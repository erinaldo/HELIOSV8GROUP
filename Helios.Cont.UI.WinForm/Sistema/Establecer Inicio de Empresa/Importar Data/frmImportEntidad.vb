Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Public Class frmImportEntidad
    Inherits frmMaster

    Public Property tipoentidad() As String

    Public Sub New(strTipoEntidad As String)

        ' This call is required by the designer.
        InitializeComponent()
        GridCFG(dgvEntidad)
        GetGridColumn()
        ' Add any initialization after the InitializeComponent() call.
        configuracionModuloV2(Gempresas.IdEmpresaRuc, "SI", Me.Text, GEstableciento.IdEstablecimiento)
        ImportarExcel(strTipoEntidad)
        Select Case strTipoEntidad
            Case TIPO_ENTIDAD.PROVEEDOR
                Me.CaptionLabels(0).Text = "Importar Proveedores"
            Case TIPO_ENTIDAD.CLIENTE
                Me.CaptionLabels(0).Text = "Importar Clientes"
        End Select
        tipoentidad = strTipoEntidad

    End Sub

#Region "Métodos"

    Sub GetGridColumn()
        Dim dt As New DataTable()
        dt.Columns.Add("idEntidad")
        dt.Columns.Add("idEmpresa")
        dt.Columns.Add("tipoEntidad")
        dt.Columns.Add("tipoPersona")
        dt.Columns.Add("tipoDoc")
        dt.Columns.Add("nrodoc")
        dt.Columns.Add("nombreCompleto")
        dt.Columns.Add("direccion")
        dt.Columns.Add("telefono")
        dt.Columns.Add("celular")
        dt.Columns.Add("email")
        dt.Columns.Add("moneda")
        dt.Columns.Add("tipoCambio")
        dt.Columns.Add("importeMN")
        dt.Columns.Add("importeME")

        dgvEntidad.DataSource = dt
    End Sub
    Dim colorx As New GridMetroColors()
    Sub GridCFG(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = System.Windows.Forms.BorderStyle.None

        '  GGC.BrowseOnly = True
        GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        GGC.TableOptions.ListBoxSelectionMode = SelectionMode.None
        GGC.TableOptions.SelectionBackColor = Color.FromArgb(85, 170, 255)
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        GGC.Table.DefaultColumnHeaderRowHeight = 45
        GGC.Table.DefaultRecordRowHeight = 40
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Public Sub ImportarExcel(strTipoEntidad As String)
        Dim strDestination As String = Nothing

        Dim dlgResult As DialogResult
        Dim icount As Integer = 1
        Try


            'Show dialog
            With OpenFileDialog1
                .Filter = "Microsoft Excel 2003|*.xls;*.xlsx" ' "All Files (*.*)|*.*|Excel files (*.xlsx)|*.xlsx|CSV Files (*.csv)|*.csv|XLS Files (*.xls)|*xls" '
                '  .ShowDialog()
                dlgResult = .ShowDialog
                strDestination = .FileName
                lblruta.Text = strDestination
            End With
            'If (strDestination <> "OpenFileDialog1") Then
            If dlgResult <> DialogResult.Cancel Then
                Dim fileName = strDestination ' "C:\Users\Jiuni\Desktop\CArpeta Compartida\SERVER NET\Name2.xls" '
                Dim book = New LinqToExcel.ExcelQueryFactory(fileName)
                Dim users = (From x In book.Worksheet(Of EntidadImport)("Hoja1") _
                            Select x).ToList

                For Each i In users
                    Me.dgvEntidad.Table.AddNewRecord.SetCurrent()
                    Me.dgvEntidad.Table.AddNewRecord.BeginEdit()
                    Me.dgvEntidad.Table.CurrentRecord.SetValue("idEntidad", icount)
                    Me.dgvEntidad.Table.CurrentRecord.SetValue("idEmpresa", Gempresas.IdEmpresaRuc)
                    Me.dgvEntidad.Table.CurrentRecord.SetValue("tipoEntidad", strTipoEntidad)
                    Me.dgvEntidad.Table.CurrentRecord.SetValue("tipoPersona", i.tipoPersona)
                    Me.dgvEntidad.Table.CurrentRecord.SetValue("tipoDoc", i.tipoDoc)
                    Me.dgvEntidad.Table.CurrentRecord.SetValue("nrodoc", i.nrodoc)
                    Me.dgvEntidad.Table.CurrentRecord.SetValue("nombreCompleto", i.nombreCompleto)
                    Me.dgvEntidad.Table.CurrentRecord.SetValue("direccion", i.direccion)

                    Me.dgvEntidad.Table.CurrentRecord.SetValue("telefono", i.telefono)
                    Me.dgvEntidad.Table.CurrentRecord.SetValue("celular", i.celular)
                    Me.dgvEntidad.Table.CurrentRecord.SetValue("email", i.email)
                    Me.dgvEntidad.Table.CurrentRecord.SetValue("moneda", i.moneda)
                    Me.dgvEntidad.Table.CurrentRecord.SetValue("tipoCambio", i.tipoCambio)
                    Me.dgvEntidad.Table.CurrentRecord.SetValue("importeMN", i.importeMN)
                    Me.dgvEntidad.Table.CurrentRecord.SetValue("importeME", i.importeME)
                    Me.dgvEntidad.Table.AddNewRecord.EndEdit()
                    icount += 1
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ' Dim fileName = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "names.xls")


    End Sub
#End Region

#Region "Manipulación Data"
    'Public Sub configuracionModulo(strIDEmpresa As String, strIdModulo As String, strNomModulo As String, intIdEstablecimiento As Integer)
    '    Dim moduloConfiguracionSA As New ModuloConfiguracionSA
    '    Dim moduloConfiguracion As New moduloConfiguracion
    '    Dim numeracionSA As New NumeracionBoletaSA
    '    Dim TablaSA As New tablaDetalleSA
    '    Dim almacenSA As New almacenSA
    '    Dim cajaSA As New EstadosFinancierosSA

    '    moduloConfiguracion = moduloConfiguracionSA.UbicarConfiguracionPorEmpresaModulo(strIdModulo, strIDEmpresa, intIdEstablecimiento)
    '    If Not IsNothing(moduloConfiguracion) Then
    '        With moduloConfiguracion
    '            GConfiguracion = New GConfiguracionModulo
    '            GConfiguracion.IdModulo = .idModulo
    '            GConfiguracion.NomModulo = strNomModulo
    '            GConfiguracion.TipoConfiguracion = .tipoConfiguracion
    '            Select Case .tipoConfiguracion
    '                Case "P"
    '                    With numeracionSA.GetUbicar_numeracionBoletasPorID(.configComprobante)
    '                        GConfiguracion.ConfigComprobante = .IdEnumeracion
    '                        GConfiguracion.TipoComprobante = .tipo
    '                        GConfiguracion.NombreComprobante = TablaSA.GetUbicarTablaID(10, .tipo).descripcion
    '                        GConfiguracion.Serie = .serie
    '                        GConfiguracion.ValorActual = .valorInicial
    '                        'txtSerieComp.Visible = True
    '                        'txtSerieComp.Text = .serie
    '                        'txtNumeroComp.Visible = False
    '                        'txtIdComprobante.Text = GConfiguracion.TipoComprobante
    '                        'txtComprobante.Text = GConfiguracion.NombreComprobante
    '                        'LinkTipoDoc.Enabled = False
    '                        'txtSerieComp.Enabled = False
    '                    End With
    '                Case "M"
    '                    'txtSerieComp.Visible = True
    '                    'txtNumeroComp.Visible = True
    '                    'LinkTipoDoc.Enabled = True
    '                    'txtSerieComp.Enabled = True
    '            End Select
    '            If Not IsNothing(.configAlmacen) Then
    '                Dim estableSA As New establecimientoSA
    '                With almacenSA.GetUbicar_almacenPorID(.configAlmacen)
    '                    GConfiguracion.IdAlmacen = .idAlmacen
    '                    GConfiguracion.NombreAlmacen = .descripcionAlmacen

    '                    'txtAlmacen.Text = GConfiguracion.NombreAlmacen
    '                    'txtIdAlmacen.Text = GConfiguracion.IdAlmacen
    '                    With estableSA.UbicaEstablecimientoPorID(.idEstablecimiento)
    '                        'txtIdEstableAlmacen.Text = .idCentroCosto
    '                        'txtEstableAlmacen.Text = .nombre
    '                    End With
    '                End With
    '            End If
    '            If Not IsNothing(.ConfigentidadFinanciera) Then
    '                With cajaSA.GetUbicar_estadosFinancierosPorID(.ConfigentidadFinanciera)
    '                    GConfiguracion.IDCaja = .idestado
    '                    GConfiguracion.NomCaja = .descripcion
    '                End With
    '            End If

    '        End With
    '    Else

    '    End If
    'End Sub

    Public Sub configuracionModuloV2(strIDEmpresa As String, strIdModulo As String, strNomModulo As String, intIdEstablecimiento As Integer)
        Try

            Dim moduloConfiguracionSA As New ModuloConfiguracionSA
            Dim moduloConfiguracion As New moduloConfiguracion
            Dim numeracionSA As New NumeracionBoletaSA
            Dim TablaSA As New tablaDetalleSA
            Dim almacenSA As New almacenSA
            Dim cajaSA As New EstadosFinancierosSA

            Dim RecuperacionNumeracion = numeracionSA.GetUbicar_numeracionBoletasXUnidadNegocio(New numeracionBoletas With {.empresa = strIDEmpresa, .establecimiento = intIdEstablecimiento, .codigoNumeracion = strIdModulo, .estado = "A"})

            If (Not IsNothing(RecuperacionNumeracion)) Then
                GConfiguracion = New GConfiguracionModulo
                GConfiguracion.ConfigComprobante = CInt(RecuperacionNumeracion.IdEnumeracion)
                GConfiguracion.TipoComprobante = RecuperacionNumeracion.tipo
                GConfiguracion.NombreComprobante = TablaSA.GetUbicarTablaID(10, RecuperacionNumeracion.tipo).descripcion
                GConfiguracion.Serie = RecuperacionNumeracion.serie
                GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial
            Else
                Throw New Exception("Verificar configuración")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub Grabar()
        Try
            Dim ListaEntidad As New List(Of entidad)
            Dim EntidadSA As New entidadSA
            Dim Entidad As New entidad

            ListaEntidad = New List(Of entidad)

            For Each r As Record In dgvEntidad.Table.Records
                Entidad = New entidad
                Entidad.idEmpresa = Gempresas.IdEmpresaRuc
                Select Case tipoentidad
                    Case TIPO_ENTIDAD.PROVEEDOR
                        Entidad.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
                    Case TIPO_ENTIDAD.CLIENTE
                        Entidad.tipoEntidad = TIPO_ENTIDAD.CLIENTE
                End Select
                Entidad.tipoPersona = r.GetValue("tipoPersona")
                Entidad.tipoDoc = r.GetValue("tipoDoc")
                Entidad.nrodoc = r.GetValue("nrodoc")
                Entidad.nombreCompleto = r.GetValue("nombreCompleto")
                Entidad.direccion = r.GetValue("direccion")
                Entidad.telefono = r.GetValue("telefono")
                Entidad.celular = r.GetValue("celular")
                Entidad.nextel = Nothing
                Entidad.email = r.GetValue("email")
                Entidad.estado = "A"
                Entidad.cuentaAsiento = "4212"
                Entidad.usuarioModificacion = usuario.IDUsuario
                Entidad.fechaModificacion = DateTime.Now
                Entidad.moneda = r.GetValue("moneda")
                Entidad.tipoCambio = CDec(r.GetValue("tipoCambio"))
                Entidad.ImporteMN = CDec(r.GetValue("importeMN"))
                Entidad.ImporteME = CDec(r.GetValue("importeME"))
                ListaEntidad.Add(Entidad)
            Next r
            EntidadSA.InsertGrupoEntidad(ListaEntidad)
        Catch ex As Exception
            MessageBoxAdv.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
        
        Dispose()
    End Sub
#End Region

    Private Sub frmImportEntidad_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmImportEntidad_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dispose()
    End Sub
    Dim hoveredIndex As Integer = 0
    Dim selectionColl As New Hashtable()
    Private Sub IsMouseHover(row As Integer, col As Integer, isHover As Boolean)
        Dim id As GridTableCellStyleInfoIdentity = Me.dgvEntidad.TableControl.GetTableViewStyleInfo(row, col).TableCellIdentity
        If id.DisplayElement.IsRecord() Then
            Dim key As Integer = id.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) Then
                selectionColl(key) = isHover
            Else
                selectionColl.Add(key, isHover)
            End If
            Me.dgvEntidad.TableControl.RefreshRange(GridRangeInfo.Row(row))
        End If

    End Sub

    Private Sub dgvEntidad_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvEntidad.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing AndAlso selectionColl.Count > 0 Then
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) Then
                e.Style.BackColor = Color.DeepSkyBlue
                e.Style.TextColor = Color.White
                e.Style.CurrencyEdit.PositiveColor = Color.White
            End If
        End If

        If Not IsNothing(e.TableCellIdentity.Column) Then
            'If e.TableCellIdentity.Column.Name = "tipoEx" Then
            '    If e.Style.CellValue.Equals("MR") Then
            'If e.TableCellIdentity.RowIndex = 3 Then
            '    e.Style.BackColor = Color.FromArgb(255, 192, 192)
            'End If

            'End If
            '    End If

        End If
    End Sub
    Private Sub dgvEntidad_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvEntidad.TableControlCellMouseHoverEnter
        Me.dgvEntidad.TableControl.Selections.Clear()
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True)
    End Sub

    Private Sub dgvEntidad_TableControlCellMouseHoverLeave(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvEntidad.TableControlCellMouseHoverLeave
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, False)
        Me.dgvEntidad.TableControl.Selections.Clear()
    End Sub

    Private Sub ButtonAdv15_Click(sender As Object, e As EventArgs) Handles ButtonAdv15.Click
        Me.Cursor = Cursors.WaitCursor
        Grabar()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvEntidad_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvEntidad.TableControlCellClick

    End Sub
End Class