Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes

Public Class FormRepositoryLogisticaApoyo
#Region "Attributes"
    Public Property UCLogisticaCompra As UCLogisticaCompraXEmpresa
    Public Property UCLogisticaAlmacen As UCLogisticaAlmacenXEmpresa
    Public Property UCProveedor As UCProveedorXEmpresa
    Public Property UCReportesLogistica As UCReportesLogistica
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ListarUnidOrganicas()

        UCLogisticaCompra = New UCLogisticaCompraXEmpresa(Me) With {.Dock = DockStyle.Fill}
        UCLogisticaAlmacen = New UCLogisticaAlmacenXEmpresa With {.Dock = DockStyle.Fill}
        UCProveedor = New UCProveedorXEmpresa With {.Dock = DockStyle.Fill}
        UCReportesLogistica = New UCReportesLogistica With {.Dock = DockStyle.Fill}

        PanelBody.Controls.Add(UCLogisticaCompra)
        PanelBody.Controls.Add(UCLogisticaAlmacen)
        PanelBody.Controls.Add(UCProveedor)
        PanelBody.Controls.Add(UCReportesLogistica)

        BunifuFlatButton4.Enabled = True

    End Sub

#End Region

#Region "Methods"
    Public Sub ListarUnidOrganicas()
        Try
            Dim sa As New CentrocostosSA

            Dim centroCostosBE As New centrocosto

            centroCostosBE.idCentroCosto = 0
            centroCostosBE.nombre = "TODO"
            centroCostosBE.TipoEstab = "UN"

            ListaUnidadOrganica = New List(Of centrocosto)
            ListaUnidadOrganica.Add(centroCostosBE)

            ListaUnidadOrganica.AddRange(sa.GetObtenerEstablecimiento(Gempresas.IdEmpresaRuc).Where(Function(o) o.TipoEstab = "UN").ToList)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region

#Region "Events"
    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs) Handles BunifuImageButton1.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub bunifuImageButton2_Click(sender As Object, e As EventArgs) Handles bunifuImageButton2.Click
        Me.Close()
    End Sub

    Private Sub BunifuFlatButton16_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BunifuFlatButton15_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton15.Click, BunifuFlatButton16.Click, BunifuFlatButton1.Click, BunifuFlatButton4.Click
        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width
        '  End If
        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        Select Case btn.Text
            Case "OPERACIONES"
                UCLogisticaAlmacen.Visible = False
                UCProveedor.Visible = False
                UCReportesLogistica.Visible = False
                If UCLogisticaCompra IsNot Nothing Then
                    UCLogisticaCompra.Visible = True
                    UCLogisticaCompra.BringToFront()
                    UCLogisticaCompra.Show()
                End If
            Case "ALMACEN"
                'UCLogisticaCompra.Visible = False
                'UCProveedor.Visible = False
                'UCReportesLogistica.Visible = False
                If UCLogisticaAlmacen IsNot Nothing Then
                    UCLogisticaAlmacen.Visible = True
                    UCLogisticaAlmacen.BringToFront()
                    UCLogisticaAlmacen.Show()
                End If
            Case "PROVEEDOR"
                UCLogisticaCompra.Visible = False
                UCLogisticaAlmacen.Visible = False
                UCReportesLogistica.Visible = False
                If UCProveedor IsNot Nothing Then
                    UCProveedor.Visible = True
                    UCProveedor.BringToFront()
                    UCProveedor.Show()
                End If

            Case "REPORTES"
                UCLogisticaCompra.Visible = False
                UCLogisticaAlmacen.Visible = False
                UCProveedor.Visible = False
                If UCReportesLogistica IsNot Nothing Then
                    UCReportesLogistica.UCReporteCompras.GetCombos()
                    UCReportesLogistica.Visible = True
                    UCReportesLogistica.BringToFront()
                    UCReportesLogistica.Show()
                End If
        End Select
    End Sub


#End Region
End Class