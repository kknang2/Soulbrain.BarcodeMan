App.controller('BarcodePrint', ["$rootScope", "$scope", "$http", function ($rootScope, $scope, $http) {
    $rootScope.barcodes = [];
    $scope.validate = function () {
        var checkedCount = 0;
        for (var i = 0; i < $rootScope.barcodes.length; i++) {
            var barcode = $rootScope.barcodes[i];
            if (barcode.checked) {
                checkedCount++;
                if (barcode.supplyQty == undefined) {
                    alert(barcode.productName + " " + $scope.message.supplyQty);
                    return false;
                }
                else if (barcode.lotNo == undefined) {
                    alert(barcode.productName + " " + $scope.message.lotNo);
                    return false;
                }
                else if (barcode.productDate == undefined) {
                    alert(barcode.productName + " " + $scope.message.productDate);
                    return false;
                }
                else if (barcode.expDateCode == undefined) {
                    alert(barcode.productName + " " + $scope.message.expiryDate);
                    return false;
                }
                else if (barcode.supplyDate == undefined) {
                    alert(barcode.productName + " " + $scope.message.supplyDate);
                    return false;
                }
            }
        }
        if (checkedCount == 0) {
            alert($scope.message.noSelection);
            return false;
        }
        return true;
    }
    $scope.openPopupProductList = function () {
        $("#pt_info").dialog("open");
    }
    $scope.deleteSelectedRows = function () {
        var checkedCount = 0;
        for (var i = 0; i < $rootScope.barcodes.length; i++) {
            if ($rootScope.barcodes[i].checked) {
                checkedCount++;
            }
        }
        if (checkedCount == 0) {
            alert($scope.message.noSelection);
        }
        $rootScope.barcodes = $rootScope.barcodes.filter(function (barcode) {
            return !barcode.checked;
        })
    }
    $scope.printStockTable = function () {
        if (!$scope.validate())
            return;
        var data = [];
        var html = '';
        for (var i = 0; i < $rootScope.barcodes.length; i++) {
            if ($rootScope.barcodes[i].checked && $rootScope.barcodes[i].printQty) {
                if ($rootScope.barcodes[i].lotNo == undefined) {
                    $rootScope.barcodes[i].lotNo = 0;
                }
                var table = StockTableContent({
                    vendorCode: $rootScope.barcodes[i].vendorCode,
                    productName: $rootScope.barcodes[i].productName,
                    packingQty: $rootScope.barcodes[i].packingQty,
                    unitCode: $rootScope.barcodes[i].packingUnitCode,
                    lotNo: $rootScope.barcodes[i].lotNo,
                    productDate: $rootScope.barcodes[i].productDate,
                    expDateCode: $rootScope.barcodes[i].expDateCode,
                    supplyDate: $rootScope.barcodes[i].supplyDate,
                    maker: $scope.maker
                });
                for (var j = 0; j < $rootScope.barcodes[i].printQty; j++) {
                    html += table[0].outerHTML;
                }
                data.push({
                    ProductCode: $rootScope.barcodes[i].productCode,
                    SupplyQty: $rootScope.barcodes[i].supplyQty,
                    PackingUnitCode: $rootScope.barcodes[i].packingUnitCode,
                    LotNo: $rootScope.barcodes[i].lotNo,
                    ProductDate: $rootScope.barcodes[i].productDate,
                    ExpDateCode: $rootScope.barcodes[i].expDateCode,
                    SupplyDate: $rootScope.barcodes[i].supplyDate,
                    PrintQty: $rootScope.barcodes[i].printQty,
                    PrintType: 'S'
                });
            }
        }
        var WinPrint = window.open('', '', 'left=0,top=0,width=800,height=900,toolbar=0,scrollbars=0,status=0');
        $http.post($scope.saveUrl, data).then(function (response) {
            WinPrint.document.write(html);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
        });
    }
    $scope.printBarcodeLabel = function () {
        if (!$scope.validate())
            return;
        var data = [];
        var html = '';
        for (var i = 0; i < $rootScope.barcodes.length; i++) {
            if ($rootScope.barcodes[i].checked && $rootScope.barcodes[i].printQty) {
                if ($rootScope.barcodes[i].lotNo == undefined) {
                    $rootScope.barcodes[i].lotNo = 0;
                }
                var img = BarcodeLabelContent({
                    vendorCode: $rootScope.barcodes[i].vendorCode,
                    productDate: $rootScope.barcodes[i].productDate,
                    productCode: $rootScope.barcodes[i].productCode,
                    lotNo: $rootScope.barcodes[i].lotNo,
                    packingQty: $rootScope.barcodes[i].packingQty,
                    unitCode: $rootScope.barcodes[i].packingUnitCode,
                    expDateCode: $rootScope.barcodes[i].expDateCode
                });
                for (var j = 0; j < $rootScope.barcodes[i].printQty; j++) {
                    html += img[0].outerHTML;
                }
                data.push({
                    ProductCode: $rootScope.barcodes[i].productCode,
                    SupplyQty: $rootScope.barcodes[i].supplyQty,
                    PackingUnitCode: $rootScope.barcodes[i].packingUnitCode,
                    LotNo: $rootScope.barcodes[i].lotNo,
                    ProductDate: $rootScope.barcodes[i].productDate,
                    ExpDateCode: $rootScope.barcodes[i].expDateCode,
                    SupplyDate: $rootScope.barcodes[i].supplyDate,
                    PrintQty: $rootScope.barcodes[i].printQty,
                    PrintType: 'B'
                });
            }
        }
        var WinPrint = window.open('', '', 'left=0,top=0,width=800,height=900,toolbar=0,scrollbars=0,status=0');
        $http.post($scope.saveUrl, data).then(function (response) {
            WinPrint.document.write(html);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
        });
    }
}]);
