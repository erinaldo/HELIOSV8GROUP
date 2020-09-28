Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Cont.Business.Entity
Imports Helios.General
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping

Public Class UCDistribucionAlmacen

    Public Property ListaAlmacen As List(Of almacen)
    Public UCEstructuraDocumentocabecera As UCEstructuraDocumentocabecera

    Public Sub New(DistribucionProductos As UCEstructuraDocumentocabecera)

        ' This call is required by the designer.
        InitializeComponent()
        UCEstructuraDocumentocabecera = DistribucionProductos
        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(GridCompra, False, False, 9.0F)
        GetLoadAlmacenes()
        FormatoGrid()
    End Sub

    Private Sub FormatoGrid()
        For Each i In GridCompra.TableDescriptor.Columns
            i.AllowSort = False
            i.Appearance.AnyRecordFieldCell.TextColor = Color.Black
        Next
    End Sub

    Private Sub GetLoadAlmacenes()
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("name")

        'dt.Rows.Add("1", "EMBARQUE")
        'dt.Rows.Add("2", "EN CURSO")
        dt.Rows.Add("3", "ENTREGADO")

        Dim ggcStyleStatus As GridTableCellStyleInfo = GridCompra.TableDescriptor.Columns("status").Appearance.AnyRecordFieldCell
        ggcStyleStatus.CellType = "ComboBox"
        ggcStyleStatus.DataSource = dt
        ggcStyleStatus.ValueMember = "id"
        ggcStyleStatus.DisplayMember = "name"
        ggcStyleStatus.DropDownStyle = GridDropDownStyle.Exclusive

        Dim almacenSA As New almacenSA
        ListaAlmacen = almacenSA.GetListar_almacenes(GEstableciento.IdEstablecimiento)

        Dim ggcStyle As GridTableCellStyleInfo = GridCompra.TableDescriptor.Columns("idalmacen").Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = ListaAlmacen
        ggcStyle.ValueMember = "idAlmacen"
        ggcStyle.DisplayMember = "descripcionAlmacen"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive
        GridCompra.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
    End Sub

    Private Sub GridCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridCompra.TableControlCellClick

    End Sub

    Private Sub GridCompra_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles GridCompra.TableControlCurrentCellCloseDropDown
        Dim cc As GridCurrentCell = GridCompra.TableControl.CurrentCell
        cc.ConfirmChanges()

        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()
        If cc IsNot Nothing Then
            If cc.ColIndex > -1 Then
                Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

                If style.TableCellIdentity.Column.Name = "idalmacen" Then
                    If cc.Renderer IsNot Nothing Then
                        Dim CodigoAlm As String = cc.Renderer.ControlText
                        Dim r As Record = GridCompra.Table.CurrentRecord
                        If r IsNot Nothing Then
                            Dim almacen = ListaAlmacen.Where(Function(o) o.idAlmacen = r.GetValue("idalmacen")).Single
                            If almacen IsNot Nothing Then
                                r.SetValue("tipo", almacen.tipo)
                            End If
                            Dim codigoitemCompra = r.GetValue("idItemCompra")
                            Dim itemCompra = UCEstructuraDocumentocabecera.ListaproductosComprados.Where(Function(o) o.CodigoCosto = codigoitemCompra).SingleOrDefault

                            If itemCompra IsNot Nothing Then
                                Dim InvMov = itemCompra.CustomListaInventarioMovimiento.Where(Function(i) i.codigoBarra = r.GetValue("codigo")).SingleOrDefault
                                If InvMov IsNot Nothing Then
                                    InvMov.idAlmacen = Integer.Parse(r.GetValue("idalmacen"))
                                    itemCompra.almacenRef = Integer.Parse(r.GetValue("idalmacen"))
                                End If
                            End If
                        End If
                    End If
                ElseIf style.TableCellIdentity.Column.Name = "status" Then
                    If cc.Renderer IsNot Nothing Then
                        Dim r As Record = GridCompra.Table.CurrentRecord
                        If r IsNot Nothing Then
                            Dim codigoitemCompra = r.GetValue("idItemCompra")
                            Dim itemCompra = UCEstructuraDocumentocabecera.ListaproductosComprados.Where(Function(o) o.CodigoCosto = codigoitemCompra).SingleOrDefault

                            If itemCompra IsNot Nothing Then
                                Dim InvMov = itemCompra.CustomListaInventarioMovimiento.Where(Function(i) i.codigoBarra = r.GetValue("codigo")).SingleOrDefault
                                If InvMov IsNot Nothing Then
                                    InvMov.entragado = r.GetValue("status")
                                End If
                            End If
                        End If
                    End If
                End If

            End If
        End If
    End Sub

    Private Sub GridCompra_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs) Handles GridCompra.TableControlCurrentCellChanged
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim cc As GridCurrentCell = GridCompra.TableControl.CurrentCell
        Try
            cc.ConfirmChanges()
            If cc.Renderer IsNot Nothing Then

                If cc.ColIndex > -1 Then
                    Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

                    If style.TableCellIdentity.Column.Name = "serieGuia" Then
                        If cc.Renderer IsNot Nothing Then
                            If cc.Renderer IsNot Nothing Then
                                Dim CodigoAlm As String = cc.Renderer.ControlText
                                Dim r As Record = GridCompra.Table.CurrentRecord
                                If r IsNot Nothing Then
                                    Dim codigoitemCompra = r.GetValue("idItemCompra")
                                    Dim itemCompra = UCEstructuraDocumentocabecera.ListaproductosComprados.Where(Function(o) o.CodigoCosto = codigoitemCompra).SingleOrDefault

                                    If itemCompra IsNot Nothing Then
                                        Dim InvMov = itemCompra.CustomListaInventarioMovimiento.Where(Function(i) i.codigoBarra = r.GetValue("codigo")).SingleOrDefault
                                        If InvMov IsNot Nothing Then
                                            InvMov.serie = r.GetValue("serieGuia")
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    ElseIf style.TableCellIdentity.Column.Name = "numGuia" Then
                        If cc.Renderer IsNot Nothing Then
                            If cc.Renderer IsNot Nothing Then
                                Dim CodigoAlm As String = cc.Renderer.ControlText
                                Dim r As Record = GridCompra.Table.CurrentRecord
                                If r IsNot Nothing Then
                                    Dim codigoitemCompra = r.GetValue("idItemCompra")
                                    Dim itemCompra = UCEstructuraDocumentocabecera.ListaproductosComprados.Where(Function(o) o.CodigoCosto = codigoitemCompra).SingleOrDefault

                                    If itemCompra IsNot Nothing Then
                                        Dim InvMov = itemCompra.CustomListaInventarioMovimiento.Where(Function(i) i.codigoBarra = r.GetValue("codigo")).SingleOrDefault
                                        If InvMov IsNot Nothing Then
                                            InvMov.numero = r.GetValue("numGuia")
                                        End If
                                    End If
                                End If
                            End If
                        End If


                    ElseIf style.TableCellIdentity.Column.Name = "cantidad" Then
                        'If cc.Renderer IsNot Nothing Then
                        '    If cc.Renderer IsNot Nothing Then

                        '        Dim CodigoAlm As String = cc.Renderer.ControlText
                        '        Dim r As Record = style.TableCellIdentity.Table.CurrentRecord
                        '        If r IsNot Nothing Then

                        '            Dim codigoitemCompra = r.GetValue("idItemCompra")
                        '            Dim itemCompra = UCEstructuraDocumentocabecera.ListaproductosComprados.Where(Function(o) o.CodigoCosto = codigoitemCompra).SingleOrDefault
                        '            '   Dim precioUniarioSinIvaCompra = CalculoPrecioUnitario(itemCompra.montokardex, Decimal.Parse(r.GetValue("cantidad")))
                        '            Dim cantidadDisponible = itemCompra.monto1
                        '            Dim cantidadAñadida = sumaEntregas()

                        '            If cantidadAñadida > cantidadDisponible Then
                        '                MessageBox.Show("Debe ingresar un cantidad valida!", "Verificar rango", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        '                cc.Renderer.ControlValue = 0
                        '                cc.ConfirmChanges()
                        '                cc.EndEdit()
                        '                'Exit Sub
                        '            End If

                        '            If itemCompra IsNot Nothing Then
                        '                Dim InvMov = itemCompra.CustomListaInventarioMovimiento.Where(Function(i) i.codigoBarra = r.GetValue("codigo")).SingleOrDefault
                        '                If InvMov IsNot Nothing Then
                        '                    InvMov.cantidad = Decimal.Parse(r.GetValue("cantidad"))
                        '                    InvMov.monto = InvMov.GetImporteAlmacen
                        '                    r.SetValue("costo", InvMov.GetImporteAlmacen)
                        '                End If
                        '            End If
                        '        End If
                        '    End If
                        'End If

                    ElseIf style.TableCellIdentity.Column.Name = "cantidadcompra" Then
                        If cc.Renderer IsNot Nothing Then
                            If cc.Renderer IsNot Nothing Then
                                Dim CantidadActual As String = cc.Renderer.ControlText
                                Dim r As Record = style.TableCellIdentity.Table.CurrentRecord
                                If r IsNot Nothing Then

                                    Dim codigoitemCompra = r.GetValue("idItemCompra")
                                    Dim itemCompra = UCEstructuraDocumentocabecera.ListaproductosComprados.Where(Function(o) o.CodigoCosto = codigoitemCompra).SingleOrDefault
                                    '   Dim precioUniarioSinIvaCompra = CalculoPrecioUnitario(itemCompra.montokardex, Decimal.Parse(r.GetValue("cantidad")))
                                    Dim cantidadDisponible = itemCompra.monto1
                                    Dim cantidadAñadida = sumaEntregas()

                                    If cantidadAñadida > cantidadDisponible Then
                                        MessageBox.Show("Debe ingresar un cantidad valida!", "Verificar rango", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        cc.Renderer.ControlValue = 0
                                        cc.ConfirmChanges()
                                        cc.EndEdit()
                                        'Exit Sub
                                    End If

                                    If itemCompra IsNot Nothing Then
                                        Dim InvMov = itemCompra.CustomListaInventarioMovimiento.Where(Function(i) i.codigoBarra = r.GetValue("codigo")).SingleOrDefault
                                        If InvMov IsNot Nothing Then
                                            Dim cantidadDistribucion As Decimal = CDec(CantidadActual)
                                            Dim cantEquivalencia = cantidadDistribucion * itemCompra.CustomProducto_equivalencia.fraccionUnidad
                                            Dim precioUnitarioEq = CalculoPrecioUnitario(InvMov.monto, cantidadDistribucion)
                                            Dim costoEquivale = cantidadDistribucion * precioUnitarioEq

                                            InvMov.CantEntrada = cantidadDistribucion
                                            InvMov.cantidad = cantEquivalencia
                                            InvMov.precUnite = precioUnitarioEq
                                            InvMov.monto = costoEquivale 'InvMov.GetImporteAlmacen
                                            r.SetValue("costo", costoEquivale) 'InvMov.GetImporteAlmacen)
                                            r.SetValue("cantidad", cantEquivalencia)
                                            r.SetValue("preciounitario", precioUnitarioEq)
                                        End If
                                    End If
                                End If
                            End If
                        End If

                    ElseIf style.TableCellIdentity.Column.Name = "matricula" Then
                        If cc.Renderer IsNot Nothing Then
                            If cc.Renderer IsNot Nothing Then
                                Dim CodigoAlm As String = cc.Renderer.ControlText
                                Dim r As Record = GridCompra.Table.CurrentRecord
                                If r IsNot Nothing Then
                                    Dim codigoitemCompra = r.GetValue("idItemCompra")
                                    Dim itemCompra = UCEstructuraDocumentocabecera.ListaproductosComprados.Where(Function(o) o.CodigoCosto = codigoitemCompra).SingleOrDefault

                                    If itemCompra IsNot Nothing Then
                                        Dim InvMov = itemCompra.CustomListaInventarioMovimiento.Where(Function(i) i.codigoBarra = r.GetValue("codigo")).SingleOrDefault
                                        If InvMov IsNot Nothing Then
                                            InvMov.MatriculaVehiculo = r.GetValue("matricula")
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    ElseIf style.TableCellIdentity.Column.Name = "chofer" Then
                        If cc.Renderer IsNot Nothing Then
                            If cc.Renderer IsNot Nothing Then
                                Dim CodigoAlm As String = cc.Renderer.ControlText
                                Dim r As Record = GridCompra.Table.CurrentRecord
                                If r IsNot Nothing Then
                                    Dim codigoitemCompra = r.GetValue("idItemCompra")
                                    Dim itemCompra = UCEstructuraDocumentocabecera.ListaproductosComprados.Where(Function(o) o.CodigoCosto = codigoitemCompra).SingleOrDefault

                                    If itemCompra IsNot Nothing Then
                                        Dim InvMov = itemCompra.CustomListaInventarioMovimiento.Where(Function(i) i.codigoBarra = r.GetValue("codigo")).SingleOrDefault
                                        If InvMov IsNot Nothing Then
                                            InvMov.Chofer = r.GetValue("chofer")
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Function sumaEntregas() As Decimal
        sumaEntregas = 0
        For Each i In GridCompra.Table.Records
            sumaEntregas += Decimal.Parse(i.GetValue("cantidadcompra"))
        Next
    End Function

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        'If GridCompra.Table.SelectedRecords.Count > 0 Then
        'Dim f As New FormAsignarGuiaRemision
        '    f.StartPosition = FormStartPosition.CenterParent
        '    f.ShowDialog(Me)
        '    If f.Tag IsNot Nothing Then
        '        Dim guia = CType(f.Tag, TablasGenerales.EstructuraGuiaRemision)
        '        For Each i In GridCompra.Table.Records
        '            If i.GetValue("seleccionar") = True Then
        '                With i
        '                    .SetValue("serieGuia", guia.Serie)
        '                    .SetValue("numGuia", guia.numero)
        '                    .SetValue("matricula", guia.Matricula)
        '                    .SetValue("chofer", guia.Chofer)
        '                    .SetValue("codigoUser", guia.IdUsuario)
        '                    .SetValue("usuario", guia.NameUsuario)
        '                End With
        '                UpdateRecord(i, guia)
        '            End If
        '        Next
        '    End If
        'End If

    End Sub

    Private Sub UpdateRecord(r As Record, guia As EstructuraGuiaRemision)
        Dim codigoitemCompra = r.GetValue("idItemCompra")
        Dim itemCompra = UCEstructuraDocumentocabecera.ListaproductosComprados.Where(Function(o) o.CodigoCosto = codigoitemCompra).SingleOrDefault

        If itemCompra IsNot Nothing Then
            Dim InvMov = itemCompra.CustomListaInventarioMovimiento.Where(Function(i) i.codigoBarra = r.GetValue("codigo")).SingleOrDefault
            If InvMov IsNot Nothing Then
                InvMov.serie = guia.Serie
                InvMov.numero = guia.numero
                InvMov.Chofer = guia.Chofer
                InvMov.MatriculaVehiculo = guia.Matricula
                InvMov.CodigoUsuario = guia.IdUsuario
                InvMov.nombreUsuario = guia.NameUsuario
            End If
        End If
    End Sub
End Class
