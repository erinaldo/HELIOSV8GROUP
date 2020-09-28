Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Drawing
Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Imports System.ComponentModel
Imports System.Threading
Imports ProcesosGeneralesCajamiSoft
Imports System.Net
Imports System.IO

Public Class frmDashBoardDetalle
    Inherits frmMaster

    Private TabCH_GetCuentasCobrar As TabCH_GetCuentasCobrar
    Private TabCH_GetVenta As TabCH_GetVenta

    Public Sub New(TIPO As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        LLAMAR(TIPO)

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Sub LLAMAR(TIPO As String)

        If (TIPO = "CC") Then
            pnBody.Controls.Clear()
            TabCH_GetCuentasCobrar = New TabCH_GetCuentasCobrar With {.Dock = DockStyle.Fill}
            pnBody.Controls.Add(TabCH_GetCuentasCobrar)
            TabCH_GetCuentasCobrar.Visible = True
        ElseIf (TIPO = "VT") Then
            pnBody.Controls.Clear()
            TabCH_GetVenta = New TabCH_GetVenta With {.Dock = DockStyle.Fill}
            pnBody.Controls.Add(TabCH_GetVenta)
            TabCH_GetVenta.Visible = True
        End If



    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Try
            Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class