Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Public Class FormCuentasCobrarAnalisis
#Region "Variables"
    Public Property TabFN_GetCuentasCobrarOpcion As TabFN_GetCuentasCobrarOpcion
    Public Property TabFN_GetCuentasCobrarPeriodo As TabFN_GetCuentasCobrarPeriodo
    '   Public Property TabFN_GetCuentasPagarPeriodo As TabFN_GetCuentasPagarPeriodo
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
        Dim compraSA As New documentoVentaAbarrotesSA
        Dim c = compraSA.GetAcumuladoCuentasCobrarByAnio(New Business.Entity.documentoventaAbarrotes With
            {
            .idEmpresa = Gempresas.IdEmpresaRuc,
            .idEstablecimiento = GEstableciento.IdEstablecimiento,
            .tipoVenta = TIPO_VENTA.VENTA_GENERAL,
            .fechaDoc = DateTime.Now,
            .moneda = "1"
            })

        Dim t = c.ImporteNacional.GetValueOrDefault
        LabelPoPagar.Text = CDec(t).ToString("N2")
        LabelAbonados.Text = CDec(c.PagoSumaMN).ToString("N2")
        LabelSaldoPagos.Text = CDec(t - c.PagoSumaMN).ToString("N2")
    End Sub

    Public Sub GetStatusEscaneadas()

        Dim compraSA As New documentoVentaAbarrotesSA
        Dim statusList = compraSA.GetResumenAnualCuentasCobrar(
            New Business.Entity.documentoventaAbarrotes With
            {
            .idEmpresa = Gempresas.IdEmpresaRuc,
            .idEstablecimiento = GEstableciento.IdEstablecimiento,
            .fechaDoc = DateTime.Now
            })

        Dim conteo1to30 = statusList.Where(Function(o) o.estado = "0-30").Select(Function(o) o.conteoCuotas).FirstOrDefault

        Dim conteo31to60 = statusList.Where(Function(o) o.estado = "31-60").Select(Function(o) o.conteoCuotas).FirstOrDefault

        Dim conteo61tomas = statusList.Where(Function(o) o.estado = "61-mas").Select(Function(o) o.conteoCuotas).FirstOrDefault

        Tool30.Text = conteo1to30.GetValueOrDefault
        Tool60.Text = conteo31to60.GetValueOrDefault
        Tool61.Text = conteo61tomas.GetValueOrDefault

        Dim statusListVenc = compraSA.GetResumenAnualCuentasVenc(
            New Business.Entity.documentoventaAbarrotes With
            {
            .idEmpresa = Gempresas.IdEmpresaRuc,
            .idEstablecimiento = GEstableciento.IdEstablecimiento,
            .fechaDoc = DateTime.Now
            })

        Dim conteo1to30VEN = statusListVenc.Where(Function(o) o.estado = "0-30").Select(Function(o) o.conteoCuotas).FirstOrDefault

        Dim conteo31to60VEN = statusListVenc.Where(Function(o) o.estado = "31-60").Select(Function(o) o.conteoCuotas).FirstOrDefault

        Dim conteo61tomasVEN = statusListVenc.Where(Function(o) o.estado = "61-mas").Select(Function(o) o.conteoCuotas).FirstOrDefault


        ToolVen30.Text = conteo1to30.GetValueOrDefault
        ToolVen60.Text = conteo31to60.GetValueOrDefault
        ToolVen60.Text = conteo61tomas.GetValueOrDefault

    End Sub

    Private Sub Tool30_Click(sender As Object, e As EventArgs) Handles Tool30.Click
        PanelBody.Controls.Clear()
        TabFN_GetCuentasCobrarOpcion = New TabFN_GetCuentasCobrarOpcion("0-30") With {
                        .Dock = DockStyle.Fill
        }
        TabFN_GetCuentasCobrarOpcion.BringToFront()
        PanelBody.Controls.Add(TabFN_GetCuentasCobrarOpcion)
    End Sub

    Private Sub Tool60_Click(sender As Object, e As EventArgs) Handles Tool60.Click
        PanelBody.Controls.Clear()
        TabFN_GetCuentasCobrarOpcion = New TabFN_GetCuentasCobrarOpcion("31-60") With {
                        .Dock = DockStyle.Fill
        }
        TabFN_GetCuentasCobrarOpcion.BringToFront()
        PanelBody.Controls.Add(TabFN_GetCuentasCobrarOpcion)
    End Sub

    Private Sub Tool61_Click(sender As Object, e As EventArgs) Handles Tool61.Click
        PanelBody.Controls.Clear()
        TabFN_GetCuentasCobrarOpcion = New TabFN_GetCuentasCobrarOpcion("61+mas") With {
                        .Dock = DockStyle.Fill
        }
        TabFN_GetCuentasCobrarOpcion.BringToFront()
        PanelBody.Controls.Add(TabFN_GetCuentasCobrarOpcion)
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
        TabFN_GetCuentasCobrarPeriodo = New TabFN_GetCuentasCobrarPeriodo() With {
                        .Dock = DockStyle.Fill
        }
        TabFN_GetCuentasCobrarPeriodo.BringToFront()
        PanelBody.Controls.Add(TabFN_GetCuentasCobrarPeriodo)
    End Sub

    Private Sub ToolVen30_Click(sender As Object, e As EventArgs) Handles ToolVen30.Click
        PanelBody.Controls.Clear()
        TabFN_GetCuentasCobrarOpcion = New TabFN_GetCuentasCobrarOpcion("0-30V") With {
                        .Dock = DockStyle.Fill
        }
        TabFN_GetCuentasCobrarOpcion.BringToFront()
        PanelBody.Controls.Add(TabFN_GetCuentasCobrarOpcion)
    End Sub

    Private Sub ToolVen60_Click(sender As Object, e As EventArgs) Handles ToolVen60.Click
        PanelBody.Controls.Clear()
        TabFN_GetCuentasCobrarOpcion = New TabFN_GetCuentasCobrarOpcion("31-60V") With {
                        .Dock = DockStyle.Fill
        }
        TabFN_GetCuentasCobrarOpcion.BringToFront()
        PanelBody.Controls.Add(TabFN_GetCuentasCobrarOpcion)
    End Sub

    Private Sub ToolVen90_Click(sender As Object, e As EventArgs) Handles ToolVen90.Click
        PanelBody.Controls.Clear()
        TabFN_GetCuentasCobrarOpcion = New TabFN_GetCuentasCobrarOpcion("61+masV") With {
                        .Dock = DockStyle.Fill
        }
        TabFN_GetCuentasCobrarOpcion.BringToFront()
        PanelBody.Controls.Add(TabFN_GetCuentasCobrarOpcion)
    End Sub
#End Region

#Region "Events"

#End Region
End Class