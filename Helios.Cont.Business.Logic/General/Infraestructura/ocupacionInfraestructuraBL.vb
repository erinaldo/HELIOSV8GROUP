Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Imports System.Data.Entity
Public Class ocupacionInfraestructuraBL
    Inherits BaseBL

    Public Sub SaveOcupacionInfraestructura(objOcupacion As ocupacionInfraestructura)
        Dim obj As New ocupacionInfraestructura()
        Try
            Using ts As New TransactionScope

                obj = New ocupacionInfraestructura()
                'obj.[idPersonaBeneficio] = objCategoria.[idPersonaBeneficio]
                obj.[idOcupacion] = objOcupacion.[idOcupacion]
                obj.[idEmpresa] = objOcupacion.[idEmpresa]
                obj.[idEstablecimiento] = objOcupacion.[idEstablecimiento]
                obj.[idDistribucion] = objOcupacion.[idDistribucion]
                obj.[idEntidad] = objOcupacion.[idEntidad]
                obj.[chek_in] = objOcupacion.[chek_in]
                obj.[check_on] = objOcupacion.check_on
                obj.[estado] = objOcupacion.[estado]
                obj.[glosario] = objOcupacion.[glosario]
                obj.[usuarioActualizacion] = objOcupacion.[usuarioActualizacion]
                obj.[fechaActualizacion] = objOcupacion.[fechaActualizacion]

                HeliosData.ocupacionInfraestructura.Add(obj)
                HeliosData.SaveChanges()

                ts.Complete()
            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Function listaAlertaCheckOn(objOcupacion As ocupacionInfraestructura) As List(Of ocupacionInfraestructura)
        Dim lista As New List(Of ocupacionInfraestructura)
        Dim obj As New ocupacionInfraestructura

        Dim consulta = (From OI In HeliosData.ocupacionInfraestructura
                        Where OI.idEmpresa = objOcupacion.idEmpresa And
                            OI.check_on.Value.Year = objOcupacion.check_on.Value.Year And
                            OI.check_on.Value.Month = objOcupacion.check_on.Value.Month And
                            OI.check_on.Value.Day = objOcupacion.check_on.Value.Day And
                            OI.estado = "A"
                        Select
                            OI.idDistribucion,
                            OI.idOcupacion,
                            OI.chek_in,
                            OI.check_on,
                            OI.idEntidad,
                            OI.distribucionInfraestructura.descripcionDistribucion,
                            Numeracion = CType(OI.distribucionInfraestructura.numeracion, Int32?),
                            estadoInfra = OI.distribucionInfraestructura.estado,
                            EstadoOcupacion = OI.estado,
                            conteoVenta = (CType((Aggregate t1 In
                                                      (From DOC In HeliosData.documentoventaAbarrotesDet
                                                       Where
                                                           DOC.idDistribucion = OI.idDistribucion And
                                                           DOC.documentoventaAbarrotes.tipoVenta = "VNP"
                                                       Select New With {
                                                           DOC.importeMN
                                                           }) Into Sum(t1.ImporteMN)), Decimal?))).ToList

        For Each i In consulta
            obj = New ocupacionInfraestructura
            obj.idOcupacion = i.idOcupacion
            obj.idDistribucion = i.idDistribucion
            obj.idEntidad = i.idEntidad
            obj.chek_in = i.chek_in
            obj.check_on = i.check_on
            obj.estado = i.EstadoOcupacion
            obj.glosario = i.estadoInfra
            obj.conteoPago = i.conteoVenta.GetValueOrDefault
            obj.usuarioActualizacion = i.descripcionDistribucion & " - " & i.Numeracion
            lista.Add(obj)
        Next

        Return lista
    End Function

    Public Sub EditarOcupacionInfra(i As ocupacionInfraestructura)
        Dim distribucionBL As New distribucionInfraestructuraBL
        Dim personaBeneficioBl As New personaBeneficioBL
        Dim documentoVenta As New documentoventaAbarrotesBL
        Try
            Using ts As New TransactionScope
                Dim obj = (From n In HeliosData.ocupacionInfraestructura Where i.listaId.Contains(n.idDistribucion) And n.estado = "A").ToList

                For Each ITEM In obj
                    ITEM.estado = "C"
                    HeliosData.SaveChanges()
                Next

                documentoVenta.EditarPersonaBeneficio(i)
                personaBeneficioBl.EditarPersonaBeneficio(i)
                distribucionBL.EditarOcupacionInfra(i)
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function listaOcupacionInfraestructura(objOcupacion As ocupacionInfraestructura) As List(Of ocupacionInfraestructura)
        Try


            Dim lista As New List(Of ocupacionInfraestructura)
            Dim obj As New ocupacionInfraestructura

            'Dim consulta = (From oc In HeliosData.ocupacionInfraestructura
            '                Select
            '                    oc.idOcupacion,
            '                    oc.idEmpresa,
            '                    oc.idEstablecimiento,
            '                    oc.idDistribucion,
            '                    oc.idEntidad,
            '                    oc.chek_in,
            '                    oc.check_on,
            '                    oc.estado,
            '                    oc.glosario,
            '                    oc.distribucionInfraestructura.descripcionDistribucion,
            '                    Numeracion = CType(oc.distribucionInfraestructura.numeracion, Int32?),
            '                    oc.entidad.nombreCompleto,
            '                    oc.entidad.nrodoc).ToList

            Dim consulta = (From oc In HeliosData.ocupacionInfraestructura
                            Select
                                oc.idOcupacion,
                                oc.idEmpresa,
                                oc.idEstablecimiento,
                                oc.idDistribucion,
                                oc.idEntidad,
                                oc.chek_in,
                                oc.check_on,
                                oc.estado,
                                oc.glosario,
                                oc.distribucionInfraestructura.descripcionDistribucion,
                                Numeracion = CType(oc.distribucionInfraestructura.numeracion, Int32?)
                              ).ToList

            For Each i In consulta
                obj = New ocupacionInfraestructura
                obj.idOcupacion = i.idOcupacion
                obj.[idEmpresa] = i.[idEmpresa]
                obj.[idEstablecimiento] = i.[idEstablecimiento]
                obj.idDistribucion = i.idDistribucion
                obj.idEntidad = i.idEntidad
                obj.chek_in = i.chek_in
                obj.check_on = i.check_on
                obj.estado = i.estado
                'obj.glosario = i.nombreCompleto
                obj.usuarioActualizacion = i.descripcionDistribucion & " - " & i.Numeracion
                'obj.nroEntidad = i.nrodoc
                lista.Add(obj)
            Next

            Return lista
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function OcupacionInfra(objOcupacion As ocupacionInfraestructura) As ocupacionInfraestructura
        Try

            Dim obj As New ocupacionInfraestructura

            Dim consulta = (From oc In HeliosData.ocupacionInfraestructura Where oc.idDistribucion = objOcupacion.idDistribucion And
                                                                               oc.estado = objOcupacion.estado And
                                                                               oc.idDocumento = objOcupacion.idDocumento).FirstOrDefault

            Return consulta
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetListaOcupacionInfra(objOcupacion As ocupacionInfraestructura) As List(Of ocupacionInfraestructura)
        Try

            Dim obj As New ocupacionInfraestructura
            Dim ListaInfraestructura As New List(Of ocupacionInfraestructura)

            Dim consulta = (From OCU In HeliosData.ocupacionInfraestructura
                            Join DET In HeliosData.documentoventaAbarrotesDet On OCU.idDistribucion Equals DET.idDistribucion
                            Where
                                CLng(DET.documentoventaAbarrotes.idCliente) = objOcupacion.idEntidad And
                                DET.tipoExistencia = "IF" And
                                DET.estadoDistribucion = "A"
                            Select
                                OCU.idDocumento,
                                OCU.chek_in,
                                OCU.check_on,
                                DET.estadoDistribucion,
                                DET.nombreItem,
                                DET.secuencia,
                                IdDistribucion = CType(DET.idDistribucion, Int32?)).ToList

            For Each i In consulta
                obj = New ocupacionInfraestructura
                obj.idDistribucion = i.IdDistribucion
                obj.idEntidad = i.idDocumento
                obj.chek_in = i.chek_in
                obj.check_on = i.check_on
                obj.estado = i.estadoDistribucion
                obj.idDocumento = i.idDocumento
                obj.usuarioActualizacion = i.nombreItem

                ListaInfraestructura.Add(obj)
            Next

            Return ListaInfraestructura
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
