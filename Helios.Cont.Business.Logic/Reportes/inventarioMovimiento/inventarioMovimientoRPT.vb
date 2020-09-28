Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class inventarioMovimientoRPT
    Inherits BaseBL

    Public Function ObtenerProdPorAlmacenesPeriodoRPT(ByVal idAlmacen As String, ByVal strItem As String, ByVal periodo As Integer, ByVal mes As String) As List(Of InventarioMovimiento)
        Dim objInventarioMovimientoBO As InventarioMovimiento
        Dim tablaSA As New tabladetalleBL
        Dim totalsaldo As Decimal = 0
        Dim cantidadSaldo As Decimal = 0
        Dim PrecioPromedio As Decimal = 0
        Dim x = 0
        Dim CantidadTRE As Integer = 0
        Dim precUniteTRE As Decimal = 0.0
        Dim montoTRE As Decimal = 0.0
        Dim CantidadTRS As Integer = 0
        Dim precUniteTRS As Decimal = 0.0
        Dim montoTRS As Decimal = 0.0


        Dim listaInventario As New List(Of InventarioMovimiento)
        Try
            Dim inventarios = (From p In HeliosData.InventarioMovimiento _
                                   Join q In HeliosData.detalleitems On p.idItem Equals q.codigodetalle _
                                   Join doc In HeliosData.documento On p.idDocumento Equals doc.idDocumento _
                                   Where p.idAlmacen = idAlmacen _
                                   And p.idItem = strItem _
                                   And p.fecha.Value.Month = CInt(mes) _
                                   And p.fecha.Value.Year = periodo _
                                   Order By p.fecha _
                                   Select New With _
                                           {.idInventario = p.idInventario, _
                                            .Fecha = p.fecha, _
                                            .idEmpresa = p.idEmpresa, _
                                            .idAlmacen = p.idAlmacen, _
                                            .idItem = p.idItem, _
                                            .nombreItem = q.descripcionItem, _
                                            .cantidad = p.cantidad, _
                                            .unidad = p.unidad, _
                                            .UnitproceE = p.precUnite, _
                                            .monto = p.monto, _
                                            .disponible = p.disponible, _
                                            .estado = p.status, _
                                            .TipoRegistro = p.tipoRegistro, _
                                            .Glosa = p.descripcion, _
                                            .NroDoc = doc.nroDoc, _
                                            .Cuenta = p.cuentaOrigen, _
                                            .IdDocumento = p.idDocumento, _
                                            .TipoProducto = p.tipoProducto, _
                                            .DestinoGravado = p.destinoGravadoItem, _
                                            .CostoUS = p.montoUSD, _
                                            .tipoOperacion = p.tipoOperacion _
                                           } _
                                ).ToList

            For Each obj In inventarios

                If x = 0 Then
                    totalsaldo += obj.monto
                    cantidadSaldo += obj.cantidad
                    If (totalsaldo = 0) Then
                        PrecioPromedio = 0
                    Else
                        If cantidadSaldo > 0 Then
                            PrecioPromedio = totalsaldo / cantidadSaldo
                        End If
                    End If
                Else
                    totalsaldo = Math.Round(totalsaldo + CDec(obj.monto), 2)
                    cantidadSaldo = cantidadSaldo + CDec(obj.cantidad)
                    If totalsaldo = 0 Or totalsaldo < 0 Or cantidadSaldo = 0 Then
                        PrecioPromedio = 0
                    Else
                        If cantidadSaldo > 0 Then
                            PrecioPromedio = totalsaldo / cantidadSaldo
                        End If
                    End If

                End If

                Select Case obj.TipoRegistro
                    Case "E", "EA", "EC"
                        CantidadTRE = (FormatNumber(obj.cantidad, 2))
                        precUniteTRE = (FormatNumber(obj.UnitproceE, 2))
                        montoTRE = (FormatNumber(obj.monto, 2))
                        CantidadTRS = ("0.00")
                        precUniteTRS = ("0.00")
                        montoTRS = ("0.00")
                    Case "S", "D"
                        CantidadTRE = ("0.00")
                        precUniteTRE = ("0.00")
                        montoTRE = ("0.00")
                        CantidadTRS = (FormatNumber(obj.cantidad, 2))
                        precUniteTRS = (FormatNumber(obj.UnitproceE, 2))
                        montoTRS = (FormatNumber(obj.monto, 2))

                End Select

                objInventarioMovimientoBO = New InventarioMovimiento With _
                                            {.idInventario = obj.idInventario, _
                                             .fecha = obj.Fecha, _
                                             .idEmpresa = IIf(IsDBNull(obj.idEmpresa), Nothing, obj.idEmpresa), _
                                             .idAlmacen = IIf(IsDBNull(obj.idAlmacen), Nothing, obj.idAlmacen), _
                                             .idItem = IIf(IsDBNull(obj.idItem), Nothing, obj.idItem), _
                                             .nombreItem = IIf(IsDBNull(obj.nombreItem), Nothing, obj.nombreItem), _
                                             .cantidad = IIf(IsDBNull(obj.cantidad), Nothing, obj.cantidad), _
                                             .unidad = IIf(IsDBNull(obj.unidad), Nothing, obj.unidad), _
                                             .precUnite = IIf(IsDBNull(obj.UnitproceE), Nothing, obj.UnitproceE), _
                                             .monto = IIf(IsDBNull(obj.monto), Nothing, obj.monto), _
                                             .disponible = IIf(IsDBNull(obj.disponible), Nothing, obj.disponible), _
                                             .status = IIf(IsDBNull(obj.estado), Nothing, obj.estado), _
                                             .tipoRegistro = obj.TipoRegistro.ToString, _
                                             .glosa = obj.Glosa, _
                                             .NumDocCompra = obj.NroDoc, _
                                             .cuentaOrigen = obj.Cuenta, _
                                             .idDocumento = obj.IdDocumento, _
                                             .tipoProducto = obj.TipoProducto, _
                                             .destinoGravadoItem = obj.DestinoGravado, _
                                             .montoUSD = obj.CostoUS, _
                                             .tipoOperacion = obj.tipoOperacion, _
                                             .CantSalida = CantidadTRE, _
                                             .PrUnitS = precUniteTRE, _
                                             .CostoSalida = montoTRE, _
                                             .CantEntrada = CantidadTRS, _
                                             .PrUnitE = precUniteTRS, _
                                             .CostoEntrada = montoTRS, _
                                              .CantSaldo = cantidadSaldo, _
                                              .CostoSaldo = totalsaldo, _
                                              .PrecioPromedio = PrecioPromedio _
                                                             }
                listaInventario.Add(objInventarioMovimientoBO)
            Next

            Return listaInventario
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ObtenerKardexPorAlmacen(ByVal idAlmacen As String, ByVal periodo As Integer, ByVal mes As String) As List(Of InventarioMovimiento)
        Dim objInventarioMovimientoBO As InventarioMovimiento
        Dim listaInventario As New List(Of InventarioMovimiento)
        Try
            Dim inventarios = (From p In HeliosData.InventarioMovimiento _
                                   Join q In HeliosData.detalleitems On p.idItem Equals q.codigodetalle _
                                   Join doc In HeliosData.documento On p.idDocumento Equals doc.idDocumento _
                                   Where p.idAlmacen = idAlmacen _
                                   And p.fecha.Value.Month = CInt(mes) _
                                   And p.fecha.Value.Year = periodo _
                                   Order By p.fecha _
                                   Select New With _
                                           {.idInventario = p.idInventario, _
                                            .Fecha = p.fecha, _
                                            .idEmpresa = p.idEmpresa, _
                                            .idAlmacen = p.idAlmacen, _
                                            .idItem = p.idItem, _
                                            .nombreItem = q.descripcionItem, _
                                            .unidadMedida = q.unidad1,
                                            .cantidad = p.cantidad, _
                                            .unidad = q.unidad1, _
                                            .tipoExistencia = q.tipoExistencia, _
                                            .tipoDoc = p.tipoDocAlmacen,
                                            .serie = p.serie,
                                            .numero = p.numero,
                                            .UnitproceE = p.precUnite, _
                                            .monto = p.monto, _
                                            .disponible = p.disponible, _
                                            .estado = p.status, _
                                            .TipoRegistro = p.tipoRegistro, _
                                            .Glosa = p.descripcion, _
                                            .NroDoc = doc.nroDoc, _
                                            .Cuenta = p.cuentaOrigen, _
                                            .IdDocumento = p.idDocumento, _
                                            .TipoProducto = p.tipoProducto, _
                                            .DestinoGravado = p.destinoGravadoItem, _
                                            .CostoUS = p.montoUSD, _
                                            .tipoOperacion = p.tipoOperacion _
                                           } _
                                ).ToList

            For Each obj In inventarios
                objInventarioMovimientoBO = New InventarioMovimiento With _
                                            {.idInventario = obj.idInventario, _
                                             .fecha = obj.Fecha, _
                                             .idEmpresa = IIf(IsDBNull(obj.idEmpresa), Nothing, obj.idEmpresa), _
                                             .idAlmacen = IIf(IsDBNull(obj.idAlmacen), Nothing, obj.idAlmacen), _
                                             .idItem = IIf(IsDBNull(obj.idItem), Nothing, obj.idItem), _
                                             .nombreItem = IIf(IsDBNull(obj.nombreItem), Nothing, obj.nombreItem), _
                                             .cantidad = IIf(IsDBNull(obj.cantidad), Nothing, obj.cantidad), _
                                             .unidad = IIf(IsDBNull(obj.unidad), Nothing, obj.unidad), _
                                             .tipoExistencia = obj.tipoExistencia, _
                                             .tipoDocAlmacen = obj.tipoDoc,
                                             .serie = obj.serie,
                                             .numero = obj.numero,
                                             .precUnite = IIf(IsDBNull(obj.UnitproceE), Nothing, obj.UnitproceE), _
                                             .monto = IIf(IsDBNull(obj.monto), Nothing, obj.monto), _
                                             .disponible = IIf(IsDBNull(obj.disponible), Nothing, obj.disponible), _
                                             .status = IIf(IsDBNull(obj.estado), Nothing, obj.estado), _
                                             .tipoRegistro = obj.TipoRegistro.ToString, _
                                             .glosa = obj.Glosa, _
                                             .NumDocCompra = obj.NroDoc, _
                                             .cuentaOrigen = obj.Cuenta, _
                                             .idDocumento = obj.IdDocumento, _
                                             .tipoProducto = obj.TipoProducto, _
                                             .destinoGravadoItem = obj.DestinoGravado, _
                                             .montoUSD = obj.CostoUS, _
                                             .tipoOperacion = obj.tipoOperacion _
                                             }
                listaInventario.Add(objInventarioMovimientoBO)
            Next

            Return listaInventario
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerProdPorAlmacenesDiaRPT(ByVal idAlmacen As String, ByVal strItem As String) As List(Of InventarioMovimiento)
        Dim objInventarioMovimientoBO As InventarioMovimiento
        Dim listaInventario As New List(Of InventarioMovimiento)
        Dim totalsaldo As Decimal = 0
        Dim cantidadSaldo As Decimal = 0
        Dim PrecioPromedio As Decimal = 0
        Dim x = 0
        Dim CantidadTRE As Integer = 0
        Dim precUniteTRE As Decimal = 0.0
        Dim montoTRE As Decimal = 0.0
        Dim CantidadTRS As Integer = 0
        Dim precUniteTRS As Decimal = 0.0
        Dim montoTRS As Decimal = 0.0
        Try
            Dim inventarios = (From p In HeliosData.InventarioMovimiento _
                                   Join q In HeliosData.detalleitems On p.idItem Equals q.codigodetalle _
                                   Join doc In HeliosData.documento On p.idDocumento Equals doc.idDocumento _
                                   Where p.idAlmacen = idAlmacen _
                                   And p.idItem = strItem _
                                   And p.fecha.Value.Day = CDate(DateTime.Now).Day _
                                   And p.fecha.Value.Month = CDate(DateTime.Now).Month _
                                   And p.fecha.Value.Year = CDate(DateTime.Now).Year
                                   Order By p.fecha _
                                   Select New With _
                                           {.idInventario = p.idInventario, _
                                            .Fecha = p.fecha, _
                                            .idEmpresa = p.idEmpresa, _
                                            .idAlmacen = p.idAlmacen, _
                                            .idItem = p.idItem, _
                                            .nombreItem = q.descripcionItem, _
                                            .cantidad = p.cantidad, _
                                            .unidad = p.unidad, _
                                            .UnitproceE = p.precUnite, _
                                            .monto = p.monto, _
                                            .disponible = p.disponible, _
                                            .estado = p.status, _
                                            .TipoRegistro = p.tipoRegistro, _
                                            .Glosa = p.descripcion, _
                                            .NroDoc = doc.nroDoc, _
                                            .Cuenta = p.cuentaOrigen, _
                                            .IdDocumento = p.idDocumento, _
                                            .TipoProducto = p.tipoProducto, _
                                            .DestinoGravado = p.destinoGravadoItem, _
                                            .CostoUS = p.montoUSD, _
                                            .tipoOperacion = p.tipoOperacion _
                                           } _
                                ).ToList

            For Each obj In inventarios

                If x = 0 Then
                    totalsaldo += obj.monto
                    cantidadSaldo += obj.cantidad
                    If (totalsaldo = 0) Then
                        PrecioPromedio = 0
                    Else
                        If cantidadSaldo > 0 Then
                            PrecioPromedio = totalsaldo / cantidadSaldo
                        End If
                    End If
                Else
                    totalsaldo = Math.Round(totalsaldo + CDec(obj.monto), 2)
                    cantidadSaldo = cantidadSaldo + CDec(obj.cantidad)
                    If totalsaldo = 0 Or totalsaldo < 0 Or cantidadSaldo = 0 Then
                        PrecioPromedio = 0
                    Else
                        If cantidadSaldo > 0 Then
                            PrecioPromedio = totalsaldo / cantidadSaldo
                        End If
                    End If

                End If

                Select Case obj.TipoRegistro
                    Case "E", "EA", "EC"
                        CantidadTRE = (FormatNumber(obj.cantidad, 2))
                        precUniteTRE = (FormatNumber(obj.UnitproceE, 2))
                        montoTRE = (FormatNumber(obj.monto, 2))
                        CantidadTRS = ("0.00")
                        precUniteTRS = ("0.00")
                        montoTRS = ("0.00")
                    Case "S", "D"
                        CantidadTRE = ("0.00")
                        precUniteTRE = ("0.00")
                        montoTRE = ("0.00")
                        CantidadTRS = (FormatNumber(obj.cantidad, 2))
                        precUniteTRS = (FormatNumber(obj.UnitproceE, 2))
                        montoTRS = (FormatNumber(obj.monto, 2))

                End Select

                objInventarioMovimientoBO = New InventarioMovimiento With _
                                            {.idInventario = obj.idInventario, _
                                             .fecha = obj.Fecha, _
                                             .idEmpresa = IIf(IsDBNull(obj.idEmpresa), Nothing, obj.idEmpresa), _
                                             .idAlmacen = IIf(IsDBNull(obj.idAlmacen), Nothing, obj.idAlmacen), _
                                             .idItem = IIf(IsDBNull(obj.idItem), Nothing, obj.idItem), _
                                             .nombreItem = IIf(IsDBNull(obj.nombreItem), Nothing, obj.nombreItem), _
                                             .cantidad = IIf(IsDBNull(obj.cantidad), Nothing, obj.cantidad), _
                                             .unidad = IIf(IsDBNull(obj.unidad), Nothing, obj.unidad), _
                                             .precUnite = IIf(IsDBNull(obj.UnitproceE), Nothing, obj.UnitproceE), _
                                             .monto = IIf(IsDBNull(obj.monto), Nothing, obj.monto), _
                                             .disponible = IIf(IsDBNull(obj.disponible), Nothing, obj.disponible), _
                                             .status = IIf(IsDBNull(obj.estado), Nothing, obj.estado), _
                                             .tipoRegistro = obj.TipoRegistro.ToString, _
                                             .glosa = obj.Glosa, _
                                             .NumDocCompra = obj.NroDoc, _
                                             .cuentaOrigen = obj.Cuenta, _
                                             .idDocumento = obj.IdDocumento, _
                                             .tipoProducto = obj.TipoProducto, _
                                             .destinoGravadoItem = obj.DestinoGravado, _
                                             .montoUSD = obj.CostoUS, _
                                             .tipoOperacion = obj.tipoOperacion, _
                                             .CantSalida = CantidadTRE, _
                                             .PrUnitS = precUniteTRE, _
                                             .CostoSalida = montoTRE, _
                                             .CantEntrada = CantidadTRS, _
                                             .PrUnitE = precUniteTRS, _
                                             .CostoEntrada = montoTRS, _
                                              .CantSaldo = cantidadSaldo, _
                                              .CostoSaldo = totalsaldo, _
                                              .PrecioPromedio = PrecioPromedio _
                                                             }
                listaInventario.Add(objInventarioMovimientoBO)
            Next

            Return listaInventario
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerKardexPorAlmacenAnio(ByVal idAlmacen As String, ByVal Anio As Integer) As List(Of InventarioMovimiento)
        Dim objInventarioMovimientoBO As InventarioMovimiento
        Dim listaInventario As New List(Of InventarioMovimiento)

        Dim idItemsRet As Integer = 0
        Dim totalsaldo As Decimal = 0
        Dim cantidadSaldo As Decimal = 0
        Dim PrecioPromedio As Decimal = 0
        Dim x = 0
        Dim CantidadTRE As Integer = 0
        Dim precUniteTRE As Decimal = 0.0
        Dim montoTRE As Decimal = 0.0
        Dim CantidadTRS As Integer = 0
        Dim precUniteTRS As Decimal = 0.0
        Dim montoTRS As Decimal = 0.0

        Try
            Dim inventarios = (From p In HeliosData.InventarioMovimiento _
                                   Join q In HeliosData.detalleitems On p.idItem Equals q.codigodetalle _
                                   Join doc In HeliosData.documento On p.idDocumento Equals doc.idDocumento _
                                   Where p.idAlmacen = idAlmacen _
                                     And p.fecha.Value.Year = Anio _
                                   Order By q.descripcionItem, p.fecha _
                                   Select New With _
                                           {.idInventario = p.idInventario, _
                                            .Fecha = p.fecha, _
                                            .idEmpresa = p.idEmpresa, _
                                            .idAlmacen = p.idAlmacen, _
                                            .idItem = p.idItem, _
                                            .nombreItem = q.descripcionItem, _
                                            .unidadMedida = q.unidad1,
                                            .cantidad = p.cantidad, _
                                            .unidad = q.unidad1, _
                                            .tipoExistencia = q.tipoExistencia, _
                                            .tipoDoc = p.tipoDocAlmacen,
                                            .serie = p.serie,
                                            .numero = p.numero,
                                            .UnitproceE = p.precUnite, _
                                            .monto = p.monto, _
                                            .disponible = p.disponible, _
                                            .estado = p.status, _
                                            .TipoRegistro = p.tipoRegistro, _
                                            .Glosa = p.descripcion, _
                                            .NroDoc = doc.nroDoc, _
                                            .Cuenta = p.cuentaOrigen, _
                                            .IdDocumento = p.idDocumento, _
                                            .TipoProducto = p.tipoProducto, _
                                            .DestinoGravado = p.destinoGravadoItem, _
                                            .CostoUS = p.montoUSD, _
                                            .tipoOperacion = p.tipoOperacion _
                                           } _
                                ).ToList
            For Each obj In inventarios

                If (obj.idItem = idItemsRet) Then

                    totalsaldo = Math.Round(totalsaldo + CDec(obj.monto), 2)
                    cantidadSaldo = cantidadSaldo + CDec(obj.cantidad)
                    If totalsaldo = 0 Or totalsaldo < 0 Or cantidadSaldo = 0 Then
                        PrecioPromedio = 0
                    Else
                        If cantidadSaldo > 0 Then
                            PrecioPromedio = totalsaldo / cantidadSaldo
                        End If
                    End If
                ElseIf (obj.idItem <> idItemsRet) Then
                    totalsaldo = 0
                    cantidadSaldo = 0
                    PrecioPromedio = 0

                    totalsaldo = Math.Round(totalsaldo + CDec(obj.monto), 2)
                    cantidadSaldo = cantidadSaldo + CDec(obj.cantidad)
                    If totalsaldo = 0 Or totalsaldo < 0 Or cantidadSaldo = 0 Then
                        PrecioPromedio = 0
                    Else
                        If cantidadSaldo > 0 Then
                            PrecioPromedio = totalsaldo / cantidadSaldo
                        End If
                    End If
                End If

                Select Case obj.TipoRegistro
                    Case "E", "EA", "EC"
                        CantidadTRE = (FormatNumber(obj.cantidad, 2))
                        precUniteTRE = (FormatNumber(obj.UnitproceE, 2))
                        montoTRE = (FormatNumber(obj.monto, 2))
                        CantidadTRS = ("0.00")
                        precUniteTRS = ("0.00")
                        montoTRS = ("0.00")
                    Case "S", "D"
                        CantidadTRE = ("0.00")
                        precUniteTRE = ("0.00")
                        montoTRE = ("0.00")
                        CantidadTRS = (FormatNumber(obj.cantidad, 2))
                        precUniteTRS = (FormatNumber(obj.UnitproceE, 2))
                        montoTRS = (FormatNumber(obj.monto, 2))

                End Select

                objInventarioMovimientoBO = New InventarioMovimiento With _
                                            {.idInventario = obj.idInventario, _
                                             .fecha = obj.Fecha, _
                                             .idEmpresa = IIf(IsDBNull(obj.idEmpresa), Nothing, obj.idEmpresa), _
                                             .idAlmacen = IIf(IsDBNull(obj.idAlmacen), Nothing, obj.idAlmacen), _
                                             .idItem = IIf(IsDBNull(obj.idItem), Nothing, obj.idItem), _
                                             .nombreItem = IIf(IsDBNull(obj.nombreItem), Nothing, obj.nombreItem), _
                                             .cantidad = IIf(IsDBNull(obj.cantidad), Nothing, obj.cantidad), _
                                             .unidad = IIf(IsDBNull(obj.unidad), Nothing, obj.unidad), _
                                             .tipoExistencia = obj.tipoExistencia, _
                                             .tipoDocAlmacen = obj.tipoDoc,
                                             .serie = obj.serie,
                                             .numero = obj.numero,
                                             .precUnite = IIf(IsDBNull(obj.UnitproceE), Nothing, obj.UnitproceE), _
                                             .monto = IIf(IsDBNull(obj.monto), Nothing, obj.monto), _
                                             .disponible = IIf(IsDBNull(obj.disponible), Nothing, obj.disponible), _
                                             .status = IIf(IsDBNull(obj.estado), Nothing, obj.estado), _
                                             .tipoRegistro = obj.TipoRegistro.ToString, _
                                             .glosa = obj.Glosa, _
                                             .NumDocCompra = obj.NroDoc, _
                                             .cuentaOrigen = obj.Cuenta, _
                                             .idDocumento = obj.IdDocumento, _
                                             .tipoProducto = obj.TipoProducto, _
                                             .destinoGravadoItem = obj.DestinoGravado, _
                                             .montoUSD = obj.CostoUS, _
                                             .tipoOperacion = obj.tipoOperacion, _
                                             .CantEntrada = CantidadTRE, _
                                             .PrUnitE = precUniteTRE, _
                                             .CostoEntrada = montoTRE, _
                                             .CantSalida = CantidadTRS, _
                                             .PrUnitS = precUniteTRS, _
                                             .CostoSalida = montoTRS, _
                                              .CantSaldo = cantidadSaldo, _
                                              .CostoSaldo = totalsaldo, _
                                              .PrecioPromedio = PrecioPromedio _
                                              }
                idItemsRet = objInventarioMovimientoBO.idItem
                listaInventario.Add(objInventarioMovimientoBO)
            Next

            Return listaInventario
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerKardexPorAlmacenMes(ByVal idAlmacen As String, ByVal periodo As Integer, ByVal mes As String) As List(Of InventarioMovimiento)
        Dim objInventarioMovimientoBO As InventarioMovimiento
        Dim listaInventario As New List(Of InventarioMovimiento)

        Dim idItemsRet As Integer = 0
        Dim totalsaldo As Decimal = 0
        Dim cantidadSaldo As Decimal = 0
        Dim PrecioPromedio As Decimal = 0
        Dim x = 0
        Dim CantidadTRE As Integer = 0
        Dim precUniteTRE As Decimal = 0.0
        Dim montoTRE As Decimal = 0.0
        Dim CantidadTRS As Integer = 0
        Dim precUniteTRS As Decimal = 0.0
        Dim montoTRS As Decimal = 0.0

        Try
            Dim inventarios = (From p In HeliosData.InventarioMovimiento _
                                   Join q In HeliosData.detalleitems On p.idItem Equals q.codigodetalle _
                                   Join doc In HeliosData.documento On p.idDocumento Equals doc.idDocumento _
                                   Where p.idAlmacen = idAlmacen _
                                   And p.fecha.Value.Month = CInt(mes) _
                                   And p.fecha.Value.Year = periodo _
                                   Order By q.descripcionItem, p.fecha _
                                   Select New With _
                                           {.idInventario = p.idInventario, _
                                            .Fecha = p.fecha, _
                                            .idEmpresa = p.idEmpresa, _
                                            .idAlmacen = p.idAlmacen, _
                                            .idItem = p.idItem, _
                                            .nombreItem = q.descripcionItem, _
                                            .unidadMedida = q.unidad1,
                                            .cantidad = p.cantidad, _
                                            .unidad = q.unidad1, _
                                            .tipoExistencia = q.tipoExistencia, _
                                            .tipoDoc = p.tipoDocAlmacen,
                                            .serie = p.serie,
                                            .numero = p.numero,
                                            .UnitproceE = p.precUnite, _
                                            .monto = p.monto, _
                                            .disponible = p.disponible, _
                                            .estado = p.status, _
                                            .TipoRegistro = p.tipoRegistro, _
                                            .Glosa = p.descripcion, _
                                            .NroDoc = doc.nroDoc, _
                                            .Cuenta = p.cuentaOrigen, _
                                            .IdDocumento = p.idDocumento, _
                                            .TipoProducto = p.tipoProducto, _
                                            .DestinoGravado = p.destinoGravadoItem, _
                                            .CostoUS = p.montoUSD, _
                                            .tipoOperacion = p.tipoOperacion _
                                           } _
                                ).ToList
            For Each obj In inventarios

                If (obj.idItem = idItemsRet) Then

                    totalsaldo = Math.Round(totalsaldo + CDec(obj.monto), 2)
                    cantidadSaldo = cantidadSaldo + CDec(obj.cantidad)
                    If totalsaldo = 0 Or totalsaldo < 0 Or cantidadSaldo = 0 Then
                        PrecioPromedio = 0
                    Else
                        If cantidadSaldo > 0 Then
                            PrecioPromedio = totalsaldo / cantidadSaldo
                        End If
                    End If
                ElseIf (obj.idItem <> idItemsRet) Then
                    totalsaldo = 0
                    cantidadSaldo = 0
                    PrecioPromedio = 0

                    totalsaldo = Math.Round(totalsaldo + CDec(obj.monto), 2)
                    cantidadSaldo = cantidadSaldo + CDec(obj.cantidad)
                    If totalsaldo = 0 Or totalsaldo < 0 Or cantidadSaldo = 0 Then
                        PrecioPromedio = 0
                    Else
                        If cantidadSaldo > 0 Then
                            PrecioPromedio = totalsaldo / cantidadSaldo
                        End If
                    End If
                End If

                Select Case obj.TipoRegistro
                    Case "E", "EA", "EC"
                        CantidadTRE = (FormatNumber(obj.cantidad, 2))
                        precUniteTRE = (FormatNumber(obj.UnitproceE, 2))
                        montoTRE = (FormatNumber(obj.monto, 2))
                        CantidadTRS = ("0.00")
                        precUniteTRS = ("0.00")
                        montoTRS = ("0.00")
                    Case "S", "D"
                        CantidadTRE = ("0.00")
                        precUniteTRE = ("0.00")
                        montoTRE = ("0.00")
                        CantidadTRS = (FormatNumber(obj.cantidad, 2))
                        precUniteTRS = (FormatNumber(obj.UnitproceE, 2))
                        montoTRS = (FormatNumber(obj.monto, 2))

                End Select

                objInventarioMovimientoBO = New InventarioMovimiento With _
                                            {.idInventario = obj.idInventario, _
                                             .fecha = obj.Fecha, _
                                             .idEmpresa = IIf(IsDBNull(obj.idEmpresa), Nothing, obj.idEmpresa), _
                                             .idAlmacen = IIf(IsDBNull(obj.idAlmacen), Nothing, obj.idAlmacen), _
                                             .idItem = IIf(IsDBNull(obj.idItem), Nothing, obj.idItem), _
                                             .nombreItem = IIf(IsDBNull(obj.nombreItem), Nothing, obj.nombreItem), _
                                             .cantidad = IIf(IsDBNull(obj.cantidad), Nothing, obj.cantidad), _
                                             .unidad = IIf(IsDBNull(obj.unidad), Nothing, obj.unidad), _
                                             .tipoExistencia = obj.tipoExistencia, _
                                             .tipoDocAlmacen = obj.tipoDoc,
                                             .serie = obj.serie,
                                             .numero = obj.numero,
                                             .precUnite = IIf(IsDBNull(obj.UnitproceE), Nothing, obj.UnitproceE), _
                                             .monto = IIf(IsDBNull(obj.monto), Nothing, obj.monto), _
                                             .disponible = IIf(IsDBNull(obj.disponible), Nothing, obj.disponible), _
                                             .status = IIf(IsDBNull(obj.estado), Nothing, obj.estado), _
                                             .tipoRegistro = obj.TipoRegistro.ToString, _
                                             .glosa = obj.Glosa, _
                                             .NumDocCompra = obj.NroDoc, _
                                             .cuentaOrigen = obj.Cuenta, _
                                             .idDocumento = obj.IdDocumento, _
                                             .tipoProducto = obj.TipoProducto, _
                                             .destinoGravadoItem = obj.DestinoGravado, _
                                             .montoUSD = obj.CostoUS, _
                                             .tipoOperacion = obj.tipoOperacion, _
                                             .CantEntrada = CantidadTRE, _
                                             .PrUnitE = precUniteTRE, _
                                             .CostoEntrada = montoTRE, _
                                             .CantSalida = CantidadTRS, _
                                             .PrUnitS = precUniteTRS, _
                                             .CostoSalida = montoTRS, _
                                              .CantSaldo = cantidadSaldo, _
                                              .CostoSaldo = totalsaldo, _
                                              .PrecioPromedio = PrecioPromedio _
                                              }
                idItemsRet = objInventarioMovimientoBO.idItem
                listaInventario.Add(objInventarioMovimientoBO)
            Next

            Return listaInventario
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ReporteKardexPorProducto(ByVal idAlmacen As String, iNtProducto As Integer, ByVal fecDesde As DateTime, ByVal fecHasta As DateTime) As List(Of InventarioMovimiento)


        Dim objInventarioMovimientoBO As InventarioMovimiento
        Dim listaInventario As New List(Of InventarioMovimiento)

        Dim idItemsRet As Integer = 0
        Dim totalsaldo As Decimal = 0
        Dim cantidadSaldo As Decimal = 0
        Dim PrecioPromedio As Decimal = 0
        Dim x = 0
        Dim CantidadTRE As Integer = 0
        Dim precUniteTRE As Decimal = 0.0
        Dim montoTRE As Decimal = 0.0
        Dim CantidadTRS As Integer = 0
        Dim precUniteTRS As Decimal = 0.0
        Dim montoTRS As Decimal = 0.0

        Try
            Dim inventarios = (From p In HeliosData.InventarioMovimiento _
                                   Join q In HeliosData.detalleitems On p.idItem Equals q.codigodetalle _
                                   Join doc In HeliosData.documento On p.idDocumento Equals doc.idDocumento _
                                   Join tablax In HeliosData.tabladetalle On p.tipoOperacion Equals tablax.codigoDetalle _
                                   Where p.idAlmacen = idAlmacen _
                                   And p.idItem = iNtProducto _
                                   And p.fecha >= fecDesde _
                                   And p.fecha <= fecHasta _
                                   And tablax.idtabla = 12 _
                                   Order By q.descripcionItem, p.fecha _
                                   Select New With _
                                           {.idInventario = p.idInventario, _
                                            .Fecha = p.fecha, _
                                            .idEmpresa = p.idEmpresa, _
                                            .idAlmacen = p.idAlmacen, _
                                            .idItem = p.idItem, _
                                            .nombreItem = q.descripcionItem, _
                                            .unidadMedida = q.unidad1,
                                            .cantidad = p.cantidad, _
                                            .unidad = q.unidad1, _
                                            .tipoExistencia = q.tipoExistencia, _
                                            .tipoDoc = p.tipoDocAlmacen,
                                            .serie = p.serie,
                                            .numero = p.numero,
                                            .UnitproceE = p.precUnite, _
                                            .monto = p.monto, _
                                            .disponible = p.disponible, _
                                            .estado = p.status, _
                                            .TipoRegistro = p.tipoRegistro, _
                                            .Glosa = p.descripcion, _
                                            .NroDoc = doc.nroDoc, _
                                            .Cuenta = p.cuentaOrigen, _
                                            .IdDocumento = p.idDocumento, _
                                            .TipoProducto = p.tipoProducto, _
                                            .DestinoGravado = p.destinoGravadoItem, _
                                            .CostoUS = p.montoUSD, _
                                            .tipoOperacion = tablax.descripcion _
                                           } _
                                ).ToList
            For Each obj In inventarios

                If (obj.idItem = idItemsRet) Then

                    totalsaldo = Math.Round(totalsaldo + CDec(obj.monto), 2)
                    cantidadSaldo = cantidadSaldo + CDec(obj.cantidad)
                    If totalsaldo = 0 Or totalsaldo < 0 Or cantidadSaldo = 0 Then
                        PrecioPromedio = 0
                    Else
                        If cantidadSaldo > 0 Then
                            PrecioPromedio = totalsaldo / cantidadSaldo
                        End If
                    End If
                ElseIf (obj.idItem <> idItemsRet) Then
                    totalsaldo = 0
                    cantidadSaldo = 0
                    PrecioPromedio = 0

                    totalsaldo = Math.Round(totalsaldo + CDec(obj.monto), 2)
                    cantidadSaldo = cantidadSaldo + CDec(obj.cantidad)
                    If totalsaldo = 0 Or totalsaldo < 0 Or cantidadSaldo = 0 Then
                        PrecioPromedio = 0
                    Else
                        If cantidadSaldo > 0 Then
                            PrecioPromedio = totalsaldo / cantidadSaldo
                        End If
                    End If
                End If

                Select Case obj.TipoRegistro
                    Case "E", "EA", "EC"
                        CantidadTRE = (FormatNumber(obj.cantidad, 2))
                        precUniteTRE = (FormatNumber(obj.UnitproceE, 2))
                        montoTRE = (FormatNumber(obj.monto, 2))
                        CantidadTRS = ("0.00")
                        precUniteTRS = ("0.00")
                        montoTRS = ("0.00")
                    Case "S", "D"
                        CantidadTRE = ("0.00")
                        precUniteTRE = ("0.00")
                        montoTRE = ("0.00")
                        CantidadTRS = (FormatNumber(obj.cantidad, 2))
                        precUniteTRS = (FormatNumber(obj.UnitproceE, 2))
                        montoTRS = (FormatNumber(obj.monto, 2))

                End Select

                objInventarioMovimientoBO = New InventarioMovimiento With _
                                            {.idInventario = obj.idInventario, _
                                             .fecha = obj.Fecha, _
                                             .idEmpresa = IIf(IsDBNull(obj.idEmpresa), Nothing, obj.idEmpresa), _
                                             .idAlmacen = IIf(IsDBNull(obj.idAlmacen), Nothing, obj.idAlmacen), _
                                             .idItem = IIf(IsDBNull(obj.idItem), Nothing, obj.idItem), _
                                             .nombreItem = IIf(IsDBNull(obj.nombreItem), Nothing, obj.nombreItem), _
                                             .cantidad = IIf(IsDBNull(obj.cantidad), Nothing, obj.cantidad), _
                                             .unidad = IIf(IsDBNull(obj.unidad), Nothing, obj.unidad), _
                                             .tipoExistencia = obj.tipoExistencia, _
                                             .tipoDocAlmacen = obj.tipoDoc,
                                             .serie = obj.serie,
                                             .numero = obj.numero,
                                             .precUnite = IIf(IsDBNull(obj.UnitproceE), Nothing, obj.UnitproceE), _
                                             .monto = IIf(IsDBNull(obj.monto), Nothing, obj.monto), _
                                             .disponible = IIf(IsDBNull(obj.disponible), Nothing, obj.disponible), _
                                             .status = IIf(IsDBNull(obj.estado), Nothing, obj.estado), _
                                             .tipoRegistro = obj.TipoRegistro.ToString, _
                                             .glosa = obj.Glosa, _
                                             .NumDocCompra = obj.NroDoc, _
                                             .cuentaOrigen = obj.Cuenta, _
                                             .idDocumento = obj.IdDocumento, _
                                             .tipoProducto = obj.TipoProducto, _
                                             .destinoGravadoItem = obj.DestinoGravado, _
                                             .montoUSD = obj.CostoUS, _
                                             .tipoOperacion = obj.tipoOperacion, _
                                             .CantEntrada = CantidadTRE, _
                                             .PrUnitE = precUniteTRE, _
                                             .CostoEntrada = montoTRE, _
                                             .CantSalida = CantidadTRS, _
                                             .PrUnitS = precUniteTRS, _
                                             .CostoSalida = montoTRS, _
                                              .CantSaldo = cantidadSaldo, _
                                              .CostoSaldo = totalsaldo, _
                                              .PrecioPromedio = PrecioPromedio _
                                              }
                idItemsRet = objInventarioMovimientoBO.idItem
                listaInventario.Add(objInventarioMovimientoBO)
            Next

            Return listaInventario
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerKardexPorAlmacenDia(ByVal idAlmacen As String) As List(Of InventarioMovimiento)
        Dim objInventarioMovimientoBO As InventarioMovimiento
        Dim listaInventario As New List(Of InventarioMovimiento)

        Dim idItemsRet As Integer = 0
        Dim totalsaldo As Decimal = 0
        Dim cantidadSaldo As Decimal = 0
        Dim PrecioPromedio As Decimal = 0
        Dim x = 0
        Dim CantidadTRE As Integer = 0
        Dim precUniteTRE As Decimal = 0.0
        Dim montoTRE As Decimal = 0.0
        Dim CantidadTRS As Integer = 0
        Dim precUniteTRS As Decimal = 0.0
        Dim montoTRS As Decimal = 0.0

        Try
            Dim inventarios = (From p In HeliosData.InventarioMovimiento _
                                   Join q In HeliosData.detalleitems On p.idItem Equals q.codigodetalle _
                                   Join doc In HeliosData.documento On p.idDocumento Equals doc.idDocumento _
                                   Where p.idAlmacen = idAlmacen _
                                      And p.fecha.Value.Day = CDate(DateTime.Now).Day _
                                   And p.fecha.Value.Month = CDate(DateTime.Now).Month _
                                   And p.fecha.Value.Year = CDate(DateTime.Now).Year
                                   Order By q.descripcionItem, p.fecha _
                                   Select New With _
                                           {.idInventario = p.idInventario, _
                                            .Fecha = p.fecha, _
                                            .idEmpresa = p.idEmpresa, _
                                            .idAlmacen = p.idAlmacen, _
                                            .idItem = p.idItem, _
                                            .nombreItem = q.descripcionItem, _
                                            .unidadMedida = q.unidad1,
                                            .cantidad = p.cantidad, _
                                            .unidad = q.unidad1, _
                                            .tipoExistencia = q.tipoExistencia, _
                                            .tipoDoc = p.tipoDocAlmacen,
                                            .serie = p.serie,
                                            .numero = p.numero,
                                            .UnitproceE = p.precUnite, _
                                            .monto = p.monto, _
                                            .disponible = p.disponible, _
                                            .estado = p.status, _
                                            .TipoRegistro = p.tipoRegistro, _
                                            .Glosa = p.descripcion, _
                                            .NroDoc = doc.nroDoc, _
                                            .Cuenta = p.cuentaOrigen, _
                                            .IdDocumento = p.idDocumento, _
                                            .TipoProducto = p.tipoProducto, _
                                            .DestinoGravado = p.destinoGravadoItem, _
                                            .CostoUS = p.montoUSD, _
                                            .tipoOperacion = p.tipoOperacion _
                                           } _
                                ).ToList
            For Each obj In inventarios

                If (obj.idItem = idItemsRet) Then

                    totalsaldo = Math.Round(totalsaldo + CDec(obj.monto), 2)
                    cantidadSaldo = cantidadSaldo + CDec(obj.cantidad)
                    If totalsaldo = 0 Or totalsaldo < 0 Or cantidadSaldo = 0 Then
                        PrecioPromedio = 0
                    Else
                        If cantidadSaldo > 0 Then
                            PrecioPromedio = totalsaldo / cantidadSaldo
                        End If
                    End If
                ElseIf (obj.idItem <> idItemsRet) Then
                    totalsaldo = 0
                    cantidadSaldo = 0
                    PrecioPromedio = 0

                    totalsaldo = Math.Round(totalsaldo + CDec(obj.monto), 2)
                    cantidadSaldo = cantidadSaldo + CDec(obj.cantidad)
                    If totalsaldo = 0 Or totalsaldo < 0 Or cantidadSaldo = 0 Then
                        PrecioPromedio = 0
                    Else
                        If cantidadSaldo > 0 Then
                            PrecioPromedio = totalsaldo / cantidadSaldo
                        End If
                    End If
                End If

                Select Case obj.TipoRegistro
                    Case "E", "EA", "EC"
                        CantidadTRE = (FormatNumber(obj.cantidad, 2))
                        precUniteTRE = (FormatNumber(obj.UnitproceE, 2))
                        montoTRE = (FormatNumber(obj.monto, 2))
                        CantidadTRS = ("0.00")
                        precUniteTRS = ("0.00")
                        montoTRS = ("0.00")
                    Case "S", "D"
                        CantidadTRE = ("0.00")
                        precUniteTRE = ("0.00")
                        montoTRE = ("0.00")
                        CantidadTRS = (FormatNumber(obj.cantidad, 2))
                        precUniteTRS = (FormatNumber(obj.UnitproceE, 2))
                        montoTRS = (FormatNumber(obj.monto, 2))

                End Select

                objInventarioMovimientoBO = New InventarioMovimiento With _
                                            {.idInventario = obj.idInventario, _
                                             .fecha = obj.Fecha, _
                                             .idEmpresa = IIf(IsDBNull(obj.idEmpresa), Nothing, obj.idEmpresa), _
                                             .idAlmacen = IIf(IsDBNull(obj.idAlmacen), Nothing, obj.idAlmacen), _
                                             .idItem = IIf(IsDBNull(obj.idItem), Nothing, obj.idItem), _
                                             .nombreItem = IIf(IsDBNull(obj.nombreItem), Nothing, obj.nombreItem), _
                                             .cantidad = IIf(IsDBNull(obj.cantidad), Nothing, obj.cantidad), _
                                             .unidad = IIf(IsDBNull(obj.unidad), Nothing, obj.unidad), _
                                             .tipoExistencia = obj.tipoExistencia, _
                                             .tipoDocAlmacen = obj.tipoDoc,
                                             .serie = obj.serie,
                                             .numero = obj.numero,
                                             .precUnite = IIf(IsDBNull(obj.UnitproceE), Nothing, obj.UnitproceE), _
                                             .monto = IIf(IsDBNull(obj.monto), Nothing, obj.monto), _
                                             .disponible = IIf(IsDBNull(obj.disponible), Nothing, obj.disponible), _
                                             .status = IIf(IsDBNull(obj.estado), Nothing, obj.estado), _
                                             .tipoRegistro = obj.TipoRegistro.ToString, _
                                             .glosa = obj.Glosa, _
                                             .NumDocCompra = obj.NroDoc, _
                                             .cuentaOrigen = obj.Cuenta, _
                                             .idDocumento = obj.IdDocumento, _
                                             .tipoProducto = obj.TipoProducto, _
                                             .destinoGravadoItem = obj.DestinoGravado, _
                                             .montoUSD = obj.CostoUS, _
                                             .tipoOperacion = obj.tipoOperacion, _
                                             .CantEntrada = CantidadTRE, _
                                             .PrUnitE = precUniteTRE, _
                                             .CostoEntrada = montoTRE, _
                                             .CantSalida = CantidadTRS, _
                                             .PrUnitS = precUniteTRS, _
                                             .CostoSalida = montoTRS, _
                                              .CantSaldo = cantidadSaldo, _
                                              .CostoSaldo = totalsaldo, _
                                              .PrecioPromedio = PrecioPromedio _
                                              }
                idItemsRet = objInventarioMovimientoBO.idItem
                listaInventario.Add(objInventarioMovimientoBO)
            Next

            Return listaInventario
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
