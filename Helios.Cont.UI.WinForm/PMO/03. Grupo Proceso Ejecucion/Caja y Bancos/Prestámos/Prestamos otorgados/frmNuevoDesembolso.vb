Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmNuevoDesembolso

    Inherits frmMaster

    Public Property ListaMovimientos As New List(Of movimiento)
    Public Property ListaAsientosConceptos As New List(Of documentoPrestamoDetalle)

#Region "Variables"

    Dim colorx As New GridMetroColors()
    Dim srtNomAlmacen As String = Nothing
    Dim strUM As String = Nothing
    Dim strTipoEx As String = Nothing
    Dim strCuenta As String = Nothing
    Dim intIdEstableAlm As Integer
    Dim strIdPresentacion As String = Nothing
    Public fecha As DateTime
    Dim selAlmacenPC As String

    Public Property ListaAsientonTransito As New List(Of asiento)
    Public Property ManipulacionEstado() As String
    Private cantidaExistente As New List(Of Integer)
    Dim cuentaMascaraSA As New cuentaMascaraSA
    Dim cuentaMascara As New cuentaMascara
    Private comboTable As DataTable
    Private comboTableCuentas As DataTable
    Public Property sumaMN() As Decimal
    Public Property sumaME() As Decimal
#End Region

    Public Property ListaAsientos As New List(Of asiento)


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'CargarListas()
        lblPerido.Text = PeriodoGeneral
        configuracionModuloV2(Gempresas.IdEmpresaRuc, "OES", Me.Text, GEstableciento.IdEstablecimiento)
        ListaDefaultDeInicio()
        'GridCFG(dgvCompra)

        GridCFG(dgvPrestamos)
        GetTableGrid()

        ObtenerTablaGenerales()
        ' CargarDAtos()

        DateTimePickerAdv1.Value = DateTime.Now

    End Sub

    Sub GridCFG(GGC As GridGroupingControl)
        'GGC.TableOptions.ShowRowHeader = False
        'GGC.TopLevelGroupOptions.ShowCaption = False
        'GGC.ShowColumnHeaders = True

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(15, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 7.5F

    End Sub

#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean

        'If Not parpadear Then
        '    lblEstado.ForeColor = lblEstado.BackColor
        '    lblEstado.BackColor = Color.Yellow
        'Else
        '    lblEstado.ForeColor = SystemColors.WindowText
        'End If

        parpadear = Not parpadear
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick

    End Sub
    Private TiempoRestante As Integer
    Public Sub TimerOn(ByRef Interval As Short)
        If Interval > 0 Then
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
        End If

    End Sub
    Public Function TiempoEjecutar(ByVal Tiempo As Integer)
        TiempoEjecutar = ""
        TiempoRestante = Tiempo  ' 1 minutos=60 segundos 
        Timer1.Interval = 400

        Call TimerOn(1000) ' Hechanos a andar el timer
    End Function
#End Region

#Region "Métodos"




    Sub ActFechas()
       

        Dim fechaAux As DateTime

        Dim fechaModo As DateTime = DateTimePickerAdv2.Value
        fechaModo = New DateTime(fechaModo.Year, fechaModo.Month, CInt(cboDiaPago.Text))

        'Dim fecha As DateTime
        'fecha = DateTimePickerAdv2.Value
        Dim fechaModo2 As DateTime = DateTimePickerAdv2.Value
        fechaModo2 = New DateTime(DateTimePickerAdv2.Value.Year, DateTimePickerAdv2.Value.Month, DateTimePickerAdv2.Value.Day)

        For Each i As Record In dgvPrestamos.Table.Records

            If cboModo.Text = "MENSUAL" Then

                If Year(fechaModo) = 12 Then

                    fechaModo = fechaModo.AddMonths(1)
                    fechaModo = fechaModo.AddYears(1)
                Else
                    fechaModo = fechaModo.AddMonths(1)

                End If
                fechaModo = fechaModo

                i.SetValue("FechaPago", fechaModo)
                fechaAux = fechaModo.AddDays(CInt(cbodiaplazo.Text))
                i.SetValue("FechaPlazo", fechaAux)


            ElseIf cboModo.Text = "QUINCENAL" Then

                fechaModo2 = fechaModo2.AddDays(15)
                fechaModo2 = fechaModo2

                i.SetValue("FechaPago", fechaModo2)
                fechaAux = fechaModo2.AddDays(CInt(cbodiaplazo.Text))
                i.SetValue("FechaPlazo", fechaAux)

            ElseIf cboModo.Text = "SEMANAL" Then

                fechaModo2 = fechaModo2.AddDays(7)
                fechaModo2 = fechaModo2

                i.SetValue("FechaPago", fechaModo2)
                fechaAux = fechaModo2.AddDays(CInt(cbodiaplazo.Text))
                i.SetValue("FechaPlazo", fechaAux)

            ElseIf cboModo.Text = "DIARIO" Then

                fechaModo2 = fechaModo2.AddDays(1)
                fechaModo2 = fechaModo2

                i.SetValue("FechaPago", fechaModo2)
                fechaAux = fechaModo2.AddDays(CInt(cbodiaplazo.Text))
                i.SetValue("FechaPlazo", fechaAux)
            End If


        Next

    End Sub


    'Public Sub UpdateFechasPrestamo()
    '    Dim objPrestamoEO As New documentoPrestamos
    '    Dim objDocumentoEO As New prestamos
    '    Dim docPrestamo As New documentoPrestamos
    '    Dim documentoPrestamoSA As New documentoPrestamoSA
    '    Dim listaPrestamo As New List(Of documentoPrestamos)
    '    Try
    '        With objDocumentoEO

    '            .idDocumento = lblIdDocumento.Text
    '            .fechaDesembolso = DateTimePickerAdv1.Value
    '            .modoPago = cboModo.Text
    '            .fechaInicio = DateTimePickerAdv2.Value
    '            .diaPago = CInt(cboDiaPago.Text)
    '            .plazoDias = CInt(cbodiaplazo.Text)
    '            '.nroDoc = txtNumeroCompr.Text

    '        End With

    '        For Each i As Record In dgvPrestamos.Table.Records

    '            docPrestamo = New documentoPrestamos
    '            ''''''''
    '            docPrestamo.idDocumento = i.GetValue("idDocumento")
    '            docPrestamo.idCuota = i.GetValue("idCuota")
    '            docPrestamo.fechaVcto = i.GetValue("FechaPago")
    '            docPrestamo.fechaPlazo = i.GetValue("FechaPlazo")
    '            listaPrestamo.Add(docPrestamo)
    '        Next

    '        documentoPrestamoSA.UpdateFechaPrestamos(objDocumentoEO, listaPrestamo)
    '        'Dispose()
    '        lblEstado.Text = "Fecha Actualizada"
    '        Timer1.Enabled = True
    '        PanelError.Visible = True
    '        TiempoEjecutar(10)
    '        cboDepositoHijo.Select()
    '    Catch ex As Exception
    '        MsgBox("Error al Actualizar." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del sistema")
    '    End Try
    'End Sub



    Sub GetTableGrid()
        Dim dt As New DataTable()
        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("idCuota", GetType(Integer))
        dt.Columns.Add("colGlosa", GetType(String))
        dt.Columns.Add("FechaPago", GetType(Date))
        dt.Columns.Add("FechaPlazo", GetType(Date))
        dgvPrestamos.DataSource = dt
    End Sub

    Public Sub UbicarFechas(ByVal intIdDocumento As Integer)

        Dim objLista As New documentoPrestamoSA
        Dim lista As New List(Of documentoPrestamos)

        lista = objLista.ListadoFechasCuotas(intIdDocumento)

        For Each i As documentoPrestamos In lista
            Me.dgvPrestamos.Table.AddNewRecord.SetCurrent()
            Me.dgvPrestamos.Table.AddNewRecord.BeginEdit()
            Me.dgvPrestamos.Table.CurrentRecord.SetValue("idDocumento", i.idDocumento)
            Me.dgvPrestamos.Table.CurrentRecord.SetValue("idCuota", i.idCuota)
            Me.dgvPrestamos.Table.CurrentRecord.SetValue("colGlosa", i.referencia)
            Me.dgvPrestamos.Table.CurrentRecord.SetValue("FechaPago", i.fechaVcto)
            Me.dgvPrestamos.Table.CurrentRecord.SetValue("FechaPlazo", i.fechaPlazo)
            Me.dgvPrestamos.Table.AddNewRecord.EndEdit()
        Next

        DateTimePickerAdv3.Value = lista(lista.Count - 1).fechaVcto

        listamontos(intIdDocumento)

    End Sub


    Public Sub listamontos(ByVal iddocumento As Integer)
        Dim objLista As New documentoPrestamoSA

        Dim listaMonto As New documentoPrestamoDetalle

        Dim serv As New List(Of documentoPrestamoDetalle)
        Dim objeto As New documentoPrestamoDetalle


        serv = objLista.ListadoMontosCuentas(iddocumento)

        Dim consulta = (From n In serv _
                          Group By n.descripcion, n.cuenta, n.tipo, n.cuentaH, n.devengado, n.devengadoH _
                          Into g = Group _
                           Select New With {
                               .descripcion = descripcion,
                               .cuenta = cuenta,
                               .cuentaH = cuentaH,
                                .montosoles = g.Sum(Function(cab) cab.montoSoles),
        .montodolares = g.Sum(Function(cab) cab.montoUsd)
                               }).tolist

        For Each i In consulta

            objeto = New documentoPrestamoDetalle
            objeto.descripcion = i.descripcion
            objeto.montoSoles = i.montosoles
            objeto.montoUsd = i.montodolares
            objeto.cuenta = i.cuenta
            objeto.cuentaH = i.cuentaH
            ListaAsientosConceptos.Add(objeto)
        Next

        'For Each i As documentoPrestamoDetalle In objLista.ListadoMontosCuentas(iddocumento)
        '    If i.descripcion = "ENVIO" Then
        '        envio += i.montoSoles
        '        enviome += i.montoUsd
        '    End If
        '    If i.descripcion = "PORTES" Then
        '        portes += i.montoSoles
        '        portesme += i.montoUsd
        '    End If
        '    If i.descripcion = "SEGURO" Then
        '        seguro += i.montoSoles
        '        segurome += i.montoUsd
        '    End If
        '    If i.descripcion = "INTERES" Then
        '        interes += i.montoSoles
        '        interesme += i.montoUsd
        '    End If
        '    If i.descripcion = "CAPITAL" Then
        '        capital += i.montoSoles
        '        capitalme += i.montoUsd
        '    End If
        '    If i.descripcion = "OTRO" Then
        '        otro += i.montoSoles
        '        otrome += i.montoUsd
        '    End If
        'Next


        'txtInteresMN.Value = interes
        'txtInteresME.Value = interesme
        'txtSeguroMN.Value = seguro
        'txtSeguroME.Value = segurome
        'txtOtroMN.Value = otro
        'txtOtroME.Value = otrome
        'txtPortesMN.Value = portes
        'txtPortesME.Value = portesme
        'txtEnvMN.Value = envio
        'txtEnvME.Value = enviome


    End Sub

    'Private Sub cargarCuentasAutomatico()
    '    Dim n As New movimiento
    '    txtGlosaAsiento.Clear()
    '    txtGlosaAsiento.Text = txtDescripcion.Text





    '    If txtTipo.Text = "PERSONAL" Then

    '        If (txtFondoMN.Value > 0 And txtFondoME.Value > 0) Then
    '            ListaMovimientos.Clear()
    '            n.cuenta = "1411"
    '            n.idAsiento = 1
    '            n.idmovimiento = GetMaxIDMovimiento() + 1
    '            n.tipo = "D"
    '            n.Cant = 1
    '            n.PUmn = CDec(txtFondoMN.Value / n.Cant)
    '            n.PUme = CDec(txtFondoME.Value / n.Cant)
    '            n.monto = txtFondoMN.Value
    '            n.montoUSD = txtFondoME.Value
    '            ListaMovimientos.Add(n)

    '            cargarAsientos1()
    '        Else
    '            lblEstado.Text = "Ingrese un importe."
    '            Timer1.Enabled = True
    '            PanelError.Visible = True
    '            TiempoEjecutar(10)
    '            txtFondoMN.Select(0, txtFondoMN.Text.Length)
    '            Exit Sub
    '        End If
    '        '////////////////////////



    '        If (txtFondoMN.Value > 0 And txtFondoME.Value > 0) Then

    '            'RegsitarMovimiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})
    '            Dim c As New movimiento
    '            c.cuenta = "10"
    '            c.idAsiento = 1
    '            c.idmovimiento = GetMaxIDMovimiento() + 1
    '            c.tipo = "H"
    '            c.Cant = 1
    '            c.PUmn = CDec(txtFondoMN.Value / c.Cant)
    '            c.PUme = CDec(txtFondoME.Value / c.Cant)
    '            c.monto = txtFondoMN.Value
    '            c.montoUSD = txtFondoME.Value
    '            ListaMovimientos.Add(c)


    '            '  RegistrarMovimiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})

    '            'Dim cuentaSA As New cuentaplanContableEmpresaSA
    '            Dim dt As New DataTable

    '            'dt.Reset()
    '            dt.Columns.Add("id", GetType(Integer))
    '            dt.Columns.Add("Modulo", GetType(String))
    '            dt.Columns.Add("cuenta", GetType(String))
    '            dt.Columns.Add("tipoAsiento", GetType(String))
    '            dt.Columns.Add("cant", GetType(Decimal))
    '            dt.Columns.Add("pumn", GetType(Decimal))
    '            dt.Columns.Add("importeMN", GetType(Decimal))
    '            dt.Columns.Add("pume", GetType(Decimal))
    '            dt.Columns.Add("importeME", GetType(Decimal))
    '            dt.Columns.Add("descripcion", GetType(String))

    '            Dim cosnulta = (From i In ListaMovimientos _
    '                           Where i.idAsiento = 1).ToList

    '            For Each x In cosnulta
    '                Dim dr As DataRow = dt.NewRow
    '                dr(0) = x.idmovimiento
    '                If Not IsNothing(x.cuenta) Then
    '                    dr(1) = x.nombreEntidad
    '                Else
    '                    dr(1) = String.Empty
    '                End If
    '                dr(2) = x.cuenta
    '                dr(3) = x.tipo
    '                dr(4) = x.Cant
    '                dr(5) = x.PUmn
    '                dr(6) = x.monto
    '                dr(7) = x.PUme
    '                dr(8) = x.montoUSD
    '                dr(9) = x.descripcion
    '                dt.Rows.Add(dr)
    '            Next
    '            dgvCompra.Table.Records.DeleteAll()
    '            'dgvCompra.DataSource = Nothing
    '            dgvCompra.DataSource = dt

    '        Else
    '            lblEstado.Text = "Ingrese un importe."
    '            Timer1.Enabled = True
    '            PanelError.Visible = True
    '            TiempoEjecutar(10)
    '            txtFondoMN.Select(0, txtFondoMN.Text.Length)
    '            Exit Sub
    '        End If





    '        '////////////INTERESES
    '        If txtTotalC2MN.Value > 0 Then
    '            Dim c As New movimiento
    '            c.cuenta = "1411"
    '            c.idAsiento = 2
    '            c.idmovimiento = GetMaxIDMovimiento() + 1
    '            c.tipo = "D"
    '            c.Cant = 1
    '            c.PUmn = CDec(txtTotalC2MN.Value / c.Cant)
    '            c.PUme = CDec(txtTotalC2ME.Value / c.Cant)
    '            c.monto = txtTotalC2MN.Value
    '            c.montoUSD = txtTotalC2ME.Value
    '            ListaMovimientos.Add(c)
    '        End If
    '        If txtTotalC2MN.Value > 0 Then
    '            Dim c As New movimiento
    '            c.cuenta = "4931"
    '            c.idAsiento = 2
    '            c.idmovimiento = GetMaxIDMovimiento() + 1
    '            c.tipo = "H"
    '            c.Cant = 1
    '            c.PUmn = CDec(txtTotalC2MN.Value / c.Cant)
    '            c.PUme = CDec(txtTotalC2ME.Value / c.Cant)
    '            c.monto = txtTotalC2MN.Value
    '            c.montoUSD = txtTotalC2ME.Value
    '            ListaMovimientos.Add(c)
    '        End If


    '    ElseIf txtTipo.Text = "TERCEROS" Then

    '        If (txtFondoMN.Value > 0 And txtFondoME.Value > 0) Then
    '            ListaMovimientos.Clear()
    '            n.cuenta = "1612"
    '            n.idAsiento = 1
    '            n.idmovimiento = GetMaxIDMovimiento() + 1
    '            n.tipo = "D"
    '            n.Cant = 1
    '            n.PUmn = CDec(txtFondoMN.Value / n.Cant)
    '            n.PUme = CDec(txtFondoME.Value / n.Cant)
    '            n.monto = txtFondoMN.Value
    '            n.montoUSD = txtFondoME.Value
    '            ListaMovimientos.Add(n)

    '            cargarAsientos1()
    '        Else
    '            lblEstado.Text = "Ingrese un importe."
    '            Timer1.Enabled = True
    '            PanelError.Visible = True
    '            TiempoEjecutar(10)
    '            txtFondoMN.Select(0, txtFondoMN.Text.Length)
    '            Exit Sub
    '        End If
    '        '////////////////////////

    '        If (txtFondoMN.Value > 0 And txtFondoME.Value > 0) Then

    '            'RegsitarMovimiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})
    '            Dim c As New movimiento
    '            c.cuenta = "10"
    '            c.idAsiento = 1
    '            c.idmovimiento = GetMaxIDMovimiento() + 1
    '            c.tipo = "H"
    '            c.Cant = 1
    '            c.PUmn = CDec(txtFondoMN.Value / c.Cant)
    '            c.PUme = CDec(txtFondoME.Value / c.Cant)
    '            c.monto = txtFondoMN.Value
    '            c.montoUSD = txtFondoME.Value
    '            ListaMovimientos.Add(c)


    '            '  RegistrarMovimiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})

    '            'Dim cuentaSA As New cuentaplanContableEmpresaSA
    '            Dim dt As New DataTable

    '            'dt.Reset()
    '            dt.Columns.Add("id", GetType(Integer))
    '            dt.Columns.Add("Modulo", GetType(String))
    '            dt.Columns.Add("cuenta", GetType(String))
    '            dt.Columns.Add("tipoAsiento", GetType(String))
    '            dt.Columns.Add("cant", GetType(Decimal))
    '            dt.Columns.Add("pumn", GetType(Decimal))
    '            dt.Columns.Add("importeMN", GetType(Decimal))
    '            dt.Columns.Add("pume", GetType(Decimal))
    '            dt.Columns.Add("importeME", GetType(Decimal))
    '            dt.Columns.Add("descripcion", GetType(String))

    '            Dim cosnulta = (From i In ListaMovimientos _
    '                           Where i.idAsiento = 1).ToList

    '            For Each x In cosnulta
    '                Dim dr As DataRow = dt.NewRow
    '                dr(0) = x.idmovimiento
    '                If Not IsNothing(x.cuenta) Then
    '                    dr(1) = x.nombreEntidad
    '                Else
    '                    dr(1) = String.Empty
    '                End If
    '                dr(2) = x.cuenta
    '                dr(3) = x.tipo
    '                dr(4) = x.Cant
    '                dr(5) = x.PUmn
    '                dr(6) = x.monto
    '                dr(7) = x.PUme
    '                dr(8) = x.montoUSD
    '                dr(9) = x.descripcion
    '                dt.Rows.Add(dr)
    '            Next
    '            dgvCompra.Table.Records.DeleteAll()
    '            'dgvCompra.DataSource = Nothing
    '            dgvCompra.DataSource = dt

    '        Else
    '            lblEstado.Text = "Ingrese un importe."
    '            Timer1.Enabled = True
    '            PanelError.Visible = True
    '            TiempoEjecutar(10)
    '            txtFondoMN.Select(0, txtFondoMN.Text.Length)
    '            Exit Sub
    '        End If

    '        If txtTotalC2MN.Value > 0 Then
    '            Dim c As New movimiento
    '            c.cuenta = "1612"
    '            c.idAsiento = 2
    '            c.idmovimiento = GetMaxIDMovimiento() + 1
    '            c.tipo = "D"
    '            c.Cant = 1
    '            c.PUmn = CDec(txtTotalC2MN.Value / c.Cant)
    '            c.PUme = CDec(txtTotalC2ME.Value / c.Cant)
    '            c.monto = txtTotalC2MN.Value
    '            c.montoUSD = txtTotalC2ME.Value
    '            ListaMovimientos.Add(c)
    '        End If
    '        If txtTotalC2MN.Value > 0 Then
    '            Dim c As New movimiento
    '            c.cuenta = "4931"
    '            c.idAsiento = 2
    '            c.idmovimiento = GetMaxIDMovimiento() + 1
    '            c.tipo = "H"
    '            c.Cant = 1
    '            c.PUmn = CDec(txtTotalC2MN.Value / c.Cant)
    '            c.PUme = CDec(txtTotalC2ME.Value / c.Cant)
    '            c.monto = txtTotalC2MN.Value
    '            c.montoUSD = txtTotalC2ME.Value
    '            ListaMovimientos.Add(c)
    '        End If


    '    ElseIf txtTipo.Text = "RELACIONADAS" Then

    '        If (txtFondoMN.Value > 0 And txtFondoME.Value > 0) Then
    '            ListaMovimientos.Clear()
    '            n.cuenta = "1712"
    '            n.idAsiento = 1
    '            n.idmovimiento = GetMaxIDMovimiento() + 1
    '            n.tipo = "D"
    '            n.Cant = 1
    '            n.PUmn = CDec(txtFondoMN.Value / n.Cant)
    '            n.PUme = CDec(txtFondoME.Value / n.Cant)
    '            n.monto = txtFondoMN.Value
    '            n.montoUSD = txtFondoME.Value
    '            ListaMovimientos.Add(n)

    '            cargarAsientos1()
    '        Else
    '            lblEstado.Text = "Ingrese un importe."
    '            Timer1.Enabled = True
    '            PanelError.Visible = True
    '            TiempoEjecutar(10)
    '            txtFondoMN.Select(0, txtFondoMN.Text.Length)
    '            Exit Sub
    '        End If
    '        '////////////////////////

    '        If (txtFondoMN.Value > 0 And txtFondoME.Value > 0) Then

    '            'RegsitarMovimiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})
    '            Dim c As New movimiento
    '            c.cuenta = "10"
    '            c.idAsiento = 1
    '            c.idmovimiento = GetMaxIDMovimiento() + 1
    '            c.tipo = "H"
    '            c.Cant = 1
    '            c.PUmn = CDec(txtFondoMN.Value / c.Cant)
    '            c.PUme = CDec(txtFondoME.Value / c.Cant)
    '            c.monto = txtFondoMN.Value
    '            c.montoUSD = txtFondoME.Value
    '            ListaMovimientos.Add(c)


    '            '  RegistrarMovimiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})

    '            'Dim cuentaSA As New cuentaplanContableEmpresaSA
    '            Dim dt As New DataTable

    '            'dt.Reset()
    '            dt.Columns.Add("id", GetType(Integer))
    '            dt.Columns.Add("Modulo", GetType(String))
    '            dt.Columns.Add("cuenta", GetType(String))
    '            dt.Columns.Add("tipoAsiento", GetType(String))
    '            dt.Columns.Add("cant", GetType(Decimal))
    '            dt.Columns.Add("pumn", GetType(Decimal))
    '            dt.Columns.Add("importeMN", GetType(Decimal))
    '            dt.Columns.Add("pume", GetType(Decimal))
    '            dt.Columns.Add("importeME", GetType(Decimal))
    '            dt.Columns.Add("descripcion", GetType(String))

    '            Dim cosnulta = (From i In ListaMovimientos _
    '                           Where i.idAsiento = 1).ToList

    '            For Each x In cosnulta
    '                Dim dr As DataRow = dt.NewRow
    '                dr(0) = x.idmovimiento
    '                If Not IsNothing(x.cuenta) Then
    '                    dr(1) = x.nombreEntidad
    '                Else
    '                    dr(1) = String.Empty
    '                End If
    '                dr(2) = x.cuenta
    '                dr(3) = x.tipo
    '                dr(4) = x.Cant
    '                dr(5) = x.PUmn
    '                dr(6) = x.monto
    '                dr(7) = x.PUme
    '                dr(8) = x.montoUSD
    '                dr(9) = x.descripcion
    '                dt.Rows.Add(dr)
    '            Next
    '            dgvCompra.Table.Records.DeleteAll()
    '            'dgvCompra.DataSource = Nothing
    '            dgvCompra.DataSource = dt

    '        Else
    '            lblEstado.Text = "Ingrese un importe."
    '            Timer1.Enabled = True
    '            PanelError.Visible = True
    '            TiempoEjecutar(10)
    '            txtFondoMN.Select(0, txtFondoMN.Text.Length)
    '            Exit Sub
    '        End If


    '        If txtTotalC2MN.Value > 0 Then
    '            Dim c As New movimiento
    '            c.cuenta = "1712"
    '            c.idAsiento = 2
    '            c.idmovimiento = GetMaxIDMovimiento() + 1
    '            c.tipo = "D"
    '            c.Cant = 1
    '            c.PUmn = CDec(txtTotalC2MN.Value / c.Cant)
    '            c.PUme = CDec(txtTotalC2ME.Value / c.Cant)
    '            c.monto = txtTotalC2MN.Value
    '            c.montoUSD = txtTotalC2ME.Value
    '            ListaMovimientos.Add(c)
    '        End If
    '        If txtTotalC2MN.Value > 0 Then
    '            Dim c As New movimiento
    '            c.cuenta = "4931"
    '            c.idAsiento = 2
    '            c.idmovimiento = GetMaxIDMovimiento() + 1
    '            c.tipo = "H"
    '            c.Cant = 1
    '            c.PUmn = CDec(txtTotalC2MN.Value / c.Cant)
    '            c.PUme = CDec(txtTotalC2ME.Value / c.Cant)
    '            c.monto = txtTotalC2MN.Value
    '            c.montoUSD = txtTotalC2ME.Value
    '            ListaMovimientos.Add(c)
    '        End If

    '    End If

    'End Sub


    'Private Sub cargarDatos()
    '    Dim n As New movimiento
    '    txtGlosaAsiento.Clear()
    '    txtGlosaAsiento.Text = txtDescripcion.Text
    '    Select Case cboMoneda.SelectedValue
    '        Case 1
    '            If (txtFondoMN.Value > 0 And txtFondoME.Value > 0) Then
    '                ListaMovimientos.Clear()
    '                n.cuenta = txtCuentaO.Text
    '                n.idAsiento = lstAsiento.SelectedValue
    '                n.idmovimiento = GetMaxIDMovimiento() + 1
    '                n.tipo = "D"
    '                n.Cant = 1
    '                n.PUmn = CDec(txtFondoMN.Value / n.Cant)
    '                n.PUme = CDec(txtFondoME.Value / n.Cant)
    '                n.monto = txtFondoMN.Value
    '                n.montoUSD = txtFondoME.Value
    '                ListaMovimientos.Add(n)

    '                cargarAsientosDefault()
    '            Else
    '                lblEstado.Text = "Ingrese un importe."
    '                Timer1.Enabled = True
    '                PanelError.Visible = True
    '                TiempoEjecutar(10)
    '                txtFondoMN.Select(0, txtFondoMN.Text.Length)
    '                Exit Sub
    '            End If
    '        Case 2
    '            'Select Case lblMovimiento.Text
    '            '    Case "OTRAS ENTRADAS A CAJA"
    '            '        If (txtFondoMN.Value > 0 And txtFondoME.Value > 0) Then
    '            '            ListaMovimientos.Clear()
    '            '            n.cuenta = txtCuentaO.Text
    '            '            n.idAsiento = lstAsiento.SelectedValue
    '            '            n.idmovimiento = GetMaxIDMovimiento() + 1
    '            '            n.tipo = "D"
    '            '            n.Cant = 1
    '            '            n.PUmn = CDec(txtFondoMN.Value / n.Cant)
    '            '            n.PUme = CDec(txtFondoME.Value / n.Cant)
    '            '            n.monto = txtFondoMN.Value
    '            '            n.montoUSD = txtFondoME.Value
    '            '            ListaMovimientos.Add(n)

    '            '            cargarAsientosDefault()
    '            '        Else
    '            '            lblEstado.Text = "Ingrese un importe."
    '            '            Timer1.Enabled = True
    '            '            PanelError.Visible = True
    '            '            TiempoEjecutar(10)
    '            '            txtFondoME.Select(0, txtFondoMN.Text.Length)
    '            '            Exit Sub
    '            '        End If
    '            '    Case "OTRAS SALIDAS DE CAJA"
    '            '        If (txtFondoME.Value > 0 And txtSaldoMN.Value > 0) Then
    '            '            ListaMovimientos.Clear()
    '            '            n.cuenta = txtCuentaO.Text
    '            '            n.idAsiento = lstAsiento.SelectedValue
    '            '            n.idmovimiento = GetMaxIDMovimiento() + 1
    '            '            n.tipo = "H"
    '            '            n.Cant = 1
    '            '            n.PUmn = CDec(txtSaldoMN.Value / n.Cant)
    '            '            n.PUme = CDec(txtFondoME.Value / n.Cant)
    '            '            n.monto = txtSaldoMN.Value
    '            '            n.montoUSD = txtFondoME.Value
    '            '            ListaMovimientos.Add(n)
    '            '            dgvCompra.Table.Records.DeleteAll()
    '            '            cargarAsientosDefault()
    '            '        Else
    '            '            lblEstado.Text = "Ingrese un importe."
    '            '            Timer1.Enabled = True
    '            '            PanelError.Visible = True
    '            '            TiempoEjecutar(10)
    '            '            txtFondoME.Select(0, txtFondoMN.Text.Length)
    '            '            Exit Sub
    '            '        End If

    '            'End Select

    '    End Select
    'End Sub

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
    '            End Select
    '            If Not IsNothing(.configAlmacen) Then
    '                Dim estableSA As New establecimientoSA
    '                With almacenSA.GetUbicar_almacenPorID(.configAlmacen)
    '                    GConfiguracion.IdAlmacen = .idAlmacen
    '                    GConfiguracion.NombreAlmacen = .descripcionAlmacen
    '                    With estableSA.UbicaEstablecimientoPorID(.idEstablecimiento)
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
    '        lblEstado.Text = "Este módulo no contiene una configuración disponible, intentelo más tarde.!"
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

    Private Sub ListaDefaultDeInicio()
        'If (txtFondoMN.Value > 0 And txtFondoME.Value > 0) Then



        '////
        'dockingManager1.DockControlInAutoHideMode(GroupBox2, Syncfusion.Windows.Forms.Tools.DockingStyle.Bottom, 239)
        'dockingManager1.SetDockLabel(GroupBox2, "Asiento contable")
        'dockingManager1.CloseEnabled = False
        '///




        'Else
        'lblEstado.Text = "Ingrese un importe."
        'Timer1.Enabled = True
        'PanelError.Visible = True
        'TiempoEjecutar(10)
        ''txtFondoME.Select(0, txtFondoMN.Text.Length)
        'End If

    End Sub

    Public Function GetTableAsientos() As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("id", GetType(String))
        dt.Columns.Add("name", GetType(String))

        Dim dr As DataRow = dt.NewRow()
        dr(0) = "D"
        dr(1) = "DEBE"
        dt.Rows.Add(dr)

        Dim dr1 As DataRow = dt.NewRow()
        dr1(0) = "H"
        dr1(1) = "HABER"
        dt.Rows.Add(dr1)

        Return dt

    End Function


    Public Sub GetTableAlmacen2()
        Dim cuentaSA As New cuentaplanContableEmpresaSA
        comboTableh = New DataTable("Cuentas")
        comboTableh.Columns.Add("idCuenta")
        comboTableh.Columns.Add("descripcionCuenta")

        For Each i In cuentaSA.ObtenerCuentasPorEmpresaEscalableV2(Gempresas.IdEmpresaRuc)
            comboTableh.Rows.Add(New Object() {i.cuenta, i.descripcion})
        Next

    End Sub

    'Sub updateGlosaAsiento(asiento As asiento)
    '    '    Dim cuentaSA As New cuentaplanContableEmpresaSA

    '    Try
    '        Dim consulta = (From n In ListaAsientonTransito _
    '                   Where n.idAsiento = asiento.idAsiento).FirstOrDefault

    '        If Not IsNothing(consulta) Then
    '            consulta.glosa = txtGlosaAsiento.Text.Trim
    '        End If

    '        '      RegistrarMovimiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})
    '    Catch ex As Exception
    '        MessageBoxAdv.Show(ex.Message)
    '    End Try
    'End Sub


    Function GetMaxIDMovimiento() As Integer
        If ListaMovimientos.Count > 0 Then
            Return ListaMovimientos.Max(Function(o) o.idmovimiento)
        Else
            Return 0
        End If
    End Function

    Sub RegsitarMovimiento(nAsiento As asiento)
        Dim n As New movimiento
        n.cuenta = "10"
        n.idAsiento = nAsiento.idAsiento
        n.idmovimiento = GetMaxIDMovimiento() + 1
        n.tipo = "D"
        n.Cant = 1
        n.PUmn = 0
        n.PUme = 0
        n.monto = 0
        n.montoUSD = 0
        ListaMovimientos.Add(n)
    End Sub

    'Sub RegistrarMovimiento(nAsiento As asiento)

    '    Dim cuentaSA As New cuentaplanContableEmpresaSA
    '    Dim dt As New DataTable

    '    'dt.Reset()
    '    dt.Columns.Add("id", GetType(Integer))
    '    dt.Columns.Add("Modulo", GetType(String))
    '    dt.Columns.Add("cuenta", GetType(String))
    '    dt.Columns.Add("tipoAsiento", GetType(String))
    '    dt.Columns.Add("cant", GetType(Decimal))
    '    dt.Columns.Add("pumn", GetType(Decimal))
    '    dt.Columns.Add("importeMN", GetType(Decimal))
    '    dt.Columns.Add("pume", GetType(Decimal))
    '    dt.Columns.Add("importeME", GetType(Decimal))
    '    dt.Columns.Add("descripcion", GetType(String))

    '    Dim cosnulta = (From i In ListaMovimientos _
    '                   Where i.idAsiento = nAsiento.idAsiento).ToList

    '    For Each x In cosnulta
    '        Dim dr As DataRow = dt.NewRow
    '        dr(0) = x.idmovimiento
    '        If Not IsNothing(x.cuenta) Then
    '            dr(1) = x.nombreEntidad
    '        Else
    '            dr(1) = String.Empty
    '        End If
    '        dr(2) = x.cuenta
    '        dr(3) = x.tipo
    '        dr(4) = x.Cant
    '        dr(5) = x.PUmn
    '        dr(6) = x.monto
    '        dr(7) = x.PUme
    '        dr(8) = x.montoUSD
    '        dr(9) = x.descripcion
    '        dt.Rows.Add(dr)
    '    Next
    '    dgvCompra.Table.Records.DeleteAll()
    '    'dgvCompra.DataSource = Nothing
    '    dgvCompra.DataSource = dt
    'End Sub



    'Sub RegistrarAsientos()
    '    Dim nAsiento As New asiento

    '    If ListaAsientonTransito.Count > 0 Then
    '        nAsiento.idAsiento = ListaAsientonTransito.Count + 1
    '    Else
    '        nAsiento.idAsiento = 1
    '    End If
    '    nAsiento.Descripcion = "Asiento Nro. " & ListaAsientonTransito.Count + 1
    '    ListaAsientonTransito.Add(nAsiento)

    '    GetasientosListbox()
    'End Sub

    'Sub GetasientosListbox()
    '    Dim dt As New DataTable()
    '    dt.Columns.Add("id")
    '    dt.Columns.Add("nombre")

    '    For Each i In ListaAsientonTransito
    '        Dim dr As DataRow = dt.NewRow
    '        dr(0) = i.idAsiento
    '        dr(1) = i.Descripcion
    '        dt.Rows.Add(dr)
    '    Next

    '    lstAsiento.DisplayMember = "nombre"
    '    lstAsiento.ValueMember = "id"
    '    lstAsiento.DataSource = dt
    'End Sub


    Sub updateMovimiento(r As Record)
        '    Dim cuentaSA As New cuentaplanContableEmpresaSA

        Try
            Dim consulta = (From n In ListaMovimientos _
                       Where n.idmovimiento = r.GetValue("id")).FirstOrDefault

            If Not IsNothing(consulta) Then
                consulta.cuenta = r.GetValue("cuenta")
                Dim md = r.GetValue("Modulo").ToString
                If md.Trim.Length > 0 Then
                    consulta.nombreEntidad = r.GetValue("Modulo")
                Else
                    consulta.nombreEntidad = String.Empty
                End If

                Dim des = r.GetValue("descripcion").ToString
                If des.Trim.Length > 0 Then
                    consulta.descripcion = r.GetValue("descripcion")
                Else
                    consulta.descripcion = String.Empty
                End If
                consulta.tipo = r.GetValue("tipoAsiento")
                consulta.Cant = r.GetValue("cant")
                consulta.PUmn = r.GetValue("pumn")
                consulta.PUme = r.GetValue("pume")
                consulta.monto = r.GetValue("importeMN")
                consulta.montoUSD = r.GetValue("importeME")
            End If

            '      RegistrarMovimiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})
        Catch ex As Exception
            MessageBoxAdv.Show(ex.Message)
        End Try
    End Sub


    Private Sub cargarCtasFinan()
        If cboTipoCuenta.Text = "CUENTAS EN EFECTIVO" Then
            CargarCajasTipo("EF")
            cboDepositoHijo.Enabled = True
            Dim lista As New List(Of String)
            lista.Add("001")
            lista.Add("109")

            ListaDocPago(lista)
        ElseIf cboTipoCuenta.Text = "CUENTAS EN BANCO" Then
            CargarCajasTipo("BC")
            cboDepositoHijo.Enabled = True
            Dim lista As New List(Of String)
            lista.Add("001")
            lista.Add("007")
            lista.Add("111")

            ListaDocPago(lista)
        End If
    End Sub

    Private Sub cargarDatosCuenta(idCaja As Integer)
        Dim estadoSA As New EstadosFinancierosSA
        Dim estadoBL As New estadosFinancieros
        Dim estadoSaldoBL As New estadosFinancieros

        estadoBL = estadoSA.GetUbicar_estadosFinancierosPorID(idCaja)
        estadoSaldoBL = estadoSA.GetEstadoSaldoXEFME(idCaja)
        If (Not IsNothing(estadoBL)) Then
            cboMoneda.SelectedValue = estadoBL.codigo
            txtCuentaO.Text = estadoBL.cuenta
            lblDeudaPendienteme.Text = estadoSaldoBL.importeBalanceME
            lblDeudaPendientemn.Text = estadoSaldoBL.importeBalanceMN

            Select Case cboMoneda.SelectedValue
                Case 1
                    pnNacional.Location = New Point(53, 22)
                    pnExtranjero.Location = New Point(549, 23)

                    pnExtranjero.Visible = True
                    pnTipoCambio.Visible = True
                    pnNacional.Visible = True
                    pnSaldoTotal.Visible = False

                Case 2
                    Select Case lblMovimiento.Text
                        Case "OTRAS ENTRADAS A CAJA"
                            pnExtranjero.Visible = True
                            pnTipoCambio.Visible = True
                            pnNacional.Location = New Point(549, 23)
                            pnExtranjero.Location = New Point(53, 22)
                            pnNacional.Visible = True
                            pnSaldoTotal.Visible = False

                        Case "OTRAS SALIDAS DE CAJA"
                            pnExtranjero.Location = New Point(53, 22)
                            pnExtranjero.Visible = True
                            pnTipoCambio.Visible = False
                            pnNacional.Visible = False
                            pnSaldoTotal.Visible = True

                    End Select

            End Select
            'cbotipoOperacion.SelectedValue = 9924

        End If
    End Sub

    'Private Sub cargarAsientos1()
    '    RegistrarMovimiento(New asiento With {.idAsiento = 1})
    'End Sub


    'Private Sub cargarAsientosDefault()
    '    RegistrarMovimiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})
    'End Sub

    'Sub GetObtenerSaldoEF()
    '    Dim EFSA As New EstadosFinancierosSA

    '    txtFondoEF.DecimalValue = EFSA.GetEstadoSaldoEF(New estadosFinancieros With {.idestado = cboDepositoHijo.SelectedValue}).importeBalanceMN

    'End Sub

    'Sub UbicarAsientoPorId(asiento As asiento)
    '    Dim consulta = (From n In ListaAsientonTransito _
    '            Where n.idAsiento = asiento.idAsiento).FirstOrDefault

    '    If Not IsNothing(consulta) Then
    '        txtGlosaAsiento.Text = consulta.glosa
    '    End If
    'End Sub


    Public Sub CargarCajasTipo(strBusqueda As String)
        Dim estadoSA As New EstadosFinancierosSA
        Dim taBLASA As New tablaDetalleSA
        Dim ListaestadoBL As New List(Of estadosFinancieros)
        Dim estadoBL As New estadosFinancieros

        Try

            Me.cboDepositoHijo.DataSource = estadoSA.ObtenerEFPorCuentaFinanciera(New estadosFinancieros With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                                  .tipo = strBusqueda,
                                                                                  .tipoConsulta = StatusTipoConsulta.XEmpresa})
            Me.cboDepositoHijo.DisplayMember = "descripcion"
            Me.cboDepositoHijo.ValueMember = "idestado"
            cboDepositoHijo.SelectedValue = -1
            cboDepositoHijo.Tag = 0

            cboMoneda.ValueMember = "codigoDetalle"
            cboMoneda.DisplayMember = "descripcion"
            cboMoneda.DataSource = taBLASA.GetListaTablaDetalle(4, "1")
            cboMoneda.SelectedValue = -1

        Catch ex As Exception

        End Try
    End Sub


    Public Sub ListaDocPago(listaCuenta As List(Of String))
        Dim tablaSA As New tablaDetalleSA
        Dim tabla As New List(Of tabladetalle)

        tabla = tablaSA.GetListaTablaDetalle(1, "1")
        tabla = (From n In tabla _
                     Where listaCuenta.Contains(n.codigoDetalle) _
                    Select n).ToList
        cboTipoDocumento.DataSource = tabla
        cboTipoDocumento.ValueMember = "codigoDetalle"
        cboTipoDocumento.DisplayMember = "descripcion"
        cboTipoDocumento.SelectedValue = "001"
        'CargarDAtos()
    End Sub

    Public Sub ObtenerTablaGenerales()
        Dim tablaSA As New tablaDetalleSA

        'cboMoneda.ValueMember = "codigoDetalle"
        'cboMoneda.DisplayMember = "descripcion"
        'cboMoneda.DataSource = tablaSA.GetListaTablaDetalle(4, "1")

        cboEntidad.ValueMember = "codigoDetalle"
        cboEntidad.DisplayMember = "descripcion"
        cboEntidad.DataSource = tablaSA.GetListaTablaDetalle(3, "1")
        cboEntidad.SelectedValue = -1

        'cbotipoOperacion.ValueMember = "codigoDetalle"
        'cbotipoOperacion.DisplayMember = "descripcion"
        'cbotipoOperacion.DataSource = tablaSA.GetListaTablaDetalle(12, "1")
        'cbotipoOperacion.SelectedValue = -1
    End Sub


