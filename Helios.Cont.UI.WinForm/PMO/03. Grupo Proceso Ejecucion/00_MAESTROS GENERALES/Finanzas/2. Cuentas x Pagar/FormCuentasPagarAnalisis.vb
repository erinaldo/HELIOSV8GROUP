Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Public Class FormCuentasPagarAnalisis

#Region "Variables"
    Public Property TabFN_GetCuentasPagarOpcion As TabFN_GetCuentasPagarOpcion
    Public Property TabFN_GetCuentasPagarPeriodo As TabFN_GetCuentasPagarPeriodo
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GetStatusEscaneadas()
        GetPagosAnuales()
    End Sub
#End Region

#Region "Methods"
    Private Sub GetPagosAnuales()
        Dim compraSA As New DocumentoCompraSA
        Dim c = compraSA.GetAcumuladoCuentasPagarByAnio(New Business.Entity.documentocompra With
            {
            .idEmpresa = Gempresas.IdEmpresaRuc,
            .idCentroCosto = GEstableciento.IdEstablecimiento,
            .tipoCompra = TIPO_COMPRA.COMPRA,
            .fechaDoc = DateTime.Now,
            .monedaDoc = "1"
            })

        Dim t = c.importeTotal.GetValueOrDefault
        LabelPoPagar.Text = CDec(t).ToString("N2")
        LabelAbonados.Text = CDec(c.PagoSumaMN).ToString("N2")
        LabelSaldoPagos.Text = CDec(t - c.PagoSumaMN).ToString("N2")
    End Sub

    Public Sub GetStatusEscaneadas()

        Dim compraSA As New DocumentoCompraSA
        Dim statusList = compraSA.GetResumenAnualCuentasPagar(
            New Business.Entity.documentocompra With
            {
            .idEmpresa = Gempresas.IdEmpresaRuc,
            .idCentroCosto = GEstableciento.IdEstablecimiento,
            .tipoCompra = TIPO_COMPRA.COMPRA,
            .fechaDoc = DateTime.Now
            })

        Dim conteo1to30 = statusList.Where(Function(o) o.referenciaDestino = "0-30").Select(Function(o) o.conteoCuotas).FirstOrDefault

        Dim conteo31to60 = statusList.Where(Function(o) o.referenciaDestino = "31-60").Select(Function(o) o.conteoCuotas).FirstOrDefault

        Dim conteo61tomas = statusList.Where(Function(o) o.referenciaDestino = "61-mas").Select(Function(o) o.conteoCuotas).FirstOrDefault

        Tool30.Text = conteo1to30.GetValueOrDefault
        Tool60.Text = conteo31to60.GetValueOrDefault
        Tool61.Text = conteo61tomas.GetValueOrDefault

    End Sub

    Private Sub Tool30_Click(sender As Object, e As EventArgs) Handles Tool30.Click
        PanelBody.Controls.Clear()
        TabFN_GetCuentasPagarOpcion = New TabFN_GetCuentasPagarOpcion("0-30") With {
                        .Dock = DockStyle.Fill
        }
        TabFN_GetCuentasPagarOpcion.BringToFront()
        PanelBody.Controls.Add(TabFN_GetCuentasPagarOpcion)
    End Sub

    Private Sub Tool60_Click(sender As Object, e As EventArgs) Handles Tool60.Click
        PanelBody.Controls.Clear()
        TabFN_GetCuentasPagarOpcion = New TabFN_GetCuentasPagarOpcion("31-60") With {
                        .Dock = DockStyle.Fill
        }
        TabFN_GetCuentasPagarOpcion.BringToFront()
        PanelBody.Controls.Add(TabFN_GetCuentasPagarOpcion)
    End Sub

    Private Sub Tool61_Click(sender As Object, e As EventArgs) Handles Tool61.Click
        PanelBody.Controls.Clear()
        TabFN_GetCuentasPagarOpcion = New TabFN_GetCuentasPagarOpcion("61+mas") With {
                        .Dock = DockStyle.Fill
        }
        TabFN_GetCuentasPagarOpcion.BringToFront()
        PanelBody.Controls.Add(TabFN_GetCuentasPagarOpcion)
    End Sub

    Private Sub FormCuentasPagarAnalisis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim boundWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim boundHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        Dim x As Integer = boundWidth - Me.Width
        Dim y As Integer = boundHeight - Me.Height
        Me.Location = New Point(x \ 2, y \ 2)
        Me.CaptionLabels(0).Text = "Cuentas por pagar: " & DateTime.Now.Year
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        PanelBody.Controls.Clear()
        TabFN_GetCuentasPagarPeriodo = New TabFN_GetCuentasPagarPeriodo() With {
                        .Dock = DockStyle.Fill
        }
        TabFN_GetCuentasPagarPeriodo.BringToFront()
        PanelBody.Controls.Add(TabFN_GetCuentasPagarPeriodo)
    End Sub
#End Region

#Region "Events"

#End Region

End Class