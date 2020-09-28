Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess

Public Class frmVentaPagoNuevo
    Public Property ventaSA As New documentoVentaAbarrotesDetSA
    Public Property ListaVenta As List(Of documentoventaAbarrotesDet)

    Public Sub New(idDocumentoVenta As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        ListaVenta = New List(Of documentoventaAbarrotesDet)
        ListaVenta = ventaSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(idDocumentoVenta)
    End Sub

    Private Sub frmVentaPagoNuevo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class