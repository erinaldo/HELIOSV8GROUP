Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Linq
Imports System.Runtime.InteropServices
Imports System.Text

Imports Tesseract
Imports AForge
Imports AForge.Imaging
Imports AForge.Imaging.Filters
Imports AForge.Imaging.Textures
Imports System.Text.RegularExpressions
Imports System.IO
Imports DPFP
Imports DPFP.Capture
Public Class frmNuevoSocioGym
    Implements DPFP.Capture.EventHandler

    Public Property strTipo() As String
    Public Property intIdEntidad() As Integer
    Public Property ManipulacionEstado() As String

#Region "Attributes Huella"
    'Private captura As DPFP.Capture.Capture
    'Private Enroller As DPFP.Processing.Enrollment
    Private Delegate Sub _delegadoMuestra(ByVal text As String)
    Private Delegate Sub _modificarControles()

    Private template As DPFP.Template
#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Try
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
            rbNatural.Checked = True
            rbJuridico.Enabled = True
            ManipulacionEstado = ENTITY_ACTIONS.INSERT

            If IsConnectionAvailable() = True Then
                'CargarImagenSunat()
                'LeerCaptchaSunat()
                'CargarImagenReniec()
                'AplicacionFiltros()
                'LeerCaptchaReniec()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        captura.EventHandler = Me
    End Sub

    Public Sub New(idEntidad As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        UbicarEntidad(idEntidad)
        ManipulacionEstado = ENTITY_ACTIONS.UPDATE
    End Sub
#End Region

#Region "Methods Generic"

    Public Function IsConnectionAvailable() As Boolean
        ' Returns True if connection is available 
        ' Replace www.yoursite.com with a site that 
        ' is guaranteed to be online - perhaps your 
        ' corporate site, or microsoft.com 
        Dim objUrl As New System.Uri("http://www.softpack.com.pe")
        ' Setup WebRequest 
        Dim objWebReq As System.Net.WebRequest
        objWebReq = System.Net.WebRequest.Create(objUrl)
        Dim objResp As System.Net.WebResponse
        Try
            ' Attempt to get response and return True 
            objResp = objWebReq.GetResponse
            objResp.Close()
            objWebReq = Nothing
            Return True
        Catch ex As Exception
            ' Error, exit and return False 
            objWebReq = Nothing
            Return False
        End Try
    End Function

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
            txtContacto.Text = entidad.nombreContacto

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
        txtDocProveedor.Text = entidad.nrodoc
        txtDir.Text = entidad.direccion
        txtFoNo.Text = entidad.telefono
    End Sub

    Public Sub InsertEntidad()
        Dim obEntidad As New entidad
        Dim entidadSA As New entidadSA
        Try
            'Se asigna cada uno de los datos registrados
            obEntidad.idEmpresa = Gempresas.IdEmpresaRuc
            obEntidad.tipoEntidad = strTipo

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
                obEntidad.appat = txtApePat.Text.Trim
                obEntidad.apmat = txtApeMaterno.Text.Trim
                obEntidad.nombre1 = txtNomProv.Text.Trim
                obEntidad.nombreCompleto = obEntidad.appat & " " & txtApeMaterno.Text.Trim & ", " & obEntidad.nombre1
                obEntidad.tipoPersona = "N"
            ElseIf rbJuridico.Checked = True Then
                obEntidad.nombre = txtNomProv.Text.Trim
                obEntidad.nombreCompleto = txtNomProv.Text.Trim
                obEntidad.tipoPersona = "J"
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
            If chHuella.Checked = True Then
                Using fm As New MemoryStream(template.Bytes)
                    obEntidad.huella = fm.ToArray()
                End Using
            End If

            'obEntidad.EnvioEntidades = chEntidades.Checked
            'obEntidad.EnvioPlanilla = chPlanilla.Checked
            Dim codx As Integer = entidadSA.GrabarEntidad(obEntidad)

            Dim entidad As New entidad
            entidad.idEntidad = codx
            entidad.nrodoc = txtDocProveedor.Text.Trim
            entidad.nombreCompleto = obEntidad.nombreCompleto
            Me.Tag = entidad

            Dispose()
        Catch ex As Exception
            'Manejo de errores
            MsgBox("No se pudo grabar el cliente." & vbCrLf & ex.Message)
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
            'objCliente.EnvioEntidades = chEntidades.Checked
            'objCliente.EnvioPlanilla = chPlanilla.Checked
            entidadSA.UpdateEntidad(objCliente)
            Dispose()
        Catch ex As Exception
            'Manejo de errores
            MsgBox("No se pudo grabar el cliente." & vbCrLf & ex.Message)
        End Try
    End Sub
#End Region

#End Region

#Region "Methods Huella Digital"
    Private Sub MostrarVeces(ByVal texto As String)
        If VecesDedo.InvokeRequired Then
            Dim deleg As New _delegadoMuestra(AddressOf MostrarVeces)
            Invoke(deleg, New Object() {texto})
        Else
            VecesDedo.Text = texto
        End If
    End Sub

    'Protected Overridable Sub Init()
    '    Try
    '        captura = New DPFP.Capture.Capture

    '        If captura IsNot Nothing Then
    '            captura.EventHandler = Me
    '            Enroller = New Processing.Enrollment
    '            Dim text As New System.Text.StringBuilder
    '            text.AppendFormat("Necesitas pasar el dedo {0} veces", Enroller.FeaturesNeeded)
    '            VecesDedo.Text = text.ToString()
    '        Else
    '            MessageBox.Show("no se pudo instanciar la captura")
    '        End If

    '    Catch ex As Exception
    '        MessageBox.Show("no se pudo inicializar la captura")
    '    End Try
    'End Sub

    Protected Sub PararCaptura()
        If captura IsNot Nothing Then
            Try
                captura.StopCapture()
            Catch ex As Exception
                MessageBox.Show("no se pudo detener la captura")
            End Try
        End If
    End Sub

    Protected Sub IniciarCaptura()
        Try
            If Not captura Is Nothing Then
                captura.StartCapture()
            End If
        Catch ex As Exception
            MessageBox.Show("no se pudo iniciar la captura")
        End Try

    End Sub

    Protected Function ConvertirMapaBits(ByVal sample As Sample) As Bitmap
        Dim convertidor As New DPFP.Capture.SampleConversion
        Dim mapabits As Bitmap = Nothing
        convertidor.ConvertToPicture(sample, mapabits)
        Return mapabits
    End Function

    Private Sub PonerImagen(ByVal bmp)
        ImagenHuella.Image = bmp
    End Sub

    Protected Function extraerCaracteristicas(ByVal Sample As Sample, ByVal Purpose As DPFP.Processing.DataPurpose) As FeatureSet
        Dim extractor As New DPFP.Processing.FeatureExtraction
        Dim alimentacion As CaptureFeedback = CaptureFeedback.None
        Dim caracteristicas As New FeatureSet
        extractor.CreateFeatureSet(Sample, Purpose, alimentacion, caracteristicas)
        If alimentacion = DPFP.Capture.CaptureFeedback.Good Then
            Return caracteristicas
        Else
            Return Nothing
        End If
    End Function

    Private Sub modificarControles()
        If btGrabar.InvokeRequired Then
            Dim deleg As New _modificarControles(AddressOf modificarControles)
            Invoke(deleg, New Object() {})
        Else
            btGrabar.Enabled = True
        End If
    End Sub

    Protected Sub procesar(ByVal Sample As Sample)
        Dim caracteristicas As DPFP.FeatureSet = extraerCaracteristicas(Sample, DPFP.Processing.DataPurpose.Enrollment)
        If caracteristicas IsNot Nothing Then
            Try
                Enroller.AddFeatures(caracteristicas)
            Finally
                Dim text As New System.Text.StringBuilder
                text.AppendFormat("Necesitas pasar el dedo {0} veces", Enroller.FeaturesNeeded)
                MostrarVeces(text.ToString)
                Select Case Enroller.TemplateStatus
                    Case Processing.Enrollment.Status.Ready
                        template = Enroller.Template
                        PararCaptura()
                        modificarControles()

                    Case Processing.Enrollment.Status.Failed
                        Enroller.Clear()
                        PararCaptura()
                        IniciarCaptura()
                        '    btGuardar.Enabled = False
                End Select
            End Try
        End If
    End Sub
#End Region

#Region "Events"
    Private Sub frmNuevoSocioGym_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtDocProveedor.Select()
        PararCaptura()
    End Sub

    Private Sub cboTipoDoc_KeyDown(sender As Object, e As KeyEventArgs) Handles cboTipoDoc.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtDocProveedor.Focus()
        End If
    End Sub

    Private Sub txtDocProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDocProveedor.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtNomProv.Focus()
        End If
    End Sub

    Private Sub txtDocProveedor_TextChanged(sender As Object, e As EventArgs) Handles txtDocProveedor.TextChanged
        Select Case cboTipoDoc.Text
            Case "RUC"
                txtDocProveedor.MaxLength = 11
            Case "DNI"
                txtDocProveedor.MaxLength = 8
            Case Else

        End Select
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
            If Not txtApePat.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el apellido paterno"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(10)
                txtApePat.Select()
                Exit Sub
            End If
        End If

        If rbNatural.Checked = True Then
            If Not txtApeMaterno.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el apellido materno"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(10)
                txtApeMaterno.Select()
                Exit Sub
            End If
        End If

        If cboTipoDoc.Text = "RUC" Then
            If txtDocProveedor.Text.Trim.Length <> 11 Then
                MessageBox.Show("El RUC debe ser de 11 digitos", "Validar RUC", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Cursor = Cursors.Default
                Exit Sub
            End If
        ElseIf cboTipoDoc.Text = "DNI" Then
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
        'Dim XImage As Bitmap = Filtro.Apply(bmp)
        'pictureCapchaE.Image = XImage
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
        'pictureCapchaE.Image = XImage
    End Sub
    Private Sub FiltroSharpen(bmp As Bitmap)
        'Dim Filtro As IFilter = New Sharpen()
        'Dim XImage As Bitmap = Filtro.Apply(bmp)
        '    pictureCapchaE.Image = XImage
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
        If IsConnectionAvailable() = True Then
            Try
                If Me.txtDocProveedor.Text.Length <> 8 Then
                    MessageBox.Show("Ingreso Dni Valido")
                    txtDocProveedor.SelectAll()
                    txtDocProveedor.Focus()
                    Return
                End If
                MyInfoReniec.GetInfo(Me.txtDocProveedor.Text, Me.txtreniec.Text)
                Select Case MyInfoReniec.GetResul
                    Case Reniec.Resul.Ok
                        limpiarReniec()
                        txtDocProveedor.Text = MyInfoReniec.Dni
                        txtNomProv.Text = MyInfoReniec.Nombres
                        txtApePat.Text = MyInfoReniec.ApePaterno + " " + MyInfoReniec.ApeMaterno
                        Exit Select
                    Case Reniec.Resul.NoResul
                        limpiarReniec()
                        MessageBox.Show("No Existe DNI")
                        Exit Select
                    Case Reniec.Resul.ErrorCapcha
                        limpiarReniec()
                        MessageBox.Show("Ingrese imagen correctamente")
                        Exit Select
                    Case Else
                        MessageBox.Show("Error Desconocido")
                        Exit Select
                End Select
                CargarImagenReniec()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub cboTipoDoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoDoc.SelectedIndexChanged
        txtDocProveedor.Clear()
        txtDocProveedor.Select()
        txtDocProveedor.Focus()
    End Sub

    Private Sub txtApeMaterno_TextChanged(sender As Object, e As EventArgs) Handles txtApeMaterno.TextChanged

    End Sub

    Private Sub txtApeMaterno_KeyDown(sender As Object, e As KeyEventArgs) Handles txtApeMaterno.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtCorreo.Focus()
        End If
    End Sub

#End Region

#Region "Events Huella Digital"
    Public Sub OnComplete(Capture As Object, ReaderSerialNumber As String, Sample As Sample) Implements DPFP.Capture.EventHandler.OnComplete
        If chHuella.Checked = True Then
            PonerImagen(ConvertirMapaBits(Sample))
            procesar(Sample)
        End If
    End Sub

    Public Sub OnFingerGone(Capture As Object, ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnFingerGone

    End Sub

    Public Sub OnFingerTouch(Capture As Object, ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnFingerTouch

    End Sub

    Public Sub OnReaderConnect(Capture As Object, ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnReaderConnect

    End Sub

    Public Sub OnReaderDisconnect(Capture As Object, ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnReaderDisconnect

    End Sub

    Public Sub OnSampleQuality(Capture As Object, ReaderSerialNumber As String, CaptureFeedback As CaptureFeedback) Implements DPFP.Capture.EventHandler.OnSampleQuality

    End Sub

    Private Sub chHuella_CheckedChanged(sender As Object, e As EventArgs) Handles chHuella.CheckedChanged
        If chHuella.Checked = True Then
            Dim text As New System.Text.StringBuilder
            text.AppendFormat("Necesitas pasar el dedo {0} veces", Enroller.FeaturesNeeded)
            VecesDedo.Text = text.ToString()
            IniciarCaptura()
            ImagenHuella.Image = ImageListAdv1.Images(0)
            ImagenHuella.Visible = True
        Else
            ImagenHuella.Visible = False
            ImagenHuella.Image = Nothing
            ImagenHuella.Image = ImageListAdv1.Images(0)
            PararCaptura()
        End If
    End Sub

    Private Sub frmNuevoSocioGym_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        PararCaptura()
    End Sub
#End Region

End Class