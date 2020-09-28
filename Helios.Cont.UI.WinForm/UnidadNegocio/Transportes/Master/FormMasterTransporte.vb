Imports System.ComponentModel
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms

Public Class FormMasterTransporte
    'Public Property TabTR_PasajeVenta As TabTR_PasajeVenta
    Private Property FormControlTransporteVer2 As FormControlTransporteVer2

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'TabTR_PasajeVenta = New TabTR_PasajeVenta(Me) With {.Dock = DockStyle.Fill}
        'Panel1.Controls.Add(TabTR_PasajeVenta)
        lblNombreEmpresa.Text = Gempresas.NomEmpresa
    End Sub

    Private Sub RoundButton23_Click(sender As Object, e As EventArgs) Handles RoundButton23.Click
        'Dim frm As MetroForm = Application.OpenForms.OfType(Of MetroForm)().Where(Function(pre) pre.Name = "FormControlTransporteVer2").SingleOrDefault
        'If frm Is Nothing Then
        FormControlTransporteVer2 = New FormControlTransporteVer2
        FormControlTransporteVer2.Show()
        'Else
        '    FormControlTransporteVer2.WindowState = FormWindowState.Normal
        '    FormControlTransporteVer2.BringToFront()
        'End If
        'Dim f As New FormControlTransportes()
        'f.StartPosition = FormStartPosition.CenterParent
        'f.Show()
    End Sub

#Region "Metodos"

    Private Function TerminarProceso(ByVal StrNombreProceso As String,
    Optional ByVal DecirSINO As Boolean = True) As Boolean
        ' Variables para usar Wmi  
        Dim ListaProcesos As Object
        Dim ObjetoWMI As Object
        Dim ProcesoACerrar As Object

        TerminarProceso = False

        ObjetoWMI = GetObject("winmgmts:")

        If ObjetoWMI Is DBNull.Value = False Then

            'instanciamos la variable  
            ListaProcesos = ObjetoWMI.InstancesOf("win32_process")

            For Each ProcesoACerrar In ListaProcesos
                If UCase(ProcesoACerrar.Name) = UCase(StrNombreProceso) Then
                    If DecirSINO Then
                        '   If MsgBox("¿Matar el proceso " & _
                        'ProcesoACerrar.Name & vbNewLine & "...¿Está seguro?", _
                        '                      vbYesNo + vbCritical) = vbYes Then

                        ProcesoACerrar.Terminate(0)
                        TerminarProceso = True
                        '  End If
                    Else
                        'Matamos el proceso con el método Terminate  
                        ProcesoACerrar.Terminate(0)
                        TerminarProceso = True
                    End If
                End If

            Next
        End If

        'Elimina las variables  
        ListaProcesos = Nothing
        ObjetoWMI = Nothing
    End Function

    Public Sub AlertasPseConsulta()
        Dim documentosa As New DocumentoventaTransporteSA
        Dim consulta = documentosa.AlertaEnvioPSETrasporte(Gempresas.IdEmpresaRuc)
        Dim Cant = (consulta.CpePen + consulta.AnuPen)


        If My.Computer.Network.IsAvailable = True Then

            'Dim f As New FrmAlertasEnvioPSE

            'f.lblFacturasPendientes.Text = consulta.CantFact
            'f.lblNotasPendiente.Text = consulta.CantNotaFact
            'f.lblFacturasAnuladas.Text = consulta.CantFactAnu
            'f.lblboletaspendientes.Text = consulta.CantBol
            'f.lblnotaboletas.Text = consulta.CantNotaBol
            'f.LBLBOLETASELIMINADAS.Text = consulta.CantBolAnu
            'f.StartPosition = FormStartPosition.CenterParent
            'f.ShowDialog()

            Dim f As New FormEnviosPendientesPse  'frmMasterFacturacionPSE
            f.StartPosition = FormStartPosition.CenterParent
            f.lblAnulados.Text = consulta.AnuPen
            f.lblCpe.Text = consulta.CpePen
            f.ShowDialog()
        Else
            MsgBox("NO TIENE ACCESO A INTERNET !!ALERTA TIENE CPE PENDIENTES DE ENVIO")
            'MsgBox("No tengo conexión a Internet")
        End If




    End Sub

#End Region
    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        Dim f As New FormPrincipalTranportes
        f.StartPosition = FormStartPosition.CenterParent
        f.Show()
    End Sub

    Private Sub RoundButton25_Click(sender As Object, e As EventArgs) Handles RoundButton25.Click
        Dim f As New FormManifiestoLiquidacion
        f.StartPosition = FormStartPosition.CenterParent
        f.Show()
    End Sub

    Private Sub FormMasterTransporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        General.Centrar(Me)
    End Sub

    Private Sub RoundButton22_Click(sender As Object, e As EventArgs) Handles RoundButton22.Click
        Dim f As New FormPrincipalTranportes
        f.BunifuFlatButton4.Visible = False
        f.BunifuFlatButton15.Visible = False
        f.BunifuFlatButton3.Visible = False
        f.BunifuFlatButton16.Visible = False
        f.BunifuFlatButton1.Visible = False
        f.BunifuFlatButton17.Visible = False
        f.BunifuFlatButton5.Visible = False
        f.BunifuFlatButton2.Visible = False
        'ENCOMIENDA

        f.bunifuFlatButton7.Visible = True

        f.StartPosition = FormStartPosition.CenterParent
        f.Show()
    End Sub

    Private Sub RoundButton24_Click(sender As Object, e As EventArgs) Handles RoundButton24.Click
        Dim f As New FormPrincipalTranportes
        f.bunifuFlatButton7.Visible = False
        f.BunifuFlatButton4.Visible = False
        f.BunifuFlatButton3.Visible = False
        f.BunifuFlatButton16.Visible = False
        f.BunifuFlatButton1.Visible = False
        f.BunifuFlatButton17.Visible = False
        f.BunifuFlatButton5.Visible = False
        f.BunifuFlatButton2.Visible = False
        'ENCOMIENDA
        f.BunifuFlatButton15.Visible = True
        f.cargarEncominda()

        f.StartPosition = FormStartPosition.CenterParent
        f.Show()
    End Sub

    Private Sub RoundButton26_Click(sender As Object, e As EventArgs) Handles RoundButton26.Click
        Dim f As New TabTR_ConfNumeracionAsiento
        f.cboActivosFijos.Visible = True
        f.StartPosition = FormStartPosition.CenterParent
        f.Show()
    End Sub

    Private Sub RoundButton27_Click(sender As Object, e As EventArgs) Handles RoundButton27.Click
        Dim f As New FormMasterPrecioNumeracion
        f.StartPosition = FormStartPosition.CenterParent
        f.Show()

    End Sub

    Private Sub RoundButton28_Click(sender As Object, e As EventArgs) Handles RoundButton28.Click
        If Gempresas.ubigeo > 0 Then

            AlertasPseConsulta()
        Else
            MessageBox.Show("Debe habilitar la facturación electronica", "Ubigeo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub RoundButton29_Click(sender As Object, e As EventArgs) Handles RoundButton29.Click
        Dim f As New TabTR_ConfTipoServicio
        'f.cboActivosFijos.Visible = True
        f.StartPosition = FormStartPosition.CenterParent
        f.Show()
    End Sub


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

    Private Sub FormMasterTransporte_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

    End Sub

    Private Sub FormMasterTransporte_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Gempresas.ubigeo > 0 Then

            AlertasPSE()

        End If


    End Sub

    Private Sub RoundButton210_Click(sender As Object, e As EventArgs) Handles RoundButton210.Click
        Dim f As New UCRegistroVentasTransporte
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub
End Class
