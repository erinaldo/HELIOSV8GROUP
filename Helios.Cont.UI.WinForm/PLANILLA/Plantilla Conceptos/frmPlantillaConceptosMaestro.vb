Imports Helios.Planilla.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Helios.Planilla.General.Constantes
Imports Helios.Planilla.Business.Entity
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmPlantillaConceptosMaestro
#Region "Attributes"
    Public Property ConceptoSA As New ConceptoSA
    Public Property PlantillaSA As New PlantillaSA
    Public Property PlantillaDetalleSA As New PlantillaDetalleSA
    Public Property NuevaPlantillaDetalle As PlantillaDetalle
    Private r As Record
#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(dgPlantilla, True, False)
        FormatoGridAvanzado(dgvConceptos, False, False)
        LoadCombos()
        GetPlantillas()
    End Sub

    Private Sub LoadCombos()
        Dim tablaDetalleSA As New TablaDetalleSA
        Dim lstConceptos = tablaDetalleSA.TablaDetalleSelxTabla(New TablaDetalle With {.IDTabla = 1020, .Estado = "1"}).ToList

        cboTipoConcepto.ValueMember = "IDTablaDetalle"
        cboTipoConcepto.DisplayMember = "DescripcionLarga"
        cboTipoConcepto.DataSource = lstConceptos
    End Sub

#End Region

