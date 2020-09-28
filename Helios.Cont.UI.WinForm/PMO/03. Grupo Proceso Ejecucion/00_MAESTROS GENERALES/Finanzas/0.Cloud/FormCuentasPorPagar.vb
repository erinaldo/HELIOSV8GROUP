Imports System.Threading
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General

Public Class FormCuentasPorPagar

    Private tabEscan As TabCP_Escaneadas
    Private tabRecientes As TabCP_Recientes
    Private tabRetenidas As TabCP_Retenciones
    Private tabPendientes As TabCP_Pendientes
    Private threadLog As Thread
    Friend Delegate Sub SetDataSourceDelegateLogistica(ByVal ResumenStatus As List(Of EstadoPagos))

    Public Class EstadoPagos
        Property Codigo As String
        Property Name As String
        Property Valor As Integer
        Public Sub New()

        End Sub
    End Class

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        ThreadLogistica()
    End Sub

    Private Sub ThreadLogistica()
        Try
            Dim empresa = Gempresas.IdEmpresaRuc
            threadLog = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetLogistia(empresa)))
            threadLog.Start()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GetLogistia(empresa As String)
        Dim compraSA As New DocumentoCompraSA
        Dim Pendientes = compraSA.GetCuentasPorPagarStatusCount(New Business.Entity.documentocompra With {.idEmpresa = empresa, .apruebaPago = StatusAprobacionPagos.Pendiente})
        Dim Aprobados = compraSA.GetCuentasPorPagarStatusCount(New Business.Entity.documentocompra With {.idEmpresa = empresa, .apruebaPago = StatusAprobacionPagos.Aprobado})
        Dim Rechazados = compraSA.GetCuentasPorPagarStatusCount(New Business.Entity.documentocompra With {.idEmpresa = empresa, .apruebaPago = StatusAprobacionPagos.Rechazado})
        Dim lista As New List(Of EstadoPagos)
        lista.Add(New EstadoPagos With {.Codigo = StatusAprobacionPagos.Pendiente, .Name = "Pendientes", .Valor = Pendientes})
        lista.Add(New EstadoPagos With {.Codigo = StatusAprobacionPagos.Aprobado, .Name = "Aprobados", .Valor = Aprobados})
        lista.Add(New EstadoPagos With {.Codigo = StatusAprobacionPagos.Rechazado, .Name = "Rechazados", .Valor = Rechazados})

        setDatasourceLogistica(lista)
    End Sub

    Private Sub setDatasourceLogistica(lista As List(Of EstadoPagos))
        If Me.InvokeRequired Then
            'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

            Dim deleg As New SetDataSourceDelegateLogistica(AddressOf setDatasourceLogistica)
            Invoke(deleg, New Object() {lista})
        Else
            GetStatus(lista)
        End If
    End Sub

    Private Sub GetStatus(lista As List(Of EstadoPagos))
        If lista.Count > 0 Then
            ToolConteoPendientes.Text = lista.Where(Function(o) o.Codigo = StatusAprobacionPagos.Pendiente).Select(Function(o) o.Valor).SingleOrDefault
            ToolConteoRechazo.Text = lista.Where(Function(o) o.Codigo = StatusAprobacionPagos.Rechazado).Select(Function(o) o.Valor).SingleOrDefault
        End If
    End Sub

    Private Sub ToolStripEx1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStripEx1.ItemClicked
        MsgBox(e.ClickedItem.Text)
    End Sub

    Private Sub ToolCompra_Click(sender As Object, e As EventArgs) Handles ToolCompra.Click
        PanelTabs.Controls.Clear()
        tabRetenidas = New TabCP_Retenciones
        tabRetenidas.Dock = DockStyle.Fill
        tabRetenidas.BringToFront()
        PanelTabs.Controls.Add(tabRetenidas)
    End Sub

    Private Sub ToolRecientes_Click(sender As Object, e As EventArgs) Handles ToolRecientes.Click
        PanelTabs.Controls.Clear()
        tabRecientes = New TabCP_Recientes
        tabRecientes.Dock = DockStyle.Fill
        tabRecientes.BringToFront()
        PanelTabs.Controls.Add(tabRecientes)
    End Sub

    Private Sub ToolPendientes_Click(sender As Object, e As EventArgs) Handles ToolPendientes.Click
        PanelTabs.Controls.Clear()
        tabPendientes = New TabCP_Pendientes
        tabPendientes.GetComprasPorAprobar(StatusAprobacionPagos.Pendiente)
        tabPendientes.Dock = DockStyle.Fill
        tabPendientes.BringToFront()
        PanelTabs.Controls.Add(tabPendientes)
        ThreadLogistica()
    End Sub

    Private Sub ToolRechazados_Click(sender As Object, e As EventArgs) Handles ToolRechazados.Click
        PanelTabs.Controls.Clear()
        tabPendientes = New TabCP_Pendientes
        tabPendientes.GetComprasPorAprobar(StatusAprobacionPagos.Rechazado)
        tabPendientes.Dock = DockStyle.Fill
        tabPendientes.BringToFront()
        PanelTabs.Controls.Add(tabPendientes)
        ThreadLogistica()
    End Sub

    Private Sub FormCuentasPorPagar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormCuentasPorPagar_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        threadLog.Abort()
    End Sub
End Class