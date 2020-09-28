Imports Helios.Planilla.Business.Entity
Imports Helios.Planilla.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmConceptoPersonal

#Region "Attributes"
    Public Property SelPersona As New Personal
    Public Property personaCargoSA As New PersonalCargoSA
    Private Property personaConceptoSA As New PersonalConceptosSA
    Public Property tablaSA As New TablaDetalleSA
    Private Property plantillaSA As New PlantillaDetalleSA
#End Region

#Region "Constructors"
    Public Sub New(idPersonal As Integer, idcargo As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(dgvConceptos, False, False)
        SelPersona = UbicarPersonal(idPersonal)
        txtNombres.Text = SelPersona.FullName
        txtNombres.Tag = SelPersona.IDPersonal
        txtNumDNI.Text = SelPersona.Numerodocumento
        txtCargo.Text = personaCargoSA.PersonalCargoSelxCargo(New PersonalCargo With {.IDPersonal = idPersonal, .IDCargo = idcargo}).DescripcionLarga
        txtCargo.Tag = idcargo
        txtStatus.Text = SelPersona.Estado
        txtNacionalidad.Text = SelPersona.Nacionalidad
        txtDocumentoIdent.Text = SelPersona.Tipodocumento
        '    txtDocumentoIdent.Text = tablaSA.TablaDetalleSelx(New TablaDetalle With {.IDTabla = 5}).fir
        GetConceptosXpersonal(txtCargo.Tag, SelPersona.IDPersonal)
        dgvConceptos.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
    End Sub
#End Region


#Region "methods"

    Private Sub UpdateRow(r As Record)
        Dim conceptoSA As New PersonalConceptosSA

        r = dgvConceptos.Table.CurrentRecord
        Dim conceptoSel = conceptoSA.PersonalConceptosXIDAU(New PersonalConceptos With {.IDConcepto = r.GetValue("ID"),
                                                                                        .IDPersonal = SelPersona.IDPersonal,
                                                                                        .IDCargo = txtCargo.Tag})


        conceptoSel.Action = BaseBE.EntityAction.UPDATE
        conceptoSel.ValorCalculo = Decimal.Parse(r.GetValue("valorconcepto"))
        conceptoSA.PersonalConceptosSave(conceptoSel, UserManager.TransactionData)
    End Sub

    Sub GetConceptosXpersonal(idcargo As Integer, idpersonal As Integer)
        Dim lstConceptos = personaConceptoSA.PersonalConceptosSelxCargo(New PersonalConceptos With {.IDPersonal = idpersonal, .IDCargo = idcargo}).OrderBy(Function(o) o.TipoConcepto).ToList

        Dim strTipoConcepto As String = Nothing
        Dim dt As New DataTable
        dt.Columns.Add("ID")
        dt.Columns.Add("IDSunat")
        dt.Columns.Add("codigo")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("tipocalculo")
        dt.Columns.Add("valorconcepto")
        dt.Columns.Add("activo", GetType(Boolean))
        dt.Columns.Add("concepto")

        For Each i In lstConceptos
            Select Case i.TipoConcepto
                Case Helios.Planilla.General.PlanillaConceptos.Ingresos
                    strTipoConcepto = "Ingresos"

                Case Helios.Planilla.General.PlanillaConceptos.IngresosAsignaciones
                    strTipoConcepto = "IngresosAsignaciones"
                Case Helios.Planilla.General.PlanillaConceptos.IngresosBonificaciones
                    strTipoConcepto = "IngresosBonificaciones"
                Case Helios.Planilla.General.PlanillaConceptos.IngresosGratificaciones
                    strTipoConcepto = "IngresosGratificaciones"
                Case Helios.Planilla.General.PlanillaConceptos.IngresosIndemnizaciones
                    strTipoConcepto = "IngresosIndemnizaciones"
                Case Helios.Planilla.General.PlanillaConceptos.DeduccionesTrabajador
                    strTipoConcepto = "DeduccionesTrabajador"
                Case Helios.Planilla.General.PlanillaConceptos.DescuentosTrabajador
                    strTipoConcepto = "DescuentosTrabajador"
                Case Helios.Planilla.General.PlanillaConceptos.AportacionesEmpleador
                    strTipoConcepto = "AportacionesEmpleador"
                Case Helios.Planilla.General.PlanillaConceptos.Conceptosvarios
                    strTipoConcepto = "Conceptosvarios"
                Case Helios.Planilla.General.PlanillaConceptos.OtrosConceptos
                    strTipoConcepto = "OtrosConceptos"

            End Select
            dt.Rows.Add(i.IDConcepto, i.IDSunat, i.Formula, i.DescripcionLarga,
                        If(i.TipoCalculo = "01", "FORMULA", "IMPORTE"),
                        i.ValorCalculo.GetValueOrDefault, i.Activo, strTipoConcepto)
        Next
        dgvConceptos.DataSource = dt
        dgvConceptos.TableDescriptor.Columns("concepto").Width = 150
        'dgvConceptos.TableDescriptor.GroupedColumns.Clear()
        'dgvConceptos.TableDescriptor.GroupedColumns.Add("concepto")
        'dgvConceptos.TableDescriptor.VisibleColumns.Remove("concepto")

        ' dgvConceptos.GroupDropAreaAlignment = Syncfusion.Windows.Forms.Grid.Grouping.GridGroupDropAreaAlignment.Left

        'lsvIngresos.Items.Clear()
        'lsvIngresosAsig.Items.Clear()
        'lsvIngresosGrati.Items.Clear()
        'lsvIngresosBonica.Items.Clear()
        'lsvIngresosIndemiza.Items.Clear()
        'lsvDeduccionesTrab.Items.Clear()
        'lsvDsctosTrab.Items.Clear()
        'lsvAportaEmpleador.Items.Clear()

        'Dim lstIngresos = lstConceptos.Where(Function(o) o.TipoConcepto = Helios.Planilla.General.PlanillaConceptos.Ingresos).ToList
        'Dim lstIngresosAsig = lstConceptos.Where(Function(o) o.TipoConcepto = Helios.Planilla.General.PlanillaConceptos.IngresosAsignaciones).ToList
        'Dim lstIngresosBonica = lstConceptos.Where(Function(o) o.TipoConcepto = Helios.Planilla.General.PlanillaConceptos.IngresosBonificaciones).ToList
        'Dim lstIngresosGrati = lstConceptos.Where(Function(o) o.TipoConcepto = Helios.Planilla.General.PlanillaConceptos.IngresosGratificaciones).ToList
        'Dim lstIngresosIndemiza = lstConceptos.Where(Function(o) o.TipoConcepto = Helios.Planilla.General.PlanillaConceptos.IngresosIndemnizaciones).ToList
        'Dim lstDeduccionesTrab = lstConceptos.Where(Function(o) o.TipoConcepto = Helios.Planilla.General.PlanillaConceptos.DeduccionesTrabajador).ToList
        'Dim lstDescuentosTrab = lstConceptos.Where(Function(o) o.TipoConcepto = Helios.Planilla.General.PlanillaConceptos.DescuentosTrabajador).ToList
        'Dim lstAportacionesEmpleador = lstConceptos.Where(Function(o) o.TipoConcepto = Helios.Planilla.General.PlanillaConceptos.AportacionesEmpleador).ToList

        'For Each i In lstIngresos
        '    Dim n As New ListViewItem(i.IDConcepto)
        '    n.SubItems.Add(i.DescripcionLarga)
        '    lsvIngresos.Items.Add(n)
        'Next

        'For Each i In lstIngresosAsig
        '    Dim n As New ListViewItem(i.IDConcepto)
        '    n.SubItems.Add(i.DescripcionLarga)
        '    lsvIngresosAsig.Items.Add(n)
        'Next

        'For Each i In lstIngresosBonica
        '    Dim n As New ListViewItem(i.IDConcepto)
        '    n.SubItems.Add(i.DescripcionLarga)
        '    lsvIngresosBonica.Items.Add(n)
        'Next

        'For Each i In lstIngresosGrati
        '    Dim n As New ListViewItem(i.IDConcepto)
        '    n.SubItems.Add(i.DescripcionLarga)
        '    lsvIngresosGrati.Items.Add(n)
        'Next

        'For Each i In lstIngresosIndemiza
        '    Dim n As New ListViewItem(i.IDConcepto)
        '    n.SubItems.Add(i.DescripcionLarga)
        '    lsvIngresosIndemiza.Items.Add(n)
        'Next
        ''------------------------------------------------
        'For Each i In lstDeduccionesTrab
        '    Dim n As New ListViewItem(i.IDConcepto)
        '    n.SubItems.Add(i.DescripcionLarga)
        '    lsvDeduccionesTrab.Items.Add(n)
        'Next

        'For Each i In lstDescuentosTrab
        '    Dim n As New ListViewItem(i.IDConcepto)
        '    n.SubItems.Add(i.DescripcionLarga)
        '    lsvDsctosTrab.Items.Add(n)
        'Next

        'For Each i In lstAportacionesEmpleador
        '    Dim n As New ListViewItem(i.IDConcepto)
        '    n.SubItems.Add(i.DescripcionLarga)
        '    lsvAportaEmpleador.Items.Add(n)
        'Next

    End Sub


    Private Sub GrabarConceptosXpersonal(idPlantilla As Integer)
        Dim listaConceptos As New List(Of PersonalConceptos)
        Dim lstPLantillaConceptos = plantillaSA.PlantillaDetalleSelxPlantillaV2(New PlantillaDetalle With {.IDPlantilla = idPlantilla})

        listaConceptos = New List(Of PersonalConceptos)
        For Each i In lstPLantillaConceptos
            listaConceptos.Add(New PersonalConceptos With
                               {
                               .IDConcepto = i.CustomConcepto.IDConcepto,
                               .IDPersonal = SelPersona.IDPersonal,
                               .IDCargo = Integer.Parse(txtCargo.Tag),
                               .IDTipoPlanilla = i.CustomConcepto.TipoPlanilla,
                               .orden = i.CustomConcepto.Orden,
                               .DescripcionCorta = i.CustomConcepto.DescripcionCorta,
                               .DescripcionLarga = i.CustomConcepto.DescripcionLarga,
                               .IDSunat = i.CustomConcepto.IDSunat,
                               .IDContable = i.CustomConcepto.IDContable,
                               .Moneda = i.CustomConcepto.Moneda,
                               .TipoCalculo = i.CustomConcepto.TipoCalculo,
                               .Formula = i.CustomConcepto.Formula,
                               .Activo = i.Requerido,
                               .TipoConcepto = i.CustomConcepto.TipoConcepto,
                               .ValorCalculo = i.valorConcepto,
                               .FechaModificacion = Date.Now,
                               .UsuarioModificacion = usuario.IDUsuario
                               })
        Next
        personaConceptoSA.PersonalConceptosSaveLista(listaConceptos, UserManager.TransactionData)
    End Sub

    Private Function UbicarPersonal(idPersonal As Integer) As Personal
        Dim personaSA As New PersonalSA
        Return personaSA.PersonalSelxID(New Personal With {.IDPersonal = idPersonal})
    End Function

    Private Sub GrabarConceptoPersonal(c As Concepto)
        Dim conceptoPersonal As New PersonalConceptos With {
        .IDConcepto = c.IDConcepto,
        .IDPersonal = SelPersona.IDPersonal,
        .IDCargo = txtCargo.Tag,
        .IDTipoPlanilla = c.TipoPlanilla,
        .orden = c.Orden,
        .DescripcionCorta = c.DescripcionCorta,
        .DescripcionLarga = c.DescripcionLarga,
        .IDSunat = c.IDSunat,
        .IDContable = c.IDContable,
        .Moneda = c.Moneda,
        .TipoCalculo = c.TipoCalculo,
        .Formula = c.Formula,
        .Activo = c.Activo,
        .TipoConcepto = c.TipoConcepto,
        .ValorCalculo = c.ValorCalculo,
        .FechaModificacion = Date.Now,
        .UsuarioModificacion = usuario.IDUsuario
        }


        personaConceptoSA.PersonalConceptosSave(conceptoPersonal, UserManager.TransactionData)
        MessageBox.Show("Concepto agregado con éxito!")
    End Sub
#End Region

#Region "Events"
    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        Dim f As New frmPlantillaConceptosModal
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        If Not IsNothing(f.Tag) Then
            GrabarConceptosXpersonal(Integer.Parse(f.Tag))
            ButtonAdv3_Click(sender, e)
        End If
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        GetConceptosXpersonal(txtCargo.Tag, SelPersona.IDPersonal)
    End Sub

    Private Sub ButtonAdv1_Click_1(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dim f As New frmModalConceptosSelect
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        If Not IsNothing(f.Tag) Then
            Dim c = CType(f.Tag, Concepto)
            GrabarConceptoPersonal(c)
            ButtonAdv3_Click(sender, e)
        End If
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click

    End Sub

    Private Sub dgvConceptos_TableControlCheckBoxClick(sender As Object, e As Grouping.GridTableControlCellClickEventArgs) Handles dgvConceptos.TableControlCheckBoxClick
        Me.Cursor = Cursors.WaitCursor
        Dim conceptoSA As New PersonalConceptosSA
        Dim RowIndex As Integer = e.Inner.RowIndex
        Dim valorCheck As Boolean

        If RowIndex > -1 Then
            e.TableControl.CurrentCell.EndEdit()
            e.TableControl.Table.TableDirty = True
            e.TableControl.Table.EndEdit()
            Dim valCheck = Me.dgvConceptos.TableModel(RowIndex, 8).CellValue

            Select Case valCheck
                Case "False" 'TRUE
                    valorCheck = True
                Case Else ' FALSE
                    valorCheck = False
            End Select
            Dim IDConcepto = Integer.Parse(Me.dgvConceptos.TableModel(RowIndex, 2).CellValue)
            Dim valorRequerido = Decimal.Parse(Me.dgvConceptos.TableModel(RowIndex, 7).CellValue)

            Dim conceptoSel = conceptoSA.PersonalConceptosXIDAU(New PersonalConceptos With {.IDConcepto = IDConcepto,
                                                                                            .IDPersonal = SelPersona.IDPersonal,
                                                                                            .IDCargo = txtCargo.Tag})



            conceptoSel.Action = BaseBE.EntityAction.UPDATE
            conceptoSel.ValorCalculo = valorRequerido
            conceptoSel.Activo = valorCheck
            conceptoSA.PersonalConceptosSave(conceptoSel, UserManager.TransactionData)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvConceptos_TableControlCellClick(sender As Object, e As Grouping.GridTableControlCellClickEventArgs) Handles dgvConceptos.TableControlCellClick

    End Sub

    Private Sub dgvConceptos_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvConceptos.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim r As Record = dgvConceptos.Table.CurrentRecord
        If r IsNot Nothing Then
            Select Case ColIndex
                Case 7
                    UpdateRow(r)

            End Select

        End If
    End Sub

#End Region

End Class