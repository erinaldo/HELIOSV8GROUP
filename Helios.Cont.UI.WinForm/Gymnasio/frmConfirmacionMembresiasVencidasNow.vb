Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping

Public Class frmConfirmacionMembresiasVencidasNow
#Region "Attributes"
    Protected dt As DataTable
#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(dgvCompras, True, False)
        txtFechaaInicio.Value = Date.Now
    End Sub

    Public Sub New(fechaNow As Date)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(dgvCompras, True, False)
        GetMembresiasPorVencerPeriodo(fechaNow)
        txtFechaaInicio.Value = fechaNow
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
        Const congela_dia = "congela_dia"
        Const importe = "importe"
        Const statusMembresia = "statusMembresia"
        Const statusPago = "statusPago"
    End Structure

    Private Sub GetMembresiasPorVencerPeriodo(fecha As Date)
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

        For Each i In Entidadmembresia_GymSA.GetMembresiasPorStatusMembresiaXfecha(
            New Entidadmembresia_Gym With
            {.idEmpresa = Gempresas.IdEmpresaRuc,
            .idEstablecimiento = GEstableciento.IdEstablecimiento,
            .statusMembresia = Gimnasio_EstadoMembresia.Activo,
            .fechaVcto = fecha})

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
    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        LoadingAnimator.Wire(dgvCompras.TableControl)
        GetMembresiasPorVencerPeriodo(txtFechaaInicio.Value.Date)
        LoadingAnimator.UnWire(dgvCompras.TableControl)
    End Sub

    Private Sub frmConfirmacionMembresiasVencidasNow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CaptionLabels(1).Text = Date.Now.Date
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Cursor = Cursors.WaitCursor
        Dim lista As New List(Of Entidadmembresia_Gym)
        For Each r As Record In dgvCompras.Table.Records
            lista.Add(New Entidadmembresia_Gym With {.idDocumento = r.GetValue(ColumnNameDGV.idDocumento)})
        Next
        Entidadmembresia_GymSA.GetMembresiasVencidasDelDia(lista)
        Cursor = Cursors.Default
        Close()
    End Sub
#End Region
End Class