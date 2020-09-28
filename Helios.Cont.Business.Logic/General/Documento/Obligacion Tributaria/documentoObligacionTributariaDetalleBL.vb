Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class documentoObligacionTributariaDetalleBL
    Inherits BaseBL

    Public Function UbicarDetallePorTributo(intIdDocumento As Integer) As List(Of documentoObligacionDetalle)
        Return (From n In HeliosData.documentoObligacionDetalle _
                Where n.idDocumento = intIdDocumento).ToList
    End Function

    Public Function ExistenDatosDetalleObligacion(intIdDocumentoOrigen As Integer) As Boolean

        Dim consulta = (From n In HeliosData.documentoObligacionDetalle _
                       Where n.idDocumentoOrigen = intIdDocumentoOrigen).SingleOrDefault

        If IsNothing(consulta) Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Sub EliminarGrupoTributo(intIdDocumentoCompra As Integer)
        Dim documentoBL As New documentoBL
        Dim codDocumento As Integer
        Using ts As New TransactionScope
            Dim consultaDetalle = (From x In HeliosData.documentoObligacionDetalle _
                            Where x.idDocumentoOrigen = intIdDocumentoCompra).ToList

            For Each i In consultaDetalle
                'documentoBL.DeleteSingleVariable(i.idDocumento)
                EliminarItemDetalle(i.secuencia)
                codDocumento = i.idDocumento
                Dim conteo As Integer = HeliosData.documentoObligacionDetalle.Where(Function(o) o.idDocumento = codDocumento).Count
                If conteo > 0 Then
                Else
                    documentoBL.DeleteSingleVariable(codDocumento)
                End If
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub EliminarGrupoTributoPercepcion(intIdDocumentoCompra As Integer)
        Dim documentoBL As New documentoBL
        Dim codDocumento As Integer
        Using ts As New TransactionScope
            Dim consultaDetalle = (From x In HeliosData.documentoObligacionDetalle _
                            Where x.idDocumentoOrigen = intIdDocumentoCompra).ToList

            For Each i In consultaDetalle
                codDocumento = i.idDocumento
                'documentoBL.DeleteSingleVariable(i.idDocumento)
                Dim docCabecera As documentoObligacionTributaria = HeliosData.documentoObligacionTributaria.Where(Function(o) o.idDocumento = codDocumento).First
                If docCabecera.tipoTributo = "P" Then
                    EliminarItemDetalle(i.secuencia)

                    Dim conteo As Integer = HeliosData.documentoObligacionDetalle.Where(Function(o) o.idDocumento = codDocumento).Count
                    If conteo > 0 Then
                    Else
                        documentoBL.DeleteSingleVariable(codDocumento)
                    End If
                End If
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub EliminarItemDetalle(Secuencia As Integer)
        Using ts As New TransactionScope
            Dim DetalleItem As documentoObligacionDetalle = HeliosData.documentoObligacionDetalle.Where(Function(o) o.secuencia = Secuencia).FirstOrDefault
            If Not IsNothing(DetalleItem) Then
                CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(DetalleItem)
                HeliosData.SaveChanges()
                ts.Complete()
            End If
        End Using
    End Sub

    Public Sub InsertSingle(documentoObligaciondetalle As documentoObligacionDetalle, intIdDocumento As Integer)
        Dim OBJD As New documentoObligacionDetalle
        Using ts As New TransactionScope

            OBJD = New documentoObligacionDetalle
            '    objInventario = New HeliosDAL.InventarioMovimiento
            OBJD.idDocumento = intIdDocumento ' Me.IdDocumento
            OBJD.idDocumentoOrigen = documentoObligaciondetalle.idDocumentoOrigen
            OBJD.idItem = documentoObligaciondetalle.idItem
            OBJD.descripcionItem = documentoObligaciondetalle.descripcionItem
            OBJD.destino = documentoObligaciondetalle.destino
            OBJD.unidadMedida = documentoObligaciondetalle.unidadMedida
            OBJD.cantidad = documentoObligaciondetalle.cantidad
            OBJD.precioUnitario = documentoObligaciondetalle.precioUnitario
            OBJD.precioUnitarioUS = documentoObligaciondetalle.precioUnitarioUS
            OBJD.porcTributo = documentoObligaciondetalle.porcTributo
            OBJD.importeMN = documentoObligaciondetalle.importeMN
            OBJD.importeME = documentoObligaciondetalle.importeME
            OBJD.usuarioActualizacion = documentoObligaciondetalle.usuarioActualizacion
            OBJD.fechaActualizacion = documentoObligaciondetalle.fechaActualizacion
            HeliosData.documentoObligacionDetalle.Add(OBJD)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub InsertSingleDefault(documentoObligaciondetalle As documentoObligacionDetalle, intIdDocumento As Integer,
                                   intIdOrigenDocumento As Integer)
        Dim OBJD As New documentoObligacionDetalle
        Using ts As New TransactionScope
            OBJD = New documentoObligacionDetalle
            '    objInventario = New HeliosDAL.InventarioMovimiento
            OBJD.idDocumento = intIdDocumento ' Me.IdDocumento
            OBJD.idDocumentoOrigen = intIdOrigenDocumento
            OBJD.idItem = documentoObligaciondetalle.idItem
            OBJD.descripcionItem = documentoObligaciondetalle.descripcionItem
            OBJD.destino = documentoObligaciondetalle.destino
            OBJD.unidadMedida = documentoObligaciondetalle.unidadMedida
            OBJD.cantidad = documentoObligaciondetalle.cantidad
            OBJD.precioUnitario = documentoObligaciondetalle.precioUnitario
            OBJD.precioUnitarioUS = documentoObligaciondetalle.precioUnitarioUS
            OBJD.porcTributo = documentoObligaciondetalle.porcTributo
            OBJD.importeMN = documentoObligaciondetalle.importeMN
            OBJD.importeME = documentoObligaciondetalle.importeME
            OBJD.usuarioActualizacion = documentoObligaciondetalle.usuarioActualizacion
            OBJD.fechaActualizacion = documentoObligaciondetalle.fechaActualizacion
            HeliosData.documentoObligacionDetalle.Add(OBJD)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

End Class
