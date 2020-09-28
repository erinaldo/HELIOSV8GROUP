Imports System.Transactions
Imports Helios.Cont.Business.Entity
Public Class clasehorariosBL
    Inherits BaseBL

    Public Sub GrabarHorario(be As clasehorarios)
        Using ts As New TransactionScope
            HeliosData.clasehorarios.Add(be)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function GetUbicarActividadGYMDetalle(idActividad As Integer) As List(Of clasehorarios)

        Dim con = (From n In HeliosData.clasehorarios
                   Where n.idActividad = idActividad).ToList


        'Dim obj = HeliosData.actividadPersonal.
        'Include("clasehorarios").Where(Function(o) o.idActividad = idActividad).
        'Select(Function(c) c).FirstOrDefault()

        Return con


    End Function

End Class
