using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SA = Helios.Cont.WCFService.ServiceAccess;
using BE = Helios.Cont.Business.Entity;
using Helios.Cont.Web.Models;
using static Helios.General.Constantes;
using Helios.Cont.WCFService.ServiceAccess;
using Helios.Cont.Web.Helpers;

namespace Helios.Cont.Web.Controllers
{
    public static class DocumentoOperation
    {

        #region "Save Transfer"
        public static void SaveTransfer(BE.documento order)
        {
            SA.documentoVentaAbarrotesSA ventaSA = new SA.documentoVentaAbarrotesSA();            
            var doc = MappingDocumentoTransfer(order);
            var docCabecera = MappingDocumentoCabeceraTransfer(order);
            doc.documentoventaAbarrotes = docCabecera;

            var lista = MappingDocumentCabeceraDetalleTransfer(order);
            doc.documentoventaAbarrotes.documentoventaAbarrotesDet = lista;

            var sale = ventaSA.GrabarTransferencia(doc);
            //var sale = ventaSA.GrabarInventarioEquivalencia(doc);
        }

        public static void ConfirmGiveTransfer(BE.documento order)
        {
            SA.documentoVentaAbarrotesSA ventaSA = new SA.documentoVentaAbarrotesSA();         

            ventaSA.ConfirmarTransferencia(new BE.documento()
            {
                idDocumento = order.idDocumento
            });
            //var sale = ventaSA.GrabarInventarioEquivalencia(doc);
        }

        private static BE.documento MappingDocumentoTransfer(BE.documento order)
        {           
            //string tipoOper;
            //tipoOper = General.StatusTipoOperacion.TRANSFERENCIA_ENTRE_ALMACENES;

            var MappingDocumentoRet = new BE.documento()
            {
                AfectaInventario = order.AfectaInventario,
                idEmpresa = order.idEmpresa,
                idCentroCosto = order.idCentroCosto,
                tipoDoc = "9907",
                fechaProceso = DateTime.Now,// order.fechaProceso,
                moneda = order.moneda,
                idEntidad = order.idEntidad,
                entidad = order.entidad,
                tipoEntidad = order.tipoEntidad,
                nrodocEntidad = order.nrodocEntidad,
                nroDoc = order.nroDoc,
                idOrden = 0,
                tipoOperacion = order.tipoOperacion,
                ventaConLotes = order.ventaConLotes,
                usuarioActualizacion = order.usuarioActualizacion,
                fechaActualizacion = DateTime.Now,//order.fechaActualizacion,
            };
            return MappingDocumentoRet;
        }

        private static BE.documentoventaAbarrotes MappingDocumentoCabeceraTransfer(BE.documento be)
        {
            // tipoVenta = TIPO_COMPRA.TRANSFERENCIA_ENTRE_ALMACEN;

            var statusEntrega = "0";//No entregado (En transito)
            if (be.AfectaInventario)
            {
                statusEntrega = "1";//Entregado (En almacén)
            }

            var obj = new BE.documentoventaAbarrotes()
            {
                codigoLibro = be.documentoventaAbarrotes.codigoLibro,
                tipoOperacion = be.documentoventaAbarrotes.tipoOperacion,
                idEmpresa = be.idEmpresa,
                idEstablecimiento = be.idCentroCosto,
                fechaLaboral = DateTime.Now,
                fechaDoc = DateTime.Now,//be.fechaProceso,
                fechaPeriodo = GetPeriodo(DateTime.Now, true),
                tipoDocumento = "9907",
                idCliente = be.idEntidad,
                nombrePedido = be.entidad,
                moneda = be.moneda,
                tasaIgv = 0,
                tipoCambio = 1,
                bi01 = be.documentoventaAbarrotes.bi01,
                bi02 = be.documentoventaAbarrotes.bi02,
                isc01 = 0,
                isc02 = 0,
                igv01 = be.documentoventaAbarrotes.igv01,
                igv02 = 0,
                icbper = 0,
                icbperus = 0,
                otc01 = 0,
                otc02 = 0,
                bi01us = 0,
                bi02us = 0,
                isc01us = 0,
                isc02us = 0,
                igv01us = 0,
                igv02us = 0,
                otc01us = 0,
                otc02us = 0,
                importeCostoMN = 0,
                terminos = "TRANSFERENCIA",
                ImporteNacional = be.documentoventaAbarrotes.ImporteNacional,
                ImporteExtranjero = 0,
                tipoVenta = be.documentoventaAbarrotes.tipoVenta,
                estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO,
                glosa = "TRANSFERENCIA de mercadería",
                sustentado = "S",
                idPadre = "0",
                estadoEntrega = statusEntrega,
                usuarioActualizacion = be.usuarioActualizacion,
                fechaActualizacion = DateTime.Now
            };
            return obj;
            //be.documentoventaAbarrotes = obj;
            //be.documentoventaAbarrotes.estadoCobro = TIPO_COMPRA.PAGO.PENDIENTE_PAGO;           
            //be.documentoventaAbarrotes.documentoventaAbarrotesDet = new List<BE.documentoventaAbarrotesDet>();
        }


        private static List<BE.documentoventaAbarrotesDet> MappingDocumentCabeceraDetalleTransfer(BE.documento order)
        {
            BE.documentoventaAbarrotesDet objDet;
            List<BE.documentoventaAbarrotesDet> documentoventaAbarrotesDets = new List<BE.documentoventaAbarrotesDet>();
            foreach (var i in order.documentoventaAbarrotes.documentoventaAbarrotesDet.ToList())
            {
                if (i.CustomEquivalencia.fraccionUnidad <= 0)
                    throw new Exception($"Debe ingresar un factor de conversión > 0, para el Producto-{i.CustomProducto.descripcionItem}");
                // precUnitEquivalencia = i.monto1 * i.CustomEquivalencia.fraccionUnidad

                objDet = new BE.documentoventaAbarrotesDet()
                {
                    tasaIcbper = i.tasaIcbper,
                    idAlmacenOrigen = i.idAlmacenOrigen,
                    idalmacenDestino = i.idalmacenDestino,
                    categoria = i.categoria,
                    detalleAdicional = i.detalleAdicional,
                    montoIcbper = i.montoIcbper,
                    AfectoInventario = true,
                    estadoMovimiento = "True",
                    CodigoCosto = i.CodigoCosto,
                    CustomEquivalencia = i.CustomEquivalencia,
                    ContenidoNetoUnidadComercialMaxima = i.ContenidoNetoUnidadComercialMaxima.GetValueOrDefault(),
                    CustomProducto = i.CustomProducto,
                    Customlote = i.Customlote,
                    codigoLote = i.codigoLote.GetValueOrDefault(),
                    CustomCatalogo = null,
                    catalogo_id = 0,
                    idItem = i.CustomProducto.codigodetalle.ToString(),
                    nombreItem = i.CustomProducto.descripcionItem,
                    tipoExistencia = i.CustomProducto.tipoExistencia,
                    destino = i.CustomProducto.origenProducto,
                    unidad1 = i.CustomProducto.unidad1,
                    monto1 = i.monto1,
                    equivalencia_id = i.CustomEquivalencia.equivalencia_id,
                    unidad2 = null,
                    monto2 = (i.monto1 * i.CustomEquivalencia.fraccionUnidad).ToString(),
                    precioUnitario = i.monto1 * i.CustomEquivalencia.fraccionUnidad,
                    precioUnitarioUS = i.precioUnitarioUS.GetValueOrDefault(),
                    importeMN = i.importeMN,
                    importeME = i.importeME.GetValueOrDefault(),
                    montokardex = i.montokardex,
                    montoIsc = 0,
                    montoIgv = i.montoIgv,
                    otrosTributos = 0,
                    montokardexUS = i.montokardex.GetValueOrDefault(),
                    montoIscUS = 0,
                    montoIgvUS = i.montoIgvUS.GetValueOrDefault(),
                    otrosTributosUS = 0,
                    entregado = "1",
                    estadoPago = i.estadoPago,
                    bonificacion = false,
                    descuentoMN = i.descuentoMN.GetValueOrDefault(),
                    tipobeneficio = i.tipobeneficio,
                    usuarioModificacion =i.usuarioModificacion,
                    fechaModificacion = DateTime.Now
                };
                documentoventaAbarrotesDets.Add(objDet);
            }
            return documentoventaAbarrotesDets;
        }


