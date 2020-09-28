Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.General.Constantes

Public Class FormIngresoEspecial
#Region "Attributes"
    Public Property Alert As Alert
    Private Property config As GConfiguracionModulo
#End Region

#Region "Constructors"
    Public Sub New(CuentasBancarias As List(Of estadosFinancierosConfiguracionPagos))

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GetComboEfectivo(CuentasBancarias)
        configuracionModuloV2(Gempresas.IdEmpresaRuc, "OES", Me.Text, GEstableciento.IdEstablecimiento)
    End Sub

#End Region

#Region "MEthods"
    Private Sub GetComboEfectivo(cuentasHabilitadas As List(Of estadosFinancierosConfiguracionPagos))
        Dim cajasEfectivo = cuentasHabilitadas.Where(Function(o) o.tipo = "EE").ToList

        ComboCajas.DisplayMember = "entidad"
        ComboCajas.ValueMember = "identidad"
        ComboCajas.DataSource = cajasEfectivo
    End Sub

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
    '            config = New GConfiguracionModulo
    '            config.IdModulo = .idModulo
    '            config.NomModulo = strNomModulo
    '            config.TipoConfiguracion = .tipoConfiguracion
    '            Select Case .tipoConfiguracion
    '                Case "P"
    '                    With numeracionSA.GetUbicar_numeracionBoletasPorID(.configComprobante)
    '                        config.ConfigComprobante = .IdEnumeracion
    '                        config.TipoComprobante = .tipo
    '                        config.NombreComprobante = TablaSA.GetUbicarTablaID(10, .tipo).descripcion
    '                        config.Serie = .serie
    '                        config.ValorActual = .valorInicial
    '                    End With
    '            End Select
    '            If Not IsNothing(.configAlmacen) Then
    '                Dim estableSA As New establecimientoSA
    '                With almacenSA.GetUbicar_almacenPorID(.configAlmacen)
    '                    config.IdAlmacen = .idAlmacen
    '                    config.NombreAlmacen = .descripcionAlmacen
    '                    With estableSA.UbicaEstablecimientoPorID(.idEstablecimiento)
    '                    End With
    '                End With
    '            End If
    '            If Not IsNothing(.ConfigentidadFinanciera) Then
    '                With cajaSA.GetUbicar_estadosFinancierosPorID(.ConfigentidadFinanciera)
    '                    config.IDCaja = .idestado
    '                    config.NomCaja = .descripcion
    '                End With
    '            End If

    '        End With
    '    Else
    '        MsgBox("Este módulo no contiene una configuración disponible, intentelo más tarde.!")
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

    Private Shared Function GetUsuarioCaja() As Integer
        Dim IDCajaUsuario_Login As Integer

        If (Not IsNothing(GFichaUsuarios.IdCajaUsuario)) Then
            IDCajaUsuario_Login = GFichaUsuarios.IdCajaUsuario
        Else
            IDCajaUsuario_Login = 0
        End If

        Return IDCajaUsuario_Login
    End Function

    Private Function GetEntidadElegida(tipoEntidad As String) As String
        tipoEntidad = "VR"
        Return tipoEntidad
    End Function

    Private Function GetDocumento(idNumeracion As Integer, tipoEntidad As String) As documento
        Return New documento With
        {
        .idEmpresa = Gempresas.IdEmpresaRuc,
        .idCentroCosto = GEstableciento.IdEstablecimiento,
        .tipoDoc = "9908",
        .fechaProceso = Date.Now,
        .nroDoc = idNumeracion,
        .idOrden = Nothing,
        .moneda = "1",
        .tipoEntidad = tipoEntidad,
        .idEntidad = VarClienteGeneral.idEntidad,
        .entidad = "VARIOS",
        .nrodocEntidad = "-",
        .tipoOperacion = StatusTipoOperacion.OTRAS_ENTRADAS_DE_DINERO_ESPECIAL,
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = DateTime.Now
        }
    End Function

    Private Function GetDocumentoCaja(idNumeracion As Integer, IDCajaUsuario_Login As Integer, tipoEntidad As String) As documentoCaja
        Return New documentoCaja With
                {
                .periodo = GetPeriodo(Date.Now, True),
                .idEmpresa = Gempresas.IdEmpresaRuc,
                .idEstablecimiento = GEstableciento.IdEstablecimiento,
                .TipoDocumentoPago = "9908",
                .formapago = "109",
                .codigoProveedor = VarClienteGeneral.idEntidad,
                .idPersonal = VarClienteGeneral.idEntidad,
                .tipoPersona = tipoEntidad,
                .codigoLibro = "1",
                .tipoDocPago = "9908",
                .numeroDoc = idNumeracion,
                .moneda = "1",
                .tipoMovimiento = MovimientoCaja.Otras_Entradas_Especial,
                .tipoOperacion = StatusTipoOperacion.OTRAS_ENTRADAS_DE_DINERO_ESPECIAL,
                .movimientoCaja = (MovimientoCaja.Otras_Entradas_Especial),
                .entidadFinanciera = ComboCajas.SelectedValue,
                .numeroOperacion = "0",
                .ctaIntebancaria = Nothing,
                .fechaProceso = Date.Now,
                .fechaCobro = Date.Now,
                .entregado = "SI",
                .tipoCambio = TmpTipoCambio,
                .montoSoles = TextImporte.DecimalValue,
                .montoUsd = 0,
                .idCajaUsuario = IDCajaUsuario_Login,
                .glosa = "Ingreso especial",
                .estado = "N",
                .idcosto = Nothing,
                .usuarioModificacion = usuario.IDUsuario,
                .fechaModificacion = DateTime.Now
                }
    End Function


    Private Function GetDetalleCaja(IDCajaUsuario_Login As Integer) As documentoCajaDetalle
        Return New documentoCajaDetalle With
                {
                .fecha = Date.Now,
                .idItem = "00",
                .DetalleItem = TextDetalle.Text.Trim,
                .montoSoles = TextImporte.DecimalValue,
                .montoSolesTransacc = 0,
                .montoUsd = 0,
                .montoUsdTransacc = 0,
                .diferTipoCambio = TmpTipoCambio,
                .tipoCambioTransacc = 0,
                .moneda = "1",
                .entregado = "SI",
                .documentoAfectado = 0,
                .idCajaUsuario = IDCajaUsuario_Login,
                .fechaModificacion = DateTime.Now,
                .usuarioModificacion = usuario.IDUsuario
                }
    End Function

    Public Sub Grabar()

        Dim documentoCajaSA As New DocumentoCajaSA
        Dim ndocumento As New documento
        Dim ndocumentoCaja As New documentoCaja
        Dim ndocumentoCajaDetalle As New documentoCajaDetalle
        Dim ListadocumentoCajaDetalle As New List(Of documentoCajaDetalle)
        Dim idNumeracion As Integer
        Dim IDCajaUsuario_Login As Integer
        Dim tipoEntidad As String = Nothing

        IDCajaUsuario_Login = GetUsuarioCaja()
        tipoEntidad = GetEntidadElegida(tipoEntidad)
        idNumeracion = IIf(IsNothing(config.ConfigComprobante), 0, config.ConfigComprobante)
        ndocumento = GetDocumento(idNumeracion, tipoEntidad)
        ndocumentoCaja = GetDocumentoCaja(idNumeracion, IDCajaUsuario_Login, tipoEntidad)
        ndocumento.documentoCaja = ndocumentoCaja
        ndocumentoCajaDetalle = GetDetalleCaja(IDCajaUsuario_Login)
        ListadocumentoCajaDetalle.Add(ndocumentoCajaDetalle)
        ndocumento.documentoCaja.documentoCajaDetalle = ListadocumentoCajaDetalle
        documentoCajaSA.SaveGroupCajaOtrosMovimientosSingleME(ndocumento)

        Alert = New Alert("Ingreso registrado", alertType.success)
        Alert.TopMost = True
        Alert.Show()

        Close()
    End Sub

    Private Sub ButtonGrabar_Click(sender As Object, e As EventArgs) Handles ButtonGrabar.Click
        Try
            If ComboCajas.Text.Trim.Length > 0 Then
                If TextDetalle.Text.Trim.Length > 0 Then
                    If TextImporte.DecimalValue > 0 Then
                        Grabar()
                    Else
                        MessageBox.Show("Debe indicar un importe mayor a cero!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        TextImporte.Select()
                    End If
                Else
                    MessageBox.Show("Debe indicar un detalle!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    TextDetalle.Select()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Private Sub FormIngresoEspecial_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
#End Region

#Region "Events"

#End Region
End Class