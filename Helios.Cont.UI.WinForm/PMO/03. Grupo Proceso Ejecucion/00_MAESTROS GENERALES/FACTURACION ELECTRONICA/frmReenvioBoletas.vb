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

Public Class frmReenvioBoletas

#Region "Variables"
    Private Const UrlSunat As String = "https://www.sunat.gob.pe/ol-ti-itcpfegem/billService"

    'Private Const UrlSunat As String = "https://e-beta.sunat.gob.pe/ol-ti-itcpfegem-beta/billService"
    Private Const FormatoFecha As String = "yyyy-MM-dd"
#End Region

#Region "Constructor"
    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        GetTableGrid()
        FormatoGridAvanzado(GridGroupingControl1, False, False)
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        'Dim strIDEmpresa = Gempresas.IdEmpresaRuc
        'GetNumeracion("RSD", strIDEmpresa)
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

#Region "Metodos"


    'Public Sub TicketsXValidar()
    '    Dim documentosa As New documentoVentaAbarrotesSA

    '    Dim consulta = documentosa.TicketsXvalidar()


    '    cboTickets.DisplayMember = "ticketElectronico"
    '    cboTickets.ValueMember = "ticketElectronico"
    '    cboTickets.DataSource = consulta





    'End Sub



    Public Sub BuscarBoletasXTicketSunatNotas(ticket As String)


        Dim docSA As New documentoVentaAbarrotesSA

        GridGroupingControl1.Table.Records.DeleteAll()

        Dim consulta = docSA.BuscarBoletasXTicketSunatNotas(ticket)

        If consulta.Count = 0 Then

            MessageBox.Show("No hay documentos por enviar")
        Else

            dtpFechaDocs.Value = consulta.FirstOrDefault.fechaDoc
            txtNumeracion.Text = consulta.FirstOrDefault.numeracionElectronica

            For Each i In consulta
                Me.GridGroupingControl1.Table.AddNewRecord.SetCurrent()
                Me.GridGroupingControl1.Table.AddNewRecord.BeginEdit()
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("idDocumento", i.idDocumento)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("nroDoc", i.serieVenta & "-" & i.numeroVenta)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("tipoDoc", i.tipoDocumento)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("tipoDocCliente", i.tipoDocEntidad)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("docCliente", i.NroDocEntidad)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("estado", "1")

                If i.moneda = "1" Then
                    Me.GridGroupingControl1.Table.CurrentRecord.SetValue("moneda", "PEN")
                ElseIf i.moneda = "2" Then
                    Me.GridGroupingControl1.Table.CurrentRecord.SetValue("moneda", "USD")
                End If


                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("igv", i.igv01)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("gravado", i.bi01)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("importe", i.ImporteNacional)


                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("docRel", i.serie & "-" & i.numeroDoc)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("nroRel", i.TipoDocNota)

                Me.GridGroupingControl1.Table.AddNewRecord.EndEdit()
            Next
        End If
    End Sub


    Public Sub BuscarBoletasXTicketSunat(ticket As String)


        Dim docSA As New documentoVentaAbarrotesSA

        GridGroupingControl1.Table.Records.DeleteAll()

        Dim consulta = docSA.BuscarBoletasXTicketSunat(ticket)

        If consulta.Count = 0 Then

            MessageBox.Show("No hay documentos por enviar")
        Else
            dtpFechaDocs.Value = consulta.FirstOrDefault.fechaDoc
            txtNumeracion.Text = consulta.FirstOrDefault.numeracionElectronica

            For Each i In consulta
                Me.GridGroupingControl1.Table.AddNewRecord.SetCurrent()
                Me.GridGroupingControl1.Table.AddNewRecord.BeginEdit()
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("idDocumento", i.idDocumento)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("nroDoc", i.serieVenta & "-" & i.numeroVenta)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("tipoDoc", i.tipoDocumento)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("tipoDocCliente", i.tipoDocEntidad)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("docCliente", i.NroDocEntidad)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("estado", "1")

                If i.moneda = "1" Then
                    Me.GridGroupingControl1.Table.CurrentRecord.SetValue("moneda", "PEN")
                ElseIf i.moneda = "2" Then
                    Me.GridGroupingControl1.Table.CurrentRecord.SetValue("moneda", "USD")
                End If


                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("igv", i.igv01)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("gravado", i.bi01)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("importe", i.ImporteNacional)
                Me.GridGroupingControl1.Table.AddNewRecord.EndEdit()
            Next
        End If
    End Sub

    'Dim conf As New GConfiguracionModulo
    'Private Sub GetNumeracion(strIdModulo As String, strIDEmpresa As String, intIdEstablecimiento As Integer)
    '    Dim moduloConfiguracionSA As New ModuloConfiguracionSA
    '    Dim moduloConfiguracion As New moduloConfiguracion
    '    moduloConfiguracion = moduloConfiguracionSA.UbicarConfiguracionPorEmpresaModulo(strIdModulo, strIDEmpresa, intIdEstablecimiento)
    '    conf = New GConfiguracionModulo
    '    conf = ConfigurarComprobanteVenta(moduloConfiguracion)
    '    'SetDataSourceNumeracion(moduloConfiguracion)
    'End Sub

    Public Sub configuracionModuloV2(strIDEmpresa As String, strIdModulo As String, strNomModulo As String, intIdEstablecimiento As Integer)
        Try

            Dim moduloConfiguracionSA As New ModuloConfiguracionSA
            Dim moduloConfiguracion As New moduloConfiguracion
            Dim numeracionSA As New NumeracionBoletaSA
            Dim TablaSA As New tablaDetalleSA
            Dim almacenSA As New almacenSA
            Dim cajaSA As New EstadosFinancierosSA

            Dim RecuperacionNumeracion = numeracionSA.GetUbicar_numeracionBoletasXUnidadNegocio(New numeracionBoletas With {.empresa = strIDEmpresa, .establecimiento = intIdEstablecimiento, .codigoNumeracion = strIdModulo, .estado = "A"})

            If (Not IsNothing(RecuperacionNumeracion)) Then
                GConfiguracion = New GConfiguracionModulo
                GConfiguracion.ConfigComprobante = CInt(RecuperacionNumeracion.IdEnumeracion)
                GConfiguracion.TipoComprobante = "03" 'RecuperacionNumeracion.tipo

                'GConfiguracion.Serie = RecuperacionNumeracion.serie
                GConfiguracion.ValorActual = CInt(RecuperacionNumeracion.valorInicial) + 1
                txtNumeracion.Text = CInt(RecuperacionNumeracion.valorInicial) + 1
            Else
                Throw New Exception("Verificar configuración")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Public Function ConfigurarComprobanteVenta(moduloConfiguracion As moduloConfiguracion) As GConfiguracionModulo
    '    Dim numeracionSA As New NumeracionBoletaSA
    '    Dim TablaSA As New tablaDetalleSA
    '    Dim almacenSA As New almacenSA
    '    Dim cajaSA As New EstadosFinancierosSA

    '    If Not IsNothing(moduloConfiguracion) Then
    '        With moduloConfiguracion
    '            GConfiguracion2 = New GConfiguracionModulo
    '            GConfiguracion2.IdModulo = .idModulo
    '            GConfiguracion2.TipoConfiguracion = .tipoConfiguracion
    '            Select Case .tipoConfiguracion
    '                Case "P"
    '                    With numeracionSA.GetUbicar_numeracionBoletasPorID(.configComprobante)
    '                        GConfiguracion2.ConfigComprobante = .IdEnumeracion

    '                        GConfiguracion2.TipoComprobante = "03" ' .tipo
    '                        GConfiguracion2.Serie = .serie
    '                        GConfiguracion2.ValorActual = .valorInicial

    '                        'txtSerie.Text = .serie
    '                        txtNumeracion.Text = .valorInicial + 1

    '                        'If cboTipoDoc.Text = "BOLETA" Then
    '                        '    GConfiguracion2.TipoComprobante = "12.1" ' .tipo
    '                        '    GConfiguracion2.Serie = .serie
    '                        '    GConfiguracion2.ValorActual = .valorInicial

    '                        'End If
    '                        'If cboTipoDoc.Text = "FACTURA" Then
    '                        '    GConfiguracion2.TipoComprobante = "12.2" '.tipo
    '                        '    GConfiguracion2.Serie = .serie
    '                        '    GConfiguracion2.ValorActual = .valorInicial

    '                        'End If

    '                    End With
    '                Case "M"

    '            End Select

    '        End With
    '    Else
    '        'lblEstado.Text = "Este módulo no contiene una configuración disponible, intentelo más tarde.!"
    '        'Timer1.Enabled = True
    '        ''TabCompra.Enabled = False
    '        'TiempoEjecutar(5)
    '        MessageBox.Show("Este módulo no contiene una configuración disponible, intentelo más tarde.!")
    '    End If
    '    Return GConfiguracion2
    'End Function

    Sub GetTableGrid()
        Dim dt As New DataTable()

        dt.Columns.Add("idDocumento")
        dt.Columns.Add("nroDoc")
        dt.Columns.Add("tipoDoc")
        dt.Columns.Add("tipoDocCliente")
        dt.Columns.Add("docCliente")
        dt.Columns.Add("estado")
        dt.Columns.Add("moneda")
        dt.Columns.Add("igv")
        dt.Columns.Add("gravado")
        dt.Columns.Add("importe")
        dt.Columns.Add("docRel")
        dt.Columns.Add("nroRel")


        GridGroupingControl1.DataSource = dt
    End Sub

    Function CrearEmisor() As Compania
        Dim Emisor As New Compania

        Emisor.NroDocumento = Gempresas.IdEmpresaRuc '"20603127278"
        Emisor.TipoDocumento = "6"
        Emisor.NombreComercial = Gempresas.NomEmpresa '"INVERSIONES SEÑOR DE ACORIA S.A.C."
        Emisor.NombreLegal = Gempresas.NomEmpresa '"INVERSIONES SEÑOR DE ACORIA S.A.C."
        Emisor.CodigoAnexo = "0001"

        Return Emisor

    End Function

    'Private Function CrearEmisor() As Contribuyente
    '    Return New Contribuyente() With {
    '   .NroDocumento = Gempresas.IdEmpresaRuc,
    '    .TipoDocumento = "6", 'CATALOGO N° 06
    '    .Direccion = Gempresas.direccionEmpresa,
    '    .Urbanizacion = "-",
    '    .Departamento = Gempresas.departamento,
    '    .Provincia = Gempresas.provincia,
    '    .Distrito = Gempresas.distrito,
    '    .NombreComercial = Gempresas.NomEmpresa,
    '    .NombreLegal = Gempresas.NomEmpresa,
    '    .Ubigeo = Gempresas.ubigeo
    '    }
    'End Function


    Private Sub ValidarEnvioSunat()
        Dim conteo As Integer = 0
        Dim listaActEstado As New List(Of documentoventaAbarrotes)
        Dim documentos As documentoventaAbarrotes

        Dim numer As String = String.Format("{0:00000}", CInt(txtNumeracion.Text))



        Try
            For Each i In GridGroupingControl1.Table.Records

                documentos = New documentoventaAbarrotes

                documentos.idDocumento = CInt(i.GetValue("idDocumento"))

                listaActEstado.Add(documentos)

            Next





            ValidarEnvioSunat(listaActEstado)
            Dispose()



        Catch ex As Exception
            MsgBox("No se actualizo" & vbCrLf & ex.Message)
            'Console.WriteLine(ex.Message)
        Finally
            'Console.ReadLine()
        End Try
    End Sub


    Private Sub CrearResumenDiario()

        Dim objeto As GrupoResumenNuevo
        Dim conteo As Integer = 0
        Dim listaActEstado As New List(Of documentoventaAbarrotes)
        Dim documentos As documentoventaAbarrotes

        Dim numer As String = String.Format("{0:00000}", CInt(txtNumeracion.Text))



        Try

            '.IdDocumento = String.Format("RC-{0:yyyyMMdd}-001", DateTime.Today),
            Console.WriteLine("Ejemplo de Resumen Diario")
            Dim documentoResumenDiario As New ResumenDiarioNuevo() With {
                .IdDocumento = String.Format("RC-{0:yyyyMMdd}-" & numer, DateTime.Today),
                .FechaEmision = DateTime.Today.ToString(FormatoFecha),
                .FechaReferencia = dtpFechaDocs.Value.Date.ToString(FormatoFecha), 'DateTime.Today.AddDays(-1).ToString(FormatoFecha),
                .Emisor = CrearEmisor(),
                .Resumenes = New List(Of GrupoResumenNuevo)()
            }





            For Each i In GridGroupingControl1.Table.Records

                documentos = New documentoventaAbarrotes

                If i.GetValue("tipoDoc") = "03" Then
                    objeto = New GrupoResumenNuevo
                    conteo += 1
                    objeto.Id = conteo
                    objeto.TipoDocumento = i.GetValue("tipoDoc")
                    objeto.IdDocumento = i.GetValue("nroDoc")
                    objeto.NroDocumentoReceptor = i.GetValue("docCliente")
                    objeto.TipoDocumentoReceptor = i.GetValue("tipoDocCliente")
                    objeto.CodigoEstadoItem = CInt(i.GetValue("estado"))
                    objeto.Moneda = i.GetValue("moneda")
                    objeto.TotalVenta = CDec(i.GetValue("importe"))
                    objeto.TotalIgv = CDec(i.GetValue("igv"))
                    objeto.Gravadas = CDec(i.GetValue("gravado"))

                    documentos.idDocumento = CInt(i.GetValue("idDocumento"))

                    documentoResumenDiario.Resumenes.Add(objeto)
                    listaActEstado.Add(documentos)

                ElseIf i.GetValue("tipoDoc") = "07" Then

                    objeto = New GrupoResumenNuevo
                    conteo += 1
                    objeto.Id = conteo
                    objeto.TipoDocumento = i.GetValue("tipoDoc")
                    objeto.IdDocumento = i.GetValue("nroDoc")



                    objeto.NroDocumentoReceptor = i.GetValue("docCliente")
                    objeto.TipoDocumentoReceptor = i.GetValue("tipoDocCliente")
                    objeto.CodigoEstadoItem = 2 'CInt(i.GetValue("estado"))
                    objeto.Moneda = i.GetValue("moneda")
                    objeto.TotalVenta = CDec(i.GetValue("importe"))
                    objeto.TotalIgv = CDec(i.GetValue("igv"))
                    objeto.Gravadas = CDec(i.GetValue("gravado"))
                    objeto.TipoDocumentoRelacionado = i.GetValue("nroRel")
                    objeto.DocumentoRelacionado = i.GetValue("docRel")




                    documentos.idDocumento = CInt(i.GetValue("idDocumento"))



                    documentoResumenDiario.Resumenes.Add(objeto)
                    listaActEstado.Add(documentos)

                End If



            Next

            '' 1 - Agregar. 2 - Modificar. 3 - Eliminar
            'documentoResumenDiario.Resumenes.Add(New GrupoResumenNuevo() With {
            '    .Id = 1,
            '    .TipoDocumento = "03",
            '    .IdDocumento = "BB14-33386",
            '    .NroDocumentoReceptor = "41614074",
            '    .TipoDocumentoReceptor = "1",
            '    .CodigoEstadoItem = 1,
            '    .Moneda = "PEN",
            '    .TotalVenta = 190.9D,
            '    .TotalIgv = 29.12D,
            '    .Gravadas = 161.78D
            '})
            '' Para los casos de envio de boletas anuladas, se debe primero informar las boletas creadas (1) y luego en un segundo resumen se envian las anuladas. De lo contrario se presentará el error 'El documento indicado no existe no puede ser modificado/eliminado'
            '' 1 - Agregar. 2 - Modificar. 3 - Eliminar
            'documentoResumenDiario.Resumenes.Add(New GrupoResumenNuevo() With {
            '    .Id = 2,
            '    .TipoDocumento = "03",
            '    .IdDocumento = "BB30-33384",
            '    .NroDocumentoReceptor = "08506678",
            '    .TipoDocumentoReceptor = "1",
            '    .CodigoEstadoItem = 1,
            '    .Moneda = "USD",
            '    .TotalVenta = 9580D,
            '    .TotalIgv = 1411.36D,
            '    .Gravadas = 8168.64D
            '})


            ' Console.WriteLine("Generando XML....")

            Dim documentoResponse = RestHelper(Of ResumenDiarioNuevo, DocumentoResponse).Execute("GenerarResumenDiario/v2", documentoResumenDiario)

            If Not documentoResponse.Exito Then
                'Throw New InvalidOperationException(documentoResponse.MensajeError)


                MessageBox.Show(documentoResponse.MensajeError)
                Exit Sub
            End If

            ' Console.WriteLine("Firmando XML...")
            ' Firmado del Documento.
            Dim firmado As New FirmadoRequest() With {
                .TramaXmlSinFirma = documentoResponse.TramaXmlSinFirma,
                .CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes("C:\CERIFICADOSOFTPACK.pfx")),
                .PasswordCertificado = "7cZGKQsu4idgwzib"
            }

            Dim responseFirma = RestHelper(Of FirmadoRequest, FirmadoResponse).Execute("Firmar", firmado)

            If Not responseFirma.Exito Then
                'Throw New InvalidOperationException(responseFirma.MensajeError)

                MessageBox.Show(responseFirma.MensajeError)
                Exit Sub
            End If

            'Console.WriteLine("Guardando XML de Resumen....(Revisar carpeta del ejecutable)")

            'File.WriteAllBytes("C:\FACTURASELECTRONICAS\" + documentoResumenDiario.IdDocumento + ".xml", Convert.FromBase64String(responseFirma.TramaXmlFirmado))

            'Console.WriteLine("Enviando a SUNAT....")

            Dim enviarDocumentoRequest As New EnviarDocumentoRequest() With {
                .Ruc = documentoResumenDiario.Emisor.NroDocumento,
                .UsuarioSol = "MARTIN88",
                .ClaveSol = "Samps008",
                .EndPointUrl = UrlSunat,
                .IdDocumento = documentoResumenDiario.IdDocumento,
                .TramaXmlFirmado = responseFirma.TramaXmlFirmado
            }

            Dim enviarResumenResponse = RestHelper(Of EnviarDocumentoRequest, EnviarResumenResponse).Execute("EnviarResumen", enviarDocumentoRequest)

            If Not enviarResumenResponse.Exito Then
                ' Throw New InvalidOperationException(enviarResumenResponse.MensajeError)
                'MessageBox.Show(enviarResumenResponse.MensajeError)


                'Exit Sub
                Throw New Exception(enviarResumenResponse.MensajeError)
            End If

            'Console.WriteLine("Nro de Ticket: {0}", enviarResumenResponse.NroTicket)
            File.WriteAllBytes("C:\FACTURASELECTRONICAS\RESUMENDIARIO\" + enviarResumenResponse.NombreArchivo + ".xml", Convert.FromBase64String(responseFirma.TramaXmlFirmado))

            ActualizarBoletas(listaActEstado, txtNumeracion.Text, enviarResumenResponse.NroTicket)


            MessageBox.Show(enviarResumenResponse.NroTicket)

            Dispose()

        Catch ex As Exception
            MsgBox("No se genero el resumen de boletas electronica" & vbCrLf & ex.Message)
            'Console.WriteLine(ex.Message)
        Finally
            'Console.ReadLine()
        End Try
    End Sub


    Public Sub ValidarEnvioSunat(listaBoletas As List(Of documentoventaAbarrotes))


        Dim documentoventasa As New documentoVentaAbarrotesSA



        Try



            documentoventasa.ValidarEnviosSunat(listaBoletas)


        Catch ex As Exception
            MessageBox.Show("No se Pudo Actualizar")
        End Try



    End Sub

    Public Sub ActualizarBoletas(listaBoletas As List(Of documentoventaAbarrotes), idNum As Integer, nroTicket As String)



        Dim documentoventasa As New documentoVentaAbarrotesSA
        'Dim objeto As documentoventaAbarrotes
        'Dim listaDocs As New List(Of documentoventaAbarrotes)


        Try


            'For Each i In GridGroupingControl1.Table.Records


            '    objeto = New documentoventaAbarrotes

            '    objeto.idDocumento = i.GetValue("idDocumento")

            '    listaDocs.Add(objeto)
            'Nextasdasd

            documentoventasa.ListaReenvioSunatResumen(listaBoletas, nroTicket)


        Catch ex As Exception
            MessageBox.Show("No se Pudo Actualizar")
        End Try



    End Sub

#End Region
#End Region

    Private Sub frmReenvioBoletas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        If txtTicket.Text.Trim.Length > 0 Then
            BuscarBoletasXTicketSunat(txtTicket.Text)
        End If
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles btnReenvio.Click
        If GridGroupingControl1.Table.Records.Count > 0 Then

            Try
                CrearResumenDiario()


                'Select Case ComboBox1.Text
                '    Case "BOLETAS"
                '        BuscarDocsFecha(dtpFechaDocs.Value)
                '    Case "NOTAS DE CREDITO"
                '        NotasCreditoBoleta(dtpFechaDocs.Value)
                '    Case "NOTA DE DEBITO"

                'End Select

                'Dim strIDEmpresa = Gempresas.IdEmpresaRuc
                'GetNumeracion("RSD", strIDEmpresa)
                'ActualizarEnvioSunat()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try



        Else
            MessageBox.Show("No hay Documentos para enviar")
        End If
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles btnValidar.Click
        If GridGroupingControl1.Table.Records.Count > 0 Then

            Try
                ValidarEnvioSunat()

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try



        Else
            MessageBox.Show("No hay Documentos para enviar")
        End If

    End Sub
End Class