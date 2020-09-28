Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Public Class frmInicioTrabajoEmpresa
    Inherits frmMaster

    Public Property strEmpresa As String
    Dim listaCentroCostos As New List(Of centrocosto)

    Public Sub New(idEmpresa As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridCFG(dgvEntidadFinanciera)
        ObtenerEF(idEmpresa)
        strEmpresa = idEmpresa
        UbicarEmpresa()
        ' TabControlAdv1.TabPages.RemoveAt(1)
        ' TabControlAdv1.TabPages.RemoveAt(2)
        '    TabControlAdv1.TabPages.RemoveAt(3)
    End Sub

    Dim colorx As New GridMetroColors()

#Region "Métodos"
    Sub UbicarEmpresa()
        Try


            Dim empresaSA As New empresaSA
            With empresaSA.UbicarEmpresaRuc(strEmpresa)
                Dim fechaPeriodo = "1" & "/" & .inicioOperacion
                Dim fechaPeriodo2 = "1" & "/" & .inicioOperacion
                fechaPeriodo = CDate(fechaPeriodo)
                txtRazon.Text = .razonSocial
                txtRazon.Tag = .estado
                txtSlogan.Text = .nombreCorto
                txtfono.Text = .telefono
                txtFax.Text = .fax
                txtDireccion.Text = .direccion
                txtemail.Text = .e_mail
                txtOperaciones.Text = CDate(fechaPeriodo2).AddMonths(1)
                txtPeriodo.Value = fechaPeriodo
                Select Case txtRazon.Tag
                    Case "1"
                        tabAsientos.Parent = Nothing
                        TabPageAdv3.Parent = Nothing
                        TabCuentasFinancieras.Parent = Nothing
                    Case "0"
                        tabAsientos.Parent = TabControlAdv1
                        TabPageAdv3.Parent = TabControlAdv1
                        TabCuentasFinancieras.Parent = TabControlAdv1
                End Select

            End With


            Dim estableSA As New establecimientoSA

            listaCentroCostos = estableSA.ObtenerListaEstablecimientos(strEmpresa).Where(Function(O) O.TipoEstab = "UN").ToList
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub ObtenerEF(idEmpresa As String)
        Dim estadosSA As New EstadosFinancierosSA
        Dim dt As New DataTable()

        dt.Columns.Add("entidad")
        dt.Columns.Add("tipo")
        dt.Columns.Add("numero")
        dt.Columns.Add("moneda")
        dt.Columns.Add("balance")

        For Each i In estadosSA.ObtenerEstadosFinancierosPorEstablecimiento(New estadosFinancieros With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = Nothing, .tipoConsulta = StatusTipoConsulta.XEmpresa})
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.descripcion
            dr(1) = IIf(i.tipo = "BC", "Banco", "Efectivo")
            dr(2) = i.nroCtaCorriente
            dr(3) = i.codigo
            dr(4) = i.importeBalanceMN
            dt.Rows.Add(dr)
        Next
        dgvEntidadFinanciera.DataSource = dt

    End Sub

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

    Public Sub EditarEmpresa()
        Dim libroSA As New documentoLibroDiarioSA
        Dim proveedorSA As New DocumentoCompraSA
        Dim clienteSA As New documentoVentaAbarrotesSA
        Dim empresa As New empresa
        Dim empresaSA As New empresaSA
        Dim cierremensual As New empresaCierreMensual
        Dim listaCierre As New List(Of empresaCierreMensual)

        If txtRazon.Tag = "0" Then

            'Dim TieneInventario = libroSA.TienenAperturaInventario(New documentoLibroDiario With {.tipoRegistro = "APT_EXT"})
            'If TieneInventario = False Then
            '    If MessageBoxAdv.Show("No ha registrado sus artículos de apertura, desea cancelar la operación ?", "Inventario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            '        Exit Sub
            '    End If
            'End If

            'Dim TieneCuentasXpagar = proveedorSA.TieneProveedoresApertura(New documentocompra With {.tipoCompra = "APT"})
            'If TieneCuentasXpagar = False Then
            '    If MessageBoxAdv.Show("No ha ingresado sus cuentas por pagar, desea cancelar operación ?", "Cuentas Por Pagar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            '        Exit Sub
            '    End If
            'End If

            'Dim TieneCuentasXcobrar = clienteSA.TieneClientesApertura(New documentoventaAbarrotes With {.tipoVenta = "APT"})
            'If TieneCuentasXcobrar = False Then
            '    If MessageBoxAdv.Show("No ha ingresado sus cuentas por cobrar, desea cancelar operación ?", "Cuentas Por Cobrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            '        Exit Sub
            '    End If
            'End If
        End If

        empresa = New empresa
        empresa.idEmpresa = strEmpresa
        empresa.razonSocial = txtRazon.Text
        empresa.nombreCorto = txtSlogan.Text
        empresa.direccion = txtDireccion.Text
        empresa.e_mail = txtemail.Text
        empresa.telefono = txtfono.Text
        empresa.fax = txtFax.Text
        empresa.estado = "1"

        If txtRazon.Tag = "0" Then

            For Each itemCentroCostos In listaCentroCostos

                cierremensual = New empresaCierreMensual
                cierremensual.idEmpresa = strEmpresa
                cierremensual.idCentroCosto = itemCentroCostos.idCentroCosto
                cierremensual.anio = txtPeriodo.Value.Year
                cierremensual.mes = txtPeriodo.Value.Month
                cierremensual.status = True
                cierremensual.idDocumento = 0
                cierremensual.tipoCierre = statusTipoCierre.AperturaEmpresa
                cierremensual.usuarioActualizacion = usuario.IDUsuario
                cierremensual.fechaActualizacion = Date.Now
                listaCierre.Add(cierremensual)
            Next


            'empresa.empresaCierreMensual = listaCierre
        End If

        empresaSA.EditarEmpresa(empresa, listaCierre)
        Cursor = Cursors.Default
        Close()
    End Sub
