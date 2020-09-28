Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class FormPreciosVehiculo

#Region "Attributes"

#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(GridPrecios, True, False, 10.0F, BorderStyle.None)
        FormatoGridAvanzado(GridServicioPrecios, False, False, 10.0F, BorderStyle.None)

        GetVehiculosActivos()
    End Sub
#End Region

#Region "Methods"
    Public Sub GetVehiculosActivos()
        'Dim rutaSA As New RutaTareoAutoSA
        Dim rutas As New RutasSA
        Dim dt As New DataTable
        dt.Columns.Add("idVehiculo")
        dt.Columns.Add("rutaid")
        dt.Columns.Add("ruta")
        dt.Columns.Add("horarioid")
        dt.Columns.Add("horario")
        dt.Columns.Add("horaPartida")
        dt.Columns.Add("horaLlegada")

        For Each i In rutas.GellAllRutas(New rutas With {.estado = 1})
            dt.Rows.Add("-", i.ruta_id, $"{i.ciudadOrigen}-{i.ciudadDestino}", i.ruta_horarios.First.horario_id, i.ruta_horarios.First.dias, i.ruta_horarios.First.horaPartida.Value.ToShortTimeString(), i.ruta_horarios.First.horaLlegada.Value.ToShortTimeString)
        Next
        GridPrecios.DataSource = dt
    End Sub

    Public Sub GetServicios(ruta_id As Integer, horario_id As Integer)
        Dim rutaSA As New Ruta_HorarioServiciosSA
        Dim dt As New DataTable
        dt.Columns.Add("serivicioid")
        dt.Columns.Add("servicio")
        dt.Columns.Add("costo")
        dt.Columns.Add("action")

        For Each i In rutaSA.GetServiciosVentaTransporte(New ruta_HorarioServicios With {.ruta_id = ruta_id, .horario_id = horario_id})
            dt.Rows.Add(i.codigoServicio, i.descripcionLarga, i.costoEstimado)
        Next
        GridServicioPrecios.DataSource = dt
    End Sub

    Private Sub GridResumenFormaPago_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles GridPrecios.SelectedRecordsChanged
        Cursor = Cursors.WaitCursor
        Try
            If e.SelectedRecord IsNot Nothing Then
                Dim r As Record = e.SelectedRecord.Record
                If r IsNot Nothing Then
                    If GridPrecios.Table.Records.Count > 0 Then
                        GetServicios(Integer.Parse(r.GetValue("rutaid")), Integer.Parse(r.GetValue("horarioid")))
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Atención")
        End Try

        Cursor = Cursors.Default
    End Sub
#End Region

#Region "Events"
    Private Sub dgvKardexVal_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles GridServicioPrecios.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 4 Then
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

    Private Sub dgvKardexVal_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles GridServicioPrecios.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim rutaSA As New Ruta_HorarioServiciosSA
            If e.Inner.ColIndex = 4 Then
                GridServicioPrecios.TableControl.CurrentCell.EndEdit()
                GridServicioPrecios.TableControl.Table.TableDirty = True
                GridServicioPrecios.TableControl.Table.EndEdit()
                'GridServicioPrecios.TableModel.Table.EndEdit()
                Dim id = GridServicioPrecios.TableModel(e.Inner.RowIndex, 1).CellValue
                Dim precio = Decimal.Parse(GridServicioPrecios.TableModel(e.Inner.RowIndex, 3).CellValue)
                rutaSA.ActualizarPrecio(New ruta_HorarioServicios With {.codigoServicio = id, .costoEstimado = precio})
                MessageBox.Show("Precio actualizado con exito", "Atención", MessageBoxButtons.OK)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BunifuFlatButton11_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton11.Click
        GetVehiculosActivos()
    End Sub

    Private Sub GridPrecios_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridPrecios.TableControlCellClick

    End Sub
#End Region

End Class
