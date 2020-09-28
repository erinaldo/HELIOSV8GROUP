Public Class FormConfiguracionRestaurant
#Region "Attributes"
    Public Property UCInfraestructuraSPK As FormInfraestructuraSPK
    Public Property UC_ComposicionRestaurante As UC_ComposicionRestaurante
    'Public Property UC_AreaOperativa As Tab_AreaOperativa
    'Public Property UCReportesLogistica As UCReportesLogistica
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UCInfraestructuraSPK = New FormInfraestructuraSPK() With {.Dock = DockStyle.Fill}
        UC_ComposicionRestaurante = New UC_ComposicionRestaurante With {.Dock = DockStyle.Fill}
        'UC_AreaOperativa = New Tab_AreaOperativa With {.Dock = DockStyle.Fill}
        'UCReportesLogistica = New UCReportesLogistica With {.Dock = DockStyle.Fill}

        PanelBody.Controls.Add(UCInfraestructuraSPK)
        PanelBody.Controls.Add(UC_ComposicionRestaurante)
        'PanelBody.Controls.Add(UC_AreaOperativa)
        'PanelBody.Controls.Add(UCReportesLogistica)
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

    Private Sub BunifuFlatButton15_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton15.Click, BunifuFlatButton16.Click, BunifuFlatButton1.Click, BunifuFlatButton4.Click
        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width
        '  End If
        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        Select Case btn.Text
            Case "INFRAESTRUCTURA"
                UC_ComposicionRestaurante.Visible = False
                'UC_AreaOperativa.Visible = False

                If UCInfraestructuraSPK IsNot Nothing Then
                    UCInfraestructuraSPK.Visible = True
                    UCInfraestructuraSPK.BringToFront()
                    UCInfraestructuraSPK.Show()
                End If
            Case "COMPOSICIÓN"
                UCInfraestructuraSPK.Visible = False
                'UC_AreaOperativa.Visible = False

                If UC_ComposicionRestaurante IsNot Nothing Then
                    UC_ComposicionRestaurante.Visible = True
                    UC_ComposicionRestaurante.BringToFront()
                    UC_ComposicionRestaurante.Show()
                End If
            Case "UNIDADES OPERATIVAS"
                UCInfraestructuraSPK.Visible = False
                UC_ComposicionRestaurante.Visible = False
                'If UC_AreaOperativa IsNot Nothing Then
                '    UC_AreaOperativa.Visible = True
                '    UC_AreaOperativa.BringToFront()
                '    UC_AreaOperativa.Show()
                'End If

                'Case "REPORTES"
                '    UCInfraestructuraSPK.Visible = False
                '    UC_ComposicionRestaurante.Visible = False
                '    UCProveedor.Visible = False
                '    If UCReportesLogistica IsNot Nothing Then
                '        UCReportesLogistica.UCReporteCompras.GetCombos()
                '        UCReportesLogistica.Visible = True
                '        UCReportesLogistica.BringToFront()
                '        UCReportesLogistica.Show()
                '    End If
        End Select
    End Sub


#End Region
End Class