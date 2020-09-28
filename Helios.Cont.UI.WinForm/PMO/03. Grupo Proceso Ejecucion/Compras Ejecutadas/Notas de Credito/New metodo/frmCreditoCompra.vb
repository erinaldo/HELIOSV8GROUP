Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Tools

Public Class frmCreditoCompra
    Inherits frmMaster
    Public Property TotalesXcanbeceras As TotalesXcanbecera
    Public Property tipoCambio() As Decimal
    Public Property IdCompraOrigen() As Integer
    Public Property ListaAsientonTransito As New List(Of asiento)

    Public Sub New(intIdDocumento As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ConfiguracionInicio()
        GEtColumnsByDatatable()
        GridCFG_general(dgvMov)
        TotalTalesXcolumna()
        UbicarDetalleByItemDirecto(intIdDocumento)
        dgvMov.TableDescriptor.Columns("canDev").ReadOnly = True
        dgvMov.TableDescriptor.Columns("vcmn").ReadOnly = True
        dgvMov.TableDescriptor.Columns("bonificacion").Width = 40
        dgvMov.TableDescriptor.Columns("bonificacion").HeaderText = "Bonif."
        dgvMov.TableDescriptor.Columns("btSelec").HeaderText = ".."
    End Sub

#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean



        parpadear = Not parpadear
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If TiempoRestante > 0 Then
            parpadeo()

            'lblAgregar.Visible = True
            'lblMensaje.Visible = True
            'tsSave.Enabled = False
            'lblMensaje.Text = "Agregar otro en: " & TiempoRestante
            TiempoRestante = TiempoRestante - 1
        ElseIf TiempoRestante = 0 Then
            Timer1.Enabled = False
            'lblEstado.ForeColor = Color.Navy
            'lblEstado.BackColor = Color.Transparent
            PanelError.Visible = False
            '      Dispose()
        Else
            Timer1.Enabled = False
            'Ejecuta tu función cuando termina el tiempo
            TiempoEjecutar(10)

        End If
    End Sub
    Private TiempoRestante As Integer
    Public Sub TimerOn(ByRef Interval As Short)
        If Interval > 0 Then
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
        End If

    End Sub
    Public Function TiempoEjecutar(ByVal Tiempo As Integer)
        TiempoEjecutar = ""
        TiempoRestante = Tiempo  ' 1 minutos=60 segundos 
        Timer1.Interval = 400

        Call TimerOn(1000) ' Hechanos a andar el timer
    End Function
#End Region

#Region "Metodos"

    Public Function ASBOF(cMonto As Decimal, cMontoUS As Decimal) As asiento
        Dim nAsiento As New asiento
        nAsiento = New asiento
        nAsiento.periodo = lblPerido.Text
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = txtProveedor.Tag
        nAsiento.nombreEntidad = txtProveedor.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "8"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Compra_Existencia
        nAsiento.importeMN = cMonto
        nAsiento.importeME = cMontoUS
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now
        Return nAsiento
    End Function

    Public Sub AsientoBONIF(r As documentocompradetalle)
        Dim cuentaMascaraSA As New cuentaMascaraSA
        Dim asientoTransitod As New asiento
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Dim nMovimiento As New movimiento
        Dim almacenSA As New almacenSA

        asientoTransitod = ASBOF(CDec(r.montokardex), CDec(r.montokardexUS)) ' CABECERA ASIENTO

        Dim EsalmacenVirtual = almacenSA.GetEsAlmacenVirtual(r.almacenRef)

        'MOVIMIENTOS - 2 cuenta 28
        nMovimiento = New movimiento
        nMovimiento.cuenta = "7311"
        nMovimiento.descripcion = "Bonif. obtenidas, descuentos rebajas-terceros"
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        nMovimiento.monto = r.montokardex
        nMovimiento.montoUSD = r.montokardexUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        asientoTransitod.movimiento.Add(nMovimiento)

        'MOVIMIENTOS -1 cuenta 20
        nMovimiento = New movimiento
        If EsalmacenVirtual = True Then
            Select Case r.tipoExistencia
                Case "01"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "CDS", "BONIF01.1")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "03"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "CDS", "BONIF01.1")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "04"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "CDS", "BONIF01.1")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "05"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "CDS", "BONIF01.1")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            End Select
        Else
            Select Case r.tipoExistencia
                Case "01"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ALM", "BONIF01.1")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "03"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "03", "ALM", "BONIF03.1")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "04"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "04", "ALM", "BONIF04.1")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "05"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "05", "ALM", "BONIF05.1")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            End Select
        End If

        nMovimiento.descripcion = r.descripcionItem
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        nMovimiento.monto = r.montokardex
        nMovimiento.montoUSD = r.montokardexUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        asientoTransitod.movimiento.Add(nMovimiento)



        ListaAsientonTransito.Add(asientoTransitod)
    End Sub


    Private Sub ValidarItemsDuplicados(intIdItem As Integer)
        Dim colIdItem As Integer

        colIdItem = intIdItem

        For Each i In dgvMov.Table.Records
            If colIdItem = i.GetValue("idItem") Then
                Throw New Exception("El artículo " & i.GetValue("item") & ", ya se encuentra en la canasta. Ingrese otro")
            End If
        Next
    End Sub

    Sub GridCFG_general(grid As GridGroupingControl)
        grid.TableOptions.ShowRowHeader = False
        grid.TopLevelGroupOptions.ShowCaption = False

        Dim colorx As New GridMetroColors()
        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        grid.SetMetroStyle(colorx)
        grid.BorderStyle = System.Windows.Forms.BorderStyle.None

        'Me.gridGroupingControl1.BrowseOnly = true
        'Me.gridGroupingControl1.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
        grid.TableOptions.SelectionBackColor = Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        grid.AllowProportionalColumnSizing = False
        grid.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        grid.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        grid.Table.DefaultColumnHeaderRowHeight = 25
        grid.Table.DefaultRecordRowHeight = 20
        grid.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Sub GridCFG(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        Dim colorx As New GridMetroColors()

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = System.Windows.Forms.BorderStyle.None
        '  GGC.BrowseOnly = True
        GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GGC.TableOptions.SelectionBackColor = Color.Gray

        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center

        GGC.Table.DefaultColumnHeaderRowHeight = 25
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Sub AsientoNotaCreditoNormal(ListaExistencias As List(Of documentocompradetalle))
        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento


        Dim SumaCliente = Aggregate n In ListaExistencias _
           Into totalMN = Sum(n.importe),
           totalME = Sum(n.importeUS)

        If SumaCliente.totalMN.GetValueOrDefault > 0 Then
            nAsiento = New asiento
            nAsiento.periodo = lblPerido.Text
            nAsiento.idDocumento = 0
            nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
            nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
            nAsiento.idEntidad = txtProveedor.Tag
            nAsiento.nombreEntidad = txtProveedor.Text
            nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
            nAsiento.fechaProceso = txtFecha.Value
            nAsiento.codigoLibro = "8"
            nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
            nAsiento.tipoAsiento = ASIENTO_CONTABLE.Compra_NotaCredito
            nAsiento.glosa = txtGlosa.Text.Trim
            nAsiento.importeMN = SumaCliente.totalMN.GetValueOrDefault
            nAsiento.importeME = SumaCliente.totalME.GetValueOrDefault
            nAsiento.usuarioActualizacion = usuario.IDUsuario
            nAsiento.fechaActualizacion = DateTime.Now
            ListaAsientonTransito.Add(nAsiento)
        End If

        If SumaCliente.totalMN.GetValueOrDefault > 0 Then
            nAsiento.movimiento.Add(AS_Proveedor(SumaCliente.totalMN.GetValueOrDefault, SumaCliente.totalME.GetValueOrDefault))
        End If

        For Each i In ListaExistencias
            Select Case i.TipoOperacion
                Case "9913"

                Case "9925"
                    nMovimiento = New movimiento
                    nMovimiento.cuenta = "775"
                    nMovimiento.descripcion = "DESCUENTOS OBTENIDOS POR PRONTO PAGO"
                    nMovimiento.tipo = "H"
                    nMovimiento.monto = i.montokardex
                    nMovimiento.montoUSD = i.montokardexUS
                    nMovimiento.usuarioActualizacion = usuario.IDUsuario
                    nMovimiento.fechaActualizacion = DateTime.Now
                    nAsiento.movimiento.Add(nMovimiento)
                Case Else

                    If i.bonificacion = "SI" Then
                        '  nAsiento.movimiento.Add(AS_Default(Nothing, i.montokardex, i.montokardexUS, i.tipoExistencia, i.descripcionItem))
                        AsientoBONIF(i)
                    Else
                        nAsiento.movimiento.Add(AS_Default(Nothing, i.montokardex, i.montokardexUS, i.tipoExistencia, i.descripcionItem))
                        MV_Item_Transito(i.descripcionItem, i.montokardex, i.montokardexUS, i.tipoExistencia)
                    End If
            End Select

        Next

        Dim SumaIGV = Aggregate n In ListaExistencias _
                  Into IGVmn = Sum(n.montoIgv),
                  IGVme = Sum(n.montoIgvUS)

        If SumaIGV.IGVmn.GetValueOrDefault > 0 Then
            nAsiento.movimiento.Add(AS_IGV(SumaIGV.IGVmn.GetValueOrDefault, SumaIGV.IGVme.GetValueOrDefault))
        End If
    End Sub

    Sub AsientoNotaCreditoNormalServicio(ListaServicios As List(Of documentocompradetalle))

        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento

        Dim SumaCliente = Aggregate n In ListaServicios _
             Into totalMN = Sum(n.importe),
             totalME = Sum(n.importeUS)

        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.periodo = lblPerido.Text
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = txtProveedor.Tag
        nAsiento.nombreEntidad = txtProveedor.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "8"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Compra_NotaCredito
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.importeMN = SumaCliente.totalMN.GetValueOrDefault
        nAsiento.importeME = SumaCliente.totalME.GetValueOrDefault
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now
        ListaAsientonTransito.Add(nAsiento)

        nAsiento.movimiento.Add(AS_Proveedor(SumaCliente.totalMN.GetValueOrDefault, SumaCliente.totalME.GetValueOrDefault))
        For Each i In ListaServicios
            nAsiento.movimiento.Add(AS_Default(i.idItem, i.montokardex, i.montokardexUS, i.tipoExistencia, i.descripcionItem))
        Next

        Dim SumaIGV = Aggregate n In ListaServicios _
                     Into IGVmn = Sum(n.montoIgv),
                     IGVme = Sum(n.montoIgvUS)

        nAsiento.movimiento.Add(AS_IGV(SumaIGV.IGVmn.GetValueOrDefault, SumaIGV.IGVme.GetValueOrDefault))


    End Sub

    Sub AsientoNotaCreditoExcedenteServicios(ListaServicios As List(Of documentocompradetalle))
        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento

        Dim SumaCliente = Aggregate n In ListaServicios _
                     Into totalMN = Sum(n.importe),
                     totalME = Sum(n.importeUS)

        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.periodo = lblPerido.Text
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = txtProveedor.Tag
        nAsiento.nombreEntidad = txtProveedor.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "8"
        nAsiento.importeMN = SumaCliente.totalMN.GetValueOrDefault
        nAsiento.importeME = SumaCliente.totalME.GetValueOrDefault
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Compra_NotaCredito

        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now
        ListaAsientonTransito.Add(nAsiento)

        nAsiento.movimiento.Add(Ad_prov_Excedente(SumaCliente.totalMN.GetValueOrDefault, SumaCliente.totalME.GetValueOrDefault))
        For Each i In ListaServicios
            nAsiento.movimiento.Add(AS_Default(i.idItem, i.montokardex, i.montokardexUS, i.tipoExistencia, i.descripcionItem))
        Next
        Dim SumaIGV = Aggregate n In ListaServicios _
               Into IGVmn = Sum(n.montoIgv),
               IGVme = Sum(n.montoIgvUS)

        nAsiento.movimiento.Add(AS_IGV(SumaIGV.IGVmn.GetValueOrDefault, SumaIGV.IGVme.GetValueOrDefault))

    End Sub

    Sub AsientoNotaCreditoExcedenteServiciosMasPago(ListaServicios As List(Of documentocompradetalle))
        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento

        Dim SumaCliente = Aggregate n In ListaServicios _
                     Into totalMN = Sum(n.importe),
                     totalME = Sum(n.importeUS)

        nAsiento = New asiento
        nAsiento.periodo = lblPerido.Text
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = txtProveedor.Tag
        nAsiento.nombreEntidad = txtProveedor.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "8"
        nAsiento.importeMN = SumaCliente.totalMN.GetValueOrDefault
        nAsiento.importeME = SumaCliente.totalME.GetValueOrDefault
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Compra_NotaCredito

        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now
        ListaAsientonTransito.Add(nAsiento)

        nAsiento.movimiento.Add(Ad_prov_Excedente(SumaCliente.totalMN.GetValueOrDefault, SumaCliente.totalME.GetValueOrDefault))
        nAsiento.movimiento.Add(AS_Proveedor(TotalesXcanbeceras.SaldoVentaMN, TotalesXcanbeceras.SaldoVentaME))
        For Each i In ListaServicios
            nAsiento.movimiento.Add(AS_Default(i.idItem, i.montokardex, i.montokardexUS, i.tipoExistencia, i.descripcionItem))
        Next
        Dim SumaIGV = Aggregate n In ListaServicios _
               Into IGVmn = Sum(n.montoIgv),
               IGVme = Sum(n.montoIgvUS)

        nAsiento.movimiento.Add(AS_IGV(SumaIGV.IGVmn.GetValueOrDefault, SumaIGV.IGVme.GetValueOrDefault))

    End Sub

    Sub AsientoNotaCreditoExcedenteServiciosMasPagoPendiente(ListaServicios As List(Of documentocompradetalle))
        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento

        Dim SumaCliente = Aggregate n In ListaServicios
                     Into totalMN = Sum(n.importe),
                     totalME = Sum(n.importeUS),
                  devo = Sum(n.ImporteDevolucionmn),
                  devme = Sum(n.ImporteDevolucionme)

        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.periodo = lblPerido.Text
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = txtProveedor.Tag
        nAsiento.nombreEntidad = txtProveedor.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "8"
        nAsiento.importeMN = SumaCliente.totalMN.GetValueOrDefault
        nAsiento.importeME = SumaCliente.totalME.GetValueOrDefault
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Compra_NotaCredito

        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now
        ListaAsientonTransito.Add(nAsiento)

        ' nAsiento.movimiento.Add(Ad_prov_Excedente(TotalesXcanbeceras.importeDevmn, TotalesXcanbeceras.importeDevme))
        nAsiento.movimiento.Add(Ad_prov_Excedente(SumaCliente.devo.GetValueOrDefault, SumaCliente.devme.GetValueOrDefault))
        'nAsiento.movimiento.Add(AS_Proveedor(TotalesXcanbeceras.SaldoVentaMN, TotalesXcanbeceras.SaldoVentaME))
        nAsiento.movimiento.Add(AS_Proveedor(SumaCliente.totalMN.GetValueOrDefault - SumaCliente.devo.GetValueOrDefault, SumaCliente.totalME.GetValueOrDefault - SumaCliente.devme.GetValueOrDefault))
        For Each i In ListaServicios
            Select Case i.TipoOperacion
                Case "9925"
                    nAsiento.movimiento.Add(AS_Default75(i.idItem, i.montokardex, i.montokardexUS, i.tipoExistencia, i.descripcionItem))
                Case Else
                    nAsiento.movimiento.Add(AS_Default(i.idItem, i.montokardex, i.montokardexUS, i.tipoExistencia, i.descripcionItem))
            End Select

        Next
        Dim SumaIGV = Aggregate n In ListaServicios
               Into IGVmn = Sum(n.montoIgv),
               IGVme = Sum(n.montoIgvUS)

        nAsiento.movimiento.Add(AS_IGV(SumaIGV.IGVmn.GetValueOrDefault, SumaIGV.IGVme.GetValueOrDefault))

    End Sub

    'Sub AsientoNotaCreditoExcedenteServiciosMasPagoPendiente(ListaServicios As List(Of documentocompradetalle))
    '    Dim nMovimiento As New movimiento
    '    Dim nAsiento As New asiento

    '    Dim SumaCliente = Aggregate n In ListaServicios _
    '                 Into totalMN = Sum(n.importe),
    '                 totalME = Sum(n.importeUS)

    '    nAsiento = New asiento
    '    nAsiento.idDocumento = 0
    '    nAsiento.periodo = lblPerido.Text
    '    nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
    '    nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
    '    nAsiento.idEntidad = txtProveedor.Tag
    '    nAsiento.nombreEntidad = txtProveedor.Text
    '    nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
    '    nAsiento.fechaProceso = txtFecha.Value
    '    nAsiento.codigoLibro = "8"
    '    nAsiento.importeMN = SumaCliente.totalMN.GetValueOrDefault
    '    nAsiento.importeME = SumaCliente.totalME.GetValueOrDefault
    '    nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
    '    nAsiento.tipoAsiento = ASIENTO_CONTABLE.Compra_NotaCredito

    '    nAsiento.glosa = txtGlosa.Text.Trim
    '    nAsiento.usuarioActualizacion = usuario.IDUsuario
    '    nAsiento.fechaActualizacion = DateTime.Now
    '    ListaAsientonTransito.Add(nAsiento)

    '    nAsiento.movimiento.Add(Ad_prov_Excedente(TotalesXcanbeceras.importeDevmn, TotalesXcanbeceras.importeDevme))
    '    nAsiento.movimiento.Add(AS_Proveedor(TotalesXcanbeceras.SaldoVentaMN, TotalesXcanbeceras.SaldoVentaME))
    '    For Each i In ListaServicios
    '        Select Case i.TipoOperacion
    '            Case "9925"
    '                nAsiento.movimiento.Add(AS_Default75(i.idItem, i.montokardex, i.montokardexUS, i.tipoExistencia, i.descripcionItem))
    '            Case Else
    '                nAsiento.movimiento.Add(AS_Default(i.idItem, i.montokardex, i.montokardexUS, i.tipoExistencia, i.descripcionItem))
    '        End Select

    '    Next
    '    Dim SumaIGV = Aggregate n In ListaServicios _
    '           Into IGVmn = Sum(n.montoIgv),
    '           IGVme = Sum(n.montoIgvUS)

    '    nAsiento.movimiento.Add(AS_IGV(SumaIGV.IGVmn.GetValueOrDefault, SumaIGV.IGVme.GetValueOrDefault))

    'End Sub

    Sub AsientoNotaCreditoExcedente(ListaExistencias As List(Of documentocompradetalle))
        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento

        Dim SumaCliente = Aggregate n In ListaExistencias _
                  Into totalMN = Sum(n.importe),
                  totalME = Sum(n.importeUS)

        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.periodo = lblPerido.Text
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = txtProveedor.Tag
        nAsiento.nombreEntidad = txtProveedor.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "8"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Compra_NotaCredito
        nAsiento.importeMN = SumaCliente.totalMN.GetValueOrDefault
        nAsiento.importeME = SumaCliente.totalME.GetValueOrDefault
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now
        ListaAsientonTransito.Add(nAsiento)
        '------------------------------------------

        nAsiento.movimiento.Add(Ad_prov_Excedente(SumaCliente.totalMN.GetValueOrDefault, SumaCliente.totalME.GetValueOrDefault))
        For Each i In ListaExistencias
            Select Case i.TipoOperacion
                Case "9913"

                Case "9925"
                    nMovimiento = New movimiento
                    nMovimiento.cuenta = "775"
                    nMovimiento.descripcion = "DESCUENTOS OBTENIDOS POR PRONTO PAGO"
                    nMovimiento.tipo = "H"
                    nMovimiento.monto = i.montokardex
                    nMovimiento.montoUSD = i.montokardexUS
                    nMovimiento.usuarioActualizacion = usuario.IDUsuario
                    nMovimiento.fechaActualizacion = DateTime.Now
                    nAsiento.movimiento.Add(nMovimiento)
                Case Else
                    If i.bonificacion = "SI" Then
                        AsientoBONIF(i)
                        '   nAsiento.movimiento.Add(AS_Default(Nothing, i.montokardex, i.montokardexUS, i.tipoExistencia, i.descripcionItem))
                    Else
                        MV_Item_Transito(i.descripcionItem, i.montokardex, i.montokardexUS, i.tipoExistencia)
                        nAsiento.movimiento.Add(AS_Default(Nothing, i.montokardex, i.montokardexUS, i.tipoExistencia, i.descripcionItem))
                    End If

            End Select

        Next
        Dim SumaIGV = Aggregate n In ListaExistencias _
           Into IGVmn = Sum(n.montoIgv),
           IGVme = Sum(n.montoIgvUS)

        nAsiento.movimiento.Add(AS_IGV(SumaIGV.IGVmn.GetValueOrDefault, SumaIGV.IGVme.GetValueOrDefault))
    End Sub

    Sub AsientoNotaCreditoExcedenteMaspagoDeuda(ListaExistencias As List(Of documentocompradetalle))
        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento

        Dim SumaCliente = Aggregate n In ListaExistencias _
                  Into totalMN = Sum(n.importe),
                  totalME = Sum(n.importeUS)

        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.periodo = lblPerido.Text
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = txtProveedor.Tag
        nAsiento.nombreEntidad = txtProveedor.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "8"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Compra_NotaCredito
        nAsiento.importeMN = SumaCliente.totalMN.GetValueOrDefault
        nAsiento.importeME = SumaCliente.totalME.GetValueOrDefault
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now
        ListaAsientonTransito.Add(nAsiento)
        '------------------------------------------

        nAsiento.movimiento.Add(Ad_prov_Excedente(SumaCliente.totalMN.GetValueOrDefault, SumaCliente.totalME.GetValueOrDefault))
        nAsiento.movimiento.Add(AS_Proveedor(TotalesXcanbeceras.SaldoVentaMN, TotalesXcanbeceras.SaldoVentaME))
        For Each i In ListaExistencias
            Select Case i.TipoOperacion
                Case "9913"

                Case "9925"
                    nAsiento.movimiento.Add(AS_Default(Nothing, i.montokardex, i.montokardexUS, i.tipoExistencia, i.descripcionItem))
                Case Else
                    If i.bonificacion = "SI" Then
                        AsientoBONIF(i)
                        '    nAsiento.movimiento.Add(AS_Default(Nothing, i.montokardex, i.montokardexUS, i.tipoExistencia, i.descripcionItem))
                    Else
                        MV_Item_Transito(i.descripcionItem, i.montokardex, i.montokardexUS, i.tipoExistencia)
                        nAsiento.movimiento.Add(AS_Default(Nothing, i.montokardex, i.montokardexUS, i.tipoExistencia, i.descripcionItem))
                    End If
            End Select
        Next
        Dim SumaIGV = Aggregate n In ListaExistencias _
           Into IGVmn = Sum(n.montoIgv),
           IGVme = Sum(n.montoIgvUS)

        nAsiento.movimiento.Add(AS_IGV(SumaIGV.IGVmn.GetValueOrDefault, SumaIGV.IGVme.GetValueOrDefault))


    End Sub

    Sub AsientoNotaCreditoExcedenteMaspagoDeudaPendiente(ListaExistencias As List(Of documentocompradetalle))
        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento

        Dim SumaCliente = Aggregate n In ListaExistencias
                  Into totalMN = Sum(n.importe),
                  totalME = Sum(n.importeUS),
                  devo = Sum(n.ImporteDevolucionmn),
                  devme = Sum(n.ImporteDevolucionme)



        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.periodo = lblPerido.Text
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = txtProveedor.Tag
        nAsiento.nombreEntidad = txtProveedor.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "8"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Compra_NotaCredito
        nAsiento.importeMN = SumaCliente.totalMN.GetValueOrDefault
        nAsiento.importeME = SumaCliente.totalME.GetValueOrDefault
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now
        ListaAsientonTransito.Add(nAsiento)
        '------------------------------------------

        nAsiento.movimiento.Add(Ad_prov_Excedente(SumaCliente.devo.GetValueOrDefault, SumaCliente.devme.GetValueOrDefault))
        'nAsiento.movimiento.Add(AS_Proveedor(TotalesXcanbeceras.SaldoVentaMN, TotalesXcanbeceras.SaldoVentaME))
        nAsiento.movimiento.Add(AS_Proveedor(SumaCliente.totalMN.GetValueOrDefault - SumaCliente.devo.GetValueOrDefault, SumaCliente.totalME.GetValueOrDefault - SumaCliente.devme.GetValueOrDefault))
        For Each i In ListaExistencias
            Select Case i.TipoOperacion
                Case "9913"

                Case "9925"
                    nAsiento.movimiento.Add(AS_Default75(Nothing, i.montokardex, i.montokardexUS, i.tipoExistencia, i.descripcionItem))
                Case Else
                    If i.bonificacion = "SI" Then
                        AsientoBONIF(i)
                        '       nAsiento.movimiento.Add(AS_Default(Nothing, i.montokardex, i.montokardexUS, i.tipoExistencia, i.descripcionItem))
                    Else
                        MV_Item_Transito(i.descripcionItem, i.montokardex, i.montokardexUS, i.tipoExistencia)
                        nAsiento.movimiento.Add(AS_Default(Nothing, i.montokardex, i.montokardexUS, i.tipoExistencia, i.descripcionItem))
                    End If

            End Select

        Next
        Dim SumaIGV = Aggregate n In ListaExistencias
           Into IGVmn = Sum(n.montoIgv),
           IGVme = Sum(n.montoIgvUS)

        nAsiento.movimiento.Add(AS_IGV(SumaIGV.IGVmn.GetValueOrDefault, SumaIGV.IGVme.GetValueOrDefault))


    End Sub

    'Sub AsientoNotaCreditoExcedenteMaspagoDeudaPendiente(ListaExistencias As List(Of documentocompradetalle))
    '    Dim nMovimiento As New movimiento
    '    Dim nAsiento As New asiento

    '    Dim SumaCliente = Aggregate n In ListaExistencias _
    '              Into totalMN = Sum(n.importe),
    '              totalME = Sum(n.importeUS)

    '    nAsiento = New asiento
    '    nAsiento.idDocumento = 0
    '    nAsiento.periodo = lblPerido.Text
    '    nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
    '    nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
    '    nAsiento.idEntidad = txtProveedor.Tag
    '    nAsiento.nombreEntidad = txtProveedor.Text
    '    nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
    '    nAsiento.fechaProceso = txtFecha.Value
    '    nAsiento.codigoLibro = "8"
    '    nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
    '    nAsiento.tipoAsiento = ASIENTO_CONTABLE.Compra_NotaCredito
    '    nAsiento.importeMN = SumaCliente.totalMN.GetValueOrDefault
    '    nAsiento.importeME = SumaCliente.totalME.GetValueOrDefault
    '    nAsiento.glosa = txtGlosa.Text.Trim
    '    nAsiento.usuarioActualizacion = usuario.IDUsuario
    '    nAsiento.fechaActualizacion = DateTime.Now
    '    ListaAsientonTransito.Add(nAsiento)
    '    '------------------------------------------

    '    nAsiento.movimiento.Add(Ad_prov_Excedente(TotalesXcanbeceras.importeDevmn, TotalesXcanbeceras.importeDevme))
    '    nAsiento.movimiento.Add(AS_Proveedor(TotalesXcanbeceras.SaldoVentaMN, TotalesXcanbeceras.SaldoVentaME))
    '    For Each i In ListaExistencias
    '        Select Case i.TipoOperacion
    '            Case "9913"

    '            Case "9925"
    '                nAsiento.movimiento.Add(AS_Default75(Nothing, i.montokardex, i.montokardexUS, i.tipoExistencia, i.descripcionItem))
    '            Case Else
    '                If i.bonificacion = "SI" Then
    '                    AsientoBONIF(i)
    '                    '       nAsiento.movimiento.Add(AS_Default(Nothing, i.montokardex, i.montokardexUS, i.tipoExistencia, i.descripcionItem))
    '                Else
    '                    MV_Item_Transito(i.descripcionItem, i.montokardex, i.montokardexUS, i.tipoExistencia)
    '                    nAsiento.movimiento.Add(AS_Default(Nothing, i.montokardex, i.montokardexUS, i.tipoExistencia, i.descripcionItem))
    '                End If

    '        End Select

    '    Next
    '    Dim SumaIGV = Aggregate n In ListaExistencias _
    '       Into IGVmn = Sum(n.montoIgv),
    '       IGVme = Sum(n.montoIgvUS)

    '    nAsiento.movimiento.Add(AS_IGV(SumaIGV.IGVmn.GetValueOrDefault, SumaIGV.IGVme.GetValueOrDefault))


    'End Sub

    Public Function Ad_prov_Excedente(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento
        'nMovimiento.cuenta = "16"
        nMovimiento.cuenta = "1629"
        nMovimiento.descripcion = txtProveedor.Text
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = usuario.IDUsuario

        Return nMovimiento
    End Function

    Public Function AS_IGV(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = "40111",
              .descripcion = "I.G.V.",
              .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = usuario.IDUsuario}

        Return nMovimiento
    End Function

    Public Function AS_Proveedor(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento
        'If CDec(TotalesXcanbeceras.importeDevmn) > 0 Then
        '    nMovimiento.cuenta = "16"
        'Else
        Select Case txtTipoDoc.Tag
            Case TIPO_COMPRA.COMPRA_SERVICIO_PUBLICO, TIPO_COMPRA.COMPRA_ANTICIPADA_OTORGADO, TIPO_COMPRA.COMPRA_ANTICIPADA_RECIBIDA
                nMovimiento.cuenta = "4212"
            Case TIPO_COMPRA.COMPRA
                nMovimiento.cuenta = "4212"

            Case TIPO_COMPRA.COMPRA_RECIBO_HONORARIOS
                nMovimiento.cuenta = "424"

                'Case TIPO_COMPRA.COMPRA_ANTICIPADA
                '    nMovimiento.cuenta = "422"
                'Case "RECIBOS POR SERVICIOS PUBLICOS"
                '    nMovimiento.cuenta = "424"
                'Case Else
                '    nMovimiento.cuenta = "4212"
        End Select


        '  End If
        nMovimiento.descripcion = txtProveedor.Text
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = usuario.IDUsuario

        Return nMovimiento
    End Function

    Sub AsientoNotaCredito(consultaAsiento As List(Of documentocompradetalle))
        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento

        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.periodo = lblPerido.Text
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = txtProveedor.Tag
        nAsiento.nombreEntidad = txtProveedor.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "8"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Compra_NotaCredito
        nAsiento.importeMN = TotalesXcanbeceras.TotalMN
        nAsiento.importeME = TotalesXcanbeceras.TotalMN
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now
        ListaAsientonTransito.Add(nAsiento)

        nAsiento.movimiento.Add(AS_Proveedor(TotalesXcanbeceras.TotalMN, TotalesXcanbeceras.TotalME))
        nAsiento.movimiento.Add(AS_IGV(TotalesXcanbeceras.IgvMN, TotalesXcanbeceras.IgvME))
        For Each i In consultaAsiento
            Select Case i.destino
                Case "1"
                    MV_Item_Transito(i.descripcionItem, i.montokardex, i.montokardexUS, i.tipoExistencia)
                Case Else
                    MV_Item_Transito(i.descripcionItem, i.importe, i.importe, i.tipoExistencia)

            End Select
            nAsiento.movimiento.Add(AS_Default(Nothing, i.montokardex, i.montokardexUS, i.tipoExistencia, i.descripcionItem))
        Next
    End Sub
    Public Function AS_Default(strCuenta As String, cMonto As Decimal, cMontoUS As Decimal, tipoex As String, DescItem As String) As movimiento
        Dim nMovimiento As New movimiento
        Dim cuentaMascaraSA As New cuentaMascaraSA
        nMovimiento = New movimiento

        If tipoex = "GS" Then
            nMovimiento.cuenta = strCuenta
        Else
            cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, tipoex, "ITEM", "COMPRA")
            Select Case cuentaMascara.parametro
                Case "01"
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "03"
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "04"
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "05"
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            End Select
        End If
        nMovimiento.descripcion = DescItem
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = usuario.IDUsuario

        Return nMovimiento
    End Function

    Public Function AS_Default75(strCuenta As String, cMonto As Decimal, cMontoUS As Decimal, tipoex As String, DescItem As String) As movimiento
        Dim nMovimiento As New movimiento
        Dim cuentaMascaraSA As New cuentaMascaraSA
        nMovimiento = New movimiento

        nMovimiento.cuenta = "775"
        nMovimiento.descripcion = "DESCUENTOS OBTENIDOS POR PRONTO PAGO"
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = usuario.IDUsuario

        Return nMovimiento
    End Function

    Public Function AsientoTransito(cMonto As Decimal, cMontoUS As Decimal) As asiento
        Dim nAsiento As New asiento
        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.periodo = lblPerido.Text
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = CInt(txtProveedor.Tag)
        nAsiento.nombreEntidad = txtProveedor.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "8"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Compra_NotaCredito
        nAsiento.importeMN = cMonto
        nAsiento.importeME = cMontoUS
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now
        Return nAsiento
    End Function
    Dim cuentaMascara As New cuentaMascara
    Public Sub MV_Item_Transito(cproducto As String, cMonto As Decimal, cMontoUS As Decimal, strTipoExistencia As String)
        Dim asientoTransitod As New asiento
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Dim nMovimiento As New movimiento
        Dim cuentaMascaraSA As New cuentaMascaraSA

        asientoTransitod = AsientoTransito(cMonto, cMontoUS) ' CABECERA ASIENTO

        'MOVIMIENTOS -1 cuenta 20
        nMovimiento = New movimiento

        Select Case strTipoExistencia
            Case "01"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, strTipoExistencia, "ITEM", "EXT01.2")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "03"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, strTipoExistencia, "ITEM", "EXT03.2")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "04"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, strTipoExistencia, "ITEM", "EXT04.2")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "05"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, strTipoExistencia, "ITEM", "EXT05.2")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
        End Select


        nMovimiento.descripcion = cproducto
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        asientoTransitod.movimiento.Add(nMovimiento)

        'MOVIMIENTOS - 2 cuenta 28
        nMovimiento = New movimiento
        Select Case strTipoExistencia
            Case "01"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, strTipoExistencia, "ITEM", "TRANS01.1")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "03"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, strTipoExistencia, "ITEM", "TRANS03.1")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "04"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, strTipoExistencia, "ITEM", "TRANS04.1")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "05"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, strTipoExistencia, "ITEM", "TRANS05.1")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
        End Select

        nMovimiento.descripcion = cproducto
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        asientoTransitod.movimiento.Add(nMovimiento)

        ListaAsientonTransito.Add(asientoTransitod)
    End Sub

    Function ComprobanteCaja(listaCaja As List(Of documentocompradetalle)) As documento
        Dim efSA As New EstadosFinancierosSA
        Dim ef As New estadosFinancieros
        Dim nDocumentoCaja As New documento()
        Dim objCaja As New documentoCaja
        Dim objCajaDetalle As New documentoCajaDetalle
        Dim ListaDetalle As New List(Of documentoCajaDetalle)
        Dim asiento As New asiento
        Dim nMovimiento As New movimiento
        Dim sumMN As Decimal = 0
        Dim sumME As Decimal = 0

        ef = efSA.GetUbicar_estadosFinancierosPorID(Nothing)
        nDocumentoCaja = New documento()
        nDocumentoCaja.idDocumento = 0
        nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
        nDocumentoCaja.idCentroCosto = ef.idEstablecimiento  'GEstableciento.IdEstablecimiento
        If IsNothing(GProyectos) Then
        Else
            nDocumentoCaja.idProyecto = GProyectos.IdProyectoActividad
        End If
        nDocumentoCaja.tipoDoc = "109"
        nDocumentoCaja.fechaProceso = txtFecha.Value
        nDocumentoCaja.nroDoc = Nothing ' IIf(rbEfectivo.Checked = True, Nothing, txtNumCaja.Text.Trim)
        nDocumentoCaja.idOrden = Nothing
        nDocumentoCaja.tipoOperacion = "9922" ' INGRESO DE DINERO A CAJA
        nDocumentoCaja.usuarioActualizacion = usuario.IDUsuario
        nDocumentoCaja.fechaActualizacion = DateTime.Now

        objCaja = New documentoCaja
        objCaja.idDocumento = 0
        objCaja.idEmpresa = Gempresas.IdEmpresaRuc
        objCaja.idEstablecimiento = ef.idEstablecimiento
        objCaja.fechaProceso = txtFecha.Value
        objCaja.fechaCobro = txtFecha.Value
        objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
        objCaja.IdProveedor = txtProveedor.Tag
        objCaja.codigoLibro = "9922"
        objCaja.codigoProveedor = CInt(txtProveedor.Tag)
        objCaja.TipoDocumentoPago = "109"
        objCaja.tipoDocPago = "109"
        objCaja.periodo = lblPerido.Text
        objCaja.NumeroDocumento = Nothing ' IIf(txtNumCaja.Text.Trim.Length > 0, txtNumCaja.Text, Nothing)
        objCaja.moneda = "1" ' txtCodMoneda.Text ' IIf(cboMoneda.Text = "MONEDA NACIONAL (SOLES)", "SOL", "USD")
        objCaja.tipoCambio = CDec(txtTipoCambio.Text)
        objCaja.glosa = txtGlosa.Text.Trim
        objCaja.entregado = "SI"
        objCaja.entidadFinanciera = ef.idestado
        objCaja.usuarioModificacion = usuario.IDUsuario
        objCaja.fechaModificacion = DateTime.Now
        nDocumentoCaja.documentoCaja = objCaja

        For Each i In listaCaja

            sumMN += CDec(i.importe)
            sumME += CDec(i.importeUS)

            objCajaDetalle = New documentoCajaDetalle
            objCajaDetalle.idDocumento = 0
            objCajaDetalle.documentoAfectadodetalle = i.idPadreDTCompra
            objCajaDetalle.fecha = txtFecha.Value
            objCajaDetalle.idItem = i.idItem
            objCajaDetalle.DetalleItem = i.descripcionItem
            objCajaDetalle.montoSoles = i.ImporteDevolucionmn
            objCajaDetalle.montoUsd = i.ImporteDevolucionme
            objCajaDetalle.entregado = "SI"
            objCajaDetalle.documentoAfectado = 0 ' lblIdDoc.Text
            objCajaDetalle.usuarioModificacion = usuario.IDUsuario
            objCajaDetalle.fechaModificacion = DateTime.Now
            ListaDetalle.Add(objCajaDetalle)
        Next

        nDocumentoCaja.documentoCaja.montoSoles = sumMN
        nDocumentoCaja.documentoCaja.montoUsd = sumME
        nDocumentoCaja.documentoCaja.documentoCajaDetalle = ListaDetalle


        'ASIENTO CONTABLE

        asiento = New asiento
        With asiento
            .periodo = lblPerido.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCostos = GEstableciento.IdEstablecimiento
            .idEntidad = txtProveedor.Tag
            .nombreEntidad = txtProveedor.Text
            .tipoEntidad = "PR"
            .fechaProceso = txtFecha.Value
            .codigoLibro = "8"
            .tipo = "D"
            .tipoAsiento = "AS-NTC"
            .importeMN = sumMN
            .importeME = sumME
            .glosa = txtGlosa.Text.Trim
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With

        nMovimiento = New movimiento
        nMovimiento.cuenta = ef.cuenta
        nMovimiento.descripcion = ef.descripcion
        nMovimiento.tipo = "D"
        nMovimiento.monto = sumMN
        nMovimiento.montoUSD = sumME
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = DateTime.Now
        asiento.movimiento.Add(nMovimiento)


        nMovimiento = New movimiento
        nMovimiento.cuenta = "16"
        nMovimiento.descripcion = ef.descripcion
        nMovimiento.tipo = "H"
        nMovimiento.monto = sumMN
        nMovimiento.montoUSD = sumME
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = DateTime.Now
        asiento.movimiento.Add(nMovimiento)

        ListaAsientonTransito.Add(asiento)

        Return nDocumentoCaja
    End Function

    Function ComprobanteCajaSaldo(listaCaja As List(Of documentocompradetalle)) As documento
        Dim efSA As New EstadosFinancierosSA
        Dim ef As New estadosFinancieros
        Dim nDocumentoCaja As New documento()
        Dim objCaja As New documentoCaja
        Dim objCajaDetalle As New documentoCajaDetalle
        Dim ListaDetalle As New List(Of documentoCajaDetalle)
        Dim asiento As New asiento
        Dim nMovimiento As New movimiento

        Dim sumMN As Decimal = 0
        Dim sumME As Decimal = 0


        ef = efSA.GetUbicar_estadosFinancierosPorID(Nothing)
        nDocumentoCaja = New documento()
        nDocumentoCaja.idDocumento = 0
        nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
        nDocumentoCaja.idCentroCosto = ef.idEstablecimiento  'GEstableciento.IdEstablecimiento
        If IsNothing(GProyectos) Then
        Else
            nDocumentoCaja.idProyecto = GProyectos.IdProyectoActividad
        End If
        nDocumentoCaja.tipoDoc = "109"
        nDocumentoCaja.fechaProceso = txtFecha.Value
        nDocumentoCaja.nroDoc = Nothing ' IIf(rbEfectivo.Checked = True, Nothing, txtNumCaja.Text.Trim)
        nDocumentoCaja.idOrden = Nothing
        nDocumentoCaja.tipoOperacion = "9907" 'PAGO A PROVEEDORES
        nDocumentoCaja.usuarioActualizacion = usuario.IDUsuario
        nDocumentoCaja.fechaActualizacion = DateTime.Now

        objCaja = New documentoCaja
        objCaja.idDocumento = 0
        objCaja.idEmpresa = Gempresas.IdEmpresaRuc
        objCaja.idEstablecimiento = ef.idEstablecimiento
        objCaja.fechaProceso = txtFecha.Value
        objCaja.fechaCobro = txtFecha.Value
        objCaja.tipoMovimiento = TIPO_COMPRA.PAGO.PAGADO
        objCaja.IdProveedor = txtProveedor.Tag
        objCaja.codigoLibro = "9907"
        objCaja.codigoProveedor = CInt(txtProveedor.Tag)
        objCaja.TipoDocumentoPago = "109"
        objCaja.tipoDocPago = "109"
        objCaja.periodo = lblPerido.Text
        objCaja.NumeroDocumento = Nothing ' IIf(txtNumCaja.Text.Trim.Length > 0, txtNumCaja.Text, Nothing)
        objCaja.moneda = "1" ' txtCodMoneda.Text ' IIf(cboMoneda.Text = "MONEDA NACIONAL (SOLES)", "SOL", "USD")
        objCaja.tipoCambio = CDec(txtTipoCambio.Text)


        objCaja.glosa = txtGlosa.Text.Trim
        objCaja.entregado = "SI"
        objCaja.entidadFinanciera = ef.idestado
        objCaja.usuarioModificacion = usuario.IDUsuario
        objCaja.fechaModificacion = DateTime.Now
        nDocumentoCaja.documentoCaja = objCaja

        '   For Each i As DataGridViewRow In dgvNuevoDoc.Rows
        For Each i In listaCaja
            sumMN += CDec(i.saldoVentaMN)
            sumME += CDec(i.saldoVentaME)
            objCajaDetalle = New documentoCajaDetalle
            objCajaDetalle.idDocumento = 0
            objCajaDetalle.documentoAfectadodetalle = i.idPadreDTCompra
            objCajaDetalle.fecha = txtFecha.Value
            objCajaDetalle.idItem = i.idItem
            objCajaDetalle.DetalleItem = i.descripcionItem
            objCajaDetalle.montoSoles = i.saldoVentaMN
            objCajaDetalle.montoUsd = i.saldoVentaME
            objCajaDetalle.entregado = "SI"
            objCajaDetalle.documentoAfectado = 0 ' lblIdDoc.Text
            objCajaDetalle.usuarioModificacion = usuario.IDUsuario
            objCajaDetalle.fechaModificacion = DateTime.Now
            ListaDetalle.Add(objCajaDetalle)
        Next
        nDocumentoCaja.documentoCaja.montoSoles = sumMN
        nDocumentoCaja.documentoCaja.montoUsd = sumME

        nDocumentoCaja.documentoCaja.documentoCajaDetalle = ListaDetalle


        'ASIENTO CONTABLE

        asiento = New asiento
        With asiento
            .periodo = lblPerido.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCostos = GEstableciento.IdEstablecimiento
            .idEntidad = txtProveedor.Tag
            .nombreEntidad = txtProveedor.Text
            .tipoEntidad = "PR"
            .fechaProceso = txtFecha.Value
            .codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_COMPRAS
            .tipo = "D"
            .tipoAsiento = ASIENTO_CONTABLE.Compra_NotaCredito
            .importeMN = sumMN ' TotalesXcanbeceras.SaldoVentaMN
            .importeME = sumME ' TotalesXcanbeceras.SaldoVentaME
            .glosa = txtGlosa.Text.Trim
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With

        nMovimiento = New movimiento
        Select Case txtTipoDoc.Text
            Case "RECIBOS POR SERVICIOS PUBLICOS"
                nMovimiento.cuenta = "424"
            Case Else
                nMovimiento.cuenta = "4212"
        End Select
        nMovimiento.descripcion = txtProveedor.Text
        nMovimiento.tipo = "D"
        nMovimiento.monto = sumMN ' TotalesXcanbeceras.SaldoVentaMN
        nMovimiento.montoUSD = sumME ' TotalesXcanbeceras.SaldoVentaME
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = DateTime.Now
        asiento.movimiento.Add(nMovimiento)


        nMovimiento = New movimiento
        nMovimiento.cuenta = ef.cuenta
        nMovimiento.descripcion = txtProveedor.Text
        nMovimiento.tipo = "H"
        nMovimiento.monto = sumMN ' TotalesXcanbeceras.SaldoVentaMN
        nMovimiento.montoUSD = sumME 'TotalesXcanbeceras.SaldoVentaME
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = DateTime.Now
        asiento.movimiento.Add(nMovimiento)

        ListaAsientonTransito.Add(asiento)

        Return nDocumentoCaja
    End Function

    Sub GuiaRemision(objDocumentoCompra As documento, Lista As List(Of documentocompradetalle))
        Dim guiaRemisionBE As New documentoGuia
        Dim documentoguiaDetalle As New documentoguiaDetalle
        Dim ListaGuiaDetalle As New List(Of documentoguiaDetalle)
        'REGISTRANDO LA GUIA DE REMISION
        With guiaRemisionBE
            .idDocumento = 0
            .codigoLibro = "8"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFecha.Value
            .periodo = lblPerido.Text
            .tipoDoc = "99"
            .idEntidad = CInt(txtProveedor.Tag)
            .monedaDoc = IIf(txtMon.Text = 1, "1", "2")
            .tasaIgv = CDec(txtIva.Text)
            .tipoCambio = CDec(txtTipoCambio.Text)
            .importeMN = TotalesXcanbeceras.TotalMN
            .importeME = TotalesXcanbeceras.TotalMN
            .glosa = txtGlosa.Text.Trim
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With
        objDocumentoCompra.documentoGuia = guiaRemisionBE

        For Each r As documentocompradetalle In Lista

            If r.tipoExistencia <> "GS" Then
                'If r.GetValue("almacen") <> idAlmacenVirtual Then
                documentoguiaDetalle = New documentoguiaDetalle
                If txtSerieGuia.Text.Trim.Length > 0 Then
                    'objDocumentoCompra.documentoGuia.serie = String.Format("{0:00000}", Convert.ToInt32(txtSerieGuia.Text))
                    objDocumentoCompra.documentoGuia.serie = txtSerieGuia.Text
                Else
                    Throw New Exception("Ingrese número de serie de la guía!")
                    'MessageBoxAdv.Show("Ingrese número de serie de la guía!")
                    'Exit Sub
                End If
                If txtNumeroGuia.Text.Trim.Length > 0 Then
                    objDocumentoCompra.documentoGuia.numeroDoc = txtNumeroGuia.Text
                Else
                    Throw New Exception("Ingrese número de la guía!")
                    'MessageBoxAdv.Show("Ingrese número de la guía!")
                    'Exit Sub
                End If
                documentoguiaDetalle.idDocumento = 0
                documentoguiaDetalle.idItem = r.idItem
                documentoguiaDetalle.descripcionItem = r.descripcionItem
                documentoguiaDetalle.destino = r.destino
                documentoguiaDetalle.unidadMedida = Nothing  'r.GetValue("um")
                documentoguiaDetalle.cantidad = r.monto1
                documentoguiaDetalle.precioUnitario = r.precioUnitario
                documentoguiaDetalle.precioUnitarioUS = r.precioUnitarioUS
                documentoguiaDetalle.importeMN = r.importe
                documentoguiaDetalle.importeME = r.importeUS
                documentoguiaDetalle.almacenRef = r.almacenRef
                documentoguiaDetalle.usuarioModificacion = usuario.IDUsuario
                documentoguiaDetalle.fechaModificacion = DateTime.Now
                ListaGuiaDetalle.Add(documentoguiaDetalle)
            End If

        Next
        objDocumentoCompra.documentoGuia.documentoguiaDetalle = ListaGuiaDetalle
    End Sub

    Sub Grabar()
        Dim CompraSA As New DocumentoCompraSA
        Dim ndocumento As New documento()
        Dim nDocumentoExce As New documento
        Dim nDocumentoCompra As New documentocompra()
        Dim objDocumentoCompraDet As New documentocompradetalle

        Dim entidadSA As New entidadSA
        Dim entidad As New entidad
        Dim DocCaja As New documento
        Dim FichaEFSaldo As New GFichaUsuario
        Dim asientoSA As New AsientoSA
        ' Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento
        Dim almacenSA As New almacenSA
        Dim ListaDetalle As New List(Of documentocompradetalle)
        Dim ListaTotales As New List(Of totalesAlmacen)
        ''''''''''' LIMPIANDO VARIABLES---------------------

        ListaAsientonTransito = New List(Of asiento)

        With ndocumento
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If Not IsNothing(GProyectos) Then
                .idProyecto = GProyectos.IdProyectoActividad
            End If
            .tipoDoc = "07"
            .fechaProceso = txtFecha.Value
            .nroDoc = txtSerie.Text & "-" & txtNumero.Text.Trim
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = "02"
            .moneda = IIf(txtMon.Text = 1, "1", "2")
            .idEntidad = Val(txtProveedor.Tag)
            .entidad = txtProveedor.Text
            .tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
            .nrodocEntidad = txtRuc.Text
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With

        With nDocumentoCompra
            .tieneDetraccion = "N"
            .idPadre = IdCompraOrigen
            .codigoLibro = "8"
            .tipoDoc = "07"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFecha.Value
            .fechaLaboral = New DateTime(DiaLaboral.Year, DiaLaboral.Month, DiaLaboral.Day, DiaLaboral.Hour, DiaLaboral.Minute, DiaLaboral.Second)
            .fechaContable = lblPerido.Text
            .serie = txtSerie.Text.Trim
            .numeroDoc = txtNumero.Text
            .idProveedor = CInt(txtProveedor.Tag)
            .nombreProveedor = txtProveedor.Text
            .monedaDoc = IIf(txtMon.Text = 1, "1", "2")
            .tasaIgv = CDec(txtIva.Text)    ' IIf(IsNothing(nudIgv.Value) Or String.IsNullOrEmpty(nudIgv.Value) Or String.IsNullOrWhiteSpace(nudIgv.Value), Nothing, Trim(nudIgv.Value))
            .tcDolLoc = CDec(txtTipoCambio.Text)
            .tipoRecaudo = Nothing
            .regimen = Nothing
            .tasaRegimen = 0
            .nroRegimen = Nothing
            '****************** DESTINO EN SOLES ************************************************************************
            .bi01 = TotalesXcanbeceras.base1.GetValueOrDefault
            .bi02 = TotalesXcanbeceras.base2.GetValueOrDefault

            .igv01 = TotalesXcanbeceras.MontoIgv1.GetValueOrDefault
            .igv02 = TotalesXcanbeceras.MontoIgv2.GetValueOrDefault


            '****************** DESTINO EN DOLARES ************************************************************************
            .bi01us = TotalesXcanbeceras.base1me.GetValueOrDefault
            .bi02us = TotalesXcanbeceras.base2me.GetValueOrDefault

            .igv01us = TotalesXcanbeceras.MontoIgv1me.GetValueOrDefault
            .igv02us = TotalesXcanbeceras.MontoIgv2me.GetValueOrDefault

            '****************************************************************************************************************
            .importeTotal = TotalesXcanbeceras.TotalMN.GetValueOrDefault
            .importeUS = TotalesXcanbeceras.TotalME.GetValueOrDefault
            .destino = TIPO_COMPRA.NOTA_CREDITO
            .glosa = txtGlosa.Text.Trim
            .referenciaDestino = Nothing ' IIf(IsNothing(txtDestinoref.Text) Or String.IsNullOrEmpty(txtDestinoref.Text) Or String.IsNullOrWhiteSpace(txtDestinoref.Text), Nothing, Trim(txtDestinoref.Text.Trim))
            .tipoCompra = TIPO_COMPRA.NOTA_CREDITO
            .situacion = statusComprobantes.Normal
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
            .sustentado = "01" 'strTipoNota
            .aprobado = "N"
            If cboDevolucion.Visible = True Then
                If cboDevolucion.Text = "PAGADO" Then
                    .EstadoPagoDevolucion = TIPO_VENTA.PAGO.COBRADO
                Else
                    .EstadoPagoDevolucion = TIPO_VENTA.PAGO.PENDIENTE_PAGO
                End If
            Else
                .EstadoPagoDevolucion = Nothing
            End If

            .ImporteDevMN = TotalesXcanbeceras.importeDevmn.GetValueOrDefault
            .ImporteDevME = TotalesXcanbeceras.importeDevme.GetValueOrDefault
            .SaldoVentaMN = TotalesXcanbeceras.SaldoVentaMN.GetValueOrDefault
            .SaldoVentaME = TotalesXcanbeceras.SaldoVentaME.GetValueOrDefault
            .CajaSeleccionada = Nothing
        End With
        ndocumento.documentocompra = nDocumentoCompra
        For Each r As Record In dgvMov.Table.Records
            objDocumentoCompraDet = New documentocompradetalle
            objDocumentoCompraDet.saldoVentaMN = r.GetValue("importeMN")
            objDocumentoCompraDet.saldoVentaME = r.GetValue("importeME")
            Select Case r.GetValue("estadoPago")
                Case "Pagado"
                    objDocumentoCompraDet.ImporteDevolucionmn = r.GetValue("ValDevmn")
                    objDocumentoCompraDet.ImporteDevolucionme = r.GetValue("ValDevme")

                Case Else
                    objDocumentoCompraDet.ImporteDevolucionmn = r.GetValue("ValDevmn")
                    objDocumentoCompraDet.ImporteDevolucionme = r.GetValue("ValDevme")
            End Select

            If objDocumentoCompraDet.ImporteDevolucionmn > 0 Then
                objDocumentoCompraDet.TieneExcedente = True
            Else
                objDocumentoCompraDet.TieneExcedente = False
            End If
            objDocumentoCompraDet.secuencia = r.GetValue("sec")
            objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
            objDocumentoCompraDet.FechaDoc = txtFecha.Value
            objDocumentoCompraDet.FechaLaboral = New DateTime(DiaLaboral.Year, DiaLaboral.Month, DiaLaboral.Day, DiaLaboral.Hour, DiaLaboral.Minute, DiaLaboral.Second)
            'objDocumentoCompraDet.TipoDoc = "07"
            'objDocumentoCompraDet.Serie = txtSerie.Text
            'objDocumentoCompraDet.NumDoc = txtNumero.Text
            Select Case r.GetValue("cboMov")
                Case "1" '"DISMINUIR CANTIDAD"
                    If Not CDec(r.GetValue("canDev")) > 0 Then
                        lblEstado.Text = "Ingrese una cantidad mayor a cero!"
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                        'Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc.Rows(i.Index).Cells(7)
                        'Me.dgvNuevoDoc.BeginEdit(True)
                        Exit Sub
                    End If

                    objDocumentoCompraDet.TipoOperacion = "9913"
                    objDocumentoCompraDet.operacionNota = "9913"
                Case "2" '"DISMINUIR IMPORTE"
                    If Not CDec(r.GetValue("vcmn")) > 0 Then
                        lblEstado.Text = "Ingrese un Valor de compra mayor a cero!"
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                        'Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc.Rows(i.Index).Cells(8)
                        'Me.dgvNuevoDoc.BeginEdit(True)
                        Exit Sub
                    End If

                    objDocumentoCompraDet.TipoOperacion = "9914"
                    objDocumentoCompraDet.operacionNota = "9914"


                Case "4" '"PRONTO PAGO - VOLUMEN DE COMPRA"
                    If Not CDec(r.GetValue("vcmn")) > 0 Then
                        lblEstado.Text = "Ingrese un Valor de compra mayor a cero!"
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                        Exit Sub
                    End If

                    objDocumentoCompraDet.TipoOperacion = "9925"
                    objDocumentoCompraDet.operacionNota = "9925"

                Case "DISMINUIR CANTIDAD E IMPORTE"
                    objDocumentoCompraDet.TipoOperacion = "9915"
                Case "3" '"DEVOLUCION DE EXISTENCIAS"

                    Select Case r.GetValue("tipoEx")
                        Case "GS"

                            If Not CDec(r.GetValue("vcmn")) > 0 Then
                                lblEstado.Text = "Ingrese un Valor de Venta mayor a cero!"
                                PanelError.Visible = True
                                Timer1.Enabled = True
                                TiempoEjecutar(10)

                                Exit Sub
                            End If

                        Case Else
                            If Not CDec(r.GetValue("canDev")) > 0 Then
                                lblEstado.Text = "Ingrese una cantidad mayor a cero!"
                                PanelError.Visible = True
                                Timer1.Enabled = True
                                TiempoEjecutar(10)

                                Exit Sub
                            End If

                            If Not CDec(r.GetValue("vcmn")) > 0 Then
                                lblEstado.Text = "Ingrese un Valor de Venta mayor a cero!"
                                PanelError.Visible = True
                                Timer1.Enabled = True
                                TiempoEjecutar(10)

                                Exit Sub
                            End If
                    End Select
                    objDocumentoCompraDet.TipoOperacion = "9916"
                    objDocumentoCompraDet.operacionNota = "9916"
                Case "BONIFICACIONES RECIBIDAS (OPC. Beneficios)"
                    objDocumentoCompraDet.TipoOperacion = "9917"
                    objDocumentoCompraDet.operacionNota = "9917"
                Case "BONIFICACIONES RECIBIDAS (OPC. Reduc. costos)"
                    objDocumentoCompraDet.TipoOperacion = "9918"
                    objDocumentoCompraDet.operacionNota = "9918"

                    'objDocumentoCompraDet.FlagBonif = i.Cells(40).Value()
            End Select
            objDocumentoCompraDet.destino = r.GetValue("grav")
            objDocumentoCompraDet.idItem = r.GetValue("idItem")
            objDocumentoCompraDet.descripcionItem = CStr(r.GetValue("item"))
            objDocumentoCompraDet.tipoExistencia = CStr(r.GetValue("tipoEx"))
            objDocumentoCompraDet.monto1 = CDec(r.GetValue("canDev"))
            objDocumentoCompraDet.precioUnitario = CDec(r.GetValue("pumn"))
            objDocumentoCompraDet.precioUnitarioUS = CDec(r.GetValue("pume"))
            objDocumentoCompraDet.importe = CDec(r.GetValue("totalmn"))
            objDocumentoCompraDet.importeUS = CDec(r.GetValue("totalme"))
            objDocumentoCompraDet.montokardex = CDec(r.GetValue("vcmn"))
            objDocumentoCompraDet.montoIsc = 0 ' CDec(i.Cells(13).Value())
            objDocumentoCompraDet.montoIgv = CDec(r.GetValue("ivamn"))
            objDocumentoCompraDet.otrosTributos = 0 ' CDec(i.Cells(15).Value())
            '**********************************************************************************
            objDocumentoCompraDet.montokardexUS = CDec(r.GetValue("vcme"))
            objDocumentoCompraDet.montoIscUS = 0 'CDec(i.Cells(17).Value())
            objDocumentoCompraDet.montoIgvUS = CDec(r.GetValue("ivame"))
            objDocumentoCompraDet.otrosTributosUS = 0 ' CDec(i.Cells(19).Value())

            objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
            objDocumentoCompraDet.almacenRef = CInt(r.GetValue("almacenRef"))

            objDocumentoCompraDet.preEvento = r.GetValue("estadoPago")  '= "00", Nothing, dgvNuevoDoc.Rows(S).Cells(23).Value())
            objDocumentoCompraDet.bonificacion = Nothing


            objDocumentoCompraDet.idPadreDTCompra = CInt(r.GetValue("sec"))
            '**********************************************************************************
            objDocumentoCompraDet.usuarioModificacion = usuario.IDUsuario
            objDocumentoCompraDet.fechaModificacion = DateTime.Now
            objDocumentoCompraDet.FechaVcto = Nothing ' IIf(IsNothing(dgvNuevoDoc.Rows(S).Cells(28).Value()), Nothing, CDate(dgvNuevoDoc.Rows(S).Cells(28).Value()))
            objDocumentoCompraDet.Glosa = txtGlosa.Text.Trim
            ' objDocumentoCompraDet.BonificacionMN =

            objDocumentoCompraDet.NumDoc = txtNumeroGuia.Text
            objDocumentoCompraDet.Serie = txtSerieGuia.Text
            objDocumentoCompraDet.TipoDoc = "99"
            'objDocumentoCompraDet.estadoPago = r.GetValue("estadoPago")
            If r.GetValue("estadoPago") = "Pagado" Then
                objDocumentoCompraDet.estadoPago = TIPO_COMPRA.PAGO.PAGADO
            ElseIf r.GetValue("estadoPago") = "Pendiente" Then
                objDocumentoCompraDet.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
            End If

            objDocumentoCompraDet.bonificacion = r.GetValue("bonificacion")
            ListaDetalle.Add(objDocumentoCompraDet)
            '   End If
        Next
        '---------------------------------------------------------------------------------
        ndocumento.documentocompra.tipoOperacion = "02"

        Dim ItemPagados As List(Of documentocompradetalle) = (From n In ListaDetalle
                                                              Where n.preEvento = "Pagado" _
                                                              AndAlso Fix(n.ImporteDevolucionmn) > 0).ToList


        If ItemPagados.Count > 0 Then
            If cboDevolucion.Text = "PAGADO" Then
                'If cboDepositoHijo.Text.Trim.Length > 0 Then

                'Else
                '    Throw New Exception("Debe seleccionar una entidad financiera válida!")
                'End If

                'DocCaja = ComprobanteCaja(ItemPagados) ' DEVOLUCION DEL EXCEDENTE

                ''obteniendo saldo  de la entidad financiera seleccionada
                'FichaEFSaldo = GetSaldoEF()

                'If ItemPagados.Sum(Function(o) o.importe) > FichaEFSaldo.SaldoMN Then
                '    Throw New Exception("El importe compra execede al monto de la cuenta financiera actual!")
                'End If

            Else

            End If
            ''EXISTENCIAS
            Dim ListadoExistencias = (From n In ItemPagados _
                                      Where n.tipoExistencia <> TipoRecurso.SERVICIO).ToList

            If ListadoExistencias.Count > 0 Then
                AsientoNotaCreditoExcedente(ListadoExistencias)
            End If
            '------------------------------------------------------------------------------------------

            ''SERVICIOS
            Dim ListadoServicios = (From n In ItemPagados _
                                               Where n.tipoExistencia = TipoRecurso.SERVICIO).ToList

            If ListadoServicios.Count > 0 Then
                AsientoNotaCreditoExcedenteServicios(ListadoServicios)
            End If


        End If
        '------------------------------------------------------------------------------------------------------------
        '**************************************************************************************************************

        Dim itemNoPagados As List(Of documentocompradetalle) = (From n In ListaDetalle _
                                                                 Where n.preEvento = "Pendiente").ToList

        Dim documentoSaldo As New documento

        If itemNoPagados.Count > 0 Then
            Dim Opcion1 As List(Of documentocompradetalle) = (From i In itemNoPagados _
                                                                 Where i.ImporteDevolucionmn > 0 AndAlso i.saldoVentaMN > 0).ToList
            If Opcion1.Count > 0 Then
                If cboDevolucion.Text = "PAGADO" Then

                    'If cboDepositoHijo.Text.Trim.Length > 0 Then

                    'Else
                    '    Throw New Exception("Debe seleccionar una entidad financiera válida!")
                    'End If

                    'DocCaja = ComprobanteCaja(ItemPagados) ' DEVOLUCION DEL EXCEDENTE

                    ''obteniendo saldo  de la entidad financiera seleccionada
                    'FichaEFSaldo = GetSaldoEF()

                    'If ItemPagados.Sum(Function(o) o.importe) > FichaEFSaldo.SaldoMN Then
                    '    Throw New Exception("El importe compra execede al monto de la cuenta financiera actual!")
                    'End If


                    'EXISTENCIAS
                    Dim ListadoExistencias = (From n In Opcion1 _
                                    Where n.tipoExistencia <> TipoRecurso.SERVICIO).ToList

                    If ListadoExistencias.Count > 0 Then
                        AsientoNotaCreditoExcedenteMaspagoDeuda(ListadoExistencias)
                    End If
                    '----------------------------------------------------------------------------------

                    ''SERVICIOS
                    Dim ListadoServicios = (From n In Opcion1 _
                                              Where n.tipoExistencia = TipoRecurso.SERVICIO).ToList

                    If ListadoServicios.Count > 0 Then
                        AsientoNotaCreditoExcedenteServiciosMasPago(ListadoServicios)
                    End If
                    documentoSaldo = ComprobanteCajaSaldo(Opcion1) ' PAGO DEL SALDO DE LA VENTA
                Else
                    'EXISTENCIAS
                    Dim ListadoExistencias = (From n In Opcion1 _
                                    Where n.tipoExistencia <> TipoRecurso.SERVICIO).ToList

                    If ListadoExistencias.Count > 0 Then
                        AsientoNotaCreditoExcedenteMaspagoDeudaPendiente(ListadoExistencias)
                    End If
                    '----------------------------------------------------------------------------------

                    ''SERVICIOS
                    Dim ListadoServicios = (From n In Opcion1 _
                                              Where n.tipoExistencia = TipoRecurso.SERVICIO).ToList

                    If ListadoServicios.Count > 0 Then
                        AsientoNotaCreditoExcedenteServiciosMasPagoPendiente(ListadoServicios)
                    End If
                End If

                'documentoSaldo = ComprobanteCajaSaldo(Opcion1) ' PAGO DEL SALDO DE LA VENTA
            End If

            'opcion 02

            Dim Opcion2 As List(Of documentocompradetalle) = (From i In itemNoPagados _
                                                             Where i.ImporteDevolucionmn = 0 AndAlso i.saldoVentaMN > 0).ToList
            If Opcion2.Count > 0 Then
                ''EXISTENCIAS
                Dim ListadoExistencias = (From n In Opcion2 _
                                Where n.tipoExistencia <> TipoRecurso.SERVICIO).ToList

                If ListadoExistencias.Count > 0 Then
                    AsientoNotaCreditoNormal(ListadoExistencias)
                End If

                '-------------------------------------------------------------------------
                ''SERVICIOS
                Dim ListadoServicios = (From n In Opcion2 _
                              Where n.tipoExistencia = TipoRecurso.SERVICIO).ToList

                If ListadoServicios.Count > 0 Then
                    AsientoNotaCreditoNormalServicio(ListadoServicios)
                End If
            End If

        End If
        ndocumento.asiento = ListaAsientonTransito


        '-------------------------------- codigo anterior abajo---------------------------------------------------------


        ''Asignando el asiento de la nota de credito
        'Dim array() As String = {"9916", "9914"}
        'Dim consultaAsiento As List(Of documentocompradetalle) = (From i In ListaDetalle _
        '               Where array.Contains(i.TipoOperacion)).ToList

        'If consultaAsiento.Count > 0 Then
        '    AsientoNotaCredito(consultaAsiento)
        '    ndocumento.asiento = ListaAsientonTransito
        'End If


        Dim listaOp As New List(Of String)
        listaOp.Add("9913") 'NC-DISMINUIR CANTIDAD
        listaOp.Add("9916") 'NC-DEVOLUCION DE EXISTENCIAS


        Dim consulta As List(Of documentocompradetalle) = (From i In ListaDetalle _
                       Where listaOp.Contains(i.TipoOperacion)).ToList

        If consulta.Count > 0 Then
            GuiaRemision(ndocumento, consulta)
        End If

        For Each d In ListaDetalle
            d.preEvento = Nothing
            If d.bonificacion = "SI" Then
                d.bonificacion = "S"
            Else
                d.bonificacion = "N"
            End If
        Next


        ndocumento.documentocompra.documentocompradetalle = ListaDetalle

        Dim xcod As Integer = CompraSA.SaveCompraNotaCredito2(ndocumento, DocCaja, documentoSaldo)
        lblEstado.Text = "nota de crédito registrada!"
        Dispose()
    End Sub

    Public Class TotalesXcanbecera
        Public Property BaseMN() As Decimal?
        Public Property BaseME() As Decimal?
        Public Property IgvMN() As Decimal?
        Public Property IgvME() As Decimal?
        Public Property TotalMN() As Decimal?
        Public Property TotalME() As Decimal?
        Public Property base1() As Decimal?
        Public Property base1me() As Decimal?
        Public Property base2() As Decimal?
        Public Property base2me() As Decimal?
        Public Property MontoIgv1() As Decimal?
        Public Property MontoIgv1me() As Decimal?
        Public Property MontoIgv2() As Decimal?
        Public Property MontoIgv2me() As Decimal?

        Public Property importeDevmn() As Decimal?
        Public Property importeDevme() As Decimal?

        Public Property SaldoVentaMN() As Decimal?
        Public Property SaldoVentaME() As Decimal?

        Public Sub New()

        End Sub


    End Class

    Sub TotalTalesXcolumna()
        'Dim totalDevolucionMN As Decimal = 0
        'Dim totalDevolucionME As Decimal = 0
        Dim totalVC As Decimal = 0
        Dim totalVCme As Decimal = 0

        Dim totalIVA As Decimal = 0
        Dim totalIVAme As Decimal = 0

        Dim totalDesc As Decimal = 0
        Dim totalDescme As Decimal = 0

        Dim total As Decimal = 0
        Dim totalme As Decimal = 0

        Dim bs1 As Decimal = 0
        Dim bs1me As Decimal = 0
        Dim bs2 As Decimal = 0
        Dim bs2me As Decimal = 0
        Dim igv1 As Decimal = 0
        Dim igv1me As Decimal = 0
        Dim igv2 As Decimal = 0
        Dim igv2me As Decimal = 0

        Dim dvmn As Decimal = 0
        Dim dvme As Decimal = 0
        Dim saldoMN As Decimal = 0
        Dim saldoME As Decimal = 0
        For Each r As Record In dgvMov.Table.Records

            If r.GetValue("bonificacion") = "NO" Then
                'devolucion de dinero
                'totalDevolucionMN += CDec(r.GetValue("ValDevmn"))
                'totalDevolucionME += CDec(r.GetValue("ValDevme"))
                saldoMN += CDec(r.GetValue("importeMN"))
                saldoME += CDec(r.GetValue("importeME"))

                '      If r.GetValue("estadoPago") = "Pagado" Then
                dvmn += CDec(r.GetValue("ValDevmn"))
                dvme += CDec(r.GetValue("ValDevme"))
                '   End If

                'If r.GetValue("valBonif") = "S" Then
                '    totalDesc += CDec(r.GetValue("igvmn"))
                '    totalDescme += CDec(r.GetValue("igvme"))
                'Else
                totalVC += CDec(r.GetValue("vcmn"))
                totalVCme += CDec(r.GetValue("vcme"))

                totalIVA += CDec(r.GetValue("ivamn"))
                totalIVAme += CDec(r.GetValue("ivame"))

                total += CDec(r.GetValue("totalmn"))
                totalme += CDec(r.GetValue("totalme"))
                'End If

                Select Case r.GetValue("grav")
                    Case "1"
                        bs1 += CDec(r.GetValue("vcmn"))
                        bs1me += CDec(r.GetValue("vcme"))

                        igv1 += CDec(r.GetValue("ivamn"))
                        igv1me += CDec(r.GetValue("ivame"))
                    Case "2"
                        bs2 += CDec(r.GetValue("vcmn"))
                        bs2me += CDec(r.GetValue("vcme"))

                        igv2 += CDec(r.GetValue("ivamn"))
                        igv2me += CDec(r.GetValue("ivame"))
                End Select
            End If



        Next
        TotalesXcanbeceras = New TotalesXcanbecera()

        TotalesXcanbeceras.BaseMN = totalVC
        TotalesXcanbeceras.BaseME = totalVCme

        TotalesXcanbeceras.IgvMN = totalIVA
        TotalesXcanbeceras.IgvME = totalIVAme

        TotalesXcanbeceras.TotalMN = total
        TotalesXcanbeceras.TotalME = totalme

        TotalesXcanbeceras.base1 = bs1
        TotalesXcanbeceras.base1me = bs1me
        TotalesXcanbeceras.base2 = bs2
        TotalesXcanbeceras.base2me = bs2me

        TotalesXcanbeceras.MontoIgv1 = igv1
        TotalesXcanbeceras.MontoIgv1me = igv1me
        TotalesXcanbeceras.MontoIgv2 = igv2
        TotalesXcanbeceras.MontoIgv2me = igv2me

        TotalesXcanbeceras.importeDevmn = dvmn
        TotalesXcanbeceras.importeDevme = dvme
        TotalesXcanbeceras.SaldoVentaMN = saldoMN
        TotalesXcanbeceras.SaldoVentaME = saldoME

        '****************************************************
        txtSaldoPendiente.DecimalValue = saldoMN
        txtBonifica.DecimalValue = dvmn
        txtTotalBase.DecimalValue = totalVC
        txtTotalIva.DecimalValue = totalIVA
        txtTotalPagar.DecimalValue = total

        If TotalesXcanbeceras.importeDevmn > 0 Then
            lbldev.Visible = True
            cboDevolucion.Visible = True
        Else
            lbldev.Visible = False
            cboDevolucion.Visible = False
        End If

    End Sub

    Private Sub MostrarColumnsByMoneda(strMoneda As String)
        dgvMov.TableDescriptor.Columns("ValDevmn").Width = 70
        dgvMov.TableDescriptor.Columns("ValDevme").Width = 0
        dgvMov.TableDescriptor.Columns("action").Width = 0

        Select Case strMoneda
            Case "1"
                dgvMov.TableDescriptor.Columns("precMN").Width = 65
                dgvMov.TableDescriptor.Columns("importeMN").Width = 0
                dgvMov.TableDescriptor.Columns("compraMN").Width = 65
                dgvMov.TableDescriptor.Columns("montokardex").Width = 65
                dgvMov.TableDescriptor.Columns("montoIgv").Width = 65
                dgvMov.TableDescriptor.Columns("vcmn").Width = 65
                dgvMov.TableDescriptor.Columns("ivamn").Width = 65
                dgvMov.TableDescriptor.Columns("totalmn").Width = 65
                dgvMov.TableDescriptor.Columns("pumn").Width = 65
                dgvMov.TableDescriptor.Columns("kardexAct").Width = 65
                dgvMov.TableDescriptor.Columns("impActMN").Width = 65

                dgvMov.TableDescriptor.Columns("precME").Width = 0
                dgvMov.TableDescriptor.Columns("importeME").Width = 0
                dgvMov.TableDescriptor.Columns("compraME").Width = 0
                dgvMov.TableDescriptor.Columns("montokardexus").Width = 0
                dgvMov.TableDescriptor.Columns("montoIgvUS").Width = 0
                dgvMov.TableDescriptor.Columns("vcme").Width = 0
                dgvMov.TableDescriptor.Columns("ivame").Width = 0
                dgvMov.TableDescriptor.Columns("totalme").Width = 0
                dgvMov.TableDescriptor.Columns("pume").Width = 0
                dgvMov.TableDescriptor.Columns("kardexActME").Width = 0
                dgvMov.TableDescriptor.Columns("impActME").Width = 0

            Case "2"
                dgvMov.TableDescriptor.Columns("precME").Width = 65
                dgvMov.TableDescriptor.Columns("importeME").Width = 0
                dgvMov.TableDescriptor.Columns("compraME").Width = 65
                dgvMov.TableDescriptor.Columns("montokardexus").Width = 65
                dgvMov.TableDescriptor.Columns("montoIgvUS").Width = 65
                dgvMov.TableDescriptor.Columns("vcme").Width = 65
                dgvMov.TableDescriptor.Columns("ivame").Width = 65
                dgvMov.TableDescriptor.Columns("totalme").Width = 65
                dgvMov.TableDescriptor.Columns("pume").Width = 65
                dgvMov.TableDescriptor.Columns("kardexActME").Width = 65
                dgvMov.TableDescriptor.Columns("impActME").Width = 65

                dgvMov.TableDescriptor.Columns("precMN").Width = 0
                dgvMov.TableDescriptor.Columns("importeMN").Width = 0
                dgvMov.TableDescriptor.Columns("compraMN").Width = 0
                dgvMov.TableDescriptor.Columns("montokardex").Width = 0
                dgvMov.TableDescriptor.Columns("montoIgv").Width = 0
                dgvMov.TableDescriptor.Columns("vcmn").Width = 0
                dgvMov.TableDescriptor.Columns("ivamn").Width = 0
                dgvMov.TableDescriptor.Columns("totalmn").Width = 0
                dgvMov.TableDescriptor.Columns("pumn").Width = 0
                dgvMov.TableDescriptor.Columns("kardexAct").Width = 0
                dgvMov.TableDescriptor.Columns("impActMN").Width = 0
        End Select
    End Sub


    Public Sub GEtColumnsByDatatable()
        Dim dt As New DataTable
        Try
            dt.Columns.Add("sec", GetType(Integer))
            dt.Columns.Add("grav", GetType(String))
            dt.Columns.Add("idItem", GetType(Integer))
            dt.Columns.Add("item", GetType(String))
            dt.Columns.Add("cantidad", GetType(Decimal))
            dt.Columns.Add("kardexAct", GetType(Decimal))
            dt.Columns.Add("kardexActME", GetType(Decimal))
            dt.Columns.Add("precMN", GetType(Decimal))
            dt.Columns.Add("importeMN", GetType(Decimal))
            dt.Columns.Add("precME", GetType(Decimal))
            dt.Columns.Add("importeME", GetType(Decimal))
            dt.Columns.Add("tipoEx", GetType(String))
            dt.Columns.Add("almacenRef", GetType(Integer))

            dt.Columns.Add("cantCompra", GetType(Decimal))
            dt.Columns.Add("compraMN", GetType(Decimal))
            dt.Columns.Add("compraME", GetType(Decimal))
            dt.Columns.Add("montokardex", GetType(Decimal))
            dt.Columns.Add("montokardexus", GetType(Decimal))
            dt.Columns.Add("impActMN", GetType(Decimal))
            dt.Columns.Add("impActME", GetType(Decimal))
            dt.Columns.Add("montoIgv", GetType(Decimal))
            dt.Columns.Add("montoIgvUS", GetType(Decimal))
            dt.Columns.Add("cboMov", GetType(String))
            dt.Columns.Add("canDev", GetType(Decimal))
            dt.Columns.Add("canSaldo", GetType(Decimal))

            dt.Columns.Add("vcmn", GetType(Decimal))
            dt.Columns.Add("vcme", GetType(Decimal))
            dt.Columns.Add("ivamn", GetType(Decimal))
            dt.Columns.Add("ivame", GetType(Decimal))
            dt.Columns.Add("totalmn", GetType(Decimal))
            dt.Columns.Add("totalme", GetType(Decimal))

            dt.Columns.Add("pumn", GetType(Decimal))
            dt.Columns.Add("pume", GetType(Decimal))
            dt.Columns.Add("estadoPago", GetType(String))

            dt.Columns.Add("ValDevmn", GetType(Decimal))
            dt.Columns.Add("ValDevme", GetType(Decimal))
            dt.Columns.Add("action", GetType(String))
            dt.Columns.Add("bonificacion", GetType(String))

            dt.Columns.Add("dineroDev", GetType(Decimal))
            dt.Columns.Add("dineroDevme", GetType(Decimal))

            dgvMov.DataSource = dt
            dgvMov.TableModel.RowHeights.ResizeToFit(GridRangeInfo.Table(), GridResizeToFitOptions.ResizeCoveredCells)

        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub
    Public Property TipoDocGobal() As String
    'Public Sub UbicarDetalle(intIddocumento As Integer)
    '    Dim detalleSA As New DocumentoCompraDetalleSA
    '    Dim objLista As New DocumentoCajaDetalleSA
    '    Dim detalle As New documentocompradetalle
    '    Dim compraSA As New DocumentoCompraSA
    '    Dim entidadSA As New entidadSA
    '    Dim dt As New DataTable

    '    Dim cTotalmn As Decimal = 0
    '    Dim cTotalme As Decimal = 0
    '    Dim cCreditomn As Decimal = 0
    '    Dim cCreditome As Decimal = 0
    '    Dim cDebitomn As Decimal = 0
    '    Dim cDebitome As Decimal = 0

    '    Dim cCantidadNC As Decimal = 0
    '    Dim cCantidadDB As Decimal = 0
    '    Dim cTotalCantidad As Decimal = 0
    '    Dim saldoCantidad As Decimal = 0
    '    TipoDocGobal = String.Empty
    '    Try


    '        With compraSA.UbicarDocumentoCompra(intIddocumento)
    '            IdCompraOrigen = .idDocumento

    '            txtTipoDoc.Tag = .tipoCompra
    '            If .monedaDoc = "1" Then
    '                txtMon.Text = "1"
    '                MostrarColumnsByMoneda("1")


    '            ElseIf .monedaDoc = "2" Then
    '                txtMon.Text = "2"
    '                MostrarColumnsByMoneda("2")
    '            End If


    '            txtTipoCambio.Text = .tcDolLoc
    '            txtTipoCambio.ReadOnly = True
    '            txtIva.Text = .tasaIgv
    '            txtImpFacmn.DecimalValue = .importeTotal
    '            txtImpFacme.DecimalValue = .importeUS


    '            Dim tablaSA As New tablaDetalleSA

    '            txtTipoDoc.Text = tablaSA.GetUbicarTablaID(CInt(10), .tipoDoc).descripcion
    '            TipoDocGobal = .tipoDoc
    '            TextBoxExt4.Text = .serie
    '            TextBoxExt3.Text = .numeroDoc

    '        End With

    '        Dim saldomn As Decimal = 0
    '        Dim saldome As Decimal = 0

    '        dt.Columns.Add("sec", GetType(Integer))
    '        dt.Columns.Add("grav", GetType(String))
    '        dt.Columns.Add("idItem", GetType(Integer))
    '        dt.Columns.Add("item", GetType(String))
    '        dt.Columns.Add("cantidad", GetType(Decimal))

    '        dt.Columns.Add("precMN", GetType(Decimal))
    '        dt.Columns.Add("importeMN", GetType(Decimal))
    '        dt.Columns.Add("precME", GetType(Decimal))
    '        dt.Columns.Add("importeME", GetType(Decimal))
    '        dt.Columns.Add("tipoEx", GetType(String))
    '        dt.Columns.Add("almacenRef", GetType(Integer))

    '        dt.Columns.Add("cantCompra", GetType(Decimal))
    '        dt.Columns.Add("compraMN", GetType(Decimal))
    '        dt.Columns.Add("compraME", GetType(Decimal))
    '        dt.Columns.Add("montokardex", GetType(Decimal))
    '        dt.Columns.Add("montokardexus", GetType(Decimal))
    '        dt.Columns.Add("montoIgv", GetType(Decimal))
    '        dt.Columns.Add("montoIgvUS", GetType(Decimal))
    '        dt.Columns.Add("cboMov", GetType(String))
    '        dt.Columns.Add("canDev", GetType(Decimal))
    '        dt.Columns.Add("canSaldo", GetType(Decimal))

    '        dt.Columns.Add("vcmn", GetType(Decimal))
    '        dt.Columns.Add("vcme", GetType(Decimal))
    '        dt.Columns.Add("ivamn", GetType(Decimal))
    '        dt.Columns.Add("ivame", GetType(Decimal))
    '        dt.Columns.Add("totalmn", GetType(Decimal))
    '        dt.Columns.Add("totalme", GetType(Decimal))

    '        dt.Columns.Add("pumn", GetType(Decimal))
    '        dt.Columns.Add("pume", GetType(Decimal))
    '        dt.Columns.Add("estadoPago", GetType(String))

    '        dt.Columns.Add("ValDevmn", GetType(Decimal))
    '        dt.Columns.Add("ValDevme", GetType(Decimal))
    '        dt.Columns.Add("action", GetType(String))

    '        For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorPagarPorDetails(intIddocumento)
    '            detalle = detalleSA.SumaNotasXidPadreItem(i.secuencia)

    '            saldoCantidad = i.CantidadCompra - detalle.monto1
    '            cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN
    '            cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS - CDec(i.MontoPagadoUSD) + detalle.ImporteDBME

    '            saldomn += cTotalmn
    '            saldome += cTotalme

    '            saldomn += cTotalmn
    '            saldome += cTotalme

    '            Dim dr As DataRow = dt.NewRow()
    '            dr(0) = i.secuencia
    '            dr(1) = i.destino
    '            dr(2) = i.idItem
    '            dr(3) = i.DetalleItem
    '            Select Case i.TipoExistencia
    '                Case "GS"
    '                    dr(4) = 0
    '                Case Else
    '                    If IsNothing(detalle) Then
    '                        dr(4) = 0
    '                    Else
    '                        dr(4) = i.CantidadCompra - detalle.monto1  ' detalle.monto1
    '                    End If
    '            End Select
    '            dr(5) = 0
    '            If cTotalmn < 0 Then
    '                cTotalmn = 0
    '            End If
    '            dr(6) = cTotalmn
    '            dr(7) = 0
    '            If cTotalme < 0 Then
    '                cTotalme = 0
    '            End If
    '            dr(8) = cTotalme
    '            dr(9) = i.TipoExistencia
    '            dr(10) = i.almacenRef

    '            dr(11) = i.CantidadCompra

    '            dr(12) = i.MontoDeudaSoles
    '            dr(13) = i.MontoDeudaUSD
    '            dr(14) = i.montokardex
    '            dr(15) = i.montokardexus
    '            dr(16) = i.montoIgv
    '            dr(17) = i.montoIgvUS
    '            Select Case dgvCompra.Table.CurrentRecord.GetValue("tipoCompra")
    '                Case TIPO_COMPRA.COMPRA_SERVICIO_PUBLICO, TIPO_COMPRA.COMPRA_RECIBO_HONORARIOS
    '                    dr(18) = "3"
    '                Case Else
    '                    dr(18) = "2"
    '            End Select

    '            dr(19) = 0
    '            dr(20) = 0
    '            dr(21) = 0
    '            dr(22) = 0
    '            dr(23) = 0
    '            dr(24) = 0
    '            dr(25) = 0
    '            dr(26) = 0
    '            dr(27) = 0
    '            dr(28) = 0
    '            Select Case i.EstadoCobro
    '                Case TIPO_COMPRA.PAGO.PAGADO

    '                    dr(29) = "Pagado"
    '                Case Else
    '                    dr(29) = "Pendiente"

    '            End Select
    '            dr(30) = 0
    '            dr(31) = 0
    '            dr(32) = "activo"
    '            dt.Rows.Add(dr)
    '        Next
    '        dgvMov.DataSource = dt
    '        dgvMov.TableModel.RowHeights.ResizeToFit(GridRangeInfo.Table(), GridResizeToFitOptions.ResizeCoveredCells)
    '        '    Me.dgvMov.TableOptions.ListBoxSelectionMode = SelectionMode.One

    '    Catch ex As Exception
    '        lblEstado.Text = ex.Message
    '        PanelError.Visible = True
    '        Timer1.Enabled = True
    '        TiempoEjecutar(10)
    '    End Try
    'End Sub

    Public Sub UbicarDetalleByItemDirecto(intIdDocumento As Integer)
        Dim detalleSA As New DocumentoCompraDetalleSA
        Dim objLista As New DocumentoCajaDetalleSA
        Dim detalle As New documentocompradetalle
        Dim compraSA As New DocumentoCompraSA
        Dim entidadSA As New entidadSA
        Dim dt As New DataTable
        Dim ListaSecuencia As New List(Of documentocompradetalle)
        Dim cTotalmn As Decimal = 0
        Dim cTotalme As Decimal = 0
        Dim cTotalActmn As Decimal = 0
        Dim cTotalActme As Decimal = 0
        Dim cCreditomn As Decimal = 0
        Dim cCreditome As Decimal = 0
        Dim cDebitomn As Decimal = 0
        Dim cDebitome As Decimal = 0

        Dim cCantidadNC As Decimal = 0
        Dim cCantidadDB As Decimal = 0
        Dim cTotalCantidad As Decimal = 0
        Dim saldoCantidad As Decimal = 0
        TipoDocGobal = String.Empty
        Try
            Dim compraBL = compraSA.UbicarDocumentoCompra(intIdDocumento)
            Dim entidad = entidadSA.UbicarEntidadPorID(compraBL.idProveedor).FirstOrDefault
            txtProveedor.Text = entidad.nombreCompleto
            txtProveedor.Tag = entidad.idEntidad
            txtRuc.Text = entidad.nrodoc
            With compraBL
                IdCompraOrigen = .idDocumento
                TipoDocGobal = .tipoDoc
                txtTipoDoc.Tag = .tipoCompra
                If .monedaDoc = "1" Then
                    txtMon.Text = "1"
                    MostrarColumnsByMoneda("1")

                ElseIf .monedaDoc = "2" Then
                    txtMon.Text = "2"
                    MostrarColumnsByMoneda("2")
                End If


                txtTipoCambio.Text = .tcDolLoc
                txtTipoCambio.ReadOnly = True
                txtIva.Text = .tasaIgv
                txtImpFacmn.DecimalValue = .importeTotal
                txtImpFacme.DecimalValue = .importeUS


                Dim tablaSA As New tablaDetalleSA

                txtTipoDoc.Text = tablaSA.GetUbicarTablaID(CInt(10), .tipoDoc).descripcion


                TextBoxExt4.Text = .serie
                TextBoxExt3.Text = .numeroDoc

            End With

            Dim saldomn As Decimal = 0
            Dim saldome As Decimal = 0


            ListaSecuencia = detalleSA.UbicarDocumentoCompraDetalle(intIdDocumento)

            For Each k In ListaSecuencia

                Dim i As New documentoCajaDetalle

                i = objLista.ObtenerCuentasPorPagarBySecuencia(k.secuencia)

                detalle = detalleSA.SumaNotasXidPadreItemOpcionDefault(k.secuencia)
                'detalle = detalleSA.SumaNotasXidPadreItemOpcionDefault(intSecuenciaItem)

                saldoCantidad = i.CantidadCompra - detalle.monto1
                cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN - detalle.montoCompesacion
                cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS - CDec(i.MontoPagadoUSD) + detalle.ImporteDBME - detalle.montoCompesacionme
                cTotalActmn = CDec(i.MontoDeudaSoles) - detalle.importe + detalle.ImporteDBMN
                cTotalActme = CDec(i.MontoDeudaUSD) - detalle.importeUS + detalle.ImporteDBME

                'detalle.montoCompesacion

                saldomn += cTotalmn
                saldome += cTotalme

                saldomn += cTotalmn
                saldome += cTotalme


                Me.dgvMov.Table.AddNewRecord.SetCurrent()
                Me.dgvMov.Table.AddNewRecord.BeginEdit()
                Me.dgvMov.Table.CurrentRecord.SetValue("sec", i.secuencia)
                Me.dgvMov.Table.CurrentRecord.SetValue("grav", i.destino)
                Me.dgvMov.Table.CurrentRecord.SetValue("idItem", i.idItem)
                Me.dgvMov.Table.CurrentRecord.SetValue("item", i.DetalleItem)
                Select Case i.TipoExistencia
                    Case "GS"
                        Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
                    Case Else
                        If IsNothing(detalle) Then
                            Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
                        Else
                            Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", i.CantidadCompra - detalle.monto1)
                        End If
                End Select




                Me.dgvMov.Table.CurrentRecord.SetValue("kardexAct", i.montokardex - detalle.montokardex + detalle.montokardexDB)
                Me.dgvMov.Table.CurrentRecord.SetValue("kardexActME", i.montokardexus - detalle.montokardexUS + detalle.montokardexDBUS)



                Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)

                If cTotalmn < 0 Then
                    cTotalmn = 0
                End If
                Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", cTotalmn)
                Me.dgvMov.Table.CurrentRecord.SetValue("impActMN", cTotalActmn)
                Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)

                If cTotalme < 0 Then
                    cTotalme = 0
                End If
                Me.dgvMov.Table.CurrentRecord.SetValue("importeME", cTotalme)
                Me.dgvMov.Table.CurrentRecord.SetValue("impActME", cTotalActme)

                Me.dgvMov.Table.CurrentRecord.SetValue("tipoEx", i.TipoExistencia)
                Me.dgvMov.Table.CurrentRecord.SetValue("almacenRef", i.almacenRef)

                Me.dgvMov.Table.CurrentRecord.SetValue("cantCompra", i.CantidadCompra)
                Me.dgvMov.Table.CurrentRecord.SetValue("compraMN", i.MontoDeudaSoles)
                Me.dgvMov.Table.CurrentRecord.SetValue("compraME", i.MontoDeudaUSD)
                Me.dgvMov.Table.CurrentRecord.SetValue("montokardex", i.montokardex)
                Me.dgvMov.Table.CurrentRecord.SetValue("montokardexus", i.montokardexus)
                Me.dgvMov.Table.CurrentRecord.SetValue("montoIgv", i.montoIgv)
                Me.dgvMov.Table.CurrentRecord.SetValue("montoIgvUS", i.montoIgvUS)

                Select Case compraBL.tipoCompra
                    Case TIPO_COMPRA.COMPRA_SERVICIO_PUBLICO, TIPO_COMPRA.COMPRA_RECIBO_HONORARIOS
                        Me.dgvMov.Table.CurrentRecord.SetValue("cboMov", "2")
                    Case Else
                        Dim tex = i.TipoExistencia
                        Select Case tex
                            Case "GS"
                                Me.dgvMov.Table.CurrentRecord.SetValue("cboMov", "2")
                            Case Else
                                Me.dgvMov.Table.CurrentRecord.SetValue("cboMov", "3")
                        End Select
                End Select
                Me.dgvMov.Table.CurrentRecord.SetValue("canDev", 0)
                Me.dgvMov.Table.CurrentRecord.SetValue("canSaldo", 0)

                Me.dgvMov.Table.CurrentRecord.SetValue("vcmn", 0)
                Me.dgvMov.Table.CurrentRecord.SetValue("vcme", 0)
                Me.dgvMov.Table.CurrentRecord.SetValue("ivamn", 0)
                Me.dgvMov.Table.CurrentRecord.SetValue("ivame", 0)
                Me.dgvMov.Table.CurrentRecord.SetValue("totalmn", 0)
                Me.dgvMov.Table.CurrentRecord.SetValue("totalme", 0)

                Me.dgvMov.Table.CurrentRecord.SetValue("pumn", 0)
                Me.dgvMov.Table.CurrentRecord.SetValue("pume", 0)


                'If detalle.montoCompesacion > 0 Then
                '    Me.dgvMov.Table.CurrentRecord.SetValue("estadoPago", "Compensado")
                'Else

                Select Case i.EstadoCobro
                    Case TIPO_COMPRA.PAGO.PAGADO
                        Me.dgvMov.Table.CurrentRecord.SetValue("estadoPago", "Pagado")
                        Me.dgvMov.Table.CurrentRecord.SetValue("ValDevmn", i.MontoPagadoSoles - detalle.DineroDevuelto)
                        Me.dgvMov.Table.CurrentRecord.SetValue("ValDevme", i.MontoPagadoUSD - detalle.DineroDevueltome)
                    Case Else
                        Me.dgvMov.Table.CurrentRecord.SetValue("estadoPago", "Pendiente")
                        Me.dgvMov.Table.CurrentRecord.SetValue("ValDevmn", i.MontoPagadoSoles - detalle.DineroDevuelto)
                        Me.dgvMov.Table.CurrentRecord.SetValue("ValDevme", i.MontoPagadoUSD - detalle.DineroDevueltome)
                End Select
                'End If


                Me.dgvMov.Table.CurrentRecord.SetValue("action", "activo")
                If k.bonificacion = "S" Then
                    Me.dgvMov.Table.CurrentRecord.SetValue("bonificacion", "SI")
                Else
                    Me.dgvMov.Table.CurrentRecord.SetValue("bonificacion", "NO")
                End If

                Me.dgvMov.Table.CurrentRecord.SetValue("dineroDev", i.MontoPagadoSoles - detalle.DineroDevuelto)
                Me.dgvMov.Table.CurrentRecord.SetValue("dineroDevme", i.MontoPagadoUSD - detalle.DineroDevueltome)

                Me.dgvMov.Table.AddNewRecord.EndEdit()

            Next
            TotalTalesXcolumna()
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub


    'Public Sub UbicarDetalleByItem(intSecuenciaItem As Integer, intIdDocumento As Integer)
    '    Dim detalleSA As New DocumentoCompraDetalleSA
    '    Dim objLista As New DocumentoCajaDetalleSA
    '    Dim detalle As New documentocompradetalle
    '    Dim compraSA As New DocumentoCompraSA
    '    Dim entidadSA As New entidadSA
    '    Dim dt As New DataTable

    '    Dim cTotalmn As Decimal = 0
    '    Dim cTotalme As Decimal = 0
    '    Dim cTotalActmn As Decimal = 0
    '    Dim cTotalActme As Decimal = 0
    '    Dim cCreditomn As Decimal = 0
    '    Dim cCreditome As Decimal = 0
    '    Dim cDebitomn As Decimal = 0
    '    Dim cDebitome As Decimal = 0

    '    Dim cCantidadNC As Decimal = 0
    '    Dim cCantidadDB As Decimal = 0
    '    Dim cTotalCantidad As Decimal = 0
    '    Dim saldoCantidad As Decimal = 0
    '    TipoDocGobal = String.Empty
    '    Try
    '        With compraSA.UbicarDocumentoCompra(intIdDocumento)
    '            IdCompraOrigen = .idDocumento
    '            TipoDocGobal = .tipoDoc
    '            txtTipoDoc.Tag = .tipoCompra
    '            If .monedaDoc = "1" Then
    '                txtMon.Text = "1"
    '                MostrarColumnsByMoneda("1")

    '            ElseIf .monedaDoc = "2" Then
    '                txtMon.Text = "2"
    '                MostrarColumnsByMoneda("2")
    '            End If


    '            txtTipoCambio.Text = .tcDolLoc
    '            txtTipoCambio.ReadOnly = True
    '            txtIva.Text = .tasaIgv
    '            txtImpFacmn.DecimalValue = .importeTotal
    '            txtImpFacme.DecimalValue = .importeUS


    '            Dim tablaSA As New tablaDetalleSA

    '            txtTipoDoc.Text = tablaSA.GetUbicarTablaID(CInt(10), .tipoDoc).descripcion


    '            TextBoxExt4.Text = .serie
    '            TextBoxExt3.Text = .numeroDoc

    '        End With

    '        Dim saldomn As Decimal = 0
    '        Dim saldome As Decimal = 0


    '        Dim i As New documentoCajaDetalle

    '        i = objLista.ObtenerCuentasPorPagarBySecuencia(intSecuenciaItem)

    '        detalle = detalleSA.SumaNotasXidPadreItemOpcionDefault(intSecuenciaItem)
    '        'detalle = detalleSA.SumaNotasXidPadreItemOpcionDefault(intSecuenciaItem)

    '        saldoCantidad = i.CantidadCompra - detalle.monto1
    '        cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN - detalle.montoCompesacion
    '        cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS - CDec(i.MontoPagadoUSD) + detalle.ImporteDBME - detalle.montoCompesacionme
    '        cTotalActmn = CDec(i.MontoDeudaSoles) - detalle.importe + detalle.ImporteDBMN
    '        cTotalActme = CDec(i.MontoDeudaUSD) - detalle.importeUS + detalle.ImporteDBME

    '        'detalle.montoCompesacion

    '        saldomn += cTotalmn
    '        saldome += cTotalme

    '        saldomn += cTotalmn
    '        saldome += cTotalme


    '        Me.dgvMov.Table.AddNewRecord.SetCurrent()
    '        Me.dgvMov.Table.AddNewRecord.BeginEdit()
    '        Me.dgvMov.Table.CurrentRecord.SetValue("sec", i.secuencia)
    '        Me.dgvMov.Table.CurrentRecord.SetValue("grav", i.destino)
    '        Me.dgvMov.Table.CurrentRecord.SetValue("idItem", i.idItem)
    '        Me.dgvMov.Table.CurrentRecord.SetValue("item", i.DetalleItem)
    '        Select Case i.TipoExistencia
    '            Case "GS"
    '                Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
    '            Case Else
    '                If IsNothing(detalle) Then
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
    '                Else
    '                    Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", i.CantidadCompra - detalle.monto1)
    '                End If
    '        End Select




    '        Me.dgvMov.Table.CurrentRecord.SetValue("kardexAct", i.montokardex - detalle.montokardex + detalle.montokardexDB)
    '        Me.dgvMov.Table.CurrentRecord.SetValue("kardexActME", i.montokardexus - detalle.montokardexUS + detalle.montokardexDBUS)



    '        Me.dgvMov.Table.CurrentRecord.SetValue("precMN", 0)

    '        If cTotalmn < 0 Then
    '            cTotalmn = 0
    '        End If
    '        Me.dgvMov.Table.CurrentRecord.SetValue("importeMN", cTotalmn)
    '        Me.dgvMov.Table.CurrentRecord.SetValue("impActMN", cTotalActmn)
    '        Me.dgvMov.Table.CurrentRecord.SetValue("precME", 0)

    '        If cTotalme < 0 Then
    '            cTotalme = 0
    '        End If
    '        Me.dgvMov.Table.CurrentRecord.SetValue("importeME", cTotalme)
    '        Me.dgvMov.Table.CurrentRecord.SetValue("impActME", cTotalActme)

    '        Me.dgvMov.Table.CurrentRecord.SetValue("tipoEx", i.TipoExistencia)
    '        Me.dgvMov.Table.CurrentRecord.SetValue("almacenRef", i.almacenRef)

    '        Me.dgvMov.Table.CurrentRecord.SetValue("cantCompra", i.CantidadCompra)
    '        Me.dgvMov.Table.CurrentRecord.SetValue("compraMN", i.MontoDeudaSoles)
    '        Me.dgvMov.Table.CurrentRecord.SetValue("compraME", i.MontoDeudaUSD)
    '        Me.dgvMov.Table.CurrentRecord.SetValue("montokardex", i.montokardex)
    '        Me.dgvMov.Table.CurrentRecord.SetValue("montokardexus", i.montokardexus)
    '        Me.dgvMov.Table.CurrentRecord.SetValue("montoIgv", i.montoIgv)
    '        Me.dgvMov.Table.CurrentRecord.SetValue("montoIgvUS", i.montoIgvUS)

    '        Select Case dgvCompra.Table.CurrentRecord.GetValue("tipoCompra")
    '            Case TIPO_COMPRA.COMPRA_SERVICIO_PUBLICO, TIPO_COMPRA.COMPRA_RECIBO_HONORARIOS
    '                Me.dgvMov.Table.CurrentRecord.SetValue("cboMov", "2")
    '            Case Else
    '                Dim tex = dgvCompraDetalle.Table.CurrentRecord.GetValue("tipoexistencia")
    '                Select Case tex
    '                    Case "GS"
    '                        Me.dgvMov.Table.CurrentRecord.SetValue("cboMov", "2")
    '                    Case Else
    '                        Me.dgvMov.Table.CurrentRecord.SetValue("cboMov", "3")
    '                End Select
    '        End Select

    '        Me.dgvMov.Table.CurrentRecord.SetValue("canDev", 0)
    '        Me.dgvMov.Table.CurrentRecord.SetValue("canSaldo", 0)

    '        Me.dgvMov.Table.CurrentRecord.SetValue("vcmn", 0)
    '        Me.dgvMov.Table.CurrentRecord.SetValue("vcme", 0)
    '        Me.dgvMov.Table.CurrentRecord.SetValue("ivamn", 0)
    '        Me.dgvMov.Table.CurrentRecord.SetValue("ivame", 0)
    '        Me.dgvMov.Table.CurrentRecord.SetValue("totalmn", 0)
    '        Me.dgvMov.Table.CurrentRecord.SetValue("totalme", 0)

    '        Me.dgvMov.Table.CurrentRecord.SetValue("pumn", 0)
    '        Me.dgvMov.Table.CurrentRecord.SetValue("pume", 0)


    '        'If detalle.montoCompesacion > 0 Then
    '        '    Me.dgvMov.Table.CurrentRecord.SetValue("estadoPago", "Compensado")
    '        'Else

    '        Select Case i.EstadoCobro
    '            Case TIPO_COMPRA.PAGO.PAGADO
    '                Me.dgvMov.Table.CurrentRecord.SetValue("estadoPago", "Pagado")
    '            Case Else
    '                Me.dgvMov.Table.CurrentRecord.SetValue("estadoPago", "Pendiente")
    '        End Select
    '        'End If

    '        Me.dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
    '        Me.dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
    '        Me.dgvMov.Table.CurrentRecord.SetValue("action", "activo")
    '        Me.dgvMov.Table.AddNewRecord.EndEdit()


    '    Catch ex As Exception
    '        lblEstado.Text = ex.Message
    '        PanelError.Visible = True
    '        Timer1.Enabled = True
    '        TiempoEjecutar(10)
    '    End Try
    'End Sub


    Sub ConfiguracionInicio()

        ''configurando docking manager
        'Me.WindowState = FormWindowState.Maximized
        'dockingManager1.DockControlInAutoHideMode(Panel8, DockingStyle.Right, 565)
        'dockingManager1.SetDockLabel(Panel8, "Compras")
        'dockingManager1.CloseEnabled = False
        ''If Not IsNothing(GFichaUsuarios) Then
        'ToolStripButton1.Image = ImageListAdv1.Images(1)
        ''Else
        ''    ToolStripButton1.Image = ImageListAdv1.Images(0)
        ''    GFichaUsuarios = Nothing
        ''End If
        'dgvCompra.ShowRowHeaders = False
        ''confgiurando variables generales
        '' lblPerido.Text = lblPerido.Text 
        'txtPeriodoCompras.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
        'txtFecha.Value = New Date(CInt(AnioGeneral), CInt(MesGeneral), DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        'txtFecha.Select()
        Me.WindowState = FormWindowState.Normal

        txtFecha.Value = New Date(CInt(AnioGeneral), CInt(MesGeneral), DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        txtFecha.Select()
    End Sub


    Public Sub CargarEntidadesXtipo(strTipo As String, strBusqueda As String)
        Dim entidadSA As New entidadSA
        Try

            'Me.lstEntidades.DataSource = entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, strTipo, strBusqueda)
            'Me.lstEntidades.DisplayMember = "nombreCompleto"
            'Me.lstEntidades.ValueMember = "idEntidad"
            lsvProveedor.Items.Clear()
            For Each i As entidad In entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.PROVEEDOR, strBusqueda)
                Dim n As New ListViewItem(i.idEntidad)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(i.cuentaAsiento)
                n.SubItems.Add(i.nrodoc)
                lsvProveedor.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub


    'Private Sub UbicarCompraDetalle(idDocumento As Integer)
    '    Dim documentoCompraSA As New DocumentoCompraDetalleSA
    '    Dim documentoCompra As New List(Of documentocompradetalle)
    '    Dim tablaSA As New tablaDetalleSA
    '    Dim dt As New DataTable
    '    dt.Columns.Add("idItem", GetType(Integer))
    '    dt.Columns.Add("descripcion", GetType(String))
    '    dt.Columns.Add("tipoexistencia", GetType(String))
    '    dt.Columns.Add("unidad", GetType(String))

    '    dt.Columns.Add("monto", GetType(Decimal))
    '    dt.Columns.Add("pumn", GetType(Decimal))
    '    dt.Columns.Add("pume", GetType(Decimal))
    '    dt.Columns.Add("importemn", GetType(Decimal))
    '    dt.Columns.Add("importeme", GetType(Decimal))
    '    dt.Columns.Add("secuencia")

    '    documentoCompra = documentoCompraSA.UbicarDocumentoCompraDetalle(idDocumento)

    '    If Not IsNothing(documentoCompra) Then
    '        For Each i In documentoCompra
    '            Dim dr As DataRow = dt.NewRow()
    '            dr(0) = i.idItem
    '            dr(1) = i.descripcionItem
    '            dr(2) = i.tipoExistencia
    '            dr(3) = i.unidad1
    '            dr(4) = i.monto1
    '            dr(5) = i.precioUnitario
    '            dr(6) = i.precioUnitarioUS
    '            dr(7) = i.importe
    '            dr(8) = i.importeUS
    '            dr(9) = i.secuencia
    '            dt.Rows.Add(dr)
    '        Next
    '        dgvCompraDetalle.DataSource = dt

    '    Else

    '    End If
    'End Sub

    'Private Sub UbicarCompraXProveedorNroSerie(RucProveedor As String, strPeriodo As String)
    '    Dim documentoCompraSA As New DocumentoCompraSA
    '    Dim documentoCompra As New List(Of documentocompra)
    '    Dim tablaSA As New tablaDetalleSA
    '    Dim dt As New DataTable

    '    dt.Columns.Add("idDocumento", GetType(Integer))
    '    dt.Columns.Add("tipoCompra", GetType(String))
    '    dt.Columns.Add("Fecha", GetType(String))
    '    dt.Columns.Add("periodo", GetType(String))

    '    dt.Columns.Add("TipoDoc", GetType(String))
    '    dt.Columns.Add("Serie", GetType(String))
    '    dt.Columns.Add("Numero", GetType(String))
    '    dt.Columns.Add("moneda", GetType(String))
    '    dt.Columns.Add("montoMN", GetType(Decimal))
    '    dt.Columns.Add("montoME", GetType(Decimal))
    '    dt.Columns.Add("cuotas", GetType(Integer))

    '    documentoCompra = documentoCompraSA.UbicarCompraPorProveedorXperiodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, RucProveedor, strPeriodo)
    '    Dim str As String
    '    If Not IsNothing(documentoCompra) Then
    '        For Each i In documentoCompra
    '            Dim dr As DataRow = dt.NewRow()
    '            str = Nothing
    '            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
    '            dr(0) = i.idDocumento
    '            dr(1) = i.tipoCompra
    '            dr(2) = str
    '            dr(3) = i.fechaContable
    '            dr(4) = tablaSA.GetUbicarTablaID(10, i.tipoDoc).descripcion.Substring(0, 3)
    '            dr(5) = i.serie
    '            dr(6) = i.numeroDoc
    '            Select Case i.monedaDoc
    '                Case 1
    '                    dr(7) = "NAC"
    '                Case Else
    '                    dr(7) = "EXT"

    '            End Select
    '            dr(8) = i.importeTotal
    '            dr(9) = i.importeUS
    '            dr(10) = i.conteoCuotas
    '            dt.Rows.Add(dr)
    '        Next
    '        dgvCompra.DataSource = dt

    '    Else

    '    End If
    'End Sub
    Private Function comboTable() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("name")

        Dim dr As DataRow = dt.NewRow()
        dr(0) = "1"
        dr(1) = "DISMINUIR CANTIDAD"
        dt.Rows.Add(dr)

        Dim dr2 As DataRow = dt.NewRow()
        dr2(0) = "2"
        dr2(1) = "DISMINUIR IMPORTE"
        dt.Rows.Add(dr2)

        Dim dr3 As DataRow = dt.NewRow()
        dr3(0) = "3"
        dr3(1) = "DEVOLUCION DE EXISTENCIAS"
        dt.Rows.Add(dr3)

        Dim dr4 As DataRow = dt.NewRow()
        dr4(0) = "4"
        dr4(1) = "PRONTO PAGO - VOLUMEN DE COMPRA"
        dt.Rows.Add(dr4)

        Return dt
    End Function

#End Region

    'Private Sub ListaDefaultDeInicio()
    '    dockingManager1.DockControlInAutoHideMode(GroupBox2, Syncfusion.Windows.Forms.Tools.DockingStyle.Top, 65)
    '    Me.DockingClientPanel1.AutoScroll = True
    '    Me.DockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    '    dockingManager1.SetDockLabel(GroupBox2, "Entidad Financiera")
    '    dockingManager1.CloseEnabled = False
    'End Sub

    Private Sub frmCreditoCompra_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmCreditoCompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboDevolucion.Text = "PENDIENTE"
        Dim ggcStyle As GridTableCellStyleInfo = dgvMov.TableDescriptor.Columns(19).Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = Me.comboTable
        ggcStyle.ValueMember = "id"
        ggcStyle.DisplayMember = "name"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive
        dgvMov.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        '2017
    End Sub

    

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        If lsvProveedor.SelectedItems.Count > 0 Then
            Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub txtProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Me.popupControlContainer1.ParentControl = Me.txtProveedor
            Me.popupControlContainer1.ShowPopup(Point.Empty)
            CargarEntidadesXtipo(TIPO_ENTIDAD.PROVEEDOR, txtProveedor.Text.Trim)
        End If


    End Sub

    Private Sub txtProveedor_TextChanged(sender As Object, e As EventArgs) Handles txtProveedor.TextChanged

    End Sub

    Private Sub txtSerie_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSerie.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                txtNumero.Select()

                If txtSerie.Text.Trim.Length > 0 AndAlso txtProveedor.Text.Trim.Length > 0 Then
                    txtGlosa.Text = "Por el registro de la nota de crédito " & "del proveedor, " & txtProveedor.Text.Trim & "de fecha " & txtFecha.Value
                End If

            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtSerie.Clear()
        End Try
    End Sub

    Private Sub txtSerie_LostFocus(sender As Object, e As EventArgs) Handles txtSerie.LostFocus
        'Try
        '    If txtSerie.Text.Trim.Length > 0 Then
        '        '  If chFormato.Checked = True Then
        '        txtSerie.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerie.Text))
        '        'End If
        '    End If

        'Catch ex As Exception

        '    If IsNumeric(Microsoft.VisualBasic.Mid(Trim(txtSerie.Text), 2, 1)) = True Then

        '        If IsNumeric(Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 1)) = True Then

        '            If Not IsNumeric(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1)) = True Then

        '                If Len(txtSerie.Text) <= 2 Then

        '                    txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + "000" + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 1))

        '                ElseIf Len(txtSerie.Text) <= 3 Then

        '                    txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + "00" + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 2))

        '                ElseIf Len(txtSerie.Text) <= 4 Then

        '                    txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + "0" + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 3))

        '                ElseIf Len(txtSerie.Text) <= 5 Then

        '                    txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 4))

        '                End If
        '            End If
        '        Else

        '            txtSerie.Select()
        '            txtSerie.Focus()
        '            txtSerie.Clear()
        '            lblEstado.Text = "INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO"
        '            Timer1.Enabled = True
        '            PanelError.Visible = True
        '            TiempoEjecutar(10)

        '        End If

        '    Else

        '        txtSerie.Select()
        '        txtSerie.Focus()
        '        txtSerie.Clear()
        '        lblEstado.Text = "INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO"
        '        Timer1.Enabled = True
        '        PanelError.Visible = True
        '        TiempoEjecutar(10)
        '    End If

        'End Try
    End Sub

    Private Sub txtSerie_TextChanged(sender As Object, e As EventArgs) Handles txtSerie.TextChanged

    End Sub

    Private Sub dgvCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs)

    End Sub

   

    

    Private Sub dgvMov_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvMov.QueryCellStyleInfo
        '    If Not IsNothing(e.TableCellIdentity.Column) Then
        '        Dim el As Syncfusion.Grouping.Element = e.TableCellIdentity.DisplayElement

        '        If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "canDev")) Then

        'Dim str = Me.dgvMov.TableModel(e.TableCellIdentity.RowIndex, 16).CellValue
        'If Not IsNothing(str) Then
        '                Select Case str
        '                    Case "4" 'PRONTO PAGO - VOLUMEN DE COMPRA
        '                        e.Style.[ReadOnly] = True

        '                    Case "3" '  "DEVOLUCION DE EXISTENCIAS"
        '                        e.Style.[ReadOnly] = False
        '                        ''e.Style.BackColor = Color.AliceBlue
        '                        '        Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 15).CellValue = Nothing
        '                    Case "1" ' "DISMINUIR CANTIDAD"
        '                        e.Style.[ReadOnly] = False
        '                        'e.Style.BackColor = Color.AliceBlue

        '                    Case "2" '"DISMINUIR IMPORTE"
        '                        e.Style.[ReadOnly] = True
        '                        'e.Style.BackColor = Color.AliceBlue
        '                End Select
        '            End If


        '        ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "vcmn")) Then
        'Dim str = Me.dgvMov.TableModel(e.TableCellIdentity.RowIndex, 16).CellValue
        'If Not IsNothing(str) Then
        '                Select Case str
        '                    Case "3" '  "DEVOLUCION DE EXISTENCIAS"
        '                        e.Style.[ReadOnly] = False
        '                        'e.Style.BackColor = Color.AliceBlue
        '                        '        Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 15).CellValue = Nothing
        '                    Case "1" ' "DISMINUIR CANTIDAD"
        '                        e.Style.[ReadOnly] = True
        '                        'e.Style.BackColor = Color.AliceBlue

        '                    Case "2" '"DISMINUIR IMPORTE"
        '                        e.Style.[ReadOnly] = False
        '                        'e.Style.BackColor = Color.AliceBlue

        '                    Case "4" 'PRONTO PAGO - VOLUMEN DE COMPRA
        '                        e.Style.[ReadOnly] = False
        '                End Select
        '            End If

        '        ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "cboMov")) Then
        'Dim str = Me.dgvMov.TableModel(e.TableCellIdentity.RowIndex, 30).CellValue
        'If Not IsNothing(str) Then
        '                If str = "GS" Then
        '                    e.Style.ReadOnly = True
        '                Else
        '                    e.Style.[ReadOnly] = False
        '                End If
        '            End If

        '        End If
        '    End If
    End Sub

    Sub Calculos()
        Dim cantidad As Decimal = 0
        Dim VC As Decimal = 0
        Dim VCme As Decimal = 0
        Dim Igv As Decimal = 0
        Dim IgvME As Decimal = 0
        Dim totalMN As Decimal = 0
        Dim colBI As Decimal = 0
        Dim colBIme As Decimal = 0
        Dim colPrecUnit As Decimal = 0
        Dim colPrecUnitme As Decimal = 0
        Dim colDestinoGravado As Decimal = 0
        Dim colBonifica As String = Nothing
        '****************************************************************
        'colBonifica = Me.dgvCompra.Table.CurrentRecord.GetValue("chBonif")
        colDestinoGravado = Me.dgvMov.Table.CurrentRecord.GetValue("grav")
        cantidad = Me.dgvMov.Table.CurrentRecord.GetValue("canDev")
        Me.dgvMov.Table.CurrentRecord.SetValue("canDev", cantidad.ToString("N2"))
        VC = Me.dgvMov.Table.CurrentRecord.GetValue("vcmn")
        VCme = Math.Round(VC / CDec(txtTipoCambio.Text), 2)
        If cantidad > 0 AndAlso VC > 0 Then
            Igv = Math.Round(VC * CDec(txtIva.Text), 2)
            IgvME = Math.Round(VCme * CDec(txtIva.Text), 2)

            colBI = VC + Igv
            colBIme = VCme + IgvME

            colPrecUnit = Math.Round(VC / cantidad, 2)
            colPrecUnitme = Math.Round(VCme / cantidad, 2)
        ElseIf cantidad = 0 Then
            Igv = Math.Round(VC * CDec(txtIva.Text), 2)
            IgvME = Math.Round(VCme * CDec(txtIva.Text), 2)
            colBI = VC + Igv
            colBIme = VCme + IgvME
            colPrecUnit = 0
            colPrecUnitme = 0
        Else
            colPrecUnit = 0
            colPrecUnitme = 0

            colBI = 0
            colBIme = 0
            Igv = 0
            IgvME = 0
        End If

        '  TipoDocGobal
        'Select Case TextBoxExt1.Tag
        Select Case TipoDocGobal
            Case "08"

            Case "03", "02"
                Me.dgvMov.Table.CurrentRecord.SetValue("vcmn", VC.ToString("N2"))
                Me.dgvMov.Table.CurrentRecord.SetValue("vcme", VCme.ToString("N2"))
                Me.dgvMov.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                Me.dgvMov.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
                Me.dgvMov.Table.CurrentRecord.SetValue("totalmn", VC.ToString("N2"))
                Me.dgvMov.Table.CurrentRecord.SetValue("totalme", VCme.ToString("N2"))
                Me.dgvMov.Table.CurrentRecord.SetValue("igvmn", 0)
                Me.dgvMov.Table.CurrentRecord.SetValue("igvme", 0)
            Case Else
                If txtMon.Text = 1 Then
                    ' DATOS SOLES

                    Select Case colDestinoGravado
                        Case "2", "3", "4"

                            Me.dgvMov.Table.CurrentRecord.SetValue("vcmn", VC.ToString("N2"))
                            Me.dgvMov.Table.CurrentRecord.SetValue("vcme", VCme.ToString("N2"))
                            Me.dgvMov.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                            Me.dgvMov.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
                            Me.dgvMov.Table.CurrentRecord.SetValue("totalmn", VC.ToString("N2"))
                            Me.dgvMov.Table.CurrentRecord.SetValue("totalme", VCme.ToString("N2"))
                            Me.dgvMov.Table.CurrentRecord.SetValue("ivamn", 0)
                            Me.dgvMov.Table.CurrentRecord.SetValue("ivame", 0)

                        Case Else
                            If Me.dgvMov.Table.CurrentRecord.GetValue("chBonif") = "1" Then ' BOnIFICACIOn
                                Me.dgvMov.Table.CurrentRecord.SetValue("vcmn", VC.ToString("N2"))
                                Me.dgvMov.Table.CurrentRecord.SetValue("vcme", VCme.ToString("N2"))
                                Me.dgvMov.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                                Me.dgvMov.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
                                Me.dgvMov.Table.CurrentRecord.SetValue("totalmn", VC.ToString("N2"))
                                Me.dgvMov.Table.CurrentRecord.SetValue("totalme", VCme.ToString("N2"))
                                Me.dgvMov.Table.CurrentRecord.SetValue("ivamn", 0)
                                Me.dgvMov.Table.CurrentRecord.SetValue("ivame", 0)

                            Else
                                If cantidad > 0 Then

                                    Me.dgvMov.Table.CurrentRecord.SetValue("vcmn", VC.ToString("N2"))
                                    Me.dgvMov.Table.CurrentRecord.SetValue("vcme", VCme.ToString("N2"))
                                    Me.dgvMov.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                                    Me.dgvMov.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
                                    Me.dgvMov.Table.CurrentRecord.SetValue("totalmn", colBI.ToString("N2"))
                                    Me.dgvMov.Table.CurrentRecord.SetValue("totalme", colBIme.ToString("N2"))
                                    Me.dgvMov.Table.CurrentRecord.SetValue("ivamn", Igv.ToString("N2"))
                                    Me.dgvMov.Table.CurrentRecord.SetValue("ivame", IgvME.ToString("N2"))

                                Else

                                    Me.dgvMov.Table.CurrentRecord.SetValue("vcmn", VC.ToString("N2"))
                                    Me.dgvMov.Table.CurrentRecord.SetValue("vcme", VCme.ToString("N2"))
                                    Me.dgvMov.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
                                    Me.dgvMov.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
                                    Me.dgvMov.Table.CurrentRecord.SetValue("totalmn", colBI.ToString("N2"))
                                    Me.dgvMov.Table.CurrentRecord.SetValue("totalme", colBIme.ToString("N2"))
                                    Me.dgvMov.Table.CurrentRecord.SetValue("ivamn", Igv.ToString("N2"))
                                    Me.dgvMov.Table.CurrentRecord.SetValue("ivame", IgvME.ToString("N2"))

                                End If

                            End If
                    End Select

                ElseIf txtMon.Text = 2 Then

                    Select Case colDestinoGravado
                        Case "4"

                        Case Else


                    End Select

                End If
        End Select
        TotalTalesXcolumna()
    End Sub
    Private Sub dgvMov_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvMov.TableControlCurrentCellEditingComplete
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'Try
        '    If Not IsNothing(Me.dgvMov.Table.CurrentRecord) Then
        '        Select Case ColIndex
        '            'Case 11
        '            Case 16
        '                Select Case dgvMov.Table.CurrentRecord.GetValue("cboMov")
        '                    Case "1"

        '                        'Dim f As New frmNotaValidaAlmacen(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc,
        '                        '                                                           .idEstablecimiento = GEstableciento.IdEstablecimiento,
        '                        '                                                           .idItem = Val(dgvMov.Table.CurrentRecord.GetValue("idItem")),
        '                        '                                                           .cantidad = CDec(dgvMov.Table.CurrentRecord.GetValue("cantCompra")),
        '                        '                                                           .importeSoles = CDec(dgvMov.Table.CurrentRecord.GetValue("montokardex")),
        '                        '                                                           .importeDolares = CDec(dgvMov.Table.CurrentRecord.GetValue("montokardexus"))})

        '                        'f.StartPosition = FormStartPosition.CenterParent
        '                        'f.ShowDialog()

        '                        'If Not IsNothing(f.Tag) Then
        '                        Dim cantidadOrigen As Decimal = 0
        '                        cantidadOrigen = dgvMov.Table.CurrentRecord.GetValue("cantidad")
        '                        If cantidadOrigen <= 0 Then
        '                            dgvMov.Table.CurrentRecord.SetValue("cboMov", String.Empty)
        '                            Throw New Exception("Esta opción no esta disponible elija otra!")
        '                        End If


        '                        'Else
        '                        'Throw New Exception("No se puede realizar la transacción")
        '                        'End If

        '                    Case "2", "4"
        '                        dgvMov.Table.CurrentRecord.SetValue("canDev", 0)
        '                    Case "3"
        '                        Dim cantidadOrigen As Decimal = 0
        '                        cantidadOrigen = dgvMov.Table.CurrentRecord.GetValue("cantidad")
        '                        If cantidadOrigen <= 0 Then
        '                            dgvMov.Table.CurrentRecord.SetValue("cboMov", String.Empty)
        '                            Throw New Exception("Esta opción no esta disponible elija otra!")
        '                        End If
        '                End Select

        '                Calculos()
        '                'Case 12
        '            Case 17
        '                Dim cantidad As Decimal = 0
        '                Dim canSaldo As Decimal = 0
        '                Dim cantidadOrigen As Decimal = 0

        '                cantidadOrigen = dgvMov.Table.CurrentRecord.GetValue("cantidad")
        '                If cantidadOrigen <= 0 Then
        '                    dgvMov.Table.CurrentRecord.SetValue("canDev", 0)
        '                    Throw New Exception("El valor de la cantidad no esta disponible")
        '                End If

        '                If CDec(dgvMov.Table.CurrentRecord.GetValue("canDev")) > cantidadOrigen Then
        '                    dgvMov.Table.CurrentRecord.SetValue("canDev", 0)
        '                    Throw New Exception("El valor de la cantidad excede al monto original")
        '                End If

        '                If dgvMov.Table.CurrentRecord.GetValue("tipoEx") <> TipoRecurso.SERVICIO Then
        '                    If CDec(dgvMov.Table.CurrentRecord.GetValue("canDev")) > 0 Then
        '                        getStockAlmacenes(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc,
        '                                                                                       .idEstablecimiento = GEstableciento.IdEstablecimiento,
        '                                                                                       .idItem = Val(dgvMov.Table.CurrentRecord.GetValue("idItem")),
        '                                                                                       .cantidad = CDec(dgvMov.Table.CurrentRecord.GetValue("canDev")),
        '                                                                                       .importeSoles = CDec(dgvMov.Table.CurrentRecord.GetValue("vcmn")),
        '                                                                                       .importeDolares = CDec(dgvMov.Table.CurrentRecord.GetValue("vcme"))})

        '                        PanelStock.Visible = True
        '                        '        DockingClientPanel1.Enabled = False
        '                    End If
        '                Else

        '                End If


        '                'cantidad = CDec(dgvMov.Table.CurrentRecord.GetValue("cantCompra"))
        '                'canSaldo = cantidad - CDec(dgvMov.Table.CurrentRecord.GetValue("canDev"))
        '                'dgvMov.Table.CurrentRecord.SetValue("canSaldo", canSaldo)
        '                'Calculos()



        '                'Else
        '                'Throw New Exception("No puede realizar esta transacción!")
        '                'End If
        '                'dgvMov.Table.CurrentRecord.SetValue("almacenRef", obj.idAlmacen)

        '                ' Case 13
        '            Case 18

        '                If dgvMov.Table.CurrentRecord.GetValue("bonificacion") = "NO" Then
        '                    Calculos()
        '                    Select Case dgvMov.Table.CurrentRecord.GetValue("estadoPago")
        '                        Case "Pagado"
        '                            Dim saldoFinalmn As Decimal = 0
        '                            Dim saldoFinalme As Decimal = 0

        '                            Dim saldoCompramn As Decimal = 0
        '                            Dim saldoComprame As Decimal = 0
        '                            Dim valAbonomn As Decimal = 0
        '                            Dim valAbonome As Decimal = 0
        '                            Dim ventaOriginalMN As Decimal = 0
        '                            Dim ventaOriginalME As Decimal = 0

        '                            ventaOriginalMN = CDec(dgvMov.Table.CurrentRecord.GetValue("compraMN"))
        '                            ventaOriginalME = CDec(dgvMov.Table.CurrentRecord.GetValue("compraME"))

        '                            'saldoCompramn = CDec(dgvMov.Table.CurrentRecord.GetValue("importeMN"))
        '                            'saldoComprame = CDec(dgvMov.Table.CurrentRecord.GetValue("importeME"))
        '                            saldoCompramn = CDec(dgvMov.Table.CurrentRecord.GetValue("impActMN"))
        '                            saldoComprame = CDec(dgvMov.Table.CurrentRecord.GetValue("impActME"))

        '                            If saldoCompramn = 0 Then
        '                                dgvMov.Table.CurrentRecord.SetValue("vcmn", 0)
        '                                dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
        '                                dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
        '                                dgvMov.Table.CurrentRecord.SetValue("action", "inactivo")
        '                                Calculos()
        '                                Throw New Exception("El importe de la nota supera al importe de compra, " & saldoCompramn.ToString("N2"))
        '                            End If

        '                            valAbonomn = dgvMov.Table.CurrentRecord.GetValue("totalmn")
        '                            valAbonome = dgvMov.Table.CurrentRecord.GetValue("totalme")

        '                            saldoFinalmn = ventaOriginalMN - valAbonomn
        '                            saldoFinalme = ventaOriginalME - valAbonome


        '                            If saldoCompramn < valAbonomn Then
        '                                dgvMov.Table.CurrentRecord.SetValue("vcmn", 0)
        '                                dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
        '                                dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
        '                                dgvMov.Table.CurrentRecord.SetValue("action", "inactivo")
        '                                Calculos()
        '                                Throw New Exception("El importe de la nota supera al importe de compra, " & saldoCompramn.ToString("N2"))
        '                            End If



        '                            'If saldoFinalmn < 0 Then
        '                            If saldoCompramn < 0 Then
        '                                dgvMov.Table.CurrentRecord.SetValue("vcmn", 0)
        '                                dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
        '                                dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
        '                                dgvMov.Table.CurrentRecord.SetValue("action", "inactivo")
        '                                Calculos()
        '                                Throw New Exception("El monto ingresado supera al valor original del artículo!")

        '                                'ElseIf saldoFinalmn >= 0 Then
        '                            ElseIf saldoCompramn > 0 Then
        '                                Select Case dgvMov.Table.CurrentRecord.GetValue("cboMov")
        '                                    Case "4"
        '                                        dgvMov.Table.CurrentRecord.SetValue("ValDevmn", valAbonomn)
        '                                        dgvMov.Table.CurrentRecord.SetValue("ValDevme", valAbonome)
        '                                        dgvMov.Table.CurrentRecord.SetValue("action", "activo")

        '                                    Case Else
        '                                        If dgvMov.Table.CurrentRecord.GetValue("tipoEx") <> TipoRecurso.SERVICIO Then
        '                                            If CDec(dgvMov.Table.CurrentRecord.GetValue("vcmn")) > 0 Then
        '                                                getStockAlmacenes(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc,
        '                                                                                              .idEstablecimiento = GEstableciento.IdEstablecimiento,
        '                                                                                              .idItem = Val(dgvMov.Table.CurrentRecord.GetValue("idItem")),
        '                                                                                              .cantidad = CDec(dgvMov.Table.CurrentRecord.GetValue("canDev")),
        '                                                                                              .importeSoles = CDec(dgvMov.Table.CurrentRecord.GetValue("vcmn")),
        '                                                                                              .importeDolares = CDec(dgvMov.Table.CurrentRecord.GetValue("vcme"))})

        '                                                PanelStock.Visible = True
        '                                                '    DockingClientPanel1.Enabled = False
        '                                            End If

        '                                        Else

        '                                            dgvMov.Table.CurrentRecord.SetValue("ValDevmn", valAbonomn)
        '                                            dgvMov.Table.CurrentRecord.SetValue("ValDevme", valAbonome)
        '                                            dgvMov.Table.CurrentRecord.SetValue("action", "activo")
        '                                        End If
        '                                End Select




        '                                Calculos()
        '                                'dgvMov.Table.CurrentRecord.SetValue("ValDevmn", valAbonomn)
        '                                'dgvMov.Table.CurrentRecord.SetValue("ValDevme", valAbonome)
        '                                'dgvMov.Table.CurrentRecord.SetValue("action", "activo")
        '                            End If

        '                        Case Else

        '                            Dim saldoFinalmn As Decimal = 0
        '                            Dim saldoFinalme As Decimal = 0
        '                            Dim ventaOriginalMN As Decimal = 0
        '                            Dim ventaOriginalME As Decimal = 0

        '                            Dim saldoCompramn As Decimal = 0
        '                            Dim saldoComprame As Decimal = 0
        '                            Dim valAbonomn As Decimal = 0
        '                            Dim valAbonome As Decimal = 0



        '                            ventaOriginalMN = CDec(dgvMov.Table.CurrentRecord.GetValue("compraMN"))
        '                            ventaOriginalME = CDec(dgvMov.Table.CurrentRecord.GetValue("compraME"))

        '                            'saldoCompramn = CDec(dgvMov.Table.CurrentRecord.GetValue("importeMN"))
        '                            'saldoComprame = CDec(dgvMov.Table.CurrentRecord.GetValue("importeME"))
        '                            saldoCompramn = CDec(dgvMov.Table.CurrentRecord.GetValue("impActMN"))
        '                            saldoComprame = CDec(dgvMov.Table.CurrentRecord.GetValue("impActME"))

        '                            valAbonomn = dgvMov.Table.CurrentRecord.GetValue("totalmn")
        '                            valAbonome = dgvMov.Table.CurrentRecord.GetValue("totalme")


        '                            If saldoCompramn <= 0 Then
        '                                dgvMov.Table.CurrentRecord.SetValue("vcmn", 0)
        '                                dgvMov.Table.CurrentRecord.SetValue("vcme", 0)
        '                                dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
        '                                dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
        '                                Calculos()
        '                                Throw New Exception("El Comprobante no esta disponible")
        '                            End If

        '                            'If valAbonomn > ventaOriginalMN Then
        '                            If valAbonomn > saldoCompramn Then
        '                                dgvMov.Table.CurrentRecord.SetValue("vcmn", 0)
        '                                dgvMov.Table.CurrentRecord.SetValue("vcme", 0)
        '                                dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
        '                                dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
        '                                Calculos()
        '                                'Throw New Exception("El importe de la nota supera al importe de compra, " & ventaOriginalMN.ToString("N2"))
        '                                Throw New Exception("El importe de la nota supera al importe de compra, " & saldoCompramn.ToString("N2"))
        '                            End If

        '                            Select Case dgvMov.Table.CurrentRecord.GetValue("cboMov")
        '                                Case "4"
        '                                    saldoFinalmn = saldoCompramn - valAbonomn
        '                                    saldoFinalme = saldoComprame - valAbonome

        '                                    If saldoFinalmn < 0 Then
        '                                        dgvMov.Table.CurrentRecord.SetValue("ValDevmn", saldoFinalmn * -1)
        '                                        dgvMov.Table.CurrentRecord.SetValue("ValDevme", saldoFinalme * -1)
        '                                        dgvMov.Table.CurrentRecord.SetValue("action", "activo")
        '                                    Else
        '                                        dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
        '                                        dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
        '                                        dgvMov.Table.CurrentRecord.SetValue("action", "inactivo")
        '                                    End If
        '                                    Calculos()


        '                                Case Else
        '                                    If dgvMov.Table.CurrentRecord.GetValue("tipoEx") <> TipoRecurso.SERVICIO Then
        '                                        If CDec(dgvMov.Table.CurrentRecord.GetValue("vcmn")) > 0 Then
        '                                            getStockAlmacenes(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc,
        '                                                                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
        '                                                                                          .idItem = Val(dgvMov.Table.CurrentRecord.GetValue("idItem")),
        '                                                                                          .cantidad = CDec(dgvMov.Table.CurrentRecord.GetValue("canDev")),
        '                                                                                          .importeSoles = CDec(dgvMov.Table.CurrentRecord.GetValue("vcmn")),
        '                                                                                          .importeDolares = CDec(dgvMov.Table.CurrentRecord.GetValue("vcme"))})

        '                                            PanelStock.Visible = True
        '                                            '   DockingClientPanel1.Enabled = False
        '                                        End If

        '                                    Else
        '                                        saldoFinalmn = saldoCompramn - valAbonomn
        '                                        saldoFinalme = saldoComprame - valAbonome

        '                                        If saldoFinalmn < 0 Then
        '                                            dgvMov.Table.CurrentRecord.SetValue("ValDevmn", saldoFinalmn * -1)
        '                                            dgvMov.Table.CurrentRecord.SetValue("ValDevme", saldoFinalme * -1)
        '                                            dgvMov.Table.CurrentRecord.SetValue("action", "activo")
        '                                        Else
        '                                            dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
        '                                            dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
        '                                            dgvMov.Table.CurrentRecord.SetValue("action", "inactivo")
        '                                        End If
        '                                        Calculos()
        '                                    End If

        '                            End Select





        '                    End Select

        '                Else

        '                    ''345345


        '                    ''436



        '                    If CDec(dgvMov.Table.CurrentRecord.GetValue("impActMN")) >= dgvMov.Table.CurrentRecord.GetValue("vcmn") Then


        '                        Dim saldoFinalmn As Decimal = 0
        '                        Dim saldoFinalme As Decimal = 0
        '                        Dim ventaOriginalMN As Decimal = 0
        '                        Dim ventaOriginalME As Decimal = 0

        '                        Dim saldoCompramn As Decimal = 0
        '                        Dim saldoComprame As Decimal = 0
        '                        Dim valAbonomn As Decimal = 0
        '                        Dim valAbonome As Decimal = 0



        '                        ventaOriginalMN = CDec(dgvMov.Table.CurrentRecord.GetValue("compraMN"))
        '                        ventaOriginalME = CDec(dgvMov.Table.CurrentRecord.GetValue("compraME"))

        '                        'saldoCompramn = CDec(dgvMov.Table.CurrentRecord.GetValue("importeMN"))
        '                        'saldoComprame = CDec(dgvMov.Table.CurrentRecord.GetValue("importeME"))
        '                        saldoCompramn = CDec(dgvMov.Table.CurrentRecord.GetValue("impActMN"))
        '                        saldoComprame = CDec(dgvMov.Table.CurrentRecord.GetValue("impActME"))

        '                        valAbonomn = dgvMov.Table.CurrentRecord.GetValue("totalmn")
        '                        valAbonome = dgvMov.Table.CurrentRecord.GetValue("totalme")


        '                        If saldoCompramn <= 0 Then
        '                            dgvMov.Table.CurrentRecord.SetValue("vcmn", 0)
        '                            dgvMov.Table.CurrentRecord.SetValue("vcme", 0)
        '                            dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
        '                            dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
        '                            Calculos()
        '                            Throw New Exception("El Comprobante no esta disponible")
        '                        End If

        '                        'If valAbonomn > ventaOriginalMN Then
        '                        If valAbonomn > saldoCompramn Then
        '                            dgvMov.Table.CurrentRecord.SetValue("vcmn", 0)
        '                            dgvMov.Table.CurrentRecord.SetValue("vcme", 0)
        '                            dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
        '                            dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
        '                            Calculos()
        '                            'Throw New Exception("El importe de la nota supera al importe de compra, " & ventaOriginalMN.ToString("N2"))
        '                            Throw New Exception("El importe de la nota supera al importe de compra, " & saldoCompramn.ToString("N2"))
        '                        End If

        '                        Select Case dgvMov.Table.CurrentRecord.GetValue("cboMov")
        '                            Case "4"
        '                                saldoFinalmn = saldoCompramn - valAbonomn
        '                                saldoFinalme = saldoComprame - valAbonome

        '                                If saldoFinalmn < 0 Then
        '                                    dgvMov.Table.CurrentRecord.SetValue("ValDevmn", saldoFinalmn * -1)
        '                                    dgvMov.Table.CurrentRecord.SetValue("ValDevme", saldoFinalme * -1)
        '                                    dgvMov.Table.CurrentRecord.SetValue("action", "activo")
        '                                Else
        '                                    dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
        '                                    dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
        '                                    dgvMov.Table.CurrentRecord.SetValue("action", "inactivo")
        '                                End If
        '                                'Calculos()


        '                            Case Else
        '                                If dgvMov.Table.CurrentRecord.GetValue("tipoEx") <> TipoRecurso.SERVICIO Then
        '                                    If CDec(dgvMov.Table.CurrentRecord.GetValue("vcmn")) > 0 Then
        '                                        getStockAlmacenes(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc,
        '                                                                                      .idEstablecimiento = GEstableciento.IdEstablecimiento,
        '                                                                                      .idItem = Val(dgvMov.Table.CurrentRecord.GetValue("idItem")),
        '                                                                                      .cantidad = CDec(dgvMov.Table.CurrentRecord.GetValue("canDev")),
        '                                                                                      .importeSoles = CDec(dgvMov.Table.CurrentRecord.GetValue("vcmn")),
        '                                                                                      .importeDolares = CDec(dgvMov.Table.CurrentRecord.GetValue("vcme"))})

        '                                        PanelStock.Visible = True
        '                                        '   DockingClientPanel1.Enabled = False
        '                                    End If

        '                                Else
        '                                    saldoFinalmn = saldoCompramn - valAbonomn
        '                                    saldoFinalme = saldoComprame - valAbonome

        '                                    If saldoFinalmn < 0 Then
        '                                        dgvMov.Table.CurrentRecord.SetValue("ValDevmn", saldoFinalmn * -1)
        '                                        dgvMov.Table.CurrentRecord.SetValue("ValDevme", saldoFinalme * -1)
        '                                        dgvMov.Table.CurrentRecord.SetValue("action", "activo")
        '                                    Else
        '                                        dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
        '                                        dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
        '                                        dgvMov.Table.CurrentRecord.SetValue("action", "inactivo")
        '                                    End If
        '                                    'Calculos()
        '                                End If

        '                        End Select





        '                    Else
        '                        dgvMov.Table.CurrentRecord.SetValue("vcmn", 0)
        '                        dgvMov.Table.CurrentRecord.SetValue("vcme", 0)
        '                        dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
        '                        dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
        '                        Calculos()
        '                        'Throw New Exception("El importe de la nota supera al importe de compra, " & ventaOriginalMN.ToString("N2"))
        '                        'Throw New Exception("El importe de la nota supera al importe de compra, " & saldoCompramn.ToString("N2"))
        '                        Throw New Exception("El importe de la nota supera al importe de compra, ")
        '                    End If


        '                End If



        '                'End If


        '                ' Case 16
        '            Case 21
        '                'dgvMov.Table.CurrentRecord.SetValue("ValDevmn", CDec(dgvMov.Table.CurrentRecord.GetValue("totalmn")))
        '                'dgvMov.Table.CurrentRecord.SetValue("ValDevme", CDec(dgvMov.Table.CurrentRecord.GetValue("totalme")))

        '                TotalTalesXcolumna()

        '        End Select
        '    End If
        'Catch ex As Exception
        '    lblEstado.Text = ex.Message
        '    PanelError.Visible = True
        '    Timer1.Enabled = True
        '    TiempoEjecutar(10)
        'End Try
    End Sub

    Private Sub Panel9_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        Cursor = Cursors.WaitCursor
        Try
            If Not txtSerie.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingresar un número de serie válido"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)

                Me.Cursor = Cursors.Arrow
                Exit Sub
            Else
                lblEstado.Text = "Done serie"
            End If

            If Not txtNumero.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingresar un número de comprobante válido"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)

                Me.Cursor = Cursors.Arrow
                Exit Sub
            Else
                lblEstado.Text = "Done número comprobante"

            End If

            If Not txtProveedor.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingresar un proveedor válido"

                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)

                Me.Cursor = Cursors.Arrow
                Exit Sub
            Else
                lblEstado.Text = "Done proveedor"

            End If



            '***********************************************************************
            If dgvMov.Table.Records.Count > 0 Then
                Grabar()
            Else
                MessageBox.Show("Debe ingresar al menos un item a la canasta!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub txtNumero_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumero.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                'cboMoneda.Select()
                txtProveedor.Select()
                'txtProveedor.Focus()
                If txtSerie.Text.Trim.Length > 0 AndAlso txtProveedor.Text.Trim.Length > 0 Then
                    txtGlosa.Text = "Por el registro de la nota de crédito " & "del proveedor, " & txtProveedor.Text.Trim & "de fecha " & txtFecha.Value
                End If
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtNumero.Clear()
        End Try
    End Sub

    Private Sub txtNumero_LostFocus(sender As Object, e As EventArgs) Handles txtNumero.LostFocus
        'Try
        '    If txtNumero.Text.Trim.Length > 0 Then
        '        '    If chFormato.Checked = True Then
        '        txtNumero.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumero.Text))

        '        'End If
        '    End If
        'Catch ex As Exception
        '    'MessageBoxAdv.Show("Error de formato!", "Atención", Nothing, MessageBoxIcon.Error)
        '    txtNumero.Select()
        '    txtNumero.Focus()
        '    txtNumero.Clear()
        '    lblEstado.Text = "Error de formato verifiuqe el ingreso!"
        'End Try
    End Sub

    Private Sub txtSerieGuia_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSerieGuia.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                txtNumeroGuia.Select()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtSerieGuia.Clear()
        End Try
    End Sub

    Private Sub txtSerieGuia_LostFocus(sender As Object, e As EventArgs) Handles txtSerieGuia.LostFocus
        'Try
        '    If txtSerieGuia.Text.Trim.Length > 0 Then
        '        '  If chFormato.Checked = True Then
        '        txtSerieGuia.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerieGuia.Text))
        '        'End If
        '    End If

        'Catch ex As Exception

        '    If IsNumeric(Microsoft.VisualBasic.Mid(Trim(txtSerieGuia.Text), 2, 1)) = True Then

        '        If IsNumeric(Microsoft.VisualBasic.Right(Trim(txtSerieGuia.Text), 1)) = True Then

        '            If Not IsNumeric(Microsoft.VisualBasic.Left(Trim(txtSerieGuia.Text), 1)) = True Then

        '                If Len(txtSerieGuia.Text) <= 2 Then

        '                    txtSerieGuia.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerieGuia.Text), 1) + "000" + Microsoft.VisualBasic.Right(Trim(txtSerieGuia.Text), 1))

        '                ElseIf Len(txtSerieGuia.Text) <= 3 Then

        '                    txtSerieGuia.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerieGuia.Text), 1) + "00" + Microsoft.VisualBasic.Right(Trim(txtSerieGuia.Text), 2))

        '                ElseIf Len(txtSerieGuia.Text) <= 4 Then

        '                    txtSerieGuia.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerieGuia.Text), 1) + "0" + Microsoft.VisualBasic.Right(Trim(txtSerieGuia.Text), 3))

        '                ElseIf Len(txtSerieGuia.Text) <= 5 Then

        '                    txtSerieGuia.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerieGuia.Text), 1) + Microsoft.VisualBasic.Right(Trim(txtSerieGuia.Text), 4))

        '                End If
        '            End If
        '        Else

        '            txtSerieGuia.Select()
        '            txtSerieGuia.Focus()
        '            txtSerieGuia.Clear()
        '            lblEstado.Text = "INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO"
        '            Timer1.Enabled = True
        '            PanelError.Visible = True
        '            TiempoEjecutar(10)

        '        End If

        '    Else

        '        txtSerieGuia.Select()
        '        txtSerieGuia.Focus()
        '        txtSerieGuia.Clear()
        '        lblEstado.Text = "INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO"
        '        Timer1.Enabled = True
        '        PanelError.Visible = True
        '        TiempoEjecutar(10)
        '    End If

        'End Try
    End Sub

    Private Sub txtNumeroGuia_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumeroGuia.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                'cboMoneda.Select()
                txtSerieGuia.Select()
                'txtProveedor.Focus()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtNumeroGuia.Clear()
        End Try
    End Sub

    Private Sub txtNumeroGuia_LostFocus(sender As Object, e As EventArgs) Handles txtNumeroGuia.LostFocus
        'Try
        '    If txtNumeroGuia.Text.Trim.Length > 0 Then
        '        '    If chFormato.Checked = True Then
        '        txtNumeroGuia.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumeroGuia.Text))

        '        'End If
        '    End If
        'Catch ex As Exception
        '    'MessageBoxAdv.Show("Error de formato!", "Atención", Nothing, MessageBoxIcon.Error)
        '    txtNumeroGuia.Select()
        '    txtNumeroGuia.Focus()
        '    txtNumeroGuia.Clear()
        '    lblEstado.Text = "Error de formato verifique el ingreso!"
        'End Try
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If Not IsNothing(Me.dgvMov.Table.CurrentRecord) Then
            Me.dgvMov.Table.CurrentRecord.Delete()
            TotalTalesXcolumna()
        End If
    End Sub

 

    Private Sub dgvCompraDetalle_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs)

    End Sub

    

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        dgvMov.Table.CurrentRecord.SetValue("canDev", 0)
        dgvMov.Table.CurrentRecord.SetValue("vcmn", 0)
        dgvMov.Table.CurrentRecord.SetValue("vcme", 0)
        Calculos()
    End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs)
    '    Dim cantidad As Decimal = 0
    '    Dim canSaldo As Decimal = 0
    '    Dim cantidadOrigen As Decimal = 0

    '    If Not IsNothing(GridGroupingControl1.Table.CurrentRecord) Then
    '        Try
    '            Dim r As Record = GridGroupingControl1.Table.CurrentRecord


    '            Select Case dgvMov.Table.CurrentRecord.GetValue("cboMov")
    '                Case "1" ' DISMINUIR CANTIDAD

    '                    If Not CDec(dgvMov.Table.CurrentRecord.GetValue("canDev")) <= CDec(r.GetValue("cant")) Then
    '                        dgvMov.Table.CurrentRecord.SetValue("canDev", 0)
    '                        dgvMov.Table.CurrentRecord.SetValue("vcmn", 0)
    '                        dgvMov.Table.CurrentRecord.SetValue("ivamn", 0)
    '                        dgvMov.Table.CurrentRecord.SetValue("totalmn", 0)
    '                        dgvMov.Table.CurrentRecord.SetValue("vcme", 0)
    '                        dgvMov.Table.CurrentRecord.SetValue("ivame", 0)
    '                        dgvMov.Table.CurrentRecord.SetValue("totalme", 0)
    '                        dgvMov.Table.CurrentRecord.SetValue("pumn", 0)
    '                        dgvMov.Table.CurrentRecord.SetValue("pume", 0)
    '                        MessageBox.Show("No cuenta con stock disponible!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)


    '                    Else
    '                        cantidad = CDec(dgvMov.Table.CurrentRecord.GetValue("cantCompra"))
    '                        canSaldo = cantidad - CDec(dgvMov.Table.CurrentRecord.GetValue("canDev"))
    '                        dgvMov.Table.CurrentRecord.SetValue("canSaldo", canSaldo)
    '                        dgvMov.Table.CurrentRecord.SetValue("almacenRef", r.GetValue("idAlmacen"))

    '                        '  DockingClientPanel1.Enabled = True
    '                    End If

    '                Case "2" ' DISMINUIR IMPORTE
    '                    If dgvMov.Table.CurrentRecord.GetValue("bonificacion") = "NO" Then
    '                        Calculos()
    '                    End If

    '                    If Not CDec(dgvMov.Table.CurrentRecord.GetValue("vcmn")) <= CDec(r.GetValue("monto")) Then
    '                        dgvMov.Table.CurrentRecord.SetValue("vcmn", 0)
    '                        dgvMov.Table.CurrentRecord.SetValue("ivamn", 0)
    '                        dgvMov.Table.CurrentRecord.SetValue("totalmn", 0)
    '                        dgvMov.Table.CurrentRecord.SetValue("vcme", 0)
    '                        dgvMov.Table.CurrentRecord.SetValue("ivame", 0)
    '                        dgvMov.Table.CurrentRecord.SetValue("totalme", 0)
    '                        dgvMov.Table.CurrentRecord.SetValue("pumn", 0)
    '                        dgvMov.Table.CurrentRecord.SetValue("pume", 0)
    '                        MessageBox.Show("No cuenta con costo disponible!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)

    '                    Else
    '                        Select Case dgvMov.Table.CurrentRecord.GetValue("estadoPago")
    '                            Case "Pagado"
    '                                Dim saldoFinalmn As Decimal = 0
    '                                Dim saldoFinalme As Decimal = 0

    '                                Dim saldoCompramn As Decimal = 0
    '                                Dim saldoComprame As Decimal = 0
    '                                Dim valAbonomn As Decimal = 0
    '                                Dim valAbonome As Decimal = 0
    '                                Dim ventaOriginalMN As Decimal = 0
    '                                Dim ventaOriginalME As Decimal = 0

    '                                ventaOriginalMN = CDec(dgvMov.Table.CurrentRecord.GetValue("compraMN"))
    '                                ventaOriginalME = CDec(dgvMov.Table.CurrentRecord.GetValue("compraME"))

    '                                saldoCompramn = CDec(dgvMov.Table.CurrentRecord.GetValue("importeMN"))
    '                                saldoComprame = CDec(dgvMov.Table.CurrentRecord.GetValue("importeME"))

    '                                valAbonomn = dgvMov.Table.CurrentRecord.GetValue("totalmn")
    '                                valAbonome = dgvMov.Table.CurrentRecord.GetValue("totalme")

    '                                saldoFinalmn = ventaOriginalMN - valAbonomn
    '                                saldoFinalme = ventaOriginalME - valAbonome

    '                                'If saldoFinalmn < 0 Then
    '                                '    dgvMov.Table.CurrentRecord.SetValue("vcmn", 0)
    '                                '    dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
    '                                '    dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
    '                                '    dgvMov.Table.CurrentRecord.SetValue("action", "inactivo")
    '                                '    Calculos()
    '                                '    Throw New Exception("El monto ingresado supera al valor original del artículo!")

    '                                'ElseIf saldoFinalmn >= 0 Then
    '                                dgvMov.Table.CurrentRecord.SetValue("ValDevmn", valAbonomn)
    '                                dgvMov.Table.CurrentRecord.SetValue("ValDevme", valAbonome)
    '                                dgvMov.Table.CurrentRecord.SetValue("action", "activo")
    '                                'End If

    '                            Case Else

    '                                Dim saldoFinalmn As Decimal = 0
    '                                Dim saldoFinalme As Decimal = 0
    '                                Dim ventaOriginalMN As Decimal = 0
    '                                Dim ventaOriginalME As Decimal = 0

    '                                Dim saldoCompramn As Decimal = 0
    '                                Dim saldoComprame As Decimal = 0
    '                                Dim valAbonomn As Decimal = 0
    '                                Dim valAbonome As Decimal = 0

    '                                ventaOriginalMN = CDec(dgvMov.Table.CurrentRecord.GetValue("compraMN"))
    '                                ventaOriginalME = CDec(dgvMov.Table.CurrentRecord.GetValue("compraME"))

    '                                saldoCompramn = CDec(dgvMov.Table.CurrentRecord.GetValue("importeMN"))
    '                                saldoComprame = CDec(dgvMov.Table.CurrentRecord.GetValue("importeME"))


    '                                valAbonomn = dgvMov.Table.CurrentRecord.GetValue("totalmn")
    '                                valAbonome = dgvMov.Table.CurrentRecord.GetValue("totalme")


    '                                'If saldoCompramn <= 0 Then
    '                                '    dgvMov.Table.CurrentRecord.SetValue("vcmn", 0)
    '                                '    dgvMov.Table.CurrentRecord.SetValue("vcme", 0)
    '                                '    dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
    '                                '    dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
    '                                '    Calculos()
    '                                '    Throw New Exception("El Comprobante no esta disponible")
    '                                'End If

    '                                'If valAbonomn > ventaOriginalMN Then
    '                                '    dgvMov.Table.CurrentRecord.SetValue("vcmn", 0)
    '                                '    dgvMov.Table.CurrentRecord.SetValue("vcme", 0)
    '                                '    dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
    '                                '    dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
    '                                '    Calculos()
    '                                '    Throw New Exception("El importe de la nota supera al importe de compra, " & ventaOriginalMN.ToString("N2"))
    '                                'End If

    '                                saldoFinalmn = saldoCompramn - valAbonomn
    '                                saldoFinalme = saldoComprame - valAbonome

    '                                If saldoFinalmn < 0 Then
    '                                    dgvMov.Table.CurrentRecord.SetValue("ValDevmn", saldoFinalmn * -1)
    '                                    dgvMov.Table.CurrentRecord.SetValue("ValDevme", saldoFinalme * -1)
    '                                    dgvMov.Table.CurrentRecord.SetValue("action", "activo")
    '                                Else
    '                                    dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
    '                                    dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
    '                                    dgvMov.Table.CurrentRecord.SetValue("action", "inactivo")
    '                                End If
    '                        End Select

    '                        If dgvMov.Table.CurrentRecord.GetValue("bonificacion") = "NO" Then
    '                            Calculos()
    '                        End If
    '                        dgvMov.Table.CurrentRecord.SetValue("almacenRef", r.GetValue("idAlmacen"))

    '                        '    DockingClientPanel1.Enabled = True
    '                    End If


    '                Case "3" '"DEVOLUCION DE EXISTENCIAS"


    '                    If Not CDec(dgvMov.Table.CurrentRecord.GetValue("canDev")) <= CDec(r.GetValue("cant")) Then
    '                        'dgvMov.Table.CurrentRecord.SetValue("canDev", 0)
    '                        MessageBox.Show("No cuenta con stock disponible!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                        dgvMov.Table.CurrentRecord.SetValue("canDev", 0)
    '                        dgvMov.Table.CurrentRecord.SetValue("vcmn", 0)
    '                        dgvMov.Table.CurrentRecord.SetValue("ivamn", 0)
    '                        dgvMov.Table.CurrentRecord.SetValue("totalmn", 0)
    '                        dgvMov.Table.CurrentRecord.SetValue("vcme", 0)
    '                        dgvMov.Table.CurrentRecord.SetValue("ivame", 0)
    '                        dgvMov.Table.CurrentRecord.SetValue("totalme", 0)
    '                        dgvMov.Table.CurrentRecord.SetValue("pumn", 0)
    '                        dgvMov.Table.CurrentRecord.SetValue("pume", 0)


    '                    Else
    '                        cantidad = CDec(dgvMov.Table.CurrentRecord.GetValue("cantCompra"))
    '                        canSaldo = cantidad - CDec(dgvMov.Table.CurrentRecord.GetValue("canDev"))
    '                        dgvMov.Table.CurrentRecord.SetValue("canSaldo", canSaldo)
    '                    End If

    '                    Select Case dgvMov.Table.CurrentRecord.GetValue("estadoPago")
    '                        Case "Pagado"
    '                            Dim saldoFinalmn As Decimal = 0
    '                            Dim saldoFinalme As Decimal = 0

    '                            Dim saldoCompramn As Decimal = 0
    '                            Dim saldoComprame As Decimal = 0
    '                            Dim valAbonomn As Decimal = 0
    '                            Dim valAbonome As Decimal = 0
    '                            Dim ventaOriginalMN As Decimal = 0
    '                            Dim ventaOriginalME As Decimal = 0

    '                            ventaOriginalMN = CDec(dgvMov.Table.CurrentRecord.GetValue("compraMN"))
    '                            ventaOriginalME = CDec(dgvMov.Table.CurrentRecord.GetValue("compraME"))

    '                            saldoCompramn = CDec(dgvMov.Table.CurrentRecord.GetValue("importeMN"))
    '                            saldoComprame = CDec(dgvMov.Table.CurrentRecord.GetValue("importeME"))

    '                            valAbonomn = dgvMov.Table.CurrentRecord.GetValue("totalmn")
    '                            valAbonome = dgvMov.Table.CurrentRecord.GetValue("totalme")

    '                            saldoFinalmn = ventaOriginalMN - valAbonomn
    '                            saldoFinalme = ventaOriginalME - valAbonome

    '                            'If saldoFinalmn < 0 Then
    '                            '    dgvMov.Table.CurrentRecord.SetValue("vcmn", 0)
    '                            '    dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
    '                            '    dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
    '                            '    dgvMov.Table.CurrentRecord.SetValue("action", "inactivo")
    '                            '    Calculos()
    '                            '    Throw New Exception("El monto ingresado supera al valor original del artículo!")

    '                            'ElseIf saldoFinalmn >= 0 Then
    '                            dgvMov.Table.CurrentRecord.SetValue("ValDevmn", valAbonomn)
    '                            dgvMov.Table.CurrentRecord.SetValue("ValDevme", valAbonome)
    '                            dgvMov.Table.CurrentRecord.SetValue("action", "activo")
    '                            'End If

    '                        Case Else

    '                            Dim saldoFinalmn As Decimal = 0
    '                            Dim saldoFinalme As Decimal = 0
    '                            Dim ventaOriginalMN As Decimal = 0
    '                            Dim ventaOriginalME As Decimal = 0

    '                            Dim saldoCompramn As Decimal = 0
    '                            Dim saldoComprame As Decimal = 0
    '                            Dim valAbonomn As Decimal = 0
    '                            Dim valAbonome As Decimal = 0

    '                            ventaOriginalMN = CDec(dgvMov.Table.CurrentRecord.GetValue("compraMN"))
    '                            ventaOriginalME = CDec(dgvMov.Table.CurrentRecord.GetValue("compraME"))

    '                            saldoCompramn = CDec(dgvMov.Table.CurrentRecord.GetValue("importeMN"))
    '                            saldoComprame = CDec(dgvMov.Table.CurrentRecord.GetValue("importeME"))


    '                            valAbonomn = dgvMov.Table.CurrentRecord.GetValue("totalmn")
    '                            valAbonome = dgvMov.Table.CurrentRecord.GetValue("totalme")


    '                            'If saldoCompramn <= 0 Then
    '                            '    dgvMov.Table.CurrentRecord.SetValue("vcmn", 0)
    '                            '    dgvMov.Table.CurrentRecord.SetValue("vcme", 0)
    '                            '    dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
    '                            '    dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
    '                            '    Calculos()
    '                            '    Throw New Exception("El Comprobante no esta disponible")
    '                            'End If

    '                            'If valAbonomn > ventaOriginalMN Then
    '                            '    dgvMov.Table.CurrentRecord.SetValue("vcmn", 0)
    '                            '    dgvMov.Table.CurrentRecord.SetValue("vcme", 0)
    '                            '    dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
    '                            '    dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
    '                            '    Calculos()
    '                            '    Throw New Exception("El importe de la nota supera al importe de compra, " & ventaOriginalMN.ToString("N2"))
    '                            'End If

    '                            saldoFinalmn = saldoCompramn - valAbonomn
    '                            saldoFinalme = saldoComprame - valAbonome

    '                            If saldoFinalmn < 0 Then
    '                                dgvMov.Table.CurrentRecord.SetValue("ValDevmn", saldoFinalmn * -1)
    '                                dgvMov.Table.CurrentRecord.SetValue("ValDevme", saldoFinalme * -1)
    '                                dgvMov.Table.CurrentRecord.SetValue("action", "activo")
    '                            Else
    '                                dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
    '                                dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
    '                                dgvMov.Table.CurrentRecord.SetValue("action", "inactivo")
    '                            End If
    '                    End Select
    '                    If dgvMov.Table.CurrentRecord.GetValue("bonificacion") = "NO" Then
    '                        Calculos()
    '                    End If
    '                    dgvMov.Table.CurrentRecord.SetValue("almacenRef", r.GetValue("idAlmacen"))

    '                    '    DockingClientPanel1.Enabled = True
    '            End Select


    '        Catch ex As Exception
    '            MessageBox.Show(ex.Message)
    '        End Try
    '    Else
    '        MessageBox.Show("Deebe seleccionar un item!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End If
    'End Sub

    Private Sub dgvMov_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles dgvMov.TableControlCurrentCellCloseDropDown
        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()
    End Sub

    Private Sub dgvMov_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs) Handles dgvMov.TableControlCurrentCellChanged
        'Dim cc As GridCurrentCell = Me.dgvCompra.TableControl.CurrentCell
        'cc.ConfirmChanges()

        'Try
        '    If Not IsNothing(cc) Then
        '        Select Case cc.ColIndex
        '            'Case 11
        '            Case 16
        '                Select Case dgvMov.Table.CurrentRecord.GetValue("cboMov")
        '                    Case "1"

        '                        'Dim f As New frmNotaValidaAlmacen(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc,
        '                        '                                                           .idEstablecimiento = GEstableciento.IdEstablecimiento,
        '                        '                                                           .idItem = Val(dgvMov.Table.CurrentRecord.GetValue("idItem")),
        '                        '                                                           .cantidad = CDec(dgvMov.Table.CurrentRecord.GetValue("cantCompra")),
        '                        '                                                           .importeSoles = CDec(dgvMov.Table.CurrentRecord.GetValue("montokardex")),
        '                        '                                                           .importeDolares = CDec(dgvMov.Table.CurrentRecord.GetValue("montokardexus"))})

        '                        'f.StartPosition = FormStartPosition.CenterParent
        '                        'f.ShowDialog()

        '                        'If Not IsNothing(f.Tag) Then
        '                        Dim cantidadOrigen As Decimal = 0
        '                        cantidadOrigen = dgvMov.Table.CurrentRecord.GetValue("cantidad")
        '                        If cantidadOrigen <= 0 Then
        '                            dgvMov.Table.CurrentRecord.SetValue("cboMov", String.Empty)
        '                            Throw New Exception("Esta opción no esta disponible elija otra!")
        '                        End If


        '                        'Else
        '                        'Throw New Exception("No se puede realizar la transacción")
        '                        'End If

        '                    Case "2", "4"
        '                        dgvMov.Table.CurrentRecord.SetValue("canDev", 0)
        '                    Case "3"
        '                        Dim cantidadOrigen As Decimal = 0
        '                        cantidadOrigen = dgvMov.Table.CurrentRecord.GetValue("cantidad")
        '                        If cantidadOrigen <= 0 Then
        '                            dgvMov.Table.CurrentRecord.SetValue("cboMov", String.Empty)
        '                            Throw New Exception("Esta opción no esta disponible elija otra!")
        '                        End If
        '                End Select

        '                Calculos()
        '                'Case 12
        '            Case 17
        '                Dim cantidad As Decimal = 0
        '                Dim canSaldo As Decimal = 0
        '                Dim cantidadOrigen As Decimal = 0

        '                cantidadOrigen = dgvMov.Table.CurrentRecord.GetValue("cantidad")
        '                If cantidadOrigen <= 0 Then
        '                    dgvMov.Table.CurrentRecord.SetValue("canDev", 0)
        '                    Throw New Exception("El valor de la cantidad no esta disponible")
        '                End If

        '                If CDec(dgvMov.Table.CurrentRecord.GetValue("canDev")) > cantidadOrigen Then
        '                    dgvMov.Table.CurrentRecord.SetValue("canDev", 0)
        '                    Throw New Exception("El valor de la cantidad excede al monto original")
        '                End If

        '                If dgvMov.Table.CurrentRecord.GetValue("tipoEx") <> TipoRecurso.SERVICIO Then
        '                    If CDec(dgvMov.Table.CurrentRecord.GetValue("canDev")) > 0 Then
        '                        getStockAlmacenes(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc,
        '                                                                                       .idEstablecimiento = GEstableciento.IdEstablecimiento,
        '                                                                                       .idItem = Val(dgvMov.Table.CurrentRecord.GetValue("idItem")),
        '                                                                                       .cantidad = CDec(dgvMov.Table.CurrentRecord.GetValue("canDev")),
        '                                                                                       .importeSoles = CDec(dgvMov.Table.CurrentRecord.GetValue("vcmn")),
        '                                                                                       .importeDolares = CDec(dgvMov.Table.CurrentRecord.GetValue("vcme"))})

        '                        PanelStock.Visible = True
        '                        '        DockingClientPanel1.Enabled = False
        '                    End If
        '                Else

        '                End If


        '                'cantidad = CDec(dgvMov.Table.CurrentRecord.GetValue("cantCompra"))
        '                'canSaldo = cantidad - CDec(dgvMov.Table.CurrentRecord.GetValue("canDev"))
        '                'dgvMov.Table.CurrentRecord.SetValue("canSaldo", canSaldo)
        '                'Calculos()



        '                'Else
        '                'Throw New Exception("No puede realizar esta transacción!")
        '                'End If
        '                'dgvMov.Table.CurrentRecord.SetValue("almacenRef", obj.idAlmacen)

        '                ' Case 13
        '            Case 18


        '                Calculos()
        '                Select Case dgvMov.Table.CurrentRecord.GetValue("estadoPago")
        '                    Case "Pagado"
        '                        Dim saldoFinalmn As Decimal = 0
        '                        Dim saldoFinalme As Decimal = 0

        '                        Dim saldoCompramn As Decimal = 0
        '                        Dim saldoComprame As Decimal = 0
        '                        Dim valAbonomn As Decimal = 0
        '                        Dim valAbonome As Decimal = 0
        '                        Dim ventaOriginalMN As Decimal = 0
        '                        Dim ventaOriginalME As Decimal = 0

        '                        ventaOriginalMN = CDec(dgvMov.Table.CurrentRecord.GetValue("compraMN"))
        '                        ventaOriginalME = CDec(dgvMov.Table.CurrentRecord.GetValue("compraME"))

        '                        'saldoCompramn = CDec(dgvMov.Table.CurrentRecord.GetValue("importeMN"))
        '                        'saldoComprame = CDec(dgvMov.Table.CurrentRecord.GetValue("importeME"))
        '                        saldoCompramn = CDec(dgvMov.Table.CurrentRecord.GetValue("impActMN"))
        '                        saldoComprame = CDec(dgvMov.Table.CurrentRecord.GetValue("impActME"))

        '                        If saldoCompramn = 0 Then
        '                            dgvMov.Table.CurrentRecord.SetValue("vcmn", 0)
        '                            dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
        '                            dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
        '                            dgvMov.Table.CurrentRecord.SetValue("action", "inactivo")
        '                            Calculos()
        '                            Throw New Exception("El importe de la nota supera al importe de compra, " & saldoCompramn.ToString("N2"))
        '                        End If

        '                        valAbonomn = dgvMov.Table.CurrentRecord.GetValue("totalmn")
        '                        valAbonome = dgvMov.Table.CurrentRecord.GetValue("totalme")

        '                        saldoFinalmn = ventaOriginalMN - valAbonomn
        '                        saldoFinalme = ventaOriginalME - valAbonome


        '                        If saldoCompramn < valAbonomn Then
        '                            dgvMov.Table.CurrentRecord.SetValue("vcmn", 0)
        '                            dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
        '                            dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
        '                            dgvMov.Table.CurrentRecord.SetValue("action", "inactivo")
        '                            Calculos()
        '                            Throw New Exception("El importe de la nota supera al importe de compra, " & saldoCompramn.ToString("N2"))
        '                        End If



        '                        'If saldoFinalmn < 0 Then
        '                        If saldoCompramn < 0 Then
        '                            dgvMov.Table.CurrentRecord.SetValue("vcmn", 0)
        '                            dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
        '                            dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
        '                            dgvMov.Table.CurrentRecord.SetValue("action", "inactivo")
        '                            Calculos()
        '                            Throw New Exception("El monto ingresado supera al valor original del artículo!")

        '                            'ElseIf saldoFinalmn >= 0 Then
        '                        ElseIf saldoCompramn > 0 Then
        '                            Select Case dgvMov.Table.CurrentRecord.GetValue("cboMov")
        '                                Case "4"
        '                                    dgvMov.Table.CurrentRecord.SetValue("ValDevmn", valAbonomn)
        '                                    dgvMov.Table.CurrentRecord.SetValue("ValDevme", valAbonome)
        '                                    dgvMov.Table.CurrentRecord.SetValue("action", "activo")

        '                                Case Else
        '                                    If dgvMov.Table.CurrentRecord.GetValue("tipoEx") <> TipoRecurso.SERVICIO Then
        '                                        If CDec(dgvMov.Table.CurrentRecord.GetValue("vcmn")) > 0 Then
        '                                            getStockAlmacenes(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc,
        '                                                                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
        '                                                                                          .idItem = Val(dgvMov.Table.CurrentRecord.GetValue("idItem")),
        '                                                                                          .cantidad = CDec(dgvMov.Table.CurrentRecord.GetValue("canDev")),
        '                                                                                          .importeSoles = CDec(dgvMov.Table.CurrentRecord.GetValue("vcmn")),
        '                                                                                          .importeDolares = CDec(dgvMov.Table.CurrentRecord.GetValue("vcme"))})

        '                                            PanelStock.Visible = True
        '                                            '    DockingClientPanel1.Enabled = False
        '                                        End If

        '                                    Else

        '                                        dgvMov.Table.CurrentRecord.SetValue("ValDevmn", valAbonomn)
        '                                        dgvMov.Table.CurrentRecord.SetValue("ValDevme", valAbonome)
        '                                        dgvMov.Table.CurrentRecord.SetValue("action", "activo")
        '                                    End If
        '                            End Select




        '                            Calculos()
        '                            'dgvMov.Table.CurrentRecord.SetValue("ValDevmn", valAbonomn)
        '                            'dgvMov.Table.CurrentRecord.SetValue("ValDevme", valAbonome)
        '                            'dgvMov.Table.CurrentRecord.SetValue("action", "activo")
        '                        End If

        '                    Case Else

        '                        Dim saldoFinalmn As Decimal = 0
        '                        Dim saldoFinalme As Decimal = 0
        '                        Dim ventaOriginalMN As Decimal = 0
        '                        Dim ventaOriginalME As Decimal = 0

        '                        Dim saldoCompramn As Decimal = 0
        '                        Dim saldoComprame As Decimal = 0
        '                        Dim valAbonomn As Decimal = 0
        '                        Dim valAbonome As Decimal = 0

        '                        ventaOriginalMN = CDec(dgvMov.Table.CurrentRecord.GetValue("compraMN"))
        '                        ventaOriginalME = CDec(dgvMov.Table.CurrentRecord.GetValue("compraME"))

        '                        'saldoCompramn = CDec(dgvMov.Table.CurrentRecord.GetValue("importeMN"))
        '                        'saldoComprame = CDec(dgvMov.Table.CurrentRecord.GetValue("importeME"))
        '                        saldoCompramn = CDec(dgvMov.Table.CurrentRecord.GetValue("impActMN"))
        '                        saldoComprame = CDec(dgvMov.Table.CurrentRecord.GetValue("impActME"))

        '                        valAbonomn = dgvMov.Table.CurrentRecord.GetValue("totalmn")
        '                        valAbonome = dgvMov.Table.CurrentRecord.GetValue("totalme")


        '                        If saldoCompramn <= 0 Then
        '                            dgvMov.Table.CurrentRecord.SetValue("vcmn", 0)
        '                            dgvMov.Table.CurrentRecord.SetValue("vcme", 0)
        '                            dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
        '                            dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
        '                            Calculos()
        '                            Throw New Exception("El Comprobante no esta disponible")
        '                        End If

        '                        'If valAbonomn > ventaOriginalMN Then
        '                        If valAbonomn > saldoCompramn Then
        '                            dgvMov.Table.CurrentRecord.SetValue("vcmn", 0)
        '                            dgvMov.Table.CurrentRecord.SetValue("vcme", 0)
        '                            dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
        '                            dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
        '                            Calculos()
        '                            'Throw New Exception("El importe de la nota supera al importe de compra, " & ventaOriginalMN.ToString("N2"))
        '                            Throw New Exception("El importe de la nota supera al importe de compra, " & saldoCompramn.ToString("N2"))
        '                        End If

        '                        Select Case dgvMov.Table.CurrentRecord.GetValue("cboMov")
        '                            Case "4"
        '                                saldoFinalmn = saldoCompramn - valAbonomn
        '                                saldoFinalme = saldoComprame - valAbonome

        '                                If saldoFinalmn < 0 Then
        '                                    dgvMov.Table.CurrentRecord.SetValue("ValDevmn", saldoFinalmn * -1)
        '                                    dgvMov.Table.CurrentRecord.SetValue("ValDevme", saldoFinalme * -1)
        '                                    dgvMov.Table.CurrentRecord.SetValue("action", "activo")
        '                                Else
        '                                    dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
        '                                    dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
        '                                    dgvMov.Table.CurrentRecord.SetValue("action", "inactivo")
        '                                End If
        '                                Calculos()


        '                            Case Else
        '                                If dgvMov.Table.CurrentRecord.GetValue("tipoEx") <> TipoRecurso.SERVICIO Then
        '                                    If CDec(dgvMov.Table.CurrentRecord.GetValue("vcmn")) > 0 Then
        '                                        getStockAlmacenes(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc,
        '                                                                                      .idEstablecimiento = GEstableciento.IdEstablecimiento,
        '                                                                                      .idItem = Val(dgvMov.Table.CurrentRecord.GetValue("idItem")),
        '                                                                                      .cantidad = CDec(dgvMov.Table.CurrentRecord.GetValue("canDev")),
        '                                                                                      .importeSoles = CDec(dgvMov.Table.CurrentRecord.GetValue("vcmn")),
        '                                                                                      .importeDolares = CDec(dgvMov.Table.CurrentRecord.GetValue("vcme"))})

        '                                        PanelStock.Visible = True
        '                                        '   DockingClientPanel1.Enabled = False
        '                                    End If

        '                                Else
        '                                    saldoFinalmn = saldoCompramn - valAbonomn
        '                                    saldoFinalme = saldoComprame - valAbonome

        '                                    If saldoFinalmn < 0 Then
        '                                        dgvMov.Table.CurrentRecord.SetValue("ValDevmn", saldoFinalmn * -1)
        '                                        dgvMov.Table.CurrentRecord.SetValue("ValDevme", saldoFinalme * -1)
        '                                        dgvMov.Table.CurrentRecord.SetValue("action", "activo")
        '                                    Else
        '                                        dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
        '                                        dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
        '                                        dgvMov.Table.CurrentRecord.SetValue("action", "inactivo")
        '                                    End If
        '                                    Calculos()
        '                                End If
        '                        End Select
        '                End Select



        '                'End If


        '                ' Case 16
        '            Case 21
        '                'dgvMov.Table.CurrentRecord.SetValue("ValDevmn", CDec(dgvMov.Table.CurrentRecord.GetValue("totalmn")))
        '                'dgvMov.Table.CurrentRecord.SetValue("ValDevme", CDec(dgvMov.Table.CurrentRecord.GetValue("totalme")))

        '                TotalTalesXcolumna()

        '        End Select
        '    End If
        'Catch ex As Exception
        '    lblEstado.Text = ex.Message
        '    PanelError.Visible = True
        '    Timer1.Enabled = True
        '    TiempoEjecutar(10)
        'End Try


    End Sub

    Private Sub txtFecha_ValueChanged(sender As Object, e As EventArgs) Handles txtFecha.ValueChanged
        If IsDate(txtFecha.Value) Then
            If txtFecha.Value.Date > DiaLaboral.Date Then
                txtFecha.Value = DiaLaboral
                MessageBox.Show("Debe respetar la fecha laboral o fechas inferiores a esta.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Sub FilaCalculada(sender As Object)
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Try
            If Not IsNothing(Me.dgvMov.Table.CurrentRecord) Then
                'Select Case ColIndex
                '    'Case 11
                '    Case 16
                '        Select Case dgvMov.Table.CurrentRecord.GetValue("cboMov")
                '            Case "1"
                '                Dim cantidadOrigen As Decimal = 0
                '                cantidadOrigen = dgvMov.Table.CurrentRecord.GetValue("cantidad")
                '                If cantidadOrigen <= 0 Then
                '                    dgvMov.Table.CurrentRecord.SetValue("cboMov", String.Empty)
                '                    Throw New Exception("Esta opción no esta disponible elija otra!")
                '                End If


                '            Case "2", "4"
                '                dgvMov.Table.CurrentRecord.SetValue("canDev", 0)
                '            Case "3"
                '                Dim cantidadOrigen As Decimal = 0
                '                cantidadOrigen = dgvMov.Table.CurrentRecord.GetValue("cantidad")
                '                If cantidadOrigen <= 0 Then
                '                    dgvMov.Table.CurrentRecord.SetValue("cboMov", String.Empty)
                '                    Throw New Exception("Esta opción no esta disponible elija otra!")
                '                End If
                '        End Select

                '        Calculos()
                '        'Case 12
                '    Case 17
                '        Dim cantidad As Decimal = 0
                '        Dim canSaldo As Decimal = 0
                '        Dim cantidadOrigen As Decimal = 0

                '        cantidadOrigen = dgvMov.Table.CurrentRecord.GetValue("cantidad")
                '        If cantidadOrigen <= 0 Then
                '            dgvMov.Table.CurrentRecord.SetValue("canDev", 0)
                '            Throw New Exception("El valor de la cantidad no esta disponible")
                '        End If

                '        If CDec(dgvMov.Table.CurrentRecord.GetValue("canDev")) > cantidadOrigen Then
                '            dgvMov.Table.CurrentRecord.SetValue("canDev", 0)
                '            Throw New Exception("El valor de la cantidad excede al monto original")
                '        End If

                '        If dgvMov.Table.CurrentRecord.GetValue("tipoEx") <> TipoRecurso.SERVICIO Then
                '            If CDec(dgvMov.Table.CurrentRecord.GetValue("canDev")) > 0 Then
                '                getStockAlmacenes(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc,
                '                                                                               .idEstablecimiento = GEstableciento.IdEstablecimiento,
                '                                                                               .idItem = Val(dgvMov.Table.CurrentRecord.GetValue("idItem")),
                '                                                                               .cantidad = CDec(dgvMov.Table.CurrentRecord.GetValue("canDev")),
                '                                                                               .importeSoles = CDec(dgvMov.Table.CurrentRecord.GetValue("vcmn")),
                '                                                                               .importeDolares = CDec(dgvMov.Table.CurrentRecord.GetValue("vcme"))})

                '                PanelStock.Visible = True
                '                '        DockingClientPanel1.Enabled = False
                '            End If
                '        Else

                '        End If


                '        'cantidad = CDec(dgvMov.Table.CurrentRecord.GetValue("cantCompra"))
                '        'canSaldo = cantidad - CDec(dgvMov.Table.CurrentRecord.GetValue("canDev"))
                '        'dgvMov.Table.CurrentRecord.SetValue("canSaldo", canSaldo)
                '        'Calculos()



                '        'Else
                '        'Throw New Exception("No puede realizar esta transacción!")
                '        'End If
                '        'dgvMov.Table.CurrentRecord.SetValue("almacenRef", obj.idAlmacen)

                '        ' Case 13
                '    Case 18

                If dgvMov.Table.CurrentRecord.GetValue("bonificacion") = "NO" Then
                    Calculos()
                    Select Case dgvMov.Table.CurrentRecord.GetValue("estadoPago")
                        Case "Pagado"
                            Dim saldoFinalmn As Decimal = 0
                            Dim saldoFinalme As Decimal = 0

                            Dim saldoCompramn As Decimal = 0
                            Dim saldoComprame As Decimal = 0
                            Dim valAbonomn As Decimal = 0
                            Dim valAbonome As Decimal = 0
                            Dim ventaOriginalMN As Decimal = 0
                            Dim ventaOriginalME As Decimal = 0

                            ventaOriginalMN = CDec(dgvMov.Table.CurrentRecord.GetValue("compraMN"))
                            ventaOriginalME = CDec(dgvMov.Table.CurrentRecord.GetValue("compraME"))

                            'saldoCompramn = CDec(dgvMov.Table.CurrentRecord.GetValue("importeMN"))
                            'saldoComprame = CDec(dgvMov.Table.CurrentRecord.GetValue("importeME"))
                            saldoCompramn = CDec(dgvMov.Table.CurrentRecord.GetValue("impActMN"))
                            saldoComprame = CDec(dgvMov.Table.CurrentRecord.GetValue("impActME"))

                            If saldoCompramn = 0 Then
                                dgvMov.Table.CurrentRecord.SetValue("vcmn", 0)
                                dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
                                dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
                                dgvMov.Table.CurrentRecord.SetValue("action", "inactivo")
                                Calculos()
                                Throw New Exception("El importe de la nota supera al importe de compra, " & saldoCompramn.ToString("N2"))
                            End If

                            valAbonomn = dgvMov.Table.CurrentRecord.GetValue("totalmn")
                            valAbonome = dgvMov.Table.CurrentRecord.GetValue("totalme")

                            saldoFinalmn = ventaOriginalMN - valAbonomn
                            saldoFinalme = ventaOriginalME - valAbonome


                            If saldoCompramn < valAbonomn Then
                                dgvMov.Table.CurrentRecord.SetValue("vcmn", 0)
                                dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
                                dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
                                dgvMov.Table.CurrentRecord.SetValue("action", "inactivo")
                                Calculos()
                                Throw New Exception("El importe de la nota supera al importe de compra, " & saldoCompramn.ToString("N2"))
                            End If



                            'If saldoFinalmn < 0 Then
                            If saldoCompramn < 0 Then
                                dgvMov.Table.CurrentRecord.SetValue("vcmn", 0)
                                dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
                                dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
                                dgvMov.Table.CurrentRecord.SetValue("action", "inactivo")
                                Calculos()
                                Throw New Exception("El monto ingresado supera al valor original del artículo!")

                                'ElseIf saldoFinalmn >= 0 Then
                            ElseIf saldoCompramn > 0 Then
                                Select Case dgvMov.Table.CurrentRecord.GetValue("cboMov")
                                    Case "4"
                                        dgvMov.Table.CurrentRecord.SetValue("ValDevmn", valAbonomn)
                                        dgvMov.Table.CurrentRecord.SetValue("ValDevme", valAbonome)
                                        dgvMov.Table.CurrentRecord.SetValue("action", "activo")
                                    Case "3"
                                        dgvMov.Table.CurrentRecord.SetValue("ValDevmn", valAbonomn)
                                        dgvMov.Table.CurrentRecord.SetValue("ValDevme", valAbonome)
                                        dgvMov.Table.CurrentRecord.SetValue("action", "activo")
                                    Case "2"
                                        dgvMov.Table.CurrentRecord.SetValue("ValDevmn", valAbonomn)
                                        dgvMov.Table.CurrentRecord.SetValue("ValDevme", valAbonome)
                                        dgvMov.Table.CurrentRecord.SetValue("action", "activo")
                                    Case "1"
                                        dgvMov.Table.CurrentRecord.SetValue("vcmn", 0)
                                        dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
                                        dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
                                        dgvMov.Table.CurrentRecord.SetValue("action", "inactivo")

                                    Case Else
                                        If dgvMov.Table.CurrentRecord.GetValue("tipoEx") <> TipoRecurso.SERVICIO Then
                                            If CDec(dgvMov.Table.CurrentRecord.GetValue("vcmn")) > 0 Then
                                                'getStockAlmacenes(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                '                                              .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                '                                              .idItem = Val(dgvMov.Table.CurrentRecord.GetValue("idItem")),
                                                '                                              .cantidad = CDec(dgvMov.Table.CurrentRecord.GetValue("canDev")),
                                                '                                              .importeSoles = CDec(dgvMov.Table.CurrentRecord.GetValue("vcmn")),
                                                '                                              .importeDolares = CDec(dgvMov.Table.CurrentRecord.GetValue("vcme"))})

                                                'PanelStock.Visible = True
                                                '    DockingClientPanel1.Enabled = False
                                            End If

                                        Else

                                            dgvMov.Table.CurrentRecord.SetValue("ValDevmn", valAbonomn)
                                            dgvMov.Table.CurrentRecord.SetValue("ValDevme", valAbonome)
                                            dgvMov.Table.CurrentRecord.SetValue("action", "activo")
                                        End If
                                End Select




                                Calculos()
                                'dgvMov.Table.CurrentRecord.SetValue("ValDevmn", valAbonomn)
                                'dgvMov.Table.CurrentRecord.SetValue("ValDevme", valAbonome)
                                'dgvMov.Table.CurrentRecord.SetValue("action", "activo")
                            End If

                        Case Else

                            Dim saldoFinalmn As Decimal = 0
                            Dim saldoFinalme As Decimal = 0
                            Dim ventaOriginalMN As Decimal = 0
                            Dim ventaOriginalME As Decimal = 0

                            Dim saldoCompramn As Decimal = 0
                            Dim saldoComprame As Decimal = 0
                            Dim valAbonomn As Decimal = 0
                            Dim valAbonome As Decimal = 0



                            ventaOriginalMN = CDec(dgvMov.Table.CurrentRecord.GetValue("compraMN"))
                            ventaOriginalME = CDec(dgvMov.Table.CurrentRecord.GetValue("compraME"))

                            'saldoCompramn = CDec(dgvMov.Table.CurrentRecord.GetValue("importeMN"))
                            'saldoComprame = CDec(dgvMov.Table.CurrentRecord.GetValue("importeME"))
                            saldoCompramn = CDec(dgvMov.Table.CurrentRecord.GetValue("impActMN"))
                            saldoComprame = CDec(dgvMov.Table.CurrentRecord.GetValue("impActME"))

                            valAbonomn = dgvMov.Table.CurrentRecord.GetValue("totalmn")
                            valAbonome = dgvMov.Table.CurrentRecord.GetValue("totalme")


                            If saldoCompramn <= 0 Then
                                dgvMov.Table.CurrentRecord.SetValue("vcmn", 0)
                                dgvMov.Table.CurrentRecord.SetValue("vcme", 0)
                                dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
                                dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
                                Calculos()
                                Throw New Exception("El Comprobante no esta disponible")
                            End If

                            'If valAbonomn > ventaOriginalMN Then
                            If valAbonomn > saldoCompramn Then
                                dgvMov.Table.CurrentRecord.SetValue("vcmn", 0)
                                dgvMov.Table.CurrentRecord.SetValue("vcme", 0)
                                dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
                                dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
                                Calculos()
                                'Throw New Exception("El importe de la nota supera al importe de compra, " & ventaOriginalMN.ToString("N2"))
                                Throw New Exception("El importe de la nota supera al importe de compra, " & saldoCompramn.ToString("N2"))
                            End If

                            Select Case dgvMov.Table.CurrentRecord.GetValue("cboMov")
                                Case "4"


                                    'saldoFinalmn = saldoCompramn - valAbonomn
                                    'saldoFinalme = saldoComprame - valAbonome

                                    'If saldoFinalmn < 0 Then
                                    '    dgvMov.Table.CurrentRecord.SetValue("ValDevmn", saldoFinalmn * -1)
                                    '    dgvMov.Table.CurrentRecord.SetValue("ValDevme", saldoFinalme * -1)
                                    '    dgvMov.Table.CurrentRecord.SetValue("action", "activo")
                                    'Else
                                    '    dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
                                    '    dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
                                    '    dgvMov.Table.CurrentRecord.SetValue("action", "inactivo")
                                    'End If



                                    If dgvMov.Table.CurrentRecord.GetValue("importeMN") = 0 Then



                                        dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
                                        dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
                                        dgvMov.Table.CurrentRecord.SetValue("action", "inactivo")
                                    Else


                                        saldoFinalmn = saldoCompramn - valAbonomn
                                        saldoFinalme = saldoComprame - valAbonome
                                        Dim dinerodev As Decimal = dgvMov.Table.CurrentRecord.GetValue("dineroDev")
                                        Dim dinerodevme As Decimal = dgvMov.Table.CurrentRecord.GetValue("dineroDevme")

                                        Dim saldox As Decimal = dgvMov.Table.CurrentRecord.GetValue("importeMN")
                                        Dim saldoxme As Decimal = dgvMov.Table.CurrentRecord.GetValue("importeME")

                                        If saldoFinalmn < 0 Then
                                            dgvMov.Table.CurrentRecord.SetValue("ValDevmn", saldoFinalmn * -1)
                                            dgvMov.Table.CurrentRecord.SetValue("ValDevme", saldoFinalme * -1)
                                            dgvMov.Table.CurrentRecord.SetValue("action", "activo")
                                        ElseIf saldoFinalmn = 0 Then

                                            dgvMov.Table.CurrentRecord.SetValue("ValDevmn", dinerodev)
                                            dgvMov.Table.CurrentRecord.SetValue("ValDevme", dinerodevme)
                                            dgvMov.Table.CurrentRecord.SetValue("action", "activo")

                                        Else
                                            saldoFinalmn = saldox - valAbonomn
                                            saldoFinalme = saldoxme - valAbonome

                                            If saldoFinalmn >= 0 Then
                                                dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
                                                dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
                                                dgvMov.Table.CurrentRecord.SetValue("action", "activo")
                                            Else
                                                dgvMov.Table.CurrentRecord.SetValue("ValDevmn", saldoFinalmn * -1)
                                                dgvMov.Table.CurrentRecord.SetValue("ValDevme", saldoFinalme * -1)
                                                dgvMov.Table.CurrentRecord.SetValue("action", "activo")
                                            End If

                                        End If


                                    End If


                                    Calculos()
                                Case "3"
                                    If dgvMov.Table.CurrentRecord.GetValue("importeMN") = 0 Then



                                        dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
                                        dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
                                        dgvMov.Table.CurrentRecord.SetValue("action", "inactivo")
                                    Else


                                        saldoFinalmn = saldoCompramn - valAbonomn
                                        saldoFinalme = saldoComprame - valAbonome
                                        Dim dinerodev As Decimal = dgvMov.Table.CurrentRecord.GetValue("dineroDev")
                                        Dim dinerodevme As Decimal = dgvMov.Table.CurrentRecord.GetValue("dineroDevme")

                                        Dim saldox As Decimal = dgvMov.Table.CurrentRecord.GetValue("importeMN")
                                        Dim saldoxme As Decimal = dgvMov.Table.CurrentRecord.GetValue("importeME")

                                        If saldoFinalmn < 0 Then
                                            dgvMov.Table.CurrentRecord.SetValue("ValDevmn", saldoFinalmn * -1)
                                            dgvMov.Table.CurrentRecord.SetValue("ValDevme", saldoFinalme * -1)
                                            dgvMov.Table.CurrentRecord.SetValue("action", "activo")
                                        ElseIf saldoFinalmn = 0 Then

                                            dgvMov.Table.CurrentRecord.SetValue("ValDevmn", dinerodev)
                                            dgvMov.Table.CurrentRecord.SetValue("ValDevme", dinerodevme)
                                            dgvMov.Table.CurrentRecord.SetValue("action", "activo")

                                        Else
                                            saldoFinalmn = saldox - valAbonomn
                                            saldoFinalme = saldoxme - valAbonome

                                            If saldoFinalmn >= 0 Then
                                                dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
                                                dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
                                                dgvMov.Table.CurrentRecord.SetValue("action", "activo")
                                            Else
                                                dgvMov.Table.CurrentRecord.SetValue("ValDevmn", saldoFinalmn * -1)
                                                dgvMov.Table.CurrentRecord.SetValue("ValDevme", saldoFinalme * -1)
                                                dgvMov.Table.CurrentRecord.SetValue("action", "activo")
                                            End If

                                        End If


                                    End If

                                    Calculos()
                                Case "2"
                                    If dgvMov.Table.CurrentRecord.GetValue("importeMN") = 0 Then



                                        dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
                                        dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
                                        dgvMov.Table.CurrentRecord.SetValue("action", "inactivo")
                                    Else


                                        saldoFinalmn = saldoCompramn - valAbonomn
                                        saldoFinalme = saldoComprame - valAbonome
                                        Dim dinerodev As Decimal = dgvMov.Table.CurrentRecord.GetValue("dineroDev")
                                        Dim dinerodevme As Decimal = dgvMov.Table.CurrentRecord.GetValue("dineroDevme")

                                        Dim saldox As Decimal = dgvMov.Table.CurrentRecord.GetValue("importeMN")
                                        Dim saldoxme As Decimal = dgvMov.Table.CurrentRecord.GetValue("importeME")

                                        If saldoFinalmn < 0 Then
                                            dgvMov.Table.CurrentRecord.SetValue("ValDevmn", saldoFinalmn * -1)
                                            dgvMov.Table.CurrentRecord.SetValue("ValDevme", saldoFinalme * -1)
                                            dgvMov.Table.CurrentRecord.SetValue("action", "activo")
                                        ElseIf saldoFinalmn = 0 Then

                                            dgvMov.Table.CurrentRecord.SetValue("ValDevmn", dinerodev)
                                            dgvMov.Table.CurrentRecord.SetValue("ValDevme", dinerodevme)
                                            dgvMov.Table.CurrentRecord.SetValue("action", "activo")

                                        Else
                                            saldoFinalmn = saldox - valAbonomn
                                            saldoFinalme = saldoxme - valAbonome
                                            If saldoFinalmn >= 0 Then
                                                dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
                                                dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
                                                dgvMov.Table.CurrentRecord.SetValue("action", "activo")
                                            Else
                                                dgvMov.Table.CurrentRecord.SetValue("ValDevmn", saldoFinalmn * -1)
                                                dgvMov.Table.CurrentRecord.SetValue("ValDevme", saldoFinalme * -1)
                                                dgvMov.Table.CurrentRecord.SetValue("action", "activo")
                                            End If


                                        End If


                                    End If
                                    Calculos()

                                Case "1"

                                    dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
                                    dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
                                    dgvMov.Table.CurrentRecord.SetValue("action", "inactivo")
                                    Calculos()
                                Case Else
                                    If dgvMov.Table.CurrentRecord.GetValue("tipoEx") <> TipoRecurso.SERVICIO Then
                                        If CDec(dgvMov.Table.CurrentRecord.GetValue("vcmn")) > 0 Then
                                            'getStockAlmacenes(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                            '                                              .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                            '                                              .idItem = Val(dgvMov.Table.CurrentRecord.GetValue("idItem")),
                                            '                                              .cantidad = CDec(dgvMov.Table.CurrentRecord.GetValue("canDev")),
                                            '                                              .importeSoles = CDec(dgvMov.Table.CurrentRecord.GetValue("vcmn")),
                                            '                                              .importeDolares = CDec(dgvMov.Table.CurrentRecord.GetValue("vcme"))})

                                            'PanelStock.Visible = True
                                            '   DockingClientPanel1.Enabled = False
                                        End If

                                    Else
                                        saldoFinalmn = saldoCompramn - valAbonomn
                                        saldoFinalme = saldoComprame - valAbonome

                                        If saldoFinalmn < 0 Then
                                            dgvMov.Table.CurrentRecord.SetValue("ValDevmn", saldoFinalmn * -1)
                                            dgvMov.Table.CurrentRecord.SetValue("ValDevme", saldoFinalme * -1)
                                            dgvMov.Table.CurrentRecord.SetValue("action", "activo")
                                        Else
                                            dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
                                            dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
                                            dgvMov.Table.CurrentRecord.SetValue("action", "inactivo")
                                        End If
                                        Calculos()
                                    End If

                            End Select





                    End Select

                Else

                    If CDec(dgvMov.Table.CurrentRecord.GetValue("impActMN")) >= dgvMov.Table.CurrentRecord.GetValue("vcmn") Then


                        Dim saldoFinalmn As Decimal = 0
                        Dim saldoFinalme As Decimal = 0
                        Dim ventaOriginalMN As Decimal = 0
                        Dim ventaOriginalME As Decimal = 0

                        Dim saldoCompramn As Decimal = 0
                        Dim saldoComprame As Decimal = 0
                        Dim valAbonomn As Decimal = 0
                        Dim valAbonome As Decimal = 0



                        ventaOriginalMN = CDec(dgvMov.Table.CurrentRecord.GetValue("compraMN"))
                        ventaOriginalME = CDec(dgvMov.Table.CurrentRecord.GetValue("compraME"))

                        'saldoCompramn = CDec(dgvMov.Table.CurrentRecord.GetValue("importeMN"))
                        'saldoComprame = CDec(dgvMov.Table.CurrentRecord.GetValue("importeME"))
                        saldoCompramn = CDec(dgvMov.Table.CurrentRecord.GetValue("impActMN"))
                        saldoComprame = CDec(dgvMov.Table.CurrentRecord.GetValue("impActME"))

                        valAbonomn = dgvMov.Table.CurrentRecord.GetValue("totalmn")
                        valAbonome = dgvMov.Table.CurrentRecord.GetValue("totalme")


                        If saldoCompramn <= 0 Then
                            dgvMov.Table.CurrentRecord.SetValue("vcmn", 0)
                            dgvMov.Table.CurrentRecord.SetValue("vcme", 0)
                            dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
                            dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
                            Calculos()
                            Throw New Exception("El Comprobante no esta disponible")
                        End If

                        'If valAbonomn > ventaOriginalMN Then
                        If valAbonomn > saldoCompramn Then
                            dgvMov.Table.CurrentRecord.SetValue("vcmn", 0)
                            dgvMov.Table.CurrentRecord.SetValue("vcme", 0)
                            dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
                            dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
                            Calculos()
                            'Throw New Exception("El importe de la nota supera al importe de compra, " & ventaOriginalMN.ToString("N2"))
                            Throw New Exception("El importe de la nota supera al importe de compra, " & saldoCompramn.ToString("N2"))
                        End If

                        Select Case dgvMov.Table.CurrentRecord.GetValue("cboMov")
                            Case "4"
                                'saldoFinalmn = saldoCompramn - valAbonomn
                                'saldoFinalme = saldoComprame - valAbonome

                                'If saldoFinalmn < 0 Then
                                '    dgvMov.Table.CurrentRecord.SetValue("ValDevmn", saldoFinalmn * -1)
                                '    dgvMov.Table.CurrentRecord.SetValue("ValDevme", saldoFinalme * -1)
                                '    dgvMov.Table.CurrentRecord.SetValue("action", "activo")
                                'Else
                                '    dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
                                '    dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
                                '    dgvMov.Table.CurrentRecord.SetValue("action", "inactivo")
                                'End If
                                'Calculos()

                                If dgvMov.Table.CurrentRecord.GetValue("importeMN") = 0 Then



                                    dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
                                    dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
                                    dgvMov.Table.CurrentRecord.SetValue("action", "inactivo")
                                Else


                                    saldoFinalmn = saldoCompramn - valAbonomn
                                    saldoFinalme = saldoComprame - valAbonome
                                    Dim dinerodev As Decimal = dgvMov.Table.CurrentRecord.GetValue("dineroDev")
                                    Dim dinerodevme As Decimal = dgvMov.Table.CurrentRecord.GetValue("dineroDevme")

                                    Dim saldox As Decimal = dgvMov.Table.CurrentRecord.GetValue("importeMN")
                                    Dim saldoxme As Decimal = dgvMov.Table.CurrentRecord.GetValue("importeME")

                                    If saldoFinalmn < 0 Then
                                        dgvMov.Table.CurrentRecord.SetValue("ValDevmn", saldoFinalmn * -1)
                                        dgvMov.Table.CurrentRecord.SetValue("ValDevme", saldoFinalme * -1)
                                        dgvMov.Table.CurrentRecord.SetValue("action", "activo")
                                    ElseIf saldoFinalmn = 0 Then

                                        dgvMov.Table.CurrentRecord.SetValue("ValDevmn", dinerodev)
                                        dgvMov.Table.CurrentRecord.SetValue("ValDevme", dinerodevme)
                                        dgvMov.Table.CurrentRecord.SetValue("action", "activo")

                                    Else
                                        saldoFinalmn = saldox - valAbonomn
                                        saldoFinalme = saldoxme - valAbonome

                                        dgvMov.Table.CurrentRecord.SetValue("ValDevmn", saldoFinalmn * -1)
                                        dgvMov.Table.CurrentRecord.SetValue("ValDevme", saldoFinalme * -1)
                                        dgvMov.Table.CurrentRecord.SetValue("action", "activo")

                                    End If


                                End If
                                Calculos()
                            Case 3
                                If dgvMov.Table.CurrentRecord.GetValue("importeMN") = 0 Then



                                    dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
                                    dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
                                    dgvMov.Table.CurrentRecord.SetValue("action", "inactivo")
                                Else


                                    saldoFinalmn = saldoCompramn - valAbonomn
                                    saldoFinalme = saldoComprame - valAbonome
                                    Dim dinerodev As Decimal = dgvMov.Table.CurrentRecord.GetValue("dineroDev")
                                    Dim dinerodevme As Decimal = dgvMov.Table.CurrentRecord.GetValue("dineroDevme")

                                    Dim saldox As Decimal = dgvMov.Table.CurrentRecord.GetValue("importeMN")
                                    Dim saldoxme As Decimal = dgvMov.Table.CurrentRecord.GetValue("importeME")

                                    If saldoFinalmn < 0 Then
                                        dgvMov.Table.CurrentRecord.SetValue("ValDevmn", saldoFinalmn * -1)
                                        dgvMov.Table.CurrentRecord.SetValue("ValDevme", saldoFinalme * -1)
                                        dgvMov.Table.CurrentRecord.SetValue("action", "activo")
                                    ElseIf saldoFinalmn = 0 Then

                                        dgvMov.Table.CurrentRecord.SetValue("ValDevmn", dinerodev)
                                        dgvMov.Table.CurrentRecord.SetValue("ValDevme", dinerodevme)
                                        dgvMov.Table.CurrentRecord.SetValue("action", "activo")

                                    Else
                                        saldoFinalmn = saldox - valAbonomn
                                        saldoFinalme = saldoxme - valAbonome

                                        dgvMov.Table.CurrentRecord.SetValue("ValDevmn", saldoFinalmn * -1)
                                        dgvMov.Table.CurrentRecord.SetValue("ValDevme", saldoFinalme * -1)
                                        dgvMov.Table.CurrentRecord.SetValue("action", "activo")

                                    End If


                                End If
                                Calculos()
                            Case 2
                                If dgvMov.Table.CurrentRecord.GetValue("importeMN") = 0 Then



                                    dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
                                    dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
                                    dgvMov.Table.CurrentRecord.SetValue("action", "inactivo")
                                Else


                                    saldoFinalmn = saldoCompramn - valAbonomn
                                    saldoFinalme = saldoComprame - valAbonome
                                    Dim dinerodev As Decimal = dgvMov.Table.CurrentRecord.GetValue("dineroDev")
                                    Dim dinerodevme As Decimal = dgvMov.Table.CurrentRecord.GetValue("dineroDevme")

                                    Dim saldox As Decimal = dgvMov.Table.CurrentRecord.GetValue("importeMN")
                                    Dim saldoxme As Decimal = dgvMov.Table.CurrentRecord.GetValue("importeME")

                                    If saldoFinalmn < 0 Then
                                        dgvMov.Table.CurrentRecord.SetValue("ValDevmn", saldoFinalmn * -1)
                                        dgvMov.Table.CurrentRecord.SetValue("ValDevme", saldoFinalme * -1)
                                        dgvMov.Table.CurrentRecord.SetValue("action", "activo")
                                    ElseIf saldoFinalmn = 0 Then

                                        dgvMov.Table.CurrentRecord.SetValue("ValDevmn", dinerodev)
                                        dgvMov.Table.CurrentRecord.SetValue("ValDevme", dinerodevme)
                                        dgvMov.Table.CurrentRecord.SetValue("action", "activo")

                                    Else
                                        saldoFinalmn = saldox - valAbonomn
                                        saldoFinalme = saldoxme - valAbonome

                                        dgvMov.Table.CurrentRecord.SetValue("ValDevmn", saldoFinalmn * -1)
                                        dgvMov.Table.CurrentRecord.SetValue("ValDevme", saldoFinalme * -1)
                                        dgvMov.Table.CurrentRecord.SetValue("action", "activo")

                                    End If


                                End If
                                Calculos()
                            Case 1

                                dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
                                dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
                                dgvMov.Table.CurrentRecord.SetValue("action", "inactivo")

                                Calculos()



                            Case Else
                                If dgvMov.Table.CurrentRecord.GetValue("tipoEx") <> TipoRecurso.SERVICIO Then
                                    If CDec(dgvMov.Table.CurrentRecord.GetValue("vcmn")) > 0 Then
                                        'getStockAlmacenes(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                        '                                              .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                        '                                              .idItem = Val(dgvMov.Table.CurrentRecord.GetValue("idItem")),
                                        '                                              .cantidad = CDec(dgvMov.Table.CurrentRecord.GetValue("canDev")),
                                        '                                              .importeSoles = CDec(dgvMov.Table.CurrentRecord.GetValue("vcmn")),
                                        '                                              .importeDolares = CDec(dgvMov.Table.CurrentRecord.GetValue("vcme"))})

                                        'PanelStock.Visible = True
                                        '   DockingClientPanel1.Enabled = False
                                    End If

                                Else
                                    'saldoFinalmn = saldoCompramn - valAbonomn
                                    'saldoFinalme = saldoComprame - valAbonome

                                    'If saldoFinalmn < 0 Then
                                    '    dgvMov.Table.CurrentRecord.SetValue("ValDevmn", saldoFinalmn * -1)
                                    '    dgvMov.Table.CurrentRecord.SetValue("ValDevme", saldoFinalme * -1)
                                    '    dgvMov.Table.CurrentRecord.SetValue("action", "activo")
                                    'Else
                                    '    dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
                                    '    dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
                                    '    dgvMov.Table.CurrentRecord.SetValue("action", "inactivo")
                                    'End If
                                    'Calculos()

                                    If dgvMov.Table.CurrentRecord.GetValue("importeMN") = 0 Then



                                        dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
                                        dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
                                        dgvMov.Table.CurrentRecord.SetValue("action", "inactivo")
                                    Else


                                        saldoFinalmn = saldoCompramn - valAbonomn
                                        saldoFinalme = saldoComprame - valAbonome
                                        Dim dinerodev As Decimal = dgvMov.Table.CurrentRecord.GetValue("dineroDev")
                                        Dim dinerodevme As Decimal = dgvMov.Table.CurrentRecord.GetValue("dineroDevme")

                                        Dim saldox As Decimal = dgvMov.Table.CurrentRecord.GetValue("importeMN")
                                        Dim saldoxme As Decimal = dgvMov.Table.CurrentRecord.GetValue("importeME")

                                        If saldoFinalmn < 0 Then
                                            dgvMov.Table.CurrentRecord.SetValue("ValDevmn", saldoFinalmn * -1)
                                            dgvMov.Table.CurrentRecord.SetValue("ValDevme", saldoFinalme * -1)
                                            dgvMov.Table.CurrentRecord.SetValue("action", "activo")
                                        ElseIf saldoFinalmn = 0 Then

                                            dgvMov.Table.CurrentRecord.SetValue("ValDevmn", dinerodev)
                                            dgvMov.Table.CurrentRecord.SetValue("ValDevme", dinerodevme)
                                            dgvMov.Table.CurrentRecord.SetValue("action", "activo")

                                        Else
                                            saldoFinalmn = saldox - valAbonomn
                                            saldoFinalme = saldoxme - valAbonome

                                            dgvMov.Table.CurrentRecord.SetValue("ValDevmn", saldoFinalmn * -1)
                                            dgvMov.Table.CurrentRecord.SetValue("ValDevme", saldoFinalme * -1)
                                            dgvMov.Table.CurrentRecord.SetValue("action", "activo")

                                        End If


                                    End If


                                End If
                                Calculos()
                        End Select
                    Else
                        dgvMov.Table.CurrentRecord.SetValue("vcmn", 0)
                        dgvMov.Table.CurrentRecord.SetValue("vcme", 0)
                        dgvMov.Table.CurrentRecord.SetValue("ValDevmn", 0)
                        dgvMov.Table.CurrentRecord.SetValue("ValDevme", 0)
                        Calculos()
                        'Throw New Exception("El importe de la nota supera al importe de compra, " & ventaOriginalMN.ToString("N2"))
                        'Throw New Exception("El importe de la nota supera al importe de compra, " & saldoCompramn.ToString("N2"))
                        Throw New Exception("El importe de la nota supera al importe de compra, ")
                    End If
                End If

                'End If


                ' Case 16
                'Case 21
                'dgvMov.Table.CurrentRecord.SetValue("ValDevmn", CDec(dgvMov.Table.CurrentRecord.GetValue("totalmn")))
                'dgvMov.Table.CurrentRecord.SetValue("ValDevme", CDec(dgvMov.Table.CurrentRecord.GetValue("totalme")))

                'TotalTalesXcolumna()

                'End Select
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    

    Private Sub dgvMov_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles dgvMov.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        Dim detalleSA As New DocumentoCompraDetalleSA
        Dim TC As Decimal = TmpTipoCambio
        Dim objConfiEO As New listadoPrecios
        Dim ListadoSA As New ListadoPrecioSA
        Dim totalesAlmacenSA As New TotalesAlmacenSA
        Dim ListaPrecioFull As New List(Of listadoPrecios)

        'Dim tipoExistencia As String
        'Dim destinoGravado As String
        'Dim presentacion As String
        'Dim unidad As String

        '.importeSoles = CDec(dgvMov.Table.CurrentRecord.GetValue("vcmn")),
        '                                      .importeDolares = CDec(dgvMov.Table.CurrentRecord.GetValue("vcme"))}

        Dim items As New listadoPrecios
        '.idEstablecimiento = GEstableciento.IdEstablecimiento,
        '.idItem = Val(dgvMov.Table.CurrentRecord.GetValue("idItem")),
        '.cantidad = CDec(dgvMov.Table.CurrentRecord.GetValue("canDev")),
        '.importeSoles = CDec(dgvMov.Table.CurrentRecord.GetValue("vcmn")),
        '.importeDolares = CDec(dgvMov.Table.CurrentRecord.GetValue("vcme"))})
        Try

            If e.Inner.ColIndex = 33 Then
                dgvMov.Table.Records(e.Inner.RowIndex - 3).SetCurrent()
                'dgvMov.Table.Records(e.Inner.RowIndex - 3).SetSelected(True)
                'dgvMov.Table.Records(e.Inner.RowIndex).SetCurrent("canDev")
                Dim cantActualizada = CDec(dgvMov.TableModel(e.Inner.RowIndex, 8).CellValue)
                Dim BaseActualizada = CDec(dgvMov.TableModel(e.Inner.RowIndex, 9).CellValue)
                Dim rowIdItem = Val(dgvMov.TableModel(e.Inner.RowIndex, 31).CellValue)
                Dim rowCantidad = CDec(dgvMov.TableModel(e.Inner.RowIndex, 17).CellValue)
                Dim rowImporteSoles = CDec(dgvMov.TableModel(e.Inner.RowIndex, 18).CellValue)
                Dim rowImporteDolares = CDec(dgvMov.TableModel(e.Inner.RowIndex, 22).CellValue)
                Dim secuenciaCompra = detalleSA.GetUbicar_documentocompradetallePorID(dgvMov.TableModel(e.Inner.RowIndex, 34).CellValue)

                Select Case dgvMov.Table.CurrentRecord.GetValue("tipoEx")
                    Case "GS"
                        Dim t = New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                          .idItem = rowIdItem,
                                          .cantidad = rowCantidad,
                                          .importeSoles = rowImporteSoles,
                                          .importeDolares = rowImporteDolares}

                        Dim f As New frmModalNotaCreditoGastos(t)
                        f.cboMotivo.Enabled = True
                        f.txtBaseDev.Text = BaseActualizada.ToString("N2")
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog()
                        If Not IsNothing(f.Tag) Then
                            Dim c = CType(f.Tag, totalesAlmacen)
                            Dim rowSelec As Record = dgvMov.Table.CurrentRecord
                            rowSelec.SetValue("canDev", 0)
                            rowSelec.SetValue("vcmn", c.importeSoles)
                            rowSelec.SetValue("vcme", c.importeSoles / TmpTipoCambio)
                            rowSelec.SetValue("almacenRef", 0)
                            rowSelec.SetValue("cboMov", c.TipoAcces)
                            FilaCalculada(sender)
                        End If


                    Case Else
                        Dim t = New totalesAlmacen With
                            {
                            .idEmpresa = Gempresas.IdEmpresaRuc,
                            .idEstablecimiento = GEstableciento.IdEstablecimiento,
                            .idItem = rowIdItem,
                            .cantidad = rowCantidad,
                            .importeSoles = rowImporteSoles,
                            .importeDolares = rowImporteDolares,
                            .codigoLote = secuenciaCompra.codigoLote
                        }

                        Dim f As New frmModalStockArticuloAlmacen(t)
                        f.cboMotivo.Enabled = True
                        f.txtCanDev.Text = cantActualizada.ToString("N2")
                        f.txtBaseDev.Text = BaseActualizada.ToString("N2")
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog()
                        If Not IsNothing(f.Tag) Then
                            Dim c = CType(f.Tag, totalesAlmacen)
                            Dim rowSelec As Record = dgvMov.Table.CurrentRecord

                            If c.TipoAcces = "4" Then

                                rowSelec.SetValue("vcmn", c.importeSoles)
                                rowSelec.SetValue("vcme", c.importeSoles / TmpTipoCambio)
                                rowSelec.SetValue("cboMov", c.TipoAcces)
                            Else


                                rowSelec.SetValue("canDev", c.cantidad)
                                rowSelec.SetValue("vcmn", c.importeSoles)
                                rowSelec.SetValue("vcme", c.importeSoles / TmpTipoCambio)
                                rowSelec.SetValue("almacenRef", c.idAlmacen)
                                rowSelec.SetValue("cboMov", c.TipoAcces)
                            End If

                            FilaCalculada(sender)
                            End If
                End Select

            ElseIf e.Inner.ColIndex = 23 Then

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvMov_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles dgvMov.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 33 Then
                e.Inner.Style.Description = "btSelec"
                Dim sButtonText As String = e.Inner.Style.Description
                e.Inner.Style.Description = String.Empty
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)

                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3), New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6))

                e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
            End If

        End If
    End Sub

    Private Sub dgvMov_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvMov.TableControlCellClick

    End Sub
End Class