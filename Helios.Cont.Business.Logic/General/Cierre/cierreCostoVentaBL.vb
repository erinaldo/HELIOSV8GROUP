Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class cierreCostoVentaBL
    Inherits BaseBL


    Public Function GetListado_cierreCostoVenta(cierreBE As cierreCostoVenta) As List(Of cierreCostoVenta)
        Dim list As New List(Of cierreCostoVenta)
        Dim cierre As New cierreCostoVenta

        Dim consulta = (From a In HeliosData.cierreCostoVenta _
                Where a.idEmpresa = cierreBE.idEmpresa AndAlso a.periodo = cierreBE.periodo).ToList

        For Each i In consulta
            cierre = New cierreCostoVenta
            cierre.tipoExistencia = i.tipoExistencia
            cierre.tipoOperacion = i.tipoOperacion
            cierre.periodo = i.periodo
            cierre.importe = i.importe
            cierre.importeUS = i.importeUS
            
            list.Add(cierre)
        Next
        Return list
    End Function




    Public Sub GrabarListaCierreCostoVenta(lista As List(Of cierreCostoVenta), objDocumento As documento)
        'Dim caja As Integer
        Dim DocumentoBL As New documentoBL
        Dim AsientoBL As New AsientoBL
        'Dim objDocumento As documento

        'objDocumento = New documento

        'objDocumento.idEmpresa = Gempresas.IdEmpresaRuc
        'objDocumento.idCentroCosto = GEstableciento.IdEstablecimiento
        'objDocumento.idProyecto = 0
        'objDocumento.tipoDoc = "01"
        'objDocumento.fechaProceso = DateTime.Now
        'objDocumento.nroDoc = "2354235"
        'objDocumento.idOrden = "1"
        'objDocumento.tipoOperacion = "99"
        'objDocumento.usuarioActualizacion = "Jiuni"
        'objDocumento.fechaActualizacion = DateTime.Now



        Try
            Using ts As New TransactionScope



                DocumentoBL.Insert(objDocumento)


                'Dim usuario As cajaUsuario = HeliosData.cajaUsuario.Where(Function(o) o.idcajaUsuario = caja).FirstOrDefault
                For Each i In lista
                    Insert(i, objDocumento.idDocumento)
                Next


                If Not IsNothing(objDocumento.asiento) Then
                    If objDocumento.asiento.Count > 0 Then
                        'objDocumento.idDocumento = codNota
                        AsientoBL.SavebyGroupDoc(objDocumento)
                    End If
                End If

                'HeliosData.ObjectStateManager.GetObjectStateEntry(usuario).State.ToString()
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub GrabarListaCierreCostoVentaV2(lista As List(Of cierreCostoVenta), idDocumento As Integer, objDocumento As documento)
        Dim AsientoBL As New AsientoBL
        Try
            Using ts As New TransactionScope
                For Each i In lista
                    Insert(i, idDocumento)
                Next
                If Not IsNothing(objDocumento.asiento) Then
                    objDocumento.idDocumento = idDocumento
                    If objDocumento.asiento.Count > 0 Then
                        AsientoBL.SavebyGroupDoc(objDocumento)
                    End If
                End If
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function Insert(ByVal cierreCostoVentaBE As cierreCostoVenta, iddocRef As Integer) As Integer
        Dim cierre As New cierreCostoVenta
        Using ts As New TransactionScope
            With cierre
                .idEmpresa = cierreCostoVentaBE.idEmpresa
                .idCentroCosto = cierreCostoVentaBE.idCentroCosto
                .periodo = cierreCostoVentaBE.periodo
                .dia = cierreCostoVentaBE.dia
                .mes = cierreCostoVentaBE.mes
                .anio = cierreCostoVentaBE.anio
                .importe = cierreCostoVentaBE.importe
                .tipoExistencia = cierreCostoVentaBE.tipoExistencia
                .tipoOperacion = cierreCostoVentaBE.tipoOperacion
                .importeUS = cierreCostoVentaBE.importeUS
                .usuarioModificacion = cierreCostoVentaBE.usuarioModificacion
                .fechaModificacion = cierreCostoVentaBE.fechaModificacion
                .idDocumento = iddocRef
            End With
            HeliosData.cierreCostoVenta.Add(cierre)
            HeliosData.SaveChanges()
            ts.Complete()
            Return 0
        End Using
    End Function


End Class
