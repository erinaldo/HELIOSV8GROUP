var list = [];

function renderMesas() {
   
    var s;// = '<option value="-1">Please Select a Department</option>';  
    var $ele = $("#CountryList");
    $ele.empty();

    $.getJSON("GetMesas",
        function (json) {
          
            for (var i = 0; i < json.length; i++) {

                s += '<option value="' + json[i].idDistribucion + '">' + json[i].descripcionDistribucion + '-' + json[i].numeracion + '</option>';
            }
            $("#CountryList").html(s); 
        });
    
}

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

function SelectedValue(ddlObject) {
    //Selected value of dropdownlist  
    var selectedValue = ddlObject.value;
    //Selected text of dropdownlist  
    var selectedText = ddlObject.options[ddlObject.selectedIndex].innerHTML;
        
    $("#idMesa").val(selectedValue);
    document.getElementById('MesaName').innerHTML = selectedText;
  
    //alert($("#idMesa").val());
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

function addItemToBasket(json) {
    var tr; 
    var ColumnID;
   // var columnMinus;
    var ColumnCantidad;
    //var columnPlus;
    var ColumnProducto;
    var ColumnTotal;
    var ColumnInfoExtra;
    var ColumnLlevar;
    var columnBtn;
   // for (var i = 0; i < json.length; i++) {
    var obj = json[0];
    list.push(obj);

    tr = $('<tr/>');
    var precio = parseFloat(json[0].detalleitem_equivalencias[0].detalleitemequivalencia_catalogos[0].detalleitemequivalencia_precios[0].precio).toFixed(2);
    ColumnID = "<td style='display: none;' class='mailbox-subject' style='font-size: smaller'>" + json[0].codigodetalle + "</td>";
   // columnMinus = "<td width:20%>" + "<button id='btnMinusItemBasquet' type='button' class='btn btn-danger btn-xs'>-</button>" + "</td>";
    ColumnCantidad = "<td>" + "<button id='btnMinusItemBasquet' type='button' class='btn btn-primary btn-xs'>--</button>" +
                     "<input id ='quantity' class='roundedcorner' style='width:40px;text-align:center; background-color :#FCFCFC' type='number' min='1' value='1'>" +                    
                    "<button id='btnPlusItemBasquet' type='button' class='btn btn-primary btn-xs'>+</button>" + "</td>";
 //   columnPlus = "<td>" + "<button id='btnPlusItemBasquet' type='button' class='btn btn-danger btn-xs'>+</button>" + "</td>";
    ColumnProducto = "<td class='mailbox-subject'>" + json[0].descripcionItem + "<span id='puItem' class='label label-warning pull-right'>" + precio +
        "</span>" + "<br />" + "<input class='roundedcorner' type='text' id='Colinfo' value='' style='width:170px; font-size:10px;' placeholder='Info extra'>" + "</td>";
    ColumnTotal = "<td><input id='totalItemSale' class='roundedcorner' style='width:62px;' type='number' min='1' value=" + precio + "></td>";
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
  //  }
}


function GetProducts(id) {
    try {
        
    //Call EmpDetails jsonResult Method  
    listProductSelCategory = [];

    $.getJSON("/Order/GetProductsSelCategory?id=" + id,
        function (json) {
            var tr;
            //Append each row to html table                  
            var ColumnID;
            var columnName;
            var columnPrice;
            var columnBtn;
            var labelHistory = '';
            var labelRender = '';
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

                columnPrice = "<td>" + labelRender + "S/ " + parseFloat(json[i].detalleitem_equivalencias[0].detalleitemequivalencia_catalogos[0].detalleitemequivalencia_precios[0].precio).toFixed(2) + "</span>" + "</td>";

                var obj = json[i];
                listProductSelCategory.push(obj);

                tr = $('<tr/>');
                
                ColumnID = "<td style='display: none;'>" + "<input type='checkbox' style='display: none'>" + json[i].codigodetalle + "</td>";
                //columnName = "<td class='mailbox-name'><a href='#'>" + json[i].descripcionItem + "</a></td>";
                columnName = "<td class='mailbox-name'>" + json[i].descripcionItem + "</td>";
                //columnName = "<td>" + "class='mailbox-name'><a href='#'>" + json[i].detalleitem_equivalencias[0].detalleitemequivalencia_catalogos[0].detalleitemequivalencia_precios[0].precio + "</a></td>";
                // columnPrice = "<td class='mailbox-subject'><b>" + json[i].detalleitem_equivalencias[0].detalleitemequivalencia_catalogos[0].detalleitemequivalencia_precios[0].precio + "</b></td>";                                    
             
                
                //columnPrice = "<td>" + "<span class='badge'>" + parseFloat(json[i].detalleitem_equivalencias[0].detalleitemequivalencia_catalogos[0].detalleitemequivalencia_precios[0].precio).toFixed(2) + "</span>" + "</td>";
                //columnBtn = "<td><input id='btnAdditem' type='button' value='+' class='btn btn-warning btn-xs'> <span class='glyphicon glyphicon-trash'></span></td>";
                columnBtn = "<td><button id='btnAdditem' type='button' class='btn bg-light-blue btn-xs'><span class='fa fa-fw fa-plus-circle'></span></button ></td>";

                //Maping tabla Produts
                tr.append(ColumnID);
                tr.append(columnName);
                tr.append(columnPrice);
                tr.append(columnBtn);
                //<span class='label label-warning'>Pending</span>
                $('#dtProducts').append(tr);
                //$(el).closest('li').css('background', 'white');
            }
        });
    }
    catch (err) {
    err.message;
    }
}

