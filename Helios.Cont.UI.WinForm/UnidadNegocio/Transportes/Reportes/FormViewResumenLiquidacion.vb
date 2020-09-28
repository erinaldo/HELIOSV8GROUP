Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Public Class FormViewResumenLiquidacion
    Public Property FormLiquidacionProgramacion As FormConsolidarSalidaEmbarque
    Public Property Prog_id As Integer
    Public Property tipooper As String

    Public Property PLACA As String

    Public Property ORIGEN As String

    Public Property DESTINO As String

#Region "Constructors"
    Public Sub New(programacion_id As Integer, tipo As String, form As FormConsolidarSalidaEmbarque)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        tipooper = tipo
        FormLiquidacionProgramacion = form
        Prog_id = programacion_id
        FormatoGridAvanzado(dgvCuentas, True, False, 10.0F)
        Select Case tipo
            Case "pasajes"
                GetResumenPasajes(programacion_id)
            Case "encomiendas"
                GetResumenEncomiendas(programacion_id)
        End Select
    End Sub

    Public Sub New(programacion_id As Integer, tipo As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        tipooper = tipo
        'FormLiquidacionProgramacion = Form
        Prog_id = programacion_id
        FormatoGridAvanzado(dgvCuentas, True, False, 10.0F)
        Select Case tipo
            Case "pasajes"
                GetResumenPasajes(programacion_id)
            Case "encomiendas"
                GetResumenEncomiendas(programacion_id)
        End Select
        TextCodigoPlaca.Enabled = True
        txtTotalAPagar.Text = txtTotalVEntas.Value
        txtTotal.Text = txtTotalVEntas.Value
        txtTotalDescuento.Text = "0.00"
    End Sub

    Private Sub GetResumenPasajes(programacion_id As Integer)
        Dim ventaSA As New DocumentoventaTransporteSA
        Dim dt As New DataTable
        Dim totalimporte As Decimal = 0.0
        dt.Columns.Add("id")
        dt.Columns.Add("asiento")
        dt.Columns.Add("fechaventa")
        dt.Columns.Add("tipodoc")
        dt.Columns.Add("numero")
        dt.Columns.Add("importe")

        For Each i In (ventaSA.GetMovimientosByProgramacion(New documentoventaTransporte With {.programacion_id = programacion_id, .tipoVenta = TIPO_VENTA.VENTA_PASAJES})).OrderBy(Function(O) O.numeroAsiento)

            If (i.estado <> 5) Then
                dt.Rows.Add(
               i.idDocumento,
               i.numeroAsiento,
               i.fechadoc,
               i.tipoDocumento,
               $"{i.serie }-{i.numero}",
               i.total)
                totalimporte = totalimporte + i.total
            End If

        Next
        dgvCuentas.DataSource = dt
        txtTotalVEntas.Value = totalimporte
    End Sub

    Private Sub GetResumenEncomiendas(programacion_id As Integer)
        Dim ventaSA As New DocumentoventaTransporteSA
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("asiento")
        dt.Columns.Add("fechaventa")
        dt.Columns.Add("tipodoc")
        dt.Columns.Add("numero")
        dt.Columns.Add("importe")

        For Each i In ventaSA.GetEncomiendasByProgramacion(New documentoventaTransporte With {.programacion_id = programacion_id, .tipoVenta = TIPO_VENTA.VENTA_ENCOMIENDAS})
            If (i.estado <> 5) Then
                dt.Rows.Add(
                               i.idDocumento,
                               i.Remitente,
                               i.Consignado,
                               i.comprador,
                               $"{i.serie }-{i.numero}",
                               i.total)
            End If
        Next
        dgvCuentas.DataSource = dt
    End Sub

    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        Select Case tipooper
            Case "pasajes"
                'Dim f As New FormLiquidacionProgramacionPasaje(Prog_id, FormLiquidacionProgramacion)
                'f.StartPosition = FormStartPosition.CenterParent
                'f.ShowDialog(Me)



                '?? LIRACY Y LALO
                'ImprimirPednienteSingle(Prog_id)

                ''//PICHANAQUI - ANDES
                ImprimirPednienteSingleTicket(Prog_id)

            Case "encomiendas"
                Dim f As New FormReporteEncomiendas(Prog_id, FormLiquidacionProgramacion)
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog(Me)
        End Select

    End Sub

    Private Sub ImprimirPednienteSingleTicket(program_id As Integer)
        Dim a As TickeTransporteLiquidacion = New TickeTransporteLiquidacion
        ' Logo de la Empresa

        Dim lista As New List(Of String)

        Dim gravMN As Decimal = 0
        Dim gravME As Decimal = 0
        Dim ExoMN As Decimal = 0
        Dim ExoME As Decimal = 0
        Dim InaMN As Decimal = 0
        Dim InaME As Decimal = 0


        Dim tipoComprobante As String = String.Empty

        Dim ventaSA As New DocumentoventaTransporteSA

        Dim listaCOMPROBANTE = ventaSA.GetMovimientosByProgramacion(New documentoventaTransporte With {.programacion_id = program_id, .tipoVenta = General.TIPO_VENTA.VENTA_PASAJES})

        If (listaCOMPROBANTE.Count > 0) Then

            Dim consulta = (listaCOMPROBANTE.Where(Function(o) o.estado <> 5)).OrderBy(Function(O) O.numeroAsiento)




            a.AnadirLineaEmpresa("LIQUIDACIÒN")

            '//*************************
            'direccion de la empresa
            'a.TextoIzquierda("FECHA: " & TextFechaProgramada.Value.ToShortDateString)
            'a.TextoIzquierda("HORA: " & TextFechaProgramada.Value.ToShortTimeString)
            'a.TextoIzquierda("UNIDAD - VEHICULO: " & TextUnidadVehiculo.Text) ' ComboVehiculo.Text)
            'a.TextoIzquierda("CONDUCTOR: " & TextChoferTripulante.Text) ' ComboChofer.Text)
            'a.TextoIzquierda("ORIGEN: " & TextOrigen.Text)
            'a.TextoIzquierda("DESTINO: " & TextDestino.Text)

            'Dim HORA As String = Date.Now.ToLongTimeString
            Dim FECHAENVIO As String = Date.Now
            'a.AnadirLineaCabeza($"{"FECHA: "}{FECHAENVIO}                                                  {"UNIDAD: "}{PLACA}")
            'a.AnadirLineaCabeza($"{"ORIGEN: "}{ORIGEN}                                                     {"DESTINO: "}{DESTINO}")





            '*********************** TODO LOS DETALLES DE LOS ITEM *********************
            'CODIGO
            'DESCRIPCION
            'CANTIDAD
            'UM
            'VALOR VENTA UNITARIO
            'DESCUENTO
            'VALOR DE VENTA TOTAL
            'OTROS CARGOS
            'IMPUESTOS
            'PRECIO DE VENTA
            'VALOR TOTAL

            Dim CONTE As Integer = 1

            Dim NUM As Integer = 0
            Dim TIPO As String = String.Empty
            Dim SERIE As String = String.Empty
            Dim IMPORTE As String = String.Empty
            Dim IMPORTETOTAL As Decimal = 0.0
            Dim CINTEOONUM As Integer = 0
            Dim asientoNum As Integer = 0

            For Each i In consulta
                'If (CINTEOONUM = 0) Then
                '    NUM = CONTE
                '    TIPO = i.tipoDocumento
                '    SERIE = i.serie & "-" & i.numero
                '    IMPORTE = i.total
                '    CINTEOONUM = 1
                '    asientoNum = i.numeroAsiento
                'ElseIf (CINTEOONUM = 1) Then
                'a.AnadirLineaElementosEncomienda(asientoNum, i.serie & "-" & i.numero, SERIE, TIPO, IMPORTE, i.numeroAsiento, i.total, i.tipoDocumento)

                a.AnadirLineaElementosFactura(i.numeroAsiento,
                                 i.serie & "-" & i.numero,
                                 0,
                                  0, i.total)


                '    CINTEOONUM = 0
                ''End If

                'IMPORTETOTAL = IMPORTETOTAL + i.total

                CONTE = CONTE + 1

            Next



            a.AnadirLineaCaracteresDatosGEnerales("RUTA: " & ORIGEN & " - " & DESTINO,
                                              "FECHA: " & txtFecha.Text,
                                              TextCodigoPlaca.Text,
                                             "TOTAL PAX: " & CONTE,
                                             "",
                                              "",
                                              "",
                                              "HORA: " & txtHora.Text)

            'If (CINTEOONUM = 1) Then
            '    a.AnadirLineaElementosEncomienda(asientoNum, "", SERIE, TIPO, IMPORTE, "", 0.0, "")
            '    CINTEOONUM = 0
            'End If

            a.AnadirDatosGenerales("S/", txtTotalVEntas.Value)
            a.AnadirDatosGenerales("S/", CDec(txtTotalDescuento.Text))
            a.AnadirDatosGenerales("S/", txtCotizacion.Value)
            a.AnadirDatosGenerales("S/", txtAcuenta.Value)
            a.AnadirDatosGenerales("S/", CDec(txtTotalAPagar.Text))


            a.AnadirLineaDatos(IMPORTETOTAL, "2", "3")

            ''TICJET NORMAL
            a.ImprimeTicket("TICKET")

            ''PARA LA MERCED
            'a.ImprimeTicket("EPSON TM-T20II Receipt5")
        End If
    End Sub



    Private Sub ImprimirPednienteSingle(program_id As Integer)
        Dim a As ManifiestoTransporte = New ManifiestoTransporte
        ' Logo de la Empresa

        Dim lista As New List(Of String)

        Dim gravMN As Decimal = 0
        Dim gravME As Decimal = 0
        Dim ExoMN As Decimal = 0
        Dim ExoME As Decimal = 0
        Dim InaMN As Decimal = 0
        Dim InaME As Decimal = 0


        Dim tipoComprobante As String = String.Empty

        Dim ventaSA As New DocumentoventaTransporteSA

        Dim listaCOMPROBANTE = ventaSA.GetMovimientosByProgramacion(New documentoventaTransporte With {.programacion_id = program_id, .tipoVenta = General.TIPO_VENTA.VENTA_PASAJES})

        If (listaCOMPROBANTE.Count > 0) Then

            Dim consulta = listaCOMPROBANTE.Where(Function(o) o.estado <> 5)




            a.AnadirLineaEmpresa("LIQUIDACIÒN")

            '//*************************
            'direccion de la empresa
            'a.TextoIzquierda("FECHA: " & TextFechaProgramada.Value.ToShortDateString)
            'a.TextoIzquierda("HORA: " & TextFechaProgramada.Value.ToShortTimeString)
            'a.TextoIzquierda("UNIDAD - VEHICULO: " & TextUnidadVehiculo.Text) ' ComboVehiculo.Text)
            'a.TextoIzquierda("CONDUCTOR: " & TextChoferTripulante.Text) ' ComboChofer.Text)
            'a.TextoIzquierda("ORIGEN: " & TextOrigen.Text)
            'a.TextoIzquierda("DESTINO: " & TextDestino.Text)

            'Dim HORA As String = Date.Now.ToLongTimeString
            Dim FECHAENVIO As String = Date.Now
            a.AnadirLineaCabeza($"{"FECHA: "}{FECHAENVIO}                                                  {"UNIDAD: "}{PLACA}")
            a.AnadirLineaCabeza($"{"ORIGEN: "}{ORIGEN}                                                     {"DESTINO: "}{DESTINO}")

            '*********************** TODO LOS DETALLES DE LOS ITEM *********************
            'CODIGO
            'DESCRIPCION
            'CANTIDAD
            'UM
            'VALOR VENTA UNITARIO
            'DESCUENTO
            'VALOR DE VENTA TOTAL
            'OTROS CARGOS
            'IMPUESTOS
            'PRECIO DE VENTA
            'VALOR TOTAL

            Dim CONTE As Integer = 1

            Dim NUM As Integer = 0
            Dim TIPO As String = String.Empty
            Dim SERIE As String = String.Empty
            Dim IMPORTE As String = String.Empty
            Dim IMPORTETOTAL As Decimal = 0.0
            Dim CINTEOONUM As Integer = 0
            Dim asientoNum As Integer = 0

            For Each i In consulta
                If (CINTEOONUM = 0) Then
                    NUM = CONTE
                    TIPO = i.tipoDocumento
                    SERIE = i.serie & "-" & i.numero
                    IMPORTE = i.total
                    CINTEOONUM = 1
                    asientoNum = i.numeroAsiento
                ElseIf (CINTEOONUM = 1) Then
                    a.AnadirLineaElementosEncomienda(asientoNum, i.serie & "-" & i.numero, SERIE, TIPO, IMPORTE, i.numeroAsiento, i.total, i.tipoDocumento)
                    CINTEOONUM = 0
                End If

                IMPORTETOTAL = IMPORTETOTAL + i.total

                CONTE = CONTE + 1

            Next

            If (CINTEOONUM = 1) Then
                a.AnadirLineaElementosEncomienda(asientoNum, "", SERIE, TIPO, IMPORTE, "", 0.0, "")
                CINTEOONUM = 0
            End If

            a.AnadirLineaDatos(IMPORTETOTAL, "2", "3")

                a.ImprimeTicket("TICKET/RUTA")
            End If
    End Sub

    Private Sub TxtDescuento_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescuento.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                calculoDescuento(txtDescuento.Value)
                txtCotizacion.Select()
                txtCotizacion.Focus()
                txtCotizacion.Select(0, txtCotizacion.Text.Length)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            txtDescuento.Value = 0.0
        End Try
    End Sub

    Private Sub TxtCotizacion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCotizacion.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                calculcotizaciono(txtCotizacion.Value)
                txtAcuenta.Select()
                txtAcuenta.Focus()
                txtAcuenta.Select(0, txtAcuenta.Text.Length)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            txtCotizacion.Value = 0.0
        End Try
    End Sub

    Private Sub TxtAcuenta_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAcuenta.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                calculAcuenta(txtAcuenta.Value)
                RoundButton21.Select()
                RoundButton21.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            txtAcuenta.Value = 0.0
        End Try
    End Sub

    Private Sub FormViewResumenLiquidacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtDescuento.Select(0, txtDescuento.Text.Length)
        txtTotal.Text = txtTotalVEntas.Value
    End Sub

    Private Sub calculoDescuento(descuento As Decimal)
        Try
            'Dim descuento As Decimal
            Dim cotizacion As Decimal
            Dim total As Decimal
            Dim ventaTotal As Decimal = txtTotal.Text

            total = Math.Round(txtTotalVEntas.Value - (txtTotalVEntas.Value * (descuento / 100)), 1, MidpointRounding.ToEven)
            txtTotalDescuento.Text = (Math.Round((txtTotalVEntas.Value - (txtTotalVEntas.Value * (txtDescuento.Value / 100))) - (txtCotizacion.Value), 1, MidpointRounding.ToEven)).ToString("N2")
            txtTotal.Text = (txtTotalDescuento.Text)

            total = Math.Round(((txtTotalVEntas.Value - (txtTotalVEntas.Value * (txtDescuento.Value / 100))) - (txtCotizacion.Value)) - (txtAcuenta.Value), 1, MidpointRounding.ToEven).ToString("N2")

            txtTotalAPagar.Text = (total.ToString("N2"))

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub calculcotizaciono(cotizacion As Decimal)
        Try
            Dim descuento As Decimal
            'Dim cotizacion As Decimal
            Dim total As Decimal
            Dim ventaTotal As Decimal = txtTotal.Text

            total = Math.Round((txtTotalVEntas.Value - (txtTotalVEntas.Value * (txtDescuento.Value / 100))) - (cotizacion), 1, MidpointRounding.ToEven).ToString("N2")

            txtTotal.Text = total.ToString("N2")


            total = Math.Round(((txtTotalVEntas.Value - (txtTotalVEntas.Value * (txtDescuento.Value / 100))) - (txtCotizacion.Value)) - (txtAcuenta.Value), 1, MidpointRounding.ToEven).ToString("N2")

            txtTotalAPagar.Text = total.ToString("N2")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub calculAcuenta(acuenta As Decimal)
        Try
            Dim descuento As Decimal
            'Dim cotizacion As Decimal
            Dim total As Decimal
            Dim ventaTotal As Decimal = txtTotal.Text

            total = Math.Round(((txtTotalVEntas.Value - (txtTotalVEntas.Value * (txtDescuento.Value / 100))) - (txtCotizacion.Value)) - (acuenta), 1, MidpointRounding.ToEven).ToString("N2")

            txtTotalAPagar.Text = total.ToString("N2")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TxtTotalVEntas_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTotalVEntas.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True

                txtDescuento.Select()
                txtDescuento.Focus()
                txtDescuento.Select(0, txtDescuento.Text.Length)

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            txtAcuenta.Value = 0.0
        End Try
    End Sub

    Private Sub TextBoxExt2_TextChanged(sender As Object, e As EventArgs) Handles txtHora.TextChanged

    End Sub

    Private Sub TxtDescuento_Click(sender As Object, e As EventArgs) Handles txtDescuento.Click
        txtDescuento.Select(0, txtDescuento.Text.Length)
    End Sub

    Private Sub TxtCotizacion_Click(sender As Object, e As EventArgs) Handles txtCotizacion.Click
        txtCotizacion.Select(0, txtCotizacion.Text.Length)
    End Sub

    Private Sub TxtAcuenta_Click(sender As Object, e As EventArgs) Handles txtAcuenta.Click
        txtAcuenta.Select(0, txtAcuenta.Text.Length)
    End Sub

#End Region

End Class