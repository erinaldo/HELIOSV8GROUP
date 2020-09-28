Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess


Public Class UCCuentasFinancieras

#Region "Attributes"

#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(dgCuentasFinancieras, True, False, 9.0F)
        OrdenamientoGrid(dgCuentasFinancieras, True)
        BunifuFlatButton7.Enabled = True
    End Sub
#End Region

#Region "Methods"

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

    Public Sub GetCuentasFinancieras()
        Dim entidadSA As New EstadosFinancierosSA

        Dim dt As New DataTable("Entidades financieras")
        dt.Columns.Add(New DataColumn("idEF", GetType(Integer)))
        dt.Columns.Add(New DataColumn("moneda", GetType(String)))
        dt.Columns.Add(New DataColumn("cuenta", GetType(String)))
        dt.Columns.Add(New DataColumn("descripEF", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoEF", GetType(String)))
        dt.Columns.Add(New DataColumn("nombreEntidad", GetType(String)))

        dt.Columns.Add(New DataColumn("nroCuenta", GetType(String)))
        dt.Columns.Add(New DataColumn("nroCuentaInt", GetType(String)))
        dt.Columns.Add(New DataColumn("Modalidad", GetType(String)))

        For Each i In entidadSA.ObtenerEstadosFinancierosPorEstablecimiento(New estadosFinancieros With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                            .tipoConsulta = StatusTipoConsulta.XEmpresa})
            Dim dr As DataRow = dt.NewRow()

            dr(0) = i.idestado
            If i.codigo = 1 Then
                dr(1) = ("NACIONAL")
            Else
                dr(1) = ("EXTRANJERA")
            End If
            dr(2) = i.cuenta

            dr(3) = i.descripcion
            If (i.tipo = "BC") Then
                dr(4) = "BANCO"
                dr(6) = i.nroCtaCorriente
                dr(7) = i.nroCtaInterbancaria
                dr(8) = i.modalidadCuenta
            ElseIf (i.tipo = "EF") Then
                dr(4) = "EFECTIVO"
                dr(6) = "-"
                dr(7) = "-"
                dr(8) = "Cta Efectivo"
            ElseIf (i.tipo = "EP") Then
                dr(4) = "EFECTIVO"
                dr(6) = "-"
                dr(7) = "-"
                dr(8) = "Cta Efectivo"
            ElseIf (i.tipo = "TC") Then
                dr(4) = "TARJETA"
                dr(6) = i.nroCtaCorriente
                dr(7) = i.nroCtaInterbancaria
                dr(8) = i.modalidadCuenta
            End If

            If (IsNothing(i.idBanco)) Then
                dr(5) = "---"
            Else
                dr(5) = i.predeterminado
            End If



            dt.Rows.Add(dr)
        Next
        dgCuentasFinancieras.DataSource = dt
        dgCuentasFinancieras.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub

#End Region

#Region "Events"
    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.EDITAR_CUENTA_FINANCIERA_Botón___, AutorizacionRolList) Then
        If Not IsNothing(Me.dgCuentasFinancieras.Table.CurrentRecord) Then
            Dim f As New frmModalCaja
            f.strEstadoManipulacion = ENTITY_ACTIONS.UPDATE
            f.ObtenerMascaraMercaderia()
            '.txtCuentaID.Text = "101"
            f.UbicarPorID(Me.dgCuentasFinancieras.Table.CurrentRecord.GetValue("idEF"))
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            'Else
            '    MessageBox.Show("Debe seleccionar una entidad financiera!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'End If
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        Me.Cursor = Cursors.WaitCursor
        If validarPermisos(PermisosDelSistema.FINANZAS_, AutorizacionRolList) = 1 Then
            Dim f As New frmModalCaja
            f.strEstadoManipulacion = ENTITY_ACTIONS.INSERT
            f.ObtenerMascaraMercaderia()
            f.txtCuentaID.Text = "104"
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            'Else
            '    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'End If
        End If
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub BunifuFlatButton5_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton5.Click
        PictureLoad.Visible = True
        GetCuentasFinancieras()
        PictureLoad.Visible = False
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click

    End Sub

    Private Sub BunifuFlatButton6_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton6.Click
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Cursor = Cursors.WaitCursor
        'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.NUEVO_INGRESO_Botón___, AutorizacionRolList) Then

        If validarPermisos(PermisosDelSistema.INGRESO_DE_EFECTIVO_, AutorizacionRolList) = 1 Then

            Dim f As New FrmTransferenciadeEfectivo
            f.txtAnioCompra.Text = DateTime.Now.Year
            f.cboMesCompra.SelectedValue = String.Format("{0:00}", DateTime.Now.Month)
            f.txtHora.Value = DateTime.Now
            f.TxtDia.Text = DateTime.Now.Day ' ""
            f.StartPosition = FormStartPosition.CenterParent
            f.txtTipoCambio.Value = TmpTipoCambio
            f.ShowDialog(Me)

        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BunifuFlatButton7_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton7.Click
        Cursor = Cursors.WaitCursor

        '     If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.ENTREGA_DE_INVENTARIO__, AutorizacionRolList) Then
        Dim f As New FormConfiguracionPago
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        'Dim FormPreparacionArticulosVenta = New FormPreparacionArticulosVenta
        'FormPreparacionArticulosVenta.StartPosition = FormStartPosition.CenterScreen
        'FormPreparacionArticulosVenta.Show(Me)
        'Else
        '    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If


        Dim cajaActiva = ListaCajasActivas.Where(Function(o) o.tipoCaja = Tipo_Caja.GENERAL).SingleOrDefault

        If cajaActiva Is Nothing Then
            AbrirCajaGeneral()
        End If

        Cursor = Cursors.Default
    End Sub
#End Region
End Class
