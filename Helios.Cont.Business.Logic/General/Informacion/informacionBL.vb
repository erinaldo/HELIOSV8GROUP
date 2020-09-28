Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class informacionBL
    Inherits BaseBL

    Public Sub EditarInformacion(i As informacionComplementaria)
        Try
            Using ts As New TransactionScope
                Dim obj = (From n In HeliosData.informacionComplementaria
                           Where n.idInformacion = i.idInformacion And n.idEmpresa = i.idEmpresa).FirstOrDefault

                'obj.[idInformacion] = i.[idInformacion]
                'obj.[idEmpresa] = i.[idEmpresa]
                'obj.[idEstablecimiento] = i.[idEstablecimiento]
                'obj.[idDocumento] = i.[idDocumento]
                obj.[idDocumentoDet] = i.[idDocumentoDet]
                obj.[tipo] = i.[tipo]
                obj.[descripcion] = i.[descripcion]
                obj.[fechaInformacion] = i.[fechaInformacion]
                obj.[estado] = i.[estado]
                obj.[usuarioActualizacion] = i.[usuarioActualizacion]
                obj.[fechaActualizacion] = i.[fechaActualizacion]

                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function Saveinformacion(i As informacionComplementaria) As Integer
        Dim obj As New informacionComplementaria()
        Try

            Using ts As New TransactionScope
                obj = New informacionComplementaria()
                obj.[idInformacion] = i.[idInformacion]
                obj.[idEmpresa] = i.[idEmpresa]
                obj.[idEstablecimiento] = i.[idEstablecimiento]
                obj.[idDocumento] = i.[idDocumento]
                obj.[idDocumentoDet] = i.[idDocumentoDet]
                obj.[tipo] = i.[tipo]
                obj.[descripcion] = i.[descripcion]
                obj.[fechaInformacion] = i.[fechaInformacion]
                obj.[estado] = i.[estado]
                obj.[usuarioActualizacion] = i.[usuarioActualizacion]
                obj.[fechaActualizacion] = i.[fechaActualizacion]
                HeliosData.informacionComplementaria.Add(obj)
                HeliosData.SaveChanges()
                ts.Complete()
                Return obj.idInformacion
            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SaveInformacionFull(listaInformacion As List(Of informacionComplementaria)) As Integer
        Dim obj As New informacionComplementaria()
        Try

            Using ts As New TransactionScope

                For Each i In listaInformacion
                    obj = New informacionComplementaria()
                    obj.[idInformacion] = i.[idInformacion]
                    obj.[idEmpresa] = i.[idEmpresa]
                    obj.[idEstablecimiento] = i.[idEstablecimiento]
                    obj.[idDocumento] = i.[idDocumento]
                    obj.[idDocumentoDet] = i.[idDocumentoDet]
                    obj.[tipo] = i.[tipo]
                    obj.[descripcion] = i.[descripcion]
                    obj.[fechaInformacion] = i.[fechaInformacion]
                    obj.[estado] = i.[estado]
                    obj.[usuarioActualizacion] = i.[usuarioActualizacion]
                    obj.[fechaActualizacion] = i.[fechaActualizacion]
                    HeliosData.informacionComplementaria.Add(obj)
                    HeliosData.SaveChanges()
                Next
                ts.Complete()
                Return obj.idInformacion
            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetUbicarInformacion(informacionBE As informacionComplementaria) As List(Of informacionComplementaria)
        Dim lista As New List(Of informacionComplementaria)
        Dim obj As New informacionComplementaria

        Dim consulta = (From a In HeliosData.informacionComplementaria
                        Where a.idInformacion = informacionBE.idInformacion And a.idEmpresa = informacionBE.idEmpresa).ToList

        For Each i In consulta
            obj = New informacionComplementaria
            obj.[idInformacion] = i.[idInformacion]
            obj.[idEmpresa] = i.[idEmpresa]
            obj.[idEstablecimiento] = i.[idEstablecimiento]
            obj.[idDocumento] = i.[idDocumento]
            obj.[idDocumentoDet] = i.[idDocumentoDet]
            obj.[tipo] = i.[tipo]
            obj.[descripcion] = i.[descripcion]
            obj.[fechaInformacion] = i.[fechaInformacion]
            obj.[estado] = i.[estado]
            obj.[usuarioActualizacion] = i.[usuarioActualizacion]
            obj.[fechaActualizacion] = i.[fechaActualizacion]
            lista.Add(obj)
        Next

        Return lista
    End Function




End Class
