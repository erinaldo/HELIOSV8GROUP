Public Class UCControlFinanzas

#Region "Attributes"
    Public UCCuentasXpagar As UCCuentasXpagar
    Public UCCuentasXcobrar As UCCuentasXcobrar
    'Public UCRegistroOtrosMovimientos As UCRegistroOtrosMovimientos
    'Public UCMovimientos As UCMovimientos
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UCCuentasXpagar = New UCCuentasXpagar With {.Dock = DockStyle.Fill, .Visible = True}
        UCCuentasXcobrar = New UCCuentasXcobrar With {.Dock = DockStyle.Fill, .Visible = False}
        PanelBody.Controls.Add(UCCuentasXpagar)
        PanelBody.Controls.Add(UCCuentasXcobrar)
    End Sub

#End Region

#Region "Methods"

#End Region

#Region "Events"
    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click, BunifuFlatButton6.Click, BunifuFlatButton5.Click, BunifuFlatButton3.Click, BunifuFlatButton1.Click
        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width
        '  End If
        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        Select Case btn.Text
            Case "Cuentas x pagar"
                UCCuentasXcobrar.Visible = False
                'UCMovimientos.Visible = False
                If UCCuentasXpagar IsNot Nothing Then
                    UCCuentasXpagar.Visible = True
                    UCCuentasXpagar.BringToFront()
                    UCCuentasXpagar.Show()
                End If

            Case "Cuentas x cobrar"
                UCCuentasXpagar.Visible = False
                'UCMovimientos.Visible = False
                If UCCuentasXcobrar IsNot Nothing Then
                    UCCuentasXcobrar.Visible = True
                    UCCuentasXcobrar.BringToFront()
                    UCCuentasXcobrar.Show()
                End If
            Case "Prestamos"


            Case "Anticipos"

            Case "Reclamaciones"

        End Select
    End Sub
#End Region


End Class
