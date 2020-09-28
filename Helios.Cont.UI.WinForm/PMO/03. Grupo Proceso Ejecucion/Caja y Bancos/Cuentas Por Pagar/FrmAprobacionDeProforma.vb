Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class FrmAprobacionDeProforma
    Inherits frmMaster
    Private CheckBoxClicked As Boolean = False
    Private dt As DataTable
    Private str() As Boolean = {True, False}
    Private CheckBoxValue As Boolean = False

    Public Sub New()
        Dim DocumentoCompraSA As New DocumentoCompraSA
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        dt = New DataTable()
        dt.Columns.Add("idDocumento", GetType(String))
        dt.Columns.Add("NombreEntidad", GetType(String))
        dt.Columns.Add("fechaDoc", GetType(String))
        dt.Columns.Add("importeTotal", GetType(Decimal))
        dt.Columns.Add("importeUS", GetType(Decimal))
        dt.Columns.Add("tipoCompra", GetType(String))
        dt.Columns.Add("Estado", GetType(Boolean))
        '  i.fechaDoc, i.importeTotal, i.importeUS, i.tipoCompra, True)
        'For Each row In DocumentoCompraSA.GetListarProforma(Gempresas.IdEmpresaRuc)
        '    Dim dr As DataRow = dt.NewRow()
        '    dr(0) = row.idDocumento
        '    dr(1) = row.NombreEntidad
        '    dr(2) = row.fechaDoc
        '    dr(3) = row.importeTotal
        '    dr(4) = row.importeUS
        '    dr(5) = row.tipoCompra
        '    If row.tipoCompra = TIPO_COMPRA.PROFORMA_ACEPTADA Then
        '        dr(6) = True
        '    Else
        '        dr(6) = False
        '    End If
        '    dt.Rows.Add(dr)

        'Next
        Me.dgvProforma.DataSource = dt
        Me.dgvProforma.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False

        AddHandler dgvProforma.TableControlCheckBoxClick, AddressOf gridGroupingControl1_TableControlCheckBoxClick
        
    End Sub

#Region "METODOS"



    Sub UpdateDoc(intIdDocumento As Integer)
        Dim nRecursoSA As New DocumentoCompraSA
        Dim nRecurso As New documentocompra
        nRecurso = New documentocompra With {
        .Action = Business.Entity.BaseBE.EntityAction.UPDATE,
        .idDocumento = intIdDocumento}
        '.tipoCompra = TIPO_COMPRA.PROFORMA_ACEPTADA}
        'If (nRecursoSA.EstadoSoli(nRecurso)) Then
        '    lblEstado.Text = " editado!"
        '    lblEstado.Image = My.Resources.ok4
        'Else
        '    lblEstado.Text = "Error al grabar Cadena!"
        '    lblEstado.Image = My.Resources.cross
        'End If
    End Sub

    Sub UpdateDocEspera(intIdDocumento As Integer)
        Dim nRecursoSA As New DocumentoCompraSA
        Dim nRecurso As New documentocompra
        nRecurso = New documentocompra With {
        .Action = Business.Entity.BaseBE.EntityAction.UPDATE}
        '.idDocumento = intIdDocumento}'
        '.tipoCompra = TIPO_COMPRA.PROFORMA_ESPERA}
        'If (nRecursoSA.EstadoSoli(nRecurso)) Then
        '    lblEstado.Text = " editado!"
        '    lblEstado.Image = My.Resources.ok4
        'Else
        '    lblEstado.Text = "Error al grabar Cadena!"
        '    lblEstado.Image = My.Resources.cross
        'End If
    End Sub

    'Private Function GetParentTable() As DataTable
    '    Dim dt As New DataTable("Proformas")
    '    Dim DocumentoCompraSA As New DocumentoCompraSA


    '    dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
    '    'lower case p
    '    dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
    '    dt.Columns.Add(New DataColumn("Fecha", GetType(String)))
    '    dt.Columns.Add(New DataColumn("ImporteMN", GetType(Decimal)))
    '    dt.Columns.Add(New DataColumn("ImporteME", GetType(Decimal)))
    '    dt.Columns.Add(New DataColumn("TipoCompra", GetType(String)))
    '    dt.Columns.Add(New DataColumn("CheckboxCol", GetType(Boolean)))

    '    For Each i In DocumentoCompraSA.GetListarProforma(Gempresas.IdEmpresaRuc)
    '        Dim dr As DataRow = dt.NewRow()
    '        If i.tipoCompra = "PROFA" Then

    '            dr(0) = i.idDocumento
    '            dr(1) = i.NombreEntidad
    '            dr(2) = i.fechaDoc
    '            dr(3) = i.importeTotal
    '            dr(4) = i.importeUS
    '            dr(5) = i.tipoCompra
    '            dr(6) = True

    '            ' dgvCompra.Rows.Add(i.idDocumento, i.NombreEntidad, i.fechaDoc, i.importeTotal, i.importeUS, i.tipoCompra, True)
    '        ElseIf i.tipoCompra = "PROF" Then
    '            dr(0) = i.idDocumento
    '            dr(1) = i.NombreEntidad
    '            dr(2) = i.fechaDoc
    '            dr(3) = i.importeTotal
    '            dr(4) = i.importeUS
    '            dr(5) = i.tipoCompra
    '            dr(6) = False

    '            '        dgvCompra.Rows.Add(i.idDocumento, i.NombreEntidad, i.fechaDoc, i.importeTotal, i.importeUS, i.tipoCompra, False)
    '        End If
    '        dt.Rows.Add(dr)
    '    Next
    '    Return dt
    'End Function


    'Public Sub ListaProforma(strPeriodo As String)
    '    Dim documentoCompraSA As New DocumentoCompraSA

    '    Dim unboundField As FieldDescriptor = New FieldDescriptor("CheckboxCol", "", False, "")
    '    unboundField.ReadOnly = False
    '    Me.dgvProforma.TableDescriptor.UnboundFields.Add(unboundField)
    '    dgvProforma.TableDescriptor.Columns("CheckboxCol").Appearance.AnyRecordFieldCell.CellType = "CheckBox"
    '    dgvProforma.TableDescriptor.Columns("CheckboxCol").Appearance.AnyRecordFieldCell.CheckBoxOptions.CheckedValue = "True"
    '    dgvProforma.TableDescriptor.Columns("CheckboxCol").Appearance.AnyRecordFieldCell.CheckBoxOptions.UncheckedValue = "False"
    '    dgvProforma.TableDescriptor.Columns("CheckboxCol").Appearance.AnyRecordFieldCell.HorizontalAlignment = GridHorizontalAlignment.Center
    '    dgvProforma.TableDescriptor.Columns("CheckboxCol").Appearance.AnyRecordFieldCell.VerticalAlignment = GridVerticalAlignment.Middle

    '    Dim parentTable As DataTable = GetParentTable()
    '    dgvProforma.DataSource = parentTable ' documentoCompraSA.GetListarProforma(Gempresas.IdEmpresaRuc)


    'End Sub



