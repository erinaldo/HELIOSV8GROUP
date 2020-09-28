Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms

Public Class FormCrearAnticipo

#Region "Attributes"
    Public Property anticipoSA As New documentoAnticipoSA
    Public Property cuentaSA As New EstadosFinancierosSA
    Public Property ListaCuentasBancarias As List(Of estadosFinancieros)
    Public Property ListaCuentas As List(Of estadosFinancieros)
    Public Property entidadSA As New entidadSA
    Friend Delegate Sub SetDataSourceDelegate(ByVal lista As List(Of entidad))
    Public Property listaClientes As List(Of entidad)
#End Region

#Region "Constructors"
    Public Sub New(be As entidad)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        configuracionModuloV2(Gempresas.IdEmpresaRuc, "ANT", "ANTICIPOS", GEstableciento.IdEstablecimiento)
        textFecha.Value = Date.Now
        GetLoad()
        TextPersona.Enabled = False
        GetMappingEntidad(be)
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        configuracionModuloV2(Gempresas.IdEmpresaRuc, "ANT", "ANTICIPOS", GEstableciento.IdEstablecimiento)
        textFecha.Value = Date.Now
        GetLoad()
        threadClientes()
        TextPersona.Enabled = True
        '  GetMappingEntidad(be)
    End Sub
#End Region

#Region "Entidad"
    Dim thread As System.Threading.Thread
    Private Sub threadClientes()
        Dim tipo = General.TIPO_ENTIDAD.CLIENTE
        Dim empresa = General.Gempresas.IdEmpresaRuc
        ProgressBar1.Visible = True
        ProgressBar1.Style = ProgressBarStyle.Marquee
        thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetClientes(tipo, empresa)))
        thread.Start()
    End Sub

    Private Sub GetClientes(tipo As String, empresa As String)
        Dim lista As New List(Of entidad)
        lista = New List(Of entidad)
        '  Dim varios = entidadSA.UbicarEntidadVarios("VR", General.Gempresas.IdEmpresaRuc, String.Empty)
        'Dim lista = entidadSA.ObtenerListaEntidad(tipo, empresa)
        lista.Add(VarClienteGeneral)
        lista.AddRange(entidadSA.GetListarEntidad(New entidad With {.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA}))
        setDataSource(lista)
    End Sub

    Private Sub setDataSource(ByVal lista As List(Of entidad))
        If Me.InvokeRequired Then
            'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

            Dim deleg As New SetDataSourceDelegate(AddressOf setDataSource)
            Invoke(deleg, New Object() {lista})
        Else
            listaClientes = New List(Of entidad)
            listaClientes = lista
            ProgressBar1.Visible = False
        End If
    End Sub
#End Region

