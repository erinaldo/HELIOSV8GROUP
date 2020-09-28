/// <reference path="jquery-1.10.2.js" />
/// <reference path="jquery-1.10.2.js" />
var Categories = []
var Unidades = []
//fetch categories from database
//function LoadCategory(element) {
//    if (Categories.length == 0) {
//        //ajax function for fetch data
//        $.ajax({
//            type: "GET",
//            url: '/Order/getProductCategories',
//            success: function (data) {
//                Categories = data;
//                //render catagory
//                renderCategory(element);
//            }
//        })
//    }
//    else {
//        //render catagory to the element
//        renderCategory(element);
//    }
//}

//function renderCategory(element) {
//    var $ele = $(element);
//    $ele.empty();
//    var s = '<option value="-1">Please Select a Department</option>';  
//   // $ele.append($('<option/>').val('0').text('jIUNI'));
//    $.each(Categories, function (i, val) {
//     //   $ele.append($('<option/>').val(val.CategoryID).text(val.CategortyName));
//        s += '<option value="' + val.CategoryID + '">' + val.CategortyName + '</option>';
//    })
//    $("#productCategory").html(s); 
//}




//function LoadProduct(categoryDD) {
//    var val1 = $('#productCategory').val();//Equivbalencia_id
//    var val2 = $('#txtSearch').val(); //IdProducto
//    $.ajax({
//        type: "GET",
//        url: "/Order/getProducts",
//        data: { 'para1': val1, 'para2': val2 },
//        success: function (data) {
//            //render products to appropriate dropdown
//            renderProduct($(categoryDD).parents('.mycontainer').find('select.product'), data);
//        },
//        error: function (error) {
//            console.log(error);
//        }
//    })
//}




//fetch Unidades


//function LoadUnidades(categoryDD) {
//    $.ajax({
//        type: "GET",
//        url: "/Order/getUnidades",
//        data: { 'ProductID': $(categoryDD).val() },
//        success: function (data) {
//            //render products to appropriate dropdown
//            Unidades = data;
//            //renderCategory(element);
//            renderUnidades(element, data);
//        },
//        error: function (error) {
//            console.log(error);
//        }
//    })
//}
      
//#region Metodos
function LoadUnidades(categoryDD) {
    $("#quantity").val(0);
    $("#price").val(0);
    $("#rate").val(0);

    $.ajax({
        type: "GET",
        url: "/Order/getUnidades",
        data: JSON.stringify(detalleitems),
        success: function (data) {
            //render products to appropriate dropdown
            Unidades = data;
            //renderCategory(element);
            renderUnidades(element, data);
        },
        error: function (error) {
            console.log(error);
        }
    })
}

function renderProduct(element, data) {
    //render product
    var $ele = $(element);
        $ele.empty();
  //  $ele.append($('<option/>').val('0').text('-Catalogo-'));

    if (data.length == 0) {
        $("#product").prop("disabled", true);
    } else {
        $.each(data, function (i, val) {
            $ele.append($('<option/>').val(val.idCatalogo).text(val.nombre_corto));
        })
        $("#product").prop("disabled", false);
    }    

    if (data.length > 0) {
        var idCatalogo = data[0].idCatalogo;
        $.ajax({
            type: "GET",
            url: "/Order/getPrecios",
            data: { 'catalogoID': idCatalogo },
            success: function (data) {
                //render products to appropriate dropdown
                renderPrecios($("#product").parents('.mycontainer').find('select.price'), data);
            },
            error: function (error) {
                console.log(error);
            }
        })
    }
}

function renderProductTable(element, data, row) {
    //render product
    var $ele = $(element);
    $ele.empty();
    //  $ele.append($('<option/>').val('0').text('-Catalogo-'));
      
    if (data.length == 0) {
        row.find('.product').prop("disabled", true);
    } else {
        $.each(data, function (i, val) {
            $ele.append($('<option/>').val(val.idCatalogo).text(val.nombre_corto));
        })
        row.find('.product').prop("disabled", false);
    }

    if (data.length > 0) {
        var idCatalogo = data[0].idCatalogo;
        $.ajax({
            type: "GET",
            url: "/Order/getPrecios",
            data: { 'catalogoID': idCatalogo },
            success: function (data) {
            //    render products to appropriate dropdown

                //renderPreciosTable(row.find('.product').parents('.mycontainer').find('.price'), data, row);
                
                renderPreciosTable(row.find('.price'), data, row);

               // renderProductTable($row.find('.pc').parents('.mycontainer').find('.product'), data, r);
            },
            error: function (error) {
                console.log(error);
            }
        })
    }
}

function renderPrecios(element, data) {
    //render product
    var $ele = $(element);
    $ele.empty();
    // $ele.append($('<option/>').val('0').text('Select precio'));
    if (data.length == 0) {
        $("#quantity").prop("disabled", true);
        $("#price").prop("disabled", true);
    } else {
        //$.each(data, function (i, val) {
        //    //$ele.append($('<option/>').val(val.precio_id).text(val.precio));
        //    $ele.append($('<option/>').val(val.precio).text(val.precio));
        //})
        $("#quantity").prop("disabled", false);
        $("#price").prop("disabled", false);
    }   
}

