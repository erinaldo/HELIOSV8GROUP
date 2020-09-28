Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class datosGeneralesBL
    Inherits BaseBL

    Public Function UbicaEmpresaFull(datosgerales As datosGenerales) As List(Of datosGenerales)
        Try
            Dim datoGeneralBE As New datosGenerales
            Dim listaDatos As New List(Of datosGenerales)

            Dim consulta = (From a In HeliosData.datosGenerales Where a.idEmpresa = datosgerales.idEmpresa And a.idEstablecimiento = datosgerales.idEstablecimiento).ToList

            For Each item In consulta
                datoGeneralBE = New datosGenerales
                datoGeneralBE.idConfiguracion = item.idConfiguracion
                datoGeneralBE.idEmpresa = item.idEmpresa
                datoGeneralBE.idEstablecimiento = item.idEstablecimiento
                datoGeneralBE.idclientespk = item.idclientespk
                datoGeneralBE.razonSocial = item.razonSocial
                datoGeneralBE.nombreCorto = item.nombreCorto
                datoGeneralBE.ruc = item.ruc
                datoGeneralBE.direccionPrincipal = item.direccionPrincipal
                datoGeneralBE.direccionSecudaria = item.direccionSecudaria
                datoGeneralBE.telefono1 = item.telefono1
                datoGeneralBE.telefono2 = item.telefono2
                datoGeneralBE.telefono3 = item.telefono3
                datoGeneralBE.telefono4 = item.telefono4
                datoGeneralBE.e_mail = item.e_mail
                datoGeneralBE.password = item.password
                datoGeneralBE.logo = item.logo
                datoGeneralBE.posicionLogo = item.posicionLogo
                datoGeneralBE.nombreGiro = item.nombreGiro
                datoGeneralBE.formaImpresion = item.formaImpresion
                datoGeneralBE.formatoImpresion = item.formatoImpresion & "/" & item.nombreGiro
                datoGeneralBE.NombreFormato = item.formatoImpresion
                datoGeneralBE.nombreImpresion = item.nombreImpresion
                datoGeneralBE.tipoImpresion = item.tipoImpresion
                datoGeneralBE.publicidad = item.publicidad
                datoGeneralBE.nroImpresion = item.nroImpresion
                datoGeneralBE.condicionImpresion = item.condicionImpresion
                datoGeneralBE.predeterminado = item.predeterminado
                datoGeneralBE.nroCuentaSoles = item.nroCuentaSoles
                datoGeneralBE.nroCuentaDolares = item.nroCuentaDolares
                datoGeneralBE.nroCuentaSoles2 = item.nroCuentaSoles2
                datoGeneralBE.nroCuentaDolares2 = item.nroCuentaDolares2
                datoGeneralBE.glosario = item.glosario
                datoGeneralBE.formato = item.formato
                datoGeneralBE.usuarioActualizacion = item.usuarioActualizacion
                datoGeneralBE.fechaActualizacion = item.fechaActualizacion
                listaDatos.Add(datoGeneralBE)
            Next

            Return listaDatos

        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Public Function UbicaEmpresaID(idDatoGeneral As String) As datosGenerales
        Return (From a In HeliosData.datosGenerales Where a.idConfiguracion = idDatoGeneral Select a).FirstOrDefault
    End Function

    Public Function InsertEmpresa(datoGeneralBE As datosGenerales) As Integer
        Dim datosGeneralesBE As New datosGenerales
        Try
            Using ts As New TransactionScope
                With datoGeneralBE
                    datosGeneralesBE = New datosGenerales
                    datosGeneralesBE.idEmpresa = .idEmpresa
                    datosGeneralesBE.idEstablecimiento = .idEstablecimiento
                    datosGeneralesBE.idclientespk = .idclientespk
                    datosGeneralesBE.razonSocial = .razonSocial
                    datosGeneralesBE.nombreCorto = .nombreCorto
                    datosGeneralesBE.ruc = .ruc
                    datosGeneralesBE.direccionPrincipal = .direccionPrincipal
                    datosGeneralesBE.direccionSecudaria = .direccionSecudaria
                    datosGeneralesBE.telefono1 = .telefono1
                    datosGeneralesBE.telefono2 = .telefono2
                    datosGeneralesBE.telefono3 = .telefono3
                    datosGeneralesBE.telefono4 = .telefono4
                    datosGeneralesBE.e_mail = .e_mail
                    datosGeneralesBE.password = .password
                    datosGeneralesBE.logo = .logo
                    datosGeneralesBE.posicionLogo = .posicionLogo
                    datosGeneralesBE.nombreGiro = .nombreGiro
                    datosGeneralesBE.formaImpresion = .formaImpresion
                    datosGeneralesBE.formatoImpresion = .formatoImpresion
                    datosGeneralesBE.nombreImpresion = .nombreImpresion
                    datosGeneralesBE.tipoImpresion = .tipoImpresion
                    datosGeneralesBE.publicidad = .publicidad
                    datosGeneralesBE.nroImpresion = .nroImpresion
                    datosGeneralesBE.predeterminado = .predeterminado
                    datosGeneralesBE.condicionImpresion = .condicionImpresion
                    datosGeneralesBE.nroCuentaSoles = .nroCuentaSoles
                    datosGeneralesBE.nroCuentaDolares = .nroCuentaDolares
                    datosGeneralesBE.nroCuentaSoles2 = .nroCuentaSoles2
                    datosGeneralesBE.nroCuentaDolares2 = .nroCuentaDolares2
                    datosGeneralesBE.glosario = .glosario
                    datosGeneralesBE.formato = .formato
                    datosGeneralesBE.nroCuentaDetraccion = .nroCuentaDetraccion
                    datosGeneralesBE.nroCuentaDetraccion2 = .nroCuentaDetraccion2
                    datosGeneralesBE.usuarioActualizacion = .usuarioActualizacion
                    datosGeneralesBE.fechaActualizacion = .fechaActualizacion
                End With
                HeliosData.datosGenerales.Add(datosGeneralesBE)
                HeliosData.SaveChanges()
                ts.Complete()
                Return 0
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function updateDatos(objDatoGeneralBE As datosGenerales) As Integer
        Dim datosGeneralesBE As New datosGenerales
        Try
            Using ts As New TransactionScope

                'Dim datos As datosGenerales = HeliosData.datosGenerales.Where(Function(o) _
                '                            o.idConfiguracion = datoGeneralBE.idConfiguracion).FirstOrDefault
                EliminarImpresion(objDatoGeneralBE)

                If (Not IsNothing(objDatoGeneralBE)) Then
                    datosGeneralesBE = New datosGenerales
                    With objDatoGeneralBE
                        datosGeneralesBE.idEmpresa = .idEmpresa
                        datosGeneralesBE.idEstablecimiento = .idEstablecimiento
                        datosGeneralesBE.idclientespk = .idclientespk
                        datosGeneralesBE.razonSocial = .razonSocial
                        datosGeneralesBE.nombreCorto = .nombreCorto
                        datosGeneralesBE.ruc = .ruc
                        datosGeneralesBE.direccionPrincipal = .direccionPrincipal
                        datosGeneralesBE.direccionSecudaria = .direccionSecudaria
                        datosGeneralesBE.telefono1 = .telefono1
                        datosGeneralesBE.telefono2 = .telefono2
                        datosGeneralesBE.telefono3 = .telefono3
                        datosGeneralesBE.telefono4 = .telefono4
                        datosGeneralesBE.e_mail = .e_mail
                        datosGeneralesBE.password = .password
                        datosGeneralesBE.logo = .logo
                        datosGeneralesBE.posicionLogo = .posicionLogo
                        datosGeneralesBE.nombreGiro = .nombreGiro
                        datosGeneralesBE.formaImpresion = .formaImpresion
                        datosGeneralesBE.formatoImpresion = .formatoImpresion
                        datosGeneralesBE.nombreImpresion = .nombreImpresion
                        datosGeneralesBE.tipoImpresion = .tipoImpresion
                        datosGeneralesBE.publicidad = .publicidad
                        datosGeneralesBE.nroImpresion = .nroImpresion
                        datosGeneralesBE.condicionImpresion = .condicionImpresion
                        datosGeneralesBE.predeterminado = .predeterminado
                        datosGeneralesBE.nroCuentaSoles = .nroCuentaSoles
                        datosGeneralesBE.nroCuentaDolares = .nroCuentaDolares
                        datosGeneralesBE.glosario = .glosario
                        datosGeneralesBE.formato = .formato
                        datosGeneralesBE.nroCuentaSoles2 = .nroCuentaSoles2
                        datosGeneralesBE.nroCuentaDolares2 = .nroCuentaDolares2
                        datosGeneralesBE.nroCuentaDetraccion = .nroCuentaDetraccion
                        datosGeneralesBE.nroCuentaDetraccion2 = .nroCuentaDetraccion2
                        datosGeneralesBE.usuarioActualizacion = .usuarioActualizacion
                        datosGeneralesBE.fechaActualizacion = .fechaActualizacion
                    End With
                    HeliosData.datosGenerales.Add(datosGeneralesBE)
                    HeliosData.SaveChanges()
                    ts.Complete()
                End If

                Return 0
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub EliminarImpresion(datoGeneralBE As datosGenerales)
        Try
            Using ts As New TransactionScope
                Dim producto = HeliosData.datosGenerales.Where(Function(o) o.idConfiguracion = datoGeneralBE.idConfiguracion And
                                                                   o.idEmpresa = datoGeneralBE.idEmpresa).SingleOrDefault

                If Not IsNothing(producto) Then
                    CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(producto)
                    HeliosData.SaveChanges()
                Else
                    Throw New Exception("No se puede eliminar la impresion, no se ubica!")
                End If
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function updatePredeterminado(datoGeneralBE As datosGenerales) As Integer
        Dim datosGeneralesBE As New datosGenerales
        Try
            Using ts As New TransactionScope

                Dim datos = (From a In HeliosData.datosGenerales Where a.predeterminado = 1).FirstOrDefault

                If (Not IsNothing(datos)) Then

                    datos.predeterminado = 0
                    HeliosData.SaveChanges()

                    Dim consulta As datosGenerales = HeliosData.datosGenerales.Where(Function(o) _
                                           o.idConfiguracion = datoGeneralBE.idConfiguracion).FirstOrDefault

                    If (Not IsNothing(consulta)) Then
                        With datoGeneralBE
                            consulta.predeterminado = 1
                            HeliosData.SaveChanges()
                        End With

                    End If
                Else
                    Dim consulta As datosGenerales = HeliosData.datosGenerales.Where(Function(o) _
                                         o.idConfiguracion = datoGeneralBE.idConfiguracion).FirstOrDefault

                    If (Not IsNothing(consulta)) Then
                        With datoGeneralBE
                            consulta.predeterminado = 1
                            HeliosData.SaveChanges()
                        End With

                    End If
                End If
                ts.Complete()
                Return 0
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function


End Class
