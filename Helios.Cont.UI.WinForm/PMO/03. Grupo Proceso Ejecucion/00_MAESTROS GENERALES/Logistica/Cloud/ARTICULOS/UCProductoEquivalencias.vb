Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Public Class UCProductoEquivalencias

#Region "Attributes"
    Public Property ListaEquivalencia As List(Of detalleitem_equivalencias)
    Public Property frmNuevaExistencia As frmNuevaExistencia
#End Region

#Region "Constructors"
    Public Sub New(be As detalleitems)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'FormatoGridAvanzado(GridEquivalencia, False, False, 9.0F)
        'FormatoGridAvanzado(GridPrecios, False, False, 9.0F)
        FormatoGridBlack(GridEquivalencia, False)
        FormatoGridBlack(GridPrecios, False)
        ListaEquivalencia = New List(Of detalleitem_equivalencias)
        '  GetCombos()
        MappingArticulo(be)
        GetCombos()
        CargarEquivalenciasDefault()
        GridEquivalencia.TableDescriptor.Columns("fraccion").Width = 80
        'GridEquivalencia.TableDescriptor.Columns("contenido_neto").Appearance.AnyRecordFieldCell.CellType = "TextBox"
        GridEquivalencia.TableDescriptor.Columns("contenido_neto").Appearance.AnyRecordFieldCell.TextColor = Color.Black
        '       GridEquivalencia.TableDescriptor.Columns("unidadcomercial").Appearance.AlternateRecordFieldCell.TextColor = Color.Black
        'GetCombos()
        GridEquivalencia.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
    End Sub


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridBlack(GridEquivalencia, False)
        FormatoGridBlack(GridPrecios, False)
        ListaEquivalencia = New List(Of detalleitem_equivalencias)
        GetCombos()
        GridEquivalencia.TableDescriptor.Columns("fraccion").Width = 80
        'GridEquivalencia.TableDescriptor.Columns("contenido_neto").Appearance.AnyRecordFieldCell.CellType = "TextBox"
        GridEquivalencia.TableDescriptor.Columns("contenido_neto").Appearance.AnyRecordFieldCell.TextColor = Color.Black
        '       GridEquivalencia.TableDescriptor.Columns("unidadcomercial").Appearance.AlternateRecordFieldCell.TextColor = Color.Black
        'GetCombos()
        GridEquivalencia.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell

        TextCantMinima.MaxValue = 1.0
    End Sub

#End Region

