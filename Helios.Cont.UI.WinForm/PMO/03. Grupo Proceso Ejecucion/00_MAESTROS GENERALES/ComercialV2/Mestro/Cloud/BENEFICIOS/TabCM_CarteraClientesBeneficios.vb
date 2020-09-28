Imports System.Threading
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping

Public Class TabCM_CarteraClientesBeneficios

#Region "Attributes"
    Public Property beneficioSA As New beneficioSA
    Private Thread As Thread
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(dgvCliente, True, False, 10.0F)
        FormatoGridAvanzado(GridGroupingControl1, True, False, 10.0F)
        Dim empresa As String = Gempresas.IdEmpresaRuc
        ProgressBar1.Visible = True
        ProgressBar1.Style = ProgressBarStyle.Marquee
        Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetClientes(empresa)))
        Thread.Start()
    End Sub
#End Region

#Region "Methods"
    Private Sub GetClientes(empresa As String)
        Dim dt As New DataTable
        With dt.Columns
            .Add("idEntidad")
            .Add("tipoDoc")
            .Add("nroDoc")
            .Add("tipo")
            .Add("razon")
            .Add("direc")
            .Add("fono")
        End With

        For Each i In beneficioSA.CatalogoDeClientesBeneficio(New Business.Entity.entidad With
                                                              {
                                                              .idEmpresa = empresa,
                                                              .idOrganizacion = GEstableciento.IdEstablecimiento,
                                                              .tipoEntidad = TIPO_ENTIDAD.CLIENTE,
                                                              .tieneBeneficio = True
                                                              })
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.idEntidad
            Select Case i.tipoDoc
                Case "6"
                    dr(1) = "RUC"
                Case "1"
                    dr(1) = "DNI"
                Case "7"
                    dr(1) = "PASSAPORTE"
                Case "4"
                    dr(1) = "CARNET DE EXTRANJERIA"
            End Select

            dr(2) = i.nrodoc
            dr(3) = IIf(i.tipoPersona = "N", "NATURAL", "JURIDICO")
            dr(4) = i.nombreCompleto
            dr(5) = i.direccion
            dr(6) = i.telefono
            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub

    Public Sub setDatasource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            Dim deleg As New SetDataSourceDelegate(AddressOf setDatasource)
            Invoke(deleg, New Object() {table})
        Else
            dgvCliente.DataSource = table
            ProgressBar1.Visible = False
        End If
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub GetBeneficiosByCliente(currentRecord As Record)
        Dim dt As New DataTable()
        dt.Columns.Add("id")
        dt.Columns.Add("detalle")
        dt.Columns.Add("tipo")
        dt.Columns.Add("tipoafecta")
        dt.Columns.Add("montobase")
        dt.Columns.Add("vigencia")

        For Each i In beneficioSA.BeneficioListaClienteProductions(New Business.Entity.beneficio With
                                                                   {
                                                                   .idCliente = Integer.Parse(currentRecord.GetValue("idEntidad"))
                                                                   })
            dt.Rows.Add(i.beneficio_id, i.detalleBeneficio, i.tipoTabla, i.tipoAfectacion, i.importeBase, i.vigencia.GetValueOrDefault)
        Next
        GridGroupingControl1.DataSource = dt
    End Sub
#End Region

#Region "Events"
    Private Sub dgvCliente_TableControlCellClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles dgvCliente.TableControlCellClick

    End Sub

    Private Sub dgvCliente_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvCliente.SelectedRecordsChanged
        'GetBeneficiosByCliente(e.Table.CurrentRecord)
    End Sub

    Private Sub DescuentoRebajaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DescuentoRebajaToolStripMenuItem.Click
        Dim r As Record = dgvCliente.Table.CurrentRecord
        If r IsNot Nothing Then
            Dim id = Integer.Parse(r.GetValue("idEntidad"))
            Dim f As New FormConfirmarSolicitudAfiliado(id)
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
        Else

        End If
    End Sub

    Private Sub BonificaciónRegalosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BonificaciónRegalosToolStripMenuItem.Click
        Dim r As Record = dgvCliente.Table.CurrentRecord
        If r IsNot Nothing Then
            Dim id = Integer.Parse(r.GetValue("idEntidad"))
            Dim f As New FormBeneficioRegalos(id)
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
        Else

        End If
    End Sub

    Private Sub PromocionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PromocionToolStripMenuItem.Click
        Dim r As Record = dgvCliente.Table.CurrentRecord
        If r IsNot Nothing Then
            Dim id = Integer.Parse(r.GetValue("idEntidad"))
            Dim f As New FormBeneficioPromocion(id)
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
        Else

        End If
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Dim r As Record = dgvCliente.Table.CurrentRecord
        If r IsNot Nothing Then
            Dim f As New FormDetalleBeneficiosCliente(New Business.Entity.entidad With
                                                      {
                                                      .idEntidad = Integer.Parse(r.GetValue("idEntidad")),
                                                      .nombreCompleto = r.GetValue("razon")
                                                      })
            f.StartPosition = FormStartPosition.CenterParent
            f.FormBorderStyle = FormBorderStyle.FixedSingle
            f.ShowDialog(Me)
        End If

    End Sub

    Private Sub ValesDeConsumoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ValesDeConsumoToolStripMenuItem.Click
        Dim r As Record = dgvCliente.Table.CurrentRecord
        If r IsNot Nothing Then
            Dim id = Integer.Parse(r.GetValue("idEntidad"))
            Dim f As New FormValesDeConsumo(id)
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
        Else

        End If
    End Sub
#End Region

End Class
