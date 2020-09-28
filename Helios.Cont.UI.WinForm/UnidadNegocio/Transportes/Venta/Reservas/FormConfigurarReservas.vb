Imports System.IO
Imports System.Net
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports ProcesosGeneralesCajamiSoft
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports HtmlAgilityPack
Imports System.Net.Http
Imports Helios.Cont.Business.Logic

Public Class FormConfigurarReservas

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        pnBuscardor.Visible = True
        btnReserva.Visible = True
    End Sub

    Private Sub BtnReserva_Click(sender As Object, e As EventArgs) Handles btnReserva.Click
        Dim f As New FormNuevoReserva()
        'f.programacion_ID = programacion_ID
        'f.placaBus = txtNombreBus.Tag
        f.pnBuscardor.Visible = True
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
    End Sub
End Class