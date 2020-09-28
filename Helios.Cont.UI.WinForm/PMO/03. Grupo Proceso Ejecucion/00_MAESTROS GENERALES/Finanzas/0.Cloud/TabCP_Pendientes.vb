Imports Helios.Cont.Business.Entity
Imports Helios.Cont.Presentation.WinForm
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping

Public Class TabCP_Pendientes

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(GridPendientes, True, False)
        'GetComprasPorAprobar()
    End Sub

    Public Class EstadoPagos
        Property Codigo As String
        Property Name As String
        Property Valor As Integer
        Public Sub New()

        End Sub
    End Class

    'Public Sub GetAsync()
    '    Dim compraSA As New DocumentoCompraSA
    '    Dim Pendientes = compraSA.GetCuentasPorPagarStatusCount(New Business.Entity.documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .apruebaPago = StatusAprobacionPagos.Pendiente})
    '    Dim Aprobados = compraSA.GetCuentasPorPagarStatusCount(New Business.Entity.documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .apruebaPago = StatusAprobacionPagos.Aprobado})
    '    Dim Rechazados = compraSA.GetCuentasPorPagarStatusCount(New Business.Entity.documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .apruebaPago = StatusAprobacionPagos.Rechazado})
    '    Dim lista As New List(Of EstadoPagos)
    '    lista.Add(New EstadoPagos With {.Codigo = StatusAprobacionPagos.Pendiente, .Name = "Pendientes", .Valor = Pendientes})
    '    lista.Add(New EstadoPagos With {.Codigo = StatusAprobacionPagos.Aprobado, .Name = "Aprobados", .Valor = Aprobados})
    '    lista.Add(New EstadoPagos With {.Codigo = StatusAprobacionPagos.Rechazado, .Name = "Rechazados", .Valor = Rechazados})

    '    ListaNotificaciones = New List(Of EstadoPagos)
    '    ListaNotificaciones = lista
    'End Sub

    Public Sub GetComprasPorAprobar(status As String)
        Dim compraSA As New DocumentoCompraSA
        Dim dt As New DataTable()
        dt.Columns.Add("nrodoc")
        dt.Columns.Add("fechaVcto")
        dt.Columns.Add("importe")
        dt.Columns.Add("Proveedor")
        dt.Columns.Add("unidad")
        dt.Columns.Add("idDocumento")

        For Each i In compraSA.GetComprasPorAprobarPago(New Business.Entity.documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .apruebaPago = status})
            dt.Rows.Add(String.Format("{0}-{1}", i.serie, i.numeroDoc), i.fechaDoc, i.importeTotal, i.CustomEntidad.nombreCompleto, "UND", i.idDocumento)
        Next
        GridPendientes.DataSource = dt
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim r As Record = GridPendientes.Table.CurrentRecord
        If r IsNot Nothing Then
            AprobarFactura(Integer.Parse(r.GetValue("idDocumento")), r, StatusAprobacionPagos.Aprobado)
        Else
            MsgBox("Debe seleccionar una factura válida", MsgBoxStyle.Critical, "Seleccionar comprobante")
        End If
    End Sub

    Private Sub AprobarFactura(ID As Integer, r As Record, status As String)
        Dim compraSA As New DocumentoCompraSA
        compraSA.StatusApruebaPagoFactura(New documentocompra With {.idDocumento = ID, .idEmpresa = Gempresas.IdEmpresaRuc, .apruebaPago = status})
        r.Delete()
        '    GetAsync()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Dim r As Record = GridPendientes.Table.CurrentRecord
        If r IsNot Nothing Then
            AprobarFactura(Integer.Parse(r.GetValue("idDocumento")), r, StatusAprobacionPagos.Rechazado)
        Else
            MsgBox("Debe seleccionar una factura válida", MsgBoxStyle.Critical, "Seleccionar comprobante")
        End If
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click

    End Sub
End Class
