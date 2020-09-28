Imports System.ComponentModel
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.Business.Entity
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Tools
Imports System.IO
Imports System.Reflection

Public Class frmMaestroProyectos
    Private Sub LinkLabel30_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel30.LinkClicked
        Dim f As New frmMantenimientoProyectos
        f.Size = New Size(1240, 550)
        f.StartPosition = FormStartPosition.CenterParent

        f.LinkLabel2.Visible = False
        f.LinkLabel3.Visible = False


        f.ShowDialog()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim f As New frmControlDeProyectos
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Dim f As New frmCentroCostosV2
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub



    Private Sub frmMaestroProyectos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub LinkLabel6_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        With frmTransferenciaProduccion
            .lblPerido.Text = PeriodoGeneral
            .lblMovimiento.Text = "TRANSFERENCIA ENTRE ALMACENES"
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        With frmTransferenciaGasto
            .lblPerido.Text = PeriodoGeneral
            .lblMovimiento.Text = "TRANSFERENCIA ENTRE ALMACENES"
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub

    Private Sub LinkLabel7_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel7.LinkClicked
        Dim f As New frmHojaDeCosto
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel8_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel8.LinkClicked
        Dim f As New frmAsignaciondeServicios
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel9_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel9.LinkClicked
        Dim f As New frmMantenimientoProyectos
        f.Size = New Size(1240, 550)
        f.StartPosition = FormStartPosition.CenterParent

        f.LinkLabel30.Visible = False
        f.LinkLabel1.Visible = False
        f.LinkLabel2.Visible = False     'ENVIO ALMACEN
        f.LinkLabel3.Visible = True
        f.LinkLabel4.Visible = False

        f.ShowDialog()
    End Sub

    Private Sub LinkLabel10_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel10.LinkClicked
        Dim f As New frmMantenimientoProyectos
        f.Size = New Size(1240, 550)
        f.StartPosition = FormStartPosition.CenterParent
        f.LinkLabel30.Visible = False
        f.LinkLabel1.Visible = False
        f.LinkLabel2.Visible = True      'ENVIO ALMACEN
        f.LinkLabel3.Visible = False
        f.LinkLabel4.Visible = False
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel11_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel11.LinkClicked
        Dim f As New frmReconocimientoGenerados


        'f.txtProyectoGeneral.Text = Me.dgvEntregables.Table.CurrentRecord.GetValue("Proyecto")
        'f.txtSubProyecto.Text = Me.dgvEntregables.Table.CurrentRecord.GetValue("Subproyecto")
        'f.lblidEntregable.Text = CInt(Me.dgvEntregables.Table.CurrentRecord.GetValue("idEntregable"))
        'f.txtEntregable.Text = Me.dgvEntregables.Table.CurrentRecord.GetValue("Entregable")

        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub
End Class