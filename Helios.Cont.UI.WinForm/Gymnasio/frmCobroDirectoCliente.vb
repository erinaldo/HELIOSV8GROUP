Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports System.IO
Imports DPFP
Imports DPFP.Capture
Imports DPFP.Verification

Public Class frmCobroDirectoCliente
    Implements DPFP.Capture.EventHandler

    Protected entidadSA As New entidadSA
    Protected Friend frmRegistroVentasClientes As frmRegistroVentasClientes
    Protected Friend frmConsultaAsistenciaSocio As frmConsultaAsistenciaSocio
    Protected Friend ListaSociosEmpresa As List(Of Business.Entity.entidad)

#Region "Atributos Huella"
    'Private captura As Capture
    'Private template As DPFP.Template
    'Private verificador As Verification
    Private Delegate Sub _delegadoMuestraSocio(ByVal nroDoc As String)
    Private Delegate Sub _delegadoLimpiarSocio()
#End Region

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        entidadSA = New WCFService.ServiceAccess.entidadSA
        ListaSociosEmpresa = New List(Of Business.Entity.entidad)
        ListaSociosEmpresa = entidadSA.GetEntidadesGenerales(TIPO_ENTIDAD.CLIENTE, Gempresas.IdEmpresaRuc)
        captura.EventHandler = Me
    End Sub


    Private Sub btRegistrar_Click(sender As Object, e As EventArgs) Handles btPagos.Click
        Dim entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", txtCliente.Text)

        If entidad IsNot Nothing Then
            Hide()
            frmRegistroVentasClientes = New frmRegistroVentasClientes(entidad.idEntidad)
            frmRegistroVentasClientes.CaptionLabels(1).Text = "Cliente: " & entidad.nombreCompleto
            frmRegistroVentasClientes.StartPosition = FormStartPosition.CenterParent
            frmRegistroVentasClientes.ShowDialog()
        Else
            MessageBox.Show("El número de DNI. consultado no existe, verificar", "Verificar DNI.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCliente.Select()
            txtCliente.SelectAll()
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Close()
    End Sub

    Private Sub frmCobroDirectoCliente_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtCliente.Select()
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles btAsistencia.Click
        Cursor = Cursors.WaitCursor
        Dim entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", txtCliente.Text)

        If entidad IsNot Nothing Then
            Hide()
            frmConsultaAsistenciaSocio = New frmConsultaAsistenciaSocio(entidad.idEntidad)
            frmConsultaAsistenciaSocio.StartPosition = FormStartPosition.CenterParent
            frmConsultaAsistenciaSocio.ShowDialog()
        Else
            MessageBox.Show("El número de DNI. consultado no existe, verificar", "Verificar DNI.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCliente.Select()
            txtCliente.SelectAll()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles btMembresias.Click
        Cursor = Cursors.WaitCursor
        Dim entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", txtCliente.Text)
        If entidad IsNot Nothing Then
            Hide()
            frmMembresiasClienteMaestro = New frmMembresiasClienteMaestro(entidad.idEntidad)
            frmMembresiasClienteMaestro.CaptionLabels(1).Text = entidad.nombreCompleto & "-" & entidad.nrodoc
            frmMembresiasClienteMaestro.StartPosition = FormStartPosition.CenterParent
            frmMembresiasClienteMaestro.ShowDialog()
        Else
            MessageBox.Show("El número de DNI u otro. consultado no existe, verificar", "Verificar DNI.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCliente.Select()
            txtCliente.SelectAll()
        End If
        Cursor = Cursors.Default
    End Sub

    'Private Sub rbHuella_CheckedChanged(sender As Object, e As EventArgs) Handles rbHuella.CheckedChanged
    '    If rbHuella.Checked = True Then
    '        txtCliente.ReadOnly = True
    '        '      chHuella.Enabled = True
    '        GradientPanel5.Enabled = True
    '        btMembresias.Enabled = False
    '        btAsistencia.Enabled = False
    '        btPagos.Enabled = False
    '    Else
    '        'chHuella.Enabled = False
    '        'GradientPanel5.Enabled = False
    '        'txtCliente.ReadOnly = False
    '    End If
    'End Sub

    'Private Sub rbDNI_CheckedChanged(sender As Object, e As EventArgs) Handles rbDNI.CheckedChanged
    '    If rbDNI.Checked = True Then
    '        '  chHuella_CheckedChanged(sender, e)
    '        ' chHuella.Enabled = False
    '        GradientPanel5.Enabled = False
    '        txtCliente.ReadOnly = False
    '        txtCliente.Clear()
    '        txtCliente.Select()
    '        btMembresias.Enabled = True
    '        btAsistencia.Enabled = True
    '        btPagos.Enabled = True
    '        If ImageListAdv2.Images.Count > 0 Then
    '            ImagenHuella.Image = ImageListAdv2.Images(0)
    '        End If
    '    End If
    'End Sub

#Region "Methods Huella"

    Private Sub LimipiarControles()
        If txtCliente.InvokeRequired Then
            Dim deleg As New _delegadoLimpiarSocio(AddressOf LimipiarControles)
            Invoke(deleg, New Object() {})
        Else
            txtCliente.Clear()
            txtCliente.Select()
            btMembresias.Enabled = False
            btAsistencia.Enabled = False
            btPagos.Enabled = False
        End If
    End Sub

    Private Sub MostrarDatos(ByVal nroDoc As String)
        If txtCliente.InvokeRequired Then
            Dim deleg As New _delegadoMuestraSocio(AddressOf MostrarDatos)
            Invoke(deleg, New Object() {nroDoc})
        Else
            GetEntidadEncontrada(nroDoc)
        End If
    End Sub

    Private Sub GetEntidadEncontrada(nroDoc As String)
        Dim entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", nroDoc)
        If entidad IsNot Nothing Then
            txtCliente.Text = entidad.nombreCompleto
            txtCliente.Tag = entidad.idEntidad

            btMembresias.Enabled = True
            btAsistencia.Enabled = True
            btPagos.Enabled = True
        Else
            MessageBox.Show("El número de DNI. consultado no existe, verificar", "Verificar DNI.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCliente.Select()
            txtCliente.SelectAll()
        End If
    End Sub

    'Protected Overridable Sub Init()
    '    Try
    '        captura = New Capture

    '        If captura IsNot Nothing Then
    '            captura.EventHandler = Me
    '            verificador = New Verification
    '            template = New Template
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

#Region "Events Huella"
    Public Sub OnComplete(Capture As Object, ReaderSerialNumber As String, Sample As Sample) Implements EventHandler.OnComplete
        '     If chHuella.Checked = True Then
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
                    Constantes.template.DeSerialize(memoria.ToArray())
                    verificador.Verify(caracteristicas, Constantes.template, result)
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
        '   End If
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

    'Private Sub chHuella_CheckedChanged(sender As Object, e As EventArgs) Handles chHuella.CheckedChanged
    '    If chHuella.Checked = True Then
    '        Init()
    '        IniciarCaptura()
    '    Else
    '        ImagenHuella.Image = Nothing
    '        ImagenHuella.Image = ImageListAdv2.Images(0)
    '        '  PararCaptura()
    '    End If
    'End Sub

    Private Sub frmCobroDirectoCliente_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        PararCaptura()
    End Sub

    Private Sub txtCliente_TextChanged(sender As Object, e As EventArgs) Handles txtCliente.TextChanged

    End Sub

    Private Sub frmCobroDirectoCliente_Activated(sender As Object, e As EventArgs) Handles Me.Activated

    End Sub

    Private Sub frmCobroDirectoCliente_Leave(sender As Object, e As EventArgs) Handles Me.Leave
        PararCaptura()
    End Sub

    Private Sub chHuella_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub chHuella_CheckedChanged_1(sender As Object, e As EventArgs) Handles chHuella.CheckedChanged
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

    'Private Sub chHuella_CheckedChanged(sender As Object, e As EventArgs) Handles chHuella.CheckedChanged
    '    If chHuella.Checked = True Then

    '        ImagenHuella.Image = ImageListAdv2.Images(0)
    '        ImagenHuella.Visible = True
    '        chHuella.Enabled = False
    '    Else
    '        ImagenHuella.Visible = False
    '        ImagenHuella.Image = Nothing
    '        ImagenHuella.Image = ImageListAdv2.Images(0)
    '        '       PararCaptura()
    '    End If
    'End Sub
#End Region
End Class