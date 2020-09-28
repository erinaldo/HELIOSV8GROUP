Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Imports System.Data.Entity
Public Class entidadBL
    Inherits BaseBL

#Region "DEPURADO"
    Public Function GetListarEntidad(EntidadBE As entidad) As List(Of entidad)
        Try

            '  objTipo As String, strIdEmpresa As String, idEstable As Integer, tipoCosulta As String

            Dim listadoAtributos As List(Of entidadAtributos)
            GetListarEntidad = New List(Of entidad)

            Select Case EntidadBE.tipoConsulta
                Case "EMPRESA"

                    Dim con = HeliosData.entidad.Include(Function(at) at.entidadAtributos).Where(Function(o) o.idEmpresa = EntidadBE.idEmpresa).ToList

                    For Each i In con
                        listadoAtributos = New List(Of entidadAtributos)
                        For Each at In i.entidadAtributos
                            Dim atributo As New entidadAtributos With
                            {
                            .idAtributo = at.idAtributo,
                            .tipo = at.tipo,
                            .valorAtributo = at.valorAtributo,
                            .estado = at.estado,
                            .usuarioModificacion = at.usuarioModificacion,
                            .fechaModificacion = at.fechaModificacion
                            }
                            listadoAtributos.Add(atributo)
                            'i.entidadAtributos.Add(atributo)
                        Next
                        i.entidadAtributos = listadoAtributos
                        GetListarEntidad.Add(i)
                    Next

                Case "UNIDAD_ORGANICA"

                    Dim con = HeliosData.entidad.Include(Function(at) at.entidadAtributos).Where(Function(o) o.idEmpresa = EntidadBE.idEmpresa AndAlso o.idOrganizacion = EntidadBE.idOrganizacion).ToList

                    For Each i In con
                        listadoAtributos = New List(Of entidadAtributos)
                        For Each at In i.entidadAtributos
                            Dim atributo As New entidadAtributos With
                            {
                            .idAtributo = at.idAtributo,
                            .tipo = at.tipo,
                            .valorAtributo = at.valorAtributo,
                            .estado = at.estado,
                            .usuarioModificacion = at.usuarioModificacion,
                            .fechaModificacion = at.fechaModificacion
                            }
                            listadoAtributos.Add(atributo)
                            'i.entidadAtributos.Add(atributo)
                        Next
                        i.entidadAtributos = listadoAtributos
                        GetListarEntidad.Add(i)
                    Next

            End Select

            Return GetListarEntidad

        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

    Public Function UbicarEntidadPorIdEntidad(strEmpresa As String, strTipoEntidad As String, idEntidad As Integer) As entidad
        Return (From n In HeliosData.entidad Where n.tipoEntidad = strTipoEntidad _
                And n.idEntidad = idEntidad).FirstOrDefault
    End Function

    Public Function UbicarClientePoID(ByVal strNroPersona As String) As entidad

        Dim consulta = (From p In HeliosData.entidad
                        Where p.nrodoc = strNroPersona
                        Select p).FirstOrDefault

        Return consulta
    End Function

    Public Function UbicarClienteXID(ByVal entidadBE As entidad) As entidad

        Dim consulta = (From p In HeliosData.entidad
                        Where
                            p.nrodoc = entidadBE.nrodoc And
                            p.idEmpresa = entidadBE.idEmpresa And
                            p.tipoEntidad = "CL"
                        Select p).FirstOrDefault

        Return consulta

    End Function

    Public Sub InsertGrupoEntidad(list As List(Of entidad))
        Dim entidad As New entidad
        Dim documento As New documento
        Dim documentoBL As New documentoBL
        Dim documentoSaldo As New saldoInicio
        Dim documentoSaldoBL As New saldoInicialBL
        Dim inicioDetalleBL As New saldoInicioDetalleBL

        Dim SumaMN As Decimal = list.Sum(Function(o) o.ImporteMN)
        Dim SumaME As Decimal = list.Sum(Function(o) o.ImporteME)

        Using ts As New TransactionScope
            documento = New documento With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                            .idCentroCosto = GEstableciento.IdEstablecimiento,
                                            .tipoDoc = "",
                                            .fechaProceso = DateTime.Now,
                                            .tipoOperacion = "",
                                            .usuarioActualizacion = list(0).usuarioModificacion
                }
            documentoBL.Insert(documento)

            documentoSaldo = New saldoInicio With {
                .TipoConfiguracion = GConfiguracion.TipoConfiguracion,
                .IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante),
                .idDocumento = documento.idDocumento,
                .codigoLibro = "8",
                .idEmpresa = Gempresas.IdEmpresaRuc,
                .idCentroCosto = GEstableciento.IdEstablecimiento,
                .fechaDoc = DateTime.Now,
                .fechaVcto = Nothing,
                .periodo = PeriodoGeneral,
                .tipoDoc = "9901",
                .serie = GConfiguracion.Serie,
                .numeroDoc = Nothing,
                .idPersona = list(0).usuarioModificacion,
                .tipoPersona = "PR",
                .monedaDoc = list(0).moneda,
                .tasaIgv = TmpIGV,
                .tcDolLoc = TmpTipoCambio,
                .importeTotal = SumaMN,
                .importeUS = SumaME,
                .destino = Nothing,
                .estadoPago = "PN",
                .glosa = "Saldo de Inicio",
                .tipoCompra = TIPO_COMPRA.SALDO_INICIAL,
                .idPadre = Nothing,
                .usuarioActualizacion = list(0).usuarioModificacion,
                .fechaActualizacion = DateTime.Now
        }
            documentoSaldoBL.Insert(documentoSaldo, documento.idDocumento)

            For Each i In list
                Select Case i.tipoEntidad
                    Case TIPO_ENTIDAD.PROVEEDOR
                        i.cuentaAsiento = "4212"
                    Case TIPO_ENTIDAD.CLIENTE
                        i.cuentaAsiento = "1213"
                End Select
                Dim codEntidad As Integer = Insert(i) 'insertando entidades
                i.idEntidad = codEntidad
                SaldoInicioDetalleGrabar(i, documento.idDocumento)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Sub SaldoInicioDetalleGrabar(entidad As entidad, intIdDocumento As Integer)
        Dim saldoDetalle As New saldoInicioDetalle
        Using ts As New TransactionScope
            saldoDetalle.idDocumento = intIdDocumento
            saldoDetalle.modulo = entidad.tipoEntidad
            saldoDetalle.idModulo = entidad.idEntidad
            saldoDetalle.idItem = entidad.moneda
            saldoDetalle.descripcionItem = entidad.nombreCompleto
            saldoDetalle.tipoExistencia = entidad.tipoEntidad
            saldoDetalle.cantidad = entidad.tipoCambio
            saldoDetalle.tipoAsiento = Nothing
            saldoDetalle.precioUnitario = 0
            saldoDetalle.precioUnitarioUS = 0
            saldoDetalle.importe = entidad.ImporteMN
            saldoDetalle.importeUS = entidad.ImporteME
            saldoDetalle.bonificacion = Nothing
            saldoDetalle.almacen = Nothing
            saldoDetalle.caja = Nothing
            saldoDetalle.usuarioModificacion = entidad.usuarioModificacion
            saldoDetalle.fechaModificacion = DateTime.Now

            HeliosData.saldoInicioDetalle.Add(saldoDetalle)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
        
    End Sub

    Public Function BuscarEntidadXdescripcion(strEmpresa As String, strTipoEntidad As String, strBusqueda As String) As List(Of entidad)
        Dim lista As New List(Of entidad)
        lista = (From n In HeliosData.entidad
                 Where
                     n.idEmpresa = strEmpresa And
                     n.tipoEntidad = strTipoEntidad And
                     n.nombreCompleto.Contains(strBusqueda) Take 25 Order By n.nombreCompleto).ToList

        Return lista
    End Function

    Public Function UbicarEntidadPorRucNro(strEmpresa As String, strTipoEntidad As String, strNroDoc As String) As entidad
        Return (From n In HeliosData.entidad Where n.tipoEntidad = strTipoEntidad _
                And n.nrodoc = strNroDoc).FirstOrDefault
    End Function

    Public Function GrabarSocioGym(ByVal entidadBE As entidad) As Integer
        Try
            Dim ruc As entidad = HeliosData.entidad.Where(Function(o) o.nrodoc = entidadBE.nrodoc And o.tipoEntidad = entidadBE.tipoEntidad).FirstOrDefault

            If IsNothing(ruc) Then
                Using ts As New TransactionScope
                    'Se inserta entidad
                    HeliosData.entidad.Add(entidadBE)
                    HeliosData.SaveChanges()
                    ts.Complete()
                    Return entidadBE.idEntidad
                End Using
            Else
                Throw New Exception("El ruc ingresado ya esta registrado, ingrese otro!")
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function Insert(ByVal entidadBE As entidad) As Integer
        Try
            Dim ruc As entidad = HeliosData.entidad.Where(Function(o) o.nrodoc = entidadBE.nrodoc And o.tipoEntidad = entidadBE.tipoEntidad And o.idOrganizacion = entidadBE.idOrganizacion).FirstOrDefault

            If IsNothing(ruc) Then
                Using ts As New TransactionScope
                    'Se inserta entidad
                    HeliosData.entidad.Add(entidadBE)
                    If entidadBE.EnvioEntidades = True Then
                        If (entidadBE.tipoEntidad = TIPO_ENTIDAD.CLIENTE) Then
                            entidadBE.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
                            entidadBE.cuentaAsiento = "4212"
                        ElseIf (entidadBE.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR) Then
                            entidadBE.tipoEntidad = TIPO_ENTIDAD.CLIENTE
                            entidadBE.cuentaAsiento = "1212"
                        End If
                        HeliosData.entidad.Add(entidadBE)
                    End If
                    HeliosData.SaveChanges()
                    ts.Complete()
                    Return entidadBE.idEntidad
                End Using
            Else
                Throw New Exception("El ruc ingresado ya esta registrado, ingrese otro!")
            End If
            
        Catch ex As Exception
            Throw ex
        End Try
      
    End Function

    Public Sub Update(ByVal entidadBE As entidad)
        Using ts As New TransactionScope
            'Se actualiza entidadBE
            'HeliosData.asiento.Attach(asientoBE)
            HeliosData.entidad.Attach(entidadBE)
            HeliosData.Entry(entidadBE).State = System.Data.Entity.EntityState.Modified
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal entidadBE As entidad)
        Using ts As New TransactionScope
            Dim entidad As entidad = HeliosData.entidad.Where(Function(o) o.idEntidad = entidadBE.idEntidad).FirstOrDefault
            entidad.estado = entidadBE.estado
            'If Not IsNothing(entidad) Then
            '    CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(entidad)
            'End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub



    Public Function GetEntidadesGenerales(tipo As String, strIdEmpresa As String) As List(Of entidad)
        Return (From a In HeliosData.entidad
                Where a.tipoEntidad = tipo
                Select a Order By a.nombreCompleto).ToList
    End Function

    Public Function GetUbicarEntidadPorID(intIdEntidad As Integer) As List(Of entidad)
        Return (From a In HeliosData.entidad
                Where a.idEntidad = intIdEntidad _
                Select a).ToList
    End Function


    Public Function ListarEntidadesPorNombres(ByVal strtipo As String, ByVal strEmpresa As String, ByVal strBusqueda As String) As List(Of entidad)
        Dim consulta = (From p In HeliosData.entidad _
                     Where p.tipoEntidad = strtipo _
                     AndAlso p.nombreCompleto.Contains(strBusqueda) _
                     AndAlso p.estado = "A" _
                     Order By p.nombreCompleto Ascending _
                     Select p).ToList

        Return consulta
    End Function

    Public Function ListarEntidadesPorRuc(ByVal strtipo As String, ByVal strEmpresa As String, ByVal strBusqueda As String) As List(Of entidad)

        Dim consulta = (From p In HeliosData.entidad _
                     Where p.tipoEntidad = strtipo _
                     AndAlso p.nrodoc.StartsWith(strBusqueda) _
                     AndAlso p.estado = "A" _
                     Order By p.nombreCompleto Ascending _
                     Select p).ToList

        Return consulta
    End Function

    Public Function UbicarEntidadVarios(ByVal strtipo As String, ByVal strEmpresa As String, ByVal strBusqueda As String, idEstablecimiento As Integer) As entidad

        Dim consulta = (From p In HeliosData.entidad
                        Where p.tipoEntidad = strtipo _
                     AndAlso p.idEmpresa = strEmpresa _
                            AndAlso p.idOrganizacion = idEstablecimiento _
                     AndAlso p.nombreCompleto = ("VARIOS") _
                     AndAlso p.estado = "A").First

        Return consulta
    End Function

    Public Function GetUbicarEntPorID(strEmpresa As String, intIdEntidad As Integer) As entidad
        Return (From a In HeliosData.entidad
                Where a.idEntidad = intIdEntidad And
                a.idEmpresa = strEmpresa
                Select a).FirstOrDefault
    End Function

