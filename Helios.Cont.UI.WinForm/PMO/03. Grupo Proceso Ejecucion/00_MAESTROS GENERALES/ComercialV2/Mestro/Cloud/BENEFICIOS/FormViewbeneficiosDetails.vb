Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess

Public Class FormViewbeneficiosDetails
#Region "Attributes"
    Public Property beneficioSA As New BeneficioDetalleSA
    Public Property lista As List(Of beneficioDetalle)
#End Region

#Region "Constructors"
    Public Sub New(idBeneficio As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GetDetalle(idBeneficio)
    End Sub

#End Region

#Region "Methods"
    Private Sub GetDetalle(idBeneficio As Integer)
        LsvProducts.Items.Clear()
        lista = New List(Of beneficioDetalle)
        lista = beneficioSA.GetListDetalleSel(New Business.Entity.beneficio With {.beneficio_id = idBeneficio})
        For Each i In lista
            Dim n As New ListViewItem(i.iditem)
            n.SubItems.Add(i.Nombreproducto)
            n.SubItems.Add(i.cantidad)
            n.SubItems.Add(i.almacen)
            LsvProducts.Items.Add(n)
        Next
    End Sub
#End Region

#Region "Events"
    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        Me.Tag = lista
        Close()
    End Sub
#End Region
End Class