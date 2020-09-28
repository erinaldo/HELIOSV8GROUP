Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Public Class FormFiltroDiaVentas

#Region "Constructor"

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        txtFecha.Value = DateTime.Now

    End Sub

    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        Dim datos As List(Of item) = item.Instance()
        datos.Clear()
        Dim c As New item

        Dim periodo = txtFecha.Value
        Tag = periodo

        c.descripcion = cboComprobantes.Text
        datos.Add(c)

        Close()
    End Sub

#End Region

End Class