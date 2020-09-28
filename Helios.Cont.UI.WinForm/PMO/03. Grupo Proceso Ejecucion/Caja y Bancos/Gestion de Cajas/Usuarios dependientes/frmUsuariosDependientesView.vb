Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Drawing

Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Imports System.ComponentModel

Public Class frmUsuariosDependientesView
    Inherits frmMaster

    Dim cajaUsuarioSA As New cajaUsuarioSA
    Dim cajaUsuario As New cajaUsuario

    Public Sub New(rec As Record)

        ' This call is required by the designer.
        InitializeComponent()
        ' GRID()
        GridCFG(gridGroupingControl1)
        ' Add any initialization after the InitializeComponent() call.
        Label4.Visible = False
        '  txtCajaRecepcion.Visible = False
        cboTipo.Visible = False

        cboDepositoHijo.Visible = False

        lblFecCierre.Visible = False
        txtFechaCierre.Visible = False
        txtFondoAdepositar.Visible = False
        txtFondoAdepositarme.Visible = False
        lblimporteCierre.Visible = False
        btOperacion.Visible = False
        record = rec

        cajaUsuario = cajaUsuarioSA.UbicarCajaUsuarioPorID(rec.GetValue("idcajaUsuario"))
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        InitializeComponent()
        ' GRID()
        GridCFG(gridGroupingControl1)
        Label4.Visible = False
        '  txtCajaRecepcion.Visible = False
        cboTipo.Visible = False

        cboDepositoHijo.Visible = False

        lblFecCierre.Visible = False
        txtFechaCierre.Visible = False
    End Sub

    Dim colorx As New GridMetroColors()

    Dim record As Record