        #endregion


        #region Others purchases

        public static void SaveOthersPurchase(BE.documento order)
        {
            var compraSA = new DocumentoCompraSA();
            var doc = MappingDocumentoPurchases(order);
            var docCompra = MappingDocumentOthersPurchase(order);
            doc.documentocompra = docCompra;
            MappingDocumentoPurchasesDetail(order, doc.documentocompra);                       

            compraSA.GrabarCompraEquivalencia(doc);
        }      

        private static void AddInventario(BE.documentocompradetalle itemCompra,decimal cantDividida,BE.documentocompra compra )
        {
            string codigoInv = Guid.NewGuid().ToString();
            var fechaCompra = DateTime.Now; // New Date(UCEstructuraDocumentocabecera.TxtDia.DecimalValue, CInt(UCEstructuraDocumentocabecera.cboMesCompra.SelectedValue), Date.Now.Year)
                               

            decimal fracccion = itemCompra.CustomProducto_equivalencia.fraccionUnidad.GetValueOrDefault();
            decimal cantidadInventario = fracccion * itemCompra.monto1.GetValueOrDefault();
            var costoInventario = itemCompra.montokardex;
            var costoUnitario = Math.Round((decimal)(costoInventario / itemCompra.monto1), 2);
         //   var montoCostoItem = costoUnitario * cantidadInventario;


            string tipoOperacion = null;

            //switch (FormPurchase.ComboComprobante.Text)
            //{
            //    case "Compra recepción directa":
            //        {
            //            tipoOperacion = StatusTipoOperacion.COMPRA;
            //            break;
            //        }

            //    case "NOTA DE COMPRA":
            //        {
            //            tipoOperacion = StatusTipoOperacion.COMPRA;
            //            break;
            //        }

            //    case "Otra entrada":
            //        {
            tipoOperacion = StatusTipoOperacion.OTRAS_ENTRADAS_A_ALMACEN;
            //            break;
            //        }
            //}


            var obj = new BE.InventarioMovimiento();
            obj.CantEntrada = itemCompra.monto1.GetValueOrDefault();
            obj.codigoBarra = codigoInv;
            obj.idEmpresa = LoginInformation.Empresa.idEmpresa;
            obj.idEstablecimiento = LoginInformation.Establecimiento.idCentroCosto;
            obj.idAlmacen = itemCompra.almacenRef.GetValueOrDefault();
            obj.TipoAlmacen = "AF";
            obj.nrolote = "0";
            obj.MatriculaVehiculo = "nro.matricula";
            obj.Chofer = "nom.chofer";
            obj.tipoOperacion = tipoOperacion; // StatusTipoOperacion.COMPRA
            obj.tipoDocAlmacen = "99";
            obj.serie = compra.serie;
            obj.numero = compra.numeroDoc;
            obj.idDocumento = 0;
            obj.idDocumentoRef = "0";
            obj.descripcion = itemCompra.CustomProducto.descripcionItem;
            obj.fechaLaboral = DateTime.Now;
            obj.fecha = fechaCompra;
            obj.tipoRegistro = "E";
            obj.destinoGravadoItem = itemCompra.CustomProducto.origenProducto;
            obj.tipoProducto = itemCompra.CustomProducto.tipoExistencia;
            obj.OrigentipoProducto = "N";
            obj.idItem = itemCompra.CustomProducto.codigodetalle;
            obj.marca = itemCompra.CustomProducto.unidad2;
            obj.presentacion = itemCompra.CustomProducto.presentacion;
            obj.cantidad = cantidadInventario;
            obj.unidad = itemCompra.CustomProducto.unidad1;
            obj.cantidad2 = 0;
            obj.precUnite = costoUnitario;
            obj.precUniteUSD = 0;
            obj.monto = itemCompra.montokardex; // obj.GetImporteAlmacen ' montoCostoItem
            obj.montoUSD = itemCompra.montokardexUS.GetValueOrDefault();
            obj.montoOther = 0;
            obj.monedaOther = "0";
            obj.disponible = 0;
            obj.disponible2 = 0;
            obj.saldoMonto = 0;
            obj.saldoMontoUsd = 0;
            obj.status = "D";
            obj.entragado = "1";
            obj.usuarioActualizacion = itemCompra.usuarioModificacion;
            obj.consignado = "N";
            obj.fechaActualizacion = DateTime.Now;
            itemCompra.CustomListaInventarioMovimiento.Add(obj);
        }

        //private static List<BE.inventarioTransito> GetMappingInventarioTransito(List<BE.InventarioMovimiento> lista)
        //{
        //    List<BE.inventarioTransito> GetMappingInventarioTransitoRet;
        //    GetMappingInventarioTransitoRet = new List<BE.inventarioTransito>();
        //    foreach (var i in lista)
        //    {
        //        //switch (ComboComprobante.Text)
        //        //{
        //        //    case "Compra recepción directa":
        //        //        {
        //        //            i.tipoOperacion = StatusTipoOperacion.COMPRA;
        //        //            break;
        //        //        }

        //        //    case "NOTA DE COMPRA":
        //        //        {
        //        //            i.tipoOperacion = StatusTipoOperacion.COMPRA;
        //        //            break;
        //        //        }

        //            //case "Otra entrada":
        //            //    {
        //                    i.tipoOperacion = StatusTipoOperacion.OTRAS_ENTRADAS_A_ALMACEN;
        //                    //break;
        //        //        }
        //        //}


        //        var almacenSel = UCTransporteDistribucionProductos.UCDistribucionAlmacen.ListaAlmacen.Where(o => Operators.ConditionalCompareObjectEqual(o.idAlmacen, i.idAlmacen, false)).SingleOrDefault;

        //        if (almacenSel.tipo == "AV")
        //            GetMappingInventarioTransitoRet.Add(new inventarioTransito()
        //            {
        //                idEstablecimiento = GEstableciento.IdEstablecimiento,
        //                almacen = i.idAlmacen,
        //                idProducto = i.idItem,
        //                cantidad = i.cantidad,
        //                monto = i.monto,
        //                montoME = i.montoUSD,
        //                tipoOperacion = i.tipoOperacion,
        //                status = 1
        //            });
        //    }

        //    return GetMappingInventarioTransitoRet;
        //}
        
