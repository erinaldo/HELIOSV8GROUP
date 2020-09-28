Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports System.Xml

Public Class UCPagoVentaCompleto


#Region "Attributes"
    Public Property FormVentaPrincipal As FormVentaNueva
    Private listaActivas As List(Of cajaUsuario)
    Private listaCuentasGrid As List(Of estadosFinancierosConfiguracionPagos)
    Public m_xmld As Xml.XmlDocument

#End Region

#Region "Constructors"
    Public Sub New(FormVenta As FormVentaNueva)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormVentaPrincipal = FormVenta
        FormatoGridAvanzado(GridCompra, False, False, 9.0F)
        GetCajasActivas()
        FormatoGrid()
        GetUsuarioUnico()
    End Sub
#End Region

#Region "Methods"
    Private Sub FormatoGrid()
        For Each i In GridCompra.TableDescriptor.Columns
            i.AllowSort = False
            i.Appearance.AnyRecordFieldCell.TextColor = Color.Black
        Next
    End Sub

    Private Sub GetUsuarioUnico()
        ' If CheckUsuarioUnico.Checked = True Then
        Dim user = UsuariosList.Where(Function(o) o.IDUsuario = usuario.IDUsuario).SingleOrDefault
        If user IsNot Nothing Then
            TextCodigoVendedor.Text = user.codigo
            TextBoxExt1.Text = user.CustomAutenticacionUsuario.Alias
        End If
        'End If
    End Sub

    Private Sub GetUsuarioUnicoSel(CodigoUser As String)
        ' If CheckUsuarioUnico.Checked = True Then
        Dim user = UsuariosList.Where(Function(o) o.codigo = CodigoUser).SingleOrDefault
        If user IsNot Nothing Then
            TextCodigoVendedor.Text = user.codigo
            TextBoxExt1.Text = user.CustomAutenticacionUsuario.Alias
        Else
            TextCodigoVendedor.Text = String.Empty
            TextBoxExt1.Text = String.Empty
        End If
        'End If
    End Sub

    Public Function ValidarTipoPedido() As Integer

        Dim modPedido As Integer = 1
        m_xmld = New XmlDocument()
        m_xmld.Load("C:\SPKconfiguration.xml")
        Dim m_nodeAPI = m_xmld.SelectNodes("/spk/company/ordertype")
        For Each m_node In m_nodeAPI
            'Obtenemos el Elemento RUC
            Dim ApiCodigo = m_node.ChildNodes.Item(0).InnerText
            If ApiCodigo.ToString.Trim.Length > 0 Then
                modPedido = ApiCodigo
                Exit For
            End If
        Next

        Return modPedido



    End Function

    Sub GetCajasActivas()
        Try


            Dim UsuarioBE = New cajaUsuario
            Dim cajaUsuarioSA As New cajaUsuarioSA
            UsuarioBE.idEmpresa = Gempresas.IdEmpresaRuc
            UsuarioBE.idEstablecimiento = GEstableciento.IdEstablecimiento
            UsuarioBE.estadoCaja = "A"



            If ValidarTipoPedido() = 3 Then

                If GconfigCaja = "2" Then


                    Dim query As cajaUsuario

                    If usuario.tipoCaja = Tipo_Caja.ADMINISTRATIVO Then

                        query = (From i In ListaCajasActivas
                                 Where i.estadoCaja = "A" And i.tipoCaja = Tipo_Caja.GENERAL).SingleOrDefault

                    ElseIf usuario.tipoCaja = Tipo_Caja.PUNTO_DE_VENTA Then

                        query = (From i In ListaCajasActivas
                                 Where i.idPersona = usuario.IDUsuario And i.estadoCaja = "A" And i.IDRol = usuario.IDRol).SingleOrDefault

                    End If

                    If query IsNot Nothing Then

                        Dim ListCaja As New List(Of cajaUsuario)
                        ListCaja.Add(query)

                        ComboCaja.DataSource = ListCaja
                        ComboCaja.ValueMember = "idcajaUsuario" ' "IDUsuario"
                        ComboCaja.DisplayMember = "NombrePersona"
                    End If
                End If

            Else

            End If




            'If GconfigCaja = "2" Then


            '    Dim query As cajaUsuario

            '    If usuario.tipoCaja = Tipo_Caja.ADMINISTRATIVO Then

            '        query = (From i In ListaCajasActivas
            '                 Where i.estadoCaja = "A" And i.tipoCaja = Tipo_Caja.GENERAL).SingleOrDefault

            '    ElseIf usuario.tipoCaja = Tipo_Caja.PUNTO_DE_VENTA Then

            '        query = (From i In ListaCajasActivas
            '                 Where i.idPersona = usuario.IDUsuario And i.estadoCaja = "A" And i.IDRol = usuario.IDRol).SingleOrDefault

            '    End If

            '    If query IsNot Nothing Then

            '        Dim ListCaja As New List(Of cajaUsuario)
            '        ListCaja.Add(query)

            '        ComboCaja.DataSource = ListCaja
            '        ComboCaja.ValueMember = "idcajaUsuario" ' "IDUsuario"
            '        ComboCaja.DisplayMember = "NombrePersona"
            '    End If

            'Else
            '    listaActivas = cajaUsuarioSA.ListadoCajaXEstado(UsuarioBE)
            '    ComboCaja.DataSource = listaActivas
            '    ComboCaja.ValueMember = "idcajaUsuario" ' "IDUsuario"
            '    ComboCaja.DisplayMember = "NombrePersona"
            'End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub GetLoadGridCajas(idCaja As Integer)
        Dim dt As New DataTable
        Dim SA As New EstadosFinancierosConfiguracionPagosSA

        Dim listaCuentasEfectivoBancario As New List(Of estadosFinancierosConfiguracionPagos)

        With dt.Columns
            .Add("IDforma")
            .Add("forma")
            .Add("idCuenta")
            .Add("Cuenta")
            .Add("tipodoc")
            .Add("nrooper")
            .Add("codigoTarjeta")
            .Add("monto")
            .Add("action")
            .Add("iddocumento")
            .Add("montoME")
            .Add("tipocambio")
            .Add("moneda")
            .Add("tipoEntidad")
            .Add("idCajaUsuario")
            .Add("nameMoneda")
        End With

        listaCuentasGrid = SA.GetConfigurationPayCaja(New estadosFinancierosConfiguracionPagos With
                                                 {
                                                 .idEmpresa = Gempresas.IdEmpresaRuc,
                                                 .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                 .IDCaja = idCaja
                                                 })

        If usuario.tipoCaja = Tipo_Caja.PUNTO_DE_VENTA Then

            Dim consulta = (From i In listaCuentasGrid Where i.tipoCaja = "EP").ToList

            For Each i In consulta
                listaCuentasEfectivoBancario.Add(i)
            Next


            Dim cajaCentral = (From i In ListaCajasActivas Where i.tipoCaja = "GNR").SingleOrDefault


            If cajaCentral IsNot Nothing Then
                Dim listaCuentasGenerales = SA.GetConfigurationPayCaja(New estadosFinancierosConfiguracionPagos With
                                                 {
                                                 .idEmpresa = Gempresas.IdEmpresaRuc,
                                                 .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                 .IDCaja = cajaCentral.idcajaUsuario
                                                 })


                For Each i In From k In listaCuentasGenerales Where k.tipoCaja <> "EF"
                    listaCuentasEfectivoBancario.Add(i)
                Next


            End If





        ElseIf usuario.tipoCaja = Tipo_Caja.ADMINISTRATIVO Then

                listaCuentasEfectivoBancario = listaCuentasGrid


        End If




        For Each i In listaCuentasEfectivoBancario ' ListaCuentasFinancierasConfiguradas.Where(Function(o) o.IDFormaPago <> "9991").ToList

            Select Case FormVentaPrincipal.UCEstructuraCabeceraVentaV2.cboMoneda.SelectedValue
                Case "2"
                    'If i.FormaPago = "EFECTIVO" And CDec(FormVentaPrincipal.UCEstructuraCabeceraVentaV2.DigitalME.Value) > 0 Then
                    '    dt.Rows.Add(i.IDFormaPago, $"{i.FormaPago} - {If(i.moneda = "1", "Nuevo Sol", "Moneda extranjera")}", i.identidad, i.entidad, "VOUCHER", String.Empty, String.Empty, CDec(FormVentaPrincipal.UCEstructuraCabeceraVentaV2.DigitalME.Value), "", 0)
                    'Else
                    '    dt.Rows.Add(i.IDFormaPago, $"{i.FormaPago} - {If(i.moneda = "1", "Nuevo Sol", "Moneda extranjera")}", i.FormaPago, i.identidad, i.entidad, "VOUCHER", String.Empty, String.Empty, 0.0, "", 0)
                    'End If

                    If i.FormaPago = "EFECTIVO" And CDec(FormVentaPrincipal.UCEstructuraCabeceraVentaV2.DigitalME.Value) > 0 Then
                        'dt.Rows.Add(i.IDFormaPago, $"{i.FormaPago} - {If(i.moneda = "1", "Nuevo Sol", "Moneda extranjera")}", i.identidad, i.entidad, "VOUCHER", String.Empty, String.Empty, 0, "", 0, 0, 3, i.moneda, i.tipoCaja, i.IDCaja)
                        dt.Rows.Add(i.IDFormaPago, i.FormaPago, i.identidad, i.entidad, "VOUCHER", String.Empty, String.Empty, 0, "", 0, 0, 3, i.moneda, i.tipoCaja, i.IDCaja, If(i.moneda = "1", "SOLES", "DOLARES"))
                    Else
                        'dt.Rows.Add(i.IDFormaPago, $"{i.FormaPago} - {If(i.moneda = "1", "Nuevo Sol", "Moneda extranjera")}", i.identidad, i.entidad, "VOUCHER", String.Empty, String.Empty, 0.0, "", 0, 0, 3, i.moneda, i.tipoCaja, i.IDCaja)
                        dt.Rows.Add(i.IDFormaPago, i.FormaPago, i.identidad, i.entidad, "VOUCHER", String.Empty, String.Empty, 0.0, "", 0, 0, 3, i.moneda, i.tipoCaja, i.IDCaja, If(i.moneda = "1", "SOLES", "DOLARES"))
                    End If

                Case Else
                    If i.FormaPago = "EFECTIVO" And CDec(FormVentaPrincipal.UCEstructuraCabeceraVentaV2.txtTotalPagar.Value) > 0 Then
                        dt.Rows.Add(i.IDFormaPago,
                                    $"{i.FormaPago}", '- {If(i.moneda = "1", "Nuevo Sol", "Moneda extranjera")}
                                    i.identidad,
                                    i.entidad,
                                    "VOUCHER",
                                    String.Empty,
                                    String.Empty,
                                    If(i.moneda = "1", CDec(FormVentaPrincipal.UCEstructuraCabeceraVentaV2.txtTotalPagar.Value), 0),
                                    "",
                                    0,
                                    0,
                                    3,
                                    i.moneda, i.tipoCaja, i.IDCaja, If(i.moneda = "1", "SOLES", "DOLARES"))

                    Else
                        dt.Rows.Add(i.IDFormaPago,
                                   $"{i.FormaPago}", '- {If(i.moneda = "1", "Nuevo Sol", "Moneda extranjera")}
                                    i.identidad,
                                    i.entidad,
                                    "VOUCHER",
                                    String.Empty,
                                    String.Empty,
                                    0.0,
                                    "",
                                    0,
                                    0,
                                    3,
                                    i.moneda, i.tipoCaja, i.IDCaja, If(i.moneda = "1", "SOLES", "DOLARES"))
                    End If
            End Select

        Next
        GridCompra.DataSource = dt
    End Sub
