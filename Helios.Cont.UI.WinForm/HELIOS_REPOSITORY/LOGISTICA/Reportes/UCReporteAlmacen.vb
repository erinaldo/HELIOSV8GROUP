Imports Helios.General
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Cont.Business.Entity
Public Class UCReporteAlmacen
#Region "Attributes"
    Private estableSA As New establecimientoSA
    Private almacenSA As New almacenSA
    Private ListaAlmacen As List(Of almacen)
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
#End Region

#Region "Methods"
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

        ListaAlmacen = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})

    End Sub

#End Region

#Region "Events"

    Private Sub ComboUnidad_Click(sender As Object, e As EventArgs) Handles ComboUnidad.Click

    End Sub

    Private Sub ComboUnidad_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboUnidad.SelectedValueChanged
        If IsNumeric(ComboUnidad.SelectedValue) Then
            Dim Almacenes = ListaAlmacen.Where(Function(o) o.idEstablecimiento = ComboUnidad.SelectedValue).ToList
            ComboUnidad.DataSource = Almacenes
            ComboUnidad.ValueMember = "idAlmacen"
            ComboUnidad.DisplayMember = "descripcionAlmacen"
        End If
    End Sub
#End Region
End Class
