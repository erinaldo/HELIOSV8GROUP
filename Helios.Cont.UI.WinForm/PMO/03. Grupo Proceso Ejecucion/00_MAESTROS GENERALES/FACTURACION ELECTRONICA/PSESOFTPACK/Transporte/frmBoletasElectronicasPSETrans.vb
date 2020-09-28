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

Public Class frmBoletasElectronicasPSETrans

#Region "cONSTRUCTOR"

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        GetTableGrid()
        FormatoGridAvanzado(GridGroupingControl1, False, False)
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        'Dim strIDEmpresa = Gempresas.IdEmpresaRuc
        'GetNumeracion("RSD", strIDEmpresa)
        ' Add any initialization after the InitializeComponent() call.

    End Sub

#End Region

#Region "METODOS"

    Public Sub EnviarnBoletaAnulada(tipo As String)

        Dim numeracionsa As New NumeracionBoletaSA

        Dim numerobaja = numeracionsa.GenerarNumeroXTipo(GEstableciento.IdEstablecimiento, "RSD", "03")
        'Dim numerobaja = numeracionsa.GenerarNumeroBaja(GConfiguracion2.ConfigComprobante)
        Dim numer As String = String.Format("{0:00000}", CInt(numerobaja))
        Dim DocumentoSA As New DocumentoventaTransporteSA
        Dim objeto As Helios.Fact.Sunat.Business.Entity.DocumentoResumenDetalle
        Dim Resumen = New Helios.Fact.Sunat.Business.Entity.DocumentoResumen

        Try
            Dim r As Record
            r = GridGroupingControl1.Table.CurrentRecord

            If r.GetValue("idDocumento") > 0 Then
                Resumen.Action = 0
                Resumen.idEmpresa = Gempresas.ubigeo
                Resumen.Contribuyente_id = Gempresas.IdEmpresaRuc
                Resumen.IdDocumento = String.Format("RC-{0:yyyyMMdd}-" & numer, DateTime.Today)
                Resumen.FechaEmision = DateTime.Now
                Resumen.FechaReferencia = CDate(r.GetValue("fecha"))
                Resumen.FechaRecepcion = DateTime.Now
                Resumen.EnvioSunat = "NO"
                Resumen.Grupo = "NO"

                'Resumen.TipoResumen = tipo
                Select Case ComboBox1.Text
                    Case "BOLETAS"
                        Resumen.TipoResumen = "03"
                    Case "NOTAS DE CREDITO"
                        Resumen.TipoResumen = "07"
                    Case "NOTA DE DEBITO"
                        Resumen.TipoResumen = "08"
                    Case "ANULADOS"
                        Resumen.TipoResumen = "AN"
                End Select


                If r.GetValue("tipoDoc") = "03" Then
                    objeto = New Helios.Fact.Sunat.Business.Entity.DocumentoResumenDetalle

                    objeto.idSecuencia = 1
                    objeto.TipoDocumento = r.GetValue("tipoDoc")
                    objeto.IdDocumento = r.GetValue("nroDoc")
                    objeto.NroDocumentoReceptor = r.GetValue("docCliente")
                    objeto.TipoDocumentoReceptor = r.GetValue("tipoDocCliente")
                    objeto.CodigoEstadoItem = CInt(r.GetValue("estado"))
                    objeto.Moneda = r.GetValue("moneda")
                    objeto.TotalVenta = CDec(r.GetValue("importe"))
                    objeto.TotalIgv = CDec(r.GetValue("igv"))
                    objeto.Gravadas = CDec(r.GetValue("gravado"))
                    objeto.Exoneradas = CDec(r.GetValue("exonerado"))

                    Resumen.DocumentoResumenDetalle.Add(objeto)

                ElseIf r.GetValue("tipoDoc") = "07" Then

                    objeto = New Helios.Fact.Sunat.Business.Entity.DocumentoResumenDetalle

                    objeto.idSecuencia = 1
                    objeto.TipoDocumento = r.GetValue("tipoDoc")
                    objeto.IdDocumento = r.GetValue("nroDoc")

                    objeto.NroDocumentoReceptor = r.GetValue("docCliente")
                    objeto.TipoDocumentoReceptor = r.GetValue("tipoDocCliente")
                    objeto.CodigoEstadoItem = CInt(r.GetValue("estado"))
                    objeto.Moneda = r.GetValue("moneda")
                    objeto.TotalVenta = CDec(r.GetValue("importe"))
                    objeto.TotalIgv = CDec(r.GetValue("igv"))
                    objeto.Gravadas = CDec(r.GetValue("gravado"))
                    objeto.Exoneradas = CDec(r.GetValue("exonerado"))
                    objeto.TipoDocumentoRelacionado = r.GetValue("nroRel")
                    objeto.DocumentoRelacionado = r.GetValue("docRel")

                    Resumen.DocumentoResumenDetalle.Add(objeto)

                End If

                'Enviando al PSE
                Dim codigo = Helios.Fact.Sunat.WCFService.ServiceAccess.Admin.DocumentoResumenSA.DocumentoResumenSaveValidado(Resumen, Nothing)

                If codigo.idResumen > 0 Then
                    DocumentoSA.UpdateAnulacionEnviada(r.GetValue("idDocumento"), numerobaja, 0)
                    MessageBox.Show("El Resumen se Envio Correctamente al PSE")
                    ButtonAdv2.Enabled = True
                End If
            End If
        Catch ex As Exception

            MessageBox.Show("No se Pudo Enviar")
            ButtonAdv2.Enabled = True
        End Try
    End Sub


    'Public Sub usuariopse(idempresa As String)

    '    Try

    '        Dim Empresa As New Fact.Sunat.Business.Entity.empresa

    '        Empresa.ruc = idempresa


    '        Dim CodigoCliente = Helios.Fact.Sunat.WCFService.ServiceAccess.Admin.empresaSA.empresaSelxID(Empresa)

    '        If CodigoCliente Is Nothing Then
    '            'MessageBox.Show("Contactese con el PSE")
    '        Else
    '            lblIdPse.Text = CodigoCliente.idEmpresa
    '        End If

    '    Catch ex As Exception

    '        ' MessageBox.Show("ERROR")

    '    End Try

    'End Sub

    Public Sub ActualizarBoletas(listaBoletas As List(Of documentoventaTransporte), idNum As Integer, nroTicket As String)



        Dim documentoventasa As New DocumentoventaTransporteSA
        'Dim objeto As documentoventaAbarrotes
        'Dim listaDocs As New List(Of documentoventaAbarrotes)


        Try


            'For Each i In GridGroupingControl1.Table.Records


            '    objeto = New documentoventaAbarrotes

            '    objeto.idDocumento = i.GetValue("idDocumento")

            '    listaDocs.Add(objeto)
            'Next

            documentoventasa.ListaEnvioSunatResumenTrans(listaBoletas, idNum, nroTicket)


        Catch ex As Exception
            MessageBox.Show("No se Pudo Actualizar")
        End Try



    End Sub

    'Public Sub EnviarResumenBoletas(tipo As String)

    '    Dim numer As String = String.Format("{0:00000}", CInt(txtNumeracion.Text))
    '    Dim documentos As documentoventaTransporte
    '    Dim listaActEstado As New List(Of documentoventaTransporte)
    '    Dim objeto As Helios.Fact.Sunat.Business.Entity.DocumentoResumenDetalle
    '    Dim Resumen = New Helios.Fact.Sunat.Business.Entity.DocumentoResumen
    '    Dim conteo As Integer = 0

    '    Try

    '        Resumen.Action = 0
    '        Resumen.idEmpresa = lblIdPse.Text
    '        Resumen.Contribuyente_id = Gempresas.IdEmpresaRuc
    '        Resumen.IdDocumento = String.Format("RC-{0:yyyyMMdd}-" & numer, DateTime.Today)
    '        Resumen.FechaEmision = DateTime.Now
    '        Resumen.FechaReferencia = dtpFechaDocs.Value
    '        Resumen.FechaRecepcion = DateTime.Now
    '        Resumen.EnvioSunat = "NO"
    '        'Resumen.TipoResumen = tipo
    '        Select Case ComboBox1.Text
    '            Case "BOLETAS"
    '                Resumen.TipoResumen = "03"
    '            Case "NOTAS DE CREDITO"
    '                Resumen.TipoResumen = "07"
    '            Case "NOTA DE DEBITO"
    '                Resumen.TipoResumen = "08"
    '            Case "ANULADOS"
    '                Resumen.TipoResumen = "AN"
    '        End Select



    '        For Each i In GridGroupingControl1.Table.Records
    '            documentos = New documentoventaTransporte
    '            If i.GetValue("tipoDoc") = "03" Then
    '                objeto = New Helios.Fact.Sunat.Business.Entity.DocumentoResumenDetalle
    '                conteo += 1
    '                objeto.idSecuencia = conteo
    '                objeto.TipoDocumento = i.GetValue("tipoDoc")
    '                objeto.IdDocumento = i.GetValue("nroDoc")
    '                objeto.NroDocumentoReceptor = i.GetValue("docCliente")
    '                objeto.TipoDocumentoReceptor = i.GetValue("tipoDocCliente")
    '                objeto.CodigoEstadoItem = CInt(i.GetValue("estado"))
    '                objeto.Moneda = i.GetValue("moneda")
    '                objeto.TotalVenta = CDec(i.GetValue("importe"))
    '                objeto.TotalIgv = CDec(i.GetValue("igv"))
    '                objeto.Gravadas = CDec(i.GetValue("gravado"))
    '                objeto.Exoneradas = CDec(i.GetValue("exonerado"))

    '                documentos.idDocumento = CInt(i.GetValue("idDocumento"))

    '                Resumen.DocumentoResumenDetalle.Add(objeto)
    '                listaActEstado.Add(documentos)

    '            ElseIf i.GetValue("tipoDoc") = "07" Then

    '                'objeto = New Helios.Fact.Sunat.Business.Entity.DocumentoResumenDetalle
    '                'conteo += 1
    '                'objeto.idSecuencia = conteo
    '                'objeto.TipoDocumento = i.GetValue("tipoDoc")
    '                'objeto.IdDocumento = i.GetValue("nroDoc")


    '                'objeto.NroDocumentoReceptor = i.GetValue("docCliente")
    '                'objeto.TipoDocumentoReceptor = i.GetValue("tipoDocCliente")
    '                'objeto.CodigoEstadoItem = CInt(i.GetValue("estado"))
    '                'objeto.Moneda = i.GetValue("moneda")
    '                'objeto.TotalVenta = CDec(i.GetValue("importe"))
    '                'objeto.TotalIgv = CDec(i.GetValue("igv"))
    '                'objeto.Gravadas = CDec(i.GetValue("gravado"))
    '                'objeto.Exoneradas = CDec(i.GetValue("exonerado"))
    '                'objeto.TipoDocumentoRelacionado = i.GetValue("nroRel")
    '                'objeto.DocumentoRelacionado = i.GetValue("docRel")

    '                'documentos.idDocumento = CInt(i.GetValue("idDocumento"))

    '                'Resumen.DocumentoResumenDetalle.Add(objeto)
    '                'listaActEstado.Add(documentos)

    '            End If
    '        Next



    '        'Enviando al PSE
    '        Dim codigo = Helios.Fact.Sunat.WCFService.ServiceAccess.Admin.DocumentoResumenSA.DocumentoResumenSave(Resumen, Nothing)

    '        If codigo.idResumen > 0 Then

    '            ActualizarBoletas(listaActEstado, IIf(IsNothing(conf.ConfigComprobante), 0, conf.ConfigComprobante), "0")
    '            MessageBox.Show("El Resumen se Envio Correctamente al PSE")
    '        End If

    '    Catch ex As Exception

    '        MessageBox.Show("No se Pudo Enviar")
    '        ButtonAdv2.Enabled = True
    '    End Try
    'End Sub


    Public Sub BuscarBoletasAnuladasPeriodoTrans(fecha As DateTime)


        Dim docSA As New DocumentoventaTransporteSA

        GridGroupingControl1.Table.Records.DeleteAll()

        Dim consulta = docSA.BuscarBoletasAnuladasPeriodoTrans(fecha, Gempresas.IdEmpresaRuc)

        If consulta.Count = 0 Then

            MessageBox.Show("No hay documentos por enviar")
            ButtonAdv2.Enabled = True
            ButtonAdv1.Enabled = True
        Else
            For Each i In consulta

                Dim numerovent As String = String.Format("{0:00000000}", i.numero)

                Me.GridGroupingControl1.Table.AddNewRecord.SetCurrent()
                Me.GridGroupingControl1.Table.AddNewRecord.BeginEdit()
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("idDocumento", i.idDocumento)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("nroDoc", i.serie & "-" & numerovent) 'i.numeroVenta)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("tipoDoc", i.tipoDocumento)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("tipoDocCliente", i.tipDocClie)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("docCliente", i.nrodoc)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("estado", "3")

                If i.moneda = "1" Then
                    Me.GridGroupingControl1.Table.CurrentRecord.SetValue("moneda", "PEN")
                ElseIf i.moneda = "2" Then
                    Me.GridGroupingControl1.Table.CurrentRecord.SetValue("moneda", "USD")
                End If


                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("igv", i.igv1)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("gravado", i.baseImponible1)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("importe", i.total)

                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("exonerado", i.baseImponible2)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("fecha", i.fechadoc)
                Me.GridGroupingControl1.Table.AddNewRecord.EndEdit()
            Next
        End If
    End Sub

    Public Sub BuscarBoletasAnuladas(fecha As DateTime)


        Dim docSA As New DocumentoventaTransporteSA

        GridGroupingControl1.Table.Records.DeleteAll()

        Dim consulta = docSA.BuscarBoletasAnuladasTrans(fecha, Gempresas.IdEmpresaRuc)

        If consulta.Count = 0 Then

            MessageBox.Show("No hay documentos por enviar")
            ButtonAdv2.Enabled = True
            ButtonAdv1.Enabled = True
        Else
            For Each i In consulta

                Dim numerovent As String = String.Format("{0:00000000}", i.numero)

                Me.GridGroupingControl1.Table.AddNewRecord.SetCurrent()
                Me.GridGroupingControl1.Table.AddNewRecord.BeginEdit()
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("idDocumento", i.idDocumento)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("nroDoc", i.serie & "-" & numerovent) 'i.numeroVenta)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("tipoDoc", i.tipoDocumento)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("tipoDocCliente", i.tipDocClie)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("docCliente", i.nrodoc)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("estado", "3")

                If i.moneda = "1" Then
                    Me.GridGroupingControl1.Table.CurrentRecord.SetValue("moneda", "PEN")
                ElseIf i.moneda = "2" Then
                    Me.GridGroupingControl1.Table.CurrentRecord.SetValue("moneda", "USD")
                End If


                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("igv", i.igv1)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("gravado", i.baseImponible1)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("importe", i.total)

                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("exonerado", i.baseImponible2)

                Me.GridGroupingControl1.Table.AddNewRecord.EndEdit()
            Next
        End If
    End Sub

    Public Sub NotasCreditoBoleta(fecha As DateTime)


        Dim docSA As New documentoVentaAbarrotesSA

        GridGroupingControl1.Table.Records.DeleteAll()

        Dim consulta = docSA.NotasCreditoBoleta(fecha, "07", Gempresas.IdEmpresaRuc)

        If consulta.Count = 0 Then

            MessageBox.Show("No hay documentos por enviar")
            ButtonAdv2.Enabled = True
        Else


            For Each i In consulta

                Dim numerovent As String = String.Format("{0:00000000}", i.numeroVenta)
                Dim numeroventrel As String = String.Format("{0:00000000}", i.numeroDoc)

                Me.GridGroupingControl1.Table.AddNewRecord.SetCurrent()
                Me.GridGroupingControl1.Table.AddNewRecord.BeginEdit()
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("idDocumento", i.idDocumento)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("nroDoc", i.serieVenta & "-" & numerovent) 'i.numeroVenta)
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


                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("docRel", i.serie & "-" & numeroventrel) 'i.numeroDoc)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("nroRel", i.TipoDocNota)

                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("exonerado", i.bi02)

                Me.GridGroupingControl1.Table.AddNewRecord.EndEdit()
            Next
        End If
    End Sub

    Public Sub BuscarDocsFecha(fecha As DateTime)


        Dim docSA As New DocumentoventaTransporteSA

        GridGroupingControl1.Table.Records.DeleteAll()

        Dim consulta = docSA.BuscarFacturanoEnviadasTrans(fecha, "03", Gempresas.IdEmpresaRuc)

        If consulta.Count = 0 Then
            MessageBox.Show("No hay documentos por enviar")
            ButtonAdv2.Enabled = True
            ButtonAdv1.Enabled = True
        Else


            For Each i In consulta

                Dim numerovent As String = String.Format("{0:00000000}", i.numero)

                Me.GridGroupingControl1.Table.AddNewRecord.SetCurrent()
                Me.GridGroupingControl1.Table.AddNewRecord.BeginEdit()
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("idDocumento", i.idDocumento)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("nroDoc", i.serie & "-" & numerovent) 'i.numeroVenta)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("tipoDoc", i.tipoDocumento)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("tipoDocCliente", i.tipDocClie)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("docCliente", i.nrodoc)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("estado", "1")

                If i.moneda = "1" Then
                    Me.GridGroupingControl1.Table.CurrentRecord.SetValue("moneda", "PEN")
                ElseIf i.moneda = "2" Then
                    Me.GridGroupingControl1.Table.CurrentRecord.SetValue("moneda", "USD")
                End If


                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("igv", i.igv1)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("gravado", i.baseImponible1)

                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("importe", i.total)

                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("exonerado", i.baseImponible2)


                Me.GridGroupingControl1.Table.AddNewRecord.EndEdit()
            Next
        End If
    End Sub

    'Dim conf As New GConfiguracionModulo
    'Private Sub GetNumeracion(strIdModulo As String, strIDEmpresa As String)
    '    Dim moduloConfiguracionSA As New ModuloConfiguracionSA
    '    Dim moduloConfiguracion As New moduloConfiguracion
    '    moduloConfiguracion = moduloConfiguracionSA.UbicarConfiguracionPorEmpresaModulo(strIdModulo, strIDEmpresa)
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
        dt.Columns.Add("exonerado")
        dt.Columns.Add("fecha")

        GridGroupingControl1.DataSource = dt
    End Sub

