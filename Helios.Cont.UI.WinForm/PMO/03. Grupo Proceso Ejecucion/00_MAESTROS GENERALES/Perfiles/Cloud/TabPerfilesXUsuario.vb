Imports System.Threading
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.Business.Entity
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class TabPerfilesXUsuario

#Region "Fields"
    Dim filter As New GridExcelFilter()
    Private Thread As Thread
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Public Property RolSA As New UsuarioRolSA

#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(dgPerfilesUsuario, True, False)
        Dim empresa As String = Gempresas.IdEmpresaRuc
        ProgressBar1.Visible = True
        ProgressBar1.Style = ProgressBarStyle.Marquee
        Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetPerfiles(empresa)))
        Thread.Start()
    End Sub
#End Region

#Region "Methods"
    Private Sub GetPerfiles(empresa As String)

        Dim dt As New DataTable("Movimientos - período " & PeriodoGeneral & " ")
        dt.Columns.Add(New DataColumn("IDRol", GetType(Integer)))
        dt.Columns.Add(New DataColumn("IDCliente", GetType(String)))
        dt.Columns.Add(New DataColumn("Nombre", GetType(String)))
        dt.Columns.Add(New DataColumn("Descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha", GetType(String)))

        For Each i In RolSA.GetListaUsuariosXPerfilXCliente(Gempresas.IDCliente)
            Dim dr As DataRow = dt.NewRow()

            dr(0) = i.IDUsuario
            dr(1) = i.IdCliente
            dr(2) = i.nombreUsuario
            dr(3) = i.nombrePerfil
            dr(4) = i.FechaActualizacion
            dt.Rows.Add(dr)
        Next

        setDatasource(dt)
    End Sub

    Public Sub setDatasource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            Dim deleg As New SetDataSourceDelegate(AddressOf setDatasource)
            Invoke(deleg, New Object() {table})
        Else
            dgPerfilesUsuario.DataSource = table
            ProgressBar1.Visible = False
        End If
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

#End Region
End Class
