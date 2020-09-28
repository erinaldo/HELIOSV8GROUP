Imports Helios.Planilla.Business.Entity
Imports Helios.Planilla.WCFService.ServiceAccess
Imports Syncfusion.Grouping

Public Class FrmConceptosLocSistema

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        SelConcepto = Nothing
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dim r As Record = dgvConceptos.Table.CurrentRecord
        If Not IsNothing(r) Then
            SelConcepto = "[" + r.GetValue("DescripcionCorta") + "]"
            Close()
        End If
    End Sub

    Private Sub FrmConceptosLocSistema_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim servicio As New VariablesDelSistemaSA
        Dim listaVariables = servicio.VariablesDelSistemaSelxID(New VariablesDelSistema With {.TipoConcepto = "01"})

        dgvConceptos.DataSource = listaVariables
        dgvConceptos.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub

    Private Sub FrmConceptosLocSistema_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ' ButtonAdv2_Click()
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        SelConcepto = Nothing
    End Sub
End Class