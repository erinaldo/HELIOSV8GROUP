Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping

Public Class frmKardex
    Inherits frmMaster
    'Private htmluiControl1 As Syncfusion.Windows.Forms.HTMLUI.HTMLUIControl
    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        QGlobalColorSchemeManager1.Global.CurrentTheme = Qios.DevSuite.Components.QColorScheme.LunaBlueThemeName
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        '  UbicarAlmacenVirtual()
        lblPerido.Text = PeriodoGeneral
        ObtenerAlmacenes()
        ConfigDock()
        SetRenderer()
    End Sub

    Private Sub SetRenderer()
        Dim styleRenderer1 As New StyledRenderer()
        tbIGV.Renderer = styleRenderer1
        'Dim styleRenderer2 As New StyledRenderer()
        'tbIGV.Renderer = styleRenderer2
        'Dim styleRenderer3 As New StyledRenderer()
        'toggleButton11.Renderer = styleRenderer3
        'Dim styleRenderer4 As New StyledRenderer()
        'toggleButton12.Renderer = styleRenderer4
        ' Panel2.Visible = False
    End Sub

#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean

        If Not parpadear Then
            lblEstado.ForeColor = lblEstado.BackColor
            lblEstado.BackColor = Color.Yellow
        Else
            lblEstado.ForeColor = SystemColors.WindowText
        End If

        parpadear = Not parpadear
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If TiempoRestante > 0 Then
            parpadeo()

            'lblAgregar.Visible = True
            'lblMensaje.Visible = True
            'tsSave.Enabled = False
            'lblMensaje.Text = "Agregar otro en: " & TiempoRestante
            TiempoRestante = TiempoRestante - 1
        ElseIf TiempoRestante = 0 Then
            Timer1.Enabled = False
            lblEstado.ForeColor = Color.Navy
            lblEstado.BackColor = Color.Transparent
            '      Dispose()
        Else
            Timer1.Enabled = False
            'Ejecuta tu función cuando termina el tiempo
            TiempoEjecutar(10)

        End If
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
    Private Sub ConfigDock()
        '  Me.dockingManager1.DockControl(Me.Panel2, Me, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 200)
        '    dockingManager1.DockControlInAutoHideMode(Panel2, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 200)
        'DockingClientPanel1.BringToFront()
        'dockingManager1.MDIActivatedVisibility = True
        'Me.DockingClientPanel1.AutoScroll = True
        ''  Me.dockingClientPanel1.SizeToFit = True
        'Me.DockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        ' dockingManager1.SetDockVisibility ( panel)
        '   dockingManager1.SetDockLabel(Panel2, "Existencias")
    End Sub

    'Private Sub LoadKardexProductosPorRango(intIdAlmacen As Integer, intIdItem As Integer, desde As Date, hasta As Date)
    '    Dim inventario As New inventarioMovimientoSA
    '    Dim totalsaldo As Decimal = 0
    '    Dim cantidadSaldo As Decimal = 0
    '    Dim PrecioPromedio As Decimal = 0
    '    Dim tablaSA As New tablaDetalleSA
    '    Try
    '        lsvKardex.CheckBoxes = False
    '        lsvKardex.Items.Clear()
    '        lsvKardex.Columns.Clear()
    '        lsvKardex.Columns.Add("Fc Movimiento", 150) '0
    '        lsvKardex.Columns.Add("idEmpresa", 0) '1
    '        lsvKardex.Columns.Add("idAlmacen", 0) '2
    '        lsvKardex.Columns.Add("Movimiento", 0) '3
    '        lsvKardex.Columns.Add("idItem", 0) '4
    '        lsvKardex.Columns.Add("Descripción", 210) '5
    '        lsvKardex.Columns.Add("U.M.", 80) '6
    '        lsvKardex.Columns.Add("Cant Entrada", 70, HorizontalAlignment.Right) '7
    '        lsvKardex.Columns.Add("Pr Unit E.", 80, HorizontalAlignment.Right) '8
    '        lsvKardex.Columns.Add("Costo Entrada", 70, HorizontalAlignment.Right) '9

    '        lsvKardex.Columns.Add("Cant Salida", 70, HorizontalAlignment.Right) '10
    '        lsvKardex.Columns.Add("Pr Unit S.", 85, HorizontalAlignment.Right) '11
    '        lsvKardex.Columns.Add("Costo Salida", 71, HorizontalAlignment.Right) '12

    '        lsvKardex.Columns.Add("Cant Saldo", 75, HorizontalAlignment.Right) '13
    '        lsvKardex.Columns.Add("Costo Saldo", 75, HorizontalAlignment.Right) '14
    '        lsvKardex.Columns.Add("P.M.", 80, HorizontalAlignment.Right) '15
    '        lsvKardex.Columns.Add("Glosa", 250) '16
    '        lsvKardex.Columns.Add("ID", 0) '17
    '        lsvKardex.Columns.Add("Nro. Doc (referencia)", 100) '18
    '        lsvKardex.Columns.Add("Cta Contable", 0) '19
    '        lsvKardex.Columns.Add("Tipo Reg.", 0) '20
    '        lsvKardex.Columns.Add("IDDoc", 0) '21
    '        lsvKardex.Columns.Add("Tipo producto", 0) '22
    '        lsvKardex.Columns.Add("Gravado", 0) '23
    '        lsvKardex.Columns.Add("Costo Saldo US", 0) '24

    '        Dim x = 0
    '        For Each i As InventarioMovimiento In inventario.ObtenerProdPorAlmacenesPorRango(intIdAlmacen, intIdItem, desde, hasta)
    '            If x = 0 Then
    '                totalsaldo += i.monto
    '                cantidadSaldo += i.cantidad
    '                If (totalsaldo = 0) Then
    '                    PrecioPromedio = 0
    '                Else
    '                    If cantidadSaldo > 0 Then
    '                        PrecioPromedio = totalsaldo / cantidadSaldo
    '                    End If
    '                End If
    '            Else
    '                totalsaldo = Math.Round(totalsaldo + CDec(i.monto), 2)
    '                cantidadSaldo = cantidadSaldo + CDec(i.cantidad)
    '                If totalsaldo = 0 Or totalsaldo < 0 Or cantidadSaldo = 0 Then
    '                    PrecioPromedio = 0
    '                Else
    '                    If cantidadSaldo > 0 Then
    '                        PrecioPromedio = totalsaldo / cantidadSaldo
    '                    End If
    '                End If

    '            End If

    '            If i.tipoRegistro = "E" Or i.tipoRegistro = "EA" Or i.tipoRegistro = "EC" Then
    '                'lsvKardex.lis 
    '                Dim n As New ListViewItem(FormatDateTime(i.fecha, DateFormat.GeneralDate))
    '                n.SubItems.Add(i.idEmpresa)
    '                n.SubItems.Add(i.idAlmacen)
    '                n.SubItems.Add(i.tipoRegistro)
    '                n.SubItems.Add(i.idItem)
    '                n.SubItems.Add(i.nombreItem)
    '                n.SubItems.Add(tablaSA.GetUbicarTablaID(6, i.unidad).descripcion)
    '                n.SubItems.Add(FormatNumber(i.cantidad, 2))
    '                n.SubItems.Add(FormatNumber(i.precUnite, 2))
    '                n.SubItems.Add(FormatNumber(i.monto, 2))
    '                n.SubItems.Add("0.00")
    '                n.SubItems.Add("0.00")
    '                n.SubItems.Add("0.00")
    '                n.SubItems.Add(FormatNumber(cantidadSaldo, 2))
    '                n.SubItems.Add(FormatNumber(totalsaldo, 2))
    '                n.SubItems.Add(FormatNumber(PrecioPromedio, 2))
    '                n.SubItems.Add(i.glosa)
    '                n.SubItems.Add(i.idInventario)
    '                n.SubItems.Add(i.NumDocCompra)
    '                n.SubItems.Add(i.cuentaOrigen)
    '                n.SubItems.Add(i.tipoRegistro)
    '                n.SubItems.Add(i.idDocumento)
    '                n.SubItems.Add(i.tipoProducto)
    '                n.SubItems.Add(i.destinoGravadoItem)
    '                n.SubItems.Add(FormatNumber(i.montoUSD, 2))
    '                lsvKardex.Items.Add(n)

    '            ElseIf i.tipoRegistro = "S" Or i.tipoRegistro = "D" Then
    '                Dim n As New ListViewItem(FormatDateTime(i.fecha, DateFormat.GeneralDate))
    '                n.SubItems.Add(i.idEmpresa)
    '                n.SubItems.Add(i.idAlmacen)
    '                n.SubItems.Add(i.tipoRegistro)
    '                n.SubItems.Add(i.idItem)
    '                n.SubItems.Add(i.nombreItem)
    '                n.SubItems.Add(tablaSA.GetUbicarTablaID(6, i.unidad).descripcion)
    '                n.SubItems.Add("0.00")
    '                n.SubItems.Add("0.00")
    '                n.SubItems.Add("0.00")
    '                n.SubItems.Add(FormatNumber(i.cantidad, 2))
    '                n.SubItems.Add(FormatNumber(i.precUnite, 2))
    '                n.SubItems.Add(FormatNumber(i.monto, 2))
    '                n.SubItems.Add(FormatNumber(cantidadSaldo, 2))
    '                n.SubItems.Add(FormatNumber(totalsaldo, 2))
    '                n.SubItems.Add(FormatNumber(PrecioPromedio, 2))
    '                n.SubItems.Add(i.glosa)
    '                n.SubItems.Add(i.idInventario)
    '                n.SubItems.Add(i.NumDocCompra)
    '                n.SubItems.Add(i.cuentaOrigen)
    '                n.SubItems.Add(i.tipoRegistro)
    '                n.SubItems.Add(i.idDocumento)
    '                n.SubItems.Add(i.tipoProducto)
    '                n.SubItems.Add(i.destinoGravadoItem)
    '                n.SubItems.Add(FormatNumber(i.montoUSD, 2))
    '                lsvKardex.Items.Add(n)

    '            End If
    '        Next
    '        lblEstado.Text = "Registros encontrdos: " & lsvKardex.Items.Count
    '        lblEstado.Image = My.Resources.ok4

    '        colorearColumnas_Listview(lsvKardex)
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub


    'Private Sub LoadKardexProductosPorMes(intIdAlmacen As Integer, intIdItem As Integer, periodo As Integer, mes As String)
    '    Dim inventario As New inventarioMovimientoSA
    '    Dim totalsaldo As Decimal = 0
    '    Dim cantidadSaldo As Decimal = 0
    '    Dim PrecioPromedio As Decimal = 0
    '    Dim tablaSA As New tablaDetalleSA
    '    Try
    '        lsvKardex.CheckBoxes = False
    '        lsvKardex.Items.Clear()
    '        lsvKardex.Columns.Clear()
    '        lsvKardex.Columns.Add("Fc Movimiento", 150) '0
    '        lsvKardex.Columns.Add("idEmpresa", 0) '1
    '        lsvKardex.Columns.Add("idAlmacen", 0) '2
    '        lsvKardex.Columns.Add("Movimiento", 0) '3
    '        lsvKardex.Columns.Add("idItem", 0) '4
    '        lsvKardex.Columns.Add("Descripción", 210) '5
    '        lsvKardex.Columns.Add("U.M.", 80) '6
    '        lsvKardex.Columns.Add("Cant Entrada", 70, HorizontalAlignment.Right) '7
    '        lsvKardex.Columns.Add("Pr Unit E.", 80, HorizontalAlignment.Right) '8
    '        lsvKardex.Columns.Add("Costo Entrada", 70, HorizontalAlignment.Right) '9

    '        lsvKardex.Columns.Add("Cant Salida", 70, HorizontalAlignment.Right) '10
    '        lsvKardex.Columns.Add("Pr Unit S.", 85, HorizontalAlignment.Right) '11
    '        lsvKardex.Columns.Add("Costo Salida", 71, HorizontalAlignment.Right) '12

    '        lsvKardex.Columns.Add("Cant Saldo", 75, HorizontalAlignment.Right) '13
    '        lsvKardex.Columns.Add("Costo Saldo", 75, HorizontalAlignment.Right) '14
    '        lsvKardex.Columns.Add("P.M.", 80, HorizontalAlignment.Right) '15
    '        lsvKardex.Columns.Add("Glosa", 250) '16
    '        lsvKardex.Columns.Add("ID", 0) '17
    '        lsvKardex.Columns.Add("Nro. Doc (referencia)", 100) '18
    '        lsvKardex.Columns.Add("Cta Contable", 0) '19
    '        lsvKardex.Columns.Add("Tipo Reg.", 0) '20
    '        lsvKardex.Columns.Add("IDDoc", 0) '21
    '        lsvKardex.Columns.Add("Tipo producto", 0) '22
    '        lsvKardex.Columns.Add("Gravado", 0) '23
    '        lsvKardex.Columns.Add("Costo Saldo US", 0) '24

    '        Dim x = 0
    '        For Each i As InventarioMovimiento In inventario.ObtenerProdPorAlmacenesPorMes(intIdAlmacen, intIdItem, periodo, mes)
    '            If x = 0 Then
    '                totalsaldo += i.monto
    '                cantidadSaldo += i.cantidad
    '                If (totalsaldo = 0) Then
    '                    PrecioPromedio = 0
    '                Else
    '                    If cantidadSaldo > 0 Then
    '                        PrecioPromedio = totalsaldo / cantidadSaldo
    '                    End If
    '                End If
    '            Else
    '                totalsaldo = Math.Round(totalsaldo + CDec(i.monto), 2)
    '                cantidadSaldo = cantidadSaldo + CDec(i.cantidad)
    '                If totalsaldo = 0 Or totalsaldo < 0 Or cantidadSaldo = 0 Then
    '                    PrecioPromedio = 0
    '                Else
    '                    If cantidadSaldo > 0 Then
    '                        PrecioPromedio = totalsaldo / cantidadSaldo
    '                    End If
    '                End If

    '            End If

    '            If i.tipoRegistro = "E" Or i.tipoRegistro = "EA" Or i.tipoRegistro = "EC" Then
    '                'lsvKardex.lis 
    '                Dim n As New ListViewItem(FormatDateTime(i.fecha, DateFormat.GeneralDate))
    '                n.SubItems.Add(i.idEmpresa)
    '                n.SubItems.Add(i.idAlmacen)
    '                n.SubItems.Add(i.tipoRegistro)
    '                n.SubItems.Add(i.idItem)
    '                n.SubItems.Add(i.nombreItem)
    '                n.SubItems.Add(tablaSA.GetUbicarTablaID(6, i.unidad).descripcion)
    '                n.SubItems.Add(FormatNumber(i.cantidad, 2))
    '                n.SubItems.Add(FormatNumber(i.precUnite, 2))
    '                n.SubItems.Add(FormatNumber(i.monto, 2))
    '                n.SubItems.Add("0.00")
    '                n.SubItems.Add("0.00")
    '                n.SubItems.Add("0.00")
    '                n.SubItems.Add(FormatNumber(cantidadSaldo, 2))
    '                n.SubItems.Add(FormatNumber(totalsaldo, 2))
    '                n.SubItems.Add(FormatNumber(PrecioPromedio, 2))
    '                n.SubItems.Add(i.glosa)
    '                n.SubItems.Add(i.idInventario)
    '                n.SubItems.Add(i.NumDocCompra)
    '                n.SubItems.Add(i.cuentaOrigen)
    '                n.SubItems.Add(i.tipoRegistro)
    '                n.SubItems.Add(i.idDocumento)
    '                n.SubItems.Add(i.tipoProducto)
    '                n.SubItems.Add(i.destinoGravadoItem)
    '                n.SubItems.Add(FormatNumber(i.montoUSD, 2))
    '                lsvKardex.Items.Add(n)

    '            ElseIf i.tipoRegistro = "S" Or i.tipoRegistro = "D" Then
    '                Dim n As New ListViewItem(FormatDateTime(i.fecha, DateFormat.GeneralDate))
    '                n.SubItems.Add(i.idEmpresa)
    '                n.SubItems.Add(i.idAlmacen)
    '                n.SubItems.Add(i.tipoRegistro)
    '                n.SubItems.Add(i.idItem)
    '                n.SubItems.Add(i.nombreItem)
    '                n.SubItems.Add(tablaSA.GetUbicarTablaID(6, i.unidad).descripcion)
    '                n.SubItems.Add("0.00")
    '                n.SubItems.Add("0.00")
    '                n.SubItems.Add("0.00")
    '                n.SubItems.Add(FormatNumber(i.cantidad, 2))
    '                n.SubItems.Add(FormatNumber(i.precUnite, 2))
    '                n.SubItems.Add(FormatNumber(i.monto, 2))
    '                n.SubItems.Add(FormatNumber(cantidadSaldo, 2))
    '                n.SubItems.Add(FormatNumber(totalsaldo, 2))
    '                n.SubItems.Add(FormatNumber(PrecioPromedio, 2))
    '                n.SubItems.Add(i.glosa)
    '                n.SubItems.Add(i.idInventario)
    '                n.SubItems.Add(i.NumDocCompra)
    '                n.SubItems.Add(i.cuentaOrigen)
    '                n.SubItems.Add(i.tipoRegistro)
    '                n.SubItems.Add(i.idDocumento)
    '                n.SubItems.Add(i.tipoProducto)
    '                n.SubItems.Add(i.destinoGravadoItem)
    '                n.SubItems.Add(FormatNumber(i.montoUSD, 2))
    '                lsvKardex.Items.Add(n)

    '            End If
    '        Next
    '        lblEstado.Text = "Registros encontrdos: " & lsvKardex.Items.Count
    '        lblEstado.Image = My.Resources.ok4

    '        colorearColumnas_Listview(lsvKardex)
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

    Private Function getParentTableKardexPorPeriodo() As DataTable
        Dim tablaSA As New tablaDetalleSA
        Dim inventario As New inventarioMovimientoSA
        Dim totalsaldo As Decimal = 0
        Dim cantidadSaldo As Decimal = 0
        Dim PrecioPromedio As Decimal = 0
        Dim x = 0

        Dim dt As New DataTable("kárdex - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("Movimiento", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha", GetType(String)))
        dt.Columns.Add(New DataColumn("destinoGravadoItem", GetType(String)))
        dt.Columns.Add(New DataColumn("nombreItem", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("tipoProducto", GetType(String)))
        dt.Columns.Add(New DataColumn("unidad", GetType(String)))

        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto1", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))



        Dim str As String
        For Each i As InventarioMovimiento In inventario.ObtenerProdPorAlmacenesPorMes(txtAlmacen.ValueMember, lstProductos.SelectedValue, AnioGeneral, MesGeneral)
            If x = 0 Then
                totalsaldo += i.monto
                cantidadSaldo += i.cantidad
                If (totalsaldo = 0) Then
                    PrecioPromedio = 0
                Else
                    If cantidadSaldo > 0 Then
                        PrecioPromedio = totalsaldo / cantidadSaldo
                    End If
                End If
            Else
                totalsaldo = Math.Round(totalsaldo + CDec(i.monto), 2)
                cantidadSaldo = cantidadSaldo + CDec(i.cantidad)
                If totalsaldo = 0 Or totalsaldo < 0 Or cantidadSaldo = 0 Then
                    PrecioPromedio = 0
                Else
                    If cantidadSaldo > 0 Then
                        PrecioPromedio = totalsaldo / cantidadSaldo
                    End If
                End If

            End If


            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fecha).ToString("dd-MMM hh:mm tt ")
            dr(0) = tablaSA.GetUbicarTablaID(12, i.tipoOperacion).descripcion
            dr(1) = str
            dr(2) = i.destinoGravadoItem
            dr(3) = i.nombreItem
            dr(4) = i.tipoProducto
            dr(5) = i.unidad

            Select Case i.tipoRegistro
                Case "E", "EA", "EC"
                    dr(6) = (FormatNumber(i.cantidad, 2))
                    If CDec(i.monto) > 0 And CDec(i.cantidad) > 0 Then
                        dr(7) = Math.Round(CDec(i.monto) / CDec(i.cantidad), 2)
                    Else
                        dr(7) = 0
                    End If

                    '(FormatNumber(i.precUnite, 2))
                    dr(8) = (FormatNumber(i.monto, 2))
                    dr(9) = ("0.00")
                    dr(10) = ("0.00")
                    dr(11) = ("0.00")
                    dr(12) = (FormatNumber(cantidadSaldo, 2))
                    dr(13) = (FormatNumber(totalsaldo, 2))
                    dr(14) = (FormatNumber(PrecioPromedio, 2))
                Case "S", "D"
                    dr(6) = ("0.00")
                    dr(7) = ("0.00")
                    dr(8) = ("0.00")
                    dr(9) = (FormatNumber(i.cantidad, 2))
                    If CDec(i.monto) > 0 And CDec(i.cantidad) > 0 Then
                        dr(10) = Math.Round(CDec(i.monto) / CDec(i.cantidad), 2)
                    Else
                        dr(10) = 0
                    End If
                    ' (FormatNumber(i.precUnite, 2))
                    dr(11) = (FormatNumber(i.monto, 2))
                    dr(12) = (FormatNumber(cantidadSaldo, 2))
                    dr(13) = (FormatNumber(totalsaldo, 2))
                    dr(14) = (FormatNumber(PrecioPromedio, 2))
            End Select
            dr(15) = i.idDocumento
            dt.Rows.Add(dr)
        Next
        Return dt



    End Function

    Private Function getParentTableKardexPorPeriodoAll() As DataTable
        Dim tablaSA As New tablaDetalleSA
        Dim inventario As New inventarioMovimientoSA
        Dim totalsaldo As Decimal = 0
        Dim cantidadSaldo As Decimal = 0
        Dim PrecioPromedio As Decimal = 0
        Dim x = 0

        Dim dt As New DataTable("kárdex - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("Movimiento", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha", GetType(String)))
        dt.Columns.Add(New DataColumn("destinoGravadoItem", GetType(String)))
        dt.Columns.Add(New DataColumn("nombreItem", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("tipoProducto", GetType(String)))
        dt.Columns.Add(New DataColumn("unidad", GetType(String)))

        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto1", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))


        Dim str As String
        Dim codItem As Integer = 0
        Dim cou As Integer = 0
        For Each i As InventarioMovimiento In inventario.ObtenerProdPorAlmacenesPorMesAll(txtAlmacen.ValueMember, AnioGeneral, MesGeneral)
            If cou = 0 Then
                If x = 0 Then
                    totalsaldo += i.monto
                    cantidadSaldo += i.cantidad
                    If (totalsaldo = 0) Then
                        PrecioPromedio = 0
                    Else
                        If cantidadSaldo > 0 Then
                            PrecioPromedio = totalsaldo / cantidadSaldo
                        End If
                    End If
                Else
                    totalsaldo = Math.Round(totalsaldo + CDec(i.monto), 2)
                    cantidadSaldo = cantidadSaldo + CDec(i.cantidad)
                    If totalsaldo = 0 Or totalsaldo < 0 Or cantidadSaldo = 0 Then
                        PrecioPromedio = 0
                    Else
                        If cantidadSaldo > 0 Then
                            PrecioPromedio = totalsaldo / cantidadSaldo
                        End If
                    End If

                End If
            Else
                If codItem = i.idItem Then
                    If x = 0 Then
                        totalsaldo += i.monto
                        cantidadSaldo += i.cantidad
                        If (totalsaldo = 0) Then
                            PrecioPromedio = 0
                        Else
                            If cantidadSaldo > 0 Then
                                PrecioPromedio = totalsaldo / cantidadSaldo
                            End If
                        End If
                    Else
                        totalsaldo = Math.Round(totalsaldo + CDec(i.monto), 2)
                        cantidadSaldo = cantidadSaldo + CDec(i.cantidad)
                        If totalsaldo = 0 Or totalsaldo < 0 Or cantidadSaldo = 0 Then
                            PrecioPromedio = 0
                        Else
                            If cantidadSaldo > 0 Then
                                PrecioPromedio = totalsaldo / cantidadSaldo
                            End If
                        End If

                    End If
                Else
                    cantidadSaldo = i.cantidad
                    totalsaldo = i.monto
                End If
            End If

            codItem = i.idItem

            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fecha).ToString("dd-MMM HH:mm tt ")
            dr(0) = tablaSA.GetUbicarTablaID(12, i.tipoOperacion).descripcion
            dr(1) = str
            dr(2) = i.destinoGravadoItem
            dr(3) = i.nombreItem
            dr(4) = i.tipoProducto
            dr(5) = i.unidad

            Select Case i.tipoRegistro
                Case "E", "EA", "EC"
                    dr(6) = (FormatNumber(i.cantidad, 2))
                    If CDec(i.monto) > 0 And CDec(i.cantidad) > 0 Then
                        dr(7) = Math.Round(CDec(i.monto) / CDec(i.cantidad), 2)
                    Else
                        dr(7) = 0
                    End If

                    '(FormatNumber(i.precUnite, 2))
                    dr(8) = (FormatNumber(i.monto, 2))
                    dr(9) = ("0.00")
                    dr(10) = ("0.00")
                    dr(11) = ("0.00")
                    dr(12) = (FormatNumber(cantidadSaldo, 2))
                    dr(13) = (FormatNumber(totalsaldo, 2))
                    dr(14) = (FormatNumber(PrecioPromedio, 2))
                Case "S", "D"
                    dr(6) = ("0.00")
                    dr(7) = ("0.00")
                    dr(8) = ("0.00")
                    dr(9) = (FormatNumber(i.cantidad, 2))
                    If CDec(i.monto) > 0 And CDec(i.cantidad) > 0 Then
                        dr(10) = Math.Round(CDec(i.monto) / CDec(i.cantidad), 2)
                    Else
                        dr(10) = 0
                    End If
                    ' (FormatNumber(i.precUnite, 2))
                    dr(11) = (FormatNumber(i.monto, 2))
                    dr(12) = (FormatNumber(cantidadSaldo, 2))
                    dr(13) = (FormatNumber(totalsaldo, 2))
                    dr(14) = (FormatNumber(PrecioPromedio, 2))
            End Select
            dr(15) = i.idDocumento
            dt.Rows.Add(dr)
            cou += 1
        Next
        Return dt



    End Function

    Private Function getParentTableKardexPorAnio() As DataTable
        Dim tablaSA As New tablaDetalleSA
        Dim inventario As New inventarioMovimientoSA
        Dim totalsaldo As Decimal = 0
        Dim cantidadSaldo As Decimal = 0
        Dim PrecioPromedio As Decimal = 0
        Dim x = 0

        Dim dt As New DataTable("kárdex - año " & AnioGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("Movimiento", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha", GetType(String)))
        dt.Columns.Add(New DataColumn("destinoGravadoItem", GetType(String)))
        dt.Columns.Add(New DataColumn("nombreItem", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("tipoProducto", GetType(String)))
        dt.Columns.Add(New DataColumn("unidad", GetType(String)))

        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto1", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))


        Dim str As String
        For Each i As InventarioMovimiento In inventario.ObtenerProdPorAlmacenesPorAnio(txtAlmacen.ValueMember, lstProductos.SelectedValue, AnioGeneral)
            If x = 0 Then
                totalsaldo += i.monto
                cantidadSaldo += i.cantidad
                If (totalsaldo = 0) Then
                    PrecioPromedio = 0
                Else
                    If cantidadSaldo > 0 Then
                        PrecioPromedio = totalsaldo / cantidadSaldo
                    End If
                End If
            Else
                totalsaldo = Math.Round(totalsaldo + CDec(i.monto), 2)
                cantidadSaldo = cantidadSaldo + CDec(i.cantidad)
                If totalsaldo = 0 Or totalsaldo < 0 Or cantidadSaldo = 0 Then
                    PrecioPromedio = 0
                Else
                    If cantidadSaldo > 0 Then
                        PrecioPromedio = totalsaldo / cantidadSaldo
                    End If
                End If

            End If


            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fecha).ToString("dd-MMM hh:mm tt ")
            dr(0) = tablaSA.GetUbicarTablaID(12, i.tipoOperacion).descripcion
            dr(1) = str
            dr(2) = i.destinoGravadoItem
            dr(3) = i.nombreItem
            dr(4) = i.tipoProducto
            dr(5) = i.unidad

            Select Case i.tipoRegistro
                Case "E", "EA", "EC"
                    dr(6) = (FormatNumber(i.cantidad, 2))
                    If CDec(i.monto) > 0 And CDec(i.cantidad) > 0 Then
                        dr(7) = Math.Round(CDec(i.monto) / CDec(i.cantidad), 2)
                    Else
                        dr(7) = 0
                    End If

                    '(FormatNumber(i.precUnite, 2))
                    dr(8) = (FormatNumber(i.monto, 2))
                    dr(9) = ("0.00")
                    dr(10) = ("0.00")
                    dr(11) = ("0.00")
                    dr(12) = (FormatNumber(cantidadSaldo, 2))
                    dr(13) = (FormatNumber(totalsaldo, 2))
                    dr(14) = (FormatNumber(PrecioPromedio, 2))
                Case "S", "D"
                    dr(6) = ("0.00")
                    dr(7) = ("0.00")
                    dr(8) = ("0.00")
                    dr(9) = (FormatNumber(i.cantidad, 2))
                    If CDec(i.monto) > 0 And CDec(i.cantidad) > 0 Then
                        dr(10) = Math.Round(CDec(i.monto) / CDec(i.cantidad), 2)
                    Else
                        dr(10) = 0
                    End If
                    ' (FormatNumber(i.precUnite, 2))
                    dr(11) = (FormatNumber(i.monto, 2))
                    dr(12) = (FormatNumber(cantidadSaldo, 2))
                    dr(13) = (FormatNumber(totalsaldo, 2))
                    dr(14) = (FormatNumber(PrecioPromedio, 2))
            End Select
            dr(15) = i.idDocumento
            dt.Rows.Add(dr)
        Next
        Return dt



    End Function

    Private Function getParentTableKardexPorAnioAll() As DataTable
        Dim tablaSA As New tablaDetalleSA
        Dim inventario As New inventarioMovimientoSA
        Dim totalsaldo As Decimal = 0
        Dim cantidadSaldo As Decimal = 0
        Dim PrecioPromedio As Decimal = 0
        Dim x = 0

        Dim dt As New DataTable("kárdex - año " & AnioGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("Movimiento", GetType(String)))
        dt.Columns.Add(New DataColumn("fecha", GetType(String)))
        dt.Columns.Add(New DataColumn("destinoGravadoItem", GetType(String)))
        dt.Columns.Add(New DataColumn("nombreItem", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("tipoProducto", GetType(String)))
        dt.Columns.Add(New DataColumn("unidad", GetType(String)))

        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto1", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))


        Dim str As String
        Dim codItem As Integer = 0
        Dim cou As Integer = 0
        For Each i As InventarioMovimiento In inventario.ObtenerProdPorAlmacenesPorAnioAll(txtAlmacen.ValueMember, AnioGeneral)

            If cou = 0 Then
                If x = 0 Then
                    totalsaldo += i.monto
                    cantidadSaldo += i.cantidad
                    If (totalsaldo = 0) Then
                        PrecioPromedio = 0
                    Else
                        If cantidadSaldo > 0 Then
                            PrecioPromedio = totalsaldo / cantidadSaldo
                        End If
                    End If
                Else
                    totalsaldo = Math.Round(totalsaldo + CDec(i.monto), 2)
                    cantidadSaldo = cantidadSaldo + CDec(i.cantidad)
                    If totalsaldo = 0 Or totalsaldo < 0 Or cantidadSaldo = 0 Then
                        PrecioPromedio = 0
                    Else
                        If cantidadSaldo > 0 Then
                            PrecioPromedio = totalsaldo / cantidadSaldo
                        End If
                    End If

                End If
            Else
                If codItem = i.idItem Then
                    If x = 0 Then
                        totalsaldo += i.monto
                        cantidadSaldo += i.cantidad
                        If (totalsaldo = 0) Then
                            PrecioPromedio = 0
                        Else
                            If cantidadSaldo > 0 Then
                                PrecioPromedio = totalsaldo / cantidadSaldo
                            End If
                        End If
                    Else
                        totalsaldo = Math.Round(totalsaldo + CDec(i.monto), 2)
                        cantidadSaldo = cantidadSaldo + CDec(i.cantidad)
                        If totalsaldo = 0 Or totalsaldo < 0 Or cantidadSaldo = 0 Then
                            PrecioPromedio = 0
                        Else
                            If cantidadSaldo > 0 Then
                                PrecioPromedio = totalsaldo / cantidadSaldo
                            End If
                        End If

                    End If
                Else
                    totalsaldo = i.monto
                    cantidadSaldo = i.cantidad
                End If
            End If



            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fecha).ToString("dd-MMM HH:mm tt ")
            dr(0) = tablaSA.GetUbicarTablaID(12, i.tipoOperacion).descripcion
            dr(1) = str
            dr(2) = i.destinoGravadoItem
            dr(3) = i.nombreItem
            dr(4) = i.tipoProducto
            dr(5) = i.unidad

            codItem = i.idItem
            Select Case i.tipoRegistro
                Case "E", "EA", "EC"
                    dr(6) = (FormatNumber(i.cantidad, 2))
                    If CDec(i.monto) > 0 And CDec(i.cantidad) > 0 Then
                        dr(7) = Math.Round(CDec(i.monto) / CDec(i.cantidad), 2)
                    Else
                        dr(7) = 0
                    End If

                    '(FormatNumber(i.precUnite, 2))
                    dr(8) = (FormatNumber(i.monto, 2))
                    dr(9) = ("0.00")
                    dr(10) = ("0.00")
                    dr(11) = ("0.00")
                    dr(12) = (FormatNumber(cantidadSaldo, 2))
                    dr(13) = (FormatNumber(totalsaldo, 2))
                    dr(14) = (FormatNumber(PrecioPromedio, 2))
                Case "S", "D"
                    dr(6) = ("0.00")
                    dr(7) = ("0.00")
                    dr(8) = ("0.00")
                    dr(9) = (FormatNumber(i.cantidad, 2))
                    If CDec(i.monto) > 0 And CDec(i.cantidad) > 0 Then
                        dr(10) = Math.Round(CDec(i.monto) / CDec(i.cantidad), 2)
                    Else
                        dr(10) = 0
                    End If
                    ' (FormatNumber(i.precUnite, 2))
                    dr(11) = (FormatNumber(i.monto, 2))
                    dr(12) = (FormatNumber(cantidadSaldo, 2))
                    dr(13) = (FormatNumber(totalsaldo, 2))
                    dr(14) = (FormatNumber(PrecioPromedio, 2))
            End Select
            dr(15) = i.idDocumento
            dt.Rows.Add(dr)
            cou += 1
        Next
        Return dt



    End Function

    Private Function getParentTableKardexPorDia() As DataTable
        Dim inventario As New inventarioMovimientoSA
        Dim totalsaldo As Decimal = 0
        Dim cantidadSaldo As Decimal = 0
        Dim PrecioPromedio As Decimal = 0
        Dim x = 0

        Dim dt As New DataTable("kárdex - día " & DateTime.Now.Date & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("fecha", GetType(String)))
        dt.Columns.Add(New DataColumn("destinoGravadoItem", GetType(String)))
        dt.Columns.Add(New DataColumn("nombreItem", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("tipoProducto", GetType(String)))
        dt.Columns.Add(New DataColumn("unidad", GetType(String)))

        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto1", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto2", GetType(Decimal)))


        Dim str As String
        For Each i As InventarioMovimiento In inventario.ObtenerProdPorAlmacenes(txtAlmacen.ValueMember, lstProductos.SelectedValue)
            If x = 0 Then
                totalsaldo += i.monto
                cantidadSaldo += i.cantidad
                If (totalsaldo = 0) Then
                    PrecioPromedio = 0
                Else
                    If cantidadSaldo > 0 Then
                        PrecioPromedio = totalsaldo / cantidadSaldo
                    End If
                End If
            Else
                totalsaldo = Math.Round(totalsaldo + CDec(i.monto), 2)
                cantidadSaldo = cantidadSaldo + CDec(i.cantidad)
                If totalsaldo = 0 Or totalsaldo < 0 Or cantidadSaldo = 0 Then
                    PrecioPromedio = 0
                Else
                    If cantidadSaldo > 0 Then
                        PrecioPromedio = totalsaldo / cantidadSaldo
                    End If
                End If

            End If


            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fecha).ToString("dd-MMM hh:mm tt ")
            dr(0) = str
            dr(1) = i.destinoGravadoItem
            dr(2) = i.nombreItem
            dr(3) = i.tipoProducto
            dr(4) = i.unidad

            Select Case i.tipoRegistro
                Case "E", "EA", "EC"
                    dr(5) = (FormatNumber(i.cantidad, 2))
                    dr(6) = Math.Round(CDec(i.monto) / CDec(i.cantidad), 2) ' (FormatNumber(i.precUnite, 2))
                    dr(7) = (FormatNumber(i.monto, 2))
                    dr(8) = ("0.00")
                    dr(9) = ("0.00")
                    dr(10) = ("0.00")
                    dr(11) = (FormatNumber(cantidadSaldo, 2))
                    dr(12) = (FormatNumber(totalsaldo, 2))
                    dr(13) = (FormatNumber(PrecioPromedio, 2))
                Case "S", "D"
                    dr(5) = ("0.00")
                    dr(6) = ("0.00")
                    dr(7) = ("0.00")
                    dr(8) = (FormatNumber(i.cantidad, 2))
                    dr(9) = Math.Round(CDec(i.monto) / CDec(i.cantidad), 2) ' (FormatNumber(i.precUnite, 2))
                    dr(10) = (FormatNumber(i.monto, 2))
                    dr(11) = (FormatNumber(cantidadSaldo, 2))
                    dr(12) = (FormatNumber(totalsaldo, 2))
                    dr(13) = (FormatNumber(PrecioPromedio, 2))
            End Select

            dt.Rows.Add(dr)
        Next
        Return dt



    End Function

    Private Function getParentTableKardexPorDiaAll() As DataTable
        Dim inventario As New inventarioMovimientoSA
        Dim totalsaldo As Decimal = 0
        Dim cantidadSaldo As Decimal = 0
        Dim PrecioPromedio As Decimal = 0
        Dim x = 0

        Dim dt As New DataTable("kárdex - día " & DateTime.Now.Date & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("fecha", GetType(String)))
        dt.Columns.Add(New DataColumn("destinoGravadoItem", GetType(String)))
        dt.Columns.Add(New DataColumn("nombreItem", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("tipoProducto", GetType(String)))
        dt.Columns.Add(New DataColumn("unidad", GetType(String)))

        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto1", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("cantidad2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precUnite2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto2", GetType(Decimal)))

        Dim str As String
        Dim codItem As Integer = 0
        Dim cou As Integer = 0
        For Each i As InventarioMovimiento In inventario.ObtenerProdPorAlmacenesXdiaAll(txtAlmacen.ValueMember)
            If cou = 0 Then
                If x = 0 Then
                    totalsaldo += i.monto
                    cantidadSaldo += i.cantidad
                    If (totalsaldo = 0) Then
                        PrecioPromedio = 0
                    Else
                        If cantidadSaldo > 0 Then
                            PrecioPromedio = totalsaldo / cantidadSaldo
                        End If
                    End If
                Else
                    totalsaldo = Math.Round(totalsaldo + CDec(i.monto), 2)
                    cantidadSaldo = cantidadSaldo + CDec(i.cantidad)
                    If totalsaldo = 0 Or totalsaldo < 0 Or cantidadSaldo = 0 Then
                        PrecioPromedio = 0
                    Else
                        If cantidadSaldo > 0 Then
                            PrecioPromedio = totalsaldo / cantidadSaldo
                        End If
                    End If

                End If
            Else
                If codItem = i.idItem Then
                    If x = 0 Then
                        totalsaldo += i.monto
                        cantidadSaldo += i.cantidad
                        If (totalsaldo = 0) Then
                            PrecioPromedio = 0
                        Else
                            If cantidadSaldo > 0 Then
                                PrecioPromedio = totalsaldo / cantidadSaldo
                            End If
                        End If
                    Else
                        totalsaldo = Math.Round(totalsaldo + CDec(i.monto), 2)
                        cantidadSaldo = cantidadSaldo + CDec(i.cantidad)
                        If totalsaldo = 0 Or totalsaldo < 0 Or cantidadSaldo = 0 Then
                            PrecioPromedio = 0
                        Else
                            If cantidadSaldo > 0 Then
                                PrecioPromedio = totalsaldo / cantidadSaldo
                            End If
                        End If

                    End If
                Else
                    totalsaldo = i.monto
                    cantidadSaldo = i.cantidad
                End If
            End If
            codItem = i.idItem
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fecha).ToString("dd-MMM hh:mm tt ")
            dr(0) = str
            dr(1) = i.destinoGravadoItem
            dr(2) = i.nombreItem
            dr(3) = i.tipoProducto
            dr(4) = i.unidad

            Select Case i.tipoRegistro
                Case "E", "EA", "EC"
                    dr(5) = (FormatNumber(i.cantidad, 2))
                    dr(6) = Math.Round(CDec(i.monto) / CDec(i.cantidad), 2) ' (FormatNumber(i.precUnite, 2))
                    dr(7) = (FormatNumber(i.monto, 2))
                    dr(8) = ("0.00")
                    dr(9) = ("0.00")
                    dr(10) = ("0.00")
                    dr(11) = (FormatNumber(cantidadSaldo, 2))
                    dr(12) = (FormatNumber(totalsaldo, 2))
                    dr(13) = (FormatNumber(PrecioPromedio, 2))
                Case "S", "D"
                    dr(5) = ("0.00")
                    dr(6) = ("0.00")
                    dr(7) = ("0.00")
                    dr(8) = (FormatNumber(i.cantidad, 2))
                    dr(9) = Math.Round(CDec(i.monto) / CDec(i.cantidad), 2) ' (FormatNumber(i.precUnite, 2))
                    dr(10) = (FormatNumber(i.monto, 2))
                    dr(11) = (FormatNumber(cantidadSaldo, 2))
                    dr(12) = (FormatNumber(totalsaldo, 2))
                    dr(13) = (FormatNumber(PrecioPromedio, 2))
            End Select

            dt.Rows.Add(dr)
        Next
        Return dt



    End Function

    Public Sub ListaKardexPorPeriodo()
        Try
            Dim parentTable As DataTable = getParentTableKardexPorPeriodo()
            Me.dgvCompra.DataSource = parentTable
            dgvCompra.TableDescriptor.Relations.Clear()
            'dgvCompra.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.a
            'dgvCompra.TableOptions.ListBoxSelectionMode = SelectionMode.One
            'dgvCompra.Appearance.AnyRecordFieldCell.Enabled = False
            dgvCompra.GroupDropPanel.Visible = True
            dgvCompra.TableDescriptor.GroupedColumns.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ListaKardexPorPeriodoAll()
        Try
            Dim parentTable As DataTable = getParentTableKardexPorPeriodoAll()
            Me.dgvCompra.DataSource = parentTable
            dgvCompra.TableDescriptor.Relations.Clear()
            'dgvCompra.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.a
            'dgvCompra.TableOptions.ListBoxSelectionMode = SelectionMode.One
            'dgvCompra.Appearance.AnyRecordFieldCell.Enabled = False
            dgvCompra.GroupDropPanel.Visible = True
            dgvCompra.TableDescriptor.GroupedColumns.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ListaKardexPorAnio()
        Try
            Dim parentTable As DataTable = getParentTableKardexPorAnio()
            Me.dgvCompra.DataSource = parentTable
            dgvCompra.TableDescriptor.Relations.Clear()
            'dgvCompra.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.a
            'dgvCompra.TableOptions.ListBoxSelectionMode = SelectionMode.One
            'dgvCompra.Appearance.AnyRecordFieldCell.Enabled = False
            dgvCompra.GroupDropPanel.Visible = True
            dgvCompra.TableDescriptor.GroupedColumns.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ListaKardexPorAnioAll()
        Try
            Dim parentTable As DataTable = getParentTableKardexPorAnioAll()
            Me.dgvCompra.DataSource = parentTable
            dgvCompra.TableDescriptor.Relations.Clear()
            'dgvCompra.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.a
            'dgvCompra.TableOptions.ListBoxSelectionMode = SelectionMode.One
            'dgvCompra.Appearance.AnyRecordFieldCell.Enabled = False
            dgvCompra.GroupDropPanel.Visible = True
            dgvCompra.TableDescriptor.GroupedColumns.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ListaKardexPorDia()
        Try
            Dim parentTable As DataTable = getParentTableKardexPorDia()
            Me.dgvCompra.DataSource = parentTable
            dgvCompra.TableDescriptor.Relations.Clear()
            dgvCompra.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            dgvCompra.TableOptions.ListBoxSelectionMode = SelectionMode.One
            dgvCompra.Appearance.AnyRecordFieldCell.Enabled = False
            dgvCompra.GroupDropPanel.Visible = True
            dgvCompra.TableDescriptor.GroupedColumns.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ListaKardexPorDiaAll()
        Try
            Dim parentTable As DataTable = getParentTableKardexPorDiaAll()
            Me.dgvCompra.DataSource = parentTable
            dgvCompra.TableDescriptor.Relations.Clear()
            dgvCompra.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            dgvCompra.TableOptions.ListBoxSelectionMode = SelectionMode.One
            dgvCompra.Appearance.AnyRecordFieldCell.Enabled = False
            dgvCompra.GroupDropPanel.Visible = True
            dgvCompra.TableDescriptor.GroupedColumns.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ObtenerAlmacenes()
        Dim almacenSA As New almacenSA
        Dim almacen As New List(Of almacen)
        Dim tablaSA As New tablaDetalleSA

        almacen = almacenSA.GetListar_almacenes(GEstableciento.IdEstablecimiento)
        lstAlmacen.ValueMember = "idAlmacen"
        lstAlmacen.DisplayMember = "descripcionAlmacen"
        lstAlmacen.DataSource = almacen

        cboTipoExistencia.DisplayMember = "descripcion"
        cboTipoExistencia.ValueMember = "codigoDetalle"
        cboTipoExistencia.DataSource = tablaSA.GetListaTablaDetalle(5, "1")
    End Sub

    Public Sub BuscarProductoPorDescripcion(strNombreProducto As String)
        Dim totalesAlmacenSA As New TotalesAlmacenSA
        Dim totalesAlmacenBE As New List(Of totalesAlmacen)

        totalesAlmacenBE = totalesAlmacenSA.GetListaProductosTAPorProducto(txtAlmacen.ValueMember, strNombreProducto)
        lstProductos.DisplayMember = "descripcion"
        lstProductos.ValueMember = "idItem"
        lstProductos.DataSource = totalesAlmacenBE
        lblEstado.Text = "Productos encontrados: " & lstProductos.Items.Count
    End Sub

    Private Sub colorearColumnas_Listview(ByVal listview1 As System.Windows.Forms.ListView)

        For i As Integer = 0 To listview1.Items.Count - 1

            listview1.Items(i).UseItemStyleForSubItems = False

            If listview1.Items(i).SubItems.Count > 1 Then

                listview1.Items(i).SubItems(0).BackColor = Color.Cornsilk

                listview1.Items(i).SubItems(7).BackColor = Color.WhiteSmoke
                listview1.Items(i).SubItems(7).ForeColor = Color.DarkGreen
                listview1.Items(i).SubItems(8).BackColor = Color.White
                listview1.Items(i).SubItems(8).ForeColor = Color.DimGray
                listview1.Items(i).SubItems(9).BackColor = Color.WhiteSmoke
                listview1.Items(i).SubItems(9).ForeColor = Color.DarkGreen

                listview1.Items(i).SubItems(10).BackColor = Color.WhiteSmoke
                listview1.Items(i).SubItems(10).ForeColor = Color.Teal
                listview1.Items(i).SubItems(11).BackColor = Color.White
                listview1.Items(i).SubItems(11).ForeColor = Color.DimGray
                listview1.Items(i).SubItems(12).BackColor = Color.WhiteSmoke
                listview1.Items(i).SubItems(12).ForeColor = Color.Teal

                listview1.Items(i).SubItems(13).BackColor = Color.LightYellow
                listview1.Items(i).SubItems(13).ForeColor = Color.SlateGray
                listview1.Items(i).SubItems(14).BackColor = Color.LightYellow
                listview1.Items(i).SubItems(14).ForeColor = Color.SlateGray
                listview1.Items(i).SubItems(15).BackColor = Color.LavenderBlush
                listview1.Items(i).SubItems(15).ForeColor = Color.DarkRed

                listview1.Items(i).SubItems(18).BackColor = Color.YellowGreen
                listview1.Items(i).SubItems(18).ForeColor = Color.Black

                listview1.Items(i).SubItems(1).Font = New Font(listview1.Items(i).SubItems(1).Font.Size, 10) ', FontStyle.Bold)
                listview1.GridLines = True

            End If

        Next
    End Sub

    Private Sub ObtenerProducto(intIdItem As Integer)
        Dim totalesAlmacenSA As New TotalesAlmacenSA
        Dim nTotal As New totalesAlmacen

        nTotal = totalesAlmacenSA.GetUbicarProductoTAlmacen(txtAlmacen.ValueMember, intIdItem)

        If Not IsNothing(nTotal) Then
            lblProducto.Text = nTotal.descripcion
            lblCanDisponible.Text = nTotal.cantidad
            lblUnidad.Text = nTotal.unidadMedida
        End If

    End Sub

    'Private Sub LoadKardexProductos(intIdAlmacen As Integer, intIdItem As Integer)
    '    Dim inventario As New inventarioMovimientoSA
    '    Dim totalsaldo As Decimal = 0
    '    Dim cantidadSaldo As Decimal = 0
    '    Dim PrecioPromedio As Decimal = 0
    '    Dim tablaSA As New tablaDetalleSA
    '    Try
    '        lsvKardex.CheckBoxes = False
    '        lsvKardex.Items.Clear()
    '        lsvKardex.Columns.Clear()
    '        lsvKardex.Columns.Add("Fc Movimiento", 150) '0
    '        lsvKardex.Columns.Add("idEmpresa", 0) '1
    '        lsvKardex.Columns.Add("idAlmacen", 0) '2
    '        lsvKardex.Columns.Add("Movimiento", 0) '3
    '        lsvKardex.Columns.Add("idItem", 0) '4
    '        lsvKardex.Columns.Add("Descripción", 210) '5
    '        lsvKardex.Columns.Add("U.M.", 80) '6
    '        lsvKardex.Columns.Add("Cant Entrada", 70, HorizontalAlignment.Right) '7
    '        lsvKardex.Columns.Add("Pr Unit E.", 80, HorizontalAlignment.Right) '8
    '        lsvKardex.Columns.Add("Costo Entrada", 70, HorizontalAlignment.Right) '9

    '        lsvKardex.Columns.Add("Cant Salida", 70, HorizontalAlignment.Right) '10
    '        lsvKardex.Columns.Add("Pr Unit S.", 85, HorizontalAlignment.Right) '11
    '        lsvKardex.Columns.Add("Costo Salida", 71, HorizontalAlignment.Right) '12

    '        lsvKardex.Columns.Add("Cant Saldo", 75, HorizontalAlignment.Right) '13
    '        lsvKardex.Columns.Add("Costo Saldo", 75, HorizontalAlignment.Right) '14
    '        lsvKardex.Columns.Add("P.M.", 80, HorizontalAlignment.Right) '15
    '        lsvKardex.Columns.Add("Glosa", 250) '16
    '        lsvKardex.Columns.Add("ID", 0) '17
    '        lsvKardex.Columns.Add("Nro. Doc (referencia)", 100) '18
    '        lsvKardex.Columns.Add("Cta Contable", 0) '19
    '        lsvKardex.Columns.Add("Tipo Reg.", 0) '20
    '        lsvKardex.Columns.Add("IDDoc", 0) '21
    '        lsvKardex.Columns.Add("Tipo producto", 0) '22
    '        lsvKardex.Columns.Add("Gravado", 0) '23
    '        lsvKardex.Columns.Add("Costo Saldo US", 0) '24

    '        Dim x = 0
    '        For Each i As InventarioMovimiento In inventario.ObtenerProdPorAlmacenes(intIdAlmacen, intIdItem)
    '            If x = 0 Then
    '                totalsaldo += i.monto
    '                cantidadSaldo += i.cantidad
    '                If (totalsaldo = 0) Then
    '                    PrecioPromedio = 0
    '                Else
    '                    If cantidadSaldo > 0 Then
    '                        PrecioPromedio = totalsaldo / cantidadSaldo
    '                    End If
    '                End If
    '            Else
    '                totalsaldo = Math.Round(totalsaldo + CDec(i.monto), 2)
    '                cantidadSaldo = cantidadSaldo + CDec(i.cantidad)
    '                If totalsaldo = 0 Or totalsaldo < 0 Or cantidadSaldo = 0 Then
    '                    PrecioPromedio = 0
    '                Else
    '                    If cantidadSaldo > 0 Then
    '                        PrecioPromedio = totalsaldo / cantidadSaldo
    '                    End If
    '                End If

    '            End If

    '            If i.tipoRegistro = "E" Or i.tipoRegistro = "EA" Or i.tipoRegistro = "EC" Then
    '                'lsvKardex.lis 
    '                Dim n As New ListViewItem(FormatDateTime(i.fecha, DateFormat.GeneralDate))
    '                n.SubItems.Add(i.idEmpresa)
    '                n.SubItems.Add(i.idAlmacen)
    '                n.SubItems.Add(i.tipoRegistro)
    '                n.SubItems.Add(i.idItem)
    '                n.SubItems.Add(i.nombreItem)
    '                n.SubItems.Add(tablaSA.GetUbicarTablaID(6, i.unidad).descripcion)
    '                n.SubItems.Add(FormatNumber(i.cantidad, 2))
    '                n.SubItems.Add(FormatNumber(i.precUnite, 2))
    '                n.SubItems.Add(FormatNumber(i.monto, 2))
    '                n.SubItems.Add("0.00")
    '                n.SubItems.Add("0.00")
    '                n.SubItems.Add("0.00")
    '                n.SubItems.Add(FormatNumber(cantidadSaldo, 2))
    '                n.SubItems.Add(FormatNumber(totalsaldo, 2))
    '                n.SubItems.Add(FormatNumber(PrecioPromedio, 2))
    '                n.SubItems.Add(i.glosa)
    '                n.SubItems.Add(i.idInventario)
    '                n.SubItems.Add(i.NumDocCompra)
    '                n.SubItems.Add(i.cuentaOrigen)
    '                n.SubItems.Add(i.tipoRegistro)
    '                n.SubItems.Add(i.idDocumento)
    '                n.SubItems.Add(i.tipoProducto)
    '                n.SubItems.Add(i.destinoGravadoItem)
    '                n.SubItems.Add(FormatNumber(i.montoUSD, 2))
    '                lsvKardex.Items.Add(n)

    '            ElseIf i.tipoRegistro = "S" Or i.tipoRegistro = "D" Then
    '                Dim n As New ListViewItem(FormatDateTime(i.fecha, DateFormat.GeneralDate))
    '                n.SubItems.Add(i.idEmpresa)
    '                n.SubItems.Add(i.idAlmacen)
    '                n.SubItems.Add(i.tipoRegistro)
    '                n.SubItems.Add(i.idItem)
    '                n.SubItems.Add(i.nombreItem)
    '                n.SubItems.Add(tablaSA.GetUbicarTablaID(6, i.unidad).descripcion)
    '                n.SubItems.Add("0.00")
    '                n.SubItems.Add("0.00")
    '                n.SubItems.Add("0.00")
    '                n.SubItems.Add(FormatNumber(i.cantidad, 2))
    '                n.SubItems.Add(FormatNumber(i.precUnite, 2))
    '                n.SubItems.Add(FormatNumber(i.monto, 2))
    '                n.SubItems.Add(FormatNumber(cantidadSaldo, 2))
    '                n.SubItems.Add(FormatNumber(totalsaldo, 2))
    '                n.SubItems.Add(FormatNumber(PrecioPromedio, 2))
    '                n.SubItems.Add(i.glosa)
    '                n.SubItems.Add(i.idInventario)
    '                n.SubItems.Add(i.NumDocCompra)
    '                n.SubItems.Add(i.cuentaOrigen)
    '                n.SubItems.Add(i.tipoRegistro)
    '                n.SubItems.Add(i.idDocumento)
    '                n.SubItems.Add(i.tipoProducto)
    '                n.SubItems.Add(i.destinoGravadoItem)
    '                n.SubItems.Add(FormatNumber(i.montoUSD, 2))
    '                lsvKardex.Items.Add(n)

    '            End If
    '        Next
    '        lblEstado.Text = "Registros encontrados del almacén: " & txtAlmacen.Text & ", " & Space(1) & lsvKardex.Items.Count & " fila(s)."
    '        lblEstado.Image = My.Resources.ok4

    '        colorearColumnas_Listview(lsvKardex)
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

    'Private Sub STockItemsPorAlmVirtual(intIdAlmacen As Integer)
    '    Dim inventario As New inventarioMovimientoSA
    '    Dim totalsaldo As Decimal = 0
    '    Dim cantidadSaldo As Decimal = 0
    '    Dim PrecioPromedio As Decimal = 0
    '    Dim tablaSA As New tablaDetalleSA
    '    Try
    '        lsvKardex.CheckBoxes = False
    '        lsvKardex.Items.Clear()
    '        lsvKardex.Columns.Clear()
    '        lsvKardex.Columns.Add("Fc Movimiento", 150) '0
    '        lsvKardex.Columns.Add("idEmpresa", 0) '1
    '        lsvKardex.Columns.Add("idAlmacen", 0) '2
    '        lsvKardex.Columns.Add("Movimiento", 0) '3
    '        lsvKardex.Columns.Add("idItem", 0) '4
    '        lsvKardex.Columns.Add("Descripción", 210) '5
    '        lsvKardex.Columns.Add("U.M.", 80) '6
    '        lsvKardex.Columns.Add("Cant Entrada", 70, HorizontalAlignment.Right) '7
    '        lsvKardex.Columns.Add("Pr Unit E.", 80, HorizontalAlignment.Right) '8
    '        lsvKardex.Columns.Add("Costo Entrada", 70, HorizontalAlignment.Right) '9

    '        lsvKardex.Columns.Add("Cant Salida", 70, HorizontalAlignment.Right) '10
    '        lsvKardex.Columns.Add("Pr Unit S.", 85, HorizontalAlignment.Right) '11
    '        lsvKardex.Columns.Add("Costo Salida", 71, HorizontalAlignment.Right) '12

    '        lsvKardex.Columns.Add("Cant Saldo", 75, HorizontalAlignment.Right) '13
    '        lsvKardex.Columns.Add("Costo Saldo", 75, HorizontalAlignment.Right) '14
    '        lsvKardex.Columns.Add("P.M.", 80, HorizontalAlignment.Right) '15
    '        lsvKardex.Columns.Add("Glosa", 250) '16
    '        lsvKardex.Columns.Add("ID", 0) '17
    '        lsvKardex.Columns.Add("Nro. Doc (referencia)", 100) '18
    '        lsvKardex.Columns.Add("Cta Contable", 0) '19
    '        lsvKardex.Columns.Add("Tipo Reg.", 0) '20
    '        lsvKardex.Columns.Add("IDDoc", 0) '21
    '        lsvKardex.Columns.Add("Tipo producto", 0) '22
    '        lsvKardex.Columns.Add("Gravado", 0) '23
    '        lsvKardex.Columns.Add("Costo Saldo US", 0) '24

    '        Dim x = 0
    '        For Each i As InventarioMovimiento In inventario.ObtenerItemsPorAlmacen(intIdAlmacen)
    '            If x = 0 Then
    '                totalsaldo += i.monto
    '                cantidadSaldo += i.cantidad
    '                If (totalsaldo = 0) Then
    '                    PrecioPromedio = 0
    '                Else
    '                    If cantidadSaldo > 0 Then
    '                        PrecioPromedio = totalsaldo / cantidadSaldo
    '                    End If
    '                End If
    '            Else
    '                totalsaldo = Math.Round(totalsaldo + CDec(i.monto), 2)
    '                cantidadSaldo = cantidadSaldo + CDec(i.cantidad)
    '                If totalsaldo = 0 Or totalsaldo < 0 Or cantidadSaldo = 0 Then
    '                    PrecioPromedio = 0
    '                Else
    '                    If cantidadSaldo > 0 Then
    '                        PrecioPromedio = totalsaldo / cantidadSaldo
    '                    End If
    '                End If

    '            End If

    '            If i.tipoRegistro = "E" Or i.tipoRegistro = "EA" Or i.tipoRegistro = "EC" Then
    '                'lsvKardex.lis 
    '                Dim n As New ListViewItem(FormatDateTime(i.fecha, DateFormat.GeneralDate))
    '                n.SubItems.Add(i.idEmpresa)
    '                n.SubItems.Add(i.idAlmacen)
    '                n.SubItems.Add(i.tipoRegistro)
    '                n.SubItems.Add(i.idItem)
    '                n.SubItems.Add(i.nombreItem)
    '                n.SubItems.Add(tablaSA.GetUbicarTablaID(6, i.unidad).descripcion)
    '                n.SubItems.Add(FormatNumber(i.cantidad, 2))
    '                n.SubItems.Add(FormatNumber(i.precUnite, 2))
    '                n.SubItems.Add(FormatNumber(i.monto, 2))
    '                n.SubItems.Add("0.00")
    '                n.SubItems.Add("0.00")
    '                n.SubItems.Add("0.00")
    '                n.SubItems.Add(FormatNumber(cantidadSaldo, 2))
    '                n.SubItems.Add(FormatNumber(totalsaldo, 2))
    '                n.SubItems.Add(FormatNumber(PrecioPromedio, 2))
    '                n.SubItems.Add(i.glosa)
    '                n.SubItems.Add(i.idInventario)
    '                n.SubItems.Add(i.NumDocCompra)
    '                n.SubItems.Add(i.cuentaOrigen)
    '                n.SubItems.Add(i.tipoRegistro)
    '                n.SubItems.Add(i.idDocumento)
    '                n.SubItems.Add(i.tipoProducto)
    '                n.SubItems.Add(i.destinoGravadoItem)
    '                n.SubItems.Add(FormatNumber(i.montoUSD, 2))
    '                lsvKardex.Items.Add(n)
    '            ElseIf i.tipoRegistro = "S" Or i.tipoRegistro = "D" Then
    '                Dim n As New ListViewItem(FormatDateTime(i.fecha, DateFormat.GeneralDate))
    '                n.SubItems.Add(i.idEmpresa)
    '                n.SubItems.Add(i.idAlmacen)
    '                n.SubItems.Add(i.tipoRegistro)
    '                n.SubItems.Add(i.idItem)
    '                n.SubItems.Add(i.nombreItem)
    '                n.SubItems.Add(tablaSA.GetUbicarTablaID(6, i.unidad).descripcion)
    '                n.SubItems.Add("0.00")
    '                n.SubItems.Add("0.00")
    '                n.SubItems.Add("0.00")
    '                n.SubItems.Add(FormatNumber(i.cantidad, 2))
    '                n.SubItems.Add(FormatNumber(i.precUnite, 2))
    '                n.SubItems.Add(FormatNumber(i.monto, 2))
    '                n.SubItems.Add(FormatNumber(cantidadSaldo, 2))
    '                n.SubItems.Add(FormatNumber(totalsaldo, 2))
    '                n.SubItems.Add(FormatNumber(PrecioPromedio, 2))
    '                n.SubItems.Add(i.glosa)
    '                n.SubItems.Add(i.idInventario)
    '                n.SubItems.Add(i.NumDocCompra)
    '                n.SubItems.Add(i.cuentaOrigen)
    '                n.SubItems.Add(i.tipoRegistro)
    '                n.SubItems.Add(i.idDocumento)
    '                n.SubItems.Add(i.tipoProducto)
    '                n.SubItems.Add(i.destinoGravadoItem)
    '                n.SubItems.Add(FormatNumber(i.montoUSD, 2))
    '                lsvKardex.Items.Add(n)
    '            End If
    '        Next
    '        lblEstado.Text = "Registros encontrados del almacén: " & "VIRTUAL " & ", " & Space(1) & lsvKardex.Items.Count & " fila(s)."
    '        lblEstado.Image = My.Resources.ok4

    '        colorearColumnas_Listview(lsvKardex)
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub


    ', lv1Child
    Public Sub ObetnerListaProductosLST(intIdAlmacen As Integer)
        Dim totalesSA As New TotalesAlmacenSA

        lstProductos.DisplayMember = "descripcion"
        lstProductos.ValueMember = "idItem"
        lstProductos.DataSource = totalesSA.GetListaProductosPorAlmacen(intIdAlmacen)


        lblEstado.Text = "Productos encontrados: " & lstProductos.Items.Count
    End Sub

    Public Sub ObetnerListaProductosLSTPorItem(intIdAlmacen As Integer, strProducto As String, strTipoExistencia As String)
        Dim totalesSA As New TotalesAlmacenSA

        lstProductos.DisplayMember = "descripcion"
        lstProductos.ValueMember = "idItem"
        lstProductos.DataSource = totalesSA.GetProductoPorAlmacenTipoEx(intIdAlmacen, strTipoExistencia, strProducto)


        lblEstado.Text = "Productos encontrados: " & lstProductos.Items.Count
    End Sub
