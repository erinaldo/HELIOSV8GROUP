Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports System.ComponentModel
Imports Syncfusion.Windows.Forms.Tools
Public Class frmEstadoDeResultados
    Inherits frmMaster


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        EstadosResultadosByFuncion()
    End Sub

#Region "Métodos"
    Private Sub EstadosResultadosByFuncion()
        Dim movimiento As New List(Of movimiento)
        Dim movimientoSA As New MovimientoSA

        movimiento = movimientoSA.BalanceGeneralAnual(New asiento With {.fechaProceso = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Date.Day)})
        Me.GridControl2(32, 7).Text = 0
        Me.GridControl2(8, 4).Text = AnioGeneral
        Me.GridControl2(9, 4).Text = Gempresas.IdEmpresaRuc
        Me.GridControl2(10, 4).Text = Gempresas.NomEmpresa
        For Each i In movimiento
            Select Case i.cuenta
                Case "70"
                    Me.GridControl2(14, 7).Text = i.haberSaldoS - i.debeSaldoS

                Case "73"
                    Me.GridControl2(15, 7).Text = i.haberSaldoS - i.debeSaldoS

                Case "74"
                    Me.GridControl2(16, 7).Text = i.debeSaldoS - i.haberSaldoS

                Case "69"
                    Me.GridControl2(19, 7).Text = i.debeSaldoS - i.haberSaldoS

                Case "94"
                    Me.GridControl2(23, 7).Text = i.debeSaldoS - i.haberSaldoS

                Case "95"
                    Me.GridControl2(24, 7).Text = i.debeSaldoS - i.haberSaldoS

                Case "96"
                    Me.GridControl2(25, 7).Text = i.debeSaldoS - i.haberSaldoS

                Case "97"
                    Me.GridControl2(26, 7).Text = i.debeSaldoS - i.haberSaldoS

                Case "77"
                    Me.GridControl2(30, 7).Text = i.haberSaldoS - i.debeSaldoS

                Case "75", "76"
                    Me.GridControl2(32, 7).Text += (i.haberSaldoS - i.debeSaldoS)

            End Select

        Next

        Me.GridControl2(17, 7).Format = "c"
        Me.GridControl2(20, 7).Format = "c"
        Me.GridControl2(27, 7).Format = "c"

        Me.GridControl2(39, 7).Format = "c"
        Me.GridControl2(41, 7).Format = "c"
    End Sub
#End Region

    Private Sub frmEstadoDeResultados_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmEstadoDeResultados_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class