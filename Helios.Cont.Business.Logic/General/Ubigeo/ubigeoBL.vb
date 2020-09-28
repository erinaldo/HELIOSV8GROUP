Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Imports System.Data.Entity
Public Class ubigeoBL
    Inherits BaseBL

    Public Function GetAllubigeo() As List(Of ubigeo)
        Return (From a In HeliosData.ubigeo Select a).ToList
    End Function


#Region "UBIGEO FABIO"
    Public Function ListarGetUbigeos() As List(Of regiones)
        Dim objDistritos As distritos
        Dim objProvincias As provincias
        Dim objRegiones As regiones
        Dim objLisRegiones As New List(Of regiones)
        Dim objLisProvincias As New List(Of provincias)
        Dim objLisDistritos As New List(Of distritos)

        Try

            Dim consulUbige = (HeliosData.regiones.Include(Function(det) det.provincias.Select _
                               (Function(o) o.distritos))).ToList


            For Each U In consulUbige

                For Each p In U.provincias.Where(Function(o) o.region_id = U.id).ToList

                    For Each d In p.distritos.Where(Function(i) i.province_id = p.id).ToList
                        objDistritos = New distritos
                        objDistritos.id = d.id
                        objDistritos.name = d.name.ToUpper
                        objDistritos.region_id = U.id
                        objDistritos.province_id = p.id
                        objLisDistritos.Add(objDistritos)
                    Next

                    objProvincias = New provincias
                    objProvincias.id = p.id
                    objProvincias.name = p.name.ToUpper
                    objProvincias.distrito = objLisDistritos
                    objLisProvincias.Add(objProvincias)
                    objLisDistritos = New List(Of distritos)
                Next

                objRegiones = New regiones
                objRegiones.id = U.id
                objRegiones.name = U.name.ToUpper
                objRegiones.provincia = objLisProvincias
                objLisRegiones.Add(objRegiones)
                objLisProvincias = New List(Of provincias)

            Next

            Return objLisRegiones

        Catch ex As Exception
            Throw ex
        End Try

    End Function
#End Region
End Class
