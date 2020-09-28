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

Public Class FrmInventariosBalances


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

        Me.reportName = "Helios.Cont.Presentation.WinForm.rptInventarioBalance.rdlc"
        compra = movimientoSA.BuscarCuentasFull(strPeriodo)
        ReportViewer1.KeepSessionAlive = True
        ReportViewer1.Reset()
        ReportViewer1.LocalReport.Refresh()
        ReportViewer1.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        ReportViewer1.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)

        Dim cuenta70 As Decimal
        cuenta70 = CDec(0.0)
        Dim cuenta73 As Decimal
        cuenta73 = CDec(0.0)
        Dim cuenta74 As Decimal
        cuenta74 = CDec(0.0)
        Dim totalIngreBruto As Decimal
        totalIngreBruto = CDec(0.0)
        Dim cuenta69 As Decimal
        cuenta69 = CDec(0.0)
        Dim utilidadBruta As Decimal
        utilidadBruta = CDec(0.0)
        Dim cuenta94 As Decimal
        cuenta94 = CDec(0.0)
        Dim cuenta95 As Decimal
        cuenta95 = CDec(0.0)
        Dim cuenta96 As Decimal
        cuenta96 = CDec(0.0)
        Dim cuenta97 As Decimal
        cuenta97 = CDec(0.0)
        Dim utilidadoperativa As Decimal
        utilidadoperativa = CDec(0.0)
        Dim cuenta77 As Decimal
        cuenta77 = CDec(0.0)
        Dim cuenta67 As Decimal
        cuenta67 = CDec(0.0)
        Dim cuenta75 As Decimal
        cuenta75 = CDec(0.0)
        Dim cuenta76 As Decimal
        cuenta76 = CDec(0.0)


        Dim otroingre As Decimal
        otroingre = CDec(0.0)

        Dim resultImp As Decimal
        resultImp = CDec(0.0)
        



        For Each i In compra

            If Mid((i.cuenta), 1, 2) = "70" Then
                cuenta70 += i.monto
            ElseIf Mid((i.cuenta), 1, 2) = "73" Then
                cuenta73 += i.monto
            ElseIf Mid((i.cuenta), 1, 2) = "74" Then
                cuenta74 += i.monto

            ElseIf Mid((i.cuenta), 1, 2) = "69" Then
                cuenta69 += i.monto
            ElseIf Mid((i.cuenta), 1, 2) = "94" Then
                cuenta94 += i.monto
            ElseIf Mid((i.cuenta), 1, 2) = "95" Then
                cuenta95 += i.monto
            ElseIf Mid((i.cuenta), 1, 2) = "96" Then
                cuenta96 += i.monto
            ElseIf Mid((i.cuenta), 1, 2) = "97" Then
                cuenta97 += i.monto

            ElseIf Mid((i.cuenta), 1, 2) = "77" Then
                cuenta77 += i.monto
            ElseIf Mid((i.cuenta), 1, 2) = "67" Then
                cuenta67 += i.monto
            ElseIf Mid((i.cuenta), 1, 1) = "75" Then
                cuenta75 += i.monto
            ElseIf Mid((i.cuenta), 1, 2) = "76" Then
                cuenta76 += i.monto
           




            End If

        Next


        otroingre = (cuenta75 + cuenta76)

        totalIngreBruto = (cuenta70 + cuenta73 + cuenta74)

        utilidadBruta = (totalIngreBruto - cuenta69)

        utilidadoperativa = (utilidadBruta - cuenta94 - cuenta95 - cuenta96 - cuenta97)

        resultImp = (utilidadoperativa + cuenta77 + cuenta67 + otroingre)

        

        oParams.Add(New ReportParameter("rpCuenta70", cuenta70))
        oParams.Add(New ReportParameter("rpCuenta73", cuenta73))
        oParams.Add(New ReportParameter("rpCuenta74", cuenta74))
        oParams.Add(New ReportParameter("rpTotIngresoBruto", totalIngreBruto))
        oParams.Add(New ReportParameter("rpcuenta69", cuenta69))
        oParams.Add(New ReportParameter("rpUtilidadBruta", utilidadBruta))
        oParams.Add(New ReportParameter("rpCuenta94", cuenta94))
        oParams.Add(New ReportParameter("rpCuenta95", cuenta95))
        oParams.Add(New ReportParameter("rpCuenta96", cuenta96))
        oParams.Add(New ReportParameter("rpCuenta97", cuenta97))
        oParams.Add(New ReportParameter("rpUtilidadOperativa", utilidadoperativa))
        oParams.Add(New ReportParameter("rpCuenta77", cuenta77))
        oParams.Add(New ReportParameter("rpCuenta67", cuenta67))
        oParams.Add(New ReportParameter("rpCuenta7576", otroingre))
        oParams.Add(New ReportParameter("rpRentaParti", resultImp))
        
       



        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        oParams.Add(New ReportParameter("rpPeriodo", AnioGeneral))



        ReportViewer1.LocalReport.SetParameters(oParams)
        ReportViewer1.RefreshReport()
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.Percent
        ReportViewer1.ZoomPercent = 100
    End Sub

#End Region


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ConsultaReporteTotalesPorANio(AnioGeneral)
        Me.ReportViewer1.RefreshReport()

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click



    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
