Imports System.Threading
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class TabLG_Proveedores

#Region "Fields"
    Dim filter As New GridExcelFilter()
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
#End Region

#Region "Constructors"

    Private Thread As Thread

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(dgvProveedor, True, False)
        Dim empresa As String = Gempresas.IdEmpresaRuc
        ProgressBar1.Visible = True
        ProgressBar1.Style = ProgressBarStyle.Marquee
        Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetProveedores(empresa)))
        Thread.Start()
    End Sub
#End Region

#Region "Methods"
    Private Sub GetProveedores(empresa As String)
        Dim entidadsa As New entidadSA
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

        For Each i In entidadsa.GetListarEntidad(New entidad With {.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
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
            dgvProveedor.DataSource = table
            ProgressBar1.Visible = False
        End If
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        With frmCrearENtidades
            .CaptionLabels(0).Text = "Nuevo proveedor"
            .strTipo = TIPO_ENTIDAD.PROVEEDOR
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Cursor = Cursors.WaitCursor
        If Not IsNothing(dgvProveedor.Table.CurrentRecord) Then
            If dgvProveedor.Table.CurrentRecord.GetValue("razon") <> "PROVEEDORES VARIOS" Then
                Dim f As New frmCrearENtidades(CInt(dgvProveedor.Table.CurrentRecord.GetValue("idEntidad")))
                f.CaptionLabels(0).Text = "Editar proveedor"
                f.strTipo = TIPO_ENTIDAD.PROVEEDOR
                '   f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                f.intIdEntidad = dgvProveedor.Table.CurrentRecord.GetValue("idEntidad")
                'f.UbicarEntidad(dgvProveedor.Table.CurrentRecord.GetValue("idEntidad"))
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            End If
        Else
            MessageBox.Show("Debe seleccionar un cliente!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If ToolStripButton3.Tag = "Inactivo" Then
            dgvProveedor.TopLevelGroupOptions.ShowFilterBar = True
            dgvProveedor.NestedTableGroupOptions.ShowFilterBar = True
            dgvProveedor.ChildGroupOptions.ShowFilterBar = True
            For Each col As GridColumnDescriptor In dgvProveedor.TableDescriptor.Columns
                col.AllowFilter = True
            Next
            filter.AllowResize = True
            filter.AllowFilterByColor = True
            filter.EnableDateFilter = True
            filter.EnableNumberFilter = True

            dgvProveedor.OptimizeFilterPerformance = True
            dgvProveedor.ShowNavigationBar = True
            filter.WireGrid(dgvProveedor)
            ToolStripButton3.Tag = "activo"
        Else
            ToolStripButton3.Tag = "Inactivo"
            filter.ClearFilters(dgvProveedor)
            dgvProveedor.TopLevelGroupOptions.ShowFilterBar = False
        End If
    End Sub
#End Region
End Class
