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
Public Class frmPos_0_Venta
    Inherits frmMaster
    Dim colorx As New GridMetroColors()
    Dim lblPedidosCount As New Label
    Dim lblAnulado As New Label

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Meses()
        lblPedidosCount = New Label
        GridCFG(dgvVentas)
        GridCFG(dgvCoti)
        GridCFG(dgvCliente)
        Me.WindowState = FormWindowState.Normal
        ToolStripLabel2.Text = PeriodoGeneral
        GetCountPedidos()
        GetCountVentasAnuladas()
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

#Region "Métodos"
    Private Sub Meses()
        Dim listaMeses As New List(Of MesesAnio)
        Dim obj As New MesesAnio

        For x = 1 To 12
            obj = New MesesAnio
            obj.Codigo = String.Format("{0:00}", CInt(x))
            obj.Mes = New DateTime(AnioGeneral, x, 1).ToString("MMMM")
            listaMeses.Add(obj)
        Next x

        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.DataSource = listaMeses
        cboMesCompra.SelectedValue = MesGeneral
    End Sub

    Public Sub GetCountVentasAnuladas()

        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA
        Dim cant As New List(Of documentoventaAbarrotes)

        cant = DocumentoVentaSA.GetListarAllVentasPeriodoAnulado(GEstableciento.IdEstablecimiento, PeriodoGeneral)
        '   lblCenter = New Label
        lblAnulado.Text = cant.Count
        lblAnulado.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        lblAnulado.AutoSize = False
        lblAnulado.BackColor = Color.Transparent
        lblAnulado.Dock = DockStyle.Fill
        lblAnulado.ForeColor = Color.DarkRed
        lblAnulado.TextAlign = ContentAlignment.MiddleLeft

    End Sub

    Public Sub GetCountPedidos()
        Dim ventaSA As New documentoVentaAbarrotesSA

        Dim venta = ventaSA.GetConteoPedidos(GEstableciento.IdEstablecimiento, PeriodoGeneral)
        '   lblCenter = New Label
        lblPedidosCount.Text = venta
        lblPedidosCount.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        lblPedidosCount.AutoSize = False
        lblPedidosCount.BackColor = Color.Transparent
        lblPedidosCount.Dock = DockStyle.Fill
        lblPedidosCount.ForeColor = Color.DarkRed
        lblPedidosCount.TextAlign = ContentAlignment.MiddleLeft

    End Sub

    Sub ElimnarCliente()
        Dim UsuarioEstadoCaja As New UsuarioEstadoCaja
        Dim entidad As New entidadSA
        Dim objEntidad As New entidad
        If Not IsNothing(Me.dgvCliente.Table.CurrentRecord) Then

            With objEntidad
                .idEntidad = Me.dgvCliente.Table.CurrentRecord.GetValue("idEntidad")
            End With

            entidad.DeleteEntidad(objEntidad)
            Me.dgvCliente.Table.CurrentRecord.Delete()
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
            lblEstado.Text = "Proveedor eliminada!"

        End If
    End Sub

    Public Sub UbicarEntidadPorRuc(strNro As String)
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.CLIENTE, strNro)
        If Not IsNothing(entidad) Then
            With entidad
                txtCliente.Text = .nombreCompleto
                txtCliente.Tag = .idEntidad
                '   txtCuenta.Text = .cuentaAsiento
                txtRuc.Text = .nrodoc
            End With
        Else
            txtCliente.Clear()
            '  txtCuenta.Clear()
            txtRuc.Clear()
            If MessageBoxAdv.Show("Desea crear un nuevo cliente?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                Dim f As New frmCrearENtidades
                f.CaptionLabels(0).Text = "Nuevo proveedor"
                f.strTipo = TIPO_ENTIDAD.CLIENTE
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            End If
        End If
    End Sub

#Region "CLIENTES"

    Private Sub GetListaNotasPedido()
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Pedidos - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("pedido", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))

        'lower case p
        dt.Columns.Add(New DataColumn("estado", GetType(String)))

        Dim str As String

        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarAllNotasPedido(GEstableciento.IdEstablecimiento, PeriodoGeneral)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoVenta
            dr(2) = str

            dr(4) = i.tipoDocumento
            dr(5) = i.serie
            Select Case i.tipoVenta
                Case TIPO_VENTA.VENTA_AL_TICKET, TIPO_VENTA.VENTA_NOTA_PEDIDO
                    dr(3) = i.nombrePedido
                    dr(6) = i.numeroDoc
                Case TIPO_VENTA.VENTA_GENERAL
                    dr(3) = "-"
                    dr(6) = i.numeroDocNormal
            End Select

            dr(7) = i.NroDocEntidad
            dr(8) = i.NombreEntidad
            dr(9) = i.ImporteNacional
            dr(10) = i.tipoCambio
            dr(11) = i.ImporteExtranjero
            dr(12) = i.moneda
            dr(13) = i.usuarioActualizacion
            dr(14) = i.estadoCobro

            dt.Rows.Add(dr)
        Next
        dgvVentas.DataSource = dt

    End Sub

    Private Sub GetListaVentasPorPeriodoAnulado()
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Ventas - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("pedido", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))

        'lower case p
        dt.Columns.Add(New DataColumn("estado", GetType(String)))

        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarAllVentasPeriodoAnulado(GEstableciento.IdEstablecimiento, PeriodoGeneral)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoVenta
            dr(2) = str

            dr(4) = i.tipoDocumento
            dr(5) = i.serie
            Select Case i.tipoVenta
                Case TIPO_VENTA.VENTA_AL_TICKET, TIPO_VENTA.VENTA_POS_DIRECTA
                    'If i.tipoVenta = TIPO_VENTA.VENTA_AL_TICKET Then
                    '    dr(1) = "Venta Ticket"
                    'ElseIf i.tipoVenta = TIPO_VENTA.VENTA_POS_DIRECTA Then
                    '    dr(1) = "Venta Ticket directa"
                    'End If
                    dr(3) = i.nombrePedido
                    dr(6) = i.numeroDoc

                Case TIPO_VENTA.COTIZACION
                    '    dr(1) = "Cotización"
                    dr(3) = i.nombrePedido
                    dr(6) = i.numeroDoc

                Case TIPO_VENTA.VENTA_GENERAL

                    '    dr(1) = "Venta General"
                    dr(3) = "-"
                    dr(6) = i.numeroDocNormal

                Case "NTC"
                    '   dr(1) = "Nota de crédito"
                    dr(3) = "-"
                    dr(6) = i.numeroDocNormal
            End Select

            dr(7) = i.NroDocEntidad
            dr(8) = i.NombreEntidad
            dr(9) = FormatNumber(i.ImporteNacional, 2)
            dr(10) = i.tipoCambio
            dr(11) = FormatNumber(i.ImporteExtranjero, 2)
            dr(12) = i.moneda
            dr(13) = i.usuarioActualizacion

            Select Case i.tipoVenta
                Case "NTC"
                    dr(14) = "-"
                Case Else
                    Select Case i.estadoCobro
                        Case "DC"
                            dr(14) = "Cobrado"
                        Case "ANU"
                            dr(14) = "Anulado"
                        Case TIPO_VENTA.AnuladaPorNotaCredito
                            dr(14) = "Anulado x NC."
                        Case Else
                            dr(14) = "Pendiente"
                    End Select
            End Select


            dt.Rows.Add(dr)
        Next
        GridGroupingControl1.DataSource = dt

    End Sub

    Private Sub GetListaVentasPorPeriodo()
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Ventas - período " & cboMesCompra.SelectedValue & "/" & AnioGeneral)
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("pedido", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))

        'lower case p
        dt.Columns.Add(New DataColumn("estado", GetType(String)))

        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarAllVentasPeriodo(GEstableciento.IdEstablecimiento, cboMesCompra.SelectedValue & "/" & AnioGeneral)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoVenta
            dr(2) = str

            dr(4) = i.tipoDocumento
            dr(5) = i.serie
            Select Case i.tipoVenta
                Case TIPO_VENTA.VENTA_AL_TICKET, TIPO_VENTA.VENTA_POS_DIRECTA
                    'If i.tipoVenta = TIPO_VENTA.VENTA_AL_TICKET Then
                    '    dr(1) = "Venta Ticket"
                    'ElseIf i.tipoVenta = TIPO_VENTA.VENTA_POS_DIRECTA Then
                    '    dr(1) = "Venta Ticket directa"
                    'End If
                    dr(3) = i.nombrePedido
                    dr(6) = i.numeroDoc

                Case TIPO_VENTA.COTIZACION
                    '    dr(1) = "Cotización"
                    dr(3) = i.nombrePedido
                    dr(6) = i.numeroDoc

                Case TIPO_VENTA.VENTA_GENERAL

                    '    dr(1) = "Venta General"
                    dr(3) = "-"
                    dr(6) = i.numeroDocNormal

                Case "NTC"
                    '   dr(1) = "Nota de crédito"
                    dr(3) = "-"
                    dr(6) = i.numeroDocNormal
            End Select

            dr(7) = i.NroDocEntidad
            dr(8) = i.NombreEntidad
            dr(9) = FormatNumber(i.ImporteNacional, 2)
            dr(10) = i.tipoCambio
            dr(11) = FormatNumber(i.ImporteExtranjero, 2)
            dr(12) = i.moneda
            dr(13) = i.usuarioActualizacion

            Select Case i.tipoVenta
                Case "NTC"
                    dr(14) = "-"
                Case Else
                    Select Case i.estadoCobro
                        Case "DC"
                            dr(14) = "Cobrado"
                        Case "ANU"
                            dr(14) = "Anulado"
                        Case TIPO_VENTA.AnuladaPorNotaCredito
                            dr(14) = "Anulado x NC."
                        Case Else
                            dr(14) = "Pendiente"
                    End Select
            End Select


            dt.Rows.Add(dr)
        Next
        dgvVentas.DataSource = dt

    End Sub

    Private Sub GetVentasPeriodoByCliente()
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Ventas - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("pedido", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("importeTotal"))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS"))
        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))

        'lower case p
        dt.Columns.Add(New DataColumn("estado", GetType(String)))

        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetVentasPeriodoByCliente(New documentoventaAbarrotes With {.idEstablecimiento = GEstableciento.IdEstablecimiento, .fechaPeriodo = PeriodoGeneral,
                                                                                                                              .idCliente = txtCliente.Tag})
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoVenta
            dr(2) = str

            dr(4) = i.tipoDocumento
            dr(5) = i.serie
            dr(6) = String.Format("{0:00000000}", CInt(i.numeroDoc))

            dr(7) = i.NroDocEntidad
            dr(8) = i.NombreEntidad
            dr(9) = CDec(i.ImporteNacional).ToString("N2")
            dr(10) = i.tipoCambio
            dr(11) = CDec(i.ImporteExtranjero).ToString("N2")
            dr(12) = i.moneda
            dr(13) = i.usuarioActualizacion
            dr(14) = If(i.estadoCobro = "PN", "Pendiente", "Venta")

            dt.Rows.Add(dr)
        Next
        dgvCoti.DataSource = dt

    End Sub

    Public Sub EliminarAnticipo(IntIdDocumento As Integer)
        Dim documentoSA As New DocumentoSA
        Dim objDocumento As New documento

        With objDocumento
            .idDocumento = IntIdDocumento
        End With
        documentoSA.DeleteAnticipoSL(objDocumento)
    End Sub


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
        dgvCliente.DataSource = dt
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
            Me.dgvVentas.Table.CurrentRecord.Delete()
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

    Public Sub EliminarPVDirecta(intIdDocumento As Integer)
        Dim documentoSA As New DocumentoSA
        Dim objDocumento As New documento
        Try
            With objDocumento
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                .idDocumento = intIdDocumento
            End With

            documentoSA.EliminarVentaTicketDirecta(objDocumento)
            'Me.dgvVentas.Table.CurrentRecord.Delete()
            lblEstado.Text = "Pedido eliminado!"
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

    Public Sub EliminarVentaGeneral(intIdDocumento As Integer)
        Dim documentoSA As New DocumentoSA
        Dim objDocumento As New documento
        Try
            With objDocumento
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                .idDocumento = intIdDocumento
            End With

            documentoSA.EliminarVentaGeneralPV(objDocumento)
            'Me.dgvVentas.Table.CurrentRecord.Delete()
            lblEstado.Text = "Venta Anulada!"
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

    Public Sub EliminarPV(intIdDocumento As Integer)
        Dim documentoSA As New DocumentoSA
        Dim objDocumento As New documento
        Try
            With objDocumento
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                .idDocumento = intIdDocumento
            End With

            documentoSA.EliminarVentaGeneralPV(objDocumento)
            Me.dgvVentas.Table.CurrentRecord.Delete()
            lblEstado.Text = "Pedido eliminado!"
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

    Public Sub EliminarNotaDebito(intIdDocumentoNota As Integer)
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
                .ImporteMN = dgvVentas.Table.CurrentRecord.GetValue("importeTotal")
                .ImporteME = dgvVentas.Table.CurrentRecord.GetValue("importeUS")
            End With
            compraSA.EliminarNotaDebitoVenta(objDocumento)
            Me.dgvVentas.Table.CurrentRecord.Delete()
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
#End Region

    Private Sub frmPos_0_Venta_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmPos_0_Venta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtAnioCompra.Text = AnioGeneral
        treeViewAdv2.BackColor = Color.WhiteSmoke ' Color.FromArgb(240, 158, 80)
        TabPageAdv1.Parent = TabControlAdv1
        TabCotizacion.Parent = Nothing
        TabPageAdv2.Parent = Nothing
        TabPageAdv3.Parent = Nothing

        Me.treeViewAdv2.Nodes(0).CustomControl = lblPedidosCount
        treeViewAdv2.Nodes.RemoveAt(3)
        Me.treeViewAdv2.Nodes(3).CustomControl = lblAnulado
    End Sub


    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        Me.Cursor = Cursors.WaitCursor
        Select Case treeViewAdv2.SelectedNode.Text
            Case "Venta de Existencias, Servicios y Activo Inmv."
                Dim f As New frmVenta
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.ShowDialog()
                Dim SaldoCaja As New UsuarioEstadoCaja
                SaldoCaja.GetSaldoActual(GFichaUsuarios)
                Me.CaptionLabels(0).Text = GFichaUsuarios.SaldoMN.ToString("N2")
            Case "POS - Venta de existencias."
                Dim f As New frmVentaPV
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                'f.txtFecha.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
                'f.txtFecha.CustomFormat = "dd/MM/yyyy HH:mm tt"
                f.StartPosition = FormStartPosition.CenterScreen
                f.Show()
            Case "Administración de Clientes"
                Dim f As New frmCrearENtidades
                f.CaptionLabels(0).Text = "Nuevo cliente"
                f.strTipo = TIPO_ENTIDAD.CLIENTE
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            Case "Notas de Crédito"
                If Not IsNothing(GFichaUsuarios) Then
                    Dim f As New frmNotaVentaNew
                    f.ShowDialog()
                    Dim SaldoCaja As New UsuarioEstadoCaja
                    SaldoCaja.GetSaldoActual(GFichaUsuarios)
                    Me.CaptionLabels(0).Text = GFichaUsuarios.SaldoMN.ToString("N2")
                Else
                    lblEstado.Text = "Debe iniciar una caja, para realizar està tarea!"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                End If
            Case "Notas de Débito"
                If Not IsNothing(GFichaUsuarios) Then
                    Dim f As New frmNotaDebitoVenta
                    f.ShowDialog()
                    Dim SaldoCaja As New UsuarioEstadoCaja
                    SaldoCaja.GetSaldoActual(GFichaUsuarios)
                    Me.CaptionLabels(0).Text = GFichaUsuarios.SaldoMN.ToString("N2")
                Else
                    lblEstado.Text = "Debe iniciar una caja, para realizar està tarea!"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                End If
        End Select
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub treeViewAdv2_AfterSelect(sender As Object, e As EventArgs) Handles treeViewAdv2.AfterSelect
        Me.Cursor = Cursors.WaitCursor
        Select Case treeViewAdv2.SelectedNode.Text
            Case "Administración de Clientes"
                GridCFG(dgvCliente)

                TabPageAdv1.Parent = Nothing
                TabPageAdv2.Parent = TabControlAdv1
                TabCotizacion.Parent = Nothing
                TabPageAdv3.Parent = Nothing
                ' ListaClientes()
            Case "Ventas del período"
                Label2.Text = "REGISTRO DE VENTAS / Listado"
                GradientPanel17.Visible = True
                dgvVentas.Table.Records.DeleteAll()
                GridCFG(dgvVentas)
                TabPageAdv1.Parent = TabControlAdv1
                TabPageAdv2.Parent = Nothing
                TabCotizacion.Parent = Nothing
                '      GetListaVentasPorPeriodo()
                TabPageAdv3.Parent = Nothing
            Case "Notas Pedido"
                Label2.Text = "REGISTRO DE PEDIDOS / Listado"
                TabPageAdv1.Parent = TabControlAdv1
                TabPageAdv2.Parent = Nothing
                TabCotizacion.Parent = Nothing
                TabPageAdv3.Parent = Nothing

                GradientPanel17.Visible = False

                GetListaNotasPedido()

            Case "Cotizaciones"
                GridCFG(dgvCoti)
                TabPageAdv1.Parent = Nothing
                TabPageAdv2.Parent = Nothing
                TabPageAdv3.Parent = Nothing
                TabCotizacion.Parent = TabControlAdv1
            Case "Ventas Anuladas"
                GridCFG(GridGroupingControl1)
                TabPageAdv1.Parent = Nothing
                TabPageAdv2.Parent = Nothing
                TabCotizacion.Parent = Nothing
                TabPageAdv3.Parent = TabControlAdv1
        End Select
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub treeViewAdv2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles treeViewAdv2.MouseDoubleClick
        Me.Cursor = Cursors.WaitCursor
        Select Case treeViewAdv2.SelectedNode.Text
            Case "Administración de Clientes"
                ListaClientes()
            Case "Ventas del período"
                '   GetListaVentasPorPeriodo()
            Case "Notas Pedido"
                GetListaNotasPedido()

            Case "Cotizaciones"
            Case "Ventas Anuladas"

                GetListaVentasPorPeriodoAnulado()
        End Select
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub treeViewAdv2_Click(sender As Object, e As EventArgs) Handles treeViewAdv2.Click

    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        Me.Cursor = Cursors.WaitCursor
        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then
            If Not IsNothing(Me.dgvVentas.Table.CurrentRecord) Then
                Select Case Me.dgvVentas.Table.CurrentRecord.GetValue("tipoCompra")
                    Case TIPO_VENTA.VENTA_GENERAL
                        Dim f As New frmVenta(Me.dgvVentas.Table.CurrentRecord.GetValue("idDocumento"))
                        'f.WindowState = FormWindowState.Maximized
                        f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                        f.ShowDialog()
                    Case TIPO_VENTA.VENTA_NOTA_PEDIDO
                        Dim f As New frmVentaPV(Me.dgvVentas.Table.CurrentRecord.GetValue("idDocumento"))
                        'f.WindowState = FormWindowState.Maximized
                        f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                        f.ShowDialog()

                    Case TIPO_VENTA.VENTA_POS_DIRECTA
                        Dim f As New frmVentaPVdirecta(Me.dgvVentas.Table.CurrentRecord.GetValue("idDocumento"))
                        'f.WindowState = FormWindowState.Maximized
                        f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                        f.ShowDialog()
                    Case TIPO_VENTA.VENTA_AL_TICKET
                        Dim f As New frmVentaPV(Me.dgvVentas.Table.CurrentRecord.GetValue("idDocumento"))
                        'f.WindowState = FormWindowState.Maximized
                        f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                        f.ShowDialog()

                End Select
            Else
                MessageBox.Show("Debe seleccionar un pedido/venta!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        ElseIf TabControlAdv1.SelectedTab Is TabPageAdv2 Then
            If Not IsNothing(dgvCliente.Table.CurrentRecord) Then
                If dgvCliente.Table.CurrentRecord.GetValue("razon") <> "CLIENTES VARIOS" Then
                    Dim f As New frmCrearENtidades
                    f.CaptionLabels(0).Text = "Editar cliente"
                    f.strTipo = TIPO_ENTIDAD.CLIENTE
                    f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    f.intIdEntidad = Me.dgvCliente.Table.CurrentRecord.GetValue("idEntidad")
                    f.UbicarEntidad(Me.dgvCliente.Table.CurrentRecord.GetValue("idEntidad"))
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                End If

            Else
                MessageBox.Show("Debe seleccionar un cliente!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        ElseIf TabControlAdv1.SelectedTab Is TabCotizacion Then
            If Not IsNothing(dgvCoti.Table.CurrentRecord) Then
                Dim f As New frmVentaPV(Me.dgvCoti.Table.CurrentRecord.GetValue("idDocumento"))
                f.WindowState = FormWindowState.Maximized
                f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                f.ShowDialog()
            Else
                MessageBox.Show("Debe seleccionar una cotización!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Me.Cursor = Cursors.WaitCursor
        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then
            If Not IsNothing(Me.dgvVentas.Table.CurrentRecord) Then
                If MessageBox.Show("Desea Elimiar el item seleccionado?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Select Case Me.dgvVentas.Table.CurrentRecord.GetValue("tipoCompra")
                        Case TIPO_COMPRA.NOTA_CREDITO
                            EliminarNota(Me.dgvVentas.Table.CurrentRecord.GetValue("idDocumento"))

                        Case TIPO_COMPRA.NOTA_DEBITO
                            EliminarNotaDebito(Me.dgvVentas.Table.CurrentRecord.GetValue("idDocumento"))

                        Case TIPO_VENTA.VENTA_NOTA_PEDIDO
                            EliminarPV(Me.dgvVentas.Table.CurrentRecord.GetValue("idDocumento"))
                        Case TIPO_VENTA.VENTA_GENERAL
                            'se elimina atraves de las notas de credito

                            EliminarVentaGeneral(Val(Me.dgvVentas.Table.CurrentRecord.GetValue("idDocumento")))
                        Case TIPO_VENTA.VENTA_POS_DIRECTA, TIPO_VENTA.VENTA_AL_TICKET
                            EliminarPVDirecta(Val(Me.dgvVentas.Table.CurrentRecord.GetValue("idDocumento")))
                    End Select
                End If
            Else
                MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        ElseIf (TabControlAdv1.SelectedTab Is TabPageAdv2) Then
            Dim documentoVentasSA As New documentoVentaAbarrotesSA
            Dim SumVentaProveedor As Integer = 0
            If Not IsNothing(Me.dgvCliente.Table.CurrentRecord) Then
                SumVentaProveedor = documentoVentasSA.UbicarVentaPorClienteXperiodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, Me.dgvCliente.Table.CurrentRecord.GetValue("nroDoc"), PeriodoGeneral).Count

                If (SumVentaProveedor = 0) Then
                    ElimnarCliente()
                Else
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                    lblEstado.Text = "El Cliente tiene movimientos, error al eliminar!"
                End If
            End If

        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.Cursor = Cursors.WaitCursor
        GetCountPedidos()
        GetCountVentasAnuladas()
        Select Case treeViewAdv2.SelectedNode.Text
            Case "Administración de Clientes"
                ListaClientes()
            Case "Ventas del período"
                GetListaVentasPorPeriodo()
            Case "Cotizaciones"
                '   GetVentasPeriodoByProveedor()
        End Select
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        PanelError.Visible = False
        Timer1.Enabled = False
    End Sub

    Private Sub ToolStripButton11_Click(sender As Object, e As EventArgs) Handles ToolStripButton11.Click
        Dim f As New frmVenta
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        f.ShowDialog()
        'Dim SaldoCaja As New UsuarioEstadoCaja
        'SaldoCaja.GetSaldoActual(GFichaUsuarios)
        'Me.CaptionLabels(0).Text = GFichaUsuarios.SaldoMN.ToString("N2")
    End Sub

    Private Sub ToolStripButton12_Click(sender As Object, e As EventArgs) Handles ToolStripButton12.Click
        Dim f As New frmVentaPV
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        'f.txtFecha.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
        'f.txtFecha.CustomFormat = "dd/MM/yyyy HH:mm tt"
        f.StartPosition = FormStartPosition.CenterScreen
        f.Show()
    End Sub

    Private Sub ToolStripButton14_Click(sender As Object, e As EventArgs) Handles ToolStripButton14.Click
        Dim f As New frmCrearENtidades
        f.CaptionLabels(0).Text = "Nuevo cliente"
        f.strTipo = TIPO_ENTIDAD.CLIENTE
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub ToolStripDropDownButton1_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton1.Click
        'If Not IsNothing(GFichaUsuarios) Then
        Dim f As New frmNotaVentaNew
        f.ShowDialog()
        '    Dim SaldoCaja As New UsuarioEstadoCaja
        '    SaldoCaja.GetSaldoActual(GFichaUsuarios)
        '    Me.CaptionLabels(0).Text = GFichaUsuarios.SaldoMN.ToString("N2")
        'Else
        '    lblEstado.Text = "Debe iniciar una caja, para realizar està tarea!"
        '    PanelError.Visible = True
        '    Timer1.Enabled = True
        '    TiempoEjecutar(10)
        'End If
    End Sub

    Private Sub ToolStripButton13_Click(sender As Object, e As EventArgs) Handles ToolStripButton13.Click
        'If Not IsNothing(GFichaUsuarios) Then
        Dim f As New frmNotaDebitoVenta
        f.ShowDialog()
        'Dim SaldoCaja As New UsuarioEstadoCaja
        'SaldoCaja.GetSaldoActual(GFichaUsuarios)
        'Me.CaptionLabels(0).Text = GFichaUsuarios.SaldoMN.ToString("N2")
        'Else
        'lblEstado.Text = "Debe iniciar una caja, para realizar està tarea!"
        'PanelError.Visible = True
        'Timer1.Enabled = True
        'TiempoEjecutar(10)
        'End If
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs)

    End Sub
    Dim filter As New GridExcelFilter()
    Private Sub ToolStripButton15_Click(sender As Object, e As EventArgs) Handles ToolStripButton15.Click
        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then
            filter.ClearFilters(Me.dgvVentas)
            Me.dgvVentas.TopLevelGroupOptions.ShowFilterBar = False
        ElseIf TabControlAdv1.SelectedTab Is TabPageAdv2 Then
            filter.ClearFilters(Me.dgvCliente)
            Me.dgvCliente.TopLevelGroupOptions.ShowFilterBar = False
        End If

    End Sub

    Private Sub ToolStripButton16_Click(sender As Object, e As EventArgs) Handles ToolStripButton16.Click
        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then
            dgvVentas.TableDescriptor.GroupedColumns.Clear()
            If dgvVentas.ShowGroupDropArea = True Then
                dgvVentas.ShowGroupDropArea = False
            Else
                dgvVentas.ShowGroupDropArea = True
            End If
        ElseIf TabControlAdv1.SelectedTab Is TabPageAdv2 Then
            dgvCliente.TableDescriptor.GroupedColumns.Clear()
            If dgvCliente.ShowGroupDropArea = True Then
                dgvCliente.ShowGroupDropArea = False
            Else
                dgvCliente.ShowGroupDropArea = True
            End If
        End If
    End Sub

    Private Sub ToolStripButton17_Click(sender As Object, e As EventArgs) Handles ToolStripButton17.Click
        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then
            Me.dgvVentas.TopLevelGroupOptions.ShowFilterBar = True
            Me.dgvVentas.NestedTableGroupOptions.ShowFilterBar = True
            Me.dgvVentas.ChildGroupOptions.ShowFilterBar = True

            For Each col As GridColumnDescriptor In Me.dgvVentas.TableDescriptor.Columns
                col.AllowFilter = True
            Next
            filter.AllowResize = True
            filter.AllowFilterByColor = True
            filter.EnableDateFilter = True
            filter.EnableNumberFilter = True

            Me.dgvVentas.OptimizeFilterPerformance = True
            Me.dgvVentas.ShowNavigationBar = True

            filter.WireGrid(dgvVentas)
        ElseIf TabControlAdv1.SelectedTab Is TabPageAdv2 Then

            Me.dgvCliente.TopLevelGroupOptions.ShowFilterBar = True
            Me.dgvCliente.NestedTableGroupOptions.ShowFilterBar = True
            Me.dgvCliente.ChildGroupOptions.ShowFilterBar = True

            For Each col As GridColumnDescriptor In Me.dgvCliente.TableDescriptor.Columns
                col.AllowFilter = True
            Next
            filter.AllowResize = True
            filter.AllowFilterByColor = True
            filter.EnableDateFilter = True
            filter.EnableNumberFilter = True

            Me.dgvCliente.OptimizeFilterPerformance = True
            Me.dgvCliente.ShowNavigationBar = True

            filter.WireGrid(dgvCliente)

        End If
    End Sub

    Private Sub PrestaciónConBienesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrestaciónConBienesToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Dim cajaUsuario As New cajaUsuario
        Dim cajaUsuarioSA As New cajaUsuarioSA

        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then
            If cboMesCompra.Text.Trim.Length > 0 Then
                cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                If Not IsNothing(cajaUsuario) Then
                    Dim f As New frmVenta
                    f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                    f.CargarTipoDeVenta(TIPO_VENTA.VENTA_CONTADO_TOTAL)
                    f.ToolStripLabel1.Visible = False
                    f.ToolStripLabel3.Visible = False
                    f.ToolStripComboBox1.Visible = False
                    f.ToolStripComboBox2.Visible = False
                    f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    f.ShowDialog()
                Else
                    MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                 MessageBox.Show("Debe indicar el un período para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
           
        Else
            MessageBox.Show("Debe indicar el un período para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Dim f As New frmCotizacion
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub PrestaciónDeServiciosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrestaciónDeServiciosToolStripMenuItem.Click
        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then
            If cboMesCompra.Text.Trim.Length > 0 Then
                Dim f As New frmVentaPV
                f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                'f.txtFecha.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
                'f.txtFecha.CustomFormat = "dd/MM/yyyy HH:mm tt"
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                GetCountPedidos()
            Else
                MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMesCompra.Select()
                cboMesCompra.DroppedDown = True
            End If
        Else
            MessageBox.Show("Debe indicar el un período para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        
    End Sub

    Private Sub txtRuc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRuc.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtRuc.Text.Trim.Length > 0 Then
                'If VAL_RUC(txtRuc.Text) = False Then
                '    MessageBoxAdv.Show("RUC NO VALIDO", "SIGEA", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Else
                '    MessageBoxAdv.Show("OK", "SIGEA", MessageBoxButtons.OK, MessageBoxIcon.Information)
                UbicarEntidadPorRuc(txtRuc.Text.Trim)
                'End If

            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        If txtCliente.Tag.ToString.Trim.Length > 0 Then
            GetVentasPeriodoByCliente()
        Else
            MessageBox.Show("Debe identificar al cliente!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(dgvCoti.Table.CurrentRecord) Then
            Dim f As New frmVentaPV(True, Val(dgvCoti.Table.CurrentRecord.GetValue("idDocumento")))
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        Else
            MessageBox.Show("Debe seleccionar un cliente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub VentaPOSToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim f As New frmVentaPVdirecta
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterScreen
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub ButtonAdv19_Click(sender As Object, e As EventArgs) Handles ButtonAdv19.Click
        Cursor = Cursors.WaitCursor
        GetListaVentasPorPeriodo()
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv18_Click(sender As Object, e As EventArgs) Handles ButtonAdv18.Click
        Dim r As Record = dgvVentas.Table.CurrentRecord
        If Not IsNothing(r) Then
            Dim f As New frmCambiarPeriodo2(New documentoventaAbarrotes With {.idDocumento = Val(r.GetValue("idDocumento"))})
            f.operacion = StatusTipoOperacion.VENTA
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            ButtonAdv19_Click(sender, e)
        End If
    End Sub

    Private Sub GradientPanel17_Paint(sender As Object, e As PaintEventArgs) Handles GradientPanel17.Paint

    End Sub

    Private Sub VentaDirectaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentaDirectaToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Dim cajaUsuario As New cajaUsuario
        Dim cajaUsuarioSA As New cajaUsuarioSA

        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then
            If cboMesCompra.Text.Trim.Length > 0 Then
                cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                If Not IsNothing(cajaUsuario) Then
                    Dim f As New frmVentaPVdirecta
                    f.lblPerido.Text = cboMesCompra.SelectedValue & "/" & AnioGeneral
                    f.CargarTipoDeVenta(TIPO_VENTA.VENTA_CONTADO_TOTAL)
                    f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    f.ToolStripLabel7.Visible = False
                    f.ToolStripLabel8.Visible = False
                    f.ToolStripComboBox1.Visible = False
                    f.ToolStripComboBox2.Visible = False
                    f.WindowState = FormWindowState.Maximized
                    f.ShowDialog()
                Else
                    MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Debe indicar el un período para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Else
            MessageBox.Show("Debe indicar el un período para realizar la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvVentas_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvVentas.TableControlCellClick

    End Sub
End Class