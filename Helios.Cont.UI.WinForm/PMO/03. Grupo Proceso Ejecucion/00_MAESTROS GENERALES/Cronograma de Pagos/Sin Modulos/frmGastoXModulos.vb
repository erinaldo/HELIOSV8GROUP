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
Imports System.Collections
Imports System.Collections.Specialized
Imports Syncfusion.Windows.Forms.Tools

Public Class frmGastoXModulos
    Inherits frmMaster

    Public Property txtCuenta As String
    Public Property idCostoGeneral As Integer
    Dim asientoSA As New AsientoSA
    Dim listaAsiento As New List(Of movimiento)
    Dim listaAst As New List(Of asiento)

    Dim SumaTotalDebeMN As Decimal = 0
    Dim SumaTotalHaberMN As Decimal = 0
    Dim SumaTotalDebeME As Decimal = 0
    Dim SumaTotalHaberME As Decimal = 0


    ' Public Property ListaAsientos As New List(Of asiento)
    Public Property ManipulacionEstado() As String
    'Public Property ListadoCuentasContables As New List(Of cuentaplanContableEmpresa)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        configuracionModuloV2(Gempresas.IdEmpresaRuc, "GASTOS", Me.Text, GEstableciento.IdEstablecimiento)
        Loadcontroles()
        txtTipoCambio.Value = TmpTipoCambio
        cboMoneda.SelectedValue = "1"
        GetTableGrid()
        LoadCombos()
        GridCFG2(dgvMovimientos)
        'If Not lblIdDocumento.Text = "00" Then
        '    UbicarDocumento(CInt(lblIdDocumento.Text))
        'End If
        ' Add any initialization after the InitializeComponent() call.
        txtFecha.Value = DateTime.Now
    End Sub
    Private Sub LoadCombos()
        Dim cuentaSA As New cuentaplanContableEmpresaSA
        ListadoCuentasContables = cuentaSA.ObtenerCuentasPorEmpresaEscalable(Gempresas.IdEmpresaRuc)
    End Sub

    Sub GetTableGrid()
        Dim dt As New DataTable()
        dt.Columns.Add("idSecuencia", GetType(Integer))
        dt.Columns.Add("idmovimiento", GetType(Integer))
        dt.Columns.Add("cuenta", GetType(String))
        dt.Columns.Add("descripcion", GetType(String))
        dt.Columns.Add("tipo", GetType(String))
        dt.Columns.Add("monto", GetType(Decimal))
        dt.Columns.Add("montoUSD", GetType(Decimal))
        dt.Columns.Add("estado", GetType(String))
        dt.Columns.Add("debe", GetType(Decimal))
        dt.Columns.Add("haber", GetType(Decimal))
        dt.Columns.Add("tipoPago", GetType(String))
        dt.Columns.Add("idCosto")
        dt.Columns.Add("NombreProyectoGeneral")
        dt.Columns.Add("idSubProyecto")
        dt.Columns.Add("Subproyecto")
        dt.Columns.Add("idEDT")
        dt.Columns.Add("edt")
        dt.Columns.Add("tipoCosto")
        dt.Columns.Add("idElemento")
        dt.Columns.Add("Elemento")
        dt.Columns.Add("abrev")
        dgvMovimientos.DataSource = dt
    End Sub



    Public Sub New(IdDocumento As Integer)

        ' This call is required by the designer.
        InitializeComponent()
        UbicarDocumento(IdDocumento)
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    'Public Sub New(IdDocumento As Integer)

    '    UbicarDocumento(IdDocumento)
    'End Sub

#Region "Asientos"
    Public Property ListaAsientos As New List(Of asiento)
    Public Property ListaMovimiento As New List(Of movimiento)

    Public Property ListadoCuentasContables As New List(Of cuentaplanContableEmpresa)
    Public Property ListadoOperaciones As New List(Of tabladetalle)
#End Region

