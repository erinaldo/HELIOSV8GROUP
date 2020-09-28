Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess

Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Public Class frmNotify
    Inherits frmMaster

#Region "Métodos"
    Dim dt As New DataTable
    Public Sub Listado()
        Dim entidadSa As New entidadSA

        Dim entidad As New List(Of entidad)

        dt.Columns.Add("idEntidad")
        dt.Columns.Add("Entidad")
        dt.Columns.Add("tipo")
        dt.Columns.Add("idEmpresa")
        Dim str As String = Nothing

        For Each i In entidadSa.GetListarEntidad(New entidad With {.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.idEntidad & vbCrLf & i.nombreCompleto
            dr(1) = i.nombreCompleto
            dr(2) = IIf(i.tipoPersona = "N", "NATURAL", "JURIDICO")
            dr(3) = i.idEmpresa
            dt.Rows.Add(dr)
        Next
        dgvCompras.DataSource = dt
        dgvCompras.TableDescriptor.Columns(1).Width = 350


        'Me.gridGroupingControl1.TableDescriptor.TableOptions.ShowRowHeader = False
        'Me.gridGroupingControl1.Table.ExpandAllGroups()
        ''Me.gridGroupingControl1.ChildGroupOptions.CaptionText = Me.gridGroupingControl1.TableDescriptor.GroupedColumns(0).Name.ToString()
        'Me.gridGroupingControl1.ShowRowHeaders = False
        'Me.gridGroupingControl1.ShowColumnHeaders = False
        'Me.gridGroupingControl1.TopLevelGroupOptions.ShowAddNewRecordAfterDetails = False
        'Me.gridGroupingControl1.TableDescriptor.AllowEdit = False
        'Me.gridGroupingControl1.TableDescriptor.AllowNew = False
        'Me.gridGroupingControl1.TopLevelGroupOptions.ShowCaption = False
        '' Me.gridGroupingControl1.TableControlCurrentCellStartEditing += New Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCancelEventHandler(gridGroupingControl1_TableControlCurrentCellStartEditing)
        'Me.gridGroupingControl1.Table.DefaultRecordRowHeight = 57
        'Me.gridGroupingControl1.Table.ExpandAllGroups()
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.None
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
        ''   Me.gridGroupingControl1.QueryCellStyleInfo += New Syncfusion.Windows.Forms.Grid.Grouping.GridTableCellStyleInfoEventHandler(gridGroupingControl1_QueryCellStyleInfo)
        'Me.gridGroupingControl1.ActivateCurrentCellBehavior = Syncfusion.Windows.Forms.Grid.GridCellActivateAction.None
        'Me.gridGroupingControl1.TableModel.CellModels.Add("OutlookHeaderCell", New OutlookCell.OutlookHeaderCellModel(Me.gridGroupingControl1.TableModel))
        ''    Me.gridGroupingControl1.TableModel.QueryColWidth += New Syncfusion.Windows.Forms.Grid.GridRowColSizeEventHandler(TableModel_QueryColWidth)
        ''Me.gridGroupingControl1.TableControlCellClick += New Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventHandler(gridGroupingControl1_TableControlCellClick)
        ''    Me.setMessageTextBoxText()
        'Me.gridGroupingControl1.TableOptions.SelectionBackColor = ColorTranslator.FromHtml("#CDE6F7")
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionOutlineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Standard)
        ''   Me.gridGroupingControl1.TableControlCellMouseHover += New Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellMouseEventHandler(gridGroupingControl1_TableControlCellMouseHover)
        'AddHandler Me.gridGroupingControl1.TableModel.QueryRowHeight, AddressOf TableModel_QueryRowHeight

        'AddHandler Me.gridGroupingControl1.TableControl.MouseWheel, AddressOf TableControl_MouseWheel


        'AddHandler Me.gridGroupingControl1.TableControl.ScrollbarsVisibleChanged, AddressOf TableControl_ScrollbarsVisibleChanged
        ''    Me.gridGroupingControl1.TableModel.QueryRowHeight += New GridRowColSizeEventHandler(TableModel_QueryRowHeight)
        '' Me.gridGroupingControl1.TableControl.MouseWheel += New MouseEventHandler(TableControl_MouseWheel)
        ''     Me.gridGroupingControl1.TableControlDrawCellDisplayText += New Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlDrawCellDisplayTextEventHandler(gridGroupingControl1_TableControlDrawCellDisplayText)
        ''Me.gridGroupingControl1.TableControl.ScrollbarsVisibleChanged += New EventHandler(TableControl_ScrollbarsVisibleChanged)
        ''    Me.gridGroupingControl1.TableControlDrawCell += New Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlDrawCellEventHandler(gridGroupingControl1_TableControlDrawCell)
        'Me.gridGroupingControl1.DefaultGridBorderStyle = GridBorderStyle.None
        'Me.gridGroupingControl1.BorderStyle = BorderStyle.None
        ''    Me.InnerSplitterContainer.SplitterDistance = Me.outlookSearchBox1.Width - 40
        ''     mailSplitterDistance = Me.splitContainerAdv1.SplitterDistance
        ''    readerSplitterDistance = Me.InnerSplitterContainer.SplitterDistance
        ''   Me.splitContainerAdv1.SplitterMoved += New Syncfusion.Windows.Forms.Tools.Events.SplitterMoveEventHandler(splitContainerAdv1_SplitterMoved)
        ''  Me.InnerSplitterContainer.SplitterMoved += New Syncfusion.Windows.Forms.Tools.Events.SplitterMoveEventHandler(InnerSplitterContainer_SplitterMoved)
        ''    Me.statusStripEx1.MetroColor = System.Drawing.Color.FromArgb(CInt(CByte(0)), CInt(CByte(114)), CInt(CByte(198)))
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionCurrentCellOptions = GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        'Me.gridGroupingControl1.TableOptions.SelectionBackColor = Color.White
        ''ColorTranslator.FromHtml("#CDE6F7");
        'Me.gridGroupingControl1.Appearance.GroupCaptionPlusMinusCell.BackColor = ColorTranslator.FromHtml("#F0F0F0")
        ''Me.gridGroupingControl1.TableControlPrepareViewStyleInfo += New GridTableControlPrepareViewStyleInfoEventHandler(gridGroupingControl1_TableControlPrepareViewStyleInfo)
        ''Me.gridGroupingControl1.TableControlCellMouseHoverEnter += New GridTableControlCellMouseEventHandler(gridGroupingControl1_TableControlCellMouseHoverEnter)
        ''  Me.gridGroupingControl1.TableControlCellMouseHoverLeave += New GridTableControlCellMouseEventHandler(gridGroupingControl1_TableControlCellMouseHoverLeave)
        ''    Me.gridGroupingControl1.TableControl.VScrollPixelPosChanging += New GridScrollPositionChangingEventHandler(TableControl_VScrollPixelPosChanging)

        ''     this.gridGroupingControl1.TableControlCellDrawn += new GridTableControlDrawCellEventHandler(gridGroupingControl1_TableControlCellDrawn);
        ''  Me.InnerSplitterContainer.SplitterMoving += New Syncfusion.Windows.Forms.Tools.Events.SplitterMoveEventHandler(InnerSplitterContainer_SplitterMoving)
        ''   dt = ds.Tables(0)
        'AddHandler Me.gridGroupingControl1.TableModel.QueryColWidth, AddressOf TableModel_QueryColWidth
        ''  Me.gridGroupingControl1.TableModel.QueryColWidth += New GridRowColSizeEventHandler(TableModel_QueryColWidth)
        ''   Me.gridGroupingControl1.TableControlCellMouseHover += New GridTableControlCellMouseEventHandler(gridGroupingControl1_TableControlCellMouseHover)
        ''   Me.gridGroupingControl1.TableControl.CellClick += New GridCellClickEventHandler(TableControl_CellClick)
        ''  Me.gridGroupingControl1.VisibleChanged += New EventHandler(gridGroupingControl1_VisibleChanged)
        'AddHandler Me.gridGroupingControl1.TableControlCellDrawn, AddressOf gridGroupingControl1_TableControlCellDrawn

        'Me.gridGroupingControl1.AllowProportionalColumnSizing = True
        'Me.gridGroupingControl1.TableControl.Refresh()
      
    End Sub
#End Region

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Listado()
    End Sub

    'Dim degreeOfPercentage As Integer = 100
    'Dim rowIndex As Integer = 0
    'Private Sub gridGroupingControl1_TableControlCellDrawn(sender As Object, e As GridTableControlDrawCellEventArgs)
    '    Dim ht As Integer = 20
    '    If degreeOfPercentage <> 100 Then
    '        ht = ht + ht * degreeOfPercentage / 100 + 2
    '    End If
    '    If e.Inner.Style.CellType = "OutlookHeaderCell" Then
    '        rowIndex = e.Inner.RowIndex
    '        Dim g As Graphics = e.Inner.Graphics
    '        Dim clRect As Rectangle = e.Inner.Bounds
    '        Dim result As Integer = 0
    '        If Integer.TryParse(e.Inner.Style.ValueMember, result) Then
    '            'If Not unreadMessage.Contains(rowIndex) Then
    '            '    unreadMessage.Add(rowIndex)
    '            'End If
    '        End If

    '        Dim firstDrawString As New Rectangle(clRect.X + 2, clRect.Y + 1, clRect.Width - 110, ht)
    '        Dim secondDrawString As New Rectangle(clRect.X + 2, clRect.Y + 22, clRect.Width - 110, ht - 4)
    '        Dim thirdDrawString As New Rectangle(clRect.X + 2, clRect.Y + 38, clRect.Width - 110, ht - 6)
    '        Dim fourthDrawString As New Rectangle(clRect.Width - 90, clRect.Y + 22, 100, ht - 6)
    '        Dim fifthDrawString As New Rectangle()
    '        Dim firstFont As New Font("Segoe UI", 11.5F)
    '        Dim secondFont As New Font("Segoe UI", 9.0F)
    '        Dim thirdFont As New Font("Segoe UI", 8.0F)
    '        Dim fourthFont As New Font("Segoe UI", 8.0F)
    '        Dim firstBrush As New SolidBrush(ColorTranslator.FromHtml("#0E0E0E"))
    '        Dim secondBrush As New SolidBrush(ColorTranslator.FromHtml("#0E0E0E"))
    '        Dim thirdBrush As New SolidBrush(ColorTranslator.FromHtml("#0E0E0E"))
    '        Dim fourthBrush As New SolidBrush(ColorTranslator.FromHtml("#0E0E0E"))
    '        Dim firstString As String = "Customer Support"
    '        Dim secondString As String = "Please schedule the meeting on tomorrow"
    '        Dim thirdString As String = "<http.customersupport.com>"
    '        Dim fourthString As String = "11.58 AM"
    '        '    closeImage = New Rectangle(clRect.X + clRect.Width - 25, clRect.Y + 20, 20, 20)

    '        If e.Inner.RowIndex < dt.Rows.Count + 2 Then
    '            firstString = dt.Rows(e.Inner.RowIndex).ItemArray(0).ToString()

    '            secondString = dt.Rows(e.Inner.RowIndex).ItemArray(1).ToString()
    '            thirdString = dt.Rows(e.Inner.RowIndex).ItemArray(2).ToString()
    '            If Char.IsNumber(dt.Rows(e.Inner.RowIndex).ItemArray(3).ToString(), 0) Then
    '                fourthString = "    " + dt.Rows(e.Inner.RowIndex).ItemArray(2).ToString()
    '            Else
    '                fourthString = dt.Rows(e.Inner.RowIndex).ItemArray(2).ToString()
    '            End If
    '        End If

    '        If e.TableControl.Table.CurrentRecord IsNot Nothing Then
    '            If e.TableControl.Table.CurrentRecord.GetRowIndex() = e.Inner.RowIndex Then
    '                'Pen blackPen = new Pen(Color.Black, 1);
    '                'blackPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
    '                Dim paintRect As New Rectangle(e.Inner.Bounds.X, e.Inner.Bounds.Y + 1, e.Inner.Bounds.Width, e.Inner.Bounds.Height - 2)
    '                'g.DrawRectangle(blackPen, paintRect);
    '                g.FillRectangle(New SolidBrush(Color.FromArgb(205, 230, 247)), paintRect)
    '            End If
    '        End If

    '        'If unreadMessage.Contains(rowIndex) Then
    '        '    firstFont = New Font("Segoe UI", 11.55F)
    '        '    secondFont = New Font("Segoe UI", 9.0F, FontStyle.Bold)
    '        '    ' Semilight
    '        '    fourthFont = New Font("Segoe UI", 9.0F, FontStyle.Bold)
    '        '    firstBrush = New SolidBrush(Color.Black)
    '        '    secondBrush = New SolidBrush(ColorTranslator.FromHtml("#006FC4"))
    '        '    g.FillRectangle(secondBrush, clRect.X, clRect.Y + 1, 3, clRect.Height - 2)
    '        '    If IsColWidthChanged Then
    '        '        firstBrush = New SolidBrush(ColorTranslator.FromHtml("#006FC4"))
    '        '    End If
    '        'End If
    '        If IsColWidthChanged AndAlso screenBounds.Width < 1500 Then
    '            firstDrawString = New Rectangle(clRect.X + 2, clRect.Y + 6, clRect.Width * 20 / 100, ht)
    '            secondDrawString = New Rectangle(clRect.Width * 20 / 100 + 12, clRect.Y + 6, clRect.Width * 30 / 100, ht)
    '            thirdDrawString = New Rectangle(clRect.X + 2, clRect.Y + 28, clRect.Width * 80 / 100, ht - 2)
    '            fourthDrawString = New Rectangle(clRect.Width * 50 / 100 + 12, clRect.Y + 6, clRect.Width * 20 / 100, ht - 6)
    '            fifthDrawString = New Rectangle(clRect.Width * 70 / 100 + 12, clRect.Y + 6, clRect.Width * 10 / 100, ht - 4)
    '            firstFont = New Font("Segoe UI", 9.25F)
    '            secondFont = New Font("Segoe UI", 9.25F)
    '            thirdFont = New Font("Segoe UI", 9.25F)
    '            fourthFont = New Font("Segoe UI", 9.25F)
    '            'If unreadMessage.Contains(rowIndex) Then
    '            '    firstFont = New Font("Segoe UI", 9.25F, FontStyle.Bold)
    '            '    secondFont = New Font("Segoe UI", 9.25F, FontStyle.Bold)
    '            '    fourthFont = New Font("Segoe UI", 9.25F, FontStyle.Bold)
    '            'End If
    '            Dim fifthString As String = "54KB"
    '            If e.Inner.RowIndex < dt.Rows.Count + 2 Then
    '                fifthString = dt.Rows(e.Inner.RowIndex).ItemArray(1).ToString()

    '            End If
    '            g.DrawString(fifthString, fourthFont, secondBrush, fifthDrawString)
    '            '     categoryRect = New Rectangle(clRect.Width * 80 / 100 + 6, clRect.Y + 6, 8, ht - 6)
    '            '  g.DrawRectangle(New Pen(Color.LightGray), categoryRect)
    '            'If category.Contains(rowIndex) Then
    '            '    g.FillRectangle(New SolidBrush(Color.FromArgb(124, 206, 110)), categoryRect)
    '            '    Dim sixthDrawString As New Rectangle(clRect.Width * 80 / 100 + 6 + categoryRect.Width, clRect.Y + 6, 90, ht - 6)
    '            '    g.DrawRectangle(New Pen(Color.FromArgb(57, 125, 42)), categoryRect)
    '            '    Dim sixthString As String = "Green.."
    '            '    g.DrawString(sixthString, firstFont, firstBrush, sixthDrawString)
    '            '    '
    '            'End If
    '        End If
    '        g.DrawString(firstString, firstFont, firstBrush, firstDrawString)
    '        g.DrawString(secondString, secondFont, secondBrush, secondDrawString)
    '        g.DrawString(thirdString, thirdFont, thirdBrush, thirdDrawString)
    '        g.DrawString(fourthString, fourthFont, secondBrush, fourthDrawString)
    '    End If
    'End Sub

    'Dim screenBounds As New Rectangle()
    'Private Sub TableModel_QueryColWidth(sender As Object, e As Syncfusion.Windows.Forms.Grid.GridRowColSizeEventArgs)
    '    If e.Index = 2 Then
    '        If screenBounds.Width > 1500 Then
    '            dist = 40
    '        End If
    '        '   e.Size = Me.outlookSearchBox1.Width - dist
    '        e.Handled = True
    '    End If
    '    If e.Index = 3 Then
    '        e.Size = 100
    '        e.Handled = True
    '    End If
    '    If e.Size > 400 Then
    '        IsColWidthChanged = True
    '    Else
    '        IsColWidthChanged = False
    '    End If
    'End Sub

    'Private Sub TableControl_ScrollbarsVisibleChanged(sender As Object, e As EventArgs)
    '    Me.gridGroupingControl1.TableModel.Refresh()
    'End Sub
    'Private Sub TableControl_MouseWheel(sender As Object, e As MouseEventArgs)
    '    Me.gridGroupingControl1.TableModel.Refresh()
    '    Me.gridGroupingControl1.Refresh()
    'End Sub

    'Private Sub TableModel_QueryRowHeight(sender As Object, e As GridRowColSizeEventArgs)
    '    If Me.gridGroupingControl1.TableModel(e.Index, 2).CellType = "Static" Then
    '        e.Size = 22
    '        e.Handled = True
    '    End If
    '    'If isUnreadClicked Then
    '    '    If Not unreadMessage.Contains(e.Index) Then
    '    '        e.Size = 0
    '    '        e.Handled = True
    '    '    End If
    '    'End If
    '    'If emptyData Then
    '    '    e.Size = 0
    '    '    e.Handled = True
    '    'End If
    '    'If sentItems Then
    '    '    If e.Index > 6 Then
    '    '        e.Size = 0
    '    '        e.Handled = True
    '    '    End If
    '    'End If
    '    'if (this.gridGroupingControl1.TableModel[e.Index, 2].CellType == "OutlookHeaderCell")
    '    '{
    '    '    if (IsColWidthChanged)
    '    '    {
    '    '        e.Size = 40;
    '    '    }
    '    '    else
    '    '        e.Size = 57;
    '    '    e.Handled = true;
    '    '}
    'End Sub
    ''Private Sub TableModel_QueryColWidth(sender As Object, e As Syncfusion.Windows.Forms.Grid.GridRowColSizeEventArgs)
    ''    If e.Index = 2 Then
    ''        If screenBounds.Width > 1500 Then
    ''            dist = 40
    ''        End If
    ''        e.Size = Me.outlookSearchBox1.Width - dist
    ''        e.Handled = True
    ''    End If
    ''    If e.Index = 3 Then
    ''        e.Size = 100
    ''        e.Handled = True
    ''    End If
    ''    If e.Size > 400 Then
    ''        IsColWidthChanged = True
    ''    Else
    ''        IsColWidthChanged = False
    ''    End If
    ''End Sub

    'Private Sub frmNotify_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    Listado()
    'End Sub
    'Dim selectedRows As New Hashtable()
    'Dim hoveredRowIndex As Integer = -1

    'Private Sub gridGroupingControl1_TableControlCellMouseHover(sender As Object, e As GridTableControlCellMouseEventArgs) Handles gridGroupingControl1.TableControlCellMouseHover
    '    Dim rowIndex As Integer, colIndex As Integer
    '    rowIndex = e.Inner.RowIndex
    '    colIndex = e.Inner.ColIndex
    '    moveRowIndex = rowIndex
    '    moveColIndex = colIndex
    '    Dim result As Integer = 0
    '    Dim style As GridStyleInfo = Me.gridGroupingControl1.TableModel(rowIndex, colIndex)
    '    If Integer.TryParse(style.ValueMember, result) Then
    '        'If Not unreadMessage.Contains(rowIndex) Then
    '        '    unreadMessage.Add(rowIndex)
    '        'End If
    '    End If
    '    If style.CellType = "IndentCell" Then
    '        Me.gridGroupingControl1.TableControl.Refresh()
    '    End If
    '    '
    '    '
    '    '
    '    If Me.gridGroupingControl1.TableModel(e.Inner.RowIndex, e.Inner.ColIndex).CellType = "IndentCell" OrElse Me.gridGroupingControl1.TableModel(e.Inner.RowIndex, e.Inner.ColIndex).CellType = "OutlookHeaderCell" Then
    '        indentCellHovered = True
    '        indentRI = e.Inner.RowIndex
    '        indentCI = e.Inner.ColIndex
    '        Me.gridGroupingControl1.TableModel(e.Inner.RowIndex, e.Inner.ColIndex).BackColor = ColorTranslator.FromHtml("#E6F2FA")
    '    Else
    '        indentCellHovered = False
    '    End If
    '    If e.Inner.ColIndex = 3 Then
    '        e.TableControl.RefreshRange(GridRangeInfo.Cols(2, 2))
    '    End If
    'End Sub
    'Private Sub gridGroupingControl1_TableControlCurrentCellStartEditing(sender As Object, e As GridTableControlCancelEventArgs) Handles gridGroupingControl1.TableControlCurrentCellStartEditing
    '    e.Inner.Cancel = False
    'End Sub

    'Private Sub gridGroupingControl1_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles gridGroupingControl1.QueryCellStyleInfo
    '    If e.Style.CellType = "TextBox" Then
    '        e.Style.CellType = "OutlookHeaderCell"
    '    End If
    '    If e.Style.CellType = "OutlookHeaderCell" Then
    '        e.Style.Text = ""
    '    End If
    '    If e.Style.CellType = "Header" Then
    '        e.Style.CellType = GridCellTypeName.[Static]
    '    End If
    '    e.Style.Borders.All = GridBorder.Empty
    '    If e.Style.CellType = GridCellTypeName.[Static] Then
    '        Dim newFont As New Font(e.Style.GdipFont.Name, e.Style.GdipFont.Size, FontStyle.Bold)
    '        e.Style.Font = New GridFontInfo(newFont)
    '        e.Style.VerticalAlignment = GridVerticalAlignment.Middle
    '        e.Style.HorizontalAlignment = GridHorizontalAlignment.Left
    '    End If
    '    'selection
    '    If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectedRows IsNot Nothing AndAlso selectedRows.Count > 0 Then
    '        Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
    '        If selectedRows.Contains(key) AndAlso CBool(selectedRows(key)) Then
    '            e.Style.BackColor = Color.FromArgb(230, 242, 250)
    '            ' ColorTranslator.FromHtml("#CDE6F7");
    '            e.Style.TextColor = Color.White
    '            hoveredRowIndex = e.TableCellIdentity.RowIndex
    '        End If
    '    End If

    '    Me.gridGroupingControl1.TableControl.Selections.Clear()

    '    If e.Style.TableCellIdentity.TableCellType = GridTableCellType.GroupCaptionCell Then
    '        Dim capRow As GridCaptionRow = TryCast(e.Style.TableCellIdentity.DisplayElement, GridCaptionRow)
    '        Dim g As Group = capRow.ParentGroup
    '        If Not g.IsTopLevelGroup Then
    '            e.Style.CellValue = g.Category.ToString().Substring(2)
    '        End If
    '    End If
    'End Sub

    'Private Sub gridGroupingControl1_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles gridGroupingControl1.TableControlCellClick

    'End Sub
    'Private moveRowIndex As Integer = 0, moveColIndex As Integer = 0
    'Private hoveredFlag As Boolean, hoveredClose As Boolean = False

    'Private indentCellHovered As Boolean = False
    'Private indentRI As Integer, indentCI As Integer = 0
    'Private IsColWidthChanged As Boolean = False
    'Private dist As Integer = 30
    'Dim selectionIndents As New Hashtable()
    'Private Sub MouseHoverCheck(row As Integer, col As Integer, isHover As Boolean)
    '    If col > 1 Then
    '        Dim id As GridTableCellStyleInfoIdentity = Me.gridGroupingControl1.TableControl.GetTableViewStyleInfo(row, col).TableCellIdentity
    '        If id.DisplayElement.IsRecord() Then
    '            Dim key As Integer = id.DisplayElement.GetRecord().Id
    '            selectedRows.Clear()
    '            selectedRows.Add(key, isHover)
    '            selectionIndents.Clear()
    '            selectionIndents.Add(col - 2, isHover)
    '            Me.gridGroupingControl1.TableControl.RefreshRange(GridRangeInfo.Row(row))
    '        End If
    '        If Me.gridGroupingControl1.TableControl.Selections.Count > 0 Then
    '            Me.gridGroupingControl1.TableControl.Selections.Clear()
    '        End If
    '    End If
    'End Sub
    'Dim currentRowIndex As Integer = 0, currentColIndex As Integer = 0
    'Private Sub gridGroupingControl1_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles gridGroupingControl1.TableControlCellMouseHoverEnter
    '    Dim styleInfo As GridTableCellStyleInfo = e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex)
    '    If styleInfo.TableCellIdentity.TableCellType.ToString() <> "Static" Then
    '        If e.Inner.ColIndex > 1 AndAlso e.Inner.ColIndex <= 2 Then
    '            MouseHoverCheck(e.Inner.RowIndex, e.Inner.ColIndex, True)
    '            currentRowIndex = e.Inner.RowIndex
    '            currentColIndex = e.Inner.ColIndex
    '            Me.gridGroupingControl1.TableControl.RefreshRange(GridRangeInfo.Row(e.Inner.RowIndex), GridRangeOptions.None)
    '        End If
    '    End If
    '    Me.gridGroupingControl1.TableControl.Refresh()
    'End Sub

    'Private Sub gridGroupingControl1_TableControlDrawCellDisplayText(sender As Object, e As GridTableControlDrawCellDisplayTextEventArgs) Handles gridGroupingControl1.TableControlDrawCellDisplayText
    '    If Me.gridGroupingControl1.TableModel(e.Inner.RowIndex, e.Inner.ColIndex).CellType = "IndentCell" Then
    '        Using g As Graphics = Me.gridGroupingControl1.TableControl.CreateGridGraphics()
    '        End Using
    '    End If
    'End Sub

    'Private Sub gridGroupingControl1_TableControlCellMouseHoverLeave(sender As Object, e As GridTableControlCellMouseEventArgs) Handles gridGroupingControl1.TableControlCellMouseHoverLeave
    '    Dim styleInfo As GridTableCellStyleInfo = e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex)
    '    If styleInfo.TableCellIdentity IsNot Nothing AndAlso styleInfo.TableCellIdentity.TableCellType.ToString() <> "Static" Then
    '        If e.Inner.ColIndex > 1 Then
    '            MouseHoverCheck(e.Inner.RowIndex, e.Inner.ColIndex, False)
    '            Me.gridGroupingControl1.TableControl.RefreshRange(GridRangeInfo.Row(e.Inner.RowIndex), GridRangeOptions.None)
    '        End If
    '    End If
    'End Sub

    'Private Sub gridGroupingControl1_TableControlVScrollPixelPosChanged(sender As Object, e As GridTableControlScrollPositionChangedEventArgs) Handles gridGroupingControl1.TableControlVScrollPixelPosChanged

    'End Sub

    'Private Sub gridGroupingControl1_TableControlVScrollPixelPosChanging(sender As Object, e As GridTableControlScrollPositionChangingEventArgs) Handles gridGroupingControl1.TableControlVScrollPixelPosChanging
    '    Me.gridGroupingControl1.TableControl.Refresh()
    'End Sub

    Private Sub frmNotify_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class