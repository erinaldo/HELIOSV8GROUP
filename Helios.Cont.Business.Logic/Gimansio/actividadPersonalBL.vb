Imports System.Transactions
Imports Helios.Cont.Business.Entity
Imports System.Data.Entity.Migrations
Public Class actividadPersonalBL
    Inherits BaseBL

    Public Sub EditarActividadGym(be As actividadPersonal)
        Using ts As New TransactionScope
            Dim detalle = HeliosData.clasehorarios.Where(Function(o) o.idActividad = be.idActividad).ToList
            For Each i In detalle
                CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(i)
            Next
            HeliosData.actividadPersonal.AddOrUpdate(be)
            For Each det In be.clasehorarios
                HeliosData.clasehorarios.Add(det)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub GrabarActividad(be As actividadPersonal)
        Using ts As New TransactionScope
            HeliosData.actividadPersonal.Add(be)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function GetActividadesEmpresa(be As actividadPersonal) As List(Of actividadPersonal)
        Dim consulta = (From n In HeliosData.actividadPersonal
                        Select n).ToList

        Return consulta
    End Function

    Public Function GetUbicarActividadGYM(idActividad As Integer) As actividadPersonal

        Dim con = (From n In HeliosData.actividadPersonal
                   Where n.idActividad = idActividad).FirstOrDefault


        'Dim obj = HeliosData.actividadPersonal.
        'Include("clasehorarios").Where(Function(o) o.idActividad = idActividad).
        'Select(Function(c) c).FirstOrDefault()

        Return con


    End Function
End Class
