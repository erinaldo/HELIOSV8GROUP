Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Public Class frmNuevoAlmacen
    Inherits frmMaster
    Public Property ManipulacionEstado() As String

    Public Sub New(idUnidOrg As Integer, NombreAlmacen As String)
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        txtEmpresa.Text = Gempresas.NomEmpresa
        txtEmpresa.Tag = Gempresas.IdEmpresaRuc
        txtEstablecimiento.Text = GEstableciento.NombreEstablecimiento
        txtEstablecimiento.Tag = GEstableciento.IdEstablecimiento
        txtdescripcion.Select()
    End Sub

    Public Sub New(idalmacen As Integer, idUnidOrg As Integer, NombreAlmacen As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtEmpresa.Text = Gempresas.NomEmpresa
        txtEmpresa.Tag = Gempresas.IdEmpresaRuc
        txtEstablecimiento.Text = GEstableciento.NombreEstablecimiento
        txtEstablecimiento.Tag = GEstableciento.IdEstablecimiento
        UbicarDocumento(idalmacen)
        txtdescripcion.Select()
    End Sub

    Public Sub limpiar()
        txtEmpresa.Clear()
        txtEstablecimiento.Clear()
        txtDescripcion.Clear()
        txtEncargado.Clear()
        cboTipoDoc.Text = ""
        DateTimePickerAdv1.Value = Date.Now
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As Object, e As EventArgs) Handles GuardarToolStripButton.Click
        
    End Sub

    Public Sub GrabarAlamcen()
        Dim objAlmacen As New almacen
        Dim almacenSA As New almacenSA
        Try
            'Se asigna cada uno de los datos registrados
            objAlmacen.idEmpresa = Gempresas.IdEmpresaRuc   ' Trim(txtCodigoDocumento.Text)
            objAlmacen.idEstablecimiento = txtEstablecimiento.Tag ' GEstableciento.IdEstablecimiento
            objAlmacen.descripcionAlmacen = txtdescripcion.Text
            objAlmacen.encargado = txtEncargado.Text.Trim
            objAlmacen.direccionAlmacen = txtDireccion.Text
            Select Case cboTipoDoc.SelectedItem
                Case "ALMACEN FISICO"
                    objAlmacen.tipo = "AF"
                Case "PUNTO DE UBICACION"
                    objAlmacen.tipo = "PT"
            End Select

            objAlmacen.estado = "S"

            objAlmacen.usuarioModificacion = usuario.IDUsuario
            objAlmacen.fechaModificacion = DateTime.Now
            almacenSA.InsertNuevaAlmacen(objAlmacen)
            MessageBox.Show("almacén registrado!", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            'Manejo de errores
            MessageBox.Show(ex.Message)
            'lblEstado.Image = My.Resources.warning2
        End Try
    End Sub

    Public Sub UpdateAlmacen()
        Dim objAlmacen As New almacen
        Dim almacenSA As New almacenSA
        Try
            'Se asigna cada uno de los datos registrados
            objAlmacen.idEmpresa = Gempresas.IdEmpresaRuc   ' Trim(txtCodigoDocumento.Text)
            objAlmacen.idEstablecimiento = GEstableciento.IdEstablecimiento
            objAlmacen.idAlmacen = Me.Tag
            objAlmacen.descripcionAlmacen = txtDescripcion.Text
            objAlmacen.encargado = txtEncargado.Text.Trim
            objAlmacen.direccionAlmacen = txtDireccion.Text
            Select Case cboTipoDoc.SelectedItem
                Case "ALMACEN FISICO"
                    objAlmacen.tipo = "AF"
                Case "PUNTO DE UBICACION"
                    objAlmacen.tipo = "PT"
            End Select
            objAlmacen.estado = "S"

            objAlmacen.usuarioModificacion = usuario.IDUsuario
            objAlmacen.fechaModificacion = DateTime.Now

            almacenSA.UpdateNuevaAlmacen(objAlmacen)
            '  Me.lblEstado.Image = My.Resources.ok4
            MessageBox.Show("Almacén editado!", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            'Manejo de errores
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub UbicarDocumento(ByVal intIdDocumento As Integer)
        Dim objAlmacen As New almacen
        Dim almacenSA As New almacenSA
        Try
            objAlmacen = almacenSA.GetUbicar_almacenPorID(intIdDocumento)
            If Not IsNothing(objAlmacen) Then
                With objAlmacen
                    Me.Tag = .idAlmacen
                    txtdescripcion.Text = .descripcionAlmacen
                    txtEncargado.Text = .encargado
                    txtDireccion.Text = .direccionAlmacen

                    Select Case .tipo
                        Case "AF"
                            cboTipoDoc.SelectedItem = "ALMACEN FISICO"
                        Case "PT"
                            cboTipoDoc.SelectedItem = "PUNTO DE UBICACION"
                    End Select


                    DateTimePickerAdv1.Value = .fechaModificacion
                End With
            End If

        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub txtDescripcion_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtEncargado.Select()
        End If
    End Sub

    Private Sub frmNuevoAlmacen_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub txtEncargado_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            nudPorGanancia.Select()
        End If
    End Sub

    Private Sub frmNuevoAlmacen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Dispose()
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        Me.Cursor = Cursors.WaitCursor
        If Not txtDescripcion.Text.Trim.Length > 0 Then
            MessageBox.Show("Ingrese el nombre del almacén", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Cursor = Cursors.Arrow
            Exit Sub
            'ElseIf Not txtEncargado.Text.Trim.Length > 0 Then
            '    lblEstado.Text = "Ingrese el nombre del encargado"
            '    Me.Cursor = Cursors.Arrow
            '    Exit Sub
        ElseIf Not cboTipoDoc.Text.Trim.Length > 0 Then
            MessageBox.Show("Seleccione un tipo de almacén", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Cursor = Cursors.Arrow
            Exit Sub
        ElseIf Not nudPorGanancia.Text.Trim.Length > 0 Then
            MessageBox.Show("ingrese un monto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
            GrabarAlamcen()
            Dispose()
        Else
            UpdateAlmacen()
            Dispose()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtdescripcion_TextChanged(sender As Object, e As EventArgs) Handles txtdescripcion.TextChanged

    End Sub
End Class