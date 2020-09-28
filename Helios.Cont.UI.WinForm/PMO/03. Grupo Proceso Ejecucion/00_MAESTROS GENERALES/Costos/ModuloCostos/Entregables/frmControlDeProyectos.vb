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

Public Class frmControlDeProyectos

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        'GetProyectosGeneralesCMB()
        'GastosAsignados()
        GridCFG(dgvEntregables)
        ' Add any initialization after the InitializeComponent() call.

    End Sub


#Region "Metodos"

    'Public Sub GetItemsNoAsignadosInventarioxEntregable(idEntregable As Integer)
    '    Dim compraSA As New DocumentoCompraSA
    '    Dim dt As New DataTable

    '    dt.Columns.Add("idDocumento")
    '    dt.Columns.Add("secuencia")
    '    dt.Columns.Add("FechaDoc")
    '    dt.Columns.Add("TipoDoc")
    '    dt.Columns.Add("Serie")
    '    dt.Columns.Add("NumDoc")
    '    dt.Columns.Add("Moneda")
    '    dt.Columns.Add("idItem")
    '    dt.Columns.Add("descripcionItem")
    '    dt.Columns.Add("tipoExistencia")
    '    dt.Columns.Add("destino")
    '    dt.Columns.Add("unidad1")
    '    dt.Columns.Add("monto1")
    '    dt.Columns.Add("montokardex")
    '    dt.Columns.Add("montokardexUS")
    '    dt.Columns.Add("TipoOperacion")
    '    dt.Columns.Add("idPadreDTCompra")
    '    dt.Columns.Add("idCosto")
    '    dt.Columns.Add("NombreProyectoGeneral")
    '    dt.Columns.Add("idSubProyecto")
    '    dt.Columns.Add("Subproyecto")
    '    dt.Columns.Add("idEDT")
    '    dt.Columns.Add("edt")
    '    dt.Columns.Add("tipoCosto")
    '    dt.Columns.Add("idElemento")
    '    dt.Columns.Add("Elemento")
    '    dt.Columns.Add("abrev")
    '    dt.Columns.Add("fechaTrabajo")
    '    For Each i In compraSA.ListaRecursosCostoInventarioEntregables(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento,
    '                                                                                               .fechaContable = PeriodoGeneral, .idCosto = idEntregable})
    '        Dim dr As DataRow = dt.NewRow
    '        dr(0) = i.idDocumento
    '        dr(1) = i.secuencia
    '        dr(2) = i.FechaDoc
    '        dr(3) = i.TipoDoc
    '        dr(4) = i.Serie
    '        dr(5) = i.NumDoc
    '        dr(6) = i.Moneda
    '        dr(7) = i.idItem
    '        dr(8) = i.descripcionItem
    '        dr(9) = i.tipoExistencia

    '        dr(10) = i.destino
    '        dr(11) = i.unidad1
    '        dr(12) = i.monto1
    '        dr(13) = i.montokardex
    '        dr(14) = i.montokardexUS
    '        dr(15) = i.TipoOperacion
    '        dr(16) = i.idPadreDTCompra
    '        dr(17) = i.idCosto
    '        dr(18) = i.NombreProyectoGeneral
    '        dr(19) = Nothing
    '        dr(20) = Nothing
    '        dr(21) = i.idCosto
    '        dr(22) = i.NombreProyectoGeneral
    '        dr(23) = Nothing
    '        dr(24) = Nothing
    '        dr(25) = Nothing
    '        dr(26) = "HC"
    '        dr(27) = DateTime.Now
    '        dt.Rows.Add(dr)
    '    Next
    '    GridGroupingControl1.DataSource = dt ' compraSA.ListaRecursosCostoInventario(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento,
    '    '.fechaContable = PeriodoGeneral})
    '    GridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended


    '    GridGroupingControl1.TableDescriptor.Columns("idPadreDTCompra").Width = 0
    '    GridGroupingControl1.TableDescriptor.Columns("idCosto").Width = 0
    '    GridGroupingControl1.TableDescriptor.Columns("NombreProyectoGeneral").Width = 0
    '    GridGroupingControl1.TableDescriptor.Columns("idSubProyecto").Width = 0
    '    GridGroupingControl1.TableDescriptor.Columns("Subproyecto").Width = 0
    '    GridGroupingControl1.TableDescriptor.Columns("idEDT").Width = 70


    '    GridGroupingControl1.TableDescriptor.Columns("tipoCosto").Width = 0
    '    GridGroupingControl1.TableDescriptor.Columns("idElemento").Width = 0
    '    GridGroupingControl1.TableDescriptor.Columns("Elemento").Width = 0



    'End Sub



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

    'Public Sub GastosAsignados()
    '    Dim documentocompra As New DocumentoCompraSA
    '    Dim cantidad As Integer = 0
    '    cantidad = documentocompra.ConteoRecursosNoCosteados(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento,
    '                                                                                               .fechaContable = PeriodoGeneral})
    '    txtCosNoAsg.Text = cantidad
    'End Sub




    Sub EntregablesPorEstado()
        Dim costoSA As New recursoCostoSA
        Dim costo As New List(Of recursoCosto)
        '     If Not IsNothing(cboSubProyecto.SelectedValue) Then
        costo = costoSA.GetEntregablesXProyecto(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)



        Dim dt As New DataTable
        dt.Columns.Add("idProyecto")
        dt.Columns.Add("Proyecto")
        dt.Columns.Add("idSubProyecto")
        dt.Columns.Add("Subproyecto")

        dt.Columns.Add("idEntregable")
        dt.Columns.Add("Entregable")

        dt.Columns.Add("compras")
        dt.Columns.Add("inventario")
        dt.Columns.Add("finanzas")
        dt.Columns.Add("libro")

        dt.Columns.Add("estado")

        dt.Columns.Add("subtipo")

        dt.Columns.Add("cuenta")

        For Each i In costo
            Dim dr As DataRow = dt.NewRow

            dr(0) = i.IdProyecto
            dr(1) = i.nombreProyecto
            dr(2) = i.IdSubProyecto
            dr(3) = i.nombreSubProyecto

            dr(4) = i.idEntregable
            dr(5) = i.nombreEntregable
            dr(6) = i.Conteocompras
            dr(7) = i.Conteoinventario
            dr(8) = i.Conteofinanza
            dr(9) = i.Conteolibro

            Select Case i.estado
                Case "PRO"
                    dr(10) = "EN PROCESO"
                Case "SUS"
                    dr(10) = "SUSPENDIDO"
                Case "EJE"
                    dr(10) = "EJECUTADO"
                Case "COS"
                    dr(10) = "PROCESO COSTEADO"
                Case "VAL"
                    dr(10) = "PROCESO VALORIZADO"
            End Select
            dr(11) = i.subtipo

            dr(12) = i.nombreCuenta

            dt.Rows.Add(dr)
        Next
        dgvEntregables.DataSource = dt
        '   End If
    End Sub


