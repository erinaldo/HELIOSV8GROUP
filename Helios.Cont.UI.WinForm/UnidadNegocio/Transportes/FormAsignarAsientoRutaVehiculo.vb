Imports Helios.General
Imports Helios.Cont.Business.Entity
Public Class FormAsignarAsientoRutaVehiculo

#Region "Attributes"

#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(GridRutas, False, False, 10.0F)
    End Sub
#End Region

#Region "Methods"

#End Region

#Region "Events"
    Private Sub RoundButton22_Click(sender As Object, e As EventArgs) Handles RoundButton22.Click
        RegistrarPrecios()
    End Sub

    Private Sub RegistrarPrecios()
        Dim precio As vehiculoAsiento_Precios

        For Each i In GridRutas.Table.Records
            precio = New vehiculoAsiento_Precios

        Next


    End Sub
#End Region

End Class