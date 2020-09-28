Imports Helios.General
Imports Helios.General.Constantes.TIPO_COMPRA

Public Class frmInformeClase

    Public Mes As Date
    Public anio As Date
    Public fechaDesde As Date
    Public fechaHasta As Date

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        If (txtClase.Text.Length > 0) Then
            With frmInformeClaseReporte
                Select Case Tag
                    Case TIPO_REPORTE.FULL
                        .listaDeReporteInformePorClase(txtClase.Text)
                        .StartPosition = FormStartPosition.CenterScreen
                        .Show()
                    Case TIPO_REPORTE.ACUMULADO
                        .listaDeReporteInformePorClaseAcumulado(fechaDesde, fechaHasta, txtClase.Text)
                        .StartPosition = FormStartPosition.CenterScreen
                        .Show()
                    Case TIPO_REPORTE.PERIODO
                        .listaDeReporteInformePorClaseMes(anio, Mes, txtClase.Text)
                        .StartPosition = FormStartPosition.CenterScreen
                        .Show()
                End Select


            End With
            Me.Dispose()
        End If
    End Sub
End Class