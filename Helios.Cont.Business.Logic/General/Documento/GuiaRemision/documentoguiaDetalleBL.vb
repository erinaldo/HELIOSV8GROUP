Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Imports System.Data.Entity
Public Class documentoguiaDetalleBL
    Inherits BaseBL

    Public Function GetAlmacenesDistribuidosParaEmision(secuenciaCompra As Integer, idCompra As Integer) As List(Of documentoguiaDetalle)
        Dim Consulta = (From g In HeliosData.documentoguiaDetalle
                        Where
                            g.secuenciaRef = secuenciaCompra And
                            g.idDocumentoPadre = idCompra
                        Select
                            g.almacenRef, g.idItem).Distinct.ToList()

        GetAlmacenesDistribuidosParaEmision = New List(Of documentoguiaDetalle)
        For Each i In Consulta
            GetAlmacenesDistribuidosParaEmision.Add(New documentoguiaDetalle With
                                                    {
                                                    .almacenRef = i.almacenRef,
                                                    .idItem = i.idItem
                                                    })
        Next
    End Function

    Public Sub InsertarGuiaDetalleVenta(documenoGuiaBE As documentoGuia, intIdDocumento As Integer)
        Dim documentoGuiaDetalle As New documentoguiaDetalle
        Using ts As New TransactionScope
            For Each i As documentoguiaDetalle In documenoGuiaBE.documentoguiaDetalle
                documentoGuiaDetalle = New documentoguiaDetalle
                documentoGuiaDetalle.idDocumento = intIdDocumento
                documentoGuiaDetalle.idItem = i.idItem
                documentoGuiaDetalle.descripcionItem = i.descripcionItem
                documentoGuiaDetalle.destino = i.destino
                documentoGuiaDetalle.unidadMedida = i.unidadMedida
                documentoGuiaDetalle.cantidad = i.cantidad
                documentoGuiaDetalle.precioUnitario = i.precioUnitario
                documentoGuiaDetalle.precioUnitarioUS = i.precioUnitarioUS
                documentoGuiaDetalle.importeMN = i.importeMN
                documentoGuiaDetalle.importeME = i.importeME
                documentoGuiaDetalle.almacenRef = i.almacenRef
                documentoGuiaDetalle.idDocumentoPadre = documenoGuiaBE.CodigoVenta
                documentoGuiaDetalle.usuarioModificacion = i.usuarioModificacion
                documentoGuiaDetalle.fechaModificacion = i.fechaModificacion
                HeliosData.documentoguiaDetalle.Add(documentoGuiaDetalle)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function UbicarGuiaDetallePorIdDocumentoPadreCAC(intIdDocumento As Integer) As documentoguiaDetalle
        Dim newObjeto As New documentoguiaDetalle
        Dim consulta = (From n In HeliosData.documentoguiaDetalle _
                        Join doc In HeliosData.documentoGuia _
                        On n.idDocumento Equals doc.idDocumento _
                      Where n.idDocumentoPadre = intIdDocumento).FirstOrDefault

        If Not IsNothing(consulta) Then
            newObjeto = New documentoguiaDetalle
            newObjeto.fecha = consulta.doc.fechaDoc
            newObjeto.Serie = consulta.doc.serie
            newObjeto.Numero = consulta.doc.numeroDoc
        End If
        Return newObjeto
    End Function

    Public Function UbicarDocumentoGuiaDetalle(intIdDocumento As Integer) As List(Of documentoguiaDetalle)
        Dim DocDetalle As New documentoguiaDetalle
        Dim listaDetalle As New List(Of documentoguiaDetalle)

        Dim consulta = (From n In HeliosData.documentoguiaDetalle _
                        Join almacen In HeliosData.almacen _
                        On n.almacenRef Equals almacen.idAlmacen _
                        Join estable In HeliosData.centrocosto _
                        On estable.idCentroCosto Equals almacen.idEstablecimiento _
                      Where n.idDocumento = intIdDocumento).ToList

        For Each i In consulta
            DocDetalle = New documentoguiaDetalle
            DocDetalle.almacenRef = i.n.almacenRef
            DocDetalle.NombreAlmacen = i.almacen.descripcionAlmacen
            DocDetalle.idItem = i.n.idItem
            DocDetalle.descripcionItem = i.n.descripcionItem
            DocDetalle.cantidad = i.n.cantidad
            DocDetalle.unidadMedida = i.n.unidadMedida
            DocDetalle.precioUnitario = i.n.precioUnitario
            DocDetalle.precioUnitarioUS = i.n.precioUnitarioUS
            DocDetalle.importeMN = i.n.importeMN
            DocDetalle.importeME = i.n.importeME
            DocDetalle.NombreEstablecimiento = i.estable.nombre
            DocDetalle.NombreAlmacen = i.almacen.descripcionAlmacen
            listaDetalle.Add(DocDetalle)
        Next
        Return listaDetalle
    End Function

    Public Sub InsertarGuiaDetalle(documenoGuiaBE As documentoGuia, intIdDocumento As Integer)
        Dim documentoGuiaDetalle As New documentoguiaDetalle
        Using ts As New TransactionScope
            For Each i As documentoguiaDetalle In documenoGuiaBE.documentoguiaDetalle
                documentoGuiaDetalle = New documentoguiaDetalle
                documentoGuiaDetalle.idDocumento = intIdDocumento
                documentoGuiaDetalle.idItem = i.idItem
                documentoGuiaDetalle.descripcionItem = i.descripcionItem
                documentoGuiaDetalle.destino = i.destino
                documentoGuiaDetalle.unidadMedida = i.unidadMedida
                documentoGuiaDetalle.cantidad = i.cantidad
                documentoGuiaDetalle.precioUnitario = i.precioUnitario
                documentoGuiaDetalle.precioUnitarioUS = i.precioUnitarioUS
                documentoGuiaDetalle.importeMN = i.importeMN
                documentoGuiaDetalle.importeME = i.importeME
                documentoGuiaDetalle.almacenRef = i.almacenRef
                documentoGuiaDetalle.idDocumentoPadre = i.idDocumentoPadre
                documentoGuiaDetalle.usuarioModificacion = i.usuarioModificacion
                documentoGuiaDetalle.fechaModificacion = i.fechaModificacion
                HeliosData.documentoguiaDetalle.Add(documentoGuiaDetalle)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub InsertarGuiaDetalleSL(documenoGuiaBE As documentoGuia, intIdDocumento As Integer)
        Dim documentoGuiaDetalle As New documentoguiaDetalle
        Dim documentoCompraDetalleBL As New documentocompradetalleBL
        Dim documentoCompraBL As New documentocompraBL
        Using ts As New TransactionScope
            For Each i As documentoguiaDetalle In documenoGuiaBE.documentoguiaDetalle
                documentoGuiaDetalle = New documentoguiaDetalle
                documentoGuiaDetalle.idDocumento = intIdDocumento
                documentoGuiaDetalle.idItem = i.idItem
                documentoGuiaDetalle.descripcionItem = i.descripcionItem
                documentoGuiaDetalle.destino = i.destino
                documentoGuiaDetalle.unidadMedida = i.unidadMedida
                documentoGuiaDetalle.cantidad = i.cantidad
                documentoGuiaDetalle.precioUnitario = i.precioUnitario
                documentoGuiaDetalle.precioUnitarioUS = i.precioUnitarioUS
                documentoGuiaDetalle.importeMN = i.importeMN
                documentoGuiaDetalle.importeME = i.importeME
                documentoGuiaDetalle.almacenRef = i.almacenRef
                documentoGuiaDetalle.idDocumentoPadre = i.idDocumentoPadre
                documentoGuiaDetalle.usuarioModificacion = i.usuarioModificacion
                documentoGuiaDetalle.fechaModificacion = i.fechaModificacion
                HeliosData.documentoguiaDetalle.Add(documentoGuiaDetalle)
                documentoCompraDetalleBL.UpdateSingleDocCompraDetalleSL(i.idDocumentoPadre, i.idItem)
                documentoCompraBL.UpdateSingleDocCompraSL(i.idDocumentoPadre)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub InsertarGuiaDetalleAlCredito(documenoGuiaBE As documentoGuia, intIdDocumentoGuia As Integer, intIdDocumentoPadre As Integer)
        Dim documentoGuiaDetalle As New documentoguiaDetalle
        Using ts As New TransactionScope
            For Each i As documentoguiaDetalle In documenoGuiaBE.documentoguiaDetalle
                documentoGuiaDetalle = New documentoguiaDetalle
                documentoGuiaDetalle.idDocumento = intIdDocumentoGuia
                documentoGuiaDetalle.idItem = i.idItem
                documentoGuiaDetalle.descripcionItem = i.descripcionItem
                documentoGuiaDetalle.destino = i.destino
                documentoGuiaDetalle.unidadMedida = i.unidadMedida
                documentoGuiaDetalle.cantidad = i.cantidad
                documentoGuiaDetalle.precioUnitario = i.precioUnitario
                documentoGuiaDetalle.precioUnitarioUS = i.precioUnitarioUS
                documentoGuiaDetalle.importeMN = i.importeMN
                documentoGuiaDetalle.importeME = i.importeME
                documentoGuiaDetalle.almacenRef = i.almacenRef
                documentoGuiaDetalle.idDocumentoPadre = intIdDocumentoPadre
                documentoGuiaDetalle.usuarioModificacion = i.usuarioModificacion
                documentoGuiaDetalle.fechaModificacion = i.fechaModificacion
                HeliosData.documentoguiaDetalle.Add(documentoGuiaDetalle)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub InsertarGuiaDetallePagado(documenoGuiaBE As documentoGuia, intIdDocumento As Integer)
        Dim documentoGuiaDetalle As New documentoguiaDetalle
        Using ts As New TransactionScope
            For Each i As documentoguiaDetalle In documenoGuiaBE.documentoguiaDetalle
                documentoGuiaDetalle = New documentoguiaDetalle
                documentoGuiaDetalle.idDocumento = intIdDocumento
                documentoGuiaDetalle.idItem = i.idItem
                documentoGuiaDetalle.descripcionItem = i.descripcionItem
                documentoGuiaDetalle.destino = i.destino
                documentoGuiaDetalle.unidadMedida = i.unidadMedida
                documentoGuiaDetalle.cantidad = i.cantidad
                documentoGuiaDetalle.precioUnitario = i.precioUnitario
                documentoGuiaDetalle.precioUnitarioUS = i.precioUnitarioUS
                documentoGuiaDetalle.importeMN = i.importeMN
                documentoGuiaDetalle.importeME = i.importeME
                documentoGuiaDetalle.almacenRef = i.almacenRef
                documentoGuiaDetalle.idDocumentoPadre = intIdDocumento
                documentoGuiaDetalle.usuarioModificacion = i.usuarioModificacion
                documentoGuiaDetalle.fechaModificacion = i.fechaModificacion
                HeliosData.documentoguiaDetalle.Add(documentoGuiaDetalle)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub InsertarGuiaDetalleNuevo(documenoGuiaBE As documentoGuia, codGuia As Integer, intIdDocumentoRef As Integer)
        Dim documentoGuiaDetalle As New documentoguiaDetalle
        Using ts As New TransactionScope
            For Each i As documentoguiaDetalle In documenoGuiaBE.documentoguiaDetalle
                documentoGuiaDetalle = New documentoguiaDetalle
                documentoGuiaDetalle.secuenciaRef = i.secuenciaRef
                documentoGuiaDetalle.idDocumento = codGuia
                documentoGuiaDetalle.idItem = i.idItem
                documentoGuiaDetalle.descripcionItem = i.descripcionItem
                documentoGuiaDetalle.destino = i.destino
                documentoGuiaDetalle.unidadMedida = i.unidadMedida
                documentoGuiaDetalle.cantidad = i.cantidad
                documentoGuiaDetalle.precioUnitario = i.precioUnitario
                documentoGuiaDetalle.precioUnitarioUS = i.precioUnitarioUS
                documentoGuiaDetalle.importeMN = i.importeMN
                documentoGuiaDetalle.importeME = i.importeME
                documentoGuiaDetalle.almacenRef = i.almacenRef
                documentoGuiaDetalle.estado = i.estado
                documentoGuiaDetalle.nombreRecepcion = i.nombreRecepcion
                documentoGuiaDetalle.dniRecepcion = i.dniRecepcion
                documentoGuiaDetalle.puntoLlegada = i.puntoLlegada
                documentoGuiaDetalle.idDocumentoPadre = intIdDocumentoRef
                documentoGuiaDetalle.usuarioModificacion = i.usuarioModificacion
                documentoGuiaDetalle.fechaModificacion = i.fechaModificacion
                HeliosData.documentoguiaDetalle.Add(documentoGuiaDetalle)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub UpateDetalleGuia(documentocompradetalle As documentoguiaDetalle, intIdDocumento As Integer)
        Dim OBJD As New documentoguiaDetalle
        Using ts As New TransactionScope
            OBJD = New documentoguiaDetalle
            OBJD.idDocumento = intIdDocumento ' Me.IdDocumento
            OBJD.idItem = documentocompradetalle.idItem
            OBJD.descripcionItem = documentocompradetalle.descripcionItem
            OBJD.destino = documentocompradetalle.destino
            OBJD.precioUnitario = documentocompradetalle.precioUnitario
            OBJD.precioUnitarioUS = documentocompradetalle.precioUnitarioUS
            OBJD.importeMN = documentocompradetalle.importeMN
            OBJD.importeME = documentocompradetalle.importeME

            OBJD.almacenRef = documentocompradetalle.almacenRef
            OBJD.idDocumentoPadre = documentocompradetalle.idDocumentoPadre
            '*********************************************************************
            OBJD.usuarioModificacion = documentocompradetalle.usuarioModificacion
            OBJD.fechaModificacion = documentocompradetalle.fechaModificacion
            HeliosData.documentoguiaDetalle.Add(OBJD)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Sub EliminarSingle(documentoBE As documentoguiaDetalle)
        Using ts As New TransactionScope
            CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(documentoBE)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub EliminarDetalleItems(intIdDocumentoCompra As Integer)
        Dim ColiD As Integer
        Dim documentoBL As New documentoBL
        Dim docGuiaBL As New documentoGuiaBL
        Using ts As New TransactionScope
            Dim ListaDetalle As List(Of documentoguiaDetalle) = HeliosData.documentoguiaDetalle.Where(Function(o) o.idDocumentoPadre = intIdDocumentoCompra).ToList
            For Each i As documentoguiaDetalle In ListaDetalle
                EliminarSingle(i)
                ColiD = i.idDocumento

                Dim Listacompra2 As documentoguiaDetalle = HeliosData.documentoguiaDetalle.Where(Function(o) o.idDocumento = ColiD).FirstOrDefault
                If IsNothing(Listacompra2) Then
                    documentoBL.DeleteSingleVariable(ColiD)
                End If
            Next
           
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function ConsultaDocumentoGuiaDetalle(stremp As String, periodo As String) As List(Of documentoguiaDetalle)
        Dim DocDetalle As New documentoguiaDetalle
        Dim listaDetalle As New List(Of documentoguiaDetalle)

        Dim consulta = (From n In HeliosData.documentoguiaDetalle
                        Join almacen In HeliosData.almacen
                        On n.almacenRef Equals almacen.idAlmacen
                        Join estable In HeliosData.centrocosto
                        On estable.idCentroCosto Equals almacen.idEstablecimiento
                        Join pri In HeliosData.documentoGuia
                        On n.idDocumento Equals pri.idDocumento
                        Join tbl In HeliosData.tabladetalle
                        On pri.tipoDoc Equals tbl.codigoDetalle
                        Where pri.idEmpresa = stremp _
                      And pri.periodo = periodo And tbl.idtabla = 10).ToList

        For Each i In consulta
            DocDetalle = New documentoguiaDetalle
            DocDetalle.idDocumento = i.pri.idDocumento
            DocDetalle.fecha = i.pri.fechaDoc
            DocDetalle.tipodoc = i.tbl.descripcion
            DocDetalle.numerodoc = i.pri.numeroDoc
            DocDetalle.Serie = i.pri.serie
            DocDetalle.ImporteTotal = i.pri.importeMN

            DocDetalle.idItem = i.n.idItem
            DocDetalle.descripcionItem = i.n.descripcionItem
            DocDetalle.cantidad = i.n.cantidad
            DocDetalle.unidadMedida = i.n.unidadMedida
            DocDetalle.precioUnitario = i.n.precioUnitario
            DocDetalle.precioUnitarioUS = i.n.precioUnitarioUS
            DocDetalle.importeMN = i.n.importeMN
            DocDetalle.importeME = i.n.importeME
            DocDetalle.NombreEstablecimiento = i.estable.nombre
            DocDetalle.NombreAlmacen = i.almacen.descripcionAlmacen
            listaDetalle.Add(DocDetalle)
        Next
        Return listaDetalle
    End Function

    Public Sub EliminarDetalleItemsSL(intIdDocumentoCompra As Integer)
        Dim ColiD As Integer
        Dim docGuiaBL As New documentoGuiaBL
        Dim documentocompradetalleBL As New documentocompradetalleBL
        Using ts As New TransactionScope
            Dim ListaDetalle As List(Of documentoguiaDetalle) = HeliosData.documentoguiaDetalle.Where(Function(o) o.idDocumentoPadre = intIdDocumentoCompra).ToList
            For Each i As documentoguiaDetalle In ListaDetalle
                EliminarSingle(i)

                ColiD = i.idDocumento
                Dim Listacompra2 As documentoguiaDetalle = HeliosData.documentoguiaDetalle.Where(Function(o) o.idDocumento = ColiD).FirstOrDefault
                If IsNothing(Listacompra2) Then
                    docGuiaBL.EliminarDocGuia(ColiD)
                End If
            Next

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function UbicarGuiaDetallePorIdDocumentoguia(intIdDocumento As Integer) As List(Of documentoguiaDetalle)
        Dim DocDetalle As New documentoguiaDetalle
        Dim ObjListaDocDetalle As New List(Of documentoguiaDetalle)
        Dim consulta = (From n In HeliosData.documentoguiaDetalle
                        Join detalleTran In HeliosData.documentocompradetalle
                            On detalleTran.secuencia Equals n.secuenciaRef _
                            And detalleTran.idDocumento Equals n.idDocumentoPadre
                        Join doc In HeliosData.documentoGuia
                            On n.idDocumento Equals doc.idDocumento
                        Where n.idDocumento = intIdDocumento).ToList

        For Each i In consulta

            DocDetalle = New documentoguiaDetalle
            DocDetalle.idDocumento = i.n.idDocumento
            DocDetalle.secuencia = i.n.secuencia
            DocDetalle.descripcionItem = i.n.descripcionItem
            DocDetalle.cantidad = i.n.cantidad
            DocDetalle.estado = i.n.estado
            DocDetalle.cantConforme = i.detalleTran.monto1
            DocDetalle.cantPendiente = i.detalleTran.monto1
            DocDetalle.almacenRef = i.detalleTran.almacenDestino
            DocDetalle.unidadMedida = i.n.unidadMedida
            DocDetalle.destino = i.n.destino
            DocDetalle.Serie = i.doc.serie
            DocDetalle.idItem = i.n.idItem
            DocDetalle.numerodoc = i.doc.numeroDoc
            DocDetalle.importeMN = i.n.importeMN
            DocDetalle.importeME = i.n.importeME
            DocDetalle.precioUnitario = i.n.precioUnitario
            DocDetalle.precioUnitarioUS = i.n.precioUnitarioUS
            DocDetalle.tipoExistencia = i.n.tipoExistencia
            DocDetalle.codigoLote = i.detalleTran.codigoLote
            ObjListaDocDetalle.Add(DocDetalle)
        Next
        Return ObjListaDocDetalle

    End Function

    Public Function MappingProperties(i As documentoguiaDetalle) As documentoguiaDetalle
        Dim DocDetalle = New documentoguiaDetalle
        DocDetalle.idDocumento = i.idDocumento
        DocDetalle.secuencia = i.secuencia
        DocDetalle.descripcionItem = i.descripcionItem
        DocDetalle.cantidad = i.cantidad
        DocDetalle.estado = i.estado
        DocDetalle.almacenRef = i.almacenRef
        DocDetalle.unidadMedida = i.unidadMedida
        DocDetalle.destino = i.destino
        DocDetalle.idItem = i.idItem
        DocDetalle.tipoExistencia = i.tipoExistencia

        Return DocDetalle
    End Function


    Public Sub InsertarGuiaDetalleEntrega(documenoGuiaBE As documentoGuia, intIdDocumento As Integer)
        Dim documentoGuiaDetalle As New documentoguiaDetalle
        Using ts As New TransactionScope
            For Each i As documentoguiaDetalle In documenoGuiaBE.documentoguiaDetalle
                documentoGuiaDetalle = New documentoguiaDetalle
                documentoGuiaDetalle.idDocumento = intIdDocumento
                documentoGuiaDetalle.idItem = i.idItem
                documentoGuiaDetalle.descripcionItem = i.descripcionItem
                documentoGuiaDetalle.destino = i.destino
                documentoGuiaDetalle.unidadMedida = i.unidadMedida
                documentoGuiaDetalle.cantidad = i.cantidad
                documentoGuiaDetalle.precioUnitario = i.precioUnitario
                documentoGuiaDetalle.precioUnitarioUS = i.precioUnitarioUS
                documentoGuiaDetalle.importeMN = i.importeMN
                documentoGuiaDetalle.importeME = i.importeME
                documentoGuiaDetalle.almacenRef = i.almacenRef
                documentoGuiaDetalle.idDocumentoPadre = i.idDocumentoPadre
                documentoGuiaDetalle.observaciones = i.observaciones
                documentoGuiaDetalle.ubigeo = i.ubigeo
                documentoGuiaDetalle.estado = i.estado
                documentoGuiaDetalle.puntoLlegada = i.puntoLlegada
                documentoGuiaDetalle.usuarioModificacion = i.usuarioModificacion
                documentoGuiaDetalle.fechaModificacion = i.fechaModificacion
                HeliosData.documentoguiaDetalle.Add(documentoGuiaDetalle)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function UpdateSingleDocDetalle(ByVal intIdDocumento As Integer, ByVal secuencia As Integer, tipoEntrega As String, cantidad As Integer, tipo As Integer) As Integer
        Using ts As New TransactionScope
            Dim consulta = (From c In HeliosData.documentoguiaDetalle
                            Where c.idDocumento = intIdDocumento _
                                   And c.secuencia = secuencia
                            Select c).FirstOrDefault

            If Not IsNothing(consulta) Then

                If (tipo = 0) Then
                    consulta.estado = tipoEntrega
                Else
                    consulta.estado = tipoEntrega
                    'consulta.cantidad = consulta.cantidad - cantidad
                End If

                'HeliosData.ObjectStateManager.GetObjectStateEntry(items).State.ToString()

                HeliosData.SaveChanges()
                ts.Complete()
                Return consulta.idDocumentoPadre
            Else
                Throw New Exception("El comprobante no se encuentra, verifique su existencia!")
            End If
        End Using
    End Function

    Sub InsertarDetalleGuia(i As documentoguiaDetalle, codGuia As Integer, intIdDocumentoRef As Integer)
        Dim documentoGuiaDetalle As New documentoguiaDetalle
        Using ts As New TransactionScope
            documentoGuiaDetalle = New documentoguiaDetalle
            documentoGuiaDetalle.secuenciaRef = i.secuenciaRef
            documentoGuiaDetalle.idDocumento = codGuia
            documentoGuiaDetalle.idItem = i.idItem
            documentoGuiaDetalle.descripcionItem = i.descripcionItem
            documentoGuiaDetalle.destino = i.destino
            documentoGuiaDetalle.unidadMedida = i.unidadMedida
            documentoGuiaDetalle.cantidad = i.cantidad
            documentoGuiaDetalle.precioUnitario = i.precioUnitario
            documentoGuiaDetalle.precioUnitarioUS = i.precioUnitarioUS
            documentoGuiaDetalle.importeMN = i.importeMN
            documentoGuiaDetalle.importeME = i.importeME
            documentoGuiaDetalle.almacenRef = i.almacenRef
            documentoGuiaDetalle.estado = i.estado
            documentoGuiaDetalle.nombreRecepcion = i.nombreRecepcion
            documentoGuiaDetalle.dniRecepcion = i.dniRecepcion
            documentoGuiaDetalle.puntoLlegada = i.puntoLlegada
            documentoGuiaDetalle.idDocumentoPadre = intIdDocumentoRef
            '    documentoGuiaDetalle.secuenciaRef = intSecuenciaRef
            documentoGuiaDetalle.usuarioModificacion = i.usuarioModificacion
            documentoGuiaDetalle.fechaModificacion = i.fechaModificacion
            documentoGuiaDetalle.tipoExistencia = i.tipoExistencia
            HeliosData.documentoguiaDetalle.Add(documentoGuiaDetalle)
            HeliosData.SaveChanges()
            ts.Complete()
            i.secuencia = documentoGuiaDetalle.secuencia

        End Using

    End Sub

    Public Sub InsertarGuiaDetalleNuevoEntregado(documenoGuiaBE As documentoGuia, codGuia As Integer, intIdDocumentoRef As Integer)
        Dim documentoGuiaDetalle As New documentoguiaDetalle
        ' Dim documnetocondicion As New documentoGuiaDetalleCondicionBL
        Using ts As New TransactionScope
            For Each i As documentoguiaDetalle In documenoGuiaBE.documentoguiaDetalle
                InsertarDetalleGuia(i, codGuia, intIdDocumentoRef)
                '     documnetocondicion.SaveGuiaRemisionEntergado(i, codGuia, i.secuencia)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


