Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes
Imports Syncfusion.Grouping
Public Class TabLG_RechazadosCRNC
#Region "variables"
    Dim Alert As Alert
    Public Property compraSA As New DocumentoCompraSA
    Public Property FormMDI As FormGestionNotasCompra
#End Region

#Region "Constructors"
    Public Sub New(Form As FormGestionNotasCompra)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        General.FormatoGridAvanzado(GridStatus, True, False, 10.0F, SelectionMode.One)
        GetPendientes()
        FormMDI = Form
    End Sub
#End Region

#Region "Methods"
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

        For Each i In compraSA.GetStatusAprobacionListNotaCompra(New Business.Entity.documentocompra With
                                                       {.idEmpresa = General.Gempresas.IdEmpresaRuc,
                                                       .idCentroCosto = General.GEstableciento.IdEstablecimiento,
                                                       .tipoCompra = General.TIPO_COMPRA.NOTA_DE_COMPRA,
                                                       .aprobado = "R"
                                                       })

            dt.Rows.Add(
                i.idDocumento,
                i.tipoCompra,
                i.fechaDoc,
                i.tipoDoc,
                i.serie,
                i.numeroDoc,
                String.Empty,
                i.nombreProveedor,
                String.Empty,
                String.Empty,
                "NN",
                "N",
                String.Empty)

        Next
        GridStatus.DataSource = dt
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim r As Record = GridStatus.Table.CurrentRecord
        If r IsNot Nothing Then
            If MessageBox.Show("Liberar el documento seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                compraSA.RechazarCompraRapida(New Business.Entity.documento With
                                              {
                                              .idDocumento = Integer.Parse(r.GetValue("idDocumento")),
                                              .tipoOperacion = "N"
                                              })
                r.Delete()
                FormMDI.GetStatus()
            End If
        Else
            MessageBox.Show("Debe elegir una fila", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        If Not IsNothing(Me.GridStatus.Table.CurrentRecord) Then

            If MessageBox.Show("Desea anular la nota de compra?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                compraSA.AnularNotaDeCompra(New documento With
                               {
                               .idDocumento = Integer.Parse(GridStatus.Table.CurrentRecord.GetValue("idDocumento"))
                               })
                Alert = New Alert("Nota de compra anulada", alertType.info)
                Alert.TopMost = True
                Alert.Show()
                GridStatus.Table.CurrentRecord.Delete()
                GridStatus.Refresh()
            End If
        End If
    End Sub
#End Region

#Region "Events"

#End Region
End Class
