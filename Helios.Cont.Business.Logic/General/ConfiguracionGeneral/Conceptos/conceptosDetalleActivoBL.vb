Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class conceptosDetalleActivoBL
    Inherits BaseBL

    Public Function Insert(ByVal conceptosDetalleActivoBE As conceptosDetalleActivo) As Integer
        Using ts As New TransactionScope
            HeliosData.conceptosDetalleActivo.Add(conceptosDetalleActivoBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return conceptosDetalleActivoBE.secuencia
        End Using
    End Function

    Public Sub Update(ByVal conceptosDetalleActivoBE As conceptosDetalleActivo)
        Using ts As New TransactionScope
            Dim concpDetalleActivo As conceptosDetalleActivo = HeliosData.conceptosDetalleActivo.Where(Function(o) _
                                            o.idInventario = conceptosDetalleActivoBE.idInventario _
                                            And o.secuencia = conceptosDetalleActivoBE.secuencia).First()

            concpDetalleActivo.idConcepto = conceptosDetalleActivoBE.idConcepto
            concpDetalleActivo.idActivo = conceptosDetalleActivoBE.idActivo
            concpDetalleActivo.importeMN = conceptosDetalleActivoBE.importeMN
            concpDetalleActivo.importeME = conceptosDetalleActivoBE.importeME
            concpDetalleActivo.usuarioActualizacion = conceptosDetalleActivoBE.usuarioActualizacion
            concpDetalleActivo.fechaActualizacion = conceptosDetalleActivoBE.fechaActualizacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(concpDetalleActivo).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub Delete(ByVal conceptosDetalleActivoBE As conceptosDetalleActivo)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(conceptosDetalleActivoBE)
    End Sub

    Public Function GetListar_conceptosDetalleActivo() As List(Of conceptosDetalleActivo)
        Return (From a In HeliosData.conceptosDetalleActivo Select a).ToList
    End Function

    Public Function GetUbicar_conceptosDetalleActivoPorID(Secuencia As Integer) As conceptosDetalleActivo
        Return (From a In HeliosData.conceptosDetalleActivo
                Where a.secuencia = Secuencia Select a).First
    End Function
End Class
