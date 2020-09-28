Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Public Class tabListaVentaXDoc

    Property CierreSA As New empresaCierreMensualSA
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
    Dim filter As New GridExcelFilter()
    Private anioSel As String
    Private mesSel As String

    Public Sub New(listaUsuario As List(Of Integer), ListaIDCajas As List(Of Integer), FechaLaboral As Date)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGrid(dgPedidos)

        Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetListaVentasPorPeriodo(listaUsuario, ListaIDCajas, FechaLaboral)))
        thread.Start()
    End Sub

#Region "METODOS"
    Private Sub GetListaVentasPorPeriodo(listaUsuario As List(Of Integer), ListaIDcajas As List(Of Integer), FechaLaboral As Date)
        Dim documentocajaSA As New DocumentoCajaSA
        Dim DocumentoBE As New documentoCaja
        Dim dt As New DataTable("Ventas")

        dt.Columns.Add("id")
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("glosario", GetType(String)))
        dt.Columns.Add("detail")

        DocumentoBE = New documentoCaja
        DocumentoBE.fechaProceso = FechaLaboral
        DocumentoBE.idEmpresa = Gempresas.IdEmpresaRuc
        DocumentoBE.idEstablecimiento = GEstableciento.IdEstablecimiento
        DocumentoBE.movimientoCaja = "VPOS"
        'DocumentoBE.entidadFinanciera = idEntidad
        DocumentoBE.ListaIDCajas = ListaIDcajas

        Dim str As String
        For Each i As documentoCaja In documentocajaSA.DocCajaXDocumentoVentas(DocumentoBE, listaUsuario)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaProceso).ToString("dd-MMM hh:mm tt ")

            dr(0) = i.idDocumento
            dr(1) = i.movimientoCaja
            dr(2) = str
            dr(3) = i.tipoDocPago
            dr(4) = i.numeroDoc
            dr(5) = i.NumeroDocumento
            dr(6) = i.NombreEntidad
            dr(7) = FormatNumber(i.montoSoles, 2)
            dr(8) = TmpTipoCambio
            dr(9) = FormatNumber(i.montoUsd, 2)
            dr(10) = i.glosa
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

#Region "Events"
    Private Sub dgvKardexVal_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles dgPedidos.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 9 Then
                e.Inner.Style.Description = "Details"
                e.Inner.Style.TextColor = Color.Black
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
                                           New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
                    )
                '    e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
            End If
        End If
    End Sub

    Private Sub dgvKardexVal_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles dgPedidos.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.Inner.ColIndex = 9 Then
                Dim idDocumento = dgPedidos.TableModel(e.Inner.RowIndex, 1).CellValue
                Dim cliente As String = dgPedidos.TableModel(e.Inner.RowIndex, 6).CellValue

                Dim tipodoc = dgPedidos.TableModel(e.Inner.RowIndex, 4).CellValue
                Dim numeroVenta = dgPedidos.TableModel(e.Inner.RowIndex, 5).CellValue
                Select Case tipodoc
                    Case "03"
                        tipodoc = "BOL. Nro. "
                    Case "01"
                        tipodoc = "FAC. Nro. "
                    Case Else
                        tipodoc = "NOTA. Nro. "

                End Select

                Dim comprobante As String = dgPedidos.TableModel(e.Inner.RowIndex, 1).CellValue
                comprobante = tipodoc & numeroVenta

                Dim f As New FormVentaDetalleModalRentaPerdida(idDocumento, cliente, comprobante)
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog(Me)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Me.Cursor = Cursors.Default
    End Sub
#End Region

End Class
