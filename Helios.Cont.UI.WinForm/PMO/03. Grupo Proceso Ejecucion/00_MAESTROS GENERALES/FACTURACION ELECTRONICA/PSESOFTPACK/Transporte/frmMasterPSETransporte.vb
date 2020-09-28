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

Public Class frmMasterPSETransporte

#Region "Variables"
    Dim documentoventaSA As New DocumentoventaTransporteSA
    Dim documentoventa As New documentoventaTransporte
#End Region

#Region "Metodos"

    Public Function usuariopse(idempresa As String)

        Try

            Dim Empresa As New Fact.Sunat.Business.Entity.empresa

            Empresa.ruc = idempresa


            Dim CodigoCliente = Helios.Fact.Sunat.WCFService.ServiceAccess.Admin.empresaSA.empresaSelxID(Empresa)

            If CodigoCliente Is Nothing Then
                'MessageBox.Show("Contactese con el PSE")
                Return 0
            Else
                Return CodigoCliente.idEmpresa
            End If

        Catch ex As Exception

            Return 0
            'MessageBox.Show("ERROR")

        End Try

    End Function

    Public Sub AlertasPSE()
        Dim documentosa As New DocumentoventaTransporteSA

        Dim consulta = documentosa.AlertaPSETrasporte(Gempresas.IdEmpresaRuc)

        lblFacturasPendientes.Text = consulta.CantFact
        lblNotasPendiente.Text = consulta.CantNotaFact
        lblFacturasAnuladas.Text = consulta.CantFactAnu

        lblboletaspendientes.Text = consulta.CantBol
        lblnotaboletas.Text = consulta.CantNotaBol
        LBLBOLETASELIMINADAS.Text = consulta.CantBolAnu

    End Sub
#End Region

    Private Sub frmMasterPSETransporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        documentoventa.idEmpresa = Gempresas.IdEmpresaRuc
        AlertasPSE()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim f As New frmFacturaElectronicaPSETrans   'frmVentaNuevoPOS

        f.ComboBox1.Text = "FACTURA"
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog(Me)

        'AlertasFacturacionElectronica()
        AlertasPSE()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim f As New frmComunicacionBajaPSETrans    'frmVentaNuevoPOS

        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog(Me)

        'AlertasFacturacionElectronica()
        AlertasPSE()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        Dim f As New frmFacturaElectronicaPSETrans   'frmVentaNuevoPOS

        f.ComboBox1.Text = "BOLETAS"
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog(Me)

        'AlertasFacturacionElectronica()
        AlertasPSE()

        'Dim f As New frmBoletasElectronicasPSETrans   'frmVentaNuevoPOS

        'f.StartPosition = FormStartPosition.CenterScreen
        'f.ShowDialog(Me)
        ''AlertasBoletas()
        ''AlertasFacturacionElectronica()

        'AlertasPSE()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim f As New frmBoletasElectronicasPSETrans   'frmVentaNuevoPOS
        f.ComboBox1.Text = "ANULADOS"
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog(Me)
        'AlertasBoletas()

        AlertasPSE()
    End Sub

    Private Sub frmMasterPSETransporte_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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

            If My.Computer.Network.IsAvailable = True Then
                Dim servirdor = usuariopse(Gempresas.IdEmpresaRuc)
                If servirdor > 0 Then
                    'no saldra si tiene pendientes y internet y servidor pse
                    MessageBox.Show("Pendientes de Envio CPE !OBLIGATORIO DE ENVIO")
                    e.Cancel = True
                Else
                    MsgBox("PROBLEMAS CON EL SERVIDOR DEL PSE CONTACTESE !!ALERTA TIENE CPE PENDIENTES DE ENVIO")
                    'e.Cancel = True
                End If

            Else
                MsgBox("NO TIENE ACCESO A INTERNET !!ALERTA TIENE CPE PENDIENTES DE ENVIO")
                'e.Cancel = True
            End If




        End If
    End Sub
End Class