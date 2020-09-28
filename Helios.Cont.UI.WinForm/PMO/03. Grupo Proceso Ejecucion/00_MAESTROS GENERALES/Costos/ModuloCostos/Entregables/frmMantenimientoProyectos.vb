Imports Syncfusion.Windows.Forms.Tools
Imports Helios.Cont.Business.Entity
Imports Helios.General
'Imports Helios.Planilla.Business.Entity

Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
'Imports Helios.Planilla.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports Syncfusion.GridHelperClasses

Public Class frmMantenimientoProyectos


    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        GridCFG(dgvEntregables)
        GetProyectosGeneralesCMB()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.DataSource = ListaDeMeses()
        cboMesCompra.SelectedValue = MesGeneral

        txtAnioCompra.Text = AnioGeneral

    End Sub

#Region "Metodos"





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


    Sub EntregablesPorSubProy(idSubProy As Integer, periodo As String)
        Dim costoSA As New recursoCostoSA
        Dim costo As New List(Of recursoCosto)
        Dim dias
        Dim diasH
        Dim diasA
        '     If Not IsNothing(cboSubProyecto.SelectedValue) Then
        costo = costoSA.GetEntregablesXSubProy(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, idSubProy, periodo)



        Dim dt As New DataTable
        dt.Columns.Add("idProyecto")
        dt.Columns.Add("Proyecto")
        dt.Columns.Add("idSubProyecto")
        dt.Columns.Add("Subproyecto")

        dt.Columns.Add("idEntregable")
        dt.Columns.Add("Entregable")

        dt.Columns.Add("tipo")

        dt.Columns.Add("tipoDescip")

        dt.Columns.Add("estado")

        dt.Columns.Add("cantSub")
        dt.Columns.Add("um")
        dt.Columns.Add("cant")

        dt.Columns.Add("costoUnit")

        dt.Columns.Add("fechaIni")
        dt.Columns.Add("fechaFin")

        dt.Columns.Add("dias")
        dt.Columns.Add("habiles")
        dt.Columns.Add("atrazos")
        dt.Columns.Add("total")
        dt.Columns.Add("idItem")

        dt.Columns.Add("cuenta")







        For Each i In costo
            Dim dr As DataRow = dt.NewRow

            dr(0) = ""
            dr(1) = ""
            dr(2) = ""
            dr(3) = ""

            dr(4) = i.idEntregable
            dr(5) = i.nombreEntregable

            dr(6) = i.subtipo



            If i.subtipo = "CPP" Then
                dr(7) = "HC -PROCESOS PRODUCTIVOS A VALORES HISTORICOS"
            ElseIf i.subtipo = "CPV" Then
                dr(7) = "HC -COSTOS POR VALORACION"
            ElseIf i.subtipo = "CPE" Then
                dr(7) = "HC -PROCESO PRODUCTIVO A VALORES ESTANDAR"
            
            End If


            Select Case i.estado
                Case "PRO"
                    dr(8) = "EN PROCESO"
                Case "SUS"
                    dr(8) = "SUSPENDIDO"

                Case "EJE"
                    dr(8) = "EJECUTADO"
                Case "COS"
                    dr(8) = "PROCESO COSTEADO"
                Case "VAL"
                    dr(8) = "PROCESO VALORIZADO"
                    
            End Select

            dr(9) = i.nroSubProductos

            dr(10) = i.unidad
            dr(11) = i.cantidad
            dr(12) = i.precUnit

            dr(13) = CDate(i.inicio).ToString("dd/MM/yyyy")
            dr(14) = CDate(i.finaliza).ToString("dd/MM/yyyy")

            ' calculo de dias habiles atrasos por de


            dias = DateDiff("d", i.inicio, i.finaliza)

            If DateTime.Now.Date >= i.inicio And DateTime.Now.Date <= i.finaliza Then
                diasH = DateDiff("d", DateTime.Now.Date, i.finaliza)
            Else
                diasH = 0
            End If

            If DateTime.Now.Date > i.finaliza Then
                diasA = DateDiff("d", DateTime.Now.Date, i.finaliza)
            Else
                diasA = 0
            End If

            dr(15) = dias
            dr(16) = diasH
            dr(17) = diasA
            dr(18) = i.TotalMN
            dr(19) = i.codigo

            dr(20) = i.nombreCuenta

            dt.Rows.Add(dr)
        Next
        dgvEntregables.DataSource = dt



        dgvEntregables.TableDescriptor.Columns("idProyecto").Width = 0
        dgvEntregables.TableDescriptor.Columns("Proyecto").Width = 0
        dgvEntregables.TableDescriptor.Columns("idSubProyecto").Width = 0
        dgvEntregables.TableDescriptor.Columns("Subproyecto").Width = 0

        '   End If
    End Sub


    Sub EntregablesPorEstado()
        Dim costoSA As New recursoCostoSA
        Dim costo As New List(Of recursoCosto)
        Dim dias
        Dim diasH
        Dim diasA
        '     If Not IsNothing(cboSubProyecto.SelectedValue) Then
        costo = costoSA.GetProyectosAll(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)

        Dim dt As New DataTable
        dt.Columns.Add("idProyecto")
        dt.Columns.Add("Proyecto")
        dt.Columns.Add("idSubProyecto")
        dt.Columns.Add("Subproyecto")

        dt.Columns.Add("idEntregable")
        dt.Columns.Add("Entregable")

        dt.Columns.Add("tipo")

        dt.Columns.Add("tipoDescip")

        dt.Columns.Add("estado")
        dt.Columns.Add("cantSub")



        dt.Columns.Add("um")
        dt.Columns.Add("cant")

        dt.Columns.Add("costoUnit")

        dt.Columns.Add("fechaIni")
        dt.Columns.Add("fechaFin")


        dt.Columns.Add("dias")
        dt.Columns.Add("habiles")
        dt.Columns.Add("atrazos")
        dt.Columns.Add("total")

        dt.Columns.Add("idItem")

        dt.Columns.Add("cuenta")






        For Each i In costo
            Dim dr As DataRow = dt.NewRow

            dr(0) = i.idProyecto
            dr(1) = i.nombreProyecto
            dr(2) = i.idSubProyecto
            dr(3) = i.nombreSubProyecto

            dr(4) = i.idEntregable
            dr(5) = i.nombreEntregable

            dr(6) = i.subtipo



            If i.subtipo = "CPP" Then
                dr(7) = "HC -PROCESOS PRODUCTIVOS A VALORES HISTORICOS"
            ElseIf i.subtipo = "CPV" Then
                dr(7) = "HC -COSTOS POR VALORACION"
            ElseIf i.subtipo = "CPE" Then
                dr(7) = "HC -PROCESO PRODUCTIVO A VALORES ESTANDAR"
           
            End If



            Select Case i.estado
                Case "PRO"
                    dr(8) = "EN PROCESO"
                Case "SUS"
                    dr(8) = "SUSPENDIDO"
                Case "EJE"
                    dr(8) = "EJECUTADO"
                Case "COS"
                    dr(8) = "PROCESO COSTEADO"
                Case "VAL"
                    dr(8) = "PROCESO VALORIZADO"
            End Select

            dr(9) = i.nroSubProductos

            dr(10) = i.unidad
            dr(11) = i.cantidad

            dr(12) = i.precUnit

            dr(13) = CDate(i.inicio).ToString("dd/MM/yyyy")
            dr(14) = CDate(i.finaliza).ToString("dd/MM/yyyy")

            ' calculo de dias habiles atrasos por de


            dias = DateDiff("d", i.inicio, i.finaliza)

            If DateTime.Now.Date >= i.inicio And DateTime.Now.Date <= i.finaliza Then
                diasH = DateDiff("d", DateTime.Now.Date, i.finaliza)
            Else
                diasH = 0
            End If

            If DateTime.Now.Date > i.finaliza Then
                diasA = DateDiff("d", DateTime.Now.Date, i.finaliza)
            Else
                diasA = 0
            End If

            dr(15) = dias
            dr(16) = diasH
            dr(17) = diasA
            dr(18) = i.TotalMN

            dr(19) = i.codigo


            dr(20) = i.nombreCuenta


            dt.Rows.Add(dr)
        Next
        dgvEntregables.DataSource = dt


        dgvEntregables.TableDescriptor.Columns("idProyecto").Width = 0
        dgvEntregables.TableDescriptor.Columns("Proyecto").Width = 170
        dgvEntregables.TableDescriptor.Columns("idSubProyecto").Width = 0
        dgvEntregables.TableDescriptor.Columns("Subproyecto").Width = 170

        '   End If
    End Sub

    Private Sub GetProyectosGeneralesCMB()
        Dim costoSA As New recursoCostoSA
        cboTipo.DisplayMember = "nombreCosto"
        cboTipo.ValueMember = "idCosto"
        cboTipo.DataSource = costoSA.GetListaRecursosXtipo(New recursoCosto With {.tipo = "HC", .subtipo = "PY"})
    End Sub

    Public Sub GetSubProyectos(idProyectoGeneral As Integer)
        Dim recursoSA As New recursoCostoSA
        Dim lista As New List(Of recursoCosto)
        lista = recursoSA.GetListaSubProyectos(New recursoCosto With {.tipo = "HC", .idpadre = idProyectoGeneral, .status = StatusProductosTerminados.Pendiente})
        'lista = recursoSA.GetListaProtectosByProyGeneral(New recursoCosto With {.tipo = "HC", .idpadre = idProyectoGeneral})
        Dim query = lista.Where(Function(o) o.subtipo <> TipoCosto.HC_Mercaderia).ToList
        cboSubProyecto.DataSource = query
        cboSubProyecto.DisplayMember = "nombreCosto"
        cboSubProyecto.ValueMember = "idCosto"
    End Sub


