Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General

Public Class FormMantenimientoComprasRapidas

#Region "Varables"
    Dim compraSA As New DocumentoCompraSA
    Public Property TabLG_Recientes As TabLG_Recientes
    Public Property TabLG_PendienteCR As TabLG_PendienteCR
    Public Property TabLG_RechazadosCR As TabLG_RechazadosCR
    Public Property TabLG_Escaneadas As TabLG_Escaneadas
    Public Property TabLG_CRapidaPeriodo As TabLG_CRapidaPeriodo
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.WindowState = FormWindowState.Maximized
        GetStatus()
        GetStatusEscaneadas()
        Inicio24Conteo()
    End Sub

#End Region

#Region "Methods"
    Sub Inicio24Conteo()
        ToolStripButton10.Text = "24 horas"
        Dim conteos = compraSA.GetContadorCRapidaRecientes(
            New documentocompra With
            {
            .tipoOperacion = "24 horas",
            .idEmpresa = General.Gempresas.IdEmpresaRuc,
            .idCentroCosto = General.GEstableciento.IdEstablecimiento,
            .tipoCompra = General.TIPO_COMPRA.NOTA_DE_COMPRA_EN_ESPERA,
            .fechaDoc = DateTime.Now
            })
        ToolRecientes.Text = conteos
    End Sub

    Sub GetConteoVenta()

        Select Case ToolStripButton10.Text
            Case "24 horas"
                ToolStripButton10.Text = "2 días"
                Dim conteos = compraSA.GetContadorCRapidaRecientes(
                    New documentocompra With
                    {
                    .tipoOperacion = "2 días",
                    .idEmpresa = General.Gempresas.IdEmpresaRuc,
                    .idCentroCosto = General.GEstableciento.IdEstablecimiento,
                    .tipoCompra = General.TIPO_COMPRA.NOTA_DE_COMPRA_EN_ESPERA,
                    .fechaDoc = DateTime.Now})

                ToolRecientes.Text = conteos

            Case "2 días"
                ToolStripButton10.Text = "3 días"
                Dim conteos = compraSA.GetContadorCRapidaRecientes(
                    New documentocompra With
                    {
                    .tipoOperacion = "3 días",
                    .idEmpresa = General.Gempresas.IdEmpresaRuc,
                    .idCentroCosto = General.GEstableciento.IdEstablecimiento,
                    .tipoCompra = General.TIPO_COMPRA.NOTA_DE_COMPRA_EN_ESPERA,
                    .fechaDoc = DateTime.Now})

                ToolRecientes.Text = conteos

            Case "3 días"
                ToolStripButton10.Text = "5 días"

                Dim conteos = compraSA.GetContadorCRapidaRecientes(
                    New documentocompra With
                    {
                    .tipoOperacion = "5 días",
                    .idEmpresa = General.Gempresas.IdEmpresaRuc,
                    .idCentroCosto = General.GEstableciento.IdEstablecimiento,
                    .tipoCompra = General.TIPO_COMPRA.NOTA_DE_COMPRA_EN_ESPERA,
                    .fechaDoc = DateTime.Now})

                ToolRecientes.Text = conteos


            Case "5 días"
                ToolStripButton10.Text = "7 días"

                Dim conteos = compraSA.GetContadorCRapidaRecientes(
                    New documentocompra With
                    {
                    .tipoOperacion = "7 días",
                    .idEmpresa = General.Gempresas.IdEmpresaRuc,
                    .idCentroCosto = General.GEstableciento.IdEstablecimiento,
                    .tipoCompra = General.TIPO_COMPRA.NOTA_DE_COMPRA_EN_ESPERA,
                    .fechaDoc = DateTime.Now})

                ToolRecientes.Text = conteos


            Case "7 días"
                ToolStripButton10.Text = "24 horas"

                Dim conteos = compraSA.GetContadorCRapidaRecientes(
                    New documentocompra With
                    {
                    .tipoOperacion = "24 horas",
                    .idEmpresa = General.Gempresas.IdEmpresaRuc,
                    .idCentroCosto = General.GEstableciento.IdEstablecimiento,
                    .tipoCompra = General.TIPO_COMPRA.NOTA_DE_COMPRA_EN_ESPERA,
                    .fechaDoc = DateTime.Now})
                ToolRecientes.Text = conteos
        End Select
    End Sub

    Public Sub GetStatus()
        Dim compraSA As New DocumentoCompraSA
        Dim statusList = compraSA.GetStatusAprobacion(
            New Business.Entity.documentocompra With
            {
            .idEmpresa = Gempresas.IdEmpresaRuc,
            .idCentroCosto = GEstableciento.IdEstablecimiento,
            .tipoCompra = TIPO_COMPRA.NOTA_DE_COMPRA_EN_ESPERA
            })

        Dim conteoPendientes = statusList.Where(Function(o) o.aprobado = "N").Select(Function(o) o.conteoCuotas).FirstOrDefault

        Dim conteoOtros = statusList.Where(Function(o) o.aprobado = "O").Select(Function(o) o.conteoCuotas).FirstOrDefault

        Dim conteoRechazados = statusList.Where(Function(o) o.aprobado = "R").Select(Function(o) o.conteoCuotas).FirstOrDefault


        ToolConteoPendientes.Text = conteoPendientes.GetValueOrDefault
        ToolConteoOtros.Text = conteoOtros.GetValueOrDefault
        ToolConteoRechazo.Text = conteoRechazados.GetValueOrDefault

    End Sub

    Public Sub GetStatusEscaneadas()

        Dim compraSA As New DocumentoCompraSA
        Dim statusList = compraSA.GetEscaneadasCRapidas(
            New Business.Entity.documentocompra With
            {
            .idEmpresa = Gempresas.IdEmpresaRuc,
            .idCentroCosto = GEstableciento.IdEstablecimiento,
            .tipoCompra = TIPO_COMPRA.NOTA_DE_COMPRA_EN_ESPERA
            })

        Dim conteo1to30 = statusList.Where(Function(o) o.referenciaDestino = "0-30").Select(Function(o) o.conteoCuotas).FirstOrDefault

        Dim conteo31to60 = statusList.Where(Function(o) o.referenciaDestino = "31-60").Select(Function(o) o.conteoCuotas).FirstOrDefault

        Dim conteo61tomas = statusList.Where(Function(o) o.referenciaDestino = "61-mas").Select(Function(o) o.conteoCuotas).FirstOrDefault

        Tool30.Text = conteo1to30.GetValueOrDefault
        Tool60.Text = conteo31to60.GetValueOrDefault
        Tool61.Text = conteo61tomas.GetValueOrDefault

    End Sub

    Private Sub GetListAprobacion(status As String)
        PanelBody.Controls.Clear()

        Select Case status
            Case "N"
                TabLG_PendienteCR = New TabLG_PendienteCR(Me) With {
                    .Dock = DockStyle.Fill
                }
                TabLG_PendienteCR.BringToFront()
                PanelBody.Controls.Add(TabLG_PendienteCR)
            Case "R"
                TabLG_RechazadosCR = New TabLG_RechazadosCR(Me) With {
                    .Dock = DockStyle.Fill
                }
                TabLG_RechazadosCR.BringToFront()
                PanelBody.Controls.Add(TabLG_RechazadosCR)
            Case Else

        End Select
    End Sub