#End Region

#Region "Events"
    Private Sub ComboCaja_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboCaja.SelectedValueChanged
        If IsNumeric(ComboCaja.SelectedValue) Then
            GetLoadGridCajas(Integer.Parse(ComboCaja.SelectedValue))
        End If
    End Sub

    Private Sub ComboCaja_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboCaja_Click_1(sender As Object, e As EventArgs) Handles ComboCaja.Click

    End Sub

    Private Sub GridCompra_TableControlCellClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles GridCompra.TableControlCellClick

    End Sub

    Public Function SumaPagos() As Decimal
        SumaPagos = 0
        For Each i In GridCompra.Table.Records
            'If i.GetValue("moneda") = "1" Then
            SumaPagos += CDec(i.GetValue("monto"))
            ' End If
        Next
        SumaPagos = SumaPagos
        TextPagado.DecimalValue = SumaPagos
        Return SumaPagos
    End Function

    Public Function SumaPagosME() As Decimal
        SumaPagosME = 0
        For Each i In GridCompra.Table.Records
            'If i.GetValue("moneda") = "2" Then
            SumaPagosME += CDec(i.GetValue("montoME"))
            ' End If
        Next
        SumaPagosME = SumaPagosME
        TextPagadoME.DecimalValue = SumaPagosME
        Return SumaPagosME
    End Function

    Private Sub GridCompra_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles GridCompra.TableControlCurrentCellEditingComplete
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'Try

        '    ' Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        '    Dim cc As GridCurrentCell = GridCompra.TableControl.CurrentCell
        '    cc.ConfirmChanges()
        '    If cc.Renderer IsNot Nothing Then

        '        If cc.ColIndex > -1 Then
        '            Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

        '            If style.TableCellIdentity.Column.Name = "monto" Then
        '                Dim pagos As Decimal = 0
        '                Select Case FormVentaPrincipal.UCEstructuraCabeceraVentaV2.cboMoneda.SelectedValue
        '                    Case "2"
        '                        Dim tipocambio = CDec(style.TableCellIdentity.Table.CurrentRecord.GetValue("tipocambio"))
        '                        Dim pagoCelSoles As Decimal = Math.Round(CDec(style.TableCellIdentity.Table.CurrentRecord.GetValue("monto")) / tipocambio, 2)
        '                        style.TableCellIdentity.Table.CurrentRecord.SetValue("montoME", pagoCelSoles)

        '                        pagos = SumaPagosME()

        '                        If pagos > CDec(FormVentaPrincipal.UCEstructuraCabeceraVentaV2.DigitalME.Value) Then
        '                            MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                            GridCompra.Table.CurrentRecord.SetValue("monto", 0)
        '                            GridCompra.Table.CurrentRecord.SetValue("montoME", 0)
        '                            TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - pagos
        '                            Exit Sub
        '                        End If

        '                    Case "1"

        '                        TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - pagos
        '                        style.TableCellIdentity.Table.CurrentRecord.SetValue("montoME", 0)

        '                        pagos = SumaPagos()

        '                        If pagos > TextCompraTotal.DecimalValue Then
        '                            MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                            GridCompra.Table.CurrentRecord.SetValue("monto", 0)
        '                            GridCompra.Table.CurrentRecord.SetValue("montoME", 0)
        '                            TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - pagos
        '                            Exit Sub
        '                        End If
        '                End Select




        '                ' style.TableCellIdentity.Table.CurrentRecord.SetValue("tipocambio", 0)


        '            ElseIf style.TableCellIdentity.Column.Name = "montoME" Then

        '                Dim pagos As Decimal = 0 'SumaPagosME()

        '                Dim tipocambio = CDec(style.TableCellIdentity.Table.CurrentRecord.GetValue("tipocambio"))
        '                Dim pagoCelSoles As Decimal = Math.Round(CDec(style.TableCellIdentity.Table.CurrentRecord.GetValue("montoME")) * tipocambio, 2)
        '                style.TableCellIdentity.Table.CurrentRecord.SetValue("monto", pagoCelSoles)

        '                Select Case FormVentaPrincipal.UCEstructuraCabeceraVentaV2.cboMoneda.SelectedValue
        '                    Case "2"
        '                        pagos = SumaPagosME()
        '                    Case "1"
        '                        pagos = SumaPagos()
        '                End Select

        '                TextSaldo.DecimalValue = TextCompraTotal.DecimalValue '- CDec(SumaPagosME())

        '                If pagos > TextCompraTotal.DecimalValue Then
        '                    MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                    GridCompra.Table.CurrentRecord.SetValue("montoME", 0)
        '                    GridCompra.Table.CurrentRecord.SetValue("monto", 0)
        '                    TextSaldo.DecimalValue = TextCompraTotal.DecimalValue '- CDec(SumaPagosME())
        '                    Exit Sub
        '                End If


        '            End If
        '        End If
        '    End If

        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Verificar montos del pago")
        'End Try





        '-------------------------------------------------------------------------------------------------------------------------------------------
        '-------------------------------------------------------------------------------------------------------------------------------------------
        '-------------------------------------------------------------------------------------------------------------------------------------------
        '-------------------------------------------------------------------------------------------------------------------------------------------
        '-------------------------------------------------------------------------------------------------------------------------------------------

        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Try
            ' Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
            Dim cc As GridCurrentCell = GridCompra.TableControl.CurrentCell
            cc.ConfirmChanges()
            If cc.Renderer IsNot Nothing Then

                If cc.ColIndex > -1 Then
                    Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

                    If style.TableCellIdentity.Column.Name = "monto" Then
                        Dim pagos As Decimal = 0
                        Select Case FormVentaPrincipal.UCEstructuraCabeceraVentaV2.cboMoneda.SelectedValue
                            Case "2"
                                Dim tipocambio = CDec(style.TableCellIdentity.Table.CurrentRecord.GetValue("tipocambio"))
                                Dim pagoCelSoles As Decimal = Math.Round(CDec(style.TableCellIdentity.Table.CurrentRecord.GetValue("monto")) / tipocambio, 2)
                                style.TableCellIdentity.Table.CurrentRecord.SetValue("montoME", pagoCelSoles)

                                pagos = SumaPagosME()

                                'TextSaldo.DecimalValue = TextCompraTotal.DecimalValue '- CDec(SumaPagosME())

                                If pagos > CDec(FormVentaPrincipal.UCEstructuraCabeceraVentaV2.DigitalME.Value) Then
                                    MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    GridCompra.Table.CurrentRecord.SetValue("montoME", 0)
                                    GridCompra.Table.CurrentRecord.SetValue("monto", 0)
                                    'TextSaldo.DecimalValue = TextCompraTotal.DecimalValue '- CDec(SumaPagosME())
                                    Exit Sub
                                End If

                            Case "1"

                                '  TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - pagos
                                'style.TableCellIdentity.Table.CurrentRecord.SetValue("abonadoME", 0)

                                pagos = SumaPagos()

                                'TextSaldo.DecimalValue = TextCompraTotal.DecimalValue '- CDec(SumaPagosME())

                                If pagos > CDec(FormVentaPrincipal.UCEstructuraCabeceraVentaV2.txtTotalPagar.Value) Then
                                    MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    GridCompra.Table.CurrentRecord.SetValue("montoME", 0)
                                    GridCompra.Table.CurrentRecord.SetValue("monto", 0)
                                    'TextSaldo.DecimalValue = TextCompraTotal.DecimalValue '- CDec(SumaPagosME())
                                    Exit Sub
                                End If
                        End Select

                        ' style.TableCellIdentity.Table.CurrentRecord.SetValue("tipocambio", 0)


                    ElseIf style.TableCellIdentity.Column.Name = "montoME" Then

                        If style.TableCellIdentity.Table.CurrentRecord IsNot Nothing Then
                            Dim pagos As Decimal = 0 'SumaPagosME()

                            Dim tipocambio = CDec(style.TableCellIdentity.Table.CurrentRecord.GetValue("tipocambio"))
                            Dim pagoCelSoles As Decimal = Math.Round(CDec(style.TableCellIdentity.Table.CurrentRecord.GetValue("montoME")) * tipocambio, 2)
                            style.TableCellIdentity.Table.CurrentRecord.SetValue("monto", pagoCelSoles)

                            Select Case FormVentaPrincipal.UCEstructuraCabeceraVentaV2.cboMoneda.SelectedValue
                                Case "2"
                                    pagos = SumaPagosME()

                                    'TextSaldo.DecimalValue = TextCompraTotal.DecimalValue '- CDec(SumaPagosME())

                                    If pagos > CDec(FormVentaPrincipal.UCEstructuraCabeceraVentaV2.DigitalME.Value) Then
                                        MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        GridCompra.Table.CurrentRecord.SetValue("montoME", 0)
                                        GridCompra.Table.CurrentRecord.SetValue("monto", 0)
                                        'TextSaldo.DecimalValue = TextCompraTotal.DecimalValue '- CDec(SumaPagosME())
                                        Exit Sub
                                    End If
                                Case "1"
                                    pagos = SumaPagos()

                                    'TextSaldo.DecimalValue = TextCompraTotal.DecimalValue '- CDec(SumaPagosME())

                                    If pagos > CDec(FormVentaPrincipal.UCEstructuraCabeceraVentaV2.txtTotalPagar.Value) Then
                                        MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        GridCompra.Table.CurrentRecord.SetValue("montoME", 0)
                                        GridCompra.Table.CurrentRecord.SetValue("monto", 0)
                                        '   TextSaldo.DecimalValue = TextCompraTotal.DecimalValue '- CDec(SumaPagosME())
                                        Exit Sub
                                    End If
                            End Select
                        End If

                        'TextSaldo.DecimalValue = TextCompraTotal.DecimalValue '- CDec(SumaPagosME())

                    ElseIf style.TableCellIdentity.Column.Name = "tipocambio" Then
                        Dim pagos As Decimal = 0
                        'Dim style As GridTableCellStyleInfo = e.TableControl.Model(cc.RowIndex, cc.ColIndex)
                        If style.TableCellIdentity.Table.CurrentRecord Is Nothing Then Exit Sub
                        Dim r = style.TableCellIdentity.Table.CurrentRecord
                        Select Case r.GetValue("moneda")
                            Case 1
                                Dim valorSoles = CDec(r.GetValue("monto"))
                                Dim valorTipoCambio As Decimal = cc.Renderer.ControlText
                                Dim valorDolares = 0 ' 
                                If valorTipoCambio > 0 Then
                                    valorDolares = Math.Round(valorSoles / valorTipoCambio, 2)
                                Else
                                    valorDolares = 0
                                End If
                                r.SetValue("montoME", valorDolares)

                                Select Case FormVentaPrincipal.UCEstructuraCabeceraVentaV2.cboMoneda.SelectedValue
                                    Case "2"
                                        pagos = SumaPagosME()

                                        'TextSaldo.DecimalValue = TextCompraTotal.DecimalValue '- CDec(SumaPagosME())

                                        If pagos > CDec(FormVentaPrincipal.UCEstructuraCabeceraVentaV2.DigitalME.Value) Then
                                            MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                            GridCompra.Table.CurrentRecord.SetValue("montoME", 0)
                                            GridCompra.Table.CurrentRecord.SetValue("monto", 0)
                                            '  TextSaldo.DecimalValue = TextCompraTotal.DecimalValue '- CDec(SumaPagosME())
                                            Exit Sub
                                        End If

                                    Case "1"
                                        pagos = SumaPagos()

                                        'TextSaldo.DecimalValue = TextCompraTotal.DecimalValue '- CDec(SumaPagosME())

                                        If pagos > CDec(FormVentaPrincipal.UCEstructuraCabeceraVentaV2.txtTotalPagar.Value) Then
                                            MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                            GridCompra.Table.CurrentRecord.SetValue("montoME", 0)
                                            GridCompra.Table.CurrentRecord.SetValue("monto", 0)
                                            'TextSaldo.DecimalValue = TextCompraTotal.DecimalValue '- CDec(SumaPagosME())
                                            Exit Sub
                                        End If
                                End Select

                            Case 2
                                Dim valorDolares = CDec(r.GetValue("montoME"))
                                Dim valorTipoCambio As Decimal = cc.Renderer.ControlText
                                Dim valorSoles As Decimal = 0

                                If valorTipoCambio > 0 Then
                                    valorSoles = Math.Round(valorDolares * valorTipoCambio, 2)
                                    r.SetValue("monto", valorSoles)
                                Else
                                    valorSoles = 0
                                    r.SetValue("monto", valorSoles)
                                End If

                                Select Case FormVentaPrincipal.UCEstructuraCabeceraVentaV2.cboMoneda.SelectedValue
                                    Case "2"
                                        pagos = SumaPagosME()

                                        'TextSaldo.DecimalValue = TextCompraTotal.DecimalValue '- CDec(SumaPagosME())

                                        If pagos > CDec(FormVentaPrincipal.UCEstructuraCabeceraVentaV2.DigitalME.Value) Then
                                            MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                            GridCompra.Table.CurrentRecord.SetValue("montoME", 0)
                                            GridCompra.Table.CurrentRecord.SetValue("monto", 0)
                                            'TextSaldo.DecimalValue = TextCompraTotal.DecimalValue '- CDec(SumaPagosME())
                                            Exit Sub
                                        End If

                                    Case "1"
                                        pagos = SumaPagos()

                                        '                                        TextSaldo.DecimalValue = TextCompraTotal.DecimalValue '- CDec(SumaPagosME())

                                        If pagos > CDec(FormVentaPrincipal.UCEstructuraCabeceraVentaV2.txtTotalPagar.Value) Then
                                            MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                            GridCompra.Table.CurrentRecord.SetValue("montoME", 0)
                                            GridCompra.Table.CurrentRecord.SetValue("monto", 0)
                                            '    TextSaldo.DecimalValue = TextCompraTotal.DecimalValue '- CDec(SumaPagosME())
                                            Exit Sub
                                        End If
                                End Select

                        End Select

                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Verificar montos del pago")
        End Try
    End Sub

    Private Sub TextCodigoVendedor_TextChanged(sender As Object, e As EventArgs) Handles TextCodigoVendedor.TextChanged

    End Sub

    Private Sub TextCodigoVendedor_KeyDown(sender As Object, e As KeyEventArgs) Handles TextCodigoVendedor.KeyDown
        If TextCodigoVendedor.Text.Trim.Length > 0 Then
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                GetUsuarioUnicoSel(TextCodigoVendedor.Text.Trim)
            End If
        End If
    End Sub

    Private Sub GridCompra_TableControlKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles GridCompra.TableControlKeyDown

        'Try

        '    Dim cc As GridCurrentCell = GridCompra.TableControl.CurrentCell
        '    If cc.RowIndex > -1 Then
        '        If e.Inner.KeyCode = Keys.Up Then
        '            If cc IsNot Nothing Then
        '                cc.ConfirmChanges()
        '                If cc.RowIndex = 2 Then
        '                    Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex, cc.ColIndex), GridTableCellStyleInfo)
        '                    Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
        '                    Dim idProducto As Decimal = Decimal.Parse(currenrecord.GetValue("monto"))

        '                    Dim pagos As Decimal = SumaPagos()

        '                    TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - CDec(SumaPagos())

        '                    If pagos > TextCompraTotal.DecimalValue Then
        '                        cc.Renderer.ControlText = 0
        '                        cc.Renderer.ControlValue = 0
        '                        'currenrecord.SetValue("monto", 0)
        '                        MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        '                        TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - CDec(SumaPagos())
        '                        Exit Sub
        '                    End If

        '                    'Dim pagos As Decimal = SumaPagos()

        '                    'TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - CDec(SumaPagos())

        '                    'If pagos > TextCompraTotal.DecimalValue Then
        '                    '    currenrecord.SetValue("monto", 0)
        '                    '    MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        '                    '    TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - CDec(SumaPagos())
        '                    '    Exit Sub
        '                    'End If

        '                Else
        '                    Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex, cc.ColIndex), GridTableCellStyleInfo)
        '                    Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
        '                    Dim idProducto As Decimal = Decimal.Parse(currenrecord.GetValue("monto"))
        '                    Dim pagos As Decimal = SumaPagos()

        '                    TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - CDec(SumaPagos())

        '                    If pagos > TextCompraTotal.DecimalValue Then
        '                        cc.Renderer.ControlText = 0
        '                        cc.Renderer.ControlValue = 0
        '                        'currenrecord.SetValue("monto", 0)
        '                        MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        '                        TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - CDec(SumaPagos())
        '                        Exit Sub
        '                    End If

        '                    'TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - CDec(SumaPagos())

        '                    'If pagos > TextCompraTotal.DecimalValue Then
        '                    '    currenrecord.SetValue("monto", 0)
        '                    '    MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        '                    '    TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - CDec(SumaPagos())
        '                    '    Exit Sub
        '                    'End If
        '                End If

        '            End If
        '        ElseIf e.Inner.KeyCode = Keys.Down Then
        '            If cc IsNot Nothing Then
        '                cc.ConfirmChanges()
        '                Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex, cc.ColIndex), GridTableCellStyleInfo)
        '                If style IsNot Nothing Then
        '                    ' Dim rows = dgvCompra.Table.Records.Count
        '                    If style.TableCellIdentity IsNot Nothing Then
        '                        Dim currenrecord = style.TableCellIdentity.DisplayElement.GetRecord()
        '                        If currenrecord IsNot Nothing Then
        '                            Dim idProducto As Decimal = Decimal.Parse(currenrecord.GetValue("monto"))

        '                            'currenrecord.SetValue("monto", 0)

        '                            Dim pagos As Decimal = SumaPagos()

        '                            TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - CDec(SumaPagos())

        '                            If pagos > TextCompraTotal.DecimalValue Then
        '                                cc.Renderer.ControlText = 0
        '                                cc.Renderer.ControlValue = 0
        '                                'currenrecord.SetValue("monto", 0)
        '                                MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        '                                TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - CDec(SumaPagos())
        '                                Exit Sub
        '                            End If
        '                        End If
        '                    End If

        '                End If

        '            End If

        '        Else
        '            cc.ConfirmChanges()
        '            Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex, cc.ColIndex), GridTableCellStyleInfo)
        '            Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
        '            Dim idProducto As Decimal = Decimal.Parse(currenrecord.GetValue("monto"))
        '            Dim pagos As Decimal = SumaPagos()

        '            TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - CDec(SumaPagos())

        '            If pagos > TextCompraTotal.DecimalValue Then
        '                cc.Renderer.ControlText = 0
        '                cc.Renderer.ControlValue = 0
        '                'currenrecord.SetValue("monto", 0)
        '                MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        '                TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - CDec(SumaPagos())
        '                Exit Sub
        '            End If


        '            'Dim pagos As Decimal = SumaPagos()

        '            'TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - CDec(SumaPagos())

        '            'If pagos > TextCompraTotal.DecimalValue Then

        '            '    MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        '            '    TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - CDec(SumaPagos())
        '            '    Exit Sub
        '            'End If
        '        End If
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try



    End Sub

    Private Sub TextTotalPagosCliente_TextChanged(sender As Object, e As EventArgs) Handles TextTotalPagosCliente.TextChanged
        If TextTotalPagosCliente.DecimalValue > 0 Then
            CalcularPagoDelCliente()
        Else
            LabelVueltoCliente.Text = "0.00"
        End If
    End Sub

    Private Sub CalcularPagoDelCliente()
        Dim totalPago As Decimal = TextTotalPagosCliente.DecimalValue
        Dim totalVenta As Decimal = TextCompraTotal.DecimalValue

        If totalVenta > totalPago Then
            LabelVueltoCliente.Text = "0.00"
            Exit Sub
        End If
        Dim vuelto As Decimal = totalPago - totalVenta
        LabelVueltoCliente.Text = vuelto.ToString("N2")
    End Sub

    Private Sub GridCompra_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles GridCompra.QueryCellStyleInfo
        If Not IsNothing(e.TableCellIdentity.Column) Then
            Dim el As Syncfusion.Grouping.Element = e.TableCellIdentity.DisplayElement


            If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "monto")) Then
                Dim moneda As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("moneda").ToString()

                If moneda IsNot Nothing Then
                    Select Case moneda
                        Case "1"
                            'e.Style.BackColor = Color.Yellow
                            'e.Style.TextColor = Color.Black
                            e.Style.ReadOnly = False
                            e.Style.BackColor = Color.FromArgb(255, 255, 128)
                        Case Else
                            e.Style.ReadOnly = True
                            e.Style.BackColor = Color.White
                    End Select
                End If

            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "montoME")) Then
                Dim moneda As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("moneda").ToString()

                If moneda IsNot Nothing Then
                    Select Case moneda
                        Case "2"
                            'e.Style.BackColor = Color.Yellow
                            'e.Style.TextColor = Color.Black
                            e.Style.ReadOnly = False
                            e.Style.BackColor = Color.FromArgb(255, 255, 128)
                        Case Else
                            e.Style.ReadOnly = True
                            e.Style.BackColor = Color.White
                    End Select
                End If
            End If
        End If
    End Sub

    Private Sub ComboCaja_DropDown(sender As Object, e As EventArgs) Handles ComboCaja.DropDown

    End Sub
#End Region

End Class
