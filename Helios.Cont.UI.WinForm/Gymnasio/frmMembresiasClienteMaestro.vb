Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmMembresiasClienteMaestro
#Region "Attributes"
    Protected dt As DataTable
    Protected Friend frmRegistroClienteMembresia As frmRegistroClienteMembresia
    Protected Friend frmMembresiaConfirmarInicio As frmMembresiaConfirmarInicio
    Protected Friend frmSeguimientoControlMembresia As frmSeguimientoControlMembresia
    Protected Friend frmMembresiasCongelamientos As frmMembresiasCongelamientos
    Protected Friend frmPagoMembresia As frmPagoMembresia
    Protected Friend frmHistorialPagosMembresias As frmHistorialPagosMembresias
    Public Property r As Record
    Dim filter As New GridExcelFilter()
#End Region

#Region "Constructors"
    Public Sub New(idSocio As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        GradientPanel11.Visible = False
        GetMembresiasBySocio(idSocio)
        FormatoGridAvanzado(dgvCompras, True, False)
    End Sub

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        cboPeriodo.DataSource = ListaDeMeses()
        cboPeriodo.ValueMember = "Codigo"
        cboPeriodo.DisplayMember = "Mes"
        cboPeriodo.SelectedValue = MesGeneral
        txtAnioCompra.Text = AnioGeneral
        FormatoGridAvanzado(dgvCompras, True, False)
    End Sub

#End Region

#Region "Methods"
    Structure ColumnNameDGV
        Const idMembresia = "idMembresia"
        Const Membresia = "Membresia"
        Const idDocumento = "idDocumento"
        Const tipoServicio = "tipoServicio"
        Const tipodoc = "tipodoc"
        Const serie = "serie"
        Const numero = "numero"
        Const idEntidad = "idEntidad"
        Const Cliente = "Cliente"
        Const DNICliente = "DNICliente"
        Const fechaRegistro = "fechaRegistro"
        Const fechaInicio = "fechaInicio"
        Const fechafin = "fechafin"
        Const contract_mes = "contract_mes"
        Const contract_dia = "contract_dia"
        Const congela_mes = "congela_mes"
        Const congela_dia = "congela_dia"
        Const importe = "importe"
        Const statusMembresia = "statusMembresia"
        Const statusPago = "statusPago"
    End Structure

    Private Sub GetMembresiasByPeriodo(periodo As String)
        dt = New DataTable
        dt.Columns.Add(ColumnNameDGV.idMembresia).Caption = "IDM"
        dt.Columns.Add(ColumnNameDGV.Membresia).Caption = "Membresia / promoción"
        dt.Columns.Add(ColumnNameDGV.idDocumento).Caption = "IDD"
        dt.Columns.Add(ColumnNameDGV.tipodoc).Caption = "Tipo doc."
        dt.Columns.Add(ColumnNameDGV.serie).Caption = "Serie"
        dt.Columns.Add(ColumnNameDGV.numero).Caption = "Número"
        dt.Columns.Add(ColumnNameDGV.tipoServicio).Caption = "Tipo"
        dt.Columns.Add(ColumnNameDGV.idEntidad).Caption = "IDE"
        dt.Columns.Add(ColumnNameDGV.Cliente).Caption = "Cliente"
        dt.Columns.Add(ColumnNameDGV.DNICliente).Caption = "D.N.I."
        dt.Columns.Add(ColumnNameDGV.fechaRegistro).Caption = "Fecha doc."
        dt.Columns.Add(ColumnNameDGV.fechaInicio).Caption = "Inicio"
        dt.Columns.Add(ColumnNameDGV.fechafin).Caption = "Finaliza"
        dt.Columns.Add(ColumnNameDGV.contract_mes).Caption = "Mes"
        dt.Columns.Add(ColumnNameDGV.contract_dia).Caption = "Día"
        dt.Columns.Add(ColumnNameDGV.congela_mes).Caption = "Mes"
        dt.Columns.Add(ColumnNameDGV.congela_dia).Caption = "Días congelados"
        dt.Columns.Add(ColumnNameDGV.importe).Caption = "Importe"
        dt.Columns.Add(ColumnNameDGV.statusPago).Caption = "Pago"
        dt.Columns.Add(ColumnNameDGV.statusMembresia).Caption = "Estado"

        For Each i In Entidadmembresia_GymSA.GetRegistroMembresiasByPeriodo(New Entidadmembresia_Gym With {.periodo = periodo, .idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento})
            dt.Rows.Add(i.idMembresia,
                        i.CustomMembresia.descripcion,
                        i.idDocumento,
                        i.tipodoc,
                        i.serie,
                        i.numero,
                        i.tipoServicio,
                        i.idEntidad,
                        i.CustomEntidad.nombreCompleto,
                        i.CustomEntidad.nrodoc,
                        i.fechaRegistro,
                        i.fechaInicio.GetValueOrDefault,
                        i.fechaVcto.GetValueOrDefault,
                        i.contract_mes,
                        i.contract_dia,
                        i.congela_mes,
                        i.congela_dia,
                        i.importe,
                        i.statusPago,
                        i.statusMembresia)
        Next
        dgvCompras.DataSource = dt
    End Sub

    Private Sub GetMembresiasBySocio(idSocio As Integer)
        dt = New DataTable
        dt.Columns.Add(ColumnNameDGV.idMembresia).Caption = "IDM"
        dt.Columns.Add(ColumnNameDGV.Membresia).Caption = "Membresia / promoción"
        dt.Columns.Add(ColumnNameDGV.idDocumento).Caption = "IDD"
        dt.Columns.Add(ColumnNameDGV.tipodoc).Caption = "Tipo doc."
        dt.Columns.Add(ColumnNameDGV.serie).Caption = "Serie"
        dt.Columns.Add(ColumnNameDGV.numero).Caption = "Número"
        dt.Columns.Add(ColumnNameDGV.tipoServicio).Caption = "Tipo"
        dt.Columns.Add(ColumnNameDGV.idEntidad).Caption = "IDE"
        dt.Columns.Add(ColumnNameDGV.Cliente).Caption = "Cliente"
        dt.Columns.Add(ColumnNameDGV.DNICliente).Caption = "D.N.I."
        dt.Columns.Add(ColumnNameDGV.fechaRegistro).Caption = "Fecha doc."
        dt.Columns.Add(ColumnNameDGV.fechaInicio).Caption = "Inicio"
        dt.Columns.Add(ColumnNameDGV.fechafin).Caption = "Finaliza"
        dt.Columns.Add(ColumnNameDGV.contract_mes).Caption = "Mes"
        dt.Columns.Add(ColumnNameDGV.contract_dia).Caption = "Día"
        dt.Columns.Add(ColumnNameDGV.congela_mes).Caption = "Mes"
        dt.Columns.Add(ColumnNameDGV.congela_dia).Caption = "Días congelados"
        dt.Columns.Add(ColumnNameDGV.importe).Caption = "Importe"
        dt.Columns.Add(ColumnNameDGV.statusPago).Caption = "Pago"
        dt.Columns.Add(ColumnNameDGV.statusMembresia).Caption = "Estado"

        For Each i In Entidadmembresia_GymSA.GetMembresiasContratadasXSocio(New Entidadmembresia_Gym With {.idEntidad = idSocio, .idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento})
            dt.Rows.Add(i.idMembresia,
                        i.CustomMembresia.descripcion,
                        i.idDocumento,
                        i.tipodoc,
                        i.serie,
                        i.numero,
                        i.tipoServicio,
                        i.idEntidad,
                        i.CustomEntidad.nombreCompleto,
                        i.CustomEntidad.nrodoc,
                        i.fechaRegistro,
                        i.fechaInicio.GetValueOrDefault,
                        i.fechaVcto.GetValueOrDefault,
                        i.contract_mes,
                        i.contract_dia,
                        i.congela_mes,
                        i.congela_dia,
                        i.importe,
                        i.statusPago,
                        i.statusMembresia)
        Next
        dgvCompras.DataSource = dt
    End Sub
#End Region

#Region "Events"
    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        LoadingAnimator.Wire(dgvCompras.TableControl)
        GetMembresiasByPeriodo(cboPeriodo.SelectedValue & "/" & AnioGeneral)
        LoadingAnimator.UnWire(dgvCompras.TableControl)
    End Sub

    Private Sub ToolStripButton13_Click(sender As Object, e As EventArgs) Handles ToolStripButton13.Click
        Try
            Select Case usuario.CustomUsuario.CustomUsuarioRol.IDRol
                Case 3, 4
                    frmRegistroClienteMembresia = New frmRegistroClienteMembresia
                    frmRegistroClienteMembresia.txtPeriodo.Value = New Date(AnioGeneral, CInt(cboPeriodo.SelectedValue), 1)
                    frmRegistroClienteMembresia.StartPosition = FormStartPosition.CenterParent
                    frmRegistroClienteMembresia.ShowDialog()
                Case Else
                    MessageBox.Show("Debe iniciar una caja", "Iniciar sesión de caja", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        r = dgvCompras.Table.CurrentRecord
        If r IsNot Nothing Then
            frmMembresiaConfirmarInicio = New frmMembresiaConfirmarInicio(Integer.Parse(r.GetValue("idDocumento")))
            frmMembresiaConfirmarInicio.StartPosition = FormStartPosition.CenterParent
            frmMembresiaConfirmarInicio.ShowDialog()
        Else
            MessageBox.Show("Debe seleccionar un documento válido", "Seleccionar fila", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub dgvCompras_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvCompras.QueryCellStyleInfo

        If (e.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell OrElse e.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) Then
            'Checks for the column name when the cellvalue is greater than 5.
            'ENTRADAS A ALMACEN
            If e.TableCellIdentity.Column.MappingName = "statusPago" AndAlso (e.Style.CellValue) = "0" Then
                e.Style.BackColor = Color.FromArgb(234, 46, 46)
                e.Style.Text = "Pendiente"
                e.Style.TextColor = Color.White
            End If

            If e.TableCellIdentity.Column.MappingName = "statusPago" AndAlso (e.Style.CellValue) = "1" Then
                e.Style.BackColor = Color.FromArgb(241, 71, 26)
                e.Style.Text = "Parcial"
                e.Style.TextColor = Color.White
            End If

            If e.TableCellIdentity.Column.MappingName = "statusPago" AndAlso (e.Style.CellValue) = "2" Then
                e.Style.BackColor = Color.FromArgb(49, 169, 87)
                e.Style.Text = "Saldado"
                e.Style.TextColor = Color.White
            End If

            If e.TableCellIdentity.Column.MappingName = "statusPago" AndAlso (e.Style.CellValue) = "3" Then
                e.Style.BackColor = Color.FromArgb(22, 165, 220)
                e.Style.Text = "Ingreso Libre"
                e.Style.TextColor = Color.White
            End If

        End If

        If (e.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell OrElse e.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) Then
            'Checks for the column name when the cellvalue is greater than 5.
            'ENTRADAS A ALMACEN
            'If e.TableCellIdentity.Column.MappingName = "cantidad" AndAlso CDbl(Fix(e.Style.CellValue)) > 0 Then
            '    e.Style.BackColor = Color.FromArgb(225, 240, 190)
            'End If
            'If e.TableCellIdentity.Column.MappingName = "monto" AndAlso CDbl(Fix(e.Style.CellValue)) > 0 Then
            '    e.Style.BackColor = Color.FromArgb(225, 240, 190)
            'End If


            ''SALIDAS A ALMACEN
            'If e.TableCellIdentity.Column.MappingName = "cantidad1" AndAlso CDbl(Fix(e.Style.CellValue)) > 0 Then
            '    e.Style.BackColor = Color.FromArgb(255, 192, 192) '
            'End If
            'If e.TableCellIdentity.Column.MappingName = "monto1" AndAlso CDbl(Fix(e.Style.CellValue)) > 0 Then
            '    e.Style.BackColor = Color.FromArgb(255, 192, 192)
            'End If

        End If


        If e.TableCellIdentity.RowIndex <> -1 Then
            'Dim rec As GridRecordRow =
            '    TryCast(dgvCompras.Table.DisplayElements(e.TableCellIdentity.RowIndex), GridRecordRow)

            'If rec IsNot Nothing Then
            '    ' Applies format by checking the value Row1
            '    Dim dr As DataRowView = TryCast(rec.GetData(), DataRowView)
            '    If dr IsNot Nothing AndAlso CDec(dr(ColumnNameDGV.statusMembresia)) = Gimnasio_EstadoMembresia.Activo Then
            '        '   e.Style.Enabled = False
            '        e.Style.Text = "Activo"
            '    ElseIf dr IsNot Nothing AndAlso CDec(dr(ColumnNameDGV.statusMembresia)) = Gimnasio_EstadoMembresia.Baja Then
            '        e.Style.Text = "Culminado"
            '    End If

            '    If dr IsNot Nothing AndAlso CDec(dr(ColumnNameDGV.statusPago)) = Gimnasio_EstadoMembresiaPago.Completo Then
            '        e.Style.Text = "Saldado"
            '    ElseIf dr IsNot Nothing AndAlso CDec(dr(ColumnNameDGV.statusPago)) = Gimnasio_EstadoMembresiaPago.PagoParcial Then
            '        e.Style.Text = "Parcial"
            '    ElseIf dr IsNot Nothing AndAlso CDec(dr(ColumnNameDGV.statusPago)) = Gimnasio_EstadoMembresiaPago.Pendiente Then
            '        e.Style.Text = "Pendiente"
            '    End If

            'End If
        End If
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        LoadingAnimator.Wire(dgvCompras.TableControl)
        r = dgvCompras.Table.CurrentRecord
        If r IsNot Nothing Then
            frmSeguimientoControlMembresia = New frmSeguimientoControlMembresia(r.GetValue(ColumnNameDGV.idDocumento))
            frmSeguimientoControlMembresia.StartPosition = FormStartPosition.CenterParent
            frmSeguimientoControlMembresia.ShowDialog()
        End If
        LoadingAnimator.UnWire(dgvCompras.TableControl)
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        LoadingAnimator.Wire(dgvCompras.TableControl)
        r = dgvCompras.Table.CurrentRecord
        If r IsNot Nothing Then
            frmMembresiasCongelamientos = New frmMembresiasCongelamientos(r.GetValue(ColumnNameDGV.idDocumento))
            frmMembresiasCongelamientos.StartPosition = FormStartPosition.CenterParent
            frmMembresiasCongelamientos.ShowDialog()
        End If
        LoadingAnimator.UnWire(dgvCompras.TableControl)
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        LoadingAnimator.Wire(dgvCompras.TableControl)
        r = dgvCompras.Table.CurrentRecord
        If r IsNot Nothing Then
            If r.GetValue(ColumnNameDGV.statusPago) = Gimnasio_EstadoMembresiaPago.IngresoLibre Then
                MessageBox.Show("No puede cobrar un comprobante de ingreso libre", "Pago restringido", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                frmPagoMembresia = New frmPagoMembresia(r.GetValue(ColumnNameDGV.idDocumento))
                frmPagoMembresia.txtPeriodo.Value = New Date(AnioGeneral, CInt(cboPeriodo.SelectedValue), 1)
                frmPagoMembresia.StartPosition = FormStartPosition.CenterParent
                frmPagoMembresia.ShowDialog()
                ButtonAdv6_Click(sender, e)
            End If
        Else
            MessageBox.Show("Debe seleccionar un comprobante", "Seleccionar fila", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        LoadingAnimator.UnWire(dgvCompras.TableControl)
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        LoadingAnimator.Wire(dgvCompras.TableControl)
        r = dgvCompras.Table.CurrentRecord
        If r IsNot Nothing Then
            If r.GetValue(ColumnNameDGV.statusPago) = Gimnasio_EstadoMembresiaPago.IngresoLibre Then
                MessageBox.Show("No puede cobrar un comprobante de ingreso libre", "Pago restringido", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                frmHistorialPagosMembresias = New frmHistorialPagosMembresias(r.GetValue(ColumnNameDGV.idDocumento))
                frmHistorialPagosMembresias.StartPosition = FormStartPosition.CenterParent
                frmHistorialPagosMembresias.ShowDialog()
            End If
        Else
            MessageBox.Show("Debe seleccionar un comprobante", "Seleccionar fila", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        LoadingAnimator.UnWire(dgvCompras.TableControl)
    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        LoadingAnimator.Wire(dgvCompras.TableControl)
        r = dgvCompras.Table.CurrentRecord
        If r IsNot Nothing Then
            frmRegistroClienteMembresia = New frmRegistroClienteMembresia(r.GetValue(ColumnNameDGV.idDocumento))
            frmRegistroClienteMembresia.StartPosition = FormStartPosition.CenterParent
            frmRegistroClienteMembresia.ShowDialog()
        Else
            MessageBox.Show("Debe seleccionar un comprobante", "Seleccionar fila", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        LoadingAnimator.UnWire(dgvCompras.TableControl)
    End Sub

    Private Sub ToggleButton21_ButtonStateChanged(sender As Object, e As ToggleButton2.ToggleButtonStateEventArgs) Handles ToggleButton21.ButtonStateChanged
        If ToggleButton21.ToggleState = ToggleButton2.ToggleButtonState.OFF Then
            dgvCompras.TopLevelGroupOptions.ShowFilterBar = True
            dgvCompras.NestedTableGroupOptions.ShowFilterBar = True
            dgvCompras.ChildGroupOptions.ShowFilterBar = True
            For Each col As GridColumnDescriptor In dgvCompras.TableDescriptor.Columns
                col.AllowFilter = True
            Next
            filter.AllowResize = True
            filter.AllowFilterByColor = True
            filter.EnableDateFilter = True
            filter.EnableNumberFilter = True

            dgvCompras.OptimizeFilterPerformance = True
            dgvCompras.ShowNavigationBar = True
            filter.WireGrid(dgvCompras)
        Else
            filter.ClearFilters(dgvCompras)
            dgvCompras.TopLevelGroupOptions.ShowFilterBar = False
        End If
    End Sub

    Private Sub dgvCompras_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompras.TableControlCellClick

    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        LoadingAnimator.Wire(dgvCompras.TableControl)
        r = dgvCompras.Table.CurrentRecord
        If r IsNot Nothing Then
            'If r.GetValue(ColumnNameDGV.statusPago) = Gimnasio_EstadoMembresiaPago.IngresoLibre Then
            '    MessageBox.Show("No puede cobrar un comprobante de ingreso libre", "Pago restringido", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Else
            Select Case usuario.CustomUsuario.CustomUsuarioRol.IDRol
                Case 1
                    Entidadmembresia_GymSA.GetEliminarMembresia(New Entidadmembresia_Gym With {.idDocumento = r.GetValue(ColumnNameDGV.idDocumento)})
                    dgvCompras.Table.CurrentRecord.Delete()
                Case Else
                    MessageBox.Show("Debe tener permisos de administrador", "Seleccionar fila", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Select
            'End If
        Else
            MessageBox.Show("Debe seleccionar un comprobante", "Seleccionar fila", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        LoadingAnimator.UnWire(dgvCompras.TableControl)
    End Sub

    Private Sub GradientPanel11_Paint(sender As Object, e As PaintEventArgs) Handles GradientPanel11.Paint

    End Sub

    Private Sub frmMembresiasClienteMaestro_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        LoadingAnimator.Wire(dgvCompras.TableControl)
        r = dgvCompras.Table.CurrentRecord
        If r IsNot Nothing Then
            If r.GetValue(ColumnNameDGV.statusPago) = Gimnasio_EstadoMembresiaPago.IngresoLibre Then
                MessageBox.Show("No puede cobrar un comprobante de ingreso libre", "Pago restringido", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                frmPagoMembresia = New frmPagoMembresia(r.GetValue(ColumnNameDGV.idDocumento))
                frmPagoMembresia.txtPeriodo.Value = New Date(AnioGeneral, CInt(cboPeriodo.SelectedValue), 1)
                frmPagoMembresia.StartPosition = FormStartPosition.CenterParent
                frmPagoMembresia.ShowDialog()
                ButtonAdv6_Click(sender, e)
            End If
        Else
            MessageBox.Show("Debe seleccionar un comprobante", "Seleccionar fila", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        LoadingAnimator.UnWire(dgvCompras.TableControl)
    End Sub

#End Region
End Class