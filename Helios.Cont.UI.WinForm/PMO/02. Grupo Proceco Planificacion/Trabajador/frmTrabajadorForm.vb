Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports System.Text.RegularExpressions
Public Class frmTrabajadorForm
    Public xManipulacion As String

#Region "Manipulación Data"
    Private Function validar_Mail(ByVal sMail As String) As Boolean
        ' retorna true o false   
        Return Regex.IsMatch(sMail, _
                "^([\w-]+\.)*?[\w-]+@[\w-]+\.([\w-]+\.)*?[\w]+$")
    End Function
    'Public Sub ObtenerTrabPorDoc(ByVal NumDoc As String)
    '    Dim trabajadorSA As New Trabajador_PLSA
    '    Dim objLista() As HeliosService.PersonaBO
    '    Try
    '        With trabajadorSA.UbicarTrabDNI(GEstableciento.IdEstablecimiento, NumDoc)

    '        End With
    '        If objLista.Length > 0 Then
    '            txtNombres.Text = objLista(0).pNombres
    '            txtAppat.Text = objLista(0).pAppat
    '            txtApmat.Text = objLista(0).pApmat
    '            '  txtNumDoc.Text = objLista(0).pIdPersona
    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    'Public Sub EliminarCargo(ByVal xCase As Byte)
    '    Select Case xCase
    '        Case 1 'AFECTA A LA BD
    '            Dim objService = HeliosSEProxy.CrearProxyHELIOS()
    '            Dim objCargo As New HeliosService.trabajadorOcupacion_PLEO()
    '            Try
    '                With objCargo
    '                    .idEmpresa = CEmpresa
    '                    .idEstablecimiento = CEstablecimiento
    '                    .codTrabajdor = txtNumDoc.Text
    '                    .codOcupacion = lsvOcupacion.SelectedItems(0).SubItems(0).Text
    '                End With
    '                objService.GetDeleteOCupTrab(objCargo)
    '                Me.lblEstado.Image = My.Resources.ok ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\ok.ico")


    '            Catch ex As Exception
    '                MsgBox(ex.Message)
    '            End Try
    '        Case 2 'NO AFECTA A LA BD

    '            lsvOcupacion.SelectedItems(0).Remove()
    '    End Select


    'End Sub

    'Public Sub EliminarCorreo(ByVal xCase As Byte)
    '    Select Case xCase
    '        Case 1 'AFECTA A LA BD
    '            Dim objService = HeliosSEProxy.CrearProxyHELIOS()
    '            Dim objCargo As New HeliosService.CorreoEntidadesEO()
    '            Try
    '                With objCargo
    '                    .codigo = lsvCorreos.SelectedItems(0).SubItems(0).Text
    '                End With
    '                If objService.GetEliminarCorreo(objCargo) = True Then
    '                    lsvCorreos.SelectedItems(0).Remove()
    '                    Me.lblEstado.Image = My.Resources.ok ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\ok.ico")
    '                End If

    '            Catch ex As Exception
    '                MsgBox(ex.Message)
    '            End Try
    '        Case 2 'NO AFECTA A LA BD

    '            lsvCorreos.SelectedItems(0).Remove()
    '    End Select


    'End Sub

    Public Function UbicarTabalDetails(ByVal intIdTabla As Integer, ByVal strCodigo As String) As String
        Dim tablaSA As New tablaDetalleSA
        Dim strDatoRegresa As String = Nothing
        Try
            With tablaSA.GetUbicarTablaID(intIdTabla, strCodigo)
                If Not IsNothing(tablaSA) Then
                    strDatoRegresa = .descripcion
                Else
                    strDatoRegresa = Nothing
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return strDatoRegresa
    End Function

    Public Sub UbicarTrabPorCodigo(ByVal codTrab As String)
        Dim trabajadorSA As New Trabajador_PLSA
        Try
            With trabajadorSA.UbicarTrabDNI(GEstableciento.IdEstablecimiento, codTrab)
                txtNombres.Text = .nombres
                txtAppat.Text = .appat
                txtApmat.Text = .apmat
                Select Case .sexo
                    Case "M"
                        rbMasculino.Checked = True
                    Case "F"
                        rbFemenino.Checked = True
                End Select
                txtIdTipoDoc.Text = .tipoDoc
                txtTipoDoc.Text = UbicarTabalDetails(2, .tipoDoc)

                txtNumDoc.Text = .codTrabajdor
                txtFechaNac.Text = .fecNacimiento

                txtIdNac.Text = .codPais
                txtNacionalidad.Text = UbicarTabalDetails(98, .codPais)

                txtIdNivel.Text = .codNivelEducativo
                txtNivelEduca.Text = UbicarTabalDetails(201, .codNivelEducativo)

                Select Case .condDomicilio
                    Case "D"
                        rbDom.Checked = True
                    Case "ND"
                        rbNoDom.Checked = True
                End Select

                Select Case .Salud
                    Case "S"
                        rbafsi.Checked = True
                    Case "N"
                        rbafno.Checked = True
                End Select
            End With
          
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Public Sub ObtenerCargosPorTrab(ByVal codTrab As String)
    '    Dim objService = HeliosSEProxy.CrearProxyHELIOS()
    '    Dim objLista() As HeliosService.trabajadorOcupacion_PLBO
    '    Try
    '        objLista = objService.GetObtenerOcupacionPorTrab(CEmpresa, CEstablecimiento, codTrab)
    '        lsvOcupacion.Items.Clear()

    '        For Each i As HeliosService.trabajadorOcupacion_PLBO In objLista
    '            Dim n As New ListViewItem(i.codOcupacion)
    '            n.SubItems.Add(i.NombreOcupacion)
    '            n.SubItems.Add("E")
    '            lsvOcupacion.Items.Add(n)
    '        Next
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Sub ComprobanteShowed()
        Me.Cursor = Cursors.WaitCursor

        Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
        datos.Clear()
        'With frmModalComprobantesTabla
        '    .lblTipo.Text = "2"
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    If datos.Count > 0 Then
        '        txtIdTipoDoc.Text = datos(0).ID
        '        txtTipoDoc.Text = datos(0).NombreCampo
        '    Else

        '        txtIdTipoDoc.Text = String.Empty
        '        txtTipoDoc.Text = String.Empty
        '        '       MsgBox("Debe ingresar un comprobante.", MsgBoxStyle.Information, "Atención!")
        '    End If
        'End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Sub NacionalidadShowed()
        Me.Cursor = Cursors.WaitCursor

        Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
        datos.Clear()
        'With frmModalComprobantesTabla
        '    .lblTipo.Text = "98"
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    If datos.Count > 0 Then
        '        txtIdNac.Text = datos(0).ID
        '        txtNacionalidad.Text = datos(0).NombreCampo
        '    Else

        '        txtIdNac.Text = String.Empty
        '        txtNacionalidad.Text = String.Empty
        '        '      MsgBox("Debe ingresar un comprobante.", MsgBoxStyle.Information, "Atención!")
        '    End If
        'End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Sub NivelEducaShowed()
        Me.Cursor = Cursors.WaitCursor

        Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
        datos.Clear()
        'With frmModalComprobantesTabla
        '    .lblTipo.Text = "201"
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    If datos.Count > 0 Then
        '        txtIdNivel.Text = datos(0).ID
        '        txtNivelEduca.Text = datos(0).NombreCampo
        '    Else

        '        txtIdNivel.Text = String.Empty
        '        txtNivelEduca.Text = String.Empty
        '        '      MsgBox("Debe ingresar un comprobante.", MsgBoxStyle.Information, "Atención!")
        '    End If
        'End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Sub OcupacionShowed()
        Me.Cursor = Cursors.WaitCursor

        Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
        datos.Clear()
        'With frmModalComprobantesTabla
        '    .lblTipo.Text = "200"
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    If datos.Count > 0 Then
        '        txtIDOcupacion.Text = datos(0).ID
        '        txtOcupacion.Text = datos(0).NombreCampo
        '    Else

        '        txtIDOcupacion.Text = String.Empty
        '        txtOcupacion.Text = String.Empty
        '        '  MsgBox("Debe ingresar un comprobante.", MsgBoxStyle.Information, "Atención!")
        '    End If
        'End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Public Sub Grabar()
        Dim TrabajadorSA As New Trabajador_PLSA
        Dim Trab As New Trabajador_PL
        'Dim objDet As New HeliosService.trabajadorOcupacion_PLBO()
        'Dim objDetalle() As HeliosService.trabajadorOcupacion_PLBO
        'Dim conteo As Integer = lsvOcupacion.Items.Count
        'conteo = conteo - 1
        'ReDim objDetalle(conteo)

        'Dim objCorreoDet As New HeliosService.CorreoEntidadesBO()
        'Dim objCorreoDetalle() As HeliosService.CorreoEntidadesBO
        'Dim conteoCorreo As Integer = lsvCorreos.Items.Count
        'conteoCorreo = conteoCorreo - 1
        'ReDim objCorreoDetalle(conteoCorreo)
        Try
            With Trab
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .codTrabajdor = txtNumDoc.Text.Trim
                .nombres = txtNombres.Text.Trim
                .appat = txtAppat.Text.Trim
                .apmat = txtApmat.Text.Trim
                .tipoDoc = txtIdTipoDoc.Text.Trim
                .fecNacimiento = txtFechaNac.Text
                .sexo = IIf(rbMasculino.Checked = True, "M", "F")
                .codPais = txtIdNac.Text.Trim
                .codNivelEducativo = txtIdNivel.Text.Trim
                .condDomicilio = IIf(rbDom.Checked = True, "D", "ND")
                .domicilio = Nothing
                .IsDiscapacidad = Nothing
                .regPensionario = Nothing
                .FecInscripcion = Nothing
                .CUSPP = Nothing
                .SCTR = Nothing
                .Salud = IIf(rbafsi.Checked = True, "S", "N")
                .Pension = Nothing
                .OtroIngresos5ta = Nothing
                .estado = "1"

            End With

            'mapeando del detalle del proyecto
            'Dim S As Integer = 0
            'For S = 0 To conteo
            '    objDet = New HeliosService.trabajadorOcupacion_PLBO()
            '    objDet.idEmpresa = CEmpresa
            '    objDet.idEstablecimiento = CEstablecimiento
            '    objDet.codTrabajdor = lsvOcupacion.Items(S).SubItems(0).Text
            '    objDet.codOcupacion = lsvOcupacion.Items(S).SubItems(0).Text
            '    objDetalle(S) = objDet
            'Next S
            'Trab.ListaOcupacion = objDetalle

            'mapeando Correos del trabajador
            'Dim x As Integer = 0
            'For x = 0 To conteoCorreo
            '    objCorreoDet = New HeliosService.CorreoEntidadesBO()
            '    objCorreoDet.codigo = 0
            '    objCorreoDet.idEmpresa = CEmpresa
            '    objCorreoDet.idEstablecimiento = CEstablecimiento
            '    objCorreoDet.idEntidad = 0
            '    objCorreoDet.tipoEntidad = "TR"
            '    objCorreoDet.Gop = "1"
            '    objCorreoDet.tipoCorreo = lsvCorreos.Items(x).SubItems(2).Text
            '    objCorreoDet.email = lsvCorreos.Items(x).SubItems(3).Text
            '    objCorreoDet.EstadoMani = lsvCorreos.Items(x).SubItems(4).Text
            '    objCorreoDet.usuarioActualizacion = cIDUsuario
            '    objCorreoDet.fechaActualizacion = Now.Date
            '    objCorreoDetalle(x) = objCorreoDet
            'Next x
            'Trab.ListaCorreos = objCorreoDetalle

            TrabajadorSA.GrabarTrabajador(Trab)
            Me.lblEstado.Image = My.Resources.ok4 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\ok.ico")
            Me.lblEstado.Text = ("Done: El trabajador se registro con exito.!")
            Timer1.Enabled = True
            TiempoEjecutar(3)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#Region "TIMER"
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If TiempoRestante > 0 Then
            lblAgregar.Visible = True
            lblMensaje.Visible = True
            '   tsSave.Enabled = False
            lblMensaje.Text = "Agregar otro en: " & TiempoRestante
            TiempoRestante = TiempoRestante - 1
        ElseIf TiempoRestante = 0 Then
            Dispose()
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
        Timer1.Interval = 1000

        Call TimerOn(1000) ' Hechanos a andar el timer
    End Function
