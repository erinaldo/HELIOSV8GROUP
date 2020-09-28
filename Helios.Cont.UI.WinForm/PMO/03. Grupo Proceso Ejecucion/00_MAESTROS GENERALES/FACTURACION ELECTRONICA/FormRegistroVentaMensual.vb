Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.GroupingGridExcelConverter

Public Class FormRegistroVentaMensual


    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        'FormatoGrid(dgvRegistros)
        FormatoGridBlack(GridVentas, False)
        GetCombos()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

#Region "METODOS"

    Private Sub GetCombos()
        Dim empresaAnioSA As New empresaPeriodoSA
        cboMes2.DisplayMember = "Mes"
        cboMes2.ValueMember = "Codigo"
        cboMes2.DataSource = ListaDeMeses()
        cboMes2.SelectedValue = String.Format("{0:00}", DateTime.Now.Month)

        cboaño2.DisplayMember = "periodo"
        cboaño2.ValueMember = "periodo"
        cboaño2.DataSource = empresaAnioSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
        cboaño2.Text = DateTime.Now.Year
    End Sub

    'fisicas otros
    Private Sub GetListarRegistroVentasFisicas(period As String)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim ListaTipo As New List(Of String)

        ListaTipo.Add(TIPO_VENTA.VENTA_GENERAL)
        ListaTipo.Add(TIPO_VENTA.VENTA_HEREDAD)
        ListaTipo.Add(TIPO_VENTA.VENTA_POS_DIRECTA)
        ListaTipo.Add(TIPO_VENTA.VENTA_ANTICIPADA_OTORGADO)

        ListaTipo.Add(TIPO_VENTA.VENTA_AL_TICKET)
        ListaTipo.Add(TIPO_COMPRA.NOTA_CREDITO)
        ListaTipo.Add(TIPO_COMPRA.NOTA_DEBITO)



        Dim dt As New DataTable("Ventas de - " & period)
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
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



        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarRegistroVentasXTipo(GEstableciento.IdEstablecimiento, period, ListaTipo)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = str
            dr(2) = i.tipoDocumento
            dr(3) = i.serieVenta
            dr(4) = i.numeroVenta

            Select Case i.NroDocEntidad
                Case Is = Nothing

                    dr(5) = "-"
                    dr(6) = i.nombrePedido
                Case Else

                    dr(5) = i.NroDocEntidad
                    dr(6) = i.NombreEntidad
            End Select



            dr(7) = i.bi01
            dr(8) = i.bi02

            dr(9) = i.igv01
            dr(10) = i.icbper
            dr(11) = i.ImporteNacional


            Select Case i.estadoCobro
                Case "DC"
                    dr(12) = "Cobrado"
                Case "ANU"
                    dr(12) = "Anulado"
                Case TIPO_VENTA.AnuladaPorNotaCredito
                    dr(12) = "Anulado x NC."
                Case Else
                    dr(12) = "-"
            End Select



            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub

    'electronicas
    Private Sub GetListarRegistroVentasElectronicas(period As String)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim ListaTipo As New List(Of String)

        'ListaTipo.Add(TIPO_VENTA.VENTA_GENERAL)
        'ListaTipo.Add(TIPO_VENTA.VENTA_HEREDAD)
        'ListaTipo.Add(TIPO_VENTA.VENTA_POS_DIRECTA)
        'ListaTipo.Add(TIPO_VENTA.VENTA_ANTICIPADA_OTORGADO)

        'ListaTipo.Add(TIPO_VENTA.VENTA_AL_TICKET)
        'ListaTipo.Add(TIPO_COMPRA.NOTA_CREDITO)
        'ListaTipo.Add(TIPO_COMPRA.NOTA_DEBITO)
        ListaTipo.Add(TIPO_VENTA.VENTA_ELECTRONICA)
        ListaTipo.Add(TIPO_COMPRA.NOTA_CREDITO_ELECTRONICA)


        Dim dt As New DataTable("Ventas de - " & period)
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
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



        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarRegistroVentasXTipo(GEstableciento.IdEstablecimiento, period, ListaTipo)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = str
            dr(2) = i.tipoDocumento
            dr(3) = i.serieVenta
            dr(4) = i.numeroVenta

            Select Case i.NroDocEntidad
                Case Is = Nothing

                    dr(5) = "-"
                    dr(6) = i.nombrePedido
                Case Else

                    dr(5) = i.NroDocEntidad
                    dr(6) = i.NombreEntidad
            End Select



            dr(7) = i.bi01
            dr(8) = i.bi02

            dr(9) = i.igv01
            dr(10) = i.icbper.GetValueOrDefault
            dr(11) = i.ImporteNacional


            Select Case i.estadoCobro
                Case "DC"
                    dr(12) = "Cobrado"
                Case "ANU"
                    dr(12) = "Anulado"
                Case TIPO_VENTA.AnuladaPorNotaCredito
                    dr(12) = "Anulado x NC."
                Case Else
                    dr(12) = "-"
            End Select



            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub


    'todos
    Private Sub GetListaVentasPorPeriodo(period As String)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Ventas de - " & period)
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
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

        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarRegistroVentas(GEstableciento.IdEstablecimiento, period)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = str
            dr(2) = i.tipoDocumento
            dr(3) = i.serieVenta
            dr(4) = i.numeroVenta

            Select Case i.NroDocEntidad
                Case Is = Nothing

                    dr(5) = "-"
                    dr(6) = i.nombrePedido
                Case Else

                    dr(5) = i.NroDocEntidad
                    dr(6) = i.NombreEntidad
            End Select



            dr(7) = i.bi01
            dr(8) = i.bi02

            dr(9) = i.igv01
            dr(10) = i.icbper
            dr(11) = i.ImporteNacional


            Select Case i.estadoCobro
                Case "DC"
                    dr(12) = "Cobrado"
                Case "ANU"
                    dr(12) = "Anulado"
                Case TIPO_VENTA.AnuladaPorNotaCredito
                    dr(12) = "Anulado x NC."
                Case Else
                    dr(12) = "-"
            End Select

            'dr(1) = i.tipoVenta
            'dr(2) = str

            'dr(4) = i.tipoDocumento
            'dr(5) = i.serieVenta
            'Select Case i.tipoVenta
            '    Case TIPO_VENTA.VENTA_AL_TICKET, TIPO_VENTA.VENTA_POS_DIRECTA
            '        dr(6) = i.numeroVenta

            '    Case TIPO_VENTA.COTIZACION
            '        dr(6) = i.numeroDoc

            '    Case TIPO_VENTA.VENTA_GENERAL
            '        dr(6) = i.numeroVenta
            '    Case "NTC"
            '        dr(6) = i.numeroVenta
            '    Case TIPO_VENTA.VENTA_MEMBRESIAS_GIMANSIO
            '        dr(6) = i.numeroDoc
            '    Case Else
            '        dr(6) = i.numeroVenta
            'End Select
            'Select Case i.NroDocEntidad
            '    Case Is = Nothing
            '        dr(3) = i.nombrePedido
            '        dr(7) = "-"
            '        dr(8) = i.nombrePedido
            '    Case Else
            '        dr(3) = i.NombreEntidad
            '        dr(7) = i.NroDocEntidad
            '        dr(8) = i.NombreEntidad
            'End Select

            'dr(9) = FormatNumber(i.ImporteNacional, 2)
            'dr(10) = i.tipoCambio
            'dr(11) = FormatNumber(i.ImporteExtranjero, 2)
            'dr(12) = i.moneda
            'dr(13) = i.usuarioActualizacion

            'Select Case i.tipoVenta
            '    Case "NTC"
            '        dr(14) = "-"

            '    Case TIPO_VENTA.VENTA_MEMBRESIAS_GIMANSIO
            '        Select Case i.estadoCobro
            '            Case Gimnasio_EstadoMembresiaPago.Completo
            '                dr(14) = "Cobrado"
            '            Case Gimnasio_EstadoMembresiaPago.IngresoLibre
            '                dr(14) = "Libre"
            '            Case Gimnasio_EstadoMembresiaPago.PagoParcial
            '                dr(14) = "Parcial"
            '            Case Gimnasio_EstadoMembresiaPago.Pendiente
            '                dr(14) = "Pendiente"
            '        End Select

            '    Case Else
            '        Select Case i.estadoCobro
            '            Case "DC"
            '                dr(14) = "Cobrado"
            '            Case "ANU"
            '                dr(14) = "Anulado"
            '            Case TIPO_VENTA.AnuladaPorNotaCredito
            '                dr(14) = "Anulado x NC."
            '            Case Else
            '                dr(14) = "Pendiente"
            '        End Select
            'End Select


            'Select Case i.notaCredito
            '    Case StatusVentaMatizados.PorPreparar
            '        dr(15) = "Pendiente"
            '    Case StatusVentaMatizados.TerminadaYentregada
            '        dr(15) = "Entregada"
            'End Select
            'If i.tipoVenta = "NTC" Then
            '    dr(16) = i.idPadre
            'End If

            'dr(17) = i.EnvioSunat

            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub

    Public Sub setDatasource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            Dim deleg As New SetDataSourceDelegate(AddressOf setDatasource)
            Invoke(deleg, New Object() {table})
        Else
            GridVentas.DataSource = table
            'ProgressBar1.Visible = False
        End If
    End Sub
