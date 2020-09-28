Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Drawing

Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Imports System.ComponentModel

Public Class FrmAddServicio

    Inherits frmMaster

#Region "metodos"

    Public Sub GrabarServicioPadre()
        Dim objitem As New servicio
        Dim servicioSA As New servicioSA

        Try

            'objitem.codigo = "P"
            objitem.codigo = txttipo.Text
            objitem.descripcion = txtServicioNew.Text


            If txttipo.Text = "PC" Then
                objitem.cuenta = cbocuenta.Text
            End If

            If txtObservaciones.Text.Trim.Length > 0 Then
                objitem.observaciones = txtObservaciones.Text
            Else
                objitem.observaciones = Nothing
            End If

            objitem.estado = "1"

            servicioSA.GrabarServicioPadre(objitem)
            '  Dim codxIdtem As Integer = servicioSA.GrabarServicioPadre(objitem)
            'Me.lblEstado.Image = My.Resources.ok4
            'Me.lblEstado.Text = "Item registrado!"

            Dispose()



        Catch ex As Exception
            'Manejo de errores
            'lblEstado.Text = ex.Message
            'lblEstado.Image = My.Resources.warning2
        End Try
    End Sub


    Public Sub EditarServicioPadre(idservicio As Integer)
        Dim objitem As New servicio
        Dim servicioSA As New servicioSA
        Try
            objitem.idServicio = idservicio
            objitem.descripcion = txtServicioNew.Text
            objitem.observaciones = txtObservaciones.Text
            servicioSA.EditarServicioPadre(objitem)
            Dispose()
        Catch ex As Exception
            'Manejo de errores
            'lblEstado.Text = ex.Message
            'lblEstado.Image = My.Resources.warning2
        End Try
    End Sub

#End Region

    Private Sub FrmAddServicio_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub FrmAddServicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If txttipo.Text = "PC" Then
            cbocuenta.Visible = True
            Label3.Visible = True
        End If
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs)
        Dispose()
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dispose()
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click





        Me.Cursor = Cursors.WaitCursor
        If cbocuenta.Text.Trim.Length > 0 Then
            If txtServicioNew.Text.Trim.Length > 0 Then
                If Tag = "editar" Then
                    If txtidservicio.Text.Trim.Length > 0 Then
                        EditarServicioPadre(txtidservicio.Text)
                    End If
                Else

                    GrabarServicioPadre()

                End If
            Else
                MessageBoxAdv.Show("Debe ingresar una descripción para el servicio padre!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
        Me.Cursor = Cursors.Arrow






    End Sub
End Class