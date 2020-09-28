Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class FormCrearEquivalenciasArticulo

#Region "Attributes"
    Public Property ListaEquivalencia As List(Of detalleitem_equivalencias)
#End Region

#Region "Methods"
    Private Sub AddEquivalent(Text As String)
        Try
            Dim obj As New detalleitem_equivalencias
            Dim id = System.Guid.NewGuid()
            obj.IDGUI = id.ToString()
            obj.detalle = Text
            obj.fraccionUnidad = 0
            '    obj.detalleitemequivalencia_precios = New List(Of detalleitemequivalencia_precios)
            ListaEquivalencia.Add(obj)
            LoadGridEquivalencias()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub LoadGridEquivalencias()
        Dim dt As New DataTable
        dt.Columns.Add("IDEQ")
        dt.Columns.Add("detalle")
        dt.Columns.Add("fraccion")
        dt.Columns.Add("btNuevoPrecio")

        For Each i In ListaEquivalencia
            dt.Rows.Add(i.IDGUI, i.detalle, i.fraccionUnidad)
        Next
        GridEquivalencia.DataSource = dt
    End Sub

    Private Sub MappingArticulo(be As detalleitems)
        txtProveedor.Text = be.descripcionItem
        cboUnidades.SelectedValue = be.unidad1
    End Sub

    Private Sub GetCombos()
        Dim tablaSA As New tablaDetalleSA
        Dim ListaUnidadaes = tablaSA.GetListaTablaDetalle(6, "1")
        cboUnidades.DataSource = ListaUnidadaes
        cboUnidades.DisplayMember = "descripcion"
        cboUnidades.ValueMember = "codigoDetalle"
    End Sub
#End Region

#Region "Constructors"
    Public Sub New(be As detalleitems)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(GridEquivalencia, False, False, 9.0F)
        FormatoGridAvanzado(GridPrecios, False, False, 9.0F)
        ListaEquivalencia = New List(Of detalleitem_equivalencias)
        GetCombos()
        MappingArticulo(be)
    End Sub
#End Region

