//var UsuariosSystem = []

function DeleteData(ID) {
    //render product
    alert(ID);
    $("datatable tbody").parents('tr').remove();
    var target_row = $(this).closest('tr').get(0);

    alert('Delete this id ' + target_row);

    //$.ajax({
    //    type: "GET",
    //    url: "/Order/EliminarPedido",
    //    data: { 'idDocumento': parseInt(ID)},
    //    success: function (data) {
    //        //render products to appropriate dropdown
    //        alert('Pedido Eliminado');
    //    },
    //    error: function (error) {
    //        console.log(error);
    //    }
    //});
}

function MappingPagos() {
    $('#dtPagos tbody tr').each(function () {
        var $row = $(this).closest('tr');
        //var ID = $row.find('td:eq(0)').text();        
        var ImporteAbonado = $row.find('#montoAbonado').val();
        var ID_Forma = $row.find('#formapg_id').val();
        var Forma = $row.find('#formapago').val();
        var idEntidad = $row.find('#idcaja').val();
        var Entidad = $row.find('#caja').val();

        var moneda = $row.find('td:eq(3)').text();  

        if (ID_Forma == '109' && moneda == "NUEVO SOL") {
            $row.find('#montoAbonado').val(PedidoSeleccionado.ImporteNacional);
        } else{
            $row.find('#montoAbonado').val(0);
        }

    });
}

function MappingPagosVentaDirecta() {
    $('#dtPagos tbody tr').each(function () {
        var $row = $(this).closest('tr');
        //var ID = $row.find('td:eq(0)').text();        
        var ImporteAbonado = $row.find('#montoAbonado').val();
        var ID_Forma = $row.find('#formapg_id').val();
        var Forma = $row.find('#formapago').val();
        var idEntidad = $row.find('#idcaja').val();
        var Entidad = $row.find('#caja').val();

        if (ID_Forma == '109') {
            //$row.find('#montoAbonado').val($("#total").val());
            var montoTotal = document.getElementById('spanTotalventa').innerHTML.replace("S/ ", "");
            $row.find('#montoAbonado').val(montoTotal);
        }

    });
}

function RiniciarPagos() {
    $('#dtPagos tbody tr').each(function () {
        var $row = $(this).closest('tr');
        //var ID = $row.find('td:eq(0)').text();        
        var ImporteAbonado = $row.find('#montoAbonado').val();
        var ID_Forma = $row.find('#formapg_id').val();
        var Forma = $row.find('#formapago').val();
        var idEntidad = $row.find('#idcaja').val();
        var Entidad = $row.find('#caja').val();
             
            $row.find('#montoAbonado').val(0);    

    });
}

