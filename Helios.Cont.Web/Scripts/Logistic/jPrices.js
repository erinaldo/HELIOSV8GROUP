var objProduct = null;
var objProduct_unidad = null;
var objProduct_catalogo = null;
var selCatalogoDefault = null;
$(document).ready(function () {
  

    document.getElementById("menuUnidad").addEventListener("click", function (e) {
        //if (e.target && e.target.matches("li.item")) {
        //    e.target.className = "foo"; // new class name here
        //    alert("clicked " + e.target.innerText);
        //}

        if (e.target && e.target.matches("li")) {
            //e.target.className = "foo"; // new class name here
            var ID = e.target.id;
            //alert("clicked " + e.target.innerText);
            alert(ID);
        }
    });

    $('#dtProductsPrices tbody').on('click', 'tr td #btVer', function () {
        var el = this;
        var $row = $(this).closest('tr');
        var ID = $row.find('td:eq(0)').text();        

        //alert(ID);
        var Item = list.filter(p => p.codigodetalle == ID);

        var o = Object(Item);
        var content = JSON.stringify(o);
        var obj = JSON.parse(content);

        objProduct = obj[0];
        $('#ComboCatalogos').empty();
        $("#dtProductPrices tbody tr").remove();
        GetSourceUnidadesComerciales(obj[0].detalleitem_equivalencias);
    });


    $("#TextSearchProduct").on('keyup', function (e) {
        if (e.keyCode === 13) {           

            // Do something
            var div = document.getElementById('menuUnidad')
            if (div !== null) {
                while (div.hasChildNodes()) {
                    div.removeChild(div.lastChild);
                }
            } else {
                //alert("No existe la caja previamente creada.");
            }
            $('#ComboCatalogos').empty();
            $("#dtProductsPrices tbody tr").remove();
            var filter = $("#TextSearchProduct").val();
            //GetProductSelText(filter);
            //RenderProductTableDBPurchase(filter);

            var listItem = document.createElement('i');
            listItem.className = 'fa fa-refresh fa-spin';
            // ul.appendChild(listItem);
            document.getElementById('loading').appendChild(listItem);

            GetProducts(1, filter)
        }
    });

    $("#btnNuevoProduct").click(function () {
     //   alert('hola');
        //var div = document.getElementById('loading')
        //if (div !== null) {
        //    while (div.hasChildNodes()) {
        //        div.removeChild(div.lastChild);
        //    }
        //} else {
        //    alert("No existe la caja previamente creada.");
        //}



      //////  var nuevo_parrafo = document.createElement('i').appendChild(document.createTextNode('Nuevo párrafo.'));
      ////  var listItem = document.createElement('i');
      ////  listItem.className = 'fa fa-refresh fa-spin';
      //// // ul.appendChild(listItem);
      ////  document.getElementById('loading').appendChild(listItem);
    });    

    $('#dtProductPrices tbody').on('keyup mouseup', 'tr td #CantMinima', function (e) {
                
        if (e.keyCode === 13)
        {
            //var $row = $(this).closest('tr');
            //let precUnit = 0;
            //let cantidad = $row.find('#quantity').val();
            //let total = $row.find('#totalItemSale').val();
            //precUnit = parseFloat(total / cantidad).toFixed(2);
            //$row.find('#puItem').text(precUnit);
            //SumBasquetPurchase();
        }        
        //MappingPagosVentaDirecta();
    });

    $('#dtProductPrices tbody').on('click', 'tr td #btnConfirmChanges', function (e) {
        var $row = $(this).closest('tr');
        var ID = $row.find('td:eq(0)').text();
        //alert(ID);
        var precioObj = selCatalogoDefault.detalleitemequivalencia_precios.filter(p => p.precio_id == ID);
        if (precioObj != null) {
            var o = Object(precioObj);
            var content = JSON.stringify(o);
            var obj = JSON.parse(content);

            var precionSend = obj[0];

            let cantidadminima = $row.find('#CantMinima').val();
            let precioContado = $row.find('#preciocontado').val();
            let precioCredito = $row.find('#preciocredito').val();

            precionSend.equivalencia_id = objProduct_unidad.equivalencia_id;
            precionSend.codigodetalle = objProduct.codigodetalle;
            precionSend.rango_inicio = parseFloat(cantidadminima);
            precionSend.precio = parseFloat(precioContado);
            precionSend.precioCredito = parseFloat(precioCredito);
            EditingPrice(precionSend);
        }       
    });

    $('#btAddPrice').click(function () {
        //alert('click price new');
        if (objProduct_catalogo != null) {
           // var precioObj = selCatalogoDefault.detalleitemequivalencia_precios.filter(p => p.precio_id == ID);
         //   if (precioObj != null) {
                //var o = Object(precioObj);
                //var content = JSON.stringify(o);
                //var obj = JSON.parse(content);
            
            let cantidadminima = 0;            
            let precioContado = 0;
            let precioCredito = 0;
            if (selCatalogoDefault.detalleitemequivalencia_precios.length == 0) {
                cantidadminima = 1;
            }
            else
            {
                cantidadminima = Math.max.apply(Math, selCatalogoDefault.detalleitemequivalencia_precios.filter(p => p.idCatalogo == selCatalogoDefault.idCatalogo).map(function (o) { return o.rango_inicio; }))
                cantidadminima = cantidadminima + 1;
            }
            

            var data = {
                idCatalogo: selCatalogoDefault.idCatalogo,
                equivalencia_id: objProduct_unidad.equivalencia_id,
                codigodetalle: objProduct.codigodetalle,
                rango_inicio: parseFloat(cantidadminima),
                precio: parseFloat(precioContado),
                estado: 1,
                precioCredito: parseFloat(precioCredito)
            }
            NewPrice(data);
           // }       
        }
    });
});

