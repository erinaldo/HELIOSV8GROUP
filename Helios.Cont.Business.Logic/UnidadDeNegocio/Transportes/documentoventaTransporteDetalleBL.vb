Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports System.Data.Entity.DbFunctions
Public Class documentoventaTransporteDetalleBL
    Inherits BaseBL

    Public Sub InsertarDocTransporteDet(objDocumentoDetalle As List(Of documentoventaTransporteDetalle), idDocumento As Integer)

        Try
            Using ts As New TransactionScope()
                For Each item In objDocumentoDetalle

                    Dim docdet As documentoventaTransporteDetalle = New documentoventaTransporteDetalle With
                                               {
        .idDocumento = idDocumento,
        .[tipo] = item.[tipo],
       .[codigoBarraSerie] = item.[codigoBarraSerie],
        .[detalle] = item.[detalle],
        .[sku] = item.[sku],
        .destino = item.destino,
        .[cantidad] = item.[cantidad],
        .[unidadMedida] = item.[unidadMedida],
        .[importe] = item.[importe],
        .[agencia_id] = item.[agencia_id],
        .[estado] = item.[estado],
        .[manifiesto] = item.[manifiesto],
        .[idDistribucion] = item.[idDistribucion],
        .[estadoDiustribucion] = item.[estadoDiustribucion],
        .[usuarioActualizacion] = item.[usuarioActualizacion],
        .[fechaActualizacion] = item.[fechaActualizacion]
             }

                    HeliosData.documentoventaTransporteDetalle.Add(docdet)
                    HeliosData.SaveChanges()
                Next

                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateProgramacionDetalleXCAmbioPlaca(listaAsientoXBus As vehiculoAsiento_Precios, idDocumento As Integer)
        Dim documentoVEntaDetBL As New documentoventaTransporteDetalleBL
        Try
            Using ts As New TransactionScope()

                Dim documento As documentoventaTransporteDetalle = HeliosData.documentoventaTransporteDetalle.Where(Function(o) _
                                            o.idDocumento = idDocumento).FirstOrDefault

                If (Not IsNothing(documento)) Then

                    documento.idDistribucion = listaAsientoXBus.precio_id
                    HeliosData.SaveChanges()

                End If

                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class
