Imports System.ComponentModel
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms

Public Class FormControlTransporteVer2
    'Public Property TabTR_PasajeVenta As TabTR_PasajeVenta
    'Private Property FormControlTransportes As FormControlTransportes

    Public Property TabTR_PasajeVenta As TabTR_PasajeVenta
    Public Property TabTR_IdentificacionRuta As TabTR_IdentificacionRuta
    Public Property FormMeaestroRutas As UCMaestroRutas
    Public Property UCPantallaEmbarque As UCPantallaEmbarque

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'TabTR_PasajeVenta = New TabTR_PasajeVenta(Me) With {.Dock = DockStyle.Fill}
        'Panel1.Controls.Add(TabTR_PasajeVenta)
        'lblNombreEmpresa.Text = Gempresas.NomEmpresa

        TabTR_IdentificacionRuta = New TabTR_IdentificacionRuta(Me) With {.Dock = DockStyle.Fill}
        PanelBody.Controls.Add(TabTR_IdentificacionRuta)

        TabTR_PasajeVenta = New TabTR_PasajeVenta(Me) With {.Dock = DockStyle.Fill}
        PanelBody.Controls.Add(TabTR_PasajeVenta)

        'FormMeaestroRutas = New UCMaestroRutas(Me) With {.Dock = DockStyle.Fill}
        'PanelBody.Controls.Add(FormMeaestroRutas)

        UCPantallaEmbarque = New UCPantallaEmbarque(Me) With {.Dock = DockStyle.Fill}
        PanelBody.Controls.Add(UCPantallaEmbarque)

    End Sub

#Region "Constructor"

    Public Sub AlertasPSE()
        Dim documentosa As New DocumentoventaTransporteSA

        'Dim consulta = documentosa.AlertaPSETrasporte(Gempresas.IdEmpresaRuc)

        ' Dim Cant = (consulta.CantFact + consulta.CantNotaFact + consulta.CantFactAnu +
        'consulta.CantBol + consulta.CantNotaBol + consulta.CantBolAnu)

        Dim consulta = documentosa.AlertaEnvioPSETrasporte(Gempresas.IdEmpresaRuc)
        Dim Cant = (consulta.CpePen + consulta.AnuPen)

        If Cant > 0 Then
            If My.Computer.Network.IsAvailable = True Then

                Dim f As New FormEnviosPendientesPse  'frmMasterFacturacionPSE
                f.StartPosition = FormStartPosition.CenterParent
                f.lblAnulados.Text = consulta.AnuPen
                f.lblCpe.Text = consulta.CpePen
                f.ShowDialog()

            Else
                MsgBox("NO TIENE ACCESO A INTERNET !!ALERTA TIENE CPE PENDIENTES DE ENVIO")
                'MsgBox("No tengo conexión a Internet")
            End If
        End If



    End Sub

#End Region

    Private Sub FormControlTransporteVer2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormControlTransporteVer2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Gempresas.ubigeo > 0 Then

            AlertasPSE()

        End If
    End Sub
End Class