#End Region

    Public Property ControlBounds() As Rectangle
        Get
            Return m_ControlBounds
        End Get
        Set(ByVal value As Rectangle)
            m_ControlBounds = value
        End Set
    End Property
    Private m_ControlBounds As Rectangle


    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        Using brush As Brush = New SolidBrush(Color.FromArgb(45, Color.White))
            e.Graphics.FillRectangle(brush, e.ClipRectangle)
        End Using
        Me.Opacity = 68
    End Sub

    Private Sub frmInicioTrabajoEmpresa_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmInicioTrabajoEmpresa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TabPageAdv1.Parent = TabControlAdv1
        tabAsientos.Parent = Nothing
        'TabPageAdv3.Parent = TabControlAdv1
        'TabCuentasFinancieras.Parent = TabControlAdv1
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dim fechaNueva = txtPeriodo.Value.AddMonths(1)
        Dim fechaRegistro = New DateTime(fechaNueva.Year, fechaNueva.Month, 1)

        Dim f As New frmCuentasCobrarApertura
        f.txtPeriodo.Value = fechaRegistro ' txtPeriodo.Value
        f.txtPeriodo.Enabled = False
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        'Dim f As New frmImportEntidad(TIPO_ENTIDAD.CLIENTE)
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub PictureBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseClick
        TabPageAdv1.Parent = TabControlAdv1
        tabAsientos.Parent = Nothing
        TabPageAdv3.Parent = Nothing
        TabCuentasFinancieras.Parent = Nothing
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        TabPageAdv1.Parent = Nothing
        tabAsientos.Parent = TabControlAdv1
        TabPageAdv3.Parent = Nothing
        TabCuentasFinancieras.Parent = Nothing
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub PictureBox2_MouseClick(sender As Object, e As MouseEventArgs) Handles PictureBox2.MouseClick
        TabPageAdv1.Parent = Nothing
        tabAsientos.Parent = Nothing
        TabPageAdv3.Parent = TabControlAdv1
        TabCuentasFinancieras.Parent = Nothing
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click

    End Sub

    Private Sub PictureBox4_MouseClick(sender As Object, e As MouseEventArgs) Handles PictureBox4.MouseClick
        TabPageAdv1.Parent = Nothing
        tabAsientos.Parent = Nothing
        TabPageAdv3.Parent = Nothing
        TabCuentasFinancieras.Parent = TabControlAdv1
    End Sub

    Private Sub Label16_Click(sender As Object, e As EventArgs) Handles Label16.Click
        Dim oExcel As Object
        Dim oBook As Object
        Dim oSheet As Object

        'Start a new workbook in Excel- this isn't really what I need though, I need it to open a template and populate it.
        oExcel = CreateObject("Excel.Application")
        oBook = oExcel.Workbooks.Add


        'Add data to cells of the first worksheet in the new workbook
        oSheet = oBook.Worksheets(1)
        oSheet.Range("A1").Value = "idEntidad"
        oSheet.Range("B1").Value = "idEmpresa"
        oSheet.Range("B2").Value = Gempresas.IdEmpresaRuc
        oSheet.Range("B2").ColumnWidth = 20
        oSheet.Range("C1").Value = "tipoEntidad"
        oSheet.Range("C2").Value = "CL"
        oSheet.Range("D1").Value = "tipoPersona"
        oSheet.Range("E1").Value = "tipoDoc"
        oSheet.Range("F1").Value = "nrodoc"
        oSheet.Range("G1").Value = "nombreCompleto"
        oSheet.Range("G1").ColumnWidth = 40
        oSheet.Range("H1").Value = "direccion"
        oSheet.Range("H1").ColumnWidth = 30
        oSheet.Range("I1").Value = "telefono"
        oSheet.Range("J1").Value = "celular"
        oSheet.Range("K1").Value = "email"
        oSheet.Range("L1").Value = "moneda"
        oSheet.Range("M1").Value = "tipoCambio"
        oSheet.Range("N1").Value = "importeMN"
        oSheet.Range("O1").Value = "importeME"
        'etc....

        'Save the Workbook and Quit Excel
        oBook.SaveAs("D:\Clientes.xlsx")
        oExcel.Quit()
        System.Diagnostics.Process.Start("D:\Clientes.xlsx")
    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click

    End Sub

    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click
        Dim oExcel As Object
        Dim oBook As Object
        Dim oSheet As Object

        'Start a new workbook in Excel- this isn't really what I need though, I need it to open a template and populate it.
        oExcel = CreateObject("Excel.Application")
        oBook = oExcel.Workbooks.Add


        'Add data to cells of the first worksheet in the new workbook
        oSheet = oBook.Worksheets(1)
        oSheet.Range("A1").Value = "idEntidad"
        oSheet.Range("B1").Value = "idEmpresa"
        oSheet.Range("B2").Value = Gempresas.IdEmpresaRuc
        oSheet.Range("B1").ColumnWidth = 20
        oSheet.Range("C1").Value = "tipoEntidad"
        oSheet.Range("C2").Value = "PR"
        oSheet.Range("D1").Value = "tipoPersona"
        oSheet.Range("E1").Value = "tipoDoc"
        oSheet.Range("F1").Value = "nrodoc"
        oSheet.Range("G1").Value = "nombreCompleto"
        oSheet.Range("G1").ColumnWidth = 40
        oSheet.Range("H1").Value = "direccion"
        oSheet.Range("H1").ColumnWidth = 30
        oSheet.Range("I1").Value = "telefono"
        oSheet.Range("J1").Value = "celular"
        oSheet.Range("K1").Value = "email"
        oSheet.Range("L1").Value = "moneda"
        oSheet.Range("M1").Value = "tipoCambio"
        oSheet.Range("N1").Value = "importeMN"
        oSheet.Range("O1").Value = "importeME"
        'etc....


        'Save the Workbook and Quit Excel
        oBook.SaveAs("D:\Proveedores.xlsx")
        oExcel.Quit()
        System.Diagnostics.Process.Start("D:\Proveedores.xlsx")
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Dim fechaNueva = txtPeriodo.Value.AddMonths(1)
        Dim fechaRegistro = New DateTime(fechaNueva.Year, fechaNueva.Month, 1)

        Dim f As New frmCuentasPagarApertura
        f.txtPeriodo.Value = fechaRegistro
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()

        'Dim f As New frmImportEntidad(TIPO_ENTIDAD.PROVEEDOR)
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog()
    End Sub

    Private Sub Label19_Click(sender As Object, e As EventArgs) Handles Label19.Click
        Dim oExcel As Object
        Dim oBook As Object
        Dim oSheet As Object

        'Start a new workbook in Excel- this isn't really what I need though, I need it to open a template and populate it.
        oExcel = CreateObject("Excel.Application")
        oBook = oExcel.Workbooks.Add

        'Add data to cells of the first worksheet in the new workbook
        oSheet = oBook.Worksheets(1)
        oSheet.Range("A1").Value = "codigodetalle"
        oSheet.Range("A2").Value = 1
        oSheet.Range("B1").Value = "idEmpresa"
        oSheet.Range("B1").ColumnWidth = 20
        oSheet.Range("B2").Value = Gempresas.IdEmpresaRuc
        oSheet.Range("C1").Value = "descripcionItem"
        oSheet.Range("C1").ColumnWidth = 40
        oSheet.Range("C2").Value = "Producto/item x..."
        oSheet.Range("D1").Value = "presentacion"
        oSheet.Range("E1").Value = "unidad1"
        oSheet.Range("F1").Value = "tipoExistencia"
        oSheet.Range("G1").Value = "origenProducto"
        oSheet.Range("G2").Value = "2"
        oSheet.Range("H1").Value = "tipoProducto"
        oSheet.Range("H2").Value = "I"
        oSheet.Range("I1").Value = "stock"
        oSheet.Range("I2").Value = 0.0
        oSheet.Range("J1").Value = "cantMinima"
        oSheet.Range("J2").Value = 0.0
        oSheet.Range("K1").Value = "cantMaxima"
        oSheet.Range("K2").Value = 0.0
        oSheet.Range("L1").Value = "costoMN"
        oSheet.Range("L2").Value = 0.0
        oSheet.Range("M1").Value = "costoME"
        oSheet.Range("M2").Value = 0.0
        oSheet.Range("N1").Value = "precio_menor"
        oSheet.Range("N2").Value = 0.0
        oSheet.Range("O1").Value = "precio_mayor"
        oSheet.Range("O2").Value = 0.0
        oSheet.Range("P1").Value = "precio_granmayor"
        oSheet.Range("P2").Value = 0.0

        'Save the Workbook and Quit Excel
        oBook.SaveAs("D:\Items.xlsx")
        oExcel.Quit()
        System.Diagnostics.Process.Start("D:\Items.xlsx")
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        'Dim fechaNueva = txtPeriodo.Value.AddMonths(1)
        'Dim fechaRegistro = New DateTime(fechaNueva.Year, fechaNueva.Month, 1)
        'Dim f As New frmImportarExistencia(strEmpresa)
        'f.txtAnio.Value = New Date(fechaRegistro.Year, fechaRegistro.Month, 1)
        'f.txtMes.Value = New Date(fechaRegistro.Year, fechaRegistro.Month, 1)
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog()
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        Me.Cursor = Cursors.WaitCursor
        Dim fechaNueva = txtPeriodo.Value.AddMonths(1)
        Dim fechaRegistro = New DateTime(fechaNueva.Year, fechaNueva.Month, 1)

        With frmModalCajaApertura
            .txtFecha.Value = fechaRegistro
            .txtFecha.Enabled = False
            .strEstadoManipulacion = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            ObtenerEF(strEmpresa)
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click
        Me.Cursor = Cursors.WaitCursor
        Dim oExcel As Object
        Dim oBook As Object
        Dim oSheet As Object

        'Start a new workbook in Excel- this isn't really what I need though, I need it to open a template and populate it.
        oExcel = CreateObject("Excel.Application")
        oBook = oExcel.Workbooks.Add

        'Add data to cells of the first worksheet in the new workbook
        oSheet = oBook.Worksheets(1)
        oSheet.Range("A1").Value = "cuenta"
        oSheet.Range("B1").Value = "descripcion"
        oSheet.Range("B1").ColumnWidth = 40
        oSheet.Range("C1").Value = "tipoAsiento"
        oSheet.Range("D1").Value = "debe"
        oSheet.Range("E1").Value = "haber"

        'Save the Workbook and Quit Excel
        oBook.SaveAs("D:\cuentas.xlsx")
        oExcel.Quit()
        System.Diagnostics.Process.Start("D:\cuentas.xlsx")
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        Dim fechaNueva = txtPeriodo.Value.AddMonths(1)
        Dim fechaRegistro = New DateTime(fechaNueva.Year, fechaNueva.Month, 1)
        Dim f As New frmImportarCuentasContables
        f.txtfecha.Value = fechaRegistro
        f.txtfecha.Enabled = False
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub Label25_Click(sender As Object, e As EventArgs) Handles Label25.Click
        Dim oExcel As Object
        Dim oBook As Object
        Dim oSheet As Object

        'Start a new workbook in Excel- this isn't really what I need though, I need it to open a template and populate it.
        oExcel = CreateObject("Excel.Application")
        oBook = oExcel.Workbooks.Add


        'Add data to cells of the first worksheet in the new workbook
        oSheet = oBook.Worksheets(1)


        oSheet.Range("A1").Value = "tipoEx"
        oSheet.Range("B1").Value = "Modulo"
        oSheet.Range("C1").Value = "unidad"
        oSheet.Range("D1").Value = "cantidad"
        oSheet.Range("E1").Value = "cuenta"
        oSheet.Range("F1").Value = "nomCuenta"
        oSheet.Range("G1").Value = "importeMN"
        oSheet.Range("H1").Value = "HaberMN"
        oSheet.Range("I1").Value = "importeME"
        oSheet.Range("J1").Value = "HaberME"
        oSheet.Range("K1").Value = "idAlmacen"
        oSheet.Range("L1").Value = "colModVenta"
        oSheet.Range("M1").Value = "moneda"


        'etc....

        'Save the Workbook and Quit Excel
        oBook.SaveAs("D:\Aportes.xlsx")
        oExcel.Quit()
        System.Diagnostics.Process.Start("D:\Aportes.xlsx")
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        'Dim f As New frmCuentasPagarApertura
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog()

        'Dim f As New frmImportAporte("APORTE")
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog()
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        EditarEmpresa()

    End Sub

    Private Sub ButtonAdv7_Click(sender As Object, e As EventArgs) Handles ButtonAdv7.Click
        Close()
    End Sub
End Class