        private static void MappingDocumentoPurchasesDetail(BE.documento obj, BE.documentocompra compraNew)
        {
          //  SA.almacenSA almacenSA = new almacenSA();
            BE.documentocompradetalle objDet;                  
            compraNew.documentocompradetalle = new List<BE.documentocompradetalle>();
            foreach (var i in obj.documentocompra.documentocompradetalle.ToList())
            {                
             
                objDet = new BE.documentocompradetalle()
                {                    
                    CustomListaInventarioMovimiento = new List<BE.InventarioMovimiento>(),
                    CustomProducto = i.CustomProducto,
                    CustomProducto_equivalencia = i.CustomProducto_equivalencia,
                    equivalencia_id = i.CustomProducto_equivalencia.equivalencia_id,
                    idItem = i.CustomProducto.codigodetalle.ToString(),
                    descripcionItem = i.CustomProducto.descripcionItem,
                    tipoExistencia = i.CustomProducto.tipoExistencia,
                    destino = i.CustomProducto.origenProducto,
                    unidad1 = i.CustomProducto.unidad1,
                    monto1 = i.monto1,
                    unidad2 = null,
                    monto2 = i.CustomProducto_equivalencia.fraccionUnidad.GetValueOrDefault().ToString(),
                    precioUnitario = i.precioUnitario.GetValueOrDefault(),
                    precioUnitarioUS = i.precioUnitarioUS.GetValueOrDefault(),
                    importe = i.importe,
                    importeUS = i.importeUS.GetValueOrDefault(),
                    montokardex = i.montokardex,
                    montoIsc = 0,
                    montoIgv = i.montoIgv,
                    otrosTributos = 0,
                    montokardexUS = i.montokardexUS.GetValueOrDefault(),
                    montoIscUS = 0,
                    montoIgvUS = i.montoIgvUS.GetValueOrDefault(),
                    otrosTributosUS = 0,
                    percepcionMN = 0,
                    percepcionME = 0,
                    bonificacion = i.bonificacion,
                    nrolote = i.nrolote,
                    almacenRef = i.almacenRef,
                    entregable = "N",
                    estadoPago = i.estadoPago,
                    ItemEntregadototal = i.ItemEntregadototal,
                    usuarioModificacion = i.usuarioModificacion,
                    fechaModificacion = DateTime.Now
                };
                compraNew.documentocompradetalle.Add(objDet);
                AddInventario(objDet, 1, compraNew);
            }
        }


        private static BE.documentocompra MappingDocumentOthersPurchase(BE.documento be)
        {       
            string glosa = null;       
            string TIPOCOMPRA = string.Empty;
            TIPOCOMPRA = TIPO_COMPRA.OTRAS_ENTRADAS;

            glosa = be.documentocompra.glosa;                 

            var obj = new BE.documentocompra()
            {
                codigoLibro = "8",
                idEmpresa = be.idEmpresa,
                idCentroCosto = be.idCentroCosto,
                fechaLaboral = DateTime.Now,
                fechaDoc = DateTime.Now,
                fechaVcto = null,
                fechaContable = GetPeriodo(DateTime.Now, true),
                tipoDoc = be.tipoDoc,
                serie = be.documentocompra.serie,
                numeroDoc = be.documentocompra.numeroDoc,
                idProveedor = be.idEntidad,
                monedaDoc = be.moneda,
                tasaIgv = be.documentocompra.tasaIgv,
                tcDolLoc = be.documentocompra.tcDolLoc,
                tipocambio = be.documentocompra.tipocambio,
                bi01 = be.documentocompra.bi01,
                bi02 = be.documentocompra.bi02,
                bi03 = 0,
                bi04 = 0,
                isc01 = 0,
                isc02 = 0,
                isc03 = 0,
                igv01 = be.documentocompra.igv01,
                igv02 = 0,
                igv03 = 0,
                otc01 = 0,
                otc02 = 0,
                otc03 = 0,
                otc04 = 0,
                bi01us = be.documentocompra.bi01us,
                bi02us = be.documentocompra.bi02us,
                bi03us = 0,
                bi04us = 0,
                isc01us = 0,
                isc02us = 0,
                isc03us = 0,
                igv01us = be.documentocompra.igv01us,
                igv02us = 0,
                igv03us = 0,
                otc01us = 0,
                otc02us = 0,
                otc03us = 0,
                otc04us = 0,
                percepcion = 0,
                percepcionus = 0,
                importeTotal = be.documentocompra.importeTotal,
                importeUS = be.documentocompra.importeUS,
                destino = be.documentocompra.tipoCompra,
                estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO,
                glosa = glosa,
                tipoCompra =be.documentocompra.tipoCompra,
                sustentado = "S",
                idPadre = 0,
                aprobado = "S",
                apruebaPago = "S",
                tieneDetraccion = "N",
                situacion = ((int)statusComprobantes.Normal).ToString(),
                estadoEntrega = "1",
                usuarioActualizacion = be.usuarioActualizacion,
                fechaActualizacion = DateTime.Now
            };

            return obj;
            //be.documentocompra.documentocompradetalle = new List<BE.documentocompradetalle>();
        }

        private static BE.documento MappingDocumentoPurchases(BE.documento order)
        {
            var fechaCompra = DateTime.Now;

            string NUMERO_DOC = string.Empty;
            string OPERACION_DOC = string.Empty;
            NUMERO_DOC = "0";
            OPERACION_DOC = StatusTipoOperacion.OTRAS_ENTRADAS_A_ALMACEN;                                         

            var MappingDocumentoRet = new BE.documento()
            {
                idEmpresa = LoginInformation.Empresa.idEmpresa,
                idCentroCosto = LoginInformation.Establecimiento.idCentroCosto,
                idProyecto = 0,
                tipoDoc = order.tipoDoc,
                fechaProceso = fechaCompra,
                moneda = "1",
                idEntidad = order.idEntidad,
                entidad = order.entidad,
                tipoEntidad = TIPO_ENTIDAD.PROVEEDOR,
                nrodocEntidad = order.nrodocEntidad,
                nroDoc = NUMERO_DOC,
                idOrden = 0,
                tipoOperacion = OPERACION_DOC,
                usuarioActualizacion = order.usuarioActualizacion,
                fechaActualizacion = DateTime.Now
            };
            return MappingDocumentoRet;
        }

        #endregion

        #region "Save Sale"
        public static void SaveSale(BE.documento order)
        {
            SA.documentoVentaAbarrotesSA ventaSA = new SA.documentoVentaAbarrotesSA();
            EnvioImpresionVendedorPernos envio = null;
            var doc = FillDocumento(order);
            FillDocumentoCompraCabeceraSale(doc, order.documentoventaAbarrotes);
            FillDocumentoCompraCabeceraDetalleSale(doc, order.documentoventaAbarrotes);
            MappingPagos(envio, doc, order);
            var ListaPagos = doc.ListaCustomDocumento;
            var sale = ventaSA.GrabarVentaEquivalencia(doc);
            GetSendDocumentElectronic(ListaPagos, sale);
            // UpdateInfraestructura(order.documentoventaAbarrotes);
        }

        private static void GetSendDocumentElectronic(List<BE.documento> ListaPagos, BE.documento sale)
        {
            SA.documentoVentaAbarrotesSA ventaSA = new SA.documentoVentaAbarrotesSA();

            if(sale.tipoDoc == "01" || sale.tipoDoc == "03")
            {
                if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                {
                    System.Net.NetworkInformation.Ping Pings = new System.Net.NetworkInformation.Ping();
                    int timeout = 10;

                    if (Pings.Send("138.128.171.106", timeout).Status == System.Net.NetworkInformation.IPStatus.Success)
                    {
                        if (int.Parse(LoginInformation.Empresa.ubigeo) > 0)
                        {
                            var comprobante = ventaSA.GetVentaID(new BE.documento() { idDocumento = sale.idDocumento });
                            sale.documentoventaAbarrotes = comprobante;
                            sale.ListaCustomDocumento = ListaPagos;
                            EnviarFacturaElectronica(sale, int.Parse(LoginInformation.Empresa.ubigeo));

                            //FormImpresionNuevo = new FormImpresionEquivalencia(doc);  // frmVentaNuevoFormato
                            //FormImpresionNuevo.tienda = "";
                            //FormImpresionNuevo.FormaPago = "";
                            //FormImpresionNuevo.DocumentoID = doc.idDocumento;
                            //FormImpresionNuevo.Email = "";
                            //FormImpresionNuevo.StartPosition = FormStartPosition.CenterScreen;

                            //FormImpresionNuevo.ShowDialog(this);
                        }
                    }
                }
            }
            else
            {

            }

            
        }

