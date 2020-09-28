Imports Helios.Cont.Business.Entity
Imports System.Transactions
Public Class recursoCostoLoteBL
    Inherits BaseBL

    Public Function GetLotesSelVerificacion(be As recursoCostoLote) As List(Of recursoCostoLote)
        Dim con = HeliosData.recursoCostoLote _
            .Join(HeliosData.documentocompra, Function(tot) tot.idDocumento, Function(al) al.idDocumento, Function(tot, al) _
                                               New With {
                                               .compra = al,
                                               .lote = tot
                                               }) _
        .Join(HeliosData.detalleitems, Function(tot1) tot1.lote.codigoProducto, Function(al1) al1.codigodetalle, Function(tot1, al1) _
                                               New With {
                                               .compra = tot1.compra,
                                               .lote = tot1.lote,
                                               .detalleitem = al1
                                               }) _
        .Where(Function(i) i.lote.verificado = be.verificado).ToList

        GetLotesSelVerificacion = New List(Of recursoCostoLote)
        Dim obj As recursoCostoLote
        For Each i In con
            obj = New recursoCostoLote()
            obj.CustomCompra = New documentocompra With
            {
            .idDocumento = i.compra.idDocumento,
            .fechaDoc = i.compra.fechaDoc,
            .tipoDoc = i.compra.tipoDoc,
            .serie = i.compra.serie,
            .numeroDoc = i.compra.numeroDoc,
            .idProveedor = i.compra.idProveedor
            }
            obj.codigoProducto = i.lote.codigoProducto
            obj.codigoLote = i.lote.codigoLote
            obj.nroLote = i.lote.nroLote
            obj.detalle = i.lote.detalle
            obj.cantidad = i.lote.cantidad
            obj.precioUnitarioIva = i.lote.precioUnitarioIva
            obj.precioUnitarioIvaME = i.lote.precioUnitarioIvaME
            obj.verificado = i.lote.verificado

            obj.CustomProducto = New detalleitems With
            {
            .idItem = i.detalleitem.idItem,
            .codigodetalle = i.detalleitem.codigodetalle,
            .descripcionItem = i.detalleitem.descripcionItem,
            .unidad1 = i.detalleitem.unidad1,
            .unidad2 = i.detalleitem.unidad2,
            .origenProducto = i.detalleitem.origenProducto,
            .tipoExistencia = i.detalleitem.tipoExistencia
            }

            GetLotesSelVerificacion.Add(obj)
        Next

    End Function
    Public Function GetLotes() As List(Of recursoCostoLote)

        Return HeliosData.recursoCostoLote.ToList()

    End Function

    Public Sub DeleteLote(ByVal codigoLote As Integer)
        Using ts As New TransactionScope
            Dim consulta As recursoCostoLote = HeliosData.recursoCostoLote.Where(Function(o) o.codigoLote = codigoLote).FirstOrDefault
            CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub

    Public Sub DeleteLoteDocumento(ByVal idDocumento As Integer)
        Using ts As New TransactionScope
            Dim consulta = HeliosData.recursoCostoLote.Where(Function(o) o.idDocumento = idDocumento).ToList

            HeliosData.recursoCostoLote.RemoveRange(consulta)

            'CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub

    Public Function GetLoteByID(codigoLote As Integer) As recursoCostoLote
        Return HeliosData.recursoCostoLote.Where(Function(o) o.codigoLote = codigoLote).SingleOrDefault
    End Function

    Public Function ExisteCodigoLote(lote As String) As Boolean
        Dim con = HeliosData.recursoCostoLote.Where(Function(o) o.nroLote = lote).Count
        If con > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub GrabarLotes(lista As List(Of recursoCostoLote))
        Using ts As New TransactionScope
            For Each i In lista
                HeliosData.recursoCostoLote.Add(i)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function GrabarLotesOne(be As recursoCostoLote) As Integer
        Using ts As New TransactionScope
            HeliosData.recursoCostoLote.Add(be)
            HeliosData.SaveChanges()
            ts.Complete()
            Return be.codigoLote
        End Using
    End Function

    Public Sub EditarLote(be As recursoCostoLote)
        Using ts As New TransactionScope

            Dim lote = HeliosData.recursoCostoLote.Where(Function(o) o.codigoLote = be.codigoLote).Single

            lote.nroLote = be.nroLote
            lote.fechaProduccion = IIf(be.fechaProduccion.HasValue, be.fechaProduccion, Nothing)
            lote.fechaVcto = IIf(be.fechaVcto.HasValue, be.fechaVcto, Nothing)
            lote.serie = be.serie
            lote.sku = be.sku
            lote.composicion = be.composicion
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub
End Class