function EditingPrice(priceObj) {
    var precMap = priceObj;
    $.ajax({
        type: 'POST',
        url: '/Logistics/EditingPrice',
        data: JSON.stringify(priceObj),
        contentType: 'application/json',
        success: function (data) {
            if (data.status) {
                toastr.success('Precio actualizado!')             

                var indexProd = list.findIndex((p => p.codigodetalle == precMap.codigodetalle));
                
                var indexUnidad = list[indexProd].detalleitem_equivalencias.findIndex((p => p.equivalencia_id == precMap.equivalencia_id));
                var indexCatalogo = list[indexProd].detalleitem_equivalencias[indexUnidad].detalleitemequivalencia_catalogos.findIndex((p => p.idCatalogo == precMap.idCatalogo));
                var indexPrecio = list[indexProd].detalleitem_equivalencias[indexUnidad].detalleitemequivalencia_catalogos[indexCatalogo].detalleitemequivalencia_precios.findIndex((p => p.precio_id == precMap.precio_id));


                list[indexProd].detalleitem_equivalencias[indexUnidad].detalleitemequivalencia_catalogos[indexCatalogo].detalleitemequivalencia_precios[indexPrecio].rango_inicio = precMap.rango_inicio;
                list[indexProd].detalleitem_equivalencias[indexUnidad].detalleitemequivalencia_catalogos[indexCatalogo].detalleitemequivalencia_precios[indexPrecio].precio = precMap.precio;
                list[indexProd].detalleitem_equivalencias[indexUnidad].detalleitemequivalencia_catalogos[indexCatalogo].detalleitemequivalencia_precios[indexPrecio].precioCredito = precMap.precioCredito;

                //var indexUnidad = objProduct.detalleitem_equivalencias.findIndex((p => p.equivalencia_id == precMap.equivalencia_id));
                //var indexCatalogo = objProduct.detalleitem_equivalencias[indexUnidad].detalleitemequivalencia_catalogos.findIndex((p => p.idCatalogo == precMap.idCatalogo));
                //var indexPrecio = objProduct.detalleitem_equivalencias[indexUnidad].detalleitemequivalencia_catalogos[indexCatalogo].detalleitemequivalencia_precios.findIndex((p => p.precio_id == precMap.precio_id));

                //objProduct.detalleitem_equivalencias[indexUnidad].detalleitemequivalencia_catalogos[indexCatalogo].detalleitemequivalencia_precios[indexPrecio].rango_inicio = precMap.rango_inicio;
                //objProduct.detalleitem_equivalencias[indexUnidad].detalleitemequivalencia_catalogos[indexCatalogo].detalleitemequivalencia_precios[indexPrecio].precio = precMap.precio;
                //objProduct.detalleitem_equivalencias[indexUnidad].detalleitemequivalencia_catalogos[indexCatalogo].detalleitemequivalencia_precios[indexPrecio].precioCredito = precMap.precioCredito;

                //var item = selCatalogoDefault.detalleitemequivalencia_precios.filter(p => p.precio_id == precMap.precio_id);
                //var o = Object(item);
                //var content = JSON.stringify(o);
                //var obj = JSON.parse(content);

                //var objIndexCatalogo = objProduct_catalogo.findIndex((p => p.idCatalogo == precMap.idCatalogo));
                //var objIndexPrecio = objProduct_catalogo[objIndexCatalogo].detalleitemequivalencia_precios.findIndex((p => p.precio_id == precMap.precio_id));

                //objProduct_catalogo[objIndexCatalogo].detalleitemequivalencia_precios[objIndexPrecio].rango_inicio = precMap.rango_inicio;
                //objProduct_catalogo[objIndexCatalogo].detalleitemequivalencia_precios[objIndexPrecio].precio = precMap.precio;
                //objProduct_catalogo[objIndexCatalogo].detalleitemequivalencia_precios[objIndexPrecio].precioCredito = precMap.precioCredito;

                //var objIndex = selCatalogoDefault.detalleitemequivalencia_precios.findIndex((obj => obj.precio_id == precMap.precio_id));
                //selCatalogoDefault.detalleitemequivalencia_precios[objIndex].rango_inicio = precMap.rango_inicio;
                //selCatalogoDefault.detalleitemequivalencia_precios[objIndex].precio = precMap.precio;
                //selCatalogoDefault.detalleitemequivalencia_precios[objIndex].precioCredito = precMap.precioCredito;
               // var nombre = obj[0].AfectoInventario;                
            }
            else {
                
                alert('Error');
                //$("#loaderDiv").hide();
            }            
        },
        error: function (error) {           
            toastr.error('Error al grabar pedido!')
         //   $("#loaderDiv").hide();
            // console.log(error);
            //    $('#btSaveOrderSale').text('Save');
        }
    });
}

