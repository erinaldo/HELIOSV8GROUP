Imports Helios.Seguridad.Business.Entity
Imports System.Transactions
Public Class productoDetalleBL
    Inherits BaseBL

    Public Function GetInsertProductoDetalle(objListaAsegurables As Producto, idProducto As Integer) As Producto
        Dim prodcutodetalleBl As New ProductoBL
        Dim productoDetalleBE As New ProductoDetalle
        Try
            Using ts As New TransactionScope

                For Each item In objListaAsegurables.ProductoDetalle
                    productoDetalleBE = New ProductoDetalle
                    productoDetalleBE.idProducto = idProducto
                    productoDetalleBE.IDAsegurable = item.IDAsegurable
                    productoDetalleBE.estadoProducto = item.estadoProducto
                    productoDetalleBE.UsuarioActualizacion = item.UsuarioActualizacion
                    productoDetalleBE.FechaActualizacion = item.FechaActualizacion
                    SeguridadData.ProductoDetalle.Add(productoDetalleBE)
                Next
                SeguridadData.SaveChanges()
                ts.Complete()
                Return Nothing
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function GetAsegurableProductoDetalle(idProductoPadre As Integer) As List(Of ProductoDetalle)
        Dim AsegurableBE As New List(Of ProductoDetalle)
        Dim ObjAsegurable As New ProductoDetalle
        Try

            Dim consulta = (From pd In SeguridadData.ProductoDetalle
                            Where CLng(pd.Producto.IDProducto) = idProductoPadre
                            Order By pd.Descripcion
                            Select IDAsegurable = CType(pd.IDAsegurable, Int32?),
                                IDProducto = CType(pd.Producto.IDProducto, Int32?),
                                pd.Nombre,
                                pd.Descripcion,
                                Column1 = pd.Producto.nombre).ToList

            'Dim consulta = (From pd In SeguridadData.ProductoDetalle
            '                Join a In SeguridadData.Asegurable On New With {pd.IDAsegurable} Equals New With {a.IDAsegurable}
            '                Where CLng(pd.Producto.IDProducto) = idProductoPadre
            '                Order By a.Descripcion
            '                Select IDAsegurable = CType(pd.IDAsegurable, Int32?),
            '                    IDProducto = CType(pd.Producto.IDProducto, Int32?),
            '                    a.Nombre,
            '                    a.Descripcion,
            '                    Column1 = pd.Producto.nombre).ToList

            If (Not IsNothing(consulta)) Then
                For Each item In consulta
                    ObjAsegurable = New ProductoDetalle
                    ObjAsegurable.idProducto = item.IDProducto
                    ObjAsegurable.IDAsegurable = item.IDAsegurable
                    ObjAsegurable.nombre = item.Nombre
                    ObjAsegurable.descripcion = item.Descripcion
                    ObjAsegurable.nombreProducto = item.Column1
                    AsegurableBE.Add(ObjAsegurable)
                Next

            End If
            Return AsegurableBE
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub insertProductoDetalle(ByVal objProductoDetalle As ProductoDetalle)
        Select Case objProductoDetalle.Action
            Case BaseBE.EntityAction.INSERT
                SeguridadData.ProductoDetalle.Add(objProductoDetalle)
            Case BaseBE.EntityAction.UPDATE
                SeguridadData.ProductoDetalle.Attach(objProductoDetalle)
                'SeguridadData.ObjectStateManager.GetObjectStateEntry(AutorizacionRol).ChangeState(EntityState.Modified)
            Case BaseBE.EntityAction.DELETE
                'IDRol = AutorizacionRol.IDRol
                'IDAsegurable = AutorizacionRol.IDAsegurable
                'AutorizacionRolBE = (From be In SeguridadData.AutorizacionRol
                '                     Where be.IDRol = IDRol And be.IDAsegurable = IDAsegurable).Single
                'SeguridadData.Delete(AutorizacionRolBE)
        End Select
        Using ts As New TransactionScope
            SeguridadData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function GetListaProductoDetalle(idProductoPadre As Integer) As List(Of ProductoDetalle)
        Dim AsegurableBE As New List(Of ProductoDetalle)
        Dim ObjAsegurable As New ProductoDetalle
        Try

            Dim consulta = (From pd In SeguridadData.ProductoDetalle
                            Join a In SeguridadData.Asegurable On New With {pd.IDAsegurable} Equals New With {a.IDAsegurable}
                            Where CLng(pd.Producto.IDProducto) = idProductoPadre
                            Order By a.Descripcion
                            Select IDAsegurable = CType(pd.IDAsegurable, Int32?),
                                IDProducto = CType(pd.Producto.IDProducto, Int32?),
                                a.Nombre,
                                a.Descripcion,
                                Column1 = pd.Producto.nombre).ToList

            If (Not IsNothing(consulta)) Then
                For Each item In consulta
                    ObjAsegurable = New ProductoDetalle
                    ObjAsegurable.idProducto = item.IDProducto
                    ObjAsegurable.IDAsegurable = item.IDAsegurable
                    ObjAsegurable.nombre = item.Nombre
                    ObjAsegurable.descripcion = item.Descripcion
                    ObjAsegurable.nombreProducto = item.Column1
                    AsegurableBE.Add(ObjAsegurable)
                Next

            End If
            Return AsegurableBE
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetListaProductoDetalleInicio(idProductoPadre As Integer) As List(Of ProductoDetalle)
        Dim AsegurableBE As New List(Of ProductoDetalle)
        Dim ObjAsegurable As New ProductoDetalle
        Try

            Dim consulta = (From pd In SeguridadData.ProductoDetalle
                            Where CLng(pd.Producto.IDProducto) = idProductoPadre
                            Order By pd.Descripcion
                            Select IDAsegurable = CType(pd.IDAsegurable, Int32?),
                                IDAsegurablePadre = pd.IDAsegurablePadre,
                                IDProducto = CType(pd.Producto.IDProducto, Int32?),
                                pd.Nombre,
                                pd.Descripcion,
                                Column1 = pd.Producto.nombre,
                                pd.orden,
                                pd.formulario).ToList

            If (Not IsNothing(consulta)) Then
                For Each item In consulta
                    ObjAsegurable = New ProductoDetalle
                    ObjAsegurable.idProducto = item.IDProducto
                    ObjAsegurable.IDAsegurable = item.IDAsegurable
                    ObjAsegurable.IDAsegurablePadre = item.IDAsegurablePadre
                    ObjAsegurable.Nombre = item.Nombre
                    ObjAsegurable.Descripcion = item.Descripcion
                    ObjAsegurable.nombreProducto = item.Column1
                    ObjAsegurable.formulario = item.formulario
                    ObjAsegurable.orden = item.orden
                    AsegurableBE.Add(ObjAsegurable)
                Next

            End If
            Return AsegurableBE
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
