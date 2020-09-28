Public Class FormRepositoryLogistica
#Region "Attributes"
    Public Property UCLogisticaCompra As UCLogisticaCompra
    Public Property UCLogisticaAlmacen As UCLogisticaAlmacen
    Public Property UCProveedor As UCProveedor
    Public Property UCReportesLogistica As UCReportesLogistica
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UCLogisticaCompra = New UCLogisticaCompra(Me) With {.Dock = DockStyle.Fill}
        UCLogisticaAlmacen = New UCLogisticaAlmacen With {.Dock = DockStyle.Fill}
        UCProveedor = New UCProveedor With {.Dock = DockStyle.Fill}
        UCReportesLogistica = New UCReportesLogistica With {.Dock = DockStyle.Fill}

        PanelBody.Controls.Add(UCLogisticaCompra)
        PanelBody.Controls.Add(UCLogisticaAlmacen)
        PanelBody.Controls.Add(UCProveedor)
        PanelBody.Controls.Add(UCReportesLogistica)
        BunifuFlatButton4.Enabled = True
    End Sub

#End Region

#Region "Methods"

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

    Private Sub BunifuFlatButton15_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton15.Click, BunifuFlatButton3.Click, BunifuFlatButton2.Click, BunifuFlatButton16.Click, BunifuFlatButton1.Click, BunifuFlatButton4.Click
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
                UCLogisticaCompra.Visible = False
                UCProveedor.Visible = False
                UCReportesLogistica.Visible = False
                If UCLogisticaAlmacen IsNot Nothing Then
                    UCLogisticaAlmacen.Visible = True
                    UCLogisticaAlmacen.BringToFront()
                    UCLogisticaAlmacen.ThreadTransito()
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