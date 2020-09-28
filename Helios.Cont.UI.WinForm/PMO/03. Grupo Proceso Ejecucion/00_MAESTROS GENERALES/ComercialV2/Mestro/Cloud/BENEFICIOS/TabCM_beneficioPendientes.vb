Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes
Imports Syncfusion.Grouping

Public Class TabCM_beneficioPendientes
#Region "Attributes"
    Public Property afiliacionSA As New EntidadAfiliacionBeneficioSA
    Public Property f As FormMaestroBeneficiosGeneral
#End Region

#Region "Constructors"
    Public Sub New(form As FormMaestroBeneficiosGeneral)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        f = form
        FormatoGridAvanzado(GridPendientes, True, False, 10.0F)
        GetLista()
    End Sub
#End Region

#Region "Methods"
    Public Sub GetLista()
        Dim dt As New DataTable
        dt.Columns.Add("codigo")
        dt.Columns.Add("fechaemision")
        dt.Columns.Add("fechaconfirma")
        dt.Columns.Add("idcliente")
        dt.Columns.Add("cliente")
        dt.Columns.Add("nrodoc")

        Dim afiliacionSA As New EntidadAfiliacionBeneficioSA

        For Each i In afiliacionSA.EntidadAfiliacionBeneficioStatus(New EntidadAfiliacionBeneficio With {.status = StatusAfiliacionBeneficiosCliente.Pendiente})

            dt.Rows.Add(i.idEntidad, i.fechaPedido.GetValueOrDefault, i.fechaAprobacion.GetValueOrDefault, i.entidad.idEntidad, i.entidad.nombreCompleto, i.entidad.nrodoc)
        Next
        GridPendientes.DataSource = dt

    End Sub

#End Region

#Region "Events"
    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Dim r As Record = GridPendientes.Table.CurrentRecord
        If r IsNot Nothing Then
            Dim be As New EntidadAfiliacionBeneficio
            be.idEntidad = Integer.Parse(r.GetValue("idcliente"))
            be.status = General.StatusAfiliacionBeneficiosCliente.Aprobado
            be.fechaAprobacion = DateTime.Now

            afiliacionSA.ChangeStatusAfiliado(be)
            MessageBox.Show("Cliente afiliado correctamente!", "Verificado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            r.Delete()
            f.GetStatus()
            'Dim f As New FormConfirmarSolicitudAfiliado(r)
            'f.StartPosition = FormStartPosition.CenterParent
            'f.ShowDialog(Me)
        Else

        End If
    End Sub
#End Region
End Class