#End Region

    Sub MostrarKardexXfechas()
        Dim filter1 As New RecordFilterDescriptor()
        Me.dgvCompra.TableDescriptor.RecordFilters.Clear()
        filter1.Expression = "[DateTime] like '" + "03/11/2015" + "'"
        Me.dgvCompra.TableDescriptor.RecordFilters.Add(filter1)
    End Sub

    Private Sub ToolStripLabel1_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs)
        ''''frmPMO.Panel3.Width = 249
        Dispose()
    End Sub

    Private Sub lstProductos_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lstProductos.MouseDoubleClick
        Me.Cursor = Cursors.WaitCursor
        If lstProductos.SelectedItems.Count > 0 Then
            Me.pcProductos.HidePopup(PopupCloseType.Done)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lstProductos_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstProductos.SelectedIndexChanged
        'If lstProductos.SelectedItems.Count > 0 Then
        '    ObtenerProducto(lstProductos.SelectedValue)
        '    LoadKardexProductos(cboAlmacenes.ComboBox.SelectedValue, lstProductos.SelectedValue)
        'End If
        'If CheckBox1.Checked = True Then
        '    If lstProductos.SelectedItems.Count > 0 Then
        '        ObtenerProducto(lstProductos.SelectedValue)
        '        LoadKardexProductos(txtAlmacen.ValueMember, lstProductos.SelectedValue)
        '    End If
        'ElseIf CheckBox2.Checked = True Then

        'ElseIf CheckBox3.Checked = True Then
        'If lstProductos.SelectedItems.Count > 0 Then
        '    ObtenerProducto(lstProductos.SelectedValue)
        '    LoadKardexProductosPorRango(txtAlmacen.ValueMember, lstProductos.SelectedValue, CDate(DateTimePicker1.Value), CDate(DateTimePicker2.Value))
        'End If
        'End If
    End Sub

    'Private Sub ToolStripTextBox1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles ToolStripTextBox1.KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        e.SuppressKeyPress = True
    '        Me.lsvKardex.Items.Clear()

    '        If Not txtAlmacen.Text.Trim.Length > 0 Then
    '            lblEstado.Text = "Debe elegir un almacen valido"
    '            Timer1.Enabled = True
    '            TiempoEjecutar(5)
    '        Else
    '            If ToolStripTextBox1.Text.Trim.Length > 0 Then
    '                BuscarProductoPorDescripcion(ToolStripTextBox1.Text.Trim)
    '            Else

    '                lblEstado.Text = "Debe escribir el nombre del producto a buscar"
    '                Timer1.Enabled = True
    '                TiempoEjecutar(5)
    '            End If

    '        End If


    '    End If
    'End Sub

    Private Sub frmKardex_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub VerPorAlmacénToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        'Me.Cursor = Cursors.WaitCursor
        'Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        'datos.Clear()
        'With frmModalAlmacen
        '    .ObtenerAlmacenes(GEstableciento.IdEstablecimiento)
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    If datos.Count > 0 Then
        '        lblIdAlmacen.Text = datos(0).ID
        '        lblAlmacen.Text = datos(0).NombreEntidad
        '        lsvKardex.Items.Clear()
        '        ObetnerListaProductosLST(lblIdAlmacen.Text)
        '    End If

        'End With
        'Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub ToolStripButton7_Click(sender As System.Object, e As System.EventArgs)
        ''''frmPMO.Panel3.Width = 249
        Dispose()
    End Sub

    Private Sub lblPerido_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lblPerido.MouseUp
        Dim p As Point = e.Location
        p.Offset(lblPerido.Bounds.Location)
        ContextMenuStrip2.Show(ToolStrip4.PointToScreen(p))
        cboPeriodo.DroppedDown = True
    End Sub


    'Private Sub cboPeriodo_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboPeriodo.SelectedIndexChanged
    '    Select Case cboPeriodo.Text
    '        Case "ENERO"
    '            lblPerido.Text = "01" & "/" & PeriodoGeneral
    '        Case "FEBRERO"
    '            lblPerido.Text = "02" & "/" & PeriodoGeneral
    '        Case "MARZO"
    '            lblPerido.Text = "03" & "/" & PeriodoGeneral
    '        Case "ABRIL"
    '            lblPerido.Text = "04" & "/" & PeriodoGeneral
    '        Case "MAYO"
    '            lblPerido.Text = "05" & "/" & PeriodoGeneral
    '        Case "JUNIO"
    '            lblPerido.Text = "06" & "/" & PeriodoGeneral
    '        Case "JULIO"
    '            lblPerido.Text = "07" & "/" & PeriodoGeneral
    '        Case "AGOSTO"
    '            lblPerido.Text = "08" & "/" & PeriodoGeneral
    '        Case "SETIEMBRE"
    '            lblPerido.Text = "09" & "/" & PeriodoGeneral
    '        Case "OCTUBRE"
    '            lblPerido.Text = "10" & "/" & PeriodoGeneral
    '        Case "NOVIEMBRE"
    '            lblPerido.Text = "11" & "/" & PeriodoGeneral
    '        Case "DICIEMBRE"
    '            lblPerido.Text = "12" & "/" & PeriodoGeneral
    '    End Select


    '    If CheckBox2.Checked = True Then
    '        LoadKardexProductosPorMes(txtAlmacen.ValueMember, lstProductos.SelectedValue, PeriodoGeneral, String.Format("{0:00}", lblPerido.Text.Substring(0, 2)))
    '    End If
    '    ContextMenuStrip2.Hide()
    'End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        'If CheckBox1.Checked = True Then


        '    CheckBox1.Checked = True
        '    CheckBox2.Checked = False
        '    CheckBox3.Checked = False

        '    DateTimePicker1.Visible = False
        '    DateTimePicker2.Visible = False
        '    lbldesde.Visible = False
        '    lblhasta.Visible = False
        'End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If txtAlmacen.Text.Trim.Length > 0 Then

            If CheckBox2.Checked = True Then
                '   LoadKardexProductosPorMes(txtAlmacen.ValueMember, lstProductos.SelectedValue, PeriodoGeneral, String.Format("{0:00}", lblPerido.Text.Substring(0, 2)))
                CheckBox1.Checked = False
                CheckBox2.Checked = True
                CheckBox3.Checked = False

                DateTimePicker1.Visible = False
                DateTimePicker2.Visible = False
                lbldesde.Visible = False
                lblhasta.Visible = False
            End If

        Else

            lblEstado.Text = "Debe seleccionar un almacen"
            Timer1.Enabled = True
            TiempoEjecutar(5)

            CheckBox1.Checked = False
            CheckBox3.Checked = False
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox3.CheckedChanged
        If txtAlmacen.Text.Trim.Length > 0 Then
            If CheckBox3.Checked = True Then
                '      LoadKardexProductosPorRango(txtAlmacen.ValueMember, lstProductos.SelectedValue, CDate(DateTimePicker1.Value), CDate(DateTimePicker2.Value))
                CheckBox1.Checked = False
                CheckBox2.Checked = False
                CheckBox3.Checked = True
                DateTimePicker1.Visible = True
                DateTimePicker2.Visible = True
                lbldesde.Visible = True
                lblhasta.Visible = True

            End If

        Else

            lblEstado.Text = "Debe seleccionar un almacen"
            Timer1.Enabled = True
            TiempoEjecutar(5)
            CheckBox1.Checked = False
            CheckBox2.Checked = False
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        If CheckBox3.Checked = True Then
            '  LoadKardexProductosPorRango(txtAlmacen.ValueMember, lstProductos.SelectedValue, DateTimePicker1.Value, DateTimePicker2.Value)
        End If
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DateTimePicker2.ValueChanged
        If CheckBox3.Checked = True Then
            '  LoadKardexProductosPorRango(txtAlmacen.ValueMember, lstProductos.SelectedValue, DateTimePicker1.Value, DateTimePicker2.Value)
        End If
    End Sub

    Private Sub pcAlmacen_BeforePopup(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles pcAlmacen.BeforePopup
        Me.pcAlmacen.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub pcAlmacen_CloseUp(sender As System.Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs) Handles pcAlmacen.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lstAlmacen.SelectedItems.Count > 0 Then
                Me.txtAlmacen.ValueMember = lstAlmacen.SelectedValue
                txtAlmacen.Text = lstAlmacen.Text
                dgvCompra.Table.Records.DeleteAll()
                '  ListadoItemsEnTransito(MesGeneral, AnioGeneral, txtExistencia.ValueMember)
                '       ObetnerListaProductosLST(txtAlmacen.ValueMember)
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtAlmacen.Focus()
        End If
    End Sub

    Private Sub ButtonAdv5_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv5.Click
        Me.pcAlmacen.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub ButtonAdv4_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv4.Click
        Me.pcAlmacen.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub ButtonAdv1_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv1.Click
        pcAlmacen.Font = New Font("Segoe UI", 8)
        pcAlmacen.Size = New Size(260, 110)
        Me.pcAlmacen.ParentControl = Me.txtAlmacen
        Me.pcAlmacen.ShowPopup(Point.Empty)
    End Sub

    Private Sub rbPeriodo_CheckChanged(sender As System.Object, e As System.EventArgs) Handles rbPeriodo.CheckChanged
        Me.Cursor = Cursors.WaitCursor
        If txtAlmacen.Text.Trim.Length > 0 Then
            dgvCompra.Table.Records.DeleteAll()
            If rbPeriodo.Checked = True Then
                Dim statusForm As New FeedbackForm()
                statusForm.Tag = "CEX"
                'statusForm.Show("PROCESANDO ITEMS...!")
                If tbIGV.ToggleState = Tools.ToggleButtonState.Active Then
                    If lstProductos.SelectedItems.Count > 0 Then

                        '    ObtenerProducto(lstProductos.SelectedValue)
                        ListaKardexPorPeriodo()
                        '  LoadKardexProductosPorMes(txtAlmacen.ValueMember, lstProductos.SelectedValue, AnioGeneral, MesGeneral)
                    End If
                ElseIf tbIGV.ToggleState = Tools.ToggleButtonState.Inactive Then
                    ListaKardexPorPeriodoAll()
                End If
               
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub rbDia_CheckChanged(sender As System.Object, e As System.EventArgs) Handles rbDia.CheckChanged
        Me.Cursor = Cursors.WaitCursor
        If txtAlmacen.Text.Trim.Length > 0 Then
            dgvCompra.Table.Records.DeleteAll()
            If tbIGV.ToggleState = Tools.ToggleButtonState.Active Then
                If lstProductos.SelectedItems.Count > 0 Then
                    If rbDia.Checked = True Then
                        Dim statusForm As New FeedbackForm()
                        statusForm.Tag = "CEX"
                        'statusForm.Show("PROCESANDO ITEMS...!")
                        '   ObtenerProducto(lstProductos.SelectedValue)
                        ListaKardexPorDia()
                    End If
                End If
            ElseIf tbIGV.ToggleState = Tools.ToggleButtonState.Inactive Then
                If rbDia.Checked = True Then
                    Dim statusForm As New FeedbackForm()
                    statusForm.Tag = "CEX"
                    'statusForm.Show("PROCESANDO ITEMS...!")
                    ListaKardexPorDiaAll()
                End If

            End If
         
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lstAlmacen_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstAlmacen.MouseDoubleClick
        Me.Cursor = Cursors.WaitCursor
        If lstAlmacen.SelectedItems.Count > 0 Then
            Me.pcAlmacen.HidePopup(PopupCloseType.Done)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lstAlmacen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstAlmacen.SelectedIndexChanged

    End Sub

    Private Sub frmKardex_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ContextMenuStrip = New ContextMenuStrip()
        ContextMenuStrip.Items.Add("Visualizar documento de origen...")
        AddHandler ContextMenuStrip.ItemClicked, AddressOf contextMenuStrip_ItemClicked
        AddHandler Me.dgvCompra.TableControlMouseDown, AddressOf gridGroupingControl1_TableControlMouseDown
    End Sub

    Private Sub contextMenuStrip_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            If e.ClickedItem.Text = "Visualizar documento de origen..." Then
                '   Me.dgvCompra.Table.CurrentRecord.Delete()
                Select Case Me.dgvCompra.Table.CurrentRecord.GetValue("Movimiento")
                    Case "COMPRA", "OTRAS ENTRADAS A ALMACEN", "TRANSFERENCIA ENTRE ALMACENES", "OTRAS SALIDAS DE ALMACEN", "NC-DISMINUIR CANTIDAD", "NC-DISMINUIR IMPORTE", "NC-DISMINUIR CANTIDAD E IMPORTE", "NC-DEVOLUCION DE EXISTENCIAS"
                        Dim a As New frmInfoSourceAlmacen(Me.dgvCompra.Table.CurrentRecord.GetValue("Movimiento"), Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
                        ' Me.dgvCompra.TableDescriptor.Columns("CompanyName").HeaderText = "Hello"
                        a.GDBSource.Binder.InternalColumns("fechaDoc").HeaderText = "Fecha operación"
                        a.GDBSource.Binder.InternalColumns("Proveedor").HeaderText = "Proveedor y/o trabajador"
                        a.StartPosition = FormStartPosition.CenterParent
                        a.ShowDialog()
                    Case "VENTA" ', "OTRAS SALIDAS DE ALMACEN"
                        Dim a As New frmInfoSourceAlmacen(Me.dgvCompra.Table.CurrentRecord.GetValue("Movimiento"), Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
                        a.GDBSource.Binder.InternalColumns("fechaDoc").HeaderText = "Fecha venta"
                        a.GDBSource.Binder.InternalColumns("Proveedor").HeaderText = "Cliente"
                        a.StartPosition = FormStartPosition.CenterParent
                        a.ShowDialog()
                    Case "APORTES"
                        Dim a As New frmInfoSourceAlmacen(Me.dgvCompra.Table.CurrentRecord.GetValue("Movimiento"), Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
                        a.GDBSource.Binder.InternalColumns("fechaDoc").HeaderText = "Fecha venta"
                        a.GDBSource.Binder.InternalColumns("Proveedor").HeaderText = "Trabajador"
                        a.StartPosition = FormStartPosition.CenterParent
                        a.ShowDialog()
                End Select


            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub gridGroupingControl1_TableControlMouseDown(sender As Object, e As GridTableControlMouseEventArgs)
        Dim row As Integer = 0, col As Integer = 0
        Me.dgvCompra.TableControl.PointToRowCol(e.Inner.Location, row, col)
        Dim style As GridTableCellStyleInfo = Me.dgvCompra.TableControl.GetTableViewStyleInfo(row, col)
        'To check whether it is columnheadercell
        If style IsNot Nothing AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.Inner.Button = System.Windows.Forms.MouseButtons.Right Then
            '  gridGroupingControl1.ContextMenuStrip = fieldchooser.ContextMenu
        Else
            'If it is not column header cell
            dgvCompra.ContextMenuStrip = ContextMenuStrip
        End If
    End Sub


    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        '   dockingManager1.SetDockVisibility(Panel2, True)
    End Sub

    Private Sub txtAlmacen_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAlmacen.KeyDown
        If e.KeyCode = Keys.Down Then
            If Not Me.pcAlmacen.IsShowing() Then
                ' Let the popup align around the source textBox.
                pcAlmacen.Font = New Font("Segoe UI", 8)
                pcAlmacen.Size = New Size(260, 110)
                Me.pcAlmacen.ParentControl = Me.txtAlmacen
                Me.pcAlmacen.ShowPopup(Point.Empty)
                e.Handled = True
            End If
        End If
        '  End If
        ' Escape should close the popup.
        If e.KeyCode = Keys.Escape Then
            If Me.pcAlmacen.IsShowing() Then
                Me.pcAlmacen.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub txtAlmacen_TextChanged(sender As Object, e As EventArgs) Handles txtAlmacen.TextChanged

    End Sub

    Private Sub pcAlmacen_Popup(sender As Object, e As EventArgs) Handles pcAlmacen.Popup
        lstAlmacen.Focus()
    End Sub

    Private Sub txtBuscarProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscarProducto.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                If txtAlmacen.Text.Trim.Length > 0 Then
                    pcProductos.Font = New Font("Segoe UI", 8)
                    Me.pcProductos.ParentControl = Me.txtBuscarProducto
                    Me.pcProductos.ShowPopup(Point.Empty)
                    ObetnerListaProductosLSTPorItem(txtAlmacen.ValueMember, txtBuscarProducto.Text.Trim, cboTipoExistencia.SelectedValue)
                    Me.Cursor = Cursors.Arrow
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub txtBuscarProducto_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarProducto.TextChanged

    End Sub

    Private Sub pcProductos_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles pcProductos.BeforePopup
        Me.pcProductos.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub pcProductos_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcProductos.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lstProductos.SelectedItems.Count > 0 Then
                If txtAlmacen.Text.Trim.Length > 0 Then
                    txtBuscarProducto.Text = lstProductos.Text
                    txtBuscarProducto.Tag = lstProductos.SelectedValue
                    If rbPeriodo.Checked = True Then
                        If lstProductos.SelectedItems.Count > 0 Then
                            '    ObtenerProducto(lstProductos.SelectedValue)
                            ' LoadKardexProductosPorMes(txtAlmacen.ValueMember, lstProductos.SelectedValue, AnioGeneral, MesGeneral)
                            ListaKardexPorPeriodo()
                        End If
                    ElseIf rbDia.Checked = True Then
                        '     ObtenerProducto(lstProductos.SelectedValue)
                        ListaKardexPorDia()
                        '   LoadKardexProductos(txtAlmacen.ValueMember, lstProductos.SelectedValue)
                    ElseIf rbAnio.Checked = True Then
                        ListaKardexPorAnio()
                    End If
                End If
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtBuscarProducto.Focus()
        End If
    End Sub

    Private Sub cboTipoExistencia_Click(sender As Object, e As EventArgs) Handles cboTipoExistencia.Click

    End Sub

    Private Sub cboTipoExistencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoExistencia.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        dgvCompra.Table.Records.DeleteAll()
        If txtAlmacen.Text.Trim.Length > 0 Then
            pcProductos.Font = New Font("Segoe UI", 8)
            Me.pcProductos.ParentControl = Me.txtBuscarProducto
            Me.pcProductos.ShowPopup(Point.Empty)
            ObetnerListaProductosLSTPorItem(txtAlmacen.ValueMember, txtBuscarProducto.Text.Trim, cboTipoExistencia.SelectedValue)
            ' Me.Cursor = Cursors.Arrow
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Me.Cursor = Cursors.WaitCursor
        If txtAlmacen.Text.Trim.Length > 0 Then
            If rbPeriodo.Checked = True Then
                Dim statusForm As New FeedbackForm()
                statusForm.Tag = "CEX"
                'statusForm.Show("PROCESANDO ITEMS...!")
                If tbIGV.ToggleState = Tools.ToggleButtonState.Active Then
                    If lstProductos.SelectedItems.Count > 0 Then
                        ListaKardexPorPeriodo()
                    End If
                ElseIf tbIGV.ToggleState = Tools.ToggleButtonState.Inactive Then
                    ListaKardexPorPeriodoAll()
                End If
               
            ElseIf rbDia.Checked = True Then
                '    ObtenerProducto(lstProductos.SelectedValue)
                Dim statusForm As New FeedbackForm()
                statusForm.Tag = "CEX"
                'statusForm.Show("PROCESANDO ITEMS...!")
                If tbIGV.ToggleState = Tools.ToggleButtonState.Active Then
                    ListaKardexPorDia()
                ElseIf tbIGV.ToggleState = Tools.ToggleButtonState.Inactive Then
                    ListaKardexPorDiaAll()
                End If

                '   LoadKardexProductos(txtAlmacen.ValueMember, lstProductos.SelectedValue)
            ElseIf rbAnio.Checked = True Then
                Dim statusForm As New FeedbackForm()
                statusForm.Tag = "CEX"
                'statusForm.Show("PROCESANDO ITEMS...!")
                If tbIGV.ToggleState = Tools.ToggleButtonState.Active Then

                    ListaKardexPorAnio()
                ElseIf tbIGV.ToggleState = Tools.ToggleButtonState.Inactive Then

                    ListaKardexPorAnioAll()
                End If

            End If
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Me.Cursor = Cursors.WaitCursor
        With frmRPTKardex
            If (rbPeriodo.Checked = True) Then
                .ConsultaReporteTotalesPorMes(txtAlmacen.ValueMember, txtAlmacen.Text)
                .StartPosition = FormStartPosition.CenterScreen
                .ShowDialog()
            ElseIf (rbAnio.Checked = True) Then
                .ConsultaReporteTotalesPorAnio(txtAlmacen.ValueMember, txtAlmacen.Text)
                .StartPosition = FormStartPosition.CenterScreen
                .ShowDialog()
            ElseIf (rbDia.Checked = True) Then
                .ConsultaReporteTotalesPorDia(txtAlmacen.ValueMember, txtAlmacen.Text)
                .StartPosition = FormStartPosition.CenterScreen
                .ShowDialog()
            End If
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub tbIGV_Click(sender As Object, e As EventArgs) Handles tbIGV.Click

    End Sub

    Private Sub tbIGV_ToggleStateChanged(sender As Object, e As Tools.ToggleStateChangedEventArgs) Handles tbIGV.ToggleStateChanged
        If e.ToggleState = Tools.ToggleButtonState.Active Then
            txtBuscarProducto.Enabled = True
            cboTipoExistencia.Enabled = True
            dgvCompra.Table.Records.DeleteAll()
            Me.dgvCompra.TableDescriptor.VisibleColumns.Remove("nombreItem")
        ElseIf e.ToggleState = Tools.ToggleButtonState.Inactive Then
            txtBuscarProducto.Enabled = False
            cboTipoExistencia.Enabled = False
            dgvCompra.Table.Records.DeleteAll()
            Me.dgvCompra.TableDescriptor.VisibleColumns.Add("nombreItem")

        End If
    End Sub

    Private Sub rbAnio_CheckChanged(sender As Object, e As EventArgs) Handles rbAnio.CheckChanged
        Me.Cursor = Cursors.WaitCursor
        If txtAlmacen.Text.Trim.Length > 0 Then
            dgvCompra.Table.Records.DeleteAll()
            If rbDia.Checked = True Then
                If lstProductos.SelectedItems.Count > 0 Then
                    Dim statusForm As New FeedbackForm()
                    statusForm.Tag = "CEX"
                    'statusForm.Show("PROCESANDO ITEMS...!")
                    '    ObtenerProducto(lstProductos.SelectedValue)
                    If tbIGV.ToggleState = Tools.ToggleButtonState.Active Then
                        ListaKardexPorAnio()
                    End If
                End If
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompra.TableControlCellClick

    End Sub
End Class