Imports System.Data.Entity.Migrations
Imports System.Transactions
Imports Helios.Cont.Business.Entity

Public Class Ruta_HorarioServiciosBL
    Inherits BaseBL

    Public Function GetServiciosVentaTransporte(be As ruta_HorarioServicios) As List(Of ruta_HorarioServicios)
        Return HeliosData.ruta_HorarioServicios.Where(Function(o) o.ruta_id = be.ruta_id And o.horario_id = be.horario_id).ToList
    End Function

    Public Sub ActualizarPrecio(be As ruta_HorarioServicios)
        Using ts As New TransactionScope
            Dim serv = HeliosData.ruta_HorarioServicios.Where(Function(o) o.codigoServicio = be.codigoServicio).SingleOrDefault
            serv.costoEstimado = be.costoEstimado
            'HeliosData.ruta_HorarioServicios.AddOrUpdate(be)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

End Class
