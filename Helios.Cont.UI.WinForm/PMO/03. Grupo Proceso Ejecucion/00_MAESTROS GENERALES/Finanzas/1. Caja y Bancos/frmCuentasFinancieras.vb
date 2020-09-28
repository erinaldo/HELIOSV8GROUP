Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General

Public Class frmCuentasFinancieras

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GetCuentasFinancieras()
    End Sub
#End Region

#Region "Métodos"
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
#End Region

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Me.Cursor = Cursors.WaitCursor
        With frmModalCaja
            .strEstadoManipulacion = ENTITY_ACTIONS.INSERT
            .ObtenerMascaraMercaderia()
            .txtCuentaID.Text = "104"
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        If Not IsNothing(Me.dgCuentasFinancieras.Table.CurrentRecord) Then
            With frmModalCaja
                .strEstadoManipulacion = ENTITY_ACTIONS.UPDATE
                .ObtenerMascaraMercaderia()
                '.txtCuentaID.Text = "101"
                .UbicarPorID(Me.dgCuentasFinancieras.Table.CurrentRecord.GetValue("idEF"))
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        Else
            MessageBox.Show("Debe seleccionar una entidad financiera!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        Me.Cursor = Cursors.WaitCursor
        GetCuentasFinancieras()
        Me.Cursor = Cursors.Default
    End Sub
End Class