$(document).ready(function () { 
    $("#btCobrarPedido").click(function () {     
     
        var listCaja = [];
        var ID_CAJA_USUARIO = $("#ComboCajasActivas").val();

        
        //if (typeof PedidoSeleccionado == 'undefined') {
        //    alert("Debe seleccionar un pedido!");
        //    return;
        //}

        

        if (typeof PedidoSeleccionado == 'undefined') {
            alert("Debe seleccionar un pedido!");
            return;
        }        

        if (PedidoSeleccionado === null) {
            alert("Debe seleccionar un pedido!");
            return;
        }        

       
     //   var cliente = $('#nrodoc').val();
        //Mapeando documento caja: pagos     


      //  var array = [];
        //var rows = $("#dtPagos tbody tr");

        //$.each(rows, function (index, row) {
        //    var columns = $(row).find("td");

        //    array[index] = {};
        //    array[index].from = columns[0].innerHTML;
        //    array[index].type = columns[1].innerHTML;
        //    array[index].amount = columns[2].textContent;

        //    if (index > 0) {
        //        array[index - 1].to = columns[0].innerHTML;
        //    }
        //});

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
                periodo: PedidoSeleccionado.fechaPeriodo,
                idEmpresa: PedidoSeleccionado.idEmpresa,
                idEstablecimiento: PedidoSeleccionado.idEstablecimiento,
                fechaProceso: PedidoSeleccionado.fechaDoc,
                fechaCobro: PedidoSeleccionado.fechaDoc,
                tipoMovimiento: 'DC',
                codigoProveedor: PedidoSeleccionado.idCliente,
                IdProveedor: PedidoSeleccionado.idCliente,
                idPersonal: PedidoSeleccionado.idCliente,
                TipoDocumentoPago: '9903',
                codigoLibro: '1',
                tipoDocPago: PedidoSeleccionado.tipoDocumento,
                formapago: ID_Forma,
                formaPagoName: Forma,
                NumeroDocumento: '-',
                numeroOperacion: '',
                movimientoCaja: 'VELC',
                montoSoles: ImporteAbonado,
                moneda: PedidoSeleccionado.moneda,
                tipoCambio: PedidoSeleccionado.tipoCambio,
                montoUsd: 0,
                estado: '1',
                glosa: 'Venta cobrada!',
                entregado: 'SI',
                idCajaUsuario: ID_CAJA_USUARIO,
                entidadFinanciera: idEntidad,
                NombreEntidad: Entidad,
                usuarioModificacion: PedidoSeleccionado.usuarioActualizacion
            }
            listCaja.push(dataCaja);
        })      
                                 
        var listPedidodetail = [];
        for (var det of PedidoSeleccionado.documentoventaAbarrotesDet) 
        {
            var orderItem = {
                idDocumento: det.idDocumento,
                secuencia: det.secuencia,
                CustomProducto: det.CustomProducto,
                CustomEquivalencia: det.CustomEquivalencia,
                CustomCatalogo: det.CustomCatalogo,
                equivalencia_id: det.equivalencia_id,
                catalogo_id: det.catalogo_id,
                idAlmacenOrigen: det.idAlmacenOrigen,
                establecimientoOrigen: det.establecimientoOrigen,
                idItem: det.idItem,
                nombreItem: det.nombreItem,
                tipoExistencia: det.tipoExistencia,
                destino: det.destino,
                unidad2: det.unidad2,
                unidad1: det.unidad1,
                monto1: det.monto1,
                monto2: det.monto2,
                PrecioUnitarioVentaMN: det.precioUnitario,
                precioUnitario: det.precioUnitario,
                precioUnitarioUS: det.precioUnitarioUS,
                importeMN: det.importeMN,
                importeME: 0,
                importeMNK: 0,
                importeMEK: 0,
                descuentoMN: 0,
                descuentoME: 0,
                montokardex: det.montokardex,
                montoIsc: 0,
                montoIgv: det.montoIgv,
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
                estadoPago: 'DC',
                estadoEntrega: "PN",
                bonificacion: 'False',
                montoIcbper: 0,
                montoIcbperUS: 0,
                tasaIcbper: 0,
                tipoVenta: det.tipoVenta,
                detalleAdicional: '',
                usuarioModificacion: det.usuarioModificacion,
                fechaModificacion: det.fechaModificacion
            }
            listPedidodetail.push(orderItem);
        }      

       // var dataventa = PedidoSeleccionado;







        var Tipocomprobante = $("#orderNo").val();                      

      //  sdfsdf_11'¿'
        dataventa = {
            codigoLibro: PedidoSeleccionado.codigoLibro,
            idEmpresa: PedidoSeleccionado.idEmpresa,
            idEstablecimiento: PedidoSeleccionado.idEstablecimiento,
            fechaLaboral: PedidoSeleccionado.fechaLaboral,
            fechaDoc: PedidoSeleccionado.fechaDoc,           
            fechaPeriodo: PedidoSeleccionado.fechaPeriodo,
            tipoOperacion: '01',
            tipoDocumento: Tipocomprobante,
            idCliente: PedidoSeleccionado.idCliente,
            nombrePedido: $('#cliente').val(),
            moneda: PedidoSeleccionado.moneda,
            tasaIgv: PedidoSeleccionado.tasaIgv,
            tipoCambio: PedidoSeleccionado.tipoCambio,
            bi01: PedidoSeleccionado.bi01,
            bi02: PedidoSeleccionado.bi02,
            isc01: 0,
            isc02: 0,
            igv01: PedidoSeleccionado.igv01,
            igv02: 0,
            otc01: 0,
            otc02: 0,
            bi01us: PedidoSeleccionado.bi01us,
            bi02us: PedidoSeleccionado.bi02us,
            isc01us: 0,
            isc02us: 0,
            igv01us: PedidoSeleccionado.igv01us,
            igv02us: 0,
            otc01us: 0,
            otc02us: 0,
            importeCostoMN: 0,
            terminos: "CONTADO",
            ImporteNacional: PedidoSeleccionado.ImporteNacional,
            ImporteExtranjero: PedidoSeleccionado.ImporteExtranjero,
            tipoVenta: 'VELC',
            estadoCobro: 'DC',
            glosa: "Venta de mercadería",
            sustentado: "S",
            idPadre: PedidoSeleccionado.idDocumento,
            estadoEntrega: "1",                      
            usuarioActualizacion: PedidoSeleccionado.usuarioActualizacion,
            documentoventaAbarrotesDet: listPedidodetail//PedidoSeleccionado.documentoventaAbarrotesDet
        }

        var data = {
            TipoEnvio: 'PREVENTA',
            idEmpresa: PedidoSeleccionado.idEmpresa,
            idCentroCosto: PedidoSeleccionado.idEstablecimiento,
            idProyecto: 0,
            tipoDoc: $('#orderNo').val(),
            fechaProceso: PedidoSeleccionado.fechaDoc,
            moneda: '1',
            idEntidad: $('#cliente_id').val(),            
            entidad: $('#cliente').val(),
            tipoEntidad: 'CL',
            nrodocEntidad: $('#nrodoc').val(),
            nroDoc: '0',
            idOrden: 0,
            tipoOperacion: "01",
            usuarioActualizacion: PedidoSeleccionado.usuarioActualizacion,
            documentoventaAbarrotes: dataventa,
            ListaCustomDocumentoCaja: listCaja
        }

        //INSERTAR DOCUMENTO VENTA CONFIRMADA
        $.ajax({
            type: 'POST',
            url: '/Order/saveVentaCaja',
            data: JSON.stringify(data),
            contentType: 'application/json',
            success: function (data) {
                if (data.status) {
                    toastr.success('Venta registrada con exito!');       
                    $("#dtPedidosPendientes tbody tr").remove();
                    LoadPedidosTable();
                    PedidoSeleccionado = null;

                    $("#cliente").val('');
                    $('#nrodoc').val('');
                    $('#total').val(0);
                    document.getElementById('spanTotalventa').innerHTML = "0.00";
                    $("input[id=cliente_id]").val(0);
                    RiniciarPagos();
                }
                else {
                    alert('Error');
                }
            //    $('#submit').text('Save');
            },
            error: function (request, status, error) {
                valor = request.responseText.match(/<title>([\s\S]*)<\/title>/)[1];//Solo para reciuperar caracteres
             //   valor = request.responseText.match(/<title>(\d*)<\/title>/)[1] --para recuperar numeros

               
                toastr.error(valor);
                //toastr.error(temporal.textContent);
                //var texto = $(request.responseText).text();
              //  $('#submit').text('Save');
            }
        });
     

    });       

    $('#dtPedidosPendientes tbody').on('click', 'tr td #Deleteventa', function () {

        var $row = $(this).closest('tr');
        var ID = $row.find('td:eq(0)').text();

        var answer = window.confirm("Desea eliminar el pedido seleccionado?")
        if (answer) {
            //some code
            $.ajax({
                type: "POST",
                url: "/Order/EliminarPedido",
                data: { 'idDocumento': parseInt(ID) },
                success: function (data) {
                    typeof PedidoSeleccionado;
                    toastr.success('Pedido eliminado');

                    $("#dtPedidosPendientes tbody tr").remove();
                    LoadPedidosTable();

                    $("#cliente").val('');
                    $('#nrodoc').val('');
                    $('#total').val(0);
                    document.getElementById('spanTotalventa').innerHTML = "0.00";
                    $("input[id=cliente_id]").val(0);
                    MappingPagos();
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

    $('#dtPedidosPendientes tbody').on('click', 'tr td #Confirmarventa', function () {

        var $row = $(this).closest('tr');     
        var ID = $row.find('td:eq(0)').text();          

        $.ajax({
            type: "GET",
            url: "/Order/GetVentaID",
            data: { 'id': parseInt(ID) },
            success: function (data) {                
                PedidoSeleccionado = data;
                //alert(PedidoSeleccionado.ImporteNacional);
                $("#cliente").val('');
                $('#cliente').val(PedidoSeleccionado.CustomEntidad.nombreCompleto);
                $('#nrodoc').val(PedidoSeleccionado.CustomEntidad.nrodoc);                
                $('#total').val(parseFloat(PedidoSeleccionado.ImporteNacional).toFixed(2));
                document.getElementById('spanTotalventa').innerHTML = parseFloat(PedidoSeleccionado.ImporteNacional).toFixed(2); 
                $("input[id=cliente_id]").val(PedidoSeleccionado.CustomEntidad.idEntidad);
                MappingPagos();
            },
            error: function (error) {
                console.log(error);
            }
        });     

    });

    $('#dtDetalleVenta tbody').on('click', 'tr td #myCheckRow', function () {

        var $row = $(this).closest('tr');
        var IDSec = $row.find('td:eq(1)').text();
        var ID2 = $row.find('td:eq(7)').text();
              
    //    var qq = $row.find('#myCheckRow').text();

        //if ($(this).checked == true) {
        //    alert("true");
        //} else {
        //    alert("false");
        //}
                           
        var checke = $row.find('input[name=CheckRow]:checked').val();
        var invent;
        if (checke == "on") {
            invent = true;
        } else {
            invent = false;
        }
        //alert(invent);


        var Item = PedidoSeleccionado.documentoventaAbarrotesDet.filter(p => p.secuencia == IDSec);

      //  aler(Item.AfectoInventario);

        var o = Object(Item);
        var content = JSON.stringify(o);
        var obj = JSON.parse(content);
        var nombre = obj[0].AfectoInventario;

        obj[0].AfectoInventario = invent;
        
        //PedidoSeleccionado.documentoventaAbarrotesDet["AfectoInventario"] = invent;


        //Find index of specific object using findIndex method.    
        var objIndex = PedidoSeleccionado.documentoventaAbarrotesDet.findIndex((obj => obj.secuencia == IDSec));

        //Log object to Console.
        //console.log("Before update: ", PedidoSeleccionado.documentoventaAbarrotesDet[objIndex]);

        //Update object's name property.
        PedidoSeleccionado.documentoventaAbarrotesDet[objIndex].AfectoInventario = invent;

        //Log object to console again.
        //console.log("After update: ", PedidoSeleccionado.documentoventaAbarrotesDet[objIndex]);

        //let foundIndex = PedidoSeleccionado.documentoventaAbarrotesDet(element => element.secuencia === IDSec);
        //PedidoSeleccionado.documentoventaAbarrotesDet.splice(foundIndex, 1, obj[0]);

        //var ppasas = $('input[name=CheckRow]:checked').val();

        //$.ajax({
        //    type: "GET",
        //    url: "/Order/GetVentaID",
        //    data: { 'id': parseInt(ID) },
        //    success: function (data) {
        //        PedidoSeleccionado = data;
        //        //alert(PedidoSeleccionado.ImporteNacional);
        //        $("#cliente").val('');
        //        $('#cliente').val(PedidoSeleccionado.CustomEntidad.nombreCompleto);
        //        $('#nrodoc').val(PedidoSeleccionado.CustomEntidad.nrodoc);
        //        $('#total').val(parseFloat(PedidoSeleccionado.ImporteNacional).toFixed(2));
        //        document.getElementById('spanTotalventa').innerHTML = parseFloat(PedidoSeleccionado.ImporteNacional).toFixed(2);
        //        $("input[id=cliente_id]").val(PedidoSeleccionado.CustomEntidad.idEntidad);
        //        MappingPagos();
        //    },
        //    error: function (error) {
        //        console.log(error);
        //    }
        //});

    });

    $("#btBuscarOrden").click(function () {
        //alert("Buscar orden");
        //document.getElementById("dtPedidosPendientes").innerHTML = "";
        $("#dtPedidosPendientes tbody tr").remove();
        LoadPedidosTable();
    });

    $('#BtUpdateOrders').click(function () {
        alert('Actualizar Pedidos');
        $.ajax({
            type: "GET",
            url: "/Order/CobroPedidos"         
        });
    });

    $("#tablaCobros tr").click(function () {
        $(this).addClass('selected').siblings().removeClass('selected');
        var value = $(this).find('td:first').html();
        alert(value);
        var url = "/Order/PagarVenta?id=" + 6; ; 
        window.location.href = url;
    });

    $("#BtVerDetalleVenta").click(function () {        

        if (typeof PedidoSeleccionado == 'undefined') {
            alert("Debe seleccionar un pedido!");
            return;
        }

        if (PedidoSeleccionado === null) {
            alert("Debe seleccionar un pedido!");
            return;
        }        

        $("#dtDetalleVenta tbody tr").remove();
       // GetDetalleVentaInfo(PedidoSeleccionado.idDocumento);
        GetDetalleVentaInfoV2();
    });
    
    Jquery102('#datatable tbody').on('click', 'tr td #del', function () {

        var $row = $(this).closest('tr');

        //var ID = $row.find('td:eq(1)').html();
        //var ID2 = $row.find('td:eq(0)').attr('href');
        var ID = $row.find('td:eq(0)').text();
        var con = confirm("Desea eliminar el pedido?");
        if (con) {
            Jquery102("#loaderDiv").show();


            $.ajax({
                type: "POST",
                url: "/Order/EliminarPedido",
                data: { 'idDocumento': parseInt(ID) },
                success: function (data) {
                    if (data.status) {
                        //   alert('Successfully saved');                     
                        alert('Pedido Eliminado');
                    }
                    //render products to appropriate dropdown

                },
                error: function (error) {
                    console.log(error);
                    $("#loaderDiv").hide();
                }
            });
            Jquery102(this).parents('tr').remove();
            Jquery102("#loaderDiv").hide();
        }
        else {
        }
        //var mydata = (tableObj.row(row).data());
        //alert(mydata["idDocumento"]);



    });

    $('#datatableVentas tbody').on('click', 'tr td #deleteVenta', function () {
        var el = this;
        var $row = $(this).closest('tr');

        //var ID = $row.find('td:eq(1)').html();
        //var ID2 = $row.find('td:eq(0)').attr('href');
        var ID = $row.find('td:eq(0)').text();


        sweetAlert({
            title: "¿Estás seguro?",
            text: "¿Estás seguro de que deseas eliminar esta venta?",
            type: "warning",
            showCancelButton: true,
            closeOnConfirm: false,
            confirmButtonText: "Sí, bórralo!",
            confirmButtonColor: "#ec6c62"
        },
            function () {
                $.ajax({
                    url: "/Order/AnularVenta",
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
        //$(this).parents('tr').remove();
       

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

    //$('#datatable tbody').on('click', 'img.icon-delete', function () {
    //    table
    //        .row($(this).parents('tr'))
    //        .remove()
    //        .draw();
    //});

    // Delete a record
    //$('#datatable').on('click', 'a.editor_remove', function (e) {
    //    e.preventDefault();

    //    editor.remove($(this).closest('tr'), {
    //        title: 'Delete record',
    //        message: 'Are you sure you wish to remove this record?',
    //        buttons: 'Delete'
    //    });
    //});

    //$('#datatable tbody').on('click', 'a.delete', function () {
    //    table
    //        .row($(this).parents('tr'))
    //        .remove()
    //        .draw();
    //});

    //$('#datatable tbody').on('click', 'tr', function () {
    //    var row = $('#datatable tbody').row($(this).parents('tr'));
    //    var rowNode = row.node();
    //    row.remove();
    //});

    //$('#datatable tbody').on('click', 'tr', function () {
    //    var myTable = $('#myTable').DataTable();
    //    alert("dd");
    //    myTable.row(this)
    //    $('#datatable').DataTable().row(this).de;
    //    $('#datatable').DataTable().row($(this).parents('tr')).remove();

    ////        .remove();
    //});

    //$('#datatable tbody').on('click', 'tr', function () {
    //    $('#datatable').DataTable()
    //        .row($(this).parents('tr'))
    //        .remove()
    //        .draw();
    //});



    $('#btnConsultar').click(function () {
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

        $('#datatable').DataTable({
            destroy: true,
            paging: true,
            searching: true,
            responsive: true,
            language: {
                sLoadingRecords: '<span style="width:100%;"><img src="http://www.snacklocal.com/images/ajaxload.gif"></span>'
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
                { "data": "numeroVenta", "autoWidth": true },
                { "data": "NombreEntidad", "autoWidth": true },
                { "data": "NroDocEntidad", "autoWidth": true },
                { "data": "moneda", "autoWidth": true },
                {
                    "data": "ImporteNacional", className: 'dt-body-right', render: $.fn.dataTable.render.number(',', '.', 2)
                    //"data": "ImporteNacional", className: 'dt-body-right', render: function (data, type, row) {
                    //    return $.fn.dataTable.render.number(',', '.', 2)
                    //} 


                },
                {
                    "render": function (data, type, full, meta) { return '<a class="btn btn-info" href="/Order/Edit/' + full.idDocumento + '"><span class="glyphicon glyphicon-search"></span> Ver</a>'; }
                },
                {
                    data: null, render: function (data, type, row) {
                        //  return "<a href='#' class='btn btn-danger' onclick=DeleteData('" + row.idDocumento + "'); >Delete</a>";
                        //return "<a href='#' class='editor_remove'  >Delete</a>";
                        return '<a href="#" class="btn btn-danger" id=del> <span class="glyphicon glyphicon-trash"></span> </a>';
                    }
                },
            ]
        })

        $('#datatableVentas').DataTable({
            destroy: true,
            paging: true,
            searching: true,
            responsive: true,
            language: {
                sLoadingRecords: '<span style="width:100%;"><img src="http://www.snacklocal.com/images/ajaxload.gif"></span>'
            },
            "order": [[0, 'desc']],
            "ajax": {
                "url": "/Order/LoadVentas",
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
                { "data": "serieVenta", "autoWidth": true },
                { "data": "numeroVenta", "autoWidth": true },
                { "data": "NombreEntidad", "autoWidth": true },
                { "data": "NroDocEntidad", "autoWidth": true },
                { "data": "moneda", "autoWidth": true },
                {
                    "data": "ImporteNacional", className: 'dt-body-right', render: $.fn.dataTable.render.number(',', '.', 2)
                    //"data": "ImporteNacional", className: 'dt-body-right', render: function (data, type, row) {
                    //    return $.fn.dataTable.render.number(',', '.', 2)
                    //} 


                },
                {
                    "data": "estadoCobro", className: "uniqueClassName", "autoWidth": true, 'render': function (estadopago) {
                        if (!estadopago) {
                            return 'N/A';
                        }
                        else {
                            if (estadopago == "DC")
                                return "<span id='estadopay' class='label label-success'>" + 'Saldado' + "</span>"
                            else
                                return "<span id='estadopay' class='label label-danger'>" + 'Pendiente' + "</span>"

                        }
                    }
                },
                {
                    "render": function (data, type, full, meta) { return '<a class="btn btn-info" href="/Order/Edit/' + full.idDocumento + '"><span class="glyphicon glyphicon-search"></span> Ver</a>'; }
                },                
                {
                    data: null, render: function (data, type, row) {
                        //  return "<a href='#' class='btn btn-danger' onclick=DeleteData('" + row.idDocumento + "'); >Delete</a>";
                        //return "<a href='#' class='editor_remove'  >Delete</a>";
                        return '<a href="#" class="btn btn-danger" id=deleteVenta> <span class="glyphicon glyphicon-trash"></span> </a>';
                    }
                },
            ]
        })

        //    $("#loaderDiv").hide();
    });

    $('#btnNuevo').click(function () {
        //   alert('btn nuevo');
        //var url = '@Url.Action("NuevaOrden", "Order")';
        window.location.href = 'NuevaOrden2';
    });

    $('#btnNuevaVenta').click(function () {
        //   alert('btn nuevo');
        //var url = '@Url.Action("NuevaOrden", "Order")';
        //window.location.href = 'NuevaVenta';
        window.location.href = 'NewSale';
    });


});