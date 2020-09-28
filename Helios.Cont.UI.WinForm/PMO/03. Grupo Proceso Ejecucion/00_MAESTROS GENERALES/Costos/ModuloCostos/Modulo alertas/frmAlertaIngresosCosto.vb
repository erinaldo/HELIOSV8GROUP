Imports Helios.Cont.Business.Entity
Imports Helios.General
'Imports Helios.Planilla.Business.Entity

Imports Helios.Cont.WCFService.ServiceAccess
'Imports Helios.Planilla.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid

Public Class frmAlertaIngresosCosto
    Inherits frmMaster

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridCFG(dgvItemsNoasignados)
        '    GetItemsNoAsignados()

        cboElemento.Visible = True
        GetProyectosGeneralesCMB()
        cboProyectoGeneral.SelectedIndex = -1
    End Sub

#Region "Métodos"
    Sub GridCFG(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        Dim colorx As New GridMetroColors()

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

        GGC.Table.DefaultColumnHeaderRowHeight = 23
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub
    Sub ComboProcesos1(intIdCostoPadre As Integer)
        Dim costoSA As New recursoCostoSA

        cboProceso.DataSource = costoSA.GetActividadProcesoByProyecto(New recursoCosto With {.idCosto = intIdCostoPadre})
        cboProceso.ValueMember = "idCosto"
        cboProceso.DisplayMember = "nombreCosto"
    End Sub


    Public Sub GetSubProyectos(idProyectoGeneral As Integer)
        Dim recursoSA As New recursoCostoSA
        Dim lista As New List(Of recursoCosto)

        lista = recursoSA.GetListaProtectosByProyGeneral(New recursoCosto With {.tipo = "HC", .idpadre = idProyectoGeneral})
        Dim query = lista.Where(Function(o) o.subtipo <> TipoCosto.HC_Mercaderia).ToList
        cboCostoDestino.DataSource = query
        cboCostoDestino.DisplayMember = "nombreCosto"
        cboCostoDestino.ValueMember = "idCosto"
    End Sub

    Private Sub GetProyectosGeneralesCMB()
        Dim costoSA As New recursoCostoSA
        cboProyectoGeneral.DisplayMember = "nombreCosto"
        cboProyectoGeneral.ValueMember = "idCosto"
        cboProyectoGeneral.DataSource = costoSA.GetListaRecursosXtipo(New recursoCosto With {.tipo = "HC", .subtipo = "PY"})
    End Sub
#End Region

    Private Sub frmAlertaIngresosCosto_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Close()
    End Sub


    Private Sub frmAlertaIngresosCosto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        GetSubProyectos(cboProyectoGeneral.SelectedValue)
        cboCostoDestino.SelectedIndex = -1
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboCostoDestino_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCostoDestino.SelectedIndexChanged
        Dim costoSA As New recursoCostoSA
        cboElemento.DataSource = Nothing
        cboProceso.DataSource = Nothing
        If cboCostoDestino.SelectedIndex > -1 Then

            Dim recursoSA As New recursoCostoSA

            Dim codValue = cboCostoDestino.SelectedValue


            If IsNumeric(codValue) Then
                codValue = Val(codValue)
                txtTipoCosto.Text = costoSA.GetCostoById(New recursoCosto With {.idCosto = codValue}).subtipo

                cboElemento.Visible = True

                cboElemento.DisplayMember = "nombreCosto"
                cboElemento.ValueMember = "idCosto"
                cboElemento.DataSource = recursoSA.GetElementosCostoByCosto(New recursoCosto With {.idCosto = codValue})

                ComboProcesos1(codValue)

            End If

        End If
        cboElemento.SelectedIndex = -1
        cboProceso.SelectedIndex = -1
    End Sub
End Class