Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes

Public Class FormConfiguracion

    Private TabRegistroVenta As TabCM_RegistroDatosGenerales

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        cargarDatos()
    End Sub

    Private Sub cargarDatos()

        PanelBody.Controls.Clear()
        TabRegistroVenta = New TabCM_RegistroDatosGenerales() With {
        .Dock = DockStyle.Fill}
        TabRegistroVenta.BringToFront()
        PanelBody.Controls.Add(TabRegistroVenta)
        'PanelRegistro.Visible = True
    End Sub

End Class
