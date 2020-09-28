using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SA = Helios.Cont.WCFService.ServiceAccess;
using BE = Helios.Cont.Business.Entity;
using Helios.Cont.Presentation.Web.Models;
using static Helios.General.Constantes;

namespace Helios.Cont.Presentation.Web.Models
{
    public static class DocumentoOperation
    {

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
                fechaProceso =DateTime.Now,//  DateTime.Parse(order.fechaDoc.ToString()),
                moneda = order.moneda,//cboMoneda.Text == "NUEVO SOL" ? "1" : "2",
                idEntidad = order.idCliente.GetValueOrDefault(),
                entidad = order.NombreEntidad,
                tipoEntidad = TIPO_ENTIDAD.CLIENTE,
                nrodocEntidad =order.NroDocEntidad,
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
                idPadre = 0,
                estado = "1",
                estadoEntrega = "1",
                usuarioActualizacion = order.usuarioActualizacion,
                fechaActualizacion = DateTime.Now
            };
           
            be.documentoventaAbarrotes = obj;            
            be.documentoventaAbarrotes.estadoCobro = TIPO_COMPRA.PAGO.PENDIENTE_PAGO;
            be.documentoventaAbarrotes.documentoventaAbarrotesDet = new List<BE.documentoventaAbarrotesDet>();
        }

        private static void MappingDocumentoCompraCabeceraDetalle(BE.documento obj,  BE.documentoventaAbarrotes order)
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
                            var BaseImponibleItem = Math.Round((decimal)CalculoBaseImponible(i.importeMN.GetValueOrDefault(), (decimal)1.18),2);
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


    }
}