Imports Helios.Cont.Business.Entity
Imports Helios.Cont.Presentation.WinForm
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Drawing
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Chart
Imports Syncfusion.Windows.Forms.Grid
Public Class UCSalesBySeller

#Region "Atributos"
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
#End Region

#Region "Constructor"
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        FormatoGridAvanzado(DgvComprobantes, False, False, 8.0F)
        'FormatoGrid(DgvComprobantes)
        ' Add any initialization after the InitializeComponent() call.
        FormatoGridPrincipal(DgvComprobantes)
    End Sub
#End Region

#Region "Metodsos"

    Public Sub GetListSalesPerSeller(be As List(Of documentoventaAbarrotes))
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Ventas")
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("enviosunat", GetType(String)))

        Dim str As String

        For Each i As documentoventaAbarrotes In be
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoVenta
            dr(2) = str
            dr(3) = i.tipoDocumento
            dr(4) = i.serieVenta
            Select Case i.tipoVenta
                Case TIPO_VENTA.VENTA_AL_TICKET, TIPO_VENTA.VENTA_POS_DIRECTA
                    dr(5) = i.numeroVenta

                Case TIPO_VENTA.COTIZACION
                    dr(5) = i.numeroDoc

                Case TIPO_VENTA.VENTA_GENERAL
                    dr(5) = i.numeroVenta
                Case "NTC"
                    dr(5) = i.numeroVenta
                Case TIPO_VENTA.VENTA_MEMBRESIAS_GIMANSIO
                    dr(5) = i.numeroDoc
                Case Else
                    dr(5) = i.numeroVenta
            End Select

            Select Case i.NroDocEntidad
                Case Is = Nothing
                    dr(6) = "-"
                Case Else
                    dr(6) = i.NombreEntidad
            End Select

            dr(7) = FormatNumber(i.ImporteNacional, 2)
            dr(8) = i.moneda

            If UsuariosList IsNot Nothing Then
                Dim vendedor = UsuariosList.Where(Function(o) o.IDUsuario = i.usuarioActualizacion).SingleOrDefault
                dr(9) = vendedor.Full_Name ' i.usuarioActualizacion
            End If


            dr(10) = i.EnvioSunat
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
            'UCResumenVentasCustom.PictureLoad.Visible = False
            'SumatoriaGeneral()
        End If
    End Sub

    'Private Sub SumatoriaGeneral()
    '    Dim ventasFull = ListaVentas.Sum(Function(o) o.ImporteNacional).GetValueOrDefault
    '    Dim ventasContado = ListaVentas.Where(Function(o) o.estadoCobro = TIPO_VENTA.PAGO.COBRADO).Sum(Function(o) o.ImporteNacional).GetValueOrDefault

    '    Dim ventasCredito = ListaVentas.Where(Function(o) o.estadoCobro <> TIPO_VENTA.PAGO.COBRADO).Sum(Function(o) o.ImporteNacional).GetValueOrDefault

    '    UCResumenVentasCustom.LabelTotalVentas.Text = $"S/{CDec(ventasFull).ToString("N2")}"
    '    UCResumenVentasCustom.LabelAlContado.Text = $"S/{CDec(ventasContado).ToString("N2")}"
    '    UCResumenVentasCustom.LabelAlCredito.Text = $"S/{CDec(ventasCredito).ToString("N2")}"
    'End Sub

#End Region


End Class