#Region "Methods"
    Private Sub FillLSVClientes(consulta As List(Of entidad))
        LsvProveedor.Items.Clear()
        '     Dim image = ImageList1.Images(0)
        For Each i In consulta
            Dim n As New ListViewItem(i.idEntidad)

            n.SubItems.Add(i.nombreCompleto)
            n.SubItems.Add(i.nrodoc)
            n.SubItems.Add(i.tipoDoc)
            LsvProveedor.Items.Add(n)
        Next
    End Sub

    Private Sub GetCalculo()
        Dim importe = TextValorPrestamo.DecimalValue
        Dim baseImponible = Math.Round(CDec(CalculoBaseImponible(importe, 1.18)), 2)
        Dim iva = Math.Round(importe - baseImponible, 2)
        TextBaseImponible.DecimalValue = baseImponible
        TextValorIva.DecimalValue = iva
    End Sub

    'Public Sub configuracionModulo(strIDEmpresa As String, strIdModulo As String, strNomModulo As String, intIdEstablecimiento As Integer)
    '    Dim moduloConfiguracionSA As New ModuloConfiguracionSA
    '    Dim moduloConfiguracion As New moduloConfiguracion
    '    Dim numeracionSA As New NumeracionBoletaSA
    '    Dim TablaSA As New tablaDetalleSA
    '    Dim almacenSA As New almacenSA
    '    Dim cajaSA As New EstadosFinancierosSA

    '    moduloConfiguracion = moduloConfiguracionSA.UbicarConfiguracionPorEmpresaModulo(strIdModulo, strIDEmpresa, intIdEstablecimiento)
    '    If Not IsNothing(moduloConfiguracion) Then
    '        With moduloConfiguracion
    '            GConfiguracion = New GConfiguracionModulo
    '            GConfiguracion.IdModulo = .idModulo
    '            GConfiguracion.NomModulo = strNomModulo
    '            GConfiguracion.TipoConfiguracion = .tipoConfiguracion
    '            Select Case .tipoConfiguracion
    '                Case "P"
    '                    With numeracionSA.GetUbicar_numeracionBoletasPorID(.configComprobante)
    '                        GConfiguracion.ConfigComprobante = .IdEnumeracion
    '                        GConfiguracion.TipoComprobante = .tipo
    '                        GConfiguracion.NombreComprobante = TablaSA.GetUbicarTablaID(10, .tipo).descripcion
    '                        GConfiguracion.Serie = .serie
    '                        GConfiguracion.ValorActual = .valorInicial
    '                    End With
    '                Case "M"

    '            End Select
    '            If Not IsNothing(.configAlmacen) Then
    '                Dim estableSA As New establecimientoSA
    '                With almacenSA.GetUbicar_almacenPorID(.configAlmacen)
    '                    GConfiguracion.IdAlmacen = .idAlmacen
    '                    GConfiguracion.NombreAlmacen = .descripcionAlmacen

    '                End With
    '            End If
    '            If Not IsNothing(.ConfigentidadFinanciera) Then
    '                With cajaSA.GetUbicar_estadosFinancierosPorID(.ConfigentidadFinanciera)
    '                    GConfiguracion.IDCaja = .idestado
    '                    GConfiguracion.NomCaja = .descripcion
    '                End With
    '            End If

    '        End With
    '    Else
    '        '  lblEstado.Text = "Este módulo no contiene una configuración disponible, intentelo más tarde.!"
    '        'Timer1.Enabled = True
    '        'TabCompra.Enabled = False
    '        'TiempoEjecutar(5)
    '    End If
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
                GConfiguracion.TipoComprobante = RecuperacionNumeracion.tipo
                GConfiguracion.NombreComprobante = TablaSA.GetUbicarTablaID(10, RecuperacionNumeracion.tipo).descripcion
                GConfiguracion.Serie = RecuperacionNumeracion.serie
                GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial
            Else
                Throw New Exception("Verificar configuración")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GetCuentasFinancieras()
        ComboCuentaFinanciera.DataSource = ListaCuentas
        ComboCuentaFinanciera.DisplayMember = "descripcion"
        ComboCuentaFinanciera.ValueMember = "idestado"
    End Sub

    Private Sub GetLoad()
        Dim tablaSA As New tablaDetalleSA

        Dim listaFormaPago = tablaSA.GetListaTablaDetalle(1, "1")
        Dim customLista As New List(Of String) From
            {
            "EFECTIVO",
            "DEPOSITO EN CUENTA",
            "TARJETA DE DEBITO",
            "TARJETA DE CREDITO"
            }
        listaFormaPago = listaFormaPago.Where(Function(o) customLista.Contains(o.descripcion)).ToList
        ComboFormaDeposito.DataSource = listaFormaPago
        ComboFormaDeposito.DisplayMember = "descripcion"
        ComboFormaDeposito.ValueMember = "codigoDetalle"
        ComboFormaDeposito.Text = "EFECTIVO"

        ListaCuentasBancarias = cuentaSA.ObtenerEstadosFinancierosPorEstablecimiento(New estadosFinancieros With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})


    End Sub

    Private Sub Grabar()
        Dim TipoConfiguracion As String = String.Empty
        Dim tipoDocumento As String = String.Empty
        Dim ConfigComprobante As Integer

        Select Case ComboTipoAnticipo.selectedIndex
            Case 0 'FACTURA
                ConfigComprobante = 0
                TipoConfiguracion = String.Empty
                tipoDocumento = "01"
            Case 1

                ConfigComprobante = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
                TipoConfiguracion = GConfiguracion.TipoConfiguracion
                tipoDocumento = "9901"
        End Select

        Dim documento As New documento With
        {
         .idEmpresa = Gempresas.IdEmpresaRuc,
        .idCentroCosto = GEstableciento.IdEstablecimiento,
        .tipoDoc = tipoDocumento,
        .fechaProceso = textFecha.Value,
        .nroDoc = ConfigComprobante,' IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante),
        .tipoOperacion = StatusTipoOperacion.ANTICIPOS_RECIBIDOS,
        .tipoEntidad = "CL",
        .entidad = TextPersona.Text,
        .nrodocEntidad = "-",
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = Date.Now
        }

        documento.documentoAnticipo = New documentoAnticipo With
        {
        .idEmpresa = Gempresas.IdEmpresaRuc,
        .idEstablecimiento = GEstableciento.IdEstablecimiento,
        .tipoDocumento = tipoDocumento,
        .TipoConfiguracion = TipoConfiguracion,' GConfiguracion.TipoConfiguracion,
        .IdNumeracion = ConfigComprobante,' IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante),
        .numeroDoc = .IdNumeracion,
        .fechaDoc = textFecha.Value,
        .fechaPeriodo = GetPeriodo(textFecha.Value, True),
        .tipoOperacion = StatusTipoOperacion.ANTICIPOS_RECIBIDOS,
        .tipoAnticipo = Anticipo.Tipo.Recibido,
        .razonSocial = CInt(TextPersona.Tag),
        .TipoCambio = TmpTipoCambio,
        .Moneda = 1,
        .baseImponible = TextBaseImponible.DecimalValue,
        .iva = TextValorIva.DecimalValue,
        .importeMN = TextValorPrestamo.DecimalValue,
        .importeME = 0,
        .idEntidadFinanciera = CInt(ComboCuentaFinanciera.SelectedValue),
        .estado = Anticipo.Estado.NotaCredito,
        .usuarioModificacion = usuario.IDUsuario,
        .fechaActualizacion = Date.Now
        }

        'documento.documentoAnticipo.documentoAnticipoDetalle = New List(Of documentoAnticipoDetalle) From
        '    {
        '    New documentoAnticipoDetalle With
        '        {
        '        .idEmpresa = Gempresas.IdEmpresaRuc,
        '        .idEstablecimiento = GEstableciento.IdEstablecimiento,
        '        .codigoOperacion = "103",
        '        .descripcion = "Anticipos Recibidos",
        '        .importeMN = TextValorPrestamo.DecimalValue,
        '        .importeME = 0,
        '        .usuarioModificacion = usuario.IDUsuario,
        '        .fechaActualizacion = Date.Now
        '        }
        '    }

        Dim DocumentoCaja = GetComprobanteCaja(documento.documentoAnticipo)
        documento.CustomDocumentoCaja = DocumentoCaja
        anticipoSA.SaveAnticipo(documento)
        MessageBox.Show("Anticipo registrado!", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close()
    End Sub

    Function GetComprobanteCaja(be As documentoAnticipo) As documento
        Dim nDocumentoCaja As New documento()
        Dim objCaja As New documentoCaja
        Dim objCajaDetalle As New documentoCajaDetalle
        Dim ListaDetalle As New List(Of documentoCajaDetalle)

        nDocumentoCaja = New documento With
        {
            .idDocumento = 0,
            .idEmpresa = Gempresas.IdEmpresaRuc,
            .idCentroCosto = GEstableciento.IdEstablecimiento,
            .fechaProceso = textFecha.Value,
            .tipoDoc = be.tipoDocumento,
            .nroDoc = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante),
            .idOrden = Nothing,
            .tipoOperacion = be.tipoOperacion,
            .tipoEntidad = "CL",
            .entidad = TextPersona.Text,
            .nrodocEntidad = "-",
            .usuarioActualizacion = usuario.IDUsuario,
            .fechaActualizacion = Date.Now
        }

        objCaja = New documentoCaja With
        {
            .idDocumento = 0,
            .idEmpresa = Gempresas.IdEmpresaRuc,
            .idEstablecimiento = GEstableciento.IdEstablecimiento,
            .tipoMovimiento = MovimientoCaja.EntradaDinero,
            .IdProveedor = be.razonSocial,
            .codigoLibro = "1",
            .codigoProveedor = be.razonSocial,
            .formapago = ComboFormaDeposito.SelectedValue,
            .TipoDocumentoPago = be.tipoDocumento,
            .tipoDocPago = be.tipoDocumento,
            .periodo = be.fechaPeriodo,
            .NumeroDocumento = Nothing,
            .moneda = be.Moneda,
            .glosa = "Registro de anticipos",
            .numeroOperacion = String.Empty,
            .ctaCorrienteDeposito = Nothing,
            .ctaIntebancaria = Nothing,
            .bancoEntidad = Nothing,
            .fechaCobro = be.fechaDoc,
            .fechaProceso = Date.Now,
            .entregado = "SI",
            .tipoCambio = 1,
            .montoSoles = TextValorPrestamo.DecimalValue,
            .montoUsd = 0,
            .entidadFinanciera = Integer.Parse(ComboCuentaFinanciera.SelectedValue),
            .tipoOperacion = be.tipoOperacion,
            .movimientoCaja = "AR",
            .idCajaUsuario = GFichaUsuarios.IdCajaUsuario.GetValueOrDefault,
            .estado = "1",
            .usuarioModificacion = usuario.IDUsuario,
            .fechaModificacion = DateTime.Now
        }
        nDocumentoCaja.documentoCaja = objCaja

        objCajaDetalle = New documentoCajaDetalle
        objCajaDetalle.idDocumento = 0
        objCajaDetalle.fecha = be.fechaDoc
        objCajaDetalle.idItem = Nothing
        objCajaDetalle.DetalleItem = Nothing
        objCajaDetalle.montoSoles = be.importeMN
        objCajaDetalle.montoUsd = be.importeME
        objCajaDetalle.entregado = "SI"
        objCajaDetalle.moneda = be.Moneda
        objCajaDetalle.diferTipoCambio = 0
        objCajaDetalle.idCajaUsuario = GFichaUsuarios.IdCajaUsuario.GetValueOrDefault
        objCajaDetalle.usuarioModificacion = usuario.IDUsuario
        objCajaDetalle.fechaModificacion = DateTime.Now
        ListaDetalle.Add(objCajaDetalle)
        nDocumentoCaja.documentoCaja.documentoCajaDetalle = ListaDetalle


        '   nDocumentoCaja.documentoCaja.documentoCajaDetalle.Add(objCajaDetalle)
        Return nDocumentoCaja
    End Function

    Sub GetMappingEntidad(be As entidad)
        TextPersona.Tag = be.idEntidad
        TextPersona.Text = be.nombreCompleto
        TextRuc.Text = be.nrodoc
    End Sub

