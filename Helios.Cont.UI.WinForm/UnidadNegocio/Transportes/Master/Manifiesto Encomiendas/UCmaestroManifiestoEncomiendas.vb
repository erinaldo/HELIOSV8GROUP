Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.GroupingGridExcelConverter

Public Class UCmaestroManifiestoEncomiendas
    Private listaAgencias As List(Of centrocosto)
#Region "Constructors"
    Public Sub New(UCEncomiendas As UCEncomiendas)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(GridEncomiendas, True, False, 8.0F)
        'ComboAgenciaDestino.Enabled = True
        'BunifuThinButton23.Visible = True
        'BunifuThinButton23.Enabled = True
        GetAgencias()
    End Sub
#End Region

#Region "Methods"
    Private Sub GetAgencias()
        Dim agenciaSA As New establecimientoSA
        listaAgencias = agenciaSA.ObtenerListaEstablecimientos(Gempresas.IdEmpresaRuc).ToList

        Dim listaAgenciasOrigen = listaAgencias.Where(Function(o) o.TipoEstab = "UN").ToList

        ComboAgenciaOrigen.DataSource = listaAgenciasOrigen
        ComboAgenciaOrigen.DisplayMember = "nombre"
        ComboAgenciaOrigen.ValueMember = "idCentroCosto"
        ComboAgenciaOrigen.Text = GEstableciento.NombreEstablecimiento
    End Sub
#End Region

