Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class numeracionBoletasBL
    Inherits BaseBL

    Public Function GenerarNumero(intIdEstablecimiento As Integer, strcodigoNumeracion As String, strTipo As String) As numeracionBoletas
        Dim valor As Integer
        Try
            Using ts As New TransactionScope()
                Dim numeracion As numeracionBoletas = HeliosData.numeracionBoletas.Where(Function(o) o.establecimiento = intIdEstablecimiento And o.codigoNumeracion = strcodigoNumeracion _
                                                                                             And o.tipo = strTipo).First
                With numeracion
                    valor = .valorInicial
                    valor = CDec(valor) + 1
                    .valorInicial = valor 'String.Concat(rpta)
                End With
                'HeliosData.ObjectStateManager.GetObjectStateEntry(numeracion).State.ToString()
                HeliosData.SaveChanges()
                ts.Complete()
                Return numeracion
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GenerarNumeroXTipo(intIdEstablecimiento As Integer, strcodigoNumeracion As String, strTipo As String) As Integer
        Try
            Dim consulta = NumeracionBoletasSel(intIdEstablecimiento, strcodigoNumeracion, strTipo)

            Dim numero = GenerarNumeroPorID(consulta.IdEnumeracion)

            Return numero

        Catch ex As Exception

        End Try

    End Function

    Public Function NumeracionBoletasSel(intIdEstablecimiento As Integer,
                                         strcodigoNumeracion As String, strTipo As String) As numeracionBoletas

        Return (From n In HeliosData.numeracionBoletas
                Where n.establecimiento = intIdEstablecimiento _
                             And n.codigoNumeracion = strcodigoNumeracion _
                             And n.tipo = strTipo
                Select n).First
    End Function


    Public Function NumeracionBoletasSelV2(intIdEstablecimiento As Integer,
                                         strcodigoNumeracion As String, strTipo As String, idCargo As Integer) As numeracionBoletas
        Try


            Return (From n In HeliosData.numeracionBoletas Join x In HeliosData.distribucionNumeracionAO
                On n.IdEnumeracion Equals x.IdEnumeracion
                    Where n.establecimiento = intIdEstablecimiento _
                                 And n.codigoNumeracion = strcodigoNumeracion _
                                 And x.idRol = idCargo
                    Select n).First

        Catch ex As Exception
            Throw New Exception("Verificar acceso de numeración")
        End Try
    End Function


    Public Sub InsertarNumeracionInicio(lista As List(Of numeracionBoletas), listaCentroCostos As List(Of centrocosto))
        Try
            Dim moduloBL As New ModuloConfiguracionBL
            Dim organizacionBL As New organizacionBL
            Dim distribucionNuemacionBL As New distribucionNumeracionAOBL
            Dim listaModulo As New List(Of moduloConfiguracion)
            Dim listaNumeracion As New List(Of numeracionBoletas)
            Dim numeracionBE As numeracionBoletas
            Dim moduloEstado As Boolean = True

            Dim listaOrganizacion = organizacionBL.GetInsertOrganizacion(lista, listaCentroCostos)

            Using ts As New TransactionScope

                'For Each organizacion In listaOrganizacion
                For Each i In lista
                    If (moduloEstado = True) Then
                        Dim idConfiguracion = moduloBL.InsertarModulo(0, i)
                        listaModulo.Add(idConfiguracion)
                    End If
                    numeracionBE = New numeracionBoletas
                    numeracionBE = InsertsINGLE(i)
                    listaNumeracion.Add(numeracionBE)
                    moduloEstado = False
                Next

                'SE MOVIO VERIFICAR AL CREAR LA NUEVA EMPRESA IDCARGO 
                For Each organizacion In listaOrganizacion
                    For Each numeacion In listaNumeracion.ToList
                        distribucionNuemacionBL.InsertAreaOperativaNumeracion(New distribucionNumeracionAO With {
                                                                                                  .IdEnumeracion = numeacion.IdEnumeracion,
                                                                                                  .idCargo = organizacion.idCargo,
                                                                                                  .idRol = organizacion.tipo,
                                                                                                  .usuarioActualizacion = "Administrador",
                                                                                                  .fechaActualizacion = Date.Now})
                    Next
                Next

                'Next

                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub InsertarNumeracionXUnidOrg(lista As List(Of numeracionBoletas))
        Try
            Dim moduloBL As New ModuloConfiguracionBL
            Dim organizacionBL As New OrganizacionBL
            Dim distribucionNuemacionBL As New distribucionNumeracionAOBL
            Dim listaModulo As New List(Of moduloConfiguracion)
            Dim listaNumeracion As New List(Of numeracionBoletas)
            Dim numeracionBE As numeracionBoletas
            Dim moduloEstado As Boolean = True
            Dim NUMERACION As Integer = 0
            Using ts As New TransactionScope

                Dim consulta = (From n In HeliosData.numeracionBoletas Select n.anclado).Max

                If (Not IsNothing(consulta)) Then
                    NUMERACION = consulta + 1
                Else
                    NUMERACION = 0 + 1
                End If

                For Each i In lista
                    i.anclado = NUMERACION
                    numeracionBE = New numeracionBoletas
                    numeracionBE = InsertNumeracionXUnidOrg(i)
                    listaNumeracion.Add(numeracionBE)
                    moduloEstado = False
                Next

                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ObtenerDocumentoPorEstablecimiento(intIdEstablecimiento As Integer, ByVal strSerie As String,
                                                  strcodigoNumeracion As String, strTipo As String) As numeracionBoletas

        Return (From n In HeliosData.numeracionBoletas _
                             Where n.establecimiento = intIdEstablecimiento _
                             AndAlso n.serie = strSerie _
                             And n.codigoNumeracion = strcodigoNumeracion _
                             And n.tipo = strTipo _
                             Select n).First
    End Function

    Public Function ObtenerSeriesPorModulo(intIdEstablecimiento As Integer, strModulo As String) As List(Of numeracionBoletas)

        Return (From n In HeliosData.numeracionBoletas _
                             Where n.establecimiento = intIdEstablecimiento _
                             And n.codigoNumeracion = strModulo _
                             Select n).ToList
    End Function

    Public Function GenerarNumero(strIdEmpresa As String, IntIdEstablecimiento As Integer, TipoDoc As String,
                                  Serie As String) As Integer
        '   Dim objNuevo As New numeracionBoletas()
        Dim valor As Integer
        '   Dim rpta As String
        Try
            Using ts As New TransactionScope()

                'objNuevo = (From n In HeliosData.numeracionBoletas _
                '              Where n.empresa = strIdEmpresa And _
                '              n.establecimiento = IntIdEstablecimiento _
                '              And n.tipo = TipoDoc And _
                '              n.serie = Serie).First

                Dim objNuevo As numeracionBoletas = HeliosData.numeracionBoletas.Where(Function(o) o.empresa = strIdEmpresa _
                                                                                              And o.establecimiento = IntIdEstablecimiento _
                                                                                              And o.tipo = TipoDoc And _
                                                                                              o.serie = Serie).First

                With objNuevo
                    valor = .valorInicial
                    valor = CDec(valor) + 1
                    '  rpta = String.Format("{0:000000}", Convert.ToInt32(valor))
                    .valorInicial = valor 'String.Concat(rpta)
                    ' rpta = String.Concat(.codigoNumeracion, .valorInicial)
                    ' .empresa = strIdEmpresa
                    ' .establecimiento = IntIdEstablecimiento
                    ' .usuarioActualizacion = User
                    ' .fechaActualizacion = DateTimes
                End With
                'HeliosData.ObjectStateManager.GetObjectStateEntry(objNuevo).State.ToString()
                HeliosData.SaveChanges()
                ts.Complete()
                Return valor

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GenerarNumeroPorCodigo(CodigoNumeracion As String) As Integer
        Dim valor As Integer
        Try
            Using ts As New TransactionScope()
                Dim numeracion As numeracionBoletas = HeliosData.numeracionBoletas.Where(Function(o) o.codigoNumeracion = CodigoNumeracion).FirstOrDefault
                With numeracion
                    valor = .valorInicial
                    valor = CDec(valor) + 1
                    .valorInicial = valor 'String.Concat(rpta)
                End With
                'HeliosData.ObjectStateManager.GetObjectStateEntry(numeracion).State.ToString()
                HeliosData.SaveChanges()
                ts.Complete()
                Return valor
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GenerarNumeroPorCodigoEmpresa(CodigoNumeracion As String, empresa As String, tipodoc As String, intIdEstablecimiento As Integer) As numeracionBoletas
        Dim valor As Integer
        Try
            Using ts As New TransactionScope()
                Dim numeracion As numeracionBoletas = HeliosData.numeracionBoletas.Where(Function(o) o.codigoNumeracion = CodigoNumeracion And
                                                                                             o.empresa = empresa And
                                                                                             o.establecimiento = intIdEstablecimiento And
                                                                                             o.tipo = tipodoc).FirstOrDefault
                With numeracion
                    .serie = numeracion.serie
                    .serie1 = numeracion.serie1
                    valor = .valorInicial
                    valor = CDec(valor) + 1
                    .valorInicial = valor 'String.Concat(rpta)
                End With

                GenerarNumeroPorCodigoEmpresa = numeracion
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function GenerarNumeroPorID(intIdNumeracion As Integer) As Integer
        Dim valor As Integer
        Try
            Using ts As New TransactionScope()
                Dim numeracion As numeracionBoletas = HeliosData.numeracionBoletas.Where(Function(o) o.IdEnumeracion = intIdNumeracion).First
                With numeracion
                    valor = .valorInicial
                    valor = CDec(valor) + 1
                    .valorInicial = valor 'String.Concat(rpta)
                End With
                'HeliosData.ObjectStateManager.GetObjectStateEntry(numeracion).State.ToString()
                HeliosData.SaveChanges()
                ts.Complete()
                Return valor
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function GenerarNumeroAporte(strIdEmpresa As String, IntIdEstablecimiento As Integer, TipoDoc As String,
                                  Serie As String) As Integer
        '   Dim objNuevo As New numeracionBoletas()
        Dim valor As Integer
        '   Dim rpta As String
        Try
            Using ts As New TransactionScope()

                'objNuevo = (From n In HeliosData.numeracionBoletas _
                '              Where n.empresa = strIdEmpresa And _
                '              n.establecimiento = IntIdEstablecimiento _
                '              And n.tipo = TipoDoc And _
                '              n.serie = Serie).First

                Dim objNuevo As numeracionBoletas = HeliosData.numeracionBoletas.Where(Function(o) o.empresa = strIdEmpresa _
                                                                                              And o.establecimiento = IntIdEstablecimiento _
                                                                                              And o.codigoNumeracion = "APORT" _
                                                                                              And o.tipo = "VOU" And _
                                                                                              o.serie = Serie).First

                With objNuevo
                    valor = .valorInicial
                    valor = CDec(valor) + 1
                    '  rpta = String.Format("{0:000000}", Convert.ToInt32(valor))
                    .valorInicial = valor 'String.Concat(rpta)
                    ' rpta = String.Concat(.codigoNumeracion, .valorInicial)
                    ' .empresa = strIdEmpresa
                    ' .establecimiento = IntIdEstablecimiento
                    ' .usuarioActualizacion = User
                    ' .fechaActualizacion = DateTimes
                End With
                'HeliosData.ObjectStateManager.GetObjectStateEntry(objNuevo).State.ToString()
                HeliosData.SaveChanges()
                ts.Complete()
                Return valor

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerNumeracionEES(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strSerie As String) As List(Of numeracionBoletas)
        Return (From n In HeliosData.numeracionBoletas _
                               Where n.empresa = strIdEmpresa _
                               AndAlso n.establecimiento = intIdEstablecimiento _
                               AndAlso n.serie = strSerie _
                               Select n).ToList

    End Function


    Public Function InsertNumeracionXUnidOrg(ByVal numeracionBoletasBE As numeracionBoletas) As numeracionBoletas
        Try
            Dim numBoletas As New numeracionBoletas
            Using ts As New TransactionScope
                'numBoletas.IdEnumeracion = numeracionBoletasBE.IdEnumeracion
                numBoletas.codigoNumeracion = numeracionBoletasBE.codigoNumeracion
                numBoletas.tipo = numeracionBoletasBE.tipo
                numBoletas.serie = CStr(numeracionBoletasBE.serie + (numeracionBoletasBE.anclado)).PadRight(4, "0"c)
                numBoletas.valorInicial = numeracionBoletasBE.valorInicial
                numBoletas.empresa = numeracionBoletasBE.empresa
                numBoletas.establecimiento = numeracionBoletasBE.establecimiento
                numBoletas.valorMinimo = numeracionBoletasBE.valorMinimo
                numBoletas.valorMaximo = numeracionBoletasBE.valorMaximo
                numBoletas.incremento = numeracionBoletasBE.incremento

                numBoletas.tipo1 = numeracionBoletasBE.tipo1
                numBoletas.serie1 = numeracionBoletasBE.serie1
                numBoletas.valorInicial1 = numeracionBoletasBE.valorInicial1
                numBoletas.valorMinimo1 = numeracionBoletasBE.valorMinimo1
                numBoletas.valorMaximo1 = numeracionBoletasBE.valorMaximo1
                numBoletas.incremento1 = numeracionBoletasBE.incremento1
                numBoletas.tipoControl = numeracionBoletasBE.tipoControl
                numBoletas.anclado = numeracionBoletasBE.anclado
                numBoletas.usuarioActualizacion = numeracionBoletasBE.usuarioActualizacion
                numBoletas.fechaActualizacion = numeracionBoletasBE.fechaActualizacion

                HeliosData.numeracionBoletas.Add(numBoletas)
                HeliosData.SaveChanges()
                ts.Complete()
                numeracionBoletasBE.tipoModulo = numeracionBoletasBE.tipoModulo
                numeracionBoletasBE.IdEnumeracion = numBoletas.IdEnumeracion
            End Using
            Return numeracionBoletasBE
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function InsertsINGLE(ByVal numeracionBoletasBE As numeracionBoletas) As numeracionBoletas
        Try
            Dim numBoletas As New numeracionBoletas
            Using ts As New TransactionScope
                'numBoletas.IdEnumeracion = numeracionBoletasBE.IdEnumeracion
                numBoletas.codigoNumeracion = numeracionBoletasBE.codigoNumeracion
                numBoletas.tipo = numeracionBoletasBE.tipo
                numBoletas.serie = numeracionBoletasBE.serie
                numBoletas.valorInicial = numeracionBoletasBE.valorInicial
                numBoletas.empresa = numeracionBoletasBE.empresa
                numBoletas.establecimiento = numeracionBoletasBE.establecimiento
                numBoletas.valorMinimo = numeracionBoletasBE.valorMinimo
                numBoletas.valorMaximo = numeracionBoletasBE.valorMaximo
                numBoletas.incremento = numeracionBoletasBE.incremento

                numBoletas.tipo1 = numeracionBoletasBE.tipo1
                numBoletas.serie1 = numeracionBoletasBE.serie1
                numBoletas.valorInicial1 = numeracionBoletasBE.valorInicial1
                numBoletas.valorMinimo1 = numeracionBoletasBE.valorMinimo1
                numBoletas.valorMaximo1 = numeracionBoletasBE.valorMaximo1
                numBoletas.incremento1 = numeracionBoletasBE.incremento1
                numBoletas.tipoControl = numeracionBoletasBE.tipoControl
                numBoletas.anclado = numeracionBoletasBE.anclado
                numBoletas.usuarioActualizacion = numeracionBoletasBE.usuarioActualizacion
                numBoletas.fechaActualizacion = numeracionBoletasBE.fechaActualizacion

                HeliosData.numeracionBoletas.Add(numBoletas)
                HeliosData.SaveChanges()
                ts.Complete()
                numeracionBoletasBE.tipoModulo = numeracionBoletasBE.tipoModulo
                numeracionBoletasBE.IdEnumeracion = numBoletas.IdEnumeracion
            End Using
            Return numeracionBoletasBE
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Insert(ByVal numeracionBoletasBE As numeracionBoletas) As Integer
        Try
            Using ts As New TransactionScope

                If (numeracionBoletasBE.afectoUN = True) Then

                    Dim consulta As Integer = HeliosData.numeracionBoletas.Where(Function(o) _
                                                                                   o.empresa = numeracionBoletasBE.empresa And
                                                                                   o.establecimiento = numeracionBoletasBE.establecimiento And
                                                                                   o.codigoNumeracion = numeracionBoletasBE.codigoNumeracion And
                                                                                   o.tipo = numeracionBoletasBE.tipo And
                                                                                   o.serie = numeracionBoletasBE.serie).Count
                    If Not consulta > 0 Then
                        InsertsINGLE(numeracionBoletasBE)
                        HeliosData.SaveChanges()
                        ts.Complete()
                        Return numeracionBoletasBE.IdEnumeracion
                    Else
                        Throw New Exception("EL registro ingresado ya existe en la base datos, ingrese otro!")
                    End If
                Else
                    Dim consulta As Integer = HeliosData.numeracionBoletas.Where(Function(o) _
                                                                                  o.empresa = numeracionBoletasBE.empresa And
                                                                                  o.codigoNumeracion = numeracionBoletasBE.codigoNumeracion And
                                                                                  o.tipo = numeracionBoletasBE.tipo And
                                                                                  o.serie = numeracionBoletasBE.serie).Count
                    If Not consulta > 0 Then
                        InsertsINGLE(numeracionBoletasBE)
                        HeliosData.SaveChanges()
                        ts.Complete()
                        Return numeracionBoletasBE.IdEnumeracion
                    Else
                        Throw New Exception("EL registro ingresado ya existe en la base datos, ingrese otro!")
                    End If
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Sub Update(ByVal numeracionBoletasBE As numeracionBoletas)
        Using ts As New TransactionScope
            Dim numBoletas As numeracionBoletas = HeliosData.numeracionBoletas.Where(Function(o) _
                                            o.IdEnumeracion = numeracionBoletasBE.IdEnumeracion).First()

            numBoletas.codigoNumeracion = numeracionBoletasBE.codigoNumeracion
            numBoletas.tipo = numeracionBoletasBE.tipo
            numBoletas.serie = numeracionBoletasBE.serie
            numBoletas.valorInicial = numeracionBoletasBE.valorInicial
            numBoletas.empresa = numeracionBoletasBE.empresa
            numBoletas.establecimiento = numeracionBoletasBE.establecimiento
            numBoletas.valorMinimo = numeracionBoletasBE.valorMinimo
            numBoletas.valorMaximo = numeracionBoletasBE.valorMaximo
            numBoletas.incremento = numeracionBoletasBE.incremento
            numBoletas.anclado = numeracionBoletasBE.anclado
            numBoletas.usuarioActualizacion = numeracionBoletasBE.usuarioActualizacion
            numBoletas.fechaActualizacion = numeracionBoletasBE.fechaActualizacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(numBoletas).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub Delete(ByVal numeracionBoletasBE As numeracionBoletas)
        Dim consulta = HeliosData.numeracionBoletas.Where(Function(o) o.IdEnumeracion = numeracionBoletasBE.IdEnumeracion).First
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)
        HeliosData.SaveChanges()
    End Sub

    Public Function GetListar_numeracionBoletas() As List(Of numeracionBoletas)
        Return (From a In HeliosData.numeracionBoletas Select a).ToList
    End Function

    Public Function GetUbicar_numeracionBoletasPorID(IdEnumeracion As Integer) As numeracionBoletas
        Return (From a In HeliosData.numeracionBoletas
                Where a.IdEnumeracion = IdEnumeracion Select a).FirstOrDefault
    End Function

    Public Function GetUbicar_numeracionBoletasXUnidadNegocio(numeracionBoletasBE As numeracionBoletas) As numeracionBoletas
        Return (From a In HeliosData.numeracionBoletas
                Where a.empresa = numeracionBoletasBE.empresa And a.establecimiento = numeracionBoletasBE.establecimiento _
                And a.codigoNumeracion = numeracionBoletasBE.codigoNumeracion And
                    a.estado = numeracionBoletasBE.estado Select a).FirstOrDefault
    End Function

    Public Function GetTieneConfiguracion(strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strSerie As String) As Boolean
        Dim consulta = (From n In HeliosData.numeracionBoletas _
                               Where n.empresa = strIdEmpresa AndAlso _
                               n.establecimiento = intIdEstablecimiento _
                               AndAlso n.serie = strSerie).Count

        If consulta > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

