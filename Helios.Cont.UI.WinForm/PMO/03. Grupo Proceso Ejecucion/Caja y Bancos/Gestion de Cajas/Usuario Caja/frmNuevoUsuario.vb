Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmNuevoUsuario
    Inherits frmMaster
    Private lblPeriodo As System.Windows.Forms.ToolStripLabel
    Private lblPeriodoLabel As System.Windows.Forms.ToolStripLabel
    Public ManipulacionEstado As String

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        lblPerido.Text = PeriodoGeneral
        ClearCajas()
        txtDniTrab.Select()
    End Sub

    Private Sub ClearCajas()
        txtDniTrab.Clear()
        txtNombreTrab.Clear()
        txtAppatTrab.Clear()
        txtApmatTrab.Clear()
    End Sub

    Public Sub GrabarPersona()
        Dim personaSA As New PersonaSA
        Dim personaBE As New Persona

        With personaBE
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idPersona = txtDniTrab.Text.Trim
            .nombres = txtNombreTrab.Text.Trim
            .appat = txtAppatTrab.Text.Trim
            .apmat = txtApmatTrab.Text.Trim
            .nombreCompleto = String.Concat(.appat & " " & .apmat & ", " & .nombres)
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = Date.Now
        End With
        personaSA.InsertPersona(personaBE)
        Dispose()
    End Sub

    Public Sub UpdatePersona()
        Dim personaSA As New PersonaSA
        Dim personaBE As New Persona

        With personaBE
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idPersona = txtDniTrab.Text.Trim
            .nombres = txtNombreTrab.Text.Trim
            .appat = txtAppatTrab.Text.Trim
            .apmat = txtApmatTrab.Text.Trim
            .nombreCompleto = String.Concat(.appat & " " & .apmat & ", " & .nombres)
        End With
        personaSA.EditarPersona(personaBE)
        Dispose()
    End Sub

    Public Sub UbicarporDNI(srtDNI As Integer)
        Dim personaSA As New PersonaSA
        Dim personaBE As New Persona

        personaBE = personaSA.ObtenerPersonaNumDoc(Gempresas.IdEmpresaRuc, srtDNI)

        With personaBE
            txtDniTrab.Text = .idPersona
            txtNombreTrab.Text = .nombres
            txtAppatTrab.Text = .appat
            txtApmatTrab.Text = .apmat
        End With
        txtDniTrab.Select()
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As Object, e As EventArgs) Handles GuardarToolStripButton.Click
     

    End Sub

    Private Sub txtNombreTrab_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNombreTrab.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtAppatTrab.Focus()
            txtAppatTrab.Select()
        End If
    End Sub

    Private Sub txtDniTrab_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDniTrab.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtNombreTrab.Focus()
            txtNombreTrab.Select()
        End If
    End Sub

    Private Sub txtAppatTrab_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAppatTrab.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtApmatTrab.Focus()
            txtApmatTrab.Select()
        End If
    End Sub

    Private Sub frmNuevoUsuario_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmNuevoUsuario_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        If Not txtDniTrab.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el nro de documento del trabajador"
            pcTrabajador.Font = New Font("Segoe UI", 8)
            pcTrabajador.Size = New Size(327, 250)
            txtDniTrab.Select()
            Exit Sub
        End If

        If Not txtNombreTrab.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el nombre del trabajador"
            pcTrabajador.Font = New Font("Segoe UI", 8)
            pcTrabajador.Size = New Size(327, 250)
            txtNombreTrab.Select()
            Exit Sub
        End If

        If Not txtAppatTrab.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese los apellidos del trabajador"
            pcTrabajador.Font = New Font("Segoe UI", 8)
            pcTrabajador.Size = New Size(327, 250)
            txtAppatTrab.Select()
            Exit Sub
        End If

        If Not txtApmatTrab.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese los apellidos del trabajador"
            pcTrabajador.Font = New Font("Segoe UI", 8)
            pcTrabajador.Size = New Size(327, 250)
            txtApmatTrab.Select()
            Exit Sub
        End If

        If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
            GrabarPersona()
        ElseIf ManipulacionEstado = ENTITY_ACTIONS.UPDATE Then
            UpdatePersona()
        End If
    End Sub
End Class