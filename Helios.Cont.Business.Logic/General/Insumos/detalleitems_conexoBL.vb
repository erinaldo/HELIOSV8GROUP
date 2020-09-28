Imports System.Data.Entity.Migrations
Imports System.Transactions
Imports Helios.Cont.Business.Entity
Public Class detalleitems_conexoBL
    Inherits BaseBL

    Private Sub Insert(be As detalleitems_conexo)
        Using ts As New TransactionScope
            HeliosData.detalleitems_conexo.Add(be)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub

    Private Sub EliminaritemConexo(be As detalleitems_conexo)
        Using ts As New TransactionScope
            Dim consulta = HeliosData.detalleitems_conexo.Where(Function(o) o.conexo_id = be.conexo_id).SingleOrDefault

            CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function SaveConexo(be As detalleitems_conexo) As detalleitems_conexo
        Try
            Using ts As New TransactionScope
                Select Case be.Action
                    Case BaseBE.EntityAction.INSERT

                        'Dim NumEquivalencia = HeliosData.detalleitem_equivalencias.Where(Function(o) o.codigodetalle = be.codigodetalle).Count
                        'If NumEquivalencia >= 1 Then
                        '    Throw New Exception("No puede ingresar más de dos unidades comerciales")
                        'End If

                        Insert(be)

                    Case BaseBE.EntityAction.UPDATE
                        HeliosData.detalleitems_conexo.AddOrUpdate(be)

                    Case BaseBE.EntityAction.DELETE
                        EliminaritemConexo(be)
                End Select
                HeliosData.SaveChanges()
                ts.Complete()
                '  be.detalleitemequivalencia_catalogos = New List(Of detalleitemequivalencia_catalogos)
                be.conexo_id = be.conexo_id
                Return be
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