#End Region

#Region "Events"

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LsvProveedor.MouseDoubleClick, TextPersona.MouseDoubleClick
        Me.pcLikeCategoria.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub pcLikeCategoria_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcLikeCategoria.CloseUp
        Dim beneficioSA As New beneficioSA
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.PopupCloseType = PopupCloseType.Done Then
                If LsvProveedor.SelectedItems.Count > 0 Then
                    If LsvProveedor.SelectedItems(0).SubItems(1).Text = "Agregar nuevo" Then
                        Dim f As New frmCrearENtidades
                        f.CaptionLabels(0).Text = "Nuevo cliente"
                        f.strTipo = TIPO_ENTIDAD.CLIENTE
                        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        'f.tipoPersona(TIPO_ENTIDAD.CLIENTE)
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog()
                        If Not IsNothing(f.Tag) Then
                            Dim c = CType(f.Tag, entidad)
                            listaClientes.Add(c)
                            'txtTipoDocClie.Text = c.tipoDoc
                            TextPersona.Text = c.nombreCompleto
                            TextRuc.Text = c.nrodoc
                            TextPersona.Tag = c.idEntidad
                            TextRuc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                            TextRuc.Visible = True
                            TextPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        End If
                    Else
                        TextPersona.Text = LsvProveedor.SelectedItems(0).SubItems(1).Text
                        TextPersona.Tag = LsvProveedor.SelectedItems(0).SubItems(0).Text
                        TextPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        TextRuc.Text = LsvProveedor.SelectedItems(0).SubItems(2).Text
                        'txtTipoDocClie.Text = LsvProveedor.SelectedItems(0).SubItems(3).Text
                        TextRuc.Visible = True
                        'ListaBeneficios = New List(Of Business.Entity.beneficio)
                        'ListaBeneficios = beneficioSA.BeneficioListaClienteProductions(New Business.Entity.beneficio With {.idCliente = Integer.Parse(TXTcOMPRADOR.Tag)})

                        'If ListaBeneficios.Count > 0 Then
                        '    TotalesColumnaDescuentos(ListaBeneficios)
                        'Else
                        '    TotalesColumnaDescuentos(ListaBeneficios)
                        'End If


                        'TextBenefClienteBase.Text = beneficio.importeBase.GetValueOrDefault
                        'TextValorAfecto.Text = beneficio.valorConvertido

                        'Select Case beneficio.tipoAfectacion
                        '    Case "I"
                        '        TextTipoBeneficio.Text = "IMPORTE"
                        '    Case "C"
                        '        TextTipoBeneficio.Text = "CANTIDAD"
                        '    Case "P"
                        '        TextTipoBeneficio.Text = "PORCENTAJE"
                        'End Select

                    End If
                    'ListaMercaderiasXIdHijo(Val(txtSubCategoria.Tag), cboTipoExistencia.SelectedValue)
                End If
            End If

            'Set focus back to textbox.
            If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
                Me.TextPersona.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub


    Private Sub TXTcOMPRADOR_TextChanged(sender As Object, e As EventArgs) Handles TextPersona.TextChanged
        TextPersona.ForeColor = Color.Black
        TextPersona.Tag = Nothing
        If TextPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            TextRuc.Visible = True
        Else
            TextRuc.Visible = True
        End If
    End Sub

    Private Sub TXTcOMPRADOR_KeyDown(sender As Object, e As KeyEventArgs) Handles TextPersona.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcLikeCategoria.Size = New Size(282, 128)
            Me.pcLikeCategoria.ParentControl = Me.TextPersona
            Me.pcLikeCategoria.ShowPopup(Point.Empty)
            Dim consulta As New List(Of entidad)
            consulta.Add(New entidad With {.nombreCompleto = "Agregar nuevo"})



            Dim consulta2 = (From n In listaClientes
                             Where n.nombreCompleto.StartsWith(TextPersona.Text) Or n.nrodoc.StartsWith(TextPersona.Text)).ToList




            consulta.AddRange(consulta2)
            FillLSVClientes(consulta)
            e.Handled = True
        End If

        If e.KeyCode = Keys.Down Then
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcLikeCategoria.Size = New Size(282, 128)
            Me.pcLikeCategoria.ParentControl = Me.TextPersona
            Me.pcLikeCategoria.ShowPopup(Point.Empty)
            LsvProveedor.Focus()
        End If
        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.pcLikeCategoria.IsShowing() Then
                Me.pcLikeCategoria.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub ButtonGrabar_Click(sender As Object, e As EventArgs) Handles ButtonGrabar.Click
        Try
            Dim info = $"{"Confirma el registro con fecha: "} {textFecha.Value}"
            If MessageBox.Show(info, "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Grabar()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Atención")
        End Try
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Close()
    End Sub

    Private Sub ComboFormaDeposito_Click(sender As Object, e As EventArgs) Handles ComboFormaDeposito.Click

    End Sub

    Private Sub ComboFormaDeposito_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboFormaDeposito.SelectedValueChanged
        If ComboFormaDeposito.Text = "EFECTIVO" Then
            If ListaCuentasBancarias IsNot Nothing Then
                If ListaCuentasBancarias.Count > 0 Then
                    Dim Lista = ListaCuentasBancarias.Where(Function(o) o.tipo = "EF").ToList
                    ListaCuentas = Lista
                    GetCuentasFinancieras()
                End If
            End If
        Else
            If ListaCuentasBancarias IsNot Nothing Then
                If ListaCuentasBancarias.Count > 0 Then
                    Dim Lista = ListaCuentasBancarias.Where(Function(o) o.tipo <> "EF").ToList
                    ListaCuentas = Lista
                    GetCuentasFinancieras()
                End If
            End If
        End If
    End Sub

    Private Sub ComboTipoDoc_onItemSelected(sender As Object, e As EventArgs) Handles ComboTipoDoc.onItemSelected
        If ComboTipoDoc.selectedIndex = 0 Then 'factura
            TextNumeroDocumento.Enabled = True
            TextNumeroDocumento.Clear()
        ElseIf ComboTipoDoc.selectedIndex = 1 Then
            TextNumeroDocumento.Enabled = False
            TextNumeroDocumento.Clear()
        End If
    End Sub

    Private Sub TextValorPrestamo_TextChanged(sender As Object, e As EventArgs) Handles TextValorPrestamo.TextChanged
        GetCalculo()
    End Sub

    Private Sub FormCrearAnticipo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ComboCuentaFinanciera_Click(sender As Object, e As EventArgs) Handles ComboCuentaFinanciera.Click

    End Sub

#End Region

End Class