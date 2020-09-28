Public Class FormRepositoryRRHHApoyo

#Region "Attributes"
    Public UCCargos As UCCargos


#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'BtPagos.Visible = False
        '  BunifuFlatButton3.Visible = False
        UCCargos = New UCCargos With {.Dock = DockStyle.Fill}

        PanelBody.Controls.Add(UCCargos)

    End Sub
#End Region

#Region "Methods"

#End Region

#Region "Events"
    Private Sub BunifuFlatButton15_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton15.Click, BunifuFlatButton4.Click, BunifuFlatButton16.Click
        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width
        '  End If
        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        Select Case btn.Text
            Case "CARGOS"

                If UCCargos IsNot Nothing Then
                    UCCargos.Visible = True
                    UCCargos.BringToFront()
                    UCCargos.Show()
                End If
            Case "COLABORADORES"

            Case "REPORTES"

        End Select
    End Sub

    Private Sub bunifuImageButton2_Click(sender As Object, e As EventArgs) Handles bunifuImageButton2.Click
        Close()
    End Sub

    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs) Handles BunifuImageButton1.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

#End Region


End Class