Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Transporte

Public Class UCManifestoEnEspera
    Public Property OperacionSel As String

    Public Sub New(UCPantallaEmbarque As UCPantallaEmbarque, Operacion As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Select Case Operacion
            Case "En Espera"
                GetEmbarques(ProgramacionEstado.VentaEnMostrador)
            Case "En Curso"
                GetEmbarques(ProgramacionEstado.VehiculoAsignadoEnCurso)
            Case "Limpiar lista"
                GetEmbarques(ProgramacionEstado.VehiculoAsignadoRutaCulminada)
                'GetPasajerosEmbarque(ListProgramacionEmbarque.SelectedItems)
        End Select
        OperacionSel = Operacion
    End Sub

    Public Sub ConfirmarProgramacionRuta()
        If ListProgramacionEmbarque.SelectedItems.Count > 0 Then
            ListProgramacionEmbarque.SelectedItems(0).Remove()
            ListPasajeros.Items.Clear()
        End If
    End Sub

    Private Sub GetEmbarques(estado As ProgramacionEstado)
        Try
            Dim rutaprogramacionsalidaSA As New RutaProgramacionSalidasSA
            Dim lista = rutaprogramacionsalidaSA.GetProgramacionEstatus(New rutaProgramacionSalidas With {.estado = estado})

            ListProgramacionEmbarque.Items.Clear()
            For Each i In lista
                Dim n As New ListViewItem(i.programacion_id)
                n.SubItems.Add($"DESDE: {i.CustomRutas.ciudadOrigen} HASTA: {i.CustomRutas.ciudadDestino}")
                n.SubItems.Add(i.fechaProgramacion)
                n.SubItems.Add("48")
                n.SubItems.Add(i.Ventas)
                n.SubItems.Add(i.Reservas)
                ListProgramacionEmbarque.Items.Add(n)
            Next
            ListProgramacionEmbarque.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ListProgramacionEmbarque_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListProgramacionEmbarque.SelectedIndexChanged
        If ListProgramacionEmbarque.SelectedItems.Count > 0 Then
            Select Case OperacionSel
                Case "En Espera"
                    GetPasajerosEmbarque(ListProgramacionEmbarque.SelectedItems)
                    GetEncomiendasEmbarque(ListProgramacionEmbarque.SelectedItems)
                Case "En Curso"
                    GetPasajerosEnCurso(ListProgramacionEmbarque.SelectedItems)
                Case "Limpiar lista"
                    GetPasajerosEnCulminado(ListProgramacionEmbarque.SelectedItems)
            End Select

        End If
    End Sub

    Private Sub GetPasajerosEmbarque(selectedItems As ListView.SelectedListViewItemCollection)
        Try
            Dim embarqueSA As New VehiculoAsiento_PreciosSA
            Dim lista = embarqueSA.GetConsultarEnviosPorProgramacion(New vehiculoAsiento_Precios With
                                                                     {
                                                                     .programacion_id = Integer.Parse(selectedItems(0).SubItems(0).Text)
                                                                     })

            ListPasajeros.Items.Clear()
            For Each i In lista
                Dim n As New ListViewItem(i.idComponente)
                n.Checked = True
                n.SubItems.Add(i.CustomPersona.codigo)
                n.SubItems.Add(i.CustomPersona.nombreCompleto)
                n.SubItems.Add(i.CustomPersona.idPersona)
                n.SubItems.Add(i.CustomRuta.ciudadDestino)
                n.SubItems.Add($"{i.CustomDocumentoVentaTransporte.serie}-{i.CustomDocumentoVentaTransporte.numero}")
                n.SubItems.Add(i.CustomDocumentoVentaTransporte.total)
                n.SubItems.Add(i.CustomRuta_HorarioServicios.codigoServicio)
                n.SubItems.Add(i.CustomRuta_HorarioServicios.descripcionLarga)
                n.SubItems.Add(i.CustomDocumentoVentaTransporte.idDocumento)
                ListPasajeros.Items.Add(n)
            Next
            ListPasajeros.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GetEncomiendasEmbarque(selectedItems As ListView.SelectedListViewItemCollection)
        Try
            Dim embarqueSA As New DocumentoventaTransporteSA
            Dim lista = embarqueSA.GetConsultaEncomiendasFechaProgramada(New documentoventaTransporte With
                                                                     {
                                                                     .idEmpresa = General.Gempresas.IdEmpresaRuc,
                                                                     .idOrganizacion = General.GEstableciento.IdEstablecimiento,
                                                                     .programacion_id = Integer.Parse(selectedItems(0).SubItems(0).Text)
                                                                     })

            ListEncomiendas.Items.Clear()
            Dim contenidos As String = String.Empty
            For Each i In lista

                For Each det In i.documentoventaTransporteDetalle
                    If contenidos IsNot Nothing Then
                        contenidos = contenidos & ", " & det.detalle
                    Else
                        contenidos = contenidos
                    End If
                Next

                Dim n As New ListViewItem(i.idDocumento)
                n.Checked = True
                n.SubItems.Add(i.razonSocial)
                n.SubItems.Add(i.Remitente)
                n.SubItems.Add(i.ciudadOrigen)
                n.SubItems.Add(i.idPersona)
                n.SubItems.Add(i.Consignado)
                n.SubItems.Add(i.ciudadDestino)
                n.SubItems.Add(contenidos)
                n.SubItems.Add(i.total)
                n.SubItems.Add(i.estadoCobro)
                ListEncomiendas.Items.Add(n)
            Next
            ListEncomiendas.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GetPasajerosEnCurso(selectedItems As ListView.SelectedListViewItemCollection)
        Try
            Dim embarqueSA As New RutaTareoDetalleSA
            Dim lista = embarqueSA.GetProgamacionEnCurso(New rutaProgramacionSalidas With
                                                                     {
                                                                     .programacion_id = Integer.Parse(selectedItems(0).SubItems(0).Text)
                                                                     })

            ListPasajeros.Items.Clear()
            For Each i In lista
                Dim n As New ListViewItem(i.idComponente)
                n.Tag = i.idDistribucion
                n.Checked = True
                n.SubItems.Add(i.CustomPersona.codigo)
                n.SubItems.Add(i.CustomPersona.nombreCompleto)
                n.SubItems.Add(i.CustomPersona.idPersona)
                n.SubItems.Add(i.CustomRuta.ciudadDestino)
                n.SubItems.Add($"{i.CustomDocumentoVentaTransporte.serie}-{i.CustomDocumentoVentaTransporte.numero}")
                n.SubItems.Add(i.CustomDocumentoVentaTransporte.total)
                n.SubItems.Add(i.CustomRuta_HorarioServicios.codigoServicio)
                n.SubItems.Add(i.CustomRuta_HorarioServicios.descripcionLarga)
                n.SubItems.Add(i.CustomDocumentoVentaTransporte.idDocumento)
                ListPasajeros.Items.Add(n)
            Next
            ListPasajeros.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GetPasajerosEnCulminado(selectedItems As ListView.SelectedListViewItemCollection)
        Try
            Dim embarqueSA As New RutaTareoDetalleSA
            Dim lista = embarqueSA.GetProgamacionEnCurso(New rutaProgramacionSalidas With
                                                                     {
                                                                     .programacion_id = Integer.Parse(selectedItems(0).SubItems(0).Text)
                                                                     })

            Dim listaCulminados = lista.Where(Function(o) o.CustomrutaTareoAutos.tipoTareo = General.Transporte.TipotareoGeneral.LlegadaAdestino).ToList

            ListPasajeros.Items.Clear()
            For Each i In listaCulminados
                Dim n As New ListViewItem(i.idComponente)
                n.Tag = i.idDistribucion
                n.Checked = True
                n.SubItems.Add(i.CustomPersona.codigo)
                n.SubItems.Add(i.CustomPersona.nombreCompleto)
                n.SubItems.Add(i.CustomPersona.idPersona)
                n.SubItems.Add(i.CustomRuta.ciudadDestino)
                n.SubItems.Add($"{i.CustomDocumentoVentaTransporte.serie}-{i.CustomDocumentoVentaTransporte.numero}")
                n.SubItems.Add(i.CustomDocumentoVentaTransporte.total)
                n.SubItems.Add(i.CustomRuta_HorarioServicios.codigoServicio)
                n.SubItems.Add(i.CustomRuta_HorarioServicios.descripcionLarga)
                n.SubItems.Add(i.CustomDocumentoVentaTransporte.idDocumento)
                ListPasajeros.Items.Add(n)
            Next
            ListPasajeros.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ListEncomiendas_MouseMove(sender As Object, e As MouseEventArgs) Handles ListEncomiendas.MouseMove
        Dim thisItem As ListViewItem = ListEncomiendas.GetItemAt(e.X, e.Y)
        Dim a As New ToolTip
        If Not thisItem Is Nothing Then
            a.SetToolTip(ListEncomiendas, thisItem.Text)
        Else
            a.SetToolTip(ListEncomiendas, "")
        End If
    End Sub

    Private Sub ListEncomiendas_DrawItem(sender As Object, e As DrawListViewItemEventArgs) Handles ListEncomiendas.DrawItem

    End Sub

    Private Sub ListEncomiendas_MouseLeave(sender As Object, e As EventArgs) Handles ListEncomiendas.MouseLeave
        Dim a As New ToolTip
        a.SetToolTip(ListEncomiendas, "")
    End Sub
End Class
