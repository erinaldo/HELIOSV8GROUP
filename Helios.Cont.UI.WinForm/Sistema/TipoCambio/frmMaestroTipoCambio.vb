Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Tools
Imports System.Collections
Imports Syncfusion.Windows.Forms.Grid
Imports System.Collections.Specialized
Imports Syncfusion.Grouping
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid.Grouping
Public Class frmMaestroTipoCambio
    Inherits frmMaster

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ObtenerHistorial()
        ' Add any initialization after the InitializeComponent() call.

    End Sub
#Region "Métodos"
    Private Function getTableTipoCambio() As DataTable
        Dim tcSA As New tipoCambioSA

        Dim dt As New DataTable("Historial tipo de cambio ")

        dt.Columns.Add(New DataColumn("fechaIgv", GetType(String)))
        dt.Columns.Add(New DataColumn("compra", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("venta", GetType(Decimal)))

        Dim str As String
        For Each i As tipoCambio In tcSA.GetListar_tipoCambio()
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaIgv).ToString("dd-MM-yyyy hh:mm tt ")
            dr(0) = str
            dr(1) = i.compra
            dr(2) = i.venta
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Public Sub ObtenerHistorial()
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim grupoActual As String = String.Empty
        Dim g As New ListViewGroup
        Try

            Dim parentTable As DataTable = getTableTipoCambio()
            Me.dgvDoc.DataSource = parentTable
            dgvDoc.TableDescriptor.Relations.Clear()
            dgvDoc.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            dgvDoc.TableOptions.ListBoxSelectionMode = SelectionMode.One
            dgvDoc.Appearance.AnyRecordFieldCell.Enabled = False
            dgvDoc.GroupDropPanel.Visible = True
            dgvDoc.TableDescriptor.GroupedColumns.Clear()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
#End Region

    Private Sub frmMaestroTipoCambio_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub
End Class