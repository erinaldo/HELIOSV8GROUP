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
Public Class frmBusquedaCuentasFinancieras
    Inherits frmMaster

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridCFG(dgvEntidadFinanciera)
        ObtenerEF()
    End Sub

    Dim colorx As New GridMetroColors()

    Sub ObtenerEF()
        Dim estadosSA As New EstadosFinancierosSA
        Dim dt As New DataTable()

        dt.Columns.Add("entidad")
        dt.Columns.Add("tipo")
        dt.Columns.Add("numero")
        dt.Columns.Add("moneda")
        dt.Columns.Add("balance")
        dt.Columns.Add("id")

        For Each i In estadosSA.ObtenerEstadosFinancierosPorEstablecimiento(New estadosFinancieros With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.descripcion
            dr(1) = IIf(i.tipo = "BC", "Banco", "Efectivo")
            dr(2) = i.nroCtaCorriente
            dr(3) = i.codigo
            dr(4) = i.importeBalanceMN
            dr(5) = i.idestado
            dt.Rows.Add(dr)
        Next
        dgvEntidadFinanciera.DataSource = dt
        Me.dgvEntidadFinanciera.TableOptions.ListBoxSelectionMode = SelectionMode.One

    End Sub

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

    Private Sub frmBusquedaCuentasFinancieras_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmBusquedaCuentasFinancieras_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dispose()
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        Dim cuentaSA As New cuentaplanContableEmpresaSA
        If Not IsNothing(dgvEntidadFinanciera.Table.CurrentRecord) Then
            'Dim c As New RecuperarCarteras
            'Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
            'datos.Clear()

            'c.ID = dgvEntidadFinanciera.Table.CurrentRecord.GetValue("id")
            'c.NomEvento = dgvEntidadFinanciera.Table.CurrentRecord.GetValue("entidad")
            'datos.Add(c)
            'Dispose()
            With frmAportesInicio
                Dim entidadSA As New entidadSA
                Dim cajaSA As New EstadosFinancierosSA

                .dgvCompra.Table.AddNewRecord.SetCurrent()
                .dgvCompra.Table.AddNewRecord.BeginEdit()
                .dgvCompra.Table.CurrentRecord.SetValue("id", 0)

                .dgvCompra.Table.CurrentRecord.SetValue("idModulo", dgvEntidadFinanciera.Table.CurrentRecord.GetValue("id"))
                '  Me.dgvCompra.Table.CurrentRecord.SetValue("Modulo", lstEntidades.Text)
                .dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0.0)
                .dgvCompra.Table.CurrentRecord.SetValue("importeMN", 0.0)
                .dgvCompra.Table.CurrentRecord.SetValue("importeME", 0.0)
                .dgvCompra.Table.CurrentRecord.SetValue("HaberMN", 0.0)
                .dgvCompra.Table.CurrentRecord.SetValue("HaberME", 0.0)
                .dgvCompra.Table.CurrentRecord.SetValue("tipoAsiento", "DEBE")
                .dgvCompra.Table.CurrentRecord.SetValue("tipoEx", "CA")
                .dgvCompra.Table.CurrentRecord.SetValue("moneda", dgvEntidadFinanciera.Table.CurrentRecord.GetValue("moneda"))
                With cajaSA.GetUbicar_estadosFinancierosPorID(dgvEntidadFinanciera.Table.CurrentRecord.GetValue("id"))
                    frmAportesInicio.dgvCompra.Table.CurrentRecord.SetValue("cuenta", .cuenta)
                    frmAportesInicio.dgvCompra.Table.CurrentRecord.SetValue("Modulo", .descripcion)
                    frmAportesInicio.dgvCompra.Table.CurrentRecord.SetValue("nomCuenta", cuentaSA.ObtenerCuentaPorID(Gempresas.IdEmpresaRuc, .cuenta).descripcion)
                End With

                .dgvCompra.Table.AddNewRecord.EndEdit()
                .dgvCompra.Table.ExpandAllRecords()
            End With
        End If
    End Sub

    Private Sub dgvEntidadFinanciera_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvEntidadFinanciera.TableControlCellClick

    End Sub
    '///////////
    Private Sub dgvEntidadFinanciera_TableControlCellDoubleClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvEntidadFinanciera.TableControlCellDoubleClick
        Dim cuentaSA As New cuentaplanContableEmpresaSA
        If Not IsNothing(dgvEntidadFinanciera.Table.CurrentRecord) Then
            'Dim c As New RecuperarCarteras
            'Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
            'datos.Clear()

            'c.ID = dgvEntidadFinanciera.Table.CurrentRecord.GetValue("id")
            'c.NomEvento = dgvEntidadFinanciera.Table.CurrentRecord.GetValue("entidad")
            'datos.Add(c)
            'Dispose()
            With frmAportesInicio
                Dim entidadSA As New entidadSA
                Dim cajaSA As New EstadosFinancierosSA

                .dgvCompra.Table.AddNewRecord.SetCurrent()
                .dgvCompra.Table.AddNewRecord.BeginEdit()
                .dgvCompra.Table.CurrentRecord.SetValue("id", 0)

                .dgvCompra.Table.CurrentRecord.SetValue("idModulo", dgvEntidadFinanciera.Table.CurrentRecord.GetValue("id"))
                '  Me.dgvCompra.Table.CurrentRecord.SetValue("Modulo", lstEntidades.Text)
                .dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0.0)
                .dgvCompra.Table.CurrentRecord.SetValue("importeMN", 0.0)
                .dgvCompra.Table.CurrentRecord.SetValue("importeME", 0.0)
                .dgvCompra.Table.CurrentRecord.SetValue("HaberMN", 0.0)
                .dgvCompra.Table.CurrentRecord.SetValue("HaberME", 0.0)
                .dgvCompra.Table.CurrentRecord.SetValue("tipoAsiento", "DEBE")
                .dgvCompra.Table.CurrentRecord.SetValue("tipoEx", "CA")
                .dgvCompra.Table.CurrentRecord.SetValue("moneda", dgvEntidadFinanciera.Table.CurrentRecord.GetValue("moneda"))
                With cajaSA.GetUbicar_estadosFinancierosPorID(dgvEntidadFinanciera.Table.CurrentRecord.GetValue("id"))
                    frmAportesInicio.dgvCompra.Table.CurrentRecord.SetValue("cuenta", .cuenta)
                    frmAportesInicio.dgvCompra.Table.CurrentRecord.SetValue("Modulo", .descripcion)
                    frmAportesInicio.dgvCompra.Table.CurrentRecord.SetValue("nomCuenta", cuentaSA.ObtenerCuentaPorID(Gempresas.IdEmpresaRuc, .cuenta).descripcion)
                End With

                .dgvCompra.Table.AddNewRecord.EndEdit()
                .dgvCompra.Table.ExpandAllRecords()
            End With
        End If
    End Sub

    Private Sub dgvEntidadFinanciera_TableControlCurrentCellControlDoubleClick(sender As Object, e As GridTableControlControlEventArgs) Handles dgvEntidadFinanciera.TableControlCurrentCellControlDoubleClick

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Cursor = Cursors.WaitCursor
        With frmModalCaja
            .strEstadoManipulacion = ENTITY_ACTIONS.INSERT
            .ObtenerMascaraMercaderia()
            .txtCuentaID.Text = "101"
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            ObtenerEF()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub


End Class