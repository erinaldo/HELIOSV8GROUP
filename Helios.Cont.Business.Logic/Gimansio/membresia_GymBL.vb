Imports System.Transactions
Imports Helios.Cont.Business.Entity
Imports System.Data.Entity.Migrations
Imports Helios.General
Public Class membresia_GymBL
    Inherits BaseBL

    Public Sub GrabarMembresia(be As membresia_Gym)
        Using ts As New TransactionScope
            HeliosData.membresia_Gym.Add(be)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function UbicarMembresia(id As Integer) As membresia_Gym
        Return HeliosData.membresia_Gym.Where(Function(o) o.idMembresia = id).FirstOrDefault
    End Function

    Public Sub EditarMembresia(be As membresia_Gym)
        Using ts As New TransactionScope
            '  Dim con = HeliosData.membresia_Gym.Where(Function(o) o.idMembresia = be.idMembresia).FirstOrDefault
            'Dim entry = HeliosData.Entry(be)
            'entry.CurrentValues.SetValues(be)
            HeliosData.membresia_Gym.AddOrUpdate(be)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function GetMembresias() As List(Of membresia_Gym)
        Return HeliosData.membresia_Gym.ToList
    End Function

    Public Function GetMembresiasByStatus(be As membresia_Gym) As List(Of membresia_Gym)
        Return HeliosData.membresia_Gym.Where(Function(o) o.idEmpresa = be.idEmpresa And o.status = be.status).ToList
    End Function

    Public Sub GrabarClienteMembresia(documento As documento)
        Dim documentoBL As New documentoBL
        Dim documentocajaBL As New documentoCajaBL
        Dim documentocajadelleBL As New documentoCajaDetalleBL
        Dim numeracionBL As New numeracionBoletasBL
        Dim numeracionAuto As New numeracionBoletas
        Try
            Using ts As New TransactionScope

                'Validando si existe una membresia ctiva del socio
                Dim socioTieneMembresia = HeliosData.Entidadmembresia_Gym.Where(Function(o) o.idEntidad = documento.Entidadmembresia_Gym.idEntidad And
                                                                                    o.idEmpresa = documento.Entidadmembresia_Gym.idEmpresa And
                                                                                    o.statusMembresia = Gimnasio_EstadoMembresia.Activo).FirstOrDefault
                If socioTieneMembresia IsNot Nothing Then
                    Throw New Exception("El cliente ya posee una membresía activa, cierre primero la membresía activa")
                End If

                'Insertando Documento
                Select Case documento.IsFormatoGeneral
                    Case True
                        documentoBL.Insert(documento)
                        Dim idDocumentoMembresia = documento.idDocumento
                        'Insertar Membresia cliente
                        documento.Entidadmembresia_Gym.idDocumento = idDocumentoMembresia
                        HeliosData.Entidadmembresia_Gym.Add(documento.Entidadmembresia_Gym)

                        'Insertando documento caja
                        If Not IsNothing(documento.CustomDocumentoCaja) Then
                            documento.CustomDocumentoCaja.nroDoc = documento.Entidadmembresia_Gym.serie & "-" & documento.Entidadmembresia_Gym.numero
                            documento.CustomDocumentoCaja.documentoCaja.numeroDoc = documento.Entidadmembresia_Gym.serie & "-" & documento.Entidadmembresia_Gym.numero
                            documentocajaBL.SaveGroupCajaDefaultGym(documento.CustomDocumentoCaja, idDocumentoMembresia)
                        End If

                    Case Else
                        numeracionAuto = numeracionBL.GenerarNumeroPorCodigoEmpresa("GYM TICKET", Gempresas.IdEmpresaRuc, documento.tipoDoc, GEstableciento.IdEstablecimiento)

                        If numeracionAuto IsNot Nothing Then
                            documento.nroDoc = numeracionAuto.serie & "-" & numeracionAuto.valorInicial
                            documentoBL.Insert(documento)
                            Dim idDocumentoMembresia = documento.idDocumento
                            'Insertar Membresia cliente
                            documento.Entidadmembresia_Gym.idDocumento = idDocumentoMembresia
                            documento.Entidadmembresia_Gym.serie = numeracionAuto.serie
                            documento.Entidadmembresia_Gym.numero = numeracionAuto.valorInicial
                            HeliosData.Entidadmembresia_Gym.Add(documento.Entidadmembresia_Gym)

                            'Insertando documento caja
                            If Not IsNothing(documento.CustomDocumentoCaja) Then
                                documento.CustomDocumentoCaja.nroDoc = numeracionAuto.serie & "-" & numeracionAuto.valorInicial
                                documento.CustomDocumentoCaja.documentoCaja.numeroDoc = numeracionAuto.serie & "-" & numeracionAuto.valorInicial
                                documentocajaBL.SaveGroupCajaDefaultGym(documento.CustomDocumentoCaja, idDocumentoMembresia)
                            End If
                        Else
                            Throw New Exception("No tiene registrado comprobantes internos, para realizar está operación!")
                        End If

                End Select

                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub GetCambiarEstado(be As membresia_Gym)
        Using ts As New TransactionScope
            Dim ob = HeliosData.membresia_Gym.Where(Function(o) o.idMembresia = be.idMembresia).FirstOrDefault
            If ob IsNot Nothing Then
                ob.status = be.status
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub
End Class
