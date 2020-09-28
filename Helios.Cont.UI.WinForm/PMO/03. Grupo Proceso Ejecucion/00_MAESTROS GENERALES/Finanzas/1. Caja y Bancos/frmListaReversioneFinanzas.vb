Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General

Public Class frmListaReversioneFinanzas

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub


    Public Sub GetCuentasFinancieras(idDocumento As Integer)
        Dim docCajaSA As New DocumentoCajaSA
        Dim listaCaja As New List(Of documentoCaja)
        ListView1.Items.Clear()
        listaCaja = docCajaSA.ListaReversionXDoc(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, idDocumento)

        If (Not IsNothing(listaCaja)) Then
            For Each i In listaCaja
                Dim n As New ListViewItem("")
                n.SubItems.Add(i.fechaProceso)
                n.SubItems.Add(i.DetalleItem)
                n.SubItems.Add(i.montoSoles)
                n.SubItems.Add(i.montoUsd)
                ListView1.Items.Add(n)
            Next
        Else

        End If

      


    End Sub

End Class