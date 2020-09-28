Public Class frmEstadosFinancieros

    Private Sub LinkLabel6_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        Dim f As New FrmReporteCajaBanco
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub LinkLabel7_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel7.LinkClicked
        Dim f As New frmReporteCuentasXCobrar
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub LinkLabel8_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel8.LinkClicked
        Dim f As New frmReporteCuentasXPagar
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Dim f As New frmReporteSaldoMercaderia
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Dim f As New frmReporteServicioOtroAnticipado
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub
End Class