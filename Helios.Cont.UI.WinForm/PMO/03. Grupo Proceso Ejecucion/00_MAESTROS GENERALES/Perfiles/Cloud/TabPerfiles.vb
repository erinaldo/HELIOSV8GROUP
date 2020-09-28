Imports System.Threading
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.Business.Entity
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class TabPerfiles

#Region "Fields"
    Dim filter As New GridExcelFilter()
    Private Thread As Thread
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Public Property RolSA As New RolSA

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
        Try
            'Dim rolBE As New Rol
            Dim rolBE As New perfilAnexo
            Dim perfilSA As New perfilAnexoSA

            Dim dt As New DataTable("Movimientos - período " & PeriodoGeneral & " ")
            dt.Columns.Add(New DataColumn("IDRol", GetType(Integer)))
            dt.Columns.Add(New DataColumn("IDRolGrupoEmp", GetType(String)))
            dt.Columns.Add(New DataColumn("Nombre", GetType(String)))
            dt.Columns.Add(New DataColumn("Descripcion", GetType(String)))

            'rolBE.IDEmpresa = Gempresas.IdEmpresaRuc
            'rolBE.IDEstablecimiento = GEstableciento.IdEstablecimiento

            'rolBE.IDEmpresa = Gempresas.IdEmpresaRuc
            rolBE.idCentroCosto = GEstableciento.IdEstablecimiento

            'Dim CONSULTA As New List(Of Rol)
            'CONSULTA = RolSA.GetRolesXEstablecimiento(rolBE)

            'For Each i In RolSA.GetRolesXcliente(rolBE)
            For Each i In perfilSA.GetObtenerPerfilIDestablecimiento(rolBE)
                Dim dr As DataRow = dt.NewRow()

                dr(0) = i.idRol
                dr(1) = ""
                dr(2) = i.descripcion
                dr(3) = i.descripcion
                dt.Rows.Add(dr)
            Next

            setDatasource(dt)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
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

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs)
        With frmCrearENtidades
            .CaptionLabels(0).Text = "Nuevo cliente"
            .strTipo = TIPO_ENTIDAD.CLIENTE
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgPerfilesUsuario.Table.CurrentRecord) Then

            If Me.dgPerfilesUsuario.Table.CurrentRecord.GetValue("Nombre") = "Administrador" Then

                MessageBox.Show("Admin no se puede eeditar seleccione otro")

            Else

                Dim f As New frmCrearPerfilesDelSistema(Me.dgPerfilesUsuario.Table.CurrentRecord.GetValue("IDRol"))
                f.strEstadoManipulacion = ENTITY_ACTIONS.UPDATE
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()

            End If

        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Dim empresa As String = Gempresas.IdEmpresaRuc
        ProgressBar1.Visible = True
        ProgressBar1.Style = ProgressBarStyle.Marquee
        Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetPerfiles(empresa)))
        Thread.Start()
    End Sub

    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Cursor = Cursors.WaitCursor

        If Not IsNothing(Me.dgPerfilesUsuario.Table.CurrentRecord) Then



            'If Me.dgPerfilesUsuario.Table.CurrentRecord.GetValue("Nombre") = "ADMINISTRADOR" Then

            '    MessageBox.Show("Admin tiene todos los permisos seleccione otro Cargo")

            'Else

            Dim f As New FrmConfiguracionPerfil()
                f.txtIdRol.Text = Me.dgPerfilesUsuario.Table.CurrentRecord.GetValue("IDRol")
                f.txtRol.Text = Me.dgPerfilesUsuario.Table.CurrentRecord.GetValue("Nombre")
                f.txtGrupoRol.Text = Me.dgPerfilesUsuario.Table.CurrentRecord.GetValue("IDRolGrupoEmp")
                f.ListarAsegurableRol()
                'f.strEstadoManipulacion = ENTITY_ACTIONS.UPDATE
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()

            'End If
        Else
            MessageBox.Show("DEBE SELECCIONAR UN PERFIL")

        End If


        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click

    End Sub

#End Region
End Class
