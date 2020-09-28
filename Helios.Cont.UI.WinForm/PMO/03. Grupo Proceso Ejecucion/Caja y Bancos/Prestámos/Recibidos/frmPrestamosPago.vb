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
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid

Public Class frmPrestamosPago

    Public Property manipulacionEstado As String
    Public Property lblIdProveedor() As String
    Public Property lblCuentaProveedor() As String
    Public Property lblNomProveedor() As String
    Public Property lblTipoCambioOriginal() As Decimal



    Public Property ListaAsientos As New List(Of asiento)

    Public Sub New()
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        QGlobalColorSchemeManager1.Global.CurrentTheme = Qios.DevSuite.Components.QColorScheme.LunaBlueThemeName
        SetRenderer()
        ObtenerTablaGenerales()

        'GridCFG(dgvPrestamos)
        'GetTableGrid()
        GridCFG(dgvPrestamoRO)
        GetTableGridPrestamo()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        'ListaDocPago()
        'CargarDAtos()
        'txtFechaTrans.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
        txtFechaTrans.Value = Date.Now
        txtTipoCambio.Value = TmpTipoCambio
    End Sub

#Region "metodos"

    Sub GetTableGridPrestamo()
        Dim dt As New DataTable()
        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("idCuota", GetType(Integer))
        dt.Columns.Add("secuencia", GetType(Integer))
        dt.Columns.Add("cuota", GetType(Integer))
        dt.Columns.Add("descripcion", GetType(String))
        dt.Columns.Add("montomn", GetType(Decimal))
        dt.Columns.Add("montome", GetType(Decimal))
        dt.Columns.Add("pago", GetType(Decimal))
        dt.Columns.Add("saldo", GetType(Decimal))
        dt.Columns.Add("pagoME", GetType(Decimal))
        dt.Columns.Add("saldoME", GetType(Decimal))
        dt.Columns.Add("cuenta", GetType(String))
        dt.Columns.Add("cuentaH", GetType(String))
        dt.Columns.Add("cuentaDev", GetType(String))
        dt.Columns.Add("cuentaDevH", GetType(String))

        dgvPrestamoRO.DataSource = dt
        dgvPrestamoRO.ShowGroupDropArea = False
        dgvPrestamoRO.TableDescriptor.GroupedColumns.Clear()
        dgvPrestamoRO.TableDescriptor.GroupedColumns.Add("cuota")
    End Sub
    'Sub GetTableGridPrestamo()
    '    Dim dt As New DataTable()
    '    dt.Columns.Add("idDocumento", GetType(Integer))
    '    dt.Columns.Add("idCuota", GetType(Integer))
    '    dt.Columns.Add("secuencia", GetType(Integer))
    '    dt.Columns.Add("cuota", GetType(String))
    '    dt.Columns.Add("descripcion", GetType(String))
    '    dt.Columns.Add("montomn", GetType(Decimal))
    '    dt.Columns.Add("montome", GetType(Decimal))
    '    dt.Columns.Add("pago", GetType(Decimal))
    '    dt.Columns.Add("saldo", GetType(Decimal))
    '    dt.Columns.Add("pagoME", GetType(Decimal))
    '    dt.Columns.Add("saldoME", GetType(Decimal))
    '    dt.Columns.Add("cuenta", GetType(String))
    '    dt.Columns.Add("tipo", GetType(String))
    '    dgvPrestamoRO.DataSource = dt
    '    dgvPrestamoRO.ShowGroupDropArea = False
    '    dgvPrestamoRO.TableDescriptor.GroupedColumns.Clear()
    '    dgvPrestamoRO.TableDescriptor.GroupedColumns.Add("cuota")
    'End Sub

    'Private Sub cargarCuentasAutomatico()
    '    Dim n As New movimiento
    '    'txtGlosaAsiento.Clear()
    '    'txtGlosaAsiento.Text = txtDescripcion.Text

    '    If (txtFondoMN.Value > 0 And txtFondoME.Value > 0) Then
    '        ListaMovimientos.Clear()
    '        n.cuenta = "1611"
    '        n.idAsiento = 1
    '        n.idmovimiento = GetMaxIDMovimiento() + 1
    '        n.tipo = "D"
    '        n.Cant = 1
    '        n.PUmn = CDec(txtFondoMN.Value / n.Cant)
    '        n.PUme = CDec(txtFondoME.Value / n.Cant)
    '        n.monto = txtFondoMN.Value
    '        n.montoUSD = txtFondoME.Value
    '        ListaMovimientos.Add(n)

    '        'cargarAsientos1()
    '    Else
    '        lblEstado.Text = "Ingrese un importe."
    '        Timer1.Enabled = True
    '        PanelError.Visible = True
    '        TiempoEjecutar(10)
    '        'txtFondoMN.Select(0, txtFondoMN.Text.Length)
    '        Exit Sub
    '    End If
    '    '////////////////////////

    '    If (txtFondoMN.Value > 0 And txtFondoME.Value > 0) Then


    '        Dim c As New movimiento
    '        c.cuenta = "10"
    '        c.idAsiento = 1
    '        c.idmovimiento = GetMaxIDMovimiento() + 1
    '        c.tipo = "H"
    '        c.Cant = 1
    '        c.PUmn = CDec(txtFondoMN.Value / c.Cant)
    '        c.PUme = CDec(txtFondoME.Value / c.Cant)
    '        c.monto = txtFondoMN.Value
    '        c.montoUSD = txtFondoME.Value
    '        ListaMovimientos.Add(c)



    '        'Dim dt As New DataTable


    '        'dt.Columns.Add("id", GetType(Integer))
    '        'dt.Columns.Add("Modulo", GetType(String))
    '        'dt.Columns.Add("cuenta", GetType(String))
    '        'dt.Columns.Add("tipoAsiento", GetType(String))
    '        'dt.Columns.Add("cant", GetType(Decimal))
    '        'dt.Columns.Add("pumn", GetType(Decimal))
    '        'dt.Columns.Add("importeMN", GetType(Decimal))
    '        'dt.Columns.Add("pume", GetType(Decimal))
    '        'dt.Columns.Add("importeME", GetType(Decimal))
    '        'dt.Columns.Add("descripcion", GetType(String))

    '        'Dim cosnulta = (From i In ListaMovimientos _
    '        '               Where i.idAsiento = 1).ToList

    '        'For Each x In cosnulta
    '        '    Dim dr As DataRow = dt.NewRow
    '        '    dr(0) = x.idmovimiento
    '        '    If Not IsNothing(x.cuenta) Then
    '        '        dr(1) = x.nombreEntidad
    '        '    Else
    '        '        dr(1) = String.Empty
    '        '    End If
    '        '    dr(2) = x.cuenta
    '        '    dr(3) = x.tipo
    '        '    dr(4) = x.Cant
    '        '    dr(5) = x.PUmn
    '        '    dr(6) = x.monto
    '        '    dr(7) = x.PUme
    '        '    dr(8) = x.montoUSD
    '        '    dr(9) = x.descripcion
    '        '    dt.Rows.Add(dr)
    '        'Next
    '        'dgvCompra.Table.Records.DeleteAll()
    '        'dgvCompra.DataSource = dt

    '    Else
    '        lblEstado.Text = "Ingrese un importe."
    '        Timer1.Enabled = True
    '        PanelError.Visible = True
    '        TiempoEjecutar(10)
    '        'txtFondoMN.Select(0, txtFondoMN.Text.Length)
    '        Exit Sub
    '    End If
    '    '////////////INTERESES
    '    If txtTotalC2MN.Value > 0 Then
    '        Dim c As New movimiento
    '        c.cuenta = "1631"
    '        c.idAsiento = 2
    '        c.idmovimiento = GetMaxIDMovimiento() + 1
    '        c.tipo = "D"
    '        c.Cant = 1
    '        c.PUmn = CDec(txtTotalC2MN.Value / c.Cant)
    '        c.PUme = CDec(txtTotalC2ME.Value / c.Cant)
    '        c.monto = txtTotalC2MN.Value
    '        c.montoUSD = txtTotalC2ME.Value
    '        ListaMovimientos.Add(c)
    '    End If
    '    If txtTotalC2MN.Value > 0 Then
    '        Dim c As New movimiento
    '        c.cuenta = "4931"
    '        c.idAsiento = 2
    '        c.idmovimiento = GetMaxIDMovimiento() + 1
    '        c.tipo = "H"
    '        c.Cant = 1
    '        c.PUmn = CDec(txtTotalC2MN.Value / c.Cant)
    '        c.PUme = CDec(txtTotalC2ME.Value / c.Cant)
    '        c.monto = txtTotalC2MN.Value
    '        c.montoUSD = txtTotalC2ME.Value
    '        ListaMovimientos.Add(c)
    '    End If

    ' End Sub



    Public Sub AsientoIntereses()
        Dim asientoBL As New asiento
        Dim nMovimiento As New movimiento


        For Each i As Record In dgvPrestamoRO.Table.Records

            If i.GetValue("descripcion") = "CAPITAL" Then
                If i.GetValue("pago") > 0 Then

                    asientoBL = New asiento
                    asientoBL.idEmpresa = Gempresas.IdEmpresaRuc
                    asientoBL.idCentroCostos = GEstableciento.IdEstablecimiento

                    asientoBL.idEntidad = cboDepositoHijo.SelectedValue
                    asientoBL.nombreEntidad = cboDepositoHijo.Text

                    asientoBL.tipoEntidad = "BC"
                    asientoBL.fechaProceso = DateTime.Now
                    asientoBL.codigoLibro = "1"
                    asientoBL.tipo = "D"

                    asientoBL.tipoAsiento = ASIENTO_CONTABLE.OTRAS_SALIDAS_CAJA

                    'asientoBL.importeMN = CDec(txtpagocapital.Value)
                    'asientoBL.importeME = CDec(txtpagocapitalme.Value)
                    asientoBL.importeMN = CDec(i.GetValue("pago"))
                    asientoBL.importeME = CDec(i.GetValue("pagoME"))
                    asientoBL.glosa = Glosa()


                    nMovimiento = New movimiento
                    ' nMovimiento.cuenta = "4411"
                    nMovimiento.cuenta = txtcuentatipo.Text
                    nMovimiento.descripcion = "PRÉSTAMOS"
                    nMovimiento.tipo = "D"
                    nMovimiento.monto = CDec(i.GetValue("pago"))
                    nMovimiento.montoUSD = CDec(i.GetValue("pagoME"))
                    nMovimiento.usuarioActualizacion = usuario.IDUsuario
                    nMovimiento.fechaActualizacion = DateTime.Now
                    asientoBL.movimiento.Add(nMovimiento)

                    nMovimiento = New movimiento
                    nMovimiento.cuenta = txtCuentaO.Text
                    nMovimiento.descripcion = cboDepositoHijo.Text
                    nMovimiento.tipo = "H"
                    nMovimiento.monto = CDec(i.GetValue("pago"))
                    nMovimiento.montoUSD = CDec(i.GetValue("pagoME"))
                    nMovimiento.usuarioActualizacion = usuario.IDUsuario
                    nMovimiento.fechaActualizacion = DateTime.Now
                    asientoBL.movimiento.Add(nMovimiento)
                    ListaAsientos.Add(asientoBL)
                End If

            Else
                If i.GetValue("pago") > 0 Then

                    asientoBL = New asiento
                    asientoBL.idEmpresa = Gempresas.IdEmpresaRuc
                    asientoBL.idCentroCostos = GEstableciento.IdEstablecimiento

                    asientoBL.idEntidad = txtProveedor.Tag
                    asientoBL.nombreEntidad = txtProveedor.Text

                    asientoBL.tipoEntidad = "BC"
                    asientoBL.fechaProceso = DateTime.Now
                    asientoBL.codigoLibro = "1"
                    asientoBL.tipo = "D"
                    asientoBL.tipoAsiento = "IPR"
                    asientoBL.importeMN = CDec(i.GetValue("pago"))
                    asientoBL.importeME = CDec(i.GetValue("pagoME"))
                    asientoBL.glosa = Glosa()



                    nMovimiento = New movimiento
                    'nMovimiento.cuenta = "4411"
                    'nMovimiento.cuenta = txtcuentatipo.Text
                    nMovimiento.cuenta = i.GetValue("cuentaH")
                    nMovimiento.descripcion = "PRÉSTAMOS"
                    nMovimiento.tipo = "D"
                    nMovimiento.monto = CDec(i.GetValue("pago"))
                    nMovimiento.montoUSD = CDec(i.GetValue("pagoME"))
                    nMovimiento.usuarioActualizacion = usuario.IDUsuario
                    nMovimiento.fechaActualizacion = DateTime.Now
                    asientoBL.movimiento.Add(nMovimiento)

                    nMovimiento = New movimiento
                    nMovimiento.cuenta = txtCuentaO.Text
                    nMovimiento.descripcion = cboDepositoHijo.Text
                    nMovimiento.tipo = "H"
                    nMovimiento.monto = CDec(i.GetValue("pago"))
                    nMovimiento.montoUSD = CDec(i.GetValue("pagoME"))
                    nMovimiento.usuarioActualizacion = usuario.IDUsuario
                    nMovimiento.fechaActualizacion = DateTime.Now
                    asientoBL.movimiento.Add(nMovimiento)
                    ListaAsientos.Add(asientoBL)


                    ''ultimoo devengado
                    asientoBL = New asiento
                    asientoBL.idEmpresa = Gempresas.IdEmpresaRuc
                    asientoBL.idCentroCostos = GEstableciento.IdEstablecimiento
                    asientoBL.fechaProceso = DateTime.Now
                    asientoBL.codigoLibro = "1"
                    asientoBL.tipo = "D"
                    asientoBL.tipoAsiento = ASIENTO_CONTABLE.OTRAS_ENTRADAS_CAJA
                    asientoBL.importeMN = CDec(i.GetValue("pago"))
                    asientoBL.importeME = CDec(i.GetValue("pagoME"))
                    asientoBL.glosa = "Por Devengado del interes"

                    nMovimiento = New movimiento
                    ' nMovimiento.cuenta = "493"
                    'nMovimiento.cuenta = i.GetValue("cuenta")
                    nMovimiento.cuenta = i.GetValue("cuentaDevH")
                    nMovimiento.descripcion = "INTERESES DIFERIDOS"
                    nMovimiento.tipo = "H"
                    'nMovimiento.tipo = i.GetValue("tipo")
                    nMovimiento.monto = CDec(i.GetValue("pago"))
                    nMovimiento.montoUSD = CDec(i.GetValue("pagoME"))
                    nMovimiento.usuarioActualizacion = usuario.IDUsuario
                    nMovimiento.fechaActualizacion = DateTime.Now
                    asientoBL.movimiento.Add(nMovimiento)

                    nMovimiento = New movimiento
                    'nMovimiento.cuenta = "779"
                    'nMovimiento.cuenta = txtdevengado.Text
                    nMovimiento.cuenta = i.GetValue("cuentaDev")
                    nMovimiento.descripcion = "OTROS INGRESOS FINANCIEROS"
                    nMovimiento.tipo = "D"
                    'nMovimiento.tipo = txttip2.Text
                    nMovimiento.monto = CDec(i.GetValue("pago"))
                    nMovimiento.montoUSD = CDec(i.GetValue("pagoME"))
                    nMovimiento.usuarioActualizacion = usuario.IDUsuario
                    nMovimiento.fechaActualizacion = DateTime.Now
                    asientoBL.movimiento.Add(nMovimiento)
                    ListaAsientos.Add(asientoBL)

                    'ElseIf txtTipo.Text = "INST.FINANCIERAS" Then


                    '    nMovimiento = New movimiento
                    '    nMovimiento.cuenta = "4511"
                    '    nMovimiento.descripcion = "INSTITUCIONES FINANCIERAS"
                    '    nMovimiento.tipo = "D"
                    '    nMovimiento.monto = CDec(txtpagocapital.Value)
                    '    nMovimiento.montoUSD = CDec(txtpagocapitalme.Value)
                    '    nMovimiento.usuarioActualizacion = usuario.IDUsuario
                    '    nMovimiento.fechaActualizacion = DateTime.Now
                    '    asientoBL.movimiento.Add(nMovimiento)

                    '    nMovimiento = New movimiento
                    '    nMovimiento.cuenta = txtCuentaO.Text
                    '    nMovimiento.descripcion = cboDepositoHijo.Text
                    '    nMovimiento.tipo = "H"
                    '    nMovimiento.monto = CDec(txtpagocapital.Value)
                    '    nMovimiento.montoUSD = CDec(txtpagocapitalme.Value)
                    '    nMovimiento.usuarioActualizacion = usuario.IDUsuario
                    '    nMovimiento.fechaActualizacion = DateTime.Now
                    '    asientoBL.movimiento.Add(nMovimiento)

                    'ElseIf txtTipo.Text = "CUENTAS POR PAGAR RELACIONADAS" Then

                    '    nMovimiento = New movimiento
                    '    nMovimiento.cuenta = "471"
                    '    nMovimiento.descripcion = "PRÉSTAMOS"
                    '    nMovimiento.tipo = "D"
                    '    nMovimiento.monto = CDec(txtpagocapital.Value)
                    '    nMovimiento.montoUSD = CDec(txtpagocapitalme.Value)
                    '    nMovimiento.usuarioActualizacion = usuario.IDUsuario
                    '    nMovimiento.fechaActualizacion = DateTime.Now
                    '    asientoBL.movimiento.Add(nMovimiento)

                    '    nMovimiento = New movimiento
                    '    nMovimiento.cuenta = txtCuentaO.Text
                    '    nMovimiento.descripcion = cboDepositoHijo.Text
                    '    nMovimiento.tipo = "H"
                    '    nMovimiento.monto = CDec(txtpagocapital.Value)
                    '    nMovimiento.montoUSD = CDec(txtpagocapitalme.Value)
                    '    nMovimiento.usuarioActualizacion = usuario.IDUsuario
                    '    nMovimiento.fechaActualizacion = DateTime.Now
                    '    asientoBL.movimiento.Add(nMovimiento)

                    'End If
                End If

            End If
        Next


        'ListaAsientos.Add(asientoBL)
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


        asientoBL.importeMN = CDec(txtpagointeres.Value)
        asientoBL.importeME = CDec(txtpagointeresme.Value)
        asientoBL.glosa = Glosa()



        If txtTipo.Text = "ACC./SOCIOS/DIREC./PERSONAL" Then

            nMovimiento = New movimiento
            nMovimiento.cuenta = "4411"
            nMovimiento.descripcion = "PRÉSTAMOS"
            nMovimiento.tipo = "D"
            nMovimiento.monto = CDec(txtpagointeres.Value)
            nMovimiento.montoUSD = CDec(txtpagointeresme.Value)
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nMovimiento.fechaActualizacion = DateTime.Now
            asientoBL.movimiento.Add(nMovimiento)

            nMovimiento = New movimiento
            nMovimiento.cuenta = txtCuentaO.Text
            nMovimiento.descripcion = cboDepositoHijo.Text
            nMovimiento.tipo = "H"
            nMovimiento.monto = CDec(txtpagointeres.Value)
            nMovimiento.montoUSD = CDec(txtpagointeresme.Value)
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nMovimiento.fechaActualizacion = DateTime.Now
            asientoBL.movimiento.Add(nMovimiento)

        ElseIf txtTipo.Text = "INST.FINANCIERAS" Then


            nMovimiento = New movimiento
            nMovimiento.cuenta = "4511"
            nMovimiento.descripcion = "PRÉSTAMOS"
            nMovimiento.tipo = "D"
            nMovimiento.monto = CDec(txtpagointeres.Value)
            nMovimiento.montoUSD = CDec(txtpagointeresme.Value)
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nMovimiento.fechaActualizacion = DateTime.Now
            asientoBL.movimiento.Add(nMovimiento)

            nMovimiento = New movimiento
            nMovimiento.cuenta = txtCuentaO.Text
            nMovimiento.descripcion = cboDepositoHijo.Text
            nMovimiento.tipo = "H"
            nMovimiento.monto = CDec(txtpagointeres.Value)
            nMovimiento.montoUSD = CDec(txtpagointeresme.Value)
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nMovimiento.fechaActualizacion = DateTime.Now
            asientoBL.movimiento.Add(nMovimiento)
        ElseIf txtTipo.Text = "CUENTAS POR PAGAR RELACIONADAS" Then


            nMovimiento = New movimiento
            nMovimiento.cuenta = "471"
            nMovimiento.descripcion = "Por regularizar"
            nMovimiento.tipo = "D"
            nMovimiento.monto = CDec(txtpagointeres.Value)
            nMovimiento.montoUSD = CDec(txtpagointeresme.Value)
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nMovimiento.fechaActualizacion = DateTime.Now
            asientoBL.movimiento.Add(nMovimiento)

            nMovimiento = New movimiento
            nMovimiento.cuenta = txtCuentaO.Text
            nMovimiento.descripcion = cboDepositoHijo.Text
            nMovimiento.tipo = "H"
            nMovimiento.monto = CDec(txtpagointeres.Value)
            nMovimiento.montoUSD = CDec(txtpagocapitalme.Value)
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nMovimiento.fechaActualizacion = DateTime.Now
            asientoBL.movimiento.Add(nMovimiento)
        End If


        ListaAsientos.Add(asientoBL)
    End Sub


    Public Sub AsientoIntereses3()
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

        asientoBL.importeMN = CDec(txtpagointeres.Value)
        asientoBL.importeME = CDec(txtpagointeresme.Value)
        asientoBL.glosa = Glosa()

        nMovimiento = New movimiento
        nMovimiento.cuenta = "4931"
        nMovimiento.descripcion = "Por regularizar"
        nMovimiento.tipo = "D"
        nMovimiento.monto = CDec(txtpagointeres.Value)
        nMovimiento.montoUSD = CDec(txtpagointeresme.Value)
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = DateTime.Now
        asientoBL.movimiento.Add(nMovimiento)

        nMovimiento = New movimiento
        nMovimiento.cuenta = "779"
        ' nMovimiento.descripcion = txtCajaOrigen.Text
        nMovimiento.descripcion = cboDepositoHijo.Text
        nMovimiento.tipo = "H"
        nMovimiento.monto = CDec(txtpagointeres.Value)
        nMovimiento.montoUSD = CDec(txtpagointeresme.Value)
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = DateTime.Now
        asientoBL.movimiento.Add(nMovimiento)

        ListaAsientos.Add(asientoBL)
    End Sub




    Function Glosa() As String
        Dim strGlosa As String = Nothing

        'With frmCuentasPorPagar
        strGlosa = "Por pagos prestamo, en " & cboTipoDoc.Text & " con fecha: " & txtFechaTrans.Value

        'End With
        Return strGlosa
    End Function


    Public Function AS_DebeCaja(Cuenta As String, cDescripcion As String, cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = Cuenta,
              .descripcion = cDescripcion,
              .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = usuario.IDUsuario}

        Return nMovimiento
    End Function

    Public Function AS_DebeCajaDolares(Cuenta As String, cDescripcion As String, cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = Cuenta,
              .descripcion = cDescripcion,
              .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = GFichaUsuarios.IdCajaUsuario}
        Return nMovimiento
    End Function


    Public Function AS_HaberCliente(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
      .cuenta = lblCuentaProveedor,
      .descripcion = lblNomProveedor,
      .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
      .monto = cMonto,
      .montoUSD = cMontoUS,
      .fechaActualizacion = DateTime.Now,
      .usuarioActualizacion = usuario.IDUsuario}

        Return nMovimiento
    End Function


    'Function asientoCaja(monedaExtrajera As Decimal, MontoMonedaExt As Decimal, MontoSoles As Decimal) As asiento
    '    Dim cuentaFinacieraSA As New EstadosFinancierosSA
    '    Dim nAsiento As New asiento
    '    Dim nDebe As New movimiento
    '    Dim nHaber As New movimiento

    '    nAsiento = New asiento
    '    nAsiento.idDocumento = 0
    '    nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
    '    nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
    '    nAsiento.idEntidad = lblIdProveedor
    '    nAsiento.nombreEntidad = lblNomProveedor
    '    nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
    '    nAsiento.fechaProceso = txtFechaTrans.Value
    '    nAsiento.codigoLibro = "1"
    '    nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
    '    nAsiento.tipoAsiento = ASIENTO_CONTABLE.PAGO_COMPRA
    '    nAsiento.importeMN = txtImporteCompramn.Value ' dgvDetalleItems.Rows(i.Index).Cells(6).Value()
    '    nAsiento.importeME = txtImporteComprame.Value ' dgvDetalleItems.Rows(i.Index).Cells(7).Value()
    '    nAsiento.glosa = Glosa()
    '    nAsiento.usuarioActualizacion = usuario.IDUsuario
    '    nAsiento.fechaActualizacion = DateTime.Now







    '    'For Each i As DataGridViewRow In dgvDetalleItems.Rows
    '    For Each i As Record In dgvPrestamos.Table.Records
    '        If CDec(i.GetValue("pagoTotalMN")) > 0 Then

    '            Select Case cboMoneda.SelectedValue
    '                Case 0
    '                    nAsiento.movimiento.Add(AS_HaberCliente(i.GetValue("pagoTotalMN"), i.GetValue("pagoTotalME")))
    '                    nAsiento.movimiento.Add(AS_DebeCaja(cuentaFinacieraSA.GetUbicar_estadosFinancierosPorID(cboDepositoHijo.SelectedValue).cuenta, i.GetValue("colGlosa"), i.GetValue("pagoTotalMN"), i.GetValue("pagoTotalME")))
    '                Case 1
    '                    If (MontoMonedaExt > CDec(txtImporteComprame.Value) And MontoSoles = 0.0) Then
    '                        nAsiento.movimiento.Add(AS_HaberCliente(i.GetValue("pagoTotalMN"), i.GetValue("pagoTotalME")))
    '                        nAsiento.movimiento.Add(AS_DebeCaja(cuentaFinacieraSA.GetUbicar_estadosFinancierosPorID(cboDepositoHijo.SelectedValue).cuenta, i.GetValue("colGlosa"), i.GetValue("pagoTotalMN"), i.GetValue("pagoTotalME")))
    '                        nAsiento.movimiento.Add(AS_HaberCliente(0.0, (MontoMonedaExt - CDec(txtImporteComprame.Value))))
    '                        nAsiento.movimiento.Add(AS_DebeCaja("676", i.GetValue("colGlosa"), 0.0, (MontoMonedaExt - CDec(txtImporteComprame.Value))))
    '                    ElseIf (MontoMonedaExt < CDec(txtImporteComprame.Value) And MontoSoles = 0.0) Then
    '                        nAsiento.movimiento.Add(AS_HaberCliente(i.GetValue("pagoTotalMN"), i.GetValue("pagoTotalME")))
    '                        nAsiento.movimiento.Add(AS_DebeCaja(cuentaFinacieraSA.GetUbicar_estadosFinancierosPorID(cboDepositoHijo.SelectedValue).cuenta, i.GetValue("colGlosa"), i.GetValue("pagoTotalMN"), i.GetValue("pagoTotalME")))
    '                        nAsiento.movimiento.Add(AS_HaberCliente(0.0, (CDec(txtImporteComprame.Value) - monedaExtrajera)))
    '                        nAsiento.movimiento.Add(AS_DebeCaja("776", i.GetValue("colGlosa"), 0.0, (CDec(txtImporteComprame.Value) - monedaExtrajera)))
    '                    Else
    '                        nAsiento.movimiento.Add(AS_HaberCliente(i.GetValue("pagoTotalMN"), i.GetValue("pagoTotalME")))
    '                        nAsiento.movimiento.Add(AS_DebeCaja(cuentaFinacieraSA.GetUbicar_estadosFinancierosPorID(cboDepositoHijo.SelectedValue).cuenta, i.GetValue("colGlosa"), i.GetValue("pagoTotalMN"), i.GetValue("pagoTotalME")))




    '                    End If
    '            End Select
    '        End If
    '    Next












    '    Return nAsiento
    'End Function


    Public Sub Grabar()
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim documentoSA As New DocumentoSA
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim ndocumento As New documento
        Dim ndocumentoCaja As New documentoCaja
        Dim ndocumentoCajaDetalle As New documentoCajaDetalle
        Dim ListadocumentoCajaDetalle As New List(Of documentoCajaDetalle)
        Dim asiento As New asiento
        Dim ListaAsiento As New List(Of asiento)

        Dim cajaUsarioBE As New cajaUsuario
        Dim cajaUsariodetalleBE As New cajaUsuariodetalle
        Dim cajaUsariodetalleListaBE As New List(Of cajaUsuariodetalle)
        Dim SaldoMonedaExt As Decimal = 0
        Dim MontoMonedaExt As Decimal = 0
        Dim MontoSoles As Decimal = 0
        Dim n As New RecolectarDatos()
        Dim datos As List(Of RecolectarDatos) = RecolectarDatos.Instance()
        datos.Clear()
        Try


            With ndocumento
                .idDocumento = lblIdDocumento.Text
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                If Not IsNothing(GProyectos) Then
                    .idProyecto = GProyectos.IdProyectoActividad
                End If
                .tipoDoc = cboTipoDoc.SelectedValue
                .fechaProceso = txtFechaTrans.Value
                .nroDoc = txtNumeroCompr.Text.Trim
                .idOrden = Nothing
                .tipoOperacion = "9907"
                .usuarioActualizacion = usuario.IDUsuario
                .fechaActualizacion = DateTime.Now
            End With

            With ndocumentoCaja
                .codigoLibro = "9907"
                .periodo = PeriodoGeneral
                .idDocumento = lblIdDocumento.Text
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .tipoMovimiento = MovimientoCaja.SalidaDinero
                .tipoOperacion = "101"
                '.codigoProveedor = lblIdProveedor
                '.fechaProceso = fecha
                '.fechaCobro = fecha
                .tipoDocPago = cboTipoDoc.SelectedValue
                If cboTipoDoc.SelectedValue = "001" Then
                    .numeroDoc = Nothing
                    .numeroOperacion = txtNumOper.Text.Trim
                    .ctaCorrienteDeposito = txtCuentaCorriente.Text.Trim
                    .ctaIntebancaria = Nothing
                    .bancoEntidad = cboEntidades.SelectedValue
                    .fechaProceso = txtFechaTrans.Value
                    .fechaCobro = Date.Now
                    .entregado = "SI"
                ElseIf cboTipoDoc.SelectedValue = "003" Then
                    .numeroDoc = Nothing
                    .numeroOperacion = txtNumOper.Text.Trim
                    .ctaCorrienteDeposito = Nothing
                    .bancoEntidad = cboEntidades.SelectedValue
                    .fechaProceso = txtFechaTrans.Value
                    .fechaCobro = Date.Now
                    .entregado = "SI"
                    '.ctaIntebancaria = txtCtaInterbancaria.Text
                ElseIf cboTipoDoc.SelectedValue = "007" Then ' cheques
                    .numeroDoc = txtNumeroCompr.Text.Trim
                    .numeroOperacion = Nothing
                    .ctaCorrienteDeposito = Nothing
                    .ctaIntebancaria = Nothing
                    .bancoEntidad = Nothing
                    .fechaProceso = txtFechaTrans.Value
                    .fechaCobro = txtFechaCobro.Value
                    .entregado = "NO"
                ElseIf cboTipoDoc.SelectedValue = "111" Then
                    .numeroDoc = txtNumeroCompr.Text.Trim
                    .numeroOperacion = Nothing
                    .ctaCorrienteDeposito = Nothing
                    .ctaIntebancaria = Nothing
                    .bancoEntidad = Nothing
                    .fechaProceso = txtFechaTrans.Value
                    .fechaCobro = txtFechaCobro.Value
                    .entregado = "NO"
                ElseIf cboTipoDoc.SelectedValue = "109" Then
                    .numeroDoc = txtNumeroCompr.Text.Trim
                    .numeroOperacion = Nothing
                    .ctaCorrienteDeposito = Nothing
                    .ctaIntebancaria = Nothing
                    .bancoEntidad = Nothing
                    .fechaCobro = txtFechaTrans.Value
                    .fechaProceso = txtFechaCobro.Value
                    .entregado = "NO"
                End If

                .moneda = cboMoneda.SelectedValue
                .entidadFinanciera = cboDepositoHijo.SelectedValue
                .tipoCambio = txtTipoCambio.Value
                .montoSoles = txtImporteCompramn.Value
                .montoUsd = txtImporteComprame.Value

                .glosa = Glosa()
                .usuarioModificacion = cboDepositoHijo.SelectedValue
                .fechaModificacion = DateTime.Now
                .DeudaEvalMN = CDec(lblDeudaPendiente.Text)
                .DeudaEvalME = CDec(lblDeudaPendienteme.Text)
                .codigoProveedor = CInt(txtProveedor.Tag)
            End With

            ndocumento.documentoCaja = ndocumentoCaja


            For Each i As Record In dgvPrestamoRO.Table.Records
                If i.GetValue("pago") > 0 Then
                    ndocumentoCajaDetalle = New documentoCajaDetalle
                    ndocumentoCajaDetalle.fecha = txtFechaTrans.Value
                    ndocumentoCajaDetalle.idItem = i.GetValue("secuencia")
                    ndocumentoCajaDetalle.DetalleItem = i.GetValue("descripcion")
                    ndocumentoCajaDetalle.montoSoles = i.GetValue("pago")
                    ndocumentoCajaDetalle.montoUsd = i.GetValue("pagoME")
                    '///////////
                    ndocumentoCajaDetalle.moneda = cboMoneda.SelectedValue
                    ndocumentoCajaDetalle.entregado = "SI"
                    ndocumentoCajaDetalle.diferTipoCambio = txtTipoCambio.Value

                    ndocumentoCajaDetalle.idDocumento = lblIdDocumento.Text
                    ndocumentoCajaDetalle.documentoAfectado = CInt(i.GetValue("idCuota"))
                    ndocumentoCajaDetalle.usuarioModificacion = cboDepositoHijo.SelectedValue
                    ndocumentoCajaDetalle.fechaModificacion = Date.Now
                    ndocumentoCajaDetalle.documentoAfectadodetalle = CInt(i.GetValue("secuencia"))
                    ListadocumentoCajaDetalle.Add(ndocumentoCajaDetalle)
                End If
            Next

            'For Each i As Record In dgvPrestamos.Table.Records
            '    ' For Each i As DataGridViewRow In dgvDetalleItems.Rows
            '    'If CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value()) > 0 Then



            '    'If CDec(i.GetValue("pagoCapitalMN")) > 0 Then
            '    ndocumentoCajaDetalle = New documentoCajaDetalle
            '    ndocumentoCajaDetalle.fecha = txtFechaTrans.Value
            '    ' ndocumentoCajaDetalle.idItem = dgvDetalleItems.Rows(i.Index).Cells(0).Value()
            '    ndocumentoCajaDetalle.idItem = i.GetValue("idDocumento")
            '    ndocumentoCajaDetalle.DetalleItem = i.GetValue("colGlosa")


            '    ndocumentoCajaDetalle.montoSoles = i.GetValue("pagoTotalMN")

            '    ndocumentoCajaDetalle.montoUsd = i.GetValue("pagoTotalME")


            '    ''//////////////
            '    ndocumentoCajaDetalle.capitalMN = i.GetValue("pagoCapitalMN")
            '    ndocumentoCajaDetalle.capitalME = i.GetValue("pagoCapitalME")

            '    ndocumentoCajaDetalle.interesMN = i.GetValue("PagoInteresMN")
            '    ndocumentoCajaDetalle.interesME = i.GetValue("PagoInteresME")

            '    ndocumentoCajaDetalle.seguroMN = i.GetValue("pagoSeguroMN")
            '    ndocumentoCajaDetalle.seguroME = i.GetValue("pagoSeguroME")

            '    ndocumentoCajaDetalle.otroMN = i.GetValue("pagoOtroMN")
            '    ndocumentoCajaDetalle.otroME = i.GetValue("pagoOtroME")

            '    ndocumentoCajaDetalle.portesMN = i.GetValue("pagoPortesMN")
            '    ndocumentoCajaDetalle.portesME = i.GetValue("pagoPortesME")

            '    ndocumentoCajaDetalle.envMN = i.GetValue("pagoEnvMN")
            '    ndocumentoCajaDetalle.envME = i.GetValue("pagoEnvME")

            '    ndocumentoCajaDetalle.moraMN = i.GetValue("pagoMoraMN")
            '    ndocumentoCajaDetalle.moraME = i.GetValue("pagoMoraME")

            '    ndocumentoCajaDetalle.compMN = i.GetValue("pagoCompMN")
            '    ndocumentoCajaDetalle.compME = i.GetValue("pagoCompME")

            '    ndocumentoCajaDetalle.morOtroMN = i.GetValue("pagoMoraOtroMN")
            '    ndocumentoCajaDetalle.morOtroME = i.GetValue("pagoMoraOtroME")

            '    ndocumentoCajaDetalle.morOtro1MN = i.GetValue("pagoMoraOtro1MN")
            '    ndocumentoCajaDetalle.morOtro1ME = i.GetValue("pagoMoraOtro1ME")
            '    ndocumentoCajaDetalle.moneda = "1"


            '    '///////////

            '    ndocumentoCajaDetalle.entregado = "SI"
            '    ndocumentoCajaDetalle.diferTipoCambio = txtTipoCambio.Value

            '    ndocumentoCajaDetalle.documentoAfectado = lblIdDocumento.Text
            '    ndocumentoCajaDetalle.usuarioModificacion = cboDepositoHijo.SelectedValue
            '    ndocumentoCajaDetalle.fechaModificacion = Date.Now
            '    ndocumentoCajaDetalle.documentoAfectadodetalle = CInt(i.GetValue("idCuota"))
            '    ListadocumentoCajaDetalle.Add(ndocumentoCajaDetalle)
            '    'SaldoMonedaExt += CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value())
            '    'MontoMonedaExt += CDec(dgvDetalleItems.Rows(i.Index).Cells(5).Value())
            '    'MontoSoles += CDec(dgvDetalleItems.Rows(i.Index).Cells(8).Value())
            '    'End If

            'Next





            ndocumento.documentoCaja.documentoCajaDetalle = ListadocumentoCajaDetalle
            'Select Case cboTipoDoc.SelectedValue
            '    Case "109", "003", "001"
            '        asiento = asientoCaja(SaldoMonedaExt, MontoMonedaExt, MontoSoles)
            '        ListaAsiento.Add(asiento)
            '        ndocumento.asiento = ListaAsiento
            '    Case "007", "111"

            AsientoIntereses()
            'If txtpagointeres.Value > 0 Then
            '    AsientoIntereses2()
            '    'AsientoIntereses3()
            'End If
            ndocumento.asiento = ListaAsientos


            cajaUsarioBE = Nothing
            'End Select

            n.IdAlmacen = documentoCajaSA.SaveGroupCajaPrestamo(ndocumento, cajaUsarioBE)
            datos.Add(n)
            lblEstado.Text = "Transacción realizada con éxito!"
            lblEstado.Image = My.Resources.ok4
            Dispose()
        Catch ex As Exception
            lblEstado.Text = ex.Message
            lblEstado.Image = My.Resources.warning2
        End Try
    End Sub


    Private Sub cargarDatosCuenta(idCaja As Integer)
        Dim estadoSA As New EstadosFinancierosSA
        Dim estadoBL As New estadosFinancieros
        Dim estadoSaldoBL As New estadosFinancieros

        estadoBL = estadoSA.GetUbicar_estadosFinancierosPorID(cboDepositoHijo.SelectedValue)
        estadoSaldoBL = estadoSA.GetEstadoSaldoXEFME(cboDepositoHijo.SelectedValue)
        If (Not IsNothing(estadoBL)) Then
            cboMoneda.SelectedValue = estadoBL.codigo
            txtCuentaO.Text = estadoBL.cuenta
            nudDeudaPendienteme.Value = estadoSaldoBL.importeBalanceME
            nudDeudaPendientemn.Value = estadoSaldoBL.importeBalanceMN
            Select Case cboMoneda.SelectedValue
                Case 1
                    'pnNacional.Location = New Point(49, 25)
                    'pnExtranjero.Location = New Point(420, 25)
                    pnImpMEDisp.Location = New Point(170, 21)
                    pnImpMNDisp.Location = New Point(9, 21)
                    'txtImporteComprame.Enabled = False
                    'txtImporteCompramn.Enabled = True
                    ' PictureBox5.Visible = False
                    pnDiferencia.Visible = False
                    'txtImporteCompramn.Value = 0.0
                    'txtImporteComprame.Value = 0.0
                    'txtTipoCambio.Value = 0
                    'txtDiferenciaMontos.Value = 0

                    Select Case tb19.ToggleState
                        Case ToggleButton2.ToggleButtonState.OFF 'dolares
                            'pnTipoCambio.Visible = True
                            ' pnExtranjero.Visible = True
                            pnDiferencia.Visible = True
                            pnDiferencia.Location = New Point(650, 25)
                            'pnTipoCambio.Enabled = True
                        Case ToggleButton2.ToggleButtonState.ON 'soles
                            'pnTipoCambio.Visible = True
                            'pnExtranjero.Visible = True
                            pnDiferencia.Visible = False
                            'pnTipoCambio.Enabled = False
                            'txtTipoCambio.Value = lblTipoCambio.Text
                    End Select

                Case 2

                    ''pnExtranjero.Location = New Point(49, 25)
                    'pnImpMEDisp.Location = New Point(9, 21)
                    'pnImpMNDisp.Location = New Point(170, 21)
                    'txtImporteComprame.Enabled = True
                    'txtImporteCompramn.Enabled = False
                    ''PictureBox5.Visible = True
                    'pnDiferencia.Visible = True
                    'txtImporteCompramn.Value = 0.0
                    'txtImporteComprame.Value = 0.0
                    'txtTipoCambio.Value = 0
                    'txtDiferenciaMontos.Value = 0
                    'Select Case tb19.ToggleState
                    '    Case ToggleButton2.ToggleButtonState.OFF 'dolares
                    '        ' pnTipoCambio.Visible = True
                    '        'pnExtranjero.Visible = True
                    '        pnDiferencia.Visible = True
                    '        'pnExtranjero.Enabled = True
                    '        ' pnNacional.Location = New Point(430, 25)
                    '        pnDiferencia.Location = New Point(650, 25)
                    '        txtTipoCambio.Value = lblTipoCambio.Text
                    '        ' pnTipoCambio.Enabled = False
                    '    Case ToggleButton2.ToggleButtonState.ON 'soles
                    '        'pnTipoCambio.Visible = True
                    '        ' pnExtranjero.Visible = True
                    '        pnDiferencia.Visible = True
                    '        'pnNacional.Location = New Point(430, 25)
                    '        pnDiferencia.Location = New Point(650, 25)
                    '        txtTipoCambio.Value = 0.0
                    '        'pnTipoCambio.Enabled = True
                    'End Select
            End Select
            'GetObtenerSaldoEF()
        End If
    End Sub



    Public Sub CargarCajasTipo(strBusqueda As String)
        Dim estadoSA As New EstadosFinancierosSA
        Dim taBLASA As New tablaDetalleSA
        Dim ListaestadoBL As New List(Of estadosFinancieros)
        Dim estadoBL As New estadosFinancieros

        Try
            'With estadoBL
            '    .idestado = Nothing
            '    .descripcion = Nothing

            'End With

            'ListaestadoBL.Add(estadoBL)

            'For Each items In (estadoSA.ObtenerEFPorCuentaFinanciera(GEstableciento.IdEstablecimiento, strBusqueda))
            '    ListaestadoBL.Add(items)
            'Next

            ''ListaestadoBL = (estadoSA.ObtenerEFPorCuentaFinanciera(GEstableciento.IdEstablecimiento, strBusqueda))
            'Me.cboDepositoHijo.DataSource = ListaestadoBL
            'cboDepositoHijo.DataSource = estadoSA.ObtenerEFPorCuentaFinanciera(GEstableciento.IdEstablecimiento, strBusqueda)
            'cboDepositoHijo.DisplayMember = "descripcion"

            Me.cboDepositoHijo.DataSource = estadoSA.ObtenerEFPorCuentaFinanciera(New estadosFinancieros With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                                  .tipo = strBusqueda,
                                                                                  .tipoConsulta = StatusTipoConsulta.XEmpresa})
            Me.cboDepositoHijo.DisplayMember = "descripcion"
            Me.cboDepositoHijo.ValueMember = "idestado"
            cboDepositoHijo.SelectedValue = -1
            ' Tag = 0

            cboMoneda.ValueMember = "codigoDetalle"
            cboMoneda.DisplayMember = "descripcion"
            cboMoneda.DataSource = taBLASA.GetListaTablaDetalle(4, "1")
            cboMoneda.SelectedValue = -1

            'estadoBL = estadoSA.GetUbicar_estadosFinancierosPorID()
            'txtMoneda.Tag = estadoBL.codigo
            'txtMoneda.Text = estadoBL.descripcion

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
        cboTipoDoc.DataSource = tabla
        cboTipoDoc.ValueMember = "codigoDetalle"
        cboTipoDoc.DisplayMember = "descripcion"
        cboTipoDoc.SelectedValue = "001"

    End Sub


    Private Sub cargarCtasFinan()
        If cboTipo.Text = "CUENTAS EN EFECTIVO" Then
            CargarCajasTipo("EF")
            Dim lista As New List(Of String)
            lista.Add("001")
            lista.Add("109")

            ListaDocPago(lista)
            cboTipoDoc.SelectedValue = "001"
        ElseIf cboTipo.Text = "CUENTAS EN BANCO" Then
            CargarCajasTipo("BC")
            Dim lista As New List(Of String)
            lista.Add("001")
            lista.Add("003")
            lista.Add("007")
            lista.Add("111")
            ListaDocPago(lista)
            cboTipoDoc.SelectedValue = "001"
        End If
    End Sub



    Private Sub SetRenderer()
        Dim styleRenderer1 As New StyledRenderer()
        '  tbFormaPago.Renderer = styleRenderer1
        'Dim styleRenderer2 As New StyledRenderer()
        'tbIGV.Renderer = styleRenderer2
        'Dim styleRenderer3 As New StyledRenderer()
        'toggleButton11.Renderer = styleRenderer3
        'Dim styleRenderer4 As New StyledRenderer()
        'toggleButton12.Renderer = styleRenderer4
        ' Panel2.Visible = False
    End Sub
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
    '            Select Case lblMovimiento.Text
    '                Case "OTRAS ENTRADAS A CAJA"
    '                    If (txtFondoMN.Value > 0 And txtFondoME.Value > 0) Then
    '                        ListaMovimientos.Clear()
    '                        n.cuenta = txtCuentaO.Text
    '                        n.idAsiento = lstAsiento.SelectedValue
    '                        n.idmovimiento = GetMaxIDMovimiento() + 1
    '                        n.tipo = "D"
    '                        n.Cant = 1
    '                        n.PUmn = CDec(txtFondoMN.Value / n.Cant)
    '                        n.PUme = CDec(txtFondoME.Value / n.Cant)
    '                        n.monto = txtFondoMN.Value
    '                        n.montoUSD = txtFondoME.Value
    '                        ListaMovimientos.Add(n)

    '                        cargarAsientosDefault()
    '                    Else
    '                        lblEstado.Text = "Ingrese un importe."
    '                        Timer1.Enabled = True
    '                        PanelError.Visible = True
    '                        TiempoEjecutar(10)
    '                        txtFondoME.Select(0, txtFondoMN.Text.Length)
    '                        Exit Sub
    '                    End If
    '                Case "OTRAS SALIDAS DE CAJA"
    '                    If (txtFondoME.Value > 0 And txtSaldoMN.Value > 0) Then
    '                        ListaMovimientos.Clear()
    '                        n.cuenta = txtCuentaO.Text
    '                        n.idAsiento = lstAsiento.SelectedValue
    '                        n.idmovimiento = GetMaxIDMovimiento() + 1
    '                        n.tipo = "H"
    '                        n.Cant = 1
    '                        n.PUmn = CDec(txtSaldoMN.Value / n.Cant)
    '                        n.PUme = CDec(txtFondoME.Value / n.Cant)
    '                        n.monto = txtSaldoMN.Value
    '                        n.montoUSD = txtFondoME.Value
    '                        ListaMovimientos.Add(n)
    '                        dgvCompra.Table.Records.DeleteAll()
    '                        cargarAsientosDefault()
    '                    Else
    '                        lblEstado.Text = "Ingrese un importe."
    '                        Timer1.Enabled = True
    '                        PanelError.Visible = True
    '                        TiempoEjecutar(10)
    '                        txtFondoME.Select(0, txtFondoMN.Text.Length)
    '                        Exit Sub
    '                    End If

    '            End Select

    '    End Select
    'End Sub

    Public Sub ObtenerTablaGenerales()
        Dim tablaSA As New tablaDetalleSA

        cboEntidades.ValueMember = "codigoDetalle"
        cboEntidades.DisplayMember = "descripcion"
        cboEntidades.DataSource = tablaSA.GetListaTablaDetalle(3, "1")

        'If tbFormaPago.ToggleState = Tools.ToggleButtonState.Active Then
        '    txtNumero.Visible = True
        '    cboTipoDoc.SelectedValue = "007"
        'ElseIf tbFormaPago.ToggleState = Tools.ToggleButtonState.Inactive Then

        '    txtNumero.Visible = False
        '    cboTipoDoc.SelectedValue = "109"
        'End If
    End Sub


    'Sub GridCFG(GGC As GridGroupingControl)
    '    'GGC.TableOptions.ShowRowHeader = False
    '    'GGC.TopLevelGroupOptions.ShowCaption = False
    '    'GGC.ShowColumnHeaders = True

    '    colorx = New GridMetroColors()
    '    colorx.HeaderColor.HoverColor = Color.FromArgb(15, 128, 128, 128)
    '    colorx.HeaderTextColor.HoverTextColor = Color.Gray
    '    colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
    '    GGC.SetMetroStyle(colorx)
    '    GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 7.5F

    'End Sub

    'Private Sub ListaDefaultDeInicio()
    '    'If (txtFondoMN.Value > 0 And txtFondoME.Value > 0) Then
    '    dockingManager1.DockControlInAutoHideMode(GroupBox2, Syncfusion.Windows.Forms.Tools.DockingStyle.Bottom, 239)
    '    dockingManager1.SetDockLabel(GroupBox2, "Asiento contable")
    '    dockingManager1.CloseEnabled = False

    '    'Else
    '    'lblEstado.Text = "Ingrese un importe."
    '    'Timer1.Enabled = True
    '    'PanelError.Visible = True
    '    'TiempoEjecutar(10)
    '    ''txtFondoME.Select(0, txtFondoMN.Text.Length)
    '    'End If

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

    Sub totalespagos()

        Dim deuda As Decimal = 0
        Dim deudaME As Decimal = 0

        For Each r As Record In dgvPrestamoRO.Table.Records

            deuda += r.GetValue("montomn")
            deudaME += r.GetValue("montome")
        Next
        txttotalpago.Value = deuda


    End Sub








    'Function asientoCaja(monedaExtrajera As Decimal, MontoMonedaExt As Decimal, MontoSoles As Decimal) As asiento
    '    Dim cuentaFinacieraSA As New EstadosFinancierosSA
    '    Dim nAsiento As New asiento
    '    Dim nDebe As New movimiento
    '    Dim nHaber As New movimiento

    '    nAsiento = New asiento
    '    nAsiento.idDocumento = 0
    '    nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
    '    nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
    '    nAsiento.idEntidad = lblIdProveedor
    '    nAsiento.nombreEntidad = lblNomProveedor
    '    nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
    '    nAsiento.fechaProceso = txtFechaTrans.Value
    '    nAsiento.codigoLibro = "1"
    '    nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
    '    nAsiento.tipoAsiento = ASIENTO_CONTABLE.PAGO_COMPRA
    '    nAsiento.importeMN = txtImporteCompramn.Value ' dgvDetalleItems.Rows(i.Index).Cells(6).Value()
    '    nAsiento.importeME = txtImporteComprame.Value ' dgvDetalleItems.Rows(i.Index).Cells(7).Value()
    '    nAsiento.glosa = Glosa()
    '    nAsiento.usuarioActualizacion = GFichaUsuarios.IdCajaUsuario
    '    nAsiento.fechaActualizacion = DateTime.Now

    '    For Each i As DataGridViewRow In dgvDetalleItems.Rows
    '        If CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value()) > 0 Then

    '            Select Case cboMoneda.SelectedValue
    '                Case 0
    '                    nAsiento.movimiento.Add(AS_HaberCliente(dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
    '                    nAsiento.movimiento.Add(AS_DebeCaja(cuentaFinacieraSA.GetUbicar_estadosFinancierosPorID(cboDepositoHijo.SelectedValue).cuenta, dgvDetalleItems.Rows(i.Index).Cells(1).Value(), dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
    '                Case 1
    '                    If (MontoMonedaExt > CDec(txtImporteComprame.Value) And MontoSoles = 0.0) Then
    '                        nAsiento.movimiento.Add(AS_HaberCliente(dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
    '                        nAsiento.movimiento.Add(AS_DebeCaja(cuentaFinacieraSA.GetUbicar_estadosFinancierosPorID(cboDepositoHijo.SelectedValue).cuenta, dgvDetalleItems.Rows(i.Index).Cells(1).Value(), dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
    '                        nAsiento.movimiento.Add(AS_HaberCliente(0.0, (MontoMonedaExt - CDec(txtImporteComprame.Value))))
    '                        nAsiento.movimiento.Add(AS_DebeCaja("676", dgvDetalleItems.Rows(i.Index).Cells(1).Value(), 0.0, (MontoMonedaExt - CDec(txtImporteComprame.Value))))
    '                    ElseIf (MontoMonedaExt < CDec(txtImporteComprame.Value) And MontoSoles = 0.0) Then
    '                        nAsiento.movimiento.Add(AS_HaberCliente(dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
    '                        nAsiento.movimiento.Add(AS_DebeCaja(cuentaFinacieraSA.GetUbicar_estadosFinancierosPorID(cboDepositoHijo.SelectedValue).cuenta, dgvDetalleItems.Rows(i.Index).Cells(1).Value(), dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
    '                        nAsiento.movimiento.Add(AS_HaberCliente(0.0, (CDec(txtImporteComprame.Value) - monedaExtrajera)))
    '                        nAsiento.movimiento.Add(AS_DebeCaja("776", dgvDetalleItems.Rows(i.Index).Cells(1).Value(), 0.0, (CDec(txtImporteComprame.Value) - monedaExtrajera)))
    '                    Else
    '                        nAsiento.movimiento.Add(AS_HaberCliente(dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
    '                        nAsiento.movimiento.Add(AS_DebeCaja(cuentaFinacieraSA.GetUbicar_estadosFinancierosPorID(cboDepositoHijo.SelectedValue).cuenta, dgvDetalleItems.Rows(i.Index).Cells(1).Value(), dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
    '                    End If
    '            End Select
    '        End If
    '    Next
    '    Return nAsiento
    'End Function


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
        If TiempoRestante > 0 Then
            parpadeo()

            'lblAgregar.Visible = True
            'lblMensaje.Visible = True
            'tsSave.Enabled = False
            'lblMensaje.Text = "Agregar otro en: " & TiempoRestante
            TiempoRestante = TiempoRestante - 1
        ElseIf TiempoRestante = 0 Then
            Timer1.Enabled = False
            'lblEstado.ForeColor = Color.Navy
            'lblEstado.BackColor = Color.Transparent
            PanelError.Visible = False
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



    Public Sub UbicarDocumento(ByVal intIdDocumento As Integer)

        Dim documentoPrestamoSA As New documentoPrestamoSA
        Dim objLista As New DocumentoCajaDetalleSA
        Dim detalle As New documentoCajaDetalle

        Dim docPres As New prestamosSA
        Dim entidadsa As New entidadSA
        Dim tabla As New tablaDetalleSA
        Dim Persona As New PersonaSA

        Dim docdetalle As New List(Of documentoPrestamos)


        With docPres.UbicarPrestamoXcodigoSingle(intIdDocumento)

            lblIdDocumento.Text = intIdDocumento
            txtFechaComprobante.Value = .fechaPrestamo
            txtProveedor.Tag = .idBeneficiario

            'txtProveedor.Text = entidadsa.UbicarEntidadPorIdentidad(Gempresas.IdEmpresaRuc, .tipoBeneficiario, .idBeneficiario).nombre
            If .tipoBeneficiario = "PR" Then
                txtProveedor.Text = entidadsa.UbicarEntidadPorIdentidad(Gempresas.IdEmpresaRuc, .tipoBeneficiario, .idBeneficiario).nombre
            ElseIf .tipoBeneficiario = "TR" Then
                txtProveedor.Text = Persona.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, CStr(.idBeneficiario), .tipoBeneficiario).nombres
            ElseIf .tipoBeneficiario = "CL" Then
                txtProveedor.Text = entidadsa.UbicarEntidadPorIdentidad(Gempresas.IdEmpresaRuc, .tipoBeneficiario, .idBeneficiario).nombre
            End If

            txtNumeroCompr.Text = .nroDoc
            txtComprobante.Text = tabla.GetUbicarTablaID(10, .DocPrestamo).descripcion
            txtTipoCambio.Value = .tipoCambio

            txtTipo.Text = .tipo
        End With



        '////////////7


        Dim saldoItem As Decimal = 0
        Dim saldoItemME As Decimal = 0
        Dim conteo As Integer = 0
        Dim valor As Integer = 0


        'For Each i As documentoCajaDetalle In objLista.ObtenerPrestamosPorPagarPorDetails(intIdDocumento)
        For Each i As documentoPrestamoDetalle In objLista.ListarPrestamosPorPagarPorDetails(intIdDocumento)

            saldoItem = i.DeudaMonto - i.PagadoMonto
            saldoItemME = i.DeudaMontoME - i.PagadoMontoME
            Me.dgvPrestamoRO.Table.AddNewRecord.SetCurrent()
            Me.dgvPrestamoRO.Table.AddNewRecord.BeginEdit()

            If saldoItem > 0 Then
                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("idDocumento", intIdDocumento)
                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("idCuota", i.idCuota)
                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("secuencia", i.secuencia)
                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", i.cuota)
                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("descripcion", i.descripcion)
                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montomn", saldoItem)
                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montome", saldoItemME)
                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("pago", CDec(0))
                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("saldo", CDec(0))
                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("pagoME", CDec(0))
                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("saldoME", CDec(0))
                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuenta", i.cuenta)
                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaH", i.cuentaH)
                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDev", i.devengado)
                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDevH", i.devengadoH)
                Me.dgvPrestamoRO.Table.AddNewRecord.EndEdit()
                'valor = i.idCuota
            End If

            'If Not i.EstadoCobro = "PG" Then

            '    saldoItem = i.DeudaMonto - i.PagadoMonto
            '    saldoItemME = i.DeudaMontoME - i.PagadoMontoME

            '    saldoInteres = i.DeudaInteres - i.PagadoInteres
            '    saldoInteresME = i.DeudaInteresME - i.PagadoInteresME
            '    saldoSeguro = i.DeudaSeguro - i.PagadoSeguro
            '    saldoSeguroME = i.DeudaSeguroME - i.PagadoSeguroME
            '    saldoOtro = i.MontoDeudaSoles - i.PagadoOtro
            '    saldoOtroME = i.MontoDeudaSoles - i.PagadoOtroME
            '    saldoPortes = i.DeudaPortes - i.PagadoPortes
            '    saldoPortesME = i.DeudaPortesME - i.PagadoPortesME

            '    saldoEnv = i.DeudaEnv - i.PagadoEnv
            '    saldoEnvME = i.DeudaEnvME - i.PagadoEnvME
            '    saldoMora = i.DeudaMora - i.PagadoMora
            '    saldoMoraME = i.DeudaMoraME - i.PagadoMora
            '    saldoCompen = i.DeudaComp - i.PagadoComp
            '    saldoCompenME = i.DeudaCompME - i.PagadoCompME
            '    saldoMorOtro = i.DeudaMorOtro - i.PagadoMorOtro
            '    saldoMorOtroME = i.DeudaMorOtroMe - i.PagadoMorOtroMe
            '    saldoMorOtro1 = i.DeudaMorOtro1 - i.PagadoMorOtro1
            '    saldoMorOtro1ME = i.DeudaMorOtro1ME - i.PagadoMorOtro1ME

            '    'SaldoTotal = saldoItem + saldoInteres + saldoSeguro + saldoOtro + saldoPortes + saldoEnv + saldoMora + saldoCompen + saldoMorOtro + saldoMorOtro1
            '    'SaldoTotalME = saldoItemME + saldoInteresME + saldoSeguroME + saldoOtroME + saldoPortesME + saldoEnvME + saldoMoraME + saldoCompenME + saldoMorOtroME + saldoMorOtro1ME

            '    Me.dgvPrestamos.Table.AddNewRecord.SetCurrent()
            '    Me.dgvPrestamos.Table.AddNewRecord.BeginEdit()
            '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("idDocumento", intIdDocumento)
            '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("idCuota", i.secuencia)
            '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("colGlosa", i.referencia)
            '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("colcapital", saldoItem)
            '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("colcapitalUSD", saldoItemME)
            '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("colInteresSoles", saldoInteres)
            '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("colInteresUSD", saldoInteresME)
            '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("Seguro", saldoSeguro)
            '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("SeguroME", saldoSeguroME)
            '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("Otro", saldoOtro)
            '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("otroME", saldoOtroME)
            '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("Portes", saldoPortes)
            '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("PortesME", saldoPortesME)
            '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("EnvioCuenta", saldoEnv)
            '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("EnvCuentaME", saldoEnvME)
            '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("moratorioMN", saldoMora)
            '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("moratorioME", saldoMoraME)
            '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("compensaMN", saldoCompen)
            '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("compensaME", saldoCompenME)
            '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("morOtroMN", saldoMorOtro)
            '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("morOtroME", saldoMorOtroME)
            '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("morOtro1MN", saldoMorOtro1)
            '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("morOtro1ME", saldoMorOtro1ME)
            '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("FechaPago", i.fechaVcto)
            '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("FechaPlazo", i.fechaPlazo)

            '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("pagoCapitalMN", CDec(0.0))
            '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("pagoCapitalME", CDec(0.0))
            '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("PagoInteresMN", CDec(0.0))
            '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("PagoInteresME", CDec(0.0))
            '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("pagoSeguroMN", CDec(0.0))
            '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("pagoSeguroME", CDec(0.0))
            '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("pagoOtroMN", CDec(0.0))
            '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("pagoOtroME", CDec(0.0))
            '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("pagoPortesMN", CDec(0.0))
            '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("pagoPortesME", CDec(0.0))
            '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("pagoEnvMN", CDec(0.0))
            '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("pagoEnvME", CDec(0.0))

            '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("pagoMoraMN", CDec(0.0))
            '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("pagoMoraME", CDec(0.0))
            '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("pagoCompMN", CDec(0.0))
            '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("pagoCompME", CDec(0.0))
            '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("pagoMoraOtroMN", CDec(0.0))
            '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("pagoMoraOtroME", CDec(0.0))
            '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("pagoMoraOtro1MN", CDec(0.0))
            '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("pagoMoraOtro1ME", CDec(0.0))

            '    Me.dgvPrestamos.Table.AddNewRecord.EndEdit()


            '    'cTotalmn = CDec(i.MontoDeudaSoles) - CDec(i.MontoPagadoSoles)
            '    'cTotalme = CDec(i.MontoDeudaUSD) - CDec(i.MontoPagadoUSD)
            '    'If cTotalmn < 0 Then
            '    '    cTotalmn = 0
            '    'End If
            '    'If cTotalme < 0 Then
            '    '    cTotalme = 0
            '    'End If
            '    'saldomn += cTotalmn
            '    'saldome += cTotalme
            '    'If cTotalmn > 0 Or cTotalme > 0 Then
            '    '    .dgvDetalleItems.Rows.Add(i.idItem, i.DetalleItem, Nothing,
            '    '                               Nothing, cTotalmn, cTotalme,
            '    '                               "0.00", "0.00", "0.00", "0.00", Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT, i.secuencia)
            '    'End If
            'End If
        Next


        '//////////


        'For Each i In documentoPrestamoSA.ListadoCuotas(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, intIdDocumento, "PO")


        '    Me.dgvPrestamos.Table.AddNewRecord.SetCurrent()
        '    Me.dgvPrestamos.Table.AddNewRecord.BeginEdit()
        '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("idDocumento", i.idDocumento)
        '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("idCuota", i.idCuota)
        '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("colGlosa", i.referencia)
        '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("colcapital", i.montoSoles)
        '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("colcapitalUSD", i.montoDolares)
        '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("colInteresSoles", i.montoInteresSoles)
        '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("colInteresUSD", i.montoInteresUSD)
        '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("Seguro", i.montoSeguro)
        '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("SeguroME", i.montoSeguroME)
        '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("Otro", i.montoOtro)
        '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("otroME", i.montoOtroME)
        '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("Portes", i.montoPortes)
        '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("PortesME", i.montoPortesME)
        '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("EnvioCuenta", i.montoEnvCuenta)
        '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("EnvCuentaME", i.montoEnvCuentaME)
        '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("moratorioMN", i.intMoratorio)
        '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("moratorioME", i.intMoratorioME)
        '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("compensaMN", i.IntCompensatorio)
        '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("compensaME", i.IntCompensatorioME)
        '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("morOtroMN", i.otros)
        '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("morOtroME", i.otrosME)
        '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("morOtro1MN", i.otros1)
        '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("morOtro1ME", i.otros1ME)
        '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("FechaPago", i.fechaVcto)
        '    Me.dgvPrestamos.Table.CurrentRecord.SetValue("FechaPlazo", i.fechaPlazo)
        '    Me.dgvPrestamos.Table.AddNewRecord.EndEdit()
        'Next

        'Catch ex As Exception
        '    MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        'End Try
        totalespagos()
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

    'Sub GetTableGrid()
    '    Dim dt As New DataTable()
    '    dt.Columns.Add("idDocumento", GetType(Integer))
    '    dt.Columns.Add("idCuota", GetType(Integer))
    '    dt.Columns.Add("colGlosa", GetType(String))
    '    dt.Columns.Add("colcapital", GetType(Decimal))
    '    dt.Columns.Add("colInteresSoles", GetType(Decimal))
    '    dt.Columns.Add("Seguro", GetType(Decimal))
    '    dt.Columns.Add("Otro", GetType(Decimal))
    '    dt.Columns.Add("Portes", GetType(Decimal))
    '    dt.Columns.Add("EnvioCuenta", GetType(Decimal))

    '    dt.Columns.Add("moratorioMN", GetType(Decimal))
    '    dt.Columns.Add("compensaMN", GetType(Decimal))
    '    dt.Columns.Add("morOtroMN", GetType(Decimal))
    '    dt.Columns.Add("morOtro1MN", GetType(Decimal))

    '    dt.Columns.Add("colTotalSoles", GetType(Decimal))

    '    dt.Columns.Add("colcapitalUSD", GetType(Decimal))
    '    dt.Columns.Add("colInteresUSD", GetType(Decimal))
    '    dt.Columns.Add("SeguroME", GetType(Decimal))
    '    dt.Columns.Add("otroME", GetType(Decimal))
    '    dt.Columns.Add("PortesME", GetType(Decimal))
    '    dt.Columns.Add("EnvCuentaME", GetType(Decimal))
    '    dt.Columns.Add("colTotalUSD", GetType(Decimal))



    '    dt.Columns.Add("moratorioME", GetType(Decimal))


    '    dt.Columns.Add("compensaME", GetType(Decimal))


    '    dt.Columns.Add("morOtroME", GetType(Decimal))


    '    dt.Columns.Add("morOtro1ME", GetType(Decimal))


    '    dt.Columns.Add("FechaPago", GetType(Date))
    '    dt.Columns.Add("FechaPlazo", GetType(Date))

    '    'new

    '    dt.Columns.Add("pagoCapitalMN", GetType(Decimal))
    '    dt.Columns.Add("pagoCapitalME", GetType(Decimal))
    '    dt.Columns.Add("PagoInteresMN", GetType(Decimal))
    '    dt.Columns.Add("PagoInteresME", GetType(Decimal))
    '    dt.Columns.Add("pagoSeguroMN", GetType(Decimal))
    '    dt.Columns.Add("pagoSeguroME", GetType(Decimal))
    '    dt.Columns.Add("pagoOtroMN", GetType(Decimal))
    '    dt.Columns.Add("pagoOtroME", GetType(Decimal))
    '    dt.Columns.Add("pagoPortesMN", GetType(Decimal))
    '    dt.Columns.Add("pagoPortesME", GetType(Decimal))
    '    dt.Columns.Add("pagoEnvMN", GetType(Decimal))
    '    dt.Columns.Add("pagoEnvME", GetType(Decimal))

    '    dt.Columns.Add("pagoMoraMN", GetType(Decimal))
    '    dt.Columns.Add("pagoMoraME", GetType(Decimal))

    '    dt.Columns.Add("pagoCompMN", GetType(Decimal))
    '    dt.Columns.Add("pagoCompME", GetType(Decimal))

    '    dt.Columns.Add("pagoMoraOtroMN", GetType(Decimal))
    '    dt.Columns.Add("pagoMoraOtroME", GetType(Decimal))

    '    dt.Columns.Add("pagoMoraOtro1MN", GetType(Decimal))
    '    dt.Columns.Add("pagoMoraOtro1ME", GetType(Decimal))


    '    dt.Columns.Add("saldoCapMN", GetType(Decimal))
    '    dt.Columns.Add("saldoCapME", GetType(Decimal))

    '    dt.Columns.Add("saldoIntMN", GetType(Decimal))
    '    dt.Columns.Add("saldoIntME", GetType(Decimal))

    '    dt.Columns.Add("saldoSegMN", GetType(Decimal))
    '    dt.Columns.Add("saldoSegME", GetType(Decimal))

    '    dt.Columns.Add("saldoOtrMN", GetType(Decimal))
    '    dt.Columns.Add("saldoOtrME", GetType(Decimal))


    '    dt.Columns.Add("saldoPortMN", GetType(Decimal))
    '    dt.Columns.Add("saldoPortME", GetType(Decimal))

    '    dt.Columns.Add("saldoEnvMN", GetType(Decimal))
    '    dt.Columns.Add("saldoEnvME", GetType(Decimal))

    '    dt.Columns.Add("SaldoMoraMN", GetType(Decimal))
    '    dt.Columns.Add("SaldoMoraME", GetType(Decimal))

    '    dt.Columns.Add("SaldoCompMN", GetType(Decimal))
    '    dt.Columns.Add("SaldoCompME", GetType(Decimal))

    '    dt.Columns.Add("SaldoMorOtrMN", GetType(Decimal))
    '    dt.Columns.Add("SaldoMorOtrME", GetType(Decimal))

    '    dt.Columns.Add("SaldoMorOtr1MN", GetType(Decimal))
    '    dt.Columns.Add("SaldoMorOtr1ME", GetType(Decimal))

    '    dt.Columns.Add("pagoTotalMN", GetType(Decimal))
    '    dt.Columns.Add("pagoTotalME", GetType(Decimal))

    '    dgvPrestamos.DataSource = dt
    'End Sub
