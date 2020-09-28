Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid

Public Class UCTransferenciasXEmpresa

#Region "Attributes"
    Public Property ventaSA As New documentoVentaAbarrotesSA
    Public Property TablaSA As New tablaDetalleSA
    Private listaOperacion As List(Of tabladetalle)
    Dim Alert As Alert
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        '  FormatoGridBlack(dgvcompras, True)
        dgvcompras.Appearance.AnyCell.TextColor = Color.WhiteSmoke
        dgvcompras.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        dgvcompras.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        dgvcompras.TableOptions.ListBoxSelectionMode = SelectionMode.One
        dgvcompras.TableOptions.SelectionBackColor = Color.FromArgb(85, 170, 255)
        dgvcompras.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        dgvcompras.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        dgvcompras.TableDescriptor.VisibleColumns.RemoveAt(0)
        'dgvcompras.TableDescriptor.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(36, 41, 46))
        'FormatoGridAvanzado(dgvcompras, True, False)
    End Sub

#End Region

#Region "Methods"
    Private Sub GetTrasnferenciasDia(period As DateTime, dia As DateTime)
        Dim dt As New DataTable("Transferencias: - " & period)
        dt.Columns.Add(New DataColumn("idDocumento", GetType(documentoventaAbarrotes)))
        dt.Columns.Add(New DataColumn("fecha", GetType(String)))
        dt.Columns.Add(New DataColumn("comprobante", GetType(String)))
        dt.Columns.Add(New DataColumn("nro", GetType(String)))
        dt.Columns.Add(New DataColumn("almacenpartida", GetType(String)))
        dt.Columns.Add(New DataColumn("almacenllegada", GetType(String)))
        dt.Columns.Add(New DataColumn("itemsTransferidos", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))


        Dim str As String
        For Each i As documentoventaAbarrotes In ventaSA.GetTransferenciasPeriodo(New documentoventaAbarrotes With {.fechaDoc = period, .idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento}) _
            .Where(Function(o) o.fechaDoc.Value.Year = dia.Year And
                               o.fechaDoc.Value.Month = dia.Month And
                               o.fechaDoc.Value.Day = dia.Day).ToList
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i
            dr(1) = str
            dr(2) = i.tipoDocumento
            dr(3) = $"{i.serieVenta}-{i.numeroVenta}"
            dr(4) = i.documentoventaAbarrotesDet.FirstOrDefault.CustomAlmacenPartida.descripcionAlmacen
            dr(5) = i.documentoventaAbarrotesDet.FirstOrDefault.CustomAlmacenLlegada.descripcionAlmacen
            dr(6) = $"{i.documentoventaAbarrotesDet.Count} - Item(s)"
            dr(7) = "Entregado"
            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub


    Private Sub GetListaVentasPorTipo(period As DateTime)
        Dim dt As New DataTable("Transferencias: - " & period)
        dt.Columns.Add(New DataColumn("idDocumento", GetType(documentoventaAbarrotes)))
        dt.Columns.Add(New DataColumn("fecha", GetType(String)))
        dt.Columns.Add(New DataColumn("comprobante", GetType(String)))
        dt.Columns.Add(New DataColumn("nro", GetType(String)))
        dt.Columns.Add(New DataColumn("almacenpartida", GetType(String)))
        dt.Columns.Add(New DataColumn("almacenllegada", GetType(String)))
        dt.Columns.Add(New DataColumn("itemsTransferidos", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))


        Dim str As String
        For Each i As documentoventaAbarrotes In ventaSA.GetTransferenciasPeriodo(New documentoventaAbarrotes With {.fechaDoc = period, .idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento})
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i
            dr(1) = str
            dr(2) = i.tipoDocumento
            dr(3) = $"{i.serieVenta}-{i.numeroVenta}"
            dr(4) = i.documentoventaAbarrotesDet.FirstOrDefault.CustomAlmacenPartida.descripcionAlmacen
            dr(5) = i.documentoventaAbarrotesDet.FirstOrDefault.CustomAlmacenLlegada.descripcionAlmacen
            dr(6) = $"{i.documentoventaAbarrotesDet.Count} - Item(s)"
            dr(7) = "Entregado"
            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub

    Public Sub setDatasource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            Dim deleg As New SetDataSourceDelegate(AddressOf setDatasource)
            Invoke(deleg, New Object() {table})
        Else
            dgvcompras.DataSource = table
            PictureLoad.Visible = False
            BunifuFlatButton5.Enabled = True
            BunifuFlatButton3.Enabled = True
        End If
    End Sub
#End Region

#Region "Events"
    Private Sub BunifuFlatButton5_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton5.Click
        Dim f As New FormFiltroAvanzadoPeriodo()
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim periodoSel = CType(f.Tag, DateTime?)
            PictureLoad.Visible = True
            BunifuFlatButton5.Enabled = False
            'GetMovPorPeriodo(GEstableciento.IdEstablecimiento, GetPeriodo(periodoSel, True))
            Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetListaVentasPorTipo(periodoSel)))
            thread.Start()
        End If
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        Dim r As Record = dgvcompras.Table.CurrentRecord
        If r IsNot Nothing Then
            Dim obj = CType(r.GetValue("idDocumento"), documentoventaAbarrotes)
            Dim f As New FormSalidasInventarioVenta(obj)
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
        End If
    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        Dim f As New FormFiltroAvanzadoDia()
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            PictureLoad.Visible = True
            BunifuFlatButton5.Enabled = False
            Dim FechaSel = CType(f.Tag, DateTime?)

            Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetTrasnferenciasDia(FechaSel, FechaSel)))
            thread.Start()


            'GetMovDia(FechaSel, GEstableciento.IdEstablecimiento)
        End If
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Dim r As Record = dgvcompras.Table.CurrentRecord
        If r IsNot Nothing Then
            Dim obj = CType(r.GetValue("idDocumento"), documentoventaAbarrotes)
            Dim f As New FormMovimientosItemLote(obj)
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
        End If
    End Sub

    Private Sub dgvcompras_TableControlCellClick(sender As Object, e As Grouping.GridTableControlCellClickEventArgs) Handles dgvcompras.TableControlCellClick

    End Sub

    Private Sub UCTransferenciasXEmpresa_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
#End Region

End Class