        private static void MappingPagos(EnvioImpresionVendedorPernos envio, BE.documento obj, BE.documento orden)
        {
            var ListaPagos = ListaPagosCajas(obj.documentoventaAbarrotes, obj.documentoventaAbarrotes.documentoventaAbarrotesDet.ToList(), envio, orden);
            obj.ListaCustomDocumento = ListaPagos.ToList();

            decimal SumaPagos = 0;
            foreach (var i in ListaPagos)
                SumaPagos += i.documentoCaja.montoSoles.GetValueOrDefault();
            if (SumaPagos == obj.documentoventaAbarrotes.ImporteNacional)
            {
                obj.documentoventaAbarrotes.terminos = "CONTADO";
                obj.documentoventaAbarrotes.estadoCobro = TIPO_VENTA.PAGO.COBRADO;
            }
            else
            {
                // ndocumento.documentoventaAbarrotes.terminos = "PARCIAL"
                obj.documentoventaAbarrotes.terminos = "CREDITO";
                obj.documentoventaAbarrotes.estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO;
            }
        }

        public static List<BE.documento> ListaPagosCajas(BE.documentoventaAbarrotes venta, List<BE.documentoventaAbarrotesDet> ventaDetalle, EnvioImpresionVendedorPernos envio, BE.documento Order)
        {
            BE.documento nDocumentoCaja = new BE.documento();
            BE.documentoCaja objCaja = new BE.documentoCaja();
            List<BE.documento> ListaDoc = new List<BE.documento>();

            if (Order.ListaCustomDocumentoCaja != null)
            {
                foreach (var i in Order.ListaCustomDocumentoCaja)
                {
                    if (i.montoSoles > 0)
                    {
                        nDocumentoCaja = new BE.documento();
                        nDocumentoCaja.idDocumento = 0; // CInt(Me.Tag)
                        nDocumentoCaja.idEmpresa = Order.idEmpresa;
                        nDocumentoCaja.idCentroCosto = Order.idCentroCosto;
                        nDocumentoCaja.fechaProceso = DateTime.Now;
                        nDocumentoCaja.tipoDoc = "9903"; // cbotipoDocPago.SelectedValue
                        nDocumentoCaja.nroDoc = "0";
                        nDocumentoCaja.idOrden = null;
                        nDocumentoCaja.moneda = i.moneda;
                        nDocumentoCaja.idEntidad = Order.idEntidad;
                        nDocumentoCaja.entidad = Order.entidad;
                        nDocumentoCaja.nrodocEntidad = Order.nrodocEntidad;
                        nDocumentoCaja.tipoEntidad = TIPO_ENTIDAD.CLIENTE;
                        nDocumentoCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES;
                        nDocumentoCaja.usuarioActualizacion = venta.usuarioActualizacion; // usuario.IDUsuario
                        nDocumentoCaja.fechaActualizacion = DateTime.Now;


                        // DOCUMENTO CAJA
                        objCaja = new BE.documentoCaja();
                        objCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES;
                        objCaja.idDocumento = 0;
                        objCaja.periodo = venta.fechaPeriodo;
                        objCaja.idEmpresa = venta.idEmpresa;
                        objCaja.idEstablecimiento = venta.idEstablecimiento;
                        objCaja.fechaProceso = DateTime.Now;
                        objCaja.fechaCobro = DateTime.Now;
                        objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO;
                        objCaja.codigoProveedor = i.codigoProveedor;
                        objCaja.IdProveedor = i.IdProveedor;
                        objCaja.idPersonal = i.idPersonal;

                        objCaja.TipoDocumentoPago = "9903";
                        objCaja.codigoLibro = "1";
                        objCaja.tipoDocPago = venta.tipoDocumento;
                        objCaja.formapago = i.formapago;
                        objCaja.formaPagoName = i.formaPagoName;
                        objCaja.NumeroDocumento = "-";
                        var numeroop = i.numeroOperacion;

                        if (numeroop != null)
                            objCaja.numeroOperacion = numeroop;
                        //if (i.GetValue("idforma") == "006" | i.GetValue("idforma") == "007")
                        //    objCaja.estadopago = 1;

                        switch (venta.tipoDocumento)
                        {
                            case "9907":
                                {
                                    objCaja.movimientoCaja = TIPO_VENTA.NOTA_DE_VENTA;
                                    break;
                                }

                            case "9903":
                                {
                                    objCaja.movimientoCaja = TIPO_VENTA.PROFORMA;
                                    break;
                                }

                            default:
                                {
                                    objCaja.movimientoCaja = TIPO_VENTA.VENTA_ELECTRONICA;
                                    break;
                                }
                        }


                        objCaja.montoSoles = i.montoSoles;
                        objCaja.moneda = i.moneda;
                        objCaja.tipoCambio = i.tipoCambio;
                        objCaja.montoUsd = 0;
                        objCaja.estado = "1";
                        objCaja.glosa = "Por ventas";
                        objCaja.entregado = "SI";
                        objCaja.idCajaUsuario = i.idCajaUsuario;// envio.IDCaja; // GFichaUsuarios.IdCajaUsuario
                        objCaja.entidadFinanciera = i.entidadFinanciera;
                        objCaja.NombreEntidad = i.NombreEntidad;
                        objCaja.usuarioModificacion = venta.usuarioActualizacion; // usuario.IDUsuario
                        objCaja.fechaModificacion = DateTime.Now;
                        nDocumentoCaja.documentoCaja = objCaja;
                        nDocumentoCaja.documentoCaja.documentoCajaDetalle = GetDetallePago(objCaja, ventaDetalle);
                        // asientoDocumento(nDocumentoCaja.documentoCaja)
                        ListaDoc.Add(nDocumentoCaja);
                    }
                }
            }            

            return ListaDoc;
        }

        private static List<BE.documentoCajaDetalle> GetDetallePago(BE.documentoCaja objCaja, List<BE.documentoventaAbarrotesDet> ventaDetalle)
        {
            List<string> listaBeneficio = new List<string>();
            listaBeneficio.Add("OFERTA");
            listaBeneficio.Add("REGALO");
            var montoPago = objCaja.montoSoles.GetValueOrDefault();
            var DetallePago = new List<BE.documentoCajaDetalle>();
            foreach (var i in ventaDetalle.Where(o => !listaBeneficio.Contains(o.tipobeneficio)).ToList())
            {
                if (montoPago > 0)
                {
                    if (i.MontoSaldo > 0)
                    {
                        if (i.MontoSaldo > montoPago)
                        {
                            var canUso = montoPago;
                            i.MontoPago = canUso;
                            i.estadoPago = i.ItemPendiente;
                        }
                        else if (i.MontoSaldo == montoPago)
                        {
                            i.MontoPago = montoPago;
                            i.estadoPago = i.ItemSaldado;
                        }
                        else
                        {
                            var canUso = i.MontoSaldo;
                            i.MontoPago = canUso;
                            i.estadoPago = i.ItemSaldado;
                        }
                        montoPago -= i.MontoPago; // ImporteDisponible

                        // .codigoLote = Integer.Parse(i.codigoLote),

                        DetallePago.Add(new BE.documentoCajaDetalle()
                        {
                            destino = i.CodigoCosto,
                            fecha = DateTime.Now,
                            codigoLote = 0,
                            otroMN = 0,
                            idItem = i.idItem,
                            DetalleItem = i.nombreItem,
                            montoSoles = i.MontoPago,
                            montoUsd = 0,
                            diferTipoCambio = 1,
                            tipoCambioTransacc = 1,
                            entregado = "SI",
                            idCajaUsuario = objCaja.idCajaUsuario,
                            usuarioModificacion = objCaja.usuarioModificacion,
                            documentoAfectado = 0,
                            documentoAfectadodetalle = 0,
                            EstadoCobro = i.estadoPago,
                            fechaModificacion = DateTime.Now
                        });
                        i.estadoPago = i.estadoPago;
                    }
                }
            }
            return DetallePago;
        }

