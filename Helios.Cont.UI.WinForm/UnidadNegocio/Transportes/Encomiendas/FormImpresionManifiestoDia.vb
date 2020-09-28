Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Public Class FormImpresionManifiestoDia

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        '   GetComboPersonas()
    End Sub
#End Region

#Region "Methdos"
    'Public Sub GetComboPersonas()
    '    Dim PersonaSA As New PersonaSA
    '    Dim ListaTrasnportistas = PersonaSA.ObtenerPersona(Gempresas.IdEmpresaRuc).Where(Function(o) o.tipoPersona = "T").ToList
    '    ComboChofer.DataSource = ListaTrasnportistas
    '    ComboChofer.ValueMember = "codigo"
    '    ComboChofer.DisplayMember = "nombreCompleto"
    'End Sub
#End Region

#Region "Events"
    Private Sub FormImpresionManifiestoDia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtFechaVenta.Value = Date.Now
    End Sub

    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        '.tripulante1 = Integer.Parse(ComboChofer.SelectedValue)

        If RBAcumuladoDia.Checked = True Then
            If IsDate(txtFechaVenta.Value) Then
                Dim rutaTraeo As New rutaTareoEncomienda With
                        {
                        .fechaEnvio = txtFechaVenta.Value,
                        .UnidadVehiculo = TextUnidadVehiculo.Text,
                        .Tripulante = TextChoferTripulante.Text,
                        .TipoImpresion = "ACU"
                    }
                Tag = rutaTraeo
                Close()
            End If

        ElseIf RBHistorial.Checked = True Then
            Dim rutaTraeo As New rutaTareoEncomienda With
                        {
                        .fechaEnvio = txtFechaVenta.Value,
                        .UnidadVehiculo = TextUnidadVehiculo.Text,
                        .Tripulante = TextChoferTripulante.Text,
                        .TipoImpresion = "HIS"
                    }
            Tag = rutaTraeo
            Close()
        End If


    End Sub
#End Region
End Class