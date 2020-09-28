Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Public Class frmInicioEmpresaUnica
#Region "Attributes"
    Public Property SelEmpresa As empresa
    Public Property SelEstablecimiento As List(Of centrocosto)
    Public Property EmpresaSA As New empresaSA
    Public Property EstableSA As New establecimientoSA
    Private Property tipoCmabioSA As New tipoCambioSA
#End Region

#Region "Constructors"
    Public Sub New(empresa As empresa)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        SelEstablecimiento = New List(Of centrocosto)
        Anios(empresa.idEmpresa)
        SelEmpresa = EmpresaSA.UbicarEmpresaRuc(empresa.idEmpresa)
        SelEstablecimiento = EstableSA.ObtenerListaEstablecimientos(SelEmpresa.idEmpresa)
        GetCMBEstablecimientos(SelEstablecimiento)
        CaptionLabels(1).Text = SelEmpresa.nombreCorto
        GetConfiguracionInicio(empresa.idEmpresa)
    End Sub

    Private Sub Anios(idEmpresa As String)
        Dim empresaPeriodoSA As New empresaPeriodoSA
        cboAnio.DataSource = empresaPeriodoSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
        cboAnio.ValueMember = "periodo"
        cboAnio.DisplayMember = "periodo"
        cboAnio.SelectedValue = Date.Now.Year.ToString
    End Sub

    Private Sub GetConfiguracionInicio(idEmpresa As String)
        Dim configuracion As New configuracionInicio
        Dim configuracionSA As New ConfiguracionInicioSA

        configuracion = configuracionSA.ObtenerConfigXempresa(idEmpresa, GEstableciento.IdEstablecimiento)
        If configuracion IsNot Nothing Then
            cboEstablecimiento.SelectedValue = configuracion.idCentroCosto
            'txtFechaInicio.Value = configuracion.dia
            'txtDia.Value = DateTime.Now.Day
            ''cboMes.SelectedValue = String.Format("{0:00}", Integer.Parse(configuracion.mes))
            'cboMes.SelectedValue = String.Format("{0:00}", Integer.Parse(DateTime.Now.Month))
            'cboAnio.Text = configuracion.anio
            'AnioGeneral = configuracion.anio

            txtFechaTC.Value = Date.Now
            Dim diaLaboral = txtFechaTC.Value
            Dim tipoCambioDia = tipoCmabioSA.GeTipoCambioXfecha(Gempresas.IdEmpresaRuc, diaLaboral, GEstableciento.IdEstablecimiento)
            If tipoCambioDia IsNot Nothing Then
                nudTipoCambioCompra.DecimalValue = tipoCambioDia.compra.GetValueOrDefault
                nudTipoCambioVenta.DecimalValue = tipoCambioDia.venta.GetValueOrDefault
            Else
                nudTipoCambioCompra.DecimalValue = 0
                nudTipoCambioVenta.DecimalValue = 0
            End If


        End If
    End Sub
#End Region

