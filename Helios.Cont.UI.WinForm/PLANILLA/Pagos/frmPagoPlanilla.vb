Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Planilla.WCFService.ServiceAccess
Imports Helios.Cont.Business.Entity
Imports Helios.General
Public Class frmPagoPlanilla

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        General.FormatoGridAvanzado(dgvPlanilla, True, False)
        GetCombos()
    End Sub

    Private Sub GetCombos()
        Dim empresaPeriodoSA As New empresaPeriodoSA
        cboMesCompra.DataSource = General.ListaDeMeses()
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.DisplayMember = "Mes"

        cboAnio.DataSource = empresaPeriodoSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
        cboAnio.ValueMember = "periodo"
        cboAnio.DisplayMember = "periodo"

    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        GetPlanilla(Integer.Parse(cboMesCompra.SelectedValue), cboAnio.Text)
    End Sub

    Private Sub GetPlanilla(mes As Integer, anio As String)
        Dim planillaSA As New PlanillaGeneralSA
        Dim dt As New DataTable
        With dt
            .Columns.Add("idPersonal")
            .Columns.Add("fullname")
            .Columns.Add("idcargo")
            .Columns.Add("cargo")
            .Columns.Add("Ingresos")
            .Columns.Add("Deducciones")
            .Columns.Add("Descuentos")
            .Columns.Add("NetoPago")
            .Columns.Add("Aportaciones")
        End With

        For Each i In planillaSA.PlanillaGeneralSelXPeriodo(New Planilla.Business.Entity.PlanillaGeneral _
                                                            With {.AnioPlanilla = anio, .MesPlanilla = mes})


            dt.Rows.Add(i.IDPersonal,
                        i.FullName,
                        i.IDCargo,
                        i.Cargo,
                        i.ConceptoIngresos,
                        i.ConceptoDeducciones,
                        i.ConceptoDescuentos, 0,
                        i.ConceptoAportes)
        Next
        dgvPlanilla.DataSource = dt

    End Sub
End Class