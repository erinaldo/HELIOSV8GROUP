Public Class ComisionMaster

    Private UCComision As UCComision
    Private UCRegistroComision As UCRegistroComision
    Private UCComisionDesembolso As UCComisionDesembolso
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UCComision = New UCComision With {.Dock = DockStyle.Fill, .Visible = True}
        UCRegistroComision = New UCRegistroComision With {.Dock = DockStyle.Fill, .Visible = False}
        UCComisionDesembolso = New UCComisionDesembolso With {.Dock = DockStyle.Fill, .Visible = False}

        PanelBody.Controls.Add(UCComision)
        PanelBody.Controls.Add(UCRegistroComision)
        PanelBody.Controls.Add(UCComisionDesembolso)
    End Sub

    Private Sub ComisionMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        General.Centrar(Me)
    End Sub

    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs) Handles BunifuImageButton1.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub BunifuImageButton2_Click(sender As Object, e As EventArgs) Handles bunifuImageButton2.Click
        Me.Close()
    End Sub

    Private Sub BunifuFlatButton15_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton15.Click, BunifuFlatButton9.Click, BunifuFlatButton8.Click, BunifuFlatButton16.Click, BunifuFlatButton11.Click, BunifuFlatButton10.Click, BunifuFlatButton1.Click
        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width
        '  End If
        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        Select Case btn.Text
            Case "PRINCIPAL"
                UCComisionDesembolso.Visible = False
                UCRegistroComision.Visible = False
                UCComision.Visible = True

            Case "COMISIONES"
                UCComisionDesembolso.Visible = False
                UCRegistroComision.Visible = True
                UCComision.Visible = False

            Case "PAGOS AUTORIZADOS"
                UCComisionDesembolso.Visible = True
                UCRegistroComision.Visible = False
                UCComision.Visible = False
        End Select
    End Sub
End Class