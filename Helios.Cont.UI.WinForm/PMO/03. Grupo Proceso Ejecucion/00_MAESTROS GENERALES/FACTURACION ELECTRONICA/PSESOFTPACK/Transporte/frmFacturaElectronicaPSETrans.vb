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

Public Class frmFacturaElectronicaPSETrans

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        GetTableGrid()
        FormatoGridAvanzado(GridGroupingControl1, False, False)
        ' Add any initialization after the InitializeComponent() call.
        txtPeriodo.Value = DateTime.Now
        ' Add any initialization after the InitializeComponent() call.

    End Sub

#Region "Metodos"

    Sub GetTableGrid()
        Dim dt As New DataTable()

        dt.Columns.Add("idDocumento")
        dt.Columns.Add("serie")
        dt.Columns.Add("numero")
        dt.Columns.Add("tipodoc")
        dt.Columns.Add("importe")
        dt.Columns.Add("enviosunat")
        dt.Columns.Add("fecha")
        GridGroupingControl1.DataSource = dt
    End Sub

    Public Sub EnviarFacturaElectronica(idDocumento As Integer, Tipo As String, estado As String)

        'Dim documentoSA As New documentoVentaAbarrotesSA
        'Dim documentoDetSA As New documentoVentaAbarrotesDetSA
        Dim DocumentoventaTransporteSA As New DocumentoventaTransporteSA
        Dim entidadSA As New entidadSA
        Dim DetalleFactura As Fact.Sunat.Business.Entity.DocumentoElectronicoDetalle
        Dim documneotventaTransporte As New documentoventaTransporte
        Dim item As New documentoventaTransporte
        item.idDocumento = idDocumento

        Try

            documneotventaTransporte = DocumentoventaTransporteSA.DocumentoTransporteSelID(item)


            'Dim comprobante = documentoSA.GetUbicar_documentoventaAbarrotesPorID(idDocumento)
            'Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(idDocumento)
            Dim receptor = entidadSA.GetUbicarEntPorID(Gempresas.IdEmpresaRuc, documneotventaTransporte.razonSocial)
            Dim numerovent As String = String.Format("{0:00000000}", documneotventaTransporte.numero)
            Dim tipoDoc = String.Format("{0:00}", documneotventaTransporte.tipoDocumento)
            Dim conteo As Integer = 0

            '//Enviando el documento

            Dim Factura As New Fact.Sunat.Business.Entity.DocumentoElectronico

            'Datos del Cliente 
            Factura.Action = 0
            Factura.idEmpresa = Gempresas.ubigeo   'lblIdPse.Text
            Factura.Contribuyente_id = Gempresas.IdEmpresaRuc
            Factura.EnvioSunat = "NO"
            'Receptor de la Factura
            Factura.NroDocumentoRec = receptor.nrodoc
            Factura.TipoDocumentoRec = receptor.tipoDoc
            Factura.NombreLegalRec = receptor.nombreCompleto
            'Datos Generales De La Factura
            Factura.IdDocumento = documneotventaTransporte.serie & "-" & numerovent
            Factura.FechaEmision = documneotventaTransporte.fechadoc
            Factura.FechaRecepcion = DateTime.Now 'fecha en la que se envia al PSE
            Factura.FechaVencimiento = DateTime.Now
            Factura.HoraEmision = documneotventaTransporte.fechadoc.Value.ToString("HH:mm:ss")
            'If documneotventaTransporte.moneda = "1" Then
            Factura.Moneda = "PEN"
            'ElseIf documneotventaTransporte.moneda = "2" Then
            'Factura.Moneda = "USD"
            'End If
            Factura.TipoDocumento = tipoDoc
            Factura.TotalIgv = documneotventaTransporte.igv1
            Factura.TotalVenta = documneotventaTransporte.total
            Factura.Gravadas = documneotventaTransporte.baseImponible1
            Factura.Exoneradas = 0
            Factura.TipoOperacion = "0101"

            'Cargando el Detalle de la Factura

            For Each i In documneotventaTransporte.documentoventaTransporteDetalle
                conteo += 1
                Dim preciounit As Decimal = Math.Round(CDec(i.importe / i.cantidad), 2)
                Dim calcbi As Decimal = Math.Round(CDec(CalculoBaseImponible(i.importe, 1.18)), 2)
                Dim calcigv As Decimal = Math.Round(CDec(i.importe - calcbi), 2)

                DetalleFactura = New Fact.Sunat.Business.Entity.DocumentoElectronicoDetalle
                DetalleFactura.Id = conteo
                DetalleFactura.Cantidad = i.cantidad
                DetalleFactura.PrecioReferencial = preciounit 'i.precioUnitario
                DetalleFactura.CodigoItem = i.secuencia
                DetalleFactura.Descripcion = i.detalle
                DetalleFactura.UnidadMedida = i.unidadMedida
                DetalleFactura.Impuesto = calcigv

                ' If i.destino = "1" Then
                DetalleFactura.TipoImpuesto = "10" 'CATALOGO 7
                DetalleFactura.TipoPrecio = "01" 'CATALOGO 16
                DetalleFactura.PrecioUnitario = CalculoBaseImponible(preciounit, 1.18) 'FormatNumber
                'ElseIf i.destino = "2" Then
                '  DetalleFactura.TipoImpuesto = "20" 'CATALOGO 7
                'DetalleFactura.TipoPrecio = "01" '"02"  'CATALOGO 16
                '  DetalleFactura.PrecioUnitario = i.precioUnitario
                'End If

                DetalleFactura.TotalVenta = calcbi 'i.montokardex
                'DetalleItems .Descuento = "falta"
                'DetalleItems .ImpuestoSelectivo = "falta"
                'DetalleItems.OtroImpuesto = "falta"
                'DetalleItems.PlacaVehiculo = "falta"
                Factura.DocumentoElectronicoDetalle.Add(DetalleFactura)
            Next


            'Enviando al PSE
            Dim codigo = Helios.Fact.Sunat.WCFService.ServiceAccess.Admin.DocumentoElectronicoSA.DocumentoElectronicoSaveValidado(Factura, Nothing)

            If codigo.idDocumentoElectronico > 0 Then

                UpdateEnvioSunatEstado(documneotventaTransporte.idDocumento, estado)
                'MessageBox.Show("La Factura se Envio Correctamente al PSE")
                'ButtonAdv2.Enabled = True
            End If

        Catch ex As Exception

            ' MessageBox.Show("No se Pudo Enviar")
            'ButtonAdv2.Enabled = True
        End Try



        'Try

        '    Dim Empresa As New Fact.Sunat.Business.Entity.empresa

        '    Empresa.ruc = "23423423"


        '    Dim CodigoCliente = Helios.Fact.Sunat.WCFService.ServiceAccess.Admin.empresaSA.empresaSelxID(Empresa)

        '    If CodigoCliente Is Nothing Then
        '        MessageBox.Show("El cliente no existe")
        '    End If




        '    Dim Factura As New Fact.Sunat.Business.Entity.DocumentoElectronico

        '    Factura.Action = 0
        '    Factura.NroDocumentoRec = "20100039207"
        '    Factura.TipoDocumentoRec = "6"
        '    Factura.NombreLegalRec = "RANSA COMERCIAL S.A."
        '    Factura.Contribuyente_id = "20601672309"
        '    Factura.EnvioSunat = "NO"
        '    Factura.idEmpresa = 2

        '    Factura.IdDocumento = "FF11-00009910"
        '    Factura.FechaEmision = DateTime.Now
        '    Factura.FechaEnvio = DateTime.Now
        '    Factura.FechaRecepcion = DateTime.Now
        '    Factura.FechaVencimiento = DateTime.Now
        '    Factura.HoraEmision = DateTime.Now.ToString("HH:mm:ss")
        '    Factura.Moneda = "PEN"
        '    Factura.TipoDocumento = "01"
        '    Factura.TotalIgv = 18
        '    Factura.TotalVenta = 118
        '    Factura.Gravadas = 100
        '    Factura.Exoneradas = 0

        '    Dim codigo = Helios.Fact.Sunat.WCFService.ServiceAccess.Admin.DocumentoElectronicoSA.DocumentoElectronicoSave(Factura, Nothing)

        '    If codigo.idDocumentoElectronico > 0 Then
        '        MessageBox.Show("Se envio Correctamente al PSE")

        '    End If
        'Catch ex As Exception

        '    MessageBox.Show("No se Pudo Enviar")

        'End Try
    End Sub

    Public Sub UpdateEnvioSunatEstado(idDoc As Integer, estado As String)
        Try

            Dim docSA As New DocumentoventaTransporteSA

            docSA.UpdateFacturasXEstadoTrans(idDoc, estado)

            'MessageBox.Show("Se Genero Correctamente")
        Catch ex As Exception
            'MessageBox.Show("No se Pudo Actualizar")
        End Try



    End Sub


    Public Sub BuscarDocsFechaPeriodo(fecha As DateTime, tipoDoc As String)
        Dim docSA As New DocumentoventaTransporteSA
        GridGroupingControl1.Table.Records.DeleteAll()
        Dim consulta = docSA.BuscarFacturanoEnviadasPeriodoTrans(fecha, tipoDoc, Gempresas.IdEmpresaRuc)

        If consulta.Count = 0 Then
            MessageBox.Show("No hay documentos por enviar")
            ButtonAdv2.Enabled = True
        Else
            For Each i In consulta
                Me.GridGroupingControl1.Table.AddNewRecord.SetCurrent()
                Me.GridGroupingControl1.Table.AddNewRecord.BeginEdit()
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("idDocumento", i.idDocumento)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("serie", i.serie)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("numero", i.numero)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("tipodoc", i.tipoDocumento)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("importe", i.total)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("enviosunat", i.EnvioSunat)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("fecha", i.fechadoc)
                Me.GridGroupingControl1.Table.AddNewRecord.EndEdit()


            Next
        End If

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

    '        'MessageBox.Show("ERROR")

    '    End Try

    'End Sub