#Region "Events"
    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click
        AddEquivalent(BunifuThinButton21.ButtonText)
    End Sub

    Private Sub BunifuThinButton22_Click(sender As Object, e As EventArgs) Handles BunifuThinButton22.Click
        AddEquivalent(BunifuThinButton22.ButtonText)
    End Sub

    Private Sub BunifuThinButton23_Click(sender As Object, e As EventArgs) Handles BunifuThinButton23.Click
        AddEquivalent(BunifuThinButton23.ButtonText)
    End Sub

    Private Sub BunifuThinButton24_Click(sender As Object, e As EventArgs) Handles BunifuThinButton24.Click
        AddEquivalent(BunifuThinButton24.ButtonText)
    End Sub

    Private Sub BunifuThinButton25_Click(sender As Object, e As EventArgs) Handles BunifuThinButton25.Click
        AddEquivalent(BunifuThinButton25.ButtonText)
    End Sub

    Private Sub BunifuThinButton26_Click(sender As Object, e As EventArgs) Handles BunifuThinButton26.Click
        AddEquivalent(BunifuThinButton26.ButtonText)
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim r As Record = GridEquivalencia.Table.CurrentRecord
        If r IsNot Nothing Then
            Dim id = r.GetValue("IDEQ")
            Dim eq = ListaEquivalencia.Where(Function(o) o.IDGUI = id).Single
            ListaEquivalencia.Remove(eq)
            LoadGridEquivalencias()
        End If
    End Sub

    Private Sub GridEquivalencia_TableControlCellClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles GridEquivalencia.TableControlCellClick
        Dim r As Record = GridEquivalencia.Table.CurrentRecord
        If r IsNot Nothing Then
            If GridEquivalencia.Table.Records.Count > 0 Then
                Dim idEQ = r.GetValue("IDEQ")
                GetPreciosSelEquivalencia(idEQ)
            End If
        End If
    End Sub

    Private Sub GridEquivalencia_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles GridEquivalencia.SelectedRecordsChanged
        Cursor = Cursors.WaitCursor
        Try
            If e.SelectedRecord IsNot Nothing Then
                Dim r As Record = e.SelectedRecord.Record
                If r IsNot Nothing Then
                    If GridEquivalencia.Table.Records.Count > 0 Then
                        Dim idEQ = r.GetValue("IDEQ")
                        GetPreciosSelEquivalencia(idEQ)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub GetPreciosSelEquivalencia(idEQ As Object)
        Dim eq = ListaEquivalencia.Where(Function(o) o.IDGUI = idEQ).Single
        '     LoadGridPrecios(eq.detalleitemequivalencia_precios.ToList)
    End Sub

    Private Sub GridEquivalencia_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles GridEquivalencia.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 4 Then
                e.Inner.Style.Description = "Precio"
                e.Inner.Style.TextColor = Color.Black
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
                                           New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
                    )
                '    e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
            End If
        End If
    End Sub

    Private Sub GridEquivalencia_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles GridEquivalencia.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.Inner.ColIndex = 4 Then
                Dim idEquivalencia = GridEquivalencia.TableModel(e.Inner.RowIndex, 1).CellValue

                Dim EQ = ListaEquivalencia.Where(Function(o) o.IDGUI = idEquivalencia).Single

                Dim codPrec = System.Guid.NewGuid()

                'EQ.detalleitemequivalencia_precios.Add(New detalleitemequivalencia_precios With
                '                                       {
                '                                       .equivalencia_idGUi = EQ.IDGUI,
                '                                       .IDGUI = codPrec.ToString(),
                '                                       .precio = 0,
                '                                       .precioCode = "NewPrice"
                '                                       })

                'LoadGridPrecios(EQ.detalleitemequivalencia_precios.ToList())

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadGridPrecios(list As List(Of detalleitemequivalencia_precios))
        Dim dt As New DataTable
        dt.Columns.Add("IdPrecio")
        dt.Columns.Add("detalle")
        dt.Columns.Add("fraccion")
        dt.Columns.Add("idparent")

        For Each i In list
            dt.Rows.Add(i.IDGUI,
                        i.precioCode, i.precio, i.equivalencia_idGUi)
        Next
        GridPrecios.DataSource = dt
    End Sub

    Private Sub BunifuThinButton27_Click(sender As Object, e As EventArgs) Handles BunifuThinButton27.Click
        Tag = ListaEquivalencia
        Close()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        'Dim rEQ As Record = GridEquivalencia.Table.CurrentRecord
        Dim rPREC As Record = GridPrecios.Table.CurrentRecord
        Try
            If rPREC IsNot Nothing Then
                GetEliminarPrecioSelID(rPREC)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GetEliminarPrecioSelID(rPREC As Record)
        Dim idPrec = rPREC.GetValue("IdPrecio")
        Dim idEQ = rPREC.GetValue("idparent")

        Dim eq = ListaEquivalencia.Where(Function(o) o.IDGUI = idEQ).Single
        'Dim prec = eq.detalleitemequivalencia_precios.Where(Function(o) o.IDGUI = idPrec And o.equivalencia_idGUi = idEQ).Single
        'eq.detalleitemequivalencia_precios.Remove(prec)

        'LoadGridPrecios(eq.detalleitemequivalencia_precios.ToList)
    End Sub

    Private Sub GridEquivalencia_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles GridEquivalencia.TableControlCurrentCellEditingComplete
        Dim cc As GridCurrentCell = GridEquivalencia.TableControl.CurrentCell
        cc.ConfirmChanges()

        If cc.ColIndex > -1 Then
            Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

            If style.TableCellIdentity.Column.Name = "detalle" Then
                Dim text As String = cc.Renderer.ControlText

                If text.Trim.Length > 0 Then
                    cc.Renderer.ControlValue = text
                    Dim r = GridEquivalencia.Table.CurrentRecord
                    EditarEquivalencia(r)
                End If
            ElseIf style.TableCellIdentity.Column.Name = "fraccion" Then
                Dim text As String = cc.Renderer.ControlText

                If text.Trim.Length > 0 Then
                    Dim value As Decimal = Convert.ToDecimal(text)
                    cc.Renderer.ControlValue = value
                    Dim r = GridEquivalencia.Table.CurrentRecord
                    EditarEquivalencia(r)
                End If
            End If
        End If
    End Sub

    Private Sub GridEquivalencia_TableControlKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles GridEquivalencia.TableControlKeyDown
        Try
            Dim cc As GridCurrentCell = GridEquivalencia.TableControl.CurrentCell
            If cc.RowIndex > -1 Then
                If e.Inner.KeyCode = Keys.Up Then
                    If cc IsNot Nothing Then
                        cc.ConfirmChanges()
                        If cc.RowIndex = 2 Then
                            Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex, cc.ColIndex), GridTableCellStyleInfo)
                            Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                            Dim idEQ = currenrecord.GetValue("IDEQ")
                            GetPreciosSelEquivalencia(idEQ)
                        Else
                            Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex - 1, cc.ColIndex), GridTableCellStyleInfo)
                            Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                            Dim idEQ = currenrecord.GetValue("IDEQ")
                            GetPreciosSelEquivalencia(idEQ)
                        End If

                    End If
                ElseIf e.Inner.KeyCode = Keys.Down Then
                    If cc IsNot Nothing Then
                        cc.ConfirmChanges()
                        Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex + 1, cc.ColIndex), GridTableCellStyleInfo)
                        If style IsNot Nothing Then
                            ' Dim rows = dgvCompra.Table.Records.Count
                            If style.TableCellIdentity IsNot Nothing Then
                                Dim currenrecord = style.TableCellIdentity.DisplayElement.GetRecord()
                                If currenrecord IsNot Nothing Then
                                    Dim idEQ = currenrecord.GetValue("IDEQ")
                                    GetPreciosSelEquivalencia(idEQ)
                                End If
                            End If

                        End If

                    End If

                Else
                    cc.ConfirmChanges()
                    Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex, cc.ColIndex), GridTableCellStyleInfo)
                    Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                    Dim idEQ = currenrecord.GetValue("IDEQ")
                    GetPreciosSelEquivalencia(idEQ)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub EditarEquivalencia(r As Record)
        If r IsNot Nothing Then
            Dim idEQ = r.GetValue("IDEQ")
            Dim eq = ListaEquivalencia.Where(Function(o) o.IDGUI = idEQ).Single
            eq.detalle = r.GetValue("detalle")
            eq.fraccionUnidad = CDec(r.GetValue("fraccion"))
            GridEquivalencia.Refresh()
        End If
    End Sub

    Private Sub GridPrecios_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridPrecios.TableControlCellClick

    End Sub

    Private Sub GridPrecios_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles GridPrecios.TableControlCurrentCellEditingComplete
        Dim cc As GridCurrentCell = GridPrecios.TableControl.CurrentCell
        cc.ConfirmChanges()

        If cc.ColIndex > -1 Then
            Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

            If style.TableCellIdentity.Column.Name = "detalle" Then
                Dim text As String = cc.Renderer.ControlText

                If text.Trim.Length > 0 Then
                    cc.Renderer.ControlValue = text
                    Dim r = GridPrecios.Table.CurrentRecord
                    ' Dim rEQ = GridEquivalencia.Table.CurrentRecord
                    EditarPrecio(r)
                End If
            ElseIf style.TableCellIdentity.Column.Name = "fraccion" Then
                Dim text As String = cc.Renderer.ControlText

                If text.Trim.Length > 0 Then
                    Dim value As Decimal = Convert.ToDecimal(text)
                    cc.Renderer.ControlValue = value
                    Dim r = GridPrecios.Table.CurrentRecord
                    'Dim rEQ = GridEquivalencia.Table.CurrentRecord
                    EditarPrecio(r)
                End If
            End If
        End If
    End Sub

    Private Sub EditarPrecio(r As Record)
        If r IsNot Nothing Then
            Dim idEQ = r.GetValue("idparent")
            Dim idPrec = r.GetValue("IdPrecio")
            Dim eq = ListaEquivalencia.Where(Function(o) o.IDGUI = idEQ).Single
            '  Dim prec = eq.detalleitemequivalencia_precios.Where(Function(o) o.IDGUI = idPrec AndAlso o.equivalencia_idGUi = idEQ).Single

            'prec.precioCode = r.GetValue("detalle")
            'prec.precio = Decimal.Parse(r.GetValue("fraccion"))
            GridPrecios.Refresh()
        End If

    End Sub

    Private Sub cboUnidades_Click(sender As Object, e As EventArgs) Handles cboUnidades.Click

    End Sub

    Private Sub cboUnidades_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboUnidades.SelectedValueChanged
        If cboUnidades.Text.Trim.Length > 0 Then
            If cboUnidades.Text.Trim.Length <= 10 Then
                BunifuThinButton21.ButtonText = $"{cboUnidades.Text}"
                BunifuThinButton22.ButtonText = $"3/4 {cboUnidades.Text}"
                BunifuThinButton23.ButtonText = $"1/2 {cboUnidades.Text}"
                BunifuThinButton24.ButtonText = $"DOCENA"
                BunifuThinButton25.ButtonText = $"UNIDAD"
            End If
        End If
    End Sub
#End Region

End Class