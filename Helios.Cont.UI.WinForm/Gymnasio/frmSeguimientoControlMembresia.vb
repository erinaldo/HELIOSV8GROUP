Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Public Class frmSeguimientoControlMembresia
#Region "Attributes"
    Private dt As DataTable
    Protected Friend TablaSA As tablaDetalleSA
#End Region

#Region "Constructors"
    Public Sub New(iddocumento As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(dgvConsumo, True, False)
        LoadCombos()
        UbicarDocumentoMembresia(iddocumento)
    End Sub

#End Region

#Region "Methods"
    Private Function calculoDiasCongelados(TotalDiasCongelados As Integer) As List(Of String)
        Dim iniciooriginal = New Date(2017, 11, 22)
        ' Dim fechasDB = membresia_congelamientoSA.GetMaximoMinimoFechaCongelamiento(New membresia_congelamiento With {.idDocumento = Tag})

        Dim inicio = txtFechVcto.Value
        '  Dim TotalDiasCongelados = DateDiff(DateInterval.Day, incio, fin)
        '  TotalDiasCongelados = TotalDiasCongelados + 1
        Dim finaliza = txtFechVcto.Value.AddDays(TotalDiasCongelados - 1)
        Dim conteoSemana = 2
        Dim anio = inicio.Year
        Dim mes = inicio.Month
        Dim nuevoInicio
        Dim lista As New List(Of String)

        '   MsgBox(MonthName(inicio.Month))
        lista.Add(inicio)
        Do While True
            nuevoInicio = inicio
            inicio = inicio.AddDays(1)

            If inicio.Year = anio AndAlso inicio.Month = mes Then
                If conteoSemana = 7 Then
                    conteoSemana = 2
                    lista.Add(inicio)
                    lista.Add(inicio.AddDays(1))
                    inicio = inicio.AddDays(1)
                    TotalDiasCongelados -= 1
                Else
                    conteoSemana += 1

                End If

            Else
                lista.Add(inicio.AddDays(-1))
                '  If TotalDiasCongelados >= 7 Then
                lista.Add(inicio.AddDays(1 - 1))

                ' inicio = inicio.AddDays(1)
                '  End If

                conteoSemana = 2
                anio = inicio.Year
                mes = inicio.Month
                'MsgBox(MonthName(inicio.Month))
                'lista.Add(inicio)
            End If


            TotalDiasCongelados -= 1

            If TotalDiasCongelados <= 0 Then
                Exit Do
            End If
        Loop
        lista.Add(inicio.AddDays(-1))
        lista = lista.Distinct().ToList
        Dim c = lista.Count
        If c Mod 2 = 0 Then
            lista(lista.Count - 1) = finaliza
        Else
            lista.RemoveAt(lista.Count - 1)
            lista(lista.Count - 1) = finaliza
        End If
        Return lista
    End Function

    Private Sub LoadCombos()
        TablaSA = New tablaDetalleSA
        cboTipoDoc.DataSource = TablaSA.GetListaTablaDetalle(10, "1")
        cboTipoDoc.DisplayMember = "descripcion"
        cboTipoDoc.ValueMember = "codigoDetalle"

        cboPeriodicida.DataSource = TablaSA.GetListaTablaDetalle(505, "1")
        cboPeriodicida.DisplayMember = "descripcion"
        cboPeriodicida.ValueMember = "codigoDetalle"
    End Sub

    Private Sub UbicarDocumentoMembresia(iddocumento As Integer)
        Dim objDocumento = Entidadmembresia_GymSA.GetUbicarDocumentoMembresia(iddocumento)
        If objDocumento IsNot Nothing Then
            Tag = objDocumento.idDocumento
            txtNroDocCliente.Text = objDocumento.CustomEntidad.nrodoc
            txtCliente.Text = objDocumento.CustomEntidad.nombreCompleto
            txtFecha.Value = objDocumento.fechaRegistro
            cboTipoDoc.SelectedValue = objDocumento.tipodoc
            txtSerie.Text = objDocumento.serie
            txtNumero.Text = objDocumento.numero

            CaptionLabels(1).Text = "Consumo de membresías: " & txtSerie.Text & "-" & txtNumero.Text
            CaptionLabels(1).Size = New Size(300, 24)

            txtMembresia.Text = objDocumento.CustomMembresia.descripcion
            cboPeriodicida.SelectedValue = objDocumento.CustomMembresia.tipo.ToString
            txtValDuracion.Text = objDocumento.CustomMembresia.valorDuracion
            txtDuracion.Text = objDocumento.CustomMembresia.tipoDuracion
            txtValido.Value = objDocumento.CustomMembresia.fechafin
            txtInfoExtra.Text = objDocumento.CustomMembresia.detalle

            'Servicio Contractutal
            txtFechaInicio.Value = objDocumento.fechaInicio.Value
            txtFechVcto.Value = objDocumento.fechaVcto
            txtCongela_dia.Value = objDocumento.congela_dia
            lblMontoContactual.Text = Decimal.Parse(objDocumento.opGravado)
            '     Dim NumDiasDelMesInicio = DateTime.DaysInMonth(txtFechaInicio.Value.Year, txtFechaInicio.Value.Month) ' Número de dias del mes
            Dim TotalMes = DateDiff(DateInterval.Day, txtFechaInicio.Value, txtFechVcto.Value)
            TotalMes += 1
            lblDiasContratados.Text = TotalMes
            lblCostoXdia.Text = Decimal.Parse(lblMontoContactual.Text) / Decimal.Parse(lblDiasContratados.Text)
            calculoDGVConsumo()
        End If
    End Sub

    Sub calculoDGVConsumo()
        Dim DaysFreez As Integer = 0
        Dim totalDiasCongelados As Integer = 0
        Dim vctomesContra = txtFechVcto.Value.Month
        Dim vctoAnioContra = txtFechVcto.Value.Year
        Dim fechaINicio = txtFechaInicio.Value
        Dim fechaVcto = txtFechVcto.Value
        Dim saldoContractural = Decimal.Parse(lblMontoContactual.Text)
        'fechaVcto = fechaVcto.AddDays(txtCongela_dia.Value)

        Dim TotalMes = DateDiff(DateInterval.Month, fechaINicio, fechaVcto)

        dt = New DataTable
        dt.Columns.Add("periodo")
        dt.Columns.Add("rango")
        dt.Columns.Add("nrodias")
        dt.Columns.Add("periodo_contrac")
        dt.Columns.Add("consumoContractual")
        dt.Columns.Add("congelamiento")
        dt.Columns.Add("consumo")
        dt.Columns.Add("saldo")

        dt.Columns.Add("consumoactual")
        dt.Columns.Add("diascongelados")

        Dim DiasCongelados = membresia_congelamientoSA.GetCongelamientoByDocumento(Tag)

        'Dim valor As Integer = 0
        'For Each f In DiasCongelados
        '    valor += GetCalculoDiasFreezingNow(f.fechainicio, f.fechafin)
        'Next

        For i = 0 To TotalMes
            Dim numDiasMes = Date.DaysInMonth(fechaINicio.Year, fechaINicio.Month)
            If i = TotalMes Then
                'Dim diasDeUso = DateDiff(DateInterval.Day, fechaINicio, New Date(fechaINicio.Year, fechaINicio.Month, fechaVcto.Day))
                ''    ultimoSaldoPeriodo = numDiasMes - diasDeUso
                fechaVcto = fechaVcto.AddDays(-1)

                Dim montoCongelamiento = GetResultadoCongelamiento(New membresia_congelamiento With {.fechainicio = fechaINicio, .idDocumento = Tag})
                Dim ImporteCongelado = montoCongelamiento * Decimal.Parse(lblCostoXdia.Text)

                Dim TotalDias = DateDiff(DateInterval.Day, fechaINicio.Date, New Date(fechaINicio.Year, fechaINicio.Month, fechaVcto.Day))
                TotalDias = TotalDias + 1
                Dim ConsumoContractual = TotalDias * Decimal.Parse(lblCostoXdia.Text)
                Dim conusmoValorizado = ConsumoContractual - ImporteCongelado
                saldoContractural -= conusmoValorizado


                Dim diasUsados = DateDiff(DateInterval.Day, fechaINicio.Date, New Date(Date.Now.Year, Date.Now.Month, Date.Now.Day))
                diasUsados = diasUsados

                If diasUsados < 0 Then
                    diasUsados = 0
                End If

                totalDiasCongelados = 0
                For Each x In DiasCongelados
                    Dim diaInicio = x.fechainicio
                    Dim fechaLimite = x.fechafin
                    Do While True
                        If diaInicio.Value.Date = fechaLimite.Value.Date Then
                            'MsgBox(diaInicio)
                            If diaInicio.Value.Date.CompareTo(fechaINicio.Date) >= 0 AndAlso diaInicio.Value.Date.CompareTo(New Date(fechaINicio.Year, fechaINicio.Month, numDiasMes)) <= 0 Then
                                totalDiasCongelados += 1

                            Else
                                ' MessageBox.Show("Fuera del rango de congelamiento")
                            End If
                            Exit Do
                        End If
                        'MsgBox(diaInicio)
                        If diaInicio.Value.Date.CompareTo(fechaINicio.Date) >= 0 AndAlso diaInicio.Value.Date.CompareTo(New Date(fechaINicio.Year, fechaINicio.Month, numDiasMes)) <= 0 Then
                            totalDiasCongelados += 1
                        Else
                            ' MessageBox.Show("Fuera del rango de congelamiento")
                        End If
                        diaInicio = diaInicio.Value.AddDays(1)

                    Loop
                Next

                dt.Rows.Add(MonthName(fechaINicio.Month, True) & " -" & fechaINicio.Year,
                            fechaINicio & " Al " & New Date(fechaINicio.Year, fechaINicio.Month, fechaVcto.Day),
                            fechaVcto.Day,
                            TotalDias,
                            TotalDias * Decimal.Parse(lblCostoXdia.Text),
                            ImporteCongelado,
                            conusmoValorizado,
                            saldoContractural,
                            diasUsados,
                            totalDiasCongelados)

                'Dim n As New ListViewItem(MonthName(fechaINicio.Month, True))
                'n.SubItems.Add(fechaVcto.Day)
                'n.SubItems.Add(diasDeUso)
                'ListView2.Items.Add(n)

            Else
                'Dim diasDeUso = DateDiff(DateInterval.Day, fechaINicio, New Date(fechaINicio.Year, fechaINicio.Month, numDiasMes))
                'diasDeUso += 1

                Dim TotalDias = DateDiff(DateInterval.Day, fechaINicio.Date, New Date(fechaINicio.Year, fechaINicio.Month, numDiasMes))
                TotalDias = TotalDias + 1

                Dim montoCongelamiento = GetResultadoCongelamiento(New membresia_congelamiento With {.fechainicio = fechaINicio, .idDocumento = Tag})
                Dim ImporteCongelado = montoCongelamiento * Decimal.Parse(lblCostoXdia.Text)
                Dim ConsumoContractual = TotalDias * Decimal.Parse(lblCostoXdia.Text)
                Dim conusmoValorizado = ConsumoContractual - ImporteCongelado
                saldoContractural -= conusmoValorizado

                Dim diasUsados = DateDiff(DateInterval.Day, fechaINicio.Date, New Date(Date.Now.Year, Date.Now.Month, Date.Now.Day))
                diasUsados = diasUsados

                If diasUsados < 0 Then
                    diasUsados = 0
                End If

                totalDiasCongelados = 0
                For Each x In DiasCongelados
                    Dim diaInicio = x.fechainicio
                    Dim fechaLimite = x.fechafin
                    Do While True
                        If diaInicio.Value.Date = fechaLimite.Value.Date Then
                            'MsgBox(diaInicio)
                            If diaInicio.Value.Date.CompareTo(fechaINicio.Date) >= 0 AndAlso diaInicio.Value.Date.CompareTo(New Date(fechaINicio.Year, fechaINicio.Month, numDiasMes)) <= 0 Then
                                totalDiasCongelados += 1
                            Else
                                ' MessageBox.Show("Fuera del rango de congelamiento")
                            End If
                            Exit Do
                        End If
                        'MsgBox(diaInicio)
                        If diaInicio.Value.Date.CompareTo(fechaINicio.Date) >= 0 AndAlso diaInicio.Value.Date.CompareTo(New Date(fechaINicio.Year, fechaINicio.Month, numDiasMes)) <= 0 Then
                            totalDiasCongelados += 1
                        Else
                            ' MessageBox.Show("Fuera del rango de congelamiento")
                        End If
                        diaInicio = diaInicio.Value.AddDays(1)

                    Loop
                Next

                dt.Rows.Add(MonthName(fechaINicio.Month, True) & " -" & fechaINicio.Year,
                            fechaINicio.ToShortDateString & " Al " & New Date(fechaINicio.Year, fechaINicio.Month, numDiasMes),
                            fechaVcto.Day,
                            TotalDias,
                            TotalDias * Decimal.Parse(lblCostoXdia.Text),
                            ImporteCongelado,
                            conusmoValorizado,
                            saldoContractural,
                            diasUsados,
                            totalDiasCongelados)

                'Dim n As New ListViewItem(MonthName(fechaINicio.Month, True))
                'n.SubItems.Add(DateTime.DaysInMonth(fechaINicio.Year, fechaINicio.Month))
                'n.SubItems.Add(diasDeUso)
                'ListView2.Items.Add(n)

            End If
            fechaINicio = fechaINicio.AddMonths(1)
            fechaINicio = New Date(fechaINicio.Year, fechaINicio.Month, 1)
        Next
        dgvConsumo.DataSource = dt

        'Cálculo Dias congelados
        Dim listaCongelados = membresia_congelamientoSA.GetCongelamientoByDocumento(Tag)
        If listaCongelados.Count > 0 Then
            Dim NroDiasRecuperados = 0
            For Each t In listaCongelados
                NroDiasRecuperados += GetRangoFecha(t.fechainicio, t.fechafin)
            Next
            ' For Each i In listaCongelados
            Dim lista = calculoDiasCongelados(NroDiasRecuperados)
            If lista.Count > 0 Then
                For x As Integer = 0 To lista.Count - 1 Step 2
                    Dim TotalDias = DateDiff(DateInterval.Day, CDate(lista(x)), CDate(lista(x + 1)))
                    TotalDias = TotalDias + 1
                    saldoContractural -= TotalDias * Decimal.Parse(lblCostoXdia.Text)
                    dgvConsumo.Table.AddNewRecord.SetCurrent()
                    dgvConsumo.Table.AddNewRecord.BeginEdit()
                    dgvConsumo.Table.CurrentRecord.SetValue("periodo", ("(F)") & MonthName(CDate(lista(x)).Month, True) & "-" & CDate(lista(x)).Year)
                    dgvConsumo.Table.CurrentRecord.SetValue("rango", lista(x) & " Al " & lista(x + 1))
                    dgvConsumo.Table.CurrentRecord.SetValue("nrodias", 0)
                    dgvConsumo.Table.CurrentRecord.SetValue("periodo_contrac", TotalDias)
                    dgvConsumo.Table.CurrentRecord.SetValue("consumoContractual", 0)
                    dgvConsumo.Table.CurrentRecord.SetValue("congelamiento", 0)
                    dgvConsumo.Table.CurrentRecord.SetValue("consumo", TotalDias * Decimal.Parse(lblCostoXdia.Text))
                    dgvConsumo.Table.CurrentRecord.SetValue("saldo", saldoContractural)
                    dgvConsumo.Table.AddNewRecord.EndEdit()
                Next
            End If
        End If

        ' Next
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="inicioCompare">Fec inicio congelamiento</param>
    ''' <param name="finalizaCompare">Fec finaliza congelamiento</param>
    Private Function GetCalculoDiasFreezingNow(inicioCompare As Date, finalizaCompare As Date) As Integer
        Dim inicio = txtFechaInicio.Value
        Dim fechaActual = Date.Now

        Dim totaldias = DateDiff(DateInterval.Day, inicio.Date, fechaActual.Date)
        totaldias = totaldias + 1
        GetCalculoDiasFreezingNow = 0
        Do While True
            If inicio.Date = fechaActual.Date Then
                'MsgBox(diaInicio)
                If inicio.Date.CompareTo(inicioCompare.Date) >= 0 AndAlso inicio.Date.CompareTo(finalizaCompare) <= 0 Then
                    GetCalculoDiasFreezingNow += 1
                Else
                    ' MessageBox.Show("Fuera del rango de congelamiento")
                End If
                Exit Do
            End If

            If inicio.Date.CompareTo(inicioCompare.Date) >= 0 AndAlso inicio.Date.CompareTo(finalizaCompare) <= 0 Then
                GetCalculoDiasFreezingNow += 1
            Else
                ' MessageBox.Show("Fuera del rango de congelamiento")
            End If
            inicio = inicio.AddDays(1)
        Loop
    End Function

    Private Function GetResultadoCongelamiento(be As membresia_congelamiento) As Integer
        Dim diasRecuperados = 0
        For Each i In membresia_congelamientoSA.GetSumaCongelamientoByPeriodo(be)
            diasRecuperados += GetRangoFecha(i.fechainicio, i.fechafin)
        Next
        Return diasRecuperados
    End Function

    Private Function GetRangoFecha(fechainicio As Date?, fechafin As Date?) As Integer
        Dim t = DateDiff(DateInterval.Day, fechainicio.GetValueOrDefault, fechafin.GetValueOrDefault)
        t += 1
        Return t
    End Function

#End Region

#Region "Events"

#End Region
End Class