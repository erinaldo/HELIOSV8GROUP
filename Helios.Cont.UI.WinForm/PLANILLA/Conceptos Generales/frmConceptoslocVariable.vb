Imports Helios.Planilla.Business.Entity
Imports Helios.Planilla.General.Constantes
Imports Helios.Planilla.WCFService.ServiceAccess
Imports Syncfusion.Grouping

Public Class frmConceptoslocVariable

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        SelConcepto = Nothing
    End Sub

    Private Sub GetConceptos(idconcepto As String)
        Dim servicio As New ConceptoSA
        Dim listaConceptoIngresos = servicio.ConceptoSelxTipoConcepto(New Concepto With {.TipoConcepto = idconcepto})

        dgvConceptos.DataSource = listaConceptoIngresos
        dgvConceptos.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub

    Private Sub frmConceptoslocVariable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Listados As New TablaDetalleSA
        Dim lstTipoConcepto = Listados.TablaDetalleSelxTabla(New TablaDetalle With {.IDTabla = 1020})

        cboTipoConcepto.DataSource = lstTipoConcepto
        cboTipoConcepto.ValueMember = "DescripcionCorta"
        cboTipoConcepto.DisplayMember = "DescripcionLarga"
        GetConceptos(PlanillaConceptos.Ingresos)
    End Sub

    Private Sub cboTipoConcepto_Click(sender As Object, e As EventArgs) Handles cboTipoConcepto.Click

    End Sub

    Private Sub cboTipoConcepto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoConcepto.SelectedIndexChanged
        GetConceptos(cboTipoConcepto.SelectedValue.ToString)
    End Sub



    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dim r As Record = dgvConceptos.Table.CurrentRecord
        If Not IsNothing(r) Then
            SelConcepto = "[" + r.GetValue("DescripcionCorta") + "]"
            Close()
        End If
    End Sub

    Private Sub frmConceptoslocVariable_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'ButtonAdv2_Click(sender, e)
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        SelConcepto = Nothing
    End Sub
End Class