#End Region
    Public Sub UpdateTrab()
        Dim TrabajadorSA As New Trabajador_PLSA
        Dim Trab As New Trabajador_PL
        'Dim objDet As New HeliosService.trabajadorOcupacion_PLBO()
        'Dim objDetalle() As HeliosService.trabajadorOcupacion_PLBO
        'Dim conteo As Integer = lsvOcupacion.Items.Count
        'conteo = conteo - 1
        'ReDim objDetalle(conteo)

        'Dim objCorreoDet As New HeliosService.CorreoEntidadesBO()
        'Dim objCorreoDetalle() As HeliosService.CorreoEntidadesBO
        'Dim conteoCorreo As Integer = lsvCorreos.Items.Count
        'conteoCorreo = conteoCorreo - 1
        'ReDim objCorreoDetalle(conteoCorreo)
        Try
            With Trab
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .codTrabajdor = txtNumDoc.Text.Trim
                .nombres = txtNombres.Text.Trim
                .appat = txtAppat.Text.Trim
                .apmat = txtApmat.Text.Trim
                .tipoDoc = txtIdTipoDoc.Text.Trim
                .fecNacimiento = txtFechaNac.Text
                .sexo = IIf(rbMasculino.Checked = True, "M", "F")
                .codPais = txtIdNac.Text.Trim
                .codNivelEducativo = txtIdNivel.Text.Trim
                .condDomicilio = IIf(rbDom.Checked = True, "D", "ND")
                .domicilio = Nothing
                .IsDiscapacidad = Nothing
                .regPensionario = Nothing
                .FecInscripcion = Nothing
                .CUSPP = Nothing
                .SCTR = Nothing
                .Salud = IIf(rbafsi.Checked = True, "S", "N")
                .Pension = Nothing
                .OtroIngresos5ta = Nothing
                .estado = "1"

            End With

            'mapeando del detalle del proyecto
            'Dim S As Integer = 0
            'For S = 0 To conteo
            '    objDet = New HeliosService.trabajadorOcupacion_PLBO()
            '    objDet.idEmpresa = CEmpresa
            '    objDet.idEstablecimiento = CEstablecimiento
            '    objDet.codTrabajdor = txtNumDoc.Text  ' lsvOcupacion.SelectedItems(0).SubItems(0).Text
            '    objDet.codOcupacion = lsvOcupacion.Items(S).SubItems(0).Text
            '    objDet.Estado = lsvOcupacion.Items(S).SubItems(2).Text
            '    objDetalle(S) = objDet
            'Next S
            'Trab.ListaOcupacion = objDetalle

            'mapeando Correos del trabajador
            'Dim x As Integer = 0
            'For x = 0 To conteoCorreo
            '    objCorreoDet = New HeliosService.CorreoEntidadesBO()
            '    objCorreoDet.codigo = lsvCorreos.Items(x).SubItems(0).Text
            '    objCorreoDet.idEmpresa = CEmpresa
            '    objCorreoDet.idEstablecimiento = CEstablecimiento
            '    objCorreoDet.idEntidad = txtNumDoc.Text
            '    objCorreoDet.tipoEntidad = "TR"
            '    objCorreoDet.Gop = "1"
            '    objCorreoDet.tipoCorreo = lsvCorreos.Items(x).SubItems(2).Text
            '    objCorreoDet.email = lsvCorreos.Items(x).SubItems(3).Text
            '    objCorreoDet.EstadoMani = lsvCorreos.Items(x).SubItems(4).Text
            '    objCorreoDet.usuarioActualizacion = cIDUsuario
            '    objCorreoDet.fechaActualizacion = Now.Date
            '    objCorreoDetalle(x) = objCorreoDet
            'Next x
            'Trab.ListaCorreos = objCorreoDetalle

            TrabajadorSA.UpdateTrabajador(Trab)
            Me.lblEstado.Image = My.Resources.ok4 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\ok.ico")
            Me.lblEstado.Text = ("Done: El trabajador se editó con exito.!")
            Timer1.Enabled = True
            TiempoEjecutar(3)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

