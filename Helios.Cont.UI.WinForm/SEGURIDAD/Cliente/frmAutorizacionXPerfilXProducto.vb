Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Helios.Seguridad.Business.Entity
Imports Syncfusion.Windows.Forms.Grid

Public Class frmAutorizacionXPerfilXProducto

#Region "Attributes"
    Public Property autorizaSA As New AutorizacionRolSA
    Public Property ProductoSA As New ProductoSA
    Public Property rolSA As New RolSA
    Public Property frmModulos As frmModalSistemas
    Public Property tipo As String
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridPequeño(dgPerfilAutoriza, False)
        GetPefiles()
        Dim dt As New DataTable()
        dt.Columns.Add("IDAsegurable")
        dt.Columns.Add("Nombre")
        dt.Columns.Add("modulo")
        dt.Columns.Add("autorizado", GetType(Boolean))
        dgPerfilAutoriza.DataSource = dt
    End Sub
#End Region

#Region "Methods"
    Sub GetPefiles()
        cboPErfil.ValueMember = "IDRol"
        cboPErfil.DisplayMember = "Nombre"
        cboPErfil.DataSource = rolSA.ListadoRoles
        cboPErfil.SelectedIndex = -1

        cboProducto.ValueMember = "idProducto"
        cboProducto.DisplayMember = "nombre"
        cboProducto.DataSource = ProductoSA.ListadoProductoFull
        cboProducto.SelectedIndex = -1

    End Sub

    Public Sub GetAutorizacionesByRol(ID As Integer)
        Dim dt As New DataTable()
        dt.Columns.Add("IDAsegurable")
        dt.Columns.Add("Nombre")
        dt.Columns.Add("modulo")
        dt.Columns.Add("autorizado", GetType(Boolean))

        For Each i In autorizaSA.GetAutorizacionesRolXProducto(New AutorizacionRol With {.IDRol = cboPErfil.SelectedValue, .IDProducto = ID})
            dt.Rows.Add(i.IDAsegurable, i.Nomasegurable, i.Categoria, i.EstaAutorizado)
        Next
        dgPerfilAutoriza.DataSource = dt
        'dgPerfilAutoriza.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        'dgPerfilAutoriza.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left

        dgPerfilAutoriza.TableDescriptor.Columns("Nombre").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        dgPerfilAutoriza.TableDescriptor.Columns("Nombre").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
        'dgPerfilAutoriza.TableDescriptor.GroupedColumns.Clear()
        'dgPerfilAutoriza.TableDescriptor.GroupedColumns.Add("modulo")
        'dgPerfilAutoriza.TableDescriptor.Columns("modulo").Width = 0
    End Sub
#End Region

#Region "Events"
    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Cursor = Cursors.WaitCursor
        GetAutorizacionesByRol(cboProducto.SelectedValue)
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        frmModulos = New frmModalSistemas(cboProducto.SelectedValue)
        frmModulos.tipo = "CLI"
        frmModulos.StartPosition = FormStartPosition.CenterParent
        frmModulos.ShowDialog()
        If Not IsNothing(frmModulos.Tag) Then
            Dim c = CType(frmModulos.Tag, AutorizacionRol)
            'agregar fila al GGC
            dgPerfilAutoriza.Table.AddNewRecord.SetCurrent()
            dgPerfilAutoriza.Table.AddNewRecord.BeginEdit()
            dgPerfilAutoriza.Table.CurrentRecord.SetValue("IDAsegurable", c.IDAsegurable)
            dgPerfilAutoriza.Table.CurrentRecord.SetValue("Nombre", c.Nomasegurable)
            dgPerfilAutoriza.Table.CurrentRecord.SetValue("autorizado", c.EstaAutorizado)
            dgPerfilAutoriza.Table.AddNewRecord.EndEdit()
            c.Action = BaseBE.EntityAction.INSERT
            c.IDRol = cboPErfil.SelectedValue
            c.IDAsegurable = c.IDAsegurable
            c.UsuarioActualizacion = usuario.IDUsuario
            c.EstaAutorizado = c.EstaAutorizado
            c.IDProducto = cboProducto.SelectedValue
            c.FechaActualizacion = Date.Now
            autorizaSA.InsertItem(c)
            GetAutorizacionesByRol(cboProducto.SelectedValue)
        End If
    End Sub

    Private Sub dgPerfilAutoriza_TableControlCheckBoxClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles dgPerfilAutoriza.TableControlCheckBoxClick
        Cursor = Cursors.WaitCursor
        Dim RowIndex As Integer = e.Inner.RowIndex
        Dim be As New AutorizacionRol

        If RowIndex > -1 Then
            e.TableControl.CurrentCell.EndEdit()
            e.TableControl.Table.TableDirty = True
            e.TableControl.Table.EndEdit()

            Dim valCheck = Me.dgPerfilAutoriza.TableModel(RowIndex, 4).CellValue
            Select Case valCheck
                Case "False" 'TRUE
                    '     MessageBox.Show(True)

                    'be.IDAsegurable = Me.dgPerfilAutoriza.TableModel(RowIndex, 1).CellValue
                    'be.IDRol = cboPErfil.SelectedValue
                    'be.EstaAutorizado = True
                    'autorizaSA.GetUpdateAutorizacion(be)
                Case Else ' FALSE

                    '       MessageBox.Show(False)

                    'be.IDAsegurable = Me.dgPerfilAutoriza.TableModel(RowIndex, 1).CellValue
                    'be.IDRol = cboPErfil.SelectedValue
                    'be.EstaAutorizado = False
                    'autorizaSA.GetUpdateAutorizacion(be)
            End Select
        End If
        Cursor = Cursors.Default
    End Sub

#End Region

    Private Sub cboPErfil_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPErfil.SelectedIndexChanged
        dgPerfilAutoriza.Table.Records.DeleteAll()
    End Sub
End Class