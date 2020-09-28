Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping

Public Class frmControlGastos
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        'GetProyectosGeneralesCMB()
        'GastosAsignados()
        GridCFG(dgvEntregables)
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

#Region "Metodos"

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

        'Me.gridGroupingControl1.BrowseOnly = true
        'Me.gridGroupingControl1.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
        grid.TableOptions.SelectionBackColor = Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        grid.AllowProportionalColumnSizing = False
        grid.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        grid.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        grid.Table.DefaultColumnHeaderRowHeight = 25
        grid.Table.DefaultRecordRowHeight = 20
        grid.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Sub GastosXCostear()
        Dim costoSA As New recursoCostoSA
        Dim costo As New List(Of recursoCosto)
        '     If Not IsNothing(cboSubProyecto.SelectedValue) Then
        costo = costoSA.GetGastosTipoAll(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)



        Dim dt As New DataTable


        dt.Columns.Add("tipoGasto")
        dt.Columns.Add("idGasto")
        dt.Columns.Add("Gasto")

        dt.Columns.Add("compras")
        dt.Columns.Add("inventario")
        dt.Columns.Add("finanzas")
        dt.Columns.Add("libro")

        dt.Columns.Add("cuenta")



        For Each i In costo
            Dim dr As DataRow = dt.NewRow


            Select Case i.subtipo
                Case "GADM"
                    dr(0) = "GASTO ADMINISTRATIVO"
                Case "GAVT"
                    dr(0) = "GASTO DE VENTAS"
                Case "FIN"
                    dr(0) = "GASTO FINANCIERO"
            End Select



            'dr(0) = i.subtipo
            dr(1) = i.idEntregable
            dr(2) = i.nombreEntregable
            dr(3) = i.Conteocompras
            dr(4) = i.Conteoinventario
            dr(5) = i.Conteofinanza
            dr(6) = i.Conteolibro
            dr(7) = i.nombreCuenta




            dt.Rows.Add(dr)
        Next
        dgvEntregables.DataSource = dt
        '   End If
    End Sub
