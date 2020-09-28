Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Grouping
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class UCEncomiendasPorEntregar
    Public listaEncomiendas As List(Of documentoventaTransporte)
#Region "Attributes"
    Public Property ventaSA As New DocumentoventaTransporteSA
    Public Property FormPrincipalSel As UCEncomiendas
    Dim filter As New GridExcelFilter()
#End Region

#Region "Constructors"
    Public Sub New(form As UCEncomiendas)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(GridEncomiendas, True, False, 8.0F)
        FormPrincipalSel = form
        ' FormatoGridAvanzado(GridDetalle, True, False, 10.0F)
        TextFechaPersonal.Value = Date.Now
        BunifuThinButton23.Visible = True
        GetAgencias()
        'Filtros()
    End Sub

#End Region

#Region "Methods"

    Sub Filtros()
        GridEncomiendas.TopLevelGroupOptions.ShowFilterBar = True
        GridEncomiendas.NestedTableGroupOptions.ShowFilterBar = True
        GridEncomiendas.ChildGroupOptions.ShowFilterBar = True
        For Each col As GridColumnDescriptor In GridEncomiendas.TableDescriptor.Columns
            col.AllowFilter = True
        Next
        filter.AllowResize = True
        filter.AllowFilterByColor = True
        filter.EnableDateFilter = True
        filter.EnableNumberFilter = True

        GridEncomiendas.OptimizeFilterPerformance = True
        GridEncomiendas.ShowNavigationBar = True
        filter.WireGrid(GridEncomiendas)
    End Sub

    Private Sub GetCiudadesPendientesDia()
        Dim ventaSA As New DocumentoventaTransporteSA
        GridEncomiendas.Table.Records.DeleteAll()
        'Dim lista = ventaSA.GetCiudadesPorEntregarOrigen(New documentoventaTransporte With
        '                                                 {
        '                                                 .idEmpresa = Gempresas.IdEmpresaRuc,
        '                                                 .idOrganizacion = ComboAgenciaOrigen.SelectedValue,
        '                                                 .estado = Transporte.EncomiendaEstado.PendienteDeEntrega
        '                                                 })

        Dim lista = ventaSA.GetCiudadesPorEntregarOrigenFecha(New documentoventaTransporte With
                                                         {
                                                         .idEmpresa = Gempresas.IdEmpresaRuc,
                                                         .idOrganizacion = ComboAgenciaOrigen.SelectedValue,
                                                         .fechadoc = Date.Now
                                                         }, "PorDia")

        ListCiudades.Items.Clear()
        For Each i In lista
            Dim n As New ListViewItem(i.agenciaDestino_id)
            n.SubItems.Add(i.ciudadDestino)
            n.SubItems.Add(i.TotalPendientes)
            n.SubItems.Add(i.TotalEntregados)
            ListCiudades.Items.Add(n)
        Next
        ListCiudades.Refresh()
    End Sub

    Private Sub GetCiudadesPendientesMes()
        GridEncomiendas.Table.Records.DeleteAll()

        Dim ventaSA As New DocumentoventaTransporteSA

        'Dim lista = ventaSA.GetCiudadesPorEntregarOrigen(New documentoventaTransporte With
        '                                                 {
        '                                                 .idEmpresa = Gempresas.IdEmpresaRuc,
        '                                                 .idOrganizacion = ComboAgenciaOrigen.SelectedValue,
        '                                                 .estado = Transporte.EncomiendaEstado.PendienteDeEntrega
        '                                                 })

        Dim lista = ventaSA.GetCiudadesPorEntregarOrigenFecha(New documentoventaTransporte With
                                                         {
                                                         .idEmpresa = Gempresas.IdEmpresaRuc,
                                                         .idOrganizacion = ComboAgenciaOrigen.SelectedValue,
                                                         .fechadoc = TextFechaPersonal.Value
                                                         }, "PorDia")

        ListCiudades.Items.Clear()
        For Each i In lista
            Dim n As New ListViewItem(i.agenciaDestino_id)
            n.SubItems.Add(i.ciudadDestino)
            n.SubItems.Add(i.TotalPendientes)
            n.SubItems.Add(i.TotalEntregados)
            ListCiudades.Items.Add(n)
        Next
        ListCiudades.Refresh()
    End Sub


    Private Sub GetAgencias()
        Dim agenciaSA As New establecimientoSA
        Dim listaAgencias = Transporte.ListaAgencias ' agenciaSA.ObtenerListaEstablecimientos(Gempresas.IdEmpresaRuc).ToList

        Dim listaAgenciasOrigen = listaAgencias.Where(Function(o) o.TipoEstab = "UN").ToList

        ComboAgenciaOrigen.DataSource = listaAgenciasOrigen
        ComboAgenciaOrigen.DisplayMember = "nombre"
        ComboAgenciaOrigen.ValueMember = "idCentroCosto"
        ComboAgenciaOrigen.Text = GEstableciento.NombreEstablecimiento
    End Sub

    Public Sub GetEncomiendas()
        Dim estado As String = String.Empty
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("fecharecepcion")
        dt.Columns.Add("origen")
        dt.Columns.Add("Emisor")
        dt.Columns.Add("destino")
        dt.Columns.Add("receptor")
        dt.Columns.Add("items")
        dt.Columns.Add("total")
        dt.Columns.Add("estadopago")
        dt.Columns.Add("estado", GetType(Boolean))
        dt.Columns.Add("contenido")
        dt.Columns.Add("costo")
        dt.Columns.Add("secuencia")
        dt.Columns.Add("cantidad")


        Dim codigoCiudadDestino As Integer = Integer.Parse(ListCiudades.SelectedItems(0).SubItems(0).Text)

        listaEncomiendas = ventaSA.GetEncomiendasSelAgenciaDestino(New Business.Entity.documentoventaTransporte With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .agenciaDestino_id = codigoCiudadDestino,
                                                          .fechadoc = Date.Now,
                                                          .estado = Transporte.EncomiendaEstado.PendienteDeEntrega
                                                          })

        Dim consignado As String = String.Empty
        For Each i In listaEncomiendas
            If i.Consignado IsNot Nothing Then
                consignado = i.Consignado
            Else
                consignado = i.comprador
            End If

            Select Case i.estado
                Case Transporte.EncomiendaEstado.PendienteDeEntrega
                    estado = "Pendiente"
                Case Transporte.EncomiendaEstado.Entregado
                    estado = "Entregado"
                Case Transporte.EncomiendaEstado.Abandonado
                    estado = "Abandonado"
                Case Transporte.EncomiendaEstado.Vencido
                    estado = "Vencido"
                Case Transporte.EncomiendaEstado.Otros
                    estado = "otros"

            End Select

            dt.Rows.Add(
                i.idDocumento,
                i.fechadoc,
                i.ciudadOrigen,
                i.Remitente,
                i.ciudadDestino,
                consignado,
                i.itemsEnviados,
                i.total,
               If(i.estadoCobro = "DC", "Cobrado", "Pendiente"),
                True,
i.CustomDocumentoVentaDetalle.detalle,
i.CustomDocumentoVentaDetalle.importe,
i.CustomDocumentoVentaDetalle.secuencia,
i.CustomDocumentoVentaDetalle.cantidad)
        Next
        GridEncomiendas.DataSource = dt
    End Sub

    Public Sub GetEncomiendasPendientesPorMes()
        Dim estado As String = String.Empty
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("fecharecepcion")
        dt.Columns.Add("origen")
        dt.Columns.Add("Emisor")
        dt.Columns.Add("destino")
        dt.Columns.Add("receptor")
        dt.Columns.Add("items")
        dt.Columns.Add("total")
        dt.Columns.Add("estadopago")
        dt.Columns.Add("estado", GetType(Boolean))
        dt.Columns.Add("contenido")
        dt.Columns.Add("costo")
        dt.Columns.Add("secuencia")
        dt.Columns.Add("cantidad")


        Dim codigoCiudadDestino As Integer = Integer.Parse(ListCiudades.SelectedItems(0).SubItems(0).Text)

        listaEncomiendas = ventaSA.GetEncomiendasSelAgenciaDestino(New Business.Entity.documentoventaTransporte With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .agenciaDestino_id = codigoCiudadDestino,
                                                          .fechadoc = TextFechaPersonal.Value,
                                                          .estado = Transporte.EncomiendaEstado.PendienteDeEntrega
                                                          })

        Dim consignado As String = String.Empty
        For Each i In listaEncomiendas
            If i.Consignado IsNot Nothing Then
                consignado = i.Consignado
            Else
                consignado = i.comprador
            End If

            Select Case i.estado
                Case Transporte.EncomiendaEstado.PendienteDeEntrega
                    estado = "Pendiente"
                Case Transporte.EncomiendaEstado.Entregado
                    estado = "Entregado"
                Case Transporte.EncomiendaEstado.Abandonado
                    estado = "Abandonado"
                Case Transporte.EncomiendaEstado.Vencido
                    estado = "Vencido"
                Case Transporte.EncomiendaEstado.Otros
                    estado = "otros"

            End Select

            dt.Rows.Add(
                i.idDocumento,
                i.fechadoc,
                i.ciudadOrigen,
                i.Remitente,
                i.ciudadDestino,
                consignado,
                i.itemsEnviados,
                i.total,
               If(i.estadoCobro = "DC", "Cobrado", "Pendiente"),
                True,
i.CustomDocumentoVentaDetalle.detalle,
i.CustomDocumentoVentaDetalle.importe,
i.CustomDocumentoVentaDetalle.secuencia,
i.CustomDocumentoVentaDetalle.cantidad)
        Next
        GridEncomiendas.DataSource = dt
    End Sub

    Public Sub GetEncomiendasEntregadas()
        Dim estado As String = String.Empty

        Dim codigoCiudadDestino As Integer = Integer.Parse(ListCiudades.SelectedItems(0).SubItems(0).Text)

        Dim lista = ventaSA.GetEncomiendasSelAgenciaDestino(New Business.Entity.documentoventaTransporte With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .agenciaDestino_id = codigoCiudadDestino,
                                                          .fechadoc = Date.Now,
                                                          .estado = Transporte.EncomiendaEstado.Entregado
                                                          })


        ListEntregados.Items.Clear()
        For Each i In lista
            Select Case i.estado
                Case Transporte.EncomiendaEstado.PendienteDeEntrega
                    estado = "Pendiente"
                Case Transporte.EncomiendaEstado.Entregado
                    estado = "Entregado"
                Case Transporte.EncomiendaEstado.Abandonado
                    estado = "Abandonado"
                Case Transporte.EncomiendaEstado.Vencido
                    estado = "Vencido"
                Case Transporte.EncomiendaEstado.Otros
                    estado = "otros"
            End Select

            Dim n As New ListViewItem()
            n.Text = i.CustomDocumentoVentaDetalle.secuencia
            n.SubItems.Add(i.idDocumento)
            n.SubItems.Add(i.fechadoc)
            n.SubItems.Add(i.Remitente)
            n.SubItems.Add(i.ciudadDestino)
            n.SubItems.Add(i.CustomDocumentoVentaDetalle.cantidad)
            n.SubItems.Add(i.CustomDocumentoVentaDetalle.detalle)
            n.SubItems.Add(i.CustomDocumentoVentaDetalle.importe)
            ListEntregados.Items.Add(n)
        Next
        ListEntregados.Refresh()
    End Sub

    '    Public Sub GetEncomiendas()
    '        Dim estado As String = String.Empty
    '        Dim dt As New DataTable
    '        dt.Columns.Add("id")
    '        dt.Columns.Add("fecharecepcion")
    '        dt.Columns.Add("origen")
    '        dt.Columns.Add("Emisor")
    '        dt.Columns.Add("destino")
    '        dt.Columns.Add("receptor")
    '        dt.Columns.Add("items")
    '        dt.Columns.Add("total")
    '        dt.Columns.Add("estadopago")
    '        dt.Columns.Add("estado", GetType(Boolean))
    '        dt.Columns.Add("contenido")
    '        dt.Columns.Add("costo")
    '        dt.Columns.Add("secuencia")
    '        dt.Columns.Add("cantidad")


    '        Dim codigoCiudadDestino As Integer = Integer.Parse(ListCiudades.SelectedItems(0).SubItems(0).Text)

    '        listaEncomiendas = ventaSA.GetEncomiendasSelEstadoEntrega(New Business.Entity.documentoventaTransporte With
    '                                                          {
    '                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
    '                                                          .idOrganizacion = ComboAgenciaOrigen.SelectedValue,
    '                                                          .estado = Transporte.EncomiendaEstado.PendienteDeEntrega
    '                                                          })

    '        For Each i In listaEncomiendas

    '            Select Case i.estado
    '                Case Transporte.EncomiendaEstado.PendienteDeEntrega
    '                    estado = "Pendiente"
    '                Case Transporte.EncomiendaEstado.Entregado
    '                    estado = "Entregado"
    '                Case Transporte.EncomiendaEstado.Abandonado
    '                    estado = "Abandonado"
    '                Case Transporte.EncomiendaEstado.Vencido
    '                    estado = "Vencido"
    '                Case Transporte.EncomiendaEstado.Otros
    '                    estado = "otros"

    '            End Select

    '            dt.Rows.Add(
    '                i.idDocumento,
    '                i.fechadoc,
    '                i.ciudadOrigen,
    '                i.Remitente,
    '                i.ciudadDestino,
    '                i.Consignado,
    '                i.itemsEnviados,
    '                i.total,
    '               If(i.estadoCobro = "DC", "Cobrado", "Pendiente"),
    '                True,
    'i.CustomDocumentoVentaDetalle.detalle,
    'i.CustomDocumentoVentaDetalle.importe,
    'i.CustomDocumentoVentaDetalle.secuencia,
    'i.CustomDocumentoVentaDetalle.cantidad)
    '        Next
    '        GridEncomiendas.DataSource = dt
    '    End Sub

    'Private Sub GetDetalle(intIdDocumento As Integer)
    '    Dim dt As New DataTable
    '    Dim docDetalle = ventaSA.DocumentoTransporteSelID(New documentoventaTransporte With {.idDocumento = intIdDocumento})

    '    dt.Columns.Add("secuencia")
    '    dt.Columns.Add("tipo")
    '    dt.Columns.Add("cantidad")
    '    dt.Columns.Add("detalle")
    '    dt.Columns.Add("importe")

    '    If docDetalle IsNot Nothing Then
    '        For Each i In docDetalle.documentoventaTransporteDetalle.ToList
    '            dt.Rows.Add(i.secuencia, i.tipo, i.cantidad, i.detalle, i.importe)
    '        Next
    '    End If
    '    GridDetalle.DataSource = dt
    'End Sub



    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click
        If GridEncomiendas.Table.Records.Count > 0 Then
            ' ConfirmarEntregas()
            Dim f As New FormConfirmaEntregaEncomiendas(Me, FormPrincipalSel)
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
            GridEncomiendas.Table.Records.DeleteAll()
            BunifuThinButton26_Click(sender, e)
            'ListCiudades_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub ConfirmarEntregas()
        Dim obj As New documentoventaTransporte
        Dim lista As New List(Of documentoventaTransporte)
        For Each i In GridEncomiendas.Table.Records
            obj = New documentoventaTransporte With
            {
            .idDocumento = Integer.Parse(i.GetValue("id"))
            }
            lista.Add(obj)
        Next
        'ventaSA.ActualizarEntrega(lista)
        MessageBox.Show("Encomiendas enviadas correctamente", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)
        GridEncomiendas.Table.Records.DeleteAll()
    End Sub
