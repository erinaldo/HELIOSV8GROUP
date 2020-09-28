Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class documentoCompraRPT
    Inherits BaseBL


    Public Function LidtadoNotasXempresa(fecINic As DateTime, fecHasta As DateTime, idProv As Integer) As List(Of documentocompra)
        Dim Lista As New List(Of documentocompra)
        Dim objRecurso As New documentocompra

        If idProv = -1 Then
            Dim consulta = (From i In HeliosData.documentocompra _
                      Join d2 In HeliosData.documentocompra _
                      On i.idPadre Equals d2.idDocumento _
                      Join e In HeliosData.entidad _
                      On d2.idProveedor Equals e.idEntidad _
                      Where i.idEmpresa = Gempresas.IdEmpresaRuc _
                      And i.tipoDoc = "07" And i.fechaDoc >= fecINic And i.fechaDoc <= fecHasta).ToList

            For Each i In consulta
                objRecurso = New documentocompra
                objRecurso.NumDocOperCaja = i.i.serie & "-" & i.i.numeroDoc
                objRecurso.fechaDoc = i.i.fechaDoc
                Select Case i.i.destino
                    Case "9913"
                        objRecurso.destino = "NC-DISMINUIR CANTIDAD"
                    Case "9914"
                        objRecurso.destino = "NC-DISMINUIR IMPORTE"
                    Case "9915"
                        objRecurso.destino = "NC-DISMINUIR CANTIDAD E IMPORTE"
                    Case "9916"
                        objRecurso.destino = "NC-DEVOLUCION DE EXISTENCIAS"
                    Case "9917"
                        objRecurso.destino = "BONIFICACIONES RECIBIDAS (OPC. Beneficios)"
                    Case "9918"
                        objRecurso.destino = "BONIFICACIONES RECIBIDAS (OPC. Reduc. costos)"

                    Case "9925"
                        objRecurso.destino = "PRONTO PAGO - VOLUMEN DE COMPRA"
                End Select
                objRecurso.nombreProveedor = i.e.nombreCompleto
                objRecurso.tipoDoc = i.d2.tipoDoc
                objRecurso.numeroDocumento = i.d2.serie & "-" & i.d2.numeroDoc
                objRecurso.importeTotal = i.i.importeTotal
                objRecurso.importeUS = i.i.importeUS
                Lista.Add(objRecurso)
            Next


        Else
            Dim consulta = (From i In HeliosData.documentocompra _
                      Join d2 In HeliosData.documentocompra _
                      On i.idPadre Equals d2.idDocumento _
                      Join e In HeliosData.entidad _
                      On d2.idProveedor Equals e.idEntidad _
                      Where i.idEmpresa = Gempresas.IdEmpresaRuc _
                      And i.tipoDoc = "07" And i.fechaDoc >= fecINic And i.fechaDoc <= fecHasta _
                      And i.idProveedor = idProv).ToList


            For Each i In consulta
                objRecurso = New documentocompra
                objRecurso.NumDocOperCaja = i.i.serie & "-" & i.i.numeroDoc
                objRecurso.fechaDoc = i.i.fechaDoc
                Select Case i.i.destino
                    Case "9913"
                        objRecurso.destino = "NC-DISMINUIR CANTIDAD"
                    Case "9914"
                        objRecurso.destino = "NC-DISMINUIR IMPORTE"
                    Case "9915"
                        objRecurso.destino = "NC-DISMINUIR CANTIDAD E IMPORTE"
                    Case "9916"
                        objRecurso.destino = "NC-DEVOLUCION DE EXISTENCIAS"
                    Case "9917"
                        objRecurso.destino = "BONIFICACIONES RECIBIDAS (OPC. Beneficios)"
                    Case "9918"
                        objRecurso.destino = "BONIFICACIONES RECIBIDAS (OPC. Reduc. costos)"
                    Case "9925"
                        objRecurso.destino = "PRONTO PAGO - VOLUMEN DE COMPRA"
                End Select
                objRecurso.nombreProveedor = i.e.nombreCompleto
                objRecurso.tipoDoc = i.d2.tipoDoc
                objRecurso.numeroDocumento = i.d2.serie & "-" & i.d2.numeroDoc
                objRecurso.importeTotal = i.i.importeTotal
                objRecurso.importeUS = i.i.importeUS
                Lista.Add(objRecurso)
            Next
        End If

        Return Lista
    End Function

    Public Function GetListarMvimientosAlmacenPorDiaReporte(intIdEstablecimiento As Integer, strTipoCompra As String) As List(Of documentocompra)
        Dim Lista As New List(Of documentocompra)
        Dim objRecurso As New documentocompra
        Dim consulta = (From doc In HeliosData.documento _
                       Join compra In HeliosData.documentocompra _
                       On doc.idDocumento Equals compra.idDocumento _
                       Join entidad In HeliosData.entidad _
                       On compra.idProveedor Equals entidad.idEntidad _
                       Where compra.fechaDoc.Value.Day = DateTime.Now.Day And _
                       compra.fechaDoc.Value.Month = DateTime.Now.Month And _
                       compra.fechaDoc.Value.Year = DateTime.Now.Year And _
                       compra.tipoCompra = strTipoCompra _
                       And compra.idCentroCosto = intIdEstablecimiento _
                       Order By compra.fechaDoc Ascending).ToList

        For Each obj In consulta
            objRecurso = New documentocompra

            objRecurso.idDocumento = obj.compra.idDocumento
            objRecurso.tipoOperacion = obj.doc.tipoOperacion
            objRecurso.fechaDoc = obj.compra.fechaDoc
            objRecurso.tipoDoc = obj.compra.tipoDoc
            objRecurso.serie = obj.compra.serie
            objRecurso.numeroDoc = obj.compra.numeroDoc
            objRecurso.tipoDocEntidad = obj.entidad.tipoDoc
            objRecurso.NroDocEntidad = obj.entidad.nrodoc
            objRecurso.NombreEntidad = obj.entidad.nombreCompleto
            objRecurso.TipoPersona = obj.entidad.tipoPersona
            objRecurso.importeTotal = obj.compra.importeTotal
            objRecurso.tcDolLoc = obj.compra.tcDolLoc
            objRecurso.importeUS = obj.compra.importeUS
            objRecurso.monedaDoc = obj.compra.monedaDoc
            objRecurso.tipoCompra = obj.compra.tipoCompra
            objRecurso.destino = obj.compra.destino
            Lista.Add(objRecurso)
        Next

        Return Lista
    End Function

    Public Function OntenerListadoComprasPorPeriodo(strEmpresa As String, intIdEstablecimiento As Integer,
                                               strPeriodo As String) As List(Of documentocompra)

        Dim Lista As New List(Of documentocompra)
        Dim objRecurso As New documentocompra
        Dim consulta = (From doc In HeliosData.documento _
                       Join compra In HeliosData.documentocompra _
                       On doc.idDocumento Equals compra.idDocumento _
                       Join entidad In HeliosData.entidad _
                       On compra.idProveedor Equals entidad.idEntidad _
                       Where compra.idEmpresa = strEmpresa And compra.idCentroCosto = intIdEstablecimiento _
                       And compra.fechaContable = strPeriodo _
                       Order By compra.fechaDoc Ascending).ToList

        For Each obj In consulta
            objRecurso = New documentocompra

            objRecurso.idDocumento = obj.compra.idDocumento
            objRecurso.tipoOperacion = obj.doc.tipoOperacion
            objRecurso.fechaDoc = obj.compra.fechaDoc
            objRecurso.tipoDoc = obj.compra.tipoDoc
            objRecurso.serie = obj.compra.serie
            objRecurso.numeroDoc = obj.compra.numeroDoc
            objRecurso.tipoDocEntidad = obj.entidad.tipoDoc
            objRecurso.NroDocEntidad = obj.entidad.nrodoc
            objRecurso.NombreEntidad = obj.entidad.nombreCompleto
            objRecurso.TipoPersona = obj.entidad.tipoPersona
            objRecurso.importeTotal = obj.compra.importeTotal
            objRecurso.tcDolLoc = obj.compra.tcDolLoc
            objRecurso.importeUS = obj.compra.importeUS
            objRecurso.monedaDoc = obj.compra.monedaDoc
            objRecurso.bi01 = obj.compra.bi01
            objRecurso.bi02 = obj.compra.bi02
            objRecurso.bi03 = obj.compra.bi03
            objRecurso.bi04 = obj.compra.bi04
            objRecurso.igv01 = obj.compra.igv01
            objRecurso.igv02 = obj.compra.igv02
            objRecurso.igv03 = obj.compra.igv03
            Lista.Add(objRecurso)
        Next

        Return Lista

    End Function



    Public Function OntenerListadoComprasPorEmpresa(strEmpresa As String,
                                              strPeriodo As String) As List(Of documentocompra)

        Dim Lista As New List(Of documentocompra)
        Dim objRecurso As New documentocompra
        Dim consulta = (From doc In HeliosData.documento _
                       Join compra In HeliosData.documentocompra _
                       On doc.idDocumento Equals compra.idDocumento _
                       Join centro In HeliosData.centrocosto _
                       On compra.idCentroCosto Equals centro.idCentroCosto _
                       Join entidad In HeliosData.entidad _
                       On compra.idProveedor Equals entidad.idEntidad _
                       Where compra.idEmpresa = strEmpresa _
                       And compra.fechaContable = strPeriodo _
                       Order By compra.fechaDoc Ascending).ToList

        For Each obj In consulta
            objRecurso = New documentocompra

            objRecurso.nombreEstablecimiento = obj.centro.nombre   'martin
            objRecurso.idDocumento = obj.compra.idDocumento
            objRecurso.tipoOperacion = obj.doc.tipoOperacion
            objRecurso.fechaDoc = obj.compra.fechaDoc
            objRecurso.tipoDoc = obj.compra.tipoDoc
            objRecurso.serie = obj.compra.serie
            objRecurso.numeroDoc = obj.compra.numeroDoc
            objRecurso.tipoDocEntidad = obj.entidad.tipoDoc
            objRecurso.NroDocEntidad = obj.entidad.nrodoc
            objRecurso.NombreEntidad = obj.entidad.nombreCompleto
            objRecurso.TipoPersona = obj.entidad.tipoPersona
            objRecurso.importeTotal = obj.compra.importeTotal
            objRecurso.tcDolLoc = obj.compra.tcDolLoc
            objRecurso.importeUS = obj.compra.importeUS
            objRecurso.monedaDoc = obj.compra.monedaDoc
            objRecurso.bi01 = obj.compra.bi01
            objRecurso.bi02 = obj.compra.bi02
            objRecurso.bi03 = obj.compra.bi03
            objRecurso.bi04 = obj.compra.bi04
            objRecurso.igv01 = obj.compra.igv01
            objRecurso.igv02 = obj.compra.igv02
            objRecurso.igv03 = obj.compra.igv03
            Lista.Add(objRecurso)
        Next

        Return Lista

    End Function

    'martin listado de compras con bonificacion

    Public Function OntenerListadoComprasConBonificacion(strEmpresa As String, intIdEstablecimiento As Integer,
                                               strPeriodo As String) As List(Of documentocompradetalle)

        Dim Lista As New List(Of documentocompradetalle)
        Dim objRecurso As New documentocompradetalle
        Dim consulta = (From doc In HeliosData.documento _
                       Join compra In HeliosData.documentocompra _
                       On doc.idDocumento Equals compra.idDocumento _
                       Join entidad In HeliosData.entidad _
                       On compra.idProveedor Equals entidad.idEntidad _
                       Join det In HeliosData.documentocompradetalle _
                       On compra.idDocumento Equals det.idDocumento _
                       Where compra.idEmpresa = strEmpresa And compra.idCentroCosto = intIdEstablecimiento _
                        And compra.fechaContable = strPeriodo _
                        And det.bonificacion = "S" _
                       Order By compra.fechaDoc Ascending).ToList

        For Each obj In consulta
            objRecurso = New documentocompradetalle

            objRecurso.TipoDoc = obj.compra.tipoDoc
            objRecurso.FechaDoc = obj.compra.fechaDoc
            objRecurso.Serie = obj.compra.serie
            objRecurso.NumDoc = obj.compra.numeroDoc
            objRecurso.NombreProveedor = obj.entidad.nombre
            If obj.compra.monedaDoc = "1" Then
                objRecurso.Moneda = "NACIONAL"
            Else
                objRecurso.Moneda = "EXTRANJERA"
            End If

            objRecurso.idDocumento = obj.det.idDocumento
            objRecurso.secuencia = obj.det.secuencia
            objRecurso.idItem = obj.det.idItem
            objRecurso.descripcionItem = obj.det.descripcionItem
            objRecurso.tipoExistencia = obj.det.tipoExistencia
            objRecurso.destino = obj.det.destino
            objRecurso.unidad1 = obj.det.unidad1
            objRecurso.monto1 = obj.det.monto1
            objRecurso.unidad2 = obj.det.unidad2
            objRecurso.monto2 = obj.det.monto2
            objRecurso.precioUnitario = obj.det.precioUnitario
            objRecurso.precioUnitarioUS = obj.det.precioUnitarioUS
            objRecurso.importe = obj.det.importe
            objRecurso.importeUS = obj.det.importeUS
            objRecurso.montokardex = obj.det.montokardex
            objRecurso.montoIsc = obj.det.montoIsc
            objRecurso.montoIgv = obj.det.montoIgv
            objRecurso.otrosTributos = obj.det.otrosTributos
            objRecurso.montokardexUS = obj.det.montokardexUS
            objRecurso.montoIscUS = obj.det.montoIscUS
            objRecurso.montoIgvUS = obj.det.montoIgvUS
            objRecurso.otrosTributosUS = obj.det.otrosTributosUS
            objRecurso.preEvento = obj.det.preEvento
            objRecurso.cantidadCredito = obj.det.cantidadCredito
            objRecurso.cantidadDebito = obj.det.cantidadDebito
            objRecurso.notaCreditoMN = obj.det.notaCreditoMN
            objRecurso.notaCreditoME = obj.det.notaCreditoME
            objRecurso.notaDebitoMN = obj.det.notaDebitoMN
            objRecurso.notaDebitoME = obj.det.notaDebitoME
            objRecurso.bonificacion = obj.det.bonificacion
            objRecurso.almacenRef = obj.det.almacenRef
            objRecurso.almacenDestino = obj.det.almacenDestino
            objRecurso.idPadreDTCompra = obj.det.idPadreDTCompra
            objRecurso.usuarioModificacion = obj.det.usuarioModificacion
            objRecurso.fechaModificacion = obj.det.fechaModificacion

            Lista.Add(objRecurso)
        Next

        Return Lista

    End Function

    'martin compras por proveedor , periodo y empresa


    Public Function OntenerListadoComprasPorProveedor(strEmpresa As String, intIdProveedor As Integer,
                                               strPeriodo As String) As List(Of documentocompra)

        Dim Lista As New List(Of documentocompra)
        Dim objRecurso As New documentocompra
        Dim consulta = (From doc In HeliosData.documento _
                       Join compra In HeliosData.documentocompra _
                       On doc.idDocumento Equals compra.idDocumento _
                       Join centro In HeliosData.centrocosto _
                       On compra.idCentroCosto Equals centro.idCentroCosto _
                       Join entidad In HeliosData.entidad _
                       On compra.idProveedor Equals entidad.idEntidad _
                       Where compra.idEmpresa = strEmpresa And compra.idProveedor = intIdProveedor _
                       And compra.fechaContable = strPeriodo _
                       Order By compra.fechaDoc Ascending).ToList

        For Each obj In consulta
            objRecurso = New documentocompra


            objRecurso.nombreEstablecimiento = obj.centro.nombre
            objRecurso.idDocumento = obj.compra.idDocumento
            objRecurso.tipoOperacion = obj.doc.tipoOperacion
            objRecurso.fechaDoc = obj.compra.fechaDoc
            objRecurso.tipoDoc = obj.compra.tipoDoc
            objRecurso.serie = obj.compra.serie
            objRecurso.numeroDoc = obj.compra.numeroDoc
            objRecurso.tipoDocEntidad = obj.entidad.tipoDoc
            objRecurso.NroDocEntidad = obj.entidad.nrodoc
            objRecurso.NombreEntidad = obj.entidad.nombreCompleto
            objRecurso.TipoPersona = obj.entidad.tipoPersona
            objRecurso.importeTotal = obj.compra.importeTotal
            objRecurso.tcDolLoc = obj.compra.tcDolLoc
            objRecurso.importeUS = obj.compra.importeUS
            objRecurso.monedaDoc = obj.compra.monedaDoc
            objRecurso.bi01 = obj.compra.bi01
            objRecurso.bi02 = obj.compra.bi02
            objRecurso.bi03 = obj.compra.bi03
            objRecurso.bi04 = obj.compra.bi04
            objRecurso.igv01 = obj.compra.igv01
            objRecurso.igv02 = obj.compra.igv02
            objRecurso.igv03 = obj.compra.igv03
            Lista.Add(objRecurso)
        Next

        Return Lista

    End Function





    'martin  compras por proveedor , periodo,proveedor,establecimiento


    Public Function OntenerListadoComprasPorProveedorEstablec(strEmpresa As String, intIdEstablecimiento As Integer, intIdProveedor As Integer,
                                               strPeriodo As String) As List(Of documentocompra)

        Dim Lista As New List(Of documentocompra)
        Dim objRecurso As New documentocompra
        Dim consulta = (From doc In HeliosData.documento _
                       Join compra In HeliosData.documentocompra _
                       On doc.idDocumento Equals compra.idDocumento _
                       Join entidad In HeliosData.entidad _
                       On compra.idProveedor Equals entidad.idEntidad _
                       Where compra.idCentroCosto = intIdEstablecimiento And compra.idProveedor = intIdProveedor _
                       And compra.fechaContable = strPeriodo _
                       And compra.idEmpresa = strEmpresa
                       Order By compra.fechaDoc Ascending).ToList

        For Each obj In consulta
            objRecurso = New documentocompra

            objRecurso.idDocumento = obj.compra.idDocumento
            objRecurso.tipoOperacion = obj.doc.tipoOperacion
            objRecurso.fechaDoc = obj.compra.fechaDoc
            objRecurso.tipoDoc = obj.compra.tipoDoc
            objRecurso.serie = obj.compra.serie
            objRecurso.numeroDoc = obj.compra.numeroDoc
            objRecurso.tipoDocEntidad = obj.entidad.tipoDoc
            objRecurso.NroDocEntidad = obj.entidad.nrodoc
            objRecurso.NombreEntidad = obj.entidad.nombreCompleto
            objRecurso.TipoPersona = obj.entidad.tipoPersona
            objRecurso.importeTotal = obj.compra.importeTotal
            objRecurso.tcDolLoc = obj.compra.tcDolLoc
            objRecurso.importeUS = obj.compra.importeUS
            objRecurso.monedaDoc = obj.compra.monedaDoc
            objRecurso.bi01 = obj.compra.bi01
            objRecurso.bi02 = obj.compra.bi02
            objRecurso.bi03 = obj.compra.bi03
            objRecurso.bi04 = obj.compra.bi04
            objRecurso.igv01 = obj.compra.igv01
            objRecurso.igv02 = obj.compra.igv02
            objRecurso.igv03 = obj.compra.igv03
            Lista.Add(objRecurso)
        Next

        Return Lista

    End Function

    ':::::::::::::::::::::::::::::::::::::::::APORTACIONES:::::::::::::::::::::::::::::::::::::::::

    'REPORTE DE APORTACIONES POR "APE"

    Public Function OntenerListadoComprasPorAportacionesPorDia(strEmpresa As String, intIdEstablecimiento As Integer) As List(Of documentocompra)
        Dim Lista As New List(Of documentocompra)
        Dim objRecurso As New documentocompra


        Dim consulta = (From doc In HeliosData.documento _
                       Join compra In HeliosData.documentocompra _
                       On doc.idDocumento Equals compra.idDocumento _
                       Join entidad In HeliosData.entidad _
                       On compra.idProveedor Equals entidad.idEntidad _
                       Where compra.idCentroCosto = intIdEstablecimiento And _
                       compra.fechaDoc.Value.Day = CDate(DateTime.Now).Day _
                       And compra.fechaDoc.Value.Month = CDate(DateTime.Now).Month _
                       And compra.fechaDoc.Value.Year = CDate(DateTime.Now).Year _
                       And compra.tipoCompra = TIPO_COMPRA.APORTE_EXISTENCIAS _
                       Order By compra.fechaDoc Ascending).ToList

        For Each obj In consulta
            objRecurso = New documentocompra

            objRecurso.idDocumento = obj.compra.idDocumento
            objRecurso.tipoOperacion = obj.doc.tipoOperacion
            objRecurso.fechaDoc = obj.compra.fechaDoc
            objRecurso.tipoDoc = obj.compra.tipoDoc
            objRecurso.serie = obj.compra.serie
            objRecurso.numeroDoc = obj.compra.numeroDoc
            objRecurso.tipoDocEntidad = obj.entidad.tipoDoc
            objRecurso.NroDocEntidad = obj.entidad.nrodoc
            objRecurso.NombreEntidad = obj.entidad.nombreCompleto
            objRecurso.TipoPersona = obj.entidad.tipoPersona
            objRecurso.importeTotal = obj.compra.importeTotal
            objRecurso.tcDolLoc = obj.compra.tcDolLoc
            objRecurso.importeUS = obj.compra.importeUS
            objRecurso.monedaDoc = obj.compra.monedaDoc
            objRecurso.bi01 = obj.compra.bi01
            objRecurso.bi02 = obj.compra.bi02
            objRecurso.bi03 = obj.compra.bi03
            objRecurso.bi04 = obj.compra.bi04
            objRecurso.igv01 = obj.compra.igv01
            objRecurso.igv02 = obj.compra.igv02
            objRecurso.igv03 = obj.compra.igv03

            Lista.Add(objRecurso)
        Next

        Return Lista
    End Function

    Public Function OntenerListadoComprasPorAportaciones(strEmpresa As String, intIdEstablecimiento As Integer,
                                               strPeriodo As String) As List(Of documentocompra)

        Dim Lista As New List(Of documentocompra)
        Dim objRecurso As New documentocompra
        Dim consulta = (From doc In HeliosData.documento _
                       Join compra In HeliosData.documentocompra _
                       On doc.idDocumento Equals compra.idDocumento _
                       Join entidad In HeliosData.entidad _
                       On compra.idProveedor Equals entidad.idEntidad _
                       Where compra.idEmpresa = strEmpresa And compra.idCentroCosto = intIdEstablecimiento _
                       And compra.fechaContable = strPeriodo _
                       And compra.tipoCompra = "APE" _
                       Order By compra.fechaDoc Ascending).ToList

        For Each obj In consulta
            objRecurso = New documentocompra

            objRecurso.idDocumento = obj.compra.idDocumento
            objRecurso.tipoOperacion = obj.doc.tipoOperacion
            objRecurso.fechaDoc = obj.compra.fechaDoc
            objRecurso.tipoDoc = obj.compra.tipoDoc
            objRecurso.serie = obj.compra.serie
            objRecurso.numeroDoc = obj.compra.numeroDoc
            objRecurso.tipoDocEntidad = obj.entidad.tipoDoc
            objRecurso.NroDocEntidad = obj.entidad.nrodoc
            objRecurso.NombreEntidad = obj.entidad.nombreCompleto
            objRecurso.TipoPersona = obj.entidad.tipoPersona
            objRecurso.importeTotal = obj.compra.importeTotal
            objRecurso.tcDolLoc = obj.compra.tcDolLoc
            objRecurso.importeUS = obj.compra.importeUS
            objRecurso.monedaDoc = obj.compra.monedaDoc
            objRecurso.bi01 = obj.compra.bi01
            objRecurso.bi02 = obj.compra.bi02
            objRecurso.bi03 = obj.compra.bi03
            objRecurso.bi04 = obj.compra.bi04
            objRecurso.igv01 = obj.compra.igv01
            objRecurso.igv02 = obj.compra.igv02
            objRecurso.igv03 = obj.compra.igv03
            Lista.Add(objRecurso)
        Next

        Return Lista

    End Function



    'martin reporte aporte por empresa y periodo

    Public Function OntenerListadoComprasPorAporteEmpresa(strEmpresa As String,
                                               strPeriodo As String) As List(Of documentocompra)

        Dim Lista As New List(Of documentocompra)
        Dim objRecurso As New documentocompra
        Dim consulta = (From doc In HeliosData.documento _
                       Join compra In HeliosData.documentocompra _
                       On doc.idDocumento Equals compra.idDocumento _
                       Join centro In HeliosData.centrocosto _
                       On compra.idCentroCosto Equals centro.idCentroCosto _
                       Join entidad In HeliosData.entidad _
                       On compra.idProveedor Equals entidad.idEntidad _
                       Where compra.idEmpresa = strEmpresa _
                       And compra.fechaContable = strPeriodo _
                       And compra.tipoCompra = "APE" _
                       Order By compra.fechaDoc Ascending).ToList

        For Each obj In consulta
            objRecurso = New documentocompra

            objRecurso.nombreEstablecimiento = obj.centro.nombre   'martin
            objRecurso.idDocumento = obj.compra.idDocumento
            objRecurso.tipoOperacion = obj.doc.tipoOperacion
            objRecurso.fechaDoc = obj.compra.fechaDoc
            objRecurso.tipoDoc = obj.compra.tipoDoc
            objRecurso.serie = obj.compra.serie
            objRecurso.numeroDoc = obj.compra.numeroDoc
            objRecurso.tipoDocEntidad = obj.entidad.tipoDoc
            objRecurso.NroDocEntidad = obj.entidad.nrodoc
            objRecurso.NombreEntidad = obj.entidad.nombreCompleto
            objRecurso.TipoPersona = obj.entidad.tipoPersona
            objRecurso.importeTotal = obj.compra.importeTotal
            objRecurso.tcDolLoc = obj.compra.tcDolLoc
            objRecurso.importeUS = obj.compra.importeUS
            objRecurso.monedaDoc = obj.compra.monedaDoc
            objRecurso.bi01 = obj.compra.bi01
            objRecurso.bi02 = obj.compra.bi02
            objRecurso.bi03 = obj.compra.bi03
            objRecurso.bi04 = obj.compra.bi04
            objRecurso.igv01 = obj.compra.igv01
            objRecurso.igv02 = obj.compra.igv02
            objRecurso.igv03 = obj.compra.igv03
            Lista.Add(objRecurso)
        Next

        Return Lista

    End Function





    'martin compras APORTACIONES por proveedor , periodo y empresa


    Public Function OntenerListadoComprasAportacionesPorProveedor(strEmpresa As String, intIdProveedor As Integer,
                                               strPeriodo As String) As List(Of documentocompra)

        Dim Lista As New List(Of documentocompra)
        Dim objRecurso As New documentocompra
        Dim consulta = (From doc In HeliosData.documento _
                       Join compra In HeliosData.documentocompra _
                       On doc.idDocumento Equals compra.idDocumento _
                       Join centro In HeliosData.centrocosto _
                       On compra.idCentroCosto Equals centro.idCentroCosto _
                       Join entidad In HeliosData.entidad _
                       On compra.idProveedor Equals entidad.idEntidad _
                       Where compra.idEmpresa = strEmpresa And compra.idProveedor = intIdProveedor _
                       And compra.fechaContable = strPeriodo _
                        And compra.tipoCompra = "APE" _
                       Order By compra.fechaDoc Ascending).ToList

        For Each obj In consulta
            objRecurso = New documentocompra

            objRecurso.nombreEstablecimiento = obj.centro.nombre
            objRecurso.idDocumento = obj.compra.idDocumento
            objRecurso.tipoOperacion = obj.doc.tipoOperacion
            objRecurso.fechaDoc = obj.compra.fechaDoc
            objRecurso.tipoDoc = obj.compra.tipoDoc
            objRecurso.serie = obj.compra.serie
            objRecurso.numeroDoc = obj.compra.numeroDoc
            objRecurso.tipoDocEntidad = obj.entidad.tipoDoc
            objRecurso.NroDocEntidad = obj.entidad.nrodoc
            objRecurso.NombreEntidad = obj.entidad.nombreCompleto
            objRecurso.TipoPersona = obj.entidad.tipoPersona
            objRecurso.importeTotal = obj.compra.importeTotal
            objRecurso.tcDolLoc = obj.compra.tcDolLoc
            objRecurso.importeUS = obj.compra.importeUS
            objRecurso.monedaDoc = obj.compra.monedaDoc
            objRecurso.bi01 = obj.compra.bi01
            objRecurso.bi02 = obj.compra.bi02
            objRecurso.bi03 = obj.compra.bi03
            objRecurso.bi04 = obj.compra.bi04
            objRecurso.igv01 = obj.compra.igv01
            objRecurso.igv02 = obj.compra.igv02
            objRecurso.igv03 = obj.compra.igv03
            Lista.Add(objRecurso)
        Next

        Return Lista

    End Function


    'reporte compra aportaciones por empresa establecimiento  y proveedor  y periodo

    Public Function OntenerListadoComprasAportacionesPorProveedorEstablec(strEmpresa As String, intIdEstablecimiento As Integer, intIdProveedor As Integer,
                                               strPeriodo As String) As List(Of documentocompra)

        Dim Lista As New List(Of documentocompra)
        Dim objRecurso As New documentocompra
        Dim consulta = (From doc In HeliosData.documento _
                       Join compra In HeliosData.documentocompra _
                       On doc.idDocumento Equals compra.idDocumento _
                       Join entidad In HeliosData.entidad _
                       On compra.idProveedor Equals entidad.idEntidad _
                       Where compra.idCentroCosto = intIdEstablecimiento And compra.idProveedor = intIdProveedor _
                       And compra.fechaContable = strPeriodo _
                       And compra.idEmpresa = strEmpresa _
                       And compra.tipoCompra = "APE" _
                       Order By compra.fechaDoc Ascending).ToList

        For Each obj In consulta
            objRecurso = New documentocompra

            objRecurso.idDocumento = obj.compra.idDocumento
            objRecurso.tipoOperacion = obj.doc.tipoOperacion
            objRecurso.fechaDoc = obj.compra.fechaDoc
            objRecurso.tipoDoc = obj.compra.tipoDoc
            objRecurso.serie = obj.compra.serie
            objRecurso.numeroDoc = obj.compra.numeroDoc
            objRecurso.tipoDocEntidad = obj.entidad.tipoDoc
            objRecurso.NroDocEntidad = obj.entidad.nrodoc
            objRecurso.NombreEntidad = obj.entidad.nombreCompleto
            objRecurso.TipoPersona = obj.entidad.tipoPersona
            objRecurso.importeTotal = obj.compra.importeTotal
            objRecurso.tcDolLoc = obj.compra.tcDolLoc
            objRecurso.importeUS = obj.compra.importeUS
            objRecurso.monedaDoc = obj.compra.monedaDoc
            objRecurso.bi01 = obj.compra.bi01
            objRecurso.bi02 = obj.compra.bi02
            objRecurso.bi03 = obj.compra.bi03
            objRecurso.bi04 = obj.compra.bi04
            objRecurso.igv01 = obj.compra.igv01
            objRecurso.igv02 = obj.compra.igv02
            objRecurso.igv03 = obj.compra.igv03
            Lista.Add(objRecurso)
        Next

        Return Lista

    End Function

    Public Function GetListarComprasPorPeriodoReporte(intIdEstablecimiento As Integer, strPeriodo As String) As List(Of documentocompra)
        Dim Lista As New List(Of documentocompra)
        Dim listaTipoCompra As New List(Of String)
        Dim objRecurso As New documentocompra

        listaTipoCompra.Add(TIPO_COMPRA.COMPRA)
        listaTipoCompra.Add(TIPO_COMPRA.COMPRA_SERVICIO_PUBLICO)
        listaTipoCompra.Add(TIPO_COMPRA.COMPRA_RECIBO_HONORARIOS)
        listaTipoCompra.Add(TIPO_COMPRA.BONIFICACIONES_RECIBIDAS)
        listaTipoCompra.Add(TIPO_COMPRA.NOTA_CREDITO)
        listaTipoCompra.Add(TIPO_COMPRA.NOTA_DEBITO)
        'listaTipoCompra.Add(TIPO_COMPRA.COMPRA_ANTICIPADA)
        listaTipoCompra.Add(TIPO_COMPRA.COMPRA_ANTICIPADA_OTORGADO)
        listaTipoCompra.Add(TIPO_COMPRA.COMPRA_ANTICIPADA_RECIBIDA)

        listaTipoCompra.Add(TIPO_COMPRA.COMPRA_PAGADA)

        'Dim consulta = (From doc In HeliosData.documento _
        '               Join compra In HeliosData.documentocompra _
        '               On doc.idDocumento Equals compra.idDocumento _
        '               Join entidad In HeliosData.entidad _
        '               On compra.idProveedor Equals entidad.idEntidad _
        '               Where compra.fechaContable = strPeriodo _
        '               And compra.idCentroCosto = intIdEstablecimiento _
        '               And listaTipoCompra.Contains(compra.tipoCompra) _
        '               Order By compra.fechaDoc Ascending).ToList


        Dim consulta = (From doc In HeliosData.documento _
               Join compra In HeliosData.documentocompra _
               On doc.idDocumento Equals compra.idDocumento _
               Join entidad In HeliosData.entidad _
               On compra.idProveedor Equals entidad.idEntidad _
               Where compra.fechaContable = strPeriodo _
               And compra.idCentroCosto = intIdEstablecimiento _
               And listaTipoCompra.Contains(compra.tipoCompra) _
               And compra.tieneDetraccion = "N" And compra.situacion = CStr(statusComprobantes.Normal)).ToList


        strPeriodo = strPeriodo.Replace("/", "")
        Dim consulta2 = (From doc In HeliosData.documento _
               Join compra In HeliosData.documentocompra _
               On doc.idDocumento Equals compra.idDocumento _
               Join entidad In HeliosData.entidad _
               On compra.idProveedor Equals entidad.idEntidad _
               Where compra.periodoTributo = strPeriodo _
               And compra.idCentroCosto = intIdEstablecimiento _
               And listaTipoCompra.Contains(compra.tipoCompra) _
               And compra.tieneDetraccion = "S" And compra.situacion = CStr(statusComprobantes.Normal)).ToList

        Dim con3 = consulta.Concat(consulta2).OrderBy(Function(o) o.compra.fechaDoc).ToList

        For Each obj In con3
            objRecurso = New documentocompra
            objRecurso.periodoTributo = obj.compra.periodoTributo
            objRecurso.idDocumento = obj.compra.idDocumento
            objRecurso.tipoCompra = obj.compra.tipoCompra
            objRecurso.tipoOperacion = obj.doc.tipoOperacion
            objRecurso.fechaDoc = obj.compra.fechaDoc
            objRecurso.tipoDoc = obj.compra.tipoDoc
            objRecurso.serie = obj.compra.serie
            objRecurso.numeroDoc = obj.compra.numeroDoc
            objRecurso.tipoDocEntidad = obj.entidad.tipoDoc
            objRecurso.NroDocEntidad = obj.entidad.nrodoc
            objRecurso.NombreEntidad = obj.entidad.nombreCompleto
            objRecurso.TipoPersona = obj.entidad.tipoPersona
            objRecurso.tcDolLoc = obj.compra.tcDolLoc
            Select Case obj.compra.tipoDoc
                Case "07", "87"
                    objRecurso.bi01 = obj.compra.bi01.GetValueOrDefault * -1
                    objRecurso.bi02 = obj.compra.bi02.GetValueOrDefault * -1
                    objRecurso.bi03 = obj.compra.bi03.GetValueOrDefault * -1
                    objRecurso.bi04 = obj.compra.bi04.GetValueOrDefault * -1
                    objRecurso.igv01 = obj.compra.igv01.GetValueOrDefault * -1
                    objRecurso.igv02 = obj.compra.igv02.GetValueOrDefault * -1
                    objRecurso.igv03 = obj.compra.igv03.GetValueOrDefault * -1
                    objRecurso.importeTotal = obj.compra.importeTotal.GetValueOrDefault * -1
                    objRecurso.importeUS = obj.compra.importeUS.GetValueOrDefault * -1

                Case "08", "88"
                    objRecurso.bi01 = obj.compra.bi01.GetValueOrDefault
                    objRecurso.bi02 = obj.compra.bi02.GetValueOrDefault
                    objRecurso.bi03 = obj.compra.bi03.GetValueOrDefault
                    objRecurso.bi04 = obj.compra.bi04.GetValueOrDefault
                    objRecurso.igv01 = obj.compra.igv01.GetValueOrDefault
                    objRecurso.igv02 = obj.compra.igv02.GetValueOrDefault
                    objRecurso.igv03 = obj.compra.igv03.GetValueOrDefault
                    objRecurso.importeTotal = obj.compra.importeTotal.GetValueOrDefault
                    objRecurso.importeUS = obj.compra.importeUS.GetValueOrDefault
                Case Else
                    objRecurso.bi01 = obj.compra.bi01.GetValueOrDefault
                    objRecurso.bi02 = obj.compra.bi02.GetValueOrDefault
                    objRecurso.bi03 = obj.compra.bi03.GetValueOrDefault
                    objRecurso.bi04 = obj.compra.bi04.GetValueOrDefault
                    objRecurso.igv01 = obj.compra.igv01.GetValueOrDefault
                    objRecurso.igv02 = obj.compra.igv02.GetValueOrDefault
                    objRecurso.igv03 = obj.compra.igv03.GetValueOrDefault
                    objRecurso.importeTotal = obj.compra.importeTotal.GetValueOrDefault
                    objRecurso.importeUS = obj.compra.importeUS.GetValueOrDefault
            End Select
            objRecurso.monedaDoc = obj.compra.monedaDoc
            objRecurso.estadoPago = obj.compra.estadoPago
            objRecurso.idPadre = obj.compra.idPadre
            Lista.Add(objRecurso)
        Next

        Return Lista
    End Function


    Public Function GetListarComprasPorANioReporte(intIdEstablecimiento As Integer, ANio As Integer) As List(Of documentocompra)
        Dim Lista As New List(Of documentocompra)
        Dim listaTipoCompra As New List(Of String)
        Dim objRecurso As New documentocompra

        listaTipoCompra.Add(TIPO_COMPRA.COMPRA)
        listaTipoCompra.Add(TIPO_COMPRA.COMPRA_SERVICIO_PUBLICO)
        'listaTipoCompra.Add(TIPO_COMPRA.COMPRA_ANTICIPADA)
        listaTipoCompra.Add(TIPO_COMPRA.COMPRA_ANTICIPADA_OTORGADO)
        listaTipoCompra.Add(TIPO_COMPRA.COMPRA_ANTICIPADA_RECIBIDA)
        listaTipoCompra.Add(TIPO_COMPRA.COMPRA_RECIBO_HONORARIOS)
        Dim consulta = (From compra In HeliosData.documentocompra _
                        Where compra.fechaDoc.Value.Year = ANio _
                       And listaTipoCompra.Contains(compra.tipoCompra)
                       Group compra By _
                       compra.fechaContable Into g = Group _
                        Select New With {g, .SumaMN = g.Sum(Function(c) c.importeTotal),
                                            .SumaME = g.Sum(Function(c) c.importeUS),
                                         .fecha = fechaContable}
                                 ).ToList

        For Each obj In consulta
            objRecurso = New documentocompra
            objRecurso.fechaContable = obj.fecha
            objRecurso.importeTotal = obj.SumaMN
            objRecurso.importeUS = obj.SumaME
            Lista.Add(objRecurso)
        Next

        Return Lista
    End Function

    Public Function GetListarComprasPorANioReporte2(intIdEstablecimiento As Integer, ANio As Integer) As List(Of documentocompra)
        Dim Lista As New List(Of documentocompra)
        Dim listaTipoCompra As New List(Of String)
        Dim objRecurso As New documentocompra

        listaTipoCompra.Add(TIPO_COMPRA.COMPRA_AL_CREDITO)
        listaTipoCompra.Add(TIPO_COMPRA.COMPRA_AL_CREDITO_CON_RECEPCION)
        listaTipoCompra.Add(TIPO_COMPRA.COMPRA_DIRECTA_CON_RECEPCION)
        listaTipoCompra.Add(TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION)
        Dim consulta = (From compra In HeliosData.documentocompra _
                        Where compra.fechaDoc.Value.Year = ANio _
                       And compra.idCentroCosto = intIdEstablecimiento _
                       And listaTipoCompra.Contains(compra.tipoCompra)
                       Group compra By _
                       compra.fechaContable Into g = Group _
                        Select New With {g, .SumaMN = g.Sum(Function(c) c.importeTotal),
                                            .SumaME = g.Sum(Function(c) c.importeUS),
                                         .fecha = fechaContable}
                                 ).ToList

        For Each obj In consulta
            objRecurso = New documentocompra
            objRecurso.fechaContable = obj.fecha
            objRecurso.importeTotal = obj.SumaMN
            objRecurso.importeUS = obj.SumaME
            Lista.Add(objRecurso)
        Next

        Return Lista
    End Function


    Public Function GetListarComprasPorDiaReporte(intIdEstablecimiento As Integer, fechaDia As Date) As List(Of documentocompra)
        Dim Lista As New List(Of documentocompra)
        Dim listaTipoCompra As New List(Of String)
        Dim objRecurso As New documentocompra

        listaTipoCompra.Add(TIPO_COMPRA.COMPRA)
        listaTipoCompra.Add(TIPO_COMPRA.COMPRA_SERVICIO_PUBLICO)
        'listaTipoCompra.Add(TIPO_COMPRA.COMPRA_ANTICIPADA)
        listaTipoCompra.Add(TIPO_COMPRA.COMPRA_ANTICIPADA_OTORGADO)
        listaTipoCompra.Add(TIPO_COMPRA.COMPRA_ANTICIPADA_RECIBIDA)
        listaTipoCompra.Add(TIPO_COMPRA.COMPRA_RECIBO_HONORARIOS)
        Dim consulta = (From doc In HeliosData.documento _
                       Join compra In HeliosData.documentocompra _
                       On doc.idDocumento Equals compra.idDocumento _
                       Join entidad In HeliosData.entidad _
                       On compra.idProveedor Equals entidad.idEntidad _
                       Where compra.idCentroCosto = intIdEstablecimiento And _
                       compra.fechaDoc.Value.Day = CDate(fechaDia).Day _
                       And compra.fechaDoc.Value.Month = CDate(fechaDia).Month _
                       And compra.fechaDoc.Value.Year = CDate(fechaDia).Year _
                       And listaTipoCompra.Contains(compra.tipoCompra) _
                       Order By compra.fechaDoc Ascending).ToList

        For Each obj In consulta
            objRecurso = New documentocompra

            objRecurso.idDocumento = obj.compra.idDocumento
            objRecurso.tipoCompra = obj.compra.tipoCompra
            objRecurso.tipoOperacion = obj.doc.tipoOperacion
            objRecurso.fechaDoc = obj.compra.fechaDoc
            objRecurso.tipoDoc = obj.compra.tipoDoc
            objRecurso.serie = obj.compra.serie
            objRecurso.numeroDoc = obj.compra.numeroDoc
            objRecurso.tipoDocEntidad = obj.entidad.tipoDoc
            objRecurso.NroDocEntidad = obj.entidad.nrodoc
            objRecurso.NombreEntidad = obj.entidad.nombreCompleto
            objRecurso.TipoPersona = obj.entidad.tipoPersona
            objRecurso.importeTotal = obj.compra.importeTotal
            objRecurso.tcDolLoc = obj.compra.tcDolLoc
            objRecurso.importeUS = obj.compra.importeUS
            objRecurso.monedaDoc = obj.compra.monedaDoc
            objRecurso.estadoPago = obj.compra.estadoPago
            objRecurso.bi01 = obj.compra.bi01
            objRecurso.bi02 = obj.compra.bi02
            objRecurso.bi03 = obj.compra.bi03
            objRecurso.bi04 = obj.compra.bi04
            objRecurso.igv01 = obj.compra.igv01
            objRecurso.igv02 = obj.compra.igv02
            objRecurso.igv03 = obj.compra.igv03
            Lista.Add(objRecurso)
        Next

        Return Lista
    End Function

End Class
