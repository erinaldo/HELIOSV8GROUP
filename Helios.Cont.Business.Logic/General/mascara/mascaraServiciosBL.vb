Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class mascaraServiciosBL
    Inherits BaseBL

    Public Function Insert(ByVal mascaraServiciosBE As mascaraServicios) As Integer
        Using ts As New TransactionScope
            HeliosData.mascaraServicios.Add(mascaraServiciosBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return mascaraServiciosBE.idMascara
        End Using
    End Function

    Public Sub Update(ByVal mascaraServiciosBE As mascaraServicios)
        Using ts As New TransactionScope
            Dim maskServ As mascaraServicios = HeliosData.mascaraServicios.Where(Function(o) _
                                            o.idMascara = mascaraServiciosBE.idMascara).First()

            maskServ.cuentaCompra = mascaraServiciosBE.cuentaCompra
            maskServ.descripcionCompra = mascaraServiciosBE.descripcionCompra
            maskServ.cuentaCostoProcesoDebe = mascaraServiciosBE.cuentaCostoProcesoDebe
            maskServ.descripcionCostoProcesoDebe = mascaraServiciosBE.descripcionCostoProcesoDebe
            maskServ.cuentaCostoProcesoHaber = mascaraServiciosBE.cuentaCostoProcesoHaber
            maskServ.descripcionCostoProcesoHaber = mascaraServiciosBE.descripcionCostoProcesoHaber
            maskServ.cuentaConclusionProcesoDebe = mascaraServiciosBE.cuentaConclusionProcesoDebe
            maskServ.descripcionConclusionDebe = mascaraServiciosBE.descripcionConclusionDebe
            maskServ.cuentaConclusionProcesoHaber = mascaraServiciosBE.cuentaConclusionProcesoHaber
            maskServ.descripcionConclusionHaber = mascaraServiciosBE.descripcionConclusionHaber
            maskServ.cuentaDestinoDebe = mascaraServiciosBE.cuentaDestinoDebe
            maskServ.descripcionDestinoDebe = mascaraServiciosBE.descripcionDestinoDebe
            maskServ.cuentaDestinoHaber = mascaraServiciosBE.cuentaDestinoHaber
            maskServ.descripcionDestinoHaber = mascaraServiciosBE.descripcionDestinoHaber
            maskServ.usuarioActualizacion = mascaraServiciosBE.usuarioActualizacion
            maskServ.fechaActualizacion = mascaraServiciosBE.fechaActualizacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(maskServ).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub Delete(ByVal mascaraServiciosBE As mascaraServicios)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(mascaraServiciosBE)
    End Sub

    Public Function GetListar_mascaraServicios() As List(Of mascaraServicios)
        Return (From a In HeliosData.mascaraServicios Select a).ToList
    End Function

    Public Function GetUbicar_mascaraServiciosPorID(idMascara As Integer) As mascaraServicios
        Return (From a In HeliosData.mascaraServicios
                 Where a.idMascara = idMascara Select a).First
    End Function
End Class