        private static void FillDocumentoCompraCabeceraDetalleSale(BE.documento obj, BE.documentoventaAbarrotes order)
        {
            //establecimientoOrigen = obj.idCentroCosto,                    
            //        CustomEquivalencia = i.CustomEquivalencia,                    
            //        CustomCatalogo = i.CustomCatalogo,             

            BE.documentoventaAbarrotesDet objDet;
            foreach (var i in order.documentoventaAbarrotesDet.ToList())
            {
                var cod = System.Guid.NewGuid().ToString();

                objDet = new BE.documentoventaAbarrotesDet()
                {
                    tasaIcbper = 0,
                    montoIcbper = 0,
                    montoIcbperUS = 0,
                    idAlmacenOrigen = 0,
                    AfectoInventario = i.AfectoInventario,
                    CodigoCosto = cod,
                    CustomProducto = i.CustomProducto,
                    catalogo_id = i.CustomCatalogo.idCatalogo,
                    idItem = i.CustomProducto.codigodetalle.ToString(),
                    nombreItem = i.CustomProducto.descripcionItem,
                    tipoExistencia = i.CustomProducto.tipoExistencia,
                    destino = i.CustomProducto.origenProducto,
                    unidad1 = i.CustomProducto.unidad1,
                    monto1 = i.monto1,
                    equivalencia_id = i.CustomEquivalencia.equivalencia_id,
                    unidad2 = null,
                    monto2 = i.PrecioUnitarioVentaMN.ToString(),
                    PrecioUnitarioVentaMN = i.PrecioUnitarioVentaMN,
                    precioUnitario = i.precioUnitario.GetValueOrDefault(),
                    precioUnitarioUS = i.precioUnitarioUS.GetValueOrDefault(),
                    importeMN = i.importeMN,
                    importeME = i.importeME.GetValueOrDefault(),
                    montokardex = i.montokardex,
                    montoIsc = 0,
                    montoIgv = i.montoIgv,
                    otrosTributos = 0,
                    montokardexUS = i.montokardexUS.GetValueOrDefault(),
                    montoIscUS = 0,
                    montoIgvUS = i.montoIgvUS.GetValueOrDefault(),
                    otrosTributosUS = 0,
                    entregado = "1",
                    estadoPago = "DC",
                    detalleAdicional = i.detalleAdicional,
                    tipobeneficio = "N",
                    bonificacion = false,
                    descuentoMN = 0,
                    usuarioModificacion = i.usuarioModificacion,
                    fechaModificacion = DateTime.Now
                };

                obj.documentoventaAbarrotes.documentoventaAbarrotesDet.Add(objDet);
            }
        }
        
       
        #endregion

        #region "Save Order"

        public static void SaveOrder(BE.documento order)
        {
            SA.documentoVentaAbarrotesSA ventaSA = new SA.documentoVentaAbarrotesSA();
            var doc = FillDocumento(order);
            FillDocumentoCompraCabecera(doc, order.documentoventaAbarrotes);
            FillDocumentoCompraCabeceraDetalle(doc, order.documentoventaAbarrotes);
            ventaSA.GrabarVentaEquivalencia(doc);
           // UpdateInfraestructura(order.documentoventaAbarrotes);
        }

        public static BE.documento FillDocumento(BE.documento order)
        {
            DateTime fechaVenta = DateTime.Now;

            var documento = new BE.documento()
            {
                idEmpresa = order.idEmpresa,
                idCentroCosto = order.idCentroCosto,
                idProyecto = 0,
                tipoDoc = order.tipoDoc,
                fechaProceso = DateTime.Now,//  DateTime.Parse(order.fechaDoc.ToString()),
                moneda = order.moneda,//cboMoneda.Text == "NUEVO SOL" ? "1" : "2",
                idEntidad = order.idEntidad,
                entidad = order.entidad,
                tipoEntidad = TIPO_ENTIDAD.CLIENTE,
                nrodocEntidad = order.nrodocEntidad,
                nroDoc = order.nroDoc,
                idOrden = 0,
                tipoOperacion = StatusTipoOperacion.VENTA,
                usuarioActualizacion = order.usuarioActualizacion,
                fechaActualizacion = DateTime.Now,
                TipoEnvio = order.TipoEnvio,
            };
            return documento;
        }

        private static void FillDocumentoCompraCabecera(BE.documento be, BE.documentoventaAbarrotes order)
        {
            //idClientePedido = order.idClientePedido,
            BE.documentoventaAbarrotes obj = new BE.documentoventaAbarrotes()
            {
                codigoLibro = order.codigoLibro,
                tipoOperacion = order.tipoOperacion,
                idEmpresa = order.idEmpresa,
                idEstablecimiento = order.idEstablecimiento,
                fechaLaboral = DateTime.Now,
                fechaDoc = DateTime.Now,
                fechaVcto = null,
                fechaPeriodo = GetPeriodo(be.fechaProceso, true),
                tipoDocumento = order.tipoDocumento,
                idCliente = order.idCliente,
                nombrePedido = order.nombrePedido,
                moneda = order.moneda,
                tasaIgv = order.tasaIgv,
                tipoCambio = order.tipoCambio,
                bi01 = order.bi01,
                bi02 = order.bi02,
                isc01 = 0,
                isc02 = 0,
                igv01 = order.igv01,
                igv02 = 0,
                otc01 = 0,
                otc02 = 0,
                bi01us = 0,
                bi02us = 0,
                isc01us = 0,
                isc02us = 0,
                igv01us = 0,
                igv02us = 0,
                otc01us = 0,
                otc02us = 0,
                importeCostoMN = 0,
                terminos = "CREDITO",
                ImporteNacional = order.ImporteNacional,
                ImporteExtranjero = order.ImporteExtranjero,
                tipoVenta = order.tipoVenta,
                estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO,
                glosa = "PRE VENTA",
                sustentado = "S",
                idPadre = "0",
                estadoEntrega = "1",
                icbper = 0,
                icbperus = 0,
                usuarioActualizacion = order.usuarioActualizacion,
                fechaActualizacion = DateTime.Now
            };
            //estado = "1",
            be.documentoventaAbarrotes = obj;
            be.documentoventaAbarrotes.estadoCobro = TIPO_COMPRA.PAGO.PENDIENTE_PAGO;
            be.documentoventaAbarrotes.documentoventaAbarrotesDet = new List<BE.documentoventaAbarrotesDet>();
        }

