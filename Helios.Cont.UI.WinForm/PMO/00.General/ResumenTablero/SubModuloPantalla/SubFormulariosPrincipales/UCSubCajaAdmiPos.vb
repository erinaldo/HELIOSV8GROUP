Imports System.ComponentModel
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity

Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Public Class UCSubCajaAdmiPos

#Region "Atributos"

    Public Property cajaUsuarioSA As New cajaUsuarioSA
    Private FormCajeroIndependiente As FormCajeroIndependiente
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Public Property User As New cajaUsuario

#End Region

#Region "Constructor"

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

#End Region

#Region "Metodos"


    Private Sub GetListCuentaFinancierasTotal(tipo As String, idCajaUser As Integer)
        Dim estadosFinancierosSA As New EstadosFinancierosSA


        Select Case tipo
            Case "EFECTIVO CAJERO"
                tipo = "EP"

        End Select


        Dim dt As New DataTable("Mis Cuentas Financieras")
        dt.Columns.Add(New DataColumn("idestado", GetType(Integer)))
        dt.Columns.Add(New DataColumn("descripcion"))
        dt.Columns.Add(New DataColumn("moneda"))
        dt.Columns.Add(New DataColumn("monto"))

        For Each i In estadosFinancierosSA.GetSaldoCuentasFinancieraCajeroActivo(New Business.Entity.estadosFinancieros With {
                                       .idEmpresa = Gempresas.IdEmpresaRuc,
                                       .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                       .tipo = tipo, .fechaBalance = DateTime.Now,
                                       .IdCaja = idCajaUser
                                                                                  })

            Dim dr As DataRow = dt.NewRow()

            dr(0) = i.idestado
            dr(1) = i.descripcion
            dr(2) = "-"
            dr(3) = (i.SaldoAnterior.GetValueOrDefault + i.Cobros.GetValueOrDefault) - i.Pagos.GetValueOrDefault
            dt.Rows.Add(dr)
        Next

        setDatasource(dt)


    End Sub


    Public Sub setDatasource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            Dim deleg As New SetDataSourceDelegate(AddressOf setDatasource)
            Invoke(deleg, New Object() {table})
        Else
            DgvComprobantes.DataSource = table
            'ProgressBar1.Visible = False
        End If
    End Sub

    Public Sub AbrirCajaGeneral()
        Dim usuarioSel = UsuariosList.Where(Function(o) o.TipoDocumento = "SUPER").FirstOrDefault
        If usuarioSel IsNot Nothing Then

            Dim CargoSelec = usuarioSel.UsuarioRol.FirstOrDefault  ' super usuairo solo tiene 1 rol 
            If CargoSelec IsNot Nothing Then


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
                        .IDRol = CargoSelec.IDRol
                        .tipoCaja = Tipo_Caja.GENERAL
                        .namepc = shostname
                        .idEmpresa = Gempresas.IdEmpresaRuc
                        .idEstablecimiento = GEstableciento.IdEstablecimiento
                        .periodo = GetPeriodo(Date.Now, True)
                        .idPersona = usuarioSel.IDUsuario
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

                    For Each d In ListaCuentasFinancierasConfiguradas.Where(Function(o) o.IDFormaPago <> "9991" And o.tipoCaja <> "EP").ToList
                        UserDetalle = New cajaUsuariodetalle
                        UserDetalle.idEntidad = Integer.Parse(d.identidad)
                        UserDetalle.moneda = d.moneda

                        If UserDetalle.moneda = "1" Then
                            UserDetalle.importeMN = CDec(0.0)
                            UserDetalle.importeME = 0
                        ElseIf UserDetalle.moneda = "2" Then
                            UserDetalle.importeMN = 0
                            UserDetalle.importeME = CDec(0.0)
                        End If

                        UserDetalle.tipoCambio = TmpTipoCambio
                        UserDetalle.usuarioActualizacion = usuario.IDUsuario
                        UserDetalle.idConfiguracion = Integer.Parse(d.idConfiguracion)
                        UserDetalle.fechaActualizacion = DateTime.Now
                        ListaUserDetalle.Add(UserDetalle)
                    Next
                    objCaja.cajaUsuariodetalle = ListaUserDetalle
                    If ListaUserDetalle.Count = 0 Then Exit Sub
                    Dim codigoUsuarioClave = documentoCajaSA.SaveCajaAdministrativaApertura(Nothing, objCaja, Nothing)
                    ListaCajasActivas = cajaSA.ListadoCajaXEstado(New cajaUsuario With {
                                                                     .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                     .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                     .estadoCaja = "A"
                                                                     })

                Catch ex As Exception

                End Try


            End If

        End If




    End Sub

