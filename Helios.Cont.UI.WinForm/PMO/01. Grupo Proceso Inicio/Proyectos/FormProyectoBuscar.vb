Imports Helios.Cont.Business.Entity
Imports Helios.General
Imports Helios.Planilla.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Public Class FormProyectoBuscar
    'Public currentPage As Integer = 0
    'Public currentSize As Integer = 10
    'Public xConteo As Integer = 0
    'Dim conteoPaginado As Integer

    Public Enum TipoConsulta
        PorTarea = 1
        PorProyecto = 2
    End Enum
#Region "Evento"

    Private Sub FormProyectoBuscar_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub FormProyectoBuscar_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        '  cboEstablecimiento.SelectedValue = IdEstablecimiento

    End Sub


#End Region

#Region "Métodos"
    Public Sub ObtenerProyectos()
        Me.Cursor = Cursors.WaitCursor
        Dim proyectoSA = New ProyectoPlaneacionSA()
        lsvListaProyectos.Items.Clear()
        For Each i In proyectoSA.ObtenerListaProyectos(GEstableciento.IdEstablecimiento)
            Dim n As New ListViewItem(i.idProyecto)
            n.SubItems.Add(i.nombreProyecto)
            n.SubItems.Add(i.estadoCosto)
            n.SubItems.Add(i.fechaInicio.Value.Date)
            n.SubItems.Add(i.fechaFinal.Value.Date)
            lsvListaProyectos.Items.Add(n)
        Next
        Me.Cursor = Cursors.Arrow
    End Sub

    Public Sub EliminarProyecto()
        Dim proyectoSA As New ProyectoPlaneacionSA
        Dim proyectoBL As New ProyectoPlaneacion

        With proyectoBL
            .idProyecto = lsvListaProyectos.SelectedItems(0).SubItems(0).Text
        End With
        proyectoSA.DeleteProyecto(proyectoBL)
        lblEstado.Text = "Proyecto elimiado correctamente"
        lblEstado.Image = My.Resources.ok4
        lsvListaProyectos.SelectedItems(0).Remove()
    End Sub
