$('#buttonDemo2').click(function () { 
    var dis = $('#dis').val();
    var total = $('#staticEmail2').val();
    $.ajax({
        type: 'GET',
        url: '/cart/discount/' + dis + '/' + total,
        success: function (result) {
            $('#staticEmail2').val(result);
        }
    });
});


/*$('#minus-btn').click(function () {
    var q = $('#quant').val();
    $ajax({
        type: 'GET',
        url: 'cart/remove/' + q,
        success: function (result) {
            $('#quant').val(result);
        }
    });
});*/