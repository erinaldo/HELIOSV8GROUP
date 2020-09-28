Imports System.Transactions
Imports Helios.Cont.Business.Entity

Public Class inventarioTransitoBL
    Inherits BaseBL

    Public Sub EliminarInventario(idDocumentoCompra As Integer)
        Using ts As New TransactionScope
            Dim obj = HeliosData.inventarioTransito.Where(Function(o) o.idDocumentoCompra = idDocumentoCompra).ToList

            HeliosData.inventarioTransito.RemoveRange(obj)

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    'Private Sub Eliminar(i As inventarioTransito)
    '    Using ts As New TransactionScope

    '        Dim obj = HeliosData.inventarioTransito

    '        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(obj)
    '        HeliosData.SaveChanges()

    '        HeliosData.SaveChanges()
    '        ts.Complete()
    '    End Using
    'End Sub
End Class