#End Region

    'ObtenerProyectosDetalle(CEmpresa, cboEstablecimiento.SelectedValue, dtpFechaInicio.Value, dtpFechaFin.Value)
    '            Else
    '                ObtenerProyectosDetalle(CEmpresa, cboEstablecimiento.SelectedValue, dtpFechaInicio.Value, dtpFechaFin.Value)

    Private Sub cboEstablecimiento_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub btnCerrar_Click_1(sender As System.Object, e As System.EventArgs)
        Dispose()
    End Sub

    Private Sub ToolStripButton3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton3.Click
        Dispose()
    End Sub

    Private Sub NuevoToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles NuevoToolStripButton.Click
        With FormProyectoNuevo
            .lblTitulo.Text = "Proyectos: Nuevo Ingreso"
            TmpAction = ENTITY_ACTIONS.INSERT
            .MdiParent = frmPMO
            .Parent = frmPMO.Panel4
            .WindowState = FormWindowState.Maximized
            .StartPosition = FormStartPosition.CenterScreen
            .Show()
        End With
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        Me.Cursor = Cursors.WaitCursor
        With FormProyectoNuevo
            .lblTitulo.Text = "Proyectos: Edición de Datos"
            TmpAction = ENTITY_ACTIONS.UPDATE
            .UbicarProyectoID(lsvListaProyectos.SelectedItems(0).SubItems(0).Text)
            .ObtenerListaEquipoProyecto()
            .ObtenerListaEquipoCliente()
            .confNuevo2()
            Modpreliminar = Modulo_Preliminar.INTERMEDIO
            .MdiParent = frmPMO
            .Parent = frmPMO.Panel4
            .WindowState = FormWindowState.Maximized
            .StartPosition = FormStartPosition.CenterScreen
            .Show()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub


    Private Sub ToolStripButton8_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton8.Click
        'If (conteoPaginado > 1 And conteoPaginado <> txtIndice.Text) Then
        '    Select Case Tag
        '        Case "todo"
        '            currentPage = conteoPaginado - 1
        '            ObtenerProyectosFull(CEmpresa, (IdEstablecimiento), currentPage, currentSize)
        '        Case "AprobaoSinfecha"
        '            currentPage = conteoPaginado - 1
        '            MostrarProyectoAprobadoSinFecha(CEmpresa, (IdEstablecimiento), currentPage, currentSize)
        '        Case "CarteraSinFecha"
        '            currentPage = conteoPaginado - 1
        '            ObtenerProyectosDetalleSinFecha(CEmpresa, (IdEstablecimiento), currentPage, currentSize)
        '        Case "Aprobado"
        '            currentPage = conteoPaginado - 1
        '            ObtenerProyectosFullAPE(CEmpresa, (IdEstablecimiento), currentPage, currentSize)
        '        Case "Ejecucion"
        '            currentPage = conteoPaginado - 1
        '            ObtenerProyectosFullAPE(CEmpresa, IdEstablecimiento, currentPage, currentSize)
        '    End Select

        'End If
    End Sub

    Private Sub ToolStripButton6_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton6.Click
        'If (conteoPaginado > 1 And txtIndice.Text > 1) Then

        '    Select Case Tag
        '        Case "todo"
        '            currentPage = (currentPage - 1)
        '            ObtenerProyectosFull(CEmpresa, (IdEstablecimiento), currentPage, currentSize)
        '        Case "AprobaoSinfecha"
        '            currentPage = (currentPage - 1)
        '            MostrarProyectoAprobadoSinFecha(CEmpresa, (IdEstablecimiento), currentPage, currentSize)
        '        Case "CarteraSinFecha"
        '            currentPage = (currentPage - 1)
        '            ObtenerProyectosDetalleSinFecha(CEmpresa, (IdEstablecimiento), currentPage, currentSize)
        '        Case "Aprobado"
        '            currentPage = (currentPage - 1)
        '            ObtenerProyectosFullAPE(CEmpresa, (IdEstablecimiento), currentPage, currentSize)
        '        Case "Ejecucion"
        '            currentPage = (currentPage - 1)
        '            ObtenerProyectosFullAPE(CEmpresa, IdEstablecimiento, currentPage, currentSize)
        '    End Select

        'End If
    End Sub

    Private Sub ToolStripButton5_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton5.Click
        If (txtIndice.Text > 1) Then

            'Select Case Tag
            '    Case "todo"
            '        currentPage = (conteoPaginado - conteoPaginado)
            '        ObtenerProyectosFull(CEmpresa, (IdEstablecimiento), currentPage, currentSize)
            '    Case "AprobaoSinfecha"
            '        currentPage = (conteoPaginado - conteoPaginado)
            '        MostrarProyectoAprobadoSinFecha(CEmpresa, (IdEstablecimiento), currentPage, currentSize)
            '    Case "CarteraSinFecha"
            '        currentPage = (conteoPaginado - conteoPaginado)
            '        ObtenerProyectosDetalleSinFecha(CEmpresa, (IdEstablecimiento), currentPage, currentSize)
            '    Case "Aprobado"
            '        currentPage = (conteoPaginado - conteoPaginado)
            '        ObtenerProyectosFullAPE(CEmpresa, (IdEstablecimiento), currentPage, currentSize)
            '    Case "Ejecucion"
            '        currentPage = (conteoPaginado - conteoPaginado)
            '        ObtenerProyectosFullAPE(CEmpresa, IdEstablecimiento, currentPage, currentSize)
            'End Select

        End If
    End Sub

    Private Sub btnEditarCuenta_Click(sender As System.Object, e As System.EventArgs) Handles btnEditarCuenta.Click
        If lsvListaProyectos.SelectedItems.Count > 0 Then
            If MessageBox.Show("Desea eliminar el proyecto seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                EliminarProyecto()
            End If
        End If
    End Sub
End Class