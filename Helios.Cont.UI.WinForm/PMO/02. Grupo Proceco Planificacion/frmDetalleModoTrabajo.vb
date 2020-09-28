Imports Helios.Cont.Business.Entity
Imports Helios.General

Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmDetalleModoTrabajo

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        Dispose()
    End Sub

    Public Sub ubicarModoTrabajo()
        Dim UbicarBL As New ActividadesSA
        Dim TrabSA As New Trabajador_PLSA
        Dim Trab As New Trabajador_PL
        'UbicarBL.GetUbicaProyectoActividad(GProyectos.IdProyectoActividad, GProyectos.IdModoTrabajo)
        lblModoTrabajo.Text = UbicarBL.GetUbicaEDT(GProyectos.IdActividadTrabajo).descripcion
        Trab = TrabSA.UbicarTrabDNI(GProyectos.DirectorProyecto, GEstableciento.IdEstablecimiento)
        lblDirector.Text = Trab.appat & " " & Trab.apmat & ", " & Trab.nombres
    End Sub

End Class