#Region "Métodos"

    Dim ingresoMN As Decimal = 0
    Dim ingresoME As Decimal = 0

    Dim egresoMN As Decimal = 0
    Dim egresoME As Decimal = 0

    Public Sub CargarCajasTipo(strBusqueda As String)
        Dim estadoSA As New EstadosFinancierosSA
        Dim taBLASA As New tablaDetalleSA
        Dim ListaestadoBL As New List(Of estadosFinancieros)
        Dim estadoBL As New estadosFinancieros

        Try
            Me.cboDepositoHijo.DataSource = estadoSA.ObtenerEFPorCuentaFinanciera(New estadosFinancieros With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                                  .tipo = strBusqueda,
                                                                                  .tipoConsulta = StatusTipoConsulta.XEmpresa})
            Me.cboDepositoHijo.DisplayMember = "descripcion"
            Me.cboDepositoHijo.ValueMember = "idestado"
            cboDepositoHijo.SelectedValue = -1

        Catch ex As Exception

        End Try
    End Sub

    Public Function AS_CAJA_ORIGEN() As movimiento
        Dim efSA As New EstadosFinancierosSA
        Dim ef As New estadosFinancieros
        Dim nMovimiento As New movimiento

        ef = efSA.GetUbicar_estadosFinancierosPorID(cajaUsuario.idCajaOrigen)

        nMovimiento = New movimiento With {
              .cuenta = ef.cuenta,
              .descripcion = ef.descripcion,
              .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
              .monto = txtFondoAdepositar.DecimalValue,
              .montoUSD = txtFondoAdepositarme.DecimalValue,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = usuario.IDUsuario}

        Return nMovimiento
    End Function

    Public Function AS_CAJA_DESTINO() As movimiento
        Dim efSA As New EstadosFinancierosSA
        Dim ef As New estadosFinancieros
        Dim nMovimiento As New movimiento
        Try
            ef = efSA.GetUbicar_estadosFinancierosPorID(cboDepositoHijo.SelectedValue)
            nMovimiento = New movimiento With {
                .cuenta = ef.cuenta,
                .descripcion = ef.descripcion,
                .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
                .monto = txtFondoAdepositar.DecimalValue,
                .montoUSD = txtFondoAdepositarme.DecimalValue,
                .fechaActualizacion = DateTime.Now,
                .usuarioActualizacion = usuario.IDUsuario}
        Catch ex As Exception
            Throw ex
        End Try
        Return nMovimiento
    End Function

    Function asientoCaja() As asiento
        Dim nAsiento As New asiento
        Dim nDebe As New movimiento
        Dim nHaber As New movimiento

        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = CInt(txtPersona.Tag)
        nAsiento.nombreEntidad = txtPersona.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PERSONAL_PLANILLA
        nAsiento.fechaProceso = txtFechaCierre.Value
        nAsiento.codigoLibro = "1"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.CIERRE_CAJA_USUARIO
        nAsiento.importeMN = txtFondoAdepositar.DecimalValue
        nAsiento.importeME = txtFondoAdepositarme.DecimalValue
        nAsiento.glosa = "Por cierre de caja."
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now

        nAsiento.movimiento.Add(AS_CAJA_ORIGEN)
        nAsiento.movimiento.Add(AS_CAJA_DESTINO)

        Return nAsiento
    End Function

    Public Sub CerrarCajaUsuario(r As Record)
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim cajaUsuario As New cajaUsuario
        Dim nDocumento As New documento
        Dim asiento As New asiento
        Dim ListaAsiento As New List(Of asiento)
        Try
            With cajaUsuario
                .idcajaUsuario = r.GetValue("idcajaUsuario")
                .fechaCierre = txtFechaCierre.Value
                .enUso = "N"
                .estadoCaja = "C"
                .otrosEgresosMN = 0 ' nudImporteEgresosmn.Value
                .otrosEgresosME = 0 ' nudImporteEgresosme.Value
                .ingresoAdicMN = 0 ' nudIngresoMN.Value
                .ingresoAdicME = 0 'nudIngresoME.Value
                .idCajaCierre = 0 ' txtCajaDestino.ValueMember
            End With


            If Not txtOrigen.Tag = cboDepositoHijo.SelectedValue Then
                nDocumento = ComprobanteCaja()
                asiento = asientoCaja()
                ListaAsiento.Add(asiento)
                nDocumento.asiento = ListaAsiento
                nDocumento.CustomDocumentoCaja = ComprobanteCajaOrigen()
            Else
                nDocumento.CustomDocumentoCaja = Nothing
            End If
            cajaUsuarioSA.CerrarCajaUsuario(cajaUsuario, nDocumento)
            Dispose()
        Catch ex As Exception
            'lblEstado.Text = ex.Message
            'lblEstado.Image = My.Resources.warning2
        End Try
    End Sub

    Function ComprobanteCaja() As documento
        Dim nDocumentoCaja As New documento()
        Dim objCaja As New documentoCaja
        Dim objCajaDetalle As New documentoCajaDetalle

        nDocumentoCaja.idDocumento = 0
        nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
        nDocumentoCaja.idCentroCosto = GEstableciento.IdEstablecimiento   'GEstableciento.IdEstablecimiento
        If IsNothing(GProyectos) Then
        Else
            nDocumentoCaja.idProyecto = GProyectos.IdProyectoActividad
        End If

        nDocumentoCaja.tipoDoc = "9903"
        nDocumentoCaja.fechaProceso = txtFechaCierre.Value
        nDocumentoCaja.nroDoc = "EFECTIVO"
        nDocumentoCaja.idOrden = Nothing
        nDocumentoCaja.tipoOperacion = "9906"
        nDocumentoCaja.usuarioActualizacion = "Jiuni"
        nDocumentoCaja.fechaActualizacion = DateTime.Now

        objCaja.idEmpresa = Gempresas.IdEmpresaRuc
        objCaja.idEstablecimiento = GEstableciento.IdEstablecimiento
        objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
        objCaja.TipoDocumentoPago = "VOCJ"
        objCaja.codigoLibro = "9906" ' TIPO OPERACION
        objCaja.periodo = PeriodoGeneral
        objCaja.codigoProveedor = cajaUsuario.idPersona
        objCaja.fechaProceso = txtFechaCierre.Value
        objCaja.fechaCobro = txtFechaCierre.Value
        objCaja.tipoDocPago = "9903"
        objCaja.numeroDoc = 0 ' txtNumeroComp.Text
        objCaja.moneda = 1 'If(cboMoneda.Text = "NACIONAL", "1", "2")
        objCaja.entidadFinanciera = cboDepositoHijo.SelectedValue
        objCaja.numeroOperacion = "00001" 'txtNumeroComp.Text
        objCaja.tipoCambio = TmpTipoCambio
        objCaja.montoSoles = txtFondoAdepositar.DecimalValue
        objCaja.montoUsd = txtFondoAdepositarme.DecimalValue
        objCaja.glosa = "Por cierre de cajas"
        objCaja.entregado = "SI"
        objCaja.usuarioModificacion = usuario.IDUsuario
        objCaja.fechaModificacion = DateTime.Now
        nDocumentoCaja.documentoCaja = objCaja

        objCajaDetalle = New documentoCajaDetalle
        objCajaDetalle.fecha = txtFechaCierre.Value
        objCajaDetalle.idItem = "00"
        objCajaDetalle.DetalleItem = "POR CIERRE DE CAJA"
        objCajaDetalle.montoSoles = txtFondoAdepositar.DecimalValue
        objCajaDetalle.montoUsd = txtFondoAdepositarme.DecimalValue
        objCajaDetalle.entregado = "SI"
        '  ndocumentoCajaDetalle.DiferenciaTipoCambio = 0


        objCajaDetalle.documentoAfectado = 0
        objCajaDetalle.usuarioModificacion = usuario.IDUsuario
        objCajaDetalle.fechaModificacion = Date.Now
        nDocumentoCaja.documentoCaja.documentoCajaDetalle.Add(objCajaDetalle)

        Return nDocumentoCaja
    End Function

    Function ComprobanteCajaOrigen() As documento
        Dim nDocumentoCaja As New documento()
        Dim objCaja As New documentoCaja
        Dim objCajaDetalle As New documentoCajaDetalle

        nDocumentoCaja.idDocumento = 0
        nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
        nDocumentoCaja.idCentroCosto = GEstableciento.IdEstablecimiento   'GEstableciento.IdEstablecimiento
        If IsNothing(GProyectos) Then
        Else
            nDocumentoCaja.idProyecto = GProyectos.IdProyectoActividad
        End If

        nDocumentoCaja.tipoDoc = "9903"
        nDocumentoCaja.fechaProceso = txtFechaCierre.Value
        nDocumentoCaja.nroDoc = "EFECTIVO"
        nDocumentoCaja.idOrden = Nothing
        nDocumentoCaja.tipoOperacion = "9906"
        nDocumentoCaja.usuarioActualizacion = usuario.IDUsuario
        nDocumentoCaja.fechaActualizacion = DateTime.Now

        objCaja.idEmpresa = Gempresas.IdEmpresaRuc
        objCaja.idEstablecimiento = GEstableciento.IdEstablecimiento
        objCaja.tipoMovimiento = TIPO_COMPRA.PAGO.PAGADO
        objCaja.TipoDocumentoPago = "VOCJ"
        objCaja.codigoLibro = "9906" ' TIPO OPERACION
        objCaja.periodo = PeriodoGeneral
        objCaja.codigoProveedor = cajaUsuario.idPersona
        objCaja.fechaProceso = txtFechaCierre.Value
        objCaja.fechaCobro = txtFechaCierre.Value
        objCaja.tipoDocPago = "9903"
        objCaja.numeroDoc = 0 ' txtNumeroComp.Text
        objCaja.moneda = 1 'If(cboMoneda.Text = "NACIONAL", "1", "2")
        objCaja.entidadFinanciera = CInt(txtOrigen.Tag)
        objCaja.numeroOperacion = "00001" 'txtNumeroComp.Text
        objCaja.tipoCambio = TmpTipoCambio
        objCaja.montoSoles = saldoFinalMN
        objCaja.montoUsd = saldoFinalME
        objCaja.glosa = "Por cierre de cajas"
        objCaja.entregado = "SI"
        objCaja.usuarioModificacion = usuario.IDUsuario
        objCaja.fechaModificacion = DateTime.Now
        nDocumentoCaja.documentoCaja = objCaja

        objCajaDetalle = New documentoCajaDetalle
        objCajaDetalle.fecha = txtFechaCierre.Value
        objCajaDetalle.idItem = "00"
        objCajaDetalle.DetalleItem = "POR CIERRE DE CAJA"
        objCajaDetalle.montoSoles = saldoFinalMN
        objCajaDetalle.montoUsd = saldoFinalME
        'dgvDetalleItems.Rows(i).Cells(3).Value()
        ' dgvDetalleItems.Rows(i).Cells(4).Value()
        objCajaDetalle.entregado = "SI"
        '  ndocumentoCajaDetalle.DiferenciaTipoCambio = 0


        objCajaDetalle.documentoAfectado = 0
        objCajaDetalle.usuarioModificacion = usuario.IDUsuario
        objCajaDetalle.fechaModificacion = Date.Now
        nDocumentoCaja.documentoCaja.documentoCajaDetalle.Add(objCajaDetalle)

        Return nDocumentoCaja
    End Function
    Dim saldoFinalMN As Decimal = 0
    Dim saldoFinalME As Decimal = 0
    Sub TotalesXcolumna()
        Dim fondoMN As Decimal = 0
        Dim fondoME As Decimal = 0

        saldoFinalMN = 0
        saldoFinalME = 0

        ingresoMN = 0
        ingresoME = 0

        egresoMN = 0
        egresoME = 0
        For Each r As Record In gridGroupingControl1.Table.Records
            fondoMN += CDec(r.GetValue("aperturaMN"))
            fondoME += CDec(r.GetValue("aperturaME"))
            ingresoMN += CDec(r.GetValue("ingresoMN"))
            ingresoME += CDec(r.GetValue("ingresoME"))
            egresoMN += CDec(r.GetValue("salidaMN"))
            egresoME += CDec(r.GetValue("salidaME"))
            'End If
        Next r

        lblFondo.Text = fondoMN.ToString("N2")

        lblTotalIngreso.Text = ingresoMN.ToString("N2") + CDec(lblIngresoR.Text)
        lblTotalSalida.Text = egresoMN.ToString("N2") + CDec(lblSalidaR.Text)
        lblTotalSaldo.Text = CDec(CDec(fondoMN) + CDec(lblTotalIngreso.Text) - CDec(lblTotalSalida.Text)).ToString("N2")
        lblTotal.Text = CDec(lblTotalSaldo.Text).ToString("N2")

        If Not txtOrigen.Tag = cboDepositoHijo.SelectedValue Then
            txtFondoAdepositar.DecimalValue = CDec(lblTotalSaldo.Text)
            txtFondoAdepositarme.DecimalValue = CDec(CDec(cajaUsuario.fondoME) + ingresoME - egresoME)
        Else
            txtFondoAdepositar.DecimalValue = 0 ' ingresoMN - egresoMN
            txtFondoAdepositarme.DecimalValue = 0 ' ingresoME - egresoME
        End If
        saldoFinalMN = CDec(lblTotalSaldo.Text)
        saldoFinalME = CDec(CDec(cajaUsuario.fondoME) + ingresoME - egresoME)

    End Sub

    Sub GridCFG(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = System.Windows.Forms.BorderStyle.None

        '  GGC.BrowseOnly = True
        GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        GGC.TableOptions.ListBoxSelectionMode = SelectionMode.None
        GGC.TableOptions.SelectionBackColor = Color.FromArgb(85, 170, 255)
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        GGC.Table.DefaultColumnHeaderRowHeight = 45
        GGC.Table.DefaultRecordRowHeight = 40
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Sub GRID()

        Me.gridGroupingControl1.Appearance.ColumnHeaderCell.Interior = New BrushInfo(GradientStyle.Vertical, Color.Black, Color.Black)
        Me.gridGroupingControl1.TopLevelGroupOptions.ShowCaption = False
        Dim color__1 As New GridMetroColors()
        color__1.HeaderColor.NormalColor = Color.Black
        color__1.HeaderColor.HoverColor = Color.Empty
        color__1.HeaderTextColor.HoverTextColor = Color.White
        Me.gridGroupingControl1.SetMetroStyle(color__1)
        Me.gridGroupingControl1.AllowProportionalColumnSizing = True
        Me.gridGroupingControl1.DisplayVerticalLines = False
        Me.gridGroupingControl1.BrowseOnly = True
        Me.gridGroupingControl1.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        Me.gridGroupingControl1.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        Me.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
        Me.gridGroupingControl1.TableOptions.SelectionBackColor = Color.FromArgb(85, 170, 255)
        Me.gridGroupingControl1.TableOptions.ShowRowHeader = False
        Me.gridGroupingControl1.TableDescriptor.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(30, 30, 30))
        Dim captionImage1 As New Syncfusion.Windows.Forms.CaptionImage()
        Me.gridGroupingControl1.Table.DefaultRecordRowHeight = 30
        Me.gridGroupingControl1.Table.DefaultColumnHeaderRowHeight = 35
        Me.gridGroupingControl1.Appearance.AnyCell.TextColor = Color.White
        Me.gridGroupingControl1.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        Me.gridGroupingControl1.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        Me.gridGroupingControl1.TableDescriptor.Appearance.AnyCell.Borders.Bottom = New GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, Color.FromArgb(25, 25, 25))
        Me.gridGroupingControl1.TableDescriptor.Appearance.AnyCell.Borders.Right = New GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, Color.FromArgb(25, 25, 25))
        Me.gridGroupingControl1.TableDescriptor.Appearance.AnyHeaderCell.Borders.Top = New GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, Color.FromArgb(25, 25, 25))
        Me.gridGroupingControl1.GridOfficeScrollBars = OfficeScrollBars.Metro
        Me.gridGroupingControl1.TableControl.MetroColorTable.ScrollerBackground = Color.FromArgb(45, 45, 45)
        Me.gridGroupingControl1.TableControl.MetroColorTable.ArrowNormal = Color.FromArgb(195, 195, 195)
        Me.gridGroupingControl1.TableControl.MetroColorTable.ArrowChecked = Color.FromArgb(94, 171, 222)
        Me.gridGroupingControl1.TableControl.MetroColorTable.ThumbNormal = Color.FromArgb(31, 31, 31)
        Me.gridGroupingControl1.TableControl.MetroColorTable.ThumbPushed = Color.FromArgb(94, 171, 222)
        Me.gridGroupingControl1.TableControl.HScrollBehavior = Syncfusion.Windows.Forms.Grid.GridScrollbarMode.Disabled
    End Sub

    ''Dim cajaUsuario As New cajaUsuario
    Public Sub UbicarCajaPadre(iNtIdPadre As Integer)
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim personaSA As New Helios.Seguridad.WCFService.ServiceAccess.UsuarioSA
        Dim entidadSA As New EstadosFinancierosSA
        Dim entidad As New estadosFinancieros

        cajaUsuario = New cajaUsuario
        cajaUsuario = cajaUsuarioSA.UbicarCajaUsuarioPorID(iNtIdPadre)
        If cajaUsuario.estadoCaja = "C" Then
            ckCerrar.Enabled = False
        Else
            ckCerrar.Enabled = True
        End If


        txtFecHaApertura.Value = cajaUsuario.fechaRegistro
        With personaSA.UbicarUsuarioXid(New Usuario With {.IDUsuario = cajaUsuario.idPersona})
            txtPersona.Text = .Full_Name
            cajaUsuario.NombrePersona = .Full_Name
        End With

        txtDni.Text = cajaUsuario.idPersona
        '      lblTipoCambio.Text = .tipoCambio
        lblFondo.Text = cajaUsuario.fondoMN
        '      lblFondoME.Text = .fondoME
        entidad = entidadSA.GetUbicar_estadosFinancierosPorID(cajaUsuario.idCajaOrigen)
        txtOrigen.Text = entidad.descripcion
        txtOrigen.Tag = entidad.idestado
        cajaUsuario.NombreCajaOrigen = entidad.descripcion

        'entidad = entidadSA.GetUbicar_estadosFinancierosPorID(.idCajaDestino)
        'txtDestino.Text = entidad.descripcion
        'cajaUsuario.NombreCajaDestino = entidad.descripcion

    End Sub


    Public Sub UbicarCajasHijas(iNtIdPadre As Integer)
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim cajaUsuario As New cajaUsuario
        Dim cajaSA As New DocumentoCajaSA
        Dim caja As New documentoCaja
        Dim DT As New DataTable()
        Dim personaSA As New UsuarioSA
        Dim persona As New Usuario

        DT.Columns.Add("nomUser", GetType(String))
        DT.Columns.Add("idPersona", GetType(String))

        DT.Columns.Add("aperturaMN", GetType(Decimal))
        DT.Columns.Add("ingresoMN", GetType(Decimal))
        DT.Columns.Add("salidaMN", GetType(Decimal))
        DT.Columns.Add("saldoMN", GetType(Decimal))

        DT.Columns.Add("aperturaME", GetType(Decimal))
        DT.Columns.Add("ingresoME", GetType(Decimal))
        DT.Columns.Add("salidaME", GetType(Decimal))
        DT.Columns.Add("saldoME", GetType(Decimal))


        Dim dr1 As DataRow = DT.NewRow()

        cajaUsuario = cajaUsuarioSA.UbicarCajaUsuarioPorID(iNtIdPadre)

        caja = cajaSA.ResumenTransaccionesxUsuarioDEP(cajaUsuario.idPersona) 'cajaUsuario.idcajaUsuario

        dr1(0) = cajaUsuario.NombrePersona
        dr1(1) = cajaUsuario.idPersona

        dr1(2) = cajaUsuario.fondoMN
        dr1(3) = caja.MontoIngresosMN
        dr1(4) = caja.MontoEgresosMN
        lblIngresoR.Text = caja.MontoIngresosMN.ToString("N2")
        lblSalidaR.Text = caja.MontoEgresosMN.ToString("N2")
        dr1(5) = Math.Round(CDec(cajaUsuario.fondoMN) + CDec(caja.MontoIngresosMN) - CDec(caja.MontoEgresosMN), 2)

        dr1(6) = cajaUsuario.fondoME
        dr1(7) = caja.MontoIngresosME
        dr1(8) = caja.MontoEgresosME
        dr1(9) = Math.Round(CDec(cajaUsuario.fondoME) + CDec(caja.MontoIngresosME) - CDec(caja.MontoEgresosME), 2)
        DT.Rows.Add(dr1)

        For Each i In cajaUsuarioSA.UbicarCajasHijasXpadre(iNtIdPadre)
            Dim dr As DataRow = DT.NewRow()

            caja = cajaSA.ResumenTransaccionesxUsuarioDEP(i.idPersona)

            persona = personaSA.UbicarUsuarioXid(New Usuario With {.IDUsuario = i.idPersona})

            dr(0) = persona.Nombres & ", " & persona.ApellidoPaterno & " " & persona.ApellidoMaterno
            dr(1) = i.idPersona

            dr(2) = i.fondoMN
            dr(3) = caja.MontoIngresosMN

            dr(4) = caja.MontoEgresosMN

            dr(5) = Math.Round(CDec(i.fondoMN) + CDec(caja.MontoIngresosMN) - CDec(caja.MontoEgresosMN), 2)

            dr(6) = i.fondoME
            dr(7) = caja.MontoIngresosME
            dr(8) = caja.MontoEgresosME
            dr(9) = Math.Round(CDec(i.fondoME) + CDec(caja.MontoIngresosME) - CDec(caja.MontoEgresosME), 2)
            DT.Rows.Add(dr)
        Next

        gridGroupingControl1.DataSource = DT

        TotalesXcolumna()
    End Sub
