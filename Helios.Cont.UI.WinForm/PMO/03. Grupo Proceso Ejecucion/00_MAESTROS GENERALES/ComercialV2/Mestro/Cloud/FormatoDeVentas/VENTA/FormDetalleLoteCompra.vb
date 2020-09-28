Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.GroupingGridExcelConverter

Public Class FormDetalleLoteCompra



#Region "Attributes"
    Public Property almacenSA As New almacenSA
    Public Property TotalesAlmacenSA As New TotalesAlmacenSA
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)

    Dim conditionDataBarRule1 As Syncfusion.Windows.Forms.Grid.Grouping.ConditionalFormatDataBarRule = New Syncfusion.Windows.Forms.Grid.Grouping.ConditionalFormatDataBarRule()
    Dim gridConditionalFormatDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor()
#End Region

#Region "Constructor"

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        FormatoGridAvanzado(dgvKardexVal, False, False, 7.5F)
        'FormatoGridBlack(dgvKardexVal, False)
        OrdenamientoGrid(dgvKardexVal, False)
        LoadCombos()

        Me.dgvKardexVal.TableDescriptor.Columns("descripcion").Appearance.AnyRecordFieldCell.HorizontalAlignment = GridHorizontalAlignment.Left
        Me.dgvKardexVal.TableDescriptor.Columns("descripcion").Appearance.AnyRecordFieldCell.WrapText = False
        Me.dgvKardexVal.TableDescriptor.Columns("descripcion").Appearance.AnyRecordFieldCell.Trimming = StringTrimming.EllipsisCharacter

        Me.dgvKardexVal.TableControl.CellToolTip.AutomaticDelay = 25000

        ' Add any initialization after the InitializeComponent() call.

    End Sub

#End Region


