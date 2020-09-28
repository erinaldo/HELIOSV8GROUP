Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid

Public Class FrmPagosConAnticipo

    Public Property manipulacionEstado As String
    Public Property lblIdProveedor() As String
    Public Property lblCuentaProveedor() As String
    Public Property lblNomProveedor() As String
    Public Property lblTipoCambioOriginal() As Decimal


    Public Sub New()
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        QGlobalColorSchemeManager1.Global.CurrentTheme = Qios.DevSuite.Components.QColorScheme.LunaBlueThemeName
        SetRenderer()
        ' ObtenerTablaGenerales()
        configuracionModuloV2(Gempresas.IdEmpresaRuc, "ANT", "ANTICIPOS", GEstableciento.IdEstablecimiento)
        GridCFG(dgvDetalleItems)
        GetTableGrid()
        GridCFG(dgvAnticipos)


        GridCFG(GridGroupingControl1)
        GetTableGridPago()
       

        txtFechaTrans.Value = Date.Now
    End Sub

#Region "metodos"

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
    '                    End With
    '                Case "M"

    '            End Select
    '            If Not IsNothing(.configAlmacen) Then
    '                Dim estableSA As New establecimientoSA
    '                With almacenSA.GetUbicar_almacenPorID(.configAlmacen)
    '                    GConfiguracion.IdAlmacen = .idAlmacen
    '                    GConfiguracion.NombreAlmacen = .descripcionAlmacen

    '                    'With estableSA.UbicaEstablecimientoPorID(.idEstablecimiento)
    '                    '    'txtIdEstableAlmacen.Text = .idCentroCosto
    '                    '    'txtEstableAlmacen.Text = .nombre
    '                    'End With
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
    '        lblEstado.Text = "Este módulo no contiene una configuración disponible, intentelo más tarde.!"
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

    Public Sub Grabar()
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim documentoSA As New DocumentoSA
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim ndocumento As New documento
        Dim ndocumentoAnticipo As New documentoAnticipo
        Dim ndocumentoCajaDetalle As New documentoAnticipoDetalle
        Dim ListadocumentoCajaDetalle As New List(Of documentoAnticipoDetalle)
        Dim asiento As New asiento
        Dim ListaAsiento As New List(Of asiento)
        Dim cajaUsarioBE As New cajaUsuario
        Dim cajaUsariodetalleBE As New cajaUsuariodetalle
        Dim cajaUsariodetalleListaBE As New List(Of cajaUsuariodetalle)
        Dim SaldoMonedaExt As Decimal = 0
        Dim MontoMonedaExt As Decimal = 0
        Dim MontoSoles As Decimal = 0
        Dim entidadSA As New entidadSA
        Dim n As New RecolectarDatos()
        Dim datos As List(Of RecolectarDatos) = RecolectarDatos.Instance()
        datos.Clear()
        Try
            Dim documentoOrigen = documentoCompraSA.UbicarDocumentoCompra(lblIdDocumento.Text)
            With ndocumento
                .idDocumento = lblIdDocumento.Text
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                If Not IsNothing(GProyectos) Then
                    .idProyecto = GProyectos.IdProyectoActividad
                End If
                .tipoDoc = "9903"
                .fechaProceso = txtFechaTrans.Value
                 .nroDoc = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
                .idOrden = Nothing
                If Not IsNothing(documentoOrigen) Then
                    .idEntidad = documentoOrigen.idProveedor

                    Dim ent = entidadSA.UbicarEntidadPorID(.idEntidad).FirstOrDefault
                    If Not IsNothing(ent) Then
                        .entidad = ent.nombreCompleto
                        .tipoEntidad = "PR"
                        .nrodocEntidad = ent.nrodoc
                    End If
                End If
                .tipoOperacion = "104"
                .usuarioActualizacion = usuario.IDUsuario
                .fechaActualizacion = DateTime.Now
            End With

            With ndocumentoAnticipo
                .codigoLibro = "1"
                .fechaPeriodo = PeriodoGeneral
                .idDocumento = lblIdDocumento.Text
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .tipoMovimiento = TIPO_COMPRA.PAGO.PAGADO
                .movimiento = "DC"
                .tipoDocumento = txtComprobante.Tag
                .fechaDoc = DateTime.Now
                .tipoOperacion = "104"
                .IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
                .numeroDoc = .IdNumeracion
                .Moneda = "1"
                .tipocambio = txtTipoCambio.Value
                .importeMN = txttotalpagomn.Value
                .importeME = txttotalpagome.Value
                '.glosa = Glosa()
                .usuarioModificacion = usuario.IDUsuario
                .fechaActualizacion = DateTime.Now
                .codigoProveedor = CInt(txtProveedor.Tag)
            End With

            ndocumento.documentoAnticipo = ndocumentoAnticipo

            For Each i As Record In GridGroupingControl1.Table.Records

                ndocumentoCajaDetalle = New documentoAnticipoDetalle
                ndocumentoCajaDetalle.fecha = txtFechaTrans.Value
                ndocumentoCajaDetalle.idAnticipo = i.GetValue("idanticipo")
                ndocumentoCajaDetalle.DetalleItem = i.GetValue("descripcion")
                ndocumentoCajaDetalle.importeMN = CDec(i.GetValue("montopago"))
                ndocumentoCajaDetalle.montoSolesRef = CDec(i.GetValue("montopago"))
                ndocumentoCajaDetalle.importeME = CDec(i.GetValue("montopagome"))
                ndocumentoCajaDetalle.montoUsdRef = CDec(i.GetValue("montopagome"))
                ndocumentoCajaDetalle.entregado = "SI"
                ndocumentoCajaDetalle.diferTipoCambio = txtTipoCambio.Value
                ndocumentoCajaDetalle.estadoAnticipo = "0"
                ndocumentoCajaDetalle.documentoAfectado = lblIdDocumento.Text
                ndocumentoCajaDetalle.usuarioModificacion = usuario.IDUsuario
                ndocumentoCajaDetalle.fechaActualizacion = Date.Now
                ndocumentoCajaDetalle.documentoAfectadodetalle = CDec(i.GetValue("iddocumentodet"))
                ListadocumentoCajaDetalle.Add(ndocumentoCajaDetalle)

            Next

            ndocumento.documentoAnticipo.documentoAnticipoDetalle = ListadocumentoCajaDetalle
            'Select Case cboTipoDoc.SelectedValue
            '    Case "109", "003", "001"
            '        asiento = asientoCaja(SaldoMonedaExt, MontoMonedaExt, MontoSoles)
            '        ListaAsiento.Add(asiento)
            '        ndocumento.asiento = ListaAsiento
            '    Case "007", "111"
            '        cajaUsarioBE = Nothing
            'End Select
            n.IdAlmacen = documentoCajaSA.SaveGroupAnticipo(ndocumento)
            datos.Add(n)
            lblEstado.Text = "Transacción realizada con éxito!"
            lblEstado.Image = My.Resources.ok4
            Dispose()
        Catch ex As Exception
            lblEstado.Text = ex.Message
            lblEstado.Image = My.Resources.warning2
        End Try
    End Sub






    Public Sub getTableAnticiposPorTipoProveedor(idprov As Integer)
        Dim DocumentoAnticipoSL As New documentoAnticipo
        Dim dt As New DataTable("Aportes de Proveedor - período " & PeriodoGeneral & " ")
        Dim documentoAnticipoSA As New documentoAnticipoSA
        ' Dim str As String
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoAnticipo", GetType(String)))
        dt.Columns.Add(New DataColumn("razonSocial", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("Monto", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("MontoPago", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ImporteNacional", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ImporteExtranjero", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("pago", GetType(Decimal)))

        For Each i As documentoAnticipo In documentoAnticipoSA.getTableAnticiposMontoActual(idprov, "AO")
            Dim dr As DataRow = dt.NewRow()
            'str = Nothing
            'str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")

            Dim deuda As Decimal
            deuda = CDec(0)
            deuda = i.MontoDeudaSoles - i.MontoPagadoSoles

            If deuda > 0 Then

                dr(0) = i.idDocumento
                dr(1) = i.numeroDoc
                dr(2) = i.tipoAnticipo
                dr(3) = i.razonSocial
                dr(4) = i.TipoCambio
                dr(5) = i.MontoDeudaSoles
                dr(6) = i.MontoPagadoSoles
                dr(7) = i.MontoDeudaSoles - i.MontoPagadoSoles
                dr(8) = i.MontoDeudaUSD - i.MontoPagadoUSD
                dr(9) = CDec(0.0)
                dt.Rows.Add(dr)
            End If


        Next
        dgvAnticipos.DataSource = dt

    End Sub



    Private Sub SetRenderer()
        Dim styleRenderer1 As New StyledRenderer()
    End Sub

    Sub GetTableGrid()
        Dim dt As New DataTable()
        dt.Columns.Add("id", GetType(String))
        dt.Columns.Add("descripcion", GetType(String))
        dt.Columns.Add("unidad", GetType(String))
        dt.Columns.Add("precUnit", GetType(Decimal))
        dt.Columns.Add("importeMN", GetType(Decimal))
        dt.Columns.Add("importeME", GetType(Decimal))
        dt.Columns.Add("PagoMN", GetType(Decimal))
        dt.Columns.Add("PagoME", GetType(Decimal))
        dt.Columns.Add("SaldoMN", GetType(Decimal))
        dt.Columns.Add("SaldoME", GetType(Decimal))
        dt.Columns.Add("estado", GetType(String))
        dt.Columns.Add("secuencia", GetType(Integer))

        dgvDetalleItems.DataSource = dt
    End Sub


    Sub GetTableGridPago()
        Dim dt As New DataTable()
        dt.Columns.Add("idanticipo", GetType(Integer))
        dt.Columns.Add("montopago", GetType(Decimal))
        dt.Columns.Add("iddocumento", GetType(String))
        dt.Columns.Add("iddocumentodet", GetType(String))
        dt.Columns.Add("descripcion", GetType(String))
        dt.Columns.Add("montopagome", GetType(Decimal))

        GridGroupingControl1.DataSource = dt
    End Sub



    Sub GridCFG(grid As GridGroupingControl)
        grid.TableOptions.ShowRowHeader = False
        grid.TopLevelGroupOptions.ShowCaption = False

        Dim colorx As New GridMetroColors()
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
#End Region
    Private Sub FrmPagosConAnticipo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub dgvAnticipos_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvAnticipos.KeyDown

    End Sub

    Private Sub dgvAnticipos_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvAnticipos.TableControlCellClick

    End Sub

    Private Sub dgvAnticipos_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvAnticipos.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        If Not IsNothing(Me.dgvAnticipos.Table.CurrentRecord) Then
            Select Case ColIndex
                Case 10 ' capital
                    Dim total As Decimal = CDec(0.0)
                    Dim totalme As Decimal = CDec(0.0)
                    'Dim totalme As Decimal = CDec(0.0)




                    GridGroupingControl1.Table.Records.DeleteAll()
                    For Each i As Record In dgvDetalleItems.Table.Records
                        i.SetValue("PagoMN", CDec(0.0))
                        i.SetValue("PagoME", CDec(0.0))
                        i.SetValue("SaldoMN", i.GetValue("importeMN"))
                        i.SetValue("SaldoME", CDec(0.0))
                    Next


                    For Each i As Record In dgvAnticipos.Table.Records
                        If (i.GetValue("ImporteNacional")) >= (i.GetValue("pago")) Then

                            Dim nudSaldo As Decimal = Math.Round((i.GetValue("pago")), 2)
                            Dim cSaldo As Decimal = 0
                            Dim cSaldoex As Decimal = 0
                            Dim cSaldoME As Decimal = 0
                            Dim cSaldoexME As Decimal = 0

                            '/MONTO COMPRA
                            For Each g As Record In dgvDetalleItems.Table.Records


                                If nudSaldo > 0 Then

                                    cSaldo = Math.Round((CDec(g.GetValue("SaldoMN"))), 2) - nudSaldo
                                    If cSaldo >= 0 Then
                                        g.SetValue("PagoMN", (nudSaldo + CDec(g.GetValue("PagoMN"))))
                                        g.SetValue("SaldoMN", cSaldo)

                                        Me.GridGroupingControl1.Table.AddNewRecord.SetCurrent()
                                        Me.GridGroupingControl1.Table.AddNewRecord.BeginEdit()
                                        Me.GridGroupingControl1.Table.CurrentRecord.SetValue("idanticipo", CInt(i.GetValue("idDocumento")))
                                        Me.GridGroupingControl1.Table.CurrentRecord.SetValue("montopago", nudSaldo)
                                        Me.GridGroupingControl1.Table.CurrentRecord.SetValue("iddocumento", lblIdDocumento.Text)
                                        Me.GridGroupingControl1.Table.CurrentRecord.SetValue("iddocumentodet", g.GetValue("secuencia"))
                                        Me.GridGroupingControl1.Table.CurrentRecord.SetValue("descripcion", g.GetValue("descripcion"))
                                        Me.GridGroupingControl1.Table.CurrentRecord.SetValue("montopagome", (nudSaldo / i.GetValue("tipoCambio")))
                                        Me.GridGroupingControl1.Table.AddNewRecord.EndEdit()


                                        nudSaldo = 0
                                    Else
                                        g.SetValue("PagoMN", CDec(g.GetValue("SaldoMN")) + g.GetValue("PagoMN"))
                                        g.SetValue("SaldoMN", CDec(0.0))
                                        Dim rest As Decimal = nudSaldo + cSaldo
                                        nudSaldo = cSaldo * -1



                                        Me.GridGroupingControl1.Table.AddNewRecord.SetCurrent()
                                        Me.GridGroupingControl1.Table.AddNewRecord.BeginEdit()
                                        Me.GridGroupingControl1.Table.CurrentRecord.SetValue("idanticipo", CInt(i.GetValue("idDocumento")))
                                        Me.GridGroupingControl1.Table.CurrentRecord.SetValue("montopago", rest)
                                        Me.GridGroupingControl1.Table.CurrentRecord.SetValue("iddocumento", lblIdDocumento.Text)
                                        Me.GridGroupingControl1.Table.CurrentRecord.SetValue("iddocumentodet", g.GetValue("secuencia"))
                                        Me.GridGroupingControl1.Table.CurrentRecord.SetValue("descripcion", g.GetValue("descripcion"))
                                        Me.GridGroupingControl1.Table.CurrentRecord.SetValue("montopagome", (nudSaldo / i.GetValue("tipoCambio")))
                                        Me.GridGroupingControl1.Table.AddNewRecord.EndEdit()


                                    End If
                                End If


                            Next




                        Else
                            Me.dgvAnticipos.Table.CurrentRecord.SetValue("pago", 0)
                            MessageBox.Show("No hay monto suficiente en el anticipo")
                        End If

                        total += CDec(i.GetValue("pago"))
                        totalme += CDec(i.GetValue("pago") / i.GetValue("tipoCambio"))




                    Next


                    txttotalpagomn.Value = total
                    txttotalpagome.Value = totalme

                Case 3


            End Select
        End If
    End Sub

  
    
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txttotalpagomn.Value > lblDeudaPendiente.Text Then
            MessageBox.Show("El monto a pagar debe ser menor o igual al saldo")
            Exit Sub
        End If

        Grabar()


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dispose()
    End Sub
End Class