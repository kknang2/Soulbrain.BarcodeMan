App.controller('PopupProduct', ["$rootScope", "$scope", "$http", function ($rootScope, $scope, $http) {
    $scope.filter = {
        offset: 0
    };
    $scope.items = [];
    $scope.finishedLoading = false;
    $scope.getFilteredProducts = function () {
        $scope.items = [];
        $scope.finishedLoading = false;
        $scope.filter.offset = 0;
        $scope.getProducts();
    }
    $scope.getProducts = function () {
        if ($scope.finishedLoading)
            return;
        $http.get($scope.url, {
            params: $scope.filter
        }).then(function (response) {
            $scope.items = $scope.items.concat(response.data.items);
            $scope.filter.offset += response.data.items.length;
            if (response.data.totalCount == $scope.items.length) {
                $scope.finishedLoading = true;
            }
        });
    }
    $scope.addRows = function () {
        for (var i = 0; i < $scope.items.length; i++) {
            if ($scope.items[i].checked) {
                if (checkIfNotSelected($scope.items[i].productCode)) {
                    $rootScope.barcodes.push({
                        vendorCode: $scope.items[i].vendorCode,
                        productCode: $scope.items[i].productCode,
                        productName: $scope.items[i].productName,
                        packingQty: $scope.items[i].packingQty,
                        packingUnitCode: $scope.items[i].packingUnitCode,
                        printQty: 1
                    });
                }
            }
        }
    }
    var checkIfNotSelected = function (productCode) {
        for (var i = 0; i < $rootScope.barcodes.length; i++) {
            if ($rootScope.barcodes[i].productCode == productCode) {
                return false;
            }
        }
        return true;
    }
}]);
