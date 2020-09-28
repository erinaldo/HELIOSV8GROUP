Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Imports System.Data.Entity
Public Class distribucionTipoServicioBL
    Inherits BaseBL

    Public Function GetUbicarDistribucionTipoServicio(composicionBE As distribucionTipoServicio) As List(Of distribucionTipoServicio)
        Dim lista As New List(Of distribucionTipoServicio)
        Dim obj As New distribucionTipoServicio

        Dim consulta = (From a In HeliosData.distribucionTipoServicio Join
                        b In HeliosData.componente On a.idComponente Equals b.idComponente
                        Where a.idTipoServicio = composicionBE.idTipoServicio And
                        b.tipo = "TD").ToList

        For Each i In consulta
            obj = New distribucionTipoServicio
            obj.[idEmpresa] = i.a.idEmpresa
            obj.[idEstablecimiento] = i.a.idEstablecimiento
            obj.[idTipoServicio] = i.a.idTipoServicio
            obj.[idDistribucion] = i.a.idDistribucion
            obj.idComponente = i.a.idComponente
            obj.[estado] = i.a.estado
            obj.usuarioActualizacion = i.b.descripcionItem
            lista.Add(obj)
        Next

        Return lista
    End Function

    Public Function Save_ListaDistribucionTipoServicio(ListaDistribucion As List(Of distribucionTipoServicio)) As Integer
        Dim obj As New distribucionTipoServicio()
        Dim listaDistribucionOBJ As New List(Of distribucionTipoServicio)
        Try

            Using ts As New TransactionScope
                obj = New distribucionTipoServicio()

                For Each i In ListaDistribucion
                    obj = New distribucionTipoServicio
                    'obj.[idDistribucionTipoServicio] = i.[idDistribucionTipoServicio]
                    obj.[idEmpresa] = i.[idEmpresa]
                    obj.[idEstablecimiento] = i.[idEstablecimiento]
                    obj.[idTipoServicio] = i.[idTipoServicio]
                    obj.[idDistribucion] = i.[idDistribucion]
                    obj.idComponente = i.idComponente
                    obj.[estado] = i.[estado]
                    obj.[usuarioActualizacion] = i.[usuarioActualizacion]
                    obj.[fechaActualizacion] = i.[fechaActualizacion]

                    HeliosData.distribucionTipoServicio.Add(obj)
                    HeliosData.SaveChanges()
                Next

                ts.Complete()
                Return 1
            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub DeleteTipoServicioFull(ByVal ListaTipo As List(Of distribucionTipoServicio))

        Using ts As New TransactionScope

            For Each item In ListaTipo
                Dim consulta As distribucionTipoServicio = HeliosData.distribucionTipoServicio.Where(Function(o) o.idDistribucionTipoServicio = item.idDistribucionTipoServicio).First
                CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)
                HeliosData.SaveChanges()
            Next
            ts.Complete()
        End Using
    End Sub

End Class
