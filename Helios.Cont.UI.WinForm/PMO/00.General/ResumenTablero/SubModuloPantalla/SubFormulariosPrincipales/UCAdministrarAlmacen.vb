Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes
Imports Helios.Seguridad.WCFService.ServiceAccess

Public Class UCAdministrarAlmacen

    Public Property almacenSA As New almacenSA

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        '  
    End Sub

    Public Sub CARGARCOMPLEMENTOS()
        FormatoGridAvanzado(dgAlmacen, True, False, 9.0F)
        OrdenamientoGrid(dgAlmacen, True)
    End Sub

    Public Sub GetAlmacenes()

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

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.NUEVO_ALMACEN_Botón___, AutorizacionRolList) Then
        Dim f As New frmNuevoAlmacen(GEstableciento.IdEstablecimiento, Gempresas.IdEmpresaRuc)
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        'Else
        '    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        Cursor = Cursors.WaitCursor

        Dim r As Syncfusion.Grouping.Record = dgAlmacen.Table.CurrentRecord
        If r IsNot Nothing Then
            Dim f As New frmNuevoAlmacen(GEstableciento.IdEstablecimiento, Gempresas.IdEmpresaRuc)
            f.UbicarDocumento(Val(r.GetValue("idalmacen")))
            f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click

        Dim r As Syncfusion.Grouping.Record = dgAlmacen.Table.CurrentRecord
        If r IsNot Nothing Then
            almacenSA.CambiarEstadoAlmacen(New almacen With {.idAlmacen = r.GetValue("idalmacen"), .estado = "I"})
            GetAlmacenes()
        Else
            MsgBox("Seleccionar un almacén", MsgBoxStyle.Critical, "Atención")
        End If
    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        GetAlmacenes()
    End Sub
End Class
