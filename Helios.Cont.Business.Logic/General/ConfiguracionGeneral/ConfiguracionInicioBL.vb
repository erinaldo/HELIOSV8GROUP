Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class ConfiguracionInicioBL
    Inherits BaseBL

    Public Sub Insert(configBE As configuracionInicio)
        Dim configiracionBE As New configuracionInicio
        Using ts As New TransactionScope()
            With configBE
                configiracionBE.idEmpresa = .idEmpresa
                configiracionBE.periodo = .periodo
                configiracionBE.anio = .anio
                configiracionBE.mes = .mes
                configiracionBE.dia = .dia
                configiracionBE.tipocambio = .tipocambio
                configiracionBE.iva = .iva
                configiracionBE.tipoIva = .tipoIva
                configiracionBE.idalmacenVenta = .idalmacenVenta
                configiracionBE.idCentroCosto = .idCentroCosto
                configiracionBE.retencion4ta = .retencion4ta
                configiracionBE.entidadFinanciera = .entidadFinanciera
                configiracionBE.montoMaximo = .montoMaximo
                configiracionBE.tipoCambioTransacCompra = .tipoCambioTransacCompra
                configiracionBE.tipoCambioTransacVenta = .tipoCambioTransacVenta

            End With
            HeliosData.configuracionInicio.Add(configiracionBE)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub EditarTipoCambio(tipocambio As Decimal)
        Dim configiracionBE As configuracionInicio = HeliosData.configuracionInicio.Where(Function(o) o.idEmpresa = Gempresas.IdEmpresaRuc).FirstOrDefault
        Using ts As New TransactionScope()
            configiracionBE.tipocambio = tipocambio
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub EditarV00(configBE As configuracionInicio)
        Dim configiracionBE As configuracionInicio = HeliosData.configuracionInicio.Where(Function(o) o.idEmpresa = configBE.idEmpresa).FirstOrDefault
        Using ts As New TransactionScope()
            configiracionBE.tipocambio = configBE.tipocambio
            configiracionBE.iva = configBE.iva
            configiracionBE.montoMaximo = configBE.montoMaximo
            configiracionBE.FormatoVenta = configBE.FormatoVenta
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Editar(configBE As configuracionInicio)
        Dim configiracionBE As configuracionInicio = HeliosData.configuracionInicio.Where(Function(o) o.idEmpresa = configBE.idEmpresa And o.idCentroCosto = configBE.idCentroCosto).FirstOrDefault
        Using ts As New TransactionScope()
            With configBE
                configiracionBE.periodo = .periodo
                configiracionBE.anio = .anio
                configiracionBE.mes = .mes
                configiracionBE.dia = .dia
                configiracionBE.tipocambio = .tipocambio
                configiracionBE.iva = .iva
                configiracionBE.tipoIva = .tipoIva
                configiracionBE.idalmacenVenta = .idalmacenVenta
                configiracionBE.entidadFinanciera = .entidadFinanciera
                configiracionBE.idCentroCosto = .idCentroCosto
                configiracionBE.retencion4ta = .retencion4ta
                configiracionBE.montoMaximo = .montoMaximo
                configiracionBE.tipoCambioTransacCompra = .tipoCambioTransacCompra
                configiracionBE.tipoCambioTransacVenta = .tipoCambioTransacVenta

            End With
            'HeliosData.ObjectStateManager.GetObjectStateEntry(configiracionBE).State.ToString()
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub EditarConfiguracionGeneral(configBE As configuracionInicio)
        Dim configiracionBE As configuracionInicio = HeliosData.configuracionInicio.Where(Function(o) o.idEmpresa = configBE.idEmpresa).FirstOrDefault
        Using ts As New TransactionScope()
            With configBE
                configiracionBE.proyecto = .proyecto
                configiracionBE.produccionLotes = .produccionLotes
                configiracionBE.cronogramaPagos = .cronogramaPagos
                configiracionBE.HC_SERV_EDUCAT = .HC_SERV_EDUCAT
                configiracionBE.HC_VENTA_MERCADERIA = .HC_VENTA_MERCADERIA
                configiracionBE.HC_PRODUCCION = .HC_PRODUCCION
                configiracionBE.HC_CONS_INMED = .HC_CONS_INMED
                configiracionBE.HC_CONSTRUCC = .HC_CONSTRUCC
                configiracionBE.HC_SERV_VARIOS = .HC_SERV_VARIOS
                configiracionBE.HC_SERV_TRANSP = .HC_SERV_TRANSP
                configiracionBE.HC_SERV_HOTELERIA = .HC_SERV_HOTELERIA
                configiracionBE.HC_ARRENDAMIENTO = .HC_ARRENDAMIENTO
                configiracionBE.HG_ADMIN = .HG_ADMIN
                configiracionBE.HG_GASTO_VENTAS = .HG_GASTO_VENTAS
                configiracionBE.HG_ACTIVOS = .HG_ACTIVOS
            End With
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Eliminar(configBE As configuracionInicio)
        Dim configiracionBE As configuracionInicio = HeliosData.configuracionInicio.Where(Function(o) o.idEmpresa = configBE.idEmpresa).FirstOrDefault
        Using ts As New TransactionScope()
            CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(configiracionBE)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function ObtenerConfigXempresa(strIdEmpresa As String, intIdEstaclecimiento As Integer) As configuracionInicio
        Return HeliosData.configuracionInicio.Where(Function(o) o.idEmpresa = strIdEmpresa And o.idCentroCosto = intIdEstaclecimiento).FirstOrDefault
    End Function

End Class
