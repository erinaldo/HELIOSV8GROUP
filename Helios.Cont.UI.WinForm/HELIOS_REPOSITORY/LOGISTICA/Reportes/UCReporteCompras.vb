Imports Helios.General
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Cont.Business.Entity
Imports Syncfusion.Pdf
Imports Syncfusion.Pdf.Graphics
Imports Syncfusion.Pdf.Grid

Public Class UCReporteCompras
#Region "Attributes"
    Private estableSA As New establecimientoSA
    Private UCReporteFechaPeriodoCompra As UCReporteFechaPeriodoCompra
    'Private UCReporteVentaProductos As UCReporteVentaProductos
    'Private UCVentaProductosAcumulado As UCVentaProductosAcumulado
#End Region

#Region "Contructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
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


        Dim lista = estableSA.ObtenerListaEstablecimientos(Gempresas.IdEmpresaRuc).Where(Function(o) o.TipoEstab = "UN").ToList

        ComboUnidad.DataSource = lista
        ComboUnidad.ValueMember = "idCentroCosto"
        ComboUnidad.DisplayMember = "nombre"

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
            Case "COMPRA POR DIA"
                UCReporteFechaPeriodoCompra = New UCReporteFechaPeriodoCompra(txtFecha.Value, ComboUnidad.SelectedValue, Me) With {.Dock = DockStyle.Fill}
                panel5.Controls.Add(UCReporteFechaPeriodoCompra)
            Case "COMPRA POR MES"
                Dim periodo = String.Format("{0:00}", CInt(cboMesPedido.SelectedValue)) & "/" & cboAnio.Text
                UCReporteFechaPeriodoCompra = New UCReporteFechaPeriodoCompra(periodo, Me, ComboUnidad.SelectedValue) With {.Dock = DockStyle.Fill}
                panel5.Controls.Add(UCReporteFechaPeriodoCompra)
            Case "COMPRA POR VENDEDOR"
                Select Case BunifuiOSSwitch1.Value
                    Case True 'periodo
                        Dim periodo = String.Format("{0:00}", CInt(cboMesPedido.SelectedValue)) & "/" & cboAnio.Text

                        Dim obj As New documentocompra
                        obj.fechaContable = periodo
                        obj.idCentroCosto = ComboUnidad.SelectedValue
                        obj.usuarioActualizacion = ComboUsuarios.SelectedValue

                        UCReporteFechaPeriodoCompra = New UCReporteFechaPeriodoCompra(obj, "PERIODO", Me) With {.Dock = DockStyle.Fill}
                        panel5.Controls.Add(UCReporteFechaPeriodoCompra)
                    Case False

                        Dim obj As New documentocompra
                        obj.fechaDoc = txtFecha.Value
                        obj.idCentroCosto = ComboUnidad.SelectedValue
                        obj.usuarioActualizacion = ComboUsuarios.SelectedValue

                        UCReporteFechaPeriodoCompra = New UCReporteFechaPeriodoCompra(obj, "DIA", Me) With {.Dock = DockStyle.Fill}
                        panel5.Controls.Add(UCReporteFechaPeriodoCompra)
                End Select
            Case "COMPRA POR ARTICULOS"

                'If SwitchAcumulado.Value = False Then
                '    Select Case BunifuiOSSwitch1.Value
                '        Case True 'periodo
                '            Dim periodo = String.Format("{0:00}", CInt(cboMesPedido.SelectedValue)) & "/" & cboAnio.Text

                '            Dim obj As New documentoventaAbarrotes
                '            obj.fechaPeriodo = periodo
                '            obj.idEstablecimiento = ComboUnidad.SelectedValue
                '            obj.usuarioActualizacion = ComboUsuarios.SelectedValue

                '            UCReporteVentaProductos = New UCReporteVentaProductos(obj, "PERIODO", Me) With {.Dock = DockStyle.Fill}
                '            panel5.Controls.Add(UCReporteVentaProductos)
                '        Case False

                '            Dim obj As New documentoventaAbarrotes
                '            obj.fechaDoc = txtFecha.Value
                '            obj.idEstablecimiento = ComboUnidad.SelectedValue
                '            obj.usuarioActualizacion = ComboUsuarios.SelectedValue

                '            UCReporteVentaProductos = New UCReporteVentaProductos(obj, "DIA", Me) With {.Dock = DockStyle.Fill}
                '            panel5.Controls.Add(UCReporteVentaProductos)
                '    End Select
                'ElseIf SwitchAcumulado.Value = True Then


                '    Select Case BunifuiOSSwitch1.Value
                '        Case True 'periodo
                '            Dim periodo = String.Format("{0:00}", CInt(cboMesPedido.SelectedValue)) & "/" & cboAnio.Text

                '            Dim obj As New documentoventaAbarrotes
                '            obj.fechaPeriodo = periodo
                '            obj.idEstablecimiento = ComboUnidad.SelectedValue
                '            obj.usuarioActualizacion = ComboUsuarios.SelectedValue

                '            UCVentaProductosAcumulado = New UCVentaProductosAcumulado(obj, "PERIODO", Me) With {.Dock = DockStyle.Fill}
                '            panel5.Controls.Add(UCVentaProductosAcumulado)
                '        Case False

                '            Dim obj As New documentoventaAbarrotes
                '            obj.fechaDoc = txtFecha.Value
                '            obj.idEstablecimiento = ComboUnidad.SelectedValue
                '            obj.usuarioActualizacion = ComboUsuarios.SelectedValue

                '            UCVentaProductosAcumulado = New UCVentaProductosAcumulado(obj, "DIA", Me) With {.Dock = DockStyle.Fill}
                '            panel5.Controls.Add(UCVentaProductosAcumulado)
                '    End Select
                'End If


            Case ""

        End Select
    End Sub

    Private Sub ComboReporte_Click(sender As Object, e As EventArgs) Handles ComboReporte.Click

    End Sub

    Private Sub ComboReporte_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboReporte.SelectedValueChanged

        SwitchAcumulado.Visible = False
        LabelAcumulado.Visible = False

        Select Case ComboReporte.Text
            Case "COMPRA POR DIA"
                BunifuiOSSwitch1.Value = False
                BunifuiOSSwitch1.Enabled = False
                ComboUsuarios.Visible = False
                LabelUsuarios.Visible = False

                Panel2.Visible = True
                Panel3.Visible = True
                Panel4.Visible = True
            Case "COMPRA POR MES"
                BunifuiOSSwitch1.Value = True
                BunifuiOSSwitch1.Enabled = False
                ComboUsuarios.Visible = False
                LabelUsuarios.Visible = False

                Panel2.Visible = True
                Panel3.Visible = True
                Panel4.Visible = True
            Case "COMPRA POR VENDEDOR"
                BunifuiOSSwitch1.Enabled = True
                ComboUsuarios.Visible = True
                LabelUsuarios.Visible = True

                Panel2.Visible = True
                Panel3.Visible = True
                Panel4.Visible = True
            Case "COMPRA POR ARTICULOS"
                ComboUsuarios.Visible = False
                LabelUsuarios.Visible = False
                BunifuiOSSwitch1.Enabled = True
                Panel2.Visible = True
                Panel3.Visible = True
                Panel4.Visible = True

                SwitchAcumulado.Visible = True
                LabelAcumulado.Visible = True

            Case "COMPRA POR PROVEEDOR"


            Case Else
                BunifuiOSSwitch1.Enabled = True
                ComboUsuarios.Visible = False
                LabelUsuarios.Visible = False

                Panel2.Visible = True
                Panel3.Visible = True
                Panel4.Visible = True
        End Select
    End Sub

    Private Sub pictureBox1_Click(sender As Object, e As EventArgs)
        Select Case ComboReporte.Text
            Case "COMPRA POR DIA"
                Dim titulo = $"COMPRAS POR DIA {txtFecha.Value.ToShortDateString}"
                Dim file = $"ComprasPorDia_{txtFecha.Value.ToShortDateString.Replace("/", "")}"
                ExportarDataExcel(titulo, file, UCReporteFechaPeriodoCompra.ListaCompras)
            Case "COMPRA POR MES"
                Dim periodo = String.Format("{0:00}", CInt(cboMesPedido.SelectedValue))
                periodo = $"{periodo}/{cboAnio.Text}"
                Dim titulo = $"COMPRAS POR MES {periodo}"
                Dim file = $"ComprasMes_{periodo.Replace("/", "")}"
                ExportarDataExcel(titulo, file, UCReporteFechaPeriodoCompra.ListaCompras)
            Case "COMPRA POR VENDEDOR"
                Select Case BunifuiOSSwitch1.Value
                    Case True
                        Dim periodo = String.Format("{0:00}", CInt(cboMesPedido.SelectedValue))
                        periodo = $"{periodo}/{cboAnio.Text}"
                        Dim titulo = $"COMPRAS POR USUARIO {periodo}-{ComboUsuarios.Text}"
                        Dim file = $"ComprasUserMes_{periodo.Replace("/", "")}"
                        ExportarDataExcel(titulo, file, UCReporteFechaPeriodoCompra.ListaCompras)
                    Case False
                        Dim titulo = $"VENTAS POR VENDEDOR {txtFecha.Value.ToShortDateString}-{ComboUsuarios.Text}"
                        Dim file = $"ComprasUserDia_{txtFecha.Value.ToShortDateString.Replace("/", "")}"
                        ExportarDataExcel(titulo, file, UCReporteFechaPeriodoCompra.ListaCompras)
                End Select

            Case "VENTA POR ARTICULOS"
                'Select Case BunifuiOSSwitch1.Value
                '    Case True
                '        Dim periodo = String.Format("{0:00}", CInt(cboMesPedido.SelectedValue))
                '        periodo = $"{periodo}/{cboAnio.Text}"
                '        Dim titulo = $"VENTAS POR ARTICULOS {periodo}"
                '        Dim file = $"VentaArtMes_{periodo.Replace("/", "")}"
                '        ExportarDataExcel(titulo, file, UCReporteVentaProductos.ListaVentas)
                '    Case False
                '        Dim titulo = $"VENTAS POR ARTICULOS {txtFecha.Value.ToShortDateString}"
                '        Dim file = $"VentaArtDia_{txtFecha.Value.ToShortDateString.Replace("/", "")}"
                '        ExportarDataExcel(titulo, file, UCReporteVentaProductos.ListaVentas)
                'End Select
            Case ""

        End Select
    End Sub

    Private Sub ExportarDataExcel(titulo As String, filename As String, listaCompras As List(Of documentocompra))
        Dim oExcel As Object
        Dim oBook As Object
        Dim oSheet As Object

        'Start a new workbook in Excel- this isn't really what I need though, I need it to open a template and populate it.
        oExcel = CreateObject("Excel.Application")
        oBook = oExcel.Workbooks.Add

        'Add data to cells of the first worksheet in the new workbook
        oSheet = oBook.Worksheets(1)
        oSheet.Range("C1").Value = titulo

        oSheet.Range("A3").Value = "Tipo Compra"
        oSheet.Range("B3").Value = "Fecha Doc"
        oSheet.Range("B3").ColumnWidth = 25
        oSheet.Range("C3").Value = "Comprobante"
        oSheet.Range("C3").ColumnWidth = 30
        oSheet.Range("D3").Value = "Serie"
        oSheet.Range("E3").Value = "Número"
        oSheet.Range("F3").Value = "Razón Social"
        oSheet.Range("F3").ColumnWidth = 45
        oSheet.Range("G3").Value = "Total"
        oSheet.Range("H3").Value = "Moneda"
        oSheet.Range("I3").Value = "Usuario"
        oSheet.Range("I3").ColumnWidth = 20
        oSheet.Range("J3").Value = "*"

        Dim columnaIndex = 4
        Dim tipodoc As String = String.Empty
        For Each i In listaCompras
            Select Case i.tipoDoc
                Case "9907"
                    tipodoc = "NOTA"
                Case "01"
                    tipodoc = "FACTURA"
                Case "03"
                    tipodoc = "BOLETA"
            End Select

            Dim index = columnaIndex.ToString()
            oSheet.Range($"A{index}").Value = i.tipoCompra
            oSheet.Range($"B{index}").Value = i.fechaDoc
            oSheet.Range($"C{index}").Value = tipodoc
            oSheet.Range($"D{index}").Value = i.serie
            oSheet.Range($"E{index}").Value = i.numeroDoc
            oSheet.Range($"F{index}").Value = i.NombreEntidad
            oSheet.Range($"G{index}").Value = i.importeTotal
            oSheet.Range($"H{index}").Value = "NUEVO SOL"
            oSheet.Range($"I{index}").Value = UsuariosList.Where(Function(o) o.IDUsuario = i.usuarioActualizacion).SingleOrDefault.Full_Name
            oSheet.Range($"J{index}").Value = "-"
            columnaIndex += 1
        Next

        'Save the Workbook and Quit Excel
        oBook.SaveAs("D:\" & filename & ".xlsx")
        oExcel.Quit()
        System.Diagnostics.Process.Start("D:\" & filename & ".xlsx")
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Select Case ComboReporte.Text
            Case "COMPRA POR DIA"
                Dim titulo = $"COMPRAS POR DIA {txtFecha.Value.ToShortDateString}"
                Dim file = $"ComprasPorDia_{txtFecha.Value.ToShortDateString.Replace("/", "")}"
                ExportarDataExcel(titulo, file, UCReporteFechaPeriodoCompra.ListaCompras)
            Case "COMPRA POR MES"
                Dim periodo = String.Format("{0:00}", CInt(cboMesPedido.SelectedValue))
                periodo = $"{periodo}/{cboAnio.Text}"
                Dim titulo = $"COMPRAS POR MES {periodo}"
                Dim file = $"ComprasMes_{periodo.Replace("/", "")}"
                ExportarDataExcel(titulo, file, UCReporteFechaPeriodoCompra.ListaCompras)
            Case "COMPRA POR VENDEDOR"
                Select Case BunifuiOSSwitch1.Value
                    Case True
                        Dim periodo = String.Format("{0:00}", CInt(cboMesPedido.SelectedValue))
                        periodo = $"{periodo}/{cboAnio.Text}"
                        Dim titulo = $"COMPRAS POR USUARIO {periodo}-{ComboUsuarios.Text}"
                        Dim file = $"ComprasUserMes_{periodo.Replace("/", "")}"
                        ExportarDataExcel(titulo, file, UCReporteFechaPeriodoCompra.ListaCompras)
                    Case False
                        Dim titulo = $"VENTAS POR VENDEDOR {txtFecha.Value.ToShortDateString}-{ComboUsuarios.Text}"
                        Dim file = $"ComprasUserDia_{txtFecha.Value.ToShortDateString.Replace("/", "")}"
                        ExportarDataExcel(titulo, file, UCReporteFechaPeriodoCompra.ListaCompras)
                End Select

            Case "VENTA POR ARTICULOS"
                'Select Case BunifuiOSSwitch1.Value
                '    Case True
                '        Dim periodo = String.Format("{0:00}", CInt(cboMesPedido.SelectedValue))
                '        periodo = $"{periodo}/{cboAnio.Text}"
                '        Dim titulo = $"VENTAS POR ARTICULOS {periodo}"
                '        Dim file = $"VentaArtMes_{periodo.Replace("/", "")}"
                '        ExportarDataExcel(titulo, file, UCReporteVentaProductos.ListaVentas)
                '    Case False
                '        Dim titulo = $"VENTAS POR ARTICULOS {txtFecha.Value.ToShortDateString}"
                '        Dim file = $"VentaArtDia_{txtFecha.Value.ToShortDateString.Replace("/", "")}"
                '        ExportarDataExcel(titulo, file, UCReporteVentaProductos.ListaVentas)
                'End Select
            Case ""

        End Select
    End Sub

    Private Sub pictureBox2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Select Case ComboReporte.Text
            Case "COMPRA POR DIA"
                Dim titulo = $"COMPRAS POR DIA {txtFecha.Value.ToShortDateString}"
                Dim file = $"ComprasPorDia_{txtFecha.Value.ToShortDateString.Replace("/", "")}"
                'ExportarDataExcel(titulo, file, UCReporteFechaPeriodoCompra.ListaCompras)
                GeneratePDF(UCReporteFechaPeriodoCompra.ListaCompras)
            Case "COMPRA POR MES"
                Dim periodo = String.Format("{0:00}", CInt(cboMesPedido.SelectedValue))
                periodo = $"{periodo}/{cboAnio.Text}"
                Dim titulo = $"COMPRAS POR MES {periodo}"
                Dim file = $"ComprasMes_{periodo.Replace("/", "")}"
                'ExportarDataExcel(titulo, file, UCReporteFechaPeriodoCompra.ListaCompras)
                GeneratePDF(UCReporteFechaPeriodoCompra.ListaCompras)
            Case "COMPRA POR VENDEDOR"
                'Select Case BunifuiOSSwitch1.Value
                '    Case True
                '        Dim periodo = String.Format("{0:00}", CInt(cboMesPedido.SelectedValue))
                '        periodo = $"{periodo}/{cboAnio.Text}"
                '        Dim titulo = $"COMPRAS POR USUARIO {periodo}-{ComboUsuarios.Text}"
                '        Dim file = $"ComprasUserMes_{periodo.Replace("/", "")}"
                '        ExportarDataExcel(titulo, file, UCReporteFechaPeriodoCompra.ListaCompras)
                '    Case False
                '        Dim titulo = $"VENTAS POR VENDEDOR {txtFecha.Value.ToShortDateString}-{ComboUsuarios.Text}"
                '        Dim file = $"ComprasUserDia_{txtFecha.Value.ToShortDateString.Replace("/", "")}"
                '        ExportarDataExcel(titulo, file, UCReporteFechaPeriodoCompra.ListaCompras)
                'End Select

            Case "VENTA POR ARTICULOS"
                'Select Case BunifuiOSSwitch1.Value
                '    Case True
                '        Dim periodo = String.Format("{0:00}", CInt(cboMesPedido.SelectedValue))
                '        periodo = $"{periodo}/{cboAnio.Text}"
                '        Dim titulo = $"VENTAS POR ARTICULOS {periodo}"
                '        Dim file = $"VentaArtMes_{periodo.Replace("/", "")}"
                '        ExportarDataExcel(titulo, file, UCReporteVentaProductos.ListaVentas)
                '    Case False
                '        Dim titulo = $"VENTAS POR ARTICULOS {txtFecha.Value.ToShortDateString}"
                '        Dim file = $"VentaArtDia_{txtFecha.Value.ToShortDateString.Replace("/", "")}"
                '        ExportarDataExcel(titulo, file, UCReporteVentaProductos.ListaVentas)
                'End Select
            Case ""

        End Select
    End Sub

    Private Sub GeneratePDF(ByVal ListaCompras As List(Of documentocompra))
        Dim document As PdfDocument = New PdfDocument()
        document.PageSettings.Orientation = PdfPageOrientation.Landscape

        document.PageSettings.Margins.All = 50
        Dim page As PdfPage = document.Pages.Add()
        Dim g As PdfGraphics = page.Graphics
        Dim element As PdfTextElement = New PdfTextElement(Gempresas.NomEmpresa & vbLf & "{Dir}," & vbLf & "{Ciudad}," & vbLf & "Perú.")
        element.Font = New PdfStandardFont(PdfFontFamily.TimesRoman, 12)
        element.Brush = New PdfSolidBrush(New PdfColor(89, 89, 93))
        Dim result As PdfLayoutResult = element.Draw(page, New RectangleF(0, 0, page.Graphics.ClientSize.Width / 2, 200))
        'Dim img As PdfImage = PdfImage.FromFile(GetFullTemplatePath("logo.jpg", True))
        'page.Graphics.DrawImage(img, New RectangleF(g.ClientSize.Width - 200, result.Bounds.Y, 190, 45))
        Dim subHeadingFont As PdfFont = New PdfTrueTypeFont(New Font("Segoe UI", 13.0F)) 'New PdfStandardFont(PdfFontFamily.TimesRoman, 14)

        g.DrawRectangle(New PdfSolidBrush(New PdfColor(126, 151, 173)), New RectangleF(0, result.Bounds.Bottom + 40, g.ClientSize.Width, 30))
        element = New PdfTextElement("REGISTRO DE COMPRAS", subHeadingFont)
        element.Brush = PdfBrushes.White
        result = element.Draw(page, New PointF(10, result.Bounds.Bottom + 48))
        Dim currentDate As String = "PERIODO " & GetPeriodo(txtFecha.Value, True)
        Dim textSize As SizeF = subHeadingFont.MeasureString(currentDate)
        g.DrawString(currentDate, subHeadingFont, element.Brush, New PointF(g.ClientSize.Width - textSize.Width - 10, result.Bounds.Y))
        element = New PdfTextElement("RESUMEN ", New PdfTrueTypeFont(New Font("Segoe UI", 10.0F))) 'New PdfStandardFont(PdfFontFamily.TimesRoman, 10))
        element.Brush = New PdfSolidBrush(New PdfColor(126, 155, 203))
        result = element.Draw(page, New PointF(10, result.Bounds.Bottom + 25))
        g.DrawLine(New PdfPen(New PdfColor(126, 151, 173), 0.7F), New PointF(0, result.Bounds.Bottom + 3), New PointF(g.ClientSize.Width, result.Bounds.Bottom + 3))

        'Dim shipTable As DataTable = GetShipDetails(id)
        'GetProductTable(shipTable)
        element = New PdfTextElement("FACTURAS: " & ListaCompras.Where(Function(o) o.tipoDoc = "01").Sum(Function(o) o.importeTotal).GetValueOrDefault.ToString("N2"), New PdfTrueTypeFont(New Font("Segoe UI", 10.0F)))
        element.Brush = New PdfSolidBrush(New PdfColor(89, 89, 93))
        result = element.Draw(page, New RectangleF(10, result.Bounds.Bottom + 5, g.ClientSize.Width / 2, 100))

        element = New PdfTextElement("BOLETAS: " & ListaCompras.Where(Function(o) o.tipoDoc = "03").Sum(Function(o) o.importeTotal).GetValueOrDefault.ToString("N2"), New PdfTrueTypeFont(New Font("Segoe UI", 10.0F)))
        element.Brush = New PdfSolidBrush(New PdfColor(89, 89, 93))
        result = element.Draw(page, New RectangleF(10, result.Bounds.Bottom + 3, g.ClientSize.Width / 2, 100))

        element = New PdfTextElement("GRAVADAS: " & ListaCompras.Sum(Function(o) o.bi01).GetValueOrDefault.ToString("N2"), New PdfTrueTypeFont(New Font("Segoe UI", 10.0F)))
        element.Brush = New PdfSolidBrush(New PdfColor(89, 89, 93))
        result = element.Draw(page, New RectangleF(10, result.Bounds.Bottom + 2, g.ClientSize.Width / 2, 100))

        element = New PdfTextElement("EXONERADAS: " & ListaCompras.Sum(Function(o) o.bi02).GetValueOrDefault.ToString("N2"), New PdfTrueTypeFont(New Font("Segoe UI", 10.0F)))
        element.Brush = New PdfSolidBrush(New PdfColor(89, 89, 93))
        result = element.Draw(page, New RectangleF(10, result.Bounds.Bottom + 2, g.ClientSize.Width / 2, 100))

        element = New PdfTextElement("I.G.V.: " & ListaCompras.Sum(Function(o) o.igv01).GetValueOrDefault.ToString("N2"), New PdfTrueTypeFont(New Font("Segoe UI", 10.0F)))
        element.Brush = New PdfSolidBrush(New PdfColor(89, 89, 93))
        result = element.Draw(page, New RectangleF(10, result.Bounds.Bottom + 2, g.ClientSize.Width / 2, 100))

        'Grid PDF configuration
        Dim grid As PdfGrid = New PdfGrid()
        grid.DataSource = GetProductDetails(ListaCompras)

        Dim cellStyle As PdfGridCellStyle = New PdfGridCellStyle()
        cellStyle.Borders.All = PdfPens.White

        Dim fontGrid As PdfFont = New PdfTrueTypeFont(New Font("Segoe UI", 11.0F))

        Dim header As PdfGridRow = grid.Headers(0)
        Dim headerStyle As PdfGridCellStyle = New PdfGridCellStyle()
        headerStyle.Borders.All = New PdfPen(New PdfColor(126, 151, 173))
        headerStyle.BackgroundBrush = New PdfSolidBrush(New PdfColor(126, 151, 173))
        headerStyle.TextBrush = PdfBrushes.White
        headerStyle.Font = fontGrid ' New PdfStandardFont(PdfFontFamily.TimesRoman, 12.0F, PdfFontStyle.Regular)

        For i As Integer = 0 To header.Cells.Count - 1

            If i = 0 OrElse i = 1 Then
                header.Cells(i).StringFormat = New PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle)
            Else
                header.Cells(i).StringFormat = New PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle)
            End If
        Next

        header.ApplyStyle(headerStyle)
        cellStyle.Borders.Bottom = New PdfPen(New PdfColor(217, 217, 217), 0.7F)
        Dim fontRow As PdfFont = New PdfTrueTypeFont(New Font("Segoe UI", 9.5F))
        cellStyle.Font = fontRow ' New PdfStandardFont(PdfFontFamily.TimesRoman, 11.0F)
        cellStyle.TextBrush = New PdfSolidBrush(New PdfColor(31, 31, 31)) ' New PdfSolidBrush(New PdfColor(131, 130, 136))

        For Each row As PdfGridRow In grid.Rows
            row.ApplyStyle(cellStyle)

            For i As Integer = 0 To row.Cells.Count - 1
                Dim cell As PdfGridCell = row.Cells(i)

                If i = 1 Then
                    cell.StringFormat = New PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle)
                ElseIf i = 0 Then
                    cell.StringFormat = New PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle)
                ElseIf i = 4 Then
                    cell.StringFormat = New PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle)
                ElseIf i = 5 Then
                    cell.StringFormat = New PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle)
                Else
                    cell.StringFormat = New PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle)
                End If

                If i >= 6 Then
                    If i <> 10 Then
                        Dim val As Decimal = CDec(cell.Value)
                        cell.Value = val.ToString("N2")
                    End If
                End If
            Next
        Next

        grid.Columns(0).Width = 40
        grid.Columns(1).Width = 120
        grid.Columns(2).Width = 70
        grid.Columns(3).Width = 50
        grid.Columns(4).Width = 70
        grid.Columns(5).Width = 150
        Dim layoutFormat As PdfGridLayoutFormat = New PdfGridLayoutFormat()
        layoutFormat.Layout = PdfLayoutType.Paginate
        Dim gridResult As PdfGridLayoutResult = grid.Draw(page, New RectangleF(New PointF(0, result.Bounds.Bottom + 40), New SizeF(g.ClientSize.Width, g.ClientSize.Height - 100)), layoutFormat)
        Dim pos As Single = 0.0F

        For i As Integer = 0 To grid.Columns.Count - 1 - 1
            pos += grid.Columns(i).Width
        Next

        Dim font As PdfFont = New PdfTrueTypeFont(New Font("Segoe UI", 9.5F)) ' New PdfStandardFont(PdfFontFamily.TimesRoman, 14.0F)

        ' gridResult.Page.Graphics.DrawString("Total Compras", font, New PdfSolidBrush(New PdfColor(126, 151, 173)), New RectangleF(New PointF(pos - grid.Columns(3).Width, gridResult.Bounds.Bottom + 20), New SizeF(grid.Columns(5).Width - pos, 20)), New PdfStringFormat(PdfTextAlignment.Right))
        'gridResult.Page.Graphics.DrawString("Thank you for your business!", New PdfStandardFont(PdfFontFamily.TimesRoman, 12), New PdfSolidBrush(New PdfColor(89, 89, 93)), New PointF(pos - 55, gridResult.Bounds.Bottom + 60))
        'pos += grid.Columns(3).Width

        gridResult.Page.Graphics.DrawString("TOTALES: ", font, New PdfSolidBrush(New PdfColor(126, 151, 173)), New RectangleF(New PointF(pos - (grid.Columns(7).Width * 4), gridResult.Bounds.Bottom + 20), New SizeF(grid.Columns(3).Width - pos, 20)), New PdfStringFormat(PdfTextAlignment.Right))

        gridResult.Page.Graphics.DrawString(ListaCompras.Sum(Function(o) o.bi01).GetValueOrDefault.ToString("N2"), font, New PdfSolidBrush(New PdfColor(31, 31, 31)), New RectangleF(New PointF(pos - (grid.Columns(7).Width * 3), gridResult.Bounds.Bottom + 20), New SizeF(grid.Columns(3).Width - pos, 20)), New PdfStringFormat(PdfTextAlignment.Right))

        gridResult.Page.Graphics.DrawString(ListaCompras.Sum(Function(o) o.bi02).GetValueOrDefault.ToString("N2"), font, New PdfSolidBrush(New PdfColor(31, 31, 31)), New RectangleF(New PointF(pos - (grid.Columns(7).Width * 2), gridResult.Bounds.Bottom + 20), New SizeF(grid.Columns(3).Width - pos, 20)), New PdfStringFormat(PdfTextAlignment.Right))

        gridResult.Page.Graphics.DrawString(ListaCompras.Sum(Function(o) o.igv01).GetValueOrDefault.ToString("N2"), font, New PdfSolidBrush(New PdfColor(31, 31, 31)), New RectangleF(New PointF(pos - grid.Columns(3).Width, gridResult.Bounds.Bottom + 20), New SizeF(grid.Columns(3).Width - pos, 20)), New PdfStringFormat(PdfTextAlignment.Right))

        gridResult.Page.Graphics.DrawString(ListaCompras.Sum(Function(o) o.importeTotal).GetValueOrDefault.ToString("N2"), font, New PdfSolidBrush(New PdfColor(31, 31, 31)), New RectangleF(New PointF(pos, gridResult.Bounds.Bottom + 20), New SizeF(grid.Columns(4).Width - pos, 20)), New PdfStringFormat(PdfTextAlignment.Right))
        document.Save("Compras.pdf")
        document.Close(True)

        System.Diagnostics.Process.Start("Compras.pdf")
    End Sub

    Private Function GetProductDetails(listaCompras As List(Of documentocompra)) As DataTable
        Dim tipodoc As String = String.Empty
        Dim dt As New DataTable
        dt.Columns.Add("Tipo")
        dt.Columns.Add("Fecha")
        dt.Columns.Add("Tipo doc.")
        dt.Columns.Add("Serie")
        dt.Columns.Add("Número")
        dt.Columns.Add("Razon social")
        dt.Columns.Add("Grav.")
        dt.Columns.Add("Exoner.")
        dt.Columns.Add("Igv.")
        dt.Columns.Add("Total")
        dt.Columns.Add("Moneda")

        For Each i In listaCompras
            Select Case i.tipoDoc
                Case "9907"
                    tipodoc = "NOTA"
                Case "01"
                    tipodoc = "FACTURA"
                Case "03"
                    tipodoc = "BOLETA"
            End Select

            dt.Rows.Add(
                i.tipoCompra,
                i.fechaDoc,
                tipodoc,
                i.serie,
                i.numeroDoc,
                i.NombreEntidad,
                i.bi01.GetValueOrDefault,
                i.bi02.GetValueOrDefault,
                i.igv01.GetValueOrDefault,
                i.importeTotal,
                "SOL")
        Next
        Return dt
    End Function

    'Private Sub ExportarDataExcel(titulo As String, filename As String, listaCompras As List(Of documentocompra))
    '    Dim oExcel As Object
    '    Dim oBook As Object
    '    Dim oSheet As Object

    '    'Start a new workbook in Excel- this isn't really what I need though, I need it to open a template and populate it.
    '    oExcel = CreateObject("Excel.Application")
    '    oBook = oExcel.Workbooks.Add

    '    'Add data to cells of the first worksheet in the new workbook
    '    oSheet = oBook.Worksheets(1)
    '    oSheet.Range("C1").Value = titulo

    '    oSheet.Range("A3").Value = "Tipo Compra"
    '    oSheet.Range("B3").Value = "Fecha Doc"
    '    oSheet.Range("B3").ColumnWidth = 20
    '    oSheet.Range("C3").Value = "Comprobante"
    '    oSheet.Range("C3").ColumnWidth = 20
    '    oSheet.Range("D3").Value = "Producto-artículo"
    '    oSheet.Range("D3").ColumnWidth = 45
    '    oSheet.Range("E3").Value = "Afectación"
    '    oSheet.Range("F3").Value = "Cantidad"
    '    oSheet.Range("G3").Value = "Unidad de medida"
    '    oSheet.Range("H3").Value = "Valor de venta"
    '    oSheet.Range("I3").Value = "Iva"
    '    oSheet.Range("J3").Value = "P.U."
    '    oSheet.Range("K3").Value = "Total"
    '    oSheet.Range("L3").Value = "Vendedor"
    '    oSheet.Range("L3").ColumnWidth = 35

    '    Dim columnaIndex = 4
    '    Dim tipodoc As String = String.Empty
    '    For Each i In listaCompras
    '        Select Case i.documentocompra.tipoDocumento
    '            Case "9907"
    '                tipodoc = "NOTA"
    '            Case "01"
    '                tipodoc = "FACTURA ELEC"
    '            Case "03"
    '                tipodoc = "BOLETA ELEC"
    '        End Select

    '        Dim index = columnaIndex.ToString()
    '        oSheet.Range($"A{index}").Value = i.documentoventaAbarrotes.tipoVenta
    '        oSheet.Range($"B{index}").Value = i.documentoventaAbarrotes.fechaDoc
    '        oSheet.Range($"C{index}").Value = tipodoc
    '        oSheet.Range($"D{index}").Value = i.nombreItem
    '        oSheet.Range($"E{index}").Value = i.destino
    '        oSheet.Range($"F{index}").Value = i.monto1
    '        oSheet.Range($"G{index}").Value = i.unidad1
    '        oSheet.Range($"H{index}").Value = i.montokardex
    '        oSheet.Range($"I{index}").Value = i.montoIgv
    '        oSheet.Range($"J{index}").Value = 0
    '        oSheet.Range($"K{index}").Value = i.importeMN
    '        oSheet.Range($"L{index}").Value = UsuariosList.Where(Function(o) o.IDUsuario = i.documentoventaAbarrotes.usuarioActualizacion).SingleOrDefault.Full_Name
    '        columnaIndex += 1
    '    Next

    '    'Save the Workbook and Quit Excel
    '    oBook.SaveAs("D:\" & filename & ".xlsx")
    '    oExcel.Quit()
    '    System.Diagnostics.Process.Start("D:\" & filename & ".xlsx")
    'End Sub
#End Region
End Class
