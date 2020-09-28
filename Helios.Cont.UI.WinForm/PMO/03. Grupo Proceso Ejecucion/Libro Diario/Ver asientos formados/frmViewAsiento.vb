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
Imports Syncfusion.Windows.Forms.Tools
Public Class frmViewAsiento
    Inherits frmMaster

    Public Sub New(ListaMov As List(Of movimiento))

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        LLenarGrid(ListaMov)
    End Sub

#Region "Métodos"
    Sub LLenarGrid(ListaMovimiento As List(Of movimiento))
        For i As Integer = 0 To ListaMovimiento.Count - 1

            For j As Integer = 0 To 6
                Select Case ListaMovimiento(i).tipo
                    Case "D"
                        Select Case j
                            Case 0
                                Me.GridControl1(i + 3, j + 1).CellValue = ListaMovimiento(i).cuenta
                            Case 1
                                Me.GridControl1(i + 3, j + 1).CellValue = ListaMovimiento(i).nombreEntidad
                            Case 2
                                Me.GridControl1(i + 3, j + 1).CellValue = ListaMovimiento(i).descripcion
                            Case 3
                                Me.GridControl1(i + 3, j + 1).CellValue = ListaMovimiento(i).monto
                            Case 4
                                Me.GridControl1(i + 3, j + 1).CellValue = 0
                            Case 5
                                Me.GridControl1(i + 3, j + 1).CellValue = ListaMovimiento(i).montoUSD
                            Case 6
                                Me.GridControl1(i + 3, j + 1).CellValue = 0
                        End Select

                    Case "H"
                        Select Case j
                            Case 0
                                Me.GridControl1(i + 3, j + 1).CellValue = ListaMovimiento(i).cuenta
                            Case 1
                                Me.GridControl1(i + 3, j + 1).CellValue = ListaMovimiento(i).nombreEntidad
                            Case 2
                                Me.GridControl1(i + 3, j + 1).CellValue = ListaMovimiento(i).descripcion
                            Case 3
                                Me.GridControl1(i + 3, j + 1).CellValue = 0
                            Case 4
                                Me.GridControl1(i + 3, j + 1).CellValue = ListaMovimiento(i).monto
                            Case 5
                                Me.GridControl1(i + 3, j + 1).CellValue = 0
                            Case 6
                                Me.GridControl1(i + 3, j + 1).CellValue = ListaMovimiento(i).montoUSD
                        End Select


                End Select
                ' Me.gridControl1(i + 2, 1).CellValue = documentoVenta(i).tipoVenta


            Next
        Next
    End Sub
#End Region

    Private Sub frmViewAsiento_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmViewAsiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class