#Region "Events"
    Private Sub ComboAgenciaOrigen_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboAgenciaOrigen.SelectedValueChanged
        Try
            If IsNumeric(ComboAgenciaOrigen.SelectedValue) Then

                Dim lista = listaAgencias.Where(Function(o) o.TipoEstab = "UN" And o.idCentroCosto <> ComboAgenciaOrigen.SelectedValue).ToList

                ComboAgenciaDestino.DataSource = lista
                ComboAgenciaDestino.DisplayMember = "nombre"
                ComboAgenciaDestino.ValueMember = "idCentroCosto"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub BunifuThinButton23_Click(sender As Object, e As EventArgs) Handles BunifuThinButton23.Click
        GridEncomiendas.Table.Records.DeleteAll()
        ListDetalle.Items.Clear()

        GetDetalleEnvios(Integer.Parse(ComboAgenciaOrigen.SelectedValue), Integer.Parse(ComboAgenciaDestino.SelectedValue))
    End Sub

    Private Sub GetDetalleEnvios(Origen As Integer, Destino As Integer)
        Dim detalleSA As New RutaTareoEncomiendaSA

        ListDetalle.Items.Clear()
        Dim lista = detalleSA.GetTareoEncomiendasSelCiudadDestino(New rutaTareoEncomienda With
                                                                  {
                                                                  .agenciaOrigen_id = Origen,
                                                                  .agenciaDestino_id = Destino
                                                                  }).OrderByDescending(Function(O) O.fechaEnvio).ToList

        For Each i In lista
            Dim n As New ListViewItem(i.tareo_id)
            n.UseItemStyleForSubItems = True
            With n.SubItems.Add(i.fechaEnvio)
                .BackColor = Color.LavenderBlush
                .ForeColor = Color.DarkRed
                .Font = New Font("Segoe UI", 8.0, FontStyle.Bold)
            End With
            n.SubItems.Add(i.chofer)
            n.SubItems.Add(i.matriculaUnidad)
            ListDetalle.Items.Add(n)
        Next
        ListDetalle.Refresh()
    End Sub

    Private Sub ListDetalle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListDetalle.SelectedIndexChanged
        Cursor = Cursors.WaitCursor
        If ListDetalle.SelectedItems.Count > 0 Then
            GetDetalleTareo(Integer.Parse(ListDetalle.SelectedItems(0).SubItems(0).Text))
        Else
            'ListDetalle.Items.Clear()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GetDetalleTareo(tareo_id As Integer)
        Dim detalleSA As New RutaTareoEncomiendaDetalleSA
        Dim lista = detalleSA.rutaTareoEncomiendaDetalleSelID(New rutaTareoEncomiendaDetalle With {.tareo_id = tareo_id})
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("fecharecepcion")
        dt.Columns.Add("Emisor")
        dt.Columns.Add("receptor")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("contenido")
        dt.Columns.Add("costo")

        Dim comprador = String.Empty

        For Each i In lista
            If i.consignado IsNot Nothing Then
                comprador = i.consignado
            Else
                comprador = i.CustomVenta.comprador
            End If
            dt.Rows.Add(i.secuencia, i.CustomVenta.fechadoc, i.remitente, comprador, i.cantidad, i.contenido, i.costo)
        Next
        GridEncomiendas.DataSource = dt
    End Sub

    Private Sub BunifuThinButton24_Click(sender As Object, e As EventArgs) Handles BunifuThinButton24.Click
        Dim converter As New GroupingGridExcelConverterControl

        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "Files(*.xls)|*.xls"
        saveFileDialog.DefaultExt = ".xls"


        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            'If radioButton1.Checked Then
            converter.GroupingGridToExcel(Me.GridEncomiendas, saveFileDialog.FileName, Syncfusion.GridExcelConverter.ConverterOptions.Visible)
            'ElseIf radioButton2.Checked Then
            '    converter.GroupingGridToExcel(Me.GridGroupingControl1, saveFileDialog.FileName, Syncfusion.GridExcelConverter.ConverterOptions.[Default])
            'End If

            If MessageBox.Show("Desea abrir el archivo ahora?", "Export to Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim proc As New Process()
                proc.StartInfo.FileName = saveFileDialog.FileName
                proc.Start()
            End If
        End If
    End Sub



    'Public Sub Imprimir()
    '    ' Dim tareoSA As New RutaTareoAutoSA
    '    Dim tareoSA As New RutaTareoEncomiendaSA
    '    Dim detalleSA As New RutaTareoEncomiendaDetalleSA

    '    Dim lista = detalleSA.rutaTareoEncomiendaDetalleSelID(New rutaTareoEncomiendaDetalle With {.tareo_id = Integer.Parse(ListDetalle.SelectedItems(0).SubItems(0).Text)})

    '    Dim tareo = tareoSA.rutaTareoEncomiendaSelID(New rutaTareoEncomienda With
    '                                    {
    '                                    .tareo_id = Integer.Parse(ListDetalle.SelectedItems(0).SubItems(0).Text)
    '                                    })


    '    Dim a As ImpresionTransportes = New ImpresionTransportes
    '    ' Logo de la Empresa

    '    Dim gravMN As Decimal = 0
    '    Dim gravME As Decimal = 0
    '    Dim ExoMN As Decimal = 0
    '    Dim ExoME As Decimal = 0
    '    Dim InaMN As Decimal = 0
    '    Dim InaME As Decimal = 0


    '    Dim tipoComprobante As String = String.Empty


    '    a.AnadirLineaEmpresa("RELACION DE ENCOMIENDAS CARTAS Y GIROS")

    '    '//*************************
    '    'direccion de la empresa
    '    Dim fecha = CType(ListDetalle.SelectedItems(0).SubItems(1).Text, DateTime?)

    '    a.TextoIzquierda("FECHA: " & fecha.Value.ToShortDateString)
    '    a.TextoIzquierda("HORA: " & fecha.Value.ToShortTimeString)
    '    a.TextoIzquierda("UNIDAD - VEHICULO: " & tareo.Matricula)
    '    a.TextoIzquierda("CONDUCTOR: " & tareo.CustomPerson.nombreCompleto)
    '    a.TextoIzquierda("ORIGEN: " & ComboAgenciaOrigen.Text)
    '    a.TextoIzquierda("DESTINO: " & ComboAgenciaDestino.Text)



    '    '*********************** TODO LOS DETALLES DE LOS ITEM *********************
    '    'CODIGO
    '    'DESCRIPCION
    '    'CANTIDAD
    '    'UM
    '    'VALOR VENTA UNITARIO
    '    'DESCUENTO
    '    'VALOR DE VENTA TOTAL
    '    'OTROS CARGOS
    '    'IMPUESTOS
    '    'PRECIO DE VENTA
    '    'VALOR TOTAL


    '    'a.AnadirLineaElementosFactura(1, "NOMBRE PRODUCTO numero 1 DE MAYKOL CHARLY  SANCHEZ CORIS  001", "5", "UND", 15.0, "0.00", 10.0, "0.00", 0.18, 15.0, 30.0)
    '    Dim tipo As String = String.Empty
    '    Dim comprador = String.Empty
    '    For Each i In lista
    '        Select Case i.tipo
    '            Case "P"
    '                tipo = "PAQUETE"
    '            Case "S"
    '                tipo = "SOBRE"
    '            Case "C"
    '                tipo = "CAJA"
    '            Case "CO"
    '                tipo = "S/COSTAL"
    '            Case "O"
    '                tipo = "OTRO"
    '        End Select

    '        If i.consignado IsNot Nothing Then
    '            comprador = i.consignado
    '        Else
    '            comprador = i.CustomVenta.comprador
    '        End If

    '        a.AnadirLineaElementosEncomienda($"{i.CustomVenta.serie}-{i.CustomVenta.numero}",
    '                                         i.remitente,
    '                                         comprador,
    '                                         i.cantidad,
    '                                         i.contenido,
    '                                         tipo, i.costo, Date.Now)
    '    Next
    '    'a.AnadirLineaElementosEncomienda("b001-2145", "MAYKOL CHARLY SANCHEZ CORIS", "JIUNI PALACIONS SANTOS", "15.00", "COSTAL DE FRUTAS", "PAQUETE", "10.00", Date.Now)
    '    'ComboPrint.Text
    '    a.ImprimeTicket("TICKET/RUTA")
    '    'a.ImprimeTicket("PDF24 PDF")

    'End Sub

    Public Sub Imprimir(Envio As rutaTareoEncomienda)
        ' Dim tareoSA As New RutaTareoAutoSA
        Dim tareoSA As New RutaTareoEncomiendaSA
        Dim detalleSA As New RutaTareoEncomiendaDetalleSA
        Dim activoSA As New ActivosFijosSA
        Dim PersonaSA As New PersonaSA
        'Dim lista = detalleSA.rutaTareoEncomiendaDetalleSelFecha(New rutaTareoEncomienda With {.tareo_id = Integer.Parse(ListDetalle.SelectedItems(0).SubItems(0).Text)})

        'Dim tareo = tareoSA.rutaTareoEncomiendaSelID(New rutaTareoEncomienda With
        '                                {
        '                                .tareo_id = Integer.Parse(ListDetalle.SelectedItems(0).SubItems(0).Text)
        '                                })


        'Dim lista2 = detalleSA.rutaTareoEncomiendaDetalleSelFechaV2(
        '    Envio.fechaEnvio,
        '    Integer.Parse(ComboAgenciaOrigen.SelectedValue), Integer.Parse(ComboAgenciaDestino.SelectedValue))

        ',      .tripulante1 = Envio.tripulante1

        Dim lista2 = detalleSA.rutaTareoEncomiendaDetalleSelFecha(
            New rutaTareoEncomienda With {
            .agenciaOrigen_id = Integer.Parse(ComboAgenciaOrigen.SelectedValue),
            .agenciaDestino_id = Integer.Parse(ComboAgenciaDestino.SelectedValue),
            .fechaEnvio = Envio.fechaEnvio
            })

        If lista2.Count > 0 Then

            'Dim CodeVehiculo = lista2.FirstOrDefault.rutaTareoEncomienda.idVehiculo
            'Dim bus = activoSA.GetUbicar_activosFijosPorID(CodeVehiculo)
            'Dim tripulante = PersonaSA.EmpresasSelPerona(Gempresas.IdEmpresaRuc, lista2.FirstOrDefault.rutaTareoEncomienda.tripulante1).ToList.FirstOrDefault

            Dim a As ImpresionTransportesA5V2 = New ImpresionTransportesA5V2
            ' Logo de la Empresa

            Dim gravMN As Decimal = 0
            Dim gravME As Decimal = 0
            Dim ExoMN As Decimal = 0
            Dim ExoME As Decimal = 0
            Dim InaMN As Decimal = 0
            Dim InaME As Decimal = 0


            Dim tipoComprobante As String = String.Empty


            a.AnadirLineaEmpresa("RELACION DE ENCOMIENDAS CARTAS Y GIROS")

            '//*************************
            'direccion de la empresa
            'Dim fecha = CType(ListDetalle.SelectedItems(0).SubItems(1).Text, DateTime?)

            'a.TextoIzquierda("FECHA: " & Date.Now.ToShortDateString)
            'a.TextoIzquierda("HORA: " & Date.Now.ToShortTimeString)
            'a.TextoIzquierda("UNIDAD - VEHICULO: " & Envio.UnidadVehiculo) ' bus.nroSeriePlaca)
            'a.TextoIzquierda("CONDUCTOR: " & Envio.Tripulante) ' tripulante.nombreCompleto)
            'a.TextoIzquierda("ORIGEN: " & ComboAgenciaOrigen.Text)
            'a.TextoIzquierda("DESTINO: " & ComboAgenciaDestino.Text)

            Dim HORA As String = Date.Now.ToShortTimeString
            Dim FECHAENVIO As String = Date.Now.ToShortDateString
            a.AnadirLineaCabeza($"{"FECHA: "}{FECHAENVIO}                                                       {"HORA: "}{HORA}                                              {"UNIDAD: "}{Envio.UnidadVehiculo}")
            a.AnadirLineaCabeza($"{"ORIGEN: "}{ComboAgenciaOrigen.Text}                                                     {"DESTINO: "}{ComboAgenciaDestino.Text}")

            '*********************** TODO LOS DETALLES DE LOS ITEM *********************
            'CODIGO
            'DESCRIPCION
            'CANTIDAD
            'UM
            'VALOR VENTA UNITARIO
            'DESCUENTO
            'VALOR DE VENTA TOTAL
            'OTROS CARGOS
            'IMPUESTOS
            'PRECIO DE VENTA
            'VALOR TOTAL


            'a.AnadirLineaElementosFactura(1, "NOMBRE PRODUCTO numero 1 DE MAYKOL CHARLY  SANCHEZ CORIS  001", "5", "UND", 15.0, "0.00", 10.0, "0.00", 0.18, 15.0, 30.0)
            Dim tipo As String = String.Empty
            Dim comprador = String.Empty
            For Each i In lista2
                Select Case i.tipo
                    Case "P"
                        tipo = "PAQUETE"
                    Case "S"
                        tipo = "SOBRE"
                    Case "C"
                        tipo = "CAJA"
                    Case "CO"
                        tipo = "S/COSTAL"
                    Case "O"
                        tipo = "OTRO"
                End Select

                If i.consignado IsNot Nothing Then
                    comprador = i.consignado
                Else
                    comprador = i.CustomVenta.comprador
                End If

                'a.AnadirLineaElementosEncomienda($"{i.CustomVenta.serie}-{i.CustomVenta.numero}",
                '                                 i.remitente,
                '                                 comprador,
                '                                 i.cantidad,
                '                                 i.contenido,
                '                                 tipo, i.costo, Date.Now)


                a.AnadirLineaElementosEncomienda($"{i.CustomVenta.serie}-{i.CustomVenta.numero}",
                                              "",
                                               comprador,
                                               i.cantidad,
                                               tipo,
                                               i.contenido,
                                               i.costo, "")

            Next
            'a.AnadirLineaElementosEncomienda("b001-2145", "MAYKOL CHARLY SANCHEZ CORIS", "JIUNI PALACIONS SANTOS", "15.00", "COSTAL DE FRUTAS", "PAQUETE", "10.00", Date.Now)
            'ComboPrint.Text
            a.ImprimeTicket("TICKET/RUTA")
            'a.ImprimeTicket("PDF24 PDF")
        Else
            MessageBox.Show("No hay datos para esta consulta!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Public Sub Imprimir(IDTareo As Integer, Envio As rutaTareoEncomienda)
        ' Dim tareoSA As New RutaTareoAutoSA
        Dim tareoSA As New RutaTareoEncomiendaSA
        Dim detalleSA As New RutaTareoEncomiendaDetalleSA
        Dim activoSA As New ActivosFijosSA
        Dim PersonaSA As New PersonaSA
        'Dim lista = detalleSA.rutaTareoEncomiendaDetalleSelFecha(New rutaTareoEncomienda With {.tareo_id = Integer.Parse(ListDetalle.SelectedItems(0).SubItems(0).Text)})

        Dim lista2 = detalleSA.rutaTareoEncomiendaDetalleSelID(New rutaTareoEncomiendaDetalle With
                                        {
                                        .tareo_id = IDTareo
                                        })


        'Dim lista2 = detalleSA.rutaTareoEncomiendaDetalleSelFechaV2(
        '    Envio.fechaEnvio,
        '    Integer.Parse(ComboAgenciaOrigen.SelectedValue), Integer.Parse(ComboAgenciaDestino.SelectedValue))

        ',      .tripulante1 = Envio.tripulante1

        'Dim lista2 = detalleSA.rutaTareoEncomiendaDetalleSelFecha(
        '    New rutaTareoEncomienda With {
        '    .agenciaOrigen_id = Integer.Parse(ComboAgenciaOrigen.SelectedValue),
        '    .agenciaDestino_id = Integer.Parse(ComboAgenciaDestino.SelectedValue),
        '    .fechaEnvio = Envio.fechaEnvio
        '    })

        If lista2.Count > 0 Then

            'Dim CodeVehiculo = lista2.FirstOrDefault.rutaTareoEncomienda.idVehiculo
            'Dim bus = activoSA.GetUbicar_activosFijosPorID(CodeVehiculo)
            'Dim tripulante = PersonaSA.EmpresasSelPerona(Gempresas.IdEmpresaRuc, lista2.FirstOrDefault.rutaTareoEncomienda.tripulante1).ToList.FirstOrDefault

            Dim a As ImpresionTransportesA5V2 = New ImpresionTransportesA5V2
            ' Logo de la Empresa

            Dim gravMN As Decimal = 0
            Dim gravME As Decimal = 0
            Dim ExoMN As Decimal = 0
            Dim ExoME As Decimal = 0
            Dim InaMN As Decimal = 0
            Dim InaME As Decimal = 0


            Dim tipoComprobante As String = String.Empty


            a.AnadirLineaEmpresa("RELACION DE ENCOMIENDAS CARTAS Y GIROS")

            '//*************************
            'direccion de la empresa
            Dim fecha = CType(ListDetalle.SelectedItems(0).SubItems(1).Text, DateTime?)

            'a.TextoIzquierda("FECHA: " & fecha.Value.ToShortDateString)
            'a.TextoIzquierda("HORA: " & fecha.Value.ToShortTimeString)
            'a.TextoIzquierda("UNIDAD - VEHICULO: " & Envio.UnidadVehiculo) ' bus.nroSeriePlaca)
            'a.TextoIzquierda("CONDUCTOR: " & Envio.Tripulante) ' tripulante.nombreCompleto)
            'a.TextoIzquierda("ORIGEN: " & ComboAgenciaOrigen.Text)
            'a.TextoIzquierda("DESTINO: " & ComboAgenciaDestino.Text)

            Dim FECHAENVIO As String = fecha.Value.ToShortDateString
            Dim HORA As String = fecha.Value.ToShortTimeString
            a.AnadirLineaCabeza($"{"FECHA: "}{FECHAENVIO}                                                       {"HORA: "}{HORA}                                              {"UNIDAD: "}{Envio.UnidadVehiculo}")
            a.AnadirLineaCabeza($"{"ORIGEN: "}{ComboAgenciaOrigen.Text}                                                     {"DESTINO: "}{ComboAgenciaDestino.Text}")



            '*********************** TODO LOS DETALLES DE LOS ITEM *********************
            'CODIGO
            'DESCRIPCION
            'CANTIDAD
            'UM
            'VALOR VENTA UNITARIO
            'DESCUENTO
            'VALOR DE VENTA TOTAL
            'OTROS CARGOS
            'IMPUESTOS
            'PRECIO DE VENTA
            'VALOR TOTAL


            'a.AnadirLineaElementosFactura(1, "NOMBRE PRODUCTO numero 1 DE MAYKOL CHARLY  SANCHEZ CORIS  001", "5", "UND", 15.0, "0.00", 10.0, "0.00", 0.18, 15.0, 30.0)
            Dim tipo As String = String.Empty
            Dim comprador = String.Empty
            For Each i In lista2
                Select Case i.tipo
                    Case "P"
                        tipo = "PAQUETE"
                    Case "S"
                        tipo = "SOBRE"
                    Case "C"
                        tipo = "CAJA"
                    Case "CO"
                        tipo = "S/COSTAL"
                    Case "O"
                        tipo = "OTRO"
                End Select

                If i.consignado IsNot Nothing Then
                    comprador = i.consignado
                Else
                    comprador = i.CustomVenta.comprador
                End If

                'a.AnadirLineaElementosEncomienda($"{i.CustomVenta.serie}-{i.CustomVenta.numero}",
                '                                 i.remitente,
                '                                 comprador,
                '                                 i.cantidad,
                '                                 i.contenido,
                '                                 tipo, i.costo, Date.Now)

                a.AnadirLineaElementosEncomienda($"{i.CustomVenta.serie}-{i.CustomVenta.numero}",
                                        "",
                                         comprador,
                                         i.cantidad,
                                         tipo,
                                         i.contenido,
                                         i.costo, "")
            Next
            'a.AnadirLineaElementosEncomienda("b001-2145", "MAYKOL CHARLY SANCHEZ CORIS", "JIUNI PALACIONS SANTOS", "15.00", "COSTAL DE FRUTAS", "PAQUETE", "10.00", Date.Now)
            'ComboPrint.Text
            a.ImprimeTicket("TICKET/RUTA")
            'a.ImprimeTicket("PDF24 PDF")
        Else
            MessageBox.Show("No hay datos para esta consulta!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub


    Private Sub UCmaestroManifiestoEncomiendas_Load(sender As Object, e As EventArgs) Handles Me.Load
        '     Dim instance As New Printing
        Dim instance As New Printing.PrinterSettings
        Dim impresosaPredt As String = instance.PrinterName
        For Each item As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            ComboPrint.Items.Add(item.ToString)
        Next
        If ComboPrint.Items.Count > 0 Then
            ComboPrint.SelectedText = impresosaPredt
        End If
    End Sub

    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click
        Try
            If ComboAgenciaDestino.Text.Trim.Length > 0 Then
                Dim f As New FormImpresionManifiestoDia
                f.TextChoferTripulante.Text = ListDetalle.SelectedItems(0).SubItems(2).Text
                f.TextUnidadVehiculo.Text = ListDetalle.SelectedItems(0).SubItems(3).Text
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog(Me)
                If f.Tag IsNot Nothing Then
                    Dim Envio = CType(f.Tag, rutaTareoEncomienda)

                    Select Case Envio.TipoImpresion
                        Case "ACU"
                            Imprimir(Envio)
                        Case "HIS"
                            Imprimir(Integer.Parse(ListDetalle.SelectedItems(0).Text), Envio)
                    End Select
                End If
            Else
                MessageBox.Show("Debe seleccionar un destino!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ComboAgenciaDestino.Select()
                ComboAgenciaDestino.DroppedDown = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub ComboAgenciaDestino_Click(sender As Object, e As EventArgs) Handles ComboAgenciaDestino.Click

    End Sub

    Private Sub ComboAgenciaDestino_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboAgenciaDestino.SelectedValueChanged
        GridEncomiendas.Table.Records.DeleteAll()
        ListDetalle.Items.Clear()

        If IsNumeric(ComboAgenciaDestino.SelectedValue) Then
            GetDetalleEnvios(Integer.Parse(ComboAgenciaOrigen.SelectedValue), Integer.Parse(ComboAgenciaDestino.SelectedValue))
        End If
    End Sub

    Private Sub GradientPanel2_Paint(sender As Object, e As PaintEventArgs) Handles GradientPanel2.Paint

    End Sub
#End Region
End Class
