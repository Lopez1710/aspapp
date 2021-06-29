

$(document).ready(function () {


    $('#formulario').on('change', '#articulo',function () {
 
        var selected = $('#formulario select option:selected');
        var precio = selected.data(precio);
        
        
        console.log(precio);
        document.getElementById("precio").value = precio['precio'];

        var precio2 = document.getElementById("precio").value;
        var cantidad = $('#cantidad').val();
        precio2 = precio2.replace(/,/g, '.');
        precio2 = Number.parseFloat(precio2);
        cantidad = Number.parseFloat(cantidad);
        var total = (precio2 * cantidad);
        document.getElementById("total").value = Number.parseFloat(total);
    })

    $('#formulario').on('change', '#cantidad', function () {

        var precio2 = document.getElementById("precio").value;
        var cantidad = $('#cantidad').val();
        precio2 = precio2.replace(/,/g, '.');
        precio2 = Number.parseFloat(precio2);
        cantidad = Number.parseFloat(cantidad);
        var total = (precio2 * cantidad);
        document.getElementById("total").value = Number.parseFloat(total);
    })

    
});
