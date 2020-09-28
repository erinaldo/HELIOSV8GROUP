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
Public Class frmSituacionFinanciera1
    Inherits frmMaster

#Region "Métodos"
    Private Sub SituacionFinanciera()
        Dim movimiento As New List(Of movimiento)
        Dim movimientoSA As New MovimientoSA

        movimiento = movimientoSA.BalanceGeneralAnual(New asiento With {.fechaProceso = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Date.Day)})
        Me.gridSituacion(27, 5).Text = 0
        Me.gridSituacion(4, 4).Text = AnioGeneral
        Me.gridSituacion(5, 4).Text = Gempresas.IdEmpresaRuc
        Me.gridSituacion(6, 4).Text = Gempresas.NomEmpresa
        For Each i In movimiento
            Select Case i.cuenta
                Case "10"
                    Me.gridSituacion(12, 5).Text = i.debeSaldoS - i.haberSaldoS

                Case "11"
                    Me.gridSituacion(16, 5).Text = i.debeSaldoS - i.haberSaldoS

                Case "12"
                    Me.gridSituacion(17, 5).Text = i.debeSaldoS - i.haberSaldoS

                Case "13"
                    Me.gridSituacion(20, 5).Text = i.debeSaldoS - i.haberSaldoS

                Case "14"
                    Me.gridSituacion(21, 5).Text = i.debeSaldoS - i.haberSaldoS

                Case "15"
                    Me.gridSituacion(22, 5).Text = i.debeSaldoS - i.haberSaldoS

                Case "16"
                    Me.gridSituacion(23, 5).Text = i.debeSaldoS - i.haberSaldoS

                Case "17"
                    Me.gridSituacion(24, 5).Text = i.debeSaldoS - i.haberSaldoS

                Case "18"
                    Me.gridSituacion(25, 5).Text = i.debeSaldoS - i.haberSaldoS

                Case "19"
                    Me.gridSituacion(26, 5).Text = i.debeSaldoS - i.haberSaldoS

                Case "20", "21", "22", "23", "24", "25", "26", "27", "28", "29"
                    Me.gridSituacion(27, 5).Text += (i.debeSaldoS - i.haberSaldoS)

                Case "30"
                    Me.gridSituacion(35, 5).Text = i.debeSaldoS - i.haberSaldoS

                Case "31"
                    Me.gridSituacion(36, 5).Text = i.debeSaldoS - i.haberSaldoS

                Case "32"
                    Me.gridSituacion(37, 5).Text = i.debeSaldoS - i.haberSaldoS

                Case "33"
                    Me.gridSituacion(38, 5).Text = i.debeSaldoS - i.haberSaldoS

                Case "34"
                    Me.gridSituacion(39, 5).Text = i.debeSaldoS - i.haberSaldoS

                Case "35"
                    Me.gridSituacion(40, 5).Text = i.debeSaldoS - i.haberSaldoS

                Case "36"
                    Me.gridSituacion(41, 5).Text = i.debeSaldoS - i.haberSaldoS

                Case "37"
                    Me.gridSituacion(42, 5).Text = i.debeSaldoS - i.haberSaldoS

                Case "38"
                    Me.gridSituacion(43, 5).Text = i.debeSaldoS - i.haberSaldoS

                Case "39"
                    Me.gridSituacion(44, 5).Text = i.debeSaldoS - i.haberSaldoS

                Case "40"
                    Me.gridSituacion(28, 5).Text = i.debeSaldoS - i.haberSaldoS


                    'RESULTADOS DEL HABER

                Case "41"
                    Me.gridSituacion(15, 13).Text = i.haberSaldoS - i.debeSaldoS
                Case "42"
                    Me.gridSituacion(16, 13).Text = i.haberSaldoS - i.debeSaldoS

                Case "43"
                    Me.gridSituacion(18, 13).Text = i.haberSaldoS - i.debeSaldoS

                Case "44"
                    Me.gridSituacion(20, 13).Text = i.haberSaldoS - i.debeSaldoS

                Case "45"
                    Me.gridSituacion(21, 13).Text = i.haberSaldoS - i.debeSaldoS

                Case "46"
                    Me.gridSituacion(22, 13).Text = i.haberSaldoS - i.debeSaldoS

                Case "47"
                    Me.gridSituacion(23, 13).Text = i.haberSaldoS - i.debeSaldoS

                Case "48"
                    Me.gridSituacion(24, 13).Text = i.haberSaldoS - i.debeSaldoS

                Case "49"
                    Me.gridSituacion(25, 13).Text = i.haberSaldoS - i.debeSaldoS

                Case "50"
                    Me.gridSituacion(50, 13).Text = i.haberSaldoS - i.debeSaldoS

                Case "51"
                    Me.gridSituacion(51, 13).Text = i.haberSaldoS - i.debeSaldoS
                Case "52"
                    Me.gridSituacion(52, 13).Text = i.haberSaldoS - i.debeSaldoS
                Case "53"
                    Me.gridSituacion(53, 13).Text = i.haberSaldoS - i.debeSaldoS
                Case "54"
                    Me.gridSituacion(54, 13).Text = i.haberSaldoS - i.debeSaldoS
                Case "55"
                    Me.gridSituacion(55, 13).Text = i.haberSaldoS - i.debeSaldoS
                Case "56"
                    Me.gridSituacion(56, 13).Text = i.haberSaldoS - i.debeSaldoS
                Case "57"
                    Me.gridSituacion(57, 13).Text = i.haberSaldoS - i.debeSaldoS
                Case "58"
                    Me.gridSituacion(58, 13).Text = i.haberSaldoS - i.debeSaldoS
                Case "59"
                    Me.gridSituacion(59, 13).Text = i.haberSaldoS - i.debeSaldoS

            End Select

        Next

        Me.gridSituacion(32, 5).Format = "c"
        Me.gridSituacion(48, 5).Format = "c"
        Me.gridSituacion(63, 5).Format = "c"

        Me.gridSituacion(28, 13).Format = "c"
        Me.gridSituacion(45, 13).Format = "c"
        Me.gridSituacion(61, 13).Format = "c"
        Me.gridSituacion(63, 13).Format = "c"
    End Sub
#End Region

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        SituacionFinanciera()
    End Sub

    Private Sub frmSituacionFinanciera1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmSituacionFinanciera1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class