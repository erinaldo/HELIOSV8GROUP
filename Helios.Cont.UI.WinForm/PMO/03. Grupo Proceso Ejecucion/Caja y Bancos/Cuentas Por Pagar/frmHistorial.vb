Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.GridHelperClasses
Imports PopupControl
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Public Class frmHistorial
    Inherits frmMaster

    Public Property IdDocumentoCompra As Integer
    Dim colorx As New GridMetroColors()
    Dim tipoanticipo As String
    Public Property empresaPeriodoSA As New empresaCierreMensualSA

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridCFG(dgvCompras)

    End Sub

#Region "Métodos"

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


    'Public Sub EliminarCompensacion(intIdDocumento As Integer)
    '    Dim documentoSA As New DocumentoSA

    '    documentoSA.EliminarCompensacion(intIdDocumento)
    '    Me.dgvCompras.Table.CurrentRecord.Delete()

    'End Sub

    '/////////////m

    Private Function getParentAnticipo(intIdCompra As Integer) As DataTable
        Dim objLista As New documentoAnticipoSA()

        Dim dt As New DataTable("ParentTable")

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("fecha", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("moneda", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoCambio", GetType(String)))

        dt.Columns.Add(New DataColumn("montoSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUsd", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("operacion", GetType(String)))

        Dim str2 As String
        For Each i As documentoAnticipo In objLista.ListadoComprobatenAnticipos(intIdCompra)
            Dim dr As DataRow = dt.NewRow()
            str2 = Nothing
            str2 = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = str2
            dr(2) = i.tipoDocumento
            dr(3) = i.numeroDoc
            dr(4) = i.Moneda
            dr(5) = i.TipoCambio
            dr(6) = i.importeMN
            dr(7) = i.importeME
            dr(8) = i.codigoLibro
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Private Function getParentCaja(intIdCompra As Integer) As DataTable
        Dim objLista As New DocumentoCajaSA()
        Dim objLista2 As New documentoAnticipoSA()
        Dim objlista3 As New DocumentoCompraSA()
        Dim objlista4 As New documentoVentaAbarrotesSA()

        Dim dt As New DataTable("ParentTable")

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("fecha", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("moneda", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoCambio", GetType(String)))

        dt.Columns.Add(New DataColumn("montoSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUsd", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("operacion", GetType(String)))
        dt.Columns.Add(New DataColumn("tipo", GetType(String)))
        dt.Columns.Add(New DataColumn("periodo", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaOper", GetType(String)))

        Dim str As String
        For Each i As documentoCaja In objLista.ListadoComprobaNtesXidPadre(intIdCompra)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaProceso).ToString("dd-MMM hh:mm tt ")
            Dim fechaOper = CDate(i.fechaModificacion).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = str
            dr(2) = i.tipoDocPago
            dr(3) = i.numeroDoc
            dr(4) = i.moneda
            dr(5) = i.tipoCambio
            dr(6) = i.montoSoles.GetValueOrDefault
            dr(7) = i.montoUsd.GetValueOrDefault
            dr(8) = i.tipoOperacion
            dr(9) = i.formapago
            dr(10) = GetPeriodo(i.fechaProceso, True)
            dr(11) = fechaOper
            dt.Rows.Add(dr)
        Next



        '//////////////////
        Dim str2 As String
        For Each i As documentoAnticipo In objLista2.ListadoComprobatenAnticipos(intIdCompra)
            Dim dr As DataRow = dt.NewRow()
            str2 = Nothing
            str2 = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = str2
            dr(2) = i.tipoDocumento
            dr(3) = i.numeroDoc
            dr(4) = i.Moneda
            dr(5) = i.TipoCambio
            dr(6) = i.importeMN
            dr(7) = i.importeME
            dr(8) = i.codigoLibro

            If lbltipoanticipo.Text = "RECIBIDO" Then
                dr(9) = "ANTICIPO R"
            Else

                dr(9) = "ANTICIPO"
            End If
            dt.Rows.Add(dr)
        Next
        '////////////
        Dim str3 As String
        For Each i As documentocompra In objlista3.ListadoComprobateNotasXidPadre(intIdCompra)
            Dim dr As DataRow = dt.NewRow()
            str3 = Nothing
            str3 = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = str3
            dr(2) = i.tipoDoc
            dr(3) = i.numeroDoc
            dr(4) = i.monedaDoc
            dr(5) = i.tipocambio
            dr(6) = i.importeTotal
            dr(7) = i.importeUS
            dr(8) = i.codigoLibro
            dr(9) = i.tipoCompra

            dt.Rows.Add(dr)
        Next

        Return dt
    End Function

    Private Function getParentCaja2(intIdCompra As Integer, tipo As String) As DataTable
        Dim objLista As New DocumentoCajaSA()
        Dim objLista2 As New documentoAnticipoSA()
        Dim objlista3 As New DocumentoCompraSA()
        Dim objlista4 As New documentoVentaAbarrotesSA()

        Dim dt As New DataTable("ParentTable")

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("fecha", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("moneda", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoCambio", GetType(String)))

        dt.Columns.Add(New DataColumn("montoSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUsd", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("operacion", GetType(String)))
        dt.Columns.Add(New DataColumn("tipo", GetType(String)))
        dt.Columns.Add(New DataColumn("periodo", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaOper", GetType(String)))

        Dim str As String
        For Each i As documentoCaja In objLista.ListadoComprobaNtesXidPadre(intIdCompra)
            Dim dr As DataRow = dt.NewRow()
            Dim fechaOper = CDate(i.fechaModificacion).ToString("dd-MMM hh:mm tt ")
            str = Nothing
            str = CDate(i.fechaCobro).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = str
            dr(2) = i.tipoDocPago
            dr(3) = i.numeroDoc
            dr(4) = i.moneda
            dr(5) = i.tipoCambio
            dr(6) = i.montoSoles.GetValueOrDefault
            dr(7) = i.montoUsd.GetValueOrDefault
            dr(8) = i.tipoOperacion
            dr(9) = i.formapago
            dr(10) = GetPeriodo(i.fechaProceso, True)
            dr(11) = fechaOper
            dt.Rows.Add(dr)
        Next



        '//////////////////
        Dim str2 As String
        For Each i As documentoAnticipo In objLista2.ListadoComprobatenAnticipos(intIdCompra)
            Dim dr As DataRow = dt.NewRow()
            str2 = Nothing
            str2 = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = str2
            dr(2) = i.tipoDocumento
            dr(3) = i.numeroDoc
            dr(4) = i.Moneda
            dr(5) = i.TipoCambio
            dr(6) = i.importeMN
            dr(7) = i.importeME
            dr(8) = i.codigoLibro

            If lbltipoanticipo.Text = "RECIBIDO" Then
                dr(9) = "ANTICIPO R"
            Else

                dr(9) = "ANTICIPO"
            End If
            dt.Rows.Add(dr)
        Next
        '////////////
        Dim str3 As String
        For Each i As documentocompra In objlista3.ListadoComprobateNotasXidPadre(intIdCompra)
            Dim dr As DataRow = dt.NewRow()
            str3 = Nothing
            str3 = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = str3
            dr(2) = i.tipoDoc
            dr(3) = i.numeroDoc
            dr(4) = i.monedaDoc
            dr(5) = i.tipocambio
            dr(6) = i.importeTotal
            dr(7) = i.importeUS
            dr(8) = i.codigoLibro
            dr(9) = i.tipoCompra

            dt.Rows.Add(dr)
        Next
        '///////////
        If tipo = "COMPRA" Then
            Dim str4 As String
            For Each i As documentoventaAbarrotes In objlista4.ListadoComprobateVentaNotasXidPadre(intIdCompra)
                Dim dr As DataRow = dt.NewRow()
                str4 = Nothing
                str4 = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
                dr(0) = i.idDocumento
                dr(1) = str4
                dr(2) = i.tipoDocumento
                dr(3) = i.numeroDoc
                dr(4) = i.moneda
                dr(5) = i.tipoCambio
                dr(6) = i.ImporteNacional
                dr(7) = i.ImporteExtranjero
                dr(8) = i.codigoLibro
                dr(9) = i.tipoVenta

                dt.Rows.Add(dr)
            Next

            '///////////

        ElseIf tipo = "VENTA" Then

            Dim str4 As String
            For Each i As documentoventaAbarrotes In objlista4.ListadoComprobateVentaNotasXidPadre(intIdCompra)
                Dim dr As DataRow = dt.NewRow()
                str4 = Nothing
                str4 = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
                dr(0) = i.idDocumento
                dr(1) = str4
                dr(2) = i.tipoDocumento
                dr(3) = i.numeroDoc
                dr(4) = i.moneda
                dr(5) = i.tipoCambio
                dr(6) = i.ImporteNacional
                dr(7) = i.ImporteExtranjero
                dr(8) = i.codigoLibro
                dr(9) = i.tipoVenta

                dt.Rows.Add(dr)
            Next

        End If
        Return dt
    End Function

    Private Function getChildCaja(intIdDocume As Integer) As DataTable
        Dim objLista As New DocumentoCajaSA()
        Dim objLista2 As New documentoAnticipoSA()
        Dim objLista3 As New DocumentoCompraDetalleSA()
        Dim objLista4 As New documentoVentaAbarrotesDetSA()

        Dim dt As New DataTable("ChildTable")
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DetalleItems", GetType(String)))
        dt.Columns.Add(New DataColumn("montoSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUsd", GetType(Decimal)))

        For Each i As documentoCajaDetalle In objLista.ListadoCajaDetalleHijos(intIdDocume)
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.idDocumento
            dr(1) = i.DetalleItem
            dr(2) = i.montoSoles
            dr(3) = i.montoUsd
            dt.Rows.Add(dr)
        Next



        For Each i As documentoAnticipoDetalle In objLista2.ListadoAnticiposDetalleHijos(intIdDocume)
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.idDocumento
            dr(1) = i.DetalleItem
            dr(2) = i.importeMN
            dr(3) = i.importeME
            dt.Rows.Add(dr)
        Next

        'If tipo = "COMPRA" Then

        For Each i As documentocompradetalle In objLista3.ListadoNotasDetalleHijos(intIdDocume)
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.idDocumento
            dr(1) = i.DetalleItem
            dr(2) = i.importe
            dr(3) = i.importeUS
            dt.Rows.Add(dr)
        Next
        'ElseIf tipo = "VENTA" Then

        '    For Each i As documentoventaAbarrotesDet In objLista4.ListadoNotasVentaDetalleHijos(intIdDocume)
        '        Dim dr As DataRow = dt.NewRow()
        '        dr(0) = i.idDocumento
        '        dr(1) = i.DetalleItem
        '        dr(2) = i.importeMN
        '        dr(3) = i.importeME
        '        dt.Rows.Add(dr)
        '    Next
        'End If

        Return dt
    End Function

    Private Function getChildCaja2(intIdDocume As Integer, tipo As String) As DataTable
        Dim objLista As New DocumentoCajaSA()
        Dim objLista2 As New documentoAnticipoSA()
        Dim objLista3 As New DocumentoCompraDetalleSA()
        Dim objLista4 As New documentoVentaAbarrotesDetSA()

        Dim dt As New DataTable("ChildTable")
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DetalleItems", GetType(String)))
        dt.Columns.Add(New DataColumn("montoSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUsd", GetType(Decimal)))

        For Each i As documentoCajaDetalle In objLista.ListadoCajaDetalleHijos(intIdDocume)
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.idDocumento
            dr(1) = i.DetalleItem
            dr(2) = i.montoSoles
            dr(3) = i.montoUsd
            dt.Rows.Add(dr)
        Next



        For Each i As documentoAnticipoDetalle In objLista2.ListadoAnticiposDetalleHijos(intIdDocume)
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.idDocumento
            dr(1) = i.DetalleItem
            dr(2) = i.importeMN
            dr(3) = i.importeME
            dt.Rows.Add(dr)
        Next

        If tipo = "COMPRA" Then

            For Each i As documentocompradetalle In objLista3.ListadoNotasDetalleHijos(intIdDocume)
                Dim dr As DataRow = dt.NewRow()
                dr(0) = i.idDocumento
                dr(1) = i.DetalleItem
                dr(2) = i.importe
                dr(3) = i.importeUS
                dt.Rows.Add(dr)
            Next
        ElseIf tipo = "VENTA" Then

            For Each i As documentoventaAbarrotesDet In objLista4.ListadoNotasVentaDetalleHijos(intIdDocume)
                Dim dr As DataRow = dt.NewRow()
                dr(0) = i.idDocumento
                dr(1) = i.DetalleItem
                dr(2) = i.importeMN
                dr(3) = i.importeME
                dt.Rows.Add(dr)
            Next
        End If

        Return dt
    End Function



    Dim parentTable As New DataTable
    Dim ChildTable As New DataTable
    Public Sub LoadHistorialCajasXcompra()

        Dim dSet As New DataSet()
        parentTable = getParentCaja(IdDocumentoCompra)
        ChildTable = getChildCaja(IdDocumentoCompra)
        dSet.Tables.AddRange(New DataTable() {parentTable, ChildTable})

        'setup the relations
        Dim parentColumn As DataColumn = parentTable.Columns("idDocumento")
        Dim childColumn As DataColumn = ChildTable.Columns("idDocumento")
        dSet.Relations.Add("ParentToChild", parentColumn, childColumn)

        Me.dgvCompras.DataSource = parentTable
        Me.dgvCompras.Engine.BindToCurrencyManager = False

        Me.dgvCompras.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
        Me.dgvCompras.TopLevelGroupOptions.ShowCaption = False


    End Sub



    Public Sub LoadHistorialCajasXcompra2(TipoC As String)

        Dim dSet As New DataSet()
        parentTable = getParentCaja2(IdDocumentoCompra, TipoC)
        ChildTable = getChildCaja2(IdDocumentoCompra, TipoC)
        dSet.Tables.AddRange(New DataTable() {parentTable, ChildTable})

        'setup the relations
        Dim parentColumn As DataColumn = parentTable.Columns("idDocumento")
        Dim childColumn As DataColumn = ChildTable.Columns("idDocumento")
        dSet.Relations.Add("ParentToChild", parentColumn, childColumn)

        Me.dgvCompras.DataSource = parentTable
        Me.dgvCompras.Engine.BindToCurrencyManager = False

        Me.dgvCompras.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
        Me.dgvCompras.TopLevelGroupOptions.ShowCaption = False


    End Sub


    Private Function getParentTableHistorial(intIdCompra As Integer) As DataTable
        Dim objLista As New DocumentoCajaDetalleSA()

        Dim dt As New DataTable("Historial de pagos ")

        dt.Columns.Add(New DataColumn("documentoAfectado", GetType(Integer)))
        dt.Columns.Add(New DataColumn("nomDocumento", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("numeroDocNormal", GetType(String)))
        dt.Columns.Add(New DataColumn("idCliente", GetType(String)))
        dt.Columns.Add(New DataColumn("nomEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))

        dt.Columns.Add(New DataColumn("moneda", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDocumento", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoCambio", GetType(String)))
        dt.Columns.Add(New DataColumn("idDocumento", GetType(String)))

        dt.Columns.Add(New DataColumn("montoSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUsd", GetType(Decimal)))

        Dim str As String
        For Each i As documentoCajaDetalle In objLista.ObtenerHistorialPagos(intIdCompra)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.documentoAfectado
            dr(1) = i.nomDocumento
            dr(2) = i.numeroDocNormal
            dr(3) = i.idCliente
            dr(4) = i.nomEntidad
            dr(5) = str

            dr(6) = i.moneda
            dr(7) = i.tipoDocumento
            dr(8) = i.tipoCambioTransacc
            dr(9) = i.idDocumento
            dr(10) = i.montoSoles
            dr(11) = i.montoUsd
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Public Sub EliminarCompensacion(intIdDocumento As Integer)
        Dim documentoSA As New DocumentoSA

        documentoSA.EliminarCompensacion(intIdDocumento)
        Me.dgvCompras.Table.CurrentRecord.Delete()

    End Sub


    Public Sub EliminarDocumento(intIdDocumento As Integer, codigoOperacion As String)
        Dim documentoSA As New DocumentoSA
        Dim docCajaSA As New DocumentoCajaSA
        Dim nDocumento As New documento()
        With nDocumento
            .IdDocumentoAfectado = IdDocumentoCompra
            .idDocumento = intIdDocumento
            .idOrden = codigoOperacion
            '     .usuarioActualizacion = docCajaSA.GetUbicar_documentoCajaPorID(intIdDocumento).usuarioModificacion
        End With
        documentoSA.ElimiNarPagoCompra(nDocumento)
        Me.dgvCompras.Table.CurrentRecord.Delete()
        'lblEstado.Text = "Pago eliminado correctamente"
        'PanelError.Visible = True
        'Timer1.Enabled = True
        'TiempoEjecutar(10)
        '  HistorialCompra(txtFechaCompra.ValueMember)
    End Sub





    Public Sub EliminarDocumentoAnticipoRec(intIdDocumento As Integer)
        Dim documentoSA As New DocumentoSA

        Dim nDocumento As New documento()
        With nDocumento
            .IdDocumentoAfectado = IdDocumentoCompra
            .idDocumento = intIdDocumento
            ' .idOrden = codigoOperacion
            '     .usuarioActualizacion = docCajaSA.GetUbicar_documentoCajaPorID(intIdDocumento).usuarioModificacion
        End With
        documentoSA.ElimiNarCobroAnticipoVenta(nDocumento)
        Me.dgvCompras.Table.CurrentRecord.Delete()
        'lblEstado.Text = "Pago eliminado correctamente"
        'PanelError.Visible = True
        'Timer1.Enabled = True
        'TiempoEjecutar(10)
        '  HistorialCompra(txtFechaCompra.ValueMember)
    End Sub

    Public Sub EliminarDocumentoAnticipo(intIdDocumento As Integer)
        Dim documentoSA As New DocumentoSA

        Dim nDocumento As New documento()
        With nDocumento
            .IdDocumentoAfectado = IdDocumentoCompra
            .idDocumento = intIdDocumento
            ' .idOrden = codigoOperacion
            '     .usuarioActualizacion = docCajaSA.GetUbicar_documentoCajaPorID(intIdDocumento).usuarioModificacion
        End With
        documentoSA.ElimiNarPagoAnticipoCompra(nDocumento)
        Me.dgvCompras.Table.CurrentRecord.Delete()
        'lblEstado.Text = "Pago eliminado correctamente"
        'PanelError.Visible = True
        'Timer1.Enabled = True
        'TiempoEjecutar(10)
        '  HistorialCompra(txtFechaCompra.ValueMember)
    End Sub

    Public Sub HistorialCompra(intIdCompra As Integer)
        Dim objLista As New DocumentoCajaDetalleSA()
        dgvHistorial.TableDescriptor.Name = ("Historial compra")
        dgvHistorial.DataSource = getParentTableHistorial(intIdCompra) ' objLista.ObtenerHistorialPagos(intIdCompra)
        dgvHistorial.TableDescriptor.Relations.Clear()
        dgvHistorial.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
        dgvHistorial.TableOptions.ListBoxSelectionMode = SelectionMode.One
        dgvHistorial.GroupDropPanel.Visible = True
        dgvHistorial.Appearance.AnyRecordFieldCell.Enabled = False
        dgvHistorial.TableDescriptor.GroupedColumns.Clear()
        dgvHistorial.TableDescriptor.GroupedColumns.Add("nomDocumento")
    End Sub
#End Region

    Private Sub frmHistorial_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmHistorial_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.Cursor = Cursors.WaitCursor
        LoadHistorialCajasXcompra()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            'If Not IsNothing(Me.dgvHistorial.Table.CurrentRecord) Then
            '    EliminarDocumento(CInt(Me.dgvHistorial.Table.CurrentRecord.GetValue("idDocumento")))
            'End If
            Dim el As Element = Me.dgvCompras.Table.GetInnerMostCurrentElement()

            If el IsNot Nothing Then
                Dim table As GridTable = TryCast(el.ParentTable, GridTable)
                Dim tableControl As GridTableControl = Me.dgvCompras.GetTableControl(table.TableDescriptor.Name)
                Dim cc As GridCurrentCell = tableControl.CurrentCell
                Dim style As GridTableCellStyleInfo = table.GetTableCellStyle(cc.RowIndex, cc.ColIndex)
                Dim rec As GridRecord = TryCast(el, GridRecord)
                If rec Is Nothing AndAlso TypeOf el Is GridRecordRow Then
                    rec = TryCast(el.ParentRecord, GridRecord)
                End If
                If rec IsNot Nothing Then




                    If MessageBox.Show("Desea eliminar el pago seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        If rec.GetValue("tipo") = "EFECTIVO" Or rec.GetValue("tipo") = "109" Then
                            EliminarDocumento(rec.GetValue("idDocumento"), rec.GetValue("operacion"))
                        ElseIf rec.GetValue("tipo") = "ANTICIPO" Then
                            EliminarDocumentoAnticipo(rec.GetValue("idDocumento"))

                        ElseIf rec.GetValue("tipo") = "ANTICIPO R" Then
                            EliminarDocumentoAnticipoRec(rec.GetValue("idDocumento"))

                        ElseIf rec.GetValue("tipo") = "COMPV" Then

                            EliminarCompensacion(rec.GetValue("idDocumento"))

                        ElseIf rec.GetValue("tipo") = "COMP" Then

                            EliminarCompensacion(rec.GetValue("idDocumento"))
                        ElseIf rec.GetValue("tipo") = "NTC" Then
                            MessageBox.Show("El pago seleccioinado pertenece a una nota de credito", "Verificar pago", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If

                    End If

                End If
            End If

        Catch ex As Exception
            'lblEstado.Text = ex.Message
            'PanelError.Visible = True
            'Timer1.Enabled = True
            'TiempoEjecutar(10)
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub SaveToolStripButton_Click(sender As Object, e As EventArgs) Handles SaveToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim el As Element = Me.dgvCompras.Table.GetInnerMostCurrentElement()
            Dim rec As GridRecord = TryCast(el, GridRecord)
            If rec Is Nothing AndAlso TypeOf el Is GridRecordRow Then
                rec = TryCast(el.ParentRecord, GridRecord)
            End If
            If el IsNot Nothing Then
                With frmPagos
                    .manipulacionEstado = ENTITY_ACTIONS.UPDATE
                    .UbicarDocumento(rec.GetValue("idDocumento"), dgvCompras.Table.CurrentRecord.GetValue("montoSoles"), dgvCompras.Table.CurrentRecord.GetValue("montoUsd"))
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog(Me)
                End With
            End If

        Catch ex As Exception
            'lblEstado.Text = ex.Message
            'PanelError.Visible = True
            'Timer1.Enabled = True
            'TiempoEjecutar(10)
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub
    Dim hoveredIndex As Integer = 0

    Dim selectionColl As New Hashtable()
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
    Private Sub dgvCompras_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvCompras.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            Me.dgvCompras.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub dgvCompras_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvCompras.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvCompras)
    End Sub

    Private Sub dgvCompras_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompras.TableControlCellClick

    End Sub

    Private Sub dgvCompras_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvCompras.SelectedRecordsChanged
        If Not IsNothing(Me.dgvCompras.Table.CurrentRecord) Then
            PrintToolStripButton.Enabled = True
            ToolStripButton2.Enabled = True
        Else
            PrintToolStripButton.Enabled = False
            ToolStripButton2.Enabled = False
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Try
            'Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = AnioGeneral, .mes = CInt(cboMesCompra.SelectedValue)})
            'If Not IsNothing(valida) Then
            '    If valida = True Then
            '        MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '        Exit Sub
            '    End If
            'End If
            Dim r As Record = dgvCompras.Table.CurrentRecord
            If Not IsNothing(r) Then
                Dim f As New frmCambiarPeriodo2(New documentoCaja With {.idDocumento = Val(r.GetValue("idDocumento"))})
                f.operacion = "Otros"
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                ToolStripButton2_Click(sender, e)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class