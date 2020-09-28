Public Class FormFiltroAvanzadoPeriodo

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GetMeses()
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

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        Dim periodo As New Date(TExtAnio.DecimalValue, CInt(cboMesCompra.SelectedValue), 1)
        Tag = periodo
        Close()
    End Sub
End Class