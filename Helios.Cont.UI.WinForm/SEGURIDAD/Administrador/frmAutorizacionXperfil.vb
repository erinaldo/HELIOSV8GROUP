Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Helios.Seguridad.Business.Entity
Imports Syncfusion.Windows.Forms.Grid

Public Class frmAutorizacionXperfil

#Region "Attributes"
    Public Property autorizaSA As New AutorizacionRolSA
    Public Property rolSA As New RolSA
    Public Property frmModulos As frmModalSistemas
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
    Private Sub GrabarPaqueteCliente()
        Throw New NotImplementedException()
    End Sub

    Sub GetPefiles()
        cboPErfil.ValueMember = "IDRol"
        cboPErfil.DisplayMember = "Nombre"
        'cboPErfil.DataSource = rolSA.GetRolesXcliente(New Rol With {.IDEmpresa = Gempresas.IdEmpresaRuc, .IDEstablecimiento = GEstableciento.IdEstablecimiento})
        cboPErfil.DataSource = rolSA.GetRolesXcliente(Nothing)
        'cboPErfil.DataSource = rolSA.GetRolesXcliente(New Rol With {.IDCliente = "VPOS"})
    End Sub

    Public Sub GetAutorizacionesByRol()
        Dim dt As New DataTable()
        dt.Columns.Add("IDAsegurable")
        dt.Columns.Add("Nombre")
        dt.Columns.Add("modulo")
        dt.Columns.Add("autorizado", GetType(Boolean))

        For Each i In autorizaSA.GetAutorizacionesRolXcliente(New AutorizacionRol With {
                                                              .IDRol = cboPErfil.SelectedValue,
                                                              .IdEmpresa = Gempresas.IdEmpresaRuc})
            'For Each i In autorizaSA.GetAutorizacionesRolXcliente(New AutorizacionRol With {
            '                                                      .IDRol = cboPErfil.SelectedValue,
            '                                                      .IDCliente = "VPOS"})
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
        GetAutorizacionesByRol()
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dim be = (From a In AutorizacionRolList
                  Group a By a.IDProducto Into g = Group
                  Select New With {IDProducto}).FirstOrDefault

        If (Not IsNothing(be.IDProducto)) Then
            frmModulos = New frmModalSistemas(be.IDProducto)
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
                c.IdEmpresa = Gempresas.IdEmpresaRuc
                c.UsuarioActualizacion = usuario.IDUsuario
                c.FechaActualizacion = Date.Now
                c.IDProducto = be.IDProducto
                autorizaSA.InsertItem(c)
                GetAutorizacionesByRol()
            End If
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
                    be.IdEmpresa = Gempresas.IdEmpresaRuc
                    be.IDAsegurable = Me.dgPerfilAutoriza.TableModel(RowIndex, 1).CellValue
                    be.IDRol = cboPErfil.SelectedValue
                    be.EstaAutorizado = True
                    autorizaSA.GetUpdateAutorizacionXcliente(be)
                Case Else ' FALSE

                    '       MessageBox.Show(False)
                    be.IdEmpresa = Gempresas.IdEmpresaRuc
                    be.IDAsegurable = Me.dgPerfilAutoriza.TableModel(RowIndex, 1).CellValue
                    be.IDRol = cboPErfil.SelectedValue
                    be.EstaAutorizado = False
                    autorizaSA.GetUpdateAutorizacionXcliente(be)
            End Select
        End If
        Cursor = Cursors.Default
    End Sub

#End Region

    Private Sub cboPErfil_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPErfil.SelectedIndexChanged
        dgPerfilAutoriza.Table.Records.DeleteAll()
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs)
        GrabarPaqueteCliente()
    End Sub

    Private Sub dgPerfilAutoriza_TableControlCellClick(sender As Object, e As Grouping.GridTableControlCellClickEventArgs) Handles dgPerfilAutoriza.TableControlCellClick

    End Sub
End Class