Imports System.ComponentModel
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.Business.Entity
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports Tulpep.NotificationWindow

Public Class frmMasterFacturacionFE

#Region "Variables Globales"

    Dim documentoventaSA As New documentoVentaAbarrotesSA
    Dim documentoventa As New documentoventaAbarrotes
#End Region

#Region "Metodos"

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


    Public Sub AlertasTickets()
        lblResumenpendiente.Text = documentoventaSA.ResumenBoletasPendiente(documentoventa)
        lblvalidarbajas.Text = documentoventaSA.FacturasBajasValidar(documentoventa)
        LBLRESUMENBAJAVALIDAR.Text = documentoventaSA.BoletasBajaValidar(documentoventa)
    End Sub

    Public Sub AlertasBoletas()
        lblboletaspendientes.Text = documentoventaSA.BoletasPendientesEnvio(documentoventa)
        LBLBOLETASELIMINADAS.Text = documentoventaSA.BoletasBaja(documentoventa)
    End Sub


    Public Sub AlertasFacturacionElectronica()

        lblFacturasPendientes.Text = documentoventaSA.FacturasPendientesSunat(documentoventa)
        lblNotasPendiente.Text = documentoventaSA.NotasPendientesSunat(documentoventa)
        lblFacturasAnuladas.Text = documentoventaSA.FacturaBajasPendiente(documentoventa)

        'lblboletaspendientes.Text = documentoventaSA.BoletasPendientesEnvio()
        'LBLBOLETASELIMINADAS.Text = documentoventaSA.BoletasBaja()



        'lblResumenpendiente.Text = documentoventaSA.ResumenBoletasPendiente()
        'lblvalidarbajas.Text = documentoventaSA.FacturasBajasValidar()
        'LBLRESUMENBAJAVALIDAR.Text = documentoventaSA.BoletasBajaValidar()

    End Sub



#End Region

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim f As New frmFacturaElectronicaFE  'frmVentaNuevoPOS

        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog(Me)

        'AlertasFacturacionElectronica()
        AlertasPSE()
    End Sub

    Private Sub frmMasterFacturacionFE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        documentoventa.idEmpresa = Gempresas.IdEmpresaRuc
        'AlertasFacturacionElectronica()
        AlertasPSE()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim f As New frmBoletasElectronicas  'frmVentaNuevoPOS
        f.ComboBox1.Text = "BOLETAS"
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog(Me)

        ' AlertasBoletas()
        ' AlertasFacturacionElectronica()
        AlertasPSE()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim f As New frmComunicacionBajaFE   'frmVentaNuevoPOS

        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog(Me)

        'AlertasFacturacionElectronica()
        AlertasPSE()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim f As New frmConsultaFE   'frmVentaNuevoPOS

        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog(Me)
        ' AlertasFacturacionElectronica()
        AlertasTickets()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim f As New frmReenvioBoletas    'frmVentaNuevoPOS

        f.StartPosition = FormStartPosition.CenterScreen
        f.Show(Me)
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 0 Then
            'lblFacturasPendientes.Text = documentoventaSA.FacturasPendientesSunat(documentoventa)
            'lblNotasPendiente.Text = documentoventaSA.NotasPendientesSunat(documentoventa)


            AlertasPSE()

            'ElseIf TabControl1.SelectedIndex = 1 Then

            '    lblboletaspendientes.Text = documentoventaSA.BoletasPendientesEnvio(documentoventa)
            '    LBLBOLETASELIMINADAS.Text = documentoventaSA.BoletasBaja(documentoventa)

        ElseIf TabControl1.SelectedIndex = 1 Then

            lblResumenpendiente.Text = documentoventaSA.ResumenBoletasPendiente(documentoventa)
            lblvalidarbajas.Text = documentoventaSA.FacturasBajasValidar(documentoventa)
            LBLRESUMENBAJAVALIDAR.Text = documentoventaSA.BoletasBajaValidar(documentoventa)

        End If
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim f As New frmFacturaElectronicaFE  'frmVentaNuevoPOS
        f.ComboBox1.Text = "NOTAS DE CREDITO"
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog(Me)

        'AlertasFacturacionElectronica()
        AlertasPSE()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim f As New frmBoletasElectronicas  'frmVentaNuevoPOS

        f.ComboBox1.Text = "NOTAS DE CREDITO"

        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog(Me)

        ' AlertasBoletas()
        ' AlertasFacturacionElectronica()
        AlertasPSE()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim f As New frmBoletasElectronicas  'frmVentaNuevoPOS
        f.ComboBox1.Text = "ANULADOS"
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog(Me)
        ' AlertasBoletas()
        ' AlertasFacturacionElectronica()
        AlertasPSE()
    End Sub

    Private Sub Panel22_Click(sender As Object, e As EventArgs) Handles Panel22.Click
        Dim f As New frmFacturasAlertas    'frmVentaNuevoPOS
        f.StartPosition = FormStartPosition.CenterScreen
        f.txtTipoDoc.Text = "01"
        f.ShowDialog(Me)
    End Sub

    Private Sub Panel1_Click(sender As Object, e As EventArgs) Handles Panel1.Click
        Dim f As New frmFacturasAlertas    'frmVentaNuevoPOS
        f.StartPosition = FormStartPosition.CenterScreen
        f.txtTipoDoc.Text = "07"
        f.ShowDialog(Me)
    End Sub

    Private Sub Panel2_Click(sender As Object, e As EventArgs) Handles Panel2.Click
        Dim f As New frmBoletasAlertas    'frmVentaNuevoPOS
        f.StartPosition = FormStartPosition.CenterScreen
        f.txtTipoDoc.Text = "ANU"
        f.ShowDialog(Me)
    End Sub

    Private Sub Panel3_Click(sender As Object, e As EventArgs) Handles Panel3.Click
        Dim f As New frmBoletasAlertas    'frmVentaNuevoPOS
        f.StartPosition = FormStartPosition.CenterScreen
        f.txtTipoDoc.Text = "03"
        f.ShowDialog(Me)
    End Sub

    Private Sub Panel4_Click(sender As Object, e As EventArgs) Handles Panel4.Click
        Dim f As New frmBoletasAlertas    'frmVentaNuevoPOS
        f.StartPosition = FormStartPosition.CenterScreen
        f.txtTipoDoc.Text = "07"
        f.ShowDialog(Me)
    End Sub

    Private Sub Panel5_Click(sender As Object, e As EventArgs) Handles Panel5.Click
        Dim f As New frmBoletasAlertas    'frmVentaNuevoPOS
        f.StartPosition = FormStartPosition.CenterScreen
        f.txtTipoDoc.Text = "ANUBOL"
        f.ShowDialog(Me)
    End Sub
End Class