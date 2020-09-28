Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Imports System.Data.Entity

Public Class productoxAreaOperativaBL
    Inherits BaseBL

    Public Function GetProductoXAreaOperativa(be As ProductoXAreaOperativa) As List(Of ProductoXAreaOperativa)
        Try
            Dim listaHorarios As New List(Of ProductoXAreaOperativa)

            Dim consulta = (From n In HeliosData.ProductoXAreaOperativa Where n.idEmpresa = be.idEmpresa And n.idCentroCosto = be.idCentroCosto).ToList

            For Each con In consulta
                Dim obj As New ProductoXAreaOperativa With
           {
                .[idRelacion] = con.[idRelacion],
                .[idArea] = con.[idArea],
                .[codigodetalle] = con.[codigodetalle],
                .[idEmpresa] = con.[idEmpresa],
                .[idCentroCosto] = con.[idCentroCosto],
                .[usuarioActualizacion] = con.[usuarioActualizacion],
                .[fechaActualizacion] = con.fechaActualizacion
           }

                listaHorarios.Add(obj)
            Next

            Return listaHorarios

        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Public Function GetProductoXAreaOperativaxID(be As ProductoXAreaOperativa) As List(Of ProductoXAreaOperativa)
        Try
            Dim listaHorarios As New List(Of ProductoXAreaOperativa)
            Dim detalleItemBE As New detalleitems

            Dim consulta = (From n In HeliosData.ProductoXAreaOperativa Join j In HeliosData.detalleitems
                            On n.codigodetalle Equals j.codigodetalle
                            Where n.idArea = be.idArea And
                                                                     n.idEmpresa = be.idEmpresa And
                                                                     n.idCentroCosto = be.idCentroCosto).ToList

            'Dim consulta = (HeliosData.ProductoXAreaOperativa _
            '  .Include(Function(cat) cat.detalleitems).Where(Function(o) o.idEmpresa = be.idEmpresa _
            '                                                    And o.idCentroCosto = be.idCentroCosto _
            '                                                    And o.idArea = be.idArea)).ToList

            For Each con In consulta

                Dim obj As New ProductoXAreaOperativa With
           {
                .[idRelacion] = con.n.[idRelacion],
                .[idArea] = con.n.[idArea],
                .[codigodetalle] = con.n.[codigodetalle],
                .[idEmpresa] = con.n.[idEmpresa],
                .[idCentroCosto] = con.n.[idCentroCosto],
                .[usuarioActualizacion] = con.n.[usuarioActualizacion],
                .[fechaActualizacion] = con.n.fechaActualizacion,
                .descripcionItem = con.j.descripcionItem
           }

                listaHorarios.Add(obj)
            Next

            Return listaHorarios

        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Public Function GetInsertarProductoXAreaOperativa(listaProducto As List(Of ProductoXAreaOperativa)) As List(Of ProductoXAreaOperativa)
        Try
            Using ts As New TransactionScope

                For Each con In listaProducto
                    Dim obj As New ProductoXAreaOperativa With
                              {
                                   .[idArea] = con.[idArea],
                                   .[codigodetalle] = con.[codigodetalle],
                                   .[idEmpresa] = con.[idEmpresa],
                                   .[idCentroCosto] = con.[idCentroCosto],
                                   .[usuarioActualizacion] = con.[usuarioActualizacion],
                                   .[fechaActualizacion] = con.fechaActualizacion
                              }

                    HeliosData.ProductoXAreaOperativa.Add(obj)
                    HeliosData.SaveChanges()
                Next

                ts.Complete()

                Return listaProducto

            End Using
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Public Function GetInsertarProductoXAreaOperativaSingle(con As productoxAreaOperativa) As productoxAreaOperativa
        Try
            Using ts As New TransactionScope


                Dim obj As New productoxAreaOperativa With
                              {
                                   .[idArea] = con.[idArea],
                                   .[codigodetalle] = con.[codigodetalle],
                                   .[idEmpresa] = con.[idEmpresa],
                                   .[idCentroCosto] = con.[idCentroCosto],
                                   .[usuarioActualizacion] = con.[usuarioActualizacion],
                                   .[fechaActualizacion] = con.fechaActualizacion
                              }

                HeliosData.ProductoXAreaOperativa.Add(obj)
                HeliosData.SaveChanges()
                ts.Complete()

                Return obj

            End Using
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Public Function GetUpdateProductoXAreaOperativa(be As ProductoXAreaOperativa) As ProductoXAreaOperativa
        Try
            Using ts As New TransactionScope

                Dim con = (From n In HeliosData.ProductoXAreaOperativa Where n.idArea = be.idArea And
                                                                     n.idEmpresa = be.idEmpresa And
                                                                     n.idCentroCosto = be.idCentroCosto).SingleOrDefault

                If (Not IsNothing(con)) Then
                    'con. = "A"
                    HeliosData.SaveChanges()
                End If


                ts.Complete()

                Return con
            End Using

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Sub GetDeleteProductoXAreaOperativa(ByVal be As ProductoXAreaOperativa)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(be)
    End Sub

End Class
