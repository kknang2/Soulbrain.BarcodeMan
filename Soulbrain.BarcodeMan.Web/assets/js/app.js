var App = angular.module('app', [])
    .directive("datepicker", function () {
        return {
            restrict: "A",
            require: "ngModel",
            link: function (scope, elem, attrs, ngModelCtrl) {
                var updateModel = function (dateText) {
                    scope.$apply(function () {
                        ngModelCtrl.$setViewValue(dateText);
                    });
                };
                var options = {
                    onSelect: function (dateText) {
                        updateModel(dateText);
                    }
                };
                elem.datepicker(options);
            }
        }
    })
    .directive('advice', [function () {
        return {
            restrict: 'A',
            link: function (scope, element, attrs) {
                var self = $(element),
                    adviceDialog = $(attrs.advice);

                self.click(function () {
                    adviceDialog.dialog({
                        width: 900,
                        height: 600,
                        closeText: "",
                        resizable: false,
                        autoOpen: false,
                        title: attrs.title,
                        modal: true,
                        close: function () {
                            adviceDialog.dialog('destroy');
                        }
                    });

                    adviceDialog.dialog('open');
                });

                //adviceDialog.find('button').click(function () {
                //    adviceDialog.dialog('close');
                //});
            }
        }
    }])
    .directive('scrolly', function () {
        return {
            restrict: 'A',
            link: function (scope, element, attrs) {
                element.bind('scroll', function () {
                    if ($(this).scrollTop() + $(this).innerHeight() >= $(this)[0].scrollHeight) {
                        scope.$apply(attrs.scrolly);
                    }
                })
            }
        }
    });

$(function(){
    $.datepicker.setDefaults($.datepicker.regional[$('html').attr('lang')]);
    $.datepicker.setDefaults({
        dateFormat: 'yy-mm-dd'
    });
})

var InitDatepicker = function (element) {
    $.datepicker.setDefaults($.datepicker.regional[$('html').attr('lang')]);
    element.datepicker({});
};

var PadLeft = function (num, size) {
    var s = "0000000000" + num;
    return s.substr(s.length - size);
};

var PadRight = function (num, size) {
    var s = num + "0000000000";
    return s.substr(0, size);
};

var EncodeProductDate = function (dateString) {
    var date = new Date(dateString);
    var y = date.getFullYear() % 1000 % 100 % 10;
    var m = date.getMonth() + 1;
    var d = date.toString("dd");
    switch (m) {
        case 10:
            m = 'X';
            break;
        case 11:
            m = 'Y';
            break;
        case 12:
            m = 'Z';
            break;
        default:
            m = m;
            break;
    }
    return '' + y + m + d;
}

var EncodeUnitCode = function (code) {
    var encodedCode = '';

    switch (code) {
        case 'Kg':
        default:
            encodedCode = 'A';
            break;
        case 'g':
            encodedCode = 'B';
            break;
        case 'L':
            encodedCode = 'C';
            break;
        case 'ml':
            encodedCode = 'D';
            break;
    }

    return encodedCode;
}

var EncodeExpDateCode = function (code) {
    var encodedCode = '';

    switch (code) {
        case '1':
        default:
            encodedCode = 'A';
            break;
        case '3':
            encodedCode = 'B';
            break;
        case '6':
            encodedCode = 'C';
            break;
        case '9':
            encodedCode = 'D';
            break;
        case '12':
            encodedCode = 'E';
            break;
        case '18':
            encodedCode = 'F';
            break;
        case '24':
            encodedCode = 'G';
            break;
    }

    return encodedCode;
}

var GetExpiryDate = function (productDateString, expDateCode) {
    var productDate = new Date(productDateString);
    productDate.addMonths(expDateCode).addDays(-1);

    //if ($('html').attr('lang') == 'ko')
        return productDate.toString('yyyy-MM-dd');

    //return productDate.toLocaleDateString($('html').attr('lang'));
}