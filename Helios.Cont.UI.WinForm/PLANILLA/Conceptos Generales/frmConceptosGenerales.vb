Imports Helios.Planilla.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Planilla.Business.Entity

Public Class frmConceptosGenerales

#Region "Attributes"
    Private Property TablaSA As TablaDetalleSA
    Private Property conceptoSA As ConceptoSA
#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        TablaSA = New TablaDetalleSA
        conceptoSA = New ConceptoSA
        FormatoGridAvanzado(dgConcepto, True, False)
        GetConceptos()
        GetComboTipoPlanilla()
    End Sub
#End Region

#Region "Methods"
    Private Sub GetComboTipoPlanilla()
        Dim lstTipoPlanilla = TablaSA.TablaDetalleSelxTabla(New TablaDetalle With {.IDTabla = 1021})

        ' Dim cargoSA As New Helios.Planilla.WCFService.ServiceAccess.CargosSA
        cboTipoPlanilla.DataSource = lstTipoPlanilla ' cargoSA.CargosSelAll()
        cboTipoPlanilla.ValueMember = "IDTablaDetalle"
        cboTipoPlanilla.DisplayMember = "DescripcionLarga"
    End Sub


    Private Sub GetConceptos()
        lsvConceptos.Items.Clear()
        For Each i In TablaSA.TablaDetalleSelxTabla(New Planilla.Business.Entity.TablaDetalle With {.IDTabla = 1020, .Estado = True})
            Dim n As New ListViewItem(i.DescripcionCorta)
            n.SubItems.Add(i.IDTablaDetalle)
            n.SubItems.Add(i.DescripcionLarga)
            lsvConceptos.Items.Add(n)
        Next
    End Sub

    Private Sub GetConceptoDetalleXID(IDConceptoPadre As Integer)
        Dim listaConceptos = conceptoSA.ConceptoSelxCargo(New Concepto With {.TipoConcepto = IDConceptoPadre, .TipoPlanilla = String.Format("{0:00}", cboTipoPlanilla.SelectedValue)})
        dgConcepto.DataSource = listaConceptos
    End Sub
#End Region

#Region "Events"
    Private Sub lsvConceptos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvConceptos.SelectedIndexChanged
        If lsvConceptos.SelectedItems.Count > 0 Then
            GetConceptoDetalleXID(Integer.Parse(lsvConceptos.SelectedItems(0).SubItems(1).Text))
        End If
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        GetConceptos()
    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        Dim selConcepto As Int32 = 0
        Try

            If lsvConceptos.SelectedItems.Count > 0 Then
                Dim frm As New frmNuevoConceptoPlanilla
                frm.cboTipoConcepto.Enabled = False
                frm.StartPosition = FormStartPosition.CenterParent
                selConcepto = Nothing
                frm.cboTipoPlanilla.SelectedValue = cboTipoPlanilla.SelectedValue
                frm.cboTipoConcepto.SelectedValue = Integer.Parse(lsvConceptos.SelectedItems(0).SubItems(1).Text) ' Convert.ToInt32(selCondepto)
                frm.ShowDialog(Me)
            Else
                MsgBox("Seleccione una fila", MsgBoxStyle.Exclamation, "Atención")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

End Class