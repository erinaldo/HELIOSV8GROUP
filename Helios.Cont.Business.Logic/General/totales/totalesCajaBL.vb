Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class totalesCajaBL
    Inherits BaseBL

    Public Function Insert(ByVal totalesCajaBE As totalesCaja) As Integer
        Using ts As New TransactionScope
            HeliosData.totalesCaja.Add(totalesCajaBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return totalesCajaBE.Secuencia
        End Using
    End Function

    Public Sub Update(ByVal totalesCajaBE As totalesCaja)
        Using ts As New TransactionScope
            Dim totCaja As totalesCaja = HeliosData.totalesCaja.Where(Function(o) _
                                            o.Secuencia = totalesCajaBE.Secuencia).First()

            totCaja.idEmpresa = totalesCajaBE.idEmpresa
            totCaja.idEstablecimiento = totalesCajaBE.idEstablecimiento
            totCaja.idEntidad = totalesCajaBE.idEntidad
            totCaja.moneda = totalesCajaBE.moneda
            totCaja.importeMN = totalesCajaBE.importeMN
            totCaja.importeME = totalesCajaBE.importeME
            totCaja.usuarioActualizacion = totalesCajaBE.usuarioActualizacion
            totCaja.fechaActualizacion = totalesCajaBE.fechaActualizacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(totCaja).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal totalesCajaBE As totalesCaja)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(totalesCajaBE)
    End Sub

    Public Function GetListar_totalesCaja() As List(Of totalesCaja)
        Return (From a In HeliosData.totalesCaja Select a).ToList
    End Function

    Public Function GetUbicar_totalesCajaPorID(Secuencia As Integer) As totalesCaja
        Return (From a In HeliosData.totalesCaja
                 Where a.Secuencia = Secuencia Select a).First
    End Function
End Class
