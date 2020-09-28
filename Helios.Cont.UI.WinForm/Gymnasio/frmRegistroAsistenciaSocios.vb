Imports Helios.Planilla.Business.Entity
Imports Helios.Planilla.WCFService.ServiceAccess
Imports Helios.Planilla.General
Imports Helios.General
Imports System.IO
Imports DPFP
Imports DPFP.Capture
Imports DPFP.Verification

Public Class frmRegistroAsistenciaSocios
    Implements DPFP.Capture.EventHandler

#Region "Atributos Huella"
    'Private captura As Capture
    'Private template As DPFP.Template
    'Private verificador As Verification
    Private Delegate Sub _delegadoMuestraSocio(ByVal nroDoc As String)
    Private Delegate Sub _delegadoLimpiarSocio()
#End Region

#Region "Atributos"
    Public Property SelHorarioPersonal() As List(Of ControlAsistencia)
    Protected Friend SelTipoPersona As String
    Protected Friend frmConsultaAsistenciaSocio As frmConsultaAsistenciaSocio
    Protected Friend ListaSociosEmpresa As List(Of Business.Entity.entidad)
    Protected Friend SociosSA As WCFService.ServiceAccess.entidadSA

#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        SociosSA = New WCFService.ServiceAccess.entidadSA
        ListaSociosEmpresa = New List(Of Business.Entity.entidad)
        ListaSociosEmpresa = SociosSA.GetEntidadesGenerales(TIPO_ENTIDAD.CLIENTE, Gempresas.IdEmpresaRuc)
        captura.EventHandler = Me
    End Sub
#End Region

#Region "Methods Huella"

    Private Sub LimipiarControles()
        If RoundButton21.InvokeRequired Then
            Dim deleg As New _delegadoLimpiarSocio(AddressOf LimipiarControles)
            Invoke(deleg, New Object() {})
        Else
            LimpiarAll()
        End If
    End Sub

    Sub LimpiarAll()
        RoundButton21.Enabled = False
        lblCodigoMembresia.Tag = String.Empty
        lblCodigoMembresia.Text = "-"
        lblVence.Text = "-"
        lblInicio.Text = "-"
        lblDiasDisponibles.Text = "0"
        ToggleButton21.ToggleState = ToggleButton2.ToggleButtonState.OFF

        thumb.Image = ImageListAdv1.Images(0) ' If(AuditPredicted = "0", Image.FromFile("../../Images/thumb_yes.png"), Image.FromFile("../../Images/thumb_no.png"))
        AuditPredicted.Text = "NO!" 'If(AuditPredicted = "0", "YES!", "NO!")
        PredictedText.Text = "Acceso restringido," & vbCrLf & "usuario no encontrado."

        txtCodigoFiltrar.Clear()
        txtTrabajador.Clear()
        txtTrabajador.Tag = String.Empty

        txtCodigoFiltrar.Select()
    End Sub

    Private Sub MostrarDatos(ByVal nroDoc As String)
        If txtTrabajador.InvokeRequired Then
            Dim deleg As New _delegadoMuestraSocio(AddressOf MostrarDatos)
            Invoke(deleg, New Object() {nroDoc})
        Else
            GetEntidadEncontrada(nroDoc, TIPO_ENTIDAD.CLIENTE)
        End If
    End Sub

    'Protected Overridable Sub Init()
    '    Try
    '        captura = New Capture(DPFP.Capture.Priority.Normal)

    '        If captura IsNot Nothing Then
    '            captura.EventHandler = Me
    '            verificador = New Verification
    '            Template = New Template
    '            '  Enroller = New Processing.Enrollment
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
#End Region

