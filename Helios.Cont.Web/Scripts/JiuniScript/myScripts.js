/// <reference path="jquery-1.10.2.js" />
/// <reference path="jquery-1.10.2.js" />
var Categories = []
var Unidades = []
var list = [];
var ClienteSelected = null;


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

function SelectedValue(ddlObject) {
    //Selected value of dropdownlist  
    var selectedValue = ddlObject.value;
    //Selected text of dropdownlist  
    var selectedText = ddlObject.options[ddlObject.selectedIndex].innerHTML;

    //alert popup with detail of seleceted value and text  
    //alert(" Selected Value: " + selectedValue + " -- " + "Selected Text: " + selectedText);
    $("#dtPagos tbody tr").remove();    
    LoadCajasTable(selectedValue);
    //MappingPagos();
}  


function SelectedValueCajaVenta(ddlObject) {
    //Selected value of dropdownlist  
    var selectedValue = ddlObject.value;
    //Selected text of dropdownlist  
    var selectedText = ddlObject.options[ddlObject.selectedIndex].innerHTML;

    //alert popup with detail of seleceted value and text  
    //alert(" Selected Value: " + selectedValue + " -- " + "Selected Text: " + selectedText);
    $("#dtPagos tbody tr").remove();
    LoadCajasTableVenta(selectedValue);
    //MappingPagos();
}  

function LoadCajasTableVenta(id) {
    //Call EmpDetails jsonResult Method  
    $.getJSON("EmpDetails?id=" + id,
        function (json) {
            var tr;
            var montoTr;
            var IdFormaPagoTR;
            var EntidadTR;
            var ID_ENTIDADTR;

            var montoTotal = $("#total").val();

            //Append each row to html table  
            for (var i = 0; i < json.length; i++) {
                tr = $('<tr/>');

             
                montoTr = "<td>" + "<input type='number' class='form-control input-sm' name='montoTR' id='montoAbonado' style='width:95px;text-align:center; background-color :#FCFCFC' value='" + parseFloat(montoTotal) + "' />" + "</td>";
             


                IdFormaPagoTR = "<td>" + "<input type='hidden' name='formapg_id' id='formapg_id' value='" + json[i].IDFormaPago + "' />" + "</td>";

                ID_ENTIDADTR = "<td>" + "<input type='hidden' name='idcaja' id='idcaja'value='" + json[i].identidad + "' />" + "</td>";
                //EntidadTR = "<td>" + "<input type='text' name='caja' id='caja'value='" + json[i].entidad + "' disabled/>" + "</td>";
                EntidadTR = "<td>" + "<input type='hidden' name='caja' id='caja'value='" + json[i].entidad + "' disabled/>" + "</td>";



                
                //tr.append("<td>" + json[i].entidad + "</td>");                
                //tr.append("<td>" + "0.00" + "</td>");
                tr.append(montoTr);
                tr.append("<td>" + "NUEVO SOL" + "</td>");
                tr.append(IdFormaPagoTR);
                tr.append("<td>" + "<span class='label label-primary'>" + json[i].FormaPago + "</span></td>");
                tr.append("<td>" + "<input type='hidden' name='formapago' id='formapago' value='" + json[i].FormaPago + "' />" + "</td>");
                tr.append(ID_ENTIDADTR);
                tr.append(EntidadTR);
                //<span class='label label-warning'>Pending</span>
                $('#dtPagos').append(tr);
            }
        });
}

function LoadCajasTable(id) {
    //Call EmpDetails jsonResult Method  
    $.getJSON("EmpDetails?id="+id,
        function (json) {
            var tr;
            var montoTr;
            var IdFormaPagoTR;
            var EntidadTR;
            var ID_ENTIDADTR;
            //Append each row to html table  
            for (var i = 0; i < json.length; i++) {
                tr = $('<tr/>');

                if (typeof PedidoSeleccionado != 'undefined') {
                    if (json[i].moneda == "1" && json[i].FormaPago  == "EFECTIVO") {
                        montoTr = "<td>" + "<input type='number' name='montoTR' id='montoAbonado' value='" + PedidoSeleccionado.ImporteNacional + "' />" + "</td>";
                    } else {
                        montoTr = "<td>" + "<input type='number' name='montoTR' id='montoAbonado' value='" + 0 + "' />" + "</td>";
                    }
                    
                } else {
                    montoTr = "<td>" + "<input type='number' name='montoTR' id='montoAbonado' />" + "</td>";
                }       

                
                IdFormaPagoTR = "<td>" + "<input type='hidden' name='formapg_id' id='formapg_id' value='" + json[i].IDFormaPago + "' />" + "</td>";

                ID_ENTIDADTR = "<td>" + "<input type='hidden' name='idcaja' id='idcaja'value='" + json[i].identidad + "' />" + "</td>";
                EntidadTR = "<td>" + "<input type='text' name='caja' id='caja'value='" + json[i].entidad + "' disabled/>" + "</td>";
                
               

                tr.append(ID_ENTIDADTR);
                tr.append(EntidadTR);
                //tr.append("<td>" + json[i].entidad + "</td>");                
                //tr.append("<td>" + "0.00" + "</td>");
                tr.append(montoTr);
                if (json[i].moneda == "1") {
                    tr.append("<td>" + "<span class='label label-success'>" + "NUEVO SOL" + "</span></td>");
                } else {
                    tr.append("<td>" + "<span class='label label-success'>" + "MONEDA EXTRANJERA" + "</span></td>");
                }
                
                tr.append(IdFormaPagoTR);
                tr.append("<td>" + "<span class='label label-primary'>" + json[i].FormaPago + "</span></td>");
                tr.append("<td>" + "<input type='hidden' name='formapago' id='formapago' value='" + json[i].FormaPago + "' />" + "</td>");
                //<span class='label label-warning'>Pending</span>
                $('#dtPagos').append(tr);
            }
        });  
}

function LoadPedidosTable() {
    //Call EmpDetails jsonResult Method  
    $.getJSON("GetPedidosPendientes",
        function (json) {
            var tr;
            var trButton;
            var trButtonDelete;
            //Append each row to html table  
            for (var i = 0; i < json.length; i++) {

                var date = new Date(parseInt(json[i].fechaDoc.substr(6)));
                var month = date.getMonth() + 1;
                var fechaVenta = date.getDate() + "/" + month + "/" + date.getFullYear() + " " + date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds();

                tr = $('<tr/>');
                trButton = "<td>" + "<input type='button' id='Confirmarventa' value='Cobrar' class='btn btn-success btn-xs' />" + "</td>";
                trButtonDelete = "<td>" + "<input type='button' id='Deleteventa' value='Eliminar' class='btn btn-danger btn-xs' />" + "</td>";

                tr.append("<td>" + json[i].idDocumento + "</td>");
                tr.append("<td>" + fechaVenta + "</td>");
                tr.append("<td>" + "Vendedor" + "</td>");
           //     tr.append(montoTr);
                tr.append("<td>" + json[i].numeroVenta + "</td>");
                tr.append("<td>" + json[i].NombreEntidad + "</td>");
                tr.append("<td>" + json[i].NroDocEntidad + "</td>");
                tr.append("<td>" + json[i].moneda + "</td>");
                tr.append("<td>" + parseFloat(json[i].ImporteNacional).toFixed(2) + "</td>");
                tr.append(trButton);
                tr.append(trButtonDelete);
                $('#dtPedidosPendientes').append(tr);
            }
        });
}

function GetDetalleVentaInfo(id) {
    $.getJSON("GetVentaID?id=" + id,
        function (json) {
            var tr;

            for (var valor of json.documentoventaAbarrotesDet)
            {
                tr = $('<tr/>');
                tr.append("<td>" + valor.idDocumento + "</td>");
                tr.append("<td>" + valor.secuencia + "</td>");
                tr.append("<td>" + valor.nombreItem + "</td>");
                tr.append("<td>" + valor.unidad1 + "</td>");
                tr.append("<td>" + valor.monto1 + "</td>");
                tr.append("<td>" + "0.00" + "</td>");
                tr.append("<td>" + valor.importeMN + "</td>");              
                tr.append("<td>" + valor.AfectoInventario + "</td>");
                //tr.append("<td>" + "<span class='label label-primary'>" + json[i].FormaPago + "</span></td>");
                //tr.append("<td>" + "<input type='hidden' name='formapago' id='formapago' value='" + json[i].FormaPago + "' />" + "</td>");
                //<span class='label label-warning'>Pending</span>
                $('#dtDetalleVenta').append(tr);
            }        
        });  
}

