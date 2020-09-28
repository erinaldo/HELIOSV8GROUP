Imports Helios.Seguridad.Business.Entity
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Public Class frmUsuariosListado

#Region "Attributes"
    Public Property UsuarioSA As New UsuarioSA
    Public Property UsuarioBE As Usuario
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridPequeño(dgUsuarios, True)
        GetUsuariosSistema()
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

    Public Sub GetUsuariosSistema()

        Dim dt As New DataTable("Movimientos - período " & PeriodoGeneral & " ")
        dt.Columns.Add(New DataColumn("IDUsuario", GetType(Integer)))
        dt.Columns.Add(New DataColumn("TipoDocumento", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocumento", GetType(String)))
        dt.Columns.Add(New DataColumn("Full_Name", GetType(String)))

        For Each i In UsuarioSA.ListadoUsuariosXcliente(Gempresas.IDCliente)
            Dim dr As DataRow = dt.NewRow()

            dr(0) = i.IDUsuario
            If (i.TipoDocumento.Length > 0) Then
                dr(1) = i.TipoDocumento
            Else
                dr(1) = ""
            End If
            If ((i.NroDocumento.Length) > 0) Then
                dr(2) = i.NroDocumento
            Else
                dr(2) = ""
            End If
            dr(3) = i.Full_Name
            dt.Rows.Add(dr)
        Next

        dgUsuarios.DataSource = dt
        dgUsuarios.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub
#End Region

#Region "Events"
    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        Cursor = Cursors.WaitCursor
        GetUsuariosSistema()
        Cursor = Cursors.Default
    End Sub

    Private Sub dgUsuarios_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgUsuarios.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            dgUsuarios.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub dgUsuarios_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgUsuarios.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgUsuarios)
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Cursor = Cursors.WaitCursor
        Dim f As New frmCrearUsuariosDelSistema
        f.strEstadoManipulacion = ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        GetUsuariosSistema()
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click

    End Sub
#End Region

End Class