Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class tabladetalleBL
    Inherits BaseBL


    Public Sub GrabarListaTallaColor(lista As List(Of tabladetalle))
        Try
            Using ts As New TransactionScope
                HeliosData.tabladetalle.AddRange(lista)
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception

        End Try
    End Sub
    Function GetListaTablaDetalleTipos(strEstado As String)

        Dim list As New List(Of Integer)

        list.Add(18)
        list.Add(19)
        list.Add(25)
        list.Add(26)

        Return (From a In HeliosData.tabladetalle Where list.Contains(a.idtabla) _
                And a.estadodetalle = strEstado Select a).ToList
    End Function
    Function GetListaTablaDetalleMotivo(intIdTabla As Integer, strEstado As String, codigo As String) As List(Of tabladetalle)
        Dim listaTipoCompra As New List(Of String)
        listaTipoCompra.Add("17")

        Return (From a In HeliosData.tabladetalle _
                Where a.codigoDetalle = codigo _
                And a.idtabla = intIdTabla _
                And a.estadodetalle = strEstado _
                Select a).ToList
    End Function

    Public Function InsertMarca(ByVal tabladetalleBE As tabladetalle) As Integer
        Try
            Dim consulta = (From n In HeliosData.tabladetalle _
                         Where n.codigoDetalle = tabladetalleBE.codigoDetalle And
                         n.idtabla = tabladetalleBE.idtabla And
                         n.descripcion = tabladetalleBE.descripcion).Count
            If consulta > 0 Then
                Throw New Exception("la marca ya esta en la base de datos, ingrese otro nombre o codigo")
            Else
                Using ts As New TransactionScope
                    HeliosData.tabladetalle.Add(tabladetalleBE)
                    HeliosData.SaveChanges()
                    ts.Complete()
                    Return tabladetalleBE.idtabla
                End Using
            End If
        Catch ex As Exception
            Throw ex
        End Try


    End Function

    Function ObtenerTablaFull() As IList
        Dim consulta = (From a In HeliosData.tabladetalle Where a.idtabla = 6 Select a.descripcion).ToList
        Return consulta
    End Function

    Public Function InsertTablaDetalleExcel(ByVal strDescripcion As String) As Integer
        Dim objRecurso As New tabladetalle
        Dim codigoDetalleGas As Integer
        Dim CodigoUM As String

        Dim consulta = (From a In HeliosData.tabladetalle Where a.descripcion = strDescripcion _
               Select a.codigoDetalle).FirstOrDefault

        If ((consulta) = 0) Then
            codigoDetalleGas = ObtenerTablaMaximo() + 1
            Using ts As New TransactionScope
                objRecurso = New tabladetalle
                With objRecurso
                    .Action = Business.Entity.BaseBE.EntityAction.INSERT
                    .idtabla = 6
                    .codigoDetalle = codigoDetalleGas
                    .descripcion = strDescripcion
                    .estadodetalle = 1
                    .usuarioModificacion = Nothing
                    .fechaModificacion = Date.Now
                End With
                HeliosData.tabladetalle.Add(objRecurso)
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
            CodigoUM = codigoDetalleGas
        Else
            CodigoUM = consulta
        End If

        Return CodigoUM

    End Function

    Function ObtenerTablaMaximo() As Integer
        Dim consulta = (From a In HeliosData.tabladetalle Where a.idtabla = 6 Select a.codigoDetalle).Max
        Return consulta
    End Function

    Function ObtenerMaxTabla(be As tabladetalle) As String
        Dim consulta = (From a In HeliosData.tabladetalle Where a.idtabla = be.idtabla Select a.codigoDetalle).Max
        Return consulta
    End Function

    Function GetListaTablaID(strDescripcion As String) As String
        Return (From a In HeliosData.tabladetalle Where a.descripcion = strDescripcion _
                Select a.codigoDetalle).FirstOrDefault
    End Function

    Function GetListaTablaDetalle(intIdTabla As Integer, strEstado As String)
        Return (From a In HeliosData.tabladetalle Where a.idtabla = intIdTabla _
                And a.estadodetalle = strEstado Select a).ToList
    End Function

    Function GetListaTablaDetalleTodo(intIdTabla As Integer) As List(Of tabladetalle)
        Return (From a In HeliosData.tabladetalle Where a.idtabla = intIdTabla).ToList
    End Function

    Function GetUbicarTablaID(intIdTabla As Integer, strCodigo As String) As tabladetalle
        Return (From a In HeliosData.tabladetalle Where a.idtabla = intIdTabla _
                And a.codigoDetalle = strCodigo).SingleOrDefault
    End Function

    Function GetUbicarTablaNombre(strNombreTabla As String)
        Return (From a In HeliosData.tabla _
                Join det In HeliosData.tabladetalle _
                On a.idtabla Equals det.idtabla _
                Where a.descripcion = strNombreTabla _
                Select det).ToList
    End Function

    Function GetUbicarTablaexistenciaCambioInventario() As List(Of tabladetalle)

        Dim list As New List(Of String)

        list.Add("01")
        list.Add("03")
        list.Add("04")
        list.Add("05")

        Return (From a In HeliosData.tabladetalle
                Where a.idtabla = 5 And list.Contains(a.codigoDetalle)).ToList
    End Function


    Public Function Insert(ByVal tabladetalleBE As tabladetalle) As Integer
        Using ts As New TransactionScope
            HeliosData.tabladetalle.Add(tabladetalleBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return tabladetalleBE.idtabla
        End Using
    End Function

    Public Sub Update(ByVal tabladetalleBE As tabladetalle)
        Using ts As New TransactionScope
            HeliosData.tabladetalle.Add(tabladetalleBE)
            HeliosData.Entry(tabladetalleBE).State = System.Data.Entity.EntityState.Modified
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub CambiarStatusItem(be As tabladetalle)
        Dim obj = HeliosData.tabladetalle.Where(Function(o) o.idtabla = be.idtabla And o.codigoDetalle = be.codigoDetalle).Single
        Using ts As New TransactionScope
            obj.estadodetalle = be.estadodetalle

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal tabladetalleBE As tabladetalle)
        Using ts As New TransactionScope
            Dim consulta = (From n In HeliosData.tabladetalle _
                          Where n.codigoDetalle = tabladetalleBE.codigoDetalle).First
            CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Function GetUbicarTablaexistencia() As List(Of tabladetalle)

        Dim list As New List(Of String)

        list.Add("01")
        list.Add("02")
        list.Add("06")

        Return (From a In HeliosData.tabladetalle _
                 Where a.idtabla = 5 And list.Contains(a.codigoDetalle)).ToList
    End Function

    Function GetListaTablaDetalleXusuario(intIdTabla As Integer, strEstado As String, listaOperacion As List(Of String))
        Return (From a In HeliosData.tabladetalle Where a.idtabla = intIdTabla _
                And a.estadodetalle = strEstado And
                listaOperacion.Contains(a.codigoDetalle) Select a).ToList
    End Function

End Class
