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
Public Class frmTipoCambio
    Inherits frmMaster

#Region "Métodos"

    Private Sub ObtenerTipoCambioMax()
        Dim tipoCambioSA As New tipoCambioSA
        Dim tipoCambio As New tipoCambio

        tipoCambio = tipoCambioSA.GetListaTipoCambioMaxFecha(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
        If Not IsNothing(tipoCambio.usuarioModificacion) Then
            With tipoCambio
                'txtFechaIgv.Value = .fechaIgv
                txtFechaIgv.Value = DateTime.Now
                nudTipoCambioCompra.Value = .compra
                nudTipoCambio.Value = .venta
            End With
        Else
            txtFechaIgv.Value = DateTime.Now
            nudTipoCambioCompra.Value = 0
            nudTipoCambio.Value = 0
        End If
    End Sub



    Private Sub Grabar()
        Dim tipoCambioSA As New tipoCambioSA
        Dim tipoCambio As New tipoCambio
        Try
            tipoCambio = New tipoCambio
            With tipoCambio
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idRegulador = 100
                .fechaIgv = txtFechaIgv.Value
                .compra = nudTipoCambioCompra.Value
                .venta = nudTipoCambio.Value
                .usuarioModificacion = usuario.IDUsuario
                .fechaModificacion = DateTime.Now
            End With
            tipoCambioSA.InsertTC(tipoCambio)
            Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub CambiarTipoCambio()
        Dim tipoCambioSA As New tipoCambioSA
        Dim tipoCambio As New tipoCambio

        With tipoCambio
            .idRegulador = 100
            .fechaIgv = txtFechaIgv.Value
            .compra = nudTipoCambioCompra.Value
            .venta = nudTipoCambio.Value
            .usuarioModificacion = "Jiuni"
            .fechaModificacion = DateTime.Now
        End With
        tipoCambioSA.CambiarTipoCambio(tipoCambio)

        TmpTipoCambio = nudTipoCambio.Value

        'nudTipoCambioCompra.Value = .compra
        'nudTipoCambio.Value = .venta

        Dispose()
    End Sub


#End Region

    Private Sub frmTipoCambio_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmTipoCambio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ObtenerTipoCambioMax()
    End Sub

    Private Sub SaveToolStripButton_Click(sender As Object, e As EventArgs) Handles SaveToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        If Not nudTipoCambioCompra.Value > 0 Then
            MessageBoxAdv.Show("Ingrese un valor de compra > a cero!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            nudTipoCambioCompra.Focus()
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If
        If Not nudTipoCambio.Value > 0 Then
            MessageBoxAdv.Show("Ingrese un valor de venta > a cero!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            nudTipoCambio.Focus()
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        If txtCambio.Text = "Cambio" Then

            CambiarTipoCambio()

        Else
            Grabar()
        End If


        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStrip3_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip3.ItemClicked

    End Sub


    Private Sub txtFechaIgv_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaIgv.ValueChanged
        'If IsDate(txtFechaIgv.Value) Then
        '    If txtFechaIgv.Value.Date > DiaLaboral.Date Then
        '        txtFechaIgv.Value = DiaLaboral
        '        MessageBox.Show("Debe respetar la fecha laboral o fechas inferiores a esta.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    End If
        'End If
    End Sub
End Class