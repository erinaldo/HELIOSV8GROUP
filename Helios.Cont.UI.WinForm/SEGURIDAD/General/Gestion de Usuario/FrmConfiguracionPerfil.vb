Imports System.Threading
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.Business.Entity
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid.Grouping
Public Class FrmConfiguracionPerfil


#Region "Atributos"
    Public Property IDUsario As Integer
#End Region

#Region "Constructor"
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        FormatoGridAvanzado(dgPermisos, True, False)
        ' Add any initialization after the InitializeComponent() call.
        'ListarAsegurableRol()
    End Sub
#End Region

#Region "Metodos"



    Sub EliminarPermisoRol(idaseg As Integer)
        Try

            Dim sa As New AutorizacionRolSA
            Dim objeto As New AutorizacionRol
            objeto.IDRol = txtIdRol.Text
            objeto.IdEmpresa = Gempresas.IdEmpresaRuc
            objeto.IDEstablecimiento = GEstableciento.IdEstablecimiento
            objeto.IDAsegurable = idaseg
            objeto.EstaAutorizado = 0
            objeto.UsuarioActualizacion = "Martin"
            objeto.FechaActualizacion = DateTime.Now

            sa.EliminarPermisoRol(objeto)

            MessageBox.Show("OK")


            ListarAsegurableRol()

        Catch ex As Exception
            MessageBox.Show("No se Pudo Eliminar Permiso")
        End Try
    End Sub

    Sub RegistrarPermiso(idaseg As Integer, IdModulo As Integer)
        Try

            Dim sa As New AutorizacionRolSA
            Dim objeto As New AutorizacionRol
            objeto.IDRol = txtIdRol.Text
            'objeto.IDRolXGrupoEmp = txtGrupoRol.Text
            objeto.IdEmpresa = Gempresas.IdEmpresaRuc
            objeto.IDEstablecimiento = GEstableciento.IdEstablecimiento
            objeto.IDAsegurable = idaseg
            objeto.IDModulo = IdModulo
            objeto.EstaAutorizado = 0
            objeto.UsuarioActualizacion = "Martin"
            objeto.FechaActualizacion = DateTime.Now

            sa.RegistrarPermisoRol(objeto)

            'MessageBox.Show("OK")


            ListarAsegurableRol()

        Catch ex As Exception
            MessageBox.Show("No se Pudo dar Permiso")
        End Try

    End Sub

    Public Sub ListarAsegurableRol()
        Try

            Dim SA As New AutorizacionRolSA
            Dim objeto As New AutorizacionRol
            objeto.IDRol = txtIdRol.Text
            objeto.IdEmpresa = Gempresas.IdEmpresaRuc
            objeto.IDEstablecimiento = GEstableciento.IdEstablecimiento
            Dim lista = SA.GetAsegurableXRol(objeto)


            Dim ListaConPermiso = (From i In lista Where i.IDRol = txtIdRol.Text).ToList
            Dim listaPermisos = (From i In lista Where Not i.IDRol > 0).ToList

            Dim dt As New DataTable("Lista - permisos")
            dt.Columns.Add(New DataColumn("IDRol", GetType(Integer)))
            dt.Columns.Add(New DataColumn("IDAsegurable", GetType(String)))
            dt.Columns.Add(New DataColumn("Nombre", GetType(String)))
            dt.Columns.Add(New DataColumn("Descripcion", GetType(String)))

            For Each i In ListaConPermiso
                Dim dr As DataRow = dt.NewRow()

                dr(0) = i.IDRol
                dr(1) = i.IDAsegurable
                dr(2) = i.Nombre
                dr(3) = i.Descripcion
                dt.Rows.Add(dr)

                Dim obj = listaPermisos.Where(Function(o) o.IDAsegurable = i.IDAsegurable).SingleOrDefault
                If obj IsNot Nothing Then
                    listaPermisos.Remove(obj)
                End If
            Next
            dgPermisos.DataSource = dt

            ListLotes.Items.Clear()

            For Each i In listaPermisos '.OrderByDescending(Function(o) o.CustomLote.fechaentrada).ToList
                Dim n As New ListViewItem(i.IDAsegurable)
                n.SubItems.Add(i.Nombre)
                n.SubItems.Add(i.Descripcion)
                n.SubItems.Add(i.IDModulo)
                ListLotes.Items.Add(n)
            Next
            ListLotes.Refresh()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub



    Private Sub FrmConfiguracionPerfil_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarAsegurableRol()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click




    End Sub

    Private Sub ListLotes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListLotes.SelectedIndexChanged

    End Sub

    Private Sub ListLotes_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListLotes.MouseDoubleClick

        If ListLotes.SelectedItems.Count = 0 Then Exit Sub
        RegistrarPermiso(Int32.Parse(ListLotes.SelectedItems(0).SubItems(0).Text), Int32.Parse(ListLotes.SelectedItems(0).SubItems(3).Text))

    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click


        If Not IsNothing(dgPermisos.Table.CurrentRecord) Then


            EliminarPermisoRol(CInt(dgPermisos.Table.CurrentRecord.GetValue("IDAsegurable")))
        Else
            MessageBox.Show("Debe seleccionar un cliente!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If


    End Sub


#End Region

End Class