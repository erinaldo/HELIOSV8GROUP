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

Public Class frmNuevoTipoPrestamo


#Region "Metodos"


   


    Dim listaCategoria As New List(Of cuentaplanContableEmpresa)
    Private Sub CMBClasificacion()
        Dim categoriaSA As New cuentaplanContableEmpresaSA
        listaCategoria = New List(Of cuentaplanContableEmpresa)
        listaCategoria = categoriaSA.ObtenerCuentasPorEmpresaConcepto(Gempresas.IdEmpresaRuc)

    End Sub




    Public Sub EditarServicioPadre(idservicio As Integer)
        Dim objitem As New servicio
        Dim servicioSA As New servicioSA
        Try
            objitem.idServicio = idservicio
            objitem.descripcion = txtServicioNew.Text
            'objitem.cuenta = txtCuenta.Tag
            ' If ComboBox1.Text = "DEBE" Then
            'objitem.tipo = "D"
            'ElseIf ComboBox1.Text = "HABER" Then
            'objitem.tipo = "H"
            'End If

            servicioSA.EditarTipoPrestamo(objitem)
            Dispose()
        Catch ex As Exception
            'Manejo de errores
            'lblEstado.Text = ex.Message
            'lblEstado.Image = My.Resources.warning2
        End Try
    End Sub


    Public Sub GrabarServicioPadre()
        Dim objitem As New servicio
        Dim servicioSA As New servicioSA
        Dim lista As New List(Of servicio)
        Dim objeto As New servicio

        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        Dim c As New RecuperarCarteras

        Try

            objitem.codigo = "PR"

            objitem.descripcion = txtServicioNew.Text
            objitem.tipo = txtTipoPrestamo.Text
            If txtObservaciones.Text.Trim.Length > 0 Then
                objitem.observaciones = txtObservaciones.Text
            Else
                objitem.observaciones = Nothing
            End If
            objitem.estado = "1"



            If txtTipoPrestamo.Text = "PO" Then

                objeto = New servicio
                objeto.codigo = "PH"
                objeto.descripcion = "DESEMBOLSO"
                objeto.tipo = "PO"
                objeto.cuenta = "1411"
                objeto.cuentaH = "10"
                objeto.cuentaDev = ""
                objeto.cuentaDevH = ""
                objeto.valor = CDec(0.0)
                objeto.observaciones = "desembolso del prestamo"
                objeto.estado = "1"
                lista.Add(objeto)

                objeto = New servicio
                objeto.codigo = "PH"
                objeto.descripcion = "INTERES"
                objeto.cuenta = "1411"
                objeto.cuentaH = "4931"
                objeto.cuentaDev = "4931"
                objeto.cuentaDevH = "779"
                objeto.tipo = "PO"
                objeto.valor = CDec(0.0)
                objeto.observaciones = "interes del prestamo"
                objeto.estado = "1"
                lista.Add(objeto)

                objeto = New servicio
                objeto.codigo = "PH"
                objeto.descripcion = "SEGURO"
                objeto.cuenta = "1411"
                objeto.cuentaH = "4931"
                objeto.cuentaDev = "4931"
                objeto.cuentaDevH = "779"
                objeto.tipo = "PO"
                objeto.valor = CDec(0.0)
                objeto.observaciones = "interes del prestamo"
                objeto.estado = "1"
                lista.Add(objeto)

            ElseIf txtTipoPrestamo.Text = "PR" Then

                objeto = New servicio
                objeto.codigo = "PH"
                objeto.descripcion = "DESEMBOLSO"
                objeto.tipo = "PR"
                objeto.cuenta = "10"
                objeto.cuentaH = "1411"
                objeto.cuentaDev = ""
                objeto.cuentaDevH = ""
                objeto.valor = CDec(0.0)
                objeto.observaciones = "desembolso del prestamo"
                objeto.estado = "1"
                lista.Add(objeto)

                objeto = New servicio
                objeto.codigo = "PH"
                objeto.descripcion = "INTERES"
                objeto.cuenta = "3731"
                objeto.cuentaH = "45511"
                objeto.cuentaDev = "67311"
                objeto.cuentaDevH = "3731"
                objeto.tipo = "PR"
                objeto.valor = CDec(0.0)
                objeto.observaciones = "interes del prestamo"
                objeto.estado = "1"
                lista.Add(objeto)

                objeto = New servicio
                objeto.codigo = "PH"
                objeto.descripcion = "SEGURO"
                objeto.cuenta = "182"
                objeto.cuentaH = "45512"
                objeto.cuentaDev = "67312"
                objeto.cuentaDevH = "182"
                objeto.tipo = "PR"
                objeto.valor = CDec(0.0)
                objeto.observaciones = "interes del prestamo"
                objeto.estado = "1"
                lista.Add(objeto)

            End If

            Dim codxIdtem As Integer = servicioSA.GrabarTipoPrestamoPadre(objitem, lista)

            'c.IdProceso = codxIdtem
            c.ID = codxIdtem
            datos.Add(c)
            Dispose()

        Catch ex As Exception
            'Manejo de errores
            'lblEstado.Text = ex.Message
            'lblEstado.Image = My.Resources.warning2
        End Try
    End Sub
