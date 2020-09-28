Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Public Class FormSeleccionarRutaPorFecha

#Region "Attributes"

#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(dgvCuentas, True, False, 10.0F)

    End Sub
#End Region

#Region "Methods"
    Public Sub GetRutasPorFecha(fecha As Date)
        Dim rutaSA As New RutaProgramacionSalidasSA
        Dim dt As New DataTable
        dt.Columns.Add("tipo")
        dt.Columns.Add("horasalida")
        dt.Columns.Add("matricula")
        dt.Columns.Add("destino")
        dt.Columns.Add("programacion_id")
        dt.Columns.Add("ruta_id")

        For Each i In rutaSA.GetProgramacionPorFechaLaboral(New rutaProgramacionSalidas With {.fechaProgramacion = fecha})
            dt.Rows.Add(If(i.tipo = "I", "SALIDA", "VUELTA"),
                        i.fechaProgramacion.Value.ToShortTimeString, "-",
                        i.CustomRutas.ciudadDestino,
                        i.programacion_id,
                        i.ruta_id)
        Next
        dgvCuentas.DataSource = dt
    End Sub


#End Region

#Region "Events"
    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        Cursor = Cursors.WaitCursor
        GetRutasPorFecha(TextFechaProgramada.Value)
        Cursor = Cursors.Default
    End Sub
#End Region

End Class