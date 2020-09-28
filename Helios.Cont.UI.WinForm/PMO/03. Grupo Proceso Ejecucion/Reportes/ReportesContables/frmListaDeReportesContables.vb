Imports Helios.General.Constantes

Public Class frmListaDeReportesContables

    Private Sub LinkLabel3_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        With frmModalReportesLibroDiario
            'Select Case Tag
            '    Case TIPO_REPORTE.ACUMULADO
            '        .Tag = TIPO_REPORTE.ACUMULADO

            '        .StartPosition = FormStartPosition.CenterScreen
            '        .Show()
            '    Case TIPO_REPORTE.PERIODO
            '        .Tag = TIPO_REPORTE.PERIODO
            '        .ConsultaReporte(1, 1, 1, CDate(txtFechaInicio.Value).Date, CDate(txtFechaFin.Value).Date, (dtpPeriodoMes.Value), (dtpPeriodoAnio.Value))
            '        .StartPosition = FormStartPosition.CenterScreen
            '        .Show()
            'End Select
        End With
        Me.Cursor = Cursors.Arrow
    End Sub
End Class