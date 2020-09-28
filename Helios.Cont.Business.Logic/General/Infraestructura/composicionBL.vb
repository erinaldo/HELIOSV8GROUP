Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class composicionBL
    Inherits BaseBL

    Public Sub EditarComposisicion(i As composicion)
        Try
            Using ts As New TransactionScope
                Dim obj = (From n In HeliosData.
                            composicion
                           Where n.idProducto = i.idProducto And n.idComposicion = i.idComposicion).FirstOrDefault

                'obj.[idComposicion] = i.descripcion
                'obj.[idServicio] = i.descripcion
                obj.idProducto = i.idProducto
                obj.codigoDetalle = i.codigoDetalle
                obj.[idEmpresa] = i.[idEmpresa]
                obj.[idEstablecimiento] = i.[idEstablecimiento]
                obj.origen = i.origen
                obj.[tipoInventario] = i.[tipoInventario]
                obj.[cantidad] = i.[cantidad]
                obj.[descripcionComposicion] = i.[descripcionComposicion]
                obj.[unidadMedida] = i.[unidadMedida]
                obj.equivalencia = i.equivalencia
                obj.pumn = i.pumn
                obj.[pume] = i.[pume]
                obj.[importeMN] = i.[importeMN]
                obj.[importeME] = i.[importeME]
                obj.[observacion] = i.[observacion]
                obj.[estado] = i.[estado]
                obj.[usuarioActualizacion] = i.[usuarioActualizacion]
                obj.[fechaActualizacion] = i.[fechaActualizacion]
                HeliosData.composicion.Add(obj)
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function SaveComposicion(i As composicion) As Integer
        Dim obj As New composicion()
        Try

            Using ts As New TransactionScope
                obj = New composicion()
                obj.idProducto = i.idProducto
                obj.[idEmpresa] = i.[idEmpresa]
                obj.[idEstablecimiento] = i.[idEstablecimiento]
                obj.[tipoInventario] = i.[tipoInventario]
                obj.[cantidad] = i.[cantidad]
                obj.[descripcionComposicion] = i.[descripcionComposicion]
                obj.[unidadMedida] = i.[unidadMedida]
                obj.pumn = i.pumn
                obj.[pume] = i.[pume]
                obj.[importeMN] = i.[importeMN]
                obj.[importeME] = i.[importeME]
                obj.[observacion] = i.[observacion]
                obj.[estado] = i.[estado]
                obj.[usuarioActualizacion] = i.[usuarioActualizacion]
                obj.[fechaActualizacion] = i.[fechaActualizacion]
                HeliosData.composicion.Add(obj)
                HeliosData.SaveChanges()
                ts.Complete()
                Return obj.idComposicion
            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SaveComposicionFull(listaComposicion As List(Of composicion)) As Integer
        Dim obj As New composicion()
        Try

            Using ts As New TransactionScope

                For Each i In listaComposicion
                    obj = New composicion()
                    obj.idProducto = i.idProducto
                    obj.codigoDetalle = i.codigoDetalle
                    obj.[idEmpresa] = i.[idEmpresa]
                    obj.[idEstablecimiento] = i.[idEstablecimiento]
                    obj.origen = i.origen
                    obj.[tipoInventario] = i.[tipoInventario]
                    obj.[cantidad] = i.[cantidad]
                    obj.[descripcionComposicion] = i.[descripcionComposicion]
                    obj.[unidadMedida] = i.[unidadMedida]
                    obj.equivalencia = i.equivalencia
                    obj.pumn = i.pumn
                    obj.[pume] = i.[pume]
                    obj.[importeMN] = i.[importeMN]
                    obj.[importeME] = i.[importeME]
                    obj.[observacion] = i.[observacion]
                    obj.[estado] = i.[estado]
                    obj.[usuarioActualizacion] = i.[usuarioActualizacion]
                    obj.[fechaActualizacion] = i.[fechaActualizacion]
                    HeliosData.composicion.Add(obj)
                Next
                HeliosData.SaveChanges()
                ts.Complete()
                Return obj.idComposicion
            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function UpdateComposicionFull(composicionBE As composicion, listaComposicion As List(Of composicion)) As Integer
        Dim obj As New composicion()
        Try

            Using ts As New TransactionScope

                Dim consulta = HeliosData.composicion.Where(Function(o) o.idProducto = composicionBE.idProducto).ToList

                For Each obj In consulta
                    CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(obj)

                Next
                HeliosData.SaveChanges()

                For Each i In listaComposicion
                    obj = New composicion()
                    obj.idProducto = i.idProducto
                    obj.codigoDetalle = i.codigoDetalle
                    obj.[idEmpresa] = i.[idEmpresa]
                    obj.[idEstablecimiento] = i.[idEstablecimiento]
                    obj.origen = i.origen
                    obj.[tipoInventario] = i.[tipoInventario]
                    obj.[cantidad] = i.[cantidad]
                    obj.[descripcionComposicion] = i.[descripcionComposicion]
                    obj.[unidadMedida] = i.[unidadMedida]
                    obj.equivalencia = i.equivalencia
                    obj.pumn = i.pumn
                    obj.[pume] = i.[pume]
                    obj.[importeMN] = i.[importeMN]
                    obj.[importeME] = i.[importeME]
                    obj.[observacion] = i.[observacion]
                    obj.[estado] = i.[estado]
                    obj.[usuarioActualizacion] = i.[usuarioActualizacion]
                    obj.[fechaActualizacion] = i.[fechaActualizacion]
                    HeliosData.composicion.Add(obj)
                    HeliosData.SaveChanges()

                Next

                ts.Complete()
                Return obj.idComposicion
            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetUbicarComposicion(composicionBE As composicion) As List(Of composicion)
        Dim lista As New List(Of composicion)
        Dim obj As New composicion

        Dim consulta = (From a In HeliosData.composicion
                        Where a.idEstablecimiento = composicionBE.idEstablecimiento And a.idEmpresa = composicionBE.idEmpresa).ToList

        For Each i In consulta
            obj = New composicion
            obj.idComposicion = i.idComposicion
            obj.idProducto = i.idProducto
            obj.codigoDetalle = i.codigoDetalle
            obj.[idEmpresa] = i.[idEmpresa]
            obj.[idEstablecimiento] = i.[idEstablecimiento]
            obj.origen = i.origen
            obj.[tipoInventario] = i.[tipoInventario]
            obj.[cantidad] = i.[cantidad]
            obj.[descripcionComposicion] = i.[descripcionComposicion]
            obj.[unidadMedida] = i.[unidadMedida]
            obj.equivalencia = i.equivalencia
            obj.pumn = i.pumn
            obj.[pume] = i.[pume]
            obj.[importeMN] = i.[importeMN]
            obj.[importeME] = i.[importeME]
            obj.[observacion] = i.[observacion]
            obj.[estado] = i.[estado]
            obj.[usuarioActualizacion] = i.[usuarioActualizacion]
            obj.[fechaActualizacion] = i.[fechaActualizacion]
            lista.Add(obj)
        Next

        Return lista
    End Function

    Public Function GetUbicarComposicionXId(composicionBE As composicion) As List(Of composicion)
        Dim lista As New List(Of composicion)
        Dim obj As New composicion

        Dim CONSULTA = (From a In HeliosData.composicion
                        Where a.idEstablecimiento = composicionBE.idEstablecimiento And a.idEmpresa = composicionBE.idEmpresa _
                     And a.idProducto = composicionBE.idProducto).ToList

        For Each I In CONSULTA
            obj = New composicion
            obj.idComposicion = I.idComposicion
            obj.idProducto = I.idProducto
            obj.codigoDetalle = I.codigoDetalle
            obj.[idEmpresa] = I.[idEmpresa]
            obj.[idEstablecimiento] = I.[idEstablecimiento]
            obj.origen = I.origen
            obj.[tipoInventario] = I.[tipoInventario]
            obj.[cantidad] = I.[cantidad]
            obj.[descripcionComposicion] = I.[descripcionComposicion]
            obj.[unidadMedida] = I.[unidadMedida]
            obj.equivalencia = I.equivalencia
            obj.pumn = I.pumn
            obj.[pume] = I.[pume]
            obj.[importeMN] = I.[importeMN]
            obj.[importeME] = I.[importeME]
            obj.[observacion] = I.[observacion]
            obj.[estado] = I.[estado]
            obj.[usuarioActualizacion] = I.[usuarioActualizacion]
            obj.[fechaActualizacion] = I.[fechaActualizacion]

            lista.Add(obj)

        Next

        Return lista
    End Function

End Class
