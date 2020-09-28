Imports System.Transactions
Imports Helios.Cont.Business.Entity

Public Class membresia_congelamientoBL
    Inherits BaseBL

    Public Function GetMaximoMinimoFechaCongelamiento(be As membresia_congelamiento) As membresia_congelamiento
        GetMaximoMinimoFechaCongelamiento = Nothing
        Dim q = Aggregate i In HeliosData.membresia_congelamiento
                    Where i.idDocumento = be.idDocumento
                        Into
                    FecLimite = Max(i.fechafin),
                    FecInicio = Min(i.fechainicio)

        If Not IsNothing(q) Then
            GetMaximoMinimoFechaCongelamiento = New membresia_congelamiento With
                {
                .fechainicio = q.FecInicio.GetValueOrDefault,
                .fechafin = q.FecLimite.GetValueOrDefault
            }
        End If

    End Function

    Public Function GetSumaCongelamientoByPeriodo(be As membresia_congelamiento) As List(Of membresia_congelamiento)
        Return HeliosData.membresia_congelamiento.Where(Function(o) o.fechainicio.Value.Year = be.fechainicio.Value.Year And
                                                            o.fechainicio.Value.Month = be.fechainicio.Value.Month And
                                                            o.idDocumento = be.idDocumento).ToList
    End Function

    Public Sub GrabarCongelamiento(be As membresia_congelamiento)
        Using ts As New TransactionScope
            HeliosData.membresia_congelamiento.Add(be)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub GrabarGrupoCongelamiento(be As List(Of membresia_congelamiento))
        Using ts As New TransactionScope
            For Each i In be
                HeliosData.membresia_congelamiento.Add(i)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function GetCongelamientoByDocumento(idDocumento As Integer) As List(Of membresia_congelamiento)
        Return HeliosData.membresia_congelamiento.Where(Function(o) o.idDocumento = idDocumento).ToList
    End Function

    Public Sub EliminarCongelamiento(idcongelamiento As Integer)
        Using ts As New TransactionScope
            Dim be = HeliosData.membresia_congelamiento.Where(Function(o) o.idcongelamiento = idcongelamiento).FirstOrDefault
            If be IsNot Nothing Then
                CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(be)
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub
End Class