#End Region




#Region "Manipulación Data"
    Public Sub AsientoContableCaja()
        Dim asientoBL As New asiento
        Dim nMovimiento As New movimiento

        asientoBL = New asiento
        asientoBL.idEmpresa = Gempresas.IdEmpresaRuc
        asientoBL.idCentroCostos = GEstableciento.IdEstablecimiento

        asientoBL.idEntidad = cboDepositoHijo.SelectedValue
        asientoBL.nombreEntidad = cboDepositoHijo.Text

        asientoBL.tipoEntidad = "BC"
        asientoBL.fechaProceso = txtFechaTrans.Value
        asientoBL.codigoLibro = "1"
        asientoBL.tipo = "D"
        Select Case lblMovimiento.Text
            Case "OTRAS ENTRADAS A CAJA"
                asientoBL.tipoAsiento = ASIENTO_CONTABLE.OTRAS_ENTRADAS_CAJA
            Case "OTRAS SALIDAS DE CAJA"
                asientoBL.tipoAsiento = ASIENTO_CONTABLE.OTRAS_SALIDAS_CAJA
        End Select
        asientoBL.importeMN = CDec(txtFondoMN.Value)
        asientoBL.importeME = CDec(txtFondoME.Value)
        asientoBL.glosa = Glosa()


        Select Case lblMovimiento.Text
            Case "OTRAS ENTRADAS A CAJA"

            Case "OTRAS SALIDAS DE CAJA"

                nMovimiento = New movimiento
                nMovimiento.cuenta = "3000"
                nMovimiento.descripcion = "Por regularizar"
                nMovimiento.tipo = "D"
                nMovimiento.monto = CDec(txtFondoMN.Value)
                nMovimiento.montoUSD = CDec(txtFondoME.Value)
                nMovimiento.usuarioActualizacion = usuario.IDUsuario
                nMovimiento.fechaActualizacion = DateTime.Now
                asientoBL.movimiento.Add(nMovimiento)

                nMovimiento = New movimiento
                nMovimiento.cuenta = txtCuentaO.Text
                ' nMovimiento.descripcion = txtCajaOrigen.Text
                nMovimiento.descripcion = cboDepositoHijo.Text
                nMovimiento.tipo = "H"
                nMovimiento.monto = CDec(txtFondoMN.Value)
                nMovimiento.montoUSD = CDec(txtFondoME.Value)
                nMovimiento.usuarioActualizacion = usuario.IDUsuario
                nMovimiento.fechaActualizacion = DateTime.Now
                asientoBL.movimiento.Add(nMovimiento)

        End Select
        ListaAsientos.Add(asientoBL)
    End Sub

    Public Sub AsientoIntereses()
        Dim asientoBL As New asiento
        Dim nMovimiento As New movimiento
        If ListaAsientosConceptos.Count > 0 Then

            For Each i In ListaAsientosConceptos

                If i.descripcion = "CAPITAL" Then

                    asientoBL = New asiento
                    asientoBL.idEmpresa = Gempresas.IdEmpresaRuc
                    asientoBL.idCentroCostos = GEstableciento.IdEstablecimiento

                    asientoBL.idEntidad = cboDepositoHijo.SelectedValue
                    asientoBL.nombreEntidad = cboDepositoHijo.Text

                    asientoBL.tipoEntidad = "BC"
                    asientoBL.fechaProceso = DateTime.Now
                    asientoBL.codigoLibro = "1"
                    asientoBL.tipo = "D"
                    'Select Case lblMovimiento.Text
                    '    Case "OTRAS ENTRADAS A CAJA"
                    '        asientoBL.tipoAsiento = ASIENTO_CONTABLE.OTRAS_ENTRADAS_CAJA
                    '    Case "OTRAS SALIDAS DE CAJA"
                    asientoBL.tipoAsiento = ASIENTO_CONTABLE.OTRAS_SALIDAS_CAJA
                    'End Select
                    'asientoBL.importeMN = CDec(txtFondoMN.Value)
                    'asientoBL.importeME = CDec(txtFondoME.Value)
                    asientoBL.importeMN = CDec(i.montoSoles)
                    asientoBL.importeME = CDec(i.montoUsd)
                    asientoBL.glosa = "Por Prestamos Otrogados"

                    'If txtTipo.Text = "PERSONAL" Then

                    nMovimiento = New movimiento
                    'nMovimiento.cuenta = "1411"
                    nMovimiento.cuenta = txtcuentatipo.Text
                    nMovimiento.descripcion = "PRÉSTAMOS"
                    nMovimiento.tipo = "D"
                    'nMovimiento.tipo = txttipocuenta.Text
                    'nMovimiento.monto = CDec(txtFondoMN.Value)
                    'nMovimiento.montoUSD = CDec(txtFondoME.Value)
                    nMovimiento.monto = CDec(i.montoSoles)
                    nMovimiento.montoUSD = CDec(i.montoUsd)
                    nMovimiento.usuarioActualizacion = usuario.IDUsuario
                    nMovimiento.fechaActualizacion = DateTime.Now
                    asientoBL.movimiento.Add(nMovimiento)

                    nMovimiento = New movimiento
                    nMovimiento.cuenta = txtCuentaO.Text
                    nMovimiento.descripcion = cboDepositoHijo.Text
                    ' nMovimiento.descripcion = "EFECTIVO Y EQUIVALENTES DE EFECTIVO"
                    nMovimiento.tipo = "H"
                    'nMovimiento.monto = CDec(txtFondoMN.Value)
                    'nMovimiento.montoUSD = CDec(txtFondoME.Value)
                    nMovimiento.monto = CDec(i.montoSoles)
                    nMovimiento.montoUSD = CDec(i.montoUsd)
                    nMovimiento.usuarioActualizacion = usuario.IDUsuario
                    nMovimiento.fechaActualizacion = DateTime.Now
                    asientoBL.movimiento.Add(nMovimiento)


                    ListaAsientos.Add(asientoBL)


                Else
                    'OTROS CONCEPTOS

                    'Dim asientoBL As New asiento
                    'Dim nMovimiento As New movimiento

                    asientoBL = New asiento
                    asientoBL.idEmpresa = Gempresas.IdEmpresaRuc
                    asientoBL.idCentroCostos = GEstableciento.IdEstablecimiento

                    asientoBL.idEntidad = txtProveedor.Tag
                    asientoBL.nombreEntidad = txtProveedor.Text

                    asientoBL.tipoEntidad = "BC"
                    asientoBL.fechaProceso = DateTime.Now
                    asientoBL.codigoLibro = "1"
                    asientoBL.tipo = "D"
                    'asientoBL.tipo = i.tipo
                    asientoBL.tipoAsiento = "IPO"
                    asientoBL.importeMN = CDec(i.montoSoles)
                    asientoBL.importeME = CDec(i.montoUsd)
                    asientoBL.glosa = "Por Prestamso Otorgados"



                    'If txtTipo.Text = "PERSONAL" Then

                    nMovimiento = New movimiento
                    'nMovimiento.cuenta = "1411"
                    'nMovimiento.cuenta = txtcuentatipo.Text
                    nMovimiento.cuenta = i.cuenta
                    nMovimiento.descripcion = "PRÉSTAMOS"
                    nMovimiento.tipo = "D"
                    ' nMovimiento.tipo = txttipocuenta.Text
                    nMovimiento.monto = CDec(i.montoSoles)
                    nMovimiento.montoUSD = CDec(i.montoUsd)
                    nMovimiento.usuarioActualizacion = usuario.IDUsuario
                    nMovimiento.fechaActualizacion = DateTime.Now
                    asientoBL.movimiento.Add(nMovimiento)

                    nMovimiento = New movimiento
                    'nMovimiento.cuenta = "493"
                    nMovimiento.cuenta = i.cuentaH
                    ' nMovimiento.descripcion = txtCajaOrigen.Text
                    nMovimiento.descripcion = "INTERESES NO DEVENGADOS EN TRANSACCIONES CON TERCEROS"
                    nMovimiento.tipo = "H"
                    'nMovimiento.tipo = i.tipo
                    nMovimiento.monto = CDec(i.montoSoles)
                    nMovimiento.montoUSD = CDec(i.montoUsd)
                    nMovimiento.usuarioActualizacion = usuario.IDUsuario
                    nMovimiento.fechaActualizacion = DateTime.Now
                    asientoBL.movimiento.Add(nMovimiento)

                    ListaAsientos.Add(asientoBL)

                End If

            Next
        End If
    End Sub



    Public Sub AsientoIntereses2()
        Dim asientoBL As New asiento
        Dim nMovimiento As New movimiento

        asientoBL = New asiento
        asientoBL.idEmpresa = Gempresas.IdEmpresaRuc
        asientoBL.idCentroCostos = GEstableciento.IdEstablecimiento

        asientoBL.idEntidad = txtProveedor.Tag
        asientoBL.nombreEntidad = txtProveedor.Text

        asientoBL.tipoEntidad = "BC"
        asientoBL.fechaProceso = DateTime.Now
        asientoBL.codigoLibro = "1"
        asientoBL.tipo = "D"

        asientoBL.tipoAsiento = "IPO"


        asientoBL.importeMN = CDec(txtTotalC2MN.Value)
        asientoBL.importeME = CDec(txtTotalC2ME.Value)
        asientoBL.glosa = "Por Prestamso Otorgados"



        If txtTipo.Text = "PERSONAL" Then

            nMovimiento = New movimiento
            nMovimiento.cuenta = "1411"
            nMovimiento.descripcion = "PRÉSTAMOS"
            nMovimiento.tipo = "D"
            nMovimiento.monto = CDec(txtTotalC2MN.Value)
            nMovimiento.montoUSD = CDec(txtTotalC2ME.Value)
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nMovimiento.fechaActualizacion = DateTime.Now
            asientoBL.movimiento.Add(nMovimiento)

            nMovimiento = New movimiento
            nMovimiento.cuenta = "493"
            ' nMovimiento.descripcion = txtCajaOrigen.Text
            nMovimiento.descripcion = "INTERESES NO DEVENGADOS EN TRANSACCIONES CON TERCEROS"
            nMovimiento.tipo = "H"
            nMovimiento.monto = CDec(txtTotalC2MN.Value)
            nMovimiento.montoUSD = CDec(txtTotalC2ME.Value)
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nMovimiento.fechaActualizacion = DateTime.Now
            asientoBL.movimiento.Add(nMovimiento)

        ElseIf txtTipo.Text = "TERCEROS" Then


            nMovimiento = New movimiento
            nMovimiento.cuenta = "1612"
            nMovimiento.descripcion = "SIN GARANTÍA"
            nMovimiento.tipo = "D"
            nMovimiento.monto = CDec(txtTotalC2MN.Value)
            nMovimiento.montoUSD = CDec(txtTotalC2ME.Value)
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nMovimiento.fechaActualizacion = DateTime.Now
            asientoBL.movimiento.Add(nMovimiento)

            nMovimiento = New movimiento
            nMovimiento.cuenta = "493"
            ' nMovimiento.descripcion = txtCajaOrigen.Text
            nMovimiento.descripcion = "INTERESES NO DEVENGADOS EN TRANSACCIONES CON TERCEROS"
            nMovimiento.tipo = "H"
            nMovimiento.monto = CDec(txtTotalC2MN.Value)
            nMovimiento.montoUSD = CDec(txtTotalC2ME.Value)
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nMovimiento.fechaActualizacion = DateTime.Now
            asientoBL.movimiento.Add(nMovimiento)
        ElseIf txtTipo.Text = "RELACIONADAS" Then


            nMovimiento = New movimiento
            nMovimiento.cuenta = "1712"
            nMovimiento.descripcion = "SIN GARANTÍA"
            nMovimiento.tipo = "D"
            nMovimiento.monto = CDec(txtTotalC2MN.Value)
            nMovimiento.montoUSD = CDec(txtTotalC2ME.Value)
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nMovimiento.fechaActualizacion = DateTime.Now
            asientoBL.movimiento.Add(nMovimiento)

            nMovimiento = New movimiento
            nMovimiento.cuenta = "493"
            ' nMovimiento.descripcion = txtCajaOrigen.Text
            nMovimiento.descripcion = "INTERESES NO DEVENGADOS EN TRANSACCIONES CON TERCEROS"
            nMovimiento.tipo = "H"
            nMovimiento.monto = CDec(txtTotalC2MN.Value)
            nMovimiento.montoUSD = CDec(txtTotalC2ME.Value)
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nMovimiento.fechaActualizacion = DateTime.Now
            asientoBL.movimiento.Add(nMovimiento)
        End If


        ListaAsientos.Add(asientoBL)
    End Sub






    Public Function Glosa() As String
        Return "Por movimientos " & lblMovimiento.Text & " con fecha " & txtFechaTrans.Value
    End Function

    Sub Calculo()
        Dim tcambio As Decimal = 0
        Dim Imn As Decimal = 0
        tcambio = txtTipoCambio.Value
        If tcambio > 0 Then
            Imn = txtFondoMN.Value
            txtFondoME.Value = Math.Round(Imn / tcambio, 2)
        End If
    End Sub

    Sub CalculoDolares()
        Dim tcambio As Decimal = 0
        Dim Imn As Decimal = 0
        tcambio = txtTipoCambio.Value

        If tcambio > 0 Then
            Imn = txtFondoME.Value
            txtFondoMN.Value = Math.Round(Imn * tcambio, 2)
        End If

    End Sub

    Public Sub UbicarDocumento(intIdDocumento As Integer)
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim documentoCajaDetalleSA As New DocumentoCajaDetalleSA
        Dim alEFSA As New EstadosFinancierosSA
        Dim tablaSA As New tablaDetalleSA
        Dim establecimientoSA As New establecimientoSA
        Try
            With documentoCajaSA.GetUbicar_documentoCajaPorID(intIdDocumento)

                Select Case .tipoOperacion
                    Case "100"
                        lblMovimiento.Text = "OTRAS SALIDAS DE CAJA"
                    Case "101"
                        lblMovimiento.Text = "OTRAS ENTRADAS A CAJA"
                End Select

                lblIdDocumento.Text = .idDocumento
                txtFechaTrans.Value = .fechaProceso
                'fecha = .fechaCobro
                lblPerido.Text = .periodo
                cboTipoDocumento.SelectedValue = .tipoDocPago
                ' txtTipoDoc.Text = tablaSA.GetUbicarTablaID(1, .tipoDocPago).descripcion
                'txtNumero.Text = .numeroDoc
                cboMoneda.SelectedValue = .moneda

                With alEFSA.GetUbicar_estadosFinancierosPorID(.entidadFinanciera)
                    'txtEstablecimientoDestino.ValueMember = .idEstablecimiento
                    'txtEstablecimientoDestino.Text = establecimientoSA.UbicaEstablecimientoPorID(.idEstablecimiento).nombre
                    'txtCajaOrigen.ValueMember = .idestado
                    'txtCajaOrigen.Text = .descripcion

                    cboDepositoHijo.ValueMember = .idestado
                    cboDepositoHijo.Text = .descripcion

                    txtCuentaO.Text = .cuenta
                    'Select Case .tipo
                    '    Case "EF"
                    '        cboTipoCuentaD.Text = "EFECTIVO"
                    '    Case "BC"
                    '        cboTipoCuentaD.Text = "BANCO"
                    'End Select
                End With

                Select Case .TipoDocumentoPago
                    Case "001"

                        txtNumOper.Text = .numeroOperacion
                        txtCuentaCorriente.Text = .ctaCorrienteDeposito
                        cboEntidad.SelectedValue = .bancoEntidad
                        txtFechaEmision.Value = .fechaProceso
                        txtFechaCobro.Value = .fechaCobro
                        'txtNumOper.Text = .numeroDoc
                        'txtCtaInterbancaria.Text = .ctaIntebancaria

                    Case "007" 'cheques

                        txtNumOper.Text = .numeroOperacion
                        txtCuentaCorriente.Text = .ctaCorrienteDeposito
                        cboEntidad.SelectedValue = .bancoEntidad
                        txtFechaEmision.Value = .fechaProceso
                        txtFechaCobro.Value = .fechaCobro
                        'txtNumero.Text = .numeroDoc
                        'txtCtaInterbancaria.Text = .ctaIntebancaria
                    Case "111"

                        txtNumOper.Text = .numeroOperacion
                        txtCuentaCorriente.Text = .ctaCorrienteDeposito
                        cboEntidad.SelectedValue = .bancoEntidad
                        txtFechaEmision.Value = .fechaProceso
                        txtFechaCobro.Value = .fechaCobro
                        'txtNumero.Text = .numeroDoc
                        'txtCtaInterbancaria.Text = .ctaIntebancaria
                    Case "109"

                        txtNumOper.Text = .numeroOperacion
                        txtCuentaCorriente.Text = .ctaCorrienteDeposito
                        cboEntidad.SelectedValue = .bancoEntidad
                        txtFechaEmision.Value = .fechaProceso
                        txtFechaCobro.Value = .fechaCobro
                        'txtNumero.Text = .numeroDoc
                        'txtCtaInterbancaria.Text = .ctaIntebancaria
                End Select

                txtTipoCambio.Value = .tipoCambio
                txtFondoMN.Value = .montoSoles
                txtFondoME.Value = .montoUsd
                '   txtGlosa.Text = .glosa
            End With

            With documentoCajaDetalleSA.GetUbicar_DetallePorIdDocumento(intIdDocumento).First
                lblSecuenciaDetalle.Text = .secuencia
            End With
            ' cboMovimiento.Enabled = False
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub

    Public Sub GrabarOtrosMovimientos()
        Dim documentoSA As New DocumentoSA
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim ndocumento As New documento
        Dim ndocumentoCaja As New documentoCaja
        Dim ndocumentoCajaDetalle As New documentoCajaDetalle
        Dim ListadocumentoCajaDetalle As New List(Of documentoCajaDetalle)
        Dim asiento As New asiento
        Dim ListaAsiento As New List(Of asiento)
        Dim idNumeracion As Integer

        Dim objDocumentoEO As New prestamos
        Dim docPrestamo As New documentoPrestamos
        Dim listaPrestamo As New List(Of documentoPrestamos)


        dgvPrestamos.TableControl.CurrentCell.EndEdit()
        dgvPrestamos.TableControl.Table.TableDirty = True
        dgvPrestamos.TableControl.Table.EndEdit()

        With ndocumento
            '.idDocumento = lblIdDocumento.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento

            Dim idpres As Integer = CInt(lblIdPrestamo.Text)

            .idPrestamo = idpres
            '       .idProyecto = GProyectos.IdProyectoActividad
            .tipoDoc = "9901"
            .fechaProceso = txtFechaTrans.Value
            idNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
            .nroDoc = idNumeracion
            .idOrden = Nothing
            'Select Case lblMovimiento.Text
            '    Case "OTRAS ENTRADAS A CAJA"
            '        .tipoOperacion = "9909"
            '    Case "OTRAS SALIDAS DE CAJA"
            .tipoOperacion = "100"
            'End Select
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With

        With ndocumentoCaja
            '   .idDocumento = lblIdDocumento.Text
            .periodo = PeriodoGeneral
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .tipoMovimiento = TIPO_COMPRA.PAGO.PAGADO
            .TipoDocumentoPago = cboTipoDocumento.SelectedValue
            .codigoProveedor = Nothing 'txtPersona.ValueMember
            '.fechaProceso = fecha
            '.fechaCobro = fecha
            .tipoDocPago = cboTipoDocumento.SelectedValue
            .numeroDoc = idNumeracion

            .moneda = cboMoneda.SelectedValue

            ''///////////////////////
            'Select Case lblMovimiento.Text
            '    Case "OTRAS ENTRADAS A CAJA"
            '        .codigoLibro = "9909"
            '        .tipoMovimiento = "DC"
            '        .movimiento = "OEC"

            '        .entidadFinanciera = cboDepositoHijo.SelectedValue
            '    Case "OTRAS SALIDAS DE CAJA"
            .codigoLibro = "1"
            .tipoMovimiento = MovimientoCaja.SalidaDinero
            .tipoOperacion = "100"
            .entidadFinanciera = cboDepositoHijo.SelectedValue

            'End Select
            '////////////////////////////
            If cboTipoDocumento.SelectedValue = "001" Then
                .numeroOperacion = txtNumOper.Text.Trim
                .ctaCorrienteDeposito = Nothing
                .ctaIntebancaria = Nothing
                .bancoEntidad = cboEntidad.SelectedValue
                .fechaProceso = txtFechaTrans.Value
                .fechaCobro = Date.Now
                .entregado = "SI"

            ElseIf cboTipoDocumento.SelectedValue = "007" Then ' cheques
                .numeroOperacion = txtNumOper.Text.Trim
                .ctaCorrienteDeposito = Nothing
                .ctaIntebancaria = Nothing
                .bancoEntidad = Nothing
                .fechaProceso = txtFechaEmision.Value
                .fechaCobro = txtFechaCobro.Value
                .entregado = "NO"
            ElseIf cboTipoDocumento.SelectedValue = "111" Then
                .numeroOperacion = txtNumOper.Text.Trim
                .ctaCorrienteDeposito = Nothing
                .ctaIntebancaria = Nothing
                .bancoEntidad = Nothing
                .fechaProceso = txtFechaEmision.Value
                .fechaCobro = txtFechaCobro.Value
                .entregado = "NO"
            ElseIf cboTipoDocumento.SelectedValue = "109" Then
                .numeroOperacion = txtNumOper.Text.Trim
                .ctaCorrienteDeposito = Nothing
                .ctaIntebancaria = Nothing
                .bancoEntidad = Nothing
                .fechaCobro = txtFechaTrans.Value
                .fechaProceso = Date.Now
                .entregado = "NO"
            End If
            .tipoCambio = txtTipoCambio.Value
            .montoSoles = txtFondoMN.Value
            .montoUsd = txtFondoME.Value

            .glosa = Glosa()
            .usuarioModificacion = usuario.IDUsuario
            .fechaModificacion = DateTime.Now
        End With

        ndocumento.documentoCaja = ndocumentoCaja

        Select Case cboMoneda.SelectedValue
            Case 1
                ndocumentoCajaDetalle = New documentoCajaDetalle
                ndocumentoCajaDetalle.fecha = txtFechaTrans.Value
                ndocumentoCajaDetalle.idItem = "00"
                ndocumentoCajaDetalle.DetalleItem = Glosa()
                ndocumentoCajaDetalle.montoSoles = txtFondoMN.Value
                ndocumentoCajaDetalle.montoUsd = txtFondoME.Value

                ndocumentoCajaDetalle.entregado = "SI"
                ndocumentoCajaDetalle.diferTipoCambio = txtTipoCambio.Value

                ndocumentoCajaDetalle.documentoAfectado = 0
                ndocumentoCajaDetalle.usuarioModificacion = usuario.IDUsuario
                ndocumentoCajaDetalle.fechaModificacion = Date.Now


                ListadocumentoCajaDetalle.Add(ndocumentoCajaDetalle)
            Case 2

                ndocumentoCajaDetalle = New documentoCajaDetalle
                ndocumentoCajaDetalle.fecha = txtFechaTrans.Value
                ndocumentoCajaDetalle.idItem = "00"
                ndocumentoCajaDetalle.DetalleItem = Glosa()
                'ndocumentoCajaDetalle.montoSoles = txtFondoMN.Value

                'If (lblMovimiento.Tag = "OES") Then
                '    ndocumentoCajaDetalle.montoUsd = txtFondoME.Value
                '    ndocumentoCajaDetalle.montoUsdRef = txtFondoME.Value
                '    ndocumentoCajaDetalle.montoSoles = txtFondoMN.Value
                '    ndocumentoCajaDetalle.diferTipoCambio = txtTipoCambio.Value
                'Else
                ndocumentoCajaDetalle.montoUsd = txtFondoME.Value

                'End If


                ndocumentoCajaDetalle.entregado = "SI"
                '  ndocumentoCajaDetalle.DiferenciaTipoCambio = 0

                ndocumentoCajaDetalle.documentoAfectado = 0
                ndocumentoCajaDetalle.usuarioModificacion = usuario.IDUsuario
                ndocumentoCajaDetalle.fechaModificacion = Date.Now

                ListadocumentoCajaDetalle.Add(ndocumentoCajaDetalle)
        End Select

        'AsientoContableCaja()
        AsientoIntereses()
        'AsientoIntereses2()
        ndocumento.asiento = ListaAsientos
        ndocumento.documentoCaja.documentoCajaDetalle = ListadocumentoCajaDetalle

        '""""

        With objDocumentoEO

            .idDocumento = lblIdPrestamo.Text
            .fechaDesembolso = DateTimePickerAdv1.Value
            .modoPago = cboModo.Text
            .fechaInicio = DateTimePickerAdv2.Value
            .diaPago = CInt(cboDiaPago.Text)
            .plazoDias = CInt(cbodiaplazo.Text)
            ' .nroDoc = txtNumeroCompr.Text

        End With

        For Each i As Record In dgvPrestamos.Table.Records

            docPrestamo = New documentoPrestamos
            ''''''''
            docPrestamo.idDocumento = i.GetValue("idDocumento")
            docPrestamo.idCuota = i.GetValue("idCuota")
            docPrestamo.fechaVcto = i.GetValue("FechaPago")
            docPrestamo.fechaPlazo = i.GetValue("FechaPlazo")
            listaPrestamo.Add(docPrestamo)
        Next

        ''///
        Dim xCodigoDoc As Integer = documentoCajaSA.SaveDesembolso(ndocumento, objDocumentoEO, listaPrestamo)

        lblEstado.Text = "Caja registrada correctamente!"
        lblEstado.Image = My.Resources.ok4

        Dispose()
    End Sub

