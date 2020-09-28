Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping

Public Class frmPrestamo
    Inherits frmMaster
    Public Property txtCuenta As String
    Public Property fecha As DateTime
    Public Property ManipulacionEstado() As String
    Public Property idPrestamo() As Integer
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        'GridCFG(dgvPrestamos)
        'GetTableGrid()
        GridCFG(dgvConceptos)
        GetTableGridConcepto()
        GridCFG(dgvConceptos2)
        GetTableGridConcepto2()
        ' Add any initialization after the InitializeComponent() call.
        Listas()
        DateTimePickerAdv2.Value = DateTime.Now
        txtTipoCambio.Value = TmpTipoCambio

        configuracionModuloV2(Gempresas.IdEmpresaRuc, "PTO", Me.Text, GEstableciento.IdEstablecimiento)

        cboModo.SelectedIndex = 0
        cboDiaPago.SelectedIndex = 0
        cbodiaplazo.SelectedIndex = 0



        ListaTipoPrestamos()
        ConfiguracionInicio()


        If cboTipoPR.Text.Trim.Length > 0 Then
            txtNombrePrestamo.Text = cboTipoPR.Text
            TextBox1.Text = cboTipoPR.Text
            ListarConceptosPrestamos(cboTipoPR.SelectedValue)
        End If


    End Sub

    Sub Listas()
        'Dim tablaSA As New tablaDetalleSA
        'cboMoneda.DisplayMember = "descripcion"
        'cboMoneda.ValueMember = "codigoDetalle"
        'cboMoneda.DataSource = tablaSA.GetListaTablaDetalle(4, "1")
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("name")

        dt.Rows.Add(1, "NACIONAL")
        dt.Rows.Add(2, "EXTRANJERA")

        cboMoneda.ValueMember = "id"
        cboMoneda.DisplayMember = "name"
        cboMoneda.DataSource = dt
        cboMoneda.SelectedIndex = 0
    End Sub

    Dim lista As New List(Of servicio)

    Sub ListaTipoPrestamos()
        Dim tablaSA As New servicioSA
        lista = New List(Of servicio)


        cboTipoPR.DisplayMember = "descripcion"
        cboTipoPR.ValueMember = "idServicio"
        cboTipoPR.DataSource = tablaSA.ListaConceptosPrestamo("PR", "PO")



    End Sub

    Public Class Categoria

        Private _name As String
        Private _id As Integer
        Private _Utilidad As String
        Private _tipo As String

        Public Sub New(ByVal name As String, ByVal id As Integer, ByVal utilidad As String, ByVal tipo As String)
            _name = name
            _id = id
            _Utilidad = utilidad
            _tipo = tipo
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

        Public Property Utilidad() As String
            Get
                Return _Utilidad
            End Get
            Set(ByVal value As String)
                _Utilidad = value
            End Set
        End Property

        Public Property tipo() As String
            Get
                Return _tipo
            End Get
            Set(ByVal value As String)
                _tipo = value
            End Set
        End Property

    End Class



#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean



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

