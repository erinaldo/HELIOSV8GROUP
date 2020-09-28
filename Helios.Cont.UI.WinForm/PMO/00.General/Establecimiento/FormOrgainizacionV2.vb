Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.Business.Entity
Imports Helios.General
Imports System.ComponentModel
Imports Syncfusion.Windows.Forms.Tools
Imports Syncfusion.Windows.Forms
Imports System.IO
Imports System.Xml

Public Class FormOrgainizacionV2
#Region "Attributes"
    Public Property empresaSPK As New List(Of clientesSoftPack)
    Private Property SelEmpresa As empresa
    Private Property SelEstablecimiento As centrocosto
    Private Property EstablecimientoSA As New establecimientoSA
    Private Property empresaSA As New empresaSA
    Dim clienteSoftpack As clientesSoftPack
    Public Delegate Sub _delegadoValidarRUCDNI()
    '   Dim fso As New FeedbackForm

    Public Property ListaUnidadesNegocio As List(Of centrocosto)

    Dim frmMaestroModuloPOSV2 As FormTablaPrincipal
    Dim frmMaestroModuloBasic As FormTablaPrincipalBasic
    Dim FormTablaPrincipalTransportes As FormTablaPrincipalTransportes
    Dim frmMaestroModuloPOS As FormTablaPrincipalPOS
    Dim FormTablaPrincipalCaja As FormTablaPrincipalCaja

    Public Property listaRubro As List(Of centrocosto)
    Public Property listaSegemento As List(Of centrocosto)
    Public Property listaUnidadNegocios As List(Of centrocosto)

    Dim m_xmld As XmlDocument
    Dim m_nodelist As XmlNodeList
    Dim m_node As XmlNode

    Dim IdUnidadNegocio As Integer = 0

    Dim IdEmpresaDefault As String = String.Empty

    Dim cargoSeleccionado As Integer = 0

    Public Property listaCargosXUsuario As List(Of UsuarioRol)

    Dim listaUsuario As New List(Of UsuarioRol)
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        Try
            ' Add any initialization after the InitializeComponent() call.
            Me.splashControl1.SplashControlPanel.BorderType = SplashBorderType.None
            Me.splashControl1.ShowDialogSplash(Me)
            Me.splashControl1.AutoMode = False

            Me.splashControl1.HostForm = Me

            'GetCombosInicio()
            FormatoGridBlack(dgPerfilesUsuario, True)
            ValidarRucXML()

            GetGlobalMapping()
            ProgressBar2.Style = ProgressBarStyle.Marquee
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Public Sub New(idempresa As String)

        ' This call is required by the designer.
        InitializeComponent()
        Try
            ' Add any initialization after the InitializeComponent() call.
            Me.splashControl1.SplashControlPanel.BorderType = SplashBorderType.None
            Me.splashControl1.ShowDialogSplash(Me)
            Me.splashControl1.AutoMode = False

            Me.splashControl1.HostForm = Me

            'GetCombosInicio()

            IdEmpresaDefault = IdEmpresaDefault
            txtRuc.Text = IdEmpresaDefault
            'SelEmpresa = empresaSA.UbicarEmpresaRuc(IdEmpresaDefault)
            FormatoGridBlack(dgPerfilesUsuario, True)
            GetGlobalMapping()
            ProgressBar2.Style = ProgressBarStyle.Marquee

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region

