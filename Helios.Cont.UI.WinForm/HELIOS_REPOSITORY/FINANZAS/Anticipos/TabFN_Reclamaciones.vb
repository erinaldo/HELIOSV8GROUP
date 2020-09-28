Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.GroupingGridExcelConverter
Public Class TabFN_Reclamaciones

    Dim tipoAnti As String

#Region "Attributes"
    Public Property anticipoSA As New documentoAnticipoSA
    'Public Property FormMDI As FormMaestroModuloAnticipos

    Public Property FormPurchase As TabCT_ControlXCliente

    Public Property clienteID As Integer

    Public Property NumeroCliente As String

    Public Property NombreCliente As String

#End Region

#Region "Constructors"
    Public Sub New(form As FormMaestroModuloAnticipos)

        ' This call is required by the designer.
        InitializeComponent()
        'FormMDI = form
        General.FormatoGridAvanzado(GridStatus, True, False, 10.0F, SelectionMode.One)
        General.FormatoGridAvanzado(GridNotas, True, False, 10.0F, SelectionMode.One)
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(estado As Anticipo.Estado, tipo As String) ', form As FormMaestroModuloAnticipos)

        ' This call is required by the designer.
        InitializeComponent()
        'FormMDI = Form
        ' Add any initialization after the InitializeComponent() call.
        General.FormatoGridAvanzado(GridStatus, True, False, 10.0F, SelectionMode.One)
        General.FormatoGridAvanzado(GridNotas, True, False, 10.0F, SelectionMode.One)
        GradientPanel17.Visible = True

        tipoAnti = tipo
        'If tipoAnti = "AR" Then
        '    GetAnticiposStatus(estado, tipoAnti)
        'ElseIf tipoAnti = "AO" Then
        '    GetAnticiposStatusCompra(estado, tipoAnti)
        'End If

        txtPeriodo.Value = DateTime.Now
    End Sub


    Public Sub New(formRepPiscina As TabCT_ControlXCliente, status As Boolean, estado As String)

        ' This call is required by the designer.
        InitializeComponent()
        'FormMDI = form
        General.FormatoGridAvanzado(GridStatus, True, False, 10.0F, SelectionMode.One)
        General.FormatoGridAvanzado(GridNotas, True, False, 10.0F, SelectionMode.One)
        ' Add any initialization after the InitializeComponent() call.
        FormPurchase = formRepPiscina

        ToolStripButton1.Visible = status
        ButtonAdv1.Visible = status
        txtPeriodo.Value = Date.Now
        'ToolStripButton5.Visible = True
        ToolStripButton4.Visible = False
        'btnConsultar.Visible = True
    End Sub

#End Region


