Imports System
Imports System.IO
Imports System.Collections
Module LEER

    'LEER EL ARCHIVO Y LLAMA AL METODO AGREGARFILADATAGRIDVIEW PARA QUE POR CADA LINEA DEL BLOC AGREGUE UNA LINEA EN EL DATAGRIDVIEW'
    Sub LECTURAARCHIVO(ByVal TABLA As DataGridView, ByVal CARACTER As String, ByVal RUTA As String)
        Dim OBJREADER As New StreamReader(RUTA)
        Dim SLINE As String = ""
        Dim FILA As Integer = 0
        Dim FILA2 As Integer = 0
        TABLA.Rows.Clear()
        TABLA.AllowUserToAddRows = False
        Do
            SLINE = OBJREADER.ReadLine()
            If Not SLINE Is Nothing Then
                If FILA = 0 Then
                    TABLA.ColumnCount = SLINE.Split(CARACTER).Length
                    NOMBRARTITULO(TABLA, SLINE.Split(CARACTER))
                    FILA += 1
                Else
                    AGREGARFILADATAGRIDVIEW(TABLA, SLINE, "|", FILA2)
                    FILA2 += 1
                End If
            End If
        Loop Until SLINE Is Nothing
        OBJREADER.Close()
    End Sub

    'AGREGAR EL HEADERTEXT AL DATAGRIDVIEW(SON LOS TITULOS)'
    Sub NOMBRARTITULO(ByVal TABLA As DataGridView, ByVal TITULOS() As String)
        Dim X As Integer = 0
        For X = 0 To TABLA.ColumnCount - 1
            TABLA.Columns(X).HeaderText = TITULOS(X)
        Next
    End Sub

    'AGREGA UNA FILA POR CADA LINEA DE BLOC DE NOTAS :D'
    Sub AGREGARFILADATAGRIDVIEW(ByVal TABLA As DataGridView, ByVal LINEA As String, ByVal CARACTER As String, ByVal FILA As Integer)
        Dim ARREGLO() As String = LINEA.Split(CARACTER)
        TABLA.ColumnCount = ARREGLO.Length
        TABLA.Rows.Add()
        Dim X As Integer = 0
        For X = 0 To TABLA.ColumnCount - 1
            TABLA.Item(X, FILA).Value = ARREGLO(X)
        Next
    End Sub

End Module