function NewPrice(priceObj) {
    var precMap = priceObj;
    $.ajax({
        type: 'POST',
        url: '/Logistics/NewPrice',
        data: JSON.stringify(priceObj),
        contentType: 'application/json',
        success: function (data) {
            if (data.data != null) {
                toastr.success('Precio agregado!')
                precMap.precio_id = data.data.precio_id;
                var indexProd = list.findIndex((p => p.codigodetalle == precMap.codigodetalle));

                var indexUnidad = list[indexProd].detalleitem_equivalencias.findIndex((p => p.equivalencia_id == precMap.equivalencia_id));
                var indexCatalogo = list[indexProd].detalleitem_equivalencias[indexUnidad].detalleitemequivalencia_catalogos.findIndex((p => p.idCatalogo == precMap.idCatalogo));
                //var indexPrecio = list[indexProd].detalleitem_equivalencias[indexUnidad].detalleitemequivalencia_catalogos[indexCatalogo].detalleitemequivalencia_precios.findIndex((p => p.precio_id == precMap.precio_id));

                list[indexProd].detalleitem_equivalencias[indexUnidad].detalleitemequivalencia_catalogos[indexCatalogo].detalleitemequivalencia_precios.push(precMap);

           
            }
            else {

                alert('Error');
                //$("#loaderDiv").hide();
            }
        },
        error: function (error) {
            toastr.error('Error al grabar pedido!')
            //   $("#loaderDiv").hide();
            // console.log(error);
            //    $('#btSaveOrderSale').text('Save');
        }
    });
}