#End Region

#Region "Events"
    Private Sub GridEncomiendas_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles GridEncomiendas.SelectedRecordsChanged
        Cursor = Cursors.WaitCursor
        Try
            If e.SelectedRecord IsNot Nothing Then
                Dim r As Record = e.SelectedRecord.Record
                If r IsNot Nothing Then
                    If GridEncomiendas.Table.Records.Count > 0 Then
                        '      GetDetalle(Integer.Parse(r.GetValue("id")))
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Atención")
        End Try

        Cursor = Cursors.Default
    End Sub

    Private Sub BunifuThinButton23_Click(sender As Object, e As EventArgs) Handles BunifuThinButton23.Click
        Cursor = Cursors.WaitCursor
        GetCiudadesPendientesMes()
        Cursor = Cursors.Default
    End Sub

    Private Sub ListCiudades_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListCiudades.SelectedIndexChanged
        If ListCiudades.SelectedItems.Count Then
            If BunifuThinButton26.Visible = True Then
                GetEncomiendas()
                GetEncomiendasEntregadas()
            Else
                GetEncomiendasPendientesPorMes()
            End If
        End If
    End Sub

    Private Sub BunifuThinButton26_Click(sender As Object, e As EventArgs) Handles BunifuThinButton26.Click
        Cursor = Cursors.WaitCursor
        GetCiudadesPendientesDia()
        Cursor = Cursors.Default
    End Sub

    Private Sub BunifuiOSSwitch1_OnValueChange(sender As Object, e As EventArgs) Handles BunifuiOSSwitch1.OnValueChange
        If BunifuiOSSwitch1.Value = True Then
            BunifuThinButton26.Visible = False
            TextFechaPersonal.Visible = True
        ElseIf BunifuiOSSwitch1.Value = False Then
            BunifuThinButton26.Visible = True
            TextFechaPersonal.Visible = False
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListEntregados.SelectedIndexChanged

    End Sub

    Private Sub GradientPanel2_Paint(sender As Object, e As PaintEventArgs) Handles GradientPanel2.Paint

    End Sub

    Private Sub UCEncomiendasPorEntregar_Load(sender As Object, e As EventArgs) Handles Me.Load
        GroupBar1.BorderStyle = BorderStyle.None
    End Sub

    Private Sub BunifuThinButton25_Click(sender As Object, e As EventArgs) Handles BunifuThinButton25.Click

    End Sub
#End Region
End Class
