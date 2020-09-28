Imports Helios.Cont.Business.Entity
Imports Helios.General
Public Class UCRankingVendedor
#Region "Attributes"

#End Region

#Region "Constructors"
    Public Sub New(ListaVentas As List(Of documentoventaAbarrotes))

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridBlack(GridRentabilidad, True)
        GetRankingClientes(ListaVentas)
    End Sub
#End Region

#Region "Methods"
    Private Sub GetRankingClientes(listaVentas As List(Of documentoventaAbarrotes))
        Dim dt As New DataTable
        dt.Columns.Add("Cliente")
        dt.Columns.Add("tipodoc")
        dt.Columns.Add("nrodoc")
        dt.Columns.Add("tipo")
        dt.Columns.Add("ventasiniva")
        dt.Columns.Add("iva")
        dt.Columns.Add("ventaconiva")
        dt.Columns.Add("vendedor")

        For Each i In listaVentas
            Dim usuarioSEl = UsuariosList.Where(Function(o) o.IDUsuario = i.usuarioActualizacion).SingleOrDefault


            Dim base As Decimal = Math.Round(CDec(CalculoBaseImponible(i.ImporteNacional.GetValueOrDefault, 1.18)), 2)
            Dim iva As Decimal = i.ImporteNacional.GetValueOrDefault - base

            If usuarioSEl IsNot Nothing Then
                dt.Rows.Add(i.CustomEntidad.nombreCompleto, i.CustomEntidad.tipoDoc, i.CustomEntidad.nrodoc, i.CustomEntidad.tipoPersona, base.ToString("N2"), iva.ToString("N2"), i.ImporteNacional.GetValueOrDefault.ToString("N2"), usuarioSEl.Full_Name)
            Else
                dt.Rows.Add(i.CustomEntidad.nombreCompleto, i.CustomEntidad.tipoDoc, i.CustomEntidad.nrodoc, i.CustomEntidad.tipoPersona, base.ToString("N2"), iva.ToString("N2"), i.ImporteNacional.GetValueOrDefault.ToString("N2"), "-")
            End If


        Next
        GridRentabilidad.DataSource = dt
    End Sub
#End Region
End Class