function GetSourceUnidadesComerciales(json) {
       //  var nuevo_parrafo = document.createElement('i').appendChild(document.createTextNode('Nuevo párrafo.'));
    var div = document.getElementById('menuUnidad')
        if (div !== null) {
            while (div.hasChildNodes()) {
                div.removeChild(div.lastChild);
            }
        } else {
            alert("No existe la caja previamente creada.");
    }

    for (var i = 0; i < json.length; i++)
    {
        var tagi1 = document.createElement('i');
        tagi1.className = "fa fa-circle-o text-red";

        // var tagi2 = document.createElement('i');
        //tagi2.className = "fa fa-ellipsis-v";

        var span = document.createElement('span');
        span.className = "handle";
        span.appendChild(tagi1);
        //  span.appendChild(tagi2);

        var check = document.createElement("INPUT");
        check.setAttribute("type", "checkbox");
        check.setAttribute("value", "");

        var span2 = document.createElement('span');
        span2.className = "text";
        span2.textContent = json[i].unidadComercial;//  "Unidad Comercial";

        //--------------------------------------------------
        var smalli = document.createElement('i');
       // smalli.className = "fa fa-clock-o";
        var small = document.createElement('small');
        small.className = "label label-danger";
        small.textContent = json[0].detalleitemequivalencia_catalogos.length + " catálogo(s)"; // "3 jiunis";
        small.appendChild(smalli);
        //---------------------------------------------------

        var divi1 = document.createElement('i');
        divi1.className = "fa fa-edit";

        var divi2 = document.createElement('i');
        divi2.className = "fa fa-trash-o";

        var divi3 = document.createElement('i');
        divi3.className = "fa fa-arrow-right";
        divi3.setAttribute("id", json[0].equivalencia_id);
        divi3.addEventListener("click", function (e) {
            //if (e.target && e.target.matches("li")) {
                //e.target.className = "foo"; // new class name here
                //alert("clicked " + e.target.innerText);
         //   alert(e.target.id);
            var id_unidad = e.target.id;
            //alert(objProduct.codigodetalle);
            var indexProduc = list.findIndex(p => p.codigodetalle == objProduct.codigodetalle);

            //var item = objProduct.detalleitem_equivalencias.filter(p => p.equivalencia_id == id_unidad);
            var item = list[indexProduc].detalleitem_equivalencias.filter(p => p.equivalencia_id == id_unidad);

            var o = Object(item);
            var content = JSON.stringify(o);
            var obj = JSON.parse(content);
            objProduct_unidad = obj[0];
            GetCatalogos(obj[0].detalleitemequivalencia_catalogos);
            objProduct_catalogo = obj[0].detalleitemequivalencia_catalogos;
            GetPreciosSelCatalogo(obj[0].detalleitemequivalencia_catalogos[0].idCatalogo)
            //}
        });
  

        var div = document.createElement('div');
        div.className = "tools";
        div.appendChild(divi1);
        div.appendChild(divi2)
        div.appendChild(divi3)
        //-------------------------------------------------------------

        var node = document.createElement("LI")
        node.setAttribute("id", json[0].equivalencia_id);
        node.appendChild(span)
        node.appendChild(check)
        node.appendChild(span2)
        node.appendChild(small)
        node.appendChild(div)
        //    var listItem = document.createElement('i');
        //      listItem.className = 'fa fa-refresh fa-spin';
        // ul.appendChild(listItem);
        //  document.getElementById('loading').appendChild(listItem);
        document.getElementById("menuUnidad").appendChild(node);
    }    
}

$("#ComboCatalogos").on("change", function () {

    var idcatalogo = $(this).val();      
    $("#dtProductPrices tbody tr").remove();
    GetPreciosSelCatalogo(idcatalogo);    
});

//function OnclicBtn(object) {
//    alert('hola');
//}

function GetPreciosSelCatalogo(idCatalogo) {
    var item = objProduct_catalogo.filter(p => p.idCatalogo == idCatalogo);
    var o = Object(item);
    var content = JSON.stringify(o);
    var obj = JSON.parse(content);

    selCatalogoDefault = obj[0];

    var json = obj[0].detalleitemequivalencia_precios;

    for (var i = 0; i < json.length; i++) {

        //if (labelHistory == '') {
        //    labelHistory = "<span style='font-size:11px;' class='label label-success pull-right'>";
        //    labelRender = "<span style='font-size:11px;' class='label label-success pull-right'>";
        //} else if (labelHistory == "<span style='font-size:11px;' class='label label-success pull-right'>") {
        //    labelHistory = "<span style='font-size:11px;' class='label label-warning pull-right'>";
        //    labelRender = "<span style='font-size:11px;' class='label label-warning pull-right'>";
        //} else if (labelHistory == "<span style='font-size:11px;' class='label label-warning pull-right'>") {
        //    labelHistory = "<span style='font-size:11px;' class='label label-danger pull-right'>";
        //    labelRender = "<span style='font-size:11px;' class='label label-danger pull-right'>";
        //} else if (labelHistory == "<span style='font-size:11px;' class='label label-danger pull-right'>") {
        //    labelHistory = "<span style='font-size:11px;' class='label label-info pull-right'>";
        //    labelRender = "<span style='font-size:11px;' class='label label-info pull-right'>";
        //} else if (labelHistory == "<span style='font-size:11px;' class='label label-info pull-right'>") {
        //    labelHistory = '';
        //    labelRender = "<span style='font-size:11px;' class='label label-default pull-right'>";
        //}
      //  ColCantMinima = "<td>" + json[i].rango_inicio + "</td >";
        ColumnID = "<td style='display: none;' class='mailbox-subject' style='font-size: smaller'>" + json[i].precio_id + "</td>";
        ColCantMinima = "<td>" + "<input type='number' name='CantMinima' id='CantMinima' value='" + json[i].rango_inicio + "' />" + "</td>";

        colPrecioContado = "<td>" + "<input type='number' name='preciocontado' id='preciocontado' value='" + json[i].precio + "' />" + "</td>";
        //colPrecioCredito = "<td>" + json[i].precioCredito + "</td >";        
        colPrecioCredito = "<td>" + "<input type='number' name='preciocredito' id='preciocredito' value='" + json[i].precioCredito + "' />" + "</td>";
        colEstado = "<td>" + json[i].estado + "</td >";

        columnBtn = "<td><button id='btnConfirmChanges' type='button' class='btn btn-info btn-sm'><span class='glyphicon glyphicon-flash'></span></button ></td>";
        //Maping tabla Produts
        tr = $('<tr/>');
        tr.append(ColumnID);
        tr.append(ColCantMinima);
        tr.append(colPrecioContado);
        tr.append(colPrecioCredito);      
        tr.append(colEstado);
        tr.append(columnBtn);
        //<span class='label label-warning'>Pending</span>
        $('#dtProductPrices').append(tr);
    }
}


