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

Public Class frmComunicacionBajaPSETrans

#Region "Constructor"
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        GetTableGrid()

        FormatoGridAvanzado(GridGroupingControl1, False, False)
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        'Dim strIDEmpresa = Gempresas.IdEmpresaRuc
        'GetNumeracion("BAJA", strIDEmpresa)
        ' Add any initialization after the InitializeComponent() call.

    End Sub
#End Region

#Region "METODOS"

    Public Sub EnviarBajaFactura()

        Dim objetoBaja As Helios.Fact.Sunat.Business.Entity.ComunicacionBajaDetalle
        Dim comunicacion As New Helios.Fact.Sunat.Business.Entity.ComunicacionBaja

        Dim numeracionsa As New NumeracionBoletaSA
        Dim DocumentoSA As New DocumentoventaTransporteSA
        Dim numerobaja = numeracionsa.GenerarNumeroXTipo(GEstableciento.IdEstablecimiento, "BAJA", "01")
        'Dim numerobaja = numeracionsa.GenerarNumeroBaja(GConfiguracion2.ConfigComprobante)

        Try

            Dim r As Record


            r = GridGroupingControl1.Table.CurrentRecord

            If r.GetValue("idDocumento") > 0 Then
                'CABEZERA
                comunicacion.Action = 0
                comunicacion.idEmpresa = Gempresas.ubigeo
                comunicacion.IdDocumento = String.Format("RA-{0:yyyyMMdd}-" & numerobaja, DateTime.Today)
                comunicacion.FechaEmision = DateTime.Now
                comunicacion.FechaReferencia = CDate(r.GetValue("fecha"))
                comunicacion.FechaRecepcion = DateTime.Now
                comunicacion.EnvioSunat = "NO"
                comunicacion.Contribuyente_id = Gempresas.IdEmpresaRuc
                'DETALLE
                objetoBaja = New Helios.Fact.Sunat.Business.Entity.ComunicacionBajaDetalle
                objetoBaja.Id = 1
                objetoBaja.Serie = r.GetValue("serie")
                objetoBaja.Correlativo = String.Format("{0:00000000}", CInt(r.GetValue("numero")))
                objetoBaja.TipoDocumento = r.GetValue("tipoDoc")
                objetoBaja.MotivoBaja = r.GetValue("motivo")
                comunicacion.ComunicacionBajaDetalle.Add(objetoBaja)

                Dim codigo = Helios.Fact.Sunat.WCFService.ServiceAccess.Admin.ComunicacionBajaSA.ComunicacionBajaSaveValidado(comunicacion, Nothing)

                If codigo.idComunicacion > 0 Then
                    'ActualizarEnvioSunat("0")
                    DocumentoSA.UpdateAnulacionEnviada(r.GetValue("idDocumento"), numerobaja, 0)

                    MessageBox.Show("La comunicacion se Envio Correctamente al PSE")
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

    '        'MessageBox.Show("ERROR")

    '    End Try

    'End Sub

    'Public Sub ActualizarEnvioSunat(nroticket As String)



    '    Dim documentoventasa As New DocumentoventaTransporteSA
    '    Dim objeto As documentoventaTransporte
    '    Dim listaDocs As New List(Of documentoventaTransporte)


    '    Try


    '        For Each i In GridGroupingControl1.Table.Records


    '            objeto = New documentoventaTransporte

    '            objeto.idDocumento = i.GetValue("idDocumento")

    '            listaDocs.Add(objeto)
    '        Next

    '        'documentoventasa.ListaEnvioSunatAnulado(listaDocs, nroticket, IIf(IsNothing(conf.ConfigComprobante), 0, 
    '        documentoventasa.ListaEnvioSunatAnuladosTrans(listaDocs, nroticket, IIf(IsNothing(conf.ConfigComprobante), 0, conf.ConfigComprobante))


    '    Catch ex As Exception
    '        MessageBox.Show("No se Pudo Actualizar")
    '    End Try



    'End Sub

    'Public Sub EnviarComunicacionBaja()
    '    Dim conteo As Integer = 0
    '    Dim objetoBaja As Helios.Fact.Sunat.Business.Entity.ComunicacionBajaDetalle
    '    Dim numer As String = txtNumeracion.Text
    '    Dim comunicacion As New Helios.Fact.Sunat.Business.Entity.ComunicacionBaja

    '    Try

    '        comunicacion.Action = 0
    '        comunicacion.idEmpresa = lblIdPse.Text
    '        comunicacion.IdDocumento = String.Format("RA-{0:yyyyMMdd}-" & numer, DateTime.Today)
    '        comunicacion.FechaEmision = DateTime.Now
    '        comunicacion.FechaReferencia = dtpFechaDocs.Value
    '        comunicacion.FechaRecepcion = DateTime.Now
    '        comunicacion.EnvioSunat = "NO"
    '        comunicacion.Contribuyente_id = Gempresas.IdEmpresaRuc

    '        For Each i In GridGroupingControl1.Table.Records
    '            conteo += 1

    '            objetoBaja = New Helios.Fact.Sunat.Business.Entity.ComunicacionBajaDetalle
    '            objetoBaja.Id = conteo
    '            objetoBaja.Serie = i.GetValue("serie")
    '            objetoBaja.Correlativo = String.Format("{0:00000000}", CInt(i.GetValue("numero")))
    '            objetoBaja.TipoDocumento = i.GetValue("tipoDoc")
    '            objetoBaja.MotivoBaja = i.GetValue("motivo")
    '            comunicacion.ComunicacionBajaDetalle.Add(objetoBaja)
    '        Next





    '        Dim codigo = Helios.Fact.Sunat.WCFService.ServiceAccess.Admin.ComunicacionBajaSA.ComunicacionBajaSave(comunicacion, Nothing)

    '        If codigo.idComunicacion > 0 Then

    '            ActualizarEnvioSunat("0")
    '            MessageBox.Show("La comunicacion se Envio Correctamente al PSE")
    '            ButtonAdv2.Enabled = True
    '        End If
    '    Catch ex As Exception

    '        MessageBox.Show("No se Pudo Enviar")
    '        ButtonAdv2.Enabled = True
    '    End Try

    'End Sub


    Public Sub BuscarDocumentosAnuladosPeriodoTrans(fecha As DateTime)

        Dim docoumentoventasa As New DocumentoventaTransporteSA

        GridGroupingControl1.Table.Records.DeleteAll()

        Dim consulta = docoumentoventasa.BuscarDocumentosAnuladosPeriodoTrans(fecha, "01", Gempresas.IdEmpresaRuc)


        If consulta.Count > 0 Then
            For Each i In consulta
                Me.GridGroupingControl1.Table.AddNewRecord.SetCurrent()
                Me.GridGroupingControl1.Table.AddNewRecord.BeginEdit()
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("serie", i.serie)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("numero", i.numero)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("tipoDoc", i.tipoDocumento)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("afectado", i.serie)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("importe", i.total)

                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("idDocumento", i.idDocumento)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("motivo", "ANULACION DE DOCUMENTO")
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("fecha", i.fechadoc)
                Me.GridGroupingControl1.Table.AddNewRecord.EndEdit()
            Next
        Else
            MessageBox.Show("No hay documentos por enviar hoy")
            ButtonAdv2.Enabled = True
        End If
    End Sub

    Public Sub CargarDocumentosAnulados(fecha As DateTime)

        Dim docoumentoventasa As New DocumentoventaTransporteSA

        GridGroupingControl1.Table.Records.DeleteAll()

        Dim consulta = docoumentoventasa.BuscarDocumentosAnuladosFechaTrans(fecha, "01", Gempresas.IdEmpresaRuc)


        If consulta.Count > 0 Then
            For Each i In consulta
                Me.GridGroupingControl1.Table.AddNewRecord.SetCurrent()
                Me.GridGroupingControl1.Table.AddNewRecord.BeginEdit()
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("serie", i.serie)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("numero", i.numero)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("tipoDoc", i.tipoDocumento)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("afectado", i.serie)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("importe", i.total)

                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("idDocumento", i.idDocumento)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("motivo", "ANULACION DE DOCUMENTO")
                Me.GridGroupingControl1.Table.AddNewRecord.EndEdit()
            Next
        Else
            MessageBox.Show("No hay documentos por enviar hoy")
            ButtonAdv2.Enabled = True
        End If
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

    'Dim conf As New GConfiguracionModulo
    'Private Sub GetNumeracion(strIdModulo As String, strIDEmpresa As String)
    '    Dim moduloConfiguracionSA As New ModuloConfiguracionSA
    '    Dim moduloConfiguracion As New moduloConfiguracion
    '    moduloConfiguracion = moduloConfiguracionSA.UbicarConfiguracionPorEmpresaModulo(strIdModulo, strIDEmpresa)
    '    conf = New GConfiguracionModulo
    '    conf = ConfigurarComprobanteVenta(moduloConfiguracion)
    '    'SetDataSourceNumeracion(moduloConfiguracion)
    'End Sub

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
        dt.Columns.Add("fecha")
        GridGroupingControl1.DataSource = dt
    End Sub


#End Region

    Private Sub frmComunicacionBajaPSETrans_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'usuariopse(Gempresas.IdEmpresaRuc)
        txtPeriodo.Value = DateTime.Now
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        'CargarDocumentosAnulados(dtpFechaDocs.Value)

        BuscarDocumentosAnuladosPeriodoTrans(txtPeriodo.Value)
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
        'If GridGroupingControl1.Table.Records.Count > 0 Then

        '    If Not lblIdPse.Text > 0 Then

        '        MessageBox.Show("Problemas con El Servidor o no esta Registrado Comuniquese con el PSE")
        '        ButtonAdv2.Enabled = True
        '        Exit Sub
        '    End If

        '    Try



        '        EnviarComunicacionBaja()
        '        CargarDocumentosAnulados(dtpFechaDocs.Value)

        '        ' ActualizarEnvioSunat()
        '    Catch ex As Exception
        '        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        ButtonAdv2.Enabled = True
        '    End Try

        'Else
        '    MessageBox.Show("No hay documentos por enviar")
        '    ButtonAdv2.Enabled = True
        'End If
        'ButtonAdv2.Enabled = True


        ButtonAdv2.Enabled = False
        Me.Cursor = Cursors.WaitCursor
        If GridGroupingControl1.Table.Records.Count > 0 Then

            If Not Gempresas.ubigeo > 0 Then
                MessageBox.Show("No esta Registrado Comuniquese con el PSE")
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

            Try
                ' EnviarComunicacionBaja()
                Dim r As Record
                r = GridGroupingControl1.Table.CurrentRecord

                If r.GetValue("idDocumento") > 0 Then
                    EnviarBajaFactura()
                    'ReenviarDocumentoEliminado(CInt(r.GetValue("idDocumento")), Gempresas.ubigeo)


                Else
                    MessageBox.Show("Seleccione una Factura para Comunicar")
                    ButtonAdv2.Enabled = True
                    Me.Cursor = Cursors.Default
                End If

                'CargarDocumentosAnulados(dtpFechaDocs.Value)
                BuscarDocumentosAnuladosPeriodoTrans(txtPeriodo.Value)



            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ButtonAdv2.Enabled = True
                Me.Cursor = Cursors.Default
            End Try
        Else
            MessageBox.Show("No hay documentos por enviar")
            ButtonAdv2.Enabled = True
            Me.Cursor = Cursors.Default
        End If

        Me.Cursor = Cursors.Default


    End Sub
End Class