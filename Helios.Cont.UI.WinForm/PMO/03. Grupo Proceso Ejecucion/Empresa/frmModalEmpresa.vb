Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.GridHelperClasses
Imports PopupControl
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Public Class frmModalEmpresa
    Inherits frmMaster

#Region "Métodos"
    Public Sub Grabar()
        Dim empresaBE As New empresa
        Dim empresaSA As New empresaSA
        With empresaBE
            .idEmpresa = txtRuc.Text.Trim
            .razonSocial = txtRazon.Text.Trim
            .nombreCorto = txtNomCorto.Text.Trim
            .ruc = txtRuc.Text.Trim
            If txtDomicilio.Text.Trim.Length > 0 Then
                .direccion = txtDomicilio.Text.Trim
            Else
                .direccion = Nothing
            End If

            If txtFono.Text.Trim.Length > 0 Then
                .telefono = txtFono.Text.Trim
            Else
                .telefono = Nothing
            End If

            If txtActividad.Text.Trim.Length > 0 Then
                .actividad = txtActividad.Text.Trim
            Else
                .actividad = Nothing
            End If

            If cboRegimen.Text.Trim.Length > 0 Then
                .regimen = cboRegimen.Text.Trim
            Else
                .regimen = Nothing
            End If
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        'empresaSA.InsertarEmpresa(empresaBE)
        Dispose()
    End Sub
#End Region

    Private Sub frmModalEmpresa_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmModalEmpresa_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SaveToolStripButton_Click(sender As Object, e As EventArgs) Handles SaveToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        Grabar()
        Me.Cursor = Cursors.Arrow
    End Sub
End Class