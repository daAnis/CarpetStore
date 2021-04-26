$('#buttonDemo2').click(function () {
    var dis = $('#dis').val();
    var total = $('#staticEmail2').val();
    $.ajax({
        type: 'GET',
        url: '/cart/discount/' + dis + total,
        success: function (result) {
            $('#staticEmail2').html(result);
        }
    });
});