function renderPreciosTable(element, data, row) {
    //render product
    var $ele = $(element);
    $ele.empty();
    // $ele.append($('<option/>').val('0').text('Select precio'));
    if (data.length == 0) {
        row.find('.quantity').prop("disabled", true);
        row.find('.price').prop("disabled", true);
        
    } else {
        //$.each(data, function (i, val) {
        //    //$ele.append($('<option/>').val(val.precio_id).text(val.precio));
        //    $ele.append($('<option/>').val(val.precio).text(val.precio));
        //})
        row.find('.quantity').prop("disabled", false);        
        row.find('.price').prop("disabled", false);
    }
}

function LoadPrecios(PriceDD) { 
    $("#quantity").val(0);
    $("#price").val(0);
    $("#rate").val(0);

    $.ajax({
        type: "GET",
        url: "/Order/getPrecios",
        data: { 'catalogoID': $(PriceDD).val() },
        success: function (data) {
            //render products to appropriate dropdown
            renderPrecios($(PriceDD).parents('.mycontainer').find('select.price'), data);

        },
        error: function (error) {
            console.log(error);
        }
    })
}

//fetch products
function LoadProduct(categoryDD) {
    //CATALOGOS PRECIOS
    $("#quantity").val(0);
    $("#price").val(0);
    $("#rate").val(0);
    $.ajax({
        type: "GET",
        url: "/Order/getProducts",
        data: { 'categoryID': $(categoryDD).val() },
        success: function (data) {
            //render products to appropriate dropdown
            renderProduct($(categoryDD).parents('.mycontainer').find('select.product'), data);
        },
        error: function (error) {
            console.log(error);
        }
    })
}

function SumarColumna(grilla, columna) {
    var resultVal = 0.0;
    //var nFilas = $("#orderdetailsItems tr").length;
    //var nColumnas = $("#orderdetailsItems tr:last td").length;
    

    Jquery102('#orderdetailsItems tr .rate').each(function () {
        //alert($(this).html());
        //alert($(this).val());
        resultVal += parseFloat($(this).val());
    });
    document.getElementById("total").value = resultVal.toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, '$1,');
    //var filas = document.querySelectorAll("#orderdetailsItems tbody tr .quantity");

}

function renderUnidades(data) {
    //var $ele = $(element);
    //$ele.empty();
    var s;// = '<option value="-1">Please Select a Unidad</option>';  
   // $ele.append($('<option/>').val('0').text('jIUNI'));
    if (data.length == 0) {
        $("#productCategory").prop("disabled", true);

        //$("#quantity").val(0);
        //$("#price").val(0);
        //$("#rate").val(0);
    } else {
        $.each(data, function (i, val) {
            //   $ele.append($('<option/>').val(val.CategoryID).text(val.CategortyName));
            s += '<option value="' + val.equivalencia_id + '">' + val.unidadComercial + '</option>';
        })
        $("#productCategory").html(s); 
        $("#productCategory").prop("disabled", false);

        //$("#quantity").val(0);
        //$("#price").val(0);
        //$("#rate").val(0);
    }    
    if (data.length > 0) {
        var idEquivale = data[0].equivalencia_id;
        //CATALOGOS PRECIOS
        $("#quantity").val(0);
        $("#price").val(0);
        $("#rate").val(0);
        $.ajax({
            type: "GET",
            url: "/Order/getProducts",
            data: { 'categoryID': idEquivale },
            success: function (data) {
                //render products to appropriate dropdown
                renderProduct($("#productCategory").parents('.mycontainer').find('select.product'), data);
            },
            error: function (error) {
                console.log(error);
            }
        })
    }

}

function recalculate() {
    SumarColumna('orderdetailsItems', 3);
}

// #endregion
var pes = jQuery.noConflict();
var Jquery102 = pes;//$.fn.jquery;
//var JQuery102 = pes;//jQuery.noConflict();//pes.fn.jquery;

//window.jQuery = Jquery331;
//window.jQuery = JQuery102;

