Imports System.Transactions
Imports Helios.Cont.Business.Entity

Public Class totalesAlmacenOthersBL
    Inherits BaseBL

    Public Sub EliminarPorDocumentoVenta(IDDocumento As Integer)
        Using ts As New TransactionScope

            Dim con = HeliosData.totalesAlmacenOthers.Where(Function(o) o.idDocumento = IDDocumento).ToList
            HeliosData.totalesAlmacenOthers.RemoveRange(con)

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function GetInventarioSelCodigo(be As totalesAlmacenOthers) As List(Of totalesAlmacenOthers)
        'Dim con = HeliosData.totalesAlmacenOthers.Where(Function(o) o.idProducto = be.idProducto And o.cantidad > 0).ToList
        Dim con = HeliosData.totalesAlmacenOthers.Where(Function(o) o.idProducto = be.idProducto).ToList
        Return MappingInventario(con)
    End Function

    Private Function MappingInventario(lst As List(Of totalesAlmacenOthers)) As List(Of totalesAlmacenOthers)
        MappingInventario = New List(Of totalesAlmacenOthers)
        For Each i In lst
            MappingInventario.Add(New totalesAlmacenOthers With
                                  {
                                  .idMovimiento = i.idMovimiento,
                                  .idProducto = i.idProducto,
                                  .id_equivalencia = i.id_equivalencia,
                                  .idcategoria = i.idcategoria,
                                  .idalmacen = i.idalmacen,
                                  .genero = i.genero,
                                  .cantidad = i.cantidad,
                                  .tipoRegistro = i.tipoRegistro,
                                  .status = i.status
                                  })
        Next
    End Function

    Public Sub CurarTotalesTallas(be As totalesAlmacenOthers)
        Using ts As New TransactionScope
            '  Dim listado = HeliosData.totalesAlmacenOthers.Where(Function(o) o.idProducto = be.idProducto And o.id_equivalencia = be.id_equivalencia).Sum()


            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub

End Class