#End Region

    Private Sub frmUsuariosDependientesView_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmUsuariosDependientesView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtFechaCierre.BorderStyle = BorderStyle.None
    End Sub
    Dim hoveredIndex As Integer = 0
    Dim selectionColl As New Hashtable()
    Private Sub gridGroupingControl1_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles gridGroupingControl1.QueryCellStyleInfo
      If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing AndAlso selectionColl.Count > 0 Then
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) Then
                e.Style.BackColor = Color.DeepSkyBlue
                e.Style.TextColor = Color.White
                e.Style.CurrencyEdit.PositiveColor = Color.White
            End If
        End If

        If Not IsNothing(e.TableCellIdentity.Column) Then
            'If e.TableCellIdentity.Column.Name = "tipoEx" Then
            '    If e.Style.CellValue.Equals("MR") Then
            If e.TableCellIdentity.RowIndex = 3 Then
                e.Style.BackColor = Color.FromArgb(255, 192, 192)
            End If

            'End If
            '    End If

        End If

    End Sub

    Private Sub IsMouseHover(row As Integer, col As Integer, isHover As Boolean)
        Dim id As GridTableCellStyleInfoIdentity = Me.gridGroupingControl1.TableControl.GetTableViewStyleInfo(row, col).TableCellIdentity
        If id.DisplayElement.IsRecord() Then
            Dim key As Integer = id.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) Then
                selectionColl(key) = isHover
            Else
                selectionColl.Add(key, isHover)
            End If
            Me.gridGroupingControl1.TableControl.RefreshRange(GridRangeInfo.Row(row))
        End If

    End Sub

    Private Sub gridGroupingControl1_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles gridGroupingControl1.TableControlCellMouseHoverEnter
        Me.gridGroupingControl1.TableControl.Selections.Clear()
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True)
    End Sub

    Private Sub gridGroupingControl1_TableControlCellMouseHoverLeave(sender As Object, e As GridTableControlCellMouseEventArgs) Handles gridGroupingControl1.TableControlCellMouseHoverLeave
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, False)
        Me.gridGroupingControl1.TableControl.Selections.Clear()
    End Sub

    Private Sub gridGroupingControl1_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles gridGroupingControl1.TableControlCellClick

    End Sub

    Private Sub ckCerrar_CheckStateChanged(sender As Object, e As EventArgs) Handles ckCerrar.CheckStateChanged
        If ckCerrar.Checked = True Then
            Label4.Visible = True
            'txtCajaRecepcion.Visible = True
            'txtCajaRecepcion.Clear()
            cboTipo.Visible = True
            cboDepositoHijo.Visible = True

            lblFecCierre.Visible = True
            txtFechaCierre.Visible = True

            btOperacion.Visible = True

            lblimporteCierre.Visible = True
            txtFondoAdepositar.Visible = True
            txtFondoAdepositarme.Visible = True
        Else
            Label4.Visible = False
            '  txtCajaRecepcion.Visible = False
            cboTipo.Visible = False

            cboDepositoHijo.Visible = False

            lblFecCierre.Visible = False
            txtFechaCierre.Visible = False
            btOperacion.Visible = False
            lblimporteCierre.Visible = False
            txtFondoAdepositar.Visible = False
            txtFondoAdepositarme.Visible = False
        End If
    End Sub
    Public Sub CargarCajasTipo(strBusqueda As String, tiping As String)
        Dim estadoSA As New EstadosFinancierosSA
        Try
            Me.lstEntidades.DataSource = estadoSA.ObtenerEstadosFinancierosPorTipo(GEstableciento.IdEstablecimiento, tiping, strBusqueda)
            Me.lstEntidades.DisplayMember = "descripcion"
            Me.lstEntidades.ValueMember = "idestado"
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtCajaRecepcion_KeyDown(sender As Object, e As KeyEventArgs)
        'Me.Cursor = Cursors.WaitCursor
        'If e.KeyCode = Keys.Enter Then
        '    e.SuppressKeyPress = True
        '    pcEntidad.Font = New Font("Segoe UI", 8)
        '    pcEntidad.Size = New Size(249, 147)
        '    Me.pcEntidad.ParentControl = Me.txtCajaRecepcion
        '    Me.pcEntidad.ShowPopup(Point.Empty)

        '    If cboTipo.Text = "CUENTAS EN EFECTIVO" Then
        '        CargarCajasTipo(txtCajaRecepcion.Text.Trim, "EF")
        '    ElseIf cboTipo.Text = "CUENTAS EN BANCO" Then
        '        CargarCajasTipo(txtCajaRecepcion.Text.Trim, "BC")
        '    End If
        'End If
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtCajaRecepcion_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub pcEntidad_BeforePopup(sender As Object, e As CancelEventArgs) Handles pcEntidad.BeforePopup
        Me.pcEntidad.BackColor = Color.White
    End Sub

    'Private Sub pcEntidad_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcEntidad.CloseUp
    '    Me.Cursor = Cursors.WaitCursor
    '    Dim entidadSA As New entidadSA
    '    Dim cajaSA As New EstadosFinancierosSA
    '    If e.PopupCloseType = PopupCloseType.Done Then
    '        If lstEntidades.SelectedItems.Count > 0 Then
    '            With cajaSA.GetUbicar_estadosFinancierosPorID(lstEntidades.SelectedValue)
    '                txtCajaRecepcion.Tag = lstEntidades.SelectedValue
    '                txtCajaRecepcion.Text = .descripcion
    '            End With
    '        End If
    '    End If
    '    ' Set focus back to textbox.
    '    If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
    '        Me.txtCajaRecepcion.Focus()
    '    End If
    '    Me.Cursor = Cursors.Arrow
    'End Sub

    Private Sub lstEntidades_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstEntidades.MouseDoubleClick
        If lstEntidades.SelectedItems.Count > 0 Then
            Me.pcEntidad.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub cboTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipo.SelectedIndexChanged
        If cboTipo.Text = "CUENTAS EN EFECTIVO" Then
            CargarCajasTipo("EF")
        ElseIf cboTipo.Text = "CUENTAS EN BANCO" Then
            CargarCajasTipo("BC")
        End If
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        CerrarCajaUsuario(record)
    End Sub

    Private Sub cboDepositoHijo_Click(sender As Object, e As EventArgs) Handles cboDepositoHijo.Click

    End Sub

    Private Sub cboDepositoHijo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDepositoHijo.SelectedIndexChanged
        If cboDepositoHijo.Visible Then
            TotalesXcolumna()
        End If

    End Sub
End Class