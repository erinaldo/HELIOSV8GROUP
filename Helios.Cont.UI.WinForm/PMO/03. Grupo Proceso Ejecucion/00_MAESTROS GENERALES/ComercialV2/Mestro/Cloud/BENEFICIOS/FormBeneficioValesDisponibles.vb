Public Class FormBeneficioValesDisponibles
#Region "Attributes"
    Public Property CuponesSA As New WCFService.ServiceAccess.BeneficioProduccionConsumoSA
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GetCuponesActivos()
    End Sub
#End Region

#Region "Methods"
    Public Sub GetCuponesActivos()
        Try
            Dim lista = CuponesSA.GetBeneficiosSelTipo(Nothing)
            LsvCupones.Items.Clear()
            For Each i In lista
                Dim n As New ListViewItem(i.produccion_id)
                n.SubItems.Add(i.descripcion)
                n.SubItems.Add(i.valor)
                n.SubItems.Add(If(i.Vigencia.HasValue, i.Vigencia, "-"))
                LsvCupones.Items.Add(n)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

#Region "Events"
    Private Sub LsvCupones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LsvCupones.SelectedIndexChanged

    End Sub

    Private Sub LsvCupones_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LsvCupones.MouseDoubleClick
        If LsvCupones.SelectedItems.Count > 0 Then
            Dim produccion = CuponesSA.BeneficioSelID(New Business.Entity.beneficioProduccionConsumo With
                               {
                               .produccion_id = Integer.Parse(LsvCupones.SelectedItems(0).SubItems(0).Text)
                                                      })

            Me.Tag = produccion
            Close()
        End If
    End Sub
#End Region
End Class