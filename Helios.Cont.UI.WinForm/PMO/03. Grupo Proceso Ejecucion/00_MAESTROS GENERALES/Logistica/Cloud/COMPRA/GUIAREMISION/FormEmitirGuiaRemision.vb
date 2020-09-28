Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Text.RegularExpressions
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports PopupControl
Imports ProcesosGeneralesCajamiSoft
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports HtmlAgilityPack
Public Class FormEmitirGuiaRemision

#Region "ATRIBUTOS"

    Private Property SelRazon As entidad
    Private Property entidadSA As New entidadSA

    Public Property UCTrasportePrivado As UCTrasportePrivado
    Public Property UCTrasportePublico As UCTrasportePublico
    Public Property UCGuiaDestinatario As UCGuiaDestinatario


    Public Property venta As documentoventaAbarrotes
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)

    Dim idDoc As Integer

    Dim tipotroDocD As Integer


#End Region


#Region "CONSTRUCTOR"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()




        UCGuiaDestinatario = New UCGuiaDestinatario()
        UCGuiaDestinatario.Dock = DockStyle.Fill
        GradientPanel1.Controls.Add(UCGuiaDestinatario)
        UCGuiaDestinatario.Visible = False



        UCTrasportePublico = New UCTrasportePublico()
        UCTrasportePublico.Dock = DockStyle.Fill
        GradientPanel1.Controls.Add(UCTrasportePublico)

        UCTrasportePrivado = New UCTrasportePrivado()
        UCTrasportePrivado.Dock = DockStyle.Fill
        GradientPanel1.Controls.Add(UCTrasportePrivado)

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub


    Public Sub New(IdDocumento As Integer)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        txtdocprovee.Text = "RUC"


        UCGuiaDestinatario = New UCGuiaDestinatario()
        UCGuiaDestinatario.Dock = DockStyle.Fill
        GradientPanel1.Controls.Add(UCGuiaDestinatario)
        UCGuiaDestinatario.Visible = False


        UCTrasportePublico = New UCTrasportePublico()
        UCTrasportePublico.Dock = DockStyle.Fill
        GradientPanel1.Controls.Add(UCTrasportePublico)

        UCTrasportePrivado = New UCTrasportePrivado()
        UCTrasportePrivado.Dock = DockStyle.Fill
        GradientPanel1.Controls.Add(UCTrasportePrivado)

        DATOSEMPRESA()
        UbicarGuia(IdDocumento)
        idDoc = IdDocumento


        VerDetalleDocumento(venta.documentoventaAbarrotesDet)
    End Sub

#End Region


