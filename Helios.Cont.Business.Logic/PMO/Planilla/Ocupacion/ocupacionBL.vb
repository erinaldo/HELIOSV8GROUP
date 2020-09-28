Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class ocupacionBL
    Inherits BaseBL


    Function GetUbicarOcupacion(codOcupacion As Integer)
        Return (From a In HeliosData.ocupacion _
                Where a.idEstablecimiento = codOcupacion _
                Select a).ToList
    End Function


    Function GetUbicarOcupacionPorNombre(strNombre As String, intEstable As Integer) As ocupacion
        Return (From a In HeliosData.ocupacion _
                Where a.nombreOcupacion = strNombre _
                And a.idEstablecimiento = intEstable _
                Select a).First
    End Function

    Function GetUbicarOcupacionPorID(intIdOcupacion As Integer) As ocupacion
        Return (From a In HeliosData.ocupacion _
                Where a.codOcupacion = intIdOcupacion _
                Select a).First
    End Function


    Public Function Insert(ByVal ocupacionBE As ocupacion) As Integer
        Using ts As New TransactionScope
            HeliosData.ocupacion.Add(ocupacionBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return ocupacionBE.codOcupacion
        End Using
    End Function


    Public Sub Update(ByVal ocupacionBE As ocupacion)
        Using ts As New TransactionScope
            HeliosData.ocupacion.Add(ocupacionBE)
            HeliosData.Entry(ocupacionBE).State = System.Data.Entity.EntityState.Modified
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub Delete(ByVal ocupacionBE As ocupacion)
        Using ts As New TransactionScope
            Dim consulta = (From n In HeliosData.ocupacion _
                          Where n.codOcupacion = ocupacionBE.codOcupacion).First
            CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

End Class
