Imports Helios.Cont.Business.Entity
Imports ContSA = Helios.Cont.WCFService.ServiceAccess
Imports SegSA = Helios.Seguridad.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Drawing
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Helios.Cont.WCFService.ServiceAccess
Public Class UCArqueoCaja

    Private listaMovimientos As List(Of documentoCaja)

#Region "Atributos"

    Public Property cajaResponsable As List(Of estadosFinancierosConfiguracionPagos)

#End Region

#Region "Constructor"

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        FormatoGridBlack(GridCajas, False)
        ' Add any initialization after the InitializeComponent() call.
        'FormatoGrid()
        'GradientPanel1.Visible = False
        TextAnio.DecimalValue = Date.Now.Year
        'GetCombosLoad()
    End Sub

#End Region

#Region "Metodos"

    Dim cajaPEn


    Public Sub ListaCajasResponsable()


        Dim dt As New DataTable
        dt.Columns.Add("idCaja")
        dt.Columns.Add("idEntidad")
        dt.Columns.Add("entidad")



        GridCajas.Table.Records.DeleteAll()


        For Each i In cajaResponsable

            dt.Rows.Add(i.IDCaja, i.identidad, i.entidad)

        Next
        GridCajas.DataSource = dt

    End Sub

    Public Sub EntregarDinero()
        Try

            If ListViewHistorialCajas.SelectedItems.Count > 0 Then

                Dim cajauser = Integer.Parse(ListViewHistorialCajas.SelectedItems(0).SubItems(0).Text)


                Dim sa As New DocumentoCajaSA
                Dim user As New cajaUsuario
                Dim idCierre As New Integer
                user.idcajaUsuario = cajauser
                idCierre = lblIdCierre.Text


                Dim userTransc As New documentoCaja
                userTransc.idRol = usuario.IDRol
                userTransc.IdUsuarioTransaccion = usuario.IDUsuario



                sa.ConfirmarEntregaDeDinero(idCierre, user, cajaResponsable, userTransc)
                LimpiarCaja()
                MessageBox.Show("Se confirmo Correctamente")

            End If
        Catch ex As Exception

        End Try

    End Sub

    Public Sub LimpiarCaja()
        ListViewHistorialCajas.Items.Clear()
        GridCajas.Table.Records.DeleteAll()

        LabelFecha.Text = "-"
        LabelFechaInicio.Text = "-"
        lblIdCierre.Text = 0
        LabelTotalSaldo.Text = "S/0.00"
        LabelTotalSaldoUSD.Text = "$0.00"
        TxtCajero.Text = ""
        TxtCajero.Tag = Nothing


    End Sub





    Private Sub GetCombosLoad()
        If UsuariosList IsNot Nothing Then


            Dim listauser1 = UsuariosList.ToList

            Dim ListCnResponsable = (From k In UsuariosList Where k.idUsuarioResponsable = usuario.IDUsuario).ToList

            'Dim listauser2 = UsuariosList.ToList
            ComboUsuarios.DataSource = ListCnResponsable
            ComboUsuarios.DisplayMember = "Full_Name"
            ComboUsuarios.ValueMember = "IDUsuario"

            Dim userLogeo = (From i In UsuariosList
                             Where i.IDUsuario = usuario.IDUsuario).FirstOrDefault


            If userLogeo IsNot Nothing Then
                'Dim listaUser As New List(Of Seguridad.Business.Entity.Usuario)
                'listaUser.Add(userLogeo)

                'ComboResponsable.DisplayMember = "Full_Name"
                'ComboResponsable.ValueMember = "IDUsuario"
                'ComboResponsable.DataSource = listaUser

                TxtResponsable.Tag = userLogeo.IDUsuario
                TxtResponsable.Text = userLogeo.Full_Name


                ResponsableCarga(userLogeo.IDUsuario)

            End If
            cboMesCompra.DataSource = General.ListaDeMeses()
            cboMesCompra.DisplayMember = "Mes"
            cboMesCompra.ValueMember = "Codigo"
            cboMesCompra.SelectedValue = String.Format("{0:00}", Date.Now.Month)
        End If
    End Sub

    Public Sub ResponsableCarga(idUsuario As Integer)


        Try


            cajaResponsable = New List(Of estadosFinancierosConfiguracionPagos)
            Dim SA As New EstadosFinancierosConfiguracionPagosSA



            'If ListViewHistorialCajas.SelectedItems.Count > 0 Then


            Dim cajaactiva = (From i In ListaCajasActivas
                              Where i.tipoCaja = Tipo_Caja.GENERAL And
                                         i.estadoCaja = "A" And i.idEmpresa = Gempresas.IdEmpresaRuc And i.idEstablecimiento = GEstableciento.IdEstablecimiento).SingleOrDefault



            'Dim cajauser = Integer.Parse(ListViewHistorialCajas.SelectedItems(0).SubItems(0).Text)

            If (Not IsNothing(cajaactiva)) Then

                cajaResponsable = SA.GetConfigurationPayCaja(New estadosFinancierosConfiguracionPagos With
                                                                     {
                                                                     .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                     .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                     .IDCaja = cajaactiva.idcajaUsuario
                                                                    })

                If cajaResponsable.Count > 0 Then

                    ListaCajasResponsable()
                End If
            End If
            'End If

        Catch ex As Exception

        End Try

    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Cursor = Cursors.WaitCursor


        If ComboUsuarios.Text.Trim.Length > 0 Then
            CajaUsuarioSelUsuario(Integer.Parse(ComboUsuarios.SelectedValue))
        Else
            MessageBox.Show("Seleccione un Cajero")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub CajaUsuarioSelUsuario(idPerson As Integer)
        Dim periodo = $"{String.Format("{0:00}", cboMesCompra.SelectedValue)}/{TextAnio.DecimalValue}"
        Dim cajaUsuarioSA As New ContSA.cajaUsuarioSA
        Dim listado = cajaUsuarioSA.CajaUsuarioPeriodoSinRecocimiento(New cajaUsuario With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                          .fechaRegistro = GetPeriodoConvertirToDate(periodo),
                                                          .idPersona = idPerson
                                                          }).OrderByDescending(Function(o) o.fechaRegistro).ToList


        ListViewHistorialCajas.Items.Clear()
        For Each i In listado
            Dim n As New ListViewItem(i.idcajaUsuario)
            n.SubItems.Add(i.fechaRegistro.GetValueOrDefault)
            n.SubItems.Add(i.fechaCierre.GetValueOrDefault)
            n.SubItems.Add(If(i.fechaCierre.HasValue, "CERRADO", "ABIERTO"))
            n.SubItems.Add("0.00")
            n.SubItems.Add("0.00")
            ListViewHistorialCajas.Items.Add(n)
        Next
        ListViewHistorialCajas.Refresh()
    End Sub

    Private Sub ComboResponsable_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboResponsable_SelectedValueChanged(sender As Object, e As EventArgs)

        'Try


        '    cajaResponsable = New List(Of estadosFinancierosConfiguracionPagos)
        '    Dim SA As New EstadosFinancierosConfiguracionPagosSA

        '    If ComboResponsable.SelectedValue IsNot Nothing Then

        '        If ListViewHistorialCajas.SelectedItems.Count > 0 Then


        '            Dim cajaactiva = (From i In ListaCajasActivas
        '                              Where i.idPersona = ComboResponsable.SelectedValue And
        '                                 i.estadoCaja = "A").SingleOrDefault



        '            'Dim cajauser = Integer.Parse(ListViewHistorialCajas.SelectedItems(0).SubItems(0).Text)

        '            cajaResponsable = SA.GetConfigurationPayCaja(New estadosFinancierosConfiguracionPagos With
        '                                                             {
        '                                                             .idEmpresa = Gempresas.IdEmpresaRuc,
        '                                                             .idEstablecimiento = GEstableciento.IdEstablecimiento,
        '                                                             .IDCaja = cajaactiva.idcajaUsuario
        '                                                             })


        '            If cajaResponsable.Count > 0 Then

        '                ListaCajasResponsable()
        '            End If

        '        End If





        '    End If

        '    'If ComboResponsable.Text.Trim.Length > 0 Then







        '    'End If
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click
        If cajaResponsable.Count > 0 Then
            EntregarDinero()
        Else
            MessageBox.Show("No tiene Caja Confirmada")
        End If

    End Sub

    Private Sub ListViewHistorialCajas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewHistorialCajas.SelectedIndexChanged

    End Sub

    Private Sub GetFondoInicio(idcajausuario As Integer)
        Dim cajaUsuarioSA As New cajaUsuarioDetalleSA

        Dim detalle = cajaUsuarioSA.ListaDetallePorCaja(idcajausuario)

        Dim IniSoles = (From i In detalle Where i.moneda = "1").ToList
        Dim IniDolares = (From i In detalle Where i.moneda = "2").ToList

        If IniSoles.Count > 0 Then
            'LabelFondoInicio.Text = detalle.Sum(Function(o) o.importeMN).GetValueOrDefault
            LabelFondoInicio.Text = IniSoles.Sum(Function(o) o.importeMN).GetValueOrDefault
        Else
            LabelFondoInicio.Text = "0.00"
        End If


        If IniDolares.Count > 0 Then
            'LabelFondoInicio.Text = detalle.Sum(Function(o) o.importeMN).GetValueOrDefault
            LabelFondoInicioUSD.Text = IniDolares.Sum(Function(o) o.importeME).GetValueOrDefault
        Else
            LabelFondoInicioUSD.Text = "0.00"
        End If


    End Sub

    Private Sub GetDetalleMovimientos(IdCajaUsuario As Integer, fecha As Date)
        Dim documentocajaSA As New ContSA.DocumentoCajaSA
        Dim tipoIngresos As New List(Of String)
        tipoIngresos.Add(TIPO_VENTA.VENTA_ELECTRONICA)
        tipoIngresos.Add(TIPO_VENTA.NOTA_DE_VENTA)
        tipoIngresos.Add("OEC")
        tipoIngresos.Add(MovimientoCaja.CobroCliente)
        tipoIngresos.Add(MovimientoCaja.Otras_Entradas_Especial)

        Dim egresos As New List(Of String)
        egresos.Add(MovimientoCaja.PagoProveedor)
        egresos.Add("OSC")

        Try
            ' listaMovimientos = documentocajaSA.GetMovimientosCajaCajero(
            'New Business.Entity.cajaUsuario With
            '{
            '.idcajaUsuario = IdCajaUsuario,
            '.idEmpresa = Gempresas.IdEmpresaRuc,
            '.idEstablecimiento = GEstableciento.IdEstablecimiento,
            '.fechaCierre = fecha
            '})


            'listaMovimientos = documentocajaSA.GetMovimientosCajaCajeroTipoMoneda(
            listaMovimientos = documentocajaSA.GetMovimientosEfectivoCajero(
           New Business.Entity.cajaUsuario With
           {
           .idcajaUsuario = IdCajaUsuario,
           .idEmpresa = Gempresas.IdEmpresaRuc,
           .idEstablecimiento = GEstableciento.IdEstablecimiento,
           .fechaCierre = fecha
           })


            If listaMovimientos IsNot Nothing Or listaMovimientos.Count > 0 Then
                Dim ingresosTotal = listaMovimientos.Where(Function(o) tipoIngresos.Contains(o.movimientoCaja) And o.moneda = "1").Sum(Function(o) o.montoSoles).GetValueOrDefault
                Dim ingresosTotalME = listaMovimientos.Where(Function(o) tipoIngresos.Contains(o.movimientoCaja) And o.moneda = "2").Sum(Function(o) o.montoUsd).GetValueOrDefault

                Dim EgresosTotal = listaMovimientos.Where(Function(o) egresos.Contains(o.movimientoCaja) And o.moneda = "1").Sum(Function(o) o.montoSoles).GetValueOrDefault
                Dim EgresosTotalME = listaMovimientos.Where(Function(o) egresos.Contains(o.movimientoCaja) And o.moneda = "2").Sum(Function(o) o.montoUsd).GetValueOrDefault

                LabelTotalVentas.Text = $"S/{CDec(ingresosTotal).ToString("N2")}"
                LabelTotalGastos.Text = $"S/{CDec(EgresosTotal).ToString("N2")}"

                LabelTotalVentasUSD.Text = $"${CDec(ingresosTotalME).ToString("N2")}"
                LabelTotalGastosUSD.Text = $"${CDec(EgresosTotalME).ToString("N2")}"

                Dim saldo = (CDec(LabelFondoInicio.Text) + ingresosTotal) - EgresosTotal
                Dim saldoME = (CDec(LabelFondoInicioUSD.Text) + ingresosTotalME) - EgresosTotalME
                LabelTotalSaldo.Text = $"S/{CDec(saldo).ToString("N2")}"
                LabelTotalSaldoUSD.Text = $"${CDec(saldoME).ToString("N2")}"

                'LabelReclamacionClientes.Text = "0.00"
            Else
                'lblventaElectronica.Text = "0.00"
                'lblventaNotas.Text = "0.00"
                'lblOtrasEntradasCaja.Text = "0.00"
                'lblPagosCobrados.Text = "0.00"
                'lblIngresoEspecial.Text = "0.00"
                'LabelPagoProveedor.Text = "0.00"
                'LabelOtrosEgresos.Text = "0.00"
                'LabelReclamacionClientes.Text = "0.00"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ListViewHistorialCajas_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListViewHistorialCajas.MouseDoubleClick
        Cursor = Cursors.WaitCursor
        If ListViewHistorialCajas.SelectedItems.Count > 0 Then
            Dim fecha = Date.Parse(ListViewHistorialCajas.SelectedItems(0).SubItems(1).Text)

            TxtCajero.Text = ComboUsuarios.Text
            TxtCajero.Tag = ComboUsuarios.SelectedValue

            LabelFecha.Text = ListViewHistorialCajas.SelectedItems(0).SubItems(2).Text
            LabelFechaInicio.Text = ListViewHistorialCajas.SelectedItems(0).SubItems(1).Text
            GetFondoInicio(Integer.Parse(ListViewHistorialCajas.SelectedItems(0).SubItems(0).Text))
            lblIdCierre.Text = ListViewHistorialCajas.SelectedItems(0).SubItems(0).Text
            GetDetalleMovimientos(Integer.Parse(ListViewHistorialCajas.SelectedItems(0).SubItems(0).Text), fecha)
            ' GetDetalleFujoGeneral()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub TxtResponsable_TextChanged(sender As Object, e As EventArgs) Handles TxtResponsable.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        GetCombosLoad()
    End Sub