#Region "Methods"

    Public Sub GetAnticiposPeriodoxCliente(fecha As Date, tipo As String, idCliente As Integer)
        Dim anticipoSA As New documentoAnticipoSA
        Dim dt As New DataTable
        dt.Columns.Add("idDocumento")
        dt.Columns.Add("codigo")
        dt.Columns.Add("fecha")
        dt.Columns.Add("tipo")
        dt.Columns.Add("entidad")
        dt.Columns.Add("nrodoc")
        dt.Columns.Add("tipodeposito")
        dt.Columns.Add("monto")
        dt.Columns.Add("idEntidad")
        dt.Columns.Add("sumReclamaciones")
        dt.Columns.Add("numReclamaciones")
        dt.Columns.Add("disponible")
        dt.Columns.Add("estado")

        For Each i In anticipoSA.GetANTReclamacionesPeriodoXCliente(New Business.Entity.documentoAnticipo With
                                                       {
                                                       .fechaDoc = fecha,
                                                       .idEmpresa = Gempresas.IdEmpresaRuc,
                                                       .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                       .tipoAnticipo = tipo,
                                                       .estado = Anticipo.Estado.NotaCredito,
                                                       .razonSocial = idCliente
                                                       })
            dt.Rows.Add(
                i.idDocumento,
                i.numeroDoc,
                i.fechaDoc,
                i.tipoAnticipo,
                i.CustomEntidad.nombreCompleto,
                i.CustomEntidad.nrodoc,
                i.formaPago,
                i.importeMN,
                i.CustomEntidad.idEntidad,
                i.TotalNotas,
                i.ConteoNota,
                i.SaldoReclamacion,
                 "-")
        Next
        GridStatus.DataSource = dt
    End Sub
    Private Sub GetNotas(idPersona As Integer)

        Dim dt As New DataTable
        dt.Columns.Add("idDocumento")
        dt.Columns.Add("fecha")
        dt.Columns.Add("tipo")
        dt.Columns.Add("nrodoc")
        dt.Columns.Add("monto")
        dt.Columns.Add("usado")
        dt.Columns.Add("saldo")
        dt.Columns.Add("estado")

        For Each i In anticipoSA.GetANTReclamacionesPersonaAll(New documentoventaAbarrotes With
                                                             {
                                                             .idEmpresa = Gempresas.IdEmpresaRuc,
                                                             .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                             .tipoVenta = "VNCA",
                                                             .idCliente = idPersona
                                                             })

            dt.Rows.Add(i.idDocumento, i.fechaDoc, "NOTA DE CREDITO", i.numeroDoc, i.importeMN, i.TotalNotas, i.SaldoReclamacion.GetValueOrDefault, i.EstadoName)
        Next
        GridNotas.DataSource = dt
    End Sub


    Private Sub GetAnticiposStatusCompra(estado As Anticipo.Estado, tipo As String)
        Dim anticipoSA As New documentoAnticipoSA
        Dim dt As New DataTable
        dt.Columns.Add("idDocumento")
        dt.Columns.Add("codigo")
        dt.Columns.Add("fecha")
        dt.Columns.Add("tipo")
        dt.Columns.Add("entidad")
        dt.Columns.Add("nrodoc")
        dt.Columns.Add("tipodeposito")
        dt.Columns.Add("monto")
        dt.Columns.Add("idEntidad")
        dt.Columns.Add("sumReclamaciones")
        dt.Columns.Add("numReclamaciones")
        dt.Columns.Add("disponible")
        dt.Columns.Add("estado")

        For Each i In anticipoSA.GetANTReclamacionesStatusCompra(New Business.Entity.documentoAnticipo With
                                                       {
                                                       .fechaDoc = Date.Now,
                                                       .idEmpresa = Gempresas.IdEmpresaRuc,
                                                       .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                       .tipoAnticipo = tipo,
                                                       .estado = estado
                                                       })
            dt.Rows.Add(
                i.idDocumento,
                i.numeroDoc,
                i.fechaDoc,
                i.tipoAnticipo,
                i.CustomEntidad.nombreCompleto,
                i.CustomEntidad.nrodoc,
                i.formaPago,
                i.importeMN,
                i.CustomEntidad.idEntidad,
                i.TotalNotas,
                i.ConteoNota,
                i.SaldoReclamacion,
                 "-")
        Next
        GridStatus.DataSource = dt
    End Sub


    Private Sub GetAnticiposStatus(estado As Anticipo.Estado, tipo As String)
        Dim anticipoSA As New documentoAnticipoSA
        Dim dt As New DataTable
        dt.Columns.Add("idDocumento")
        dt.Columns.Add("codigo")
        dt.Columns.Add("fecha")
        dt.Columns.Add("tipo")
        dt.Columns.Add("entidad")
        dt.Columns.Add("nrodoc")
        dt.Columns.Add("tipodeposito")
        dt.Columns.Add("monto")
        dt.Columns.Add("idEntidad")
        dt.Columns.Add("sumReclamaciones")
        dt.Columns.Add("numReclamaciones")
        dt.Columns.Add("disponible")
        dt.Columns.Add("estado")

        For Each i In anticipoSA.GetANTReclamacionesStatus(New Business.Entity.documentoAnticipo With
                                                       {
                                                       .fechaDoc = Date.Now,
                                                       .idEmpresa = Gempresas.IdEmpresaRuc,
                                                       .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                       .tipoAnticipo = tipo,
                                                       .estado = estado
                                                       })
            dt.Rows.Add(
                i.idDocumento,
                i.numeroDoc,
                i.fechaDoc,
                i.tipoAnticipo,
                i.CustomEntidad.nombreCompleto,
                i.CustomEntidad.nrodoc,
                i.formaPago,
                i.importeMN,
                i.CustomEntidad.idEntidad,
                i.TotalNotas,
                i.ConteoNota,
                i.SaldoReclamacion,
                 "-")
        Next
        GridStatus.DataSource = dt
    End Sub

    Private Sub GetAnticiposPeriodoCompra(fecha As Date, tipo As String)
        Dim anticipoSA As New documentoAnticipoSA
        Dim dt As New DataTable
        dt.Columns.Add("idDocumento")
        dt.Columns.Add("codigo")
        dt.Columns.Add("fecha")
        dt.Columns.Add("tipo")
        dt.Columns.Add("entidad")
        dt.Columns.Add("nrodoc")
        dt.Columns.Add("tipodeposito")
        dt.Columns.Add("monto")
        dt.Columns.Add("idEntidad")
        dt.Columns.Add("sumReclamaciones")
        dt.Columns.Add("numReclamaciones")
        dt.Columns.Add("disponible")
        dt.Columns.Add("estado")

        For Each i In anticipoSA.GetANTReclamacionesPeriodoCompra(New Business.Entity.documentoAnticipo With
                                                       {
                                                       .fechaDoc = fecha,
                                                       .idEmpresa = Gempresas.IdEmpresaRuc,
                                                       .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                       .tipoAnticipo = tipo,
                                                       .estado = Anticipo.Estado.NotaCredito
                                                       })
            dt.Rows.Add(
                i.idDocumento,
                i.numeroDoc,
                i.fechaDoc,
                i.tipoAnticipo,
                i.CustomEntidad.nombreCompleto,
                i.CustomEntidad.nrodoc,
                i.formaPago,
                i.importeMN,
                i.CustomEntidad.idEntidad,
                i.TotalNotas,
                i.ConteoNota,
                i.SaldoReclamacion,
                 "-")
        Next
        GridStatus.DataSource = dt
    End Sub
    Private Sub GetAnticiposPeriodo(fecha As Date, tipo As String)
        Dim anticipoSA As New documentoAnticipoSA
        Dim dt As New DataTable
        dt.Columns.Add("idDocumento")
        dt.Columns.Add("codigo")
        dt.Columns.Add("fecha")
        dt.Columns.Add("tipo")
        dt.Columns.Add("entidad")
        dt.Columns.Add("nrodoc")
        dt.Columns.Add("tipodeposito")
        dt.Columns.Add("monto")
        dt.Columns.Add("idEntidad")
        dt.Columns.Add("sumReclamaciones")
        dt.Columns.Add("numReclamaciones")
        dt.Columns.Add("disponible")
        dt.Columns.Add("estado")

        For Each i In anticipoSA.GetANTReclamacionesPeriodo(New Business.Entity.documentoAnticipo With
                                                       {
                                                       .fechaDoc = fecha,
                                                       .idEmpresa = Gempresas.IdEmpresaRuc,
                                                       .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                       .tipoAnticipo = tipo,
                                                       .estado = Anticipo.Estado.NotaCredito
                                                       })
            dt.Rows.Add(
                i.idDocumento,
                i.numeroDoc,
                i.fechaDoc,
                i.tipoAnticipo,
                i.CustomEntidad.nombreCompleto,
                i.CustomEntidad.nrodoc,
                i.formaPago,
                i.importeMN,
                i.CustomEntidad.idEntidad,
                i.TotalNotas,
                i.ConteoNota,
                i.SaldoReclamacion,
                 "-")
        Next
        GridStatus.DataSource = dt
    End Sub

