Imports Helios.General
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Cont.Business.Entity

Public Class UCResumenVentasCustom

#Region "Attributes"
    Private estableSA As New establecimientoSA
    Private UCReporteFechaPeriodoVenta As UCReporteFechaPeriodoVenta
    Private UCReporteVentaProductos As UCReporteVentaProductos
    Private UCVentaProductosAcumulado As UCVentaProductosAcumulado
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        '        GetCombos()
        txtFecha.Value = Date.Now
    End Sub
#End Region

#Region "Methods"
    Public Sub GetCombos()
        cboMesPedido.DisplayMember = "Mes"
        cboMesPedido.ValueMember = "Codigo"
        cboMesPedido.DataSource = ListaDeMeses()
        cboMesPedido.SelectedValue = String.Format("{0:00}", DateTime.Now.Month)
        cboAnio.Text = DateTime.Now.Year


        Dim lista = estableSA.ObtenerListaEstablecimientos(Gempresas.IdEmpresaRuc).Where(Function(o) o.TipoEstab = "UN" And o.idCentroCosto = GEstableciento.IdEstablecimiento).ToList

        ComboUnidad.DataSource = lista
        ComboUnidad.ValueMember = "idCentroCosto"
        ComboUnidad.DisplayMember = "nombre"
        ComboUnidad.SelectedValue = GEstableciento.IdEstablecimiento

        ComboUsuarios.DataSource = UsuariosList
        ComboUsuarios.ValueMember = "IDUsuario"
        ComboUsuarios.DisplayMember = "Nombres"
    End Sub
#End Region

