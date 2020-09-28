Imports System.ComponentModel
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.Presentation.WinForm
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports System.IO
Imports OpenInvoicePeru.Comun.Dto.Intercambio
Imports OpenInvoicePeru.Comun.Dto.Modelos

Public Class FrmAlertasEnvioPSE

    'Public Function usuariopse(idempresa As String)

    '    Try

    '        Dim Empresa As New Fact.Sunat.Business.Entity.empresa

    '        Empresa.ruc = idempresa


    '        Dim CodigoCliente = Helios.Fact.Sunat.WCFService.ServiceAccess.Admin.empresaSA.empresaSelxID(Empresa)

    '        If CodigoCliente Is Nothing Then
    '            'MessageBox.Show("Contactese con el PSE")
    '            Return 0
    '        Else
    '            Return CodigoCliente.idEmpresa
    '        End If

    '    Catch ex As Exception

    '        Return 0
    '        'MessageBox.Show("ERROR")

    '    End Try

    'End Function


    Public Sub AlertasPSE()
        Dim documentosa As New documentoVentaAbarrotesSA

        Dim consulta = documentosa.AlertaPSE(Gempresas.IdEmpresaRuc)

        lblFacturasPendientes.Text = consulta.CantFact
        lblNotasPendiente.Text = consulta.CantNotaFact
        lblFacturasAnuladas.Text = consulta.CantFactAnu

        lblboletaspendientes.Text = consulta.CantBol
        lblnotaboletas.Text = consulta.CantNotaBol
        LBLBOLETASELIMINADAS.Text = consulta.CantBolAnu

    End Sub

    Private Sub FrmAlertasEnvioPSE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

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

    Private Sub FrmAlertasEnvioPSE_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing


        Dim CONTEO As Integer = 0
        CONTEO = lblFacturasPendientes.Text +
        lblNotasPendiente.Text +
        lblFacturasAnuladas.Text +
        lblboletaspendientes.Text +
        lblnotaboletas.Text +
        LBLBOLETASELIMINADAS.Text


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

    Private Sub Panel22_Paint(sender As Object, e As PaintEventArgs) Handles Panel22.Paint

    End Sub

    Private Sub Panel22_Click(sender As Object, e As EventArgs) Handles Panel22.Click
        Dim f As New frmFacturasAlertas    'frmVentaNuevoPOS
        f.StartPosition = FormStartPosition.CenterScreen
        f.txtTipoDoc.Text = "01"
        f.ShowDialog(Me)
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Panel1_Click(sender As Object, e As EventArgs) Handles Panel1.Click
        Dim f As New frmFacturasAlertas    'frmVentaNuevoPOS
        f.StartPosition = FormStartPosition.CenterScreen
        f.txtTipoDoc.Text = "07"
        f.ShowDialog(Me)
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Panel2_Click(sender As Object, e As EventArgs) Handles Panel2.Click
        Dim f As New frmBoletasAlertas    'frmVentaNuevoPOS
        f.StartPosition = FormStartPosition.CenterScreen
        f.txtTipoDoc.Text = "ANU"
        f.ShowDialog(Me)
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub Panel3_Click(sender As Object, e As EventArgs) Handles Panel3.Click
        Dim f As New frmBoletasAlertas    'frmVentaNuevoPOS
        f.StartPosition = FormStartPosition.CenterScreen
        f.txtTipoDoc.Text = "03"
        f.ShowDialog(Me)
    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub

    Private Sub Panel4_Click(sender As Object, e As EventArgs) Handles Panel4.Click
        Dim f As New frmBoletasAlertas    'frmVentaNuevoPOS
        f.StartPosition = FormStartPosition.CenterScreen
        f.txtTipoDoc.Text = "07"
        f.ShowDialog(Me)
    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint

    End Sub

    Private Sub Panel5_Click(sender As Object, e As EventArgs) Handles Panel5.Click
        Dim f As New frmBoletasAlertas    'frmVentaNuevoPOS
        f.StartPosition = FormStartPosition.CenterScreen
        f.txtTipoDoc.Text = "ANUBOL"
        f.ShowDialog(Me)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim f As New frmFacturaElectronicaPSE   'frmVentaNuevoPOS

        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog(Me)

        'AlertasFacturacionElectronica()
        AlertasPSE()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If lblFacturasPendientes.Text = 0 Then
            Dim f As New frmFacturaElectronicaPSE   'frmVentaNuevoPOS
            f.ComboBox1.Text = "NOTAS DE CREDITO"
            f.StartPosition = FormStartPosition.CenterScreen
            f.ShowDialog(Me)
            AlertasPSE()
        Else
            MessageBox.Show("Debe enviar primero todas las facturas")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim f As New frmComunicacionBajaPSE    'frmVentaNuevoPOS

        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog(Me)

        'AlertasFacturacionElectronica()
        AlertasPSE()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        Dim f As New frmFacturaElectronicaPSE   'frmVentaNuevoPOS
        f.ComboBox1.Text = "BOLETAS"
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog(Me)

        'AlertasFacturacionElectronica()
        AlertasPSE()

        'Dim f As New frmBoletasElectronicasPSE   'frmVentaNuevoPOS

        'f.StartPosition = FormStartPosition.CenterScreen
        'f.ShowDialog(Me)
        ''AlertasBoletas()
        ''AlertasFacturacionElectronica()

        'AlertasPSE()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If lblboletaspendientes.Text = 0 Then
            Dim f As New frmFacturaElectronicaPSE   'frmVentaNuevoPOS
            f.ComboBox1.Text = "NOTAS DE CREDITO BOLETAS"
            f.StartPosition = FormStartPosition.CenterScreen
            f.ShowDialog(Me)
            AlertasPSE()
        Else
            MessageBox.Show("Debe enviar primero todas las Boletas")
        End If
        'Dim f As New frmBoletasElectronicasPSE   'frmVentaNuevoPOS
        'f.ComboBox1.Text = "NOTAS DE CREDITO"
        'f.StartPosition = FormStartPosition.CenterScreen
        'f.ShowDialog(Me)
        ''AlertasBoletas()

        'AlertasPSE()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Dim f As New frmBoletasElectronicasPSE   'frmVentaNuevoPOS
        f.ComboBox1.Text = "ANULADOS"
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog(Me)
        'AlertasBoletas()

        AlertasPSE()

        'Dim f As New frmBoletasElectronicasPSE   'frmVentaNuevoPOS
        'f.ComboBox1.Text = "ANULADOS"
        'f.StartPosition = FormStartPosition.CenterScreen
        'f.ShowDialog(Me)
        ''AlertasBoletas()

        'AlertasPSE()
    End Sub

    Private Sub FrmAlertasEnvioPSE_HelpButtonClicked(sender As Object, e As CancelEventArgs) Handles Me.HelpButtonClicked

    End Sub
End Class