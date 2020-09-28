Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Drawing

Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Imports System.ComponentModel
Public Class frmNuevoServicio
    Inherits frmMaster

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        'LoadCombos()
        If cboTipo.Text = "COMPRA" Then
            tipopadre("PC")
        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub

#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean



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

#Region "Métodos"

    Public Class Categoria

        Private _name As String
        Private _id As Integer
        Private _Utilidad As String
       
        Public Sub New(ByVal name As String, ByVal id As Integer, ByVal utilidad As String)
            _name = name
            _id = id
            _Utilidad = utilidad

        End Sub

        Sub New()
            ' TODO: Complete member initialization 
        End Sub

        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property
        Public Property Id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal value As Integer)
                _id = value
            End Set
        End Property

        Public Property Utilidad() As String
            Get
                Return _Utilidad
            End Get
            Set(ByVal value As String)
                _Utilidad = value
            End Set
        End Property

    End Class




    Public Sub EliminarServicioPadreHijo(idservicio As Integer)
        Dim objitem As New servicio
        Dim servicioSA As New servicioSA

        Try

            objitem.idServicio = idservicio


            servicioSA.EliminarServicioPadreHijo(objitem)
            '  Dim codxIdtem As Integer = servicioSA.GrabarServicioPadre(objitem)
            'Me.lblEstado.Image = My.Resources.ok4
            'Me.lblEstado.Text = "Item registrado!"

            Dispose()



        Catch ex As Exception
            'Manejo de errores
            'lblEstado.Text = ex.Message
            'lblEstado.Image = My.Resources.warning2
        End Try
    End Sub


    'Public Sub LoadCombos()
    '    Dim servicioSA As New servicioSA

    '    cboServicioPadre.DisplayMember = "descripcion"
    '    cboServicioPadre.ValueMember = "idServicio"
    '    cboServicioPadre.DataSource = servicioSA.ListadoServiciosPadre

    'End Sub
    Public Sub tipopadre(ByVal tipo As String)

        Dim servicioSA As New servicioSA
        Dim servicio As New servicio
        Dim serv As New List(Of servicio)
        
        cboServicioPadre.DataSource = Nothing
        cboServicioPadre.Items.Clear()
        For Each i In servicioSA.ListadoServiciosPadreTipo(tipo)
            cboServicioPadre.Items.Add(New Categoria(i.descripcion, i.idServicio, i.cuenta))
        Next
       
        cboServicioPadre.DisplayMember = "Name"
        cboServicioPadre.ValueMember = "Id"


    End Sub

    Public Sub tipopadreVenta(ByVal tipo As String)

        Dim servicioSA As New servicioSA
        cboServicioPadre.DataSource = Nothing
        cboServicioPadre.Items.Clear()

        cboServicioPadre.DisplayMember = "descripcion"
        cboServicioPadre.ValueMember = "idServicio"
        cboServicioPadre.DataSource = servicioSA.ListadoServiciosPadreTipo(tipo)

    End Sub






    Sub LoadCuentas(strOpcion As String)
        Dim cuentaSA As New cuentaplanContableEmpresaSA
        'cboCuenta.Items.Clear()
        cboCuenta.DataSource = Nothing

        Select Case strOpcion
            Case "COMPRA"
                cboCuenta.DisplayMember = "descripcion"
                cboCuenta.ValueMember = "cuenta"
                cboCuenta.DataSource = cuentaSA.LoadCuentasGastosPadre(Gempresas.IdEmpresaRuc)
                cboCuenta.SelectedValue = "7041"
            Case Else



                Dim listaTabla As New List(Of cuentaplanContableEmpresa)
                listaTabla = cuentaSA.ListarCuentasPorPadre(Gempresas.IdEmpresaRuc, "70")
                Dim obj As New cuentaplanContableEmpresa
                Dim listaCuenta As New List(Of cuentaplanContableEmpresa)

                'Dim consulta = (From n In listaTabla).ToList

                For Each i In listaTabla
                    obj = New cuentaplanContableEmpresa
                    obj.cuenta = i.cuenta
                    obj.descripcion = String.Concat(i.cuenta, " - ", i.descripcion)
                    listaCuenta.Add(obj)
                Next

                cboCuenta.DisplayMember = "descripcion"
                cboCuenta.ValueMember = "cuenta"
                cboCuenta.DataSource = listaCuenta
                cboCuenta.SelectedValue = "7041"


                'cboCuenta.DisplayMember = "descripcion"
                'cboCuenta.ValueMember = "cuenta"
                'cboCuenta.DataSource = cuentaSA.ListarCuentasPorPadre(Gempresas.IdEmpresaRuc, "70")
                'cboCuenta.SelectedValue = "7041"
        End Select

    End Sub

    Public Sub Grabar()
        Dim servicioBE As New servicio
        Dim servicioSA As New servicioSA
        Try
            servicioBE = New servicio
            Select Case cboTipo.Text
                Case "COMPRA"
                    servicioBE.codigo = "CM"
                    servicioBE.idPadre = DirectCast(Me.cboServicioPadre.SelectedItem, Categoria).Id
                Case "VENTA"
                    servicioBE.codigo = "VT"
                    servicioBE.idPadre = cboServicioPadre.SelectedValue
            End Select
            'servicioBE.idPadre = cboServicioPadre.SelectedValue
            'servicioBE.idPadre = DirectCast(Me.cboServicioPadre.SelectedItem, Categoria).Id
            servicioBE.descripcion = txtServicio.Text.Trim
            servicioBE.cuenta = cboCuenta.SelectedValue
            servicioBE.observaciones = txtSubDetalle.Text.Trim
            servicioBE.estado = "1"
            servicioSA.GrabarServicio(servicioBE)
            Dispose()
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub
#End Region


    Private Sub frmNuevoServicio_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmNuevoServicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
    End Sub

    Private Sub ButtonAdv15_Click(sender As Object, e As EventArgs) Handles ButtonAdv15.Click
        Me.Cursor = Cursors.WaitCursor

      
            If cboServicioPadre.Text.Trim.Length Then
                If txtServicio.Text.Trim.Length > 0 Then
                    Grabar()
                Else
                    PanelError.Visible = True
                    lblEstado.Text = "Ingrese una descripcion"
                End If
            Else
                PanelError.Visible = True
                lblEstado.Text = "Seleccione un servicio padre"
            End If

            Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboTipo_Click(sender As Object, e As EventArgs) Handles cboTipo.Click

    End Sub

    

    Private Sub cboTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipo.SelectedIndexChanged


        'cboServ.Items.Clear()

        If cboTipo.Text = "COMPRA" Then

            LoadCuentas("COMPRA")

            tipopadre("PC")
        Else

            LoadCuentas("VENTA")
            tipopadreVenta("PV")
        End If
    End Sub

    Private Sub cboCuenta_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub cboCuenta_SelectedIndexChanged(sender As Object, e As EventArgs)
        '  txtNomcuenta.Text = cboCuenta.SelectedValue
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Cursor = Cursors.WaitCursor

        Dim f As New FrmAddServicio
        f.StartPosition = FormStartPosition.CenterParent
        If cboTipo.Text = "COMPRA" Then
            f.txttipo.Text = "PC"
        ElseIf cboTipo.Text = "VENTA" Then
            f.txttipo.Text = "PV"
        End If

        f.ShowDialog()
        'LoadCombos()
        If cboTipo.Text = "COMPRA" Then
            tipopadre("PC")
        ElseIf cboTipo.Text = "VENTA" Then
            tipopadreVenta("PV")
        End If


        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs)
        'If cboServicioPadre.Text.Trim.Length > 0 Then
        '    EliminarServicioPadreHijo(cboServicioPadre.SelectedValue)
        'End If
    End Sub

    Private Sub cboServicioPadre_Click(sender As Object, e As EventArgs) Handles cboServicioPadre.Click

        

    End Sub

    Public Sub cuentaportipo(ByVal padre As String)
        Dim cuentaSA As New cuentaplanContableEmpresaSA

        cboCuenta.DataSource = Nothing

        cboCuenta.DisplayMember = "descripcion"
        cboCuenta.ValueMember = "cuenta"
        cboCuenta.DataSource = cuentaSA.ListarCuentasPorPadreDescrip(Gempresas.IdEmpresaRuc, padre)
        'cboCuenta.SelectedValue = "7041"
    End Sub
    Private Sub cboServicioPadre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboServicioPadre.SelectedIndexChanged


        If cboTipo.Text = "COMPRA" Then
            'TextBox1.Text = DirectCast(Me.cboServicioPadre.SelectedItem, Categoria).Utilidad
            If cboServicioPadre.Text.Trim.Length > 0 Then
                cuentaportipo(DirectCast(Me.cboServicioPadre.SelectedItem, Categoria).Utilidad)
            End If



        End If

    End Sub
End Class