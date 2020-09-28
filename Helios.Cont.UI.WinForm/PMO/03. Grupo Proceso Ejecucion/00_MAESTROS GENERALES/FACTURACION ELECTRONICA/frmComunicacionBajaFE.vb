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


Public Class frmComunicacionBajaFE

    Implements IListaDocumento

#Region "Variables"
    Private Const FormatoFecha As String = "yyyy-MM-dd"

    Private Const UrlSunat As String = "https://www.sunat.gob.pe/ol-ti-itcpfegem/billService"

    'Private Const UrlSunat As String = "https://e-beta.sunat.gob.pe/ol-ti-itcpfegem-beta/billService"
#End Region

#Region "Constructor"
    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        GetTableGrid()
        FormatoGridAvanzado(GridGroupingControl1, False, False)
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim strIDEmpresa = Gempresas.IdEmpresaRuc
        configuracionModuloV2(strIDEmpresa, "BAJA", "", GEstableciento.IdEstablecimiento)
    End Sub

#End Region

#Region "Metodos"

    'Dim conf As New GConfiguracionModulo
    'Private Sub GetNumeracion(strIdModulo As String, strIDEmpresa As String, intIdEstablecimiento As Integer)
    '    Dim moduloConfiguracionSA As New ModuloConfiguracionSA
    '    Dim moduloConfiguracion As New moduloConfiguracion
    '    moduloConfiguracion = moduloConfiguracionSA.UbicarConfiguracionPorEmpresaModulo(strIdModulo, strIDEmpresa, intIdEstablecimiento)
    '    conf = New GConfiguracionModulo
    '    conf = ConfigurarComprobanteVenta(moduloConfiguracion)
    '    'SetDataSourceNumeracion(moduloConfiguracion)
    'End Sub


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

    '                        'GConfiguracion2.TipoComprobante = "03" ' .tipo
    '                        'GConfiguracion2.Serie = .serie
    '                        GConfiguracion2.ValorActual = .valorInicial + 1

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
                'GConfiguracion.TipoComprobante = RecuperacionNumeracion.tipo
                'GConfiguracion.NombreComprobante = TablaSA.GetUbicarTablaID(10, RecuperacionNumeracion.tipo).descripcion
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

    Public Sub CargarDocumentosAnulados(fecha As DateTime)

        Dim docoumentoventasa As New documentoVentaAbarrotesSA

        GridGroupingControl1.Table.Records.DeleteAll()

        Dim consulta = docoumentoventasa.BuscarDocumentosAnuladosFecha(fecha, "01", Gempresas.IdEmpresaRuc)


        If consulta.Count > 0 Then
            For Each i In consulta
                Me.GridGroupingControl1.Table.AddNewRecord.SetCurrent()
                Me.GridGroupingControl1.Table.AddNewRecord.BeginEdit()
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("serie", i.serieVenta)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("numero", i.numeroVenta)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("tipoDoc", i.tipoDocumento)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("afectado", i.serie)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("importe", i.ImporteNacional)

                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("idDocumento", i.idDocumento)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("motivo", "ANULACION DE DOCUMENTO")
                Me.GridGroupingControl1.Table.AddNewRecord.EndEdit()
            Next
        Else
            MessageBox.Show("No hay documentos por enviar hoy")
        End If




    End Sub




    Public Sub ActualizarEnvioSunat(nroticket As String)



        Dim documentoventasa As New documentoVentaAbarrotesSA
        Dim objeto As documentoventaAbarrotes
        Dim listaDocs As New List(Of documentoventaAbarrotes)


        Try


            For Each i In GridGroupingControl1.Table.Records


                objeto = New documentoventaAbarrotes

                objeto.idDocumento = i.GetValue("idDocumento")

                listaDocs.Add(objeto)
            Next

            documentoventasa.ListaEnvioSunatAnulados(listaDocs, nroticket, IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante))


        Catch ex As Exception
            MessageBox.Show("No se Pudo Actualizar")
        End Try



    End Sub


    Private Sub LimpiarProductosIguales(idItem As Integer)
        For Each r As Record In GridGroupingControl1.Table.Records
            If Integer.Parse(r.GetValue("idDocumento")) = idItem Then
                r.Delete()
            End If
        Next
    End Sub


    Public Sub EnviarListaArticulos(lista As List(Of documentoventaAbarrotes)) Implements IListaDocumento.EnviarListaDocumento
        'LimpiarProductosIguales(lista(0).idDocumento)
        For Each i In lista
            'EnvioProductoSolo(i)



            LimpiarProductosIguales(i.idDocumento)


            'With GridGroupingControl1.Table
            '    .AddNewRecord.SetCurrent()
            '    .AddNewRecord.BeginEdit()
            '    .CurrentRecord.SetValue("serie", i.serieVenta)
            '    .CurrentRecord.SetValue("numero", i.numeroVenta)
            '    .CurrentRecord.SetValue("tipoDoc", i.tipoDocumento)
            '    .CurrentRecord.SetValue("afectado", i.serie)
            '    .CurrentRecord.SetValue("importe", i.ImporteNacional)
            '    .CurrentRecord.SetValue("idDocumento", i.idDocumento)
            '    .CurrentRecord.SetValue("motivo", "ANULACION DE DOCUMENTO")
            '    ' .CurrentRecord.SetValue("idProducto", productoBE.idItem)
            '    .AddNewRecord.EndEdit()
            '    .TableDirty = True
            'End With
            Me.GridGroupingControl1.Table.AddNewRecord.SetCurrent()
            Me.GridGroupingControl1.Table.AddNewRecord.BeginEdit()
            Me.GridGroupingControl1.Table.CurrentRecord.SetValue("serie", i.serieVenta)
            Me.GridGroupingControl1.Table.CurrentRecord.SetValue("numero", i.numeroVenta)
            Me.GridGroupingControl1.Table.CurrentRecord.SetValue("tipoDoc", i.tipoDocumento)
            Me.GridGroupingControl1.Table.CurrentRecord.SetValue("afectado", i.serie)
            Me.GridGroupingControl1.Table.CurrentRecord.SetValue("importe", i.ImporteNacional)
            Me.GridGroupingControl1.Table.CurrentRecord.SetValue("idDocumento", i.idDocumento)
            Me.GridGroupingControl1.Table.CurrentRecord.SetValue("motivo", "ANULACION DE DOCUMENTO")
            Me.GridGroupingControl1.Table.AddNewRecord.EndEdit()


        Next
        'ConteoLabelVentas()
        ''TotalTalesXcolumna()
        'TotalTalesXcolumnaEspecial()
    End Sub

    Sub FormatoGridAvanzado(GGC As GridGroupingControl, FullRowSelect As Boolean, AllowProportionalColumnSizing As Boolean)
        Dim colorx As New GridMetroColors()
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = BorderStyle.None
        '  GGC.BrowseOnly = True
        If FullRowSelect = True Then
            GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
            GGC.TableOptions.ListBoxSelectionCurrentCellOptions = GridListBoxSelectionCurrentCellOptions.HideCurrentCell
            GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
            GGC.TableOptions.SelectionBackColor = Color.Gray
        End If
        GGC.AllowProportionalColumnSizing = AllowProportionalColumnSizing
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        GGC.Table.DefaultColumnHeaderRowHeight = 27
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub


    Sub GetTableGrid()
        Dim dt As New DataTable()

        dt.Columns.Add("serie")
        dt.Columns.Add("numero")
        dt.Columns.Add("tipoDoc")
        dt.Columns.Add("motivo")
        dt.Columns.Add("afectado")



        dt.Columns.Add("importe")
        dt.Columns.Add("idDocumento")

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
    '    .NroDocumento = Gempresas.IdEmpresaRuc,
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


    Public Sub ComunicacionDeBaja()

        Try
            'Console.WriteLine("Ejemplo de Comunicación de Baja")
            Dim objetoBaja As DocumentoBaja
            Dim conteo As Integer = 0
            Dim numer As String = txtNumeracion.Text


            Dim documentoBaja As New ComunicacionBaja() With {
                .IdDocumento = String.Format("RA-{0:yyyyMMdd}-" & numer, DateTime.Today),
                .FechaEmision = DateTime.Today.ToString(FormatoFecha),
                .FechaReferencia = dtpFechaDocs.Value.ToString(FormatoFecha),'DateTime.Today.AddDays(-1).ToString(FormatoFecha),
               .Emisor = CrearEmisor(),
                .Bajas = New List(Of DocumentoBaja)()
            }

            ' En las comunicaciones de Baja ya no se pueden colocar boletas, ya que la anulacion de las mismas
            ' la realiza el resumen diario.

            For Each i In GridGroupingControl1.Table.Records
                conteo += 1

                objetoBaja = New DocumentoBaja
                objetoBaja.Id = conteo
                objetoBaja.Correlativo = String.Format("{0:00000000}", CInt(i.GetValue("numero")))
                objetoBaja.TipoDocumento = i.GetValue("tipoDoc")
                objetoBaja.Serie = i.GetValue("serie")
                objetoBaja.MotivoBaja = i.GetValue("motivo")
                documentoBaja.Bajas.Add(objetoBaja)
            Next


            'documentoBaja.Bajas.Add(New DocumentoBaja() With {
            '    .Id = 1,
            '    .Correlativo = "33386",
            '    .TipoDocumento = "01",
            '    .Serie = "FA50",
            '    .MotivoBaja = "Anulación por otro tipo de documento"
            '})
            'documentoBaja.Bajas.Add(New DocumentoBaja() With {
            '    .Id = 2,
            '    .Correlativo = "86486",
            '    .TipoDocumento = "01",
            '    .Serie = "FF14",
            '    .MotivoBaja = "Anulación por otro datos erroneos"
            '})

            'Console.WriteLine("Generando XML....")

            Dim documentoResponse = RestHelper(Of ComunicacionBaja, DocumentoResponse).Execute("GenerarComunicacionBaja", documentoBaja)
            If Not documentoResponse.Exito Then
                'Throw New InvalidOperationException(documentoResponse.MensajeError)

                'MessageBox.Show(documentoResponse.MensajeError)
                Throw New InvalidOperationException(documentoResponse.MensajeError)
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

                ' MessageBox.Show(responseFirma.MensajeError)
                Throw New InvalidOperationException(responseFirma.MensajeError)
            End If

            ' Console.WriteLine("Guardando XML de la Comunicacion de Baja....(Revisar carpeta del ejecutable)")

            'File.WriteAllBytes("C:\FACTURASELECTRONICAS\" + documentoBaja.IdDocumento + ".xml", Convert.FromBase64String(responseFirma.TramaXmlFirmado))

            'Console.WriteLine("Enviando a SUNAT....")

            Dim sendBill As New EnviarDocumentoRequest() With {
                .Ruc = documentoBaja.Emisor.NroDocumento,
               .UsuarioSol = "MARTIN88",
                .ClaveSol = "Samps008",
                .EndPointUrl = UrlSunat,
                .IdDocumento = documentoBaja.IdDocumento,
                .TramaXmlFirmado = responseFirma.TramaXmlFirmado
            }

            Dim enviarResumenResponse = RestHelper(Of EnviarDocumentoRequest, EnviarResumenResponse).Execute("EnviarResumen", sendBill)

            If Not enviarResumenResponse.Exito Then
                'Throw New InvalidOperationException(enviarResumenResponse.MensajeError)
                'MessageBox.Show(enviarResumenResponse.MensajeError)
                Throw New InvalidOperationException(enviarResumenResponse.MensajeError)

            End If


            File.WriteAllBytes("C:\FACTURASELECTRONICAS\COMUNICACION\" + enviarResumenResponse.NombreArchivo + ".xml", Convert.FromBase64String(responseFirma.TramaXmlFirmado))

            ActualizarEnvioSunat(enviarResumenResponse.NroTicket)

            'Console.WriteLine("Nro de Ticket: {0}", enviarResumenResponse.NroTicket)

            MessageBox.Show("Nro de Ticket:" + " " + enviarResumenResponse.NroTicket, "")

        Catch ex As Exception
            'MessageBox.Show("No se pudo generar el documento electronico")
            'Exit Sub

            Throw New InvalidOperationException("No se pudo generar el documento electronico")
        End Try

    End Sub

#End Region

    Private Sub frmComunicacionBajaFE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub frmComunicacionBajaFE_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dispose()
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        'Dim f As New frmCanastaDocumentos
        'f.ListarFacturas(dtpFechaDocs.Value)
        'f.StartPosition = FormStartPosition.CenterParent
        'f.Show(Me)


        CargarDocumentosAnulados(dtpFechaDocs.Value)
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        If GridGroupingControl1.Table.Records.Count > 0 Then

            Try
                ComunicacionDeBaja()
                CargarDocumentosAnulados(dtpFechaDocs.Value)

                ' ActualizarEnvioSunat()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Else
            MessageBox.Show("No hay documentos por enviar")
        End If

    End Sub
End Class