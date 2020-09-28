Imports System.Security.Cryptography
Imports System.Text
Imports System.Threading
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.Business.Entity
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class TabPasswordXUsuario

#Region "Fields"
    Dim filter As New GridExcelFilter()
    Private Thread As Thread
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Public Property RolSA As New UsuarioRolSA
    Dim Alert As Alert
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
        dt.Columns.Add(New DataColumn("IDCliente", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha", GetType(String)))
        dt.Columns.Add(New DataColumn("Nombre", GetType(String)))
        dt.Columns.Add(New DataColumn("Descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("aliasUsuario", GetType(String)))
        dt.Columns.Add(New DataColumn("password", GetType(String)))

        For Each i In RolSA.GetListaUsuariosXPerfilAndPassword(Gempresas.IDCliente)
            Dim dr As DataRow = dt.NewRow()

            dr(0) = i.IdCliente
            dr(1) = i.FechaActualizacion
            dr(2) = i.nombreUsuario
            dr(3) = i.nombrePerfil
            dr(4) = i.aliasUsuario
            dr(5) = i.password

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

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Try
            If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.CAMBIAR_PASSWORD_Botón___, AutorizacionRolList) Then
                If Not IsNothing(dgPerfilesUsuario.Table.CurrentRecord) Then
                    Dim f As New frmCambiarPassword()
                    f.WindowState = FormWindowState.Normal
                    f.txtRUC.Text = Gempresas.IdEmpresaRuc
                    f.UsernameTextBox.Text = dgPerfilesUsuario.Table.CurrentRecord.GetValue("aliasUsuario")
                    f.txtNuevoPassword.Select()
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                    Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetPerfiles(Nothing)))
                    Thread.Start()
                Else
                    MsgBox("No se pudo cambiar el password", MsgBoxStyle.Critical, "Verificar documentos")
                End If
            Else
                MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MsgBox("No se pudo cambiar el password", MsgBoxStyle.Critical, "Verificar documentos")
        End Try
    End Sub

#End Region
End Class