#Region "Metodos"

    Private Sub LoadCombos()
        dgvKardexVal.Table.Records.DeleteAll()
        dgvKardexVal.TableDescriptor.Columns("Clasificacion").Width = 0
        dgvKardexVal.TableDescriptor.Columns("NroLote").Width = 0
        'dgvKardexVal.TableDescriptor.Columns("fechaLote").Width = 0
        dgvKardexVal.TableDescriptor.Columns("cantmax").Width = 0
        dgvKardexVal.TableDescriptor.Columns("cantmin").Width = 0
        dgvKardexVal.TableDescriptor.Columns("status").Width = 0
        dgvKardexVal.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell


        cboTipoExistencia.DisplayMember = "descripcion"
        cboTipoExistencia.ValueMember = "codigoDetalle"
        cboTipoExistencia.DataSource = GetExistencias()

        cboAlmacen.DisplayMember = "descripcionAlmacen"
        cboAlmacen.ValueMember = "idAlmacen"
        cboAlmacen.DataSource = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
    End Sub

    Private Sub GetInventario(be As totalesAlmacen)
        Try


            Dim totalesAlmacenBE As New List(Of totalesAlmacen)
            Dim dt As New DataTable("Lista de productos ")
            'Clasificicacion
            dt.Columns.Add(New DataColumn("Clasificacion", GetType(String)))
            dt.Columns.Add(New DataColumn("origenRecaudo", GetType(String)))
            dt.Columns.Add(New DataColumn("descripcion", GetType(String)))


            'lower case p
            dt.Columns.Add(New DataColumn("tipoExistencia", GetType(String)))
            dt.Columns.Add(New DataColumn("unidadMedida", GetType(String)))

            dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
            dt.Columns.Add(New DataColumn("importeSoles", GetType(Decimal)))
            dt.Columns.Add(New DataColumn("idItem", GetType(Integer)))

            dt.Columns.Add(New DataColumn("cantmax", GetType(Decimal)))
            dt.Columns.Add(New DataColumn("cantmin", GetType(Decimal)))
            dt.Columns.Add(New DataColumn("idmovimiento", GetType(Integer)))
            dt.Columns.Add(New DataColumn("marca", GetType(String)))
            dt.Columns.Add(New DataColumn("presentacion", GetType(String)))
            dt.Columns.Add("status")
            dt.Columns.Add("fechaLote")
            dt.Columns.Add("NroLote")
            dt.Columns.Add("codigoLote")
            dt.Columns.Add("importeTotal")
            dt.Columns.Add("resumentotalcosto")
            dt.Columns.Add("detalle")
            dt.Columns.Add("idSubClasificacion")
            dt.Columns.Add("estado")
            dt.Columns.Add("provedor")
            dt.Columns.Add("nroDoc")
            dt.Columns.Add("idCaracteristica")
            dt.Columns.Add("modelo")

            Dim listaInventario As New List(Of totalesAlmacen)

            Select Case ComboParametros.Text
                Case "SOLO ARTICULOS CON STOCK"
                    listaInventario = TotalesAlmacenSA.GetLotesExistentesDetalle(be.idAlmacen).Where(Function(o) o.cantidad > 0).OrderBy(Function(o) o.descripcion).ToList
                Case "-TODOS-"
                    listaInventario = TotalesAlmacenSA.GetLotesExistentesDetalle(be.idAlmacen).OrderBy(Function(o) o.descripcion).ToList
            End Select

            For Each i As totalesAlmacen In listaInventario 'TotalesAlmacenSA.GetInventarioGeneral(be).Where(Function(o) o.cantidad > 0).OrderBy(Function(o) o.descripcion).ToList
                Dim strGravado As String = IIf(i.origenRecaudo = 1, "Gravado", "No gravado")
                Dim dr As DataRow = dt.NewRow()
                dr(0) = i.Clasificicacion
                dr(1) = strGravado
                dr(2) = i.descripcion
                dr(3) = i.tipoExistencia
                dr(4) = i.unidadMedida
                dr(5) = i.cantidad
                dr(6) = i.importeSoles
                dr(7) = i.idItem

                If i.cantidadMaxima Is Nothing Then
                    dr(8) = CDec(0.0)
                Else
                    dr(8) = i.cantidadMaxima
                End If


                If i.cantidadMinima Is Nothing Then
                    dr(9) = CDec(0.0)
                Else
                    dr(9) = i.cantidadMinima
                End If
                dr(10) = i.idMovimiento
                dr(11) = i.Marca
                dr(12) = i.Presentacion
                dr(13) = i.status
                If i.fechaLote.HasValue Then
                    dr(14) = i.fechaLote.Value.ToString("dd-MM-yyyy")
                End If

                dr(15) = i.codigoLote
                dr(16) = i.codigoLote

                Dim total = i.importeSoles.GetValueOrDefault * 0.18
                total = FormatNumber(i.importeSoles.GetValueOrDefault + total, 2)
                If (i.origenRecaudo = 1) Then
                    dr(17) = total.ToString("N2")
                Else
                    dr(17) = "-"
                End If

                If (i.origenRecaudo = 1) Then
                    dr(18) = total.ToString("N2")
                Else
                    dr(18) = i.importeSoles
                End If
                dr(19) = i.CantDetalle
                dr(20) = i.idSubClasificacion
                If i.CantDetalle = 0 Then
                    dr(21) = "PENDIENTE"
                Else
                    dr(21) = "DETALLADO"
                End If
                dr(22) = i.NombreProveedor
                dr(23) = i.NroLote
                dr(24) = i.idCaracteristica
                dr(25) = i.modelo
                dt.Rows.Add(dr)
            Next
            setDataSource(dt)

            ''dgvKardexVal.DataSource = dt
            ''dgvKardexVal.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
            ''dgvKardexVal.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
            '''''ComboStatus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub setDataSource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

            Dim deleg As New SetDataSourceDelegate(AddressOf setDataSource)
            Invoke(deleg, New Object() {table})
        Else
            dgvKardexVal.DataSource = table
            dgvKardexVal.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
            dgvKardexVal.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
            dgvKardexVal.TableDescriptor.Columns("cantidad").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
            dgvKardexVal.TableDescriptor.Columns("cantidad").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Right
            'dgvKardexVal.TableDescriptor.Columns("descripcion").Appearance.AnyCell.Trimming = StringTrimming.EllipsisWord

            dgvKardexVal.TableDescriptor.Columns("cantidad").Width = 200
            Me.dgvKardexVal.UseRightToLeftCompatibleTextBox = True
            PictureLoad.Visible = False
            BunifuFlatButton4.Enabled = True
            GetDatabar()
            'Dim conditionalDescriptor As New GridConditionalFormatDescriptor()

            'object for data bar rule
            'Dim conditionDataBarRule1 As New ConditionalFormatDataBarRule()

            ''Assigning column for data bar
            'conditionDataBarRule1.ColumnName = "Profit"

            ''Adding the rule to rules collection
            'conditionalDescriptor.Rules.Add(conditionDataBarRule1)

            ''Adding descriptor.
            'Me.gridGroupingControl1.TableDescriptor.ConditionalFormats.Add(conditionalDescriptor)

        End If
    End Sub

#End Region

#Region "Databar"
    Private Sub GetDatabar()
        gridConditionalFormatDescriptor1.Expression = "[cantidad] > '0' AND [cantidad] < '100' "
        gridConditionalFormatDescriptor1.Name = "ConditionalFormat 1"
        conditionDataBarRule1.ColumnName = "cantidad"
        conditionDataBarRule1.AxisPosition = AxisPosition.Automatic
        conditionDataBarRule1.FillNegativeColorSameAsPositive = False
        conditionDataBarRule1.AutoCalculateMinMax = True
        conditionDataBarRule1.PositiveBar.FillStyle = FillStyle.Gradient
        conditionDataBarRule1.PositiveBar.GradientFillColor1 = Color.DeepSkyBlue
        conditionDataBarRule1.PositiveBar.GradientFillColor2 = Color.FromArgb(255, 255, 255)
        conditionDataBarRule1.PositiveBar.BorderColor = conditionDataBarRule1.PositiveBar.GradientFillColor1
        conditionDataBarRule1.NegativeBar.FillStyle = FillStyle.Gradient
        conditionDataBarRule1.NegativeBar.GradientFillColor1 = Color.FromArgb(235, 82, 82)
        conditionDataBarRule1.NegativeBar.GradientFillColor2 = Color.FromArgb(254, 255, 255)
        conditionDataBarRule1.NegativeBar.BorderColor = Color.Red
        conditionDataBarRule1.Name = "ConditionalDataBarRule 1"
        gridConditionalFormatDescriptor1.Rules.Add(conditionDataBarRule1)

        Me.dgvKardexVal.TableDescriptor.ConditionalFormats.Add(gridConditionalFormatDescriptor1)
    End Sub
#End Region

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        If cboAlmacen.SelectedIndex > -1 Then
            Dim codAlmacen = cboAlmacen.SelectedValue
            Dim tipoExistencia = cboTipoExistencia.SelectedValue
            If IsNumeric(codAlmacen) Then
                PictureLoad.Visible = True
                BunifuFlatButton4.Enabled = False
                Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetInventario(New totalesAlmacen With {.idAlmacen = codAlmacen, .tipoExistencia = tipoExistencia, .InvAcumulado = False})))
                thread.Start()
            End If
        End If
    End Sub

    Private Sub FormDetalleLoteCompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub dgvKardexVal_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvKardexVal.TableControlCellClick

    End Sub

    Private Sub dgvKardexVal_TableControlCurrentCellControlDoubleClick(sender As Object, e As GridTableControlControlEventArgs) Handles dgvKardexVal.TableControlCurrentCellControlDoubleClick







    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Dim r As Record = dgvKardexVal.Table.CurrentRecord
        If r IsNot Nothing Then
            If dgvKardexVal.Table.Records.Count > 0 Then
                'Dim value As String = r.GetValue("idLote").ToString()




                Dim p As Record = dgvKardexVal.Table.CurrentRecord
                If p IsNot Nothing Then
                    If dgvKardexVal.Table.Records.Count > 0 Then


                        Dim conteo = CInt(r.GetValue("detalle").ToString())


                        If conteo = 0 Then


                            'Dim f As New FormRegistroDetalleLote(CInt(r.GetValue("cantidad").ToString()), CInt(r.GetValue("codigoLote").ToString()))

                            'f.StartPosition = FormStartPosition.CenterParent
                            'f.Show()




                            Dim f As New FormRegistroDetalleLote(CInt(r.GetValue("cantidad").ToString()), CInt(r.GetValue("codigoLote").ToString()), CInt(r.GetValue("idSubClasificacion").ToString()), CInt(r.GetValue("idCaracteristica").ToString()))
                            f.lblDescripcion.Text = r.GetValue("descripcion").ToString()
                            f.lblModelo.Text = r.GetValue("modelo").ToString()
                            f.StartPosition = FormStartPosition.CenterParent
                            f.ShowDialog(Me)




                            If cboAlmacen.SelectedIndex > -1 Then
                                Dim codAlmacen = cboAlmacen.SelectedValue
                                Dim tipoExistencia = cboTipoExistencia.SelectedValue
                                If IsNumeric(codAlmacen) Then
                                    PictureLoad.Visible = True
                                    BunifuFlatButton4.Enabled = False
                                    Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetInventario(New totalesAlmacen With {.idAlmacen = codAlmacen, .tipoExistencia = tipoExistencia, .InvAcumulado = False})))
                                    thread.Start()
                                End If
                            End If




                        Else

                            MessageBox.Show("El lote ya se Ingreso Caracteristicas")

                        End If

                        'p.SetValue("idLote", r.GetValue("cantidad").ToString())
                        'p.SetValue("idDetalleLote", r.GetValue("idDetalleLote").ToString())

                        'Dim DetalleAdicional = r.GetValue("color").ToString() & "-" & r.GetValue("marca").ToString() & "-" & r.GetValue("modelo").ToString()

                        'p.SetValue("DetalleAdicional", DetalleAdicional)
                    End If
                End If


            End If
        End If
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        Dim f As New FormClasificacionItem
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
    End Sub
End Class