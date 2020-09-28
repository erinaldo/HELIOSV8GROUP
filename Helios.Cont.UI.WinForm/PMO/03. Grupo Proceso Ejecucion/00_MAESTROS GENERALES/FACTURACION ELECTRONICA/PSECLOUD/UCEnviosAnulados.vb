Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.GroupingGridExcelConverter

Public Class UCEnviosAnulados

    Public Property Form As FormEnviosPendientesPse


    Public Sub New(FormEnviosPendientesPse As FormEnviosPendientesPse)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        FormatoGridBlack(DgvDocumentos, True)
        GetTableGrid()
        Form = FormEnviosPendientesPse
        txtPeriodo.Value = DateTime.Now
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

#Region "Metodos"

    Public Sub EnviarAnulacionDocumento(objeto As documentoventaAbarrotes)
        Try
            Dim documentoventasa As New documentoVentaAbarrotesSA

            Dim documentoventaGuiasa As New DocumentoGuiaSA

            Dim objetoBaja As New Helios.Fact.Sunat.Business.Entity.RecepcionComunicacionBaja

            objetoBaja.IdDocumento = objeto.numeroDocNormal   'objeto.serieVenta & "-" & String.Format("{0:00000000}", CInt(objeto.numeroVenta))
            objetoBaja.TipoDocumento = objeto.tipoDocumento
            objetoBaja.idEmpresa = Gempresas.ubigeo
            objetoBaja.FechaEmision = objeto.fechaDoc
            objetoBaja.EnvioSunat = "NO"
            objetoBaja.estadoEnvio = "PE"
            objetoBaja.Contribuyente_id = Gempresas.IdEmpresaRuc

            Dim codigo = Helios.Fact.Sunat.WCFService.ServiceAccess.Admin.RecepcionComunicacionBajaSA.RecepcionComunicacionBajaSave(objetoBaja, Nothing)

            If codigo.idAnulacion > 0 Then
                'ActualizarEnvioSunat("0", objeto)

                If objeto.tipoDocumento = "09" Then
                    documentoventaGuiasa.UpdateGuiaXEstado(objeto.idDocumento, "SI") ', codigo.idAnulacion, 0)
                Else

                    documentoventasa.UpdateAnulacionEnviada(objeto.idDocumento, codigo.idAnulacion, 0)
                End If
                'MessageBox.Show("La comunicacion se Envio Correctamente al PSE")
            End If

        Catch ex As Exception

        End Try
    End Sub


    Sub GetTableGrid()
        Dim dt As New DataTable()
        dt.Columns.Add("id")
        dt.Columns.Add("FechaEmision")
        dt.Columns.Add("TipoDocumento")
        dt.Columns.Add("IdDocumento")
        dt.Columns.Add("Importe")
        dt.Columns.Add("EnvioSunat")
        DgvDocumentos.DataSource = dt
    End Sub

    Public Sub DocumentosAnuladosPendientes(fecha As DateTime)
        Dim docSA As New documentoVentaAbarrotesSA
        DgvDocumentos.Table.Records.DeleteAll()
        'Dim consulta = docSA.DocumentosAnuladosPendientes(fecha, Gempresas.IdEmpresaRuc)

        Dim consulta = docSA.AnuladosPendientesCPE(fecha, Gempresas.IdEmpresaRuc)

        If consulta.Count = 0 Then

            MessageBox.Show("No hay documentos por enviar")
        Else
            For Each i In consulta
                Me.DgvDocumentos.Table.AddNewRecord.SetCurrent()
                Me.DgvDocumentos.Table.AddNewRecord.BeginEdit()
                Me.DgvDocumentos.Table.CurrentRecord.SetValue("id", i.idDocumento)
                Me.DgvDocumentos.Table.CurrentRecord.SetValue("FechaEmision", i.fechaDoc)
                Me.DgvDocumentos.Table.CurrentRecord.SetValue("TipoDocumento", i.tipoDocumento)
                Me.DgvDocumentos.Table.CurrentRecord.SetValue("IdDocumento", i.serieVenta & "-" & String.Format("{0:00000000}", CInt(i.numeroVenta)))
                Me.DgvDocumentos.Table.CurrentRecord.SetValue("Importe", i.ImporteNacional)
                Me.DgvDocumentos.Table.CurrentRecord.SetValue("EnvioSunat", i.EnvioSunat)
                Me.DgvDocumentos.Table.AddNewRecord.EndEdit()


            Next
        End If

    End Sub

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        Me.Cursor = Cursors.WaitCursor
        btnEnviar.Enabled = False
        'Dim r As Record

        If Not Gempresas.ubigeo > 0 Then
            MessageBox.Show("Problemas con El Servidor o no esta Registrado Comuniquese con el PSE")
            btnEnviar.Enabled = True
            Exit Sub
        End If

        '//nuevo
        Try

            For Each i In DgvDocumentos.Table.Records

                If i.GetValue("id") > 0 Then

                    Dim objeto As New documentoventaAbarrotes()
                    objeto.idDocumento = i.GetValue("id")
                    objeto.tipoDocumento = i.GetValue("TipoDocumento")
                    objeto.numeroDocNormal = i.GetValue("IdDocumento")
                    objeto.fechaDoc = CDate(i.GetValue("FechaEmision"))
                    EnviarAnulacionDocumento(objeto)

                End If
            Next

            DocumentosAnuladosPendientes(txtPeriodo.Value)
            btnEnviar.Enabled = True


            Form.AlertaEnvioPSE()

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            btnEnviar.Enabled = True
            Me.Cursor = Cursors.Default
        End Try
        'enddd
    End Sub

    Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
        DocumentosAnuladosPendientes(txtPeriodo.Value)
    End Sub

#End Region




End Class
