Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.GridHelperClasses
Imports PopupControl
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Public Class frmNotaCreditoModal
    Inherits frmMaster
    Private theFilterBar As New GridFilterBar
    Public Property RucProveedor() As String
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
     
    End Sub

#Region "Metodos Auxiliares Grid"

    ''' <summary>
    ''' Permite obtener el valor de un columna especifica de la fila que está actualmente seleccionada
    ''' </summary>
    ''' <param name="Grid"></param>
    '''  <param name="ColumnId"></param>
    '''  <param name="RowIndex"></param>
    ''' <returns>String</returns>
    ''' <remarks></remarks>
    Private Function GetCellValue(Grid As GridDataBoundGrid, ColumnId As String, RowIndex As Integer) As String
        Dim ColIndex As Integer = GetColIndexById(Grid, ColumnId)

        Dim CellText As String = Grid.Item(RowIndex, ColIndex).FormattedText
        Return CellText
    End Function



    ''' <summary>
    ''' Permite obtener el valor de un columna especifica de la fila que está actualmente seleccionada
    ''' </summary>
    ''' <param name="Grid"></param>
    '''  <param name="ColumnId"></param>
    ''' <returns>String</returns>
    ''' <remarks></remarks>
    Private Function GetCellValue(Grid As GridDataBoundGrid, ColumnId As String) As String
        Dim ColIndex As Integer = GetColIndexById(Grid, ColumnId)
        Dim RowIndex As Integer = GetSelectedRow(Grid)

        Dim CellText As String = Grid.Item(RowIndex, ColIndex).FormattedText
        Return CellText
    End Function

    Private Function GetCellMemberValue(Grid As GridDataBoundGrid, ColumnId As String) As String
        Dim ColIndex As Integer = GetColIndexById(Grid, ColumnId)
        Dim RowIndex As Integer = GetSelectedRow(Grid)

        Dim CellText As String = Grid.Item(RowIndex, ColIndex).CellValue
        Return CellText
    End Function

    Private Sub SetCellMemberValue(Grid As GridDataBoundGrid, ColumnId As String, value As String)
        Dim ColIndex As Integer = GetColIndexById(Grid, ColumnId)
        Dim RowIndex As Integer = GetSelectedRow(Grid)

        Grid.Item(RowIndex, ColIndex).Text = value
        Grid.Item(RowIndex, ColIndex).CellValue = value


    End Sub

    ''' <summary>
    ''' Permite obtener el index de la fila que está actualmente seleccionada
    ''' </summary>
    ''' <param name="Grid"></param>
    ''' <returns>Integer</returns>
    ''' <remarks></remarks>
    Private Function GetSelectedRow(Grid As GridDataBoundGrid) As Integer
        Dim SelectedRow = Grid.Selections.GetSelectedRows(True, False)
        Return Grid.Binder.CurrentRowIndex()
    End Function

    ''' <summary>
    ''' Permite obtener el index de la columna pasada por parametros
    ''' </summary>
    ''' <param name="Grid"></param>
    '''  <param name="ColumnId"></param>
    ''' <returns>Integer</returns>
    ''' <remarks></remarks>
    Private Function GetColIndexById(Grid As GridDataBoundGrid, ColumnId As String) As Integer
        Dim ColIndex As Integer
        ColIndex = Grid.NameToColIndex(ColumnId)

        Return ColIndex
    End Function
#End Region

#Region "Métodos"
    Private Sub UbicarCompraNroSerie()
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim documentoCompra As New List(Of documentocompra)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("tipoCompra", GetType(String))
        dt.Columns.Add("Fecha", GetType(String))
        dt.Columns.Add("periodo", GetType(String))

        dt.Columns.Add("TipoDoc", GetType(String))
        dt.Columns.Add("Serie", GetType(String))
        dt.Columns.Add("Numero", GetType(String))
        dt.Columns.Add("moneda", GetType(String))

        documentoCompra = documentoCompraSA.UbicarCompraPorProveedorXperiodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, RucProveedor, txtPeriodo.Text)
        Dim str As String
        If Not IsNothing(documentoCompra) Then
            For Each i In documentoCompra
                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
                dr(0) = i.idDocumento
                dr(1) = i.tipoCompra
                dr(2) = str
                dr(3) = i.fechaContable
                dr(4) = tablaSA.GetUbicarTablaID(10, i.tipoDoc).descripcion.Substring(0, 3)
                dr(5) = i.serie
                dr(6) = i.numeroDoc
                Select Case i.monedaDoc
                    Case 1
                        dr(7) = "NAC"
                    Case Else
                        dr(7) = "EXT"
                End Select

                dt.Rows.Add(dr)
            Next
            '   Me.GDB.DataSource = dt
            Me.GDB.BeginUpdate()
            Me.GDB.Binder.SetDataBinding(dt, "")
            GDB.GridBoundColumns.Item("idDocumento").Hidden = True
            GDB.GridBoundColumns.Item("Fecha").Width = 100


            '    Me.GDB.ListBoxSelectionMode = SelectionMode.One

            If Not theFilterBar Is Nothing And Not theFilterBar.Wired Then
                theFilterBar.WireGrid(Me.GDB)
                '    Me.label2.Text = ""
            End If
            Me.GDB.RefreshRange(GridRangeInfo.Row(1))
        Else

        End If
    End Sub
#End Region

    Private Sub frmNotaCreditoModal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmNotaCreditoModal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      
        txtPeriodo.Select()
    End Sub

    Private Sub txtPeriodo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPeriodo.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            UbicarCompraNroSerie()
            Me.GDB.Model.ColWidths.ResizeToFit(GridRangeInfo.Row(0))
            Me.GDB.CurrentCell.MoveTo(1, 1)
            Me.GDB.EndUpdate()
            Me.GDB.DefaultRowHeight = 18
            Me.GDB.DefaultColWidth = 120
            Me.GDB.BackColor = Color.White
            Me.GDB.ResizeColsBehavior = GridResizeCellsBehavior.ResizeAll
        End If
    End Sub

    Private Sub txtPeriodo_TextChanged(sender As Object, e As EventArgs) Handles txtPeriodo.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GDB_CellClick(sender As Object, e As GridCellClickEventArgs) Handles GDB.CellClick

    End Sub

    Private Sub GDB_CellDoubleClick(sender As Object, e As GridCellClickEventArgs) Handles GDB.CellDoubleClick

    End Sub

    Private Sub GDB_CurrentCellControlDoubleClick(sender As Object, e As ControlEventArgs) Handles GDB.CurrentCellControlDoubleClick
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        Dim n As New RecuperarCarteras

        Dim documentoCompraSA As New DocumentoCompraDetalleSA
        If documentoCompraSA.TieneItemsEnAV(GetCellValue(GDB, "idDocumento")) = True Then
            '     PanelError.Visible = True
            lblEstado.Text = "El comprobante posee items en tránsito," & "necesita realizar la distribución, para seguir el proceso!"
            'Timer1.Enabled = True
            'TiempoEjecutar(10)
            Me.Cursor = Cursors.Arrow
        Else
            n.ID = GetCellValue(GDB, "idDocumento")
            n.Cuenta = GetCellValue(GDB, "TipoDoc")
            n.Apmat = GetCellValue(GDB, "Serie")
            n.Appat = GetCellValue(GDB, "Numero")
            n.NomProceso = GetCellValue(GDB, "tipoCompra")
            n.NomEvento = GetCellValue(GDB, "moneda")
            datos.Add(n)
            Dispose()
        End If
    End Sub
End Class