#Region "Metodos"



    Private Sub EliminarFilaMovimiento(mov As movimiento)
        Dim consulta = (From n In ListaMovimiento _
                       Where n.idmovimiento = mov.idmovimiento).FirstOrDefault

        ListaMovimiento.Remove(consulta)
        GetListadoMovimientoByAsiento(New asiento With {.idAsiento = lstAsientos.SelectedValue})
    End Sub


    Private Sub AddMovimiento()
        Dim n As New movimiento
        n.idAsiento = lstAsientos.SelectedValue
        If ListaMovimiento.Count > 0 Then
            n.idmovimiento = ListaMovimiento.Count + 1
        Else
            n.idmovimiento = 1
        End If
        n.cuenta = txtCuentaSel.Tag
        'n.descripcion = txtCuentaSel.Text
        'n.tipo = "D"
        n.monto = 0
        n.montoUSD = 0


        ''/martin

        If txtCuentaSel.Text.Trim.Length > 0 Then

            Dim conteo As Integer = Len(txtCuentaSel.Tag)

            ' Dim val As String = txtCuentaSel.Text.Replace(txtCuentaSel.Tag.ToString, "")
            If conteo > 2 Then
                Dim val As String = txtCuentaSel.Text
                ' val = val.Replace("-", "")
                'val = val.Replace(" ", "")
                Dim conteo2 As Integer = Len(txtCuentaSel.Text)

                conteo = conteo + 6
                conteo2 = conteo2 - conteo
                'Dim s = val.Substring(conteo, 5)
                Dim s = txtCuentaSel.Text.Substring(conteo, conteo2)

                n.descripcion = s
            Else
                Dim val As String = txtCuentaSel.Text
                ' val = val.Replace("-", "")
                'val = val.Replace(" ", "")
                Dim conteo2 As Integer = Len(txtCuentaSel.Text)

                conteo = conteo + 3
                conteo2 = conteo2 - conteo
                'Dim s = val.Substring(conteo, 5)
                Dim s = txtCuentaSel.Text.Substring(conteo, conteo2)

                n.descripcion = s
            End If

            'n.descripcion = val

            n.idSecuencia = 0
            n.estado = "1"
            n.debe = CDec(0.0)
            n.haber = CDec(0.0)


            If Mid(txtCuentaSel.Tag, 1, 1) = "4" Then

                If txtCuentaSel.Tag = "422" Then
                    'Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoPago", "C")
                    n.tipoPago = "C"
                    n.tipo = "D"
                ElseIf txtCuentaSel.Tag = "432" Then
                    'Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoPago", "C")
                    n.tipoPago = "C"
                    n.tipo = "D"
                ElseIf Mid(txtCuentaSel.Tag, 1, 2) = "48" Then
                    'Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoPago", "N")
                    n.tipoPago = "N"
                    n.tipo = "D"
                ElseIf Mid(txtCuentaSel.Tag, 1, 2) = "49" Then
                    ' Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoPago", "N")
                    n.tipoPago = "N"
                    n.tipo = "D"
                Else
                    If txtProveedor.Tag >= 0 Then
                        'Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoPago", "P")
                        n.tipoPago = "P"
                        n.tipo = "H"
                    Else

                        MessageBox.Show("Debe Ingresar una Identificacion")
                        Exit Sub
                    End If
                End If

            ElseIf txtCuentaSel.Tag = "122" Then
                If txtProveedor.Tag > 0 Then
                    'Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoPago", "P")
                    n.tipoPago = "P"
                    n.tipo = "H"
                Else

                    MessageBox.Show("Debe Ingresar una Identificacion")
                    Exit Sub
                End If
            ElseIf txtCuentaSel.Tag = "132" Then
                If txtProveedor.Tag > 0 Then
                    'Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoPago", "P")
                    n.tipoPago = "P"
                    n.tipo = "H"
                Else

                    MessageBox.Show("Debe Ingresar una Identificacion")
                    Exit Sub
                End If

            ElseIf Mid(txtCuentaSel.Tag, 1, 2) = "12" Then
                'Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoPago", "C")
                n.tipoPago = "C"
                n.tipo = "D"
            ElseIf Mid(txtCuentaSel.Tag, 1, 2) = "13" Then
                ' Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoPago", "C")
                n.tipoPago = "C"
                n.tipo = "D"
            ElseIf Mid(txtCuentaSel.Tag, 1, 2) = "14" Then
                ' Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoPago", "C")
                n.tipoPago = "C"
                n.tipo = "D"
            ElseIf Mid(txtCuentaSel.Tag, 1, 2) = "16" Then
                ' Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoPago", "C")
                n.tipoPago = "C"
                n.tipo = "D"
            ElseIf Mid(txtCuentaSel.Tag, 1, 2) = "17" Then
                ' Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoPago", "C")
                n.tipoPago = "C"
                n.tipo = "D"
            Else
                'Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoPago", "N")
                n.tipoPago = "N"
                n.tipo = "D"

            End If
        End If
        '/martin






        ListaMovimiento.Add(n)

        GetListadoMovimientoByAsiento(New asiento With {.idAsiento = lstAsientos.SelectedValue})
    End Sub

    Private Sub EliminarAsientoByCodigo(be As asiento)

        Dim con1 = (From n In ListaMovimiento _
                   Where n.idAsiento = be.idAsiento).ToList

        For Each i In con1
            ListaMovimiento.Remove(i)
        Next

        Dim con2 = (From n In ListaAsientos _
                   Where n.idAsiento = be.idAsiento).FirstOrDefault

        ListaAsientos.Remove(con2)

        GetListadoAsientos()

        If lstAsientos.SelectedItems.Count > 0 Then
            GetListadoMovimientoByAsiento(New asiento With {.idAsiento = lstAsientos.SelectedValue})
        Else
            dgvMovimientos.DataSource = New List(Of movimiento)
        End If
    End Sub

    Private Sub GetListadoMovimientoByAsiento(be As asiento)
        Dim con = (From n In ListaMovimiento _
                  Where n.idAsiento = be.idAsiento).ToList

        dgvMovimientos.DataSource = con
    End Sub



    Private Sub AddAsiento()
        Dim n As New asiento
        n.Action = Business.Entity.BaseBE.EntityAction.INSERT
        n.periodo = txtPeriodo.Text
        n.idDocumento = 0
        n.idEmpresa = Gempresas.IdEmpresaRuc
        n.idCentroCostos = GEstableciento.IdEstablecimiento
        n.fechaProceso = DateTime.Now
        n.codigoLibro = "5"
        n.tipo = "D"
        n.tipoAsiento = "AS-M"
        n.glosa = "Asiento manual"
        If ListaAsientos.Count > 0 Then
            n.idAsiento = ListaAsientos.Count + 1
            n.Descripcion = "Asiento " & ListaAsientos.Count + 1
        Else
            n.idAsiento = 1
            n.Descripcion = "Asiento " & 1
        End If
        n.usuarioActualizacion = usuario.IDUsuario
        n.fechaActualizacion = DateTime.Now
        ListaAsientos.Add(n)
        GetListadoAsientos()
    End Sub

    Private Sub GetListadoAsientos()
        Dim con = (From n In ListaAsientos).ToList

        lstAsientos.DataSource = con
        lstAsientos.ValueMember = "idAsiento"
        lstAsientos.DisplayMember = "Descripcion"
    End Sub

    Sub GridCFG2(grid As GridGroupingControl)
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


    Public Sub CargarTrabajadoresXnivel(strNivel As String, strBusqueda As String)
        '   Dim personaSA As New PersonaSA
        Dim personalSA As New Planilla.WCFService.ServiceAccess.PersonalSA

        Try
            lsvProveedor.Items.Clear()
            For Each i In personalSA.PersonalSelStartwithNombres(New Helios.Planilla.Business.Entity.Personal With {.Nombre = strBusqueda})
                Dim n As New ListViewItem(i.IDPersonal)
                n.SubItems.Add(i.FullName)
                n.SubItems.Add(String.Empty)
                n.SubItems.Add(i.IDPersonal)
                lsvProveedor.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub


    Public Sub CargarEntidadesXtipo(strTipo As String, strBusqueda As String)
        Dim entidadSA As New entidadSA
        Try
            lsvProveedor.Items.Clear()
            For Each i As entidad In entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, strTipo, strBusqueda)
                Dim n As New ListViewItem(i.idEntidad)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(i.cuentaAsiento)
                n.SubItems.Add(i.nrodoc)
                lsvProveedor.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub


    Public Sub UbicarDocumento(ByVal intIdDocumento As Integer)
        Dim objDoc As New documentoLibroDiarioSA
        Dim tabla As New tablaDetalleSA
        Dim objDocDet As New documentoLibroDiarioSA
        Dim entidadSA As New entidadSA
        Dim PersonaSA As New Planilla.WCFService.ServiceAccess.PersonalSA
        'Dim prov As String


        Try

            With objDoc.UbicarGastosModulo(intIdDocumento)

                'cboMotivo.SelectedValue = tabla.GetUbicarTablaID("30", .tipoRegistro).codigoDetalle
                txtPeriodo.Text = .fechaPeriodo
                cboMotivo.SelectedValue = .tipoRegistro
                txtFecha.Value = .fecha
                txtFecVence.Value = .fechaVct
                txtImporteMN.Value = .importeMN
                txtImporteME.Value = .importeME
                txtTipoCambio.Value = .tipoCambio
                txtGlosa.Text = .infoReferencial
                cboMoneda.SelectedValue = .moneda


                'prov = .idReferencia
                'If prov.Trim.Length > 0 Then


                '    CheckBox2.Checked = True
                '    GroupBox5.Visible = True
                '    sdgsg()

                'End If
                If IsNothing(.idReferencia) Then

                Else

                    Select Case .tipoRazonSocial
                        Case TIPO_ENTIDAD.PROVEEDOR
                            txtProveedor.Tag = .idReferencia
                            With entidadSA.UbicarEntidadPorID(.idReferencia).First
                                txtProveedor.Text = .nombreCompleto
                            End With
                        Case TIPO_ENTIDAD.CLIENTE
                            txtProveedor.Tag = .idReferencia
                            With entidadSA.UbicarEntidadPorID(.idReferencia).First
                                txtProveedor.Text = .nombreCompleto
                            End With
                        Case "TR"
                            txtProveedor.Tag = .idReferencia
                            Dim person = PersonaSA.PersonalSelxID(New Planilla.Business.Entity.Personal With {.IDPersonal = txtProveedor.Tag})
                            If Not IsNothing(person) Then
                                txtProveedor.Text = person.FullName
                            End If

                    End Select
                End If

            End With



            dgvMovimientos.Table.Records.DeleteAll()

            'For Each i In objDocDet.UbicarDocumentoCompraDetalle(intIdDocumento)

            '    Me.dgvMovimientos.Table.AddNewRecord.SetCurrent()
            '    Me.dgvMovimientos.Table.AddNewRecord.BeginEdit()

            '    Me.dgvMovimientos.Table.CurrentRecord.SetValue("idSecuencia", i.secuencia)
            '    Me.dgvMovimientos.Table.CurrentRecord.SetValue("idmovimiento", 1)
            '    Me.dgvMovimientos.Table.CurrentRecord.SetValue("cuenta", i.cuenta)
            '    Me.dgvMovimientos.Table.CurrentRecord.SetValue("descripcion", i.descripcion)
            '    Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipo", i.tipoAsiento)
            '    Me.dgvMovimientos.Table.CurrentRecord.SetValue("monto", i.importeMN)
            '    Me.dgvMovimientos.Table.CurrentRecord.SetValue("montoUSD", i.importeME)
            '    Me.dgvMovimientos.Table.CurrentRecord.SetValue("estado", ManipulacionEstado = ENTITY_ACTIONS.UPDATE)

            '    If i.tipoAsiento = "D" Then
            '        Me.dgvMovimientos.Table.CurrentRecord.SetValue("debe", i.importeMN)
            '        Me.dgvMovimientos.Table.CurrentRecord.SetValue("haber", CDec(0.0))
            '    ElseIf i.tipoAsiento = "H" Then
            '        Me.dgvMovimientos.Table.CurrentRecord.SetValue("debe", CDec(0.0))
            '        Me.dgvMovimientos.Table.CurrentRecord.SetValue("haber", i.importeMN)
            '    End If

            '    Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoPago", i.tipoPago)


            '    Me.dgvMovimientos.Table.AddNewRecord.EndEdit()
            'Next

            Dim movimientosSA As New MovimientoSA
            Dim cuentaSA As New cuentaplanContableEmpresaSA

            listaAst = AsientoSA.UbicarAsientoPorDocumento(intIdDocumento)

            Dim recuperaASTCosto = (From n In listaAst _
                                   Where n.tipoAsiento = "ACCA").ToList

            For Each i In recuperaASTCosto
                listaAst.Remove(i)
            Next

            'If listaAst.Count >= 2 Then
            '    listaAst.RemoveAt(listaAst.Count - 1)
            'End If

            For Each i In listaAst
                Dim n As New asiento
                n.Action = Business.Entity.BaseBE.EntityAction.INSERT
                n.idDocumento = 0
                n.periodo = txtPeriodo.Text
                n.idEmpresa = Gempresas.IdEmpresaRuc
                n.idCentroCostos = GEstableciento.IdEstablecimiento
                n.fechaProceso = txtFecha.Value
                n.codigoLibro = "5"
                n.tipo = "D"
                n.tipoAsiento = "AS-M"
                n.glosa = i.glosa
                If ListaAsientos.Count > 0 Then
                    n.idAsiento = ListaAsientos.Count + 1
                    n.Descripcion = "Asiento " & ListaAsientos.Count + 1
                Else
                    n.idAsiento = 1
                    n.Descripcion = "Asiento " & 1
                End If
                n.usuarioActualizacion = usuario.IDUsuario
                n.fechaActualizacion = DateTime.Now
                ListaAsientos.Add(n)

                listaAsiento = movimientosSA.UbicarMovimientoPorAsiento(i.idAsiento)
                For Each mov In listaAsiento
                    Dim n1 As New movimiento
                    n1.idAsiento = n.idAsiento
                    If ListaMovimiento.Count > 0 Then
                        n1.idmovimiento = ListaMovimiento.Count + 1
                    Else
                        n1.idmovimiento = 1
                    End If
                    n1.cuenta = mov.cuenta
                    n1.descripcion = mov.descripcion
                    n1.tipo = mov.tipo
                    n1.monto = mov.monto
                    n1.montoUSD = 0

                    If mov.cuenta > 0 Then

                        If Mid(mov.cuenta, 1, 1) = "4" Then
                            If mov.cuenta = "422" Then
                                n1.tipoPago = "C"

                            ElseIf mov.cuenta = "432" Then
                                n1.tipoPago = "C"
                            ElseIf Mid(mov.cuenta, 1, 2) = "48" Then
                                n1.tipoPago = "N"
                            ElseIf Mid(mov.cuenta, 1, 2) = "49" Then
                                n1.tipoPago = "N"
                            Else
                                n1.tipoPago = "P"
                            End If

                        ElseIf mov.cuenta = "122" Then
                            n1.tipoPago = "P"
                        ElseIf mov.cuenta = "132" Then
                            n1.tipoPago = "P"

                        ElseIf Mid(mov.cuenta, 1, 2) = "12" Then
                            n1.tipoPago = "C"
                        ElseIf Mid(mov.cuenta, 1, 2) = "13" Then
                            n1.tipoPago = "C"
                        ElseIf Mid(mov.cuenta, 1, 2) = "14" Then
                            n1.tipoPago = "C"
                        ElseIf Mid(mov.cuenta, 1, 2) = "16" Then
                            n1.tipoPago = "C"
                        ElseIf Mid(mov.cuenta, 1, 2) = "17" Then
                            n1.tipoPago = "C"
                        Else
                            n1.tipoPago = "N"
                        End If

                    End If



                    ListaMovimiento.Add(n1)
                Next
            Next
            'GetasientosListbox()
            GetListadoAsientos()
            If lstAsientos.SelectedItems.Count > 0 Then
                GetListadoMovimientoByAsiento(New asiento With {.idAsiento = lstAsientos.SelectedValue})
            End If

        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try

    End Sub


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
    '        'lblEstado.Text = "Este módulo no contiene una configuración disponible, intentelo más tarde.!"

    '        MessageBox.Show("Este módulo no contiene una configuración disponible, intentelo más tarde.!")

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

    'Public Sub UpdateGasto()
    '    Dim LibroSA As New documentoLibroDiarioSA
    '    Dim nDocumentoLibro As New documentoLibroDiario()
    '    Dim objDocumentoLibroDet As New documentoLibroDiarioDetalle
    '    Dim ListaDetalle As New List(Of documentoLibroDiarioDetalle)


    '    With nDocumentoLibro


    '        .idDocumento = lblIdDocumento.Text
    '        .idEmpresa = Gempresas.IdEmpresaRuc
    '        .idEstablecimiento = GEstableciento.IdEstablecimiento
    '        .tipoRegistro = cboMotivo.SelectedValue
    '        .fecha = txtFecha.Value
    '        .fechaVct = txtFecVence.Value
    '        .fechaPeriodo = txtPeriodo.Text
    '        .infoReferencial = txtGlosa.Text
    '        .tipoRazonSocial = "PR"
    '        .razonSocial = CInt(45876583)
    '        .tipoDoc = GConfiguracion.TipoComprobante
    '        '.nroDoc = GConfiguracion.NombreComprobante
    '        .IdNumeracion = GConfiguracion.ConfigComprobante
    '        .tipoOperacion = "GM"
    '        .moneda = cboMoneda.SelectedValue
    '        .tipoCambio = txtTipoCambio.Value
    '        .importeMN = txtImporteMN.Value
    '        .importeME = txtImporteME.Value
    '        .idReferencia = CInt(1)
    '        .tieneCosto = "S"
    '        .idCosto = CInt(1)
    '        .usuarioActualizacion = "Jiuni"
    '        .fechaActualizacion = DateTime.Now

    '    End With

    '    LibroSA.ActualizarGastoModulo(nDocumentoLibro)


    '    Dispose()
    'End Sub

    Public Sub UpdateGasto()
        Dim costoSA As New recursoCostoSA
        Dim documento As New documento
        Dim documentoLibroDiario As New documentoLibroDiario
        Dim documentoLibroDiarioDet As New documentoLibroDiarioDetalle
        Dim ListaDetalle As New List(Of documentoLibroDiarioDetalle)
        Dim documentoLibroDiarioSA As New documentoLibroDiarioSA
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim documentonumero = lblIdDocumento.Text

        documento = New documento
        documento.idDocumento = CInt(documentonumero)
        documento.Action = Business.Entity.BaseBE.EntityAction.INSERT
        documento.idEmpresa = Gempresas.IdEmpresaRuc
        documento.idCentroCosto = GEstableciento.IdEstablecimiento
        documento.tipoDoc = "9901" 'VOUCHER CONTABLE
        documento.fechaProceso = txtFecha.Value
        documento.nroDoc = "1"
        documento.tipoOperacion = StatusTipoOperacion.INGRESO_CUENTAS_MANUALES
        documento.idOrden = Nothing
        documento.moneda = IIf(cboMoneda.SelectedValue = 1, "1", "2")
        documento.idEntidad = Val(txtProveedor.Tag)
        documento.entidad = txtProveedor.Text
        documento.nrodocEntidad = txtRuc.Text
        If chProv.Checked = True Then
            documento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        ElseIf chCli.Checked = True Then
            documento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        ElseIf chTrab.Checked = True Then
            documento.tipoEntidad = TIPO_ENTIDAD.PERSONA_GENERAL
        End If
        documento.usuarioActualizacion = usuario.IDUsuario
        documento.fechaActualizacion = DateTime.Now


        documentoLibroDiario = New documentoLibroDiario
        documentoLibroDiario.idDocumento = CInt(documentonumero)
        documentoLibroDiario.TipoConfiguracion = GConfiguracion.TipoConfiguracion
        documentoLibroDiario.IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
        documentoLibroDiario.idEmpresa = Gempresas.IdEmpresaRuc
        documentoLibroDiario.idEstablecimiento = GEstableciento.IdEstablecimiento
        documentoLibroDiario.tipoRegistro = cboMotivo.SelectedValue
        documentoLibroDiario.fecha = txtFecha.Value
        documentoLibroDiario.fechaPeriodo = txtPeriodo.Text
        documentoLibroDiario.infoReferencial = txtGlosa.Text
        documentoLibroDiario.tipoDoc = "9901"
        documentoLibroDiario.nroDoc = "1"
        documentoLibroDiario.tipoOperacion = StatusTipoOperacion.INGRESO_CUENTAS_MANUALES
        'documentoLibroDiario.moneda = IIf(rbnac.Checked = True, "1", "2")
        documentoLibroDiario.moneda = cboMoneda.SelectedValue
        documentoLibroDiario.tipoCambio = txtTipoCambio.Value
        documentoLibroDiario.usuarioActualizacion = usuario.IDUsuario
        documentoLibroDiario.fechaActualizacion = DateTime.Now
        documentoLibroDiario.tieneCosto = txtTieneCosto.Text

        'If chCosto.Checked = True Then
        '    If rbCosto.Checked = True Then
        '        documentoLibroDiario.tieneCosto = "S"
        '        documentoLibroDiario.idCosto = cboElementoCosto.SelectedValue
        '    Else
        '        documentoLibroDiario.tieneCosto = "S"
        '        documentoLibroDiario.idCosto = cboCosto.SelectedValue
        '    End If
        'Else
        documentoLibroDiario.tieneCosto = txtTieneCosto.Text
        documentoLibroDiario.idCosto = Nothing
        'End If

        'documentoLibroDiario.importeMN = 0
        'documentoLibroDiario.importeME = 0
        documento.documentoLibroDiario = documentoLibroDiario
        SumaTotalDebeMN = 0
        SumaTotalHaberMN = 0

        SumaTotalDebeME = 0
        SumaTotalHaberME = 0

        'If chCosto.Checked = True Then
        '    'ASIENTOS CONTABLES
        '    nAsiento = New asiento With {
        '    .idEmpresa = Gempresas.IdEmpresaRuc,
        '    .idCentroCostos = GEstableciento.IdEstablecimiento,
        '    .idDocumentoRef = Nothing,
        '    .idAlmacen = 0,
        '    .nombreAlmacen = String.Empty,
        '    .idEntidad = String.Empty,
        '    .nombreEntidad = String.Empty,
        '    .tipoEntidad = String.Empty,
        '    .fechaProceso = txtFecha.Value,
        '    .codigoLibro = "5",
        '    .tipo = "D",
        '    .tipoAsiento = "ACCA",
        '    .importeMN = 0,
        '    .importeME = 0,
        '    .glosa = txtGlosa.Text.Trim,
        '    .IdProceso = cboProceso.SelectedValue,
        '    .usuarioActualizacion = usuario.IDUsuario,
        '    .fechaActualizacion = DateTime.Now}
        'End If



        Dim sumaCostoMN As Decimal = 0
        Dim sumaCostoME As Decimal = 0

        For Each obj In ListaMovimiento
            documentoLibroDiarioDet = New documentoLibroDiarioDetalle
            documentoLibroDiarioDet.idItem = obj.cuenta
            documentoLibroDiarioDet.FechaDoc = txtFecha.Value
            'If chCosto.Checked = True Then
            '    documentoLibroDiarioDet.idCosto = cboElementoCosto.SelectedValue
            '    documentoLibroDiarioDet.idProceso = cboProceso.SelectedValue
            '    Dim cuentaMid = Mid(obj.cuenta, 1, 2)
            '    Select Case Val(cuentaMid)
            '        Case 62 To 68
            '            sumaCostoMN += CDec(obj.monto)
            '            sumaCostoME += CDec(obj.monto / txtTipoCambio.Value)
            '    End Select
            'End If
            documentoLibroDiarioDet.cuenta = obj.cuenta
            documentoLibroDiarioDet.descripcion = obj.descripcion
            documentoLibroDiarioDet.tipoAsiento = obj.tipo
            documentoLibroDiarioDet.importeMN = obj.monto
            documentoLibroDiarioDet.tipoPago = obj.tipoPago
            documentoLibroDiarioDet.importeME = CDec(obj.monto / txtTipoCambio.Value)
            documentoLibroDiarioDet.usuarioActualizacion = usuario.IDUsuario
            documentoLibroDiarioDet.fechaActualizacion = DateTime.Now

            documentoLibroDiarioDet.fechaRegistro = CDate(txtFecha.Value)
            documentoLibroDiarioDet.idCosto = obj.idCosto
            documentoLibroDiarioDet.idItem = obj.cuenta
            documentoLibroDiarioDet.operacion = "9919"
            documentoLibroDiarioDet.idProceso = obj.idEDT
            documentoLibroDiarioDet.procesado = "N"
            documentoLibroDiarioDet.recursoCosto = ""


            ListaDetalle.Add(documentoLibroDiarioDet)
        Next

        'If chCosto.Checked = True Then
        '    Select Case txtTipoCosto.Text
        '        Case TipoCosto.Proyecto, _
        '            TipoCosto.CONTRATOS_DE_CONSTRUCCION, _
        '            TipoCosto.CONTRATOS_DE_SERVICIOS_POR_VALORIZACIONES_O_SIMILARES, _
        '            TipoCosto.CONTRATOS_DE_ARRENDAMIENTOS
        '            nMovimiento = New movimiento With {
        '                .cuenta = costoSA.GetCostoById(New recursoCosto With {.idCosto = cboElementoCosto.SelectedValue}).codigo,
        '                .descripcion = "MATERIALES AUXILIARES",
        '                .tipo = "D",
        '                .monto = sumaCostoMN,
        '                .montoUSD = sumaCostoME,
        '                .usuarioActualizacion = usuario.IDUsuario,
        '                .fechaActualizacion = DateTime.Now
        '            }
        '            nAsiento.movimiento.Add(nMovimiento)

        '            nMovimiento = New movimiento With {
        '            .cuenta = "791",
        '            .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
        '            .tipo = "H",
        '            .monto = sumaCostoMN,
        '            .montoUSD = sumaCostoME,
        '            .usuarioActualizacion = usuario.IDUsuario,
        '            .fechaActualizacion = DateTime.Now
        '        }
        '            nAsiento.movimiento.Add(nMovimiento)

        '        Case TipoCosto.OrdenProduccion, _
        '            TipoCosto.OP_CONTINUA_DE_BIENES, _
        '            TipoCosto.OP_DE_BIENES_CONTROL_INDEPENDIENTE, _
        '            TipoCosto.OP_CONTINUA_DE_SERVICIOS, _
        '            TipoCosto.OP_DE_SERVICIOS_CONTROL_INDEPENDIENTE, _
        '            TipoCosto.OP_DE_SERVICIOS_CONSUMO_INMEDIATO_DE_BIENES

        '            nMovimiento = New movimiento With {
        '                .cuenta = "231",
        '                .descripcion = "PRODUCTOS EN PROCESO DE MANUFACTURA",
        '                .tipo = "D",
        '                .monto = sumaCostoMN,
        '                .montoUSD = sumaCostoME,
        '                .usuarioActualizacion = usuario.IDUsuario,
        '                .fechaActualizacion = DateTime.Now
        '            }
        '            nAsiento.movimiento.Add(nMovimiento)

        '            nMovimiento = New movimiento With {
        '            .cuenta = "7111",
        '            .descripcion = "PRODUCTOS MANUFACTURADOS",
        '            .tipo = "H",
        '            .monto = sumaCostoMN,
        '            .montoUSD = sumaCostoME,
        '            .usuarioActualizacion = usuario.IDUsuario,
        '            .fechaActualizacion = DateTime.Now
        '        }
        '            nAsiento.movimiento.Add(nMovimiento)


        '        Case TipoCosto.ActivoFijo

        '            nMovimiento = New movimiento With {
        '                .cuenta = costoSA.GetCostoById(New recursoCosto With {.idCosto = cboElementoCosto.SelectedValue}).codigo,
        '                .descripcion = "CONSTRUCCIONES Y OBRAS EN CURSO",
        '                .tipo = "D",
        '                .monto = sumaCostoMN,
        '                .montoUSD = sumaCostoME,
        '                .usuarioActualizacion = usuario.IDUsuario,
        '                .fechaActualizacion = DateTime.Now
        '            }
        '            nAsiento.movimiento.Add(nMovimiento)

        '            nMovimiento = New movimiento With {
        '            .cuenta = "7225",
        '            .descripcion = "EQUIPOS DIVERSOS",
        '            .tipo = "H",
        '            .monto = sumaCostoMN,
        '            .montoUSD = sumaCostoME,
        '            .usuarioActualizacion = usuario.IDUsuario,
        '            .fechaActualizacion = DateTime.Now
        '        }
        '            nAsiento.movimiento.Add(nMovimiento)


        '        Case TipoCosto.GastoAdministrativo, TipoCosto.GastoVentas, TipoCosto.GastoFinanciero

        '            nMovimiento = New movimiento With {
        '                .cuenta = costoSA.GetCostoById(New recursoCosto With {.idCosto = cboCosto.SelectedValue}).codigo,
        '                .descripcion = "GASTOS ADMINISTRATIVOS.",
        '                .tipo = "D",
        '                .monto = sumaCostoMN,
        '                .montoUSD = sumaCostoME,
        '                .usuarioActualizacion = usuario.IDUsuario,
        '                .fechaActualizacion = DateTime.Now
        '            }
        '            nAsiento.movimiento.Add(nMovimiento)

        '            nMovimiento = New movimiento With {
        '            .cuenta = "79",
        '            .descripcion = "CARGAS IMPUTABLES A CUENTAS DE COSTOS Y GASTOS",
        '            .tipo = "H",
        '            .monto = sumaCostoMN,
        '            .montoUSD = sumaCostoME,
        '            .usuarioActualizacion = usuario.IDUsuario,
        '            .fechaActualizacion = DateTime.Now
        '        }
        '            nAsiento.movimiento.Add(nMovimiento)
        '    End Select

        '    nAsiento.importeMN = ListaMovimiento.Where(Function(o) o.tipo = "D").Sum(Function(o) o.monto)
        '    nAsiento.importeME = ListaMovimiento.Where(Function(o) o.tipo = "D").Sum(Function(o) o.montoUSD)
        'End If
        documento.documentoLibroDiario.importeMN = ListaMovimiento.Where(Function(o) o.tipo = "D").Sum(Function(o) o.monto)
        documento.documentoLibroDiario.importeME = ListaMovimiento.Where(Function(o) o.tipo = "D").Sum(Function(o) o.montoUSD)
        documento.documentoLibroDiario.documentoLibroDiarioDetalle = ListaDetalle

        For Each i In ListaAsientos
            Dim consultaMov = (From n In ListaMovimiento _
                              Where n.idAsiento = i.idAsiento).ToList

            i.periodo = txtPeriodo.Text
            i.idEmpresa = Gempresas.IdEmpresaRuc
            i.idCentroCostos = GEstableciento.IdEstablecimiento
            i.idEntidad = Val(txtProveedor.Tag)
            i.nombreEntidad = txtProveedor.Text
            If chProv.Checked = True Then
                i.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
            ElseIf chCli.Checked = True Then
                i.tipoEntidad = TIPO_ENTIDAD.CLIENTE
            ElseIf chTrab.Checked = True Then
                i.tipoEntidad = TIPO_ENTIDAD.PERSONA_GENERAL
            End If
            i.fechaProceso = txtFecha.Value
            i.codigoLibro = "5"
            i.tipo = "D"
            i.tipoAsiento = "AS-M"
            i.importeMN = consultaMov.Where(Function(o) o.tipo = "D").Sum(Function(o) o.monto)
            i.importeME = consultaMov.Where(Function(o) o.tipo = "D").Sum(Function(o) o.montoUSD)
            i.glosa = i.glosa
            i.usuarioActualizacion = usuario.IDUsuario
            i.fechaActualizacion = DateTime.Now
            i.Action = Business.Entity.BaseBE.EntityAction.INSERT

            For Each mov In consultaMov
                '    i.Descripcion = mov.nombreEntidad
                i.movimiento.Add(mov)
            Next
        Next

        'If chCosto.Checked = True Then
        '    ListaAsientos.Add(nAsiento)
        'End If
        documento.asiento = ListaAsientos
        documentoLibroDiarioSA.ActualizarDocumentoLibroDiarioASM(documento)
        'lblEstado.Text = "compra registrada!"
        Dispose()
    End Sub



    Public Sub AsientoIntereses()
        Dim asientoBL As New asiento
        Dim nMovimiento As New movimiento

        'asientoBL = New asiento
        'asientoBL.idEmpresa = Gempresas.IdEmpresaRuc
        'asientoBL.idCentroCostos = GEstableciento.IdEstablecimiento


        ''asientoBL.idEntidad = cboDepositoHijo.SelectedValue
        ''asientoBL.nombreEntidad = cboDepositoHijo.Text

        'asientoBL.tipoEntidad = "BC"
        'asientoBL.fechaProceso = DateTime.Now
        'asientoBL.codigoLibro = "1"
        'asientoBL.tipo = "D"
        ''Select Case lblMovimiento.Text
        ''    Case "OTRAS ENTRADAS A CAJA"
        'asientoBL.tipoAsiento = ASIENTO_CONTABLE.OTRAS_ENTRADAS_CAJA
        ''    Case "OTRAS SALIDAS DE CAJA"
        ''asientoBL.tipoAsiento = ASIENTO_CONTABLE.OTRAS_SALIDAS_CAJA
        ''End Select
        'asientoBL.importeMN = CDec(txtImporteMN.Value)
        'asientoBL.importeME = CDec(txtImporteME.Value)
        'asientoBL.glosa = "Por Modulos"

        'For Each r As Record In dgvMovimientos.Table.Records


        '    nMovimiento = New movimiento
        '    'nMovimiento.cuenta = "4411"
        '    nMovimiento.cuenta = r.GetValue("cuenta")
        '    nMovimiento.descripcion = r.GetValue("descripcion")
        '    nMovimiento.tipo = r.GetValue("tipo")
        '    nMovimiento.monto = CDec(r.GetValue("monto"))
        '    nMovimiento.montoUSD = CDec(r.GetValue("montome"))
        '    nMovimiento.usuarioActualizacion = usuario.IDUsuario
        '    nMovimiento.fechaActualizacion = DateTime.Now
        '    asientoBL.movimiento.Add(nMovimiento)
        'Next



        ListaAsientos.Add(asientoBL)

    End Sub

    Sub Grabar()
        Dim LibroSA As New documentoLibroDiarioSA
        Dim ndocumento As New documento()
        Dim nDocumentoLibro As New documentoLibroDiario()
        Dim objDocumentoLibroDet As New documentoLibroDiarioDetalle
        Dim ListaDetalle As New List(Of documentoLibroDiarioDetalle)


        With ndocumento
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If IsNothing(GProyectos) Then
            Else
                .idProyecto = GProyectos.IdProyectoActividad
            End If
            .tipoDoc = GConfiguracion.TipoComprobante
            .fechaProceso = txtFecha.Value
            .moneda = IIf(cboMoneda.SelectedValue = 1, "1", "2")
            .idOrden = Nothing ' Me.IdOrden
            .idEntidad = Val(txtProveedor.Tag)
            .entidad = txtProveedor.Text
            .nrodocEntidad = txtRuc.Text
            If chProv.Checked = True Then
                .tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
            ElseIf chCli.Checked = True Then
                .tipoEntidad = TIPO_ENTIDAD.CLIENTE
            ElseIf chTrab.Checked = True Then
                .tipoEntidad = TIPO_ENTIDAD.PERSONA_GENERAL
            End If
            .nroDoc = GConfiguracion.ConfigComprobante
            .tipoOperacion = StatusTipoOperacion.INGRESO_CUENTAS_MANUALES
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With

        With nDocumentoLibro
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .tipoRegistro = cboMotivo.SelectedValue
            .fecha = txtFecha.Value
            .fechaVct = DateTime.Now
            .fechaPeriodo = txtPeriodo.Text

            'si va ser identificado
            .razonSocial = CInt(txtProveedor.Tag)
            If CheckBox2.Checked = True Then
                If txtProveedor.Text.Trim.Length > 0 Then
                    If chProv.Checked = True Then
                        .tipoRazonSocial = TIPO_ENTIDAD.PROVEEDOR
                    ElseIf chTrab.Checked = True Then
                        .tipoRazonSocial = "TR"
                    ElseIf chCli.Checked = True Then
                        .tipoRazonSocial = TIPO_ENTIDAD.CLIENTE
                    End If

                End If

            End If


            .fechaVct = txtFecVence.Value
            .infoReferencial = txtGlosa.Text
            '.tipoRazonSocial = "PR"
            '.razonSocial = CInt(45876583)
            .tipoDoc = GConfiguracion.TipoComprobante
            '.nroDoc = GConfiguracion.NombreComprobante
            .IdNumeracion = GConfiguracion.ConfigComprobante
            .tipoOperacion = StatusTipoOperacion.INGRESO_CUENTAS_MANUALES
            .moneda = cboMoneda.SelectedValue
            .tipoCambio = txtTipoCambio.Value
            .importeMN = txtImporteMN.Value
            .importeME = txtImporteME.Value
            .idReferencia = CInt(1)
            .tieneCosto = txtTieneCosto.Text
            .idCosto = idCostoGeneral
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now

        End With
        ndocumento.documentoLibroDiario = nDocumentoLibro

        ''mmmm

        For Each i In ListaAsientos
            Dim consultaMov = (From n In ListaMovimiento
                               Where n.idAsiento = i.idAsiento).ToList
            For Each mov In consultaMov

                objDocumentoLibroDet = New documentoLibroDiarioDetalle
                objDocumentoLibroDet.cuenta = mov.cuenta
                objDocumentoLibroDet.descripcion = mov.descripcion
                objDocumentoLibroDet.tipoAsiento = mov.tipo
                objDocumentoLibroDet.importeMN = mov.monto
                objDocumentoLibroDet.importeME = mov.montoUSD
                objDocumentoLibroDet.Evento = "NU"
                objDocumentoLibroDet.idEvento = "NUUU"
                objDocumentoLibroDet.cuentaPadre = "40"
                objDocumentoLibroDet.idEstablecimiento = GEstableciento.IdEstablecimiento
                objDocumentoLibroDet.entregadoCancelado = "N"
                objDocumentoLibroDet.usuarioActualizacion = usuario.IDUsuario
                objDocumentoLibroDet.fechaActualizacion = DateTime.Now
                objDocumentoLibroDet.estadoPago = "PN"
                objDocumentoLibroDet.tipoPago = mov.tipoPago

                objDocumentoLibroDet.fechaRegistro = CDate(txtFecha.Value)


                'objDocumentoLibroDet.idCosto = mov.idCosto
                'objDocumentoLibroDet.tipoCosto = mov.tipoCosto


                objDocumentoLibroDet.idItem = mov.cuenta
                'objDocumentoLibroDet.destino = ""
                'objDocumentoLibroDet.um = ""
                'objDocumentoLibroDet.cant = CDec(i.Record.GetValue("monto1"))
                'objDocumentoLibroDet.puMN = 0
                'objDocumentoLibroDet.puME = 0
                'objDocumentoLibroDet.montoMN = CDec(i.Record.GetValue("montokardex")) * -1
                ' objDocumentoLibroDet.montoME = CDec(i.Record.GetValue("montokardexUS")) * -1
                'objDocumentoLibroDet.documentoRef = i.Record.GetValue("idDocumento")
                'objDocumentoLibroDet.itemRef = i.Record.GetValue("secuencia")
                objDocumentoLibroDet.operacion = "9919"
                ' objDocumentoLibroDet.idProceso = mov.idEDT
                objDocumentoLibroDet.procesado = "N"
                objDocumentoLibroDet.recursoCosto = ""
                'objDocumentoLibroDet.recursoCosto = New recursoCosto With
                '                                        {
                '                                           objDocumentoLibroDet .subtipo = ""
                '                                        }

                objDocumentoLibroDet.ididentificacion = CInt(txtProveedor.Tag)
                If CheckBox2.Checked = True Then
                    If txtProveedor.Text.Trim.Length > 0 Then
                        If chProv.Checked = True Then
                            objDocumentoLibroDet.tipoIdentificacion = TIPO_ENTIDAD.PROVEEDOR
                        ElseIf chTrab.Checked = True Then
                            objDocumentoLibroDet.tipoIdentificacion = "TR"
                        ElseIf chCli.Checked = True Then
                            objDocumentoLibroDet.tipoIdentificacion = TIPO_ENTIDAD.CLIENTE
                        End If
                    End If
                End If



                ListaDetalle.Add(objDocumentoLibroDet)


                i.movimiento.Add(mov)
            Next
        Next

        'mmmm


        ndocumento.documentoLibroDiario.documentoLibroDiarioDetalle = ListaDetalle

        'AsientoIntereses()


        'asiento nuievo
        For Each i In ListaAsientos
            Dim consultaMov = (From n In ListaMovimiento
                               Where n.idAsiento = i.idAsiento).ToList

            i.periodo = txtPeriodo.Text
            i.idEmpresa = Gempresas.IdEmpresaRuc
            i.idCentroCostos = GEstableciento.IdEstablecimiento
            i.idEntidad = Val(txtProveedor.Tag)
            i.nombreEntidad = txtProveedor.Text
            If chProv.Checked = True Then
                i.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
            ElseIf chCli.Checked = True Then
                i.tipoEntidad = TIPO_ENTIDAD.CLIENTE
            ElseIf chTrab.Checked = True Then
                i.tipoEntidad = TIPO_ENTIDAD.PERSONA_GENERAL
            End If
            'i.fechaProceso = txtFechaComprobante.Value
            i.fechaProceso = txtFecha.Value ' DateTime.Now
            i.codigoLibro = "5"
            i.tipo = "D"
            i.tipoAsiento = "AS-M"
            i.importeMN = consultaMov.Where(Function(o) o.tipo = "D").Sum(Function(o) o.monto)
            i.importeME = consultaMov.Where(Function(o) o.tipo = "D").Sum(Function(o) o.montoUSD)
            i.glosa = i.glosa
            i.usuarioActualizacion = usuario.IDUsuario
            i.fechaActualizacion = DateTime.Now
            i.Action = Business.Entity.BaseBE.EntityAction.INSERT

            For Each mov In consultaMov
                '    i.Descripcion = mov.nombreEntidad
                i.movimiento.Add(mov)
            Next
        Next

        'If chCosto.Checked = True Then
        '    ListaAsientos.Add(nAsiento)
        'End If
        'documento.asiento = ListaAsientos



        ndocumento.asiento = ListaAsientos


        Dim xcod As Integer = LibroSA.SaveSaldo(ndocumento)
        ' lblEstado.Text = "compra registrada!"

        'Dim f As New frmModalPreciosVenta(xcod)
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog()

        Dispose()
    End Sub



    Public Sub Loadcontroles()
        '  Dim entidadSA As New entidadSA
        Dim tablaSA As New tablaDetalleSA
        Dim listatabla As New List(Of tabladetalle)
        Dim categoriaSA As New itemSA
        Dim servicioSA As New servicioSA
        Dim efSA As New EstadosFinancierosSA

        cboMotivo.DisplayMember = "descripcion"
        cboMotivo.ValueMember = "codigoDetalle"
        cboMotivo.DataSource = tablaSA.GetListaTablaDetalle(30, "1")

        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("name")

        dt.Rows.Add(1, "NACIONAL")
        dt.Rows.Add(2, "EXTRANJERA")

        cboMoneda.ValueMember = "id"
        cboMoneda.DisplayMember = "name"
        cboMoneda.DataSource = dt
        cboMoneda.SelectedIndex = 0

    End Sub

