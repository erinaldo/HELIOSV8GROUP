Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class totalesAlmacenBL
    Inherits BaseBL

#Region "DEPURADO"
    Public Function GetInventarioGeneral(be As totalesAlmacen) As List(Of totalesAlmacen)
        Try



            Dim lista As New List(Of totalesAlmacen)
            Select Case be.InvAcumulado
                Case True
                    lista = GetProductosByAlmacenAcumulado(New almacen With {.idEmpresa = be.idEmpresa, .idEstablecimiento = be.idEstablecimiento, .idAlmacen = be.idAlmacen, .TipoConsulta = StatusTipoConsulta.XEmpresa}, be.tipoExistencia)
                Case False
                    lista = GetProductosByAlmacen(New almacen With {.idEmpresa = be.idEmpresa, .idEstablecimiento = be.idEstablecimiento, .idAlmacen = be.idAlmacen, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA}, be.tipoExistencia)
            End Select

            Return lista
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetProductosByAlmacen(almacenBE As almacen, Optional ByVal TipoExistencia As String = Nothing) As List(Of totalesAlmacen)

        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)

        Select Case almacenBE.TipoConsulta
            Case "EMPRESA"
                Select Case TipoExistencia
                    Case "00"

                        Dim obj = (From a In HeliosData.totalesAlmacen
                                   Join prod In HeliosData.detalleitems
                           On a.idItem Equals prod.codigodetalle
                                   Join alm In HeliosData.almacen
                           On a.idAlmacen Equals alm.idAlmacen
                                   Join estable In HeliosData.centrocosto On estable.idCentroCosto Equals alm.idEstablecimiento
                                   Group Join cat In HeliosData.item
                           On cat.idItem Equals prod.idItem
                           Into ov = Group
                                   From x In ov.DefaultIfEmpty()
                                   Group Join marca In HeliosData.item
                           On marca.idItem Equals prod.marcaRef
                           Into ov1 = Group
                                   From x1 In ov1.DefaultIfEmpty()
                                   Group Join lote In HeliosData.recursoCostoLote
                           On lote.codigoLote Equals a.codigoLote
                           Into ov2 = Group
                                   From x2 In ov2.DefaultIfEmpty()
                                   Where a.idAlmacen = almacenBE.idAlmacen And
                                       a.idEmpresa = almacenBE.idEmpresa And
                                       a.status = StatusArticulo.Activo And
                                       prod.estado = "A").ToList


                        For Each i In obj
                            ntotal = New totalesAlmacen
                            If IsNothing(i.x) Then
                                ntotal.Clasificicacion = "-"
                            Else
                                ntotal.Clasificicacion = i.x.descripcion
                            End If

                            If IsNothing(i.x1) Then
                                ntotal.Marca = "-"
                            Else
                                ntotal.Marca = i.x1.descripcion
                            End If

                            ntotal.idMovimiento = i.a.idMovimiento
                            ntotal.idEstablecimiento = i.a.idEstablecimiento
                            ntotal.NombreEstablecimiento = i.estable.nombre
                            ntotal.idAlmacen = i.a.idAlmacen
                            ntotal.NomAlmacen = i.alm.descripcionAlmacen
                            ntotal.idItem = i.a.idItem
                            ntotal.origenRecaudo = i.a.origenRecaudo
                            ntotal.tipoExistencia = i.a.tipoExistencia
                            ntotal.descripcion = i.prod.descripcionItem
                            ntotal.idUnidad = i.a.idUnidad
                            ntotal.unidadMedida = i.a.idUnidad
                            ntotal.cantidad = i.a.cantidad
                            ntotal.importeSoles = i.a.importeSoles
                            ntotal.importeDolares = i.a.importeDolares
                            ntotal.Presentacion = i.prod.presentacion
                            ntotal.cantidadMaxima = i.a.cantidadMaxima
                            ntotal.cantidadMinima = i.a.cantidadMinima
                            'ntotal.fechaLote = i.prod.fechaLote.GetValueOrDefault

                            If IsNothing(i.x2) Then

                            Else
                                ntotal.codigoLote = i.x2.codigoLote
                                ntotal.fechaLote = i.x2.fechaVcto
                                ntotal.NroLote = i.x2.nroLote
                            End If


                            ntotal.status = i.a.status

                            Listatotal.Add(ntotal)
                        Next
                    Case Else


                        Dim obj = (From a In HeliosData.totalesAlmacen
                                   Join prod In HeliosData.detalleitems
                           On a.idItem Equals prod.codigodetalle
                                   Join alm In HeliosData.almacen
                           On a.idAlmacen Equals alm.idAlmacen
                                   Join estable In HeliosData.centrocosto On estable.idCentroCosto Equals alm.idEstablecimiento
                                   Group Join cat In HeliosData.item
                           On cat.idItem Equals prod.idItem
                           Into ov = Group
                                   From x In ov.DefaultIfEmpty()
                                   Group Join marca In HeliosData.item
                           On marca.idItem Equals prod.marcaRef
                           Into ov1 = Group
                                   From x1 In ov1.DefaultIfEmpty()
                                   Group Join lote In HeliosData.recursoCostoLote
                           On lote.codigoLote Equals a.codigoLote
                                       Into ov2 = Group
                                   From x2 In ov2.DefaultIfEmpty()
                                   Where a.idAlmacen = almacenBE.idAlmacen And
                                       a.idEmpresa = almacenBE.idEmpresa And
                                       a.status = StatusArticulo.Activo _
                           And a.tipoExistencia = TipoExistencia And
                                       prod.estado = "A").ToList


                        For Each i In obj
                            ntotal = New totalesAlmacen
                            If IsNothing(i.x) Then
                                ntotal.Clasificicacion = "-"
                            Else
                                ntotal.Clasificicacion = i.x.descripcion
                            End If

                            If IsNothing(i.x1) Then
                                ntotal.Marca = "-"
                            Else
                                ntotal.Marca = i.x1.descripcion
                            End If

                            ntotal.idMovimiento = i.a.idMovimiento
                            ntotal.idEstablecimiento = i.a.idEstablecimiento
                            ntotal.NombreEstablecimiento = i.estable.nombre
                            ntotal.idAlmacen = i.a.idAlmacen
                            ntotal.NomAlmacen = i.alm.descripcionAlmacen
                            ntotal.idItem = i.a.idItem
                            ntotal.origenRecaudo = i.a.origenRecaudo
                            ntotal.tipoExistencia = i.a.tipoExistencia
                            ntotal.descripcion = i.prod.descripcionItem
                            ntotal.idUnidad = i.a.idUnidad
                            ntotal.unidadMedida = i.a.idUnidad
                            ntotal.cantidad = i.a.cantidad
                            ntotal.importeSoles = i.a.importeSoles
                            ntotal.importeDolares = i.a.importeDolares
                            ntotal.Presentacion = i.prod.presentacion
                            ntotal.cantidadMaxima = i.a.cantidadMaxima
                            ntotal.cantidadMinima = i.a.cantidadMinima
                            'ntotal.fechaLote = i.prod.fechaLote.GetValueOrDefault
                            If IsNothing(i.x2) Then

                            Else
                                ntotal.codigoLote = i.x2.codigoLote
                                ntotal.fechaLote = i.x2.fechaVcto
                                ntotal.NroLote = i.x2.nroLote
                            End If
                            ntotal.status = i.a.status
                            Listatotal.Add(ntotal)
                        Next
                End Select
            Case "UNIDAD_ORGANICA"
                Select Case TipoExistencia
                    Case "00"

                        Dim obj = (From a In HeliosData.totalesAlmacen
                                   Join prod In HeliosData.detalleitems
                           On a.idItem Equals prod.codigodetalle
                                   Join alm In HeliosData.almacen
                           On a.idAlmacen Equals alm.idAlmacen
                                   Join estable In HeliosData.centrocosto On estable.idCentroCosto Equals alm.idEstablecimiento
                                   Group Join cat In HeliosData.item
                           On cat.idItem Equals prod.idItem
                           Into ov = Group
                                   From x In ov.DefaultIfEmpty()
                                   Group Join marca In HeliosData.item
                           On marca.idItem Equals prod.marcaRef
                           Into ov1 = Group
                                   From x1 In ov1.DefaultIfEmpty()
                                   Group Join lote In HeliosData.recursoCostoLote
                           On lote.codigoLote Equals a.codigoLote
                           Into ov2 = Group
                                   From x2 In ov2.DefaultIfEmpty()
                                   Where a.idAlmacen = almacenBE.idAlmacen And
                                       a.idEmpresa = almacenBE.idEmpresa And
                                       a.idEstablecimiento = almacenBE.idEstablecimiento And
                                       a.status = StatusArticulo.Activo And
                                       prod.estado = "A").ToList


                        For Each i In obj
                            ntotal = New totalesAlmacen
                            If IsNothing(i.x) Then
                                ntotal.Clasificicacion = "-"
                            Else
                                ntotal.Clasificicacion = i.x.descripcion
                            End If

                            If IsNothing(i.x1) Then
                                ntotal.Marca = "-"
                            Else
                                ntotal.Marca = i.x1.descripcion
                            End If

                            ntotal.idMovimiento = i.a.idMovimiento
                            ntotal.idEstablecimiento = i.a.idEstablecimiento
                            ntotal.NombreEstablecimiento = i.estable.nombre
                            ntotal.idAlmacen = i.a.idAlmacen
                            ntotal.NomAlmacen = i.alm.descripcionAlmacen
                            ntotal.idItem = i.a.idItem
                            ntotal.origenRecaudo = i.a.origenRecaudo
                            ntotal.tipoExistencia = i.a.tipoExistencia
                            ntotal.descripcion = i.prod.descripcionItem
                            ntotal.idUnidad = i.a.idUnidad
                            ntotal.unidadMedida = i.a.idUnidad
                            ntotal.cantidad = i.a.cantidad
                            ntotal.importeSoles = i.a.importeSoles
                            ntotal.importeDolares = i.a.importeDolares
                            ntotal.Presentacion = i.prod.presentacion
                            ntotal.cantidadMaxima = i.a.cantidadMaxima
                            ntotal.cantidadMinima = i.a.cantidadMinima
                            'ntotal.fechaLote = i.prod.fechaLote.GetValueOrDefault

                            If IsNothing(i.x2) Then

                            Else
                                ntotal.codigoLote = i.x2.codigoLote
                                ntotal.fechaLote = i.x2.fechaVcto
                                ntotal.NroLote = i.x2.nroLote
                            End If


                            ntotal.status = i.a.status

                            Listatotal.Add(ntotal)
                        Next
                    Case Else


                        Dim obj = (From a In HeliosData.totalesAlmacen
                                   Join prod In HeliosData.detalleitems
                           On a.idItem Equals prod.codigodetalle
                                   Join alm In HeliosData.almacen
                           On a.idAlmacen Equals alm.idAlmacen
                                   Join estable In HeliosData.centrocosto On estable.idCentroCosto Equals alm.idEstablecimiento
                                   Group Join cat In HeliosData.item
                           On cat.idItem Equals prod.idItem
                           Into ov = Group
                                   From x In ov.DefaultIfEmpty()
                                   Group Join marca In HeliosData.item
                           On marca.idItem Equals prod.marcaRef
                           Into ov1 = Group
                                   From x1 In ov1.DefaultIfEmpty()
                                   Group Join lote In HeliosData.recursoCostoLote
                           On lote.codigoLote Equals a.codigoLote
                                       Into ov2 = Group
                                   From x2 In ov2.DefaultIfEmpty()
                                   Where a.idAlmacen = almacenBE.idAlmacen And
                                       a.idEmpresa = almacenBE.idEmpresa And
                                       a.idEstablecimiento = almacenBE.idEstablecimiento And
                                       a.status = StatusArticulo.Activo _
                           And a.tipoExistencia = TipoExistencia And
                                       prod.estado = "A").ToList


                        For Each i In obj
                            ntotal = New totalesAlmacen
                            If IsNothing(i.x) Then
                                ntotal.Clasificicacion = "-"
                            Else
                                ntotal.Clasificicacion = i.x.descripcion
                            End If

                            If IsNothing(i.x1) Then
                                ntotal.Marca = "-"
                            Else
                                ntotal.Marca = i.x1.descripcion
                            End If

                            ntotal.idMovimiento = i.a.idMovimiento
                            ntotal.idEstablecimiento = i.a.idEstablecimiento
                            ntotal.NombreEstablecimiento = i.estable.nombre
                            ntotal.idAlmacen = i.a.idAlmacen
                            ntotal.NomAlmacen = i.alm.descripcionAlmacen
                            ntotal.idItem = i.a.idItem
                            ntotal.origenRecaudo = i.a.origenRecaudo
                            ntotal.tipoExistencia = i.a.tipoExistencia
                            ntotal.descripcion = i.prod.descripcionItem
                            ntotal.idUnidad = i.a.idUnidad
                            ntotal.unidadMedida = i.a.idUnidad
                            ntotal.cantidad = i.a.cantidad
                            ntotal.importeSoles = i.a.importeSoles
                            ntotal.importeDolares = i.a.importeDolares
                            ntotal.Presentacion = i.prod.presentacion
                            ntotal.cantidadMaxima = i.a.cantidadMaxima
                            ntotal.cantidadMinima = i.a.cantidadMinima
                            'ntotal.fechaLote = i.prod.fechaLote.GetValueOrDefault
                            If IsNothing(i.x2) Then

                            Else
                                ntotal.codigoLote = i.x2.codigoLote
                                ntotal.fechaLote = i.x2.fechaVcto
                                ntotal.NroLote = i.x2.nroLote
                            End If
                            ntotal.status = i.a.status
                            Listatotal.Add(ntotal)
                        Next
                End Select
        End Select

        Return Listatotal

    End Function

    Public Function GetProductosByAlmacenAcumulado(almacenbe As almacen, Optional ByVal TipoExistencia As String = Nothing) As List(Of totalesAlmacen)

        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)

        Select Case almacenbe.TipoConsulta
            Case "EMPRESA"
                Select Case TipoExistencia
                    Case "00"

                        Dim obj = (From a In HeliosData.totalesAlmacen
                                   Join prod In HeliosData.detalleitems
                                       On a.idItem Equals prod.codigodetalle
                                   Join alm In HeliosData.almacen
                                       On a.idAlmacen Equals alm.idAlmacen
                                   Join estable In HeliosData.centrocosto
                                       On estable.idCentroCosto Equals alm.idEstablecimiento
                                   Where
                                       a.idEmpresa = almacenbe.idEmpresa And
                                       a.idAlmacen = almacenbe.idAlmacen And
                                       a.status = StatusArticulo.Activo And
                                       prod.estado = "A"
                                   Group New With {a, prod} By
                                       a.idEstablecimiento,
                                       NomEstable = estable.nombre,
                                       a.idAlmacen,
                                       alm.descripcionAlmacen,
                                       a.idItem,
                                       a.origenRecaudo,
                                       TipoProd = a.tipoExistencia,
                                       prod.descripcionItem,
                                       a.idUnidad,
                                       prod.presentacion,
                                       prod.cantidadMinima,
                                       prod.cantidadMaxima
                                       Into g = Group
                                   Select
                                       idEstablecimiento,
                                       NomEstable,
                                       idAlmacen,
                                       descripcionAlmacen,
                                       idItem,
                                       origenRecaudo,
                                       TipoProd,
                                       descripcionItem,
                                       idUnidad,
                                       presentacion,
                                       cantidadMinima,
                                       cantidadMaxima,
                                       SumaCantStock = CType(g.Sum(Function(p) p.a.cantidad), Decimal?),
                                       SumaCostoMN = CType(g.Sum(Function(p) p.a.importeSoles), Decimal?),
                                       SumaCostoME = CType(g.Sum(Function(p) p.a.importeDolares), Decimal?)).ToList

                        For Each i In obj
                            ntotal = New totalesAlmacen
                            ntotal.idEstablecimiento = i.idEstablecimiento
                            ntotal.NombreEstablecimiento = i.NomEstable
                            ntotal.idAlmacen = i.idAlmacen
                            ntotal.NomAlmacen = i.descripcionAlmacen
                            ntotal.idItem = i.idItem
                            ntotal.origenRecaudo = i.origenRecaudo
                            ntotal.tipoExistencia = i.TipoProd
                            ntotal.descripcion = i.descripcionItem
                            ntotal.idUnidad = i.idUnidad
                            ntotal.unidadMedida = i.idUnidad
                            ntotal.Presentacion = i.presentacion
                            ntotal.cantidad = i.SumaCantStock.GetValueOrDefault
                            ntotal.importeSoles = i.SumaCostoMN.GetValueOrDefault
                            ntotal.importeDolares = i.SumaCostoME.GetValueOrDefault
                            ntotal.cantidadMinima = i.cantidadMinima.GetValueOrDefault
                            ntotal.cantidadMaxima = i.cantidadMaxima.GetValueOrDefault
                            Listatotal.Add(ntotal)
                        Next
                    Case Else


                        Dim obj = (From a In HeliosData.totalesAlmacen
                                   Join prod In HeliosData.detalleitems
                                       On a.idItem Equals prod.codigodetalle
                                   Join alm In HeliosData.almacen
                                       On a.idAlmacen Equals alm.idAlmacen
                                   Join estable In HeliosData.centrocosto
                                       On estable.idCentroCosto Equals alm.idEstablecimiento
                                   Where
                                              a.idEmpresa = almacenbe.idEmpresa And
                                       a.idAlmacen = almacenbe.idAlmacen And
                                       a.status = StatusArticulo.Activo And
                                       a.tipoExistencia = TipoExistencia And
                                       prod.estado = "A"
                                   Group New With {a, prod} By
                                       a.idEstablecimiento,
                                       NomEstable = estable.nombre,
                                       a.idAlmacen,
                                       alm.descripcionAlmacen,
                                       a.idItem,
                                       a.origenRecaudo,
                                       TipoProd = a.tipoExistencia,
                                       prod.descripcionItem,
                                       a.idUnidad,
                                       prod.presentacion,
                                       prod.cantidadMinima,
                                       prod.cantidadMaxima
                                       Into g = Group
                                   Select
                                       idEstablecimiento,
                                       NomEstable,
                                       idAlmacen,
                                       descripcionAlmacen,
                                       idItem,
                                       origenRecaudo,
                                       TipoProd,
                                       descripcionItem,
                                       idUnidad,
                                       presentacion,
                                       cantidadMinima,
                                       cantidadMaxima,
                                       SumaCantStock = CType(g.Sum(Function(p) p.a.cantidad), Decimal?),
                                       SumaCostoMN = CType(g.Sum(Function(p) p.a.importeSoles), Decimal?),
                                       SumaCostoME = CType(g.Sum(Function(p) p.a.importeDolares), Decimal?)).ToList


                        For Each i In obj
                            ntotal = New totalesAlmacen
                            ntotal.idEstablecimiento = i.idEstablecimiento
                            ntotal.NombreEstablecimiento = i.NomEstable
                            ntotal.idAlmacen = i.idAlmacen
                            ntotal.NomAlmacen = i.descripcionAlmacen
                            ntotal.idItem = i.idItem
                            ntotal.origenRecaudo = i.origenRecaudo
                            ntotal.tipoExistencia = i.TipoProd
                            ntotal.descripcion = i.descripcionItem
                            ntotal.idUnidad = i.idUnidad
                            ntotal.unidadMedida = i.idUnidad
                            ntotal.Presentacion = i.presentacion
                            ntotal.cantidad = i.SumaCantStock.GetValueOrDefault
                            ntotal.importeSoles = i.SumaCostoMN.GetValueOrDefault
                            ntotal.importeDolares = i.SumaCostoME.GetValueOrDefault
                            ntotal.cantidadMinima = i.cantidadMinima.GetValueOrDefault
                            ntotal.cantidadMaxima = i.cantidadMaxima.GetValueOrDefault
                            Listatotal.Add(ntotal)
                        Next
                End Select


            Case "UNIDAD_ORGANICA"
                Select Case TipoExistencia
                    Case "00"

                        Dim obj = (From a In HeliosData.totalesAlmacen
                                   Join prod In HeliosData.detalleitems
                                       On a.idItem Equals prod.codigodetalle
                                   Join alm In HeliosData.almacen
                                       On a.idAlmacen Equals alm.idAlmacen
                                   Join estable In HeliosData.centrocosto
                                       On estable.idCentroCosto Equals alm.idEstablecimiento
                                   Where
                                               a.idEmpresa = almacenbe.idEmpresa And
                                       a.idEstablecimiento = almacenbe.idEstablecimiento And
                                       a.idAlmacen = almacenbe.idAlmacen And
                                       a.status = StatusArticulo.Activo And
                                       prod.estado = "A"
                                   Group New With {a, prod} By
                                       a.idEstablecimiento,
                                       NomEstable = estable.nombre,
                                       a.idAlmacen,
                                       alm.descripcionAlmacen,
                                       a.idItem,
                                       a.origenRecaudo,
                                       TipoProd = a.tipoExistencia,
                                       prod.descripcionItem,
                                       a.idUnidad,
                                       prod.presentacion,
                                       prod.cantidadMinima,
                                       prod.cantidadMaxima
                                       Into g = Group
                                   Select
                                       idEstablecimiento,
                                       NomEstable,
                                       idAlmacen,
                                       descripcionAlmacen,
                                       idItem,
                                       origenRecaudo,
                                       TipoProd,
                                       descripcionItem,
                                       idUnidad,
                                       presentacion,
                                       cantidadMinima,
                                       cantidadMaxima,
                                       SumaCantStock = CType(g.Sum(Function(p) p.a.cantidad), Decimal?),
                                       SumaCostoMN = CType(g.Sum(Function(p) p.a.importeSoles), Decimal?),
                                       SumaCostoME = CType(g.Sum(Function(p) p.a.importeDolares), Decimal?)).ToList

                        For Each i In obj
                            ntotal = New totalesAlmacen
                            ntotal.idEstablecimiento = i.idEstablecimiento
                            ntotal.NombreEstablecimiento = i.NomEstable
                            ntotal.idAlmacen = i.idAlmacen
                            ntotal.NomAlmacen = i.descripcionAlmacen
                            ntotal.idItem = i.idItem
                            ntotal.origenRecaudo = i.origenRecaudo
                            ntotal.tipoExistencia = i.TipoProd
                            ntotal.descripcion = i.descripcionItem
                            ntotal.idUnidad = i.idUnidad
                            ntotal.unidadMedida = i.idUnidad
                            ntotal.Presentacion = i.presentacion
                            ntotal.cantidad = i.SumaCantStock.GetValueOrDefault
                            ntotal.importeSoles = i.SumaCostoMN.GetValueOrDefault
                            ntotal.importeDolares = i.SumaCostoME.GetValueOrDefault
                            ntotal.cantidadMinima = i.cantidadMinima.GetValueOrDefault
                            ntotal.cantidadMaxima = i.cantidadMaxima.GetValueOrDefault
                            Listatotal.Add(ntotal)
                        Next
                    Case Else


                        Dim obj = (From a In HeliosData.totalesAlmacen
                                   Join prod In HeliosData.detalleitems
                                       On a.idItem Equals prod.codigodetalle
                                   Join alm In HeliosData.almacen
                                       On a.idAlmacen Equals alm.idAlmacen
                                   Join estable In HeliosData.centrocosto
                                       On estable.idCentroCosto Equals alm.idEstablecimiento
                                   Where
                                      a.idEmpresa = almacenbe.idEmpresa And
                                       a.idEstablecimiento = almacenbe.idEstablecimiento And
                                       a.idAlmacen = almacenbe.idAlmacen And
                                       a.status = StatusArticulo.Activo And
                                       a.tipoExistencia = TipoExistencia And
                                       prod.estado = "A"
                                   Group New With {a, prod} By
                                       a.idEstablecimiento,
                                       NomEstable = estable.nombre,
                                       a.idAlmacen,
                                       alm.descripcionAlmacen,
                                       a.idItem,
                                       a.origenRecaudo,
                                       TipoProd = a.tipoExistencia,
                                       prod.descripcionItem,
                                       a.idUnidad,
                                       prod.presentacion,
                                       prod.cantidadMinima,
                                       prod.cantidadMaxima
                                       Into g = Group
                                   Select
                                       idEstablecimiento,
                                       NomEstable,
                                       idAlmacen,
                                       descripcionAlmacen,
                                       idItem,
                                       origenRecaudo,
                                       TipoProd,
                                       descripcionItem,
                                       idUnidad,
                                       presentacion,
                                       cantidadMinima,
                                       cantidadMaxima,
                                       SumaCantStock = CType(g.Sum(Function(p) p.a.cantidad), Decimal?),
                                       SumaCostoMN = CType(g.Sum(Function(p) p.a.importeSoles), Decimal?),
                                       SumaCostoME = CType(g.Sum(Function(p) p.a.importeDolares), Decimal?)).ToList


                        For Each i In obj
                            ntotal = New totalesAlmacen
                            ntotal.idEstablecimiento = i.idEstablecimiento
                            ntotal.NombreEstablecimiento = i.NomEstable
                            ntotal.idAlmacen = i.idAlmacen
                            ntotal.NomAlmacen = i.descripcionAlmacen
                            ntotal.idItem = i.idItem
                            ntotal.origenRecaudo = i.origenRecaudo
                            ntotal.tipoExistencia = i.TipoProd
                            ntotal.descripcion = i.descripcionItem
                            ntotal.idUnidad = i.idUnidad
                            ntotal.unidadMedida = i.idUnidad
                            ntotal.Presentacion = i.presentacion
                            ntotal.cantidad = i.SumaCantStock.GetValueOrDefault
                            ntotal.importeSoles = i.SumaCostoMN.GetValueOrDefault
                            ntotal.importeDolares = i.SumaCostoME.GetValueOrDefault
                            ntotal.cantidadMinima = i.cantidadMinima.GetValueOrDefault
                            ntotal.cantidadMaxima = i.cantidadMaxima.GetValueOrDefault
                            Listatotal.Add(ntotal)
                        Next
                End Select

        End Select

        Return Listatotal

    End Function


    Public Function GetFilterArticulosStartWith(be As totalesAlmacen) As List(Of totalesAlmacen)
        GetFilterArticulosStartWith = New List(Of totalesAlmacen)
        Select Case be.InvAcumulado
            Case True
                GetFilterArticulosStartWith = GetFilterArticulosStartWith_Acumulado(be)
            Case False
                GetFilterArticulosStartWith = GetFilterArticulosStartWith_SPK(be)
        End Select

    End Function

    Public Function GetFilterArticulosStartWith_Acumulado(be As totalesAlmacen) As List(Of totalesAlmacen)

        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)

        Select Case be.tipoConsulta
            Case "EMPRESA"
                Select Case be.tipoExistencia
                    Case "00"
                        Dim obj = (From a In HeliosData.totalesAlmacen
                                   Join prod In HeliosData.detalleitems
                           On a.idItem Equals prod.codigodetalle
                                   Join alm In HeliosData.almacen
                           On a.idAlmacen Equals alm.idAlmacen
                                   Join estable In HeliosData.centrocosto On estable.idCentroCosto Equals alm.idEstablecimiento
                                   Where a.idAlmacen = be.idAlmacen And
                                       a.idEmpresa = be.idEmpresa And
                                       a.status = StatusArticulo.Activo And
                                       prod.estado = "A" And
                                       a.descripcion.Trim.Contains(be.descripcion)
                                   Group New With {a, prod} By
                                       a.idEstablecimiento,
                                       NomEstable = estable.nombre,
                                       a.idAlmacen,
                                       alm.descripcionAlmacen,
                                       a.idItem,
                                       a.origenRecaudo,
                                       TipoProd = a.tipoExistencia,
                                       prod.descripcionItem,
                                       a.idUnidad,
                                       prod.presentacion
                                       Into g = Group
                                   Select
                                       idEstablecimiento,
                                       NomEstable,
                                       idAlmacen,
                                       descripcionAlmacen,
                                       idItem,
                                       origenRecaudo,
                                       TipoProd,
                                       descripcionItem,
                                       idUnidad,
                                       presentacion,
                                       SumaCantStock = CType(g.Sum(Function(p) p.a.cantidad), Decimal?),
                                       SumaCostoMN = CType(g.Sum(Function(p) p.a.importeSoles), Decimal?),
                                       SumaCostoME = CType(g.Sum(Function(p) p.a.importeDolares), Decimal?)).ToList


                        For Each i In obj
                            ntotal = New totalesAlmacen
                            ntotal.idEstablecimiento = i.idEstablecimiento
                            ntotal.NombreEstablecimiento = i.NomEstable
                            ntotal.idAlmacen = i.idAlmacen
                            ntotal.NomAlmacen = i.descripcionAlmacen
                            ntotal.idItem = i.idItem
                            ntotal.origenRecaudo = i.origenRecaudo
                            ntotal.tipoExistencia = i.TipoProd
                            ntotal.descripcion = i.descripcionItem
                            ntotal.idUnidad = i.idUnidad
                            ntotal.unidadMedida = i.idUnidad
                            ntotal.Presentacion = i.presentacion
                            ntotal.cantidad = i.SumaCantStock.GetValueOrDefault
                            ntotal.importeSoles = i.SumaCostoMN.GetValueOrDefault
                            ntotal.importeDolares = i.SumaCostoME.GetValueOrDefault
                            Listatotal.Add(ntotal)
                        Next
                    Case Else


                        Dim obj = (From a In HeliosData.totalesAlmacen
                                   Join prod In HeliosData.detalleitems
                           On a.idItem Equals prod.codigodetalle
                                   Join alm In HeliosData.almacen
                           On a.idAlmacen Equals alm.idAlmacen
                                   Join estable In HeliosData.centrocosto On estable.idCentroCosto Equals alm.idEstablecimiento
                                   Where
                                      a.idAlmacen = be.idAlmacen And
                                       a.idEmpresa = be.idEmpresa And
                                       a.status = StatusArticulo.Activo _
                                       And a.tipoExistencia = be.tipoExistencia _
                                       And prod.estado = "A" _
                                       And a.descripcion.Trim.StartsWith(be.descripcion)
                                   Group New With {a, prod} By
                                       a.idEstablecimiento,
                                       NomEstable = estable.nombre,
                                       a.idAlmacen,
                                       alm.descripcionAlmacen,
                                       a.idItem,
                                       a.origenRecaudo,
                                       TipoProd = a.tipoExistencia,
                                       prod.descripcionItem,
                                       a.idUnidad,
                                       prod.presentacion
                                       Into g = Group
                                   Select
                                       idEstablecimiento,
                                       NomEstable,
                                       idAlmacen,
                                       descripcionAlmacen,
                                       idItem,
                                       origenRecaudo,
                                       TipoProd,
                                       descripcionItem,
                                       idUnidad,
                                       presentacion,
                                       SumaCantStock = CType(g.Sum(Function(p) p.a.cantidad), Decimal?),
                                       SumaCostoMN = CType(g.Sum(Function(p) p.a.importeSoles), Decimal?),
                                       SumaCostoME = CType(g.Sum(Function(p) p.a.importeDolares), Decimal?)).ToList


                        For Each i In obj
                            ntotal = New totalesAlmacen
                            ntotal.idEstablecimiento = i.idEstablecimiento
                            ntotal.NombreEstablecimiento = i.NomEstable
                            ntotal.idAlmacen = i.idAlmacen
                            ntotal.NomAlmacen = i.descripcionAlmacen
                            ntotal.idItem = i.idItem
                            ntotal.origenRecaudo = i.origenRecaudo
                            ntotal.tipoExistencia = i.TipoProd
                            ntotal.descripcion = i.descripcionItem
                            ntotal.idUnidad = i.idUnidad
                            ntotal.unidadMedida = i.idUnidad
                            ntotal.Presentacion = i.presentacion
                            ntotal.cantidad = i.SumaCantStock.GetValueOrDefault
                            ntotal.importeSoles = i.SumaCostoMN.GetValueOrDefault
                            ntotal.importeDolares = i.SumaCostoME.GetValueOrDefault
                            Listatotal.Add(ntotal)
                        Next
                End Select
            Case "UNIDAD_ORGANICA"
                Select Case be.tipoExistencia
                    Case "00"
                        Dim obj = (From a In HeliosData.totalesAlmacen
                                   Join prod In HeliosData.detalleitems
                           On a.idItem Equals prod.codigodetalle
                                   Join alm In HeliosData.almacen
                           On a.idAlmacen Equals alm.idAlmacen
                                   Join estable In HeliosData.centrocosto On estable.idCentroCosto Equals alm.idEstablecimiento
                                   Where a.idAlmacen = be.idAlmacen And
                                       a.idEmpresa = be.idEmpresa And
                                       a.idEstablecimiento = be.idEstablecimiento And
                                       a.status = StatusArticulo.Activo And
                                       prod.estado = "A" And
                                       a.descripcion.Trim.Contains(be.descripcion)
                                   Group New With {a, prod} By
                                       a.idEstablecimiento,
                                       NomEstable = estable.nombre,
                                       a.idAlmacen,
                                       alm.descripcionAlmacen,
                                       a.idItem,
                                       a.origenRecaudo,
                                       TipoProd = a.tipoExistencia,
                                       prod.descripcionItem,
                                       a.idUnidad,
                                       prod.presentacion
                                       Into g = Group
                                   Select
                                       idEstablecimiento,
                                       NomEstable,
                                       idAlmacen,
                                       descripcionAlmacen,
                                       idItem,
                                       origenRecaudo,
                                       TipoProd,
                                       descripcionItem,
                                       idUnidad,
                                       presentacion,
                                       SumaCantStock = CType(g.Sum(Function(p) p.a.cantidad), Decimal?),
                                       SumaCostoMN = CType(g.Sum(Function(p) p.a.importeSoles), Decimal?),
                                       SumaCostoME = CType(g.Sum(Function(p) p.a.importeDolares), Decimal?)).ToList


                        For Each i In obj
                            ntotal = New totalesAlmacen
                            ntotal.idEstablecimiento = i.idEstablecimiento
                            ntotal.NombreEstablecimiento = i.NomEstable
                            ntotal.idAlmacen = i.idAlmacen
                            ntotal.NomAlmacen = i.descripcionAlmacen
                            ntotal.idItem = i.idItem
                            ntotal.origenRecaudo = i.origenRecaudo
                            ntotal.tipoExistencia = i.TipoProd
                            ntotal.descripcion = i.descripcionItem
                            ntotal.idUnidad = i.idUnidad
                            ntotal.unidadMedida = i.idUnidad
                            ntotal.Presentacion = i.presentacion
                            ntotal.cantidad = i.SumaCantStock.GetValueOrDefault
                            ntotal.importeSoles = i.SumaCostoMN.GetValueOrDefault
                            ntotal.importeDolares = i.SumaCostoME.GetValueOrDefault
                            Listatotal.Add(ntotal)
                        Next
                    Case Else


                        Dim obj = (From a In HeliosData.totalesAlmacen
                                   Join prod In HeliosData.detalleitems
                           On a.idItem Equals prod.codigodetalle
                                   Join alm In HeliosData.almacen
                           On a.idAlmacen Equals alm.idAlmacen
                                   Join estable In HeliosData.centrocosto On estable.idCentroCosto Equals alm.idEstablecimiento
                                   Where
                                      a.idAlmacen = be.idAlmacen And
                                       a.idEmpresa = be.idEmpresa And
                                       a.idEstablecimiento = be.idEstablecimiento And
                                       a.status = StatusArticulo.Activo _
                                       And a.tipoExistencia = be.tipoExistencia _
                                       And prod.estado = "A" _
                                       And a.descripcion.Trim.StartsWith(be.descripcion)
                                   Group New With {a, prod} By
                                       a.idEstablecimiento,
                                       NomEstable = estable.nombre,
                                       a.idAlmacen,
                                       alm.descripcionAlmacen,
                                       a.idItem,
                                       a.origenRecaudo,
                                       TipoProd = a.tipoExistencia,
                                       prod.descripcionItem,
                                       a.idUnidad,
                                       prod.presentacion
                                       Into g = Group
                                   Select
                                       idEstablecimiento,
                                       NomEstable,
                                       idAlmacen,
                                       descripcionAlmacen,
                                       idItem,
                                       origenRecaudo,
                                       TipoProd,
                                       descripcionItem,
                                       idUnidad,
                                       presentacion,
                                       SumaCantStock = CType(g.Sum(Function(p) p.a.cantidad), Decimal?),
                                       SumaCostoMN = CType(g.Sum(Function(p) p.a.importeSoles), Decimal?),
                                       SumaCostoME = CType(g.Sum(Function(p) p.a.importeDolares), Decimal?)).ToList


                        For Each i In obj
                            ntotal = New totalesAlmacen
                            ntotal.idEstablecimiento = i.idEstablecimiento
                            ntotal.NombreEstablecimiento = i.NomEstable
                            ntotal.idAlmacen = i.idAlmacen
                            ntotal.NomAlmacen = i.descripcionAlmacen
                            ntotal.idItem = i.idItem
                            ntotal.origenRecaudo = i.origenRecaudo
                            ntotal.tipoExistencia = i.TipoProd
                            ntotal.descripcion = i.descripcionItem
                            ntotal.idUnidad = i.idUnidad
                            ntotal.unidadMedida = i.idUnidad
                            ntotal.Presentacion = i.presentacion
                            ntotal.cantidad = i.SumaCantStock.GetValueOrDefault
                            ntotal.importeSoles = i.SumaCostoMN.GetValueOrDefault
                            ntotal.importeDolares = i.SumaCostoME.GetValueOrDefault
                            Listatotal.Add(ntotal)
                        Next
                End Select
        End Select

        Return Listatotal

    End Function

    Public Function GetFilterArticulosStartWith_SPK(be As totalesAlmacen) As List(Of totalesAlmacen)

        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)

        Select Case be.tipoConsulta
            Case "EMPRESA"
                Select Case be.tipoExistencia
                    Case "00"
                        Dim obj = (From a In HeliosData.totalesAlmacen
                                   Join prod In HeliosData.detalleitems
                           On a.idItem Equals prod.codigodetalle
                                   Join alm In HeliosData.almacen
                           On a.idAlmacen Equals alm.idAlmacen
                                   Join estable In HeliosData.centrocosto On estable.idCentroCosto Equals alm.idEstablecimiento
                                   Group Join cat In HeliosData.item
                           On cat.idItem Equals prod.idItem
                           Into ov = Group
                                   From x In ov.DefaultIfEmpty()
                                   Group Join marca In HeliosData.item
                           On marca.idItem Equals prod.marcaRef
                           Into ov1 = Group
                                   From x1 In ov1.DefaultIfEmpty()
                                   Group Join lote In HeliosData.recursoCostoLote
                           On lote.codigoLote Equals a.codigoLote
                           Into ov2 = Group
                                   From x2 In ov2.DefaultIfEmpty()
                                   Where a.idAlmacen = be.idAlmacen And
                                       a.idEmpresa = be.idEmpresa And
                                       a.status = StatusArticulo.Activo And
                                       prod.estado = "A" And
                                       a.descripcion.Trim.Contains(be.descripcion)).ToList


                        For Each i In obj
                            ntotal = New totalesAlmacen
                            If IsNothing(i.x) Then
                                ntotal.Clasificicacion = "-"
                            Else
                                ntotal.Clasificicacion = i.x.descripcion
                            End If

                            If IsNothing(i.x1) Then
                                ntotal.Marca = "-"
                            Else
                                ntotal.Marca = i.x1.descripcion
                            End If
                            If IsNothing(i.x2) Then

                            Else
                                ntotal.codigoLote = i.x2.codigoLote
                                ntotal.fechaLote = i.x2.fechaVcto
                                ntotal.NroLote = i.x2.nroLote
                            End If
                            ntotal.idMovimiento = i.a.idMovimiento
                            ntotal.idEstablecimiento = i.a.idEstablecimiento
                            ntotal.NombreEstablecimiento = i.estable.nombre
                            ntotal.idAlmacen = i.a.idAlmacen
                            ntotal.NomAlmacen = i.alm.descripcionAlmacen
                            ntotal.idItem = i.a.idItem
                            ntotal.origenRecaudo = i.a.origenRecaudo
                            ntotal.tipoExistencia = i.a.tipoExistencia
                            ntotal.descripcion = i.prod.descripcionItem
                            ntotal.idUnidad = i.a.idUnidad
                            ntotal.unidadMedida = i.a.idUnidad
                            ntotal.cantidad = i.a.cantidad
                            ntotal.importeSoles = i.a.importeSoles
                            ntotal.importeDolares = i.a.importeDolares
                            ntotal.Presentacion = i.prod.presentacion
                            ntotal.cantidadMaxima = i.a.cantidadMaxima
                            ntotal.cantidadMinima = i.a.cantidadMinima
                            'ntotal.fechaLote = i.prod.fechaLote.GetValueOrDefault
                            ntotal.status = i.a.status
                            Listatotal.Add(ntotal)
                        Next
                    Case Else


                        Dim obj = (From a In HeliosData.totalesAlmacen
                                   Join prod In HeliosData.detalleitems
                           On a.idItem Equals prod.codigodetalle
                                   Join alm In HeliosData.almacen
                           On a.idAlmacen Equals alm.idAlmacen
                                   Join estable In HeliosData.centrocosto On estable.idCentroCosto Equals alm.idEstablecimiento
                                   Group Join cat In HeliosData.item
                           On cat.idItem Equals prod.idItem
                           Into ov = Group
                                   From x In ov.DefaultIfEmpty()
                                   Group Join marca In HeliosData.item
                           On marca.idItem Equals prod.marcaRef
                           Into ov1 = Group
                                   From x1 In ov1.DefaultIfEmpty()
                                   Group Join lote In HeliosData.recursoCostoLote
                           On lote.codigoLote Equals a.codigoLote
                           Into ov2 = Group
                                   From x2 In ov2.DefaultIfEmpty()
                                   Where a.idAlmacen = be.idAlmacen And
                                       a.idEmpresa = be.idEmpresa And
                                       a.status = StatusArticulo.Activo _
                                       And a.tipoExistencia = be.tipoExistencia _
                                       And prod.estado = "A" _
                                       And a.descripcion.Trim.StartsWith(be.descripcion)).ToList


                        For Each i In obj
                            ntotal = New totalesAlmacen
                            If IsNothing(i.x) Then
                                ntotal.Clasificicacion = "-"
                            Else
                                ntotal.Clasificicacion = i.x.descripcion
                            End If

                            If IsNothing(i.x1) Then
                                ntotal.Marca = "-"
                            Else
                                ntotal.Marca = i.x1.descripcion
                            End If

                            If IsNothing(i.x2) Then

                            Else
                                ntotal.codigoLote = i.x2.codigoLote
                                ntotal.fechaLote = i.x2.fechaVcto
                                ntotal.NroLote = i.x2.nroLote
                            End If

                            ntotal.idMovimiento = i.a.idMovimiento
                            ntotal.idEstablecimiento = i.a.idEstablecimiento
                            ntotal.NombreEstablecimiento = i.estable.nombre
                            ntotal.idAlmacen = i.a.idAlmacen
                            ntotal.NomAlmacen = i.alm.descripcionAlmacen
                            ntotal.idItem = i.a.idItem
                            ntotal.origenRecaudo = i.a.origenRecaudo
                            ntotal.tipoExistencia = i.a.tipoExistencia
                            ntotal.descripcion = i.prod.descripcionItem
                            ntotal.idUnidad = i.a.idUnidad
                            ntotal.unidadMedida = i.a.idUnidad
                            ntotal.cantidad = i.a.cantidad
                            ntotal.importeSoles = i.a.importeSoles
                            ntotal.importeDolares = i.a.importeDolares
                            ntotal.Presentacion = i.prod.presentacion
                            ntotal.cantidadMaxima = i.a.cantidadMaxima
                            ntotal.cantidadMinima = i.a.cantidadMinima
                            'ntotal.fechaLote = i.prod.fechaLote.GetValueOrDefault
                            ntotal.status = i.a.status
                            Listatotal.Add(ntotal)
                        Next
                End Select
            Case "UNIDAD_ORGANICA"
                Select Case be.tipoExistencia
                    Case "00"
                        Dim obj = (From a In HeliosData.totalesAlmacen
                                   Join prod In HeliosData.detalleitems
                           On a.idItem Equals prod.codigodetalle
                                   Join alm In HeliosData.almacen
                           On a.idAlmacen Equals alm.idAlmacen
                                   Join estable In HeliosData.centrocosto On estable.idCentroCosto Equals alm.idEstablecimiento
                                   Group Join cat In HeliosData.item
                           On cat.idItem Equals prod.idItem
                           Into ov = Group
                                   From x In ov.DefaultIfEmpty()
                                   Group Join marca In HeliosData.item
                           On marca.idItem Equals prod.marcaRef
                           Into ov1 = Group
                                   From x1 In ov1.DefaultIfEmpty()
                                   Group Join lote In HeliosData.recursoCostoLote
                           On lote.codigoLote Equals a.codigoLote
                           Into ov2 = Group
                                   From x2 In ov2.DefaultIfEmpty()
                                   Where a.idAlmacen = be.idAlmacen And
                                       a.idEmpresa = be.idEmpresa And
                                       a.idEstablecimiento = be.idEstablecimiento And
                                       a.status = StatusArticulo.Activo And
                                       prod.estado = "A" And
                                       a.descripcion.Trim.Contains(be.descripcion)).ToList


                        For Each i In obj
                            ntotal = New totalesAlmacen
                            If IsNothing(i.x) Then
                                ntotal.Clasificicacion = "-"
                            Else
                                ntotal.Clasificicacion = i.x.descripcion
                            End If

                            If IsNothing(i.x1) Then
                                ntotal.Marca = "-"
                            Else
                                ntotal.Marca = i.x1.descripcion
                            End If
                            If IsNothing(i.x2) Then

                            Else
                                ntotal.codigoLote = i.x2.codigoLote
                                ntotal.fechaLote = i.x2.fechaVcto
                                ntotal.NroLote = i.x2.nroLote
                            End If
                            ntotal.idMovimiento = i.a.idMovimiento
                            ntotal.idEstablecimiento = i.a.idEstablecimiento
                            ntotal.NombreEstablecimiento = i.estable.nombre
                            ntotal.idAlmacen = i.a.idAlmacen
                            ntotal.NomAlmacen = i.alm.descripcionAlmacen
                            ntotal.idItem = i.a.idItem
                            ntotal.origenRecaudo = i.a.origenRecaudo
                            ntotal.tipoExistencia = i.a.tipoExistencia
                            ntotal.descripcion = i.prod.descripcionItem
                            ntotal.idUnidad = i.a.idUnidad
                            ntotal.unidadMedida = i.a.idUnidad
                            ntotal.cantidad = i.a.cantidad
                            ntotal.importeSoles = i.a.importeSoles
                            ntotal.importeDolares = i.a.importeDolares
                            ntotal.Presentacion = i.prod.presentacion
                            ntotal.cantidadMaxima = i.a.cantidadMaxima
                            ntotal.cantidadMinima = i.a.cantidadMinima
                            'ntotal.fechaLote = i.prod.fechaLote.GetValueOrDefault
                            ntotal.status = i.a.status
                            Listatotal.Add(ntotal)
                        Next
                    Case Else


                        Dim obj = (From a In HeliosData.totalesAlmacen
                                   Join prod In HeliosData.detalleitems
                           On a.idItem Equals prod.codigodetalle
                                   Join alm In HeliosData.almacen
                           On a.idAlmacen Equals alm.idAlmacen
                                   Join estable In HeliosData.centrocosto On estable.idCentroCosto Equals alm.idEstablecimiento
                                   Group Join cat In HeliosData.item
                           On cat.idItem Equals prod.idItem
                           Into ov = Group
                                   From x In ov.DefaultIfEmpty()
                                   Group Join marca In HeliosData.item
                           On marca.idItem Equals prod.marcaRef
                           Into ov1 = Group
                                   From x1 In ov1.DefaultIfEmpty()
                                   Group Join lote In HeliosData.recursoCostoLote
                           On lote.codigoLote Equals a.codigoLote
                           Into ov2 = Group
                                   From x2 In ov2.DefaultIfEmpty()
                                   Where a.idAlmacen = be.idAlmacen And
                                       a.idEmpresa = be.idEmpresa And
                                       a.idEstablecimiento = be.idEstablecimiento And
                                       a.status = StatusArticulo.Activo _
                                       And a.tipoExistencia = be.tipoExistencia _
                                       And prod.estado = "A" _
                                       And a.descripcion.Trim.StartsWith(be.descripcion)).ToList


                        For Each i In obj
                            ntotal = New totalesAlmacen
                            If IsNothing(i.x) Then
                                ntotal.Clasificicacion = "-"
                            Else
                                ntotal.Clasificicacion = i.x.descripcion
                            End If

                            If IsNothing(i.x1) Then
                                ntotal.Marca = "-"
                            Else
                                ntotal.Marca = i.x1.descripcion
                            End If

                            If IsNothing(i.x2) Then

                            Else
                                ntotal.codigoLote = i.x2.codigoLote
                                ntotal.fechaLote = i.x2.fechaVcto
                                ntotal.NroLote = i.x2.nroLote
                            End If

                            ntotal.idMovimiento = i.a.idMovimiento
                            ntotal.idEstablecimiento = i.a.idEstablecimiento
                            ntotal.NombreEstablecimiento = i.estable.nombre
                            ntotal.idAlmacen = i.a.idAlmacen
                            ntotal.NomAlmacen = i.alm.descripcionAlmacen
                            ntotal.idItem = i.a.idItem
                            ntotal.origenRecaudo = i.a.origenRecaudo
                            ntotal.tipoExistencia = i.a.tipoExistencia
                            ntotal.descripcion = i.prod.descripcionItem
                            ntotal.idUnidad = i.a.idUnidad
                            ntotal.unidadMedida = i.a.idUnidad
                            ntotal.cantidad = i.a.cantidad
                            ntotal.importeSoles = i.a.importeSoles
                            ntotal.importeDolares = i.a.importeDolares
                            ntotal.Presentacion = i.prod.presentacion
                            ntotal.cantidadMaxima = i.a.cantidadMaxima
                            ntotal.cantidadMinima = i.a.cantidadMinima
                            'ntotal.fechaLote = i.prod.fechaLote.GetValueOrDefault
                            ntotal.status = i.a.status
                            Listatotal.Add(ntotal)
                        Next
                End Select
        End Select






        Return Listatotal

    End Function




#End Region

    Public Function GetLotesExistentesDetalle(intIdAlmacen As Integer) As List(Of totalesAlmacen)



        Try



            Dim ntotal As New totalesAlmacen
            Dim Listatotal As New List(Of totalesAlmacen)
            Dim LoteDetalleBL As New LoteDetalleBL



            'Dim obj = (From a In HeliosData.totalesAlmacen
            '           Join prod In HeliosData.detalleitems
            '           On a.idItem Equals prod.codigodetalle
            '           Join alm In HeliosData.almacen
            '           On a.idAlmacen Equals alm.idAlmacen
            '           Join estable In HeliosData.centrocosto On estable.idCentroCosto Equals alm.idEstablecimiento
            '           Group Join cat In HeliosData.item
            '           On cat.idItem Equals prod.idItem
            '           Into ov = Group
            '           From x In ov.DefaultIfEmpty()
            '           Group Join marca In HeliosData.item
            '           On marca.idItem Equals prod.marcaRef
            '           Into ov1 = Group
            '           From x1 In ov1.DefaultIfEmpty()
            '           Group Join lote In HeliosData.recursoCostoLote
            '           On lote.codigoLote Equals a.codigoLote
            '                       Into ov2 = Group
            '           From x2 In ov2.DefaultIfEmpty()
            '           Where a.idAlmacen = intIdAlmacen And
            '                       a.status = StatusArticulo.Activo _
            '           And a.tipoExistencia = "01" And
            '             prod.estado = "A" And prod.tipoItem = "DET").ToList

            Dim obj = (From a In HeliosData.totalesAlmacen
                       Join prod In HeliosData.detalleitems
                       On a.idItem Equals prod.codigodetalle
                       Join alm In HeliosData.almacen
                       On a.idAlmacen Equals alm.idAlmacen
                       Join estable In HeliosData.centrocosto On estable.idCentroCosto Equals alm.idEstablecimiento
                       Group Join cat In HeliosData.item
                       On cat.idItem Equals prod.idItem
                       Into ov = Group
                       From x In ov.DefaultIfEmpty()
                       Group Join lote In HeliosData.recursoCostoLote
                       On lote.codigoLote Equals a.codigoLote
                                   Into ov2 = Group
                       From x2 In ov2.DefaultIfEmpty()
                       Group Join doc In HeliosData.documentocompra
                   On doc.idDocumento Equals x2.idDocumento
                               Into ov5 = Group
                       From xd In ov5.DefaultIfEmpty()
                       Group Join ent In HeliosData.entidad
                   On ent.idEntidad Equals xd.idProveedor
                               Into ov6 = Group
                       From xent In ov6.DefaultIfEmpty()
                       Where a.idAlmacen = intIdAlmacen And
                                   a.status = StatusArticulo.Activo _
                       And a.tipoExistencia = "01" And
                         prod.estado = "A" And prod.tipoItem = "DET").ToList


            For Each i In obj
                ntotal = New totalesAlmacen
                If IsNothing(i.x) Then
                    ntotal.Clasificicacion = "-"
                Else
                    ntotal.Clasificicacion = i.x.descripcion
                End If

                ' If IsNothing(i.x1) Then
                'ntotal.Marca = "-"
                'Else
                ntotal.Marca = i.prod.marcaRef
                'End If

                ntotal.idMovimiento = i.a.idMovimiento
                ntotal.idEstablecimiento = i.a.idEstablecimiento
                ntotal.NombreEstablecimiento = i.estable.nombre
                ntotal.idAlmacen = i.a.idAlmacen
                ntotal.NomAlmacen = i.alm.descripcionAlmacen
                ntotal.idItem = i.a.idItem
                ntotal.origenRecaudo = i.a.origenRecaudo
                ntotal.tipoExistencia = i.a.tipoExistencia
                ntotal.descripcion = i.prod.descripcionItem
                ntotal.idUnidad = i.a.idUnidad
                ntotal.unidadMedida = i.a.idUnidad
                ntotal.cantidad = i.a.cantidad
                ntotal.importeSoles = i.a.importeSoles
                ntotal.importeDolares = i.a.importeDolares
                ntotal.Presentacion = i.prod.presentacion
                ntotal.idSubClasificacion = i.prod.idItem.GetValueOrDefault
                ntotal.cantidadMaxima = i.a.cantidadMaxima
                ntotal.cantidadMinima = i.a.cantidadMinima
                ntotal.NombreProveedor = i.xent.nombreCompleto
                'ntotal.fechaLote = i.prod.fechaLote.GetValueOrDefault
                If IsNothing(i.x2) Then

                Else
                    ntotal.codigoLote = i.x2.codigoLote
                    ntotal.fechaLote = i.x2.fechaVcto
                    ntotal.NroLote = i.xd.serie & "-" & i.xd.numeroDoc

                    ntotal.CantDetalle = LoteDetalleBL.CantidadDetalle(ntotal.codigoLote)

                End If
                ntotal.status = i.a.status
                ntotal.idCaracteristica = i.prod.idCaracteristica
                ntotal.modelo = i.prod.modelo
                Listatotal.Add(ntotal)
            Next




            Return Listatotal
        Catch ex As Exception

        End Try
    End Function
    Public Function GetDetalleLoteXproductoProf(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen)
        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)

        Dim obj = (From a In HeliosData.totalesAlmacen
                   Join art In HeliosData.detalleitems
                           On art.codigodetalle Equals a.idItem
                   Join lote In HeliosData.recursoCostoLote On lote.codigoLote Equals a.codigoLote
                   Join alm In HeliosData.almacen On alm.idAlmacen Equals a.idAlmacen
                   Where
                       a.idItem = objTotalBE.idItem And
                       a.idAlmacen = objTotalBE.idAlmacen And
                      a.status = StatusArticulo.Activo
                   Order By
                       lote.fechaVcto Ascending
                   Select
                       lote,
                       a.idEmpresa,
                       a.idEstablecimiento,
                       a.idAlmacen,
                       alm.descripcionAlmacen,
                       a.idItem,
                       art.origenProducto,
                       art.tipoExistencia,
                       art.descripcionItem,
                       art.unidad1,
                       a.cantidad,
                       a.importeSoles,
                       a.importeDolares
                       ).ToList

        For Each i In obj
            ntotal = New totalesAlmacen
            ntotal.CustomLote = i.lote
            ntotal.idEmpresa = i.idEmpresa
            ntotal.idEstablecimiento = i.idEstablecimiento
            ntotal.idAlmacen = i.idAlmacen
            ntotal.NomAlmacen = i.descripcionAlmacen
            ntotal.idItem = i.idItem
            ntotal.origenRecaudo = i.origenProducto
            ntotal.tipoExistencia = i.tipoExistencia
            ntotal.descripcion = i.descripcionItem
            ntotal.idUnidad = i.unidad1
            ntotal.unidadMedida = i.unidad1 ' i.tbl.descripcion
            ntotal.cantidad = i.cantidad
            ntotal.importeSoles = i.importeSoles
            ntotal.importeDolares = i.importeDolares
            Listatotal.Add(ntotal)
        Next

        Return Listatotal

    End Function

    Public Function GetUbicarArticuloLoteVenta(be As totalesAlmacen) As List(Of totalesAlmacen)
        Dim obj As totalesAlmacen = Nothing

        Dim consulta = (From t In HeliosData.totalesAlmacen
                        Join lote In HeliosData.recursoCostoLote
                            On lote.codigoLote Equals t.codigoLote
                        Join art In HeliosData.detalleitems
                            On art.codigodetalle Equals t.idItem
                        Join conexos In HeliosData.totalesAlmacen
                            On conexos.idPadre Equals t.idMovimiento
                        Where t.idItem = be.idItem And t.codigoLote = be.codigoLote And t.idAlmacen = be.idAlmacen
                        Select art.codigodetalle,
                            t.cantidad,
                            t.importeSoles,
                            t.importeDolares,
                            t.origenRecaudo,
                            art.descripcionItem,
                            art.unidad1,
                            art.codigo,
                            t.codigoLote,
                            conexos,
                            lote
                            ).ToList

        GetUbicarArticuloLoteVenta = New List(Of totalesAlmacen)
        For Each i In consulta
            obj = New totalesAlmacen With
                {
                .idItem = i.codigodetalle,
                .cantidad = i.cantidad,
                .importeSoles = i.importeSoles,
                .importeDolares = i.importeDolares,
                .origenRecaudo = i.origenRecaudo,
                .descripcion = i.descripcionItem,
                .idUnidad = i.unidad1,
                .CodigoBarra = i.codigo,
                .codigoLote = i.codigoLote,
                .ArticulosConexos = i.conexos,
                .CustomLote = i.lote
           }
            GetUbicarArticuloLoteVenta.Add(obj)
        Next


    End Function

    Public Function GetUbicarArticuloLote(be As totalesAlmacen) As totalesAlmacen
        Dim obj As totalesAlmacen = Nothing

        Dim consulta = (From t In HeliosData.totalesAlmacen
                        Join lote In HeliosData.recursoCostoLote
                            On lote.codigoLote Equals t.codigoLote
                        Join art In HeliosData.detalleitems
                            On art.codigodetalle Equals t.idItem
                        Where t.idItem = be.idItem And t.codigoLote = be.codigoLote And t.idAlmacen = be.idAlmacen
                        Select t.idMovimiento,
                            art.codigodetalle,
                            t.cantidad,
                            t.importeSoles,
                            t.importeDolares,
                            t.origenRecaudo,
                            art.descripcionItem,
                            art.unidad1,
                            art.codigo,
                            t.codigoLote,
                            lote,
                            NroEnlaces = CType((Aggregate n In HeliosData.totalesAlmacen
                                             Where n.idPadre = t.idMovimiento
                                                 Into Count(n.idEmpresa)), Integer?)
                            ).FirstOrDefault

        If Not IsNothing(consulta) Then

            'obj = New totalesAlmacen With
            '{
            '.idItem = consulta.art.codigodetalle,
            '.cantidad = consulta.t.cantidad,
            '.importeSoles = consulta.t.importeSoles,
            '.importeDolares = consulta.t.importeDolares,
            '.origenRecaudo = consulta.t.origenRecaudo,
            '.descripcion = consulta.art.descripcionItem,
            '.idUnidad = consulta.art.unidad1,
            '.CodigoBarra = consulta.art.codigo,
            '.codigoLote = consulta.t.codigoLote,
            '.CustomLote = consulta.lote
            ' }
            obj = New totalesAlmacen With
            {
            .idMovimiento = consulta.idMovimiento,
            .idItem = consulta.codigodetalle,
            .cantidad = consulta.cantidad,
            .importeSoles = consulta.importeSoles,
            .importeDolares = consulta.importeDolares,
            .origenRecaudo = consulta.origenRecaudo,
            .descripcion = consulta.descripcionItem,
            .idUnidad = consulta.unidad1,
            .CodigoBarra = consulta.codigo,
            .codigoLote = consulta.codigoLote,
            .NroEnlaces = consulta.NroEnlaces.GetValueOrDefault,
            .CustomLote = consulta.lote
             }
        End If
        GetUbicarArticuloLote = obj
    End Function

    Public Sub GetCurarKardexCaberas(be As List(Of totalesAlmacen))
        For Each i In be
            Dim obj = HeliosData.totalesAlmacen.Where(Function(o) o.idItem = i.idItem And o.idAlmacen = i.idAlmacen).FirstOrDefault
            Using ts As New TransactionScope
                If Not IsNothing(obj) Then
                    obj.fechaActualizacion = Date.Now
                    obj.cantidad = i.cantidad
                    obj.importeSoles = i.importeSoles
                    obj.importeDolares = i.importeDolares
                End If
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Next
    End Sub

    'Public Sub GetTotalizarInventario(be As List(Of totalAlmacendetalleitem))
    '    For Each i In be
    '        Dim obj = HeliosData.totalAlmacendetalleitem.Where(Function(o) o.codigodetalle = i.codigodetalle And o.idAlmacen = i.idAlmacen).FirstOrDefault
    '        Using ts As New TransactionScope
    '            If Not IsNothing(obj) Then
    '                obj.cantidad = i.cantidad
    '                obj.costo = i.costo
    '            End If
    '            HeliosData.SaveChanges()
    '            ts.Complete()
    '        End Using
    '    Next
    'End Sub

    Public Sub GetCurarKardexCaberasLOTE(be As List(Of totalesAlmacen))
        For Each i In be
            Dim obj = HeliosData.totalesAlmacen.Where(Function(o) o.idItem = i.idItem And o.idAlmacen = i.idAlmacen And o.codigoLote = i.NroLote).FirstOrDefault
            Using ts As New TransactionScope
                If Not IsNothing(obj) Then
                    obj.fechaActualizacion = Date.Now
                    obj.cantidad = i.cantidad
                    obj.importeSoles = i.importeSoles
                    obj.importeDolares = i.importeDolares
                End If
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Next
    End Sub

    Public Sub GetCurarKardexCaberasCierre(be As List(Of cierreinventario))
        For Each i In be
            Dim obj = HeliosData.totalesAlmacen.Where(Function(o) o.idItem = i.idItem And o.idAlmacen = i.idAlmacen).FirstOrDefault
            obj.fechaActualizacion = Date.Now
            Using ts As New TransactionScope
                If Not IsNothing(obj) Then
                    obj.cantidad = i.cantidad
                    obj.importeSoles = i.importe
                    obj.importeDolares = 0
                End If
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Next
    End Sub

    Public Sub GetChangeStatusArticulo(Be As totalesAlmacen)
        Using ts As New TransactionScope
            Dim t = HeliosData.totalesAlmacen.Where(Function(o) o.idMovimiento = Be.idMovimiento).FirstOrDefault
            If Not IsNothing(t) Then
                t.status = Be.status
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub GetChangeStatusArticuloIdItem(Be As totalesAlmacen)
        Using ts As New TransactionScope
            Dim t = HeliosData.totalesAlmacen.Where(Function(o) o.idItem = Be.idItem).FirstOrDefault
            If Not IsNothing(t) Then
                t.status = Be.status
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    'Public Function GetIventarioTotal(be As totalesAlmacen) As List(Of totalesAlmacen)
    '    Dim consulta = From t In HeliosData.totalesAlmacen
    '                   Join c In HeliosData.
    'End Function

    Public Function GetUbicar_EstadoCuenta20(idEmpresa As String, periodo As String) As List(Of totalesAlmacen)
        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)

        'Dim obj = (From a In HeliosData.totalesAlmacen
        '           Join prod In HeliosData.detalleitems
        '        On a.idItem Equals prod.codigodetalle
        '           Join alm In HeliosData.almacen
        '           On a.idAlmacen Equals alm.idAlmacen
        '           Where a.idEmpresa = Gempresas.IdEmpresaRuc Order By a.idAlmacen).ToList


        Dim Consulta = (From a In HeliosData.cierreinventario
                        Join prod In HeliosData.detalleitems
                        On a.idItem Equals prod.codigodetalle
                        Join alm In HeliosData.almacen
                         On a.idAlmacen Equals alm.idAlmacen
                        Where a.idEmpresa = idEmpresa And a.periodo = periodo Order By a.idAlmacen)



        For Each i In Consulta
            ntotal = New totalesAlmacen

            ntotal.idAlmacen = i.a.idAlmacen
            ntotal.NomAlmacen = i.alm.descripcionAlmacen
            ntotal.idItem = i.a.idItem
            'ntotal.origenRecaudo = i.a.origenRecaudo
            ntotal.tipoExistencia = i.a.TipoExistencia
            ntotal.descripcion = i.prod.descripcionItem
            ntotal.idUnidad = i.prod.unidad1
            ntotal.unidadMedida = i.prod.unidad1
            ntotal.cantidad = i.a.cantidad
            ntotal.importeSoles = i.a.importe
            ntotal.Presentacion = i.prod.presentacion
            'ntotal.precioUnitarioCompra = i.a.precioUnitarioCompra


            Listatotal.Add(ntotal)
        Next

        Return Listatotal

    End Function


    Public Function GetListadoProductosParaVentaXproductoEmpresaFull(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen)

        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)
        Dim lista As New List(Of String)
        lista.Add("01")
        lista.Add("02")
        lista.Add("06")
        lista.Add("GS")

        Dim obj = (From a In HeliosData.totalesAlmacen
                   Join alm In HeliosData.almacen On alm.idAlmacen Equals a.idAlmacen
                    Join articulo In HeliosData.detalleitems On articulo.codigodetalle Equals a.idItem
                Where alm.tipo <> "AV" And a.idEmpresa = Gempresas.IdEmpresaRuc And _
                lista.Contains(a.tipoExistencia) _
                And a.descripcion.Contains(objTotalBE.descripcion)).ToList
        'Dim obj = (From a In HeliosData.totalesAlmacen
        '           Join alm In HeliosData.almacen On alm.idAlmacen Equals a.idAlmacen
        '            Join articulo In HeliosData.detalleitems On articulo.codigodetalle Equals a.idItem
        '        Where alm.tipo <> "AV" And a.idEmpresa = Gempresas.IdEmpresaRuc _
        '        And a.descripcion.Contains(objTotalBE.descripcion)).ToList

        For Each i In obj
            ntotal = New totalesAlmacen
            ntotal.idEmpresa = i.a.idEmpresa
            ntotal.idEstablecimiento = i.alm.idEstablecimiento
            ntotal.idAlmacen = i.a.idAlmacen
            ntotal.NomAlmacen = i.alm.descripcionAlmacen
            ntotal.idItem = i.a.idItem
            ntotal.origenRecaudo = i.articulo.origenProducto
            ntotal.tipoExistencia = i.articulo.tipoExistencia
            ntotal.descripcion = i.articulo.descripcionItem
            ntotal.idUnidad = i.articulo.unidad1
            ntotal.unidadMedida = i.articulo.unidad1 ' i.tbl.descripcion
            ntotal.cantidad = i.a.cantidad
            ntotal.importeSoles = i.a.importeSoles
            ntotal.importeDolares = i.a.importeDolares

            '  ntotal.Presentacion = i.Presentacion

            Listatotal.Add(ntotal)
        Next

        Return Listatotal

    End Function

    Public Function GetListadoProductosParaVentaXproductoEmpresa(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen)

        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)

        Dim obj = (From a In HeliosData.totalesAlmacen
                   Join alm In HeliosData.almacen On alm.idAlmacen Equals a.idAlmacen
                   Join articulo In HeliosData.detalleitems On articulo.codigodetalle Equals a.idItem
                   Where alm.tipo <> "AV" And a.idEmpresa = Gempresas.IdEmpresaRuc _
                And a.tipoExistencia = objTotalBE.tipoExistencia And a.descripcion.Contains(objTotalBE.descripcion)).ToList

        For Each i In obj
            ntotal = New totalesAlmacen
            ntotal.idEmpresa = i.a.idEmpresa
            ntotal.idEstablecimiento = i.alm.idEstablecimiento
            ntotal.idAlmacen = i.a.idAlmacen
            ntotal.NomAlmacen = i.alm.descripcionAlmacen
            ntotal.idItem = i.a.idItem
            ntotal.origenRecaudo = i.articulo.origenProducto
            ntotal.tipoExistencia = i.articulo.tipoExistencia
            ntotal.descripcion = i.articulo.descripcionItem
            ntotal.idUnidad = i.articulo.unidad1
            ntotal.unidadMedida = i.articulo.unidad1 ' i.tbl.descripcion
            ntotal.cantidad = i.a.cantidad
            ntotal.importeSoles = i.a.importeSoles
            ntotal.importeDolares = i.a.importeDolares
            '  ntotal.Presentacion = i.Presentacion

            Listatotal.Add(ntotal)
        Next

        Return Listatotal

    End Function

    Public Function GetListadoProductosByAlmacen(be As totalesAlmacen) As List(Of totalesAlmacen)

        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)

        Dim obj = (From a In HeliosData.totalesAlmacen
                   Join alm In HeliosData.almacen On alm.idAlmacen Equals a.idAlmacen
                   Join articulo In HeliosData.detalleitems On articulo.codigodetalle Equals a.idItem
                   Join lote In HeliosData.recursoCostoLote On lote.codigoLote Equals a.codigoLote
                   Where alm.tipo <> "AV" And a.idEmpresa = be.idEmpresa _
                       And a.idAlmacen = be.idAlmacen _
                       And a.tipoExistencia = be.tipoExistencia And a.descripcion.Contains(be.descripcion) _
                       And a.status = StatusArticulo.Activo
                   Order By a.descripcion, lote.fechaVcto Ascending).ToList

        For Each i In obj
            ntotal = New totalesAlmacen
            ntotal.CustomLote = i.lote
            ntotal.idEmpresa = i.a.idEmpresa
            ntotal.idEstablecimiento = i.alm.idEstablecimiento
            ntotal.idAlmacen = i.a.idAlmacen
            ntotal.NomAlmacen = i.alm.descripcionAlmacen
            ntotal.idItem = i.a.idItem
            ntotal.origenRecaudo = i.articulo.origenProducto
            ntotal.tipoExistencia = i.articulo.tipoExistencia
            ntotal.descripcion = i.articulo.descripcionItem
            ntotal.idUnidad = i.articulo.unidad1
            ntotal.unidadMedida = i.articulo.unidad1 ' i.tbl.descripcion
            ntotal.cantidad = i.a.cantidad
            ntotal.importeSoles = i.a.importeSoles
            ntotal.importeDolares = i.a.importeDolares
            '  ntotal.Presentacion = i.Presentacion

            Listatotal.Add(ntotal)
        Next

        Return Listatotal

    End Function

    Public Function GetProductosByAlmacenCodigo(intIdAlmacen As Integer, Optional ByVal CodigoBarra As String = Nothing) As List(Of totalesAlmacen)

        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)

        Dim obj = (From a In HeliosData.totalesAlmacen
                   Join alm In HeliosData.almacen On alm.idAlmacen Equals a.idAlmacen
                   Join articulo In HeliosData.detalleitems On articulo.codigodetalle Equals a.idItem
                   Join lote In HeliosData.recursoCostoLote On lote.codigoLote Equals a.codigoLote
                   Where alm.tipo <> "AV" _
                       And a.idAlmacen = intIdAlmacen _
                       And articulo.codigo = CodigoBarra _
                       And a.status = StatusArticulo.Activo _
                       And articulo.estado = "A"
                   Order By a.descripcion, lote.fechaVcto Ascending).ToList

        'Dim obj = (From a In HeliosData.totalesAlmacen
        '           Join prod In HeliosData.detalleitems
        '   On a.idItem Equals prod.codigodetalle
        '           Join alm In HeliosData.almacen
        '   On a.idAlmacen Equals alm.idAlmacen
        '           Group Join cat In HeliosData.item
        '   On cat.idItem Equals prod.idItem
        '   Into ov = Group
        '           From x In ov.DefaultIfEmpty()
        '           Group Join marca In HeliosData.item
        '   On marca.idItem Equals prod.marcaRef
        '   Into ov1 = Group
        '           From x1 In ov1.DefaultIfEmpty()
        '           Group Join lote In HeliosData.recursoCostoLote
        '   On lote.codigoLote Equals a.codigoLote
        '   Into ov2 = Group
        '           From x2 In ov2.DefaultIfEmpty()
        '           Where prod.codigo = CodigoBarra And
        '   a.status = StatusArticulo.Activo).ToList

        For Each i In obj
            ntotal = New totalesAlmacen
            ntotal.CustomLote = i.lote
            ntotal.idEmpresa = i.a.idEmpresa
            ntotal.idEstablecimiento = i.alm.idEstablecimiento
            ntotal.idAlmacen = i.a.idAlmacen
            ntotal.NomAlmacen = i.alm.descripcionAlmacen
            ntotal.idItem = i.a.idItem
            ntotal.origenRecaudo = i.articulo.origenProducto
            ntotal.tipoExistencia = i.articulo.tipoExistencia
            ntotal.descripcion = i.articulo.descripcionItem
            ntotal.idUnidad = i.articulo.unidad1
            ntotal.unidadMedida = i.articulo.unidad1 ' i.tbl.descripcion
            ntotal.cantidad = i.a.cantidad
            ntotal.importeSoles = i.a.importeSoles
            ntotal.importeDolares = i.a.importeDolares
            '  ntotal.Presentacion = i.Presentacion

            Listatotal.Add(ntotal)
        Next

        Return Listatotal
        'For Each i In obj
        '    ntotal = New totalesAlmacen

        '    If IsNothing(i.x2) Then

        '    Else
        '        ntotal.codigoLote = i.x2.codigoLote
        '        ntotal.fechaLote = i.x2.fechaVcto
        '        ntotal.NroLote = i.x2.nroLote
        '    End If

        '    If IsNothing(i.x) Then
        '        ntotal.Clasificicacion = "-"
        '    Else
        '        ntotal.Clasificicacion = i.x.descripcion
        '    End If

        '    If IsNothing(i.x1) Then
        '        ntotal.Marca = "-"
        '    Else
        '        ntotal.Marca = i.x1.descripcion
        '    End If
        '    ntotal.idEmpresa = i.a.idEmpresa
        '    ntotal.idMovimiento = i.a.idMovimiento
        '    ntotal.idEstablecimiento = i.a.idEstablecimiento
        '    ntotal.idAlmacen = i.a.idAlmacen
        '    ntotal.NomAlmacen = i.alm.descripcionAlmacen
        '    ntotal.idItem = i.a.idItem
        '    ntotal.origenRecaudo = i.prod.origenProducto
        '    ntotal.tipoExistencia = i.prod.tipoExistencia
        '    ntotal.descripcion = i.prod.descripcionItem
        '    ntotal.idUnidad = i.prod.unidad1
        '    ntotal.unidadMedida = i.prod.unidad1
        '    ntotal.cantidad = i.a.cantidad
        '    ntotal.importeSoles = i.a.importeSoles
        '    ntotal.importeDolares = i.a.importeDolares
        '    ntotal.Presentacion = i.prod.presentacion
        '    ntotal.cantidadMaxima = i.a.cantidadMaxima
        '    ntotal.cantidadMinima = i.a.cantidadMinima
        '    'ntotal.fechaLote = i.prod.fechaLote.GetValueOrDefault
        '    ntotal.status = i.a.status
        '    Listatotal.Add(ntotal)
        'Next

        ' Return Listatotal

    End Function

    'Public Function GetProductoById(t As totalesAlmacen) As totalesAlmacen
    '    Return HeliosData.totalesAlmacen.Where(Function(o) o.idMovimiento = t.idMovimiento).FirstOrDefault
    'End Function

    Public Function GetProductosParecidosRequeridos(be As totalesAlmacen) As List(Of totalesAlmacen)
        Dim obj As New totalesAlmacen
        Dim Lista As New List(Of totalesAlmacen)
        Dim listaTipoExistencia As New List(Of String)
        listaTipoExistencia.Add(TipoExistencia.MateriaPrima)
        listaTipoExistencia.Add(TipoExistencia.MaterialAuxiliar_SuministroRepuesto)
        listaTipoExistencia.Add(TipoExistencia.EnvasesEmbalajes)
        listaTipoExistencia.Add(TipoExistencia.ProductosEnProceso)


        Dim consulta = (From n In HeliosData.totalesAlmacen _
                        Join articulo In HeliosData.detalleitems _
                        On articulo.codigodetalle Equals n.idItem _
                        Join alm In HeliosData.almacen _
                        On alm.idAlmacen Equals n.idAlmacen _
                        Where n.descripcion.StartsWith(be.descripcion) _
                        And listaTipoExistencia.Contains(n.tipoExistencia) _
                        Order By n.descripcion).ToList

        For Each i In consulta
            obj = New totalesAlmacen
            obj.NomAlmacen = i.alm.descripcionAlmacen
            obj.idAlmacen = i.alm.idAlmacen
            obj.idMovimiento = i.n.idMovimiento
            obj.idItem = i.n.idItem
            obj.descripcion = i.articulo.descripcionItem
            obj.idUnidad = i.articulo.unidad1
            obj.cantidad = i.n.cantidad
            obj.tipoExistencia = i.articulo.tipoExistencia
            obj.origenRecaudo = i.articulo.origenProducto
            Lista.Add(obj)
        Next
        Return Lista
    End Function

    Public Function GetStockAlmacenesBytem(be As totalesAlmacen)
        Dim obj As New totalesAlmacen
        Dim lista As New List(Of totalesAlmacen)

        Dim consulta = (From n In HeliosData.totalesAlmacen
                        Join articulo In HeliosData.detalleitems
                        On articulo.codigodetalle Equals n.idItem
                        Join a In HeliosData.almacen
                        On n.idAlmacen Equals a.idAlmacen
                        Join lote In HeliosData.recursoCostoLote
                                On lote.codigoLote Equals n.codigoLote
                        Where n.idItem = be.idItem And
                       n.idEmpresa = be.idEmpresa _
                       And n.idEstablecimiento = be.idEstablecimiento _
                            And n.codigoLote = be.codigoLote _
                       And a.tipo <> TipoAlmacen.transito).ToList

        For Each i In consulta
            obj = New totalesAlmacen
            obj.CustomLote = i.lote
            obj.idItem = i.n.idItem
            obj.idAlmacen = i.n.idAlmacen
            obj.NomAlmacen = i.a.descripcionAlmacen
            obj.cantidad = i.n.cantidad
            obj.idUnidad = i.articulo.unidad1
            obj.descripcion = i.articulo.descripcionItem
            obj.importeSoles = i.n.importeSoles
            obj.importeDolares = i.n.importeDolares
            lista.Add(obj)
        Next
        Return lista
    End Function





    Public Function GetInventarioAcumulado(idEMpresa As String, idEstablecimiento As Integer) As List(Of totalesAlmacen)

        'Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)

        'Dim query = HeliosData.totalesAlmacen.
        '   GroupBy(Function(g) New With {Key g.idItem,
        '                                 Key g.idEmpresa,
        '                                 Key g.codigoLote}).
        '   Select(Function(group) New With {
        '      .idItem = group.Key.idItem,
        '      .codigoLote = group.Key.codigoLote,
        '      .idempresa = group.Key.idEmpresa,
        '      .MinimaCantidadMaxima = group.Max(Function(m) m.cantidadMinima),
        '      .TotalStock = group.Sum(Function(a) a.cantidad),
        '      .TotalCosto = group.Sum(Function(c) c.importeSoles)}).Where(Function(o) o.TotalStock <= o.MinimaCantidadMaxima).Where(Function(o) o.idempresa = idEMpresa).Count


        'Dim c = HeliosData.totalesAlmacen.Join(HeliosData.detalleitems, Function(post) post.idItem, Function(prod) prod.codigodetalle, Function(post, prod) _
        '                                       New With
        '                                       {
        '                                       .post = post,
        '                                       .prod = prod
        '                                       }).ToList

        'Dim query2 = HeliosData.totalesAlmacen.Join(HeliosData.detalleitems, Function(tot) tot.idItem, Function(prod) prod.codigodetalle, Function(tot, prod) New With
        '                                                                                                                                       {
        '                                                                                                                                       .totalesAlmacen = tot,
        '                                                                                                                                       .detalleitems = prod
        '                                                                                                                                       }).
        '   GroupBy(Function(g) New With {Key g.totalesAlmacen.idItem,
        '                                 Key g.detalleitems.estado,
        '                                 Key g.totalesAlmacen.status,
        '                                 Key g.totalesAlmacen.idAlmacen,
        '                                 Key g.totalesAlmacen.idEmpresa}).
        '   Select(Function(group) New With {
        '      .idItem = group.Key.idItem,
        '      .estado = group.Key.estado,
        '      .status = group.Key.status,
        '      .idalmacen = group.Key.idAlmacen,
        '      .idempresa = group.Key.idEmpresa,
        '      .MinimaCantidadMaxima = group.Max(Function(m) m.totalesAlmacen.cantidadMinima),
        '      .TotalStock = group.Sum(Function(a) a.totalesAlmacen.cantidad),
        '      .TotalCosto = group.Sum(Function(c) c.totalesAlmacen.importeSoles)}) _
        '      .Where(Function(o) o.TotalStock >= 0 And
        '      o.TotalStock <= (o.MinimaCantidadMaxima + 5) And
        '      o.idempresa = idEMpresa And o.idalmacen <> 1 And
        '      o.status = StatusArticulo.Activo And
        '      o.estado = "A").Count

        Dim query2 = HeliosData.totalesAlmacen.
           GroupBy(Function(g) New With {Key g.idItem,
                                         Key g.detalleitems.estado,
                                         Key g.status,
                                         Key g.idAlmacen,
                                         Key g.idEmpresa,
                                         Key g.idEstablecimiento}).
           Select(Function(group) New With {
              .idItem = group.Key.idItem,
              .estado = group.Key.estado,
              .status = group.Key.status,
              .idalmacen = group.Key.idAlmacen,
              .idempresa = group.Key.idEmpresa,
              .MinimaCantidadMaxima = group.Max(Function(m) m.cantidadMinima),
              .TotalStock = group.Sum(Function(a) a.cantidad),
              .TotalCosto = group.Sum(Function(c) c.importeSoles)}) _
              .Where(Function(o) o.TotalStock >= 0 And
              o.TotalStock <= (o.MinimaCantidadMaxima + 5) And
              o.idempresa = idEMpresa And o.idalmacen <> 1 And
              o.status = StatusArticulo.Activo And
              o.estado = "A").Count



        'Dim obj = (From a In HeliosData.totalesAlmacen
        '                   Join prod In HeliosData.detalleitems
        '                       On a.idItem Equals prod.codigodetalle
        '                   Join alm In HeliosData.almacen
        '                       On a.idAlmacen Equals alm.idAlmacen
        '                   Join estable In HeliosData.centrocosto
        '                       On estable.idCentroCosto Equals alm.idEstablecimiento
        '                   Where
        '                       a.idEmpresa = idEMpresa And
        '                       a.status = StatusArticulo.Activo And
        '                       prod.estado = "A"
        '                   Group New With {a, prod} By
        '                       a.idEstablecimiento,
        '                       NomEstable = estable.nombre,
        '                       a.idAlmacen,
        '                       alm.descripcionAlmacen,
        '                       a.idItem,
        '                       a.origenRecaudo,
        '                       TipoProd = a.tipoExistencia,
        '                       prod.descripcionItem,
        '                       a.idUnidad,
        '                       prod.presentacion,
        '                       prod.cantidadMinima,
        '                       prod.cantidadMaxima
        '                       Into g = Group
        '                   Select
        '                       idEstablecimiento,
        '                       NomEstable,
        '                       idAlmacen,
        '                       descripcionAlmacen,
        '                       idItem,
        '                       origenRecaudo,
        '                       TipoProd,
        '                       descripcionItem,
        '                       idUnidad,
        '                       presentacion,
        '                       cantidadMinima,
        '                       cantidadMaxima,
        '                       SumaCantStock = CType(g.Sum(Function(p) p.a.cantidad), Decimal?),
        '                       SumaCostoMN = CType(g.Sum(Function(p) p.a.importeSoles), Decimal?),
        '                       SumaCostoME = CType(g.Sum(Function(p) p.a.importeDolares), Decimal?)).ToList

        'For Each i In obj
        '    ntotal = New totalesAlmacen
        '    ntotal.idEstablecimiento = i.idEstablecimiento
        '    ntotal.NombreEstablecimiento = i.NomEstable
        '    ntotal.idAlmacen = i.idAlmacen
        '    ntotal.NomAlmacen = i.descripcionAlmacen
        '    ntotal.idItem = i.idItem
        '    ntotal.origenRecaudo = i.origenRecaudo
        '    ntotal.tipoExistencia = i.TipoProd
        '    ntotal.descripcion = i.descripcionItem
        '    ntotal.idUnidad = i.idUnidad
        '    ntotal.unidadMedida = i.idUnidad
        '    ntotal.Presentacion = i.presentacion
        '    ntotal.cantidad = i.SumaCantStock.GetValueOrDefault
        '    ntotal.importeSoles = i.SumaCostoMN.GetValueOrDefault
        '    ntotal.importeDolares = i.SumaCostoME.GetValueOrDefault
        '    ntotal.cantidadMinima = i.cantidadMinima.GetValueOrDefault
        '    ntotal.cantidadMaxima = i.cantidadMaxima.GetValueOrDefault
        '    Listatotal.Add(ntotal)
        'Next
        Listatotal.Add(New totalesAlmacen With {.cantidad = query2})
        Return Listatotal

    End Function

    'Public Function GetProductoStockEscaso(intIdAlmacen As Integer, Optional ByVal TipoExistencia As String = Nothing) As List(Of totalesAlmacen)
    '    gg
    '    Dim ntotal As New totalesAlmacen
    '    Dim Listatotal As New List(Of totalesAlmacen)

    '    Select Case TipoExistencia
    '        Case "00"

    '            Dim obj = (From a In HeliosData.totalesAlmacen
    '                       Join prod In HeliosData.detalleitems
    '                           On a.idItem Equals prod.codigodetalle
    '                       Join alm In HeliosData.almacen
    '                           On a.idAlmacen Equals alm.idAlmacen
    '                       Join estable In HeliosData.centrocosto
    '                           On estable.idCentroCosto Equals alm.idEstablecimiento
    '                       Where
    '                           a.idAlmacen = intIdAlmacen And
    '                           a.status = StatusArticulo.Activo And
    '                           prod.estado = "A"
    '                       Group New With {a, prod} By
    '                           a.idEstablecimiento,
    '                           NomEstable = estable.nombre,
    '                           a.idAlmacen,
    '                           alm.descripcionAlmacen,
    '                           a.idItem,
    '                           a.origenRecaudo,
    '                           TipoProd = a.tipoExistencia,
    '                           prod.descripcionItem,
    '                           a.idUnidad,
    '                           prod.presentacion
    '                           Into g = Group
    '                       Select
    '                           idEstablecimiento,
    '                           NomEstable,
    '                           idAlmacen,
    '                           descripcionAlmacen,
    '                           idItem,
    '                           origenRecaudo,
    '                           TipoProd,
    '                           descripcionItem,
    '                           idUnidad,
    '                           presentacion,
    '                           SumaCantStock = CType(g.Sum(Function(p) p.a.cantidad), Decimal?),
    '                           SumaCostoMN = CType(g.Sum(Function(p) p.a.importeSoles), Decimal?),
    '                           SumaCostoME = CType(g.Sum(Function(p) p.a.importeDolares), Decimal?)).ToList

    '            For Each i In obj
    '                ntotal = New totalesAlmacen
    '                ntotal.idEstablecimiento = i.idEstablecimiento
    '                ntotal.NombreEstablecimiento = i.NomEstable
    '                ntotal.idAlmacen = i.idAlmacen
    '                ntotal.NomAlmacen = i.descripcionAlmacen
    '                ntotal.idItem = i.idItem
    '                ntotal.origenRecaudo = i.origenRecaudo
    '                ntotal.tipoExistencia = i.TipoProd
    '                ntotal.descripcion = i.descripcionItem
    '                ntotal.idUnidad = i.idUnidad
    '                ntotal.unidadMedida = i.idUnidad
    '                ntotal.Presentacion = i.presentacion
    '                ntotal.cantidad = i.SumaCantStock.GetValueOrDefault
    '                ntotal.importeSoles = i.SumaCostoMN.GetValueOrDefault
    '                ntotal.importeDolares = i.SumaCostoME.GetValueOrDefault
    '                Listatotal.Add(ntotal)
    '            Next
    '        Case Else


    '            Dim obj = (From a In HeliosData.totalesAlmacen
    '                       Join prod In HeliosData.detalleitems
    '                           On a.idItem Equals prod.codigodetalle
    '                       Join alm In HeliosData.almacen
    '                           On a.idAlmacen Equals alm.idAlmacen
    '                       Join estable In HeliosData.centrocosto
    '                           On estable.idCentroCosto Equals alm.idEstablecimiento
    '                       Where
    '                           a.idAlmacen = intIdAlmacen And
    '                           a.status = StatusArticulo.Activo And
    '                           a.tipoExistencia = TipoExistencia And
    '                           prod.estado = "A"
    '                       Group New With {a, prod} By
    '                           a.idEstablecimiento,
    '                           NomEstable = estable.nombre,
    '                           a.idAlmacen,
    '                           alm.descripcionAlmacen,
    '                           a.idItem,
    '                           a.origenRecaudo,
    '                           TipoProd = a.tipoExistencia,
    '                           prod.descripcionItem,
    '                           a.idUnidad,
    '                           prod.presentacion
    '                           Into g = Group
    '                       Select
    '                           idEstablecimiento,
    '                           NomEstable,
    '                           idAlmacen,
    '                           descripcionAlmacen,
    '                           idItem,
    '                           origenRecaudo,
    '                           TipoProd,
    '                           descripcionItem,
    '                           idUnidad,
    '                           presentacion,
    '                           SumaCantStock = CType(g.Sum(Function(p) p.a.cantidad), Decimal?),
    '                           SumaCostoMN = CType(g.Sum(Function(p) p.a.importeSoles), Decimal?),
    '                           SumaCostoME = CType(g.Sum(Function(p) p.a.importeDolares), Decimal?)).ToList


    '            For Each i In obj
    '                ntotal = New totalesAlmacen
    '                ntotal.idEstablecimiento = i.idEstablecimiento
    '                ntotal.NombreEstablecimiento = i.NomEstable
    '                ntotal.idAlmacen = i.idAlmacen
    '                ntotal.NomAlmacen = i.descripcionAlmacen
    '                ntotal.idItem = i.idItem
    '                ntotal.origenRecaudo = i.origenRecaudo
    '                ntotal.tipoExistencia = i.TipoProd
    '                ntotal.descripcion = i.descripcionItem
    '                ntotal.idUnidad = i.idUnidad
    '                ntotal.unidadMedida = i.idUnidad
    '                ntotal.Presentacion = i.presentacion
    '                ntotal.cantidad = i.SumaCantStock.GetValueOrDefault
    '                ntotal.importeSoles = i.SumaCostoMN.GetValueOrDefault
    '                ntotal.importeDolares = i.SumaCostoME.GetValueOrDefault
    '                Listatotal.Add(ntotal)
    '            Next
    '    End Select



    '    Return Listatotal

    'End Function


    Public Function GetProductosXvencerMes(empresa As String, anio As Integer, mes As Integer, TipoExistencia As String,
                                           intIdAlmacen As Integer) As List(Of totalesAlmacen)

        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)

        Select Case TipoExistencia
            Case "00"
                Dim obj = (From a In HeliosData.totalesAlmacen
                           Join prod In HeliosData.detalleitems
                   On a.idItem Equals prod.codigodetalle
                           Join alm In HeliosData.almacen
                   On a.idAlmacen Equals alm.idAlmacen
                           Join estable In HeliosData.centrocosto On estable.idCentroCosto Equals alm.idEstablecimiento
                           Group Join cat In HeliosData.item
                   On cat.idItem Equals prod.idItem
                   Into ov = Group
                           From x In ov.DefaultIfEmpty()
                           Group Join marca In HeliosData.item
                   On marca.idItem Equals prod.marcaRef
                   Into ov1 = Group
                           From x1 In ov1.DefaultIfEmpty()
                           Group Join lote In HeliosData.recursoCostoLote
                   On lote.codigoLote Equals a.codigoLote
                   Into ov2 = Group
                           From x2 In ov2.DefaultIfEmpty()
                           Where a.idAlmacen = intIdAlmacen _
                               And a.status = StatusArticulo.Activo _
                               And prod.estado = "A" _
                               And x2.fechaVcto.Value.Year = anio _
                               And x2.fechaVcto.Value.Month = mes).ToList


                For Each i In obj
                    ntotal = New totalesAlmacen
                    If IsNothing(i.x) Then
                        ntotal.Clasificicacion = "-"
                    Else
                        ntotal.Clasificicacion = i.x.descripcion
                    End If

                    If IsNothing(i.x1) Then
                        ntotal.Marca = "-"
                    Else
                        ntotal.Marca = i.x1.descripcion
                    End If

                    ntotal.idMovimiento = i.a.idMovimiento
                    ntotal.idEstablecimiento = i.a.idEstablecimiento
                    ntotal.NombreEstablecimiento = i.estable.nombre
                    ntotal.idAlmacen = i.a.idAlmacen
                    ntotal.NomAlmacen = i.alm.descripcionAlmacen
                    ntotal.idItem = i.a.idItem
                    ntotal.origenRecaudo = i.a.origenRecaudo
                    ntotal.tipoExistencia = i.a.tipoExistencia
                    ntotal.descripcion = i.prod.descripcionItem
                    ntotal.idUnidad = i.a.idUnidad
                    ntotal.unidadMedida = i.a.idUnidad
                    ntotal.cantidad = i.a.cantidad
                    ntotal.importeSoles = i.a.importeSoles
                    ntotal.importeDolares = i.a.importeDolares
                    ntotal.Presentacion = i.prod.presentacion
                    ntotal.cantidadMaxima = i.a.cantidadMaxima
                    ntotal.cantidadMinima = i.a.cantidadMinima
                    'ntotal.fechaLote = i.prod.fechaLote.GetValueOrDefault

                    If IsNothing(i.x2) Then

                    Else
                        ntotal.fechaLote = i.x2.fechaVcto
                        ntotal.NroLote = i.x2.nroLote
                    End If


                    ntotal.status = i.a.status

                    Listatotal.Add(ntotal)
                Next
            Case Else


                Dim obj = (From a In HeliosData.totalesAlmacen
                           Join prod In HeliosData.detalleitems
                   On a.idItem Equals prod.codigodetalle
                           Join alm In HeliosData.almacen
                   On a.idAlmacen Equals alm.idAlmacen
                           Join estable In HeliosData.centrocosto On estable.idCentroCosto Equals alm.idEstablecimiento
                           Group Join cat In HeliosData.item
                   On cat.idItem Equals prod.idItem
                   Into ov = Group
                           From x In ov.DefaultIfEmpty()
                           Group Join marca In HeliosData.item
                   On marca.idItem Equals prod.marcaRef
                   Into ov1 = Group
                           From x1 In ov1.DefaultIfEmpty()
                           Group Join lote In HeliosData.recursoCostoLote
                   On lote.codigoLote Equals a.codigoLote
                               Into ov2 = Group
                           From x2 In ov2.DefaultIfEmpty()
                           Where a.idAlmacen = intIdAlmacen _
                               And a.tipoExistencia = TipoExistencia _
                               And x2.fechaVcto.Value.Year = anio _
                               And x2.fechaVcto.Value.Month = mes).ToList


                For Each i In obj
                    ntotal = New totalesAlmacen
                    If IsNothing(i.x) Then
                        ntotal.Clasificicacion = "-"
                    Else
                        ntotal.Clasificicacion = i.x.descripcion
                    End If

                    If IsNothing(i.x1) Then
                        ntotal.Marca = "-"
                    Else
                        ntotal.Marca = i.x1.descripcion
                    End If

                    ntotal.idMovimiento = i.a.idMovimiento
                    ntotal.idEstablecimiento = i.a.idEstablecimiento
                    ntotal.NombreEstablecimiento = i.estable.nombre
                    ntotal.idAlmacen = i.a.idAlmacen
                    ntotal.NomAlmacen = i.alm.descripcionAlmacen
                    ntotal.idItem = i.a.idItem
                    ntotal.origenRecaudo = i.a.origenRecaudo
                    ntotal.tipoExistencia = i.a.tipoExistencia
                    ntotal.descripcion = i.prod.descripcionItem
                    ntotal.idUnidad = i.a.idUnidad
                    ntotal.unidadMedida = i.a.idUnidad
                    ntotal.cantidad = i.a.cantidad
                    ntotal.importeSoles = i.a.importeSoles
                    ntotal.importeDolares = i.a.importeDolares
                    ntotal.Presentacion = i.prod.presentacion
                    ntotal.cantidadMaxima = i.a.cantidadMaxima
                    ntotal.cantidadMinima = i.a.cantidadMinima
                    'ntotal.fechaLote = i.prod.fechaLote.GetValueOrDefault
                    If IsNothing(i.x2) Then

                    Else
                        ntotal.fechaLote = i.x2.fechaVcto
                        ntotal.NroLote = i.x2.nroLote
                    End If
                    ntotal.status = i.a.status
                    Listatotal.Add(ntotal)
                Next
        End Select



        Return Listatotal

    End Function

    Public Function GetProductosXvencerMesCount(empresa As String, anio As Integer, mes As Integer) As Integer


        Dim obj = (From a In HeliosData.totalesAlmacen
                   Join prod In HeliosData.detalleitems
                   On a.idItem Equals prod.codigodetalle
                   Join alm In HeliosData.almacen
                   On a.idAlmacen Equals alm.idAlmacen
                   Join estable In HeliosData.centrocosto On estable.idCentroCosto Equals alm.idEstablecimiento
                   Group Join cat In HeliosData.item
                   On cat.idItem Equals prod.idItem
                   Into ov = Group
                   From x In ov.DefaultIfEmpty()
                   Group Join marca In HeliosData.item
                   On marca.idItem Equals prod.marcaRef
                   Into ov1 = Group
                   From x1 In ov1.DefaultIfEmpty()
                   Group Join lote In HeliosData.recursoCostoLote
                   On lote.codigoLote Equals a.codigoLote
                   Into ov2 = Group
                   From x2 In ov2.DefaultIfEmpty()
                   Where x2.fechaVcto.Value.Year = anio _
                       And x2.fechaVcto.Value.Month = mes _
                       And alm.tipo <> TipoAlmacen.transito).Count

        Return obj

    End Function

    Public Function GetProductosXvencerMesFull(empresa As String, anio As Integer, mes As Integer) As List(Of totalesAlmacen)

        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)

        Dim obj = (From a In HeliosData.totalesAlmacen
                   Join prod In HeliosData.detalleitems
                   On a.idItem Equals prod.codigodetalle
                   Join alm In HeliosData.almacen
                   On a.idAlmacen Equals alm.idAlmacen
                   Join estable In HeliosData.centrocosto On estable.idCentroCosto Equals alm.idEstablecimiento
                   Group Join cat In HeliosData.item
                   On cat.idItem Equals prod.idItem
                   Into ov = Group
                   From x In ov.DefaultIfEmpty()
                   Group Join marca In HeliosData.item
                   On marca.idItem Equals prod.marcaRef
                   Into ov1 = Group
                   From x1 In ov1.DefaultIfEmpty()
                   Group Join lote In HeliosData.recursoCostoLote
                   On lote.codigoLote Equals a.codigoLote
                   Into ov2 = Group
                   From x2 In ov2.DefaultIfEmpty()
                   Where x2.fechaVcto.Value.Year = anio _
                       And x2.fechaVcto.Value.Month = mes _
                       And alm.tipo <> TipoAlmacen.transito).ToList


        For Each i In obj
            ntotal = New totalesAlmacen
            If IsNothing(i.x) Then
                ntotal.Clasificicacion = "-"
            Else
                ntotal.Clasificicacion = i.x.descripcion
            End If

            If IsNothing(i.x1) Then
                ntotal.Marca = "-"
            Else
                ntotal.Marca = i.x1.descripcion
            End If

            ntotal.idMovimiento = i.a.idMovimiento
            ntotal.idEstablecimiento = i.a.idEstablecimiento
            ntotal.NombreEstablecimiento = i.estable.nombre
            ntotal.idAlmacen = i.a.idAlmacen
            ntotal.NomAlmacen = i.alm.descripcionAlmacen
            ntotal.idItem = i.a.idItem
            ntotal.origenRecaudo = i.a.origenRecaudo
            ntotal.tipoExistencia = i.a.tipoExistencia
            ntotal.descripcion = i.prod.descripcionItem
            ntotal.idUnidad = i.a.idUnidad
            ntotal.unidadMedida = i.a.idUnidad
            ntotal.cantidad = i.a.cantidad
            ntotal.importeSoles = i.a.importeSoles
            ntotal.importeDolares = i.a.importeDolares
            ntotal.Presentacion = i.prod.presentacion
            ntotal.cantidadMaxima = i.a.cantidadMaxima
            ntotal.cantidadMinima = i.a.cantidadMinima
            'ntotal.fechaLote = i.prod.fechaLote.GetValueOrDefault

            If IsNothing(i.x2) Then

            Else
                ntotal.fechaLote = i.x2.fechaVcto
                ntotal.NroLote = i.x2.nroLote
            End If


            ntotal.status = i.a.status

            Listatotal.Add(ntotal)
        Next


        Return Listatotal

    End Function

    Public Function GetAlmacenesByProducto(intIdItem As Integer, strIdEmpresa As String) As List(Of totalesAlmacen)

        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)

        Dim obj = (From a In HeliosData.totalesAlmacen
                    Join prod In HeliosData.detalleitems _
                    On a.idItem Equals prod.codigodetalle _
                    Join tbl In HeliosData.tabladetalle _
                    On prod.unidad1 Equals tbl.codigoDetalle _
                    Join alm In HeliosData.almacen _
                    On a.idAlmacen Equals alm.idAlmacen _
                    Group Join cat In HeliosData.item _
                    On cat.idItem Equals prod.idItem _
                    Into ov = Group _
                    From x In ov.DefaultIfEmpty() _
                     Group Join marca In HeliosData.item _
                    On marca.idItem Equals prod.marcaRef _
                    Into ov1 = Group _
                    From x1 In ov1.DefaultIfEmpty() _
                    Where a.idEmpresa = strIdEmpresa _
                    And a.idItem = intIdItem _
                    And tbl.idtabla = 6).ToList

        For Each i In obj
            ntotal = New totalesAlmacen
            If IsNothing(i.x) Then
                ntotal.Clasificicacion = "-"
            Else
                ntotal.Clasificicacion = i.x.descripcion
            End If

            If IsNothing(i.x1) Then
                ntotal.Marca = "-"
            Else
                ntotal.Marca = i.x1.descripcion
            End If

            ntotal.idMovimiento = i.a.idMovimiento
            ntotal.idEstablecimiento = i.a.idEstablecimiento
            ntotal.idAlmacen = i.a.idAlmacen
            ntotal.NomAlmacen = i.alm.descripcionAlmacen
            ntotal.idItem = i.a.idItem
            ntotal.origenRecaudo = i.a.origenRecaudo
            ntotal.tipoExistencia = i.a.tipoExistencia
            ntotal.descripcion = i.prod.descripcionItem
            ntotal.idUnidad = i.prod.unidad1
            ntotal.unidadMedida = i.tbl.descripcion
            ntotal.cantidad = i.a.cantidad
            ntotal.importeSoles = i.a.importeSoles
            ntotal.importeDolares = i.a.importeDolares
            ntotal.Presentacion = i.prod.presentacion
            ntotal.cantidadMaxima = i.a.cantidadMaxima
            ntotal.cantidadMinima = i.a.cantidadMinima

            Listatotal.Add(ntotal)
        Next

        Return Listatotal

    End Function

    Public Sub UpdateStockTransito(ByVal i As totalesAlmacen)
        Dim objNuevo As New totalesAlmacen()
        Dim t As New totalesAlmacen
        Using ts As New TransactionScope()

            objNuevo = HeliosData.totalesAlmacen.Where(Function(o) o.idAlmacen = i.idAlmacen And _
                                                           o.origenRecaudo = i.origenRecaudo And _
                                                           o.idItem = i.idItem).FirstOrDefault

            If Not IsNothing(objNuevo) Then ' si existe el producto
                objNuevo.cantidad = objNuevo.cantidad + i.cantidad
                objNuevo.precioUnitarioCompra = objNuevo.precioUnitarioCompra + i.precioUnitarioCompra
                objNuevo.importeSoles = objNuevo.importeSoles + i.importeSoles
                objNuevo.importeDolares = objNuevo.importeDolares + i.importeDolares
            End If

            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub

    Public Sub UpdateTipoCant(ByVal ProductoBE As detalleitems)
        Using ts As New TransactionScope
            Dim objDEtalle As New totalesAlmacen
            'Se actualiza asiento
            objDEtalle = HeliosData.totalesAlmacen.Where(Function(O) O.idItem = ProductoBE.codigodetalle _
                                                             And O.idAlmacen = ProductoBE.idAlmacen).First

            With objDEtalle

                .idUnidad = ProductoBE.unidad1
                .cantidadMaxima = ProductoBE.cantMax
                .cantidadMinima = ProductoBE.cantMinima

            End With
            'HeliosData.ObjectStateManager.GetObjectStateEntry(objDEtalle).State.ToString()
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub ActulizarCantidadesByItem(be As totalesAlmacen)
        Using ts As New TransactionScope
            Dim objDEtalle As New totalesAlmacen
            objDEtalle = HeliosData.totalesAlmacen.Where(Function(O) O.idMovimiento = be.idMovimiento).FirstOrDefault

            If Not IsNothing(objDEtalle) Then
                objDEtalle.cantidadMaxima = be.cantidadMaxima
                objDEtalle.cantidadMinima = be.cantidadMinima
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Function GetProductoPorAlmacenTipoExTodo(intIdAlmacen As Integer) As List(Of totalesAlmacen)

        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)

        Dim obj = (From a In HeliosData.totalesAlmacen
                    Join prod In HeliosData.detalleitems _
                    On a.idItem Equals prod.codigodetalle _
                    Join tbl In HeliosData.tabladetalle _
                    On prod.unidad1 Equals tbl.codigoDetalle _
                    Join alm In HeliosData.almacen _
                    On a.idAlmacen Equals alm.idAlmacen _
                    Group Join cat In HeliosData.item _
                    On cat.idItem Equals prod.idItem _
                    Into ov = Group _
                    From x In ov.DefaultIfEmpty() _
                    Where a.idAlmacen = intIdAlmacen _
                    And tbl.idtabla = 6).ToList

        For Each i In obj
            ntotal = New totalesAlmacen
            If IsNothing(i.x) Then
                ntotal.Clasificicacion = "-"
            Else
                ntotal.Clasificicacion = i.x.descripcion
            End If
            ntotal.idMovimiento = i.a.idMovimiento
            ntotal.idEstablecimiento = i.a.idEstablecimiento
            ntotal.idAlmacen = i.a.idAlmacen
            ntotal.NomAlmacen = i.alm.descripcionAlmacen
            ntotal.idItem = i.a.idItem
            ntotal.origenRecaudo = i.a.origenRecaudo
            ntotal.tipoExistencia = i.a.tipoExistencia
            ntotal.descripcion = i.prod.descripcionItem
            ntotal.idUnidad = i.prod.unidad1
            ntotal.unidadMedida = i.tbl.descripcion
            ntotal.cantidad = i.a.cantidad
            ntotal.importeSoles = i.a.importeSoles
            ntotal.importeDolares = i.a.importeDolares
            ntotal.Presentacion = i.prod.presentacion
            ntotal.cantidadMaxima = i.a.cantidadMaxima
            ntotal.cantidadMinima = i.a.cantidadMinima

            Listatotal.Add(ntotal)
        Next

        Return Listatotal

    End Function

    Public Function ObtenerCanDisponibleProduct(bt As totalesAlmacen) As totalesAlmacen
        Dim consulta = (From o In HeliosData.totalesAlmacen
                        Where o.idAlmacen = bt.idAlmacen And
                       o.idItem = bt.idItem).FirstOrDefault

        Return consulta
    End Function

    Public Function ObtenerCanDisponibleProductLote(bt As totalesAlmacen) As totalesAlmacen
        Dim consulta = (From o In HeliosData.totalesAlmacen
                        Where o.idAlmacen = bt.idAlmacen And
                       o.idItem = bt.idItem And o.codigoLote = bt.codigoLote).FirstOrDefault

        Return consulta
    End Function

    Public Function GetProductoPorAlmacenItem(intIdAlmacen As Integer, strTipoEx As String, iditem As Integer) As List(Of totalesAlmacen)

        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)

        Dim obj = (From a In HeliosData.totalesAlmacen
                    Join prod In HeliosData.detalleitems _
                    On a.idItem Equals prod.codigodetalle _
                    Join tbl In HeliosData.tabladetalle _
                    On prod.unidad1 Equals tbl.codigoDetalle _
                    Join alm In HeliosData.almacen _
                    On a.idAlmacen Equals alm.idAlmacen _
                    Group Join cat In HeliosData.item _
                    On cat.idItem Equals prod.idItem _
                    Into ov = Group _
                    From x In ov.DefaultIfEmpty() _
                    Where a.idAlmacen = intIdAlmacen _
                    And prod.tipoExistencia = strTipoEx _
                    And tbl.idtabla = 6 _
                    And prod.idItem = iditem).ToList

        For Each i In obj
            ntotal = New totalesAlmacen
            If IsNothing(i.x) Then
                ntotal.Clasificicacion = "-"
            Else
                ntotal.Clasificicacion = i.x.descripcion
            End If
            ntotal.idMovimiento = i.a.idMovimiento
            ntotal.idEstablecimiento = i.a.idEstablecimiento
            ntotal.idAlmacen = i.a.idAlmacen
            ntotal.NomAlmacen = i.alm.descripcionAlmacen
            ntotal.idItem = i.a.idItem
            ntotal.origenRecaudo = i.a.origenRecaudo
            ntotal.tipoExistencia = i.a.tipoExistencia
            ntotal.descripcion = i.prod.descripcionItem
            ntotal.idUnidad = i.prod.unidad1
            ntotal.unidadMedida = i.tbl.descripcion
            ntotal.cantidad = i.a.cantidad
            ntotal.importeSoles = i.a.importeSoles
            ntotal.importeDolares = i.a.importeDolares
            ntotal.Presentacion = i.prod.presentacion
            ntotal.cantidadMaxima = i.a.cantidadMaxima
            ntotal.cantidadMinima = i.a.cantidadMinima

            Listatotal.Add(ntotal)
        Next

        Return Listatotal

    End Function

    Public Function GetAlertaIventarioMinimo(be As totalesAlmacen) As List(Of totalesAlmacen)
        Dim obj As New totalesAlmacen
        Dim lista As New List(Of totalesAlmacen)

        Dim consulta = (From t In HeliosData.totalesAlmacen _
                        Join a In HeliosData.almacen On New With {t.idAlmacen} Equals New With {a.idAlmacen} _
                        Where _
                        (t.cantidad - t.cantidadMinima) <= CDec(0) And _
                        a.tipo <> "AV" _
                        And t.idEmpresa = be.idEmpresa _
                        Select a.idAlmacen, a.descripcionAlmacen, t.idItem, t.descripcion, t.idUnidad, t.cantidad, t.importeSoles, t.importeDolares, t.cantidadMinima).ToList


        For Each i In consulta
            obj = New totalesAlmacen
            obj.idAlmacen = i.idAlmacen
            obj.NomAlmacen = i.descripcionAlmacen
            obj.idItem = i.idItem
            obj.descripcion = i.descripcion
            obj.idUnidad = i.idUnidad
            obj.cantidad = i.cantidad
            obj.importeSoles = i.importeSoles
            obj.importeDolares = i.importeDolares
            obj.cantidadMinima = i.cantidadMinima
            lista.Add(obj)
        Next
        Return lista
    End Function

    Public Function GetAlertaIventarioMinimoConteo(be As totalesAlmacen) As Integer

        Dim consulta = (From t In HeliosData.totalesAlmacen
                        Join a In HeliosData.almacen On New With {t.idAlmacen} Equals New With {a.idAlmacen}
                        Where
                        (t.cantidad - t.cantidadMinima) <= CDec(0) And
                        a.tipo <> "AV" _
                        And t.idEmpresa = be.idEmpresa).Count



        Return consulta
    End Function

    Public Function GetAlertaIventarioSinStockConteo(be As totalesAlmacen) As Integer

        Dim consulta = (From t In HeliosData.totalesAlmacen
                        Join a In HeliosData.almacen On New With {t.idAlmacen} Equals New With {a.idAlmacen}
                        Where
                            (t.cantidad - t.cantidadMinima) <= CDec(0) And
                            a.tipo <> "AV" And
                            t.idEmpresa = be.idEmpresa And
                            t.idEstablecimiento = be.idEstablecimiento And
                            t.status = StatusArticulo.Activo).Count

        Return consulta
    End Function

    Public Function ProductosMayorStock(tot As totalesAlmacen) As List(Of totalesAlmacen)
        Dim obj As New totalesAlmacen
        Dim lista As New List(Of totalesAlmacen)

        Dim consulta = (From p In HeliosData.totalesAlmacen _
                   Where p.idEmpresa = tot.idEmpresa _
                   And p.idEstablecimiento = tot.idEstablecimiento).ToList

        For Each i In consulta

            If i.cantidad >= i.cantidadMaxima Then
                obj = New totalesAlmacen
                obj.idItem = i.idItem
                obj.descripcion = i.descripcion
                obj.idAlmacen = i.idAlmacen
                obj.cantidad = i.cantidad
                obj.cantidadMaxima = i.cantidadMaxima
                obj.cantidadMinima = i.cantidadMinima
                lista.Add(obj)

            End If

        Next

        Return lista
    End Function

    Public Function ProductosPocoStock(tot As totalesAlmacen) As List(Of totalesAlmacen)
        Dim obj As New totalesAlmacen
        Dim lista As New List(Of totalesAlmacen)

        Dim consulta = (From p In HeliosData.totalesAlmacen _
                   Where p.idEmpresa = tot.idEmpresa _
                   And p.idEstablecimiento = tot.idEstablecimiento).ToList

        For Each i In consulta

            If i.cantidad <= i.cantidadMinima Then
                obj = New totalesAlmacen
                obj.idItem = i.idItem
                obj.descripcion = i.descripcion
                obj.idAlmacen = i.idAlmacen
                obj.cantidad = i.cantidad
                obj.cantidadMaxima = i.cantidadMaxima
                obj.cantidadMinima = i.cantidadMinima
                lista.Add(obj)

            End If

        Next

        Return lista
    End Function

    Public Function NumProductosSinListaPrecio(tot As totalesAlmacen) As List(Of totalesAlmacen)
        Dim obj As New totalesAlmacen
        Dim lista As New List(Of totalesAlmacen)
        Dim listaTipoExistencia As New List(Of String)
        listaTipoExistencia.Add(TipoExistencia.Mercaderia)
        listaTipoExistencia.Add(TipoExistencia.ProductoTerminado)
        listaTipoExistencia.Add(TipoExistencia.SubProductosDesechos)
        listaTipoExistencia.Add(TipoExistencia.ActivoInmovilizado)


        Dim consulta = (From p In HeliosData.detalleitems _
                    Group Join c In HeliosData.configuracionPrecioProducto _
                   On p.codigodetalle Equals c.idproducto _
                   Into ords = Group _
                   From c In ords.DefaultIfEmpty _
                   Where p.idEmpresa = tot.idEmpresa _
                   And p.idEstablecimiento = tot.idEstablecimiento _
                   And listaTipoExistencia.Contains(p.tipoExistencia) _
                   Group c By _
                   p.codigodetalle, p.descripcionItem,
                   p.origenProducto, p.unidad1, p.tipoExistencia _
                   Into g = Group _
                   Select New With {.idItem = codigodetalle,
                                    .DescripcionEF = descripcionItem,
                                    .cantidad = 0,
                                    .origenRecaudo = origenProducto,
                                    .unidad = unidad1,
                                    .tipoExistencia = tipoExistencia,
                                    g, .Conteo = g.Count(Function(c) c.idPrecio)
                                   }
                            ).ToList

        Dim q = consulta.Where(Function(o) o.Conteo = 0).ToList()

        For Each i In q
            obj = New totalesAlmacen
            obj.idItem = i.idItem
            obj.descripcion = i.DescripcionEF
            obj.cantidad = i.cantidad
            obj.origenRecaudo = i.origenRecaudo
            obj.idUnidad = i.unidad
            obj.tipoExistencia = i.tipoExistencia
            obj.idDocumento = i.Conteo
            lista.Add(obj)
        Next

        Return lista
    End Function

    'Public Function ObtenerAlertaDePrecio(ByVal productoBE As totalesAlmacen) As List(Of totalesAlmacen)
    '    Dim lista As New List(Of totalesAlmacen)
    '    Dim obj As New totalesAlmacen

    '    Dim con = (From t In HeliosData.totalesAlmacen _
    '               Group Join inv In HeliosData.InventarioMovimiento _
    '               On New With {t.idItem, t.idAlmacen} _
    '               Equals New With {inv.idItem, inv.idAlmacen} Into inv_join = Group _
    '               From inv In inv_join.DefaultIfEmpty() _
    '               Group Join prec In HeliosData.configuracionPrecioProducto _
    '               On New With {.Idproducto = t.idItem, t.idAlmacen} _
    '               Equals New With {prec.idproducto, prec.idAlmacen} Into prec_join = Group _
    '               From prec In prec_join.DefaultIfEmpty() _
    '               Group New With {t, inv, prec} By _
    '               t.idItem, t.descripcion, t.idAlmacen _
    '               Into g = Group _
    '               Where g.Max(Function(p) p.inv.fecha) > g.Max(Function(p) p.prec.fecha) And _
    '               CLng(idAlmacen) = productoBE.idAlmacen _
    '               Select IdItem = CType(idItem, Int32?), _
    '               descripcion,
    '               inventario = CType(g.Max(Function(p) p.inv.fecha), DateTime?),
    '               precio = CType(g.Max(Function(p) p.prec.fecha), DateTime?)).ToList

    '    For Each i In con
    '        '     If (i.precio > i.invetario) Then
    '        obj = New totalesAlmacen
    '        obj.idItem = i.IdItem
    '        obj.descripcion = i.descripcion
    '        obj.FechaUltimoPrecioKardex = i.inventario
    '        obj.FechaUltimoPrecioConfigurado = i.precio
    '        lista.Add(obj)
    '        '     End If
    '    Next
    '    Return lista
    'End Function

    Public Function ObtenerAlertaDePrecio(ByVal productoBE As totalesAlmacen) As List(Of totalesAlmacen)
        Dim lista As New List(Of totalesAlmacen)
        Dim obj As New totalesAlmacen
        Dim almacenBL As New almacenBL

        'Dim con = (From t In HeliosData.totalesAlmacen _
        '           Group Join inv In HeliosData.InventarioMovimiento _
        '           On New With {t.idItem, t.idAlmacen} _
        '           Equals New With {inv.idItem, inv.idAlmacen} Into inv_join = Group _
        '           From inv In inv_join.DefaultIfEmpty() _
        '           Group Join prec In HeliosData.configuracionPrecioProducto _
        '           On New With {.Idproducto = t.idItem, t.idAlmacen} _
        '           Equals New With {prec.idproducto, prec.idAlmacen} Into prec_join = Group _
        '           From prec In prec_join.DefaultIfEmpty() _
        '           Group New With {t, inv, prec} By _
        '           t.idItem, t.descripcion, t.idAlmacen _
        '           Into g = Group _
        '           Where g.Max(Function(p) p.inv.fecha) > g.Max(Function(p) p.prec.fecha) And _
        '           CLng(idAlmacen) = productoBE.idAlmacen _
        '           Select _
        '           IdItem = CType(idItem, Int32?), _
        '           descripcion,
        '           idAlmacen = CType(idAlmacen, Int32?), _
        '           inventario = CType(g.Max(Function(p) p.inv.fecha), DateTime?),
        '           precio = CType(g.Max(Function(p) p.prec.fecha), DateTime?)).ToList

        Dim con = (From t In HeliosData.totalesAlmacen _
                 Group Join inv In HeliosData.InventarioMovimiento _
                 On New With {t.idItem} _
                 Equals New With {inv.idItem} Into inv_join = Group _
                 From inv In inv_join.DefaultIfEmpty() _
                 Group Join prec In HeliosData.configuracionPrecioProducto _
                 On New With {.Idproducto = t.idItem} _
                 Equals New With {prec.idproducto} Into prec_join = Group _
                 From prec In prec_join.DefaultIfEmpty() _
                 Group New With {t, inv, prec} By _
                 t.idItem, t.descripcion _
                 Into g = Group _
                 Where g.Max(Function(p) p.inv.fecha) > g.Max(Function(p) p.prec.fecha) _
                 Select _
                 IdItem = CType(idItem, Int32?), _
                 descripcion,
                 inventario = CType(g.Max(Function(p) p.inv.fecha), DateTime?),
                 precio = CType(g.Max(Function(p) p.prec.fecha), DateTime?)).ToList


        For Each i In con
            '     If (i.precio > i.invetario) Then
            obj = New totalesAlmacen
            obj.idItem = i.IdItem
            'obj.idAlmacen = i.idAlmacen
            'obj.NomAlmacen = almacenBL.GetUbicar_almacenPorID(i.idAlmacen).descripcionAlmacen
            obj.descripcion = i.descripcion
            obj.FechaUltimoPrecioKardex = i.inventario
            obj.FechaUltimoPrecioConfigurado = i.precio
            lista.Add(obj)
            '     End If
        Next
        Return lista
    End Function

    Public Function ObtenerAlertaDePrecioConteo(ByVal productoBE As totalesAlmacen) As Integer
        Dim lista As New List(Of totalesAlmacen)
        Dim obj As New totalesAlmacen

        'Dim con = (From t In HeliosData.totalesAlmacen _
        '           Group Join inv In HeliosData.InventarioMovimiento _
        '           On New With {t.idItem, t.idAlmacen} _
        '           Equals New With {inv.idItem, inv.idAlmacen} Into inv_join = Group _
        '           From inv In inv_join.DefaultIfEmpty() _
        '           Group Join prec In HeliosData.configuracionPrecioProducto _
        '           On New With {.Idproducto = t.idItem, t.idAlmacen} _
        '           Equals New With {prec.idproducto, prec.idAlmacen} Into prec_join = Group _
        '           From prec In prec_join.DefaultIfEmpty() _
        '           Group New With {t, inv, prec} By _
        '           t.idItem, t.descripcion, t.idAlmacen, t.idEstablecimiento _
        '           Into g = Group _
        '           Where g.Max(Function(p) p.inv.fecha) > g.Max(Function(p) p.prec.fecha) And _
        '           CLng(idEstablecimiento) = GEstableciento.IdEstablecimiento _
        '           Select IdItem = CType(idItem, Int32?), _
        '           descripcion,
        '           inventario = CType(g.Max(Function(p) p.inv.fecha), DateTime?),
        '           precio = CType(g.Max(Function(p) p.prec.fecha), DateTime?)).Count

        Dim con = (From t In HeliosData.totalesAlmacen _
                 Group Join inv In HeliosData.InventarioMovimiento _
                 On New With {t.idItem} _
                 Equals New With {inv.idItem} Into inv_join = Group _
                 From inv In inv_join.DefaultIfEmpty() _
                 Group Join prec In HeliosData.configuracionPrecioProducto _
                 On New With {.Idproducto = t.idItem} _
                 Equals New With {prec.idproducto} Into prec_join = Group _
                 From prec In prec_join.DefaultIfEmpty() _
                 Group New With {t, inv, prec} By _
                 t.idItem, t.descripcion, t.idAlmacen, t.idEstablecimiento _
                 Into g = Group _
                 Where g.Max(Function(p) p.inv.fecha) > g.Max(Function(p) p.prec.fecha) And _
                 CLng(idEstablecimiento) = GEstableciento.IdEstablecimiento _
                 Select IdItem = CType(idItem, Int32?), _
                 descripcion,
                 inventario = CType(g.Max(Function(p) p.inv.fecha), DateTime?),
                 precio = CType(g.Max(Function(p) p.prec.fecha), DateTime?)).Count


        Return con
    End Function

    Public Sub UpdateCantMaxMin(nTotAlm As totalesAlmacen)
        Dim objTotAlm As New totalesAlmacen
        Using ts As New TransactionScope
            objTotAlm = HeliosData.totalesAlmacen.Where(Function(o) o.idMovimiento = nTotAlm.idMovimiento And _
                                                           o.idItem = nTotAlm.idItem).First
            objTotAlm.cantidadMaxima = nTotAlm.cantidadMaxima
            objTotAlm.cantidadMinima = nTotAlm.cantidadMinima

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function UbicarPVxItem(ByVal intIdAlmacen As Integer, intIdItem As Integer) As listadoPrecios
        Dim objTablaDetalleBO As New listadoPrecios

        'Dim q = (From n In HeliosData.listadoPrecios _
        '       Where (n.fecha) = (From x In HeliosData.listadoPrecios _
        '                         Where _
        '                            x.idAlmacen = intIdAlmacen _
        '                            And x.idItem = intIdItem _
        '                            Select x.fecha).Max _
        '                            And n.idAlmacen = intIdAlmacen _
        '                            And n.idItem = intIdItem).FirstOrDefault


        'If Not IsNothing(q) Then
        '    objTablaDetalleBO = New listadoPrecios() With _
        '                               {
        '                                   .fecha = q.fecha, _
        '                                   .idEmpresa = q.idEmpresa, _
        '                                   .idEstablecimiento = q.idEstablecimiento, _
        '                                   .tipoConfiguracion = q.tipoConfiguracion, _
        '                                   .vcmenor = q.vcmenor,
        '                                   .vcmenorme = q.vcmenorme,
        '                                   .vcmayor = q.vcmayor,
        '                                   .vcmayorme = q.vcmayorme,
        '                                   .vcgranmayor = q.vcgranmayor,
        '                                   .vcgranmayorme = q.vcgranmayorme,
        '                                   .porcUtimenor = q.porcUtimenor, _
        '                                   .porcUtimayor = q.porcUtimayor, _
        '                                   .porcUtigranmayor = q.porcUtigranmayor, _
        '                                   .montoUtimenor = q.montoUtimenor, _
        '                                   .montoUtimayor = q.montoUtimayor, _
        '                                   .montoUtigranmayor = q.montoUtigranmayor, _
        '                                   .vvmenor = q.vvmenor, _
        '                                   .vvmayor = q.vvmayor, _
        '                                   .vvgranmayor = q.vvgranmayor, _
        '                                   .igvmenor = q.igvmenor, _
        '                                   .igvmayor = q.igvmayor, _
        '                                   .igvgranmayor = q.igvgranmayor, _
        '                                   .pvmenor = q.pvmenor, _
        '                                   .pvmayor = q.pvmayor, _
        '                                   .pvgranmayor = q.pvgranmayor, _
        '                                   .montoUtimenorme = q.montoUtimenorme, _
        '                                   .montoUtimayorme = q.montoUtimayorme, _
        '                                   .montoUtigranmayorme = q.montoUtigranmayorme, _
        '                                   .vvmenorme = q.vvmenorme, _
        '                                   .vvmayorme = q.vvmayorme, _
        '                                   .vvgranmayorme = q.vvgranmayorme, _
        '                                   .igvmenormeme = q.igvmenormeme, _
        '                                   .igvmayormeme = q.igvmayormeme, _
        '                                   .igvgranmayorme = q.igvgranmayorme, _
        '                                   .pvmenorme = q.pvmenorme, _
        '                                   .pvmayorme = q.pvmayorme, _
        '                                   .pvgranmayorme = q.pvgranmayorme,
        '                                   .autoCodigo = q.autoCodigo
        '                                }

        'End If

        'ListaProductos = (objTablaDetalleBO)
        Return objTablaDetalleBO
    End Function

    Public Function ObtenerCanastaDeVenta(ByVal intIdAlmacen As Integer, ByVal strTipoExistencia As String) As List(Of totalesAlmacen)
        Dim objTablaDetalleBO As New totalesAlmacen
        Dim ListaProductos As New List(Of totalesAlmacen)

        'Dim q = From n In HeliosData.listadoPrecios _
        '        Join t In HeliosData.totalesAlmacen _
        '                       On n.idAlmacen Equals t.idAlmacen _
        '                       And n.idItem Equals t.idItem _
        '                       Join item In HeliosData.detalleitems _
        '                        On t.idItem Equals item.codigodetalle _
        '                        Join tabpre In HeliosData.tabladetalle _
        '                        On item.presentacion Equals tabpre.codigoDetalle _
        '        Where (n.fecha) = (From x In HeliosData.listadoPrecios _
        '                       Join tt In HeliosData.totalesAlmacen _
        '                       On x.idAlmacen Equals tt.idAlmacen _
        '                       And x.idItem Equals tt.idItem _
        '                       Join item2 In HeliosData.detalleitems _
        '                        On tt.idItem Equals item2.codigodetalle _
        '                        Join tabpre2 In HeliosData.tabladetalle _
        '                        On item2.presentacion Equals tabpre2.codigoDetalle _
        '                        Where _
        '                            x.idAlmacen = intIdAlmacen _
        '                            And x.tipoExistencia = strTipoExistencia _
        '                            And tabpre2.idtabla = 21 _
        '                            Select x.fecha).Max() _
        '                            And n.idAlmacen = intIdAlmacen _
        '                            And n.tipoExistencia = strTipoExistencia _
        '                             And tabpre.idtabla = 21 _
        '                            Select New With {.idEstablecimiento = t.idEstablecimiento,
        '            .idItem = t.idItem, _
        '                         .cuenta = item.cuenta,
        '                                             .TipoExistencia = item.tipoExistencia,
        '                        .descripcionItem = item.descripcionItem,
        '                         .UnidadMedida = item.unidad1,
        '                         .presentacion = item.presentacion,
        '                         .nombrePresentacion = tabpre.descripcion,
        '                         .Gravado = item.origenProducto,
        '                         .cantidadDisponible = t.cantidad,
        '                         .ImporteDisp = t.importeSoles,
        '                         .ImporteDispme = t.importeDolares,
        '                         .Modalidad = n.tipoConfiguracion, _
        '                         .PrecioVenta = n.precioVentaMN, _
        '                         .ImportemnDscto = n.montoDsctounitMenorMN, _
        '                         .ImportemnDsctoME = n.montoDsctounitMenorME, _
        '                         .VentaFinalmn = n.precioVentaFinalMenorMN, _
        '                         .VentaFinalmnME = n.precioVentaFinalMenorME, _
        '                         .ImportemyDscto = n.montoDsctounitMayorMN, _
        '                         .ImportemyDsctoME = n.montoDsctounitMayorME, _
        '                         .VentaFinalmy = n.precioVentaFinalMayorMN, _
        '                         .VentaFinalmyME = n.precioVentaFinalMayorME, _
        '                         .ImportegmyDscto = n.montoDsctounitGMayorMN, _
        '                         .ImportegmyDsctoME = n.montoDsctounitGMayorME, _
        '                         .VentaFinalgmy = n.precioVentaFinalGMayorMN, _
        '                         .VentaFinalgmyME = n.precioVentaFinalGMayorME, _
        '                         .DetalleMenor = n.detalleMenor, _
        '                         .DetalleMayor = n.detalleMayor, _
        '                         .DetalleGMayor = n.detalleGMayor _
        '                        }

        'For Each obj In q
        '    objTablaDetalleBO = New totalesAlmacen() With _
        '                                {
        '                                    .idEstablecimiento = obj.idEstablecimiento,
        '                                    .idItem = obj.idItem, _
        '                                    .tipoExistencia = obj.TipoExistencia,
        '                                    .CuentaContable = obj.cuenta,
        '                                    .descripcion = obj.descripcionItem,
        '                                    .unidadMedida = obj.UnidadMedida,
        '                                    .Presentacion = obj.presentacion,
        '                                    .NombrePresentacion = obj.nombrePresentacion,
        '                                    .origenRecaudo = obj.Gravado,
        '                                    .cantidad = obj.cantidadDisponible,
        '                                    .importeSoles = obj.ImporteDisp,
        '                                    .importeDolares = obj.ImporteDispme,
        '                                    .tipoConfiguracion = obj.Modalidad, _
        '                                    .precioVentaMN = obj.PrecioVenta, _
        '                                    .montoDsctounitMenorMN = obj.ImportemnDscto, _
        '                                    .montoDsctounitMenorME = obj.ImportemnDsctoME, _
        '                                    .precioVentaFinalMenorMN = obj.VentaFinalmn, _
        '                                    .precioVentaFinalMenorME = obj.VentaFinalmnME, _
        '                                    .montoDsctounitMayorMN = obj.ImportemyDscto, _
        '                                    .montoDsctounitMayorME = obj.ImportemyDsctoME, _
        '                                    .precioVentaFinalMayorMN = obj.VentaFinalmy, _
        '                                    .precioVentaFinalMayorME = obj.VentaFinalmyME, _
        '                                    .montoDsctounitGMayorMN = obj.ImportegmyDscto, _
        '                                    .montoDsctounitGMayorME = obj.ImportegmyDsctoME, _
        '                                    .precioVentaFinalGMayorMN = obj.VentaFinalgmy, _
        '                                    .precioVentaFinalGMayorME = obj.VentaFinalgmyME, _
        '                                    .detalleMenor = obj.DetalleMenor, _
        '                                    .detalleMayor = obj.DetalleMayor, _
        '                                    .detalleGMayor = obj.DetalleGMayor _
        '                                 }
        '    ListaProductos.Add(objTablaDetalleBO)
        'Next

        Return ListaProductos
    End Function

    Public Function ObtenerCanastaDeVentaPorProducto(ByVal intIdAlmacen As Integer, ByVal strTipoExistencia As String,
                                                     strFiltroProducto As String) As List(Of totalesAlmacen)
        Dim objTablaDetalleBO As New totalesAlmacen
        Dim ListaProductos As New List(Of totalesAlmacen)

        'Dim q = From n In HeliosData.listadoPrecios _
        '        Join t In HeliosData.totalesAlmacen _
        '                       On n.idAlmacen Equals t.idAlmacen _
        '                       And n.idItem Equals t.idItem _
        '                       Join item In HeliosData.detalleitems _
        '                        On t.idItem Equals item.codigodetalle _
        '                        Join tabpre In HeliosData.tabladetalle _
        '                        On item.presentacion Equals tabpre.codigoDetalle _
        '        Where (n.fecha) = (From x In HeliosData.listadoPrecios _
        '                       Join tt In HeliosData.totalesAlmacen _
        '                       On x.idAlmacen Equals tt.idAlmacen _
        '                       And x.idItem Equals tt.idItem _
        '                       Join item2 In HeliosData.detalleitems _
        '                        On tt.idItem Equals item2.codigodetalle _
        '                        Join tabpre2 In HeliosData.tabladetalle _
        '                        On item2.presentacion Equals tabpre2.codigoDetalle _
        '                        Where _
        '                            x.idAlmacen = intIdAlmacen _
        '                            And x.tipoExistencia = strTipoExistencia _
        '                            And tabpre2.idtabla = 21 _
        '                            And item2.descripcionItem.StartsWith(strFiltroProducto) _
        '                            Select x.fecha).Max() _
        '                            And n.idAlmacen = intIdAlmacen _
        '                            And n.tipoExistencia = strTipoExistencia _
        '                             And tabpre.idtabla = 21 _
        '                             And item.descripcionItem.StartsWith(strFiltroProducto) _
        '                            Select New With {.idEstablecimiento = t.idEstablecimiento,
        '            .idItem = t.idItem, _
        '                         .cuenta = item.cuenta,
        '                                             .TipoExistencia = item.tipoExistencia,
        '                        .descripcionItem = item.descripcionItem,
        '                         .UnidadMedida = item.unidad1,
        '                         .presentacion = item.presentacion,
        '                         .nombrePresentacion = tabpre.descripcion,
        '                         .Gravado = item.origenProducto,
        '                         .cantidadDisponible = t.cantidad,
        '                         .ImporteDisp = t.importeSoles,
        '                         .ImporteDispme = t.importeDolares,
        '                         .Modalidad = n.tipoConfiguracion, _
        '                         .PrecioVenta = n.precioVentaMN, _
        '                         .ImportemnDscto = n.montoDsctounitMenorMN, _
        '                         .ImportemnDsctoME = n.montoDsctounitMenorME, _
        '                         .VentaFinalmn = n.precioVentaFinalMenorMN, _
        '                         .VentaFinalmnME = n.precioVentaFinalMenorME, _
        '                         .ImportemyDscto = n.montoDsctounitMayorMN, _
        '                         .ImportemyDsctoME = n.montoDsctounitMayorME, _
        '                         .VentaFinalmy = n.precioVentaFinalMayorMN, _
        '                         .VentaFinalmyME = n.precioVentaFinalMayorME, _
        '                         .ImportegmyDscto = n.montoDsctounitGMayorMN, _
        '                         .ImportegmyDsctoME = n.montoDsctounitGMayorME, _
        '                         .VentaFinalgmy = n.precioVentaFinalGMayorMN, _
        '                         .VentaFinalgmyME = n.precioVentaFinalGMayorME, _
        '                         .DetalleMenor = n.detalleMenor, _
        '                         .DetalleMayor = n.detalleMayor, _
        '                         .DetalleGMayor = n.detalleGMayor _
        '                        }

        'For Each obj In q
        '    objTablaDetalleBO = New totalesAlmacen() With _
        '                                {
        '                                    .idEstablecimiento = obj.idEstablecimiento,
        '                                    .idItem = obj.idItem, _
        '                                    .tipoExistencia = obj.TipoExistencia,
        '                                    .CuentaContable = obj.cuenta,
        '                                    .descripcion = obj.descripcionItem,
        '                                    .unidadMedida = obj.UnidadMedida,
        '                                    .Presentacion = obj.presentacion,
        '                                    .NombrePresentacion = obj.nombrePresentacion,
        '                                    .origenRecaudo = obj.Gravado,
        '                                    .cantidad = obj.cantidadDisponible,
        '                                    .importeSoles = obj.ImporteDisp,
        '                                    .importeDolares = obj.ImporteDispme,
        '                                    .tipoConfiguracion = obj.Modalidad, _
        '                                    .precioVentaMN = obj.PrecioVenta, _
        '                                    .montoDsctounitMenorMN = obj.ImportemnDscto, _
        '                                    .montoDsctounitMenorME = obj.ImportemnDsctoME, _
        '                                    .precioVentaFinalMenorMN = obj.VentaFinalmn, _
        '                                    .precioVentaFinalMenorME = obj.VentaFinalmnME, _
        '                                    .montoDsctounitMayorMN = obj.ImportemyDscto, _
        '                                    .montoDsctounitMayorME = obj.ImportemyDsctoME, _
        '                                    .precioVentaFinalMayorMN = obj.VentaFinalmy, _
        '                                    .precioVentaFinalMayorME = obj.VentaFinalmyME, _
        '                                    .montoDsctounitGMayorMN = obj.ImportegmyDscto, _
        '                                    .montoDsctounitGMayorME = obj.ImportegmyDsctoME, _
        '                                    .precioVentaFinalGMayorMN = obj.VentaFinalgmy, _
        '                                    .precioVentaFinalGMayorME = obj.VentaFinalgmyME, _
        '                                    .detalleMenor = obj.DetalleMenor, _
        '                                    .detalleMayor = obj.DetalleMayor, _
        '                                    .detalleGMayor = obj.DetalleGMayor _
        '                                 }
        '    ListaProductos.Add(objTablaDetalleBO)
        'Next

        Return ListaProductos
    End Function


    Public Function ObtenerCanastaDeVentaPorProducto2(ByVal intIdAlmacen As Integer, ByVal strTipoExistencia As String,
                                                     strFiltroProducto As String) As List(Of totalesAlmacen)
        Dim objTablaDetalleBO As New totalesAlmacen
        Dim ListaProductos As New List(Of totalesAlmacen)

        Dim q = From t In HeliosData.totalesAlmacen _
                               Join item In HeliosData.detalleitems _
                                On t.idItem Equals item.codigodetalle _
                                Join tabpre In HeliosData.tabladetalle _
                                On item.presentacion Equals tabpre.codigoDetalle _
                                Where t.idAlmacen = intIdAlmacen _
                                And t.tipoExistencia = strTipoExistencia _
                                And tabpre.idtabla = 21 _
                                And item.descripcionItem.StartsWith(strFiltroProducto) _
                                Take 18 _
                                Select New With {.idEstablecimiento = t.idEstablecimiento,
                                                     .idAlmacen = t.idAlmacen,
                                                     .idItem = t.idItem, _
                                 .cuenta = item.cuenta,
                                                     .TipoExistencia = item.tipoExistencia,
                                .descripcionItem = item.descripcionItem,
                                 .UnidadMedida = item.unidad1,
                                 .presentacion = item.presentacion,
                                 .nombrePresentacion = tabpre.descripcion,
                                 .Gravado = item.origenProducto,
                                 .cantidadDisponible = t.cantidad,
                                 .ImporteDisp = t.importeSoles,
                                 .ImporteDispme = t.importeDolares
                                }

        For Each obj In q
            objTablaDetalleBO = New totalesAlmacen() With _
                                        {
                                            .idEstablecimiento = obj.idEstablecimiento,
                                            .idAlmacen = obj.idAlmacen,
                                            .idItem = obj.idItem, _
                                            .tipoExistencia = obj.TipoExistencia,
                                            .CuentaContable = obj.cuenta,
                                            .descripcion = obj.descripcionItem,
                                            .unidadMedida = obj.UnidadMedida,
                                            .Presentacion = obj.presentacion,
                                            .NombrePresentacion = obj.nombrePresentacion,
                                            .origenRecaudo = obj.Gravado,
                                            .cantidad = obj.cantidadDisponible,
                                            .importeSoles = obj.ImporteDisp,
                                            .importeDolares = obj.ImporteDispme}
            ListaProductos.Add(objTablaDetalleBO)
        Next

        Return ListaProductos
    End Function

    Public Sub SaveSIngle(ByVal objLiquidacionEO As totalesAlmacen)
        Dim objLiquidacion As New totalesAlmacen()
        Using ts As New TransactionScope()

            objLiquidacion.idEmpresa = objLiquidacionEO.idEmpresa
            objLiquidacion.idEstablecimiento = objLiquidacionEO.idEstablecimiento
            objLiquidacion.idAlmacen = objLiquidacionEO.idAlmacen
            objLiquidacion.origenRecaudo = objLiquidacionEO.origenRecaudo
            objLiquidacion.tipoCambio = objLiquidacionEO.tipoCambio
            objLiquidacion.tipoExistencia = objLiquidacionEO.tipoExistencia
            objLiquidacion.idItem = objLiquidacionEO.idItem
            objLiquidacion.descripcion = objLiquidacionEO.descripcion
            objLiquidacion.idUnidad = objLiquidacionEO.idUnidad
            objLiquidacion.unidadMedida = objLiquidacionEO.unidadMedida

            objLiquidacion.cantidad = objLiquidacionEO.cantidad
            objLiquidacion.precioUnitarioCompra = objLiquidacionEO.precioUnitarioCompra
            objLiquidacion.importeSoles = objLiquidacionEO.importeSoles

            objLiquidacion.importeDolares = objLiquidacionEO.importeDolares
            objLiquidacion.montoIsc = objLiquidacionEO.montoIsc
            objLiquidacion.montoIscUS = objLiquidacionEO.montoIscUS

            HeliosData.totalesAlmacen.Add(objLiquidacion)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub

    Public Sub UpdateSingle(ByVal objLiquidacionEO As totalesAlmacen, ByVal intCodigoDetalle As Integer)
        Dim objNuevo As New totalesAlmacen()

        Using ts As New TransactionScope()

            objNuevo = HeliosData.totalesAlmacen.Where(Function(o) o.idAlmacen = objLiquidacionEO.idAlmacen And _
                                                           o.origenRecaudo = objLiquidacionEO.origenRecaudo And _
                                                           o.idItem = objLiquidacionEO.idItem).FirstOrDefault


            With objNuevo

                Select Case objLiquidacionEO.Modulo

                    Case "N"


                        objNuevo.cantidad = objNuevo.cantidad + objLiquidacionEO.cantidad
                        objNuevo.precioUnitarioCompra = objNuevo.precioUnitarioCompra + objLiquidacionEO.precioUnitarioCompra
                        objNuevo.importeSoles = objNuevo.importeSoles + objLiquidacionEO.importeSoles

                        objNuevo.importeDolares = objNuevo.importeDolares + objLiquidacionEO.importeDolares
                        '     objNuevo.montoIsc = objNuevo.montoIsc + objLiquidacionEO.montoIsc
                        '  objNuevo.montoIscUS = objNuevo.montoIscUS + objLiquidacionEO.montoIscUS


                    Case "E"
                        Dim cVarianzaCan As Decimal = 0
                        Dim cVarianzaPU As Decimal = 0
                        Dim cVarianzaImporte As Decimal = 0
                        Dim cVarianzaImporteUS As Decimal = 0
                        Dim cVarianzaIsc As Decimal = 0
                        Dim cVarianzaIscUS As Decimal = 0


                        Dim objBackDoc = (From k In HeliosData.documentocompradetalle _
                                         Where k.secuencia = intCodigoDetalle).First

                        'otros reportes
                        cVarianzaCan = (objBackDoc.monto1 - objLiquidacionEO.cantidad) * -1
                        objNuevo.cantidad = (cVarianzaCan + objNuevo.cantidad)

                        cVarianzaPU = (objBackDoc.precioUnitario - objLiquidacionEO.precioUnitarioCompra) * -1
                        objNuevo.precioUnitarioCompra = (cVarianzaPU + objNuevo.precioUnitarioCompra)

                        cVarianzaImporte = (objBackDoc.importe - objLiquidacionEO.importeSoles) * -1
                        objNuevo.importeSoles = (cVarianzaImporte + objNuevo.importeSoles)

                        cVarianzaImporteUS = (objBackDoc.importeUS - objLiquidacionEO.importeDolares) * -1
                        objNuevo.importeDolares = (cVarianzaImporteUS + objNuevo.importeDolares)

                        cVarianzaIsc = (objBackDoc.montoIsc - objLiquidacionEO.montoIsc) * -1
                        objNuevo.montoIsc = (cVarianzaIsc + objNuevo.montoIsc)

                        cVarianzaIsc = (objBackDoc.montoIsc - objLiquidacionEO.montoIsc) * -1
                        objNuevo.montoIsc = (cVarianzaIsc + objNuevo.montoIsc)

                        cVarianzaIscUS = (objBackDoc.montoIscUS - objLiquidacionEO.montoIscUS) * -1
                        objNuevo.montoIscUS = (cVarianzaIscUS + objNuevo.montoIscUS)

                End Select


            End With
            'HeliosData.ObjectStateManager.GetObjectStateEntry(objNuevo).State.ToString()
            HeliosData.SaveChanges()
            ts.Complete()

        End Using

    End Sub

    Public Sub UpdateSingle2(ByVal i As totalesAlmacen)
        Dim objNuevo As New totalesAlmacen()

        Using ts As New TransactionScope()

            objNuevo = HeliosData.totalesAlmacen.Where(Function(o) o.idAlmacen = i.idAlmacen And _
                                                           o.origenRecaudo = i.origenRecaudo And _
                                                           o.idItem = i.idItem).FirstOrDefault

            If Not IsNothing(objNuevo) Then
                objNuevo.cantidad = objNuevo.cantidad + i.cantidad
                'objNuevo.precioUnitarioCompra = objNuevo.precioUnitarioCompra + i.precioUnitarioCompra
                objNuevo.importeSoles = objNuevo.importeSoles + i.importeSoles
                objNuevo.importeDolares = objNuevo.importeDolares + i.importeDolares
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub

    Public Function UpdateCostoVentaKardex(ByVal i As totalesAlmacen) As totalesAlmacen
        Dim objNuevo As New totalesAlmacen()
        Dim ULTIMO_item As New totalesAlmacen
        Using ts As New TransactionScope()
            Dim colcostoMN As Decimal = 0
            Dim colCantidad As Decimal = 0
            Dim colcostoME As Decimal = 0
            Dim ultimoPMmn As Decimal = 0
            Dim ultimoPMme As Decimal = 0


            '                                               o.idEstablecimiento = i.idEstablecimiento And _

            objNuevo = HeliosData.totalesAlmacen.Where(Function(o) o.idAlmacen = i.idAlmacen And _
                                                           o.idItem = i.idItem).FirstOrDefault

            If Not IsNothing(objNuevo) Then
                colcostoMN = 0
                colcostoME = 0


                ultimoPMmn = objNuevo.UltimoPMmn
                ultimoPMme = objNuevo.UltimoPMme

                colcostoMN = i.cantidad * ultimoPMmn
                colcostoME = i.cantidad * ultimoPMme

                objNuevo.cantidad = objNuevo.cantidad + i.cantidad
                'objNuevo.precioUnitarioCompra = objNuevo.precioUnitarioCompra + i.precioUnitarioCompra
                objNuevo.importeSoles = objNuevo.importeSoles + colcostoMN ' i.importeSoles
                objNuevo.importeDolares = objNuevo.importeDolares + colcostoME 'i.importeDolares

                ULTIMO_item = New totalesAlmacen
                ULTIMO_item.precioVentaMN = colcostoMN
                ULTIMO_item.precioVentaUS = colcostoME

                If ULTIMO_item.precioVentaMN < 0 Then
                    ULTIMO_item.precioVentaMN = ULTIMO_item.precioVentaMN * -1
                End If

                If ULTIMO_item.precioVentaUS < 0 Then
                    ULTIMO_item.precioVentaUS = ULTIMO_item.precioVentaUS * -1
                End If

            Else
                'CREAR NUEVO ITEM EN TOTALES ALMACEN


            End If


            HeliosData.SaveChanges()
            ts.Complete()

            Return ULTIMO_item
        End Using

    End Function

    Public Sub UpdateCostoVentaAnulacion(ByVal i As totalesAlmacen)
        Dim objNuevo As New totalesAlmacen()
        Dim ULTIMO_item As New totalesAlmacen
        Using ts As New TransactionScope()
            Dim colcostoMN As Decimal = 0
            Dim colCantidad As Decimal = 0
            Dim colcostoME As Decimal = 0
            Dim ultimoPMmn As Decimal = 0
            Dim ultimoPMme As Decimal = 0

            objNuevo = HeliosData.totalesAlmacen.Where(Function(o) o.idEmpresa = i.idEmpresa And _
                                                           o.idEstablecimiento = i.idEstablecimiento And _
                                                           o.idAlmacen = i.idAlmacen And _
                                                           o.origenRecaudo = i.origenRecaudo And _
                                                           o.idItem = i.idItem).FirstOrDefault

            If Not IsNothing(objNuevo) Then
                'colcostoMN = 0
                'colcostoME = 0


                'ultimoPMmn = objNuevo.UltimoPMmn
                'ultimoPMme = objNuevo.UltimoPMme

                'colcostoMN = i.cantidad * ultimoPMmn
                'colcostoME = i.cantidad * ultimoPMme

                objNuevo.cantidad = objNuevo.cantidad + i.cantidad
                'objNuevo.precioUnitarioCompra = objNuevo.precioUnitarioCompra + i.precioUnitarioCompra
                objNuevo.importeSoles = objNuevo.importeSoles + i.importeSoles
                objNuevo.importeDolares = objNuevo.importeDolares + i.importeDolares


            Else
                'CREAR NUEVO ITEM EN TOTALES ALMACEN

            End If


            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub


    Public Sub UpdateStock(ByVal i As totalesAlmacen)
        Dim objNuevo As New totalesAlmacen()
        Dim t As New totalesAlmacen
        Dim colcostoMN As Decimal = 0
        Dim colCantidad As Decimal = 0
        Dim colcostoME As Decimal = 0
        Dim ultimoPMmn As Decimal = 0
        Dim ultimoPMme As Decimal = 0

        Using ts As New TransactionScope()

            objNuevo = HeliosData.totalesAlmacen.Where(Function(o) o.idAlmacen = i.idAlmacen And _
                                                           o.origenRecaudo = i.origenRecaudo And _
                                                           o.idItem = i.idItem).FirstOrDefault

            If Not IsNothing(objNuevo) Then ' si existe el producto

                colcostoMN = 0
                colcostoME = 0

                ultimoPMmn = objNuevo.UltimoPMmn
                ultimoPMme = objNuevo.UltimoPMme

                objNuevo.cantidad = objNuevo.cantidad + i.cantidad

                If ultimoPMmn > 0 Then
                    colcostoMN = i.cantidad * ultimoPMmn
                    objNuevo.importeSoles = objNuevo.importeSoles + colcostoMN ' i.importeSoles

                Else
                    objNuevo.importeSoles = objNuevo.importeSoles + i.importeSoles
                End If

                If ultimoPMme > 0 Then
                    colcostoME = i.cantidad * ultimoPMme
                    objNuevo.importeDolares = objNuevo.importeDolares + colcostoME 'i.importeDolares
                Else
                    objNuevo.importeDolares = objNuevo.importeDolares + i.importeDolares
                End If


            Else ' si es uno nuevo
                t = New totalesAlmacen
                t.idEmpresa = i.idEmpresa
                t.idEstablecimiento = i.idEstablecimiento
                t.idAlmacen = i.idAlmacen  ' almacen de DESTINO
                t.origenRecaudo = i.origenRecaudo
                t.idItem = i.idItem
                t.descripcion = i.descripcion
                t.tipoExistencia = i.tipoExistencia
                t.tipoCambio = 0
                t.idUnidad = i.idUnidad
                t.cantidad = i.cantidad
                t.importeSoles = i.importeSoles
                t.importeDolares = i.importeDolares
                t.usuarioActualizacion = i.usuarioActualizacion
                t.fechaActualizacion = i.fechaActualizacion
                InsertSingle(t)
            End If


            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub

    Public Sub UpdateStockOtrasEntradas(ByVal i As totalesAlmacen)
        Dim objNuevo As New totalesAlmacen()
        Dim t As New totalesAlmacen


        Using ts As New TransactionScope()

            objNuevo = HeliosData.totalesAlmacen.Where(Function(o) o.idAlmacen = i.idAlmacen And _
                                                           o.origenRecaudo = i.origenRecaudo And _
                                                           o.idItem = i.idItem).FirstOrDefault

            If Not IsNothing(objNuevo) Then ' si existe el producto

                objNuevo.cantidad = objNuevo.cantidad + i.cantidad
                objNuevo.importeSoles = objNuevo.importeSoles + i.importeSoles
                objNuevo.importeDolares = objNuevo.importeDolares + i.importeDolares


            Else ' si es uno nuevo
                t = New totalesAlmacen
                t.idEmpresa = i.idEmpresa
                t.idEstablecimiento = i.idEstablecimiento
                t.idAlmacen = i.idAlmacen  ' almacen de DESTINO
                t.origenRecaudo = i.origenRecaudo
                t.idItem = i.idItem
                t.descripcion = i.descripcion
                t.tipoExistencia = i.tipoExistencia
                t.tipoCambio = 0
                t.idUnidad = i.idUnidad
                t.cantidad = i.cantidad
                t.importeSoles = i.importeSoles
                t.importeDolares = i.importeDolares
                t.status = StatusArticulo.Activo
                t.usuarioActualizacion = i.usuarioActualizacion
                t.fechaActualizacion = i.fechaActualizacion
                InsertSingle(t)
            End If


            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub


    'Public Function UpdateTotalesVentas(ByVal i As totalesAlmacen) As List(Of totalesAlmacen)
    '    Dim objNuevo As New totalesAlmacen()
    '    Dim listaTotalesAlmacen As New List(Of totalesAlmacen)
    '    Dim colcostoMN As Decimal = 0
    '    Dim colCantidad As Decimal = 0
    '    Dim colcostoME As Decimal = 0
    '    Dim ultimoPMmn As Decimal = 0
    '    Dim ultimoPMme As Decimal = 0
    '    Using ts As New TransactionScope()

    '        objNuevo = HeliosData.totalesAlmacen.Where(Function(o) o.idAlmacen = i.idAlmacen And _
    '                                                       o.origenRecaudo = i.origenRecaudo And _
    '                                                       o.idItem = i.idItem).FirstOrDefault

    '        If (objNuevo.cantidad >= (i.cantidad * -1)) Then

    '            colcostoMN = 0
    '            colcostoME = 0

    '            ultimoPMmn = objNuevo.UltimoPMmn
    '            ultimoPMme = objNuevo.UltimoPMme

    '            colcostoMN = i.cantidad * ultimoPMmn
    '            colcostoME = i.cantidad * ultimoPMme


    '            objNuevo.cantidad = objNuevo.cantidad + i.cantidad
    '            'objNuevo.precioUnitarioCompra = objNuevo.precioUnitarioCompra + i.precioUnitarioCompra
    '            objNuevo.importeSoles = objNuevo.importeSoles + colcostoMN ' i.importeSoles
    '            objNuevo.importeDolares = objNuevo.importeDolares + colcostoME 'i.importeDolares

    '            'HeliosData.SaveChanges()
    '            'ts.Complete()
    '        ElseIf (objNuevo.cantidad < (i.cantidad * -1)) Then
    '            listaTotalesAlmacen.Add(objNuevo)
    '        End If


    '        HeliosData.SaveChanges()
    '        ts.Complete()
    '    End Using
    '    Return listaTotalesAlmacen
    'End Function

    Public Function UpdateTotalesVentas(ByVal i As totalesAlmacen) As List(Of totalesAlmacen)
        Dim objNuevo As New totalesAlmacen()
        Dim listaTotalesAlmacen As New List(Of totalesAlmacen)
        Dim colcostoMN As Decimal = 0
        Dim colCantidad As Decimal = 0
        Dim colcostoME As Decimal = 0
        Dim ultimoPMmn As Decimal = 0
        Dim ultimoPMme As Decimal = 0
        Using ts As New TransactionScope()

            objNuevo = HeliosData.totalesAlmacen.Where(Function(o) o.idAlmacen = i.idAlmacen And _
                                                           o.origenRecaudo = i.origenRecaudo And _
                                                           o.idItem = i.idItem).FirstOrDefault

            If (objNuevo.cantidad >= (i.cantidad * -1)) Then

                colcostoMN = 0
                colcostoME = 0

                ultimoPMmn = objNuevo.UltimoPMmn
                ultimoPMme = objNuevo.UltimoPMme

                colcostoMN = i.cantidad * ultimoPMmn
                colcostoME = i.cantidad * ultimoPMme


                objNuevo.cantidad = objNuevo.cantidad + i.cantidad
                objNuevo.importeSoles = objNuevo.importeSoles + colcostoMN ' i.importeSoles
                objNuevo.importeDolares = objNuevo.importeDolares + colcostoME 'i.importeDolares

                'HeliosData.SaveChanges()
                'ts.Complete()
            ElseIf (objNuevo.cantidad < (i.cantidad * -1)) Then
                listaTotalesAlmacen.Add(objNuevo)
            End If


            HeliosData.SaveChanges()
            ts.Complete()
        End Using
        Return listaTotalesAlmacen
    End Function

    Public Function UpdateTrasnferenciaMercaderia(ByVal i As totalesAlmacen) As List(Of totalesAlmacen)
        Dim objNuevo As New totalesAlmacen()
        Dim listaTotalesAlmacen As New List(Of totalesAlmacen)
        Dim colCantidad As Decimal = 0
        Dim ultimoPMmn As Decimal = 0
        Dim ultimoPMme As Decimal = 0
        Using ts As New TransactionScope()

            objNuevo = HeliosData.totalesAlmacen.Where(Function(o) o.idEmpresa = i.idEmpresa And _
                                                           o.idEstablecimiento = i.idEstablecimiento And _
                                                           o.idAlmacen = i.idAlmacen And _
                                                           o.origenRecaudo = i.origenRecaudo And _
                                                           o.idItem = i.idItem).FirstOrDefault




            objNuevo.cantidad = objNuevo.cantidad + i.cantidad
            objNuevo.importeSoles = objNuevo.importeSoles + i.importeSoles
            objNuevo.importeDolares = objNuevo.importeDolares + i.importeDolares

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
        Return listaTotalesAlmacen
    End Function


    'Public Sub ActualizarItemsTransferencia(ByVal i As totalesAlmacen)
    '    Dim objNuevo As New totalesAlmacen()
    '    Dim t As New totalesAlmacen
    '    Dim colcostoMN As Decimal = 0
    '    Dim colCantidad As Decimal = 0
    '    Dim colcostoME As Decimal = 0
    '    Dim ultimoPMmn As Decimal = 0
    '    Dim ultimoPMme As Decimal = 0

    '    Using ts As New TransactionScope()
    '        colcostoMN = 0
    '        colcostoME = 0

    '        'SE CONSULTA EL SI EL ITEM EXISTEN EN EL ALMACEN
    '        'objNuevo = HeliosData.totalesAlmacen.Where(Function(o) o.idEmpresa = i.idEmpresa And _
    '        '                                               o.idEstablecimiento = i.idEstablecimiento And _
    '        '                                               o.idAlmacen = i.idAlmacen And _
    '        '                                               o.origenRecaudo = i.origenRecaudo And _
    '        '                                               o.idItem = i.idItem).FirstOrDefault

    '        objNuevo = HeliosData.totalesAlmacen.Where(Function(o) o.idAlmacen = i.idAlmacen And _
    '                                                      o.origenRecaudo = i.origenRecaudo And _
    '                                                      o.idItem = i.idItem).FirstOrDefault

    '        If Not IsNothing(objNuevo) Then ' SE ACTULIZA LOS MONTOS DEL ITEM RECUPERADO

    '            'ultimoPMmn = objNuevo.UltimoPMmn
    '            'ultimoPMme = objNuevo.UltimoPMme

    '            'colcostoMN = i.cantidad * ultimoPMmn
    '            'colcostoME = i.cantidad * ultimoPMme

    '            objNuevo.cantidad = objNuevo.cantidad + i.cantidad
    '            'objNuevo.precioUnitarioCompra = objNuevo.precioUnitarioCompra + i.precioUnitarioCompra
    '            objNuevo.importeSoles = objNuevo.importeSoles + i.importeSoles 'colcostoMN
    '            objNuevo.importeDolares = objNuevo.importeDolares + i.importeDolares 'colcostoME 

    '            'If objNuevo.importeSoles > 0 Then
    '            '    objNuevo.importeSoles = Math.Round(CDec(objNuevo.importeSoles), 2)
    '            'End If

    '            'If objNuevo.importeDolares > 0 Then
    '            '    objNuevo.importeDolares = Math.Round(CDec(objNuevo.importeDolares), 2)
    '            'End If

    '        Else ' SE REGISTRA EL NUEVO PRODUCTO EN EL ALMACEN SELECCIONADO
    '            t = New totalesAlmacen
    '            t.idEmpresa = i.idEmpresa
    '            t.idEstablecimiento = i.idEstablecimiento
    '            t.idAlmacen = i.idAlmacen  ' almacen de DESTINO
    '            t.origenRecaudo = i.origenRecaudo
    '            t.idItem = i.idItem
    '            t.descripcion = i.descripcion
    '            t.tipoExistencia = i.tipoExistencia
    '            t.tipoCambio = 0
    '            t.idUnidad = i.idUnidad
    '            t.cantidad = i.cantidad
    '            t.importeSoles = i.importeSoles
    '            t.importeDolares = i.importeDolares
    '            t.usuarioActualizacion = i.usuarioActualizacion
    '            t.fechaActualizacion = i.fechaActualizacion
    '            InsertSingle(t)
    '        End If
    '        HeliosData.SaveChanges()
    '        ts.Complete()
    '    End Using

    'End Sub

    Public Sub ActualizarItemsTransferencia(ByVal i As totalesAlmacen)
        Dim objNuevo As New totalesAlmacen()
        Dim t As New totalesAlmacen
        Dim colcostoMN As Decimal = 0
        Dim colCantidad As Decimal = 0
        Dim colcostoME As Decimal = 0
        Dim ultimoPMmn As Decimal = 0
        Dim ultimoPMme As Decimal = 0

        Using ts As New TransactionScope()
            colcostoMN = 0
            colcostoME = 0

            'SE CONSULTA EL SI EL ITEM EXISTEN EN EL ALMACEN
            'objNuevo = HeliosData.totalesAlmacen.Where(Function(o) o.idEmpresa = i.idEmpresa And _
            '                                               o.idEstablecimiento = i.idEstablecimiento And _
            '                                               o.idAlmacen = i.idAlmacen And _
            '                                               o.origenRecaudo = i.origenRecaudo And _
            '                                               o.idItem = i.idItem).FirstOrDefault

            objNuevo = HeliosData.totalesAlmacen.Where(Function(o) o.idAlmacen = i.idAlmacen And
                                                          o.origenRecaudo = i.origenRecaudo And
                                                          o.idItem = i.idItem).FirstOrDefault

            If Not IsNothing(objNuevo) Then ' SE ACTULIZA LOS MONTOS DEL ITEM RECUPERADO

                'ultimoPMmn = objNuevo.UltimoPMmn
                'ultimoPMme = objNuevo.UltimoPMme

                'colcostoMN = i.cantidad * ultimoPMmn
                'colcostoME = i.cantidad * ultimoPMme

                'objNuevo.cantidad = objNuevo.cantidad + i.cantidad
                ''objNuevo.precioUnitarioCompra = objNuevo.precioUnitarioCompra + i.precioUnitarioCompra
                'objNuevo.importeSoles = objNuevo.importeSoles + i.importeSoles 'colcostoMN
                'objNuevo.importeDolares = objNuevo.importeDolares + i.importeDolares 'colcostoME 

                'If objNuevo.importeSoles > 0 Then
                '    objNuevo.importeSoles = Math.Round(CDec(objNuevo.importeSoles), 2)
                'End If

                'If objNuevo.importeDolares > 0 Then
                '    objNuevo.importeDolares = Math.Round(CDec(objNuevo.importeDolares), 2)
                'End If

            Else ' SE REGISTRA EL NUEVO PRODUCTO EN EL ALMACEN SELECCIONADO
                t = New totalesAlmacen
                t.idEmpresa = i.idEmpresa
                t.idEstablecimiento = i.idEstablecimiento
                t.idAlmacen = i.idAlmacen  ' almacen de DESTINO
                t.origenRecaudo = i.origenRecaudo
                t.idItem = i.idItem
                t.descripcion = i.descripcion
                t.tipoExistencia = i.tipoExistencia
                t.tipoCambio = TmpTipoCambio
                t.idUnidad = i.idUnidad
                t.cantidad = i.cantidad
                t.importeSoles = i.importeSoles
                t.importeDolares = i.importeDolares
                t.usuarioActualizacion = i.usuarioActualizacion
                t.fechaActualizacion = i.fechaActualizacion

                HeliosData.totalesAlmacen.Add(t)
                'HeliosData.SaveChanges()
                'ts.Complete()

                'InsertSingle(t)
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub


    Public Sub UpdateCierreInventario(ByVal i As totalesAlmacen)
        Dim objNuevo As New totalesAlmacen()

        Using ts As New TransactionScope()
            objNuevo = HeliosData.totalesAlmacen.Where(Function(o) o.idEmpresa = i.idEmpresa And _
                                                           o.idEstablecimiento = i.idEstablecimiento And _
                                                           o.idAlmacen = i.idAlmacen And _
                                                           o.origenRecaudo = i.origenRecaudo And _
                                                           o.idItem = i.idItem).FirstOrDefault

            'EDICION DEL ITEM IDENTIFICADO
            objNuevo.cantidad = i.cantidad
            objNuevo.importeSoles = i.importeSoles
            objNuevo.importeDolares = i.importeDolares

            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub

    Public Sub SaveTotales(ByVal objListaDetalle As totalesAlmacen, IntIddocumentoCompraDetalle As Integer)
        Dim objTotal As New totalesAlmacen()
        Dim CONSULTA As New totalesAlmacen()
        Try
            Using ts As New TransactionScope()
                With objListaDetalle

                    CONSULTA = (From n In HeliosData.totalesAlmacen _
                                        Where n.idEmpresa = .idEmpresa _
                                        And n.idEstablecimiento = .idEstablecimiento _
                                        And n.idAlmacen = .idAlmacen _
                                        And n.origenRecaudo = .origenRecaudo _
                                        And n.idItem = .idItem).FirstOrDefault

                    objTotal = New totalesAlmacen()
                    objTotal.idEmpresa = .idEmpresa
                    objTotal.idEstablecimiento = .idEstablecimiento
                    objTotal.idAlmacen = .idAlmacen
                    objTotal.origenRecaudo = .origenRecaudo
                    objTotal.tipoCambio = .tipoCambio
                    objTotal.tipoExistencia = .tipoExistencia
                    objTotal.idItem = .idItem
                    objTotal.descripcion = .descripcion
                    objTotal.idUnidad = .idUnidad
                    objTotal.unidadMedida = .unidadMedida


                    If IsNothing(CONSULTA) Then 'no existe agregar nuevo

                        objTotal.cantidad = .cantidad
                        objTotal.precioUnitarioCompra = .precioUnitarioCompra
                        objTotal.importeSoles = .importeSoles

                        objTotal.importeDolares = .importeDolares
                        objTotal.montoIsc = .montoIsc
                        objTotal.montoIscUS = .montoIscUS

                        SaveSIngle(objTotal)
                    Else ' editar existente

                        objTotal.cantidad = .cantidad
                        objTotal.precioUnitarioCompra = .precioUnitarioCompra
                        objTotal.importeSoles = .importeSoles

                        objTotal.importeDolares = .importeDolares
                        objTotal.montoIsc = .montoIsc
                        objTotal.montoIscUS = .montoIscUS

                        UpdateSingle(objTotal, IntIddocumentoCompraDetalle)
                    End If

                End With
                HeliosData.SaveChanges()
                ts.Complete()

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function DeleteTotalesAlmacen(ByVal objDeleteLiquidacion As List(Of totalesAlmacen)) As Boolean
        Dim objNuevo As New totalesAlmacen()
        Try
            Using ts As New TransactionScope()

                For Each i In objDeleteLiquidacion
                    Dim xSecuenci As Integer = i.SecuenciaDetalle
                    Dim objBackDoc = (From k In HeliosData.documentocompradetalle _
                                         Where k.secuencia = xSecuenci).First


                    Dim xEmpresa As String = i.idEmpresa
                    Dim xEstableimiento As Integer = i.idEstablecimiento
                    Dim xAlmacen As Integer = i.idAlmacen
                    Dim xGravado As String = i.origenRecaudo
                    Dim xIdItem As Integer = i.idItem

                    objNuevo = HeliosData.totalesAlmacen.Where(Function(o) o.idEmpresa = xEmpresa And _
                                                           o.idEstablecimiento = xEstableimiento And _
                                                           o.idAlmacen = xAlmacen And _
                                                           o.origenRecaudo = xGravado And _
                                                           o.idItem = xIdItem).FirstOrDefault


                    If Not IsNothing(objNuevo) Then
                        objNuevo.cantidad = objNuevo.cantidad - objBackDoc.monto1
                        objNuevo.precioUnitarioCompra = objNuevo.precioUnitarioCompra - objBackDoc.precioUnitario

                        If objBackDoc.bonificacion = "S" Then
                            objNuevo.importeSoles = objNuevo.importeSoles - objBackDoc.importe
                            objNuevo.importeDolares = objNuevo.importeDolares - objBackDoc.importeUS

                            objNuevo.montoIsc = objNuevo.montoIsc - objBackDoc.montoIsc
                            objNuevo.montoIscUS = objNuevo.montoIscUS - objBackDoc.montoIscUS
                        Else
                            Select Case i.TipoDoc
                                Case "03", "02"
                                    objNuevo.importeSoles = objNuevo.importeSoles - objBackDoc.importe
                                    objNuevo.importeDolares = objNuevo.importeDolares - objBackDoc.importeUS
                                Case Else
                                    objNuevo.importeSoles = objNuevo.importeSoles - objBackDoc.montokardex
                                    objNuevo.importeDolares = objNuevo.importeDolares - objBackDoc.montokardexUS
                            End Select

                            objNuevo.montoIsc = objNuevo.montoIsc - objBackDoc.montoIsc
                            objNuevo.montoIscUS = objNuevo.montoIscUS - objBackDoc.montoIscUS
                        End If



                        'HeliosData.ObjectStateManager.GetObjectStateEntry(objNuevo).State.ToString()
                    End If

                Next


                HeliosData.SaveChanges()
                ts.Complete()
                Return True

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function DeleteSaldoAportes(ByVal objDeleteLiquidacion As List(Of totalesAlmacen)) As Boolean
        Dim objNuevo As New totalesAlmacen()
        Try
            Using ts As New TransactionScope()

                For Each i In objDeleteLiquidacion
                    Dim xSecuenci As Integer = i.SecuenciaDetalle
                    Dim objBackDoc = (From k In HeliosData.saldoInicioDetalle _
                                         Where k.secuencia = xSecuenci).First


                    Dim xEmpresa As String = i.idEmpresa
                    Dim xEstableimiento As Integer = i.idEstablecimiento
                    Dim xAlmacen As Integer = i.idAlmacen
                    Dim xGravado As String = i.origenRecaudo
                    Dim xIdItem As Integer = i.idItem

                    objNuevo = HeliosData.totalesAlmacen.Where(Function(o) o.idEmpresa = xEmpresa And _
                                                           o.idEstablecimiento = xEstableimiento And _
                                                           o.idAlmacen = xAlmacen And _
                                                           o.origenRecaudo = xGravado And _
                                                           o.idItem = xIdItem).FirstOrDefault


                    If Not IsNothing(objNuevo) Then
                        objNuevo.cantidad = objNuevo.cantidad - objBackDoc.cantidad
                        objNuevo.precioUnitarioCompra = objNuevo.precioUnitarioCompra - objBackDoc.precioUnitario

                        objNuevo.importeSoles = objNuevo.importeSoles - objBackDoc.importe
                        objNuevo.importeDolares = objNuevo.importeDolares - objBackDoc.importeUS
                    End If
                    'HeliosData.ObjectStateManager.GetObjectStateEntry(objNuevo).State.ToString()
                Next


                HeliosData.SaveChanges()
                ts.Complete()
                Return True

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DeleteTotalesAlmacenOE(ByVal objDeleteLiquidacion As List(Of totalesAlmacen)) As Boolean
        Dim objNuevo As New totalesAlmacen()
        Try
            Using ts As New TransactionScope()

                For Each i In objDeleteLiquidacion
                    Dim xSecuenci As Integer = i.SecuenciaDetalle
                    Dim objBackDoc = (From k In HeliosData.documentocompradetalle _
                                         Where k.secuencia = xSecuenci).First


                    Dim xEmpresa As String = i.idEmpresa
                    Dim xEstableimiento As Integer = i.idEstablecimiento
                    Dim xAlmacen As Integer = i.idAlmacen
                    Dim xGravado As String = i.origenRecaudo
                    Dim xIdItem As Integer = i.idItem

                    objNuevo = HeliosData.totalesAlmacen.Where(Function(o) o.idEmpresa = xEmpresa And _
                                                           o.idEstablecimiento = xEstableimiento And _
                                                           o.idAlmacen = xAlmacen And _
                                                           o.origenRecaudo = xGravado And _
                                                           o.idItem = xIdItem).FirstOrDefault


                    If Not IsNothing(objNuevo) Then
                        objNuevo.cantidad = objNuevo.cantidad - objBackDoc.monto1
                        '  objNuevo.precioUnitarioCompra = objNuevo.precioUnitarioCompra - objBackDoc.precioUnitario

                        objNuevo.importeSoles = objNuevo.importeSoles - objBackDoc.importe
                        objNuevo.importeDolares = objNuevo.importeDolares - objBackDoc.importeUS


                        'HeliosData.ObjectStateManager.GetObjectStateEntry(objNuevo).State.ToString()
                    End If
                Next
                HeliosData.SaveChanges()
                ts.Complete()
                Return True

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Método para eliminar elmentos de otras salidas tabla documento compra
    ''' </summary>
    ''' <param name="objDeleteLiquidacion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DeleteTotalesAlmacenOSalidas(ByVal objDeleteLiquidacion As List(Of totalesAlmacen)) As Boolean
        Dim objNuevo As New totalesAlmacen()
        Try
            Using ts As New TransactionScope()

                For Each i In objDeleteLiquidacion
                    Dim xSecuenci As Integer = i.SecuenciaDetalle
                    Dim objBackDoc = (From k In HeliosData.documentocompradetalle _
                                         Where k.secuencia = xSecuenci).First


                    Dim xEmpresa As String = i.idEmpresa
                    Dim xEstableimiento As Integer = i.idEstablecimiento
                    Dim xAlmacen As Integer = i.idAlmacen
                    Dim xGravado As String = i.origenRecaudo
                    Dim xIdItem As Integer = i.idItem

                    objNuevo = HeliosData.totalesAlmacen.Where(Function(o) o.idEmpresa = xEmpresa And _
                                                           o.idEstablecimiento = xEstableimiento And _
                                                           o.idAlmacen = xAlmacen And _
                                                           o.origenRecaudo = xGravado And _
                                                           o.idItem = xIdItem).FirstOrDefault


                    If Not IsNothing(objNuevo) Then
                        objNuevo.cantidad = objNuevo.cantidad + objBackDoc.monto1
                        '      objNuevo.precioUnitarioCompra = objNuevo.precioUnitarioCompra + objBackDoc.precioUnitario

                        objNuevo.importeSoles = objNuevo.importeSoles + objBackDoc.importe
                        objNuevo.importeDolares = objNuevo.importeDolares + objBackDoc.importeUS


                        'HeliosData.ObjectStateManager.GetObjectStateEntry(objNuevo).State.ToString()
                    End If
                Next
                HeliosData.SaveChanges()
                ts.Complete()
                Return True

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function EliminarTransferenciaAlmacenOrigen(ByVal ListaOrigen As List(Of totalesAlmacen)) As Boolean
        Dim objNuevo As New totalesAlmacen()
        Try
            Using ts As New TransactionScope()
                For Each i In ListaOrigen
                    Dim xSecuenci As Integer = i.SecuenciaDetalle
                    Dim objBackDoc = (From k In HeliosData.documentocompradetalle _
                                         Where k.secuencia = xSecuenci).First


                    Dim xEmpresa As String = i.idEmpresa
                    Dim xEstableimiento As Integer = i.idEstablecimiento
                    Dim xAlmacen As Integer = i.idAlmacen
                    Dim xGravado As String = i.origenRecaudo
                    Dim xIdItem As Integer = i.idItem

                    objNuevo = HeliosData.totalesAlmacen.Where(Function(o) o.idEmpresa = xEmpresa And _
                                                           o.idEstablecimiento = xEstableimiento And _
                                                           o.idAlmacen = xAlmacen And _
                                                           o.origenRecaudo = xGravado And _
                                                           o.idItem = xIdItem).FirstOrDefault


                    If Not IsNothing(objNuevo) Then
                        objNuevo.cantidad = objNuevo.cantidad + objBackDoc.monto1
                        objNuevo.precioUnitarioCompra = objNuevo.precioUnitarioCompra + objBackDoc.precioUnitario

                        objNuevo.importeSoles = objNuevo.importeSoles + objBackDoc.importe
                        objNuevo.importeDolares = objNuevo.importeDolares + objBackDoc.importeUS


                        'HeliosData.ObjectStateManager.GetObjectStateEntry(objNuevo).State.ToString()
                    End If
                Next
                HeliosData.SaveChanges()
                ts.Complete()
                Return True

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function EliminarTransferenciaAlmacenDestino(ByVal ListaOrigen As List(Of totalesAlmacen)) As Boolean
        Dim objNuevo As New totalesAlmacen()
        Try
            Using ts As New TransactionScope()
                For Each i In ListaOrigen
                    Dim xSecuenci As Integer = i.SecuenciaDetalle
                    Dim objBackDoc = (From k In HeliosData.documentocompradetalle _
                                         Where k.secuencia = xSecuenci).First


                    Dim xEmpresa As String = i.idEmpresa
                    Dim xEstableimiento As Integer = i.idEstablecimiento
                    Dim xAlmacen As Integer = i.idAlmacen
                    Dim xGravado As String = i.origenRecaudo
                    Dim xIdItem As Integer = i.idItem

                    objNuevo = HeliosData.totalesAlmacen.Where(Function(o) o.idEmpresa = xEmpresa And _
                                                           o.idEstablecimiento = xEstableimiento And _
                                                           o.idAlmacen = xAlmacen And _
                                                           o.origenRecaudo = xGravado And _
                                                           o.idItem = xIdItem).FirstOrDefault


                    If Not IsNothing(objNuevo) Then
                        objNuevo.cantidad = objNuevo.cantidad - objBackDoc.monto1
                        objNuevo.precioUnitarioCompra = objNuevo.precioUnitarioCompra - objBackDoc.precioUnitario

                        objNuevo.importeSoles = objNuevo.importeSoles - objBackDoc.importe
                        objNuevo.importeDolares = objNuevo.importeDolares - objBackDoc.importeUS


                        'HeliosData.ObjectStateManager.GetObjectStateEntry(objNuevo).State.ToString()
                    End If
                Next
                HeliosData.SaveChanges()
                ts.Complete()
                Return True

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DeleteTotalesAlmacenOS(ByVal objDeleteLiquidacion As List(Of totalesAlmacen)) As Boolean
        Dim objNuevo As New totalesAlmacen()
        Try
            Using ts As New TransactionScope()

                For Each i In objDeleteLiquidacion
                    Dim xSecuenci As Integer = i.SecuenciaDetalle
                    Dim objBackDoc = (From k In HeliosData.documentoventaAbarrotesDet _
                                         Where k.secuencia = xSecuenci).First


                    Dim xEmpresa As String = i.idEmpresa
                    Dim xEstableimiento As Integer = i.idEstablecimiento
                    Dim xAlmacen As Integer = i.idAlmacen
                    Dim xGravado As String = i.origenRecaudo
                    Dim xIdItem As Integer = i.idItem

                    objNuevo = HeliosData.totalesAlmacen.Where(Function(o) o.idEmpresa = xEmpresa And _
                                                           o.idEstablecimiento = xEstableimiento And _
                                                           o.idAlmacen = xAlmacen And _
                                                           o.origenRecaudo = xGravado And _
                                                           o.idItem = xIdItem).FirstOrDefault


                    If Not IsNothing(objNuevo) Then
                        objNuevo.cantidad = objNuevo.cantidad + objBackDoc.monto1
                        objNuevo.precioUnitarioCompra = objNuevo.precioUnitarioCompra + objBackDoc.precioUnitario

                        objNuevo.importeSoles = objNuevo.importeSoles + objBackDoc.importeMN
                        objNuevo.importeDolares = objNuevo.importeDolares + objBackDoc.importeME

                        'HeliosData.ObjectStateManager.GetObjectStateEntry(objNuevo).State.ToString()
                    End If
                Next
                HeliosData.SaveChanges()
                ts.Complete()
                Return True

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DeleteTotalesAlmacenNotas(ByVal objDeleteLiquidacion As List(Of totalesAlmacen)) As Boolean
        Dim objNuevo As New totalesAlmacen()
        Try
            Using ts As New TransactionScope()

                For Each i In objDeleteLiquidacion
                    Dim xSecuenci As Integer = i.SecuenciaDetalle
                    Dim objBackDoc = (From k In HeliosData.documentocompradetalle _
                                         Where k.secuencia = xSecuenci).First


                    Dim xEmpresa As String = i.idEmpresa
                    Dim xEstableimiento As Integer = i.idEstablecimiento
                    Dim xAlmacen As Integer = i.idAlmacen
                    Dim xGravado As String = i.origenRecaudo
                    Dim xIdItem As Integer = i.idItem

                    objNuevo = HeliosData.totalesAlmacen.Where(Function(o) o.idEmpresa = xEmpresa And _
                                                           o.idEstablecimiento = xEstableimiento And _
                                                           o.idAlmacen = xAlmacen And _
                                                           o.origenRecaudo = xGravado And _
                                                           o.idItem = xIdItem).FirstOrDefault


                    If Not IsNothing(objNuevo) Then
                        objNuevo.cantidad = objNuevo.cantidad + objBackDoc.monto1
                        objNuevo.precioUnitarioCompra = objNuevo.precioUnitarioCompra + objBackDoc.precioUnitario
                        objNuevo.importeSoles = objNuevo.importeSoles + objBackDoc.montokardex
                        objNuevo.importeDolares = objNuevo.importeDolares + objBackDoc.montokardexUS
                        objNuevo.montoIsc = objNuevo.montoIsc + objBackDoc.montoIsc
                        objNuevo.montoIscUS = objNuevo.montoIscUS + objBackDoc.montoIscUS
                    End If

                    'HeliosData.ObjectStateManager.GetObjectStateEntry(objNuevo).State.ToString()


                Next


                HeliosData.SaveChanges()
                ts.Complete()
                Return True

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DeleteTotalesAlmacenNotasBOF(ByVal objDeleteLiquidacion As List(Of totalesAlmacen)) As Boolean
        Dim objNuevo As New totalesAlmacen()
        Try
            Using ts As New TransactionScope()

                For Each i In objDeleteLiquidacion
                    Dim xSecuenci As Integer = i.SecuenciaDetalle
                    Dim objBackDoc = (From k In HeliosData.documentocompradetalle _
                                         Where k.secuencia = xSecuenci).First


                    Dim xEmpresa As String = i.idEmpresa
                    Dim xEstableimiento As Integer = i.idEstablecimiento
                    Dim xAlmacen As Integer = i.idAlmacen
                    Dim xGravado As String = i.origenRecaudo
                    Dim xIdItem As Integer = i.idItem

                    objNuevo = HeliosData.totalesAlmacen.Where(Function(o) o.idEmpresa = xEmpresa And _
                                                           o.idEstablecimiento = xEstableimiento And _
                                                           o.idAlmacen = xAlmacen And _
                                                           o.origenRecaudo = xGravado And _
                                                           o.idItem = xIdItem).FirstOrDefault


                    If Not IsNothing(objNuevo) Then
                        objNuevo.cantidad = objNuevo.cantidad - objBackDoc.monto1
                        objNuevo.importeSoles = objNuevo.importeSoles - objBackDoc.montokardex
                        objNuevo.importeDolares = objNuevo.importeDolares - objBackDoc.montokardexUS

                    End If

                    'HeliosData.ObjectStateManager.GetObjectStateEntry(objNuevo).State.ToString()


                Next


                HeliosData.SaveChanges()
                ts.Complete()
                Return True

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DeleteTotalesAlmacenNotasBOF2(ByVal objDeleteLiquidacion As List(Of totalesAlmacen)) As Boolean
        Dim objNuevo As New totalesAlmacen()
        Try
            Using ts As New TransactionScope()

                For Each i In objDeleteLiquidacion
                    Dim xSecuenci As Integer = i.SecuenciaDetalle
                    Dim objBackDoc = (From k In HeliosData.documentocompradetalle _
                                         Where k.secuencia = xSecuenci).First


                    Dim xEmpresa As String = i.idEmpresa
                    Dim xEstableimiento As Integer = i.idEstablecimiento
                    Dim xAlmacen As Integer = i.idAlmacen
                    Dim xGravado As String = i.origenRecaudo
                    Dim xIdItem As Integer = i.idItem

                    objNuevo = HeliosData.totalesAlmacen.Where(Function(o) o.idEmpresa = xEmpresa And _
                                                           o.idEstablecimiento = xEstableimiento And _
                                                           o.idAlmacen = xAlmacen And _
                                                           o.origenRecaudo = xGravado And _
                                                           o.idItem = xIdItem).FirstOrDefault


                    If Not IsNothing(objNuevo) Then
                        If objBackDoc.monto1 > 0 And objBackDoc.montokardex > 0 Then
                            objNuevo.cantidad = objNuevo.cantidad - objBackDoc.monto1
                            objNuevo.importeSoles = objNuevo.importeSoles - objBackDoc.montokardex
                            objNuevo.importeDolares = objNuevo.importeDolares - objBackDoc.montokardexUS
                        ElseIf objBackDoc.monto1 > 0 And objBackDoc.montokardex = 0 Then
                            objNuevo.cantidad = objNuevo.cantidad - objBackDoc.monto1
                        ElseIf objBackDoc.monto1 = 0 And objBackDoc.montokardex > 0 Then
                            objNuevo.importeSoles = objNuevo.importeSoles + objBackDoc.montokardex
                            objNuevo.importeDolares = objNuevo.importeDolares + objBackDoc.montokardexUS
                        End If
                    End If

                    'HeliosData.ObjectStateManager.GetObjectStateEntry(objNuevo).State.ToString()


                Next


                HeliosData.SaveChanges()
                ts.Complete()
                Return True

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DeleteTotalesAlmacenNotasFullPadre(ByVal docNotasDetalle As List(Of documentocompradetalle), documentoCabecera As documentocompra) As Boolean
        Dim objNuevo As New totalesAlmacen()
        Try
            Using ts As New TransactionScope()

                For Each i In docNotasDetalle

                    Dim xSecuenci As Integer = i.secuencia
                    Dim objBackDoc = (From k In HeliosData.documentocompradetalle _
                                         Where k.secuencia = xSecuenci).First


                    Dim xEmpresa As String = documentoCabecera.idEmpresa
                    Dim xEstableimiento As Integer = documentoCabecera.idCentroCosto
                    Dim xAlmacen As Integer = i.almacenRef
                    Dim xGravado As String = i.destino
                    Dim xIdItem As Integer = i.idItem

                    objNuevo = HeliosData.totalesAlmacen.Where(Function(o) o.idEmpresa = xEmpresa And _
                                                           o.idEstablecimiento = xEstableimiento And _
                                                           o.idAlmacen = xAlmacen And _
                                                           o.origenRecaudo = xGravado And _
                                                           o.idItem = xIdItem).FirstOrDefault


                    If Not IsNothing(objNuevo) Then

                        Select Case documentoCabecera.sustentado
                            Case Notas_Credito.DEV_EXISTENCIA

                                objNuevo.cantidad = objNuevo.cantidad + objBackDoc.monto1
                                objNuevo.importeSoles = objNuevo.importeSoles + objBackDoc.montokardex
                                objNuevo.importeDolares = objNuevo.importeDolares + objBackDoc.montokardexUS


                            Case Notas_Credito.DR_REDUCCION_COSTOS

                                objNuevo.importeSoles = objNuevo.importeSoles + objBackDoc.montokardex
                                objNuevo.importeDolares = objNuevo.importeDolares + objBackDoc.montokardexUS


                            Case Notas_Credito.DR_BENEFICIO

                            Case Notas_Credito.ERR_PRECIO

                                objNuevo.importeSoles = objNuevo.importeSoles + objBackDoc.montokardex
                                objNuevo.importeDolares = objNuevo.importeDolares + objBackDoc.montokardexUS


                            Case Notas_Credito.ERR_CANTIDAD

                                objNuevo.cantidad = objNuevo.cantidad + objBackDoc.monto1

                            Case Notas_Credito.BOF_REDUC_COSTO_IGUAL_COMPRA

                                objNuevo.cantidad = objNuevo.cantidad + ((objBackDoc.monto1 * -1))

                            Case Notas_Credito.BOF_REDUC_COSTO_DISTINTO_COMPRA

                            Case Notas_Credito.BOF_BENEFICIO_TERCEROS

                        End Select


                    End If

                    'HeliosData.ObjectStateManager.GetObjectStateEntry(objNuevo).State.ToString()
                Next
                HeliosData.SaveChanges()
                ts.Complete()
                Return True

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DeleteTotalesAlmacenNotasFullPadreVenta(ByVal docNotasDetalle As List(Of documentoventaAbarrotesDet), documentoCabecera As documentoventaAbarrotes) As Boolean
        Dim objNuevo As New totalesAlmacen()
        Try
            Using ts As New TransactionScope()

                For Each i In docNotasDetalle

                    Dim xSecuenci As Integer = i.secuencia
                    Dim objBackDoc = (From k In HeliosData.documentocompradetalle _
                                         Where k.secuencia = xSecuenci).First


                    Dim xEmpresa As String = documentoCabecera.idEmpresa
                    Dim xEstableimiento As Integer = documentoCabecera.idEstablecimiento
                    Dim xAlmacen As Integer = i.idAlmacenOrigen
                    Dim xGravado As String = i.destino
                    Dim xIdItem As Integer = i.idItem

                    objNuevo = HeliosData.totalesAlmacen.Where(Function(o) o.idEmpresa = xEmpresa And _
                                                           o.idEstablecimiento = xEstableimiento And _
                                                           o.idAlmacen = xAlmacen And _
                                                           o.origenRecaudo = xGravado And _
                                                           o.idItem = xIdItem).FirstOrDefault


                    If Not IsNothing(objNuevo) Then

                        Select Case documentoCabecera.sustentado
                            Case Notas_Credito.DEV_EXISTENCIA

                                objNuevo.cantidad = objNuevo.cantidad + objBackDoc.monto1
                                objNuevo.importeSoles = objNuevo.importeSoles + objBackDoc.montokardex
                                objNuevo.importeDolares = objNuevo.importeDolares + objBackDoc.montokardexUS


                            Case Notas_Credito.DR_REDUCCION_COSTOS

                                objNuevo.importeSoles = objNuevo.importeSoles + objBackDoc.montokardex
                                objNuevo.importeDolares = objNuevo.importeDolares + objBackDoc.montokardexUS


                            Case Notas_Credito.DR_BENEFICIO

                            Case Notas_Credito.ERR_PRECIO

                                objNuevo.importeSoles = objNuevo.importeSoles + objBackDoc.montokardex
                                objNuevo.importeDolares = objNuevo.importeDolares + objBackDoc.montokardexUS


                            Case Notas_Credito.ERR_CANTIDAD

                                objNuevo.cantidad = objNuevo.cantidad + objBackDoc.monto1

                            Case Notas_Credito.BOF_REDUC_COSTO_IGUAL_COMPRA

                                objNuevo.cantidad = objNuevo.cantidad + ((objBackDoc.monto1 * -1))

                            Case Notas_Credito.BOF_REDUC_COSTO_DISTINTO_COMPRA

                            Case Notas_Credito.BOF_BENEFICIO_TERCEROS

                        End Select


                    End If

                    'HeliosData.ObjectStateManager.GetObjectStateEntry(objNuevo).State.ToString()
                Next
                HeliosData.SaveChanges()
                ts.Complete()
                Return True

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DeleteTotalesAlmacenNotasDEBITO(ByVal objDeleteLiquidacion As List(Of totalesAlmacen)) As Boolean
        Dim objNuevo As New totalesAlmacen()
        Try
            Using ts As New TransactionScope()

                For Each i In objDeleteLiquidacion
                    Dim xSecuenci As Integer = i.SecuenciaDetalle
                    Dim objBackDoc = (From k In HeliosData.documentocompradetalle _
                                         Where k.secuencia = xSecuenci).First


                    Dim xEmpresa As String = i.idEmpresa
                    Dim xEstableimiento As Integer = i.idEstablecimiento
                    Dim xAlmacen As Integer = i.idAlmacen
                    Dim xGravado As String = i.origenRecaudo
                    Dim xIdItem As Integer = i.idItem

                    objNuevo = HeliosData.totalesAlmacen.Where(Function(o) o.idEmpresa = xEmpresa And _
                                                           o.idEstablecimiento = xEstableimiento And _
                                                           o.idAlmacen = xAlmacen And _
                                                           o.origenRecaudo = xGravado And _
                                                           o.idItem = xIdItem).FirstOrDefault


                    If Not IsNothing(objNuevo) Then
                        '  objNuevo.cantidad = objNuevo.cantidad + objBackDoc.monto1
                        objNuevo.precioUnitarioCompra = objNuevo.precioUnitarioCompra - objBackDoc.precioUnitario
                        objNuevo.importeSoles = objNuevo.importeSoles - objBackDoc.montokardex
                        objNuevo.importeDolares = objNuevo.importeDolares - objBackDoc.montokardexUS
                        objNuevo.montoIsc = objNuevo.montoIsc - objBackDoc.montoIsc
                        objNuevo.montoIscUS = objNuevo.montoIscUS - objBackDoc.montoIscUS
                    End If

                    'HeliosData.ObjectStateManager.GetObjectStateEntry(objNuevo).State.ToString()


                Next


                HeliosData.SaveChanges()
                ts.Complete()
                Return True

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DeleteTotalesAlmacenNotasDEBITOFullPadre(ByVal docNotasDetalle As List(Of documentocompradetalle), documentoCabecera As documentocompra) As Boolean
        Dim objNuevo As New totalesAlmacen()
        Try
            Using ts As New TransactionScope()

                For Each i In docNotasDetalle
                    Dim xSecuenci As Integer = i.secuencia
                    Dim objBackDoc = (From k In HeliosData.documentocompradetalle _
                                         Where k.secuencia = xSecuenci).First


                    Dim xEmpresa As String = documentoCabecera.idEmpresa
                    Dim xEstableimiento As Integer = documentoCabecera.idCentroCosto
                    Dim xAlmacen As Integer = i.almacenRef
                    Dim xGravado As String = i.destino
                    Dim xIdItem As Integer = i.idItem

                    objNuevo = HeliosData.totalesAlmacen.Where(Function(o) o.idEmpresa = xEmpresa And _
                                                           o.idEstablecimiento = xEstableimiento And _
                                                           o.idAlmacen = xAlmacen And _
                                                           o.origenRecaudo = xGravado And _
                                                           o.idItem = xIdItem).FirstOrDefault


                    If Not IsNothing(objNuevo) Then
                        '  objNuevo.cantidad = objNuevo.cantidad + objBackDoc.monto1
                        objNuevo.precioUnitarioCompra = objNuevo.precioUnitarioCompra - objBackDoc.precioUnitario
                        objNuevo.importeSoles = objNuevo.importeSoles - objBackDoc.montokardex
                        objNuevo.importeDolares = objNuevo.importeDolares - objBackDoc.montokardexUS
                        objNuevo.montoIsc = objNuevo.montoIsc - objBackDoc.montoIsc
                        objNuevo.montoIscUS = objNuevo.montoIscUS - objBackDoc.montoIscUS
                    End If
                    'HeliosData.ObjectStateManager.GetObjectStateEntry(objNuevo).State.ToString()
                Next
                HeliosData.SaveChanges()
                ts.Complete()
                Return True
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DeleteTotalesAlmacenNotasDEBITOFullPadreVenta(ByVal docNotasDetalle As List(Of documentoventaAbarrotesDet), documentoCabecera As documentoventaAbarrotes) As Boolean
        Dim objNuevo As New totalesAlmacen()
        Try
            Using ts As New TransactionScope()

                For Each i In docNotasDetalle
                    Dim xSecuenci As Integer = i.secuencia
                    Dim objBackDoc = (From k In HeliosData.documentocompradetalle _
                                         Where k.secuencia = xSecuenci).First


                    Dim xEmpresa As String = documentoCabecera.idEmpresa
                    Dim xEstableimiento As Integer = documentoCabecera.idEstablecimiento
                    Dim xAlmacen As Integer = i.idAlmacenOrigen
                    Dim xGravado As String = i.destino
                    Dim xIdItem As Integer = i.idItem

                    objNuevo = HeliosData.totalesAlmacen.Where(Function(o) o.idEmpresa = xEmpresa And _
                                                           o.idEstablecimiento = xEstableimiento And _
                                                           o.idAlmacen = xAlmacen And _
                                                           o.origenRecaudo = xGravado And _
                                                           o.idItem = xIdItem).FirstOrDefault


                    If Not IsNothing(objNuevo) Then
                        '  objNuevo.cantidad = objNuevo.cantidad + objBackDoc.monto1
                        objNuevo.precioUnitarioCompra = objNuevo.precioUnitarioCompra - objBackDoc.precioUnitario
                        objNuevo.importeSoles = objNuevo.importeSoles - objBackDoc.montokardex
                        objNuevo.importeDolares = objNuevo.importeDolares - objBackDoc.montokardexUS
                        objNuevo.montoIsc = objNuevo.montoIsc - objBackDoc.montoIsc
                        objNuevo.montoIscUS = objNuevo.montoIscUS - objBackDoc.montoIscUS
                    End If
                    'HeliosData.ObjectStateManager.GetObjectStateEntry(objNuevo).State.ToString()
                Next
                HeliosData.SaveChanges()
                ts.Complete()
                Return True
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DeleteTotalesAlmacenVentaTicket(ByVal objDeleteLiquidacion As List(Of totalesAlmacen)) As Boolean
        Dim objNuevo As New totalesAlmacen()
        Try
            Using ts As New TransactionScope()

                For Each i In objDeleteLiquidacion
                    Dim xSecuenci As Integer = i.SecuenciaDetalle
                    Dim objBackDoc = (From k In HeliosData.documentoventaAbarrotesDet _
                                         Where k.secuencia = xSecuenci).First


                    Dim xEmpresa As String = i.idEmpresa
                    Dim xEstableimiento As Integer = i.idEstablecimiento
                    Dim xAlmacen As Integer = i.idAlmacen
                    Dim xGravado As String = i.origenRecaudo
                    Dim xIdItem As Integer = i.idItem

                    objNuevo = HeliosData.totalesAlmacen.Where(Function(o) o.idEmpresa = xEmpresa And _
                                                           o.idEstablecimiento = xEstableimiento And _
                                                           o.idAlmacen = xAlmacen And _
                                                           o.origenRecaudo = xGravado And _
                                                           o.idItem = xIdItem).FirstOrDefault


                    If Not IsNothing(objNuevo) Then
                        objNuevo.cantidad = objNuevo.cantidad + objBackDoc.monto1
                        objNuevo.precioUnitarioCompra = objNuevo.precioUnitarioCompra + objBackDoc.precioUnitario

                        objNuevo.importeSoles = objNuevo.importeSoles + objBackDoc.salidaCostoMN
                        objNuevo.importeDolares = objNuevo.importeDolares + objBackDoc.salidaCostoME

                        objNuevo.montoIsc = objNuevo.montoIsc + objBackDoc.montoIsc
                        objNuevo.montoIscUS = objNuevo.montoIscUS + objBackDoc.montoIscUS

                        'HeliosData.ObjectStateManager.GetObjectStateEntry(objNuevo).State.ToString()
                    End If

                Next


                HeliosData.SaveChanges()
                ts.Complete()
                Return True

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DeleteTotalesAlmacenVentaTicketXitem(ByVal objEliminar As totalesAlmacen) As Boolean
        Dim objNuevo As New totalesAlmacen()
        Try
            Using ts As New TransactionScope()
                With objEliminar
                    Dim xSecuenci As Integer = .SecuenciaDetalle
                    Dim objBackDoc = (From k In HeliosData.documentoventaAbarrotesDet _
                                         Where k.secuencia = xSecuenci).First


                    Dim xEmpresa As String = .idEmpresa
                    Dim xEstableimiento As Integer = .idEstablecimiento
                    Dim xAlmacen As Integer = .idAlmacen
                    Dim xGravado As String = .origenRecaudo
                    Dim xIdItem As Integer = .idItem

                    objNuevo = HeliosData.totalesAlmacen.Where(Function(o) o.idEmpresa = xEmpresa And _
                                                           o.idEstablecimiento = xEstableimiento And _
                                                           o.idAlmacen = xAlmacen And _
                                                           o.origenRecaudo = xGravado And _
                                                           o.idItem = xIdItem).FirstOrDefault


                    If Not IsNothing(objNuevo) Then
                        objNuevo.cantidad = objNuevo.cantidad + objBackDoc.monto1
                        objNuevo.precioUnitarioCompra = objNuevo.precioUnitarioCompra + objBackDoc.precioUnitario

                        objNuevo.importeSoles = objNuevo.importeSoles + objBackDoc.salidaCostoMN
                        objNuevo.importeDolares = objNuevo.importeDolares + objBackDoc.salidaCostoME

                        objNuevo.montoIsc = objNuevo.montoIsc + objBackDoc.montoIsc
                        objNuevo.montoIscUS = objNuevo.montoIscUS + objBackDoc.montoIscUS

                    End If
                End With
                HeliosData.SaveChanges()
                ts.Complete()
                Return True

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub SaveTotalesLista(ByVal objListaDetalle As List(Of totalesAlmacen), IntIddocumentoCompraDetalle As Integer)
        Dim objTotal As New totalesAlmacen()
        Dim CONSULTA As New totalesAlmacen()
        Try
            Using ts As New TransactionScope()

                For Each i As totalesAlmacen In objListaDetalle

                    Dim xSec As Integer = i.SecuenciaDetalle
                    Dim ndocumentoDetalle As documentocompradetalle = HeliosData.documentocompradetalle.Where(Function(o) o.secuencia = xSec).First
                    ndocumentoDetalle.almacenRef = i.idAlmacen

                    Dim xEmpresa As String = i.idEmpresa
                    Dim xEstableimiento As Integer = i.idEstablecimiento
                    Dim xAlmacen As Integer = i.idAlmacen
                    Dim xGravado As String = i.origenRecaudo
                    Dim xIdItem As Integer = i.idItem

                    CONSULTA = (From n In HeliosData.totalesAlmacen _
                                 Where n.idEmpresa = xEmpresa _
                                 And n.idEstablecimiento = xEstableimiento _
                                 And n.idAlmacen = xAlmacen _
                                 And n.origenRecaudo = xGravado _
                                 And n.idItem = xIdItem).FirstOrDefault

                    objTotal = New totalesAlmacen()
                    objTotal.idEmpresa = i.idEmpresa
                    objTotal.idEstablecimiento = i.idEstablecimiento
                    objTotal.idAlmacen = i.idAlmacen
                    objTotal.origenRecaudo = i.origenRecaudo
                    objTotal.tipoCambio = i.tipoCambio
                    objTotal.tipoExistencia = i.tipoExistencia
                    objTotal.idItem = i.idItem
                    objTotal.descripcion = i.descripcion
                    objTotal.idUnidad = i.idUnidad
                    objTotal.unidadMedida = i.unidadMedida
                    objTotal.Modulo = i.Modulo


                    If IsNothing(CONSULTA) Then 'no existe agregar nuevo

                        objTotal.cantidad = i.cantidad
                        objTotal.precioUnitarioCompra = i.precioUnitarioCompra
                        objTotal.importeSoles = i.importeSoles

                        objTotal.importeDolares = i.importeDolares
                        objTotal.montoIsc = i.montoIsc
                        objTotal.montoIscUS = i.montoIscUS

                        SaveSIngle(objTotal)
                    Else ' editar existente

                        objTotal.cantidad = i.cantidad
                        objTotal.precioUnitarioCompra = i.precioUnitarioCompra
                        objTotal.importeSoles = i.importeSoles

                        objTotal.importeDolares = i.importeDolares
                        objTotal.montoIsc = i.montoIsc
                        objTotal.montoIscUS = i.montoIscUS

                        UpdateSingle(objTotal, IntIddocumentoCompraDetalle)
                    End If
                    'HeliosData.ObjectStateManager.GetObjectStateEntry(ndocumentoDetalle).State.ToString()
                Next
                HeliosData.SaveChanges()
                ts.Complete()

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub SaveTotalesListaCompraPagada(ByVal objListaDetalle As List(Of totalesAlmacen), IntIddocumentoCompraDetalle As Integer)
        Dim objTotal As New totalesAlmacen()
        Dim CONSULTA As New totalesAlmacen()
        Try
            Using ts As New TransactionScope()

                For Each i As totalesAlmacen In objListaDetalle

                    Dim xEmpresa As String = i.idEmpresa
                    Dim xEstableimiento As Integer = i.idEstablecimiento
                    Dim xAlmacen As Integer = i.idAlmacen
                    Dim xGravado As String = i.origenRecaudo
                    Dim xIdItem As Integer = i.idItem

                    CONSULTA = (From n In HeliosData.totalesAlmacen _
                                 Where n.idAlmacen = xAlmacen _
                                 And n.origenRecaudo = xGravado _
                                 And n.idItem = xIdItem).FirstOrDefault

                    objTotal = New totalesAlmacen()
                    objTotal.idEmpresa = i.idEmpresa
                    objTotal.idEstablecimiento = i.idEstablecimiento
                    objTotal.idAlmacen = i.idAlmacen
                    objTotal.origenRecaudo = i.origenRecaudo
                    objTotal.tipoCambio = i.tipoCambio
                    objTotal.tipoExistencia = i.tipoExistencia
                    objTotal.idItem = i.idItem
                    objTotal.descripcion = i.descripcion
                    objTotal.idUnidad = i.idUnidad
                    objTotal.unidadMedida = i.unidadMedida
                    objTotal.Modulo = i.Modulo


                    If IsNothing(CONSULTA) Then 'no existe agregar nuevo

                        objTotal.cantidad = i.cantidad
                        objTotal.precioUnitarioCompra = i.precioUnitarioCompra
                        objTotal.importeSoles = i.importeSoles

                        objTotal.importeDolares = i.importeDolares
                        objTotal.montoIsc = i.montoIsc
                        objTotal.montoIscUS = i.montoIscUS

                        SaveSIngle(objTotal)
                    Else ' editar existente

                        objTotal.cantidad = i.cantidad
                        objTotal.precioUnitarioCompra = i.precioUnitarioCompra
                        objTotal.importeSoles = i.importeSoles

                        objTotal.importeDolares = i.importeDolares
                        objTotal.montoIsc = i.montoIsc
                        objTotal.montoIscUS = i.montoIscUS

                        UpdateSingle(objTotal, IntIddocumentoCompraDetalle)
                    End If

                Next
                HeliosData.SaveChanges()
                ts.Complete()

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateSingleLista(ByVal objLiquidacionEO As List(Of totalesAlmacen), objDeleteTotales As List(Of totalesAlmacen))
        Dim objNuevo As New totalesAlmacen()
        Dim objTotal As New totalesAlmacen()
        Using ts As New TransactionScope()

            DeleteTotalesAlmacen(objDeleteTotales)


            For Each i As totalesAlmacen In objLiquidacionEO
                Dim xEstableimiento As Integer = i.idEstablecimiento
                Dim xAlmacen As Integer = i.idAlmacen

                Dim almacenVR = (From n In HeliosData.almacen _
                                 Where n.idAlmacen = xAlmacen).First

                Dim xEmpresa As String = i.idEmpresa
                Dim xGravado As String = i.origenRecaudo
                Dim xIdItem As Integer = i.idItem



                '   If Not almacenVR.tipo = "AV" Then

                objNuevo = HeliosData.totalesAlmacen.Where(Function(o) o.idEmpresa = xEmpresa And _
                                              o.idEstablecimiento = xEstableimiento And _
                                              o.idAlmacen = xAlmacen And _
                                              o.origenRecaudo = xGravado And _
                                              o.idItem = xIdItem).FirstOrDefault

                If Not IsNothing(objNuevo) Then


                    Select Case i.Modulo

                        Case "N"

                            objNuevo.cantidad = objNuevo.cantidad + i.cantidad
                            objNuevo.precioUnitarioCompra = objNuevo.precioUnitarioCompra + i.precioUnitarioCompra
                            objNuevo.importeSoles = objNuevo.importeSoles + i.importeSoles

                            objNuevo.importeDolares = objNuevo.importeDolares + i.importeDolares
                            objNuevo.montoIsc = objNuevo.montoIsc + i.montoIsc
                            objNuevo.montoIscUS = objNuevo.montoIscUS + i.montoIscUS



                        Case "E"
                            Dim cVarianzaCan As Decimal = 0
                            Dim cVarianzaPU As Decimal = 0
                            Dim cVarianzaImporte As Decimal = 0
                            Dim cVarianzaImporteUS As Decimal = 0
                            Dim cVarianzaIsc As Decimal = 0
                            Dim cVarianzaIscUS As Decimal = 0

                            Dim xSecuencia As Integer = i.SecuenciaDetalle
                            Dim objBackDoc = (From k In HeliosData.documentocompradetalle _
                                             Where k.secuencia = xSecuencia).First

                            'otros reportes
                            cVarianzaCan = (objBackDoc.monto1 - i.cantidad) * -1
                            objNuevo.cantidad = (cVarianzaCan + objNuevo.cantidad)

                            cVarianzaPU = (objBackDoc.precioUnitario - i.precioUnitarioCompra) * -1
                            objNuevo.precioUnitarioCompra = (cVarianzaPU + objNuevo.precioUnitarioCompra)

                            cVarianzaImporte = (objBackDoc.importe - i.importeSoles) * -1
                            objNuevo.importeSoles = (cVarianzaImporte + objNuevo.importeSoles)

                            cVarianzaImporteUS = (objBackDoc.importeUS - i.importeDolares) * -1
                            objNuevo.importeDolares = (cVarianzaImporteUS + objNuevo.importeDolares)

                            cVarianzaIsc = (objBackDoc.montoIsc - i.montoIsc) * -1
                            objNuevo.montoIsc = (cVarianzaIsc + objNuevo.montoIsc)

                            cVarianzaIsc = (objBackDoc.montoIsc - i.montoIsc) * -1
                            objNuevo.montoIsc = (cVarianzaIsc + objNuevo.montoIsc)

                            cVarianzaIscUS = (objBackDoc.montoIscUS - i.montoIscUS) * -1
                            objNuevo.montoIscUS = (cVarianzaIscUS + objNuevo.montoIscUS)

                    End Select
                    'HeliosData.ObjectStateManager.GetObjectStateEntry(objNuevo).State.ToString()
                Else
                    objTotal = New totalesAlmacen()
                    objTotal.idEmpresa = i.idEmpresa
                    objTotal.idEstablecimiento = i.idEstablecimiento
                    objTotal.idAlmacen = i.idAlmacen
                    objTotal.origenRecaudo = i.origenRecaudo
                    objTotal.tipoCambio = i.tipoCambio
                    objTotal.tipoExistencia = i.tipoExistencia
                    objTotal.idItem = i.idItem
                    objTotal.descripcion = i.descripcion
                    objTotal.idUnidad = i.idUnidad
                    objTotal.unidadMedida = i.unidadMedida
                    objTotal.Modulo = i.Modulo

                    objTotal.cantidad = i.cantidad
                    objTotal.precioUnitarioCompra = i.precioUnitarioCompra
                    objTotal.importeSoles = i.importeSoles

                    objTotal.importeDolares = i.importeDolares
                    objTotal.montoIsc = i.montoIsc
                    objTotal.montoIscUS = i.montoIscUS

                    SaveSIngle(objTotal)
                End If


                '  End If
            Next
            HeliosData.SaveChanges()
            ts.Complete()

        End Using

    End Sub

    Public Sub UpdateTotalAlmacenOE(ByVal objLiquidacionEO As List(Of totalesAlmacen), objDeleteTotales As List(Of totalesAlmacen))
        Dim objNuevo As New totalesAlmacen()
        Dim objTotal As New totalesAlmacen()
        Using ts As New TransactionScope()

            DeleteTotalesAlmacenOE(objDeleteTotales)

            For Each i As totalesAlmacen In objLiquidacionEO
                Dim xEstableimiento As Integer = i.idEstablecimiento
                Dim xAlmacen As Integer = i.idAlmacen

                Dim almacenVR = (From n In HeliosData.almacen _
                                 Where n.idAlmacen = xAlmacen).First

                Dim xEmpresa As String = i.idEmpresa
                Dim xGravado As String = i.origenRecaudo
                Dim xIdItem As Integer = i.idItem



                '   If Not almacenVR.tipo = "AV" Then

                objNuevo = HeliosData.totalesAlmacen.Where(Function(o) o.idEmpresa = xEmpresa And _
                                              o.idEstablecimiento = xEstableimiento And _
                                              o.idAlmacen = xAlmacen And _
                                              o.origenRecaudo = xGravado And _
                                              o.idItem = xIdItem).FirstOrDefault

                If Not IsNothing(objNuevo) Then


                    Select Case i.Modulo

                        Case "N"

                            objNuevo.cantidad = objNuevo.cantidad + i.cantidad
                            objNuevo.precioUnitarioCompra = objNuevo.precioUnitarioCompra + i.precioUnitarioCompra
                            objNuevo.importeSoles = objNuevo.importeSoles + i.importeSoles

                            objNuevo.importeDolares = objNuevo.importeDolares + i.importeDolares
                            objNuevo.montoIsc = objNuevo.montoIsc + i.montoIsc
                            objNuevo.montoIscUS = objNuevo.montoIscUS + i.montoIscUS



                        Case "E"
                            Dim cVarianzaCan As Decimal = 0
                            Dim cVarianzaPU As Decimal = 0
                            Dim cVarianzaImporte As Decimal = 0
                            Dim cVarianzaImporteUS As Decimal = 0
                            Dim cVarianzaIsc As Decimal = 0
                            Dim cVarianzaIscUS As Decimal = 0

                            Dim xSecuencia As Integer = i.SecuenciaDetalle
                            Dim objBackDoc = (From k In HeliosData.documentocompradetalle _
                                             Where k.secuencia = xSecuencia).First

                            'otros reportes
                            cVarianzaCan = (objBackDoc.monto1 - i.cantidad) * -1
                            objNuevo.cantidad = (cVarianzaCan + objNuevo.cantidad)

                            cVarianzaPU = (objBackDoc.precioUnitario - i.precioUnitarioCompra) * -1
                            objNuevo.precioUnitarioCompra = (cVarianzaPU + objNuevo.precioUnitarioCompra)

                            cVarianzaImporte = (objBackDoc.importe - i.importeSoles) * -1
                            objNuevo.importeSoles = (cVarianzaImporte + objNuevo.importeSoles)

                            cVarianzaImporteUS = (objBackDoc.importeUS - i.importeDolares) * -1
                            objNuevo.importeDolares = (cVarianzaImporteUS + objNuevo.importeDolares)

                            cVarianzaIsc = (objBackDoc.montoIsc - i.montoIsc) * -1
                            objNuevo.montoIsc = (cVarianzaIsc + objNuevo.montoIsc)

                            cVarianzaIsc = (objBackDoc.montoIsc - i.montoIsc) * -1
                            objNuevo.montoIsc = (cVarianzaIsc + objNuevo.montoIsc)

                            cVarianzaIscUS = (objBackDoc.montoIscUS - i.montoIscUS) * -1
                            objNuevo.montoIscUS = (cVarianzaIscUS + objNuevo.montoIscUS)

                    End Select
                    'HeliosData.ObjectStateManager.GetObjectStateEntry(objNuevo).State.ToString()
                Else
                    objTotal = New totalesAlmacen()
                    objTotal.idEmpresa = i.idEmpresa
                    objTotal.idEstablecimiento = i.idEstablecimiento
                    objTotal.idAlmacen = i.idAlmacen
                    objTotal.origenRecaudo = i.origenRecaudo
                    objTotal.tipoCambio = i.tipoCambio
                    objTotal.tipoExistencia = i.tipoExistencia
                    objTotal.idItem = i.idItem
                    objTotal.descripcion = i.descripcion
                    objTotal.idUnidad = i.idUnidad
                    objTotal.unidadMedida = i.unidadMedida
                    objTotal.Modulo = i.Modulo

                    objTotal.cantidad = i.cantidad
                    objTotal.precioUnitarioCompra = i.precioUnitarioCompra
                    objTotal.importeSoles = i.importeSoles

                    objTotal.importeDolares = i.importeDolares
                    objTotal.montoIsc = i.montoIsc
                    objTotal.montoIscUS = i.montoIscUS

                    SaveSIngle(objTotal)
                End If


                '  End If
            Next
            HeliosData.SaveChanges()
            ts.Complete()

        End Using

    End Sub

    Public Sub UpdateTotalAlmacenOS(ByVal objLiquidacionEO As List(Of totalesAlmacen), objDeleteTotales As List(Of totalesAlmacen))
        Dim objNuevo As New totalesAlmacen()
        Dim objTotal As New totalesAlmacen()
        Using ts As New TransactionScope()

            DeleteTotalesAlmacenOS(objDeleteTotales)

            For Each i As totalesAlmacen In objLiquidacionEO
                Dim xEstableimiento As Integer = i.idEstablecimiento
                Dim xAlmacen As Integer = i.idAlmacen

                Dim almacenVR = (From n In HeliosData.almacen _
                                 Where n.idAlmacen = xAlmacen).First

                Dim xEmpresa As String = i.idEmpresa
                Dim xGravado As String = i.origenRecaudo
                Dim xIdItem As Integer = i.idItem



                '  If Not almacenVR.tipo = "AV" Then

                objNuevo = HeliosData.totalesAlmacen.Where(Function(o) o.idEmpresa = xEmpresa And _
                                              o.idEstablecimiento = xEstableimiento And _
                                              o.idAlmacen = xAlmacen And _
                                              o.origenRecaudo = xGravado And _
                                              o.idItem = xIdItem).FirstOrDefault

                If Not IsNothing(objNuevo) Then


                    Select Case i.Modulo

                        Case "N"

                            objNuevo.cantidad = objNuevo.cantidad + i.cantidad
                            objNuevo.precioUnitarioCompra = objNuevo.precioUnitarioCompra + i.precioUnitarioCompra
                            objNuevo.importeSoles = objNuevo.importeSoles + i.importeSoles

                            objNuevo.importeDolares = objNuevo.importeDolares + i.importeDolares
                            objNuevo.montoIsc = objNuevo.montoIsc + i.montoIsc
                            objNuevo.montoIscUS = objNuevo.montoIscUS + i.montoIscUS



                        Case "E"
                            Dim cVarianzaCan As Decimal = 0
                            Dim cVarianzaPU As Decimal = 0
                            Dim cVarianzaImporte As Decimal = 0
                            Dim cVarianzaImporteUS As Decimal = 0
                            Dim cVarianzaIsc As Decimal = 0
                            Dim cVarianzaIscUS As Decimal = 0

                            Dim xSecuencia As Integer = i.SecuenciaDetalle
                            Dim objBackDoc = (From k In HeliosData.documentocompradetalle _
                                             Where k.secuencia = xSecuencia).First

                            'otros reportes
                            cVarianzaCan = (objBackDoc.monto1 - i.cantidad) * -1
                            objNuevo.cantidad = (cVarianzaCan + objNuevo.cantidad)

                            cVarianzaPU = (objBackDoc.precioUnitario - i.precioUnitarioCompra) * -1
                            objNuevo.precioUnitarioCompra = (cVarianzaPU + objNuevo.precioUnitarioCompra)

                            cVarianzaImporte = (objBackDoc.importe - i.importeSoles) * -1
                            objNuevo.importeSoles = (cVarianzaImporte + objNuevo.importeSoles)

                            cVarianzaImporteUS = (objBackDoc.importeUS - i.importeDolares) * -1
                            objNuevo.importeDolares = (cVarianzaImporteUS + objNuevo.importeDolares)

                            cVarianzaIsc = (objBackDoc.montoIsc - i.montoIsc) * -1
                            objNuevo.montoIsc = (cVarianzaIsc + objNuevo.montoIsc)

                            cVarianzaIsc = (objBackDoc.montoIsc - i.montoIsc) * -1
                            objNuevo.montoIsc = (cVarianzaIsc + objNuevo.montoIsc)

                            cVarianzaIscUS = (objBackDoc.montoIscUS - i.montoIscUS) * -1
                            objNuevo.montoIscUS = (cVarianzaIscUS + objNuevo.montoIscUS)

                    End Select
                    'HeliosData.ObjectStateManager.GetObjectStateEntry(objNuevo).State.ToString()
                Else
                    objTotal = New totalesAlmacen()
                    objTotal.idEmpresa = i.idEmpresa
                    objTotal.idEstablecimiento = i.idEstablecimiento
                    objTotal.idAlmacen = i.idAlmacen
                    objTotal.origenRecaudo = i.origenRecaudo
                    objTotal.tipoCambio = i.tipoCambio
                    objTotal.tipoExistencia = i.tipoExistencia
                    objTotal.idItem = i.idItem
                    objTotal.descripcion = i.descripcion
                    objTotal.idUnidad = i.idUnidad
                    objTotal.unidadMedida = i.unidadMedida
                    objTotal.Modulo = i.Modulo

                    objTotal.cantidad = i.cantidad
                    objTotal.precioUnitarioCompra = i.precioUnitarioCompra
                    objTotal.importeSoles = i.importeSoles

                    objTotal.importeDolares = i.importeDolares
                    objTotal.montoIsc = i.montoIsc
                    objTotal.montoIscUS = i.montoIscUS

                    SaveSIngle(objTotal)
                End If


                '  End If
            Next
            HeliosData.SaveChanges()
            ts.Complete()

        End Using

    End Sub

    Public Sub UpdateSingleListaVentaTicket(ByVal objLiquidacionEO As List(Of totalesAlmacen), objDeleteTotales As List(Of totalesAlmacen))
        Dim objNuevo As New totalesAlmacen()
        Dim objTotal As New totalesAlmacen()
        Using ts As New TransactionScope()

            DeleteTotalesAlmacenVentaTicket(objDeleteTotales)


            For Each i As totalesAlmacen In objLiquidacionEO
                Dim xEstableimiento As Integer = i.idEstablecimiento
                Dim xAlmacen As Integer = i.idAlmacen

                Dim almacenVR = (From n In HeliosData.almacen _
                                 Where n.idAlmacen = xAlmacen).First

                Dim xEmpresa As String = i.idEmpresa
                Dim xGravado As String = i.origenRecaudo
                Dim xIdItem As Integer = i.idItem



                '  If Not almacenVR.tipo = "AV" Then

                objNuevo = HeliosData.totalesAlmacen.Where(Function(o) o.idEmpresa = xEmpresa And _
                                              o.idEstablecimiento = xEstableimiento And _
                                              o.idAlmacen = xAlmacen And _
                                              o.origenRecaudo = xGravado And _
                                              o.idItem = xIdItem).FirstOrDefault

                If Not IsNothing(objNuevo) Then


                    Select Case i.Modulo

                        Case "N"

                            objNuevo.cantidad = objNuevo.cantidad + i.cantidad
                            objNuevo.precioUnitarioCompra = objNuevo.precioUnitarioCompra + i.precioUnitarioCompra
                            objNuevo.importeSoles = objNuevo.importeSoles + i.importeSoles

                            objNuevo.importeDolares = objNuevo.importeDolares + i.importeDolares
                            objNuevo.montoIsc = objNuevo.montoIsc + i.montoIsc
                            objNuevo.montoIscUS = objNuevo.montoIscUS + i.montoIscUS



                        Case "E"
                            Dim cVarianzaCan As Decimal = 0
                            Dim cVarianzaPU As Decimal = 0
                            Dim cVarianzaImporte As Decimal = 0
                            Dim cVarianzaImporteUS As Decimal = 0
                            Dim cVarianzaIsc As Decimal = 0
                            Dim cVarianzaIscUS As Decimal = 0

                            Dim xSecuencia As Integer = i.SecuenciaDetalle
                            Dim objBackDoc = (From k In HeliosData.documentocompradetalle _
                                             Where k.secuencia = xSecuencia).First

                            'otros reportes
                            cVarianzaCan = (objBackDoc.monto1 - i.cantidad) * -1
                            objNuevo.cantidad = (cVarianzaCan + objNuevo.cantidad)

                            cVarianzaPU = (objBackDoc.precioUnitario - i.precioUnitarioCompra) * -1
                            objNuevo.precioUnitarioCompra = (cVarianzaPU + objNuevo.precioUnitarioCompra)

                            cVarianzaImporte = (objBackDoc.importe - i.importeSoles) * -1
                            objNuevo.importeSoles = (cVarianzaImporte + objNuevo.importeSoles)

                            cVarianzaImporteUS = (objBackDoc.importeUS - i.importeDolares) * -1
                            objNuevo.importeDolares = (cVarianzaImporteUS + objNuevo.importeDolares)

                            cVarianzaIsc = (objBackDoc.montoIsc - i.montoIsc) * -1
                            objNuevo.montoIsc = (cVarianzaIsc + objNuevo.montoIsc)

                            cVarianzaIsc = (objBackDoc.montoIsc - i.montoIsc) * -1
                            objNuevo.montoIsc = (cVarianzaIsc + objNuevo.montoIsc)

                            cVarianzaIscUS = (objBackDoc.montoIscUS - i.montoIscUS) * -1
                            objNuevo.montoIscUS = (cVarianzaIscUS + objNuevo.montoIscUS)

                    End Select
                    'HeliosData.ObjectStateManager.GetObjectStateEntry(objNuevo).State.ToString()
                Else
                    objTotal = New totalesAlmacen()
                    objTotal.idEmpresa = i.idEmpresa
                    objTotal.idEstablecimiento = i.idEstablecimiento
                    objTotal.idAlmacen = i.idAlmacen
                    objTotal.origenRecaudo = i.origenRecaudo
                    objTotal.tipoCambio = i.tipoCambio
                    objTotal.tipoExistencia = i.tipoExistencia
                    objTotal.idItem = i.idItem
                    objTotal.descripcion = i.descripcion
                    objTotal.idUnidad = i.idUnidad
                    objTotal.unidadMedida = i.unidadMedida
                    objTotal.Modulo = i.Modulo

                    objTotal.cantidad = i.cantidad
                    objTotal.precioUnitarioCompra = i.precioUnitarioCompra
                    objTotal.importeSoles = i.importeSoles

                    objTotal.importeDolares = i.importeDolares
                    objTotal.montoIsc = i.montoIsc
                    objTotal.montoIscUS = i.montoIscUS

                    SaveSIngle(objTotal)
                End If


                '   End If
            Next
            HeliosData.SaveChanges()
            ts.Complete()

        End Using

    End Sub

    Public Function Insert(ByVal totalesAlmacenBE As totalesAlmacen) As Integer
        Using ts As New TransactionScope
            HeliosData.totalesAlmacen.Add(totalesAlmacenBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return totalesAlmacenBE.idMovimiento
        End Using
    End Function

    Public Function InsertSingle(ByVal totalesAlmacenBE As totalesAlmacen) As Integer
        Dim totAlmacen As New totalesAlmacen
        Using ts As New TransactionScope
            totAlmacen.idEmpresa = totalesAlmacenBE.idEmpresa
            totAlmacen.idEstablecimiento = totalesAlmacenBE.idEstablecimiento
            totAlmacen.idAlmacen = totalesAlmacenBE.idAlmacen
            totAlmacen.origenRecaudo = totalesAlmacenBE.origenRecaudo
            totAlmacen.tipoCambio = totalesAlmacenBE.tipoCambio
            totAlmacen.tipoExistencia = totalesAlmacenBE.tipoExistencia
            totAlmacen.idItem = totalesAlmacenBE.idItem
            totAlmacen.descripcion = totalesAlmacenBE.descripcion
            totAlmacen.idUnidad = totalesAlmacenBE.idUnidad
            totAlmacen.cantidad = totalesAlmacenBE.cantidad
            totAlmacen.importeSoles = totalesAlmacenBE.importeSoles
            totAlmacen.importeDolares = totalesAlmacenBE.importeDolares
            totAlmacen.cantidadMaxima = 0
            totAlmacen.cantidadMinima = 0
            totAlmacen.status = totalesAlmacenBE.status
            totAlmacen.usuarioActualizacion = totalesAlmacenBE.usuarioActualizacion
            totAlmacen.fechaActualizacion = totalesAlmacenBE.fechaActualizacion
            HeliosData.totalesAlmacen.Add(totalesAlmacenBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return totalesAlmacenBE.idMovimiento
        End Using
    End Function

    Public Sub Update(ByVal totalesAlmacenBE As totalesAlmacen)
        Using ts As New TransactionScope
            Dim totAlmacen As totalesAlmacen = HeliosData.totalesAlmacen.Where(Function(o) _
                                            o.idMovimiento = totalesAlmacenBE.idMovimiento).First()

            totAlmacen.idEmpresa = totalesAlmacenBE.idEmpresa
            totAlmacen.idEstablecimiento = totalesAlmacenBE.idEstablecimiento
            totAlmacen.idAlmacen = totalesAlmacenBE.idAlmacen
            totAlmacen.origenRecaudo = totalesAlmacenBE.origenRecaudo
            totAlmacen.tipoCambio = totalesAlmacenBE.tipoCambio
            totAlmacen.tipoExistencia = totalesAlmacenBE.tipoExistencia
            totAlmacen.idItem = totalesAlmacenBE.idItem
            totAlmacen.descripcion = totalesAlmacenBE.descripcion
            totAlmacen.idUnidad = totalesAlmacenBE.idUnidad
            totAlmacen.unidadMedida = totalesAlmacenBE.unidadMedida
            totAlmacen.cantidad = totalesAlmacenBE.cantidad
            totAlmacen.precioUnitarioCompra = totalesAlmacenBE.precioUnitarioCompra
            totAlmacen.importeSoles = totalesAlmacenBE.importeSoles
            totAlmacen.importeDolares = totalesAlmacenBE.importeDolares
            totAlmacen.montoIsc = totalesAlmacenBE.montoIsc
            totAlmacen.montoIscUS = totalesAlmacenBE.montoIscUS
            totAlmacen.Otros = totalesAlmacenBE.Otros
            totAlmacen.OtrosUS = totalesAlmacenBE.OtrosUS
            totAlmacen.porcentajeUtilidad = totalesAlmacenBE.porcentajeUtilidad
            totAlmacen.importePorcentaje = totalesAlmacenBE.importePorcentaje
            totAlmacen.importePorcentajeUS = totalesAlmacenBE.importePorcentajeUS
            totAlmacen.precioVenta = totalesAlmacenBE.precioVenta
            totAlmacen.precioVentaUS = totalesAlmacenBE.precioVentaUS
            totAlmacen.cantidadMaxima = totalesAlmacenBE.cantidadMaxima
            totAlmacen.cantidadMinima = totalesAlmacenBE.cantidadMinima
            totAlmacen.fechaVcto = totalesAlmacenBE.fechaVcto
            totAlmacen.usuarioActualizacion = totalesAlmacenBE.usuarioActualizacion
            totAlmacen.fechaActualizacion = totalesAlmacenBE.fechaActualizacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(totAlmacen).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub UpdateTA(ByVal totalesAlmacenBE As totalesAlmacen)
        Using ts As New TransactionScope
            Dim totAlmacen As totalesAlmacen = HeliosData.totalesAlmacen.Where(Function(o) _
                                            o.idMovimiento = totalesAlmacenBE.idMovimiento).First()

            totAlmacen.cantidad = totalesAlmacenBE.cantidad
            totAlmacen.importeSoles = totalesAlmacenBE.importeSoles
            totAlmacen.importeDolares = totalesAlmacenBE.importeDolares
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal totalesAlmacenBE As totalesAlmacen)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(totalesAlmacenBE)
    End Sub

    Public Function GetListar_totalesAlmacen() As List(Of totalesAlmacen)
        Return (From a In HeliosData.totalesAlmacen Select a).ToList
    End Function

    Public Function GetUbicar_totalesAlmacenPorID(idMovimiento As Integer) As totalesAlmacen
        Return (From a In HeliosData.totalesAlmacen
                 Where a.idMovimiento = idMovimiento Select a).First
    End Function


    Public Function GetListaProductosPorAlmacenFechas(intIdAlmacen As Integer) As List(Of totalesAlmacen)
        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)


        Dim obj = (From a In HeliosData.totalesAlmacen
                Join prod In HeliosData.detalleitems _
                On a.idItem Equals prod.codigodetalle _
                 Join tbl In HeliosData.tabladetalle _
                   On prod.unidad1 Equals tbl.codigoDetalle _
                   Join alm In HeliosData.almacen _
                   On a.idAlmacen Equals alm.idAlmacen _
                Where a.idAlmacen = intIdAlmacen _
                 And tbl.idtabla = 6).ToList

        For Each i In obj
            ntotal = New totalesAlmacen
            ntotal.idEstablecimiento = i.a.idEstablecimiento
            ntotal.idAlmacen = i.a.idAlmacen
            ntotal.NomAlmacen = i.alm.descripcionAlmacen
            ntotal.idItem = i.a.idItem
            ntotal.origenRecaudo = i.a.origenRecaudo
            ntotal.tipoExistencia = i.a.tipoExistencia
            ntotal.descripcion = i.prod.descripcionItem
            ntotal.idUnidad = i.prod.unidad1
            ntotal.unidadMedida = i.tbl.descripcion
            ntotal.cantidad = i.a.cantidad
            ntotal.importeSoles = i.a.importeSoles
            ntotal.Presentacion = i.prod.presentacion
            Listatotal.Add(ntotal)
        Next

        Return Listatotal

    End Function

    Public Function GetListaProductosPorAlmacenPorCategoria(intIdAlmacen As Integer, intCategoria As Integer) As List(Of totalesAlmacen)
        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)


        Dim obj = (From a In HeliosData.totalesAlmacen
                 Join prod In HeliosData.detalleitems _
                 On a.idItem Equals prod.codigodetalle _
                  Join tbl In HeliosData.tabladetalle _
                    On prod.unidad1 Equals tbl.codigoDetalle _
                    Join alm In HeliosData.almacen _
                    On a.idAlmacen Equals alm.idAlmacen _
                    Join padre In HeliosData.item _
                    On prod.idItem Equals padre.idItem _
                 Where a.idAlmacen = intIdAlmacen And padre.idPadre = intCategoria _
                  And tbl.idtabla = 6).ToList

        For Each i In obj
            ntotal = New totalesAlmacen
            ntotal.idEstablecimiento = i.a.idEstablecimiento
            ntotal.idAlmacen = i.a.idAlmacen
            ntotal.NomAlmacen = i.alm.descripcionAlmacen
            ntotal.idItem = i.a.idItem
            ntotal.origenRecaudo = i.a.origenRecaudo
            ntotal.tipoExistencia = i.a.tipoExistencia
            ntotal.descripcion = i.prod.descripcionItem
            ntotal.idUnidad = i.prod.unidad1
            ntotal.unidadMedida = i.tbl.descripcion
            ntotal.cantidad = i.a.cantidad
            ntotal.importeSoles = i.a.importeSoles
            ntotal.Presentacion = i.prod.presentacion
            ntotal.cantidadMaxima = i.a.cantidadMaxima
            ntotal.cantidadMinima = i.a.cantidadMinima
            Listatotal.Add(ntotal)
        Next

        Return Listatotal

    End Function


    Public Function GetListaProductosPorAlmacenSinCategoria(intIdAlmacen As Integer, intCategoria As Integer) As List(Of totalesAlmacen)
        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)
        Dim parametros As New List(Of String)
        parametros.Add("0")
        parametros.Add(Nothing)

        Dim obj = (From a In HeliosData.totalesAlmacen
                Join prod In HeliosData.detalleitems _
                On a.idItem Equals prod.codigodetalle _
                 Join tbl In HeliosData.tabladetalle _
                   On prod.unidad1 Equals tbl.codigoDetalle _
                   Join alm In HeliosData.almacen _
                   On a.idAlmacen Equals alm.idAlmacen _
                Where a.idAlmacen = intIdAlmacen And parametros.Contains(prod.idItem) _
                 And tbl.idtabla = 6).ToList

        For Each i In obj
            ntotal = New totalesAlmacen
            ntotal.idEstablecimiento = i.a.idEstablecimiento
            ntotal.idAlmacen = i.a.idAlmacen
            ntotal.NomAlmacen = i.alm.descripcionAlmacen
            ntotal.idItem = i.a.idItem
            ntotal.origenRecaudo = i.a.origenRecaudo
            ntotal.tipoExistencia = i.a.tipoExistencia
            ntotal.descripcion = i.prod.descripcionItem
            ntotal.idUnidad = i.prod.unidad1
            ntotal.unidadMedida = i.tbl.descripcion
            ntotal.cantidad = i.a.cantidad
            ntotal.importeSoles = i.a.importeSoles
            ntotal.Presentacion = i.prod.presentacion
            ntotal.cantidadMaxima = i.a.cantidadMaxima
            ntotal.cantidadMinima = i.a.cantidadMinima
            Listatotal.Add(ntotal)
        Next

        Return Listatotal

    End Function

    Public Function GetListaProductosPorAlmacenConfiguracion(intIdAlmacen As Integer) As List(Of totalesAlmacen)
        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)

        Dim obj = (From a In HeliosData.totalesAlmacen
                   Join prod In HeliosData.detalleitems _
                   On a.idItem Equals prod.codigodetalle _
                   Join tbl In HeliosData.tabladetalle _
                   On prod.unidad1 Equals tbl.codigoDetalle _
                   Join alm In HeliosData.almacen _
                   On a.idAlmacen Equals alm.idAlmacen _
                Where a.idAlmacen = intIdAlmacen _
                 And tbl.idtabla = 6).ToList

        For Each i In obj
            ntotal = New totalesAlmacen
            ntotal.idEstablecimiento = i.a.idEstablecimiento
            ntotal.idAlmacen = i.a.idAlmacen
            ntotal.NomAlmacen = i.alm.descripcionAlmacen
            ntotal.idItem = i.a.idItem
            ntotal.origenRecaudo = i.a.origenRecaudo
            ntotal.tipoExistencia = i.a.tipoExistencia
            ntotal.descripcion = i.prod.descripcionItem
            ntotal.idUnidad = i.prod.unidad1
            ntotal.unidadMedida = i.tbl.descripcion
            ntotal.cantidad = i.a.cantidad
            ntotal.importeSoles = i.a.importeSoles
            ntotal.Presentacion = i.prod.presentacion

            Listatotal.Add(ntotal)
        Next

        Return Listatotal

    End Function

    Public Function GetListaProductosPorAlmacen(intIdAlmacen As Integer) As List(Of totalesAlmacen)
        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)

        Dim obj = (From a In HeliosData.totalesAlmacen
                Join prod In HeliosData.detalleitems _
                On a.idItem Equals prod.codigodetalle _
                 Join tbl In HeliosData.tabladetalle _
                   On prod.unidad1 Equals tbl.codigoDetalle _
                   Join alm In HeliosData.almacen _
                   On a.idAlmacen Equals alm.idAlmacen _
                Where a.idAlmacen = intIdAlmacen _
                 And tbl.idtabla = 6).ToList

        For Each i In obj
            ntotal = New totalesAlmacen
            ntotal.idEstablecimiento = i.a.idEstablecimiento
            ntotal.idAlmacen = i.a.idAlmacen
            ntotal.NomAlmacen = i.alm.descripcionAlmacen
            ntotal.idItem = i.a.idItem
            ntotal.origenRecaudo = i.a.origenRecaudo
            ntotal.tipoExistencia = i.a.tipoExistencia
            ntotal.descripcion = i.prod.descripcionItem
            ntotal.idUnidad = i.prod.unidad1
            ntotal.unidadMedida = i.tbl.descripcion
            ntotal.cantidad = i.a.cantidad
            ntotal.importeSoles = i.a.importeSoles
            ntotal.Presentacion = i.prod.presentacion

            Listatotal.Add(ntotal)
        Next

        Return Listatotal

    End Function


    Public Function GetProductosPorAlmacen(intIdAlmacen As Integer) As List(Of totalesAlmacen)
        GetProductosPorAlmacen = New List(Of totalesAlmacen)
        Dim consulta = (From n In HeliosData.totalesAlmacen
                        Join art In HeliosData.detalleitems On art.codigodetalle Equals n.idItem
                        Where n.idAlmacen = intIdAlmacen _
                            And art.estado = "A"
                        Select
                            art.codigodetalle,
                            art.descripcionItem,
                            n.origenRecaudo,
                            art.unidad1,
                            art.tipoExistencia).Distinct.ToList

        For Each i In consulta
            GetProductosPorAlmacen.Add(New totalesAlmacen With {.idItem = i.codigodetalle, .descripcion = i.descripcionItem, .origenRecaudo = i.origenRecaudo, .tipoExistencia = i.tipoExistencia})
        Next

        'Return HeliosData.totalesAlmacen.Where(Function(o) o.idAlmacen = intIdAlmacen).ToList

    End Function

    Public Function GetListaProductosByEstablecimiento(IntIdEstablecimiento As Integer) As List(Of totalesAlmacen)
        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)

        Dim obj = (From a In HeliosData.totalesAlmacen
                Join prod In HeliosData.detalleitems _
                On a.idItem Equals prod.codigodetalle _
                 Join tbl In HeliosData.tabladetalle _
                   On prod.unidad1 Equals tbl.codigoDetalle _
                   Join alm In HeliosData.almacen _
                   On a.idAlmacen Equals alm.idAlmacen _
                Where a.idEstablecimiento = IntIdEstablecimiento _
                 And tbl.idtabla = 6).OrderBy(Function(o) o.alm.descripcionAlmacen).ToList



        For Each i In obj
            ntotal = New totalesAlmacen
            ntotal.idEstablecimiento = i.a.idEstablecimiento
            ntotal.idAlmacen = i.a.idAlmacen
            ntotal.NomAlmacen = i.alm.descripcionAlmacen
            ntotal.idItem = i.a.idItem
            ntotal.origenRecaudo = i.a.origenRecaudo
            ntotal.tipoExistencia = i.a.tipoExistencia
            ntotal.descripcion = i.prod.descripcionItem
            ntotal.idUnidad = i.prod.unidad1
            ntotal.unidadMedida = i.tbl.codigoDetalle2
            ntotal.cantidad = i.a.cantidad
            ntotal.importeSoles = i.a.importeSoles
            ntotal.importeDolares = i.a.importeDolares
            ntotal.Presentacion = i.prod.presentacion

            Listatotal.Add(ntotal)
        Next

        Return Listatotal

    End Function

    Public Function GetListaProductosTAPorProducto(intIdAlmacen As Integer, strBusqueda As String) As List(Of totalesAlmacen)

        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)

        Dim obj = (From a In HeliosData.totalesAlmacen
                Join prod In HeliosData.detalleitems _
                On a.idItem Equals prod.codigodetalle _
                 Join tbl In HeliosData.tabladetalle _
                   On prod.unidad1 Equals tbl.codigoDetalle _
                   Join alm In HeliosData.almacen _
                   On a.idAlmacen Equals alm.idAlmacen _
                Where a.idAlmacen = intIdAlmacen _
                 And tbl.idtabla = 6 _
                 And a.descripcion.Contains(strBusqueda)).ToList

        For Each i In obj
            ntotal = New totalesAlmacen
            ntotal.idEstablecimiento = i.a.idEstablecimiento
            ntotal.idAlmacen = i.a.idAlmacen
            ntotal.NomAlmacen = i.alm.descripcionAlmacen
            ntotal.idItem = i.a.idItem
            ntotal.origenRecaudo = i.a.origenRecaudo
            ntotal.tipoExistencia = i.a.tipoExistencia
            ntotal.descripcion = i.prod.descripcionItem
            ntotal.idUnidad = i.prod.unidad1
            ntotal.unidadMedida = i.tbl.descripcion
            ntotal.cantidad = i.a.cantidad
            ntotal.importeSoles = i.a.importeSoles
            ntotal.Presentacion = i.prod.presentacion

            Listatotal.Add(ntotal)
        Next

        Return Listatotal

    End Function

    Public Function GetListaProductosTAPorProductoByTake(intIdAlmacen As Integer, strBusqueda As String) As List(Of totalesAlmacen)

        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)

        Dim obj = (From a In HeliosData.totalesAlmacen
                  Join prod In HeliosData.detalleitems _
                  On a.idItem Equals prod.codigodetalle _
                  Join tbl In HeliosData.tabladetalle _
                   On prod.unidad1 Equals tbl.codigoDetalle _
                   Join alm In HeliosData.almacen _
                   On a.idAlmacen Equals alm.idAlmacen _
                  Where a.idAlmacen = intIdAlmacen _
                  And tbl.idtabla = 6 _
                  And a.descripcion.Contains(strBusqueda) Take 10 Order By prod.descripcionItem).ToList

        For Each i In obj
            ntotal = New totalesAlmacen
            ntotal.idEstablecimiento = i.a.idEstablecimiento
            ntotal.idAlmacen = i.a.idAlmacen
            ntotal.NomAlmacen = i.alm.descripcionAlmacen
            ntotal.idItem = i.a.idItem
            ntotal.origenRecaudo = i.a.origenRecaudo
            ntotal.tipoExistencia = i.a.tipoExistencia
            ntotal.descripcion = i.prod.descripcionItem
            ntotal.idUnidad = i.prod.unidad1
            ntotal.unidadMedida = i.tbl.descripcion
            ntotal.cantidad = i.a.cantidad
            ntotal.importeSoles = i.a.importeSoles
            ntotal.Presentacion = i.prod.presentacion

            Listatotal.Add(ntotal)
        Next

        Return Listatotal

    End Function

    Public Function GetListaProductosTAPorProductoByTakeSL(intIdAlmacen As Integer, strBusqueda As String) As List(Of totalesAlmacen)
        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)

        Dim obj = (From a In HeliosData.totalesAlmacen
                  Join prod In HeliosData.detalleitems _
                  On a.idItem Equals prod.codigodetalle _
                  Join tbl In HeliosData.tabladetalle _
                   On prod.unidad1 Equals tbl.codigoDetalle _
                   Join alm In HeliosData.almacen _
                   On a.idAlmacen Equals alm.idAlmacen _
                   Join it In HeliosData.item
                   On it.idItem Equals prod.idItem _
                  Where a.idAlmacen = intIdAlmacen _
                  And tbl.idtabla = 6 _
                  And a.descripcion.Contains(strBusqueda) Take 10 Order By prod.descripcionItem).ToList

        For Each i In obj
            ntotal = New totalesAlmacen
            ntotal.idEstablecimiento = i.a.idEstablecimiento
            ntotal.idAlmacen = i.a.idAlmacen
            ntotal.NomAlmacen = i.alm.descripcionAlmacen
            ntotal.idItem = i.a.idItem
            ntotal.origenRecaudo = i.a.origenRecaudo
            ntotal.tipoExistencia = i.a.tipoExistencia
            ntotal.descripcion = i.prod.descripcionItem
            ntotal.idUnidad = i.prod.unidad1
            ntotal.unidadMedida = i.tbl.descripcion
            ntotal.cantidad = i.a.cantidad
            ntotal.importeSoles = i.a.importeSoles
            ntotal.Presentacion = i.prod.presentacion
            ntotal.porcentajeUtilidad = i.it.utilidad

            Listatotal.Add(ntotal)
        Next

        Return Listatotal

    End Function

    Public Function GetProductoPorAlmacenTipoEx(intIdAlmacen As Integer, strTipoEx As String, strBusqueda As String) As List(Of totalesAlmacen)

        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)

        Dim obj = (From a In HeliosData.totalesAlmacen
                   Join prod In HeliosData.detalleitems
                    On a.idItem Equals prod.codigodetalle
                   Join alm In HeliosData.almacen
                    On a.idAlmacen Equals alm.idAlmacen
                   Group Join cat In HeliosData.item
                    On cat.idItem Equals prod.idItem
                    Into ov = Group
                   From x In ov.DefaultIfEmpty()
                   Group Join marca In HeliosData.item
                    On marca.idItem Equals prod.unidad2
                    Into marca = Group
                   From marca_empty In marca.DefaultIfEmpty()
                   Group Join lote In HeliosData.recursoCostoLote
                    On lote.codigoLote Equals a.codigoLote
                    Into ov1 = Group
                   From x1 In ov1.DefaultIfEmpty()
                   Where a.idAlmacen = intIdAlmacen _
                       And a.status = StatusArticulo.Activo _
                    And prod.tipoExistencia = strTipoEx _
                    And a.descripcion.Contains(strBusqueda)).ToList

        For Each i In obj
            ntotal = New totalesAlmacen
            If IsNothing(i.x) Then
                ntotal.Clasificicacion = "-"
            Else
                ntotal.Clasificicacion = i.x.descripcion
            End If
            ntotal.Marca = i.marca_empty.descripcion
            ntotal.idMovimiento = i.a.idMovimiento
            ntotal.idEstablecimiento = i.a.idEstablecimiento
            ntotal.idAlmacen = i.a.idAlmacen
            ntotal.NomAlmacen = i.alm.descripcionAlmacen
            ntotal.idItem = i.a.idItem
            ntotal.origenRecaudo = i.a.origenRecaudo
            ntotal.tipoExistencia = i.a.tipoExistencia
            ntotal.descripcion = i.prod.descripcionItem
            ntotal.idUnidad = i.a.idUnidad
            ntotal.unidadMedida = i.a.idUnidad
            ntotal.cantidad = i.a.cantidad
            ntotal.importeSoles = i.a.importeSoles
            ntotal.importeDolares = i.a.importeDolares
            ntotal.Presentacion = i.prod.presentacion
            ntotal.cantidadMaxima = i.a.cantidadMaxima
            ntotal.cantidadMinima = i.a.cantidadMinima
            ntotal.CustomLote = i.x1
            Listatotal.Add(ntotal)
        Next

        Return Listatotal

    End Function


    Public Function GetProductoPorAlmacenTipoExByCodigoBarra(intIdAlmacen As Integer, strTipoEx As String, CodBarra As String) As List(Of totalesAlmacen)

        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)

        Dim obj = (From a In HeliosData.totalesAlmacen
                    Join prod In HeliosData.detalleitems _
                    On a.idItem Equals prod.codigodetalle _
                    Join alm In HeliosData.almacen _
                    On a.idAlmacen Equals alm.idAlmacen _
                    Group Join cat In HeliosData.item _
                    On cat.idItem Equals prod.idItem _
                    Into ov = Group _
                    From x In ov.DefaultIfEmpty() _
                    Where a.idAlmacen = intIdAlmacen _
                    And prod.tipoExistencia = strTipoEx _
                    And prod.codigo = CodBarra).ToList

        For Each i In obj
            ntotal = New totalesAlmacen
            If IsNothing(i.x) Then
                ntotal.Clasificicacion = "-"
            Else
                ntotal.Clasificicacion = i.x.descripcion
            End If
            ntotal.idMovimiento = i.a.idMovimiento
            ntotal.idEstablecimiento = i.a.idEstablecimiento
            ntotal.idAlmacen = i.a.idAlmacen
            ntotal.NomAlmacen = i.alm.descripcionAlmacen
            ntotal.idItem = i.a.idItem
            ntotal.origenRecaudo = i.a.origenRecaudo
            ntotal.tipoExistencia = i.a.tipoExistencia
            ntotal.descripcion = i.prod.descripcionItem
            ntotal.idUnidad = i.a.idUnidad
            ntotal.unidadMedida = i.a.idUnidad
            ntotal.cantidad = i.a.cantidad
            ntotal.importeSoles = i.a.importeSoles
            ntotal.importeDolares = i.a.importeDolares
            ntotal.Presentacion = i.prod.presentacion
            ntotal.cantidadMaxima = i.a.cantidadMaxima
            ntotal.cantidadMinima = i.a.cantidadMinima

            Listatotal.Add(ntotal)
        Next

        Return Listatotal

    End Function

    Public Function GetProductoPorTipoExistencia(intIdAlmacen As Integer, strTipoEx As String) As List(Of totalesAlmacen)

        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)

        Dim obj = (From a In HeliosData.totalesAlmacen
                Join prod In HeliosData.detalleitems _
                On a.idItem Equals prod.codigodetalle _
                 Join tbl In HeliosData.tabladetalle _
                   On prod.unidad1 Equals tbl.codigoDetalle _
                   Join alm In HeliosData.almacen _
                   On a.idAlmacen Equals alm.idAlmacen _
                Where a.idAlmacen = intIdAlmacen _
                And prod.tipoExistencia = strTipoEx _
                 And tbl.idtabla = 6).ToList

        For Each i In obj
            ntotal = New totalesAlmacen
            ntotal.idEstablecimiento = i.a.idEstablecimiento
            ntotal.idAlmacen = i.a.idAlmacen
            ntotal.NomAlmacen = i.alm.descripcionAlmacen
            ntotal.idItem = i.a.idItem
            ntotal.origenRecaudo = i.a.origenRecaudo
            ntotal.tipoExistencia = i.a.tipoExistencia
            ntotal.descripcion = i.prod.descripcionItem
            ntotal.idUnidad = i.prod.unidad1
            ntotal.unidadMedida = i.tbl.descripcion
            ntotal.cantidad = i.a.cantidad
            ntotal.importeSoles = i.a.importeSoles
            ntotal.importeDolares = i.a.importeDolares
            ntotal.Presentacion = i.prod.presentacion

            Listatotal.Add(ntotal)
        Next

        Return Listatotal

    End Function

    Function RecuperarSumaINVxitem(intiDItem As Integer, intAnio As Integer, intMes As Integer) As totalesAlmacen

        Dim consulta = Aggregate n In HeliosData.InventarioMovimiento _
                       Join alm In HeliosData.almacen _
                       On alm.idAlmacen Equals n.idAlmacen _
                       Where n.idEmpresa = Gempresas.IdEmpresaRuc And n.idEstablecimiento = GEstableciento.IdEstablecimiento _
                       And n.idItem = intiDItem And n.fecha.Value.Year = intAnio And n.fecha.Value.Month = intMes _
                       And alm.tipo <> "AV" _
                       Into sumCant = Sum(n.cantidad), sumMN = Sum(n.monto), sumME = Sum(n.montoUSD)

        Return New totalesAlmacen With {.cantidad = consulta.sumCant.GetValueOrDefault,
                                          .importeSoles = consulta.sumMN.GetValueOrDefault,
                                          .importeDolares = consulta.sumME.GetValueOrDefault}
    End Function

    Public Function GetProductosXempresa(be As totalesAlmacen) As List(Of totalesAlmacen)

        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)
        Dim cierreBL As New cierreinventarioBL
        Dim cierre As New cierreinventario

        Dim obj = (From a In HeliosData.totalesAlmacen
                   Join prod In HeliosData.detalleitems
                   On a.idItem Equals prod.codigodetalle
                   Join alm In HeliosData.almacen
                   On a.idAlmacen Equals alm.idAlmacen
                   Where a.idEmpresa = be.idEmpresa _
                       And a.idEstablecimiento = be.idEstablecimiento _
                   And alm.tipo <> "AV").ToList


        Dim cant As Decimal = 0
        Dim montoMN As Decimal = 0
        Dim montoME As Decimal = 0
        For Each i In obj

            'cierre = cierreBL.RecuperarCierreListado(AnioGeneral, MesGeneral - 1, i.a.idItem) 'recuperando saldo anterior
            'If Not IsNothing(cierre) Then
            '    cant = cierre.cantidad.GetValueOrDefault
            '    montoMN = cierre.importe.GetValueOrDefault
            '    montoME = cierre.importeUS.GetValueOrDefault
            'Else
            '    cant = 0
            '    montoMN = 0
            '    montoME = 0
            'End If

            '  Dim inventario As New totalesAlmacen
            'inventario = RecuperarSumaINVxitem(i.a.idItem, AnioGeneral, MesGeneral)
            'cant = cant + inventario.cantidad
            'montoMN = montoMN + inventario.importeSoles
            'montoME = montoME + inventario.importeDolares

            ntotal = New totalesAlmacen
            ntotal.idEstablecimiento = i.a.idEstablecimiento
            ntotal.idAlmacen = i.a.idAlmacen
            ntotal.NomAlmacen = i.alm.descripcionAlmacen
            ntotal.idItem = i.a.idItem
            ntotal.origenRecaudo = i.a.origenRecaudo
            ntotal.tipoExistencia = i.a.tipoExistencia
            ntotal.descripcion = i.prod.descripcionItem
            ntotal.idUnidad = i.prod.unidad1
            ntotal.unidadMedida = i.a.idUnidad
            ntotal.cantidad = i.a.cantidad ' cant
            ntotal.importeSoles = i.a.importeSoles ' (montoMN) ' + sumaCierreAnteriorMN
            ntotal.importeDolares = i.a.importeDolares ' montoME ' + sumaCierreAnteriorME
            ntotal.Presentacion = i.prod.presentacion

            Listatotal.Add(ntotal)

            'sumaCierreAnteriorMN = 0
            'sumaCierreAnteriorME = 0
        Next

        Return Listatotal

    End Function

    Public Function GetListadoProductosParaVentaXproductoXAlmacenFull(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen)

        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)
        Dim lista As New List(Of String)
        lista.Add(TipoExistencia.Mercaderia)
        lista.Add(TipoExistencia.ProductoTerminado)
        lista.Add(TipoExistencia.SubProductosDesechos)
        lista.Add("GS")

        Dim obj = (From a In HeliosData.totalesAlmacen
                   Join alm In HeliosData.almacen On alm.idAlmacen Equals a.idAlmacen
                   Join articulo In HeliosData.detalleitems On articulo.codigodetalle Equals a.idItem
                Where alm.tipo <> "AV" And lista.Contains(a.tipoExistencia) And alm.idAlmacen = objTotalBE.idAlmacen And a.descripcion.Contains(objTotalBE.descripcion)).ToList

        'Dim obj = (From a In HeliosData.totalesAlmacen
        '           Join alm In HeliosData.almacen On alm.idAlmacen Equals a.idAlmacen
        '           Join articulo In HeliosData.detalleitems On articulo.codigodetalle Equals a.idItem
        '        Where alm.tipo <> "AV" And alm.idAlmacen = objTotalBE.idAlmacen And a.descripcion.Contains(objTotalBE.descripcion)).ToList

        For Each i In obj
            ntotal = New totalesAlmacen
            ntotal.idEmpresa = i.a.idEmpresa
            ntotal.idEstablecimiento = i.alm.idEstablecimiento
            ntotal.idAlmacen = i.a.idAlmacen
            ntotal.NomAlmacen = i.alm.descripcionAlmacen
            ntotal.idItem = i.a.idItem
            ntotal.origenRecaudo = i.articulo.origenProducto
            ntotal.tipoExistencia = i.articulo.tipoExistencia
            ntotal.descripcion = i.articulo.descripcionItem
            ntotal.idUnidad = i.articulo.unidad1
            ntotal.unidadMedida = i.articulo.unidad1 ' i.tbl.descripcion
            ntotal.cantidad = i.a.cantidad
            ntotal.importeSoles = i.a.importeSoles
            ntotal.importeDolares = i.a.importeDolares
            '  ntotal.Presentacion = i.Presentacion

            Listatotal.Add(ntotal)
        Next

        Return Listatotal

    End Function


    Public Function GetListadoProductosParaVentaXproductoXAlmacen(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen)

        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)

        Dim obj = (From a In HeliosData.totalesAlmacen
                   Join alm In HeliosData.almacen On alm.idAlmacen Equals a.idAlmacen
                   Join articulo In HeliosData.detalleitems On articulo.codigodetalle Equals a.idItem
                   Where alm.tipo <> "AV" And a.tipoExistencia = objTotalBE.tipoExistencia And alm.idAlmacen = objTotalBE.idAlmacen And a.descripcion.Contains(objTotalBE.descripcion)).ToList

        For Each i In obj
            ntotal = New totalesAlmacen
            ntotal.idEmpresa = i.a.idEmpresa
            ntotal.idEstablecimiento = i.alm.idEstablecimiento
            ntotal.idAlmacen = i.a.idAlmacen
            ntotal.NomAlmacen = i.alm.descripcionAlmacen
            ntotal.idItem = i.a.idItem
            ntotal.origenRecaudo = i.articulo.origenProducto
            ntotal.tipoExistencia = i.articulo.tipoExistencia
            ntotal.descripcion = i.articulo.descripcionItem
            ntotal.idUnidad = i.articulo.unidad1
            ntotal.unidadMedida = i.articulo.unidad1 ' i.tbl.descripcion
            ntotal.cantidad = i.a.cantidad
            ntotal.importeSoles = i.a.importeSoles
            ntotal.importeDolares = i.a.importeDolares
            '  ntotal.Presentacion = i.Presentacion

            Listatotal.Add(ntotal)
        Next

        Return Listatotal

    End Function

    Public Function listaProductosMarca(be As detalleitems) As List(Of totalesAlmacen)
        Dim Listatotal As New List(Of totalesAlmacen)
        Dim ntotal As totalesAlmacen

        Dim consunlta = (From t In HeliosData.totalesAlmacen
                         Join alm In HeliosData.almacen On t.idAlmacen Equals alm.idAlmacen
                         Join articulo In HeliosData.detalleitems On t.idItem Equals articulo.codigodetalle
                         Join marca In HeliosData.item On marca.idItem Equals articulo.unidad2
                         Where
                             articulo.idEmpresa = be.idEmpresa And
                             alm.tipo <> "AV" And
                             articulo.tipoExistencia = be.tipoExistencia And
                             articulo.unidad2 = be.unidad2 And
                             t.status = StatusArticulo.Activo And
                             articulo.estado = "A"
                         Group New With {articulo, t} By
                             t.idEmpresa,
                             alm.idEstablecimiento,
                             alm.idAlmacen,
                             alm.descripcionAlmacen,
                             articulo.codigodetalle,
                             marcaName = marca.descripcion,
                             articulo.origenProducto,
                             articulo.tipoExistencia,
                             articulo.descripcionItem,
                             articulo.unidad1,
                      precioMenor = (
                      ((From configuracionPrecioProductoes In HeliosData.configuracionPrecioProducto
                        Where
                             configuracionPrecioProductoes.idproducto = t.idItem And
                             CLng(configuracionPrecioProductoes.idPrecio) = 1 And
                             configuracionPrecioProductoes.fecha = (Aggregate t2 In
                                                                        (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                                                         Where
                                                                             CLng(configuracionPrecioProductoes0.idPrecio) = 1 And
                                                                             configuracionPrecioProductoes0.idproducto = t.idItem
                                                                         Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                        Select New With {
                             configuracionPrecioProductoes.precioMN
                             }).FirstOrDefault().precioMN)),
                       precioMayor = (
                       ((From configuracionPrecioProductoes In HeliosData.configuracionPrecioProducto
                         Where
                             configuracionPrecioProductoes.idproducto = t.idItem And
                             CLng(configuracionPrecioProductoes.idPrecio) = 2 And
                             configuracionPrecioProductoes.fecha = (Aggregate t2 In
                                                                        (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                                                         Where
                                                                             CLng(configuracionPrecioProductoes0.idPrecio) = 2 And
                                                                             configuracionPrecioProductoes0.idproducto = t.idItem
                                                                         Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                         Select New With {
                             configuracionPrecioProductoes.precioMN
                             }).FirstOrDefault().precioMN)),
                       precioGranMayor = (
                       ((From configuracionPrecioProductoes In HeliosData.configuracionPrecioProducto
                         Where
                             configuracionPrecioProductoes.idproducto = t.idItem And
                             CLng(configuracionPrecioProductoes.idPrecio) = 3 And
                             configuracionPrecioProductoes.fecha = (Aggregate t2 In
                                                                        (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                                                         Where
                                                                             CLng(configuracionPrecioProductoes0.idPrecio) = 3 And
                                                                             configuracionPrecioProductoes0.idproducto = t.idItem
                                                                         Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                         Select New With {
                             configuracionPrecioProductoes.precioMN
                             }).FirstOrDefault().precioMN))
                      Into g = Group
                         Order By
                      descripcionItem
                         Select
                      idEmpresa,
                             marcaName,
                      idEstablecimiento,
                      idAlmacen,
                      descripcionAlmacen,
                      codigodetalle,
                      origenProducto,
                      tipoExistencia,
                      descripcionItem,
                      unidad1,
                      precioMenor,
                      precioMayor,
                      precioGranMayor,
                      Stock = CType(g.Sum(Function(p) p.t.cantidad), Decimal?)).ToList



        For Each i In consunlta
            ntotal = New totalesAlmacen
            ntotal.idEmpresa = i.idEmpresa
            ntotal.idEstablecimiento = i.idEstablecimiento
            ntotal.idAlmacen = i.idAlmacen
            ntotal.NomAlmacen = i.descripcionAlmacen
            ntotal.idItem = i.codigodetalle
            ntotal.origenRecaudo = i.origenProducto
            ntotal.tipoExistencia = i.tipoExistencia
            ntotal.descripcion = i.descripcionItem
            ntotal.idUnidad = i.unidad1
            ntotal.unidadMedida = i.unidad1 ' i.tbl.descripcion
            ntotal.cantidad = i.Stock.GetValueOrDefault
            ntotal.Marca = i.marcaName
            ntotal.precioVentaFinalMenorMN = i.precioMenor.GetValueOrDefault
            ntotal.precioVentaFinalMayorMN = i.precioMayor.GetValueOrDefault
            ntotal.precioVentaFinalGMayorMN = i.precioGranMayor.GetValueOrDefault
            Listatotal.Add(ntotal)
        Next

        Return Listatotal

    End Function


    Public Function ListaXGrupo(be As detalleitems) As List(Of totalesAlmacen)
        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)

        Dim consunlta = (From t In HeliosData.totalesAlmacen
                         Join alm In HeliosData.almacen On t.idAlmacen Equals alm.idAlmacen
                         Join articulo In HeliosData.detalleitems On t.idItem Equals articulo.codigodetalle
                         Group Join marca In HeliosData.item On marca.idItem Equals articulo.unidad2
                             Into marca_join = Group
                         From marca In marca_join.DefaultIfEmpty()
                         Where
                             articulo.idEmpresa = be.idEmpresa And
                             alm.tipo <> "AV" And
                             articulo.tipoExistencia = be.tipoExistencia And
                             articulo.idItem = be.idItem And
                             t.status = StatusArticulo.Activo And
                             articulo.estado = "A"
                         Group New With {articulo, t} By
                             t.idEmpresa,
                             alm.idEstablecimiento,
                             alm.idAlmacen,
                             alm.descripcionAlmacen,
                             articulo.codigodetalle,
                             marcaName = marca.descripcion,
                             articulo.origenProducto,
                             articulo.tipoExistencia,
                             articulo.descripcionItem,
                             articulo.unidad1,
                      precioMenor = (
                      ((From configuracionPrecioProductoes In HeliosData.configuracionPrecioProducto
                        Where
                             configuracionPrecioProductoes.idproducto = t.idItem And
                             CLng(configuracionPrecioProductoes.idPrecio) = 1 And
                             configuracionPrecioProductoes.fecha = (Aggregate t2 In
                                                                        (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                                                         Where
                                                                             CLng(configuracionPrecioProductoes0.idPrecio) = 1 And
                                                                             configuracionPrecioProductoes0.idproducto = t.idItem
                                                                         Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                        Select New With {
                             configuracionPrecioProductoes.precioMN
                             }).FirstOrDefault().precioMN)),
                       precioMayor = (
                       ((From configuracionPrecioProductoes In HeliosData.configuracionPrecioProducto
                         Where
                             configuracionPrecioProductoes.idproducto = t.idItem And
                             CLng(configuracionPrecioProductoes.idPrecio) = 2 And
                             configuracionPrecioProductoes.fecha = (Aggregate t2 In
                                                                        (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                                                         Where
                                                                             CLng(configuracionPrecioProductoes0.idPrecio) = 2 And
                                                                             configuracionPrecioProductoes0.idproducto = t.idItem
                                                                         Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                         Select New With {
                             configuracionPrecioProductoes.precioMN
                             }).FirstOrDefault().precioMN)),
                       precioGranMayor = (
                       ((From configuracionPrecioProductoes In HeliosData.configuracionPrecioProducto
                         Where
                             configuracionPrecioProductoes.idproducto = t.idItem And
                             CLng(configuracionPrecioProductoes.idPrecio) = 3 And
                             configuracionPrecioProductoes.fecha = (Aggregate t2 In
                                                                        (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                                                         Where
                                                                             CLng(configuracionPrecioProductoes0.idPrecio) = 3 And
                                                                             configuracionPrecioProductoes0.idproducto = t.idItem
                                                                         Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                         Select New With {
                             configuracionPrecioProductoes.precioMN
                             }).FirstOrDefault().precioMN))
                      Into g = Group
                         Order By
                      descripcionItem
                         Select
                      idEmpresa,
                             marcaName,
                      idEstablecimiento,
                      idAlmacen,
                      descripcionAlmacen,
                      codigodetalle,
                      origenProducto,
                      tipoExistencia,
                      descripcionItem,
                      unidad1,
                      precioMenor,
                      precioMayor,
                      precioGranMayor,
                      Stock = CType(g.Sum(Function(p) p.t.cantidad), Decimal?)).ToList


        For Each i In consunlta
            ntotal = New totalesAlmacen
            ntotal.idEmpresa = i.idEmpresa
            ntotal.idEstablecimiento = i.idEstablecimiento
            ntotal.idAlmacen = i.idAlmacen
            ntotal.NomAlmacen = i.descripcionAlmacen
            ntotal.idItem = i.codigodetalle
            ntotal.origenRecaudo = i.origenProducto
            ntotal.tipoExistencia = i.tipoExistencia
            ntotal.descripcion = i.descripcionItem
            ntotal.idUnidad = i.unidad1
            ntotal.unidadMedida = i.unidad1 ' i.tbl.descripcion
            ntotal.cantidad = i.Stock.GetValueOrDefault
            ntotal.Marca = i.marcaName
            ntotal.precioVentaFinalMenorMN = i.precioMenor.GetValueOrDefault
            ntotal.precioVentaFinalMayorMN = i.precioMayor.GetValueOrDefault
            ntotal.precioVentaFinalGMayorMN = i.precioGranMayor.GetValueOrDefault
            Listatotal.Add(ntotal)
        Next

        Return Listatotal

    End Function

    Public Function GetBusquedaAvanzadaProductosSinAlmacen(be As detalleitems, caso As String) As List(Of totalesAlmacen)
        ' Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)

        Select Case caso
            Case "MARCA"
                Listatotal = listaProductosMarcaSinAlmacen(be)

            Case "CLASIFICACION"
                Listatotal = ListaXGrupoSinAlmacen(be)
        End Select
        Return Listatotal

    End Function

    Public Function listaProductosMarcaSinAlmacen(be As detalleitems) As List(Of totalesAlmacen)
        Dim Listatotal As New List(Of totalesAlmacen)
        Dim ntotal As totalesAlmacen

        Dim consunlta = (From articulo In HeliosData.detalleitems
                         Join marca In HeliosData.item On marca.idItem Equals articulo.unidad2
                         Where
                             articulo.idEmpresa = be.idEmpresa And
                              articulo.tipoExistencia = be.tipoExistencia And
                             articulo.unidad2 = be.unidad2 And
                              articulo.estado = "A" And
                           Not (Not _
                           (From TotalesAlmacen In HeliosData.totalesAlmacen
                            Where
                                TotalesAlmacen.idItem = articulo.codigodetalle
                            Select New With {
                                TotalesAlmacen
                                }).FirstOrDefault() Is Nothing)
                         Group New With {articulo} By
                             articulo.codigodetalle,
                             marcaName = marca.descripcion,
                             articulo.origenProducto,
                             articulo.tipoExistencia,
                             articulo.descripcionItem,
                              articulo.idEmpresa,
                              articulo.idEstablecimiento,
                             articulo.unidad1,
                      precioMenor = (
                      ((From configuracionPrecioProductoes In HeliosData.configuracionPrecioProducto
                        Where
                             configuracionPrecioProductoes.idproducto = articulo.codigodetalle And
                             CLng(configuracionPrecioProductoes.idPrecio) = 1 And
                             configuracionPrecioProductoes.fecha = (Aggregate t2 In
                                                                        (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                                                         Where
                                                                             CLng(configuracionPrecioProductoes0.idPrecio) = 1 And
                                                                             configuracionPrecioProductoes0.idproducto = articulo.codigodetalle
                                                                         Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                        Select New With {
                             configuracionPrecioProductoes.precioMN
                             }).FirstOrDefault().precioMN)),
                       precioMayor = (
                       ((From configuracionPrecioProductoes In HeliosData.configuracionPrecioProducto
                         Where
                             configuracionPrecioProductoes.idproducto = articulo.codigodetalle And
                             CLng(configuracionPrecioProductoes.idPrecio) = 2 And
                             configuracionPrecioProductoes.fecha = (Aggregate t2 In
                                                                        (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                                                         Where
                                                                             CLng(configuracionPrecioProductoes0.idPrecio) = 2 And
                                                                             configuracionPrecioProductoes0.idproducto = articulo.codigodetalle
                                                                         Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                         Select New With {
                             configuracionPrecioProductoes.precioMN
                             }).FirstOrDefault().precioMN)),
                       precioGranMayor = (
                       ((From configuracionPrecioProductoes In HeliosData.configuracionPrecioProducto
                         Where
                             configuracionPrecioProductoes.idproducto = articulo.codigodetalle And
                             CLng(configuracionPrecioProductoes.idPrecio) = 3 And
                             configuracionPrecioProductoes.fecha = (Aggregate t2 In
                                                                        (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                                                         Where
                                                                             CLng(configuracionPrecioProductoes0.idPrecio) = 3 And
                                                                             configuracionPrecioProductoes0.idproducto = articulo.codigodetalle
                                                                         Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                         Select New With {
                             configuracionPrecioProductoes.precioMN
                             }).FirstOrDefault().precioMN)),
                              PrecioGranMayorME = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = articulo.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 3 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 3 _
                                            And configuracionPrecioProductoes0.idproducto = articulo.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioME
                                  }).FirstOrDefault().precioME)),
                              PrecioMayorME = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = articulo.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 2 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 2 _
                                            And configuracionPrecioProductoes0.idproducto = articulo.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioME
                                  }).FirstOrDefault().precioME)),
                               precioMenorME = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = articulo.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 1 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 1 _
                                            And configuracionPrecioProductoes0.idproducto = articulo.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioME
                                  }).FirstOrDefault().precioME))
                      Into g = Group
                         Order By
                      descripcionItem
                         Select
                                                marcaName,
                                         codigodetalle,
                      origenProducto,
                      tipoExistencia,
                      descripcionItem,
                      unidad1,
                      precioMenor,
                      precioMayor,
                             idEstablecimiento,
                             idEmpresa,
                      precioGranMayor,
                             precioMenorME,
                             PrecioMayorME,
                             PrecioGranMayorME).ToList



        For Each i In consunlta
            ntotal = New totalesAlmacen
            ntotal.idEmpresa = i.idEmpresa
            ntotal.idEstablecimiento = i.idEstablecimiento
            ntotal.idItem = i.codigodetalle
            ntotal.origenRecaudo = i.origenProducto
            ntotal.tipoExistencia = i.tipoExistencia
            ntotal.descripcion = i.descripcionItem
            ntotal.idUnidad = i.unidad1
            ntotal.unidadMedida = i.unidad1 ' i.tbl.descripcion
            ntotal.cantidad = 0
            ntotal.Marca = i.marcaName
            ntotal.precioVentaFinalMenorMN = i.precioMenor.GetValueOrDefault
            ntotal.precioVentaFinalMayorMN = i.precioMayor.GetValueOrDefault
            ntotal.precioVentaFinalGMayorMN = i.precioGranMayor.GetValueOrDefault
            ntotal.precioVentaFinalMenorMN = i.precioMenorME.GetValueOrDefault
            ntotal.precioVentaFinalMayorME = i.PrecioMayorME.GetValueOrDefault
            ntotal.precioVentaFinalGMayorME = i.PrecioGranMayorME.GetValueOrDefault
            Listatotal.Add(ntotal)
        Next

        Return Listatotal

    End Function


    Public Function ListaXGrupoSinAlmacen(be As detalleitems) As List(Of totalesAlmacen)
        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)

        Dim consunlta = (From articulo In HeliosData.detalleitems
                         Group Join marca In HeliosData.item On marca.idItem Equals articulo.unidad2
                             Into marca_join = Group
                         From marca In marca_join.DefaultIfEmpty()
                         Where
                             articulo.idEmpresa = be.idEmpresa And
                                            articulo.tipoExistencia = be.tipoExistencia And
                             articulo.idItem = be.idItem And
                                          articulo.estado = "A"
                         Group New With {articulo} By
                             articulo.idEmpresa,
                             articulo.idEstablecimiento,
                                          articulo.codigodetalle,
                             marcaName = marca.descripcion,
                             articulo.origenProducto,
                             articulo.tipoExistencia,
                             articulo.descripcionItem,
                             articulo.unidad1,
                      precioMenor = (
                      ((From configuracionPrecioProductoes In HeliosData.configuracionPrecioProducto
                        Where
                             configuracionPrecioProductoes.idproducto = articulo.codigodetalle And
                             CLng(configuracionPrecioProductoes.idPrecio) = 1 And
                             configuracionPrecioProductoes.fecha = (Aggregate t2 In
                                                                        (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                                                         Where
                                                                             CLng(configuracionPrecioProductoes0.idPrecio) = 1 And
                                                                             configuracionPrecioProductoes0.idproducto = articulo.codigodetalle
                                                                         Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                        Select New With {
                             configuracionPrecioProductoes.precioMN
                             }).FirstOrDefault().precioMN)),
                       precioMayor = (
                       ((From configuracionPrecioProductoes In HeliosData.configuracionPrecioProducto
                         Where
                             configuracionPrecioProductoes.idproducto = articulo.codigodetalle And
                             CLng(configuracionPrecioProductoes.idPrecio) = 2 And
                             configuracionPrecioProductoes.fecha = (Aggregate t2 In
                                                                        (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                                                         Where
                                                                             CLng(configuracionPrecioProductoes0.idPrecio) = 2 And
                                                                             configuracionPrecioProductoes0.idproducto = articulo.codigodetalle
                                                                         Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                         Select New With {
                             configuracionPrecioProductoes.precioMN
                             }).FirstOrDefault().precioMN)),
                       precioGranMayor = (
                       ((From configuracionPrecioProductoes In HeliosData.configuracionPrecioProducto
                         Where
                             configuracionPrecioProductoes.idproducto = articulo.codigodetalle And
                             CLng(configuracionPrecioProductoes.idPrecio) = 3 And
                             configuracionPrecioProductoes.fecha = (Aggregate t2 In
                                                                        (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                                                         Where
                                                                             CLng(configuracionPrecioProductoes0.idPrecio) = 3 And
                                                                             configuracionPrecioProductoes0.idproducto = articulo.codigodetalle
                                                                         Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                         Select New With {
                             configuracionPrecioProductoes.precioMN
                             }).FirstOrDefault().precioMN)),
                                          PrecioGranMayorME = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = articulo.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 3 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 3 _
                                            And configuracionPrecioProductoes0.idproducto = articulo.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioME
                                  }).FirstOrDefault().precioME)),
                              PrecioMayorME = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = articulo.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 2 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 2 _
                                            And configuracionPrecioProductoes0.idproducto = articulo.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioME
                                  }).FirstOrDefault().precioME)),
                               precioMenorME = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = articulo.codigodetalle And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 1 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 1 _
                                            And configuracionPrecioProductoes0.idproducto = articulo.codigodetalle
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioME
                                  }).FirstOrDefault().precioME))
                      Into g = Group
                         Order By
                      descripcionItem
                         Select
                      idEmpresa,
                             marcaName,
                      idEstablecimiento,
                       codigodetalle,
                      origenProducto,
                      tipoExistencia,
                      descripcionItem,
                      unidad1,
                      precioMenor,
                      precioMayor,
                      precioGranMayor,
                             precioMenorME,
                             PrecioMayorME,
                             PrecioGranMayorME).ToList


        For Each i In consunlta
            ntotal = New totalesAlmacen
            ntotal.idEmpresa = i.idEmpresa
            ntotal.idEstablecimiento = i.idEstablecimiento
            ntotal.idItem = i.codigodetalle
            ntotal.origenRecaudo = i.origenProducto
            ntotal.tipoExistencia = i.tipoExistencia
            ntotal.descripcion = i.descripcionItem
            ntotal.idUnidad = i.unidad1
            ntotal.unidadMedida = i.unidad1 ' i.tbl.descripcion
            ntotal.cantidad = 0
            ntotal.Marca = i.marcaName
            ntotal.precioVentaFinalMenorMN = i.precioMenor.GetValueOrDefault
            ntotal.precioVentaFinalMayorMN = i.precioMayor.GetValueOrDefault
            ntotal.precioVentaFinalGMayorMN = i.precioGranMayor.GetValueOrDefault
            ntotal.precioVentaFinalMenorMN = i.precioMenorME.GetValueOrDefault
            ntotal.precioVentaFinalMayorME = i.PrecioMayorME.GetValueOrDefault
            ntotal.precioVentaFinalGMayorME = i.PrecioGranMayorME.GetValueOrDefault
            Listatotal.Add(ntotal)
        Next

        Return Listatotal
    End Function

    Public Function GetBusquedaAvanzadaProductos(be As detalleitems, caso As String) As List(Of totalesAlmacen)
        ' Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)

        Select Case caso
            Case "MARCA"
                Listatotal = listaProductosMarca(be)

            Case "CLASIFICACION"
                Listatotal = ListaXGrupo(be)
        End Select
        Return Listatotal

    End Function

    Public Function GetInventarioParaVentaAcumulado(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen)
        GetInventarioParaVentaAcumulado = New List(Of totalesAlmacen)
        Select Case objTotalBE.Moneda
            Case "SOL"
                GetInventarioParaVentaAcumulado.AddRange(GentVentaEnSoles(objTotalBE))
            Case "USD"
                GetInventarioParaVentaAcumulado.AddRange(GetVentaEnDolares(objTotalBE))
        End Select

        'Dim ntotal As New totalesAlmacen
        'Dim Listatotal As New List(Of totalesAlmacen)
        'Dim consunlta = (From t In HeliosData.totalesAlmacen
        '                 Join alm In HeliosData.almacen On t.idAlmacen Equals alm.idAlmacen
        '                 Join articulo In HeliosData.detalleitems On t.idItem Equals articulo.codigodetalle
        '                 Group Join marca In HeliosData.item On marca.idItem Equals articulo.unidad2
        '                     Into marca_join = Group
        '                 From marca In marca_join.DefaultIfEmpty()
        '                 Where
        '                     alm.tipo <> "AV" And
        '                     articulo.tipoExistencia = objTotalBE.tipoExistencia And
        '                     articulo.descripcionItem.Contains(objTotalBE.descripcion) And
        '                     t.status = StatusArticulo.Activo And
        '                     articulo.estado = "A"
        '                 Group New With {articulo, t} By
        '                     t.idEmpresa,
        '                     alm.idEstablecimiento,
        '                     alm.idAlmacen,
        '                     alm.descripcionAlmacen,
        '                     articulo.codigodetalle,
        '                     marcaName = marca.descripcion,
        '                     articulo.origenProducto,
        '                     articulo.tipoExistencia,
        '                     articulo.descripcionItem,
        '                     articulo.unidad1,
        '              precioMenor = (
        '              ((From configuracionPrecioProductoes In HeliosData.configuracionPrecioProducto
        '                Where
        '                     configuracionPrecioProductoes.idproducto = t.idItem And
        '                     CLng(configuracionPrecioProductoes.idPrecio) = 1 And
        '                     configuracionPrecioProductoes.fecha = (Aggregate t2 In
        '                                                                (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
        '                                                                 Where
        '                                                                     CLng(configuracionPrecioProductoes0.idPrecio) = 1 And
        '                                                                     configuracionPrecioProductoes0.idproducto = t.idItem
        '                                                                 Select configuracionPrecioProductoes0) Into Max(t2.fecha))
        '                Select New With {
        '                     configuracionPrecioProductoes.precioMN
        '                     }).FirstOrDefault().precioMN)),
        '               precioMayor = (
        '               ((From configuracionPrecioProductoes In HeliosData.configuracionPrecioProducto
        '                 Where
        '                     configuracionPrecioProductoes.idproducto = t.idItem And
        '                     CLng(configuracionPrecioProductoes.idPrecio) = 2 And
        '                     configuracionPrecioProductoes.fecha = (Aggregate t2 In
        '                                                                (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
        '                                                                 Where
        '                                                                     CLng(configuracionPrecioProductoes0.idPrecio) = 2 And
        '                                                                     configuracionPrecioProductoes0.idproducto = t.idItem
        '                                                                 Select configuracionPrecioProductoes0) Into Max(t2.fecha))
        '                 Select New With {
        '                     configuracionPrecioProductoes.precioMN
        '                     }).FirstOrDefault().precioMN)),
        '               precioGranMayor = (
        '               ((From configuracionPrecioProductoes In HeliosData.configuracionPrecioProducto
        '                 Where
        '                     configuracionPrecioProductoes.idproducto = t.idItem And
        '                     CLng(configuracionPrecioProductoes.idPrecio) = 3 And
        '                     configuracionPrecioProductoes.fecha =
        '                     (Aggregate t2 In
        '                          (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
        '                           Where
        '                               CLng(configuracionPrecioProductoes0.idPrecio) = 3 And
        '                               configuracionPrecioProductoes0.idproducto = t.idItem
        '                           Select configuracionPrecioProductoes0) Into Max(t2.fecha))
        '                 Select New With {
        '                     configuracionPrecioProductoes.precioMN,
        '                     configuracionPrecioProductoes.precioME
        '                     }).FirstOrDefault().precioMN))
        '              Into g = Group
        '                 Order By
        '              descripcionItem
        '                 Select
        '              idEmpresa,
        '                     marcaName,
        '              idEstablecimiento,
        '              idAlmacen,
        '              descripcionAlmacen,
        '              codigodetalle,
        '              origenProducto,
        '              tipoExistencia,
        '              descripcionItem,
        '              unidad1,
        '              precioMenor,
        '              precioMayor,
        '              precioGranMayor,
        '              Stock = CType(g.Sum(Function(p) p.t.cantidad), Decimal?)).ToList


        'For Each i In consunlta
        '    ntotal = New totalesAlmacen
        '    ntotal.idEmpresa = i.idEmpresa
        '    ntotal.idEstablecimiento = i.idEstablecimiento
        '    ntotal.idAlmacen = i.idAlmacen
        '    ntotal.NomAlmacen = i.descripcionAlmacen
        '    ntotal.idItem = i.codigodetalle
        '    ntotal.origenRecaudo = i.origenProducto
        '    ntotal.tipoExistencia = i.tipoExistencia
        '    ntotal.descripcion = i.descripcionItem
        '    ntotal.idUnidad = i.unidad1
        '    ntotal.unidadMedida = i.unidad1 ' i.tbl.descripcion
        '    ntotal.cantidad = i.Stock.GetValueOrDefault
        '    ntotal.Marca = i.marcaName
        '    ntotal.precioVentaFinalMenorMN = i.precioMenor.GetValueOrDefault
        '    ntotal.precioVentaFinalMayorMN = i.precioMayor.GetValueOrDefault
        '    ntotal.precioVentaFinalGMayorMN = i.precioGranMayor.GetValueOrDefault
        '    Listatotal.Add(ntotal)
        'Next

        'Return Listatotal

    End Function

    Public Function GentVentaEnSoles(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen)
        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)
        Dim consunlta = (From t In HeliosData.totalesAlmacen
                         Join alm In HeliosData.almacen On t.idAlmacen Equals alm.idAlmacen
                         Join articulo In HeliosData.detalleitems On t.idItem Equals articulo.codigodetalle
                         Group Join marca In HeliosData.item On marca.idItem Equals articulo.unidad2
                             Into marca_join = Group
                         From marca In marca_join.DefaultIfEmpty()
                         Where
                             alm.tipo <> "AV" And
                             articulo.tipoExistencia = objTotalBE.tipoExistencia And
                             articulo.descripcionItem.Contains(objTotalBE.descripcion) And
                             t.status = StatusArticulo.Activo And
                             articulo.estado = "A"
                         Group New With {articulo, t} By
                             t.idEmpresa,
                             alm.idEstablecimiento,
                             alm.idAlmacen,
                             alm.descripcionAlmacen,
                             articulo.codigodetalle,
                             marcaName = marca.descripcion,
                             articulo.origenProducto,
                             articulo.tipoExistencia,
                             articulo.descripcionItem,
                             articulo.unidad1,
                      precioMenor = (
                      ((From configuracionPrecioProductoes In HeliosData.configuracionPrecioProducto
                        Where
                             configuracionPrecioProductoes.idproducto = t.idItem And
                             CLng(configuracionPrecioProductoes.idPrecio) = 1 And
                             configuracionPrecioProductoes.fecha = (Aggregate t2 In
                                                                        (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                                                         Where
                                                                             CLng(configuracionPrecioProductoes0.idPrecio) = 1 And
                                                                             configuracionPrecioProductoes0.idproducto = t.idItem
                                                                         Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                        Select New With {
                             configuracionPrecioProductoes.precioMN
                             }).FirstOrDefault().precioMN)),
                       precioMayor = (
                       ((From configuracionPrecioProductoes In HeliosData.configuracionPrecioProducto
                         Where
                             configuracionPrecioProductoes.idproducto = t.idItem And
                             CLng(configuracionPrecioProductoes.idPrecio) = 2 And
                             configuracionPrecioProductoes.fecha = (Aggregate t2 In
                                                                        (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                                                         Where
                                                                             CLng(configuracionPrecioProductoes0.idPrecio) = 2 And
                                                                             configuracionPrecioProductoes0.idproducto = t.idItem
                                                                         Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                         Select New With {
                             configuracionPrecioProductoes.precioMN
                             }).FirstOrDefault().precioMN)),
                       precioGranMayor = (
                       ((From configuracionPrecioProductoes In HeliosData.configuracionPrecioProducto
                         Where
                             configuracionPrecioProductoes.idproducto = t.idItem And
                             CLng(configuracionPrecioProductoes.idPrecio) = 3 And
                             configuracionPrecioProductoes.fecha =
                             (Aggregate t2 In
                                  (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                   Where
                                       CLng(configuracionPrecioProductoes0.idPrecio) = 3 And
                                       configuracionPrecioProductoes0.idproducto = t.idItem
                                   Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                         Select New With {
                             configuracionPrecioProductoes.precioMN,
                             configuracionPrecioProductoes.precioME
                             }).FirstOrDefault().precioMN))
                      Into g = Group
                         Order By
                      descripcionItem
                         Select
                      idEmpresa,
                             marcaName,
                      idEstablecimiento,
                      idAlmacen,
                      descripcionAlmacen,
                      codigodetalle,
                      origenProducto,
                      tipoExistencia,
                      descripcionItem,
                      unidad1,
                      precioMenor,
                      precioMayor,
                      precioGranMayor,
                      Stock = CType(g.Sum(Function(p) p.t.cantidad), Decimal?)).ToList


        For Each i In consunlta
            ntotal = New totalesAlmacen
            ntotal.idEmpresa = i.idEmpresa
            ntotal.idEstablecimiento = i.idEstablecimiento
            ntotal.idAlmacen = i.idAlmacen
            ntotal.NomAlmacen = i.descripcionAlmacen
            ntotal.idItem = i.codigodetalle
            ntotal.origenRecaudo = i.origenProducto
            ntotal.tipoExistencia = i.tipoExistencia
            ntotal.descripcion = i.descripcionItem
            ntotal.idUnidad = i.unidad1
            ntotal.unidadMedida = i.unidad1 ' i.tbl.descripcion
            ntotal.cantidad = i.Stock.GetValueOrDefault
            ntotal.Marca = i.marcaName
            ntotal.precioVentaFinalMenorMN = i.precioMenor.GetValueOrDefault
            ntotal.precioVentaFinalMayorMN = i.precioMayor.GetValueOrDefault
            ntotal.precioVentaFinalGMayorMN = i.precioGranMayor.GetValueOrDefault
            Listatotal.Add(ntotal)
        Next

        Return Listatotal

    End Function

    Public Function GetVentaEnDolares(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen)
        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)
        Dim consunlta = (From t In HeliosData.totalesAlmacen
                         Join alm In HeliosData.almacen On t.idAlmacen Equals alm.idAlmacen
                         Join articulo In HeliosData.detalleitems On t.idItem Equals articulo.codigodetalle
                         Group Join marca In HeliosData.item On marca.idItem Equals articulo.unidad2
                             Into marca_join = Group
                         From marca In marca_join.DefaultIfEmpty()
                         Where
                             alm.tipo <> "AV" And
                             articulo.tipoExistencia = objTotalBE.tipoExistencia And
                             articulo.descripcionItem.Contains(objTotalBE.descripcion) And
                             t.status = StatusArticulo.Activo And
                             articulo.estado = "A"
                         Group New With {articulo, t} By
                             t.idEmpresa,
                             alm.idEstablecimiento,
                             alm.idAlmacen,
                             alm.descripcionAlmacen,
                             articulo.codigodetalle,
                             marcaName = marca.descripcion,
                             articulo.origenProducto,
                             articulo.tipoExistencia,
                             articulo.descripcionItem,
                             articulo.unidad1,
                      precioMenor = (
                      ((From configuracionPrecioProductoes In HeliosData.configuracionPrecioProducto
                        Where
                             configuracionPrecioProductoes.idproducto = t.idItem And
                             CLng(configuracionPrecioProductoes.idPrecio) = 1 And
                             configuracionPrecioProductoes.fecha = (Aggregate t2 In
                                                                        (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                                                         Where
                                                                             CLng(configuracionPrecioProductoes0.idPrecio) = 1 And
                                                                             configuracionPrecioProductoes0.idproducto = t.idItem
                                                                         Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                        Select New With {
                             configuracionPrecioProductoes.precioME
                             }).FirstOrDefault().precioMe)),
                       precioMayor = (
                       ((From configuracionPrecioProductoes In HeliosData.configuracionPrecioProducto
                         Where
                             configuracionPrecioProductoes.idproducto = t.idItem And
                             CLng(configuracionPrecioProductoes.idPrecio) = 2 And
                             configuracionPrecioProductoes.fecha = (Aggregate t2 In
                                                                        (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                                                         Where
                                                                             CLng(configuracionPrecioProductoes0.idPrecio) = 2 And
                                                                             configuracionPrecioProductoes0.idproducto = t.idItem
                                                                         Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                         Select New With {
                             configuracionPrecioProductoes.precioME
                             }).FirstOrDefault().precioME)),
                       precioGranMayor = (
                       ((From configuracionPrecioProductoes In HeliosData.configuracionPrecioProducto
                         Where
                             configuracionPrecioProductoes.idproducto = t.idItem And
                             CLng(configuracionPrecioProductoes.idPrecio) = 3 And
                             configuracionPrecioProductoes.fecha =
                             (Aggregate t2 In
                                  (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                   Where
                                       CLng(configuracionPrecioProductoes0.idPrecio) = 3 And
                                       configuracionPrecioProductoes0.idproducto = t.idItem
                                   Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                         Select New With {
                             configuracionPrecioProductoes.precioME
                             }).FirstOrDefault().precioME))
                      Into g = Group
                         Order By
                      descripcionItem
                         Select
                      idEmpresa,
                             marcaName,
                      idEstablecimiento,
                      idAlmacen,
                      descripcionAlmacen,
                      codigodetalle,
                      origenProducto,
                      tipoExistencia,
                      descripcionItem,
                      unidad1,
                      precioMenor,
                      precioMayor,
                      precioGranMayor,
                      Stock = CType(g.Sum(Function(p) p.t.cantidad), Decimal?)).ToList


        For Each i In consunlta
            ntotal = New totalesAlmacen
            ntotal.idEmpresa = i.idEmpresa
            ntotal.idEstablecimiento = i.idEstablecimiento
            ntotal.idAlmacen = i.idAlmacen
            ntotal.NomAlmacen = i.descripcionAlmacen
            ntotal.idItem = i.codigodetalle
            ntotal.origenRecaudo = i.origenProducto
            ntotal.tipoExistencia = i.tipoExistencia
            ntotal.descripcion = i.descripcionItem
            ntotal.idUnidad = i.unidad1
            ntotal.unidadMedida = i.unidad1 ' i.tbl.descripcion
            ntotal.cantidad = i.Stock.GetValueOrDefault
            ntotal.Marca = i.marcaName
            ntotal.precioVentaFinalMenorME = i.precioMenor.GetValueOrDefault
            ntotal.precioVentaFinalMayorME = i.precioMayor.GetValueOrDefault
            ntotal.precioVentaFinalGMayorME = i.precioGranMayor.GetValueOrDefault
            Listatotal.Add(ntotal)
        Next

        Return Listatotal

    End Function

    Public Function GetInventarioParaVentaAcumuladoEspecial(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen)
        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)

        'articulo.tipoProducto = "E"

        Dim consunlta = (From articulo In HeliosData.detalleitems
                         Where
                             articulo.tipoExistencia = objTotalBE.tipoExistencia And
                             articulo.descripcionItem.StartsWith(objTotalBE.descripcion) And
                             articulo.estado = "A"
                         Group New With {articulo} By
                                              articulo.codigodetalle,
                                              articulo.origenProducto,
                                              articulo.tipoExistencia,
                                              articulo.descripcionItem,
                                              articulo.unidad1,
                                       precioMenor = (
                                       ((From configuracionPrecioProductoes In HeliosData.configuracionPrecioProducto
                                         Where
                                              configuracionPrecioProductoes.idproducto = articulo.codigodetalle And
                                              CLng(configuracionPrecioProductoes.idPrecio) = 1 And
                                              configuracionPrecioProductoes.fecha = (Aggregate t2 In
                                                                                         (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                                                                          Where
                                                                                              CLng(configuracionPrecioProductoes0.idPrecio) = 1 And
                                                                                              configuracionPrecioProductoes0.idproducto = articulo.codigodetalle
                                                                                          Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                                         Select New With {
                                              configuracionPrecioProductoes.precioMN
                                              }).FirstOrDefault().precioMN)),
                                        precioMayor = (
                                        ((From configuracionPrecioProductoes In HeliosData.configuracionPrecioProducto
                                          Where
                                              configuracionPrecioProductoes.idproducto = articulo.codigodetalle And
                                              CLng(configuracionPrecioProductoes.idPrecio) = 2 And
                                              configuracionPrecioProductoes.fecha = (Aggregate t2 In
                                                                                         (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                                                                          Where
                                                                                              CLng(configuracionPrecioProductoes0.idPrecio) = 2 And
                                                                                              configuracionPrecioProductoes0.idproducto = articulo.codigodetalle
                                                                                          Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                                          Select New With {
                                              configuracionPrecioProductoes.precioMN
                                              }).FirstOrDefault().precioMN)),
                                        precioGranMayor = (
                                        ((From configuracionPrecioProductoes In HeliosData.configuracionPrecioProducto
                                          Where
                                              configuracionPrecioProductoes.idproducto = articulo.codigodetalle And
                                              CLng(configuracionPrecioProductoes.idPrecio) = 3 And
                                              configuracionPrecioProductoes.fecha = (Aggregate t2 In
                                                                                         (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                                                                          Where
                                                                                              CLng(configuracionPrecioProductoes0.idPrecio) = 3 And
                                                                                              configuracionPrecioProductoes0.idproducto = articulo.codigodetalle
                                                                                          Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                                          Select New With {
                                              configuracionPrecioProductoes.precioMN
                                              }).FirstOrDefault().precioMN))
                                       Into g = Group
                         Order By
                      descripcionItem
                         Select
                      codigodetalle,
                      origenProducto,
                      tipoExistencia,
                      descripcionItem,
                      unidad1,
                      precioMenor,
                      precioMayor,
                      precioGranMayor).ToList


        For Each i In consunlta
            ntotal = New totalesAlmacen
            ntotal.idItem = i.codigodetalle
            ntotal.origenRecaudo = i.origenProducto
            ntotal.tipoExistencia = i.tipoExistencia
            ntotal.descripcion = i.descripcionItem
            ntotal.idUnidad = i.unidad1
            ntotal.unidadMedida = i.unidad1 ' i.tbl.descripcion
            ntotal.precioVentaFinalMenorMN = i.precioMenor.GetValueOrDefault
            ntotal.precioVentaFinalMayorMN = i.precioMayor.GetValueOrDefault
            ntotal.precioVentaFinalGMayorMN = i.precioGranMayor.GetValueOrDefault
            Listatotal.Add(ntotal)
        Next

        Return Listatotal

    End Function

    Public Function GetProductsShopingOrOthers(objTotalBE As totalesAlmacen) As List(Of usp_GetProductsByEstable_Result)

        Return HeliosData.usp_GetProductsByEstable(objTotalBE.tipoExistencia, objTotalBE.descripcion).ToList

    End Function


    Public Function GetInventarioParaVentaAcumuladoForma2(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen)
        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)

        Dim consunlta = (From t In HeliosData.totalesAlmacen
                         Join alm In HeliosData.almacen On t.idAlmacen Equals alm.idAlmacen
                         Join articulo In HeliosData.detalleitems On t.idItem Equals articulo.codigodetalle
                         Group Join marca In HeliosData.item On marca.idItem Equals articulo.unidad2
                             Into marca_join = Group
                         From marca In marca_join.DefaultIfEmpty()
                         Where
                             alm.tipo <> "AV" And
                             articulo.tipoExistencia = objTotalBE.tipoExistencia And
                             articulo.descripcionItem.StartsWith(objTotalBE.descripcion) And
                             t.status = StatusArticulo.Activo And
                             articulo.estado = "A"
                         Group New With {articulo, t} By
                             t.idEmpresa,
                              marcaName = marca.descripcion,
                             alm.idEstablecimiento,
                             alm.idAlmacen,
                             alm.descripcionAlmacen,
                             articulo.codigodetalle,
                             articulo.origenProducto,
                             articulo.tipoExistencia,
                             articulo.descripcionItem,
                             articulo.unidad1,
                      precioMenor = (
                      ((From configuracionPrecioProductoes In HeliosData.configuracionPrecioProducto
                        Where
                             configuracionPrecioProductoes.idproducto = t.idItem And
                             CLng(configuracionPrecioProductoes.idPrecio) = 1 And
                             configuracionPrecioProductoes.fecha = (Aggregate t2 In
                                                                        (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                                                         Where
                                                                             CLng(configuracionPrecioProductoes0.idPrecio) = 1 And
                                                                             configuracionPrecioProductoes0.idproducto = t.idItem
                                                                         Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                        Select New With {
                             configuracionPrecioProductoes.precioMN
                             }).FirstOrDefault().precioMN)),
                       precioMayor = (
                       ((From configuracionPrecioProductoes In HeliosData.configuracionPrecioProducto
                         Where
                             configuracionPrecioProductoes.idproducto = t.idItem And
                             CLng(configuracionPrecioProductoes.idPrecio) = 2 And
                             configuracionPrecioProductoes.fecha = (Aggregate t2 In
                                                                        (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                                                         Where
                                                                             CLng(configuracionPrecioProductoes0.idPrecio) = 2 And
                                                                             configuracionPrecioProductoes0.idproducto = t.idItem
                                                                         Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                         Select New With {
                             configuracionPrecioProductoes.precioMN
                             }).FirstOrDefault().precioMN)),
                       precioGranMayor = (
                       ((From configuracionPrecioProductoes In HeliosData.configuracionPrecioProducto
                         Where
                             configuracionPrecioProductoes.idproducto = t.idItem And
                             CLng(configuracionPrecioProductoes.idPrecio) = 3 And
                             configuracionPrecioProductoes.fecha = (Aggregate t2 In
                                                                        (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                                                         Where
                                                                             CLng(configuracionPrecioProductoes0.idPrecio) = 3 And
                                                                             configuracionPrecioProductoes0.idproducto = t.idItem
                                                                         Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                         Select New With {
                             configuracionPrecioProductoes.precioMN
                             }).FirstOrDefault().precioMN))
                      Into g = Group
                         Order By
                      descripcionItem
                         Select
                      idEmpresa,
                             marcaName,
                      idEstablecimiento,
                      idAlmacen,
                      descripcionAlmacen,
                      codigodetalle,
                      origenProducto,
                      tipoExistencia,
                      descripcionItem,
                      unidad1,
                      precioMenor,
                      precioMayor,
                      precioGranMayor,
                      Stock = CType(g.Sum(Function(p) p.t.cantidad), Decimal?)).ToList


        For Each i In consunlta
            ntotal = New totalesAlmacen
            ntotal.idEmpresa = i.idEmpresa
            ntotal.idEstablecimiento = i.idEstablecimiento
            ntotal.idAlmacen = i.idAlmacen
            ntotal.NomAlmacen = i.descripcionAlmacen
            ntotal.idItem = i.codigodetalle
            ntotal.origenRecaudo = i.origenProducto
            ntotal.tipoExistencia = i.tipoExistencia
            ntotal.descripcion = i.descripcionItem
            ntotal.idUnidad = i.unidad1
            ntotal.unidadMedida = i.unidad1 ' i.tbl.descripcion
            ntotal.Marca = i.marcaName
            ntotal.cantidad = i.Stock.GetValueOrDefault
            ntotal.precioVentaFinalMenorMN = i.precioMenor.GetValueOrDefault
            ntotal.precioVentaFinalMayorMN = i.precioMayor.GetValueOrDefault
            ntotal.precioVentaFinalGMayorMN = i.precioGranMayor.GetValueOrDefault
            Listatotal.Add(ntotal)
        Next

        Return Listatotal

    End Function

    Public Function GetInventarioParaVentaAcumuladoDolares(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen)
        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)

        Dim consunlta = (From t In HeliosData.totalesAlmacen
                         Join alm In HeliosData.almacen On t.idAlmacen Equals alm.idAlmacen
                         Join articulo In HeliosData.detalleitems On t.idItem Equals articulo.codigodetalle
                         Where
                             alm.tipo <> "AV" And
                             articulo.tipoExistencia = objTotalBE.tipoExistencia And
                             articulo.descripcionItem.Contains(objTotalBE.descripcion) And
                             t.status = StatusArticulo.Activo
                         Group New With {articulo, t} By
                             t.idEmpresa,
                             alm.idEstablecimiento,
                             alm.idAlmacen,
                             alm.descripcionAlmacen,
                             articulo.codigodetalle,
                             articulo.origenProducto,
                             articulo.tipoExistencia,
                             articulo.descripcionItem,
                             articulo.unidad1,
                             precioMenorME = (
                             ((From configuracionPrecioProductoes In HeliosData.configuracionPrecioProducto
                               Where
                             configuracionPrecioProductoes.idproducto = t.idItem And
                             CLng(configuracionPrecioProductoes.idPrecio) = 1 And
                             configuracionPrecioProductoes.fecha =
                            (Aggregate t2 In
                                 (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                  Where
                                      CLng(configuracionPrecioProductoes0.idPrecio) = 1 And configuracionPrecioProductoes0.idproducto = t.idItem
                                  Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                               Select New With {
                             configuracionPrecioProductoes.precioME
                             }).FirstOrDefault().precioME)),
                       precioMayorME = (
                       ((From configuracionPrecioProductoes In HeliosData.configuracionPrecioProducto
                         Where
                             configuracionPrecioProductoes.idproducto = t.idItem And
                             CLng(configuracionPrecioProductoes.idPrecio) = 2 And
                             configuracionPrecioProductoes.fecha = (Aggregate t2 In
                                                                        (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                                                         Where
                                                                             CLng(configuracionPrecioProductoes0.idPrecio) = 2 And
                                                                             configuracionPrecioProductoes0.idproducto = t.idItem
                                                                         Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                         Select New With {
                             configuracionPrecioProductoes.precioME
                             }).FirstOrDefault().precioME)),
                       precioGranMayorME = (
                       ((From configuracionPrecioProductoes In HeliosData.configuracionPrecioProducto
                         Where
                             configuracionPrecioProductoes.idproducto = t.idItem And
                             CLng(configuracionPrecioProductoes.idPrecio) = 3 And
                             configuracionPrecioProductoes.fecha = (Aggregate t2 In
                                                                        (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                                                         Where
                                                                             CLng(configuracionPrecioProductoes0.idPrecio) = 3 And
                                                                             configuracionPrecioProductoes0.idproducto = t.idItem
                                                                         Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                         Select New With {
                             configuracionPrecioProductoes.precioME
                             }).FirstOrDefault().precioME))
                      Into g = Group
                         Order By
                      descripcionItem
                         Select
                      idEmpresa,
                      idEstablecimiento,
                      idAlmacen,
                      descripcionAlmacen,
                      codigodetalle,
                      origenProducto,
                      tipoExistencia,
                      descripcionItem,
                      unidad1,
                      precioMenorME,
                      precioMayorME,
                      precioGranMayorME,
                      Stock = CType(g.Sum(Function(p) p.t.cantidad), Decimal?)).ToList


        For Each i In consunlta
            ntotal = New totalesAlmacen
            ntotal.idEmpresa = i.idEmpresa
            ntotal.idEstablecimiento = i.idEstablecimiento
            ntotal.idAlmacen = i.idAlmacen
            ntotal.NomAlmacen = i.descripcionAlmacen
            ntotal.idItem = i.codigodetalle
            ntotal.origenRecaudo = i.origenProducto
            ntotal.tipoExistencia = i.tipoExistencia
            ntotal.descripcion = i.descripcionItem
            ntotal.idUnidad = i.unidad1
            ntotal.unidadMedida = i.unidad1 ' i.tbl.descripcion
            ntotal.cantidad = i.Stock.GetValueOrDefault
            ntotal.precioVentaFinalMenorMN = i.precioMenorME.GetValueOrDefault
            ntotal.precioVentaFinalMayorMN = i.precioMayorME.GetValueOrDefault
            ntotal.precioVentaFinalGMayorMN = i.precioGranMayorME.GetValueOrDefault
            Listatotal.Add(ntotal)
        Next

        Return Listatotal

    End Function

    Public Function GetInventarioParaVentaAcumuladoCodigo(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen)
        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)

        't.idAlmacen = objTotalBE.idAlmacen And
        Dim consunlta = (From t In HeliosData.totalesAlmacen
                         Join alm In HeliosData.almacen On t.idAlmacen Equals alm.idAlmacen
                         Join articulo In HeliosData.detalleitems On t.idItem Equals articulo.codigodetalle
                         Group Join marca In HeliosData.item On marca.idItem Equals articulo.unidad2
                             Into marca_join = Group
                         From marca In marca_join.DefaultIfEmpty()
                         Where
                             alm.tipo <> "AV" And
                             articulo.codigo = objTotalBE.descripcion And
                             articulo.tipoExistencia = objTotalBE.tipoExistencia And
                             t.status = StatusArticulo.Activo And
                             articulo.estado = "A"
                         Group New With {articulo, t} By
                             t.idEmpresa,
                             alm.idEstablecimiento,
                             alm.idAlmacen,
                             alm.descripcionAlmacen,
                             articulo.codigodetalle,
                             marcaName = marca.descripcion,
                             articulo.origenProducto,
                             articulo.tipoExistencia,
                             articulo.descripcionItem,
                             articulo.unidad1,
                      precioMenor = (
                      ((From configuracionPrecioProductoes In HeliosData.configuracionPrecioProducto
                        Where
                             configuracionPrecioProductoes.idproducto = t.idItem And
                             CLng(configuracionPrecioProductoes.idPrecio) = 1 And
                             configuracionPrecioProductoes.fecha = (Aggregate t2 In
                                                                        (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                                                         Where
                                                                             CLng(configuracionPrecioProductoes0.idPrecio) = 1 And
                                                                             configuracionPrecioProductoes0.idproducto = t.idItem
                                                                         Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                        Select New With {
                             configuracionPrecioProductoes.precioMN
                             }).FirstOrDefault().precioMN)),
                       precioMayor = (
                       ((From configuracionPrecioProductoes In HeliosData.configuracionPrecioProducto
                         Where
                             configuracionPrecioProductoes.idproducto = t.idItem And
                             CLng(configuracionPrecioProductoes.idPrecio) = 2 And
                             configuracionPrecioProductoes.fecha = (Aggregate t2 In
                                                                        (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                                                         Where
                                                                             CLng(configuracionPrecioProductoes0.idPrecio) = 2 And
                                                                             configuracionPrecioProductoes0.idproducto = t.idItem
                                                                         Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                         Select New With {
                             configuracionPrecioProductoes.precioMN
                             }).FirstOrDefault().precioMN)),
                       precioGranMayor = (
                       ((From configuracionPrecioProductoes In HeliosData.configuracionPrecioProducto
                         Where
                             configuracionPrecioProductoes.idproducto = t.idItem And
                             CLng(configuracionPrecioProductoes.idPrecio) = 3 And
                             configuracionPrecioProductoes.fecha =
                             (Aggregate t2 In
                                  (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                   Where
                                       CLng(configuracionPrecioProductoes0.idPrecio) = 3 And
                                       configuracionPrecioProductoes0.idproducto = t.idItem
                                   Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                         Select New With {
                             configuracionPrecioProductoes.precioMN,
                             configuracionPrecioProductoes.precioME
                             }).FirstOrDefault().precioMN))
                      Into g = Group
                         Order By
                      descripcionItem
                         Select
                      idEmpresa,
                             marcaName,
                      idEstablecimiento,
                      idAlmacen,
                      descripcionAlmacen,
                      codigodetalle,
                      origenProducto,
                      tipoExistencia,
                      descripcionItem,
                      unidad1,
                      precioMenor,
                      precioMayor,
                      precioGranMayor,
                      Stock = CType(g.Sum(Function(p) p.t.cantidad), Decimal?)).ToList


        For Each i In consunlta
            ntotal = New totalesAlmacen
            ntotal.idEmpresa = i.idEmpresa
            ntotal.idEstablecimiento = i.idEstablecimiento
            ntotal.idAlmacen = i.idAlmacen
            ntotal.NomAlmacen = i.descripcionAlmacen
            ntotal.idItem = i.codigodetalle
            ntotal.origenRecaudo = i.origenProducto
            ntotal.tipoExistencia = i.tipoExistencia
            ntotal.descripcion = i.descripcionItem
            ntotal.idUnidad = i.unidad1
            ntotal.unidadMedida = i.unidad1 ' i.tbl.descripcion
            ntotal.cantidad = i.Stock.GetValueOrDefault
            ntotal.Marca = i.marcaName
            ntotal.precioVentaFinalMenorMN = i.precioMenor.GetValueOrDefault
            ntotal.precioVentaFinalMayorMN = i.precioMayor.GetValueOrDefault
            ntotal.precioVentaFinalGMayorMN = i.precioGranMayor.GetValueOrDefault
            Listatotal.Add(ntotal)
        Next

        Return Listatotal

    End Function

    Public Function GetDetalleLoteXproducto(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen)
        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)

        Dim obj = (From a In HeliosData.totalesAlmacen
                   Join art In HeliosData.detalleitems
                           On art.codigodetalle Equals a.idItem
                   Join lote In HeliosData.recursoCostoLote On lote.codigoLote Equals a.codigoLote
                   Join alm In HeliosData.almacen On alm.idAlmacen Equals a.idAlmacen
                   Where
                       a.idItem = objTotalBE.idItem And
                       a.idAlmacen = objTotalBE.idAlmacen And
                       a.cantidad > 0 And a.status = StatusArticulo.Activo
                   Order By
                       lote.fechaVcto Ascending
                   Select
                       lote,
                       a.idEmpresa,
                       a.idEstablecimiento,
                       a.idAlmacen,
                       alm.descripcionAlmacen,
                       a.idItem,
                       art.origenProducto,
                       art.tipoExistencia,
                       art.descripcionItem,
                       art.unidad1,
                       a.cantidad,
                       a.importeSoles,
                       a.importeDolares
                       ).ToList

        For Each i In obj
            ntotal = New totalesAlmacen
            ntotal.CustomLote = i.lote
            ntotal.idEmpresa = i.idEmpresa
            ntotal.idEstablecimiento = i.idEstablecimiento
            ntotal.idAlmacen = i.idAlmacen
            ntotal.NomAlmacen = i.descripcionAlmacen
            ntotal.idItem = i.idItem
            ntotal.origenRecaudo = i.origenProducto
            ntotal.tipoExistencia = i.tipoExistencia
            ntotal.descripcion = i.descripcionItem
            ntotal.idUnidad = i.unidad1
            ntotal.unidadMedida = i.unidad1 ' i.tbl.descripcion
            ntotal.cantidad = i.cantidad
            ntotal.importeSoles = i.importeSoles
            ntotal.importeDolares = i.importeDolares
            Listatotal.Add(ntotal)
        Next

        Return Listatotal

    End Function

    'Public Function GetProductoTotal(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen)
    '    Dim ntotal As New totalesAlmacen
    '    Dim Listatotal As New List(Of totalesAlmacen)

    '    Dim obj = (From a In HeliosData.totalesAlmacen
    '               Join lote In HeliosData.recursoCostoLote On lote.codigoLote Equals a.codigoLote
    '               Join alm In HeliosData.almacen On alm.idAlmacen Equals a.idAlmacen
    '               Where
    '                   a.idItem = objTotalBE.idItem And
    '                   a.idAlmacen = objTotalBE.idAlmacen And
    '                   a.cantidad > 0 And a.status = StatusArticulo.Activo
    '               Order By
    '                   lote.fechaVcto Ascending
    '               Select
    '                   lote,
    '                   a.idEmpresa,
    '                   a.idEstablecimiento,
    '                   a.idAlmacen,
    '                   alm.descripcionAlmacen,
    '                   a.idItem,
    '                   a.origenRecaudo,
    '                   a.tipoExistencia,
    '                   a.descripcion,
    '                   a.unidadMedida,
    '                   a.cantidad,
    '                   a.importeSoles,
    '                   a.importeDolares
    '                   ).ToList

    '    For Each i In obj
    '        ntotal = New totalesAlmacen
    '        ntotal.CustomLote = i.lote
    '        ntotal.idEmpresa = i.idEmpresa
    '        ntotal.idEstablecimiento = i.idEstablecimiento
    '        ntotal.idAlmacen = i.idAlmacen
    '        ntotal.NomAlmacen = i.descripcionAlmacen
    '        ntotal.idItem = i.idItem
    '        ntotal.origenRecaudo = i.origenRecaudo
    '        ntotal.tipoExistencia = i.tipoExistencia
    '        ntotal.descripcion = i.descripcion
    '        ntotal.idUnidad = i.unidadMedida
    '        ntotal.unidadMedida = i.unidadMedida ' i.tbl.descripcion
    '        ntotal.cantidad = i.cantidad
    '        ntotal.importeSoles = i.importeSoles
    '        ntotal.importeDolares = i.importeDolares
    '        Listatotal.Add(ntotal)
    '    Next

    '    Return Listatotal

    'End Function

    Public Function GetDetalleLoteXproductoFullAlmacen(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen)
        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)

        Dim obj = (From a In HeliosData.totalesAlmacen
                   Join art In HeliosData.detalleitems
                           On art.codigodetalle Equals a.idItem
                   Join lote In HeliosData.recursoCostoLote On lote.codigoLote Equals a.codigoLote
                   Join alm In HeliosData.almacen On alm.idAlmacen Equals a.idAlmacen
                   Where
                       a.idEmpresa = objTotalBE.idEmpresa And
                       alm.tipo <> "AV" And
                       a.idItem = objTotalBE.idItem And
                       a.cantidad > 0 And a.status = StatusArticulo.Activo
                   Take 10 Order By lote.fechaentrada Descending
                   Select
                       lote,
                       a.idEmpresa,
                       a.idEstablecimiento,
                       a.idAlmacen,
                       alm.descripcionAlmacen,
                       a.idItem,
                       art.origenProducto,
                       art.tipoExistencia,
                       art.descripcionItem,
                       art.unidad1,
                       a.cantidad,
                       a.importeSoles,
                       a.importeDolares
                       ).ToList

        For Each i In obj
            ntotal = New totalesAlmacen
            ntotal.CustomLote = i.lote
            ntotal.idEmpresa = i.idEmpresa
            ntotal.idEstablecimiento = i.idEstablecimiento
            ntotal.idAlmacen = i.idAlmacen
            ntotal.NomAlmacen = i.descripcionAlmacen
            ntotal.idItem = i.idItem
            ntotal.origenRecaudo = i.origenProducto
            ntotal.tipoExistencia = i.tipoExistencia
            ntotal.descripcion = i.descripcionItem
            ntotal.idUnidad = i.unidad1
            ntotal.unidadMedida = i.unidad1 ' i.tbl.descripcion
            ntotal.cantidad = i.cantidad
            ntotal.importeSoles = i.importeSoles
            ntotal.importeDolares = i.importeDolares
            Listatotal.Add(ntotal)
        Next

        Return Listatotal

    End Function

    Public Function GetListadoProductosParaVentaXproducto(objTotalBE As totalesAlmacen) As List(Of totalesAlmacen)
        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)

        Dim obj = (From a In HeliosData.totalesAlmacen
                   Join alm In HeliosData.almacen On alm.idAlmacen Equals a.idAlmacen
                   Join articulo In HeliosData.detalleitems On articulo.codigodetalle Equals a.idItem
                   Join lote In HeliosData.recursoCostoLote On lote.codigoLote Equals a.codigoLote
                   Where alm.tipo <> "AV" And a.tipoExistencia = objTotalBE.tipoExistencia _
                       And a.descripcion.Contains(objTotalBE.descripcion)
                   Select
                       lote,
                       a.idEmpresa,
                       alm.idEstablecimiento,
                       a.idAlmacen,
                       alm.descripcionAlmacen,
                       a.idItem,
                       articulo.origenProducto,
                       articulo.tipoExistencia,
                       articulo.descripcionItem,
                       articulo.unidad1,
                       a.cantidad,
                       a.importeSoles,
                       a.importeDolares,
                      precioMenor = (
                       ((From configuracionPrecioProductoes In HeliosData.configuracionPrecioProducto
                         Where
                             configuracionPrecioProductoes.idproducto = a.idItem And
                             CLng(configuracionPrecioProductoes.idPrecio) = 1 And
                             configuracionPrecioProductoes.fecha = (Aggregate t2 In
                                                                        (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                                                         Where
                                                                             CLng(configuracionPrecioProductoes0.idPrecio) = 1 And
                                                                             configuracionPrecioProductoes0.idproducto = a.idItem
                                                                         Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                         Select New With {
                             configuracionPrecioProductoes.precioMN
                             }).FirstOrDefault().precioMN)),
                       precioMayor = (
                       ((From configuracionPrecioProductoes In HeliosData.configuracionPrecioProducto
                         Where
                             configuracionPrecioProductoes.idproducto = a.idItem And
                             CLng(configuracionPrecioProductoes.idPrecio) = 2 And
                             configuracionPrecioProductoes.fecha = (Aggregate t2 In
                                                                        (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                                                         Where
                                                                             CLng(configuracionPrecioProductoes0.idPrecio) = 2 And
                                                                             configuracionPrecioProductoes0.idproducto = a.idItem
                                                                         Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                         Select New With {
                             configuracionPrecioProductoes.precioMN
                             }).FirstOrDefault().precioMN)),
                       precioGranMayor = (
                       ((From configuracionPrecioProductoes In HeliosData.configuracionPrecioProducto
                         Where
                             configuracionPrecioProductoes.idproducto = a.idItem And
                             CLng(configuracionPrecioProductoes.idPrecio) = 3 And
                             configuracionPrecioProductoes.fecha = (Aggregate t2 In
                                                                        (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                                                         Where
                                                                             CLng(configuracionPrecioProductoes0.idPrecio) = 3 And
                                                                             configuracionPrecioProductoes0.idproducto = a.idItem
                                                                         Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                         Select New With {
                             configuracionPrecioProductoes.precioMN
                             }).FirstOrDefault().precioMN))
                       ).ToList

        For Each i In obj
            ntotal = New totalesAlmacen
            ntotal.CustomLote = i.lote
            ntotal.idEmpresa = i.idEmpresa
            ntotal.idEstablecimiento = i.idEstablecimiento
            ntotal.idAlmacen = i.idAlmacen
            ntotal.NomAlmacen = i.descripcionAlmacen
            ntotal.idItem = i.idItem
            ntotal.origenRecaudo = i.origenProducto
            ntotal.tipoExistencia = i.tipoExistencia
            ntotal.descripcion = i.descripcionItem
            ntotal.idUnidad = i.unidad1
            ntotal.unidadMedida = i.unidad1 ' i.tbl.descripcion
            ntotal.cantidad = i.cantidad
            ntotal.importeSoles = i.importeSoles
            ntotal.importeDolares = i.importeDolares
            ntotal.precioVentaFinalMenorMN = i.precioMenor.GetValueOrDefault
            ntotal.precioVentaFinalMayorMN = i.precioMayor.GetValueOrDefault
            ntotal.precioVentaFinalGMayorMN = i.precioGranMayor.GetValueOrDefault

            'ntotal.idEmpresa = i.a.idEmpresa
            'ntotal.idEstablecimiento = i.alm.idEstablecimiento
            'ntotal.idAlmacen = i.a.idAlmacen
            'ntotal.NomAlmacen = i.alm.descripcionAlmacen
            'ntotal.idItem = i.a.idItem
            'ntotal.origenRecaudo = i.articulo.origenProducto
            'ntotal.tipoExistencia = i.articulo.tipoExistencia
            'ntotal.descripcion = i.articulo.descripcionItem
            'ntotal.idUnidad = i.articulo.unidad1
            'ntotal.unidadMedida = i.articulo.unidad1 ' i.tbl.descripcion
            'ntotal.cantidad = i.a.cantidad
            'ntotal.importeSoles = i.a.importeSoles
            'ntotal.importeDolares = i.a.importeDolares
            '  ntotal.Presentacion = i.Presentacion

            Listatotal.Add(ntotal)
        Next

        Return Listatotal

    End Function

    Public Function GetListadoProductosParaVentaXbarCode(objTotalBE As totalesAlmacen) As totalesAlmacen

        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)

        Dim i = (From a In HeliosData.totalesAlmacen
                Where a.idAlmacen = objTotalBE.idAlmacen And _
                a.idItem = objTotalBE.idItem).FirstOrDefault

        ntotal = New totalesAlmacen
        ntotal.idEstablecimiento = i.idEstablecimiento
        ntotal.idAlmacen = i.idAlmacen
        ntotal.NomAlmacen = objTotalBE.NomAlmacen
        ntotal.idItem = i.idItem
        ntotal.origenRecaudo = i.origenRecaudo
        ntotal.tipoExistencia = i.tipoExistencia
        ntotal.descripcion = i.descripcion
        ntotal.idUnidad = i.idUnidad
        ntotal.unidadMedida = i.idUnidad ' i.tbl.descripcion
        ntotal.cantidad = i.cantidad
        ntotal.importeSoles = i.importeSoles
        ntotal.importeDolares = i.importeDolares

        Return ntotal

    End Function

    Public Function GetUbicarProductoTAlmacen(intIdAlmacen As Integer, intIdItem As Integer) As totalesAlmacen
        Dim ntotal As New totalesAlmacen
        Dim obj = (From a In HeliosData.totalesAlmacen
                   Join prod In HeliosData.detalleitems
                On a.idItem Equals prod.codigodetalle
                   Where a.idAlmacen = intIdAlmacen _
                 And a.idItem = intIdItem
                   Order By prod.descripcionItem Ascending).FirstOrDefault

        If Not IsNothing(obj) Then

            ntotal = New totalesAlmacen
            ntotal.tipoExistencia = obj.a.tipoExistencia
            ntotal.origenRecaudo = obj.a.origenRecaudo
            ntotal.idEstablecimiento = obj.a.idEstablecimiento
            ntotal.idAlmacen = obj.a.idAlmacen
            ntotal.idItem = obj.a.idItem
            ntotal.descripcion = obj.prod.descripcionItem
            ntotal.idUnidad = obj.prod.unidad1
            ntotal.unidadMedida = obj.a.idUnidad
            ntotal.cantidad = obj.a.cantidad
            ntotal.importeSoles = obj.a.importeSoles
            ntotal.importeDolares = obj.a.importeDolares
            ntotal.Presentacion = obj.prod.presentacion
            Return ntotal
        Else
            Return Nothing
        End If
    End Function

    Public Function GetUbicarTotalesAlmacen(strIdEmpresa As String, intIdEstablecimiento As Integer, strIdAlmacen As Integer) As List(Of totalesAlmacen)
        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)
        Dim obj = (From a In HeliosData.totalesAlmacen
                   Join b In HeliosData.almacen
                   On a.idAlmacen Equals b.idAlmacen
               Where a.idEmpresa = strIdEmpresa And
               a.idEstablecimiento = intIdEstablecimiento And
               a.idItem = strIdAlmacen And
               b.tipo = "AF").ToList

        For Each items In obj
            ntotal = New totalesAlmacen
            ntotal.idMovimiento = items.a.idMovimiento
            ntotal.idEmpresa = items.a.idEmpresa
            ntotal.idEstablecimiento = items.a.idEstablecimiento
            ntotal.idItem = items.a.idItem
            ntotal.descripcion = items.a.descripcion
            ntotal.cantidad = items.a.cantidad
            ntotal.idAlmacen = items.a.idAlmacen
            ntotal.NomAlmacen = items.b.descripcionAlmacen

            Listatotal.Add(ntotal)
        Next
        Return Listatotal
    End Function

    Public Sub UpdateTotalesAlmacen(ByVal objDeleteLiquidacion As List(Of totalesAlmacen), ByVal objDocumento As Integer)
        Dim objNuevo As New totalesAlmacen()
        Dim documento As New documentoBL
        Dim notificacionAlmacenDetalleBL As New notificacionAlmacenDetalleBL
        Dim notificacionAlmacen As New notificacionAlmacenBL
        Try
            Using ts As New TransactionScope()

                For Each i In objDeleteLiquidacion
                    objNuevo = HeliosData.totalesAlmacen.Where(Function(o) o.idEmpresa = i.idEmpresa And _
                                                           o.idEstablecimiento = i.idEstablecimiento And _
                                                           o.idAlmacen = i.idAlmacen And _
                                                           o.idItem = i.idItem).FirstOrDefault
                    If Not IsNothing(objNuevo) Then
                        If (objNuevo.cantidad < i.cantidad) Then
                            objNuevo.cantidad = CDec(objNuevo.cantidad) - CDec(objNuevo.cantidad)
                            objNuevo.precioUnitarioCompra = CDec(objNuevo.precioUnitarioCompra).ToString("N2") - CDec(objNuevo.precioUnitarioCompra).ToString("N2")
                            objNuevo.importeSoles = CDec(objNuevo.importeSoles).ToString("N2") - CDec(objNuevo.importeSoles).ToString("N2")
                            objNuevo.importeDolares = CDec(objNuevo.importeDolares).ToString("N2") - CDec(objNuevo.importeDolares).ToString("N2")
                            objNuevo.montoIsc = CDec(objNuevo.montoIsc).ToString("N2") - CDec(objNuevo.montoIsc).ToString("N2")
                            objNuevo.montoIscUS = CDec(objNuevo.montoIscUS).ToString("N2") - CDec(objNuevo.montoIscUS).ToString("N2")
                            'HeliosData.ObjectStateManager.GetObjectStateEntry(objNuevo).State.ToString()
                        Else
                            objNuevo.cantidad = CDec(i.cantidad) - CDec(objNuevo.cantidad)
                            objNuevo.precioUnitarioCompra = CDec(i.precioUnitarioCompra).ToString("N2") - CDec(objNuevo.precioUnitarioCompra).ToString("N2")
                            objNuevo.importeSoles = CDec(i.importeSoles).ToString("N2") - CDec(objNuevo.importeSoles).ToString("N2")
                            objNuevo.importeDolares = CDec(i.importeDolares).ToString("N2") - CDec(objNuevo.importeDolares).ToString("N2")
                            objNuevo.montoIsc = CDec(i.montoIsc).ToString("N2") - CDec(objNuevo.montoIsc).ToString("N2")
                            objNuevo.montoIscUS = CDec(i.montoIscUS).ToString("N2") - CDec(objNuevo.montoIscUS).ToString("N2")
                            'HeliosData.ObjectStateManager.GetObjectStateEntry(objNuevo).State.ToString()
                        End If
                    End If
                    notificacionAlmacenDetalleBL.Insert2(objNuevo, i.idMovimiento, objDocumento)
                    'HeliosData.ObjectStateManager.GetObjectStateEntry(objNuevo).State.ToString()
                Next
                documento.DeleteSingleVariable(objDeleteLiquidacion(0).idMovimiento)
                notificacionAlmacen.UpdateSingle(objDocumento)
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function UpdateTotalesAlmacen2(ByVal objDeleteLiquidacion As List(Of totalesAlmacen), ByVal objDocumento As Integer) As Boolean
        Dim objNuevo As New totalesAlmacen()
        Dim documentoCompraDetBL As New documentocompradetalleBL
        Dim docuemntoCompraBL As New documentocompraBL
        Dim notificacionAlmacenDealleBL As New notificacionAlmacenDetalleBL
        Dim notificacionAlmacenBL As New notificacionAlmacenBL
        Dim documentoBL As New documentoBL
        Dim resultadoNotificacion As Boolean
        Dim conteoItemNotificacion As Integer = 0
        Try
            Using ts As New TransactionScope()

                For Each i In objDeleteLiquidacion

                    objNuevo = HeliosData.totalesAlmacen.Where(Function(o) o.idEmpresa = i.idEmpresa And _
                                                           o.idEstablecimiento = i.idEstablecimiento And _
                                                           o.idAlmacen = i.idAlmacen And _
                                                           o.idItem = i.idItem).FirstOrDefault
                    If Not IsNothing(objNuevo) Then
                        If (CInt(i.cantidad < objNuevo.cantidad)) Then
                            notificacionAlmacenDealleBL.Insert(i, i.idMovimiento, objDocumento)
                            documentoCompraDetBL.UpdateSingle2(i, i.idMovimiento)

                            objNuevo.cantidad = CDec(objNuevo.cantidad) - CDec(i.cantidad)
                            objNuevo.precioUnitarioCompra = CDec(objNuevo.precioUnitarioCompra).ToString("N2") - CDec(i.precioUnitarioCompra).ToString("N2")
                            objNuevo.importeSoles = CDec(objNuevo.importeSoles).ToString("N2") - CDec(i.importeSoles).ToString("N2")
                            objNuevo.importeDolares = CDec(objNuevo.importeDolares).ToString("N2") - CDec(i.importeDolares).ToString("N2")
                            objNuevo.montoIsc = CDec(objNuevo.montoIsc).ToString("N2") - CDec(i.montoIsc).ToString("N2")
                            objNuevo.montoIscUS = CDec(objNuevo.montoIscUS).ToString("N2") - CDec(i.montoIscUS).ToString("N2")
                            'HeliosData.ObjectStateManager.GetObjectStateEntry(objNuevo).State.ToString()
                            conteoItemNotificacion += 1
                        Else
                            notificacionAlmacenDealleBL.Insert(i, i.idMovimiento, objDocumento)
                            documentoCompraDetBL.UpdateSingle2(i, i.idMovimiento)
                            objNuevo.cantidad = CDec(objNuevo.cantidad) - CDec(i.cantidad)
                            '  objNuevo.precioUnitarioCompra = CDec(objNuevo.precioUnitarioCompra).ToString("N2") - CDec(i.precioUnitarioCompra).ToString("N2")
                            objNuevo.importeSoles = CDec(objNuevo.importeSoles).ToString("N2") - CDec(i.importeSoles).ToString("N2")
                            objNuevo.importeDolares = CDec(objNuevo.importeDolares).ToString("N2") - CDec(i.importeDolares).ToString("N2")
                            'objNuevo.montoIsc = CDec(objNuevo.montoIsc).ToString("N2") - CDec(i.montoIsc).ToString("N2")
                            'objNuevo.montoIscUS = CDec(objNuevo.montoIscUS).ToString("N2") - CDec(i.montoIscUS).ToString("N2")
                            'HeliosData.ObjectStateManager.GetObjectStateEntry(objNuevo).State.ToString()
                            'sff()
                        End If
                    Else
                        conteoItemNotificacion += 1
                    End If
                Next

                If (conteoItemNotificacion = 0) Then
                    notificacionAlmacenBL.UpdateSingle(objDocumento)
                    resultadoNotificacion = True
                Else
                    resultadoNotificacion = False
                End If

                Dim x = objDeleteLiquidacion(0).idDocumento
                Dim totals3 = Aggregate p In HeliosData.documentocompradetalle _
                          Where p.idDocumento = x _
            Into sumCan = Sum(p.monto1), _
               sumSoles = Sum(p.importe), _
               sumaDolares = Sum(p.importeUS)

                If totals3.sumCan.GetValueOrDefault <= 0 Then
                    documentoBL.DeleteSingleVariable(objDeleteLiquidacion(0).idDocumento)
                End If
                HeliosData.SaveChanges()
                ts.Complete()
                Return resultadoNotificacion
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    'Public Function UpdateTotalesAlmacen2(ByVal objDeleteLiquidacion As List(Of totalesAlmacen), ByVal objDocumento As Integer) As Boolean
    'Dim objNuevo As New totalesAlmacen()
    'Dim documentoCompraDetBL As New documentocompradetalleBL
    'Dim docuemntoCompraBL As New documentocompraBL
    'Dim notificacionAlmacenDealleBL As New notificacionAlmacenDetalleBL
    'Dim documentoBL As New documentoBL
    'Try
    '    Using ts As New TransactionScope()

    '        For Each i In objDeleteLiquidacion

    '            objNuevo = HeliosData.totalesAlmacen.Where(Function(o) o.idEmpresa = i.idEmpresa And _
    '                                                   o.idEstablecimiento = i.idEstablecimiento And _
    '                                                   o.idAlmacen = i.idAlmacen And _
    '                                                   o.idItem = i.idItem).FirstOrDefault
    '            If Not IsNothing(objNuevo) Then
    '                If (objNuevo.cantidad < i.cantidad) Then
    '                    notificacionAlmacenDealleBL.Insert(objNuevo, i.idMovimiento, objDocumento)
    '                    documentoCompraDetBL.UpdateSingle2(objNuevo, i.idMovimiento)

    '                    objNuevo.cantidad = CDec(objNuevo.cantidad) - CDec(objNuevo.cantidad)
    '                    objNuevo.precioUnitarioCompra = CDec(objNuevo.precioUnitarioCompra).ToString("N2") - CDec(objNuevo.precioUnitarioCompra).ToString("N2")
    '                    objNuevo.importeSoles = CDec(objNuevo.importeSoles).ToString("N2") - CDec(objNuevo.importeSoles).ToString("N2")
    '                    objNuevo.importeDolares = CDec(objNuevo.importeDolares).ToString("N2") - CDec(objNuevo.importeDolares).ToString("N2")
    '                    objNuevo.montoIsc = CDec(objNuevo.montoIsc).ToString("N2") - CDec(objNuevo.montoIsc).ToString("N2")
    '                    objNuevo.montoIscUS = CDec(objNuevo.montoIscUS).ToString("N2") - CDec(objNuevo.montoIscUS).ToString("N2")
    '                    'HeliosData.ObjectStateManager.GetObjectStateEntry(objNuevo).State.ToString()

    '                Else
    '                    notificacionAlmacenDealleBL.Insert(objNuevo, i.idMovimiento, objDocumento)
    '                    documentoCompraDetBL.UpdateSingle2(i, i.idMovimiento)
    '                    objNuevo.cantidad = CDec(objNuevo.cantidad) - CDec(i.cantidad)
    '                    '  objNuevo.precioUnitarioCompra = CDec(objNuevo.precioUnitarioCompra).ToString("N2") - CDec(i.precioUnitarioCompra).ToString("N2")
    '                    objNuevo.importeSoles = CDec(objNuevo.importeSoles).ToString("N2") - CDec(i.importeSoles).ToString("N2")
    '                    objNuevo.importeDolares = CDec(objNuevo.importeDolares).ToString("N2") - CDec(i.importeDolares).ToString("N2")
    '                    'objNuevo.montoIsc = CDec(objNuevo.montoIsc).ToString("N2") - CDec(i.montoIsc).ToString("N2")
    '                    'objNuevo.montoIscUS = CDec(objNuevo.montoIscUS).ToString("N2") - CDec(i.montoIscUS).ToString("N2")
    '                    'HeliosData.ObjectStateManager.GetObjectStateEntry(objNuevo).State.ToString()
    '                    'sff()
    '                End If
    '            End If
    '        Next
    '        Dim x = objDeleteLiquidacion(0).idDocumento
    '        Dim totals3 = Aggregate p In HeliosData.documentocompradetalle _
    '                  Where p.idDocumento = x _
    '  Into sumCan = Sum(p.monto1), _
    '       sumSoles = Sum(p.importe), _
    '       sumaDolares = Sum(p.importeUS)

    '        If totals3.sumCan.GetValueOrDefault <= 0 Then
    '            documentoBL.DeleteSingleVariable(objDeleteLiquidacion(0).idDocumento)
    '        End If
    '        HeliosData.SaveChanges()
    '        ts.Complete()
    '    End Using
    'Catch ex As Exception
    '    Throw ex
    'End Try

    'End Function

    Public Function GetNotificacionAlmacen() As List(Of totalesAlmacen)
        Dim obj = (From a In HeliosData.totalesAlmacen _
                   Where a.cantidadMinima <= 10).ToList
        Return obj

    End Function

    Public Sub ActualizarItemsCambioInventario(ByVal i As totalesAlmacen)
        Dim objNuevo As New totalesAlmacen()
        Dim t As New totalesAlmacen
        Dim colcostoMN As Decimal = 0
        Dim colCantidad As Decimal = 0
        Dim colcostoME As Decimal = 0
        Dim ultimoPMmn As Decimal = 0
        Dim ultimoPMme As Decimal = 0

        Using ts As New TransactionScope()
            colcostoMN = 0
            colcostoME = 0

            'SE CONSULTA EL SI EL ITEM EXISTEN EN EL ALMACEN
            'objNuevo = HeliosData.totalesAlmacen.Where(Function(o) o.idEmpresa = i.idEmpresa And _
            '                                               o.idEstablecimiento = i.idEstablecimiento And _
            '                                               o.idAlmacen = i.idAlmacen And _
            '                                               o.origenRecaudo = i.origenRecaudo And _
            '                                               o.idItem = i.idItem).FirstOrDefault

            objNuevo = HeliosData.totalesAlmacen.Where(Function(o) o.idAlmacen = i.idAlmacen And
                                                          o.origenRecaudo = i.origenRecaudo And
                                                          o.idItem = i.idItem And
                                                          o.tipoExistencia = i.tipoExistencia).FirstOrDefault

            If Not IsNothing(objNuevo) Then ' SE ACTULIZA LOS MONTOS DEL ITEM RECUPERADO

                'ultimoPMmn = objNuevo.UltimoPMmn
                'ultimoPMme = objNuevo.UltimoPMme

                'colcostoMN = i.cantidad * ultimoPMmn
                'colcostoME = i.cantidad * ultimoPMme

                objNuevo.cantidad = objNuevo.cantidad + i.cantidad
                'objNuevo.precioUnitarioCompra = objNuevo.precioUnitarioCompra + i.precioUnitarioCompra
                objNuevo.importeSoles = objNuevo.importeSoles + i.importeSoles 'colcostoMN
                objNuevo.importeDolares = objNuevo.importeDolares + i.importeDolares 'colcostoME 

                'If objNuevo.importeSoles > 0 Then
                '    objNuevo.importeSoles = Math.Round(CDec(objNuevo.importeSoles), 2)
                'End If

                'If objNuevo.importeDolares > 0 Then
                '    objNuevo.importeDolares = Math.Round(CDec(objNuevo.importeDolares), 2)
                'End If

            Else ' SE REGISTRA EL NUEVO PRODUCTO EN EL ALMACEN SELECCIONADO
                t = New totalesAlmacen
                t.idEmpresa = i.idEmpresa
                t.idEstablecimiento = i.idEstablecimiento
                t.idAlmacen = i.idAlmacen  ' almacen de DESTINO
                t.origenRecaudo = i.origenRecaudo
                t.idItem = i.idItem
                t.descripcion = i.descripcion
                t.tipoExistencia = i.tipoExistencia
                t.tipoCambio = TmpTipoCambio
                t.idUnidad = i.idUnidad
                t.cantidad = i.cantidad
                t.importeSoles = i.importeSoles
                t.importeDolares = i.importeDolares
                t.usuarioActualizacion = i.usuarioActualizacion
                t.fechaActualizacion = i.fechaActualizacion

                HeliosData.totalesAlmacen.Add(t)
                'HeliosData.SaveChanges()
                'ts.Complete()

                'InsertSingle(t)
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub


#Region "MARTIN"


    Public Function GetListaProductosPorAlmacenItems(intIdAlmacen As Integer, iditem As Integer) As List(Of totalesAlmacen)

        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)

        Dim obj = (From a In HeliosData.totalesAlmacen
                Join prod In HeliosData.detalleitems _
                On a.idItem Equals prod.codigodetalle _
                 Join tbl In HeliosData.tabladetalle _
                   On prod.unidad1 Equals tbl.codigoDetalle _
                   Join alm In HeliosData.almacen _
                   On a.idAlmacen Equals alm.idAlmacen _
                   Join det In HeliosData.detalleitems _
                   On a.idItem Equals det.codigodetalle _
                   Join itm In HeliosData.item _
                   On det.idItem Equals itm.idItem _
                Where a.idAlmacen = intIdAlmacen _
                And itm.idItem = iditem _
                 And tbl.idtabla = 6).ToList

        For Each i In obj
            ntotal = New totalesAlmacen
            ntotal.idEstablecimiento = i.a.idEstablecimiento
            ntotal.idAlmacen = i.a.idAlmacen
            ntotal.NomAlmacen = i.alm.descripcionAlmacen
            ntotal.idItem = i.a.idItem
            ntotal.origenRecaudo = i.a.origenRecaudo
            ntotal.tipoExistencia = i.a.tipoExistencia
            ntotal.descripcion = i.prod.descripcionItem
            ntotal.idUnidad = i.prod.unidad1
            ntotal.unidadMedida = i.tbl.descripcion
            ntotal.cantidad = i.a.cantidad
            ntotal.importeSoles = i.a.importeSoles
            ntotal.Presentacion = i.prod.presentacion

            Listatotal.Add(ntotal)
        Next

        Return Listatotal

    End Function

    Public Function GetListaAlmaceneDetalle(idempresa As String, idEstablecimientio As Integer) As List(Of totalesAlmacen)

        Dim ntotal As New totalesAlmacen
        Dim Listatotal As New List(Of totalesAlmacen)

        Dim obj = (From a In HeliosData.totalesAlmacen
                Join prod In HeliosData.detalleitems _
                On a.idItem Equals prod.codigodetalle _
                 Join tbl In HeliosData.tabladetalle _
                   On prod.unidad1 Equals tbl.codigoDetalle _
                   Join alm In HeliosData.almacen _
                   On a.idAlmacen Equals alm.idAlmacen _
                   Join det In HeliosData.detalleitems _
                   On a.idItem Equals det.codigodetalle _
                   Join itm In HeliosData.item _
                   On det.idItem Equals itm.idItem _
                Where a.idEmpresa = idempresa _
                And itm.idEstablecimiento = idEstablecimientio _
                 And tbl.idtabla = 6).ToList

        For Each i In obj
            ntotal = New totalesAlmacen
            ntotal.idEstablecimiento = i.a.idEstablecimiento
            ntotal.idAlmacen = i.a.idAlmacen
            ntotal.NomAlmacen = i.alm.descripcionAlmacen
            ntotal.idItem = i.a.idItem
            ntotal.origenRecaudo = i.a.origenRecaudo
            ntotal.tipoExistencia = i.a.tipoExistencia
            ntotal.descripcion = i.prod.descripcionItem
            ntotal.idUnidad = i.prod.unidad1
            ntotal.unidadMedida = i.tbl.descripcion
            ntotal.cantidad = i.a.cantidad
            ntotal.importeSoles = i.a.importeSoles
            ntotal.Presentacion = i.prod.presentacion

            Listatotal.Add(ntotal)
        Next

        Return Listatotal

    End Function


    Public Function GetListaItemsProd(idempresa As String, intIdestable As Integer) As List(Of item)
        Dim ntotal As New item
        Dim Listatotal As New List(Of item)

        Dim obj = (From a In HeliosData.item
                Where a.idEstablecimiento = intIdestable _
                And a.idEmpresa = idempresa).ToList

        For Each i In obj
            ntotal = New item
            ntotal.idItem = i.idItem
            ntotal.descripcion = i.descripcion
            Listatotal.Add(ntotal)
        Next
        Return Listatotal

    End Function

    Public Sub GetChangeStatusArticuloRange(listaInventario As List(Of totalesAlmacen))
        Dim almacenBL As New almacenBL
        Using ts As New TransactionScope
            For Each i In listaInventario
                Dim t = HeliosData.totalesAlmacen.Where(Function(o) o.idItem = i.idItem).ToList
                For Each obj In t
                    Dim EsalmacenVirtual = almacenBL.GetEsAlmacenVirtual(obj.idAlmacen)
                    If Not EsalmacenVirtual Then
                        obj.status = i.status
                    End If
                Next
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub EditarArticuloLOTE(objInventario As totalesAlmacen)
        Dim articuloHistory As detalleitemsModifica
        Dim articuloGeneral = HeliosData.detalleitems.Where(Function(o) o.codigodetalle = objInventario.idItem).FirstOrDefault
        Dim articuloInventario = HeliosData.totalesAlmacen.Where(Function(o) o.idItem = objInventario.idItem And o.codigoLote = objInventario.CustomLote.codigoLote).FirstOrDefault
        Dim Lote = HeliosData.recursoCostoLote.Where(Function(o) o.codigoLote = objInventario.CustomLote.codigoLote).FirstOrDefault
        Dim nombreOld As String = Nothing
        Using ts As New TransactionScope

            If articuloGeneral IsNot Nothing Then
                nombreOld = articuloGeneral.descripcionItem
                articuloGeneral.descripcionItem = objInventario.descripcion
                articuloGeneral.unidad1 = objInventario.idUnidad
                articuloGeneral.codigo = objInventario.CodigoBarra
            End If
            If articuloInventario IsNot Nothing Then
                articuloInventario.descripcion = objInventario.descripcion
                articuloInventario.idUnidad = objInventario.idUnidad
            End If

            If Lote IsNot Nothing Then
                Lote.fechaProduccion = objInventario.CustomLote.fechaProduccion
                If objInventario.CustomLote.fechaVcto.HasValue Then
                    Lote.fechaVcto = objInventario.CustomLote.fechaVcto.GetValueOrDefault
                Else
                    Lote.fechaVcto = Nothing
                End If
                Lote.detalle = objInventario.descripcion
            End If

            articuloHistory = New detalleitemsModifica
            articuloHistory.codigodetalle = objInventario.idItem
            articuloHistory.codigoLote = objInventario.CustomLote.codigoLote
            articuloHistory.nombreOld = nombreOld
            articuloHistory.nombrenuevo = objInventario.descripcion
            articuloHistory.fechaActualizacion = Date.Now
            articuloHistory.usuarioActualizacion = 1
            HeliosData.detalleitemsModifica.Add(articuloHistory)

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub EliminarArticuloInicio(inv As InventarioMovimiento)
        Try
            Using ts As New TransactionScope
                Dim salidasAlmacen As New List(Of String)
                salidasAlmacen.Add("OSA")
                salidasAlmacen.Add("TEA")

                Dim articuloGeneral = HeliosData.detalleitems.Where(Function(o) o.codigodetalle = inv.idItem).FirstOrDefault
                Dim articuloInventario = HeliosData.totalesAlmacen.Where(Function(o) o.idItem = inv.idItem And o.codigoLote = inv.nrolote).FirstOrDefault
                Dim articuloInventarioMov = HeliosData.InventarioMovimiento.Where(Function(o) o.idInventario = inv.idInventario).FirstOrDefault
                Dim articuloLibroDiario = HeliosData.documentoLibroDiarioDetalle.Where(Function(o) o.secuencia = inv.Secuencia).FirstOrDefault

                Dim ventasArticulo = HeliosData.documentoventaAbarrotesDet.Where(Function(o) o.codigoLote = inv.nrolote).Count
                If ventasArticulo > 0 Then
                    Throw New Exception("El articulo tiene ventas, no puede eliminar")
                End If

                Dim MovAlmacenArticulo = (From det In HeliosData.documentocompradetalle
                                          Join c In HeliosData.documentocompra
                                             On c.idDocumento Equals det.idDocumento
                                          Where det.codigoLote = inv.nrolote _
                                         And salidasAlmacen.Contains(c.tipoCompra)).Count


                If MovAlmacenArticulo > 0 Then
                    Throw New Exception("El articulo tiene otras salidas de inventario, no puede eliminar")
                End If

                CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(articuloLibroDiario)
                CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(articuloInventarioMov)
                CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(articuloInventario)
                CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(articuloGeneral)


                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ListProductsConexos(be As totalesAlmacen) As List(Of totalesAlmacen)
        Return HeliosData.totalesAlmacen.Where(Function(o) o.idPadre = be.idMovimiento).ToList
    End Function

    Public Sub ProductosConexos(lista As List(Of totalesAlmacen))
        Using ts As New TransactionScope

            Dim articuloPadre = lista.Where(Function(o) o.TipoAcces = "P").Single
            Dim articulosHijos = lista.Where(Function(o) o.TipoAcces = "H").ToList

            For Each i In articulosHijos
                Dim obj = HeliosData.totalesAlmacen.Where(Function(o) o.idMovimiento = i.idMovimiento).Single
                obj.idPadre = articuloPadre.idMovimiento
                obj.cantidad2 = i.cantidad2
                obj.tipoEnlace = i.tipoEnlace
            Next

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

#End Region
End Class