#End Region



    Private Sub FrmAprobacionDeProforma_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub FrmAprobacionDeProforma_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        lblPerido.Text = PeriodoGeneral
        '   ListaProforma("1")
    End Sub

    Private Sub PegarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles PegarToolStripButton.Click
        Dispose()
    End Sub

   


    Private Sub dgvCompra_CurrentCellDirtyStateChanged(sender As Object, e As System.EventArgs)
        'Try
        '    If dgvCompra.IsCurrentCellDirty Then
        '        dgvCompra.CommitEdit(DataGridViewDataErrorContexts.Commit)
        '    End If

        '    If TypeOf dgvCompra.CurrentCell Is DataGridViewCheckBoxCell Then
        '        dgvCompra.CommitEdit(DataGridViewDataErrorContexts.Commit)
        '    End If


        'Catch
        'End Try
    End Sub

    Private chk As Boolean, check As Boolean = False
    Private ht As New ArrayList()
    Dim GroupCheckValue As New Hashtable()
    '   Dim el As Element = Style.TableCellIdentity.DisplayElement
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
            Dim column As Integer = Me.dgvProforma.TableModel.NameToColIndex("Estado")
            Console.WriteLine("CheckBoxClicked")
            If style.Enabled AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell Then
                chk = CBool(Me.dgvProforma.TableModel(style.TableCellIdentity.RowIndex, column).CellValue)

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


                    UpdateDocEspera(Me.dgvProforma.TableModel(RowIndex, 1).CellValue)

                    'dgvCompra.Item(5, dgvCompra.CurrentRow.Index).Value = "PROF"
                Else
                    Dim RowIndex As Integer = e.Inner.RowIndex
                    Dim ColIndex As Integer = e.Inner.ColIndex
                    flag = "T"

                    UpdateDoc(Me.dgvProforma.TableModel(RowIndex, 1).CellValue)

                    'dgvCompra.Item(5, dgvCompra.CurrentRow.Index).Value = "PROF"

                End If
                e.TableControl.EndUpdate()
                If ht.Contains(curStatus) AndAlso (Not ht.Contains((Not curStatus))) Then


                    Me.dgvProforma.TableModel(2, column).CellValue = curStatus
                ElseIf Not ht.Contains(curStatus) Then
                    Me.dgvProforma.TableModel(2, column).CellValue = curStatus
                    CheckBoxValue = Not curStatus
                End If
                ht.Clear()
            End If
        End If

        Me.dgvProforma.TableControl.Refresh()
    End Sub

    Private Sub gridGroupingControl1_TableControlCellClick(ByVal sender As Object, ByVal e As GridTableControlCellClickEventArgs)
        Dim style As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
        If style.Enabled Then
            If style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso style.TableCellIdentity.Column.Name = "Estado" Then
                e.Inner.Cancel = True
            End If
            Console.WriteLine(e.Inner.RowIndex.ToString() & "TableControlCellClick")
        End If
    End Sub

    Private Sub gridGroupingControl1_SaveCellText(ByVal sender As Object, ByVal e As Syncfusion.Windows.Forms.Grid.GridCellTextEventArgs)
        Dim style As GridTableCellStyleInfo = CType(e.Style, GridTableCellStyleInfo)
        If style.Enabled AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell Then
            Me.CheckBoxValue = Boolean.Parse(e.Text)
            e.Handled = True
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
    Dim flag As String = Nothing


    'Private Sub dgvProforma_QueryCellStyleInfo(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableCellStyleInfoEventArgs) Handles dgvProforma.QueryCellStyleInfo

    '    'If e.TableCellIdentity.ColIndex = 3 AndAlso e.TableCellIdentity.RowIndex > 2 Then
    '    '    If e.TableCellIdentity.RowIndex Mod 4 = 0 Then
    '    '        e.Style.CellValue = False
    '    '    Else
    '    '        e.Style.CellValue = True
    '    '    End If
    '    'End If
    'End Sub

    'Private Sub dgvProforma_QueryValue(sender As System.Object, e As Syncfusion.Grouping.FieldValueEventArgs) Handles dgvProforma.QueryValue
    '    If e.Field.Name = "CheckboxCol" Then

    '        '   Dim key As String = e.Record.GetValue().ToString()
    '        'If Not key Is Nothing Then
    '        '    '   Dim val As Object = unboundValues(key)
    '        '    '   e.Value = val
    '        'End If
    '        '      MsgBox("check")
    '    End If
    'End Sub

    'Private Sub dgvProforma_SaveValue(sender As Object, e As Syncfusion.Grouping.FieldValueEventArgs) Handles dgvProforma.SaveValue
    '    'If e.Field.Name = "CheckboxCol" Then
    '    '    '   Dim key As String = e.Record.GetValue("CheckboxCol").ToString()
    '    '    'If Not key Is Nothing Then
    '    '    '    Dim val As Object = e.Value
    '    '    '    '     unboundValues(key) = val
    '    '    'End If
    '    '    '    MsgBox("No check")
    '    'End If
    'End Sub

    'Private Sub dgvProforma_TableControlCheckBoxClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles dgvProforma.TableControlCheckBoxClick
    '    Dim style As GridTableCellStyleInfo = e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex)

    '    If style.CellValue = True Then
    '        '   MsgBox("false")
    '        UpdateDocEspera()
    '        dgvCompra.Item(5, dgvCompra.CurrentRow.Index).Value = "PROF"
    '    Else
    '        '  MsgBox("true")
    '        UpdateDoc()
    '        dgvCompra.Item(5, dgvCompra.CurrentRow.Index).Value = "PROFA"
    '    End If


    '    'UpdateDoc()
    '    'dgvCompra.Item(6, dgvCompra.CurrentRow.Index).Value = "S"
    '    'dgvCompra.Item(5, dgvCompra.CurrentRow.Index).Value = "PROFA"

    '    'ElseIf Not CheckBoxClicked Then

    '    'UpdateDocEspera()
    '    'dgvCompra.Item(6, dgvCompra.CurrentRow.Index).Value = "N"
    '    'dgvCompra.Item(5, dgvCompra.CurrentRow.Index).Value = "PROF"

    'End Sub

    'Private Sub dgvProforma_TableControlCurrentCellChanged(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlEventArgs) Handles dgvProforma.TableControlCurrentCellChanged
    '    Dim cc As GridCurrentCell = e.TableControl.CurrentCell
    '    'If cc.Renderer.StyleInfo.CellType = "CheckBox" Then
    '    '    '  MsgBox(e.TableControl.Table.CurrentRecord.Info)
    '    '    If e.TableControl.Table.CurrentRecordManager.CurrentField.DefaultValue = True Then
    '    '        MsgBox("check")
    '    '    Else

    '    '        MsgBox(" no check")
    '    '    End If
    '    '    Dim rv As DataRowView = TryCast(e.TableControl.Table.CurrentRecord.GetData(), DataRowView)
    '    'End If
    'End Sub

    Private Sub dgvProforma_TableControlCellClick(sender As System.Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles dgvProforma.TableControlCellClick

    End Sub

    Private Sub dgvProforma_TableControlCheckBoxClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles dgvProforma.TableControlCheckBoxClick
    End Sub
End Class