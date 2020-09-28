Imports Helios.General
Imports Helios.Planilla.Business.Entity
Imports Helios.Planilla.WCFService.ServiceAccess
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmConsultaAsistenciaTrabajador

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        cboPeriodo.DisplayMember = "Mes"
        cboPeriodo.ValueMember = "Codigo"
        cboPeriodo.DataSource = ListaDeMeses()
        txtAnio.Text = AnioGeneral
    End Sub
#End Region

#Region "Métodos"
    Private Sub CargarDetalleAsistencia(dia As Integer)
        Dim sa As New ControlDeAsistenciaSA
        dgDetalle.DataSource = sa.ControldeAsistenciaSelxPersonalDetalle(New ControlDeAsistencia With {.IDPersonal = txtPersonal.Tag, .AñoAsistencia = AnioGeneral,
                                                                         .MesAsistencia = MesGeneral, .DiaAsistencia = dia})
    End Sub

    Private Sub LoadTrabajador()
        Dim sa As New PersonalSA
        Dim be As Personal
        be = sa.PersonalSelxDNI(New Personal With {.Numerodocumento = txtFiltro.Text.Trim})
        If Not IsNothing(be) Then
            txtPersonal.Text = be.FullName
            txtPersonal.Tag = be.IDPersonal
        Else

        End If
    End Sub
#End Region

    Private Sub frmConsultaAsistenciaTrabajador_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        LoadAsistenciaTrabajador(Val(txtPersonal.Tag))
    End Sub

    Private Sub LoadAsistenciaTrabajador(idPersona As Integer)
        Dim sa As New ControlDeAsistenciaSA
        dgAsistencia.DataSource = sa.ControlDeAsistenciaSelxIDPersonal_SP(New ControlDeAsistencia With {.IDPersonal = idPersona, .AñoAsistencia = AnioGeneral, .MesAsistencia = CInt(cboPeriodo.SelectedValue)})
        dgAsistencia.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub

    Private Sub txtFiltro_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFiltro.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtFiltro.Text.Trim.Length > 0 Then
                LoadTrabajador()
            Else
                MessageBox.Show("Debe ingresar número de documento válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub dgAsistencia_TableControlCellClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles dgAsistencia.TableControlCellClick

    End Sub

    Private Sub dgAsistencia_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgAsistencia.SelectedRecordsChanged
        If Not IsNothing(e.SelectedRecord) Then
            CargarDetalleAsistencia(e.SelectedRecord.Record.GetValue("DiaAsistencia"))
        End If
    End Sub

    Private Sub dgDetalle_TableControlCellClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles dgDetalle.TableControlCellClick

    End Sub

    Private Sub dgDetalle_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgDetalle.QueryCellStyleInfo
        If Not IsNothing(e.TableCellIdentity.Column) Then
            Dim el As Syncfusion.Grouping.Element = e.TableCellIdentity.DisplayElement

            If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "TipoAcesso")) Then



                'Dim str = Me.dgDetalle.TableModel(e.TableCellIdentity.RowIndex, 1).CellValue
                ''Dim a = el.EngineTable.Records(e.TableCellIdentity.RowIndex - 1).GetValue("TipoAcesso")
                'Select Case str
                '    Case "HI" 'Hora de Ingreso
                '        e.Style.CellValue = "Hora de Ingreso"
                '        e.Style.BackColor = Color.AliceBlue
                '    Case "HS" 'Hora de Salida  
                '        e.Style.CellValue = "Hora de Sálida"
                '        e.Style.BackColor = Color.AliceBlue
                '    Case "RE" 'Refrigerio
                '        e.Style.CellValue = "Refrigerio"
                '        e.Style.BackColor = Color.AliceBlue
                '    Case "RI" 'Reingreso
                '        e.Style.CellValue = "Reingreso"
                '        e.Style.BackColor = Color.AliceBlue
                'End Select

            Else
                'e.Style.[ReadOnly] = False
            End If

            'If e.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell OrElse e.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell Then
            '    If e.TableCellIdentity.Column.Name = "HoraIngreso" Then
            '        e.Style.Format = "h:mm:ss tt"
            '    End If
            '    e.Handled = True
            'End If

            'If e.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell OrElse e.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell Then
            '    If e.TableCellIdentity.Column.Name = "fechaVcto" Then
            '        e.Style.Format = "dd/MM/yyyy"
            '    End If
            '    e.Handled = True
            'End If


            If (e.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell OrElse e.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) Then
                'Checks for the column name when the cellvalue is greater than 5.
                'If IsNumeric(e.Style.CellValue) Then
                '    If e.TableCellIdentity.Column.MappingName = "cantidad" AndAlso CInt(Fix(e.Style.CellValue)) > 0 Then
                '        ' e.Style.BackColor = Color.LightYellow
                '        e.Style.BackColor = Color.Yellow
                '        '     e.Style.Format = "##.00"
                '    End If
                'End If
                'If e.TableCellIdentity.Column.MappingName = "vcmn" AndAlso CInt(Fix(e.Style.CellValue)) > 0 Then
                '    e.Style.BackColor = Color.LightYellow
                '    'e.Style.Format = "S/.##.00"
                'End If
                'If e.TableCellIdentity.Column.MappingName = "almacen" Then
                '    e.Style.BackColor = Color.LightYellow
                'End If
                '    End If
                '    'If e.TableCellIdentity.Column.Name = "importeMN" Then
                '    '    If IsNumeric(e.Style.CellValue) Then
                '    '        '        If Fix(e.Style.CellValue) > 0 Then
                '    '        '    e.Style.ReadOnly = True
                '    '        e.TableCellIdentity.Table.CurrentRecord.SetValue("HaberMN", 0)
                '    '        'End If
                '    '    End If

            End If
        End If
    End Sub
End Class