#End Region

#Region "Events"


    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim r As Record = GridStatus.Table.CurrentRecord
        If r IsNot Nothing Then
            Dim ent As New entidad With
                {
                .idEntidad = Integer.Parse(r.GetValue("idEntidad")),
                .nombreCompleto = r.GetValue("entidad"),
                .nrodoc = r.GetValue("nrodoc")
            }
            Dim idDocumento As Integer = Integer.Parse(r.GetValue("idDocumento"))

            If tipoAnti = "AR" Then
                Dim f As New FormCrearNotaCreditoAnticipo(idDocumento, ent)
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog(Me)
            ElseIf tipoAnti = "AO" Then
                Dim f As New FormCrearNotaCreditoAnticipoOtorgado(idDocumento, ent)
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog(Me)
            End If


        End If
    End Sub

    Private Sub GridStatus_TableControlCellClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles GridStatus.TableControlCellClick

    End Sub

    Private Sub GridResumenFormaPago_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles GridStatus.SelectedRecordsChanged
        'Cursor = Cursors.WaitCursor
        'If e.SelectedRecord IsNot Nothing Then
        '    Dim r As Record = e.SelectedRecord.Record
        '    If r IsNot Nothing Then
        '        If GridStatus.Table.Records.Count > 0 Then
        '            GetNotas(Integer.Parse(r.GetValue("idEntidad")))
        '        End If
        '    End If
        'End If
        'Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Dim fecha = txtPeriodo.Value

        If tipoAnti = "AR" Then
            GetAnticiposPeriodo(fecha, tipoAnti)
        ElseIf tipoAnti = "AO" Then
            GetAnticiposPeriodoCompra(fecha, tipoAnti)
        End If
    End Sub
#End Region

End Class

