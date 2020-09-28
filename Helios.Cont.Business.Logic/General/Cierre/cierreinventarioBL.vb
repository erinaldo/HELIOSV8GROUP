Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Imports EntityFramework.BulkInsert.Extensions
Imports EntityFramework.MappingApi
Public Class cierreinventarioBL
    Inherits BaseBL

    Public Function GetListPeriodos(be As cierreinventario) As List(Of cierreinventario)
        Dim con = HeliosData.cierreinventario.Where(Function(o) o.idEmpresa = be.idEmpresa).Select(Function(o) o.periodo).Distinct.ToList
        GetListPeriodos = New List(Of cierreinventario)
        For Each i In con
            GetListPeriodos.Add(New cierreinventario With
                                {
                                .periodo = i
                                })
        Next
    End Function

    Public Function GetListAnios(be As cierreinventario) As List(Of cierreinventario)
        Dim con = HeliosData.cierreinventario.Where(Function(o) o.idEmpresa = be.idEmpresa).Select(Function(o) o.anio).Distinct.ToList
        GetListAnios = New List(Of cierreinventario)
        For Each i In con
            GetListAnios.Add(New cierreinventario With
                                {
                                .anio = i
                                })
        Next
    End Function

    Public Function GetListMeses(be As cierreinventario) As List(Of cierreinventario)
        Dim con = HeliosData.cierreinventario.Where(Function(o) o.idEmpresa = be.idEmpresa And o.anio = be.anio).Select(Function(o) o.mes).Distinct.ToList
        GetListMeses = New List(Of cierreinventario)
        For Each i In con
            GetListMeses.Add(New cierreinventario With
                                {
                                .mes = i,
                                .NombreMes = MonthName(i)
                                })
        Next
    End Function

    Public Sub EliminarCierreInventario(cierreBE As cierreinventario)
        Dim consulta = (From i In HeliosData.cierreinventario _
                       Where i.idEmpresa = cierreBE.idEmpresa _
                       And i.periodo = cierreBE.periodo).ToList

        For Each n In consulta
            CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(n)
        Next
        HeliosData.SaveChanges()
    End Sub

    Public Function ObtenerPeriodosCerrados(cierreBE As cierreinventario) As List(Of cierreinventario)
        Dim cierre As New cierreinventario
        Dim cierreList As New List(Of cierreinventario)
        Dim consulta = (From n In HeliosData.cierreinventario _
                           Where n.idEmpresa = cierreBE.idEmpresa _
                           Select New With {.periodo = n.periodo}).Distinct.ToList

        For Each i In consulta
            cierre = New cierreinventario
            cierre.periodo = i.periodo
            cierreList.Add(cierre)
        Next

        '   consulta.ToList()
        Return cierreList
    End Function

    Public Function PeriodoInventarioCerrado(strempresa As String, strPeriodo As String) As Boolean
        Try
            Dim consulta = (From n In HeliosData.cierreinventario
                            Where n.idEmpresa = strempresa AndAlso n.periodo = strPeriodo).Count

            If consulta > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function InventarioEstaCerradoV2(strempresa As String, anio As Integer, mes As Integer, intIdEstablecimineto As Integer) As Boolean
        Try
            Dim consulta = (From n In HeliosData.cierreinventario
                            Where n.idEmpresa = strempresa AndAlso n.idCentroCosto = intIdEstablecimineto AndAlso n.anio = anio And n.mes = mes).Count

            If consulta > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RecuperarCierre(intAnio As Integer, intMes As Integer, intIdItem As Integer) As cierreinventario

         Select intMes
            Case 1
                Return (From n In HeliosData.cierreinventario _
                        Where n.anio = intAnio - 1 _
                        And n.mes = 12 _
                        And n.idItem = intIdItem).FirstOrDefault
            Case Else
                Return (From n In HeliosData.cierreinventario _
                                Where n.anio = intAnio _
                                And n.mes = intMes - 1 _
                                And n.idItem = intIdItem).FirstOrDefault
        End Select

    End Function

    Public Function RecuperarCierre2(intAnio As Integer, intMes As Integer, intIdItem As Integer) As cierreinventario

        Select Case intMes
            Case 1
                Return (From n In HeliosData.cierreinventario _
                        Where n.anio = intAnio - 1 _
                        And n.mes = 12 _
                        And n.idItem = intIdItem).FirstOrDefault
            Case Else
                Return (From n In HeliosData.cierreinventario _
                                Where n.anio = intAnio _
                                And n.mes = intMes _
                                And n.idItem = intIdItem).FirstOrDefault
        End Select

    End Function

    Public Function RecuperarCierreListado(intAnio As Integer, intMes As Integer, intIdItem As Integer) As cierreinventario

        Dim consulta = (From n In HeliosData.cierreinventario _
                       Where n.anio = intAnio And n.mes = intMes _
                       And n.idItem = intIdItem).SingleOrDefault


        Return consulta
    End Function

    Public Sub CierreProductoMesesAnteriores(intAnio As Integer, intMes As Integer, intIdItem As Integer, cierreBE As cierreinventario)
        'Dim strMes As String = String.Format("{0:00}", intMes)
        Select Case intMes
            Case 1
                'Return (From n In HeliosData.cierreinventario _
                '        Where n.anio = intAnio - 1 _
                '        And n.mes = 12 _
                '        And n.idItem = intIdItem).FirstOrDefault
            Case Else
                Dim lista = (From n In HeliosData.cierreinventario _
                               Where n.anio = intAnio _
                               AndAlso n.mes >= intMes _
                               AndAlso n.mes <= 12 _
                               AndAlso n.idItem = intIdItem).ToList


                For Each i In lista
                    Dim cierre = (From c In HeliosData.cierreinventario _
                                 Where c.idEmpresa = i.idEmpresa _
                                 And c.idCentroCosto = i.idCentroCosto _
                                 And c.periodo = i.periodo _
                                 And c.idAlmacen = i.idAlmacen _
                                 And c.idItem = i.idItem).FirstOrDefault

                    If Not IsNothing(cierre) Then
                        cierre.cantidad += cierreBE.cantidad
                        cierre.importe += cierreBE.importe
                        cierre.importeUS += cierreBE.importeUS
                    End If

                Next

        End Select
        HeliosData.SaveChanges()
    End Sub

    Public Function CerrarByPeriodo(doc As documento) As Integer
        Dim documentoBL As New documentoBL
        Dim inv As InventarioMovimiento
        Dim lista As List(Of InventarioMovimiento)
        Dim listaCierreInv As List(Of cierreinventario)
        Try
            lista = New List(Of InventarioMovimiento)
            listaCierreInv = New List(Of cierreinventario)
            Using ts As New TransactionScope
                '  HeliosData.Configuration.AutoDetectChangesEnabled = False
                'documentoBL.Insert(doc)
                documentoBL.InsertDocCierre(doc)

                For Each i In doc.cierreinventario
                    If i.cantidad > 0 Then
                        Dim nuevaFecha = New DateTime(i.anio, i.mes, 1, 0, 0, 0)
                        nuevaFecha = nuevaFecha.AddMonths(1)
                        i.idDocumento = doc.idDocumento

                        'InsertCierre(i)
                        listaCierreInv.Add(ReturnObjetoCierre(i))

                        inv = New InventarioMovimiento With
                              {
                                  .idEmpresa = doc.idEmpresa,
                                  .nrolote = i.codigoLote,
                                  .idEstablecimiento = doc.idCentroCosto,
                                  .idAlmacen = i.idAlmacen,
                                  .tipoOperacion = StatusTipoOperacion.CIERRES,
                                  .tipoDocAlmacen = "9901",
                                  .serie = "-",
                                  .numero = "-",
                                  .idDocumento = doc.idDocumento,
                                  .idDocumentoRef = doc.idDocumento,
                                  .descripcion = i.NomItem,
                                  .fechaLaboral = Date.Now,
                                  .fecha = nuevaFecha,
                                  .tipoRegistro = "EA",
                                  .destinoGravadoItem = "1",
                                  .tipoProducto = i.TipoExistencia,
                                  .idItem = i.idItem,
                                  .cantidad = i.cantidad,
                                  .unidad = i.unidad,
                                  .precUnite = 0,
                                  .precUniteUSD = 0,
                                  .monto = i.importe,
                                  .montoUSD = 0,
                                  .montoOther = 0,
                                  .status = "C",
                                  .entragado = "SI",
                                  .usuarioActualizacion = i.usuarioModificacion,
                                  .fechaActualizacion = Date.Now
                                  }
                        '  HeliosData.InventarioMovimiento.Add(inv)
                        lista.Add(inv)
                    End If
                Next
                'HeliosData.BulkInsert(lista.AsEnumerable())
                HeliosData.InventarioMovimiento.AddRange(lista)
                HeliosData.cierreinventario.AddRange(listaCierreInv)
                'HeliosData.BulkInsert(listaCierreInv)
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
            Return doc.idDocumento
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub CerrarInventario(lista As List(Of cierreinventario))
        Try
            Using ts As New TransactionScope
                For Each i In lista
                    InsertCierre(i)
                Next
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub InsertCierre(ByVal cierreinventarioBE As cierreinventario)
        Dim cierre As New cierreinventario
        Using ts As New TransactionScope
            cierre = New cierreinventario
            cierre.idDocumento = cierreinventarioBE.idDocumento
            cierre.codigoLote = cierreinventarioBE.codigoLote
            cierre.idEmpresa = cierreinventarioBE.idEmpresa
            cierre.idCentroCosto = cierreinventarioBE.idCentroCosto
            cierre.periodo = cierreinventarioBE.periodo
            cierre.idAlmacen = cierreinventarioBE.idAlmacen
            cierre.idItem = cierreinventarioBE.idItem
            cierre.anio = cierreinventarioBE.anio
            cierre.mes = cierreinventarioBE.mes
            cierre.dia = cierreinventarioBE.dia
            cierre.cantidad = cierreinventarioBE.cantidad
            cierre.importe = cierreinventarioBE.importe
            cierre.importeUS = cierreinventarioBE.importeUS
            cierre.unidad = cierreinventarioBE.unidad
            cierre.usuarioModificacion = cierreinventarioBE.usuarioModificacion
            cierre.fechaModificacion = cierreinventarioBE.fechaModificacion
            HeliosData.cierreinventario.Add(cierre)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Function ReturnObjetoCierre(ByVal cierreinventarioBE As cierreinventario) As cierreinventario
        Dim cierre As New cierreinventario
        cierre = New cierreinventario
        cierre.idDocumento = cierreinventarioBE.idDocumento
        cierre.codigoLote = cierreinventarioBE.codigoLote
        cierre.idEmpresa = cierreinventarioBE.idEmpresa
        cierre.idCentroCosto = cierreinventarioBE.idCentroCosto
        cierre.periodo = cierreinventarioBE.periodo
        cierre.idAlmacen = cierreinventarioBE.idAlmacen
        cierre.idItem = cierreinventarioBE.idItem
        cierre.anio = cierreinventarioBE.anio
        cierre.mes = cierreinventarioBE.mes
        cierre.dia = cierreinventarioBE.dia
        cierre.cantidad = cierreinventarioBE.cantidad
        cierre.importe = cierreinventarioBE.importe
        cierre.importeUS = cierreinventarioBE.importeUS
        cierre.unidad = cierreinventarioBE.unidad
        cierre.usuarioModificacion = cierreinventarioBE.usuarioModificacion
        cierre.fechaModificacion = cierreinventarioBE.fechaModificacion

        Return cierre
    End Function

    Public Function Insert(ByVal cierreinventarioBE As cierreinventario) As Integer
        Using ts As New TransactionScope
            HeliosData.cierreinventario.Add(cierreinventarioBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return cierreinventarioBE.idEmpresa
        End Using
    End Function

    Public Sub Update(ByVal cierreinventarioBE As cierreinventario)
        Using ts As New TransactionScope
            Dim cierreinvent As cierreinventario = HeliosData.cierreinventario.Where(Function(o) _
                                            o.idEmpresa = cierreinventarioBE.idEmpresa _
                                            And o.idCentroCosto = cierreinventarioBE.idCentroCosto _
                                            And o.periodo = cierreinventarioBE.periodo _
                                            And o.idAlmacen = cierreinventarioBE.idAlmacen _
                                            And o.idItem = cierreinventarioBE.idItem).First()

            cierreinvent.anio = cierreinventarioBE.anio
            cierreinvent.mes = cierreinventarioBE.mes
            cierreinvent.dia = cierreinventarioBE.dia
            cierreinvent.cantidad = cierreinventarioBE.cantidad
            cierreinvent.unidad = cierreinventarioBE.unidad
            cierreinvent.usuarioModificacion = cierreinventarioBE.usuarioModificacion
            cierreinvent.fechaModificacion = cierreinventarioBE.fechaModificacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(cierreinvent).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal cierreinventarioBE As cierreinventario)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(cierreinventarioBE)
    End Sub

    Public Function GetListar_cierreinventario() As List(Of cierreinventario)
        Return (From a In HeliosData.cierreinventario Select a).ToList
    End Function

    Public Function GetUbicar_cierreinventarioPorID(idEmpresa As String) As cierreinventario
        Return (From a In HeliosData.cierreinventario
                Where a.idEmpresa = idEmpresa Select a).First
    End Function

    Public Function GetListado_cierreinventarioPorPeriodo(cierreBE As cierreinventario) As List(Of cierreinventario)
        Dim list As New List(Of cierreinventario)
        Dim cierre As New cierreinventario

        Dim consulta = (From a In HeliosData.cierreinventario
                        Join alm In HeliosData.almacen
                        On alm.idAlmacen Equals a.idAlmacen
                        Join prod In HeliosData.detalleitems
                        On prod.codigodetalle Equals a.idItem
                        Join lote In HeliosData.recursoCostoLote
                                On lote.codigoLote Equals a.codigoLote
                        Where a.idEmpresa = cierreBE.idEmpresa AndAlso a.periodo = cierreBE.periodo).ToList

        For Each i In consulta
            cierre = New cierreinventario
            cierre.codigoLote = i.lote.codigoLote
            cierre.NomAlmacen = i.alm.descripcionAlmacen
            cierre.NomItem = i.prod.descripcionItem
            cierre.unidad = i.prod.unidad1
            cierre.TipoExistencia = i.prod.tipoExistencia
            cierre.cantidad = i.a.cantidad
            cierre.importe = i.a.importe
            cierre.importeUS = i.a.importeUS
            list.Add(cierre)
        Next
        Return list
    End Function

End Class
