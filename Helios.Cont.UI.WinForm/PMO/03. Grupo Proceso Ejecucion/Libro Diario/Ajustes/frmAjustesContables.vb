Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Tools
Public Class frmAjustesContables
    Inherits frmMaster
    Public Property TotalesXcanbeceras As TotalesXcanbecera
    Public Property tipoCambio() As Decimal
    Public Property IdCompraOrigen() As Integer
    Public Property ListaAsientonTransito As New List(Of asiento)

    Public Sub New(IntIdDocumento As Integer)

        ' This call is required by the designer.
        InitializeComponent()
        configuracionModuloV2(Gempresas.IdEmpresaRuc, "AST", Me.Text, GEstableciento.IdEstablecimiento)
        ' Add any initialization after the InitializeComponent() call.
        dgvCuenta.DataSource = GetTableGrid()
        GridCFG(dgvCuenta)
        ConfiguracionInicio()
        UbicarDetalle(IntIdDocumento)
    End Sub
    Dim colorx As New GridMetroColors()

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

        'GGC.BrowseOnly = True
        'GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        'GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        'GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
        'GGC.TableOptions.SelectionBackColor = Color.Gray
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

        GGC.Table.DefaultColumnHeaderRowHeight = 25
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Private Function GetTableGrid() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("Modulo", GetType(String))
        dt.Columns.Add("importeMN", GetType(Decimal))
        dt.Columns.Add("importeME", GetType(Decimal))
        dt.Columns.Add("HaberMN", GetType(Decimal))
        dt.Columns.Add("HaberME", GetType(Decimal))
        dt.Columns.Add("tipoAsiento", GetType(String))
        dt.Columns.Add("cuenta", GetType(String))
        Return dt
    End Function

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
    Sub AsientoNotaCreditoNormal(ListaExistencias As List(Of documentocompradetalle))
        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento


        Dim SumaCliente = Aggregate n In ListaExistencias _
           Into totalMN = Sum(n.importe),
           totalME = Sum(n.importeUS)

        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = txtProveedor.Tag
        nAsiento.nombreEntidad = txtProveedor.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "1"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.AjustesContables
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.importeMN = SumaCliente.totalMN.GetValueOrDefault
        nAsiento.importeME = SumaCliente.totalME.GetValueOrDefault
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now
        ListaAsientonTransito.Add(nAsiento)

        nAsiento.movimiento.Add(AS_Proveedor(SumaCliente.totalMN.GetValueOrDefault, SumaCliente.totalME.GetValueOrDefault))
        For Each i In ListaExistencias
            nAsiento.movimiento.Add(AS_Default(Nothing, i.montokardex, i.montokardexUS, i.tipoExistencia, i.descripcionItem))
            MV_Item_Transito(i.descripcionItem, i.montokardex, i.montokardexUS, i.tipoExistencia)
        Next

        Dim SumaIGV = Aggregate n In ListaExistencias _
                  Into IGVmn = Sum(n.montoIgv),
                  IGVme = Sum(n.montoIgvUS)

        nAsiento.movimiento.Add(AS_IGV(SumaIGV.IGVmn.GetValueOrDefault, SumaIGV.IGVme.GetValueOrDefault))


    End Sub

    Sub AsientoNotaCreditoNormalServicio(ListaServicios As List(Of documentocompradetalle))

        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento

        Dim SumaCliente = Aggregate n In ListaServicios _
             Into totalMN = Sum(n.importe),
             totalME = Sum(n.importeUS)

        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = txtProveedor.Tag
        nAsiento.nombreEntidad = txtProveedor.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "1"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.AjustesContables
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
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = txtProveedor.Tag
        nAsiento.nombreEntidad = txtProveedor.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "1"
        nAsiento.importeMN = SumaCliente.totalMN.GetValueOrDefault
        nAsiento.importeME = SumaCliente.totalME.GetValueOrDefault
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.AjustesContables

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
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = txtProveedor.Tag
        nAsiento.nombreEntidad = txtProveedor.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "1"
        nAsiento.importeMN = SumaCliente.totalMN.GetValueOrDefault
        nAsiento.importeME = SumaCliente.totalME.GetValueOrDefault
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.AjustesContables

        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.usuarioActualizacion = "jiuni"
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

    Sub AsientoNotaCreditoExcedente(ListaExistencias As List(Of documentocompradetalle))
        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento

        Dim SumaCliente = Aggregate n In ListaExistencias _
                  Into totalMN = Sum(n.importe),
                  totalME = Sum(n.importeUS)

        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = txtProveedor.Tag
        nAsiento.nombreEntidad = txtProveedor.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "1"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.AjustesContables
        nAsiento.importeMN = SumaCliente.totalMN.GetValueOrDefault
        nAsiento.importeME = SumaCliente.totalME.GetValueOrDefault
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.usuarioActualizacion = "jiuni"
        nAsiento.fechaActualizacion = DateTime.Now
        ListaAsientonTransito.Add(nAsiento)
        '------------------------------------------

        nAsiento.movimiento.Add(Ad_prov_Excedente(SumaCliente.totalMN.GetValueOrDefault, SumaCliente.totalME.GetValueOrDefault))
        For Each i In ListaExistencias
            MV_Item_Transito(i.descripcionItem, i.montokardex, i.montokardexUS, i.tipoExistencia)
            nAsiento.movimiento.Add(AS_Default(Nothing, i.montokardex, i.montokardexUS, i.tipoExistencia, i.descripcionItem))
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
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = txtProveedor.Tag
        nAsiento.nombreEntidad = txtProveedor.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "1"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.AjustesContables
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
            MV_Item_Transito(i.descripcionItem, i.montokardex, i.montokardexUS, i.tipoExistencia)
            nAsiento.movimiento.Add(AS_Default(Nothing, i.montokardex, i.montokardexUS, i.tipoExistencia, i.descripcionItem))
        Next
        Dim SumaIGV = Aggregate n In ListaExistencias _
           Into IGVmn = Sum(n.montoIgv),
           IGVme = Sum(n.montoIgvUS)

        nAsiento.movimiento.Add(AS_IGV(SumaIGV.IGVmn.GetValueOrDefault, SumaIGV.IGVme.GetValueOrDefault))


    End Sub

    Public Function Ad_prov_Excedente(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento
        nMovimiento.cuenta = "16"
        nMovimiento.descripcion = txtProveedor.Text
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = "Jiuni"

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
              .usuarioActualizacion = "Jiuni"}

        Return nMovimiento
    End Function

    Public Function AS_Proveedor(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento
        'If CDec(TotalesXcanbeceras.importeDevmn) > 0 Then
        '    nMovimiento.cuenta = "16"
        'Else
        nMovimiento.cuenta = "4212"
        '  End If
        nMovimiento.descripcion = txtProveedor.Text
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = "Jiuni"

        Return nMovimiento
    End Function

    Sub AsientoNotaCredito(consultaAsiento As List(Of documentocompradetalle))
        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento

        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = txtProveedor.Tag
        nAsiento.nombreEntidad = txtProveedor.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "1"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.AjustesContables
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
        nMovimiento.usuarioActualizacion = "Jiuni"

        Return nMovimiento
    End Function

    Public Function AsientoTransito(cMonto As Decimal, cMontoUS As Decimal) As asiento
        Dim nAsiento As New asiento
        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = CInt(txtProveedor.Tag)
        nAsiento.nombreEntidad = txtProveedor.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "8"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.PRODUCTOS_EN_TRANSITO
        nAsiento.importeMN = cMonto
        nAsiento.importeME = cMontoUS
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.usuarioActualizacion = "jiuni"
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
        nMovimiento.usuarioActualizacion = "Jiuni"
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
        nMovimiento.usuarioActualizacion = "Jiuni"
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

        ef = efSA.GetUbicar_estadosFinancierosPorID(GFichaUsuarios.IdCajaDestino)
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
        nDocumentoCaja.usuarioActualizacion = "Jiuni"
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
        objCaja.periodo = PeriodoGeneral
        objCaja.NumeroDocumento = Nothing ' IIf(txtNumCaja.Text.Trim.Length > 0, txtNumCaja.Text, Nothing)
        objCaja.moneda = "1" ' txtCodMoneda.Text ' IIf(cboMoneda.Text = "MONEDA NACIONAL (SOLES)", "SOL", "USD")
        objCaja.tipoCambio = CDec(txtTipoCambio.Text)
        objCaja.glosa = txtGlosa.Text.Trim
        objCaja.entregado = "SI"
        objCaja.entidadFinanciera = ef.idestado
        objCaja.usuarioModificacion = GFichaUsuarios.IdCajaUsuario
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
            objCajaDetalle.usuarioModificacion = GFichaUsuarios.IdCajaUsuario
            objCajaDetalle.fechaModificacion = DateTime.Now
            ListaDetalle.Add(objCajaDetalle)
        Next

        nDocumentoCaja.documentoCaja.montoSoles = sumMN
        nDocumentoCaja.documentoCaja.montoUsd = sumME
        nDocumentoCaja.documentoCaja.documentoCajaDetalle = ListaDetalle


        'ASIENTO CONTABLE

        asiento = New asiento
        With asiento
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
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With

        nMovimiento = New movimiento
        nMovimiento.cuenta = ef.cuenta
        nMovimiento.descripcion = ef.descripcion
        nMovimiento.tipo = "D"
        nMovimiento.monto = sumMN
        nMovimiento.montoUSD = sumME
        nMovimiento.usuarioActualizacion = "Jiuni"
        nMovimiento.fechaActualizacion = DateTime.Now
        asiento.movimiento.Add(nMovimiento)


        nMovimiento = New movimiento
        nMovimiento.cuenta = "16"
        nMovimiento.descripcion = ef.descripcion
        nMovimiento.tipo = "H"
        nMovimiento.monto = sumMN
        nMovimiento.montoUSD = sumME
        nMovimiento.usuarioActualizacion = "Jiuni"
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


        ef = efSA.GetUbicar_estadosFinancierosPorID(GFichaUsuarios.IdCajaDestino)
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
        nDocumentoCaja.usuarioActualizacion = "Jiuni"
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
        objCaja.periodo = PeriodoGeneral
        objCaja.NumeroDocumento = Nothing ' IIf(txtNumCaja.Text.Trim.Length > 0, txtNumCaja.Text, Nothing)
        objCaja.moneda = "1" ' txtCodMoneda.Text ' IIf(cboMoneda.Text = "MONEDA NACIONAL (SOLES)", "SOL", "USD")
        objCaja.tipoCambio = CDec(txtTipoCambio.Text)

        objCaja.glosa = txtGlosa.Text.Trim
        objCaja.entregado = "SI"
        objCaja.entidadFinanciera = ef.idestado
        objCaja.usuarioModificacion = GFichaUsuarios.IdCajaUsuario
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
            objCajaDetalle.usuarioModificacion = GFichaUsuarios.IdCajaUsuario
            objCajaDetalle.fechaModificacion = DateTime.Now
            ListaDetalle.Add(objCajaDetalle)
        Next
        nDocumentoCaja.documentoCaja.montoSoles = sumMN
        nDocumentoCaja.documentoCaja.montoUsd = sumME

        nDocumentoCaja.documentoCaja.documentoCajaDetalle = ListaDetalle


        'ASIENTO CONTABLE

        asiento = New asiento
        With asiento
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCostos = GEstableciento.IdEstablecimiento
            .idEntidad = txtProveedor.Tag
            .nombreEntidad = txtProveedor.Text
            .tipoEntidad = "CL"
            .fechaProceso = txtFecha.Value
            .codigoLibro = "14"
            .tipo = "D"
            .tipoAsiento = "AS-NTC"
            .importeMN = sumMN ' TotalesXcanbeceras.SaldoVentaMN
            .importeME = sumME ' TotalesXcanbeceras.SaldoVentaME
            .glosa = txtGlosa.Text.Trim
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With

        nMovimiento = New movimiento
        nMovimiento.cuenta = "4212"
        nMovimiento.descripcion = txtProveedor.Text
        nMovimiento.tipo = "D"
        nMovimiento.monto = sumMN ' TotalesXcanbeceras.SaldoVentaMN
        nMovimiento.montoUSD = sumME ' TotalesXcanbeceras.SaldoVentaME
        nMovimiento.usuarioActualizacion = "Jiuni"
        nMovimiento.fechaActualizacion = DateTime.Now
        asiento.movimiento.Add(nMovimiento)


        nMovimiento = New movimiento
        nMovimiento.cuenta = ef.cuenta
        nMovimiento.descripcion = txtProveedor.Text
        nMovimiento.tipo = "H"
        nMovimiento.monto = sumMN ' TotalesXcanbeceras.SaldoVentaMN
        nMovimiento.montoUSD = sumME 'TotalesXcanbeceras.SaldoVentaME
        nMovimiento.usuarioActualizacion = "Jiuni"
        nMovimiento.fechaActualizacion = DateTime.Now
        asiento.movimiento.Add(nMovimiento)

        ListaAsientonTransito.Add(asiento)

        Return nDocumentoCaja
    End Function

    'Sub GuiaRemision(objDocumentoCompra As documento, Lista As List(Of documentocompradetalle))
    '    Dim guiaRemisionBE As New documentoGuia
    '    Dim documentoguiaDetalle As New documentoguiaDetalle
    '    Dim ListaGuiaDetalle As New List(Of documentoguiaDetalle)
    '    'REGISTRANDO LA GUIA DE REMISION
    '    With guiaRemisionBE
    '        .idDocumento = 0
    '        .codigoLibro = "8"
    '        .idEmpresa = Gempresas.IdEmpresaRuc
    '        .idCentroCosto = GEstableciento.IdEstablecimiento
    '        .fechaDoc = txtFecha.Value
    '        .periodo = PeriodoGeneral
    '        .tipoDoc = "99"
    '        .idEntidad = CInt(txtProveedor.Tag)
    '        .monedaDoc = IIf(txtMon.Text = 1, "1", "2")
    '        .tasaIgv = CDec(txtIva.Text)
    '        .tipoCambio = CDec(txtTipoCambio.Text)
    '        .importeMN = TotalesXcanbeceras.TotalMN
    '        .importeME = TotalesXcanbeceras.TotalMN
    '        .glosa = txtGlosa.Text.Trim
    '        .usuarioActualizacion = "Jiuni"
    '        .fechaActualizacion = DateTime.Now
    '    End With
    '    objDocumentoCompra.documentoGuia = guiaRemisionBE

    '    For Each r As documentocompradetalle In Lista

    '        If r.tipoExistencia <> "GS" Then
    '            'If r.GetValue("almacen") <> idAlmacenVirtual Then
    '            documentoguiaDetalle = New documentoguiaDetalle
    '            If txtSerieGuia.Text.Trim.Length > 0 Then
    '                'objDocumentoCompra.documentoGuia.serie = String.Format("{0:00000}", Convert.ToInt32(txtSerieGuia.Text))
    '                objDocumentoCompra.documentoGuia.serie = txtSerieGuia.Text
    '            Else
    '                Throw New Exception("Ingrese número de serie de la guía!")
    '                'MessageBoxAdv.Show("Ingrese número de serie de la guía!")
    '                'Exit Sub
    '            End If
    '            If txtNumeroGuia.Text.Trim.Length > 0 Then
    '                objDocumentoCompra.documentoGuia.numeroDoc = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumeroGuia.Text))
    '            Else
    '                Throw New Exception("Ingrese número de la guía!")
    '                'MessageBoxAdv.Show("Ingrese número de la guía!")
    '                'Exit Sub
    '            End If
    '            documentoguiaDetalle.idDocumento = 0
    '            documentoguiaDetalle.idItem = r.idItem
    '            documentoguiaDetalle.descripcionItem = r.descripcionItem
    '            documentoguiaDetalle.destino = r.destino
    '            documentoguiaDetalle.unidadMedida = Nothing  'r.GetValue("um")
    '            documentoguiaDetalle.cantidad = r.monto1
    '            documentoguiaDetalle.precioUnitario = r.precioUnitario
    '            documentoguiaDetalle.precioUnitarioUS = r.precioUnitarioUS
    '            documentoguiaDetalle.importeMN = r.importe
    '            documentoguiaDetalle.importeME = r.importeUS
    '            documentoguiaDetalle.almacenRef = r.almacenRef
    '            documentoguiaDetalle.usuarioModificacion = "Jiuni"
    '            documentoguiaDetalle.fechaModificacion = DateTime.Now
    '            ListaGuiaDetalle.Add(documentoguiaDetalle)
    '        End If

    '    Next
    '    objDocumentoCompra.documentoGuia.documentoguiaDetalle = ListaGuiaDetalle
    'End Sub
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
    '                        txtSerie.Text = .serie
    '                        'txtSerieComp.Visible = True
    '                        'txtSerieComp.Text = .serie
    '                        'txtNumeroComp.Visible = False
    '                        'txtIdComprobante.Text = GConfiguracion.TipoComprobante
    '                        'txtComprobante.Text = GConfiguracion.NombreComprobante
    '                        'LinkTipoDoc.Enabled = False
    '                        'txtSerieComp.Enabled = False
    '                    End With
    '                Case "M"
    '                    'txtSerieComp.Visible = True
    '                    'txtNumeroComp.Visible = True
    '                    'LinkTipoDoc.Enabled = True
    '                    'txtSerieComp.Enabled = True
    '            End Select
    '            If Not IsNothing(.configAlmacen) Then
    '                Dim estableSA As New establecimientoSA
    '                With almacenSA.GetUbicar_almacenPorID(.configAlmacen)
    '                    GConfiguracion.IdAlmacen = .idAlmacen
    '                    GConfiguracion.NombreAlmacen = .descripcionAlmacen

    '                    'txtAlmacen.Text = GConfiguracion.NombreAlmacen
    '                    'txtIdAlmacen.Text = GConfiguracion.IdAlmacen
    '                    With estableSA.UbicaEstablecimientoPorID(.idEstablecimiento)
    '                        'txtIdEstableAlmacen.Text = .idCentroCosto
    '                        'txtEstableAlmacen.Text = .nombre
    '                    End With
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
    '        '    lblEstado.Text = "Este módulo no contiene una configuración disponible, intentelo más tarde.!"
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

    Sub Grabar()
        Dim documentoLibroDiario As New documentoLibroDiario
        Dim documentoLibroDiarioDetalle As New documentoLibroDiarioDetalle
        Dim ListaDetalle As New List(Of documentoLibroDiarioDetalle)

        Dim CompraSA As New documentoLibroDiarioSA
        Dim ndocumento As New documento()

        ''''''''''' LIMPIANDO VARIABLES---------------------

        ListaAsientonTransito = New List(Of asiento)

        With ndocumento
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If Not IsNothing(GProyectos) Then
                .idProyecto = GProyectos.IdProyectoActividad
            End If
            .tipoDoc = "9901"
            .fechaProceso = txtFecha.Value
            .nroDoc = txtSerie.Text & "-" & txtNumero.Text.Trim
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = "02"
            .usuarioActualizacion = "NN"
            .fechaActualizacion = DateTime.Now
        End With

        documentoLibroDiario = New documentoLibroDiario With {
               .TipoConfiguracion = GConfiguracion.TipoConfiguracion,
        .IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante),
            .idEmpresa = Gempresas.IdEmpresaRuc,
        .idEstablecimiento = GEstableciento.IdEstablecimiento,
        .tipoRegistro = "AJU",
        .fecha = txtFecha.Value,
        .fechaPeriodo = PeriodoGeneral,
        .infoReferencial = txtGlosa.Text,
        .razonSocial = CInt(txtProveedor.Tag),
        .tipoDoc = "9901",
        .nroDoc = Nothing,
        .tipoOperacion = "02",
        .moneda = IIf(txtMon.Text = 1, "1", "2"),
        .tipoCambio = txtTipoCambio.Text,
        .importeMN = TotalesXcanbeceras.TotalMN,
        .importeME = TotalesXcanbeceras.TotalME,
        .idReferencia = IdCompraOrigen,
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = DateTime.Now
        }
        ndocumento.documentoLibroDiario = documentoLibroDiario

        For Each r As Record In dgvMov.Table.Records
            documentoLibroDiarioDetalle = New documentoLibroDiarioDetalle With {
                .secuencia = r.GetValue("sec"),
                .cuenta = r.GetValue("sec"),
            .idItem = r.GetValue("idItem"),
            .descripcion = r.GetValue("item"),
            .tipoAsiento = Nothing,
            .importeMN = CDec(r.GetValue("totalmn")),
            .importeME = CDec(r.GetValue("totalme")),
            .Evento = Nothing,
            .idEvento = Nothing,
            .cuentaPadre = Nothing,
            .idEstablecimiento = Nothing,
            .entregadoCancelado = Nothing,
            .usuarioActualizacion = usuario.IDUsuario,
            .fechaActualizacion = DateTime.Now
            }
            ListaDetalle.Add(documentoLibroDiarioDetalle)
        Next
        ndocumento.documentoLibroDiario.documentoLibroDiarioDetalle = ListaDetalle
        '---------------------------------------------------------------------------------
        ndocumento.asiento = ListaAsientonTransito



        Dim xcod As Integer = CompraSA.GrabarAjustes(ndocumento)
        lblEstado.Text = "nota de crédito registrada!"
        Dispose()
    End Sub

    Public Class TotalesXcanbecera
        Public Property BaseMN() As Decimal
        Public Property BaseME() As Decimal
        Public Property IgvMN() As Decimal
        Public Property IgvME() As Decimal
        Public Property TotalMN() As Decimal
        Public Property TotalME() As Decimal
        Public Property base1() As Decimal
        Public Property base1me() As Decimal
        Public Property base2() As Decimal
        Public Property base2me() As Decimal
        Public Property MontoIgv1() As Decimal
        Public Property MontoIgv1me() As Decimal
        Public Property MontoIgv2() As Decimal
        Public Property MontoIgv2me() As Decimal

        Public Property importeDevmn() As Decimal
        Public Property importeDevme() As Decimal

        Public Property SaldoVentaMN() As Decimal
        Public Property SaldoVentaME() As Decimal

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

    End Sub

    Public Sub UbicarDetalle(intIddocumento As Integer)
        Dim detalleSA As New DocumentoCompraDetalleSA
        Dim objLista As New DocumentoCajaDetalleSA
        Dim detalle As New documentocompradetalle
        Dim compraSA As New DocumentoCompraSA
        Dim entidadSA As New entidadSA
        Dim dt As New DataTable

        Dim cTotalmn As Decimal = 0
        Dim cTotalme As Decimal = 0
        Dim cCreditomn As Decimal = 0
        Dim cCreditome As Decimal = 0
        Dim cDebitomn As Decimal = 0
        Dim cDebitome As Decimal = 0

        Dim cCantidadNC As Decimal = 0
        Dim cCantidadDB As Decimal = 0
        Dim cTotalCantidad As Decimal = 0
        Dim saldoCantidad As Decimal = 0
        Try
            With compraSA.UbicarDocumentoCompra(intIddocumento)
                IdCompraOrigen = .idDocumento
                txtMon.Text = .monedaDoc
                txtTipoCambio.Text = .tcDolLoc
                txtTipoCambio.ReadOnly = True
                txtIva.Text = .tasaIgv
                txtImpFacmn.DecimalValue = .importeTotal
                txtImpFacme.DecimalValue = .importeUS
                txtTipoDoc.Text = .tipoDoc
            End With

            Dim saldomn As Decimal = 0
            Dim saldome As Decimal = 0

            dt.Columns.Add("sec", GetType(Integer))
            dt.Columns.Add("grav", GetType(String))
            dt.Columns.Add("idItem", GetType(Integer))
            dt.Columns.Add("item", GetType(String))
            dt.Columns.Add("cantidad", GetType(Decimal))
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
            dt.Columns.Add("montoIgv", GetType(Decimal))
            dt.Columns.Add("montoIgvUS", GetType(Decimal))

            dt.Columns.Add("totalmn", GetType(Decimal))
            dt.Columns.Add("totalme", GetType(Decimal))

            dt.Columns.Add("estadoPago", GetType(String))
            dt.Columns.Add("ValDevmn", GetType(Decimal))
            dt.Columns.Add("ValDevme", GetType(Decimal))
            dt.Columns.Add("action", GetType(String))

            For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorPagarPorDetails(intIddocumento)
                detalle = detalleSA.SumaNotasXidPadreItem(i.secuencia)

                saldoCantidad = i.CantidadCompra - detalle.monto1
                cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN
                cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS - CDec(i.MontoPagadoUSD) + detalle.ImporteDBME

                saldomn += cTotalmn
                saldome += cTotalme

                saldomn += cTotalmn
                saldome += cTotalme

                Dim dr As DataRow = dt.NewRow()
                dr(0) = i.secuencia
                dr(1) = i.destino
                dr(2) = i.idItem
                dr(3) = i.DetalleItem
                Select Case i.TipoExistencia
                    Case "GS"
                        dr(4) = 0
                    Case Else
                        If IsNothing(detalle) Then
                            dr(4) = 0
                        Else
                            dr(4) = i.CantidadCompra - detalle.monto1  ' detalle.monto1
                        End If
                End Select
                dr(5) = 0
                If cTotalmn < 0 Then
                    cTotalmn = 0
                End If
                dr(6) = cTotalmn
                dr(7) = 0
                If cTotalme < 0 Then
                    cTotalme = 0
                End If
                dr(8) = cTotalme
                dr(9) = i.TipoExistencia
                dr(10) = i.almacenRef

                dr(11) = i.CantidadCompra
                dr(12) = i.MontoDeudaSoles
                dr(13) = i.MontoDeudaUSD
                dr(14) = i.montokardex
                dr(15) = i.montokardexus
                dr(16) = i.montoIgv
                dr(17) = i.montoIgvUS
                dr(18) = 0
                dr(19) = 0
                Select Case i.EstadoCobro
                    Case TIPO_COMPRA.PAGO.PAGADO
                        dr(20) = "Pagado"
                    Case Else
                        dr(20) = "Pendiente"

                End Select
                dr(21) = 0
                dr(22) = 0
                dr(23) = "activo"
                dt.Rows.Add(dr)
            Next
            dgvMov.DataSource = dt
            dgvMov.TableModel.RowHeights.ResizeToFit(GridRangeInfo.Table(), GridResizeToFitOptions.ResizeCoveredCells)
            '    Me.dgvMov.TableOptions.ListBoxSelectionMode = SelectionMode.One

        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Sub ConfiguracionInicio()

        'configurando docking manager
        Me.WindowState = FormWindowState.Maximized
        'dockingManager1.DockControlInAutoHideMode(Panel8, DockingStyle.Right, 565)
        'dockingManager1.SetDockLabel(Panel8, "Compras")
        'dockingManager1.CloseEnabled = False
        'If Not IsNothing(GFichaUsuarios) Then
        ToolStripButton1.Image = ImageListAdv1.Images(1)
        'Else
        '    ToolStripButton1.Image = ImageListAdv1.Images(0)
        '    GFichaUsuarios = Nothing
        'End If
        dgvCompra.ShowRowHeaders = False
        'confgiurando variables generales
        lblPerido.Text = PeriodoGeneral
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

    Private Sub UbicarCompraXProveedorNroSerie(RucProveedor As String, strPeriodo As String)
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim documentoCompra As New List(Of documentocompra)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("tipoCompra", GetType(String))
        dt.Columns.Add("Fecha", GetType(String))
        dt.Columns.Add("periodo", GetType(String))

        dt.Columns.Add("TipoDoc", GetType(String))
        dt.Columns.Add("Serie", GetType(String))
        dt.Columns.Add("Numero", GetType(String))
        dt.Columns.Add("moneda", GetType(String))
        dt.Columns.Add("montoMN", GetType(Decimal))
        dt.Columns.Add("montoME", GetType(Decimal))

        documentoCompra = documentoCompraSA.UbicarCompraPorProveedorXperiodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, RucProveedor, strPeriodo)
        Dim str As String
        If Not IsNothing(documentoCompra) Then
            For Each i In documentoCompra
                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
                dr(0) = i.idDocumento
                dr(1) = i.tipoCompra
                dr(2) = str
                dr(3) = i.fechaContable
                dr(4) = tablaSA.GetUbicarTablaID(10, i.tipoDoc).descripcion.Substring(0, 3)
                dr(5) = i.serie
                dr(6) = i.numeroDoc
                Select Case i.monedaDoc
                    Case 1
                        dr(7) = "NAC"
                    Case Else
                        dr(7) = "EXT"
                End Select
                dr(8) = i.importeTotal
                dr(9) = i.importeUS
                dt.Rows.Add(dr)
            Next
            dgvCompra.DataSource = dt

        Else

        End If
    End Sub

#End Region

    Private Sub frmAjustesContables_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub


    Public Function GetTableAlmacen() As DataTable


        Dim cuentaSA As New cuentaplanContableEmpresaSA
        Dim dt As New DataTable()
        dt.Columns.Add("idCuenta", GetType(Integer))
        dt.Columns.Add("descripcionCuenta", GetType(String))

        For Each i In cuentaSA.ObtenerCuentasPorEmpresa(Gempresas.IdEmpresaRuc)
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.cuenta
            dr(1) = i.cuenta
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Dim comboTable As New DataTable
    Private Sub frmAjustesContables_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        comboTable = Me.GetTableAlmacen

        Dim ggcStyle As GridTableCellStyleInfo = dgvCuenta.TableDescriptor.Columns(2).Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = Me.comboTable
        ggcStyle.ValueMember = "idCuenta"
        ggcStyle.DisplayMember = "descripcionCuenta"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive


        dgvCompra.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        dgvCompra.ShowRowHeaders = False
    End Sub

    Private Sub popupControlContainer1_CloseUp(sender As Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs) Handles popupControlContainer1.CloseUp
        Me.Cursor = Cursors.WaitCursor
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                Me.txtProveedor.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                txtProveedor.Tag = lsvProveedor.SelectedItems(0).SubItems(0).Text
                txtRuc.Text = lsvProveedor.SelectedItems(0).SubItems(3).Text
                ' txtCuenta.Text = lsvProveedor.SelectedItems(0).SubItems(2).Text

                'UbicarCompraXProveedorNroSerie(txtRuc.Text, PeriodoGeneral)

            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
        Me.Cursor = Cursors.Arrow
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
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtSerie.Clear()
        End Try
    End Sub

    Private Sub txtSerie_LostFocus(sender As Object, e As EventArgs) Handles txtSerie.LostFocus
        Try
            If txtSerie.Text.Trim.Length > 0 Then
                '  If chFormato.Checked = True Then
                txtSerie.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerie.Text))
                'End If
            End If

        Catch ex As Exception

            If IsNumeric(Microsoft.VisualBasic.Mid(Trim(txtSerie.Text), 2, 1)) = True Then

                If IsNumeric(Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 1)) = True Then

                    If Not IsNumeric(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1)) = True Then

                        If Len(txtSerie.Text) <= 2 Then

                            txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + "000" + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 1))

                        ElseIf Len(txtSerie.Text) <= 3 Then

                            txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + "00" + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 2))

                        ElseIf Len(txtSerie.Text) <= 4 Then

                            txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + "0" + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 3))

                        ElseIf Len(txtSerie.Text) <= 5 Then

                            txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 4))

                        End If
                    End If
                Else

                    txtSerie.Select()
                    txtSerie.Focus()
                    txtSerie.Clear()
                    lblEstado.Text = "INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO"
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)

                End If

            Else

                txtSerie.Select()
                txtSerie.Focus()
                txtSerie.Clear()
                lblEstado.Text = "INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
            End If

        End Try
    End Sub

    Private Sub txtSerie_TextChanged(sender As Object, e As EventArgs) Handles txtSerie.TextChanged

    End Sub

    Private Sub dgvCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompra.TableControlCellClick

    End Sub

    Private Sub dgvCompra_TableControlCurrentCellControlDoubleClick(sender As Object, e As GridTableControlControlEventArgs) Handles dgvCompra.TableControlCurrentCellControlDoubleClick
        Dim DocumentoCompraSA As New DocumentoCompraDetalleSA
        Me.Cursor = Cursors.WaitCursor
        If DocumentoCompraSA.TieneItemsEnAV(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento")) = True Then
            PanelError.Visible = True
            lblEstado.Text = "El comprobante posee items en el almacen en transito, " & "necesita realizar la distribución, para seguir el proceso!"
            Timer1.Enabled = True
            TiempoEjecutar(10)
            Me.Cursor = Cursors.Arrow
        Else
            UbicarDetalle(dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvMov_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvMov.QueryCellStyleInfo
        If Not IsNothing(e.TableCellIdentity.Column) Then
            Dim el As Syncfusion.Grouping.Element = e.TableCellIdentity.DisplayElement

            If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "canDev")) Then

                Dim str = Me.dgvMov.TableModel(e.TableCellIdentity.RowIndex, 11).CellValue
                If Not IsNothing(str) Then
                    Select Case str
                        Case "3" '  "DEVOLUCION DE EXISTENCIAS"
                            e.Style.[ReadOnly] = False
                            ''e.Style.BackColor = Color.AliceBlue
                            '        Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 15).CellValue = Nothing
                        Case "1" ' "DISMINUIR CANTIDAD"
                            e.Style.[ReadOnly] = False
                            'e.Style.BackColor = Color.AliceBlue

                        Case "2" '"DISMINUIR IMPORTE"
                            e.Style.[ReadOnly] = True
                            'e.Style.BackColor = Color.AliceBlue
                    End Select
                End If


            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "vcmn")) Then
                Dim str = Me.dgvMov.TableModel(e.TableCellIdentity.RowIndex, 11).CellValue
                If Not IsNothing(str) Then
                    Select Case str
                        Case "3" '  "DEVOLUCION DE EXISTENCIAS"
                            e.Style.[ReadOnly] = False
                            'e.Style.BackColor = Color.AliceBlue
                            '        Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 15).CellValue = Nothing
                        Case "1" ' "DISMINUIR CANTIDAD"
                            e.Style.[ReadOnly] = True
                            'e.Style.BackColor = Color.AliceBlue

                        Case "2" '"DISMINUIR IMPORTE"
                            e.Style.[ReadOnly] = False
                            'e.Style.BackColor = Color.AliceBlue
                    End Select
                End If


            Else
                'e.Style.[ReadOnly] = False
            End If
        End If
    End Sub

    Private Sub dgvMov_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvMov.TableControlCellClick

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
        '   cantidad = Me.dgvMov.Table.CurrentRecord.GetValue("canDev")
        '   Me.dgvMov.Table.CurrentRecord.SetValue("canDev", cantidad.ToString("N2"))
        VC = 0 ' Me.dgvMov.Table.CurrentRecord.GetValue("vcmn")
        VCme = 0 ' Math.Round(VC / CDec(txtTipoCambio.Text), 2)
        If cantidad > 0 AndAlso VC > 0 Then
            Igv = 0 ' Math.Round(VC * CDec(txtIva.Text), 2)
            IgvME = 0 ' Math.Round(VCme * CDec(txtIva.Text), 2)

            colBI = VC + Igv
            colBIme = VCme + IgvME

            colPrecUnit = 0 ' Math.Round(VC / cantidad, 2)
            colPrecUnitme = 0 ' Math.Round(VCme / cantidad, 2)
        ElseIf cantidad = 0 Then
            Igv = 0 ' Math.Round(VC * CDec(txtIva.Text), 2)
            IgvME = 0 ' Math.Round(VCme * CDec(txtIva.Text), 2)
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
        Me.dgvMov.Table.CurrentRecord.SetValue("totalmn", Me.dgvMov.Table.CurrentRecord.GetValue("totalmn"))
        Me.dgvMov.Table.CurrentRecord.SetValue("totalme", Me.dgvMov.Table.CurrentRecord.GetValue("totalme"))

        TotalTalesXcolumna()
    End Sub
    Private Sub dgvMov_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvMov.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Try
            If Not IsNothing(Me.dgvMov.Table.CurrentRecord) Then
                Select Case ColIndex
                    Case 11
                        Calculos()

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

                        saldoCompramn = CDec(dgvMov.Table.CurrentRecord.GetValue("importeMN"))
                        saldoComprame = CDec(dgvMov.Table.CurrentRecord.GetValue("importeME"))

                        valAbonomn = dgvMov.Table.CurrentRecord.GetValue("totalmn")
                        valAbonome = dgvMov.Table.CurrentRecord.GetValue("totalme")
                        If valAbonomn > saldoCompramn Then
                            Throw New Exception("El importe no debe ser mayor al saldo de la compra")
                        End If
                        saldoFinalmn = saldoCompramn - valAbonomn
                        saldoFinalme = saldoComprame - valAbonome
                        Calculos()

                    Case 12


                        Calculos()

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

                        saldoCompramn = CDec(dgvMov.Table.CurrentRecord.GetValue("importeMN"))
                        saldoComprame = CDec(dgvMov.Table.CurrentRecord.GetValue("importeME"))

                        valAbonomn = dgvMov.Table.CurrentRecord.GetValue("totalmn")
                        valAbonome = dgvMov.Table.CurrentRecord.GetValue("totalme")
                        If valAbonomn > saldoCompramn Then
                            Throw New Exception("El importe no debe ser mayor al saldo de la compra")
                        End If
                        saldoFinalmn = saldoCompramn - valAbonomn
                        saldoFinalme = saldoComprame - valAbonome
                        Calculos()

                End Select
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Private Sub Panel9_Paint(sender As Object, e As PaintEventArgs) Handles Panel9.Paint

    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        Try
            If dgvMov.Table.Records.Count > 0 Then
                Grabar()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try

    End Sub

    Private Sub txtNumero_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumero.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                'cboMoneda.Select()
                txtProveedor.Select()
                'txtProveedor.Focus()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtNumero.Clear()
        End Try
    End Sub

    Private Sub txtNumero_LostFocus(sender As Object, e As EventArgs) Handles txtNumero.LostFocus
        Try
            If txtNumero.Text.Trim.Length > 0 Then
                '    If chFormato.Checked = True Then
                txtNumero.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumero.Text))

                'End If
            End If
        Catch ex As Exception
            'MessageBoxAdv.Show("Error de formato!", "Atención", Nothing, MessageBoxIcon.Error)
            txtNumero.Select()
            txtNumero.Focus()
            txtNumero.Clear()
            lblEstado.Text = "Error de formato verifiuqe el ingreso!"
        End Try
    End Sub


    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If Not IsNothing(Me.dgvMov.Table.CurrentRecord) Then
            Me.dgvMov.Table.CurrentRecord.Delete()
            TotalTalesXcolumna()
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim almacenSA As New almacenSA
        Dim cuentaSA As New cuentaplanContableEmpresaSA


        Me.dgvCuenta.Table.AddNewRecord.SetCurrent()
        Me.dgvCuenta.Table.AddNewRecord.BeginEdit()
        Me.dgvCuenta.Table.CurrentRecord.SetValue("id", 0)
        Me.dgvCuenta.Table.CurrentRecord.SetValue("Modulo", "")
        Me.dgvCuenta.Table.CurrentRecord.SetValue("importeMN", 0.0)
        Me.dgvCuenta.Table.CurrentRecord.SetValue("importeME", 0.0)
        Me.dgvCuenta.Table.CurrentRecord.SetValue("HaberMN", 0.0)
        Me.dgvCuenta.Table.CurrentRecord.SetValue("HaberME", 0.0)

        Me.dgvCuenta.Table.CurrentRecord.SetValue("cuenta", "00") '

        'Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", almacenSA.GetUbicar_almacenVirtual(GEstableciento.IdEstablecimiento).idAlmacen)
        'Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", cuentaSA.ObtenerCuentasPorEmpresa(Gempresas.IdEmpresaRuc).cu)


        Me.dgvCuenta.Table.CurrentRecord.SetValue("tipoAsiento", "DEBE")
        Me.dgvCuenta.Table.AddNewRecord.EndEdit()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If Not IsNothing(Me.dgvCuenta.Table.CurrentRecord) Then
            Me.dgvCuenta.Table.CurrentRecord.Delete()
        End If
    End Sub

    Private Sub dgvCuenta_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCuenta.TableControlCellClick

    End Sub

    Private Sub dgvCuenta_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvCuenta.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        If Not IsNothing(Me.dgvCuenta.Table.CurrentRecord) Then
            'Select Case ColIndex
            '    Case 4
            '        e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 6, GridSetCurrentCellOptions.SetFocus)

            '        'Case 7
            '        '    e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 10, GridSetCurrentCellOptions.SetFocus)
            'End Select

            If ColIndex = 2 Then

                Dim cuentaSA As New cuentaplanContableEmpresaSA

                Me.dgvCuenta.Table.CurrentRecord.SetValue("Modulo", cuentaSA.ObtenerCuentaPorID(Gempresas.IdEmpresaRuc, Me.dgvCuenta.Table.CurrentRecord.GetValue("cuenta")).descripcion)

                'Me.dgvCompra.Table.CurrentRecord.SetValue("Modulo", Me.dgvCompra.Table.CurrentRecord.GetValue("cuenta"))

            End If


            If ColIndex = 3 Then
                Dim importeDebeME As Decimal = 0

                If CDec(Me.dgvCuenta.Table.CurrentRecord.GetValue("importeMN")) > 0 Then
                    Me.dgvCuenta.Table.CurrentRecord.SetValue("HaberMN", 0)
                    Me.dgvCuenta.Table.CurrentRecord.SetValue("HaberME", 0)
                    importeDebeME = Math.Round(CDec(Me.dgvCuenta.Table.CurrentRecord.GetValue("importeMN")) / txtTipoCambio2.Value, 2)
                    Me.dgvCuenta.Table.CurrentRecord.SetValue("importeME", importeDebeME)
                    Me.dgvCuenta.Table.CurrentRecord.SetValue("tipoAsiento", "DEBE")
                End If

            End If
            If ColIndex = 4 Then
                Dim importeHaberME As Decimal = 0

                Me.dgvCuenta.Table.CurrentRecord.SetValue("importeME", 0)
                Me.dgvCuenta.Table.CurrentRecord.SetValue("importeMN", 0)
                importeHaberME = Math.Round(CDec(Me.dgvCuenta.Table.CurrentRecord.GetValue("HaberMN")) / txtTipoCambio2.Value, 2)
                Me.dgvCuenta.Table.CurrentRecord.SetValue("HaberME", importeHaberME)
                Me.dgvCuenta.Table.CurrentRecord.SetValue("tipoAsiento", "HABER")

            End If
        End If
    End Sub
End Class