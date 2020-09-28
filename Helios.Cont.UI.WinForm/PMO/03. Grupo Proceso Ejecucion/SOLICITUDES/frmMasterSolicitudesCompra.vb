Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.GridHelperClasses
Imports PopupControl
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Public Class frmMasterSolicitudesCompra
    Inherits frmMaster

    Private dt As DataTable
    Private CheckBoxValue As Boolean = False

    Dim filter As GridDynamicFilter = New GridDynamicFilter()
    Private lblPeriodo As System.Windows.Forms.ToolStripLabel
    Private lblPeriodoLabel As System.Windows.Forms.ToolStripLabel

    Private Sub ConfiguracionInicio()
        Me.RibbonControlAdv1.QuickPanelVisible = True
        Me.lblPeriodo = New System.Windows.Forms.ToolStripLabel()
        Me.lblPeriodoLabel = New System.Windows.Forms.ToolStripLabel()
        Me.lblPeriodoLabel.Text = "Período:"
        Me.lblPeriodoLabel.Font = New Font("Segoe UI", 8.25, FontStyle.Bold)
        lblPeriodoLabel.Enabled = False

        Me.lblPeriodo.Font = New Font("Segoe UI", 8.25)
        ' Set the text and DisplayStyle property.
        Me.lblPeriodo.Text = PeriodoGeneral
        lblPeriodo.Enabled = False
        Me.lblPeriodo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text

        ' Add the toolstripbutton in the header of the RibbonControlAdv.
        Me.RibbonControlAdv1.Header.AddQuickItem(Me.lblPeriodoLabel)
        Me.RibbonControlAdv1.Header.AddQuickItem(Me.lblPeriodo) 'ToolStripSeparator1
        '   Me.RibbonControlAdv1.Header.AddQuickItem(Me.ToolStripSeparator1)
        RibbonControlAdv1.RibbonHeaderImage = Syncfusion.Windows.Forms.Tools.RibbonHeaderImage.Birds
        'Me.rbnPrincipal.Header.AddQuickItem(btnAnio)
        'Me.rbnPrincipal.Header.AddQuickItem(cboAnio)
    End Sub


