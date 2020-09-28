Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess

Public Class TabLG_Almacen

    Property almacenSA As New almacenSA

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(dgAlmacen, True, False)
        GetAlmacenes()
    End Sub

#Region "Methods"
    Sub GetAlmacenes()

        Dim dt As New DataTable
        dt.Columns.Add("idalmacen")
        dt.Columns.Add("almacen")
        dt.Columns.Add("encargado")
        dt.Columns.Add("estado")

        Dim listaAlmacenes = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})


        For Each i In listaAlmacenes ' almacenSA.GetListar_almacenesTipobyEmpre(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .tipo = TipoAlmacen.Deposito})
            dt.Rows.Add(i.idAlmacen, i.descripcionAlmacen, i.encargado, If(i.estado = "S", "Activo", "Baja"))
        Next
        dgAlmacen.DataSource = dt
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.NUEVO_ALMACEN_Botón___, AutorizacionRolList) Then
        '    Dim f As New frmNuevoAlmacen
        '    f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        '    f.StartPosition = FormStartPosition.CenterParent
        '    f.ShowDialog(Me)
        'Else
        '    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        'Cursor = Cursors.WaitCursor
        'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.EDITAR_ALMACEN_Botón___, AutorizacionRolList) Then
        '    Dim r As Syncfusion.Grouping.Record = dgAlmacen.Table.CurrentRecord
        '    If r IsNot Nothing Then
        '        Dim f As New frmNuevoAlmacen
        '        f.UbicarDocumento(Val(r.GetValue("idalmacen")))
        '        f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
        '        f.StartPosition = FormStartPosition.CenterParent
        '        f.ShowDialog()
        '    End If
        'Else
        '    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
        'Cursor = Cursors.Default
    End Sub

    Private Sub PonerInactivoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PonerInactivoToolStripMenuItem.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.ESTADO_ALMACEN_Botón___, AutorizacionRolList) Then
            Dim r As Syncfusion.Grouping.Record = dgAlmacen.Table.CurrentRecord
            If r IsNot Nothing Then
                almacenSA.CambiarEstadoAlmacen(New almacen() With {.idAlmacen = r.GetValue("idalmacen"), .estado = "I"})
                GetAlmacenes()
            Else
                MsgBox("Seleccionar un almacén", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ActivarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActivarToolStripMenuItem.Click
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.ESTADO_ALMACEN_Botón___, AutorizacionRolList) Then
            Dim r As Syncfusion.Grouping.Record = dgAlmacen.Table.CurrentRecord
            If r IsNot Nothing Then
                almacenSA.CambiarEstadoAlmacen(New almacen() With {.idAlmacen = r.GetValue("idalmacen"), .estado = "S"})
                GetAlmacenes()
            Else
                MsgBox("Seleccionar un almacén", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
#End Region

End Class
