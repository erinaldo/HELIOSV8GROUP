Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Helios.Seguridad.Business.Entity
Imports Syncfusion.Windows.Forms.Grid

Public Class frmAutorizacionXModulo

#Region "Attributes"
    Public Property ProductoSA As New ProductoSA
    Public Property autorizaSA As New AutorizacionRolSA
    Public Property autorizaDetalleSA As New ProductoDetalleSA
    Public Property frmModulos As frmModalSistemas
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridPequeño(dgPerfilAutoriza, False)
        'GetPefiles()
        Dim dt As New DataTable()
        dt.Columns.Add("IDAsegurable")
        dt.Columns.Add("Nombre")
        dt.Columns.Add("producto")
        dt.Columns.Add("idProducto")
        dt.Columns.Add("autorizado", GetType(Boolean))
        dgPerfilAutoriza.DataSource = dt
        GetPefiles()
    End Sub
#End Region

#Region "Methods"
    Sub GetPefiles()
        cboPErfil.ValueMember = "idProducto"
        cboPErfil.DisplayMember = "nombre"
        cboPErfil.DataSource = ProductoSA.ListadoProductoFull
        cboPErfil.SelectedIndex = -1
    End Sub

    Public Sub GetAutorizacionesByRol(ID As Integer)
        Dim dt As New DataTable()
        dt.Columns.Add("IDAsegurable")
        dt.Columns.Add("Nombre")
        dt.Columns.Add("producto")
        dt.Columns.Add("idProducto")
        dt.Columns.Add("autoriza")

        For Each i In autorizaDetalleSA.ListadoAsegurableProducto(ID)
            dt.Rows.Add(i.IDAsegurable, i.nombre, i.nombreProducto, i.idProducto, True)
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
        GetAutorizacionesByRol(cboPErfil.SelectedValue)
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        frmModulos = New frmModalSistemas()
        frmModulos.tipo = "ADM"
        frmModulos.StartPosition = FormStartPosition.CenterParent
        frmModulos.ShowDialog()
        If Not IsNothing(frmModulos.Tag) Then
            Dim c = CType(frmModulos.Tag, ProductoDetalle)
            'agregar fila al GGC
            dgPerfilAutoriza.Table.AddNewRecord.SetCurrent()
            dgPerfilAutoriza.Table.AddNewRecord.BeginEdit()
            dgPerfilAutoriza.Table.CurrentRecord.SetValue("IDAsegurable", c.IDAsegurable)
            dgPerfilAutoriza.Table.CurrentRecord.SetValue("Nombre", c.nombre)
            dgPerfilAutoriza.Table.CurrentRecord.SetValue("autoriza", c.estadoProducto)
            dgPerfilAutoriza.Table.CurrentRecord.SetValue("producto", cboPErfil.Text)
            dgPerfilAutoriza.Table.CurrentRecord.SetValue("idProducto", cboPErfil.SelectedValue)

            dgPerfilAutoriza.Table.AddNewRecord.EndEdit()
            c.Action = BaseBE.EntityAction.INSERT
            c.idProducto = cboPErfil.SelectedValue
            c.UsuarioActualizacion = usuario.IDUsuario
            c.estadoProducto = True
            c.FechaActualizacion = Date.Now
            autorizaDetalleSA.insertProductoDetalle(c)
            GetAutorizacionesByRol(cboPErfil.SelectedValue)
        End If
    End Sub

    Private Sub dgPerfilAutoriza_TableControlCheckBoxClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs)
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
                    ''autorizaSA.GetUpdateAutorizacion(be)
                Case Else ' FALSE

                    '       MessageBox.Show(False)

                    'be.IDAsegurable = Me.dgPerfilAutoriza.TableModel(RowIndex, 1).CellValue
                    'be.IDRol = cboPErfil.SelectedValue
                    'be.EstaAutorizado = False
                    ''autorizaSA.GetUpdateAutorizacion(be)
            End Select
        End If
        Cursor = Cursors.Default
    End Sub

#End Region

    Private Sub cboPErfil_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPErfil.SelectedIndexChanged
        dgPerfilAutoriza.Table.Records.DeleteAll()
    End Sub
End Class