Imports Microsoft.Reporting.WinForms
Imports System.Security
Imports System.Security.Permissions
Imports Helios.Cont.Business.Entity
Imports Helios.General
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmArqueoCaja
    Inherits frmMaster

    Property reportName As String
    Property reportData As Object
    Property subreportData As Object
    Property hasSubReport As Boolean
    Property nombreMainDS As String
    Public Property TipoCaja() As String


    Public Sub ConsultaReporte(intIdCajaUsuario As Integer)
        Dim cajaSa As New DocumentoCajaSA
        Dim cajausuarioSA As New cajaUsuarioSA
        Dim cajausuarioDetalleSA As New cajaUsuarioDetalleSA
        Dim efSA As New EstadosFinancierosSA
        Dim personaSA As New UsuarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Dim totalVentasme As Decimal = 0
        Dim fondoMn As Decimal = 0
        Dim fondoMe As Decimal = 0
        Dim codUsuarioSeguridad As Integer

        Me.reportName = "Helios.Cont.Presentation.WinForm.rptArqueoCaja.rdlc"
        '   Me.reportData = objTicket
        '   Me.nombreMainDS = "DSEstrategias"

        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCaja.KeepSessionAlive = True
        rptCaja.Reset()
        rptCaja.LocalReport.DataSources.Add(reporte)
        rptCaja.LocalReport.Refresh()
        rptCaja.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCaja.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpEstablecimiento", GEstableciento.NombreEstablecimiento))
        With cajausuarioSA.UbicarCajaUsuarioPorID(intIdCajaUsuario)
            codUsuarioSeguridad = .idPersona
         

            With efSA.GetUbicar_estadosFinancierosPorID(.idCajaOrigen)
                oParams.Add(New ReportParameter("rpCaja", .descripcion))
            End With
            With personaSA.UbicarUsuarioXid(New Usuario With {.IDUsuario = codUsuarioSeguridad})
                oParams.Add(New ReportParameter("rpOperador", .Full_Name))
            End With

            oParams.Add(New ReportParameter("rpFondoCajamn", .fondoMN))
            fondoMn = .fondoMN
            oParams.Add(New ReportParameter("rpFondoCajame", .fondoME))
            fondoMe = .fondoME
            'oParams.Add(New ReportParameter("rpIngresosmn", .ingresoAdicMN))
            'oParams.Add(New ReportParameter("rpIngresosme", .ingresoAdicME))

            'oParams.Add(New ReportParameter("rpEgresosmn", .otrosEgresosMN * -1))
            'oParams.Add(New ReportParameter("rpEgresosme", .otrosEgresosME * -1))
        End With

        For Each i As documentoCaja In cajaSa.GetObtenerCierreCajasModulos(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, PeriodoGeneral, codUsuarioSeguridad)
            Select Case i.codigoLibro
                Case "12.1"
                    oParams.Add(New ReportParameter("rpVentaTicketBol", i.montoSoles))
                    totalVentas += i.montoSoles
                    totalVentasme += i.montoUsd
                Case "12.2"
                    oParams.Add(New ReportParameter("rpVentaTicketFac", i.montoSoles))
                    totalVentas += i.montoSoles
                    totalVentasme += i.montoUsd
                Case "02"
                    oParams.Add(New ReportParameter("rpEgresosmn", i.montoSoles))
                    oParams.Add(New ReportParameter("rpEgresosme", i.montoUsd))
            End Select
        Next
        'For Each i In cajausuarioDetalleSA.ListaDetallePorCaja(intIdCajaUsuario)
        '    Select Case i.tipoVenta
        '        Case TIPO_VENTA.VENTA_AL_TICKET
        '            If i.tipoDoc = "03" Then
        '                oParams.Add(New ReportParameter("rpVentaTicketBol", i.importeMN))
        '                totalVentas += i.importeMN
        '            ElseIf i.tipoDoc = "01" Then
        '                oParams.Add(New ReportParameter("rpVentaTicketFac", i.importeMN))
        '                totalVentas += i.importeMN
        '            End If

        '        Case TIPO_VENTA.VENTA_AL_TICKET_DIRECTA
        '            If i.tipoDoc = "03" Then
        '                oParams.Add(New ReportParameter("rpVentaTicketDirBol", i.importeMN))
        '                totalVentas += i.importeMN
        '            ElseIf i.tipoDoc = "01" Then
        '                oParams.Add(New ReportParameter("rpVentaTicketDirFac", i.importeMN))
        '                totalVentas += i.importeMN
        '            End If

        '        Case TIPO_VENTA.VENTA_PAGADA
        '            If i.tipoDoc = "03" Then
        '                oParams.Add(New ReportParameter("rpVentasBoleta", i.importeMN))
        '                totalVentas += i.importeMN
        '            ElseIf i.tipoDoc = "01" Then
        '                oParams.Add(New ReportParameter("rpVentasFactura", i.importeMN))
        '                totalVentas += i.importeMN
        '            End If
        '        Case TIPO_COMPRA.COMPRA_PAGADA
        '            'oParams.Add(New ReportParameter("rpEgresosmn", i.importeMN * -1))
        '            'oParams.Add(New ReportParameter("rpEgresosme", i.importeME * -1))
        '    End Select
        'Next
        oParams.Add(New ReportParameter("rpTotalVenta", totalVentas))
        oParams.Add(New ReportParameter("rpIngresosmn", totalVentas))
        oParams.Add(New ReportParameter("rpIngresosme", totalVentasme))


        totalUtilidad = CDec(fondoMn) + CDec(totalVentas) - CDec(0)
        totalUtilidadme = CDec(fondoMe) + CDec(totalVentasme) - CDec(0)
        oParams.Add(New ReportParameter("rpUtilidadMN", totalUtilidad))
        oParams.Add(New ReportParameter("rpUtilidadME", totalUtilidadme))

        rptCaja.LocalReport.SetParameters(oParams)
        rptCaja.RefreshReport()
        rptCaja.SetDisplayMode(DisplayMode.PrintLayout)
        rptCaja.ZoomMode = ZoomMode.Percent
        rptCaja.ZoomPercent = 100
    End Sub

    Public Sub ConsultaReportePadre(intIdCajaUsuario As Integer)
        Dim cajaSa As New DocumentoCajaSA
        Dim documentoCaja As New documentoCaja
        Dim cajausuarioSA As New cajaUsuarioSA
        Dim cajausuarioDetalleSA As New cajaUsuarioDetalleSA
        Dim efSA As New EstadosFinancierosSA
        Dim personaSA As New UsuarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Dim totalVentasme As Decimal = 0
        Dim fondoMn As Decimal = 0
        Dim fondoMe As Decimal = 0
        Dim codUsuarioSeguridad As Integer = 0

        Me.reportName = "Helios.Cont.Presentation.WinForm.ArqueoCajaFull.rdlc"
        '   Me.reportData = objTicket
        '   Me.nombreMainDS = "DSEstrategias"

        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCaja.KeepSessionAlive = True
        rptCaja.Reset()
        rptCaja.LocalReport.DataSources.Add(reporte)
        rptCaja.LocalReport.Refresh()
        rptCaja.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCaja.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpEstablecimiento", GEstableciento.NombreEstablecimiento))
        With cajausuarioSA.UbicarCajaUsuarioPorID(intIdCajaUsuario)

            codUsuarioSeguridad = .idPersona

            With efSA.GetUbicar_estadosFinancierosPorID(.idCajaOrigen)
                oParams.Add(New ReportParameter("rpCaja", .descripcion))
            End With
            With personaSA.UbicarUsuarioXid(New Usuario With {.IDUsuario = codUsuarioSeguridad})
                oParams.Add(New ReportParameter("rpOperador", .Full_Name))
            End With

            oParams.Add(New ReportParameter("rpFondoCajamn", .fondoMN))
            fondoMn = .fondoMN
            oParams.Add(New ReportParameter("rpFondoCajame", .fondoME))
            fondoMe = .fondoME
            'oParams.Add(New ReportParameter("rpIngresosmn", .ingresoAdicMN))
            'oParams.Add(New ReportParameter("rpIngresosme", .ingresoAdicME))

            'oParams.Add(New ReportParameter("rpEgresosmn", .otrosEgresosMN * -1))
            'oParams.Add(New ReportParameter("rpEgresosme", .otrosEgresosME * -1))
        End With

        documentoCaja = cajaSa.ResumenTransaccionesUsuarios(intIdCajaUsuario, "PG")
        oParams.Add(New ReportParameter("rpUserEgresosmn", documentoCaja.montoSoles))
        oParams.Add(New ReportParameter("rpUserEgresosme", documentoCaja.montoUsd))


        documentoCaja = cajaSa.ResumenTransaccionesUsuarios(intIdCajaUsuario, "CB")
        oParams.Add(New ReportParameter("rpUserIngresosmn", documentoCaja.montoSoles))
        oParams.Add(New ReportParameter("rpUserIngresosme", documentoCaja.montoUsd))
       
        Dim egresos As Decimal = 0
        Dim egresosme As Decimal = 0


        Dim ingresos As Decimal = 0
        Dim ingresosme As Decimal = 0
        For Each i As documentoCaja In cajaSa.GetObtenerCierreCajasModulos(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, PeriodoGeneral, codUsuarioSeguridad)
            Select Case i.codigoLibro
                Case "12.1"
                    oParams.Add(New ReportParameter("rpVentaTicketBol", i.montoSoles))
                    totalVentas += i.montoSoles
                    totalVentasme += i.montoUsd
                Case "12.2"
                    oParams.Add(New ReportParameter("rpVentaTicketFac", i.montoSoles))
                    totalVentas += i.montoSoles
                    totalVentasme += i.montoUsd
                Case "02", "9907", "104", "100"
                    egresos += i.montoSoles
                    egresosme += i.montoUsd

                Case "01", "101", "103", "9908"
                    ingresos += i.montoSoles
                    ingresosme += i.montoUsd
            End Select
        Next


        oParams.Add(New ReportParameter("rpEgresosmn", egresos))
        oParams.Add(New ReportParameter("rpEgresosme", egresosme))

        oParams.Add(New ReportParameter("rpIngresosmn", ingresos))
        oParams.Add(New ReportParameter("rpIngresosme", ingresosme))
        'For Each i In cajausuarioDetalleSA.ListaDetallePorCaja(intIdCajaUsuario)
        '    Select Case i.tipoVenta
        '        Case TIPO_VENTA.VENTA_AL_TICKET
        '            If i.tipoDoc = "03" Then
        '                oParams.Add(New ReportParameter("rpVentaTicketBol", i.importeMN))
        '                totalVentas += i.importeMN
        '            ElseIf i.tipoDoc = "01" Then
        '                oParams.Add(New ReportParameter("rpVentaTicketFac", i.importeMN))
        '                totalVentas += i.importeMN
        '            End If

        '        Case TIPO_VENTA.VENTA_AL_TICKET_DIRECTA
        '            If i.tipoDoc = "03" Then
        '                oParams.Add(New ReportParameter("rpVentaTicketDirBol", i.importeMN))
        '                totalVentas += i.importeMN
        '            ElseIf i.tipoDoc = "01" Then
        '                oParams.Add(New ReportParameter("rpVentaTicketDirFac", i.importeMN))
        '                totalVentas += i.importeMN
        '            End If

        '        Case TIPO_VENTA.VENTA_PAGADA
        '            If i.tipoDoc = "03" Then
        '                oParams.Add(New ReportParameter("rpVentasBoleta", i.importeMN))
        '                totalVentas += i.importeMN
        '            ElseIf i.tipoDoc = "01" Then
        '                oParams.Add(New ReportParameter("rpVentasFactura", i.importeMN))
        '                totalVentas += i.importeMN
        '            End If
        '        Case TIPO_COMPRA.COMPRA_PAGADA
        '            'oParams.Add(New ReportParameter("rpEgresosmn", i.importeMN * -1))
        '            'oParams.Add(New ReportParameter("rpEgresosme", i.importeME * -1))
        '    End Select
        'Next
        oParams.Add(New ReportParameter("rpTotalVenta", totalVentas))
        oParams.Add(New ReportParameter("rpIngresosmn", totalVentas))
        oParams.Add(New ReportParameter("rpIngresosme", totalVentasme))


        totalUtilidad = CDec(fondoMn) + CDec(totalVentas) - CDec(0)
        totalUtilidadme = CDec(fondoMe) + CDec(totalVentasme) - CDec(0)
        oParams.Add(New ReportParameter("rpUtilidadMN", totalUtilidad))
        oParams.Add(New ReportParameter("rpUtilidadME", totalUtilidadme))

        rptCaja.LocalReport.SetParameters(oParams)
        rptCaja.RefreshReport()
        rptCaja.SetDisplayMode(DisplayMode.PrintLayout)
        rptCaja.ZoomMode = ZoomMode.Percent
        rptCaja.ZoomPercent = 100
    End Sub

    Private Sub frmArqueoCaja_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmArqueoCaja_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
      
    End Sub
End Class