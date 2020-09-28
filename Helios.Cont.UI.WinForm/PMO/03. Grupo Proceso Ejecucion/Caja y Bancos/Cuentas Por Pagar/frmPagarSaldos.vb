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

Public Class frmPagarSaldos
    Inherits frmMaster

#Region "Métodos"
    Public Sub CargarEntidadesXtipo(strTipo As String, strBusqueda As String)
        Dim entidadSA As New entidadSA
        Try

            Me.lstEntidades.DataSource = entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, strTipo, strBusqueda)
            Me.lstEntidades.DisplayMember = "nombreCompleto"
            Me.lstEntidades.ValueMember = "idEntidad"

        Catch ex As Exception

        End Try
    End Sub
#End Region

    Private Sub frmPagarSaldos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmPagarSaldos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
     
    End Sub

    Private Sub popupControlContainer1_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles popupControlContainer1.BeforePopup
        Me.popupControlContainer1.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub popupControlContainer1_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles popupControlContainer1.CloseUp
        Dim entidadSA As New entidadSA
        Dim cajaSA As New EstadosFinancierosSA
        If e.PopupCloseType = PopupCloseType.Done Then
            With entidadSA.UbicarEntidadPorID(lstEntidades.SelectedValue).First
                txtProveedorFilter.Text = .nombreCompleto
                txtProveedorFilter.Tag = .idEntidad
                txtNumProvFilter.Text = .nrodoc

                Dim customers As BaseCollection = BaseCollection.ListaPagosXproveedor(.idEntidad)
                Me.gridDataBoundGrid1.Binder.SetDataBinding(customers, "")
                Dim childrenLevel As GridHierarchyLevel = Me.gridDataBoundGrid1.Binder.AddRelation("Children")
                childrenLevel.ShowHeaders = False
                Me.gridDataBoundGrid1.Binder.RootHierarchyLevel.ShowHeaders = True

                childrenLevel.RowStyle.BackColor = SystemColors.Window
                Dim rootLevel As GridHierarchyLevel = Me.gridDataBoundGrid1.Binder.RootHierarchyLevel
                rootLevel.RowStyle.BackColor = SystemColors.Window
                Me.gridDataBoundGrid1.DefaultRowHeight = 18
                Me.gridDataBoundGrid1.DefaultColWidth = 70
                gridDataBoundGrid1.ShowTreeLines = True
            End With
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedorFilter.Focus()
        End If
    End Sub

    Private Sub txtProveedorFilter_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedorFilter.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtProveedorFilter.Text.Trim.Length > 0 Then
                popupControlContainer1.Font = New Font("Segoe UI", 8)
                Me.popupControlContainer1.ParentControl = Me.txtProveedorFilter
                Me.popupControlContainer1.ShowPopup(Point.Empty)
                CargarEntidadesXtipo(TIPO_ENTIDAD.PROVEEDOR, txtProveedorFilter.Text.Trim)
            End If
        End If
    End Sub

    Private Sub lstEntidades_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstEntidades.MouseDoubleClick
        If lstEntidades.SelectedItems.Count > 0 Then
            Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub lstEntidades_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstEntidades.SelectedIndexChanged

    End Sub
End Class