#End Region

    Private Sub frmFacturaElectronicaPSETrans_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'usuariopse(Gempresas.IdEmpresaRuc)
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click




        Select Case ComboBox1.Text
            Case "FACTURA"
                BuscarDocsFechaPeriodo(txtPeriodo.Value, "01")
            Case "BOLETAS"
                BuscarDocsFechaPeriodo(txtPeriodo.Value, "03")
            Case "NOTAS DE CREDITO"
                   'BuscarDocsFechaPeriodo(txtPeriodo.Value, "07")
            Case "NOTA DE DEBITO"
                ' BuscarDocsFecha(dtpFechaDocs.Value, "08")
        End Select

    End Sub


    Public Sub ReEnviarFacturaElectronica(idDocumento As Integer, IdPse As String, estado As String)
        Try

            Dim documentoVenta As New DocumentoventaTransporteSA
            documentoVenta.ReEnviarFacturaElectronica(idDocumento, IdPse, estado)

        Catch ex As Exception
            MessageBox.Show("No se Pudo enviar el comprobante")
            ButtonAdv2.Enabled = True
        End Try


    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click


        Me.Cursor = Cursors.WaitCursor
        ButtonAdv2.Enabled = False
        'Dim r As Record

        If Not Gempresas.ubigeo > 0 Then
            MessageBox.Show("Problemas con El Servidor o no esta Registrado Comuniquese con el PSE")
            ButtonAdv2.Enabled = True
            Exit Sub
        End If

        '//nuevo
        Try

            For Each i In GridGroupingControl1.Table.Records

                If i.GetValue("idDocumento") > 0 Then
                    Select Case i.GetValue("tipodoc")
                        Case "01", "03"
                            Dim clas = (i.GetValue("enviosunat"))
                            If clas.ToString.Trim.Length > 0 Then
                                If i.GetValue("enviosunat") = "NE" Then
                                    EnviarFacturaElectronica(CInt(i.GetValue("idDocumento")), "FACTURA", "PE")
                                End If
                            Else
                                EnviarFacturaElectronica(CInt(i.GetValue("idDocumento")), "FACTURA", "SI")
                            End If

                        Case "07"
                            'EnviarNotaCreditoElectronico(CInt(i.GetValue("idDocumento")), "NOTAS DE CREDITO", "")
                        Case "08"
                    End Select

                Else
                    MessageBox.Show("Seleccione un Documento para Enviar")
                    ButtonAdv2.Enabled = True
                    Me.Cursor = Cursors.Default
                End If



            Next

            Select Case ComboBox1.Text
                Case "FACTURA"
                    BuscarDocsFechaPeriodo(txtPeriodo.Value, "01")
                Case "BOLETAS"
                    BuscarDocsFechaPeriodo(txtPeriodo.Value, "01")
                Case "NOTAS DE CREDITO"
                    BuscarDocsFechaPeriodo(txtPeriodo.Value, "07")
                Case "NOTA DE DEBITO"
                    BuscarDocsFechaPeriodo(txtPeriodo.Value, "08")
            End Select
            ButtonAdv2.Enabled = True
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            ButtonAdv2.Enabled = True
            Me.Cursor = Cursors.Default
        End Try
        'enddd






        'Try
        '    r = GridGroupingControl1.Table.CurrentRecord

        '    If r.GetValue("idDocumento") > 0 Then
        '        Select Case r.GetValue("tipodoc")
        '            Case "01", "03"
        '                Dim clas = (r.GetValue("enviosunat"))
        '                If clas.ToString.Trim.Length > 0 Then
        '                    If r.GetValue("enviosunat") = "NE" Then
        '                        EnviarFacturaElectronica(CInt(r.GetValue("idDocumento")), "FACTURA", "PE")
        '                    End If
        '                Else
        '                    EnviarFacturaElectronica(CInt(r.GetValue("idDocumento")), "FACTURA", "SI")
        '                End If
        '            Case "07"
        '                EnviarNotaCreditoElectronico(CInt(r.GetValue("idDocumento")), "NOTAS DE CREDITO", "")
        '            Case "08"
        '        End Select


        '        Select Case ComboBox1.Text
        '            Case "FACTURA"
        '                BuscarDocsFechaPeriodo(txtPeriodo.Value, "01")
        '            Case "BOLETAS"
        '                BuscarDocsFechaPeriodo(txtPeriodo.Value, "01")
        '            Case "NOTAS DE CREDITO"
        '                BuscarDocsFechaPeriodo(txtPeriodo.Value, "07")
        '            Case "NOTA DE DEBITO"
        '                BuscarDocsFechaPeriodo(txtPeriodo.Value, "08")
        '        End Select
        '    Else
        '        MessageBox.Show("Seleccione un Documento para Enviar")
        '        ButtonAdv2.Enabled = True
        '    End If
        '    ButtonAdv2.Enabled = True
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    ButtonAdv2.Enabled = True
        'End Try







        'Me.Cursor = Cursors.WaitCursor
        'ButtonAdv2.Enabled = False
        'Dim x As Record
        'x = GridGroupingControl1.Table.CurrentRecord

        'If Gempresas.ubigeo > 0 Then
        '    If My.Computer.Network.IsAvailable = True Then
        '        If My.Computer.Network.Ping("148.102.27.231") Then

        '            If x.GetValue("idDocumento") > 0 Then
        '                Select Case x.GetValue("tipodoc")
        '                    Case "01", "03"
        '                        Dim clas = (x.GetValue("enviosunat"))
        '                        If clas.ToString.Trim.Length > 0 Then
        '                            If x.GetValue("enviosunat") = "NE" Then
        '                                ReEnviarFacturaElectronica(CInt(x.GetValue("idDocumento")), Gempresas.ubigeo, "PE")
        '                                BuscarDocsFechaPeriodo(txtPeriodo.Value, x.GetValue("tipodoc"))
        '                            End If
        '                        Else
        '                            ReEnviarFacturaElectronica(CInt(x.GetValue("idDocumento")), Gempresas.ubigeo, "SI")
        '                            BuscarDocsFechaPeriodo(txtPeriodo.Value, x.GetValue("tipodoc"))
        '                        End If
        '                    Case "07"
        '                        ReEnviarNotaCreditoElectronico(CInt(x.GetValue("idDocumento")), Gempresas.ubigeo, "")
        '                        BuscarDocsFechaPeriodo(txtPeriodo.Value, x.GetValue("tipodoc"))
        '                    Case "08"
        '                End Select

        '            Else
        '                MessageBox.Show("Seleccione un Documento para Enviar")
        '                ButtonAdv2.Enabled = True
        '            End If

        '        End If
        '    End If
        'End If
        'ButtonAdv2.Enabled = True
        'Me.Cursor = Cursors.Default


        '/////////////////////////

        'ButtonAdv2.Enabled = False
        'Dim r As Record

        ''If Not lblIdPse.Text > 0 Then

        ''    MessageBox.Show("Problemas con El Servidor o no esta Registrado Comuniquese con el PSE")
        ''    ButtonAdv2.Enabled = True
        ''    Exit Sub
        ''End If

        'Try
        '    r = GridGroupingControl1.Table.CurrentRecord

        '    If Gempresas.ubigeo > 0 Then
        '        If My.Computer.Network.IsAvailable = True Then
        '            If My.Computer.Network.Ping("148.102.27.231") Then

        '                If r.GetValue("idDocumento") > 0 Then

        '                    Select Case r.GetValue("tipodoc")
        '                        Case "01", "03"


        '                            Dim clas = (r.GetValue("enviosunat"))
        '                            If clas.ToString.Trim.Length > 0 Then
        '                                If r.GetValue("enviosunat") = "NE" Then
        '                                    'ReEnviarFacturaElectronica(CInt(r.GetValue("idDocumento")), Gempresas.ubigeo, "PE")
        '                                    EnviarFacturaElectronica(CInt(r.GetValue("idDocumento")), "FACTURA", "PE")
        '                                    BuscarDocsFechaPeriodo(txtPeriodo.Value, r.GetValue("tipodoc"))
        '                                End If
        '                            Else
        '                                EnviarFacturaElectronica(CInt(r.GetValue("idDocumento")), "FACTURA", "SI")
        '                                'ReEnviarFacturaElectronica(CInt(r.GetValue("idDocumento")), Gempresas.ubigeo, "SI")
        '                                BuscarDocsFechaPeriodo(txtPeriodo.Value, r.GetValue("tipodoc"))
        '                            End If

        '                'Dim clas = (r.GetValue("enviosunat"))

        '                'If clas.ToString.Trim.Length > 0 Then

        '                '    If r.GetValue("enviosunat") = "NE" Then
        '                '        EnviarFacturaElectronica(CInt(r.GetValue("idDocumento")), "FACTURA", "PE")
        '                '    End If

        '                'Else

        '                '    EnviarFacturaElectronica(CInt(r.GetValue("idDocumento")), "FACTURA", "SI")

        '                'End If



        '                'If r.GetValue("enviosunat") = "NE" Then
        '                '    GenerarFacturaElectronica(CInt(r.GetValue("idDocumento")), "FACTURA", "PE")

        '                'ElseIf r.GetValue("enviosunat") = Nothing Then

        '                '    GenerarFacturaElectronica(CInt(r.GetValue("idDocumento")), "FACTURA", "SI")

        '                'End If

        '                        Case "07"
        '               ' EnviarNotaCreditoElectronico(CInt(r.GetValue("idDocumento")), "NOTAS DE CREDITO", "")
        '                        Case "08"

        '                    End Select

        '                    'GenerarFacturaElectronica(CInt(r.GetValue("idDocumento")))
        '                    ' UpdateEnvioSunat(CInt(r.GetValue("idDocumento")))


        '                    'Select Case ComboBox1.Text
        '                    '    Case "FACTURA"
        '                    '        'BuscarDocsFecha(dtpFechaDocs.Value, "01")
        '                    '        BuscarDocsFechaPeriodo(txtPeriodo.Value, "01")

        '                    '        'Case "NOTAS DE CREDITO"
        '                    '        ''BuscarDocsFecha(dtpFechaDocs.Value, "07")
        '                    '        ' BuscarDocsFechaPeriodo(txtPeriodo.Value, "07")
        '                    '        '  Case "NOTA DE DEBITO"
        '                    '        ' 'BuscarDocsFecha(dtpFechaDocs.Value, "08")
        '                    '        ' BuscarDocsFechaPeriodo(txtPeriodo.Value, "08")
        '                    'End Select
        '                Else
        '                    MessageBox.Show("Seleccione un Documento para Enviar")
        '                    ButtonAdv2.Enabled = True
        '                End If


        '            End If
        '        End If
        '    End If

        '    ButtonAdv2.Enabled = True
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    ButtonAdv2.Enabled = True
        'End Try
    End Sub
End Class