#Region "Arbol"
    Dim newNodeUsuario As TreeNode = New TreeNode("Usuario: " & "")
    Dim newNodeTrab As TreeNode = New TreeNode("Datos Generales")
    Dim newNodeOcupacion As TreeNode = New TreeNode("Ocupación")
    ' Dim newNodeCosto As TreeNode = New TreeNode("Datos Centro de Costo")
    Dim newNodeDerechoHabientes As TreeNode = New TreeNode("Derecho Habientes")
    Dim newNodeCorreos As TreeNode = New TreeNode("Correos")
    ' Dim newNodeDetalle As TreeNode = New TreeNode("Detalle de la compra")
    Private Sub LoadTree()
        ' TODO: Agregar código a elementos en la vista de árbol
        With tvDatos
            '  Dim newNodeUsuario As TreeNode = New TreeNode("Usuario: " & cIDUsuario)
            tvDatos.Nodes.Add(newNodeUsuario)

            '  Dim newNodeComprobante As TreeNode = New TreeNode("Comprobante compra")
            newNodeTrab.Tag = "IF"
            tvDatos.Nodes.Add(newNodeTrab)


      
            'newNodeCorreos.Tag = "MAIL"
            'tvDatos.Nodes.Add(newNodeCorreos)
         
        End With
    End Sub