$(document).ready(function () {
    //jQuery.noConflict();
    $("[data-toggle='tooltip']").tooltip();
    //var pes = jQuery.noConflict();

    //alert($.fn.jquery);
    //alert(pes.fn.jquery);


    //alert(Jquery102.fn.jquery);
    //alert($.fn.jquery);

    

    //$('#btnEditEntidad').hide();
    //$('#btnNuevaEntidad').hide();
  //  $('form#folderform input[type=submit]').hide()

    $("#submit").prop("disabled", true);
    $("#total").prop("disabled", true);
    $("#moneda").prop("disabled", true);
    $("#orderDate").prop("disabled", true);

    $("#productCategory").prop("disabled", true);
    $("#quantity").prop("disabled", true);
   // $("#price").prop("disabled", true);   
    $("#rate").prop("disabled", true);    
    $("#product").prop("disabled", true);
    //$('#tdPrice tr').change(function () {
    //    var dato = $(this).find('td:first').html();
    //    //$('#txtNombre').val(dato);
    //    alert(dato);
    //});

    $("#quantity").on("click", function () {
        $(this).select();
    });

    $("#price").on("click", function () {
        $(this).select();
    });

    //Add button click event
    $('#add').click(function () {
        //validation and add order items
        var isAllValid = true;

        if (Jquery102("#product_id").val() == 0) {
            alert("Ingresar un producto válido!");
            return;
        }
        

        //if ($("#product_id").val() == 0) {
        //    isAllValid = false;
        //    $('#product_id').siblings('span.error').css('visibility', 'visible');
        //}
        //else {
        //    $('#product_id').siblings('span.error').css('visibility', 'hidden');
        //}

        if (Jquery102('#txtSearch').val().trim() == '') {
            isAllValid = false;
            Jquery102('#txtSearch').siblings('span.error').css('visibility', 'visible');
        }
        else {
            Jquery102('#txtSearch').siblings('span.error').css('visibility', 'hidden');
        }

        if (Jquery102('#productCategory').val() == "0") {
            isAllValid = false;
            Jquery102('#productCategory').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#productCategory').siblings('span.error').css('visibility', 'hidden');
        }

        if (Jquery102('#product').val() == "0") {
            isAllValid = false;
            Jquery102('#product').siblings('span.error').css('visibility', 'visible');
        }
        else {
            Jquery102('#product').siblings('span.error').css('visibility', 'hidden');
        }

        if (!(Jquery102('#quantity').val().trim() != '' && (parseInt(Jquery102('#quantity').val()) || 0))) {
            isAllValid = false;
            Jquery102('#quantity').siblings('span.error').css('visibility', 'visible');
        }
        else {
            Jquery102('#quantity').siblings('span.error').css('visibility', 'hidden');
        }

        if (!(Jquery102('#rate').val().trim() != '' && !isNaN(Jquery102('#rate').val().trim()))) {
            isAllValid = false;
            Jquery102('#rate').siblings('span.error').css('visibility', 'visible');
        }
        else {
            Jquery102('#rate').siblings('span.error').css('visibility', 'hidden');
        }

        //jQuery.noConflict(false);

        if (isAllValid) {
            var $newRow = Jquery102('#mainrow').clone().removeAttr('id');
            Jquery102('.pc', $newRow).val(Jquery102('#productCategory').val());
            Jquery102('.product', $newRow).val(Jquery102('#product').val());
            Jquery102('.item', $newRow).val(Jquery102('#txtSearch').val());
            Jquery102('.quantity', $newRow).val(Jquery102('#quantity').val());
            Jquery102('.price', $newRow).val(Jquery102('#price').val());
            Jquery102('.rate', $newRow).val(Jquery102('#rate').val());
            Jquery102('#txtSearch', $newRow).prop("disabled", true);
            Jquery102('#rate', $newRow).prop("disabled", true);

            
            //Replace add button with remove button
            Jquery102('#add', $newRow).addClass('remove').val('Remove').removeClass('btn-success').addClass('btn-danger');

            //remove id attribute from new clone row
            Jquery102('#productCategory,#product,#quantity,#price,#rate,#txtSearch,#add', $newRow).removeAttr('id');
            Jquery102('span.error', $newRow).remove();
            //append clone row
            Jquery102('#orderdetailsItems').append($newRow);

            //clear select data
            //Jquery102('#productCategory').val('0');
            Jquery102('#productCategory').empty();
            Jquery102('#product').val('');
            Jquery102('#quantity,#rate').val('');
            //Jquery102('#quantity,#rate,#price').val('');
            Jquery102('#orderItemError').empty();
            Jquery102('#txtSearch').val('');
            Jquery102('#txtproductSearch').val('');
            

            recalculate();
            //Jquery102('input[id=price]').val(0);

            Jquery102('#productCategory').prop("disabled", true);
            Jquery102('#product').prop("disabled", true);
            Jquery102('#quantity').prop("disabled", true);
            Jquery102("#product_id").val(0);
            Jquery102("#submit").prop("disabled", false);
        }

    })    

    $("#btnEditEntidad").click(function () {

        if ($("input[id=nrodoc]").val().trim().length == 0) {
            alert('Ingresar un documento de identidad!');
            return;
        }

        if ($("input[id=cliente]").val().trim().length == 0) {
            alert('Ingrese la razón social/nombres!');
            return;
        }

        if ($("input[id=cliente]").val() == 'VARIOS') {            
            return;
        }
           
        if ($("input[id=cliente]").val().trim() == "Varios") {            
            return;
        }

        var idcli = $("input[id=cliente_id]").val()
        //alert(idcli);

     //   jQuery.noConflict();
        //$.ajax({

     //   var $scroll = jQuery.noConflict();

        jQuery.ajax({
            type: 'GET',
            url: '/Order/ClienteSelID',
            data: { 'idEntidad': idcli },            
            success: function (data) {                
                //    $("#loaderDiv").hide();
                alert("Cliente encontrado!");
                $("input[id=ip_cli_nro]").val(data.nrodoc);
                $("input[id=ip_cli_razon]").val(data.nombreCompleto);
                $("input[id=ip_cli_contacto]").val(data.nombreContacto);
                $("textarea[id=ip_cli_dir]").val(data.direccion);
                $("input[id=cliente_id_modal]").val(data.idEntidad);
               // event.preventDefault();
            //    jQuery.noConflict();
                $("#loginModal").modal("show");
            },
            error: function (error) {
                alert(error);
                console.log(error);
            }
        });

    });

    $("#btnNuevaEntidad").click(function () {
        
        $("input[id=cliente_id_modal]").val(0);
        $("input[id=ip_cli_nro]").val('');
        $("input[id=ip_cli_razon]").val('');
        $("input[id=ip_cli_contacto]").val('');
        $("textarea[id=ip_cli_dir]").val('');             
    });

    $("#btnSubmit").click(function () {       
        //alert($("input[id=ip_cli_nro]").val());
        //alert($("input[id=ip_cli_razon]").val());
        //alert($("input[id=ip_cli_contacto]").val());
        //alert($("textarea[id=ip_cli_dir]").val());

        if ($("input[id=ip_cli_nro]").val().trim() == '') {
            //isAllValid = false;
            //$('#txtSearch').siblings('span.error').css('visibility', 'visible');
            alert("Ingrese el nro. de documento del cliente!");
            return;
        }

        if ($("input[id=ip_cli_razon]").val().trim() == '') {
            //isAllValid = false;
            //$('#txtSearch').siblings('span.error').css('visibility', 'visible');
            alert("Ingrese un cliente valido!");
            return;
        }
        //else {
        //    //$('#txtSearch').siblings('span.error').css('visibility', 'hidden');
        //}

   
        var data = {
            idEntidad: $("input[id=cliente_id]").val(),
            idEmpresa: '20604303495',            
            idOrganizacion: 3,
            tipoEntidad: 'CL',
            tipoPersona: 'N',
            tipoDoc: '1',
            nrodoc: $("input[id=ip_cli_nro]").val().trim(),
            nombreCompleto: $("input[id=ip_cli_razon]").val().trim(),
            nombreContacto: $("input[id=ip_cli_contacto]").val().trim(),
            direccion: $("textarea[id=ip_cli_dir]").val().trim(),
            estado: 'A'
        }

       // jQuery.noConflict();
        $.ajax({
            type: 'POST',
            url: '/Order/InsertCliente',
            data: JSON.stringify(data),
            contentType: 'application/json',
            success: function (data) {
                $("#loginModal").modal("hide");
                //    $("#loaderDiv").hide();
                alert("Cliente registrado");
                $("input[id=ip_cli_nro]").val('');
                $("input[id=ip_cli_razon]").val('');
                $("input[id=ip_cli_contacto]").val('');
                $("textarea[id=ip_cli_dir]").val('');

                $('#cliente').val(data.nombreCompleto);
                $('#nrodoc').val(data.nrodoc);
                $("input[id=cliente_id]").val(data.idEntidad);
                
            },
            error: function (error) {
                alert("Error");
                console.log(error);
            }
        });

    });

    $('#quantity').keyup(function () {
        var cantidad = parseFloat($(this).val());

        if (cantidad <= 0) {
      //      alert("La cantidad debe ser mayor a cero{0}!");
            $(this).val(0);
            $('#price').val(0);
            $('#rate').val(0);
            return;
        }

        var idcatalogo = parseInt($('#product').val());

        $.ajax({
            type: 'GET',
            url: '/Order/GetCalculoPrecio',
            data: { 'idCatalogo': idcatalogo, 'cant': $(this).val() },
            success: function (data) {

            //    alert(data.precio);
                
                //    $("#loaderDiv").hide();
                //alert("Cliente encontrado!");
                //$("input[id=price]").val(data.precio);
                $("#price").val(data.precio);
              //  var precio = parseFloat($('#price').val());
                var total = cantidad * parseFloat(data.precio);
                //$("input[id=rate]").val(total);
                $("#rate").val(total)
                //$("input[id=ip_cli_contacto]").val(data.nombreContacto);
                //$("textarea[id=ip_cli_dir]").val(data.direccion);
                //$("input[id=cliente_id_modal]").val(data.idEntidad);
                //$("#loginModal").modal("show");
            },
            error: function (error) {
                alert('El producto no tiene precios configurados');
                //$("input[id=price]").val(0);
                //$("input[id=rate]").val(0);
                console.log(error);
            }
        });

//        $('#rate').val(total)
        //$('#texr2').text('New Text');
        //recalculate();
    });

    $('#price').keyup(function () {
        var precioUnitario = parseFloat($(this).val());      
        var cantidad = $('#quantity').val();        
        var total = cantidad * parseFloat(precioUnitario);
        $('#rate').val(total.toFixed(2));
        //var filas = document.querySelectorAll("#orderdetailsItems tbody tr .quantity");             
        
    });

    //$('input').change(function () {
    //    recalculate()
    //});


    //$('#orderDate').datepicker();
    //$('#orderDate').datepicker({
    //    setDate: new Date(),
    //    autoclose: true,
    //    language: "es-PE"
    //});
   
    
    Jquery102("#orderDate").datepicker({ dateFormat: "dd-mm-yyyy", autoclose: true, language: "es-PE" }).datepicker("setDate", new Date());

    //Autocomplete
    Jquery102("#txtSearch").autocomplete({
        source: "/Order/GetStudents",        
        minLength: 2,
        delay: 40,
        select: function (event, ui) {
            //$("#CityId").val(ui.item.id);
            // alert(ui.item.id);

            $("#product_id").val(ui.item.id);

            $.ajax({
                type: "GET",
                url: "/Order/getUnidades",
                data: { 'ProductID': ui.item.id },
                success: function (data) {
                    //render products to appropriate dropdown
                    renderUnidades(data);
                    $("#quantity").prop("disabled", true);
                    $("#price").prop("disabled", true);
                    $("#rate").prop("disabled", true);
                    $("#quantity").val(0);
                    $("#price").val(0);
                    $("#rate").val(0);
                },
                error: function (error) {
                    alert('Actualizar lista de items');
                    console.log(error);
                }
            })
        }
    });
     
    //Buscar cliente enter
    $('#nrodoc').keydown(function (e) {
        if (e.keyCode == 13) {

            var $t = $(this);
            $t.addClass('loading');
            $("#submit").prop("disabled", true);
            //$("input[value='OK']").focus().click();
            //alert('persionaste enter');
            //return false;
            // alert('Enviando...');
            var nro = $("#nrodoc").val();
            var selval = $('input[name=rdbcountry]:checked').val();
            //  alert(selval)
            $.ajax({
                type: "GET",
                url: "/Order/GetCliente",
                data: { 'nrodoc': nro, 'tipo': selval },
                success: function (data) {

                    //alert(data.nombreCompleto);
                    $("#cliente").val('');
                    $('#cliente').val(data.nombreCompleto);
                   // alert(data.idEntidad);
                    $("input[id=cliente_id]").val(data.idEntidad);
                    $("#submit").prop("disabled", false);
                    $t.removeClass('loading');
                },
                error: function (error) {
                    console.log(error);
                    $t.removeClass('loading');
                }
            })
            //alert(mesa);
            //return false;
        }
    });

    $('input[name=rdbcountry]').change(function () {

        $("#submit").prop("disabled", true);

        var selval = $('input[name=rdbcountry]:checked').val();
        //  alert(selval);
        if (selval == 'Cliente') {
            $("input[name='rdbcountry'][value='Varios']").prop('disabled', true);
            $("input[name='rdbcountry'][value='Cliente']").prop('disabled', true);

            $("#btnNuevaEntidad").prop("disabled", false);
            $("#btnEditEntidad").prop("disabled", false);

            $("#nrodoc").val('');
            $("#cliente").val('');
            $("#nrodoc").prop("disabled", false);
            $("#cliente").prop("disabled", true);
            $("#submit").prop("disabled", false);


            $("input[name='rdbcountry'][value='Varios']").prop('disabled', false);
            $("input[name='rdbcountry'][value='Cliente']").prop('disabled', false);
        } else {

            $("input[name='rdbcountry'][value='Varios']").prop('disabled', true);
            $("input[name='rdbcountry'][value='Cliente']").prop('disabled', true);

            $("#btnNuevaEntidad").prop("disabled", true);
            $("#btnEditEntidad").prop("disabled", true);

            var nro = $("#nrodoc").val();
            //     alert(nro);

            $("#nrodoc").val('');
            $("#cliente").val('');
            $("#nrodoc").prop("disabled", true);
            $("#cliente").prop("disabled", true);
            $.ajax({
                type: "GET",
                url: "/Order/GetCliente",
                data: { 'nrodoc': nro, 'tipo': 'Varios' },
                success: function (data) {

                    //alert(data.nombreCompleto);
                    $("#nrodoc").val('0')
                    $("#cliente").val('');
                    $('#cliente').val(data.nombreCompleto);
                    $('#cliente_id').val(data.idEntidad);
                    $("#submit").prop("disabled", false);

                    $("input[name='rdbcountry'][value='Varios']").prop('disabled', false);
                    $("input[name='rdbcountry'][value='Cliente']").prop('disabled', false);

                },
                error: function (error) {
                    console.log(error);
                    $("input[name='rdbcountry'][value='Varios']").prop('disabled', true);
                    $("input[name='rdbcountry'][value='Cliente']").prop('disabled', true);
                }
            })
        }
        //$("#nrodoc").fadeIn();
        //$('#testdiv').fadeOut();
    });


  //  $("#orderNo").editableSelect();

    //remove button click event
    $('#orderdetailsItems').on('click', '.remove', function () {
                
        $(this).parents('tr').remove();
        recalculate();

        var valid = ValidarDetalle();        
        if (valid == false) {
            $("#submit").prop("disabled", true);
        } else {
            $("#submit").prop("disabled", false);
        }

    });

    $('#orderdetailsItems').on('keyup', '.quantity', function () {
       // $(this).parents('tr').remove();
        var cantidad = parseFloat($(this).val());    

       // var precio = $('#orderdetailsItems').val();
        var $row = $(this).closest('tr');    
        //sirve
     //   var precio = parseFloat($row.find('.price').val());

        //sirve
        //var total = cantidad * precio;//$row.find('.rate').val();

        //$row.find('td').eq(5).text(total);

        //sirve
        //$row.find('.rate').val(total.toFixed(2));
        //recalculate();
        //**********

        //var total = $(this).closest('tr').find("input[id*='rate']").val();
        //var t2 = $(this).parent().parent().find("input[id*='rate']").val();
        //var t3 = $(this).parent().find("input[id*='rate']").val();
     
      //  alert(precio);
     //   alert(total);

        if (cantidad <= 0) {
            alert("La cantidad debe ser mayor a cero{0}!");
            $(this).val(0);            
            $row.find('.price').val(0)
            $row.find('.rate').val(0)
            return;
        }

        var cantidad = parseFloat($(this).val());
        var idcatalogo = parseInt($row.find('.product').val());

        $.ajax({
            type: 'GET',
            url: '/Order/GetCalculoPrecio',
            data: { 'idCatalogo': idcatalogo, 'cant': cantidad },
            success: function (data) {
                $row.find('.price').val(data.precio);    
                var total = cantidad * parseFloat(data.precio);
                $row.find('.rate').val(total.toFixed(2));    

                var filas = document.querySelectorAll("#orderdetailsItems tbody tr .quantity");

                var total = 0;

                // recorremos cada una de las filas
                filas.forEach(function (e) {

                    var $rowSel = $(e).closest('tr');
                    //var f = $(e).val();
                    var rate = parseFloat($rowSel.find('.rate').val());
                    // obtenemos las columnas de cada fila
                    //var columnas = f;//e.querySelectorAll("td");


                    // obtenemos los valores de la cantidad y importe
                    //var cantidad = (columnas[3].innerText);
                    //var importe = (columnas[3].innerHTML);

                    // mostramos el total por fila
                    //columnas[3].textContent = (cantidad * importe).toFixed(2);

                    total += rate;//cantidad * importe;
                });
                document.getElementById("total").value = total.toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, '$1,');
            },
            error: function (error) {
                alert('El producto no tiene precios configurados');
                $("input[id=price]").val(0);
                $("input[id=rate]").val(0);
                console.log(error);
            }
        });
        //recalculate();


        

    });        

    $('#orderdetailsItems').on('keyup', '.price', function () {
        
        var precioUnitario = parseFloat($(this).val());
        var $row = $(this).closest('tr');             
        var cantidad = $row.find('.quantity').val();

        //$(this)(data.precio);
        var total = cantidad * parseFloat(precioUnitario);
        $row.find('.rate').val(total.toFixed(2));

        var filas = document.querySelectorAll("#orderdetailsItems tbody tr .quantity");

        var total = 0;

        // recorremos cada una de las filas
        filas.forEach(function (e) {

            var $rowSel = $(e).closest('tr');
            //var f = $(e).val();
            var rate = parseFloat($rowSel.find('.rate').val());
            // obtenemos las columnas de cada fila
            //var columnas = f;//e.querySelectorAll("td");


            // obtenemos los valores de la cantidad y importe
            //var cantidad = (columnas[3].innerText);
            //var importe = (columnas[3].innerHTML);

            // mostramos el total por fila
            //columnas[3].textContent = (cantidad * importe).toFixed(2);

            total += rate;//cantidad * importe;
        });
        document.getElementById("total").value = total.toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, '$1,');                    

    });     

    $('#orderdetailsItems').on('change', '.rate', function () {
        // $(this).parents('tr').remove();
        alert($(this).val());  
        recalculate();
    });        

    $('#orderdetailsItems').on('change', '.pc', function () {
       
        //alert($(this).val());
  //      alert('Unidad hola');

        var $row = $(this).closest('tr');
        var ID = $row.find('.pc').val();;
        
        $row.find('.quantity').val(0);
        $row.find('.price').val(0);
        $row.find('.rate').val(0);

        var r = $row;

        $.ajax({
            type: "GET",
            url: "/Order/getProducts",
            data: { 'categoryID': ID },
            success: function (data) {
                //render products to appropriate dropdown
                //renderProduct($('#orderdetailsItems .product')).parents('.mycontainer').find('select.pc'), data);

                //renderProductTable($row.find('.pc').parents('.mycontainer').find('.product'), data, r);
                renderProductTable($row.find('.product'), data, r);

                //renderProductTable($(this).parents('.mycontainer').find('select.product'), data, r);
            },
            error: function (error) {
                console.log(error);
            }
        })
       
    });        


    $('#orderdetailsItems').on('change', '.product', function () {
                
        alert('catalogo hola');

        var $row = $(this).closest('tr');
        var ID = $row.find('.product').val();;

        $row.find('.quantity').val(0);
        $row.find('.price').val(0);
        $row.find('.rate').val(0);

        var row = $row;

        $.ajax({
            type: "GET",
            url: "/Order/getPrecios",
            data: { 'catalogoID': ID },
            success: function (data) {
                //render products to appropriate dropdown
                renderPreciosTable($row.find('.price'), data, row);

            },
            error: function (error) {
                console.log(error);
            }
        });
    });


    function ValidarDetalle() {
        var Valid = true;

        var list = [];        
        var errorItemCount = 0;
        $('#orderdetailsItems tbody tr').each(function (index, ele) {
            if (
                $('select.product', this).val() == "0" ||
                (parseInt($('.quantity', this).val()) || 0) == 0 ||
                $('.rate', this).val() == "" ||
                isNaN($('.rate', this).val())
            ) {
                errorItemCount++;
                $(this).addClass('error');
            } else {

                var orderItem = {
                    catalogo_id: $('select.product', this).val(),
                    nombreItem: $('.txtSearch', this).val(),
                    equivalencia_id: $('select.pc', this).val(),
                    monto1: parseInt($('.quantity', this).val()),
                    precioUnitario: parseFloat($('.price', this).val()),
                    FlagBonif: 'False',
                    tipoExistencia: '01',
                    importeMN: parseFloat($('.rate', this).val())
                }
                list.push(orderItem);
            }

        });

        if (errorItemCount > 0) {
            $('#orderItemError').text(errorItemCount + " invalid entry in order item list.");
            Valid = false;
        }

        if (list.length == 0) {
            $('#orderItemError').text('Al menos 1 artículo de pedido requerido.');
            Valid = false;
        }

        return Valid;
    }

    $('#submit').click(function () {
        jQuery.noConflict();
        var isAllValid = true;

        var Valid = ValidarDetalle();

        //var filas = document.querySelectorAll("#orderdetailsItems tbody tr .quantity");

        ////if (filas.length == 0) {
        ////    alert("Debe ingresar productos a la canasta");
        ////    return;
        ////}

        if (Valid) {
            if ($('#cliente').val().trim() == '') {
                alert('Ingreser un cliente');
                return;
            }

            if ($('#nrodoc').val().trim() == '') {
                alert('Ingreser un cliente');
                return;
            }


            // $("#VendedorModal").modal("show");     
            $('#jps').val('');
            Jquery102("#dialog-confirm").dialog({
                resizable: false,
                height: "auto",
                width: 400,
                modal: true,
                buttons: {
                    "Aceptar": function () {
                        Jquery102(this).dialog("close");
                        var codigoVendedor = $('#jps').val();

                        $.ajax({
                            type: 'GET',
                            url: '/Order/GetUbicarVendedor',
                            data: { 'codigoVendedor': codigoVendedor },
                            success: function (data) {
                                //validate order items
                                //$('#orderItemError').text('');
                                var list = [];
                                var errorItemCount = 0;
                                $('#orderdetailsItems tbody tr').each(function (index, ele) {
                                    if (
                                        $('select.product', this).val() == "0" ||
                                        (parseInt($('.quantity', this).val()) || 0) == 0 ||
                                        $('.rate', this).val() == "" ||
                                        isNaN($('.rate', this).val())
                                    ) {
                                        errorItemCount++;
                                        $(this).addClass('error');
                                    } else {

                                        var orderItem = {
                                            catalogo_id: $('select.product', this).val(),
                                            nombreItem: $('.txtSearch', this).val(),
                                            equivalencia_id: $('select.pc', this).val(),
                                            monto1: parseInt($('.quantity', this).val()),
                                            precioUnitario: parseFloat($('.price', this).val()),
                                            FlagBonif: 'False',
                                            tipoExistencia: '01',
                                            usuarioModificacion: data.IDUsuario,
                                            importeMN: parseFloat($('.rate', this).val())
                                        }
                                        list.push(orderItem);
                                    }

                                })

                                if (errorItemCount > 0) {
                                    $('#orderItemError').text(errorItemCount + " invalid entry in order item list.");
                                    isAllValid = false;
                                }

                                if (list.length == 0) {
                                    $('#orderItemError').text('Al menos 1 artículo de pedido requerido.');
                                    isAllValid = false;
                                }

                                if ($('#orderNo').val().trim() == '') {
                                    $('#orderNo').siblings('span.error').css('visibility', 'visible');
                                    isAllValid = false;
                                }
                                else {
                                    $('#orderNo').siblings('span.error').css('visibility', 'hidden');
                                }

                                if ($('#orderDate').val().trim() == '') {
                                    $('#orderDate').siblings('span.error').css('visibility', 'visible');
                                    isAllValid = false;
                                }
                                else {
                                    $('#orderDate').siblings('span.error').css('visibility', 'hidden');
                                }

                                if ($('#cliente').val().trim() == '') {
                                    $('#cliente').siblings('span.error').css('visibility', 'visible');
                                    isAllValid = false;
                                }
                                else {
                                    $('#cliente').siblings('span.error').css('visibility', 'hidden');
                                }

                                if ($('#nrodoc').val().trim() == '') {
                                    $('#nrodoc').siblings('span.error').css('visibility', 'visible');
                                    isAllValid = false;
                                }
                                else {
                                    $('#nrodoc').siblings('span.error').css('visibility', 'hidden');
                                }


                                if (isAllValid) {
                                    //  var now = new Date();
                                    $("#loaderDiv").show();


                                    var data = {
                                        idDocumento: 0,
                                        idEmpresa: '20604303495',
                                        idEstablecimiento: 3,
                                        fechaDoc: $('#orderDate').val().trim(),
                                        tipoOperacion: '01',
                                        codigoLibro: '1',
                                        tipoDocumento: $('#orderNo').val(),
                                        fechaLaboral: $('#orderDate').val().trim(),
                                        fechaDoc: $('#orderDate').val().trim(),
                                        fechaPeriodo: '07/2019',
                                        serieVenta: '0',
                                        numeroVenta: 1,
                                        idClientePedido: $('#cliente_id').val(),
                                        idCliente: $('#cliente_id').val(),
                                        NombreEntidad: $('#cliente').val(),
                                        NroDocEntidad: $('#nrodoc').val(),
                                        moneda: $('#moneda').val(),
                                        tipoCambio: 1,
                                        tasaIgv: 0.18,
                                        ImporteNacional: $('#total').val(),
                                        ImporteExtranjero: 0,
                                        usuarioActualizacion: data.IDUsuario,
                                        documentoventaAbarrotesDet: list
                                    }

                                    // $(this).val('Please wait...');

                                    $.ajax({
                                        type: 'POST',
                                        url: '/Order/save',
                                        data: JSON.stringify(data),
                                        contentType: 'application/json',
                                        success: function (data) {
                                            if (data.status) {
                                                alert('Pedido Registrado');
                                                //here we will clear the form
                                                list = [];
                                                // $('#cliente_id', '#cliente', '#nrodoc').val('');
                                                $('#total', '#price').val('0.00');
                                                $('#orderdetailsItems').empty();
                                                $('#submit').text('Save');
                                                $("input[id=price]").val(0)
                                                $("input[id=total]").val(0)
                                                // $("input[id=cliente]").val('')
                                                // $("input[id=nrodoc]").val('')
                                               
                                                $("#submit").prop("disabled", true);
                                                $("#btnNuevaEntidad").prop("disabled", true);
                                                $("#btnEditEntidad").prop("disabled", true);

                                                //$('input:radio[name="mygroup"][value="Varios"]').attr('checked', true);
                                                $("input[name='rdbcountry'][value='Varios']").prop('checked', true);
                                                $.ajax({
                                                    type: "GET",
                                                    url: "/Order/GetCliente",
                                                    data: { 'nrodoc': '0', 'tipo': 'Varios' },
                                                    success: function (data) {

                                                        //alert(data.nombreCompleto);
                                                        $("#nrodoc").val('0')
                                                        $("#cliente").val('');
                                                        $('#cliente').val(data.nombreCompleto);
                                                        $('#cliente_id').val(data.idEntidad);     
                                                        $('#nrodoc').prop("disabled", true);
                                                        $('#cliente').prop("disabled", true);
                                                        $("#loaderDiv").hide();
                                                    },
                                                    error: function (error) {
                                                        console.log(error);
                                                    }
                                                });

                                            }
                                            else {
                                                alert('Error');
                                            }
                                            $('#submit').text('Save');
                                        },
                                        error: function (error) {
                                            console.log(error);
                                            $('#submit').text('Save');
                                        }
                                    });
                                }
                            },
                            error: function (error) {
                                alert('No se encontro un vendedor con el código ingresado!');
                                console.log(error);
                            }
                        });
                    },
                    Cancel: function () {
                        Jquery102(this).dialog("close");
                    }
                }
            });
        }
    });                
});

//LoadCategory($('#productCategory'));
