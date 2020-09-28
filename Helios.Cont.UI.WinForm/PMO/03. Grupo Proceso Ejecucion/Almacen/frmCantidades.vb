Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping

Public Class frmCantidades
    Inherits frmMaster


#Region "metodos"
    Public Sub EditarCantMaxMin()
        Dim objitem As New totalesAlmacen
        Dim totales As New totalesAlmacenRPTSA

        Try
            'objitem.idEmpresa = Gempresas.IdEmpresaRuc
            'objitem.idAlmacen = Me.dgvKardex.Table.CurrentRecord.GetValue("idalmacen")
            'objitem.idEstablecimiento = GEstableciento.IdEstablecimiento
            'objitem.idItem = Me.dgvKardex.Table.CurrentRecord.GetValue("idItem")
            'objitem.cantidadMaxima = Me.dgvKardex.Table.CurrentRecord.GetValue("cantmax")
            'objitem.cantidadMinima = Me.dgvKardex.Table.CurrentRecord.GetValue("cantmin")

            'objitem.idEmpresa = Gempresas.IdEmpresaRuc
            objitem.idMovimiento = CInt(txtidmovimiento.Text)
            'objitem.idEstablecimiento = GEstableciento.IdEstablecimiento
            objitem.idItem = CInt(txtiditem.Text)
            objitem.cantidadMaxima = CDec(txtcantmax.Text)
            objitem.cantidadMinima = CDec(txtcantmin.Text)

            totales.EditarCantMaxMin(objitem)
            'Me.lblEstado.Image = My.Resources.ok4
            'Me.lblEstado.Text = "Item registrado!"
            Dispose()

        Catch ex As Exception
            'Manejo de errores
            'lblEstado.Text = ex.Message
            'lblEstado.Image = My.Resources.warning2
        End Try
    End Sub
#End Region

    Private Sub ButtonAdv16_Click(sender As Object, e As EventArgs) Handles ButtonAdv16.Click

        If CDec(txtcantmax.Text) > CDec(txtcantmin.Text) Then
            EditarCantMaxMin()
        Else
            MessageBox.Show("La maxima cantidad debe ser mayor")
        End If
    End Sub

    'Private Sub txtcantmax_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcantmax.KeyPress
    '    If Not IsNumeric(e.KeyChar) Then
    '        e.Handled = True
    '    End If
    'End Sub

    Private Sub txtcantmax_TextChanged(sender As Object, e As EventArgs)

    End Sub

    'Private Sub txtcantmin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcantmin.KeyPress
    '    If Not IsNumeric(e.KeyChar) Then
    '        e.Handled = True
    '    End If
    'End Sub

    Private Sub txtcantmin_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub frmCantidades_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmCantidades_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dispose()
    End Sub

    Private Sub txtcantmax_KeyPress(sender As Object, e As KeyPressEventArgs)
        'If Not IsNumeric(e.KeyChar) Then
        '    e.Handled = True
        'End If
    End Sub

    Private Sub txtcantmax_TextChanged_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtcantmin_KeyPress(sender As Object, e As KeyPressEventArgs)
        'If Not IsNumeric(e.KeyChar) Then
        '    e.Handled = True
        'End If
    End Sub

    Private Sub txtcantmin_TextChanged_1(sender As Object, e As EventArgs)

    End Sub
End Class