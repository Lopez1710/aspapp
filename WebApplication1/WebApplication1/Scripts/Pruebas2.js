$(document).ready(function () {

    var total = 0;

    $('.table tbody').find('tr').each(function (i,el) {

        total += parseFloat($(this).find('td').eq(5).text().replace(/,/g,'.'));

        console.log(total);
    })

    $('.table tfoot tr td').eq(5).text(total.toString());


});