#End Region



    Public Class Categoria

        Private _name As String
        Private _id As Integer
        Private _cuenta As String

        Public Sub New(ByVal name As String, ByVal id As Integer, ByVal cuenta As String)
            _name = name
            _id = id
            _cuenta = cuenta
        End Sub
        Sub New()
            ' TODO: Complete member initialization 
        End Sub

        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property
        Public Property Id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal value As Integer)
                _id = value
            End Set
        End Property

        Public Property Cuenta() As String
            Get
                Return _cuenta
            End Get
            Set(ByVal value As String)
                _cuenta = value
            End Set
        End Property

    End Class

    Dim comboTableh As New DataTable

    Private Sub frmNuevoDesembolso_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub


    Private Sub frmNuevoDesembolso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetTableAlmacen2()

        txtTotalC2MN.Value = txtInteresMN.Value + txtSeguroMN.Value + txtPortesMN.Value + txtOtroMN.Value + txtEnvMN.Value
        txtTotalC2ME.Value = txtInteresME.Value + txtSeguroME.Value + txtPortesME.Value + txtOtroME.Value + txtEnvME.Value

    End Sub

    Private Sub cboTipoCuenta_Click(sender As Object, e As EventArgs) Handles cboTipoCuenta.Click

    End Sub

    Private Sub cboTipoCuenta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoCuenta.SelectedIndexChanged
        'cboDepositoHijo.SelectedValue = -1
        cboMoneda.SelectedValue = -1
        ' txtTipoCambio.Value = 0.0
        txtCuentaCorriente.Clear()
        'txtFondoEF.DecimalValue = 0
        cboTipoDocumento.SelectedValue = -1
        txtDescripcion.Clear()
        'cboEntidad.SelectedValue = -1
        'cbotipoOperacion.SelectedValue = -1
        txtNumOper.Clear()
        Select Case lblMovimiento.Text
            Case "OTRAS ENTRADAS A CAJA"
                pnEntidad.Visible = False
                pnFecha.Visible = False
                cboDepositoHijo.Enabled = False
            Case "OTRAS SALIDAS DE CAJA"
                pnEntidad.Visible = True
                pnFecha.Visible = False
                cboDepositoHijo.Enabled = False
        End Select
        cargarCtasFinan()
    End Sub

    Private Sub cboDepositoHijo_Click(sender As Object, e As EventArgs) Handles cboDepositoHijo.Click
        cboDepositoHijo.Tag = 1
    End Sub

    Private Sub cboDepositoHijo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDepositoHijo.SelectedIndexChanged
        Dim value As Object = Me.cboDepositoHijo.SelectedValue
        'txtTipoCambio.Value = 0.0
        txtCuentaCorriente.Clear()
        'txtFondoEF.DecimalValue = 0
        'cboTipoDocumento.SelectedValue = -1
        txtDescripcion.Clear()
        txtNumOper.Clear()

        If (cboDepositoHijo.Tag = 1) Then
            If IsNumeric(value) Then
                cargarDatosCuenta(CInt(value))
            Else
                'txtFondoEF.DecimalValue = 0
            End If
        End If


        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboTipoDocumento_Click(sender As Object, e As EventArgs) Handles cboTipoDocumento.Click

    End Sub

    Private Sub cboTipoDocumento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoDocumento.SelectedIndexChanged
        If cboTipoDocumento.ValueMember.Trim.Length > 0 Then
            txtNumOper.Clear()
            txtCuentaCorriente.Clear()
            If cboTipoDocumento.SelectedValue = "109" Then 'EFECTIVO (que se genere un vocher de caja con los datos del comprobante que se está pagando) 

                pnEntidad.Visible = False
                pnFecha.Visible = False
                Label17.Text = "NRO. VOUCHER:"


            ElseIf cboTipoDocumento.SelectedValue = "007" Then ' CHEQUES

                pnEntidad.Visible = False
                pnFecha.Visible = True
                Label17.Text = "NRO. CHEQUE:"
                pnFecha.Location = New Point(25, 43)

            ElseIf cboTipoDocumento.SelectedValue = "001" Then ' DEPOSITO EN CUENTA 
                Select Case lblMovimiento.Text
                    Case "OTRAS ENTRADAS A CAJA"
                        pnEntidad.Visible = False
                        pnFecha.Visible = False
                        Label17.Text = "NRO. OPERACIÓN:"
                    Case "OTRAS SALIDAS DE CAJA"
                        pnEntidad.Visible = True
                        pnFecha.Visible = False
                        Label17.Text = "NRO. OPERACIÓN:"
                End Select


            ElseIf cboTipoDocumento.SelectedValue = "111" Then ' CHEQUE NO NEGOCIABLE 
                pnEntidad.Visible = False
                pnFecha.Visible = True
                Label17.Text = "NRO. CHEQUE:"
                pnFecha.Location = New Point(25, 43)

            End If
        End If
    End Sub

    Private Sub txtFondoMN_ValueChanged(sender As Object, e As EventArgs) Handles txtFondoMN.ValueChanged
        ' If (txtFondoMN.Value <= lblDeudaPendientemn.Value) Then
        'txtFondoMN.Select(0, txtFondoMN.Text.Length)
        'cargarDatos()
        ' Else
        ' lblEstado.Text = "Seleccione Otra Caja con mas monto"
        ' PanelError.Visible = True
        'Timer1.Enabled = True
        ' TiempoEjecutar(10)
        'txtFondoMN.Value = 0.0
        ' txtFondoMN.Select(0, txtFondoMN.Text.Length)
        ' End If
    End Sub


    Private Sub dgvCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs)

    End Sub

    Private Sub txtCuotas_ValueChanged(sender As Object, e As EventArgs) Handles txtCuotas.ValueChanged

    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs)
        'UpdateFechasPrestamo()
    End Sub

    Private Sub DateTimePickerAdv2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerAdv2.ValueChanged
        ActFechas()
    End Sub





    Private Sub Label26_Click(sender As Object, e As EventArgs) Handles Label26.Click

    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
      
        If Not txtCuentaCorriente.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese un numero de voucher"
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
            cboDepositoHijo.Select()
            Exit Sub
        End If

        If Not DateTimePickerAdv1.Value.Date <= DateTimePickerAdv2.Value.Date Then

            lblEstado.Text = "Actualize la fecha de inicio"
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
            cboDepositoHijo.Select()
            Exit Sub

        End If


        If Not lblDeudaPendientemn.Value >= txtFondoMN.Value Then
            lblEstado.Text = "Monto insuficiente en Caja."
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
            cboDepositoHijo.Select()
            Exit Sub
        End If

        If Not cboDepositoHijo.Text.Length > 0 Then
            lblEstado.Text = "Ingrese la entidad financiera."
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
            cboDepositoHijo.Select()
            Exit Sub
        End If


        Select Case cboMoneda.SelectedValue
            Case 1
                If Not txtTipoCambio.Value > 0 Then
                    lblEstado.Text = "Debe ingresar un tipo de cambio mayor a cero!"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                    txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                    Exit Sub
                End If

                If Not txtFondoMN.Value > 0 Then
                    lblEstado.Text = "Debe ingresar un importe mayor a cero!"
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                    txtFondoMN.Select(0, txtFondoMN.Text.Length)
                    Exit Sub
                End If

            Case 2



        End Select

        If cboTipoDocumento.SelectedValue = "001" Then
            If Not cboTipoDocumento.Text.Length > 0 Then
                lblEstado.Text = "Ingrese tipo documento."
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                cboTipoDocumento.Select()
                Exit Sub
            End If

            If Not txtNumOper.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el número de operación."
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                txtNumOper.Select()
                Exit Sub
            End If


            Select Case lblMovimiento.Text
                Case "OTRAS ENTRADAS A CAJA"

                Case "OTRAS SALIDAS DE CAJA"
                    If Not txtCuentaCorriente.Text.Trim.Length > 0 Then
                        lblEstado.Text = "Ingrese el número de cuenta."
                        Timer1.Enabled = True
                        PanelError.Visible = True
                        TiempoEjecutar(10)
                        txtCuentaCorriente.Select()
                        Exit Sub
                    End If
            End Select

        ElseIf cboTipoDocumento.SelectedValue = "007" Then

        ElseIf cboTipoDocumento.SelectedValue = "109" Then
            If Not cboTipoDocumento.Text.Length > 0 Then
                lblEstado.Text = "Ingrese tipo documento."
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                cboTipoDocumento.Select()
                Exit Sub
            End If

            If Not txtNumOper.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el número de operación."
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                txtNumOper.Select()
                Exit Sub
            End If

        ElseIf cboTipoDocumento.SelectedValue = "111" Then

        End If

        GrabarOtrosMovimientos()
    End Sub

    Private Sub dgvPrestamos_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvPrestamos.QueryCellStyleInfo
        If e.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell OrElse e.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell Then
            If e.TableCellIdentity.Column.Name = "FechaPago" Then
                e.Style.Format = "dd/MM/yyyy"
                ' e.Style.Format = "dd/MM/yyyy h:mm:ss tt"
            End If
            e.Handled = True
        End If
        
        If e.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell OrElse e.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell Then
            If e.TableCellIdentity.Column.Name = "FechaPlazo" Then
                e.Style.Format = "dd/MM/yyyy"
                ' e.Style.Format = "dd/MM/yyyy h:mm:ss tt"
            End If
            e.Handled = True
        End If
    End Sub

    Private Sub dgvPrestamos_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvPrestamos.TableControlCellClick

    End Sub

    Private Sub dgvPrestamos_TableControlCheckBoxClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvPrestamos.TableControlCheckBoxClick
       
    End Sub

    Private Sub dgvPrestamos_TableControlCurrentCellAcceptedChanges(sender As Object, e As GridTableControlCancelEventArgs) Handles dgvPrestamos.TableControlCurrentCellAcceptedChanges
       
    End Sub

    Private Sub dgvPrestamos_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles dgvPrestamos.TableControlCurrentCellCloseDropDown
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim ColRowIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.RowIndex

        If Not IsNothing(Me.dgvPrestamos.Table.CurrentRecord) Then
            Select Case ColIndex
                Case 4 ' cantidad

                    dgvPrestamos.TableControl.CurrentCell.EndEdit()
                    dgvPrestamos.TableControl.Table.TableDirty = True
                    dgvPrestamos.TableControl.Table.EndEdit()

                    If Not IsDate(Me.dgvPrestamos.TableModel(ColRowIndex - 1, 4).CellValue) Then
                        ' MessageBox.Show("Primer Caso")
                        '1ercaso
                        If Not IsDate(Me.dgvPrestamos.TableModel(ColRowIndex + 1, 4).CellValue) Then

                            If (Me.dgvPrestamos.TableModel(ColRowIndex, 4).CellValue) <= DateTimePickerAdv2.Value Then

                               MessageBox.Show("Ingrese una fecha igual o mayor al de inicio")
                            Else
                                If (Me.dgvPrestamos.TableModel(ColRowIndex, 4).CellValue) > DateTimePickerAdv3.Value Then
                                    MessageBox.Show("Ingrese una fecha igual o menor ala fecha maxima")
                                End If

                            End If

                        Else

                            If (Me.dgvPrestamos.TableModel(ColRowIndex, 4).CellValue) >= DateTimePickerAdv2.Value Then

                                If (Me.dgvPrestamos.TableModel(ColRowIndex, 4).CellValue) > (Me.dgvPrestamos.TableModel(ColRowIndex + 1, 4).CellValue) Then
                                    MessageBox.Show("Ingrese una Fecha menor que la cuota siguiente")
                                End If
                            Else
                                MessageBox.Show("La Fecha debe ser mayor o igual que la fecha de inicio")
                            End If
                        End If

                    Else


                        If (Me.dgvPrestamos.TableModel(ColRowIndex, 4).CellValue) < DateTimePickerAdv2.Value Then


                            If Not IsDate(Me.dgvPrestamos.TableModel(ColRowIndex + 1, 4).CellValue) Then
                                If (Me.dgvPrestamos.TableModel(ColRowIndex, 4).CellValue) <= DateTimePickerAdv3.Value Then
                                Else

                                    MessageBox.Show("Ingrese una fecha mejor que la fecha maxima")
                                End If

                            Else

                                If (Me.dgvPrestamos.TableModel(ColRowIndex, 4).CellValue) < (Me.dgvPrestamos.TableModel(ColRowIndex + 1, 4).CellValue) Then
                                Else

                                    MessageBox.Show("Ingrese una Fecha menor que la cuota siguiente")
                                End If


                            End If



                        Else
                            MessageBox.Show("Ingrese una fecha mayor que ala de inicio")
                        End If


                    End If

            End Select
        End If
    End Sub

    Private Sub dgvPrestamos_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvPrestamos.TableControlCurrentCellEditingComplete
       
    End Sub

    Private Sub cboMoneda_Click(sender As Object, e As EventArgs) Handles cboMoneda.Click

    End Sub
End Class