#Region "restautant"
    Public Function UbicarEntidadPorRucNroxIdDistribucion(strEmpresa As String, strTipoEntidad As String, strNroDoc As String) As List(Of entidad)
        Dim entidadBE As New entidad
        Dim listaEntidad As New List(Of entidad)

        Dim consulta = (From det In HeliosData.documentoventaAbarrotesDet
                        Join ent In HeliosData.entidad On CType(CInt(det.documentoventaAbarrotes.idCliente), Int32?) Equals ent.idEntidad
                        Where
                           det.estadoDistribucion = strTipoEntidad And
                            ent.nrodoc = strNroDoc
                        Select New With {
                            det.idDocumento,
                            det.secuencia,
                            det.idDistribucion,
                            ent.idEntidad,
                            ent.nrodoc,
                            ent.nombreCompleto}).ToList

        For Each item In consulta
            entidadBE = New entidad
            entidadBE.idEntidad = item.idEntidad
            entidadBE.nrodoc = item.nrodoc
            entidadBE.nombreCompleto = item.nombreCompleto
            entidadBE.listaDistribucion = (item.idDistribucion)
            entidadBE.idOrganizacion = (item.idDocumento)
            entidadBE.idEmpresa = (item.secuencia)

            listaEntidad.Add(entidadBE)
        Next

        Return listaEntidad

    End Function

    Public Function GetListaClientesAndHuesped(strEmpresa As String, strTipoEntidad As String) As List(Of entidad)
        Dim entidadBE As New entidad
        Dim listaEntidad As New List(Of entidad)

        Dim consultaEntidad = (From det In HeliosData.entidad Where det.idEntidad = strEmpresa And (det.tipoEntidad = "CL" Or det.tipoEntidad = "CLE")).ToList

        Dim consultaHospedados = (From det In HeliosData.personaBeneficio Where det.idEntidad = strEmpresa).ToList

        For Each item In consultaEntidad
            entidadBE = New entidad
            entidadBE.idEntidad = item.idEntidad
            entidadBE.tipoEntidad = item.tipoEntidad
            entidadBE.nrodoc = item.nrodoc
            entidadBE.nombreCompleto = item.nombreCompleto
            entidadBE.estado = item.estado
            listaEntidad.Add(entidadBE)
        Next

        For Each itemHP In consultaHospedados
            entidadBE = New entidad
            entidadBE.idEntidad = itemHP.idPersonaBeneficio
            entidadBE.tipoEntidad = "HP"
            entidadBE.nrodoc = itemHP.nroDocumento
            entidadBE.nombreCompleto = itemHP.nombrePersona
            entidadBE.estado = itemHP.estado

            listaEntidad.Add(entidadBE)
        Next

        Return listaEntidad

    End Function

    Public Function GetUbicarClienteOrHuesped(entBE As entidad) As entidad
        Dim entidadBE As New entidad
        Dim listaEntidad As New List(Of entidad)

        'Dim consulta = HeliosData.entidad.Join(HeliosData.documentoventaAbarrotes, Function(post) post.idEntidad, Function(prod) prod.idCliente, Function(post, prod) _
        '                                       New With
        '                                       {
        '                                       .post = post,
        '                                       .prod = prod
        '                                       }) _
        '                                        .Where(Function(O) O.post.idEntidad = entBE.idEntidad And
        '                                        O.post.estado = entBE.estado).FirstOrDefault

        Dim consulta = (From ent In HeliosData.entidad
                        Where
                            (ent.nrodoc) = entBE.nrodoc And
                            ent.estado = entBE.estado
                        Select
                            conteoAbarrotes = (CType((Aggregate t1 In
                                               (From det In HeliosData.documentoventaAbarrotesDet
                                                Where
                                                    det.documentoventaAbarrotes.idCliente = ent.idEntidad And
                                                    det.estadoDistribucion = "A"
                                                Select New With {
                                                    det.documentoventaAbarrotes.idDocumento
                                                    }) Into Count()), Int64?)),
                            conteoAbarrotesHistoricos = (CType((Aggregate t1 In
                                               (From doc In HeliosData.documentoventaAbarrotes
                                                Where
                                                    doc.idCliente = ent.idEntidad
                                                Select New With {
                                                    doc.idDocumento
                                                    }) Into Count()), Int64?)),
                            ent.idEntidad,
                            ent.nombreCompleto,
                            ent.nrodoc,
                            ent.direccion,
                            ent.tipoEntidad).FirstOrDefault


        If (Not IsNothing(consulta)) Then
            entidadBE = New entidad
            entidadBE.idEntidad = consulta.idEntidad
            entidadBE.tipoEntidad = consulta.tipoEntidad
            entidadBE.nrodoc = consulta.nrodoc
            entidadBE.nombreCompleto = consulta.nombreCompleto
            entidadBE.clienteActivo = consulta.conteoAbarrotes
            entidadBE.totalVEntas = consulta.conteoAbarrotesHistoricos

            'listaEntidad.Add(entidadBE)
        End If

        Return entidadBE

    End Function

#End Region

End Class
