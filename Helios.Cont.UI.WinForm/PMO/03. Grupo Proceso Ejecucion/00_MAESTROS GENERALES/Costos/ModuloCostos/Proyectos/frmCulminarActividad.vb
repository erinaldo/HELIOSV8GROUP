Imports Syncfusion.Windows.Forms.Tools
Imports Helios.Cont.Business.Entity
Imports Helios.General
'Imports Helios.Planilla.Business.Entity

Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
'Imports Helios.Planilla.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Chart
Imports Syncfusion.Drawing

Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class frmCulminarActividad
    Inherits frmMaster

    Public Property IdSesionActividad As Integer

    Private Sub frmCulminarActividad_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmCulminarActividad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtFecCierre.Value = DateTime.Now
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dim obj As New recursoCosto
        Dim costoSA As New recursoCostoSA

        obj = New recursoCosto
        obj.idCosto = IdSesionActividad
        obj.finalizaActual = txtFecCierre.Value
        obj.status = StatusCosto.Culminado
        costoSA.GetCierreActividad(obj)
        MessageBox.Show("Actividad culminada con exito!", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Dispose()
    End Sub
End Class