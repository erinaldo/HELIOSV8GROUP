Imports System.Threading
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class UCProveedor

#Region "Attributes"
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Private Thread As Thread
    Dim filter As New GridExcelFilter()
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(dgvCliente, True, False, 9.0F)
        OrdenamientoGrid(dgvCliente, True)
        Dim empresa As String = Gempresas.IdEmpresaRuc
        PictureLoad.Visible = True
        'Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetProveedores(empresa)))
        'Thread.Start()
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
            dgvCliente.DataSource = table
            PictureLoad.Visible = False
        End If
    End Sub

#End Region

#Region "Events"
    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        Dim f As New frmCrearENtidades With
        {
        .strTipo = TIPO_ENTIDAD.PROVEEDOR,
        .ManipulacionEstado = ENTITY_ACTIONS.INSERT,
        .StartPosition = FormStartPosition.CenterParent
        }
        f.CaptionLabels(0).Text = "Nuevo Proveedor"
        f.ShowDialog(Me)
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        Cursor = Cursors.WaitCursor
        If Not IsNothing(dgvCliente.Table.CurrentRecord) Then
            Dim f As New frmCrearENtidades(CInt(dgvCliente.Table.CurrentRecord.GetValue("idEntidad")))
            f.CaptionLabels(0).Text = "Editar Proveedor"
            f.strTipo = TIPO_ENTIDAD.PROVEEDOR
            '   f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE 
            f.intIdEntidad = dgvCliente.Table.CurrentRecord.GetValue("idEntidad")
            'f.UbicarEntidad(dgvProveedor.Table.CurrentRecord.GetValue("idEntidad"))
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            Dim empresa As String = Gempresas.IdEmpresaRuc
            PictureLoad.Visible = True
            Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetProveedores(empresa)))
            Thread.Start()
        Else
            MessageBox.Show("Debe seleccionar un cliente!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        Dim empresa As String = Gempresas.IdEmpresaRuc
        PictureLoad.Visible = True
        Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetProveedores(empresa)))
        Thread.Start()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        dgvCliente.TopLevelGroupOptions.ShowFilterBar = True
        dgvCliente.NestedTableGroupOptions.ShowFilterBar = True
        dgvCliente.ChildGroupOptions.ShowFilterBar = True
        For Each col As GridColumnDescriptor In dgvCliente.TableDescriptor.Columns
            col.AllowFilter = True
        Next
        filter.AllowResize = True
        filter.AllowFilterByColor = True
        filter.EnableDateFilter = True
        filter.EnableNumberFilter = True

        dgvCliente.OptimizeFilterPerformance = True
        dgvCliente.ShowNavigationBar = True
        filter.WireGrid(dgvCliente)
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click

    End Sub
#End Region

End Class
