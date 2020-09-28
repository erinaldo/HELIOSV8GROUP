Imports Helios.Planilla.Business.Entity
Imports Helios.Planilla.General.Constantes
Imports Helios.Planilla.WCFService.ServiceAccess

Public Class frmPlantillaConceptoCargo

#Region "Attributes"
    Dim servicio As New ConceptoSA
    Public Property plantillaSA As New PlantillaSA
#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        GetFillCombo()

    End Sub
#End Region

#Region "Methods"

    Sub GetFillCombo()
        Dim Listados As New TablaDetalleSA
        Dim lstTipoPlanilla = Listados.TablaDetalleSelxTabla(New TablaDetalle With {.IDTabla = 1021})

        ' Dim cargoSA As New Helios.Planilla.WCFService.ServiceAccess.CargosSA
        cboTipoPlanilla.DataSource = lstTipoPlanilla ' cargoSA.CargosSelAll()
        cboTipoPlanilla.ValueMember = "IDTablaDetalle"
        cboTipoPlanilla.DisplayMember = "DescripcionLarga"
    End Sub

    Public Sub GetConceptos(idTipoPlanilla As String)
        Dim lstIngresos = servicio.ConceptoSelxCargo(New Concepto With {.TipoConcepto = PlanillaConceptos.Ingresos, .TipoPlanilla = idTipoPlanilla})
        Dim lstIngresosAsignaciones = servicio.ConceptoSelxCargo(New Concepto With {.TipoConcepto = PlanillaConceptos.IngresosAsignaciones, .TipoPlanilla = idTipoPlanilla})
        Dim lstIngresosBonificaciones = servicio.ConceptoSelxCargo(New Concepto With {.TipoConcepto = PlanillaConceptos.IngresosBonificaciones, .TipoPlanilla = idTipoPlanilla})
        Dim lstIngresosGratificaciones = servicio.ConceptoSelxCargo(New Concepto With {.TipoConcepto = PlanillaConceptos.IngresosGratificaciones, .TipoPlanilla = idTipoPlanilla})
        Dim lstIngresosIndemnizaciones = servicio.ConceptoSelxCargo(New Concepto With {.TipoConcepto = PlanillaConceptos.IngresosIndemnizaciones, .TipoPlanilla = idTipoPlanilla})

        Dim lstDeduccionesAltrabajador = servicio.ConceptoSelxCargo(New Concepto With {.TipoConcepto = PlanillaConceptos.DeduccionesTrabajador, .TipoPlanilla = idTipoPlanilla})
        Dim lstDescuentosAlTrabajador = servicio.ConceptoSelxCargo(New Concepto With {.TipoConcepto = PlanillaConceptos.DescuentosTrabajador, .TipoPlanilla = idTipoPlanilla})
        Dim lstAportacionesEmpleador = servicio.ConceptoSelxCargo(New Concepto With {.TipoConcepto = PlanillaConceptos.AportacionesEmpleador, .TipoPlanilla = idTipoPlanilla})


        'Fill lista Ingresos
        lsvIngresos.Items.Clear()
        For Each i In lstIngresos
            Dim n As New ListViewItem(i.IDConcepto)
            n.Checked = False
            n.SubItems.Add(i.IDSunat)
            n.SubItems.Add(i.DescripcionLarga)
            n.SubItems.Add(i.Orden)
            n.SubItems.Add(i.Activo)
            lsvIngresos.Items.Add(n)
        Next

        lsvIngresosAsignaciones.Items.Clear()
        For Each i In lstIngresosAsignaciones
            Dim n As New ListViewItem(i.IDConcepto)
            n.Checked = False
            n.SubItems.Add(i.IDSunat)
            n.SubItems.Add(i.DescripcionLarga)
            n.SubItems.Add(i.Orden)
            n.SubItems.Add(i.Activo)
            lsvIngresosAsignaciones.Items.Add(n)
        Next

        lsvIngresosBonificaciones.Items.Clear()
        For Each i In lstIngresosBonificaciones
            Dim n As New ListViewItem(i.IDConcepto)
            n.Checked = False
            n.SubItems.Add(i.IDSunat)
            n.SubItems.Add(i.DescripcionLarga)
            n.SubItems.Add(i.Orden)
            n.SubItems.Add(i.Activo)
            lsvIngresosBonificaciones.Items.Add(n)
        Next

        lsvIngresosGratificacion.Items.Clear()
        For Each i In lstIngresosGratificaciones
            Dim n As New ListViewItem(i.IDConcepto)
            n.Checked = False
            n.SubItems.Add(i.IDSunat)
            n.SubItems.Add(i.DescripcionLarga)
            n.SubItems.Add(i.Orden)
            n.SubItems.Add(i.Activo)
            lsvIngresosGratificacion.Items.Add(n)
        Next

        lsvIngresosIndemnizaciones.Items.Clear()
        For Each i In lstIngresosIndemnizaciones
            Dim n As New ListViewItem(i.IDConcepto)
            n.Checked = False
            n.SubItems.Add(i.IDSunat)
            n.SubItems.Add(i.DescripcionLarga)
            n.SubItems.Add(i.Orden)
            n.SubItems.Add(i.Activo)
            lsvIngresosIndemnizaciones.Items.Add(n)
        Next

        lsvDeduccionesTrabajador.Items.Clear()
        For Each i In lstDeduccionesAltrabajador
            Dim n As New ListViewItem(i.IDConcepto)
            n.Checked = False
            n.SubItems.Add(i.IDSunat)
            n.SubItems.Add(i.DescripcionLarga)
            n.SubItems.Add(i.Orden)
            n.SubItems.Add(i.Activo)
            lsvDeduccionesTrabajador.Items.Add(n)
        Next

        lsvDescuentosTrabajador.Items.Clear()
        For Each i In lstDescuentosAlTrabajador
            Dim n As New ListViewItem(i.IDConcepto)
            n.Checked = False
            n.SubItems.Add(i.IDSunat)
            n.SubItems.Add(i.DescripcionLarga)
            n.SubItems.Add(i.Orden)
            n.SubItems.Add(i.Activo)
            lsvDescuentosTrabajador.Items.Add(n)
        Next

        lsvAportacionesEmpleador.Items.Clear()
        For Each i In lstAportacionesEmpleador
            Dim n As New ListViewItem(i.IDConcepto)
            n.Checked = False
            n.SubItems.Add(i.IDSunat)
            n.SubItems.Add(i.DescripcionLarga)
            n.SubItems.Add(i.Orden)
            n.SubItems.Add(i.Activo)
            lsvAportacionesEmpleador.Items.Add(n)
        Next


    End Sub

    Private Sub Grabar()
        Dim plantilla As New Plantilla
        plantilla.DescripcionCorta = txtPLantillaAbrev.Text.Trim
        plantilla.DescripcionLarga = txtPLantilla.Text.Trim
        plantilla.UsuarioModificacion = usuario.IDUsuario
        plantilla.FechaModificacion = Date.Now

        plantilla.PlantillaDetalle.Clear()
        For Each i As ListViewItem In lsvIngresos.CheckedItems
            plantilla.PlantillaDetalle.Add(New PlantillaDetalle With {
                                           .IDConcepto = Integer.Parse(i.SubItems(0).Text),
                                           .DescripcionCorta = PlanillaConceptos.Ingresos,
                                           .Orden = Short.Parse(i.SubItems(3).Text),
                                           .Requerido = Boolean.Parse(i.SubItems(4).Text)})
        Next

        For Each i As ListViewItem In lsvIngresosAsignaciones.CheckedItems
            plantilla.PlantillaDetalle.Add(New PlantillaDetalle With {
                                           .IDConcepto = Integer.Parse(i.SubItems(0).Text),
                                           .DescripcionCorta = PlanillaConceptos.IngresosAsignaciones,
                                           .Orden = Short.Parse(i.SubItems(3).Text),
                                           .Requerido = Boolean.Parse(i.SubItems(4).Text)})
        Next

        For Each i As ListViewItem In lsvIngresosBonificaciones.CheckedItems
            plantilla.PlantillaDetalle.Add(New PlantillaDetalle With {
                                           .IDConcepto = Integer.Parse(i.SubItems(0).Text),
                                           .DescripcionCorta = PlanillaConceptos.IngresosBonificaciones,
                                           .Orden = Short.Parse(i.SubItems(3).Text),
                                           .Requerido = Boolean.Parse(i.SubItems(4).Text)})
        Next

        For Each i As ListViewItem In lsvIngresosGratificacion.CheckedItems
            plantilla.PlantillaDetalle.Add(New PlantillaDetalle With {
                                           .IDConcepto = Integer.Parse(i.SubItems(0).Text),
                                           .DescripcionCorta = PlanillaConceptos.IngresosGratificaciones,
                                           .Orden = Short.Parse(i.SubItems(3).Text),
                                           .Requerido = Boolean.Parse(i.SubItems(4).Text)})
        Next

        For Each i As ListViewItem In lsvIngresosIndemnizaciones.CheckedItems
            plantilla.PlantillaDetalle.Add(New PlantillaDetalle With {
                                           .IDConcepto = Integer.Parse(i.SubItems(0).Text),
                                           .DescripcionCorta = PlanillaConceptos.IngresosIndemnizaciones,
                                           .Orden = Short.Parse(i.SubItems(3).Text),
                                           .Requerido = Boolean.Parse(i.SubItems(4).Text)})
        Next
        '--------------------

        For Each i As ListViewItem In lsvDeduccionesTrabajador.CheckedItems
            plantilla.PlantillaDetalle.Add(New PlantillaDetalle With {
                                           .IDConcepto = Integer.Parse(i.SubItems(0).Text),
                                           .DescripcionCorta = PlanillaConceptos.DeduccionesTrabajador,
                                           .Orden = Short.Parse(i.SubItems(3).Text),
                                           .Requerido = Boolean.Parse(i.SubItems(4).Text)})
        Next

        For Each i As ListViewItem In lsvDescuentosTrabajador.CheckedItems
            plantilla.PlantillaDetalle.Add(New PlantillaDetalle With {
                                           .IDConcepto = Integer.Parse(i.SubItems(0).Text),
                                           .DescripcionCorta = PlanillaConceptos.DescuentosTrabajador,
                                           .Orden = Short.Parse(i.SubItems(3).Text),
                                           .Requerido = Boolean.Parse(i.SubItems(4).Text)})
        Next

        For Each i As ListViewItem In lsvAportacionesEmpleador.CheckedItems
            plantilla.PlantillaDetalle.Add(New PlantillaDetalle With {
                                           .IDConcepto = Integer.Parse(i.SubItems(0).Text),
                                           .DescripcionCorta = PlanillaConceptos.AportacionesEmpleador,
                                           .Orden = Short.Parse(i.SubItems(3).Text),
                                           .Requerido = Boolean.Parse(i.SubItems(4).Text)})
        Next

        plantillaSA.PlantillaSaveAll(plantilla, UserManager.TransactionData)

        MessageBox.Show("Plantilla registrada", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close()
    End Sub
#End Region

#Region "Events"
    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        If txtPLantillaAbrev.Text.Trim.Length = 0 Then
            MessageBox.Show("Debe ingresar el nombre de la plantilla", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If txtPLantilla.Text.Trim.Length > 0 Then
            Grabar()
        Else
            MessageBox.Show("Debe ingresar una descripción breve", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub cboTipoPlanilla_Click(sender As Object, e As EventArgs) Handles cboTipoPlanilla.Click

    End Sub

    Private Sub cboTipoPlanilla_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboTipoPlanilla.SelectedValueChanged
        If cboTipoPlanilla.Text.Trim.Length > 0 Then
            Dim codigo = cboTipoPlanilla.SelectedValue
            If IsNumeric(codigo) Then
                GetConceptos(String.Format("{0:00}", cboTipoPlanilla.SelectedValue))
            End If
        End If
    End Sub

    Private Sub GroupBar1_GroupBarItemSelected(sender As Object, e As EventArgs) Handles GroupBar1.GroupBarItemSelected

    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        CheckConceptos(True)
    End Sub

    Private Sub CheckConceptos(SelecAll As Boolean)
        For Each i As ListViewItem In lsvIngresos.Items
            i.Checked = SelecAll
        Next

        For Each i As ListViewItem In lsvIngresosAsignaciones.Items
            i.Checked = SelecAll
        Next

        For Each i As ListViewItem In lsvIngresosBonificaciones.Items
            i.Checked = SelecAll
        Next

        For Each i As ListViewItem In lsvIngresosGratificacion.Items
            i.Checked = SelecAll
        Next

        For Each i As ListViewItem In lsvIngresosIndemnizaciones.Items
            i.Checked = SelecAll
        Next

        For Each i As ListViewItem In lsvDeduccionesTrabajador.Items
            i.Checked = SelecAll
        Next

        For Each i As ListViewItem In lsvDescuentosTrabajador.Items
            i.Checked = SelecAll
        Next

        For Each i As ListViewItem In lsvAportacionesEmpleador.Items
            i.Checked = SelecAll
        Next
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        CheckConceptos(False)
    End Sub
#End Region

End Class