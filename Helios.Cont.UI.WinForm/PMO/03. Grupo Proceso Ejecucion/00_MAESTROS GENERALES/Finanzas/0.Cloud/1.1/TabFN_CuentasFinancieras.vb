Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess

Public Class TabFN_CuentasFinancieras

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(dgCuentasFinancieras, True, False)
        GetCuentasFinancieras()
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

        For Each i In entidadSA.ObtenerEstadosFinancierosPorEstablecimiento(New estadosFinancieros With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
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
            ElseIf (i.tipo = "TC") Then
                dr(4) = "TARJETA"
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

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.EDITAR_CUENTA_FINANCIERA_Botón___, AutorizacionRolList) Then
            If Not IsNothing(Me.dgCuentasFinancieras.Table.CurrentRecord) Then
                Dim f As New frmModalCaja
                f.strEstadoManipulacion = ENTITY_ACTIONS.UPDATE
                f.ObtenerMascaraMercaderia()
                '.txtCuentaID.Text = "101"
                f.UbicarPorID(Me.dgCuentasFinancieras.Table.CurrentRecord.GetValue("idEF"))
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            Else
                MessageBox.Show("Debe seleccionar una entidad financiera!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click

    End Sub
End Class
