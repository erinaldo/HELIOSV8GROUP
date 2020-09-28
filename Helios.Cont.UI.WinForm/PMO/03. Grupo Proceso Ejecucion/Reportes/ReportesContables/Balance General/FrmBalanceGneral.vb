Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess

Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms

Imports Microsoft.Reporting.WinForms
Imports System.Security
Imports System.Security.Permissions

Public Class FrmBalanceGneral

    Property reportName As String
    Property reportData As Object
    Property subreportData As Object
    Property hasSubReport As Boolean
    Property nombreMainDS As String



#Region "metodos"


    Public Sub ConsultaReporteTotalesPorANio(strPeriodo As Integer)
        Dim movimientoSA As New MovimientoSA
        Dim compra As New List(Of movimiento)
        Dim mes(11) As Decimal

        Me.reportName = "Helios.Cont.Presentation.WinForm.rptActivoCorriente.rdlc"
        compra = movimientoSA.BuscarCuentasBalance(strPeriodo)
        ReportViewer1.KeepSessionAlive = True
        ReportViewer1.Reset()
        ReportViewer1.LocalReport.Refresh()
        ReportViewer1.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        ReportViewer1.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)


        Dim cuenta10 As Decimal
        cuenta10 = CDec(0.0)
        Dim cuenta11 As Decimal
        cuenta11 = CDec(0.0)
        Dim cuenta12 As Decimal
        cuenta12 = CDec(0.0)
        Dim cuenta422 As Decimal
        cuenta422 = CDec(0.0)
        Dim cuenta13 As Decimal
        cuenta13 = CDec(0.0)
        Dim cuenta14 As Decimal
        cuenta14 = CDec(0.0)
        Dim cuenta15 As Decimal
        cuenta15 = CDec(0.0)
        Dim cuenta16 As Decimal
        cuenta16 = CDec(0.0)
        Dim cuenta17 As Decimal
        cuenta17 = CDec(0.0)
        Dim cuenta18 As Decimal
        cuenta18 = CDec(0.0)
        Dim cuenta19 As Decimal
        cuenta19 = CDec(0.0)
        Dim cuenta20 As Decimal
        cuenta20 = CDec(0.0)
        Dim ActivoCorriente As Decimal
        ActivoCorriente = CDec(0.0)


        Dim cuenta40 As Decimal
        cuenta40 = CDec(0.0)

        'ult
        Dim cuenta40debe As Decimal
        cuenta40debe = CDec(0.0)

        Dim cuenta40haber As Decimal
        cuenta40haber = CDec(0.0)

        Dim debe40 As Decimal
        debe40 = CDec(0.0)


        Dim haber40 As Decimal
        haber40 = CDec(0.0)
        'ult



        Dim cuenta41 As Decimal
        cuenta41 = CDec(0.0)
        Dim cuenta42 As Decimal
        cuenta42 = CDec(0.0)
        Dim cuenta122 As Decimal
        cuenta122 = CDec(0.0)
        Dim cuenta43 As Decimal
        cuenta43 = CDec(0.0)
        Dim cuenta44 As Decimal
        cuenta44 = CDec(0.0)
        Dim cuenta45 As Decimal
        cuenta45 = CDec(0.0)
        Dim cuenta46 As Decimal
        cuenta46 = CDec(0.0)
        Dim cuenta47 As Decimal
        cuenta47 = CDec(0.0)
        Dim cuenta48 As Decimal
        cuenta48 = CDec(0.0)
        Dim cuenta49 As Decimal
        cuenta49 = CDec(0.0)
        Dim PasivoCorriente As Decimal
        PasivoCorriente = CDec(0.0)


        Dim PasivoNoCorriente As Decimal
        PasivoNoCorriente = CDec(0.0)

        Dim TotalPasivo As Decimal
        TotalPasivo = CDec(0.0)

        Dim cuenta30 As Decimal
        cuenta30 = CDec(0.0)
        Dim cuenta31 As Decimal
        cuenta31 = CDec(0.0)
        Dim cuenta32 As Decimal
        cuenta32 = CDec(0.0)
        Dim cuenta33 As Decimal
        cuenta33 = CDec(0.0)
        Dim cuenta34 As Decimal
        cuenta34 = CDec(0.0)
        Dim cuenta35 As Decimal
        cuenta35 = CDec(0.0)
        Dim cuenta36 As Decimal
        cuenta36 = CDec(0.0)
        Dim cuenta37 As Decimal
        cuenta37 = CDec(0.0)
        Dim cuenta38 As Decimal
        cuenta38 = CDec(0.0)
        Dim cuenta39 As Decimal
        cuenta39 = CDec(0.0)

        Dim totalactivonocorriente As Decimal
        totalactivonocorriente = CDec(0.0)

        Dim totalactivo As Decimal
        totalactivo = CDec(0.0)

        Dim cuenta50 As Decimal
        cuenta50 = CDec(0.0)
        Dim cuenta51 As Decimal
        cuenta51 = CDec(0.0)
        Dim cuenta52 As Decimal
        cuenta52 = CDec(0.0)
        Dim cuenta53 As Decimal
        cuenta53 = CDec(0.0)
        Dim cuenta54 As Decimal
        cuenta54 = CDec(0.0)
        Dim cuenta55 As Decimal
        cuenta55 = CDec(0.0)
        Dim cuenta56 As Decimal
        cuenta56 = CDec(0.0)
        Dim cuenta57 As Decimal
        cuenta57 = CDec(0.0)
        Dim cuenta58 As Decimal
        cuenta58 = CDec(0.0)
        Dim cuenta59 As Decimal
        cuenta59 = CDec(0.0)
        'Dim cuenta39 As Decimal
        'cuenta39 = CDec(0.0)

        Dim totalpatrimonio As Decimal
        totalpatrimonio = CDec(0.0)

        Dim totalPasPatr As Decimal
        totalPasPatr = CDec(0.0)



        For Each i In compra

            If Mid((i.cuenta), 1, 2) = "10" Then
                cuenta10 += i.monto
            ElseIf Mid((i.cuenta), 1, 2) = "11" Then
                cuenta11 += i.monto
            ElseIf Mid((i.cuenta), 1, 2) = "12" Then

                If i.cuenta = "122" Then   'observar
                    cuenta122 = i.monto
                    cuenta12 += i.monto
                Else                        'observar
                    cuenta12 += i.monto
                End If                      'observar

            ElseIf i.cuenta = "422" Then
                cuenta422 += i.monto
            ElseIf Mid((i.cuenta), 1, 2) = "13" Then
                cuenta13 += i.monto
            ElseIf Mid((i.cuenta), 1, 2) = "14" Then
                cuenta14 += i.monto
            ElseIf Mid((i.cuenta), 1, 2) = "15" Then
                cuenta15 += i.monto
            ElseIf Mid((i.cuenta), 1, 2) = "16" Then
                cuenta16 += i.monto
            ElseIf Mid((i.cuenta), 1, 2) = "17" Then
                cuenta17 += i.monto
            ElseIf Mid((i.cuenta), 1, 2) = "18" Then
                cuenta18 += i.monto
            ElseIf Mid((i.cuenta), 1, 2) = "19" Then
                cuenta19 += i.monto
            ElseIf Mid((i.cuenta), 1, 1) = "2" Then
                cuenta20 += i.monto
            ElseIf Mid((i.cuenta), 1, 2) = "40" Then


                If i.tipo = "D" Then
                    cuenta40debe += i.monto
                ElseIf i.tipo = "H" Then
                    cuenta40haber += i.monto
                End If




            ElseIf Mid((i.cuenta), 1, 2) = "41" Then
                cuenta41 += i.monto
            ElseIf Mid((i.cuenta), 1, 2) = "42" Then
                cuenta42 += i.monto
            ElseIf Mid((i.cuenta), 1, 2) = "43" Then
                cuenta43 += i.monto
            ElseIf Mid((i.cuenta), 1, 2) = "44" Then
                cuenta44 += i.monto
            ElseIf Mid((i.cuenta), 1, 2) = "45" Then
                cuenta45 += i.monto
            ElseIf Mid((i.cuenta), 1, 2) = "46" Then
                cuenta46 += i.monto
            ElseIf Mid((i.cuenta), 1, 2) = "47" Then
                cuenta47 += i.monto
                PasivoNoCorriente += i.monto
            ElseIf Mid((i.cuenta), 1, 2) = "48" Then
                cuenta48 += i.monto
            ElseIf Mid((i.cuenta), 1, 2) = "49" Then
                cuenta49 += i.monto

            ElseIf Mid((i.cuenta), 1, 2) = "30" Then
                cuenta30 += i.monto
            ElseIf Mid((i.cuenta), 1, 2) = "31" Then
                cuenta31 += i.monto
            ElseIf Mid((i.cuenta), 1, 2) = "32" Then
                cuenta32 += i.monto
            ElseIf Mid((i.cuenta), 1, 2) = "33" Then
                cuenta33 += i.monto
            ElseIf Mid((i.cuenta), 1, 2) = "34" Then
                cuenta34 += i.monto
            ElseIf Mid((i.cuenta), 1, 2) = "35" Then
                cuenta35 += i.monto
            ElseIf Mid((i.cuenta), 1, 2) = "36" Then
                cuenta36 += i.monto
            ElseIf Mid((i.cuenta), 1, 2) = "37" Then
                cuenta37 += i.monto
            ElseIf Mid((i.cuenta), 1, 2) = "38" Then
                cuenta38 += i.monto
            ElseIf Mid((i.cuenta), 1, 2) = "39" Then
                cuenta39 += i.monto
            ElseIf Mid((i.cuenta), 1, 2) = "50" Then
                cuenta50 += i.monto
            ElseIf Mid((i.cuenta), 1, 2) = "51" Then
                cuenta51 += i.monto
            ElseIf Mid((i.cuenta), 1, 2) = "52" Then
                cuenta52 += i.monto
            ElseIf Mid((i.cuenta), 1, 2) = "53" Then
                cuenta53 += i.monto
            ElseIf Mid((i.cuenta), 1, 2) = "54" Then
                cuenta54 += i.monto
            ElseIf Mid((i.cuenta), 1, 2) = "55" Then
                cuenta55 += i.monto
            ElseIf Mid((i.cuenta), 1, 2) = "56" Then
                cuenta56 += i.monto
            ElseIf Mid((i.cuenta), 1, 2) = "57" Then
                cuenta57 += i.monto
            ElseIf Mid((i.cuenta), 1, 2) = "58" Then
                cuenta58 += i.monto
            ElseIf Mid((i.cuenta), 1, 2) = "59" Then
                cuenta59 += i.monto

            End If

        Next

        'AQUI

        cuenta40 += cuenta40debe - cuenta40haber

        If cuenta40 > 0 Then
            debe40 = cuenta40
            haber40 = CDec(0.0)
        ElseIf cuenta40 < 0 Then
            haber40 = (cuenta40 * (-1))
            debe40 = CDec(0.0)
        End If


        'OJO


        'ActivoCorriente = (cuenta10 + cuenta11 + cuenta12 + cuenta422 + cuenta13 + cuenta14 + cuenta15 + cuenta16 + cuenta17 +
        '    cuenta18 + cuenta19 + cuenta20)
        ActivoCorriente = (cuenta10 + cuenta11 + cuenta12 + cuenta422 + cuenta13 + cuenta14 + cuenta15 + cuenta16 + cuenta17 +
            cuenta18 + cuenta19 + cuenta20 + debe40)



        'PasivoCorriente = (cuenta40 + cuenta41 + cuenta42 + cuenta43 + cuenta44 + cuenta45 + cuenta46 + cuenta47 + cuenta48 + cuenta49)
        PasivoCorriente = (haber40 + cuenta41 + cuenta42 + cuenta43 + cuenta44 + cuenta45 + cuenta46 + cuenta47 + cuenta48 + cuenta49)


        TotalPasivo = PasivoNoCorriente + PasivoCorriente

        totalactivonocorriente = (cuenta30 + cuenta31 + cuenta32 + cuenta33 + cuenta34 + cuenta35 + cuenta36 + cuenta37 + cuenta38 + cuenta39)

        totalactivo = ActivoCorriente + totalactivonocorriente

        totalpatrimonio = (cuenta50 + cuenta51 + cuenta52 + cuenta53 + cuenta54 + cuenta55 + cuenta56 + cuenta57 + cuenta58 + cuenta59)

        totalPasPatr = totalpatrimonio + TotalPasivo

        oParams.Add(New ReportParameter("rpEfectEqui", cuenta10))
        oParams.Add(New ReportParameter("rpInverFinan", cuenta11))
        oParams.Add(New ReportParameter("rpCuenCobra", cuenta12))
        oParams.Add(New ReportParameter("rpAntiProve", cuenta422))
        oParams.Add(New ReportParameter("rpCuenCobraComer", cuenta13))
        oParams.Add(New ReportParameter("rpCuenCobraPers", cuenta14))
        oParams.Add(New ReportParameter("rpCuenta15", cuenta15))
        oParams.Add(New ReportParameter("rpCuenDiverTer", cuenta16))
        oParams.Add(New ReportParameter("rpCuenDiverRel", cuenta17))
        oParams.Add(New ReportParameter("rpServContra", cuenta18))
        oParams.Add(New ReportParameter("rpEstCueCobr", cuenta19))
        oParams.Add(New ReportParameter("rpInventarios", cuenta20))
        oParams.Add(New ReportParameter("rpActivoCorriente", ActivoCorriente))

        'oParams.Add(New ReportParameter("rpTributoApor", cuenta40))
        oParams.Add(New ReportParameter("rpTributoApor", haber40))

        oParams.Add(New ReportParameter("rpTribuApor", debe40))


        oParams.Add(New ReportParameter("rpRemuParti", cuenta41))
        oParams.Add(New ReportParameter("rpCuenPaga", cuenta42))
        oParams.Add(New ReportParameter("rpAntiClie", cuenta122))   'observarr
        oParams.Add(New ReportParameter("rpCuenPagaRel", cuenta43))
        oParams.Add(New ReportParameter("rpCuenPagaAcc", cuenta44))
        oParams.Add(New ReportParameter("rpObliFinan", cuenta45))
        oParams.Add(New ReportParameter("rpCuePagaDiv", cuenta46))
        oParams.Add(New ReportParameter("rpCuePagaDivRel", cuenta47))
        oParams.Add(New ReportParameter("rpProvisiones", cuenta48))
        oParams.Add(New ReportParameter("rpPasivoDif", cuenta49))
        oParams.Add(New ReportParameter("rpPasivoCorriente", PasivoCorriente))

        oParams.Add(New ReportParameter("rpPasNoCorriente", PasivoNoCorriente))

        oParams.Add(New ReportParameter("rpTotalPasivo", TotalPasivo))


        oParams.Add(New ReportParameter("rpInverMobi", cuenta30))
        oParams.Add(New ReportParameter("rpInverInmo", cuenta31))
        oParams.Add(New ReportParameter("rpActAdquiA", cuenta32))
        oParams.Add(New ReportParameter("rpInmuMaqui", cuenta33))
        oParams.Add(New ReportParameter("rpIntagibles", cuenta34))
        oParams.Add(New ReportParameter("rpActBio", cuenta35))
        oParams.Add(New ReportParameter("rpDesvInmo", cuenta36))
        oParams.Add(New ReportParameter("rpActDife", cuenta37))
        oParams.Add(New ReportParameter("rpOtroAct", cuenta38))
        oParams.Add(New ReportParameter("rpDepreAmor", cuenta39))

        oParams.Add(New ReportParameter("rpTotalActivoNoCorriente", totalactivonocorriente))

        oParams.Add(New ReportParameter("rpTotalActivo", totalactivo))

        oParams.Add(New ReportParameter("rpCapital", cuenta50))
        oParams.Add(New ReportParameter("rpAccionInver", cuenta51))
        oParams.Add(New ReportParameter("rpCapitalAd", cuenta52))
        oParams.Add(New ReportParameter("rpCuenta53", cuenta53))
        oParams.Add(New ReportParameter("rpCuenta54", cuenta54))
        oParams.Add(New ReportParameter("rpCuenta55", cuenta55))
        oParams.Add(New ReportParameter("rpResultNoReal", cuenta56))
        oParams.Add(New ReportParameter("rpExceReval", cuenta57))
        oParams.Add(New ReportParameter("rpReservas", cuenta58))
        oParams.Add(New ReportParameter("rpResultAcumu", cuenta59))
        oParams.Add(New ReportParameter("rpResultPerio", cuenta59))

        oParams.Add(New ReportParameter("rpTotalPatrominio", totalpatrimonio))

        oParams.Add(New ReportParameter("rpTotalPasivoYPatri", totalPasPatr))

        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        oParams.Add(New ReportParameter("rpPeriodo", AnioGeneral))



        ReportViewer1.LocalReport.SetParameters(oParams)
        ReportViewer1.RefreshReport()
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.Percent
        ReportViewer1.ZoomPercent = 100
    End Sub

    'Public Sub ConsultaReporteTotalesPorANio(strPeriodo As Integer)
    '    Dim movimientoSA As New MovimientoSA
    '    Dim compra As New List(Of movimiento)
    '    Dim mes(11) As Decimal

    '    Me.reportName = "Helios.Cont.Presentation.WinForm.rptActivoCorriente.rdlc"
    '    compra = movimientoSA.BuscarCuentasFull(strPeriodo)
    '    ReportViewer1.KeepSessionAlive = True
    '    ReportViewer1.Reset()
    '    ReportViewer1.LocalReport.Refresh()
    '    ReportViewer1.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
    '    ReportViewer1.LocalReport.ReportEmbeddedResource = reportName
    '    Dim oParams As New List(Of ReportParameter)


    '    Dim cuenta10 As Decimal
    '    cuenta10 = CDec(0.0)
    '    Dim cuenta11 As Decimal
    '    cuenta11 = CDec(0.0)
    '    Dim cuenta12 As Decimal
    '    cuenta12 = CDec(0.0)
    '    Dim cuenta422 As Decimal
    '    cuenta422 = CDec(0.0)
    '    Dim cuenta13 As Decimal
    '    cuenta13 = CDec(0.0)
    '    Dim cuenta14 As Decimal
    '    cuenta14 = CDec(0.0)
    '    Dim cuenta15 As Decimal
    '    cuenta15 = CDec(0.0)
    '    Dim cuenta16 As Decimal
    '    cuenta16 = CDec(0.0)
    '    Dim cuenta17 As Decimal
    '    cuenta17 = CDec(0.0)
    '    Dim cuenta18 As Decimal
    '    cuenta18 = CDec(0.0)
    '    Dim cuenta19 As Decimal
    '    cuenta19 = CDec(0.0)
    '    Dim cuenta20 As Decimal
    '    cuenta20 = CDec(0.0)
    '    Dim ActivoCorriente As Decimal
    '    ActivoCorriente = CDec(0.0)


    '    Dim cuenta40 As Decimal
    '    cuenta40 = CDec(0.0)
    '    Dim cuenta41 As Decimal
    '    cuenta41 = CDec(0.0)
    '    Dim cuenta42 As Decimal
    '    cuenta42 = CDec(0.0)
    '    Dim cuenta122 As Decimal
    '    cuenta122 = CDec(0.0)
    '    Dim cuenta43 As Decimal
    '    cuenta43 = CDec(0.0)
    '    Dim cuenta44 As Decimal
    '    cuenta44 = CDec(0.0)
    '    Dim cuenta45 As Decimal
    '    cuenta45 = CDec(0.0)
    '    Dim cuenta46 As Decimal
    '    cuenta46 = CDec(0.0)
    '    Dim cuenta47 As Decimal
    '    cuenta47 = CDec(0.0)
    '    Dim cuenta48 As Decimal
    '    cuenta48 = CDec(0.0)
    '    Dim cuenta49 As Decimal
    '    cuenta49 = CDec(0.0)
    '    Dim PasivoCorriente As Decimal
    '    PasivoCorriente = CDec(0.0)


    '    Dim PasivoNoCorriente As Decimal
    '    PasivoNoCorriente = CDec(0.0)

    '    Dim TotalPasivo As Decimal
    '    TotalPasivo = CDec(0.0)

    '    Dim cuenta30 As Decimal
    '    cuenta30 = CDec(0.0)
    '    Dim cuenta31 As Decimal
    '    cuenta31 = CDec(0.0)
    '    Dim cuenta32 As Decimal
    '    cuenta32 = CDec(0.0)
    '    Dim cuenta33 As Decimal
    '    cuenta33 = CDec(0.0)
    '    Dim cuenta34 As Decimal
    '    cuenta34 = CDec(0.0)
    '    Dim cuenta35 As Decimal
    '    cuenta35 = CDec(0.0)
    '    Dim cuenta36 As Decimal
    '    cuenta36 = CDec(0.0)
    '    Dim cuenta37 As Decimal
    '    cuenta37 = CDec(0.0)
    '    Dim cuenta38 As Decimal
    '    cuenta38 = CDec(0.0)
    '    Dim cuenta39 As Decimal
    '    cuenta39 = CDec(0.0)

    '    Dim totalactivonocorriente As Decimal
    '    totalactivonocorriente = CDec(0.0)

    '    Dim totalactivo As Decimal
    '    totalactivo = CDec(0.0)

    '    Dim cuenta50 As Decimal
    '    cuenta50 = CDec(0.0)
    '    Dim cuenta51 As Decimal
    '    cuenta51 = CDec(0.0)
    '    Dim cuenta52 As Decimal
    '    cuenta52 = CDec(0.0)
    '    Dim cuenta53 As Decimal
    '    cuenta53 = CDec(0.0)
    '    Dim cuenta54 As Decimal
    '    cuenta54 = CDec(0.0)
    '    Dim cuenta55 As Decimal
    '    cuenta55 = CDec(0.0)
    '    Dim cuenta56 As Decimal
    '    cuenta56 = CDec(0.0)
    '    Dim cuenta57 As Decimal
    '    cuenta57 = CDec(0.0)
    '    Dim cuenta58 As Decimal
    '    cuenta58 = CDec(0.0)
    '    Dim cuenta59 As Decimal
    '    cuenta59 = CDec(0.0)
    '    'Dim cuenta39 As Decimal
    '    'cuenta39 = CDec(0.0)

    '    Dim totalpatrimonio As Decimal
    '    totalpatrimonio = CDec(0.0)

    '    Dim totalPasPatr As Decimal
    '    totalPasPatr = CDec(0.0)



    '    For Each i In compra

    '        If Mid((i.cuenta), 1, 2) = "10" Then
    '            cuenta10 += i.monto
    '        ElseIf Mid((i.cuenta), 1, 2) = "11" Then
    '            cuenta11 += i.monto
    '        ElseIf Mid((i.cuenta), 1, 2) = "12" Then

    '            If i.cuenta = "122" Then   'observar
    '                cuenta122 = i.monto
    '                cuenta12 += i.monto
    '            Else                        'observar
    '                cuenta12 += i.monto
    '            End If                      'observar

    '        ElseIf i.cuenta = "422" Then
    '            cuenta422 += i.monto
    '        ElseIf Mid((i.cuenta), 1, 2) = "13" Then
    '            cuenta13 += i.monto
    '        ElseIf Mid((i.cuenta), 1, 2) = "14" Then
    '            cuenta14 += i.monto
    '        ElseIf Mid((i.cuenta), 1, 2) = "15" Then
    '            cuenta15 += i.monto
    '        ElseIf Mid((i.cuenta), 1, 2) = "16" Then
    '            cuenta16 += i.monto
    '        ElseIf Mid((i.cuenta), 1, 2) = "17" Then
    '            cuenta17 += i.monto
    '        ElseIf Mid((i.cuenta), 1, 2) = "18" Then
    '            cuenta18 += i.monto
    '        ElseIf Mid((i.cuenta), 1, 2) = "19" Then
    '            cuenta19 += i.monto
    '        ElseIf Mid((i.cuenta), 1, 1) = "2" Then
    '            cuenta20 += i.monto
    '        ElseIf Mid((i.cuenta), 1, 2) = "40" Then
    '            cuenta40 += i.monto
    '        ElseIf Mid((i.cuenta), 1, 2) = "41" Then
    '            cuenta41 += i.monto
    '        ElseIf Mid((i.cuenta), 1, 2) = "42" Then
    '            cuenta42 += i.monto
    '        ElseIf Mid((i.cuenta), 1, 2) = "43" Then
    '            cuenta43 += i.monto
    '        ElseIf Mid((i.cuenta), 1, 2) = "44" Then
    '            cuenta44 += i.monto
    '        ElseIf Mid((i.cuenta), 1, 2) = "45" Then
    '            cuenta45 += i.monto
    '        ElseIf Mid((i.cuenta), 1, 2) = "46" Then
    '            cuenta46 += i.monto
    '        ElseIf Mid((i.cuenta), 1, 2) = "47" Then
    '            cuenta47 += i.monto
    '            PasivoNoCorriente += i.monto
    '        ElseIf Mid((i.cuenta), 1, 2) = "48" Then
    '            cuenta48 += i.monto
    '        ElseIf Mid((i.cuenta), 1, 2) = "49" Then
    '            cuenta49 += i.monto

    '        ElseIf Mid((i.cuenta), 1, 2) = "30" Then
    '            cuenta30 += i.monto
    '        ElseIf Mid((i.cuenta), 1, 2) = "31" Then
    '            cuenta31 += i.monto
    '        ElseIf Mid((i.cuenta), 1, 2) = "32" Then
    '            cuenta32 += i.monto
    '        ElseIf Mid((i.cuenta), 1, 2) = "33" Then
    '            cuenta33 += i.monto
    '        ElseIf Mid((i.cuenta), 1, 2) = "34" Then
    '            cuenta34 += i.monto
    '        ElseIf Mid((i.cuenta), 1, 2) = "35" Then
    '            cuenta35 += i.monto
    '        ElseIf Mid((i.cuenta), 1, 2) = "36" Then
    '            cuenta36 += i.monto
    '        ElseIf Mid((i.cuenta), 1, 2) = "37" Then
    '            cuenta37 += i.monto
    '        ElseIf Mid((i.cuenta), 1, 2) = "38" Then
    '            cuenta38 += i.monto
    '        ElseIf Mid((i.cuenta), 1, 2) = "39" Then
    '            cuenta39 += i.monto

    '        ElseIf Mid((i.cuenta), 1, 2) = "50" Then
    '            cuenta50 += i.monto
    '        ElseIf Mid((i.cuenta), 1, 2) = "51" Then
    '            cuenta51 += i.monto
    '        ElseIf Mid((i.cuenta), 1, 2) = "52" Then
    '            cuenta52 += i.monto
    '        ElseIf Mid((i.cuenta), 1, 2) = "53" Then
    '            cuenta53 += i.monto
    '        ElseIf Mid((i.cuenta), 1, 2) = "54" Then
    '            cuenta54 += i.monto
    '        ElseIf Mid((i.cuenta), 1, 2) = "55" Then
    '            cuenta55 += i.monto
    '        ElseIf Mid((i.cuenta), 1, 2) = "56" Then
    '            cuenta56 += i.monto
    '        ElseIf Mid((i.cuenta), 1, 2) = "57" Then
    '            cuenta57 += i.monto
    '        ElseIf Mid((i.cuenta), 1, 2) = "58" Then
    '            cuenta58 += i.monto
    '        ElseIf Mid((i.cuenta), 1, 2) = "59" Then
    '            cuenta59 += i.monto



    '        End If

    '    Next

    '    ActivoCorriente = (cuenta10 + cuenta11 + cuenta12 + cuenta422 + cuenta13 + cuenta14 + cuenta15 + cuenta16 + cuenta17 +
    '        cuenta18 + cuenta19 + cuenta20)

    '    PasivoCorriente = (cuenta40 + cuenta41 + cuenta42 + cuenta43 + cuenta44 + cuenta45 + cuenta46 + cuenta47 + cuenta48 + cuenta49)

    '    TotalPasivo = PasivoNoCorriente + PasivoCorriente

    '    totalactivonocorriente = (cuenta30 + cuenta31 + cuenta32 + cuenta33 + cuenta34 + cuenta35 + cuenta36 + cuenta37 + cuenta38 + cuenta39)

    '    totalactivo = ActivoCorriente + totalactivonocorriente

    '    totalpatrimonio = (cuenta50 + cuenta51 + cuenta52 + cuenta53 + cuenta54 + cuenta55 + cuenta56 + cuenta57 + cuenta58 + cuenta59)

    '    totalPasPatr = totalpatrimonio + TotalPasivo

    '    oParams.Add(New ReportParameter("rpEfectEqui", cuenta10))
    '    oParams.Add(New ReportParameter("rpInverFinan", cuenta11))
    '    oParams.Add(New ReportParameter("rpCuenCobra", cuenta12))
    '    oParams.Add(New ReportParameter("rpAntiProve", cuenta422))
    '    oParams.Add(New ReportParameter("rpCuenCobraComer", cuenta13))
    '    oParams.Add(New ReportParameter("rpCuenCobraPers", cuenta14))
    '    oParams.Add(New ReportParameter("rpCuenta15", cuenta15))
    '    oParams.Add(New ReportParameter("rpCuenDiverTer", cuenta16))
    '    oParams.Add(New ReportParameter("rpCuenDiverRel", cuenta17))
    '    oParams.Add(New ReportParameter("rpServContra", cuenta18))
    '    oParams.Add(New ReportParameter("rpEstCueCobr", cuenta19))
    '    oParams.Add(New ReportParameter("rpInventarios", cuenta20))
    '    oParams.Add(New ReportParameter("rpActivoCorriente", ActivoCorriente))

    '    oParams.Add(New ReportParameter("rpTributoApor", cuenta40))
    '    oParams.Add(New ReportParameter("rpRemuParti", cuenta41))
    '    oParams.Add(New ReportParameter("rpCuenPaga", cuenta42))
    '    oParams.Add(New ReportParameter("rpAntiClie", cuenta122))   'observarr
    '    oParams.Add(New ReportParameter("rpCuenPagaRel", cuenta43))
    '    oParams.Add(New ReportParameter("rpCuenPagaAcc", cuenta44))
    '    oParams.Add(New ReportParameter("rpObliFinan", cuenta45))
    '    oParams.Add(New ReportParameter("rpCuePagaDiv", cuenta46))
    '    oParams.Add(New ReportParameter("rpCuePagaDivRel", cuenta47))
    '    oParams.Add(New ReportParameter("rpProvisiones", cuenta48))
    '    oParams.Add(New ReportParameter("rpPasivoDif", cuenta49))
    '    oParams.Add(New ReportParameter("rpPasivoCorriente", PasivoCorriente))

    '    oParams.Add(New ReportParameter("rpPasNoCorriente", PasivoNoCorriente))

    '    oParams.Add(New ReportParameter("rpTotalPasivo", TotalPasivo))


    '    oParams.Add(New ReportParameter("rpInverMobi", cuenta30))
    '    oParams.Add(New ReportParameter("rpInverInmo", cuenta31))
    '    oParams.Add(New ReportParameter("rpActAdquiA", cuenta32))
    '    oParams.Add(New ReportParameter("rpInmuMaqui", cuenta33))
    '    oParams.Add(New ReportParameter("rpIntagibles", cuenta34))
    '    oParams.Add(New ReportParameter("rpActBio", cuenta35))
    '    oParams.Add(New ReportParameter("rpDesvInmo", cuenta36))
    '    oParams.Add(New ReportParameter("rpActDife", cuenta37))
    '    oParams.Add(New ReportParameter("rpOtroAct", cuenta38))
    '    oParams.Add(New ReportParameter("rpDepreAmor", cuenta39))

    '    oParams.Add(New ReportParameter("rpTotalActivoNoCorriente", totalactivonocorriente))

    '    oParams.Add(New ReportParameter("rpTotalActivo", totalactivo))

    '    oParams.Add(New ReportParameter("rpCapital", cuenta50))
    '    oParams.Add(New ReportParameter("rpAccionInver", cuenta51))
    '    oParams.Add(New ReportParameter("rpCapitalAd", cuenta52))
    '    oParams.Add(New ReportParameter("rpCuenta53", cuenta53))
    '    oParams.Add(New ReportParameter("rpCuenta54", cuenta54))
    '    oParams.Add(New ReportParameter("rpCuenta55", cuenta55))
    '    oParams.Add(New ReportParameter("rpResultNoReal", cuenta56))
    '    oParams.Add(New ReportParameter("rpExceReval", cuenta57))
    '    oParams.Add(New ReportParameter("rpReservas", cuenta58))
    '    oParams.Add(New ReportParameter("rpResultAcumu", cuenta59))
    '    oParams.Add(New ReportParameter("rpResultPerio", cuenta59))

    '    oParams.Add(New ReportParameter("rpTotalPatrominio", totalpatrimonio))

    '    oParams.Add(New ReportParameter("rpTotalPasivoYPatri", totalPasPatr))

    '    oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
    '    oParams.Add(New ReportParameter("rpPeriodo", AnioGeneral))



    '    ReportViewer1.LocalReport.SetParameters(oParams)
    '    ReportViewer1.RefreshReport()
    '    ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
    '    ReportViewer1.ZoomMode = ZoomMode.Percent
    '    ReportViewer1.ZoomPercent = 100
    'End Sub

#End Region


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'BuscarMovimientosFull(AnioGeneral)
        ConsultaReporteTotalesPorANio(AnioGeneral)

        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