function GetProductSelText(Text) {
    //Call EmpDetails jsonResult Method  
    listProductSelCategory = [];
    //$.getJSON("/Order/GetProductsSelCategory?id=" + Text,
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

                columnPrice = "<td>" + labelRender + "S/ " + parseFloat(json[i].detalleitem_equivalencias[0].detalleitemequivalencia_catalogos[0].detalleitemequivalencia_precios[0].precio).toFixed(2) + "</span>" + "</td>";

                var obj = json[i];
                listProductSelCategory.push(obj);

                tr = $('<tr/>');

                ColumnID = "<td style='display: none;'>" + "<input type='checkbox' style='display: none'>" + json[i].codigodetalle + "</td>";
                //columnName = "<td class='mailbox-name'><a href='#'>" + json[i].descripcionItem + "</a></td>";
                columnName = "<td class='mailbox-name'>" + json[i].presentacion + "</td>";
                //columnName = "<td>" + "class='mailbox-name'><a href='#'>" + json[i].detalleitem_equivalencias[0].detalleitemequivalencia_catalogos[0].detalleitemequivalencia_precios[0].precio + "</a></td>";
                // columnPrice = "<td class='mailbox-subject'><b>" + json[i].detalleitem_equivalencias[0].detalleitemequivalencia_catalogos[0].detalleitemequivalencia_precios[0].precio + "</b></td>";                                    


                //columnPrice = "<td>" + "<span class='badge'>" + parseFloat(json[i].detalleitem_equivalencias[0].detalleitemequivalencia_catalogos[0].detalleitemequivalencia_precios[0].precio).toFixed(2) + "</span>" + "</td>";
                //columnBtn = "<td><input id='btnAdditem' type='button' value='+' class='btn btn-warning btn-xs'> <span class='glyphicon glyphicon-trash'></span></td>";
                columnBtn = "<td><button id='btnAdditem' type='button' class='btn bg-light-blue btn-xs'><span class='fa fa-fw fa-plus-circle'></span></button ></td>";

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

var pes = jQuery.noConflict();
var Jquery102 = pes;//$.fn.jquery;
$(document).ready(function () {

    //alert($.fn.jquery);
    //alert(pes.fn.jquery);

   // sweetAlert("Congratulations!!");  

    //$("#1029 [data-widget='collapse']").click(function () {
    //    var box = $(this).parents(".box").first();

    //    var boxComplementos = $("#1033 [data-widget='collapse']").parents(".box").first();

    //    var bf = boxComplementos.find(".box-body, .box-footer");

    //    if (!box.hasClass("collapsed-box")) {
    //        console.log("collapsing #my-box-id ...");
    //        //bf.slideUp();
    //        bf.slideDown();
    //    } else {
    //        console.log("expanding #my-box-id ...");
    //        //bf.slideDown();
    //        bf.slideUp();
    //    }
    //});


     $("[data-widget='collapse']").click(function () {
             
        //Find the box parent........
         var control = $(this);
         var box = $(this).parents(".box").first();
         var id = box[0].id;
         var c = box.html();

         var bfPrincipal = box.find(".box-body, .box-footer");

         

         if (!control.children().hasClass("fa-plus")) {
             control.children(".fa-minus").removeClass("fa-minus").addClass("fa-plus");
           //  bfPrincipal.slideDown();
         } else {
             //Convert plus into minus
             //control.children(".fa-plus").removeClass("fa-plus").addClass("fa-minus");
             if (!control.children().hasClass("fa-plus")) {
                 control.children(".fa-minus").removeClass("fa-minus").addClass("fa-plus");
             } else {
                 control.children(".fa-plus").addClass("fa-plus").addClass("fa-plus");
             }

            // bfPrincipal.slideDown();

         }
         //bfPrincipal.slideDown();

        // var result1 = listCategorias.where({ idItem: 1, name: 'foo' });
         var result1 = $.grep(listCategorias, function (p) { return p.idItem != id; })
             .map(function (p) { return p.idItem; });
      //   $("#1033 [data-widget='collapse']").parents(".box").first();

         for (var i = 0; i < result1.length; i++) {
            // alert(result1[i]);

             var code = '#' + result1[i] + " [data-widget='collapse']";
             var boxComplementos = $(code).parents(".box").first();
             var boxComplementosV2 = $(code);
             var bf = boxComplementos.find(".box-body, .box-footer");
           //  bf.slideDown();
             //if (!box.hasClass("collapsed-box")) {
             //    console.log("collapsing #my-box-id ...");
             //    //bf.slideUp();
             //    //boxComplementos.children(".fa-plus").removeClass("fa-plus").addClass("fa-minus");
             //    bf.slideDown();
             //} else {
             //    console.log("expanding #my-box-id ...");
                 //bf.slideDown();
                 //boxComplementos.children(".fa-minus").removeClass("fa-minus").addClass("fa-plus");

             bf.slideUp();
             if (!boxComplementosV2.children().hasClass("fa-plus")) {
                 boxComplementosV2.children(".fa-minus").removeClass("fa-minus").addClass("fa-plus");

             } else {
                 //Convert plus into minus
                 boxComplementosV2.children(".fa-plus").removeClass("fa-plus").addClass("fa-plus");
                 //bfPrincipal.slideDown();
             }
             //boxComplementosV2.children(".fa-minus").removeClass("fa-minus").addClass("fa-plus");



            // alert( boxComplementosV2.html());
          //   }

             /*if (!boxComplementos.children().hasClass("fa-plus")) {
                 boxComplementos.children(".fa-minus").removeClass("fa-minus").addClass("fa-plus");
               //  bf.slideUp();
             } else {
                 //Convert plus into minus
                 boxComplementos.children(".fa-plus").removeClass("fa-plus").addClass("fa-minus");
                // bf.slideDown();
             }*/

          //   boxComplementos.children(".fa-minus").removeClass("fa-minus").addClass("fa-plus");
         }     

        //Find the body and the footer
       // var bf = box.find(".box-body, .box-footer");

        //var theDiv = document.getElementsByClassName($(this));
        //var x = theDiv.innerHTML;

       /* if (!$(this).children().hasClass("fa-plus")) {
            $(this).children(".fa-minus").removeClass("fa-minus").addClass("fa-plus");
            bf.slideUp();
        } else {
            //Convert plus into minus
            $(this).children(".fa-plus").removeClass("fa-plus").addClass("fa-minus");
            bf.slideDown();
        }*/
    });

    $('#btCollapseAll').click(function () {
        alert('Collapsible');

        //Estado
        var theDiv = document.getElementById("divInfra 1033");
        //alert("The content is " + theDiv.innerHTML);

        //Maximizando div
        var replacestring = theDiv.innerHTML.replace('<div class="box box-default">', '<div class="box box-default collapsed-box">')
            .replace('<div id="menu" class="box-body no-padding" style="">', '<div id="menu" class="box-body no-padding" style="display: none;">')
            .replace('<i class="fa fa-plus"></i>', '<i class="fa fa-minus"></i>');

        //Minimizando div
        //var replacestring = theDiv.innerHTML.replace('<div class="box box-default">', '<div class="box box-default collapsed-box">')
        //    .replace('<div id="menu" class="box-body no-padding" style="">', '<div id="menu" class="box-body no-padding" style="display: none;">')
        //    .replace('<i class="fa fa-minus"></i>', '<i class="fa fa-plus"></i>');


        //alert(replacestring);

        document.getElementById("divInfra 1033").innerHTML = replacestring;

      //  var replaceBodyMessage = replacestring.innerHTML.replace('<div id="menu" class="box-body no-padding" style="display: none;">', '<div id="menu" class="box-body no-padding" style>');
      //  alert(replaceBodyMessage);

      //  var replaceBodyIcono = replaceBodyMessage.innerHTML.replace('<i class="fa fa-plus"></i>', '<i class="fa fa-minus"></i>');
      //  alert(replaceBodyIcono);
    });


    $('.hidenID').hide();

    $("#btnImprimirConsumo").click(function (e) {
        alert('print');

        var $row = $("#datatablePedidos").closest('tr');
        var ID = $row.find('td:eq(0)').text();
        var sec = $row.find('td:eq(1)').text();
        var vendedor = $row.find('td:eq(3)').text();
        var mesa = $('#CountryList').val();

        $.ajax({
            type: 'GET',
            dataType: 'json',
            contentType: 'application/json',
            url: '/Order/GetPrintDocumento',
            data: { 'idmesa': mesa, 'fecha': '22/10/2019', 'vendedor': vendedor },
            success: function (data) {
                //alert(data);
                if (data == true) {
                    //location.href = "/Account/Demo"
                }
                else {
                 //   location.href = "/Account/Login"
                }
            },
            error: function (xhr) {
                alert('error');
            }
        });
    });


    $("#btnFilterProduct").click(function () {
        $("#dtProducts tbody tr").remove();
        var filter = $("#TextFilter").val();    
        GetProductSelText(filter)
    });

    //$("#trash").click(function () {
    //    var id = $("#trash").val();
    //    //var t = $(this).text();
    //    alert(id);
    //});
       

    $('#menu li').on('click', function () {     
       // var el = this;
        var id = $(this).closest('li').find('.hidenID').text();        
       // $(el).closest('li').css('background', 'yellow');
     //   alert(id);
        //Eliminando todas las filas de dtProducts
        $("#dtProducts tbody tr").remove();
        GetProducts(id);
    });            
   
    $('#dtProducts tbody').on('click', 'tr td #btnAdditem', function () {
        var el = this;
        var $row = $(this).closest('tr');
        var ID = $row.find('td:eq(0)').text();
        var Item = listProductSelCategory.filter(p => p.codigodetalle == ID);

        var o = Object(Item);
        var content = JSON.stringify(o);
        var obj = JSON.parse(content);
        var nombre = obj[0].presentacion;

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

    $('#dtBasquetSale tbody').on('click', 'tr td #btnPlusItemBasquet', function () {
        var $row = $(this).closest('tr');
        var ID = $row.find('td:eq(0)').text();           
        var inforExtra = $row.find('#Colinfo').val();
        var cantidad = parseFloat($row.find('#quantity').val());
        var suma = cantidad + 1;
        $row.find('#quantity').val(suma);

        //Calculo        
        var precioUnitario = parseFloat($row.find('#puItem').text());
        // var precioUnitario2 = parseFloat($row.find('#puItem').text());

        var total = parseFloat(suma * precioUnitario).toFixed(2);

        $row.find('#totalItemSale').val(total);
        SumBasquetSale();

        //SumBasquetSale();
           
    });   

    $('#dtBasquetSale tbody').on('click', 'tr td #btnMinusItemBasquet', function () {
        var $row = $(this).closest('tr');
        var ID = $row.find('td:eq(0)').text();
        var inforExtra = $row.find('#Colinfo').val();
        var cantidad = parseFloat($row.find('#quantity').val());        
        var suma = cantidad - 1;
        if (suma == 0) {
            suma = 1;
        }
        $row.find('#quantity').val(suma);

        //Calculo        
        var precioUnitario = parseFloat($row.find('#puItem').text());
        // var precioUnitario2 = parseFloat($row.find('#puItem').text());

        var total = parseFloat(suma * precioUnitario).toFixed(2);

        $row.find('#totalItemSale').val(total);
        SumBasquetSale();

        //SumBasquetSale();

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
        list.splice(objIndex,1);

        //$(this).parents('tr').remove();
        $(el).closest('tr').css('background', 'tomato');
        $(el).closest('tr').fadeOut(400, function () {
            $(this).remove();
            SumBasquetSale();
            //$(this).parents('tr').remove();
        });


      //  SumBasquetSale();

        //var con = confirm("Desea anular la venta?");
        //if (con) {
        //    Jquery102("#loaderDiv").show();
        //    $.ajax({
        //        type: "POST",
        //        url: "/Order/AnularVenta",
        //        data: { 'idDocumento': parseInt(ID) },
        //        success: function (data) {
        //            if (data.status) {
        //                //   alert('Successfully saved');                     
        //             //   alert('Venta anulada');
        //                toastr.error('Venta anulada');
        //            }
        //            //render products to appropriate dropdown

        //        },
        //        error: function (error) {
        //            toastr.error(error);
        //            console.log(error);
        //            $("#loaderDiv").hide();
        //        }
        //    });
        //  Jquery102(this).parents('tr').remove();
        //   Jquery102("#loaderDiv").hide();
        //}
        //else {
        //}
        //var mydata = (tableObj.row(row).data());
        //alert(mydata["idDocumento"]);



    });

    $('#dtBasquetSale tbody').on('keyup mouseup', 'tr td #quantity', function (e) {

        var $row = $(this).closest('tr');
        //var ID = $row.find('td:eq(0)').text();        
      //  ImporteAbonado += parseFloat($row.find('#totalItemSale').val());

        var cantidad = parseFloat($row.find('#quantity').val());
        var precioUnitario = parseFloat($row.find('#puItem').text());
       // var precioUnitario2 = parseFloat($row.find('#puItem').text());

        var total = parseFloat(cantidad * precioUnitario).toFixed(2);

        $row.find('#totalItemSale').val(total);
        SumBasquetSale();
    });

    $('#dtBasquetSale tbody').on('keyup mouseup', 'tr td #totalItemSale', function (e) {

        var $row = $(this).closest('tr');              
        SumBasquetSale();
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

        if ($("#idMesa").val().trim() == '' || $("#idMesa").val() == '0') {
           // alert('Identificar la mesa');
            sweetAlert("Identificar la mesa!!");  
            return;
        }

        //var mesaName = $('#CountryList').find("option:selected").text();
        var mesaName = $("#nombreMesa").val().trim()
        var prop_mesa;
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
                                    let colBI = redondearExp(colTotal / 1.18, 2, true);
                                    let colIGV = Number(parseFloat(colTotal - colBI).toFixed(2));

                                    var colInfoExtra = $row.find('#Colinfo').val();
                                    prop_mesa = $("#idMesa").val();
                                  
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
                                            break;
                                        case '2':
                                            total_BI2 += colBI;
                                            break;
                                        default:
                                            break;
                                    }
                                    total_IVA += colIGV;
                                    total_PEDIDO += colTotal;

                                    var dataitem = {
                                        idDocumento: 0,
                                        secuencia: 0,
                                        CustomProducto: obj[0],
                                        CustomEquivalencia: obj[0].detalleitem_equivalencias[0],
                                        CustomCatalogo: obj[0].detalleitem_equivalencias[0].detalleitemequivalencia_catalogos[0],
                                        equivalencia_id: obj[0].detalleitem_equivalencias[0].equivalencia_id,
                                        catalogo_id: obj[0].detalleitem_equivalencias[0].detalleitemequivalencia_catalogos[0].idCatalogo,
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
                                        precioUnitario: 0,
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
                                        detalleAdicional: colInfoExtra,
                                        idDistribucion: prop_mesa,
                                        estadoDistribucion: 'A',
                                        usuarioModificacion: data.IDUsuario,
                                        fechaModificacion: today
                                    }
                                    listDetailOrder.push(dataitem);
                                });


                                //  var now = new Date();
                                $("#loaderDiv").show();

                                var dataVenta = {
                                    nroOrdenVenta: mesaName,
                                    tipoOperacion: '01',
                                    codigoLibro: '8',
                                    idEmpresa: "12345678912",
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
                                    idEmpresa: "12345678912",
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
                                            $("#idMesa").val('');
                                            document.getElementById('MesaName').innerHTML = "0";
                                            Jquery102("#CountryList").val('default');
                                            Jquery102("#CountryList").selectpicker("refresh");
                                            //renderMesas();
                                            //$('#total', '#price').val('0.00');
                                            //$('#orderdetailsItems').empty();
                                            //    $('#btSaveOrderSale').text('Save');
                                            //$("input[id=price]").val(0)
                                            //$("input[id=total]").val(0)

                                            $("#btSaveOrderSale").removeAttr('disabled');
                                            //$("#btnNuevaEntidad").prop("disabled", true);
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


    $('#btnConsultar').click(function () {
        //alert('script ordenes');}}
        var mesa = $('#CountryList').val();       
   
        var data = { 'mesa': mesa };      

        $('#datatablePedidos').DataTable({
            destroy: true,
            paging: true,
            searching: true,
            responsive: true,
            language: {
                sLoadingRecords: '<span style="width:100%;">"Procesando..."</span>',
                "sProcessing": "Procesando...",

                "sLengthMenu": "Mostrar _MENU_ registros",

                "sZeroRecords": "No se encontraron resultados",

                "sEmptyTable": "Ningún dato disponible en esta tabla",

                "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",

                "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",

                "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",

                "sInfoPostFix": "",

                "sSearch": "Buscar:",

                "sUrl": "",

                "sInfoThousands": ",",

                "oPaginate": {

                    "sFirst": "Primero",

                    "sLast": "Último",

                    "sNext": "Siguiente",

                    "sPrevious": "Anterior"

                },

                "oAria": {

                    "sSortAscending": ": Activar para ordenar la columna de manera ascendente",

                    "sSortDescending": ": Activar para ordenar la columna de manera descendente"

                }
            },
            "order": [[0, 'desc']],
            "ajax": {
                "url": "/Order/LoadOrders",
                "type": "GET",
                "data": data,
                "datatype": "json"
            },
            "columns": [
                {
                    "data": "idDocumento", 'render': function (webSite) {
                        if (!webSite) {
                            return 'N/A';
                        }
                        else {
                            return '<a href=' + webSite + 'id=id>'
                                + webSite + '</a>';
                        }
                    }
                },
                { "data": "secuencia", "autoWidth": true, "visible": true },
                {
                    "data": "FechaDoc", 'render': function (jsonDate) {
                        var date = new Date(parseInt(jsonDate.substr(6)));
                        var month = date.getMonth() + 1;
                        return date.getDate() + "/" + month + "/" + date.getFullYear() + " " + date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds();
                    }
                },
                {
                    "data": "usuarioModificacion", "autoWidth": true, 'render': function (vendedor) {
                        if (!vendedor) {
                            return 'N/A';
                        }
                        else {
                            var vend = UsuariosSystem.filter(p => p.idUsuario == vendedor);
                            var o = Object(vend);
                            var content = JSON.stringify(o);
                            var obj = JSON.parse(content);
                            var nombre = obj[0].full_Name;
                            return nombre;
                        }
                    }
                },
                { "data": "TipoDoc", "autoWidth": true },                            
                {
                    "data": "nombreItem", 'render': function (webSite) {
                        if (!webSite) {
                            return 'N/A';
                        }
                        else {
                            return '<span style:"font:size:11px;" class="label label-default">' + webSite + '</span>';
                        }
                    }
                },
                { "data": "monto1", "autoWidth": true },
                {
                    data: 'importeMN', className: 'dt-body-right',
                    render: $.fn.dataTable.render.number(',', '.', 2)
                },
                
                {
                    "data": "estadoPago", 'render': function (webSite) {
                        if (!webSite) {
                            return 'N/A';
                        }
                        else {
                            var status;
                            switch (webSite) {

                                case "PN":
                                    status = "Pendiente";
                                    break;
                                default:
                                    status = "N/A";
                                    break;
                            }

                            return '<span style:"font:size:11px;" class="label label-warning">' + status + '</span>';
                        }
                    }
                },                
                {
                    data: null, render: function (data, type, row) {
                        //  return "<a href='#' class='btn btn-danger' onclick=DeleteData('" + row.idDocumento + "'); >Delete</a>";
                        //return "<a href='#' class='editor_remove'  >Delete</a>";
                        return '<a href="#" class="btn btn-danger btn-sm" id=deleteVenta> <span class="glyphicon glyphicon-trash"></span> </a>';
                    }
                },
                {
                    data: null, render: function (data, type, row) {
                        //  return "<a href='#' class='btn btn-danger' onclick=DeleteData('" + row.idDocumento + "'); >Delete</a>";
                        //return "<a href='#' class='editor_remove'  >Delete</a>";
                        return '<a href="#" class="btn btn-success btn-sm" id=printOrder> <span class="glyphicon glyphicon-print"></span> </a>';
                    }
                }
            ]
        })
    });

    /*{
        "render": function (data, type, full, meta) { return '<a class="btn btn-info btn-sm" href="/Order/Edit/' + full.idDocumento + '"><span class="glyphicon glyphicon-search"></span> Ver</a>'; }
    },*/

    $('#datatablePedidos tbody').on('click', 'tr td #deleteVenta', function () {
        var el = this;
        var $row = $(this).closest('tr');
        var ID = $row.find('td:eq(0)').text();
        var sec = $row.find('td:eq(1)').text();
        var mesa = $('#CountryList').val();

        //var answer = window.confirm("Desea eliminar el pedido seleccionado?")
        //if (answer) {
        //    //some code
        //    $.ajax({
        //        type: "POST",
        //        url: "/Order/EliminarPedido",
        //        data: { 'idDocumento': parseInt(ID), 'secuencia': parseInt(sec), 'idmesa': parseInt(mesa) },
        //        success: function (data) {
        //            //typeof PedidoSeleccionado;
        //            toastr.success('Pedido eliminado');
        //            $("#datatablePedidos tbody tr").remove();

        //        },
        //        error: function (error) {
        //            console.log(error);
        //        }
        //    });
        //}
        //else {
        //    //some code
        //}

        sweetAlert({
            title: "¿Estás seguro?",
            text: "¿Estás seguro de que deseas eliminar está orden?",
            type: "warning",
            showCancelButton: true,
            closeOnConfirm: false,
            confirmButtonText: "Sí, bórralo!",
            confirmButtonColor: "#ec6c62"
        },
            function () {
                $.ajax({
                    url: "/Order/EliminarPedido",
                    data: { 'idDocumento': parseInt(ID), 'secuencia': parseInt(sec), 'idmesa': parseInt(mesa) },
                    type: "POST"
                })
                    .done(function (data) {
                        $(el).closest('tr').css('background', 'tomato');
                        $(el).closest('tr').fadeOut(800, function () {
                            $(this).remove();
                        });
                        sweetAlert
                            ({
                                title: "Eliminado",
                                text: "Su archivo fue eliminado exitosamente!",
                                type: "success"
                            },
                                function () {

                                    //window.location.href = '/DeleteConfirmation/Details';
                                });
                    })
                    .error(function (data) {
                        sweetAlert("Oops", "¡No pudimos conectarnos al servidor!", "Error");
                    });
            });  


    });


    $('#datatablePedidos tbody').on('click', 'tr td #printOrder', function () {

        var $row = $(this).closest('tr');
        var ID = $row.find('td:eq(0)').text();
        var sec = $row.find('td:eq(1)').text();
        var vendedor = $row.find('td:eq(3)').text();
        var mesa = $('#CountryList').val();
        var mesaName = $('#CountryList').find("option:selected").text();

        var answer = window.confirm("Desea imprimir el pedido seleccionado?")
        if (answer) {
            //some code
            $.ajax({
                type: "GET",
                url: '/Order/GetPrintDocumento',
                data: { 'idmesa': mesa, 'fecha': '22/10/2019', 'vendedor': vendedor, 'id': ID, 'nameMesa': mesaName },
                success: function (data) {
                    if (data.status == true) {
                        alert('print success');
                    }
                    //typeof PedidoSeleccionado;
                   // toastr.success('Pedido eliminado');
                    //$("#datatablePedidos tbody tr").remove();

                },
                error: function (error) {
                    console.log(error);
                }
            });
        }
        else {
            //some code
        }

    });
});

//update infraestructura 
$('#btnActualizarBoton').click(function (e) {

    //  e.preventDefault();

    if ($(this).attr('disabled') == 'disabled') {
        e.preventDefault();

        return;
    }
     
    var mesaName = $('#DistribucionID').val();
    var DistribucionID = $('#DistribucionID').val();
    var estado = "U"  //$('#EstadoInfra').val();
      
    $("#btnActualizarBoton").attr('disabled', 'disabled');
          
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
                                                   
                            var districuionInfraestructura = {
                                idDistribucion: DistribucionID,
                                idEmpresa: "12345678912",
                                idCentroCosto: 3,
                                estado: estado                              
                            }
                                   
                            $.ajax({
                                contentType: 'application/json; charset=utf-8',
                                dataType: 'json',
                                type: 'POST',
                                url: '/Order/UpdateInfraestructuraXDistribucionID',
                                data: JSON.stringify({ order: datadoc }),
                                success: function (datadoc) {
                                    if (datadoc.status) {
                                        toastr.success('Mesa actualizado!')
                                        //// alert('Pedido Registrado');
                                        ////here we will clear the form
                                        //$("#loaderDiv").hide();
                                        //$("#dtBasquetSale tbody tr").remove();
                                        //list = [];
                                        //listProductSales = [];
                                        //SumBasquetSale();
                                        ////$('#TextComprador').val('');
                                        //$("#TextFilter").val('');
                                        //$("#idMesa").val('');
                                        //document.getElementById('MesaName').innerHTML = "0";
                                        //Jquery102("#CountryList").val('default');
                                        //Jquery102("#CountryList").selectpicker("refresh");
                                     
                                        $("#btnActualizarBoton").removeAttr('disabled');
                                                                                                              

                                    }
                                    else {
                                        $("#btnActualizarBoton").removeAttr('disabled');
                                        alert('Error');
                                        $("#loaderDiv").hide();
                                    }
                                    //   $('#btSaveOrderSale').text('Save');
                                },
                                error: function (error) {
                                    $("#btnActualizarBoton").removeAttr('disabled');
                                    // console.log(error);
                                    toastr.error('Error al Actualizar Mesa!')
                                    $("#loaderDiv").hide();
                                    //    $('#btSaveOrderSale').text('Save');
                                }
                            });
                                          
                },
                Cancel: function () {
                    $("#btnActualizarBoton").removeAttr('disabled');
                    Jquery102(this).dialog("close");
                }
            }
        });
 
});