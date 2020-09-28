Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports System.Collections
Imports System.Collections.Specialized
Imports Syncfusion.Windows.Forms.Tools
Public Class frmFlujoAsientoManualPago

    Inherits frmMaster

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridCFG(dgvPagosV)
        'GridCFG(dgvPagosProgramados)
        'GetTableGrid2()

        'txtPeriodo.Value = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Day)

        'getConfigGrid()
    End Sub

#Region "Metodos"


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

        '  GGC.BrowseOnly = True
        'GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        'GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        'GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GGC.TableOptions.SelectionBackColor = Color.Gray
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        GGC.Table.DefaultColumnHeaderRowHeight = 23
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 7.5F

    End Sub



    Private Sub UbicarTodoPagosAsientoManualMNME()
        Dim documentoVentaSA As New documentoLibroDiarioSA
        Dim documentoVenta As New List(Of documentoLibroDiarioDetalle)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        'Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("fecha", GetType(String))
        dt.Columns.Add("descripcion", GetType(String))
        dt.Columns.Add("tipoVenta", GetType(String))
        dt.Columns.Add("tipoDoc", GetType(String))
        dt.Columns.Add("serie", GetType(String))
        dt.Columns.Add("numero", GetType(String))
        dt.Columns.Add("moneda", GetType(String))
        dt.Columns.Add("importeMN", GetType(Decimal))
        dt.Columns.Add("tipoCambio", GetType(Decimal))
        dt.Columns.Add("importeME", GetType(Decimal))
        dt.Columns.Add("abonoMN", GetType(Decimal))
        dt.Columns.Add("abonoME", GetType(Decimal))
        dt.Columns.Add("saldoMN", GetType(Decimal))
        dt.Columns.Add("saldoME", GetType(Decimal))
        dt.Columns.Add("estadoPago", GetType(String))
        dt.Columns.Add("dia", GetType(Integer))
        dt.Columns.Add("montoVenc", GetType(Decimal))
        dt.Columns.Add("montoVencme", GetType(Decimal))
        dt.Columns.Add("fechaVcto", GetType(String))
        dt.Columns.Add("montocrono", GetType(Decimal))
        dt.Columns.Add("montocronome", GetType(Decimal))
        dt.Columns.Add("montoxprog", GetType(Decimal))
        dt.Columns.Add("montoxprogme", GetType(Decimal))
        dt.Columns.Add("pago", GetType(Decimal))
        dt.Columns.Add("pagome", GetType(Decimal))
        dt.Columns.Add("cuenta", GetType(String))
        dt.Columns.Add("idsecuencia", GetType(Integer))
        dt.Columns.Add("idProveedor", GetType(Integer))
        dt.Columns.Add("nombre", GetType(String))
        dt.Columns.Add("tipoProveedor", GetType(String))

        documentoVenta = documentoVentaSA.UbicarTodoPagosAsientoManualMNME(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
        Dim str As String
        Dim str2 As String
        If Not IsNothing(documentoVenta) Then
            For Each i In documentoVenta
                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.FechaDoc).ToString("dd-MMM hh:mm tt ")
                str2 = Nothing
                str2 = CDate(i.fechaVcto).ToString("dd-MMM hh:mm tt ")
                dr(0) = i.idDocumento
                dr(1) = str
                dr(2) = i.descripcion
                dr(3) = ""
                dr(4) = i.tipoDocumento
                dr(5) = ""
                dr(6) = i.numeroDoc
                dr(11) = i.PagoSumaMN
                dr(12) = i.PagoSumaME

                Select Case i.moneda
                    Case 1
                        dr(7) = "NAC"
                        dr(8) = i.importeMN
                        dr(9) = i.tipoCambio
                        dr(10) = CDec(0.0)
                        dr(13) = CDec(i.importeMN - i.PagoSumaMN).ToString("N2")
                        dr(14) = CDec(0.0)
                    Case Else
                        dr(7) = "EXT"
                        dr(8) = CDec(0.0)
                        dr(9) = i.tipoCambio
                        dr(10) = i.importeME
                        dr(13) = CDec(0.0)
                        dr(14) = CDec(i.importeME - i.PagoSumaME).ToString("N2")
                End Select

                Select Case i.estadoPago
                    Case TIPO_COMPRA.PAGO.PAGADO
                        dr(15) = "Saldado"
                    Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                        dr(15) = "Pendiente"
                End Select

                'monto vencidos dolares y soles
                If DateTime.Now.Date > i.fechaVcto Then

                    If i.moneda = "1" Then

                        Dim dias As Integer
                        Dim fecha1 As Date
                        Dim fecha2 As Date
                        fecha1 = DateTime.Now
                        fecha2 = i.FechaDoc
                        dias = (fecha1 - fecha2).TotalDays
                        dr(16) = dias
                        dr(17) = CDec(i.importeMN - i.PagoSumaMN).ToString("N2")
                        dr(18) = CDec(0.0)

                    ElseIf i.moneda = "2" Then

                        Dim dias As Integer
                        Dim fecha1 As Date
                        Dim fecha2 As Date
                        fecha1 = DateTime.Now
                        fecha2 = i.FechaDoc
                        dias = (fecha1 - fecha2).TotalDays

                        dr(16) = dias
                        dr(17) = CDec(0.0)
                        dr(18) = CDec(i.importeME - i.PagoSumaME).ToString("N2")

                    End If
                Else
                    dr(16) = 0
                    dr(17) = 0
                    dr(18) = 0
                End If

                dr(19) = str2

                If i.moneda = "1" Then
                    dr(20) = i.montocrono
                    dr(21) = CDec(0.0)
                    dr(22) = CDec(i.importeMN - i.PagoSumaMN - i.montocrono).ToString("N2")
                    dr(23) = CDec(0.0)
                    dr(24) = CDec(0.0)
                    dr(25) = CDec(0.0)
                    dr(26) = i.cuenta
                    dr(27) = i.secuencia
                     dr(28) = i.razonSocial
                    dr(29) = i.NombreRazon
                    dr(30) = i.tipoRazon



                    If CDec(i.importeMN - i.PagoSumaMN - i.montocrono).ToString("N2") > 0 Then
                        dt.Rows.Add(dr)
                    End If

                ElseIf i.moneda = "2" Then
                    dr(20) = CDec(0.0)
                    dr(21) = i.montocronome
                    dr(22) = CDec(CDec(0.0))
                    dr(23) = CDec(i.importeME - i.PagoSumaME - i.montocronome).ToString("N2")
                    dr(24) = CDec(0.0)
                    dr(25) = CDec(0.0)
                    dr(26) = i.cuenta
                    dr(27) = i.secuencia
                    dr(28) = i.razonSocial
                    dr(29) = i.NombreRazon
                    dr(30) = i.tipoRazon


                    If CDec(i.importeME - i.PagoSumaME - i.montocronome).ToString("N2") > 0 Then
                        dt.Rows.Add(dr)
                    End If

                End If

            Next

            dgvPagosV.DataSource = dt
            Me.dgvPagosV.TableOptions.ListBoxSelectionMode = SelectionMode.One
        Else

        End If
    End Sub



    Private Sub UbicarCobrosPorAsientoManualMNME(RucCliente As Integer)
        Dim documentoVentaSA As New documentoLibroDiarioSA
        Dim documentoVenta As New List(Of documentoLibroDiarioDetalle)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        'Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("fecha", GetType(String))
        dt.Columns.Add("descripcion", GetType(String))
        dt.Columns.Add("tipoVenta", GetType(String))
        dt.Columns.Add("tipoDoc", GetType(String))
        dt.Columns.Add("serie", GetType(String))
        dt.Columns.Add("numero", GetType(String))
        dt.Columns.Add("moneda", GetType(String))
        dt.Columns.Add("importeMN", GetType(Decimal))
        dt.Columns.Add("tipoCambio", GetType(Decimal))
        dt.Columns.Add("importeME", GetType(Decimal))
        dt.Columns.Add("abonoMN", GetType(Decimal))
        dt.Columns.Add("abonoME", GetType(Decimal))
        dt.Columns.Add("saldoMN", GetType(Decimal))
        dt.Columns.Add("saldoME", GetType(Decimal))
        dt.Columns.Add("estadoPago", GetType(String))
        dt.Columns.Add("dia", GetType(Integer))
        dt.Columns.Add("montoVenc", GetType(Decimal))
        dt.Columns.Add("montoVencme", GetType(Decimal))
        dt.Columns.Add("fechaVcto", GetType(String))
        dt.Columns.Add("montocrono", GetType(Decimal))
        dt.Columns.Add("montocronome", GetType(Decimal))
        dt.Columns.Add("montoxprog", GetType(Decimal))
        dt.Columns.Add("montoxprogme", GetType(Decimal))
        dt.Columns.Add("pago", GetType(Decimal))
        dt.Columns.Add("pagome", GetType(Decimal))
        dt.Columns.Add("cuenta", GetType(String))
        dt.Columns.Add("idsecuencia", GetType(Integer))
        dt.Columns.Add("idProveedor", GetType(Integer))
        dt.Columns.Add("nombre", GetType(String))
        dt.Columns.Add("tipoProveedor", GetType(String))

        documentoVenta = documentoVentaSA.UbicarCobrosPorAsientoManualMNME(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, RucCliente)
        Dim str As String
        Dim str2 As String
        If Not IsNothing(documentoVenta) Then
            For Each i In documentoVenta
                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.FechaDoc).ToString("dd-MMM hh:mm tt ")
                str2 = Nothing
                str2 = CDate(i.fechaVcto).ToString("dd-MMM hh:mm tt ")
                dr(0) = i.idDocumento
                dr(1) = str
                dr(2) = i.descripcion
                dr(3) = ""
                dr(4) = i.tipoDocumento
                dr(5) = ""
                dr(6) = i.numeroDoc
                dr(11) = i.PagoSumaMN
                dr(12) = i.PagoSumaME

                Select Case i.moneda
                    Case 1
                        dr(7) = "NAC"
                        dr(8) = i.importeMN
                        dr(9) = i.tipoCambio
                        dr(10) = CDec(0.0)
                        dr(13) = CDec(i.importeMN - i.PagoSumaMN).ToString("N2")
                        dr(14) = CDec(0.0)
                    Case Else
                        dr(7) = "EXT"
                        dr(8) = CDec(0.0)
                        dr(9) = i.tipoCambio
                        dr(10) = i.importeME
                        dr(13) = CDec(0.0)
                        dr(14) = CDec(i.importeME - i.PagoSumaME).ToString("N2")
                End Select

                Select Case i.estadoPago
                    Case TIPO_COMPRA.PAGO.PAGADO
                        dr(15) = "Saldado"
                    Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                        dr(15) = "Pendiente"
                End Select

                'monto vencidos dolares y soles
                If DateTime.Now.Date > i.fechaVcto Then

                    If i.moneda = "1" Then

                        Dim dias As Integer
                        Dim fecha1 As Date
                        Dim fecha2 As Date
                        fecha1 = DateTime.Now
                        fecha2 = i.FechaDoc
                        dias = (fecha1 - fecha2).TotalDays
                        dr(16) = dias
                        dr(17) = CDec(i.importeMN - i.PagoSumaMN).ToString("N2")
                        dr(18) = CDec(0.0)

                    ElseIf i.moneda = "2" Then

                        Dim dias As Integer
                        Dim fecha1 As Date
                        Dim fecha2 As Date
                        fecha1 = DateTime.Now
                        fecha2 = i.FechaDoc
                        dias = (fecha1 - fecha2).TotalDays

                        dr(16) = dias
                        dr(17) = CDec(0.0)
                        dr(18) = CDec(i.importeME - i.PagoSumaME).ToString("N2")

                    End If
                Else
                    dr(16) = 0
                    dr(17) = 0
                    dr(18) = 0
                End If

                dr(19) = str2

                If i.moneda = "1" Then
                    dr(20) = i.montocrono
                    dr(21) = CDec(0.0)
                    dr(22) = CDec(i.importeMN - i.PagoSumaMN - i.montocrono).ToString("N2")
                    dr(23) = CDec(0.0)
                    dr(24) = CDec(0.0)
                    dr(25) = CDec(0.0)
                    dr(26) = i.cuenta
                    dr(27) = i.secuencia

                    dr(28) = txtProveedor.Tag
                    dr(29) = txtProveedor.Text
                    If chProv.Checked = True Then
                        dr(30) = TIPO_ENTIDAD.PROVEEDOR
                    ElseIf chTrab.Checked = True Then
                        dr(30) = "TR"
                    ElseIf chCli.Checked = True Then

                        dr(30) = TIPO_ENTIDAD.CLIENTE
                    End If



                    If CDec(i.importeMN - i.PagoSumaMN - i.montocrono).ToString("N2") > 0 Then
                        dt.Rows.Add(dr)
                    End If

                ElseIf i.moneda = "2" Then
                    dr(20) = CDec(0.0)
                    dr(21) = i.montocronome
                    dr(22) = CDec(CDec(0.0))
                    dr(23) = CDec(i.importeME - i.PagoSumaME - i.montocronome).ToString("N2")
                    dr(24) = CDec(0.0)
                    dr(25) = CDec(0.0)
                    dr(26) = i.cuenta
                    dr(27) = i.secuencia
                    dr(28) = txtProveedor.Tag
                    dr(29) = txtProveedor.Text

                    If chProv.Checked = True Then
                        dr(30) = TIPO_ENTIDAD.PROVEEDOR
                    ElseIf chTrab.Checked = True Then
                        dr(30) = "TR"
                    ElseIf chCli.Checked = True Then

                        dr(30) = TIPO_ENTIDAD.CLIENTE
                    End If

                    If CDec(i.importeME - i.PagoSumaME - i.montocronome).ToString("N2") > 0 Then
                        dt.Rows.Add(dr)
                    End If

                End If

            Next

            dgvPagosV.DataSource = dt
            Me.dgvPagosV.TableOptions.ListBoxSelectionMode = SelectionMode.One
        Else

        End If
    End Sub

    Private Sub UbicarVentaNroSerieMNME(RucCliente As Integer)
        Dim documentoVentaSA As New documentoLibroDiarioSA
        Dim documentoVenta As New List(Of documentoLibroDiarioDetalle)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        'Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("fecha", GetType(String))
        dt.Columns.Add("descripcion", GetType(String))
        dt.Columns.Add("tipoVenta", GetType(String))
        dt.Columns.Add("tipoDoc", GetType(String))
        dt.Columns.Add("serie", GetType(String))
        dt.Columns.Add("numero", GetType(String))
        dt.Columns.Add("moneda", GetType(String))
        dt.Columns.Add("importeMN", GetType(Decimal))
        dt.Columns.Add("tipoCambio", GetType(Decimal))
        dt.Columns.Add("importeME", GetType(Decimal))
        dt.Columns.Add("abonoMN", GetType(Decimal))
        dt.Columns.Add("abonoME", GetType(Decimal))
        dt.Columns.Add("saldoMN", GetType(Decimal))
        dt.Columns.Add("saldoME", GetType(Decimal))
        dt.Columns.Add("estadoPago", GetType(String))
        dt.Columns.Add("dia", GetType(Integer))
        dt.Columns.Add("montoVenc", GetType(Decimal))
        dt.Columns.Add("montoVencme", GetType(Decimal))
        dt.Columns.Add("fechaVcto", GetType(String))
        dt.Columns.Add("montocrono", GetType(Decimal))
        dt.Columns.Add("montocronome", GetType(Decimal))
        dt.Columns.Add("montoxprog", GetType(Decimal))
        dt.Columns.Add("montoxprogme", GetType(Decimal))
        dt.Columns.Add("pago", GetType(Decimal))
        dt.Columns.Add("pagome", GetType(Decimal))
        dt.Columns.Add("cuenta", GetType(String))
        dt.Columns.Add("idsecuencia", GetType(Integer))
        dt.Columns.Add("idProveedor", GetType(Integer))
        dt.Columns.Add("nombre", GetType(String))
        dt.Columns.Add("tipoProveedor", GetType(String))

        documentoVenta = documentoVentaSA.UbicarPagosPorAsientoManualMNME(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, RucCliente)
        Dim str As String
        Dim str2 As String
        If Not IsNothing(documentoVenta) Then
            For Each i In documentoVenta
                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.FechaDoc).ToString("dd-MMM hh:mm tt ")
                str2 = Nothing
                str2 = CDate(i.fechaVcto).ToString("dd-MMM hh:mm tt ")
                dr(0) = i.idDocumento
                dr(1) = str
                dr(2) = i.descripcion
                dr(3) = ""
                dr(4) = i.tipoDocumento
                dr(5) = ""
                dr(6) = i.numeroDoc
                dr(11) = i.PagoSumaMN
                dr(12) = i.PagoSumaME

                Select Case i.moneda
                    Case 1
                        dr(7) = "NAC"
                        dr(8) = i.importeMN
                        dr(9) = i.tipoCambio
                        dr(10) = CDec(0.0)
                        dr(13) = CDec(i.importeMN - i.PagoSumaMN).ToString("N2")
                        dr(14) = CDec(0.0)
                    Case Else
                        dr(7) = "EXT"
                        dr(8) = CDec(0.0)
                        dr(9) = i.tipoCambio
                        dr(10) = i.importeME
                        dr(13) = CDec(0.0)
                        dr(14) = CDec(i.importeME - i.PagoSumaME).ToString("N2")
                End Select

                Select Case i.estadoPago
                    Case TIPO_COMPRA.PAGO.PAGADO
                        dr(15) = "Saldado"
                    Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                        dr(15) = "Pendiente"
                End Select

                'monto vencidos dolares y soles
                If DateTime.Now.Date > i.fechaVcto Then

                    If i.moneda = "1" Then

                        Dim dias As Integer
                        Dim fecha1 As Date
                        Dim fecha2 As Date
                        fecha1 = DateTime.Now
                        fecha2 = i.FechaDoc
                        dias = (fecha1 - fecha2).TotalDays
                        dr(16) = dias
                        dr(17) = CDec(i.importeMN - i.PagoSumaMN).ToString("N2")
                        dr(18) = CDec(0.0)

                    ElseIf i.moneda = "2" Then

                        Dim dias As Integer
                        Dim fecha1 As Date
                        Dim fecha2 As Date
                        fecha1 = DateTime.Now
                        fecha2 = i.FechaDoc
                        dias = (fecha1 - fecha2).TotalDays

                        dr(16) = dias
                        dr(17) = CDec(0.0)
                        dr(18) = CDec(i.importeME - i.PagoSumaME).ToString("N2")

                    End If
                Else
                    dr(16) = 0
                    dr(17) = 0
                    dr(18) = 0
                End If

                dr(19) = str2

                If i.moneda = "1" Then
                    dr(20) = i.montocrono
                    dr(21) = CDec(0.0)
                    dr(22) = CDec(i.importeMN - i.PagoSumaMN - i.montocrono).ToString("N2")
                    dr(23) = CDec(0.0)
                    dr(24) = CDec(0.0)
                    dr(25) = CDec(0.0)
                    dr(26) = i.cuenta
                    dr(27) = i.secuencia

                    dr(28) = txtProveedor.Tag
                    dr(29) = txtProveedor.Text
                    If chProv.Checked = True Then
                        dr(30) = TIPO_ENTIDAD.PROVEEDOR
                    ElseIf chTrab.Checked = True Then
                        dr(30) = "TR"
                    ElseIf chCli.Checked = True Then

                        dr(30) = TIPO_ENTIDAD.CLIENTE
                    End If



                    If CDec(i.importeMN - i.PagoSumaMN - i.montocrono).ToString("N2") > 0 Then
                        dt.Rows.Add(dr)
                    End If

                ElseIf i.moneda = "2" Then
                    dr(20) = CDec(0.0)
                    dr(21) = i.montocronome
                    dr(22) = CDec(CDec(0.0))
                    dr(23) = CDec(i.importeME - i.PagoSumaME - i.montocronome).ToString("N2")
                    dr(24) = CDec(0.0)
                    dr(25) = CDec(0.0)
                    dr(26) = i.cuenta
                    dr(27) = i.secuencia
                    dr(28) = txtProveedor.Tag
                    dr(29) = txtProveedor.Text

                    If chProv.Checked = True Then
                        dr(30) = TIPO_ENTIDAD.PROVEEDOR
                    ElseIf chTrab.Checked = True Then
                        dr(30) = "TR"
                    ElseIf chCli.Checked = True Then

                        dr(30) = TIPO_ENTIDAD.CLIENTE
                    End If

                    If CDec(i.importeME - i.PagoSumaME - i.montocronome).ToString("N2") > 0 Then
                        dt.Rows.Add(dr)
                    End If

                End If

            Next

            dgvPagosV.DataSource = dt
            Me.dgvPagosV.TableOptions.ListBoxSelectionMode = SelectionMode.One
        Else

        End If
    End Sub

    Public Sub CargarTrabajadoresXnivel(strNivel As String, strBusqueda As String)
        Dim personaSA As New PersonaSA
        Try
            lsvProveedor.Items.Clear()
            For Each i In personaSA.ObtenerPersonaNumDocPorNivelxDescripcion(Gempresas.IdEmpresaRuc, strNivel, strBusqueda)
                Dim n As New ListViewItem(i.idPersona)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(String.Empty)
                n.SubItems.Add(i.idPersona)
                lsvProveedor.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub


    Public Sub CargarEntidadesXtipo(strTipo As String, strBusqueda As String)
        Dim entidadSA As New entidadSA
        Try
            lsvProveedor.Items.Clear()
            For Each i As entidad In entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, strTipo, strBusqueda)
                Dim n As New ListViewItem(i.idEntidad)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(i.cuentaAsiento)
                n.SubItems.Add(i.nrodoc)
                lsvProveedor.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub
