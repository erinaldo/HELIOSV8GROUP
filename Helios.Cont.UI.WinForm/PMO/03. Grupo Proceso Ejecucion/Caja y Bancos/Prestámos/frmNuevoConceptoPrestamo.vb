Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Public Class frmNuevoConceptoPrestamo

    Dim ManipulacionEstado As String

#Region "metodos"

    Dim listaCategoria As New List(Of cuentaplanContableEmpresa)
    Private Sub CMBClasificacion()
        Dim categoriaSA As New cuentaplanContableEmpresaSA
        listaCategoria = New List(Of cuentaplanContableEmpresa)
        listaCategoria = categoriaSA.ObtenerCuentasPorEmpresaConcepto(Gempresas.IdEmpresaRuc)

    End Sub

    Private Sub EditarConcepto()
        Dim documentoPrestamoSA As New servicioSA
        Dim objServicio As New servicio

        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        Dim c As New RecuperarCarteras
        Try
            With objServicio

                .idServicio = lblidconcepto.Text
                .descripcion = txtDescripcion.Text
                .cuenta = txtCuenta.Tag
                .cuentaH = txtCuentaH.Tag
                .cuentaDev = txtDevengado.Tag
                .cuentaDevH = txtDevengadoH.Tag
                .valor = txtvalor.Value
            End With

            documentoPrestamoSA.EditarConceptoPrestamo(objServicio)

            c.Cuenta = txtCuenta.Tag
            c.CuentaH = txtCuentaH.Tag
            c.Devengado = txtDevengado.Tag
            c.DevengadoH = txtDevengadoH.Tag
            c.Montomn = txtvalor.Value
            datos.Add(c)

            Dispose()
        Catch ex As Exception
            MsgBox("Error al confirmar el prestámo." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del sistema")
        End Try
    End Sub


    Private Sub SavePrestamo()
        Dim documentoPrestamoSA As New servicioSA
        Dim objServicio As New servicio

        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        Dim c As New RecuperarCarteras

        Try
            With objServicio
                .idPadre = lblidpadre.Text
                .codigo = "PH"
                .descripcion = txtDescripcion.Text
                .cuenta = txtCuenta.Tag
                .cuentaH = txtCuentaH.Tag
                .cuentaDev = txtDevengado.Tag
                .cuentaDevH = txtDevengadoH.Tag
                .observaciones = txtObservaciones.Text
                .tipo = "PO"
                .estado = "1"
                .valor = txtvalor.Value
            End With

            Dim codx As Integer = documentoPrestamoSA.GrabarConceptoPrestamo(objServicio)

            c.ID = codx
            c.Montomn = txtvalor.Value
            c.IdProceso = lblidpadre.Text
            c.NombreEntidad = txtDescripcion.Text
            c.Cuenta = txtCuenta.Tag
            c.CuentaH = txtCuentaH.Tag
            c.Devengado = txtDevengado.Tag
            c.DevengadoH = txtDevengadoH.Tag
            datos.Add(c)

            Dispose()
        Catch ex As Exception
            MsgBox("Error al confirmar el prestámo." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del sistema")
        End Try
    End Sub





#End Region

    Private Sub frmNuevoConceptoPrestamo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub
    Private Sub frmNuevoConceptoPrestamo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CMBClasificacion()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If Not txtCuenta.Text.Trim.Length > 0 Then
            MessageBox.Show("Escriba una Cuenta")
            Exit Sub
        End If

        If Not txtDescripcion.Text.Trim.Length > 0 Then
            MessageBox.Show("Escriba una Descripcion")
            Exit Sub
        End If

        If txtDescripcion.Text = "DESEMBOLSO" Then
        Else


            If lblEditor.Text = "CUENTA" Then
            Else

                If Not txtvalor.Value > 0 Then
                    MessageBox.Show("Escriba un Monto")
                    Exit Sub
                End If
            End If


        End If

            If Tag = ENTITY_ACTIONS.INSERT Then
                SavePrestamo()

            ElseIf Tag = ENTITY_ACTIONS.UPDATE Then
                EditarConcepto()
            End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dispose()
    End Sub

    Private Sub txtCuenta_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCuenta.KeyDown

        If txtDescripcion.Text = "DESEMBOLSO" Then


            If txtTipoPrestamo.Text = "PO" Then

                If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

                Else
                    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
                    Me.pcLikeCategoria.Size = New Size(396, 110)
                    Me.pcLikeCategoria.ParentControl = Me.txtCuenta
                    Me.pcLikeCategoria.ShowPopup(Point.Empty)
                    Dim consulta = (From n In listaCategoria _
                             Where n.cuenta.StartsWith(txtCuenta.Text)).ToList

                    lsvCuenta.DataSource = consulta
                    lsvCuenta.DisplayMember = "descripcion"
                    lsvCuenta.ValueMember = "cuenta"
                    'e.Handled = True
                End If

                '  If Not Me.pcLikeCategoria.IsShowing() Then

                '   End If

                '    If Not Me.pcLikeCategoria.IsShowing() Then
                If e.KeyCode = Keys.Down Then
                    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
                    Me.pcLikeCategoria.Size = New Size(396, 110)
                    Me.pcLikeCategoria.ParentControl = Me.txtCuenta
                    Me.pcLikeCategoria.ShowPopup(Point.Empty)
                    lsvCuenta.Focus()
                End If
                '   End If

                ' e.SuppressKeyPress = True
                If e.KeyCode = Keys.Escape Then
                    If Me.pcLikeCategoria.IsShowing() Then
                        Me.pcLikeCategoria.HidePopup(PopupCloseType.Canceled)
                    End If
                End If
            End If
        Else
            If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

            Else
                Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
                Me.pcLikeCategoria.Size = New Size(396, 110)
                Me.pcLikeCategoria.ParentControl = Me.txtCuenta
                Me.pcLikeCategoria.ShowPopup(Point.Empty)
                Dim consulta = (From n In listaCategoria _
                         Where n.cuenta.StartsWith(txtCuenta.Text)).ToList

                lsvCuenta.DataSource = consulta
                lsvCuenta.DisplayMember = "descripcion"
                lsvCuenta.ValueMember = "cuenta"
                'e.Handled = True
            End If

            '  If Not Me.pcLikeCategoria.IsShowing() Then

            '   End If

            '    If Not Me.pcLikeCategoria.IsShowing() Then
            If e.KeyCode = Keys.Down Then
                Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
                Me.pcLikeCategoria.Size = New Size(396, 110)
                Me.pcLikeCategoria.ParentControl = Me.txtCuenta
                Me.pcLikeCategoria.ShowPopup(Point.Empty)
                lsvCuenta.Focus()
            End If
            '   End If

            ' e.SuppressKeyPress = True
            If e.KeyCode = Keys.Escape Then
                If Me.pcLikeCategoria.IsShowing() Then
                    Me.pcLikeCategoria.HidePopup(PopupCloseType.Canceled)
                End If
            End If

        End If






        'Else

        '    If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        '    Else
        '        Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
        '        Me.pcLikeCategoria.Size = New Size(396, 110)
        '        Me.pcLikeCategoria.ParentControl = Me.txtCuenta
        '        Me.pcLikeCategoria.ShowPopup(Point.Empty)
        '        Dim consulta = (From n In listaCategoria _
        '                 Where n.cuenta.StartsWith(txtCuenta.Text)).ToList

        '        lsvCuenta.DataSource = consulta
        '        lsvCuenta.DisplayMember = "descripcion"
        '        lsvCuenta.ValueMember = "cuenta"
        '        'e.Handled = True
        '    End If

        '    '  If Not Me.pcLikeCategoria.IsShowing() Then

        '    '   End If

        '    '    If Not Me.pcLikeCategoria.IsShowing() Then
        '    If e.KeyCode = Keys.Down Then
        '        Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
        '        Me.pcLikeCategoria.Size = New Size(396, 110)
        '        Me.pcLikeCategoria.ParentControl = Me.txtCuenta
        '        Me.pcLikeCategoria.ShowPopup(Point.Empty)
        '        lsvCuenta.Focus()
        '    End If
        '    '   End If

        '    ' e.SuppressKeyPress = True
        '    If e.KeyCode = Keys.Escape Then
        '        If Me.pcLikeCategoria.IsShowing() Then
        '            Me.pcLikeCategoria.HidePopup(PopupCloseType.Canceled)
        '        End If
        '    End If

        'End If
    End Sub

    Private Sub txtCuenta_TextChanged(sender As Object, e As EventArgs) Handles txtCuenta.TextChanged



        txtCuenta.ForeColor = Color.Black
        txtCuenta.Tag = Nothing

    End Sub

    Private Sub lsvCuenta_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvCuenta.MouseDoubleClick
        Me.pcLikeCategoria.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub lsvCuenta_MouseMove(sender As Object, e As MouseEventArgs) Handles lsvCuenta.MouseMove

        Dim lb As ListBox = DirectCast(sender, ListBox)
        Dim index As Integer = lb.IndexFromPoint(e.Location)

        If index >= 0 AndAlso index < lb.Items.Count Then
            Dim toolTipString As String = lb.Items(index).ToString()

            ' check if tooltip text coincides with the current one,
            ' if so, do nothing
            If ToolTip1.GetToolTip(lb) <> toolTipString Then
                ToolTip1.SetToolTip(lb, toolTipString)
            End If

        Else
            ToolTip1.Hide(lb)
        End If
    End Sub

    Private Sub lsvCuenta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvCuenta.SelectedIndexChanged

    End Sub

    Private Sub pcLikeCategoria_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcLikeCategoria.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvCuenta.SelectedItems.Count > 0 Then
                txtCuenta.Text = lsvCuenta.Text
                txtCuenta.Tag = lsvCuenta.SelectedValue

                If txtTipoPrestamo.Text = "PR" Then
                    txtDevengadoH.Text = lsvCuenta.Text
                    txtDevengadoH.Tag = lsvCuenta.SelectedValue
                End If
                'txtSubCategoria.Clear()
                'txtCategoria.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                '' Label43.Text = "0 items"
                'Productoshijos()
            End If
        End If
        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtCuenta.Focus()
        End If
    End Sub

    Private Sub txtCuentaH_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCuentaH.KeyDown
        If txtDescripcion.Text = "DESEMBOLSO" Then

            If txtTipoPrestamo.Text = "PR" Then

                If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

                Else
                    Me.pcLikeCategoriaH.Font = New Font("Segoe UI", 8)
                    Me.pcLikeCategoriaH.Size = New Size(396, 110)
                    Me.pcLikeCategoriaH.ParentControl = Me.txtCuentaH
                    Me.pcLikeCategoriaH.ShowPopup(Point.Empty)
                    Dim consulta = (From n In listaCategoria _
                             Where n.cuenta.StartsWith(txtCuentaH.Text)).ToList

                    lsvCuentaH.DataSource = consulta
                    lsvCuentaH.DisplayMember = "descripcion"
                    lsvCuentaH.ValueMember = "cuenta"

                End If


                If e.KeyCode = Keys.Down Then
                    Me.pcLikeCategoriaH.Font = New Font("Segoe UI", 8)
                    Me.pcLikeCategoriaH.Size = New Size(396, 110)
                    Me.pcLikeCategoriaH.ParentControl = Me.txtCuentaH
                    Me.pcLikeCategoriaH.ShowPopup(Point.Empty)
                    lsvCuentaH.Focus()
                End If
                '   End If

                ' e.SuppressKeyPress = True
                If e.KeyCode = Keys.Escape Then
                    If Me.pcLikeCategoriaH.IsShowing() Then
                        Me.pcLikeCategoriaH.HidePopup(PopupCloseType.Canceled)
                    End If
                End If
            End If


        Else


            If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

            Else
                Me.pcLikeCategoriaH.Font = New Font("Segoe UI", 8)
                Me.pcLikeCategoriaH.Size = New Size(396, 110)
                Me.pcLikeCategoriaH.ParentControl = Me.txtCuentaH
                Me.pcLikeCategoriaH.ShowPopup(Point.Empty)
                Dim consulta = (From n In listaCategoria _
                         Where n.cuenta.StartsWith(txtCuentaH.Text)).ToList

                lsvCuentaH.DataSource = consulta
                lsvCuentaH.DisplayMember = "descripcion"
                lsvCuentaH.ValueMember = "cuenta"

            End If


            If e.KeyCode = Keys.Down Then
                Me.pcLikeCategoriaH.Font = New Font("Segoe UI", 8)
                Me.pcLikeCategoriaH.Size = New Size(396, 110)
                Me.pcLikeCategoriaH.ParentControl = Me.txtCuentaH
                Me.pcLikeCategoriaH.ShowPopup(Point.Empty)
                lsvCuentaH.Focus()
            End If
            '   End If

            ' e.SuppressKeyPress = True
            If e.KeyCode = Keys.Escape Then
                If Me.pcLikeCategoriaH.IsShowing() Then
                    Me.pcLikeCategoriaH.HidePopup(PopupCloseType.Canceled)
                End If
            End If
        End If
    End Sub

    Private Sub txtCuentaH_TextChanged(sender As Object, e As EventArgs) Handles txtCuentaH.TextChanged
       
            txtCuentaH.ForeColor = Color.Black
            txtCuentaH.Tag = Nothing


    End Sub

    Private Sub txtDevengado_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDevengado.KeyDown
        If txtTipoPrestamo.Text = "PR" Then
            If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

            Else
                Me.pcLikeDevengado.Font = New Font("Segoe UI", 8)
                Me.pcLikeDevengado.Size = New Size(396, 110)
                Me.pcLikeDevengado.ParentControl = Me.txtDevengado
                Me.pcLikeDevengado.ShowPopup(Point.Empty)
                Dim consulta = (From n In listaCategoria _
                         Where n.cuenta.StartsWith(txtDevengado.Text)).ToList

                lsvDevengado.DataSource = consulta
                lsvDevengado.DisplayMember = "descripcion"
                lsvDevengado.ValueMember = "cuenta"
                'e.Handled = True
            End If

            '  If Not Me.pcLikeCategoria.IsShowing() Then

            '   End If

            '    If Not Me.pcLikeCategoria.IsShowing() Then
            If e.KeyCode = Keys.Down Then
                Me.pcLikeDevengado.Font = New Font("Segoe UI", 8)
                Me.pcLikeDevengado.Size = New Size(396, 110)
                Me.pcLikeDevengado.ParentControl = Me.txtDevengado
                Me.pcLikeDevengado.ShowPopup(Point.Empty)
                lsvDevengado.Focus()
            End If
            '   End If

            ' e.SuppressKeyPress = True
            If e.KeyCode = Keys.Escape Then
                If Me.pcLikeDevengado.IsShowing() Then
                    Me.pcLikeDevengado.HidePopup(PopupCloseType.Canceled)
                End If
            End If
        End If
    End Sub

    Private Sub txtCuentaDevengado_TextChanged(sender As Object, e As EventArgs) Handles txtDevengado.TextChanged
        If txtTipoPrestamo.Text = "PR" Then
            txtDevengado.ForeColor = Color.Black
            txtDevengado.Tag = Nothing
        End If
    End Sub

    Private Sub txtDevengadoH_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDevengadoH.KeyDown
        If txtTipoPrestamo.Text = "PO" Then
            If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

            Else
                Me.pcLikeDevengadoH.Font = New Font("Segoe UI", 8)
                Me.pcLikeDevengadoH.Size = New Size(396, 110)
                Me.pcLikeDevengadoH.ParentControl = Me.txtDevengadoH
                Me.pcLikeDevengadoH.ShowPopup(Point.Empty)
                Dim consulta = (From n In listaCategoria _
                         Where n.cuenta.StartsWith(txtDevengadoH.Text)).ToList

                lsvDevengadoH.DataSource = consulta
                lsvDevengadoH.DisplayMember = "descripcion"
                lsvDevengadoH.ValueMember = "cuenta"

            End If


            If e.KeyCode = Keys.Down Then
                Me.pcLikeDevengadoH.Font = New Font("Segoe UI", 8)
                Me.pcLikeDevengadoH.Size = New Size(396, 110)
                Me.pcLikeDevengadoH.ParentControl = Me.txtDevengadoH
                Me.pcLikeDevengadoH.ShowPopup(Point.Empty)
                lsvDevengadoH.Focus()
            End If
            '   End If

            ' e.SuppressKeyPress = True
            If e.KeyCode = Keys.Escape Then
                If Me.pcLikeDevengadoH.IsShowing() Then
                    Me.pcLikeDevengadoH.HidePopup(PopupCloseType.Canceled)
                End If
            End If
        End If
    End Sub

    Private Sub txtCuentaDevengadoH_TextChanged(sender As Object, e As EventArgs) Handles txtDevengadoH.TextChanged
        If txtTipoPrestamo.Text = "PO" Then
            txtDevengadoH.ForeColor = Color.Black
            txtDevengadoH.Tag = Nothing
        End If
    End Sub

    Private Sub lsvCuentaH_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvCuentaH.MouseDoubleClick
        Me.pcLikeCategoriaH.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub lsvCuentaH_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvCuentaH.SelectedIndexChanged

    End Sub

    Private Sub pcLikeCategoriaH_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcLikeCategoriaH.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvCuentaH.SelectedItems.Count > 0 Then
                txtCuentaH.Text = lsvCuentaH.Text
                txtCuentaH.Tag = lsvCuentaH.SelectedValue

                If txtTipoPrestamo.Text = "PO" Then
                    txtDevengado.Text = lsvCuentaH.Text
                    txtDevengado.Tag = lsvCuentaH.SelectedValue
                End If
                'txtSubCategoria.Clear()
                'txtCategoria.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                '' Label43.Text = "0 items"
                'Productoshijos()
            End If
        End If
        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtCuentaH.Focus()
        End If
    End Sub

    Private Sub lsvDevengado_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvDevengado.MouseDoubleClick
        Me.pcLikeDevengado.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub lsvDevengado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvDevengado.SelectedIndexChanged

    End Sub

    Private Sub pcLikeDevengado_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcLikeDevengado.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvDevengado.SelectedItems.Count > 0 Then
                txtDevengado.Text = lsvDevengado.Text
                txtDevengado.Tag = lsvDevengado.SelectedValue
                'txtSubCategoria.Clear()
                'txtCategoria.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                '' Label43.Text = "0 items"
                'Productoshijos()
            End If
        End If
        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtDevengado.Focus()
        End If
    End Sub

    Private Sub lsvDevengadoH_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvDevengadoH.MouseDoubleClick
        Me.pcLikeDevengadoH.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub lsvDevengadoH_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvDevengadoH.SelectedIndexChanged

    End Sub

    Private Sub pcLikeDevengadoH_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcLikeDevengadoH.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvDevengadoH.SelectedItems.Count > 0 Then
                txtDevengadoH.Text = lsvDevengadoH.Text
                txtDevengadoH.Tag = lsvDevengadoH.SelectedValue
                'txtSubCategoria.Clear()
                'txtCategoria.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                '' Label43.Text = "0 items"
                'Productoshijos()
            End If
        End If
        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtDevengadoH.Focus()
        End If
    End Sub
End Class