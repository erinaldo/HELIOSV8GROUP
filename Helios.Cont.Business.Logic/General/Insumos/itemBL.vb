Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Imports System.Data.Entity.Migrations

Public Class itemBL
    Inherits BaseBL

    Public Sub GrabarListaDeItemTipo(ByVal lista As List(Of item))
        Try

            'Using ts As New TransactionScope


            '    For Each i In lista
            '        InsertItemxTipo(i)
            '    Next

            'End Using



            Using ts As New TransactionScope
                'Se inserta asiento
                'For Each i In ProductoListaBE
                'If IsNothing(GetUbicaProductoNombre(i.descripcionItem, i.idEmpresa, i.idEstablecimiento)) Then
                '  HeliosData.detalleitems.Add(i)
                InsertItemxTipo(lista)
                'Else

                'End If
                'Next
                HeliosData.SaveChanges()
                ts.Complete()

            End Using


        Catch ex As Exception

        End Try

    End Sub


    Public Sub InsertItemxTipo(ProductoListaBE As List(Of item))
        Using ts As New TransactionScope
            HeliosData.item.AddRange(ProductoListaBE)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function ListaTotalItem(itemBE As item) As List(Of item)

        Dim listanueva As New List(Of item)


        Dim consulta = (From i In HeliosData.item Where i.idEmpresa = itemBE.idEmpresa _
                                                      And i.idEstablecimiento = itemBE.idEstablecimiento).ToList()


        For Each i In consulta
            Dim objeto As New item

            objeto.idItem = i.idItem
            objeto.idPadre = i.idPadre
            objeto.idEmpresa = i.idEmpresa
            objeto.idEstablecimiento = i.idEstablecimiento
            objeto.fechaIngreso = i.fechaIngreso
            objeto.descripcion = i.descripcion
            objeto.tipo = i.tipo
            objeto.utilidad = i.utilidad
            objeto.utilidadmayor = i.utilidadmayor
            objeto.utilidadgranmayor = i.utilidadgranmayor
            objeto.usuarioActualizacion = i.usuarioActualizacion
            objeto.fechaActualizacion = i.fechaActualizacion
            listanueva.Add(objeto)

        Next



        Return listanueva
    End Function
    Public Function GetListaCategoriasItem(be As item) As List(Of item)

        Dim lista As New List(Of item)
        Dim objeto As item

        Dim consulta = (From a In HeliosData.item Where a.idEmpresa = be.idEmpresa And a.idEstablecimiento = be.idEstablecimiento Select a Order By a.tipo).ToList

        For Each i In consulta
            objeto = New item
            objeto.idEmpresa = i.idEmpresa
            objeto.idPadre = i.idPadre
            objeto.idEstablecimiento = i.idEstablecimiento
            objeto.idItem = i.idItem
            objeto.descripcion = i.descripcion
            objeto.tipo = i.tipo
            objeto.codigo = i.codigo
            lista.Add(objeto)
        Next

        Return lista


    End Function
    Public Sub EditarPropertycategoryProducts(lista As List(Of detalleitems), category_id As Integer)
        Using ts As New TransactionScope
            For Each i In lista
                Dim prod = HeliosData.detalleitems.Where(Function(o) o.codigodetalle = i.codigodetalle).Single
                If category_id = 0 Then
                    prod.idItem = Nothing
                Else
                    prod.idItem = category_id
                End If
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    'Public Function Insertmarca(ByVal itemBE As item) As Integer
    '    Dim productoBL As New detalleitemsBL()
    '    Using ts As New TransactionScope
    '        'Se inserta item
    '        Dim consulta As Integer = HeliosData.item.Where(Function(o) o.idEmpresa = itemBE.idEmpresa _
    '                                                          And o.idEstablecimiento = itemBE.idEstablecimiento And
    '                                                          o.descripcion = itemBE.descripcion And o.idPadre = itemBE.idPadre).Count


    '        If consulta > 0 Then
    '            Throw New Exception("Categoría existente en la base de datos, ingrese otro!")
    '        Else
    '            HeliosData.item.Add(itemBE)
    '            For Each detalleBE In itemBE.detalleitems
    '                productoBL.GetUbicaProductoNombre(detalleBE.descripcionItem, detalleBE.idEmpresa, detalleBE.idEstablecimiento)
    '                If IsNothing(productoBL) Then
    '                    HeliosData.detalleitems.Add(detalleBE)
    '                End If
    '            Next
    '            HeliosData.SaveChanges()
    '            ts.Complete()
    '        End If
    '        'Se inserta detalle
    '        Return itemBE.idItem
    '    End Using
    'End Function

    Public Function Insertmarca(ByVal itemBE As item) As Integer
        Dim productoBL As New detalleitemsBL()
        Using ts As New TransactionScope
            'Se inserta item
            Dim consulta As Integer = HeliosData.item.Where(Function(o) o.idEmpresa = itemBE.idEmpresa _
                                                              And o.idEstablecimiento = itemBE.idEstablecimiento And
                                                              o.descripcion = itemBE.descripcion And o.tipo = "M").Count


            If consulta > 0 Then
                Throw New Exception("Marca existente en la base de datos, ingrese otro!")
            Else
                HeliosData.item.Add(itemBE)
                For Each detalleBE In itemBE.detalleitems
                    productoBL.GetUbicaProductoNombre(detalleBE.descripcionItem, detalleBE.idEmpresa, detalleBE.idEstablecimiento)
                    If IsNothing(productoBL) Then
                        HeliosData.detalleitems.Add(detalleBE)
                    End If
                Next
                HeliosData.SaveChanges()
                ts.Complete()
            End If
            'Se inserta detalle
            Return itemBE.idItem
        End Using
    End Function

    Function GetListaIdPadre() As List(Of item)
        Return (From a In HeliosData.item Where a.idPadre Is Nothing Select a Order By a.descripcion).ToList
    End Function

    Function GetListaPorIdPadre(intIdPadre As Integer) As List(Of item)
        Return (From a In HeliosData.item Where a.idPadre = intIdPadre Select a Order By a.descripcion).ToList
    End Function

    Public Function GetListaItemsPorTipo(be As item) As List(Of item)

        Dim lista As New List(Of item)
        Dim objeto As item

        Dim consulta = (From a In HeliosData.item Where a.idEmpresa = be.idEmpresa And a.tipo = be.tipo Select a Order By a.descripcion).ToList

        For Each i In consulta
            objeto = New item
            objeto.idItem = i.idItem
            objeto.idPadre = i.idPadre
            objeto.descripcion = i.descripcion
            objeto.codigo = i.codigo
            objeto.nombrePadre = i.nombrePadre
            objeto.tipo = i.tipo


            lista.Add(objeto)
        Next

        Return lista


    End Function



    Public Function GetListaItemsPorTipoPadre(be As item) As List(Of item)
        Dim lista As New List(Of item)

        Dim consulta = (From a In HeliosData.item Where a.idEmpresa = be.idEmpresa And a.tipo = be.tipo
                        Select a.idItem,
                    a.descripcion,
                    a.idPadre,
                    a.codigo,
                            a.tipo,
                    nombrepadre = (From i In HeliosData.item
                                   Where i.idItem = a.idPadre Select i.descripcion).FirstOrDefault
                        ).ToList



        consulta = (From i In consulta Order By i.descripcion).ToList

        For Each i In consulta
            Dim objeto As New item
            objeto.idItem = i.idItem
            objeto.idPadre = i.idPadre
            objeto.descripcion = i.descripcion
            objeto.codigo = i.codigo
            objeto.nombrePadre = i.nombrepadre
            objeto.tipo = i.tipo


            lista.Add(objeto)
        Next


        Return lista
    End Function
    Public Sub InsertDefault(nProducto As detalleitems, intIdItem As Integer)
        Dim productoBE As New detalleitems
        Using ts As New TransactionScope

            productoBE.idItem = intIdItem
            productoBE.idEmpresa = nProducto.idEmpresa
            productoBE.idEstablecimiento = nProducto.idEstablecimiento
            productoBE.cuenta = nProducto.cuenta
            productoBE.descripcionItem = nProducto.descripcionItem
            productoBE.presentacion = nProducto.presentacion
            productoBE.unidad1 = nProducto.unidad1
            productoBE.tipoExistencia = nProducto.tipoExistencia
            productoBE.origenProducto = nProducto.origenProducto
            productoBE.tipoProducto = nProducto.tipoProducto
            productoBE.estado = nProducto.estado

            HeliosData.detalleitems.Add(productoBE)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub GrabarProductosExcel(ByVal insumos As List(Of item))
        Using ts As New TransactionScope
            For Each obj In insumos
                Me.InsertExcel(obj, obj.idItem)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub InsertExcel(ByVal itemBE As item, intIdItem As Integer)
        Dim productoBL As New detalleitemsBL()
        Using ts As New TransactionScope
            For Each detalleBE In itemBE.detalleitems
                InsertDefault(detalleBE, intIdItem)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Function InsertMultiplePresentacion(ByVal itemBE As item) As Integer


        Try
            Dim productoBL As New detalleitemsBL()
            Using ts As New TransactionScope
                'Se inserta item
                Dim consulta As Integer = HeliosData.item.Where(Function(o) o.idEmpresa = itemBE.idEmpresa _
                                                                  And o.idEstablecimiento = itemBE.idEstablecimiento And
                                                                  o.descripcion = itemBE.descripcion And o.idPadre = itemBE.idPadre).Count
                'validar codigo

                If Not IsNothing(itemBE.codigo) Then
                    If itemBE.codigo.Trim.Length > 0 Then

                        Dim validarCodigo As Integer = HeliosData.item.Where(Function(o) o.codigo = itemBE.codigo And o.tipo = itemBE.tipo).Count

                        If validarCodigo > 0 Then
                            Throw New Exception("El codigo  ya existe, ingrese otro.")
                        End If
                    End If
                Else
                End If



                If consulta > 0 Then
                    Throw New Exception("La Presentacion ya existe en esta Marca")
                Else
                    HeliosData.item.Add(itemBE)
                    For Each detalleBE In itemBE.detalleitems
                        productoBL.GetUbicaProductoNombre(detalleBE.descripcionItem, detalleBE.idEmpresa, detalleBE.idEstablecimiento)
                        If IsNothing(productoBL) Then
                            HeliosData.detalleitems.Add(detalleBE)
                        End If
                    Next
                    HeliosData.SaveChanges()
                    ts.Complete()
                End If
                'Se inserta detalle
                Return itemBE.idItem
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    Public Function Insert(ByVal itemBE As item) As Integer



        Try
            Dim productoBL As New detalleitemsBL()
            Using ts As New TransactionScope
                'Se inserta item

                Dim consulta As Integer = 0

                If itemBE.tipo = "H" Then
                    consulta = HeliosData.item.Where(Function(o) o.idEmpresa = itemBE.idEmpresa _
                                                                  And o.idEstablecimiento = itemBE.idEstablecimiento And
                                                                  o.descripcion = itemBE.descripcion And o.tipo = itemBE.tipo).Count
                Else
                    consulta = HeliosData.item.Where(Function(o) o.idEmpresa = itemBE.idEmpresa _
                                                                  And o.idEstablecimiento = itemBE.idEstablecimiento And
                                                                  o.descripcion = itemBE.descripcion And o.tipo = itemBE.tipo And
                                                                  o.idPadre = itemBE.idPadre).Count
                End If


                'validar codigo

                If Not IsNothing(itemBE.codigo) Then
                    If itemBE.codigo.Trim.Length > 0 Then

                        Dim validarCodigo As Integer = HeliosData.item.Where(Function(o) o.codigo = itemBE.codigo And o.tipo = itemBE.tipo).Count

                        If validarCodigo > 0 Then
                            Throw New Exception("El codigo  ya existe, ingrese otro.")
                        End If
                    End If
                Else
                End If



                If consulta > 0 Then
                    Throw New Exception("El Item ya existe en la base de datos, ingrese otro!")
                Else
                    HeliosData.item.Add(itemBE)
                    For Each detalleBE In itemBE.detalleitems
                        productoBL.GetUbicaProductoNombre(detalleBE.descripcionItem, detalleBE.idEmpresa, detalleBE.idEstablecimiento)
                        If IsNothing(productoBL) Then
                            HeliosData.detalleitems.Add(detalleBE)
                        End If
                    Next
                    HeliosData.SaveChanges()
                    ts.Complete()
                End If
                'Se inserta detalle
                Return itemBE.idItem
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function UpdateTipoCategoria(ByVal itemBE As item) As Integer



        Try
            Dim productoBL As New detalleitemsBL()
            Using ts As New TransactionScope
                'Se inserta item

                Dim consulta = (From i In HeliosData.item
                                Where i.idItem = itemBE.idItem).FirstOrDefault



                Dim nuevadescripcion As Integer = HeliosData.item.Where(Function(o) o.idEmpresa = consulta.idEmpresa _
                                                                  And o.idEstablecimiento = consulta.idEstablecimiento And
                                                                  o.descripcion = itemBE.descripcion And Not o.idItem = consulta.idItem).Count



                'validar codigo

                If Not IsNothing(itemBE.codigo) Then
                    If itemBE.codigo.Trim.Length > 0 Then

                        Dim validarCodigo As Integer = HeliosData.item.Where(Function(o) o.codigo = itemBE.codigo And o.tipo = itemBE.tipo And Not o.idItem = consulta.idItem).Count

                        If validarCodigo > 0 Then
                            Throw New Exception("El codigo  ya existe, ingrese otro.")
                        End If
                    End If
                Else
                End If



                If nuevadescripcion > 0 Then
                    Throw New Exception("Categoría existente en la base de datos, ingrese otro!")
                Else


                    consulta.descripcion = itemBE.descripcion
                    consulta.codigo = itemBE.codigo

                    HeliosData.SaveChanges()
                    ts.Complete()
                End If
                'Se inserta detalle
                Return itemBE.idItem
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function InsertSL(ByVal itemBE As item) As item
        Dim productoBL As New detalleitemsBL()
        Using ts As New TransactionScope
            'Se inserta item
            Dim consulta As Integer = HeliosData.item.Where(Function(o) o.idEmpresa = itemBE.idEmpresa _
                                                              And o.idEstablecimiento = itemBE.idEstablecimiento And
                                                              o.descripcion = itemBE.descripcion).Count


            If consulta > 0 Then
                Throw New Exception("Categoría existente en la base de datos, ingrese otro!")
            Else
                HeliosData.item.Add(itemBE)
                For Each detalleBE In itemBE.detalleitems
                    productoBL.GetUbicaProductoNombre(detalleBE.descripcionItem, detalleBE.idEmpresa, detalleBE.idEstablecimiento)
                    If IsNothing(productoBL) Then
                        HeliosData.detalleitems.Add(detalleBE)
                    End If
                Next
                HeliosData.SaveChanges()
                ts.Complete()
            End If
            'Se inserta detalle
            Return itemBE
        End Using
    End Function

    Public Sub Update(ByVal itemBE As item)
        Using ts As New TransactionScope
            'Se actualiza asiento
            'HeliosData.asiento.Attach(asientoBE)
            HeliosData.item.AddOrUpdate(itemBE)
            'HeliosData.Entry(itemBE).State = System.Data.Entity.EntityState.Modified

            'HeliosData.asiento.ApplyCurrentValues(asientoBE)
            'Se inserta/actualiza/elimina detalle
            'For Each detalleBE In itemBE.detalleitems
            '    Select Case detalleBE.Action
            '        Case BaseBE.EntityAction.INSERT
            '            HeliosData.detalleitems.Add(detalleBE)
            '        Case BaseBE.EntityAction.UPDATE
            '            HeliosData.detalleitems.Attach(detalleBE)
            '        Case BaseBE.EntityAction.DELETE
            '            CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(detalleBE)
            '    End Select
            'Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal itemBE As item)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(itemBE)
    End Sub

    Public Function DeleteSL(ByVal itemBE As item) As Boolean
        Using ts As New TransactionScope
            Dim RecursoBE = (From n In HeliosData.detalleitems
                             Where n.idItem = itemBE.idItem).Count

            If (RecursoBE = 0) Then
                Dim item = (From n In HeliosData.item
                            Where n.idItem = itemBE.idItem).FirstOrDefault
                CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(item)
                HeliosData.SaveChanges()
                ts.Complete()
                Return False
            Else
                Return True
            End If

        End Using
    End Function

    Public Sub SavebyGroup(ByVal insumos As List(Of item))
        Using ts As New TransactionScope
            For Each obj In insumos
                Select Case obj.Action
                    Case BaseBE.EntityAction.INSERT
                        Me.Insert(obj)
                    Case BaseBE.EntityAction.UPDATE
                        Me.Update(obj)
                    Case BaseBE.EntityAction.DELETE
                        Me.Delete(obj)
                End Select
            Next
            ts.Complete()
        End Using
    End Sub

    Public Sub SavebyGroupFormatoExcel(ByVal insumos As List(Of item))
        Using ts As New TransactionScope
            For Each obj In insumos
                If IsNothing(GetUbicaCategoriaNombre(obj.idEmpresa, obj.idEstablecimiento, obj.descripcion)) Then
                    Me.Insert(obj)
                End If
            Next
            ts.Complete()
        End Using
    End Sub

    Public Sub UpdateCategoriaFull(lista As List(Of item))
        Dim objNuevo As New item()
        Using ts As New TransactionScope
            For Each i In lista

                objNuevo = HeliosData.item.Where(Function(o) o.idItem = i.idItem).FirstOrDefault
                If Not IsNothing(objNuevo) Then
                    objNuevo.utilidad = i.utilidad
                    'HeliosData.ObjectStateManager.GetObjectStateEntry(objNuevo).State.ToString()
                End If
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Function GetListaInsumoPorEstable(intIdEstable As Integer) As List(Of item)
        Return (From a In HeliosData.item Where a.idEstablecimiento = intIdEstable Select a).ToList
    End Function

    Function UbicarCategoriaPorID(intIdCategoria As Integer) As item
        Return (From a In HeliosData.item Where a.idItem = intIdCategoria).First
    End Function

    Function GetUbicaCategoriaNombre(strIdEmpresa As String, intIdEstable As Integer, strNomCategoria As String) As item
        Dim consulta As New item
        consulta = (From a In HeliosData.item
                    Where a.idEmpresa = strIdEmpresa _
                    And a.idEstablecimiento = intIdEstable _
                    And a.descripcion = strNomCategoria
                    Select a).FirstOrDefault

        Return consulta
    End Function

    Function GetUbicarItemID(intIdTablaDep As String) As item
        Return (From a In HeliosData.item Where a.descripcion = intIdTablaDep).First
    End Function

    Function GetListaItemID(strDescripcion As String) As String
        Return (From a In HeliosData.item Where a.descripcion = strDescripcion
                Select a.idItem).FirstOrDefault
    End Function

    Function GetListaItemPorEstable(strEstable As Integer, strIdEmpresa As String) As List(Of item)

        Dim lista As New List(Of item)
        Dim objeto As item

        Dim consulta = (From a In HeliosData.item Where a.idEmpresa = strIdEmpresa And a.idEstablecimiento = strEstable Order By a.descripcion).ToList

        For Each i In consulta
            objeto = New item

            objeto.idItem = i.idItem
            objeto.idPadre = i.idPadre
            objeto.tipo = i.tipo
            objeto.descripcion = i.descripcion
            objeto.idEmpresa = i.idEmpresa
            objeto.idEstablecimiento = i.idEstablecimiento
            objeto.codigo = i.codigo
            lista.Add(objeto)
        Next


        Return lista


    End Function

    Function GetListaItemPorEstableLike(strEstable As Integer, strLike As String) As List(Of item)
        Return (From a In HeliosData.item Where a.idEstablecimiento = strEstable And a.descripcion.StartsWith(strLike) Take 5
                Order By a.descripcion).ToList
    End Function


    Public Function InsertarItemClasificaion(ByVal tabladetalleBE As item) As Integer
        Using ts As New TransactionScope
            HeliosData.item.Add(tabladetalleBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return tabladetalleBE.idItem
        End Using
    End Function

    Function ObtenerItemsFull() As IList
        Dim consulta = (From a In HeliosData.item Select a.descripcion).ToList
        Return consulta
    End Function

    Public Function InsertItemExcel(ByVal strIdEmpresa As String, ByVal strIdEstablecimiento As String, ByVal strClasificacion As String) As Integer
        Dim objRecurso As New item
        Dim CodigoItem As Integer = 0
        Dim consulta = (From a In HeliosData.item Where a.descripcion = strClasificacion
                        Select a.idItem).FirstOrDefault
        If ((consulta) = 0) Then
            Using ts As New TransactionScope

                objRecurso = New item
                With objRecurso
                    .Action = Business.Entity.BaseBE.EntityAction.INSERT
                    .idEmpresa = strIdEmpresa
                    .idEstablecimiento = strIdEstablecimiento
                    .fechaIngreso = Date.Now
                    .descripcion = strClasificacion
                    .usuarioActualizacion = Nothing
                    .fechaActualizacion = Date.Now
                End With
                HeliosData.item.Add(objRecurso)
                HeliosData.SaveChanges()
                ts.Complete()
                CodigoItem = objRecurso.idItem
            End Using
        Else
            CodigoItem = consulta
        End If
        Return CodigoItem
    End Function

    Public Function GetUbicaCategoriaItem_Utilidad(strIdEmpresa As String, intIdEstable As Integer, idItem As Integer) As Integer

        Dim utilidadBE = (From a In HeliosData.item
                          Join b In HeliosData.detalleitems
                          On a.idItem Equals b.idItem
                          Where a.idEmpresa = strIdEmpresa _
                          And a.idEstablecimiento = intIdEstable _
                        And b.codigodetalle = idItem).FirstOrDefault

        If (Not IsNothing(utilidadBE)) Then
            Return utilidadBE.a.utilidad
        Else
            Return 0
        End If
    End Function

    Function GetListaItemPorEmpresa(strIdEmpresa As String, intIdEstablec As Integer) As List(Of item)
        Return (From a In HeliosData.item Where a.idEstablecimiento = intIdEstablec _
                And a.idEmpresa = strIdEmpresa Order By a.descripcion).ToList
    End Function

    Function GetListaItemxEstable(itemBE As item) As List(Of item)

        Dim lista As New List(Of item)
        Dim objeto As item
        Dim consulta = (From a In HeliosData.item Where a.idEmpresa = itemBE.idEmpresa And a.idEstablecimiento = itemBE.idEstablecimiento Order By a.descripcion).ToList

        For Each i In consulta
            objeto = New item

            objeto.idItem = i.idItem
            objeto.idPadre = i.idPadre
            objeto.tipo = i.tipo
            objeto.descripcion = i.descripcion
            objeto.idEmpresa = i.idEmpresa
            objeto.idEstablecimiento = i.idEstablecimiento
            objeto.codigo = i.codigo
            lista.Add(objeto)
        Next
        Return lista
    End Function

End Class