function GetDetalleVentaInfoV2() {   
            if (typeof PedidoSeleccionado == 'undefined') {
                alert("Debe seleccionar un pedido!");
                return;
            }

            if (PedidoSeleccionado === null) {
                alert("Debe seleccionar un pedido!");
                return;
            }        
            var tr;
            for (var valor of PedidoSeleccionado.documentoventaAbarrotesDet) {
                tr = $('<tr/>');
                tr.append("<td>" + valor.idDocumento + "</td>");
                tr.append("<td>" + valor.secuencia + "</td>");
                tr.append("<td>" + valor.nombreItem + "</td>");
                tr.append("<td>" + valor.unidad1 + "</td>");
                tr.append("<td>" + valor.monto1 + "</td>");
                tr.append("<td>" + "0.00" + "</td>");
                tr.append("<td>" + valor.importeMN + "</td>");               
             //   tr.append("<td>" + valor.AfectoInventario + "</td>");
                if (valor.AfectoInventario == true) {
                    tr.append("<td>" + "<input type='checkbox' name='CheckRow' id='myCheckRow' checked>" + "</td>");
                } else {
                    tr.append("<td>" + "<input type='checkbox' name='CheckRow' id='myCheckRow'>" + "</td>");
                }
                
                //tr.append("<td>" + "<span class='label label-primary'>" + json[i].FormaPago + "</span></td>");
                //tr.append("<td>" + "<input type='hidden' name='formapago' id='formapago' value='" + json[i].FormaPago + "' />" + "</td>");
                //<span class='label label-warning'>Pending</span>
                $('#dtDetalleVenta').append(tr);
            }  
}
      
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
    

    $('#orderdetailsItems tr .rate').each(function () {
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

function displayToastr() {
    //alert('yes');
    // Display a info toast, with no title
    toastr.info('Hi Mahedee, This information for you.')

    // Display a warning toast, with no title
    toastr.warning('Hi Mahedee, This the first warning for you!')

    // Display a success toast, with a title
    toastr.success('Yes! You have successfully completed your task!', 'Congratulation for you, Mahedee!')

    // Display an error toast, with a title
    toastr.error('An error occured in the solution!', 'Please contact with system administrator.')
}

function recalculate() {
    SumarColumna('orderdetailsItems', 3);
}


var pes = jQuery.noConflict();
var Jquery102 = pes;//$.fn.jquery;


$(document).ready(function () {
    //jQuery.noConflict();
     
  //  displayToastr();
    //$("#TextRuc").prop('disabled', true);
    //$("#TextComprador").prop('disabled', true);
    //$("#TextComprador").val("VARIOS");

    $("[data-toggle='tooltip']").tooltip();

    //sweetAlert("Congratulations!!");  
    //sweetAlert({
    //    title: "Do you want to save it?",
    //    text: "Please check Information before Submiting!",
    //    type: "warning",
    //    showCancelButton: true,
    //    confirmButtonColor: "#DD6B55",
    //    confirmButtonText: "Save",
    //    cancelButtonText: "Cancel",
    //    closeOnConfirm: false,
    //    closeOnCancel: false
    //},
    //    function (isConfirm) {
    //        if (isConfirm) {
    //            if (validateData() == true) {
    //                $("#CreateForm").submit();
    //            }
    //        } else {
    //            swal("Cancelled", "You have Cancelled Form Submission!", "error");
    //        }
    //    }); 

    //var pes = jQuery.noConflict();

   // alert($.fn.jquery);
  //  alert(pes.fn.jquery);


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

    $("#btLogout").on("click", function () {
      //  alert('Logout');
    
        $.ajax({

            type: 'POST',
            dataType: 'json',
            contentType: 'application/json',
            url: '/Account/checkSession',
            data: '{}',
            success: function (data) {
                //alert(data);
                if (data == true) {
                    //location.href = "/Account/Demo"
                }
                else {
                    location.href = "/Account/Login"
                }
            },
            error: function (xhr) {
                alert('error');
            }
        }); 
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
            Jquery102('.CheckRow', $newRow).val(Jquery102('#CheckRow').val());

            Jquery102('#txtSearch', $newRow).prop("disabled", true);
            Jquery102('#rate', $newRow).prop("disabled", true);


            //Replace add button with remove button
            Jquery102('#add', $newRow).addClass('remove').val('Remove').removeClass('btn-success').addClass('btn-danger');

            //remove id attribute from new clone row
            Jquery102('#productCategory,#product,#quantity,#price,#rate,#txtSearch,#CheckRow, #add', $newRow).removeAttr('id');
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
            Jquery102("#submitVentaDirecta").prop("disabled", false);
            MappingPagosVentaDirecta();
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
            idEmpresa: '20602665063',
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

                    document.getElementById("txtSearch").title = ui.item.value; 
                },
                error: function (error) {
                    alert('Actualizar lista de items');
                    console.log(error);
                }
            })
        }
    });

    $('#nrodocCli').keydown(function (e) {
        if (e.keyCode == 13) {

            //var $t = $(this);           
            var nro = $("#nrodocCli").val();
            var selval = 'Cliente';// $('input[name=rbCliente]:checked').val();
            //  alert(selval)
            $.ajax({
                type: "GET",
                url: "/Order/GetCliente",
                data: { 'nrodoc': nro, 'tipo': selval },
                success: function (data) {

                    //alert(data.nombreCompleto);
                    $("#clienterazon").val('');
                    $('#clienterazon').val(data.nombreCompleto);
                    // alert(data.idEntidad);
                    $("input[id=clienteid]").val(data.idEntidad);
                    //$("#submit").prop("disabled", false);
                    
                },
                error: function (error) {
                    console.log(error);                   
                }
            })
            //alert(mesa);
            //return false;
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

    $('input[name=rbCliente]').change(function () {

        $("#submit").prop("disabled", true);

        var selval = $('input[name=rbCliente]:checked').val();
        //  alert(selval);
        if (selval == 'Cliente') {
            $("input[name='rbCliente'][value='Varios']").prop('disabled', true);
            $("input[name='rbCliente'][value='Cliente']").prop('disabled', true);
                 
            $("#nrodocCli").val('');
            $("#clienterazon").val('');
            $("#nrodocCli").prop("disabled", false);
            $("#clienterazon").prop("disabled", true);         


            $("input[name='rbCliente'][value='Varios']").prop('disabled', false);
            $("input[name='rbCliente'][value='Cliente']").prop('disabled', false);
        } else {

            $("input[name='rbCliente'][value='Varios']").prop('disabled', true);
            $("input[name='rbCliente'][value='Cliente']").prop('disabled', true);

            var nro = $("#nrodocCli").val();
            //     alert(nro);

            $("#nrodocCli").val('');
            $("#clienterazon").val('');
            $("#nrodocCli").prop("disabled", true);
            $("#clienterazon").prop("disabled", true);
            $.ajax({
                type: "GET",
                url: "/Order/GetCliente",
                data: { 'nrodoc': nro, 'tipo': 'Varios' },
                success: function (data) {

                    //alert(data.nombreCompleto);
                    $("#nrodocCli").val('0')
                    $("#clienterazon").val('');
                    $('#clienterazon').val(data.nombreCompleto);
                    $('#clienteid').val(data.idEntidad);
               
                    $("input[name='rbCliente'][value='Varios']").prop('disabled', false);
                    $("input[name='rbCliente'][value='Cliente']").prop('disabled', false);

                },
                error: function (error) {
                    console.log(error);
                    $("input[name='rbCliente'][value='Varios']").prop('disabled', true);
                    $("input[name='rbCliente'][value='Cliente']").prop('disabled', true);
                }
            })
        }
        //$("#nrodoc").fadeIn();
        //$('#testdiv').fadeOut();
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
        MappingPagosVentaDirecta();
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
       // jQuery.noConflict();
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

                                    var date = Date(Date.now());

                                    var dt = new Date(date);
                                    var mes = dt.getMonth() + 1;
                                    mes = String.format("{0:00}", mes);
                                    var anio = dt.getFullYear();
                                    var regPeriodo = mes + "/" + anio

                                    var data = {
                                        idDocumento: 0,
                                        idEmpresa: '20602665063',
                                        idEstablecimiento: 3,
                                        fechaDoc: $('#orderDate').val().trim(),
                                        tipoOperacion: '01',
                                        codigoLibro: '1',
                                        tipoDocumento: $('#orderNo').val(),
                                        fechaLaboral: $('#orderDate').val().trim(),
                                        fechaDoc: $('#orderDate').val().trim(),
                                        fechaPeriodo: regPeriodo,
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
                                                toastr.success('Pedido registrado!')
                                                //alert('Pedido Registrado');
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
                                            toastr.error('Error al grabar pedido!')
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


    $('#submitVentaDirecta').click(function () {

        var listCaja = [];
        var ID_CAJA_USUARIO = $("#ComboCajasActivas").val();

        // jQuery.noConflict();
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

                                    var $rowDet = $(this).closest('tr');

                                    var idProducto = $rowDet.find('#product_id').val();
                                    var checke = $rowDet.find('input[name=CheckRow]:checked').val();
                                    var invent;
                                    if (checke == "on") {
                                        invent = true;
                                    } else {
                                        invent = false;
                                    }
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
                                            idItem: idProducto,
                                            nombreItem: $('.txtSearch', this).val(),
                                            equivalencia_id: $('select.pc', this).val(),
                                            monto1: parseInt($('.quantity', this).val()),
                                            precioUnitario: parseFloat($('.price', this).val()),
                                            FlagBonif: 'False',
                                            tipoExistencia: '01',
                                            bonificacion: false,
                                            usuarioModificacion: data.IDUsuario,
                                            AfectoInventario: invent,
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
                                    
                                   // var periodo = $('#orderDate').val();
                                    var date = Date(Date.now());

                                    var dt = new Date(date);
                                    var mes = dt.getMonth() + 1;
                                    mes = String.format("{0:00}", mes);                                    
                                    var anio = dt.getFullYear();
                                    var regPeriodo = mes + "/" + anio


                                  //  var myName = <%= LoginInformation.Empresa.idEmpresa %>;                              

                                    var dataventa = {
                                        idDocumento: 0,
                                        idEmpresa: '20602665063',
                                        idEstablecimiento: 3,
                                        fechaDoc: $('#orderDate').val().trim(),
                                        tipoOperacion: '01',
                                        codigoLibro: '1',
                                        tipoDocumento: $('#orderNo').val(),
                                        fechaLaboral: $('#orderDate').val().trim(),
                                        fechaDoc: $('#orderDate').val().trim(),
                                        fechaPeriodo: regPeriodo,
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
                                                                        
                                    // Registrar Documentos de pago **************************************************************************

                                    $('#dtPagos tbody tr').each(function () {
                                        var $row = $(this).closest('tr');
                                        //var ID = $row.find('td:eq(0)').text();        
                                        var ImporteAbonado = $row.find('#montoAbonado').val();
                                        var ID_Forma = $row.find('#formapg_id').val();
                                        var Forma = $row.find('#formapago').val();
                                        var idEntidad = $row.find('#idcaja').val();
                                        var Entidad = $row.find('#caja').val();

                                                                               
                                        var dataCaja = {
                                            tipoOperacion: '9908',
                                            periodo: dataventa.fechaPeriodo,
                                            idEmpresa: dataventa.idEmpresa,
                                            idEstablecimiento: dataventa.idEstablecimiento,
                                            fechaProceso: dataventa.fechaDoc,
                                            fechaCobro: dataventa.fechaDoc,
                                            tipoMovimiento: 'DC',
                                            codigoProveedor: dataventa.idCliente,
                                            IdProveedor: dataventa.idCliente,
                                            idPersonal: dataventa.idCliente,
                                            TipoDocumentoPago: '9903',
                                            codigoLibro: '1',
                                            tipoDocPago: dataventa.tipoDocumento,
                                            formapago: ID_Forma,
                                            formaPagoName: Forma,
                                            NumeroDocumento: '-',
                                            numeroOperacion: '',
                                            movimientoCaja: 'VELC',
                                            montoSoles: ImporteAbonado,
                                            moneda: dataventa.moneda,
                                            tipoCambio: dataventa.tipoCambio,
                                            montoUsd: 0,
                                            estado: '1',
                                            glosa: 'Venta cobrada!',
                                            entregado: 'SI',
                                            idCajaUsuario: ID_CAJA_USUARIO,
                                            entidadFinanciera: idEntidad,
                                            NombreEntidad: Entidad,
                                            usuarioModificacion: dataventa.usuarioActualizacion
                                        }
                                        listCaja.push(dataCaja);
                                    })


                                    if (typeof listCaja == 'undefined') {
                                        alert("Debe agregar el pago de la venta!");
                                        return;
                                    }

                                    if (listCaja === null) {
                                        alert("Debe agregar el pago de la venta!");
                                        return;
                                    }      

                                    if (listCaja.length == 0) {
                                        alert("Debe agregar el pago de la venta!");
                                        return;
                                    }        

                                    //********************************************************************************************************
                                    //Documento General
                                    var data = {
                                        TipoEnvio: 'VENTA',
                                        idEmpresa: '20602665063',
                                        idCentroCosto: 3,
                                        idProyecto: 0,
                                        tipoDoc: $('#orderNo').val(),
                                        fechaProceso: $('#orderDate').val().trim(),
                                        moneda: '1',
                                        idEntidad: $('#cliente_id').val(),
                                        entidad: $('#cliente').val(),
                                        tipoEntidad: 'CL',
                                        nrodocEntidad: $('#nrodoc').val(),
                                        nroDoc: '0',
                                        idOrden: 0,
                                        tipoOperacion: "01",
                                        usuarioActualizacion: data.IDUsuario,
                                        documentoventaAbarrotes: dataventa,
                                        ListaCustomDocumentoCaja: listCaja
                                    }


                                    // $(this).val('Please wait...');


                                    $.ajax({
                                        type: 'POST',
                                        url: '/Order/saveVentaCaja',
                                        data: JSON.stringify(data),
                                        contentType: 'application/json',
                                        success: function (data) {
                                            if (data.status) {
                                                toastr.success('Venta registrada!')
                                                //alert('Pedido Registrado');
                                                //here we will clear the form
                                                list = [];
                                                // $('#cliente_id', '#cliente', '#nrodoc').val('');
                                                $('#total', '#price').val('0.00');
                                                $('#orderdetailsItems').empty();
                                                $('#submitVentaDirecta').text('Save');
                                                $("input[id=price]").val(0)
                                                $("input[id=total]").val(0)
                                                // $("input[id=cliente]").val('')
                                                // $("input[id=nrodoc]").val('')

                                                $("#submitVentaDirecta").prop("disabled", true);
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
                                                        RiniciarPagos();
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
                                            $('#submitVentaDirecta').text('Save');
                                        },
                                        error: function (request, status, error) {
                                            valor = request.responseText.match(/<title>([\s\S]*)<\/title>/)[1];//Solo para reciuperar caracteres                                    
                                            toastr.error(valor);
                                            $('#submitVentaDirecta').text('Save');
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

    $("#btnFilterProduct").click(function () {
        $("#dtProducts tbody tr").remove();
        var filter = $("#TextFilter").val();
        RenderProductTableDB(filter);

        //GetProductSelText(filter);
    });

    function GetProductSelText(Text) {
        //Call EmpDetails jsonResult Method  
        listProductSelCategory = [];              
        var filter = Text.toUpperCase();
        //var prod = listProductsGeneral.map((item) => item.descripcionItem)
        //    .includes(res)
        //const ProductMatchings = listProductsGeneral.filter(c => c.descripcionItem.includes(filter));

                
        const filterItems = (letters) => {
            return listProductsGeneral.filter(name => name.descripcionItem.indexOf(letters) > -1);
        } 

        //var results = filterItems('KIGCOL');
        var results = filterItems(filter);

        //const startsWithN = listProductsGeneral.filter((c) => c.descripcionItem.startsWith(res));
                       
        RenderProductTable(results);

   
        
        //$.getJSON("/Order/GetProductSelText?Text=" + Text,
        //    function (json) {
        //        var tr;
        //        Append each row to html table                  
        //        var ColumnID;
        //        var columnName;
        //        var columnPrice;
        //        var columnBtn;
        //        var labelHistory = '';
        //        var labelRender = '';            
        //        var columnCatalogo;
        //        for (var i = 0; i < json.length; i++) {

        //            var numero = i;
        //            var resto = numero % 2;
        //            if (resto == 0) {
        //                columnPrice = "<td>" + "<span class='label label-primary pull-right'>" + "S/" + parseFloat(json[i].detalleitem_equivalencias[0].detalleitemequivalencia_catalogos[0].detalleitemequivalencia_precios[0].precio).toFixed(2) + "</span>" + "</td>";
        //            } else {
        //                columnPrice = "<td>" + "<span class='label label-success pull-right'>" + "S/" + parseFloat(json[i].detalleitem_equivalencias[0].detalleitemequivalencia_catalogos[0].detalleitemequivalencia_precios[0].precio).toFixed(2) + "</span>" + "</td>";
        //            }

        //            if (labelHistory == '') {
        //                labelHistory = "<span style='font-size:11px;' class='label label-success pull-right'>";
        //                labelRender = "<span style='font-size:11px;' class='label label-success pull-right'>";
        //            } else if (labelHistory == "<span style='font-size:11px;' class='label label-success pull-right'>") {
        //                labelHistory = "<span style='font-size:11px;' class='label label-warning pull-right'>";
        //                labelRender = "<span style='font-size:11px;' class='label label-warning pull-right'>";
        //            } else if (labelHistory == "<span style='font-size:11px;' class='label label-warning pull-right'>") {
        //                labelHistory = "<span style='font-size:11px;' class='label label-danger pull-right'>";
        //                labelRender = "<span style='font-size:11px;' class='label label-danger pull-right'>";
        //            } else if (labelHistory == "<span style='font-size:11px;' class='label label-danger pull-right'>") {
        //                labelHistory = "<span style='font-size:11px;' class='label label-info pull-right'>";
        //                labelRender = "<span style='font-size:11px;' class='label label-info pull-right'>";
        //            } else if (labelHistory == "<span style='font-size:11px;' class='label label-info pull-right'>") {
        //                labelHistory = '';
        //                labelRender = "<span style='font-size:11px;' class='label label-default pull-right'>";
        //            }

        //            columnPrice = "<td>" + labelRender + "S/ " + parseFloat(json[i].detalleitem_equivalencias[0].detalleitemequivalencia_catalogos[0].detalleitemequivalencia_precios[0].precio).toFixed(2) + "</span>" + "</td>";

        //            var obj = json[i];
        //            listProductSelCategory.push(obj);

        //            tr = $('<tr/>');

        //            ColumnID = "<td style='display: none;'>" + "<input type='checkbox' style='display: none'>" + json[i].codigodetalle + "</td>";
        //            columnName = "<td class='mailbox-name'><a href='#'>" + json[i].descripcionItem + "</a></td>";
        //            columnName = "<td class='mailbox-name'>" + json[i].descripcionItem + "</td>";

        //            columnUnidad = ""

        //            var itemsUnidades = '';
        //            var result = json[i].detalleitem_equivalencias;
        //            for (var q = 0; q < result.length; q++) {                    
        //                itemsUnidades += "<option value =" + result[q].equivalencia_id + ">" + result[q].unidadComercial + "</option>";

        //                var itemsCatalogos = '';
        //                var resultCatalogos = result[q].detalleitemequivalencia_catalogos;
        //                for (var cat = 0; cat < resultCatalogos.length; cat++) {
        //                    itemsCatalogos += "<option value =" + resultCatalogos[cat].idCatalogo + ">" + resultCatalogos[cat].nombre_corto + "</option>";
        //                }
        //            }
                                      
        //            var htmlextraUnidadComercial = "<select id='comboUnidadComercial' class='pull-left' style='border: 1px solid whitesmoke; margin: 2px;'>" +
        //                itemsUnidades + "</select>";

        //            var htmlextraCatalogos = "<select id='comboCatalogo' class='pull-right' style='border: 1px solid whitesmoke; margin: 2px;'>" +
        //                itemsCatalogos + "</select>";

        //            var htmlextraCatalogos = "<select id='old' class='pull-right' style='border: 1px solid whitesmoke; margin: 2px;'>< option value ='volvo'>Volvo</option><option value='saab'>Saab</option>" +
        //                "<option value='vw'>VW</option>" +
        //                "<option value='audi' selected>Audi</option></select>";

        //            columnName = "<td><span class='product-description'>" + json[i].descripcionItem + "</span>" + "<br />" + htmlextraUnidadComercial + htmlextraCatalogos + "</td >";

        //            columnName = "<td><span class='product-description'>" + json[i].descripcionItem + "</span>" + "<br />" + "</td >";

        //            GetCombos(json[i].detalleitem_equivalencias);
        //            columnName = "<td>" + "class='mailbox-name'><a href='#'>" + json[i].detalleitem_equivalencias[0].detalleitemequivalencia_catalogos[0].detalleitemequivalencia_precios[0].precio + "</a></td>";
        //             columnPrice = "<td class='mailbox-subject'><b>" + json[i].detalleitem_equivalencias[0].detalleitemequivalencia_catalogos[0].detalleitemequivalencia_precios[0].precio + "</b></td>";                                    


        //            columnPrice = "<td>" + "<span class='badge'>" + parseFloat(json[i].detalleitem_equivalencias[0].detalleitemequivalencia_catalogos[0].detalleitemequivalencia_precios[0].precio).toFixed(2) + "</span>" + "</td>";
        //            columnBtn = "<td><input id='btnAdditem' type='button' value='+' class='btn btn-warning btn-xs'> <span class='glyphicon glyphicon-trash'></span></td>";
                    
        //            columnBtn = "<td><button id='btnAdditem' type='button' class='btn bg-light-blue btn-sm'><span class='fa fa fa-plus-square'></span></button ></td>";


        //            Maping tabla Produts
        //            tr.append(ColumnID);
        //            tr.append(columnName);
        //            tr.append(columnPrice);
        //            tr.append(columnBtn);
        //            <span class='label label-warning'>Pending</span>
        //            $('#dtProducts').append(tr);
        //        }
        //    });
    }

    function RenderProductTableDB(Text) {
        listProductSelCategory = [];           

         $.getJSON("/Order/GetProductSelText?Text=" + Text,
            function (json) {
                var tr;
                //Append each row to html table                  
                var ColumnID;
                var columnName;
                var columnPrice;
                var columnBtn;
                var labelHistory = '';
                var labelRender = '';
                var columnCatalogo;
                for (var i = 0; i < json.length; i++) {

                    //var numero = i;
                    //var resto = numero % 2;
                    //if (resto == 0) {
                    //    columnPrice = "<td>" + "<span class='label label-primary pull-right'>" + "S/" + parseFloat(json[i].detalleitem_equivalencias[0].detalleitemequivalencia_catalogos[0].detalleitemequivalencia_precios[0].precio).toFixed(2) + "</span>" + "</td>";
                    //} else {
                    //    columnPrice = "<td>" + "<span class='label label-success pull-right'>" + "S/" + parseFloat(json[i].detalleitem_equivalencias[0].detalleitemequivalencia_catalogos[0].detalleitemequivalencia_precios[0].precio).toFixed(2) + "</span>" + "</td>";
                    //}

                    if (labelHistory == '') {
                        labelHistory = "<span style='font-size:11px;' class='label label-success pull-right'>";
                        labelRender = "<span style='font-size:11px;' class='label label-success pull-right'>";
                    } else if (labelHistory == "<span style='font-size:11px;' class='label label-success pull-right'>") {
                        labelHistory = "<span style='font-size:11px;' class='label label-warning pull-right'>";
                        labelRender = "<span style='font-size:11px;' class='label label-warning pull-right'>";
                    } else if (labelHistory == "<span style='font-size:11px;' class='label label-warning pull-right'>") {
                        labelHistory = "<span style='font-size:11px;' class='label label-danger pull-right'>";
                        labelRender = "<span style='font-size:11px;' class='label label-danger pull-right'>";
                    } else if (labelHistory == "<span style='font-size:11px;' class='label label-danger pull-right'>") {
                        labelHistory = "<span style='font-size:11px;' class='label label-info pull-right'>";
                        labelRender = "<span style='font-size:11px;' class='label label-info pull-right'>";
                    } else if (labelHistory == "<span style='font-size:11px;' class='label label-info pull-right'>") {
                        labelHistory = '';
                        labelRender = "<span style='font-size:11px;' class='label label-default pull-right'>";
                    }


                    var price = 0;//json[i].detalleitem_equivalencias[0].detalleitemequivalencia_catalogos[0].detalleitemequivalencia_precios[0].precio;
                    var count = json[i].detalleitem_equivalencias[0].detalleitemequivalencia_catalogos[0].detalleitemequivalencia_precios.length;
                    if (count == 0) {
                        price = 0;
                    } else {
                        price = json[i].detalleitem_equivalencias[0].detalleitemequivalencia_catalogos[0].detalleitemequivalencia_precios[0].precio;
                    }

                    columnPrice = "<td>" + labelRender + "S/ " + parseFloat(price).toFixed(2) + "</span>" + "</td>";

                    var obj = json[i];
                    listProductSelCategory.push(obj);

                    tr = $('<tr/>');

                    ColumnID = "<td style='display: none;'>" + "<input type='checkbox' style='display: none'>" + json[i].codigodetalle + "</td>";
                    //columnName = "<td class='mailbox-name'><a href='#'>" + json[i].descripcionItem + "</a></td>";
                    //   columnName = "<td class='mailbox-name'>" + json[i].descripcionItem + "</td>";

                    //  columnUnidad = ""

                    var itemsUnidades = '';
                    var result = json[i].detalleitem_equivalencias;
                    for (var q = 0; q < result.length; q++) {
                        itemsUnidades += "<option value =" + result[q].equivalencia_id + ">" + result[q].unidadComercial + "</option>";

                        var itemsCatalogos = '';
                        var resultCatalogos = result[q].detalleitemequivalencia_catalogos;
                        for (var cat = 0; cat < resultCatalogos.length; cat++) {
                            itemsCatalogos += "<option value =" + resultCatalogos[cat].idCatalogo + ">" + resultCatalogos[cat].nombre_corto + "</option>";
                        }
                    }

                    var htmlextraUnidadComercial = "<select id='comboUnidadComercial' class='pull-left' style='border: 1px solid whitesmoke; margin: 2px;'>" +
                        itemsUnidades + "</select>";

                    var htmlextraCatalogos = "<select id='comboCatalogo' class='pull-right' style='border: 1px solid whitesmoke; margin: 2px;'>" +
                        itemsCatalogos + "</select>";

                    //var htmlextraCatalogos = "<select id='old' class='pull-right' style='border: 1px solid whitesmoke; margin: 2px;'>< option value ='volvo'>Volvo</option><option value='saab'>Saab</option>" +
                    //    "<option value='vw'>VW</option>" +
                    //    "<option value='audi' selected>Audi</option></select>";

                    //columnName = "<td><span class='product-description'>" + json[i].descripcionItem + "</span>" + "<br />" + htmlextraUnidadComercial + htmlextraCatalogos + "</td >";

                    columnName = "<td><span class='product-description'>" + json[i].descripcionItem + "</span>" + "<br />" + "</td >";

                    //   GetCombos(json[i].detalleitem_equivalencias);
                    //columnName = "<td>" + "class='mailbox-name'><a href='#'>" + json[i].detalleitem_equivalencias[0].detalleitemequivalencia_catalogos[0].detalleitemequivalencia_precios[0].precio + "</a></td>";
                    // columnPrice = "<td class='mailbox-subject'><b>" + json[i].detalleitem_equivalencias[0].detalleitemequivalencia_catalogos[0].detalleitemequivalencia_precios[0].precio + "</b></td>";                                    


                    //columnPrice = "<td>" + "<span class='badge'>" + parseFloat(json[i].detalleitem_equivalencias[0].detalleitemequivalencia_catalogos[0].detalleitemequivalencia_precios[0].precio).toFixed(2) + "</span>" + "</td>";
                    //columnBtn = "<td><input id='btnAdditem' type='button' value='+' class='btn btn-warning btn-xs'> <span class='glyphicon glyphicon-trash'></span></td>";

                    columnBtn = "<td><button id='btnAdditem' type='button' class='btn bg-light-blue btn-sm'><span class='fa fa fa-plus-square'></span></button ></td>";


                    //Maping tabla Produts
                    tr.append(ColumnID);
                    tr.append(columnName);
                    tr.append(columnPrice);
                    tr.append(columnBtn);
                    //<span class='label label-warning'>Pending</span>
                    $('#dtProducts').append(tr);
                }
            });
    }

    function RenderProductTable(json) {
        var tr;
        //Append each row to html table                  
        var ColumnID;
        var columnName;
        var columnPrice;
        var columnBtn;
        var labelHistory = '';
        var labelRender = '';
        var columnCatalogo;
        for (var i = 0; i < json.length; i++) {

            //var numero = i;
            //var resto = numero % 2;
            //if (resto == 0) {
            //    columnPrice = "<td>" + "<span class='label label-primary pull-right'>" + "S/" + parseFloat(json[i].detalleitem_equivalencias[0].detalleitemequivalencia_catalogos[0].detalleitemequivalencia_precios[0].precio).toFixed(2) + "</span>" + "</td>";
            //} else {
            //    columnPrice = "<td>" + "<span class='label label-success pull-right'>" + "S/" + parseFloat(json[i].detalleitem_equivalencias[0].detalleitemequivalencia_catalogos[0].detalleitemequivalencia_precios[0].precio).toFixed(2) + "</span>" + "</td>";
            //}

            if (labelHistory == '') {
                labelHistory = "<span style='font-size:11px;' class='label label-success pull-right'>";
                labelRender = "<span style='font-size:11px;' class='label label-success pull-right'>";
            } else if (labelHistory == "<span style='font-size:11px;' class='label label-success pull-right'>") {
                labelHistory = "<span style='font-size:11px;' class='label label-warning pull-right'>";
                labelRender = "<span style='font-size:11px;' class='label label-warning pull-right'>";
            } else if (labelHistory == "<span style='font-size:11px;' class='label label-warning pull-right'>") {
                labelHistory = "<span style='font-size:11px;' class='label label-danger pull-right'>";
                labelRender = "<span style='font-size:11px;' class='label label-danger pull-right'>";
            } else if (labelHistory == "<span style='font-size:11px;' class='label label-danger pull-right'>") {
                labelHistory = "<span style='font-size:11px;' class='label label-info pull-right'>";
                labelRender = "<span style='font-size:11px;' class='label label-info pull-right'>";
            } else if (labelHistory == "<span style='font-size:11px;' class='label label-info pull-right'>") {
                labelHistory = '';
                labelRender = "<span style='font-size:11px;' class='label label-default pull-right'>";
            }


            var price = 0;//json[i].detalleitem_equivalencias[0].detalleitemequivalencia_catalogos[0].detalleitemequivalencia_precios[0].precio;
            var count = json[i].detalleitem_equivalencias[0].detalleitemequivalencia_catalogos[0].detalleitemequivalencia_precios.length;
            if (count == 0) {
                price = 0;
            } else {
                price = json[i].detalleitem_equivalencias[0].detalleitemequivalencia_catalogos[0].detalleitemequivalencia_precios[0].precio;
            }           

            columnPrice = "<td>" + labelRender + "S/ " + parseFloat(price).toFixed(2) +  "</span>" + "</td>";

            var obj = json[i];
            listProductSelCategory.push(obj);

            tr = $('<tr/>');

            ColumnID = "<td style='display: none;'>" + "<input type='checkbox' style='display: none'>" + json[i].codigodetalle + "</td>";
            //columnName = "<td class='mailbox-name'><a href='#'>" + json[i].descripcionItem + "</a></td>";
            //   columnName = "<td class='mailbox-name'>" + json[i].descripcionItem + "</td>";

            //  columnUnidad = ""

            var itemsUnidades = '';
            var result = json[i].detalleitem_equivalencias;
            for (var q = 0; q < result.length; q++) {
                itemsUnidades += "<option value =" + result[q].equivalencia_id + ">" + result[q].unidadComercial + "</option>";

                var itemsCatalogos = '';
                var resultCatalogos = result[q].detalleitemequivalencia_catalogos;
                for (var cat = 0; cat < resultCatalogos.length; cat++) {
                    itemsCatalogos += "<option value =" + resultCatalogos[cat].idCatalogo + ">" + resultCatalogos[cat].nombre_corto + "</option>";
                }
            }

            var htmlextraUnidadComercial = "<select id='comboUnidadComercial' class='pull-left' style='border: 1px solid whitesmoke; margin: 2px;'>" +
                itemsUnidades + "</select>";

            var htmlextraCatalogos = "<select id='comboCatalogo' class='pull-right' style='border: 1px solid whitesmoke; margin: 2px;'>" +
                itemsCatalogos + "</select>";

            //var htmlextraCatalogos = "<select id='old' class='pull-right' style='border: 1px solid whitesmoke; margin: 2px;'>< option value ='volvo'>Volvo</option><option value='saab'>Saab</option>" +
            //    "<option value='vw'>VW</option>" +
            //    "<option value='audi' selected>Audi</option></select>";

            //columnName = "<td><span class='product-description'>" + json[i].descripcionItem + "</span>" + "<br />" + htmlextraUnidadComercial + htmlextraCatalogos + "</td >";

            columnName = "<td><span class='product-description'>" + json[i].descripcionItem + "</span>" + "<br />" + "</td >";

            //   GetCombos(json[i].detalleitem_equivalencias);
            //columnName = "<td>" + "class='mailbox-name'><a href='#'>" + json[i].detalleitem_equivalencias[0].detalleitemequivalencia_catalogos[0].detalleitemequivalencia_precios[0].precio + "</a></td>";
            // columnPrice = "<td class='mailbox-subject'><b>" + json[i].detalleitem_equivalencias[0].detalleitemequivalencia_catalogos[0].detalleitemequivalencia_precios[0].precio + "</b></td>";                                    


            //columnPrice = "<td>" + "<span class='badge'>" + parseFloat(json[i].detalleitem_equivalencias[0].detalleitemequivalencia_catalogos[0].detalleitemequivalencia_precios[0].precio).toFixed(2) + "</span>" + "</td>";
            //columnBtn = "<td><input id='btnAdditem' type='button' value='+' class='btn btn-warning btn-xs'> <span class='glyphicon glyphicon-trash'></span></td>";

            columnBtn = "<td><button id='btnAdditem' type='button' class='btn bg-light-blue btn-sm'><span class='fa fa fa-plus-square'></span></button ></td>";


            //Maping tabla Produts
            tr.append(ColumnID);
            tr.append(columnName);
            tr.append(columnPrice);
            tr.append(columnBtn);
            //<span class='label label-warning'>Pending</span>
            $('#dtProducts').append(tr);
        }
    }


    $('#dtProducts tbody').on('click', 'tr td #btnAdditem', function () {
        var el = this;
        var $row = $(this).closest('tr');
        var ID = $row.find('td:eq(0)').text();
        var Item = listProductSelCategory.filter(p => p.codigodetalle == ID);

        var o = Object(Item);
        var content = JSON.stringify(o);
        var obj = JSON.parse(content);
        var nombre = obj[0].descripcionItem;
        var IDunidadComercial = $row.find('#comboUnidadComercial').val()
        
        // obj[0].AfectoInventario = invent;

        // alert(nombre);

        // $(el).closest('tr').css('background', 'yellow');
        //$("#someElement").fadeOut(100).fadeIn(100).fadeOut(100).fadeIn(100);

        $(el).closest('tr').css({ opacity: 0 });
        $(el).closest('tr').animate({ opacity: 1 }, 700);
        addItemToBasket(obj);
        //$(el).closest('tr').fadeIn(800, function () {
        //    addItemToBasket(obj);
        //    $(el).closest('tr').css('background', 'white');
        //});


        //   addItemToBasket(obj);


        ////document.getElementById("dtPedidosPendientes").innerHTML = "";
        //$("#dtPedidosPendientes tbody tr").remove();
        //LoadPedidosTable();
    });

    $('#TextFilter').keyup(function () {      
        //$("#dtProducts tbody tr").remove();
        //var filter = $("#TextFilter").val();
        //GetProductSelText(filter)
    });

    $('#dtBasquetSale tbody').on('click', 'tr td #btnMinusItemBasquet', function () {
        var $row = $(this).closest('tr');
        var ID = $row.find('td:eq(0)').text();
        var inforExtra = $row.find('#Colinfo').val();
        var cantidad = parseFloat($row.find('#quantity').val());
        var suma = parseFloat(cantidad - 0.01).toFixed(2);
        if (suma == 0) {
            suma = 1;
        }
        $row.find('#quantity').val(suma);

        var IDunidadComercial = $row.find('#comboUnidadComercial').val()
        var IDunidadCatalogo = $row.find('#comboCatalogo').val()

        var Item = list.filter(p => p.codigodetalle == ID);

        var o = Object(Item);
        var content = JSON.stringify(o);
        var obj = JSON.parse(content);

        //Equivalencias Unidades comerciales
        var Listaequivalencias = obj[0].detalleitem_equivalencias;
        var equivalenciaSel = Listaequivalencias.filter(p => p.equivalencia_id == IDunidadComercial);
        var oeq = Object(equivalenciaSel);
        var contenteq = JSON.stringify(oeq);
        var objeq = JSON.parse(contenteq);

        //Catalogo de precios
        var ListaCatalogos = objeq[0].detalleitemequivalencia_catalogos;
        var catalogoSel = ListaCatalogos.filter(c => c.idCatalogo == IDunidadCatalogo);
        var ocat = Object(catalogoSel);
        var contentcat = JSON.stringify(ocat);
        var objcat = JSON.parse(contentcat);

        var precioVenta = CalculoPrecioVenta(suma, objcat[0]);
        $row.find('#puItem').text(precioVenta);
        //Calculo        
        var precioUnitario = parseFloat($row.find('#puItem').text());
        // var precioUnitario2 = parseFloat($row.find('#puItem').text());

        var total = parseFloat(suma * precioUnitario).toFixed(2);

        $row.find('#totalItemSale').val(total);
        SumBasquetSale();  
        MappingPagosVentaDirecta();

    });   

    $('#dtBasquetSale tbody').on('click', 'tr td #btnDeleteItemBasquet', function () {
        var el = this;
        var $row = $(this).closest('tr');
        var ID = $row.find('td:eq(0)').text();

        var Item = list.filter(p => p.codigodetalle == ID);

        var o = Object(Item);
        var content = JSON.stringify(o);
        var obj = JSON.parse(content);
        //var nombre = obj[0].descripcionItem;


        var objIndex = list.findIndex((r => r.codigodetalle == ID));
        list.splice(objIndex, 1);

        //$(this).parents('tr').remove();
        $(el).closest('tr').css('background', 'tomato');
        $(el).closest('tr').fadeOut(400, function () {
            $(this).remove();
            SumBasquetSale();
            MappingPagosVentaDirecta();
            //$(this).parents('tr').remove();
        });
    });

    $('#dtBasquetSale tbody').on('click', 'tr td #btnPlusItemBasquet', function () {
        var $row = $(this).closest('tr');
        var ID = $row.find('td:eq(0)').text();
        var inforExtra = $row.find('#Colinfo').val();
        var cantidad = parseFloat($row.find('#quantity').val());
        var suma = parseFloat(cantidad + 0.01).toFixed(2);
        $row.find('#quantity').val(suma); 

        var IDunidadComercial = $row.find('#comboUnidadComercial').val()
        var IDunidadCatalogo = $row.find('#comboCatalogo').val()

        var Item = list.filter(p => p.codigodetalle == ID);

        var o = Object(Item);
        var content = JSON.stringify(o);
        var obj = JSON.parse(content);

        //Equivalencias Unidades comerciales
        var Listaequivalencias = obj[0].detalleitem_equivalencias;
        var equivalenciaSel = Listaequivalencias.filter(p => p.equivalencia_id == IDunidadComercial);
        var oeq = Object(equivalenciaSel);
        var contenteq = JSON.stringify(oeq);
        var objeq = JSON.parse(contenteq);

        //Catalogo de precios
        var ListaCatalogos = objeq[0].detalleitemequivalencia_catalogos;
        var catalogoSel = ListaCatalogos.filter(c => c.idCatalogo == IDunidadCatalogo);
        var ocat = Object(catalogoSel);
        var contentcat = JSON.stringify(ocat);
        var objcat = JSON.parse(contentcat);

        var precioVenta = CalculoPrecioVenta(suma, objcat[0]);
        $row.find('#puItem').text(precioVenta);
        //Calculo        
        var precioUnitario = parseFloat($row.find('#puItem').text());
        // var precioUnitario2 = parseFloat($row.find('#puItem').text());

        var total = parseFloat(suma * precioUnitario).toFixed(2);

        $row.find('#totalItemSale').val(total);
        SumBasquetSale();    
        MappingPagosVentaDirecta();
    });   

    $('#dtBasquetSale tbody').on('change', 'tr td #comboUnidadComercial', function () {    

     //   alert('Equivalencia hola');

        var $row = $(this).closest('tr');
        var ID = $row.find('td:eq(0)').text();
        var inforExtra = $row.find('#Colinfo').val();
        var cantidad = parseFloat($row.find('#quantity').val());
        var suma = cantidad;        
        $row.find('#quantity').val(suma);
        var r = $row;

        var IDunidadComercial = $row.find('#comboUnidadComercial').val()
              
        var IDunidadCatalogo = $row.find('#comboCatalogo').val()

        var Item = list.filter(p => p.codigodetalle == ID);

        var o = Object(Item);
        var content = JSON.stringify(o);
        var obj = JSON.parse(content);

        //Equivalencias Unidades comerciales
        var Listaequivalencias = obj[0].detalleitem_equivalencias;
        var equivalenciaSel = Listaequivalencias.filter(p => p.equivalencia_id == IDunidadComercial);
        var oeq = Object(equivalenciaSel);
        var contenteq = JSON.stringify(oeq);
        var objeq = JSON.parse(contenteq);


        renderCatalogosTable($row.find('#comboCatalogo'), objeq[0].detalleitemequivalencia_catalogos, r);


        //Catalogo de precios
        //var ListaCatalogos = objeq[0].detalleitemequivalencia_catalogos;
        //var catalogoSel = ListaCatalogos.filter(c => c.idCatalogo == IDunidadCatalogo);
        //var ocat = Object(catalogoSel);
        //var contentcat = JSON.stringify(ocat);
      //  var objcat = JSON.parse(contentcat);

        //var precioVenta = CalculoPrecioVenta(suma, objcat[0]);
        //$row.find('#puItem').text(precioVenta);
        ////Calculo        
        //var precioUnitario = parseFloat($row.find('#puItem').text());
        //// var precioUnitario2 = parseFloat($row.find('#puItem').text());

        //var total = parseFloat(suma * precioUnitario).toFixed(2);

        //$row.find('#totalItemSale').val(total);
        //SumBasquetSale();          
   
    });

    $('#dtBasquetSale tbody').on('change', 'tr td #comboCatalogo', function () {

      //  alert('precio hola');
              
        var $row = $(this).closest('tr');
        var ID = $row.find('td:eq(0)').text();
        var inforExtra = $row.find('#Colinfo').val();
        var cantidad = parseFloat($row.find('#quantity').val());
        var suma = cantidad;
        $row.find('#quantity').val(suma);

        var IDunidadComercial = $row.find('#comboUnidadComercial').val()
        var IDunidadCatalogo = $row.find('#comboCatalogo').val()

        var Item = list.filter(p => p.codigodetalle == ID);

        var o = Object(Item);
        var content = JSON.stringify(o);
        var obj = JSON.parse(content);

        //Equivalencias Unidades comerciales
        var Listaequivalencias = obj[0].detalleitem_equivalencias;
        var equivalenciaSel = Listaequivalencias.filter(p => p.equivalencia_id == IDunidadComercial);
        var oeq = Object(equivalenciaSel);
        var contenteq = JSON.stringify(oeq);
        var objeq = JSON.parse(contenteq);

        //Catalogo de precios
        var ListaCatalogos = objeq[0].detalleitemequivalencia_catalogos;
        var catalogoSel = ListaCatalogos.filter(c => c.idCatalogo == IDunidadCatalogo);
        var ocat = Object(catalogoSel);
        var contentcat = JSON.stringify(ocat);
        var objcat = JSON.parse(contentcat);

        var precioVenta = CalculoPrecioVenta(suma, objcat[0]);
        $row.find('#puItem').text(precioVenta);
        //Calculo        
        var precioUnitario = parseFloat($row.find('#puItem').text());
        // var precioUnitario2 = parseFloat($row.find('#puItem').text());

        var total = parseFloat(suma * precioUnitario).toFixed(2);

        $row.find('#totalItemSale').val(total);

        if (objcat[0].detalleitemequivalencia_precios.length == 0) {
            $row.find('#totalItemSale').prop('disabled', true);
        } else {
            $row.find('#totalItemSale').prop('disabled', false);
        }

        SumBasquetSale();          
        MappingPagosVentaDirecta();
    });


    $('#dtBasquetSale tbody').on('keyup mouseup', 'tr td #totalItemSale', function (e) {

        var $row = $(this).closest('tr');
        let precUnit = 0;
        let cantidad = $row.find('#quantity').val();
        let total = $row.find('#totalItemSale').val();
        precUnit = parseFloat(total / cantidad).toFixed(2);
        $row.find('#puItem').text(precUnit);
        SumBasquetSale();
        MappingPagosVentaDirecta();
    });

    $('#cboTipoPago').on('change', function () {

        var valor = $("#cboTipoPago").val();
        if (valor == "CONTADO") {
            $("#cajero").show();
            $("#tablePagosDiv").show();
        } else if (valor == "CREDITO") {            
            $('#cajero').hide();
            $("#tablePagosDiv").hide();
        }                     
    });


    $('#dtBasquetSale tbody').on('keyup mouseup', 'tr td #quantity', function (e) {

        var $row = $(this).closest('tr');
        var ID = $row.find('td:eq(0)').text();
        var inforExtra = $row.find('#Colinfo').val();
        let cantidad = ($row.find('#quantity').val());
        let suma = cantidad;// + 1;
        $row.find('#quantity').val(suma);

        var IDunidadComercial = $row.find('#comboUnidadComercial').val()
        var IDunidadCatalogo = $row.find('#comboCatalogo').val()

        var Item = list.filter(p => p.codigodetalle == ID);

        var o = Object(Item);
        var content = JSON.stringify(o);
        var obj = JSON.parse(content);

        //Equivalencias Unidades comerciales
        var Listaequivalencias = obj[0].detalleitem_equivalencias;
        var equivalenciaSel = Listaequivalencias.filter(p => p.equivalencia_id == IDunidadComercial);
        var oeq = Object(equivalenciaSel);
        var contenteq = JSON.stringify(oeq);
        var objeq = JSON.parse(contenteq);

        //Catalogo de precios
        var ListaCatalogos = objeq[0].detalleitemequivalencia_catalogos;
        var catalogoSel = ListaCatalogos.filter(c => c.idCatalogo == IDunidadCatalogo);
        var ocat = Object(catalogoSel);
        var contentcat = JSON.stringify(ocat);
        var objcat = JSON.parse(contentcat);

        var precioVenta = CalculoPrecioVenta(suma, objcat[0]);
        $row.find('#puItem').text(precioVenta);
        //Calculo        
        var precioUnitario = parseFloat($row.find('#puItem').text());
        // var precioUnitario2 = parseFloat($row.find('#puItem').text());

        var total = parseFloat(suma * precioUnitario).toFixed(2);

        $row.find('#totalItemSale').val(total);
        SumBasquetSale();    
        MappingPagosVentaDirecta();
    });

    $("#TextFilter").on('keyup', function (e) {
        if (e.keyCode === 13) {
            // Do something
            $("#dtProducts tbody tr").remove();
            var filter = $("#TextFilter").val();
            //GetProductSelText(filter);
            RenderProductTableDB(filter);
        }
    });

    $('#TextRuc').keydown(function (e) {
        if (e.keyCode == 13) {

            //var $t = $(this);           
            var nro = $("#TextRuc").val();
            var selval = 'Cliente';// $('input[name=rbCliente]:checked').val();
            //  alert(selval)
            $.ajax({
                type: "GET",
                url: "/Order/GetCliente",
                data: { 'nrodoc': nro, 'tipo': selval },
                success: function (data) {
                    ClienteSelected = data;
                    //alert(data.nombreCompleto);
                    if (data == null) {
                        $("#TextRuc").val('');
                        ClienteSelected = null;
                    } else {
                        $("#TextComprador").val('');
                        $('#TextComprador').val(data.nombreCompleto);
                    }
                    
                    // alert(data.idEntidad);
                //    $("input[id=TextRuc]").val(data.idEntidad);
                    //$("#submit").prop("disabled", false);

                },
                error: function (error) {
                    ClienteSelected = null;
                    $("#TextComprador").val('');
                    $("#TextRuc").val('');
                    console.log(error);
                }
            })
            //alert(mesa);
            //return false;
        }
    });


    $('#chCliente').change(function () {
        $("#TextComprador").val("");
        $("#TextRuc").val("");

        if (this.checked != true) {            
            $("#TextRuc").prop('disabled', false);
            $("#TextComprador").prop('disabled', false);
            $("#TextComprador").val("");
            ClienteSelected = null;
        }
        else {

            $("#TextRuc").prop('disabled', true);
            $("#TextComprador").prop('disabled', true);
            $("#TextComprador").val("VARIOS");
            ClienteSelected = ClienteVarios;
            
        }
    });
});

function addItemToBasket(json) {
    var tr;
    var ColumnID;
    // var columnMinus;
    var ColumnCantidad;
    //var columnPlus;
  //  var ColumnUnidadComercial;
    var ColumnProducto;
    var ColumnTotal;
    var ColumnInfoExtra;
    var ColumnLlevar;
    var columnBtn;
    // for (var i = 0; i < json.length; i++) {
    var obj = json[0];
    list.push(obj);

    tr = $('<tr/>');

    var itemsUnidades = '';
    var result = json[0].detalleitem_equivalencias;
    for (var q = 0; q < result.length; q++) {
        if (q == 0) {
            itemsUnidades += "<option value =" + result[q].equivalencia_id + " selected>" + result[q].unidadComercial + "</option>";

            var itemsCatalogos = '';
            var resultCatalogos = result[q].detalleitemequivalencia_catalogos;
            for (var cat = 0; cat < resultCatalogos.length; cat++) {
                itemsCatalogos += "<option value =" + resultCatalogos[cat].idCatalogo + ">" + resultCatalogos[cat].nombre_corto + "</option>";
            }
        } else {
            itemsUnidades += "<option value =" + result[q].equivalencia_id + ">" + result[q].unidadComercial + "</option>";
        }       
        
    }

    var htmlextraUnidadComercial = "<select id='comboUnidadComercial' class='pull-left' style='border: 1px solid whitesmoke; margin: 2px;'>" +
        itemsUnidades + "</select>";

    var htmlextraCatalogos = "<select id='comboCatalogo' class='pull-left' style='border: 1px solid whitesmoke; margin: 2px;'>" +
        itemsCatalogos + "</select>";

    var price = 0;//json[i].detalleitem_equivalencias[0].detalleitemequivalencia_catalogos[0].detalleitemequivalencia_precios[0].precio;
    var count = json[0].detalleitem_equivalencias[0].detalleitemequivalencia_catalogos[0].detalleitemequivalencia_precios.length;
    if (count == 0) {
        price = 0;
    } else {
        price = parseFloat(json[0].detalleitem_equivalencias[0].detalleitemequivalencia_catalogos[0].detalleitemequivalencia_precios[0].precio).toFixed(2);
    }

  //  columnPrice = "<td>" + labelRender + "S/ " + parseFloat(price).toFixed(2) + "</span>" + "</td>";



  //  var precio = parseFloat(json[0].detalleitem_equivalencias[0].detalleitemequivalencia_catalogos[0].detalleitemequivalencia_precios[0].precio).toFixed(2);
    ColumnID = "<td style='display: none;' class='mailbox-subject' style='font-size: smaller'>" + json[0].codigodetalle + "</td>";
    // columnMinus = "<td width:20%>" + "<button id='btnMinusItemBasquet' type='button' class='btn btn-danger btn-xs'>-</button>" + "</td>";
    ColumnCantidad = "<td>" + "<button id='btnMinusItemBasquet' type='button' class='btn btn-primary btn-xs'>--</button>" +
        "<input id ='quantity' class='roundedcorner' style='width:55px;text-align:center; background-color :#FCFCFC' type='number' min='1' value='1' step='0.01' pattern='^\d + (?: \.\d{ 1, 2 })?$'>" +
        "<button id='btnPlusItemBasquet' type='button' class='btn btn-primary btn-xs'>+</button>" + "</td>";
    //   columnPlus = "<td>" + "<button id='btnPlusItemBasquet' type='button' class='btn btn-danger btn-xs'>+</button>" + "</td>";
    ColumnProducto = "<td class='mailbox-subject'>" + json[0].descripcionItem + "<br />" + htmlextraUnidadComercial + htmlextraCatalogos +
        "<span id='puItem' class='label label-warning pull-right'>" + price +
        "</span>" +"</td>";
    ColumnTotal = "<td><input id='totalItemSale' class='roundedcorner' style='width:62px;' type='number' min='1' value=" + price + "></td>";
    //ColumnInfoExtra = "<td><input class='roundedcorner' type='text' id='Colinfo' value='' style='width:83px;' placeholder='Info extra'></td>";
    //ColumnInfoExtra = "<td>Llevar</td>";
    ColumnLlevar = "<td><input name='CheckRow' id='myCheckRow' type='checkbox'></td>";
    columnBtn = "<td><button id='btnDeleteItemBasquet' type='button' class='btn btn-danger btn-xs'><span class='glyphicon glyphicon-trash'></span></button ></td>";

    //Maping tabla Produts
    tr.append(ColumnID);
    // tr.append(columnMinus);
    tr.append(ColumnCantidad);
    // tr.append(columnPlus);
    tr.append(ColumnProducto);
    tr.append(ColumnTotal);
    //tr.append(ColumnInfoExtra);
    tr.append(ColumnLlevar);
    tr.append(columnBtn);
    //<span class='label label-warning'>Pending</span>
    $('#dtBasquetSale').append(tr);
    SumBasquetSale();
    MappingPagosVentaDirecta();
    //  }
}

function SumBasquetSale() {
    var ImporteAbonado = 0;
    $('#dtBasquetSale tbody tr').each(function () {
        var $row = $(this).closest('tr');
        //var ID = $row.find('td:eq(0)').text();        
        ImporteAbonado += parseFloat($row.find('#totalItemSale').val());
        //var ID_Forma = $row.find('#formapg_id').val();
        //var Forma = $row.find('#formapago').val();
        //var idEntidad = $row.find('#idcaja').val();
        //var Entidad = $row.find('#caja').val();

        //if (ID_Forma == '109') {
        //    $row.find('#totalItemSale').val(PedidoSeleccionado.ImporteNacional);
        //}

   });
    document.getElementById('spanTotalventa').innerHTML = "S/ " + parseFloat(ImporteAbonado).toFixed(2);
}


function GetCombos(result) {
    var options = [];
    for (var i = 0; i < result.length; i++) {
        options.push('<option value="',
            result[i].equivalencia_id, '">',
            result[i].unidadComercial, '</option>');
    }
    $("#comboCatalogo").html(options.join(''));
}



function CalculoPrecioVenta(cantidadVenta, Catalogo) {
    var ListaPrecios = Catalogo.detalleitemequivalencia_precios;
    var listaDeRangos = ConvertirPreciosArangos(ListaPrecios);
    if (listaDeRangos.length == 0) {
        alert("El producto no tiene precios de venta asignados");
        return 0;
    }

    for (var i = 0; i < listaDeRangos.length; i++)
    {
        var rango_inicio = listaDeRangos[i].rango_inicio;
        var rango_fin = listaDeRangos[i].rango_final;

        if (cantidadVenta >= rango_inicio && rango_fin == 0) {
            return listaDeRangos[i].precio;
        }

        if (cantidadVenta >= rango_inicio && cantidadVenta <= rango_fin) {
            return listaDeRangos[i].precio;
        }
    }           
}

function ConvertirPreciosArangos(ListaPrecios) {
    var ListaNueva = [];
    //var maxValor = ListaPrecios.max(precio => precio.rango_inicio);

    var maxValor = Math.max.apply(Math, ListaPrecios.map(function (o) {
        return o.rango_inicio;
    })); 

    //let maxValor = Math.max.apply(null, ListaPrecios.rango_inicio); // 4
    let max = 0;
    for (var cat = 0; cat < ListaPrecios.length; cat++) {

        let rangoMinimo = ListaPrecios[cat].rango_inicio;
        if (rangoMinimo == maxValor) {
            max = 0;
        }
        else
        {           
            var max1 = ListaPrecios[cat + 1].rango_inicio;
            if (max1 <= 1) {
                max = ListaPrecios[cat + 1].rango_inicio - 0.01
            } else {
                max = ListaPrecios[cat + 1].rango_inicio - 1;
            }                      
        }
        var item = {
            precio: ListaPrecios[cat].precio,
            rango_inicio: rangoMinimo,
            rango_final: max          
        }        
        ListaNueva.push(item);                
    }
    return ListaNueva;
}





//Grabar Pedido de venta 
$('#btSaveOrderSale').click(function (e) {

    //  e.preventDefault();

    if ($(this).attr('disabled') == 'disabled') {
        e.preventDefault();

        return;
    }

    if ($('#TextComprador').val().trim() == '') {

        //alert('Ingrese un comprador');
        sweetAlert("Ingrese un comprador!!");
        return;
    }

    //if ($("#idMesa").val().trim() == '' || $("#idMesa").val() == '0') {
    //    // alert('Identificar la mesa');
    //    sweetAlert("Identificar la mesa!!");
    //    return;
    //}

    //var mesaName = $('#CountryList').find("option:selected").text();
    //var prop_mesa;
    var vendedor;

    var Valid = ValidarDetalle();

    if (Valid) {

        var prop_Comprador = $('#TextComprador').val();
        $("#btSaveOrderSale").attr('disabled', 'disabled');

        //  document.getElementById("btSaveOrderSale").disabled = true;

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
                            vendedor = data.Full_Name;
                            //validate order items
                            //$('#orderItemError').text('');
                            var listDetailOrder = [];

                            var date = Date(Date.now());

                            var dt = new Date(date);
                            var mes = dt.getMonth() + 1;
                            var day = dt.getDay() + 1;
                            mes = String.format("{0:00}", mes);
                            var anio = dt.getFullYear();
                            var regPeriodo = mes + "/" + anio



                            var today = new Date();
                            var dd = today.getDate();
                            var mm = today.getMonth() + 1; //January is 0!

                            var yyyy = today.getFullYear();
                            if (dd < 10) {
                                dd = '0' + dd;
                            }
                            if (mm < 10) {
                                mm = '0' + mm;
                            }
                            var today = dd + '/' + mm + '/' + yyyy + " " + today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();

                            var fechaDocValue = today;

                            let total_BI1 = 0;
                            let total_BI2 = 0;
                            let total_IVA = 0;
                            let total_PEDIDO = 0;

                            $('#dtBasquetSale tbody tr').each(function () {
                                var $row = $(this).closest('tr');
                                var ID = $row.find('td:eq(0)').text();

                                var Item = list.filter(p => p.codigodetalle == ID);

                                var o = Object(Item);
                                var content = JSON.stringify(o);
                                var obj = JSON.parse(content);
                                //var nombre = obj[0].descripcionItem;

                                let colTotal = parseFloat($row.find('#totalItemSale').val());
                                let colCantidad = parseFloat($row.find('#quantity').val());

                                let colBI = 0;
                                let colIGV = 0;

                                switch (obj[0].origenProducto) {

                                    case '1':
                                        colBI = redondearExp(colTotal / 1.18, 2, true);
                                        colIGV = Number(parseFloat(colTotal - colBI).toFixed(2));
                                        break;
                                    case '2':
                                        colBI = colTotal;
                                        colIGV = 0;
                                        break;
                                    default:
                                        break;
                                }                                                            

                                var colInfoExtra = "";// $row.find('#Colinfo').val();
                               
                                var colDeliverStatus = 'DR';
                                var checke = $row.find('input[name=CheckRow]:checked').val();
                                if (checke == "on") {
                                    colDeliverStatus = 'PL';
                                } else {
                                    colDeliverStatus = 'DR';
                                }

                                switch (obj[0].origenProducto) {

                                    case '1':
                                        total_BI1 += colBI;
                                        total_IVA += colIGV;
                                      
                                        break;
                                    case '2':
                                        total_BI2 += colBI;
                                        total_IVA += 0;
                                        break;
                                    default:
                                        break;
                                }                                
                                total_PEDIDO += colTotal;

                                var ListaEquivalencias = obj[0].detalleitem_equivalencias;
                                var IDunidadComercial = $row.find('#comboUnidadComercial').val()
                           

                                var objUnidadComercial = ListaEquivalencias.filter(q => q.equivalencia_id == IDunidadComercial);

                                var oUC = Object(objUnidadComercial);
                                var contentUC = JSON.stringify(oUC);
                                var objUC = JSON.parse(contentUC);

                                //--------------------------------------------------------------------------------------------------

                                var ListaCatalogos = objUC[0].detalleitemequivalencia_catalogos;
                                var IDunidadCatalogo = $row.find('#comboCatalogo').val()
                                var objCatalogo = ListaCatalogos.filter(c => c.idCatalogo == IDunidadCatalogo);

                                var oCAT = Object(objCatalogo);
                                var contentCAT = JSON.stringify(oCAT);
                                var objCAT = JSON.parse(contentCAT);

                                
                                let precioUnitarioVenta = $row.find('#puItem').text();                             

                                var dataitem = {
                                    idDocumento: 0,
                                    secuencia: 0,
                                    CustomProducto: obj[0],
                                    CustomEquivalencia: objUC[0],
                                    CustomCatalogo: objCAT[0],
                                    equivalencia_id: objUC[0].equivalencia_id,
                                    catalogo_id: objCAT[0].idCatalogo,
                                    idAlmacenOrigen: 0,
                                    establecimientoOrigen: 0,
                                    idItem: obj[0].codigodetalle,
                                    nombreItem: obj[0].descripcionItem,
                                    tipoExistencia: obj[0].tipoExistencia,
                                    destino: obj[0].origenProducto,
                                    unidad2: obj[0].unidad1,
                                    unidad1: obj[0].unidad1,
                                    monto1: parseFloat(colCantidad),
                                    monto2: 0,
                                    PrecioUnitarioVentaMN: precioUnitarioVenta,
                                    precioUnitario: parseFloat(colTotal / colCantidad).toFixed(2),
                                    precioUnitarioUS: 0,
                                    importeMN: colTotal,
                                    importeME: 0,
                                    importeMNK: 0,
                                    importeMEK: 0,
                                    descuentoMN: 0,
                                    descuentoME: 0,
                                    montokardex: colBI,
                                    montoIsc: 0,
                                    montoIgv: colIGV,
                                    otrosTributos: 0,
                                    montokardexUS: 0,
                                    montoIscUS: 0,
                                    montoIgvUS: 0,
                                    otrosTributosUS: 0,
                                    salidaCostoMN: 0,
                                    salidaCostoME: 0,
                                    preEvento: 0,
                                    estadoMovimiento: "False",
                                    entregado: 1,
                                    estadoPago: "PN",
                                    estadoEntrega: "PN",
                                    bonificacion: 'False',
                                    montoIcbper: 0,
                                    montoIcbperUS: 0,
                                    tasaIcbper: 0,
                                    tipoVenta: colDeliverStatus,
                                    detalleAdicional: '',                                                                        
                                    usuarioModificacion: data.IDUsuario,
                                    fechaModificacion: today
                                }
                                listDetailOrder.push(dataitem);
                            });


                            //  var now = new Date();
                            $("#loaderDiv").show();

                            var dataVenta = {                                
                                tipoOperacion: '01',
                                codigoLibro: '8',
                                idEmpresa: '20602665063',
                                idEstablecimiento: 3,
                                tipoDocumento: '1000',
                                fechaLaboral: fechaDocValue,
                                fechaDoc: fechaDocValue,
                                fechaConfirmacion: fechaDocValue,
                                fechaPeriodo: regPeriodo,
                                serie: '0',
                                numeroDoc: 0,
                                numeroDocNormal: '0',
                                serieVenta: '0',
                                numeroVenta: 1,
                                idClientePedido: 1,
                                nombrePedido: prop_Comprador,
                                idCliente: 1,
                                moneda: '1',
                                tipoCambio: 1,
                                tasaIgv: 0.18,
                                bi01: total_BI1,
                                bi02: total_BI2,
                                isc01: 0,
                                isc02: 0,
                                igv01: total_IVA,
                                igv02: 0,
                                otc01: 0,
                                otc02: 0,
                                bi01us: 0,
                                bi02us: 0,
                                isc01us: 0,
                                isc02us: 0,
                                igv01us: 0,
                                igv02us: 0,
                                otc01us: 0,
                                otc02us: 0,
                                ImporteNacional: total_PEDIDO,
                                ImporteExtranjero: 0,
                                importeCostoMN: 0,
                                importeCostoME: 0,
                                estadoCobro: 'PN',
                                glosa: 'Pedido de venta',
                                terminos: 'CREDITO',
                                tipoVenta: 'VNP',
                                estadoEntrega: '1',
                                usuarioActualizacion: data.IDUsuario,
                                fechaActualizacion: fechaDocValue,
                                icbper: 0,
                                icbperus: 0,
                                documentoventaAbarrotesDet: listDetailOrder
                            }

                            var datadoc = {
                                idDocumento: 0,
                                idEmpresa: '20602665063',
                                idCentroCosto: 3,
                                idProyecto: 0,
                                tipoDoc: '1000',
                                fechaProceso: fechaDocValue,
                                moneda: '1',
                                idEntidad: 1,
                                entidad: 'Varios',
                                tipoEntidad: 'CL',
                                nrodocEntidad: '1',
                                nroDoc: '0',
                                idOrden: 0,
                                tipoOperacion: '01',
                                CustomNumero: vendedor,
                                usuarioActualizacion: data.IDUsuario,
                                fechaActualizacion: fechaDocValue,
                                documentoventaAbarrotes: dataVenta
                            }

                            //dataType: 'multipart/form-data'
                            //contentType: 'application/json',

                            //  var urlContract = '@Url.Action("Create", "Order", null, Request.Url.Scheme, null)'

                            // dataAjaxSend = { 'order': datadoc };

                            //          var d = JSON.stringify({ paramReferenceNo: paramReferenceNo, paramLots: paramLots }),

                            //$.ajax({
                            //    contentType: 'application/json; charset=utf-8',
                            //    dataType: 'json',
                            //    url: '@Url.Action("UpdateProducts")',
                            //    type: 'post',
                            //    data: JSON.stringify({ products: products, statusId: 1 }) //stringify the whole data again
                            //})
                            //    .done(function (result) {
                            //        //result here
                            //    });

                            //'/Order/saveOrder',


                            $.ajax({
                                contentType: 'application/json; charset=utf-8',
                                dataType: 'json',
                                type: 'POST',
                                url: '/Order/saveOrder',
                                data: JSON.stringify({ order: datadoc }),
                                success: function (datadoc) {
                                    if (datadoc.status) {
                                        toastr.success('Pedido registrado!')
                                        // alert('Pedido Registrado');
                                        //here we will clear the form
                                        $("#loaderDiv").hide();
                                        $("#dtBasquetSale tbody tr").remove();
                                        list = [];
                                        listProductSales = [];
                                        SumBasquetSale();
                                        //$('#TextComprador').val('');
                                        $("#TextFilter").val('');                                                                     
                                        $('#TextComprador').val('VARIOS');
                                        //renderMesas();
                                        //$('#total', '#price').val('0.00');
                                        //$('#orderdetailsItems').empty();
                                        //    $('#btSaveOrderSale').text('Save');
                                        //$("input[id=price]").val(0)
                                        //$("input[id=total]").val(0)

                                        $("#btSaveOrderSale").removeAttr('disabled');                                     
                                        //$("#btnEditEntidad").prop("disabled", true);

                                        //var answer = window.confirm("Imprimir el pedido ahora?")
                                        //if (answer) {
                                        //    //some code
                                        //    $.ajax({
                                        //        type: "GET",
                                        //        url: '/Order/GetPrintDocumento',
                                        //        data: { 'idmesa': prop_mesa, 'fecha': fechaDocValue, 'vendedor': vendedor, 'id': ID, 'nameMesa': mesaName },
                                        //        success: function (data) {
                                        //            if (data.status == true) {
                                        //                alert('print success');
                                        //            }
                                        //            //typeof PedidoSeleccionado;
                                        //            // toastr.success('Pedido eliminado');
                                        //            //$("#datatablePedidos tbody tr").remove();

                                        //        },
                                        //        error: function (error) {
                                        //            console.log(error);
                                        //        }
                                        //    });
                                        //}
                                        //else {
                                        //    //some code
                                        //}


                                        //$("input[name='rdbcountry'][value='Varios']").prop('checked', true);                                                                              

                                    }
                                    else {
                                        $("#btSaveOrderSale").removeAttr('disabled');
                                        alert('Error');
                                        $("#loaderDiv").hide();
                                    }
                                    //   $('#btSaveOrderSale').text('Save');
                                },
                                error: function (error) {
                                    $("#btSaveOrderSale").removeAttr('disabled');
                                    // console.log(error);
                                    toastr.error('Error al grabar pedido!')
                                    $("#loaderDiv").hide();
                                    console.log(error);
                                    //    $('#btSaveOrderSale').text('Save');
                                }
                            });

                        },
                        error: function (error) {
                            $("#btSaveOrderSale").removeAttr('disabled');
                            //alert('No se encontro un vendedor con el código ingresado!');
                            toastr.error('No se encontro un vendedor con el código ingresado!')
                            console.log(error);
                            $("#loaderDiv").hide();
                        }
                    });
                },
                Cancel: function () {
                    $("#btSaveOrderSale").removeAttr('disabled');
                    Jquery102(this).dialog("close");
                }
            }
        });
    } else {
        //alert('Verificar el detalle del pedido!');
        sweetAlert('Verificar el detalle del pedido!');
        //toastr.error('ErrorVerificar el detalle del pedido!');
    }
});

//Grabar venta directa
$('#btSaveSale').click(function (e) {
    var statusPago = "";
    //  e.preventDefault();

    if ($(this).attr('disabled') == 'disabled') {
        e.preventDefault();

        return;
    }

    if ($('#TextComprador').val().trim() == '') {

        //alert('Ingrese un comprador');
        sweetAlert("Ingrese un comprador!!");
        return;
    }

    //if ($("#idMesa").val().trim() == '' || $("#idMesa").val() == '0') {
    //    // alert('Identificar la mesa');
    //    sweetAlert("Identificar la mesa!!");
    //    return;
    //}

    var listCaja = [];
    var ID_CAJA_USUARIO = $("#ComboCajasActivas").val();
    var Condicionpago = $("#cboTipoPago").val();
    var vendedor;

    var Valid = ValidarDetalle();

    if (Valid) {

        if (ClienteSelected == null) {
            sweetAlert("Ingrese un comprador!!");
            return;
        }

        var prop_Comprador = ClienteSelected.nombreCompleto;
        $("#btSaveSale").attr('disabled', 'disabled');

        //  document.getElementById("btSaveOrderSale").disabled = true;

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
                            vendedor = data.Full_Name;
                            //validate order items
                            //$('#orderItemError').text('');
                            var listDetailOrder = [];

                            var date = Date(Date.now());

                            var dt = new Date(date);
                            var mes = dt.getMonth() + 1;
                            var day = dt.getDay() + 1;
                            mes = String.format("{0:00}", mes);
                            var anio = dt.getFullYear();
                            var regPeriodo = mes + "/" + anio



                            var today = new Date();
                            var dd = today.getDate();
                            var mm = today.getMonth() + 1; //January is 0!

                            var yyyy = today.getFullYear();
                            if (dd < 10) {
                                dd = '0' + dd;
                            }
                            if (mm < 10) {
                                mm = '0' + mm;
                            }
                            var today = dd + '/' + mm + '/' + yyyy + " " + today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();

                            var fechaDocValue = today;

                            let total_BI1 = 0;
                            let total_BI2 = 0;
                            let total_IVA = 0;
                            let total_PEDIDO = 0;

                            $('#dtBasquetSale tbody tr').each(function () {
                                var $row = $(this).closest('tr');
                                var ID = $row.find('td:eq(0)').text();

                                var Item = list.filter(p => p.codigodetalle == ID);

                                var o = Object(Item);
                                var content = JSON.stringify(o);
                                var obj = JSON.parse(content);
                                //var nombre = obj[0].descripcionItem;

                                let colTotal = parseFloat($row.find('#totalItemSale').val());
                                let colCantidad = parseFloat($row.find('#quantity').val());

                                let colBI = 0;
                                let colIGV = 0;

                                switch (obj[0].origenProducto) {

                                    case '1':
                                        colBI = redondearExp(colTotal / 1.18, 2, true);
                                        colIGV = Number(parseFloat(colTotal - colBI).toFixed(2));
                                        break;
                                    case '2':
                                        colBI = colTotal;
                                        colIGV = 0;
                                        break;
                                    default:
                                        break;
                                }

                                var colInfoExtra = "";// $row.find('#Colinfo').val();

                                var colDeliverStatus = 'DR';
                                var checke = $row.find('input[name=CheckRow]:checked').val();
                                if (checke == "on") {
                                    colDeliverStatus = 'PL';
                                } else {
                                    colDeliverStatus = 'DR';
                                }

                                switch (obj[0].origenProducto) {

                                    case '1':
                                        total_BI1 += colBI;
                                        total_IVA += colIGV;

                                        break;
                                    case '2':
                                        total_BI2 += colBI;
                                        total_IVA += 0;
                                        break;
                                    default:
                                        break;
                                }
                                total_PEDIDO += colTotal;

                                var ListaEquivalencias = obj[0].detalleitem_equivalencias;
                                var IDunidadComercial = $row.find('#comboUnidadComercial').val()


                                var objUnidadComercial = ListaEquivalencias.filter(q => q.equivalencia_id == IDunidadComercial);

                                var oUC = Object(objUnidadComercial);
                                var contentUC = JSON.stringify(oUC);
                                var objUC = JSON.parse(contentUC);

                                //--------------------------------------------------------------------------------------------------

                                var ListaCatalogos = objUC[0].detalleitemequivalencia_catalogos;
                                var IDunidadCatalogo = $row.find('#comboCatalogo').val()
                                var objCatalogo = ListaCatalogos.filter(c => c.idCatalogo == IDunidadCatalogo);

                                var oCAT = Object(objCatalogo);
                                var contentCAT = JSON.stringify(oCAT);
                                var objCAT = JSON.parse(contentCAT);


                                let precioUnitarioVenta = $row.find('#puItem').text();


                              
                            
                                if (Condicionpago == "CONTADO")
                                    statusPago = "DC";
                                else
                                    statusPago = "PN";

                                var dataitem = {
                                    idDocumento: 0,
                                    secuencia: 0,
                                    CustomProducto: obj[0],
                                    CustomEquivalencia: objUC[0],
                                    CustomCatalogo: objCAT[0],
                                    equivalencia_id: objUC[0].equivalencia_id,
                                    catalogo_id: objCAT[0].idCatalogo,
                                    idAlmacenOrigen: 0,
                                    establecimientoOrigen: 0,
                                    idItem: obj[0].codigodetalle,
                                    nombreItem: obj[0].descripcionItem,
                                    tipoExistencia: obj[0].tipoExistencia,
                                    destino: obj[0].origenProducto,
                                    unidad2: obj[0].unidad1,
                                    unidad1: obj[0].unidad1,
                                    monto1: parseFloat(colCantidad),
                                    monto2: 0,
                                    PrecioUnitarioVentaMN: precioUnitarioVenta,
                                    precioUnitario: parseFloat(colTotal / colCantidad).toFixed(2),
                                    precioUnitarioUS: 0,
                                    importeMN: colTotal,
                                    importeME: 0,
                                    importeMNK: 0,
                                    importeMEK: 0,
                                    descuentoMN: 0,
                                    descuentoME: 0,
                                    montokardex: colBI,
                                    montoIsc: 0,
                                    montoIgv: colIGV,
                                    otrosTributos: 0,
                                    montokardexUS: 0,
                                    montoIscUS: 0,
                                    montoIgvUS: 0,
                                    otrosTributosUS: 0,
                                    salidaCostoMN: 0,
                                    salidaCostoME: 0,
                                    preEvento: 0,
                                    estadoMovimiento: "False",
                                    entregado: 1,
                                    estadoPago: statusPago,
                                    estadoEntrega: "PN",
                                    bonificacion: 'False',
                                    montoIcbper: 0,
                                    montoIcbperUS: 0,
                                    tasaIcbper: 0,
                                    tipoVenta: colDeliverStatus,
                                    detalleAdicional: '',
                                    usuarioModificacion: data.IDUsuario,
                                    fechaModificacion: today
                                }
                                listDetailOrder.push(dataitem);
                            });


                            //  var now = new Date();
                            $("#loaderDiv").show();

                            var Tipocomprobante = $("#ComboComprobante").val();                            

                            var dataVenta = {
                                tipoOperacion: '01',
                                codigoLibro: '8',
                                idEmpresa: '20602665063',
                                idEstablecimiento: 3,
                                tipoDocumento: Tipocomprobante,
                                fechaLaboral: fechaDocValue,
                                fechaDoc: fechaDocValue,
                                fechaConfirmacion: fechaDocValue,
                                fechaPeriodo: regPeriodo,
                                serie: '0',
                                numeroDoc: 0,
                                numeroDocNormal: '0',
                                serieVenta: '0',
                                numeroVenta: 1,
                                idClientePedido: ClienteSelected.idEntidad,
                                nombrePedido: prop_Comprador,
                                idCliente: ClienteSelected.idEntidad,
                                moneda: '1',
                                tipoCambio: 1,
                                tasaIgv: 0.18,
                                bi01: total_BI1,
                                bi02: total_BI2,
                                isc01: 0,
                                isc02: 0,
                                igv01: total_IVA,
                                igv02: 0,
                                otc01: 0,
                                otc02: 0,
                                bi01us: 0,
                                bi02us: 0,
                                isc01us: 0,
                                isc02us: 0,
                                igv01us: 0,
                                igv02us: 0,
                                otc01us: 0,
                                otc02us: 0,
                                ImporteNacional: total_PEDIDO,
                                ImporteExtranjero: 0,
                                importeCostoMN: 0,
                                importeCostoME: 0,
                                estadoCobro: statusPago,
                                glosa: 'VENTA DIRECTA',
                                terminos: Condicionpago,
                                tipoVenta: 'VELC',
                                estadoEntrega: '1',
                                usuarioActualizacion: data.IDUsuario,
                                fechaActualizacion: fechaDocValue,
                                icbper: 0,
                                icbperus: 0,
                                documentoventaAbarrotesDet: listDetailOrder
                            }


                            // Registrar Documentos de pago **************************************************************************

                         

                            if (Condicionpago == "CONTADO") {
                                let SumaPagos = 0;

                                $('#dtPagos tbody tr').each(function () {
                                    var $row = $(this).closest('tr');
                                    //var ID = $row.find('td:eq(0)').text();        
                                    var ImporteAbonado = $row.find('#montoAbonado').val();
                                    SumaPagos += ImporteAbonado;
                                    var ID_Forma = $row.find('#formapg_id').val();
                                    var Forma = $row.find('#formapago').val();
                                    var idEntidad = $row.find('#idcaja').val();
                                    var Entidad = $row.find('#caja').val();

                                    var dataCaja = {
                                        tipoOperacion: '9908',
                                        periodo: dataVenta.fechaPeriodo,
                                        idEmpresa: dataVenta.idEmpresa,
                                        idEstablecimiento: dataVenta.idEstablecimiento,
                                        fechaProceso: dataVenta.fechaDoc,
                                        fechaCobro: dataVenta.fechaDoc,
                                        tipoMovimiento: 'DC',
                                        codigoProveedor: dataVenta.idCliente,
                                        IdProveedor: dataVenta.idCliente,
                                        idPersonal: dataVenta.idCliente,
                                        TipoDocumentoPago: '9903',
                                        codigoLibro: '1',
                                        tipoDocPago: dataVenta.tipoDocumento,
                                        formapago: ID_Forma,
                                        formaPagoName: Forma,
                                        NumeroDocumento: '-',
                                        numeroOperacion: '',
                                        movimientoCaja: 'VELC',
                                        montoSoles: ImporteAbonado,
                                        moneda: dataVenta.moneda,
                                        tipoCambio: dataVenta.tipoCambio,
                                        montoUsd: 0,
                                        estado: '1',
                                        glosa: 'Venta cobrada!',
                                        entregado: 'SI',
                                        idCajaUsuario: ID_CAJA_USUARIO,
                                        entidadFinanciera: idEntidad,
                                        NombreEntidad: Entidad,
                                        usuarioModificacion: dataVenta.usuarioActualizacion
                                    }
                                    listCaja.push(dataCaja);
                                });

                                if (SumaPagos == 0) {
                                    sweetAlert("Ingrese un pago mayor a cero!!");
                                    $("#loaderDiv").hide();
                                    $("#btSaveSale").removeAttr('disabled');
                                    return;
                                }
                            }                            
                            
                            var datadoc = {
                                idDocumento: 0,
                                idEmpresa: '20602665063',
                                idCentroCosto: 3,
                                idProyecto: 0,
                                tipoDoc: Tipocomprobante,
                                fechaProceso: fechaDocValue,
                                moneda: '1',
                                idEntidad: ClienteSelected.idEntidad,
                                entidad: ClienteSelected.nombreCompleto,
                                tipoEntidad: 'CL',
                                nrodocEntidad: ClienteSelected.nrodoc,
                                nroDoc: '0',
                                idOrden: 0,
                                tipoOperacion: '01',
                                CustomNumero: vendedor,
                                usuarioActualizacion: data.IDUsuario,
                                fechaActualizacion: fechaDocValue,
                                documentoventaAbarrotes: dataVenta,
                                ListaCustomDocumentoCaja: listCaja
                            }                          

                            $.ajax({
                                contentType: 'application/json; charset=utf-8',
                                dataType: 'json',
                                type: 'POST',
                                url: '/Order/SaveSale',
                                data: JSON.stringify({ order: datadoc }),
                                success: function (datadoc) {
                                    if (datadoc.status) {
                                        toastr.success('Venta registrada!')
                                        // alert('Pedido Registrado');
                                        //here we will clear the form
                                        $("#loaderDiv").hide();
                                        $("#dtBasquetSale tbody tr").remove();
                                        list = [];
                                        listProductSales = [];
                                        SumBasquetSale();
                                        //$('#TextComprador').val('');
                                        $("#TextFilter").val('');
                                        $('#TextComprador').val('VARIOS');
                                        ClienteSelected = ClienteVarios;
                                        //renderMesas();
                                        //$('#total', '#price').val('0.00');
                                        //$('#orderdetailsItems').empty();
                                        //    $('#btSaveOrderSale').text('Save');
                                        //$("input[id=price]").val(0)
                                        //$("input[id=total]").val(0)

                                        $("#btSaveSale").removeAttr('disabled');
                                        //$("#btnEditEntidad").prop("disabled", true);

                                        //var answer = window.confirm("Imprimir el pedido ahora?")
                                        //if (answer) {
                                        //    //some code
                                        //    $.ajax({
                                        //        type: "GET",
                                        //        url: '/Order/GetPrintDocumento',
                                        //        data: { 'idmesa': prop_mesa, 'fecha': fechaDocValue, 'vendedor': vendedor, 'id': ID, 'nameMesa': mesaName },
                                        //        success: function (data) {
                                        //            if (data.status == true) {
                                        //                alert('print success');
                                        //            }
                                        //            //typeof PedidoSeleccionado;
                                        //            // toastr.success('Pedido eliminado');
                                        //            //$("#datatablePedidos tbody tr").remove();

                                        //        },
                                        //        error: function (error) {
                                        //            console.log(error);
                                        //        }
                                        //    });
                                        //}
                                        //else {
                                        //    //some code
                                        //}


                                        //$("input[name='rdbcountry'][value='Varios']").prop('checked', true);                                                                              

                                    }
                                    else {
                                        $("#btSaveSale").removeAttr('disabled');
                                        alert('Error');
                                        $("#loaderDiv").hide();
                                    }
                                    //   $('#btSaveOrderSale').text('Save');
                                },
                                error: function (error) {
                                    $("#btSaveSale").removeAttr('disabled');
                                    // console.log(error);
                                    toastr.error('Error al grabar pedido!')
                                    $("#loaderDiv").hide();
                                    console.log(error);
                                    //    $('#btSaveOrderSale').text('Save');
                                }
                            });

                        },
                        error: function (error) {
                            $("#btSaveSale").removeAttr('disabled');
                            //alert('No se encontro un vendedor con el código ingresado!');
                            toastr.error('No se encontro un vendedor con el código ingresado!')
                            console.log(error);
                            $("#loaderDiv").hide();
                        }
                    });
                },
                Cancel: function () {
                    $("#btSaveSale").removeAttr('disabled');
                    Jquery102(this).dialog("close");
                }
            }
        });
    } else {
        //alert('Verificar el detalle del pedido!');
        sweetAlert('Verificar el detalle del pedido!');
        //toastr.error('ErrorVerificar el detalle del pedido!');
    }
});


