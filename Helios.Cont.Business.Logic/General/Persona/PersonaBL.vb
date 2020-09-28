Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class PersonaBL
    Inherits BaseBL

    Public Function ObtenerPersona(PersonaBE As Persona) As List(Of Persona)
        Return (From s In HeliosData.Persona
                Where s.idEmpresa = PersonaBE.idEmpresa And s.tipoPersona = PersonaBE.tipoPersona).ToList
    End Function

    Public Function Insert(ByVal personsBE As Persona) As Persona
        Try
            Dim persom As Persona = HeliosData.Persona.Where(Function(o) o.idPersona = personsBE.idPersona).FirstOrDefault
            If IsNothing(persom) Then
                Using ts As New TransactionScope
                    HeliosData.Persona.Add(personsBE)
                    HeliosData.SaveChanges()
                    ts.Complete()
                End Using
            Else
                Throw New Exception("El personal ingresado ya esta registrado, intente en otra ocasión!")
            End If
            Return personsBE
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Editar(ByVal personsBE As Persona)
        Using ts As New TransactionScope
            Dim consulta As Persona = HeliosData.Persona.Where(Function(o) o.idPersona = personsBE.idPersona).First
            With consulta
                '.estado = personsBE.estado
            End With
            'HeliosData.ObjectStateManager.GetObjectStateEntry(consulta).State.ToString()
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal personsBE As Persona)
        Using ts As New TransactionScope
            Dim consulta As Persona = HeliosData.Persona.Where(Function(o) o.idPersona = personsBE.idPersona).First
            CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function ObtenerPersonaNumDoc(ByVal strIDEmpresa As String, ByVal strNumDoc As String) As Persona
        Return (From s In HeliosData.Persona _
                Where s.idEmpresa = strIDEmpresa _
                And s.idPersona = strNumDoc).FirstOrDefault

    End Function

    Public Function ObtenerPersonaNumDocPorNivel(ByVal strIDEmpresa As String, ByVal strNumDoc As String, strNivel As String) As Persona
        Return (From s In HeliosData.Persona _
                Where s.idEmpresa = strIDEmpresa _
                And s.nivel = strNivel _
                And s.idPersona = strNumDoc).FirstOrDefault

    End Function

    Public Function ObtenerPersonaNumDocPorNivelxDescripcion(ByVal strIDEmpresa As String, strNivel As String, strbusqueda As String) As List(Of Persona)
        Return (From s In HeliosData.Persona _
                Where s.idEmpresa = strIDEmpresa _
                And s.nivel = strNivel _
                And s.nombreCompleto.Contains(strbusqueda) Take 10).ToList

    End Function


    Public Function ObtenerPersonaPorNombres(ByVal strIDEmpresa As String, ByVal strNombres As String) As List(Of Persona)
        Return (From s In HeliosData.Persona _
                Where s.idEmpresa = strIDEmpresa _
                And s.nombreCompleto.Contains(strNombres)).ToList

    End Function

End Class
