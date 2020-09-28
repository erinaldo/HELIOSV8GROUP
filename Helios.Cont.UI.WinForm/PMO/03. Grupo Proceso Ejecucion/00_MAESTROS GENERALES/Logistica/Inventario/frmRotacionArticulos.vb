Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmRotacionArticulos

#Region "Attributes"
    Dim documentoSA As New documentoVentaAbarrotesSA
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridPequeño(dgvRotacion, True)
        txtfecInicio.Value = DateTime.Now
        txtfecFin.Value = DateTime.Now
    End Sub

#End Region

#Region "Methods"
    Sub VentasCantidadStock(cantidad As String, fechaini As Date, fechafin As Date, mayor As Decimal, menor As Decimal, nombre As String)
        Dim documentoventa As New List(Of documentoventaAbarrotesDet)
        Dim dt As New DataTable(nombre)
        dt.Columns.Add("idItem")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("monto")
        dt.Columns.Add("stock")
        dt.Columns.Add("idalmacen")
        documentoventa = documentoSA.VentasCantidadStock(cantidad, fechaini, fechafin, mayor, menor)
        For Each i In documentoventa
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idItem
            dr(1) = i.nombreItem
            dr(2) = i.monto1
            dr(3) = i.monto2
            dr(4) = i.NombreProveedor
            dt.Rows.Add(dr)
        Next
        dgvRotacion.DataSource = dt
    End Sub

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

#End Region

#Region "Events"
    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Me.Cursor = Cursors.WaitCursor
        If cboConsultaRotacion.Text = "0 - 10 unidades" Then
            VentasCantidadStock("1", txtfecInicio.Value, txtfecFin.Value, CDec(10.0), CDec(0.0), "filtro de 0 - 10 unidades")
        ElseIf cboConsultaRotacion.Text = "11 - 100 unidades" Then
            VentasCantidadStock("2", txtfecInicio.Value, txtfecFin.Value, CDec(100.0), CDec(11), "filtro de 11 - 100 unidades")
        ElseIf cboConsultaRotacion.Text = "101 - 500 unidades" Then
            VentasCantidadStock("3", txtfecInicio.Value, txtfecFin.Value, CDec(500.0), CDec(101), "filtro de 101 - 500 unidades")
        ElseIf cboConsultaRotacion.Text = "501 - a mas" Then
            VentasCantidadStock("4", txtfecInicio.Value, txtfecFin.Value, CDec(99999999), CDec(501), "filtro de 501 - a mas unidades")
        ElseIf cboConsultaRotacion.Text = "0 - a mas" Then
            VentasCantidadStock("4", txtfecInicio.Value, txtfecFin.Value, CDec(99999999), CDec(0), "filtro de  0 - a mas unidades")
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvRotacion_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvRotacion.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            dgvRotacion.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub dgvRotacion_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvRotacion.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvRotacion)
    End Sub
#End Region

End Class