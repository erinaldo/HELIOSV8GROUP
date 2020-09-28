Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmListadoAportes

    Private Sub DesdeExcelToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DesdeExcelToolStripMenuItem.Click
        With frmAporteExcel
            .lblPeriodo.Text = PeriodoGeneral
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub
End Class