#End Region

#Region "Formato GRID"
    'Private Sub FormatoGrid()
    '    Me.gridGroupingControl1.Appearance.ColumnHeaderCell.Interior = New BrushInfo(GradientStyle.Vertical, Color.Black, Color.Black)
    '    Me.gridGroupingControl1.TopLevelGroupOptions.ShowCaption = False
    '    Dim colorF As GridMetroColors = New GridMetroColors()
    '    colorF.HeaderColor.NormalColor = Color.Black
    '    colorF.HeaderColor.HoverColor = Color.Empty
    '    Me.gridGroupingControl1.SetMetroStyle(colorF)
    '    Me.gridGroupingControl1.AllowProportionalColumnSizing = True
    '    Me.gridGroupingControl1.DisplayVerticalLines = False
    '    Me.gridGroupingControl1.BrowseOnly = True
    '    Me.gridGroupingControl1.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
    '    Me.gridGroupingControl1.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
    '    Me.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
    '    Me.gridGroupingControl1.TableOptions.SelectionBackColor = Color.FromArgb(85, 170, 255)
    '    Me.gridGroupingControl1.TableOptions.ShowRowHeader = False
    '    Me.gridGroupingControl1.TableDescriptor.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(30, 30, 30))
    '    Dim captionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
    '    Me.gridGroupingControl1.Table.DefaultRecordRowHeight = 30
    '    Me.gridGroupingControl1.Table.DefaultColumnHeaderRowHeight = 35
    '    Me.gridGroupingControl1.Appearance.AnyCell.TextColor = Color.White
    '    Me.gridGroupingControl1.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
    '    Me.gridGroupingControl1.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
    '    Me.gridGroupingControl1.TableDescriptor.Appearance.AnyCell.Borders.Bottom = New GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, Color.FromArgb(25, 25, 25))
    '    Me.gridGroupingControl1.TableDescriptor.Appearance.AnyCell.Borders.Right = New GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, Color.FromArgb(25, 25, 25))
    '    Me.gridGroupingControl1.TableDescriptor.Appearance.AnyHeaderCell.Borders.Top = New GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, Color.FromArgb(25, 25, 25))
    '    Me.gridGroupingControl1.GridOfficeScrollBars = OfficeScrollBars.Metro
    '    Me.gridGroupingControl1.TableControl.MetroColorTable.ScrollerBackground = Color.FromArgb(45, 45, 45)
    '    Me.gridGroupingControl1.TableControl.MetroColorTable.ArrowNormal = Color.FromArgb(195, 195, 195)
    '    Me.gridGroupingControl1.TableControl.MetroColorTable.ArrowChecked = Color.FromArgb(94, 171, 222)
    '    Me.gridGroupingControl1.TableControl.MetroColorTable.ThumbNormal = Color.FromArgb(31, 31, 31)
    '    Me.gridGroupingControl1.TableControl.MetroColorTable.ThumbPushed = Color.FromArgb(94, 171, 222)
    '    Me.gridGroupingControl1.TableControl.HScrollBehavior = Syncfusion.Windows.Forms.Grid.GridScrollbarMode.Disabled
    'End Sub
#End Region

End Class
