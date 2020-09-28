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
Public Class frmImportarCuentasContables
    Inherits frmMaster

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        configuracionModuloV2(Gempresas.IdEmpresaRuc, "AST", Me.Text, GEstableciento.IdEstablecimiento)
        ' Add any initialization after the InitializeComponent() call.
        GridCFG(dgvCuentas)
        GridCFG(dgvAddcuentas)
        GetGridColumn()
        ImportarExcel()
        Me.WindowState = FormWindowState.Maximized
    End Sub

#Region "Métodos"
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
    '                        '  txtSerie.Text = .serie
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
    '        '    lblEstado.Text = "Este módulo no contiene una configuración disponible, intentelo más tarde.!"
    '        'Timer1.Enabled = True
    '        'TabCompra.Enabled = False
    '        'TiempoEjecutar(5)
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

    Sub GetGridColumn()
        Dim dt As New DataTable()
        dt.Columns.Add("cuenta")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("tipoAsiento")
        dt.Columns.Add("debe")
        dt.Columns.Add("haber")

        dgvCuentas.DataSource = dt

        Dim dt2 As New DataTable()
        dt2.Columns.Add("cuenta")
        dt2.Columns.Add("nomCuenta")

        dgvAddcuentas.DataSource = dt2

    End Sub

    Public Sub ImportarExcel()
        Dim strDestination As String = Nothing
        Dim cuentaSA As New cuentaplanContableEmpresaSA
        Dim cuenta As New cuentaplanContableEmpresa
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
                Dim users = (From x In book.Worksheet(Of cuentaImport)("Hoja1") _
                            Select x).ToList

                For Each i In users
                    If Not IsNothing(i.cuenta) Then

                        If cuentaSA.CuentaExistenteEnBD(New cuentaplanContableEmpresa With {.idEmpresa = Gempresas.IdEmpresaRuc, .cuenta = i.cuenta}) = False Then
                            Me.dgvAddcuentas.Table.AddNewRecord.SetCurrent()
                            Me.dgvAddcuentas.Table.AddNewRecord.BeginEdit()
                            Me.dgvAddcuentas.Table.CurrentRecord.SetValue("cuenta", i.cuenta)
                            Me.dgvAddcuentas.Table.CurrentRecord.SetValue("nomCuenta", i.descripcion)
                            Me.dgvAddcuentas.Table.AddNewRecord.EndEdit()
                        End If

                        Me.dgvCuentas.Table.AddNewRecord.SetCurrent()
                        Me.dgvCuentas.Table.AddNewRecord.BeginEdit()
                        Me.dgvCuentas.Table.CurrentRecord.SetValue("cuenta", i.cuenta)
                        Me.dgvCuentas.Table.CurrentRecord.SetValue("descripcion", i.descripcion)
                        Me.dgvCuentas.Table.CurrentRecord.SetValue("tipoAsiento", i.tipoAsiento)
                        Me.dgvCuentas.Table.CurrentRecord.SetValue("debe", i.debe)
                        Me.dgvCuentas.Table.CurrentRecord.SetValue("haber", i.haber)
                        Me.dgvCuentas.Table.AddNewRecord.EndEdit()
                        icount += 1
                    End If
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ' Dim fileName = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "names.xls")


    End Sub
#End Region