#End Region

    Private Sub frmFlujoAsientoManualPago_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmFlujoAsientoManualPago_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Me.popupControlContainer1.ParentControl = Me.txtProveedor
            Me.popupControlContainer1.ShowPopup(Point.Empty)
            If chProv.Checked = True Then
                CargarEntidadesXtipo(TIPO_ENTIDAD.PROVEEDOR, txtProveedor.Text.Trim)
            ElseIf chTrab.Checked = True Then
                CargarTrabajadoresXnivel("TR", txtProveedor.Text.Trim)
            ElseIf chCli.Checked = True Then

                CargarEntidadesXtipo(TIPO_ENTIDAD.CLIENTE, txtProveedor.Text.Trim)
            End If
        End If
    End Sub

    Private Sub txtProveedor_TextChanged(sender As Object, e As EventArgs) Handles txtProveedor.TextChanged

    End Sub

    Private Sub popupControlContainer1_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles popupControlContainer1.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                Me.txtProveedor.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                txtProveedor.Tag = lsvProveedor.SelectedItems(0).SubItems(0).Text
                txtRuc.Text = lsvProveedor.SelectedItems(0).SubItems(3).Text
                'txtCuenta = lsvProveedor.SelectedItems(0).SubItems(2).Text
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        If lsvProveedor.SelectedItems.Count > 0 Then
            Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub lsvProveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvProveedor.SelectedIndexChanged

    End Sub

    Private Sub ButtonAdv15_Click(sender As Object, e As EventArgs) Handles ButtonAdv15.Click
        Me.Cursor = Cursors.WaitCursor
        If txtProveedor.Text.Trim.Length > 0 Then

            If Not IsNothing(txtProveedor.Tag) Then

            Else
                MessageBox.Show("Ingrese una Identificacion ", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtProveedor.Focus()
                Exit Sub
            End If
            If txtTipoConsulta.Text = "PAGO" Then
                UbicarVentaNroSerieMNME(txtProveedor.Tag)
            ElseIf txtTipoConsulta.Text = "COBRO" Then
                UbicarCobrosPorAsientoManualMNME(txtProveedor.Tag)
            End If
        Else
            MessageBox.Show("Ingrese una Identificacion ", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    

    

    

    Private Sub chProv_Click(sender As Object, e As EventArgs) Handles chProv.Click
        chProv.Checked = True
        chTrab.Checked = False
        chCli.Checked = False
        txtProveedor.Clear()
        txtRuc.Clear()
    End Sub

    Private Sub chTrab_Click(sender As Object, e As EventArgs) Handles chTrab.Click
        chProv.Checked = False
        chTrab.Checked = True
        chCli.Checked = False
        txtProveedor.Clear()
        txtRuc.Clear()
    End Sub

    Private Sub chCli_Click(sender As Object, e As EventArgs) Handles chCli.Click
        chProv.Checked = False
        chTrab.Checked = False
        chCli.Checked = True
        txtProveedor.Clear()
        txtRuc.Clear()
    End Sub

   
    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        Me.Cursor = Cursors.WaitCursor

        If Not IsNothing(dgvPagosV.Table.CurrentRecord) Then
            If dgvPagosV.Table.CurrentRecord.GetValue("moneda") = "NAC" Then
                If dgvPagosV.Table.CurrentRecord.GetValue("montoxprog") > 0 Then

                    If txtTipoConsulta.Text = "PAGO" Then
                        Dim f As New frmNegociacionPagos
                        f.lblIdDocumento.Text = dgvPagosV.Table.CurrentRecord.GetValue("idDocumento")
                        f.txtImporteCompramn.Value = dgvPagosV.Table.CurrentRecord.GetValue("montoxprog")
                        f.txtImporteComprame.Value = dgvPagosV.Table.CurrentRecord.GetValue("montoxprogme")
                        f.txttipocambio.Value = dgvPagosV.Table.CurrentRecord.GetValue("tipoCambio")
                        f.txtMoneda.Text = dgvPagosV.Table.CurrentRecord.GetValue("moneda")
                        f.txtSerie.Text = dgvPagosV.Table.CurrentRecord.GetValue("serie")
                        f.txtNumero.Text = dgvPagosV.Table.CurrentRecord.GetValue("numero")
                        f.txtSecuencia.Text = dgvPagosV.Table.CurrentRecord.GetValue("idsecuencia")

                        'If txtTipoConsulta.Text = "PAGO" Then
                        f.lbltipo.Text = "PA"
                        'ElseIf txtTipoConsulta.Text = "COBRO" Then
                        '    f.lbltipo.Text = "CA"
                        'End If
                        f.chkSunat.Visible = True

                        f.txtCliente.Tag = dgvPagosV.Table.CurrentRecord.GetValue("idProveedor")
                        f.txtCliente.Text = dgvPagosV.Table.CurrentRecord.GetValue("nombre")
                        f.txtTipoProv.Text = dgvPagosV.Table.CurrentRecord.GetValue("tipoProveedor")

                        f.txtDescripcion.Text = dgvPagosV.Table.CurrentRecord.GetValue("descripcion")
                        f.txtCuenta.Text = dgvPagosV.Table.CurrentRecord.GetValue("cuenta")
                        f.txtRuc.Text = txtRuc.Text

                        f.txtDescripcion.Visible = True
                        f.txtCuenta.Visible = True
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog()
                        'End With
                        UbicarVentaNroSerieMNME(txtProveedor.Tag)

                    ElseIf txtTipoConsulta.Text = "COBRO" Then

                        Dim f As New frmNegociacionCobross
                        f.lblIdDocumento.Text = dgvPagosV.Table.CurrentRecord.GetValue("idDocumento")
                        f.txtImporteCompramn.Value = dgvPagosV.Table.CurrentRecord.GetValue("montoxprog")
                        f.txtImporteComprame.Value = dgvPagosV.Table.CurrentRecord.GetValue("montoxprogme")
                        f.txttipocambio.Value = dgvPagosV.Table.CurrentRecord.GetValue("tipoCambio")
                        f.txtMoneda.Text = dgvPagosV.Table.CurrentRecord.GetValue("moneda")
                        f.txtSerie.Text = dgvPagosV.Table.CurrentRecord.GetValue("serie")
                        f.txtNumero.Text = dgvPagosV.Table.CurrentRecord.GetValue("numero")
                        f.txtSecuencia.Text = dgvPagosV.Table.CurrentRecord.GetValue("idsecuencia")


                        'If txtTipoConsulta.Text = "PAGO" Then
                        '    f.lbltipo.Text = "PA"
                        'ElseIf txtTipoConsulta.Text = "COBRO" Then
                        f.lbltipo.Text = "CA"
                        'End If

                        f.chkSunat.Visible = True

                        f.txtCliente.Tag = dgvPagosV.Table.CurrentRecord.GetValue("idProveedor")
                        f.txtCliente.Text = dgvPagosV.Table.CurrentRecord.GetValue("nombre")
                        f.txtTipoProv.Text = dgvPagosV.Table.CurrentRecord.GetValue("tipoProveedor")

                        f.txtDescripcion.Text = dgvPagosV.Table.CurrentRecord.GetValue("descripcion")
                        f.txtCuenta.Text = dgvPagosV.Table.CurrentRecord.GetValue("cuenta")
                        f.txtRuc.Text = txtRuc.Text

                        f.txtDescripcion.Visible = True
                        f.txtCuenta.Visible = True
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog()
                        'End With
                        UbicarVentaNroSerieMNME(txtProveedor.Tag)


                    End If
            End If








            ElseIf dgvPagosV.Table.CurrentRecord.GetValue("moneda") = "EXT" Then
                If dgvPagosV.Table.CurrentRecord.GetValue("montoxprogme") > 0 Then

                    If txtTipoConsulta.Text = "PAGO" Then
                        Dim f As New frmNegociacionPagos

                        f.lblIdDocumento.Text = dgvPagosV.Table.CurrentRecord.GetValue("idDocumento")
                        f.txtImporteCompramn.Value = dgvPagosV.Table.CurrentRecord.GetValue("montoxprog")
                        f.txtImporteComprame.Value = dgvPagosV.Table.CurrentRecord.GetValue("montoxprogme")
                        f.txttipocambio.Value = dgvPagosV.Table.CurrentRecord.GetValue("tipoCambio")
                        f.txtMoneda.Text = dgvPagosV.Table.CurrentRecord.GetValue("moneda")
                        f.txtSerie.Text = dgvPagosV.Table.CurrentRecord.GetValue("serie")
                        f.txtNumero.Text = dgvPagosV.Table.CurrentRecord.GetValue("numero")
                        f.txtSecuencia.Text = dgvPagosV.Table.CurrentRecord.GetValue("idsecuencia")

                        f.lbltipo.Text = "PA"


                        f.chkSunat.Visible = True

                        f.txtCliente.Tag = dgvPagosV.Table.CurrentRecord.GetValue("idProveedor")
                        f.txtCliente.Text = dgvPagosV.Table.CurrentRecord.GetValue("nombre")
                        f.txtTipoProv.Text = dgvPagosV.Table.CurrentRecord.GetValue("tipoProveedor")

                        f.txtDescripcion.Text = dgvPagosV.Table.CurrentRecord.GetValue("descripcion")
                        f.txtCuenta.Text = dgvPagosV.Table.CurrentRecord.GetValue("cuenta")
                        f.txtRuc.Text = txtRuc.Text

                        f.txtDescripcion.Visible = True
                        f.txtCuenta.Visible = True
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog()
                        UbicarVentaNroSerieMNME(txtProveedor.Tag)

                    ElseIf txtTipoConsulta.Text = "COBRO" Then
                        Dim f As New frmNegociacionPagos

                        f.lblIdDocumento.Text = dgvPagosV.Table.CurrentRecord.GetValue("idDocumento")
                        f.txtImporteCompramn.Value = dgvPagosV.Table.CurrentRecord.GetValue("montoxprog")
                        f.txtImporteComprame.Value = dgvPagosV.Table.CurrentRecord.GetValue("montoxprogme")
                        f.txttipocambio.Value = dgvPagosV.Table.CurrentRecord.GetValue("tipoCambio")
                        f.txtMoneda.Text = dgvPagosV.Table.CurrentRecord.GetValue("moneda")
                        f.txtSerie.Text = dgvPagosV.Table.CurrentRecord.GetValue("serie")
                        f.txtNumero.Text = dgvPagosV.Table.CurrentRecord.GetValue("numero")
                        f.txtSecuencia.Text = dgvPagosV.Table.CurrentRecord.GetValue("idsecuencia")

                        f.lbltipo.Text = "CA"
                        f.chkSunat.Visible = True

                        f.txtCliente.Tag = dgvPagosV.Table.CurrentRecord.GetValue("idProveedor")
                        f.txtCliente.Text = dgvPagosV.Table.CurrentRecord.GetValue("nombre")
                        f.txtTipoProv.Text = dgvPagosV.Table.CurrentRecord.GetValue("tipoProveedor")

                        f.txtDescripcion.Text = dgvPagosV.Table.CurrentRecord.GetValue("descripcion")
                        f.txtCuenta.Text = dgvPagosV.Table.CurrentRecord.GetValue("cuenta")
                        f.txtRuc.Text = txtRuc.Text

                        f.txtDescripcion.Visible = True
                        f.txtCuenta.Visible = True
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog()
                        UbicarVentaNroSerieMNME(txtProveedor.Tag)
                    End If

                End If

            End If
        Else
            ' MessageBox.Show("Seleccione un Item a Editar")
            MessageBox.Show("Seleccione un Item a Editar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        UbicarTodoPagosAsientoManualMNME()
        Me.Cursor = Cursors.Arrow

    End Sub
End Class