#Region "ANCLADO NUMERACION POR DOC"
    Public Sub UpdatePredeterminadoAll(nNumeracionBE As numeracionBoletas)
        Using ts As New TransactionScope()
            PredeterminadoNullAll(nNumeracionBE) ' coloca otodos lo s item en :: 'N=NO ESTABLECIDO'
            UpdatePredeterminado(nNumeracionBE) ' ACTUALIZA UNA SERIE COMO PREDETERMINADA
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function UpdatePredeterminado(nNumeracionBE As numeracionBoletas) As Boolean

        Using ts As New TransactionScope()
            'objAlmacen = (From s In HeliosData.numeracionBoletas _
            '               Where s.empresa = nNumeracionBE.empresa _
            '               AndAlso s.establecimiento = nNumeracionBE.establecimiento _
            '               AndAlso s.serie = nNumeracionBE.serie AndAlso s.tipo = nNumeracionBE.tipo).First

            Dim numeracion As numeracionBoletas = HeliosData.numeracionBoletas.Where(Function(o) o.IdEnumeracion = nNumeracionBE.IdEnumeracion).First
            numeracion.anclado = nNumeracionBE.anclado
            HeliosData.SaveChanges()
            ts.Complete()
            Return True
        End Using

    End Function

    Public Function PredeterminadoNullAll(nNumeracionBE As numeracionBoletas) As Boolean
        Try
            Using ts As New TransactionScope
                Dim consulta = (From n In HeliosData.numeracionBoletas _
                               Where n.empresa = nNumeracionBE.empresa _
                               And n.establecimiento = nNumeracionBE.establecimiento _
                               And n.codigoNumeracion = nNumeracionBE.codigoNumeracion _
                               And n.tipo = nNumeracionBE.tipo).ToList

                For Each i In consulta
                    i.anclado = "N"
                Next
                HeliosData.SaveChanges()
                ts.Complete()
                Return True
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Public Function ObtenerNumeracionPredterminada(strIdEmpresa As String, intIdEstablecimiento As Integer, strComprobante As String, strTipoDoc As String) As numeracionBoletas
    '    Return (From n In HeliosData.numeracionBoletas _
    '            Where n.empresa = strIdEmpresa _
    '            And n.establecimiento = intIdEstablecimiento _
    '            And n.codigoNumeracion = strComprobante _
    '            And n.tipo = strTipoDoc _
    '            And n.anclado = "S").FirstOrDefault
    'End Function

    Public Function ObtenerNumeracionPredterminada(strIdEmpresa As String, intIdEstablecimiento As Integer, strTipoDoc As String) As numeracionBoletas
        Return (From n In HeliosData.numeracionBoletas _
                Where n.empresa = strIdEmpresa _
                And n.establecimiento = intIdEstablecimiento _
                And n.tipo = strTipoDoc _
                And n.anclado = "S").FirstOrDefault
    End Function

    Public Function ObtenerAncladosPorComprobante(strIdEmpresa As String, intIdEstablecimiento As Integer, strComprobante As String) As List(Of numeracionBoletas)
        Return (From n In HeliosData.numeracionBoletas _
                Where n.empresa = strIdEmpresa _
                And n.establecimiento = intIdEstablecimiento _
                And n.codigoNumeracion = strComprobante _
                And n.anclado = "S").ToList
    End Function
