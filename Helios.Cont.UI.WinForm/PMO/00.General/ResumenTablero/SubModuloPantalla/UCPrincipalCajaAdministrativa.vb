
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Public Class UCPrincipalCajaAdministrativa

#Region "Atributos"
    Private UCArqueoCaja As UCArqueoCaja
    Private UCHistorialCajaUsuario As UCHistorialCajaUsuario
    Private UCCajaEnActividad As UCCajaEnActividad
    Private UCCajaEnArqueo As UCCajaEnArqueo
    Private UCSubCajaAdmi As UCSubCajaAdmi
#End Region

#Region "Constructor"
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        'If validarPermisos(PermisosDelSistema.CAJA_CENTRAL_, AutorizacionRolList) = 1 Then
        UCSubCajaAdmi = New UCSubCajaAdmi With {.Dock = DockStyle.Fill, .Visible = True}
            'Else
            '    UCSubCajaAdmi = New UCSubCajaAdmi With {.Dock = DockStyle.Fill, .Visible = False}
            'End If

            'UCHistorialCajaUsuario = New UCHistorialCajaUsuario With {.Dock = DockStyle.Fill, .Visible = False}
            'UCArqueoCaja = New UCArqueoCaja With {.Dock = DockStyle.Fill, .Visible = False}

            'UCCajaEnActividad = New UCCajaEnActividad With {.Dock = DockStyle.Fill, .Visible = False}
            'UCCajaEnArqueo = New UCCajaEnArqueo With {.Dock = DockStyle.Fill, .Visible = False}
            PanelBody.Controls.Add(UCSubCajaAdmi)
        'PanelBody.Controls.Add(UCHistorialCajaUsuario)
        'PanelBody.Controls.Add(UCArqueoCaja)

        'PanelBody.Controls.Add(UCCajaEnActividad)
        'PanelBody.Controls.Add(UCCajaEnArqueo)
    End Sub


#End Region

#Region "Metodos"


    Public Sub OcultarTodos()
        If UCArqueoCaja IsNot Nothing Then
            UCArqueoCaja.Visible = False
        End If
        If UCHistorialCajaUsuario IsNot Nothing Then
            UCHistorialCajaUsuario.Visible = False
        End If
        If UCCajaEnActividad IsNot Nothing Then
            UCCajaEnActividad.Visible = False
        End If
        If UCCajaEnArqueo IsNot Nothing Then
            UCCajaEnArqueo.Visible = False
        End If
        If UCSubCajaAdmi IsNot Nothing Then
            UCSubCajaAdmi.Visible = False
        End If

    End Sub


    Public Sub AbrirCajaGeneral()
        Dim usuarioSel = UsuariosList.Where(Function(o) o.TipoDocumento = "SUPER").FirstOrDefault
        If usuarioSel IsNot Nothing Then

            Dim CargoSelec = usuarioSel.UsuarioRol.FirstOrDefault  ' super usuairo solo tiene 1 rol 
            If CargoSelec IsNot Nothing Then


                Dim cajaSA As New cajaUsuarioSA
                Dim objCaja As New cajaUsuario
                Dim documentoCajaSA As New DocumentoCajaSA
                Dim UserDetalle As New cajaUsuariodetalle
                Dim ListaUserDetalle As New List(Of cajaUsuariodetalle)
                Try
                    objCaja = New cajaUsuario

                    Dim shostname As String
                    shostname = System.Net.Dns.GetHostName
                    With objCaja
                        .IDRol = CargoSelec.IDRol
                        .tipoCaja = Tipo_Caja.GENERAL
                        .namepc = shostname
                        .idEmpresa = Gempresas.IdEmpresaRuc
                        .idEstablecimiento = GEstableciento.IdEstablecimiento
                        .periodo = GetPeriodo(Date.Now, True)
                        .idPersona = usuarioSel.IDUsuario
                        .idCajaOrigen = 0
                        .idCajaDestino = 0
                        .moneda = "1"
                        .tipoCambio = TmpTipoCambio
                        .fechaRegistro = Date.Now
                        .fondoMN = 0
                        .fondoME = 0
                        .ingresoAdicMN = 0
                        .ingresoAdicME = 0
                        .otrosIngresosMN = 0
                        .otrosIngresosME = 0
                        .otrosEgresosMN = 0
                        .otrosEgresosME = 0
                        .estadoCaja = "A"
                        .enUso = "N"
                        .usuarioActualizacion = usuario.IDUsuario
                        .fechaActualizacion = DateTime.Now
                    End With

                    ListaUserDetalle = New List(Of cajaUsuariodetalle)


                    For Each d In ListaCuentasFinancierasConfiguradas.Where(Function(o) o.IDFormaPago <> "9991" And o.tipoCaja <> "EP").ToList
                        UserDetalle = New cajaUsuariodetalle
                        UserDetalle.idEntidad = Integer.Parse(d.identidad)
                        UserDetalle.moneda = d.moneda
                        If UserDetalle.moneda = "1" Then
                            UserDetalle.importeMN = CDec(0.0)
                            UserDetalle.importeME = 0
                        ElseIf UserDetalle.moneda = "2" Then
                            UserDetalle.importeMN = 0
                            UserDetalle.importeME = CDec(0.0)
                        End If
                        UserDetalle.tipoCambio = TmpTipoCambio

                        UserDetalle.usuarioActualizacion = usuario.IDUsuario
                        UserDetalle.idConfiguracion = Integer.Parse(d.idConfiguracion)
                        UserDetalle.fechaActualizacion = DateTime.Now
                        ListaUserDetalle.Add(UserDetalle)
                    Next
                    objCaja.cajaUsuariodetalle = ListaUserDetalle
                    If ListaUserDetalle.Count = 0 Then Exit Sub
                    Dim codigoUsuarioClave = documentoCajaSA.SaveCajaAdministrativaApertura(Nothing, objCaja, Nothing)
                    ListaCajasActivas = cajaSA.ListadoCajaXEstado(New cajaUsuario With {
                                                                     .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                     .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                     .estadoCaja = "A"
                                                                     })

                Catch ex As Exception

                End Try


            End If

        End If




    End Sub