#Region "Métodos"

    Sub ConfiguracionInicio()

        'configurando docking manager
        DockingManager1.DockControlInAutoHideMode(GradientPanel2, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 400)
        DockingManager1.DockControlInAutoHideMode(GradientPanel4, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 400)
        Me.DockingClientPanel1.AutoScroll = True
        Me.DockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DockingManager1.SetDockLabel(GradientPanel2, "Cuentas")
        DockingManager1.SetDockLabel(GradientPanel4, "Conceptos")
        dockingManager1.CloseEnabled = False
    End Sub


    Public Sub ListarConceptosPrestamos(ByVal idservicio As Integer)

        Dim objDoc As New servicioSA
        Dim listaServicio As New List(Of servicio)

        Try

            dgvConceptos.Table.Records.DeleteAll()
            dgvConceptos2.Table.Records.DeleteAll()

            'For Each i In objDoc.ListaConceptosPrestamo(codigo)
            listaServicio = objDoc.ListadoServiciosHijosXIdTipo(New servicio With {.codigo = "PH", .idPadre = idservicio})

            'For Each i In objDoc.ListadoServiciosHijosXIdTipo(New servicio With {.codigo = "PH", .idPadre = idservicio})
            For Each i In listaServicio

                If i.descripcion = "INTERES" Then

                    txtPorcIneteres.Value = i.valor
                    Me.dgvConceptos.Table.AddNewRecord.SetCurrent()
                    Me.dgvConceptos.Table.AddNewRecord.BeginEdit()
                    Me.dgvConceptos.Table.CurrentRecord.SetValue("idServicio", i.idServicio)
                    Me.dgvConceptos.Table.CurrentRecord.SetValue("descripcion", i.descripcion)
                    Me.dgvConceptos.Table.CurrentRecord.SetValue("cuenta", i.cuenta)
                    Me.dgvConceptos.Table.CurrentRecord.SetValue("cuentaH", i.cuentaH)
                    Me.dgvConceptos.Table.CurrentRecord.SetValue("cuentaDev", i.cuentaDev)
                    Me.dgvConceptos.Table.CurrentRecord.SetValue("cuentaDevH", i.cuentaDevH)
                    Me.dgvConceptos.Table.CurrentRecord.SetValue("valor", i.valor)
                    'Me.dgvConceptos.Table.CurrentRecord.SetValue("check", True)
                    'Me.dgvConceptos.Table.CurrentRecord.SetValue("estado", "N")
                    'Me.dgvConceptos.Table.CurrentRecord.SetValue("tipo", "Porcentaje")


                    'solo concepto
                    Me.dgvConceptos2.Table.AddNewRecord.SetCurrent()
                    Me.dgvConceptos2.Table.AddNewRecord.BeginEdit()
                    Me.dgvConceptos2.Table.CurrentRecord.SetValue("idServicio", i.idServicio)
                    Me.dgvConceptos2.Table.CurrentRecord.SetValue("descripcion", i.descripcion)
                    Me.dgvConceptos2.Table.CurrentRecord.SetValue("cuenta", i.cuenta)
                    Me.dgvConceptos2.Table.CurrentRecord.SetValue("cuentaH", i.cuentaH)
                    Me.dgvConceptos2.Table.CurrentRecord.SetValue("cuentaDev", i.cuentaDev)
                    Me.dgvConceptos2.Table.CurrentRecord.SetValue("cuentaDevH", i.cuentaDevH)
                    Me.dgvConceptos2.Table.CurrentRecord.SetValue("valor", i.valor)
                    Me.dgvConceptos2.Table.CurrentRecord.SetValue("check", True)
                    Me.dgvConceptos2.Table.CurrentRecord.SetValue("estado", "N")
                    Me.dgvConceptos2.Table.CurrentRecord.SetValue("tipo", "Porcentaje")


                ElseIf i.descripcion = "SEGURO" Then

                    txtporcseg.Value = i.valor
                    Me.dgvConceptos.Table.AddNewRecord.SetCurrent()
                    Me.dgvConceptos.Table.AddNewRecord.BeginEdit()
                    Me.dgvConceptos.Table.CurrentRecord.SetValue("idServicio", i.idServicio)
                    Me.dgvConceptos.Table.CurrentRecord.SetValue("descripcion", i.descripcion)
                    Me.dgvConceptos.Table.CurrentRecord.SetValue("cuenta", i.cuenta)
                    Me.dgvConceptos.Table.CurrentRecord.SetValue("cuentaH", i.cuentaH)
                    Me.dgvConceptos.Table.CurrentRecord.SetValue("cuentaDev", i.cuentaDev)
                    Me.dgvConceptos.Table.CurrentRecord.SetValue("cuentaDevH", i.cuentaDevH)
                    Me.dgvConceptos.Table.CurrentRecord.SetValue("valor", i.valor)
                    'Me.dgvConceptos.Table.CurrentRecord.SetValue("check", True)
                    'Me.dgvConceptos.Table.CurrentRecord.SetValue("estado", "N")
                    'Me.dgvConceptos.Table.CurrentRecord.SetValue("tipo", "Porcentaje")

                    'solo conceptos
                    Me.dgvConceptos2.Table.AddNewRecord.SetCurrent()
                    Me.dgvConceptos2.Table.AddNewRecord.BeginEdit()
                    Me.dgvConceptos2.Table.CurrentRecord.SetValue("idServicio", i.idServicio)
                    Me.dgvConceptos2.Table.CurrentRecord.SetValue("descripcion", i.descripcion)
                    Me.dgvConceptos2.Table.CurrentRecord.SetValue("cuenta", i.cuenta)
                    Me.dgvConceptos2.Table.CurrentRecord.SetValue("cuentaH", i.cuentaH)
                    Me.dgvConceptos2.Table.CurrentRecord.SetValue("cuentaDev", i.cuentaDev)
                    Me.dgvConceptos2.Table.CurrentRecord.SetValue("cuentaDevH", i.cuentaDevH)
                    Me.dgvConceptos2.Table.CurrentRecord.SetValue("valor", i.valor)
                    Me.dgvConceptos2.Table.CurrentRecord.SetValue("check", True)
                    Me.dgvConceptos2.Table.CurrentRecord.SetValue("estado", "N")
                    Me.dgvConceptos2.Table.CurrentRecord.SetValue("tipo", "Porcentaje")


                ElseIf i.descripcion = "DESEMBOLSO" Then
                    txtDevengado.Tag = i.idServicio
                    txtDevengado.Text = i.cuenta
                    txtDevengadoH.Text = i.cuentaH


                Else
                    Me.dgvConceptos.Table.AddNewRecord.SetCurrent()
                    Me.dgvConceptos.Table.AddNewRecord.BeginEdit()
                    Me.dgvConceptos.Table.CurrentRecord.SetValue("idServicio", i.idServicio)
                    Me.dgvConceptos.Table.CurrentRecord.SetValue("descripcion", i.descripcion)
                    Me.dgvConceptos.Table.CurrentRecord.SetValue("cuenta", i.cuenta)
                    Me.dgvConceptos.Table.CurrentRecord.SetValue("cuentaH", i.cuentaH)
                    Me.dgvConceptos.Table.CurrentRecord.SetValue("cuentaDev", i.cuentaDev)
                    Me.dgvConceptos.Table.CurrentRecord.SetValue("cuentaDevH", i.cuentaDevH)
                    Me.dgvConceptos.Table.CurrentRecord.SetValue("valor", i.valor)
                    'Me.dgvConceptos.Table.CurrentRecord.SetValue("check", False)
                    'Me.dgvConceptos.Table.CurrentRecord.SetValue("estado", "N")
                    'Me.dgvConceptos.Table.CurrentRecord.SetValue("tipo", "Monto Fijo")

                    'solo concepto
                    Me.dgvConceptos2.Table.AddNewRecord.SetCurrent()
                    Me.dgvConceptos2.Table.AddNewRecord.BeginEdit()
                    Me.dgvConceptos2.Table.CurrentRecord.SetValue("idServicio", i.idServicio)
                    Me.dgvConceptos2.Table.CurrentRecord.SetValue("descripcion", i.descripcion)
                    Me.dgvConceptos2.Table.CurrentRecord.SetValue("cuenta", i.cuenta)
                    Me.dgvConceptos2.Table.CurrentRecord.SetValue("cuentaH", i.cuentaH)
                    Me.dgvConceptos2.Table.CurrentRecord.SetValue("cuentaDev", i.cuentaDev)
                    Me.dgvConceptos2.Table.CurrentRecord.SetValue("cuentaDevH", i.cuentaDevH)
                    Me.dgvConceptos2.Table.CurrentRecord.SetValue("valor", i.valor)
                    Me.dgvConceptos2.Table.CurrentRecord.SetValue("check", False)
                    Me.dgvConceptos2.Table.CurrentRecord.SetValue("estado", "N")
                    Me.dgvConceptos2.Table.CurrentRecord.SetValue("tipo", "Monto Fijo")

                End If


                Me.dgvConceptos.Table.AddNewRecord.EndEdit()
                Me.dgvConceptos2.Table.AddNewRecord.EndEdit()
            Next

            

        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try

    End Sub


    Sub GetTableGridConcepto()
        Dim dt As New DataTable()

        dt.Columns.Add("idServicio", GetType(Integer))
        dt.Columns.Add("descripcion", GetType(String))
        dt.Columns.Add("cuenta", GetType(String))
        dt.Columns.Add("cuentaH", GetType(String))
        dt.Columns.Add("cuentaDev", GetType(String))
        dt.Columns.Add("cuentaDevH", GetType(String))
        dt.Columns.Add("valor", GetType(Decimal))
        'dt.Columns.Add("check", GetType(Boolean))
        'dt.Columns.Add("estado", GetType(String))
        'dt.Columns.Add("tipo", GetType(String))
        'dt.Columns.Add("tipoCuenta", GetType(String))
        dgvConceptos.DataSource = dt
    End Sub

    Sub GetTableGridConcepto2()
        Dim dt As New DataTable()

        dt.Columns.Add("idServicio", GetType(Integer))
        dt.Columns.Add("descripcion", GetType(String))
        dt.Columns.Add("cuenta", GetType(String))
        dt.Columns.Add("cuentaH", GetType(String))
        dt.Columns.Add("cuentaDev", GetType(String))
        dt.Columns.Add("cuentaDevH", GetType(String))
        dt.Columns.Add("valor", GetType(Decimal))
        dt.Columns.Add("check", GetType(Boolean))
        dt.Columns.Add("estado", GetType(String))
        dt.Columns.Add("tipo", GetType(String))
        'dt.Columns.Add("tipoCuenta", GetType(String))
        dgvConceptos2.DataSource = dt
    End Sub


    '////////////////////

    Public Sub UbicarPrestamo(intCodigo As Integer)
        Dim objLista As New DocumentoCajaDetalleSA
        Dim listadetalle As New List(Of documentoPrestamoDetalle)
        Dim entidadSA As New entidadSA
        Dim personaSA As New PersonaSA

        lblIdDocumento.Text = intCodigo
        listadetalle = objLista.PrestamoSinConfirmarDetalle(intCodigo)
        cboTipoPR.Text = listadetalle(0).tipo
        'If listadetalle(0).moneda = "1" Then
        cboMoneda.SelectedValue = listadetalle(0).moneda
        'ElseIf listadetalle(0).moneda = "2" Then
        '    cboMoneda.Text = "EXTRANJERA"
        'End If
        Dim cuota As Decimal = listadetalle(0).numcuotas
        txtCuotas.Value = CDec(cuota)
        txtImporteCompramn.Value = listadetalle(0).montoprestamo
        txtImporteComprame.Value = listadetalle(0).montoprestamome
        DateTimePickerAdv2.Value = listadetalle(0).fechainicio
        cboModo.Text = listadetalle(0).modopago

        Select Case listadetalle(0).tipoBeneficiario
            Case TIPO_ENTIDAD.PROVEEDOR
                With entidadSA.UbicarEntidadPorID(listadetalle(0).idBeneficiario).First
                    txtProveedor.Text = .nombreCompleto
                End With
            Case TIPO_ENTIDAD.CLIENTE
                With entidadSA.UbicarEntidadPorID(listadetalle(0).idBeneficiario).First
                    txtProveedor.Text = .nombreCompleto
                End With
            Case "TR"
                With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, listadetalle(0).idBeneficiario, "TR")
                    txtProveedor.Text = .nombreCompleto
                End With
            Case "OT"
                With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, listadetalle(0).idBeneficiario, "OT")
                    txtProveedor.Text = .nombreCompleto
                End With
        End Select


        For Each i In listadetalle

            Me.dgvPrestamoRO.Table.AddNewRecord.SetCurrent()
            Me.dgvPrestamoRO.Table.AddNewRecord.BeginEdit()
            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("idDocumento", i.idDocumento)
            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("idCuota", i.idCuota)
            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("secuencia", i.secuencia)
            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", i.cuota)
            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("descripcion", i.descripcion)
            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montomn", i.montoSoles)
            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montome", i.montoUsd)
            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaVct", i.fechaVencimiento)
            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaPlazo", i.fechaPlazo)

            Me.dgvPrestamoRO.Table.AddNewRecord.EndEdit()

        Next

    End Sub



    '//////////////77


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
    '                Case "M"
    '                    'txtSerieComp.Visible = True
    '                    'txtNumeroComp.Visible = True
    '                    'LinkTipoDoc.Enabled = True
    '                    'txtSerieComp.Enabled = True
    '            End Select
    '            If Not IsNothing(.configAlmacen) Then
    '                Dim estableSA As New establecimientoSA
    '                With almacenSA.GetUbicar_almacenPorID(.configAlmacen)
    '                    GConfiguracion.IdAlmacen = .idAlmacen
    '                    GConfiguracion.NombreAlmacen = .descripcionAlmacen

    '                    'txtAlmacen.Text = GConfiguracion.NombreAlmacen
    '                    'txtIdAlmacen.Text = GConfiguracion.IdAlmacen
    '                    With estableSA.UbicaEstablecimientoPorID(.idEstablecimiento)
    '                        'txtIdEstableAlmacen.Text = .idCentroCosto
    '                        'txtEstableAlmacen.Text = .nombre
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
    '        'Timer1.Enabled = True
    '        'TabCompra.Enabled = False
    '        'TiempoEjecutar(5)
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

    Public Sub CargarTrabajadoresXnivel(strNivel As String, strBusqueda As String)
        Dim personaSA As New PersonaSA
        Try
            lsvProveedor.Items.Clear()
            For Each i In personaSA.ObtenerPersonaNumDocPorNivelxDescripcion(Gempresas.IdEmpresaRuc, strNivel, strBusqueda)
                Dim n As New ListViewItem(i.idPersona)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(String.Empty)
                n.SubItems.Add(i.idPersona)
                lsvProveedor.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub


    Public Sub CargarEntidadesXtipo(strTipo As String, strBusqueda As String)
        Dim entidadSA As New entidadSA
        Try
            lsvProveedor.Items.Clear()
            For Each i As entidad In entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.PROVEEDOR, strBusqueda)
                Dim n As New ListViewItem(i.idEntidad)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(i.cuentaAsiento)
                n.SubItems.Add(i.nrodoc)
                lsvProveedor.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub


    Sub Cuotas()
        If txtCuotas.Value > 0 Then
            If Not cboModo.Text.Trim.Length > 0 Then
                
                lblEstado.Text = "Elija un modo de pago!"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                Exit Sub


            End If
            If txtCuotas.Value > 0 Then

                If Not txtImporteCompramn.Value > 0 Then
                    ''MessageBox.Show("Ingrese un Monto de Prestamo")
                    'Exit Sub

                    lblEstado.Text = "Ingrese un Monto de Prestamo!"
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    Exit Sub
                End If

                txtCapital.Value = txtImporteCompramn.Value / txtCuotas.Value
                txtCapitalme.Value = txtImporteComprame.Value / txtCuotas.Value

                If txtCapital.Value > 0 Then
                    Dim valInteres As Decimal = Math.Round(txtporcseg.Value / 100, 2)
                    txtSeguro.Value = Math.Round(txtCapital.Value * valInteres, 2)
                    txtSeguroME.Value = Math.Round(txtCapitalme.Value * valInteres, 2)
                Else
                    txtporcseg.Value = 0
                    'MessageBox.Show("Ingrese Un Importe")
                    lblEstado.Text = "Ingrese Un Importe!"
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    Exit Sub
                End If


                If Not cboModo.SelectedIndex > -1 Then
                    'MessageBox.Show("especifica el modo de pago")
                    'Exit Sub
                    lblEstado.Text = "especifica el modo de pago!"
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    Exit Sub
                End If

                If cboModo.Text = "MENSUAL" Then
                    If Not cboDiaPago.SelectedIndex > -1 Then
                        'MessageBox.Show("especifica el dia de pago")
                        'Exit Sub
                        lblEstado.Text = "especifica el dia de pago!"
                        Timer1.Enabled = True
                        PanelError.Visible = True
                        TiempoEjecutar(10)
                        Exit Sub
                    End If
                End If

                If Not cbodiaplazo.SelectedIndex > -1 Then
                    'MessageBox.Show("especificar el periodo de gracia")
                    'Exit Sub
                    lblEstado.Text = "especificar el periodo de gracia!"
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    Exit Sub
                End If

                Dim fechaAux As DateTime

                Dim fechaModo As DateTime = DateTimePickerAdv2.Value
                If cboModo.Text = "MENSUAL" Then
                    fechaModo = New DateTime(fechaModo.Year, fechaModo.Month, CInt(cboDiaPago.Text))
                End If

                Dim fechaModo2 As DateTime = DateTimePickerAdv2.Value
                fechaModo2 = New DateTime(DateTimePickerAdv2.Value.Year, DateTimePickerAdv2.Value.Month, DateTimePickerAdv2.Value.Day)

                If txtTipoCambio.Value > 0 Then

                    dgvPrestamoRO.TableDescriptor.Columns.Clear()
                    'creacion de colummnas
                    dgvPrestamoRO.TableDescriptor.Columns.Add("idDocumento")
                    dgvPrestamoRO.TableDescriptor.Columns(0).Width = 0
                    dgvPrestamoRO.TableDescriptor.Columns(0).HeaderText = "idDocumento"
                    dgvPrestamoRO.TableDescriptor.Columns(0).MappingName = "idDocumento"

                    dgvPrestamoRO.TableDescriptor.Columns.Add("idCuota")
                    dgvPrestamoRO.TableDescriptor.Columns(1).Width = 0
                    dgvPrestamoRO.TableDescriptor.Columns(1).HeaderText = "idCuota"
                    dgvPrestamoRO.TableDescriptor.Columns(1).MappingName = "idCuota"

                    dgvPrestamoRO.TableDescriptor.Columns.Add("secuencia")
                    dgvPrestamoRO.TableDescriptor.Columns(2).Width = 0
                    dgvPrestamoRO.TableDescriptor.Columns(2).HeaderText = "secuencia"
                    dgvPrestamoRO.TableDescriptor.Columns(2).MappingName = "secuencia"

                    dgvPrestamoRO.TableDescriptor.Columns.Add("cuota")
                    dgvPrestamoRO.TableDescriptor.Columns(3).Width = 75
                    dgvPrestamoRO.TableDescriptor.Columns(3).HeaderText = "cuota"
                    dgvPrestamoRO.TableDescriptor.Columns(3).MappingName = "cuota"

                    dgvPrestamoRO.TableDescriptor.Columns.Add("descripcion")
                    dgvPrestamoRO.TableDescriptor.Columns(4).Width = 75
                    dgvPrestamoRO.TableDescriptor.Columns(4).HeaderText = "descripcion"
                    dgvPrestamoRO.TableDescriptor.Columns(4).MappingName = "descripcion"
                    If cboMoneda.SelectedValue = "1" Then
                        dgvPrestamoRO.TableDescriptor.Columns.Add("montomn")
                        dgvPrestamoRO.TableDescriptor.Columns(5).Width = 75
                        dgvPrestamoRO.TableDescriptor.Columns(5).HeaderText = "montomn"
                        dgvPrestamoRO.TableDescriptor.Columns(5).MappingName = "montomn"
                    Else
                        dgvPrestamoRO.TableDescriptor.Columns.Add("montomn")
                        dgvPrestamoRO.TableDescriptor.Columns(5).Width = 0
                        dgvPrestamoRO.TableDescriptor.Columns(5).HeaderText = "montomn"
                        dgvPrestamoRO.TableDescriptor.Columns(5).MappingName = "montomn"
                    End If
                    If cboMoneda.SelectedValue = "2" Then
                        dgvPrestamoRO.TableDescriptor.Columns.Add("montome")
                        dgvPrestamoRO.TableDescriptor.Columns(6).Width = 75
                        dgvPrestamoRO.TableDescriptor.Columns(6).HeaderText = "montome"
                        dgvPrestamoRO.TableDescriptor.Columns(6).MappingName = "montome"
                    Else
                        dgvPrestamoRO.TableDescriptor.Columns.Add("montome")
                        dgvPrestamoRO.TableDescriptor.Columns(6).Width = 0
                        dgvPrestamoRO.TableDescriptor.Columns(6).HeaderText = "montome"
                        dgvPrestamoRO.TableDescriptor.Columns(6).MappingName = "montome"
                    End If


                    dgvPrestamoRO.TableDescriptor.Columns.Add("FechaVct")
                    dgvPrestamoRO.TableDescriptor.Columns(7).Width = 75
                    dgvPrestamoRO.TableDescriptor.Columns(7).HeaderText = "FechaVct"
                    dgvPrestamoRO.TableDescriptor.Columns(7).MappingName = "FechaVct"

                    dgvPrestamoRO.TableDescriptor.Columns.Add("FechaPlazo")
                    dgvPrestamoRO.TableDescriptor.Columns(8).Width = 75
                    dgvPrestamoRO.TableDescriptor.Columns(8).HeaderText = "FechaPlazo"
                    dgvPrestamoRO.TableDescriptor.Columns(8).MappingName = "FechaPlazo"

                    dgvPrestamoRO.TableDescriptor.Columns.Add("cuenta")
                    dgvPrestamoRO.TableDescriptor.Columns(9).Width = 0
                    dgvPrestamoRO.TableDescriptor.Columns(9).HeaderText = "cuenta"
                    dgvPrestamoRO.TableDescriptor.Columns(9).MappingName = "cuenta"

                    dgvPrestamoRO.TableDescriptor.Columns.Add("cuentaH")
                    dgvPrestamoRO.TableDescriptor.Columns(10).Width = 0
                    dgvPrestamoRO.TableDescriptor.Columns(10).HeaderText = "cuentaH"
                    dgvPrestamoRO.TableDescriptor.Columns(10).MappingName = "cuentaH"

                    dgvPrestamoRO.TableDescriptor.Columns.Add("cuentaDev")
                    dgvPrestamoRO.TableDescriptor.Columns(11).Width = 0
                    dgvPrestamoRO.TableDescriptor.Columns(11).HeaderText = "cuentaDev"
                    dgvPrestamoRO.TableDescriptor.Columns(11).MappingName = "cuentaDev"

                    dgvPrestamoRO.TableDescriptor.Columns.Add("cuentaDevH")
                    dgvPrestamoRO.TableDescriptor.Columns(12).Width = 0
                    dgvPrestamoRO.TableDescriptor.Columns(12).HeaderText = "cuentaDevH"
                    dgvPrestamoRO.TableDescriptor.Columns(12).MappingName = "cuentaDevH"

                    GetTableGrid()

                    '///////////////

                    If txtImporteCompramn.Value > 0 Or txtImporteComprame.Value > 0 Then

                        dgvPrestamoRO.Table.Records.DeleteAll()
                        For x = 0 To txtCuotas.Value - 1
                            Dim cuota As Decimal
                            cuota = x + 1


                            If cboModo.Text = "MENSUAL" Then

                                If Year(fechaModo) = 12 Then
                                    fechaModo = fechaModo.AddMonths(1)
                                    fechaModo = fechaModo.AddYears(1)
                                Else
                                    fechaModo = fechaModo.AddMonths(1)
                                End If
                                fechaModo = fechaModo
                                fechaAux = fechaModo.AddDays(CInt(cbodiaplazo.Text))
                                '////////////

                                Me.dgvPrestamoRO.Table.AddNewRecord.SetCurrent()
                                Me.dgvPrestamoRO.Table.AddNewRecord.BeginEdit()
                                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("idCuota", cuota)
                                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", cuota)
                                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("descripcion", "CAPITAL")
                                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montomn", Format(Math.Round(CDec(txtCapital.Value), 2), "#,###,###,#0.00"))
                                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montome", Format(Math.Round(CDec(txtCapitalme.Value), 2), "#,###,###,#0.00"))
                                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaVct", fechaModo)
                                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaPlazo", fechaAux)
                                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuenta", "NO")
                                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaH", "NO")
                                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDev", "NO")
                                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDevH", "NO")
                                Me.dgvPrestamoRO.Table.AddNewRecord.EndEdit()

                                For Each i As Record In dgvConceptos2.Table.Records
                                    If i.GetValue("descripcion") = "INTERES" Then
                                        If txtInteresMN.Value > 0 Then
                                            Me.dgvPrestamoRO.Table.AddNewRecord.SetCurrent()
                                            Me.dgvPrestamoRO.Table.AddNewRecord.BeginEdit()
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("idCuota", cuota)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", cuota)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("descripcion", "INTERES")
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montomn", Format(Math.Round(CDec(txtInteresMN.Value), 2), "#,###,###,#0.00"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montome", Format(Math.Round(CDec(txtInteresME.Value), 2), "#,###,###,#0.00"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaVct", fechaModo)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaPlazo", fechaAux)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuenta", i.GetValue("cuenta"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaH", i.GetValue("cuentaH"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDev", i.GetValue("cuentaDev"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDevH", i.GetValue("cuentaDevH"))
                                            Me.dgvPrestamoRO.Table.AddNewRecord.EndEdit()
                                        End If


                                    ElseIf i.GetValue("descripcion") = "SEGURO" Then

                                        If txtSeguro.Value > 0 Then
                                            Me.dgvPrestamoRO.Table.AddNewRecord.SetCurrent()
                                            Me.dgvPrestamoRO.Table.AddNewRecord.BeginEdit()
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("idCuota", cuota)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", cuota)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("descripcion", "SEGURO")
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montomn", Format(Math.Round(CDec(txtSeguro.Value), 2), "#,###,###,#0.00"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montome", Format(Math.Round(CDec(txtSeguroME.Value), 2), "#,###,###,#0.00"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaVct", fechaModo)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaPlazo", fechaAux)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuenta", i.GetValue("cuenta"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaH", i.GetValue("cuentaH"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDev", i.GetValue("cuentaDev"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDevH", i.GetValue("cuentaDevH"))
                                            Me.dgvPrestamoRO.Table.AddNewRecord.EndEdit()
                                        End If
                                    Else

                                        If Not i.GetValue("estado") = "N" Then
                                            Me.dgvPrestamoRO.Table.AddNewRecord.SetCurrent()
                                            Me.dgvPrestamoRO.Table.AddNewRecord.BeginEdit()
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("idCuota", cuota)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", cuota)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("descripcion", i.GetValue("descripcion"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montomn", Format(Math.Round(CDec(i.GetValue("valor")), 2), "#,###,###,#0.00"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montome", Format(Math.Round(CDec(CDec(i.GetValue("valor")) / txtTipoCambio.Value), 2), "#,###,###,#0.00"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaVct", fechaModo)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaPlazo", fechaAux)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuenta", i.GetValue("cuenta"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaH", i.GetValue("cuentaH"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDev", i.GetValue("cuentaDev"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDevH", i.GetValue("cuentaDevH"))
                                            Me.dgvPrestamoRO.Table.AddNewRecord.EndEdit()
                                            Me.dgvPrestamoRO.Table.AddNewRecord.SetCurrent()
                                        End If

                                    End If

                                Next

                            ElseIf cboModo.Text = "QUINCENAL" Then

                                fechaModo2 = fechaModo2.AddDays(15)
                                fechaModo2 = fechaModo2
                                fechaAux = fechaModo2.AddDays(CInt(cbodiaplazo.Text))

                                Me.dgvPrestamoRO.Table.AddNewRecord.SetCurrent()
                                Me.dgvPrestamoRO.Table.AddNewRecord.BeginEdit()
                                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("idCuota", cuota)
                                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", cuota)
                                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("descripcion", "CAPITAL")
                                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montomn", Format(Math.Round(CDec(txtCapital.Value), 2), "#,###,###,#0.00"))
                                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montome", Format(Math.Round(CDec(txtCapitalme.Value), 2), "#,###,###,#0.00"))
                                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaVct", fechaModo2)
                                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaPlazo", fechaAux)
                                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuenta", "NO")
                                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaH", "NO")
                                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDev", "NO")
                                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDevH", "NO")
                                Me.dgvPrestamoRO.Table.AddNewRecord.EndEdit()

                                For Each i As Record In dgvConceptos2.Table.Records
                                    If i.GetValue("descripcion") = "INTERES" Then
                                        If txtInteresMN.Value > 0 Then
                                            Me.dgvPrestamoRO.Table.AddNewRecord.SetCurrent()
                                            Me.dgvPrestamoRO.Table.AddNewRecord.BeginEdit()
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("idCuota", cuota)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", cuota)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("descripcion", "INTERES")
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montomn", Format(Math.Round(CDec(txtInteresMN.Value), 2), "#,###,###,#0.00"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montome", Format(Math.Round(CDec(txtInteresME.Value), 2), "#,###,###,#0.00"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaVct", fechaModo2)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaPlazo", fechaAux)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuenta", i.GetValue("cuenta"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaH", i.GetValue("cuentaH"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDev", i.GetValue("cuentaDev"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDevH", i.GetValue("cuentaDevH"))
                                            Me.dgvPrestamoRO.Table.AddNewRecord.EndEdit()
                                        End If


                                    ElseIf i.GetValue("descripcion") = "SEGURO" Then

                                        If txtSeguro.Value > 0 Then
                                            Me.dgvPrestamoRO.Table.AddNewRecord.SetCurrent()
                                            Me.dgvPrestamoRO.Table.AddNewRecord.BeginEdit()
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("idCuota", cuota)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", cuota)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("descripcion", "SEGURO")
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montomn", Format(Math.Round(CDec(txtSeguro.Value), 2), "#,###,###,#0.00"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montome", Format(Math.Round(CDec(txtSeguroME.Value), 2), "#,###,###,#0.00"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaVct", fechaModo2)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaPlazo", fechaAux)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuenta", i.GetValue("cuenta"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaH", i.GetValue("cuentaH"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDev", i.GetValue("cuentaDev"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDevH", i.GetValue("cuentaDevH"))
                                            Me.dgvPrestamoRO.Table.AddNewRecord.EndEdit()
                                        End If

                                    Else
                                        If Not i.GetValue("estado") = "S" Then
                                            Me.dgvPrestamoRO.Table.AddNewRecord.SetCurrent()
                                            Me.dgvPrestamoRO.Table.AddNewRecord.BeginEdit()
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("idCuota", cuota)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", cuota)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("descripcion", i.GetValue("descripcion"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montomn", Format(Math.Round(CDec(i.GetValue("valor")), 2), "#,###,###,#0.00"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montome", Format(Math.Round(CDec(CDec(i.GetValue("valor")) / txtTipoCambio.Value), 2), "#,###,###,#0.00"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaVct", fechaModo)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaPlazo", fechaAux)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuenta", i.GetValue("cuenta"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaH", i.GetValue("cuentaH"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDev", i.GetValue("cuentaDev"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDevH", i.GetValue("cuentaDevH"))
                                            Me.dgvPrestamoRO.Table.AddNewRecord.EndEdit()
                                            Me.dgvPrestamoRO.Table.AddNewRecord.SetCurrent()
                                        End If

                                    End If
                                Next
                                '//////77
                            ElseIf cboModo.Text = "SEMANAL" Then

                                fechaModo2 = fechaModo2.AddDays(7)
                                fechaModo2 = fechaModo2
                                fechaAux = fechaModo2.AddDays(CInt(cbodiaplazo.Text))

                                Me.dgvPrestamoRO.Table.AddNewRecord.SetCurrent()
                                Me.dgvPrestamoRO.Table.AddNewRecord.BeginEdit()
                                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("idCuota", cuota)
                                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", cuota)
                                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("descripcion", "CAPITAL")
                                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montomn", Format(Math.Round(CDec(txtCapital.Value), 2), "#,###,###,#0.00"))
                                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montome", Format(Math.Round(CDec(txtCapitalme.Value), 2), "#,###,###,#0.00"))
                                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaVct", fechaModo2)
                                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaPlazo", fechaAux)
                                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuenta", "NO")
                                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaH", "NO")
                                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDev", "NO")
                                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDevH", "NO")
                                Me.dgvPrestamoRO.Table.AddNewRecord.EndEdit()


                                For Each i As Record In dgvConceptos2.Table.Records
                                    If i.GetValue("descripcion") = "INTERES" Then
                                        If txtInteresMN.Value > 0 Then
                                            Me.dgvPrestamoRO.Table.AddNewRecord.SetCurrent()
                                            Me.dgvPrestamoRO.Table.AddNewRecord.BeginEdit()
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("idCuota", cuota)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", cuota)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("descripcion", "INTERES")
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montomn", Format(Math.Round(CDec(txtInteresMN.Value), 2), "#,###,###,#0.00"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montome", Format(Math.Round(CDec(txtInteresME.Value), 2), "#,###,###,#0.00"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaVct", fechaModo2)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaPlazo", fechaAux)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuenta", i.GetValue("cuenta"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaH", i.GetValue("cuentaH"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDev", i.GetValue("cuentaDev"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDevH", i.GetValue("cuentaDevH"))
                                            Me.dgvPrestamoRO.Table.AddNewRecord.EndEdit()
                                        End If

                                    ElseIf i.GetValue("descripcion") = "SEGURO" Then

                                        If txtSeguro.Value > 0 Then
                                            Me.dgvPrestamoRO.Table.AddNewRecord.SetCurrent()
                                            Me.dgvPrestamoRO.Table.AddNewRecord.BeginEdit()
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("idCuota", cuota)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", cuota)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("descripcion", "SEGURO")
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montomn", Format(Math.Round(CDec(txtSeguro.Value), 2), "#,###,###,#0.00"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montome", Format(Math.Round(CDec(txtSeguroME.Value), 2), "#,###,###,#0.00"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaVct", fechaModo2)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaPlazo", fechaAux)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuenta", i.GetValue("cuenta"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaH", i.GetValue("cuentaH"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDev", i.GetValue("cuentaDev"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDevH", i.GetValue("cuentaDevH"))
                                            Me.dgvPrestamoRO.Table.AddNewRecord.EndEdit()
                                        End If

                                    Else

                                        If Not i.GetValue("estado") = "S" Then
                                            Me.dgvPrestamoRO.Table.AddNewRecord.SetCurrent()
                                            Me.dgvPrestamoRO.Table.AddNewRecord.BeginEdit()
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("idCuota", cuota)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", cuota)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("descripcion", i.GetValue("descripcion"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montomn", Format(Math.Round(CDec(i.GetValue("valor")), 2), "#,###,###,#0.00"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montome", Format(Math.Round(CDec(CDec(i.GetValue("valor")) / txtTipoCambio.Value), 2), "#,###,###,#0.00"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaVct", fechaModo)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaPlazo", fechaAux)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuenta", i.GetValue("cuenta"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaH", i.GetValue("cuentaH"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDev", i.GetValue("cuentaDev"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDevH", i.GetValue("cuentaDevH"))
                                            Me.dgvPrestamoRO.Table.AddNewRecord.EndEdit()
                                            Me.dgvPrestamoRO.Table.AddNewRecord.SetCurrent()
                                        End If

                                    End If
                                Next
                                '//////77
                            ElseIf cboModo.Text = "DIARIO" Then

                                fechaModo2 = fechaModo2.AddDays(1)
                                fechaModo2 = fechaModo2
                                fechaAux = fechaModo2.AddDays(CInt(cbodiaplazo.Text))

                                Me.dgvPrestamoRO.Table.AddNewRecord.SetCurrent()
                                Me.dgvPrestamoRO.Table.AddNewRecord.BeginEdit()
                                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("idCuota", cuota)
                                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", cuota)
                                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("descripcion", "CAPITAL")
                                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montomn", Format(Math.Round(CDec(txtCapital.Value), 2), "#,###,###,#0.00"))
                                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montome", Format(Math.Round(CDec(txtCapitalme.Value), 2), "#,###,###,#0.00"))
                                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaVct", fechaModo2)
                                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaPlazo", fechaAux)
                                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuenta", "NO")
                                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaH", "NO")
                                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDev", "NO")
                                Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDevH", "NO")
                                Me.dgvPrestamoRO.Table.AddNewRecord.EndEdit()

                                For Each i As Record In dgvConceptos2.Table.Records
                                    If i.GetValue("descripcion") = "INTERES" Then
                                        If txtInteresMN.Value > 0 Then
                                            Me.dgvPrestamoRO.Table.AddNewRecord.SetCurrent()
                                            Me.dgvPrestamoRO.Table.AddNewRecord.BeginEdit()
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("idCuota", cuota)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", cuota)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("descripcion", "INTERES")
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montomn", Format(Math.Round(CDec(txtInteresMN.Value), 2), "#,###,###,#0.00"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montome", Format(Math.Round(CDec(txtInteresME.Value), 2), "#,###,###,#0.00"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaVct", fechaModo2)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaPlazo", fechaAux)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuenta", i.GetValue("cuenta"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaH", i.GetValue("cuentaH"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDev", i.GetValue("cuentaDev"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDevH", i.GetValue("cuentaDevH"))
                                            Me.dgvPrestamoRO.Table.AddNewRecord.EndEdit()
                                        End If




                                    ElseIf i.GetValue("descripcion") = "SEGURO" Then

                                        If txtSeguro.Value > 0 Then
                                            Me.dgvPrestamoRO.Table.AddNewRecord.SetCurrent()
                                            Me.dgvPrestamoRO.Table.AddNewRecord.BeginEdit()
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("idCuota", cuota)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", cuota)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("descripcion", "SEGURO")
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montomn", Format(Math.Round(CDec(txtSeguro.Value), 2), "#,###,###,#0.00"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montome", Format(Math.Round(CDec(txtSeguroME.Value), 2), "#,###,###,#0.00"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaVct", fechaModo2)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaPlazo", fechaAux)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuenta", i.GetValue("cuenta"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaH", i.GetValue("cuentaH"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDev", i.GetValue("cuentaDev"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDevH", i.GetValue("cuentaDevH"))
                                            Me.dgvPrestamoRO.Table.AddNewRecord.EndEdit()
                                        End If

                                    Else

                                        If Not i.GetValue("estado") = "S" Then
                                            Me.dgvPrestamoRO.Table.AddNewRecord.SetCurrent()
                                            Me.dgvPrestamoRO.Table.AddNewRecord.BeginEdit()
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("idCuota", cuota)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", cuota)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("descripcion", i.GetValue("descripcion"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montomn", Format(Math.Round(CDec(i.GetValue("valor")), 2), "#,###,###,#0.00"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montome", Format(Math.Round(CDec(CDec(i.GetValue("valor")) / txtTipoCambio.Value), 2), "#,###,###,#0.00"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaVct", fechaModo)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaPlazo", fechaAux)
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuenta", i.GetValue("cuenta"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaH", i.GetValue("cuentaH"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDev", i.GetValue("cuentaDev"))
                                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDevH", i.GetValue("cuentaDevH"))
                                            Me.dgvPrestamoRO.Table.AddNewRecord.EndEdit()
                                            Me.dgvPrestamoRO.Table.AddNewRecord.SetCurrent()
                                        End If
                                    End If

                                Next

                            End If

                        Next

                    Else

                        lblEstado.Text = "Ingrese un monto mayor 0"
                        txtCuotas.Value = CDec(0)
                    End If

                Else
                    lblEstado.Text = "Ingrese un tipo de cambio"
                    txtCuotas.Value = CDec(0)

                End If
            End If

        End If

        montoPorConcepto()
    End Sub




    Sub GetTableGrid()
        Dim dt As New DataTable()

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("idCuota", GetType(Integer))
        dt.Columns.Add("secuencia", GetType(Integer))
        dt.Columns.Add("cuota", GetType(Integer))
        dt.Columns.Add("descripcion", GetType(String))
        dt.Columns.Add("montomn", GetType(Decimal))
        dt.Columns.Add("montome", GetType(Decimal))
        dt.Columns.Add("FechaVct", GetType(Date))
        dt.Columns.Add("FechaPlazo", GetType(Date))
        dt.Columns.Add("cuenta", GetType(String))
        dt.Columns.Add("cuentaH", GetType(String))
        dt.Columns.Add("cuentaDev", GetType(String))
        dt.Columns.Add("cuentaDevH", GetType(String))


        dgvPrestamoRO.DataSource = dt

        dgvPrestamoRO.ShowGroupDropArea = False
        dgvPrestamoRO.TableDescriptor.GroupedColumns.Clear()
        dgvPrestamoRO.TableDescriptor.GroupedColumns.Add("cuota")

        dgvPrestamoRO.TableDescriptor.Columns("idDocumento").ReadOnly = True
        dgvPrestamoRO.TableDescriptor.Columns("idCuota").ReadOnly = True
        dgvPrestamoRO.TableDescriptor.Columns("secuencia").ReadOnly = True
        dgvPrestamoRO.TableDescriptor.Columns("cuota").ReadOnly = True
        dgvPrestamoRO.TableDescriptor.Columns("descripcion").ReadOnly = True
        dgvPrestamoRO.TableDescriptor.Columns("montomn").ReadOnly = True
        dgvPrestamoRO.TableDescriptor.Columns("montome").ReadOnly = True
        dgvPrestamoRO.TableDescriptor.Columns("FechaVct").ReadOnly = True
        dgvPrestamoRO.TableDescriptor.Columns("FechaPlazo").ReadOnly = True
        dgvPrestamoRO.TableDescriptor.Columns("cuenta").ReadOnly = True
        dgvPrestamoRO.TableDescriptor.Columns("cuentaH").ReadOnly = True
        dgvPrestamoRO.TableDescriptor.Columns("cuentaDev").ReadOnly = True
        dgvPrestamoRO.TableDescriptor.Columns("cuentaDevH").ReadOnly = True

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


    Public Sub UbicarPrestamoXcodigo(intIdPrestamo As Integer)
        Dim prestamoSA As New prestamosSA
        Dim entidadSA As New entidadSA
        Dim personaSA As New PersonaSA

        With prestamoSA.UbicarPrestamoXcodigo(intIdPrestamo)
            lblEstado.Text = "Modificar préstamo"
            idPrestamo = .codigo
            fecha = .fechaPrestamo
            txtFechaComprobante.Value = .fechaPrestamo
            'txtNumero.Text = .nroDoc
            cboMoneda.SelectedValue = .moneda
            Select Case .tipoBeneficiario
                Case "PR"
                    chProv.Checked = True
                    chTrab.Checked = False
                    chCli.Checked = False

                    With entidadSA.UbicarEntidadPorID(.idBeneficiario).First
                        txtProveedor.Text = .nombreCompleto
                        txtProveedor.Tag = .idEntidad
                        txtRuc.Text = .nrodoc
                    End With

                Case "CL"
                    chProv.Checked = False
                    chTrab.Checked = False
                    chCli.Checked = True

                    With entidadSA.UbicarEntidadPorID(.idBeneficiario).First
                        txtProveedor.Text = .nombreCompleto
                        txtProveedor.Tag = .idEntidad
                        txtRuc.Text = .nrodoc
                    End With
                Case "TR"
                    chProv.Checked = False
                    chTrab.Checked = True
                    chCli.Checked = False

                    With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, .idBeneficiario, "TR")
                        txtProveedor.Text = .nombreCompleto
                        txtProveedor.Tag = .idPersona
                        txtRuc.Text = .idPersona
                    End With
                Case "OT"
                    chProv.Checked = False
                    chTrab.Checked = False
                    chCli.Checked = False

                    With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, .idBeneficiario, "OT")
                        txtProveedor.Text = .nombreCompleto
                        txtProveedor.Tag = .idPersona
                        txtRuc.Text = .idPersona
                    End With
            End Select
            txtTipoCambio.Value = .tipoCambio
            txtImporteCompramn.Value = .monto
            txtImporteComprame.Value = .montoUSD

            lblPerido.Text = .periodo


            txtCuotas.Value = .numCuotas
        End With

    End Sub




    Private Sub SavePrestamo()
        Dim objPrestamoEO As New documentoPrestamos
        Dim objDocumentoEO As New documento
        Dim prestamoEO As New prestamos
        Dim docPrestamo As New documentoPrestamos
        Dim documentoPrestamoSA As New documentoPrestamoSA
        Dim listaPrestamo As New List(Of documentoPrestamos)
        Dim docPrestamoDet As New documentoPrestamoDetalle
        Dim ListaDetalle As New List(Of documentoPrestamoDetalle)
        Try
            With objDocumentoEO
                .IdDocumentoAfectado = lblIdDocumento.Text
                .idDocumento = 0
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                .tipoDoc = GConfiguracion.TipoComprobante
                .fechaProceso = txtFechaComprobante.Value
                .nroDoc = Nothing ' txtNroDocumento.Text
                .idOrden = Nothing
                .tipoOperacion = "100"
                .usuarioActualizacion = "Jiuni"
                .fechaActualizacion = Date.Now
            End With


            With prestamoEO
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .DocPrestamo = "9903"  'voucher de caja
                .fechaPrestamo = DateTime.Now
                .periodo = PeriodoGeneral
                .tipoPrestamo = "POT"
                If chProv.Checked = True Then
                    .tipoBeneficiario = "PR"
                ElseIf chCli.Checked = True Then
                    .tipoBeneficiario = "CL"
                ElseIf chTrab.Checked = True Then
                    .tipoBeneficiario = "TR"
                End If
                .idBeneficiario = Val(txtProveedor.Tag)
                .detalleGlosa = "PRESTAMOS"
                .moneda = cboMoneda.SelectedValue
                .tipoCambio = txtTipoCambio.Value
                .tipo = cboTipoPR.Text
                .monto = txtImporteCompramn.Value
                .montoUSD = txtImporteComprame.Value
                .interes = txtInteresTotal.Value

                .tipoActivo = "101"
                .entregaPendiente = "NO"
                .desembolso = "NO"

                .estado = TIPO_COMPRA.PAGO.PENDIENTE_PAGO  ' P: pendiente or E: entregado
                .usuarioActualizacion = "Jiuni"
                .fechaActualizacion = Now.Date

                .fechaDesembolso = DateTime.Now
                .numCuotas = CInt(txtCuotas.Value)

                .IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
                'ultimo
                .cuentaTipo = txtDevengado.Text
                '.cuentaDevengado = txtDevengadoH.Text


                .modoPago = cboModo.Text
                If cboModo.Text = "MENSUAL" Then
                    Dim diapago = cboDiaPago.Text
                    .diaPago = CInt(diapago)
                Else
                    .diaPago = 1
                End If
                .fechaInicio = DateTimePickerAdv2.Value
                Dim plazo = cbodiaplazo.Text
                .plazoDias = CInt(plazo)

            End With

            '/////////////////
            Dim nombrecuenta As Integer = 0
            For Each i As Record In dgvPrestamoRO.Table.Records

                If Not i.GetValue("cuota") = nombrecuenta Then
                    nombrecuenta = i.GetValue("cuota")
                    docPrestamo = New documentoPrestamos
                    docPrestamo.TipoConfiguracion = GConfiguracion.TipoConfiguracion
                    'docPrestamo.IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
                    docPrestamo.idEmpresa = Gempresas.IdEmpresaRuc
                    docPrestamo.idEstablecimiento = GEstableciento.IdEstablecimiento
                    docPrestamo.cuentaContable = "12"
                    docPrestamo.tipoMovimiento = "PR"
                    If chProv.Checked = True Then
                        docPrestamo.tipoBeneficiario = "PR"
                    ElseIf chCli.Checked = True Then
                        docPrestamo.tipoBeneficiario = "CL"
                    ElseIf chTrab.Checked = True Then
                        docPrestamo.tipoBeneficiario = "TR"
                    End If
                    docPrestamo.idBeneficiario = Val(txtProveedor.Tag)
                    docPrestamo.fecha = txtFechaComprobante.Value
                    docPrestamo.referencia = i.GetValue("cuota")
                    docPrestamo.moneda = "1"
                    docPrestamo.montoSoles = txtCapital.Value
                    docPrestamo.montoDolares = txtCapitalme.Value
                    docPrestamo.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                    ''''''''
                    If Not IsNothing(i.GetValue("FechaVct")) Then
                        If i.GetValue("FechaVct").ToString.Trim.Length > 0 Then
                            If IsDate(i.GetValue("FechaVct")) Then
                                docPrestamo.fechaVcto = CDate(i.GetValue("FechaVct"))
                            Else
                                MsgBox("Debe ingresar un formato correcto de fecha.", MsgBoxStyle.Exclamation, "Atención")
                                Me.Cursor = Cursors.Arrow
                                Exit Sub
                            End If
                        Else
                            MsgBox("Debe ingresar la fecha de vencimiento de las cuotas", MsgBoxStyle.Information, "Atención")
                            Me.Cursor = Cursors.Arrow
                            Exit Sub
                        End If
                    Else
                        MsgBox("Debe ingresar la fecha de vencimiento de las cuotas", MsgBoxStyle.Information, "Atención")
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If
                    ''''''''''
                    If Not IsNothing(i.GetValue("FechaPlazo")) Then
                        If i.GetValue("FechaPlazo").ToString.Trim.Length > 0 Then
                            If IsDate(i.GetValue("FechaPlazo")) Then
                                docPrestamo.fechaPlazo = CDate(i.GetValue("FechaPlazo"))
                            Else
                                MsgBox("Debe ingresar un formato correcto de fecha.", MsgBoxStyle.Exclamation, "Atención")
                                Me.Cursor = Cursors.Arrow
                                Exit Sub
                            End If
                        Else
                            MsgBox("Debe ingresar la fecha de vencimiento de las cuotas", MsgBoxStyle.Information, "Atención")
                            Me.Cursor = Cursors.Arrow
                            Exit Sub
                        End If
                    Else
                        MsgBox("Debe ingresar la fecha de vencimiento de las cuotas", MsgBoxStyle.Information, "Atención")
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If
                    '''''
                    docPrestamo.entregado = "S"
                    docPrestamo.usuarioActualizacion = "Jiuni"
                    docPrestamo.fechaActualizacion = Date.Now
                    listaPrestamo.Add(docPrestamo)
                End If
                '//DetallePrestamo
                docPrestamoDet = New documentoPrestamoDetalle
                docPrestamoDet.montoSoles = CDec(i.GetValue("montomn"))
                docPrestamoDet.montoUsd = CDec(i.GetValue("montome"))
                docPrestamoDet.descripcion = i.GetValue("descripcion")
                docPrestamoDet.estadoPago = "PN"
                docPrestamoDet.referencia = i.GetValue("cuota")
                docPrestamoDet.cuota = i.GetValue("cuota")
                docPrestamoDet.fechaVencimiento = CDate(i.GetValue("FechaVct"))
                docPrestamoDet.fechaPlazo = CDate(i.GetValue("FechaPlazo"))
                docPrestamoDet.cuenta = i.GetValue("cuenta")
                docPrestamoDet.tieneCosto = "N"
                docPrestamoDet.cuentaH = i.GetValue("cuentaH")
                docPrestamoDet.devengado = i.GetValue("cuentaDev")
                docPrestamoDet.devengadoH = i.GetValue("cuentaDevH")

                ListaDetalle.Add(docPrestamoDet)
            Next
            documentoPrestamoSA.InsertPrestamoRecibido(objDocumentoEO, prestamoEO, listaPrestamo, ListaDetalle)
            Dispose()
        Catch ex As Exception
            MsgBox("Error al confirmar el prestámo." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del sistema")
        End Try
    End Sub


    Private Sub UpdatePrestamo()
        Dim prestamoSA As New prestamosSA
        Dim objPrestamoEO As New prestamos
        Try
            With objPrestamoEO
                .codigo = idPrestamo
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .DocPrestamo = "9903"  'voucher de caja
                .fechaPrestamo = fecha ' txtFechaComprobante.Value
                .periodo = lblPerido.Text

                .tipoPrestamo = "POT" ' Prestamo otorgado


                If chProv.Checked = True Then
                    .tipoBeneficiario = "PR"
                ElseIf chCli.Checked = True Then
                    .tipoBeneficiario = "CL"
                ElseIf chTrab.Checked = True Then
                    .tipoBeneficiario = "TR"

                End If
                .idBeneficiario = Val(txtProveedor.Tag)
                .detalleGlosa = "PRESTAMOS"
                '.nroDoc = txtNumero.Text.Trim
                .moneda = cboMoneda.SelectedValue
                .tipoCambio = txtTipoCambio.Value
                .monto = txtImporteCompramn.Value
                .montoUSD = txtImporteComprame.Value

                .tipoActivo = "101"
                .entregaPendiente = "NO"
                .estado = TIPO_COMPRA.PAGO.PENDIENTE_PAGO  ' P: pendiente or E: entregado
                .usuarioActualizacion = "Jiuni"
                .fechaActualizacion = Now.Date
                .fechaDesembolso = DateTime.Now
                .numCuotas = CInt(txtCuotas.Value)

            End With

            prestamoSA.EditarPrePrestamo(objPrestamoEO)
            Dispose()

        Catch ex As Exception
            MsgBox("No se pudo guardar los datos." & vbCrLf & ex.Message)
        End Try
    End Sub


#End Region

    Private Sub frmPrestamo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmPrestamo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '//////////////////////
    End Sub

    Private Sub PegarToolStripButton_Click(sender As Object, e As EventArgs)
        Dispose()
    End Sub

    Private Sub txtTipoCambio_ValueChanged(sender As Object, e As EventArgs) Handles txtTipoCambio.ValueChanged

        If txtTipoCambio.Value > 0 Then

            If txtTipoCambio.Value > 0 Then
                txtPorcIneteres.Enabled = True

                If cboMoneda.SelectedValue = "1" Then
                    txtImporteComprame.Value = Math.Round(CDec(txtImporteCompramn.Value) / CDec(txtTipoCambio.Value), 2)
                    txtMontoSolesRef.Text = Math.Round(CDec(txtImporteCompramn.Value), 2)
                Else
                    txtImporteCompramn.Value = Math.Round(CDec(txtImporteComprame.Value) * CDec(txtTipoCambio.Value), 2)
                    txtMontoSolesRef.Text = Math.Round(CDec(txtImporteComprame.Value) * CDec(txtTipoCambio.Value), 2)
                End If
            Else
                txtImporteComprame.Value = 0
                txtImporteCompramn.Value = 0
                txtPorcIneteres.Enabled = False

            End If
        Else

            lblEstado.Text = "ingrese un tipo de cambio"
        End If
    End Sub

    Private Sub txtPorcIneteres_ValueChanged(sender As Object, e As EventArgs) Handles txtPorcIneteres.ValueChanged

        If txtTipoCambio.Value > 0 Then
            Dim valInteres As Decimal = Math.Round(txtPorcIneteres.Value / 100, 2)
            Dim monto As Decimal = CDec(0.0)
            Dim montoseguro As Decimal = CDec(0.0)

            txtInteresMN.Value = Math.Round(txtCapital.Value * valInteres, 2)
            txtInteresME.Value = Math.Round(txtCapitalme.Value * valInteres, 2)


            monto = Math.Round(txtImporteCompramn.Value * valInteres, 2)
            'txtInteresMonto.Value = Math.Round(txtImporteCompramn.Value * valInteres, 2)
            txtInteresMonto.Value = monto
            txtInteresMontome.Value = Math.Round(CDec(monto) / CDec(txtTipoCambio.Value), 2)


            Dim valIntereSeg As Decimal = Math.Round(txtporcseg.Value / 100, 2)
            'txtSeguroMonto.Value = Math.Round(txtImporteCompramn.Value * valIntereSeg, 2)
            montoseguro = Math.Round(txtImporteCompramn.Value * valIntereSeg, 2)
            txtSeguroMonto.Value = montoseguro
            txtSeguroMontome.Value = Math.Round(CDec(montoseguro) / CDec(txtTipoCambio.Value), 2)

        End If
        If txtCuotas.Value > 0 Then
            Cuotas()
        End If


    End Sub

    Private Sub GuardarToolStripButton_Click(sender As Object, e As EventArgs)
        Me.Cursor = Cursors.WaitCursor
        If Not txtProveedor.Text.Trim.Length > 0 Then
            lblEstado.Text = "Debe elegir un beneficiario!"
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
            txtRuc.Select()
            txtRuc.Focus()
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        If Not txtTipoCambio.Value > 0 Then
            lblEstado.Text = "El tipo de cambio debe ser mayor a cero!"
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
            txtTipoCambio.Select()
            txtTipoCambio.Focus()
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        If Not txtImporteCompramn.Value > 0 Then
            lblEstado.Text = "Ingrese un monto > a '0' del prestamo!"
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
            txtImporteCompramn.Select()
            txtImporteCompramn.Focus()
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        'If Not txtNumero.Text.Trim.Length > 0 Then
        '    lblEstado.Text = "Ingrese el número de prestámo!"
        '    Timer1.Enabled = True
        '    PanelError.Visible = True
        '    TiempoEjecutar(10)
        '    txtNumero.Select()
        '    txtNumero.Focus()
        '    Me.Cursor = Cursors.Arrow
        '    Exit Sub
        'End If

        Select Case ManipulacionEstado
            Case ENTITY_ACTIONS.INSERT
                SavePrestamo()
            Case ENTITY_ACTIONS.UPDATE
                UpdatePrestamo()
        End Select

        Me.Cursor = Cursors.Arrow
    End Sub





    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
            fecha = New DateTime(txtFechaComprobante.Value.Year, txtFechaComprobante.Value.Month, txtFechaComprobante.Value.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        Else
            fecha = New DateTime(fecha.Year, fecha.Month, txtFechaComprobante.Value.Day, txtFechaComprobante.Value.Hour, txtFechaComprobante.Value.Minute, txtFechaComprobante.Value.Second)
        End If
    End Sub



    Private Sub txtImporteCompramn_ValueChanged(sender As Object, e As EventArgs) Handles txtImporteCompramn.ValueChanged
        txtTipoCambio_ValueChanged(sender, e)
        txtPorcIneteres_ValueChanged(sender, e)
        If txtCuotas.Value > 0 Then
            Cuotas()
        End If
    End Sub


    Private Sub txtNumero_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not (Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar)) Then
            e.Handled = True
        End If
    End Sub


    Private Sub txtCuotas_ValueChanged(sender As Object, e As EventArgs) Handles txtCuotas.ValueChanged

        If Not cboTipoPR.Text.Trim.Length > 0 Then
            txtCuotas.Value = CDec(0)
            'MessageBox.Show("Seleccione un Tipo de Prestamo")
            'Exit Sub

            lblEstado.Text = "Seleccione un Tipo de Prestamo!"
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
            Exit Sub
        End If

        If txtCuotas.Value > 0 Then

            If Not txtImporteCompramn.Value > 0 Then
                txtCuotas.Value = CDec(0)
                'MessageBox.Show("Ingrese un Monto de Prestamo")
                'Exit Sub

                lblEstado.Text = "Ingrese un Monto de Prestamo!"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                Exit Sub
            End If

            txtCapital.Value = txtImporteCompramn.Value / txtCuotas.Value
            txtCapitalme.Value = txtImporteComprame.Value / txtCuotas.Value

            If txtCapital.Value > 0 Then
                Dim valInteres As Decimal = Math.Round(txtporcseg.Value / 100, 2)
                txtSeguro.Value = Math.Round(txtCapital.Value * valInteres, 2)
                txtSeguroME.Value = Math.Round(txtCapitalme.Value * valInteres, 2)
            Else
                txtporcseg.Value = 0
                ' MessageBox.Show("Ingrese Un Importe")

                lblEstado.Text = "Ingrese Un Importe!"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                Exit Sub
            End If

            Dim valInteres2 As Decimal = Math.Round(txtPorcIneteres.Value / 100, 2)
            txtInteresMN.Value = Math.Round(txtCapital.Value * valInteres2, 2)
            txtInteresME.Value = Math.Round(txtCapitalme.Value * valInteres2, 2)

            If Not cboModo.SelectedIndex > -1 Then
                'MessageBox.Show("especifica el modo de pago")
                'Exit Sub

                lblEstado.Text = "especifica el modo de pago!"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                Exit Sub
            End If

            If cboModo.Text = "MENSUAL" Then
                If Not cboDiaPago.SelectedIndex > -1 Then
                    MessageBox.Show("especifica el dia de pago")
                    Exit Sub
                End If

            End If

            If Not cbodiaplazo.SelectedIndex > -1 Then

                lblEstado.Text = "especificar el periodo de gracia!"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                Exit Sub
            End If

            Dim fechaAux As DateTime

            Dim fechaModo As DateTime = DateTimePickerAdv2.Value
            If cboModo.Text = "MENSUAL" Then
                fechaModo = New DateTime(fechaModo.Year, fechaModo.Month, CInt(cboDiaPago.Text))
            End If

            Dim fechaModo2 As DateTime = DateTimePickerAdv2.Value
            fechaModo2 = New DateTime(DateTimePickerAdv2.Value.Year, DateTimePickerAdv2.Value.Month, DateTimePickerAdv2.Value.Day)

            If txtTipoCambio.Value > 0 Then

                dgvPrestamoRO.TableDescriptor.Columns.Clear()
                'creacion de colummnas
                dgvPrestamoRO.TableDescriptor.Columns.Add("idDocumento")
                dgvPrestamoRO.TableDescriptor.Columns(0).Width = 0
                dgvPrestamoRO.TableDescriptor.Columns(0).HeaderText = "idDocumento"
                dgvPrestamoRO.TableDescriptor.Columns(0).MappingName = "idDocumento"

                dgvPrestamoRO.TableDescriptor.Columns.Add("idCuota")
                dgvPrestamoRO.TableDescriptor.Columns(1).Width = 0
                dgvPrestamoRO.TableDescriptor.Columns(1).HeaderText = "idCuota"
                dgvPrestamoRO.TableDescriptor.Columns(1).MappingName = "idCuota"

                dgvPrestamoRO.TableDescriptor.Columns.Add("secuencia")
                dgvPrestamoRO.TableDescriptor.Columns(2).Width = 0
                dgvPrestamoRO.TableDescriptor.Columns(2).HeaderText = "secuencia"
                dgvPrestamoRO.TableDescriptor.Columns(2).MappingName = "secuencia"

                dgvPrestamoRO.TableDescriptor.Columns.Add("cuota")
                dgvPrestamoRO.TableDescriptor.Columns(3).Width = 75
                dgvPrestamoRO.TableDescriptor.Columns(3).HeaderText = "cuota"
                dgvPrestamoRO.TableDescriptor.Columns(3).MappingName = "cuota"

                dgvPrestamoRO.TableDescriptor.Columns.Add("descripcion")
                dgvPrestamoRO.TableDescriptor.Columns(4).Width = 75
                dgvPrestamoRO.TableDescriptor.Columns(4).HeaderText = "descripcion"
                dgvPrestamoRO.TableDescriptor.Columns(4).MappingName = "descripcion"
                If cboMoneda.SelectedValue = "1" Then
                    dgvPrestamoRO.TableDescriptor.Columns.Add("montomn")
                    dgvPrestamoRO.TableDescriptor.Columns(5).Width = 75
                    dgvPrestamoRO.TableDescriptor.Columns(5).HeaderText = "montomn"
                    dgvPrestamoRO.TableDescriptor.Columns(5).MappingName = "montomn"
                Else
                    dgvPrestamoRO.TableDescriptor.Columns.Add("montomn")
                    dgvPrestamoRO.TableDescriptor.Columns(5).Width = 0
                    dgvPrestamoRO.TableDescriptor.Columns(5).HeaderText = "montomn"
                    dgvPrestamoRO.TableDescriptor.Columns(5).MappingName = "montomn"
                End If
                If cboMoneda.SelectedValue = "2" Then
                    dgvPrestamoRO.TableDescriptor.Columns.Add("montome")
                    dgvPrestamoRO.TableDescriptor.Columns(6).Width = 75
                    dgvPrestamoRO.TableDescriptor.Columns(6).HeaderText = "montome"
                    dgvPrestamoRO.TableDescriptor.Columns(6).MappingName = "montome"
                Else
                    dgvPrestamoRO.TableDescriptor.Columns.Add("montome")
                    dgvPrestamoRO.TableDescriptor.Columns(6).Width = 0
                    dgvPrestamoRO.TableDescriptor.Columns(6).HeaderText = "montome"
                    dgvPrestamoRO.TableDescriptor.Columns(6).MappingName = "montome"
                End If


                dgvPrestamoRO.TableDescriptor.Columns.Add("FechaVct")
                dgvPrestamoRO.TableDescriptor.Columns(7).Width = 75
                dgvPrestamoRO.TableDescriptor.Columns(7).HeaderText = "FechaVct"
                dgvPrestamoRO.TableDescriptor.Columns(7).MappingName = "FechaVct"

                dgvPrestamoRO.TableDescriptor.Columns.Add("FechaPlazo")
                dgvPrestamoRO.TableDescriptor.Columns(8).Width = 75
                dgvPrestamoRO.TableDescriptor.Columns(8).HeaderText = "FechaPlazo"
                dgvPrestamoRO.TableDescriptor.Columns(8).MappingName = "FechaPlazo"

                dgvPrestamoRO.TableDescriptor.Columns.Add("cuenta")
                dgvPrestamoRO.TableDescriptor.Columns(9).Width = 0
                dgvPrestamoRO.TableDescriptor.Columns(9).HeaderText = "cuenta"
                dgvPrestamoRO.TableDescriptor.Columns(9).MappingName = "cuenta"

                dgvPrestamoRO.TableDescriptor.Columns.Add("cuentaH")
                dgvPrestamoRO.TableDescriptor.Columns(10).Width = 0
                dgvPrestamoRO.TableDescriptor.Columns(10).HeaderText = "cuentaH"
                dgvPrestamoRO.TableDescriptor.Columns(10).MappingName = "cuentaH"

                dgvPrestamoRO.TableDescriptor.Columns.Add("cuentaDev")
                dgvPrestamoRO.TableDescriptor.Columns(11).Width = 0
                dgvPrestamoRO.TableDescriptor.Columns(11).HeaderText = "cuentaDev"
                dgvPrestamoRO.TableDescriptor.Columns(11).MappingName = "cuentaDev"

                dgvPrestamoRO.TableDescriptor.Columns.Add("cuentaDevH")
                dgvPrestamoRO.TableDescriptor.Columns(12).Width = 0
                dgvPrestamoRO.TableDescriptor.Columns(12).HeaderText = "cuentaDevH"
                dgvPrestamoRO.TableDescriptor.Columns(12).MappingName = "cuentaDevH"


                GetTableGrid()



                '///////////////

                If txtImporteCompramn.Value > 0 Or txtImporteComprame.Value > 0 Then

                    dgvPrestamoRO.Table.Records.DeleteAll()
                    For x = 0 To txtCuotas.Value - 1
                        Dim cuota As Decimal
                        cuota = x + 1

                        If cboModo.Text = "MENSUAL" Then

                            If Year(fechaModo) = 12 Then
                                fechaModo = fechaModo.AddMonths(1)
                                fechaModo = fechaModo.AddYears(1)
                            Else
                                fechaModo = fechaModo.AddMonths(1)
                            End If
                            fechaModo = fechaModo
                            fechaAux = fechaModo.AddDays(CInt(cbodiaplazo.Text))
                            '////////////


                            Me.dgvPrestamoRO.Table.AddNewRecord.SetCurrent()
                            Me.dgvPrestamoRO.Table.AddNewRecord.BeginEdit()
                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("idCuota", cuota)
                            'Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", "Cuota nro. " & cuota)
                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", cuota)
                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("descripcion", "CAPITAL")

                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montomn", Format(Math.Round(CDec(txtCapital.Value), 2), "#,###,###,#0.00"))
                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montome", Format(Math.Round(CDec(txtCapitalme.Value), 2), "#,###,###,#0.00"))

                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaVct", fechaModo)
                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaPlazo", fechaAux)
                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuenta", "NO")
                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaH", "NO")
                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDev", "NO")
                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDevH", "NO")

                            Me.dgvPrestamoRO.Table.AddNewRecord.EndEdit()

                            For Each i As Record In dgvConceptos2.Table.Records
                                If i.GetValue("descripcion") = "INTERES" Then
                                    If txtInteresMN.Value > 0 Then
                                        Me.dgvPrestamoRO.Table.AddNewRecord.SetCurrent()
                                        Me.dgvPrestamoRO.Table.AddNewRecord.BeginEdit()
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("idCuota", cuota)
                                        ' Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", "Cuota nro. " & cuota)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", cuota)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("descripcion", "INTERES")
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montomn", Format(Math.Round(CDec(txtInteresMN.Value), 2), "#,###,###,#0.00"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montome", Format(Math.Round(CDec(txtInteresME.Value), 2), "#,###,###,#0.00"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaVct", fechaModo)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaPlazo", fechaAux)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuenta", i.GetValue("cuenta"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaH", i.GetValue("cuentaH"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDev", i.GetValue("cuentaDev"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDevH", i.GetValue("cuentaDevH"))
                                        Me.dgvPrestamoRO.Table.AddNewRecord.EndEdit()
                                    End If


                                ElseIf i.GetValue("descripcion") = "SEGURO" Then

                                    If txtSeguro.Value > 0 Then
                                        Me.dgvPrestamoRO.Table.AddNewRecord.SetCurrent()
                                        Me.dgvPrestamoRO.Table.AddNewRecord.BeginEdit()
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("idCuota", cuota)
                                        ' Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", "Cuota nro. " & cuota)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", cuota)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("descripcion", "SEGURO")
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montomn", Format(Math.Round(CDec(txtSeguro.Value), 2), "#,###,###,#0.00"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montome", Format(Math.Round(CDec(txtSeguroME.Value), 2), "#,###,###,#0.00"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaVct", fechaModo)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaPlazo", fechaAux)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuenta", i.GetValue("cuenta"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaH", i.GetValue("cuentaH"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDev", i.GetValue("cuentaDev"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDevH", i.GetValue("cuentaDevH"))
                                        Me.dgvPrestamoRO.Table.AddNewRecord.EndEdit()
                                    End If





                                Else


                                    If Not i.GetValue("estado") = "N" Then
                                        Me.dgvPrestamoRO.Table.AddNewRecord.SetCurrent()
                                        Me.dgvPrestamoRO.Table.AddNewRecord.BeginEdit()
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("idCuota", cuota)
                                        ' Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", "Cuota nro. " & cuota)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", cuota)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("descripcion", i.GetValue("descripcion"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montomn", Format(Math.Round(CDec(i.GetValue("valor")), 2), "#,###,###,#0.00"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montome", Format(Math.Round(CDec(CDec(i.GetValue("valor")) / txtTipoCambio.Value), 2), "#,###,###,#0.00"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaVct", fechaModo)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaPlazo", fechaAux)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuenta", i.GetValue("cuenta"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaH", i.GetValue("cuentaH"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDev", i.GetValue("cuentaDev"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDevH", i.GetValue("cuentaDevH"))
                                        Me.dgvPrestamoRO.Table.AddNewRecord.EndEdit()
                                        Me.dgvPrestamoRO.Table.AddNewRecord.SetCurrent()
                                    End If



                                End If
                            Next

                        ElseIf cboModo.Text = "QUINCENAL" Then

                            fechaModo2 = fechaModo2.AddDays(15)
                            fechaModo2 = fechaModo2
                            fechaAux = fechaModo2.AddDays(CInt(cbodiaplazo.Text))


                            Me.dgvPrestamoRO.Table.AddNewRecord.SetCurrent()
                            Me.dgvPrestamoRO.Table.AddNewRecord.BeginEdit()
                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("idCuota", cuota)
                            'Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", "Cuota nro. " & cuota)
                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", cuota)
                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("descripcion", "CAPITAL")
                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montomn", Format(Math.Round(CDec(txtCapital.Value), 2), "#,###,###,#0.00"))
                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montome", Format(Math.Round(CDec(txtCapitalme.Value), 2), "#,###,###,#0.00"))
                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaVct", fechaModo2)
                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaPlazo", fechaAux)
                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuenta", "NO")
                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaH", "NO")
                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDev", "NO")
                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDevH", "NO")
                            Me.dgvPrestamoRO.Table.AddNewRecord.EndEdit()

                            For Each i As Record In dgvConceptos2.Table.Records
                                If i.GetValue("descripcion") = "INTERES" Then
                                    If txtInteresMN.Value > 0 Then
                                        Me.dgvPrestamoRO.Table.AddNewRecord.SetCurrent()
                                        Me.dgvPrestamoRO.Table.AddNewRecord.BeginEdit()
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("idCuota", cuota)
                                        'Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", "Cuota nro. " & cuota)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", cuota)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("descripcion", "INTERES")
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montomn", Format(Math.Round(CDec(txtInteresMN.Value), 2), "#,###,###,#0.00"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montome", Format(Math.Round(CDec(txtInteresME.Value), 2), "#,###,###,#0.00"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaVct", fechaModo2)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaPlazo", fechaAux)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuenta", i.GetValue("cuenta"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaH", i.GetValue("cuentaH"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDev", i.GetValue("cuentaDev"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDevH", i.GetValue("cuentaDevH"))
                                        Me.dgvPrestamoRO.Table.AddNewRecord.EndEdit()
                                    End If


                                ElseIf i.GetValue("descripcion") = "SEGURO" Then

                                    If txtSeguro.Value > 0 Then
                                        Me.dgvPrestamoRO.Table.AddNewRecord.SetCurrent()
                                        Me.dgvPrestamoRO.Table.AddNewRecord.BeginEdit()
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("idCuota", cuota)
                                        ' Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", "Cuota nro. " & cuota)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", cuota)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("descripcion", "SEGURO")
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montomn", Format(Math.Round(CDec(txtSeguro.Value), 2), "#,###,###,#0.00"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montome", Format(Math.Round(CDec(txtSeguroME.Value), 2), "#,###,###,#0.00"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaVct", fechaModo2)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaPlazo", fechaAux)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuenta", i.GetValue("cuenta"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaH", i.GetValue("cuentaH"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDev", i.GetValue("cuentaDev"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDevH", i.GetValue("cuentaDevH"))
                                        Me.dgvPrestamoRO.Table.AddNewRecord.EndEdit()
                                    End If

                                Else
                                    If Not i.GetValue("estado") = "S" Then
                                        Me.dgvPrestamoRO.Table.AddNewRecord.SetCurrent()
                                        Me.dgvPrestamoRO.Table.AddNewRecord.BeginEdit()
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("idCuota", cuota)
                                        'Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", "Cuota nro. " & cuota)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", cuota)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("descripcion", i.GetValue("descripcion"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montomn", Format(Math.Round(CDec(i.GetValue("valor")), 2), "#,###,###,#0.00"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montome", Format(Math.Round(CDec(CDec(i.GetValue("valor")) / txtTipoCambio.Value), 2), "#,###,###,#0.00"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaVct", fechaModo)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaPlazo", fechaAux)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuenta", i.GetValue("cuenta"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaH", i.GetValue("cuentaH"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDev", i.GetValue("cuentaDev"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDevH", i.GetValue("cuentaDevH"))
                                        Me.dgvPrestamoRO.Table.AddNewRecord.EndEdit()
                                        Me.dgvPrestamoRO.Table.AddNewRecord.SetCurrent()
                                    End If
                                End If

                            Next

                            '//////77

                        ElseIf cboModo.Text = "SEMANAL" Then

                            fechaModo2 = fechaModo2.AddDays(7)
                            fechaModo2 = fechaModo2
                            fechaAux = fechaModo2.AddDays(CInt(cbodiaplazo.Text))

                            Me.dgvPrestamoRO.Table.AddNewRecord.SetCurrent()
                            Me.dgvPrestamoRO.Table.AddNewRecord.BeginEdit()
                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("idCuota", cuota)
                            ' Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", "Cuota nro. " & cuota)
                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", cuota)
                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("descripcion", "CAPITAL")
                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montomn", Format(Math.Round(CDec(txtCapital.Value), 2), "#,###,###,#0.00"))
                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montome", Format(Math.Round(CDec(txtCapitalme.Value), 2), "#,###,###,#0.00"))
                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaVct", fechaModo2)
                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaPlazo", fechaAux)
                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuenta", "NO")
                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaH", "NO")
                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDev", "NO")
                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDevH", "NO")
                            Me.dgvPrestamoRO.Table.AddNewRecord.EndEdit()

                            For Each i As Record In dgvConceptos2.Table.Records
                                If i.GetValue("descripcion") = "INTERES" Then
                                    If txtInteresMN.Value > 0 Then
                                        Me.dgvPrestamoRO.Table.AddNewRecord.SetCurrent()
                                        Me.dgvPrestamoRO.Table.AddNewRecord.BeginEdit()
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("idCuota", cuota)
                                        ' Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", "Cuota nro. " & cuota)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", cuota)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("descripcion", "INTERES")
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montomn", Format(Math.Round(CDec(txtInteresMN.Value), 2), "#,###,###,#0.00"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montome", Format(Math.Round(CDec(txtInteresME.Value), 2), "#,###,###,#0.00"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaVct", fechaModo2)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaPlazo", fechaAux)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuenta", i.GetValue("cuenta"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaH", i.GetValue("cuentaH"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDev", i.GetValue("cuentaDev"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDevH", i.GetValue("cuentaDevH"))
                                        Me.dgvPrestamoRO.Table.AddNewRecord.EndEdit()
                                    End If

                                ElseIf i.GetValue("descripcion") = "SEGURO" Then

                                    If txtSeguro.Value > 0 Then
                                        Me.dgvPrestamoRO.Table.AddNewRecord.SetCurrent()
                                        Me.dgvPrestamoRO.Table.AddNewRecord.BeginEdit()
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("idCuota", cuota)
                                        'Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", "Cuota nro. " & cuota)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", cuota)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("descripcion", "SEGURO")
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montomn", Format(Math.Round(CDec(txtSeguro.Value), 2), "#,###,###,#0.00"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montome", Format(Math.Round(CDec(txtSeguroME.Value), 2), "#,###,###,#0.00"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaVct", fechaModo2)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaPlazo", fechaAux)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuenta", i.GetValue("cuenta"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaH", i.GetValue("cuentaH"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDev", i.GetValue("cuentaDev"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDevH", i.GetValue("cuentaDevH"))
                                        Me.dgvPrestamoRO.Table.AddNewRecord.EndEdit()
                                    End If

                                Else

                                    If Not i.GetValue("estado") = "S" Then
                                        Me.dgvPrestamoRO.Table.AddNewRecord.SetCurrent()
                                        Me.dgvPrestamoRO.Table.AddNewRecord.BeginEdit()
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("idCuota", cuota)
                                        ' Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", "Cuota nro. " & cuota)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", cuota)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("descripcion", i.GetValue("descripcion"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montomn", Format(Math.Round(CDec(i.GetValue("valor")), 2), "#,###,###,#0.00"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montome", Format(Math.Round(CDec(CDec(i.GetValue("valor")) / txtTipoCambio.Value), 2), "#,###,###,#0.00"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaVct", fechaModo)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaPlazo", fechaAux)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuenta", i.GetValue("cuenta"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaH", i.GetValue("cuentaH"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDev", i.GetValue("cuentaDev"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDevH", i.GetValue("cuentaDevH"))
                                        Me.dgvPrestamoRO.Table.AddNewRecord.EndEdit()
                                        Me.dgvPrestamoRO.Table.AddNewRecord.SetCurrent()
                                    End If
                                End If

                            Next

                            '//////77


                        ElseIf cboModo.Text = "DIARIO" Then

                            fechaModo2 = fechaModo2.AddDays(1)
                            fechaModo2 = fechaModo2
                            fechaAux = fechaModo2.AddDays(CInt(cbodiaplazo.Text))

                            Me.dgvPrestamoRO.Table.AddNewRecord.SetCurrent()
                            Me.dgvPrestamoRO.Table.AddNewRecord.BeginEdit()
                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("idCuota", cuota)
                            'Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", "Cuota nro. " & cuota)
                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", cuota)
                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("descripcion", "CAPITAL")
                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montomn", Format(Math.Round(CDec(txtCapital.Value), 2), "#,###,###,#0.00"))
                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montome", Format(Math.Round(CDec(txtCapitalme.Value), 2), "#,###,###,#0.00"))
                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaVct", fechaModo2)
                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaPlazo", fechaAux)
                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuenta", "NO")
                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaH", "NO")
                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDev", "NO")
                            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDevH", "NO")
                            Me.dgvPrestamoRO.Table.AddNewRecord.EndEdit()

                            For Each i As Record In dgvConceptos2.Table.Records
                                If i.GetValue("descripcion") = "INTERES" Then
                                    If txtInteresMN.Value > 0 Then
                                        Me.dgvPrestamoRO.Table.AddNewRecord.SetCurrent()
                                        Me.dgvPrestamoRO.Table.AddNewRecord.BeginEdit()
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("idCuota", cuota)
                                        'Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", "Cuota nro. " & cuota)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", cuota)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("descripcion", "INTERES")
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montomn", Format(Math.Round(CDec(txtInteresMN.Value), 2), "#,###,###,#0.00"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montome", Format(Math.Round(CDec(txtInteresME.Value), 2), "#,###,###,#0.00"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaVct", fechaModo2)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaPlazo", fechaAux)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuenta", i.GetValue("cuenta"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaH", i.GetValue("cuentaH"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDev", i.GetValue("cuentaDev"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDevH", i.GetValue("cuentaDevH"))
                                        Me.dgvPrestamoRO.Table.AddNewRecord.EndEdit()
                                    End If




                                ElseIf i.GetValue("descripcion") = "SEGURO" Then

                                    If txtSeguro.Value > 0 Then
                                        Me.dgvPrestamoRO.Table.AddNewRecord.SetCurrent()
                                        Me.dgvPrestamoRO.Table.AddNewRecord.BeginEdit()
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("idCuota", cuota)
                                        ' Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", "Cuota nro. " & cuota)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", cuota)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("descripcion", "SEGURO")
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montomn", Format(Math.Round(CDec(txtSeguro.Value), 2), "#,###,###,#0.00"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montome", Format(Math.Round(CDec(txtSeguroME.Value), 2), "#,###,###,#0.00"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaVct", fechaModo2)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaPlazo", fechaAux)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuenta", i.GetValue("cuenta"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaH", i.GetValue("cuentaH"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDev", i.GetValue("cuentaDev"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDevH", i.GetValue("cuentaDevH"))
                                        Me.dgvPrestamoRO.Table.AddNewRecord.EndEdit()
                                    End If

                                Else

                                    If Not i.GetValue("estado") = "S" Then
                                        Me.dgvPrestamoRO.Table.AddNewRecord.SetCurrent()
                                        Me.dgvPrestamoRO.Table.AddNewRecord.BeginEdit()
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("idCuota", cuota)
                                        'Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", "Cuota nro. " & cuota)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", cuota)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("descripcion", i.GetValue("descripcion"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montomn", Format(Math.Round(CDec(i.GetValue("valor")), 2), "#,###,###,#0.00"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montome", Format(Math.Round(CDec(CDec(i.GetValue("valor")) / txtTipoCambio.Value), 2), "#,###,###,#0.00"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaVct", fechaModo)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaPlazo", fechaAux)
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuenta", i.GetValue("cuenta"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaH", i.GetValue("cuentaH"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDev", i.GetValue("cuentaDev"))
                                        Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuentaDevH", i.GetValue("cuentaDevH"))
                                        Me.dgvPrestamoRO.Table.AddNewRecord.EndEdit()
                                        Me.dgvPrestamoRO.Table.AddNewRecord.SetCurrent()
                                    End If
                                End If

                            Next

                            '//////77

                        End If

                    Next

                Else

                    lblEstado.Text = "Ingrese un monto mayor 0"
                    txtCuotas.Value = CDec(0)
                End If

            Else
                lblEstado.Text = "Ingrese un tipo de cambio"
                txtCuotas.Value = CDec(0)

            End If
        End If

        montoPorConcepto()


    End Sub



    Public Sub montoPorConcepto()
        lstConceptos.Items.Clear()

        If Not IsNothing(Me.dgvPrestamoRO.Table.CurrentRecord) Then
            Dim serv As New List(Of servicio)
            Dim objserv As New servicio
            Dim montoInt As Decimal = CDec(0.0)
            Dim montoCap As Decimal = CDec(0.0)
            Dim montoCapme As Decimal = CDec(0.0)
            Dim montoInteres As Decimal = CDec(0.0)
            Dim montoInteresme As Decimal = CDec(0.0)
            Dim montoSeguro As Decimal = CDec(0.0)
            Dim montoSegurome As Decimal = CDec(0.0)
            Dim diferencia As Decimal = CDec(0.0)
            Dim diferenciame As Decimal = CDec(0.0)

            For Each h As Record In dgvPrestamoRO.Table.Records
                objserv = New servicio

                If h.GetValue("descripcion") = "CAPITAL" Then
                    montoCap += h.GetValue("montomn")
                    montoCapme += h.GetValue("montome")
                ElseIf h.GetValue("descripcion") = "INTERES" Then
                    montoInteres += h.GetValue("montomn")
                    montoInteresme += h.GetValue("montome")
                ElseIf h.GetValue("descripcion") = "SEGURO" Then
                    montoSeguro += h.GetValue("montomn")
                    montoSegurome += h.GetValue("montome")
                End If



                If h.GetValue("cuota") = txtCuotas.Value Then
                    'ULTYIM,OPOO
                    If h.GetValue("descripcion") = "CAPITAL" Then
                        If txtImporteCompramn.Value = montoCap Then
                            objserv.descripcion = h.GetValue("descripcion")
                            objserv.valor = h.GetValue("montomn")
                        ElseIf txtImporteCompramn.Value > montoCap Then
                            diferencia = txtImporteCompramn.Value - montoCap
                            Dim nuevovalor As Decimal = ((h.GetValue("montomn")) + diferencia)
                            h.SetValue("montomn", nuevovalor)
                            objserv.descripcion = h.GetValue("descripcion")
                            objserv.valor = nuevovalor

                        ElseIf txtImporteCompramn.Value < montoCap Then
                            diferencia = montoCap - txtImporteCompramn.Value
                            Dim nuevovalor As Decimal = ((h.GetValue("montomn")) - diferencia)
                            h.SetValue("montomn", nuevovalor)
                            objserv.descripcion = h.GetValue("descripcion")
                            objserv.valor = nuevovalor
                        End If
                        'dolares 
                        If txtImporteComprame.Value = montoCapme Then
                            objserv.valorme = h.GetValue("montome")
                        ElseIf txtImporteComprame.Value > montoCapme Then
                            diferenciame = txtImporteComprame.Value - montoCapme
                            Dim nuevovalor As Decimal = ((h.GetValue("montome")) + diferenciame)
                            h.SetValue("montome", nuevovalor)
                            objserv.valorme = nuevovalor

                        ElseIf txtImporteComprame.Value < montoCapme Then
                            diferenciame = montoCapme - txtImporteComprame.Value
                            Dim nuevovalor As Decimal = ((h.GetValue("montome")) - diferenciame)
                            h.SetValue("montome", nuevovalor)
                            objserv.valorme = nuevovalor
                        End If



                    ElseIf h.GetValue("descripcion") = "INTERES" Then
                        If txtInteresMonto.Value = montoInteres Then
                            objserv.descripcion = h.GetValue("descripcion")
                            objserv.valor = h.GetValue("montomn")
                        ElseIf txtInteresMonto.Value > montoInteres Then
                            diferencia = txtInteresMonto.Value - montoInteres
                            Dim nuevovalor As Decimal = ((h.GetValue("montomn")) + diferencia)
                            h.SetValue("montomn", nuevovalor)
                            objserv.descripcion = h.GetValue("descripcion")
                            objserv.valor = nuevovalor
                        ElseIf txtInteresMonto.Value < montoInteres Then
                            diferencia = montoInteres - txtInteresMonto.Value
                            Dim nuevovalor As Decimal = ((h.GetValue("montomn")) - diferencia)
                            h.SetValue("montomn", nuevovalor)
                            objserv.descripcion = h.GetValue("descripcion")
                            objserv.valor = nuevovalor
                        End If
                        'dolares
                        If txtInteresMontome.Value = montoInteresme Then
                            objserv.valorme = h.GetValue("montome")
                        ElseIf txtInteresMontome.Value > montoInteresme Then
                            diferenciame = txtInteresMontome.Value - montoInteresme
                            Dim nuevovalor As Decimal = ((h.GetValue("montome")) + diferenciame)
                            h.SetValue("montome", nuevovalor)
                            objserv.valorme = nuevovalor
                        ElseIf txtInteresMontome.Value < montoInteresme Then
                            diferenciame = montoInteresme - txtInteresMontome.Value
                            Dim nuevovalor As Decimal = ((h.GetValue("montome")) - diferenciame)
                            h.SetValue("montome", nuevovalor)
                            objserv.valorme = nuevovalor
                        End If


                    ElseIf h.GetValue("descripcion") = "SEGURO" Then
                        If txtSeguroMonto.Value = montoSeguro Then
                            objserv.descripcion = h.GetValue("descripcion")
                            objserv.valor = h.GetValue("montomn")
                        ElseIf txtSeguroMonto.Value > montoSeguro Then
                            diferencia = txtSeguroMonto.Value - montoSeguro
                            Dim nuevovalor As Decimal = ((h.GetValue("montomn")) + diferencia)
                            h.SetValue("montomn", nuevovalor)
                            objserv.descripcion = h.GetValue("descripcion")
                            objserv.valor = nuevovalor
                        ElseIf txtSeguroMonto.Value < montoSeguro Then
                            diferencia = montoSeguro - txtSeguroMonto.Value
                            Dim nuevovalor As Decimal = ((h.GetValue("montomn")) - diferencia)
                            h.SetValue("montomn", nuevovalor)
                            objserv.descripcion = h.GetValue("descripcion")
                            objserv.valor = nuevovalor
                        End If
                        'dolares 
                        If txtSeguroMontome.Value = montoSegurome Then
                            objserv.valorme = h.GetValue("montome")
                        ElseIf txtSeguroMontome.Value > montoSegurome Then
                            diferenciame = txtSeguroMontome.Value - montoSegurome
                            Dim nuevovalor As Decimal = ((h.GetValue("montome")) + diferenciame)
                            h.SetValue("montome", nuevovalor)
                            objserv.valorme = nuevovalor
                        ElseIf txtSeguroMontome.Value < montoSegurome Then
                            diferenciame = montoSegurome - txtSeguroMontome.Value
                            Dim nuevovalor As Decimal = ((h.GetValue("montome")) - diferenciame)
                            h.SetValue("montome", nuevovalor)
                            objserv.valorme = nuevovalor
                        End If
                    Else

                        objserv.descripcion = h.GetValue("descripcion")
                        objserv.valor = h.GetValue("montomn")
                        objserv.valorme = h.GetValue("montome")
                    End If


                Else

                    objserv.descripcion = h.GetValue("descripcion")
                    objserv.valor = h.GetValue("montomn")
                    objserv.valorme = h.GetValue("montome")
                End If

                'montotot += h.GetValue("montomn")
                serv.Add(objserv)
            Next

            'Dim consulta = (From n In serv _
            '                Group By n.descripcion _
            '                Into g = Group _
            '                 Select New With {
            '                     .descripcion = descripcion,
            '                      .valor = g.Sum(Function(cab) cab.valor)
            '                     }).tolist
            Dim consulta = (From n In serv _
                           Group By n.descripcion _
                           Into g = Group _
                            Select New With {
                                .descripcion = descripcion,
                                 .valor = g.Sum(Function(cab) cab.valor),
                                .valorme = g.Sum(Function(cab) cab.valorme)
                                }).tolist


            For Each i In consulta

                Dim n As New ListViewItem(1)
                n.SubItems.Add(i.descripcion)
                n.SubItems.Add(i.valor)
                n.SubItems.Add(i.valorme)
                If Not i.descripcion = "CAPITAL" Then
                    montoInt += i.valor
                End If
                lstConceptos.Items.Add(n)
            Next
            txtInteresTotal.Value = montoInt
            'For Each i In consulta

            '    Dim n As New ListViewItem(1)
            '    n.SubItems.Add(i.descripcion)
            '    n.SubItems.Add(i.valor)
            '    If Not i.descripcion = "CAPITAL" Then
            '        montoInt += i.valor
            '    End If

            '    lstConceptos.Items.Add(n)
            'Next
            'txtInteresTotal.Value = montoInt
        End If
    End Sub



    Private Sub cboDiaPago_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDiaPago.SelectedIndexChanged
        If txtCuotas.Value > 0 Then
            Cuotas()
        End If

    End Sub


    Private Sub cboModo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboModo.SelectedIndexChanged
        If cboModo.Text = "MENSUAL" Then

            Label24.Visible = True
            cboDiaPago.Visible = True

        ElseIf cboModo.Text = "QUINCENAL" Then

            Label24.Visible = False
            cboDiaPago.Visible = False

        ElseIf cboModo.Text = "SEMANAL" Then

            Label24.Visible = False
            cboDiaPago.Visible = False

        ElseIf cboModo.Text = "DIARIO" Then

            Label24.Visible = False
            cboDiaPago.Visible = False

        End If

        If txtCuotas.Value > 0 Then
            Cuotas()
        End If
    End Sub

    Private Sub cbodiaplazo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbodiaplazo.SelectedIndexChanged

        If txtCuotas.Value > 0 Then
            Cuotas()
        End If

    End Sub

    Private Sub DateTimePickerAdv2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerAdv2.ValueChanged

        If IsDate(DateTimePickerAdv2.Value) Then
            If txtCuotas.Value > 0 Then
                Cuotas()
            End If
        Else

        End If

    End Sub






    Private Sub txtFechaComprobante_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaComprobante.ValueChanged

    End Sub

    Private Sub txtImporteComprame_ValueChanged(sender As Object, e As EventArgs) Handles txtImporteComprame.ValueChanged
        txtTipoCambio_ValueChanged(sender, e)
        txtPorcIneteres_ValueChanged(sender, e)
    End Sub

    Private Sub txtInteresME_ValueChanged(sender As Object, e As EventArgs) Handles txtInteresME.ValueChanged

    End Sub

    Private Sub txtInteresMN_ValueChanged(sender As Object, e As EventArgs) Handles txtInteresMN.ValueChanged

    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        If lsvProveedor.SelectedItems.Count > 0 Then
            Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
        End If
    End Sub


    Private Sub lsvProveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvProveedor.SelectedIndexChanged

    End Sub


    Private Sub popupControlContainer1_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles popupControlContainer1.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                Me.txtProveedor.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                txtProveedor.Tag = lsvProveedor.SelectedItems(0).SubItems(0).Text
                txtRuc.Text = lsvProveedor.SelectedItems(0).SubItems(3).Text
                txtCuenta = lsvProveedor.SelectedItems(0).SubItems(2).Text
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
    End Sub

    Private Sub txtProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Me.popupControlContainer1.ParentControl = Me.txtProveedor
            Me.popupControlContainer1.ShowPopup(Point.Empty)
            If chProv.Checked = True Then
                CargarEntidadesXtipo(TIPO_ENTIDAD.PROVEEDOR, txtProveedor.Text.Trim)
            ElseIf chTrab.Checked = True Then
                CargarTrabajadoresXnivel("TR", txtProveedor.Text.Trim)
            ElseIf chCli.Checked = True Then

                CargarEntidadesXtipo(TIPO_ENTIDAD.CLIENTE, txtProveedor.Text.Trim)
            End If
        End If
    End Sub


    Private Sub txtProveedor_TextChanged(sender As Object, e As EventArgs) Handles txtProveedor.TextChanged

    End Sub

    Private Sub chTrab_Click(sender As Object, e As EventArgs) Handles chTrab.Click

        chProv.Checked = False
        chTrab.Checked = True
        chCli.Checked = False
        txtProveedor.Clear()
        txtRuc.Clear()

    End Sub

    Private Sub chCli_Click(sender As Object, e As EventArgs) Handles chCli.Click
        chProv.Checked = False
        chTrab.Checked = False
        chCli.Checked = True
        txtProveedor.Clear()
        txtRuc.Clear()
    End Sub

    Private Sub txtporcseg_ValueChanged(sender As Object, e As EventArgs) Handles txtporcseg.ValueChanged

        If txtCuotas.Value > 0 Then
            Cuotas()
        End If
    End Sub

    Private Sub chProv_Click(sender As Object, e As EventArgs) Handles chProv.Click
        chProv.Checked = True
        chTrab.Checked = False
        chCli.Checked = False
        txtProveedor.Clear()
        txtRuc.Clear()
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        If chProv.Checked = True Then
            Dim f As New frmCrearENtidades
            f.CaptionLabels(0).Text = "Nuevo proveedor"
            f.strTipo = TIPO_ENTIDAD.PROVEEDOR
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        End If

        If chCli.Checked = True Then
            Dim f As New frmCrearENtidades
            f.CaptionLabels(0).Text = "Nuevo Cliente"
            f.strTipo = TIPO_ENTIDAD.CLIENTE
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        End If

        If chTrab.Checked = True Then
            With FrmNuevaPersona
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        End If
    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click


        Dim cap As Decimal
        cap = 0
        For Each i As Record In dgvPrestamoRO.Table.Records
            If i.GetValue("descripcion") = "CAPITAL" Then
                cap += i.GetValue("montomn")
            End If
        Next

        If Not cap = txtImporteCompramn.Value Then
            'Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montomn", 0)
            MessageBox.Show("El Monto Capital no cuadra")
            Exit Sub
        End If


        If Not txtProveedor.Text.Trim.Length > 0 Then
            MessageBox.Show("Ingrese un Beneficiario")
            Exit Sub
        End If

        If Not (txtImporteCompramn.Value > 0) Then
            MessageBox.Show("Debe ingresa un importe mayor a 0")
            Exit Sub
        End If

        If Not txtTipoCambio.Value > 0 Then
            MessageBox.Show("el tipo de cambio debe ser mayor a 0 ")
            Exit Sub
        End If
        If Not txtPorcIneteres.Value >= 0 Then
            MessageBox.Show("Ingrese un Interes")
            Exit Sub
        End If


        If Not cboModo.SelectedIndex > -1 Then
            MessageBox.Show("especificar modo de pago")
            Exit Sub
        End If

        If cboModo.Text = "MENSUAL" Then
            If Not cboDiaPago.SelectedIndex > -1 Then
                MessageBox.Show("especificar el dia de pago")
                Exit Sub
            End If
        End If

        If Not cbodiaplazo.SelectedIndex > -1 Then
            MessageBox.Show("no se ingreso el perido de gracia")
            Exit Sub
        End If
        If Not txtCuotas.Value > 0 Then
            MessageBox.Show("el numero de cuotas debe ser mayo a 0")
            Exit Sub
        End If


        SavePrestamo()
    End Sub

    Private Sub btnConfiguracion_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtportes_ValueChanged(sender As Object, e As EventArgs)
        If txtCuotas.Value > 0 Then
            Cuotas()
        End If
    End Sub

    Private Sub txtenviocuenta_ValueChanged(sender As Object, e As EventArgs)
        If txtCuotas.Value > 0 Then
            Cuotas()
        End If
    End Sub

    Private Sub dgvConceptos_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvConceptos.TableControlCellClick

    End Sub

    Private Sub dgvConceptos_TableControlCellMouseHoverLeave(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvConceptos.TableControlCellMouseHoverLeave

    End Sub

    Private chk As Boolean, check As Boolean = False
    Private ht As New ArrayList()
    Private Sub dgvConceptos_TableControlCheckBoxClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvConceptos.TableControlCheckBoxClick
     
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            dgvPrestamoRO.TableDescriptor.GroupedColumns.Clear()

            dgvPrestamoRO.TableDescriptor.Columns("idDocumento").ReadOnly = True
            dgvPrestamoRO.TableDescriptor.Columns("idCuota").ReadOnly = True
            dgvPrestamoRO.TableDescriptor.Columns("secuencia").ReadOnly = True
            dgvPrestamoRO.TableDescriptor.Columns("cuota").ReadOnly = True
            dgvPrestamoRO.TableDescriptor.Columns("descripcion").ReadOnly = True
            dgvPrestamoRO.TableDescriptor.Columns("montomn").ReadOnly = False
            dgvPrestamoRO.TableDescriptor.Columns("montome").ReadOnly = True
            dgvPrestamoRO.TableDescriptor.Columns("FechaVct").ReadOnly = True
            dgvPrestamoRO.TableDescriptor.Columns("FechaPlazo").ReadOnly = True

        ElseIf CheckBox1.Checked = False Then
            dgvPrestamoRO.ShowGroupDropArea = False
            dgvPrestamoRO.TableDescriptor.GroupedColumns.Clear()
            dgvPrestamoRO.TableDescriptor.GroupedColumns.Add("cuota")

            dgvPrestamoRO.TableDescriptor.Columns("idDocumento").ReadOnly = True
            dgvPrestamoRO.TableDescriptor.Columns("idCuota").ReadOnly = True
            dgvPrestamoRO.TableDescriptor.Columns("secuencia").ReadOnly = True
            dgvPrestamoRO.TableDescriptor.Columns("cuota").ReadOnly = True
            dgvPrestamoRO.TableDescriptor.Columns("descripcion").ReadOnly = True
            dgvPrestamoRO.TableDescriptor.Columns("montomn").ReadOnly = True
            dgvPrestamoRO.TableDescriptor.Columns("montome").ReadOnly = True
            dgvPrestamoRO.TableDescriptor.Columns("FechaVct").ReadOnly = True
            dgvPrestamoRO.TableDescriptor.Columns("FechaPlazo").ReadOnly = True

        End If
    End Sub

    Private Sub dgvPrestamoRO_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvPrestamoRO.QueryCellStyleInfo
        If e.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell OrElse e.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell Then
            If e.TableCellIdentity.Column.Name = "FechaVct" Then
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

    Private Sub dgvPrestamoRO_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvPrestamoRO.TableControlCellClick

    End Sub

    Private Sub dgvPrestamoRO_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvPrestamoRO.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        If Not IsNothing(Me.dgvPrestamoRO.Table.CurrentRecord) Then
            Select ColIndex
                Case 6 ' capital

                    Dim colCapitalME As Decimal = 0
                    colCapitalME = Math.Round(CDec(Me.dgvPrestamoRO.Table.CurrentRecord.GetValue("montomn")) / CDec(txtTipoCambio.Value), 2)
                    Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montome", colCapitalME)

                    montoPorConcepto()

            End Select

        End If
    End Sub

   

    Private Sub dgvConceptos_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvConceptos.TableControlCurrentCellEditingComplete
       
    End Sub

   


    Private Sub cbotipoprestamo_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub cboTipoPR_Click(sender As Object, e As EventArgs) Handles cboTipoPR.Click

    End Sub

    Private Sub cboTipoPR_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoPR.SelectedIndexChanged
        If cboTipoPR.Text.Trim.Length > 0 Then
            txtNombrePrestamo.Text = cboTipoPR.Text
            TextBox1.Text = cboTipoPR.Text
            ListarConceptosPrestamos(cboTipoPR.SelectedValue)
        End If


        'Dim cod = cboTipoPR.SelectedValue
        'If cboTipoPR.Text.Trim.Length > 0 Then
        '    If IsNumeric(cod) Then
        '        Dim con = (From n In lista _
        '              Where n.idServicio = cboTipoPR.SelectedValue).FirstOrDefault

        '        If Not IsNothing(con) Then

        '            txtCuentaTipo.Text = con.cuenta
        '            txtNombrePrestamo.Text = con.descripcion
        '            '  txttip1.Text = (DirectCast(Me.cboTipoPR.SelectedItem, Categoria).tipo)
        '            ListarConceptosPrestamos(con.idServicio)
        '        End If
        '    End If
        'End If
    End Sub

  


   
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()

        Dim f As New frmNuevoTipoPrestamo
        f.StartPosition = FormStartPosition.CenterParent
        f.txtTipoPrestamo.Text = "PO"
        f.Tag = ENTITY_ACTIONS.INSERT

        f.ShowDialog()
        ListaTipoPrestamos()

        If datos.Count > 0 Then
            'cboTipoPR.ValueMember = datos(0).ID
            'cboTipoPR.SelectedValue = datos(0).ID

            Me.cboTipoPR.SelectedValue = datos(0).ID
        End If
        'ListarConceptosPrestamos("CON")

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If cboTipoPR.Text.Trim.Length Then
            If DirectCast(Me.cboTipoPR.SelectedItem, Categoria).Id > 0 Then

                Dim f As New frmNuevoTipoPrestamo
                f.StartPosition = FormStartPosition.CenterParent
                f.Tag = ENTITY_ACTIONS.UPDATE
                f.txtidservicio.Text = DirectCast(Me.cboTipoPR.SelectedItem, Categoria).Id
                f.txtServicioNew.Text = cboTipoPR.Text
                f.txtObservaciones.Visible = False
                f.txtServicioNew.ReadOnly = True
               
                f.Label2.Visible = False
                f.ShowDialog()

                ListaTipoPrestamos()
                Me.Cursor = Cursors.Arrow

            End If
        Else
            MessageBox.Show("Seleccione un Tipo de Prestamo")
        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        If txtDevengado.Tag > 0 Then

            Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
            datos.Clear()

            Dim f As New frmNuevoConceptoPrestamo
            f.Tag = ENTITY_ACTIONS.UPDATE
            'f.lblidconcepto.Text = txtDevengado.Tag
            f.txtTipoPrestamo.Text = "PO"
            f.txtDescripcion.Text = "DESEMBOLSO"
            f.txtDescripcion.ReadOnly = True
            f.Label5.Visible = False
            f.Label9.Visible = False
            f.Label8.Visible = False
            f.txtDevengado.Visible = False
            f.txtDevengadoH.Visible = False
            f.txtCuentaH.ReadOnly = True
            f.Label3.Visible = False
            f.txtvalor.Visible = False

            f.txtCuenta.Text = txtDevengado.Text
            f.txtCuenta.Tag = txtDevengado.Text
            f.txtCuentaH.Text = txtDevengadoH.Text
            f.txtCuentaH.Tag = txtDevengadoH.Text
            f.lblidconcepto.Text = txtDevengado.Tag
            f.ShowDialog()

            'If datos.Count > 0 Then
            '    'cboTipoPR.ValueMember = datos(0).ID
            '    'cboTipoPR.SelectedValue = datos(0).ID
            '    Me.txtDevengado.Text = datos(0).Cuenta
            'End If

            If cboTipoPR.Text.Trim.Length > 0 Then
                ListarConceptosPrestamos(cboTipoPR.SelectedValue)
            End If


            'PrestamosDesembolsoAptos("POT")
            Me.Cursor = Cursors.Arrow
        Else
            MessageBox.Show("Seleccione un Tipo de Prestamo")
        End If
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        If Not IsNothing(Me.dgvConceptos.Table.CurrentRecord) Then

            Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
            datos.Clear()

            Dim f As New frmNuevoConceptoPrestamo
            f.Tag = ENTITY_ACTIONS.UPDATE
            f.txtDevengado.ReadOnly = True
            f.txtTipoPrestamo.Text = "PO"
            f.lblidconcepto.Text = Me.dgvConceptos.Table.CurrentRecord.GetValue("idServicio")
            f.txtDescripcion.Text = Me.dgvConceptos.Table.CurrentRecord.GetValue("descripcion")
            If Me.dgvConceptos.Table.CurrentRecord.GetValue("descripcion") = "INTERES" Then
                f.txtDescripcion.ReadOnly = True
                f.Label3.Text = "Porcentaje:"
            ElseIf Me.dgvConceptos.Table.CurrentRecord.GetValue("descripcion") = "SEGURO" Then
                f.txtDescripcion.ReadOnly = True
                f.Label3.Text = "Porcentaje:"
            End If
            f.txtCuenta.Text = Me.dgvConceptos.Table.CurrentRecord.GetValue("cuenta")
            f.txtCuenta.Tag = Me.dgvConceptos.Table.CurrentRecord.GetValue("cuenta")
            f.txtCuentaH.Text = Me.dgvConceptos.Table.CurrentRecord.GetValue("cuentaH")
            f.txtCuentaH.Tag = Me.dgvConceptos.Table.CurrentRecord.GetValue("cuentaH")
            f.txtDevengado.Text = Me.dgvConceptos.Table.CurrentRecord.GetValue("cuentaDev")
            f.txtDevengado.Tag = Me.dgvConceptos.Table.CurrentRecord.GetValue("cuentaDev")
            f.txtDevengadoH.Text = Me.dgvConceptos.Table.CurrentRecord.GetValue("cuentaDevH")
            f.txtDevengadoH.Tag = Me.dgvConceptos.Table.CurrentRecord.GetValue("cuentaDevH")
            f.txtvalor.Value = Me.dgvConceptos.Table.CurrentRecord.GetValue("valor")
            f.txtvalor.Visible = False
            f.lblEditor.Text = "CUENTA"
            f.Label3.Visible = False
            f.ShowDialog()


            'If datos.Count > 0 Then
            '    'cboTipoPR.ValueMember = datos(0).ID
            '    'cboTipoPR.SelectedValue = datos(0).ID
            '    Me.dgvConceptos.Table.CurrentRecord.SetValue("cuenta", datos(0).Cuenta)
            '    Me.dgvConceptos.Table.CurrentRecord.SetValue("cuentaH", datos(0).CuentaH)
            '    Me.dgvConceptos.Table.CurrentRecord.SetValue("cuentaDev", datos(0).Devengado)
            '    Me.dgvConceptos.Table.CurrentRecord.SetValue("cuentaDevH", datos(0).DevengadoH)
            '    Me.dgvConceptos.Table.CurrentRecord.SetValue("valor", datos(0).Montomn)
            'End If

            If cboTipoPR.Text.Trim.Length > 0 Then
                ListarConceptosPrestamos(cboTipoPR.SelectedValue)
            End If

            'If cboTipoPR.Text.Trim.Length > 0 Then
            '    ListarConceptosPrestamos(DirectCast(Me.cboTipoPR.SelectedItem, Categoria).Id)
            'End If




            Me.Cursor = Cursors.Arrow
        Else

            MessageBox.Show("Seleccione un Item")
        End If
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        'If cboTipoPR.Text.Trim.Length > 0 Then

        '    Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        '    datos.Clear()

        '    Dim f As New frmNuevoConceptoPrestamo
        '    f.StartPosition = FormStartPosition.CenterParent
        '    f.Tag = ENTITY_ACTIONS.INSERT
        '    ' f.lblidpadre.Text = DirectCast(Me.cboTipoPR.SelectedItem, Categoria).Id
        '    f.lblidpadre.Text = Me.cboTipoPR.SelectedValue
        '    f.ShowDialog()


        '    If datos.Count > 0 Then
        '        'cboTipoPR.ValueMember = datos(0).ID
        '        'cboTipoPR.SelectedValue = datos(0).ID
        '        Me.dgvConceptos.Table.AddNewRecord.SetCurrent()
        '        Me.dgvConceptos.Table.AddNewRecord.BeginEdit()
        '        Me.dgvConceptos.Table.CurrentRecord.SetValue("idServicio", datos(0).ID)
        '        Me.dgvConceptos.Table.CurrentRecord.SetValue("descripcion", datos(0).NombreEntidad)
        '        Me.dgvConceptos.Table.CurrentRecord.SetValue("cuenta", datos(0).Cuenta)
        '        Me.dgvConceptos.Table.CurrentRecord.SetValue("cuentaH", datos(0).CuentaH)
        '        Me.dgvConceptos.Table.CurrentRecord.SetValue("cuentaDev", datos(0).Devengado)
        '        Me.dgvConceptos.Table.CurrentRecord.SetValue("cuentaDevH", datos(0).DevengadoH)
        '        Me.dgvConceptos.Table.CurrentRecord.SetValue("valor", datos(0).Montomn)
        '        Me.dgvConceptos.Table.CurrentRecord.SetValue("check", False)
        '        Me.dgvConceptos.Table.CurrentRecord.SetValue("estado", "N")
        '        Me.dgvConceptos.Table.CurrentRecord.SetValue("tipo", "Monto Fijo")
        '        'Me.dgvConceptos.Table.CurrentRecord.SetValue("tipoCuenta", "H")
        '        Me.dgvConceptos.Table.AddNewRecord.EndEdit()
        '    End If



        '    ' ListarConceptosPrestamos(DirectCast(Me.cboTipoPR.SelectedItem, Categoria).Id)


        '    Me.Cursor = Cursors.Arrow
        'Else
        '    MessageBox.Show("Seleccione un Tipo de Prestamo")
        'End If
    End Sub

    Private Sub GroupBox4_Enter(sender As Object, e As EventArgs) Handles GroupBox4.Enter

    End Sub

   
    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        If cboTipoPR.Text.Trim.Length > 0 Then
            ListarConceptosPrestamos(DirectCast(Me.cboTipoPR.SelectedItem, Categoria).Id)
        Else
            MessageBox.Show("Seleccione un Tipo de Prestamo")
        End If
    End Sub

   

    Private Sub dgvConceptos2_TableControlCheckBoxClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvConceptos2.TableControlCheckBoxClick
        Dim style As GridTableCellStyleInfo = DirectCast(e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex), GridTableCellStyleInfo)
        Dim el As Element = Me.dgvConceptos2.Table.GetInnerMostCurrentElement()

        Dim colindexVal As Integer = style.CellIdentity.ColIndex

        Dim RowIndex2 As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.RowIndex
        If RowIndex2 > -1 Then
            Select Case colindexVal

                Case 8

                    If style.Enabled Then
                        Dim column As Integer = Me.dgvConceptos2.TableModel.NameToColIndex("check")

                        If style.Enabled AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell Then
                            chk = CBool(Me.dgvConceptos2.TableModel(style.TableCellIdentity.RowIndex, column).CellValue)

                            e.TableControl.BeginUpdate()

                            e.TableControl.EndUpdate(True)
                        End If
                        If style.Enabled AndAlso (style.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell OrElse style.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) AndAlso style.TableCellIdentity.Column.Name = "check" Then
                            Dim currentRecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                            Dim curStatus As Boolean = Boolean.Parse(style.Text)
                            e.TableControl.BeginUpdate()

                            If curStatus Then
                                '   CheckBoxValue = False
                            End If
                            If curStatus = True Then
                                Dim RowIndex As Integer = e.Inner.RowIndex
                                Dim ColIndex As Integer = e.Inner.ColIndex

                                Me.dgvConceptos2.TableModel(RowIndex, 9).CellValue = "N"

                                Cuotas()

                            Else
                                Dim RowIndex As Integer = e.Inner.RowIndex
                                Dim ColIndex As Integer = e.Inner.ColIndex

                                Me.dgvConceptos2.TableModel(RowIndex, 9).CellValue = "S"

                                If Me.dgvConceptos2.TableModel(RowIndex, 2).CellValue = "INTERES" Then
                                    txtPorcIneteres.Value = Me.dgvConceptos2.TableModel(RowIndex, 4).CellValue

                                ElseIf Me.dgvConceptos2.TableModel(RowIndex, 2).CellValue = "SEGURO" Then
                                    txtporcseg.Value = Me.dgvConceptos2.TableModel(RowIndex, 4).CellValue
                                End If

                                Cuotas()

                            End If
                            e.TableControl.EndUpdate()
                            If ht.Contains(curStatus) AndAlso (Not ht.Contains((Not curStatus))) Then
                            ElseIf Not ht.Contains(curStatus) Then
                            End If
                            ht.Clear()
                        End If
                    End If

            End Select

            Me.dgvConceptos2.TableControl.Refresh()

        End If
    End Sub

    Private Sub dgvConceptos2_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvConceptos2.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        If Not IsNothing(Me.dgvConceptos2.Table.CurrentRecord) Then
            Select Case ColIndex
                Case 4 ' cantidad

                    If Me.dgvConceptos2.Table.CurrentRecord.GetValue("descripcion") = "INTERES" Then
                        txtPorcIneteres.Value = CDec(Me.dgvConceptos2.Table.CurrentRecord.GetValue("valor"))
                        Cuotas()


                    ElseIf Me.dgvConceptos2.Table.CurrentRecord.GetValue("descripcion") = "SEGURO" Then
                        txtporcseg.Value = CDec(Me.dgvConceptos2.Table.CurrentRecord.GetValue("valor"))
                        Cuotas()

                    Else

                        Cuotas()

                    End If

            End Select
        End If
    End Sub

    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click
        If cboTipoPR.Text.Trim.Length > 0 Then

            Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
            datos.Clear()

            Dim f As New frmNuevoConceptoPrestamo
            f.StartPosition = FormStartPosition.CenterParent
            f.txtTipoPrestamo.Text = "PO"
            f.Tag = ENTITY_ACTIONS.INSERT
            ' f.lblidpadre.Text = DirectCast(Me.cboTipoPR.SelectedItem, Categoria).Id
            f.lblidpadre.Text = Me.cboTipoPR.SelectedValue
            f.ShowDialog()


            'If datos.Count > 0 Then
            '    'cboTipoPR.ValueMember = datos(0).ID
            '    'cboTipoPR.SelectedValue = datos(0).ID
            '    Me.dgvConceptos2.Table.AddNewRecord.SetCurrent()
            '    Me.dgvConceptos2.Table.AddNewRecord.BeginEdit()
            '    Me.dgvConceptos2.Table.CurrentRecord.SetValue("idServicio", datos(0).ID)
            '    Me.dgvConceptos2.Table.CurrentRecord.SetValue("descripcion", datos(0).NombreEntidad)
            '    Me.dgvConceptos2.Table.CurrentRecord.SetValue("cuenta", datos(0).Cuenta)
            '    Me.dgvConceptos2.Table.CurrentRecord.SetValue("cuentaH", datos(0).CuentaH)
            '    Me.dgvConceptos2.Table.CurrentRecord.SetValue("cuentaDev", datos(0).Devengado)
            '    Me.dgvConceptos2.Table.CurrentRecord.SetValue("cuentaDevH", datos(0).DevengadoH)
            '    Me.dgvConceptos2.Table.CurrentRecord.SetValue("valor", datos(0).Montomn)
            '    Me.dgvConceptos2.Table.CurrentRecord.SetValue("check", False)
            '    Me.dgvConceptos2.Table.CurrentRecord.SetValue("estado", "N")
            '    Me.dgvConceptos2.Table.CurrentRecord.SetValue("tipo", "Monto Fijo")
            '    Me.dgvConceptos2.Table.AddNewRecord.EndEdit()

            '    Me.dgvConceptos.Table.AddNewRecord.SetCurrent()
            '    Me.dgvConceptos.Table.AddNewRecord.BeginEdit()
            '    Me.dgvConceptos.Table.CurrentRecord.SetValue("idServicio", datos(0).ID)
            '    Me.dgvConceptos.Table.CurrentRecord.SetValue("descripcion", datos(0).NombreEntidad)
            '    Me.dgvConceptos.Table.CurrentRecord.SetValue("cuenta", datos(0).Cuenta)
            '    Me.dgvConceptos.Table.CurrentRecord.SetValue("cuentaH", datos(0).CuentaH)
            '    Me.dgvConceptos.Table.CurrentRecord.SetValue("cuentaDev", datos(0).Devengado)
            '    Me.dgvConceptos.Table.CurrentRecord.SetValue("cuentaDevH", datos(0).DevengadoH)
            '    'Me.dgvConceptos2.Table.CurrentRecord.SetValue("valor", datos(0).Montomn)
            '    'Me.dgvConceptos2.Table.CurrentRecord.SetValue("check", False)
            '    'Me.dgvConceptos2.Table.CurrentRecord.SetValue("estado", "N")
            '    'Me.dgvConceptos2.Table.CurrentRecord.SetValue("tipo", "Monto Fijo")
            '    Me.dgvConceptos.Table.AddNewRecord.EndEdit()

            'End If

            If cboTipoPR.Text.Trim.Length > 0 Then
                ListarConceptosPrestamos(cboTipoPR.SelectedValue)
            End If


            ' ListarConceptosPrestamos(DirectCast(Me.cboTipoPR.SelectedItem, Categoria).Id)


            Me.Cursor = Cursors.Arrow
        Else
            MessageBox.Show("Seleccione un Tipo de Prestamo")
        End If
    End Sub

    Private Sub PictureBox11_Click(sender As Object, e As EventArgs) Handles PictureBox11.Click
        If Not IsNothing(Me.dgvConceptos2.Table.CurrentRecord) Then

            Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
            datos.Clear()

            Dim f As New frmNuevoConceptoPrestamo
            f.Tag = ENTITY_ACTIONS.UPDATE
            f.txtTipoPrestamo.Text = "PO"
            f.lblidconcepto.Text = Me.dgvConceptos2.Table.CurrentRecord.GetValue("idServicio")
            f.txtDescripcion.Text = Me.dgvConceptos2.Table.CurrentRecord.GetValue("descripcion")
            If Me.dgvConceptos2.Table.CurrentRecord.GetValue("descripcion") = "INTERES" Then
                f.txtDescripcion.ReadOnly = True
                f.Label3.Text = "Porcentaje:"
            ElseIf Me.dgvConceptos2.Table.CurrentRecord.GetValue("descripcion") = "SEGURO" Then
                f.txtDescripcion.ReadOnly = True
                f.Label3.Text = "Porcentaje:"
            End If

            f.Label4.Visible = False
            f.Label6.Visible = False
            f.Label7.Visible = False
            f.Label5.Visible = False
            f.Label9.Visible = False
            f.Label8.Visible = False

            f.txtCuenta.Text = Me.dgvConceptos2.Table.CurrentRecord.GetValue("cuenta")
            f.txtCuenta.Tag = Me.dgvConceptos2.Table.CurrentRecord.GetValue("cuenta")
            f.txtCuenta.Visible = False

            f.txtCuentaH.Text = Me.dgvConceptos2.Table.CurrentRecord.GetValue("cuentaH")
            f.txtCuentaH.Tag = Me.dgvConceptos2.Table.CurrentRecord.GetValue("cuentaH")
            f.txtCuentaH.Visible = False

            f.txtDevengado.Text = Me.dgvConceptos2.Table.CurrentRecord.GetValue("cuentaDev")
            f.txtDevengado.Tag = Me.dgvConceptos2.Table.CurrentRecord.GetValue("cuentaDev")
            f.txtDevengado.Visible = False

            f.txtDevengadoH.Text = Me.dgvConceptos2.Table.CurrentRecord.GetValue("cuentaDevH")
            f.txtDevengadoH.Tag = Me.dgvConceptos2.Table.CurrentRecord.GetValue("cuentaDevH")
            f.txtDevengadoH.Visible = False

            f.txtvalor.Value = Me.dgvConceptos2.Table.CurrentRecord.GetValue("valor")

            f.ShowDialog()


            'If datos.Count > 0 Then
            '    'cboTipoPR.ValueMember = datos(0).IDdfgd
            '    'cboTipoPR.SelectedValue = datos(0).ID
            '    'Me.dgvConceptos2.Table.CurrentRecord.SetValue("cuenta", datos(0).Cuenta)
            '    'Me.dgvConceptos2.Table.CurrentRecord.SetValue("cuenta", datos(0).Cuenta)
            '    'Me.dgvConceptos2.Table.CurrentRecord.SetValue("cuenta", datos(0).Cuenta)
            '    'Me.dgvConceptos2.Table.CurrentRecord.SetValue("cuenta", datos(0).Cuenta)
            '    Me.dgvConceptos2.Table.CurrentRecord.SetValue("valor", datos(0).Montomn)
            'End If

            If cboTipoPR.Text.Trim.Length > 0 Then
                ListarConceptosPrestamos(cboTipoPR.SelectedValue)
            End If


            'If cboTipoPR.Text.Trim.Length > 0 Then
            '    ListarConceptosPrestamos(DirectCast(Me.cboTipoPR.SelectedItem, Categoria).Id)
            'End If




            Me.Cursor = Cursors.Arrow
        Else

            MessageBox.Show("Seleccione un Item")
        End If
    End Sub

    Private Sub tb19_ButtonStateChanged(sender As Object, e As ToggleButton2.ToggleButtonStateEventArgs) Handles tb19.ButtonStateChanged
        If tb19.ToggleState = ToggleButton2.ToggleButtonState.ON Then
            'txtTotalBase.DecimalValue = TotalesXcanbeceras.BaseME
            'txtTotalIva.DecimalValue = TotalesXcanbeceras.IgvME
            'txtTotalPagar.DecimalValue = TotalesXcanbeceras.TotalME
            'lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionME

            'dgvCompra.TableDescriptor.Columns("pumn").Width = 0
            'dgvCompra.TableDescriptor.Columns("vcmn").Width = 0
            'dgvCompra.TableDescriptor.Columns("igvmn").Width = 0
            'dgvCompra.TableDescriptor.Columns("totalmn").Width = 0
            'dgvCompra.TableDescriptor.Columns("percepcionMN").Width = 0

            'dgvCompra.TableDescriptor.Columns("pume").Width = 60
            'dgvCompra.TableDescriptor.Columns("vcme").Width = 65
            'dgvCompra.TableDescriptor.Columns("igvme").Width = 65
            'dgvCompra.TableDescriptor.Columns("totalme").Width = 70
            'dgvCompra.TableDescriptor.Columns("percepcionME").Width = 70
            Label8.Visible = True
            txtImporteComprame.Visible = True
            txtImporteComprame.ReadOnly = False
            Label6.Visible = False
            txtImporteCompramn.Visible = False
            txtMontoSolesRef.Visible = True
            Label2.Visible = True





            cboMoneda.SelectedValue = 2
            If dgvPrestamoRO.Table.Records.Count > 0 Then
                dgvPrestamoRO.TableDescriptor.Columns("montomn").Width = 0
                dgvPrestamoRO.TableDescriptor.Columns("montome").Width = 70
            End If

        ElseIf tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF Then
            'txtTotalBase.DecimalValue = TotalesXcanbeceras.BaseMN
            'txtTotalIva.DecimalValue = TotalesXcanbeceras.IgvMN
            'txtTotalPagar.DecimalValue = TotalesXcanbeceras.TotalMN
            'lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionMN

            'dgvCompra.TableDescriptor.Columns("pumn").Width = 60
            'dgvCompra.TableDescriptor.Columns("vcmn").Width = 65
            'dgvCompra.TableDescriptor.Columns("igvmn").Width = 65
            'dgvCompra.TableDescriptor.Columns("totalmn").Width = 70
            'dgvCompra.TableDescriptor.Columns("percepcionMN").Width = 70

            'dgvCompra.TableDescriptor.Columns("pume").Width = 0
            'dgvCompra.TableDescriptor.Columns("vcme").Width = 0
            'dgvCompra.TableDescriptor.Columns("igvme").Width = 0
            'dgvCompra.TableDescriptor.Columns("totalme").Width = 0
            'dgvCompra.TableDescriptor.Columns("percepcionME").Width = 0

            txtMontoSolesRef.Visible = False
            Label2.Visible = False
            Label8.Visible = False
            txtImporteComprame.Visible = False
            Label6.Visible = True
            txtImporteCompramn.Visible = True
            cboMoneda.SelectedValue = 1
            If dgvPrestamoRO.Table.Records.Count > 0 Then

                dgvPrestamoRO.TableDescriptor.Columns("montomn").Width = 70
                dgvPrestamoRO.TableDescriptor.Columns("montome").Width = 0

            End If

        End If
    End Sub

    

  

    
   
    Private Sub tb19_Click(sender As Object, e As EventArgs) Handles tb19.Click

    End Sub
End Class