Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class listadoPreciosBL
    Inherits BaseBL

    Public Function GetUbicar_PrecioExistente(Codigo As Integer) As listadoPrecios
        Try
            Dim valor As Decimal
            valor = 1
            Return (From a In HeliosData.listadoPrecios _
                    Where a.idItem = Codigo _
                     And a.idEmpresa = Gempresas.IdEmpresaRuc _
                    And a.idEstablecimiento = GEstableciento.IdEstablecimiento _
                    And a.vcmenor >= valor).First
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub GrabarPrecioEntrada(documentoCompra As documentocompradetalle)
        Dim precio As New listadoPrecios
        Dim consulta As listadoPrecios
        Try
            consulta = HeliosData.listadoPrecios.Where(Function(o) o.idEmpresa = documentoCompra.IdEmpresa And _
                                                                                 o.idEstablecimiento = documentoCompra.IdEstablecimiento And _
                                                                                 o.idItem = documentoCompra.idItem And _
                                                                                 o.destinoGravado = documentoCompra.destino And o.porcUtimenor = documentoCompra.porcUtimenor _
                                                                                 And o.porcUtimayor = documentoCompra.porcUtimayor _
                                                                                 And o.porcUtigranmayor = documentoCompra.porcUtigranMayor _
                                                                                 And o.fecha = documentoCompra.FechaDoc).FirstOrDefault

            Using ts As New TransactionScope
                precio = New listadoPrecios
                If IsNothing(consulta) Then

                    precio.idEmpresa = documentoCompra.IdEmpresa
                    precio.idEstablecimiento = documentoCompra.IdEstablecimiento
                    precio.tipoExistencia = documentoCompra.tipoExistencia
                    precio.destinoGravado = documentoCompra.destino
                    precio.idItem = documentoCompra.idItem
                    precio.descripcion = documentoCompra.descripcionItem
                    precio.fecha = documentoCompra.FechaDoc
                    precio.tipoConfiguracion = "P"
                    precio.presentacion = documentoCompra.unidad2
                    precio.unidad = documentoCompra.unidad1
                    'CALCULO
                    precio.porcUtimenor = documentoCompra.porcUtimenor

                    Dim colMontoUtiMenor As Decimal = 0
                    Dim colMontoUtiMenorME As Decimal = 0

                    Dim colValorVentaMenor As Decimal = 0
                    Dim colValorVentaMenorME As Decimal = 0

                    Dim costoUnitVC As Decimal = 0
                    Dim costoUnitVCme As Decimal = 0
                    Select Case documentoCompra.tipoCompra
                        Case TIPO_COMPRA.OTRAS_ENTRADAS

                            costoUnitVC = Math.Round(CDbl(documentoCompra.importe) / CDbl(documentoCompra.monto1), 2)
                            costoUnitVCme = Math.Round(CDbl(documentoCompra.importeUS) / CDbl(documentoCompra.monto1), 2)

                            precio.vcmenor = costoUnitVC
                            precio.vcmenorme = costoUnitVCme


                            colMontoUtiMenor = Math.Round(CDbl(costoUnitVC) * (CDbl(documentoCompra.porcUtimenor) / 100), 2)
                            colMontoUtiMenorME = Math.Round(CDbl(costoUnitVCme) * (CDbl(documentoCompra.porcUtimenor) / 100), 2)

                            colValorVentaMenor = CDbl(costoUnitVC) + colMontoUtiMenor
                            colValorVentaMenorME = CDbl(costoUnitVCme) + colMontoUtiMenorME
                        Case Else

                            costoUnitVC = Math.Round(CDbl(documentoCompra.montokardex) / CDbl(documentoCompra.monto1), 2)
                            costoUnitVCme = Math.Round(CDbl(documentoCompra.montokardexUS) / CDbl(documentoCompra.monto1), 2)

                            precio.vcmenor = costoUnitVC
                            precio.vcmenorme = costoUnitVCme

                            colMontoUtiMenor = Math.Round(costoUnitVC * (CDbl(documentoCompra.porcUtimenor) / 100), 2)
                            colMontoUtiMenorME = Math.Round(costoUnitVCme * (CDbl(documentoCompra.porcUtimenor) / 100), 2)

                            colValorVentaMenor = CDbl(costoUnitVC) + colMontoUtiMenor
                            colValorVentaMenorME = CDbl(costoUnitVCme) + colMontoUtiMenorME
                    End Select

                    Select Case documentoCompra.destino

                        Case "2"
                            Dim colIgvMenor As Decimal = 0
                            Dim colIgvMenorME As Decimal = 0

                            Dim colPrecioVentaMenor As Decimal = colValorVentaMenor + colIgvMenor
                            Dim colPrecioVentaMenorME As Decimal = colValorVentaMenorME + colIgvMenorME

                            Dim b As Decimal = 0
                            Dim b1 As Decimal = 0
                            b = colPrecioVentaMenor - Int(colPrecioVentaMenor)
                            b1 = colPrecioVentaMenorME - Int(colPrecioVentaMenorME)
                            Dim s = b.ToString.Replace("0.", "")
                            Dim s1 = b1.ToString.Replace("0.", "")
                            Dim x = Mid(s, 1, 1) & "0"
                            Dim x1 = Mid(s1, 1, 1) & "0"
                            If s > x Then
                                Dim z = CDbl(x) + 10
                                'Dim zz = Int(a).ToString
                                Dim zzz = Int(z).ToString
                                If z = 100 Then
                                    Dim zzzz = Int(colPrecioVentaMenor) + 1 & "." & 0
                                    Dim resultMN = CDbl(zzzz)
                                    colPrecioVentaMenor = resultMN
                                Else
                                    Dim zzzz = Int(colPrecioVentaMenor).ToString & "." & zzz
                                    Dim resultMN = CDbl(zzzz)
                                    '    MsgBox(resultMN)
                                    colPrecioVentaMenor = resultMN
                                End If

                            End If

                            If s1 > x1 Then
                                Dim z1 = CDbl(x1) + 10
                                'Dim zz = Int(a).ToString
                                Dim zzz1 = Int(z1).ToString
                                If z1 = 100 Then
                                    Dim zzzz1 = Int(colPrecioVentaMenorME) + 1 & "." & 0
                                    Dim resultMe = CDbl(zzzz1)
                                    colPrecioVentaMenorME = resultMe
                                Else
                                    Dim zzzz1 = Int(colPrecioVentaMenorME).ToString & "." & zzz1
                                    Dim resultME = CDbl(zzzz1)
                                    colPrecioVentaMenorME = resultME
                                End If
                                '    MsgBox(resultMN)
                            End If

                            precio.montoUtimenor = colMontoUtiMenor
                            precio.montoUtimenorme = colMontoUtiMenorME

                            precio.vvmenor = colValorVentaMenor
                            precio.vvmenorme = colValorVentaMenorME

                            precio.igvmenor = colIgvMenor
                            precio.igvmenormeme = colIgvMenorME

                            precio.pvmenor = colPrecioVentaMenor
                            precio.pvmenorme = colPrecioVentaMenorME

                        Case Else
                            Dim colIgvMenor As Decimal = Math.Round(colValorVentaMenor * (18 / 100), 2)
                            Dim colIgvMenorME As Decimal = Math.Round(colValorVentaMenorME * (18 / 100), 2)

                            Dim colPrecioVentaMenor As Decimal = colValorVentaMenor + colIgvMenor
                            Dim colPrecioVentaMenorME As Decimal = colValorVentaMenorME + colIgvMenorME

                            Dim b As Decimal = 0
                            Dim b1 As Decimal = 0
                            b = colPrecioVentaMenor - Int(colPrecioVentaMenor)
                            b1 = colPrecioVentaMenorME - Int(colPrecioVentaMenorME)
                            Dim s = b.ToString.Replace("0.", "")
                            Dim s1 = b1.ToString.Replace("0.", "")
                            Dim x = Mid(s, 1, 1) & "0"
                            Dim x1 = Mid(s1, 1, 1) & "0"
                            If s > x Then
                                Dim z = CDbl(x) + 10
                                'Dim zz = Int(a).ToString
                                Dim zzz = Int(z).ToString
                                If z = 100 Then
                                    Dim zzzz = Int(colPrecioVentaMenor) + 1 & "." & 0
                                    Dim resultMN = CDbl(zzzz)
                                    colPrecioVentaMenor = resultMN
                                Else
                                    Dim zzzz = Int(colPrecioVentaMenor).ToString & "." & zzz
                                    Dim resultMN = CDbl(zzzz)
                                    '    MsgBox(resultMN)
                                    colPrecioVentaMenor = resultMN
                                End If

                            End If

                            If s1 > x1 Then
                                Dim z1 = CDbl(x1) + 10
                                'Dim zz = Int(a).ToString
                                Dim zzz1 = Int(z1).ToString
                                If z1 = 100 Then
                                    Dim zzzz1 = Int(colPrecioVentaMenorME) + 1 & "." & 0
                                    Dim resultMe = CDbl(zzzz1)
                                    colPrecioVentaMenorME = resultMe
                                Else
                                    Dim zzzz1 = Int(colPrecioVentaMenorME).ToString & "." & zzz1
                                    Dim resultME = CDbl(zzzz1)
                                    colPrecioVentaMenorME = resultME
                                End If
                                '    MsgBox(resultMN)
                            End If

                            precio.montoUtimenor = colMontoUtiMenor
                            precio.montoUtimenorme = colMontoUtiMenorME

                            precio.vvmenor = colValorVentaMenor
                            precio.vvmenorme = colValorVentaMenorME

                            precio.igvmenor = colIgvMenor
                            precio.igvmenormeme = colIgvMenorME

                            precio.pvmenor = colPrecioVentaMenor
                            precio.pvmenorme = colPrecioVentaMenorME
                    End Select

                 

            
                    '----------------------------------------------------------------------------
                    precio.porcUtimayor = documentoCompra.porcUtimayor
                    Dim colMontoUtiMayor As Decimal = 0
                    Dim colMontoUtiMayorME As Decimal = 0

                    Dim colValorVentaMayor As Decimal = 0
                    Dim colValorVentaMayorME As Decimal = 0

                    Dim costoUnitmyVC As Decimal = 0
                    Dim costoUnitmyVCme As Decimal = 0

                    Select Case documentoCompra.tipoCompra
                        Case TIPO_COMPRA.OTRAS_ENTRADAS

                            costoUnitmyVC = Math.Round(CDbl(documentoCompra.importe) / CDbl(documentoCompra.monto1), 2)
                            costoUnitmyVCme = Math.Round(CDbl(documentoCompra.importeUS) / CDbl(documentoCompra.monto1), 2)

                            precio.vcmayor = costoUnitmyVC
                            precio.vcmayorme = costoUnitmyVCme

                            colMontoUtiMayor = Math.Round(CDbl(costoUnitmyVC) * (CDbl(documentoCompra.porcUtimayor) / 100), 2)
                            colMontoUtiMayorME = Math.Round(CDbl(costoUnitmyVCme) * (CDbl(documentoCompra.porcUtimayor) / 100), 2)

                            colValorVentaMayor = CDbl(costoUnitmyVC) + colMontoUtiMayor
                            colValorVentaMayorME = CDbl(costoUnitmyVCme) + colMontoUtiMayorME
                        Case Else

                            costoUnitmyVC = Math.Round(CDbl(documentoCompra.montokardex) / CDbl(documentoCompra.monto1), 2)
                            costoUnitmyVCme = Math.Round(CDbl(documentoCompra.montokardexUS) / CDbl(documentoCompra.monto1), 2)

                            precio.vcmayor = costoUnitmyVC
                            precio.vcmayorme = costoUnitmyVCme

                            colMontoUtiMayor = Math.Round(CDbl(costoUnitmyVC) * (CDbl(documentoCompra.porcUtimayor) / 100), 2)
                            colMontoUtiMayorME = Math.Round(CDbl(costoUnitmyVCme) * (CDbl(documentoCompra.porcUtimayor) / 100), 2)

                            colValorVentaMayor = CDbl(costoUnitmyVC) + colMontoUtiMayor
                            colValorVentaMayorME = CDbl(costoUnitmyVCme) + colMontoUtiMayorME
                    End Select


                      Select documentoCompra.destino

                        Case "2"
                            Dim colIgvMayor As Decimal = 0
                            Dim colIgvMayorME As Decimal = 0

                            Dim colPrecioVentaMayor As Decimal = colValorVentaMayor + colIgvMayor
                            Dim colPrecioVentaMayorME As Decimal = colValorVentaMayorME + colIgvMayorME

                            Dim b As Decimal = 0
                            Dim b1 As Decimal = 0
                            b = colPrecioVentaMayor - Int(colPrecioVentaMayor)
                            b1 = colPrecioVentaMayorME - Int(colPrecioVentaMayorME)
                            Dim s = b.ToString.Replace("0.", "")
                            Dim s1 = b1.ToString.Replace("0.", "")
                            Dim x = Mid(s, 1, 1) & "0"
                            Dim x1 = Mid(s1, 1, 1) & "0"
                            If s > x Then
                                Dim z = CDbl(x) + 10
                                'Dim zz = Int(a).ToString
                                Dim zzz = Int(z).ToString
                                If z = 100 Then
                                    Dim zzzz = Int(colPrecioVentaMayor) + 1 & "." & 0
                                    Dim resultMN = CDbl(zzzz)
                                    colPrecioVentaMayor = resultMN
                                Else
                                    Dim zzzz = Int(colPrecioVentaMayor).ToString & "." & zzz
                                    Dim resultMN = CDbl(zzzz)
                                    '    MsgBox(resultMN)
                                    colPrecioVentaMayor = resultMN
                                End If

                            End If

                            If s1 > x1 Then
                                Dim z1 = CDbl(x1) + 10
                                'Dim zz = Int(a).ToString
                                Dim zzz1 = Int(z1).ToString
                                If z1 = 100 Then
                                    Dim zzzz1 = Int(colPrecioVentaMayorME) + 1 & "." & 0
                                    Dim resultMe = CDbl(zzzz1)
                                    colPrecioVentaMayorME = resultMe
                                Else
                                    Dim zzzz1 = Int(colPrecioVentaMayorME).ToString & "." & zzz1
                                    Dim resultME = CDbl(zzzz1)
                                    colPrecioVentaMayorME = resultME
                                End If
                                '    MsgBox(resultMN)
                            End If

                            precio.montoUtimayor = colMontoUtiMayor
                            precio.montoUtimayorme = colMontoUtiMayorME

                            precio.vvmayor = colValorVentaMayor
                            precio.vvmayorme = colValorVentaMayorME

                            precio.igvmayor = colIgvMayor
                            precio.igvmayormeme = colIgvMayorME

                            precio.pvmayor = colPrecioVentaMayor
                            precio.pvmayorme = colPrecioVentaMayorME

                        Case Else
                            Dim colIgvMayor As Decimal = Math.Round(colValorVentaMayor * (18 / 100), 2)
                            Dim colIgvMayorME As Decimal = Math.Round(colValorVentaMayorME * (18 / 100), 2)

                            Dim colPrecioVentaMayor As Decimal = colValorVentaMayor + colIgvMayor
                            Dim colPrecioVentaMayorME As Decimal = colValorVentaMayorME + colIgvMayorME
                            Dim b As Decimal = 0
                            Dim b1 As Decimal = 0
                            b = colPrecioVentaMayor - Int(colPrecioVentaMayor)
                            b1 = colPrecioVentaMayorME - Int(colPrecioVentaMayorME)
                            Dim s = b.ToString.Replace("0.", "")
                            Dim s1 = b1.ToString.Replace("0.", "")
                            Dim x = Mid(s, 1, 1) & "0"
                            Dim x1 = Mid(s1, 1, 1) & "0"
                            If s > x Then
                                Dim z = CDbl(x) + 10
                                'Dim zz = Int(a).ToString
                                Dim zzz = Int(z).ToString
                                If z = 100 Then
                                    Dim zzzz = Int(colPrecioVentaMayor) + 1 & "." & 0
                                    Dim resultMN = CDbl(zzzz)
                                    colPrecioVentaMayor = resultMN
                                Else
                                    Dim zzzz = Int(colPrecioVentaMayor).ToString & "." & zzz
                                    Dim resultMN = CDbl(zzzz)
                                    '    MsgBox(resultMN)
                                    colPrecioVentaMayor = resultMN
                                End If

                            End If

                            If s1 > x1 Then
                                Dim z1 = CDbl(x1) + 10
                                'Dim zz = Int(a).ToString
                                Dim zzz1 = Int(z1).ToString
                                If z1 = 100 Then
                                    Dim zzzz1 = Int(colPrecioVentaMayorME) + 1 & "." & 0
                                    Dim resultMe = CDbl(zzzz1)
                                    colPrecioVentaMayorME = resultMe
                                Else
                                    Dim zzzz1 = Int(colPrecioVentaMayorME).ToString & "." & zzz1
                                    Dim resultME = CDbl(zzzz1)
                                    colPrecioVentaMayorME = resultME
                                End If
                                '    MsgBox(resultMN)
                            End If

                            precio.montoUtimayor = colMontoUtiMayor
                            precio.montoUtimayorme = colMontoUtiMayorME

                            precio.vvmayor = colValorVentaMayor
                            precio.vvmayorme = colValorVentaMayorME

                            precio.igvmayor = colIgvMayor
                            precio.igvmayormeme = colIgvMayorME

                            precio.pvmayor = colPrecioVentaMayor
                            precio.pvmayorme = colPrecioVentaMayorME
                    End Select


                    '----------------------------------------------------------------------------------------------
                    precio.porcUtigranmayor = documentoCompra.porcUtigranMayor

                    Dim colMontoUtiGranMayor As Decimal = 0
                    Dim colMontoUtiGranMayorME As Decimal = 0

                    Dim colValorVentaGranMayor As Decimal = 0
                    Dim colValorVentaGranMayorME As Decimal = 0

                    Dim costoUnitgmyVC As Decimal = 0
                    Dim costoUnitgmyVCme As Decimal = 0
                    Select Case documentoCompra.tipoCompra
                        Case TIPO_COMPRA.OTRAS_ENTRADAS

                            costoUnitgmyVC = Math.Round(CDbl(documentoCompra.importe) / CDbl(documentoCompra.monto1), 2)
                            costoUnitgmyVCme = Math.Round(CDbl(documentoCompra.importeUS) / CDbl(documentoCompra.monto1), 2)

                            precio.vcgranmayor = costoUnitgmyVC
                            precio.vcgranmayorme = costoUnitgmyVCme

                            colMontoUtiGranMayor = Math.Round(CDbl(costoUnitgmyVC) * (CDbl(documentoCompra.porcUtigranMayor) / 100), 2)
                            colMontoUtiGranMayorME = Math.Round(CDbl(costoUnitgmyVCme) * (CDbl(documentoCompra.porcUtigranMayor) / 100), 2)

                            colValorVentaGranMayor = CDbl(costoUnitgmyVC) + colMontoUtiGranMayor
                            colValorVentaGranMayorME = CDbl(costoUnitgmyVCme) + colMontoUtiGranMayorME
                        Case Else

                            costoUnitgmyVC = Math.Round(CDbl(documentoCompra.montokardex) / CDbl(documentoCompra.monto1), 2)
                            costoUnitgmyVCme = Math.Round(CDbl(documentoCompra.montokardexUS) / CDbl(documentoCompra.monto1), 2)

                            precio.vcgranmayor = costoUnitgmyVC
                            precio.vcgranmayorme = costoUnitgmyVCme

                            colMontoUtiGranMayor = Math.Round(CDbl(costoUnitgmyVC) * (CDbl(documentoCompra.porcUtigranMayor) / 100), 2)
                            colMontoUtiGranMayorME = Math.Round(CDbl(costoUnitgmyVCme) * (CDbl(documentoCompra.porcUtigranMayor) / 100), 2)

                            colValorVentaGranMayor = CDbl(costoUnitgmyVC) + colMontoUtiGranMayor
                            colValorVentaGranMayorME = CDbl(costoUnitgmyVCme) + colMontoUtiGranMayorME
                    End Select

                      Select documentoCompra.destino

                        Case "2"
                            Dim colIgvGranMayor As Decimal = 0
                            Dim colIgvGranMayorME As Decimal = 0

                            Dim colPrecioVentaGranMayor As Decimal = colValorVentaGranMayor + colIgvGranMayor
                            Dim colPrecioVentaGranMayorME As Decimal = colValorVentaGranMayorME + colIgvGranMayorME
                            Dim b As Decimal = 0
                            Dim b1 As Decimal = 0
                            b = colPrecioVentaGranMayor - Int(colPrecioVentaGranMayor)
                            b1 = colPrecioVentaGranMayorME - Int(colPrecioVentaGranMayorME)
                            Dim s = b.ToString.Replace("0.", "")
                            Dim s1 = b1.ToString.Replace("0.", "")
                            Dim x = Mid(s, 1, 1) & "0"
                            Dim x1 = Mid(s1, 1, 1) & "0"
                            If s > x Then
                                Dim z = CDbl(x) + 10
                                'Dim zz = Int(a).ToString
                                Dim zzz = Int(z).ToString
                                If z = 100 Then
                                    Dim zzzz = Int(colPrecioVentaGranMayor) + 1 & "." & 0
                                    Dim resultMN = CDbl(zzzz)
                                    colPrecioVentaGranMayor = resultMN
                                Else
                                    Dim zzzz = Int(colPrecioVentaGranMayor).ToString & "." & zzz
                                    Dim resultMN = CDbl(zzzz)
                                    '    MsgBox(resultMN)
                                    colPrecioVentaGranMayor = resultMN
                                End If

                            End If

                            If s1 > x1 Then
                                Dim z1 = CDbl(x1) + 10
                                'Dim zz = Int(a).ToString
                                Dim zzz1 = Int(z1).ToString
                                If z1 = 100 Then
                                    Dim zzzz1 = Int(colPrecioVentaGranMayorME) + 1 & "." & 0
                                    Dim resultMe = CDbl(zzzz1)
                                    colPrecioVentaGranMayorME = resultMe
                                Else
                                    Dim zzzz1 = Int(colPrecioVentaGranMayorME).ToString & "." & zzz1
                                    Dim resultME = CDbl(zzzz1)
                                    colPrecioVentaGranMayorME = resultME
                                End If
                                '    MsgBox(resultMN)
                            End If


                            precio.montoUtigranmayor = colMontoUtiGranMayor
                            precio.montoUtigranmayorme = colMontoUtiGranMayorME

                            precio.vvgranmayor = colValorVentaGranMayor
                            precio.vvgranmayorme = colValorVentaGranMayorME

                            precio.igvgranmayor = colIgvGranMayor
                            precio.igvgranmayorme = colIgvGranMayorME

                            precio.pvgranmayor = colPrecioVentaGranMayor
                            precio.pvgranmayorme = colPrecioVentaGranMayorME
                        Case Else
                            Dim colIgvGranMayor As Decimal = Math.Round(colValorVentaGranMayor * (18 / 100), 2)
                            Dim colIgvGranMayorME As Decimal = Math.Round(colValorVentaGranMayorME * (18 / 100), 2)

                            Dim colPrecioVentaGranMayor As Decimal = colValorVentaGranMayor + colIgvGranMayor
                            Dim colPrecioVentaGranMayorME As Decimal = colValorVentaGranMayorME + colIgvGranMayorME
                            Dim b As Decimal = 0
                            Dim b1 As Decimal = 0
                            b = colPrecioVentaGranMayor - Int(colPrecioVentaGranMayor)
                            b1 = colPrecioVentaGranMayorME - Int(colPrecioVentaGranMayorME)
                            Dim s = b.ToString.Replace("0.", "")
                            Dim s1 = b1.ToString.Replace("0.", "")
                            Dim x = Mid(s, 1, 1) & "0"
                            Dim x1 = Mid(s1, 1, 1) & "0"
                            If s > x Then
                                Dim z = CDbl(x) + 10
                                'Dim zz = Int(a).ToString
                                Dim zzz = Int(z).ToString
                                If z = 100 Then
                                    Dim zzzz = Int(colPrecioVentaGranMayor) + 1 & "." & 0
                                    Dim resultMN = CDbl(zzzz)
                                    colPrecioVentaGranMayor = resultMN
                                Else
                                    Dim zzzz = Int(colPrecioVentaGranMayor).ToString & "." & zzz
                                    Dim resultMN = CDbl(zzzz)
                                    '    MsgBox(resultMN)
                                    colPrecioVentaGranMayor = resultMN
                                End If

                            End If

                            If s1 > x1 Then
                                Dim z1 = CDbl(x1) + 10
                                'Dim zz = Int(a).ToString
                                Dim zzz1 = Int(z1).ToString
                                If z1 = 100 Then
                                    Dim zzzz1 = Int(colPrecioVentaGranMayorME) + 1 & "." & 0
                                    Dim resultMe = CDbl(zzzz1)
                                    colPrecioVentaGranMayorME = resultMe
                                Else
                                    Dim zzzz1 = Int(colPrecioVentaGranMayorME).ToString & "." & zzz1
                                    Dim resultME = CDbl(zzzz1)
                                    colPrecioVentaGranMayorME = resultME
                                End If
                                '    MsgBox(resultMN)
                            End If


                            precio.montoUtigranmayor = colMontoUtiGranMayor
                            precio.montoUtigranmayorme = colMontoUtiGranMayorME

                            precio.vvgranmayor = colValorVentaGranMayor
                            precio.vvgranmayorme = colValorVentaGranMayorME

                            precio.igvgranmayor = colIgvGranMayor
                            precio.igvgranmayorme = colIgvGranMayorME

                            precio.pvgranmayor = colPrecioVentaGranMayor
                            precio.pvgranmayorme = colPrecioVentaGranMayorME
                    End Select
                    HeliosData.listadoPrecios.Add(precio)
                End If

                HeliosData.SaveChanges()
                ts.Complete()
            End Using
            'Else
            '   Throw new Exception ("")



        Catch ex As Exception

        End Try
    End Sub

    Public Sub GrabarPrecioEntradaAportes(documentoCompra As saldoInicioDetalle)
        Dim precio As New listadoPrecios
        Dim consulta As listadoPrecios
        Try
            consulta = HeliosData.listadoPrecios.Where(Function(o) o.idEmpresa = documentoCompra.IdEmpresa And _
                                                                                 o.idEstablecimiento = documentoCompra.IdEstablecimiento And _
                                                                                 o.idItem = documentoCompra.idModulo And _
                                                                                 o.destinoGravado = documentoCompra.destino And o.porcUtimenor = documentoCompra.utiMenor _
                                                                                 And o.porcUtimayor = documentoCompra.utiMayor _
                                                                                 And o.porcUtigranmayor = documentoCompra.utiGranMayor _
                                                                                 And o.fecha = documentoCompra.FechaDoc).FirstOrDefault

            Using ts As New TransactionScope
                precio = New listadoPrecios
                If IsNothing(consulta) Then

                    precio.idEmpresa = documentoCompra.IdEmpresa
                    precio.idEstablecimiento = documentoCompra.IdEstablecimiento
                    '     precio.idAlmacen = documentoCompra.almacen
                    precio.tipoExistencia = documentoCompra.tipoExistencia
                    precio.destinoGravado = documentoCompra.destino
                    precio.idItem = documentoCompra.idModulo
                    precio.descripcion = documentoCompra.descripcionItem
                    precio.fecha = documentoCompra.FechaDoc
                    precio.tipoConfiguracion = "P"
                    precio.presentacion = Nothing ' documentoCompra.unidad2
                    precio.unidad = Nothing ' documentoCompra.unidad1
                    'CALCULO
                    precio.porcUtimenor = documentoCompra.utiMenor

                    Dim colMontoUtiMenor As Decimal = 0
                    Dim colMontoUtiMenorME As Decimal = 0

                    Dim colValorVentaMenor As Decimal = 0
                    Dim colValorVentaMenorME As Decimal = 0

                    Dim costoUnitVC As Decimal = 0
                    Dim costoUnitVCme As Decimal = 0

                    costoUnitVC = Math.Round(CDbl(documentoCompra.importe) / CDbl(documentoCompra.cantidad), 2)
                    costoUnitVCme = Math.Round(CDbl(documentoCompra.importeUS) / CDbl(documentoCompra.cantidad), 2)

                    precio.vcmenor = costoUnitVC
                    precio.vcmenorme = costoUnitVCme

                    colMontoUtiMenor = Math.Round(CDbl(costoUnitVC) * (CDbl(documentoCompra.utiMenor) / 100), 2)
                    colMontoUtiMenorME = Math.Round(CDbl(costoUnitVCme) * (CDbl(documentoCompra.utiMenor) / 100), 2)

                    colValorVentaMenor = CDbl(costoUnitVC) + colMontoUtiMenor
                    colValorVentaMenorME = CDbl(costoUnitVCme) + colMontoUtiMenorME

                    Select Case documentoCompra.destino

                        Case "2"
                            Dim colIgvMenor As Decimal = 0
                            Dim colIgvMenorME As Decimal = 0

                            Dim colPrecioVentaMenor As Decimal = colValorVentaMenor + colIgvMenor
                            Dim colPrecioVentaMenorME As Decimal = colValorVentaMenorME + colIgvMenorME

                            Dim b As Decimal = 0
                            Dim b1 As Decimal = 0
                            b = colPrecioVentaMenor - Int(colPrecioVentaMenor)
                            b1 = colPrecioVentaMenorME - Int(colPrecioVentaMenorME)
                            Dim s = b.ToString.Replace("0.", "")
                            Dim s1 = b1.ToString.Replace("0.", "")
                            Dim x = Mid(s, 1, 1) & "0"
                            Dim x1 = Mid(s1, 1, 1) & "0"
                            If s > x Then
                                Dim z = CDbl(x) + 10
                                'Dim zz = Int(a).ToString
                                Dim zzz = Int(z).ToString
                                If z = 100 Then
                                    Dim zzzz = Int(colPrecioVentaMenor) + 1 & "." & 0
                                    Dim resultMN = CDbl(zzzz)
                                    colPrecioVentaMenor = resultMN
                                Else
                                    Dim zzzz = Int(colPrecioVentaMenor).ToString & "." & zzz
                                    Dim resultMN = CDbl(zzzz)
                                    '    MsgBox(resultMN)
                                    colPrecioVentaMenor = resultMN
                                End If

                            End If

                            If s1 > x1 Then
                                Dim z1 = CDbl(x1) + 10
                                'Dim zz = Int(a).ToString
                                Dim zzz1 = Int(z1).ToString
                                If z1 = 100 Then
                                    Dim zzzz1 = Int(colPrecioVentaMenorME) + 1 & "." & 0
                                    Dim resultMe = CDbl(zzzz1)
                                    colPrecioVentaMenorME = resultMe
                                Else
                                    Dim zzzz1 = Int(colPrecioVentaMenorME).ToString & "." & zzz1
                                    Dim resultME = CDbl(zzzz1)
                                    colPrecioVentaMenorME = resultME
                                End If
                                '    MsgBox(resultMN)
                            End If

                            precio.montoUtimenor = colMontoUtiMenor
                            precio.montoUtimenorme = colMontoUtiMenorME

                            precio.vvmenor = colValorVentaMenor
                            precio.vvmenorme = colValorVentaMenorME

                            precio.igvmenor = colIgvMenor
                            precio.igvmenormeme = colIgvMenorME

                            precio.pvmenor = colPrecioVentaMenor
                            precio.pvmenorme = colPrecioVentaMenorME

                        Case Else
                            Dim colIgvMenor As Decimal = Math.Round(colValorVentaMenor * (18 / 100), 2)
                            Dim colIgvMenorME As Decimal = Math.Round(colValorVentaMenorME * (18 / 100), 2)

                            Dim colPrecioVentaMenor As Decimal = colValorVentaMenor + colIgvMenor
                            Dim colPrecioVentaMenorME As Decimal = colValorVentaMenorME + colIgvMenorME

                            Dim b As Decimal = 0
                            Dim b1 As Decimal = 0
                            b = colPrecioVentaMenor - Int(colPrecioVentaMenor)
                            b1 = colPrecioVentaMenorME - Int(colPrecioVentaMenorME)
                            Dim s = b.ToString.Replace("0.", "")
                            Dim s1 = b1.ToString.Replace("0.", "")
                            Dim x = Mid(s, 1, 1) & "0"
                            Dim x1 = Mid(s1, 1, 1) & "0"
                            If s > x Then
                                Dim z = CDbl(x) + 10
                                'Dim zz = Int(a).ToString
                                Dim zzz = Int(z).ToString
                                If z = 100 Then
                                    Dim zzzz = Int(colPrecioVentaMenor) + 1 & "." & 0
                                    Dim resultMN = CDbl(zzzz)
                                    colPrecioVentaMenor = resultMN
                                Else
                                    Dim zzzz = Int(colPrecioVentaMenor).ToString & "." & zzz
                                    Dim resultMN = CDbl(zzzz)
                                    '    MsgBox(resultMN)
                                    colPrecioVentaMenor = resultMN
                                End If

                            End If

                            If s1 > x1 Then
                                Dim z1 = CDbl(x1) + 10
                                'Dim zz = Int(a).ToString
                                Dim zzz1 = Int(z1).ToString
                                If z1 = 100 Then
                                    Dim zzzz1 = Int(colPrecioVentaMenorME) + 1 & "." & 0
                                    Dim resultMe = CDbl(zzzz1)
                                    colPrecioVentaMenorME = resultMe
                                Else
                                    Dim zzzz1 = Int(colPrecioVentaMenorME).ToString & "." & zzz1
                                    Dim resultME = CDbl(zzzz1)
                                    colPrecioVentaMenorME = resultME
                                End If
                                '    MsgBox(resultMN)
                            End If

                            precio.montoUtimenor = colMontoUtiMenor
                            precio.montoUtimenorme = colMontoUtiMenorME

                            precio.vvmenor = colValorVentaMenor
                            precio.vvmenorme = colValorVentaMenorME

                            precio.igvmenor = colIgvMenor
                            precio.igvmenormeme = colIgvMenorME

                            precio.pvmenor = colPrecioVentaMenor
                            precio.pvmenorme = colPrecioVentaMenorME
                    End Select
                    '-------------------------------------------------------------------

                    precio.porcUtimayor = documentoCompra.utiMayor
                    Dim colMontoUtiMayor As Decimal = 0
                    Dim colMontoUtiMayorME As Decimal = 0

                    Dim colValorVentaMayor As Decimal = 0
                    Dim colValorVentaMayorME As Decimal = 0

                    Dim costoUnitmyVC As Decimal = 0
                    Dim costoUnitmyVCme As Decimal = 0

                    costoUnitmyVC = Math.Round(CDbl(documentoCompra.importe) / CDbl(documentoCompra.cantidad), 2)
                    costoUnitmyVCme = Math.Round(CDbl(documentoCompra.importeUS) / CDbl(documentoCompra.cantidad), 2)

                    precio.vcmayor = costoUnitmyVC
                    precio.vcmayorme = costoUnitmyVCme

                    colMontoUtiMayor = Math.Round(CDbl(costoUnitmyVC) * (CDbl(documentoCompra.utiMayor) / 100), 2)
                    colMontoUtiMayorME = Math.Round(CDbl(costoUnitmyVCme) * (CDbl(documentoCompra.utiMayor) / 100), 2)

                    colValorVentaMayor = CDbl(costoUnitmyVC) + colMontoUtiMayor
                    colValorVentaMayorME = CDbl(costoUnitmyVCme) + colMontoUtiMayorME

                    Select Case documentoCompra.destino

                        Case "2"
                            Dim colIgvMayor As Decimal = 0
                            Dim colIgvMayorME As Decimal = 0

                            Dim colPrecioVentaMayor As Decimal = colValorVentaMayor + colIgvMayor
                            Dim colPrecioVentaMayorME As Decimal = colValorVentaMayorME + colIgvMayorME
                            Dim b As Decimal = 0
                            Dim b1 As Decimal = 0
                            b = colPrecioVentaMayor - Int(colPrecioVentaMayor)
                            b1 = colPrecioVentaMayorME - Int(colPrecioVentaMayorME)
                            Dim s = b.ToString.Replace("0.", "")
                            Dim s1 = b1.ToString.Replace("0.", "")
                            Dim x = Mid(s, 1, 1) & "0"
                            Dim x1 = Mid(s1, 1, 1) & "0"
                            If s > x Then
                                Dim z = CDbl(x) + 10
                                'Dim zz = Int(a).ToString
                                Dim zzz = Int(z).ToString
                                If z = 100 Then
                                    Dim zzzz = Int(colPrecioVentaMayor) + 1 & "." & 0
                                    Dim resultMN = CDbl(zzzz)
                                    colPrecioVentaMayor = resultMN
                                Else
                                    Dim zzzz = Int(colPrecioVentaMayor).ToString & "." & zzz
                                    Dim resultMN = CDbl(zzzz)
                                    '    MsgBox(resultMN)
                                    colPrecioVentaMayor = resultMN
                                End If

                            End If

                            If s1 > x1 Then
                                Dim z1 = CDbl(x1) + 10
                                'Dim zz = Int(a).ToString
                                Dim zzz1 = Int(z1).ToString
                                If z1 = 100 Then
                                    Dim zzzz1 = Int(colPrecioVentaMayorME) + 1 & "." & 0
                                    Dim resultMe = CDbl(zzzz1)
                                    colPrecioVentaMayorME = resultMe
                                Else
                                    Dim zzzz1 = Int(colPrecioVentaMayorME).ToString & "." & zzz1
                                    Dim resultME = CDbl(zzzz1)
                                    colPrecioVentaMayorME = resultME
                                End If
                                '    MsgBox(resultMN)
                            End If


                            precio.montoUtimayor = colMontoUtiMayor
                            precio.montoUtimayorme = colMontoUtiMayorME

                            precio.vvmayor = colValorVentaMayor
                            precio.vvmayorme = colValorVentaMayorME

                            precio.igvmayor = colIgvMayor
                            precio.igvmayormeme = colIgvMayorME

                            precio.pvmayor = colPrecioVentaMayor
                            precio.pvmayorme = colPrecioVentaMayorME
                        Case Else

                            Dim colIgvMayor As Decimal = Math.Round(colValorVentaMayor * (18 / 100), 2)
                            Dim colIgvMayorME As Decimal = Math.Round(colValorVentaMayorME * (18 / 100), 2)

                            Dim colPrecioVentaMayor As Decimal = colValorVentaMayor + colIgvMayor
                            Dim colPrecioVentaMayorME As Decimal = colValorVentaMayorME + colIgvMayorME
                            Dim b As Decimal = 0
                            Dim b1 As Decimal = 0
                            b = colPrecioVentaMayor - Int(colPrecioVentaMayor)
                            b1 = colPrecioVentaMayorME - Int(colPrecioVentaMayorME)
                            Dim s = b.ToString.Replace("0.", "")
                            Dim s1 = b1.ToString.Replace("0.", "")
                            Dim x = Mid(s, 1, 1) & "0"
                            Dim x1 = Mid(s1, 1, 1) & "0"
                            If s > x Then
                                Dim z = CDbl(x) + 10
                                'Dim zz = Int(a).ToString
                                Dim zzz = Int(z).ToString
                                If z = 100 Then
                                    Dim zzzz = Int(colPrecioVentaMayor) + 1 & "." & 0
                                    Dim resultMN = CDbl(zzzz)
                                    colPrecioVentaMayor = resultMN
                                Else
                                    Dim zzzz = Int(colPrecioVentaMayor).ToString & "." & zzz
                                    Dim resultMN = CDbl(zzzz)
                                    '    MsgBox(resultMN)
                                    colPrecioVentaMayor = resultMN
                                End If

                            End If

                            If s1 > x1 Then
                                Dim z1 = CDbl(x1) + 10
                                'Dim zz = Int(a).ToString
                                Dim zzz1 = Int(z1).ToString
                                If z1 = 100 Then
                                    Dim zzzz1 = Int(colPrecioVentaMayorME) + 1 & "." & 0
                                    Dim resultMe = CDbl(zzzz1)
                                    colPrecioVentaMayorME = resultMe
                                Else
                                    Dim zzzz1 = Int(colPrecioVentaMayorME).ToString & "." & zzz1
                                    Dim resultME = CDbl(zzzz1)
                                    colPrecioVentaMayorME = resultME
                                End If
                                '    MsgBox(resultMN)
                            End If


                            precio.montoUtimayor = colMontoUtiMayor
                            precio.montoUtimayorme = colMontoUtiMayorME

                            precio.vvmayor = colValorVentaMayor
                            precio.vvmayorme = colValorVentaMayorME

                            precio.igvmayor = colIgvMayor
                            precio.igvmayormeme = colIgvMayorME

                            precio.pvmayor = colPrecioVentaMayor
                            precio.pvmayorme = colPrecioVentaMayorME
                    End Select



                    '----------------------------------------------------------------------------------------------
                    precio.porcUtigranmayor = documentoCompra.utiGranMayor

                    Dim colMontoUtiGranMayor As Decimal = 0
                    Dim colMontoUtiGranMayorME As Decimal = 0

                    Dim colValorVentaGranMayor As Decimal = 0
                    Dim colValorVentaGranMayorME As Decimal = 0

                    Dim costoUnitgmyVC As Decimal = 0
                    Dim costoUnitgmyVCme As Decimal = 0

                    costoUnitgmyVC = Math.Round(CDbl(documentoCompra.importe) / CDbl(documentoCompra.cantidad), 2)
                    costoUnitgmyVCme = Math.Round(CDbl(documentoCompra.importeUS) / CDbl(documentoCompra.cantidad), 2)

                    precio.vcgranmayor = costoUnitgmyVC
                    precio.vcgranmayorme = costoUnitgmyVCme

                    colMontoUtiGranMayor = Math.Round(CDbl(costoUnitgmyVC) * (CDbl(documentoCompra.utiGranMayor) / 100), 2)
                    colMontoUtiGranMayorME = Math.Round(CDbl(costoUnitgmyVCme) * (CDbl(documentoCompra.utiGranMayor) / 100), 2)

                    colValorVentaGranMayor = CDbl(costoUnitgmyVC) + colMontoUtiGranMayor
                    colValorVentaGranMayorME = CDbl(costoUnitgmyVCme) + colMontoUtiGranMayorME

                    Select Case documentoCompra.destino

                        Case "2"
                            Dim colIgvGranMayor As Decimal = 0
                            Dim colIgvGranMayorME As Decimal = 0
                            Dim colPrecioVentaGranMayor As Decimal = colValorVentaGranMayor + colIgvGranMayor
                            Dim colPrecioVentaGranMayorME As Decimal = colValorVentaGranMayorME + colIgvGranMayorME

                            Dim b As Decimal = 0
                            Dim b1 As Decimal = 0
                            b = colPrecioVentaGranMayor - Int(colPrecioVentaGranMayor)
                            b1 = colPrecioVentaGranMayorME - Int(colPrecioVentaGranMayorME)
                            Dim s = b.ToString.Replace("0.", "")
                            Dim s1 = b1.ToString.Replace("0.", "")
                            Dim x = Mid(s, 1, 1) & "0"
                            Dim x1 = Mid(s1, 1, 1) & "0"
                            If s > x Then
                                Dim z = CDbl(x) + 10
                                'Dim zz = Int(a).ToString
                                Dim zzz = Int(z).ToString
                                If z = 100 Then
                                    Dim zzzz = Int(colPrecioVentaGranMayor) + 1 & "." & 0
                                    Dim resultMN = CDbl(zzzz)
                                    colPrecioVentaGranMayor = resultMN
                                Else
                                    Dim zzzz = Int(colPrecioVentaGranMayor).ToString & "." & zzz
                                    Dim resultMN = CDbl(zzzz)
                                    '    MsgBox(resultMN)
                                    colPrecioVentaGranMayor = resultMN
                                End If

                            End If

                            If s1 > x1 Then
                                Dim z1 = CDbl(x1) + 10
                                'Dim zz = Int(a).ToString
                                Dim zzz1 = Int(z1).ToString
                                If z1 = 100 Then
                                    Dim zzzz1 = Int(colPrecioVentaGranMayorME) + 1 & "." & 0
                                    Dim resultMe = CDbl(zzzz1)
                                    colPrecioVentaGranMayorME = resultMe
                                Else
                                    Dim zzzz1 = Int(colPrecioVentaGranMayorME).ToString & "." & zzz1
                                    Dim resultME = CDbl(zzzz1)
                                    colPrecioVentaGranMayorME = resultME
                                End If
                                '    MsgBox(resultMN)
                            End If

                            precio.montoUtigranmayor = colMontoUtiGranMayor
                            precio.montoUtigranmayorme = colMontoUtiGranMayorME

                            precio.vvgranmayor = colValorVentaGranMayor
                            precio.vvgranmayorme = colValorVentaGranMayorME

                            precio.igvgranmayor = colIgvGranMayor
                            precio.igvgranmayorme = colIgvGranMayorME

                            precio.pvgranmayor = colPrecioVentaGranMayor
                            precio.pvgranmayorme = colPrecioVentaGranMayorME
                        Case Else

                            Dim colIgvGranMayor As Decimal = Math.Round(colValorVentaGranMayor * (18 / 100), 2)
                            Dim colIgvGranMayorME As Decimal = Math.Round(colValorVentaGranMayorME * (18 / 100), 2)
                            Dim colPrecioVentaGranMayor As Decimal = colValorVentaGranMayor + colIgvGranMayor
                            Dim colPrecioVentaGranMayorME As Decimal = colValorVentaGranMayorME + colIgvGranMayorME

                            Dim b As Decimal = 0
                            Dim b1 As Decimal = 0
                            b = colPrecioVentaGranMayor - Int(colPrecioVentaGranMayor)
                            b1 = colPrecioVentaGranMayorME - Int(colPrecioVentaGranMayorME)
                            Dim s = b.ToString.Replace("0.", "")
                            Dim s1 = b1.ToString.Replace("0.", "")
                            Dim x = Mid(s, 1, 1) & "0"
                            Dim x1 = Mid(s1, 1, 1) & "0"
                            If s > x Then
                                Dim z = CDbl(x) + 10
                                'Dim zz = Int(a).ToString
                                Dim zzz = Int(z).ToString
                                If z = 100 Then
                                    Dim zzzz = Int(colPrecioVentaGranMayor) + 1 & "." & 0
                                    Dim resultMN = CDbl(zzzz)
                                    colPrecioVentaGranMayor = resultMN
                                Else
                                    Dim zzzz = Int(colPrecioVentaGranMayor).ToString & "." & zzz
                                    Dim resultMN = CDbl(zzzz)
                                    '    MsgBox(resultMN)
                                    colPrecioVentaGranMayor = resultMN
                                End If

                            End If

                            If s1 > x1 Then
                                Dim z1 = CDbl(x1) + 10
                                'Dim zz = Int(a).ToString
                                Dim zzz1 = Int(z1).ToString
                                If z1 = 100 Then
                                    Dim zzzz1 = Int(colPrecioVentaGranMayorME) + 1 & "." & 0
                                    Dim resultMe = CDbl(zzzz1)
                                    colPrecioVentaGranMayorME = resultMe
                                Else
                                    Dim zzzz1 = Int(colPrecioVentaGranMayorME).ToString & "." & zzz1
                                    Dim resultME = CDbl(zzzz1)
                                    colPrecioVentaGranMayorME = resultME
                                End If
                                '    MsgBox(resultMN)
                            End If

                            precio.montoUtigranmayor = colMontoUtiGranMayor
                            precio.montoUtigranmayorme = colMontoUtiGranMayorME

                            precio.vvgranmayor = colValorVentaGranMayor
                            precio.vvgranmayorme = colValorVentaGranMayorME

                            precio.igvgranmayor = colIgvGranMayor
                            precio.igvgranmayorme = colIgvGranMayorME

                            precio.pvgranmayor = colPrecioVentaGranMayor
                            precio.pvgranmayorme = colPrecioVentaGranMayorME
                    End Select

                    HeliosData.listadoPrecios.Add(precio)
                End If

                HeliosData.SaveChanges()
                ts.Complete()
            End Using
            'Else
            '   Throw new Exception ("")



        Catch ex As Exception

        End Try
    End Sub

    Public Function UbicarVentaPorItem(ByVal intIdAlmacen As Integer, intIdItem As Integer) As listadoPrecios
        Dim objTablaDetalleBO As New listadoPrecios

        'Dim q = (From n In HeliosData.listadoPrecios _
        '       Where (n.fecha) = (From x In HeliosData.listadoPrecios _
        '                         Where _
        '                            x.idAlmacen = intIdAlmacen _
        '                            And x.idItem = intIdItem _
        '                            Select x.fecha).Max() _
        '                            And n.idAlmacen = intIdAlmacen _
        '                            And n.idItem = intIdItem).FirstOrDefault


        'If Not IsNothing(q) Then
        '    objTablaDetalleBO = New listadoPrecios() With _
        '                           {
        '                               .tipoConfiguracion = q.tipoConfiguracion, _
        '                               .pvmenor = q.pvmenor, _
        '                               .pvmenorme = q.pvmenorme, _
        '                               .pvmayor = q.pvmayor, _
        '                               .pvmayorme = q.pvmayorme, _
        '                               .pvgranmayor = q.pvgranmayor, _
        '                               .pvgranmayorme = q.pvgranmayorme _
        '                            }

        'End If

        'ListaProductos = (objTablaDetalleBO)
        Return objTablaDetalleBO
    End Function

    Public Function UbicarVentaPorItemXiva(ByVal intIdAlmacen As Integer, intIdItem As Integer, strIVA As String) As listadoPrecios
        Dim objTablaDetalleBO As New listadoPrecios

        'Dim q = (From n In HeliosData.listadoPrecios _
        '       Where (n.fecha) = (From x In HeliosData.listadoPrecios _
        '                         Where _
        '                            x.idAlmacen = intIdAlmacen _
        '                            And x.idItem = intIdItem _
        '                            Select x.fecha).Max() _
        '                            And n.idAlmacen = intIdAlmacen _
        '                            And n.idItem = intIdItem).FirstOrDefault


        'If Not IsNothing(q) Then
        '    objTablaDetalleBO = New listadoPrecios() With _
        '                           {
        '                               .tipoConfiguracion = q.tipoConfiguracion, _
        '                               .pvmenor = q.pvmenor, _
        '                               .pvmenorme = q.pvmenorme, _
        '                               .pvmayor = q.pvmayor, _
        '                               .pvmayorme = q.pvmayorme, _
        '                               .pvgranmayor = q.pvgranmayor, _
        '                               .pvgranmayorme = q.pvgranmayorme _
        '                            }

        'End If

        'ListaProductos = (objTablaDetalleBO)
        Return objTablaDetalleBO
    End Function

    Public Sub Insert(ByVal listadoPreciosBE As listadoPrecios)
        Dim listPrecios As New listadoPrecios
        Using ts As New TransactionScope
            listPrecios.idEmpresa = listadoPreciosBE.idEmpresa
            listPrecios.idEstablecimiento = listadoPreciosBE.idEstablecimiento
            '    listPrecios.idAlmacen = listadoPreciosBE.idAlmacen
            listPrecios.tipoExistencia = listadoPreciosBE.tipoExistencia
            listPrecios.destinoGravado = listadoPreciosBE.destinoGravado
            listPrecios.idItem = listadoPreciosBE.idItem
            listPrecios.descripcion = listadoPreciosBE.descripcion
            listPrecios.presentacion = listadoPreciosBE.presentacion
            listPrecios.unidad = listadoPreciosBE.unidad
            listPrecios.fecha = listadoPreciosBE.fecha
            listPrecios.valcompraIgvMN = listadoPreciosBE.valcompraIgvMN
            listPrecios.valcompraSinIgvMN = listadoPreciosBE.valcompraSinIgvMN
            listPrecios.valcompraIgvME = listadoPreciosBE.valcompraIgvME
            listPrecios.valcompraSinIgvME = listadoPreciosBE.valcompraSinIgvME
            listPrecios.tipoConfiguracion = listadoPreciosBE.tipoConfiguracion
            listPrecios.montoUtilidad = listadoPreciosBE.montoUtilidad
            listPrecios.montoUtilidadME = listadoPreciosBE.montoUtilidadME
            listPrecios.utilidadsinIgvMN = listadoPreciosBE.utilidadsinIgvMN
            listPrecios.valorVentaMN = listadoPreciosBE.valorVentaMN
            listPrecios.igvMN = listadoPreciosBE.igvMN
            listPrecios.iscMN = listadoPreciosBE.iscMN
            listPrecios.otcMN = listadoPreciosBE.otcMN
            listPrecios.precioVentaMN = listadoPreciosBE.precioVentaMN
            listPrecios.utilidadsinIgvME = listadoPreciosBE.utilidadsinIgvME
            listPrecios.valorVentaME = listadoPreciosBE.valorVentaME
            listPrecios.igvME = listadoPreciosBE.igvME
            listPrecios.iscME = listadoPreciosBE.iscME
            listPrecios.otcME = listadoPreciosBE.otcME
            listPrecios.precioVentaME = listadoPreciosBE.precioVentaME
            listPrecios.PorDsctounitMenor = listadoPreciosBE.PorDsctounitMenor
            listPrecios.montoDsctounitMenorMN = listadoPreciosBE.montoDsctounitMenorMN
            listPrecios.montoDsctounitMenorME = listadoPreciosBE.montoDsctounitMenorME
            listPrecios.precioVentaFinalMenorMN = listadoPreciosBE.precioVentaFinalMenorMN
            listPrecios.precioVentaFinalMenorME = listadoPreciosBE.precioVentaFinalMenorME
            listPrecios.PorDsctounitMayor = listadoPreciosBE.PorDsctounitMayor
            listPrecios.montoDsctounitMayorMN = listadoPreciosBE.montoDsctounitMayorMN
            listPrecios.montoDsctounitMayorME = listadoPreciosBE.montoDsctounitMayorME
            listPrecios.precioVentaFinalMayorMN = listadoPreciosBE.precioVentaFinalMayorMN
            listPrecios.precioVentaFinalMayorME = listadoPreciosBE.precioVentaFinalMayorME
            listPrecios.PorDsctounitGMayor = listadoPreciosBE.PorDsctounitGMayor
            listPrecios.montoDsctounitGMayorMN = listadoPreciosBE.montoDsctounitGMayorMN
            listPrecios.montoDsctounitGMayorME = listadoPreciosBE.montoDsctounitGMayorME
            listPrecios.precioVentaFinalGMayorMN = listadoPreciosBE.precioVentaFinalGMayorMN
            listPrecios.precioVentaFinalGMayorME = listadoPreciosBE.precioVentaFinalGMayorME
            listPrecios.detalleMenor = listadoPreciosBE.detalleMenor
            listPrecios.cantidadMenor = listadoPreciosBE.cantidadMenor
            listPrecios.detalleMayor = listadoPreciosBE.detalleMayor
            listPrecios.cantidadMayor = listadoPreciosBE.cantidadMayor
            listPrecios.detalleGMayor = listadoPreciosBE.detalleGMayor
            listPrecios.cantidadGMayor = listadoPreciosBE.cantidadGMayor
            listPrecios.usuarioActualizacion = listadoPreciosBE.usuarioActualizacion
            listPrecios.fechaActualizacion = listadoPreciosBE.fechaActualizacion

            HeliosData.listadoPrecios.Add(listPrecios)
            HeliosData.SaveChanges()
            ts.Complete()
            listadoPreciosBE.autoCodigo = listPrecios.autoCodigo
        End Using
    End Sub

    Public Function InsertarPrecioVV(ByVal listadoPreciosBE As listadoPrecios) As Integer
        Dim listPrecios As New listadoPrecios
        Using ts As New TransactionScope
            listPrecios.idEmpresa = listadoPreciosBE.idEmpresa
            listPrecios.idEstablecimiento = listadoPreciosBE.idEstablecimiento
            '    listPrecios.idAlmacen = listadoPreciosBE.idAlmacen
            listPrecios.tipoExistencia = listadoPreciosBE.tipoExistencia
            listPrecios.destinoGravado = listadoPreciosBE.destinoGravado
            listPrecios.idItem = listadoPreciosBE.idItem
            listPrecios.descripcion = listadoPreciosBE.descripcion
            listPrecios.presentacion = listadoPreciosBE.presentacion
            listPrecios.unidad = listadoPreciosBE.unidad
            listPrecios.fecha = listadoPreciosBE.fecha
            listPrecios.tipoConfiguracion = listadoPreciosBE.tipoConfiguracion

            listPrecios.vcmenor = listadoPreciosBE.vcmenor
            listPrecios.vcmenorme = listadoPreciosBE.vcmenorme

            listPrecios.vcmayor = listadoPreciosBE.vcmayor
            listPrecios.vcmayorme = listadoPreciosBE.vcmayorme

            listPrecios.vcgranmayor = listadoPreciosBE.vcgranmayor
            listPrecios.vcgranmayorme = listadoPreciosBE.vcgranmayorme

            listPrecios.porcUtimenor = listadoPreciosBE.porcUtimenor
            listPrecios.porcUtimayor = listadoPreciosBE.porcUtimayor
            listPrecios.porcUtigranmayor = listadoPreciosBE.porcUtigranmayor
            listPrecios.montoUtimenor = listadoPreciosBE.montoUtimenor
            listPrecios.montoUtimayor = listadoPreciosBE.montoUtimayor
            listPrecios.montoUtigranmayor = listadoPreciosBE.montoUtigranmayor
            listPrecios.vvmenor = listadoPreciosBE.vvmenor
            listPrecios.vvmayor = listadoPreciosBE.vvmayor
            listPrecios.vvgranmayor = listadoPreciosBE.vvgranmayor
            listPrecios.igvmenor = listadoPreciosBE.igvmenor
            listPrecios.igvmayor = listadoPreciosBE.igvmayor
            listPrecios.igvgranmayor = listadoPreciosBE.igvgranmayor
            listPrecios.pvmenor = listadoPreciosBE.pvmenor
            listPrecios.pvmayor = listadoPreciosBE.pvmayor
            listPrecios.pvgranmayor = listadoPreciosBE.pvgranmayor

            listPrecios.porcUtimenorme = listadoPreciosBE.porcUtimenorme
            listPrecios.porcUtimayorme = listadoPreciosBE.porcUtimayorme
            listPrecios.porcUtigranmayorme = listadoPreciosBE.porcUtigranmayorme
            listPrecios.montoUtimenorme = listadoPreciosBE.montoUtimenorme
            listPrecios.montoUtimayorme = listadoPreciosBE.montoUtimayorme
            listPrecios.montoUtigranmayorme = listadoPreciosBE.montoUtigranmayorme
            listPrecios.vvmenorme = listadoPreciosBE.vvmenorme
            listPrecios.vvmayorme = listadoPreciosBE.vvmayorme
            listPrecios.vvgranmayorme = listadoPreciosBE.vvgranmayorme
            listPrecios.igvmenormeme = listadoPreciosBE.igvmenormeme
            listPrecios.igvmayormeme = listadoPreciosBE.igvmayormeme
            listPrecios.igvgranmayorme = listadoPreciosBE.igvgranmayorme
            listPrecios.pvmenorme = listadoPreciosBE.pvmenorme
            listPrecios.pvmayorme = listadoPreciosBE.pvmayorme
            listPrecios.pvgranmayorme = listadoPreciosBE.pvgranmayorme
            HeliosData.listadoPrecios.Add(listPrecios)
            HeliosData.SaveChanges()
            ts.Complete()
            Return listPrecios.autoCodigo
        End Using
    End Function

    Public Sub Update(ByVal listadoPreciosBE As listadoPrecios)
        Using ts As New TransactionScope
            Dim listPrecios As listadoPrecios = HeliosData.listadoPrecios.Where(Function(o) _
                                            o.autoCodigo = listadoPreciosBE.autoCodigo).First()

            listPrecios.idEmpresa = listadoPreciosBE.idEmpresa
            listPrecios.idEstablecimiento = listadoPreciosBE.idEstablecimiento
            '    listPrecios.idAlmacen = listadoPreciosBE.idAlmacen
            listPrecios.tipoExistencia = listadoPreciosBE.tipoExistencia
            listPrecios.destinoGravado = listadoPreciosBE.destinoGravado
            listPrecios.idItem = listadoPreciosBE.idItem
            listPrecios.descripcion = listadoPreciosBE.descripcion
            listPrecios.presentacion = listadoPreciosBE.presentacion
            listPrecios.unidad = listadoPreciosBE.unidad
            listPrecios.fecha = listadoPreciosBE.fecha
            listPrecios.valcompraIgvMN = listadoPreciosBE.valcompraIgvMN
            listPrecios.valcompraSinIgvMN = listadoPreciosBE.valcompraSinIgvMN
            listPrecios.valcompraIgvME = listadoPreciosBE.valcompraIgvME
            listPrecios.valcompraSinIgvME = listadoPreciosBE.valcompraSinIgvME
            listPrecios.tipoConfiguracion = listadoPreciosBE.tipoConfiguracion
            listPrecios.montoUtilidad = listadoPreciosBE.montoUtilidad
            listPrecios.montoUtilidadME = listadoPreciosBE.montoUtilidadME
            listPrecios.utilidadsinIgvMN = listadoPreciosBE.utilidadsinIgvMN
            listPrecios.valorVentaMN = listadoPreciosBE.valorVentaMN
            listPrecios.igvMN = listadoPreciosBE.igvMN
            listPrecios.iscMN = listadoPreciosBE.iscMN
            listPrecios.otcMN = listadoPreciosBE.otcMN
            listPrecios.precioVentaMN = listadoPreciosBE.precioVentaMN
            listPrecios.utilidadsinIgvME = listadoPreciosBE.utilidadsinIgvME
            listPrecios.valorVentaME = listadoPreciosBE.valorVentaME
            listPrecios.igvME = listadoPreciosBE.igvME
            listPrecios.iscME = listadoPreciosBE.iscME
            listPrecios.otcME = listadoPreciosBE.otcME
            listPrecios.precioVentaME = listadoPreciosBE.precioVentaME
            listPrecios.PorDsctounitMenor = listadoPreciosBE.PorDsctounitMenor
            listPrecios.montoDsctounitMenorMN = listadoPreciosBE.montoDsctounitMenorMN
            listPrecios.montoDsctounitMenorME = listadoPreciosBE.montoDsctounitMenorME
            listPrecios.precioVentaFinalMenorMN = listadoPreciosBE.precioVentaFinalMenorMN
            listPrecios.precioVentaFinalMenorME = listadoPreciosBE.precioVentaFinalMenorME
            listPrecios.PorDsctounitMayor = listadoPreciosBE.PorDsctounitMayor
            listPrecios.montoDsctounitMayorMN = listadoPreciosBE.montoDsctounitMayorMN
            listPrecios.montoDsctounitMayorME = listadoPreciosBE.montoDsctounitMayorME
            listPrecios.precioVentaFinalMayorMN = listadoPreciosBE.precioVentaFinalMayorMN
            listPrecios.precioVentaFinalMayorME = listadoPreciosBE.precioVentaFinalMayorME
            listPrecios.PorDsctounitGMayor = listadoPreciosBE.PorDsctounitGMayor
            listPrecios.montoDsctounitGMayorMN = listadoPreciosBE.montoDsctounitGMayorMN
            listPrecios.montoDsctounitGMayorME = listadoPreciosBE.montoDsctounitGMayorME
            listPrecios.precioVentaFinalGMayorMN = listadoPreciosBE.precioVentaFinalGMayorMN
            listPrecios.precioVentaFinalGMayorME = listadoPreciosBE.precioVentaFinalGMayorME
            listPrecios.detalleMenor = listadoPreciosBE.detalleMenor
            listPrecios.cantidadMenor = listadoPreciosBE.cantidadMenor
            listPrecios.detalleMayor = listadoPreciosBE.detalleMayor
            listPrecios.cantidadMayor = listadoPreciosBE.cantidadMayor
            listPrecios.detalleGMayor = listadoPreciosBE.detalleGMayor
            listPrecios.cantidadGMayor = listadoPreciosBE.cantidadGMayor
            listPrecios.usuarioActualizacion = listadoPreciosBE.usuarioActualizacion
            listPrecios.fechaActualizacion = listadoPreciosBE.fechaActualizacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(listPrecios).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal listadoPreciosBE As listadoPrecios)
        Dim consulta As listadoPrecios = HeliosData.listadoPrecios.Where(Function(o) o.autoCodigo = listadoPreciosBE.autoCodigo).First
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)
        HeliosData.SaveChanges()
    End Sub

    Public Function GetListar_listadoPrecios() As List(Of listadoPrecios)
        Return (From a In HeliosData.listadoPrecios Select a).ToList
    End Function

    Public Function GetUbicar_listadoPreciosPorID(autoCodigo As Integer) As listadoPrecios
        Return (From a In HeliosData.listadoPrecios
                 Where a.autoCodigo = autoCodigo Select a).First
    End Function

    Public Function ObtenerPrecioPorItem(intIdAlmacen As Integer, intIdItem As Integer) As List(Of listadoPrecios)
        'Return (From n In HeliosData.listadoPrecios _
        '               Where n.idAlmacen = intIdAlmacen _
        '               And n.idItem = intIdItem _
        '               Order By n.descripcion _
        '               Select n).ToList
        Return Nothing
    End Function

    'And n.tipoConfiguracion = strTipoIVA _
    Public Function ObtenerPrecioPorItemSL(intIdAlmacen As Integer, intIdItem As Integer, strTipoIVA As String) As List(Of listadoPrecios)
        'Return (From n In HeliosData.listadoPrecios _
        '               Where n.idAlmacen = intIdAlmacen _
        '               And n.idItem = intIdItem _
        '               Order By n.fecha _
        '               Select n).ToList

        Return Nothing
    End Function

    Public Function ObtenerPrecioPorIdAlmacen(intIdAlmacen As Integer) As List(Of listadoPrecios)
        'Return (From n In HeliosData.listadoPrecios _
        '               Where n.idAlmacen = intIdAlmacen _
        '               Select n).ToList
        Return Nothing
    End Function

    Public Function UbicarVentaPorItemCSIVA(ByVal intIdAlmacen As Integer, intIdItem As Integer) As List(Of listadoPrecios)
        'Dim objTablaDetalleBO As New listadoPrecios
        'Dim ListaProductos As New List(Of listadoPrecios)
        'Dim listaIVA As New List(Of String)
        ''listaIVA.Add("SIVA")
        'listaIVA.Add("NIVA")
        'Dim obj = (From n In HeliosData.listadoPrecios _
        '       Where (n.fecha) = (From x In HeliosData.listadoPrecios _
        '                         Where _
        '                            x.idAlmacen = intIdAlmacen _
        '                            And x.idItem = intIdItem _
        '                            And listaIVA.Contains(n.tipoConfiguracion) _
        '                            Select x.fecha).Max _
        '                            And n.idAlmacen = intIdAlmacen _
        '                            And n.idItem = intIdItem _
        '                            And listaIVA.Contains(n.tipoConfiguracion) _
        '                            Select New With {
        '                                      .fecha = n.fecha, _
        '                                    .Modalidad = n.tipoConfiguracion, _
        '                                      .valorCompra = n.valcompraIgvMN, _
        '                                      .valorCompraSinIgv = n.valcompraSinIgvMN, _
        '                                        .isc = n.iscMN, _
        '                                        .montoUtilidad = n.montoUtilidad, _
        '                                      .montoutilidadSinIgv = n.utilidadsinIgvMN, _
        '                                        .ValorVenta = n.valorVentaMN, _
        '                         .PrecioVenta = n.precioVentaMN, _
        '                         .ImportemnDscto = n.montoDsctounitMenorMN, _
        '                         .ImportemnDsctoME = n.montoDsctounitMenorME, _
        '                         .VentaFinalmn = n.precioVentaFinalMenorMN, _
        '                         .VentaFinalmnME = n.precioVentaFinalMenorME, _
        '                         .ImportemyDscto = n.montoDsctounitMayorMN, _
        '                         .ImportemyDsctoME = n.montoDsctounitMayorME, _
        '                         .VentaFinalmy = n.precioVentaFinalMayorMN, _
        '                         .VentaFinalmyME = n.precioVentaFinalMayorME, _
        '                         .ImportegmyDscto = n.montoDsctounitGMayorMN, _
        '                         .ImportegmyDsctoME = n.montoDsctounitGMayorME, _
        '                         .VentaFinalgmy = n.precioVentaFinalGMayorMN, _
        '                         .VentaFinalgmyME = n.precioVentaFinalGMayorME, _
        '                         .DetalleMenor = n.detalleMenor, _
        '                         .DetalleMayor = n.detalleMayor, _
        '                         .DetalleGMayor = n.detalleGMayor, _
        '                     .porDescUnitMenor = n.PorDsctounitMenor, _
        '                                      .porDescUnitMayor = n.PorDsctounitMayor, _
        '                                      .porDescUnitGMayor = n.PorDsctounitGMayor
        '                        }).ToList


        'If Not IsNothing(obj) Then
        '    For Each q In obj
        '        objTablaDetalleBO = New listadoPrecios() With _
        '                               {
        '                                   .fecha = q.fecha, _
        '                                   .tipoConfiguracion = q.Modalidad, _
        '                                   .valcompraIgvMN = q.valorCompra, _
        '                                   .valcompraSinIgvMN = q.valorCompraSinIgv, _
        '                                   .iscMN = q.isc, _
        '                                   .montoUtilidad = q.montoUtilidad, _
        '                                   .utilidadsinIgvMN = q.montoutilidadSinIgv, _
        '                                   .valorVentaMN = q.ValorVenta, _
        '                                   .precioVentaMN = q.PrecioVenta, _
        '                                   .montoDsctounitMenorMN = q.ImportemnDscto, _
        '                                   .montoDsctounitMenorME = q.ImportemnDsctoME, _
        '                                   .precioVentaFinalMenorMN = q.VentaFinalmn, _
        '                                   .precioVentaFinalMenorME = q.VentaFinalmnME, _
        '                                   .montoDsctounitMayorMN = q.ImportemyDscto, _
        '                                   .montoDsctounitMayorME = q.ImportemyDsctoME, _
        '                                   .precioVentaFinalMayorMN = q.VentaFinalmy, _
        '                                   .precioVentaFinalMayorME = q.VentaFinalmyME, _
        '                                   .montoDsctounitGMayorMN = q.ImportegmyDscto, _
        '                                   .montoDsctounitGMayorME = q.ImportegmyDsctoME, _
        '                                   .precioVentaFinalGMayorMN = q.VentaFinalgmy, _
        '                                   .precioVentaFinalGMayorME = q.VentaFinalgmyME, _
        '                                   .detalleMenor = q.DetalleMenor, _
        '                                   .detalleMayor = q.DetalleMayor, _
        '                                   .detalleGMayor = q.DetalleGMayor, _
        '                               .PorDsctounitMenor = q.porDescUnitMenor, _
        '                                   .PorDsctounitMayor = q.porDescUnitMayor, _
        '                                   .PorDsctounitGMayor = q.porDescUnitGMayor _
        '                                }
        '        ListaProductos.Add(objTablaDetalleBO)
        '    Next
        'End If

        'ListaProductos = (objTablaDetalleBO)
        Return Nothing
    End Function

    Public Function UbicarVentaPorItemCSIVASL(ByVal intIdAlmacen As Integer, intIdItem As Integer, strIVA As String) As listadoPrecios
        Dim objTablaDetalleBO As New listadoPrecios

        'Dim q = (From n In HeliosData.listadoPrecios _
        '       Where (n.fecha) = (From x In HeliosData.listadoPrecios _
        '                         Where _
        '                            x.idAlmacen = intIdAlmacen _
        '                            And x.idItem = intIdItem _
        '                            And x.tipoConfiguracion = strIVA _
        '                            Select x.fecha).Max _
        '                            And n.idAlmacen = intIdAlmacen _
        '                            And n.idItem = intIdItem _
        '                            And n.tipoConfiguracion = strIVA _
        '                            Select New With {
        '                                      .fecha = n.fecha, _
        '                                    .Modalidad = n.tipoConfiguracion, _
        '                                      .valorCompra = n.valcompraIgvMN, _
        '                                      .valorCompraSinIgv = n.valcompraSinIgvMN, _
        '                                        .isc = n.iscMN, _
        '                                        .montoUtilidad = n.montoUtilidad, _
        '                                      .montoutilidadSinIgv = n.utilidadsinIgvMN, _
        '                                        .ValorVenta = n.valorVentaMN, _
        '                                      .IGV = n.igvMN, _
        '                         .PrecioVenta = n.precioVentaMN, _
        '                         .ImportemnDscto = n.montoDsctounitMenorMN, _
        '                         .ImportemnDsctoME = n.montoDsctounitMenorME, _
        '                         .VentaFinalmn = n.precioVentaFinalMenorMN, _
        '                         .VentaFinalmnME = n.precioVentaFinalMenorME, _
        '                         .ImportemyDscto = n.montoDsctounitMayorMN, _
        '                         .ImportemyDsctoME = n.montoDsctounitMayorME, _
        '                         .VentaFinalmy = n.precioVentaFinalMayorMN, _
        '                         .VentaFinalmyME = n.precioVentaFinalMayorME, _
        '                         .ImportegmyDscto = n.montoDsctounitGMayorMN, _
        '                         .ImportegmyDsctoME = n.montoDsctounitGMayorME, _
        '                         .VentaFinalgmy = n.precioVentaFinalGMayorMN, _
        '                         .VentaFinalgmyME = n.precioVentaFinalGMayorME, _
        '                         .DetalleMenor = n.detalleMenor, _
        '                         .DetalleMayor = n.detalleMayor, _
        '                         .DetalleGMayor = n.detalleGMayor, _
        '                     .porDescUnitMenor = n.PorDsctounitMenor, _
        '                                      .porDescUnitMayor = n.PorDsctounitMayor, _
        '                                      .porDescUnitGMayor = n.PorDsctounitGMayor
        '                        }).FirstOrDefault


        'If Not IsNothing(q) Then
        '    objTablaDetalleBO = New listadoPrecios() With _
        '                               {
        '                                   .fecha = q.fecha, _
        '                                   .tipoConfiguracion = q.Modalidad, _
        '                                   .valcompraIgvMN = q.valorCompra, _
        '                                   .valcompraSinIgvMN = q.valorCompraSinIgv, _
        '                                   .iscMN = q.isc, _
        '                                   .montoUtilidad = q.montoUtilidad, _
        '                                   .utilidadsinIgvMN = q.montoutilidadSinIgv, _
        '                                   .valorVentaMN = q.ValorVenta, _
        '                                   .precioVentaMN = q.PrecioVenta, _
        '                                    .igvMN = q.IGV, _
        '                                   .montoDsctounitMenorMN = q.ImportemnDscto, _
        '                                   .montoDsctounitMenorME = q.ImportemnDsctoME, _
        '                                   .precioVentaFinalMenorMN = q.VentaFinalmn, _
        '                                   .precioVentaFinalMenorME = q.VentaFinalmnME, _
        '                                   .montoDsctounitMayorMN = q.ImportemyDscto, _
        '                                   .montoDsctounitMayorME = q.ImportemyDsctoME, _
        '                                   .precioVentaFinalMayorMN = q.VentaFinalmy, _
        '                                   .precioVentaFinalMayorME = q.VentaFinalmyME, _
        '                                   .montoDsctounitGMayorMN = q.ImportegmyDscto, _
        '                                   .montoDsctounitGMayorME = q.ImportegmyDsctoME, _
        '                                   .precioVentaFinalGMayorMN = q.VentaFinalgmy, _
        '                                   .precioVentaFinalGMayorME = q.VentaFinalgmyME, _
        '                                   .detalleMenor = q.DetalleMenor, _
        '                                   .detalleMayor = q.DetalleMayor, _
        '                                   .detalleGMayor = q.DetalleGMayor, _
        '                               .PorDsctounitMenor = q.porDescUnitMenor, _
        '                                   .PorDsctounitMayor = q.porDescUnitMayor, _
        '                                   .PorDsctounitGMayor = q.porDescUnitGMayor _
        '                                }

        'End If

        'ListaProductos = (objTablaDetalleBO)
        Return objTablaDetalleBO
    End Function


    Public Function UbicarPVxItem(ByVal intIdAlmacen As Integer, intIdItem As Integer) As listadoPrecios
        Dim objTablaDetalleBO As New listadoPrecios

        'Dim q = (From n In HeliosData.listadoPrecios _
        '       Where (n.fecha) = (From x In HeliosData.listadoPrecios _
        '                         Where _
        '                            x.idAlmacen = intIdAlmacen _
        '                            And x.idItem = intIdItem _
        '                            Select x.fecha).Max _
        '                            And n.idAlmacen = intIdAlmacen _
        '                            And n.idItem = intIdItem).FirstOrDefault


        'If Not IsNothing(q) Then
        '    objTablaDetalleBO = New listadoPrecios() With _
        '                               {
        '                                   .fecha = q.fecha, _
        '                                   .tipoConfiguracion = q.tipoConfiguracion, _
        '                                   .vcmenor = q.vcmenor,
        '                                   .vcmenorme = q.vcmenorme,
        '                                   .vcmayor = q.vcmayor,
        '                                   .vcmayorme = q.vcmayorme,
        '                                   .vcgranmayor = q.vcgranmayor,
        '                                   .vcgranmayorme = q.vcgranmayorme,
        '                                   .porcUtimenor = q.porcUtimenor, _
        '                                   .porcUtimayor = q.porcUtimayor, _
        '                                   .porcUtigranmayor = q.porcUtigranmayor, _
        '                                   .montoUtimenor = q.montoUtimenor, _
        '                                   .montoUtimayor = q.montoUtimayor, _
        '                                   .montoUtigranmayor = q.montoUtigranmayor, _
        '                                   .vvmenor = q.vvmenor, _
        '                                   .vvmayor = q.vvmayor, _
        '                                   .vvgranmayor = q.vvgranmayor, _
        '                                   .igvmenor = q.igvmenor, _
        '                                   .igvmayor = q.igvmayor, _
        '                                   .igvgranmayor = q.igvgranmayor, _
        '                                   .pvmenor = q.pvmenor, _
        '                                   .pvmayor = q.pvmayor, _
        '                                   .pvgranmayor = q.pvgranmayor, _
        '                                   .montoUtimenorme = q.montoUtimenorme, _
        '                                   .montoUtimayorme = q.montoUtimayorme, _
        '                                   .montoUtigranmayorme = q.montoUtigranmayorme, _
        '                                   .vvmenorme = q.vvmenorme, _
        '                                   .vvmayorme = q.vvmayorme, _
        '                                   .vvgranmayorme = q.vvgranmayorme, _
        '                                   .igvmenormeme = q.igvmenormeme, _
        '                                   .igvmayormeme = q.igvmayormeme, _
        '                                   .igvgranmayorme = q.igvgranmayorme, _
        '                                   .pvmenorme = q.pvmenorme, _
        '                                   .pvmayorme = q.pvmayorme, _
        '                                   .pvgranmayorme = q.pvgranmayorme,
        '                                   .autoCodigo = q.autoCodigo
        '                                }

        'End If

        'ListaProductos = (objTablaDetalleBO)
        Return objTablaDetalleBO
    End Function

    Public Function UbicarPVxListadoItems(ByVal intIdAlmacen As Integer) As List(Of listadoPrecios)
        Dim objTablaDetalleBO As New listadoPrecios
        Dim listaBL As New listadoPrecios
        Dim listaPrec As New List(Of listadoPrecios)
        Dim taSA As New totalesAlmacenBL

        Dim xx = (From t In HeliosData.totalesAlmacen _
                  Join ite In HeliosData.detalleitems _
                  On t.idItem Equals ite.codigodetalle _
                  Where t.idAlmacen = intIdAlmacen).ToList


        For Each q In xx
            objTablaDetalleBO = New listadoPrecios()

            objTablaDetalleBO.idItem = q.t.idItem
            objTablaDetalleBO.descripcion = q.ite.descripcionItem
            objTablaDetalleBO.destinoGravado = q.ite.origenProducto
            objTablaDetalleBO.tipoExistencia = q.ite.tipoExistencia
            objTablaDetalleBO.stock = q.t.cantidad

            listaBL = taSA.UbicarPVxItem(intIdAlmacen, q.t.idItem)
            If Not IsNothing(listaBL.idEmpresa) Then
                With listaBL
                    objTablaDetalleBO.fecha = .fecha
                    objTablaDetalleBO.tipoConfiguracion = .tipoConfiguracion
                    objTablaDetalleBO.vcmenor = .vcmenor
                    objTablaDetalleBO.vcmenorme = .vcmenorme
                    objTablaDetalleBO.vcmayor = .vcmayor
                    objTablaDetalleBO.vcmayorme = .vcmayorme
                    objTablaDetalleBO.vcgranmayor = .vcgranmayor
                    objTablaDetalleBO.vcgranmayorme = .vcgranmayorme
                    objTablaDetalleBO.porcUtimenor = .porcUtimenor
                    objTablaDetalleBO.porcUtimayor = .porcUtimayor
                    objTablaDetalleBO.porcUtigranmayor = .porcUtigranmayor
                    objTablaDetalleBO.montoUtimenor = .montoUtimenor
                    objTablaDetalleBO.montoUtimayor = .montoUtimayor
                    objTablaDetalleBO.montoUtigranmayor = .montoUtigranmayor
                    objTablaDetalleBO.vvmenor = .vvmenor
                    objTablaDetalleBO.vvmayor = .vvmayor
                    objTablaDetalleBO.vvgranmayor = .vvgranmayor
                    objTablaDetalleBO.igvmenor = .igvmenor
                    objTablaDetalleBO.igvmayor = .igvmayor
                    objTablaDetalleBO.igvgranmayor = .igvgranmayor
                    objTablaDetalleBO.pvmenor = .pvmenor
                    objTablaDetalleBO.pvmayor = .pvmayor
                    objTablaDetalleBO.pvgranmayor = .pvgranmayor
                    objTablaDetalleBO.montoUtimenorme = .montoUtimenorme
                    objTablaDetalleBO.montoUtimayorme = .montoUtimayorme
                    objTablaDetalleBO.montoUtigranmayorme = .montoUtigranmayorme
                    objTablaDetalleBO.vvmenorme = .vvmenorme
                    objTablaDetalleBO.vvmayorme = .vvmayorme
                    objTablaDetalleBO.vvgranmayorme = .vvgranmayorme
                    objTablaDetalleBO.igvmenormeme = .igvmenormeme
                    objTablaDetalleBO.igvmayormeme = .igvmayormeme
                    objTablaDetalleBO.igvgranmayorme = .igvgranmayorme
                    objTablaDetalleBO.pvmenorme = .pvmenorme
                    objTablaDetalleBO.pvmayorme = .pvmayorme
                    objTablaDetalleBO.pvgranmayorme = .pvgranmayorme
                    objTablaDetalleBO.autoCodigo = .autoCodigo
                End With
            Else
                objTablaDetalleBO.fecha = Nothing
                objTablaDetalleBO.tipoConfiguracion = Nothing
                objTablaDetalleBO.vcmenor = 0
                objTablaDetalleBO.vcmenorme = 0
                objTablaDetalleBO.vcmayor = 0
                objTablaDetalleBO.vcmayorme = 0
                objTablaDetalleBO.vcgranmayor = 0
                objTablaDetalleBO.vcgranmayorme = 0
                objTablaDetalleBO.porcUtimenor = 0
                objTablaDetalleBO.porcUtimayor = 0
                objTablaDetalleBO.porcUtigranmayor = 0
                objTablaDetalleBO.montoUtimenor = 0
                objTablaDetalleBO.montoUtimayor = 0.0
                objTablaDetalleBO.montoUtigranmayor = 0.0
                objTablaDetalleBO.vvmenor = 0.0
                objTablaDetalleBO.vvmayor = 0.0
                objTablaDetalleBO.vvgranmayor = 0.0
                objTablaDetalleBO.igvmenor = 0.0
                objTablaDetalleBO.igvmayor = 0.0
                objTablaDetalleBO.igvgranmayor = 0.0
                objTablaDetalleBO.pvmenor = 0.0
                objTablaDetalleBO.pvmayor = 0.0
                objTablaDetalleBO.pvgranmayor = 0.0
                objTablaDetalleBO.montoUtimenorme = 0.0
                objTablaDetalleBO.montoUtimayorme = 0.0
                objTablaDetalleBO.montoUtigranmayorme = 0.0
                objTablaDetalleBO.vvmenorme = 0.0
                objTablaDetalleBO.vvmayorme = 0.0
                objTablaDetalleBO.vvgranmayorme = 0.0
                objTablaDetalleBO.igvmenormeme = 0.0
                objTablaDetalleBO.igvmayormeme = 0.0
                objTablaDetalleBO.igvgranmayorme = 0.0
                objTablaDetalleBO.pvmenorme = 0.0
                objTablaDetalleBO.pvmayorme = 0.0
                objTablaDetalleBO.pvgranmayorme = 0.0
                objTablaDetalleBO.autoCodigo = 0.0
            End If

            listaPrec.Add(objTablaDetalleBO)
        Next


        'Dim MaxFechaXItem = Aggregate p In HeliosData.listadoPrecios _
        '                       Where p.idAlmacen = intIdAlmacen _
        '                       And p.idItem = 100 _
        '                        Into maxFecha = Max(p.fecha)

        'For Each q In qq
        '    objTablaDetalleBO = New listadoPrecios() With _
        '                       {
        '                           .fecha = q.c.fecha, _
        '                           .idItem = q.t.idItem, _
        '                           .descripcion = q.t.descripcion, _
        '                           .destinoGravado = q.t.origenRecaudo, _
        '                           .tipoExistencia = q.t.tipoExistencia, _
        '                           .tipoConfiguracion = q.c.tipoConfiguracion, _
        '                           .vcmenor = q.c.vcmenor,
        '                           .vcmenorme = q.c.vcmenorme,
        '                           .vcmayor = q.c.vcmayor,
        '                           .vcmayorme = q.c.vcmayorme,
        '                           .vcgranmayor = q.c.vcgranmayor,
        '                           .vcgranmayorme = q.c.vcgranmayorme,
        '                           .porcUtimenor = q.c.porcUtimenor, _
        '                           .porcUtimayor = q.c.porcUtimayor, _
        '                           .porcUtigranmayor = q.c.porcUtigranmayor, _
        '                           .montoUtimenor = q.c.montoUtimenor, _
        '                           .montoUtimayor = q.c.montoUtimayor, _
        '                           .montoUtigranmayor = q.c.montoUtigranmayor, _
        '                           .vvmenor = q.c.vvmenor, _
        '                           .vvmayor = q.c.vvmayor, _
        '                           .vvgranmayor = q.c.vvgranmayor, _
        '                           .igvmenor = q.c.igvmenor, _
        '                           .igvmayor = q.c.igvmayor, _
        '                           .igvgranmayor = q.c.igvgranmayor, _
        '                           .pvmenor = q.c.pvmenor, _
        '                           .pvmayor = q.c.pvmayor, _
        '                           .pvgranmayor = q.c.pvgranmayor, _
        '                           .montoUtimenorme = q.c.montoUtimenorme, _
        '                           .montoUtimayorme = q.c.montoUtimayorme, _
        '                           .montoUtigranmayorme = q.c.montoUtigranmayorme, _
        '                           .vvmenorme = q.c.vvmenorme, _
        '                           .vvmayorme = q.c.vvmayorme, _
        '                           .vvgranmayorme = q.c.vvgranmayorme, _
        '                           .igvmenormeme = q.c.igvmenormeme, _
        '                           .igvmayormeme = q.c.igvmayormeme, _
        '                           .igvgranmayorme = q.c.igvgranmayorme, _
        '                           .pvmenorme = q.c.pvmenorme, _
        '                           .pvmayorme = q.c.pvmayorme, _
        '                           .pvgranmayorme = q.c.pvgranmayorme,
        '                            .autoCodigo = q.c.autoCodigo
        '                        }
        '    listaPrec.Add(objTablaDetalleBO)
        'Next


        'For Each q In qq


        'Next

        'ListaProductos = (objTablaDetalleBO)
        Return listaPrec
    End Function

    Public Sub InsertSL(ByVal listadoPrecio As List(Of listadoPrecios))
        Dim listPrecios As New listadoPrecios
        Using ts As New TransactionScope

            For Each listadoPreciosBE As listadoPrecios In listadoPrecio
                listPrecios = New listadoPrecios
                listPrecios.idEmpresa = listadoPreciosBE.idEmpresa
                listPrecios.idEstablecimiento = listadoPreciosBE.idEstablecimiento
                listPrecios.tipoExistencia = listadoPreciosBE.tipoExistencia
                listPrecios.destinoGravado = listadoPreciosBE.destinoGravado
                listPrecios.idItem = listadoPreciosBE.idItem
                listPrecios.descripcion = listadoPreciosBE.descripcion
                listPrecios.presentacion = listadoPreciosBE.presentacion
                listPrecios.unidad = listadoPreciosBE.unidad
                listPrecios.fecha = listadoPreciosBE.fecha
                listPrecios.valcompraIgvMN = listadoPreciosBE.valcompraIgvMN
                listPrecios.valcompraSinIgvMN = listadoPreciosBE.valcompraSinIgvMN
                listPrecios.valcompraIgvME = listadoPreciosBE.valcompraIgvME
                listPrecios.valcompraSinIgvME = listadoPreciosBE.valcompraSinIgvME
                listPrecios.tipoConfiguracion = listadoPreciosBE.tipoConfiguracion
                listPrecios.montoUtilidad = listadoPreciosBE.montoUtilidad
                listPrecios.montoUtilidadME = listadoPreciosBE.montoUtilidadME
                listPrecios.utilidadsinIgvMN = listadoPreciosBE.utilidadsinIgvMN
                listPrecios.valorVentaMN = listadoPreciosBE.valorVentaMN
                listPrecios.igvMN = listadoPreciosBE.igvMN
                listPrecios.iscMN = listadoPreciosBE.iscMN
                listPrecios.otcMN = listadoPreciosBE.otcMN
                listPrecios.precioVentaMN = listadoPreciosBE.precioVentaMN
                listPrecios.utilidadsinIgvME = listadoPreciosBE.utilidadsinIgvME
                listPrecios.valorVentaME = listadoPreciosBE.valorVentaME
                listPrecios.igvME = listadoPreciosBE.igvME
                listPrecios.iscME = listadoPreciosBE.iscME
                listPrecios.otcME = listadoPreciosBE.otcME
                listPrecios.precioVentaME = listadoPreciosBE.precioVentaME
                listPrecios.PorDsctounitMenor = listadoPreciosBE.PorDsctounitMenor
                listPrecios.montoDsctounitMenorMN = listadoPreciosBE.montoDsctounitMenorMN
                listPrecios.montoDsctounitMenorME = listadoPreciosBE.montoDsctounitMenorME
                listPrecios.precioVentaFinalMenorMN = listadoPreciosBE.precioVentaFinalMenorMN
                listPrecios.precioVentaFinalMenorME = listadoPreciosBE.precioVentaFinalMenorME
                listPrecios.PorDsctounitMayor = listadoPreciosBE.PorDsctounitMayor
                listPrecios.montoDsctounitMayorMN = listadoPreciosBE.montoDsctounitMayorMN
                listPrecios.montoDsctounitMayorME = listadoPreciosBE.montoDsctounitMayorME
                listPrecios.precioVentaFinalMayorMN = listadoPreciosBE.precioVentaFinalMayorMN
                listPrecios.precioVentaFinalMayorME = listadoPreciosBE.precioVentaFinalMayorME
                listPrecios.PorDsctounitGMayor = listadoPreciosBE.PorDsctounitGMayor
                listPrecios.montoDsctounitGMayorMN = listadoPreciosBE.montoDsctounitGMayorMN
                listPrecios.montoDsctounitGMayorME = listadoPreciosBE.montoDsctounitGMayorME
                listPrecios.precioVentaFinalGMayorMN = listadoPreciosBE.precioVentaFinalGMayorMN
                listPrecios.precioVentaFinalGMayorME = listadoPreciosBE.precioVentaFinalGMayorME
                listPrecios.detalleMenor = listadoPreciosBE.detalleMenor
                listPrecios.cantidadMenor = listadoPreciosBE.cantidadMenor
                listPrecios.detalleMayor = listadoPreciosBE.detalleMayor
                listPrecios.cantidadMayor = listadoPreciosBE.cantidadMayor
                listPrecios.detalleGMayor = listadoPreciosBE.detalleGMayor
                listPrecios.cantidadGMayor = listadoPreciosBE.cantidadGMayor
                listPrecios.usuarioActualizacion = listadoPreciosBE.usuarioActualizacion
                listPrecios.fechaActualizacion = listadoPreciosBE.fechaActualizacion

                HeliosData.listadoPrecios.Add(listPrecios)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function UbicarPrecioNuevo(ByVal intIdAlmacen As Integer, intIdItem As Integer, strIVA As String) As Decimal
        Dim objTablaDetalleBO As New listadoPrecios

        'Dim q = (From n In HeliosData.listadoPrecios _
        '       Where (n.fecha) = (From x In HeliosData.listadoPrecios _
        '                         Where _
        '                            x.idAlmacen = intIdAlmacen _
        '                            And x.idItem = intIdItem _
        '                            And x.tipoConfiguracion = strIVA _
        '                            Select x.fecha).Max _
        '                            And n.idAlmacen = intIdAlmacen _
        '                            And n.idItem = intIdItem _
        '                              And n.tipoConfiguracion = strIVA _
        '                            Select New With {
        '                                .montoUtilidad = n.montoUtilidad,
        '                                .valorCompraIGV = n.valcompraIgvMN
        '                                       }).FirstOrDefault

        'Dim valueMonto As Decimal = 0
        'If Not IsNothing(q) Then
        '    objTablaDetalleBO = New listadoPrecios
        '    If (q.montoUtilidad = 0) Then
        '        Return 0
        '    Else
        '        valueMonto = Math.Round(CDec((q.montoUtilidad * 100) / q.valorCompraIGV), 1)
        '        objTablaDetalleBO.montoUtilidad = valueMonto
        '    End If

        'End If
        'If (Not IsNothing(objTablaDetalleBO.montoUtilidad)) Then
        '    Return objTablaDetalleBO.montoUtilidad
        'Else
        '    Return 0
        'End If
        Return Nothing
    End Function


End Class
