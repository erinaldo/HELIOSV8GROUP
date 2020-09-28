Imports System.ComponentModel
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity

Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms

Public Class FormTablaPrincipalTransportes
#Region "Attributes"
    'Private UCMantenimiento As UCControlMantenimiento
    Public UCMaestroRutas As UCMaestroRutas

    Public UCMaestroActivo As UCMaestroActivo

    Public UCCrearBus As UCCrearBus
    Private Property FormUsuarioSPK As FormUsuarioSPK

    Private Property UCMaestroAgenciaEmp As UCMaestroAgenciaEmp

    Private Property USubMaestroRRHH As USubMaestroRRHH

    Public Property UFCrearRuta As UFCrearRuta

    Public Property UFProgramacionRuta As UFProgramacionRuta

    Public Property UCMaestroProgramacion As UCMaestroProgramacion

    Public Property USubMaestroServicios As USubMaestroServicios

    Public Property UFCambiarPLaca As UFCambiarPLaca

    Public Property UCMaestroCambioPlaca As UCMaestroCambioPlaca

    Public Property usuarioListSA As New Helios.Seguridad.WCFService.ServiceAccess.UsuarioSA

#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ' Timer1.Enabled = True
        'UCMantenimiento = New UCControlMantenimiento With {.Dock = DockStyle.Fill, .Visible = False}
        'PanelBody.Controls.Add(UCMantenimiento)


        UCMaestroRutas = New UCMaestroRutas(Me) With {.Dock = DockStyle.Fill, .Visible = False}
        PanelBody.Controls.Add(UCMaestroRutas)

        UCMaestroActivo = New UCMaestroActivo(Me) With {.Dock = DockStyle.Fill, .Visible = False}
        PanelBody.Controls.Add(UCMaestroActivo)

        UCMaestroAgenciaEmp = New UCMaestroAgenciaEmp(Me) With {.Dock = DockStyle.Fill, .Visible = False}
        PanelBody.Controls.Add(UCMaestroAgenciaEmp)

        USubMaestroRRHH = New USubMaestroRRHH() With {.Dock = DockStyle.Fill, .Visible = False}
        PanelBody.Controls.Add(USubMaestroRRHH)

        UCCrearBus = New UCCrearBus(Me) With {.Dock = DockStyle.Fill, .Visible = False}
        PanelBody.Controls.Add(UCCrearBus)

        UFCrearRuta = New UFCrearRuta(Me) With {.Dock = DockStyle.Fill, .Visible = False}
        PanelBody.Controls.Add(UFCrearRuta)

        UFProgramacionRuta = New UFProgramacionRuta(Me) With {.Dock = DockStyle.Fill, .Visible = False}
        PanelBody.Controls.Add(UFProgramacionRuta)

        UCMaestroProgramacion = New UCMaestroProgramacion(Me) With {.Dock = DockStyle.Fill, .Visible = False}
        PanelBody.Controls.Add(UCMaestroProgramacion)

        USubMaestroServicios = New USubMaestroServicios() With {.Dock = DockStyle.Fill, .Visible = False}
        PanelBody.Controls.Add(USubMaestroServicios)

        UFCambiarPLaca = New UFCambiarPLaca(Me) With {.Dock = DockStyle.Fill, .Visible = False}
        PanelBody.Controls.Add(UFCambiarPLaca)

        UCMaestroCambioPlaca = New UCMaestroCambioPlaca(Me) With {.Dock = DockStyle.Fill, .Visible = False}
        PanelBody.Controls.Add(UCMaestroCambioPlaca)

        UsuariosList = usuarioListSA.ListadoUsuariosv2()
    End Sub

    Public Sub LIMPIAR()
        PanelBody.Visible = True
        UCMaestroRutas.Visible = False
        UCCrearBus.Visible = False
        UCMaestroActivo.Visible = False
        UCMaestroAgenciaEmp.Visible = False
        USubMaestroRRHH.Visible = False
        USubMaestroServicios.Visible = False
    End Sub

    Public Sub LIMPIARTOTAL()
        PanelBody.Visible = False
        UCMaestroRutas.Visible = False
        UCCrearBus.Visible = False
        UCMaestroActivo.Visible = False
        UCMaestroAgenciaEmp.Visible = False
        USubMaestroRRHH.Visible = False
        USubMaestroServicios.Visible = False
    End Sub

    Private Sub btnPrincipal_Click(sender As Object, e As EventArgs) Handles btnPrincipal.Click, BunifuFlatButton3.Click, BunifuFlatButton16.Click, BunifuFlatButton1.Click, BunifuFlatButton2.Click, BunifuFlatButton4.Click, BunifuFlatButton15.Click
        Try
            sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
            sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width

            Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
            Select Case btn.Text
                Case "PRINCIPAL"
                    PanelBody.Visible = True
                    UCMaestroRutas.Visible = False
                    UCCrearBus.Visible = False
                    UCMaestroActivo.Visible = False
                    UCMaestroAgenciaEmp.Visible = False
                    USubMaestroRRHH.Visible = False
                    USubMaestroServicios.Visible = False
                Case "AGENCIAS"
                    PanelBody.Visible = True
                    UCMaestroActivo.Visible = False
                    UCCrearBus.Visible = False
                    UCMaestroRutas.Visible = False
                    USubMaestroRRHH.Visible = False
                    USubMaestroServicios.Visible = False
                    If UCMaestroAgenciaEmp IsNot Nothing Then
                        UCMaestroAgenciaEmp.Visible = True
                        UCMaestroAgenciaEmp.BringToFront()
                        UCMaestroAgenciaEmp.Show()
                    End If

                Case "RUTAS"
                    PanelBody.Visible = True
                    UCMaestroActivo.Visible = False
                    UCCrearBus.Visible = False
                    UCMaestroAgenciaEmp.Visible = False
                    USubMaestroRRHH.Visible = False
                    USubMaestroServicios.Visible = False
                    If UCMaestroRutas IsNot Nothing Then
                        UCMaestroRutas.Visible = True
                        UCMaestroRutas.BringToFront()
                        UCMaestroRutas.Show()
                    End If

                Case "ACTIVOS"

                    PanelBody.Visible = True
                    UCMaestroRutas.Visible = False
                    UCCrearBus.Visible = False
                    UCMaestroAgenciaEmp.Visible = False
                    USubMaestroRRHH.Visible = False
                    USubMaestroServicios.Visible = False
                    If UCMaestroActivo IsNot Nothing Then
                        UCMaestroActivo.Visible = True
                        UCMaestroActivo.BringToFront()
                        UCMaestroActivo.Show()
                    End If

                Case "PERSONAS"
                    PanelBody.Visible = True
                    UCMaestroRutas.Visible = False
                    UCMaestroActivo.Visible = False
                    UCCrearBus.Visible = False
                    UCMaestroAgenciaEmp.Visible = False
                    USubMaestroServicios.Visible = False
                    If USubMaestroRRHH IsNot Nothing Then
                        USubMaestroRRHH.Visible = True
                        USubMaestroRRHH.BringToFront()
                        USubMaestroRRHH.Show()
                    End If

                Case "SERVICIO"
                    PanelBody.Visible = True
                    UCMaestroRutas.Visible = False
                    UCMaestroActivo.Visible = False
                    UCCrearBus.Visible = False
                    UCMaestroAgenciaEmp.Visible = False
                    USubMaestroRRHH.Visible = False

                    If USubMaestroServicios IsNot Nothing Then
                        USubMaestroServicios.Visible = True
                        USubMaestroServicios.BringToFront()
                        USubMaestroServicios.Show()
                    End If

                Case "REPORTE"
                    PanelBody.Visible = True
                    UCMaestroRutas.Visible = False
                    UCMaestroActivo.Visible = False
                    UCCrearBus.Visible = False
                    UCMaestroAgenciaEmp.Visible = False
                    USubMaestroServicios.Visible = False
                    If USubMaestroRRHH IsNot Nothing Then
                        USubMaestroRRHH.Visible = True
                        USubMaestroRRHH.BringToFront()
                        USubMaestroRRHH.Show()
                    End If

            End Select

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuCustomLabel11_Click(sender As Object, e As EventArgs) Handles BunifuCustomLabel11.Click
        FormLogeoNuevoIntro()
    End Sub
