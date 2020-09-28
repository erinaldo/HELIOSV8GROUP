Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms
Public NotInheritable Class MetodosGenericos

#Region "Metodos Auxiliares Grid"

    ''' <summary>
    ''' Permite obtener el valor de un columna especifica de la fila que está actualmente seleccionada
    ''' </summary>
    ''' <param name="Grid"></param>
    '''  <param name="ColumnId"></param>
    '''  <param name="RowIndex"></param>
    ''' <returns>String</returns>
    ''' <remarks></remarks>
    Public Shared Function GetCellValue(Grid As GridDataBoundGrid, ColumnId As String, RowIndex As Integer) As String
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
    Public Shared Function GetCellValue(Grid As GridDataBoundGrid, ColumnId As String) As String
        Dim ColIndex As Integer = GetColIndexById(Grid, ColumnId)
        Dim RowIndex As Integer = GetSelectedRow(Grid)

        Dim CellText As String = Grid.Item(RowIndex, ColIndex).FormattedText
        Return CellText
    End Function


    Public Shared Function GetCellMemberValue(Grid As GridDataBoundGrid, ColumnId As String) As String
        Dim ColIndex As Integer = GetColIndexById(Grid, ColumnId)
        Dim RowIndex As Integer = GetSelectedRow(Grid)

        Dim CellText As String = Grid.Item(RowIndex, ColIndex).CellValue
        Return CellText
    End Function

    Public Shared Sub SetCellMemberValue(Grid As GridDataBoundGrid, ColumnId As String, value As String)
        Dim ColIndex As Integer = GetColIndexById(Grid, ColumnId)
        Dim RowIndex As Integer = GetSelectedRow(Grid)

        Grid.Item(RowIndex, ColIndex).Text = value
        Grid.Item(RowIndex, ColIndex).CellValue = value


    End Sub

    Public Shared Sub SetCellMemberValue(Grid As GridDataBoundGrid, ColumnId As String, RowIndex As Integer, value As String)
        Dim ColIndex As Integer = GetColIndexById(Grid, ColumnId)

        Grid.Item(RowIndex, ColIndex).Text = value
        Grid.Item(RowIndex, ColIndex).CellValue = value


    End Sub

    Public Shared Sub SetCellFontBold(Grid As GridDataBoundGrid, ColumnId As String, bold As Boolean)
        Dim ColIndex As Integer = GetColIndexById(Grid, ColumnId)
        Dim RowIndex As Integer = GetSelectedRow(Grid)

        Dim CellText As String = Grid.Item(RowIndex, ColIndex).Font.Bold = bold

    End Sub

    ''' <summary>
    ''' Permite obtener el index de la fila que está actualmente seleccionada
    ''' </summary>
    ''' <param name="Grid"></param>
    ''' <returns>Integer</returns>
    ''' <remarks></remarks>
    Public Shared Function GetSelectedRow(Grid As GridDataBoundGrid) As Integer
        Return Grid.Binder.CurrentRowIndex()
    End Function


    ''' <summary>
    ''' Permite obtener el index de la columna pasada por parametros
    ''' </summary>
    ''' <param name="Grid"></param>
    '''  <param name="ColumnId"></param>
    ''' <returns>Integer</returns>
    ''' <remarks></remarks>
    Public Shared Function GetColIndexById(Grid As GridDataBoundGrid, ColumnId As String) As Integer
        Dim ColIndex As Integer
        ColIndex = Grid.NameToColIndex(ColumnId)

        Return ColIndex
    End Function
#End Region


End Class