#Region "Methods"
    Private Sub GrabarPlantillaConcepto(c As Concepto)
        r = dgPlantilla.Table.CurrentRecord
        If r IsNot Nothing Then
            NuevaPlantillaDetalle = New PlantillaDetalle
            NuevaPlantillaDetalle.Action = BaseBE.EntityAction.INSERT
            NuevaPlantillaDetalle.IDPlantilla = Integer.Parse(r.GetValue("IDPlantilla"))
            NuevaPlantillaDetalle.IDConcepto = c.IDConcepto
            NuevaPlantillaDetalle.DescripcionCorta = c.TipoConcepto
            NuevaPlantillaDetalle.Orden = Short.Parse(c.Orden)
            NuevaPlantillaDetalle.Requerido = c.Activo
            NuevaPlantillaDetalle.UsuarioModificacion = usuario.IDUsuario
            NuevaPlantillaDetalle.FechaModificacion = Date.Now
            PlantillaDetalleSA.PlantillaDetalleSave(NuevaPlantillaDetalle, UserManager.TransactionData)
        Else
            MessageBox.Show("Debe seleccionar un concepto padre", "Validar selección", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub CalculoRow(r As Record, colIndex As Integer)
        Select Case colIndex
            Case 5
                Dim colValorUnico = r.GetValue("valorconcepto")

                UpdateRow(r)
            Case 6
                'Dim colValorUnico = r.GetValue("valorconcepto")
                'Dim valorCheck = Boolean.Parse(r.GetValue("activo"))
                'If valorCheck = True Then
                '    If colValorUnico <= 0 Then
                '        MessageBox.Show("El valor del concepto debe ser mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '        r.SetValue("activo", False)
                '        Exit Sub
                '    End If
                'End If
                UpdateRow(r)
        End Select

    End Sub

    Private Sub UpdateRow(r As Record)
        Dim objUpdate As New PlantillaDetalle
        Dim plantillaSA As New PlantillaDetalleSA
        Dim idplantilla = dgPlantilla.Table.CurrentRecord.GetValue("IDPlantilla")
        Dim plantillaSel = plantillaSA.PlantillaDetalleSelxPlantillaxConcepto(New PlantillaDetalle With {.IDConcepto = r.GetValue("ID"), .IDPlantilla = idplantilla})

        objUpdate = New PlantillaDetalle
        objUpdate = plantillaSel
        objUpdate.Action = BaseBE.EntityAction.UPDATE
        objUpdate.IDPlantilla = plantillaSel.IDPlantilla
        objUpdate.IDConcepto = plantillaSel.IDConcepto
        objUpdate.valorConcepto = Decimal.Parse(r.GetValue("valorconcepto"))
        plantillaSA.PlantillaDetalleSave(objUpdate, UserManager.TransactionData)
    End Sub

    Private Sub GetConceptosDetalleXplantilla(idPlantilla As Integer)
        'lsvIngresos.Items.Clear()
        'lsvIngresosAsig.Items.Clear()
        'lsvIngresosBonifica.Items.Clear()
        'lsvIngresosGrati.Items.Clear()
        'lsvIngresosIndem.Items.Clear()

        'lsvDeduccionesTrab.Items.Clear()
        'lsvDescuentosTrab.Items.Clear()
        'lsvAportacionesEmpleador.Items.Clear()

        'Dim lstDetallePlantilla = PlantillaDetalleSA.PlantillaDetalleSelxPlantillaV2(New Planilla.Business.Entity.PlantillaDetalle With {.IDPlantilla = idPlantilla})

        'Dim lstConceptos = lstDetallePlantilla.Where(Function(o) o.CustomConcepto.TipoConcepto = tipoConcepto).ToList

        'Dim lstIngresos = lstDetallePlantilla.Where(Function(o) o.CustomConcepto.TipoConcepto = PlanillaConceptos.Ingresos).ToList
        'Dim lstingresosAsiganciones = lstDetallePlantilla.Where(Function(o) o.CustomConcepto.TipoConcepto = PlanillaConceptos.IngresosAsignaciones).ToList
        'Dim lstingresosBonificaciones = lstDetallePlantilla.Where(Function(o) o.CustomConcepto.TipoConcepto = PlanillaConceptos.IngresosBonificaciones).ToList
        'Dim lstingresosGrati = lstDetallePlantilla.Where(Function(o) o.CustomConcepto.TipoConcepto = PlanillaConceptos.IngresosGratificaciones).ToList
        'Dim lstingresosindemniza = lstDetallePlantilla.Where(Function(o) o.CustomConcepto.TipoConcepto = PlanillaConceptos.IngresosIndemnizaciones).ToList

        'Dim lstDeduccionesAlTrabajador = lstDetallePlantilla.Where(Function(o) o.CustomConcepto.TipoConcepto = PlanillaConceptos.DeduccionesTrabajador).ToList
        'Dim lstDescuentosAlTrabajador = lstDetallePlantilla.Where(Function(o) o.CustomConcepto.TipoConcepto = PlanillaConceptos.DescuentosTrabajador).ToList
        'Dim lstAportacionesEmpleador = lstDetallePlantilla.Where(Function(o) o.CustomConcepto.TipoConcepto = PlanillaConceptos.AportacionesEmpleador).ToList

        'For Each i In lstIngresos
        '    Dim n As New ListViewItem(i.CustomConcepto.IDConcepto)
        '    n.SubItems.Add(i.CustomConcepto.DescripcionLarga)
        '    lsvIngresos.Items.Add(n)
        'Next

        'For Each i In lstingresosAsiganciones
        '    Dim n As New ListViewItem(i.CustomConcepto.IDConcepto)
        '    n.SubItems.Add(i.CustomConcepto.DescripcionLarga)
        '    lsvIngresosAsig.Items.Add(n)
        'Next

        'For Each i In lstingresosBonificaciones
        '    Dim n As New ListViewItem(i.CustomConcepto.IDConcepto)
        '    n.SubItems.Add(i.CustomConcepto.DescripcionLarga)
        '    lsvIngresosBonifica.Items.Add(n)
        'Next

        'For Each i In lstingresosGrati
        '    Dim n As New ListViewItem(i.CustomConcepto.IDConcepto)
        '    n.SubItems.Add(i.CustomConcepto.DescripcionLarga)
        '    lsvIngresosGrati.Items.Add(n)
        'Next

        'For Each i In lstingresosindemniza
        '    Dim n As New ListViewItem(i.CustomConcepto.IDConcepto)
        '    n.SubItems.Add(i.CustomConcepto.DescripcionLarga)
        '    lsvIngresosIndem.Items.Add(n)
        'Next

        'For Each i In lstDeduccionesAlTrabajador
        '    Dim n As New ListViewItem(i.CustomConcepto.IDConcepto)
        '    n.SubItems.Add(i.CustomConcepto.DescripcionLarga)
        '    lsvDeduccionesTrab.Items.Add(n)
        'Next

        'For Each i In lstDescuentosAlTrabajador
        '    Dim n As New ListViewItem(i.CustomConcepto.IDConcepto)
        '    n.SubItems.Add(i.CustomConcepto.DescripcionLarga)
        '    lsvDescuentosTrab.Items.Add(n)
        'Next

        'For Each i In lstAportacionesEmpleador
        '    Dim n As New ListViewItem(i.CustomConcepto.IDConcepto)
        '    n.SubItems.Add(i.CustomConcepto.DescripcionLarga)
        '    lsvAportacionesEmpleador.Items.Add(n)
        'Next

    End Sub

    Private Sub GetConceptosPlantilla(idPlantilla As Integer, tipoconcepto As String)
        Dim dt As New DataTable
        dt.Columns.Add("ID")
        dt.Columns.Add("IDSunat")
        dt.Columns.Add("codigo")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("tipocalculo")
        dt.Columns.Add("valorconcepto")
        dt.Columns.Add("activo", GetType(Boolean))

        Dim lstDetallePlantilla = PlantillaDetalleSA.PlantillaDetalleSelxPlantillaV2(New Planilla.Business.Entity.PlantillaDetalle With {.IDPlantilla = idPlantilla})

        Dim lstConceptos = lstDetallePlantilla.Where(Function(o) o.CustomConcepto.TipoConcepto = tipoconcepto).ToList

        For Each i In lstConceptos
            dt.Rows.Add(i.CustomConcepto.IDConcepto, i.CustomConcepto.IDSunat, i.CustomConcepto.Formula, i.CustomConcepto.DescripcionLarga, If(i.CustomConcepto.TipoCalculo = "01", "FORMULA", "IMPORTE"), i.valorConcepto.GetValueOrDefault, i.Requerido)
        Next
        dgvConceptos.DataSource = dt
    End Sub

    Private Sub GetPlantillas()
        Dim dt As New DataTable
        dt.Columns.Add("IDPlantilla").Caption = "ID"
        dt.Columns.Add("DescripcionCorta")
        dt.Columns.Add("DescripcionLarga")

        For Each i In PlantillaSA.PlantillaSelAll
            dt.Rows.Add(i.IDPlantilla,
                        i.DescripcionCorta,
                        i.DescripcionLarga)
        Next
        dgPlantilla.DataSource = dt
    End Sub

    Private Sub EliminarConceptosDetalle()
        'If TabPage1 Is TabControl1.SelectedTab Then 'Ingresos
        '    If lsvIngresos.SelectedItems.Count > 0 Then

        '    End If
        'ElseIf TabPage2 Is TabControl1.SelectedTab Then ' Descuentos
        '    If lsvDescuentos.SelectedItems.Count > 0 Then

        '    End If
        'ElseIf lsvIngresosBOF Is TabControl1.SelectedTab Then 'Aportes del trabajador
        '    If lsvAportesTrab.SelectedItems.Count > 0 Then

        '    End If
        'ElseIf TabPage4 Is TabControl1.SelectedTab Then 'Aportes del empleador
        '    If lsvAportesEmple.SelectedItems.Count > 0 Then

        '    End If

        'End If
    End Sub

#End Region

#Region "Events"
    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        Dim f As New frmPlantillaConceptoCargo
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub dgPlantilla_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgPlantilla.SelectedRecordsChanged
        If e.SelectedRecord IsNot Nothing Then
            GetConceptosDetalleXplantilla(Integer.Parse(e.SelectedRecord.Record.GetValue("IDPlantilla")))
        Else

        End If
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        Dim f As New frmModalConceptosSelect
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        If Not IsNothing(f.Tag) Then
            Dim c = CType(f.Tag, Concepto)
            GrabarPlantillaConcepto(c)
            GetConceptosDetalleXplantilla(Integer.Parse(dgPlantilla.Table.CurrentRecord.GetValue("IDPlantilla")))
        End If
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        EliminarConceptosDetalle()
    End Sub

    Private Sub ButtonAdv7_Click(sender As Object, e As EventArgs) Handles ButtonAdv7.Click
        GetPlantillas()
    End Sub

    Private Sub ButtonAdv8_Click(sender As Object, e As EventArgs) Handles ButtonAdv8.Click
        Dim r As Record = dgPlantilla.Table.CurrentRecord
        If r IsNot Nothing Then
            GetConceptosPlantilla(r.GetValue("IDPlantilla"), cboTipoConcepto.SelectedValue)
        End If
    End Sub

    Private Sub dgPlantilla_TableControlCellClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles dgPlantilla.TableControlCellClick

    End Sub

    Private Sub dgvConceptos_TableControlCellClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles dgvConceptos.TableControlCellClick

    End Sub

    Private Sub dgvConceptos_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvConceptos.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim r As Record = dgvConceptos.Table.CurrentRecord
        If r IsNot Nothing Then
            CalculoRow(r, ColIndex)
        End If
    End Sub

    Private Sub dgvConceptos_TableControlCheckBoxClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvConceptos.TableControlCheckBoxClick
        Me.Cursor = Cursors.WaitCursor
        Dim plantillaSA As New PlantillaDetalleSA
        Dim objUpdate As New PlantillaDetalle
        Dim RowIndex As Integer = e.Inner.RowIndex
        Dim valorCheck As Boolean

        If RowIndex > -1 Then
            e.TableControl.CurrentCell.EndEdit()
            e.TableControl.Table.TableDirty = True
            e.TableControl.Table.EndEdit()

            Dim valCheck = Me.dgvConceptos.TableModel(RowIndex, 7).CellValue
            Select Case valCheck
                Case "False" 'TRUE
                    valorCheck = True
                Case Else ' FALSE
                    valorCheck = False
            End Select
            Dim IDConcepto = Integer.Parse(Me.dgvConceptos.TableModel(RowIndex, 1).CellValue)
            Dim valorRequerido = Decimal.Parse(Me.dgvConceptos.TableModel(RowIndex, 6).CellValue)

            Dim idplantilla = dgPlantilla.Table.CurrentRecord.GetValue("IDPlantilla")
            Dim plantillaSel = plantillaSA.PlantillaDetalleSelxPlantillaxConcepto(
                New PlantillaDetalle With {.IDConcepto = IDConcepto, .IDPlantilla = idplantilla})


            objUpdate = New PlantillaDetalle
            objUpdate = plantillaSel
            objUpdate.Action = BaseBE.EntityAction.UPDATE
            objUpdate.IDPlantilla = idplantilla
            objUpdate.IDConcepto = IDConcepto
            objUpdate.valorConcepto = valorRequerido
            objUpdate.Requerido = valorCheck
            plantillaSA.PlantillaDetalleSave(objUpdate, UserManager.TransactionData)

        End If
        Me.Cursor = Cursors.Arrow
    End Sub

#End Region
End Class