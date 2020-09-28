Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid

Public Class frmDetalleReferenciasComprobantes

#Region "Attributes"
    Public Property CompraSA As New DocumentoCompraSA
    Public Property CompraDetSA As New DocumentoCompraDetalleSA
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
#End Region

#Region "Constructors"
    Public Sub New(listadoComprobantes As List(Of documentocompra))

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridPequeño(dgvServicios, True)
        LoadReferencias(listadoComprobantes)
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

    Private Sub LoadReferencias(listadoComprobantes As List(Of documentocompra))
        Dim dSet As New DataSet()
        Dim childtable As New DataTable
        Dim parentable As New DataTable

        parentable = New DataTable
        childtable = New DataTable

        parentable.Columns.Add("id")
        parentable.Columns.Add("fechadoc")
        parentable.Columns.Add("tipodoc")
        parentable.Columns.Add("serie")
        parentable.Columns.Add("numero")
        parentable.Columns.Add("moneda")
        parentable.Columns.Add("importe")
        '-----------------------------------------------------
        childtable.Columns.Add("id")
        childtable.Columns.Add("motivo")
        childtable.Columns.Add("gravado")
        childtable.Columns.Add("iditem")
        childtable.Columns.Add("articulo")
        childtable.Columns.Add("unidad")
        childtable.Columns.Add("tipoexistencia")
        childtable.Columns.Add("importe")
        '------------------------------------------------------

        'Dim ListadoReferencias = CompraSA.GetListarNotasPorIdCompraPadre(idCompra, "00")
        Dim listaDetalles As New List(Of documentocompradetalle)
        For Each i In listadoComprobantes
            parentable.Rows.Add(i.idDocumento, i.fechaDoc, i.tipoDoc, i.serie, i.numeroDoc, i.monedaDoc, i.importeTotal)
            listaDetalles.AddRange(CompraDetSA.UbicarDocumentoCompraDetalle(i.idDocumento))
        Next

        For Each i In listaDetalles

            Dim motivo As String = String.Empty


            Select Case i.operacionNota
                Case "9913"
                    motivo = "NC-DISMINUIR CANTIDAD"

                Case "9914"
                    motivo = "NC-DISMINUIR IMPORTE"
                Case "9915"
                    motivo = "NC-DISMINUIR CANTIDAD E IMPORTE"
                Case "9916"
                    motivo = "NC-DEVOLUCION DE EXISTENCIAS"
                Case "9917"
                    motivo = "BONIFICACIONES RECIBIDAS (OPC. Beneficios)"
                Case "9918"
                    motivo = "BONIFICACIONES RECIBIDAS (OPC. Reduc. costos)"
                Case "9919"
                    motivo = "INGRESO CUENTAS MANUALES"
                Case "9920"
                    motivo = "DEVOLUCION X NOTA DE CREDITO A CLIENTE"
                Case "9921"
                    motivo = "NB-INCREMENTO DEL COSTO"
                Case "9922"
                    motivo = "DEVOLUCION X NOTA DE CREDITO A PROVEEDOR"
                Case "9925"
                    motivo = "GASTOS FINANCIEROS"
            End Select

            childtable.Rows.Add(i.idDocumento, motivo, i.destino, i.idItem, i.descripcionItem, i.unidad1, i.tipoExistencia, i.importe)

        Next

        dSet.Tables.AddRange(New DataTable() {parentable, childtable})

        Dim parentColumn As DataColumn = parentable.Columns("id")
        Dim childColumn As DataColumn = childtable.Columns("id")
        'dSet.Relations.Clear()
        dSet.Relations.Add("ParentToChild", parentColumn, childColumn)

        Me.dgvServicios.DataSource = parentable
        Me.dgvServicios.Engine.BindToCurrencyManager = False

        'Me.dgvCajasAssig.GridVisualStyles = GridVisualStyles.Metro
        'Me.dgvCajasAssig.GridOfficeScrollBars = OfficeScrollBars.Metro
        Me.dgvServicios.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
        Me.dgvServicios.TopLevelGroupOptions.ShowCaption = False

        dgvServicios.TableModel.ColWidths.ResizeToFit(GridRangeInfo.Table(), GridResizeToFitOptions.ResizeCoveredCells)

    End Sub
#End Region

#Region "Events"
    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dim obj As New InfoNotas
        obj.seguirOperaion = "NO"
        obj.tieneGasto = "NO"

        Tag = obj
        Close()
    End Sub
    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        Dim tieneGasto As Integer = CInt(0)
        For Each p In dgvServicios.Table.Records
            For Each n In p.NestedTables
                Dim ctc As ChildTable = n.ChildTable
                For Each rec As Record In ctc.Records

                    Dim valor As String = rec.GetValue("motivo").ToString

                    If valor = "GASTOS FINANCIEROS" Then
                        tieneGasto += tieneGasto + 1
                    End If
                Next rec
            Next
        Next
        Dim obj As New InfoNotas
        obj.seguirOperaion = "SI"
        If tieneGasto > 0 Then
            obj.tieneGasto = "SI"
        Else
            obj.tieneGasto = "NO"
        End If

        Tag = obj
        Close()


    End Sub

    Private Sub dgvCompras_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvServicios.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            'Dim str = dgvCompras.TableModel(e.TableCellIdentity.RowIndex, 1).CellValue
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            Me.dgvServicios.TableControl.Selections.Clear()
        End If

        If Not IsNothing(e.TableCellIdentity.Column) Then
            'Dim el As Element = e.TableCellIdentity.DisplayElement

            'If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "tipoCompra")) Then
            '    If Not IsNothing(dgvCompras.TableModel(e.TableCellIdentity.RowIndex, 1).CellValue) Then
            '        Dim str = dgvCompras.TableModel(e.TableCellIdentity.RowIndex, 1).CellValue
            '        Select Case str
            '            Case TIPO_COMPRA.COMPRA
            '                e.Style.CellValue = "Compra"
            '            Case TIPO_COMPRA.COMPRA_SERVICIO_PUBLICO
            '                e.Style.CellValue = "Servicio público"
            '            Case TIPO_COMPRA.COMPRA_RECIBO_HONORARIOS
            '                e.Style.CellValue = "Recibo honorario"
            '            Case TIPO_COMPRA.COMPRA_ANTICIPADA_OTORGADO
            '                e.Style.CellValue = "Anticipo"
            '            Case TIPO_COMPRA.COMPRA_ANTICIPADA_RECIBIDA
            '                e.Style.CellValue = "Anticipo"
            '            Case TIPO_COMPRA.NOTA_CREDITO
            '                e.Style.CellValue = "Nota credito"
            '            Case TIPO_COMPRA.NOTA_DEBITO
            '                e.Style.CellValue = "Nota debito"
            '            Case TIPO_COMPRA.BONIFICACIONES_RECIBIDAS
            '                e.Style.CellValue = "Bonificación"
            '        End Select
            '    End If
            'Else
            '    'e.Style.[ReadOnly] = False
            'End If
        End If

    End Sub

    Private Sub dgvCompras_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvServicios.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvServicios)
    End Sub
#End Region

End Class