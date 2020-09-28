Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General

Public Class frmMembresiasPorVencer

#Region "Attributes"
    Protected Friend dt As DataTable
#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        txtFechaConsulta.Value = Date.Now
        txtFechaaInicio.Value = New Date(Date.Now.Year, Date.Now.Month, 1)
        FormatoGridAvanzado(dgvCompras, True, False)
        cboMes.DataSource = ListaDeMeses()
        cboMes.ValueMember = "Codigo"
        cboMes.DisplayMember = "Mes"
        txtAnio.Value = New Date(txtAnio.Value.Year, Date.Now.Month, 1)
        txtAnio.Value = DiaLaboral
        cboMes.SelectedValue = MesGeneral
    End Sub
#End Region

#Region "Methods"

    Sub CalculoConsulta()
        Dim fInicio = txtFechaaInicio.Value
        Dim valConuslta = txtValor.Value
        Dim result = Nothing
        Select Case cboConsulta.Text
            Case "meses"
                result = fInicio.AddMonths(valConuslta)
            Case "días"
                result = fInicio.AddDays(valConuslta)
        End Select
        txtFechaConsulta.Value = result
    End Sub

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
        Const congela_dia = "congela_dia"
        Const importe = "importe"
        Const statusMembresia = "statusMembresia"
        Const statusPago = "statusPago"
    End Structure

    Private Sub GetMembresiasPorVencer()
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
        dt.Columns.Add(ColumnNameDGV.fechafin).Caption = "Vence"
        dt.Columns.Add(ColumnNameDGV.congela_dia).Caption = "Días congelados"
        dt.Columns.Add(ColumnNameDGV.importe).Caption = "Importe"
        dt.Columns.Add(ColumnNameDGV.statusPago).Caption = "Pago"
        dt.Columns.Add(ColumnNameDGV.statusMembresia).Caption = "Estado"

        For Each i In Entidadmembresia_GymSA.GetMembresiasPorVencer(
            New Entidadmembresia_Gym With
            {.idEmpresa = Gempresas.IdEmpresaRuc,
            .idEstablecimiento = GEstableciento.IdEstablecimiento,
            .fechaInicio = txtFechaaInicio.Value,
            .fechaVcto = txtFechaConsulta.Value})

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
                        i.fechaVcto,
                        i.congela_dia,
                        i.importe,
                        i.statusPago,
                        i.statusMembresia)
        Next
        dgvCompras.DataSource = dt
    End Sub

    Private Sub GetMembresiasPorVencerPeriodo()
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
        dt.Columns.Add(ColumnNameDGV.fechafin).Caption = "Vence"
        dt.Columns.Add(ColumnNameDGV.congela_dia).Caption = "Días congelados"
        dt.Columns.Add(ColumnNameDGV.importe).Caption = "Importe"
        dt.Columns.Add(ColumnNameDGV.statusPago).Caption = "Pago"
        dt.Columns.Add(ColumnNameDGV.statusMembresia).Caption = "Estado"

        For Each i In Entidadmembresia_GymSA.GetMembresiasPorVencerPeriodo(
            New Entidadmembresia_Gym With
            {.idEmpresa = Gempresas.IdEmpresaRuc,
            .idEstablecimiento = GEstableciento.IdEstablecimiento,
            .periodo = cboMes.SelectedValue & "/" & txtAnio.Value.Year})

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
                        i.fechaVcto,
                        i.congela_dia,
                        i.importe,
                        i.statusPago,
                        i.statusMembresia)
        Next
        dgvCompras.DataSource = dt
    End Sub
#End Region

#Region "Events"
    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        LoadingAnimator.Wire(dgvCompras.TableControl)
        GetMembresiasPorVencer()
        LoadingAnimator.UnWire(dgvCompras.TableControl)
    End Sub

    Private Sub txtValor_ValueChanged(sender As Object, e As EventArgs) Handles txtValor.ValueChanged
        CalculoConsulta()
    End Sub

    Private Sub cboConsulta_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboConsulta.SelectedValueChanged
        If Not IsNothing(cboConsulta.Text) Then
            CalculoConsulta()
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Panel1.Visible = True
        Else
            Panel1.Visible = False
        End If
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        LoadingAnimator.Wire(dgvCompras.TableControl)
        GetMembresiasPorVencerPeriodo()
        LoadingAnimator.UnWire(dgvCompras.TableControl)
    End Sub
#End Region

End Class