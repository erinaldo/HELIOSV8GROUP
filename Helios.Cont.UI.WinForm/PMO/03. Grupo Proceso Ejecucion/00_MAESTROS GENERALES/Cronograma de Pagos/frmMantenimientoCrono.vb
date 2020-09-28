Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Tools
Imports System.Collections
Imports Syncfusion.Windows.Forms.Grid
Imports System.Collections.Specialized
Imports Syncfusion.Grouping
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports System.ComponentModel

Public Class frmMantenimientoCrono

    Inherits frmMaster

#Region "metodos"

    Public Sub UpdateGasto()
        Dim LibroSA As New CronogramaSA
        Dim nDocumentoLibro As New Cronograma()


        With nDocumentoLibro

            .idCronograma = lblIdCronograma.Text
            .montoAutorizadoMN = txtImporteMN.Value
            .montoAutorizadoME = txtImporteME.Value
            .fechaoperacion = txtFecha.Value
            .fechaPago = txtfechapago.Value
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now

        End With

        LibroSA.ActualizarCronogramaHijo(nDocumentoLibro)


        Dispose()
    End Sub


#End Region

    Private Sub ButtonAdv15_Click(sender As Object, e As EventArgs) Handles ButtonAdv15.Click
        If txtImporteMN.Value > 0 Then


            UpdateGasto()

        Else
            MessageBox.Show("El monto debe se mayor a 0!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub txtImporteMN_ValueChanged(sender As Object, e As EventArgs) Handles txtImporteMN.ValueChanged
        txtImporteME.Value = txtImporteMN.Value * TmpTipoCambio
    End Sub

    Private Sub frmMantenimientoCrono_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmMantenimientoCrono_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dispose()
    End Sub
End Class