function GetCatalogos(data) {
    $('#ComboCatalogos').empty();
    $("#dtProductPrices tbody tr").remove();
    //$('#ComboAlmacenDestino').append('<option value=-1>' + '-Selec almacén-' + '</option > ');

    for (var i = 0; i < data.length; i++) {
        //  $('#ComboAlmacenDestino').append('<option value=' + almacenList[i].idAlmacen + '>' + almacenList[i].descripcionAlmacen + '</option > ');
        //      $("#ComboAlmacenDestino").append("<option>" + almacenList[i].descripcionAlmacen + "</option>")
        $("#ComboCatalogos").append($("<option></option>").val(data[i].idCatalogo).html(data[i].nombre_corto));
    }
}

function GetProducts(pageIndex, filter) {
    $.ajax({
        type: "POST",
        url: "/Logistics/AjaxMethod",
        data: '{pageIndex: ' + pageIndex + ', sortName: "' + '-' + '", sortDirection: "' + '-' + '", Text: "' + filter + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess,
        failure: function (response) {
            var div = document.getElementById('loading')
            if (div !== null) {
                while (div.hasChildNodes()) {
                    div.removeChild(div.lastChild);
                }
            } else {
                //   alert("No existe la caja previamente creada.");
            }
            alert(response.d);
        },
        error: function (response) {
            var div = document.getElementById('loading')
            if (div !== null) {
                while (div.hasChildNodes()) {
                    div.removeChild(div.lastChild);
                }
            } else {
                //   alert("No existe la caja previamente creada.");
            }
            alert(response.d);
        }
    });
};

function OnSuccess(response) {

    $("#dtProductsPrices tbody tr").remove();

    var model = response;
    var row = $("#dtProductsPrices tr:last-child").removeAttr("style").clone(true);
    $("#dtProductsPrices tr").not($("#dtProductsPrices tr:first-child")).remove();
    var tr;
    var ColumnID;
    var colCategory;
    var colCodigo;
    var colProducto;
    var colUnidadMedida;
    var colTipoExistencia;
    var colAfectacion;
    var colEstado;

    if (model.Detalleitems.length == 0) {
        var div = document.getElementById('loading')
        if (div !== null) {
            while (div.hasChildNodes()) {
                div.removeChild(div.lastChild);
            }
        } else {
            //   alert("No existe la caja previamente creada.");
        }
    }

    list = model.Detalleitems;

    $.each(model.Detalleitems, function () {
        var product = this;
        //$("td", row).eq(0).html(product.codigodetalle);
        //$("td", row).eq(1).html(product.codigo);
        //$("td", row).eq(2).html(product.descripcionItem);
        //$("td", row).eq(3).html(product.unidad1);
        //$("td", row).eq(4).html(product.tipoExistencia);
        //$("td", row).eq(5).html(product.origenProducto);
        //$("td", row).eq(6).html(product.estado);
        //$("#dtProductsPrices").append(row);

        ColumnID = "<td><a id='btVer' href='#'>" + product.codigodetalle + "</td >";
        colCategory = "<td>" + "-" + "</td >";
        colCodigo = "<td>" + product.codigo + "</td >";
        colProducto = "<td>" + product.descripcionItem + "</td >";
        colUnidadMedida = "<td>" + product.unidad1 + "</td >";
        colTipoExistencia = "<td>" + product.tipoExistencia + "</td >";
        colAfectacion = "<td>" + product.origenProducto + "</td >";
        colEstado = "<td>" + product.estado + "</td >";
        //Maping tabla Produts
        tr = $('<tr/>');



        tr.append(ColumnID);
        tr.append(colCategory);
        tr.append(colCodigo);
        tr.append(colProducto);
        tr.append(colUnidadMedida);
        tr.append(colTipoExistencia);
        tr.append(colAfectacion);
        tr.append(colEstado);
        //<span class='label label-warning'>Pending</span>
        $('#dtProductsPrices').append(tr);



        var div = document.getElementById('loading')
        if (div !== null) {
            while (div.hasChildNodes()) {
                div.removeChild(div.lastChild);
            }
        } else {
         //   alert("No existe la caja previamente creada.");
        }
        //row = $("#dtProductsPrices tr:last-child").clone(true);
    });
    Jquery102(".Pager").ASPSnippets_Pager({
        ActiveCssClass: "current",
        PagerCssClass: "pager",
        PageIndex: model.PageIndex,
        PageSize: model.PageSize,
        RecordCount: model.RecordCount
    });
};