#End Region

    Private Sub frmControlEstadoEntregables_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cboProyectoGeneral_Click(sender As Object, e As EventArgs)

    End Sub




    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click

        EntregablesPorEstado()




    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs)

        'GetItemsNoAsignadosInventarioxEntregable(cboEntregable.SelectedValue)

    End Sub

    Private Sub cboEntregable_Click(sender As Object, e As EventArgs)

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
                    Case 7
                        If dgvEntregables.Table.CurrentRecord.GetValue("estado") = "EN PROCESO" Then
                            If dgvEntregables.Table.CurrentRecord.GetValue("compras") > 0 Then

                                Me.Cursor = Cursors.WaitCursor

                                Dim f As New frmCosteoCompras



                                'f.txtProyectoGeneral.Text = dgvEntregables.Table.CurrentRecord.GetValue("Proyecto")
                                'f.txtSubProyecto.Text = dgvEntregables.Table.CurrentRecord.GetValue("Subproyecto")
                                'f.txtEntregable.Text = dgvEntregables.Table.CurrentRecord.GetValue("Entregable")
                                'f.txtidEntregable.Text = dgvEntregables.Table.CurrentRecord.GetValue("idEntregable")
                                f.txtTipoCosteo.Text = "HC"
                                f.Size = New Size(1240, 550)
                                f.StartPosition = FormStartPosition.CenterParent
                                f.ShowDialog()

                                EntregablesPorEstado()

                                Me.Cursor = Cursors.Arrow
                            End If
                        Else
                            MessageBox.Show("El Entregable se encuenta Costeado o Ejecutado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.Cursor = Cursors.Arrow
                        End If
                    Case 8


                    Case 9
                        If dgvEntregables.Table.CurrentRecord.GetValue("estado") = "EN PROCESO" Then
                            If dgvEntregables.Table.CurrentRecord.GetValue("finanzas") > 0 Then

                                Me.Cursor = Cursors.WaitCursor

                                Dim f As New frmCosteoFinanzas

                                f.txtProyectoGeneral.Text = dgvEntregables.Table.CurrentRecord.GetValue("Proyecto")
                                f.txtSubProyecto.Text = dgvEntregables.Table.CurrentRecord.GetValue("Subproyecto")
                                f.txtEntregable.Text = dgvEntregables.Table.CurrentRecord.GetValue("Entregable")
                                f.txtidEntregable.Text = dgvEntregables.Table.CurrentRecord.GetValue("idEntregable")
                                f.txtTipoCosteo.Text = "HC"
                                f.Size = New Size(1240, 550)
                                f.StartPosition = FormStartPosition.CenterParent
                                f.ShowDialog()

                                EntregablesPorEstado()

                                Me.Cursor = Cursors.Arrow
                            End If
                        Else
                            MessageBox.Show("El Entregable se encuenta Costeado o Ejecutado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.Cursor = Cursors.Arrow
                        End If
                    Case 10

                        If dgvEntregables.Table.CurrentRecord.GetValue("estado") = "EN PROCESO" Then
                            If dgvEntregables.Table.CurrentRecord.GetValue("libro") > 0 Then

                                Me.Cursor = Cursors.WaitCursor

                                Dim f As New frmCosteoLibro

                                f.txtProyectoGeneral.Text = dgvEntregables.Table.CurrentRecord.GetValue("Proyecto")
                                f.txtSubProyecto.Text = dgvEntregables.Table.CurrentRecord.GetValue("Subproyecto")
                                f.txtEntregable.Text = dgvEntregables.Table.CurrentRecord.GetValue("Entregable")
                                f.txtidEntregable.Text = dgvEntregables.Table.CurrentRecord.GetValue("idEntregable")
                                f.txtTipoCosteo.Text = "HC"
                                f.Size = New Size(1240, 550)
                                f.StartPosition = FormStartPosition.CenterParent
                                f.ShowDialog()

                                EntregablesPorEstado()

                                Me.Cursor = Cursors.Arrow
                            End If
                        Else
                            MessageBox.Show("El Entregable se encuenta Costeado o Ejecutado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

    Private Sub dgvEntregables_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvEntregables.QueryCellStyleInfo

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click

        If dgvEntregables.Table.Records.Count > 0 Then
            If Not IsNothing(Me.dgvEntregables.Table.CurrentRecord) Then


                If dgvEntregables.Table.CurrentRecord.GetValue("estado") = "EN PROCESO" Or dgvEntregables.Table.CurrentRecord.GetValue("estado") = "PROCESO VALORIZADO" Then
                    'Dim idAlmacen As Integer = dgvEntregables.Table.CurrentRecord.GetValue("idAlmacen")
                    'Dim idItem As Integer = dgvEntregables.Table.CurrentRecord.GetValue("idItem")
                    'Dim cantidad As Decimal = dgvEntregables.Table.CurrentRecord.GetValue("cantEnv")


                    ' Dim f As New frmOtrasSalidasDeProduccion
                    Dim f As New frmSalidasAlConsumoCosto

                    'f.RecursoEnvio = RecursoEnvio
                    'f.listaAsientoEnvio = listaAsientoEnvio
                    ' f.CargarDetalleAutomatico(idAlmacen, idItem, cantidad)
                    f.Label1.Text = "CONSUMO PARA EL ENTREGABLE:"
                    f.txtEntregable.Text = dgvEntregables.Table.CurrentRecord.GetValue("Entregable")
                    f.txtidEntregable.Text = dgvEntregables.Table.CurrentRecord.GetValue("idEntregable")
                    f.txtCuentaCosto.Text = dgvEntregables.Table.CurrentRecord.GetValue("cuenta")
                    f.txtTipoCosto.Text = "HC"
                    f.lbltipoentregable.Text = dgvEntregables.Table.CurrentRecord.GetValue("subtipo")
                    f.lblPerido.Text = PeriodoGeneral
                    f.GroupBox2.Visible = True
                    f.cboOperacion.SelectedValue = "10.01"


                    '.rbCosto.Checked = True
                    f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()


                    ' GetItemsNoAsignadosInventarioxEntregable(txtidEntregable.Text)
                    'If txtTipoCosteo.Text = "HC" Then
                    '    GetItemsNoAsignadosInventarioxEntregable(txtidEntregable.Text)

                    'ElseIf txtTipoCosteo.Text = "HG" Then
                    '    GastosInventarioxEntregable(txtidEntregable.Text)
                    'End If
                Else
                    MessageBox.Show("El Entregable se encuenta Costeado o Ejecutado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If


            Else
                MessageBox.Show("No ha seleccionado los items!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("No existen items en costos por el momento!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If




    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click

        If dgvEntregables.Table.Records.Count > 0 Then
            If Not IsNothing(Me.dgvEntregables.Table.CurrentRecord) Then
          


        If dgvEntregables.Table.CurrentRecord.GetValue("estado") = "EN PROCESO" Or dgvEntregables.Table.CurrentRecord.GetValue("estado") = "PROCESO VALORIZADO" Then
            'If dgvEntregables.Table.CurrentRecord.GetValue("compras") > 0 Then

            Me.Cursor = Cursors.WaitCursor

            Dim f As New frmCosteoCompras



            f.txtProyectoGeneral.Text = dgvEntregables.Table.CurrentRecord.GetValue("Proyecto")
            f.txtSubProyecto.Text = dgvEntregables.Table.CurrentRecord.GetValue("Subproyecto")
            f.txtEntregable.Text = dgvEntregables.Table.CurrentRecord.GetValue("Entregable")
            f.txtidEntregable.Text = dgvEntregables.Table.CurrentRecord.GetValue("idEntregable")
            f.txtTipoCosteo.Text = "HC"
            f.lblTipoProyecto.Text = dgvEntregables.Table.CurrentRecord.GetValue("subtipo")
            f.Size = New Size(1240, 550)
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()

            ' EntregablesPorEstado()

            Me.Cursor = Cursors.Arrow
            'End If
        Else
            MessageBox.Show("El Entregable se encuenta Costeado o Ejecutado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Cursor = Cursors.Arrow
                End If
            Else
                MessageBox.Show("No ha seleccionado los items!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("No existen items en costos por el momento!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        If dgvEntregables.Table.Records.Count > 0 Then
            If Not IsNothing(Me.dgvEntregables.Table.CurrentRecord) Then

                If dgvEntregables.Table.CurrentRecord.GetValue("estado") = "EN PROCESO" Then
                    'If dgvEntregables.Table.CurrentRecord.GetValue("libro") > 0 Then

                    Me.Cursor = Cursors.WaitCursor

                    Dim f As New frmCosteoLibro

                    f.txtProyectoGeneral.Text = dgvEntregables.Table.CurrentRecord.GetValue("Proyecto")
                    f.txtSubProyecto.Text = dgvEntregables.Table.CurrentRecord.GetValue("Subproyecto")
                    f.txtEntregable.Text = dgvEntregables.Table.CurrentRecord.GetValue("Entregable")
                    f.txtidEntregable.Text = dgvEntregables.Table.CurrentRecord.GetValue("idEntregable")
                    f.txtTipoCosteo.Text = "HC"
                    f.Size = New Size(1240, 550)
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()

                    EntregablesPorEstado()

                    Me.Cursor = Cursors.Arrow
                    'End If
                Else
                    MessageBox.Show("El Entregable se encuenta Costeado o Ejecutado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.Cursor = Cursors.Arrow
                End If
            Else
                MessageBox.Show("No ha seleccionado los items!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("No existen items en costos por el momento!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        If dgvEntregables.Table.CurrentRecord.GetValue("estado") = "EN PROCESO" Then


            Me.Cursor = Cursors.WaitCursor

            Dim f As New frmCosteoFinanzas

            f.txtProyectoGeneral.Text = dgvEntregables.Table.CurrentRecord.GetValue("Proyecto")
            f.txtSubProyecto.Text = dgvEntregables.Table.CurrentRecord.GetValue("Subproyecto")
            f.txtEntregable.Text = dgvEntregables.Table.CurrentRecord.GetValue("Entregable")
            f.txtidEntregable.Text = dgvEntregables.Table.CurrentRecord.GetValue("idEntregable")
            f.txtTipoCosteo.Text = "HC"
            f.Size = New Size(1240, 550)
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()

            EntregablesPorEstado()

            Me.Cursor = Cursors.Arrow

        Else
        MessageBox.Show("El Entregable se encuenta Costeado o Ejecutado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Me.Cursor = Cursors.Arrow
        End If
    End Sub
End Class