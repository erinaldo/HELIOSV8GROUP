Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Public Class TabLG_HistorialInventario
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        GradientPanel11.Visible = True
        FormatoGridAvanzado(GridInventario, True, False)
        GetCombos()
    End Sub

    Private Sub GetCombos()
        Dim cierreSA As New CierreInventarioSA

        cboAnio.DisplayMember = "anio"
        cboAnio.ValueMember = "anio"
        cboAnio.DataSource = cierreSA.GetListAnios(New Business.Entity.cierreinventario With {.idEmpresa = Gempresas.IdEmpresaRuc})
    End Sub

    Private Sub GetMeses(intAnio As Integer)
        Dim cierreSA As New CierreInventarioSA

        cboMes.DisplayMember = "NombreMes"
        cboMes.ValueMember = "mes"
        cboMes.DataSource = cierreSA.GetListMeses(New Business.Entity.cierreinventario With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = intAnio})
    End Sub

    Private Sub cboAnio_Click(sender As Object, e As EventArgs) Handles cboAnio.Click

    End Sub

    Private Sub cboAnio_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboAnio.SelectedValueChanged
        Dim anio As Object
        anio = cboAnio.SelectedValue
        If IsNumeric(anio) Then
            GetMeses(anio)
        End If
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        If IsNumeric(cboMes.SelectedValue) Then
            If cboAnio.Text.Trim.Length > 0 Then
                GetCierrePeriodo(Integer.Parse(cboAnio.Text), Integer.Parse(cboMes.SelectedValue))
            End If
        End If
    End Sub

    Private Sub GetCierrePeriodo(Anio As Integer, Mes As Integer)
        Dim cierreSA As New CierreInventarioSA
        Dim dt As New DataTable
        With dt.Columns
            .Add("almacen")
            .Add("producto")
            .Add("lote")
            .Add("unidad")
            .Add("tipoex")
            .Add("cantidad")
            .Add("costo")
        End With
        Dim fecha As New Date(Anio, Mes, 1)
        For Each i In cierreSA.GetListado_cierreinventarioPorPeriodo(New Business.Entity.cierreinventario With {.idEmpresa = Gempresas.IdEmpresaRuc, .periodo = GetPeriodo(fecha, False)})
            dt.Rows.Add(i.NomAlmacen, i.NomItem, i.codigoLote, i.unidad, i.TipoExistencia, i.cantidad, i.importe)
        Next
        GridInventario.DataSource = dt
    End Sub
End Class
