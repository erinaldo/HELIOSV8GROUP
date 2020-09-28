Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports System.IO
Imports OpenInvoicePeru.Comun.Dto.Intercambio
Imports OpenInvoicePeru.Comun.Dto.Modelos
Imports Syncfusion.Windows.Forms.Grid
Imports System.Runtime.Serialization
Imports Syncfusion.GroupingGridExcelConverter
Public Class FormQuotesClients

#Region "Atributos"
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
#End Region
#Region "Constructor"

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        FormatoGridAvanzado(DgvComprobantes, False, False, 8.0F)
        ' Add any initialization after the InitializeComponent() call.
        FormatoGridPrincipal(DgvComprobantes)
        Me.StartPosition = FormStartPosition.CenterParent
    End Sub

#End Region
#Region "Metodos"


    Private Sub GetListaVentasPorDia(fechaLaboral As Date, idEstable As Integer, tipo As String)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim ListaTipo As New List(Of String)



        'Select Case tipo
        '    Case "COTIZACIONES"
        '        ListaTipo.Add(TIPO_VENTA.COTIZACION)
        '    Case "VENTAS ELECTRONICAS"
        '        ListaTipo.Add(TIPO_VENTA.VENTA_ELECTRONICA)
        '        ListaTipo.Add(TIPO_COMPRA.NOTA_CREDITO_ELECTRONICA)
        '    Case "NOTAS DE VENTA"
        '        ListaTipo.Add(TIPO_VENTA.NOTA_DE_VENTA)
        '    Case "NOTAS DE CREDITO"
        '        ListaTipo.Add(TIPO_COMPRA.NOTA_CREDITO_ELECTRONICA)
        '    Case "TODAS LAS VENTAS"
        '        ListaTipo.Add(TIPO_VENTA.VENTA_ELECTRONICA)
        '        ListaTipo.Add(TIPO_VENTA.NOTA_DE_VENTA)
        'End Select



        Dim dt As New DataTable("Ventas de - " & fechaLaboral)
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("comprobante", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDocumento", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numero", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("bi", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("bi02", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("igv", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("icbper", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("total", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("enviosunat", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoVenta", GetType(String)))



        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarVentasPorDiaEstablecimiento(New documentoventaAbarrotes With {.idEstablecimiento = idEstable, .fechaDoc = fechaLaboral, .tipoVenta = tipo})
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.fechaDoc 'str
            dr(2) = i.tipoDocumento

            Select Case i.tipoDocumento
                Case "01"
                    dr(3) = "Factura"
                Case "03"
                    dr(3) = "Boleta"
                Case "07"
                    dr(3) = "Nota Credito"
                Case "08"
                    dr(3) = "Nota Debito"
                Case "9903"
                    dr(3) = "Nota Debito"
                Case Else
                    dr(3) = "Cotizacion"
            End Select


            dr(4) = i.serieVenta
            dr(5) = i.numeroVenta

            Select Case i.NroDocEntidad
                Case Is = Nothing

                    dr(6) = "-"
                    dr(7) = i.nombrePedido
                Case Else

                    dr(6) = i.NroDocEntidad
                    dr(7) = i.NombreEntidad
            End Select



            dr(8) = i.bi01
            dr(9) = i.bi02

            dr(10) = i.igv01
            dr(11) = i.icbper.GetValueOrDefault
            dr(12) = i.ImporteNacional


            Select Case i.estadoCobro
                Case "DC"
                    dr(13) = "Cobrado"
                Case "ANU"
                    dr(13) = "Anulado"
                Case TIPO_VENTA.AnuladaPorNotaCredito
                    dr(13) = "Anulado x NC."
                Case Else
                    dr(13) = "-"
            End Select

            If i.EnvioSunat IsNot Nothing Then
                dr(14) = i.EnvioSunat
            Else
                dr(14) = "NO"
            End If

            dr(15) = i.tipoVenta
            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub

    Public Sub setDatasource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            Dim deleg As New SetDataSourceDelegate(AddressOf setDatasource)
            Invoke(deleg, New Object() {table})
        Else
            DgvComprobantes.DataSource = table
            'PictureLoad.Visible = False
            'BunifuFlatButton5.Enabled = True
            'BunifuFlatButton3.Enabled = True
        End If
    End Sub

    Private Sub GetListaVentasPorTipo(period As String, tipo As String)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim ListaTipo As New List(Of String)



        'Select Case tipo
        '    Case "COTIZACIONES"
        '        ListaTipo.Add(TIPO_VENTA.COTIZACION)
        '    Case "VENTAS ELECTRONICAS"
        '        ListaTipo.Add(TIPO_VENTA.VENTA_ELECTRONICA)
        '        ListaTipo.Add(TIPO_COMPRA.NOTA_CREDITO_ELECTRONICA)
        '    Case "NOTAS DE VENTA"
        '        ListaTipo.Add(TIPO_VENTA.NOTA_DE_VENTA)
        '    Case "NOTAS DE CREDITO"
        '        ListaTipo.Add(TIPO_COMPRA.NOTA_CREDITO_ELECTRONICA)
        '    Case "TODAS LAS VENTAS"
        '        ListaTipo.Add(TIPO_VENTA.VENTA_ELECTRONICA)
        '        ListaTipo.Add(TIPO_VENTA.NOTA_DE_VENTA)
        'End Select



        Dim dt As New DataTable("Ventas de - " & period)
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("comprobante", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDocumento", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numero", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("bi", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("bi02", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("igv", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("icbper", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("total", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("enviosunat", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoVenta", GetType(String)))



        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarVentasPeriodoXTipo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, period, tipo, StatusTipoConsulta.XUNIDAD_ORGANICA)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.fechaDoc 'str
            dr(2) = i.tipoDocumento

            Select Case i.tipoDocumento
                Case "01"
                    dr(3) = "Factura"
                Case "03"
                    dr(3) = "Boleta"
                Case "07"
                    dr(3) = "Nota Credito"
                Case "08"
                    dr(3) = "Nota Debito"
                Case "9903"
                    dr(3) = "Nota Debito"
                Case Else
                    dr(3) = "Cotizacion"
            End Select


            dr(4) = i.serieVenta
            dr(5) = i.numeroVenta

            Select Case i.NroDocEntidad
                Case Is = Nothing

                    dr(6) = "-"
                    dr(7) = i.nombrePedido
                Case Else

                    dr(6) = i.NroDocEntidad
                    dr(7) = i.NombreEntidad
            End Select



            dr(8) = i.bi01
            dr(9) = i.bi02

            dr(10) = i.igv01
            dr(11) = i.icbper.GetValueOrDefault
            dr(12) = i.ImporteNacional


            Select Case i.estadoCobro
                Case "DC"
                    dr(13) = "Cobrado"
                Case "ANU"
                    dr(13) = "Anulado"
                Case TIPO_VENTA.AnuladaPorNotaCredito
                    dr(13) = "Anulado x NC."
                Case Else
                    dr(13) = "-"
            End Select

            If i.EnvioSunat IsNot Nothing Then
                dr(14) = i.EnvioSunat
            Else
                dr(14) = "NO"
            End If

            dr(15) = i.tipoVenta
            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub

#End Region

    Private Sub btnBuscarVenta_Click(sender As Object, e As EventArgs) Handles btnBuscarVenta.Click
        If cboTipoBusqueda.Text = "POR PERIODO" Then
            Dim f As New FormFiltroAvanzadoPeriodo()
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
            If f.Tag IsNot Nothing Then
                Dim periodoSel = CType(f.Tag, DateTime?)
                'PictureLoad.Visible = True
                'BunifuFlatButton5.Enabled = False
                lblTittleReport.Text = "Cotizaciones del Periodo" & " - " & periodoSel

                Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetListaVentasPorTipo(GetPeriodo(periodoSel, True), TIPO_VENTA.COTIZACION)))
                thread.Start()
            End If

        ElseIf cboTipoBusqueda.Text = "POR DIA" Then

            Dim f As New FormFiltroAvanzadoDia()
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
            If f.Tag IsNot Nothing Then
                Dim FechaSel = CType(f.Tag, DateTime?)
                'PictureLoad.Visible = True
                'BunifuFlatButton3.Enabled = False

                lblTittleReport.Text = "Cotizaciones del Día" & " - " & FechaSel

                Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetListaVentasPorDia(FechaSel, GEstableciento.IdEstablecimiento, TIPO_VENTA.COTIZACION)))
                thread.Start()

            End If

        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Cursor = Cursors.WaitCursor
        Dim r As Record = DgvComprobantes.Table.CurrentRecord
        If r IsNot Nothing Then
            Dim f As New FormImpresionEquivalencia(Integer.Parse(r.GetValue("idDocumento"))) 'FormImpresionNuevo(Integer.Parse(r.GetValue("idDocumento")))
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
        Else
            MessageBox.Show("Debe seleccionar un documento válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub btnVerDetalle_Click(sender As Object, e As EventArgs) Handles btnVerDetalle.Click
        Cursor = Cursors.WaitCursor
        Dim r As Record = Me.DgvComprobantes.Table.CurrentRecord
        If r IsNot Nothing Then
            Dim f As New FormVentaNueva(Integer.Parse(r.GetValue("idDocumento")))
            f.ToolStrip1.Enabled = False
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)

        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub btnImportarExcel_Click(sender As Object, e As EventArgs) Handles btnImportarExcel.Click
        Dim converter As New GroupingGridExcelConverterControl

        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "Files(*.xls)|*.xls"
        saveFileDialog.DefaultExt = ".xls"


        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            'If radioButton1.Checked Then
            converter.GroupingGridToExcel(Me.DgvComprobantes, saveFileDialog.FileName, Syncfusion.GridExcelConverter.ConverterOptions.Visible)
            'ElseIf radioButton2.Checked Then
            '    converter.GroupingGridToExcel(Me.GridGroupingControl1, saveFileDialog.FileName, Syncfusion.GridExcelConverter.ConverterOptions.[Default])
            'End If

            If MessageBox.Show("Exportar Registro de Ventas a un archivo excel ahora?", "Exportar a Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim proc As New Process()
                proc.StartInfo.FileName = saveFileDialog.FileName
                proc.Start()
            End If
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnMinimizar_Click(sender As Object, e As EventArgs) Handles btnMinimizar.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnGenerarVenta_Click(sender As Object, e As EventArgs) Handles btnGenerarVenta.Click
        Cursor = Cursors.WaitCursor
        Dim r As Record = DgvComprobantes.Table.CurrentRecord
        If r IsNot Nothing Then
            Dim f As New FormVentaNueva(Convert.ToString(r.GetValue("numero")))
            If Gempresas.ubigeo IsNot Nothing Then
                f.ComboComprobante.Text = "VENTA"
            Else
                f.ComboComprobante.Text = "NOTA DE VENTA"
            End If

            f.StartPosition = FormStartPosition.CenterParent
            f.Show(Me)
        Else
            MessageBox.Show("Debe seleccionar un documento válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub FormQuotesClients_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Centrar(Me)
    End Sub
End Class