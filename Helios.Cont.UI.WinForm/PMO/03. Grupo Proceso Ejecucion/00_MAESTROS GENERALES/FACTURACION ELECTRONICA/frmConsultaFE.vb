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

Public Class frmConsultaFE

#Region "Variables"
    Private Const UrlSunat As String = "https://www.sunat.gob.pe/ol-ti-itcpfegem/billService"
    Dim docVenta As New documentoventaAbarrotes
#End Region

#Region "Constructor"
    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        docVenta = New documentoventaAbarrotes
        docVenta.idEmpresa = Gempresas.IdEmpresaRuc
    End Sub


#End Region

#Region "Metodos"

    Public Sub TicketsXvalidarBajasBoletas()
        Dim documentosa As New documentoVentaAbarrotesSA
        cboTickets.DataSource = Nothing
        Dim consulta = documentosa.TicketsXvalidarBajasBoletas(docVenta)

        cboTickets.DisplayMember = "ticketElectronico"
        cboTickets.ValueMember = "ticketElectronico"
        cboTickets.DataSource = consulta

        txtCodigoRespuesta.Text = ""
        txtRespuesta.Text = ""

    End Sub


    Public Sub TicketsXvalidarNotasBoleta()
        Dim documentosa As New documentoVentaAbarrotesSA
        cboTickets.DataSource = Nothing

        Dim consulta = documentosa.TicketsXvalidarNotasBoleta(docVenta)

        cboTickets.DisplayMember = "ticketElectronico"
        cboTickets.ValueMember = "ticketElectronico"
        cboTickets.DataSource = consulta

        txtCodigoRespuesta.Text = ""
        txtRespuesta.Text = ""

    End Sub

    Public Sub TicketsXvalidarBajasFactura()
        Dim documentosa As New documentoVentaAbarrotesSA

        cboTickets.DataSource = Nothing

        Dim consulta = documentosa.TicketsXvalidarBajasFactura(docVenta)

        cboTickets.DisplayMember = "ticketElectronico"
        cboTickets.ValueMember = "ticketElectronico"
        cboTickets.DataSource = consulta

        txtCodigoRespuesta.Text = ""
        txtRespuesta.Text = ""

    End Sub

    Public Sub TicketsXValidar()
        Dim documentosa As New documentoVentaAbarrotesSA
        cboTickets.DataSource = Nothing
        Dim consulta = documentosa.TicketsXvalidar(docVenta)

        cboTickets.DisplayMember = "ticketElectronico"
        cboTickets.ValueMember = "ticketElectronico"
        cboTickets.DataSource = consulta

        txtCodigoRespuesta.Text = ""
        txtRespuesta.Text = ""

    End Sub

    Public Sub Consulta(nroTicket As String)


        txtNumero.Text = ""
        txtRespuesta.Text = ""

        Try

            Dim documentoRequest As New ConsultaTicketRequest() With {
                .Ruc = 20603329156,
                .UsuarioSol = "MARTIN88",
                .ClaveSol = "Samps008",
                .EndPointUrl = UrlSunat,
                .NroTicket = nroTicket
            }

            Dim enviarDocumentoResponse = RestHelper(Of ConsultaTicketRequest, EnviarDocumentoResponse).Execute("ConsultarTicket", documentoRequest)

            If Not enviarDocumentoResponse.Exito Then

                Throw New Exception(enviarDocumentoResponse.MensajeError)

            End If




            MessageBox.Show("Consulta ok" + enviarDocumentoResponse.CodigoRespuesta)
            txtCodigoRespuesta.Text = enviarDocumentoResponse.CodigoRespuesta
            txtRespuesta.Text = enviarDocumentoResponse.MensajeRespuesta

            If txtCodigoRespuesta.Text = "0" Then
                File.WriteAllBytes("C:\FACTURASELECTRONICAS\CONSULTA\" & enviarDocumentoResponse.NombreArchivo & ".zip", Convert.FromBase64String(enviarDocumentoResponse.TramaZipCdr))
                btnvalidar.Visible = True
                btnReenviar.Visible = False
            Else
                btnvalidar.Visible = False
                btnReenviar.Visible = True
            End If


        Catch ex As Exception
            MsgBox("Error" & vbCrLf & ex.Message)
        End Try
    End Sub
#End Region

    Private Sub frmConsultaFE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If cboTickets.Text.Trim.Length > 0 Then
            Consulta(cboTickets.Text)
        Else
            MessageBox.Show("Digite su numero de ticket a consultar")
        End If
    End Sub

    Private Sub btnReenviar_Click(sender As Object, e As EventArgs) Handles btnReenviar.Click


        Select Case ComboBox1.Text
            Case "FACTURAS ANULADAS"
                If Not txtCodigoRespuesta.Text = "0" Then
                    Dim f As New frmRennvioComunicacionBaja     'frmVentaNuevoPOS
                    ' f.txtTicket.Text = cboTickets.Text
                    ' f.btnReenvio.Visible = True
                    f.txtNumeracion.Visible = True
                    f.btnEnvio.Visible = True
                    f.txtTicket.Text = cboTickets.Text
                    f.BuscarDocumentosAnuladosFechaTicket(cboTickets.Text)
                    f.StartPosition = FormStartPosition.CenterScreen
                    f.Show(Me)

                    cboTickets.DataSource = Nothing
                    txtCodigoRespuesta.Text = ""
                    txtRespuesta.Text = ""
                End If

            Case "RESUMEN DE BOLETAS"
                If Not txtCodigoRespuesta.Text = "0" Then
                    Dim f As New frmReenvioBoletas    'frmVentaNuevoPOS
                    f.txtTicket.Text = cboTickets.Text
                    f.btnReenvio.Visible = True
                    f.txtNumeracion.Visible = True
                    f.BuscarBoletasXTicketSunat(cboTickets.Text)
                    f.StartPosition = FormStartPosition.CenterScreen
                    f.Show(Me)

                    cboTickets.DataSource = Nothing
                    txtCodigoRespuesta.Text = ""
                    txtRespuesta.Text = ""
                End If

            Case "RESUMEN DE NOTAS CREDITO BOLETAS"
                If Not txtCodigoRespuesta.Text = "0" Then
                    Dim f As New frmReenvioBoletas    'frmVentaNuevoPOS
                    f.txtTicket.Text = cboTickets.Text
                    f.btnReenvio.Visible = True
                    f.txtNumeracion.Visible = True
                    f.BuscarBoletasXTicketSunatNotas(cboTickets.Text)
                    f.StartPosition = FormStartPosition.CenterScreen
                    f.Show(Me)

                    cboTickets.DataSource = Nothing
                    txtCodigoRespuesta.Text = ""
                    txtRespuesta.Text = ""
                End If


            Case "RESUMEN BOLETAS ANULADAS"
                If Not txtCodigoRespuesta.Text = "0" Then
                    Dim f As New frmReenvioBoletas    'frmVentaNuevoPOS
                    f.txtTicket.Text = cboTickets.Text
                    f.btnReenvio.Visible = True
                    f.txtNumeracion.Visible = True
                    f.BuscarBoletasXTicketSunat(cboTickets.Text)
                    f.StartPosition = FormStartPosition.CenterScreen
                    f.Show(Me)

                    cboTickets.DataSource = Nothing
                    txtCodigoRespuesta.Text = ""
                    txtRespuesta.Text = ""
                End If
        End Select

    End Sub

    Private Sub btnvalidar_Click(sender As Object, e As EventArgs) Handles btnvalidar.Click


        Select Case ComboBox1.Text
            Case "FACTURAS ANULADAS"

                If txtCodigoRespuesta.Text = "0" Then
                    Dim f As New frmRennvioComunicacionBaja     'frmVentaNuevoPOS
                    ' f.txtTicket.Text = cboTickets.Text
                    ' f.btnValidar.Visible = True
                    f.txtTicket.Text = cboTickets.Text
                    f.btnValidar.Visible = True
                    f.BuscarDocumentosAnuladosFechaTicket(cboTickets.Text)
                    f.StartPosition = FormStartPosition.CenterScreen
                    f.Show(Me)

                    cboTickets.DataSource = Nothing
                    txtCodigoRespuesta.Text = ""
                    txtRespuesta.Text = ""
                End If

            Case "RESUMEN DE BOLETAS"


                If txtCodigoRespuesta.Text = "0" Then
                    Dim f As New frmReenvioBoletas    'frmVentaNuevoPOS
                    f.txtTicket.Text = cboTickets.Text
                    f.btnValidar.Visible = True
                    f.BuscarBoletasXTicketSunat(cboTickets.Text)
                    f.StartPosition = FormStartPosition.CenterScreen
                    f.Show(Me)

                    cboTickets.DataSource = Nothing
                    txtCodigoRespuesta.Text = ""
                    txtRespuesta.Text = ""
                End If


            Case "RESUMEN DE NOTAS CREDITO BOLETAS"

                If txtCodigoRespuesta.Text = "0" Then
                    Dim f As New frmReenvioBoletas    'frmVentaNuevoPOS
                    f.txtTicket.Text = cboTickets.Text
                    f.btnValidar.Visible = True
                    f.BuscarBoletasXTicketSunat(cboTickets.Text)
                    f.StartPosition = FormStartPosition.CenterScreen
                    f.Show(Me)

                    cboTickets.DataSource = Nothing
                    txtCodigoRespuesta.Text = ""
                    txtRespuesta.Text = ""
                End If

            Case "RESUMEN BOLETAS ANULADAS"

                If txtCodigoRespuesta.Text = "0" Then
                    Dim f As New frmReenvioBoletas    'frmVentaNuevoPOS
                    f.txtTicket.Text = cboTickets.Text
                    f.btnValidar.Visible = True
                    f.BuscarBoletasXTicketSunat(cboTickets.Text)
                    f.StartPosition = FormStartPosition.CenterScreen
                    f.Show(Me)

                    cboTickets.DataSource = Nothing
                    txtCodigoRespuesta.Text = ""
                    txtRespuesta.Text = ""
                End If

        End Select

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        Select Case ComboBox1.Text

            Case "FACTURAS ANULADAS"

                TicketsXvalidarBajasFactura()

            Case "RESUMEN DE BOLETAS"
                TicketsXValidar()

            Case "RESUMEN DE NOTAS CREDITO BOLETAS"

                TicketsXvalidarNotasBoleta()

            Case "RESUMEN BOLETAS ANULADAS"
                TicketsXvalidarBajasBoletas()
        End Select


    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        cboTickets.DataSource = Nothing
        txtNumero.Text = ""
        txtRespuesta.Text = ""
    End Sub

    Private Sub cboTickets_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTickets.SelectedIndexChanged
        txtNumero.Text = ""
        txtRespuesta.Text = ""
    End Sub

    Private Sub frmConsultaFE_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dispose()
    End Sub
End Class