#Region "Methods"
    Private Sub GetCombos()
        Dim tablaSA As New tablaDetalleSA
        Dim ggcStyle As GridTableCellStyleInfo = GridEquivalencia.TableDescriptor.Columns("detalle").Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = tablaSA.GetListaTablaDetalle(6, "1")
        ggcStyle.ValueMember = "codigoDetalle"
        ggcStyle.DisplayMember = "descripcion"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive
    End Sub


    Public Sub CargarEquivalenciasDefault()
        Dim equivalencia = TextPresentacion.Text.Trim

        AddEquivalent($"{"1"} {equivalencia}", 1)
        AddEquivalent($"{"3/4"} {equivalencia}", 0.75)
        AddEquivalent($"{"1/2"} {equivalencia}", 0.5)
        AddEquivalent($"{"1/4"} {equivalencia}", 0.25)
        AddEquivalent($"{"1/8"} {equivalencia}", 0.125)
        If TextPresentacion.Tag IsNot Nothing Then
            AddEquivalent($"{"1 unidad"} {equivalencia}", 1 / CDec(TextPresentacion.Tag))
        End If
    End Sub

    Public Sub CargarEquivalenciasDefaultOpcion2()
        Dim equivalencia = TextPresentacion.Text.Trim

        AddEquivalentV2(frmNuevaExistencia.UCNuenExistencia.cboUnidades.Text, 1)
        '   AddEquivalentV2("Caja", 5)
        AddEquivalentV2("Paquete", 5)
        AddEquivalentV2("Sub paquete", 50)
        AddEquivalentV2("Unidad", 300)

    End Sub

    Private Sub AddEquivalent(Text As String)
        Try
            Dim obj As New detalleitem_equivalencias
            Dim id = System.Guid.NewGuid()
            obj.estado = "A"
            obj.IDGUI = id.ToString()
            obj.detalle = Text
            obj.fraccionUnidad = 0
            obj.detalleitemequivalencia_catalogos = New List(Of detalleitemequivalencia_catalogos)
            ListaEquivalencia.Add(obj)
            LoadGridEquivalencias()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub AddEquivalent(Text As String, valor As Decimal)
        Try
            Dim obj As New detalleitem_equivalencias
            Dim id = System.Guid.NewGuid()
            obj.IDGUI = id.ToString()
            obj.estado = "A"
            obj.detalle = Text
            obj.fraccionUnidad = valor
            obj.detalleitemequivalencia_catalogos = New List(Of detalleitemequivalencia_catalogos)
            ListaEquivalencia.Add(obj)
            LoadGridEquivalencias()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub AddEquivalentV2(Text As String, contenido As String)
        Try
            Dim obj As New detalleitem_equivalencias
            Dim id = System.Guid.NewGuid()
            obj.IDGUI = id.ToString()
            obj.estado = "A"
            obj.detalle = Text
            obj.contenido = Decimal.Parse(contenido)
            obj.fraccionUnidad = 0
            obj.detalleitemequivalencia_catalogos = New List(Of detalleitemequivalencia_catalogos)
            ListaEquivalencia.Add(obj)
            LoadGridEquivalenciasV2()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub AddEquivalentV2(Text As String)
        Dim representacion As Integer = 0
        Dim valor = 0
        Dim cont As String = Nothing
        Try

            'If GridEquivalencia.Table.Records.Count >= 1 Then
            '    MessageBox.Show("No puede agregar dos o mas unidades comerciales", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    Exit Sub
            'End If

            If GridEquivalencia.Table.Records.Count = 0 Then
                cont = frmNuevaExistencia.UCNuenExistencia.cboUnidades.Text
                valor = 1
                representacion = 1
            Else
                valor = 0
                cont = "Describir..."
                representacion = 0
            End If

            Dim obj As New detalleitem_equivalencias
            Dim id = System.Guid.NewGuid()
            obj.IDGUI = id.ToString()
            obj.estado = "A"
            obj.detalle = frmNuevaExistencia.UCNuenExistencia.cboUnidades.SelectedValue
            obj.unidadComercial = cont
            obj.contenido = representacion
            obj.fraccionUnidad = valor
            obj.contenido_neto = 0
            obj.detalleitemequivalencia_catalogos = New List(Of detalleitemequivalencia_catalogos) From
                {
                New detalleitemequivalencia_catalogos With
                    {
                    .nombre_corto = "CATALOGO GENERAL",
                    .nombre_largo = "CATALOGO GENERAL",
                    .predeterminado = True,
                    .estado = 1
                    }
                }
            ListaEquivalencia.Add(obj)
            LoadGridEquivalenciasV2()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub AddEquivalentV2(UnidadComercial As String, contenido As Decimal?, Flag As String)
        Dim representacion As Integer = 0
        Dim valor As Decimal = 0
        Dim cont As String = Nothing
        Try

            'If GridEquivalencia.Table.Records.Count >= 1 Then
            '    MessageBox.Show("No puede agregar dos o mas unidades comerciales", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    Exit Sub
            'End If

            cont = UnidadComercial
            'If GridEquivalencia.Table.Records.Count = 0 Then
            '    cont = UnidadComercial
            '    valor = 1
            '    representacion = 1
            'Else

            '    cont = UnidadComercial

            '    Dim primeraFila As Decimal = Decimal.Parse(GridEquivalencia.Table.Records(0).GetValue("contenido_neto"))
            '    Dim content As Decimal = primeraFila / contenido
            '    representacion = content

            '    valor = 0

            '    valor = 1 / content
            'End If


            Dim obj As New detalleitem_equivalencias
            Dim id = System.Guid.NewGuid()
            obj.IDGUI = id.ToString()
            obj.estado = "A"
            obj.detalle = frmNuevaExistencia.UCNuenExistencia.cboUnidades.SelectedValue
            obj.unidadComercial = UnidadComercial
            obj.contenido = representacion
            obj.fraccionUnidad = valor
            obj.contenido_neto = contenido
            obj.flag = Flag
            obj.detalleitemequivalencia_catalogos = New List(Of detalleitemequivalencia_catalogos) From
                {
                New detalleitemequivalencia_catalogos With
                    {
                    .nombre_corto = "CATALOGO GENERAL",
                    .nombre_largo = "CATALOGO GENERAL",
                    .predeterminado = True,
                    .estado = 1
                    }
                }
            ListaEquivalencia.Add(obj)
            LoadGridEquivalenciasV2()
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

    Private Sub LoadGridEquivalenciasV2()

        Dim dt As New DataTable
        dt.Columns.Add("IDEQ")
        dt.Columns.Add("detalle")
        dt.Columns.Add("unidadcomercial")
        dt.Columns.Add("contenido")
        dt.Columns.Add("fraccion")
        dt.Columns.Add("resultado")
        dt.Columns.Add("contenido_neto")
        dt.Columns.Add("btNuevoPrecio")


        For Each i In ListaEquivalencia
            dt.Rows.Add(i.IDGUI, i.detalle, i.unidadComercial, i.contenido, i.fraccionUnidad, 0, i.contenido_neto.GetValueOrDefault)
        Next

        GridEquivalencia.DataSource = dt
    End Sub

    Private Sub MappingArticulo(be As detalleitems)
        txtProveedor.Text = be.descripcionItem
        TextPresentacion.Text = be.presentacion
        ' cboUnidades.SelectedValue = be.unidad1

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
            LoadGridEquivalenciasV2()
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
        '    LoadGridPrecios(eq.detalleitemequivalencia_catalogos.ToList)
    End Sub

    Private Sub GridEquivalencia_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles GridEquivalencia.TableControlDrawCell
        'If e.Inner.Style.CellType = "PushButton" Then
        '    e.Inner.Cancel = True

        '    ' //Draw the Image in a cell.
        '    If e.Inner.ColIndex = 4 Then
        '        e.Inner.Style.Description = "Precio"
        '        e.Inner.Style.TextColor = Color.Black
        '        e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
        '        Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
        '                                   New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
        '            )
        '        '    e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
        '    End If
        'End If
    End Sub

    Private Sub GridEquivalencia_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles GridEquivalencia.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        'Try
        '    If e.Inner.ColIndex = 4 Then
        '        Dim idEquivalencia = GridEquivalencia.TableModel(e.Inner.RowIndex, 1).CellValue

        '        Dim EQ = ListaEquivalencia.Where(Function(o) o.IDGUI = idEquivalencia).Single

        '        Dim codPrec = System.Guid.NewGuid()

        '        'EQ.detalleitemequivalencia_precios.Add(New detalleitemequivalencia_precios With
        '        '                                       {
        '        '                                       .equivalencia_idGUi = EQ.IDGUI,
        '        '                                       .IDGUI = codPrec.ToString(),
        '        '                                       .precio = 0,
        '        '                                       .precioCode = "NewPrice"
        '        '                                       })

        '        'LoadGridPrecios(EQ.detalleitemequivalencia_precios.ToList())

        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
        Me.Cursor = Cursors.Default
    End Sub

    'Private Sub LoadGridPrecios(list As List(Of detalleitemequivalencia_catalogos))
    '    Dim dt As New DataTable
    '    dt.Columns.Add("IdPrecio")
    '    dt.Columns.Add("detalle")
    '    dt.Columns.Add("fraccion")
    '    dt.Columns.Add("idparent")

    '    For Each i In list
    '        dt.Rows.Add(i.IDGUI,
    '                    i.precioCode, i.precio, i.equivalencia_idGUi)
    '    Next
    '    GridPrecios.DataSource = dt
    'End Sub

    Private Sub BunifuThinButton27_Click(sender As Object, e As EventArgs) Handles BunifuThinButton27.Click
        Tag = ListaEquivalencia
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim rPREC As Record = GridPrecios.Table.CurrentRecord
        Try
            If rPREC IsNot Nothing Then
                'GetEliminarPrecioSelID(rPREC)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Private Sub GetEliminarPrecioSelID(rPREC As Record)
    '    Dim idPrec = rPREC.GetValue("IdPrecio")
    '    Dim idEQ = rPREC.GetValue("idparent")

    '    Dim eq = ListaEquivalencia.Where(Function(o) o.IDGUI = idEQ).Single
    '    Dim prec = eq.detalleitemequivalencia_precios.Where(Function(o) o.IDGUI = idPrec And o.equivalencia_idGUi = idEQ).Single
    '    eq.detalleitemequivalencia_precios.Remove(prec)

    '    LoadGridPrecios(eq.detalleitemequivalencia_precios.ToList)
    'End Sub

    Private Sub GridEquivalencia_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles GridEquivalencia.TableControlCurrentCellEditingComplete
        'Dim cc As GridCurrentCell = GridEquivalencia.TableControl.CurrentCell
        'cc.ConfirmChanges()

        'If cc.ColIndex > -1 Then
        '    Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

        '    If style.TableCellIdentity.Column.Name = "detalle" Or style.TableCellIdentity.Column.Name = "unidadcomercial" Then
        '        Dim text As String = cc.Renderer.ControlText

        '        If text.Trim.Length > 0 Then
        '            cc.Renderer.ControlValue = text
        '            Dim r = GridEquivalencia.Table.CurrentRecord
        '            EditarEquivalencia(r)
        '        End If
        '    ElseIf style.TableCellIdentity.Column.Name = "contenido" Then '  respresentacion numero
        '        Dim text As String = cc.Renderer.ControlText

        '        If text.Trim.Length > 0 Then
        '            cc.Renderer.ControlValue = text
        '            Dim r = GridEquivalencia.Table.CurrentRecord
        '            If r IsNot Nothing Then

        '                Dim idEQ = r.GetValue("IDEQ")
        '                Dim eq = ListaEquivalencia.Where(Function(o) o.IDGUI = idEQ).Single

        '                Dim contenido = CDec(text) 'CDec(r.GetValue("contenido"))
        '                eq.contenido = contenido
        '                Dim fraccion As Decimal = 0
        '                If contenido > 0 Then
        '                    fraccion = 1 / contenido
        '                End If
        '                eq.fraccionUnidad = fraccion 'CDec(r.GetValue("fraccion"))

        '                r.SetValue("fraccion", fraccion)
        '                GridEquivalencia.Refresh()
        '            End If
        '        End If
        '    ElseIf style.TableCellIdentity.Column.Name = "fraccion" Then
        '        Dim text As String = cc.Renderer.ControlText

        '        If text.Trim.Length > 0 Then
        '            Dim value As Decimal = Convert.ToDecimal(text)
        '            cc.Renderer.ControlValue = value
        '            Dim r = GridEquivalencia.Table.CurrentRecord
        '            EditarEquivalencia(r)
        '        End If
        '    End If
        'End If
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
            eq.unidadComercial = r.GetValue("unidadcomercial")
            eq.contenido = Decimal.Parse(r.GetValue("contenido"))
            eq.fraccionUnidad = CDec(r.GetValue("fraccion"))
            eq.contenido_neto = CDec(r.GetValue("contenido_neto"))
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
                    ' EditarPrecio(r)
                End If
            ElseIf style.TableCellIdentity.Column.Name = "fraccion" Then
                Dim text As String = cc.Renderer.ControlText

                If text.Trim.Length > 0 Then
                    Dim value As Decimal = Convert.ToDecimal(text)
                    cc.Renderer.ControlValue = value
                    Dim r = GridPrecios.Table.CurrentRecord
                    'Dim rEQ = GridEquivalencia.Table.CurrentRecord
                    'EditarPrecio(r)
                End If
            End If
        End If
    End Sub

    'Private Sub EditarPrecio(r As Record)
    '    If r IsNot Nothing Then
    '        Dim idEQ = r.GetValue("idparent")
    '        Dim idPrec = r.GetValue("IdPrecio")
    '        Dim eq = ListaEquivalencia.Where(Function(o) o.IDGUI = idEQ).Single
    '        Dim prec = eq.detalleitemequivalencia_precios.Where(Function(o) o.IDGUI = idPrec AndAlso o.equivalencia_idGUi = idEQ).Single

    '        prec.precioCode = r.GetValue("detalle")
    '        prec.precio = Decimal.Parse(r.GetValue("fraccion"))
    '        GridPrecios.Refresh()
    '    End If

    'End Sub

    Private Sub cboUnidades_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub cboUnidades_SelectedValueChanged(sender As Object, e As EventArgs)
        'If cboUnidades.Text.Trim.Length > 0 Then
        '    'If cboUnidades.Text.Trim.Length <= 10 Then
        '    BunifuThinButton21.ButtonText = $"{cboUnidades.Text}"
        '    BunifuThinButton22.ButtonText = $"3/4 {cboUnidades.Text}"
        '    BunifuThinButton23.ButtonText = $"1/2 {cboUnidades.Text}"
        '    BunifuThinButton24.ButtonText = $"DOCENA"
        '    BunifuThinButton25.ButtonText = $"UNIDAD"
        '    ' End If
        'End If
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked

        Select Case ComboPlantilla.Text
            Case "1 UNIDAD COMERCIAL"
                AddEquivalentV2(BunifuThinButton26.ButtonText)
            Case "MIN. Y MAX. UNIDAD COMERCIAL"
                AddEquivalentV2(BunifuThinButton26.ButtonText)
            Case "MANUAL"
                AddEquivalentV2(BunifuThinButton26.ButtonText)
        End Select

    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        ListaEquivalencia = New List(Of detalleitem_equivalencias)
        'CargarEquivalenciasDefault()
        CargarEquivalenciasDefaultOpcion2()
        'UCEquivalencias.BringToFront()
    End Sub

    Private Sub GridEquivalencia_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles GridEquivalencia.TableControlCurrentCellCloseDropDown
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

            End If
        End If
    End Sub

    Private Sub GridEquivalencia_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs) Handles GridEquivalencia.TableControlCurrentCellChanged
        Dim cc As GridCurrentCell = GridEquivalencia.TableControl.CurrentCell
        cc.ConfirmChanges()

        If cc.ColIndex > -1 Then
            Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

            If style.TableCellIdentity.Column.Name = "detalle" Or style.TableCellIdentity.Column.Name = "unidadcomercial" Then
                Dim text As String = cc.Renderer.ControlText

                If text.Trim.Length > 0 Then
                    cc.Renderer.ControlValue = text
                    Dim r = GridEquivalencia.Table.CurrentRecord
                    EditarEquivalencia(r)
                End If
            ElseIf style.TableCellIdentity.Column.Name = "contenido" Then '  respresentacion numero
                'Dim text As String = cc.Renderer.ControlText

                'If text.Trim.Length > 0 Then
                '    cc.Renderer.ControlValue = text
                '    Dim r = GridEquivalencia.Table.CurrentRecord
                '    If r IsNot Nothing Then

                '        Dim idEQ = r.GetValue("IDEQ")
                '        Dim eq = ListaEquivalencia.Where(Function(o) o.IDGUI = idEQ).Single

                '        Dim contenido = CDec(text) 'CDec(r.GetValue("contenido"))
                '        eq.contenido = contenido
                '        Dim fraccion As Decimal = 0
                '        If contenido > 0 Then
                '            fraccion = 1 / contenido
                '        End If
                '        eq.fraccionUnidad = fraccion 'CDec(r.GetValue("fraccion"))

                '        r.SetValue("fraccion", fraccion)
                '        GridEquivalencia.Refresh()
                '    End If
                'End If
            ElseIf style.TableCellIdentity.Column.Name = "fraccion" Then
                Dim text As String = cc.Renderer.ControlText

                If text.Trim.Length > 0 Then
                    Dim value As Decimal = Convert.ToDecimal(text)
                    cc.Renderer.ControlValue = value
                    Dim r = GridEquivalencia.Table.CurrentRecord
                    EditarEquivalencia(r)
                End If
            ElseIf style.TableCellIdentity.Column.Name = "contenido_neto" Then
                Dim text As String = cc.Renderer.ControlText

                If text.Trim.Length > 0 Then
                    cc.Renderer.ControlValue = text
                    Dim r = GridEquivalencia.Table.CurrentRecord

                    'calculando representacion
                    If GridEquivalencia.Table.Records.Count = 1 Then
                        If IsNumeric(cc.Renderer.ControlText) Then
                            If CDec(cc.Renderer.ControlText) > 0 Then
                                r.SetValue("contenido", CDec(cc.Renderer.ControlText) / CDec(cc.Renderer.ControlText))
                            Else
                                r.SetValue("contenido", 0)
                            End If
                        Else
                            cc.Renderer.ControlText = 0
                            r.SetValue("contenido", 0)
                        End If
                    Else
                        If IsNumeric(cc.Renderer.ControlText) Then
                            If CDec(cc.Renderer.ControlText) > 0 Then
                                Dim primeraFila = Decimal.Parse(GridEquivalencia.Table.Records(0).GetValue("contenido_neto"))
                                r.SetValue("contenido", primeraFila / CDec(cc.Renderer.ControlText))
                            Else
                                r.SetValue("contenido", 0)
                                r.SetValue("fraccion", 0)
                                EditarEquivalencia(r)
                                Exit Sub
                            End If
                        End If
                    End If

                    Dim contenido = Decimal.Parse(r.GetValue("contenido"))
                    Dim idEQ = r.GetValue("IDEQ")
                    Dim eq = ListaEquivalencia.Where(Function(o) o.IDGUI = idEQ).Single
                    Dim fraccion As Decimal = 0
                    If contenido > 0 Then
                        fraccion = 1 / contenido
                    End If
                    eq.fraccionUnidad = fraccion
                    r.SetValue("fraccion", fraccion)
                    EditarEquivalencia(r)
                End If
            End If
        End If
    End Sub

    Private Sub ComboPlantilla_Click(sender As Object, e As EventArgs) Handles ComboPlantilla.Click

    End Sub

    Private Sub ComboPlantilla_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboPlantilla.SelectedValueChanged

        If ComboPlantilla.Text.Trim.Length > 0 Then
            ListaEquivalencia = New List(Of detalleitem_equivalencias)
            LoadGridEquivalenciasV2()
            Select Case ComboPlantilla.Text
                Case "SÓLO UNIDAD COMERCIAL"
                    PaneluNIDAD.Visible = True
                    LabelmAX.Visible = False
                    LabelContMax.Visible = False
                    TextUCMaxima.Visible = False
                    TextCantMax.Visible = False

                    'PaneluNIDAD.Visible = False
                    LinkLabel3.Visible = True
                Case "VARIAS UNIDADES COMERCIALES(ESTABLECER :MIN. Y MAX.)"
                    LabelmAX.Visible = True
                    LabelContMax.Visible = True
                    TextUCMaxima.Visible = True
                    TextCantMax.Visible = True

                    PaneluNIDAD.Visible = True
                    LinkLabel3.Visible = False
                Case "MANUAL"
                    PaneluNIDAD.Visible = False
                    LinkLabel3.Visible = True
            End Select
        End If


    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        If TextUCMaxima.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingresar la unidad comercial maxima!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If TextUCMinima.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingresar la unidad comercial maxima!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        AddEquivalentV2(TextUCMaxima.Text, TextCantMax.DecimalValue)
        AddEquivalentV2(TextUCMinima.Text, TextCantMinima.DecimalValue)
        '  PaneluNIDAD.Visible = False
    End Sub

    Private Sub TextCantMax_TextChanged(sender As Object, e As EventArgs) Handles TextCantMax.TextChanged



        'TextCantMinima.MaxValue = TextCantMax.DecimalValue

    End Sub

    Private Sub TextCantMinima_TextChanged(sender As Object, e As EventArgs) Handles TextCantMinima.TextChanged
        'If TextCantMinima.DecimalValue = 0 Then
        '    TextCantMinima.DecimalValue = 1
        'End If
    End Sub



#End Region

End Class
