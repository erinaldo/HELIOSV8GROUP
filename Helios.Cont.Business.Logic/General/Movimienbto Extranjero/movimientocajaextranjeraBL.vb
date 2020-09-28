Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class movimientocajaextranjeraBL
    Inherits BaseBL

    Public Function GetMovimientosDetalleByDepodito(be As movimientocajaextranjera) As List(Of movimientocajaextranjera)
        Return HeliosData.movimientocajaextranjera.Where(Function(o) o.idDocumento = be.idDocumento).ToList
    End Function

    Public Sub EliminarPagos(iddocumentoCaja As Integer)

        Using ts As New TransactionScope
            Dim con = HeliosData.movimientocajaextranjera.Where(Function(o) o.idDocumentoCaja = iddocumentoCaja).ToList

            For Each i In con
                EliminarSingleton(i)
                '     CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(i)

                Dim sumPagosME = Aggregate n In HeliosData.movimientocajaextranjera _
                                 Where n.idDocumento = i.idDocumento Into _
                                 Suma = Sum(n.importe)

                Dim entrada = HeliosData.documentoCaja.Where(Function(o) o.idDocumento = i.idDocumento).FirstOrDefault

                If Not IsNothing(entrada) Then
                    'Dim saldo As Decimal = entrada.montoUsd - sumPagosME.GetValueOrDefault
                    'If saldo <= 0 Then
                    '    entrada.estadopago = StatusPagoMonedaExtranjera.Saldado
                    'Else
                    '    entrada.estadopago = StatusPagoMonedaExtranjera.Pendiente
                    'End If


                    Select Case entrada.moneda
                        Case "1"
                            Dim saldo As Decimal = entrada.montoSoles - sumPagosME.GetValueOrDefault
                            If saldo <= 0 Then
                                entrada.estadopago = StatusPagoMonedaExtranjera.Saldado
                            Else
                                entrada.estadopago = StatusPagoMonedaExtranjera.Pendiente
                            End If
                        Case "2"
                            Dim saldo As Decimal = entrada.montoUsd - sumPagosME.GetValueOrDefault
                            If saldo <= 0 Then
                                entrada.estadopago = StatusPagoMonedaExtranjera.Saldado
                            Else
                                entrada.estadopago = StatusPagoMonedaExtranjera.Pendiente
                            End If
                    End Select

                End If
            Next



            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub

    Sub EliminarSingleton(i As movimientocajaextranjera)
        Using ts As New TransactionScope
            CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(i)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Sub GrabarPagoSingleton(i As movimientocajaextranjera, iddocumentoCaja As Integer, fecha As DateTime)
        Dim obj As New movimientocajaextranjera
        Using ts As New TransactionScope

            obj = New movimientocajaextranjera
            obj.idDocumento = i.idDocumento
            obj.idDocumentoCaja = iddocumentoCaja
            obj.identidad = i.identidad
            obj.fecha = fecha
            obj.tipomovimiento = i.tipomovimiento
            obj.moneda = i.moneda
            obj.tipocambioorigen = i.tipocambioorigen
            obj.tipocambio = i.tipocambio
            obj.importe = i.importe
            obj.usuarioActualizacion = i.usuarioActualizacion
            obj.fechaActualizacion = i.fechaActualizacion
            HeliosData.movimientocajaextranjera.Add(obj)

            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub

    Public Sub GrabarListaPagos(be As documentoCaja, iddocumentoCaja As Integer)

        Using ts As New TransactionScope
            For Each i In be.movimientocajaextranjera

                GrabarPagoSingleton(i, iddocumentoCaja, be.fechaProceso)

                Dim sumPagosME = Aggregate n In HeliosData.movimientocajaextranjera
                                 Where n.idDocumento = i.idDocumento Into
                                 Suma = Sum(n.importe)

                Dim entrada = HeliosData.documentoCaja.Where(Function(o) o.idDocumento = i.idDocumento).FirstOrDefault

                If Not IsNothing(entrada) Then

                    Select Case entrada.moneda
                        Case "1"
                            Dim saldo As Decimal = entrada.montoSoles - sumPagosME
                            If saldo <= 0 Then
                                entrada.estadopago = StatusPagoMonedaExtranjera.Saldado
                            Else
                                entrada.estadopago = StatusPagoMonedaExtranjera.Pendiente
                            End If
                        Case "2"
                            Dim saldo As Decimal = entrada.montoUsd - sumPagosME
                            If saldo <= 0 Then
                                entrada.estadopago = StatusPagoMonedaExtranjera.Saldado
                            Else
                                entrada.estadopago = StatusPagoMonedaExtranjera.Pendiente
                            End If
                    End Select


                End If

            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


End Class