        private static void FillDocumentoCompraCabeceraSale(BE.documento be, BE.documentoventaAbarrotes order)
        {
            //idClientePedido = order.idClientePedido,
            BE.documentoventaAbarrotes obj = new BE.documentoventaAbarrotes()
            {
                codigoLibro = order.codigoLibro,
                tipoOperacion = order.tipoOperacion,
                idEmpresa = order.idEmpresa,
                idEstablecimiento = order.idEstablecimiento,
                fechaLaboral = DateTime.Now,
                fechaDoc = DateTime.Now,
                fechaVcto = null,
                fechaPeriodo = GetPeriodo(be.fechaProceso, true),
                tipoDocumento = order.tipoDocumento,
                idCliente = order.idCliente,
                nombrePedido = order.nombrePedido,
                moneda = order.moneda,
                tasaIgv = order.tasaIgv,
                tipoCambio = order.tipoCambio,
                bi01 = order.bi01,
                bi02 = order.bi02,
                isc01 = 0,
                isc02 = 0,
                igv01 = order.igv01,
                igv02 = 0,
                otc01 = 0,
                otc02 = 0,
                bi01us = 0,
                bi02us = 0,
                isc01us = 0,
                isc02us = 0,
                igv01us = 0,
                igv02us = 0,
                otc01us = 0,
                otc02us = 0,
                importeCostoMN = 0,
                terminos = order.terminos,
                ImporteNacional = order.ImporteNacional,
                ImporteExtranjero = order.ImporteExtranjero,
                tipoVenta = order.tipoVenta,
                estadoCobro = order.estadoCobro,
                glosa = "VENTA DIRECTA",
                sustentado = "S",
                idPadre = order.idPadre,
                estadoEntrega = "1",
                icbper = 0,
                icbperus = 0,
                usuarioActualizacion = order.usuarioActualizacion,
                fechaActualizacion = DateTime.Now
            };
            //estado = "1",
            be.documentoventaAbarrotes = obj;
            be.documentoventaAbarrotes.estadoCobro = TIPO_COMPRA.PAGO.PAGADO;
            be.documentoventaAbarrotes.documentoventaAbarrotesDet = new List<BE.documentoventaAbarrotesDet>();
        }

        private static void FillDocumentoCompraCabeceraDetalle(BE.documento obj, BE.documentoventaAbarrotes order)
        {
            //establecimientoOrigen = obj.idCentroCosto,                    
            //        CustomEquivalencia = i.CustomEquivalencia,                    
            //        CustomCatalogo = i.CustomCatalogo,             

            BE.documentoventaAbarrotesDet objDet;
            foreach (var i in order.documentoventaAbarrotesDet.ToList())
            {
                objDet = new BE.documentoventaAbarrotesDet()
                {
                    tasaIcbper = 0,
                    montoIcbper = 0,
                    montoIcbperUS = 0,
                    idAlmacenOrigen = 0,
                    AfectoInventario = i.AfectoInventario,
                    CodigoCosto = i.CodigoCosto,
                    CustomProducto = i.CustomProducto,
                    catalogo_id = i.CustomCatalogo.idCatalogo,
                    idItem = i.CustomProducto.codigodetalle.ToString(),
                    nombreItem = i.CustomProducto.descripcionItem,
                    tipoExistencia = i.CustomProducto.tipoExistencia,
                    destino = i.CustomProducto.origenProducto,
                    unidad1 = i.CustomProducto.unidad1,
                    monto1 = i.monto1,
                    equivalencia_id = i.CustomEquivalencia.equivalencia_id,
                    unidad2 = null,
                    monto2 = i.PrecioUnitarioVentaMN.ToString(),
                    PrecioUnitarioVentaMN = i.PrecioUnitarioVentaMN,
                    precioUnitario = i.precioUnitario.GetValueOrDefault(),
                    precioUnitarioUS = i.precioUnitarioUS.GetValueOrDefault(),
                    importeMN = i.importeMN,
                    importeME = i.importeME.GetValueOrDefault(),
                    montokardex = i.montokardex,
                    montoIsc = 0,
                    montoIgv = i.montoIgv,
                    otrosTributos = 0,
                    montokardexUS = i.montokardexUS.GetValueOrDefault(),
                    montoIscUS = 0,
                    montoIgvUS = i.montoIgvUS.GetValueOrDefault(),
                    otrosTributosUS = 0,
                    entregado = "1",
                    estadoPago = i.estadoPago,
                    detalleAdicional = i.detalleAdicional,
                    tipobeneficio = "N",
                    bonificacion = false,
                    descuentoMN = 0,
                    usuarioModificacion = i.usuarioModificacion,
                    fechaModificacion = DateTime.Now
                };

                obj.documentoventaAbarrotes.documentoventaAbarrotesDet.Add(objDet);


            }
        }
        
        #endregion


        public static void SaveDocumentoVenta(BE.documentoventaAbarrotes order)
        {
            SA.documentoVentaAbarrotesSA ventaSA = new SA.documentoVentaAbarrotesSA();
            var doc = MappingDocumento(order);
            MappingDocumentoCompraCabecera(doc, order);
            MappingDocumentoCompraCabeceraDetalle(doc, order);
            ventaSA.GrabarVentaEquivalencia(doc);
        }

        private static BE.documento MappingDocumento(BE.documentoventaAbarrotes order)
        {
            DateTime fechaVenta = DateTime.Now;

            var documento = new BE.documento()
            {
                idEmpresa = order.idEmpresa,
                idCentroCosto = order.idEstablecimiento,
                idProyecto = 0,
                tipoDoc = order.tipoDocumento,
                fechaProceso = DateTime.Now,//  DateTime.Parse(order.fechaDoc.ToString()),
                moneda = order.moneda,//cboMoneda.Text == "NUEVO SOL" ? "1" : "2",
                idEntidad = order.idCliente.GetValueOrDefault(),
                entidad = order.NombreEntidad,
                tipoEntidad = TIPO_ENTIDAD.CLIENTE,
                nrodocEntidad = order.NroDocEntidad,
                nroDoc = "0",
                idOrden = 0,
                tipoOperacion = StatusTipoOperacion.VENTA,
                usuarioActualizacion = order.usuarioActualizacion,
                fechaActualizacion = DateTime.Now
            };
            return documento;
        }
                     
        private static void MappingDocumentoCompraCabecera(BE.documento be, BE.documentoventaAbarrotes order)
        {
            string tipoVenta = string.Empty;
            decimal base1 = order.bi01.GetValueOrDefault();
            decimal base2 = 0;

            decimal base1ME = 0;
            decimal base2ME = 0;

            decimal iva1 = order.igv01.GetValueOrDefault();
            decimal iva1ME = 0;
            //     decimal iva2 = 0;
            decimal total = order.ImporteNacional.GetValueOrDefault(); // 
            decimal totalME = order.ImporteExtranjero.GetValueOrDefault(); // UCEstructuraDocumentocabecera.txtTotalPagar.DecimalValue

            //switch (be.moneda)
            //{
            //    case "1":
            //        {
            //            base1 = 0;
            //            base2 = 0;
            //            base1ME = 0;
            //            base2ME = 0;
            //            iva1 = 0;
            //            iva1ME = 0;
            //            total = 0;
            //            totalME = 0;
            //            break;
            //        }

            //    case "2":
            //        {
            //            base1ME = 0;
            //            base2ME = 0;

            //            base1 = 0;
            //            base2 = 0;

            //            iva1ME = 0;
            //            iva1 = 0;

            //            totalME = 0;
            //            total = 0;
            //            break;
            //        }
            //}

            tipoVenta = TIPO_VENTA.VENTA_NOTA_PEDIDO;

            BE.documentoventaAbarrotes obj = new BE.documentoventaAbarrotes()
            {
                codigoLibro = "14",
                idEmpresa = be.idEmpresa,
                idEstablecimiento = be.idCentroCosto,
                fechaLaboral = DateTime.Now,
                fechaDoc = be.fechaProceso,
                fechaVcto = null,
                tipoOperacion = "01",
                fechaPeriodo = GetPeriodo(be.fechaProceso, true),
                tipoDocumento = be.tipoDoc,
                idClientePedido = be.idEntidad,
                idCliente = be.idEntidad,
                nombrePedido = be.entidad,
                moneda = be.moneda,
                tasaIgv = order.tasaIgv,
                tipoCambio = order.tipoCambio,
                bi01 = base1,
                bi02 = base2,
                isc01 = 0,
                isc02 = 0,
                igv01 = iva1,
                igv02 = 0,
                otc01 = 0,
                otc02 = 0,
                bi01us = base1ME,
                bi02us = base2ME,
                isc01us = 0,
                isc02us = 0,
                igv01us = iva1ME,
                igv02us = 0,
                otc01us = 0,
                otc02us = 0,
                importeCostoMN = 0,
                terminos = "CREDITO",
                ImporteNacional = total,
                ImporteExtranjero = totalME,
                tipoVenta = tipoVenta,
                estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO,
                glosa = "PRE VENTA",
                sustentado = "S",
                idPadre = "0",
                estado = "1",
                estadoEntrega = "1",
                usuarioActualizacion = order.usuarioActualizacion,
                fechaActualizacion = DateTime.Now
            };

            be.documentoventaAbarrotes = obj;
            be.documentoventaAbarrotes.estadoCobro = TIPO_COMPRA.PAGO.PENDIENTE_PAGO;
            be.documentoventaAbarrotes.documentoventaAbarrotesDet = new List<BE.documentoventaAbarrotesDet>();
        }

