Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class UCCuentasFinancierasXEmpresa

#Region "Attributes"

#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(dgCuentasFinancieras, True, False, 9.0F)
        OrdenamientoGrid(dgCuentasFinancieras, True)
        ListarUnidOrganicas()
    End Sub
#End Region

#Region "Methods"

    Public Sub ListarUnidOrganicas()
        Try
            Dim sa As New CentrocostosSA

            Dim centroCostosBE As New centrocosto

            centroCostosBE.idCentroCosto = 0
            centroCostosBE.nombre = "TODO"
            centroCostosBE.TipoEstab = "UN"

            ListaUnidadOrganica = New List(Of centrocosto)
            ListaUnidadOrganica.Add(centroCostosBE)

            ListaUnidadOrganica.AddRange(sa.GetObtenerEstablecimiento(Gempresas.IdEmpresaRuc).Where(Function(o) o.TipoEstab = "UN").ToList)


            cboUnidOrg.ValueMember = "idCentroCosto"
            cboUnidOrg.DisplayMember = "nombre"
            cboUnidOrg.DataSource = ListaUnidadOrganica

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
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
        dt.Columns.Add(New DataColumn("unidOrg", GetType(String)))


        Select Case cboUnidOrg.Text
            Case "TODO"

                For Each i In entidadSA.ObtenerEstadosFinancierosPorEstablecimiento(New estadosFinancieros With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = Nothing, .tipoConsulta = StatusTipoConsulta.XEmpresa})
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
                    ElseIf (i.tipo = "EF") Then
                        dr(4) = "EFECTIVO"
                    ElseIf (i.tipo = "EP") Then
                        dr(4) = "EFECTIVO"
                    ElseIf (i.tipo = "TC") Then
                        dr(4) = "TARJETA"
                    End If

                    If (IsNothing(i.idBanco)) Then
                        dr(5) = "---"
                    Else
                        dr(5) = i.predeterminado
                    End If
                    dr(6) = ListaUnidadOrganica.Where(Function(o) o.idCentroCosto = i.idEstablecimiento).First.nombre

                    dt.Rows.Add(dr)
                Next
                dgCuentasFinancieras.DataSource = dt
                dgCuentasFinancieras.TableOptions.ListBoxSelectionMode = SelectionMode.One
            Case Else

                For Each i In entidadSA.ObtenerEstadosFinancierosPorEstablecimiento(New estadosFinancieros With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = cboUnidOrg.SelectedValue, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
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
                    ElseIf (i.tipo = "EF") Then
                        dr(4) = "EFECTIVO"
                    ElseIf (i.tipo = "EP") Then
                        dr(4) = "EFECTIVO"
                    ElseIf (i.tipo = "TC") Then
                        dr(4) = "TARJETA"
                    End If

                    If (IsNothing(i.idBanco)) Then
                        dr(5) = "---"
                    Else
                        dr(5) = i.predeterminado
                    End If

                    dr(6) = cboUnidOrg.Text
                    dt.Rows.Add(dr)
                Next
                dgCuentasFinancieras.DataSource = dt
                dgCuentasFinancieras.TableOptions.ListBoxSelectionMode = SelectionMode.One
        End Select


    End Sub
#End Region

#Region "Events"
    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.EDITAR_CUENTA_FINANCIERA_Botón___, AutorizacionRolList) Then
        If Not IsNothing(Me.dgCuentasFinancieras.Table.CurrentRecord) Then
            Dim f As New frmModalCaja(cboUnidOrg.SelectedValue)
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
        'If validarPermisos(PermisosDelSistema.FINANZAS_, AutorizacionRolList) = 1 Then
        Dim f As New frmModalCajaXEmpresa(cboUnidOrg.SelectedValue)
            f.strEstadoManipulacion = ENTITY_ACTIONS.INSERT
            f.ObtenerMascaraMercaderia()
            f.txtCuentaID.Text = "104"
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        'Else
        '    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
        'End If
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

    Private Sub BunifuFlatButton7_Click(sender As Object, e As EventArgs)
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
        Cursor = Cursors.Default
    End Sub

    Private Sub cboUnidOrg_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboUnidOrg.SelectedValueChanged
        dgCuentasFinancieras.Table.Records.DeleteAll()
    End Sub
#End Region
End Class
