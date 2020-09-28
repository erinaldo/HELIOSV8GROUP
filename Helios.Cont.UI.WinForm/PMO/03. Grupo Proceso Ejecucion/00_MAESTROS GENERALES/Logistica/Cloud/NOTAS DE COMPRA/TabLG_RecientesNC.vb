Imports Helios.Cont.Presentation.WinForm
Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Grouping
Public Class TabLG_RecientesNC
    Implements ICommitOperacion
#Region "Variables"
    Public Property compraSA As New DocumentoCompraSA
    Public Property FormMDI As FormGestionNotasCompra
#End Region

#Region "Constructors"
    Public Sub New(Form As FormGestionNotasCompra, status As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        General.FormatoGridAvanzado(GridStatus, True, False, 10.0F, SelectionMode.One)
        GetRecientes(status)
        FormMDI = Form
    End Sub
#End Region

#Region "Methods"
    Private Sub GetRecientes(status As String)
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
        Dim estado As String = String.Empty
        For Each i In compraSA.GetNotaCompraRecientes(New Business.Entity.documentocompra With
                                                       {
                                                       .fechaDoc = DateTime.Now,
                                                       .tipoOperacion = status,
                                                       .idEmpresa = General.Gempresas.IdEmpresaRuc,
                                                       .idCentroCosto = General.GEstableciento.IdEstablecimiento,
                                                       .tipoCompra = General.TIPO_COMPRA.NOTA_DE_COMPRA,
                                                       .aprobado = "N"
                                                       })

            Select Case i.aprobado
                Case "N"
                    estado = "Pendiente"
                Case "R"
                    estado = "Rechazado"
                Case "S"
                    estado = "Revisado"
                Case Else
                    estado = "Pendiente"
            End Select

            dt.Rows.Add(
                i.idDocumento,
                i.tipoCompra,
                i.fechaDoc,
                i.tipoDoc,
                i.serie,
                i.numeroDoc, String.Empty,
                i.nombreProveedor,
                String.Empty,
                String.Empty,
                "NN",
                estado,
                String.Empty)

        Next
        GridStatus.DataSource = dt
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

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If GridStatus.Table.SelectedRecords.Count > 0 Then
            Dim idNota As Integer = GridStatus.Table.CurrentRecord.GetValue("idDocumento")
            Dim f As New FormConfirmarNotaCompra(idNota)
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
            FormMDI.GetStatus()
        Else
            MessageBox.Show("Debe elegir una fila", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Public Sub Commit(Confirmado As Boolean) Implements ICommitOperacion.Commit
        If Confirmado = True Then
            GridStatus.Table.CurrentRecord.Delete()
        End If

    End Sub
#End Region

#Region "Events"

#End Region

End Class