        private static void MappingDocumentoCompraCabeceraDetalle(BE.documento obj, BE.documentoventaAbarrotes order)
        {
            BE.documentoventaAbarrotesDet objDet;
            foreach (var i in order.documentoventaAbarrotesDet.ToList())
            {

                var Producto = (from prod in Product.GetDetalleitems
                                from unid in prod.detalleitem_equivalencias
                                from cat in unid.detalleitemequivalencia_catalogos
                                where cat.idCatalogo.Equals(i.catalogo_id)
                                select prod).SingleOrDefault();

                switch (Producto.tipoExistencia)
                {
                    case TipoExistencia.ServicioGasto:
                        {
                            i.CustomProducto = Producto;

                            objDet = new BE.documentoventaAbarrotesDet()
                            {
                                AfectoInventario = i.AfectoInventario,
                                CodigoCosto = i.CodigoCosto,
                                CustomProducto = i.CustomProducto,
                                catalogo_id = 0,
                                idItem = i.CustomProducto.codigodetalle.ToString(),
                                nombreItem = i.CustomProducto.descripcionItem,
                                tipoExistencia = i.CustomProducto.tipoExistencia,
                                destino = i.CustomProducto.origenProducto,
                                unidad1 = i.CustomProducto.unidad1,
                                monto1 = i.monto1,
                                equivalencia_id = 0,
                                unidad2 = null,
                                monto2 = i.PrecioUnitarioVentaMN.ToString(),
                                precioUnitario = i.precioUnitario.GetValueOrDefault(),
                                precioUnitarioUS = i.precioUnitarioUS.GetValueOrDefault(),
                                importeMN = i.importeMN,
                                importeME = i.importeME.GetValueOrDefault(),
                                montokardex = i.montokardex,
                                montoIsc = 0,
                                montoIgv = i.montoIgv,
                                otrosTributos = 0,
                                montokardexUS = i.montokardex.GetValueOrDefault(),
                                montoIscUS = 0,
                                montoIgvUS = i.montoIgvUS.GetValueOrDefault(),
                                otrosTributosUS = 0,
                                entregado = "1",
                                estadoPago = i.estadoPago,
                                bonificacion = bool.Parse(i.FlagBonif),
                                descuentoMN = i.descuentoMN.GetValueOrDefault(),
                                usuarioModificacion = obj.usuarioActualizacion,
                                fechaModificacion = DateTime.Now
                            };
                            break;
                        }

                    default:
                        {
                            i.CustomProducto = Producto;

                            var unidadComercial = (from prod in Product.GetDetalleitems
                                                   from unid in prod.detalleitem_equivalencias
                                                   where unid.equivalencia_id.Equals(i.equivalencia_id)
                                                   select unid).SingleOrDefault();

                            i.CustomEquivalencia = unidadComercial;


                            var catalogoPrecio = (from prod in Product.GetDetalleitems
                                                  from unid in prod.detalleitem_equivalencias
                                                  from cat in unid.detalleitemequivalencia_catalogos
                                                  where cat.idCatalogo.Equals(i.catalogo_id)
                                                  select cat).SingleOrDefault();

                            i.CustomCatalogo = catalogoPrecio;

                            if (i.CustomEquivalencia.fraccionUnidad <= 0)
                                throw new Exception($"Debe ingresar un factor de conversión > 0, para el Producto-{i.CustomProducto.descripcionItem}");
                            // precUnitEquivalencia = i.monto1 * i.CustomEquivalencia.fraccionUnidad
                            var BaseImponibleItem = Math.Round((decimal)CalculoBaseImponible(i.importeMN.GetValueOrDefault(), (decimal)1.18), 2);
                            var MontoIvaItem = i.importeMN.GetValueOrDefault() - BaseImponibleItem;

                            objDet = new BE.documentoventaAbarrotesDet()
                            {
                                idAlmacenOrigen = 0,
                                establecimientoOrigen = obj.idCentroCosto,
                                AfectoInventario = i.AfectoInventario,
                                CodigoCosto = i.CodigoCosto,
                                CustomEquivalencia = i.CustomEquivalencia,
                                CustomProducto = i.CustomProducto,
                                CustomCatalogo = i.CustomCatalogo,
                                catalogo_id = i.CustomCatalogo.idCatalogo,
                                idItem = i.CustomProducto.codigodetalle.ToString(),
                                nombreItem = i.CustomProducto.descripcionItem,
                                tipoExistencia = i.CustomProducto.tipoExistencia,
                                destino = i.CustomProducto.origenProducto,
                                unidad1 = i.CustomProducto.unidad1,
                                monto1 = i.monto1,
                                equivalencia_id = i.CustomEquivalencia.equivalencia_id,
                                unidad2 = null,
                                monto2 = i.PrecioUnitarioVentaMN.ToString(),
                                precioUnitario = i.monto1 * i.CustomEquivalencia.fraccionUnidad,
                                precioUnitarioUS = i.precioUnitarioUS.GetValueOrDefault(),
                                importeMN = i.importeMN,
                                importeME = i.importeME.GetValueOrDefault(),
                                montokardex = BaseImponibleItem,
                                montoIsc = 0,
                                montoIgv = MontoIvaItem,
                                otrosTributos = 0,
                                montokardexUS = i.montokardexUS.GetValueOrDefault(),
                                montoIscUS = 0,
                                montoIgvUS = i.montoIgvUS.GetValueOrDefault(),
                                otrosTributosUS = 0,
                                entregado = "1",
                                estadoPago = "PN",
                                bonificacion = bool.Parse(i.FlagBonif),
                                descuentoMN = i.descuentoMN.GetValueOrDefault(),
                                usuarioModificacion = i.usuarioModificacion,
                                fechaModificacion = DateTime.Now
                            };
                            break;
                        }
                }



                //if (btGrabar.Text == "Editar - F2")
                //{
                //    objDet.idDocumento = venta.idDocumento;
                //    objDet.secuencia = i.secuencia;
                //}

                obj.documentoventaAbarrotes.documentoventaAbarrotesDet.Add(objDet);
            }
        }

