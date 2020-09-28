

Public Class UCPrincipalCajaPos


#Region "Atributos"
    Private UCSubCajaAdmiPos As UCSubCajaAdmiPos

#End Region

#Region "Constructor"

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UCSubCajaAdmiPos = New UCSubCajaAdmiPos With {.Dock = DockStyle.Fill, .Visible = True}
        PanelBody.Controls.Add(UCSubCajaAdmiPos)
    End Sub

    Private Sub btnCajaCentral_Click(sender As Object, e As EventArgs) Handles btnCajaCentral.Click

    End Sub

#End Region

#Region "Metodos"


#End Region



End Class
