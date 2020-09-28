Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class empresaPeriodoBL
    Inherits BaseBL

    Public Function Insert(ByVal empresaPeriodoBE As empresaPeriodo) As Integer
        Try
            Dim consulta = (From n In HeliosData.empresaPeriodo
                            Where n.idEmpresa = empresaPeriodoBE.idEmpresa And n.idCentroCosto = empresaPeriodoBE.idCentroCosto _
                             And n.periodo = empresaPeriodoBE.periodo).Count

            If consulta > 0 Then
                If empresaPeriodoBE.message = "crear" Then
                    Throw New Exception("El periodo ya existe")
                ElseIf empresaPeriodoBE.message = "verificar" Then
                    'Throw New Exception("")
                End If
            Else
                Using ts As New TransactionScope
                    HeliosData.empresaPeriodo.Add(empresaPeriodoBE)
                    HeliosData.SaveChanges()
                    ts.Complete()

                End Using
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return empresaPeriodoBE.periodo
    End Function

    Public Sub Update(ByVal empresaPeriodoBE As empresaPeriodo)
        Using ts As New TransactionScope
            Dim empPeriodo As empresaPeriodo = HeliosData.empresaPeriodo.Where(Function(o) _
                                            o.idEmpresa = empresaPeriodoBE.idEmpresa _
                                            And o.periodo = empresaPeriodoBE.periodo).First()

            empPeriodo.usuarioActualizacion = empresaPeriodoBE.usuarioActualizacion
            empPeriodo.fechaActualizacion = empresaPeriodoBE.fechaActualizacion
             

            'HeliosData.ObjectStateManager.GetObjectStateEntry(empPeriodo).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal empresaPeriodoBE As empresaPeriodo)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(empresaPeriodoBE)
    End Sub

    Public Function GetListar_empresaPeriodo(empresaPeriodoBE As empresaPeriodo) As List(Of empresaPeriodo)
        Return (From a In HeliosData.empresaPeriodo Where a.idEmpresa = empresaPeriodoBE.idEmpresa And a.idCentroCosto = empresaPeriodoBE.idCentroCosto Select a).ToList
    End Function

    Public Function GetUbicar_empresaPeriodoPorID(idempresa As String, periodo As String, idCentroCostos As Integer) As empresaPeriodo
        Return (From a In HeliosData.empresaPeriodo
                Where a.idEmpresa = idempresa And a.idCentroCosto = idCentroCostos And a.periodo = periodo).FirstOrDefault
    End Function
End Class