#Region "Methods"
    Private Sub GetCMBEstablecimientos(selEstablecimiento As List(Of centrocosto))
        cboEstablecimiento.DataSource = selEstablecimiento
        cboEstablecimiento.ValueMember = "idCentroCosto"
        cboEstablecimiento.DisplayMember = "nombre"
    End Sub

    Private Sub Grabar()
        Dim cierreSA As New empresaCierreMensualSA
        Dim config As New configuracionInicio
        Dim existe As New configuracionInicio
        Dim configsa As New ConfiguracionInicioSA
        Dim tipcambsa As New tipoCambio
        Dim tipcambsaSA As New tipoCambioSA
        Dim existe2 As New tipoCambio


        'validar cierre
        Dim fechaAnt = New Date(txtFechaTC.Value.Year, txtFechaTC.Value.Month, 1)
        fechaAnt = fechaAnt.AddMonths(-1)
        Dim periodoAnteriorEstaCerrado As Boolean = cierreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento, .anio = fechaAnt.Year, .mes = fechaAnt.Month})


        'ultima configuracion de inicio de la empresa
        Dim inicio = configsa.ObtenerConfigXempresa(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)

        Dim diaLaboral = txtFechaTC.Value.Date 'New Date(cboAnio.Text, CInt(cboMes.SelectedValue), txtDia.Value)

        tipcambsa = tipcambsaSA.ObtenerTipoCambioXfecha(Gempresas.IdEmpresaRuc, diaLaboral, GEstableciento.IdEstablecimiento)
        If tipcambsa Is Nothing Then
            MessageBox.Show("Debe ingresar un tipo de cambio para el día laboral " & vbCrLf &
                            diaLaboral.ToShortDateString, "Validar tipo de cambio", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else

        End If

        If inicio Is Nothing Then
            With config
                .idEmpresa = SelEmpresa.idEmpresa
                .idCentroCosto = cboEstablecimiento.SelectedValue
                .montoMaximo = 699.0
                .anio = cboAnio.Text
                .mes = String.Format("{0:00}", txtFechaTC.Value.Month)
                .dia = diaLaboral
                .periodo = String.Format("{0:00}", txtFechaTC.Value.Month) & "/" & txtFechaTC.Value.Year
                .tipocambio = tipcambsa.venta
                .iva = 18.0
                .tipoIva = "IGV."
                .tipocambio = nudTipoCambioVenta.DecimalValue
                .tipoCambioTransacCompra = nudTipoCambioCompra.DecimalValue
                .tipoCambioTransacVenta = nudTipoCambioVenta.DecimalValue
            End With
            configsa.InsertConfigInicio(config)
            inicio = config
        Else


            With config
                .idEmpresa = SelEmpresa.idEmpresa
                .idCentroCosto = cboEstablecimiento.SelectedValue
                .montoMaximo = inicio.montoMaximo
                .anio = cboAnio.Text
                .mes = String.Format("{0:00}", txtFechaTC.Value.Month)
                .dia = diaLaboral
                .periodo = String.Format("{0:00}", txtFechaTC.Value.Month) & "/" & txtFechaTC.Value.Year
                .tipocambio = tipcambsa.venta
                .iva = inicio.iva
                .tipoIva = "IGV."
                .tipocambio = nudTipoCambioVenta.DecimalValue
                .tipoCambioTransacCompra = nudTipoCambioCompra.DecimalValue
                .tipoCambioTransacVenta = nudTipoCambioVenta.DecimalValue
            End With
            configsa.EditarConfigInicio(config)
            inicio = config
        End If
        'Mapeando variables GLOBALES
        GetGlobalMapping(inicio)
        If periodoAnteriorEstaCerrado = False Then
            MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & txtFechaTC.Value.Year)
            Cursor = Cursors.Default
            Dim f As New frmselectCierre("No Cerrado")
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            If f.Tag = "No Cerrado" Then
                Exit Sub
            End If
            If IsNothing(f.Tag) Then
                Exit Sub
            End If
        End If
        Close()
    End Sub

    Private Sub GetGlobalMapping(inicio As configuracionInicio)

        Gempresas = New GEmpresa With
            {
            .IdEmpresaRuc = SelEmpresa.idEmpresa,
            .NomCorto = SelEmpresa.nombreCorto,
            .NomEmpresa = SelEmpresa.razonSocial,
            .IDCliente = SelEmpresa.idclientespk,
            .IDProducto = "00",
            .Ruc = SelEmpresa.idEmpresa,
            .InicioOpeaciones = SelEmpresa.inicioOperacion
        }

        GEstableciento = New GEstablecimiento
        GEstableciento.IdEstablecimiento = cboEstablecimiento.SelectedValue
        GEstableciento.NombreEstablecimiento = cboEstablecimiento.Text
        AnioGeneral = inicio.anio
        MesGeneral = String.Format("{0:00}", CInt(inicio.mes))
        DiaLaboral = inicio.dia
        PeriodoGeneral = inicio.periodo
        TmpTipoCambio = nudTipoCambioVenta.DecimalValue
        TmpTipoCambioTransaccionCompra = nudTipoCambioCompra.DecimalValue
        TmpTipoCambioTransaccionVenta = nudTipoCambioVenta.DecimalValue
        TmpIGV = inicio.iva
        MontoMaximoCliente = inicio.montoMaximo
    End Sub

    Sub UbicarTC()
        Dim tipocambioSA As New tipoCambioSA
        Dim tipocambio As New tipoCambio

        'Dim b = MonthPeriodo.SelectedDates(0).Date
        Dim FechaActual = txtFechaTC.Value.Date ' New Date(Integer.Parse(cboAnio.Text), CInt(cboMes.SelectedValue), txtDia.Value)
        tipocambio = tipocambioSA.ObtenerTipoCambioXfecha(Gempresas.IdEmpresaRuc, FechaActual, GEstableciento.IdEstablecimiento)

        If Not IsNothing(tipocambio) Then
                ' txtFechaInicio.Value = tipocambio.fechaIgv
                nudTipoCambioCompra.DecimalValue = tipocambio.compra
                nudTipoCambioVenta.DecimalValue = tipocambio.venta
            Else
                '   txtFechaInicio.IsNullDate = True
                nudTipoCambioCompra.DecimalValue = 0
                nudTipoCambioVenta.DecimalValue = 0
            End If


    End Sub

    'Private Sub ObtenerTipoCambioMax()
    '    Dim tipoCambioSA As New tipoCambioSA
    '    Dim tipoCambio As New tipoCambio

    '    tipoCambio = tipoCambioSA.GetListaTipoCambioMaxFecha(Gempresas.IdEmpresaRuc)
    '    If (tipoCambio.compra.GetValueOrDefault > 0) Then
    '        With tipoCambio
    '            txtFechaInicio.Value = .fechaIgv
    '            'txtFechaIgv.Value = DateTime.Now
    '            nudTipoCambioCompra.DecimalValue = .compra
    '            nudTipoCambioVenta.DecimalValue = .venta
    '        End With
    '    Else
    '        txtFechaInicio.IsNullDate = True
    '        'txtFechaTC.Value = DateTime.Now
    '        nudTipoCambioCompra.DecimalValue = 0
    '        nudTipoCambioVenta.DecimalValue = 0
    '    End If
    'End Sub

