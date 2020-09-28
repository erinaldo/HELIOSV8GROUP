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
Public Class frmOrdenDeCompraExistencia
    Public Sub New()
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        GridCFG(dgvAprobacion)
        GridCFG(dgvHistorial)


    End Sub


    Sub ConfiguracionInicio()
        'TotalesXcanbeceras = New TotalesXcanbecera()
        'Dim almacenSA As New almacenSA
        'idAlmacenVirtual = almacenSA.GetUbicar_almacenVirtual(GEstableciento.IdEstablecimiento).idAlmacen
        'configurando docking manager

        'dockingManager1.DockControlInAutoHideMode(Panel4, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 420)
        Me.DockingClientPanel1.AutoScroll = True
        Me.DockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D


        dockingManager1.DockControlInAutoHideMode(GradientPanel1, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 500)
        ' dockingManager1.DockControlInAutoHideMode(Panel5, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 420)
        dockingManager1.SetDockLabel(GradientPanel1, "Datos generales")
        'dockingManager1.SetDockLabel(Panel5, "Servicios y Otros")
        'Panel5.Visible = False
      



        'dockingManager1.SetDockLabel(Panel4, "Activo Inmovilizado")
        dockingManager1.CloseEnabled = False

        'If Not IsNothing(GFichaUsuarios) Then
        ' ToolStripButton1.Image = ImageListAdv1.Images(1)
        'dgvCompra.TableDescriptor.Columns("chPago").Width = 0
        'Else
        'dgvCompra.TableDescriptor.Columns("chPago").Width = 0
        'ToolStripButton1.Image = ImageListAdv1.Images(0)
        'GFichaUsuarios = Nothing
        'End If
        'dgvCompra.TableDescriptor.Columns("pume").Width = 0
        'dgvCompra.TableDescriptor.Columns("vcme").Width = 0
        'dgvCompra.TableDescriptor.Columns("igvme").Width = 0
        'dgvCompra.TableDescriptor.Columns("totalme").Width = 0
        'dgvCompra.TableDescriptor.Columns("percepcionME").Width = 0
        'cboMoneda.SelectedValue = 1


        'confgiurando variables generales
        'txtGlosa.Text = "Por la compra según " & cboTipoDoc.Text
        'txtIva.DoubleValue = TmpIGV / 100
        'lblPerido.Text = PeriodoGeneral
        ''   txtTipoCambio.DecimalValue = TmpTipoCambio
        'ListaTipoCambio = New List(Of tipoCambio)
        'LoadTipoCambio()

        'txtFecha.Value = New Date(CInt(AnioGeneral), CInt(MesGeneral), DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        'txtFecVence.Value = New Date(CInt(AnioGeneral), CInt(MesGeneral), DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        'txtFecha.Select()
    End Sub

    Sub GridCFG(grid As GridGroupingControl)
        grid.TableOptions.ShowRowHeader = False
        grid.TopLevelGroupOptions.ShowCaption = False

        Dim colorx As New GridMetroColors()
        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        grid.SetMetroStyle(colorx)
        grid.BorderStyle = System.Windows.Forms.BorderStyle.None
        grid.TableOptions.SelectionBackColor = Color.Gray
        grid.AllowProportionalColumnSizing = False
        grid.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        grid.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        grid.Table.DefaultColumnHeaderRowHeight = 25
        grid.Table.DefaultRecordRowHeight = 20
        grid.TableDescriptor.Appearance.AnyCell.Font.Size = 7.5F

    End Sub

    Public Sub UbicarDocumentos(intIdDocumento As Integer)
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim documentoDetalleSA As New DocumentoCompraDetalleSA
        Dim docOtros As New DocumentoOtrosDatosSA
        Dim entidadSA As New entidadSA
        Dim almacenSA As New almacenSA
        Dim tablaDetalleSA As New tablaDetalleSA
        Dim cFinancieraSA As New EstadosFinancierosSA
        Try
            With documentoCompraSA.UbicarDocumentoCompra(intIdDocumento)

                With entidadSA.UbicarEntidadPorID(.idProveedor).First
                    txtProveedor.Text = .nombreCompleto
                    txtProveedor.Tag = .idEntidad
                    txtRuc.Text = .nrodoc
                    'txtCuenta.Text = .cuentaAsiento
                End With

                With docOtros.UbicarDocumentoOtros(intIdDocumento)

                    If (Not IsNothing(.condicionPago)) Then
                        txtCondicionPago.Text = tablaDetalleSA.GetUbicarTablaID(501, CInt(.condicionPago)).descripcion
                    End If

                    If (Not IsNothing(.Vcto)) Then
                        dtpFechaVencimiento.Value = CDate(.Vcto).Date
                    End If

                    If (Not IsNothing(.Modalidad)) Then
                        txtModalidades.Text = tablaDetalleSA.GetUbicarTablaID(1, .Modalidad).descripcion
                    End If

                    'txtNroCtas.Text = .ctaDeposito

                    'If ((.institucionFinanciera).Length > 0) Then
                    '    With cFinancieraSA.ObtenerEstadosFinancierosPorCodigo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, .institucionFinanciera)
                    '        txtIntFinancieras.Text = .descripcion
                    '    End With
                    'End If
                End With

                'If (.monedaDoc = "1") Then
                '    txtMoneda.Text = "NACIONAL"

                'ElseIf (.monedaDoc = "2") Then
                '    txtMoneda.Text = "EXTRANJERA"


                'End If
                txtFecha.Value = .fechaDoc
                txtSerie.Text = .serie
                txtNumero.Text = .numeroDoc
                txtTipoCambio.Text = .tcDolLoc
                'falta llamar  el igv 
            End With

            HistorialCompra(intIdDocumento)

        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Sub HistorialCompra(intIdCompra As Integer)
        Dim objLista As New DocumentoCajaDetalleSA()
        dgvAprobacion.TableDescriptor.Name = ("Detalles - Orden de Compra")
        dgvAprobacion.DataSource = getParentTableComprasPorPeriodo(intIdCompra) ' objLista.ObtenerHistorialPagos(intIdCompra)
        dgvAprobacion.TableDescriptor.Relations.Clear()
        dgvAprobacion.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
        dgvAprobacion.TableOptions.ListBoxSelectionMode = SelectionMode.One
        dgvAprobacion.ShowColumnHeaders = True
        dgvAprobacion.GroupDropPanel.Visible = False
        Me.dgvAprobacion.TopLevelGroupOptions.ShowCaption = False
        dgvAprobacion.Appearance.AnyRecordFieldCell.Enabled = False
        dgvAprobacion.TableDescriptor.GroupedColumns.Clear()
        'dgvAprobacion.TableDescriptor.GroupedColumns.Add("descripcionItem")

    End Sub

    Private Function getParentTableComprasPorPeriodo(idDocumento As Integer) As DataTable
        Dim DocumentoCompraSA As New DocumentoCompraDetalleSA
        Dim DocumentoCompraDetalleSA As New DocumentoCompraDetalleSA

        Dim dgvAprobacion = New DataTable("Movimientos - período " & PeriodoGeneral & " ")
        dgvAprobacion.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dgvAprobacion.Columns.Add(New DataColumn("secuencia", GetType(Integer)))
        dgvAprobacion.Columns.Add(New DataColumn("descripcionItem", GetType(String)))
        dgvAprobacion.Columns.Add(New DataColumn("monto2", GetType(String)))
        dgvAprobacion.Columns.Add(New DataColumn("monto1", GetType(Decimal)))
        dgvAprobacion.Columns.Add(New DataColumn("precioUnitario", GetType(Decimal)))
        dgvAprobacion.Columns.Add(New DataColumn("precioUnitarioUS", GetType(Decimal)))
        dgvAprobacion.Columns.Add(New DataColumn("importe", GetType(Decimal)))
        dgvAprobacion.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))
        dgvAprobacion.Columns.Add(New DataColumn("idItem", GetType(Integer)))
        dgvAprobacion.Columns.Add(New DataColumn("estado", GetType(String)))
        'dgvAprobacion.Columns.Add(New DataColumn("cantidadCredito", GetType(String)))

        For Each i As documentocompradetalle In DocumentoCompraDetalleSA.GetUbicar_OrdenCompraHistorial(idDocumento, "OCT")
            Dim dr As DataRow = dgvAprobacion.NewRow()

            dr(0) = i.idDocumento
            dr(1) = i.secuencia
            dr(2) = i.descripcionItem
            dr(3) = i.monto2
            dr(4) = i.monto1
            dr(5) = i.precioUnitario
            dr(6) = i.precioUnitarioUS
            dr(7) = i.importe
            dr(8) = i.importeUS
            dr(9) = i.idItem
            dr(10) = "I"
            'dr(11) = i.cantidadCredito

            dgvAprobacion.Rows.Add(dr)
        Next
        Return dgvAprobacion

    End Function

    Private Sub HistorialCompraEntrega(intIdCompra As Integer)
        Dim objLista As New DocumentoCajaDetalleSA()
        dgvHistorial.TableDescriptor.Name = ("Historial Entrega")
        dgvHistorial.DataSource = getParentTableComprasHistorialEntrega(intIdCompra) ' objLista.ObtenerHistorialPagos(intIdCompra)
        dgvHistorial.TableDescriptor.Relations.Clear()
        dgvHistorial.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
        dgvHistorial.TableOptions.ListBoxSelectionMode = SelectionMode.One
        dgvHistorial.ShowColumnHeaders = True
        dgvHistorial.GroupDropPanel.Visible = False
        Me.dgvHistorial.TopLevelGroupOptions.ShowCaption = False
        '  dgvPagos.TableOptions.ShowRowHeader = False
        dgvHistorial.Appearance.AnyRecordFieldCell.Enabled = False
        dgvHistorial.TableDescriptor.GroupedColumns.Clear()
        'dgvHistorial.TableDescriptor.GroupedColumns.Add("nomDocumento")
    End Sub

    Private Function getParentTableComprasHistorialEntrega(intIdCompra As Integer) As DataTable
        Dim DocumentoCompraSA As New DocumentoOtrosDatosSA

        Dim dt As New DataTable("Movimientos - período " & PeriodoGeneral & " ")
        Dim DocumentoOtrosDatosSA As New DocumentoOtrosDatosSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("secuencia", GetType(Integer)))
        dt.Columns.Add(New DataColumn("cantidad", GetType(Integer)))
        dt.Columns.Add(New DataColumn("idAlmacen", GetType(Integer)))
        dt.Columns.Add(New DataColumn("nombreAlmacen", GetType(String)))
        dt.Columns.Add(New DataColumn("direccionAlmacen", GetType(String)))
        dt.Columns.Add(New DataColumn("fechainicio", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaFin", GetType(String)))
        dt.Columns.Add(New DataColumn("FechaIniGarantia", GetType(String)))
        dt.Columns.Add(New DataColumn("FechaFinGarantia", GetType(String)))
        dt.Columns.Add(New DataColumn("notas", GetType(String)))
        dt.Columns.Add(New DataColumn("indicaciones", GetType(String)))
        dt.Columns.Add(New DataColumn("idItem", GetType(Integer)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))


        Dim str, str2, str3, str4 As String
        For Each i As documentoOtrosDatos In DocumentoOtrosDatosSA.UbicarDocumentoOtrosHistorialEntrega(intIdCompra)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaInicio).ToString("dd-MMM hh:mm tt ")
            str2 = Nothing
            str2 = CDate(i.fechaFin).ToString("dd-MMM hh:mm tt ")
            str3 = Nothing
            str3 = CDate(i.FechaIniGarantia).ToString("dd-MMM hh:mm tt ")
            str4 = Nothing
            str4 = CDate(i.FechaFinGarantia).ToString("dd-MMM hh:mm tt ")

            dr(0) = i.idDocumento
            dr(1) = i.secuencia
            dr(2) = i.cantidad
            dr(3) = i.idAlmacen
            dr(4) = i.nombreAlmacen
            dr(5) = i.direccionAlmacen
            dr(6) = str
            dr(7) = str2
            dr(8) = str3
            dr(9) = str4
            dr(10) = i.notas
            dr(11) = i.indicaciones
            dr(12) = i.idItem
            dr(13) = "U"

            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Sub UbicarDetalleDeEntrega()
        If Not IsNothing(Me.dgvAprobacion.Table.CurrentRecord) Then
            HistorialCompraEntrega(Me.dgvAprobacion.Table.CurrentRecord.GetValue("secuencia"))
        Else
            'lblEstado.Text = "Debe seleccionar un campo"
        End If
    End Sub

    Private Sub dgvAprobacion_TableControlCellClick(sender As Object, e As Grid.Grouping.GridTableControlCellClickEventArgs) Handles dgvAprobacion.TableControlCellClick
        UbicarDetalleDeEntrega()
    End Sub

    Private Sub frmOrdenDeCompraExistencia_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dispose()
    End Sub

    Private Sub Panel7_Paint(sender As Object, e As PaintEventArgs)

    End Sub
End Class