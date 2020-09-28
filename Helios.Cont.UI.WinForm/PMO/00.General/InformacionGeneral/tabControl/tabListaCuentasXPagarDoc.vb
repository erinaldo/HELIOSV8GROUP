Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Public Class tabListaCuentasXPagarDoc

    Property CierreSA As New empresaCierreMensualSA
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
    Dim filter As New GridExcelFilter()

    Public Sub New(listaUsuario As List(Of Integer), idEntidad As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGrid(dgPedidos)

        Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetListaVentasPorPeriodo(listaUsuario, idEntidad)))
        thread.Start()
    End Sub

#Region "METODOS"
    Private Sub GetListaVentasPorPeriodo(listaUsuario As List(Of Integer), idEntidad As Integer)
        Dim documentocajaSA As New DocumentoCajaSA
        Dim DocumentoBE As New documentoCaja
        Dim dt As New DataTable("Ventas")

        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))

        DocumentoBE = New documentoCaja
        DocumentoBE.idEmpresa = Gempresas.IdEmpresaRuc
        DocumentoBE.idEstablecimiento = GEstableciento.IdEstablecimiento
        DocumentoBE.movimientoCaja = MovimientoCaja.PagoProveedor
        DocumentoBE.entidadFinanciera = idEntidad

        Dim str As String
        For Each i As documentoCaja In documentocajaSA.DocCajaXDocumento(DocumentoBE, listaUsuario)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaProceso).ToString("dd-MMM hh:mm tt ")

            dr(0) = i.movimientoCaja
            dr(1) = str
            dr(2) = i.tipoDocPago
            dr(3) = i.numeroDoc
            dr(4) = i.NumeroDocumento
            dr(5) = i.NombreEntidad
            dr(6) = FormatNumber(i.montoSoles, 2)
            dr(7) = TmpTipoCambio
            dr(8) = FormatNumber(i.montoUsd, 2)

            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub

    Public Sub setDatasource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            Dim deleg As New SetDataSourceDelegate(AddressOf setDatasource)
            Invoke(deleg, New Object() {table})
        Else
            dgPedidos.DataSource = table
            'ProgressBar1.Visible = False
        End If
    End Sub

    Private Sub dgPedidos_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgPedidos.QueryCellStyleInfo
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
