Imports Helios.Cont.Business.Entity
Imports Helios.General
'Imports Helios.Planilla.Business.Entity

Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
'Imports Helios.Planilla.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmCajaOnline
    Inherits frmMaster

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim cfecha As Date = DateTime.Now.Date

        lblPeriodo.Text = String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & PeriodoGeneral
        '   CheckBox1.Checked = True
        '   CargarMeses()
        ObtenerEstablecimientos()
    End Sub

    Dim SaldoSoles As Decimal = 0
    Dim SaldoUSD As Decimal = 0

    Dim SaldoSolesNN As Decimal = 0
    Dim SaldoUSDNN As Decimal = 0

    Dim SaldoSolesNN1 As Decimal = 0
    Dim SaldoUSDNN1 As Decimal = 0
#Region "Métodos"



    Public Sub ObtenerCajaOnlinePorRango(intIdEstablecimiento As Integer, strEntidadFinacieras As String, desde As Date, hasta As Date)
        Dim documentoCajaSA As New DocumentoCajaSA

        Try
            SaldoSoles = 0
            SaldoUSD = 0
            SaldoSolesNN = 0
            SaldoUSDNN = 0
            SaldoSolesNN1 = 0
            SaldoUSDNN1 = 0

            lsvCajaOnline.Columns.Clear()
            lsvCajaOnline.Items.Clear()
            lsvCajaOnline.Columns.Add("Fecha", 85)
            lsvCajaOnline.Columns.Add("Movimiento", 60)
            lsvCajaOnline.Columns.Add("Comprobante", 50)
            lsvCajaOnline.Columns.Add("Número comp.", 150)
            lsvCajaOnline.Columns.Add("Glosa", 180)
            lsvCajaOnline.Columns.Add("Entrada MN", 85, HorizontalAlignment.Right)
            lsvCajaOnline.Columns.Add("Entrada ME", 85, HorizontalAlignment.Right)
            lsvCajaOnline.Columns.Add("Sálida MN", 85, HorizontalAlignment.Right)
            lsvCajaOnline.Columns.Add("Sálida ME", 85, HorizontalAlignment.Right)
            lsvCajaOnline.Columns.Add("SALDO MN", 85, HorizontalAlignment.Right)
            lsvCajaOnline.Columns.Add("SALDO ME", 85, HorizontalAlignment.Right)

            For Each i As documentoCaja In documentoCajaSA.ObtenerCajaOnlinePorRango(Gempresas.IdEmpresaRuc, intIdEstablecimiento, strEntidadFinacieras, desde, hasta)
                Dim n As New ListViewItem(i.fechaCobro)
                n.UseItemStyleForSubItems = False
                n.SubItems.Add(i.tipoMovimiento)
                n.SubItems.Add(i.TipoDocumentoPago)
                n.SubItems.Add(i.NumeroDocumento)
                n.SubItems.Add(i.glosa)
                Select Case i.tipoMovimiento
                    Case CAJA_ESTADOS.CAJA_ENTRADA_COBRO, CAJA_ESTADOS.CAJA_ENTRADA_PAGO, _
                         CAJA_ESTADOS.CAJA_APORTE, CAJA_ESTADOS.CAJA_VENTAS_ABARROTE

                        SaldoSoles += i.montoSoles
                        SaldoUSD += i.montoUsd

                        With n.SubItems.Add(i.montoSoles) 'entrada
                            .ForeColor = Color.Black
                            .BackColor = Color.LightYellow
                        End With
                        With n.SubItems.Add(i.montoUsd) 'entrada
                            .ForeColor = Color.Black
                            .BackColor = Color.LightYellow
                        End With

                        With n.SubItems.Add("0.00") 'Salida
                            .BackColor = Color.LightPink
                        End With
                        With n.SubItems.Add("0.00") 'Salida
                            .BackColor = Color.LightPink
                        End With
                        n.SubItems.Add(SaldoSoles)
                        n.SubItems.Add(SaldoUSD)


                    Case CAJA_ESTADOS.CAJA_SALIDA_PAGO, CAJA_ESTADOS.CAJA_SALIDA_COBRO

                        SaldoSoles -= i.montoSoles
                        SaldoUSD -= i.montoUsd


                        With n.SubItems.Add("0.00") 'Entrada
                            .ForeColor = Color.Black
                            .BackColor = Color.Yellow
                        End With
                        With n.SubItems.Add("0.00") 'Entrada
                            .ForeColor = Color.Black
                            .BackColor = Color.Yellow
                        End With
                        With n.SubItems.Add(i.montoSoles) 'Salida
                            .BackColor = Color.LightPink
                        End With
                        With n.SubItems.Add(i.montoUsd) 'Salida
                            .BackColor = Color.LightPink
                        End With
                        n.SubItems.Add(SaldoSoles)
                        n.SubItems.Add(SaldoUSD)
                        'Case "CB", "CE", "AP", "VT"
                        'Case "PG", "CS"
                End Select
                lsvCajaOnline.Items.Add(n)
            Next
            'ObtenerCajaAportes(strIdEMpresa, intIdEstablecimiento, String.Concat(strMes, "/", strAnio), strEntidadFinacieras)
            'ObtenerCajaVentaAbarrotes(strIdEMpresa, intIdEstablecimiento, "DC", String.Concat(strMes, "/", strAnio), strEntidadFinacieras)
        Catch ex As Exception
            MsgBox("Error al obtener datos." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema!")
        End Try
    End Sub

    Public Sub ObtenerCajaOnlinePorDia(intIdEstablecimiento As Integer, strEntidadFinacieras As String)
        Dim documentoCajaSA As New DocumentoCajaSA

        Try
            SaldoSoles = 0
            SaldoUSD = 0
            SaldoSolesNN = 0
            SaldoUSDNN = 0
            SaldoSolesNN1 = 0
            SaldoUSDNN1 = 0

            lsvCajaOnline.Columns.Clear()
            lsvCajaOnline.Items.Clear()
            lsvCajaOnline.Columns.Add("Fecha", 85)
            lsvCajaOnline.Columns.Add("Movimiento", 60)
            lsvCajaOnline.Columns.Add("Comprobante", 50)
            lsvCajaOnline.Columns.Add("Número comp.", 150)
            lsvCajaOnline.Columns.Add("Glosa", 180)
            lsvCajaOnline.Columns.Add("Entrada MN", 85, HorizontalAlignment.Right)
            lsvCajaOnline.Columns.Add("Entrada ME", 85, HorizontalAlignment.Right)
            lsvCajaOnline.Columns.Add("Sálida MN", 85, HorizontalAlignment.Right)
            lsvCajaOnline.Columns.Add("Sálida ME", 85, HorizontalAlignment.Right)
            lsvCajaOnline.Columns.Add("SALDO MN", 85, HorizontalAlignment.Right)
            lsvCajaOnline.Columns.Add("SALDO ME", 85, HorizontalAlignment.Right)

            For Each i As documentoCaja In documentoCajaSA.ObtenerCajaOnlinePorDia(Gempresas.IdEmpresaRuc, intIdEstablecimiento, strEntidadFinacieras)
                Dim n As New ListViewItem(i.fechaCobro)
                n.UseItemStyleForSubItems = False
                n.SubItems.Add(i.tipoMovimiento)
                n.SubItems.Add(i.TipoDocumentoPago)
                n.SubItems.Add(i.NumeroDocumento)
                n.SubItems.Add(i.glosa)
                Select Case i.tipoMovimiento
                    Case CAJA_ESTADOS.CAJA_ENTRADA_COBRO, CAJA_ESTADOS.CAJA_ENTRADA_PAGO, _
                         CAJA_ESTADOS.CAJA_APORTE, CAJA_ESTADOS.CAJA_VENTAS_ABARROTE

                        SaldoSoles += i.montoSoles
                        SaldoUSD += i.montoUsd

                        With n.SubItems.Add(i.montoSoles) 'entrada
                            .ForeColor = Color.Black
                            .BackColor = Color.LightYellow
                        End With
                        With n.SubItems.Add(i.montoUsd) 'entrada
                            .ForeColor = Color.Black
                            .BackColor = Color.LightYellow
                        End With

                        With n.SubItems.Add("0.00") 'Salida
                            .BackColor = Color.LightPink
                        End With
                        With n.SubItems.Add("0.00") 'Salida
                            .BackColor = Color.LightPink
                        End With
                        n.SubItems.Add(SaldoSoles)
                        n.SubItems.Add(SaldoUSD)


                    Case CAJA_ESTADOS.CAJA_SALIDA_PAGO, CAJA_ESTADOS.CAJA_SALIDA_COBRO

                        SaldoSoles -= i.montoSoles
                        SaldoUSD -= i.montoUsd


                        With n.SubItems.Add("0.00") 'Entrada
                            .ForeColor = Color.Black
                            .BackColor = Color.Yellow
                        End With
                        With n.SubItems.Add("0.00") 'Entrada
                            .ForeColor = Color.Black
                            .BackColor = Color.Yellow
                        End With
                        With n.SubItems.Add(i.montoSoles) 'Salida
                            .BackColor = Color.LightPink
                        End With
                        With n.SubItems.Add(i.montoUsd) 'Salida
                            .BackColor = Color.LightPink
                        End With
                        n.SubItems.Add(SaldoSoles)
                        n.SubItems.Add(SaldoUSD)
                        'Case "CB", "CE", "AP", "VT"
                        'Case "PG", "CS"
                End Select
                lsvCajaOnline.Items.Add(n)
            Next
            'ObtenerCajaAportes(strIdEMpresa, intIdEstablecimiento, String.Concat(strMes, "/", strAnio), strEntidadFinacieras)
            'ObtenerCajaVentaAbarrotes(strIdEMpresa, intIdEstablecimiento, "DC", String.Concat(strMes, "/", strAnio), strEntidadFinacieras)
        Catch ex As Exception
            MsgBox("Error al obtener datos." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema!")
        End Try
    End Sub

    Public Sub ObtenerEstablecimientos()

        Dim establecimientoSA As New establecimientoSA
        Dim establec As New List(Of centrocosto)
        Try

            establec = establecimientoSA.ObtenerListaEstablecimientos(Gempresas.IdEmpresaRuc)

            cboEstablecimiento.DisplayMember = "nombre"
            cboEstablecimiento.ValueMember = "idCentroCosto"
            cboEstablecimiento.DataSource = establec
        Catch ex As Exception
            MsgBox("Error al cargar datos" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub ObtenerEstadosFinancieros(ByVal strTipo As String, ByVal strMoneda As String)
        Dim EFSA As New EstadosFinancierosSA
        Try
            lsvAlmacen.Columns.Clear()
            lsvAlmacen.Items.Clear()
            lsvAlmacen.Columns.Add("ID", 0) '0
            lsvAlmacen.Columns.Add("cuenta", 0, HorizontalAlignment.Center) '1
            lsvAlmacen.Columns.Add("Moneda", 0, HorizontalAlignment.Center) '2
            lsvAlmacen.Columns.Add("E.F.", 0, HorizontalAlignment.Center) '3
            lsvAlmacen.Columns.Add("Entidad Financiera", 200) '4
            lsvAlmacen.Columns.Add("Nro. Cta. Corriente", 70) '5
            ' lsvAlmacen.FocusedItem.EnsureVisible()
            For Each i As estadosFinancieros In EFSA.ObtenerEstadosFinancierosPorMoneda(cboEstablecimiento.SelectedValue, strTipo, strMoneda)
                Dim n As New ListViewItem(i.idestado)
                n.SubItems.Add(i.cuenta)
                n.SubItems.Add(i.codigo)
                n.SubItems.Add(i.tipo)
                n.SubItems.Add(i.descripcion)
                n.SubItems.Add(i.nroCtaCorriente)
                lsvAlmacen.Items.Add(n)
            Next
        Catch ex As Exception
            MsgBox("No se pudo cargar la información para la lista de EF." & vbCrLf & ex.Message)
        End Try
    End Sub

    'Private Sub ObtenerCajaVentaAbarrotes(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strEstado As String, ByVal strPeriodo As String, ByVal strEntidadFinaciera As String)
    '    Dim objService = HeliosSEProxy.CrearProxyHELIOS()
    '    Dim objLista() As HeliosService.DocumentoVentaAbarrotesBO
    '    'Dim SaldoSoles As Decimal = 0
    '    'Dim SaldoUSD As Decimal = 0
    '    Try
    '        objLista = objService.GetObtenerPedidosPD(strIdEmpresa, intIdEstablecimiento, strEstado, strPeriodo, strEntidadFinaciera)
    '        For Each i As HeliosService.DocumentoVentaAbarrotesBO In objLista
    '            Dim n As New ListViewItem(i.FechaDoc)
    '            n.SubItems.Add("Vta. Abarrotes")
    '            n.SubItems.Add(i.TipoDocumento)
    '            n.SubItems.Add(String.Concat(i.Serie, "-", i.NumeroDoc))
    '            n.SubItems.Add(i.Glosa)
    '            '  Select Case i.TipoAporte
    '            '      Case "EFEC"
    '            SaldoSoles += i.ImporteNacional
    '            SaldoUSD += i.ImporteExtranjero
    '            n.SubItems.Add(i.ImporteNacional) 'entrada
    '            n.SubItems.Add(i.ImporteExtranjero) 'entrada
    '            n.SubItems.Add("0.00") 'Salida
    '            n.SubItems.Add("0.00") 'Salida
    '            n.SubItems.Add(SaldoSoles)
    '            n.SubItems.Add(SaldoUSD)
    '            lsvCajaOnline.Items.Add(n)
    '            '                End Select

    '        Next
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub ObtenerCajaAportes(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strPeriodo As String, ByVal strEntidadFinacieras As String)
    '    Dim objService = HeliosSEProxy.CrearProxyHELIOS()
    '    Dim objLista() As HeliosService.DocumentoAportesBO
    '    'Dim SaldoSoles As Decimal = 0
    '    'Dim SaldoUSD As Decimal = 0
    '    Try
    '        objLista = objService.GetObtenerAporteEfectivo(strIdEmpresa, intIdEstablecimiento, strPeriodo, strEntidadFinacieras)
    '        For Each i As HeliosService.DocumentoAportesBO In objLista
    '            Dim n As New ListViewItem(i.FechaDoc)
    '            n.SubItems.Add(i.TipoAporte)
    '            n.SubItems.Add(i.TipoComprobante)
    '            n.SubItems.Add(i.NumeroDoc)
    '            n.SubItems.Add(i.Glosa)
    '            Select Case i.TipoAporte
    '                Case "EFEC"
    '                    SaldoSoles += i.ImporteNacional
    '                    SaldoUSD += i.ImporteExtranjero
    '                    n.SubItems.Add(i.ImporteNacional) 'entrada
    '                    n.SubItems.Add(i.ImporteExtranjero) 'entrada
    '                    n.SubItems.Add("0.00") 'Salida
    '                    n.SubItems.Add("0.00") 'Salida
    '                    n.SubItems.Add(SaldoSoles)
    '                    n.SubItems.Add(SaldoUSD)
    '                    lsvCajaOnline.Items.Add(n)
    '            End Select

    '        Next
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Structure CAJA_ESTADOS
        Const CAJA_ENTRADA_COBRO = "CB"
        Const CAJA_ENTRADA_PAGO = "CE"
        Const CAJA_SALIDA_COBRO = "PG"
        Const CAJA_SALIDA_PAGO = "CS"
        Const CAJA_APORTE = "AP"
        Const CAJA_VENTAS_ABARROTE = "DC"


    End Structure


    Public Sub ObtenerCajaOnline(intIdEstablecimiento As Integer, strMes As String, strAnio As String, strEntidadFinacieras As String)
        Dim documentoCajaSA As New DocumentoCajaSA

        Try
            SaldoSoles = 0
            SaldoUSD = 0
            SaldoSolesNN = 0
            SaldoUSDNN = 0
            SaldoSolesNN1 = 0
            SaldoUSDNN1 = 0

            lsvCajaOnline.Columns.Clear()
            lsvCajaOnline.Items.Clear()
            lsvCajaOnline.Columns.Add("Fecha", 85)
            lsvCajaOnline.Columns.Add("Movimiento", 60)
            lsvCajaOnline.Columns.Add("Comprobante", 50)
            lsvCajaOnline.Columns.Add("Número comp.", 150)
            lsvCajaOnline.Columns.Add("Glosa", 180)
            lsvCajaOnline.Columns.Add("Entrada MN", 85, HorizontalAlignment.Right)
            lsvCajaOnline.Columns.Add("Entrada ME", 85, HorizontalAlignment.Right)
            lsvCajaOnline.Columns.Add("Sálida MN", 85, HorizontalAlignment.Right)
            lsvCajaOnline.Columns.Add("Sálida ME", 85, HorizontalAlignment.Right)
            lsvCajaOnline.Columns.Add("SALDO MN", 85, HorizontalAlignment.Right)
            lsvCajaOnline.Columns.Add("SALDO ME", 85, HorizontalAlignment.Right)

            For Each i As documentoCaja In documentoCajaSA.ObtenerCajaOnline(Gempresas.IdEmpresaRuc, intIdEstablecimiento, strMes, strAnio, strEntidadFinacieras)
                Dim n As New ListViewItem(i.fechaCobro)
                n.UseItemStyleForSubItems = False
                n.SubItems.Add(i.tipoMovimiento)
                n.SubItems.Add(i.TipoDocumentoPago)
                n.SubItems.Add(i.NumeroDocumento)
                n.SubItems.Add(i.glosa)
                Select Case i.tipoMovimiento
                    Case CAJA_ESTADOS.CAJA_ENTRADA_COBRO, CAJA_ESTADOS.CAJA_ENTRADA_PAGO, _
                         CAJA_ESTADOS.CAJA_APORTE, CAJA_ESTADOS.CAJA_VENTAS_ABARROTE

                        SaldoSoles += i.montoSoles
                        SaldoUSD += i.montoUsd

                        With n.SubItems.Add(i.montoSoles) 'entrada
                            .ForeColor = Color.Black
                            .BackColor = Color.LightYellow
                        End With
                        With n.SubItems.Add(i.montoUsd) 'entrada
                            .ForeColor = Color.Black
                            .BackColor = Color.LightYellow
                        End With

                        With n.SubItems.Add("0.00") 'Salida
                            .BackColor = Color.LightPink
                        End With
                        With n.SubItems.Add("0.00") 'Salida
                            .BackColor = Color.LightPink
                        End With
                        n.SubItems.Add(SaldoSoles)
                        n.SubItems.Add(SaldoUSD)


                    Case CAJA_ESTADOS.CAJA_SALIDA_PAGO, CAJA_ESTADOS.CAJA_SALIDA_COBRO

                        SaldoSoles -= i.montoSoles
                        SaldoUSD -= i.montoUsd


                        With n.SubItems.Add("0.00") 'Entrada
                            .ForeColor = Color.Black
                            .BackColor = Color.Yellow
                        End With
                        With n.SubItems.Add("0.00") 'Entrada
                            .ForeColor = Color.Black
                            .BackColor = Color.Yellow
                        End With
                        With n.SubItems.Add(i.montoSoles) 'Salida
                            .BackColor = Color.LightPink
                        End With
                        With n.SubItems.Add(i.montoUsd) 'Salida
                            .BackColor = Color.LightPink
                        End With
                        n.SubItems.Add(SaldoSoles)
                        n.SubItems.Add(SaldoUSD)
                        'Case "CB", "CE", "AP", "VT"
                        'Case "PG", "CS"
                End Select
                lsvCajaOnline.Items.Add(n)
            Next
            'ObtenerCajaAportes(strIdEMpresa, intIdEstablecimiento, String.Concat(strMes, "/", strAnio), strEntidadFinacieras)
            'ObtenerCajaVentaAbarrotes(strIdEMpresa, intIdEstablecimiento, "DC", String.Concat(strMes, "/", strAnio), strEntidadFinacieras)
        Catch ex As Exception
            MsgBox("Error al obtener datos." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema!")
        End Try
    End Sub
#End Region

    Private Sub frmCajaOnline_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmCajaOnline_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
       
    End Sub

    Private Sub cboMeses_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        'If cboMeses.SelectedIndex > -1 Then
        '    If lsvAlmacen.SelectedItems.Count > 0 Then
        '        ObtenerCajaOnline(frmMasterCajaBanco.lblIDEmpresa.Text, cboEstablecimiento.SelectedValue, cboMeses.SelectedValue, lblPeriodo.Text, lsvAlmacen.SelectedItems(0).SubItems(0).Text)
        '    End If
        'End If
    End Sub

    Private Sub cboEstablecimiento_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboEstablecimiento.SelectedIndexChanged
        If cboEstablecimiento.SelectedIndex > -1 Then
            If rbME.Checked = True Then
                rbME_CheckedChanged(sender, e)
            Else
                rbMN_CheckedChanged(sender, e)
            End If
        End If
    End Sub

    Private Sub rbMN_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbMN.CheckedChanged
        If cboEstablecimiento.SelectedIndex > -1 Then
            If rbMN.Checked = True Then
                If rbEntidad.Checked = True Then
                    lsvCajaOnline.Items.Clear()
                    ObtenerEstadosFinancieros("BC", "1")
                End If
                If rbEfec.Checked = True Then
                    lsvCajaOnline.Items.Clear()
                    ObtenerEstadosFinancieros("EF", "1")
                End If
            End If
        End If
    End Sub

    Private Sub rbME_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbME.CheckedChanged
        If cboEstablecimiento.SelectedIndex > -1 Then
            If rbME.Checked = True Then
                If rbEntidad.Checked = True Then
                    lsvCajaOnline.Items.Clear()
                    ObtenerEstadosFinancieros("BC", "2")
                End If
                If rbEfec.Checked = True Then
                    lsvCajaOnline.Items.Clear()
                    ObtenerEstadosFinancieros("EF", "2")
                End If
            End If
        End If
    End Sub

    Private Sub rbEfec_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbEfec.CheckedChanged
        If cboEstablecimiento.SelectedIndex > -1 Then
            If rbME.Checked = True Then
                lsvCajaOnline.Items.Clear()
                rbME_CheckedChanged(sender, e)
            Else
                lsvCajaOnline.Items.Clear()
                rbMN_CheckedChanged(sender, e)
            End If
        End If
    End Sub

    Private Sub rbEntidad_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbEntidad.CheckedChanged
        If cboEstablecimiento.SelectedIndex > -1 Then
            If rbME.Checked = True Then
                lsvCajaOnline.Items.Clear()
                rbME_CheckedChanged(sender, e)
            Else
                lsvCajaOnline.Items.Clear()
                rbMN_CheckedChanged(sender, e)
            End If
        End If
    End Sub

    Private Sub lsvAlmacen_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lsvAlmacen.SelectedIndexChanged
        Dim strFecha As DateTime = CDate("01" & "/" & lblPeriodo.Text)
        If lsvAlmacen.SelectedItems.Count > 0 Then
            'ObtenerCajaOnline(cboEstablecimiento.SelectedValue, strFecha.Month, strFecha.Year, lsvAlmacen.SelectedItems(0).SubItems(0).Text)
            If CheckBox1.Checked = True Then
                ObtenerCajaOnlinePorDia(cboEstablecimiento.SelectedValue, lsvAlmacen.SelectedItems(0).SubItems(0).Text)
                CheckBox1.Checked = True
                CheckBox2.Checked = False
                CheckBox3.Checked = False
            ElseIf CheckBox2.Checked = True Then
                ObtenerCajaOnline(cboEstablecimiento.SelectedValue, strFecha.Month, strFecha.Year, lsvAlmacen.SelectedItems(0).SubItems(0).Text)
                CheckBox1.Checked = False
                CheckBox2.Checked = True
                CheckBox3.Checked = False
            ElseIf CheckBox3.Checked = True Then
                ObtenerCajaOnlinePorRango(cboEstablecimiento.SelectedValue, lsvAlmacen.SelectedItems(0).SubItems(0).Text, CDate(DateTimePicker1.Value), CDate(DateTimePicker2.Value))
                CheckBox1.Checked = False
                CheckBox2.Checked = False
                CheckBox3.Checked = True
            End If
        Else
            lsvCajaOnline.Items.Clear()
        End If

    End Sub

    Private Sub lsvCajaOnline_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lsvCajaOnline.SelectedIndexChanged

    End Sub

    Private Sub lblPeriodo_Click(sender As System.Object, e As System.EventArgs)
        Me.Cursor = Cursors.WaitCursor

        Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
        datos.Clear()
        'With frmModalPeriodos
        '    .ObtenerAniosPorEmpresa(CEmpresa)
        '    .StartPosition = FormStartPosition.WindowsDefaultLocation
        '    .ShowDialog()
        '    If datos.Count > 0 Then
        '        lblPeriodo.Text = datos(0).NombreCampo
        '        lblPeriodo.Text = datos(0).NombreCampo
        '        ' cAnioPeriodo = datos(0).NombreCampo
        '        lsvAlmacen_SelectedIndexChanged(sender, e)
        '    Else
        '        lsvAlmacen_SelectedIndexChanged(sender, e)
        '        '   MsgBox("Debe ingresar un comprobante.", MsgBoxStyle.Information, "Atención!")
        '        '   btnAgregarProv_Click(sender, e)
        '    End If
        'End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboPeriodo_Click(sender As System.Object, e As System.EventArgs) Handles cboPeriodo.Click

    End Sub

    Private Sub cboPeriodo_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboPeriodo.SelectedIndexChanged
        Select Case cboPeriodo.Text
            Case "ENERO"
                lblPeriodo.Text = "01" & "/2014"
            Case "FEBRERO"
                lblPeriodo.Text = "02" & "/2014"
            Case "MARZO"
                lblPeriodo.Text = "03" & "/2014"
            Case "ABRIL"
                lblPeriodo.Text = "04" & "/2014"
            Case "MAYO"
                lblPeriodo.Text = "05" & "/2014"
            Case "JUNIO"
                lblPeriodo.Text = "06" & "/2014"
            Case "JULIO"
                lblPeriodo.Text = "07" & "/2014"
            Case "AGOSTO"
                lblPeriodo.Text = "08" & "/2014"
            Case "SETIEMBRE"
                lblPeriodo.Text = "09" & "/2014"
            Case "OCTUBRE"
                lblPeriodo.Text = "10" & "/2014"
            Case "NOVIEMBRE"
                lblPeriodo.Text = "11" & "/2014"
            Case "DICIEMBRE"
                lblPeriodo.Text = "12" & "/2014"
        End Select
        '   ListaCompras(lblPerido.Text)
        lsvCajaOnline.Items.Clear()
        lsvAlmacen_SelectedIndexChanged(sender, e)
        ContextMenuStrip1.Hide()


    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        ''frmPMO.Panel3.Width = 249
        Dispose()
    End Sub

    Private Sub lblPeriodo_Click_1(sender As System.Object, e As System.EventArgs) Handles lblPeriodo.Click

    End Sub

    Private Sub lblPeriodo_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lblPeriodo.MouseUp
        Dim p As Point = e.Location
        p.Offset(lblPeriodo.Bounds.Location)
        ContextMenuStrip1.Show(ToolStrip1.PointToScreen(p))
        cboPeriodo.DroppedDown = True
    End Sub

    Private Sub GroupBox2_Enter(sender As System.Object, e As System.EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        'Dim strFecha As DateTime = CDate("01" & "/" & lblPeriodo.Text)
        'With frmReporteCajaOnline
        '    .ConsultaReporte(cboEstablecimiento.SelectedValue, strFecha.Month, strFecha.Year, lsvAlmacen.SelectedItems(0).SubItems(0).Text)
        '    .StartPosition = FormStartPosition.CenterParent
        '    .Show()
        'End With
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If lsvAlmacen.SelectedItems.Count > 0 Then
            If CheckBox1.Checked = True Then
                ObtenerCajaOnlinePorDia(cboEstablecimiento.SelectedValue, lsvAlmacen.SelectedItems(0).SubItems(0).Text)


                CheckBox1.Checked = True
                CheckBox2.Checked = False
                CheckBox3.Checked = False

                DateTimePicker1.Visible = False
                DateTimePicker2.Visible = False
                lbldesde.Visible = False
                lblhasta.Visible = False

            End If
        Else
            MessageBox.Show("seleccione un almacen")
            lsvCajaOnline.Items.Clear()
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If lsvAlmacen.SelectedItems.Count > 0 Then
            If CheckBox2.Checked = True Then
                Dim strFecha As DateTime = CDate("01" & "/" & lblPeriodo.Text)
                ObtenerCajaOnline(cboEstablecimiento.SelectedValue, strFecha.Month, strFecha.Year, lsvAlmacen.SelectedItems(0).SubItems(0).Text)


                CheckBox1.Checked = False
                CheckBox2.Checked = True
                CheckBox3.Checked = False

                DateTimePicker1.Visible = False
                DateTimePicker2.Visible = False
                lbldesde.Visible = False
                lblhasta.Visible = False
            End If
        Else
            MessageBox.Show("seleccione un almacen")
            lsvCajaOnline.Items.Clear()
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox3.CheckedChanged
        If lsvAlmacen.SelectedItems.Count > 0 Then
            If CheckBox3.Checked = True Then
                ObtenerCajaOnlinePorRango(cboEstablecimiento.SelectedValue, lsvAlmacen.SelectedItems(0).SubItems(0).Text, CDate(DateTimePicker1.Value), CDate(DateTimePicker2.Value))

                CheckBox1.Checked = False
                CheckBox2.Checked = False
                CheckBox3.Checked = True

                DateTimePicker1.Visible = True
                DateTimePicker2.Visible = True
                lbldesde.Visible = True
                lblhasta.Visible = True

            End If
        Else
            lsvCajaOnline.Items.Clear()
            MessageBox.Show("seleccione un almacen")
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        If lsvAlmacen.SelectedItems.Count > 0 Then
            If CheckBox3.Checked = True Then
                ObtenerCajaOnlinePorRango(cboEstablecimiento.SelectedValue, lsvAlmacen.SelectedItems(0).SubItems(0).Text, CDate(DateTimePicker1.Value), CDate(DateTimePicker2.Value))
            End If
        Else
            lsvCajaOnline.Items.Clear()
        End If
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DateTimePicker2.ValueChanged
        If lsvAlmacen.SelectedItems.Count > 0 Then
            If CheckBox3.Checked = True Then
                ObtenerCajaOnlinePorRango(cboEstablecimiento.SelectedValue, lsvAlmacen.SelectedItems(0).SubItems(0).Text, CDate(DateTimePicker1.Value), CDate(DateTimePicker2.Value))
            End If
        Else
            lsvCajaOnline.Items.Clear()
        End If
    End Sub
End Class