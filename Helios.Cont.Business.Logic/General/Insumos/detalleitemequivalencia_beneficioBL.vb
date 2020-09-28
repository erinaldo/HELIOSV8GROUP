Imports System.Data.Entity.Migrations
Imports System.Transactions
Imports Helios.Cont.Business.Entity

Public Class detalleitemequivalencia_beneficioBL
    Inherits BaseBL

    Public Function BeneficioSave(be As detalleitemequivalencia_beneficio) As detalleitemequivalencia_beneficio
        Using ts As New TransactionScope
            Select Case be.Action
                Case BaseBE.EntityAction.INSERT
                    Insert(be)
                    be.codigodetalle = be.codigodetalle
                Case BaseBE.EntityAction.UPDATE
                    HeliosData.detalleitemequivalencia_beneficio.AddOrUpdate(be)
                Case BaseBE.EntityAction.DELETE
                    Dim consulta = HeliosData.detalleitemequivalencia_beneficio.Where(Function(o) o.beneficio_id = be.beneficio_id).SingleOrDefault
                    If Not IsNothing(consulta) Then
                        '   totalesCajaUsuario.DeleteTotalesCajaUsuarioDocCajaDetalle(documentoBE.idDocumento, documentoBE.usuarioActualizacion, documentoBE.IdDocumentoAfectado)
                        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)

                    Else
                        Throw New Exception("El comprobante no se encuentra, verifique su existencia!")
                    End If
            End Select
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
        Return be
    End Function

    Private Sub Insert(be As detalleitemequivalencia_beneficio)
        Using ts As New TransactionScope
            HeliosData.detalleitemequivalencia_beneficio.Add(be)
            HeliosData.SaveChanges()
            ts.Complete()
            be.codigodetalle = be.codigodetalle
        End Using
    End Sub

End Class