#Region "manipulacion de data"

    Public Sub EliminarDocumento(iddoc As Integer)
        'Dim documentoSA As New DocumentoSA
        'Dim nDocumento As New documento()
        'documentoSA.DeleteDocumento(D(iddoc))
        'lblEstado.Text = "Solicitud eliminado correctamente"
        'lblEstado.Image = My.Resources.ok4
    End Sub


    Public Sub ListaSolicitudesAprob()
        Dim DocumentoCompraSA As New DocumentoCompraSA

        'InitializeComponent()
        dt = New DataTable()
        dt.Columns.Add("idDocumento", GetType(String))
        dt.Columns.Add("NombreEntidad", GetType(String))
        dt.Columns.Add("fechaDoc", GetType(String))
        dt.Columns.Add("importeTotal", GetType(Decimal))
        dt.Columns.Add("importeUS", GetType(Decimal))
        dt.Columns.Add("tipoCompra", GetType(String))
        dt.Columns.Add("Estado", GetType(Boolean))

        For Each row In DocumentoCompraSA.GetListarSolicitudesCompra(Gempresas.IdEmpresaRuc)
            Dim dr As DataRow = dt.NewRow()
            dr(0) = row.idDocumento
            dr(1) = row.NombreEntidad
            dr(2) = row.fechaDoc
            dr(3) = row.importeTotal
            dr(4) = row.importeUS
            dr(5) = row.tipoCompra
            If row.tipoCompra = TIPO_COMPRA.SOLICITUD_ACEPTADA Then
                dr(6) = True
            Else
                dr(6) = False
            End If
            dt.Rows.Add(dr)

        Next

        Me.dgvAprobacion.DataSource = dt
        Me.dgvAprobacion.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False

        AddHandler dgvAprobacion.TableControlCheckBoxClick, AddressOf gridGroupingControl1_TableControlCheckBoxClick

    End Sub

    Private Sub ListaSolicitudes()
        Dim DocumentoCompraSA As New DocumentoCompraSA
        ' Llamada necesaria para el diseñador.
        dt = New DataTable()
        dt.Columns.Add("idDocumento", GetType(String))
        dt.Columns.Add("Nombre Personal", GetType(String))
        dt.Columns.Add("fechaDoc", GetType(String))
        dt.Columns.Add("importeTotal", GetType(Decimal))
        dt.Columns.Add("importeTotalUSD", GetType(Decimal))
        dt.Columns.Add("Tipo de Cambio", GetType(String))

        For Each row In DocumentoCompraSA.GetListarSolicitudesCompra(Gempresas.IdEmpresaRuc)
            Dim dr As DataRow = dt.NewRow()
            dr(0) = row.idDocumento
            dr(1) = row.NombreEntidad
            dr(2) = row.fechaDoc
            dr(3) = row.importeTotal
            dr(4) = row.importeUS
            dr(5) = row.tcDolLoc

            dt.Rows.Add(dr)
        Next

        Me.dgvProforma.DataSource = dt

        Me.dgvProforma.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
        dgvProforma.TableDescriptor.Relations.Clear()
        dgvProforma.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
        dgvProforma.TableOptions.ListBoxSelectionMode = SelectionMode.One
        dgvProforma.Appearance.AnyRecordFieldCell.Enabled = False
        dgvProforma.GroupDropPanel.Visible = True

    End Sub



    Private Sub ListaSolicitudesDia()
        Dim DocumentoCompraSA As New DocumentoCompraSA
        ' Llamada necesaria para el diseñador.
        dt = New DataTable()
        dt.Columns.Add("idDocumento", GetType(String))
        dt.Columns.Add("Nombre Personal", GetType(String))
        dt.Columns.Add("fechaDoc", GetType(String))
        dt.Columns.Add("importeTotal", GetType(Decimal))
        dt.Columns.Add("importeTotalUSD", GetType(Decimal))
        dt.Columns.Add("Tipo de Cambio", GetType(String))

        For Each row In DocumentoCompraSA.GetListarSolicitudesCompraDia(Gempresas.IdEmpresaRuc)
            Dim dr As DataRow = dt.NewRow()
            dr(0) = row.idDocumento
            dr(1) = row.NombreEntidad
            dr(2) = row.fechaDoc
            dr(3) = row.importeTotal
            dr(4) = row.importeUS
            dr(5) = row.tcDolLoc

            dt.Rows.Add(dr)
        Next

        Me.dgvProforma.DataSource = dt

        Me.dgvProforma.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
        dgvProforma.TableDescriptor.Relations.Clear()
        dgvProforma.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
        dgvProforma.TableOptions.ListBoxSelectionMode = SelectionMode.One
        dgvProforma.Appearance.AnyRecordFieldCell.Enabled = False
        dgvProforma.GroupDropPanel.Visible = True

    End Sub


    Sub UpdateDoc(intIdDocumento As Integer)
        Dim nRecursoSA As New DocumentoCompraSA
        Dim nRecurso As New documentocompra
        nRecurso = New documentocompra With {
        .Action = Business.Entity.BaseBE.EntityAction.UPDATE,
        .idDocumento = intIdDocumento,
        .tipoCompra = TIPO_COMPRA.SOLICITUD_ACEPTADA}
        If (nRecursoSA.EstadoSoli(nRecurso)) Then
            'lblEstado.Text = " editado!"
            'lblEstado.Image = My.Resources.ok4
        Else
            'lblEstado.Text = "Error al grabar Cadena!"
            'lblEstado.Image = My.Resources.cross
        End If
    End Sub

    Sub UpdateDocEspera(intIdDocumento As Integer)
        Dim nRecursoSA As New DocumentoCompraSA
        Dim nRecurso As New documentocompra
        nRecurso = New documentocompra With {
        .Action = Business.Entity.BaseBE.EntityAction.UPDATE,
        .idDocumento = intIdDocumento,
        .tipoCompra = TIPO_COMPRA.SOLICITUD_ESPERA}
        If (nRecursoSA.EstadoSoli(nRecurso)) Then
            'lblEstado.Text = " editado!"
            'lblEstado.Image = My.Resources.ok4
        Else
            'lblEstado.Text = "Error al grabar Cadena!"
            'lblEstado.Image = My.Resources.cross
        End If
    End Sub

