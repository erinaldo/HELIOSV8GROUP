$(document).ready(function () {  

 

    $('#btnConsultarEntradas').click(function () {
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

        $('#dtOtrasEntradas').DataTable({
            destroy: true,
            paging: true,
            searching: true,
            responsive: true,
            language: {
                sLoadingRecords: '<span style="width:100%;"><img src="http://www.snacklocal.com/images/ajaxload.gif"></span>'
            },
            "order": [[0, 'desc']],
            "ajax": {
                "url": "/Logistics/GetOtrasEntradasPeriodo",
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
                { "data": "tipoDoc", "autoWidth": true },
                { "data": "serie", "autoWidth": true },
                { "data": "numeroDoc", "autoWidth": true },
                { "data": "NombreEntidad", "autoWidth": true },
                { "data": "NroDocEntidad", "autoWidth": true },
                { "data": "monedaDoc", "autoWidth": true },
                {
                    "data": "importeTotal", className: 'dt-body-right', render: $.fn.dataTable.render.number(',', '.', 2)
                    //"data": "ImporteNacional", className: 'dt-body-right', render: function (data, type, row) {
                    //    return $.fn.dataTable.render.number(',', '.', 2)
                    //} 


                },
                {
                    //"render": function (data, type, full, meta) { return '<a id="btviewotraentrada" class="btn btn-info" href="#' + full.idDocumento + '" data-id="+' + full.idDocumento + '"><span class="glyphicon glyphicon-search"></span> Ver</a>'; }
                    "render": function (data, type, full, meta) { return '<a id="btviewotraentrada" class="btn btn-info" href="javascript:void(0);" data-id="+' + full.idDocumento + '"><span class="glyphicon glyphicon-search"></span> Ver</a>'; }
                },
                {
                    data: null, render: function (data, type, row) {
                        //  return "<a href='#' class='btn btn-danger' onclick=DeleteData('" + row.idDocumento + "'); >Delete</a>";
                        //return "<a href='#' class='editor_remove'  >Delete</a>";
                        return '<a href="#" class="btn btn-danger" id=deleteEntrada> <span class="glyphicon glyphicon-trash"></span> </a>';
                    }
                },
            ]
        })           

        //    $("#loaderDiv").hide();
    });

    $('#dtOtrasEntradas tbody').on('click', 'tr td #btviewotraentrada', function () {
        var $row = $(this).closest('tr');
        var ID = $row.find('td:eq(0)').text();
        //var inforExtra = $row.find('#Colinfo').val();
        //var cantidad = parseFloat($row.find('#quantity').val());
        //alert(ID);

        var url = "/Logistics/ViewWarehouse/" + ID;   
         
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

    $('#dtOtrasEntradas tbody').on('click', 'tr td #deleteEntrada', function () {
        var el = this;
        var $row = $(this).closest('tr');

        //var ID = $row.find('td:eq(1)').html();
        //var ID2 = $row.find('td:eq(0)').attr('href');
        var ID = $row.find('td:eq(0)').text();


        sweetAlert({
            title: "¿Estás seguro?",
            text: "¿Estás seguro de que deseas eliminar esta operación?",
            type: "warning",
            showCancelButton: true,
            closeOnConfirm: false,
            confirmButtonText: "Sí, bórralo!",
            confirmButtonColor: "#ec6c62"
        },
            function () {
                $.ajax({
                    url: "/Logistics/AnularEntrada",
                    data:
                    {
                        "idDocumento": parseInt(ID)
                    },
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
                                text: "Su operación fue eliminada exitosamente!",
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


    //Grabar DocumentoCompra
    $('#btSaveTransfer').click(function (e) {
        var statusPago = "";
        //  e.preventDefault();
        var valorEnTransito = $("#toggle-event").prop('checked');
        if (valorEnTransito == true) {
            valorEnTransito = false;
        } else {
            valorEnTransito = true;
        }

        if ($(this).attr('disabled') == 'disabled') {
            e.preventDefault();

            return;
        }

        if ($('#TextComprador').val().trim() == '') {

            //alert('Ingrese un comprador');
            sweetAlert("Ingrese un comprador!!");
            return;
        }

        if ($('#ComboAlmacen').val() == '-1') {
            sweetAlert("Seleccionar un almacén de origen!");
            return;
        }

        if ($('#ComboAlmacenDestino').val() == '-1') {
            sweetAlert("Seleccionar un almacén de destino!");
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

        var Valid = ValidarDetalleTransfer();

        if (Valid) {

            if (ClienteSelected == null) {
                sweetAlert("Ingrese un comprador!!");
                return;
            }

            var prop_Comprador = ClienteSelected.nombreCompleto;
            $("#btSaveTransfer").attr('disabled', 'disabled');

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

                             

                                let total_BI1 = 0;
                                let total_BI2 = 0;
                                let total_IVA = 0;
                                let total_PEDIDO = 0;

                                $('#dtBasquetTransfer tbody tr').each(function () {
                                    var $row = $(this).closest('tr');
                                    var ID = $row.find('td:eq(0)').text();

                                    var Item = list.filter(p => p.codigodetalle == ID);

                                    var o = Object(Item);
                                    var content = JSON.stringify(o);
                                    var obj = JSON.parse(content);
                                    //var nombre = obj[0].descripcionItem;

                                    let colTotal = 0;// parseFloat($row.find('#totalItemSale').val());
                                    let colCantidad = parseFloat($row.find('#quantity').val());

                                    let colBI = 0;
                                    let colIGV = 0;

                                    switch (obj[0].origenProducto) {

                                        case '1':
                                            colBI = 0;// redondearExp(colTotal / 1.18, 2, true);
                                            colIGV = 0;// Number(parseFloat(colTotal - colBI).toFixed(2));
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

                                    //var ListaCatalogos = objUC[0].detalleitemequivalencia_catalogos;
                                    //var IDunidadCatalogo = $row.find('#comboCatalogo').val()
                                    //var objCatalogo = ListaCatalogos.filter(c => c.idCatalogo == IDunidadCatalogo);

                                    //var oCAT = Object(objCatalogo);
                                    //var contentCAT = JSON.stringify(oCAT);
                                    //var objCAT = JSON.parse(contentCAT);


                                    let precioUnitarioVenta = $row.find('#puItem').text();

                                    statusPago = "PN";

                                    var AlmacenOrigen = $('#ComboAlmacen').val()
                                    var AlmacenDestino = $('#ComboAlmacenDestino').val()

                                    var dataitem = {
                                        idDocumento: 0,
                                        secuencia: 0,
                                        idAlmacenOrigen: AlmacenOrigen,
                                        idalmacenDestino: AlmacenDestino,
                                        categoria: AlmacenDestino,
                                        AfectoInventario: true,
                                        estadoMovimiento: 'True',
                                        CustomProducto: obj[0],
                                        CustomEquivalencia: objUC[0],                                        
                                        equivalencia_id: objUC[0].equivalencia_id,
                                        catalogo_id: 0,                                    
                                        establecimientoOrigen: 0,
                                        idItem: obj[0].codigodetalle,
                                        nombreItem: obj[0].descripcionItem,
                                        tipoExistencia: obj[0].tipoExistencia,
                                        destino: obj[0].origenProducto,
                                        unidad2: obj[0].unidad1,
                                        unidad1: obj[0].unidad1,
                                        monto1: parseFloat(colCantidad),
                                        monto2: 0,
                                        PrecioUnitarioVentaMN: 0,
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
                                        entregado: 1,
                                        estadoPago: statusPago,
                                        estadoEntrega: "PN",
                                        bonificacion: 'False',
                                        montoIcbper: 0,
                                        montoIcbperUS: 0,
                                        tasaIcbper: 0,
                                        tipoVenta: colDeliverStatus,
                                        detalleAdicional: '',
                                        usuarioModificacion: data.IDUsuario                                        
                                    }
                                    listDetailOrder.push(dataitem);
                                });


                                //  var now = new Date();
                                $("#loaderDiv").show();

                                var Tipocomprobante = $("#ComboComprobante").val();
                                var commentario = $("#comment").val();
                                var dataVenta = {
                                    tipoOperacion: '11',
                                    codigoLibro: '8',
                                    idEmpresa: '20602665063',
                                    idEstablecimiento: 3,
                                    tipoDocumento: Tipocomprobante,                                                                        
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
                                    glosa: commentario,
                                    terminos: 'TRANSFERENCIA',
                                    tipoVenta: 'TEA',
                                    estadoEntrega: '1',
                                    usuarioActualizacion: data.IDUsuario,                                    
                                    icbper: 0,
                                    icbperus: 0,
                                    documentoventaAbarrotesDet: listDetailOrder
                                }


                                // Registrar Documentos de pago **************************************************************************
                                                          

                                var datadoc = {
                                    AfectaInventario: Boolean(valorEnTransito),
                                    idDocumento: 0,
                                    idEmpresa: '20602665063',
                                    idCentroCosto: 3,
                                    idProyecto: 0,
                                    tipoDoc: Tipocomprobante,                                    
                                    moneda: '1',
                                    idEntidad: ClienteSelected.idEntidad,
                                    entidad: ClienteSelected.nombreCompleto,
                                    tipoEntidad: 'TR',
                                    nrodocEntidad: ClienteSelected.nrodoc,
                                    nroDoc: '0',
                                    idOrden: 0,
                                    tipoOperacion: '11',
                                    CustomNumero: vendedor,
                                    ventaConLotes: false,
                                    usuarioActualizacion: data.IDUsuario,                                    
                                    documentoventaAbarrotes: dataVenta                                    
                                }

                                $.ajax({
                                    contentType: 'application/json; charset=utf-8',
                                    dataType: 'json',
                                    type: 'POST',
                                    url: '/Logistics/SaveTransfer',
                                    data: JSON.stringify({ order: datadoc }),
                                    success: function (datadoc) {
                                        if (datadoc.status) {
                                            toastr.success('Transferencia registrada!')
                                            // alert('Pedido Registrado');
                                            //here we will clear the form
                                            $("#loaderDiv").hide();
                                            $("#dtBasquetTransfer tbody tr").remove();
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

                                            $("#btSaveTransfer").removeAttr('disabled');
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
                                            $("#btSaveTransfer").removeAttr('disabled');
                                            alert('Error');
                                            $("#loaderDiv").hide();
                                        }
                                        //   $('#btSaveOrderSale').text('Save');
                                    },
                                    error: function (request, status, error) {
                                        $("#btSaveTransfer").removeAttr('disabled');
                                        valor = request.responseText.match(/<title>([\s\S]*)<\/title>/)[1];//Solo para reciuperar caracteres                                    
                                        toastr.error(valor);
                                        $('#submitVentaDirecta').text('Save');
                                        $("#loaderDiv").hide();
                                        console.log(error);
                                    }
                                    //error: function (error) {
                                    //    $("#btSaveTransfer").removeAttr('disabled');
                                    //    // console.log(error);
                                    //    toastr.error('Error al grabar pedido!')
                                    //    $("#loaderDiv").hide();
                                    //    console.log(error);
                                    //    //    $('#btSaveOrderSale').text('Save');
                                    //}
                                });

                            },
                            error: function (error) {
                                $("#btSaveTransfer").removeAttr('disabled');
                                //alert('No se encontro un vendedor con el código ingresado!');
                                toastr.error('No se encontro un usuario con el código ingresado!')
                                console.log(error);
                                $("#loaderDiv").hide();
                            }
                        });
                    },
                    Cancel: function () {
                        $("#btSaveTransfer").removeAttr('disabled');
                        Jquery102(this).dialog("close");
                    }
                }
            });
        } else {
            //alert('Verificar el detalle del pedido!');
            sweetAlert('Verificar el detalle de la operación!');
            //toastr.error('ErrorVerificar el detalle del pedido!');
        }
    });


    $('#dtBasquetTransfer tbody').on('click', 'tr td #btnMinusItemBasquet', function () {
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
        SumBasquetPurchase();
        //MappingPagosVentaDirecta();

    });

    $('#dtBasquetTransfer tbody').on('click', 'tr td #btnDeleteItemBasquet', function () {
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
            SumBasquetPurchase();
            //MappingPagosVentaDirecta();
            //$(this).parents('tr').remove();
        });
    });

    $('#dtBasquetTransfer tbody').on('click', 'tr td #btnPlusItemBasquet', function () {
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
        SumBasquetPurchase();
        //MappingPagosVentaDirecta();
    });

    $('#dtBasquetTransfer tbody').on('change', 'tr td #comboUnidadComercial', function () {

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


        renderCatalogosTablePurchase($row.find('#comboCatalogo'), objeq[0].detalleitemequivalencia_catalogos, r);


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

    $('#dtBasquetTransfer tbody').on('change', 'tr td #comboCatalogo', function () {

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
        SumBasquetPurchase();
        //MappingPagosVentaDirecta();
    });

    $('#dtBasquetTransfer tbody').on('keyup mouseup', 'tr td #totalItemSale', function (e) {

        //var $row = $(this).closest('tr');
        //let precUnit = 0;
        //let cantidad = $row.find('#quantity').val();
        //let total = $row.find('#totalItemSale').val();
        //precUnit = parseFloat(total / cantidad).toFixed(2);
        //$row.find('#puItem').text(precUnit);
        //SumBasquetPurchase();
        //MappingPagosVentaDirecta();
    });

    $('#dtBasquetTransfer tbody').on('keyup mouseup', 'tr td #quantity', function (e) {

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
        //var ListaCatalogos = objeq[0].detalleitemequivalencia_catalogos;
        //var catalogoSel = ListaCatalogos.filter(c => c.idCatalogo == IDunidadCatalogo);
        //var ocat = Object(catalogoSel);
        //var contentcat = JSON.stringify(ocat);
        //var objcat = JSON.parse(contentcat);


        //Calculo        
        var totalPurchase = parseFloat($row.find('#totalItemSale').val());
        // var precioUnitario2 = parseFloat($row.find('#puItem').text());

        var precUnitario = parseFloat(totalPurchase / suma).toFixed(2);
        $row.find('#puItem').text(precUnitario);

        // $row.find('#totalItemSale').val(total);
        SumBasquetPurchase();
        //MappingPagosVentaDirecta();
    });

    $('#dtProductsTransfer tbody').on('click', 'tr td #btnAdditem', function () {
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
        addItemToBasketPurchase(obj);
        //$(el).closest('tr').fadeIn(800, function () {
        //    addItemToBasket(obj);
        //    $(el).closest('tr').css('background', 'white');
        //});


        //   addItemToBasket(obj);


        ////document.getElementById("dtPedidosPendientes").innerHTML = "";
        //$("#dtPedidosPendientes tbody tr").remove();
        //LoadPedidosTable();
    });

    $("#TextFilterTransfer").on('keyup', function (e) {
        if (e.keyCode === 13) {
            // Do something
            $("#dtProductsTransfer tbody tr").remove();
            var filter = $("#TextFilterTransfer").val();
            var idalmacen = $("#ComboAlmacen").val();
            //GetProductSelText(filter);
            RenderProductTableDBTransfer(filter, idalmacen);
        }
    });

    $("#ComboAlmacen").on("change", function () {      

        var idalmacen = $(this).val();

        var data = almacenList.filter(person => person.idAlmacen != idalmacen);
        $('#ComboAlmacenDestino').empty();
        $("#dtProductsTransfer tbody tr").remove();
        //$('#ComboAlmacenDestino').append('<option value=-1>' + '-Selec almacén-' + '</option > ');

        for (var i = 0; i < data.length; i++) {
          //  $('#ComboAlmacenDestino').append('<option value=' + almacenList[i].idAlmacen + '>' + almacenList[i].descripcionAlmacen + '</option > ');
      //      $("#ComboAlmacenDestino").append("<option>" + almacenList[i].descripcionAlmacen + "</option>")
            $("#ComboAlmacenDestino").append($("<option></option>").val(data[i].idAlmacen).html(data[i].descripcionAlmacen)); 
        }
    });

    $('#btnFilterProductTransfer').click(function () {
        $("#dtProductsTransfer tbody tr").remove();
        var filter = $("#TextFilterTransfer").val();
        var idalmacen = $("#ComboAlmacen").val();
        //GetProductSelText(filter);
        RenderProductTableDBTransfer(filter, idalmacen);
    });

    //$("#ComboAlmacenDestino").on("change", function () {

    //    var idalmacen = $(this).val();

    //    var data = almacenList.filter(person => person.idAlmacen != idalmacen);
    //    $('#ComboAlmacen').empty();
    //    $('#ComboAlmacen').append('<option value=-1>' + '-Selec almacén-' + '</option > ');

    //    for (var i = 0; i < data.length; i++) {
    //        //  $('#ComboAlmacenDestino').append('<option value=' + almacenList[i].idAlmacen + '>' + almacenList[i].descripcionAlmacen + '</option > ');
    //        //      $("#ComboAlmacenDestino").append("<option>" + almacenList[i].descripcionAlmacen + "</option>")
    //        $("#ComboAlmacen").append($("<option></option>").val(data[i].idAlmacen).html(data[i].descripcionAlmacen));
    //    }
    //});
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
    ColumnTotal = "<td><input id='totalItemSale' class='roundedcorner' style='width:62px;' type='text' value='0' disabled></td>";
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
    $.getJSON('/Logistics/GetProductSelAlmacenText/', { Text: Text,  idalmacen: almacen }, 
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

                var cantidadStockGeneral = 0;
                if (json[i].totalesAlmacen.length > 0) {

                    var aggregate = json[i].totalesAlmacen.reduce(function (item1, item2) {
                        return { name: '', cantidad: item1.cantidad + item2.cantidad };
                    });

                    columnPrice = "<td>" + labelRender + "st. " + parseFloat(aggregate.cantidad).toFixed(2) + "</span>" + "</td>";
                    cantidadStockGeneral = aggregate.cantidad;

                } else {
                    columnPrice = "<td>" + labelRender + "st. " + "0.00" + "</span>" + "</td>";
                }

                
                

              //  alert(aggregate.cantidad);

             //   columnPrice = "<td>" + labelRender + "st. " + parseFloat(aggregate.cantidad).toFixed(2) + "</span>" + "</td>";

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

                if (cantidadStockGeneral > 0) {
                    tr.append(ColumnID);
                    tr.append(columnName);
                    tr.append(columnPrice);
                    tr.append(columnBtn);
                    //<span class='label label-warning'>Pending</span>
                    $('#dtProductsTransfer').append(tr);
                }

                
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

function FillStorePartida(data, cboName) {
    for (var i = 0; i < data.length; i++) {
        $(cboName).append('<option value=' + data[i].idAlmacen + '>' + data[i].descripcionAlmacen + '</option > ');
    }
}

function FillStore(idalmacen, cboName) {
    
    var data = almacenList.filter(person => person.idAlmacen != idalmacen);
    $('#ComboAlmacenDestino').empty();
    for (var i = 0; i < data.length; i++) {
        $('#ComboAlmacenDestino').append('<option value=' + data[i].idAlmacen + '>' + data[i].descripcionAlmacen + '</option > ');
    }
}