#End Region

#Region "metodo"
    Private Sub FormLogeoNuevoIntro()
        'Dim Login As New FormOrgainizacion
        'Login.StartPosition = FormStartPosition.CenterParent
        'Login.ShowDialog(Me)
        'Application.DoEvents()
        'GetConfiguracionInicioBasico()
        'If bg.IsBusy <> True Then
        '    ' Start the asynchronous operation.
        '    bg.RunWorkerAsync()
        'End If

        Me.Dispose()
        Dim Login As New FormOrgainizacionV2
        Login.StartPosition = FormStartPosition.CenterParent
        Login.ShowDialog()
        Application.DoEvents()
        'GetConfiguracionInicioBasico()
        'If bg.IsBusy <> True Then
        '    ' Start the asynchronous operation.
        '    bg.RunWorkerAsync()
        'End If

    End Sub

    Private Sub HubTile1_Click(sender As Object, e As EventArgs) Handles HubTile1.Click
        Dim frm As MetroForm = Application.OpenForms.OfType(Of MetroForm)().Where(Function(pre) pre.Name = "FormUsuarioSPK").SingleOrDefault
        If frm Is Nothing Then
            FormUsuarioSPK = New FormUsuarioSPK
            FormUsuarioSPK.Show()
        Else
            FormUsuarioSPK.WindowState = FormWindowState.Normal
            FormUsuarioSPK.BringToFront()
        End If
    End Sub


    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        PanelBody.Visible = True
        UCMaestroRutas.Visible = False
        UCMaestroActivo.Visible = False
        UCCrearBus.Visible = False
        USubMaestroRRHH.Visible = False
        UCMaestroAgenciaEmp.Visible = False
        UFCambiarPLaca.Visible = False
        If UCMaestroProgramacion IsNot Nothing Then
            UCMaestroProgramacion.Visible = True
            UCMaestroProgramacion.BringToFront()
            UCMaestroProgramacion.Show()
        End If
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        PanelBody.Visible = True
        UCMaestroRutas.Visible = False
        UCMaestroActivo.Visible = False
        UCCrearBus.Visible = False
        USubMaestroRRHH.Visible = False
        UCMaestroAgenciaEmp.Visible = False
        UCMaestroProgramacion.Visible = False
        If UFCambiarPLaca IsNot Nothing Then
            UFCambiarPLaca.Visible = True
            UFCambiarPLaca.BringToFront()
            UFCambiarPLaca.Show()
        End If
    End Sub

    Private Sub BunifuCustomLabel8_Click(sender As Object, e As EventArgs) Handles BunifuCustomLabel8.Click
        Dim Login As New frmCrearENtidades
        Login.StartPosition = FormStartPosition.CenterParent
        Login.ShowDialog()
    End Sub

    Private Sub BunifuCustomLabel3_Click(sender As Object, e As EventArgs) Handles BunifuCustomLabel3.Click

    End Sub

    Private Sub BunifuCustomLabel6_Click(sender As Object, e As EventArgs) Handles BunifuCustomLabel6.Click

    End Sub

    Private Sub BunifuCustomLabel9_Click(sender As Object, e As EventArgs) Handles BunifuCustomLabel9.Click

    End Sub



#End Region

End Class