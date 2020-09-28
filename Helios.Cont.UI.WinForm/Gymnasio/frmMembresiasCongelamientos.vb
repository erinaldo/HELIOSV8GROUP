Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping

Public Class frmMembresiasCongelamientos
#Region "Attributes"
    Dim membresia_congelamiento As membresia_congelamiento
    Protected Friend dt As DataTable
    Protected TablaSA As tablaDetalleSA
    Private r As Record
#End Region

#Region "Constructors"
    Public Sub New(idDocumento As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(dgvCongelamiento, True, False)
        LoadCombos()
        UbicarDocumentoMembresia(idDocumento)
        GetCongelamientoByDocumento(idDocumento)
    End Sub
#End Region

#Region "Methods"
    Private Function GetDiasRangofecha(Inicio As Date, fin As Date)
        Dim TotalDiasCongelados = DateDiff(DateInterval.Day, Inicio, fin)
        TotalDiasCongelados += 1
        Return TotalDiasCongelados
    End Function


    Private Function calculo() As List(Of String)
        'Dim iniciooriginal = New Date(2017, 11, 22)
        Dim inicio = txtFechaDel.Value
        Dim finaliza = txtFechaHasta.Value
        Dim TotalDiasCongelados = DateDiff(DateInterval.Day, inicio, finaliza)
        TotalDiasCongelados = TotalDiasCongelados + 1
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

    Sub calculoDias()
        Dim TotalDias = DateDiff(DateInterval.Day, txtFechaDel.Value, txtFechaHasta.Value)
        txtDiasCongelados.Text = TotalDias + 1
        lblCostoCongela.Text = Decimal.Parse(lblCostoXdia.Text) * Decimal.Parse(txtDiasCongelados.Text)
    End Sub

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
            'Dim fechasDB = membresia_congelamientoSA.GetMaximoMinimoFechaCongelamiento(New membresia_congelamiento With {.idDocumento = objDocumento.idDocumento})


            Tag = objDocumento.idDocumento
            txtNroDocCliente.Text = objDocumento.CustomEntidad.nrodoc
            txtCliente.Text = objDocumento.CustomEntidad.nombreCompleto
            txtFecha.Value = objDocumento.fechaRegistro
            cboTipoDoc.SelectedValue = objDocumento.tipodoc
            txtSerie.Text = objDocumento.serie
            txtNumero.Text = objDocumento.numero
            txtMembresia.Text = objDocumento.CustomMembresia.descripcion
            cboPeriodicida.SelectedValue = objDocumento.CustomMembresia.tipo.ToString
            txtValDuracion.Text = objDocumento.CustomMembresia.valorDuracion
            txtDuracion.Text = objDocumento.CustomMembresia.tipoDuracion
            txtValido.Value = objDocumento.CustomMembresia.fechafin
            txtInfoExtra.Text = objDocumento.CustomMembresia.detalle

            'Servicio Contractutal
            txtFechaInicio.Value = objDocumento.fechaInicio.Value
            txtFechVcto.Value = objDocumento.fechaVcto
            txtFechaHasta.MaxValue = objDocumento.fechaVcto
            txtFechaDel.MaxValue = objDocumento.fechaVcto
            txtFechaDel.MinValue = objDocumento.fechaInicio.Value

            txtCongela_dia.Value = objDocumento.congela_dia
            lblMontoContactual.Text = Decimal.Parse(objDocumento.opGravado)
            '     Dim NumDiasDelMesInicio = DateTime.DaysInMonth(txtFechaInicio.Value.Year, txtFechaInicio.Value.Month) ' Número de dias del mes
            Dim TotalMes = DateDiff(DateInterval.Day, txtFechaInicio.Value, txtFechVcto.Value)
            TotalMes += 1
            lblDiasContratados.Text = TotalMes
            calculoDias()
            lblCostoXdia.Text = Decimal.Parse(lblMontoContactual.Text) / Decimal.Parse(lblDiasContratados.Text)
            txtFechaDel.Value = Date.Now
            txtFechaHasta.Value = Date.Now

            'Dim TotalDiasCongelados = DateDiff(DateInterval.Day, fechasDB.fechainicio.GetValueOrDefault, fechasDB.fechafin.GetValueOrDefault)
            'TotalDiasCongelados = TotalDiasCongelados + 1

        End If
    End Sub

    Private Sub GrabarCongelamiento()

        Dim inicio = txtFechaDel.Value
        Dim finaliza = txtFechaHasta.Value
        Dim TotalDiasCongelados = DateDiff(DateInterval.Year, inicio, finaliza)
        TotalDiasCongelados = TotalDiasCongelados + 1

        Do While True
            ' Get random number.
            Dim totalDiasDelMeInicio = Date.DaysInMonth(inicio.Year, inicio.Month)
            Dim diferenciaDiasUso = DateDiff(DateInterval.Year, inicio, New Date(inicio.Year, inicio.Month, totalDiasDelMeInicio))
            Dim disponible = diferenciaDiasUso + 1
            TotalDiasCongelados -= disponible

            inicio = inicio.AddDays(disponible)

            ' Exit loop if we have an even number.
            If TotalDiasCongelados <= 0 Then
                Exit Do
            End If
        Loop

        If finaliza > inicio Then

            If inicio.Year = finaliza.Year AndAlso inicio.Month = finaliza.Month Then

            Else
                'Hallando primera fecha
                Dim totalDiasDelMeInicio = Date.DaysInMonth(inicio.Year, inicio.Month)
                Dim diferencia = DateDiff(DateInterval.Year, inicio, New Date(inicio.Year, inicio.Month, totalDiasDelMeInicio))


            End If

        End If

        membresia_congelamiento = New membresia_congelamiento With
            {
            .idDocumento = Tag,
            .fecha = Date.Now,
            .fechainicio = txtFechaDel.Value,
            .fechafin = txtFechaHasta.Value,
            .costo = Decimal.Parse(lblCostoCongela.Text),
            .usuarioActualizacion = usuario.IDUsuario,
            .fechaActualizacion = Date.Now
        }

        membresia_congelamientoSA.GrabarCongelamiento(membresia_congelamiento)
        GetCongelamientoByDocumento(Integer.Parse(Tag))
    End Sub

    Private Sub GetCongelamientoByDocumento(idDocumento As Integer)
        dt = New DataTable
        dt.Columns.Add("fecha")
        dt.Columns.Add("fechaInicio")
        dt.Columns.Add("fechaFin")
        dt.Columns.Add("Dias")
        dt.Columns.Add("costo")
        dt.Columns.Add("idcongelamiento")
        Dim NroDiasRecuperados = 0
        For Each i In membresia_congelamientoSA.GetCongelamientoByDocumento(idDocumento)
            NroDiasRecuperados += GetRangoFecha(i.fechainicio, i.fechafin)
            dt.Rows.Add(i.fecha, i.fechainicio, i.fechafin, DateDiff(DateInterval.Day, i.fechainicio.GetValueOrDefault, i.fechafin.GetValueOrDefault) + 1, i.costo, i.idcongelamiento)
        Next
        dgvCongelamiento.DataSource = dt
        txtCongelamientoDisponible.Text = txtCongela_dia.Value - NroDiasRecuperados
    End Sub

    Private Function GetRangoFecha(fechainicio As Date?, fechafin As Date?) As Integer
        Dim t = DateDiff(DateInterval.Day, fechainicio.GetValueOrDefault, fechafin.GetValueOrDefault)
        t += 1
        Return t
    End Function

    Private Sub EliminarMembresia(idcongelamiento As Integer)
        membresia_congelamientoSA.EliminarCongelamiento(idcongelamiento)
        dgvCongelamiento.Table.CurrentRecord.Delete()
    End Sub
#End Region

#Region "Events"
    Private Sub btRegistrar_Click(sender As Object, e As EventArgs) Handles btRegistrar.Click
        GrabarCongelamiento()
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        r = dgvCongelamiento.Table.CurrentRecord
        If r IsNot Nothing Then
            EliminarMembresia(Integer.Parse(r.GetValue("idcongelamiento")))
            GetCongelamientoByDocumento(Tag)
        Else
            MessageBox.Show("Debe seleccionar un registro", "Seleccionar Fila", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub txtFechaDel_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaDel.ValueChanged
        If IsDate(txtFechaDel.Value) Then
            calculoDias()
        End If
    End Sub

    Private Sub txtFechaHasta_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaHasta.ValueChanged
        If IsDate(txtFechaHasta.Value) Then
            calculoDias()
        End If
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Dim diasCalculados = GetDiasRangofecha(txtFechaDel.Value, txtFechaHasta.Value)

        If diasCalculados < 7 Then
            MessageBox.Show("El minímo de días a congelar es 7", "Validar días", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If diasCalculados <= CInt(txtCongelamientoDisponible.Text) Then
            Dim lista = calculo()

            Dim f As New frmCalculoCongelamiento(lista, Tag)
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            GetCongelamientoByDocumento(Tag)
        Else
            MessageBox.Show("El total de días ingresado, supera el máximo de días congelados permitidos", "Validar días", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        'For x = 0 To lista.Count - 1 Step 2
        '    dgvCongelamiento.Table.AddNewRecord.SetCurrent()
        '    dgvCongelamiento.Table.AddNewRecord.BeginEdit()
        '    dgvCongelamiento.Table.CurrentRecord.SetValue("fecha", Date.Now)
        '    dgvCongelamiento.Table.CurrentRecord.SetValue("fechaInicio", lista(x))
        '    dgvCongelamiento.Table.CurrentRecord.SetValue("fechaFin", lista(x + 1))
        '    dgvCongelamiento.Table.CurrentRecord.SetValue("Dias", "A")
        '    dgvCongelamiento.Table.CurrentRecord.SetValue("costo", 0)
        '    dgvCongelamiento.Table.CurrentRecord.SetValue("idcongelamiento", 0)
        '    dgvCongelamiento.Table.AddNewRecord.EndEdit()
        'Next
    End Sub
#End Region
End Class