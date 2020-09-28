Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Public Class frmRentabilidadMembresiaByMes

#Region "Attributes"
    Property dt As New DataTable
#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
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

        Const diasContratados = "diasContratados"
        Const diasUsados = "diasUsados"
        Const costoxdia = "costoxdia"
        Const rentabilidad = "rentabilidad"
    End Structure

    Private Sub GetMembresiasByPeriodo(periodo As String)
        dt = New DataTable
        dt.Columns.Add(ColumnNameDGV.fechaRegistro).Caption = "Fecha doc."
        dt.Columns.Add(ColumnNameDGV.Membresia).Caption = "Membresia / promoción"
        dt.Columns.Add(ColumnNameDGV.Cliente).Caption = "Cliente"
        dt.Columns.Add(ColumnNameDGV.DNICliente).Caption = "D.N.I."
        dt.Columns.Add(ColumnNameDGV.tipodoc).Caption = "Tipo doc."
        dt.Columns.Add(ColumnNameDGV.serie).Caption = "Serie"
        dt.Columns.Add(ColumnNameDGV.numero).Caption = "Número"
        dt.Columns.Add(ColumnNameDGV.fechaInicio).Caption = "Inicio"
        dt.Columns.Add(ColumnNameDGV.fechafin).Caption = "Finaliza"
        dt.Columns.Add(ColumnNameDGV.congela_dia).Caption = "Días congelados"
        dt.Columns.Add(ColumnNameDGV.importe).Caption = "Monto contractual"
        dt.Columns.Add(ColumnNameDGV.diasContratados).Caption = "Días contratados"
        dt.Columns.Add(ColumnNameDGV.diasUsados).Caption = "Días usados"
        dt.Columns.Add(ColumnNameDGV.costoxdia).Caption = "Costo x día"
        dt.Columns.Add(ColumnNameDGV.rentabilidad).Caption = "rentabilidad"


        For Each i In Entidadmembresia_GymSA.GetRegistroMembresiasByPeriodo(New Entidadmembresia_Gym With {.periodo = periodo, .idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento}).Where(Function(o) o.statusMembresia = Gimnasio_EstadoMembresia.Activo).ToList
            Dim TotalDias = DateDiff(DateInterval.Day, i.fechaInicio.GetValueOrDefault, i.fechaVcto.GetValueOrDefault)
            TotalDias += 1

            Dim diaActual = Date.Now.Date
            Dim TotalDiasUsados = DateDiff(DateInterval.Day, i.fechaInicio.GetValueOrDefault, diaActual)
            TotalDiasUsados += 1

            Dim costoXdia As Decimal = i.opGravado.GetValueOrDefault / TotalDias
            Dim rentabilidad As Decimal = TotalDiasUsados * costoXdia

            If TotalDiasUsados > 0 Then
                dt.Rows.Add(i.fechaRegistro,
                        i.CustomMembresia.descripcion,
                        i.CustomEntidad.nombreCompleto,
                        i.CustomEntidad.nrodoc,
                        i.tipodoc,
                        i.serie,
                        i.numero,
                        i.fechaInicio.GetValueOrDefault,
                        i.fechaVcto.GetValueOrDefault,
                        i.congela_dia,
                        i.opGravado,
                        TotalDias,
                        TotalDiasUsados,
                        costoXdia,
                        rentabilidad)
            Else
                dt.Rows.Add(i.fechaRegistro,
                        i.CustomMembresia.descripcion,
                        i.CustomEntidad.nombreCompleto,
                        i.CustomEntidad.nrodoc,
                        i.tipodoc,
                        i.serie,
                        i.numero,
                        i.fechaInicio.GetValueOrDefault,
                        i.fechaVcto.GetValueOrDefault,
                        i.congela_dia,
                        i.opGravado,
                        TotalDias,
                        0,
                        0,
                        0)
            End If


        Next
        dgvCompras.DataSource = dt
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        LoadingAnimator.Wire(dgvCompras.TableControl)
        GetMembresiasByPeriodo(cboMes.SelectedValue & "/" & txtAnio.Value.Year)
        LoadingAnimator.UnWire(dgvCompras.TableControl)
    End Sub
#End Region

#Region "Events"

#End Region

End Class