#End Region

    Private Sub frmPrestamosPago_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub




    Private Sub frmPrestamosPago_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub



    Sub totalesPagosCuenta()
        Dim capital As Decimal = 0.0
        Dim capitalme As Decimal = 0.0


        Dim interes As Decimal = 0.0
        Dim interesme As Decimal = 0.0

        For Each i As Record In dgvPrestamoRO.Table.Records

            If i.GetValue("descripcion") = "CAPITAL" Then

                capital += Math.Round((CDec(i.GetValue("pago"))), 2)
                capitalme += Math.Round((CDec(i.GetValue("pagoME"))), 2)
            Else
                interes += Math.Round((CDec(i.GetValue("pago"))), 2)
                interesme += Math.Round((CDec(i.GetValue("pagoME"))), 2)
            End If


        Next

        txtpagocapital.Value = capital
        txtpagocapitalme.Value = capitalme
        txtpagointeres.Value = interes
        txtpagointeresme.Value = interesme
    End Sub

    'Sub totalesPagosCuenta()
    '    Dim capital As Decimal = 0.0
    '    Dim capitalme As Decimal = 0.0


    '    Dim interes As Decimal = 0.0
    '    Dim interesme As Decimal = 0.0



    '    For Each i As Record In dgvPrestamos.Table.Records

    '        capital += Math.Round((CDec(i.GetValue("pagoCapitalMN"))), 2)
    '        capitalme += Math.Round((CDec(i.GetValue("pagoCapitalME"))), 2)

    '        interes += Math.Round((CDec(i.GetValue("PagoInteresMN"))), 2)
    '        interesme += Math.Round((CDec(i.GetValue("PagoInteresME"))), 2)

    '        interes += Math.Round((CDec(i.GetValue("pagoSeguroMN"))), 2)
    '        interesme += Math.Round((CDec(i.GetValue("pagoSeguroME"))), 2)

    '        interes += Math.Round((CDec(i.GetValue("pagoOtroMN"))), 2)
    '        interesme += Math.Round((CDec(i.GetValue("pagoOtroME"))), 2)

    '        interes += Math.Round((CDec(i.GetValue("pagoPortesMN"))), 2)
    '        interesme += Math.Round((CDec(i.GetValue("pagoPortesME"))), 2)

    '        interes += Math.Round((CDec(i.GetValue("pagoEnvMN"))), 2)
    '        interesme += Math.Round((CDec(i.GetValue("pagoEnvME"))), 2)

    '        interes += Math.Round((CDec(i.GetValue("pagoMoraMN"))), 2)
    '        interesme += Math.Round((CDec(i.GetValue("pagoMoraME"))), 2)

    '        interes += Math.Round((CDec(i.GetValue("pagoCompMN"))), 2)
    '        interesme += Math.Round((CDec(i.GetValue("pagoCompME"))), 2)

    '        interes += Math.Round((CDec(i.GetValue("pagoMoraOtroMN"))), 2)
    '        interesme += Math.Round((CDec(i.GetValue("pagoMoraOtroME"))), 2)

    '        interes += Math.Round((CDec(i.GetValue("pagoMoraOtro1MN"))), 2)
    '        interesme += Math.Round((CDec(i.GetValue("pagoMoraOtro1ME"))), 2)

    '    Next

    '    txtpagocapital.Value = capital
    '    txtpagocapitalme.Value = capitalme
    '    txtpagointeres.Value = interes
    '    txtpagointeresme.Value = interesme


    'End Sub

    Sub CalculoGRID()

        Dim nudSaldo As Decimal = Math.Round((txtImporteCompramn.Value), 2)
        Dim nudSaldoME As Decimal = Math.Round((txtImporteComprame.Value), 2)
        Dim cSaldo As Decimal = 0
        Dim cSaldoex As Decimal = 0
        Dim cSaldoME As Decimal = 0
        Dim cSaldoexME As Decimal = 0

        For Each i As Record In dgvPrestamoRO.Table.Records

            If nudSaldo > 0 Then
                cSaldo = Math.Round((CDec(i.GetValue("montomn"))), 2) - nudSaldo
                If cSaldo >= 0 Then
                    i.SetValue("pago", nudSaldo)
                    i.SetValue("saldo", cSaldo)
                    nudSaldo = 0
                Else
                    i.SetValue("pago", CDec(i.GetValue("montomn")))
                    i.SetValue("saldo", CDec(0.0))
                    nudSaldo = cSaldo * -1
                End If

            Else

                i.SetValue("pago", CDec(0.0))
                i.SetValue("saldo", CDec(0.0))

            End If


            ''ME////////////////////////////////////////////////////////////
            If nudSaldoME > 0 Then

                cSaldoME = CDec(i.GetValue("montome")) - nudSaldoME
                If cSaldoME >= 0 Then
                    i.SetValue("pagoME", nudSaldoME)
                    i.SetValue("saldoME", cSaldoME)
                    nudSaldoME = 0
                Else
                    i.SetValue("pagoME", CDec(i.GetValue("montome")))
                    i.SetValue("saldoME", CDec(0.0))
                    nudSaldoME = cSaldoME * -1
                End If

            Else

                i.SetValue("pagoME", CDec(0.0))
                i.SetValue("saldoME", CDec(0.0))

            End If
        Next



        totalesPagosCuenta()

    End Sub
    'Sub CalculoGRID()

    '    Dim nudSaldo As Decimal = Math.Round((txtImporteCompramn.Value), 2)
    '    Dim nudSaldoME As Decimal = Math.Round((txtImporteComprame.Value), 2)
    '    Dim cSaldo As Decimal = 0
    '    Dim cSaldoex As Decimal = 0
    '    Dim cSaldoME As Decimal = 0
    '    Dim cSaldoexME As Decimal = 0

    '    For Each i As Record In dgvPrestamos.Table.Records

    '        If nudSaldo > 0 Then
    '            cSaldo = Math.Round((CDec(i.GetValue("morOtro1MN"))), 2) - nudSaldo
    '            If cSaldo >= 0 Then
    '                i.SetValue("pagoMoraOtro1MN", nudSaldo)
    '                i.SetValue("SaldoMorOtr1MN", cSaldo)
    '                nudSaldo = 0
    '            Else
    '                i.SetValue("pagoMoraOtro1MN", CDec(i.GetValue("morOtro1MN")))
    '                i.SetValue("SaldoMorOtr1MN", CDec(0.0))
    '                nudSaldo = cSaldo * -1
    '            End If

    '            cSaldo = CDec(i.GetValue("morOtroMN")) - nudSaldo
    '            If cSaldo >= 0 Then
    '                i.SetValue("pagoMoraOtroMN", nudSaldo)
    '                i.SetValue("SaldoMorOtrMN", cSaldo)
    '                nudSaldo = 0
    '            Else
    '                i.SetValue("pagoMoraOtroMN", CDec(i.GetValue("morOtroMN")))
    '                i.SetValue("SaldoMorOtrMN", CDec(0.0))
    '                nudSaldo = cSaldo * -1
    '            End If

    '            cSaldo = CDec(i.GetValue("compensaMN")) - nudSaldo
    '            If cSaldo >= 0 Then
    '                i.SetValue("pagoCompMN", nudSaldo)
    '                i.SetValue("SaldoCompMN", cSaldo)
    '                nudSaldo = 0
    '            Else
    '                i.SetValue("pagoCompMN", CDec(i.GetValue("compensaMN")))
    '                i.SetValue("SaldoCompMN", CDec(0.0))
    '                nudSaldo = cSaldo * -1
    '            End If
    '            cSaldo = CDec(i.GetValue("moratorioMN")) - nudSaldo
    '            If cSaldo >= 0 Then
    '                i.SetValue("pagoMoraMN", nudSaldo)
    '                i.SetValue("SaldoMoraMN", cSaldo)
    '                nudSaldo = 0
    '            Else
    '                i.SetValue("pagoMoraMN", CDec(i.GetValue("moratorioMN")))
    '                i.SetValue("SaldoMoraMN", CDec(0.0))
    '                nudSaldo = cSaldo * -1
    '            End If
    '            cSaldo = CDec(i.GetValue("EnvioCuenta")) - nudSaldo
    '            If cSaldo >= 0 Then
    '                i.SetValue("pagoEnvMN", nudSaldo)
    '                i.SetValue("saldoEnvMN", cSaldo)
    '                nudSaldo = 0
    '            Else
    '                i.SetValue("pagoEnvMN", CDec(i.GetValue("EnvioCuenta")))
    '                i.SetValue("saldoEnvMN", CDec(0.0))
    '                nudSaldo = cSaldo * -1
    '            End If
    '            cSaldo = CDec(i.GetValue("Portes")) - nudSaldo
    '            If cSaldo >= 0 Then
    '                i.SetValue("pagoPortesMN", nudSaldo)
    '                i.SetValue("saldoPortMN", cSaldo)
    '                nudSaldo = 0
    '            Else
    '                i.SetValue("pagoPortesMN", CDec(i.GetValue("Portes")))
    '                i.SetValue("saldoPortMN", CDec(0.0))
    '                nudSaldo = cSaldo * -1
    '            End If
    '            cSaldo = CDec(i.GetValue("Otro")) - nudSaldo
    '            If cSaldo >= 0 Then
    '                i.SetValue("pagoOtroMN", nudSaldo)
    '                i.SetValue("saldoOtrMN", cSaldo)
    '                nudSaldo = 0
    '            Else
    '                i.SetValue("pagoOtroMN", CDec(i.GetValue("Otro")))
    '                i.SetValue("saldoOtrMN", CDec(0.0))
    '                nudSaldo = cSaldo * -1
    '            End If
    '            cSaldo = CDec(i.GetValue("Seguro")) - nudSaldo
    '            If cSaldo >= 0 Then
    '                i.SetValue("pagoSeguroMN", nudSaldo)
    '                i.SetValue("saldoSegMN", cSaldo)
    '                nudSaldo = 0
    '            Else
    '                i.SetValue("pagoSeguroMN", CDec(i.GetValue("Seguro")))
    '                i.SetValue("saldoSegMN", CDec(0.0))
    '                nudSaldo = cSaldo * -1
    '            End If
    '            cSaldo = CDec(i.GetValue("colInteresSoles")) - nudSaldo
    '            If cSaldo >= 0 Then
    '                i.SetValue("PagoInteresMN", nudSaldo)
    '                i.SetValue("saldoIntMN", cSaldo)
    '                nudSaldo = 0
    '            Else
    '                i.SetValue("PagoInteresMN", CDec(i.GetValue("colInteresSoles")))
    '                i.SetValue("saldoIntMN", CDec(0.0))
    '                nudSaldo = cSaldo * -1
    '            End If
    '            cSaldo = CDec(i.GetValue("colcapital")) - nudSaldo
    '            If cSaldo >= 0 Then
    '                i.SetValue("pagoCapitalMN", nudSaldo)
    '                i.SetValue("saldoCapMN", cSaldo)
    '                nudSaldo = 0
    '            Else
    '                i.SetValue("pagoCapitalMN", CDec(i.GetValue("colcapital")))
    '                i.SetValue("saldoCapMN", CDec(0.0))
    '                nudSaldo = cSaldo * -1
    '            End If
    '            '///////////////////7
    '            Dim totalPagoMN As Decimal = CDec(i.GetValue("pagoCapitalMN")) + CDec(i.GetValue("PagoInteresMN")) +
    '                CDec(i.GetValue("pagoSeguroMN")) + CDec(i.GetValue("pagoOtroMN")) + CDec(i.GetValue("pagoPortesMN")) +
    '                 CDec(i.GetValue("pagoEnvMN")) + CDec(i.GetValue("pagoMoraMN")) + CDec(i.GetValue("pagoCompMN")) +
    '                 CDec(i.GetValue("pagoMoraOtroMN")) + CDec(i.GetValue("pagoMoraOtro1MN"))

    '            i.SetValue("pagoTotalMN", totalPagoMN)
    '            '//////////////////


    '        Else


    '            i.SetValue("pagoMoraOtro1MN", CDec(0.0))
    '            i.SetValue("SaldoMorOtr1MN", CDec(0.0))
    '            i.SetValue("pagoMoraOtroMN", CDec(0.0))
    '            i.SetValue("SaldoMorOtrMN", CDec(0.0))
    '            i.SetValue("pagoCompMN", CDec(0.0))
    '            i.SetValue("SaldoCompMN", CDec(0.0))
    '            i.SetValue("pagoMoraMN", CDec(0.0))
    '            i.SetValue("SaldoMoraMN", CDec(0.0))
    '            i.SetValue("pagoEnvMN", CDec(0.0))
    '            i.SetValue("saldoEnvMN", CDec(0.0))
    '            i.SetValue("pagoPortesMN", CDec(0.0))
    '            i.SetValue("saldoPortMN", CDec(0.0))
    '            i.SetValue("pagoOtroMN", CDec(0.0))
    '            i.SetValue("saldoOtrMN", CDec(0.0))
    '            i.SetValue("pagoSeguroMN", CDec(0.0))
    '            i.SetValue("saldoSegMN", CDec(0.0))
    '            i.SetValue("PagoInteresMN", CDec(0.0))
    '            i.SetValue("saldoIntMN", CDec(0.0))
    '            i.SetValue("pagoCapitalMN", CDec(0.0))
    '            i.SetValue("saldoCapMN", CDec(0.0))
    '            i.SetValue("pagoTotalMN", CDec(0.0))

    '        End If


    '        ''ME////////////////////////////////////////////////////////////
    '        If nudSaldoME > 0 Then

    '            cSaldoME = CDec(i.GetValue("morOtro1ME")) - nudSaldoME
    '            If cSaldoME >= 0 Then
    '                i.SetValue("pagoMoraOtro1ME", nudSaldoME)
    '                i.SetValue("SaldoMorOtr1ME", cSaldoME)
    '                nudSaldoME = 0
    '            Else
    '                i.SetValue("pagoMoraOtro1ME", CDec(i.GetValue("morOtro1ME")))
    '                i.SetValue("SaldoMorOtr1ME", CDec(0.0))
    '                nudSaldoME = cSaldoME * -1
    '            End If

    '            cSaldoME = CDec(i.GetValue("morOtroME")) - nudSaldoME
    '            If cSaldoME >= 0 Then
    '                i.SetValue("pagoMoraOtroME", nudSaldoME)
    '                i.SetValue("SaldoMorOtrME", cSaldoME)
    '                nudSaldoME = 0
    '            Else
    '                i.SetValue("pagoMoraOtroME", CDec(i.GetValue("morOtroME")))
    '                i.SetValue("SaldoMorOtrME", CDec(0.0))
    '                nudSaldoME = cSaldoME * -1
    '            End If

    '            cSaldoME = CDec(i.GetValue("compensaME")) - nudSaldoME
    '            If cSaldoME >= 0 Then
    '                i.SetValue("pagoCompME", nudSaldoME)
    '                i.SetValue("SaldoCompME", cSaldoME)
    '                nudSaldoME = 0
    '            Else
    '                i.SetValue("pagoCompME", CDec(i.GetValue("compensaME")))
    '                i.SetValue("SaldoCompME", CDec(0.0))
    '                nudSaldoME = cSaldoME * -1
    '            End If

    '            cSaldoME = CDec(i.GetValue("moratorioME")) - nudSaldoME
    '            If cSaldoME >= 0 Then
    '                i.SetValue("pagoMoraME", nudSaldoME)
    '                i.SetValue("SaldoMoraME", cSaldoME)
    '                nudSaldoME = 0
    '            Else
    '                i.SetValue("pagoMoraME", CDec(i.GetValue("moratorioME")))
    '                i.SetValue("SaldoMoraME", CDec(0.0))
    '                nudSaldoME = cSaldoME * -1
    '            End If

    '            cSaldoME = CDec(i.GetValue("EnvCuentaME")) - nudSaldoME
    '            If cSaldoME >= 0 Then
    '                i.SetValue("pagoEnvME", nudSaldoME)
    '                i.SetValue("saldoEnvME", cSaldoME)
    '                nudSaldoME = 0
    '            Else
    '                i.SetValue("pagoEnvME", CDec(i.GetValue("EnvCuentaME")))
    '                i.SetValue("saldoEnvME", CDec(0.0))
    '                nudSaldoME = cSaldoME * -1
    '            End If

    '            cSaldoME = CDec(i.GetValue("PortesME")) - nudSaldoME
    '            If cSaldoME >= 0 Then
    '                i.SetValue("pagoPortesME", nudSaldoME)
    '                i.SetValue("saldoPortME", cSaldoME)
    '                nudSaldoME = 0
    '            Else
    '                i.SetValue("pagoPortesME", CDec(i.GetValue("PortesME")))
    '                i.SetValue("saldoPortME", CDec(0.0))
    '                nudSaldoME = cSaldoME * -1
    '            End If

    '            cSaldoME = CDec(i.GetValue("otroME")) - nudSaldoME
    '            If cSaldoME >= 0 Then
    '                i.SetValue("pagoOtroME", nudSaldoME)
    '                i.SetValue("saldoOtrME", cSaldoME)
    '                nudSaldoME = 0
    '            Else
    '                i.SetValue("pagoOtroME", CDec(i.GetValue("otroME")))
    '                i.SetValue("saldoOtrME", CDec(0.0))
    '                nudSaldoME = cSaldoME * -1
    '            End If

    '            cSaldoME = CDec(i.GetValue("SeguroME")) - nudSaldoME
    '            If cSaldoME >= 0 Then
    '                i.SetValue("pagoSeguroME", nudSaldoME)
    '                i.SetValue("saldoSegME", cSaldoME)
    '                nudSaldoME = 0
    '            Else
    '                i.SetValue("pagoSeguroME", CDec(i.GetValue("SeguroME")))
    '                i.SetValue("saldoSegME", CDec(0.0))
    '                nudSaldoME = cSaldoME * -1
    '            End If

    '            cSaldoME = CDec(i.GetValue("colInteresUSD")) - nudSaldoME
    '            If cSaldoME >= 0 Then
    '                i.SetValue("PagoInteresME", nudSaldoME)
    '                i.SetValue("saldoIntME", cSaldoME)
    '                nudSaldoME = 0
    '            Else
    '                i.SetValue("PagoInteresME", CDec(i.GetValue("colInteresUSD")))
    '                i.SetValue("saldoIntME", CDec(0.0))
    '                nudSaldoME = cSaldoME * -1
    '            End If

    '            cSaldoME = CDec(i.GetValue("colcapitalUSD")) - nudSaldoME
    '            If cSaldoME >= 0 Then
    '                i.SetValue("pagoCapitalME", nudSaldoME)
    '                i.SetValue("saldoCapME", cSaldoME)
    '                nudSaldoME = 0
    '            Else
    '                i.SetValue("pagoCapitalME", CDec(i.GetValue("colcapitalUSD")))
    '                i.SetValue("saldoCapME", CDec(0.0))
    '                nudSaldoME = cSaldoME * -1
    '            End If

    '            '///////////
    '            Dim totalPagoME As Decimal = CDec(i.GetValue("pagoCapitalME")) +
    '                CDec(i.GetValue("PagoInteresME")) + CDec(i.GetValue("pagoSeguroME")) + CDec(i.GetValue("pagoOtroME")) +
    '                CDec(i.GetValue("pagoPortesME")) + CDec(i.GetValue("pagoEnvME")) + CDec(i.GetValue("pagoMoraME")) +
    '                CDec(i.GetValue("pagoCompME")) + CDec(i.GetValue("pagoMoraOtroME")) + CDec(i.GetValue("pagoMoraOtro1ME"))


    '            i.SetValue("pagoTotalME", totalPagoME)

    '            '//////////////////



    '        Else

    '            i.SetValue("pagoMoraOtro1ME", CDec(0.0))
    '            i.SetValue("SaldoMorOtr1ME", CDec(0.0))
    '            i.SetValue("pagoMoraOtroME", CDec(0.0))
    '            i.SetValue("SaldoMorOtrME", CDec(0.0))
    '            i.SetValue("pagoCompME", CDec(0.0))
    '            i.SetValue("SaldoCompME", CDec(0.0))
    '            i.SetValue("pagoMoraME", CDec(0.0))
    '            i.SetValue("SaldoMoraME", CDec(0.0))
    '            i.SetValue("pagoEnvME", CDec(0.0))
    '            i.SetValue("saldoEnvME", CDec(0.0))
    '            i.SetValue("pagoPortesME", CDec(0.0))
    '            i.SetValue("saldoPortME", CDec(0.0))
    '            i.SetValue("pagoOtroME", CDec(0.0))
    '            i.SetValue("saldoOtrME", CDec(0.0))
    '            i.SetValue("pagoSeguroME", CDec(0.0))
    '            i.SetValue("saldoSegME", CDec(0.0))
    '            i.SetValue("PagoInteresME", CDec(0.0))
    '            i.SetValue("saldoIntME", CDec(0.0))
    '            i.SetValue("pagoCapitalME", CDec(0.0))
    '            i.SetValue("saldoCapME", CDec(0.0))
    '            i.SetValue("pagoTotalME", CDec(0.0))

    '        End If
    '    Next



    '    totalesPagosCuenta()

    'End Sub




   

    Private Sub txtImporteCompramn_ValueChanged(sender As Object, e As EventArgs) Handles txtImporteCompramn.ValueChanged
        If txttotalpago.Value >= txtImporteCompramn.Value Then

            If txtTipoCambio.Value > 0 Then
                txtImporteComprame.Value = (txtImporteCompramn.Value / txtTipoCambio.Value)
                CalculoGRID()
            End If

        Else

            PanelError.Visible = True
            lblEstado.Text = "El monto debe ser menor o igual al monto total"
            Exit Sub
        End If
    End Sub

    Private Sub txtImporteComprame_ValueChanged(sender As Object, e As EventArgs) Handles txtImporteComprame.ValueChanged
        If txtTipoCambio.Value > 0 Then
            txtImporteCompramn.Value = (txtImporteComprame.Value * txtTipoCambio.Value)
            CalculoGRID()
        End If
    End Sub

    Private Sub cboDepositoHijo_Click(sender As Object, e As EventArgs) Handles cboDepositoHijo.Click

    End Sub

    Private Sub cboDepositoHijo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDepositoHijo.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Dim value As Object = Me.cboDepositoHijo.SelectedValue

        If IsNumeric(value) Then
            cargarDatosCuenta(CInt(value))
        Else
            'txtFondoEF.DecimalValue = 0
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboTipoDoc_Click(sender As Object, e As EventArgs) Handles cboTipoDoc.Click

    End Sub

    Private Sub cboTipoDoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoDoc.SelectedIndexChanged
        If cboTipoDoc.ValueMember.Trim.Length > 0 Then
            txtNumOper.Clear()
            txtCuentaCorriente.Clear()
            If cboTipoDoc.SelectedValue = "109" Then 'EFECTIVO (que se genere un vocher de caja con los datos del comprobante que se está pagando) 
                pnEntidad.Visible = False
                pnFecha.Visible = False
                Label17.Text = "NRO. VOUCHER:"

            ElseIf cboTipoDoc.SelectedValue = "007" Then ' CHEQUES
                pnEntidad.Visible = False
                pnFecha.Visible = True
                Label17.Text = "NRO. CHEQUE:"
                pnFecha.Location = New Point(25, 43)

            ElseIf cboTipoDoc.SelectedValue = "001" Then ' DEPOSITO EN CUENTA 
                pnEntidad.Visible = True
                pnFecha.Visible = False
                Label17.Text = "NRO. OPERACIÓN:"

            ElseIf cboTipoDoc.SelectedValue = "111" Then ' CHEQUE NO NEGOCIABLE 
                pnEntidad.Visible = False
                pnFecha.Visible = True
                Label17.Text = "NRO. CHEQUE:"
                pnFecha.Location = New Point(25, 43)

            End If
        End If
    End Sub

    

    Private Sub cboTipo_Click(sender As Object, e As EventArgs) Handles cboTipo.Click

    End Sub

    Private Sub cboTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipo.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        'txtFondoEF.DecimalValue = 0
        cargarCtasFinan()
        Me.Cursor = Cursors.Arrow
    End Sub

    

    Private Sub ToggleButton21_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        If Not txttotalpago.Value >= txtImporteCompramn.Value Then
            PanelError.Visible = True
            lblEstado.Text = "El monto debe ser menor o igual al monto total"
            Exit Sub
        End If


        If Not txtImporteCompramn.Value > 0 Then
            PanelError.Visible = True
            lblEstado.Text = "Ingrese un monto a pagar mayor a 0"
            Exit Sub
        End If

        If Not cboEntidades.Text.Trim.Length > 0 Then
            PanelError.Visible = True
            lblEstado.Text = "Elija una entidad"
            Exit Sub
        End If

        If Not txtNumOper.Text.Trim.Length > 0 Then
            PanelError.Visible = True
            lblEstado.Text = "Escriba un numero de operacion"
            Exit Sub
        End If

        If Not txtCuentaCorriente.Text.Trim.Length > 0 Then
            PanelError.Visible = True
            lblEstado.Text = "Escriba un numero de cuenta"
            Exit Sub
        End If
        Grabar()
    End Sub
End Class