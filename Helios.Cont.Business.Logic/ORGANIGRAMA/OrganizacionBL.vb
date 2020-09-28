Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Imports System.Data.Entity
Imports Helios.Seguridad.Business.Logic

Public Class OrganizacionBL
    Inherits BaseBL

    Public Function GetObtenerOrganizacion(strEmpresa As String) As List(Of organizacion)
        Return (From a In HeliosData.organizacion Where a.idEmpresa = strEmpresa Select a).ToList
    End Function

    Public Function GetObtenerParcialOrgani(strBE As organizacion) As List(Of organizacion)
        Dim obj As New organizacion
        Dim objlist As New List(Of organizacion)

        Dim conults = (From o In HeliosData.organizacion
                       Where o.idEmpresa = strBE.idEmpresa
                       Select
                         o.idOrganigrama,
                         o.descripcion).ToList

        For Each i In conults
            obj = New organizacion
            obj.idOrganigrama = i.idOrganigrama
            obj.descripcion = i.descripcion
            objlist.Add(obj)

        Next
        Return objlist
    End Function
    Public Function SaveOrganizacion(ByVal OrganizacionBE As organizacion) As organizacion

        Using ts As New TransactionScope
            Dim saveOr = HeliosData.organizacion.Add(OrganizacionBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return saveOr
        End Using


    End Function

    Public Sub ListOrgani(ByVal OrganizacionBE As List(Of organizacion))
        Try

            For Each i In OrganizacionBE
                SaveOrganizacion(i)
            Next
        Catch ex As Exception

        End Try

    End Sub

    Public Function GetOrganizacion(be As organizacion) As List(Of organizacion)
        Try
            Dim listaHorarios As New List(Of organizacion)

            Dim consulta = (From n In HeliosData.organizacion).ToList


            For Each con In consulta
                Dim obj As New organizacion With
           {
               .[idOrganigrama] = con.[idOrganigrama],
    .[idCentroCosto] = con.[idCentroCosto],
   .[idEmpresa] = con.[idEmpresa],
   .[idRubro] = con.[idRubro],
   .[idSegmento] = con.[idSegmento],
   .[NroOrganizacion] = con.[NroOrganizacion],
    .[TipoOrganizacion] = con.[TipoOrganizacion],
   .[descripcion] = con.[descripcion],
   .[idPadre] = con.[idPadre],
    .[TipoSegmento] = con.[TipoSegmento],
    .[nivel] = con.[nivel],
   .[tipo] = con.[tipo]
           }

                listaHorarios.Add(obj)
            Next

            Return listaHorarios

        Catch ex As Exception
            Throw (ex)
        End Try
    End Function


    Public Function GetInsertOrganizacion(lista As List(Of numeracionBoletas), ListaCentroCostos As List(Of centrocosto)) As List(Of perfilAnexo)
        Try
            Dim ListaPerfilAnexo As New List(Of perfilAnexo)
            Dim listaOrganigrama As New List(Of organizacion)
            Dim idOrganigrama As Integer = 0
            Dim conteoNumeracion As Integer = 1
            'Using ts As New TransactionScope

            Dim organizacionBE As New organizacion

                organizacionBE = New organizacion With {
           .[idCentroCosto] = 0,
            .[idEmpresa] = Nothing,
            .[idRubro] = 0,
            .[idSegmento] = 0,
            .[NroOrganizacion] = Nothing,
            .[TipoOrganizacion] = Nothing,
            .[descripcion] = "GERENTE GENERAL",
            .[idPadre] = Nothing,
            .[TipoSegmento] = 1,
            .[nivel] = 1,
            .[tipo] = Nothing
                }

                listaOrganigrama.Add(organizacionBE)
                HeliosData.organizacion.Add(organizacionBE)
                HeliosData.SaveChanges()
                Dim IDPadre = organizacionBE.idOrganigrama


                For Each listEstable In ListaCentroCostos
                    organizacionBE = New organizacion With {
           .[idCentroCosto] = 0,
            .[idEmpresa] = Nothing,
            .[idRubro] = 0,
            .[idSegmento] = 0,
            .[NroOrganizacion] = Nothing,
            .[TipoOrganizacion] = Nothing,
            .[descripcion] = "TIENDA 0" & conteoNumeracion,
            .[idPadre] = IDPadre,
            .[TipoSegmento] = 1,
            .[nivel] = 1,
            .[tipo] = Nothing
                }
                    listaOrganigrama.Add(organizacionBE)
                    HeliosData.organizacion.Add(organizacionBE)
                    HeliosData.SaveChanges()

                    idOrganigrama = organizacionBE.idOrganigrama

                    conteoNumeracion = conteoNumeracion + 1

                Next

            'End Using

            'INGRESAR TABLA PERFILANEXO

            Dim perfilanexoBl As New perfilAnexoBL
            Dim perfilanexoBE As New perfilAnexo

            Dim rolBL As New RolBL
            Dim consultaRol = rolBL.GetRoles()

            For Each rolBE In consultaRol
                perfilanexoBE = New perfilAnexo With {
                              .idCentroCosto = idOrganigrama,
                              .[descripcion] = rolBE.Descripcion,
                              .[tipo] = rolBE.IDRol,
                              .[estado] = "A",
                              .idRol = Nothing,
                              .[usuarioActualizacion] = "Administrador",
                              .[fechaActualizacion] = Date.Now
                        }

                'Dim perfilREcuperado = perfilanexoBl.SavePerfilAnexo(perfilanexoBE)

                'ListaPerfilAnexo.Add(perfilREcuperado)
            Next
            'ts.Complete()
            Return ListaPerfilAnexo
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Public Function GetObtenerOrganigramaXPerfil(strBE As organizacion) As List(Of organizacion)
        Dim obj As New organizacion
        Dim objlist As New List(Of organizacion)

        'Dim consulta = (From o In HeliosData.organizacion Join p In HeliosData.perfilAnexo On o.idOrganigrama Equals p.idOrganigrama
        '                Where p.tipo = strBE.tipo
        '                Select
        '                 o.idOrganigrama,
        '                 o.descripcion,
        '                    p.idCargo).ToList

        'For Each i In consulta
        '    obj = New organizacion
        '    obj.idOrganigrama = i.idOrganigrama
        '    obj.descripcion = i.descripcion
        '    obj.tipo = i.idCargo
        '    objlist.Add(obj)
        'Next
        Return objlist
    End Function

End Class
