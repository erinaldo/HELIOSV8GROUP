Imports Helios.General
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Cont.Business.Entity
Imports Syncfusion.Grouping

Public Class TabFN_AnticiposPendiente

#Region "Attributes"
    Dim anticipoSA As New documentoAnticipoSA
    Public Property FormMDI As FormMaestroModuloAnticipos
#End Region

#Region "Constructors"
    Public Sub New(Form As FormMaestroModuloAnticipos, estado As Anticipo.Estado)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        General.FormatoGridAvanzado(GridStatus, True, False, 10.0F, SelectionMode.One)
        GetPendientes(estado)
        FormMDI = Form
    End Sub

#End Region

#Region "Methods"
    Private Sub GetPendientes(estado As Anticipo.Estado)
        Dim dt As New DataTable
        dt.Columns.Add("idDocumento")
        dt.Columns.Add("codigo")
        dt.Columns.Add("fecha")
        dt.Columns.Add("tipo")
        dt.Columns.Add("entidad")
        dt.Columns.Add("nrodoc")
        dt.Columns.Add("tipodeposito")
        dt.Columns.Add("monto")
        dt.Columns.Add("idEntidad")

        For Each i In anticipoSA.GetStatusAprobacionAnticiposList(New Business.Entity.documentoAnticipo With
                                                       {
                                                       .idEmpresa = Gempresas.IdEmpresaRuc,
                                                       .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                       .tipoAnticipo = "AR",
                                                       .estado = estado
                                                       })

            dt.Rows.Add(
                i.idDocumento,
                i.numeroDoc,
                i.fechaDoc,
                i.tipoAnticipo,
                i.CustomEntidad.nombreCompleto,
                i.CustomEntidad.nrodoc,
                i.formaPago,
                i.importeMN,
                i.CustomEntidad.idEntidad)
        Next
        GridStatus.DataSource = dt
    End Sub
#End Region

#Region "Events"
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim r As Record = GridStatus.Table.CurrentRecord
        If r IsNot Nothing Then
            Dim be As New documentoAnticipo With
            {
            .idDocumento = r.GetValue("idDocumento"),
            .estado = Anticipo.Estado.NotaCredito
            }
            anticipoSA.GetChangeEstadoAnticipo(be)
            r.Delete()
            FormMDI.GetStatus()
            FormMDI.GetStatusNotasCreditoREM()
            MessageBox.Show("Anticipo aprobado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Dim ent As New entidad With
            '    {
            '    .idEntidad = Integer.Parse(r.GetValue("idEntidad")),
            '    .nombreCompleto = r.GetValue("entidad"),
            '    .nrodoc = r.GetValue("nrodoc")
            '}
            'Dim idDocumento As Integer = Integer.Parse(r.GetValue("idDocumento"))
            'Dim f As New FormCrearNotaCreditoAnticipo(idDocumento, ent)
            'f.StartPosition = FormStartPosition.CenterParent
            'f.ShowDialog(Me)
        End If
    End Sub
#End Region

End Class
