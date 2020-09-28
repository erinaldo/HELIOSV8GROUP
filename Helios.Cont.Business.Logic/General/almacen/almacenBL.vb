Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class almacenBL
    Inherits BaseBL

    Public Function GetEsAlmacenVirtual(intIdAlmacen As Integer) As Boolean
        Dim consulta = (From n In HeliosData.almacen
                        Where n.tipo = "AV" _
                       And n.idAlmacen = intIdAlmacen).FirstOrDefault

        If Not IsNothing(consulta) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function GetListar_almacenesTipo(intIdEstablecimiento As Integer, tipo As String) As List(Of almacen)
        Return (From a In HeliosData.almacen Where a.idEstablecimiento = intIdEstablecimiento And a.tipo = tipo).ToList
    End Function

    Public Function GetListar_almacenesTipobyEmpresa(almacenBE As almacen) As List(Of almacen)
        Return (From a In HeliosData.almacen Where a.idEmpresa = almacenBE.idEmpresa And a.tipo = almacenBE.tipo).ToList
    End Function

    Public Function GetListar_AlmaPuntoUbi(intIdEstablecimiento As Integer) As List(Of almacen)

        Dim listaTipo As New List(Of String)
        listaTipo.Add("AV")
        listaTipo.Add("AF")
        listaTipo.Add("PU")

        Return (From a In HeliosData.almacen Where a.idEstablecimiento = intIdEstablecimiento And listaTipo.Contains(a.tipo) Select a).ToList
    End Function


    Public Function Insert(ByVal almacenBE As almacen) As Integer
        Using ts As New TransactionScope
            HeliosData.almacen.Add(almacenBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return almacenBE.idAlmacen
        End Using
    End Function

    Public Sub Update(ByVal almacenBE As almacen)
        Using ts As New TransactionScope
            Dim almacen As almacen = HeliosData.almacen.Where(Function(o) _
                                            o.idAlmacen = almacenBE.idAlmacen).First()

            almacen.idEmpresa = almacenBE.idEmpresa
            almacen.idEstablecimiento = almacenBE.idEstablecimiento
            almacen.descripcionAlmacen = almacenBE.descripcionAlmacen
            almacen.encargado = almacenBE.encargado
            almacen.tipo = almacenBE.tipo
            almacen.estado = almacenBE.estado
            almacen.predeterminado = almacenBE.predeterminado
            almacen.porcentajeUtilidad = almacenBE.porcentajeUtilidad
            almacen.usuarioModificacion = almacenBE.usuarioModificacion
            almacen.fechaModificacion = almacenBE.fechaModificacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(almacen).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal almacenBE As almacen)

        Using ts As New TransactionScope

            Dim consulta As almacen = HeliosData.almacen.Where(Function(o) o.idAlmacen = almacenBE.idAlmacen).First
            CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function GetListar_almacen() As List(Of almacen)
        Return (From a In HeliosData.almacen Select a).ToList
    End Function

    Public Function GetListar_almacenExceptAV(almacenBE As almacen) As List(Of almacen)
        Dim Lista As New List(Of String)
        Lista.Add("AV")
        Lista.Add("PU")

        GetListar_almacenExceptAV = New List(Of almacen)

        Select Case almacenBE.TipoConsulta
            Case "EMPRESA"

                GetListar_almacenExceptAV = (From a In HeliosData.almacen Where Not Lista.Contains(a.tipo) And
              a.idEmpresa = almacenBE.idEmpresa Select a).ToList

            Case "UNIDAD_ORGANICA"

                GetListar_almacenExceptAV = (From a In HeliosData.almacen Where Not Lista.Contains(a.tipo) And
              a.idEmpresa = almacenBE.idEmpresa And a.idEstablecimiento = almacenBE.idEstablecimiento Select a).ToList

        End Select

        Return GetListar_almacenExceptAV

    End Function



    Public Function GetListar_almacenALL(idEmpresa As String) As List(Of almacen)
        Dim Lista As New List(Of String)
        Lista.Add("AV")
        Lista.Add("PU")

        Return (From a In HeliosData.almacen Where Not Lista.Contains(a.tipo) And
                a.idEmpresa = idEmpresa Select a).ToList
    End Function

    Public Function GetListar_almacenes(intIdEstablecimiento As Integer) As List(Of almacen)

        Dim listaTipo As New List(Of String)
        listaTipo.Add("AV")
        listaTipo.Add("AF")

        Return (From a In HeliosData.almacen Where a.idEstablecimiento = intIdEstablecimiento And listaTipo.Contains(a.tipo) Select a).ToList

    End Function

    Public Function GetUbicar_almacenPorID(idAlmacen As Integer) As almacen
        Return (From a In HeliosData.almacen
                Where a.idAlmacen = idAlmacen Select a).FirstOrDefault
    End Function

    Public Function GetUbicar_almacenVirtual(intIdEstablecimiento As Integer) As almacen
        Return (From a In HeliosData.almacen
                Where a.idEstablecimiento = intIdEstablecimiento _
                And a.tipo = "AV").FirstOrDefault
    End Function

    Public Function GetUbicar_almacenPredeterminado(intIdEstablecimiento As Integer) As almacen
        Return (From n In HeliosData.almacen
                Where n.idEstablecimiento = intIdEstablecimiento _
                And n.predeterminado = "S").First
    End Function


    Public Function GetEsAlmacenVirtualXFull(strIdempresa As String, intIdEstblec As Integer, intTipo As String) As almacen
        Dim consulta = (From n In HeliosData.almacen
                        Where n.tipo = "AV" _
                       And n.idEmpresa = strIdempresa _
                       And n.idEstablecimiento = intIdEstblec).FirstOrDefault


        Return consulta

    End Function

    'Public Function GetListar_almacenPorUsuario(idEmpresa As String, idEstable As Integer, listaPersona As List(Of String), intAnio As Integer, intMes As Integer, fechaInicio As DateTime, fechaFin As DateTime, tipop As String) As List(Of almacen)
    '    Dim Lista As New List(Of almacen)
    '    Dim docCuenta As New almacen
    '    Dim listaTipo As New List(Of String)
    '    listaTipo.Add("EA")
    '    listaTipo.Add("E")

    '    Select Case tipop
    '        Case "XTodo"
    '            Dim consulta2 = (From b In HeliosData.InventarioMovimiento
    '                             Where
    '                          b.idEmpresa = idEmpresa And
    '                          CStr(b.idEstablecimiento) = idEstable And
    '                          listaPersona.Contains(b.usuarioActualizacion) And
    '                             b.fecha.Value.Year = intAnio
    '                             Group b.almacen By
    '                          b.almacen.descripcionAlmacen,
    '                          b.almacen.tipo,
    '                          IdAlmacen = CType(b.almacen.idAlmacen, Int32?)
    '            Into g = Group
    '                             Select
    '                          descripcionAlmacen,
    '                          tipo,
    '                          IdAlmacen = CType(IdAlmacen, Int32?),
    '                          ingreso = (CType((Aggregate t1 In
    '                      (From c In HeliosData.InventarioMovimiento
    '                       Where
    '                          c.idAlmacen = IdAlmacen And
    '                         listaTipo.Contains(c.tipoRegistro) And
    '                          listaPersona.Contains(c.usuarioActualizacion)
    '                       Select New With {
    '                          c.monto
    '                      }) Into Sum(t1.monto)), Decimal?)),
    '                          salida = (CType((Aggregate t1 In
    '                      (From c In HeliosData.InventarioMovimiento
    '                       Where
    '                          c.idAlmacen = IdAlmacen And
    '                          c.tipoRegistro = "S" And
    '                           listaPersona.Contains(c.usuarioActualizacion)
    '                       Select New With {
    '                          c.monto
    '                      }) Into Sum(t1.monto)), Decimal?))).ToList

    '            For Each i In consulta2
    '                docCuenta = New almacen
    '                docCuenta.descripcionAlmacen = i.descripcionAlmacen
    '                docCuenta.montoMN = i.ingreso.GetValueOrDefault
    '                docCuenta.montoME = i.salida.GetValueOrDefault
    '                docCuenta.idAlmacen = i.IdAlmacen
    '                docCuenta.tipo = i.tipo

    '                Lista.Add(docCuenta)
    '            Next
    '        Case "XPeriodo"
    '            Dim consulta2 = (From b In HeliosData.InventarioMovimiento
    '                             Where
    '                    b.idEmpresa = idEmpresa And
    '                    CStr(b.idEstablecimiento) = idEstable And
    '                    listaPersona.Contains(b.usuarioActualizacion) And
    '                       b.fecha.Value.Year = intAnio And
    '                       b.fecha.Value.Month = intMes
    '                             Group b.almacen By
    '                    b.almacen.descripcionAlmacen,
    '                    b.almacen.tipo,
    '                    IdAlmacen = CType(b.almacen.idAlmacen, Int32?)
    '        Into g = Group
    '                             Select
    '                          descripcionAlmacen,
    '                          tipo,
    '                          IdAlmacen = CType(IdAlmacen, Int32?),
    '                          ingreso = (CType((Aggregate t1 In
    '                      (From c In HeliosData.InventarioMovimiento
    '                       Where
    '                          c.idAlmacen = IdAlmacen And
    '                         listaTipo.Contains(c.tipoRegistro) And
    '                          listaPersona.Contains(c.usuarioActualizacion)
    '                       Select New With {
    '                          c.monto
    '                      }) Into Sum(t1.monto)), Decimal?)),
    '                          salida = (CType((Aggregate t1 In
    '                      (From c In HeliosData.InventarioMovimiento
    '                       Where
    '                          c.idAlmacen = IdAlmacen And
    '                          c.tipoRegistro = "S" And
    '                           listaPersona.Contains(c.usuarioActualizacion)
    '                       Select New With {
    '                          c.monto
    '                      }) Into Sum(t1.monto)), Decimal?))).ToList

    '            For Each i In consulta2
    '                docCuenta = New almacen
    '                docCuenta.descripcionAlmacen = i.descripcionAlmacen
    '                docCuenta.montoMN = i.ingreso.GetValueOrDefault
    '                docCuenta.montoME = i.salida.GetValueOrDefault
    '                docCuenta.idAlmacen = i.IdAlmacen
    '                docCuenta.tipo = i.tipo

    '                Lista.Add(docCuenta)
    '            Next
    '        Case "XDia"
    '            Dim consulta2 = (From b In HeliosData.InventarioMovimiento
    '                             Where
    '                  b.idEmpresa = idEmpresa And
    '                  CStr(b.idEstablecimiento) = idEstable And
    '                  listaPersona.Contains(b.usuarioActualizacion) And
    '                     b.fecha >= fechaInicio And
    '                     b.fecha <= fechaFin
    '                             Group b.almacen By
    '                  b.almacen.descripcionAlmacen,
    '                  b.almacen.tipo,
    '                  IdAlmacen = CType(b.almacen.idAlmacen, Int32?)
    '      Into g = Group
    '                             Select
    '                          descripcionAlmacen,
    '                          tipo,
    '                          IdAlmacen = CType(IdAlmacen, Int32?),
    '                          ingreso = (CType((Aggregate t1 In
    '                      (From c In HeliosData.InventarioMovimiento
    '                       Where
    '                          c.idAlmacen = IdAlmacen And
    '                         listaTipo.Contains(c.tipoRegistro) And
    '                          listaPersona.Contains(c.usuarioActualizacion)
    '                       Select New With {
    '                          c.monto
    '                      }) Into Sum(t1.monto)), Decimal?)),
    '                          salida = (CType((Aggregate t1 In
    '                      (From c In HeliosData.InventarioMovimiento
    '                       Where
    '                          c.idAlmacen = IdAlmacen And
    '                          c.tipoRegistro = "S" And
    '                           listaPersona.Contains(c.usuarioActualizacion)
    '                       Select New With {
    '                          c.monto
    '                      }) Into Sum(t1.monto)), Decimal?))).ToList

    '            For Each i In consulta2
    '                docCuenta = New almacen
    '                docCuenta.descripcionAlmacen = i.descripcionAlmacen
    '                docCuenta.montoMN = i.ingreso.GetValueOrDefault
    '                docCuenta.montoME = i.salida.GetValueOrDefault
    '                docCuenta.idAlmacen = i.IdAlmacen
    '                docCuenta.tipo = i.tipo
    '                Lista.Add(docCuenta)
    '            Next
    '    End Select


    '    Return Lista
    'End Function

    Public Function GetListar_almacenPorUsuario(idEmpresa As String, idEstable As Integer, listaPersona As List(Of String), intAnio As Integer, intMes As Integer, fechaInicio As DateTime, fechaFin As DateTime, tipop As String, intDia As Integer) As List(Of almacen)
        Dim Lista As New List(Of almacen)
        Dim docCuenta As New almacen
        Dim listaTipo As New List(Of String)
        listaTipo.Add("EA")
        listaTipo.Add("E")

        Select Case tipop
            Case "XTodo"
                Dim consulta2 = (From b In HeliosData.InventarioMovimiento
                                 Where
                              b.idEmpresa = idEmpresa And
                              CStr(b.idEstablecimiento) = idEstable And
                              listaPersona.Contains(b.usuarioActualizacion) And
                                 b.fecha.Value.Year = intAnio
                                 Group b.almacen By
                              b.almacen.descripcionAlmacen,
                              b.almacen.tipo,
                              IdAlmacen = CType(b.almacen.idAlmacen, Int32?)
                Into g = Group
                                 Select
                              descripcionAlmacen,
                              tipo,
                              IdAlmacen = CType(IdAlmacen, Int32?),
                              ingreso = (CType((Aggregate t1 In
                          (From c In HeliosData.InventarioMovimiento
                           Where
                              c.idAlmacen = IdAlmacen And
                             listaTipo.Contains(c.tipoRegistro) And
                              listaPersona.Contains(c.usuarioActualizacion)
                           Select New With {
                              c.monto
                          }) Into Sum(t1.monto)), Decimal?)),
                              salida = (CType((Aggregate t1 In
                          (From c In HeliosData.InventarioMovimiento
                           Where
                              c.idAlmacen = IdAlmacen And
                              c.tipoRegistro = "S" And
                               listaPersona.Contains(c.usuarioActualizacion)
                           Select New With {
                              c.monto
                          }) Into Sum(t1.monto)), Decimal?))).ToList

                For Each i In consulta2
                    docCuenta = New almacen
                    docCuenta.descripcionAlmacen = i.descripcionAlmacen
                    docCuenta.montoMN = i.ingreso.GetValueOrDefault
                    docCuenta.montoME = i.salida.GetValueOrDefault
                    docCuenta.idAlmacen = i.IdAlmacen
                    docCuenta.tipo = i.tipo

                    Lista.Add(docCuenta)
                Next
            Case "XPeriodo"
                Dim consulta2 = (From b In HeliosData.InventarioMovimiento
                                 Where
                        b.idEmpresa = idEmpresa And
                        CStr(b.idEstablecimiento) = idEstable And
                        listaPersona.Contains(b.usuarioActualizacion) And
                           b.fecha.Value.Year = intAnio And
                           b.fecha.Value.Month = intMes
                                 Group b.almacen By
                        b.almacen.descripcionAlmacen,
                        b.almacen.tipo,
                        IdAlmacen = CType(b.almacen.idAlmacen, Int32?)
            Into g = Group
                                 Select
                              descripcionAlmacen,
                              tipo,
                              IdAlmacen = CType(IdAlmacen, Int32?),
                              ingreso = (CType((Aggregate t1 In
                          (From c In HeliosData.InventarioMovimiento
                           Where
                              c.idAlmacen = IdAlmacen And
                             listaTipo.Contains(c.tipoRegistro) And
                              listaPersona.Contains(c.usuarioActualizacion)
                           Select New With {
                              c.monto
                          }) Into Sum(t1.monto)), Decimal?)),
                              salida = (CType((Aggregate t1 In
                          (From c In HeliosData.InventarioMovimiento
                           Where
                              c.idAlmacen = IdAlmacen And
                              c.tipoRegistro = "S" And
                               listaPersona.Contains(c.usuarioActualizacion)
                           Select New With {
                              c.monto
                          }) Into Sum(t1.monto)), Decimal?))).ToList

                For Each i In consulta2
                    docCuenta = New almacen
                    docCuenta.descripcionAlmacen = i.descripcionAlmacen
                    docCuenta.montoMN = i.ingreso.GetValueOrDefault
                    docCuenta.montoME = i.salida.GetValueOrDefault
                    docCuenta.idAlmacen = i.IdAlmacen
                    docCuenta.tipo = i.tipo

                    Lista.Add(docCuenta)
                Next
            Case "XDia"
                Dim consulta2 = (From b In HeliosData.InventarioMovimiento
                                 Where
                      b.idEmpresa = idEmpresa And
                      CStr(b.idEstablecimiento) = idEstable And
                      listaPersona.Contains(b.usuarioActualizacion) And
                         b.fecha >= fechaInicio And
                         b.fecha <= fechaFin
                                 Group b.almacen By
                      b.almacen.descripcionAlmacen,
                      b.almacen.tipo,
                      IdAlmacen = CType(b.almacen.idAlmacen, Int32?)
          Into g = Group
                                 Select
                              descripcionAlmacen,
                              tipo,
                              IdAlmacen = CType(IdAlmacen, Int32?),
                              ingreso = (CType((Aggregate t1 In
                          (From c In HeliosData.InventarioMovimiento
                           Where
                              c.idAlmacen = IdAlmacen And
                             listaTipo.Contains(c.tipoRegistro) And
                              listaPersona.Contains(c.usuarioActualizacion)
                           Select New With {
                              c.monto
                          }) Into Sum(t1.monto)), Decimal?)),
                              salida = (CType((Aggregate t1 In
                          (From c In HeliosData.InventarioMovimiento
                           Where
                              c.idAlmacen = IdAlmacen And
                              c.tipoRegistro = "S" And
                               listaPersona.Contains(c.usuarioActualizacion)
                           Select New With {
                              c.monto
                          }) Into Sum(t1.monto)), Decimal?))).ToList

                For Each i In consulta2
                    docCuenta = New almacen
                    docCuenta.descripcionAlmacen = i.descripcionAlmacen
                    docCuenta.montoMN = i.ingreso.GetValueOrDefault
                    docCuenta.montoME = i.salida.GetValueOrDefault
                    docCuenta.idAlmacen = i.IdAlmacen
                    docCuenta.tipo = i.tipo
                    Lista.Add(docCuenta)
                Next

            Case "XHora"
                Dim consulta2 = (From b In HeliosData.InventarioMovimiento
                                 Where
                        b.idEmpresa = idEmpresa And
                        CStr(b.idEstablecimiento) = idEstable And
                        listaPersona.Contains(b.usuarioActualizacion) And
                                        b.fecha.Value.Year = intAnio And
                                             b.fecha.Value.Month = intMes And
                                             b.fecha.Value.Day = intDia And
                                        b.fecha.Value.Hour >= fechaInicio.Hour And
                                        b.fecha.Value.Hour <= fechaFin.Hour
                                 Group b.almacen By
                        b.almacen.descripcionAlmacen,
                        b.almacen.tipo,
                        IdAlmacen = CType(b.almacen.idAlmacen, Int32?)
            Into g = Group
                                 Select
                              descripcionAlmacen,
                              tipo,
                              IdAlmacen = CType(IdAlmacen, Int32?),
                              ingreso = (CType((Aggregate t1 In
                          (From c In HeliosData.InventarioMovimiento
                           Where
                              c.idAlmacen = IdAlmacen And
                             listaTipo.Contains(c.tipoRegistro) And
                              listaPersona.Contains(c.usuarioActualizacion)
                           Select New With {
                              c.monto
                          }) Into Sum(t1.monto)), Decimal?)),
                              salida = (CType((Aggregate t1 In
                          (From c In HeliosData.InventarioMovimiento
                           Where
                              c.idAlmacen = IdAlmacen And
                              c.tipoRegistro = "S" And
                               listaPersona.Contains(c.usuarioActualizacion)
                           Select New With {
                              c.monto
                          }) Into Sum(t1.monto)), Decimal?))).ToList

                For Each i In consulta2
                    docCuenta = New almacen
                    docCuenta.descripcionAlmacen = i.descripcionAlmacen
                    docCuenta.montoMN = i.ingreso.GetValueOrDefault
                    docCuenta.montoME = i.salida.GetValueOrDefault
                    docCuenta.idAlmacen = i.IdAlmacen
                    docCuenta.tipo = i.tipo

                    Lista.Add(docCuenta)
                Next

        End Select


        Return Lista
    End Function

    Public Sub CambiarEstadoAlmacen(be As almacen)

        Dim alm = HeliosData.almacen.Where(Function(o) o.idAlmacen = be.idAlmacen).Single
        Using ts As New TransactionScope
            alm.estado = be.estado
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub
End Class
