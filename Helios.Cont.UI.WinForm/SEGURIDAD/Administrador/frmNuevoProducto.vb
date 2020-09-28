Imports Helios.Seguridad.Business.Entity
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmNuevoProducto

#Region "Attributes"
    Public Property strEstadoManipulacion() As String
    Public Property productoSA As New ProductoSA
    Dim idProducto As Integer
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtFecha.Text = DateTime.Now
        txtFecha.ReadOnly = True
    End Sub

    Public Sub New(idrol As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtFecha.Text = DateTime.Now
        txtFecha.ReadOnly = True
        UbicarRol(idrol)
    End Sub

#End Region

#Region "Methods"


    Public Sub Grabar()
        Dim producto As New Seguridad.Business.Entity.Producto
        Try
            producto = New Seguridad.Business.Entity.Producto
            With producto
                .Action = BaseBE.EntityAction.INSERT
                .nombre = txtNombres.Text
                .Descripcion = txtDescripcion.Text
                .UsuarioActualizacion = "SISTEMA"
                .FechaActualizacion = Date.Now
            End With

            productoSA.InsertItemProducto(producto)
            MessageBox.Show("Producto grabado correctamente!", "!Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Close()

        Catch ex As Exception
            MsgBox("Error al grabar producto. " & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema!")

        End Try

    End Sub

    Public Sub UpdateRol()
        Dim producto As New Seguridad.Business.Entity.Producto
        Try
            producto = New Seguridad.Business.Entity.Producto
            With producto
                .Action = BaseBE.EntityAction.UPDATE
                .IDProducto = idProducto
                .nombre = txtNombres.Text
                .descripcion = txtDescripcion.Text
                .UsuarioActualizacion = usuario.IDUsuario
                .FechaActualizacion = Date.Now
            End With

            productoSA.InsertItemProducto(producto)
            MessageBox.Show("Usuario producto correctamente!", "!Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Close()

        Catch ex As Exception
            MsgBox("Error al grabar producto. " & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema!")

        End Try

    End Sub

    Public Sub UbicarRol(idProducto As Integer)
        Dim Producto As New Seguridad.Business.Entity.Producto
        Try
            Producto = productoSA.ListadoProductoXID(idProducto)

            With Producto
                idProducto = .IDProducto
                txtDescripcion.Text = .descripcion
                txtNombres.Text = .nombre
                txtFecha.Text = .UsuarioActualizacion
            End With

            'RolSA.insertRol(rol)
            MessageBox.Show("se ubico correctamente!", "!Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Close()

        Catch ex As Exception
            MsgBox("Error al ubicar producto. " & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema!")

        End Try

    End Sub
#End Region

#Region "Events"
    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Close()
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        If txtNombres.Text.Trim.Length > 0 Then
            If txtDescripcion.Text.Trim.Length > 0 Then
                If txtFecha.Text.Trim.Length > 0 Then
                    Select Case strEstadoManipulacion
                        Case ENTITY_ACTIONS.INSERT
                            Grabar()
                        Case ENTITY_ACTIONS.UPDATE
                            UpdateRol()
                            Close()
                    End Select
                Else
                    MsgBox("Ingrese nombre", MsgBoxStyle.Information, "!Atención")
                    txtFecha.Focus()

                End If
            Else
                MsgBox("Ingrese descripción", MsgBoxStyle.Information, "!Atención")
                txtDescripcion.Focus()
            End If
        Else
            MsgBox("Ingrese fecha", MsgBoxStyle.Information, "!Atención")
            txtNombres.Focus()
        End If
    End Sub
#End Region

End Class