#End Region
    Private Sub frmControlGastos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        GastosXCostear()
    End Sub

    Private Sub dgvEntregables_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvEntregables.TableControlCellClick

    End Sub

    Private Sub dgvEntregables_TableControlCurrentCellControlDoubleClick(sender As Object, e As GridTableControlControlEventArgs) Handles dgvEntregables.TableControlCurrentCellControlDoubleClick
        Dim cc As GridCurrentCell = Me.dgvEntregables.TableControl.CurrentCell
        cc.ConfirmChanges()
        Me.Cursor = Cursors.WaitCursor
        Try
            If Not IsNothing(cc) Then
                Select Case cc.ColIndex
                    'Case 11
                    Case 4
                        'If dgvEntregables.Table.CurrentRecord.GetValue("compras") > 0 Then

                        '    Me.Cursor = Cursors.WaitCursor

                        '    Dim f As New frmCosteoCompras

                        '    f.Label5.Text = "Gasto General"

                        '    f.txtProyectoGeneral.Text = dgvEntregables.Table.CurrentRecord.GetValue("Gasto")
                        '    f.txtidEntregable.Text = dgvEntregables.Table.CurrentRecord.GetValue("idGasto")

                        '    f.Label3.Visible = False
                        '    f.txtSubProyecto.Visible = False

                        '    f.Label4.Visible = False
                        '    f.txtEntregable.Visible = False
                        '    f.txtTipoCosteo.Text = "HG"
                        '    f.Size = New Size(1240, 550)
                        '    f.StartPosition = FormStartPosition.CenterParent
                        '    f.ShowDialog()

                        '    GastosXCostear()

                        '    Me.Cursor = Cursors.Arrow
                        'End If

                    Case 5


                    Case 6

                        If dgvEntregables.Table.CurrentRecord.GetValue("finanzas") > 0 Then

                            Me.Cursor = Cursors.WaitCursor

                            Dim f As New frmCosteoFinanzas

                            f.Label5.Text = "Gasto General"

                            f.txtProyectoGeneral.Text = dgvEntregables.Table.CurrentRecord.GetValue("Gasto")
                            f.txtidEntregable.Text = dgvEntregables.Table.CurrentRecord.GetValue("idGasto")

                            f.Label3.Visible = False
                            f.txtSubProyecto.Visible = False

                            f.Label4.Visible = False
                            f.txtEntregable.Visible = False

                            f.txtTipoCosteo.Text = "HG"
                            f.Size = New Size(1240, 550)
                            f.StartPosition = FormStartPosition.CenterParent
                            f.ShowDialog()

                            GastosXCostear()

                            Me.Cursor = Cursors.Arrow
                        End If

                    Case 7


                        If dgvEntregables.Table.CurrentRecord.GetValue("libro") > 0 Then

                            Me.Cursor = Cursors.WaitCursor

                            Dim f As New frmCosteoLibro

                            f.Label5.Text = "Gasto General"

                            f.txtProyectoGeneral.Text = dgvEntregables.Table.CurrentRecord.GetValue("Gasto")
                            f.txtidEntregable.Text = dgvEntregables.Table.CurrentRecord.GetValue("idGasto")

                            f.Label3.Visible = False
                            f.txtSubProyecto.Visible = False

                            f.Label4.Visible = False
                            f.txtEntregable.Visible = False

                            f.txtTipoCosteo.Text = "HG"
                            f.Size = New Size(1240, 550)
                            f.StartPosition = FormStartPosition.CenterParent
                            f.ShowDialog()

                            GastosXCostear()

                            Me.Cursor = Cursors.Arrow
                        End If

                End Select
            End If
        Catch ex As Exception
            'lblEstado.Text = ex.Message
            'PanelError.Visible = True
            'Timer1.Enabled = True
            'TiempoEjecutar(10)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        If dgvEntregables.Table.Records.Count > 0 Then
            If Not IsNothing(Me.dgvEntregables.Table.CurrentRecord) Then

            



        'Dim f As New frmOtrasSalidasDeProduccion
        Dim f As New frmSalidasAlConsumoCosto

        f.Label1.Text = "CONSUMO PARA EL ENTREGABLE:"
        f.txtEntregable.Text = dgvEntregables.Table.CurrentRecord.GetValue("Gasto")
        f.txtidEntregable.Text = dgvEntregables.Table.CurrentRecord.GetValue("idGasto")
        f.txtCuentaCosto.Text = dgvEntregables.Table.CurrentRecord.GetValue("cuenta")
        f.txtTipoCosto.Text = "HG"
        f.lblPerido.Text = PeriodoGeneral
        f.GroupBox2.Visible = True
                f.cboOperacion.SelectedValue = "10.01"
                f.Label13.Visible = True
                f.cboMotivoCosto.Visible = True



        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()


            Else
                MessageBox.Show("No ha seleccionado los items!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("No existen items en gastos por el momento!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        If Not IsNothing(Me.dgvEntregables.Table.CurrentRecord) Then

            Me.Cursor = Cursors.WaitCursor

            Dim f As New frmGastosCompras

            f.Label5.Text = "Gasto General"

            f.txtProyectoGeneral.Text = dgvEntregables.Table.CurrentRecord.GetValue("Gasto")
            f.txtidEntregable.Text = dgvEntregables.Table.CurrentRecord.GetValue("idGasto")
            f.txtCuentaCosto.Text = dgvEntregables.Table.CurrentRecord.GetValue("cuenta")

            f.Label3.Visible = False
            f.txtSubProyecto.Visible = False

            f.Label4.Visible = False
            f.txtEntregable.Visible = False
            f.txtTipoCosteo.Text = "HG"

            f.Size = New Size(1240, 550)
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()

            GastosXCostear()

            Me.Cursor = Cursors.Arrow
        Else
            MessageBox.Show("No ha seleccionado ningun Gasto!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        If Not IsNothing(Me.dgvEntregables.Table.CurrentRecord) Then
            Me.Cursor = Cursors.WaitCursor

            Dim f As New frmGastosLibro

            f.Label5.Text = "Gasto General"

            f.txtProyectoGeneral.Text = dgvEntregables.Table.CurrentRecord.GetValue("Gasto")
            f.txtidEntregable.Text = dgvEntregables.Table.CurrentRecord.GetValue("idGasto")
            f.txtCuentaGasto.Text = dgvEntregables.Table.CurrentRecord.GetValue("cuenta")
            f.Label3.Visible = False
            f.txtSubProyecto.Visible = False

            f.Label4.Visible = False
            f.txtEntregable.Visible = False

            f.txtTipoCosteo.Text = "HG"
            f.Size = New Size(1240, 550)
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()

            GastosXCostear()

            Me.Cursor = Cursors.Arrow
        Else
            MessageBox.Show("No ha seleccionado ningun Gasto!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        If Not IsNothing(Me.dgvEntregables.Table.CurrentRecord) Then
            Me.Cursor = Cursors.WaitCursor

            Dim f As New frmCosteoFinanzas

            f.Label5.Text = "Gasto General"

            f.txtProyectoGeneral.Text = dgvEntregables.Table.CurrentRecord.GetValue("Gasto")
            f.txtidEntregable.Text = dgvEntregables.Table.CurrentRecord.GetValue("idGasto")

            f.Label3.Visible = False
            f.txtSubProyecto.Visible = False

            f.Label4.Visible = False
            f.txtEntregable.Visible = False

            f.txtTipoCosteo.Text = "HG"
            f.Size = New Size(1240, 550)
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()

            GastosXCostear()

            Me.Cursor = Cursors.Arrow


        Else
            MessageBox.Show("No ha seleccionado ningun Gasto!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
End Class