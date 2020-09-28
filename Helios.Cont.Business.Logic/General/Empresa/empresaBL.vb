Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class empresaBL
    Inherits BaseBL

    Public Function Test() As String
        Return "Conexion establecida"
    End Function

    Public Sub EditarEmpresa(be As empresa, listaCierre As List(Of empresaCierreMensual))
        Try


            Dim cierreBL As New empresaCierreMensualBL
            Using ts As New TransactionScope
                Dim obj = HeliosData.empresa.Where(Function(o) o.idEmpresa = be.idEmpresa).FirstOrDefault
                Dim estado = obj.estado
                obj.razonSocial = be.razonSocial
                obj.nombreCorto = be.nombreCorto
                obj.ruc = be.ruc
                obj.direccion = be.direccion
                obj.telefono = be.telefono
                obj.fax = be.fax
                obj.celular = be.celular
                obj.e_mail = be.e_mail
                obj.estado = be.estado
                Select Case estado
                    Case "0"
                        'If be.empresaCierreMensual.Count > 0 Then
                        '    For Each i In be.empresaCierreMensual
                        '        HeliosData.empresaCierreMensual.Add(i)
                        '    Next

                        '    'HeliosData.cierreinventario.Add(New cierreinventario With {.idEmpresa = be.idEmpresa,
                        '    '                                .idCentroCosto = GEstableciento.IdEstablecimiento,
                        '    '                                .periodo = String.Format("{0:00}", be.empresaCierreMensual.First.mes) & "" & be.empresaCierreMensual.First.anio,
                        '    '                                .idAlmacen = 0,
                        '    '                                .idItem = 0,
                        '    '                                .codigoLote = 0,
                        '    '                                })

                        'End If
                        If listaCierre.Count > 0 Then
                            For Each i In listaCierre
                                HeliosData.empresaCierreMensual.Add(i)
                                HeliosData.SaveChanges()
                            Next

                            'HeliosData.cierreinventario.Add(New cierreinventario With {.idEmpresa = be.idEmpresa,
                            '                                .idCentroCosto = GEstableciento.IdEstablecimiento,
                            '                                .periodo = String.Format("{0:00}", be.empresaCierreMensual.First.mes) & "" & be.empresaCierreMensual.First.anio,
                            '                                .idAlmacen = 0,
                            '                                .idItem = 0,
                            '                                .codigoLote = 0,
                            '                                })

                        End If
                    Case "1"

                End Select
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetObtenerEmpresas() As List(Of empresa)
        Return (From a In HeliosData.empresa).ToList
        'Where a.estado = "1" Select a
    End Function

    Public Function GetObtenerEmpresasPorID(strIdEmpresa As String) As empresa
        '      Return (From a In HeliosData.empresa Where a.estado = "1" And a.idEmpresa = strIdEmpresa Select a).First
        Try
            Return (From a In HeliosData.empresa Where a.idEmpresa = strIdEmpresa).SingleOrDefault

        Catch ex As Exception
            Throw New Exception("VERIFICAR/ACTUALIZAR RUC DE EMPRESA")
        End Try


    End Function

    Public Sub InsertarEmpresa(empresaBE As empresa, ListaMascaraContable2 As List(Of mascaraContable2), ListaCuentaMascara As List(Of cuentaMascara), ListamascaraGastosEmpresa As List(Of mascaraGastosEmpresa), ListacuentaplanContableEmpresa As List(Of cuentaplanContableEmpresa))
        Dim ent As New entidad
        Dim anioBL As New empresaPeriodoBL
        Dim estable As New centrocosto
        Dim almacen As New almacen
        Dim estableBL As New centrocostoBL
        Using ts As New TransactionScope
            Insert(empresaBE)

            For Each i In ListaMascaraContable2
                i.idEmpresa = empresaBE.idEmpresa
                HeliosData.mascaraContable2.Add(i)
            Next

            For Each i In ListaCuentaMascara
                i.idEmpresa = empresaBE.idEmpresa
                HeliosData.cuentaMascara.Add(i)
            Next

            For Each i In ListamascaraGastosEmpresa
                i.idEmpresa = empresaBE.idEmpresa
                HeliosData.mascaraGastosEmpresa.Add(i)
            Next

            estable = New centrocosto
            estable.idEmpresa = empresaBE.idEmpresa
            estable.nombre = empresaBE.nombreCorto
            estable.TipoEstab = "1"
            estable.usuarioActualizacion = "1"
            estable.fechaActualizacion = Date.Now
            Dim codEstable = estableBL.InsertEstablecimiento(estable)
            '   HeliosData.centrocosto.Add(estable)

            almacen = New almacen
            almacen.idEmpresa = empresaBE.idEmpresa
            almacen.idEstablecimiento = codEstable
            almacen.descripcionAlmacen = "ALMACEN CENTRAL"
            almacen.tipo = TipoAlmacen.Deposito
            almacen.estado = "S"
            almacen.usuarioModificacion = "1"
            almacen.fechaModificacion = Date.Now
            HeliosData.almacen.Add(almacen)

            'HeliosData.usp_insertarEntidadInicio(empresaBE.idEmpresa)

            anioBL.Insert(New empresaPeriodo With
                          {
                              .idEmpresa = empresaBE.idEmpresa,
                              .periodo = empresaBE.periodo.Value.Year,
                              .usuarioActualizacion = "1",
                              .fechaActualizacion = Date.Now
                          })


            'HeliosData.Database.ExecuteSqlCommand("SET IDENTITY_INSERT entidad ON")
            'ent = New entidad
            'ent.idEntidad = 0
            'ent.idEmpresa = empresaBE.idEmpresa
            'ent.tipoEntidad = "OT"
            'ent.nombre = "SIN IDENTIDAD"
            'ent.nombreCompleto = "SIN IDENTIDAD"
            'ent.estado = "A"
            'HeliosData.entidad.Add(ent)
            'HeliosData.Database.ExecuteSqlCommand("SET IDENTITY_INSERT entidad OFF")

            For Each i In ListacuentaplanContableEmpresa
                i.idEmpresa = empresaBE.idEmpresa
                HeliosData.cuentaplanContableEmpresa.Add(i)
            Next




            '            Dim results As IEnumerable(Of entidad) = exe(Of entidad) _
            '("SELECT contactname FROM customers WHERE city = {0}, 'London'")

            'For Each p In PLANCONTABLE
            '    ObjCuentas = New cuentaplanContableEmpresa
            '    ObjCuentas.idEmpresa = empresaBE.idEmpresa
            '    ObjCuentas.cuenta = p.cuenta
            '    ObjCuentas.cuentaPadre = p.cuentaPadre
            '    ObjCuentas.descripcion = p.descripcion
            '    ObjCuentas.usuarioModificacion = empresaBE.usuarioActualizacion
            '    ObjCuentas.fechaModificacion = empresaBE.fechaActualizacion
            '    HeliosData.cuentaplanContableEmpresa.Add(ObjCuentas)
            'Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub InsertarEmpresaOne(empresaBE As empresa, ListaMascaraContable2 As List(Of mascaraContable2), ListaCuentaMascara As List(Of cuentaMascara), ListamascaraGastosEmpresa As List(Of mascaraGastosEmpresa), ListacuentaplanContableEmpresa As List(Of cuentaplanContableEmpresa), listaCentroCostos As List(Of centrocosto))
        Try
            Dim ent As New entidad
            Dim anioBL As New empresaPeriodoBL
            Dim estable As New centrocosto
            Dim almacen As New almacen
            Dim estableBL As New centrocostoBL

            Dim estadosFinancierosBL As New estadosFinancierosBL
            Dim estadosFinancierosBE As New estadosFinancieros

            Using ts As New TransactionScope

                Dim listaCentroCostoUnidadNegocio As New List(Of centrocosto)

                estable = New centrocosto
                estable.idEmpresa = empresaBE.idEmpresa
                estable.nombre = "GERENTE GENEREAL"
                estable.TipoEstab = "UN"
                estable.idpadre = Nothing
                estable.usuarioActualizacion = "1"
                estable.fechaActualizacion = Date.Now
                Dim UnidadPadre = estableBL.InsertEstablecimiento(estable)

                estable = New centrocosto
                estable.idEmpresa = empresaBE.idEmpresa
                estable.nombre = "UO_ TI"
                estable.TipoEstab = "UA"
                estable.idpadre = UnidadPadre
                estable.usuarioActualizacion = "1"
                estable.fechaActualizacion = Date.Now
                Dim IdUnidadNegocio = estableBL.InsertEstablecimiento(estable)

                estable = New centrocosto
                estable.idEmpresa = empresaBE.idEmpresa
                estable.nombre = "LOGISTICA"
                estable.TipoEstab = "UA"
                estable.idpadre = UnidadPadre
                estable.usuarioActualizacion = "1"
                estable.fechaActualizacion = Date.Now
                Dim IdUnidadNegocio2 = estableBL.InsertEstablecimiento(estable)

                estable = New centrocosto
                estable.idEmpresa = empresaBE.idEmpresa
                estable.nombre = "COMERCIAL"
                estable.TipoEstab = "UA"
                estable.idpadre = UnidadPadre
                estable.usuarioActualizacion = "1"
                estable.fechaActualizacion = Date.Now
                Dim IdUnidadNegocio3 = estableBL.InsertEstablecimiento(estable)

                estable = New centrocosto
                estable.idEmpresa = empresaBE.idEmpresa
                estable.nombre = "FINANZAS"
                estable.TipoEstab = "UA"
                estable.idpadre = UnidadPadre
                estable.usuarioActualizacion = "1"
                estable.fechaActualizacion = Date.Now
                Dim IdUnidadNegocio5 = estableBL.InsertEstablecimiento(estable)

                estable = New centrocosto
                estable.idEmpresa = empresaBE.idEmpresa
                estable.nombre = "FINANZAS"
                estable.TipoEstab = "UA"
                estable.idpadre = UnidadPadre
                estable.usuarioActualizacion = "1"
                estable.fechaActualizacion = Date.Now
                Dim IdUnidadNegocio6 = estableBL.InsertEstablecimiento(estable)

                estable = New centrocosto
                estable.idEmpresa = empresaBE.idEmpresa
                estable.nombre = "RR.HH"
                estable.TipoEstab = "UA"
                estable.idpadre = UnidadPadre
                estable.usuarioActualizacion = "1"
                estable.fechaActualizacion = Date.Now
                Dim IdUnidadNegocio7 = estableBL.InsertEstablecimiento(estable)

                '//ALMACEN GRABAR POR UNIDAD DE NEGOCIO
                almacen = New almacen
                almacen.idEmpresa = empresaBE.idEmpresa
                almacen.idEstablecimiento = IdUnidadNegocio2
                almacen.descripcionAlmacen = "ALMACEN CENTRAL"
                almacen.tipo = TipoAlmacen.Deposito
                almacen.estado = "S"
                almacen.usuarioModificacion = "1"
                almacen.fechaModificacion = Date.Now
                HeliosData.almacen.Add(almacen)

                almacen = New almacen
                almacen.idEmpresa = empresaBE.idEmpresa
                almacen.idEstablecimiento = IdUnidadNegocio2
                almacen.descripcionAlmacen = "EN TRANSITO"
                almacen.tipo = "AV"
                almacen.estado = "S"
                almacen.usuarioModificacion = "1"
                almacen.fechaModificacion = Date.Now
                HeliosData.almacen.Add(almacen)


                '                '//ENTIDAD GRABAR POR UNIDAD DE NEGOCIO
                '                Dim clienteVarios As New entidad With
                '{
                '.idEmpresa = empresaBE.idEmpresa,
                '.idOrganizacion = IdUnidadNegocio,
                '.tipoEntidad = "VR",
                '.tipoPersona = "0",
                '.tipoDoc = "0",
                '.nrodoc = "0",
                '.nombreCompleto = "Varios",
                '.estado = "A"
                '}
                '                HeliosData.entidad.Add(clienteVarios)

                '    '//ENTIDAD GRABAR POR UNIDAD DE NEGOCIO
                '    anioBL.Insert(New empresaPeriodo With
                '              {
                '                  .idEmpresa = empresaBE.idEmpresa,
                '                  .idCentroCosto = IdUnidadNegocio,
                '                  .periodo = empresaBE.periodo.Value.Year,
                '                  .usuarioActualizacion = "1",
                '                  .fechaActualizacion = Date.Now
                '              })
                '                'Next

                HeliosData.SaveChanges()

                ts.Complete()
            End Using

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub InsertarEmpresaUnidadOrganica(empresaBE As empresa, IdUnidadNegocio As Integer)
        Try
            Dim ent As New entidad
            Dim anioBL As New empresaPeriodoBL
            Dim estable As New centrocosto
            Dim almacen As New almacen
            Dim estableBL As New centrocostoBL
            Using ts As New TransactionScope

                almacen = New almacen
                almacen.idEmpresa = empresaBE.idEmpresa
                almacen.idEstablecimiento = IdUnidadNegocio
                almacen.descripcionAlmacen = "EN TRANSITO"
                almacen.tipo = "AV"
                almacen.estado = "S"
                almacen.usuarioModificacion = "1"
                almacen.fechaModificacion = Date.Now
                HeliosData.almacen.Add(almacen)


                '//ALMACEN GRABAR POR UNIDAD DE NEGOCIO
                almacen = New almacen
                almacen.idEmpresa = empresaBE.idEmpresa
                almacen.idEstablecimiento = IdUnidadNegocio
                almacen.descripcionAlmacen = "ALMACEN CENTRAL"
                almacen.tipo = TipoAlmacen.Deposito
                almacen.estado = "S"
                almacen.usuarioModificacion = "1"
                almacen.fechaModificacion = Date.Now
                HeliosData.almacen.Add(almacen)


                '//ENTIDAD GRABAR POR UNIDAD DE NEGOCIO
                Dim clienteVarios As New entidad With
            {
            .idEmpresa = empresaBE.idEmpresa,
            .idOrganizacion = IdUnidadNegocio,
            .tipoEntidad = "VR",
            .tipoPersona = "0",
            .tipoDoc = "0",
            .nrodoc = "0",
            .nombreCompleto = "Varios",
            .estado = "A"
            }
                HeliosData.entidad.Add(clienteVarios)

                ''Insertra Categoria sin determinar
                'HeliosData.usp_insertarCategoriaInicio(empresaBE.idEmpresa, IdUnidadNegocio)



                '//ENTIDAD GRABAR POR UNIDAD DE NEGOCIO
                anioBL.Insert(New empresaPeriodo With
                          {
                              .idEmpresa = empresaBE.idEmpresa,
                              .idCentroCosto = IdUnidadNegocio,
                              .periodo = Date.Now.Year,
                              .usuarioActualizacion = "1",
                              .fechaActualizacion = Date.Now
                          })
                'Next

                HeliosData.SaveChanges()
                ts.Complete()
            End Using

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub Insert(empresaBE As empresa)
        Dim empresa As New empresa
        Try
            Using ts As New TransactionScope
                With empresaBE
                    empresa.idEmpresa = .idEmpresa
                    empresa.idclientespk = .idclientespk
                    empresa.razonSocial = .razonSocial
                    empresa.nombreCorto = .nombreCorto
                    empresa.ruc = .ruc
                    empresa.direccion = .direccion
                    empresa.telefono = .telefono
                    empresa.fax = .fax
                    empresa.celular = .celular
                    empresa.e_mail = .e_mail
                    empresa.regimen = "1" ' .regimen
                    empresa.actividad = .actividad
                    empresa.inicioOperacion = .inicioOperacion
                    empresa.usuarioActualizacion = .usuarioActualizacion
                    empresa.fechaActualizacion = .fechaActualizacion
                    empresa.estado = "0" ' .estado
                End With
                HeliosData.empresa.Add(empresa)
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetEmpresasXcliente(idclientespk As Integer) As List(Of empresa)
        Return HeliosData.empresa.Where(Function(o) o.idclientespk = idclientespk).ToList
    End Function

#Region "Transporte"
    Public Sub CrearBackupDatabase()
        'Using ts As New TransactionScope
        Dim NAMEDATABASE = "HELIOS"
        Dim backupname As String = "HELIOS" & DateTime.Now.ToString("yyyyMMddHHmm")
        Const sqlCommand As String = "BACKUP DATABASE [{0}] TO  DISK = N'{1}' WITH NOFORMAT, NOINIT,  NAME = N'HELIOS-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10"
        Dim path As Integer = HeliosData.Database.ExecuteSqlCommand(System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction, String.Format(sqlCommand, NAMEDATABASE, backupname))
        '        End Using
    End Sub

#End Region

End Class