#End Region

#Region "Correos: Manipulacion"
    'Public Sub ObtenerCorreosPorTrab(ByVal codTrab As String)
    '    Dim objService = HeliosSEProxy.CrearProxyHELIOS()
    '    Dim objLista() As HeliosService.CorreoEntidadesBO
    '    Try
    '        objLista = objService.ObtenerCorreos(CEmpresa, CEstablecimiento, "TR", codTrab)
    '        lsvCorreos.Items.Clear()
    '        For Each i As HeliosService.CorreoEntidadesBO In objLista
    '            Dim n As New ListViewItem(i.codigo)
    '            n.SubItems.Add(i.idEntidad)
    '            n.SubItems.Add(i.tipoCorreo)
    '            n.SubItems.Add(i.email)
    '            n.SubItems.Add(Manipulacion.Editar)
    '            lsvCorreos.Items.Add(n)
    '        Next
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub
    'Public Sub GrabarCorreo()
    '    Dim objService = HeliosSEProxy.CrearProxyHELIOS()
    '    Dim objCorreoEO As New HeliosService.CorreoEntidadesEO()
    '    Try
    '        With objCorreoEO
    '            .codigo = ""
    '            .idEmpresa = CEmpresa
    '            .idEstablecimiento = CEstablecimiento
    '            .idEntidad = ""
    '            .
    '        End With
    '    Catch ex As Exception

    '    End Try
    'End Sub
