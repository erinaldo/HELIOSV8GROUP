Imports System.Threading
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.Business.Entity
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class TabUsuario

#Region "Fields"
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
    Dim filter As New GridExcelFilter()
    Private Thread As Thread
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Public Property UsuarioSA As New UsuarioSA
    Public Property UsuarioBE As Usuario

#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(dgvUsuariosSys, True, False)
        'Dim empresa As String = Gempresas.IdEmpresaRuc
        ProgressBar1.Visible = True
        ProgressBar1.Style = ProgressBarStyle.Marquee
        'Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetClientes()))
        'Thread.Start()
        GetClientes()
    End Sub
#End Region

#Region "Methods"
    Private Sub GetClientes()
        Dim dt As New DataTable("Usuario")
        dgvUsuariosSys.Table.Records.DeleteAll()
        dt.Columns.Add(New DataColumn("IDUsuario", GetType(Integer)))
        dt.Columns.Add(New DataColumn("TipoDocumento", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocumento", GetType(String)))
        dt.Columns.Add(New DataColumn("Full_Name", GetType(String)))
        Dim contador As Integer
        For Each i In UsuarioSA.ListadoUsuariosXcliente(Gempresas.IDCliente)
            Dim dr As DataRow = dt.NewRow()

            dr(0) = i.IDUsuario
            If (i.TipoDocumento.Length > 0) Then
                dr(1) = i.TipoDocumento
            Else
                dr(1) = ""
            End If
            If ((i.NroDocumento.Length) > 0) Then
                dr(2) = i.NroDocumento
            Else
                dr(2) = ""
            End If
            dr(3) = i.Full_Name
            dt.Rows.Add(dr)
        Next
        contador = dt.Rows.Count
        dgvUsuariosSys.DataSource = dt
        'setDatasource(dt)
    End Sub

    Public Sub setDatasource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            Dim deleg As New SetDataSourceDelegate(AddressOf setDatasource)
            Invoke(deleg, New Object() {table})
        Else
            dgvUsuariosSys.DataSource = table
            ProgressBar1.Visible = False
        End If
    End Sub

    Protected Overrides Sub Finalize()
        'MyBase.Finalize()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs)
        'With frmCrearENtidades
        '    .CaptionLabels(0).Text = "Nuevo cliente"
        '    .strTipo = TIPO_ENTIDAD.CLIENTE
        '    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        'End With
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Cursor = Cursors.WaitCursor
        If Not IsNothing(dgvUsuariosSys.Table.CurrentRecord) Then
            'If dgUsuarios.Table.CurrentRecord.GetValue("razon") <> "CLIENTES VARIOS" Then
            '    Dim f As New frmCrearENtidades(CInt(dgUsuarios.Table.CurrentRecord.GetValue("idEntidad")))
            '    f.CaptionLabels(0).Text = "Editar Cliente"
            '    f.strTipo = TIPO_ENTIDAD.CLIENTE
            '    '   f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
            '    f.intIdEntidad = dgUsuarios.Table.CurrentRecord.GetValue("idEntidad")
            '    'f.UbicarEntidad(dgvProveedor.Table.CurrentRecord.GetValue("idEntidad"))
            '    f.StartPosition = FormStartPosition.CenterParent
            '    f.ShowDialog()
            'End If
        Else
            MessageBox.Show("Debe seleccionar un cliente!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        'If ToolStripButton3.Tag = "Inactivo" Then
        '    dgUsuarios.TopLevelGroupOptions.ShowFilterBar = True
        '    dgUsuarios.NestedTableGroupOptions.ShowFilterBar = True
        '    dgUsuarios.ChildGroupOptions.ShowFilterBar = True
        '    For Each col As GridColumnDescriptor In dgUsuarios.TableDescriptor.Columns
        '        col.AllowFilter = True
        '    Next
        '    filter.AllowResize = True
        '    filter.AllowFilterByColor = True
        '    filter.EnableDateFilter = True
        '    filter.EnableNumberFilter = True

        '    dgUsuarios.OptimizeFilterPerformance = True
        '    dgUsuarios.ShowNavigationBar = True
        '    filter.WireGrid(dgUsuarios)
        '    ToolStripButton3.Tag = "activo"
        'Else
        '    ToolStripButton3.Tag = "Inactivo"
        '    filter.ClearFilters(dgUsuarios)
        '    dgUsuarios.TopLevelGroupOptions.ShowFilterBar = False
        'End If
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click

    End Sub
#End Region
End Class
