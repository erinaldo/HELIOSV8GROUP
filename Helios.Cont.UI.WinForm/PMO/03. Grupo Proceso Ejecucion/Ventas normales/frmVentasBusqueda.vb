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
Public Class frmVentasBusqueda
    Inherits frmMaster
    Private theFilterBar As New GridFilterBar
    Public Property RucProveedor() As String


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
        Dim documentoCompraSA As New documentoVentaAbarrotesSA
        Dim documentoCompra As New List(Of documentoventaAbarrotes)
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

        documentoCompra = documentoCompraSA.UbicarVentaPorClienteXperiodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, RucProveedor, txtPeriodo.Text)
        Dim str As String
        If Not IsNothing(documentoCompra) Then
            For Each i In documentoCompra
                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
                dr(0) = i.idDocumento
                dr(1) = i.tipoVenta
                dr(2) = str
                dr(3) = i.fechaPeriodo
                dr(4) = tablaSA.GetUbicarTablaID(10, i.tipoDocumento).descripcion.Substring(0, 3)
                dr(5) = i.serie
                dr(6) = i.numeroDoc
                Select Case i.moneda
                    Case 1
                        dr(7) = "NAC"
                    Case Else
                        dr(7) = "EXT"
                End Select

                dt.Rows.Add(dr)
            Next
            '   Me.GDB.DataSource = dt
            dgvCompra.DataSource = dt
            Me.dgvCompra.TableOptions.ListBoxSelectionMode = SelectionMode.One
            'GDB.GridBoundColumns.Item("idDocumento").Hidden = True
            'GDB.GridBoundColumns.Item("Fecha").Width = 100


            '    Me.GDB.ListBoxSelectionMode = SelectionMode.One

            'If Not theFilterBar Is Nothing And Not theFilterBar.Wired Then
            '    theFilterBar.WireGrid(Me.GDB)
            '    '    Me.label2.Text = ""
            'End If
            'Me.GDB.RefreshRange(GridRangeInfo.Row(1))
        Else

        End If
    End Sub
#End Region


    Private Sub frmVentasBusqueda_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub
    Private Sub frmVentasBusqueda_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtPeriodo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPeriodo.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            UbicarCompraNroSerie()
          
        End If
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellControlDoubleClick(sender As Object, e As GridTableControlControlEventArgs) Handles dgvCompra.TableControlCurrentCellControlDoubleClick
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        Dim n As New RecuperarCarteras
        n.ID = Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento") ' GetCellValue(GDB, "idDocumento")
        n.Cuenta = Me.dgvCompra.Table.CurrentRecord.GetValue("TipoDoc") ' GetCellValue(GDB, "TipoDoc")
        n.Apmat = Me.dgvCompra.Table.CurrentRecord.GetValue("Serie") 'GetCellValue(GDB, "Serie")
        n.Appat = Me.dgvCompra.Table.CurrentRecord.GetValue("Numero") ' GetCellValue(GDB, "Numero")
        n.NomProceso = Me.dgvCompra.Table.CurrentRecord.GetValue("tipoCompra") ' GetCellValue(GDB, "tipoCompra")
        n.NomEvento = Me.dgvCompra.Table.CurrentRecord.GetValue("moneda") ' GetCellValue(GDB, "moneda")
        datos.Add(n)
        Dispose()
    End Sub

    Private Sub txtPeriodo_TextChanged(sender As Object, e As EventArgs) Handles txtPeriodo.TextChanged

    End Sub
End Class