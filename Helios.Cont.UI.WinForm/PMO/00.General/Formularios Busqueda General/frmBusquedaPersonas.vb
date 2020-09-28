Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Microsoft
Public Class frmBusquedaPersonas
    Inherits frmMaster

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridCFG(dgvEntidadFinanciera)
    End Sub

#Region "métodos"

    Sub GridCFG(GGC As GridGroupingControl)
        Dim colorx As New GridMetroColors()

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

    'Sub GridCFG(GGC As GridGroupingControl)
    '    Dim colorx As New GridMetroColors()
    '    GGC.TableOptions.ShowRowHeader = False
    '    GGC.TopLevelGroupOptions.ShowCaption = False
    '    GGC.ShowColumnHeaders = True

    '    colorx = New GridMetroColors()
    '    colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
    '    colorx.HeaderTextColor.HoverTextColor = Color.Gray
    '    colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
    '    GGC.SetMetroStyle(colorx)
    '    GGC.BorderStyle = System.Windows.Forms.BorderStyle.None

    '    '  GGC.BrowseOnly = True
    '    GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
    '    GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
    '    GGC.TableOptions.ListBoxSelectionMode = SelectionMode.None
    '    GGC.TableOptions.SelectionBackColor = Color.FromArgb(85, 170, 255)
    '    'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
    '    'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
    '    'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
    '    'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
    '    'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
    '    'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
    '    'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

    '    'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
    '    GGC.AllowProportionalColumnSizing = False
    '    GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
    '    GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
    '    'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
    '    'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

    '    GGC.Table.DefaultColumnHeaderRowHeight = 45
    '    GGC.Table.DefaultRecordRowHeight = 40
    '    GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    'End Sub

    Public Sub CargarTrabajadoresXnivel(strNivel As String, strBusqueda As String)
        Dim personaSA As New PersonaSA
        Dim dt As New DataTable()
        Try
            dt.Columns.Add("tipoDoc")
            dt.Columns.Add("dni")
            dt.Columns.Add("tipopersona")
            dt.Columns.Add("nomCompleto")
            dt.Columns.Add("cuenta")
            For Each i In personaSA.ObtenerPersonaNumDocPorNivelxDescripcion(Gempresas.IdEmpresaRuc, strNivel, strBusqueda)
                Dim dr As DataRow = dt.NewRow
                'dr(0) = i.tipodoc
                'dr(1) = i.idPersona
                'Select Case i.tipoPersona
                '    Case "N"
                '        dr(2) = "NATURAL"
                '    Case "J"
                '        dr(2) = "JURIDICA"
                'End Select
                'dr(3) = i.nombreCompleto
                'dr(4) = i.cuentaContable
                dt.Rows.Add(dr)
            Next
            dgvEntidadFinanciera.DataSource = dt
            Me.dgvEntidadFinanciera.TableOptions.ListBoxSelectionMode = SelectionMode.One
        Catch ex As Exception
            MessageBoxAdv.Show(ex.Message)
        End Try
    End Sub
