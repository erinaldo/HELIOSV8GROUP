Imports System.Data.Entity.Migrations
Imports System.Transactions
Imports Helios.Cont.Business.Entity

Public Class detalleitem_equivalenciasBL
    Inherits BaseBL

    Public Function GetExisteCodeUnidadComercial(be As detalleitem_equivalencias) As Boolean
        Return HeliosData.detalleitem_equivalencias.Any(Function(s) s.codigo.Equals(be.codigo))
    End Function
    Public Function EquivalenciaSelID(be As detalleitem_equivalencias) As detalleitem_equivalencias
        Return HeliosData.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = be.equivalencia_id).SingleOrDefault
    End Function

    Public Function SaveEquivalencia(be As detalleitem_equivalencias) As detalleitem_equivalencias
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
                        HeliosData.detalleitem_equivalencias.AddOrUpdate(be)

                    Case BaseBE.EntityAction.DELETE
                        EliminarEquivalencia(be)
                End Select
                HeliosData.SaveChanges()
                ts.Complete()
                be.detalleitemequivalencia_catalogos = New List(Of detalleitemequivalencia_catalogos)
                be.equivalencia_id = be.equivalencia_id
                Return be
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub EliminarEquivalencia(be As detalleitem_equivalencias)
        Using ts As New TransactionScope
            Dim consulta = HeliosData.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = be.equivalencia_id).SingleOrDefault

            CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Private Sub Insert(be As detalleitem_equivalencias)
        Using ts As New TransactionScope
            HeliosData.detalleitem_equivalencias.Add(be)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub

    Public Sub ChangeEstatusEquivalencia(obj As detalleitem_equivalencias)
        Using ts As New TransactionScope

            Dim eq = HeliosData.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = obj.equivalencia_id).SingleOrDefault
            If eq IsNot Nothing Then
                eq.estado = obj.estado
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub
End Class