#Region "Methdos"


    Sub ValidarRucXML()
        Dim estableSA As New establecimientoSA

        'Creamos el "Document"
        m_xmld = New XmlDocument()

        'Cargamos el archivo
        m_xmld.Load("C:\SPKconfiguration.xml")

        'Obtenemos la lista de los nodos "name"
        m_nodelist = m_xmld.SelectNodes("/spk/company")

        'Iniciamos el ciclo de lectura
        For Each m_node In m_nodelist
            'Obtenemos el Elemento RUC
            Dim mNombre = m_node.ChildNodes.Item(0).InnerText
            If mNombre.ToString.Trim.Length > 0 Then
                txtRuc.Text = mNombre
                IdEmpresaDefault = mNombre
                ' Exit Sub
            End If

            Dim mUnidadNegocio = m_node.ChildNodes.Item(1).InnerText
            If mUnidadNegocio.ToString.Trim.Length > 0 Then
                IdUnidadNegocio = mUnidadNegocio
                'ComboUnidadNegocio.SelectedValue = IdUnidadNegocio
                ' Exit Sub
            End If
        Next

        'Obtenemos la lista de los nodos "name"
        m_nodelist = m_xmld.SelectNodes("/spk/impresion")

        'Iniciamos el ciclo de lectura
        For Each m_node In m_nodelist
            'Obtenemos el Elemento RUC
            Dim mImpresora = m_node.ChildNodes.Item(0).InnerText
            Dim mEmail = m_node.ChildNodes.Item(1).InnerText
            Dim mPassowrod = m_node.ChildNodes.Item(2).InnerText
            If mImpresora.ToString.Trim.Length > 0 Then
                GImpresion = New GImpresiones With
                    {
                    .ImpresoraPDF = mImpresora,
                    .EmailEnvio = mEmail,
                    .PasswordEnvio = mPassowrod
                }
            End If
        Next

        Dim m_nodeAPI = m_xmld.SelectNodes("/spk/company/apireniec")
        For Each m_node In m_nodeAPI
            'Obtenemos el Elemento RUC
            Dim ApiCodigo = m_node.ChildNodes.Item(0).InnerText
            If ApiCodigo.ToString.Trim.Length > 0 Then
                ApiReniecOption = ApiCodigo

            End If
        Next

        Dim m_noderuc = m_xmld.SelectNodes("/spk/company/apiruc")
        For Each m_node In m_noderuc
            'Obtenemos el Elemento RUC
            Dim ApiCodigo = m_node.ChildNodes.Item(0).InnerText
            If ApiCodigo.ToString.Trim.Length > 0 Then
                ApiRucOption = ApiCodigo
                Exit Sub
            End If
        Next

    End Sub

    Private Function GetCodigoVendedor() As String
        GetCodigoVendedor = Nothing
        Dim f As New FormCodigoAcceso
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim c = CType(f.Tag, String)
            GetCodigoVendedor = c
        End If
    End Function


    Private Sub GetCombosCArgosxUsuario(cargoXusuarioRol As List(Of UsuarioRol))
        Try
            Dim ListaRolbe As New List(Of UsuarioRol)
            Dim rolSA As New UsuarioRolSA

            'ListaRolbe = rolSA.GetListaUsuariosXPerfilAndPassword(Nothing)

            listaCargosXUsuario = New List(Of UsuarioRol)
            listaCargosXUsuario = cargoXusuarioRol
            'comboCargo.DataSource = listaCargosXUsuario
            'comboCargo.ValueMember = "IDRol"
            'comboCargo.DisplayMember = "nombrePerfil"
            'cargoSeleccionado = comboCargo.SelectedValue

            Dim dt As New DataTable("Usuario")
                Dim UsuarioSA As New UsuarioSA


            dt.Columns.Add(New DataColumn("ID", GetType(Integer)))
                dt.Columns.Add(New DataColumn("CARGO", GetType(String)))






                For Each i In listaCargosXUsuario 'UsuarioSA.ListadoUsuariosXclienteCargo(New Usuario With {.IDEmpresa = Gempresas.IdEmpresaRuc, .IDEstablecimiento = GEstableciento.IdEstablecimiento})

                    'For Each i In UsuarioSA.ListadoUsuariosXcliente(Gempresas.IDCliente)
                    Dim dr As DataRow = dt.NewRow()

                    dr(0) = i.IDRol
                    dr(1) = i.nombrePerfil

                    dt.Rows.Add(dr)
                Next

                dgPerfilesUsuario.DataSource = dt

            Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub GetGlobalMapping()
        'SelEstablecimiento = New centrocosto
        'SelEstablecimiento = EstablecimientoSA.ObtenerListaEstablecimientos(SelEmpresa.idEmpresa).FirstOrDefault


        Try

            SelEmpresa = empresaSA.UbicarEmpresaRuc(txtRuc.Text)

            If (Not IsNothing(SelEmpresa)) Then
                ListaUnidadesNegocio = EstablecimientoSA.ObtenerListaEstablecimientos(SelEmpresa.idEmpresa)
                Gempresas = New GEmpresa With
                    {
                    .IDProducto = 0,
                    .IdEmpresaRuc = SelEmpresa.idEmpresa,
                    .IDCliente = SelEmpresa.idclientespk,
                    .NomCorto = SelEmpresa.nombreCorto,
                    .NomEmpresa = SelEmpresa.razonSocial,
                    .Ruc = SelEmpresa.ruc,
                    .InicioOpeaciones = SelEmpresa.inicioOperacion,
                    .Regimen = SelEmpresa.regimen,
                    .direccionEmpresa = SelEmpresa.direccion,
                    .TelefonoEmpresa = SelEmpresa.telefono & "-" & SelEmpresa.celular,
                    .departamento = SelEmpresa.departamento,
                    .provincia = SelEmpresa.provincia,
                    .distrito = SelEmpresa.distrito,
                    .ubigeo = SelEmpresa.ubigeo
                }
            End If

            'GetCombosInicio()

            listaUnidadNegocios = ListaUnidadesNegocio.Where(Function(o) o.TipoEstab = "UN").ToList
            ComboUnidadNegocio.DataSource = listaUnidadNegocios
            ComboUnidadNegocio.ValueMember = "idCentroCosto"
            ComboUnidadNegocio.DisplayMember = "nombre"
            IdUnidadNegocio = ComboUnidadNegocio.SelectedValue

            'ComboUnidadNegocio.SelectedValue = IdUnidadNegocio

        Catch ex As Exception
            Throw New Exception("Verificar Ruc de la Empresa")
        End Try


        'GEstableciento = New GEstablecimiento
        'GEstableciento.IdEstablecimiento = SelEstablecimiento.idCentroCosto
        'GEstableciento.NombreEstablecimiento = SelEstablecimiento.nombre

    End Sub

    Private Function ValidarOK() As Boolean
        ValidarOK = True

        If IdEmpresaDefault.Trim.Length = 0 Then
            ErrorProvider1.SetError(UsernameTextBox, "Ingrese el número de ruc")
            ValidarOK = False
        End If

        If UsernameTextBox.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(UsernameTextBox, "Ingrese alias de usuario")
            ValidarOK = False
        Else
            ErrorProvider1.SetError(UsernameTextBox, String.Empty)
        End If

        If PasswordTextBox.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(PasswordTextBox, "Ingrese contraseña")
            ValidarOK = False
        Else
            ErrorProvider1.SetError(PasswordTextBox, String.Empty)
        End If
    End Function

    Sub autenticar()
        Try
            Dim Formulario As Object = Nothing
            Dim estado As Boolean
            Dim AutenticacionUsuarioSA As New AutenticacionUsuarioSA
            Dim AutenticacionXCargo As New UsuarioRolSA
            Dim AutorizacionRolSA As New AutorizacionRolSA
            Dim VerificarCajaSA As New cajaUsuarioSA
            Dim UsuarioBE As New Usuario
            Dim usauriosa As New UsuarioSA
            Dim rolBE As New UsuarioRol
            Dim UsuarioCompleto() As String, AliasUsuario As String 'IDCliente As String,
            'Dim RolGrupoEmpSA As New rolXGrupoEmpSA
            'SelEmpresa = New empresa
            clienteSoftpack = New clientesSoftPack

            'If Not ValidarOK() Then Exit Sub

            usuario = New AutenticacionUsuario
            UsuarioCompleto = UsernameTextBox.Text.Trim.Split("\")
            If UsuarioCompleto.Length = 2 Then
                AliasUsuario = UsuarioCompleto(1).Trim
                ' IDCliente = UsuarioCompleto(0)
            Else
                AliasUsuario = UsernameTextBox.Text.Trim
                ' IDCliente = "GENERICO"
            End If
            usuario.Alias = AliasUsuario
            usuario.Contrasena = PasswordTextBox.Text.Trim
            'usuario.IDCliente = empresaSPK.FirstOrDefault.idclientespk ' txtRUC.Text.Trim ' IDCliente

            usuario.IdEmpresa = SelEmpresa.idEmpresa
            usuario.IDEstablecimiento = IdUnidadNegocio
            usuario.tipoNegocio = SelEmpresa.actividad
            'SelEmpresa = empresaSA.UbicarEmpresaRuc(empresaSPK.FirstOrDefault.nroDoc)
            '  clienteSoftpack = ClientesSoftPackSA.GetEmpresasClientes("20392657020").FirstOrDefault
            'clienteSoftpack = ClientesSoftPackSA.GetProductoClientesXID(empresaSPK.FirstOrDefault.idclientespk)


            Select Case RoundButton23.Text
                Case "INGRESAR"

                    If AutenticacionUsuarioSA.getRecuperarUsaurioLogeo(usuario) Then
                        UserAccesoPermitido = True

                        If UserAccesoPermitido = True Then

                            AutenticacionUsuario = usuario

                            GetCombosCArgosxUsuario(usuario.CustomUsuario.CustomListaUsuarioRol)
                            ''Se obtiene los permisos necesarios
                            'AutorizacionRolList = AutorizacionRolSA.GetListaAutorizaciones(New AutorizacionRol With {.IdEmpresa = SelEmpresa.idEmpresa, .IDRol = usuario.CustomUsuario.CustomUsuarioRol.IDRol, .IDEstablecimiento = IdUnidadNegocio})
                            If (listaCargosXUsuario.Count = 1) Then

                                '////////////////////////////////////////////////////

                                listaUsuario = usuario.CustomUsuario.CustomListaUsuarioRol

                                If (listaUsuario.Count > 1) Then
                                    rolBE = listaUsuario.Where(Function(o) o.predeterminado = True).FirstOrDefault

                                    If (rolBE.control = "SA") Then
                                        'ListaRolGrupoEmpBE = RolGrupoEmpSA.GetListaXgrupoEmp(New RolXGrupoEmp With {.IDRol = rolBE.IDRol})
                                        'Dim idGrupoEmp = ListaRolGrupoEmpBE.Where(Function(o) o.IDReferencia = IdUnidadNegocio).FirstOrDefault
                                        'AutorizacionRolList = AutorizacionRolSA.GetListaAutorizacionesSingle(New AutorizacionRol With {.IdEmpresa = SelEmpresa.idEmpresa, .IDRol = rolBE.IDRol, .IDEstablecimiento = IdUnidadNegocio, .IDRolXGrupoEmp = idGrupoEmp.IDRolXGrupoEmp})

                                        AutorizacionRolList = AutorizacionRolSA.GetListaAutorizaciones(New AutorizacionRol With {.IdEmpresa = SelEmpresa.idEmpresa, .IDRol = rolBE.IDRol, .IDEstablecimiento = IdUnidadNegocio, .IDUsuario = rolBE.IDUsuario})


                                    Else
                                        AutorizacionRolList = AutorizacionRolSA.GetListaAutorizaciones(New AutorizacionRol With {.IdEmpresa = SelEmpresa.idEmpresa, .IDRol = rolBE.IDRol, .IDEstablecimiento = IdUnidadNegocio, .IDUsuario = rolBE.IDUsuario})

                                    End If
                                ElseIf (listaUsuario.Count = 1) Then
                                    rolBE = listaUsuario.FirstOrDefault
                                    AutorizacionRolList = AutorizacionRolSA.GetListaAutorizaciones(New AutorizacionRol With {.IdEmpresa = SelEmpresa.idEmpresa, .IDRol = rolBE.IDRol, .IDEstablecimiento = IdUnidadNegocio, .IDUsuario = rolBE.IDUsuario})
                                ElseIf (listaUsuario.Count <= 0) Then
                                    Throw New Exception("Verificar Cargo")
                                    RoundButton23.Enabled = True
                                End If

                                'Se obtiene los permisos necesarios

                                '  AutorizacionRolList = AutorizacionRolSA.GetAutorizacionesELI(New AutorizacionRol With {.IDCliente = SelEmpresa.idclientespk, .IDRol = usuario.CustomUsuario.CustomUsuarioRol.IDRol})

                                'Me.Close()

                                estado = VerificarCajaSA.VerificarCajaEstadoXUsuario(usuario.IDUsuario)

                                empresaSPK.FirstOrDefault.TieneCaja = estado
                                usuario.TieneCaja = estado

                                usuario.IDRol = rolBE.IDRol
                                usuario.nombreCargo = rolBE.nombrePerfil
                                usuario.tipoCaja = rolBE.tipoEF
                                usuario.tipoCargo = rolBE.control
                                'GetGlobalMapping()

                                If usuario.TieneCaja = True Then

                                    'una sola caja
                                    Dim usuarioCaja = VerificarCajaSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)


                                    'multicajas
                                    'Dim shostname As String
                                    'shostname = System.Net.Dns.GetHostName

                                    'Dim usuarioCaja = (From i In OpenBoxList
                                    '                   Where i.idPersona = usuario.IDUsuario And i.estadoCaja = "A" And i.namepc = shostname _
                                    '                  And i.enUso = "S").FirstOrDefault

                                    If usuarioCaja IsNot Nothing Then
                                        GetGlobalMappingCajaUsuario(usuarioCaja)
                                    Else
                                        MessageBox.Show("Verificar la asiganción de cajas", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        Exit Sub
                                    End If
                                End If

                                Tag = "Grabado"

                                '///////////////////////////////////////////////////

                            ElseIf (listaCargosXUsuario.Count > 1) Then
                                PNCARGOS.Visible = True
                                Tag = "Verificar"
                                RoundButton23.Enabled = True
                            ElseIf (listaCargosXUsuario.Count = 0) Then

                                If (usuario.CustomUsuario.Nombres = "ADMINISTRADOR" And usuario.CustomUsuario.TipoDocumento = "SUPER") Then
                                    'ListaRolGrupoEmpBE = RolGrupoEmpSA.GetListaXgrupoEmp(New RolXGrupoEmp With {.IDRol = rolBE.IDRol})
                                    'Dim idGrupoEmp = ListaRolGrupoEmpBE.Where(Functionusuario.CustomUsuarioo) o.IDReferencia = IdUnidadNegocio).FirstOrDefault
                                    'AutorizacionRolList = AutorizacionRolSA.GetListaAutorizacionesSingle(New AutorizacionRol With {.IdEmpresa = SelEmpresa.idEmpresa, .IDRol = rolBE.IDRol, .IDEstablecimiento = IdUnidadNegocio, .IDRolXGrupoEmp = idGrupoEmp.IDRolXGrupoEmp})
                                    Tag = "Grabado"
                                    AutorizacionRolList = AutorizacionRolSA.GetListaAutorizaciones(New AutorizacionRol With {.IdEmpresa = SelEmpresa.idEmpresa, .IDRol = rolBE.IDRol, .IDEstablecimiento = IdUnidadNegocio, .IDUsuario = rolBE.IDUsuario})
                                    usuario.nombreCargo = "SUPER_ADMINISTRADOR"
                                Else
                                    Throw New Exception("Verificar el Cargo")
                                    RoundButton23.Enabled = True
                                End If
                            End If


                        End If
                    Else
                        UserAccesoPermitido = False
                                MessageBox.Show("Usuario o clave incorrecto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                RoundButton23.Enabled = True
                              Exit Sub
                        End If


                Case "ACCEDER"
                    If (Not IsNothing(dgPerfilesUsuario.Table.CurrentRecord)) Then

                        If UserAccesoPermitido = True Then
                            'UserAccesoPermitido = True
                            'Se supone que FORM1 es un MDI y que todos los formularios lo utilizan.
                            'Dim usuariorecuperado = AutenticacionUsuarioSA.getRecuperarUsaurioLogeo(usuario)
                            AutenticacionUsuario = usuario

                            '  AutorizacionRolList = AutorizacionRolSA.GetAutorizacionesELI(New AutorizacionRol With {.IDCliente = SelEmpresa.idclientespk, .IDRol = usuario.CustomUsuario.CustomUsuarioRol.IDRol})

                            'Me.Close()

                            If (listaCargosXUsuario.Count > 1) Then
                                rolBE = listaCargosXUsuario.Where(Function(o) o.IDRol = cargoSeleccionado).FirstOrDefault
                                RoundButton23.Enabled = True
                                If (rolBE.control = "SA") Then
                                    'ListaRolGrupoEmpBE = RolGrupoEmpSA.GetListaXgrupoEmp(New RolXGrupoEmp With {.IDRol = rolBE.IDRol})
                                    'Dim GrupoEmp = ListaRolGrupoEmpBE.Where(Function(o) o.IDReferencia = IdUnidadNegocio).FirstOrDefault

                                    If (cargoSeleccionado > 0) Then
                                        'Se obtiene los permisos necesarios
                                        'AutorizacionRolList = AutorizacionRolSA.GetListaAutorizacionesSingle(New AutorizacionRol With {.IdEmpresa = SelEmpresa.idEmpresa, .IDRol = cargoSeleccionado, .IDEstablecimiento = IdUnidadNegocio, .IDRolXGrupoEmp = GrupoEmp.IDRolXGrupoEmp})
                                        AutorizacionRolList = AutorizacionRolSA.GetListaAutorizaciones(New AutorizacionRol With {.IdEmpresa = SelEmpresa.idEmpresa, .IDRol = cargoSeleccionado, .IDEstablecimiento = IdUnidadNegocio, .IDUsuario = rolBE.IDUsuario})
                                    Else
                                        Throw New Exception("Verificar el Cargo")
                                        RoundButton23.Enabled = True
                                    End If

                                    'AutorizacionRolList = AutorizacionRolSA.GetListaAutorizacionesSingle(New AutorizacionRol With {.IdEmpresa = SelEmpresa.idEmpresa, .IDRol = rolBE.IDRol, .IDEstablecimiento = IdUnidadNegocio, .IDRolXGrupoEmp = idGrupoEmp.IDRolXGrupoEmp})

                                Else
                                    'AutorizacionRolList = AutorizacionRolSA.GetListaAutorizaciones(New AutorizacionRol With {.IdEmpresa = SelEmpresa.idEmpresa, .IDRol = rolBE.IDRol, .IDEstablecimiento = IdUnidadNegocio})
                                    If (cargoSeleccionado > 0) Then
                                        'Se obtiene los permisos necesarios
                                        AutorizacionRolList = AutorizacionRolSA.GetListaAutorizaciones(New AutorizacionRol With {.IdEmpresa = SelEmpresa.idEmpresa, .IDRol = cargoSeleccionado, .IDEstablecimiento = IdUnidadNegocio, .IDUsuario = rolBE.IDUsuario})
                                    Else
                                        Throw New Exception("Verificar el Cargo")
                                        RoundButton23.Enabled = True
                                    End If
                                End If

                            ElseIf (listaCargosXUsuario.Count <= 0) Then
                                Throw New Exception("Verificar Cargo")
                                RoundButton23.Enabled = True
                            End If

                            estado = VerificarCajaSA.VerificarCajaEstadoXUsuario(usuario.IDUsuario)
                            empresaSPK.FirstOrDefault.TieneCaja = estado
                            usuario.IDUsuario = rolBE.IDUsuario
                            usuario.TieneCaja = estado
                            usuario.IDRol = rolBE.IDRol
                            usuario.nombreCargo = rolBE.nombrePerfil
                            usuario.tipoCaja = rolBE.tipoEF
                            usuario.tipoCargo = rolBE.control
                            'GetGlobalMapping()

                            If usuario.TieneCaja = True Then

                                'una sola caja
                                Dim usuarioCaja = VerificarCajaSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)


                                'multicajas
                                'Dim shostname As String
                                'shostname = System.Net.Dns.GetHostName

                                'Dim usuarioCaja = (From i In OpenBoxList
                                '                   Where i.idPersona = usuario.IDUsuario And i.estadoCaja = "A" And i.namepc = shostname _
                                '                  And i.enUso = "S").FirstOrDefault



                                If usuarioCaja IsNot Nothing Then
                                    GetGlobalMappingCajaUsuario(usuarioCaja)
                                Else
                                    MessageBox.Show("Verificar la asiganción de cajas", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    RoundButton23.Enabled = True
                                    Exit Sub
                                End If
                            End If

                            Tag = "Grabado"
                        Else

                            MessageBox.Show("Usuario o clave incorrecto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            RoundButton23.Enabled = True
                            Exit Sub
                        End If
                    Else
                        MessageBox.Show("Seleccione un cargo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        RoundButton23.Enabled = True
                        Exit Sub
                    End If
            End Select


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GetGlobalMappingCajaUsuario(be As cajaUsuario)
        GFichaUsuarios = New GFichaUsuario
        GFichaUsuarios.IdCajaUsuario = be.idcajaUsuario
        GFichaUsuarios.IdPersona = usuario.IDUsuario
        GFichaUsuarios.NombrePersona = usuario.CustomUsuario.Nombres & ", " & usuario.CustomUsuario.ApellidoPaterno & " " & usuario.CustomUsuario.ApellidoMaterno
        GFichaUsuarios.ClaveUsuario = String.Empty
    End Sub

    Private Sub RoundButton23_Click(sender As Object, e As EventArgs) Handles RoundButton23.Click
        'Try

        If RoundButton23.Text = "INGRESAR" Then
            RoundButton23.Enabled = False
            ProgressBar2.Visible = True

            If Not ValidarOK() Then
                RoundButton23.Enabled = True
                Exit Sub
            End If
            Me.SuspendLayout()
            Me.ResumeLayout(True)
            ValidarRUCDNICorrecto()

            If empresaSPK.Count > 0 Then
                Call BackgroundWorker1.RunWorkerAsync()
            Else
                MessageBox.Show("Debe ingresar correctamente el RUC", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'fso.Dispose()
                ProgressBar2.Visible = False
                'RoundButton23.Enabled = True
                RoundButton23.Text = "INGRESAR"
                RoundButton23.BackColor = Color.FromArgb(17, 87, 197)
                RoundButton23.MetroColor = Color.FromArgb(17, 87, 197)
                'txtRUC.Select()
                Exit Sub
            End If

        ElseIf RoundButton23.Text = "ACCEDER" Then
            Try
                '//SE MODIFICO EL CODIGO
                'RoundButton23.Enabled = False
                ProgressBar2.Visible = True

                If Not ValidarOK() Then
                    RoundButton23.Enabled = True
                    Exit Sub
                End If
                Me.SuspendLayout()
                Me.ResumeLayout(True)
                ValidarRUCDNICorrecto()

                If empresaSPK.Count > 0 Then
                    Call BackgroundWorker1.RunWorkerAsync()
                Else
                    MessageBox.Show("Debe ingresar correctamente el RUC", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    'fso.Dispose()
                    ProgressBar2.Visible = False
                    'RoundButton23.Enabled = True
                    RoundButton23.Text = "ACCEDER"
                    RoundButton23.BackColor = Color.FromArgb(17, 87, 197)
                    RoundButton23.MetroColor = Color.FromArgb(17, 87, 197)
                    'txtRUC.Select()
                    Exit Sub
                End If
                '//-------------------------------------------------------------------

                'If ComboUnidadNegocio.Text.Trim.Length > 0 Then
                '    GEstableciento = New GEstablecimiento
                '    GEstableciento.IdEstablecimiento = ComboUnidadNegocio.SelectedValue
                '    GEstableciento.NombreEstablecimiento = ComboUnidadNegocio.Text

                '    Hide()

                '    'Creamos el "Document"
                '    m_xmld = New XmlDocument()

                '    'Cargamos el archivo
                '    m_xmld.Load("C:\SPKconfiguration.xml")

                '    'Obtenemos la lista de los nodos "name"
                '    m_nodelist = m_xmld.SelectNodes("/spk/company")

                '    'Iniciamos el ciclo de lectura
                '    For Each m_node In m_nodelist
                '        'Obtenemos el Formulario de inicio
                '        Formulario = m_node.ChildNodes.Item(6).InnerText
                '        Exit For
                '    Next



                '    'cargando configuracion de caja

                '    Dim tipoCaja As Integer = 1
                '    m_xmld = New XmlDocument()
                '    m_xmld.Load("C:\SPKconfiguration.xml")
                '    Dim m_nodeAPI = m_xmld.SelectNodes("/spk/company/typeBox")
                '    For Each m_node In m_nodeAPI
                '        'Obtenemos el Elemento tipo caja
                '        Dim ApiCodigo = m_node.ChildNodes.Item(0).InnerText
                '        If ApiCodigo.ToString.Trim.Length > 0 Then
                '            tipoCaja = ApiCodigo
                '            Exit For
                '        End If
                '    Next

                '    If tipoCaja = 1 Then
                '        GconfigCaja = "1"
                '    ElseIf tipoCaja = 2 Then
                '        GconfigCaja = "2"
                '    Else
                '        GconfigCaja = "1"
                '    End If



                '    'Dim frm As MetroForm = Application.OpenForms.OfType(Of MetroForm)().Where(Function(pre) pre.Name = "FormTablaPrincipal").SingleOrDefault
                '    If Formulario = "FormTablaPrincipal" Then
                '        Dim frm As MetroForm = Application.OpenForms.OfType(Of MetroForm)().Where(Function(pre) pre.Name = "FormTablaPrincipal").SingleOrDefault
                '        If frm Is Nothing Then
                '            frmMaestroModuloPOSV2 = New FormTablaPrincipal
                '            frmMaestroModuloPOSV2.Show()
                '        Else

                '        End If
                '    ElseIf Formulario = "FormTablaPrincipalPOS" Then
                '        Dim frm As MetroForm = Application.OpenForms.OfType(Of MetroForm)().Where(Function(pre) pre.Name = "FormTablaPrincipalPOS").SingleOrDefault
                '        If frm Is Nothing Then
                '            frmMaestroModuloPOS = New FormTablaPrincipalPOS
                '            frmMaestroModuloPOS.Show()
                '        Else

                '        End If
                '    ElseIf Formulario = "FormTablaPrincipalCaja" Then

                '        Dim frm As MetroForm = Application.OpenForms.OfType(Of MetroForm)().Where(Function(pre) pre.Name = "FormTablaPrincipalCaja").SingleOrDefault
                '        If frm Is Nothing Then
                '            FormTablaPrincipalCaja = New FormTablaPrincipalCaja
                '            FormTablaPrincipalCaja.Show()
                '        Else

                '        End If
                '    End If

                '    'If frm Is Nothing Then
                '    '    frmMaestroModuloPOSV2 = New FormTablaPrincipal
                '    '    frmMaestroModuloPOSV2.Show()
                '    'Else
                '    '    'frmMaestroModuloPOSV2.WindowState = FormWindowState.Normal
                '    '    'frmMaestroModuloPOSV2.BringToFront()
                '    'End If
                'Else
                '    MessageBox.Show("Debe indicar una unidad de negocio!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '    RoundButton23.Enabled = True
                'End If
            Catch ex As Exception
                MsgBox(ex.Message)
                'RoundButton23.Enabled = True
            End Try
        End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        '    RoundButton23.Enabled = True
        'End Try
    End Sub

    Private Sub ValidarRUCDNICorrecto()
        'If IdEmpresaDefault.InvokeRequired Then
        '    Dim deleg As New _delegadoValidarRUCDNI(AddressOf ValidarRUCDNICorrecto)
        '    Invoke(deleg, New Object() {})
        'Else
        ValidarRucCliente(IdEmpresaDefault)
        'End If
    End Sub

    Private Sub ValidarRucCliente(ruc As String)
        empresaSPK = New List(Of clientesSoftPack)
        empresaSPK = ClientesSoftPackSA.GetEmpresasClientes(ruc)
        If empresaSPK.Count = 1 Then

            'txtRUC.ForeColor = Color.GreenYellow ' Color.FromArgb(192, 0, 192)
        ElseIf empresaSPK.Count = 0 Then
            'txtRUC.ForeColor = Color.Red
            MessageBox.Show("VERIFICAR EL RUC")
        Else
            MessageBox.Show("VERIFICAR EL RUC")
            'txtRUC.ForeColor = Color.Black
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        'autenticar()
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        'fso.Dispose()
        autenticar()

        Dim Formulario As Object = Nothing
        Me.Enabled = True
        ComboUnidadNegocio.Visible = True
        Label3.Visible = True
        If Tag = "Grabado" Then
            'GetCombosInicio()
            TextEmpresa.Tag = Gempresas.IdEmpresaRuc
            TextEmpresa.Text = Gempresas.NomEmpresa
            If (empresaSPK.FirstOrDefault.TieneCaja = False) Then
                'Close()
                ' PanelLogin.Visible = False
            ElseIf (empresaSPK.FirstOrDefault.TieneCaja = True) Then
                HabilitarUsoCaja(usuario.IDUsuario)
                'Close()
                '  PanelLogin.Visible = False
            End If
            ''RoundButton23.Enabled = True
            'RoundButton23.Text = "ACCEDER"
            'RoundButton23.BackColor = Color.FromArgb(22, 169, 110)
            'RoundButton23.MetroColor = Color.FromArgb(22, 169, 110)
            ''RoundButton21.PerformClick()
            ''If usuario.CustomUsuario.CustomUsuarioRol.IDRol = 1 Then

            ''ElseIf usuario.CustomUsuario.CustomUsuarioRol.IDRol = 2 Then

            ''ElseIf usuario.CustomUsuario.CustomUsuarioRol.IDRol = 3 Then
            ''    HabilitarUsoCaja(usuario.IDUsuario)
            ''ElseIf usuario.CustomUsuario.CustomUsuarioRol.IDRol = 4 Then
            ''    HabilitarUsoCaja(usuario.IDUsuario)
            ''End If

            ''Dispose()


            Dim unidadaNegocio As New centrocosto
            unidadaNegocio = ListaUnidadesNegocio.Where(Function(o) o.TipoEstab = "UN" And o.idCentroCosto = IdUnidadNegocio And o.idEmpresa = IdEmpresaDefault).FirstOrDefault


            'If ComboUnidadNegocio.Text.Trim.Length > 0 Then
            If (IdUnidadNegocio > 0) Then


                GEstableciento = New GEstablecimiento
                GEstableciento.IdEstablecimiento = unidadaNegocio.idCentroCosto ' ComboUnidadNegocio.SelectedValue
                GEstableciento.NombreEstablecimiento = unidadaNegocio.nombre ' ComboUnidadNegocio.Text

                Hide()

                'Creamos el "Document"
                m_xmld = New XmlDocument()

                'Cargamos el archivo
                m_xmld.Load("C:\SPKconfiguration.xml")

                'Obtenemos la lista de los nodos "name"
                m_nodelist = m_xmld.SelectNodes("/spk/company")

                'Iniciamos el ciclo de lectura
                For Each m_node In m_nodelist
                    'Obtenemos el Formulario de inicio
                    Formulario = m_node.ChildNodes.Item(4).InnerText
                    Exit For
                Next



                'cargando configuracion de caja

                Dim tipoCaja As Integer = 1
                m_xmld = New XmlDocument()
                m_xmld.Load("C:\SPKconfiguration.xml")
                Dim m_nodeAPI = m_xmld.SelectNodes("/spk/company/typeBox")
                For Each m_node In m_nodeAPI
                    'Obtenemos el Elemento tipo caja
                    Dim ApiCodigo = m_node.ChildNodes.Item(0).InnerText
                    If ApiCodigo.ToString.Trim.Length > 0 Then
                        tipoCaja = ApiCodigo
                        Exit For
                    End If
                Next

                If tipoCaja = 1 Then
                    GconfigCaja = "1"
                ElseIf tipoCaja = 2 Then
                    GconfigCaja = "2"
                Else
                    GconfigCaja = "1"
                End If


                If Formulario = "FormTablaPrincipal" Then
                    Dim frm As MetroForm = Application.OpenForms.OfType(Of MetroForm)().Where(Function(pre) pre.Name = "FormTablaPrincipal").SingleOrDefault
                    If frm Is Nothing Then
                        frmMaestroModuloPOSV2 = New FormTablaPrincipal
                        frmMaestroModuloPOSV2.Show()
                    Else

                    End If
                ElseIf Formulario = "FormTablaPrincipalBasic" Then
                    Dim frm As MetroForm = Application.OpenForms.OfType(Of MetroForm)().Where(Function(pre) pre.Name = "FormTablaPrincipalBasic").SingleOrDefault
                    If frm Is Nothing Then
                        frmMaestroModuloBasic = New FormTablaPrincipalBasic
                        frmMaestroModuloBasic.StartPosition = FormStartPosition.CenterScreen
                        frmMaestroModuloBasic.Show()
                    Else

                    End If

                ElseIf Formulario = "FormTablaPrincipalTransporte" Then
                    Dim frm As MetroForm = Application.OpenForms.OfType(Of MetroForm)().Where(Function(pre) pre.Name = "FormTablaPrincipalBasic").SingleOrDefault
                    If frm Is Nothing Then
                        FormTablaPrincipalTransportes = New FormTablaPrincipalTransportes
                        FormTablaPrincipalTransportes.StartPosition = FormStartPosition.CenterScreen
                        FormTablaPrincipalTransportes.Show()
                    Else

                    End If

                ElseIf Formulario = "FormTablaPrincipalPOS" Then
                    Dim frm As MetroForm = Application.OpenForms.OfType(Of MetroForm)().Where(Function(pre) pre.Name = "FormTablaPrincipalPOS").SingleOrDefault
                    If frm Is Nothing Then
                        frmMaestroModuloPOS = New FormTablaPrincipalPOS
                        frmMaestroModuloPOS.Show()
                    Else

                    End If
                ElseIf Formulario = "FormTablaPrincipalCaja" Then

                    Dim frm As MetroForm = Application.OpenForms.OfType(Of MetroForm)().Where(Function(pre) pre.Name = "FormTablaPrincipalCaja").SingleOrDefault
                    If frm Is Nothing Then
                        FormTablaPrincipalCaja = New FormTablaPrincipalCaja
                        FormTablaPrincipalCaja.Show()
                    Else

                    End If
                End If
            Else
                MessageBox.Show("Debe indicar una unidad de negocio!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'RoundButton23.Enabled = True
            End If
            'Else
            '    MessageBox.Show("Debe indicar una unidad de negocio!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    'RoundButton23.Enabled = True
            'End If
        ElseIf Tag = "Verificar" Then
            RoundButton23.Text = "ACCEDER"
            'GetCombosCArgosxUsuario(usuario.CustomUsuario.CustomListaUsuarioRol)

        Else
            RoundButton23.Enabled = True
            TextEmpresa.Tag = String.Empty
            TextEmpresa.Text = String.Empty
            'RoundButton23.Enabled = True
            RoundButton23.Text = "INGRESAR"
            'RoundButton23.BackColor = Color.FromArgb(17, 87, 197)
            'RoundButton23.MetroColor = Color.FromArgb(17, 87, 197)
            'MessageBox.Show("Verifique el ingreso correcto del Usuario o clave", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            UsernameTextBox.Select()
        End If
        ProgressBar2.Visible = False
    End Sub

    Public Sub HabilitarUsoCaja(intIdUsuario As Integer)
        'Dim cajaUsuarioSA As New cajaUsuarioSA
        'Dim cajaUsuario As New cajaUsuario
        'Dim efSA As New EstadosFinancierosSA
        'Dim NEstadosSA As New estadosFinancieros


        'GFichaUsuarios = GFichaUsuario.InstanceSingle()
        'GFichaUsuarios.Clear()
        'Dim UsuarioEstadoCaja As New UsuarioEstadoCaja

        'cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(intIdUsuario, "A", "S", Nothing)

        'If Not IsNothing(cajaUsuario) Then
        '    With cajaUsuario
        '        NEstadosSA = efSA.GetUbicar_estadosFinancierosPorID(.idCajaOrigen)
        '        GFichaUsuarios.IdCajaUsuario = .idcajaUsuario
        '        GFichaUsuarios.IdPersona = .idPersona
        '        GFichaUsuarios.NombrePersona = usuario.Alias
        '        GFichaUsuarios.ClaveUsuario = .claveIngreso
        '        GFichaUsuarios.IdCajaOrigen = .idCajaOrigen
        '        GFichaUsuarios.IdCajaDestino = .idCajaOrigen
        '        GFichaUsuarios.cuentaDestino = NEstadosSA.cuenta
        '        GFichaUsuarios.NomCajaDestinb = NEstadosSA.descripcion
        '        GFichaUsuarios.FechaApertura = .fechaRegistro
        '        GFichaUsuarios.Moneda = .moneda
        '        GFichaUsuarios.TipoCambio = .tipoCambio
        '        GFichaUsuarios.FondoMN = .fondoMN
        '        GFichaUsuarios.FondoME = .fondoME
        '        GFichaUsuarios.EstadoCaja = .idcajaUsuario
        '        GFichaUsuarios.EnUso = .idcajaUsuario
        '        UsuarioEstadoCaja.GetSaldoActual(GFichaUsuarios)
        '    End With
        'Else
        '    'MessageBoxAdv.Show("No tiene asiganda una caja!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    'Throw New Exception("No tiene asiganda una caja!")
        'End If


        ''With cajaUsuarioSA.UbicarCajaAsignadaUser(txtDni.Text.Trim, "A", "S", txtClave.Text.Trim)
        ''    NEstadosSA = efSA.GetUbicar_estadosFinancierosPorID(.idCajaDestino)
        ''    GFichaUsuarios.IdCajaUsuario = .idcajaUsuario
        ''    GFichaUsuarios.IdPersona = .idPersona
        ''    GFichaUsuarios.NombrePersona = txtPersona.Text.Trim
        ''    GFichaUsuarios.ClaveUsuario = .claveIngreso
        ''    GFichaUsuarios.IdCajaOrigen = .idCajaOrigen
        ''    GFichaUsuarios.IdCajaDestino = .idCajaDestino
        ''    GFichaUsuarios.cuentaDestino = NEstadosSA.cuenta
        ''    GFichaUsuarios.NomCajaDestinb = NEstadosSA.descripcion
        ''    GFichaUsuarios.FechaApertura = .fechaRegistro
        ''    GFichaUsuarios.Moneda = .moneda
        ''    GFichaUsuarios.TipoCambio = .tipoCambio
        ''    GFichaUsuarios.FondoMN = CDec(.fondoMN + (montoMNF))
        ''    GFichaUsuarios.FondoME = CDec(.fondoME + (montoMEF))
        ''    GFichaUsuarios.EstadoCaja = .idcajaUsuario
        ''    GFichaUsuarios.EnUso = .idcajaUsuario
        ''End With
        'Dispose()

        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim cajaUsuario As New cajaUsuario
        Dim efSA As New EstadosFinancierosSA
        Dim NEstadosSA As New estadosFinancieros


        GFichaUsuarios = GFichaUsuario.InstanceSingle()
        GFichaUsuarios.Clear()
        Dim UsuarioEstadoCaja As New UsuarioEstadoCaja

        cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(intIdUsuario, "A", "S", Nothing)

        '
        If Not IsNothing(cajaUsuario) Then
            With cajaUsuario
                'NEstadosSA = efSA.GetUbicar_estadosFinancierosPorID(.idCajaOrigen)
                GFichaUsuarios.IdCajaUsuario = .idcajaUsuario
                GFichaUsuarios.IdPersona = .idPersona
                GFichaUsuarios.NombrePersona = usuario.Alias
                GFichaUsuarios.ClaveUsuario = .claveIngreso
                GFichaUsuarios.IdCajaOrigen = .idCajaOrigen.GetValueOrDefault
                GFichaUsuarios.IdCajaDestino = .idCajaOrigen.GetValueOrDefault
                GFichaUsuarios.cuentaDestino = NEstadosSA.cuenta
                GFichaUsuarios.NomCajaDestinb = NEstadosSA.descripcion
                GFichaUsuarios.FechaApertura = .fechaRegistro
                GFichaUsuarios.Moneda = .moneda
                GFichaUsuarios.TipoCambio = .tipoCambio
                GFichaUsuarios.FondoMN = .fondoMN
                GFichaUsuarios.FondoME = .fondoME
                GFichaUsuarios.EstadoCaja = .estadoCaja
                GFichaUsuarios.EnUso = .idcajaUsuario
                UsuarioEstadoCaja.GetSaldoActual(GFichaUsuarios)
            End With
        Else
            'MessageBoxAdv.Show("No tiene asiganda una caja!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'Throw New Exception("No tiene asiganda una caja!")
        End If

        'Dispose()
    End Sub

    Private Sub GetComboUnidaNegocio(IDSegemento As Integer)
        listaUnidadNegocios = ListaUnidadesNegocio.Where(Function(o) o.TipoEstab = "UN" And o.idpadre = IDSegemento).ToList
        ComboUnidadNegocio.DataSource = listaUnidadNegocios
        ComboUnidadNegocio.ValueMember = "idCentroCosto"
        ComboUnidadNegocio.DisplayMember = "nombre"
        IdUnidadNegocio = ComboUnidadNegocio.SelectedValue
    End Sub

    Private Function TerminarProceso(ByVal StrNombreProceso As String,
    Optional ByVal DecirSINO As Boolean = True) As Boolean
        ' Variables para usar Wmi  
        Dim ListaProcesos As Object
        Dim ObjetoWMI As Object
        Dim ProcesoACerrar As Object

        TerminarProceso = False

        ObjetoWMI = GetObject("winmgmts:")

        If ObjetoWMI Is DBNull.Value = False Then

            'instanciamos la variable  
            ListaProcesos = ObjetoWMI.InstancesOf("win32_process")

            For Each ProcesoACerrar In ListaProcesos
                If UCase(ProcesoACerrar.Name) = UCase(StrNombreProceso) Then
                    If DecirSINO Then
                        '   If MsgBox("¿Matar el proceso " & _
                        'ProcesoACerrar.Name & vbNewLine & "...¿Está seguro?", _
                        '                      vbYesNo + vbCritical) = vbYes Then

                        ProcesoACerrar.Terminate(0)
                        TerminarProceso = True
                        '  End If
                    Else
                        'Matamos el proceso con el método Terminate  
                        ProcesoACerrar.Terminate(0)
                        TerminarProceso = True
                    End If
                End If

            Next
        End If

        'Elimina las variables  
        ListaProcesos = Nothing
        ObjetoWMI = Nothing
    End Function
#End Region

#Region "Events"


    'Dim f As New frmMaestroModuloPOSV2
    'f.Show()
    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        Try
            GEstableciento = New GEstablecimiento
            GEstableciento.IdEstablecimiento = ComboUnidadNegocio.SelectedValue
            GEstableciento.NombreEstablecimiento = ComboUnidadNegocio.Text
            '   Close()
            Hide()
            'Dim frm As MetroForm = Application.OpenForms.OfType(Of MetroForm)().Where(Function(pre) pre.Name = "frmMaestroModuloPOSV2").SingleOrDefault
            'If frm Is Nothing Then
            '    frmMaestroModuloPOSV2 = New frmMaestroModuloPOSV2
            '    frmMaestroModuloPOSV2.Show()
            'Else
            '    'frmMaestroModuloPOSV2.WindowState = FormWindowState.Normal
            '    'frmMaestroModuloPOSV2.BringToFront()
            'End If

            Dim frm As MetroForm = Application.OpenForms.OfType(Of MetroForm)().Where(Function(pre) pre.Name = "FormTablaPrincipal").SingleOrDefault
            If frm Is Nothing Then
                frmMaestroModuloPOSV2 = New FormTablaPrincipal
                frmMaestroModuloPOSV2.Show()
            Else
                'frmMaestroModuloPOSV2.WindowState = FormWindowState.Normal
                'frmMaestroModuloPOSV2.BringToFront()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FormOrgainizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim boundWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim boundHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        Dim x As Integer = boundWidth - Me.Width
        Dim y As Integer = boundHeight - Me.Height
        Me.Location = New Point(x \ 2, y \ 2)
    End Sub

    Private Sub FormOrgainizacion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'TerminarProceso("Helios.Cont.Presentation.WinForm")
        'TerminarProceso("SMSvcHost.exe")
        'Application.ExitThread()
    End Sub

    Private Sub bunifuImageButton2_Click(sender As Object, e As EventArgs) Handles bunifuImageButton2.Click
        Close()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TxtRUC_TextChanged(sender As Object, e As EventArgs)
        'Try
        '    If (txtRUC.Text.Length < 11) Then
        '        ComboRubro.DataSource = Nothing
        '        ComboSegmento.DataSource = Nothing
        '        ComboUnidadNegocio.DataSource = Nothing
        '        UsernameTextBox.Clear()
        '        PasswordTextBox.Clear()
        '    ElseIf (txtRUC.Text.Length = 11) Then
        '        SelEmpresa = empresaSA.UbicarEmpresaRuc(txtRUC.Text)
        '        GetGlobalMapping()
        '        If (Not IsNothing(ListaUnidadesNegocio)) Then
        '            If (ListaUnidadesNegocio.Count > 0) Then
        '                GetCombosInicio()
        '                RoundButton23.Enabled = True
        '            End If
        '        End If
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try

    End Sub

    Private Sub ComboUnidadNegocio_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboUnidadNegocio.SelectionChangeCommitted
        Try
            IdUnidadNegocio = ComboUnidadNegocio.SelectedValue
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub comboCargo_SelectionChangeCommitted(sender As Object, e As EventArgs)
        'Try
        '    cargoSeleccionado = comboCargo.SelectedValue
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        Try
            Dim Vendedor As String = "SOFTPACK"
            Vendedor = GetCodigoVendedor()
            If Vendedor Is Nothing Then
                Throw New Exception("Debe indicar el codigo de acceso!")
            Else
                Hide()
                Dim f As New FormRepositoryConfEmpresa
                f.StartPosition = FormStartPosition.CenterParent
                f.Show()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            'SelEmpresa = empresaSA.UbicarEmpresaRuc(IdEmpresaDefault)
            IdEmpresaDefault = CStr(txtRuc.Text)
            GetGlobalMapping()
            ProgressBar2.Style = ProgressBarStyle.Marquee
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgPerfilesUsuario_TableControlCellClick(sender As Object, e As Grid.Grouping.GridTableControlCellClickEventArgs) Handles dgPerfilesUsuario.TableControlCellClick
        cargoSeleccionado = dgPerfilesUsuario.Table.CurrentRecord("ID")
    End Sub

#End Region
End Class