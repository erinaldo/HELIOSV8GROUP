Imports System.Threading
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes
Imports Syncfusion.Drawing
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class UCClientesTransportes
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Private Thread As Thread
    Dim filter As New GridExcelFilter()
    Public ListadoClientes As List(Of Helios.Cont.Business.Entity.entidad)
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(dgvCliente, True, False, 9.0F)

        OrdenamientoGrid(dgvCliente, True)

    End Sub


    Private Sub TableModel_QueryRowHeight(ByVal sender As Object, ByVal e As GridRowColSizeEventArgs)
        If e.Index > 0 Then
            Dim graphicsProvider As IGraphicsProvider = Me.dgvCliente.TableModel.GetGraphicsProvider()
            Dim g As Graphics = graphicsProvider.Graphics
            Dim style As GridStyleInfo = Me.dgvCliente.TableModel(e.Index, 4)
            Dim model As GridCellModelBase = style.CellModel
            e.Size = model.CalculatePreferredCellSize(g, e.Index, 4, style, GridQueryBounds.Height).Height
            e.Handled = True
        End If
    End Sub

    Private Sub GetClientes(empresa As String)
        Dim entidadsa As New entidadSA
        Dim dt As New DataTable
        With dt.Columns
            .Add("idEntidad")
            .Add("tipoDoc")
            .Add("nroDoc")
            .Add("tipo")
            .Add("razon")
            .Add("fono")
            .Add("celular")
            .Add("email")
            .Add("direccion")
        End With

        ListadoClientes = (entidadsa.GetListarEntidad(New entidad With {.tipoEntidad = TIPO_ENTIDAD.CLIENTE, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})).Where(Function(o) o.tipoEntidad <> "VR").ToList

        For Each i In ListadoClientes
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
            dr(5) = i.telefono
            dr(6) = i.celular
            dr(7) = i.email
            dr(8) = i.direccion
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

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        Dim empresa As String = Gempresas.IdEmpresaRuc
        PictureLoad.Visible = True
        Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetClientes(empresa)))
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
End Class