#Region "METODOS"


    Public Sub VALIDARMENU()
        ErrorProvider1.SetError(cbomotivotrasl, Nothing)
        UCGuiaDestinatario.Visible = True
        GradientPanel4.Visible = False
        'btnConfirmar.ButtonText = "ATRAZ"

        sliderTop.Left = BunifuFlatButton6.Left
        sliderTop.Width = BunifuFlatButton6.Width
    End Sub

    Public Sub validacionCaja()
        txtmotivotraslado.Enabled = False
        txtmotivotraslado.BackColor = Color.WhiteSmoke
        txtDAM.Enabled = False
        txtDAM.BackColor = Color.WhiteSmoke
        txtDAM.Clear()
        txtmotivotraslado.Clear()
    End Sub

    Public Sub VerDetalleDocumento(venta As List(Of documentoventaAbarrotesDet))

        Try

            Dim dt As New DataTable("BIENES A TRASLADAR" & Date.Now & " ")

            dt.Columns.Add("idDocumento")
            dt.Columns.Add("secuencia")
            dt.Columns.Add("idItem")
            dt.Columns.Add("descripcionItem")
            dt.Columns.Add("unidadMedida")
            dt.Columns.Add("cantidad")

            For Each i In venta

                dt.Rows.Add(
                            i.idDocumento,
                        i.secuencia,
                        i.idItem,
                        i.nombreItem,
                        i.unidad1,
                        i.monto1
                        )

            Next
            setDataSource(dt)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub


    Private Sub setDataSource(ByVal table As DataTable)
        If Me.InvokeRequired Then

            Dim deleg As New SetDataSourceDelegate(AddressOf setDataSource)
            Invoke(deleg, New Object() {table})
        Else
            dgAgregarBien.DataSource = table
            PictureLoad.Visible = False
            BunifuFlatButton5.Enabled = True
        End If
    End Sub
    Private Function MappingDocumento() As documento

        Dim tipoOper As String
        Dim TIPODOC As Integer

        tipoOper = General.StatusTipoOperacion.GUIA_REMISION
        If IsDBNull(cbTipoDocdes.SelectedValue) Then
            TIPODOC = cbTipoDocdes.SelectedValue
        Else
            TIPODOC = cbtipoDesOtro.SelectedValue
        End If

        MappingDocumento = New documento With
            {
        .idEmpresa = Gempresas.IdEmpresaRuc,
        .idCentroCosto = GEstableciento.IdEstablecimiento,
        .idProyecto = 0,
        .tipoDoc = combotipoGuia.SelectedValue,
        .fechaProceso = DateTime.Now,' fechaVenta,
        .moneda = "",
        .idEntidad = TIPODOC,
        .entidad = txtdatosDesti.Text,
        .tipoEntidad = TIPO_ENTIDAD.CLIENTE,
        .nrodocEntidad = txtDnidesti.Text,
        .nroDoc = "200",'$"{UCEstructuraCabeceraVentaV2.txtSerie.Text}-{UCEstructuraCabeceraVentaV2.txtNumero.Text}",
        .idOrden = 0,
        .tipoOperacion = "02",'StatusTipoOperacion.VENTA,
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = Date.Now
        }


    End Function

    Private Sub MappingDocumentoCompraCabecera(be As documento)
        Dim ANIO As String
        Dim MES As String
        Dim TipoOtros As String = String.Empty
        Dim cantiTipo As Integer
        If lsvDetOtroOpera.Items.Count > 0 Then
            TipoOtros = lsvDetOtroOpera.SelectedItems(0).SubItems(0).Text
            cantiTipo = CInt(lsvDetOtroOpera.SelectedItems(0).SubItems(1).Text)
        End If
        'Dim radio As Boolean
        Dim TRASPORTE As Boolean
        ANIO = CStr(UCTrasportePublico.cbFechaGuia.Value.Year)
        MES = CStr(UCTrasportePublico.cbFechaGuia.Value.Month)
        Dim PERIODO = ANIO & MES

        'If RadioButton1.Checked = True Then
        '    radio = 1
        'Else
        '    radio = 0
        'End If

        If UCTrasportePublico.RadioButton4.Checked = True Then
            TRASPORTE = 1
        Else
            TRASPORTE = 0
        End If

        Dim obj As New documentoGuia With
        {
        .codigoLibro = "8",
        .idEmpresa = be.idEmpresa,
        .idCentroCosto = GEstableciento.IdEstablecimiento,
        .fechaDoc = Date.Now,
        .fechaTraslado = UCTrasportePublico.cbFechaGuia.Value,
        .periodo = PERIODO,
        .tipoDoc = combotipoGuia.SelectedValue,
        .serie = txtserieAfec.Text,
        .numeroDoc = txtnumerAfec.Text,
        .motivoTraslado = cbomotivotrasl.Text,
        .DescripcionMotivo = txtmotivotraslado.Text,
        .DAM = txtDAM.Text,
        .DireccionLlegada = UCGuiaDestinatario.txtdirecciodesti.Text,
        .idEntidad = be.idEntidad,
        .monedaDoc = be.moneda,
        .direccionPartida = UCGuiaDestinatario.txtdirecPartida.Text,
        .puntoPartida = UCGuiaDestinatario.txtUbiRemit.Tag,
        .puntoLlegada = UCGuiaDestinatario.txtUbigDestino.Tag,
        .usuarioActualizacion = be.usuarioActualizacion, 'usuario.IDUsuario,
        .fechaActualizacion = Date.Now,
        .AsignarOtraGuia = txtotraguia.Text,
        .Trasbordo = TRASPORTE,
        .placaVehiculo = UCTrasportePublico.txtobserTrasPubl.Text,
        .RucTrasporte = UCTrasportePublico.txtrucTraspubl.Text,
        .datosTrasporte = UCTrasportePublico.txtdatosTraspubl.Text,
        .fechaEntrega = UCTrasportePublico.dtpfechaEntregaBien.Value,
         .ObserTrasPublico = UCTrasportePublico.txtobserTrasPubl.Text,
        .nroDocTrasportista = UCTrasportePublico.txtdniDatosTras.Text,
         .razonSocialTrasportista = UCTrasportePublico.txtDatoTraspor.Text,
              .TipoDocDestinatario = cbTipoDocdes.Text,
              .DocDestinatario = txtDnidesti.Text,
              .nombreDestinatario = txtdatosDesti.Text,
              .TipoDocProveedor = txtdocprovee.Text,
              .docProveedor = txtnumprovee.Text,
              .DatosProveedor = txtRazoSocprovee.Text,
               .OtroTipoOperacion = TipoOtros,
        .OtroCantidad = cantiTipo,
        .PesoBruTotal = CInt(txtTotalPB.Text)
        }

        be.documentoGuia = obj


        be.documentoGuia.documentoguiaDetalle = New List(Of documentoguiaDetalle)
    End Sub

    Private Sub MappingDocumentoCompraCabeceraDetalle(obj As documento)
        Dim objDet As documentoguiaDetalle

        For Each i In dgAgregarBien.Table.Records

            objDet = New documentoguiaDetalle With
                            {
                            .idItem = CStr(i.GetValue("idItem")),
                            .tipoExistencia = "",
                            .descripcionItem = CStr(i.GetValue("descripcionItem")),
                            .destino = UCGuiaDestinatario.txtUbigDestino.Tag,
                            .unidadMedida = CStr(i.GetValue("unidadMedida")),
                            .cantidad = CStr(i.GetValue("cantidad")),
                            .usuarioModificacion = obj.usuarioActualizacion,' usuario.IDUsuario,
                            .fechaModificacion = Date.Now
                            }


            obj.documentoGuia.documentoguiaDetalle.Add(objDet)
        Next
    End Sub


    Public Sub DATOSEMPRESA()
        txtTipoDoc.Text = "RUC"
        txtNumeroTD.Text = Gempresas.IdEmpresaRuc
        txtRemitente.Text = Gempresas.NomEmpresa
    End Sub


    Private Sub UbicarGuia(idDocumento As Integer)

        Dim guiaSA As New DocumentoGuiaDetalleSA
        Dim ventaSA As New documentoVentaAbarrotesSA

        venta = ventaSA.GetVentaID(New Business.Entity.documento With {.idDocumento = idDocumento})

        If venta IsNot Nothing Then
            VerCabeceraDocumento(venta)

        End If

    End Sub
    Private Sub VerCabeceraDocumento(venta As documentoventaAbarrotes)
        Try
            Dim PERSONASA As New entidadSA

            txtserieAfec.Text = venta.serieVenta
            txtnumerAfec.Text = venta.numeroVenta
            If venta.serieVenta = "9907" Then
                txtcomprane.Text = "NOTA DE VENTA"
            ElseIf venta.serieVenta = "01" Then
                txtcomprane.Text = "FACTURA"
            ElseIf venta.serieVenta = "03" Then
                txtcomprane.Text = "BOLETA"
            End If




            Dim CLIENTE = PERSONASA.GetUbicarEntPorID(Gempresas.IdEmpresaRuc, venta.idCliente)
            txtDnidesti.Text = CLIENTE.nrodoc
            txtdatosDesti.Text = CLIENTE.nombreCompleto
            txtdatosDesti.Tag = CLIENTE.idEntidad


            If CLIENTE.tipoDoc = 0 Then
                cbTipoDocdes.Text = "SIN IDENTIFICACION"
            ElseIf CLIENTE.tipoDoc = 1 Then
                cbTipoDocdes.Text = "DNI"
            ElseIf CLIENTE.tipoDoc = 6 Then
                cbTipoDocdes.Text = "RUC"
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub
#Region "METODOS DE CONSTANATES"
    Public Sub TIPOGUIAREMISION()
        Dim listaTras As New List(Of TipoGuiaRemision)
        Dim obj As New TipoGuiaRemision

        obj = New TipoGuiaRemision
        obj.Codigo = "0"
        obj.Valor = " "
        listaTras.Add(obj)

        obj = New TipoGuiaRemision
        obj.Codigo = "09"
        obj.Valor = "GUÍA DE REMISIÓN REMITENTE"
        listaTras.Add(obj)

        obj = New TipoGuiaRemision
        obj.Codigo = "10"
        obj.Valor = "GUÍA DE REMISIÓN TRANSPORTISTA"
        listaTras.Add(obj)

        obj = New TipoGuiaRemision
        obj.Codigo = "11"
        obj.Valor = "GUÍA DE REMISIÓN REMITENTE COMPLEMENTARIO"
        listaTras.Add(obj)
        obj = New TipoGuiaRemision
        obj.Codigo = "12"
        obj.Valor = "GUÍA DE REMISIÓN TRANSPORTISTA REMITENTE COMPLEMENTARIO"
        listaTras.Add(obj)

        combotipoGuia.DataSource = listaTras
        combotipoGuia.ValueMember = "Codigo"
        combotipoGuia.DisplayMember = "Valor"
    End Sub

    Public Sub MOTIVOTRASLADO()
        Dim LISTA As New List(Of MOTIVOTRASLADO)
        Dim OBJETO As New MOTIVOTRASLADO

        OBJETO = New MOTIVOTRASLADO
        OBJETO.Codigo = "0"
        OBJETO.Valor = " "
        LISTA.Add(OBJETO)

        OBJETO = New MOTIVOTRASLADO
        OBJETO.Codigo = "1"
        OBJETO.Valor = "VENTA"
        LISTA.Add(OBJETO)
        OBJETO = New MOTIVOTRASLADO
        OBJETO.Codigo = "2"
        OBJETO.Valor = "COMPRA"
        LISTA.Add(OBJETO)
        OBJETO = New MOTIVOTRASLADO
        OBJETO.Codigo = "3"
        OBJETO.Valor = "CONSIGNACIÓN"
        LISTA.Add(OBJETO)
        OBJETO = New MOTIVOTRASLADO
        OBJETO.Codigo = "4"
        OBJETO.Valor = "VENTA SUJETA A CONFIRMACIÓN DEL COMPRADOR"
        LISTA.Add(OBJETO)
        OBJETO = New MOTIVOTRASLADO
        OBJETO.Codigo = "5"
        OBJETO.Valor = "DEVOLUCIÓN"
        LISTA.Add(OBJETO)
        OBJETO = New MOTIVOTRASLADO
        OBJETO.Codigo = "6"
        OBJETO.Valor = "RECOJO"
        LISTA.Add(OBJETO)
        OBJETO = New MOTIVOTRASLADO
        OBJETO.Codigo = "7"
        OBJETO.Valor = "EMISOR ITINERANTE"
        LISTA.Add(OBJETO)
        OBJETO = New MOTIVOTRASLADO
        OBJETO.Codigo = "8"
        OBJETO.Valor = "TRASLADO ENTRE ESTABLECIMIENTOS DE LA MISMA EMPRESA"
        LISTA.Add(OBJETO)
        OBJETO = New MOTIVOTRASLADO
        OBJETO.Codigo = "9"
        OBJETO.Valor = "TRASLADO DE TRANSFORMACIÓN"
        LISTA.Add(OBJETO)
        OBJETO = New MOTIVOTRASLADO
        OBJETO.Codigo = "10"
        OBJETO.Valor = "TRASLADO ZONA PRIMARIA"
        LISTA.Add(OBJETO)
        OBJETO = New MOTIVOTRASLADO
        OBJETO.Codigo = "11"
        OBJETO.Valor = "TRASLADO EMISOR ITINERANTE COMPROBANTE DE PAGO"
        LISTA.Add(OBJETO)
        OBJETO = New MOTIVOTRASLADO
        OBJETO.Codigo = "12"
        OBJETO.Valor = "IMPORTACIÓN"
        LISTA.Add(OBJETO)
        OBJETO = New MOTIVOTRASLADO
        OBJETO.Codigo = "6"
        OBJETO.Valor = "EXPORTACIÓN"
        LISTA.Add(OBJETO)
        OBJETO = New MOTIVOTRASLADO
        OBJETO.Codigo = "13"
        OBJETO.Valor = "VENTA CON ENTRAGA A TERCEROS"
        LISTA.Add(OBJETO)
        OBJETO = New MOTIVOTRASLADO
        OBJETO.Codigo = "14"
        OBJETO.Valor = "OTROS"
        LISTA.Add(OBJETO)

        cbomotivotrasl.DataSource = LISTA
        cbomotivotrasl.ValueMember = "Codigo"
        cbomotivotrasl.DisplayMember = "Valor"
    End Sub
    Public Sub TIPODOCUMENTO()
        Dim LISTA As New List(Of TIPODOCUMENTO)
        Dim OBJETO As New TIPODOCUMENTO

        OBJETO = New TIPODOCUMENTO
        OBJETO.Codigo = " "
        OBJETO.Valor = "SIN IDENTIFICACION "
        LISTA.Add(OBJETO)


        OBJETO = New TIPODOCUMENTO
        OBJETO.Codigo = "1"
        OBJETO.Valor = "DNI"
        LISTA.Add(OBJETO)
        OBJETO = New TIPODOCUMENTO
        OBJETO.Codigo = "2"
        OBJETO.Valor = "DT. S/RUC"
        LISTA.Add(OBJETO)
        OBJETO = New TIPODOCUMENTO
        OBJETO.Codigo = "3"
        OBJETO.Valor = "CED. DIPL."
        LISTA.Add(OBJETO)
        OBJETO = New TIPODOCUMENTO
        OBJETO.Codigo = "4"
        OBJETO.Valor = "C. EXT."
        LISTA.Add(OBJETO)
        OBJETO = New TIPODOCUMENTO
        OBJETO.Codigo = "7"
        OBJETO.Valor = "PASAPORTE"
        LISTA.Add(OBJETO)
        OBJETO = New TIPODOCUMENTO
        OBJETO.Codigo = "6"
        OBJETO.Valor = "RUC"
        LISTA.Add(OBJETO)


        cbTipoDocdes.DataSource = LISTA
        cbTipoDocdes.ValueMember = "Codigo"
        cbTipoDocdes.DisplayMember = "Valor"
    End Sub

    Public Sub TIPODOCUMENTOCOMPRA()
        Dim LISTA As New List(Of TIPODOCUMENTO)
        Dim OBJETO As New TIPODOCUMENTO

        OBJETO = New TIPODOCUMENTO
        OBJETO.Codigo = "6"
        OBJETO.Valor = "RUC"
        LISTA.Add(OBJETO)

        cbtipoDesOtro.DataSource = LISTA
        cbtipoDesOtro.ValueMember = "Codigo"
        cbtipoDesOtro.DisplayMember = "Valor"
    End Sub