function ValidarDetalle() {
    var Valid = true;
    var errorItemCount = 0;
    var numFilas = document.getElementById("dtBasquetSale").rows.length;

    if (numFilas > 0) {
        $('#dtBasquetSale tbody tr').each(function () {
            var $row = $(this).closest('tr');
            var ID = $row.find('td:eq(0)').text();

            let colTotal = parseFloat($row.find('#totalItemSale').val());

            if (colTotal <= 0) {
                errorItemCount = errorItemCount + 1;
            }

            let colCantidad = parseFloat($row.find('#quantity').val());
            if (colCantidad <= 0) {
                errorItemCount = errorItemCount + 1;
            }

        });
    } else {
        Valid = false;
    }

    if (errorItemCount > 0) {
        Valid = false;
    }

    return Valid;
}


function redondearExp(numero, digitos, masEspaciado = false) {
    function toExp(numero, digitos) {
        let arr = numero.toString().split("e");
        let mantisa = arr[0], exponente = digitos;
        if (arr[1]) exponente = Number(arr[1]) + digitos;
        return Number(mantisa + "e" + exponente.toString());
    }
    let absNumero = Math.abs(numero);
    let signo = Math.sign(numero);
    if (masEspaciado) {
        let n = Math.floor(Math.log2(absNumero));
        let spacing = Math.pow(2, n) * Number.EPSILON;
        if (spacing < Math.pow(10, -digitos - 1)) {
            absNumero += spacing;
        }
    }
    let entero = Math.round(toExp(absNumero, digitos));
    return signo * toExp(entero, -digitos);
}

//LoadCategory($('#productCategory'));

function renderCatalogosTable(element, data, row) {
    //render Catalogos
    var $ele = $(element);
    var precio = 0;
    $ele.empty();
    //  $ele.append($('<option/>').val('0').text('-Catalogo-'));

    if (data.length == 0) {
        row.find('#comboCatalogo').prop("disabled", true);

    } else {
        precio = parseFloat(data[0].detalleitemequivalencia_precios[0].precio).toFixed(2);     
        var precioVenta = CalculoPrecioVenta(parseFloat(row.find('#quantity').val()), data[0]);
        row.find('#puItem').text(precioVenta);

        //Calculo        
        var precioUnitario = parseFloat(row.find('#puItem').text());       
        var total = parseFloat(parseFloat(row.find('#quantity').val()) * precioUnitario).toFixed(2);

        row.find('#totalItemSale').val(total);
        SumBasquetSale();          
        
        $.each(data, function (i, val) {
            $ele.append($('<option/>').val(val.idCatalogo).text(val.nombre_corto));
        })
        row.find('#comboCatalogo').prop("disabled", false);
    }
}