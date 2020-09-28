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
Public Class frmMasterCierres
    Inherits frmMaster

    Dim colorx As New GridMetroColors()

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.WindowState = FormWindowState.Maximized
        ObtenerPeriodosCerrados()
        Label29.Text = "PERIODO - " & AnioGeneral
        GridCFG(dgvInventario)
        GridCFG(dgvCaja)
        GridCFG(dgvCierreContable)
        GridCFG(GridGroupingControl1)
        txtAnioCompra.Text = AnioGeneral
        Meses()
    End Sub



    Private Sub Meses()
        Dim listaMeses As New List(Of MesesAnio)
        Dim obj As New MesesAnio

        For x = 1 To 12
            obj = New MesesAnio
            obj.Codigo = String.Format("{0:00}", CInt(x))
            obj.Mes = New DateTime(AnioGeneral, x, 1).ToString("MMMM")
            listaMeses.Add(obj)
        Next x
        'cboMes.DisplayMember = "Mes"
        'cboMes.ValueMember = "Codigo"
        'cboMes.DataSource = listaMeses

        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.DataSource = listaMeses
        cboMesCompra.SelectedValue = MesGeneral
    End Sub

#Region "Métodos"

    Public Sub EliminarCierre(strPeriodo As String)
        Dim cierreSA As New CierreInventarioSA
        cierreSA.EliminarCierreInventario(New cierreinventario With {.idEmpresa = Gempresas.IdEmpresaRuc, .periodo = strPeriodo})
        MessageBoxAdv.Show("Periodo abierto correctamente!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Sub EliminarCierreCaja(strPeriodo As String)
        Dim cierreSA As New CierreCajaSA
        cierreSA.EliminarCierreCaja(New cierreCaja With {.idEmpresa = Gempresas.IdEmpresaRuc, .periodo = strPeriodo})
        MessageBoxAdv.Show("Periodo abierto correctamente!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Sub EliminarCierreContable(strPeriodo As String)
        Dim cierreSA As New CierreContableSA
        cierreSA.EliminarCierreContable(New cierrecontable With {.idEmpresa = Gempresas.IdEmpresaRuc, .periodo = strPeriodo})
        MessageBoxAdv.Show("Periodo abierto correctamente!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Sub ListadoCierresPorPeriodo(strPeriodo As String)
        Dim cierreSA As New CierreInventarioSA
        Dim dt As New DataTable("Cierre del periodo: " & strPeriodo)
        dt.Columns.Add("almacen")
        dt.Columns.Add("item")
        dt.Columns.Add("tipoExistencia")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("importeMN")
        dt.Columns.Add("importeME")

        For Each i In cierreSA.GetListado_cierreinventarioPorPeriodo(New cierreinventario With {.idEmpresa = Gempresas.IdEmpresaRuc, .periodo = strPeriodo})
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.NomAlmacen
            dr(1) = i.NomItem
            dr(2) = i.TipoExistencia
            dr(3) = i.cantidad
            dr(4) = i.importe
            dr(5) = i.importeUS
            dt.Rows.Add(dr)
        Next
        dgvInventario.DataSource = dt
    End Sub


    Public Sub ListadoCierresCostoVentaPorPeriodo(strPeriodo As String)
        Dim cierreSA As New cierreCostoVentaSA
        Dim dt As New DataTable("Cierre del periodo: " & strPeriodo)
        dt.Columns.Add("tipoExistencia")
        dt.Columns.Add("tipoOperacion")
        dt.Columns.Add("periodo")
        dt.Columns.Add("importe")
        dt.Columns.Add("importeus")

        For Each i In cierreSA.GetListado_cierreCostoVenta(New cierreCostoVenta With {.idEmpresa = Gempresas.IdEmpresaRuc, .periodo = strPeriodo})
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.tipoExistencia
            dr(1) = i.tipoOperacion
            dr(2) = i.periodo
            dr(3) = i.importe
            dr(4) = i.importeUS
            dt.Rows.Add(dr)

        Next
        GridGroupingControl1.DataSource = dt
    End Sub


    Public Sub GetListaCierreContableXperiodo(strPeriodo As String)
        Dim cierreSA As New CierreContableSA
        Dim planContableSA As New cuentaplanContableEmpresaSA

        Dim dt As New DataTable("Balance de comprobación: " & PeriodoGeneral & " ")

        dt.Columns.Add(New DataColumn("cuenta", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("debe", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("haber", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("debeus", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("haberus", GetType(Decimal))) '
        dt.Columns.Add(New DataColumn("tipoasiento", GetType(String)))

        For Each i In cierreSA.GetCargarCierrePorPeriodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, strPeriodo)
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.cuenta
            Dim str As String = i.cuenta.Substring(0, 2)
            dr(1) = planContableSA.ObtenerCuentaPorID(Gempresas.IdEmpresaRuc, str).descripcion
            Select Case i.tipoasiento
                Case "D"
                    dr(2) = i.monto
                    dr(3) = 0
                Case "H"
                    dr(2) = 0
                    dr(3) = i.monto
            End Select

            Select Case i.tipoasiento
                Case "D"
                    dr(4) = i.montoUSD
                    dr(5) = 0
                Case "H"
                    dr(4) = 0
                    dr(5) = i.montoUSD
            End Select
            dr(6) = i.tipoasiento
            dt.Rows.Add(dr)
        Next
        dgvCierreContable.DataSource = dt
    End Sub


    Public Sub ListadoCajasPorPeriodo(strPeriodo As String)
        Dim cierreSA As New CierreCajaSA
        Dim dt As New DataTable("Cierre del periodo: " & strPeriodo)
        dt.Columns.Add("caja")
        dt.Columns.Add("tipo")
        dt.Columns.Add("moneda")
        dt.Columns.Add("montoCajaMN")
        dt.Columns.Add("montoCajaME")

        For Each i In cierreSA.GetListado_cierreCajasPorPeriodo(New cierreCaja With {.idEmpresa = Gempresas.IdEmpresaRuc, .periodo = strPeriodo})
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.NomEntidadFinanciera
            dr(1) = i.TipoEntidad
            dr(2) = i.Moneda
            dr(3) = i.montoMN
            dr(4) = i.montoME
            dt.Rows.Add(dr)
        Next
        dgvCaja.DataSource = dt
    End Sub

    Public Sub ObtenerPeriodosCerrados()
        Dim cierreSA As New CierreInventarioSA
        Try
            treeViewAdv2.Nodes.Clear()
            For Each i In cierreSA.ObtenerPeriodosCerrados(New cierreinventario With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
                Dim node As New TreeNodeAdv
                node.Text = i.periodo
                treeViewAdv2.Nodes.Add(node)
            Next
        Catch ex As Exception
            MessageBoxAdv.Show(ex.Message)
        End Try
    End Sub

    Sub GridCFG(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = True
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
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        GGC.Table.DefaultColumnHeaderRowHeight = 23
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub
#End Region

    Private Sub frmMasterCierres_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmMasterCierres_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub TabPageAdv1_Click(sender As Object, e As EventArgs) Handles TabPageAdv1.Click

    End Sub

    Private Sub treeViewAdv2_Click(sender As Object, e As EventArgs) Handles treeViewAdv2.Click

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(treeViewAdv2.SelectedNode) Then
            Select Case TabControlAdv2.SelectedIndex
                Case 0
                    ListadoCierresPorPeriodo(treeViewAdv2.SelectedNode.Text)
                Case 1
                    ListadoCajasPorPeriodo(treeViewAdv2.SelectedNode.Text)
                Case 2
                    GetListaCierreContableXperiodo(treeViewAdv2.SelectedNode.Text)
                Case 3

            End Select

        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(treeViewAdv2.SelectedNode) Then
            If Not IsNothing(treeViewAdv2.SelectedNode) Then
                Select Case TabControlAdv2.SelectedIndex
                    Case 0
                        EliminarCierre(treeViewAdv2.SelectedNode.Text) 'INVENTARIO
                    Case 1
                        EliminarCierreCaja(treeViewAdv2.SelectedNode.Text) 'CAJA
                    Case 2
                        EliminarCierreContable(treeViewAdv2.SelectedNode.Text) 'CONTABLE
                End Select
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboMesCompra_Click(sender As Object, e As EventArgs) Handles cboMesCompra.Click

    End Sub

    Private Sub cboMesCompra_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMesCompra.SelectedIndexChanged

        Dim periodo = String.Format("{0:00}", cboMesCompra.SelectedValue)
        'periodo = periodo & "/" & AnioGeneral
        periodo = periodo & AnioGeneral
        'getTableComprasPorPeriodoContado(GEstableciento.IdEstablecimiento, periodo)

        ListadoCierresCostoVentaPorPeriodo(periodo)


        ListadoCierresPorPeriodo(periodo)

        ListadoCajasPorPeriodo(periodo)

        GetListaCierreContableXperiodo(periodo)


    End Sub
End Class