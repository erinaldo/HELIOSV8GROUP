Public Class UCFlujoCaja
#Region "Attributes"
    Private UCResumenVentas As UCResumenVentas
    Private UCFlujoCajaGeneral As UCFlujoCajaGeneral
    Private UCResumenVentasCustom As UCResumenVentasCustom
    Private UCRentabilidad As UCRentabilidad
    Private UCRankingVentas As UCRankingVentas
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UCResumenVentas = New UCResumenVentas With {.Dock = DockStyle.Fill, .Visible = True}
        UCFlujoCajaGeneral = New UCFlujoCajaGeneral With {.Dock = DockStyle.Fill, .Visible = False}
        UCResumenVentasCustom = New UCResumenVentasCustom With {.Dock = DockStyle.Fill, .Visible = False}
        UCRentabilidad = New UCRentabilidad With {.Dock = DockStyle.Fill, .Visible = False}
        UCRankingVentas = New UCRankingVentas With {.Dock = DockStyle.Fill, .Visible = False}

        PanelBody.Controls.Add(UCResumenVentas)
        PanelBody.Controls.Add(UCFlujoCajaGeneral)
        PanelBody.Controls.Add(UCResumenVentasCustom)
        PanelBody.Controls.Add(UCRentabilidad)
        PanelBody.Controls.Add(UCRankingVentas)
    End Sub

    Public Sub New(OpcionInicio As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Select Case OpcionInicio
            Case "Cierre cajero"
                BunifuFlatButton2.Visible = False
                BunifuFlatButton1.Visible = False
                BunifuFlatButton3.Visible = False

                UCResumenVentas = New UCResumenVentas With {.Dock = DockStyle.Fill, .Visible = True}
                PanelBody.Controls.Add(UCResumenVentas)

        End Select
    End Sub

    Private Sub BunifuFlatButton15_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton15.Click, BunifuFlatButton2.Click, BunifuFlatButton1.Click, BunifuFlatButton3.Click, BunifuFlatButton4.Click
        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width
        '  End If
        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        Select Case btn.Text
            Case "FLUJO DE CAJA: CAJERO"
                If UCRentabilidad Is Nothing Then Exit Sub
                If UCFlujoCajaGeneral Is Nothing Then Exit Sub
                If UCResumenVentasCustom Is Nothing Then Exit Sub
                If UCRankingVentas Is Nothing Then Exit Sub
                UCRentabilidad.Visible = False
                UCFlujoCajaGeneral.Visible = False
                UCResumenVentasCustom.Visible = False
                UCRankingVentas.Visible = False
                If UCResumenVentas IsNot Nothing Then
                    UCResumenVentas.Visible = True
                    UCResumenVentas.BringToFront()
                    UCResumenVentas.Show()
                End If
            Case "FLUJO DE CAJA: UNIDAD"
                UCRentabilidad.Visible = False
                UCFlujoCajaGeneral.GetEstablecimientos()
                UCResumenVentas.Visible = False
                UCResumenVentasCustom.Visible = False
                UCRankingVentas.Visible = False
                If UCFlujoCajaGeneral IsNot Nothing Then
                    UCFlujoCajaGeneral.ComboUnidad.Enabled = True
                    UCFlujoCajaGeneral.Visible = True
                    UCFlujoCajaGeneral.BringToFront()
                    UCFlujoCajaGeneral.Show()
                End If
            Case "VENTAS"
                UCRentabilidad.Visible = False
                UCResumenVentasCustom.GetCombos()
                UCResumenVentas.Visible = False
                UCFlujoCajaGeneral.Visible = False
                UCRankingVentas.Visible = False
                If UCResumenVentasCustom IsNot Nothing Then
                    UCResumenVentasCustom.ComboUnidad.Enabled = True
                    UCResumenVentasCustom.Visible = True
                    UCResumenVentasCustom.BringToFront()
                    UCResumenVentasCustom.Show()
                End If
            Case "RENTABILIDAD"
                UCResumenVentasCustom.Visible = False
                UCResumenVentas.Visible = False
                UCFlujoCajaGeneral.Visible = False
                UCRankingVentas.Visible = False
                If UCRentabilidad IsNot Nothing Then
                    UCRentabilidad.GetEstablecimientos()
                    UCRentabilidad.ComboUnidad.Enabled = True
                    UCRentabilidad.Visible = True
                    UCRentabilidad.BringToFront()
                    UCRentabilidad.Show()
                End If

            Case "RANKING"
                UCResumenVentasCustom.Visible = False
                UCResumenVentas.Visible = False
                UCFlujoCajaGeneral.Visible = False
                UCRentabilidad.Visible = False
                If UCRentabilidad IsNot Nothing Then
                    UCRankingVentas.Visible = True
                    UCRankingVentas.BringToFront()
                    UCRankingVentas.Show()
                End If
        End Select
    End Sub

#End Region

#Region "MEthods"

#End Region

#Region "Events"

#End Region
End Class
