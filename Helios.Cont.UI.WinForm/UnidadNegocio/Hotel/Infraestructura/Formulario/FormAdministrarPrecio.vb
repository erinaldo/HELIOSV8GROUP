Imports Helios.Cont.Business.Entity
Imports Helios.Cont.Presentation.WinForm
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.GroupingGridExcelConverter
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class FormAdministrarPrecio

#Region "Attributes"
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridPequeño(dgvExistencias, False, 11.0F)
        CargarDatos()
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

    Private Sub CargarDatos()
        Try
            Dim distribucionInfraestructuraBE As New distribucionInfraestructura
            Dim distribucionInfraestructuraSA As New distribucionInfraestructuraSA

            Dim dt As New DataTable("Precios Generales")
            dt.Columns.Add(New DataColumn("idDistribucion", GetType(Integer)))
            dt.Columns.Add(New DataColumn("piso", GetType(String)))
            dt.Columns.Add(New DataColumn("nombre", GetType(String)))
            dt.Columns.Add(New DataColumn("numero", GetType(String)))
            dt.Columns.Add(New DataColumn("action", GetType(String)))

            distribucionInfraestructuraBE.estado = "A"

            For Each i In distribucionInfraestructuraSA.getDistribucionInfraestructura(distribucionInfraestructuraBE).ToList

                Dim dr As DataRow = dt.NewRow
                dr(0) = i.idDistribucion
                dr(1) = i.NombrePiso
                dr(2) = i.descripcionDistribucion
                dr(3) = (i.numeracion)
                dt.Rows.Add(dr)
            Next

            dgvExistencias.DataSource = dt
            dgvExistencias.Engine.BindToCurrencyManager = False
            dgvExistencias.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
            dgvExistencias.TopLevelGroupOptions.ShowCaption = True
            dgvExistencias.ShowRowHeaders = True
            dgvExistencias.TableOptions.ListBoxSelectionMode = SelectionMode.One

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region

#Region "Events"


    Private Sub frmExistenciaPrecios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvExistencias.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
    End Sub

    Private Sub GrabarNumero(idDistribucion As Integer, numero As String)
        Try
            Dim numeroSA As New distribucionInfraestructuraSA
            Dim numeroBE As New distribucionInfraestructura

            If (numero.Length <= 0) Then
                MessageBox.Show("No existe una numeracion")
                Exit Sub
            End If

            numeroBE.idDistribucion = idDistribucion
            numeroBE.numeracion = numero
            numeroBE.idEmpresa = Gempresas.IdEmpresaRuc

            numeroSA.EditarNumeracion(numeroBE)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgvKardexVal_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles dgvExistencias.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.Inner.ColIndex = 5 Then
                Dim idDistribucion = dgvExistencias.TableModel(e.Inner.RowIndex, 1).CellValue
                Dim numero = dgvExistencias.TableModel(e.Inner.RowIndex, 4).CellValue
                GrabarNumero(idDistribucion, numero)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgvKardexVal_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles dgvExistencias.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 5 Then
                e.Inner.Style.Description = "Grabar"
                e.Inner.Style.TextColor = Color.Black
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
                                           New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
                    )
                '    e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
            End If
        End If
    End Sub


    Private Sub dgvExistencias_TableControlKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvExistencias.TableControlKeyDown

        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'Dim precioSA As New ConfiguracionPrecioProductoSA
        'Dim precio As New configuracionPrecioProducto
        'Dim cc As GridCurrentCell = dgvExistencias.TableControl.CurrentCell
        'cc.ConfirmChanges()

        'If Not IsNothing(cc) Or dgvExistencias.TableControl.CurrentCell IsNot Nothing Then
        '    Select Case cc.ColIndex


        '        Case 7 ' 
        '            Dim r As Record = dgvExistencias.Table.CurrentRecord
        '            If Not IsNothing(r) Then


        '                r.SetValue("menor", r.GetValue("menor"))

        '            End If

        '    End Select
        'End If
    End Sub

    Private Sub dgvExistencias_TableControlKeyPress(sender As Object, e As GridTableControlKeyPressEventArgs) Handles dgvExistencias.TableControlKeyPress
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'Dim precioSA As New ConfiguracionPrecioProductoSA
        'Dim precio As New configuracionPrecioProducto
        'Dim cc As GridCurrentCell = dgvExistencias.TableControl.CurrentCell
        'cc.ConfirmChanges()

        'If Not IsNothing(cc) Or dgvExistencias.TableControl.CurrentCell IsNot Nothing Then
        '    Select Case cc.ColIndex


        '        Case 7 ' 
        '            Dim r As Record = dgvExistencias.Table.CurrentRecord
        '            If Not IsNothing(r) Then


        '                r.SetValue("menor", r.GetValue("menor"))

        '            End If

        '    End Select
        'End If
    End Sub

    Private Sub dgvExistencias_TableControlKeyUp(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvExistencias.TableControlKeyUp
        Dim cc As GridCurrentCell = dgvExistencias.TableControl.CurrentCell
        Dim style As GridTableCellStyleInfo = TryCast(cc.Renderer.CurrentStyle, GridTableCellStyleInfo)

        If style IsNot Nothing Then

            If e.Inner.KeyData = Keys.Enter Then
                ' // e.TableControl.Table.CurrentRecord.SetCurrent("FirstColumnName")
                e.TableControl.CurrentCell.MoveTo(cc.RowIndex, cc.ColIndex + 1, GridSetCurrentCellOptions.SetFocus)
            End If
            '   End Select
        End If
    End Sub

#End Region

End Class