#End Region

    Private Sub frmBusquedaPersonas_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmBusquedaPersonas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dispose()
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Me.Cursor = Cursors.WaitCursor
        If txtBuscarPersona.Text.Trim.Length > 0 Then
            CargarTrabajadoresXnivel("TR", txtBuscarPersona.Text.Trim)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        Dim cuentaSA As New cuentaplanContableEmpresaSA
        If Not IsNothing(dgvEntidadFinanciera.Table.CurrentRecord) Then
            With frmAportesInicio
                Dim entidadSA As New entidadSA
                Dim cajaSA As New EstadosFinancierosSA

                .dgvCompra.Table.AddNewRecord.SetCurrent()
                .dgvCompra.Table.AddNewRecord.BeginEdit()
                .dgvCompra.Table.CurrentRecord.SetValue("id", 0)

                .dgvCompra.Table.CurrentRecord.SetValue("idModulo", dgvEntidadFinanciera.Table.CurrentRecord.GetValue("dni"))
                '  Me.dgvCompra.Table.CurrentRecord.SetValue("Modulo", lstEntidades.Text)
                .dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0.0)
                .dgvCompra.Table.CurrentRecord.SetValue("importeMN", 0.0)
                .dgvCompra.Table.CurrentRecord.SetValue("importeME", 0.0)
                .dgvCompra.Table.CurrentRecord.SetValue("HaberMN", 0.0)
                .dgvCompra.Table.CurrentRecord.SetValue("HaberME", 0.0)
                .dgvCompra.Table.CurrentRecord.SetValue("tipoAsiento", "DEBE")
                .dgvCompra.Table.CurrentRecord.SetValue("tipoEx", "TR")
                .dgvCompra.Table.CurrentRecord.SetValue("moneda", "P")
                '  With cajaSA.GetUbicar_estadosFinancierosPorID(dgvEntidadFinanciera.Table.CurrentRecord.GetValue("id"))
                frmAportesInicio.dgvCompra.Table.CurrentRecord.SetValue("cuenta", "5011")
                frmAportesInicio.dgvCompra.Table.CurrentRecord.SetValue("nomCuenta", cuentaSA.ObtenerCuentaPorID(Gempresas.IdEmpresaRuc, "5011").descripcion)
                frmAportesInicio.dgvCompra.Table.CurrentRecord.SetValue("Modulo", dgvEntidadFinanciera.Table.CurrentRecord.GetValue("nomCompleto"))
                ' End With

                .dgvCompra.Table.AddNewRecord.EndEdit()
                .dgvCompra.Table.ExpandAllRecords()
            End With
        End If
    End Sub

    Private Sub dgvEntidadFinanciera_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvEntidadFinanciera.TableControlCellClick

    End Sub

    Private Sub dgvEntidadFinanciera_TableControlCellDoubleClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvEntidadFinanciera.TableControlCellDoubleClick
        Dim cuentaSA As New cuentaplanContableEmpresaSA
        If Not IsNothing(dgvEntidadFinanciera.Table.CurrentRecord) Then
            With frmAportesInicio
                Dim entidadSA As New entidadSA
                Dim cajaSA As New EstadosFinancierosSA

                .dgvCompra.Table.AddNewRecord.SetCurrent()
                .dgvCompra.Table.AddNewRecord.BeginEdit()
                .dgvCompra.Table.CurrentRecord.SetValue("id", 0)

                .dgvCompra.Table.CurrentRecord.SetValue("idModulo", dgvEntidadFinanciera.Table.CurrentRecord.GetValue("dni"))
                '  Me.dgvCompra.Table.CurrentRecord.SetValue("Modulo", lstEntidades.Text)
                .dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0.0)
                .dgvCompra.Table.CurrentRecord.SetValue("importeMN", 0.0)
                .dgvCompra.Table.CurrentRecord.SetValue("importeME", 0.0)
                .dgvCompra.Table.CurrentRecord.SetValue("HaberMN", 0.0)
                .dgvCompra.Table.CurrentRecord.SetValue("HaberME", 0.0)
                .dgvCompra.Table.CurrentRecord.SetValue("tipoAsiento", "DEBE")
                .dgvCompra.Table.CurrentRecord.SetValue("tipoEx", "TR")
                .dgvCompra.Table.CurrentRecord.SetValue("moneda", "P")
                '  With cajaSA.GetUbicar_estadosFinancierosPorID(dgvEntidadFinanciera.Table.CurrentRecord.GetValue("id"))
                frmAportesInicio.dgvCompra.Table.CurrentRecord.SetValue("cuenta", dgvEntidadFinanciera.Table.CurrentRecord.GetValue("cuenta"))
                frmAportesInicio.dgvCompra.Table.CurrentRecord.SetValue("Modulo", dgvEntidadFinanciera.Table.CurrentRecord.GetValue("nomCompleto"))
                frmAportesInicio.dgvCompra.Table.CurrentRecord.SetValue("nomCuenta", cuentaSA.ObtenerCuentaPorID(Gempresas.IdEmpresaRuc, "5011").descripcion)

                ' End With

                .dgvCompra.Table.AddNewRecord.EndEdit()
                .dgvCompra.Table.ExpandAllRecords()
            End With
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        With FrmNuevaPersona
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub
End Class