#End Region
    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        'ListaSolicitudesAprob()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        ConfiguracionInicio()
    End Sub

    Private Sub frmMasterSolicitudesCompra_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmMasterSolicitudesCompra_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ListaSolicitudes()
        TabPageAdv2.TabVisible = False
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        With FrmSoliCompra
            .ShowDialog()
        End With
    End Sub

    Private Sub ToolStripPanelItem1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripPanelItem1.Click

    End Sub

    Private Sub ToolStripButton4_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton4.Click
        ListaSolicitudesAprob()
    End Sub

    Private Sub TableControl_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
        Dim row, col As Integer
        Me.dgvAprobacion.TableControl.PointToRowCol(New Point(e.X, e.Y), row, col)
        Dim style As GridTableCellStyleInfo = Me.dgvAprobacion.TableControl.Model(row, col)

        Dim controller As IMouseController = Nothing
        Me.dgvAprobacion.TableControl.MouseControllerDispatcher.HitTest(New Point(e.X, e.Y), e.Button, e.Clicks, controller)

        If controller IsNot Nothing AndAlso controller.Name = "DragGroupHeader" Then
            If Me.dgvAprobacion.TableDescriptor.GroupedColumns.Count > 0 AndAlso col = Me.dgvAprobacion.TableDescriptor.GroupedColumns.Count + 1 Then
                Me.dgvAprobacion.TableControl.GetCellRenderer(row, col - Me.dgvAprobacion.TableDescriptor.GroupedColumns.Count).RaiseMouseUp(row, col - Me.dgvAprobacion.TableDescriptor.GroupedColumns.Count, e)
            Else
                Me.dgvAprobacion.TableControl.GetCellRenderer(row, col).RaiseMouseUp(row, col, e)
            End If

        End If
    End Sub

    Private chk As Boolean, check As Boolean = False
    Private ht As New ArrayList()
    Dim GroupCheckValue As New Hashtable()
    Private Sub SetCheckStatus(g As Group, ColumnName As String, bvalue As Boolean)
        For Each group As Group In g.Groups
            SetCheckStatus(group, ColumnName, bvalue)
        Next
        For Each rec As Record In g.Records
            rec.SetValue(ColumnName, bvalue)
        Next

    End Sub

    Private Sub gridGroupingControl1_TableControlCheckBoxClick(ByVal sender As Object, ByVal e As GridTableControlCellClickEventArgs)
        Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex), GridTableCellStyleInfo)
        If style.Enabled Then
            Dim column As Integer = Me.dgvAprobacion.TableModel.NameToColIndex("Estado")
            Console.WriteLine("CheckBoxClicked")
            If style.Enabled AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell Then
                chk = CBool(Me.dgvAprobacion.TableModel(style.TableCellIdentity.RowIndex, column).CellValue)

                e.TableControl.BeginUpdate()

                e.TableControl.EndUpdate(True)
            End If
            If style.Enabled AndAlso (style.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell OrElse style.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) AndAlso style.TableCellIdentity.Column.Name = "Estado" Then
                Dim currentRecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                Dim curStatus As Boolean = Boolean.Parse(style.Text)
                e.TableControl.BeginUpdate()

                If curStatus Then
                    CheckBoxValue = False
                End If
                If curStatus = True Then
                    Dim RowIndex As Integer = e.Inner.RowIndex
                    Dim ColIndex As Integer = e.Inner.ColIndex

                    flag = "F"


                    UpdateDocEspera(Me.dgvAprobacion.TableModel(RowIndex, 1).CellValue)
                Else
                    Dim RowIndex As Integer = e.Inner.RowIndex
                    Dim ColIndex As Integer = e.Inner.ColIndex
                    flag = "T"

                    UpdateDoc(Me.dgvAprobacion.TableModel(RowIndex, 1).CellValue)

                End If
                e.TableControl.EndUpdate()
                If ht.Contains(curStatus) AndAlso (Not ht.Contains((Not curStatus))) Then


                    Me.dgvAprobacion.TableModel(2, column).CellValue = curStatus
                ElseIf Not ht.Contains(curStatus) Then
                    Me.dgvAprobacion.TableModel(2, column).CellValue = curStatus
                    CheckBoxValue = Not curStatus
                End If
                ht.Clear()
            End If
        End If

        Me.dgvAprobacion.TableControl.Refresh()
    End Sub

    Private Sub gridGroupingControl1_SaveCellText(ByVal sender As Object, ByVal e As Syncfusion.Windows.Forms.Grid.GridCellTextEventArgs)
        Dim style As GridTableCellStyleInfo = CType(e.Style, GridTableCellStyleInfo)
        If style.Enabled AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell Then
            Me.CheckBoxValue = Boolean.Parse(e.Text)
            e.Handled = True
        End If
    End Sub

    Dim flag As String = Nothing

    Private Sub GridGroupingControl1_TableControlCellClick(sender As System.Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles dgvAprobacion.TableControlCellClick
        Dim style As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
        If style.Enabled Then
            If style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso style.TableCellIdentity.Column.Name = "Estado" Then
                e.Inner.Cancel = True
            End If
            Console.WriteLine(e.Inner.RowIndex.ToString() & "TableControlCellClick")
        End If
    End Sub

    Private Sub gridGroupingControl1_QueryCellStyleInfo(ByVal sender As Object, ByVal e As GridTableCellStyleInfoEventArgs)
        If e.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.TableCellIdentity.Column.Name = "Estado" Then
            e.Style.CellType = "CheckBox"
            e.Style.CellValueType = GetType(Boolean)
            e.Style.CellValue = CheckBoxValue
            e.Style.ReadOnly = False
            e.Style.CellAppearance = GridCellAppearance.Raised
            e.Style.Enabled = True
        End If
        e.Handled = True
    End Sub

    Private Sub btnEditar_Click(sender As System.Object, e As System.EventArgs) Handles btnEditar.Click
        If Not IsNothing(Me.dgvProforma.Table.CurrentRecord) Then
            With FrmSoliCompra
                .lblIdDocumento.Text = Me.dgvProforma.Table.CurrentRecord.GetValue("idDocumento")
                .Tag = "M"
                .ShowDialog()
            End With
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs)
        If Not IsNothing(Me.dgvProforma.Table.CurrentRecord) Then
            EliminarDocumento(CInt(Me.dgvProforma.Table.CurrentRecord.GetValue("idDocumento")))

        End If
    End Sub

    Private Sub ToolStripButton3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton3.Click
        ListaSolicitudes()
    End Sub

    Private Sub btnEliminar_Click_1(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If Not IsNothing(Me.dgvProforma.Table.CurrentRecord) Then
            EliminarDocumento(CInt(Me.dgvProforma.Table.CurrentRecord.GetValue("idDocumento")))

        End If
    End Sub

    Private Sub ToolStripTabItem2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripTabItem2.Click
        TabPageAdv1.TabVisible = False
        TabPageAdv2.TabVisible = True
        
    End Sub

    Private Sub ToolStripTabItem1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripTabItem1.Click
        TabPageAdv1.TabVisible = True
        TabPageAdv2.TabVisible = False
      
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        ListaSolicitudesDia()
    End Sub
End Class