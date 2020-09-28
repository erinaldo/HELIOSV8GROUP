using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SA = Helios.Cont.WCFService.ServiceAccess;
using BE = Helios.Cont.Business.Entity;
using static Helios.General.Constantes;

namespace Helios.Retail.Helpers
{
    public static class DocumentoOperation
    {
        public static void SaveOrder(BE.documento order)
        {
            SA.documentoVentaAbarrotesSA ventaSA = new SA.documentoVentaAbarrotesSA();
            var doc = FillDocumento(order);
            FillDocumentoCompraCabecera(doc, order.documentoventaAbarrotes);
            FillDocumentoCompraCabeceraDetalle(doc, order.documentoventaAbarrotes);
            ventaSA.GrabarVentaEquivalenciaXInfra(doc);
            UpdateInfraestructura(order.documentoventaAbarrotes);
        }

        private static void UpdateInfraestructura(BE.documentoventaAbarrotes documentoventaAbarrote)
        {
            var distribucionSA = new SA.distribucionInfraestructuraSA();
            var distribucion = new BE.distribucionInfraestructura()
            {
                idEmpresa = documentoventaAbarrote.idEmpresa,
                idEstablecimiento = documentoventaAbarrote.idEstablecimiento,
                idDistribucion = documentoventaAbarrote.documentoventaAbarrotesDet.FirstOrDefault().idDistribucion.GetValueOrDefault(),
                estado = "P",
            };
            distribucionSA.updateDistribucionxID(distribucion);
        }

        public static void UpdateInfraestructuraXDistribucionID(BE.distribucionInfraestructura  Distribucion)
        {
            var distribucionSA = new SA.distribucionInfraestructuraSA();
            var distribucion = new BE.distribucionInfraestructura()
            {
                idEmpresa = Distribucion.idEmpresa,
                idEstablecimiento = Distribucion.idEstablecimiento,
                idDistribucion = Distribucion.idDistribucion ,
                estado = Distribucion.estado
            };
            distribucionSA.updateDistribucionxID(distribucion);
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
                fechaActualizacion = DateTime.Now
            };
            return documento;
        }

        private static void FillDocumentoCompraCabecera(BE.documento be, BE.documentoventaAbarrotes order)
        {
            BE.documentoventaAbarrotes obj = new BE.documentoventaAbarrotes()
            {
                codigoLibro = order.codigoLibro,
                idEmpresa = order.idEmpresa,
                idEstablecimiento = order.idEstablecimiento,
                fechaLaboral = DateTime.Now,
                fechaDoc = DateTime.Now,
                fechaVcto = null,
                tipoOperacion = order.tipoOperacion,
                fechaPeriodo = GetPeriodo(be.fechaProceso, true),
                tipoDocumento = order.tipoDocumento,
                idClientePedido = order.idClientePedido,
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
                estado = "1",
                estadoEntrega = "1",
                usuarioActualizacion = order.usuarioActualizacion,
                fechaActualizacion = DateTime.Now
            };

            be.documentoventaAbarrotes = obj;
            be.documentoventaAbarrotes.estadoCobro = TIPO_COMPRA.PAGO.PENDIENTE_PAGO;
            be.documentoventaAbarrotes.documentoventaAbarrotesDet = new List<BE.documentoventaAbarrotesDet>();
        }

        private static void FillDocumentoCompraCabeceraDetalle(BE.documento obj, BE.documentoventaAbarrotes order)
        {
            BE.documentoventaAbarrotesDet objDet;
            foreach (var i in order.documentoventaAbarrotesDet.ToList())
            {
                objDet = new BE.documentoventaAbarrotesDet()
                {
                    idAlmacenOrigen = 0,
                    establecimientoOrigen = obj.idCentroCosto,
                    AfectoInventario = i.AfectoInventario,
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
                    unidad2 = i.unidad2,
                    monto2 = i.monto2,
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
                    entregado = i.entregado,
                    estadoPago = "PN",
                    bonificacion = false,
                    descuentoMN = 0,
                    estadoEntrega = "PN",
                    montoIcbper = 0,
                    montoIcbperUS = 0,
                    tasaIcbper = 0,
                    tipoVenta = i.tipoVenta,
                    detalleAdicional = i.detalleAdicional,
                    idDistribucion = i.idDistribucion,
                    estadoDistribucion = i.estadoDistribucion,
                    usuarioModificacion = i.usuarioModificacion,
                    fechaModificacion = DateTime.Now
                };

                obj.documentoventaAbarrotes.documentoventaAbarrotesDet.Add(objDet);
            }
        }
    }
}