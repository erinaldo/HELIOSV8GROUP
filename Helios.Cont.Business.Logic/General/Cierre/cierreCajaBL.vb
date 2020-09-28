Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class cierreCajaBL
    Inherits BaseBL

    Public Function RecuperarCierreCajaAnterior(intAnio As Integer, intMes As Integer, intIdEF As Integer) As cierreCaja
        Dim consulta = (From n In HeliosData.cierreCaja _
                       Where n.anio = intAnio And n.mes = intMes _
                       And n.idEntidadFinanciera = intIdEF).SingleOrDefault

        Return consulta
    End Function

    Public Function GetListado_cierreCajasPorPeriodo(cierreBE As cierreCaja) As List(Of cierreCaja)
        Dim list As New List(Of cierreCaja)
        Dim cierre As New cierreCaja

        Dim consulta = (From a In HeliosData.cierreCaja
                        Join ent In HeliosData.estadosFinancieros
                        On ent.idestado Equals a.idEntidadFinanciera
                        Where a.idEmpresa = cierreBE.idEmpresa AndAlso a.idEstablecimiento = cierreBE.idEstablecimiento AndAlso a.periodo = cierreBE.periodo).ToList

        For Each i In consulta
            cierre = New cierreCaja
            cierre.NomEntidadFinanciera = i.ent.descripcion
            cierre.TipoEntidad = i.ent.tipo
            cierre.Moneda = i.ent.codigo
            cierre.montoMN = i.a.montoMN
            cierre.montoME = i.a.montoME
            list.Add(cierre)
        Next
        Return list
    End Function

    Public Sub EliminarCierreCaja(cierreBE As cierreCaja)
        Using ts As New TransactionScope
            Dim consulta = (From i In HeliosData.cierreCaja
                            Where
                                i.idEmpresa = cierreBE.idEmpresa _
                                And i.idEstablecimiento = cierreBE.idEstablecimiento _
                                And i.periodo = cierreBE.periodo).ToList

            For Each n In consulta
                CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(n)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function RecuperarCierre(intAnio As Integer, intMes As Integer, intIdEF As Integer) As cierreCaja

        Select Case intMes
            Case 1
                Return (From n In HeliosData.cierreCaja _
                        Where n.anio = intAnio - 1 _
                        And n.mes = 12 _
                        And n.idEntidadFinanciera = intIdEF).FirstOrDefault
            Case Else
                Return (From n In HeliosData.cierreCaja _
                                Where n.anio = intAnio _
                                And n.mes = intMes - 1 _
                                And n.idEntidadFinanciera = intIdEF).FirstOrDefault
        End Select

    End Function

    Public Function CajaTienePeriodoCerrado(strEmpresa As String, strperiodo As String, intIdEstaclecimiento As Integer) As Boolean
        Dim consulta = (From a In HeliosData.cierreCaja Where a.idEmpresa = strEmpresa AndAlso a.idEstablecimiento = intIdEstaclecimiento AndAlso a.periodo = strperiodo
                        Select a).Count

        If consulta > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function CajaTienePeriodoCerradoV2(strEmpresa As String, anio As Integer, mes As Integer, intIdEstaclecimiento As Integer) As Boolean
        Dim consulta = (From a In HeliosData.cierreCaja Where a.idEmpresa = strEmpresa AndAlso a.idEstablecimiento = intIdEstaclecimiento AndAlso a.anio = anio And a.mes = mes).Count

        If consulta > 0 Then
            Return True
        Else
            Return False
        End If
    End Function


    Public Sub GrabarListaCierreCaja(lista As List(Of cierreCaja))
        'Dim caja As Integer
        Try
            Using ts As New TransactionScope
                'Dim usuario As cajaUsuario = HeliosData.cajaUsuario.Where(Function(o) o.idcajaUsuario = caja).FirstOrDefault
                For Each i In lista
                    Insert(i)
                Next
                'HeliosData.ObjectStateManager.GetObjectStateEntry(usuario).State.ToString()
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function Insert(ByVal cierreCajaBE As cierreCaja) As Integer
        Dim cierre As New cierreCaja
        Using ts As New TransactionScope
            With cierre
                .idDocumento = cierreCajaBE.idDocumento
                .idEntidadFinanciera = cierreCajaBE.idEntidadFinanciera
                .idEmpresa = cierreCajaBE.idEmpresa
                .idEstablecimiento = cierreCajaBE.idEstablecimiento
                .periodo = cierreCajaBE.periodo
                .fechaProceso = cierreCajaBE.fechaProceso
                .dia = cierreCajaBE.dia
                .mes = cierreCajaBE.mes
                .anio = cierreCajaBE.anio
                .montoMN = cierreCajaBE.montoMN
                .montoME = cierreCajaBE.montoME
                .usuarioActualizacion = cierreCajaBE.usuarioActualizacion
                .fechaActualizacion = cierreCajaBE.fechaActualizacion
            End With
            HeliosData.cierreCaja.Add(cierre)
            HeliosData.SaveChanges()
            ts.Complete()
            Return cierreCajaBE.secuencia
        End Using
    End Function

    'Public Sub Update(ByVal cierreCajaBE As cierreCaja)
    '    Using ts As New TransactionScope
    '        Dim cierreCaja As cierreCaja = HeliosData.cierreCaja.Where(Function(o) _
    '                                        o.secuencia = cierreCajaBE.secuencia).First()

    '        cierreCaja.idEntidadOrigen = cierreCajaBE.idEntidadOrigen
    '        cierreCaja.idEntidadDestino = cierreCajaBE.idEntidadDestino
    '        cierreCaja.idEntidadDestinoCierre = cierreCajaBE.idEntidadDestinoCierre
    '        cierreCaja.idEmpresa = cierreCajaBE.idEmpresa
    '        cierreCaja.idEstablecimiento = cierreCajaBE.idEstablecimiento
    '        cierreCaja.fechaProceso = cierreCajaBE.fechaProceso
    '        cierreCaja.horaProceso = cierreCajaBE.horaProceso
    '        cierreCaja.fechaFin = cierreCajaBE.fechaFin
    '        cierreCaja.HoraTermino = cierreCajaBE.HoraTermino
    '        cierreCaja.periodo = cierreCajaBE.periodo
    '        cierreCaja.inicioSaldo = cierreCajaBE.inicioSaldo
    '        cierreCaja.montoFin = cierreCajaBE.montoFin
    '        cierreCaja.montoApertura = cierreCajaBE.montoApertura
    '        cierreCaja.inicioSaldoME = cierreCajaBE.inicioSaldoME
    '        cierreCaja.montoFinME = cierreCajaBE.montoFinME
    '        cierreCaja.montoAperturaME = cierreCajaBE.montoAperturaME
    '        cierreCaja.estadoCaja = cierreCajaBE.estadoCaja
    '        cierreCaja.usuarioActualizacion = cierreCajaBE.usuarioActualizacion
    '        cierreCaja.fechaActualizacion = cierreCajaBE.fechaActualizacion

    '        'HeliosData.ObjectStateManager.GetObjectStateEntry(cierreCaja).State.ToString()

    '        HeliosData.SaveChanges()
    '        ts.Complete()
    '    End Using
    'End Sub

    Public Sub Delete(ByVal cierreCajaBE As cierreCaja)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(cierreCajaBE)
    End Sub

    Public Function GetListar_cierreCaja() As List(Of cierreCaja)
        Return (From a In HeliosData.cierreCaja Select a).ToList
    End Function

    Public Function GetUbicar_cierreCajaPorID(Secuencia As Integer) As cierreCaja
        Return (From a In HeliosData.cierreCaja
                Where a.secuencia = Secuencia Select a).First
    End Function
End Class