#Region "GUIA FABIO"

    Public Function ListarGuiaDetalle(be As documentoGuia) As List(Of documentoGuia)
        Dim objGuiDet As New documentoguiaDetalle
        Dim objgui As New documentoGuia

        Dim listaGuiDet As New List(Of documentoguiaDetalle)
        Dim listagui As New List(Of documentoGuia)
        Try
            Dim consulta = HeliosData.documentoGuia.Include _
           (Function(o) o.documentoguiaDetalle.Where(Function(d) d.idDocumento = be.idDocumento)
           ).ToList

            For Each x In consulta
                For Each lis In x.documentoguiaDetalle
                    objGuiDet = New documentoguiaDetalle
                    objGuiDet.idDocumento = lis.idDocumento
                    objGuiDet.secuencia = lis.secuencia
                    objGuiDet.idItem = lis.idItem
                    objGuiDet.descripcionItem = lis.descripcionItem
                    objGuiDet.unidadMedida = lis.unidadMedida
                    objGuiDet.cantidad = lis.cantidad

                    listaGuiDet.Add(objGuiDet)
                Next

                objgui = New documentoGuia
                objgui.idDocumento = x.idDocumento

                objgui.documentoguiaDetalle = listaGuiDet

                listagui.Add(objgui)

            Next

        Catch ex As Exception
            Throw ex
        End Try

        Return listagui






        '    Dim objeGuia As New documentoguiaDetalle


        '    Dim consulta = (From G In HeliosData.documentoguiaDetalle
        '                    Select
        '                        G.idDocumento,
        '                        G.secuencia,
        '                        G.idItem,
        '                        G.descripcionItem,
        '                        G.unidadMedida,
        '                        G.cantidad
        '                      ).FirstOrDefault

        '    objeGuia = New documentoguiaDetalle
        '    objeGuia.idDocumento = consulta.idDocumento
        '    objeGuia.secuencia = consulta.secuencia
        '    objeGuia.idItem = consulta.idItem
        '    objeGuia.descripcionItem = consulta.descripcionItem
        '    objeGuia.unidadMedida = consulta.unidadMedida
        '    objeGuia.cantidad = consulta.cantidad


        '    Return objeGuia

    End Function
#End Region
End Class
