Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmModalActividadesNoActivas

    Public Property Estado As String
#Region "Métodos"


    Public Sub GrabarEnlazados(caso As String)
        Dim ActividadSA As New ActividadesSA
        Dim ActividadLista As New List(Of Actividades)
        Dim objActividad As New Actividades
        Select Case caso
            Case TIPO_ACTIVIDAD_MODULO.ENTREGABLE
                For Each i As ListViewItem In lsvModalBusqueda.CheckedItems
                    objActividad = New Actividades
                    objActividad.NombreActividad = i.SubItems(1).Text
                    objActividad.descripcion = i.SubItems(2).Text
                    objActividad.Observacion = i.SubItems(3).Text
                    objActividad.FechaInicio = i.SubItems(4).Text
                    objActividad.idActividad = i.SubItems(0).Text
                    objActividad.idPadre = lblIdPadre.Text
                    objActividad.Estado = "A"
                    ActividadLista.Add(objActividad)
                Next
            Case TIPO_ACTIVIDAD_MODULO.ACTIVIDAD
                For Each i As ListViewItem In lsvModalBusqueda.CheckedItems
                    objActividad = New Actividades
                    objActividad.idActividad = i.SubItems(0).Text
                    objActividad.NombreActividad = i.SubItems(1).Text
                    objActividad.FechaInicio = i.SubItems(2).Text
                    objActividad.FechaFinal = i.SubItems(3).Text
                    objActividad.idPadre = lblIdPadre.Text
                    objActividad.Estado = "A"
                    ActividadLista.Add(objActividad)
                Next
        End Select


        ActividadSA.UpdateIdPadreActividad(ActividadLista)
        lblEstado.Text = "Items enlazados correctamente!"
        lblEstado.Image = My.Resources.ok4
        Select Case caso
            Case TIPO_ACTIVIDAD_MODULO.ENTREGABLE
                With frmAgrupacionActividades
                    For Each i In ActividadLista
                        .dgvEntregables.Rows.Add(i.idActividad, i.NombreActividad & "° Entregable", i.descripcion, i.Observacion, i.FechaInicio, "0")
                        .ToolStripButton5.Visible = True
                    Next
                End With

            Case TIPO_ACTIVIDAD_MODULO.ACTIVIDAD

        End Select

        Dispose()
    End Sub

    Public Sub ObtenerLIsta(intIdPadre As Integer, strModulo As String)
        Dim actividadSA As New ActividadesSA
        lsvModalBusqueda.Columns.Clear()
        lsvModalBusqueda.Items.Clear()

        Select Case strModulo
            Case TIPO_ACTIVIDAD_MODULO.ENTREGABLE
                lsvModalBusqueda.Columns.Add("", 24)
                lsvModalBusqueda.Columns.Add("Item", 90)
                lsvModalBusqueda.Columns.Add("Concepto", 150)
                lsvModalBusqueda.Columns.Add("Descripción", 178)
                lsvModalBusqueda.Columns.Add("Fecha Entrega", 90)

                For Each i In actividadSA.GetBusquedaActividadGeneralPorEstado(GProyectos.IdProyecto, strModulo, "SA", "AP")
                    Dim n As New ListViewItem(i.idActividad)
                    n.SubItems.Add(i.NombreActividad & "° Entregable")
                    n.SubItems.Add(i.descripcion)
                    n.SubItems.Add(i.Observacion)
                    n.SubItems.Add(FormatDateTime(i.FechaInicio, DateFormat.ShortDate))
                    lsvModalBusqueda.Items.Add(n)
                Next

            Case TIPO_ACTIVIDAD_MODULO.ACTIVIDAD
                lsvModalBusqueda.Columns.Add("", 24) '0
                lsvModalBusqueda.Columns.Add("Actividad", 150) '1
                lsvModalBusqueda.Columns.Add("Inicia", 178) '2
                lsvModalBusqueda.Columns.Add("Finaliza", 90) '3

                For Each i In actividadSA.GetBusquedaActividadGeneralPorEstado(intIdPadre, strModulo, "SA", "A")
                    Dim n As New ListViewItem(i.idActividad)
                    n.SubItems.Add(i.NombreActividad)
                    n.SubItems.Add(i.FechaInicio)
                    n.SubItems.Add(i.FechaFinal)
                    lsvModalBusqueda.Items.Add(n)
                Next
        End Select


    End Sub
#End Region


    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        Dispose()
    End Sub

    Private Sub frmModalActividadesNoActivas_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub lsvModalBusqueda_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lsvModalBusqueda.SelectedIndexChanged

    End Sub

    Private Sub GuardarToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton1.Click
        If lsvModalBusqueda.CheckedItems.Count > 0 Then
            If MessageBox.Show("Desea Registrar elementos enlazados?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                GrabarEnlazados(Estado)
            End If
        Else
            lblEstado.Text = "Debe seleccionar un item"
            lblEstado.Image = My.Resources.warning2
        End If
    End Sub
End Class