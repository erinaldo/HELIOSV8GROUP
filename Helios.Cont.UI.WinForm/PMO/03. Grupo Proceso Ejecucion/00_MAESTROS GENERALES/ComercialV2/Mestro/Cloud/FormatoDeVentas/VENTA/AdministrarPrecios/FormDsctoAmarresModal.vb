Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Text.RegularExpressions
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports PopupControl
Imports ProcesosGeneralesCajamiSoft
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Public Class FormDsctoAmarresModal
    Public Property ItemsVentaDescontados As documentoventaAbarrotesDet
    Public Property ListaProductosAmarrados As List(Of documentoventaAbarrotesDet)
    Public Property frmVenta As FormVentaNueva

    Public Sub New(nroProductos As Integer, formventa As FormVentaNueva)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridBlack(GridBeneficioImporte, False)
        GridBeneficioImporte.TableDescriptor.AllowEdit = False
        ItemsVentaDescontados = New documentoventaAbarrotesDet
        ListaProductosAmarrados = New List(Of documentoventaAbarrotesDet)
        frmVenta = formventa
        GetProductos(nroProductos)
    End Sub

    Private Sub GetProductos(nroProductos As Integer)
        Dim obj As documentoventaAbarrotesDet
        '     Dim index As Integer = 0
        Do While nroProductos > 0
            Dim cod = System.Guid.NewGuid.ToString()
            obj = New documentoventaAbarrotesDet With {.CodigoCosto = cod, .CustomProducto = New detalleitems With {.descripcionItem = "Agregar item"}, .nombreItem = "Agregar item"}
            ListaProductosAmarrados.Add(obj)
            nroProductos -= 1
        Loop
        AgregarCanastaDescuentos()
    End Sub

    ''' <summary>
    ''' Agregar productos aplicados a beneficios por amarre: beneficio al item
    ''' </summary>
    Friend Sub AgregarCanastaDescuentos()
        Dim dt As New DataTable
        dt.Columns.Add("iditem")
        dt.Columns.Add("producto")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("btSeleccionar")

        For Each i In ListaProductosAmarrados
            dt.Rows.Add(i.CodigoCosto, i.CustomProducto.descripcionItem, 1)
        Next
        GridBeneficioImporte.DataSource = dt
    End Sub

    Private Sub GridBeneficioImporte_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridBeneficioImporte.TableControlCellClick

    End Sub

    Private Sub GridBeneficioImporte_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles GridBeneficioImporte.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 4 Then
                e.Inner.Style.Description = "Seleccionar"
                e.Inner.Style.TextColor = Color.Black
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
                                           New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
                    )
                '    e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
            End If
        End If
    End Sub

    Private Sub GridBeneficioImporte_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles GridBeneficioImporte.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        Dim precioSA As New detalleitemequivalencia_preciosSA
        Try
            If e.Inner.ColIndex = 4 Then
                Dim f As New FormCanastaVentaDscto(frmVenta.UCEstructuraCabeceraVentaV2, Me)
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog(Me)
                If f.Tag IsNot Nothing Then
                    Dim c = CType(f.Tag, documentoventaAbarrotesDet)
                    Dim sty As GridTableCellStyleInfo = e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex)
                    Dim record = sty.TableCellIdentity.DisplayElement.GetRecord()
                    If record IsNot Nothing Then
                        Dim codigo = record.GetValue("iditem")
                        Dim item = ListaProductosAmarrados.Where(Function(o) o.CodigoCosto = codigo).SingleOrDefault
                        ListaProductosAmarrados.Remove(item)
                        ListaProductosAmarrados.Add(c)
                        AgregarCanastaDescuentos()
                    End If
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BunifuThinButton22_Click(sender As Object, e As EventArgs) Handles BunifuThinButton22.Click

    End Sub
End Class