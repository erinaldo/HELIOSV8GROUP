Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class CompensacionBL

    Inherits BaseBL


    Public Function SaveTablaCompensacion(idDocumentoOrigen As Integer, idDocumentoDestino As Integer, opeOrigen As String, opeDestino As String) As Integer

        Try
            Dim documento As New Compensacion

            ''Dim cval As Integer = 0
            Using ts As New TransactionScope

                'cval = Convert.ToInt32(numeracionBL.GenerarNumeroPorID(documentoBE.documentocompra.IdNumeracion))

                documento.idDocumentoOrigen = idDocumentoOrigen
                documento.idDocumentoDestino = idDocumentoDestino
                documento.operacionOrigen = opeOrigen
                documento.operacionDestino = opeDestino

                HeliosData.Compensacion.Add(documento)
                HeliosData.SaveChanges()
                ts.Complete()
                Return 0
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub EliminarCompensacion(idDocOrigen As Integer)
        Dim documentoBl As New documentoBL

        Try

            Using ts As New TransactionScope()
                Dim Datos As Compensacion = Me.GetExistenCompensacion(idDocOrigen)
                'actualizar origen
                If Datos.operacionOrigen = "02" Then
                    Me.UpdateDocumentoOrigen(Datos.idDocumentoOrigen)
                ElseIf Datos.operacionOrigen = "07" Then
                    Me.UpdateDocumentoOrigenCompra(Datos.idDocumentoOrigen)
                End If

                'actualizar Destino
                If Datos.operacionDestino = "02" Then
                    Me.UpdateDocumentoOrigen(Datos.idDocumentoDestino)
                ElseIf Datos.operacionOrigen = "07" Then
                    Me.UpdateDocumentoOrigenCompra(Datos.idDocumentoDestino)
                End If
                '//////////////////////////////////////////////////////////


                'eliminar documentos de compensacion
                'origen
                documentoBl.DeleteSingleVariable(Datos.idDocumentoOrigen)
                'destino
                documentoBl.DeleteSingleVariable(Datos.idDocumentoDestino)
                'documentoBl.DeleteSingleVariableSL(Datos.idDocumentoDestino)
                '/////////////////////////////////////////////////////////////////////7

                'eliminar tabla compensancion
                Me.DeleteSingle(Datos.idDocumentoOrigen)


                HeliosData.SaveChanges()
                ts.Complete()
            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    Public Function GetExistenCompensacion(idDocOrigen As Integer) As Compensacion

        Dim ExistenCompensacion = HeliosData.Compensacion.Where(Function(o) o.idDocumentoOrigen = idDocOrigen).FirstOrDefault
        Return ExistenCompensacion

    End Function

    Public Sub UpdateDocumentoOrigenCompra(idDocOrigen As Integer)


        Dim objNuevo As New documentocompra()
        Dim objDocAfectado As New documentocompra()
        Using ts As New TransactionScope()

            objNuevo = HeliosData.documentocompra.Where(Function(o) o.idDocumento = idDocOrigen).FirstOrDefault


            objDocAfectado = HeliosData.documentocompra.Where(Function(o) o.idDocumento = objNuevo.idPadre).FirstOrDefault
            'updatedetalleAfectado
            Dim DetalleAfectado = HeliosData.documentocompradetalle.Where(Function(o) o.idDocumento = idDocOrigen).ToList

            For Each i In DetalleAfectado
                UpdateDocumentoOrigenDetalleCompra(i.idPadreDTCompra)

            Next


            If Not IsNothing(objDocAfectado) Then
                objDocAfectado.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO

            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using


    End Sub



    Public Sub UpdateDocumentoOrigen(idDocOrigen As Integer)


        Dim objNuevo As New documentoventaAbarrotes()
        Dim objDocAfectado As New documentoventaAbarrotes()
        Using ts As New TransactionScope()

            objNuevo = HeliosData.documentoventaAbarrotes.Where(Function(o) o.idDocumento = idDocOrigen).FirstOrDefault


            objDocAfectado = HeliosData.documentoventaAbarrotes.Where(Function(o) o.idDocumento = objNuevo.idPadre).FirstOrDefault
            'updatedetalleAfectado
            Dim DetalleAfectado = HeliosData.documentoventaAbarrotesDet.Where(Function(o) o.idDocumento = idDocOrigen).ToList

            For Each i In DetalleAfectado
                UpdateDocumentoOrigenDetalle(i.idPadreDTVenta)
            Next


            If Not IsNothing(objDocAfectado) Then
                objDocAfectado.estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO

            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using


    End Sub

    Public Sub UpdateDocumentoOrigenDetalleCompra(secuenciaAfectada As Integer)

        Dim objNuevo As New documentocompradetalle()

        Using ts As New TransactionScope()

            objNuevo = HeliosData.documentocompradetalle.Where(Function(o) o.secuencia = secuenciaAfectada).FirstOrDefault

            If Not IsNothing(objNuevo) Then

                objNuevo.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO

            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub


    Public Sub UpdateDocumentoOrigenDetalle(secuenciaAfectada As Integer)

        Dim objNuevo As New documentoventaAbarrotesDet()

        Using ts As New TransactionScope()

            objNuevo = HeliosData.documentoventaAbarrotesDet.Where(Function(o) o.secuencia = secuenciaAfectada).FirstOrDefault

            If Not IsNothing(objNuevo) Then

                objNuevo.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO

            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub


    Public Sub DeleteSingle(ByVal idDocOrigen As Integer)
        Dim totalesCajaUsuario As New CajaUsuarioBL
        'Dim consulta As Compensacion = HeliosData.Compensacion.Where(Function(o) o.idDocumentoOrigen = idDocOrigen).FirstOrDefault
        'If Not IsNothing(consulta) Then
        '    '   totalesCajaUsuario.DeleteTotalesCajaUsuarioDocCajaDetalle(documentoBE.idDocumento, documentoBE.usuarioActualizacion, documentoBE.IdDocumentoAfectado)
        '    CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)
        '    HeliosData.SaveChanges()
        'Else
        '    Throw New Exception("El comprobante no se encuentra, verifique su existencia!")
        'End If

        Dim consulta As Compensacion = HeliosData.Compensacion.Where(Function(o) o.idDocumentoOrigen = idDocOrigen).FirstOrDefault
        Using ts As New TransactionScope
            If Not IsNothing(consulta) Then
                CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub

End Class
