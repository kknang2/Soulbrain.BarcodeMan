var StockTableContent = function (data) {
    var table = $('<table class="print">');
    table.css({
        margin: '1cm',
        width: '10cm',
        borderCollapse: 'collapse',
        pageBreakAfter: 'always'
    });
    // -- 1st row
    var tr = $('<tr>');
    tr.css({
        height: '1.25cm'
    });
    var td = $('<td>');
    td.css({
        paddingLeft: '3mm',
        border: '0.1mm solid #000'
    });
    td.html('Code No.');
    tr.append(td);
    var td = $('<td colspan=3>');
    td.css({
        paddingLeft: '3mm',
        border: '0.1mm solid #000'
    });
    td.html(data.vendorCode);
    tr.append(td);
    table.append(tr);
    // -- 2nd row
    var tr = $('<tr>');
    tr.css({
        height: '1.25cm'
    });
    var td = $('<td>');
    td.css({
        paddingLeft: '3mm',
        border: '0.1mm solid #000'
    });
    td.html('품명');
    tr.append(td);
    var td = $('<td colspan=3>');
    td.css({
        paddingLeft: '3mm',
        border: '0.1mm solid #000'
    });
    td.html(data.productName);
    tr.append(td);
    table.append(tr);
    // -- 3th row
    var tr = $('<tr>');
    tr.css({
        height: '1.25cm'
    });
    var td = $('<td>');
    td.css({
        width: '25%',
        paddingLeft: '3mm',
        border: '0.1mm solid #000'
    });
    td.html('수량');
    tr.append(td);
    var td = $('<td>');
    td.css({
        width: '25%',
        paddingLeft: '3mm',
        border: '0.1mm solid #000'
    });
    td.html(data.packingQty);
    tr.append(td);
    var td = $('<td>');
    td.css({
        width: '25%',
        paddingLeft: '3mm',
        border: '0.1mm solid #000'
    });
    td.html('단위');
    tr.append(td);
    var td = $('<td>');
    td.css({
        width: '25%',
        paddingLeft: '3mm',
        border: '0.1mm solid #000'
    });
    td.html(data.unitCode);
    tr.append(td);
    table.append(tr);
    // -- 4th row
    var tr = $('<tr>');
    tr.css({
        height: '1.25cm'
    });
    var td = $('<td>');
    td.css({
        paddingLeft: '3mm',
        border: '0.1mm solid #000'
    });
    td.html('Lot No.');
    tr.append(td);
    var td = $('<td colspan=3>');
    td.css({
        paddingLeft: '3mm',
        border: '0.1mm solid #000'
    });
    td.html(data.lotNo);
    tr.append(td);
    table.append(tr);
    // -- 5th row
    var tr = $('<tr>');
    tr.css({
        height: '1.25cm'
    });
    var td = $('<td>');
    td.css({
        paddingLeft: '3mm',
        border: '0.1mm solid #000'
    });
    td.html('제조일');
    tr.append(td);
    var td = $('<td colspan=3>');
    td.css({
        paddingLeft: '3mm',
        border: '0.1mm solid #000'
    });
    td.html(data.productDate);
    tr.append(td);
    table.append(tr);
    // -- 6th row
    var tr = $('<tr>');
    tr.css({
        height: '1.25cm'
    });
    var td = $('<td>');
    td.css({
        paddingLeft: '3mm',
        border: '0.1mm solid #000'
    });
    td.html('유효기간 ');
    tr.append(td);
    var td = $('<td colspan=3>');
    td.css({
        paddingLeft: '3mm',
        border: '0.1mm solid #000'
    });
    td.html(GetExpiryDate(data.productDate, data.expDateCode));
    tr.append(td);
    table.append(tr);
    // -- 7th row
    var tr = $('<tr>');
    tr.css({
        height: '1.25cm'
    });
    var td = $('<td>');
    td.css({
        paddingLeft: '3mm',
        border: '0.1mm solid #000'
    });
    td.html('S/P Date');
    tr.append(td);
    var td = $('<td colspan=3>');
    td.css({
        paddingLeft: '3mm',
        border: '0.1mm solid #000'
    });
    td.html(data.supplyDate);
    tr.append(td);
    table.append(tr);
    // -- 8th row
    var tr = $('<tr>');
    tr.css({
        height: '1.25cm'
    });
    var td = $('<td>');
    td.css({
        paddingLeft: '3mm',
        border: '0.1mm solid #000'
    });
    td.html('Maker');
    tr.append(td);
    var td = $('<td colspan=3>');
    td.css({
        paddingLeft: '3mm',
        border: '0.1mm solid #000'
    });
    td.html(data.maker);
    tr.append(td);
    table.append(tr);

    return table;
}

var BarcodeLabelContent = function (data) {
    var imgTop = $('<img>');
    imgTop.css({
        display: 'block',
        width: '9cm',
        height: '2cm'
    });

    var label = data.vendorCode + '  ' +
        EncodeProductDate(data.productDate) +
        data.productCode + ' ';

    JsBarcode(imgTop[0], label);

    var imgBottom = $('<img>');
    imgBottom.css({
        display: 'block',
        width: '9cm',
        height: '2cm'
    });

    var label = PadRight(data.lotNo, 10) + '   ' +
        PadLeft(data.packingQty, 3) +
        EncodeUnitCode(data.unitCode) + ' ' +
        EncodeExpDateCode(data.expDateCode) + ' ';

    JsBarcode(imgBottom[0], label);

    var div = $('<div>');
    div.css({
        margin: '1cm',
        pageBreakAfter: 'always'
    });
    div.append(imgTop).append(imgBottom);

    return div;
}