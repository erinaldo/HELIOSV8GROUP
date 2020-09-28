Imports System.Reflection
Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Module ListExtension
    ''' <summary>
    ''' Gets a Datatable with all Browsable properties of T as columns containing all Items in the List.
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="List">System.Collections.Generic.List(Of T)</param>
    ''' <returns>System.Data.DataTable</returns>
    ''' <remarks>http://aprendiendonet.blogspot.com</remarks>
    <Extension()>
    Public Function ToDataTable(Of T)(ByVal List As List(Of T)) As DataTable
        Dim dt As New DataTable()

        Dim tipo As Type = GetType(T)
        Dim members As MemberInfo() = tipo.GetMembers() ' Obtenemos todos los Miembros de la clase correspondiente al tipo T

        For Each m As MemberInfo In members
            If m.MemberType = MemberTypes.Property Then ' Sólo nos interesan las propiedades
                Dim skip As Boolean = False

                Dim atts As Object() = m.GetCustomAttributes(GetType(BrowsableAttribute), False) ' Chequeamos si tiene BrowsableAttribute
                If atts.Length > 0 Then
                    If CType(atts(0), BrowsableAttribute).Browsable = False Then
                        skip = True ' Seteamos un flag para no agregar la columna
                    End If
                End If

                If Not skip Then
                    Dim c As DataColumn = Nothing
                    Try
                        c = New DataColumn(m.Name, CType(m, PropertyInfo).PropertyType) ' Nueva columna con el nombre de la propiedad y el tipo de la misma
                    Catch ex As Exception
                        c = New DataColumn(m.Name, GetType(String)) ' En caso de error intento crearla como String
                    End Try
                    dt.Columns.Add(c)
                End If
            End If
        Next

        For Each itm As T In List ' Recorro la lista y agrego una fila por cada item de la misma
            Dim r As DataRow = dt.NewRow()
            For Each c As DataColumn In r.Table.Columns
                Dim aux As MemberInfo() = tipo.GetMember(c.ColumnName)
                If aux.Length > 0 Then
                    r(c.ColumnName) = CType(aux(0), PropertyInfo).GetValue(itm, Nothing)
                End If
            Next
            dt.Rows.Add(r)
        Next

        Return dt
    End Function

End Module