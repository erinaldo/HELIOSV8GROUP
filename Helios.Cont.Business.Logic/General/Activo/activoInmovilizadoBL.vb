Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class activoInmovilizadoBL
    Inherits BaseBL

    Public Function Insert(ByVal activoInmovilizadoBE As activoInmovilizado) As Integer
        Using ts As New TransactionScope
            HeliosData.activoInmovilizado.Add(activoInmovilizadoBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return activoInmovilizadoBE.idActivo
        End Using
    End Function

   
    Public Sub Update(ByVal activoInmovilizadoBE As activoInmovilizado)
        Using ts As New TransactionScope
            Dim activo As activoInmovilizado = HeliosData.activoInmovilizado.Where(Function(o) o.idActivo = activoInmovilizadoBE.idActivo _
                                                And o.idEmpresa = activoInmovilizadoBE.idEmpresa _
                                                And o.idEstablecimiento = activoInmovilizadoBE.idEstablecimiento).First()
            activo.descripcion = activoInmovilizadoBE.descripcion
            activo.codigoCuenta = activoInmovilizadoBE.codigoCuenta
            activo.usuarioActualizacion = activoInmovilizadoBE.usuarioActualizacion
            activo.fechaActualizacion = activoInmovilizadoBE.fechaActualizacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(activo).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal activoInmovilizadoBE As activoInmovilizado)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(activoInmovilizadoBE)
    End Sub

    Public Function GetListar_activoInmovilizado() As List(Of activoInmovilizado)
        Return (From a In HeliosData.activoInmovilizado Select a).ToList
    End Function

    Public Function GetUbicar_activoInmovilizadoPorID(idActivo As String) As activoInmovilizado
        Return (From a In HeliosData.activoInmovilizado
                Where a.idActivo = idActivo Select a).First
    End Function
End Class