#End Region

    Private Sub FormRegistroVentaMensual_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Panel28_Click(sender As Object, e As EventArgs) Handles Panel28.Click
        Dim converter As New GroupingGridExcelConverterControl

        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "Files(*.xls)|*.xls"
        saveFileDialog.DefaultExt = ".xls"


        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            'If radioButton1.Checked Then
            converter.GroupingGridToExcel(Me.GridVentas, saveFileDialog.FileName, Syncfusion.GridExcelConverter.ConverterOptions.Visible)
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

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dim periodo = String.Format("{0:00}", cboMes2.SelectedValue)
        periodo = periodo & "/" & cboaño2.Text

        Select Case cboTipoVenta.Text
            Case "VENTAS ELECTRONICAS"
                GetListarRegistroVentasElectronicas(periodo)
            Case "VENTAS FISICAS"
                GetListarRegistroVentasFisicas(periodo)
            Case "TODAS LAS VENTAS"

                GetListaVentasPorPeriodo(periodo)
        End Select


        'Dim periodo = String.Format("{0:00}", cboMesPedido.SelectedValue)
        'periodo = periodo & "/" & cboAnio.Text
        'If chktodos.Checked = True Then
        '    GetListaVentasPorPeriodo(periodo)
        'ElseIf chkelectronicos.Checked = True Then
        '    GetListarRegistroVentasElectronicas(periodo)

        'ElseIf chkfisicas.Checked = True Then
        '    GetListarRegistroVentasFisicas(periodo)
        'End If
    End Sub

    Private Sub chktodos_CheckedChanged(sender As Object, e As EventArgs) Handles chktodos.CheckedChanged
        If chktodos.Checked = True Then
            chkelectronicos.Checked = False
            chkfisicas.Checked = False
        End If
    End Sub

    Private Sub chkelectronicos_CheckedChanged(sender As Object, e As EventArgs) Handles chkelectronicos.CheckedChanged
        If chkelectronicos.Checked = True Then
            chktodos.Checked = False
            chkfisicas.Checked = False
        End If
    End Sub

    Private Sub chkfisicas_CheckedChanged(sender As Object, e As EventArgs) Handles chkfisicas.CheckedChanged
        If chkfisicas.Checked = True Then
            chktodos.Checked = False
            chkelectronicos.Checked = False
        End If
    End Sub

    Private Sub Panel28_Paint(sender As Object, e As PaintEventArgs) Handles Panel28.Paint

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dispose()
    End Sub
End Class