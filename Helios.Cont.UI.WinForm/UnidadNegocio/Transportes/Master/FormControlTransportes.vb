Imports System.ComponentModel

Public Class FormControlTransportes
#Region "Attributes"
    Public Property TabTR_PasajeVenta As TabTR_PasajeVenta
    Public TabTR_IdentificacionRuta As TabTR_IdentificacionRuta
    Public Property FormMeaestroRutas As UCMaestroRutas
    Public Property UCPantallaEmbarque As UCPantallaEmbarque

#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call.

        'TabTR_IdentificacionRuta = New TabTR_IdentificacionRuta(Me) With {.Dock = DockStyle.Fill}
        'PanelBody.Controls.Add(TabTR_IdentificacionRuta)

        'TabTR_PasajeVenta = New TabTR_PasajeVenta(Me) With {.Dock = DockStyle.Fill}
        'PanelBody.Controls.Add(TabTR_PasajeVenta)

        'FormMeaestroRutas = New FormMeaestroRutas(Me) With {.Dock = DockStyle.Fill}
        'PanelBody.Controls.Add(FormMeaestroRutas)

        'UCPantallaEmbarque = New UCPantallaEmbarque(Me) With {.Dock = DockStyle.Fill}
        'PanelBody.Controls.Add(UCPantallaEmbarque)

        ''Dim objFormResizer As New FormControlTransportes
        ''objFormResizer.ResizeForm(Me, 864, 1152)

    End Sub

#End Region

    Private Sub BunifuImageButton2_Click(sender As Object, e As EventArgs) Handles bunifuImageButton2.Click
        Close()
    End Sub

    Private Sub FormRepositoryPiscina_Load(sender As Object, e As EventArgs) Handles Me.Load
        General.Centrar(Me)
    End Sub

    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs) Handles BunifuImageButton1.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class