$("body").on("click", ".Pager .page", function () {
    var listItem = document.createElement('i');
    listItem.className = 'fa fa-refresh fa-spin';
    // ul.appendChild(listItem);
    document.getElementById('loading').appendChild(listItem);

    var filter = $("#TextSearchProduct").val();
    GetProducts(parseInt($(this).attr('page')), filter);
});

function RenderProductTableDBPurchase(Text) {
    listProductSelCategory = [];

    $.getJSON("/Logistics/GetProductSelText?Text=" + Text,
        function (json) {
            var tr;
            //Append each row to html table                  
            var ColumnID;
            var colCategory;
            var colCodigo;
            var colProducto;
            var colUnidadMedida;
            var colTipoExistencia;
            var colAfectacion;
            var colEstado;
            
            for (var i = 0; i < json.length; i++) {
                              
                //if (labelHistory == '') {
                //    labelHistory = "<span style='font-size:11px;' class='label label-success pull-right'>";
                //    labelRender = "<span style='font-size:11px;' class='label label-success pull-right'>";
                //} else if (labelHistory == "<span style='font-size:11px;' class='label label-success pull-right'>") {
                //    labelHistory = "<span style='font-size:11px;' class='label label-warning pull-right'>";
                //    labelRender = "<span style='font-size:11px;' class='label label-warning pull-right'>";
                //} else if (labelHistory == "<span style='font-size:11px;' class='label label-warning pull-right'>") {
                //    labelHistory = "<span style='font-size:11px;' class='label label-danger pull-right'>";
                //    labelRender = "<span style='font-size:11px;' class='label label-danger pull-right'>";
                //} else if (labelHistory == "<span style='font-size:11px;' class='label label-danger pull-right'>") {
                //    labelHistory = "<span style='font-size:11px;' class='label label-info pull-right'>";
                //    labelRender = "<span style='font-size:11px;' class='label label-info pull-right'>";
                //} else if (labelHistory == "<span style='font-size:11px;' class='label label-info pull-right'>") {
                //    labelHistory = '';
                //    labelRender = "<span style='font-size:11px;' class='label label-default pull-right'>";
                //}
                ColumnID = "<td>" + json[i].codigodetalle + "</td >";               
                colCategory = "<td>" + "-" + "</td >";
                colCodigo = "<td>" + json[i].codigo + "</td >";
                colProducto = "<td>" + json[i].descripcionItem + "</td >";
                colUnidadMedida = "<td>" + json[i].unidad1 + "</td >"; 
                colTipoExistencia = "<td>" + json[i].tipoExistencia + "</td >";  
                colAfectacion = "<td>" + json[i].origenProducto + "</td >";   
                colEstado = "<td>" + json[i].estado + "</td >";  
                //Maping tabla Produts
                tr = $('<tr/>');

                

                tr.append(ColumnID);
                tr.append(colCategory);
                tr.append(colCodigo);
                tr.append(colProducto);
                tr.append(colUnidadMedida);
                tr.append(colTipoExistencia);
                tr.append(colAfectacion);
                tr.append(colEstado);
                //<span class='label label-warning'>Pending</span>
                $('#dtProductsPrices').append(tr);
            }
        });
}