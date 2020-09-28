Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess

Public Class FormCanastaServicios

#Region "Attributes"
    Dim servicio As servicio
#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        'GetServicios()

    End Sub


#End Region

#Region "Methods"

    Public Sub CuentaServicio189()
        servicio = New servicio
        servicio.descripcion = txtServicio.Text
        servicio.cuenta = "189"
        servicio.idPadre = 4053
        If cboDestino.Text = "1-Gravado" Then
            servicio.tipo = "1"
        ElseIf cboDestino.Text = "2-Exonerado" Then
            servicio.tipo = "2"
        End If
    End Sub


    Private Sub GetServicios()
        Dim servicioSA As New servicioSA
        Dim Servicios = servicioSA.ListadoServiciosHijosXIdTipo(New servicio With {.codigo = "CM", .idPadre = 4053})

        cboServicio.DisplayMember = "descripcion"
        cboServicio.ValueMember = "idServicio"
        cboServicio.DataSource = Servicios
    End Sub
#End Region

#Region "Events"
    Private Sub cboServicio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboServicio.SelectedIndexChanged
        'Me.Cursor = Cursors.WaitCursor
        'Dim servicioSA As New servicioSA

        'If cboServicio.SelectedIndex > -1 Then
        '    'If ComboBoxAdv1.Text = "SERVICIOS & GASTOS" Then
        '    '    servicio = servicioSA.UbicarServicioPorId(New servicio With {.idServicio = cboServicio.SelectedValue})
        '    '    txtCuenta.Text = servicio.cuenta
        '    'ElseIf ComboBoxAdv1.Text = "ACTIVO INMOVILIZADO" Then
        '    '    txtCuenta.Text = cboServicio.SelectedValue
        '    'End If
        '    servicio = New servicio
        '    servicio = servicioSA.UbicarServicioPorId(New servicio With {.idServicio = cboServicio.SelectedValue})
        '    txtCuenta.Text = servicio.cuenta
        'End If
        'txtServicio.Clear()
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv15_Click(sender As Object, e As EventArgs) Handles ButtonAdv15.Click
        If txtServicio.Text.Trim.Length > 0 Then

            CuentaServicio189()

            If Not IsNothing(servicio) Then
                'Tag = obj.First
                'Close()
                txtServicio.Text = ""
                Dim miInterfaz As IServicio = TryCast(Me.Owner, IServicio)
                If miInterfaz IsNot Nothing Then miInterfaz.EnviarServicio(servicio)

            End If
        Else
            MessageBox.Show("Ingrese la Descripcion del servicio")
        End If
    End Sub

    Private Sub FormCanastaServicios_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
#End Region
End Class