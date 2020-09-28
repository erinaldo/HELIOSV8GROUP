Public Class UCPrincipalAlmacenes

#Region "ATRIBUTOS"

    ' PRUEBA DE SUBIR  HITHUB

    Public Property UCOtrasEntradas As UCOtrasEntradas

    Public Property UCOtrasSalidas As UCOtrasSalidas

    Public Property UCTransferencias As UCTransferencias

    Public Property UCAdministrarAlmacen As UCAdministrarAlmacen


#End Region

#Region "CONSTRUCTOR"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UCTransferencias = New UCTransferencias With {.Dock = DockStyle.Fill, .Visible = True}
        UCAdministrarAlmacen = New UCAdministrarAlmacen With {.Dock = DockStyle.Fill, .Visible = False}
        UCOtrasEntradas = New UCOtrasEntradas With {.Dock = DockStyle.Fill, .Visible = False}
        UCOtrasSalidas = New UCOtrasSalidas With {.Dock = DockStyle.Fill, .Visible = False}

        PanelBody.Controls.Add(UCTransferencias)
        PanelBody.Controls.Add(UCOtrasEntradas)
        PanelBody.Controls.Add(UCOtrasSalidas)

        PanelBody.Controls.Add(UCAdministrarAlmacen)

    End Sub
#End Region


#Region "METODOS"

#End Region

    Private Sub btnCuentasPorCobrar_Click(sender As Object, e As EventArgs) Handles btnCuentasPorCobrar.Click, btnOtrasSalidas.Click, btnOtrasEntradas.Click, btnCuentasPorPagar.Click
        Try

            Dim btn = sender
            'Dim btn2 = CType(sender, Button)

            If btn IsNot Nothing Then
                Select Case btn.Text
                    Case "ALMACENES"
                        If validarPermisos(PermisosDelSistema.MANTENIMIENTO_ALAMACEN_, AutorizacionRolList) = 1 Then

                            sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
                            sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width

                            UCTransferencias.Visible = False
                            UCOtrasEntradas.Visible = False
                            UCOtrasSalidas.Visible = False

                            If UCAdministrarAlmacen IsNot Nothing Then
                                UCAdministrarAlmacen.Visible = True
                                UCAdministrarAlmacen.CARGARCOMPLEMENTOS()
                                UCAdministrarAlmacen.BringToFront()
                                UCAdministrarAlmacen.Show()
                            End If
                        Else
                            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Case "TRANFERENCIAS"
                        If validarPermisos(PermisosDelSistema.TRANSFERENCIA_ENTRE_ALMACENES_, AutorizacionRolList) = 1 Then

                            sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
                            sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width

                            UCAdministrarAlmacen.Visible = False
                            UCOtrasEntradas.Visible = False
                            UCOtrasSalidas.Visible = False

                            If UCTransferencias IsNot Nothing Then
                                UCTransferencias.Visible = True
                                UCTransferencias.BringToFront()
                                UCTransferencias.Show()
                            End If
                        Else
                            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If

                    Case "OTRAS ENTRADAS"
                        If validarPermisos(PermisosDelSistema.ENTRADA_INVENTARIO_, AutorizacionRolList) = 1 Then

                            sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
                            sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width

                            UCAdministrarAlmacen.Visible = False
                            UCTransferencias.Visible = False
                            UCOtrasSalidas.Visible = False

                            If UCOtrasEntradas IsNot Nothing Then
                                UCOtrasEntradas.Visible = True
                                UCOtrasEntradas.CargarComplementos()
                                UCOtrasEntradas.BringToFront()
                                UCOtrasEntradas.Show()
                            End If
                        Else
                            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If

                    Case "OTRAS SALIDAS"
                        If validarPermisos(PermisosDelSistema.SALIDA_DE_INVENTARIO_, AutorizacionRolList) = 1 Then

                            sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
                            sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width

                            UCAdministrarAlmacen.Visible = False
                            UCTransferencias.Visible = False
                            UCOtrasEntradas.Visible = False

                            If UCOtrasSalidas IsNot Nothing Then
                                UCOtrasSalidas.Visible = True
                                UCOtrasSalidas.CargarComplementos()
                                UCOtrasSalidas.BringToFront()
                                UCOtrasSalidas.Show()
                            End If
                        Else
                            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                End Select
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