#End Region
    Private Sub btnAbrirCaja_Click(sender As Object, e As EventArgs) Handles btnAbrirCaja.Click
        Try
            If validarPermisos(PermisosDelSistema.APERTURA_DE_CAJA_, AutorizacionRolList) = 1 Then

                Me.Cursor = Cursors.WaitCursor
                '
                Dim cajaActivaGeneral = ListaCajasActivas.Where(Function(o) o.tipoCaja = Tipo_Caja.GENERAL).SingleOrDefault

                If cajaActivaGeneral Is Nothing Then
                    AbrirCajaGeneral()
                End If

                '
                If usuario.tipoCaja = "POS" Then
                    Dim f As New FormCrearCajero
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog(Me)
                Else
                    MessageBox.Show("Su cargo no puede apertar Caja Pos", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

                '
                Me.Cursor = Cursors.Arrow
            Else
                MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Arrow
        End Try
    End Sub

    Private Sub btnCerrarCaja_Click(sender As Object, e As EventArgs) Handles btnCerrarCaja.Click
        Try



            If validarPermisos(PermisosDelSistema.CIERRE_DE_CAJA_, AutorizacionRolList) = 1 Then
                Dim Form As New FormCierreXUsuario()
                Form.StartPosition = FormStartPosition.CenterScreen
                Form.ShowDialog(Me)
            Else
                MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCobranza_Click(sender As Object, e As EventArgs) Handles btnCobranza.Click


        Try
            If validarPermisos(PermisosDelSistema.CAJA_CENTRAL_, AutorizacionRolList) = 1 Then

                Dim cajaActivaGeneral = ListaCajasActivas.Where(Function(o) o.tipoCaja = Tipo_Caja.GENERAL).SingleOrDefault

                If cajaActivaGeneral Is Nothing Then
                    AbrirCajaGeneral()
                End If

                '
                If ListaCajasActivas.Count = 0 Or ListaCajasActivas Is Nothing Then
                    MessageBox.Show("Debe registrar una caja para realizar la venta")
                    ListaCajasActivas = cajaUsuarioSA.ListadoCajaXEstado(New cajaUsuario With {
                                                                     .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                     .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                     .estadoCaja = "A"
                                                                     })
                    Exit Sub
                End If

                If GconfigCaja = "2" Then

                    Dim querybox = (From i In ListaCajasActivas
                                    Where i.idPersona = usuario.IDUsuario And i.estadoCaja = "A" And i.IDRol = usuario.IDRol).FirstOrDefault

                    If querybox IsNot Nothing Then
                    Else
                        MessageBox.Show("Su usuario no tiene una caja aperturada")
                        Exit Sub
                    End If
                End If

                Dim frm As MetroForm = Application.OpenForms.OfType(Of MetroForm)().Where(Function(pre) pre.Name = "FormCajeroIndependiente").SingleOrDefault
                If frm Is Nothing Then


                    If usuario.tipoCaja = "POS" Then

                        FormCajeroIndependiente = New FormCajeroIndependiente
                        FormCajeroIndependiente.StartPosition = FormStartPosition.CenterScreen
                        FormCajeroIndependiente.Show()

                    Else
                        MessageBox.Show("Su cargo no puede apertar Caja Pos", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                Else
                    FormCajeroIndependiente.WindowState = FormWindowState.Normal
                    FormCajeroIndependiente.BringToFront()
                End If
            Else
                MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnEntradaDeDinero_Click(sender As Object, e As EventArgs) Handles btnEntradaDeDinero.Click
        If validarPermisos(PermisosDelSistema.INGRESO_DE_EFECTIVO_, AutorizacionRolList) = 1 Then
            Dim cajaUsuarioSA As New cajaUsuarioSA
            Cursor = Cursors.WaitCursor
            '
            Dim cajaActivaGeneral = ListaCajasActivas.Where(Function(o) o.tipoCaja = Tipo_Caja.GENERAL).SingleOrDefault

            If cajaActivaGeneral Is Nothing Then
                AbrirCajaGeneral()
            End If

            '
            '
            Dim f As New FormRealizacionDePagos
            f.txtAnioCompra.Text = DateTime.Now.Year
            f.cboMesCompra.SelectedValue = String.Format("{0:00}", DateTime.Now.Month)
            f.txtHora.Value = DateTime.Now
            f.TxtDia.Text = DateTime.Now.Day ' ""
            f.StartPosition = FormStartPosition.CenterParent
            f.txtTipoCambio.Value = TmpTipoCambio
            f.ShowDialog(Me)
            '
            Cursor = Cursors.Default
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnSalidaDeDinero_Click(sender As Object, e As EventArgs) Handles btnSalidaDeDinero.Click
        If validarPermisos(PermisosDelSistema.SALIDA_DE_EFECTIVO_, AutorizacionRolList) = 1 Then
            Cursor = Cursors.WaitCursor
            '

            Dim cajaActivaGeneral = ListaCajasActivas.Where(Function(o) o.tipoCaja = Tipo_Caja.GENERAL).SingleOrDefault

            If cajaActivaGeneral Is Nothing Then
                AbrirCajaGeneral()
            End If
            '
            Dim f As New FormPagoEgreso
            f.txtAnioCompra.Text = DateTime.Now.Year
            f.cboMesCompra.SelectedValue = String.Format("{0:00}", DateTime.Now.Month)
            f.txtHora.Value = DateTime.Now
            f.TxtDia.Text = DateTime.Now.Day ' ""
            f.StartPosition = FormStartPosition.CenterParent
            f.txtTipoCambio.Value = TmpTipoCambio
            f.ShowDialog(Me)
            '
            Cursor = Cursors.Default
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click


        Dim querybox = (From i In ListaCajasActivas
                        Where i.idPersona = usuario.IDUsuario And i.estadoCaja = "A" And i.IDRol = usuario.IDRol).FirstOrDefault

        If querybox IsNot Nothing Then
        Else
            MessageBox.Show("Su usuario no tiene una caja Abierta")
            Exit Sub
        End If


        If usuario.tipoCaja = Tipo_Caja.PUNTO_DE_VENTA Then

            User = (From i In ListaCajasActivas Where i.idPersona = usuario.IDUsuario And i.IDRol = usuario.IDRol).FirstOrDefault

            GetListCuentaFinancierasTotal(cboTipo.Text, User.idcajaUsuario)

        End If



    End Sub
End Class
