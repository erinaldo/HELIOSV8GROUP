Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping

Public Class FormCrearCajero
#Region "Attributes"

#End Region

#Region "Constructors"
    Public Sub New(ent As entidad)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(dgvCuentas, False, False, 10.0F)
        Me.Size = New Size(732, 139)
        Mappingentidad(ent)
        GetMappingColumnsGrid()

        txtTipoCambio.Value = TmpTipoCambio
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Me.Size = New Size(732, 139)
        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(dgvCuentas, False, False, 10.0F)
        GetMappingColumnsGrid()
        LogeoUsuarioCaja()
    End Sub

#End Region

#Region "Methods"

    Public Sub LogeoUsuarioCaja()
        Dim usuarioSel = UsuariosList.Where(Function(o) o.IDUsuario = usuario.IDUsuario).FirstOrDefault


        If usuarioSel IsNot Nothing Then

            Dim CargoSelec = usuarioSel.UsuarioRol.Where(Function(o) o.IDRol = usuario.IDRol).FirstOrDefault
            If CargoSelec IsNot Nothing Then

                TextPeersona.Text = usuarioSel.Full_Name
                TextPeersona.Tag = usuarioSel.IDUsuario
                txtIdRol.Text = CargoSelec.nombrePerfil
                txtIdRol.Tag = CargoSelec.IDRol
                TextRuc.Text = usuarioSel.NroDocumento
                TextCodigoVendedor.Text = usuarioSel.codigo
                RoundButton21.Enabled = True
                'Me.Size = New Size(732, 496)
                Me.Size = New Size(732, 184)
                Centrar(Me)
            Else
                TextPeersona.Text = String.Empty
                TextPeersona.Tag = String.Empty
                txtIdRol.Text = String.Empty
                txtIdRol.Tag = String.Empty
                TextRuc.Text = String.Empty
                RoundButton21.Enabled = False
                Me.Size = New Size(732, 130)
            End If

        Else
                TextPeersona.Text = String.Empty
            TextPeersona.Tag = String.Empty
            txtIdRol.Text = String.Empty
            txtIdRol.Tag = String.Empty
            TextRuc.Text = String.Empty
            RoundButton21.Enabled = False
            Me.Size = New Size(732, 130)
            Centrar(Me)
        End If

    End Sub

    'Shared Function GetIPAddress() As String
    '    Dim oAddr As System.Net.IPAddress
    '    Dim sAddr As String
    '    With Net.Dns.GetHostByName(Net.Dns.GetHostName())
    '        oAddr = New Net.IPAddress(.AddressList(0).Address)
    '        sAddr = oAddr.ToString
    '    End With
    '    GetIPAddress = sAddr
    'End Function

    Private Sub Mappingentidad(ent As entidad)
        With ent
            TextPeersona.Text = .nombreCompleto
            TextPeersona.Tag = .idEntidad
            TextRuc.Text = .nrodoc
        End With
    End Sub



    Public Sub GrabarCajaxUsuario()
        Dim cajaSA As New cajaUsuarioSA
        Dim objCaja As New cajaUsuario
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim UserDetalle As New cajaUsuariodetalle
        Dim ListaUserDetalle As New List(Of cajaUsuariodetalle)
        Try
            objCaja = New cajaUsuario

            Dim shostname As String
            shostname = System.Net.Dns.GetHostName
            With objCaja
                .tipoCaja = Tipo_Caja.PUNTO_DE_VENTA
                .namepc = shostname
                .idPadre = 0
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .periodo = GetPeriodo(Date.Now, True)
                .idPersona = TextPeersona.Tag
                .IDRol = txtIdRol.Tag
                .idCajaOrigen = 0
                .idCajaDestino = 0
                .moneda = "1"
                .tipoCambio = TmpTipoCambio
                .fechaRegistro = Date.Now
                .fondoMN = 0
                .fondoME = 0
                .ingresoAdicMN = 0
                .ingresoAdicME = 0
                .otrosIngresosMN = 0
                .otrosIngresosME = 0
                .otrosEgresosMN = 0
                .otrosEgresosME = 0
                .estadoCaja = "A"
                .enUso = "N"
                .usuarioActualizacion = usuario.IDUsuario
                .fechaActualizacion = DateTime.Now
            End With

            ListaUserDetalle = New List(Of cajaUsuariodetalle)
            For Each i As Record In dgvCuentas.Table.Records
                UserDetalle = New cajaUsuariodetalle
                UserDetalle.idEntidad = Integer.Parse(i.GetValue("identidad"))
                UserDetalle.moneda = i.GetValue("moneda")
                If UserDetalle.moneda = "1" Then
                    UserDetalle.importeMN = CDec(i.GetValue("abonado"))
                    UserDetalle.importeME = 0
                ElseIf UserDetalle.moneda = "2" Then
                    UserDetalle.importeMN = 0
                    UserDetalle.importeME = CDec(i.GetValue("abonado"))
                End If
                UserDetalle.tipoCambio = txtTipoCambio.Value

                UserDetalle.usuarioActualizacion = usuario.IDUsuario
                UserDetalle.idConfiguracion = Integer.Parse(i.GetValue("idConfiguration"))
                UserDetalle.fechaActualizacion = DateTime.Now
                ListaUserDetalle.Add(UserDetalle)
            Next
            objCaja.cajaUsuariodetalle = ListaUserDetalle
            objCaja.idEmpresa = Gempresas.IdEmpresaRuc
            objCaja.idEstablecimiento = GEstableciento.IdEstablecimiento
            If ListaUserDetalle.Count = 0 Then Exit Sub
            Dim codigoUsuarioClave = documentoCajaSA.SaveCajaAperturaUsuarioPc(Nothing, objCaja, Nothing)
            ListaCajasActivas = cajaSA.ListadoCajaXEstado(New cajaUsuario With {
                                                             .idEmpresa = Gempresas.IdEmpresaRuc,
                                                             .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                             .estadoCaja = "A"
                                                             })
            Tag = codigoUsuarioClave
            MessageBox.Show("Caja abierta", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Close()
        Catch ex As Exception
            Tag = Nothing
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub Grabar()
        Dim cajaSA As New cajaUsuarioSA
        Dim objCaja As New cajaUsuario
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim UserDetalle As New cajaUsuariodetalle
        Dim ListaUserDetalle As New List(Of cajaUsuariodetalle)
        Try
            objCaja = New cajaUsuario



            Dim shostname As String
            shostname = System.Net.Dns.GetHostName
            With objCaja
                .tipoCaja = Tipo_Caja.PUNTO_DE_VENTA
                .namepc = shostname
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .periodo = GetPeriodo(Date.Now, True)
                .idPersona = TextPeersona.Tag
                .IDRol = txtIdRol.Tag
                .idPadre = 0
                .idCajaOrigen = 0
                .idCajaDestino = 0
                .moneda = "1"
                .tipoCambio = TmpTipoCambio
                .fechaRegistro = Date.Now
                .fondoMN = 0
                .fondoME = 0
                .ingresoAdicMN = 0
                .ingresoAdicME = 0
                .otrosIngresosMN = 0
                .otrosIngresosME = 0
                .otrosEgresosMN = 0
                .otrosEgresosME = 0
                .estadoCaja = "A"
                .enUso = "N"
                .usuarioActualizacion = usuario.IDUsuario
                .fechaActualizacion = DateTime.Now
            End With

            ListaUserDetalle = New List(Of cajaUsuariodetalle)
            For Each i As Record In dgvCuentas.Table.Records
                UserDetalle = New cajaUsuariodetalle
                UserDetalle.idEntidad = Integer.Parse(i.GetValue("identidad"))
                UserDetalle.moneda = 1
                If UserDetalle.moneda = "1" Then
                    UserDetalle.importeMN = CDec(i.GetValue("abonado"))
                    UserDetalle.importeME = 0
                ElseIf UserDetalle.moneda = "2" Then
                    UserDetalle.importeMN = 0
                    UserDetalle.importeME = CDec(i.GetValue("abonado"))
                End If
                UserDetalle.tipoCambio = txtTipoCambio.value

                'UserDetalle.importeMN = CDec(i.GetValue("abonado"))
                'UserDetalle.importeME = 0
                UserDetalle.usuarioActualizacion = usuario.IDUsuario
                UserDetalle.idConfiguracion = Integer.Parse(i.GetValue("idConfiguration"))
                UserDetalle.fechaActualizacion = DateTime.Now
                ListaUserDetalle.Add(UserDetalle)
            Next
            objCaja.cajaUsuariodetalle = ListaUserDetalle
            objCaja.idEmpresa = Gempresas.IdEmpresaRuc
            objCaja.idEstablecimiento = GEstableciento.IdEstablecimiento

            If ListaUserDetalle.Count = 0 Then Exit Sub
            Dim codigoUsuarioClave = documentoCajaSA.SaveGroupCajaApertura(Nothing, objCaja, Nothing)
            ListaCajasActivas = cajaSA.ListadoCajaXEstado(New cajaUsuario With {
                                                             .idEmpresa = Gempresas.IdEmpresaRuc,
                                                             .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                             .estadoCaja = "A"
                                                             })
            Tag = codigoUsuarioClave
            MessageBox.Show("Caja abierta", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Close()
        Catch ex As Exception
            Tag = Nothing
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GetMappingColumnsGrid()
        Dim dt As New DataTable
        Dim SA As New EstadosFinancierosConfiguracionPagosSA
        With dt
            .Columns.Add("tipo")
            .Columns.Add("identidad")
            .Columns.Add("entidad")
            .Columns.Add("abonado")
            .Columns.Add("tipocambio")
            .Columns.Add("idforma")
            .Columns.Add("formaPago")
            .Columns.Add("idConfiguration")
            .Columns.Add("moneda")
        End With


        'If cboModalidadCaja.Text = "PUNTO DE VENTA" Then

        For Each i In ListaCuentasFinancierasConfiguradas.Where(Function(o) o.IDFormaPago <> "9991" And o.tipoCaja <> "EF").ToList
                'For Each i In ListaCuentasFinancierasConfiguradas.Where(Function(o) o.IDFormaPago <> "9991").ToList
                If i.moneda = "1" Then
                    dt.Rows.Add(String.Empty, i.identidad, i.entidad, 0.0, TmpTipoCambio, i.IDFormaPago, $"{i.FormaPago} - moneda nacional", i.idConfiguracion, i.moneda)
                Else
                    dt.Rows.Add(String.Empty, i.identidad, i.entidad, 0.0, TmpTipoCambio, i.IDFormaPago, $"{i.FormaPago} - moneda extranjera", i.idConfiguracion, i.moneda)
                End If
            Next
            dgvCuentas.DataSource = dt
        'Else

        '    For Each i In ListaCuentasFinancierasConfiguradas.Where(Function(o) o.IDFormaPago <> "9991" And o.tipoCaja <> "EP").ToList
        '        'For Each i In ListaCuentasFinancierasConfiguradas.Where(Function(o) o.IDFormaPago <> "9991").ToList
        '        If i.moneda = "1" Then
        '            dt.Rows.Add(String.Empty, i.identidad, i.entidad, 0.0, TmpTipoCambio, i.IDFormaPago, $"{i.FormaPago} - moneda nacional", i.idConfiguracion, i.moneda)
        '        Else
        '            dt.Rows.Add(String.Empty, i.identidad, i.entidad, 0.0, TmpTipoCambio, i.IDFormaPago, $"{i.FormaPago} - moneda extranjera", i.idConfiguracion, i.moneda)
        '        End If
        '    Next
        '    dgvCuentas.DataSource = dt
        'End If

    End Sub


#End Region

#Region "Events"
    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click


        If dgvCuentas.Table.Records.Count = 0 Then
            MessageBox.Show("No hay Cajas Configuradas")
            Exit Sub
        End If

        If dgvCuentas.Table.Records.Count > 0 Then
            If GconfigCaja = "1" Then
                Grabar()
            ElseIf GconfigCaja = "2" Then
                GrabarCajaxUsuario()
            End If




        Else
            MessageBox.Show("Debe seleccionar una caja al menos!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub TextCodigoVendedor_TextChanged(sender As Object, e As EventArgs) Handles TextCodigoVendedor.TextChanged

    End Sub

    Private Sub TextCodigoVendedor_KeyDown(sender As Object, e As KeyEventArgs) Handles TextCodigoVendedor.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Dim codigoVendedor = TextCodigoVendedor.Text.Trim
            Dim usuarioSel = UsuariosList.Where(Function(o) o.codigo = codigoVendedor).FirstOrDefault
            If usuarioSel IsNot Nothing Then
                TextPeersona.Text = usuarioSel.Full_Name
                TextPeersona.Tag = usuarioSel.IDUsuario
                TextRuc.Text = usuarioSel.NroDocumento
                RoundButton21.Enabled = True
                Me.Size = New Size(732, 496)
                Centrar(Me)
            Else
                TextPeersona.Text = String.Empty
                TextPeersona.Tag = String.Empty
                TextRuc.Text = String.Empty
                RoundButton21.Enabled = False
                Me.Size = New Size(732, 139)
                Centrar(Me)
            End If
        End If
    End Sub

    Private Sub RoundButton22_Click(sender As Object, e As EventArgs) Handles RoundButton22.Click
        Dim r As Record = dgvCuentas.Table.CurrentRecord
        If r IsNot Nothing Then
            r.Delete()
        Else

        End If
        dgvCuentas.Refresh()
    End Sub

    Private Sub FormCrearCajero_Load(sender As Object, e As EventArgs) Handles Me.Load
        TextCodigoVendedor.Select()
        TextCodigoVendedor.SelectAll()
    End Sub

    Private Sub SfButton1_Click(sender As Object, e As EventArgs) Handles SfButton1.Click
        Dim r As Record = dgvCuentas.Table.CurrentRecord
        If r IsNot Nothing Then
            r.Delete()
        Else

        End If
        dgvCuentas.Refresh()
    End Sub

    Private Sub cboModalidadCaja_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub cboModalidadCaja_SelectedValueChanged(sender As Object, e As EventArgs)
        GetMappingColumnsGrid()
    End Sub
#End Region
End Class