Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Public Class frmSoftpackModulo

    Private Property SelEmpresa As empresa
    Private Property SelEstablecimiento As centrocosto
    Private Property EstablecimientoSA As New establecimientoSA

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub GradientPanel2_Click(sender As Object, e As EventArgs) Handles GradientPanel2.Click
        'Dim f As New frmMaestroModuloPOS
        'f.Show()
        'Hide()
    End Sub

    Private Sub GradientPanel5_Click(sender As Object, e As EventArgs) Handles GradientPanel5.Click
        'Dim f As New frmMaestroModuloV2
        'f.StartPosition = FormStartPosition.CenterParent
        'f.Show()
        'Hide()
    End Sub

    Private Sub frmSoftpackModulo_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim boundWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim boundHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        Dim x As Integer = boundWidth - Me.Width
        Dim y As Integer = boundHeight - Me.Height
        Me.Location = New Point(x \ 2, y \ 2)
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Hide()
        Dim f As New frmMaestroModulosGimnasio ' frmMaestroModuloPOS
        f.Show()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Hide()
        Dim f As New frmMaestroModuloPOS
        f.Show()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Dispose()
        Dim f As New FormOrgainizacion 'FormTablaPrincipal
        f.StartPosition = FormStartPosition.CenterParent
        f.Show()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Cursor = Cursors.WaitCursor
        SelEmpresa = New empresa
        Dim f As New frmNuevoClienteSPK
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        If Not IsNothing(f.Tag) Then
            SelEmpresa = CType(f.Tag, empresa)
            Dim f1 As New frmEmpresaNumeracionInicio(SelEmpresa.idEmpresa)
            f1.StartPosition = FormStartPosition.CenterParent
            f1.ShowDialog()

            GetGlobalMapping()

            Dim f2 As New frmInicioTrabajoEmpresa(SelEmpresa.idEmpresa)
            f2.StartPosition = FormStartPosition.CenterParent
            f2.ShowDialog()
        End If
        Cursor = Cursors.Arrow
    End Sub

    ''' <summary>
    ''' Fill Variables globales
    ''' </summary>
    Private Sub GetGlobalMapping()
        SelEstablecimiento = New centrocosto
        SelEstablecimiento = EstablecimientoSA.ObtenerListaEstablecimientos(SelEmpresa.idEmpresa).Where(Function(o) o.TipoEstab = "UN").FirstOrDefault
        Gempresas = New GEmpresa With
            {
            .IdEmpresaRuc = SelEmpresa.idEmpresa,
            .NomCorto = SelEmpresa.nombreCorto,
            .NomEmpresa = SelEmpresa.razonSocial,
            .Ruc = SelEmpresa.ruc,
            .InicioOpeaciones = SelEmpresa.inicioOperacion
        }

        GEstableciento = New GEstablecimiento
        GEstableciento.IdEstablecimiento = SelEstablecimiento.idCentroCosto
        GEstableciento.NombreEstablecimiento = SelEstablecimiento.nombre
        'AnioGeneral = cboAnio.Text
        'MesGeneral = String.Format("{0:00}", Convert.ToInt32(Me.txtFechaInicio.Value.Month))
        'DiaLaboral = txtFechaInicio.Value
        'PeriodoGeneral = String.Format("{0:00}", Convert.ToInt32(Me.txtFechaInicio.Value.Month)) & "/" & cboAnio.Text
        'TmpTipoCambio = nudTipoCambioVenta.DecimalValue
        'TmpTipoCambioTransaccionCompra = nudTipoCambioCompra.DecimalValue
        'TmpTipoCambioTransaccionVenta = nudTipoCambioVenta.DecimalValue
        'TmpIGV = 18.0
        'MontoMaximoCliente = 699.0
        usuario = New Seguridad.Business.Entity.AutenticacionUsuario
        usuario.IDUsuario = 0
        usuario.CustomUsuario = New Seguridad.Business.Entity.Usuario
        usuario.CustomUsuario.ApellidoMaterno = "Amidn"
        usuario.CustomUsuario.ApellidoPaterno = "Amidn"
        usuario.CustomUsuario.Nombres = "Amidn"
        usuario.CustomUsuario.NroDocumento = "-"
    End Sub
End Class