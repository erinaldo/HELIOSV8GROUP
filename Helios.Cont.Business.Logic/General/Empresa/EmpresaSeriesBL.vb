Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class EmpresaSeriesBL
    Inherits BaseBL

    Public Function obtenerSeriePorEEmpresa(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer) As List(Of EmpresaSeries)
        Return (From n In HeliosData.EmpresaSeries _
                                Where n.idEmpresa = strIdEmpresa _
                                And n.idEstablecimiento = intIdEstablecimiento _
                                Select n).ToList

    End Function

    Public Sub Insert(ByVal EmpresaSeriesBE As EmpresaSeries)
        Dim EmpSeries As New EmpresaSeries
        Using ts As New TransactionScope
            EmpSeries.idEmpresa = EmpresaSeriesBE.idEmpresa
            EmpSeries.idEstablecimiento = EmpresaSeriesBE.idEstablecimiento
            EmpSeries.serie = EmpresaSeriesBE.serie
            EmpSeries.comprobante = EmpresaSeriesBE.comprobante
            EmpSeries.fechaEmision = EmpresaSeriesBE.fechaEmision
            EmpSeries.usuarioAcualizacion = EmpresaSeriesBE.usuarioAcualizacion
            EmpSeries.fechaActualizacion = EmpresaSeriesBE.fechaActualizacion

            HeliosData.EmpresaSeries.Add(EmpSeries)
            HeliosData.SaveChanges()
            ts.Complete()
            EmpresaSeriesBE.serie = EmpSeries.serie
        End Using
    End Sub

    Public Sub Update(ByVal EmpresaSeriesBE As EmpresaSeries)
        Using ts As New TransactionScope
            Dim EmpSeries As EmpresaSeries = HeliosData.EmpresaSeries.Where(Function(o) _
                                            o.idEmpresa = EmpresaSeriesBE.idEmpresa _
                                            And o.idEstablecimiento = EmpresaSeriesBE.idEstablecimiento _
                                            And o.serie = EmpresaSeriesBE.serie).First()

            EmpSeries.fechaEmision = EmpresaSeriesBE.fechaEmision
            EmpSeries.usuarioAcualizacion = EmpresaSeriesBE.usuarioAcualizacion
            EmpSeries.fechaActualizacion = EmpresaSeriesBE.fechaActualizacion
             
            'HeliosData.ObjectStateManager.GetObjectStateEntry(EmpSeries).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal EmpresaSeriesBE As EmpresaSeries)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(EmpresaSeriesBE)
    End Sub

    Public Function GetListar_EmpresaSeries() As List(Of EmpresaSeries)
        Return (From a In HeliosData.EmpresaSeries Select a).ToList
    End Function

    Public Function GetUbicarSerieEmpresa(intIDEstablecimiento As Integer, strComprobante As String, strSerie As String) As EmpresaSeries
        Return (From a In HeliosData.EmpresaSeries _
                Where a.idEstablecimiento = intIDEstablecimiento _
                And a.comprobante = strComprobante _
                And a.serie = strSerie).First
    End Function

    Public Function GetUbicar_EmpresaSeriesPorID(serie As String) As EmpresaSeries
        Return (From a In HeliosData.EmpresaSeries
                 Where a.serie = serie Select a).First
    End Function
End Class