#End Region

#Region "Events"
    Private Sub ToolConteoPendientes_Click(sender As Object, e As EventArgs) Handles ToolConteoPendientes.Click, ToolStripButton19.Click
        GetListAprobacion("N")
    End Sub

    Private Sub ToolConteoRechazo_Click(sender As Object, e As EventArgs) Handles ToolConteoRechazo.Click
        GetListAprobacion("R")
    End Sub

    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs) Handles ToolStripButton10.Click
        Try
            GetConteoVenta()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub ToolRecientes_Click(sender As Object, e As EventArgs) Handles ToolRecientes.Click
        PanelBody.Controls.Clear()
        TabLG_Recientes = New TabLG_Recientes(Me, ToolStripButton10.Text) With {
            .Dock = DockStyle.Fill
        }
        TabLG_Recientes.BringToFront()
        PanelBody.Controls.Add(TabLG_Recientes)
    End Sub

    Private Sub Tool30_Click(sender As Object, e As EventArgs) Handles Tool30.Click
        PanelBody.Controls.Clear()
        TabLG_Escaneadas = New TabLG_Escaneadas(Me, "30") With {
                        .Dock = DockStyle.Fill
        }
        TabLG_Escaneadas.BringToFront()
        PanelBody.Controls.Add(TabLG_Escaneadas)
    End Sub

    Private Sub Tool60_Click(sender As Object, e As EventArgs) Handles Tool60.Click
        PanelBody.Controls.Clear()
        TabLG_Escaneadas = New TabLG_Escaneadas(Me, "60") With {
            .Dock = DockStyle.Fill
        }
        TabLG_Escaneadas.BringToFront()
        PanelBody.Controls.Add(TabLG_Escaneadas)
    End Sub

    Private Sub Tool61_Click(sender As Object, e As EventArgs) Handles Tool61.Click
        PanelBody.Controls.Clear()
        TabLG_Escaneadas = New TabLG_Escaneadas(Me, "61") With {
            .Dock = DockStyle.Fill
        }
        TabLG_Escaneadas.BringToFront()
        PanelBody.Controls.Add(TabLG_Escaneadas)
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        PanelBody.Controls.Clear()
        TabLG_CRapidaPeriodo = New TabLG_CRapidaPeriodo() With {
            .Dock = DockStyle.Fill
        }
        TabLG_CRapidaPeriodo.BringToFront()
        PanelBody.Controls.Add(TabLG_CRapidaPeriodo)
    End Sub
#End Region


End Class