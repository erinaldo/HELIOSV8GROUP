Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class cierreResultadosBL
    Inherits BaseBL


    Public Function GetObtenerCierrePorPeriodo(idEmpresa As String, strPeriodo As String) As cierreResultados
        Return (From a In HeliosData.cierreResultados
                Where a.idEmpresa = idEmpresa And _
                a.periodo = strPeriodo).FirstOrDefault
    End Function
  
    

    Public Function GetUbicaCierreResultado(idEmpresa As String, anioPeriodo As String, mesPeriodo As String) As List(Of cierreResultados)

        Dim FechaAnt As DateTime
        Dim FechaAct As DateTime
        FechaAnt = Format(Now, anioPeriodo & "-" & mesPeriodo & "-01")
        FechaAnt = FechaAnt.AddMonths(-1)
        FechaAct = Format(Now, anioPeriodo & "-" & mesPeriodo & "-01")

        Dim periodo_Anterior = String.Format("{0:00}", FechaAnt.Month) & FechaAnt.Year
        'periodo_Anterior = periodo_Anterior.Replace("/", "")
        Dim periodo_Actual = String.Format("{0:00}", FechaAct.Month) & FechaAct.Year

        Dim list As New List(Of String)
        list.Add(periodo_Anterior)
        list.Add(periodo_Actual)

        Dim consulta = (From a In HeliosData.cierreResultados
                Where a.idEmpresa = idEmpresa And
                list.Contains(a.periodo)).ToList

        Return consulta

    End Function




    Public Function Insert(ByVal cierreResultadosBE As cierreResultados, idDoc As Integer) As Integer
        Dim cierre As New cierreResultados
        Using ts As New TransactionScope
            With cierre
                .idDocumento = idDoc
                .idEmpresa = cierreResultadosBE.idEmpresa
                .idCentroCosto = cierreResultadosBE.idCentroCosto
                .periodo = cierreResultadosBE.periodo
                .mes = cierreResultadosBE.mes
                .anio = cierreResultadosBE.anio
                .montoImpuesto = cierreResultadosBE.montoImpuesto
                .montoImpuestoUSD = cierreResultadosBE.montoImpuestoUSD
                .utilidadPerdida = cierreResultadosBE.utilidadPerdida
                .utilidadPerdidaUSD = cierreResultadosBE.utilidadPerdida
                .usuarioActualizacion = cierreResultadosBE.usuarioActualizacion
                .fechaActualizacion = cierreResultadosBE.fechaActualizacion
            End With
            HeliosData.cierreResultados.Add(cierre)
            HeliosData.SaveChanges()
            ts.Complete()
            Return cierreResultadosBE.idDocumento
        End Using
    End Function

End Class