#End Region

    Private Sub TabPage1_Click(sender As System.Object, e As System.EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub frmTrabajadorForm_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Me.lblEstablecimiento.Text = GEstableciento.NombreEstablecimiento
        LoadTree()
        TabPage1.Parent = Nothing
        TabPage2.Parent = Nothing
        TabPage3.Parent = Nothing
        TabPage4.Parent = Nothing
        tvDatos.SelectedNode = newNodeTrab
        txtNumDoc.Select()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub tvDatos_AfterSelect(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles tvDatos.AfterSelect
        Me.Cursor = Cursors.WaitCursor
        Select Case tvDatos.SelectedNode.Tag
            Case "IF"
                TabPage1.Parent = TabTrab
                TabPage2.Parent = Nothing
                TabPage3.Parent = Nothing
                TabPage4.Parent = Nothing

                txtNumDoc.Select()
                txtNumDoc.Focus()
            Case "DP"
                TabPage2.Parent = TabTrab

                TabPage1.Parent = Nothing
                '
                TabPage3.Parent = Nothing
                TabPage4.Parent = Nothing
                'cboProveedor.Select()
                'cboProveedor.Focus()
            Case "DC"
                '       TabPage3.Parent = TabCompra

                'TabPage1.Parent = Nothing
                'TabPage2.Parent = Nothing
                'TabPage4.Parent = Nothing
                'TabPage5.Parent = Nothing

                ''cboEstableCosto.Focus()
                ''cboEstableCosto.Select()
            Case "IP"
                TabPage3.Parent = TabTrab

                TabPage1.Parent = Nothing
                TabPage2.Parent = Nothing
                TabPage4.Parent = Nothing

                'txtFechaPago.Select()
                'txtFechaPago.Focus()
            Case "MAIL"
                TabPage3.Parent = Nothing

                TabPage1.Parent = Nothing
                TabPage2.Parent = Nothing
                TabPage4.Parent = TabTrab
        End Select
        Me.Cursor = Cursors.Arrow
    End Sub


    Private Sub LinkTipoDoc_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkTipoDoc.LinkClicked
        Call ComprobanteShowed()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Call NacionalidadShowed()
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Call OcupacionShowed()
    End Sub

    Private Sub btnAddCargo_Click(sender As System.Object, e As System.EventArgs) Handles btnAddCargo.Click


    End Sub

    Private Sub ImprimirToolStripButton_Click(sender As System.Object, e As System.EventArgs)
        Dispose()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Call NivelEducaShowed()
    End Sub

    Private Sub txtNombres_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNombres.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtAppat.Focus()
            txtAppat.Select(0, txtAppat.Text.Length)
        End If
    End Sub

    Private Sub txtNombres_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNombres.TextChanged

    End Sub

    Private Sub txtNombres_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtNombres.Validating
        If Me.txtNombres.Text.Trim.Length = 0 Then
            'Me.lblEstado.Image = Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
            Me.lblEstado.Image = My.Resources.warning2
            Me.lblEstado.Text = "Indique el nombre del trabajador!"
            ErrorProvider1.SetError(Me.txtNombres, "Indique el nombre del trabajador!")
            txtNombres.Select(0, txtNombres.Text.Length)
            e.Cancel = True
        Else
            ErrorProvider1.SetError(Me.txtNombres, "")
            '  Me.lblEstado.Image = Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\ok.ico")
            Me.lblEstado.Image = My.Resources.ok4
            Me.lblEstado.Text = "Done!: Nombre trabajador." ' String.Empty
        End If
    End Sub

    Private Sub txtAppat_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtAppat.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtApmat.Focus()
            txtApmat.Select(0, txtApmat.Text.Length)
        End If
    End Sub

    Private Sub txtAppat_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtAppat.TextChanged

    End Sub

    Private Sub txtAppat_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtAppat.Validating
        If Me.txtAppat.Text.Trim.Length = 0 Then
            'Me.lblEstado.Image = Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
            Me.lblEstado.Image = My.Resources.warning2
            Me.lblEstado.Text = "Indique el A. Paterno del trabajador!"
            ErrorProvider1.SetError(Me.txtAppat, "Indique el A. Paterno del trabajador!")
            txtAppat.Select(0, txtAppat.Text.Length)
            e.Cancel = True
        Else
            ErrorProvider1.SetError(Me.txtAppat, "")
            '  Me.lblEstado.Image = Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\ok.ico")
            Me.lblEstado.Image = My.Resources.ok4
            Me.lblEstado.Text = "Done!: A. Paterno trabajador." ' String.Empty
        End If
    End Sub

    Private Sub txtApmat_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtApmat.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If Not txtTipoDoc.Text.Trim.Length > 0 Then
                Call ComprobanteShowed()
            Else
                txtNumDoc.Focus()
                txtNumDoc.Select(0, txtNumDoc.Text.Length)
            End If
        End If
    End Sub

    Private Sub txtApmat_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtApmat.Validating
        If Me.txtApmat.Text.Trim.Length = 0 Then
            'Me.lblEstado.Image = Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
            Me.lblEstado.Image = My.Resources.warning2
            Me.lblEstado.Text = "Indique el A. Materno del trabajador!"
            ErrorProvider1.SetError(Me.txtApmat, "Indique el A. Materno del trabajador!")
            txtApmat.Select(0, txtApmat.Text.Length)
            e.Cancel = True
        Else
            ErrorProvider1.SetError(Me.txtApmat, "")
            '  Me.lblEstado.Image = Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\ok.ico")
            Me.lblEstado.Image = My.Resources.ok4
            Me.lblEstado.Text = "Done!: A. Materno trabajador." ' String.Empty
        End If
    End Sub

    Private Sub txtNumDoc_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNumDoc.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            '    ObtenerTrabPorDoc(txtNumDoc.Text.Trim)
            '   txtFechaNac.Select()
        End If
    End Sub

    Private Sub txtNumDoc_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtNumDoc.Validating
        If Me.txtNumDoc.Text.Trim.Length = 0 Then
            'Me.lblEstado.Image = Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
            Me.lblEstado.Image = My.Resources.warning2
            Me.lblEstado.Text = "Indique el Nro.Doc del trabajador!"
            ErrorProvider1.SetError(Me.txtNumDoc, "Indique el Nro.Doc del trabajador!")
            txtNumDoc.Select(0, txtNumDoc.Text.Length)
            e.Cancel = True
        Else
            ErrorProvider1.SetError(Me.txtNumDoc, "")
            '  Me.lblEstado.Image = Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\ok.ico")
            Me.lblEstado.Image = My.Resources.ok4
            Me.lblEstado.Text = "Done!: Nro. Doc trabajador." ' String.Empty
        End If
    End Sub

    Private Sub txtNumDoc_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNumDoc.TextChanged

    End Sub

    Private Sub txtFechaNac_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtFechaNac.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            If txtNacionalidad.Text.Trim.Length > 0 Then
                txtNacionalidad.Focus()
                txtNacionalidad.Select(0, txtNacionalidad.Text.Length)
            Else
                Call NacionalidadShowed()
            End If

        End If
    End Sub

    Private Sub txtFechaNac_ValueChanged(sender As System.Object, e As System.EventArgs) Handles txtFechaNac.ValueChanged

    End Sub

    Private Sub txtNacionalidad_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNacionalidad.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            If txtNivelEduca.Text.Trim.Length > 0 Then
                txtNivelEduca.Focus()
                txtNivelEduca.Select(0, txtNivelEduca.Text.Length)
            Else
                Call NivelEducaShowed()
            End If

        End If
    End Sub

    Private Sub txtNacionalidad_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNacionalidad.TextChanged

    End Sub

    Private Sub txtNacionalidad_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtNacionalidad.Validating
        If Me.txtNacionalidad.Text.Trim.Length = 0 Then
            'Me.lblEstado.Image = Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
            Me.lblEstado.Image = My.Resources.warning2
            Me.lblEstado.Text = "Indique la nacionalidad del trabajador!"
            ErrorProvider1.SetError(Me.txtNacionalidad, "Indique la nacionalidad del trabajador!")
            txtNacionalidad.Select(0, txtNacionalidad.Text.Length)
            e.Cancel = True
        Else
            ErrorProvider1.SetError(Me.txtNacionalidad, "")
            '  Me.lblEstado.Image = Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\ok.ico")
            Me.lblEstado.Image = My.Resources.ok4
            Me.lblEstado.Text = "Done!: Nacionalidad trabajador." ' String.Empty
        End If
    End Sub

    Private Sub txtNivelEduca_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNivelEduca.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            tvDatos.SelectedNode = newNodeOcupacion
        End If
    End Sub

    Private Sub txtNivelEduca_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNivelEduca.TextChanged

    End Sub

    Private Sub ToolStripButton3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton3.Click
        If txtOcupacion.Text.Trim.Length > 0 Then
            Dim n As New ListViewItem(txtIDOcupacion.Text)
            n.SubItems.Add(txtOcupacion.Text)
            n.SubItems.Add("N")
            lsvOcupacion.Items.Add(n)
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        Me.Cursor = Cursors.WaitCursor
        If lsvOcupacion.SelectedItems.Count > 0 Then
            If lsvOcupacion.SelectedItems(0).SubItems(2).Text = "N" Then
                '  EliminarCargo(2)
            Else
                '      EliminarCargo(1)
                '     ObtenerCargosPorTrab(txtNumDoc.Text.Trim)
            End If
            Me.lblEstado.Text = ("Done: El cargo se elimino con exito.!")
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Call TrabajadoresShow()
    End Sub

    Sub TrabajadoresShow()
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        With frmPersonalExistente
            ' .LimpiarCajas(gbx1)
            .NuevoToolStripButton.Enabled = False
            .ImprimirToolStripButton.Enabled = True
            .xManipulacion = ENTITY_ACTIONS.INSERT
            .gbx1.Enabled = True
            .lblEstado.Image = My.Resources.ok4
            .lblEstado.Text = "Trabajador: Ingreso interactivo."
            .txtNumDoc.Enabled = True
            .txtNombres.Select()
            .txtNombres.Focus()
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            If datos.Count > 0 Then
                txtNumDoc.Text = datos(0).ID
                txtNombres.Text = datos(0).NombreEntidad
                txtAppat.Text = datos(0).Appat
                txtApmat.Text = datos(0).Apmat

            Else
                txtNumDoc.Text = String.Empty
                txtNombres.Text = String.Empty
                txtAppat.Text = String.Empty
                txtApmat.Text = String.Empty

            End If
        End With

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtTipoDoc_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTipoDoc.TextChanged

    End Sub
    Public Function ItemList() As ListViewItem
        Dim rbControl As New CheckBox
        rbControl.Checked = True
        Dim n As New ListViewItem(0)
        n.SubItems.Add(txtNumDoc.Text)
        'Select Case rbControl.Checked
        '    Case rbHotmail.Checked
        '        n.SubItems.Add("H")
        '    Case rbGmail.Checked
        '        n.SubItems.Add("G")
        '    Case rbYahoo.Checked
        '        n.SubItems.Add("Y")
        '    Case rbOut.Checked
        '        n.SubItems.Add("O")
        'End Select
  
        If txtMail.Text.Contains("@hotmail.com") Then
            n.SubItems.Add("H")
        End If
        If txtMail.Text.Contains("@gmail.com") Then
            n.SubItems.Add("G")
        End If
        If txtMail.Text.Contains("@yahoo.es") Then
            n.SubItems.Add("Y")
        End If

        n.SubItems.Add(txtMail.Text.Trim)
        '  n.SubItems.Add(Manipulacion.Nuevo)
        Return n
    End Function
  
    Private Sub GuardarToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton1.Click
        Dim sMail As String = txtMail.Text

        '    sMail = InputBox("Escribir una dirección de email", "validación")

        If Len(sMail) > 0 Then
            '  MsgBox(validar_Mail(sMail), MsgBoxStyle.Information)
            Select Case validar_Mail(sMail)
                Case True
                    lsvCorreos.Items.Add(ItemList)
                    txtMail.Clear()
                Case False
                    MsgBox("Ingrese un email correcto", MsgBoxStyle.Exclamation, "Atención")
            End Select
        

        End If
    End Sub

    Private Sub ImprimirToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ImprimirToolStripButton1.Click
        Me.Cursor = Cursors.WaitCursor
        If lsvCorreos.SelectedItems.Count > 0 Then
            If lsvCorreos.SelectedItems(0).SubItems(4).Text = ENTITY_ACTIONS.INSERT Then
                '      EliminarCorreo(2)
            Else
                '     EliminarCorreo(1)
                '     ObtenerCorreosPorTrab(txtNumDoc.Text.Trim)
            End If
            Me.lblEstado.Text = ("Done: El email se elimino con exito.!")
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtMail_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtMail.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            GuardarToolStripButton1_Click(sender, e)
        End If
    End Sub

    Private Sub txtMail_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtMail.TextChanged

    End Sub

    Private Sub ToolStripButton5_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton5.Click
        Dispose()
    End Sub

    Private Sub ToolStripButton4_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton4.Click
        Me.Cursor = Cursors.WaitCursor

        Dim validadoGeneral As Boolean = ValidarCajas(gbxTrab)


        If validadoGeneral = True Then
            Me.lblEstado.Image = My.Resources.ok4 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\ok.ico")
            Me.lblEstado.Text = "Done Datos Generales!"
        Else
            Me.lblEstado.Image = My.Resources.cross 'Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\cross.png")
            Me.lblEstado.Text = "Complete todos los campos: Datos del trabajador!"
            tvDatos.SelectedNode = newNodeTrab
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        'If Not lsvCorreos.Items.Count > 0 Then
        '    Me.lblEstado.Image = My.Resources.cross 'Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\cross.png")
        '    Me.lblEstado.Text = "Ingrese al menos un email del trabajador!"
        '    tvDatos.SelectedNode = newNodeTrab
        '    Me.Cursor = Cursors.Arrow
        '    Exit Sub
        'Else
        '    Me.lblEstado.Image = My.Resources.ok ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\ok.ico")
        '    Me.lblEstado.Text = "Done Datos Generales!"
        'End If

        If xManipulacion = ENTITY_ACTIONS.INSERT Then
            Grabar()
        ElseIf xManipulacion = ENTITY_ACTIONS.UPDATE Then
            UpdateTrab()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub AyudaToolStripButton_Click(sender As System.Object, e As System.EventArgs)

    End Sub
End Class