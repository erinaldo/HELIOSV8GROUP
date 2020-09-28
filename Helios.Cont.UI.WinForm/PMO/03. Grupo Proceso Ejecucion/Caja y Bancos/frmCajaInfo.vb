Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Public Class frmCajaInfo
    Inherits frmMaster

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        Me.WindowState = FormWindowState.Maximized
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean

        'If Not parpadear Then
        '    lblEstado.ForeColor = lblEstado.BackColor
        '    lblEstado.BackColor = Color.Yellow
        'Else
        '    lblEstado.ForeColor = SystemColors.WindowText
        'End If

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


    '#Region "TIPO"

    '    Public Sub ObtenerTipo()
    '        Dim estadoSA As New EstadosFinancierosSA


    '        cboTipo.ValueMember = "codigoDetalle"
    '        cboTipo.DisplayMember = "descripcion"
    '        cboTipo.DataSource = estadoSA.GetListaTablaDetalle(10, "1")


    '    End Sub

    '#End Region


#Region "Métodos"
    Structure CAJA_ESTADOS
        Const CAJA_ENTRADA_COBRO = "CB"
        Const CAJA_ENTRADA_PAGO = "CE"
        Const CAJA_SALIDA_COBRO = "PG"
        Const CAJA_SALIDA_PAGO = "CS"
        Const CAJA_APORTE = "AP"
        Const CAJA_VENTAS_ABARROTE = "DC"


    End Structure

    Public Sub CargarCajas(strBusqueda As String)
        Dim estadoSA As New EstadosFinancierosSA
        Try
            Me.lstEntidades.DataSource = estadoSA.ObtenerEstadosFinancierosPorMonedaXdescripcion(GEstableciento.IdEstablecimiento, Nothing, strBusqueda)
            Me.lstEntidades.DisplayMember = "descripcion"
            Me.lstEntidades.ValueMember = "idestado"
        Catch ex As Exception

        End Try
    End Sub

    Private Function GetParentTable(intIdCaja As Integer) As DataTable
        Dim dt As New DataTable("Movimientos período - " & PeriodoGeneral)
        Dim documentoCajaSA As New DocumentoCajaSA

        SaldoSoles = 0
        SaldoUSD = 0
        SaldoSolesNN = 0
        SaldoUSDNN = 0
        SaldoSolesNN1 = 0
        SaldoUSDNN1 = 0

        dt.Columns.Add(New DataColumn("NombreCaja", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaCobro", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("tipoMovimiento", GetType(String)))

        dt.Columns.Add(New DataColumn("dni", GetType(String)))
        dt.Columns.Add(New DataColumn("tipousuario", GetType(String)))


        dt.Columns.Add(New DataColumn("TipoDocumentoPago", GetType(String)))
        dt.Columns.Add(New DataColumn("NumeroDocumento", GetType(String)))
        dt.Columns.Add(New DataColumn("glosa", GetType(String)))

        dt.Columns.Add(New DataColumn("montoSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUsd", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoSoles2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUsd2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("Saldomn", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("Saldome", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("NombreOperacion", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoEntidad", GetType(String)))

        For Each i In documentoCajaSA.ObtenerCajaOnline(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, MesGeneral, AnioGeneral, intIdCaja)
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.NombreCaja
            dr(1) = i.fechaCobro
            Select Case i.tipoMovimiento
                Case "PG"
                    dr(2) = "SALIDA"
                Case Else
                    dr(2) = "ENTRADA"
            End Select
            dr(3) = i.dni
            dr(4) = i.tipousuario

            dr(5) = i.TipoDocumentoPago
            dr(6) = i.NumeroDocumento
            dr(7) = i.glosa

            Select Case i.tipoMovimiento
                Case CAJA_ESTADOS.CAJA_ENTRADA_COBRO, CAJA_ESTADOS.CAJA_ENTRADA_PAGO, _
                     CAJA_ESTADOS.CAJA_APORTE, CAJA_ESTADOS.CAJA_VENTAS_ABARROTE
                    SaldoSoles += i.montoSoles
                    SaldoUSD += i.montoUsd
                    dr(8) = i.montoSoles
                    dr(9) = i.montoUsd
                    dr(10) = 0
                    dr(11) = 0

                Case CAJA_ESTADOS.CAJA_SALIDA_PAGO, CAJA_ESTADOS.CAJA_SALIDA_COBRO

                    SaldoSoles -= i.montoSoles
                    SaldoUSD -= i.montoUsd

                    dr(8) = 0
                    dr(9) = 0
                    dr(10) = i.montoSoles
                    dr(11) = i.montoUsd
            End Select
            dr(12) = SaldoSoles
            dr(13) = SaldoUSD
            'INFORMACION COMPRA
            'dr(12) = i.NombreEntidad.ToLower
            'dr(13) = i.Comprobante
            'dr(14) = CInt(i.SerieCompra)
            'dr(15) = CInt(i.SerieCompra) & "-" & CInt(i.numeroCompra)
            dr(14) = (i.NombreOperacion)

            If i.entidadFinanciera = "EF" Then
                dr(15) = "CUENTAS EN EFECTIVO"
            ElseIf i.entidadFinanciera = "BC" Then
                dr(15) = "CUENTAS EN BANCO"
            End If

            dt.Rows.Add(dr)
        Next
        Return dt
    End Function
    'For Each i In documentoCajaSA.ObtenerCajaOnline(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, MesGeneral, AnioGeneral, intIdCaja)
    '    Dim dr As DataRow = dt.NewRow()
    '    dr(0) = i.NombreCaja
    '    dr(1) = i.fechaCobro
    '    Select Case i.tipoMovimiento
    '        Case "PG"
    '            dr(2) = "SALIDA"
    '        Case Else
    '            dr(2) = "ENTRADA"
    '    End Select
    '    dr(3) = i.TipoDocumentoPago
    '    dr(4) = i.NumeroDocumento
    '    dr(5) = i.glosa

    '    Select Case i.tipoMovimiento
    '        Case CAJA_ESTADOS.CAJA_ENTRADA_COBRO, CAJA_ESTADOS.CAJA_ENTRADA_PAGO, _
    '             CAJA_ESTADOS.CAJA_APORTE, CAJA_ESTADOS.CAJA_VENTAS_ABARROTE
    '            SaldoSoles += i.montoSoles
    '            SaldoUSD += i.montoUsd
    '            dr(6) = i.montoSoles
    '            dr(7) = i.montoUsd
    '            dr(8) = 0
    '            dr(9) = 0

    '        Case CAJA_ESTADOS.CAJA_SALIDA_PAGO, CAJA_ESTADOS.CAJA_SALIDA_COBRO

    '            SaldoSoles -= i.montoSoles
    '            SaldoUSD -= i.montoUsd

    '            dr(6) = 0
    '            dr(7) = 0
    '            dr(8) = i.montoSoles
    '            dr(9) = i.montoUsd
    '    End Select
    '    dr(10) = SaldoSoles
    '    dr(11) = SaldoUSD
    '    'INFORMACION COMPRA
    '    'dr(12) = i.NombreEntidad.ToLower
    '    'dr(13) = i.Comprobante
    '    'dr(14) = CInt(i.SerieCompra)
    '    'dr(15) = CInt(i.SerieCompra) & "-" & CInt(i.numeroCompra)
    '    dr(12) = (i.NombreOperacion)

    '    If i.entidadFinanciera = "EF" Then
    '        dr(13) = "CUENTAS EN EFECTIVO"
    '    ElseIf i.entidadFinanciera = "BC" Then
    '        dr(13) = "CUENTAS EN BANCO"
    '    End If
    '    dr(14) = i.dni
    '    dr(15) = i.tipousuario
    '    dt.Rows.Add(dr)


    Private Function GetParentTablePorDia(intIdCaja As Integer) As DataTable
        Dim dt As New DataTable("Movimientos día - " & DateTime.Now.Date)
        Dim documentoCajaSA As New DocumentoCajaSA

        SaldoSoles = 0
        SaldoUSD = 0
        SaldoSolesNN = 0
        SaldoUSDNN = 0
        SaldoSolesNN1 = 0
        SaldoUSDNN1 = 0
        dt.Columns.Add(New DataColumn("NombreCaja", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaCobro", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("tipoMovimiento", GetType(String)))

        dt.Columns.Add(New DataColumn("dni", GetType(String)))
        dt.Columns.Add(New DataColumn("tipousuario", GetType(String)))

        dt.Columns.Add(New DataColumn("TipoDocumentoPago", GetType(String)))
        dt.Columns.Add(New DataColumn("NumeroDocumento", GetType(String)))
        dt.Columns.Add(New DataColumn("glosa", GetType(String)))

        dt.Columns.Add(New DataColumn("montoSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUsd", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoSoles2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUsd2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("Saldomn", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("Saldome", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("NombreOperacion", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoEntidad", GetType(String)))


        For Each i In documentoCajaSA.ObtenerCajaOnlinePorDia(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, intIdCaja)
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.NombreCaja
            dr(1) = i.fechaCobro
            Select Case i.tipoMovimiento
                Case "PG"
                    dr(2) = "SALIDA"
                Case Else
                    dr(2) = "ENTRADA"
            End Select
            dr(3) = i.dni
            dr(4) = i.tipousuario

            dr(5) = i.TipoDocumentoPago
            dr(6) = i.NumeroDocumento
            dr(7) = i.glosa

            Select Case i.tipoMovimiento
                Case CAJA_ESTADOS.CAJA_ENTRADA_COBRO, CAJA_ESTADOS.CAJA_ENTRADA_PAGO, _
                     CAJA_ESTADOS.CAJA_APORTE, CAJA_ESTADOS.CAJA_VENTAS_ABARROTE
                    SaldoSoles += i.montoSoles
                    SaldoUSD += i.montoUsd
                    dr(8) = i.montoSoles
                    dr(9) = i.montoUsd
                    dr(10) = 0
                    dr(11) = 0

                Case CAJA_ESTADOS.CAJA_SALIDA_PAGO, CAJA_ESTADOS.CAJA_SALIDA_COBRO

                    SaldoSoles -= i.montoSoles
                    SaldoUSD -= i.montoUsd

                    dr(8) = 0
                    dr(9) = 0
                    dr(10) = i.montoSoles
                    dr(11) = i.montoUsd
            End Select
            dr(12) = SaldoSoles
            dr(13) = SaldoUSD
            'INFORMACION COMPRA
            'dr(12) = i.NombreEntidad.ToLower
            'dr(13) = i.Comprobante
            'dr(14) = CInt(i.SerieCompra)
            'dr(15) = CInt(i.SerieCompra) & "-" & CInt(i.numeroCompra)
            dr(14) = (i.NombreOperacion)

            If i.entidadFinanciera = "EF" Then
                dr(15) = "CUENTAS EN EFECTIVO"
            ElseIf i.entidadFinanciera = "BC" Then
                dr(15) = "CUENTAS EN BANCO"
            End If

            dt.Rows.Add(dr)
            'dr(3) = i.TipoDocumentoPago
            'dr(4) = i.NumeroDocumento
            'dr(5) = i.glosa

            'Select Case i.tipoMovimiento
            '    Case CAJA_ESTADOS.CAJA_ENTRADA_COBRO, CAJA_ESTADOS.CAJA_ENTRADA_PAGO, _
            '         CAJA_ESTADOS.CAJA_APORTE, CAJA_ESTADOS.CAJA_VENTAS_ABARROTE
            '        SaldoSoles += i.montoSoles
            '        SaldoUSD += i.montoUsd
            '        dr(6) = i.montoSoles
            '        dr(7) = i.montoUsd
            '        dr(8) = 0
            '        dr(9) = 0

            '    Case CAJA_ESTADOS.CAJA_SALIDA_PAGO, CAJA_ESTADOS.CAJA_SALIDA_COBRO

            '        SaldoSoles -= i.montoSoles
            '        SaldoUSD -= i.montoUsd

            '        dr(6) = 0
            '        dr(7) = 0
            '        dr(8) = i.montoSoles
            '        dr(9) = i.montoUsd
            'End Select
            'dr(10) = SaldoSoles
            'dr(11) = SaldoUSD
            ''INFORMACION COMPRA
            ''dr(12) = i.NombreEntidad.ToLower
            ''dr(13) = i.Comprobante
            ''dr(14) = CInt(i.SerieCompra)
            ''dr(15) = CInt(i.SerieCompra) & "-" & CInt(i.numeroCompra)
            'dr(12) = (i.NombreOperacion)

            'If i.entidadFinanciera = "EF" Then
            '    dr(13) = "CUENTAS EN EFECTIVO"
            'ElseIf i.entidadFinanciera = "BC" Then
            '    dr(13) = "CUENTAS EN BANCO"
            'End If

            'dt.Rows.Add(dr)
        Next
        Return dt



    End Function

    Private Function getParentTableAcumuladoCaja(intIdEstablecimiento As Integer, strPeriodo As String) As DataTable
        Dim dt As New DataTable("Movimiento acumulado, todas las cajas período - " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        SaldoSoles = 0
        SaldoUSD = 0
        SaldoSolesNN = 0
        SaldoUSDNN = 0
        SaldoSolesNN1 = 0
        SaldoUSDNN1 = 0
        dt.Columns.Add(New DataColumn("NombreCaja", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaCobro", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("tipoMovimiento", GetType(String)))
        dt.Columns.Add(New DataColumn("dni", GetType(String)))
        dt.Columns.Add(New DataColumn("tipousuario", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoDocumentoPago", GetType(String)))
        dt.Columns.Add(New DataColumn("NumeroDocumento", GetType(String)))
        dt.Columns.Add(New DataColumn("glosa", GetType(String)))

        dt.Columns.Add(New DataColumn("montoSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUsd", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoSoles2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUsd2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("Saldomn", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("Saldome", GetType(Decimal)))

        'dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        'dt.Columns.Add(New DataColumn("Comprobante", GetType(String)))
        'dt.Columns.Add(New DataColumn("SerieCompra", GetType(String)))
        'dt.Columns.Add(New DataColumn("numeroCompra", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreOperacion", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoEntidad", GetType(String)))
        Dim str As String
        For Each i In documentoCajaSA.ObtenerCajasMovimientosPorPeriodo(GEstableciento.IdEstablecimiento, strPeriodo)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            If IsNothing(i.fechaCobro) Then
                str = "-"
            Else
                str = CDate(i.fechaCobro).ToString("dd-MMM-yy HH:mm tt ")
            End If
            dr(0) = i.NombreCaja
            dr(1) = str
            Select Case i.tipoMovimiento
                Case "PG"
                    dr(2) = "SALIDA"
                Case Else
                    dr(2) = "ENTRADA"
            End Select
            dr(3) = i.dni
            dr(4) = i.tipousuario

            dr(5) = i.TipoDocumentoPago
            dr(6) = i.NumeroDocumento
            dr(7) = i.glosa

            Select Case i.tipoMovimiento
                Case CAJA_ESTADOS.CAJA_ENTRADA_COBRO, CAJA_ESTADOS.CAJA_ENTRADA_PAGO, _
                     CAJA_ESTADOS.CAJA_APORTE, CAJA_ESTADOS.CAJA_VENTAS_ABARROTE
                    SaldoSoles += i.montoSoles
                    SaldoUSD += i.montoUsd
                    dr(8) = i.montoSoles
                    dr(9) = i.montoUsd
                    dr(10) = 0
                    dr(11) = 0

                Case CAJA_ESTADOS.CAJA_SALIDA_PAGO, CAJA_ESTADOS.CAJA_SALIDA_COBRO

                    SaldoSoles -= i.montoSoles
                    SaldoUSD -= i.montoUsd

                    dr(8) = 0
                    dr(9) = 0
                    dr(10) = i.montoSoles
                    dr(11) = i.montoUsd
            End Select
            dr(12) = SaldoSoles
            dr(13) = SaldoUSD
            'INFORMACION COMPRA
            'dr(12) = i.NombreEntidad.ToLower
            'dr(13) = i.Comprobante
            'dr(14) = CInt(i.SerieCompra)
            'dr(15) = CInt(i.SerieCompra) & "-" & CInt(i.numeroCompra)
            dr(14) = (i.NombreOperacion)

            If i.entidadFinanciera = "EF" Then
                dr(15) = "CUENTAS EN EFECTIVO"
            ElseIf i.entidadFinanciera = "BC" Then
                dr(15) = "CUENTAS EN BANCO"
            End If

            dt.Rows.Add(dr)
            'dr(3) = i.TipoDocumentoPago
            'dr(4) = i.NumeroDocumento
            'dr(5) = i.glosa

            'Select Case i.tipoMovimiento
            '    Case CAJA_ESTADOS.CAJA_ENTRADA_COBRO, CAJA_ESTADOS.CAJA_ENTRADA_PAGO, _
            '         CAJA_ESTADOS.CAJA_APORTE, CAJA_ESTADOS.CAJA_VENTAS_ABARROTE
            '        SaldoSoles += i.montoSoles
            '        SaldoUSD += i.montoUsd
            '        dr(6) = i.montoSoles
            '        dr(7) = i.montoUsd
            '        dr(8) = 0
            '        dr(9) = 0

            '    Case CAJA_ESTADOS.CAJA_SALIDA_PAGO, CAJA_ESTADOS.CAJA_SALIDA_COBRO

            '        SaldoSoles -= i.montoSoles
            '        SaldoUSD -= i.montoUsd

            '        dr(6) = 0
            '        dr(7) = 0
            '        dr(8) = i.montoSoles
            '        dr(9) = i.montoUsd
            'End Select
            'dr(10) = SaldoSoles
            'dr(11) = SaldoUSD
            ''INFORMACION COMPRA
            ''dr(12) = i.NombreEntidad.ToLower
            ''dr(13) = i.Comprobante
            ''dr(14) = CInt(i.SerieCompra)
            ''dr(15) = CInt(i.SerieCompra) & "-" & CInt(i.numeroCompra)
            'dr(12) = (i.NombreOperacion)

            'If i.entidadFinanciera = "EF" Then
            '    dr(13) = "CUENTAS EN EFECTIVO"
            'ElseIf i.entidadFinanciera = "BC" Then
            '    dr(13) = "CUENTAS EN BANCO"
            'End If


            'dt.Rows.Add(dr)
        Next
        Return dt



    End Function


    Dim SaldoSoles As Decimal = 0
    Dim SaldoUSD As Decimal = 0

    Dim SaldoSolesNN As Decimal = 0
    Dim SaldoUSDNN As Decimal = 0

    Dim SaldoSolesNN1 As Decimal = 0
    Dim SaldoUSDNN1 As Decimal = 0


    Private Sub ConsultaInfoList(intIdCaja As Integer)
        Dim documentoCajaSA As New DocumentoCajaSA

        'For Each i As documentoCaja In documentoCajaSA.ObtenerCajaOnline(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, MesGeneral, AnioGeneral, intIdCaja)
        '    Me.dgvCuentasFinanzas.Table.AddNewRecord.SetCurrent()
        '    Me.dgvCuentasFinanzas.Table.AddNewRecord.BeginEdit()
        '    dgvCuentasFinanzas.TableDescriptor.AllowNew = True
        '    '  dgvCuentasFinanzas.TableDescriptor.AllowEdit = True
        '    Me.dgvCuentasFinanzas.GetTableControl("XXX").Model.Rows.InsertRange(3, 1)
        '    Me.dgvCuentasFinanzas.Table.CurrentRecord.SetValue("fechaCobro", "dd")
        '    Me.dgvCuentasFinanzas.Table.CurrentRecord.SetValue("tipoMovimiento", i.tipoMovimiento)
        '    Me.dgvCuentasFinanzas.Table.CurrentRecord.SetValue("TipoDocumentoPago", i.TipoDocumentoPago)
        '    Me.dgvCuentasFinanzas.Table.CurrentRecord.SetValue("NumeroDocumento", i.NumeroDocumento)
        '    Me.dgvCuentasFinanzas.Table.CurrentRecord.SetValue("glosa", i.glosa)
        '    Me.dgvCuentasFinanzas.Table.AddNewRecord.EndEdit()
        'Next

        Dim parentTable As DataTable = GetParentTable(intIdCaja)
        Me.dgvCuentasFinanzas.DataSource = parentTable
        dgvCuentasFinanzas.TableDescriptor.Relations.Clear()
        dgvCuentasFinanzas.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
        dgvCuentasFinanzas.TableOptions.ListBoxSelectionMode = SelectionMode.One
        dgvCuentasFinanzas.Appearance.AnyRecordFieldCell.Enabled = False
        dgvCuentasFinanzas.GroupDropPanel.Visible = True
        dgvCuentasFinanzas.TableDescriptor.GroupedColumns.Clear()
    End Sub

    Private Sub ConsultaInfoListPorDia(intIdCaja As Integer)
        Dim documentoCajaSA As New DocumentoCajaSA

        Dim parentTable As DataTable = GetParentTablePorDia(intIdCaja)
        Me.dgvCuentasFinanzas.DataSource = parentTable
        dgvCuentasFinanzas.TableDescriptor.Relations.Clear()
        dgvCuentasFinanzas.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
        dgvCuentasFinanzas.TableOptions.ListBoxSelectionMode = SelectionMode.One
        dgvCuentasFinanzas.Appearance.AnyRecordFieldCell.Enabled = False
        dgvCuentasFinanzas.GroupDropPanel.Visible = True
        dgvCuentasFinanzas.TableDescriptor.GroupedColumns.Clear()
    End Sub

    Private Sub ConsultaInfoListAcumulado()
        Dim documentoCajaSA As New DocumentoCajaSA

        Me.dgvCuentasFinanzas.UpdateDisplayFrequency = 0 '; // 0 if manual updates only from timer_tick

        Me.dgvCuentasFinanzas.UseDefaultsForFasterDrawing = True
        'Me.dgvCuentasFinanzas.CounterLogic = EngineCounters.YAmount
        '    Me.dgvCuentasFinanzas.AllowedOptimizations = EngineOptimizations.DisableCounters | EngineOptimizations.RecordsAsDisplayElements
        Me.dgvCuentasFinanzas.CacheRecordValues = False

        Dim parentTable As DataTable = getParentTableAcumuladoCaja(GEstableciento.IdEstablecimiento, PeriodoGeneral)
        Me.dgvCuentasFinanzas.DataSource = parentTable
        dgvCuentasFinanzas.TableDescriptor.Relations.Clear()
        dgvCuentasFinanzas.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
        dgvCuentasFinanzas.TableOptions.ListBoxSelectionMode = SelectionMode.One
        dgvCuentasFinanzas.Appearance.AnyRecordFieldCell.Enabled = False
        dgvCuentasFinanzas.GroupDropPanel.Visible = True
        dgvCuentasFinanzas.TableDescriptor.GroupedColumns.Clear()
        dgvCuentasFinanzas.TableDescriptor.GroupedColumns.Add("NombreCaja")
    End Sub


#End Region


#Region "CONFIGURACION DOCKING CONTROL"
#End Region

    Private Sub frmCajaInfo_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmCajaInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        PanelError.Visible = False
        Timer1.Enabled = False
    End Sub

    Private Sub gridGroupingControl1_TableControlCellDrawn(sender As System.Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlDrawCellEventArgs)

    End Sub

    Private Sub rbAcumulado_Click(sender As Object, e As EventArgs) Handles rbAcumulado.Click
        Me.Cursor = Cursors.WaitCursor
        If rbAcumulado.Checked = True Then
            dgvCuentasFinanzas.Table.Records.DeleteAll()
            ConsultaInfoListAcumulado()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub rbPeriodo_Click(sender As Object, e As EventArgs) Handles rbPeriodo.Click
        If rbPeriodo.Checked = True Then
            dgvCuentasFinanzas.Table.Records.DeleteAll()
        End If
    End Sub

    Private Sub rbDia_Click(sender As Object, e As EventArgs) Handles rbDia.Click
        If rbDia.Checked = True Then
            dgvCuentasFinanzas.Table.Records.DeleteAll()
        End If
    End Sub

    Private Sub txtRuc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRuc.KeyDown

    End Sub

    Private Sub txtRuc_TextChanged(sender As Object, e As EventArgs) Handles txtRuc.TextChanged
        pcEntidad.Font = New Font("Segoe UI", 8)
        Me.pcEntidad.ParentControl = Me.txtRuc
        Me.pcEntidad.ShowPopup(Point.Empty)
        'CargarCajas(txtRuc.Text.Trim)

        If cboTipo.Text = "CUENTAS EN EFECTIVO" Then
            CargarCajasTipo(txtRuc.Text.Trim, "EF")
        ElseIf cboTipo.Text = "CUENTAS EN BANCO" Then
            CargarCajasTipo(txtRuc.Text.Trim, "BC")
        End If
    End Sub

    Private Sub pcEntidad_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles pcEntidad.BeforePopup
        Me.pcEntidad.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub pcEntidad_CausesValidationChanged(sender As Object, e As EventArgs) Handles pcEntidad.CausesValidationChanged

    End Sub

    Private Sub pcEntidad_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcEntidad.CloseUp
        Me.Cursor = Cursors.WaitCursor
        Dim entidadSA As New entidadSA
        Dim cajaSA As New EstadosFinancierosSA
        If e.PopupCloseType = PopupCloseType.Done Then
            If lstEntidades.SelectedItems.Count > 0 Then
                With cajaSA.GetUbicar_estadosFinancierosPorID(lstEntidades.SelectedValue)
                    txtNomCaja.ValueMember = lstEntidades.SelectedValue
                    txtNomCaja.Text = .descripcion
                    txtTipoCaja.Text = IIf(.tipo = "BC", "BANCO", "EN EFECTIVO")
                    txtMoneda.Text = IIf(.codigo = "1", "NACIONAL", "EXTRANJERA")
                    txtNumCaja.Text = IIf(.tipo = "BC", .nroCtaCorriente, Nothing)

                    'If rbPeriodo.Checked = True Then
                    '    lblEstado.Text = "Lista de movimientos periodo: " & PeriodoGeneral
                    '    Timer1.Enabled = True
                    '    TiempoEjecutar(10)
                    '    ConsultaInfoList(.idestado)
                    'ElseIf rbDia.Checked = True Then
                    '    lblEstado.Text = "Lista de movimientos del día: " & DateTime.Now.Date
                    '    Timer1.Enabled = True
                    '    TiempoEjecutar(10)
                    '    ConsultaInfoListPorDia(.idestado)
                    'End If
                End With
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtRuc.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lstEntidades_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstEntidades.MouseDoubleClick
        If lstEntidades.SelectedItems.Count > 0 Then
            Me.pcEntidad.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub lstEntidades_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstEntidades.SelectedIndexChanged

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        If txtNomCaja.Text.Trim.Length > 0 Then
            If rbPeriodo.Checked = True Then
                dgvCuentasFinanzas.Table.Records.DeleteAll()
                lblEstado.Text = "Lista de movimientos periodo: " & PeriodoGeneral
                Timer1.Enabled = True
                TiempoEjecutar(10)
                ConsultaInfoList(txtNomCaja.ValueMember)
            End If
            If rbDia.Checked = True Then
                dgvCuentasFinanzas.Table.Records.DeleteAll()

                lblEstado.Text = "Lista de movimientos del día: " & DateTime.Now.Date
                Timer1.Enabled = True
                TiempoEjecutar(10)
                ConsultaInfoListPorDia(txtNomCaja.ValueMember)
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Me.Cursor = Cursors.WaitCursor

        With frmReporteCajaOnline
            If (rbPeriodo.Checked = True) Then
                .ConsultaReporte(GEstableciento.IdEstablecimiento, MesGeneral, AnioGeneral, lstEntidades.SelectedValue, lstEntidades.Text)
                .StartPosition = FormStartPosition.CenterScreen
                .ShowDialog()
            ElseIf (rbDia.Checked = True) Then
                .ConsultaReporteDia(GEstableciento.IdEstablecimiento, lstEntidades.SelectedValue, lstEntidades.Text)
                .StartPosition = FormStartPosition.CenterScreen
                .ShowDialog()
            ElseIf (rbAcumulado.Checked = True) Then
                .ConsultaReporteAcumulado(GEstableciento.IdEstablecimiento)
                .StartPosition = FormStartPosition.CenterScreen
                .ShowDialog()
            End If
        End With
        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub dgvCuentasFinanzas_TableControlCellClick(sender As Object, e As Grid.Grouping.GridTableControlCellClickEventArgs) Handles dgvCuentasFinanzas.TableControlCellClick

    End Sub

    Private Sub btAcum_Click(sender As Object, e As EventArgs) Handles btAcum.Click
        Me.Cursor = Cursors.WaitCursor

        dgvCuentasFinanzas.Table.Records.DeleteAll()
        ConsultaInfoListAcumulado()

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btDia_Click(sender As Object, e As EventArgs) Handles btDia.Click
        Me.Cursor = Cursors.WaitCursor
        Dim entidadSA As New entidadSA
        Dim cajaSA As New EstadosFinancierosSA
        If lstEntidades.SelectedItems.Count > 0 Then
            With cajaSA.GetUbicar_estadosFinancierosPorID(lstEntidades.SelectedValue)
                txtNomCaja.ValueMember = lstEntidades.SelectedValue
                txtNomCaja.Text = .descripcion
                txtTipoCaja.Text = IIf(.tipo = "BC", "BANCO", "EN EFECTIVO")
                txtMoneda.Text = IIf(.codigo = "1", "NACIONAL", "EXTRANJERA")
                txtNumCaja.Text = IIf(.tipo = "BC", .nroCtaCorriente, Nothing)

                lblEstado.Text = "Lista de movimientos del día: " & DateTime.Now.Date
                Timer1.Enabled = True
                TiempoEjecutar(10)
                ConsultaInfoListPorDia(.idestado)

            End With
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btPeriodo_Click(sender As Object, e As EventArgs) Handles btPeriodo.Click
        'Me.Cursor = Cursors.WaitCursor

        'If cboTipo.Text = "CUENTAS EN EFECTIVO" Then
        '    ConsultaInfoListtIPO("BC")
        'ElseIf cboTipo.Text = "CUENTAS EN BANCO" Then
        '    ConsultaInfoListtIPO("EF")
        'End If

        Dim entidadSA As New entidadSA
        Dim cajaSA As New EstadosFinancierosSA
        If lstEntidades.SelectedItems.Count > 0 Then
            With cajaSA.GetUbicar_estadosFinancierosPorID(lstEntidades.SelectedValue)

                txtNomCaja.ValueMember = lstEntidades.SelectedValue
                txtNomCaja.Text = .descripcion
                txtTipoCaja.Text = IIf(.tipo = "BC", "BANCO", "EN EFECTIVO")
                txtMoneda.Text = IIf(.codigo = "1", "NACIONAL", "EXTRANJERA")
                txtNumCaja.Text = IIf(.tipo = "BC", .nroCtaCorriente, Nothing)

                lblEstado.Text = "Lista de movimientos periodo: " & PeriodoGeneral
                Timer1.Enabled = True
                TiempoEjecutar(10)
                ConsultaInfoList(.idestado)

            End With
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboTipo_Click(sender As Object, e As EventArgs) Handles cboTipo.Click

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

    Public Sub CargarCajasTipo2(tiping As String)
        Dim estadoSA As New EstadosFinancierosSA
        Try
            Me.lstEntidades.DataSource = estadoSA.ObtenerEstadosFinancierosPorTipo(GEstableciento.IdEstablecimiento, tiping)
            Me.lstEntidades.DisplayMember = "descripcion"
            Me.lstEntidades.ValueMember = "idestado"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboTipo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboTipo.SelectedValueChanged
        Me.Cursor = Cursors.WaitCursor
        If cboTipo.Text = "CUENTAS EN EFECTIVO" Then
            CargarCajasTipo2("EF")
        ElseIf cboTipo.Text = "CUENTAS EN BANCO" Then
            CargarCajasTipo2("BC")
        End If
        Me.Cursor = Cursors.Arrow
    End Sub
End Class