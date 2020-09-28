Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Helios.Seguridad.Business.Entity
Imports Helios.General
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Public Class frmListaPerfilesXUsuario

#Region "Attributes"
    Public Property RolSA As New UsuarioRolSA
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridPequeño(dgPerfilesUsuario, True)
        GetRoles()
    End Sub
#End Region

#Region "Methods"
    Private Sub IsMouseHover(row As Integer, col As Integer, isHover As Boolean, GGC As GridGroupingControl)
        Dim color As New GridMetroColors()
        Dim id As GridTableCellStyleInfoIdentity = GGC.TableControl.GetTableViewStyleInfo(row, col).TableCellIdentity
        If id.DisplayElement.IsRecord() Then
            Dim key As Integer = id.DisplayElement.GetRecord().Id
            'if (selectionColl.Contains(key))
            '    selectionColl[key] = isHover;
            'else
            hoveredIndex = row
            selectionColl.Clear()
            'if (selectionColl.Count == 0)
            '    selectionColl.Add(key, isHover);
            GGC.TableControl.Refresh()
        End If

        GGC.TableControl.Selections.Clear()

    End Sub

    Sub GetRoles()

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

        dgPerfilesUsuario.DataSource = dt
        dgPerfilesUsuario.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub
#End Region

#Region "Events"
    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        Cursor = Cursors.WaitCursor
        GetRoles()
        Cursor = Cursors.Default
    End Sub

    Private Sub dgPerfilesUsuario_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgPerfilesUsuario.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            dgPerfilesUsuario.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub dgPerfilesUsuario_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgPerfilesUsuario.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgPerfilesUsuario)
    End Sub
#End Region


End Class