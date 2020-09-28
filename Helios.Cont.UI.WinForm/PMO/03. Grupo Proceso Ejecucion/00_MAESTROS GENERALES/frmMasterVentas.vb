Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports System.ComponentModel
Imports Syncfusion.GridHelperClasses

Public Class frmMasterVentas
    Inherits frmMaster

    Dim colorx As New GridMetroColors()
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridCFG(dgvVentasTicket)
        GridCFG(dgvVentasnormales)
        GridCFG(dgvClientes)
        GridCFG(dgvAnticipos)
        'OptimizeGrid(dgvVentasTicket)
        Me.WindowState = FormWindowState.Maximized

        If Not IsNothing(GFichaUsuarios) Then
            Dim UsuarioEstadoCaja As New UsuarioEstadoCaja
            UsuarioEstadoCaja.GetSaldoActual(GFichaUsuarios)
            Me.CaptionLabels(0).Text = GFichaUsuarios.SaldoMN.ToString("N2")
        Else
            Me.CaptionLabels.RemoveAt(0)
            Me.CaptionImages.RemoveAt(0)
            '   Me.CaptionImages.RemoveAt(1)
        End If
        ToolStripLabel2.Text = PeriodoGeneral
    End Sub

#Region "CLIENTES"

    Public Sub EliminarAnticipo(IntIdDocumento As Integer)
        Dim documentoSA As New DocumentoSA
        Dim objDocumento As New documento

        With objDocumento
            .idDocumento = IntIdDocumento
        End With
        documentoSA.DeleteAnticipoSL(objDocumento)
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

    Private Sub ListaClientes()
        Dim dt As New DataTable()
        Dim entidad As New entidadSA

        dt.Columns.Add("idEntidad")
        dt.Columns.Add("tipoDoc")
        dt.Columns.Add("nroDoc")
        dt.Columns.Add("tipo")
        dt.Columns.Add("razon")
        dt.Columns.Add("direc")
        dt.Columns.Add("fono")

        For Each i In entidad.GetListarEntidad(New entidad With {.tipoEntidad = TIPO_ENTIDAD.CLIENTE, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.idEntidad
            Select Case i.tipoDoc
                Case "6"
                    dr(1) = "RUC"
                Case "1"
                    dr(1) = "DNI"
                Case "7"
                    dr(1) = "PASSAPORTE"
                Case "4"
                    dr(1) = "CARNET DE EXTRANJERIA"
            End Select

            dr(2) = i.nrodoc
            dr(3) = IIf(i.tipoPersona = "N", "NATURAL", "JURIDICO")
            dr(4) = i.nombreCompleto
            dr(5) = i.direccion
            dr(6) = i.telefono
            dt.Rows.Add(dr)
        Next
        dgvClientes.DataSource = dt
    End Sub
#End Region
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
        GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GGC.TableOptions.SelectionBackColor = Color.Gray
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


    Public Sub EliminarNota(intIdDocumentoNota As Integer)
        Dim compraSA As New documentoVentaAbarrotesSA
        Dim objDocumento As New documento
        Dim notaCredito As documentoventaAbarrotes
        Try
            notaCredito = compraSA.GetUbicar_documentoventaAbarrotesPorID(intIdDocumentoNota)
            With objDocumento
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                .IdDocumentoAfectado = notaCredito.idPadre ' venta
                .idDocumento = intIdDocumentoNota
            End With
            compraSA.EliminarNotaCreditoMetodoVenta(objDocumento)
            Me.dgvVentasnormales.Table.CurrentRecord.Delete()
            lblEstado.Text = "Nota eliminada correctamente!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub





    Private Sub getTableVentasNormalPorDiaCredito()
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Ventas Normal - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fecha", GetType(String)))
        dt.Columns.Add(New DataColumn("cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("doc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))

        dt.Columns.Add(New DataColumn("numero", GetType(String)))

        dt.Columns.Add(New DataColumn("importeMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeME", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("moneda", GetType(String)))
        dt.Columns.Add(New DataColumn("estadoCobro", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))

        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarVentasNormalPorDiaCredito(GEstableciento.IdEstablecimiento)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoVenta
            dr(2) = str
            dr(3) = i.NombreEntidad
            dr(4) = i.tipoDocumento
            dr(5) = i.serie
            dr(6) = i.numeroDocNormal
            dr(7) = i.ImporteNacional
            dr(8) = i.tipoCambio
            dr(9) = i.ImporteExtranjero
            dr(10) = i.moneda
            Select Case i.estadoCobro
                Case TIPO_VENTA.PAGO.COBRADO
                    dr(11) = "Venta"
                Case TIPO_VENTA.PAGO.PENDIENTE_PAGO
                    dr(11) = "Pedido"
                Case TIPO_VENTA.VENTA_NOTA_CREDITO
                    dr(11) = "(DA) nota crédito"
                Case TIPO_VENTA.VENTA_NORMAL_CONTADO
                    dr(11) = "(DC) cobrado"
                Case TIPO_VENTA.VENTA_ANULADA
                    dr(11) = "(VA) Anulado"
            End Select
            dr(12) = i.usuarioActualizacion
            dt.Rows.Add(dr)
        Next
        dgvVentasnormales.DataSource = dt

    End Sub



    Private Sub getTableVentasNormalPorPeriodoCredito()
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Ventas Normal - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fecha", GetType(String)))
        dt.Columns.Add(New DataColumn("cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("doc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))

        dt.Columns.Add(New DataColumn("numero", GetType(String)))

        dt.Columns.Add(New DataColumn("importeMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeME", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("moneda", GetType(String)))
        dt.Columns.Add(New DataColumn("estadoCobro", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))

        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarVentasNormalPorPeriodoCredito(GEstableciento.IdEstablecimiento, PeriodoGeneral)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoVenta
            dr(2) = str
            dr(3) = i.NombreEntidad
            dr(4) = i.tipoDocumento
            dr(5) = i.serie
            dr(6) = i.numeroDocNormal
            dr(7) = i.ImporteNacional
            dr(8) = i.tipoCambio
            dr(9) = i.ImporteExtranjero
            dr(10) = i.moneda
            Select Case i.estadoCobro
                Case TIPO_VENTA.PAGO.COBRADO
                    dr(11) = "Venta"
                Case TIPO_VENTA.PAGO.PENDIENTE_PAGO
                    dr(11) = "Pedido"
                Case TIPO_VENTA.VENTA_NOTA_CREDITO
                    dr(11) = "(DA) nota crédito"
                Case TIPO_VENTA.VENTA_NORMAL_CONTADO
                    dr(11) = "(DC) cobrado"
                Case TIPO_VENTA.VENTA_ANULADA
                    dr(11) = "(VA) Anulado"
            End Select
            dr(12) = i.usuarioActualizacion
            dt.Rows.Add(dr)
        Next
        dgvVentasnormales.DataSource = dt

    End Sub






    Private Sub getTableVentasAllNormalPorDia()
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Ventas Normal - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fecha", GetType(String)))
        dt.Columns.Add(New DataColumn("cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("doc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))

        dt.Columns.Add(New DataColumn("numero", GetType(String)))

        dt.Columns.Add(New DataColumn("importeMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeME", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("moneda", GetType(String)))
        dt.Columns.Add(New DataColumn("estadoCobro", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))

        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarAllVentasxDia(GEstableciento.IdEstablecimiento)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoVenta
            dr(2) = str
            dr(3) = i.nombrePedido
            dr(4) = i.tipoDocumento
            dr(5) = i.serie
            dr(6) = i.numeroDocNormal
            dr(7) = i.ImporteNacional
            dr(8) = i.tipoCambio
            dr(9) = i.ImporteExtranjero
            dr(10) = i.moneda
            Select Case i.estadoCobro
                Case TIPO_VENTA.PAGO.COBRADO
                    dr(11) = "Venta"
                Case TIPO_VENTA.PAGO.PENDIENTE_PAGO
                    dr(11) = "Pedido"
                Case TIPO_VENTA.VENTA_NOTA_CREDITO
                    dr(11) = "(DA) nota crédito"
                Case TIPO_VENTA.VENTA_NORMAL_CONTADO
                    dr(11) = "(DC) cobrado"
                Case TIPO_VENTA.VENTA_ANULADA
                    dr(11) = "(VA) Anulado"
            End Select
            dr(12) = i.usuarioActualizacion
            dt.Rows.Add(dr)
        Next
        dgvVentasnormales.DataSource = dt

    End Sub



    Private Sub getTableVentasAllNormalPorPeriodo()
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Ventas Normal - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fecha", GetType(String)))
        dt.Columns.Add(New DataColumn("cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("doc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))

        dt.Columns.Add(New DataColumn("numero", GetType(String)))

        dt.Columns.Add(New DataColumn("importeMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeME", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("moneda", GetType(String)))
        dt.Columns.Add(New DataColumn("estadoCobro", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))

        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarAllVentasPeriodo(GEstableciento.IdEstablecimiento, PeriodoGeneral)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoVenta
            dr(2) = str
            dr(3) = i.nombrePedido
            dr(4) = i.tipoDocumento
            dr(5) = i.serie
            dr(6) = i.numeroDocNormal
            dr(7) = i.ImporteNacional
            dr(8) = i.tipoCambio
            dr(9) = i.ImporteExtranjero
            dr(10) = i.moneda
            Select Case i.estadoCobro
                Case TIPO_VENTA.PAGO.COBRADO
                    dr(11) = "Venta"
                Case TIPO_VENTA.PAGO.PENDIENTE_PAGO
                    dr(11) = "Pedido"
                Case TIPO_VENTA.VENTA_NOTA_CREDITO
                    dr(11) = "(DA) nota crédito"
                Case TIPO_VENTA.VENTA_NORMAL_CONTADO
                    dr(11) = "(DC) cobrado"
                Case TIPO_VENTA.VENTA_ANULADA
                    dr(11) = "(VA) Anulado"
            End Select
            dr(12) = i.usuarioActualizacion
            dt.Rows.Add(dr)
        Next
        dgvVentasnormales.DataSource = dt

    End Sub





    Private Sub getTableVentasNormalPorDia()
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Ventas Normal - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fecha", GetType(String)))
        dt.Columns.Add(New DataColumn("cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("doc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))

        dt.Columns.Add(New DataColumn("numero", GetType(String)))

        dt.Columns.Add(New DataColumn("importeMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeME", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("moneda", GetType(String)))
        dt.Columns.Add(New DataColumn("estadoCobro", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))

        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarVentasNormalPorDia(GEstableciento.IdEstablecimiento)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoVenta
            dr(2) = str
            dr(3) = i.NombreEntidad
            dr(4) = i.tipoDocumento
            dr(5) = i.serie
            dr(6) = i.numeroDocNormal
            dr(7) = i.ImporteNacional
            dr(8) = i.tipoCambio
            dr(9) = i.ImporteExtranjero
            dr(10) = i.moneda
            Select Case i.estadoCobro
                Case TIPO_VENTA.PAGO.COBRADO
                    dr(11) = "Venta"
                Case TIPO_VENTA.PAGO.PENDIENTE_PAGO
                    dr(11) = "Pedido"
                Case TIPO_VENTA.VENTA_NOTA_CREDITO
                    dr(11) = "(DA) nota crédito"
                Case TIPO_VENTA.VENTA_NORMAL_CONTADO
                    dr(11) = "(DC) cobrado"
                Case TIPO_VENTA.VENTA_ANULADA
                    dr(11) = "(VA) Anulado"
            End Select
            dr(12) = i.usuarioActualizacion
            dt.Rows.Add(dr)
        Next
        dgvVentasnormales.DataSource = dt

    End Sub




    Private Sub getTableVentasNormalPorPeriodo()
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Ventas Normal - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fecha", GetType(String)))
        dt.Columns.Add(New DataColumn("cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("doc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))

        dt.Columns.Add(New DataColumn("numero", GetType(String)))

        dt.Columns.Add(New DataColumn("importeMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeME", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("moneda", GetType(String)))
        dt.Columns.Add(New DataColumn("estadoCobro", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))

        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarVentasNormalPorPeriodo(GEstableciento.IdEstablecimiento, PeriodoGeneral)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoVenta
            dr(2) = str
            dr(3) = i.NombreEntidad
            dr(4) = i.tipoDocumento
            dr(5) = i.serie
            dr(6) = i.numeroDocNormal
            dr(7) = i.ImporteNacional
            dr(8) = i.tipoCambio
            dr(9) = i.ImporteExtranjero
            dr(10) = i.moneda
            Select Case i.estadoCobro
                Case TIPO_VENTA.PAGO.COBRADO
                    dr(11) = "Venta"
                Case TIPO_VENTA.PAGO.PENDIENTE_PAGO
                    dr(11) = "Pedido"
                Case TIPO_VENTA.VENTA_NOTA_CREDITO
                    dr(11) = "(DA) nota crédito"
                Case TIPO_VENTA.VENTA_NORMAL_CONTADO
                    dr(11) = "(DC) cobrado"
                Case TIPO_VENTA.VENTA_ANULADA
                    dr(11) = "(VA) Anulado"
            End Select
            dr(12) = i.usuarioActualizacion
            dt.Rows.Add(dr)
        Next
        dgvVentasnormales.DataSource = dt

    End Sub

    Private Sub getTableVentasPorDia()
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Ventas ticket - día " & DateTime.Now & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoVenta", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDocumento", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))

        dt.Columns.Add(New DataColumn("nombrePedido", GetType(String)))

        dt.Columns.Add(New DataColumn("ImporteNacional", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ImporteExtranjero", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("estadoCobro", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioCaja", GetType(String)))

        Dim str As String
        'For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarVentasPorDiaEstablecimiento(GEstableciento.IdEstablecimiento, TIPO_VENTA.VENTA_AL_TICKET, GFichaUsuarios.IdCajaUsuario)
        '    Dim dr As DataRow = dt.NewRow()
        '    str = Nothing
        '    str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
        '    dr(0) = i.idDocumento
        '    dr(1) = i.tipoVenta
        '    dr(2) = str
        '    Select Case i.tipoDocumento
        '        Case "03"
        '            dr(3) = "TICKET BOLETA"
        '        Case "01"
        '            dr(3) = "TICKET FACTURA"
        '        Case Else
        '            dr(3) = i.tipoDocumento
        '    End Select

        '    dr(4) = i.serie
        '    dr(5) = i.numeroDoc
        '    dr(6) = i.nombrePedido
        '    dr(7) = i.ImporteNacional
        '    dr(8) = i.tipoCambio
        '    dr(9) = i.ImporteExtranjero
        '    Select Case i.estadoCobro
        '        Case TIPO_VENTA.PAGO.COBRADO
        '            dr(10) = "Vendido"
        '        Case TIPO_VENTA.PAGO.PENDIENTE_PAGO
        '            dr(10) = "Pedido"
        '        Case TIPO_VENTA.VENTA_NOTA_CREDITO
        '            dr(10) = "(DA) nota crédito"
        '        Case TIPO_VENTA.VENTA_ANULADA
        '            dr(10) = "(VA) Anulado"
        '    End Select

        '    dr(11) = i.usuarioActualizacion
        '    dt.Rows.Add(dr)
        'Next
        dgvVentasTicket.DataSource = dt

    End Sub

    Private Sub getTableVentasPorPeriodo()


        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA
        Dim DocumentoVenta As New List(Of documentoventaAbarrotes)

        Dim dt As New DataTable("Ventas ticket - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim cl1 As New ChildList()
        Dim al As New ArrayList()

        Dim str As String

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoVenta", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDocumento", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))

        dt.Columns.Add(New DataColumn("nombrePedido", GetType(String)))

        dt.Columns.Add(New DataColumn("ImporteNacional", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ImporteExtranjero", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("estadoCobro", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioCaja", GetType(String)))

        Select Case AutorizacionRolList(0).IDRol
            Case 1
                DocumentoVenta = DocumentoVentaSA.GetListarVentasPorPeriodo(GEstableciento.IdEstablecimiento, PeriodoGeneral, TIPO_VENTA.VENTA_AL_TICKET)
            Case 2
                DocumentoVenta = DocumentoVentaSA.GetListarVentasPorPeriodo(GEstableciento.IdEstablecimiento, PeriodoGeneral, TIPO_VENTA.VENTA_AL_TICKET, GFichaUsuarios.IdCajaUsuario)
        End Select

        For Each i As documentoventaAbarrotes In DocumentoVenta
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoVenta
            dr(2) = str
            Select Case i.tipoDocumento
                Case "03"
                    dr(3) = "TICKET BOLETA"
                Case "01"
                    dr(3) = "TICKET FACTURA"
                Case Else
                    dr(3) = i.tipoDocumento
            End Select

            dr(4) = i.serie
            dr(5) = i.numeroDoc
            dr(6) = i.nombrePedido
            dr(7) = i.ImporteNacional
            dr(8) = i.tipoCambio
            dr(9) = i.ImporteExtranjero
            Select Case i.estadoCobro
                Case TIPO_VENTA.PAGO.COBRADO
                    dr(10) = "Vendido"
                Case TIPO_VENTA.PAGO.PENDIENTE_PAGO
                    dr(10) = "Pedido"
                Case TIPO_VENTA.VENTA_NOTA_CREDITO
                    dr(10) = "(DA) nota crédito"
                Case TIPO_VENTA.VENTA_ANULADA
                    dr(10) = "(VA) Anulado"
            End Select

            dr(11) = i.usuarioActualizacion
            dt.Rows.Add(dr)
        Next
        dgvVentasTicket.DataSource = dt

    End Sub

#Region "Métodos"
    Public Sub EliminarVentaServicio(IntIdDocumento As Integer, strTipoVenta As String)

        Dim documentoSA As New DocumentoSA
        Dim documentoDetalleSA As New documentoVentaAbarrotesDetSA
        Dim objDocumento As New documento

        With objDocumento
            .idDocumento = IntIdDocumento
            .tipoDoc = strTipoVenta ' TIPO_VENTA.VENTA_AL_TICKET
        End With

        documentoSA.DeleteVentaNormalServicio(objDocumento)
    End Sub



    Public Sub EliminarVentaAlCredito(IntIdDocumento As Integer, strTipoVenta As String)
        Dim almacenSA As New almacenSA
        Dim almacen As New almacen
        Dim documentoSA As New DocumentoSA
        Dim documentoDetalleSA As New documentoVentaAbarrotesDetSA
        Dim objDocumento As New documento
        Dim objNuevo As New totalesAlmacen
        Dim ListaTotales As New List(Of totalesAlmacen)

        With objDocumento
            .idDocumento = IntIdDocumento
            .tipoDoc = strTipoVenta ' TIPO_VENTA.VENTA_AL_TICKET
        End With
        For Each i In documentoDetalleSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(IntIdDocumento)
            If Not IsNothing(i.idAlmacenOrigen) Then

                almacen = almacenSA.GetUbicar_almacenPorID(i.idAlmacenOrigen)
                If Not IsNothing(almacen) Then
                    If Not almacen.tipo = "AV" Then
                        objNuevo = New totalesAlmacen
                        objNuevo.SecuenciaDetalle = i.secuencia
                        objNuevo.idEmpresa = Gempresas.IdEmpresaRuc
                        objNuevo.idEstablecimiento = almacen.idEstablecimiento
                        objNuevo.idAlmacen = almacen.idAlmacen
                        objNuevo.origenRecaudo = i.destino
                        objNuevo.idItem = i.idItem
                        objNuevo.TipoDoc = Me.dgvVentasnormales.Table.CurrentRecord.GetValue("tipoDocumento")

                        objNuevo.importeSoles = i.salidaCostoMN * -1
                        objNuevo.importeDolares = i.salidaCostoME * -1
                        'Select Case lsvListaPedidos.SelectedItems(0).SubItems(3).Text
                        '    Case "03", "02"
                        '        objNuevo.importeSoles = i.importeMN * -1
                        '        objNuevo.importeDolares = i.importeME * -1
                        '    Case Else
                        '        Select Case i.destino
                        '            Case "1"
                        '                objNuevo.importeSoles = i.montokardex * -1
                        '                objNuevo.importeDolares = i.montokardexUS * -1
                        '            Case Else
                        '                objNuevo.importeSoles = i.importeMN * -1
                        '                objNuevo.importeDolares = i.importeME * -1
                        '        End Select
                        'End Select

                        objNuevo.cantidad = i.monto1 * -1
                        objNuevo.precioUnitarioCompra = i.precioUnitario

                        objNuevo.montoIsc = i.montoIsc * -1
                        objNuevo.montoIscUS = i.montoIscUS * -1

                        ListaTotales.Add(objNuevo)

                    End If
                End If

            End If

        Next
        documentoSA.DeleteVentaNormalAlCredito(objDocumento, ListaTotales)
    End Sub

    Public Sub EliminarVentaGeneral(IntIdDocumento As Integer)
        Dim documentoSA As New DocumentoSA
        Dim documentoDetalleSA As New DocumentoCompraDetalleSA
        Dim objDocumento As New documento
        Dim objNuevo As New totalesAlmacen
        Dim almacenSA As New almacenSA
        Dim almacen As New almacen
        Dim ListaTotales As New List(Of totalesAlmacen)

        With objDocumento
            .idDocumento = Me.dgvVentasnormales.Table.CurrentRecord.GetValue("idDocumento")
            .fechaProceso = PeriodoGeneral
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .usuarioActualizacion = "Jiuni"
            .fechaProceso = Date.Now
            .tipoDoc = 9901
            .nroDoc = Me.dgvVentasnormales.Table.CurrentRecord.GetValue("serie") + "-" + Me.dgvVentasnormales.Table.CurrentRecord.GetValue("numeroDoc")
            .tipoOperacion = 2
            .fechaActualizacion = Date.Now
        End With
        documentoSA.EliminarCompraGeneral(objDocumento)
    End Sub

    Public Sub EliminarVentaCobrada(IntIdDocumento As Integer, varIdCajaUser As Integer, strTipoVenta As String)
        Dim almacenSA As New almacenSA
        Dim almacen As New almacen
        Dim documentoSA As New DocumentoSA
        Dim documentoDetalleSA As New documentoVentaAbarrotesDetSA
        Dim objDocumento As New documento
        Dim objNuevo As New totalesAlmacen
        Dim ListaTotales As New List(Of totalesAlmacen)

        With objDocumento
            .idDocumento = IntIdDocumento
            .usuarioActualizacion = varIdCajaUser
            .tipoDoc = strTipoVenta ' TIPO_VENTA.VENTA_AL_TICKET
        End With
        For Each i In documentoDetalleSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(IntIdDocumento)
            If Not IsNothing(i.idAlmacenOrigen) Then

                almacen = almacenSA.GetUbicar_almacenPorID(i.idAlmacenOrigen)
                If Not IsNothing(almacen) Then
                    If Not almacen.tipo = "AV" Then
                        objNuevo = New totalesAlmacen
                        objNuevo.SecuenciaDetalle = i.secuencia
                        objNuevo.idEmpresa = Gempresas.IdEmpresaRuc
                        objNuevo.idEstablecimiento = almacen.idEstablecimiento
                        objNuevo.idAlmacen = almacen.idAlmacen
                        objNuevo.origenRecaudo = i.destino
                        objNuevo.idItem = i.idItem
                        objNuevo.TipoDoc = Me.dgvVentasTicket.Table.CurrentRecord.GetValue("tipoDocumento")

                        objNuevo.importeSoles = i.salidaCostoMN * -1
                        objNuevo.importeDolares = i.salidaCostoME * -1
                        'Select Case lsvListaPedidos.SelectedItems(0).SubItems(3).Text
                        '    Case "03", "02"
                        '        objNuevo.importeSoles = i.importeMN * -1
                        '        objNuevo.importeDolares = i.importeME * -1
                        '    Case Else
                        '        Select Case i.destino
                        '            Case "1"
                        '                objNuevo.importeSoles = i.montokardex * -1
                        '                objNuevo.importeDolares = i.montokardexUS * -1
                        '            Case Else
                        '                objNuevo.importeSoles = i.importeMN * -1
                        '                objNuevo.importeDolares = i.importeME * -1
                        '        End Select
                        'End Select

                        objNuevo.cantidad = i.monto1 * -1
                        objNuevo.precioUnitarioCompra = i.precioUnitario

                        objNuevo.montoIsc = i.montoIsc * -1
                        objNuevo.montoIscUS = i.montoIscUS * -1

                        ListaTotales.Add(objNuevo)

                    End If
                End If

            End If

        Next
        documentoSA.DeleteVentaTicketCobrado(objDocumento, ListaTotales)
    End Sub

    Public Sub EliminarVenta(IntIdDocumento As Integer)
        Dim almacenSA As New almacenSA
        Dim almacen As New almacen
        Dim documentoSA As New DocumentoSA
        Dim documentoDetalleSA As New documentoVentaAbarrotesDetSA
        Dim objDocumento As New documento
        Dim objNuevo As New totalesAlmacen
        Dim ListaTotales As New List(Of totalesAlmacen)

        With objDocumento
            .idDocumento = IntIdDocumento
        End With
        For Each i In documentoDetalleSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(IntIdDocumento)
            If Not IsNothing(i.idAlmacenOrigen) Then

                almacen = almacenSA.GetUbicar_almacenPorID(i.idAlmacenOrigen)
                If Not IsNothing(almacen) Then
                    If Not almacen.tipo = "AV" Then
                        objNuevo = New totalesAlmacen
                        objNuevo.SecuenciaDetalle = i.secuencia
                        objNuevo.idEmpresa = Gempresas.IdEmpresaRuc
                        objNuevo.idEstablecimiento = almacen.idEstablecimiento
                        objNuevo.idAlmacen = almacen.idAlmacen
                        objNuevo.origenRecaudo = i.destino
                        objNuevo.idItem = i.idItem
                        objNuevo.TipoDoc = Me.dgvVentasTicket.Table.CurrentRecord.GetValue("tipoDocumento")

                        objNuevo.importeSoles = i.salidaCostoMN * -1
                        objNuevo.importeDolares = i.salidaCostoME * -1
                        'Select Case lsvListaPedidos.SelectedItems(0).SubItems(3).Text
                        '    Case "03", "02"
                        '        objNuevo.importeSoles = i.importeMN * -1
                        '        objNuevo.importeDolares = i.importeME * -1
                        '    Case Else
                        '        Select Case i.destino
                        '            Case "1"
                        '                objNuevo.importeSoles = i.montokardex * -1
                        '                objNuevo.importeDolares = i.montokardexUS * -1
                        '            Case Else
                        '                objNuevo.importeSoles = i.importeMN * -1
                        '                objNuevo.importeDolares = i.importeME * -1
                        '        End Select
                        'End Select

                        objNuevo.cantidad = i.monto1 * -1
                        objNuevo.precioUnitarioCompra = i.precioUnitario

                        objNuevo.montoIsc = i.montoIsc * -1
                        objNuevo.montoIscUS = i.montoIscUS * -1

                        ListaTotales.Add(objNuevo)

                    End If
                End If

            End If

        Next
        documentoSA.DeleteVentaTicket(objDocumento, ListaTotales)
    End Sub

    Public Function TieneCuentaFinanciera(Optional intIdDocumento As Integer = Nothing) As Boolean
        Dim efSA As New EstadosFinancierosSA
        Dim ef As New estadosFinancieros
        Dim estableSA As New establecimientoSA

        With frmFichaUsuarioCaja
            ModuloAppx = ModuloSistema.CAJA
            .lblNivel.Text = "Caja"
            .lblEstadoCaja.Visible = True
            '.GroupBox1.Visible = True
            '.GroupBox2.Visible = True
            '.GroupBox4.Visible = True
            '.cboMoneda.Visible = True
            .Timer1.Enabled = False
            .StartPosition = FormStartPosition.CenterParent
            '.UbicarUsuarioCaja(intIdDocumento, "VENTA")
            .ShowDialog()
            If IsNothing(GFichaUsuarios.NombrePersona) Then
                Return False
            Else
                Return True
            End If
        End With

        Return True

    End Function
#End Region

    Private Sub OptimizeGrid(gridGroupingControl As GridGroupingControl)
        ' Couple settings to perform better:
        gridGroupingControl.Engine.CounterLogic = EngineCounters.FilteredRecords
        gridGroupingControl.Engine.AllowedOptimizations = EngineOptimizations.DisableCounters Or EngineOptimizations.RecordsAsDisplayElements Or EngineOptimizations.VirtualMode
        gridGroupingControl.TableOptions.VerticalPixelScroll = False
        gridGroupingControl.Engine.TableOptions.ColumnsMaxLengthStrategy = GridColumnsMaxLengthStrategy.FirstNRecords
        gridGroupingControl.Engine.TableOptions.ColumnsMaxLengthFirstNRecords = 100
    End Sub

#Region "Motodos listas"
    Private Sub getTableAnticiposPorPeriodo()
        Dim DocumentoAnticipoSL As New documentoAnticipo
        Dim dt As New DataTable("Aportes de Proveedor - período " & PeriodoGeneral & " ")
        Dim documentoAnticipoSA As New documentoAnticipoSA
        Dim cl1 As New ChildList()
        Dim al As New ArrayList()

        Dim str As String

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoDocumento", GetType(String)))

        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoOperacion", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoAnticipo", GetType(String)))

        dt.Columns.Add(New DataColumn("razonSocial", GetType(String)))

        dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ImporteNacional", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ImporteExtranjero", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("idEntidadFinanciera", GetType(String)))



        For Each i As documentoAnticipo In documentoAnticipoSA.getTableAnticiposPorPeriodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, PeriodoGeneral)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            Select Case i.tipoDocumento
                Case "9901"
                    dr(1) = "VOUCHER CONTABLE"
            End Select
            dr(2) = i.numeroDoc
            dr(3) = str
            Select Case i.tipoOperacion
                Case "103"
                    dr(4) = "ANTICIPO RECIBIDO"
            End Select
            dr(5) = i.tipoAnticipo
            dr(6) = i.NombreEntidad
            dr(7) = i.TipoCambio
            dr(8) = i.importeMN
            dr(9) = i.importeME
            dr(10) = i.NombreEstadoFinanciero
            dt.Rows.Add(dr)
        Next
        dgvAnticipos.DataSource = dt

    End Sub

    Public Class Data
        Public Sub New()
            Me.New("", "", 0, 0, 0, 0)
        End Sub

        Public Sub New(cuenta As String, descrip As String, debesoles As Decimal, habersoles As Decimal, debedolares As Decimal, haberdolares As Decimal)
            Me.CuentaCtble = cuenta
            Me.Descripcion = descrip
            Me.Debemn = debesoles
            Me.Habermn = habersoles
            Me.Debeme = debedolares
            Me.Haberme = haberdolares
        End Sub
        Private cuenta As String
        Public Property CuentaCtble() As String
            Get
                Return Me.cuenta
            End Get
            Set(value As String)
                Me.cuenta = value
            End Set
        End Property
        Private desc As String
        Public Property Descripcion() As String
            Get
                Return Me.desc
            End Get
            Set(value As String)
                Me.desc = value
            End Set
        End Property

        Private dbmn As Decimal
        Public Property Debemn() As Decimal
            Get
                Return dbmn
            End Get
            Set(ByVal value As Decimal)
                dbmn = value
            End Set
        End Property

        Private hbmn As Decimal
        Public Property Habermn() As Decimal
            Get
                Return hbmn
            End Get
            Set(ByVal value As Decimal)
                hbmn = value
            End Set
        End Property

        Private dbme As Decimal
        Public Property Debeme() As Decimal
            Get
                Return dbme
            End Get
            Set(ByVal value As Decimal)
                dbme = value
            End Set
        End Property

        Private hbme As Decimal
        Public Property Haberme() As Decimal
            Get
                Return hbme
            End Get
            Set(ByVal value As Decimal)
                hbme = value
            End Set
        End Property

    End Class

    Public Class ChildList
        Inherits ArrayList
        Implements ITypedList

#Region "ITypedList Members"

        Public Function GetItemProperties(listAccessors As PropertyDescriptor()) As PropertyDescriptorCollection Implements ITypedList.GetItemProperties
            Return TypeDescriptor.GetProperties(GetType(Data))
        End Function

        Public Function GetListName(listAccessors As PropertyDescriptor()) As String Implements ITypedList.GetListName
            Return "Data"
        End Function

#End Region

    End Class

    Public Class ParentItem
        Private idDoc As String, tipo_venta As String, fec As String, tdoc As String, serie_doc As String, num As String, pedido As String, impmn As Decimal, tipo_cambio As Decimal, impme As Decimal, estado As String, usercaja As String
        Private m_child As ChildList
        Public Property idDocumento() As String
            Get
                Return idDoc
            End Get
            Set(value As String)
                idDoc = value
            End Set
        End Property
        Public Property tipoVenta() As String
            Get
                Return tipo_venta
            End Get
            Set(value As String)
                tipo_venta = value
            End Set
        End Property
        Public Property fechaDoc() As String
            Get
                Return fec
            End Get
            Set(value As String)
                fec = value
            End Set
        End Property

        Public Property tipoDocumento() As String
            Get
                Return tdoc
            End Get
            Set(value As String)
                tdoc = value
            End Set
        End Property

        Public Property serie() As String
            Get
                Return serie_doc
            End Get
            Set(value As String)
                serie_doc = value
            End Set
        End Property

        Public Property numeroDoc() As String
            Get
                Return num
            End Get
            Set(value As String)
                num = value
            End Set
        End Property

        Public Property nombrePedido() As String
            Get
                Return pedido
            End Get
            Set(value As String)
                pedido = value
            End Set
        End Property

        Public Property ImporteNacional() As Decimal
            Get
                Return impmn
            End Get
            Set(value As Decimal)
                impmn = value
            End Set
        End Property

        Public Property tipoCambio() As Decimal
            Get
                Return tipo_cambio
            End Get
            Set(value As Decimal)
                tipo_cambio = value
            End Set
        End Property

        Public Property ImporteExtranjero() As Decimal
            Get
                Return impme
            End Get
            Set(value As Decimal)
                impme = value
            End Set
        End Property

        Public Property estadoCobro() As String
            Get
                Return estado
            End Get
            Set(value As String)
                estado = value
            End Set
        End Property

        Public Property usuarioCaja() As String
            Get
                Return usercaja
            End Get
            Set(value As String)
                usercaja = value
            End Set
        End Property

        Public Property Child() As ChildList
            Get
                Return m_child
            End Get
            Set(value As ChildList)
                m_child = value
            End Set
        End Property

        'Public Sub New()
        '    Me.New("", "", "", "", "", "", 0, 0, 0)
        'End Sub
        Public Sub New(iddoc As String, tipoveta As String, fecha As String, tipodoc As String, serie As String, num As String, ped As String, soles As Decimal, dolares As Decimal, tc As Decimal, estado_caja As String, user As String, dt As ChildList)
            Me.idDocumento = iddoc
            Me.tipoVenta = tipoveta
            Me.fechaDoc = fecha
            Me.tipoDocumento = tipodoc
            Me.serie = serie
            Me.numeroDoc = num
            Me.nombrePedido = ped
            Me.ImporteNacional = soles
            Me.ImporteExtranjero = dolares
            Me.tipoCambio = tc
            Me.estadoCobro = estado_caja
            Me.usuarioCaja = user
            Me.m_child = dt
        End Sub
    End Class
#End Region

    Private Sub frmMasterVentas_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmMasterVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabPageAdv1.Parent = TabControlAdv1
        TabPageAdv2.Parent = Nothing
        TabPageAdv3.Parent = Nothing
        TabPageAdv4.Parent = Nothing
        Me.treeViewAdv2.SelectedNode = Me.treeViewAdv2.Nodes(0)
    End Sub

    Private Sub treeViewAdv2_Click(sender As Object, e As EventArgs) Handles treeViewAdv2.Click

    End Sub

    Private Sub treeViewAdv2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles treeViewAdv2.MouseDoubleClick
        Me.Cursor = Cursors.WaitCursor
        Select Case treeViewAdv2.SelectedNode.Text
            Case "Ventas con ticket"
                TabPageAdv1.Parent = TabControlAdv1
                TabPageAdv2.Parent = Nothing
                TabPageAdv3.Parent = Nothing
                TabPageAdv4.Parent = Nothing
                'Tag = "VentaTicket"
                If rbPeriodo.Checked = True Then
                    getTableVentasPorPeriodo()

                    lstVenta.Items.Clear()
                    lstVenta.Items.Add("Preventa")
                    lstVenta.Items.Add("Ticket Directo")

                End If
                If rbDia.Checked = True Then
                    getTableVentasPorDia()

                    lstVenta.Items.Clear()
                    lstVenta.Items.Add("Preventa")
                    lstVenta.Items.Add("Ticket Directo")

                End If
                TabPageAdv1.Text = treeViewAdv2.SelectedNode.Text

            Case "Ventas al Credito"
                TabPageAdv1.Parent = Nothing
                TabPageAdv2.Parent = TabControlAdv1
                TabPageAdv3.Parent = Nothing
                TabPageAdv4.Parent = Nothing
                ' Tag = "Ventas al Credito"
                TabPageAdv2.Text = treeViewAdv2.SelectedNode.Text

                If rbPeriodo.Checked = True Then
                    getTableVentasNormalPorPeriodoCredito()
                    lstVenta.Items.Clear()
                    lstVenta.Items.Add("Venta normal al Credito")
                    lstVenta.Items.Add("Servicios al Credito")

                End If

                If rbDia.Checked = True Then

                    getTableVentasNormalPorDiaCredito()
                    lstVenta.Items.Clear()
                    lstVenta.Items.Add("Venta normal al Credito")
                    lstVenta.Items.Add("Servicios al Credito")

                End If

            Case "Ventas al Contado"

                TabPageAdv1.Parent = Nothing
                TabPageAdv2.Parent = TabControlAdv1
                TabPageAdv3.Parent = Nothing
                TabPageAdv4.Parent = Nothing
                ' Tag = "Ventas al Contado"
                TabPageAdv2.Text = treeViewAdv2.SelectedNode.Text

                If rbPeriodo.Checked = True Then
                    getTableVentasNormalPorPeriodo()
                    lstVenta.Items.Clear()
                    lstVenta.Items.Add("Venta normal directa")
                    lstVenta.Items.Add("Servicios al Contado")

                End If

                If rbDia.Checked = True Then
                    getTableVentasNormalPorDia()
                    lstVenta.Items.Clear()
                    lstVenta.Items.Add("Venta normal directa")
                    lstVenta.Items.Add("Servicios al Contado")

                End If


            Case "Clientes"
                TabPageAdv1.Parent = Nothing
                TabPageAdv2.Parent = Nothing
                TabPageAdv3.Parent = TabControlAdv1
                TabPageAdv4.Parent = Nothing
                ' Tag = "Clientes"
                ListaClientes()
                lstVenta.Items.Clear()



            Case "Ventas del período"
                TabPageAdv1.Parent = Nothing
                TabPageAdv2.Parent = TabControlAdv1
                TabPageAdv3.Parent = Nothing
                TabPageAdv4.Parent = Nothing
                ' Tag = "All Ventas"
                TabPageAdv2.Text = treeViewAdv2.SelectedNode.Text

                If rbPeriodo.Checked = True Then
                    getTableVentasAllNormalPorPeriodo()
                    lstVenta.Items.Clear()
                    lstVenta.Items.Add("Preventa")
                    lstVenta.Items.Add("Ticket Directo")
                    lstVenta.Items.Add("Venta normal directa")
                    lstVenta.Items.Add("Servicios al Contado")
                    lstVenta.Items.Add("Venta normal al Credito")
                    lstVenta.Items.Add("Servicios al Credito")

                End If

                If rbDia.Checked = True Then
                    getTableVentasAllNormalPorDia()
                    lstVenta.Items.Clear()
                    lstVenta.Items.Add("Preventa")
                    lstVenta.Items.Add("Ticket Directo")
                    lstVenta.Items.Add("Venta normal directa")
                    lstVenta.Items.Add("Servicios al Contado")
                    lstVenta.Items.Add("Venta normal al Credito")
                    lstVenta.Items.Add("Servicios al Credito")

                End If




        End Select
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        'Me.PopupControlContainer1.ParentControl = Me.btOperacion
        'Me.PopupControlContainer1.ShowPopup(Point.Empty)
        'Me.Cursor = Cursors.WaitCursor
        Select Case treeViewAdv2.SelectedNode.Text
            Case "Clientes"
                lstVenta.Items.Clear()
                Dim f As New frmCrearENtidades
                f.CaptionLabels(0).Text = "Nuevo cliente"
                f.strTipo = TIPO_ENTIDAD.CLIENTE
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()

            Case "Ventas con ticket"
                lstVenta.Items.Clear()
                lstVenta.Items.Add("Preventa")
                lstVenta.Items.Add("Ticket Directo")
                Me.PopupControlContainer1.ParentControl = Me.btOperacion
                Me.PopupControlContainer1.ShowPopup(Point.Empty)

            Case "Ventas al Contado"
                lstVenta.Items.Clear()
                lstVenta.Items.Add("Venta normal directa")
                lstVenta.Items.Add("Servicios al Contado")
                Me.PopupControlContainer1.ParentControl = Me.btOperacion
                Me.PopupControlContainer1.ShowPopup(Point.Empty)

            Case "Ventas al Credito"
                lstVenta.Items.Clear()
                lstVenta.Items.Add("Venta normal al Credito")
                lstVenta.Items.Add("Servicios al Credito")
                Me.PopupControlContainer1.ParentControl = Me.btOperacion
                Me.PopupControlContainer1.ShowPopup(Point.Empty)

            Case "Todas las Ventas"
                lstVenta.Items.Clear()
                lstVenta.Items.Add("Preventa")
                lstVenta.Items.Add("Ticket Directo")
                lstVenta.Items.Add("Venta normal directa")
                lstVenta.Items.Add("Servicios al Contado")
                lstVenta.Items.Add("Venta normal al Credito")
                lstVenta.Items.Add("Servicios al Credito")
                Me.PopupControlContainer1.ParentControl = Me.btOperacion
                Me.PopupControlContainer1.ShowPopup(Point.Empty)

            Case "Venta de Existencias, Servicios y Activo Inmv."
                Dim f As New frmVenta
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.Show()
            Case "Notas de Crédito"
                If Not IsNothing(GFichaUsuarios) Then
                    Dim f As New frmNotaVentaNew
                    f.ShowDialog()
                Else
                    lblEstado.Text = "Debe inciar una caja, para realizar està tarea!"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                End If
        End Select


    End Sub

    Private Sub PopupControlContainer1_BeforePopup(sender As Object, e As CancelEventArgs) Handles PopupControlContainer1.BeforePopup
        Me.PopupControlContainer1.BackColor = Color.White
    End Sub

    Private Sub PopupControlContainer1_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer1.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            Select Case lstVenta.Text
                Case "Preventa"
                    With frmVentaPV
                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        .txtFecha.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
                        .txtFecha.CustomFormat = "dd/MM/yyyy HH:mm tt"
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                    End With
                Case "Ticket Directo"
                    If IsNothing(GFichaUsuarios) Then
                        lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                    Else
                        With frmVentaTicketDirecta
                            .btGrabar.Enabled = True
                            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                            '   If .TieneCuentaFinanciera = True Then
                            .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
                            .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                            .lblPerido.Text = PeriodoGeneral
                            .StartPosition = FormStartPosition.CenterParent
                            .ShowDialog()
                            'Else
                            '    'lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
                            'End If
                        End With
                    End If



                Case "Venta normal al Credito"
                    With frmVentaNormal
                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
                        .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                    End With

                Case "Venta normal directa"

                    If IsNothing(GFichaUsuarios) Then
                        lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                    Else
                        With frmVentaNormalDirecta
                            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                            ' If .TieneCuentaFinanciera = True Then
                            .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
                            .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                            .lblPerido.Text = PeriodoGeneral
                            .StartPosition = FormStartPosition.CenterParent
                            .ShowDialog()
                            'Else
                            ''lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
                            'End If
                        End With
                    End If

                Case "Servicios al Credito"

                    With frmVentaNormalServicio
                        '.btGrabar.Enabled = True
                        .lblServicio.Text = "Credito"
                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        ' If .TieneCuentaFinanciera = True Then
                        .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
                        .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                        .lblPerido.Text = PeriodoGeneral
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                        'Else
                        ''lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
                        'End If
                    End With
                    'End If


                Case "Servicios al Contado"

                    If IsNothing(GFichaUsuarios) Then
                        lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                    Else
                        With frmVentaNormalServicio
                            '.btGrabar.Enabled = True
                            .lblServicio.Text = "Contado"
                            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                            ' If .TieneCuentaFinanciera = True Then
                            .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
                            .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                            .lblPerido.Text = PeriodoGeneral
                            .StartPosition = FormStartPosition.CenterParent
                            .ShowDialog()
                            'Else
                            ''lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
                            'End If
                        End With
                    End If

                Case "Nuevo cliente"
                    Dim f As New frmCrearENtidades
                    f.CaptionLabels(0).Text = "Nuevo cliente"
                    f.strTipo = TIPO_ENTIDAD.CLIENTE
                    f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()

                Case "Nuevo anticipo"
                    With frmModalAnticipo
                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        'If .TieneCuentaFinanciera = True Then
                        '    .txtFecha.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
                        '    .txtCuentaOrigen.Text = GFichaUsuarios.cuentaDestino
                        '    .txtCajaOrigen.Text = GFichaUsuarios.NomCajaDestinb
                        '    .txtCajaOrigen.ValueMember = GFichaUsuarios.IdCajaDestino
                        '    '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                        '    .StartPosition = FormStartPosition.CenterParent
                        '    .ShowDialog()
                        'Else
                        '    lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
                        '    PanelError.Visible = True
                        '    Timer1.Enabled = True
                        '    TiempoEjecutar(5)
                        'End If
                    End With
            End Select
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.btOperacion.Focus()
        End If
    End Sub

    Private Sub lstVenta_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstVenta.MouseDoubleClick
        Me.Cursor = Cursors.WaitCursor
        If lstVenta.SelectedItems.Count > 0 Then
            Me.PopupControlContainer1.HidePopup(PopupCloseType.Done)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lstVenta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstVenta.SelectedIndexChanged

    End Sub
    Dim hoveredIndex As Integer = 0

    Dim selectionColl As New Hashtable()
    Private Sub dgvVentasTicket_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvVentasTicket.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            Me.dgvVentasTicket.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub dgvVentasTicket_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvVentasTicket.TableControlCellClick

    End Sub
    Private Sub IsMouseHover(row As Integer, col As Integer, isHover As Boolean, GGC As GridGroupingControl)
        Dim color As New GridMetroColors()
        Dim id As GridTableCellStyleInfoIdentity = GGC.TableControl.GetTableViewStyleInfo(row, col).TableCellIdentity
        If id.DisplayElement.IsRecord() Then
            Dim key As Integer = id.DisplayElement.GetRecord().Id
            'if (selectionColl.Contains(key))
            '    selectionColl[key] = isHover;
            'else
            hoveredIndex = row
            selectionColl.Clear()
            'if (selectionColl.Count == 0)
            '    selectionColl.Add(key, isHover);
            GGC.TableControl.Refresh()
        End If

        GGC.TableControl.Selections.Clear()

    End Sub
    Private Sub dgvVentasTicket_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvVentasTicket.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvVentasTicket)
    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        Me.Cursor = Cursors.WaitCursor
        Dim ventaSA As New documentoVentaAbarrotesSA
        Dim venta As New documentoventaAbarrotes
        Dim usuarioSA As New cajaUsuarioSA
        Dim usuario As New cajaUsuario

        Select Case treeViewAdv2.SelectedNode.Text
            Case "Ventas del período"
                If Not IsNothing(Me.dgvVentasnormales.Table.CurrentRecord) Then
                    Select Case Me.dgvVentasnormales.Table.CurrentRecord.GetValue("tipoCompra")
                        Case TIPO_VENTA.VENTA_GENERAL
                            Dim f As New frmVenta(Me.dgvVentasnormales.Table.CurrentRecord.GetValue("idDocumento"))
                            f.WindowState = FormWindowState.Maximized
                            f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                            f.ShowDialog()
                    End Select
                End If
            Case "Ventas con ticket"
                If Not IsNothing(Me.dgvVentasTicket.Table.CurrentRecord) Then
                    Select Case Me.dgvVentasTicket.Table.CurrentRecord.GetValue("tipoVenta")

                        Case TIPO_VENTA.VENTA_AL_TICKET
                            With frmVentaPV

                                Select Case ventaSA.DocumentoCanceladoVenta(Me.dgvVentasTicket.Table.CurrentRecord.GetValue("idDocumento"))
                                    Case TIPO_VENTA.PAGO.PENDIENTE_PAGO
                                        .btGrabar.Visible = True

                                    Case TIPO_VENTA.PAGO.COBRADO
                                        .btGrabar.Visible = False

                                    Case TIPO_VENTA.VENTA_ANULADA, TIPO_VENTA.VENTA_NOTA_CREDITO
                                        .btGrabar.Visible = False
                                End Select

                                .txtFecha.ShowUpDown = True
                                .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                                .UbicarDocumento(CInt(Me.dgvVentasTicket.Table.CurrentRecord.GetValue("idDocumento")))
                                .StartPosition = FormStartPosition.CenterParent
                                .ShowDialog()
                            End With

                        Case TIPO_VENTA.VENTA_AL_TICKET_DIRECTA

                            With frmVentaTicketDirecta
                                .ManipulacionEstado = ENTITY_ACTIONS.UPDATE

                                Select Case ventaSA.DocumentoCanceladoVenta(Me.dgvVentasTicket.Table.CurrentRecord.GetValue("idDocumento"))
                                    Case TIPO_VENTA.VENTA_ANULADA, TIPO_VENTA.VENTA_NOTA_CREDITO

                                        .btGrabar.Enabled = False
                                        .lblEstado.Text = "VENTA ANULADA!"
                                        .txtFechaComprobante.ShowUpDown = True
                                        .UbicarDocumento(Me.dgvVentasTicket.Table.CurrentRecord.GetValue("idDocumento"))
                                        .StartPosition = FormStartPosition.CenterParent
                                        .ShowDialog()


                                    Case Else

                                        .btGrabar.Enabled = False
                                        .txtFechaComprobante.ShowUpDown = True
                                        .UbicarDocumento(Me.dgvVentasTicket.Table.CurrentRecord.GetValue("idDocumento"))
                                        .StartPosition = FormStartPosition.CenterParent
                                        .ShowDialog()


                                End Select

                                If Me.dgvVentasTicket.Table.CurrentRecord.GetValue("estadoCobro") = TIPO_VENTA.VENTA_ANULADA Then
                                    .btGrabar.Enabled = False
                                    lblEstado.Text = "El documento está anulado!!"
                                    PanelError.Visible = True
                                    Timer1.Enabled = True
                                    TiempoEjecutar(10)

                                Else

                                End If
                            End With



                    End Select


                End If

            Case "Ventas al Credito"

                If Not IsNothing(Me.dgvVentasnormales.Table.CurrentRecord) Then

                    Select Case Me.dgvVentasnormales.Table.CurrentRecord.GetValue("tipoCompra")

                        Case TIPO_VENTA.VENTA_NORMAL_CREDITO

                            With frmVentaNormal
                                .txtFechaComprobante.ShowUpDown = True
                                .btGrabar.Enabled = False
                                .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                                .UbicarDocumento(CInt(Me.dgvVentasnormales.Table.CurrentRecord.GetValue("idDocumento")))
                                .lblIdDocumento.Text = (CInt(Me.dgvVentasnormales.Table.CurrentRecord.GetValue("idDocumento")))
                                .lblPerido.Text = PeriodoGeneral
                                .StartPosition = FormStartPosition.CenterParent
                                .ShowDialog()
                            End With



                        Case TIPO_VENTA.VENTA_NORMAL_SERVICIO_CREDITO
                            With frmVentaNormalServicio
                                '      If .TieneCuentaFinanciera(CInt(Me.dgvVentasnormales.Table.CurrentRecord.GetValue("idDocumento"))) = True Then
                                .lblServicio.Text = "Credito"
                                .btGrabar.Enabled = False
                                .txtFechaComprobante.ShowUpDown = True
                                .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                                .UbicarDocumento(CInt(Me.dgvVentasnormales.Table.CurrentRecord.GetValue("idDocumento")))
                                .lblIdDocumento.Text = (CInt(Me.dgvVentasnormales.Table.CurrentRecord.GetValue("idDocumento")))
                                .lblPerido.Text = PeriodoGeneral
                                .StartPosition = FormStartPosition.CenterParent
                                .ShowDialog()

                            End With
                    End Select
                End If



            Case "Ventas al Contado"

                If Not IsNothing(Me.dgvVentasnormales.Table.CurrentRecord) Then


                    Select Case Me.dgvVentasnormales.Table.CurrentRecord.GetValue("tipoCompra")

                        Case TIPO_VENTA.VENTA_NORMAL_CONTADO


                            With frmVentaNormalDirecta
                                .btGrabar.Enabled = False
                                .txtFechaComprobante.ShowUpDown = True
                                .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                                .UbicarDocumento(CInt(Me.dgvVentasnormales.Table.CurrentRecord.GetValue("idDocumento")))
                                .lblIdDocumento.Text = (CInt(Me.dgvVentasnormales.Table.CurrentRecord.GetValue("idDocumento")))
                                .lblPerido.Text = PeriodoGeneral
                                .StartPosition = FormStartPosition.CenterParent
                                .ShowDialog()

                            End With





                        Case TIPO_VENTA.VENTA_NORMAL_SERVICIO
                            With frmVentaNormalServicio
                                .btGrabar.Enabled = False
                                'If .TieneCuentaFinanciera(CInt(Me.dgvVentasnormales.Table.CurrentRecord.GetValue("idDocumento"))) = True Then
                                .txtFechaComprobante.ShowUpDown = True
                                .lblServicio.Text = "Contado"
                                .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                                .UbicarDocumento(CInt(Me.dgvVentasnormales.Table.CurrentRecord.GetValue("idDocumento")))
                                .lblIdDocumento.Text = (CInt(Me.dgvVentasnormales.Table.CurrentRecord.GetValue("idDocumento")))
                                .lblPerido.Text = PeriodoGeneral
                                .StartPosition = FormStartPosition.CenterParent
                                .ShowDialog()

                            End With
                    End Select

                End If



            Case "Clientes"
                Dim f As New frmCrearENtidades
                f.CaptionLabels(0).Text = "Editar cliente"
                f.strTipo = TIPO_ENTIDAD.CLIENTE
                f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                f.intIdEntidad = Me.dgvClientes.Table.CurrentRecord.GetValue("idEntidad")
                f.UbicarEntidad(Me.dgvClientes.Table.CurrentRecord.GetValue("idEntidad"))
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            Case "Anticipos"
                'Dim ventaSA As New documentoVentaAbarrotesSA
                If Not IsNothing(Me.dgvVentasTicket.Table.CurrentRecord) Then

                ElseIf Not IsNothing(Me.dgvAnticipos.Table.CurrentRecord) Then
                    With frmModalAnticipo
                        .ManipulacionEstado = ENTITY_ACTIONS.UPDATE

                    End With
                End If

        End Select

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim ventaSA As New documentoVentaAbarrotesSA
        Try
            Select Case treeViewAdv2.SelectedNode.Text
                Case "Ventas con ticket"
                    If Not IsNothing(Me.dgvVentasTicket.Table.CurrentRecord) Then
                        Select Case Me.dgvVentasTicket.Table.CurrentRecord.GetValue("tipoVenta")

                            Case TIPO_COMPRA.NOTA_CREDITO

                            Case TIPO_VENTA.VENTA_AL_TICKET
                                Select Case ventaSA.DocumentoCanceladoVenta(Me.dgvVentasTicket.Table.CurrentRecord.GetValue("idDocumento"))
                                    Case Nothing

                                        lblEstado.Text = "La venta ya fue anulada!"
                                        PanelError.Visible = True
                                        Timer1.Enabled = True
                                        TiempoEjecutar(10)

                                    Case TIPO_VENTA.PAGO.COBRADO

                                        Dim form As New frmANulaOpcioN
                                        form.StartPosition = FormStartPosition.CenterParent
                                        If form.ShowDialog() = DialogResult.OK Then
                                            'MessageBox.Show(form.ValorRetorno)
                                            Select Case form.ValorRetorno
                                                Case "CON"
                                                    With frmCreditoVenta  ' frmNotaCredito
                                                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                                                        .StartPosition = FormStartPosition.CenterParent
                                                        .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
                                                        .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                                                        .WindowState = FormWindowState.Maximized
                                                        .ShowDialog()
                                                    End With
                                                Case "SIN"
                                                    EliminarVentaCobrada(CInt(Me.dgvVentasTicket.Table.CurrentRecord.GetValue("idDocumento")), Me.dgvVentasTicket.Table.CurrentRecord.GetValue("usuarioCaja"), TIPO_VENTA.VENTA_AL_TICKET)
                                                    '  End If
                                                    '      lsvListaPedidos.SelectedItems(0).SubItems(15).Text = TIPO_VENTA.VENTA_ANULADA
                                                    lblEstado.Text = "Venta anulada!"
                                                    PanelError.Visible = True
                                                    Timer1.Enabled = True
                                                    TiempoEjecutar(10)
                                            End Select
                                        End If

                                    Case TIPO_VENTA.PAGO.PENDIENTE_PAGO
                                        If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                            '   If Me.dgvVenta.Table.CurrentRecord.GetValue("estadoCobro") = "PN" Then
                                            EliminarVenta(CInt(Me.dgvVentasTicket.Table.CurrentRecord.GetValue("idDocumento")))

                                            lblEstado.Text = "Pedido eliminado!"
                                            PanelError.Visible = True
                                            Timer1.Enabled = True
                                            TiempoEjecutar(10)
                                        End If
                                    Case TIPO_VENTA.VENTA_ANULADA, TIPO_VENTA.VENTA_NOTA_CREDITO
                                        lblEstado.Text = "El documento ya está anulado.!"
                                        PanelError.Visible = True
                                        Timer1.Enabled = True
                                        TiempoEjecutar(10)
                                End Select

                            Case TIPO_VENTA.VENTA_AL_TICKET_DIRECTA

                                If IsNothing(GFichaUsuarios) Then
                                    lblEstado.Text = "Debe configurar una caja válida.!"
                                    PanelError.Visible = True
                                    Timer1.Enabled = True
                                    TiempoEjecutar(10)
                                Else

                                    Dim form As New frmANulaOpcioN
                                    form.StartPosition = FormStartPosition.CenterParent
                                    If form.ShowDialog() = DialogResult.OK Then
                                        'MessageBox.Show(form.ValorRetorno)
                                        Select Case form.ValorRetorno
                                            Case "CON"

                                            Case "SIN"
                                                Select Case ventaSA.DocumentoCanceladoVenta(Me.dgvVentasTicket.Table.CurrentRecord.GetValue("idDocumento"))
                                                    Case TIPO_VENTA.PAGO.COBRADO
                                                        ' If TieneCuentaFinanciera(CInt(Me.dgvVentasTicket.Table.CurrentRecord.GetValue("idDocumento"))) = True Then
                                                        EliminarVentaCobrada(CInt(Me.dgvVentasTicket.Table.CurrentRecord.GetValue("idDocumento")), GFichaUsuarios.IdCajaUsuario, TIPO_VENTA.VENTA_AL_TICKET_DIRECTA)
                                                        '  End If
                                                        lblEstado.Text = "Venta anulada!"
                                                        PanelError.Visible = True
                                                        Timer1.Enabled = True
                                                        TiempoEjecutar(10)
                                                    Case TIPO_VENTA.PAGO.PENDIENTE_PAGO

                                                    Case TIPO_VENTA.VENTA_ANULADA, TIPO_VENTA.VENTA_NOTA_CREDITO
                                                        lblEstado.Text = "El documento ya está anulado.!"
                                                        PanelError.Visible = True
                                                        Timer1.Enabled = True
                                                        TiempoEjecutar(10)
                                                End Select
                                        End Select
                                    End If
                                End If
                        End Select
                    End If



                Case "Ventas al Credito"
                    'If Not IsNothing(Me.dgvVentasTicket.Table.CurrentRecord) Then
                    If Not IsNothing(Me.dgvVentasnormales.Table.CurrentRecord) Then


                        Select Case Me.dgvVentasnormales.Table.CurrentRecord.GetValue("tipoCompra")

                            Case TIPO_VENTA.VENTA_NORMAL_CREDITO
                                If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                    '   If Me.dgvVenta.Table.CurrentRecord.GetValue("estadoCobro") = "PN" Then
                                    EliminarVentaAlCredito(CInt(Me.dgvVentasnormales.Table.CurrentRecord.GetValue("idDocumento")), TIPO_VENTA.VENTA_NORMAL_CREDITO)

                                    lblEstado.Text = "Pedido eliminado!"
                                    PanelError.Visible = True
                                    Timer1.Enabled = True
                                    TiempoEjecutar(10)
                                End If



                            Case TIPO_VENTA.VENTA_NORMAL_SERVICIO_CREDITO

                                If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                                    EliminarVentaServicio(CInt(Me.dgvVentasnormales.Table.CurrentRecord.GetValue("idDocumento")), TIPO_VENTA.VENTA_NORMAL_SERVICIO)
                                    '     Me.dgvVentasnormales.Table.CurrentRecord.Delete()
                                    lblEstado.Text = "La venta ya fue anulada!"
                                    PanelError.Visible = True
                                    Timer1.Enabled = True
                                    TiempoEjecutar(10)

                                End If
                        End Select

                    End If




                Case "Ventas al Contado"
                    ' If Not IsNothing(Me.dgvVentasTicket.Table.CurrentRecord) Then
                    If Not IsNothing(Me.dgvVentasnormales.Table.CurrentRecord) Then


                        Select Case Me.dgvVentasnormales.Table.CurrentRecord.GetValue("tipoCompra")


                            Case TIPO_VENTA.VENTA_NORMAL_CONTADO
                                If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                                    'EliminarVentaServicio(CInt(Me.dgvVentasnormales.Table.CurrentRecord.GetValue("idDocumento")), TIPO_VENTA.VENTA_NORMAL_SERVICIO)

                                    EliminarVentaAlCredito(CInt(Me.dgvVentasnormales.Table.CurrentRecord.GetValue("idDocumento")), TIPO_VENTA.VENTA_NORMAL_CREDITO)

                                    lblEstado.Text = "La venta ya fue anulada!"
                                    PanelError.Visible = True
                                    Timer1.Enabled = True
                                    TiempoEjecutar(10)

                                End If


                            Case TIPO_VENTA.VENTA_NORMAL_SERVICIO

                                If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                                    EliminarVentaServicio(CInt(Me.dgvVentasnormales.Table.CurrentRecord.GetValue("idDocumento")), TIPO_VENTA.VENTA_NORMAL_SERVICIO)
                                    '   Me.dgvVentasnormales.Table.CurrentRecord.Delete()
                                    lblEstado.Text = "La venta ya fue anulada!"
                                    PanelError.Visible = True
                                    Timer1.Enabled = True
                                    TiempoEjecutar(10)

                                End If
                        End Select

                        'End If
                    End If


                Case "Clientes"

                Case "Anticipos"
                    If Not IsNothing(Me.dgvVentasTicket.Table.CurrentRecord) Then

                    ElseIf Not IsNothing(Me.dgvAnticipos.Table.CurrentRecord) Then
                        With frmModalAnticipo
                            .ManipulacionEstado = ENTITY_ACTIONS.UPDATE

                        End With

                    End If
            End Select


        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub
    'Dim filter As GridDynamicFilter = New GridDynamicFilter()

    Dim filter As New GridExcelFilter()
    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Select Case treeViewAdv2.SelectedNode.Text
            Case "Ventas ticket"
                Me.dgvVentasTicket.TopLevelGroupOptions.ShowFilterBar = True
                Me.dgvVentasTicket.NestedTableGroupOptions.ShowFilterBar = True
                Me.dgvVentasTicket.ChildGroupOptions.ShowFilterBar = True
                For Each col As GridColumnDescriptor In Me.dgvVentasTicket.TableDescriptor.Columns
                    col.AllowFilter = True
                Next
                filter.AllowResize = True
                filter.AllowFilterByColor = True
                filter.EnableDateFilter = True
                filter.EnableNumberFilter = True

                Me.dgvVentasTicket.OptimizeFilterPerformance = True
                Me.dgvVentasTicket.ShowNavigationBar = True
                filter.WireGrid(dgvVentasTicket)

            Case "Ventas normales"

                Me.dgvVentasnormales.TopLevelGroupOptions.ShowFilterBar = True
                Me.dgvVentasnormales.NestedTableGroupOptions.ShowFilterBar = True
                Me.dgvVentasnormales.ChildGroupOptions.ShowFilterBar = True

                For Each col As GridColumnDescriptor In Me.dgvVentasnormales.TableDescriptor.Columns
                    col.AllowFilter = True
                Next
                filter.AllowResize = True
                filter.AllowFilterByColor = True
                filter.EnableDateFilter = True
                filter.EnableNumberFilter = True
                Me.dgvVentasnormales.OptimizeFilterPerformance = True
                Me.dgvVentasnormales.ShowNavigationBar = True

                filter.WireGrid(dgvVentasnormales)

            Case "Clientes"
                Me.dgvClientes.TopLevelGroupOptions.ShowFilterBar = True
                Me.dgvClientes.NestedTableGroupOptions.ShowFilterBar = True
                Me.dgvClientes.ChildGroupOptions.ShowFilterBar = True

                For Each col As GridColumnDescriptor In Me.dgvClientes.TableDescriptor.Columns
                    col.AllowFilter = True
                Next
                filter.AllowResize = True
                filter.AllowFilterByColor = True
                filter.EnableDateFilter = True
                filter.EnableNumberFilter = True
                Me.dgvClientes.OptimizeFilterPerformance = True
                Me.dgvClientes.ShowNavigationBar = True

                filter.WireGrid(dgvClientes)

            Case "Anticipos"

                Me.dgvAnticipos.TopLevelGroupOptions.ShowFilterBar = True
                Me.dgvAnticipos.NestedTableGroupOptions.ShowFilterBar = True
                Me.dgvAnticipos.ChildGroupOptions.ShowFilterBar = True

                For Each col As GridColumnDescriptor In Me.dgvAnticipos.TableDescriptor.Columns
                    col.AllowFilter = True
                Next
                filter.AllowResize = True
                filter.AllowFilterByColor = True
                filter.EnableDateFilter = True
                filter.EnableNumberFilter = True

                Me.dgvAnticipos.OptimizeFilterPerformance = True
                Me.dgvAnticipos.ShowNavigationBar = True

                filter.WireGrid(dgvAnticipos)
        End Select

    End Sub

    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs) Handles ToolStripButton10.Click
        Select Case treeViewAdv2.SelectedNode.Text
            Case "Ventas ticket"

                filter.ClearFilters(Me.dgvVentasTicket)
                Me.dgvVentasTicket.TopLevelGroupOptions.ShowFilterBar = False
            Case "Ventas normales"

                filter.ClearFilters(Me.dgvVentasnormales)
                Me.dgvVentasnormales.TopLevelGroupOptions.ShowFilterBar = False

            Case "Clientes"
                filter.ClearFilters(Me.dgvClientes)
                Me.dgvClientes.TopLevelGroupOptions.ShowFilterBar = False

            Case "Anticipos"
                filter.ClearFilters(Me.dgvAnticipos)
                Me.dgvAnticipos.TopLevelGroupOptions.ShowFilterBar = False
        End Select


    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        Select Case treeViewAdv2.SelectedNode.Text
            Case "Ventas ticket"

                dgvVentasTicket.TableDescriptor.GroupedColumns.Clear()
                If dgvVentasTicket.ShowGroupDropArea = True Then
                    dgvVentasTicket.ShowGroupDropArea = False
                Else
                    dgvVentasTicket.ShowGroupDropArea = True
                End If
            Case "Ventas normales"

                dgvVentasnormales.TableDescriptor.GroupedColumns.Clear()
                If dgvVentasnormales.ShowGroupDropArea = True Then
                    dgvVentasnormales.ShowGroupDropArea = False
                Else
                    dgvVentasnormales.ShowGroupDropArea = True
                End If
            Case "Clientes"
                dgvClientes.TableDescriptor.GroupedColumns.Clear()
                If dgvClientes.ShowGroupDropArea = True Then
                    dgvClientes.ShowGroupDropArea = False
                Else
                    dgvClientes.ShowGroupDropArea = True
                End If

            Case "Anticipos"
                dgvAnticipos.TableDescriptor.GroupedColumns.Clear()
                If dgvAnticipos.ShowGroupDropArea = True Then
                    dgvAnticipos.ShowGroupDropArea = False
                Else
                    dgvAnticipos.ShowGroupDropArea = True
                End If
        End Select


    End Sub

    Private Sub ToolStripButton10_DisplayStyleChanged(sender As Object, e As EventArgs) Handles ToolStripButton10.DisplayStyleChanged

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        PanelError.Visible = False
        Timer1.Enabled = False
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.Cursor = Cursors.WaitCursor
        Select Case treeViewAdv2.SelectedNode.Text
            Case "Ventas con ticket"

                TabPageAdv1.Parent = TabControlAdv1
                TabPageAdv2.Parent = Nothing
                TabPageAdv3.Parent = Nothing
                TabPageAdv4.Parent = Nothing
                If rbPeriodo.Checked = True Then
                    getTableVentasPorPeriodo()
                    lstVenta.Items.Clear()
                    lstVenta.Items.Add("Preventa")
                    lstVenta.Items.Add("Ticket Directo")
                End If
                If rbDia.Checked = True Then
                    getTableVentasPorDia()
                    lstVenta.Items.Clear()
                    lstVenta.Items.Add("Preventa")
                    lstVenta.Items.Add("Ticket Directo")
                End If
                TabPageAdv1.Text = treeViewAdv2.SelectedNode.Text

                'If rbPeriodo.Checked = True Then
                '    getTableVentasPorPeriodo()
                'End If
                'If rbDia.Checked = True Then
                '    getTableVentasPorDia()
                'End If
                'TabPageAdv1.Text = treeViewAdv2.SelectedNode.Text

            Case "Ventas al Credito"

                TabPageAdv1.Parent = Nothing
                TabPageAdv2.Parent = TabControlAdv1
                TabPageAdv3.Parent = Nothing
                TabPageAdv4.Parent = Nothing
                TabPageAdv2.Text = treeViewAdv2.SelectedNode.Text
                If rbPeriodo.Checked = True Then
                    getTableVentasNormalPorPeriodoCredito()
                    lstVenta.Items.Clear()
                    lstVenta.Items.Add("Venta normal al Credito")
                    lstVenta.Items.Add("Servicios al Credito")
                End If
                If rbDia.Checked = True Then
                    getTableVentasNormalPorDiaCredito()
                    lstVenta.Items.Clear()
                    lstVenta.Items.Add("Venta normal al Credito")
                    lstVenta.Items.Add("Servicios al Credito")
                End If
                'If rbPeriodo.Checked = True Then
                '    getTableVentasNormalPorPeriodoCredito()
                'End If
            Case "Ventas al Contado"

                TabPageAdv1.Parent = Nothing
                TabPageAdv2.Parent = TabControlAdv1
                TabPageAdv3.Parent = Nothing
                TabPageAdv4.Parent = Nothing
                TabPageAdv2.Text = treeViewAdv2.SelectedNode.Text

                If rbPeriodo.Checked = True Then
                    getTableVentasNormalPorPeriodo()
                    lstVenta.Items.Clear()
                    lstVenta.Items.Add("Venta normal directa")
                    lstVenta.Items.Add("Servicios al Contado")
                End If
                If rbDia.Checked = True Then
                    getTableVentasNormalPorDia()
                    lstVenta.Items.Clear()
                    lstVenta.Items.Add("Venta normal directa")
                    lstVenta.Items.Add("Servicios al Contado")
                End If

                'If rbPeriodo.Checked = True Then
                '    getTableVentasNormalPorPeriodo()
                'End If

            Case "Clientes"
                TabPageAdv1.Parent = Nothing
                TabPageAdv2.Parent = Nothing
                TabPageAdv3.Parent = TabControlAdv1
                TabPageAdv4.Parent = Nothing
                ListaClientes()
                lstVenta.Items.Clear()
                'ListaClientes()

            Case "Todas las Ventas"
                TabPageAdv1.Parent = Nothing
                TabPageAdv2.Parent = TabControlAdv1
                TabPageAdv3.Parent = Nothing
                TabPageAdv4.Parent = Nothing
                TabPageAdv2.Text = treeViewAdv2.SelectedNode.Text
                If rbPeriodo.Checked = True Then
                    getTableVentasAllNormalPorPeriodo()
                    lstVenta.Items.Clear()
                    lstVenta.Items.Add("Preventa")
                    lstVenta.Items.Add("Ticket Directo")
                    lstVenta.Items.Add("Venta normal directa")
                    lstVenta.Items.Add("Servicios al Contado")
                    lstVenta.Items.Add("Venta normal al Credito")
                    lstVenta.Items.Add("Servicios al Credito")
                End If
                If rbDia.Checked = True Then
                    getTableVentasAllNormalPorDia()
                    lstVenta.Items.Clear()
                    lstVenta.Items.Add("Preventa")
                    lstVenta.Items.Add("Ticket Directo")
                    lstVenta.Items.Add("Venta normal directa")
                    lstVenta.Items.Add("Servicios al Contado")
                    lstVenta.Items.Add("Venta normal al Credito")
                    lstVenta.Items.Add("Servicios al Credito")
                End If


            Case "Anticipos"
                getTableAnticiposPorPeriodo()
        End Select
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PanelError_Paint(sender As Object, e As PaintEventArgs) Handles PanelError.Paint

    End Sub

    Private Sub dgvVentasnormales_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvVentasnormales.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            Me.dgvVentasnormales.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub dgvVentasnormales_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvVentasnormales.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvVentasnormales)
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click

    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Me.Cursor = Cursors.WaitCursor
        With frmCreditoVenta  ' frmNotaCredito
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
            .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            .WindowState = FormWindowState.Maximized
            .ShowDialog()
            Me.Cursor = Cursors.Arrow
        End With
    End Sub

    Private Sub dgvClientes_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvClientes.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            Me.dgvClientes.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub dgvClientes_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvClientes.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvClientes)
    End Sub

    Private Sub dgvAnticipos_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvAnticipos.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            Me.dgvAnticipos.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub dgvAnticipos_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvAnticipos.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvAnticipos)
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class