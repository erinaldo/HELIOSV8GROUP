Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping

Public Class TabCM_Ofertas

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(GridOfertas, True, False)
        GetOfertas()
    End Sub

    Private Sub GetOfertas()
        Dim ofertaSA As New OfertaSA
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("empresa")
        dt.Columns.Add("codigo")
        dt.Columns.Add("nombre")
        dt.Columns.Add("vigencia")
        dt.Columns.Add("estado")
        dt.Columns.Add("precio")

        For Each i In ofertaSA.OfertaSelAll(New Business.Entity.oferta With {.idemprea = Gempresas.IdEmpresaRuc})
            dt.Rows.Add(i.id, i.idemprea, i.codigo, i.nombreCorto, i.Vence, i.estado, i.precioventa.GetValueOrDefault)
        Next
        GridOfertas.DataSource = dt
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Dim r As Record = GridOfertas.Table.CurrentRecord
        If r IsNot Nothing Then
            Dim codigo = r.GetValue("id")
            Dim f As New FormOfertaVentas(codigo)
            f.Manipulacion = ENTITY_ACTIONS.UPDATE
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
        Else
            MessageBox.Show("Debe indicar una oferta válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
End Class
