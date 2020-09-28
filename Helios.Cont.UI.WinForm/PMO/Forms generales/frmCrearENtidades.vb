Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports System.IO

Imports Tesseract
Imports System.Text.RegularExpressions
Imports System.Net
Imports HtmlAgilityPack
Imports Newtonsoft.Json

Public Class frmCrearENtidades
    Inherits frmMaster
    Public Property strTipo() As String
    Public Property intIdEntidad() As Integer
    Public Property ManipulacionEstado() As String
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()


        ' Add any initialization after the InitializeComponent() call.
        Try
            txtNomProv.Visible = True
            txtNomProv.Clear()
            txtApePat.Visible = False
            txtApePat.Clear()
            txtApeMaterno.Visible = False
            txtApeMaterno.Clear()
            Label31.Visible = False
            Label6.Visible = False
            Label30.Text = "Nombre o Razón Social:"
            cboTipoDoc.Text = "RUC"
            ManipulacionEstado = ENTITY_ACTIONS.INSERT
            'If IsConnectionAvailable() = True Then
            '    'CargarImagenSunat()
            '    'LeerCaptchaSunat()
            '    'CargarImagenReniec()
            '    'AplicacionFiltros()
            '    'LeerCaptchaReniec()
            'End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Sub New(nat As Boolean)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        txtNomProv.Visible = True
        txtNomProv.Clear()
        txtApePat.Visible = True
        txtApePat.Clear()

        txtApeMaterno.Visible = True
        txtApeMaterno.Clear()

        Label31.Visible = True
        Label30.Text = "Nombres:"
        Label6.Visible = True
        cboTipoDoc.Text = "DNI"
        rbNatural.Checked = nat
        rbJuridico.Enabled = True
        ManipulacionEstado = ENTITY_ACTIONS.INSERT
    End Sub

    Public Sub New(idEntidad As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        UbicarEntidad(idEntidad)
        ManipulacionEstado = ENTITY_ACTIONS.UPDATE
    End Sub

    Public Sub New(valor As Object)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        PictureLoad.Visible = True
        If IsNumeric(valor) Then
            txtDocProveedor.Text = valor
            limpiar()
            txtNomProv.Focus()
            If txtDocProveedor.Text.Trim.Length = 11 Then
                cboTipoDoc.Text = "RUC"
                Dim objeto As Boolean = ValidationRUC(txtDocProveedor.Text)
                If objeto = False Then
                    PictureLoad.Visible = False
                    MessageBox.Show("Debe Ingresar un Numero correcto de ruc", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Cursor = Cursors.Default
                    Exit Sub
                End If


                LinkLabel1.Enabled = False
                'PanelLoading.Visible = True
                'ProgressBar2.Visible = True
                'ProgressBar2.Style = ProgressBarStyle.Marquee



                GetConsultaSunatAsync(txtDocProveedor.Text.Trim)




            ElseIf txtDocProveedor.Text.Trim.Length = 8 Then
                cboTipoDoc.Text = "DNI"

                LinkLabel1.Enabled = False
                'PanelLoading.Visible = True
                'ProgressBar2.Visible = True
                'ProgressBar2.Style = ProgressBarStyle.Marquee

                GetConsultarDNIReniec(txtDocProveedor.Text.Trim)
            Else
                PictureLoad.Visible = False
                MessageBox.Show("Debe ingresar un número de documento", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtDocProveedor.Select()
            End If

        Else
            txtDocProveedor.Select()
            txtDocProveedor.Focus()
            txtNomProv.Text = valor
            PictureLoad.Visible = False

        End If
        'PictureLoad.Visible = False
    End Sub

    'Public Function IsConnectionAvailable() As Boolean
    '    ' Returns True if connection is available 
    '    ' Replace www.yoursite.com with a site that 
    '    ' is guaranteed to be online - perhaps your 
    '    ' corporate site, or microsoft.com 
    '    Dim objUrl As New System.Uri("http://www.softpack.com.pe")
    '    ' Setup WebRequest 
    '    Dim objWebReq As System.Net.WebRequest
    '    objWebReq = System.Net.WebRequest.Create(objUrl)
    '    Dim objResp As System.Net.WebResponse
    '    Try
    '        ' Attempt to get response and return True 
    '        objResp = objWebReq.GetResponse
    '        objResp.Close()
    '        objWebReq = Nothing
    '        Return True
    '    Catch ex As Exception
    '        ' Error, exit and return False 
    '        objWebReq = Nothing
    '        Return False
    '    End Try
    'End Function

#Region "Variables"
    'Dim red As New IntRange(0, 255)
    'Dim green As New IntRange(0, 255)
    'Dim blue As New IntRange(0, 255)
    Dim MyInfoSunat As SunatAPIV2
    Dim MyInfoReniec As Reniec
    Dim Texto As String = String.Empty
#End Region

#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean

        'If Not parpadear Then
        '    lblEstado.ForeColor = lblEstado.BackColor
        '    lblEstado.BackColor = Color.Yellow
        'Else
        '    lblEstado.ForeColor = SystemColors.WindowText
        'End If

        parpadear = Not parpadear
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If TiempoRestante > 0 Then
            parpadeo()

            'lblAgregar.Visible = True
            'lblMensaje.Visible = True
            'tsSave.Enabled = False
            'lblMensaje.Text = "Agregar otro en: " & TiempoRestante
            TiempoRestante = TiempoRestante - 1
        ElseIf TiempoRestante = 0 Then
            Timer1.Enabled = False
            'lblEstado.ForeColor = Color.Navy
            'lblEstado.BackColor = Color.Transparent
            PanelError.Visible = False
            '      Dispose()
        Else
            Timer1.Enabled = False
            'Ejecuta tu función cuando termina el tiempo
            TiempoEjecutar(10)

        End If
    End Sub
    Private TiempoRestante As Integer
    Public Sub TimerOn(ByRef Interval As Short)
        If Interval > 0 Then
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
        End If

    End Sub
    Public Function TiempoEjecutar(ByVal Tiempo As Integer)
        TiempoEjecutar = ""
        TiempoRestante = Tiempo  ' 1 minutos=60 segundos 
        Timer1.Interval = 400

        Call TimerOn(1000) ' Hechanos a andar el timer
    End Function
#End Region

#Region "metodos Sunat"
    Private Sub CargarImagenSunat()
        Try
            If MyInfoSunat Is Nothing Then
                MyInfoSunat = New SunatAPIV2()
            End If
            Me.pictureCapcha.Image = MyInfoSunat.GetCapcha
            LeerCaptchaSunat()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub LeerCaptchaSunat()
        Using engine = New TesseractEngine("./tessdata", "eng", EngineMode.[Default])
            Using image = New System.Drawing.Bitmap(pictureCapcha.Image)
                Using pix = PixConverter.ToPix(image)
                    Using page = engine.Process(pix)
                        Dim Porcentaje = [String].Format("{0:P}", page.GetMeanConfidence())
                        Dim CaptchaTexto As String = page.GetText()
                        Dim eliminarChars As Char() = {ControlChars.Lf, " "c}
                        CaptchaTexto = CaptchaTexto.TrimEnd(eliminarChars)
                        CaptchaTexto = CaptchaTexto.Replace(" ", String.Empty)
                        CaptchaTexto = Regex.Replace(CaptchaTexto, "[^a-zA-Z]+", String.Empty)
                        If CaptchaTexto <> String.Empty And CaptchaTexto.Length = 4 Then
                            txttexto.Text = CaptchaTexto.ToUpper()
                        Else
                            CargarImagenSunat()
                        End If
                    End Using
                End Using

            End Using
        End Using

    End Sub
    Private Sub Ciudad(Direccion As String)
        Dim array As [String]() = Direccion.Split("-"c)
        If array.Length > 1 Then
            Dim a As Integer = array.Length
            Dim DirTemp As [String] = array(a - 3).Trim()
            DirTemp = DirTemp.TrimEnd(" "c)
            Dim ArrayDir As [String]() = DirTemp.Split(" "c)
            Dim i As Integer = ArrayDir.Length
            'txtdepa.Text = ArrayDir(i - 1).Trim()
            'txtPrv.Text = array(a - 2).Trim()
            'txtDist.Text = array(a - 1).Trim()
        End If
    End Sub
    Private Sub limpiarSunat()
        'txtrucc.Text = String.Empty
        'txtdirecion.Text = String.Empty
        'txtrazon.Text = String.Empty
        'txtestado.Text = String.Empty
        'txttelfono.Text = String.Empty
        'txttipo.Text = String.Empty
        'txtdepa.Text = String.Empty
        'txtPrv.Text = String.Empty
        'txtDist.Text = String.Empty
        'txtruc.Text = String.Empty
        txttexto.Text = String.Empty
    End Sub
#End Region

#Region "Métodos"




    Public Property msj As String

    Public Function ValidationRUC(ruc As String) As Boolean
        msj = String.Empty

        If ruc.Length <> 11 Then
            msj = "NUMERO DE DIGITOS INVALIDO!!!."
            Return False

        End If

        Dim dig01 As Integer = Convert.ToInt32(ruc.Substring(0, 1)) * 5
        Dim dig02 As Integer = Convert.ToInt32(ruc.Substring(1, 1)) * 4
        Dim dig03 As Integer = Convert.ToInt32(ruc.Substring(2, 1)) * 3
        Dim dig04 As Integer = Convert.ToInt32(ruc.Substring(3, 1)) * 2
        Dim dig05 As Integer = Convert.ToInt32(ruc.Substring(4, 1)) * 7
        Dim dig06 As Integer = Convert.ToInt32(ruc.Substring(5, 1)) * 6
        Dim dig07 As Integer = Convert.ToInt32(ruc.Substring(6, 1)) * 5
        Dim dig08 As Integer = Convert.ToInt32(ruc.Substring(7, 1)) * 4
        Dim dig09 As Integer = Convert.ToInt32(ruc.Substring(8, 1)) * 3
        Dim dig10 As Integer = Convert.ToInt32(ruc.Substring(9, 1)) * 2
        Dim dig11 As Integer = Convert.ToInt32(ruc.Substring(10, 1))
        Dim suma As Integer = dig01 + dig02 + dig03 + dig04 + dig05 + dig06 + dig07 + dig08 + dig09 + dig10
        Dim residuo As Integer = suma Mod 11
        Dim resta As Integer = 11 - residuo
        Dim digChk As Integer = 0
        If resta = 10 Then
            digChk = 0

        ElseIf resta = 11 Then
            digChk = 1

        Else
            digChk = resta
        End If


        If dig11 = digChk Then
            msj = "NUMERO DE RUC VALIDO!!!."
            Return True

        Else
            msj = "NUMERO DE RUC INVALIDO!!!."
            Return False

        End If

        msj = "NUMERO DE RUC VALIDO!!!."
    End Function


    Public Sub tipoPersona(strTipo As String, numero As String)
        Select Case strTipo
            Case TIPO_ENTIDAD.CLIENTE
                txtNomProv.Visible = True
                txtNomProv.Clear()
                txtApePat.Visible = True
                txtApePat.Clear()
                Label31.Visible = True
                Label30.Text = "Nombres:"
                cboTipoDoc.Text = "DNI"
                rbNatural.Checked = True
            Case TIPO_ENTIDAD.PROVEEDOR
                txtNomProv.Visible = True
                txtNomProv.Clear()
                txtApePat.Visible = False
                txtApePat.Clear()
                Label31.Visible = False
                txtDocProveedor.Text = numero
                If (numero.ToString.Length > 8) Then
                    txtNomProv.Visible = True
                    txtNomProv.Clear()
                    txtApePat.Visible = False
                    txtApePat.Clear()
                    Label31.Visible = False
                    Label30.Text = "Nombre o Razón Social:"
                    cboTipoDoc.Text = "RUC"
                    rbJuridico.Checked = True
                    rbNatural.Checked = False
                Else
                    txtNomProv.Visible = True
                    txtNomProv.Clear()
                    txtApePat.Visible = True
                    txtApePat.Clear()
                    Label31.Visible = True
                    Label30.Text = "Nombre"
                    cboTipoDoc.Text = "DNI"
                    rbJuridico.Checked = False
                    rbNatural.Checked = True
                End If
        End Select
    End Sub

    Public Sub UbicarEntidad(intIdEntidad As Integer)
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad
        entidadSA = New entidadSA
        entidad = entidadSA.UbicarEntidadPorID(intIdEntidad).FirstOrDefault
        Select Case entidad.tipoDoc
            Case "6"
                cboTipoDoc.Text = "RUC"
            Case "1"
                cboTipoDoc.Text = "DNI"
            Case "7"
                cboTipoDoc.Text = "PASSAPORTE"
            Case "4"
                cboTipoDoc.Text = "CARNET DE EXTRANJERIA"
        End Select

        If entidad.tipoPersona = "N" Then
            rbNatural.Checked = True

            txtNomProv.Visible = True
            txtNomProv.Clear()
            txtApePat.Visible = True
            txtApePat.Clear()
            txtApeMaterno.Visible = True
            txtApeMaterno.Clear()
            Label31.Visible = True
            Label6.Visible = True
            Label30.Text = "Nombres:"

            txtNomProv.Text = entidad.nombre1
            txtApePat.Text = entidad.appat
            txtApeMaterno.Text = entidad.apmat


        Else
            rbJuridico.Checked = True

            txtNomProv.Visible = True
            txtNomProv.Clear()
            txtApePat.Visible = False
            txtApePat.Clear()
            txtApeMaterno.Visible = False
            txtApeMaterno.Clear()
            Label31.Visible = False
            Label6.Visible = False
            Label30.Text = "Nombre o Razón Social:"

            txtNomProv.Text = entidad.nombreCompleto
        End If
        txtNomProv.Text = entidad.nombreCompleto
        txtDocProveedor.Text = entidad.nrodoc
        txtDir.Text = entidad.direccion
        txtFoNo.Text = entidad.telefono
        txtContacto.Text = entidad.nombreContacto
        txtCorreo.Text = entidad.email
    End Sub

    Public Sub InsertEntidad()
        Dim obEntidad As New entidad
        Dim entidadSA As New entidadSA
        Try
            'Se asigna cada uno de los datos registrados
            obEntidad.idEmpresa = Gempresas.IdEmpresaRuc
            obEntidad.tipoEntidad = strTipo
            obEntidad.idOrganizacion = GEstableciento.IdEstablecimiento

            If cboTipoDoc.Text = "RUC" Then
                obEntidad.tipoDoc = "6"
            ElseIf cboTipoDoc.Text = "DNI" Then
                obEntidad.tipoDoc = "1"
            ElseIf cboTipoDoc.Text = "PASSAPORTE" Then
                obEntidad.tipoDoc = "7"
            ElseIf cboTipoDoc.Text = "CARNET DE EXTRANJERIA" Then
                obEntidad.tipoDoc = "4"
            End If
            obEntidad.nrodoc = txtDocProveedor.Text.Trim

            If rbNatural.Checked = True Then
                obEntidad.appat = String.Empty ' txtApePat.Text.Trim
                obEntidad.apmat = String.Empty 'txtApeMaterno.Text.Trim
                obEntidad.nombre1 = String.Empty 'txtNomProv.Text.Trim
                obEntidad.nombreCompleto = txtNomProv.Text.Trim ' obEntidad.appat & " " & txtApeMaterno.Text.Trim & ", " & obEntidad.nombre1
                obEntidad.tipoPersona = "N"
            ElseIf rbJuridico.Checked = True Then
                obEntidad.nombre = txtNomProv.Text.Trim
                obEntidad.nombreCompleto = txtNomProv.Text.Trim
                obEntidad.tipoPersona = "J"
            ElseIf RBnatConnegocio.Checked = True Then
                obEntidad.nombre = txtNomProv.Text.Trim
                obEntidad.nombreCompleto = txtNomProv.Text.Trim
                obEntidad.tipoPersona = "NJ"
            End If
            Select Case strTipo
                Case TIPO_ENTIDAD.PROVEEDOR
                    obEntidad.cuentaAsiento = "4212"
                Case TIPO_ENTIDAD.CLIENTE
                    obEntidad.cuentaAsiento = "1213"
            End Select

            obEntidad.estado = StatusEntidad.Activo
            If txtDir.Text.Trim.Length > 0 Then
                obEntidad.direccion = txtDir.Text.Trim
            Else
                obEntidad.direccion = Nothing
            End If

            If txtFoNo.Text.Trim.Length > 0 Then
                obEntidad.telefono = txtFoNo.Text.Trim
            Else
                obEntidad.telefono = Nothing
            End If

            obEntidad.nombreContacto = txtContacto.Text
            obEntidad.email = txtCorreo.Text
            obEntidad.usuarioModificacion = usuario.Alias
            obEntidad.fechaModificacion = DateTime.Now
            obEntidad.EnvioEntidades = chEntidades.Checked
            obEntidad.EnvioPlanilla = chPlanilla.Checked
            obEntidad.tipoEntidad = strTipo
            Dim codx As Integer = entidadSA.GrabarEntidad(obEntidad)

            Dim entidad As New entidad
            entidad.idEntidad = codx
            entidad.nrodoc = txtDocProveedor.Text.Trim
            entidad.nombreCompleto = obEntidad.nombreCompleto
            entidad.tipoDoc = obEntidad.tipoDoc
            Me.Tag = entidad

            Dispose()
        Catch ex As Exception
            'Manejo de errores
            MsgBox("No se pudo grabar el cliente." & vbCrLf & ex.Message, MsgBoxStyle.Critical)
            Me.Tag = Nothing
        End Try
    End Sub


    Public Sub EditarEntidad()
        Dim objCliente As New entidad
        Dim entidadSA As New entidadSA
        Try
            'Se asigna cada uno de los datos registrados
            objCliente.idEntidad = intIdEntidad
            objCliente.idEmpresa = Gempresas.IdEmpresaRuc
            objCliente.idOrganizacion = GEstableciento.IdEstablecimiento
            objCliente.tipoEntidad = strTipo

            If cboTipoDoc.Text = "RUC" Then
                objCliente.tipoDoc = "6"
            ElseIf cboTipoDoc.Text = "DNI" Then
                objCliente.tipoDoc = "1"
            ElseIf cboTipoDoc.Text = "PASSAPORTE" Then
                objCliente.tipoDoc = "7"
            ElseIf cboTipoDoc.Text = "CARNET DE EXTRANJERIA" Then
                objCliente.tipoDoc = "4"
            End If
            objCliente.nrodoc = txtDocProveedor.Text.Trim

            If rbNatural.Checked = True Then
                objCliente.appat = txtApePat.Text.Trim
                objCliente.apmat = txtApeMaterno.Text.Trim
                objCliente.nombre1 = txtNomProv.Text.Trim
                objCliente.nombreCompleto = objCliente.appat & " " & txtApeMaterno.Text.Trim & ", " & objCliente.nombre1
                objCliente.tipoPersona = "N"
            ElseIf rbJuridico.Checked = True Then
                objCliente.nombre = txtNomProv.Text.Trim
                objCliente.nombreCompleto = txtNomProv.Text.Trim
                objCliente.tipoPersona = "J"
            End If
            objCliente.nombreCompleto = txtNomProv.Text.Trim
            Select Case strTipo
                Case TIPO_ENTIDAD.PROVEEDOR
                    objCliente.cuentaAsiento = "4212"
                Case TIPO_ENTIDAD.CLIENTE
                    objCliente.cuentaAsiento = "1213"
            End Select

            objCliente.estado = "A"
            If txtDir.Text.Trim.Length > 0 Then
                objCliente.direccion = txtDir.Text.Trim
            Else
                objCliente.direccion = Nothing
            End If

            If txtFoNo.Text.Trim.Length > 0 Then
                objCliente.telefono = txtFoNo.Text.Trim
            Else
                objCliente.telefono = Nothing
            End If

            objCliente.nombreContacto = txtContacto.Text
            objCliente.email = txtCorreo.Text
            objCliente.usuarioModificacion = usuario.Alias
            objCliente.fechaModificacion = DateTime.Now
            objCliente.EnvioEntidades = chEntidades.Checked
            objCliente.EnvioPlanilla = chPlanilla.Checked
            entidadSA.UpdateEntidad(objCliente)
            Dispose()
        Catch ex As Exception
            'Manejo de errores
            MsgBox("No se pudo grabar el cliente." & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
#End Region



    Private Sub frmCrearENtidades_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Me.Tag = "No"
        Dispose()
    End Sub

    Private Sub frmCrearENtidades_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtDocProveedor.Select()
    End Sub

    Private Sub cboTipoDoc_Click(sender As Object, e As EventArgs) Handles cboTipoDoc.Click

    End Sub

    Private Sub cboTipoDoc_KeyDown(sender As Object, e As KeyEventArgs) Handles cboTipoDoc.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtDocProveedor.Focus()
        End If
    End Sub

    Public Sub limpiar()
        txtNomProv.Text = ""
        txtContacto.Text = ""
        txtDir.Text = ""


    End Sub


    Private Sub txtDocProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDocProveedor.KeyDown
        limpiar()

        'If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
        '    PictureLoad.Visible = True
        '    e.SuppressKeyPress = True
        '    txtNomProv.Focus()



        '    If txtDocProveedor.Text.Trim.Length = 11 Then

        '        cboTipoDoc.Text = "RUC"
        '        Dim objeto As Boolean = ValidationRUC(txtDocProveedor.Text)
        '        If objeto = False Then
        '            PictureLoad.Visible = False
        '            MessageBox.Show("Debe Ingresar un número correcto de ruc", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '            PanelLoading.Visible = False
        '            Cursor = Cursors.Default
        '            Exit Sub
        '        End If


        '        LinkLabel1.Enabled = False
        '        PanelLoading.Visible = True
        '        ProgressBar2.Visible = True
        '        ProgressBar2.Style = ProgressBarStyle.Marquee

        '        GetConsultaSunatAsync(txtDocProveedor.Text.Trim)

        '    ElseIf txtDocProveedor.Text.Trim.Length = 8 Then
        '        cboTipoDoc.Text = "DNI"

        '        LinkLabel1.Enabled = False
        '        PanelLoading.Visible = True
        '        ProgressBar2.Visible = True
        '        ProgressBar2.Style = ProgressBarStyle.Marquee

        '        'GetConsultarDNIReniec(txtDocProveedor.Text.Trim)
        '        txtNomProv.Text = GetConsultarDNIReniec(txtDocProveedor.Text.Trim)
        '    Else
        '        MessageBox.Show("Debe ingresar un número de documento", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '        PictureLoad.Visible = False
        '        PanelLoading.Visible = False
        '        txtDocProveedor.Select()
        '    End If



        'End If

    End Sub

    Private Sub txtDocProveedor_TextChanged(sender As Object, e As EventArgs) Handles txtDocProveedor.TextChanged
        'Select Case cboTipoDoc.Text
        'Case "RUC"
        'txtDocProveedor.MaxLength = 11
        'Case "DNI"
        'txtDocProveedor.MaxLength = 8
        ' Case Else

        'End Select
        'If txtDocProveedor.Text.Trim.Length > 0 Then
        '    If txtDocProveedor.Text.Trim.ToString.StartsWith("20") Then
        '        rbJuridico.Checked = True
        '    End If
        'End If
    End Sub

    Private Sub txtNomProv_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNomProv.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            If txtApeMaterno.Visible = True Then
                e.SuppressKeyPress = True
                txtApePat.Focus()
            Else
                e.SuppressKeyPress = True
                txtCorreo.Focus()
            End If
        End If
    End Sub

    Private Sub txtNomProv_TextChanged(sender As Object, e As EventArgs) Handles txtNomProv.TextChanged

    End Sub

    Private Sub txtApePat_KeyDown(sender As Object, e As KeyEventArgs) Handles txtApePat.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtApeMaterno.Focus()
        End If
    End Sub

    Private Sub txtApePat_TextChanged(sender As Object, e As EventArgs) Handles txtApePat.TextChanged

    End Sub

    Private Sub txtDir_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDir.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            btGrabar.Select()
        End If
    End Sub

    Private Sub txtDir_TextChanged(sender As Object, e As EventArgs) Handles txtDir.TextChanged

    End Sub

    Private Sub rbNatural_CheckChanged(sender As Object, e As EventArgs) Handles rbNatural.CheckChanged
        If rbNatural.Checked = True Then
            txtNomProv.Visible = True
            txtNomProv.Clear()
            txtApePat.Visible = True
            txtApePat.Clear()

            txtApeMaterno.Visible = True
            txtApeMaterno.Clear()

            Label31.Visible = True
            Label6.Visible = True
            Label30.Text = "Nombres:"
            cboTipoDoc.Text = "DNI"
            LinkLabel1.Text = "Consultar en RENIEC"
            LinkLabel1.Visible = True
        End If
    End Sub

    Private Sub rbJuridico_CheckChanged(sender As Object, e As EventArgs) Handles rbJuridico.CheckChanged
        If rbJuridico.Checked = True Then
            txtNomProv.Visible = True
            txtNomProv.Clear()
            txtApePat.Visible = False
            txtApePat.Clear()
            txtApeMaterno.Visible = False
            txtApeMaterno.Clear()
            Label31.Visible = False
            Label6.Visible = False
            Label30.Text = "Nombre o Razón Social:"
            cboTipoDoc.Text = "RUC"
            LinkLabel1.Text = "Consultar en SUNAT"
        End If
    End Sub

    Private Sub txtCorreo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCorreo.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtContacto.Focus()
        End If
    End Sub

    Private Sub txtCorreo_TextChanged(sender As Object, e As EventArgs) Handles txtCorreo.TextChanged

    End Sub

    Private Sub txtContacto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtContacto.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtFoNo.Focus()
        End If
    End Sub

    Private Sub txtContacto_TextChanged(sender As Object, e As EventArgs) Handles txtContacto.TextChanged

    End Sub

    Private Sub txtFoNo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFoNo.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtDir.Focus()
        End If
    End Sub

    Private Sub btGrabar_Click_1(sender As Object, e As EventArgs) Handles btGrabar.Click

        If txtDocProveedor.Text.Trim.Length = 11 Then
            cboTipoDoc.Text = "RUC"
        ElseIf txtDocProveedor.Text.Trim.Length = 8 Then
            cboTipoDoc.Text = "DNI"
        End If

        If cboTipoDoc.Text = "RUC" Then
            Dim objeto As Boolean = ValidationRUC(txtDocProveedor.Text)
            If objeto = False Then
                MessageBox.Show("Debe Ingresar un Numero correcto de ruc", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Cursor = Cursors.Default
                Exit Sub
            End If
        End If

        If Not txtDocProveedor.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el nro de documento"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
            txtDocProveedor.Select()
            Exit Sub
        End If

        If Not txtNomProv.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el nombre"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
            txtNomProv.Select()
            Exit Sub
        End If

        If rbNatural.Checked = True Then
            'If Not txtApePat.Text.Trim.Length > 0 Then
            '    lblEstado.Text = "Ingrese el apellido paterno"
            '    PanelError.Visible = True
            '    Timer1.Enabled = True
            '    TiempoEjecutar(10)
            '    txtApePat.Select()
            '    Exit Sub
            'End If
        End If

        If rbNatural.Checked = True Then
            'If Not txtApeMaterno.Text.Trim.Length > 0 Then
            '    lblEstado.Text = "Ingrese el apellido materno"
            '    PanelError.Visible = True
            '    Timer1.Enabled = True
            '    TiempoEjecutar(10)
            '    txtApeMaterno.Select()
            '    Exit Sub
            'End If
        End If

        If cboTipoDoc.Text = "RUC" Then




            If txtDocProveedor.Text.Trim.Length <> 11 Then
                MessageBox.Show("El RUC debe ser de 11 digitos", "Validar RUC", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Cursor = Cursors.Default
                Exit Sub
            End If
        ElseIf cboTipoDoc.Text = "DNI" Then


            If txtNomProv.Text = "   DNI NO ENCONTRADO EN PADRÓN ELECTORAL " Then
                MessageBox.Show("Debe ingresar un DNI válido o cambie el nombre {8} digitos", "Validar DNI", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Cursor = Cursors.Default
                Exit Sub

            End If

            If Not txtDocProveedor.Text.Trim.Length = 8 Then
                MessageBox.Show("Debe ingresar un DNI válido {8} digitos", "Validar DNI", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Cursor = Cursors.Default
                Exit Sub
            End If
        ElseIf cboTipoDoc.Text = "PASSAPORTE" Then
            If Not txtDocProveedor.Text.Trim.Length > 0 Then
                MessageBox.Show("Debe ingresar el número del documento", "Validar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Cursor = Cursors.Default
                Exit Sub
            End If
        ElseIf cboTipoDoc.Text = "CARNET DE EXTRANJERIA" Then
            If Not txtDocProveedor.Text.Trim.Length > 0 Then
                MessageBox.Show("Debe ingresar el número del documento", "Validar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Cursor = Cursors.Default
                Exit Sub
            End If
        End If

        If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
            InsertEntidad()
        Else
            EditarEntidad()
        End If
    End Sub

    Private Sub Panel1_Click(sender As Object, e As EventArgs) Handles Panel1.Click

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

#Region "metodos Reniec"
    Private Sub AplicacionFiltros()
        Dim bmp As New Bitmap(pictureCapchaR.Image)
        FiltroInvertir(bmp)
        ColorFiltros()
        Dim bmp1 As New Bitmap(pictureCapchaE.Image)
        FiltroInvertir(bmp1)
        Dim bmp2 As New Bitmap(pictureCapchaE.Image)
        FiltroSharpen(bmp2)
    End Sub
    Private Sub FiltroInvertir(bmp As Bitmap)
        'Dim Filtro As IFilter = New Invert()
        '  Dim XImage As Bitmap = Filtro.Apply(bmp)
        '       pictureCapchaE.Image = XImage
    End Sub
    Private Sub ColorFiltros()
        'red.Min = Math.Min(red.Max, Byte.Parse("229"))
        'red.Max = Math.Max(red.Min, Byte.Parse("255"))
        'green.Min = Math.Min(green.Max, Byte.Parse("0"))
        'green.Max = Math.Max(green.Min, Byte.Parse("255"))
        'blue.Min = Math.Min(blue.Max, Byte.Parse("0"))
        'blue.Max = Math.Max(blue.Min, Byte.Parse("130"))
        ActualizarFiltro()
    End Sub
    Private Sub ActualizarFiltro()
        'Dim FiltroColor As New ColorFiltering()
        'FiltroColor.Red = red
        'FiltroColor.Green = green
        'FiltroColor.Blue = blue
        'Dim Filtro As IFilter = FiltroColor
        'Dim bmp As New Bitmap(pictureCapchaE.Image)
        'Dim XImage As Bitmap = Filtro.Apply(bmp)
        '  pictureCapchaE.Image = XImage
    End Sub
    Private Sub FiltroSharpen(bmp As Bitmap)
        'Dim Filtro As IFilter = New Sharpen()
        'Dim XImage As Bitmap = Filtro.Apply(bmp)
        'pictureCapchaE.Image = XImage
    End Sub
    Private Sub CargarImagenReniec()
        Try
            If MyInfoReniec Is Nothing Then
                MyInfoReniec = New Reniec()
            End If
            Me.pictureCapchaR.Image = MyInfoReniec.GetCapcha
            AplicacionFiltros()
            LeerCaptchaReniec()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub LeerCaptchaReniec() '"./tessdata"
        Dim pathToLangFolder = "C:\Users\Jiuni\Documents\Visual studio descargars\SoftSego\SoftSego\Tesseract.2.3.0.0\content\x86"
        Using engine = New TesseractEngine("./tessdata", "eng", EngineMode.Default) ' New TesseractEngine(Path.Combine(Environment.CurrentDirectory, "tessdata"), "eng", EngineMode.Default)
            Using image = New System.Drawing.Bitmap(pictureCapchaE.Image)
                Using pix = PixConverter.ToPix(image)
                    Using page = engine.Process(pix)
                        Dim Porcentaje = [String].Format("{0:P}", page.GetMeanConfidence())
                        Dim CaptchaTexto As String = page.GetText()
                        Dim eliminarChars As Char() = {ControlChars.Lf, " "c}
                        CaptchaTexto = CaptchaTexto.TrimEnd(eliminarChars)
                        CaptchaTexto = CaptchaTexto.Replace(" ", String.Empty)
                        CaptchaTexto = Regex.Replace(CaptchaTexto, "[^a-zA-Z0-9]+", String.Empty)
                        If CaptchaTexto <> String.Empty And CaptchaTexto.Length = 4 Then
                            txtreniec.Text = CaptchaTexto.ToUpper()
                        Else
                            CargarImagenReniec()
                        End If
                    End Using
                End Using

            End Using
        End Using

    End Sub
    Private Sub limpiarReniec()
        txtDocProveedor.Text = String.Empty
        txtNomProv.Text = String.Empty
        txtApePat.Text = String.Empty
        txtreniec.Text = String.Empty
        '   txtdni_reniec.Text = String.Empty
    End Sub
#End Region


    Private Sub Panel2_Click(sender As Object, e As EventArgs) Handles Panel2.Click
        Cursor = Cursors.WaitCursor
        'If IsConnectionAvailable() = True Then
        '    Try
        '        If Me.txtDocProveedor.Text.Length <> 8 Then
        '            MessageBox.Show("Ingreso Dni Valido")
        '            txtDocProveedor.SelectAll()
        '            txtDocProveedor.Focus()
        '            Return
        '        End If
        '        MyInfoReniec.GetInfo(Me.txtDocProveedor.Text, Me.txtreniec.Text)
        '        Select Case MyInfoReniec.GetResul
        '            Case Reniec.Resul.Ok
        '                limpiarReniec()
        '                txtDocProveedor.Text = MyInfoReniec.Dni
        '                txtNomProv.Text = MyInfoReniec.Nombres
        '                txtApePat.Text = MyInfoReniec.ApePaterno + " " + MyInfoReniec.ApeMaterno
        '                Exit Select
        '            Case Reniec.Resul.NoResul
        '                limpiarReniec()
        '                MessageBox.Show("No Existe DNI")
        '                Exit Select
        '            Case Reniec.Resul.ErrorCapcha
        '                limpiarReniec()
        '                MessageBox.Show("Ingrese imagen correctamente")
        '                Exit Select
        '            Case Else
        '                MessageBox.Show("Error Desconocido")
        '                Exit Select
        '        End Select
        '        CargarImagenReniec()
        '    Catch ex As Exception
        '        MessageBox.Show(ex.Message)
        '    End Try
        'End If
        Cursor = Cursors.Default
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub cboTipoDoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoDoc.SelectedIndexChanged
        ' txtDocProveedor.Clear()
        txtDocProveedor.Select()
        txtDocProveedor.Focus()
        If cboTipoDoc.Text = "RUC" Then
            LinkLabel1.Visible = True
        Else
            LinkLabel1.Visible = False
        End If
    End Sub

    Private Sub txtApeMaterno_TextChanged(sender As Object, e As EventArgs) Handles txtApeMaterno.TextChanged

    End Sub

    Private Sub txtApeMaterno_KeyDown(sender As Object, e As KeyEventArgs) Handles txtApeMaterno.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtCorreo.Focus()
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Cursor = Cursors.WaitCursor






        If txtDocProveedor.Text.Trim.Length > 0 Then

            If cboTipoDoc.Text = "RUC" Then
                Dim objeto As Boolean = ValidationRUC(txtDocProveedor.Text)
                If objeto = False Then
                    MessageBox.Show("Debe Ingresar un Numero correcto de ruc", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Cursor = Cursors.Default
                    Exit Sub
                End If
            End If

            LinkLabel1.Enabled = False
            'PanelLoading.Visible = True
            'ProgressBar2.Visible = True
            'ProgressBar2.Style = ProgressBarStyle.Marquee
            Select Case LinkLabel1.Text
                Case "Consultar en SUNAT"


                    GetConsultaSunatAsync(txtDocProveedor.Text.Trim)



                Case "Consultar en RENIEC"
                    GetConsultarDNIReniec(txtDocProveedor.Text.Trim)
            End Select
        Else
            MessageBox.Show("Debe ingresar un número de documento", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtDocProveedor.Select()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Async Sub GetConsultaSunatAsync(ruc As String)
        Dim nroDoc = txtDocProveedor.Text.Substring(0, 1).ToString
        If nroDoc = "1" Then
            Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
            If company IsNot Nothing Then
                If company.ContribuyenteTipo = "PERSONA NATURAL SIN NEGOCIO" Then
                    rbNatural.Checked = True
                    cboTipoDoc.Text = "RUC"
                End If
                txtNomProv.Text = company.RazonSocial
                txtContacto.Text = company.RazonSocial
                lblStatus.Text = company.ContribuyenteEstado
                txtDocProveedor.Text = company.Ruc

                'PanelLoading.Visible = False
                'ProgressBar2.Visible = False
                LinkLabel1.Enabled = True
                PictureLoad.Visible = False
            Else
                'PanelLoading.Visible = False
                PictureLoad.Visible = False
                'ProgressBar2.Visible = False
                LinkLabel1.Enabled = True
            End If
        ElseIf nroDoc = "2" Then
            Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
            If company IsNot Nothing Then
                'If company.ContribuyenteTipo = "SOCIEDAD ANONIMA CERRADA" Then
                rbJuridico.Checked = True
                cboTipoDoc.Text = "RUC"
                '  End If
                txtNomProv.Text = company.RazonSocial
                txtContacto.Text = company.RazonSocial
                lblStatus.Text = company.ContribuyenteEstado
                txtDir.Text = company.DomicilioFiscal
                txtDocProveedor.Text = company.Ruc
                'If company.RepresentanteLegal IsNot Nothing Then
                '    If company.RepresentanteLegal.Dni41094462 IsNot Nothing Then
                '        With company.RepresentanteLegal.Dni41094462
                '            txtContacto.Text = String.Format("{0}/{1}/{2}", .Cargo, .Nombre, .Desde)
                '        End With
                '    End If
                'End If
                'PanelLoading.Visible = False
                PictureLoad.Visible = False
                'ProgressBar2.Visible = False
                LinkLabel1.Enabled = True
            Else
                'PanelLoading.Visible = False
                'ProgressBar2.Visible = False
                LinkLabel1.Enabled = True
                PictureLoad.Visible = False
            End If
        End If

    End Sub

    Private Function GetConsultarDNIReniec(Dni As String) As String
        Dim strJSON As String = String.Empty
        Dim rClient As RESTClientAPI = New RESTClientAPI()
        Dim appat As String = String.Empty
        Dim apmat As String = String.Empty
        Dim nom As String = String.Empty
        Dim fullName As String = String.Empty
        Select Case ApiReniecOption
            Case ApisReniec.ApiReniecCloud
                rClient.endPoint = "https://api.reniec.cloud/dni/" & Dni
            Case ApisReniec.ApiGrupoTeComCom
                rClient.endPoint = "http://apis.grupotecom.com/api/ConsultaDni?dni=" & Dni
            Case ApisReniec.ApiConsultasDsdInformaticos
                rClient.endPoint = "http://consultas.dsdinformaticos.com/reniec.php?dni=" & Dni
        End Select

        strJSON = rClient.makeRequest()
        Dim res = JsonConvert.DeserializeObject(strJSON)

        Select Case ApiReniecOption
            Case ApisReniec.ApiReniecCloud
                appat = res("apellido_paterno").ToString() 'res.apellido_paterno
                apmat = res("apellido_materno").ToString() ' res.apellido_materno
                nom = res("nombres").ToString() 'res.nombres
                fullName = Trim($"{appat} {apmat} {nom}")
            Case ApisReniec.ApiGrupoTeComCom

                fullName = res("result")("NombreCompleto")
                fullName = Trim(fullName)
            Case ApisReniec.ApiConsultasDsdInformaticos
                appat = res("result")("ApellidoPaterno").ToString() 'res.apellido_paterno
                apmat = res("result")("ApellidoMaterno").ToString() ' res.apellido_materno
                nom = res("result")("Nombres").ToString() 'res.nombres
                fullName = Trim($"{appat} {apmat} {nom}")
        End Select

        'Dim s = res("dni").ToString()

        '  nombres = MIHTML.Replace("|", Space(1))
        Return fullName
    End Function
    'Private Sub GetConsultarDNIReniec(Dni As String)
    '    Dim CLIENTE As New WebClient
    '    Dim PAGINA As Stream = CLIENTE.OpenRead("http://aplicaciones007.jne.gob.pe/srop_publico/Consulta/Afiliado/GetNombresCiudadano?DNI=" & Dni)
    '    Dim LECTOR As New StreamReader(PAGINA)
    '    Dim MIHTML As String = LECTOR.ReadToEnd

    '    txtNomProv.Text = MIHTML.Replace("|", Space(1))
    '    PanelLoading.Visible = False
    '    ProgressBar2.Visible = False
    '    LinkLabel1.Enabled = True
    '    PictureLoad.Visible = False
    'End Sub

    Private Sub RadioButtonAdv1_CheckChanged(sender As Object, e As EventArgs) Handles RBnatConnegocio.CheckChanged
        If RBnatConnegocio.Checked = True Then
            txtNomProv.Visible = True
            txtNomProv.Clear()
            txtApePat.Visible = False
            txtApePat.Clear()
            txtApeMaterno.Visible = False
            txtApeMaterno.Clear()
            Label31.Visible = False
            Label6.Visible = False
            Label30.Text = "Nombre o Razón Social:"
            cboTipoDoc.Text = "RUC"
            LinkLabel1.Text = "Consultar en SUNAT"
        End If
    End Sub

    Private Sub btnReload_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtDireccion_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtDireccion_KeyDown(sender As Object, e As KeyEventArgs)

    End Sub

    Private Sub btnNavegar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs)

    End Sub

    Private Sub WebBrowser1_Navigating(sender As Object, e As WebBrowserNavigatingEventArgs)

    End Sub

    Private Sub rbAutomatico_CheckedChanged(sender As Object, e As EventArgs) Handles rbAutomatico.CheckedChanged
        If (rbAutomatico.Checked = True) Then
            limpiar()
            Panel3.Enabled = True
            rbManual.Checked = False
            txtDocProveedor.ReadOnly = True
            txtNomProv.ReadOnly = True
            'txtDir.ReadOnly = True
        End If
    End Sub

    Private Sub rbManual_CheckedChanged(sender As Object, e As EventArgs) Handles rbManual.CheckedChanged

        If (rbManual.Checked = True) Then
            limpiar()
            Panel3.Enabled = False
            rbAutomatico.Checked = False
            txtDocProveedor.ReadOnly = False
            txtNomProv.ReadOnly = False
            txtDir.ReadOnly = False

        End If
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        WebBrowser1.Navigate("https://e-consultaruc.sunat.gob.pe/cl-ti-itmrconsruc/FrameCriterioBusquedaMovil.jsp")
    End Sub

    Private Sub btnReload_Click_1(sender As Object, e As EventArgs)
        WebBrowser1.Refresh()
    End Sub

    Private Sub btnAnterior_Click_1(sender As Object, e As EventArgs) Handles btnAnterior.Click
        WebBrowser1.GoBack()
    End Sub

    Private Sub WebBrowser1_Navigating_1(sender As Object, e As WebBrowserNavigatingEventArgs) Handles WebBrowser1.Navigating
        StatusLabel.Text = "CARGANDO..."
        StatusLabel.Visible = True
        PictureLoad.Visible = True
    End Sub

    Private Sub WebBrowser1_DocumentCompleted_1(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        PictureLoad.Visible = False
        StatusLabel.Visible = False
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        Try
            'TextBox1.Text = WebBrowser1.Document.GetElementById("txtRuc").GetAttribute("value")
            Dim ELEMTNOS As HtmlElementCollection = WebBrowser1.Document.GetElementsByTagName("h4")
            Dim conteo As Integer = 0
            For Each item As HtmlElement In ELEMTNOS
                If (conteo = 1) Then

                    txtDocProveedor.Text = item.InnerText.Substring(0, 11)
                    txtNomProv.Text = item.InnerText.Substring(14)
                    Exit For
                End If
                conteo = conteo + 1
            Next
            If (txtDocProveedor.Text.Substring(0, 2) = "20") Then
                Dim ELEMTNOS1 As HtmlElementCollection = WebBrowser1.Document.GetElementsByTagName("p")
                Dim conteo1 As Integer = 0
                For Each item As HtmlElement In ELEMTNOS1
                    If (conteo1 = 5) Then


                        txtDir.Text = item.InnerText
                        Exit For
                    End If
                    conteo1 = conteo1 + 1
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class