#End Region

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        Me.Cursor = Cursors.WaitCursor
        'If txtCuenta.Text.Trim.Length > 0 Then
        If txtServicioNew.Text.Trim.Length > 0 Then
            If Tag = "U" Then
                If txtidservicio.Text.Trim.Length > 0 Then
                    EditarServicioPadre(txtidservicio.Text)
                End If
            Else

                GrabarServicioPadre()

            End If
        Else
            MessageBoxAdv.Show("Debe ingresar una descripción para el servicio padre!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        'End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dispose()
    End Sub

    Private Sub frmNuevoTipoPrestamo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'CMBClasificacion()
    End Sub

    Private Sub txtCuenta_KeyDown(sender As Object, e As KeyEventArgs)
        'If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        'Else
        '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
        '    Me.pcLikeCategoria.Size = New Size(241, 110)
        '    Me.pcLikeCategoria.ParentControl = Me.txtCuenta
        '    Me.pcLikeCategoria.ShowPopup(Point.Empty)
        '    Dim consulta = (From n In listaCategoria _
        '             Where n.cuenta.StartsWith(txtCuenta.Text)).ToList

        '    lsvCuenta.DataSource = consulta
        '    lsvCuenta.DisplayMember = "descripcion"
        '    lsvCuenta.ValueMember = "cuenta"
        '    'e.Handled = True
        'End If

        '  If Not Me.pcLikeCategoria.IsShowing() Then

        '   End If

        '    If Not Me.pcLikeCategoria.IsShowing() Then
        'If e.KeyCode = Keys.Down Then
        '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
        '    Me.pcLikeCategoria.Size = New Size(241, 110)
        '    Me.pcLikeCategoria.ParentControl = Me.txtCuenta
        '    Me.pcLikeCategoria.ShowPopup(Point.Empty)
        '    lsvCuenta.Focus()
        'End If
        '   End If

        ' e.SuppressKeyPress = True
        'If e.KeyCode = Keys.Escape Then
        '    If Me.pcLikeCategoria.IsShowing() Then
        '        Me.pcLikeCategoria.HidePopup(PopupCloseType.Canceled)
        '    End If
        'End If
    End Sub

    Private Sub txtCuenta_TextChanged(sender As Object, e As EventArgs)
        'txtCuenta.ForeColor = Color.Black
        'txtCuenta.Tag = Nothing
    End Sub

    Private Sub lsvCuenta_MouseDoubleClick(sender As Object, e As MouseEventArgs)
        'Me.pcLikeCategoria.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub lsvCuenta_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub pcLikeCategoria_CloseUp(sender As Object, e As PopupClosedEventArgs)
        'If e.PopupCloseType = PopupCloseType.Done Then
        '    If lsvCuenta.SelectedItems.Count > 0 Then
        '        txtCuenta.Text = lsvCuenta.Text
        '        txtCuenta.Tag = lsvCuenta.SelectedValue
        '        'txtSubCategoria.Clear()
        '        'txtCategoria.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        '        '' Label43.Text = "0 items"
        '        'Productoshijos()
        '    End If
        'End If
        ''Set focus back to textbox.
        'If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
        '    Me.txtCuenta.Focus()
        'End If
    End Sub

  
End Class