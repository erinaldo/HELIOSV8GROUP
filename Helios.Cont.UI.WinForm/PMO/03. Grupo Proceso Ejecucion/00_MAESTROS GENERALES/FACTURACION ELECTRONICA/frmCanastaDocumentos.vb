Imports System.ComponentModel
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.Presentation.WinForm
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports System.IO
Imports OpenInvoicePeru.Comun.Dto.Intercambio
Imports OpenInvoicePeru.Comun.Dto.Modelos

Public Class frmCanastaDocumentos

#Region "Constructor"
    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        GetTableGrid()
        'FormatoGridAvanzado(GridGroupingControl1, False, False)
        GridCFG(GridGroupingControl1)
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
#End Region

#Region "Metodos"


    Private Function GetMappingFacturaVerificado(objetoPr As documentoventaAbarrotes) As List(Of documentoventaAbarrotes)
        'Dim totalesAlmacenSA As New TotalesAlmacenSA
        'Dim obj As totalesAlmacen
        'Dim cantidadDisponibleXLote As Decimal = 0

        Dim obj As New documentoVentaAbarrotesSA

        Dim objeto As documentoventaAbarrotes

        'Dim CantidadSolicitada = InputBox("Ingrese cantidad de venta" & vbCrLf &
        '                                  "Precio x " & precio.descripcion, Record.GetValue("descripcion"), "")

        'If IsNumeric(CantidadSolicitada) Then
        '    If CantidadSolicitada <= 0 Then
        '        Throw New Exception("Ingrese una cantidad mayor a cero")
        '    End If
        '    Dim lista = totalesAlmacenSA.GetDetalleLoteXproducto(New totalesAlmacen With
        '                                        {.idEmpresa = Gempresas.IdEmpresaRuc,
        '                                        .idAlmacen = Integer.Parse(Record.GetValue("idalmacen")),
        '                                        .idItem = Integer.Parse(Record.GetValue("idItem"))
        '                                        })


        '    Dim cantidadDisponible = lista.Sum(Function(o) o.cantidad)

        '    If CantidadSolicitada > cantidadDisponible Then
        '        Throw New Exception("Ingrese una cantidad menor, disponible al inventario")
        '    End If

        GetMappingFacturaVerificado = New List(Of documentoventaAbarrotes)

        GetMappingFacturaVerificado.Add(objetoPr)

        Dim consulta = obj.BuscarNotasXDocumento(objetoPr.idDocumento)


        For Each i In consulta

            objeto = New documentoventaAbarrotes

            objeto.idDocumento = i.idDocumento
            objeto.tipoDocumento = i.tipoDocumento
            objeto.serieVenta = i.serieVenta
            objeto.numeroVenta = i.numeroVenta
            objeto.ImporteNacional = i.ImporteNacional
            objeto.serie = objetoPr.serieVenta & "-" & objetoPr.numeroVenta

            GetMappingFacturaVerificado.Add(objeto)

        Next




        'GetMappingInventarioVerificado = New List(Of totalesAlmacen)
        '    For Each i In lista
        '        cantidadDisponibleXLote = i.cantidad
        '        If CantidadSolicitada > 0 Then
        '            If i.StockSaldo > 0 Then
        '                If i.StockSaldo > CantidadSolicitada Then
        '                    Dim canUso = CantidadSolicitada
        '                    i.CantidadUsada = canUso

        '                ElseIf i.StockSaldo = CantidadSolicitada Then
        '                    i.CantidadUsada = CantidadSolicitada
        '                Else
        '                    Dim canUso = i.StockSaldo
        '                    i.CantidadUsada = canUso
        '                End If
        '                CantidadSolicitada -= i.CantidadUsada 'ImporteDisponible

        '                obj = New totalesAlmacen
        '                obj = i
        '                obj.cantidad = i.CantidadUsada
        '                obj.NomAlmacen = i.NomAlmacen
        '                obj.idUnidad = i.idUnidad
        '                obj.codigoLote = i.CustomLote.codigoLote
        '                obj.cantidad2 = cantidadDisponibleXLote
        '                obj.tipoConfiguracion = precio.idPrecio
        '                obj.PMprecioMN = precio.precioMN
        '                obj.PMprecioME = precio.precioME
        '                obj.tipoConfiguracion = precio.idPrecio
        '                GetMappingInventarioVerificado.Add(obj)
        '            End If
        '        End If
        '    Next
        'Else
        '    Throw New Exception("Ingrese una cantidad válida")
        'End If
    End Function

    Private Sub GetproductoSelect()
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim sa As New TotalesAlmacenSA
        Dim r As Record
        Dim objetoDocPrin As documentoventaAbarrotes

        r = GridGroupingControl1.Table.CurrentRecord
        'Dim precios = precioSA.ListarPreciosXproductoMaxFecha(0, r.GetValue("idItem"))

        'If precios.Count = 0 Then
        '    MessageBox.Show("El producto seleccionado no tiene precios configurados!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub
        'End If


        objetoDocPrin = New documentoventaAbarrotes

        objetoDocPrin.idDocumento = CInt(r.GetValue("idDocumento"))
        objetoDocPrin.tipoDocumento = r.GetValue("tipoDoc")
        objetoDocPrin.serieVenta = r.GetValue("serie")
        objetoDocPrin.numeroVenta = CInt(r.GetValue("numero"))
        objetoDocPrin.ImporteNacional = CDec(r.GetValue("importe"))




        'Dim listaFactura = GetMappingFacturaVerificado(r.GetValue("idDocumento"))

        Dim listaFactura = GetMappingFacturaVerificado(objetoDocPrin)
        'Dim obj = sa.GetUbicarArticuloLote(
        '    New totalesAlmacen With
        '    {
        '    .idAlmacen = Integer.Parse(r.GetValue("idalmacen")),
        '    .idItem = Val(r.GetValue("idItem")),
        '    .codigoLote = Integer.Parse(r.GetValue("codigoLote"))
        '    })

        'obj.codigoLote = Integer.Parse(r.GetValue("codigoLote"))
        'obj.idAlmacen = Integer.Parse(r.GetValue("idalmacen"))
        'obj.NomAlmacen = r.GetValue("presentacion")

        'obj.PMprecioMN = precios.FirstOrDefault.precioMN ' Me.GridGroupingControl2.Table.CurrentRecord.GetValue("Preciomn")
        'obj.PMprecioME = precios.FirstOrDefault.precioME 'Me.GridGroupingControl2.Table.CurrentRecord.GetValue("Preciome")
        'obj.tipoConfiguracion = precios.FirstOrDefault.idPrecio 'Me.GridGroupingControl2.Table.CurrentRecord.GetValue("idPrecio")
        'obj.Marca = r.GetValue("tipo")

        If listaFactura.Count > 0 Then
            Dim miInterfaz As IListaDocumento = TryCast(Me.Owner, IListaDocumento)
            If miInterfaz IsNot Nothing Then miInterfaz.EnviarListaDocumento(listaFactura)
        End If
    End Sub


    Sub ListarFacturas(fecha As DateTime)
        Dim documentoSA = New documentoVentaAbarrotesSA

        Dim consulta = documentoSA.BuscarDocumentosFecha(fecha, "01")

        For Each i In consulta
            Me.GridGroupingControl1.Table.AddNewRecord.SetCurrent()
            Me.GridGroupingControl1.Table.AddNewRecord.BeginEdit()
            Me.GridGroupingControl1.Table.CurrentRecord.SetValue("idDocumento", i.idDocumento)
            Me.GridGroupingControl1.Table.CurrentRecord.SetValue("tipoDoc", i.tipoDocumento)
            Me.GridGroupingControl1.Table.CurrentRecord.SetValue("serie", i.serieVenta)
            Me.GridGroupingControl1.Table.CurrentRecord.SetValue("numero", i.numeroVenta)
            Me.GridGroupingControl1.Table.CurrentRecord.SetValue("importe", i.ImporteNacional)
            Me.GridGroupingControl1.Table.AddNewRecord.EndEdit()
        Next

    End Sub

    Sub GetTableGrid()
        Dim dt As New DataTable()

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("tipoDoc")
        dt.Columns.Add("serie")
        dt.Columns.Add("numero")
        dt.Columns.Add("importe")

        GridGroupingControl1.DataSource = dt
    End Sub

    Sub GridCFG(grid As GridGroupingControl)
        grid.TableOptions.ShowRowHeader = False
        grid.TopLevelGroupOptions.ShowCaption = False

        Dim colorx As New GridMetroColors
        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        grid.SetMetroStyle(colorx)
        grid.BorderStyle = System.Windows.Forms.BorderStyle.None

        'Me.gridGroupingControl1.BrowseOnly = true
        'Me.gridGroupingControl1.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
        grid.TableOptions.SelectionBackColor = Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        grid.AllowProportionalColumnSizing = False
        grid.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        grid.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        grid.Table.DefaultColumnHeaderRowHeight = 25
        grid.Table.DefaultRecordRowHeight = 20
        grid.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Sub FormatoGridAvanzado(GGC As GridGroupingControl, FullRowSelect As Boolean, AllowProportionalColumnSizing As Boolean)
        Dim colorx As New GridMetroColors()
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = BorderStyle.None
        '  GGC.BrowseOnly = True
        If FullRowSelect = True Then
            GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
            GGC.TableOptions.ListBoxSelectionCurrentCellOptions = GridListBoxSelectionCurrentCellOptions.HideCurrentCell
            GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
            GGC.TableOptions.SelectionBackColor = Color.Gray
        End If
        GGC.AllowProportionalColumnSizing = AllowProportionalColumnSizing
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        GGC.Table.DefaultColumnHeaderRowHeight = 27
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub
#End Region

    Private Sub frmCanastaDocumentos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub GridGroupingControl1_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridGroupingControl1.TableControlCellClick

    End Sub

    Private Sub GridGroupingControl1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles GridGroupingControl1.MouseDoubleClick

    End Sub

    Private Sub GridGroupingControl1_TableControlCellDoubleClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridGroupingControl1.TableControlCellDoubleClick

    End Sub

    Private Sub GridGroupingControl1_TableControlCurrentCellControlDoubleClick(sender As Object, e As GridTableControlControlEventArgs) Handles GridGroupingControl1.TableControlCurrentCellControlDoubleClick
        Try
            If GridGroupingControl1.Table.CurrentRecord IsNot Nothing Then
                GetproductoSelect()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class