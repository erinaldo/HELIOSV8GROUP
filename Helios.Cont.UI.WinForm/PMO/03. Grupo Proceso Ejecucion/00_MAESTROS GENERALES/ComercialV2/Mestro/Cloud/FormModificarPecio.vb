Imports Helios.Cont.Business.Entity
Imports Helios.General
Imports Helios.Seguridad.Business.Entity
Imports Helios.Seguridad.WCFService.ServiceAccess

Public Class FormModificarPecio
    Public Property monedaSel As String
    Dim usuarioAut As New AutenticacionUsuario

    Private Sub OK_Click(sender As Object, e As EventArgs) Handles OK.Click
        Dim precio As New configuracionPrecioProducto
        Try
            'If ValidaUsuarioAdmin() Then
            If txtPrecio.DecimalValue > 0 Then

                    Select Case monedaSel
                        Case "NACIONAL"
                            precio = New configuracionPrecioProducto With
                                {
                                .precioMN = txtPrecio.DecimalValue,
                                .precioME = txtPrecio.DecimalValue / TmpTipoCambio,
                                .ModificaColumna = If(RBPrecioVenta.Checked, "PRECIO", "IMPORTE")
                            }

                        Case "EXTRANJERA"
                            precio = New configuracionPrecioProducto With
                                {
                                .precioMN = 0,
                                .precioME = txtPrecio.DecimalValue,
                                .ModificaColumna = If(RBPrecioVenta.Checked, "PRECIO", "IMPORTE")
                            }

                    End Select


                    Dim miInterfaz As IPrecio = TryCast(Me.Owner, IPrecio)
                    If miInterfaz IsNot Nothing Then miInterfaz.CambiarPrecio(precio)
                    Close()
                Else
                    MsgBox("Debe ingresar un precio mayor a cero.", MsgBoxStyle.Critical, "Validar precio")
                End If
            'Else
            '    MsgBox("Debe identificar al administrador", MsgBoxStyle.Critical, "Validar permiso")
            'End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validar permiso")
        End Try

    End Sub

    Function autenticar() As Boolean
        autenticar = False
        Dim rolSA As New RolSA
        Dim AutenticacionUsuarioSA As New AutenticacionUsuarioSA
        Dim AutorizacionRolSA As New AutorizacionRolSA
        Dim UsuarioCompleto() As String, AliasUsuario As String 'IDCliente As String,

        usuarioAut = New AutenticacionUsuario
        UsuarioCompleto = UsernameTextBox.Text.Trim.Split("\")
        If UsuarioCompleto.Length = 2 Then
            AliasUsuario = UsuarioCompleto(1).Trim
            ' IDCliente = UsuarioCompleto(0)
        Else
            AliasUsuario = UsernameTextBox.Text.Trim
            ' IDCliente = "GENERICO"
        End If
        usuarioAut.Alias = AliasUsuario
        usuarioAut.Contrasena = PasswordTextBox.Text.Trim
        'usuarioAut.IDCliente = usuario.IDCliente
        'usuarioAut.IDUsuario = usuario.IDUsuario
        If AutenticacionUsuarioSA.EsUsuarioAutenticadoConfPrecio(usuarioAut) Then
            UserAccesoPermitido = True
            'Se supone que FORM1 es un MDI y que todos los formularios lo utilizan.
            ' AutenticacionUsuario = usuario
            autenticar = True
            'Dim r = rolSA.ListadoRolesXID(usuario.CustomUsuario.CustomUsuarioRol.IDRol)
            'If r.Descripcion = "Administrador" Then
            '    autenticar = True
            'Else
            '    Throw New Exception("El usuario ingresado no es un administrador")
            'End If
        Else
            'MessageBox.Show("Usuario o clave incorrecto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Function

    Private Function ValidaUsuarioAdmin() As Boolean
        ValidaUsuarioAdmin = False
        If UsernameTextBox.Text.Trim.Length = 0 Then
            Exit Function
        End If

        If PasswordTextBox.Text.Trim.Length = 0 Then
            Exit Function
        End If
        If autenticar() = False Then
            Exit Function
        Else
            Return True
        End If

    End Function

    Private Sub FormModificarPecio_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class