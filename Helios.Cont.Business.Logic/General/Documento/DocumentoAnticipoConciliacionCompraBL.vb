Imports System.Transactions
Imports Helios.Cont.Business.Entity

Public Class DocumentoAnticipoConciliacionCompraBL

    Inherits BaseBL

    Public Function GetMovimientosByCajaUsuario(be As DocumentoAnticipoConciliacionCompra) As List(Of DocumentoAnticipoConciliacionCompra)
        Dim con = (From p In HeliosData.documentoAnticipoConciliacionCompra
                   Where
                       p.fechaRegistro.Value.Year = be.fechaRegistro.Value.Year And
                       p.fechaRegistro.Value.Month = be.fechaRegistro.Value.Month And
                       p.fechaRegistro.Value.Day = be.fechaRegistro.Value.Day And
                       p.idCajaUsuario = be.idCajaUsuario
                   Group p By
                           p.tipoOperacion
                  Into g = Group
                   Select New With {
                                        .tipoMov = tipoOperacion,
                                        g, .TotalMontoMN = g.Sum(Function(p) p.importe)
                                        }
                           ).ToList

        GetMovimientosByCajaUsuario = New List(Of DocumentoAnticipoConciliacionCompra)
        For Each i In con
            GetMovimientosByCajaUsuario.Add(New DocumentoAnticipoConciliacionCompra With
                                            {
                                            .tipoOperacion = i.tipoMov,
                                            .importe = i.TotalMontoMN.GetValueOrDefault
                                            })
        Next

    End Function

    Public Function GetMovimientosByDocumento(be As DocumentoAnticipoConciliacionCompra) As List(Of DocumentoAnticipoConciliacionCompra)
        Dim con = (From p In HeliosData.documentoAnticipoConciliacionCompra
                   Where
                       p.idDocumento = be.idDocumento
                   Select New With
                      {
                      p.secuencia,
                       p.fechaRegistro,
                       p.idDocumento,
                       p.tipoOperacion,
                       p.idItem,
                       p.detalle,
                       p.importe,
                       p.idCajaUsuario
                      }).ToList

        GetMovimientosByDocumento = New List(Of DocumentoAnticipoConciliacionCompra)
        For Each i In con
            GetMovimientosByDocumento.Add(New DocumentoAnticipoConciliacionCompra With
                                            {
                                             .secuencia = i.secuencia,
                                             .fechaRegistro = i.fechaRegistro,
                                             .idDocumento = i.idDocumento,
                                             .tipoOperacion = i.tipoOperacion,
                                             .idItem = i.idItem,
                                             .detalle = i.detalle,
                                             .importe = i.importe,
                                             .idCajaUsuario = i.idCajaUsuario
                                            })
        Next

    End Function


    Public Sub Insert(be As DocumentoAnticipoConciliacionCompra)
        Using ts As New TransactionScope
            HeliosData.documentoAnticipoConciliacionCompra.Add(be)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

End Class
