Public Class FormMaestroBeneficiosGeneral
    Public Property TabCM_beneficioPendientes As TabCM_beneficioPendientes
    Public Property TabCM_CarteraClientesBeneficios As TabCM_CarteraClientesBeneficios
    Public Property afiliacionSA As New Cont.WCFService.ServiceAccess.EntidadAfiliacionBeneficioSA


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GetStatus()
    End Sub

    Public Sub GetStatus()
        Dim statusList = afiliacionSA.GetEntidadAfiliacionConteo(
            New Business.Entity.EntidadAfiliacionBeneficio With {
            .idEntidad = 0
            })

        Dim conteoPendientes = statusList.Where(Function(o) o.status = General.StatusAfiliacionBeneficiosCliente.Pendiente).Select(Function(o) o.Conteo).FirstOrDefault

        Dim conteoOtros = statusList.Where(Function(o) o.status = General.StatusAfiliacionBeneficiosCliente.Retenido).Select(Function(o) o.Conteo).FirstOrDefault

        Dim conteoRechazados = statusList.Where(Function(o) o.status = General.StatusAfiliacionBeneficiosCliente.Rechazado).Select(Function(o) o.Conteo).FirstOrDefault


        ToolConteoPendientes.Text = conteoPendientes
        ToolConteoOtros.Text = conteoOtros
        ToolConteoRechazo.Text = conteoRechazados

    End Sub

    Private Sub ToolConteoPendientes_Click(sender As Object, e As EventArgs) Handles ToolConteoPendientes.Click, ToolStripButton1.Click, ToolStripButton17.Click, ToolStripButton24.Click

        PanelBody.Controls.Clear()
        TabCM_beneficioPendientes = New TabCM_beneficioPendientes(Me) With {
                .Dock = DockStyle.Fill
            }
        TabCM_beneficioPendientes.BringToFront()
        PanelBody.Controls.Add(TabCM_beneficioPendientes)

    End Sub

    Private Sub ToolConteoRechazo_Click(sender As Object, e As EventArgs) Handles ToolConteoRechazo.Click, ToolStripButton3.Click, ToolStripButton19.Click, ToolStripButton26.Click

    End Sub

    Private Sub ToolStripButton12_Click(sender As Object, e As EventArgs) Handles ToolStripButton12.Click
        PanelBody.Controls.Clear()
        TabCM_CarteraClientesBeneficios = New TabCM_CarteraClientesBeneficios() With {
                .Dock = DockStyle.Fill
            }
        TabCM_CarteraClientesBeneficios.BringToFront()
        PanelBody.Controls.Add(TabCM_CarteraClientesBeneficios)
    End Sub

    Private Sub ToolStripButton27_Click(sender As Object, e As EventArgs) Handles ToolStripButton27.Click
        Dim f As New FormAfiliacionBeneficio
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
    End Sub
End Class