Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class cierreEntregablesBL
    Inherits BaseBL

    Public Function Insert(ByVal cierreCostoVentaBE As cierreEntregables, iddocRef As Integer) As Integer
        Dim cierre As New cierreEntregables
        Using ts As New TransactionScope
            With cierre
                .idEmpresa = cierreCostoVentaBE.idEmpresa
                .idCentroCosto = cierreCostoVentaBE.idCentroCosto
                .periodo = cierreCostoVentaBE.periodo
                .dia = cierreCostoVentaBE.dia
                .mes = cierreCostoVentaBE.mes
                .anio = cierreCostoVentaBE.anio
                .importe = cierreCostoVentaBE.importe
                .tipoOperacion = cierreCostoVentaBE.tipoOperacion
                .importeUS = cierreCostoVentaBE.importeUS
                .usuarioModificacion = cierreCostoVentaBE.usuarioModificacion
                .fechaModificacion = cierreCostoVentaBE.fechaModificacion
                .idDocumento = iddocRef
                .idCosto = cierreCostoVentaBE.idCosto
            End With
            HeliosData.cierreEntregables.Add(cierre)
            HeliosData.SaveChanges()
            ts.Complete()
            Return 0
        End Using
    End Function

End Class
