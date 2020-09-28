Imports Helios.Cont.Business.Entity
Public Class itemSA


    Public Sub GrabarListaDeItemTipo(lista As List(Of item))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarListaDeItemTipo(lista)
    End Sub

    Public Function ListaTotalItem(itemBE As item) As List(Of item)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaTotalItem(itemBE)
    End Function
    Public Function GetListaCategoriasItem(be As item) As List(Of item)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaCategoriasItem(be)
    End Function
    Public Sub EditarPropertycategoryProducts(lista As List(Of detalleitems), category_id As Integer)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarPropertycategoryProducts(lista, category_id)
    End Sub


    Public Function GetListaItemsPorTipoPadre(be As item) As List(Of item)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaItemsPorTipoPadre(be)
    End Function

    Public Function GetListaItemsPorTipo(be As item) As List(Of item)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaItemsPorTipo(be)
    End Function

    Public Function ObtenerListaAsientos() As List(Of asiento)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As List(Of asiento)
        miLista = miServicio.AsientoGetAll
        Return miLista
    End Function

    Public Function InsertarMarcaHijo(nCat As item) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.InsertarMarcaHijo(nCat)
    End Function

    Public Function GetListaPadre() As List(Of item)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaIdPadre()
    End Function

    Public Function GetListaMarcaPadre(intIdPadre As Integer) As List(Of item)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListarPadreHijos(intIdPadre)
    End Function



    Public Function UpdateTipoCategoria(nCat As item) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UpdateTipoCategoria(nCat)
    End Function


    Public Function InsertMultiplePresentacion(nCat As item) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.InsertMultiplePresentacion(nCat)
    End Function

    Public Function SaveCategoria(nCat As item) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveInsumo(nCat)
    End Function

    Public Function SaveCategoriaSL(nCat As item) As item
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveInsumoSL(nCat)
    End Function

    Public Function UpdateCategoria(nCat As item) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateInsumo(nCat)
        Return True
    End Function

    Public Function DeleteCategoria(nCat As item) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteInsumo(nCat)
        Return True
    End Function

    Public Function DeleteCategoriaSL(nCat As item) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.DeleteInsumoSL(nCat)
    End Function

    Public Function SaveGroupCategoria(nLista As List(Of item)) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        miServicio.InsumoSaveByGroup(nLista)
        Return True
    End Function

    Public Sub UpdateCategoriaFull(nLista As List(Of item))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateCategoriaFull(nLista)
    End Sub

    Public Sub GrabarProductosExcel(ByVal insumos As List(Of item))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarProductosExcel(insumos)
    End Sub

    Public Function SaveGroupCategoriaExcel(nLista As List(Of item)) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        miServicio.InsumoSaveByGroupExcel(nLista)
        Return True
    End Function

    Public Function GetListaItemID(strDescripcion As String) As String
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaItemID(strDescripcion)
    End Function

    Public Function GetListaItemPorEstable(strEstable As Integer, strIdEmpresa As String) As List(Of item)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaItemPorEstable(strEstable, strIdEmpresa)
    End Function

    Public Function GetListaItemPorEstableLike(strEstable As Integer, strLike As String) As List(Of item)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaItemPorEstableLike(strEstable, strLike)
    End Function

    Public Function InsertarTablaDetalle(ByVal nTabDet As tabladetalle) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.InsertarTablaDetalle(nTabDet)
    End Function

    Public Function InsertarItemClasificaion(ByVal nTabDet As item) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.InsertarItemClasificaion(nTabDet)
    End Function

    Public Function ObtenerItemsFull() As IList
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerItemsFull()
    End Function

    Public Function GetUbicarItemID(intIdTablaDep As String) As item
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicarItemID(intIdTablaDep)
    End Function

    Function UbicarCategoriaPorID(intIdCategoria As Integer) As item
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarCategoriaPorID(intIdCategoria)
    End Function

    Function GetUbicaCategoriaItem_Utilidad(ByVal strIdEmpresa As String, ByVal intIdEstable As Integer, intIdItem As Integer) As Decimal
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicaCategoriaItem_Utilidad(strIdEmpresa, intIdEstable, intIdItem)
    End Function

    Public Function GetListaItemPorEmpresa(strIdEmpresa As String, intIdEstablec As Integer) As List(Of item)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaItemPorEmpresa(strIdEmpresa, intIdEstablec)
    End Function

    Public Function GetListaItemxEstable(itemBE As item) As List(Of item)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaItemxEstable(itemBE)
    End Function

End Class
