Imports System.Text.RegularExpressions
Imports Helios.Cont.Business.Entity
Imports Helios.General

Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmDetalleCliente
    Inherits frmMaster
    Public xtipoEntidad As String


    Public Manipulacionx As String
#Region "Correos: Manipulacion"
    'Public Sub ObtenerCorreosPorTrab(ByVal codTrab As String)
    '    Dim objService = HeliosSEProxy.CrearProxyHELIOS()
    '    Dim objLista() As HeliosService.CorreoEntidadesBO
    '    Try
    '        objLista = objService.ObtenerCorreos(CEmpresa, CEstablecimiento, "PR", codTrab)
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

#Region "métodos"
    Private Function validar_Mail(ByVal sMail As String) As Boolean
        ' retorna true o false   
        Return Regex.IsMatch(sMail, _
                "^([\w-]+\.)*?[\w-]+@[\w-]+\.([\w-]+\.)*?[\w]+$")
    End Function
    Public Sub Save()

        Dim objCliente As New entidad
        Dim entidadSA As New entidadSA
        'Dim objCorreoDet As New HeliosService.CorreoEntidadesBO()
        'Dim objCorreoDetalle() As HeliosService.CorreoEntidadesBO
        'Dim conteoCorreo As Integer = lsvCorreos.Items.Count
        'conteoCorreo = conteoCorreo - 1
        'ReDim objCorreoDetalle(conteoCorreo)
        Try
            'Se asigna cada uno de los datos registrados
            objCliente.idEmpresa = Gempresas.IdEmpresaRuc

            If xtipoEntidad = TIPO_ENTIDAD.PROVEEDOR Then
                objCliente.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
            ElseIf xtipoEntidad = TIPO_ENTIDAD.CLIENTE Then
                objCliente.tipoEntidad = TIPO_ENTIDAD.CLIENTE
            ElseIf xtipoEntidad = TIPO_ENTIDAD.OTRO_PROVEEDOR Then
                objCliente.tipoEntidad = TIPO_ENTIDAD.OTRO_PROVEEDOR
            ElseIf xtipoEntidad = TIPO_ENTIDAD.OTRO_CLIENTE Then
                objCliente.tipoEntidad = TIPO_ENTIDAD.OTRO_CLIENTE
            End If
            If txtCodDocumento.Text = "" Or String.IsNullOrEmpty(txtCodDocumento.Text) Then
                ' MsgBox("Indique Tipo Documento de Identidad", MsgBoxStyle.Information)
                lblEstado.Text = "Indique Tipo Documento de Identidad"
                lblEstado.Image = My.Resources.warning2
                cboDocumento.Focus()
                Exit Sub
            Else
                objCliente.tipoDoc = txtCodDocumento.Text.Trim
            End If

            If txtNumDoc.Text = "" Or String.IsNullOrEmpty(txtNumDoc.Text) Then
                'MsgBox("Indique Nro. del Documento", MsgBoxStyle.Information)
                lblEstado.Text = "Indique Nro. del Documento"
                lblEstado.Image = My.Resources.warning2
                txtNumDoc.Focus()
                txtNumDoc.Select(0, txtNumDoc.Text.Length)
                Exit Sub
            Else
                objCliente.nrodoc = txtNumDoc.Text.Trim
            End If

            If cboTipoPersona.SelectedIndex > -1 Then
                If cboTipoPersona.Text = "01 NATURAL" Then
                    objCliente.tipoPersona = "N"
                    If txtAppat.Text = "" Or String.IsNullOrEmpty(txtAppat.Text) Then
                        ' MsgBox("Ingrese Apellido paterno.!", MsgBoxStyle.Information)
                        lblEstado.Text = "Ingrese Apellido paterno.!"
                        lblEstado.Image = My.Resources.warning2
                        txtAppat.Focus()
                        txtAppat.Select(0, txtAppat.Text.Length)
                        Exit Sub
                    Else
                        objCliente.appat = txtAppat.Text.Trim
                    End If
                    If txtApmat.Text = "" Or String.IsNullOrEmpty(txtApmat.Text) Then
                        '   MsgBox("Ingrese Apellido materno.!", MsgBoxStyle.Information)
                        lblEstado.Text = "Ingrese Apellido materno.!"
                        lblEstado.Image = My.Resources.warning2
                        txtApmat.Focus()
                        txtApmat.Select(0, txtApmat.Text.Length)
                        Exit Sub
                    Else
                        objCliente.apmat = txtApmat.Text.Trim
                    End If

                    If txtNombre1.Text = "" Or String.IsNullOrEmpty(txtNombre1.Text) Then
                        '  MsgBox("Ingrese Nombre.!", MsgBoxStyle.Information)
                        lblEstado.Text = "Ingrese Nombres.!"
                        lblEstado.Image = My.Resources.warning2
                        txtNombre1.Focus()
                        txtNombre1.Select(0, txtNombre1.Text.Length)
                        Exit Sub
                    Else
                        objCliente.nombre1 = txtNombre1.Text.Trim
                    End If
                    objCliente.nombre2 = IIf(txtNombre2.Text = "" Or String.IsNullOrEmpty(txtNombre2.Text), Nothing, txtNombre2.Text.Trim)
                    objCliente.nombreCompleto = String.Concat(txtAppat.Text.Trim, Space(1), txtApmat.Text.Trim, Space(1), txtNombre1.Text.Trim, Space(1), txtNombre2.Text.Trim)
                Else
                    objCliente.tipoPersona = "J"
                    If txtRazon.Text = "" Or String.IsNullOrEmpty(txtRazon.Text) Then
                        '  MsgBox("Ingrese Razón Social.!", MsgBoxStyle.Information)
                        lblEstado.Text = "Ingrese Razón Social.!"
                        lblEstado.Image = My.Resources.warning2
                        txtRazon.Focus()
                        txtRazon.Select(0, txtRazon.Text.Length)
                        Exit Sub
                    Else
                        objCliente.nombre = txtRazon.Text.Trim
                    End If
                    objCliente.nombreCompleto = txtRazon.Text.Trim
                End If
            Else
                '   MsgBox("Seleccione Tipo de Persona[N:J]", MsgBoxStyle.Information)
                lblEstado.Text = "Seleccione Tipo de Persona[N:J]"
                lblEstado.Image = My.Resources.warning2
                cboTipoPersona.Focus()
                Exit Sub
            End If
            If String.IsNullOrEmpty(txtCuenta.Text) Then
                '   MsgBox("Indique la cuenta contable de la entidad.", MsgBoxStyle.Information, "Aviso del sistema")
                lblEstado.Text = "Indique la cuenta contable de la entidad."
                lblEstado.Image = My.Resources.warning2
                cboCuenta.Focus()
                cboCuenta.DroppedDown = True
                Exit Sub
            End If

            objCliente.direccion = IIf(txtDir.Text = "" Or String.IsNullOrEmpty(txtDir.Text), Nothing, txtDir.Text.Trim)
            objCliente.telefono = IIf(txtFono.Text = "" Or String.IsNullOrEmpty(txtFono.Text), Nothing, txtFono.Text.Trim)
            objCliente.celular = IIf(txtcelular.Text = "" Or String.IsNullOrEmpty(txtcelular.Text), Nothing, txtcelular.Text.Trim)
            objCliente.nextel = IIf(txtnextel.Text = "" Or String.IsNullOrEmpty(txtnextel.Text), Nothing, txtnextel.Text.Trim)
            objCliente.email = IIf(txtMail.Text = "" Or String.IsNullOrEmpty(txtMail.Text), Nothing, txtMail.Text.Trim)
            If chActivo.Checked = True Then
                objCliente.estado = "A"
            Else
                objCliente.estado = "I"
            End If
            objCliente.cuentaAsiento = cboCuenta.Text
            objCliente.usuarioModificacion = "NN"
            objCliente.fechaModificacion = DateTime.Now

            'mapeando Correos del trabajador
            Dim x As Integer = 0
            'For x = 0 To conteoCorreo
            '    objCorreoDet = New HeliosService.CorreoEntidadesBO()
            '    objCorreoDet.codigo = 0
            '    objCorreoDet.idEmpresa = CEmpresa
            '    objCorreoDet.idEstablecimiento = CEstablecimiento
            '    objCorreoDet.idEntidad = 0
            '    objCorreoDet.tipoEntidad = "PR"
            '    objCorreoDet.Gop = "2"
            '    objCorreoDet.tipoCorreo = lsvCorreos.Items(x).SubItems(2).Text
            '    objCorreoDet.email = lsvCorreos.Items(x).SubItems(3).Text
            '    objCorreoDet.EstadoMani = lsvCorreos.Items(x).SubItems(4).Text
            '    objCorreoDet.usuarioActualizacion = cIDUsuario
            '    objCorreoDet.fechaActualizacion = Now.Date
            '    objCorreoDetalle(x) = objCorreoDet
            'Next x
            'objCliente.ListaCorreos = objCorreoDetalle
            'Se envía la información al servicio
            entidadSA.GrabarEntidad(objCliente)
            lblEstado.Text = "Entidad registrada:" & vbCrLf & "Tipo: " & objCliente.tipoEntidad & vbCrLf & "Nombre: " & objCliente.nombreCompleto
            lblEstado.Image = My.Resources.ok4
            frmModalEntidades.txtBusqueda.Text = txtNumDoc.Text.Trim
            Dispose()

            '      MsgBox("La entidad ya se ecuentra en BD.!!", MsgBoxStyle.Critical, "Aviso del Sistema.")


            'Limpiar_Cajas(TabPage1)
        Catch ex As Exception
            'Manejo de errores
            MsgBox("No se pudo grabar el cliente." & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Sub ObtenerCuentas()
        Dim objCuentas As New List(Of cuentaplanContableEmpresa)
        Dim cuentaSA As New cuentaplanContableEmpresaSA
        Dim dtCuentas As New DataTable()
        Try
            objCuentas = cuentaSA.ObtenerCuentasConf(Gempresas.IdEmpresaRuc, rb42.Text)
            dtCuentas.Columns.Add("cuenta", GetType([String]))
            dtCuentas.Columns.Add("Descripcion", GetType([String]))

            For Each x As cuentaplanContableEmpresa In objCuentas
                dtCuentas.Rows.Add(x.cuenta,
                              x.descripcion)
            Next x
            cboCuenta.DataSource = dtCuentas
            cboCuenta.DisplayMember = "cuenta"
            cboCuenta.ValueMember = "cuenta"
            cboCuenta.Text = ""
            txtCuenta.Text = ""

            Select Case rb42.Text
                Case "12"
                    cboCuenta.Text = "1213"
                Case "42"
                    cboCuenta.Text = "4212"
            End Select
        Catch ex As Exception
            MsgBox("Error al cargar combos." & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Sub ObtenerCuentas43()
        Dim objCuentas As New List(Of cuentaplanContableEmpresa)
        Dim cuentaSA As New cuentaplanContableEmpresaSA
        Dim dtCuentas As New DataTable()
        Try
            objCuentas = cuentaSA.ObtenerCuentasConf(Gempresas.IdEmpresaRuc, rb43.Text)
            dtCuentas.Columns.Add("cuenta", GetType([String]))
            dtCuentas.Columns.Add("Descripcion", GetType([String]))

            For Each x As cuentaplanContableEmpresa In objCuentas
                dtCuentas.Rows.Add(x.cuenta,
                              x.descripcion)
            Next x
            cboCuenta.DataSource = dtCuentas
            cboCuenta.DisplayMember = "cuenta"
            cboCuenta.ValueMember = "cuenta"
            cboCuenta.Text = ""
            txtCuenta.Text = ""
        Catch ex As Exception
            MsgBox("Error al cargar combos." & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Sub ObtenerCuentasAll()
        Dim objCuentas As New List(Of cuentaplanContableEmpresa)
        Dim cuentaSA As New cuentaplanContableEmpresaSA
        Dim dtCuentas As New DataTable()
        Try
            objCuentas = cuentaSA.ObtenerCuentasPorEmpresa(Gempresas.IdEmpresaRuc)
            dtCuentas.Columns.Add("cuenta", GetType([String]))
            dtCuentas.Columns.Add("Descripcion", GetType([String]))

            For Each x As cuentaplanContableEmpresa In objCuentas
                dtCuentas.Rows.Add(x.cuenta,
                              x.descripcion)
            Next x
            cboCuenta.DataSource = dtCuentas
            cboCuenta.DisplayMember = "cuenta"
            cboCuenta.ValueMember = "cuenta"
            cboCuenta.Text = ""
            txtCuenta.Text = ""
        Catch ex As Exception
            MsgBox("Error al cargar combos." & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Sub CargarCombos()
        Dim tablaSA As New tablaDetalleSA
        Dim objList As New List(Of tabladetalle)
        Dim DT As New DataTable()
        Try
            objList = tablaSA.GetListaTablaDetalle(2, "1")
            DT.Columns.Add("codigoDetalle", GetType([String]))
            DT.Columns.Add("Descripcion", GetType([String]))
            For x = 0 To objList.Count - 1
                DT.Rows.Add(objList(x).codigoDetalle, objList(x).descripcion)
            Next
            cboDocumento.DataSource = DT
            cboDocumento.DisplayMember = "Descripcion"
            cboDocumento.ValueMember = "CodigoDetalle"
            cboDocumento.SelectedIndex = -1
            cboDocumento.Text = ""

            ' objCuentas = objService.GetListaCuentaPC("10")

        Catch ex As Exception
            MsgBox("No se pudo cargar la información para los combos." & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Sub UpdateEntidad()
        Dim objCliente As New entidad
        Dim entidadSA As New entidadSA
        'Dim objCorreoDet As New HeliosService.CorreoEntidadesBO()
        'Dim objCorreoDetalle() As HeliosService.CorreoEntidadesBO
        'Dim conteoCorreo As Integer = lsvCorreos.Items.Count
        'conteoCorreo = conteoCorreo - 1
        'ReDim objCorreoDetalle(conteoCorreo)
        Try
            'Se asigna cada uno de los datos registrados
            objCliente.idEntidad = txtCodigoCliente.Text.Trim
            objCliente.tipoEntidad = IIf(xtipoEntidad = TIPO_ENTIDAD.PROVEEDOR, TIPO_ENTIDAD.PROVEEDOR, TIPO_ENTIDAD.CLIENTE)
            objCliente.idEmpresa = Gempresas.IdEmpresaRuc
            objCliente.tipoDoc = cboDocumento.SelectedValue
            objCliente.nrodoc = txtNumDoc.Text.Trim
            If cboTipoPersona.Text = "01 NATURAL" Then
                objCliente.tipoPersona = "N"
                objCliente.appat = txtAppat.Text.Trim
                objCliente.apmat = txtApmat.Text.Trim
                objCliente.nombre1 = txtNombre1.Text.Trim
                objCliente.nombre2 = IIf(txtNombre2.Text.Trim.Length > 0, txtNombre2.Text.Trim, Nothing)
                objCliente.nombreCompleto = String.Concat(txtAppat.Text.Trim, Space(1), txtApmat.Text.Trim, Space(1), txtNombre1.Text.Trim, Space(1), txtNombre2.Text.Trim)
            Else
                objCliente.tipoPersona = "J"
                objCliente.nombre = txtRazon.Text.Trim
                objCliente.nombreCompleto = txtRazon.Text.Trim
            End If
            objCliente.direccion = IIf(txtDir.Text = "" Or String.IsNullOrEmpty(txtDir.Text), Nothing, txtDir.Text.Trim)
            objCliente.telefono = IIf(txtFono.Text = "" Or String.IsNullOrEmpty(txtFono.Text), Nothing, txtFono.Text.Trim)
            objCliente.celular = IIf(txtcelular.Text = "" Or String.IsNullOrEmpty(txtcelular.Text), Nothing, txtcelular.Text.Trim)
            objCliente.nextel = IIf(txtnextel.Text = "" Or String.IsNullOrEmpty(txtnextel.Text), Nothing, txtnextel.Text.Trim)
            objCliente.email = IIf(txtMail.Text = "" Or String.IsNullOrEmpty(txtMail.Text), Nothing, txtMail.Text.Trim)
            If chActivo.Checked = True Then
                objCliente.estado = "A"
            Else
                objCliente.estado = "I"
            End If
            objCliente.cuentaAsiento = cboCuenta.Text
            objCliente.usuarioModificacion = "NN"
            objCliente.fechaModificacion = DateTime.Now

            'mapeando Correos del trabajador
            'Dim x As Integer = 0
            'For x = 0 To conteoCorreo
            '    objCorreoDet = New HeliosService.CorreoEntidadesBO()
            '    objCorreoDet.codigo = lsvCorreos.Items(x).SubItems(0).Text
            '    objCorreoDet.idEmpresa = CEmpresa
            '    objCorreoDet.idEstablecimiento = CEstablecimiento
            '    objCorreoDet.idEntidad = txtCodigoCliente.Text.Trim
            '    objCorreoDet.tipoEntidad = "PR"
            '    objCorreoDet.Gop = "2"
            '    objCorreoDet.tipoCorreo = lsvCorreos.Items(x).SubItems(2).Text
            '    objCorreoDet.email = lsvCorreos.Items(x).SubItems(3).Text
            '    objCorreoDet.EstadoMani = lsvCorreos.Items(x).SubItems(4).Text
            '    objCorreoDet.usuarioActualizacion = cIDUsuario
            '    objCorreoDet.fechaActualizacion = Now.Date
            '    objCorreoDetalle(x) = objCorreoDet
            'Next x
            'objCliente.ListaCorreos = objCorreoDetalle

            'Se envía la información al servicio
            entidadSA.UpdateEntidad(objCliente)
            '   frmModalEntidades.txtBusqueda.Text = txtNumDoc.Text.Trim
            lblEstado.Text = "Entidad modificada:" & vbCrLf & "Tipo: " & objCliente.tipoEntidad & vbCrLf & "Nombre: " & objCliente.nombreCompleto
            lblEstado.Image = My.Resources.ok4
            Dispose()

        Catch ex As Exception
            'Manejo de errores
            MsgBox("No se pudo grabar el cliente." & vbCrLf & ex.Message)
        End Try
    End Sub
#End Region

#Region "UbicarEntidad"
    Public Sub UbicarEntidad(intIdEntidad As Integer)
        Dim entidadSA As New entidadSA
        Dim objLista As New List(Of entidad)
        Try
            objLista = entidadSA.UbicarEntidadPorID(intIdEntidad)
            txtCodigoCliente.Text = objLista(0).idEntidad
            txtSiglas.Text = objLista(0).tipoEntidad
            cboDocumento.SelectedValue = objLista(0).tipoDoc
            If objLista(0).tipoPersona = "N" Then
                cboTipoPersona.Text = "01 NATURAL"
                txtAppat.Text = objLista(0).appat
                txtApmat.Text = objLista(0).apmat
                txtNombre1.Text = objLista(0).nombre1
                txtNombre2.Text = objLista(0).nombre2
            Else
                cboTipoPersona.Text = "02 JURIDICO"
                txtRazon.Text = objLista(0).nombre
            End If
            txtNumDoc.Text = objLista(0).nrodoc
            txtDir.Text = objLista(0).direccion
            txtFono.Text = objLista(0).telefono
            txtcelular.Text = objLista(0).celular
            txtnextel.Text = objLista(0).nextel
            txtMail.Text = objLista(0).email

            If (xtipoEntidad = TIPO_ENTIDAD.PROVEEDOR) Then
                If objLista(0).cuentaAsiento.StartsWith("42") Then
                    rb42.Checked = True
                    cboCuenta.Text = objLista(0).cuentaAsiento
                Else
                    rb43.Checked = True
                    cboCuenta.Text = objLista(0).cuentaAsiento
                End If
            Else
                If objLista(0).cuentaAsiento.StartsWith("12") Then
                    rb42.Checked = True
                    cboCuenta.Text = objLista(0).cuentaAsiento
                Else
                    rb43.Checked = True
                    cboCuenta.Text = objLista(0).cuentaAsiento
                End If
            End If

        Catch ex As Exception
            MsgBox("Error al encontrar entidad." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema!")
        End Try
    End Sub
#End Region

#Region "Clases"

    '    Protected Overrides Function ProcessDialogKey( _
    'ByVal keyData As System.Windows.Forms.Keys) As Boolean

    '        If keyData <> Keys.Tab Then
    '            Return MyBase.ProcessDialogKey(keyData)
    '        End If


    '    End Function

    Private Sub Limpiar_Cajas(ByVal f As TabPage)
        ' recorrer todos los controles del formulario indicado  
        For Each c As Control In f.Controls
            If TypeOf c Is TextBox Then
                c.Text = "" ' eliminar el texto  
            End If
            If TypeOf c Is ComboBox Then
                c.Text = "" ' eliminar el texto  
            End If
        Next
    End Sub

#End Region

    Private Sub frmDetalleCliente_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmDetalleCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cboDocumento_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDocumento.Enter
        txtCodDocumento.BackColor = Color.LavenderBlush
    End Sub

    Private Sub cboDocumento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboDocumento.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.Chr(13) Or e.KeyChar = Microsoft.VisualBasic.Chr(9) Then
            e.Handled = True
            cboTipoPersona.Focus()
            cboTipoPersona.DroppedDown = True
            'If cboTipoPersona.Text = "01 NATURAL" Then
            '    txtAppat.Focus()
            '    txtAppat.Select(0, txtAppat.Text.Length)
            'Else
            '    txtRazon.Focus()
            '    txtRazon.Select(0, txtAppat.Text.Length)
            'End If
        End If
    End Sub

    Private Sub cboDocumento_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDocumento.Leave
        txtCodDocumento.BackColor = Color.White
    End Sub

    Private Sub cboDocumento_LostFocus(sender As Object, e As System.EventArgs) Handles cboDocumento.LostFocus

    End Sub


    Private Sub cboDocumento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDocumento.SelectedIndexChanged
        If String.IsNullOrEmpty(cboDocumento.ValueMember.ToString) Then
            Exit Sub
        Else
            If cboDocumento.Text = "" Then
                cboDocumento.Text = ""
                txtCodDocumento.Text = ""
            Else
                txtCodDocumento.Text = cboDocumento.SelectedValue
                If cboDocumento.SelectedValue = "6" Then
                    txtNumDoc.MaxLength = 11
                ElseIf cboDocumento.SelectedValue = "1" Then
                    txtNumDoc.MaxLength = 8
                Else
                    txtNumDoc.MaxLength = 15
                End If
            End If
        End If
    End Sub

    Private Sub cboTipoPersona_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTipoPersona.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.Chr(13) Or e.KeyChar = Microsoft.VisualBasic.Chr(9) Then
            e.Handled = True
            If cboTipoPersona.Text = "01 NATURAL" Then
                'lblnom1.Visible = True
                'lblnom2.Visible = True
                'txtNombre1.Visible = True
                'txtNombre2.Visible = True
                'txtAppat.Visible = True
                'txtApmat.Visible = True
                'lblrazon.Visible = False
                'txtRazon.Visible = False
                txtNumDoc.Text = "10"
            Else
                'lblnom1.Visible = False
                'lblnom2.Visible = False
                'txtNombre1.Visible = False
                'txtNombre2.Visible = False
                'txtAppat.Visible = False
                'txtApmat.Visible = False
                'lblrazon.Visible = True
                'txtRazon.Visible = True
                txtNumDoc.Text = "20"
            End If
            txtNumDoc.Focus()
            txtNumDoc.SelectionStart = 2
        End If
    End Sub

    Private Sub cboTipoPersona_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoPersona.SelectedIndexChanged
        txtNumDoc.Clear()
        txtAppat.Clear()
        txtApmat.Clear()
        txtNombre1.Clear()
        txtNombre2.Clear()
        txtRazon.Clear()
        If cboTipoPersona.Text = "01 NATURAL" Then
            lblnom1.Visible = True
            lblnom2.Visible = True
            lblappat.Visible = True
            lblapmat.Visible = True
            txtNombre1.Visible = True
            txtNombre2.Visible = True
            txtAppat.Visible = True
            txtApmat.Visible = True
            lblrazon.Visible = False
            txtRazon.Visible = False
            txtNumDoc.Text = "10"
        Else
            lblnom1.Visible = False
            lblnom2.Visible = False
            lblappat.Visible = False
            lblapmat.Visible = False
            txtNombre1.Visible = False
            txtNombre2.Visible = False
            txtAppat.Visible = False
            txtApmat.Visible = False
            lblrazon.Visible = True
            txtRazon.Visible = True
            txtNumDoc.Text = "20"
        End If
    End Sub

    Private Sub txtNumDoc_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumDoc.Enter
        txtNumDoc.BackColor = Color.LavenderBlush
    End Sub

    Private Sub txtNumDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumDoc.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.Chr(13) Or e.KeyChar = Microsoft.VisualBasic.Chr(9) Then
            e.Handled = True
            If cboTipoPersona.Text = "01 NATURAL" Then
                txtAppat.Focus()
                txtAppat.Select(0, txtAppat.Text.Length)
            Else
                txtRazon.Focus()
                txtRazon.Select(0, txtAppat.Text.Length)
            End If
        End If
    End Sub

    Private Sub txtNumDoc_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumDoc.Leave
        txtNumDoc.BackColor = Color.White
    End Sub

    Private Sub txtRazon_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRazon.Enter
        txtRazon.BackColor = Color.LavenderBlush
    End Sub

    Private Sub txtRazon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRazon.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.Chr(13) Or e.KeyChar = Microsoft.VisualBasic.Chr(9) Then
            e.Handled = True
            txtDir.Focus()
            txtDir.Select(0, txtDir.Text.Length)
        End If
    End Sub

    Private Sub txtRazon_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRazon.Leave
        txtRazon.BackColor = Color.White
    End Sub

    Private Sub txtDir_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDir.Enter
        txtDir.BackColor = Color.LavenderBlush
    End Sub

    Private Sub txtDir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDir.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.Chr(13) Or e.KeyChar = Microsoft.VisualBasic.Chr(9) Then
            e.Handled = True
            txtFono.Focus()
            txtFono.Select(0, txtFono.Text.Length)
        End If
    End Sub

    Private Sub txtDir_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDir.Leave
        txtDir.BackColor = Color.White
    End Sub

    Private Sub txtFono_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFono.Enter
        txtFono.BackColor = Color.LavenderBlush
    End Sub

    Private Sub txtFono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFono.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.Chr(13) Or e.KeyChar = Microsoft.VisualBasic.Chr(9) Then
            e.Handled = True
            txtcelular.Focus()
            txtcelular.Select(0, txtcelular.Text.Length)
        End If
    End Sub

    Private Sub txtFono_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFono.Leave
        txtFono.BackColor = Color.White
    End Sub

    Private Sub txtcelular_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcelular.Enter
        txtcelular.BackColor = Color.LavenderBlush
    End Sub

    Private Sub txtcelular_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcelular.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.Chr(13) Or e.KeyChar = Microsoft.VisualBasic.Chr(9) Then
            e.Handled = True
            txtnextel.Focus()
            txtnextel.Select(0, txtnextel.Text.Length)
        End If
    End Sub

    Private Sub txtcelular_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcelular.Leave
        txtcelular.BackColor = Color.White
    End Sub

    Private Sub txtnextel_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnextel.Enter
        txtnextel.BackColor = Color.LavenderBlush
    End Sub

    Private Sub txtnextel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnextel.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.Chr(13) Or e.KeyChar = Microsoft.VisualBasic.Chr(9) Then
            e.Handled = True
            txtMail.Focus()
            txtMail.Select(0, txtMail.Text.Length)
        End If
    End Sub

    Private Sub txtnextel_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnextel.Leave
        txtnextel.BackColor = Color.White
    End Sub

    Private Sub txtMail_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMail.Enter
        txtMail.BackColor = Color.LavenderBlush
    End Sub

    Private Sub txtMail_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMail.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.Chr(13) Or e.KeyChar = Microsoft.VisualBasic.Chr(9) Then
            e.Handled = True
            ' GuardarToolStripButton.Focus()
        End If
    End Sub

    Private Sub txtMail_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMail.Leave
        txtMail.BackColor = Color.White
    End Sub

    Private Sub txtAppat_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAppat.Enter
        txtAppat.BackColor = Color.LavenderBlush
    End Sub

    Private Sub txtAppat_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAppat.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.Chr(13) Or e.KeyChar = Microsoft.VisualBasic.Chr(9) Then
            e.Handled = True
            txtApmat.Focus()
            txtApmat.Select(0, txtApmat.Text.Length)
        End If
    End Sub

    Private Sub txtApmat_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtApmat.Enter
        txtApmat.BackColor = Color.LavenderBlush
    End Sub

    Private Sub txtApmat_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtApmat.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.Chr(13) Or e.KeyChar = Microsoft.VisualBasic.Chr(9) Then
            e.Handled = True
            txtNombre1.Focus()
            txtNombre1.Select(0, txtNombre1.Text.Length)
        End If
    End Sub

    Private Sub txtNombre1_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNombre1.Enter
        txtNombre1.BackColor = Color.LavenderBlush
    End Sub

    Private Sub txtNombre1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre1.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.Chr(13) Or e.KeyChar = Microsoft.VisualBasic.Chr(9) Then
            e.Handled = True
            txtNombre2.Focus()
            txtNombre2.Select(0, txtNombre2.Text.Length)
        End If
    End Sub

    Private Sub txtNombre2_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNombre2.Enter
        txtNombre2.BackColor = Color.LavenderBlush
    End Sub

    Private Sub txtNombre2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre2.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.Chr(13) Or e.KeyChar = Microsoft.VisualBasic.Chr(9) Then
            e.Handled = True
            txtDir.Focus()
            txtDir.Select(0, txtDir.Text.Length)
        End If
    End Sub

    Private Sub txtAppat_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAppat.Leave
        txtAppat.BackColor = Color.White
    End Sub

    Private Sub txtApmat_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtApmat.Leave
        txtApmat.BackColor = Color.White
    End Sub

    Private Sub txtNombre1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNombre1.Leave
        txtNombre1.BackColor = Color.White
    End Sub

    Private Sub txtNombre2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNombre2.Leave
        txtNombre2.BackColor = Color.White
    End Sub

    Private Sub txtMail_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMail.TextChanged

    End Sub

    Private Sub rb42_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rb42.CheckedChanged
        If rb42.Checked = True Then
            ObtenerCuentas()
        End If
    End Sub

    Private Sub rb43_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rb43.CheckedChanged
        If rb43.Checked = True Then
            ObtenerCuentas43()
        End If
    End Sub

    Private Sub rbAll_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbAll.CheckedChanged
        If rbAll.Checked = True Then
            ObtenerCuentasAll()
        End If
    End Sub

    Private Sub txtNumDoc_LostFocus(sender As Object, e As System.EventArgs) Handles txtNumDoc.LostFocus
        '   txtNumDoc.Text.Trim()
        'If cboDocumento.SelectedValue = "6" Then
        '    If Not txtNumDoc.Text.Length = 11 Then
        '        MsgBox("El número de Ruc es de 11 digítos.", MsgBoxStyle.Critical, "Aviso del Sistema")
        '        txtNumDoc.Focus()
        '        txtNumDoc.SelectAll()
        '        Exit Sub
        '    End If
        'Else
        'If String.IsNullOrEmpty(txtNumDoc.Text) Then
        '    MsgBox("Ingrese el número del documento.", MsgBoxStyle.Critical, "Aviso del Sistema")
        '    txtNumDoc.Focus()
        '    txtNumDoc.SelectAll()
        '    Exit Sub
        'End If
        '  End If
    End Sub

    Private Sub txtNumDoc_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNumDoc.TextChanged
        'If cboDocumento.SelectedValue = "6" Then
        '    If cboTipoPersona.Text = "01 NATURAL" Then
        '        If Not txtNumDoc.Text.Substring(0, 1) = "1" Then
        '            MsgBox("El número de documento debe empezar con '1'", MsgBoxStyle.Information, "Persona Natural")
        '            txtNumDoc.Clear()
        '            txtNumDoc.Focus()
        '        End If
        '    Else
        '        If Not txtNumDoc.Text.Substring(0, 1) = "2" Then
        '            MsgBox("El número de documento debe empezar con '2'", MsgBoxStyle.Information, "Persona Jurídica")
        '            txtNumDoc.Clear()
        '            txtNumDoc.Focus()
        '        End If
        '    End If
        '  End If
    End Sub

    Private Sub lnkAgregar_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAgregar.LinkClicked
        'With frmAgregarCuentaContable
        '    .Tag = "AgregarEntidad"
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        'End With
    End Sub

    Private Sub cboCuenta_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCuenta.SelectedIndexChanged

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
        n.SubItems.Add(txtMail2.Text.Trim)
        '  n.SubItems.Add(Manipulacion.Nuevo)
        Return n
    End Function
    Private Sub GuardarToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton1.Click
        Dim sMail As String = txtMail2.Text

        '    sMail = InputBox("Escribir una dirección de email", "validación")

        If Len(sMail) > 0 Then
            '  MsgBox(validar_Mail(sMail), MsgBoxStyle.Information)
            Select Case validar_Mail(sMail)
                Case True
                    lsvCorreos.Items.Add(ItemList)
                    txtMail2.Clear()
                Case False
                    MsgBox("Ingrese un email correcto", MsgBoxStyle.Exclamation, "Atención")
            End Select

        End If
    End Sub
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
    Private Sub ImprimirToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ImprimirToolStripButton1.Click
        Me.Cursor = Cursors.WaitCursor
        If lsvCorreos.SelectedItems.Count > 0 Then
            'If lsvCorreos.SelectedItems(0).SubItems(4).Text = Manipulacion.Nuevo Then
            '    '    EliminarCorreo(2)
            'Else
            '    '     EliminarCorreo(1)
            '    '     ObtenerCorreosPorTrab(txtNumDoc.Text.Trim)
            'End If
            Me.lblEstado.Text = ("Done: El email se elimino con exito.!")
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton.Click
        If Manipulacionx = ENTITY_ACTIONS.INSERT Then
            Save()
        ElseIf Manipulacionx = ENTITY_ACTIONS.UPDATE Then
            Select Case cboTipoPersona.Text
                Case "01 NATURAL"
                    If txtApmat.Text.Trim.Length > 0 Then
                        If txtAppat.Text.Trim.Length > 0 Then
                            If txtNombre1.Text.Trim.Length > 0 Then
                                UpdateEntidad()
                            Else
                                '   MsgBox("Ingrese el nombre de la entidad!.", MsgBoxStyle.Information, "Atención!")
                                lblEstado.Text = "Ingrese el nombre de la entidad!."
                                lblEstado.Image = My.Resources.warning2
                                txtNombre1.Focus()
                            End If
                        Else
                            ' MsgBox("Ingrese el apellido paterno de la entidad!.", MsgBoxStyle.Information, "Atención!")
                            lblEstado.Text = "Ingrese el apellido paterno de la entidad!."
                            lblEstado.Image = My.Resources.warning2
                            txtAppat.Focus()
                        End If
                    Else
                        '  MsgBox("Ingrese el apellido materno de la entidad!.", MsgBoxStyle.Information, "Atención!")
                        lblEstado.Text = "Ingrese el apellido materno de la entidad!."
                        lblEstado.Image = My.Resources.warning2
                        txtApmat.Focus()
                    End If
                Case Else
                    If txtRazon.Text.Trim.Length > 0 Then
                        UpdateEntidad()
                    Else
                        '   MsgBox("Ingrese la razón social de la entidad!.", MsgBoxStyle.Information, "Atención!")
                        lblEstado.Text = "Ingrese la razón social de la entidad!."
                        lblEstado.Image = My.Resources.warning2
                        txtRazon.Focus()
                    End If
            End Select

        End If
    End Sub

    Private Sub txtMail2_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtMail2.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            GuardarToolStripButton1_Click(sender, e)
        End If
    End Sub

    Private Sub txtMail2_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtMail2.TextChanged

    End Sub

    Private Sub AyudaToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles AyudaToolStripButton.Click
        Dispose()
    End Sub
End Class
