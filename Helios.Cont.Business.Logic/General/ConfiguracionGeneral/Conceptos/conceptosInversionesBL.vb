Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class conceptosInversionesBL
    Inherits BaseBL

    Public Function Insert(ByVal conceptosInversionesBE As conceptosInversiones) As Integer
        Using ts As New TransactionScope
            HeliosData.conceptosInversiones.Add(conceptosInversionesBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return conceptosInversionesBE.secuencia
        End Using
    End Function

    Public Sub Update(ByVal conceptosInversionesBE As conceptosInversiones)
        Using ts As New TransactionScope
            Dim conceptosInvrs As conceptosInversiones = HeliosData.conceptosInversiones.Where(Function(o) _
                                            o.idInventario = conceptosInversionesBE.idInventario _
                                            And o.secuencia = conceptosInversionesBE.secuencia).First()

            conceptosInvrs.idConcepto = conceptosInversionesBE.idConcepto
            conceptosInvrs.idActivo = conceptosInversionesBE.idActivo
            conceptosInvrs.importeMN = conceptosInversionesBE.importeMN
            conceptosInvrs.importeME = conceptosInversionesBE.importeME
            conceptosInvrs.usuarioActualizacion = conceptosInversionesBE.usuarioActualizacion
            conceptosInvrs.fechaActualizacion = conceptosInversionesBE.fechaActualizacion
             
            'HeliosData.ObjectStateManager.GetObjectStateEntry(conceptosInvrs).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub Delete(ByVal conceptosInversionesBE As conceptosInversiones)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(conceptosInversionesBE)
    End Sub

    Public Function GetListar_conceptosInversiones() As List(Of conceptosInversiones)
        Return (From a In HeliosData.conceptosInversiones Select a).ToList
    End Function

    Public Function GetUbicar_conceptosInversionesPorID(Secuencia As Integer) As conceptosInversiones
        Return (From a In HeliosData.conceptosInversiones
                 Where a.secuencia = Secuencia Select a).First
    End Function
End Class