#End Region

#Region "Events"
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        With frmTipoCambio
            .txtFechaIgv.Value = txtFechaTC.Value ' New DateTime(Val(cboAnio.Text), CInt(cboMes.SelectedValue), txtDia.Value)
            .txtFechaIgv.MaxValue = txtFechaTC.Value ' New DateTime(Val(cboAnio.Text), CInt(cboMes.SelectedValue), txtDia.Value)
            .StartPosition = FormStartPosition.CenterParent
            .nudTipoCambioCompra.Value = nudTipoCambioCompra.DecimalValue
            .nudTipoCambio.Value = nudTipoCambioVenta.DecimalValue
            .ShowDialog()
            UbicarTC()
        End With
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        Dim tipocambioSA As New tipoCambioSA

        Dim fechaLaboral = txtFechaTC.Value ' New Date(cboAnio.Text, CInt(cboMes.SelectedValue), txtDia.Value)
        If MessageBox.Show("Esta seguro de eliminar el t/c", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            tipocambioSA.DeleteTC(New tipoCambio With {.idEmpresa = Gempresas.IdEmpresaRuc, .fechaIgv = fechaLaboral.Date, .idRegulador = 100})
            MessageBox.Show("t/c eliminado correctamente", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
                nudTipoCambioCompra.DecimalValue = 0
                nudTipoCambioVenta.DecimalValue = 0
                UbicarTC()
            End If
            Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        UbicarTC() 'ObtenerTipoCambioMax()
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        Try
            If SelEmpresa.estado = "0" Then
                MessageBox.Show("Debe terminar la configuración de su empresa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            'Dim FechaActual = New Date(Integer.Parse(cboAnio.Text), txtFechaInicio.Value.Month, txtFechaInicio.Value.Day)

            'If txtFechaTC.Value.Date = FechaActual.Date Then

            'Else
            '    MessageBox.Show("Debe ingresar un t/c para la fecha de trabajo!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    Exit Sub
            'End If

            If nudTipoCambioCompra.DecimalValue > 0 Then
                If nudTipoCambioVenta.DecimalValue > 0 Then
                    If MessageBox.Show("Desea guardar la configuración con fecha" & vbCrLf & vbCrLf &
                                              Space(25) & txtFechaTC.Value.Date, "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                        Grabar()
                    Else
                        Exit Sub
                    End If
                Else
                    MessageBox.Show("Ingresar un tipo de cambio mayor a 0", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Ingresar un tipo de cambio mayor a 0", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtFechaTC_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaTC.ValueChanged
        If IsDate(txtFechaTC.Value) Then
            UbicarTC()
        End If
    End Sub

    Private Sub frmInicioEmpresaUnica_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PictureBox19_Click(sender As Object, e As EventArgs) Handles PictureBox19.Click
        Me.Cursor = Cursors.WaitCursor
        Dim empresaPeriodoSA As New empresaPeriodoSA
        Dim nuevoAnio = InputBox("Agregar nuevo año de trabajo", "Periodo empresa", "")

        If IsNumeric((nuevoAnio)) Then
            empresaPeriodoSA.InsertarPeriodo(New empresaPeriodo With
                                              {
                                                  .idEmpresa = SelEmpresa.idEmpresa,
                                                  .periodo = nuevoAnio,
                                                  .usuarioActualizacion = usuario.IDUsuario,
                                                  .fechaActualizacion = Date.Now
                                             })

            Anios(SelEmpresa.idEmpresa)
            cboAnio.SelectedValue = nuevoAnio
        Else
            MessageBox.Show("Formato incorrecto", "Validar año", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        'With frmModalCaja
        '    .strEstadoManipulacion = ENTITY_ACTIONS.INSERT
        '    .ObtenerMascaraMercaderia()
        '    .txtCuentaID.Text = "101"
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    CMBAlmacen(cboEstablecimiento.SelectedValue)
        'End With
        Me.Cursor = Cursors.Arrow
    End Sub

#End Region



End Class