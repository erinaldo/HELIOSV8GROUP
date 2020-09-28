Public Class FormProductosTransito
    Public Property UCEntregaDeMercaderiaLogistica As UCEntregaDeMercaderiaLogistica

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UCEntregaDeMercaderiaLogistica = New UCEntregaDeMercaderiaLogistica With
        {
        .Dock = DockStyle.Fill,
        .Visible = True
        }
    End Sub

End Class