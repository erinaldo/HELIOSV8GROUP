Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Grouping

Public Class TabLG_PendienteCR

    Public Property compraSA As New DocumentoCompraSA
    Public Property FormMDI As FormMantenimientoComprasRapidas

    Public Sub New(form As FormMantenimientoComprasRapidas)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        General.FormatoGridAvanzado(GridStatus, True, False, 10.0F, SelectionMode.One)
        GetPendientes()
        FormMDI = form
    End Sub

    Private Sub GetPendientes()
        Dim dt As New DataTable
        dt.Columns.Add("idDocumento")
        dt.Columns.Add("tipoCompra")
        dt.Columns.Add("fechaDoc")
        dt.Columns.Add("tipoDoc")
        dt.Columns.Add("serie")
        dt.Columns.Add("numeroDoc")
        dt.Columns.Add("iditem")
        dt.Columns.Add("item")
        dt.Columns.Add("unidad")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("usuarioActualizacion")
        dt.Columns.Add("estado")
        dt.Columns.Add("secuencia")

        For Each i In compraSA.GetStatusAprobacionList(New Business.Entity.documentocompra With
                                                       {.idEmpresa = General.Gempresas.IdEmpresaRuc,
                                                       .idCentroCosto = General.GEstableciento.IdEstablecimiento,
                                                       .tipoCompra = General.TIPO_COMPRA.NOTA_DE_COMPRA_EN_ESPERA,
                                                       .aprobado = "N"
                                                       })

            dt.Rows.Add(
                i.idDocumento,
                i.tipoCompra,
                i.fechaDoc,
                i.tipoDoc,
                i.serie,
                i.numeroDoc,
                i.CustomDetalleCompra.idItem,
                i.CustomDetalleCompra.descripcionItem,
                i.CustomDetalleCompra.unidad1,
                i.CustomDetalleCompra.monto1,
                "NN",
                "N",
                i.CustomDetalleCompra.secuencia)

        Next
        GridStatus.DataSource = dt
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If GridStatus.Table.SelectedRecords.Count > 0 Then
            Dim f As New FormConfirmarNota(GridStatus)
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
            FormMDI.GetStatus()
        Else
            MessageBox.Show("Debe elegir una fila", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Dim r As Record = GridStatus.Table.CurrentRecord
        If r IsNot Nothing Then
            If MessageBox.Show("Rechazar la compra rapida?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                compraSA.RechazarCompraRapida(New Business.Entity.documento With
                                              {
                                              .idDocumento = Integer.Parse(r.GetValue("idDocumento")),
                                              .tipoOperacion = "R"
                                              })
                r.Delete()
                FormMDI.GetStatus()
            End If
        Else
            MessageBox.Show("Debe elegir una fila", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
End Class