#End Region
#End Region






    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        Dim U As New FormAgregarBienes
        U.StartPosition = FormStartPosition.CenterScreen
        U.ShowDialog()

        U.AgregarCaja()
    End Sub

    Private Sub FormEmitirGuiaRemision_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MOTIVOTRASLADO()
        TIPOGUIAREMISION()
        TIPODOCUMENTO()
        TIPODOCUMENTOCOMPRA()
    End Sub

    Private Sub BunifuFlatButton5_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton5.Click
        VerDetalleDocumento(venta.documentoventaAbarrotesDet)
    End Sub




    Private Sub BunifuFlatButton1_Click_1(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Try
            Dim U As New FormOtroDocumentoRelacion
            U.StartPosition = FormStartPosition.CenterScreen
            U.ShowDialog()

            If Not IsNothing(U.Tag) Then
                Dim T = CType(U.Tag, OTROSTIPODOCUMENTO)

                Dim n As New ListViewItem(T.Valor)
                n.SubItems.Add(T.NumDoc)
                'n.SubItems.Add(T.Codigo)
                lsvDetOtroOpera.Items.Add(n)
                If lsvDetOtroOpera.Items.Count > 0 Then
                    lsvDetOtroOpera.Items(0).Selected = True
                End If
                'ListBox1.Items.Add(T.Codigo & " " & "-" & " " & T.NumDoc)  OTRO FORMA DIRECTA
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub




    Private Sub cbomotivotrasl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbomotivotrasl.SelectedIndexChanged
        Select Case cbomotivotrasl.Text
            Case "VENTA"

                ' VALIDARMENU()
                'gpbProveedor.Visible = False
                gpbProveedor.Visible = False
                cbTipoDocdes.Visible = True
                cbtipoDesOtro.Visible = False
                txtDnidesti.Enabled = True
                txtdatosDesti.Enabled = True
                txtDnidesti.Clear()
                txtdatosDesti.Clear()
                validacionCaja()
            Case "COMPRA"


                ErrorProvider1.SetError(txtDnidesti, Nothing)

                gpbProveedor.Visible = True
                cbTipoDocdes.Visible = False
                cbtipoDesOtro.Visible = True
                txtDnidesti.Enabled = False
                txtdatosDesti.Enabled = False
                txtDnidesti.Text = Gempresas.IdEmpresaRuc
                txtdatosDesti.Text = Gempresas.NomEmpresa
                validacionCaja()
            Case "CONSIGNACIÓN"
            Case "VENTA SUJETA A CONFIRMACIÓN DEL COMPRADOR"
            Case "DEVOLUCIÓN"
            Case "RECOJO"
            Case "EMISOR ITINERANTE"
            Case "TRASLADO ENTRE ESTABLECIMIENTOS DE LA MISMA EMPRESA"

                ErrorProvider1.SetError(txtDnidesti, Nothing)

                gpbProveedor.Visible = True
                cbTipoDocdes.Visible = False
                cbtipoDesOtro.Visible = True
                txtDnidesti.Enabled = False
                txtdatosDesti.Enabled = False
                txtDnidesti.Text = Gempresas.IdEmpresaRuc
                txtdatosDesti.Text = Gempresas.NomEmpresa
                validacionCaja()
            Case "TRASLADO DE TRANSFORMACIÓN"

                gpbProveedor.Visible = False
                cbTipoDocdes.Visible = True
                cbtipoDesOtro.Visible = False
                txtDnidesti.Enabled = True
                txtdatosDesti.Enabled = True
                txtDnidesti.Clear()
                txtdatosDesti.Clear()
                validacionCaja()
            Case "TRASLADO ZONA PRIMARIA"

                gpbProveedor.Visible = False
                cbTipoDocdes.Visible = True
                cbtipoDesOtro.Visible = False
                txtDnidesti.Enabled = True
                txtdatosDesti.Enabled = True
                txtDnidesti.Clear()
                txtdatosDesti.Clear()
                validacionCaja()
            Case "TRASLADO EMISOR ITINERANTE COMPROBANTE DE PAGO"

                gpbProveedor.Visible = False
                cbTipoDocdes.Visible = False
                cbtipoDesOtro.Visible = True
                txtDnidesti.Enabled = True
                txtdatosDesti.Enabled = True
                txtDnidesti.Clear()
                txtdatosDesti.Clear()
                txtDnidesti.Text = Gempresas.IdEmpresaRuc
                txtdatosDesti.Text = Gempresas.NomEmpresa
                validacionCaja()
            Case "IMPORTACIÓN"

                gpbProveedor.Visible = True
                cbTipoDocdes.Visible = True
                cbtipoDesOtro.Visible = False
                txtDnidesti.Enabled = True
                txtdatosDesti.Enabled = True
                txtmotivotraslado.Enabled = False
                txtmotivotraslado.BackColor = Color.WhiteSmoke
                txtDAM.Enabled = True
                txtDAM.BackColor = Color.White
                txtDAM.Clear()
                txtmotivotraslado.Clear()
                txtnumprovee.Clear()
                txtRazoSocprovee.Clear()
                txtDnidesti.Clear()
                txtdatosDesti.Clear()
                txtDAM.Select()
            Case "EXPORTACIÓN"

                gpbProveedor.Visible = False
                cbTipoDocdes.Visible = True
                cbtipoDesOtro.Visible = False
                txtDnidesti.Enabled = True
                txtdatosDesti.Enabled = True
                txtDnidesti.Clear()
                txtdatosDesti.Clear()
                validacionCaja()
            Case "VENTA CON ENTRAGA A TERCEROS"
            Case "OTROS"


                gpbProveedor.Visible = False
                cbTipoDocdes.Visible = True
                cbtipoDesOtro.Visible = False
                txtDnidesti.Enabled = True
                txtdatosDesti.Enabled = True
                txtmotivotraslado.Enabled = True
                txtmotivotraslado.BackColor = Color.White
                txtmotivotraslado.Clear()
                txtDAM.Enabled = False
                txtDAM.BackColor = Color.WhiteSmoke
                txtDAM.Clear()
                txtDnidesti.Clear()
                txtdatosDesti.Clear()
                txtmotivotraslado.Select()


        End Select
    End Sub


    Private Sub bfbRemitente_Click_1(sender As Object, e As EventArgs) Handles bfbRemitente.Click, BunifuFlatButton6.Click, BunifuFlatButton3.Click
        Try
            Dim cambio As Integer
            sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
            sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width
            Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)

            Select Case btn.Text

                Case "EMISION DE GUÍA"

                    UCGuiaDestinatario.Visible = False
                    GradientPanel4.Visible = True

                Case "PUNTO DE PARTIDA Y LLEGADA"

                    If cbomotivotrasl.Text.Trim.Length > 0 Then
                        UCGuiaDestinatario.Visible = True
                        GradientPanel4.Visible = False
                    Else

                        sliderTop.Left = bfbRemitente.Left
                        sliderTop.Width = bfbRemitente.Width
                        UCTrasportePublico.Visible = False
                        UCTrasportePrivado.Visible = False
                        GradientPanel4.Visible = True
                        ErrorProvider1.SetError(cbomotivotrasl, "INGRESA MOTIVO DE TRASLADO")
                        MessageBox.Show("INGRESA MOTIVO DE TRASLADO")
                    End If

                Case "TIPO TRANSPORTE"

                    If UCGuiaDestinatario.txtUbiRemit.Text = "" Then

                        sliderTop.Left = BunifuFlatButton6.Left
                        sliderTop.Width = BunifuFlatButton6.Width
                        GradientPanel4.Visible = False
                        UCGuiaDestinatario.Visible = True
                        ErrorProvider1.SetError(UCGuiaDestinatario.txtUbiRemit, "INGRESA EL UBIGEO")

                    Else

                        If UCTrasportePublico.txtrucTraspubl.Text = "" Then
                            Dim f As New FormTipotrasporte
                            f.StartPosition = FormStartPosition.CenterParent
                            f.ShowDialog(Me)
                            If f.Tag IsNot Nothing Then
                                Dim ent = CType(f.Tag, OTROSTIPODOCUMENTO)
                                If ent.Codigo = 1 Then
                                    cambio = 1
                                    UCGuiaDestinatario.Visible = False
                                    GradientPanel4.Visible = False
                                    UCTrasportePrivado.Visible = False
                                    UCTrasportePublico.ruc = txtDnidesti.Text
                                    UCTrasportePublico.Visible = True
                                Else
                                    cambio = 2
                                    UCGuiaDestinatario.Visible = False
                                    GradientPanel4.Visible = False
                                    UCTrasportePublico.Visible = False
                                    UCTrasportePrivado.Visible = True
                                End If
                            End If
                        Else
                            If cambio = 1 Then

                                UCGuiaDestinatario.Visible = False
                                GradientPanel4.Visible = False
                                UCTrasportePublico.Visible = False
                                UCTrasportePrivado.Visible = True

                            Else
                                UCGuiaDestinatario.Visible = False
                                GradientPanel4.Visible = False
                                UCTrasportePrivado.Visible = False

                                UCTrasportePublico.Visible = True


                            End If

                        End If
                    End If


            End Select
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub btnConfirmar_Click_1(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        Try

            Dim obj As New documento
            Dim GUIASA As New DocumentoGuiaSA


            If cbomotivotrasl.Text.Trim.Length > 0 Then
                ErrorProvider1.SetError(cbomotivotrasl, Nothing)

                If txtDnidesti.Text.Trim.Length > 0 Then
                    'btnConfirmar.ButtonText = "Grabar"
                    ErrorProvider1.SetError(txtDnidesti, Nothing)

                    If combotipoGuia.Text.Trim.Length > 0 Then
                        ErrorProvider1.SetError(combotipoGuia, Nothing)

                        If txtTotalPB.Text = "" Then
                            ErrorProvider1.SetError(txtTotalPB, "Ingresa Peso Bruto")

                        Else
                            ErrorProvider1.SetError(txtTotalPB, Nothing)

                            If UCGuiaDestinatario.txtUbiRemit.Text = "" Then
                                ErrorProvider1.SetError(UCGuiaDestinatario.txtUbiRemit, "Ingrese RUC destino")

                                UCGuiaDestinatario.Visible = True
                                GradientPanel4.Visible = False

                                sliderTop.Left = BunifuFlatButton6.Left
                                sliderTop.Width = BunifuFlatButton6.Width

                            Else
                                If UCTrasportePublico.txtrucTraspubl.Text = "" Then
                                    ErrorProvider1.SetError(UCTrasportePublico.txtrucTraspubl, "Ingrese RUC destino")

                                    UCGuiaDestinatario.Visible = False
                                    GradientPanel4.Visible = False
                                    UCTrasportePublico.Visible = True

                                    sliderTop.Left = BunifuFlatButton3.Left
                                    sliderTop.Width = BunifuFlatButton3.Width
                                Else

                                    ErrorProvider1.SetError(cbomotivotrasl, Nothing)
                                    'GUARDARGUIA()
                                    obj = MappingDocumento()
                                    MappingDocumentoCompraCabecera(obj)
                                    MappingDocumentoCompraCabeceraDetalle(obj)

                                    GUIASA.RegistrarGuiaRemision(obj)
                                    MessageBox.Show("se guardo correcto")
                                End If

                            End If


                        End If
                    Else
                        ErrorProvider1.SetError(combotipoGuia, "Ingrese Tipo de Guia")
                        UCGuiaDestinatario.Visible = False
                        GradientPanel4.Visible = True
                        UCTrasportePublico.Visible = False
                    End If


                Else
                    ErrorProvider1.SetError(txtDnidesti, "Ingrese RUC destino")
                    UCGuiaDestinatario.Visible = False
                    GradientPanel4.Visible = True
                    UCTrasportePublico.Visible = False
                End If

            Else
                ErrorProvider1.SetError(cbomotivotrasl, "Ingrese el motivo del traslado")
                UCGuiaDestinatario.Visible = False
                GradientPanel4.Visible = True
                UCTrasportePublico.Visible = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Private Sub BunifuFlatButton9_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton9.Click
        If Not IsNothing(dgAgregarBien.Table.CurrentRecord) Then

            Dim RESUL As Integer = MessageBox.Show("Seguro que quiere eliminar el Registro?", "ELIMINAR REGISTRO", MessageBoxButtons.YesNo)
            If RESUL = DialogResult.Yes Then
                dgAgregarBien.Table.CurrentRecord.Delete()

            End If
        Else
            MessageBox.Show("Seleccione un Activo!!")
        End If
    End Sub
#Region "RUC Y DNI"


    Private Sub txtnumprovee_KeyDown(sender As Object, e As KeyEventArgs) Handles txtnumprovee.KeyDown
        tipotroDocD = 2

        Dim nombres = String.Empty
        Try
            'TextNumIdentrazon.Enabled = False
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True

                Select Case txtnumprovee.Text.Trim.Length
                    Case 8 'dni
                        MessageBox.Show("Debe Ingresar un número correcto de ruc", "Ingrese Correcto en numero de RUC", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        'SelRazon = New entidad

                        'If My.Computer.Network.IsAvailable = True Then
                        '    'PictureLoad.Visible = True

                        '    nombres = GetConsultarDNIReniec(txtnumprovee.Text.Trim)

                        '    If nombres.Trim.Length > 0 Then

                        '        If nombres = "DNI no encontrado en Padrón Electoral" Then
                        '            txtnumprovee.Clear()
                        '            txtRazoSocprovee.Text = String.Empty
                        '            txtRazoSocprovee.Tag = Nothing
                        '            'PictureLoad.Visible = False
                        '            Exit Sub
                        '        End If

                        '        SelRazon.tipoEntidad = "CL"
                        '        SelRazon.nombreCompleto = nombres
                        '        SelRazon.nrodoc = txtnumprovee.Text.Trim
                        '        SelRazon.tipoDoc = "1"
                        '        SelRazon.tipoPersona = "N"
                        '        txtRazoSocprovee.Text = nombres

                        '        Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", txtnumprovee.Text.Trim)

                        '        If existeEnDB Is Nothing Then
                        '            txtRazoSocprovee.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        '            GrabarEntidadRapida()
                        '            'PictureLoad.Visible = False
                        '        Else
                        '            txtRazoSocprovee.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        '            txtRazoSocprovee.Tag = existeEnDB.idEntidad
                        '            'If RadioButton2.Checked = True Then
                        '            'TextFiltrar.Focus()
                        '            'TextFiltrar.Select()
                        '            'ElseIf RadioButton1.Checked = True Then
                        '            '    txtruc.Focus()
                        '            '    txtruc.Select()
                        '            'End If
                        '        End If
                        '    Else
                        '        txtnumprovee.Clear()
                        '        txtRazoSocprovee.Text = String.Empty
                        '        txtRazoSocprovee.Tag = Nothing
                        '    End If
                        '    'PictureLoad.Visible = False
                        'Else

                        '    'CUANDO NO HAY CONEXION A INTERNET
                        '    Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", txtnumprovee.Text.Trim)
                        '    If existeEnDB Is Nothing Then
                        '        SelRazon.tipoEntidad = "CL"
                        '        SelRazon.nombreCompleto = txtRazoSocprovee.Text.Trim
                        '        SelRazon.nrodoc = txtnumprovee.Text.Trim
                        '        SelRazon.tipoDoc = "1"
                        '        SelRazon.tipoPersona = "N"
                        '        'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        '        'GrabarEntidadRapida()
                        '        GrabarEnFormBasico()
                        '        'PictureLoad.Visible = False
                        '    Else
                        '        txtRazoSocprovee.Text = existeEnDB.nombreCompleto
                        '        txtRazoSocprovee.Tag = existeEnDB.idEntidad
                        '        txtRazoSocprovee.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        '        'If RadioButton2.Checked = True Then
                        '        'TextFiltrar.Focus()
                        '        'TextFiltrar.Select()
                        '        'ElseIf RadioButton1.Checked = True Then
                        '        '    txtruc.Focus()
                        '        '    txtruc.Select()
                        '        'End If
                        '    End If
                        'End If



                    Case 11 'razonSocial
                        'PictureLoad.Visible = True
                        Dim objeto As Boolean = ValidationRUC(txtnumprovee.Text.Trim)
                        If objeto = False Then
                            'PictureLoad.Visible = False
                            MessageBox.Show("Debe Ingresar un número correcto de ruc", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Cursor = Cursors.Default
                            txtRazoSocprovee.Clear()
                            Exit Sub
                        End If

                        If My.Computer.Network.IsAvailable = True Then
                            'VALIDAR SI EXISTE EN LA bd LOCAL PRIMERO 
                            If GetValidarLocalDB(txtnumprovee.Text.Trim) = False Then
                                txtnumprovee.ReadOnly = True

                                Select Case ToggleConsultas.ToggleState
                                    Case ToggleButton2.ToggleButtonState.OFF ' API
                                        '  GetConsultaSunatAsync(TextNumIdentrazon.Text.Trim)
                                        GetApiSunat(txtnumprovee.Text.Trim)
                                    Case ToggleButton2.ToggleButtonState.ON ' WEB
                                        BgProveedor.RunWorkerAsync()
                                End Select
                            End If
                        Else
                            'SI NO HAY CONEXION A INTERNET
                            If GetValidarLocalDB(txtnumprovee.Text.Trim) = False Then
                                Dim nroDoc = txtnumprovee.Text.Trim.Substring(0, 1).ToString
                                If nroDoc = "1" Then
                                    'SelRazon.tipoEntidad = "CL"
                                    'SelRazon.nombreCompleto = TextEmpresaPasajero.Text.Trim
                                    'SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                                    'SelRazon.tipoDoc = "6"
                                    'SelRazon.tipoPersona = "N"
                                    'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    'GrabarEntidadRapida()
                                    GrabarEnFormBasico()
                                    'PictureLoad.Visible = False
                                    If txtnumprovee.Text.Trim.Length > 0 Then
                                        'TextFiltrar.Select()
                                        'TextFiltrar.Focus()
                                    Else
                                        txtnumprovee.Clear()
                                        txtnumprovee.Select()
                                    End If
                                ElseIf nroDoc = "2" Then
                                    'SelRazon.tipoEntidad = "CL"
                                    'SelRazon.nombreCompleto = TextEmpresaPasajero.Text.Trim
                                    'SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                                    'SelRazon.tipoDoc = "6"
                                    'SelRazon.tipoPersona = "J"
                                    'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    'GrabarEntidadRapida()
                                    GrabarEnFormBasico()
                                    'PictureLoad.Visible = False
                                    If txtRazoSocprovee.Text.Trim.Length > 0 Then
                                        'TextFiltrar.Select()
                                        'TextFiltrar.Focus()
                                    Else
                                        txtnumprovee.Clear()
                                        txtnumprovee.Select()
                                    End If
                                End If
                            End If
                        End If

                    Case Else
                        txtRazoSocprovee.Text = String.Empty
                        txtnumprovee.Text = String.Empty
                        MessageBox.Show("Ingrese un documento correcto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Select

            End If
            '    TextNumIdentrazon.Enabled = True

        Catch ew As WebException

            If ew.Status = WebExceptionStatus.ProtocolError Then
                'PictureLoad.Visible = False
                Dim [error] As String = New System.IO.StreamReader(ew.Response.GetResponseStream()).ReadToEnd()
                MessageBox.Show("DNI no encontrado en el padron, verifique si es menor de edad")
                txtnumprovee.Clear()
                txtnumprovee.Select()
                txtnumprovee.Focus()
                txtnumprovee.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtDnidesti_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDnidesti.KeyDown
        tipotroDocD = 1

        Dim nombres = String.Empty
        Try
            'TextNumIdentrazon.Enabled = False
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True

                Select Case txtDnidesti.Text.Trim.Length
                    Case 8 'dni

                        SelRazon = New entidad

                        If My.Computer.Network.IsAvailable = True Then
                            'PictureLoad.Visible = True

                            nombres = GetConsultarDNIReniec(txtDnidesti.Text.Trim)

                            If nombres.Trim.Length > 0 Then

                                If nombres = "DNI no encontrado en Padrón Electoral" Then
                                    txtDnidesti.Clear()
                                    txtdatosDesti.Text = String.Empty
                                    txtdatosDesti.Tag = Nothing
                                    'PictureLoad.Visible = False
                                    Exit Sub
                                End If

                                SelRazon.tipoEntidad = "CL"
                                SelRazon.nombreCompleto = nombres
                                SelRazon.nrodoc = txtDnidesti.Text.Trim
                                SelRazon.tipoDoc = "1"
                                SelRazon.tipoPersona = "N"
                                txtdatosDesti.Text = nombres

                                Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", txtDnidesti.Text.Trim)

                                If existeEnDB Is Nothing Then
                                    txtdatosDesti.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    GrabarEntidadRapida()
                                    'PictureLoad.Visible = False
                                Else
                                    txtdatosDesti.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    txtdatosDesti.Tag = existeEnDB.idEntidad
                                    'If RadioButton2.Checked = True Then
                                    'TextFiltrar.Focus()
                                    'TextFiltrar.Select()
                                    'ElseIf RadioButton1.Checked = True Then
                                    '    txtruc.Focus()
                                    '    txtruc.Select()
                                    'End If
                                End If
                            Else
                                txtDnidesti.Clear()
                                txtdatosDesti.Text = String.Empty
                                txtdatosDesti.Tag = Nothing
                            End If
                            'PictureLoad.Visible = False
                        Else

                            'CUANDO NO HAY CONEXION A INTERNET
                            Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", txtDnidesti.Text.Trim)
                            If existeEnDB Is Nothing Then
                                SelRazon.tipoEntidad = "CL"
                                SelRazon.nombreCompleto = txtdatosDesti.Text.Trim
                                SelRazon.nrodoc = txtDnidesti.Text.Trim
                                SelRazon.tipoDoc = "1"
                                SelRazon.tipoPersona = "N"
                                'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                'GrabarEntidadRapida()
                                GrabarEnFormBasico()
                                'PictureLoad.Visible = False
                            Else
                                txtdatosDesti.Text = existeEnDB.nombreCompleto
                                txtdatosDesti.Tag = existeEnDB.idEntidad
                                txtdatosDesti.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                'If RadioButton2.Checked = True Then
                                'TextFiltrar.Focus()
                                'TextFiltrar.Select()
                                'ElseIf RadioButton1.Checked = True Then
                                '    txtruc.Focus()
                                '    txtruc.Select()
                                'End If
                            End If
                        End If



                    Case 11 'razonSocial
                        'PictureLoad.Visible = True

                        Dim objeto As Boolean = ValidationRUC(txtDnidesti.Text.Trim)
                        If objeto = False Then
                            'PictureLoad.Visible = False
                            MessageBox.Show("Debe Ingresar un número correcto de ruc", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Cursor = Cursors.Default
                            txtdatosDesti.Clear()
                            Exit Sub
                        End If

                        If My.Computer.Network.IsAvailable = True Then
                            'VALIDAR SI EXISTE EN LA bd LOCAL PRIMERO 
                            If GetValidarLocalDB(txtDnidesti.Text.Trim) = False Then
                                txtDnidesti.ReadOnly = True

                                Select Case ToggleConsultas.ToggleState
                                    Case ToggleButton2.ToggleButtonState.OFF ' API
                                        '  GetConsultaSunatAsync(TextNumIdentrazon.Text.Trim)
                                        GetApiSunat(txtDnidesti.Text.Trim)
                                    Case ToggleButton2.ToggleButtonState.ON ' WEB
                                        BgProveedor.RunWorkerAsync()
                                End Select
                            End If
                        Else
                            'SI NO HAY CONEXION A INTERNET
                            If GetValidarLocalDB(txtDnidesti.Text.Trim) = False Then
                                Dim nroDoc = txtDnidesti.Text.Trim.Substring(0, 1).ToString
                                If nroDoc = "1" Then
                                    'SelRazon.tipoEntidad = "CL"
                                    'SelRazon.nombreCompleto = TextEmpresaPasajero.Text.Trim
                                    'SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                                    'SelRazon.tipoDoc = "6"
                                    'SelRazon.tipoPersona = "N"
                                    'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    'GrabarEntidadRapida()
                                    GrabarEnFormBasico()
                                    'PictureLoad.Visible = False
                                    If txtDnidesti.Text.Trim.Length > 0 Then
                                        'TextFiltrar.Select()
                                        'TextFiltrar.Focus()
                                    Else
                                        txtDnidesti.Clear()
                                        txtDnidesti.Select()
                                    End If
                                ElseIf nroDoc = "2" Then
                                    'SelRazon.tipoEntidad = "CL"
                                    'SelRazon.nombreCompleto = TextEmpresaPasajero.Text.Trim
                                    'SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                                    'SelRazon.tipoDoc = "6"
                                    'SelRazon.tipoPersona = "J"
                                    'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    'GrabarEntidadRapida()
                                    GrabarEnFormBasico()
                                    'PictureLoad.Visible = False
                                    If txtdatosDesti.Text.Trim.Length > 0 Then
                                        'TextFiltrar.Select()
                                        'TextFiltrar.Focus()
                                    Else
                                        txtDnidesti.Clear()
                                        txtDnidesti.Select()
                                    End If
                                End If
                            End If
                        End If

                    Case Else
                        txtdatosDesti.Text = String.Empty
                        txtDnidesti.Text = String.Empty
                        MessageBox.Show("Ingrese un documento correcto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Select

            End If
            '    TextNumIdentrazon.Enabled = True

        Catch ew As WebException

            If ew.Status = WebExceptionStatus.ProtocolError Then
                'PictureLoad.Visible = False
                Dim [error] As String = New System.IO.StreamReader(ew.Response.GetResponseStream()).ReadToEnd()
                MessageBox.Show("DNI no encontrado en el padron, verifique si es menor de edad")
                txtDnidesti.Clear()
                txtDnidesti.Select()
                txtDnidesti.Focus()
                txtDnidesti.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function GetConsultarDNIReniec(Dni As String) As String
        Dim CLIENTE As New WebClient
        'Dim PAGINA As Stream = CLIENTE.OpenRead("http://aplicaciones007.jne.gob.pe/srop_publico/Consulta/Afiliado/GetNombresCiudadano?DNI=" & Dni)
        Dim PAGINA As Stream = CLIENTE.OpenRead("http://clientes.reniec.gob.pe/padronElectoral2012/consulta.htm?hTipo=2&hDni=" & Dni)
        Dim LECTOR As New StreamReader(PAGINA)
        Dim MIHTML As String = LECTOR.ReadToEnd
        Dim nombres = String.Empty
        ' Dim array = MIHTML.Split("|")
        Dim posicion = 0
        Dim doc As HtmlAgilityPack.HtmlDocument = New HtmlAgilityPack.HtmlDocument
        doc.LoadHtml(MIHTML)

        For Each node As HtmlTextNode In doc.DocumentNode.SelectNodes("//text()")
            Select Case posicion
                Case 36
                    nombres = node.Text
                    Exit For
                Case 42
                   ' TextDNI.Text = node.Text
                Case 60
                  '  TextProvincia.Text = node.Text
                Case 66
                 '   TextDepartamento.Text = node.Text
                Case 54
                    '   TextDistrito.Text = node.Text
            End Select
            posicion = posicion + 1
        Next


        '  nombres = MIHTML.Replace("|", Space(1))
        Return Trim(nombres)
    End Function


    Private Sub GrabarEntidadRapida()
        Dim obEntidad As New entidad
        Dim entidadSA As New entidadSA
        Try

            obEntidad.idEmpresa = Gempresas.IdEmpresaRuc
            obEntidad.idOrganizacion = GEstableciento.IdEstablecimiento
            obEntidad.tipoEntidad = "CL"
            obEntidad.tipoDoc = SelRazon.tipoDoc
            obEntidad.tipoPersona = SelRazon.tipoPersona
            obEntidad.nrodoc = SelRazon.nrodoc
            If tipotroDocD = 1 Then
                obEntidad.nombreCompleto = txtdatosDesti.Text.Trim
            ElseIf tipotroDocD = 2 Then
                obEntidad.nombreCompleto = txtRazoSocprovee.Text.Trim
            End If

            obEntidad.cuentaAsiento = "1213"
            obEntidad.direccion = SelRazon.direccion
            If SelRazon.direccion IsNot Nothing Then
                If SelRazon.direccion.Trim.Length > 0 Then
                    obEntidad.entidadAtributos = New List(Of entidadAtributos)
                    obEntidad.entidadAtributos.Add(New entidadAtributos With {
                                               .Action = BaseBE.EntityAction.INSERT,
                                               .tipo = "DOMICILIO",
                                               .tipoVia = SelRazon.TipoVia,
                                               .Via = SelRazon.Via,
                                               .ubigeo = SelRazon.Ubigeo,
                                               .estado = 1,
                                               .valorAtributo = SelRazon.direccion,
                                               .usuarioModificacion = usuario.IDUsuario,
                                               .fechaModificacion = Date.Now
                                               })
                End If
            End If
            obEntidad.estado = StatusEntidad.Activo
            Dim codx As Integer = entidadSA.GrabarEntidad(obEntidad)

            If tipotroDocD = 1 Then
                txtdatosDesti.Tag = codx
                Dim entidad As New entidad
                entidad.idEntidad = codx
                entidad.nrodoc = txtDnidesti.Text.Trim
                entidad.nombreCompleto = obEntidad.nombreCompleto
                entidad.tipoDoc = obEntidad.tipoDoc
                Me.Tag = entidad

            ElseIf tipotroDocD = 2 Then
                txtRazoSocprovee.Tag = codx
                Dim entidad As New entidad
                entidad.idEntidad = codx
                entidad.nrodoc = txtnumprovee.Text.Trim
                entidad.nombreCompleto = obEntidad.nombreCompleto
                entidad.tipoDoc = obEntidad.tipoDoc
                Me.Tag = entidad
            End If
            'If RadioButton2.Checked = True Then
            '    textPersona.Focus()
            '    textPersona.Select()
            'ElseIf RadioButton1.Checked = True Then
            '    txtruc.Focus()
            '    txtruc.Select()
            'End If
            'Transporte.ListaEmpresas.Add(entidad)

            '    Dispose()

            'Se asigna cada uno de los datos registrados

        Catch ex As Exception
            'Manejo de errores
            MsgBox("No se pudo grabar el cliente." & vbCrLf & ex.Message, MsgBoxStyle.Critical)
            Me.Tag = Nothing
        End Try
    End Sub


    Private Function GetValidarLocalDB(idEntidad As String) As Boolean
        GetValidarLocalDB = False
        Dim entidadSA As New entidadSA

        Dim entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", idEntidad)
        If entidad IsNot Nothing Then
            SelRazon = New entidad
            SelRazon = entidad

            If tipotroDocD = 1 Then
                txtdatosDesti.Text = entidad.nombreCompleto
                txtdatosDesti.Tag = entidad.idEntidad
                GetValidarLocalDB = True
                'PictureLoad.Visible = False

                If txtdatosDesti.Text.Trim.Length > 0 Then
                    'TextFiltrar.Select()
                    'TextFiltrar.Focus()
                Else
                    txtDnidesti.Clear()
                    txtDnidesti.Select()
                End If
            ElseIf tipotroDocD = 2 Then
                txtRazoSocprovee.Text = entidad.nombreCompleto
                txtRazoSocprovee.Tag = entidad.idEntidad
                GetValidarLocalDB = True
                'PictureLoad.Visible = False

                If txtRazoSocprovee.Text.Trim.Length > 0 Then
                    'TextFiltrar.Select()
                    'TextFiltrar.Focus()
                Else
                    txtnumprovee.Clear()
                    txtnumprovee.Select()
                End If
            End If


        End If
    End Function

    Private Sub GrabarEnFormBasico()
        Dim f As New frmCrearENtidades
        f.strTipo = TIPO_ENTIDAD.CLIENTE
        f.CaptionLabels(0).Text = "Nuevo cliente"
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If tipotroDocD = 1 Then
            If f.Tag IsNot Nothing Then
                Dim ent = CType(f.Tag, entidad)
                txtDnidesti.Text = ent.nrodoc
                txtdatosDesti.Text = ent.nombreCompleto
                txtdatosDesti.Tag = ent.idEntidad
            Else
                txtDnidesti.Text = String.Empty
                txtdatosDesti.Text = String.Empty
                txtdatosDesti.Tag = Nothing
            End If
        ElseIf tipotroDocD = 2 Then
            If f.Tag IsNot Nothing Then
                Dim ent = CType(f.Tag, entidad)
                txtnumprovee.Text = ent.nrodoc
                txtRazoSocprovee.Text = ent.nombreCompleto
                txtRazoSocprovee.Tag = ent.idEntidad
            Else
                txtnumprovee.Text = String.Empty
                txtRazoSocprovee.Text = String.Empty
                txtRazoSocprovee.Tag = Nothing
            End If
        End If


    End Sub


    Private Async Sub GetApiSunat(ByVal nroruc As String)
        SelRazon = New entidad()

        Using client = New HttpClient()

            If nroruc.ToString().Trim().Substring(0, 1) = "1" Then
                SelRazon.tipoPersona = "N"
            ElseIf nroruc.ToString().Trim().Substring(0, 1) = "2" Then
                SelRazon.tipoPersona = "J"
            End If

            'client.BaseAddress = New Uri("https://api.peruonline.cloud/v1/?ruc=10449245691")
            Dim responseTask = Await client.GetAsync("https://api.peruonline.cloud/v1/?ruc=" & nroruc)
            ' responseTask.Wait()
            'Dim result = responseTask.Result

            If responseTask.IsSuccessStatusCode Then
                Dim readTask = responseTask.Content.ReadAsAsync(Of SunatContribuyente)()
                readTask.Wait()
                Dim students = readTask.Result
                SelRazon.tipoDoc = "6"
                SelRazon.tipoEntidad = "CL"
                SelRazon.nombreCompleto = students.NombreORazonSocial
                SelRazon.nombreContacto = students.NombreORazonSocial

                If tipotroDocD = 1 Then
                    txtdatosDesti.Text = students.NombreORazonSocial
                ElseIf tipotroDocD = 2 Then
                    txtRazoSocprovee.Text = students.NombreORazonSocial
                End If

                SelRazon.estado = students.EstadoDelContribuyente
                SelRazon.nrodoc = students.Ruc
                SelRazon.direccion = students.Direccion & " " & students.Manzana & " " & students.Lote & " " & students.CodigoDeZona & " " & students.TipoDeZona

                SelRazon.TipoVia = students.TipoDeVia
                SelRazon.Via = students.NombreDeVia
                SelRazon.Ubigeo = students.Ubigeo

                GrabarEntidadRapida()
                'PictureLoad.Visible = False
            Else
                GetConsultaSunatAsync(nroruc)

                'TextProveedor.Clear()
                'PictureLoad.Visible = False
            End If

            If tipotroDocD = 1 Then
                txtDnidesti.ReadOnly = False
            ElseIf tipotroDocD = 2 Then
                txtnumprovee.ReadOnly = False
            End If



        End Using
    End Sub

    Private Sub BgProveedor_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgProveedor.DoWork
        If tipotroDocD = 1 Then
            GetConsultaSunatThread(txtDnidesti.Text)
        ElseIf tipotroDocD = 2 Then
            GetConsultaSunatThread(txtnumprovee.Text)
        End If
    End Sub


    Private Sub GetConsultaSunatThread(ruc As String)
        SelRazon = New entidad
        Dim nroDoc = ruc.Substring(0, 1).ToString
        If nroDoc = "1" Then

            'getRuc donde ase llama como el company
            Dim sunat As New Helios.Consultas.Sunat.Sunat()
            sunat.GenerateCapchaTemporal()
            Dim valorCapcha = sunat.Decode_CapchaTemporal()
            Dim company As ProcesosJH.DatosRuc = ProcesosJH.ConsultarRUC(ruc, valorCapcha)

            'Dim datosSunat = New Helios.Sunat.Consulta.GetConsultaSunat()
            'Dim company = datosSunat.GetConsultaRuc(ruc)

            '  Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
            If company.Ruc IsNot Nothing Then
                If company.RazonSocial = "ERROR" Then

                Else
                    SelRazon.tipoPersona = "N"
                    SelRazon.tipoDoc = "6"
                    SelRazon.tipoEntidad = "CL"
                    SelRazon.nombreCompleto = company.RazonSocial
                    SelRazon.nombreContacto = company.RazonSocial
                    SelRazon.estado = company.Estado_Contribuyente
                    SelRazon.nrodoc = company.Ruc
                    SelRazon.direccion = company.DireccionDomicilioFiscal
                End If

            Else

            End If
        ElseIf nroDoc = "2" Then
            Dim sunat As New Helios.Consultas.Sunat.Sunat()
            sunat.GenerateCapchaTemporal()
            Dim valorCapcha = sunat.Decode_CapchaTemporal()
            Dim company As ProcesosJH.DatosRuc = ProcesosJH.ConsultarRUC(ruc, valorCapcha)

            'Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
            If company.Ruc IsNot Nothing Then
                'If company.ContribuyenteTipo = "SOCIEDAD ANONIMA CERRADA" Then
                If company.RazonSocial = "ERROR" Then

                Else
                    SelRazon.tipoPersona = "J"
                    SelRazon.tipoDoc = "6"
                    SelRazon.tipoEntidad = "CL"
                    SelRazon.nombreCompleto = company.RazonSocial
                    SelRazon.nombreContacto = company.RazonSocial
                    SelRazon.estado = company.Estado_Contribuyente
                    SelRazon.direccion = company.DireccionDomicilioFiscal
                    SelRazon.nrodoc = company.Ruc

                End If
            Else

            End If
        End If
    End Sub


    Private Async Sub GetConsultaSunatAsync(ruc As String)
        SelRazon = New entidad
        Dim nroDoc = ruc.Substring(0, 1).ToString
        If nroDoc = "1" Then
            Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
            If company IsNot Nothing Then
                ' If company.ContribuyenteTipo = "PERSONA NATURAL SIN NEGOCIO" Then
                SelRazon.tipoPersona = "N"
                SelRazon.tipoDoc = "6"
                ' End If
                SelRazon.tipoEntidad = "CL"
                SelRazon.nombreCompleto = company.RazonSocial
                '********/1/***************
                If tipotroDocD = 1 Then
                    txtdatosDesti.Text = company.RazonSocial
                ElseIf tipotroDocD = 2 Then
                    '********/2/***************
                    txtRazoSocprovee.Text = company.RazonSocial
                End If



                SelRazon.nombreContacto = company.RazonSocial
                SelRazon.estado = company.ContribuyenteEstado
                SelRazon.nrodoc = company.Ruc
                SelRazon.direccion = company.DomicilioFiscal
                GrabarEntidadRapida()
                'PictureLoad.Visible = False
            Else

                If tipotroDocD = 1 Then
                    txtdatosDesti.Clear()
                ElseIf tipotroDocD = 2 Then
                    txtRazoSocprovee.Clear()
                End If



                'PictureLoad.Visible = False
            End If
        ElseIf nroDoc = "2" Then
            Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
            If company IsNot Nothing Then
                'If company.ContribuyenteTipo = "SOCIEDAD ANONIMA CERRADA" Then
                SelRazon.tipoPersona = "J"
                SelRazon.tipoDoc = "6"
                SelRazon.tipoEntidad = "CL"
                '  End If
                SelRazon.nombreCompleto = company.RazonSocial
                SelRazon.nombreContacto = company.RazonSocial

                If tipotroDocD = 1 Then
                    txtdatosDesti.Text = company.RazonSocial
                ElseIf tipotroDocD = 2 Then
                    '********/2/***************
                    txtRazoSocprovee.Text = company.RazonSocial
                End If

                SelRazon.estado = company.ContribuyenteEstado
                SelRazon.direccion = company.DomicilioFiscal
                SelRazon.nrodoc = company.Ruc
                'If company.RepresentanteLegal IsNot Nothing Then
                '    If company.RepresentanteLegal.Dni41094462 IsNot Nothing Then
                '        With company.RepresentanteLegal.Dni41094462
                '            txtContacto.Text = String.Format("{0}/{1}/{2}", .Cargo, .Nombre, .Desde)
                '        End With
                '    End If
                'End If
                GrabarEntidadRapida()
                'PictureLoad.Visible = False
            Else

                If tipotroDocD = 1 Then
                    txtdatosDesti.Clear()
                ElseIf tipotroDocD = 2 Then
                    txtRazoSocprovee.Clear()
                End If


                'PictureLoad.Visible = False
            End If
        End If
        If tipotroDocD = 1 Then
            txtDnidesti.ReadOnly = False
        ElseIf tipotroDocD = 2 Then
            txtnumprovee.ReadOnly = False
        End If

    End Sub

#End Region


    Private Sub ComboBoxAdv1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTipoDocdes.SelectedIndexChanged
        Select Case cbTipoDocdes.Text
            Case "SIN IDENTIFICACION "
                txtDnidesti.Enabled = False
                txtDnidesti.Clear()

            Case "DNI"
                txtDnidesti.Enabled = True
                txtdatosDesti.Clear()
                txtDnidesti.Clear()
                txtDnidesti.Select()
                txtDnidesti.MaxLength = 8

            Case "RUC"
                txtDnidesti.Enabled = True
                txtdatosDesti.Clear()
                txtDnidesti.Clear()
                txtDnidesti.Select()
                txtDnidesti.MaxLength = 11

        End Select
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            combotipoGuia.Enabled = True
            txtotraguia.Enabled = False
            txtotraguia.BackColor = Color.WhiteSmoke
            txtotraguia.Clear()
        Else
            combotipoGuia.SelectedValue = -1
            combotipoGuia.Enabled = False
            txtotraguia.Enabled = True
            combotipoGuia.BackColor = Color.WhiteSmoke
            txtotraguia.BackColor = Color.White
            txtotraguia.Select()
        End If
    End Sub


End Class