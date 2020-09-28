Imports Helios.Seguridad.Business.Entity
Imports System.Transactions
Public Class ProductoBL
    Inherits BaseBL

    Public Function GetAsegurableProducto(tipoProducto As String) As List(Of Producto)
        Dim AsegurableBE As New List(Of Producto)
        Dim ObjAsegurable As New Producto
        Try

            'Dim consulta = (From ap In SeguridadData.Producto
            '                Where ap.tipo = tipoProducto
            '                Select ap.IDAsegurable, ap.Asegurable.Nombre, ap.Asegurable.Descripcion).ToList

            'If (Not IsNothing(consulta)) Then
            '    'For Each item In consulta
            '    '    ObjAsegurable = New Producto
            '    '    ObjAsegurable.IDAsegurable = item.IDAsegurable
            '    '    ObjAsegurable.tipo = item.Nombre
            '    '    ObjAsegurable.descripcion = item.Descripcion
            '    '    AsegurableBE.Add(ObjAsegurable)
            '    'Next

            'End If
            Return AsegurableBE
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetListaAsegurableProducto(tipoProducto As String) As List(Of Producto)
        Dim listaProducto As New List(Of Producto)
        Dim objProducto As New Producto

        'Dim CONSULTA = (From a In SeguridadData.AsegurableProducto
        '                Where a.tipo = tipoProducto
        '                Order By a.Asegurable.Descripcion
        '                Select a.IDAsegurable, a.Asegurable.Nombre, a.tipo, a.Asegurable.Descripcion)


        'For Each i In CONSULTA
        '    objProducto = New AsegurableProducto
        '    objProducto.IDAsegurable = i.IDAsegurable
        '    objProducto.tipo = i.Nombre
        '    objProducto.descripcion = i.Descripcion

        '    listaProducto.Add(objProducto)
        'Next
        Return listaProducto
    End Function


    Public Function GetInsertAsegurableProducto(objListaAsegurables As Producto) As Producto
        Dim productoDetalleBl As New productoDetalleBL
        Dim product As New Producto
        Try
            Using ts As New TransactionScope
                Me.InsertProducto(objListaAsegurables)
                productoDetalleBl.GetInsertProductoDetalle(objListaAsegurables, objListaAsegurables.IDProducto)
                SeguridadData.SaveChanges()
                ts.Complete()
                Return Nothing
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function InsertProducto(objProducto As Producto) As Producto
        Dim product As New Producto
        Try
            Using ts As New TransactionScope

                product.UsuarioActualizacion = objProducto.UsuarioActualizacion
                product.FechaActualizacion = objProducto.FechaActualizacion
                product.nombre = objProducto.nombre
                product.descripcion = objProducto.descripcion
                SeguridadData.Producto.Add(product)

                SeguridadData.SaveChanges()
                ts.Complete()
                objProducto.IDProducto = product.IDProducto
                Return Nothing
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ListadoTipoProducto() As List(Of Producto)
        Dim AsegurableBE As New List(Of Producto)
        Dim ObjAsegurable As New Producto
            Try

                Dim consulta = (From ap In SeguridadData.Producto).ToList

                If (Not IsNothing(consulta)) Then
                    For Each item In consulta
                        ObjAsegurable = New Producto
                        ObjAsegurable.IDProducto = item.IDProducto
                    ObjAsegurable.nombre = item.nombre
                    ObjAsegurable.descripcion = item.descripcion
                    ObjAsegurable.FechaActualizacion = item.FechaActualizacion
                    AsegurableBE.Add(ObjAsegurable)
                    Next

                End If
                Return AsegurableBE
            Catch ex As Exception
                Throw ex
            End Try
            Return AsegurableBE

    End Function

    Public Function ListadoProductoXID(IdProducto As Integer) As Producto
        Dim AsegurableBE As New Producto

        Try

            Dim consulta = (From ap In SeguridadData.Producto Where ap.IDProducto = IdProducto).FirstOrDefault

            If (Not IsNothing(consulta)) Then
                AsegurableBE = New Producto
                AsegurableBE.IDProducto = consulta.IDProducto
                AsegurableBE.nombre = consulta.nombre
                AsegurableBE.descripcion = consulta.descripcion
                AsegurableBE.FechaActualizacion = consulta.FechaActualizacion

            End If
            Return AsegurableBE
        Catch ex As Exception
            Throw ex
        End Try
        Return AsegurableBE

    End Function

    Public Sub InsertItemProducto(ByVal productoBE As Producto)
        Select Case productoBE.Action
            Case BaseBE.EntityAction.INSERT
                SeguridadData.Producto.Add(productoBE)
            Case BaseBE.EntityAction.UPDATE
                SeguridadData.Producto.Attach(productoBE)
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

End Class
