Imports Helios.Planilla.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping

Public Class frmModalConceptosSelect
#Region "Attributes"
    Public Property ConceptoSA As New ConceptoSA
    Public Property TablaSA As New TablaDetalleSA
#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        ConfiguracionInicio()
        FormatoGridPequeño(dgConceptos, True)
        GetComboConceptos()
    End Sub

#End Region

#Region "Methods"
    Private Sub ConfiguracionInicio()
        dgConceptos.TableDescriptor.Columns("IDConcepto").HeaderText = "ID"
        dgConceptos.TableDescriptor.Columns("DescripcionCorta").HeaderText = "Abrev."
        dgConceptos.TableDescriptor.Columns("DescripcionLarga").HeaderText = "Descripción"
    End Sub

    Private Sub GetComboConceptos()
        Dim lstConceptos = TablaSA.TablaDetalleSelxTabla(New Planilla.Business.Entity.TablaDetalle With {.IDTabla = 1020})

        cboTipoConcepto.DataSource = lstConceptos
        cboTipoConcepto.ValueMember = "IDTablaDetalle"
        cboTipoConcepto.DisplayMember = "DescripcionLarga"
    End Sub

    Private Sub GetConceptosXPadre(TipoConcepto As String)
        Dim listaConceptos = ConceptoSA.ConceptoSelxTipoConcepto(New Planilla.Business.Entity.Concepto With {.TipoConcepto = TipoConcepto})
        dgConceptos.DataSource = listaConceptos
    End Sub
#End Region

#Region "Events"
    Private Sub cboTipoPlanilla_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboTipoConcepto.SelectedValueChanged
        If cboTipoConcepto.Text.Trim.Length > 0 Then
            GetConceptosXPadre(cboTipoConcepto.SelectedValue.ToString)
        End If
    End Sub

    Private Sub dgConceptos_TableControlCellDoubleClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgConceptos.TableControlCellDoubleClick
        Dim r As Record = dgConceptos.Table.CurrentRecord
        Dim conceptoSeleccionado = ConceptoSA.ConceptoSelxID(New Planilla.Business.Entity.Concepto With {.IDConcepto = Integer.Parse(r.GetValue("IDConcepto"))})
        Tag = conceptoSeleccionado
        Close()
    End Sub

#End Region

End Class