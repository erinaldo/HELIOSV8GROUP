Imports Helios.General
Public Class FormInventarioEscaso

    Public FormInventarioEscaso As ucInventarioMinimo

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormInventarioEscaso = New ucInventarioMinimo With {.Dock = DockStyle.Fill, .Visible = True}
        PanelBody.Controls.Add(FormInventarioEscaso)
        Centrar(Me)
    End Sub
End Class