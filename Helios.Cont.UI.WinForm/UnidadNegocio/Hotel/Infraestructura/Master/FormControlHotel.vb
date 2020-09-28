Imports System.ComponentModel

Public Class FormControlHotel
#Region "Attributes"
    Public Property TabP_IdentificacionCliente As TabP_IdentificacionCliente
    Public TabRC_RecepcionPersona As TabRC_RecepcionPersona
    Public TabCT_ControlXCliente As TabCT_ControlXCliente
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        TabP_IdentificacionCliente = New TabP_IdentificacionCliente(Me) With {.Dock = DockStyle.Fill}
        PanelBody.Controls.Add(TabP_IdentificacionCliente)

        TabRC_RecepcionPersona = New TabRC_RecepcionPersona(Me) With {.Dock = DockStyle.Fill}
        PanelBody.Controls.Add(TabRC_RecepcionPersona)

        TabCT_ControlXCliente = New TabCT_ControlXCliente(Me) With {.Dock = DockStyle.Fill}
        PanelBody.Controls.Add(TabCT_ControlXCliente)

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