#End Region

    Private Sub btnHistorialDeCajas_Click(sender As Object, e As EventArgs) Handles btnHistorialDeCajas.Click, btnArqueoDeCaja.Click, btnSeguimientoCajas.Click, btnCajasXArquear.Click
        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width
        '  End If
        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        Select Case btn.Text

            Case "CAJA CENTRAL"
                If validarPermisos(PermisosDelSistema.CAJA_CENTRAL_, AutorizacionRolList) = 1 Then


                    OcultarTodos()
                    'UCCajaEnActividad.Visible = False
                    'UCCajaEnArqueo.Visible = False
                    'UCHistorialCajaUsuario.Visible = False
                    'UCArqueoCaja.Visible = False
                    If UCSubCajaAdmi IsNot Nothing Then
                        UCSubCajaAdmi.Visible = True
                        UCSubCajaAdmi.BringToFront()
                        UCSubCajaAdmi.Show()
                    End If
                Else
                    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Case "ARQUEO DE CAJA"
                If validarPermisos(PermisosDelSistema.ARQUEO_CAJA_, AutorizacionRolList) = 1 Then


                    OcultarTodos()

                    If UCArqueoCaja Is Nothing Then
                        UCArqueoCaja = New UCArqueoCaja With {.Dock = DockStyle.Fill, .Visible = False}
                        PanelBody.Controls.Add(UCArqueoCaja)
                        UCArqueoCaja.Visible = True
                        UCArqueoCaja.BringToFront()
                        UCArqueoCaja.Show()
                    Else
                        UCArqueoCaja.Visible = True
                        UCArqueoCaja.BringToFront()
                        UCArqueoCaja.Show()
                    End If


                    'UCCajaEnActividad.Visible = False
                    'UCCajaEnArqueo.Visible = False
                    'UCHistorialCajaUsuario.Visible = False
                    'UCSubCajaAdmi.Visible = False
                    'If UCArqueoCaja IsNot Nothing Then
                    '    UCArqueoCaja.Visible = True
                    '    UCArqueoCaja.BringToFront()
                    '    UCArqueoCaja.Show()
                    'End If
                Else
                    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Case "HISTORIAL DE CAJAS"
                If validarPermisos(PermisosDelSistema.HISTORIAL_CAJA_, AutorizacionRolList) = 1 Then


                    OcultarTodos()

                    If UCHistorialCajaUsuario Is Nothing Then
                        UCHistorialCajaUsuario = New UCHistorialCajaUsuario With {.Dock = DockStyle.Fill, .Visible = False}
                        PanelBody.Controls.Add(UCHistorialCajaUsuario)
                        UCHistorialCajaUsuario.Visible = True
                        UCHistorialCajaUsuario.BringToFront()
                        UCHistorialCajaUsuario.Show()
                    Else
                        UCHistorialCajaUsuario.Visible = True
                        UCHistorialCajaUsuario.BringToFront()
                        UCHistorialCajaUsuario.Show()
                    End If

                    'UCArqueoCaja.Visible = False
                    'UCCajaEnActividad.Visible = False
                    'UCCajaEnArqueo.Visible = False
                    'UCSubCajaAdmi.Visible = False
                    'If UCHistorialCajaUsuario IsNot Nothing Then
                    '    UCHistorialCajaUsuario.Visible = True
                    '    UCHistorialCajaUsuario.BringToFront()
                    '    UCHistorialCajaUsuario.Show()
                    'End If
                Else
                    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Case "CONTROL DE CAJAS"
                If validarPermisos(PermisosDelSistema.CONTROL_CAJA_, AutorizacionRolList) = 1 Then


                    OcultarTodos()

                    If UCCajaEnActividad Is Nothing Then
                        UCCajaEnActividad = New UCCajaEnActividad With {.Dock = DockStyle.Fill, .Visible = False}
                        PanelBody.Controls.Add(UCCajaEnActividad)
                        UCCajaEnActividad.Visible = True
                        UCCajaEnActividad.BringToFront()
                        UCCajaEnActividad.Show()
                    Else
                        UCCajaEnActividad.Visible = True
                        UCCajaEnActividad.BringToFront()
                        UCCajaEnActividad.Show()
                    End If


                    'UCArqueoCaja.Visible = False
                    'UCCajaEnArqueo.Visible = False
                    'UCHistorialCajaUsuario.Visible = False
                    'UCSubCajaAdmi.Visible = False
                    'If UCCajaEnActividad IsNot Nothing Then
                    '    UCCajaEnActividad.Visible = True
                    '    UCCajaEnActividad.BringToFront()
                    '    UCCajaEnActividad.Show()
                    'End If
                Else
                    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Case "CAJAS POR ARQUEAR"
                If validarPermisos(PermisosDelSistema.CAJA_POR_ARQUEAR_, AutorizacionRolList) = 1 Then



                    OcultarTodos()

                    If UCCajaEnArqueo Is Nothing Then
                        UCCajaEnArqueo = New UCCajaEnArqueo With {.Dock = DockStyle.Fill, .Visible = False}
                        PanelBody.Controls.Add(UCCajaEnArqueo)
                        UCCajaEnArqueo.Visible = True
                        UCCajaEnArqueo.BringToFront()
                        UCCajaEnArqueo.Show()
                    Else
                        UCCajaEnArqueo.Visible = True
                        UCCajaEnArqueo.BringToFront()
                        UCCajaEnArqueo.Show()
                    End If

                    'UCArqueoCaja.Visible = False
                    'UCCajaEnActividad.Visible = False
                    'UCHistorialCajaUsuario.Visible = False
                    'UCSubCajaAdmi.Visible = False
                    'If UCCajaEnArqueo IsNot Nothing Then
                    '    UCCajaEnArqueo.Visible = True
                    '    UCCajaEnArqueo.BringToFront()
                    '    UCCajaEnArqueo.Show()
                    'End If
                Else
                    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

        End Select
    End Sub

    'Private Sub btnEntradaDeDinero_Click(sender As Object, e As EventArgs) Handles btnEntradaDeDinero.Click
    '    Dim cajaUsuarioSA As New cajaUsuarioSA
    '    Cursor = Cursors.WaitCursor
    '    'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.NUEVO_INGRESO_Botón___, AutorizacionRolList) Then

    '    Dim cajaActivaGeneral = ListaCajasActivas.Where(Function(o) o.tipoCaja = Tipo_Caja.GENERAL).SingleOrDefault

    '    If cajaActivaGeneral Is Nothing Then
    '        AbrirCajaGeneral()
    '    End If

    '    If validarPermisos(PermisosDelSistema.INGRESO_DE_EFECTIVO_, AutorizacionRolList) = 1 Then


    '        ' Dim cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
    '        'If Not IsNothing(cajaUsuario) Then
    '        '    GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)

    '        Dim f As New FormRealizacionDePagos
    '        f.txtAnioCompra.Text = DateTime.Now.Year
    '        f.cboMesCompra.SelectedValue = String.Format("{0:00}", DateTime.Now.Month)
    '        f.txtHora.Value = DateTime.Now
    '        f.TxtDia.Text = DateTime.Now.Day ' ""
    '        f.StartPosition = FormStartPosition.CenterParent
    '        f.txtTipoCambio.Value = TmpTipoCambio
    '        f.ShowDialog(Me)
    '        'Else
    '        '    MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        'End If
    '    Else
    '        MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    End If
    '    Cursor = Cursors.Default
    'End Sub

    'Private Sub btnSalidaDeDinero_Click(sender As Object, e As EventArgs) Handles btnSalidaDeDinero.Click
    '    Cursor = Cursors.WaitCursor
    '    'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.NUEVA_SALIDA_CAJA_Botón___, AutorizacionRolList) Then


    '    Dim cajaActivaGeneral = ListaCajasActivas.Where(Function(o) o.tipoCaja = Tipo_Caja.GENERAL).SingleOrDefault

    '    If cajaActivaGeneral Is Nothing Then
    '        AbrirCajaGeneral()
    '    End If
    '    If validarPermisos(PermisosDelSistema.SALIDA_DE_EFECTIVO_, AutorizacionRolList) = 1 Then
    '        'Else
    '        '    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        'End If
    '        '    Dim cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
    '        '    If Not IsNothing(cajaUsuario) Then
    '        '  GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)
    '        Dim f As New FormPagoEgreso
    '        f.txtAnioCompra.Text = DateTime.Now.Year
    '        f.cboMesCompra.SelectedValue = String.Format("{0:00}", DateTime.Now.Month)
    '        f.txtHora.Value = DateTime.Now
    '        f.TxtDia.Text = DateTime.Now.Day ' ""
    '        f.StartPosition = FormStartPosition.CenterParent
    '        f.txtTipoCambio.Value = TmpTipoCambio
    '        f.ShowDialog(Me)
    '        'Else
    '        '    MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        'End If
    '    Else
    '        MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    End If
    '    Cursor = Cursors.Default
    'End Sub





End Class
