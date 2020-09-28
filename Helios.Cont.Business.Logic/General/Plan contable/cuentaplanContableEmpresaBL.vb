Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class cuentaplanContableEmpresaBL
    Inherits BaseBL

    Public Function CuentasCostoGastoSinModulo(ByVal strIdEmpresa As String) As List(Of cuentaplanContableEmpresa)
        Dim lista As New List(Of cuentaplanContableEmpresa)
        Dim item As New cuentaplanContableEmpresa
        Dim ICuenta = (From s In HeliosData.cuentaplanContableEmpresa _
                                          Where s.idEmpresa = strIdEmpresa _
                                          And Not (New String() {"61", "62", "63", "64", "65", "66", "67", "68"}).Contains(s.cuenta.Substring(1 - 1, 2)) _
                                          Order By s.cuenta _
                                          Select New With {.cuenta = s.cuenta,
                                                           .descripcion = s.cuenta & " - " & s.descripcion}).ToList


        Dim x As Integer = 0
        For Each i In ICuenta
            item = New cuentaplanContableEmpresa
            item.cuenta = i.cuenta
            If i.cuenta.Length > 2 Then
                item.descripcion = Space(2) & "-" & i.descripcion
            Else
                item.descripcion = i.descripcion
            End If
            lista.Add(item)
            'x = i.cuenta.Length
        Next

        Return lista
    End Function

    Public Sub InsertarListaDeCuentasV2(ListaCuentas As List(Of cuentaplanContableEmpresa), idCosto As Integer, idEnu As Integer)

        Dim numeracionBL As New numeracionBoletasBL
        Dim cval As Integer
        cval = Convert.ToInt32(numeracionBL.GenerarNumeroPorID(idEnu))

        Using ts As New TransactionScope
            For Each i In ListaCuentas
                i.idCosto = idCosto
                i.cuenta = i.cuenta & cval

                GrabarCuenta(i)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Function CuentasServicios(strEmpresa As String) As List(Of cuentaplanContableEmpresa)
        Dim objeto As New cuentaplanContableEmpresa
        Dim lista As New List(Of cuentaplanContableEmpresa)

        Dim consulta = (From det In HeliosData.cuentaplanContableEmpresa
                        Where det.idEmpresa = strEmpresa _
                        And (New String() {"63", "64", "65", "66", "67", "68"}).Contains(det.cuenta.Substring(1 - 1, 2))).ToList

        For Each i In consulta
            objeto = New cuentaplanContableEmpresa

            objeto.cuenta = i.cuenta
            objeto.descripcion = i.descripcion

            lista.Add(objeto)
        Next

        Return lista

    End Function

    Function LoadEstructuraLibroDiario(ByVal strEmpresa As String, ByVal strPeriodo As String) As List(Of cuentaplanContableEmpresa)
        Dim obj As New cuentaplanContableEmpresa
        Dim listaCuenta As New List(Of cuentaplanContableEmpresa)


        Try
            Dim lista = (From s In HeliosData.cuentaplanContableEmpresa
                         Where s.idEmpresa = strEmpresa).ToList

            For Each i In lista
                obj = New cuentaplanContableEmpresa
                obj.cuenta = i.cuenta
                obj.descripcion = i.descripcion
                listaCuenta.Add(obj)
            Next

            Return listaCuenta
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Function LoadCuentasConcepto(ByVal strEmpresa As String) As List(Of cuentaplanContableEmpresa)
        Dim obj As New cuentaplanContableEmpresa
        Dim listaCuenta As New List(Of cuentaplanContableEmpresa)
        Dim Cuentas As New List(Of String)
        Cuentas.Add("30")
        Cuentas.Add("31")
        Cuentas.Add("32")
        Cuentas.Add("33")
        Cuentas.Add("34")
        Cuentas.Add("35")
        Cuentas.Add("38")

        Try
            'Dim lista = (From s In HeliosData.cuentaplanContableEmpresa _
            '                              Where s.idEmpresa = strEmpresa _
            '                              And Cuentas.Contains(s.cuentaPadre) _
            '                              Order By s.cuenta _
            '                              Select New With {.cuenta = s.cuenta, .descripcion = s.descripcion}).ToList
            Dim lista = (From s In HeliosData.cuentaplanContableEmpresa _
                                          Where s.idEmpresa = strEmpresa _
                                          Order By s.cuenta _
                                          Select New With {.cuenta = s.cuenta, .descripcion = s.descripcion}).ToList

            For Each i In lista
                obj = New cuentaplanContableEmpresa
                obj.cuenta = i.cuenta
                obj.descripcion = String.Concat(i.cuenta, " - ", i.descripcion)
                listaCuenta.Add(obj)
            Next

            Return listaCuenta
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ObtenerMaxCuentabyCuenta(be As cuentaplanContableEmpresa) As cuentaplanContableEmpresa
        Dim obj As New cuentaplanContableEmpresa

        Dim consuta2 = (From CuentaplanContableEmpresa In _
                       (From CuentaplanContableEmpresa In HeliosData.cuentaplanContableEmpresa _
                        Where
                        CuentaplanContableEmpresa.cuentaPadre = be.cuentaPadre And _
                        CuentaplanContableEmpresa.idEmpresa = be.idEmpresa _
                        Select
                        idEmpresa = CuentaplanContableEmpresa.idEmpresa,
                        cuenta = CuentaplanContableEmpresa.cuenta,
                        cuentaPadre = CuentaplanContableEmpresa.cuentaPadre,
                        descripcion = CuentaplanContableEmpresa.descripcion,
                        Observaciones = CuentaplanContableEmpresa.Observaciones,
                        usuarioModificacion = CuentaplanContableEmpresa.usuarioModificacion,
                        fechaModificacion = CuentaplanContableEmpresa.fechaModificacion,
        Dummy = "x"
                        )
                    Group CuentaplanContableEmpresa By CuentaplanContableEmpresa.Dummy Into g = Group
                    Select New With {
                        .Column1 = g.Max(Function(p) p.cuenta)
                    }).FirstOrDefault


        obj = New cuentaplanContableEmpresa
        obj.cuenta = consuta2.Column1

        Return obj
    End Function

    Public Sub InsertarListaDeCuentas(ListaCuentas As List(Of cuentaplanContableEmpresa))
        Using ts As New TransactionScope
            For Each i In ListaCuentas
                GrabarCuenta(i)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function CuentaExistenteEnBD(cuentaBE As cuentaplanContableEmpresa) As Boolean
        Dim consulta = (From n In HeliosData.cuentaplanContableEmpresa _
                       Where n.idEmpresa = cuentaBE.idEmpresa And _
                       n.cuenta = cuentaBE.cuenta).FirstOrDefault

        If Not IsNothing(consulta) Then ' si existe ne la BD
            Return True
        Else
            Return False
        End If
    End Function

    Function LoadCuentasActivoInm(ByVal strEmpresa As String) As List(Of cuentaplanContableEmpresa)
        Dim obj As New cuentaplanContableEmpresa
        Dim listaCuenta As New List(Of cuentaplanContableEmpresa)
        Dim Cuentas As New List(Of String)
        Cuentas.Add("30")
        Cuentas.Add("31")
        Cuentas.Add("32")
        Cuentas.Add("33")
        Cuentas.Add("34")
        Cuentas.Add("35")
        Cuentas.Add("38")

        Try
            Dim lista = (From s In HeliosData.cuentaplanContableEmpresa _
                                          Where s.idEmpresa = strEmpresa _
                                          And Cuentas.Contains(s.cuentaPadre) _
                                          Order By s.cuenta _
                                          Select New With {.cuenta = s.cuenta, .descripcion = s.descripcion}).ToList

            For Each i In lista
                obj = New cuentaplanContableEmpresa
                obj.cuenta = i.cuenta
                obj.descripcion = String.Concat(i.cuenta, " - ", i.descripcion)
                listaCuenta.Add(obj)
            Next

            Return listaCuenta
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ListarCuentasPorPadreDescrip(strEmpresa As String, strCuenta As String) As List(Of cuentaplanContableEmpresa)

        Dim lista As New List(Of cuentaplanContableEmpresa)
        Dim item As New cuentaplanContableEmpresa
        Dim ICuenta = (From s In HeliosData.cuentaplanContableEmpresa _
                                          Where s.idEmpresa = strEmpresa _
                                          And s.cuentaPadre = strCuenta _
                                          Order By s.cuenta _
                                          Select New With {.cuenta = s.cuenta,
                                                           .descripcion = s.cuenta & " - " & s.descripcion}).ToList

        Dim x As Integer = 0
        For Each i In ICuenta
            item = New cuentaplanContableEmpresa
            item.cuenta = i.cuenta
            If i.cuenta.Length > 2 Then
                item.descripcion = Space(2) & "-" & i.descripcion
            Else
                item.descripcion = i.descripcion
            End If
            lista.Add(item)

        Next

        Return lista

    End Function

    Function LoadCuentasGastos(ByVal strEmpresa As String) As List(Of cuentaplanContableEmpresa)
        Dim Cuentas As New List(Of String)
        Cuentas.Add("18")
        Cuentas.Add("37")
        Cuentas.Add("63")
        Cuentas.Add("64")
        Cuentas.Add("65")
        '  Cuentas.Add("66")
        Cuentas.Add("67")
        Cuentas.Add("68")
        '   Cuentas.Add("69")
        Try
            Return (From s In HeliosData.cuentaplanContableEmpresa _
                                          Where s.idEmpresa = strEmpresa _
                                          And Cuentas.Contains(s.cuenta) _
                                          Order By s.cuenta _
                                          Select s).ToList
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Function LoadCuentasGastosPadre(ByVal strEmpresa As String) As List(Of cuentaplanContableEmpresa)
        Dim obj As New cuentaplanContableEmpresa
        Dim listaCuenta As New List(Of cuentaplanContableEmpresa)
        Dim Cuentas As New List(Of String)
        Cuentas.Add("18")
        Cuentas.Add("37")
        Cuentas.Add("63")
        Cuentas.Add("64")
        Cuentas.Add("65")

        Cuentas.Add("67")
        Cuentas.Add("68")

        Try
            Dim lista = (From s In HeliosData.cuentaplanContableEmpresa _
                                          Where s.idEmpresa = strEmpresa _
                                          And Cuentas.Contains(s.cuentaPadre) _
                                          Order By s.cuenta _
                                          Select New With {.cuenta = s.cuenta, .descripcion = s.descripcion}).ToList

            For Each i In lista
                obj = New cuentaplanContableEmpresa
                obj.cuenta = i.cuenta
                obj.descripcion = String.Concat(i.cuenta, " - ", i.descripcion)
                listaCuenta.Add(obj)
            Next

            Return listaCuenta
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Function LoadCuentasPagoHonorarios(ByVal strEmpresa As String) As List(Of cuentaplanContableEmpresa)
        Dim Cuentas As New List(Of String)
        
        Cuentas.Add("63")
        Cuentas.Add("65")
        Try
            Return (From s In HeliosData.cuentaplanContableEmpresa _
                                          Where s.idEmpresa = strEmpresa _
                                          And Cuentas.Contains(s.cuenta) _
                                          Order By s.cuenta _
                                          Select s).ToList
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Function LoadCuentasServicios(ByVal strEmpresa As String) As List(Of cuentaplanContableEmpresa)
        Dim Cuentas As New List(Of String)

        Cuentas.Add("7041")
        Cuentas.Add("7042")
        Try
            Return (From s In HeliosData.cuentaplanContableEmpresa _
                                          Where s.idEmpresa = strEmpresa _
                                          And Cuentas.Contains(s.cuenta) _
                                          Order By s.cuenta _
                                          Select s).ToList
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub GrabarCuenta(cuenta As cuentaplanContableEmpresa)
        Try
            Using ts As New TransactionScope
                Dim consulta = (From n In HeliosData.cuentaplanContableEmpresa
                                Where n.idEmpresa = cuenta.idEmpresa And n.cuenta = cuenta.cuenta).Count

                If consulta > 0 Then
                    Throw New Exception("Está cuenta ya se encuentra registrada, ingrese otro porfavor.!")
                Else
                    InsertCostos(cuenta)
                    HeliosData.SaveChanges()
                    ts.Complete()
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Insert(ByVal cuentaBE As cuentaplanContableEmpresa)
        Dim cuenta As New cuentaplanContableEmpresa
        Using ts As New TransactionScope

            cuenta = New cuentaplanContableEmpresa With
                {
                    .idEmpresa = cuentaBE.idEmpresa,
                    .cuenta = cuentaBE.cuenta,
                    .cuentaPadre = cuentaBE.cuentaPadre,
                    .descripcion = cuentaBE.descripcion,
                    .Observaciones = cuentaBE.Observaciones,
                    .usuarioModificacion = cuentaBE.usuarioModificacion,
                    .fechaModificacion = cuentaBE.fechaModificacion
                }

            HeliosData.cuentaplanContableEmpresa.Add(cuenta)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub InsertCostos(ByVal cuentaBE As cuentaplanContableEmpresa)
        Dim cuenta As New cuentaplanContableEmpresa
        Using ts As New TransactionScope

            cuenta = New cuentaplanContableEmpresa With
                {
                    .idEmpresa = cuentaBE.idEmpresa,
                    .cuenta = cuentaBE.cuenta,
                    .cuentaPadre = cuentaBE.cuentaPadre,
                    .descripcion = cuentaBE.NomCosto,
                    .Observaciones = cuentaBE.Observaciones,
                    .usuarioModificacion = cuentaBE.usuarioModificacion,
                    .fechaModificacion = cuentaBE.fechaModificacion,
                    .idCosto = cuentaBE.idCosto
                }

            HeliosData.cuentaplanContableEmpresa.Add(cuenta)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub EditarCuenta(ByVal cuentaBE As cuentaplanContableEmpresa)
        Dim cuenta As New cuentaplanContableEmpresa
        Using ts As New TransactionScope
            Dim cuentaMod = (From n In HeliosData.cuentaplanContableEmpresa _
                            Where n.idEmpresa = cuentaBE.idEmpresa _
                            And n.cuenta = cuentaBE.cuenta).FirstOrDefault

            cuentaMod.idEmpresa = cuentaBE.idEmpresa
            cuentaMod.cuenta = cuentaBE.cuenta
            cuentaMod.cuentaPadre = cuentaBE.cuentaPadre
            cuentaMod.descripcion = cuentaBE.descripcion
            cuentaMod.Observaciones = cuentaBE.Observaciones
            cuentaMod.usuarioModificacion = cuentaBE.usuarioModificacion
            cuentaMod.fechaModificacion = cuentaBE.fechaModificacion
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub EliminarCuenta(ByVal cuentaBE As cuentaplanContableEmpresa)
        Dim cuenta As New cuentaplanContableEmpresa
        Using ts As New TransactionScope
            Dim consulta = (From n In HeliosData.cuentaplanContableEmpresa _
                            Where n.idEmpresa = cuentaBE.idEmpresa _
                            And n.cuenta = cuentaBE.cuenta).FirstOrDefault

            If Not IsNothing(consulta) Then
                CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)
            End If

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub Update(ByVal cuentaBE As cuentaplanContableEmpresa)
        Using ts As New TransactionScope
            HeliosData.cuentaplanContableEmpresa.Attach(cuentaBE)
            HeliosData.Entry(cuentaBE).State = System.Data.Entity.EntityState.Modified
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function ObtenerCuentasConf(strEmpresa As String, strCuenta As String) As List(Of cuentaplanContableEmpresa)
        Dim ICuenta = (From s In HeliosData.cuentaplanContableEmpresa _
                                      Where s.idEmpresa = strEmpresa _
                                      And s.cuenta.StartsWith(strCuenta) _
                                      Order By s.cuenta _
                                      Select s).ToList

        Return ICuenta
    End Function

    Public Function ListarCuentasPorPadre(strEmpresa As String, strCuenta As String) As List(Of cuentaplanContableEmpresa)
        Return (From s In HeliosData.cuentaplanContableEmpresa _
                                          Where s.idEmpresa = strEmpresa _
                                          And s.cuentaPadre = strCuenta _
                                          Order By s.cuenta _
                                          Select s).ToList

    End Function

    Public Function ObtenerCuentasPorEmpresa(ByVal strIdEmpresa As String) As List(Of cuentaplanContableEmpresa)
        Dim ICuenta = (From s In HeliosData.cuentaplanContableEmpresa _
                                          Where s.idEmpresa = strIdEmpresa _
                                          Order By s.cuenta _
                                          Select s).ToList

        Return ICuenta
    End Function


    Public Function ObtenerCuentasPorEmpresaEscalable(ByVal strIdEmpresa As String) As List(Of cuentaplanContableEmpresa)
        Dim lista As New List(Of cuentaplanContableEmpresa)
        Dim item As New cuentaplanContableEmpresa
        Dim ICuenta = (From s In HeliosData.cuentaplanContableEmpresa _
                                          Where s.idEmpresa = strIdEmpresa _
                                          Order By s.cuenta _
                                          Select New With {.cuenta = s.cuenta,
                                                           .descripcion = s.cuenta & " - " & s.descripcion}).ToList


        Dim x As Integer = 0
        For Each i In ICuenta
            item = New cuentaplanContableEmpresa
            item.cuenta = i.cuenta
            If i.cuenta.Length > 2 Then
                item.descripcion = Space(2) & "-" & i.descripcion
            Else
                item.descripcion = i.descripcion
            End If
            lista.Add(item)
            'x = i.cuenta.Length
        Next

        Return lista
    End Function

    Public Function ObtenerCuentasPorEmpresaEscalableV2(ByVal strIdEmpresa As String) As List(Of cuentaplanContableEmpresa)
        Dim lista As New List(Of cuentaplanContableEmpresa)
        Dim item As New cuentaplanContableEmpresa
        Dim ICuenta = (From s In HeliosData.cuentaplanContableEmpresa _
                                          Where s.idEmpresa = strIdEmpresa _
                                          Order By s.cuenta _
                                          Select New With {.cuenta = s.cuenta,
                                                           .descripcion = s.cuenta & " - " & s.descripcion}).ToList


        Dim x As Integer = 0
        For Each i In ICuenta
            item = New cuentaplanContableEmpresa
            item.cuenta = i.cuenta
            item.descripcion = i.descripcion
            lista.Add(item)
        Next

        Return lista
    End Function

    Public Function ObtenerCuentaPorID(strEmpresa As String, strCuenta As String) As cuentaplanContableEmpresa
        Return (From s In HeliosData.cuentaplanContableEmpresa _
                                      Where s.idEmpresa = strEmpresa _
                                      And s.cuenta = (strCuenta)).FirstOrDefault

    End Function

End Class
