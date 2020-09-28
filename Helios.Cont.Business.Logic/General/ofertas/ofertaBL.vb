Imports System.Data.Entity.Migrations
Imports System.Transactions
Imports Helios.Cont.Business.Entity
Public Class ofertaBL
    Inherits BaseBL

    Public Sub SaveOferta(be As oferta)
        Using ts As New TransactionScope
            If be.Action = BaseBE.EntityAction.INSERT Then
                HeliosData.oferta.Add(be)
            Else
                HeliosData.oferta.AddOrUpdate(be)
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function OfertaSel(be As oferta) As oferta
        Return HeliosData.oferta.Where(Function(o) o.id = be.id).SingleOrDefault
    End Function

    Public Function OfertaSelCodigo(be As oferta) As oferta
        Return HeliosData.oferta.Where(Function(o) o.idemprea = be.idemprea And o.codigo = be.codigo).SingleOrDefault
    End Function

    Public Function OfertaSelAll(be As oferta) As List(Of oferta)
        Return HeliosData.oferta.Where(Function(o) o.idemprea = be.idemprea).ToList
    End Function

End Class