#End Region

    Private Sub frmGastoXModulos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmGastoXModulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("name")

        Dim dr As DataRow = dt.NewRow
        dr(0) = "D"
        dr(1) = "DEBE"
        dt.Rows.Add(dr)

        Dim dr1 As DataRow = dt.NewRow
        dr1(0) = "H"
        dr1(1) = "HABER"
        dt.Rows.Add(dr1)

        Dim ggcStyle As GridTableCellStyleInfo = dgvMovimientos.TableDescriptor.Columns("tipo").Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = dt
        ggcStyle.ValueMember = "id"
        ggcStyle.DisplayMember = "name"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive
        dgvMovimientos.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell






        Dim dt2 As New DataTable
        dt2.Columns.Add("id")
        dt2.Columns.Add("name")

        Dim dr2 As DataRow = dt2.NewRow
        dr2(0) = "C"
        dr2(1) = "COBRO"
        dt2.Rows.Add(dr2)

        Dim dr3 As DataRow = dt2.NewRow
        dr3(0) = "P"
        dr3(1) = "PAGO"
        dt2.Rows.Add(dr3)

        Dim dr4 As DataRow = dt2.NewRow
        dr4(0) = "N"
        dr4(1) = "NINGUNO"
        dt2.Rows.Add(dr4)

        Dim ggcStyle2 As GridTableCellStyleInfo = dgvMovimientos.TableDescriptor.Columns("tipoPago").Appearance.AnyRecordFieldCell
        ggcStyle2.CellType = "ComboBox"
        ggcStyle2.DataSource = dt2
        ggcStyle2.ValueMember = "id"
        ggcStyle2.DisplayMember = "name"
        ggcStyle2.DropDownStyle = GridDropDownStyle.Exclusive
        dgvMovimientos.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell

        If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
            AddAsiento()
        End If
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click

        If dgvMovimientos.Table.Records.Count > 0 Then

            '  For Each rec As Record In dgvMovimientos.Table.Records
            ' If rec.Record.GetValue("edt") = "" Then
            'If Mid(rec.GetValue("cuenta"), 1, 2) = "62" Then
            '    Dim valEdt = rec.GetValue("edt")
            '    If IsNothing(valEdt) Then
            '        MessageBox.Show("Debe identificar el EDT y elemento del costo" & vbCrLf & "de la cuenta " & rec.GetValue("cuenta"), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '        Exit Sub
            '    End If
            'ElseIf Mid(rec.GetValue("cuenta"), 1, 2) = "63" Then
            '    Dim valEdt = rec.GetValue("edt")
            '    If IsNothing(valEdt) Then
            '        MessageBox.Show("Debe identificar el EDT y elemento del costo" & vbCrLf & "de la cuenta " & rec.GetValue("cuenta"), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '        Exit Sub
            '    End If
            'ElseIf Mid(rec.GetValue("cuenta"), 1, 2) = "64" Then
            '    Dim valEdt = rec.GetValue("edt")
            '    If IsNothing(valEdt) Then
            '        MessageBox.Show("Debe identificar el EDT y elemento del costo" & vbCrLf & "de la cuenta " & rec.GetValue("cuenta"), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '        Exit Sub
            '    End If
            'ElseIf Mid(rec.GetValue("cuenta"), 1, 2) = "65" Then
            '    Dim valEdt = rec.GetValue("edt")
            '    If IsNothing(valEdt) Then
            '        MessageBox.Show("Debe identificar el EDT y elemento del costo" & vbCrLf & "de la cuenta " & rec.GetValue("cuenta"), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '        Exit Sub
            '    End If
            'ElseIf Mid(rec.GetValue("cuenta"), 1, 2) = "66" Then
            '    Dim valEdt = rec.GetValue("edt")
            '    If IsNothing(valEdt) Then
            '        MessageBox.Show("Debe identificar el EDT y elemento del costo" & vbCrLf & "de la cuenta " & rec.GetValue("cuenta"), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '        Exit Sub
            '    End If
            'ElseIf Mid(rec.GetValue("cuenta"), 1, 2) = "67" Then
            '    Dim valEdt = rec.GetValue("edt")
            '    If IsNothing(valEdt) Then
            '        MessageBox.Show("Debe identificar el EDT y elemento del costo" & vbCrLf & "de la cuenta " & rec.GetValue("cuenta"), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '        Exit Sub
            '    End If
            'ElseIf Mid(rec.GetValue("cuenta"), 1, 2) = "68" Then
            '    Dim valEdt = rec.GetValue("edt")
            '    If IsNothing(valEdt) Then
            '        MessageBox.Show("Debe identificar el EDT y elemento del costo" & vbCrLf & "de la cuenta " & rec.GetValue("cuenta"), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '        Exit Sub
            '    End If
            '  'End If
            '     Next

            Dim debe As Decimal = CDec(0.0)
            Dim haber As Decimal = CDec(0.0)

            Dim debetotal As Decimal = CDec(0.0)
            Dim habertotal As Decimal = CDec(0.0)

            For Each r As Record In dgvMovimientos.Table.Records
                'If r.GetValue("cuenta") = "4" Then
                '    If txtProveedor.Tag > 0 Then

                'validar costeo

                'If Mid(r.GetValue("cuenta"), 1, 2) = "62" Or Mid(r.GetValue("cuenta"), 1, 2) = "63" Or
                '                Mid(r.GetValue("cuenta"), 1, 2) = "64" Or Mid(r.GetValue("cuenta"), 1, 2) = "65" Or
                '                Mid(r.GetValue("cuenta"), 1, 2) = "66" Or Mid(r.GetValue("cuenta"), 1, 2) = "67" Or
                '                Mid(r.GetValue("cuenta"), 1, 2) = "68" Then

                '    If Not IsNothing(r.GetValue("idCosto")) Then

                '    Else
                '        MessageBoxAdv.Show(r.GetValue("cuenta") & vbCrLf & vbCrLf & "Debe ser costeado.", "Antención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '        Me.Cursor = Cursors.Arrow
                '        Exit Sub
                '    End If

                'End If






                If r.GetValue("monto") = 0 Then
                    'MessageBox.Show("Los montos deben ser mayor a 0")
                    MessageBox.Show("Los montos deben ser mayor a 0!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                Else
                    If r.GetValue("tipo") = "D" Then
                        debe += r.GetValue("monto")
                        debetotal += r.GetValue("debe")
                    ElseIf r.GetValue("tipo") = "H" Then
                        haber += r.GetValue("monto")
                        habertotal += r.GetValue("haber")
                    End If
                End If


                '    Else

                'MessageBox.Show("Ingrese necesariamente una ifentificacion")
                'Exit Sub

                '    End If
                'End If

            Next

            If Not debetotal = habertotal Then
                'MessageBox.Show("Los asientos no Cuadran")
                MessageBox.Show("Los asientos no Cuadran!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If


            If Not debe = haber Then
                'MessageBox.Show("Los asientos no Cuadran")
                MessageBox.Show("Los asientos no Cuadran!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If



            'If Not txtImporteMN.Value > 0 Then
            '    MessageBox.Show("Ingrese un Monto mayor a 0", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    txtImporteMN.Focus()
            '    Exit Sub
            'End If
            If Not txtGlosa.Text.Trim.Length > 0 Then
                MessageBox.Show("Ingrese una Glosa", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtGlosa.Focus()
                Exit Sub
            End If

            If CheckBox2.Checked = True Then


                'If Not txtProveedor.Text.Trim.Length > 0 Then
                '    MessageBox.Show("Ingrese una Identificacion", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    txtProveedor.Focus()
                '    Exit Sub
                'End If
                If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then



                    If txtRuc.Text.Trim.Length <= 0 Then
                        MessageBox.Show("Ingrese una Identificacion ", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        txtProveedor.Focus()
                        Exit Sub
                    End If
                End If
            End If

            If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                Grabar()
            Else
                UpdateGasto()
            End If

        Else

            ' MessageBox.Show("El asiento no tiene Detalle")
            MessageBox.Show("El asiento no tiene Detalle!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub txtImporteMN_ValueChanged(sender As Object, e As EventArgs) Handles txtImporteMN.ValueChanged
        If cboMoneda.SelectedValue = "1" Then

            txtImporteME.Value = (txtImporteMN.Value / txtTipoCambio.Value)


        Else

        End If
    End Sub

    Private Sub txtImporteME_ValueChanged(sender As Object, e As EventArgs) Handles txtImporteME.ValueChanged
        If cboMoneda.SelectedValue = "2" Then

            txtImporteMN.Value = (txtImporteME.Value * txtTipoCambio.Value)


        Else

        End If
    End Sub

    Private Sub txtProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Me.popupControlContainer1.ParentControl = Me.txtProveedor
            Me.popupControlContainer1.ShowPopup(Point.Empty)
            If chProv.Checked = True Then
                CargarEntidadesXtipo(TIPO_ENTIDAD.PROVEEDOR, txtProveedor.Text.Trim)
            ElseIf chTrab.Checked = True Then
                CargarTrabajadoresXnivel("TR", txtProveedor.Text.Trim)
            ElseIf chCli.Checked = True Then

                CargarEntidadesXtipo(TIPO_ENTIDAD.CLIENTE, txtProveedor.Text.Trim)
            End If
        End If
    End Sub

    Private Sub txtProveedor_TextChanged(sender As Object, e As EventArgs) Handles txtProveedor.TextChanged

    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        If lsvProveedor.SelectedItems.Count > 0 Then
            Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub lsvProveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvProveedor.SelectedIndexChanged

    End Sub

    Private Sub popupControlContainer1_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles popupControlContainer1.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                Me.txtProveedor.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                txtProveedor.Tag = lsvProveedor.SelectedItems(0).SubItems(0).Text
                txtRuc.Text = lsvProveedor.SelectedItems(0).SubItems(3).Text
                txtCuenta = lsvProveedor.SelectedItems(0).SubItems(2).Text
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            GroupBox5.Visible = True
        ElseIf CheckBox2.Checked = False Then
            GroupBox5.Visible = False
        End If
    End Sub

    Private Sub chProv_Click(sender As Object, e As EventArgs) Handles chProv.Click
        chProv.Checked = True
        chTrab.Checked = False
        chCli.Checked = False
        txtProveedor.Clear()
        txtProveedor.Tag = Nothing
        txtRuc.Clear()
    End Sub

    Private Sub chTrab_Click(sender As Object, e As EventArgs) Handles chTrab.Click
        chProv.Checked = False
        chTrab.Checked = True
        chCli.Checked = False
        txtProveedor.Clear()
        txtProveedor.Tag = Nothing
        txtRuc.Clear()
    End Sub

    Private Sub chCli_Click(sender As Object, e As EventArgs) Handles chCli.Click
        chProv.Checked = False
        chTrab.Checked = False
        chCli.Checked = True
        txtProveedor.Clear()
        txtProveedor.Tag = Nothing
        txtRuc.Clear()
    End Sub

    Private Sub ComboBoxAdv2_Click(sender As Object, e As EventArgs) Handles ComboBoxAdv2.Click

    End Sub

    Private Sub ComboBoxAdv2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxAdv2.SelectedIndexChanged
        If ComboBoxAdv2.Text = "DE CONTADO" Then
            txtFecVence.Value = txtFecha.Value
        ElseIf ComboBoxAdv2.Text = "7 DIAS" Then
            Dim fecha As DateTime = txtFecha.Value
            fecha = fecha.AddDays(7)
            txtFecVence.Value = fecha
        ElseIf ComboBoxAdv2.Text = "10 DIAS" Then
            Dim fecha As DateTime = txtFecha.Value
            fecha = fecha.AddDays(10)
            txtFecVence.Value = fecha
        ElseIf ComboBoxAdv2.Text = "15 DIAS" Then
            Dim fecha As DateTime = txtFecha.Value
            fecha = fecha.AddDays(15)
            txtFecVence.Value = fecha
        ElseIf ComboBoxAdv2.Text = "30 DIAS" Then
            Dim fecha As DateTime = txtFecha.Value
            fecha = fecha.AddDays(30)
            txtFecVence.Value = fecha
        ElseIf ComboBoxAdv2.Text = "33 DIAS" Then
            Dim fecha As DateTime = txtFecha.Value
            fecha = fecha.AddDays(33)
            txtFecVence.Value = fecha
        ElseIf ComboBoxAdv2.Text = "45 DIAS" Then
            Dim fecha As DateTime = txtFecha.Value
            fecha = fecha.AddDays(45)
            txtFecVence.Value = fecha
        ElseIf ComboBoxAdv2.Text = "55 DIAS" Then
            Dim fecha As DateTime = txtFecha.Value
            fecha = fecha.AddDays(55)
            txtFecVence.Value = fecha
        ElseIf ComboBoxAdv2.Text = "60 DIAS" Then
            Dim fecha As DateTime = txtFecha.Value
            fecha = fecha.AddDays(60)
            txtFecVence.Value = fecha
        ElseIf ComboBoxAdv2.Text = "90 DIAS" Then
            Dim fecha As DateTime = txtFecha.Value
            fecha = fecha.AddDays(90)
            txtFecVence.Value = fecha

        End If
    End Sub

    Private Sub cboMotivo_Click(sender As Object, e As EventArgs) Handles cboMotivo.Click

    End Sub

    Private Sub cboMotivo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMotivo.SelectedIndexChanged
        'If cboMotivo.Text = "CUENTAS POR PAGAR A LOS ACC(SOCIOS)DIRECT Y GERENTES" Then

        '    cuentaportipo("40")

        'End If
    End Sub

    'Public Sub cuentaportipo(ByVal padre As String)
    '    Dim cuentaSA As New cuentaplanContableEmpresaSA

    '    cboCuenta.DataSource = Nothing

    '    cboCuenta.DisplayMember = "descripcion"
    '    cboCuenta.ValueMember = "cuenta"
    '    cboCuenta.DataSource = cuentaSA.ListarCuentasPorPadreDescrip(Gempresas.IdEmpresaRuc, padre)
    '    'cboCuenta.SelectedValue = "7041"
    'End Sub



    Private Sub txtCodigoCuentaBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigoCuentaBuscar.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else
            Me.pcCuentas.Font = New Font("Segoe UI", 8)
            Me.pcCuentas.Size = New Size(337, 142)
            Me.pcCuentas.ParentControl = Me.txtCodigoCuentaBuscar
            Me.pcCuentas.ShowPopup(Point.Empty)
            Dim consulta = (From n In ListadoCuentasContables _
                     Where n.cuenta.StartsWith(txtCodigoCuentaBuscar.Text)).ToList

            lsvCuentasEncontradas.DataSource = consulta
            lsvCuentasEncontradas.DisplayMember = "descripcion"
            lsvCuentasEncontradas.ValueMember = "cuenta"

            e.Handled = True
        End If

        '  If Not Me.pcLikeCategoria.IsShowing() Then

        '   End If

        '    If Not Me.pcLikeCategoria.IsShowing() Then
        If e.KeyCode = Keys.Down Then
            Me.pcCuentas.Font = New Font("Segoe UI", 8)
            Me.pcCuentas.Size = New Size(337, 142)
            Me.pcCuentas.ParentControl = Me.txtCodigoCuentaBuscar
            Me.pcCuentas.ShowPopup(Point.Empty)
            lsvCuentasEncontradas.Focus()
        End If
        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.pcCuentas.IsShowing() Then
                Me.pcCuentas.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub txtCodigoCuentaBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtCodigoCuentaBuscar.TextChanged

    End Sub




    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click

        If txtCuentaSel.Text.Trim.Length > 0 Then
            'AddMovimiento()

            Me.dgvMovimientos.Table.AddNewRecord.SetCurrent()
            Me.dgvMovimientos.Table.AddNewRecord.BeginEdit()
            Me.dgvMovimientos.Table.CurrentRecord.SetValue("idSecuencia", 0)
            Me.dgvMovimientos.Table.CurrentRecord.SetValue("idmovimiento", 1)
            Me.dgvMovimientos.Table.CurrentRecord.SetValue("cuenta", txtCuentaSel.Tag)
            Me.dgvMovimientos.Table.CurrentRecord.SetValue("descripcion", txtCuentaSel.Text)
            Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipo", "D")
            Me.dgvMovimientos.Table.CurrentRecord.SetValue("monto", CDec(0.0))
            Me.dgvMovimientos.Table.CurrentRecord.SetValue("montoUSD", CDec(0.0))
            Me.dgvMovimientos.Table.CurrentRecord.SetValue("estado", "1")
            Me.dgvMovimientos.Table.CurrentRecord.SetValue("debe", CDec(0.0))
            Me.dgvMovimientos.Table.CurrentRecord.SetValue("haber", CDec(0.0))


            If Mid(txtCuentaSel.Tag, 1, 1) = "4" Then

                If txtCuentaSel.Tag = "422" Then
                    Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoPago", "C")
                ElseIf txtCuentaSel.Tag = "432" Then
                    Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoPago", "C")
                ElseIf Mid(txtCuentaSel.Tag, 1, 2) = "48" Then
                    Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoPago", "N")
                ElseIf Mid(txtCuentaSel.Tag, 1, 2) = "49" Then
                    Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoPago", "N")
                Else
                    Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoPago", "P")
                End If

            ElseIf txtCuentaSel.Tag = "122" Then
                Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoPago", "P")
            ElseIf txtCuentaSel.Tag = "132" Then
                Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoPago", "P")

            ElseIf Mid(txtCuentaSel.Tag, 1, 2) = "12" Then
                Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoPago", "C")
            ElseIf Mid(txtCuentaSel.Tag, 1, 2) = "13" Then
                Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoPago", "C")
            ElseIf Mid(txtCuentaSel.Tag, 1, 2) = "14" Then
                Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoPago", "C")
            ElseIf Mid(txtCuentaSel.Tag, 1, 2) = "16" Then
                Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoPago", "C")
            ElseIf Mid(txtCuentaSel.Tag, 1, 2) = "17" Then
                Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoPago", "C")
            Else

                Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoPago", "N")


            End If

            Me.dgvMovimientos.Table.AddNewRecord.EndEdit()

        End If

    End Sub

    Private Sub pcCuentas_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcCuentas.CloseUp
        'Me.Cursor = Cursors.WaitCursor
        'If e.PopupCloseType = PopupCloseType.Done Then
        '    If lsvCuentasEncontradas.SelectedItems.Count > 0 Then
        '        txtCuentaSel.Text = lsvCuentasEncontradas.Text
        '        txtCuentaSel.Tag = lsvCuentasEncontradas.SelectedValue

        '        If txtCuentaSel.Text.Trim.Length > 0 Then

        '            Dim val As String = txtCuentaSel.Text.Replace(txtCuentaSel.Tag.ToString, "")
        '            val = val.Replace("-", "")
        '            Me.dgvMovimientos.Table.AddNewRecord.SetCurrent()
        '            Me.dgvMovimientos.Table.AddNewRecord.BeginEdit()
        '            Me.dgvMovimientos.Table.CurrentRecord.SetValue("idSecuencia", 0)
        '            Me.dgvMovimientos.Table.CurrentRecord.SetValue("idmovimiento", 1)
        '            Me.dgvMovimientos.Table.CurrentRecord.SetValue("cuenta", txtCuentaSel.Tag)
        '            Me.dgvMovimientos.Table.CurrentRecord.SetValue("descripcion", val)
        '            Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipo", "D")
        '            Me.dgvMovimientos.Table.CurrentRecord.SetValue("monto", CDec(0.0))
        '            Me.dgvMovimientos.Table.CurrentRecord.SetValue("montome", CDec(0.0))
        '            Me.dgvMovimientos.Table.CurrentRecord.SetValue("estado", "1")
        '            Me.dgvMovimientos.Table.CurrentRecord.SetValue("debe", CDec(0.0))
        '            Me.dgvMovimientos.Table.CurrentRecord.SetValue("haber", CDec(0.0))


        '            If Mid(txtCuentaSel.Tag, 1, 1) = "4" Then

        '                If txtCuentaSel.Tag = "422" Then
        '                    Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoPago", "C")
        '                ElseIf txtCuentaSel.Tag = "432" Then
        '                    Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoPago", "C")
        '                ElseIf Mid(txtCuentaSel.Tag, 1, 2) = "48" Then
        '                    Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoPago", "N")
        '                ElseIf Mid(txtCuentaSel.Tag, 1, 2) = "49" Then
        '                    Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoPago", "N")
        '                Else
        '                    If txtProveedor.Tag > 0 Then
        '                        Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoPago", "P")
        '                    Else

        '                        MessageBox.Show("Debe Ingresar una Identificacion")
        '                        Exit Sub
        '                    End If
        '                End If

        '            ElseIf txtCuentaSel.Tag = "122" Then
        '                If txtProveedor.Tag > 0 Then
        '                    Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoPago", "P")
        '                Else

        '                    MessageBox.Show("Debe Ingresar una Identificacion")
        '                    Exit Sub
        '                End If
        '            ElseIf txtCuentaSel.Tag = "132" Then
        '                If txtProveedor.Tag > 0 Then
        '                    Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoPago", "P")
        '                Else

        '                    MessageBox.Show("Debe Ingresar una Identificacion")
        '                    Exit Sub
        '                End If

        '            ElseIf Mid(txtCuentaSel.Tag, 1, 2) = "12" Then
        '                Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoPago", "C")
        '            ElseIf Mid(txtCuentaSel.Tag, 1, 2) = "13" Then
        '                Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoPago", "C")
        '            ElseIf Mid(txtCuentaSel.Tag, 1, 2) = "14" Then
        '                Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoPago", "C")
        '            ElseIf Mid(txtCuentaSel.Tag, 1, 2) = "16" Then
        '                Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoPago", "C")
        '            ElseIf Mid(txtCuentaSel.Tag, 1, 2) = "17" Then
        '                Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoPago", "C")
        '            Else

        '                Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoPago", "N")


        '            End If

        '            Me.dgvMovimientos.Table.AddNewRecord.EndEdit()

        '        End If




        '    End If
        'End If
        ''Set focus back to textbox.
        'If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
        '    Me.txtCodigoCuentaBuscar.Focus()
        'End If
        'Me.Cursor = Cursors.Arrow



        '/////////
        Me.Cursor = Cursors.WaitCursor
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvCuentasEncontradas.SelectedItems.Count > 0 Then
                txtCuentaSel.Text = lsvCuentasEncontradas.Text
                txtCuentaSel.Tag = lsvCuentasEncontradas.SelectedValue


                If lstAsientos.SelectedItems.Count > 0 Then
                    If txtCuentaSel.Text.Trim.Length > 0 Then
                        AddMovimiento()
                    End If
                End If
            End If
        End If
        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtCodigoCuentaBuscar.Focus()
        End If
        Me.Cursor = Cursors.Arrow
        '//////////////////77

    End Sub

    Private Sub lsvCuentasEncontradas_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvCuentasEncontradas.MouseDoubleClick
        If lsvCuentasEncontradas.SelectedItems.Count > 0 Then
            Me.pcCuentas.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub lsvCuentasEncontradas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvCuentasEncontradas.SelectedIndexChanged

    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        'If Not IsNothing(Me.dgvMovimientos.Table.CurrentRecord) Then
        '    Me.dgvMovimientos.Table.CurrentRecord.Delete()
        '    'TotalTalesXcolumna()
        'End If

        If Not IsNothing(dgvMovimientos.Table.CurrentRecord) Then
            EliminarFilaMovimiento(New movimiento With {.idmovimiento = Val(dgvMovimientos.Table.CurrentRecord.GetValue("idmovimiento"))})
        End If
    End Sub

    Private Sub dgvMovimientos_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvMovimientos.TableControlCellClick

    End Sub

    Private Sub dgvMovimientos_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles dgvMovimientos.TableControlCurrentCellCloseDropDown
        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()
    End Sub

    Private Sub dgvMovimientos_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvMovimientos.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        If Not IsNothing(Me.dgvMovimientos.Table.CurrentRecord) Then
            Select Case ColIndex


                'Case 4

                '    If Me.dgvMovimientos.Table.CurrentRecord.GetValue("tipo") = "D" Then
                '        Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoPago", "C")

                '    ElseIf Me.dgvMovimientos.Table.CurrentRecord.GetValue("tipo") = "H" Then
                '        Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoPago", "P")
                '    End If

                Case 5 ' cantidad

                    Dim montoMN As Decimal = CDec(0.0)
                    montoMN = Math.Round(CDec(Me.dgvMovimientos.Table.CurrentRecord.GetValue("monto")), 2)

                    If Me.dgvMovimientos.Table.CurrentRecord.GetValue("tipo") = "D" Then
                        Me.dgvMovimientos.Table.CurrentRecord.SetValue("debe", montoMN)
                        Me.dgvMovimientos.Table.CurrentRecord.SetValue("haber", CDec(0))
                        Me.dgvMovimientos.Table.CurrentRecord.SetValue("montoUSD", montoMN / TmpTipoCambio)

                        If Me.dgvMovimientos.Table.CurrentRecord.GetValue("tipoPago") = "N" Then
                        Else

                            Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoPago", "C")
                        End If
                    ElseIf Me.dgvMovimientos.Table.CurrentRecord.GetValue("tipo") = "H" Then
                        Me.dgvMovimientos.Table.CurrentRecord.SetValue("haber", montoMN)
                        Me.dgvMovimientos.Table.CurrentRecord.SetValue("debe", CDec(0))
                        Me.dgvMovimientos.Table.CurrentRecord.SetValue("montoUSD", montoMN / TmpTipoCambio)
                        If Me.dgvMovimientos.Table.CurrentRecord.GetValue("tipoPago") = "N" Then

                        Else
                            Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoPago", "P")
                        End If
                    End If
                Case 6
                    Dim montoME As Decimal = 0
                    Dim montoMN As Decimal = 0

                    Dim totalpago As Decimal = 0

                    montoMN = Math.Round(CDec(Me.dgvMovimientos.Table.CurrentRecord.GetValue("monto")), 2)
                    montoME = Math.Round(CDec(montoMN) / txtTipoCambio.Value, 2)
                    Me.dgvMovimientos.Table.CurrentRecord.SetValue("montoUSD", montoME)

                    If Me.dgvMovimientos.Table.CurrentRecord.GetValue("tipo") = "D" Then
                        Me.dgvMovimientos.Table.CurrentRecord.SetValue("debe", montoMN)
                        Me.dgvMovimientos.Table.CurrentRecord.SetValue("haber", CDec(0.0))
                    ElseIf Me.dgvMovimientos.Table.CurrentRecord.GetValue("tipo") = "H" Then
                        Me.dgvMovimientos.Table.CurrentRecord.SetValue("haber", montoMN)
                        Me.dgvMovimientos.Table.CurrentRecord.SetValue("debe", CDec(0.0))
                    End If




                    For Each r As Record In dgvMovimientos.Table.Records
                        If r.GetValue("tipo") = "H" Then


                            If r.GetValue("cuenta") = "422" Then

                            ElseIf r.GetValue("cuenta") = "432" Then

                            ElseIf r.GetValue("cuenta") = "48" Then

                            ElseIf r.GetValue("cuenta") = "49" Then

                            ElseIf r.GetValue("cuenta") = "122" Then

                                totalpago += r.GetValue("monto")

                            ElseIf r.GetValue("cuenta") = "132" Then

                                totalpago += r.GetValue("monto")

                            ElseIf Mid(r.GetValue("cuenta"), 1, 1) = "4" Then

                                totalpago += r.GetValue("monto")
                                'MessageBox.Show("paso 4")
                            End If

                        End If


                    Next

                    txtImporteMN.Value = totalpago
            End Select
        End If
    End Sub


    Private Sub txtFecha_ValueChanged(sender As Object, e As EventArgs) Handles txtFecha.ValueChanged
        If txtFecha.Value.Year = DateTime.Now.Year Then

        Else
            ' txtPeriodo.Value.Year = New DateTime(txtPeriodo.Year, txtPeriodo.Month, CInt(txtPeriodo.Text))


            'Dim fechaModo2 As DateTime = txtPeriodo.Value
            txtFecha.Value = New DateTime(DateTime.Now.Year, txtFecha.Value.Month, txtFecha.Value.Day)
        End If
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        AddAsiento()
    End Sub

    Private Sub lstAsientos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstAsientos.SelectedIndexChanged
        If lstAsientos.SelectedItems.Count > 0 Then

            Dim cod = lstAsientos.SelectedValue
            If IsNumeric(cod) Then
                GetListadoMovimientoByAsiento(New asiento With {.idAsiento = lstAsientos.SelectedValue})

                Dim consulta = (From n In ListaAsientos _
                               Where n.idAsiento = lstAsientos.SelectedValue).FirstOrDefault

                If Not IsNothing(consulta) Then
                    txtGlosaAsiento.Text = consulta.glosa
                End If

            End If

            'RegistrarMovimiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})
            'UbicarAsientoPorId(New asiento With {.idAsiento = lstAsiento.SelectedValue})
        End If
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        If lstAsientos.SelectedItems.Count > 0 Then
            EliminarAsientoByCodigo(New asiento With {.idAsiento = lstAsientos.SelectedValue})
        End If
    End Sub

    Private Sub ButtonAdv9_Click(sender As Object, e As EventArgs) Handles ButtonAdv9.Click
        If txtGlosaAsiento.Text.Trim.Length > 0 Then
            Dim consulta = (From n In ListaAsientos _
                       Where n.idAsiento = lstAsientos.SelectedValue).FirstOrDefault

            If Not IsNothing(consulta) Then
                consulta.glosa = txtGlosaAsiento.Text.Trim
            End If
        End If
    End Sub

 
    Private Sub cboMoneda_Click(sender As Object, e As EventArgs) Handles cboMoneda.Click

    End Sub

    Private Sub txtFecVence_ValueChanged(sender As Object, e As EventArgs) Handles txtFecVence.ValueChanged

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then


            Dim f As New frmSeleccionarEDT()
            f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            f.StartPosition = FormStartPosition.CenterParent
            f.WindowState = FormWindowState.Normal
            f.ShowDialog()
            If Not IsNothing(f.Tag) Then
                Dim c = CType(f.Tag, SeleccionCosto)
                'For Each rec As Record = dgvMovimientos.Table.CurrentRecord

                'For Each rec As SelectedRecord In dgvMovimientos.Table.SelectedRecords
                For Each rec As Record In dgvMovimientos.Table.Records

                    ' If rec.Record.GetValue("edt") = "" Then
                    If Mid(rec.GetValue("cuenta"), 1, 2) = "62" Then
                        rec.SetValue("idSubProyecto", c.idSubProyecto)
                        rec.SetValue("Subproyecto", c.SubProyecto)
                        rec.SetValue("idEDT", c.idEntregable)
                        rec.SetValue("edt", c.Entregable)
                        rec.SetValue("idCosto", c.idProyectoGeneral)
                        idCostoGeneral = c.idProyectoGeneral
                        rec.SetValue("NombreProyectoGeneral", c.ProyectoGeneral)
                        rec.SetValue("tipoCosto", c.TipoCosto)
                        rec.SetValue("idElemento", c.idElemento)
                        rec.SetValue("Elemento", c.ElementoCosto)
                        rec.SetValue("abrev", c.Abreviatura)
                        txtTieneCosto.Text = "S"
                    ElseIf Mid(rec.GetValue("cuenta"), 1, 2) = "63" Then
                        rec.SetValue("idSubProyecto", c.idSubProyecto)
                        rec.SetValue("Subproyecto", c.SubProyecto)
                        rec.SetValue("idEDT", c.idEntregable)
                        rec.SetValue("edt", c.Entregable)
                        rec.SetValue("idCosto", c.idProyectoGeneral)
                        idCostoGeneral = c.idProyectoGeneral
                        rec.SetValue("NombreProyectoGeneral", c.ProyectoGeneral)
                        rec.SetValue("tipoCosto", c.TipoCosto)
                        rec.SetValue("idElemento", c.idElemento)
                        rec.SetValue("Elemento", c.ElementoCosto)
                        rec.SetValue("abrev", c.Abreviatura)
                        txtTieneCosto.Text = "S"
                    ElseIf Mid(rec.GetValue("cuenta"), 1, 2) = "64" Then
                        rec.SetValue("idSubProyecto", c.idSubProyecto)
                        rec.SetValue("Subproyecto", c.SubProyecto)
                        rec.SetValue("idEDT", c.idEntregable)
                        rec.SetValue("edt", c.Entregable)
                        rec.SetValue("idCosto", c.idProyectoGeneral)
                        idCostoGeneral = c.idProyectoGeneral
                        rec.SetValue("NombreProyectoGeneral", c.ProyectoGeneral)
                        rec.SetValue("tipoCosto", c.TipoCosto)
                        rec.SetValue("idElemento", c.idElemento)
                        rec.SetValue("Elemento", c.ElementoCosto)
                        rec.SetValue("abrev", c.Abreviatura)
                        txtTieneCosto.Text = "S"
                    ElseIf Mid(rec.GetValue("cuenta"), 1, 2) = "65" Then
                        rec.SetValue("idSubProyecto", c.idSubProyecto)
                        rec.SetValue("Subproyecto", c.SubProyecto)
                        rec.SetValue("idEDT", c.idEntregable)
                        rec.SetValue("edt", c.Entregable)
                        rec.SetValue("idCosto", c.idProyectoGeneral)
                        idCostoGeneral = c.idProyectoGeneral
                        rec.SetValue("NombreProyectoGeneral", c.ProyectoGeneral)
                        rec.SetValue("tipoCosto", c.TipoCosto)
                        rec.SetValue("idElemento", c.idElemento)
                        rec.SetValue("Elemento", c.ElementoCosto)
                        rec.SetValue("abrev", c.Abreviatura)
                        txtTieneCosto.Text = "S"
                    ElseIf Mid(rec.GetValue("cuenta"), 1, 2) = "66" Then
                        rec.SetValue("idSubProyecto", c.idSubProyecto)
                        rec.SetValue("Subproyecto", c.SubProyecto)
                        rec.SetValue("idEDT", c.idEntregable)
                        rec.SetValue("edt", c.Entregable)
                        rec.SetValue("idCosto", c.idProyectoGeneral)
                        idCostoGeneral = c.idProyectoGeneral
                        rec.SetValue("NombreProyectoGeneral", c.ProyectoGeneral)
                        rec.SetValue("tipoCosto", c.TipoCosto)
                        rec.SetValue("idElemento", c.idElemento)
                        rec.SetValue("Elemento", c.ElementoCosto)
                        rec.SetValue("abrev", c.Abreviatura)
                        txtTieneCosto.Text = "S"
                    ElseIf Mid(rec.GetValue("cuenta"), 1, 2) = "67" Then
                        rec.SetValue("idSubProyecto", c.idSubProyecto)
                        rec.SetValue("Subproyecto", c.SubProyecto)
                        rec.SetValue("idEDT", c.idEntregable)
                        rec.SetValue("edt", c.Entregable)
                        rec.SetValue("idCosto", c.idProyectoGeneral)
                        idCostoGeneral = c.idProyectoGeneral
                        rec.SetValue("NombreProyectoGeneral", c.ProyectoGeneral)
                        rec.SetValue("tipoCosto", c.TipoCosto)
                        rec.SetValue("idElemento", c.idElemento)
                        rec.SetValue("Elemento", c.ElementoCosto)
                        rec.SetValue("abrev", c.Abreviatura)
                        txtTieneCosto.Text = "S"
                    ElseIf Mid(rec.GetValue("cuenta"), 1, 2) = "68" Then
                        rec.SetValue("idSubProyecto", c.idSubProyecto)
                        rec.SetValue("Subproyecto", c.SubProyecto)
                        rec.SetValue("idEDT", c.idEntregable)
                        rec.SetValue("edt", c.Entregable)
                        rec.SetValue("idCosto", c.idProyectoGeneral)
                        idCostoGeneral = c.idProyectoGeneral
                        rec.SetValue("NombreProyectoGeneral", c.ProyectoGeneral)
                        rec.SetValue("tipoCosto", c.TipoCosto)
                        rec.SetValue("idElemento", c.idElemento)
                        rec.SetValue("Elemento", c.ElementoCosto)
                        rec.SetValue("abrev", c.Abreviatura)
                        txtTieneCosto.Text = "S"
                    End If
                Next
            End If


            'Dim r As Record = dgvMovimientos.Table.CurrentRecord
            'If Not IsNothing(r) Then

            '    If Mid(r.GetValue("cuenta"), 1, 2) = "62" Then

            '        sdfsf()
            '        Select Case dgvMovimientos.Table.SelectedRecords.Count
            '            Case 1
            '                Dim codProy = r.GetValue("idCosto")

            '                If Not IsNothing(codProy) Then
            '                    If codProy.ToString.Trim.Length > 0 Then
            '                        Dim f As New frmSeleccionarEDT(CInt(r.GetValue("idCosto")))
            '                        f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            '                        f.StartPosition = FormStartPosition.CenterParent
            '                        f.WindowState = FormWindowState.Normal
            '                        f.ShowDialog()
            '                        If Not IsNothing(f.Tag) Then
            '                            Dim c = CType(f.Tag, SeleccionCosto)
            '                            r.SetValue("idSubProyecto", c.idSubProyecto)
            '                            r.SetValue("Subproyecto", c.SubProyecto)
            '                            r.SetValue("idEDT", c.idEDT)
            '                            r.SetValue("edt", c.EDT)
            '                            r.SetValue("idCosto", c.idProyectoGeneral)
            '                            idCostoGeneral = c.idProyectoGeneral
            '                            r.SetValue("NombreProyectoGeneral", c.ProyectoGeneral)
            '                            r.SetValue("tipoCosto", c.TipoCosto)
            '                            r.SetValue("idElemento", c.idElemento)
            '                            r.SetValue("Elemento", c.ElementoCosto)
            '                            r.SetValue("abrev", c.Abreviatura)
            '                        End If

            '                    Else

            '                        Dim f As New frmSeleccionarEDT()
            '                        f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            '                        f.StartPosition = FormStartPosition.CenterParent
            '                        f.WindowState = FormWindowState.Normal
            '                        f.ShowDialog()
            '                        If Not IsNothing(f.Tag) Then
            '                            Dim c = CType(f.Tag, SeleccionCosto)
            '                            r.SetValue("idSubProyecto", c.idSubProyecto)
            '                            r.SetValue("Subproyecto", c.SubProyecto)
            '                            r.SetValue("idEDT", c.idEDT)
            '                            r.SetValue("edt", c.EDT)
            '                            r.SetValue("idCosto", c.idProyectoGeneral)
            '                            idCostoGeneral = c.idProyectoGeneral
            '                            r.SetValue("NombreProyectoGeneral", c.ProyectoGeneral)
            '                            r.SetValue("tipoCosto", c.TipoCosto)
            '                            r.SetValue("idElemento", c.idElemento)
            '                            r.SetValue("Elemento", c.ElementoCosto)
            '                            r.SetValue("abrev", c.Abreviatura)
            '                        End If

            '                    End If
            '                Else
            '                    Dim f As New frmSeleccionarEDT()
            '                    f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            '                    f.StartPosition = FormStartPosition.CenterParent
            '                    f.WindowState = FormWindowState.Normal
            '                    f.ShowDialog()
            '                    If Not IsNothing(f.Tag) Then
            '                        Dim c = CType(f.Tag, SeleccionCosto)
            '                        r.SetValue("idSubProyecto", c.idSubProyecto)
            '                        r.SetValue("Subproyecto", c.SubProyecto)
            '                        r.SetValue("idEDT", c.idEDT)
            '                        r.SetValue("edt", c.EDT)
            '                        r.SetValue("idCosto", c.idProyectoGeneral)
            '                        idCostoGeneral = c.idProyectoGeneral
            '                        r.SetValue("NombreProyectoGeneral", c.ProyectoGeneral)
            '                        r.SetValue("tipoCosto", c.TipoCosto)
            '                        r.SetValue("idElemento", c.idElemento)
            '                        r.SetValue("Elemento", c.ElementoCosto)
            '                        r.SetValue("abrev", c.Abreviatura)
            '                    End If
            '                End If



            '            Case Else
            '                Dim f As New frmSeleccionarEDT()
            '                f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            '                f.StartPosition = FormStartPosition.CenterParent
            '                f.WindowState = FormWindowState.Normal
            '                f.ShowDialog()
            '                If Not IsNothing(f.Tag) Then
            '                    Dim c = CType(f.Tag, SeleccionCosto)
            '                    For Each rec As SelectedRecord In dgvMovimientos.Table.SelectedRecords
            '                        rec.Record.SetValue("idSubProyecto", c.idSubProyecto)
            '                        rec.Record.SetValue("Subproyecto", c.SubProyecto)
            '                        rec.Record.SetValue("idEDT", c.idEDT)
            '                        rec.Record.SetValue("edt", c.EDT)
            '                        rec.Record.SetValue("idCosto", c.idProyectoGeneral)
            '                        idCostoGeneral = c.idProyectoGeneral
            '                        rec.Record.SetValue("NombreProyectoGeneral", c.ProyectoGeneral)
            '                        rec.Record.SetValue("tipoCosto", c.TipoCosto)
            '                        rec.Record.SetValue("idElemento", c.idElemento)
            '                        rec.Record.SetValue("Elemento", c.ElementoCosto)
            '                        rec.Record.SetValue("abrev", c.Abreviatura)
            '                    Next
            '                End If
            '        End Select




            '    End If
            'End If


        End If
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        If chProv.Checked = True Then
            Dim f As New frmCrearENtidades
            f.CaptionLabels(0).Text = "Nuevo proveedor"
            f.strTipo = TIPO_ENTIDAD.PROVEEDOR
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            'f.tipoPersona(TIPO_ENTIDAD.PROVEEDOR)
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            If Not IsNothing(f.Tag) Then
                Dim c = CType(f.Tag, entidad)
                'ListadoProveedores.Add(c)
                txtProveedor.Text = c.nombreCompleto
                txtProveedor.Tag = c.idEntidad
                txtRuc.Text = c.nrodoc
                txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            End If

        ElseIf chCli.Checked = True Then

            Dim f As New frmCrearENtidades
            f.CaptionLabels(0).Text = "Nuevo cliente"
            f.strTipo = TIPO_ENTIDAD.CLIENTE
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            'f.tipoPersona(TIPO_ENTIDAD.PROVEEDOR)
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            If Not IsNothing(f.Tag) Then
                Dim c = CType(f.Tag, entidad)
                'ListadoProveedores.Add(c)
                txtProveedor.Text = c.nombreCompleto
                txtProveedor.Tag = c.idEntidad
                txtRuc.Text = c.nrodoc
                txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            End If

        ElseIf chTrab.Checked = True Then
            Dim f As New frmNuevoTrabajador
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If Not IsNothing(dgvMovimientos.Table.CurrentRecord) Then


            Dim cuentaP As String = dgvMovimientos.Table.CurrentRecord.GetValue("cuenta")

            If Mid(cuentaP, 1, 2) = "62" Or Mid(cuentaP, 1, 2) = "63" Or
                                Mid(cuentaP, 1, 2) = "64" Or Mid(cuentaP, 1, 2) = "65" Or
                                Mid(cuentaP, 1, 2) = "66" Or Mid(cuentaP, 1, 2) = "67" Or
                                Mid(cuentaP, 1, 2) = "68" Then




                Dim f As New frmSelectCosto()
                f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                f.StartPosition = FormStartPosition.CenterParent
                f.WindowState = FormWindowState.Normal
                f.ShowDialog()
                If Not IsNothing(f.Tag) Then
                    Dim c = CType(f.Tag, SeleccionCosto)

                    Me.dgvMovimientos.Table.CurrentRecord.SetValue("costeo", c.Entregable)
                    Me.dgvMovimientos.Table.CurrentRecord.SetValue("idCosto", c.idEntregable)
                    Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoCosto", "PC")

                End If

            Else
                MessageBox.Show("Solo se peude costear cuenta de la 61 a 68!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End If

        Else
            MessageBox.Show("No ha seleccionado los items!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub
End Class