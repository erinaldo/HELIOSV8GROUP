Imports Helios.Cont.Business.Entity
Imports Syncfusion.Grouping
Imports Helios.General
Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion
Imports Syncfusion.Windows.Forms.Grid
Imports System.Runtime.Serialization
Imports Syncfusion.Windows.Forms
Public Class FormCronogramaPagos

#Region "Variables"
    Private ResumenPagos As List(Of documentoCaja)
    Public Property pagoAnticipo As documentoAnticipo
    Public Property Saldo As Decimal
    Public Property ventaSA As New documentoVentaAbarrotesSA
    Public Property ListaDetalleCompra As List(Of documentoventaAbarrotesDet)
    Public Property ventCabecera As documentoventaAbarrotes
    Public Property listaCronograma As List(Of Cronograma)
    Public Property ListadoFormasPago As List(Of estadosFinancierosConfiguracionPagos)

    Dim instance As New Printing.PrinterSettings
#End Region

#Region "Constructors"
    Public Sub New(idDocumento As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GetConfigInicio()
        GetpagosDetalle(idDocumento)
        LoadComboFechas()
        GetCajasSaldo()
        HistorialPagos(idDocumento)
        GetCronogramaPagos(idDocumento)
        GetDataPays()
    End Sub

    Private Sub GetCronogramaPagos(idDocumento As Integer)
        Dim pagoSA As New CronogramaSA
        Dim dt As New DataTable
        dt.Columns.Add("idCronograma")
        dt.Columns.Add("nrocuota")
        dt.Columns.Add("fechapago")
        dt.Columns.Add("moneda")
        dt.Columns.Add("montocuota")

        listaCronograma = pagoSA.GetListarCuotasDocumentoPagos(idDocumento).Where(Function(o) o.estado = "0").ToList

        For Each i In listaCronograma
            i.EstadoPago = "PN"
            i.GetSaldoPendiente = i.GetSaldoMN
            'i.CustomConfiguracionPagos = ListConfigurationPays
            i.CustomConfiguracionPagos = New List(Of estadosFinancierosConfiguracionPagos)
            For Each pay As estadosFinancierosConfiguracionPagos In ListConfigurationPays
                Dim cod = Guid.NewGuid
                pay.CodigoAlfa = cod.ToString

                i.CustomConfiguracionPagos.Add(New estadosFinancierosConfiguracionPagos With
                                               {
                                               .idConfiguracion = pay.idConfiguracion,
                                               .idEmpresa = pay.idEmpresa,
                                               .idEstablecimiento = pay.idEstablecimiento,
                                               .identidad = pay.identidad,
                                               .tipo = pay.tipo,
                                               .fecha = pay.fecha,
                                               .entidad = pay.entidad,
                                               .moneda = pay.moneda,
                                               .CodigoAlfa = pay.CodigoAlfa,
                                               .TipoEF = pay.TipoEF,
                                               .FormaPago = pay.FormaPago,
                                               .IDFormaPago = pay.IDFormaPago,
                                               .IDCaja = pay.IDCaja,
                                               .MontoCaja = pay.MontoCaja
                                               })
            Next

            dt.Rows.Add(i.idCronograma, i.nrocuota, i.fechaPago, i.moneda, i.GetSaldoMN.GetValueOrDefault)
        Next
        GridPagosResumen.DataSource = dt
    End Sub
#End Region

#Region "Methods"
    Private Sub HistorialPagos(iddoc As Integer)
        Dim cajaSA As New DocumentoCajaSA
        '   Dim dt As New DataTable

        'dt.Columns.Add("iddoc")
        'dt.Columns.Add("fecha")
        'dt.Columns.Add("tipodoc")
        'dt.Columns.Add("numerodoc")
        'dt.Columns.Add("formapago")
        'dt.Columns.Add("nrooper")
        'dt.Columns.Add("entidadfinanciera")
        'dt.Columns.Add("identidadfinanciera")
        'dt.Columns.Add("moneda")
        'dt.Columns.Add("tcambio")
        'dt.Columns.Add("importe")

        ResumenPagos = cajaSA.ListadoComprobaNtesXidPadre(iddoc)
        'For Each i In ResumenPagos
        '    dt.Rows.Add(
        '        i.idDocumento,
        '        i.fechaCobro,
        '        i.tipoDocPago,
        '        i.numeroDoc,
        '        i.formapago,
        '        i.numeroOperacion,
        '        i.NombreCaja, i.entidadFinanciera,
        '        i.moneda, i.tipoCambio,
        '        i.montoSoles)
        'Next
        'GridPagosResumen.DataSource = dt
    End Sub

    Sub GetCajasSaldo()


        Dim query As cajaUsuario

        If usuario.tipoCaja = Tipo_Caja.ADMINISTRATIVO Then

            query = (From i In ListaCajasActivas
                     Where i.estadoCaja = "A" And i.tipoCaja = Tipo_Caja.ADMINISTRATIVO).SingleOrDefault


            Dim pagoSA As New EstadosFinancierosConfiguracionPagosSA
            ListConfigurationPays = pagoSA.GetConfigurationPaySaldo(New estadosFinancierosConfiguracionPagos With
                    {
                    .idEmpresa = Gempresas.IdEmpresaRuc,
                    .idEstablecimiento = GEstableciento.IdEstablecimiento,
                    .fecha = DateTime.Now,
                    .IDCaja = query.idcajaUsuario
                    })




        ElseIf usuario.tipoCaja = Tipo_Caja.PUNTO_DE_VENTA Then



            query = (From i In ListaCajasActivas
                     Where i.idPersona = usuario.IDUsuario And i.estadoCaja = "A" And i.IDRol = usuario.IDRol).SingleOrDefault


            Dim pagoSA As New EstadosFinancierosConfiguracionPagosSA
            ListConfigurationPays = pagoSA.GetConfigurationPaySaldo(New estadosFinancierosConfiguracionPagos With
                    {
                    .idEmpresa = Gempresas.IdEmpresaRuc,
                    .idEstablecimiento = GEstableciento.IdEstablecimiento,
                    .fecha = DateTime.Now,
                    .IDCaja = query.idcajaUsuario
                    })

        End If























    End Sub


    Sub GetDataPays(IdCronograma As Integer)

        Dim dt As New DataTable
        dt.Columns.Add("idforma")
        dt.Columns.Add("cuenta")
        dt.Columns.Add("identidad")
        dt.Columns.Add("entidad")
        dt.Columns.Add("codigocontable")
        dt.Columns.Add("importe")
        dt.Columns.Add("saldo")
        dt.Columns.Add("nrooperacion")
        dt.Columns.Add("tipo")
        dt.Columns.Add("codigo")


        Dim obj = listaCronograma.Where(Function(o) o.idCronograma = IdCronograma).SingleOrDefault


        For Each i In obj.CustomConfiguracionPagos.ToList
            dt.Rows.Add(i.IDFormaPago, i.FormaPago, i.identidad, i.entidad, String.Empty, i.MontoAbonado.GetValueOrDefault, i.MontoCaja, String.Empty, "CA", i.CodigoAlfa)
        Next
        'Dim efectivo = ListConfigurationPays.Where(Function(o) o.tipo = "EF").SingleOrDefault

        'If efectivo IsNot Nothing Then
        '    dt.Rows.Add("EFECTIVO", efectivo.identidad, efectivo.entidad, String.Empty, 0)
        'Else
        '    'dt.Rows.Add("EFECTIVO", 0, String.Empty, String.Empty, 0)
        'End If

        'dt.Rows.Add("DEPOSITO", 0, String.Empty, String.Empty, 0)
        'dt.Rows.Add("TARJETA", 0, String.Empty, String.Empty, 0)
        'dt.Rows.Add("CHEQUE", 0, String.Empty, String.Empty, 0)
        'dt.Rows.Add("VALE", 0, String.Empty, String.Empty, 0)
        'dt.Rows.Add("COMPENSACION", 0, String.Empty, String.Empty, 0)

        GridPagos.DataSource = dt
    End Sub

    Sub GetDataPays()

        GetCajasSaldo()

        Dim dt As New DataTable
        dt.Columns.Add("idforma2")
        dt.Columns.Add("cuenta2")
        dt.Columns.Add("identidad2")
        dt.Columns.Add("entidad2")
        dt.Columns.Add("codigocontable2")
        dt.Columns.Add("importe2")
        dt.Columns.Add("saldo2")
        dt.Columns.Add("nrooperacion2")
        dt.Columns.Add("tipo2")

        ListadoFormasPago = ListConfigurationPays

        For Each i In ListadoFormasPago
            dt.Rows.Add(i.IDFormaPago, i.FormaPago, i.identidad, i.entidad, String.Empty, 0, i.MontoCaja, String.Empty, "CA")
        Next
        'Dim efectivo = ListConfigurationPays.Where(Function(o) o.tipo = "EF").SingleOrDefault

        'If efectivo IsNot Nothing Then
        '    dt.Rows.Add("EFECTIVO", efectivo.identidad, efectivo.entidad, String.Empty, 0)
        'Else
        '    'dt.Rows.Add("EFECTIVO", 0, String.Empty, String.Empty, 0)
        'End If

        'dt.Rows.Add("DEPOSITO", 0, String.Empty, String.Empty, 0)
        'dt.Rows.Add("TARJETA", 0, String.Empty, String.Empty, 0)
        'dt.Rows.Add("CHEQUE", 0, String.Empty, String.Empty, 0)
        'dt.Rows.Add("VALE", 0, String.Empty, String.Empty, 0)
        'dt.Rows.Add("COMPENSACION", 0, String.Empty, String.Empty, 0)

        GridPagoMasivo.DataSource = dt
    End Sub

    Private Sub LoadComboFechas()
        Dim empresaAnioSA As New empresaPeriodoSA

        cboAnio.DisplayMember = "periodo"
        cboAnio.ValueMember = "periodo"
        cboAnio.DataSource = empresaAnioSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
        cboAnio.Text = DateTime.Now.Year

        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.DataSource = ListaDeMeses()
        cboMesCompra.SelectedValue = String.Format("{0:00}", DateTime.Now.Month)

    End Sub

    Private Sub GetConfigInicio()
        'GridPagosResumen.TableModel.CellModels.Add("LinkLabelCell", New LinkLabelCellModel(GridPagosResumen.TableModel))
        FormatoGridAvanzado(GridPagosResumen, True, False, 9.0F)
        FormatoGridAvanzado(GridPagos, False, False, 9.0F)
        FormatoGridAvanzado(GridPagoMasivo, False, False, 9.0F)
        OrdenamientoGrid(GridPagosResumen, False)
        OrdenamientoGrid(GridPagos, False)
        OrdenamientoGrid(GridPagoMasivo, False)

        DigitalGauge2.OuterFrameGradientStartColor = Color.White
        DigitalGauge2.OuterFrameGradientEndColor = Color.White
        DigitalGauge2.ForeColor = Color.Black
        DigitalGauge2.FrameBorderColor = Color.Black

        DigitalPagos.OuterFrameGradientStartColor = Color.White
        DigitalPagos.OuterFrameGradientEndColor = Color.White
        DigitalPagos.ForeColor = Color.Purple
        DigitalGauge2.FrameBorderColor = Color.Purple

        DigitalSaldo.OuterFrameGradientStartColor = Color.White
        DigitalSaldo.OuterFrameGradientEndColor = Color.White
        DigitalSaldo.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        DigitalGauge2.FrameBorderColor = Color.FromKnownColor(KnownColor.HotTrack)

        Dim impresosaPredt As String = instance.PrinterName

        ComboImpresora.Items.Clear()
        For Each item As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            ComboImpresora.Items.Add(item.ToString)
        Next
        If ComboImpresora.Items.Count > 0 Then
            ComboImpresora.SelectedText = impresosaPredt
        End If
    End Sub

    Private Sub GetpagosDetalle(idDocumento As Integer)
        ventCabecera = ventaSA.GetVentaPorID(idDocumento)
        If ventCabecera Is Nothing Then
            Throw New Exception("No se encontró el documento de referencia")
        End If

        ListaDetalleCompra = ventaSA.GetCobrosByDocumento(
            New documentoventaAbarrotes With {
            .idEmpresa = Gempresas.IdEmpresaRuc,
            .idEstablecimiento = GEstableciento.IdEstablecimiento,
            .estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO,
            .idDocumento = idDocumento})

        If ListaDetalleCompra.Count <= 0 Then
            Throw New Exception("No se encontraron items para pagar")
        Else
            Saldo = ListaDetalleCompra.Sum(Function(o) o.importeMN).GetValueOrDefault
            DigitalGauge2.Text = Saldo
            DigitalGauge2.Value = Saldo

            DigitalPagos.Text = "0.00"
            DigitalPagos.Value = "0.00"

            DigitalSaldo.Text = "0.00"
            DigitalSaldo.Value = "0.00"
        End If
    End Sub

    Private Sub GridPagosResumen_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridPagosResumen.TableControlCellClick
        Dim r As Record = GridPagosResumen.Table.CurrentRecord
        If r IsNot Nothing Then
            GetDataPays(Integer.Parse(r.GetValue("idCronograma")))
        End If
    End Sub

    Private Sub GridPagos_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridPagos.TableControlCellClick

    End Sub

    Private Sub GridPagos_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles GridPagos.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex

        Dim cc As GridCurrentCell = GridPagos.TableControl.CurrentCell
        cc.ConfirmChanges()

        Try
            If Not IsNothing(cc) Then
                Select Case ColIndex
                    Case 2
                        Dim style3 As GridTableCellStyleInfo = e.TableControl.Model(cc.RowIndex, cc.ColIndex)
                        If style3.TableCellIdentity.Table.CurrentRecord Is Nothing Then Exit Sub
                        Dim r = style3.TableCellIdentity.Table.CurrentRecord
                        Dim montocuota As Decimal = CDec(GridPagosResumen.Table.CurrentRecord.GetValue("montocuota"))
                        If r.GetValue("tipo") = "VNCA" Or r.GetValue("tipo") = "VRC" Then
                            Dim saldocaja = CDec(r.GetValue("saldo"))

                            Dim text As String = cc.Renderer.ControlText
                            '-----------------------------------------------------------------------------------------------------------------------------

                            If text.Trim.Length > 0 Then
                                Dim value As Decimal = Convert.ToDecimal(text)
                                cc.Renderer.ControlValue = value

                                If value > saldocaja Then
                                    cc.Renderer.ControlValue = 0
                                    cc.ConfirmChanges()
                                    cc.EndEdit()
                                    Exit Sub
                                End If
                            End If
                        End If

                        Dim Cod As String = r.GetValue("codigo").ToString
                        Dim idCronograma = Integer.Parse(GridPagosResumen.Table.CurrentRecord.GetValue("idCronograma"))

                        Dim Item = listaCronograma.Where(Function(o) o.idCronograma = idCronograma).SingleOrDefault
                        Dim ItemPago = Item.CustomConfiguracionPagos.Where(Function(p) p.CodigoAlfa = Cod).SingleOrDefault

                        If CDec(cc.Renderer.ControlText) < 0 Then

                            ItemPago.MontoAbonado = 0
                            MessageBox.Show("El pago debe ser mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            GridPagos.Table.CurrentRecord.SetValue("importe", 0)
                            Dim pagos2 As Decimal = SumaPagos()
                            DigitalPagos.Text = pagos2
                            DigitalPagos.Value = pagos2

                            DigitalSaldo.Text = Saldo - pagos2
                            DigitalSaldo.Value = Saldo - pagos2
                            '  Dim pagos2 As Decimal = SumaPagos()
                            Exit Sub
                        End If

                        ItemPago.MontoAbonado = CDec(cc.Renderer.ControlText)

                        Dim pagosCronograma = SumaPagosCronograma(idCronograma)

                        Dim pagos As Decimal = SumaPagos()
                        DigitalPagos.Text = pagos
                        DigitalPagos.Value = pagos

                        DigitalSaldo.Text = Saldo - pagos
                        DigitalSaldo.Value = Saldo - pagos

                        If pagosCronograma > montocuota Then
                            ItemPago.MontoAbonado = 0
                            MessageBox.Show("El pago no debe exceder el valor permitido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            GridPagos.Table.CurrentRecord.SetValue("importe", 0)
                            Dim pagos2 As Decimal = SumaPagos()
                            DigitalPagos.Text = pagos2
                            DigitalPagos.Value = pagos2

                            DigitalSaldo.Text = Saldo - pagos2
                            DigitalSaldo.Value = Saldo - pagos2
                            '  Dim pagos2 As Decimal = SumaPagos()
                            Exit Sub
                        End If

                        If pagos > CDec(Saldo) Then
                            MessageBox.Show("El pago no debe exceder el valor permitido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            GridPagos.Table.CurrentRecord.SetValue("importe", 0)
                            Dim pagos2 As Decimal = SumaPagos()
                            DigitalPagos.Text = pagos2
                            DigitalPagos.Value = pagos2

                            DigitalSaldo.Text = Saldo - pagos2
                            DigitalSaldo.Value = Saldo - pagos2
                            Exit Sub
                        End If
                End Select
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Verificar montos del pago")
        End Try
    End Sub

    Private Function SumaPagosSolo() As Decimal
        Dim suma As Decimal = 0
        For Each i In GridPagoMasivo.Table.Records
            'If i.GetValue("importe") <= 0 Then
            '    Throw New Exception("El monto abonado debe sre mayor a cero")
            'End If
            suma += CDec(i.GetValue("importe2"))
        Next
        Return suma
    End Function

    Private Function SumaPagos() As Decimal
        Dim Pagos = Aggregate cro In listaCronograma
                    From pay In cro.CustomConfiguracionPagos
                    Into SumaTotal = Sum(pay.MontoAbonado)

        SumaPagos = Pagos.GetValueOrDefault
        'For Each i In GridPagos.Table.Records
        '    'If i.GetValue("importe") <= 0 Then
        '    '    Throw New Exception("El monto abonado debe sre mayor a cero")
        '    'End If
        '    SumaPagos += CDec(i.GetValue("importe"))
        'Next
        Return SumaPagos
    End Function

    Private Function SumaPagosCronograma(intIdCronograma As Integer) As Decimal
        Dim Pagos = (Aggregate cro In listaCronograma
                    From pay In cro.CustomConfiguracionPagos
                        Where cro.idCronograma = intIdCronograma
                    Into SumaTotal = Sum(pay.MontoAbonado))

        SumaPagosCronograma = Pagos.GetValueOrDefault
    End Function

    Private Function GetCodigoVendedor() As Helios.Seguridad.Business.Entity.Usuario
        GetCodigoVendedor = Nothing
        Dim f As New FormCodigoVendedor
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim c = CType(f.Tag, Helios.Seguridad.Business.Entity.Usuario)
            GetCodigoVendedor = c
        End If
    End Function

    Private Function GetConfiguracionUsuario(usuarioSel As Seguridad.Business.Entity.Usuario, cajaUsuario As cajaUsuario) As EnvioImpresionVendedorPernos
        Dim envio As EnvioImpresionVendedorPernos
        envio = New EnvioImpresionVendedorPernos With
            {
            .CodigoVendedor = usuarioSel.codigo,
            .IDCaja = cajaUsuario.idcajaUsuario,
            .IDVendedor = usuarioSel.IDUsuario,
            .print = True,
            .Nombreprint = String.Empty,
            .NombreCajero = usuarioSel.Full_Name,
            .EntidadFinanciera = 0,'ef.idestado,
            .EntidadFinancieraName = String.Empty
        }
        Return envio
    End Function

    Private Function GetAnticipoRec() As List(Of documentoAnticipo)
        GetAnticipoRec = New List(Of documentoAnticipo)
        For Each r As Record In GridPagos.Table.Records

            If r.GetValue("tipo") = "VNCA" Or r.GetValue("tipo") = "VRC" Then

                If CDec(r.GetValue("importe")) > 0 Then
                    GetAnticipoRec.Add(New documentoAnticipo With
                             {
                                .idDocumento = Integer.Parse(r.GetValue("identidad").ToString()),
                                .importeMN = Decimal.Parse(r.GetValue("importe")),
                                .tipoAnticipo = r.GetValue("tipo")
                                 })
                End If
            End If

        Next
    End Function

    Private Function GetPagosSolo() As List(Of documentoCaja)
        GetPagosSolo = New List(Of documentoCaja)
        For Each r As Record In GridPagoMasivo.Table.Records
            'If CDec(r.GetValue("importe")) <= 0 Then
            '    Throw New Exception("Debe indicar un importe mayor a cero")
            'End If
            Dim MontoPagado = CDec(r.GetValue("importe2"))
            If r.GetValue("tipo2") = "CA" Then
                If CDec(r.GetValue("importe2")) > 0 Then
                    Dim docCaja As New documentoCaja With
                             {
                                .IdEntidadFinanciera = Integer.Parse(r.GetValue("identidad2").ToString()),
                                .NomCajaOrigen = r.GetValue("entidad2"),
                                .montoSoles = Decimal.Parse(r.GetValue("importe2")),
                                .formapago = r.GetValue("idforma2"),
                                .numeroOperacion = r.GetValue("nrooperacion2"),
                                .glosa = "Pago cuota"
                             }

                    Dim ListadoPagosDocumentados = GetPagoCuotasByImporte(MontoPagado, docCaja)
                    GetPagosSolo.AddRange(ListadoPagosDocumentados)
                End If
            End If

        Next
    End Function

    Private Function GetPagoCuotasByImporte(montoPagado As Decimal, doc As documentoCaja) As List(Of documentoCaja)

        GetPagoCuotasByImporte = New List(Of documentoCaja)

        For Each c In listaCronograma

            If montoPagado <= 0 Then Exit Function


            If c.EstadoPago = "PN" Then
                Dim saldoCronograma = c.GetSaldoPendiente.GetValueOrDefault
                Dim saldoDisponible = c.GetSaldoPendiente - montoPagado


                Dim montoCobro As Decimal = 0
                If saldoDisponible < 0 Then
                    montoCobro = c.GetSaldoPendiente.GetValueOrDefault
                    c.EstadoPago = "DC"
                    c.GetSaldoPendiente = 0

                ElseIf saldoDisponible = 0 Then
                    montoCobro = c.GetSaldoPendiente.GetValueOrDefault
                    c.estado = "DC"
                    c.GetSaldoPendiente = 0
                ElseIf saldoDisponible > 0 Then
                    montoCobro = montoPagado
                    c.EstadoPago = "PN"
                    c.GetSaldoPendiente = saldoDisponible
                End If

                GetPagoCuotasByImporte.Add(New documentoCaja With
                                {
                                .idcosto = c.idCronograma,
                                .IdEntidadFinanciera = Integer.Parse(doc.IdEntidadFinanciera),
                                .NomCajaOrigen = doc.NomCajaOrigen,
                                .montoSoles = montoCobro,
                                .formapago = doc.formapago,
                                .numeroOperacion = doc.numeroOperacion,
                                .glosa = "Pago cuota " & c.nrocuota
                                })

                montoPagado = montoPagado - montoCobro
            End If

        Next
    End Function

    Private Function GetPagos() As List(Of documentoCaja)
        GetPagos = New List(Of documentoCaja)
        '  For Each r As Record In GridPagos.Table.Records
        'If CDec(r.GetValue("importe")) <= 0 Then
        '    Throw New Exception("Debe indicar un importe mayor a cero")
        'End If

        '  If r.GetValue("tipo") = "CA" Then

        Dim Pagos = From cro In listaCronograma
                    From pay In cro.CustomConfiguracionPagos
                    Select cro.nrocuota, cro.idCronograma, pay

        For Each i In Pagos
            If i.pay.MontoAbonado.GetValueOrDefault > 0 Then
                GetPagos.Add(New documentoCaja With
                                         {
                                         .idcosto = i.idCronograma,
                                         .IdEntidadFinanciera = i.pay.identidad,
                                         .NomCajaOrigen = i.pay.entidad,
                                         .montoSoles = i.pay.MontoAbonado,
                                         .formapago = i.pay.IDFormaPago,
                                         .numeroOperacion = i.pay.NumeroOperacion,
                                         .glosa = i.nrocuota
                                     })
            End If
        Next


        'If CDec(r.GetValue("importe")) > 0 Then
        '    GetPagos.Add(New documentoCaja With
        '             {
        '                .IdEntidadFinanciera = Integer.Parse(r.GetValue("identidad").ToString()),
        '                .NomCajaOrigen = r.GetValue("entidad"),
        '                .montoSoles = Decimal.Parse(r.GetValue("importe")),
        '                .formapago = r.GetValue("idforma"),
        '                .numeroOperacion = r.GetValue("nrooperacion")
        '             })
        'End If

        '  End If

        '  Next
    End Function

    Public Function RegistrarPagos(comp As Integer) As List(Of documentoCaja)
        RegistrarPagos = New List(Of documentoCaja)
        Try
            Dim pagos As Decimal = SumaPagos()
            If pagos > CDec(Saldo) Then
                MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Function
            ElseIf pagos <= 0 Then
                MessageBox.Show("El pago debe ser mayor cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Function
            End If

            If pagos < CDec(Saldo) Then
                If MessageBox.Show("El pago realizado es menor a la venta total, desea continuar ?", "Verificar pagos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    RegistrarPagos = GetPagos()

                    If RegistrarPagos.Count = 0 Then

                        '/si no hya compesancion
                        If comp = 0 Then
                            MessageBox.Show("Debe realizar al menos un pago", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Function

                        End If

                    End If

                    Return RegistrarPagos

                Else
                    Exit Function
                End If
            ElseIf pagos = CDec(Saldo) Then
                RegistrarPagos = GetPagos()
                If RegistrarPagos.Count = 0 Then
                    '/si no hya compesancion
                    If comp = 0 Then
                        MessageBox.Show("Debe realizar al menos un pago", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Function
                    End If
                End If
                Return RegistrarPagos

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Validar importe")
        End Try
    End Function

    Public Function RegistrarPagosSolo(comp As Integer) As List(Of documentoCaja)
        RegistrarPagosSolo = New List(Of documentoCaja)
        Try

            Dim pagos As Decimal = SumaPagosSolo()

            If pagos > CDec(Saldo) Then
                MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Function
            ElseIf pagos <= 0 Then
                MessageBox.Show("El pago debe ser mayor cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Function
            End If

            If pagos < CDec(Saldo) Then
                If MessageBox.Show("El pago realizado es menor a la venta total, desea continuar ?", "Verificar pagos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    RegistrarPagosSolo = GetPagosSolo()

                    If RegistrarPagosSolo.Count = 0 Then

                        '/si no hya compesancion
                        If comp = 0 Then
                            MessageBox.Show("Debe realizar al menos un pago", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Function

                        End If

                    End If

                    Return RegistrarPagosSolo

                Else
                    Exit Function
                End If
            ElseIf pagos = CDec(Saldo) Then
                RegistrarPagosSolo = GetPagosSolo()
                If RegistrarPagosSolo.Count = 0 Then
                    '/si no hya compesancion
                    If comp = 0 Then
                        MessageBox.Show("Debe realizar al menos un pago", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Function
                    End If
                End If
                Return RegistrarPagosSolo

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Validar importe")
        End Try
    End Function

    Public Function ListaPagosCajas(lista As List(Of documentoCaja), envio As EnvioImpresionVendedorPernos) As List(Of documento)
        Dim nDocumentoCaja As New documento
        Dim objCaja As New documentoCaja
        Dim ListaDoc As New List(Of documento)
        Dim fechaPago As New DateTime(cboAnio.Text, cboMesCompra.SelectedValue, TxtDia.Text, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        For Each i In lista

            nDocumentoCaja = New documento
            nDocumentoCaja.idDocumento = 0
            nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
            nDocumentoCaja.idCentroCosto = GEstableciento.IdEstablecimiento
            nDocumentoCaja.tipoDoc = "9903" ' cbotipoDocPago.SelectedValue
            nDocumentoCaja.fechaProceso = fechaPago
            nDocumentoCaja.nroDoc = i.numeroOperacion ' txtNumOper.Text
            nDocumentoCaja.idOrden = Nothing
            nDocumentoCaja.moneda = "1"

            nDocumentoCaja.idEntidad = ventCabecera.idCliente
            nDocumentoCaja.entidad = ventCabecera.NombreEntidad
            nDocumentoCaja.nrodocEntidad = ventCabecera.NroDocEntidad

            nDocumentoCaja.tipoEntidad = TIPO_ENTIDAD.CLIENTE
            nDocumentoCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
            nDocumentoCaja.usuarioActualizacion = envio.IDCaja ' usuario.IDUsuario
            nDocumentoCaja.fechaActualizacion = DateTime.Now

            'DOCUMENTO CAJA
            objCaja = New documentoCaja
            objCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
            objCaja.idDocumento = 0
            objCaja.periodo = GetPeriodo(fechaPago, True)
            objCaja.idEmpresa = Gempresas.IdEmpresaRuc
            objCaja.idEstablecimiento = GEstableciento.IdEstablecimiento
            objCaja.fechaProceso = fechaPago
            objCaja.fechaCobro = fechaPago
            objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
            objCaja.codigoProveedor = ventCabecera.idCliente
            objCaja.IdProveedor = ventCabecera.idCliente
            objCaja.idPersonal = ventCabecera.idCliente
            objCaja.TipoDocumentoPago = ventCabecera.tipoDocumento 'cbotipoDocPago.SelectedValue
            objCaja.codigoLibro = "1"
            objCaja.tipoDocPago = "9903"
            objCaja.formapago = i.formapago
            objCaja.NumeroDocumento = "-"
            objCaja.numeroOperacion = i.numeroOperacion
            objCaja.movimientoCaja = MovimientoCaja.CobroCliente 'TIPO_VENTA.VENTA_POS_DIRECTA,
            objCaja.montoSoles = Decimal.Parse(i.montoSoles)

            objCaja.moneda = "1"
            objCaja.tipoCambio = TmpTipoCambio
            objCaja.montoUsd = Decimal.Parse(objCaja.montoSoles / TmpTipoCambio)

            objCaja.estado = "1"
            objCaja.glosa = "Pago cuota nro. " & i.glosa
            objCaja.entregado = "SI"

            objCaja.idCajaUsuario = envio.IDCaja ' GFichaUsuarios.IdCajaUsuario
            objCaja.entidadFinanciera = i.IdEntidadFinanciera
            objCaja.NombreEntidad = i.NomCajaOrigen
            objCaja.idcosto = i.idcosto
            objCaja.usuarioModificacion = envio.IDCaja ' usuario.IDUsuario
            objCaja.fechaModificacion = DateTime.Now

            nDocumentoCaja.documentoCaja = objCaja
            nDocumentoCaja.documentoCaja.documentoCajaDetalle = GetDetallePago(objCaja, envio)
            '   asientoDocumento(nDocumentoCaja.documentoCaja)
            ListaDoc.Add(nDocumentoCaja)
        Next

        Return ListaDoc
    End Function

    Private Function GetDetallePago(objCaja As documentoCaja, envio As EnvioImpresionVendedorPernos) As List(Of documentoCajaDetalle)
        Dim montoPago = objCaja.montoSoles
        GetDetallePago = New List(Of documentoCajaDetalle)
        For Each i In ListaDetalleCompra
            If montoPago > 0 Then
                If i.MontoSaldo > 0 Then
                    If i.MontoSaldo > montoPago Then
                        Dim canUso = montoPago
                        i.MontoPago = canUso
                        i.estadoPago = i.ItemPendiente
                    ElseIf i.MontoSaldo = montoPago Then
                        i.MontoPago = montoPago
                        i.estadoPago = i.ItemSaldado
                    Else
                        Dim canUso = i.MontoSaldo
                        i.MontoPago = canUso
                        i.estadoPago = i.ItemSaldado
                    End If
                    montoPago -= i.MontoPago 'ImporteDisponible

                    '.codigoLote = Integer.Parse(i.codigoLote),

                    GetDetallePago.Add(New documentoCajaDetalle With
                                   {
                                   .fecha = Date.Now,
                                   .codigoLote = 0,
                                   .otroMN = 0,
                                   .idItem = i.idItem,
                                   .DetalleItem = i.nombreItem,
                                   .montoSoles = i.MontoPago,
                                   .montoUsd = FormatNumber(i.MontoPago / TmpTipoCambio, 2),
                                   .diferTipoCambio = TmpTipoCambio,
                                   .tipoCambioTransacc = TmpTipoCambio,
                                   .entregado = "SI",
                                   .idCajaUsuario = envio.IDCaja,' GFichaUsuarios.IdCajaUsuario,
                                   .usuarioModificacion = envio.IDCaja,'usuario.IDUsuario,
                                   .documentoAfectado = ventCabecera.idDocumento,
                                   .documentoAfectadodetalle = i.secuencia,
                                   .EstadoCobro = i.estadoPago,
                                   .fechaModificacion = DateTime.Now
                                   })
                    i.estadoPago = i.estadoPago
                    'Dim item = ventaDetalle.Where(Function(o) o.secuencia = i.secuencia).Single
                    'item.estadoPago = i.EstadoPagos
                End If
            End If
        Next
    End Function

    Private Function ListaPagosAntComp(lista As List(Of documentoAnticipo), envio As EnvioImpresionVendedorPernos) As List(Of documentoAnticipoConciliacion)
        Dim ListaDoc As New List(Of documentoAnticipoConciliacion)

        For Each i In lista
            ListaDoc.AddRange(GetDetallePagoAntComp(i, envio))
        Next
        Return ListaDoc
    End Function

    Private Function GetDetallePagoAntComp(objCaja As documentoAnticipo, envio As EnvioImpresionVendedorPernos) As List(Of documentoAnticipoConciliacion)
        Dim montoPago = objCaja.importeMN
        Dim tipoCon = ""
        Dim Operacion = ""
        GetDetallePagoAntComp = New List(Of documentoAnticipoConciliacion)
        For Each i In ListaDetalleCompra
            If montoPago > 0 Then
                If i.MontoSaldo > 0 Then
                    If i.MontoSaldo > montoPago Then
                        Dim canUso = montoPago
                        i.MontoPago = canUso
                        i.estadoPago = i.ItemPendiente
                    ElseIf i.MontoSaldo = montoPago Then
                        i.MontoPago = montoPago
                        i.estadoPago = i.ItemSaldado
                    Else
                        Dim canUso = i.MontoSaldo
                        i.MontoPago = canUso
                        i.estadoPago = i.ItemSaldado
                    End If
                    montoPago -= i.MontoPago 'ImporteDisponible

                    '.codigoLote = Integer.Parse(i.codigoLote),
                    If objCaja.tipoAnticipo = "VNCA" Then
                        tipoCon = "ANT"
                        Operacion = "9936"
                    ElseIf objCaja.tipoAnticipo = "VRC" Then
                        tipoCon = "REC"
                        Operacion = "9935"
                    End If

                    GetDetallePagoAntComp.Add(New documentoAnticipoConciliacion With
                                   {
                                   .idDocumento = objCaja.idDocumento,
                                   .fechaRegistro = DateTime.Now,
                                   .tipoOperacion = Operacion,'StatusTipoOperacion.COBRO_A_CLIENTES,
                                   .tipoConciliacion = tipoCon,
                                   .serie = "CMP",
                                   .tipoDocumento = "9912",
                                   .idItem = i.idItem,
                                   .detalle = i.DetalleItem,
                                   .importe = i.MontoPago,
                                   .idDetalle = i.secuencia,
                                   .idCajaUsuario = envio.IDCaja,' GFichaUsuarios.IdCajaUsuario,
                                   .usuarioActualizacion = envio.IDCaja, 'usuario.IDUsuario,
                                   .fechaActualizacion = DateTime.Now
                                   })
                    i.estadoPago = i.estadoPago
                    'Dim item = ventaDetalle.Where(Function(o) o.secuencia = i.secuencia).Single
                    'item.estadoPago = i.EstadoPagos
                End If
            End If
        Next
    End Function

    Public Sub imprimirTicketCxCobrar(ListaPagos As List(Of documento), Vendedor As Helios.Seguridad.Business.Entity.Usuario)
        Dim a As TicketFCxCobrar = New TicketFCxCobrar
        'a.HeaderImage = "C:\Users\MAYKOL\Documents\LogoEmpresa\LOGO ROYAL BRANDING.jpg"
        Dim gravMN As Decimal = 0
        Dim gravME As Decimal = 0
        Dim ExoMN As Decimal = 0
        Dim ExoME As Decimal = 0
        Dim InaMN As Decimal = 0
        Dim InaME As Decimal = 0
        Dim precioUnit As Decimal = 0
        Dim PrecioTotal As Decimal = 0


        Dim rucCliente As String = String.Empty
        a.tipoImagen = False
        'a.AnadirLineaEmpresa(objDatosGenrales.razonSocial)
        '' propietario
        'If ((objDatosGenrales.nombreCorto).Count > 0) Then
        '    a.AnadirLineaNombrePropietario("DE: " & objDatosGenrales.nombreCorto)
        'End If
        'a.HeaderImage = Image.FromFile("C:\Users\MAYKOL\Pictures\pernos.JPG")

        'Direccion de La empresa general

        a.tipoEncabezado = False
        a.AnadirLineaEmpresa(Gempresas.NomEmpresa)
        'a.AnadirLineaNombrePropietario("MAYKOL CHARLY SANCHEZ CORIS")



        'Dim nombreCliente As String
        'Dim rucCliente As String
        'Dim nombreCliente As String
        'Dim rucCliente As String

        'ruc
        a.TextoIzquierda("R.U.C.: " & Gempresas.IdEmpresaRuc)
        'direccion de la empresa
        'a.TextoIzquierda("Direccion Principal: " & "PRO.ANGARAES NRO. 399 (A 1CDRA ANTES ESTADIO HUANCAYO) JUNIN - HUANCAYO - HUANCAYO")
        'a.TextoIzquierda("Direccion Secundaria: " & objDatosGenrales.direccionSecudaria)
        'Telefono de la empresa
        'a.TextoIzquierda("TELF: " & "966557413")
        'a.TextoIzquierda("")

        rucCliente = ("NRO DOC.: " & ventCabecera.NroDocEntidad)

        a.AnadirLineaComprobante("PAGOS VARIOS")

        'a.AnadirLineaComprobante("C001 - 000000001")

        a.AnadirLineaCaracteresDatosGEnerales("",
                                              "",
                                              ventCabecera.NombreEntidad,
                                              "",
                                              "",
                                              rucCliente,
                                              "",
                                              "") ' JUNTAR TODO EN UNA LINEA
        a.AnadirLineasDatosFinales("")
        a.AnadirLineasDatosFinales("FECHA DOC REF.: " & ventCabecera.fechaDoc.Value)

        Dim tipodoc As String = String.Empty
        Select Case ventCabecera.tipoDocumento
            Case "01"
                tipodoc = "FACTURA ELECTRONICA"
            Case "03"
                tipodoc = "BOLETA ELECTRONICA"
            Case Else
                tipodoc = "NOTA"
        End Select

        a.AnadirLineasDatosFinales("DOC: REF.: " & tipodoc)
        a.AnadirLineasDatosFinales("SERIE - NUMERO: " & ventCabecera.serieVenta & "-" & ventCabecera.numeroVenta)
        a.AnadirLineasDatosFinales("CUOTA NUMERO: " & "-")
        a.AnadirLineasDatosFinales("VENCIMIENTO: " & "-")

        a.AnadirLineasDatosFinales("")
        a.AnadirLineasDatosFinales("MONTO RECIBIDO") 'MEDIO SIN LINEA

        For Each I In ListaPagos
            a.AnadirLineasDatosFinales(I.documentoCaja.NombreEntidad & ":   " & I.documentoCaja.montoSoles)
        Next

        a.AnadirLineasDatosFinales("")

        a.AnadirLineasDatosFinales("REFERENCIA") 'MEDIO SIN LINEA

        a.AnadirLineasDatosFinales("OBLIGACION INICIAL: " & ventCabecera.ImporteNacional)
        a.AnadirLineasDatosFinales("PAGOS REALIZADOS: " & ResumenPagos.Sum(Function(o) o.montoSoles).GetValueOrDefault + CDec(DigitalPagos.Text))
        a.AnadirLineasDatosFinales("SALDOS PENDIENTES: " & CDec(DigitalSaldo.Text))
        a.AnadirLineasDatosFinales("COBRADO POR: " & Vendedor.Full_Name)
        a.AnadirLineasDatosFinales("FECHA Y HORA: " & DateTime.Now)
        a.AnadirLineasDatosFinales("---------------------------------------------------------------------")
        a.ImprimeTicket(ComboImpresora.Text, 1)
        'Next

        'a.ImprimeTicket(imprimir)
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dim ndocumento As New documento
        Dim cajaSA As New DocumentoCajaSA
        Dim cajaUsuaroSA As New cajaUsuarioSA
        Try

            If TxtDia.Text.Trim.Length = 0 Then
                MessageBox.Show("Debe ingresar la fecha de cobro")
                TxtDia.Select()
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            Dim Vendedor = GetCodigoVendedor()
            If Vendedor Is Nothing Then
                Throw New Exception("Debe indicar el codigo del vendedor!")
            End If

            'Dim cajaActiva = ListaCajasActivas.Where(Function(o) o.idPersona = Vendedor.IDUsuario).SingleOrDefault

            Dim cajaActiva As cajaUsuario
            If usuario.tipoCaja = Tipo_Caja.ADMINISTRATIVO Then

                cajaActiva = (From i In ListaCajasActivas Where i.tipoCaja = Tipo_Caja.ADMINISTRATIVO And i.estadoCaja = "A").FirstOrDefault

            ElseIf usuario.tipoCaja = Tipo_Caja.PUNTO_DE_VENTA Then

                cajaActiva = (From i In ListaCajasActivas Where i.idPersona = usuario.IDUsuario And i.IDRol = usuario.IDRol).FirstOrDefault

            End If


            If cajaActiva Is Nothing Then
                Throw New Exception("no existe una caja activa, para " & Vendedor.Full_Name)
            End If

            Dim cajaUsuario = cajaUsuaroSA.UbicarCajaUsuarioPorID(cajaActiva.idcajaUsuario)
            If cajaUsuario Is Nothing Then
                Throw New Exception("no existe caja activa!")
            End If
            Dim envio = GetConfiguracionUsuario(Vendedor, cajaUsuario)
            Dim ant = GetAnticipoRec() 'RegistrarAnticipoRec()
            Dim c As List(Of documentoCaja)
            c = New List(Of documentoCaja)
            Select Case ToggleButton21.ToggleState
                Case ToggleButton2.ToggleButtonState.OFF
                    c = RegistrarPagos(ant.Count)
                Case ToggleButton2.ToggleButtonState.ON
                    c = RegistrarPagosSolo(ant.Count)
            End Select

            If c.Count > 0 Then
                ndocumento.documentoventaAbarrotes = New documentoventaAbarrotes
                Dim ListaPagos = ListaPagosCajas(c, envio)

                'dfgdfg

                Dim ListaCompAnt = ListaPagosAntComp(ant, envio)


                Dim SumaPagos As Decimal = 0
                For Each i In ListaPagos
                    SumaPagos += i.documentoCaja.montoSoles.GetValueOrDefault
                Next

                Dim SumaPagosAnt As Decimal = 0
                For Each i In ListaCompAnt
                    SumaPagos += i.importe.GetValueOrDefault
                Next

                If SumaPagos = Saldo Then
                    ndocumento.documentoventaAbarrotes.estadoCobro = TIPO_VENTA.PAGO.COBRADO
                Else
                    'ndocumento.documentoventaAbarrotes.terminos = "PARCIAL"
                    ndocumento.documentoventaAbarrotes.estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO
                End If
                ndocumento.idDocumento = ventCabecera.idDocumento
                'ndocumento.documentocompra.documentocompradetalle = ListaDetalleCompra
                ndocumento.ListaCustomDocumento = ListaPagos 'ListaPagosCajas(c)
                Dim PAGOS_GLOBAL = ListaPagos
                ndocumento.ListaDetalleAnticipos = ListaCompAnt
                ndocumento.IdDocumentoAfectado = ventCabecera.idDocumento
                cajaSA.PagoDocVentas(ndocumento)
                MessageBox.Show("Cobro realizado con éxito", "Hecho", MessageBoxButtons.OK)
                imprimirTicketCxCobrar(PAGOS_GLOBAL, Vendedor)
                Close()


            ElseIf ant.Count > 0 Then

                ndocumento.documentoventaAbarrotes = New documentoventaAbarrotes
                Dim SumaPagos As Decimal = 0

                Dim ListaCompAnt = ListaPagosAntComp(ant, envio)

                For Each i In ListaCompAnt
                    SumaPagos += i.importe.GetValueOrDefault
                Next

                If SumaPagos = Saldo Then
                    ndocumento.documentoventaAbarrotes.estadoCobro = TIPO_VENTA.PAGO.COBRADO
                Else
                    'ndocumento.documentoventaAbarrotes.terminos = "PARCIAL"
                    ndocumento.documentoventaAbarrotes.estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO
                End If

                ndocumento.idDocumento = ventCabecera.idDocumento
                ndocumento.ListaDetalleAnticipos = ListaCompAnt
                cajaSA.PagoCompensacionVentas(ndocumento)
                MessageBox.Show("Cobro realizado con éxito", "Hecho", MessageBoxButtons.OK)



                Close()
            Else
                Throw New Exception("Debe realizar el Cobro del comprobante")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Validación")
        End Try
    End Sub

    Private Sub TxtDia_TextChanged(sender As Object, e As EventArgs) Handles TxtDia.TextChanged

    End Sub

    Private Sub CboMesCompra_Click(sender As Object, e As EventArgs) Handles cboMesCompra.Click

    End Sub

    Private Sub cboMesCompra_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboMesCompra.SelectedValueChanged
        cboAnio_SelectedValueChanged(sender, e)
    End Sub

    Sub GetDiasMes(mes As Integer, anio As Integer)
        Dim days As Integer = System.DateTime.DaysInMonth(anio, mes)
        TxtDia.MaxValue = days
        TxtDia.MinValue = 1
    End Sub

    Private Sub cboAnio_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboAnio.SelectedValueChanged
        If cboAnio.Text.Trim.Length > 0 Then
            If Not IsNothing(cboMesCompra.SelectedValue) Then
                'txtPeriodo.Value = GetPeriodoConvertirToDate(cboMesCompra.SelectedValue & "/" & cboAnio.Text)
                If TxtDia.Text.Trim.Length > 0 Then
                    GetDiasMes(Integer.Parse(cboMesCompra.SelectedValue), cboAnio.Text)
                Else
                    GetDiasMes(Integer.Parse(cboMesCompra.SelectedValue), cboAnio.Text)
                    TxtDia.Clear()
                End If
                TxtDia_TextChanged(sender, e)
            End If
        End If
    End Sub

    Private Sub GridPagoMasivo_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridPagoMasivo.TableControlCellClick

    End Sub

    Private Sub GridPagoMasivo_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles GridPagoMasivo.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex

        Dim cc As GridCurrentCell = GridPagoMasivo.TableControl.CurrentCell
        cc.ConfirmChanges()

        Try
            If Not IsNothing(cc) Then
                Select Case ColIndex
                    Case 2
                        Dim style3 As GridTableCellStyleInfo = e.TableControl.Model(cc.RowIndex, cc.ColIndex)
                        If style3.TableCellIdentity.Table.CurrentRecord Is Nothing Then Exit Sub
                        Dim r = style3.TableCellIdentity.Table.CurrentRecord
                        If r.GetValue("tipo2") = "VNCA" Or r.GetValue("tipo2") = "VRC" Then
                            Dim saldocaja = CDec(r.GetValue("saldo2"))
                            Dim text As String = cc.Renderer.ControlText
                            If text.Trim.Length > 0 Then
                                Dim value As Decimal = Convert.ToDecimal(text)
                                cc.Renderer.ControlValue = value
                                If value > saldocaja Then
                                    cc.Renderer.ControlValue = 0
                                    cc.ConfirmChanges()
                                    cc.EndEdit()
                                    Exit Sub
                                End If
                            End If
                        End If


                        Dim pagos As Decimal = SumaPagosSolo()
                        DigitalPagos.Text = pagos
                        DigitalPagos.Value = pagos

                        DigitalSaldo.Text = Saldo - pagos
                        DigitalSaldo.Value = Saldo - pagos



                        If pagos > CDec(Saldo) Then
                            MessageBox.Show("El pago no debe exceder el valor permitido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            GridPagoMasivo.Table.CurrentRecord.SetValue("importe2", 0)
                            Dim pagos2 As Decimal = SumaPagosSolo()
                            DigitalPagos.Text = pagos2
                            DigitalPagos.Value = pagos2

                            DigitalSaldo.Text = Saldo - pagos2
                            DigitalSaldo.Value = Saldo - pagos2
                            Exit Sub
                        End If
                End Select
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Verificar montos del pago")
        End Try
    End Sub

    Private Sub ToggleButton21_Click(sender As Object, e As EventArgs) Handles ToggleButton21.Click

    End Sub

    Private Sub ToggleButton21_ButtonStateChanged(sender As Object, e As ToggleButton2.ToggleButtonStateEventArgs) Handles ToggleButton21.ButtonStateChanged
        If ToggleButton21.ToggleState = ToggleButton2.ToggleButtonState.OFF Then
            PanelPagoMasivo.Visible = True
            GradientPanel1.Visible = False

            For Each i In listaCronograma
                i.GetSaldoPendiente = i.GetSaldoMN
            Next

            For Each r In GridPagoMasivo.Table.Records
                r.SetValue("importe2", 0)
            Next

            Dim pagos As Decimal = SumaPagosSolo()
            DigitalPagos.Text = pagos
            DigitalPagos.Value = pagos

            DigitalSaldo.Text = Saldo - pagos
            DigitalSaldo.Value = Saldo - pagos

        ElseIf ToggleButton21.ToggleState = ToggleButton2.ToggleButtonState.ON Then
            GradientPanel1.Visible = True
            PanelPagoMasivo.Visible = False

            Dim pagos As Decimal = SumaPagosSolo()
            DigitalPagos.Text = pagos
            DigitalPagos.Value = pagos

            DigitalSaldo.Text = Saldo - pagos
            DigitalSaldo.Value = Saldo - pagos
        End If

    End Sub
#End Region

End Class