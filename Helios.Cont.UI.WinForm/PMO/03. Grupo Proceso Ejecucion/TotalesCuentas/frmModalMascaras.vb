Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms.Tools

Public Class frmModalMascaras
    Inherits RibbonForm

    Sub GrabarMercaderia()
        Dim intTipoExistencia As String = Nothing
        Dim intIdRecursoActividad As Integer
        Dim mascaraContable2SA As New mascaraContable2SA
        Dim mascaraContable2 As New mascaraContable2

        Try
            Select Case cboTipoExistencia.Text
                Case "MERCADERIA"
                    intTipoExistencia = "01"
            End Select

            mascaraContable2 = New mascaraContable2 With {
                           .Action = Business.Entity.BaseBE.EntityAction.INSERT,
                           .idEmpresa = Gempresas.IdEmpresaRuc,
                           .tipoExistencia = intTipoExistencia,
                           .cuentaCompra = txtCuentaPadre.Text,
                           .descripcionCompra = txtDescripcionCuentaPadre.Text,
                           .asientoCompra = "D",
                           .destinoCompra = txtCuentaCC.Text,
                           .descripcionDestino = txtDescripcionCC.Text,
                           .asientoDestino = "D",
                           .destinoCompra2 = txtCuentaCC2.Text,
                           .descripcionDestino2 = txtDescripcionCC2.Text,
                           .asientoDestino2 = "H",
                            .cuentaDestinoKardex = txtCuentaCCredTransito.Text,
                            .nameDestinoKardex = txtDescripCCredTransito.Text,
                            .asientoDestinoKardex = "D"}

            intIdRecursoActividad = mascaraContable2SA.InsertarMascaraSingle(mascaraContable2)
            If intIdRecursoActividad <> Nothing Then
                lblEstado.Text = "cuenta registrado"
                lblEstado.Image = My.Resources.ok4
            Else
                lblEstado.Text = "Error al grabar Cadena!"
                lblEstado.Image = My.Resources.cross
            End If
            Dispose()

        Catch ex As Exception
            lblEstado.Text = "Error al grabar la cuenta" & vbCrLf & ex.Message
            lblEstado.Image = My.Resources.cross
        End Try
    End Sub

    Sub GrabarOtros()
        Dim intTipoExistencia As String = Nothing
        Dim intIdRecursoActividad As Integer
        Dim mascaraContableExistenciaSA As New mascaraContableExistenciaSA
        Dim mascaraContableExistencia As New mascaraContableExistencia
        Try

            Select Case cboTipoExistencia.Text
                Case "MATERIA PRIMA"
                    intTipoExistencia = "03"
                Case "ENVASES Y EMBALAJES"
                    intTipoExistencia = "04"
                Case "MATERIALES AUXILIARES, SUMINISTROS Y RESPUESTOS"
                    intTipoExistencia = "05"
            End Select

            mascaraContableExistencia = New mascaraContableExistencia With {
                      .Action = Business.Entity.BaseBE.EntityAction.INSERT,
                        .idEmpresa = Gempresas.IdEmpresaRuc,
                        .tipoExistencia = intTipoExistencia,
                        .cuentaCompra = txtCuentaPadre.Text,
                        .descripcionCompra = txtDescripcionCuentaPadre.Text,
                        .asientoCompra = "D",
                        .destinoCompra = txtCuentaCC.Text,
                        .descripcionDestino = txtDescripcionCC.Text,
                        .asientoDestino = "D",
                        .destinoCompra2 = txtCuentaCC2.Text,
                        .descripcionDestino2 = txtDescripcionCC2.Text,
                        .asientoDestino2 = "H",
                        .cuentaIngAlmacen = txtCuentaCCredTransito.Text,
                        .nameIngAlmacen = txtDescripCCredTransito.Text,
                        .asientoIngAlmacen = "D",
                        .cuentaSalida = txtCuentaCCredTransito2.Text,
                        .descripcionSalida = txtDescripCCredTransito2.Text,
                        .asientoSalida = "D"}
            intIdRecursoActividad = mascaraContableExistenciaSA.InsertMascaraContableExistenciaSingle(mascaraContableExistencia)
            If intIdRecursoActividad <> Nothing Then
                lblEstado.Text = "cuenta registrado"
                lblEstado.Image = My.Resources.ok4
            Else
                lblEstado.Text = "Error al grabar Cadena!"
                lblEstado.Image = My.Resources.cross
            End If
            Dispose()

        Catch ex As Exception
            lblEstado.Text = "Error al grabar la cuenta" & vbCrLf & ex.Message
            lblEstado.Image = My.Resources.cross
        End Try
    End Sub

    Sub EditarMercaderia()
        Dim intTipoExistencia As String = Nothing
        Dim intIdRecursoActividad As Integer
        Dim mascaraContable2SA As New mascaraContable2SA
        Dim mascaraContable2 As New mascaraContable2

        Try
            Select Case cboTipoExistencia.Text
                Case "MERCADERIA"
                    intTipoExistencia = "01"
            End Select

            mascaraContable2 = New mascaraContable2 With {
                           .Action = Business.Entity.BaseBE.EntityAction.INSERT,
                           .idEmpresa = Gempresas.IdEmpresaRuc,
                           .tipoExistencia = intTipoExistencia,
                           .cuentaCompra = txtCuentaPadre.Text,
                           .descripcionCompra = txtDescripcionCuentaPadre.Text,
                           .asientoCompra = "D",
                           .destinoCompra = txtCuentaCC.Text,
                           .descripcionDestino = txtDescripcionCC.Text,
                           .asientoDestino = "D",
                           .destinoCompra2 = txtCuentaCC2.Text,
                           .descripcionDestino2 = txtDescripcionCC2.Text,
                           .asientoDestino2 = "H",
                            .cuentaDestinoKardex = txtCuentaCCredTransito.Text,
                            .nameDestinoKardex = txtDescripCCredTransito.Text,
                            .asientoDestinoKardex = "D"}

            intIdRecursoActividad = mascaraContable2SA.UpdateMascaraContable2(mascaraContable2)
            If intIdRecursoActividad <> Nothing Then
                lblEstado.Text = "cuenta actualizada"
                lblEstado.Image = My.Resources.ok4
            Else
                lblEstado.Text = "Error al actualizar cadena!"
                lblEstado.Image = My.Resources.cross
            End If
            Dispose()

        Catch ex As Exception
            lblEstado.Text = "Error al actualizar la cuenta" & vbCrLf & ex.Message
            lblEstado.Image = My.Resources.cross
        End Try
    End Sub

    Sub EditarOtros()
        Dim intTipoExistencia As String = Nothing
        Dim cuentaplanContableEmpresaSA As New cuentaplanContableEmpresaSA
        Dim cuentaplanContableEmpresa As New cuentaplanContableEmpresa
        Dim intIdRecursoActividad As Integer
        Dim mascaraContableExistenciaSA As New mascaraContableExistenciaSA
        Dim mascaraContableExistencia As New mascaraContableExistencia
        Try
            Select Case cboTipoExistencia.Text
                Case "MATERIA PRIMA"
                    intTipoExistencia = "03"
                Case "ENVASES Y EMBALAJES"
                    intTipoExistencia = "04"
                Case "MATERIALES AUXILIARES, SUMINISTROS Y RESPUESTOS"
                    intTipoExistencia = "05"
            End Select

            mascaraContableExistencia = New mascaraContableExistencia With {
                        .Action = Business.Entity.BaseBE.EntityAction.INSERT,
                        .idEmpresa = Gempresas.IdEmpresaRuc,
                        .tipoExistencia = intTipoExistencia,
                        .cuentaCompra = txtCuentaPadre.Text,
                        .descripcionCompra = txtDescripcionCuentaPadre.Text,
                        .asientoCompra = "D",
                        .destinoCompra = txtCuentaCC.Text,
                        .descripcionDestino = txtDescripcionCC.Text,
                        .asientoDestino = "D",
                        .destinoCompra2 = txtCuentaCC2.Text,
                        .descripcionDestino2 = txtDescripcionCC2.Text,
                        .asientoDestino2 = "H",
                        .cuentaIngAlmacen = txtCuentaCCredTransito.Text,
                        .nameIngAlmacen = txtDescripCCredTransito.Text,
                        .asientoIngAlmacen = "D",
                        .cuentaSalida = txtCuentaCCredTransito2.Text,
                        .descripcionSalida = txtDescripCCredTransito2.Text,
                        .asientoSalida = "D"}
            intIdRecursoActividad = mascaraContableExistenciaSA.UpdateMascaraContableExistenciaSingle(mascaraContableExistencia)
            If intIdRecursoActividad <> Nothing Then
                lblEstado.Text = "cuenta registrado"
                lblEstado.Image = My.Resources.ok4
            Else
                lblEstado.Text = "Error al grabar Cadena!"
                lblEstado.Image = My.Resources.cross
            End If
            Dispose()

        Catch ex As Exception
            lblEstado.Text = "Error al grabar la cuenta" & vbCrLf & ex.Message
            lblEstado.Image = My.Resources.cross
        End Try
    End Sub

    Private Sub cboTipoExistencia_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTipoExistencia.SelectedIndexChanged
        If (cboTipoExistencia.SelectedItem = "MERCADERIA") Then
            txtCuentaCCredTransito2.Enabled = False
            txtDescripCCredTransito2.Enabled = False
            lblEstado.Text = "Estado: nueva venta."
        Else
            txtCuentaCCredTransito2.Enabled = True
            txtDescripCCredTransito2.Enabled = True
            txtCuentaCCredTransito2.Clear()
            txtDescripCCredTransito2.Clear()
            lblEstado.Text = "Estado: nueva venta."
        End If
    End Sub

    Private Sub txtCuentaPadre_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCuentaPadre.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtDescripcionCuentaPadre.Select()
            txtDescripcionCuentaPadre.Focus()
            lblEstado.Text = "Estado: nueva venta."
        End If
    End Sub

    Private Sub txtDescripcionCuentaPadre_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDescripcionCuentaPadre.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtCuentaCC.Select()
            txtCuentaCC.Focus()
            lblEstado.Text = "Estado: nueva venta."
        End If
    End Sub

    Private Sub txtCuentaCC_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCuentaCC.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtDescripcionCC.Select()
            txtDescripcionCC.Focus()
            lblEstado.Text = "Estado: nueva venta."
        End If
    End Sub

    Private Sub txtDescripcionCC_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDescripcionCC.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtCuentaCC2.Select()
            txtCuentaCC2.Focus()
            lblEstado.Text = "Estado: nueva venta."
        End If
    End Sub

    Private Sub txtCuentaCC2_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCuentaCC2.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtDescripcionCC2.Select()
            txtDescripcionCC2.Focus()
            lblEstado.Text = "Estado: nueva venta."
            If (cboTipoExistencia.SelectedItem = "MERCADERIA") Then
                txtCuentaCCredTransito2.Text = txtCuentaCC2.Text
            End If
        End If
    End Sub

    Private Sub txtDescripcionCC2_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDescripcionCC2.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtCuentaCCredTransito.Select()
            txtCuentaCCredTransito.Focus()
            lblEstado.Text = "Estado: nueva venta."
            If (cboTipoExistencia.SelectedItem = "MERCADERIA") Then
                txtDescripCCredTransito2.Text = txtDescripcionCC2.Text
            End If
        End If
    End Sub

    Private Sub txtCuentaCCredTransito_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCuentaCCredTransito.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtDescripCCredTransito.Select()
            txtDescripCCredTransito.Focus()
            lblEstado.Text = "Estado: nueva venta."
        End If
    End Sub

    Private Sub txtDescripCCredTransito_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDescripCCredTransito.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtCuentaCCredTransito2.Select()
            txtCuentaCCredTransito2.Focus()
            lblEstado.Text = "Estado: nueva venta."
        End If
    End Sub

    Private Sub txtCuentaCCredTransito2_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCuentaCCredTransito2.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtDescripCCredTransito2.Select()
            txtDescripCCredTransito2.Focus()
            lblEstado.Text = "Estado: nueva venta."
        End If
    End Sub

    Private Sub txtCuentaPadre_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCuentaPadre.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtCuentaCC_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCuentaCC.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtCuentaCC2_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCuentaCC2.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtCuentaCCredTransito_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCuentaCCredTransito.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtCuentaCCredTransito2_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCuentaCCredTransito2.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Function ValidarCajasMascaras() As Boolean

        If (cboTipoExistencia.Text.Length = 0 Or txtCuentaPadre.Text.Length = 0 Or txtDescripcionCuentaPadre.Text.Length = 0 Or txtCuentaCC.Text.Length = 0 _
             Or txtDescripcionCC.Text.Length = 0 Or txtCuentaCC2.Text.Length = 0 Or txtCuentaCC2.Text.Length = 0 _
             Or txtDescripcionCC2.Text.Length = 0 Or txtCuentaCCredTransito.Text.Length = 0 Or txtDescripCCredTransito.Text.Length = 0 _
             Or txtCuentaCCredTransito2.Text.Length = 0 Or txtDescripCCredTransito2.Text.Length = 0) Then
            lblEstado.Text = "Debe ingresar todos los campos"
            Return False
        Else
            Return True
            lblEstado.Text = "Estado: nueva venta."
        End If
    End Function

    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        With frmMovimientoMascaras
            If (Tag = "INSERT") Then
                Select Case cboTipoExistencia.Text
                    Case "MERCADERIA"
                        If (ValidarCajasMascaras() = True) Then
                            GrabarMercaderia()
                            .CargarMascaras()
                            .Dispose()
                        End If
                    Case "MATERIA PRIMA"
                        If (ValidarCajasMascaras() = True) Then
                            GrabarOtros()
                            .CargarMascaras()
                            .Dispose()
                        End If
                    Case "ENVASES Y EMBALAJES"
                        If (ValidarCajasMascaras() = True) Then
                            GrabarOtros()
                            .CargarMascaras()
                            .Dispose()
                        End If
                    Case "MATERIALES AUXILIARES, SUMINISTROS Y RESPUESTOS"
                        If (ValidarCajasMascaras() = True) Then
                            GrabarOtros()
                            .CargarMascaras()
                            .Dispose()
                        End If
                    Case ""
                        lblEstado.Text = "Debe ingresar tipo de existencia"
                End Select
            ElseIf (Tag = "UPDATE") Then
                Select Case cboTipoExistencia.Text
                    Case "MERCADERIA"
                        If (ValidarCajasMascaras() = True) Then
                            EditarMercaderia()
                            .CargarMascaras()
                            .Dispose()
                        End If
                    Case "MATERIA PRIMA"
                        If (ValidarCajasMascaras() = True) Then
                            EditarOtros()
                            .CargarMascaras()
                            .Dispose()
                        End If
                    Case "ENVASES Y EMBALAJES"
                        If (ValidarCajasMascaras() = True) Then
                            EditarOtros()
                            .CargarMascaras()
                            .Dispose()
                        End If
                    Case "MATERIALES AUXILIARES, SUMINISTROS Y RESPUESTOS"
                        If (ValidarCajasMascaras() = True) Then
                            EditarOtros()
                            .CargarMascaras()
                            .Dispose()
                        End If
                    Case ""
                        lblEstado.Text = "Debe ingresar tipo de existencia"
                End Select
            End If

        End With
        Me.Cursor = Cursors.Arrow
    End Sub
End Class