        public static void EnviarFacturaElectronica(BE.documento doc, int idPSE)
        {
            //var documentoSA = new documentoVentaAbarrotesSA();
            //var documentoDetSA = new documentoVentaAbarrotesDetSA();
            //var entidadSA = new entidadSA();
            Fact.Sunat.Business.Entity.DocumentoElectronicoDetalle DetalleFactura;
            try
            {
                var comprobante = doc.documentoventaAbarrotes; // documentoSA.GetVentaID(New documento With {.idDocumento = doc.idDocumento})
                                                               // Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(doc.idDocumento)
                var receptor = comprobante.CustomEntidad; // entidadSA.GetUbicarEntPorID(Gempresas.IdEmpresaRuc, comprobante.idCliente)
                string numerovent = string.Format("{0:00000000}", comprobante.numeroVenta);
                string tipoDoc = string.Format("{0:00}", comprobante.tipoDocumento);
                int conteo = 0;
                // //Enviando el documento
                var Factura = new Fact.Sunat.Business.Entity.DocumentoElectronico();
                // Datos del Cliente 
                Factura.Action = 0;
                Factura.idEmpresa = idPSE; // lblIdPse.Text
                Factura.Contribuyente_id = LoginInformation.Empresa.idEmpresa;
                Factura.EnvioSunat = "NO";
                // Receptor de la Factura
                Factura.NroDocumentoRec = receptor.nrodoc;
                Factura.TipoDocumentoRec = receptor.tipoDoc;
                Factura.NombreLegalRec = receptor.nombreCompleto;
                // Datos Generales De La Factura
                Factura.IdDocumento = comprobante.serieVenta + "-" + numerovent;
                Factura.FechaEmision = comprobante.fechaDoc;
                Factura.FechaRecepcion = DateTime.Now; // fecha en la que se envia al PSE
                Factura.FechaVencimiento = DateTime.Now;
                Factura.HoraEmision = comprobante.fechaDoc.Value.ToString("HH:mm:ss");
                Factura.TipoDocumento = tipoDoc;
                Factura.TipoOperacion = "0101";
                Factura.TotalIcbper = comprobante.icbper.GetValueOrDefault();

                if (comprobante.importeCostoMN.GetValueOrDefault() > 0)
                    Factura.DescuentoGlobal = comprobante.importeCostoMN;
                else
                    Factura.DescuentoGlobal = 0;

                if (comprobante.moneda == "1")
                {
                    Factura.Moneda = "PEN";
                    Factura.TotalIgv = comprobante.igv01;
                    Factura.TotalVenta = comprobante.ImporteNacional; // + Factura.DescuentoGlobal.GetValueOrDefault
                    Factura.Gravadas = comprobante.bi01;
                    Factura.Exoneradas = comprobante.bi02;
                }
                else if (comprobante.moneda == "2")
                {
                    Factura.Moneda = "USD";
                    Factura.TotalIgv = comprobante.igv01us;
                    Factura.TotalVenta = comprobante.ImporteExtranjero; // + Factura.DescuentoGlobal.GetValueOrDefault
                    Factura.Gravadas = comprobante.bi01us;
                    Factura.Exoneradas = comprobante.bi02us;
                }

                // Cargando el Detalle de la Factura
                decimal precioSinIva = 0;
                decimal precioConIva = 0;
                decimal cantEquiva = 0;
                foreach (var i in comprobante.documentoventaAbarrotesDet)
                {
                    DetalleFactura = new Fact.Sunat.Business.Entity.DocumentoElectronicoDetalle();
                    switch (i.tipoExistencia)
                    {
                        case TipoExistencia.ServicioGasto:
                            {
                                cantEquiva = Decimal.Parse(i.monto1.ToString()); // 1
                                DetalleFactura.CodigoItem =Convert.ToString(1);
                                break;
                            }

                        default:
                            {
                                Decimal quantity = i.monto1.GetValueOrDefault();
                                Decimal unidadfraccion = i.CustomEquivalencia.fraccionUnidad.GetValueOrDefault();
                                //cantEquiva = Decimal.Parse(i.monto1 * i.CustomEquivalencia.fraccionUnidad.GetValueOrDefault());
                                cantEquiva = quantity * unidadfraccion;
                                DetalleFactura.CodigoItem = i.idItem;
                                break;
                            }
                    }

                   // Decimal montoKardexval = i.montokardex.GetValueOrDefault();
                    //precioSinIva = Decimal.Parse(i.montokardex.GetValueOrDefault().ToString() / cantEquiva);
                    precioSinIva = i.montokardex.GetValueOrDefault() / cantEquiva;
                    precioConIva = i.importeMN.GetValueOrDefault() / cantEquiva;

                    conteo += 1;

                    DetalleFactura.Id = conteo;
                    DetalleFactura.Cantidad = cantEquiva; // i.monto1 * i.CustomEquivalencia.fraccionUnidad.GetValueOrDefault 'i.monto1


                    DetalleFactura.Descripcion = i.nombreItem;
                    DetalleFactura.UnidadMedida = i.unidad1;

                    if (comprobante.moneda == "1")
                    {
                        DetalleFactura.PrecioReferencial = precioConIva; // i.precioUnitario
                        DetalleFactura.Impuesto = i.montoIgv;
                        DetalleFactura.TotalVenta = i.montokardex;
                        if (i.destino == "1")
                        {
                            DetalleFactura.TipoImpuesto = "10"; // CATALOGO 7
                            DetalleFactura.TipoPrecio = "01"; // CATALOGO 16
                            DetalleFactura.PrecioUnitario = precioSinIva; // CalculoBaseImponible(i.precioUnitario, 1.18) 'FormatNumber(CalculoBaseImponible(i.precioUnitario, 1.18), 2)
                        }
                        else if (i.destino == "2")
                        {
                            DetalleFactura.TipoImpuesto = "20"; // CATALOGO 7
                            DetalleFactura.TipoPrecio = "01"; // "02"  'CATALOGO 16
                            DetalleFactura.PrecioUnitario = precioConIva; // i.precioUnitario
                        }
                    }
                    else if (comprobante.moneda == "2")
                    {
                    }
                    // DetalleItems .Descuento = "falta"
                    // DetalleItems .ImpuestoSelectivo = "falta"
                    // DetalleItems.OtroImpuesto = "falta"
                    // DetalleItems.PlacaVehiculo = "falta"
                    if (i.tasaIcbper.GetValueOrDefault() > 0)
                    {
                        DetalleFactura.TotalIcbper = i.montoIcbper.GetValueOrDefault();
                        DetalleFactura.ImpuestoIcbper = i.tasaIcbper.GetValueOrDefault();
                        DetalleFactura.CantidadBolsa = int.Parse(cantEquiva.ToString());
                    }
                    else
                    {
                        DetalleFactura.TotalIcbper = 0;
                        DetalleFactura.ImpuestoIcbper = 0;
                        DetalleFactura.CantidadBolsa = 0;
                    }
                    Factura.DocumentoElectronicoDetalle.Add(DetalleFactura);
                }
                // Enviando al PSE
                var codigo = Helios.Fact.Sunat.WCFService.ServiceAccess.Admin.DocumentoElectronicoSA.DocumentoElectronicoSaveValidado(Factura, null);

                if (codigo.idDocumentoElectronico > 0)
                    UpdateEnvioSunatEstado(comprobante.idDocumento, "SI");
            }
            catch (Exception ex)
            {
            }
        }

        public static void UpdateEnvioSunatEstado(int idDoc, string estado)
        {
            try
            {
                var docSA = new documentoVentaAbarrotesSA();
                docSA.UpdateFacturasXEstado(idDoc, estado);
            }
            catch (Exception ex)
            {
            }
        }

       
    }
}