#Region "Métodos"
    Private Sub CargarHorarioPersonal()
        Dim sa As New ControlDeAsistenciaSA
        Dim lista = sa.ControlDeAsistenciaSelxIDPersonal(New ControlDeAsistencia With {.IDPersonal = txtTrabajador.Tag})
        LoadControles(lista)
    End Sub

    Private Sub CargarHorarios()
        SelHorarioPersonal = New List(Of ControlAsistencia)
        Dim sa As New ControlAsistenciaSA

        SelHorarioPersonal = sa.ControlAsistenciaSelxIDPersonal(New ControlAsistencia With {.IDPersonal = Val(txtTrabajador.Tag)})
    End Sub

    Sub AccesoPermitidoCongelamiento(iddocumento As Integer)

        Dim congelamientos = WCFService.ServiceAccess.membresia_congelamientoSA.GetCongelamientoByDocumento(iddocumento)
        For Each i In congelamientos
            If txtFecha.Value.Date.CompareTo(i.fechainicio.Value.Date) >= 0 AndAlso txtFecha.Value.Date.CompareTo(i.fechafin.Value.Date) <= 0 Then
                'MessageBox.Show("Dentro del rango  de congelamiento")
                'restringir acceso ese día debido a que se encuentra congelado
                Throw New Exception("No tiene acceso a este día," & vbCrLf & "el día se encuentra congelado")
            Else
                ' MessageBox.Show("Fuera del rango de congelamiento")
            End If
        Next
    End Sub


    Public Sub Grabar_Asistencia()
        'Dim TotalHoras As TimeSpan
        Dim servicio As New ControlDeAsistenciaSA
        Dim objAsistencia As New ControlDeAsistencia

        AccesoPermitidoCongelamiento(lblCodigoMembresia.Tag)

        objAsistencia = New ControlDeAsistencia
        objAsistencia.tipoPersona = SelTipoPersona
        objAsistencia.iddocumentoref = lblCodigoMembresia.Tag
        'ControlAsistencia = New ControlAsistencia With {.Action = BaseBE.EntityAction.INSERT}
        objAsistencia.Action = BaseBE.EntityAction.INSERT
        objAsistencia.IDPersonal = Integer.Parse(txtTrabajador.Tag)
        objAsistencia.tipoPersona = TIPO_ENTIDAD.CLIENTE
        objAsistencia.FechaAsistencia = txtFecha.Value ' Date.Now.Date
        objAsistencia.HoraIngreso = txtFecha.Value.TimeOfDay ' Date.Now.TimeOfDay

        objAsistencia.TipoAcesso = cboAcceso.SelectedValue
        objAsistencia.HorasTotales = New TimeSpan(0, 0, 0)

        'Dim codAcceso = SelHorarioPersonal.Where(Function(o) o.TipoAcesso = cboAcceso.SelectedValue).FirstOrDefault

        'If Not IsNothing(codAcceso) Then
        '    Dim tolerancia = codAcceso.Tolerancia

        '    If tolerancia < DateTime.Now.TimeOfDay Then
        '        Dim saldo = DateTime.Now.TimeOfDay.Subtract(tolerancia)
        '        objAsistencia.Tardanza = saldo
        '    Else
        '        objAsistencia.Tardanza = New TimeSpan(0, 0, 0) ' HoraCapturada
        '    End If

        'Else

        '    objAsistencia.Tardanza = New TimeSpan(0, 0, 0) ' HoraCapturada
        'End If

        'Select Case cboAcceso.SelectedValue
        '    Case "HI" 'Hora de Ingreso
        '        objAsistencia.HorasTotales = New TimeSpan(0, 0, 0)
        '    Case "HS" 'Hora de Salida  
        '        objAsistencia.HorasTotales = New TimeSpan(0, 0, 0)
        '    Case "RE" 'Refrigerio
        '        objAsistencia.HorasTotales = New TimeSpan(0, 0, 0)
        '    Case "RI" 'Reingreso
        '        objAsistencia.HorasTotales = New TimeSpan(0, 0, 0)
        'End Select

        objAsistencia.MesAsistencia = txtFecha.Value.Month
        objAsistencia.AñoAsistencia = txtFecha.Value.Year
        objAsistencia.DiaAsistencia = txtFecha.Value.Day
        objAsistencia.FechaModificacion = DateTime.Now
        objAsistencia.UsuarioModificacion = usuario.IDUsuario
        objAsistencia.status = 1
        'Dim ts As TimeSpan '= .Hora - .HoraPersonal
        'objAsistencia.HorasFaltas = ts.TotalHours


        servicio.ControlDeAsistenciaSave(objAsistencia, UserManager.TransactionData)

        thumb.Image = ImageListAdv1.Images(1)
        AuditPredicted.Text = "SI!"
        PredictedText.Text = "Asistencia registrada."
        MessageBox.Show("Asistencia registrada", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)

        'Dim listaAsistencia = servicio.ControlAsistenciaSelxIDPersonal(New ControlAsistencia With {.IDPersonal = txtCodigo.Text.Trim})
        'gridAsistencia.DataSource = listaAsistencia

        ' Close()
        'LimpiandoControles

        RoundButton21.Enabled = False
        lblCodigoMembresia.Tag = String.Empty
        lblCodigoMembresia.Text = "-"
        lblVence.Text = "-"
        lblInicio.Text = "-"
        lblDiasDisponibles.Text = "0"
        ToggleButton21.ToggleState = ToggleButton2.ToggleButtonState.OFF

        thumb.Image = Nothing ' If(AuditPredicted = "0", Image.FromFile("../../Images/thumb_yes.png"), Image.FromFile("../../Images/thumb_no.png"))
        AuditPredicted.Text = "" 'If(AuditPredicted = "0", "YES!", "NO!")
        PredictedText.Text = ""

        txtCodigoFiltrar.Clear()
        txtTrabajador.Clear()
        txtTrabajador.Tag = String.Empty
        txtCodigoFiltrar.Select()
    End Sub

    Private Sub LoadControles(be As List(Of ControlDeAsistencia))
        Dim coleccion As New List(Of String)
        Dim Listados As New TablaDetalleSA
        Dim lstTipoAcceso = Listados.TablaDetalleSelxTabla(New TablaDetalle With {.IDTabla = 1018})

        ' If be.Count = 0 Then
        cboAcceso.DataSource = lstTipoAcceso
        cboAcceso.ValueMember = "DescripcionCorta"
        cboAcceso.DisplayMember = "DescripcionLarga"
        'Else
        '    For Each i In be
        '        coleccion.Add(i.TipoAcesso)
        '    Next

        '    lstTipoAcceso = lstTipoAcceso.Where(Function(o) Not coleccion.Contains(o.DescripcionCorta)).ToList
        '    cboAcceso.DataSource = lstTipoAcceso
        '    cboAcceso.ValueMember = "DescripcionCorta"
        '    cboAcceso.DisplayMember = "DescripcionLarga"
        'End If
    End Sub

    ''' <summary>
    ''' Buscar socio por Nro. documento de identidad
    ''' </summary>
    ''' <param name="NroDocEntidad">DNI, u otro documento</param>
    ''' <param name="tipo">Tipo persona : "CL"</param>
    Private Sub GetEntidadEncontrada(NroDocEntidad As String, tipo As String)
        Dim entidadSA As New Helios.Cont.WCFService.ServiceAccess.entidadSA
        Dim entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, tipo, NroDocEntidad)
        If entidad IsNot Nothing Then
            txtTrabajador.Text = entidad.nombreCompleto
            txtTrabajador.Tag = CInt(entidad.idEntidad)

            Dim membresia = WCFService.ServiceAccess.Entidadmembresia_GymSA.GetMembresiaActivaXSocio(New Business.Entity.Entidadmembresia_Gym With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEntidad = entidad.idEntidad})
            If membresia IsNot Nothing Then
                txtCodigoFiltrar.Text = NroDocEntidad
                lblCodigoMembresia.Text = membresia.serie & "-" & membresia.numero
                lblCodigoMembresia.Tag = membresia.idDocumento
                lblVence.Text = FormatDateTime(membresia.fechaVcto, DateFormat.ShortDate)
                lblInicio.Text = FormatDateTime(membresia.fechaInicio, DateFormat.ShortDate)
                Dim TotalDias = DateDiff(DateInterval.Day, Date.Now, membresia.fechaVcto.GetValueOrDefault)
                TotalDias += 1
                lblDiasDisponibles.Text = TotalDias
                ToggleButton21.Visible = True
                ToggleButton22.Visible = True
                If membresia.DeudasXpagar > 0 Then
                    ToggleButton22.ToggleState = ToggleButton2.ToggleButtonState.ON
                Else
                    ToggleButton22.ToggleState = ToggleButton2.ToggleButtonState.OFF
                End If

                Select Case membresia.statusMembresia
                    Case Gimnasio_EstadoMembresia.Activo

                    Case Gimnasio_EstadoMembresia.Baja

                End Select

                If Date.Now.Date >= membresia.fechaInicio.Value.Date Then

                    If membresia.fechaVcto.Value.Date = Date.Now.Date Then
                        thumb.Image = ImageListAdv1.Images(1) ' If(AuditPredicted = "0", Image.FromFile("../../Images/thumb_yes.png"), Image.FromFile("../../Images/thumb_no.png"))
                        AuditPredicted.Text = "SI!" 'If(AuditPredicted = "0", "YES!", "NO!")
                        PredictedText.Text = "Último día disponible!"
                        RoundButton21.Enabled = True

                    ElseIf membresia.fechaVcto <= Date.Now Then
                        thumb.Image = ImageListAdv1.Images(0) ' If(AuditPredicted = "0", Image.FromFile("../../Images/thumb_yes.png"), Image.FromFile("../../Images/thumb_no.png"))
                        AuditPredicted.Text = "NO!" 'If(AuditPredicted = "0", "YES!", "NO!")
                        PredictedText.Text = "Acceso restringido," & vbCrLf & "Su membresía caducó."
                        Cursor = Cursors.Default
                        RoundButton21.Enabled = False
                        Exit Sub
                    Else
                        RoundButton21.Enabled = True
                        lblInfo.Text = "Verificación correcta."
                        lblInfo.ForeColor = Color.Green

                        thumb.Image = ImageListAdv1.Images(1) ' If(AuditPredicted = "0", Image.FromFile("../../Images/thumb_yes.png"), Image.FromFile("../../Images/thumb_no.png"))
                        AuditPredicted.Text = "SI!" 'If(AuditPredicted = "0", "YES!", "NO!")
                        PredictedText.Text = "Usuario encontrado." ' If(AuditPredicted = "0", "Your audit risk is low.", "Your audit risk is high.")
                    End If

                Else
                    thumb.Image = ImageListAdv1.Images(0) ' If(AuditPredicted = "0", Image.FromFile("../../Images/thumb_yes.png"), Image.FromFile("../../Images/thumb_no.png"))
                    AuditPredicted.Text = "NO!" 'If(AuditPredicted = "0", "YES!", "NO!")
                    PredictedText.Text = "Acceso restringido," & vbCrLf & "verificar fecha de inicio."

                    RoundButton21.Enabled = False
                    lblInfo.Text = "Verificación restringida," & vbCrLf & "verifique su fecha de inicio."
                    lblInfo.ForeColor = Color.Red
                End If
            Else
                '   MessageBox.Show(" Usuario o socio no encontrado", "Verificar membresía", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                RoundButton21.Enabled = False
                lblCodigoMembresia.Tag = String.Empty
                lblCodigoMembresia.Text = "-"
                lblVence.Text = "-"
                lblInicio.Text = "-"
                lblDiasDisponibles.Text = "0"
                ToggleButton21.ToggleState = ToggleButton2.ToggleButtonState.OFF

                thumb.Image = ImageListAdv1.Images(0) ' If(AuditPredicted = "0", Image.FromFile("../../Images/thumb_yes.png"), Image.FromFile("../../Images/thumb_no.png"))
                AuditPredicted.Text = "NO!" 'If(AuditPredicted = "0", "YES!", "NO!")
                PredictedText.Text = "Acceso restringido," & vbCrLf & "usuario no encontrado."

                '    txtCodigoFiltrar.Clear()
                txtTrabajador.Clear()
                txtTrabajador.Tag = String.Empty

                txtCodigoFiltrar.Select()
            End If
            'Select Case entidad.estado
            '    Case Tabla_SituacionTrabajador.activo_o_subsidiado
            '        TextBoxExt1.Text = "Activo"
            '    Case Tabla_SituacionTrabajador.activo_o_subsidiado_eps_serv_propios
            '        TextBoxExt1.Text = "Activo"
            '    Case Tabla_SituacionTrabajador.baja
            '        TextBoxExt1.Text = "Baja"
            '    Case Tabla_SituacionTrabajador.baja_eps_serv_propios
            '        TextBoxExt1.Text = "Baja"
            '    Case Tabla_SituacionTrabajador.sin_vinculo_laboral_con_conceptos_pendientes_de_liquidar_eps_serv_propios
            '        TextBoxExt1.Text = "Sin vinculo laboral"
            '    Case Tabla_SituacionTrabajador.sin_vinculo_laboral_con_conceptos_pendientes_por_liquidar
            '        TextBoxExt1.Text = "Sin vinculo laboral"
            '    Case Tabla_SituacionTrabajador.suspension_perfecta
            '        TextBoxExt1.Text = "Suspendión perfecta"
            'End Select
        Else
            RoundButton21.Enabled = False
            lblCodigoMembresia.Tag = String.Empty
            '   lblCodigoMembresia.Text = "-"
            lblVence.Text = "-"
            lblInicio.Text = "-"
            lblDiasDisponibles.Text = "0"
            ToggleButton21.ToggleState = ToggleButton2.ToggleButtonState.OFF

            thumb.Image = ImageListAdv1.Images(0) ' If(AuditPredicted = "0", Image.FromFile("../../Images/thumb_yes.png"), Image.FromFile("../../Images/thumb_no.png"))
            AuditPredicted.Text = "NO!" 'If(AuditPredicted = "0", "YES!", "NO!")
            PredictedText.Text = "Usuario no encontrado."

            txtCodigoFiltrar.Clear()
            txtTrabajador.Clear()
            txtTrabajador.Tag = String.Empty
            txtCodigoFiltrar.Select()
        End If
    End Sub

    Private Sub GetPersonaSelXDNI(Dni As Integer)
        Dim persona As New Personal
        Dim servicio As New PersonalSA

        persona = servicio.PersonalSelxDNI(New Personal With {.Numerodocumento = Dni})

        If Not IsNothing(persona) Then
            txtTrabajador.Text = persona.FullName
            txtTrabajador.Tag = CInt(persona.IDPersonal)

            'Select Case persona.Situacion
            '    Case Tabla_SituacionTrabajador.activo_o_subsidiado
            '        txtPaterno.Text = "Activo"
            '    Case Tabla_SituacionTrabajador.activo_o_subsidiado_eps_serv_propios
            '        txtPaterno.Text = "Activo"
            '    Case Tabla_SituacionTrabajador.baja
            '        txtPaterno.Text = "Baja"
            '    Case Tabla_SituacionTrabajador.baja_eps_serv_propios
            '        txtPaterno.Text = "Baja"
            '    Case Tabla_SituacionTrabajador.sin_vinculo_laboral_con_conceptos_pendientes_de_liquidar_eps_serv_propios
            '        txtPaterno.Text = "Sin vinculo laboral"
            '    Case Tabla_SituacionTrabajador.sin_vinculo_laboral_con_conceptos_pendientes_por_liquidar
            '        txtPaterno.Text = "Sin vinculo laboral"
            '    Case Tabla_SituacionTrabajador.suspension_perfecta
            '        txtPaterno.Text = "Suspendión perfecta"
            'End Select

        Else
            txtTrabajador.Clear()
            txtCodigoFiltrar.Select()
            MessageBox.Show("El dni ingresado no se encuentra en la base de registros", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
#End Region

#Region "Events"
    Private Sub frmIncio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtFecha.Value = DateTime.Now
        '   txtFecha.ReadOnly = False
        PararCaptura()
    End Sub

    Private Sub GradientPanel1_Paint(sender As Object, e As PaintEventArgs) Handles GradientPanel1.Paint

    End Sub

    Private Sub txtCodigoFiltrar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigoFiltrar.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtCodigoFiltrar.Text.Trim.Length > 0 Then
                'Select Case SelTipoPersona
                '    Case TIPO_ENTIDAD.PROVEEDOR

                '    Case TIPO_ENTIDAD.CLIENTE
                '    Label3.Text = "Nombre del cliente"
                GetEntidadEncontrada(txtCodigoFiltrar.Text.Trim, TIPO_ENTIDAD.CLIENTE)
                '    Case "PL"
                '        Label3.Text = "Nombre del trabajador"
                '        GetPersonaSelXDNI(txtCodigoFiltrar.Text.Trim)
                'End Select

                'CargarHorarioPersonal()
                'CargarHorarios()
            End If
        End If
    End Sub


    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Cursor = Cursors.WaitCursor
        If txtTrabajador.Text.Trim.Length > 0 Then
            Dim f As New frmRegistroVentasClientes(txtTrabajador.Tag)
            f.CaptionLabels(1).Text = txtTrabajador.Text
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Cursor = Cursors.WaitCursor
        If txtTrabajador.Text.Trim.Length > 0 Then
            frmConsultaAsistenciaSocio = New frmConsultaAsistenciaSocio(lblCodigoMembresia.Tag)
            frmConsultaAsistenciaSocio.StartPosition = FormStartPosition.CenterParent
            frmConsultaAsistenciaSocio.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        Cursor = Cursors.WaitCursor
        Try
            If txtTrabajador.Text.Trim.Length > 0 Then
                Grabar_Asistencia()
            Else
                MessageBox.Show("Debe identificar a un trabajador válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "Validar congelamientos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            thumb.Image = ImageListAdv1.Images(0) ' If(AuditPredicted = "0", Image.FromFile("../../Images/thumb_yes.png"), Image.FromFile("../../Images/thumb_no.png"))
            AuditPredicted.Text = "NO!" 'If(AuditPredicted = "0", "YES!", "NO!")
            PredictedText.Text = ex.Message ' "Acceso restringido, verificar fecha de inicio."
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub txtCodigoFiltrar_TextChanged(sender As Object, e As EventArgs) Handles txtCodigoFiltrar.TextChanged

    End Sub


#End Region

#Region "Events Huella"
    Public Sub OnComplete(Capture As Object, ReaderSerialNumber As String, Sample As Sample) Implements EventHandler.OnComplete
        '  If chHuella.Checked = True Then
        PonerImagen(ConvertirMapaBits(Sample))
            Dim caracteristicas As FeatureSet = extraerCaracteristicas(Sample, DPFP.Processing.DataPurpose.Verification)
            If caracteristicas IsNot Nothing Then
                Dim result As New DPFP.Verification.Verification.Result
                '   Dim lista = con.finger.ToList()
                Dim verificado As Boolean = False
                Dim nombre As String = Nothing
                Dim nrodoc As String = Nothing
                Dim codigoSocio As Integer = 0
                For Each i In ListaSociosEmpresa.ToList
                    If i.huella IsNot Nothing Then
                        Dim memoria As New MemoryStream(CType(i.huella, Byte()))
                    ' Dim memoria As New MemoryStream(template.Bytes)
                    General.Constantes.template.DeSerialize(memoria.ToArray())
                    verificador.Verify(caracteristicas, General.Constantes.template, result)
                    If result.Verified Then
                            nombre = i.nombreCompleto
                            codigoSocio = i.idEntidad
                            nrodoc = i.nrodoc
                            verificado = True
                            Exit For
                        End If
                    End If

                Next

                If verificado Then
                    MessageBox.Show("Bienvenido! " & nombre, "Usuario encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    MostrarDatos(nrodoc)
                Else
                    nombre = Nothing
                    nrodoc = Nothing
                    codigoSocio = 0
                    MessageBox.Show("No se encontró ningún socio", "Validar huella", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    LimipiarControles()
                End If

            End If
        '    End If
    End Sub

    Public Sub OnFingerGone(Capture As Object, ReaderSerialNumber As String) Implements EventHandler.OnFingerGone

    End Sub

    Public Sub OnFingerTouch(Capture As Object, ReaderSerialNumber As String) Implements EventHandler.OnFingerTouch

    End Sub

    Public Sub OnReaderConnect(Capture As Object, ReaderSerialNumber As String) Implements EventHandler.OnReaderConnect

    End Sub

    Public Sub OnReaderDisconnect(Capture As Object, ReaderSerialNumber As String) Implements EventHandler.OnReaderDisconnect

    End Sub

    Public Sub OnSampleQuality(Capture As Object, ReaderSerialNumber As String, CaptureFeedback As CaptureFeedback) Implements EventHandler.OnSampleQuality

    End Sub

    Private Sub chHuella_CheckedChanged(sender As Object, e As EventArgs) Handles chHuella.CheckedChanged
        If chHuella.Checked = True Then
            IniciarCaptura()
            ImagenHuella.Image = ImageListAdv2.Images(0)
            ImagenHuella.Visible = True
            'chHuella.Enabled = False
        Else
            ImagenHuella.Visible = False
            ImagenHuella.Image = Nothing
            ImagenHuella.Image = ImageListAdv2.Images(0)
            PararCaptura()
        End If
    End Sub

    Private Sub frmRegistroAsistenciaSocios_Leave(sender As Object, e As EventArgs) Handles Me.Leave
        PararCaptura()
    End Sub

    Private Sub GradientPanel3_Paint(sender As Object, e As PaintEventArgs) Handles GradientPanel3.Paint

    End Sub
#End Region


End Class