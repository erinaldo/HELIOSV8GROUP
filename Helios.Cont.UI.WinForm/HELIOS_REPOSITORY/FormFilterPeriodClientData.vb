Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Public Class FormFilterPeriodClientData

#Region "Atributos"

#End Region

#Region "Constructor"
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        GetMeses()
        ' Add any initialization after the InitializeComponent() call.

    End Sub
#End Region

#Region "methods"
    Sub GetMeses()
        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.DataSource = General.ListaDeMeses
        cboMesCompra.SelectedValue = String.Format("{0:00}", DateTime.Now.Month)

        TExtAnio.DecimalValue = DateTime.Now.Year
    End Sub
#End Region

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim datos As List(Of item) = item.Instance()
        datos.Clear()
        Dim c As New item

        Dim periodo As New Date(TExtAnio.DecimalValue, CInt(cboMesCompra.SelectedValue), 1)
        Tag = periodo

        c.descripcion = cboComprobantes.Text
        datos.Add(c)

        Close()
    End Sub
End Class