#End Region


    Private Sub frmMantenimientoProyectos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub







    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        EntregablesPorEstado()
    End Sub

    Private Sub dgvEntregables_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvEntregables.TableControlCellClick

    End Sub

    Private Sub dgvEntregables_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvEntregables.QueryCellStyleInfo


        If (e.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell OrElse e.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) Then
            'Checks for the column name when the cellvalue is greater than 5.
            'ENTRADAS A ALMACEN
            If e.TableCellIdentity.Column.MappingName = "estado" AndAlso CStr(e.Style.CellValue) = "EN PROCESO" Then
                e.Style.BackColor = Color.YellowGreen
            End If
            If e.TableCellIdentity.Column.MappingName = "estado" AndAlso CStr(e.Style.CellValue) = "SUSPENDIDO" Then
                e.Style.BackColor = Color.Red
            End If
            If e.TableCellIdentity.Column.MappingName = "estado" AndAlso CStr(e.Style.CellValue) = "EJECUTADO" Then
                e.Style.BackColor = Color.LightSalmon
            End If
            If e.TableCellIdentity.Column.MappingName = "estado" AndAlso CStr(e.Style.CellValue) = "PROCESO COSTEADO" Then
                e.Style.BackColor = Color.MediumTurquoise
            End If
            If e.TableCellIdentity.Column.MappingName = "estado" AndAlso CStr(e.Style.CellValue) = "PROCESO VALORIZADO" Then
                e.Style.BackColor = Color.SkyBlue
            End If


            If e.TableCellIdentity.Column.MappingName = "dias" AndAlso CDbl(Fix(e.Style.CellValue)) >= 0 Then
                e.Style.BackColor = Color.LightCyan  '

            End If
            If e.TableCellIdentity.Column.MappingName = "habiles" AndAlso CDbl(Fix(e.Style.CellValue)) >= 0 Then
                e.Style.BackColor = Color.LemonChiffon

            End If
            If e.TableCellIdentity.Column.MappingName = "atrazos" AndAlso CDbl(Fix(e.Style.CellValue)) <= 0 Then
                e.Style.BackColor = Color.MistyRose

            End If



        End If

    End Sub

    Private Sub cboSubProyecto_Click(sender As Object, e As EventArgs) Handles cboSubProyecto.Click

    End Sub



    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click

        Dim periodo As String = cboMesCompra.SelectedValue & "/" & txtAnioCompra.Text
        If cboSubProyecto.Text.Trim.Length > 0 Then
            EntregablesPorSubProy(cboSubProyecto.SelectedValue, periodo)
        Else
            MessageBox.Show("Seleccione un SubProyecto")
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Cursor = Cursors.WaitCursor
        GetSubProyectos(cboTipo.SelectedValue)
        cboSubProyecto.SelectedIndex = -1
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboTipo_Click(sender As Object, e As EventArgs) Handles cboTipo.Click

    End Sub

    Private Sub cboTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipo.SelectedIndexChanged
        cboSubProyecto.DataSource = Nothing
    End Sub



    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            GroupBox1.Visible = True
            CheckBox1.Checked = False
            ButtonAdv4.Visible = False
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            GroupBox1.Visible = False
            CheckBox2.Checked = False
            ButtonAdv4.Visible = True
        End If
    End Sub

    Private Sub LinkLabel30_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel30.LinkClicked
        Dim f As New frmProyectoConstruccion
        f.StartPosition = FormStartPosition.CenterScreen
        f.Creacion = "PROYECTO"
        f.Show()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If Not IsNothing(Me.dgvEntregables.Table.CurrentRecord) Then


            Dim f As New frmProyectoConstruccion
            f.Manipulacion = ENTITY_ACTIONS.INSERT
            f.StartPosition = FormStartPosition.CenterParent
            f.txtNuevoCosto.Text = Me.dgvEntregables.Table.CurrentRecord.GetValue("Proyecto")
            f.txtIdProyecto.Text = Me.dgvEntregables.Table.CurrentRecord.GetValue("idProyecto")
            f.Creacion = "SUBPROYECTO"
            f.txtNuevoCosto.ReadOnly = True
            f.ShowDialog()
        Else
            MessageBox.Show("Debe seleccionar una item!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Cursor = Cursors.WaitCursor
        'If cboMes.Text.Trim.Length > 0 Then
        'validarCierreAnterior()
        'ValidarCierreActual()
        Dim objeto As New recursoCosto

        If Not IsNothing(Me.dgvEntregables.Table.CurrentRecord) Then


           

            If Me.dgvEntregables.Table.CurrentRecord.GetValue("tipo") = "CPP" Or Me.dgvEntregables.Table.CurrentRecord.GetValue("tipo") = "CPE" Then

                If Me.dgvEntregables.Table.CurrentRecord.GetValue("estado") = "PROCESO COSTEADO" Then
                    '    MessageBox.Show("El Entregable ya se encuentra Ejecutado!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    '    Exit Sub
                    'End If

                    ' Dim f As New frmEntradasProductoTerminado
                    Dim f As New frmEntradasaProduccion

                    objeto = New recursoCosto
                    objeto.idItem = CInt(Me.dgvEntregables.Table.CurrentRecord.GetValue("idItem"))
                    objeto.idEntregable = CInt(Me.dgvEntregables.Table.CurrentRecord.GetValue("idEntregable"))
                    objeto.cantidad = CDec(Me.dgvEntregables.Table.CurrentRecord.GetValue("cant"))
                    objeto.precUnit = CDec(Me.dgvEntregables.Table.CurrentRecord.GetValue("costoUnit"))
                    objeto.subtipo = Me.dgvEntregables.Table.CurrentRecord.GetValue("tipo")
                    objeto.TotalMN = CDec(Me.dgvEntregables.Table.CurrentRecord.GetValue("total"))


                    'f.MoverProductosTerminados(Me.dgvEntregables.Table.CurrentRecord.GetValue("idItem"), Me.dgvEntregables.Table.CurrentRecord.GetValue("idEntregable"))
                    f.MoverProductosTerminados(objeto)
                    f.txtIdEntregable.Text = Me.dgvEntregables.Table.CurrentRecord.GetValue("idEntregable")
                    f.lblPerido.Text = PeriodoGeneral  'cboMes.SelectedValue & "/" & AnioGeneral
                    '.cboOperacion.SelectedValue = "20"
                    f.cboOperacion.Text = "PRODUCCION"
                    f.NumDowCosto.Value = CDec(Me.dgvEntregables.Table.CurrentRecord.GetValue("total"))
                    f.lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
                    f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()

                    If CheckBox1.Checked = True Then
                        EntregablesPorEstado()

                    Else
                        Dim periodo As String = cboMesCompra.SelectedValue & "/" & txtAnioCompra.Text
                        If cboSubProyecto.Text.Trim.Length > 0 Then
                            EntregablesPorSubProy(cboSubProyecto.SelectedValue, periodo)
                        End If
                    End If
                Else

                    MessageBox.Show("El Entregable esta ejecutado o Falta Costear!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Cursor = Cursors.Default
                    Exit Sub
                End If

            Else
                MessageBox.Show("Debe seleccionar Entregable de Tipo Produccion!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Cursor = Cursors.Default
            End If
        Else
            MessageBox.Show("Debe seleccionar una item!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Cursor = Cursors.Default
        End If
        'Else
        '    MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    cboMes.Select()
        '    cboMes.DroppedDown = True
        'End If
        Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Cursor = Cursors.WaitCursor
        

        If Not IsNothing(Me.dgvEntregables.Table.CurrentRecord) Then

            If Me.dgvEntregables.Table.CurrentRecord.GetValue("estado") = "EN PROCESO" Or Me.dgvEntregables.Table.CurrentRecord.GetValue("estado") = "PROCESO VALORIZADO" Then

                Dim f As New frmConsumoDeProduccion
                f.lblIdEntregable.Text = CInt(Me.dgvEntregables.Table.CurrentRecord.GetValue("idEntregable"))
                f.txtEntregable.Text = Me.dgvEntregables.Table.CurrentRecord.GetValue("Entregable")

                f.lblCuentaProyecto.Text = Me.dgvEntregables.Table.CurrentRecord.GetValue("cuenta")
                f.lblTipoProyecto.Text = Me.dgvEntregables.Table.CurrentRecord.GetValue("tipoDescip")

                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()

                If CheckBox1.Checked = True Then
                    EntregablesPorEstado()

                Else
                    Dim periodo As String = cboMesCompra.SelectedValue & "/" & txtAnioCompra.Text
                    If cboSubProyecto.Text.Trim.Length > 0 Then
                        EntregablesPorSubProy(cboSubProyecto.SelectedValue, periodo)
                    End If
                End If

            Else
                MessageBox.Show("El proyecto ya fue Costeado o esta Ejecutado!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Cursor = Cursors.Default
            End If
            'Dim f As New frmProduccionEnviada


            'f.txtProyectoGeneral.Text = Me.dgvEntregables.Table.CurrentRecord.GetValue("Proyecto")
            'f.txtSubProyecto.Text = Me.dgvEntregables.Table.CurrentRecord.GetValue("Subproyecto")
            'f.lblidEntregable.Text = CInt(Me.dgvEntregables.Table.CurrentRecord.GetValue("idEntregable"))
            'f.txtEntregable.Text = Me.dgvEntregables.Table.CurrentRecord.GetValue("Entregable")

            'f.StartPosition = FormStartPosition.CenterParent
            '    f.ShowDialog()


        Else
            MessageBox.Show("Debe seleccionar una item!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Cursor = Cursors.Default
        End If

            Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Dim f As New fmHistorialCosteo


        f.txtProyectoGeneral.Text = Me.dgvEntregables.Table.CurrentRecord.GetValue("Proyecto")
        f.txtSubProyecto.Text = Me.dgvEntregables.Table.CurrentRecord.GetValue("Subproyecto")
        f.lblidEntregable.Text = CInt(Me.dgvEntregables.Table.CurrentRecord.GetValue("idEntregable"))
        f.txtEntregable.Text = Me.dgvEntregables.Table.CurrentRecord.GetValue("Entregable")

        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    
End Class