#Region "Manipulacion Data"
    Public Sub GrabarCuentasNuevos()
        Dim cuentaSA As New cuentaplanContableEmpresaSA
        Dim cuenta As New cuentaplanContableEmpresa
        Dim Lista As New List(Of cuentaplanContableEmpresa)

        For Each i In dgvAddcuentas.Table.Records
            cuenta = New cuentaplanContableEmpresa With
                     {
                         .idEmpresa = Gempresas.IdEmpresaRuc,
                         .cuenta = i.GetValue("cuenta"),
                         .cuentaPadre = Mid(i.GetValue("cuenta"), 1, 2),
                         .descripcion = i.GetValue("nomCuenta"),
                         .Observaciones = String.Empty,
                         .usuarioModificacion = usuario.IDUsuario,
                         .fechaModificacion = DateTime.Now
                         }
            Lista.Add(cuenta)
        Next
        cuentaSA.InsertarListaDeCuentas(Lista)
        dgvCuentas.Table.Records.DeleteAll()
        dgvCuentas.Refresh()
    End Sub

    Public Sub GrabarCierre()
        Dim cierre As New cierrecontable
        Dim listaCierre As New List(Of cierrecontable)
        Dim cierreSA As New CierreContableSA

        Dim asiento As New asiento
        Dim nMovimiento As New movimiento
        Try
            Dim strperiodo As String = String.Format("{0:00}", CInt(txtfecha.Value.Month)) & txtfecha.Value.Year
            Dim documento As New documento
            Dim documentoLibroDiario As New documentoLibroDiario
            Dim documentoLibroDiarioDet As New documentoLibroDiarioDetalle
            Dim ListaDetalle As New List(Of documentoLibroDiarioDetalle)
            Dim documentoLibroDiarioSA As New documentoLibroDiarioSA

            documento = New documento
            documento.Action = Business.Entity.BaseBE.EntityAction.INSERT
            documento.idEmpresa = Gempresas.IdEmpresaRuc
            documento.idCentroCosto = GEstableciento.IdEstablecimiento
            documento.tipoDoc = "9901" 'VOUCHER CONTABLE
            documento.fechaProceso = txtfecha.Value
            documento.nroDoc = "1"
            documento.tipoOperacion = "I"  'INGRESO CUENTAS MANUALES
            documento.idEntidad = usuario.IDUsuario
            documento.entidad = usuario.CustomUsuario.Full_Name
            documento.nrodocEntidad = usuario.CustomUsuario.NroDocumento
            documento.tipoEntidad = "US"
            documento.idOrden = Nothing
            documento.usuarioActualizacion = usuario.IDUsuario
            documento.fechaActualizacion = DateTime.Now

            documentoLibroDiario = New documentoLibroDiario
            documentoLibroDiario.TipoConfiguracion = GConfiguracion.TipoConfiguracion
            documentoLibroDiario.IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
            documentoLibroDiario.idEmpresa = Gempresas.IdEmpresaRuc
            documentoLibroDiario.idEstablecimiento = GEstableciento.IdEstablecimiento
            documentoLibroDiario.tipoRegistro = "APT"
            documentoLibroDiario.fecha = txtfecha.Value
            documentoLibroDiario.fechaPeriodo = strperiodo
            documentoLibroDiario.infoReferencial = "Asiento de apertura por inicio de labores"
            documentoLibroDiario.tipoDoc = "9901"
            documentoLibroDiario.nroDoc = "1"
            documentoLibroDiario.tipoOperacion = "105"
            documentoLibroDiario.moneda = "1"
            documentoLibroDiario.tipoCambio = 3.0
            documentoLibroDiario.usuarioActualizacion = usuario.IDUsuario
            documentoLibroDiario.fechaActualizacion = DateTime.Now

            documento.documentoLibroDiario = documentoLibroDiario

            For Each obj In dgvCuentas.Table.Records
                documentoLibroDiarioDet = New documentoLibroDiarioDetalle
                documentoLibroDiarioDet.cuenta = obj.GetValue("cuenta")
                documentoLibroDiarioDet.descripcion = obj.GetValue("descripcion")

                Select Case obj.GetValue("tipoAsiento")
                    Case "D", "DEBE"
                        documentoLibroDiarioDet.tipoAsiento = "D"
                        documentoLibroDiarioDet.importeMN = CDec(obj.GetValue("debe"))
                        documentoLibroDiarioDet.importeME = Math.Round(CDec(obj.GetValue("debe")) / TmpTipoCambio, 2)

                    Case "H", "HABER"
                        documentoLibroDiarioDet.tipoAsiento = "H"
                        documentoLibroDiarioDet.importeMN = CDec(obj.GetValue("haber"))
                        documentoLibroDiarioDet.importeME = Math.Round(CDec(obj.GetValue("haber")) / TmpTipoCambio, 2)
                End Select
                documentoLibroDiarioDet.usuarioActualizacion = usuario.IDUsuario
                documentoLibroDiarioDet.fechaActualizacion = DateTime.Now
                ListaDetalle.Add(documentoLibroDiarioDet)
            Next
            documento.documentoLibroDiario.importeMN = ListaDetalle.Where(Function(o) o.tipoAsiento = "D").Sum(Function(o) o.importeMN)
            documento.documentoLibroDiario.importeME = ListaDetalle.Where(Function(o) o.tipoAsiento = "D").Sum(Function(o) o.importeME)

            documento.documentoLibroDiario.documentoLibroDiarioDetalle = ListaDetalle



            'ASIENTOS CONTABLES

            asiento = New asiento
            asiento.idAsiento = 0
            asiento.periodo = String.Format("{0:00}", txtfecha.Value.Month) & "/" & txtfecha.Value.Year
            asiento.idEmpresa = Gempresas.IdEmpresaRuc
            asiento.idCentroCostos = GEstableciento.IdEstablecimiento
            asiento.codigoLibro = StatusCodigoLibroContable.LIBRO_DIARIO
            asiento.idDocumentoRef = Nothing
            asiento.idAlmacen = Nothing
            asiento.nombreAlmacen = Nothing
            asiento.idEntidad = Nothing
            asiento.nombreEntidad = Nothing
            asiento.tipoEntidad = Nothing
            asiento.fechaProceso = txtfecha.Value
            asiento.tipo = "I"
            asiento.tipoAsiento = ASIENTO_CONTABLE.InicioDeOperaciones
            asiento.importeMN = 0
            asiento.importeME = 0
            asiento.glosa = "Asiento de inicio de empresa"
            asiento.usuarioActualizacion = usuario.IDUsuario
            asiento.fechaActualizacion = DateTime.Now

            For Each r As Record In dgvCuentas.Table.Records
                nMovimiento = New movimiento
                nMovimiento.cuenta = r.GetValue("cuenta")
                nMovimiento.descripcion = r.GetValue("descripcion")


                cierre = New cierrecontable
                cierre.idEmpresa = Gempresas.IdEmpresaRuc
                cierre.idCentroCosto = GEstableciento.IdEstablecimiento

                cierre.periodo = strperiodo
                cierre.cuenta = r.GetValue("cuenta")
                cierre.anio = CInt(txtfecha.Value.Year)
                cierre.mes = CInt(txtfecha.Value.Month)
                cierre.dia = CInt(txtfecha.Value.Day)

                Select Case r.GetValue("tipoAsiento")
                    Case "D", "DEBE"
                        cierre.tipoasiento = "D"
                        cierre.monto = CDec(r.GetValue("debe"))
                        cierre.montoUSD = Math.Round(CDec(r.GetValue("debe")) / TmpTipoCambio, 2)


                        nMovimiento.tipo = "D"
                        nMovimiento.monto = CDec(r.GetValue("debe"))
                        nMovimiento.montoUSD = Math.Round(CDec(r.GetValue("debe")) / TmpTipoCambio, 2)
                    Case "H", "HABER"
                        cierre.tipoasiento = "H"
                        cierre.monto = CDec(r.GetValue("haber"))
                        cierre.montoUSD = Math.Round(CDec(r.GetValue("haber")) / TmpTipoCambio, 2)

                        nMovimiento.tipo = "H"
                        nMovimiento.monto = CDec(r.GetValue("haber"))
                        nMovimiento.montoUSD = Math.Round(CDec(r.GetValue("haber")) / TmpTipoCambio, 2)
                End Select

                cierre.usuarioActualizacion = usuario.IDUsuario
                cierre.fechaActualizacion = DateTime.Now

                nMovimiento.usuarioActualizacion = usuario.IDUsuario
                nMovimiento.fechaActualizacion = DateTime.Now
                asiento.movimiento.Add(nMovimiento)
                listaCierre.Add(cierre)
            Next r
            cierreSA.GrabarListaAsientos(listaCierre, asiento, documento)
            Dispose()
        Catch ex As Exception
            '  lblEstado.Text = ex.Message
        End Try
    End Sub
#End Region

    Private Sub frmImportarCuentasContables_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmImportarCuentasContables_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dispose()
    End Sub

    Private Sub ButtonAdv15_Click(sender As Object, e As EventArgs) Handles ButtonAdv15.Click
        GrabarCierre()
    End Sub

    Private Sub btnAdCuenta_Click(sender As Object, e As EventArgs) Handles btnAdCuenta.Click
        Me.Cursor = Cursors.WaitCursor
        If dgvAddcuentas.Table.Records.Count > 0 Then
            GrabarCuentasNuevos()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub
End Class