#End Region

    Private Sub frmBoletasElectronicasPSETrans_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'usuariopse(Gempresas.IdEmpresaRuc)

        txtPeriodo.Value = DateTime.Now
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        ButtonAdv1.Enabled = False
        Select Case ComboBox1.Text
            Case "BOLETAS"
                'BuscarDocsFecha(dtpFechaDocs.Value)
            Case "NOTAS DE CREDITO"
                'NotasCreditoBoleta(dtpFechaDocs.Value)
            Case "NOTA DE DEBITO"

            Case "ANULADOS"
                'BuscarBoletasAnuladas(dtpFechaDocs.Value)
                BuscarBoletasAnuladasPeriodoTrans(txtPeriodo.Value)
        End Select
        ButtonAdv1.Enabled = True
    End Sub


    Public Sub ReenviarDocumentoEliminado(idDocumento As Integer, idPsE As String)
        Try
            Dim objetosa As New DocumentoventaTransporteSA

            objetosa.ReenviarDocumentoEliminado(idDocumento, idPsE)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        'ButtonAdv2.Enabled = False
        'If Not lblIdPse.Text > 0 Then

        '    MessageBox.Show("Problemas con El Servidor o no esta Registrado Comuniquese con el PSE")
        '    ButtonAdv2.Enabled = True
        '    Exit Sub
        'End If

        'If GridGroupingControl1.Table.Records.Count > 0 Then

        '    Try
        '        EnviarResumenBoletas("03")


        '        Select Case ComboBox1.Text
        '            Case "BOLETAS"
        '                BuscarDocsFecha(dtpFechaDocs.Value)
        '            Case "NOTAS DE CREDITO"
        '                NotasCreditoBoleta(dtpFechaDocs.Value)
        '            Case "NOTA DE DEBITO"

        '            Case "ANULADOS"
        '                BuscarBoletasAnuladas(dtpFechaDocs.Value)

        '        End Select

        '        Dim strIDEmpresa = Gempresas.IdEmpresaRuc
        '        GetNumeracion("RSD", strIDEmpresa)
        '        'ActualizarEnvioSunat()
        '    Catch ex As Exception
        '        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        ButtonAdv2.Enabled = True
        '    End Try
        'Else
        '    MessageBox.Show("No hay Documentos para enviar")
        '    ButtonAdv2.Enabled = True
        'End If
        'ButtonAdv2.Enabled = True

        ButtonAdv2.Enabled = False
        Me.Cursor = Cursors.WaitCursor

        If Not Gempresas.ubigeo > 0 Then
            MessageBox.Show("Problemas con El Servidor o no esta Registrado Comuniquese con el PSE")
            ButtonAdv2.Enabled = True
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        If Not My.Computer.Network.IsAvailable = True Then
            MessageBox.Show("No tiene Conexion a intenert para hacer el envio")
            ButtonAdv2.Enabled = True
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        If Not My.Computer.Network.Ping("138.128.171.106") Then
            MessageBox.Show("Problemas con El Servidor o no esta Registrado Comuniquese con el PSE")
            ButtonAdv2.Enabled = True
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If GridGroupingControl1.Table.Records.Count > 0 Then

            Try
                Dim r As Record
                r = GridGroupingControl1.Table.CurrentRecord
                If r.GetValue("idDocumento") > 0 Then

                    EnviarnBoletaAnulada("03")
                    'ReenviarDocumentoEliminado(CInt(r.GetValue("idDocumento")), Gempresas.ubigeo)

                    BuscarBoletasAnuladasPeriodoTrans(txtPeriodo.Value)

                Else
                    MessageBox.Show("Seleccione una boleta para comunicar")
                    Me.Cursor = Cursors.Default
                End If

            Catch ex As Exception
                ButtonAdv2.Enabled = True
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Cursor = Cursors.Default
            End Try

            ButtonAdv2.Enabled = True
            Me.Cursor = Cursors.Default
        Else
            MessageBox.Show("No hay Documentos para enviar")
            ButtonAdv2.Enabled = True
            Me.Cursor = Cursors.Default
        End If
        Me.Cursor = Cursors.Default


    End Sub
End Class