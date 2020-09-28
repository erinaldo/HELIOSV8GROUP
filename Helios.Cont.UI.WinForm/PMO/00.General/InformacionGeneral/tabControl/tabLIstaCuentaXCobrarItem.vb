Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Public Class tabLIstaCuentaXCobrarItem
    Property CierreSA As New empresaCierreMensualSA
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
    Dim filter As New GridExcelFilter()
    Private anioSel As String
    Private mesSel As String

    Public Sub New(listaUsuario As List(Of Integer), listIDCajas As List(Of Integer), FechaLaboral As Date)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGrid(dgPedidos)

        Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetListaVentasPorPeriodo(listaUsuario, listIDCajas, FechaLaboral)))
        thread.Start()
    End Sub


#Region "METODOS"
    Private Sub GetListaVentasPorPeriodo(listaUsuario As List(Of Integer), listIDCajas As List(Of Integer), FechaLaboral As Date)
        Dim documentocajaSA As New DocumentoCajaDetalleSA
        Dim DocumentoBE As New documentoCaja
        Dim dt As New DataTable("Ventas")

        dt.Columns.Add(New DataColumn("detalleItem", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("glosario", GetType(String)))
        '  dt.Columns.Add(New DataColumn("color", GetType(Decimal)))

        DocumentoBE = New documentoCaja
        DocumentoBE.fechaProceso = FechaLaboral
        DocumentoBE.idEmpresa = Gempresas.IdEmpresaRuc
        DocumentoBE.idEstablecimiento = GEstableciento.IdEstablecimiento
        DocumentoBE.movimientoCaja = MovimientoCaja.CobroCliente
        'DocumentoBE.entidadFinanciera = idEntidad
        DocumentoBE.ListaIDCajas = listIDCajas

        Dim str As String
        For Each i As documentoCajaDetalle In documentocajaSA.DocCajaXItem(DocumentoBE, listaUsuario)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")

            dr(0) = i.DetalleItem
            dr(1) = str
            dr(2) = i.tipoDocumento
            dr(3) = i.numeroDoc
            dr(4) = i.nomEntidad
            dr(5) = FormatNumber(i.montoSoles, 2)
            dr(6) = TmpTipoCambio
            dr(7) = FormatNumber(i.montoUsd, 2)
            dr(8) = i.glosario

            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub

    'Public Function CalculoRentabilidadOperdida() As Decimal
    '    Dim precioCompra = 
    'End Function

    Public Sub setDatasource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            Dim deleg As New SetDataSourceDelegate(AddressOf setDatasource)
            Invoke(deleg, New Object() {table})
        Else
            dgPedidos.DataSource = table
            'ProgressBar1.Visible = False
        End If
    End Sub

    Private Sub dgPedidos_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs)
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            dgPedidos.TableControl.Selections.Clear()
        End If
    End Sub

#End Region
End Class