#Region "Events"
    Private Sub BunifuiOSSwitch1_OnValueChange(sender As Object, e As EventArgs) Handles BunifuiOSSwitch1.OnValueChange
        If BunifuiOSSwitch1.Value = True Then
            txtFecha.Visible = False
        ElseIf BunifuiOSSwitch1.Value = False Then
            txtFecha.Visible = True
        End If
    End Sub

    Private Sub BunifuThinButton23_Click(sender As Object, e As EventArgs) Handles BunifuThinButton23.Click
        panel5.Controls.Clear()
        PictureLoad.Visible = True

        Select Case ComboReporte.Text
            Case "VENTA POR DIA"
                UCReporteFechaPeriodoVenta = New UCReporteFechaPeriodoVenta(txtFecha.Value, ComboUnidad.SelectedValue, Me) With {.Dock = DockStyle.Fill}
                panel5.Controls.Add(UCReporteFechaPeriodoVenta)
            Case "VENTA POR MES"
                Dim periodo = String.Format("{0:00}", CInt(cboMesPedido.SelectedValue)) & "/" & cboAnio.Text
                UCReporteFechaPeriodoVenta = New UCReporteFechaPeriodoVenta(periodo, Me, ComboUnidad.SelectedValue) With {.Dock = DockStyle.Fill}
                panel5.Controls.Add(UCReporteFechaPeriodoVenta)
            Case "VENTA POR VENDEDOR"
                Select Case BunifuiOSSwitch1.Value
                    Case True 'periodo
                        Dim periodo = String.Format("{0:00}", CInt(cboMesPedido.SelectedValue)) & "/" & cboAnio.Text

                        Dim obj As New documentoventaAbarrotes
                        obj.fechaPeriodo = periodo
                        obj.idEstablecimiento = ComboUnidad.SelectedValue
                        obj.usuarioActualizacion = ComboUsuarios.SelectedValue
                        obj.tipoDocumento = 0

                        UCReporteFechaPeriodoVenta = New UCReporteFechaPeriodoVenta(obj, "PERIODO", Me) With {.Dock = DockStyle.Fill}
                        panel5.Controls.Add(UCReporteFechaPeriodoVenta)
                    Case False

                        Dim obj As New documentoventaAbarrotes
                        obj.fechaDoc = txtFecha.Value
                        obj.idEstablecimiento = ComboUnidad.SelectedValue
                        obj.usuarioActualizacion = ComboUsuarios.SelectedValue
                        obj.tipoDocumento = 0
                        UCReporteFechaPeriodoVenta = New UCReporteFechaPeriodoVenta(obj, "DIA", Me) With {.Dock = DockStyle.Fill}
                        panel5.Controls.Add(UCReporteFechaPeriodoVenta)
                End Select
            Case "VENTA POR ARTICULOS"



                If SwitchAcumulado.Value = False Then
                    Select Case BunifuiOSSwitch1.Value
                        Case True 'periodo
                            Dim periodo = String.Format("{0:00}", CInt(cboMesPedido.SelectedValue)) & "/" & cboAnio.Text

                            Dim obj As New documentoventaAbarrotes
                            obj.fechaPeriodo = periodo
                            obj.idEstablecimiento = ComboUnidad.SelectedValue
                            obj.usuarioActualizacion = ComboUsuarios.SelectedValue
                            obj.tipoDocumento = ComboComprobante.Text

                            UCReporteVentaProductos = New UCReporteVentaProductos(obj, "PERIODO", Me) With {.Dock = DockStyle.Fill}
                            panel5.Controls.Add(UCReporteVentaProductos)
                        Case False

                            Dim obj As New documentoventaAbarrotes
                            obj.fechaDoc = txtFecha.Value
                            obj.idEstablecimiento = ComboUnidad.SelectedValue
                            obj.usuarioActualizacion = ComboUsuarios.SelectedValue
                            obj.tipoDocumento = ComboComprobante.Text

                            UCReporteVentaProductos = New UCReporteVentaProductos(obj, "DIA", Me) With {.Dock = DockStyle.Fill}
                            panel5.Controls.Add(UCReporteVentaProductos)
                    End Select
                ElseIf SwitchAcumulado.Value = True Then


                    Select Case BunifuiOSSwitch1.Value
                        Case True 'periodo
                            Dim periodo = String.Format("{0:00}", CInt(cboMesPedido.SelectedValue)) & "/" & cboAnio.Text

                            Dim obj As New documentoventaAbarrotes
                            obj.fechaPeriodo = periodo
                            obj.idEstablecimiento = ComboUnidad.SelectedValue
                            obj.usuarioActualizacion = ComboUsuarios.SelectedValue
                            obj.tipoDocumento = ComboComprobante.Text

                            UCVentaProductosAcumulado = New UCVentaProductosAcumulado(obj, "PERIODO", Me) With {.Dock = DockStyle.Fill}
                            panel5.Controls.Add(UCVentaProductosAcumulado)
                        Case False

                            Dim obj As New documentoventaAbarrotes
                            obj.fechaDoc = txtFecha.Value
                            obj.idEstablecimiento = ComboUnidad.SelectedValue
                            obj.usuarioActualizacion = ComboUsuarios.SelectedValue
                            obj.tipoDocumento = ComboComprobante.Text

                            UCVentaProductosAcumulado = New UCVentaProductosAcumulado(obj, "DIA", Me) With {.Dock = DockStyle.Fill}
                            panel5.Controls.Add(UCVentaProductosAcumulado)
                    End Select
                End If


            Case ""

        End Select
    End Sub

    Private Sub ComboReporte_Click(sender As Object, e As EventArgs) Handles ComboReporte.Click

    End Sub

    Private Sub ComboReporte_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboReporte.SelectedValueChanged
        ComboComprobante.Visible = False
        SwitchAcumulado.Visible = False
        LabelAcumulado.Visible = False
        PanelProductos.Visible = False
        Select Case ComboReporte.Text
            Case "VENTA POR DIA"
                ComboComprobante.Visible = True
                BunifuiOSSwitch1.Value = False
                BunifuiOSSwitch1.Enabled = False
                ComboUsuarios.Visible = False
                LabelUsuarios.Visible = False

                Panel2.Visible = True
                Panel3.Visible = True
                Panel4.Visible = True
            Case "VENTA POR MES"
                ComboComprobante.Visible = True
                BunifuiOSSwitch1.Value = True
                BunifuiOSSwitch1.Enabled = False
                ComboUsuarios.Visible = False
                LabelUsuarios.Visible = False

                Panel2.Visible = True
                Panel3.Visible = True
                Panel4.Visible = True
            Case "VENTA POR VENDEDOR"
                BunifuiOSSwitch1.Enabled = True
                ComboUsuarios.Visible = True
                LabelUsuarios.Visible = True

                Panel2.Visible = True
                Panel3.Visible = True
                Panel4.Visible = True
            Case "VENTA POR ARTICULOS"
                ComboComprobante.Visible = True
                ComboUsuarios.Visible = False
                LabelUsuarios.Visible = False
                BunifuiOSSwitch1.Enabled = True
                Panel2.Visible = True
                Panel3.Visible = True
                Panel4.Visible = True

                SwitchAcumulado.Visible = True
                LabelAcumulado.Visible = True
                PanelProductos.Visible = True
            Case Else
                BunifuiOSSwitch1.Enabled = True
                ComboUsuarios.Visible = False
                LabelUsuarios.Visible = False

                Panel2.Visible = True
                Panel3.Visible = True
                Panel4.Visible = True
        End Select
    End Sub

    Private Sub pictureBox1_Click(sender As Object, e As EventArgs) Handles pictureBox1.Click
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Select Case ComboReporte.Text
            Case "VENTA POR DIA"
                Dim titulo = $"VENTAS POR DIA {txtFecha.Value.ToShortDateString}"
                Dim file = $"VentasPorDia_{txtFecha.Value.ToShortDateString.Replace("/", "")}"
                ExportarDataExcel(titulo, file, UCReporteFechaPeriodoVenta.ListaVentas)
            Case "VENTA POR MES"
                Dim periodo = String.Format("{0:00}", CInt(cboMesPedido.SelectedValue))
                periodo = $"{periodo}/{cboAnio.Text}"
                Dim titulo = $"VENTAS POR MES {periodo}"
                Dim file = $"VentasMes_{periodo.Replace("/", "")}"
                ExportarDataExcel(titulo, file, UCReporteFechaPeriodoVenta.ListaVentas)
            Case "VENTA POR VENDEDOR"
                Select Case BunifuiOSSwitch1.Value
                    Case True
                        Dim periodo = String.Format("{0:00}", CInt(cboMesPedido.SelectedValue))
                        periodo = $"{periodo}/{cboAnio.Text}"
                        Dim titulo = $"VENTAS POR VENDEDOR {periodo}-{ComboUsuarios.Text}"
                        Dim file = $"VentasVenMes_{periodo.Replace("/", "")}"
                        ExportarDataExcel(titulo, file, UCReporteFechaPeriodoVenta.ListaVentas)
                    Case False
                        Dim titulo = $"VENTAS POR VENDEDOR {txtFecha.Value.ToShortDateString}-{ComboUsuarios.Text}"
                        Dim file = $"VentasVenDia_{txtFecha.Value.ToShortDateString.Replace("/", "")}"
                        ExportarDataExcel(titulo, file, UCReporteFechaPeriodoVenta.ListaVentas)
                End Select

            Case "VENTA POR ARTICULOS"
                Select Case BunifuiOSSwitch1.Value
                    Case True
                        Dim periodo = String.Format("{0:00}", CInt(cboMesPedido.SelectedValue))
                        periodo = $"{periodo}/{cboAnio.Text}"
                        Dim titulo = $"VENTAS POR ARTICULOS {periodo}"
                        Dim file = $"VentaArtMes_{periodo.Replace("/", "")}"
                        ExportarDataExcel(titulo, file, UCReporteVentaProductos.ListaVentas)
                    Case False
                        Dim titulo = $"VENTAS POR ARTICULOS {txtFecha.Value.ToShortDateString}"
                        Dim file = $"VentaArtDia_{txtFecha.Value.ToShortDateString.Replace("/", "")}"
                        ExportarDataExcel(titulo, file, UCReporteVentaProductos.ListaVentas)
                End Select
            Case ""

        End Select
        Cursor = Cursors.Default
    End Sub

    Private Sub ExportarDataExcel(titulo As String, filename As String, listaVentas As List(Of documentoventaAbarrotes))
        Dim oExcel As Object
        Dim oBook As Object
        Dim oSheet As Object

        'Start a new workbook in Excel- this isn't really what I need though, I need it to open a template and populate it.
        oExcel = CreateObject("Excel.Application")
        oBook = oExcel.Workbooks.Add
        oBook.Worksheets("Hoja1").PageSetup.Zoom = 85
        'Add data to cells of the first worksheet in the new workbook
        oSheet = oBook.Worksheets(1)
        oSheet.Range("A1").Value = titulo
        oSheet.Range("A1").Font.Bold = True
        oSheet.Range("A1").Font.Name = "Segoe UI"
        oSheet.Range("A1:K1").Merge()
        oSheet.Range("A1:K1").Font.Size = 11
        oSheet.Range("A1:K1").VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter

        'oSheet.Range("A3:K3").Style.Font.Color = Color.White


        oSheet.Range("A3").Value = "Tipo Venta"
        oSheet.Range("B3").Value = "Fecha Doc"
        oSheet.Range("B3").ColumnWidth = 20
        oSheet.Range("C3").Value = "Comprobante"
        oSheet.Range("C3").ColumnWidth = 20
        oSheet.Range("D3").Value = "Serie venta"
        oSheet.Range("E3").Value = "Número venta"
        oSheet.Range("F3").Value = "Razón Social"
        oSheet.Range("F3").ColumnWidth = 40
        oSheet.Range("G3").Value = "Total"
        oSheet.Range("G3").Style = "Currency"

        oSheet.Range("H3").Value = "Moneda"
        oSheet.Range("I3").Value = "Vendedor"
        oSheet.Range("I3").ColumnWidth = 20
        oSheet.Range("J3").Value = "Envio a sunat"
        oSheet.Range("K3").Value = "Estado pago"

        oSheet.Range("A3").Font.Bold = True
        oSheet.Range("B3").Font.Bold = True
        oSheet.Range("C3").Font.Bold = True
        oSheet.Range("D3").Font.Bold = True
        oSheet.Range("E3").Font.Bold = True
        oSheet.Range("F3").Font.Bold = True
        oSheet.Range("G3").Font.Bold = True
        oSheet.Range("H3").Font.Bold = True
        oSheet.Range("I3").Font.Bold = True
        oSheet.Range("J3").Font.Bold = True
        oSheet.Range("K3").Font.Bold = True
        oSheet.Range("A1:K1").Interior.ColorIndex = 37 'linea de color de los encabezados
        oSheet.Range("A3:K3").Interior.ColorIndex = 24 'linea de color de los encabezados

        Dim columnaIndex = 4
        Dim tipodoc As String = String.Empty
        For Each i In listaVentas
            Select Case i.tipoDocumento
                Case "9907"
                    tipodoc = "NOTA"
                Case "01"
                    tipodoc = "FACTURA ELEC"
                Case "03"
                    tipodoc = "BOLETA ELEC"
            End Select

            Dim index = columnaIndex.ToString()
            oSheet.Range($"A{index}").Value = i.tipoVenta
            oSheet.Range($"B{index}").Value = i.fechaDoc
            oSheet.Range($"C{index}").Value = tipodoc
            oSheet.Range($"D{index}").Value = i.serieVenta
            oSheet.Range($"E{index}").Value = i.numeroVenta
            oSheet.Range($"F{index}").Value = i.NombreEntidad
            oSheet.Range($"G{index}").Value = i.ImporteNacional
            oSheet.Range($"H{index}").Value = "NUEVO SOL"
            oSheet.Range($"I{index}").Value = UsuariosList.Where(Function(o) o.IDUsuario = i.usuarioActualizacion).SingleOrDefault.Full_Name
            oSheet.Range($"J{index}").Value = i.EnvioSunat
            Select Case i.estadoCobro
                Case "DC"
                    oSheet.Range($"K{index}").Value = "Cobrado"
                Case "ANU"
                    oSheet.Range($"K{index}").Value = "Anulado"
                Case TIPO_VENTA.AnuladaPorNotaCredito
                    oSheet.Range($"K{index}").Value = "Anulado x NC."
                Case Else
                    oSheet.Range($"K{index}").Value = "Pendiente"
            End Select
            columnaIndex += 1
        Next

        'Save the Workbook and Quit Excel
        'With OpenFileDialog1
        '    .Filter = "Microsoft Excel 2003|*.xls;*.xlsx" ' "All Files (*.*)|*.*|Excel files (*.xlsx)|*.xlsx|CSV Files (*.csv)|*.csv|XLS Files (*.xls)|*xls" '
        '    '  .ShowDialog()
        '    dlgResult = .ShowDialog
        '    strDestination = .FileName
        '    ruta = strDestination
        'End With

        With SaveFileDialog1
            .Filter = "Microsoft Excel 2003|*.xls;*.xlsx" ' "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif"
            .Title = "Guardar archivo"
            .ShowDialog()
        End With

        If SaveFileDialog1.FileName <> "" Then
            'Dim fs As System.IO.FileStream = CType(SaveFileDialog1.OpenFile(), System.IO.FileStream)
            oBook.SaveAs(SaveFileDialog1.FileName) '& "\" & filename & ".xlsx")
            '    fs.Close()
        End If


        oExcel.Quit()
        '  System.Diagnostics.Process.Start("D:\" & filename & ".xlsx")
    End Sub

    Private Sub ExportarDataExcel(titulo As String, filename As String, listaVentas As List(Of documentoventaAbarrotesDet))
        Dim oExcel As Object
        Dim oBook As Object
        Dim oSheet As Object

        'Start a new workbook in Excel- this isn't really what I need though, I need it to open a template and populate it.
        oExcel = CreateObject("Excel.Application")
        oBook = oExcel.Workbooks.Add

        'Add data to cells of the first worksheet in the new workbook
        oSheet = oBook.Worksheets(1)
        oSheet.Range("C1").Value = titulo

        oSheet.Range("A3").Value = "Tipo Venta"
        oSheet.Range("B3").Value = "Fecha Doc"
        oSheet.Range("B3").ColumnWidth = 20

        oSheet.Range("C3").Value = "Documento"
        oSheet.Range("C3").ColumnWidth = 20

        oSheet.Range("D3").Value = "Serie"
        oSheet.Range("D3").ColumnWidth = 20
        oSheet.Range("E3").Value = "Numero"
        oSheet.Range("E3").ColumnWidth = 20

        oSheet.Range("F3").Value = "N.Doc"
        oSheet.Range("F3").ColumnWidth = 20

        oSheet.Range("G3").Value = "Cliente"
        oSheet.Range("G3").ColumnWidth = 45



        oSheet.Range("H3").Value = "Comprobante"
        oSheet.Range("H3").ColumnWidth = 20
        oSheet.Range("I3").Value = "Producto-artículo"
        oSheet.Range("I3").ColumnWidth = 45
        oSheet.Range("J3").Value = "Afectación"
        oSheet.Range("K3").Value = "Cantidad"
        oSheet.Range("L3").Value = "Unidad de medida"
        oSheet.Range("M3").Value = "Valor de venta"
        oSheet.Range("N3").Value = "Iva"
        oSheet.Range("O3").Value = "P.U."
        oSheet.Range("P3").Value = "Total"
        oSheet.Range("Q3").Value = "Vendedor"
        oSheet.Range("Q3").ColumnWidth = 35

        Dim columnaIndex = 4
        Dim tipodoc As String = String.Empty
        For Each i In listaVentas
            Select Case i.documentoventaAbarrotes.tipoDocumento
                Case "9907"
                    tipodoc = "NOTA"
                Case "01"
                    tipodoc = "FACTURA ELEC"
                Case "03"
                    tipodoc = "BOLETA ELEC"
            End Select

            Dim index = columnaIndex.ToString()
            oSheet.Range($"A{index}").Value = i.documentoventaAbarrotes.tipoVenta
            oSheet.Range($"B{index}").Value = i.documentoventaAbarrotes.fechaDoc

            If i.documentoventaAbarrotes.tipoDocumento = "01" Then
                oSheet.Range($"C{index}").Value = "FACTURA"
            ElseIf i.documentoventaAbarrotes.tipoDocumento = "03" Then
                oSheet.Range($"C{index}").Value = "BOLETA"
            ElseIf i.documentoventaAbarrotes.tipoDocumento = "07" Then
                oSheet.Range($"C{index}").Value = "NOTA CREDITO"
            ElseIf i.documentoventaAbarrotes.tipoDocumento = "08" Then
                oSheet.Range($"C{index}").Value = "NOTA DEBITO"
            ElseIf i.documentoventaAbarrotes.tipoDocumento = "9907" Then
                oSheet.Range($"C{index}").Value = "NOTA VENTA"

            End If


            oSheet.Range($"D{index}").Value = i.documentoventaAbarrotes.serieVenta
            oSheet.Range($"E{index}").Value = i.documentoventaAbarrotes.numeroVenta

            oSheet.Range($"F{index}").Value = i.documentoventaAbarrotes.NroDocEntidad

            oSheet.Range($"G{index}").Value = i.documentoventaAbarrotes.NombreEntidad


            oSheet.Range($"H{index}").Value = tipodoc
            oSheet.Range($"I{index}").Value = i.nombreItem
            oSheet.Range($"J{index}").Value = i.destino
            oSheet.Range($"K{index}").Value = i.monto1
            oSheet.Range($"L{index}").Value = i.unidad1
            oSheet.Range($"M{index}").Value = i.montokardex
            oSheet.Range($"N{index}").Value = i.montoIgv
            If i.importeMN > 0 Then
                oSheet.Range($"O{index}").Value = i.importeMN / i.monto1
            Else
                oSheet.Range($"O{index}").Value = 0
            End If



            oSheet.Range($"P{index}").Value = i.importeMN
            oSheet.Range($"Q{index}").Value = UsuariosList.Where(Function(o) o.IDUsuario = i.documentoventaAbarrotes.usuarioActualizacion).SingleOrDefault.Full_Name
            columnaIndex += 1
        Next

        'Save the Workbook and Quit Excel
        With SaveFileDialog1
            .Filter = "Microsoft Excel 2003|*.xls;*.xlsx" ' "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif"
            .Title = "Guardar archivo"
            .ShowDialog()
        End With

        If SaveFileDialog1.FileName <> "" Then
            'Dim fs As System.IO.FileStream = CType(SaveFileDialog1.OpenFile(), System.IO.FileStream)
            oBook.SaveAs(SaveFileDialog1.FileName) '& "\" & filename & ".xlsx")
            '    fs.Close()
        End If
        oExcel.Quit()
        'System.Diagnostics.Process.Start("D:\" & filename & ".xlsx")
    End Sub

    Private Sub pictureBox2_Click(sender As Object, e As EventArgs) Handles pictureBox2.Click
        Cursor = Cursors.WaitCursor
        '   Application.DoEvents()

        Cursor = Cursors.Default
    End Sub

    Private Sub SwitchAcumulado_OnValueChange(sender As Object, e As EventArgs) Handles SwitchAcumulado.OnValueChange
        'If ComboReporte.Text = "VENTA POR ARTICULOS" Then



        '    If SwitchAcumulado.Value = False Then

        '        ComboComprobante.Visible = True

        '    ElseIf SwitchAcumulado.Value = True Then
        '        ComboComprobante.Visible = False

        '    End If



        'End If
    End Sub

#End Region

End Class
