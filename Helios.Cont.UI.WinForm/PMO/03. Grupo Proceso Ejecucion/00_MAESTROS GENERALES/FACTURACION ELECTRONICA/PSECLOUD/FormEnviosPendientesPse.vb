Imports Syncfusion.Grouping
Imports Helios.General
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Cont.Business.Entity


Public Class FormEnviosPendientesPse
#Region "Attributes"
    Public UCEnviosCpe As UCEnviosCpe
    Public UCEnviosAnulados As UCEnviosAnulados
#End Region

#Region "Constructors"

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        UCEnviosCpe = New UCEnviosCpe(Me)
        UCEnviosAnulados = New UCEnviosAnulados(Me)


        UCEnviosCpe.Dock = DockStyle.Fill
        PanelBody.Controls.Add(UCEnviosCpe)

        PanelBody.Controls.Add(UCEnviosAnulados)

        'AlertaEnvioPSE()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

#Region "Metodos"


    Public Sub AlertaEnvioPSE()
        Dim documentosa As New documentoVentaAbarrotesSA

        Dim consulta = documentosa.AlertaEnvioPSE(Gempresas.IdEmpresaRuc)

        lblCpe.Text = consulta.CpePen
        lblAnulados.Text = consulta.AnuPen


    End Sub

#End Region



    Private Sub buttonAdv3_Click(sender As Object, e As EventArgs) Handles buttonAdv3.Click
        If UCEnviosAnulados IsNot Nothing Then
            UCEnviosAnulados.Visible = False
        End If

        If UCEnviosCpe IsNot Nothing Then
            UCEnviosCpe.Visible = True
            UCEnviosCpe.BringToFront()
            UCEnviosCpe.Show()
        End If

        AlertaEnvioPSE()
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click

        If lblCpe.Text = 0 Then

            If UCEnviosCpe IsNot Nothing Then
                UCEnviosCpe.Visible = False
            End If

            If UCEnviosAnulados IsNot Nothing Then
                UCEnviosAnulados.Visible = True
                UCEnviosAnulados.BringToFront()
                UCEnviosAnulados.Show()
            End If

            AlertaEnvioPSE()
        Else
            MessageBox.Show("Envie Primero Todos Los Comprobantes")

        End If
    End Sub

    Private Sub FormEnviosPendientesPse_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim CONTEO As Integer = 0
        CONTEO = lblCpe.Text + lblAnulados.Text

        If CONTEO = 0 Then
            '       bg.CancelAsync()
        Else
            If Gempresas.ubigeo > 0 Then
                If My.Computer.Network.IsAvailable = True Then
                    If My.Computer.Network.Ping("138.128.171.106") Then
                        MessageBox.Show("Pendientes de Envio CPE !OBLIGATORIO DE ENVIO")
                        e.Cancel = True
                    Else
                        MsgBox("EN ESTOS MOMEMENTOS NO SE ENCUENTRA DISPONIBLE EL SERVIDOR PUEDE HACER EL ENVIO DESPUES")
                    End If
                Else
                    MsgBox("NO TIENE ACCESO A INTERNET !!ALERTA TIENE CPE PENDIENTES DE ENVIO")
                    'e.Cancel = True
                End If
            End If

        End If
    End Sub

    Private Sub lblCpe_Click(sender As Object, e As EventArgs) Handles lblCpe.Click

    End Sub

#End Region

End Class