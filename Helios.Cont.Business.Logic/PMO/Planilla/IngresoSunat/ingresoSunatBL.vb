Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class ingresoSunatBl
    Inherits BaseBL

    Function GetUbicarTablaNombre(intIdPadre As Integer)
        Return (From a In HeliosData.ingresoSunat _
                Where a.idPadre = intIdPadre _
                Select a).ToList
    End Function

    Public Function Insert(ByVal ingresosunatBE As ingresoSunat) As Integer
        Using ts As New TransactionScope
            HeliosData.ingresoSunat.Add(ingresosunatBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return ingresosunatBE.codigoSunat
        End Using
    End Function

    Public Sub Update(ByVal ingresosunatBE As ingresoSunat)
        Using ts As New TransactionScope
            HeliosData.ingresoSunat.Add(ingresosunatBE)
            HeliosData.Entry(ingresosunatBE).State = System.Data.Entity.EntityState.Modified
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub Delete(ByVal ingresosunatBE As ingresoSunat)
        Using ts As New TransactionScope
            Dim consulta = (From n In HeliosData.ingresoSunat _
                          Where n.idIngresoSunat = ingresosunatBE.idIngresoSunat).First
            CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub



End Class
