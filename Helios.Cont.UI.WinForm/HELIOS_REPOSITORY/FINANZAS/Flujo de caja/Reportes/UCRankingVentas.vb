Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Public Class UCRankingVentas

    Dim ventaSA As New documentoVentaAbarrotesSA
    Dim estableSA As New establecimientoSA
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GetCombos()
    End Sub

    Public Sub GetCombos()
        cboMesPedido.DisplayMember = "Mes"
        cboMesPedido.ValueMember = "Codigo"
        cboMesPedido.DataSource = ListaDeMeses()
        cboMesPedido.SelectedValue = String.Format("{0:00}", DateTime.Now.Month)
        cboAnio.Text = DateTime.Now.Year


        Dim lista = estableSA.ObtenerListaEstablecimientos(Gempresas.IdEmpresaRuc).Where(Function(o) o.TipoEstab = "UN").ToList

        ComboUnidad.DataSource = lista
        ComboUnidad.ValueMember = "idCentroCosto"
        ComboUnidad.DisplayMember = "nombre"
        ComboUnidad.SelectedValue = GEstableciento.IdEstablecimiento
        'ComboUsuarios.DataSource = UsuariosList
        'ComboUsuarios.ValueMember = "IDUsuario"
        'ComboUsuarios.DisplayMember = "Nombres"
    End Sub

    Private Sub BunifuThinButton23_Click(sender As Object, e As EventArgs) Handles BunifuThinButton23.Click
        PanelBody.Controls.Clear()

        Select Case ComboReporte.Text
            Case "CLIENTES"
                GetRankingClientes()

            Case "PRODUCTO"
                GetRankingProductos()

            Case "VENDEDOR"
                GetRankingVendedor()
        End Select
    End Sub

    Private Sub GetRankingClientes()
        Dim periodo = New Date(CInt(cboAnio.Text), CInt(cboMesPedido.SelectedValue), 1)
        Dim periodoSel = GetPeriodo(periodo, True)
        Dim lista = ventaSA.RankingVentas("CLIENTES", New Business.Entity.documentoventaAbarrotes With {
                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                          .idEstablecimiento = ComboUnidad.SelectedValue,
                                          .fechaPeriodo = periodoSel
                                          })

        Dim ucrankincCliente As New UCRankingClientes(lista.OrderByDescending(Function(o) o.ImporteNacional).ToList) With {.Dock = DockStyle.Fill, .Visible = True}
        ucrankincCliente.Show()
        PanelBody.Controls.Add(ucrankincCliente)
    End Sub

    Private Sub GetRankingVendedor()
        Dim periodo = New Date(CInt(cboAnio.Text), CInt(cboMesPedido.SelectedValue), 1)
        Dim periodoSel = GetPeriodo(periodo, True)
        Dim lista = ventaSA.RankingVentas("VENDEDOR", New Business.Entity.documentoventaAbarrotes With {
                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                          .idEstablecimiento = ComboUnidad.SelectedValue,
                                          .fechaPeriodo = periodoSel
                                          })

        Dim UCRankingVendedor As New UCRankingVendedor(lista.OrderByDescending(Function(o) o.ImporteNacional).ToList) With {.Dock = DockStyle.Fill, .Visible = True}
        UCRankingVendedor.Show()
        PanelBody.Controls.Add(UCRankingVendedor)
    End Sub

    Private Sub GetRankingProductos()
        Dim periodo = New Date(CInt(cboAnio.Text), CInt(cboMesPedido.SelectedValue), 1)
        Dim periodoSel = GetPeriodo(periodo, True)
        Dim lista = ventaSA.RankingVentas("PRODUCTOS", New Business.Entity.documentoventaAbarrotes With {
                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                          .idEstablecimiento = ComboUnidad.SelectedValue,
                                          .fechaPeriodo = periodoSel
                                          })

        Dim UCRankingProductos As New UCRankingProductos(lista) With {.Dock = DockStyle.Fill, .Visible = True}
        UCRankingProductos.Show()
        PanelBody.Controls.Add(UCRankingProductos)
    End Sub
End Class