#End Region

    Public Function GetListar_numeracionBoletasAll(numeracionBoletasBE As numeracionBoletas) As List(Of numeracionBoletas)
        Try
            Dim numeracionBol As numeracionBoletas
            Dim listaNumeracionBoleta As New List(Of numeracionBoletas)

            Dim consulta = (From a In HeliosData.numeracionBoletas).ToList


            If (Not IsNothing(consulta)) Then
                For Each item In consulta
                    numeracionBol = New numeracionBoletas With {
                        .[IdEnumeracion] = item.[IdEnumeracion],
                        .[codigoNumeracion] = item.[codigoNumeracion],
                    .[tipo] = item.[tipo],
                    .[serie] = item.[serie],
                    .[valorInicial] = item.[valorInicial],
                    .[empresa] = item.[empresa],
                    .[establecimiento] = item.[establecimiento],
                    .[valorMinimo] = item.[valorMinimo],
                    .[valorMaximo] = item.[valorMaximo],
                    .[incremento] = item.[incremento],
                    .[anclado] = item.[anclado],
                    .[tipo1] = item.[tipo1],
                    .[serie1] = item.[serie1],
                    .[valorInicial1] = item.[valorInicial1],
                    .[valorMinimo1] = item.[valorMinimo1],
                    .[valorMaximo1] = item.[valorMaximo1],
                    .[incremento1] = item.[incremento1],
                    .[estado] = item.[estado],
                    .[usuarioActualizacion] = item.[usuarioActualizacion],
                    .[fechaActualizacion] = item.[fechaActualizacion]
                    }

                    listaNumeracionBoleta.Add(numeracionBol)

                Next
            End If

            Return listaNumeracionBoleta

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function GetListar_numeracionBoletasXCargo(numeracionBoletasBE As numeracionBoletas) As List(Of numeracionBoletas)
        Try
            Dim numeracionBol As numeracionBoletas
            Dim listaNumeracionBoleta As New List(Of numeracionBoletas)
            Dim distribucionLista As New List(Of distribucionNumeracionAO)
            Dim distribucionBL As New distribucionNumeracionAOBL
            Dim estadoNumeracion As Boolean = False
            Dim consulta = (From a In HeliosData.numeracionBoletas Join x In HeliosData.moduloConfiguracion On
                                                                       a.codigoNumeracion Equals x.idModulo Where a.empresa = numeracionBoletasBE.empresa _
                                                                                                                And a.establecimiento = numeracionBoletasBE.establecimiento).ToList


            distribucionLista = (From a In HeliosData.distribucionNumeracionAO Where a.idCargo = numeracionBoletasBE.idCargo).ToList


            If (Not IsNothing(consulta)) Then
                For Each item In consulta

                    If ((distribucionLista.Where(Function(o) o.IdEnumeracion = item.a.[IdEnumeracion]).Count > 0)) Then
                        estadoNumeracion = True
                    Else
                        estadoNumeracion = False
                    End If

                    numeracionBol = New numeracionBoletas With {
                    .[IdEnumeracion] = item.a.[IdEnumeracion],
                    .[codigoNumeracion] = item.a.[codigoNumeracion],
                    .[tipo] = item.a.[tipo],
                    .[serie] = item.a.[serie],
                    .[valorInicial] = item.a.[valorInicial],
                    .[estado] = item.a.[estado],
                    .descripcionModulo = item.x.descripcionModulo,
                    .estadoNumeracion = estadoNumeracion
                    }

                    listaNumeracionBoleta.Add(numeracionBol)

                Next
            End If

            Return listaNumeracionBoleta

        Catch ex As Exception
            Throw ex
        End Try

    End Function


End Class
