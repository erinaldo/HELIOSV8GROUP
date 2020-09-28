$(document).ready(function () {

    $('#btnConsultarTransfer').click(function () {
        //alert('script ordenes');
        var mes = $('#cboMes').val();
        var anio = $('#textAnio').val();

        if (mes == "-1") {
            alert('Debe seleccionar un mes válido!');
            return;
        }
        //     $("#loaderDiv").show();

        //    var youngsters2 = UsuariosSystem.filter(p => p.idUsuario == 21230);

        //var o = Object(youngsters2);
        //var content = JSON.stringify(o);
        //var obj = JSON.parse(content);
        ////alert(content);        
        //alert(obj[0].full_Name);
        var data = { 'mes': mes, "anio": anio };

        $('#dtTransfer').DataTable({
            destroy: true,
            paging: true,
            searching: true,
            responsive: true,
            language: {
                sLoadingRecords: '<span style="width:100%;"><img src="http://www.snacklocal.com/images/ajaxload.gif"></span>'
            },
            "order": [[0, 'desc']],
            "ajax": {
                "url": "/Logistics/GetTransferenciasPeriodo",
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
                {
                    "data": "fechaDoc", 'render': function (jsonDate) {
                        var date = new Date(parseInt(jsonDate.substr(6)));
                        var month = date.getMonth() + 1;
                        return date.getDate() + "/" + month + "/" + date.getFullYear() + " " + date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds();
                    }
                },
                {
                    "data": "usuarioActualizacion", "autoWidth": true, 'render': function (vendedor) {
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
                { "data": "tipoDocumento", "autoWidth": true },              
                { "data": "numeroVenta", "autoWidth": true },
               // { "data": "CustomAlmacenPartida.descripcionAlmacen", "autoWidth": true },
                {
                    "render": function (data, type, full, meta) { return full.documentoventaAbarrotesDet[0].CustomAlmacenPartida.descripcionAlmacen; }
                },
                {
                    "render": function (data, type, full, meta) {
                        return full.documentoventaAbarrotesDet[0].CustomAlmacenLlegada.descripcionAlmacen;
                    }
                },              
                {
                    "render": function (data, type, full, meta) {
                       
                        return full.documentoventaAbarrotesDet.length;
                    }
                },              
                //{ "data": "documentoventaAbarrotesDet.Count", "autoWidth": true },
                {
                    "render": function (data, type, full, meta) {

                        return "Entregado";
                    }
                },              
                {
                    //"render": function (data, type, full, meta) { return '<a class="btn btn-info" href="/Order/Edit/' + full.idDocumento + '"><span class="glyphicon glyphicon-search"></span> Ver</a>'; }
                    "render": function (data, type, full, meta) { return '<a id="btviewTransfer" class="btn btn-info" href="javascript:void(0);" data-id="+' + full.idDocumento + '"><span class="glyphicon glyphicon-search"></span> Ver</a>'; }
                },
                {
                    data: null, render: function (data, type, row) {
                        //  return "<a href='#' class='btn btn-danger' onclick=DeleteData('" + row.idDocumento + "'); >Delete</a>";
                        //return "<a href='#' class='editor_remove'  >Delete</a>";
                        return '<a href="#" class="btn btn-danger" id=#> <span class="glyphicon glyphicon-trash"></span> </a>';
                    }
                },
            ]
        })

        //    $("#loaderDiv").hide();
    });

  
    $('#btnConsultarTransferTransit').click(function () {
      
        $('#dtTransferTransit').DataTable({
            destroy: true,
            paging: true,
            searching: true,
            responsive: true,
            language: {
                sLoadingRecords: '<span style="width:100%;"><img src="http://www.snacklocal.com/images/ajaxload.gif"></span>'
            },
            "order": [[0, 'desc']],
            "ajax": {
                "url": "/Logistics/GetTransferenciasEnTransito",
                "type": "GET",
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
                {
                    "data": "fechaDoc", 'render': function (jsonDate) {
                        var date = new Date(parseInt(jsonDate.substr(6)));
                        var month = date.getMonth() + 1;
                        return date.getDate() + "/" + month + "/" + date.getFullYear() + " " + date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds();
                    }
                },
                {
                    "data": "usuarioActualizacion", "autoWidth": true, 'render': function (vendedor) {
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
                { "data": "tipoDocumento", "autoWidth": true },
                { "data": "numeroVenta", "autoWidth": true },
                // { "data": "CustomAlmacenPartida.descripcionAlmacen", "autoWidth": true },
                {
                    "render": function (data, type, full, meta) { return full.documentoventaAbarrotesDet[0].CustomAlmacenPartida.descripcionAlmacen; }
                },
                {
                    "render": function (data, type, full, meta) {
                        return full.documentoventaAbarrotesDet[0].CustomAlmacenLlegada.descripcionAlmacen;
                    }
                },
                {
                    "render": function (data, type, full, meta) {

                        return full.documentoventaAbarrotesDet.length;
                    }
                },
                //{ "data": "documentoventaAbarrotesDet.Count", "autoWidth": true },
                {
                    "render": function (data, type, full, meta) {

                        return "Entregado";
                    }
                },
                {
                    //"render": function (data, type, full, meta) { return '<a class="btn btn-info" href="/Order/Edit/' + full.idDocumento + '"><span class="glyphicon glyphicon-search"></span> Ver</a>'; }
                    "render": function (data, type, full, meta) { return '<a id="btviewTransfer" class="btn btn-info" href="javascript:void(0);" data-id="+' + full.idDocumento + '"><span class="glyphicon glyphicon-search"></span> Ver</a>'; }
                },
                {
                    data: null, render: function (data, type, row) {
                        //  return "<a href='#' class='btn btn-danger' onclick=DeleteData('" + row.idDocumento + "'); >Delete</a>";
                        //return "<a href='#' class='editor_remove'  >Delete</a>";
                        return '<a href="#" class="btn btn-danger" id=#> <span class="glyphicon glyphicon-trash"></span> </a>';
                    }
                },
            ]
        })

        //    $("#loaderDiv").hide();
    });
});

$('#dtTransferTransit tbody').on('click', 'tr td #confirmTransfer', function () {
  //  var ID = $row.find('td:eq(0)').text();
   // var el = this;
    var $row = $(this).closest('tr');
    var ID = $row.find('td:eq(0)').text();
    //var datadoc = {      
    //    idDocumento: 0
    //}

    var datadoc = {     
        idDocumento: ID,
        idEmpresa: '20602665063',
        idCentroCosto: 3,
        idProyecto: 0,
        tipoDoc: '00',
        fechaProceso: '11-02-2020',
        moneda: '1',
        idEntidad: 0,
        entidad: 'NN',
        tipoEntidad: 'TR',
        nrodocEntidad: 0,
        nroDoc: '0',
        idOrden: 0,
        tipoOperacion: '11',
        CustomNumero: '0',
        ventaConLotes: false,
        usuarioActualizacion: '1',
        fechaActualizacion: '11-02-2020'
    }

    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: '/Logistics/ConfirmTransfer',
        data: JSON.stringify({ order: datadoc }),
        success: function (datadoc) {
            if (datadoc.status) {
                toastr.success('Transferencia Entregada!')
                                                                           
                GetTransfersTransit();
            }
            else {
              
            }
            //   $('#btSaveOrderSale').text('Save');
        },
        error: function (error) {
            $("#btSaveTransfer").removeAttr('disabled');
            // console.log(error);
            toastr.error('Error al grabar pedido!')
            $("#loaderDiv").hide();
            console.log(error);
            //    $('#btSaveOrderSale').text('Save');
        }
    });
});

$('#dtTransfer tbody').on('click', 'tr td #btviewTransfer', function () {
    var $row = $(this).closest('tr');
    var ID = $row.find('td:eq(0)').text();
    //var inforExtra = $row.find('#Colinfo').val();
    //var cantidad = parseFloat($row.find('#quantity').val());
    //alert(ID);

    var url = "/Logistics/ViewWarehouseTransfer/" + ID;

    debugger;
    var $buttonClicked = $(this);
    var id = $buttonClicked.attr('data-id');
    var options = { "backdrop": "static", keyboard: true };
    $.ajax({
        type: "GET",
        url: url,
        contentType: "application/json; charset=utf-8",
        data: { "Id": id },
        datatype: "json",
        success: function (data) {
            debugger;
            $('#myModalContent').html(data);
            $('#myModal').modal(options);
            $('#myModal').modal('show');

        },
        error: function () {
            alert("Dynamic content load failed.");
        }
    });

    //$("#closebtn").on('click',function(){  
    //    $('#myModal').modal('hide');    

    $("#closbtn").click(function () {
        $('#myModal').modal('hide');
    });



    //$("#btnShowModal").click(function () {
    //    $("#loginModal").modal('show');
    //});

    //$("#btnHideModal").click(function () {
    //    $("#loginModal").modal('hide');
    //}); 

    //$.ajax({
    //    url: url,
    //    type: 'GET',
    //    cache: false,
    //    success: function (result) {
    //        $('#editModal').html(result).find('.modal').modal({
    //            show: true
    //        });
    //        $("#savePackageChangesBtn").click(function () {
    //            $('.modal').modal({
    //                show: true
    //            });
    //            return false; //prevent browser defualt behavior
    //        });
    //    }
    //});
    return false; //prevent browser defualt behavior

});

$('#dtTransferTransit tbody').on('click', 'tr td #btviewTransfer', function () {
    var $row = $(this).closest('tr');
    var ID = $row.find('td:eq(0)').text();
    //var inforExtra = $row.find('#Colinfo').val();
    //var cantidad = parseFloat($row.find('#quantity').val());
    //alert(ID);

    var url = "/Logistics/ViewWarehouseTransfer/" + ID;

    debugger;
    var $buttonClicked = $(this);
    var id = $buttonClicked.attr('data-id');
    var options = { "backdrop": "static", keyboard: true };
    $.ajax({
        type: "GET",
        url: url,
        contentType: "application/json; charset=utf-8",
        data: { "Id": id },
        datatype: "json",
        success: function (data) {
            debugger;
            $('#myModalContent').html(data);
            $('#myModal').modal(options);
            $('#myModal').modal('show');

        },
        error: function () {
            alert("Dynamic content load failed.");
        }
    });

    //$("#closebtn").on('click',function(){  
    //    $('#myModal').modal('hide');    

    $("#closbtn").click(function () {
        $('#myModal').modal('hide');
    });



    //$("#btnShowModal").click(function () {
    //    $("#loginModal").modal('show');
    //});

    //$("#btnHideModal").click(function () {
    //    $("#loginModal").modal('hide');
    //}); 

    //$.ajax({
    //    url: url,
    //    type: 'GET',
    //    cache: false,
    //    success: function (result) {
    //        $('#editModal').html(result).find('.modal').modal({
    //            show: true
    //        });
    //        $("#savePackageChangesBtn").click(function () {
    //            $('.modal').modal({
    //                show: true
    //            });
    //            return false; //prevent browser defualt behavior
    //        });
    //    }
    //});
    return false; //prevent browser defualt behavior

});

function SumBasquetPurchase() {
    var ImporteAbonado = 0;
    $('#dtBasquetTransfer tbody tr').each(function () {
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

function renderCatalogosTablePurchase(element, data, row) {
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
        SumBasquetPurchase();

        $.each(data, function (i, val) {
            $ele.append($('<option/>').val(val.idCatalogo).text(val.nombre_corto));
        })
        row.find('#comboCatalogo').prop("disabled", false);
    }
}

function addItemToBasketPurchase(json) {
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

    //var htmlextraCatalogos = "<select id='comboCatalogo' class='pull-left' style='border: 1px solid whitesmoke; margin: 2px;'>" +
    //    itemsCatalogos + "</select>";

    var htmlextraCatalogos = "";

    var price = 0;//json[i].detalleitem_equivalencias[0].detalleitemequivalencia_catalogos[0].detalleitemequivalencia_precios[0].precio;
    //var count = json[0].detalleitem_equivalencias[0].detalleitemequivalencia_catalogos[0].detalleitemequivalencia_precios.length;
    //if (count == 0) {
    //    price = 0;
    //} else {
    //    price = parseFloat(json[0].detalleitem_equivalencias[0].detalleitemequivalencia_catalogos[0].detalleitemequivalencia_precios[0].precio).toFixed(2);
    //}

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
        "</span>" + "</td>";
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
    $('#dtBasquetTransfer').append(tr);
    SumBasquetPurchase();
    //MappingPagosVentaDirecta();
    //  }
}

function RenderProductTableDBTransfer(Text, almacen) {
    listProductSelCategory = [];

    // var url = '@Url.Action("GetProductSelAlmacenText", "Logistics")'; // don't hard code your urls!
    //   $.getJSON(url, { Text: Text, idalmacen: almacen },
    $.getJSON('/Logistics/GetProductSelAlmacenText/', { Text: Text, idalmacen: almacen },
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

                var aggregate = json[i].totalesAlmacen.reduce(function (item1, item2) {
                    return { name: '', cantidad: item1.cantidad + item2.cantidad };
                });


                //  alert(aggregate.cantidad);

                columnPrice = "<td>" + labelRender + "st. " + parseFloat(aggregate.cantidad).toFixed(2) + "</span>" + "</td>";

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
                $('#dtProductsTransfer').append(tr);
            }
        });
}

function ValidarDetalleTransfer() {
    var Valid = true;
    var errorItemCount = 0;
    var numFilas = document.getElementById("dtBasquetTransfer").rows.length;

    if (numFilas > 0) {
        $('#dtBasquetTransfer tbody tr').each(function () {
            var $row = $(this).closest('tr');
            var ID = $row.find('td:eq(0)').text();

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

function GetTransfersTransit() {
    $('#dtTransferTransit').DataTable({
        destroy: true,
        paging: true,
        searching: true,
        responsive: true,
        language: {
            sLoadingRecords: '<span style="width:100%;"><img src="http://www.snacklocal.com/images/ajaxload.gif"></span>'
        },
        "order": [[0, 'desc']],
        "ajax": {
            "url": "/Logistics/GetTransferenciasEnTransito",
            "type": "GET",
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
            {
                "data": "fechaDoc", 'render': function (jsonDate) {
                    var date = new Date(parseInt(jsonDate.substr(6)));
                    var month = date.getMonth() + 1;
                    return date.getDate() + "/" + month + "/" + date.getFullYear() + " " + date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds();
                }
            },
            {
                "data": "usuarioActualizacion", "autoWidth": true, 'render': function (vendedor) {
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
            { "data": "tipoDocumento", "autoWidth": true },
            { "data": "numeroVenta", "autoWidth": true },
            // { "data": "CustomAlmacenPartida.descripcionAlmacen", "autoWidth": true },
            {
                "render": function (data, type, full, meta) { return full.documentoventaAbarrotesDet[0].CustomAlmacenPartida.descripcionAlmacen; }
            },
            {
                "render": function (data, type, full, meta) {
                    return full.documentoventaAbarrotesDet[0].CustomAlmacenLlegada.descripcionAlmacen;
                }
            },
            {
                "render": function (data, type, full, meta) {

                    return full.documentoventaAbarrotesDet.length;
                }
            },
            //{ "data": "documentoventaAbarrotesDet.Count", "autoWidth": true },
            {
                "render": function (data, type, full, meta) {

                    return "Entregado";
                }
            },
            {
                //"render": function (data, type, full, meta) { return '<a class="btn btn-info" href="/Order/Edit/' + full.idDocumento + '"><span class="glyphicon glyphicon-search"></span> Ver</a>'; }
                "render": function (data, type, full, meta) { return '<a id="btviewTransfer" class="btn btn-info" href="javascript:void(0);" data-id="+' + full.idDocumento + '"><span class="glyphicon glyphicon-search"></span> Ver</a>'; }
            },
            {
                data: null, render: function (data, type, row) {
                    //  return "<a href='#' class='btn btn-danger' onclick=DeleteData('" + row.idDocumento + "'); >Delete</a>";
                    //return "<a href='#' class='editor_remove'  >Delete</a>";
                    return '<a href="#" class="btn btn-danger" id="confirmTransfer"> <span class="glyphicon glyphicon-ok"></span> </a>';
                }
            },
        ]
    })
}
