Public Class FormTipoBusqueda


#Region "Variables"

    Public Property UCEstructuraCabeceraVenta As UCEstructuraCabeceraVentaV2
    Public Property UCBusquedaLoteDet As UCBusquedaLoteDet
    Public Property UCBusquedaSegmento As UCBusquedaSegmento
#End Region

#Region "Constructor"

    Sub New(ucVenta As UCEstructuraCabeceraVentaV2)

        ' This call is required by the designer.
        InitializeComponent()
        UCEstructuraCabeceraVenta = ucVenta
        UCBusquedaLoteDet = New UCBusquedaLoteDet(UCEstructuraCabeceraVenta)
        'UCBusquedaSegmento = New UCBusquedaSegmento(UCEstructuraCabeceraVenta)
        UCBusquedaSegmento = New UCBusquedaSegmento(UCEstructuraCabeceraVenta) With {.Dock = DockStyle.Fill, .Visible = False}
        PanelBody.Controls.Add(UCBusquedaLoteDet)
        PanelBody.Controls.Add(UCBusquedaSegmento)
        ' Add any initialization after the InitializeComponent() call.
    End Sub

#End Region

#Region "Metodos"


#End Region

    Private Sub FormTipoBusqueda_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width

        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)

        Select Case btn.Text
            Case "DETALLE LOTE"


                UCBusquedaSegmento.Visible = False
                If UCBusquedaLoteDet IsNot Nothing Then
                    UCBusquedaLoteDet.Visible = True
                    UCBusquedaLoteDet.BringToFront()
                    UCBusquedaLoteDet.Show()
                    'btOperacion.ButtonText = "Grabar"
                End If
            Case "POR SEGMENTO"
                UCBusquedaLoteDet.Visible = False
                If UCBusquedaSegmento IsNot Nothing Then
                    UCBusquedaSegmento.Visible = True
                    UCBusquedaSegmento.BringToFront()
                    UCBusquedaSegmento.Show()
                    'btOperacion.ButtonText = "Grabar"
                End If


        End Select
    End Sub

    Private Sub BunifuFlatButton15_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton15.Click
        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width

        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)

        Select Case btn.Text
            Case "DETALLE LOTE"


                UCBusquedaSegmento.Visible = False
                If UCBusquedaLoteDet IsNot Nothing Then
                    UCBusquedaLoteDet.Visible = True
                    UCBusquedaLoteDet.BringToFront()
                    UCBusquedaLoteDet.Show()
                    'btOperacion.ButtonText = "Grabar"
                End If
            Case "POR SEGMENTO"
                UCBusquedaLoteDet.Visible = False
                If UCBusquedaSegmento IsNot Nothing Then
                    UCBusquedaSegmento.Visible = True
                    UCBusquedaSegmento.BringToFront()
                    UCBusquedaSegmento.Show()
                    'btOperacion.ButtonText = "Grabar"
                End If


        End Select
    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click

    End Sub
End Class