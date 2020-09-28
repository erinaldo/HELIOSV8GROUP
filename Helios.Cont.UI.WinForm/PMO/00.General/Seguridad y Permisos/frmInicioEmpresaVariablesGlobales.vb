Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General

Public Class frmInicioEmpresaVariablesGlobales
    Public Property ultimaConfiguracion As configuracionInicio
    Public Property configuracionSA As New ConfiguracionInicioSA

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        ultimaConfiguracion = New configuracionInicio
        ultimaConfiguracion = configuracionSA.ObtenerConfigXempresa(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
        MapearControles()
    End Sub

    Private Sub MapearControles()
        nudTipoCambioCompra.DecimalValue = ultimaConfiguracion.tipocambio
        nudTipoCambioVenta.DecimalValue = ultimaConfiguracion.tipocambio
        txtIva.DecimalValue = ultimaConfiguracion.iva
        txtMontoVenta.DecimalValue = ultimaConfiguracion.montoMaximo

        Dim dt As New DataTable
        dt.Columns.Add("ID")
        dt.Columns.Add("NAME")
        dt.Rows.Add("VT", "VENTA FORMATO DIRECTA")
        dt.Rows.Add("MKT", "VENTA FORMATO MINIMARKET")

        cboTipoVenta.DataSource = dt
        cboTipoVenta.ValueMember = "ID"
        cboTipoVenta.DisplayMember = "NAME"
        cboTipoVenta.SelectedValue = ultimaConfiguracion.FormatoVenta

    End Sub

    Private Function ValidarGrabado() As Boolean
        Dim listaErrores As Integer = 0

        If txtMontoVenta.DecimalValue <= 0 Then
            ErrorProvider1.SetError(txtMontoVenta, "Ingrese un monto de venta mayor > que 0")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(txtMontoVenta, Nothing)
        End If

        If txtIva.DecimalValue < 0 Then
            ErrorProvider1.SetError(txtIva, "El igv. debe ser mayor o igual que 0")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(txtIva, Nothing)
        End If

        If listaErrores > 0 Then
            ValidarGrabado = False
        Else
            ValidarGrabado = True
        End If
    End Function

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        If ValidarGrabado() Then
            Grabar()
        End If
    End Sub

    Private Sub Grabar()
        Dim obj As New configuracionInicio With
            {
            .idEmpresa = Gempresas.IdEmpresaRuc,
            .idCentroCosto = GEstableciento.IdEstablecimiento,
               .periodo = ultimaConfiguracion.periodo,
                .anio = ultimaConfiguracion.anio,
                .mes = ultimaConfiguracion.mes,
                .dia = ultimaConfiguracion.dia,
                .tipocambio = 3,
                .iva = txtIva.DecimalValue,
                .tipoIva = txtIva.DecimalValue,
                .montoMaximo = txtMontoVenta.DecimalValue,
                .idalmacenVenta = 0,
                .entidadFinanciera = 0,
                .retencion4ta = 0,
                .tipoCambioTransacCompra = 3,
                .tipoCambioTransacVenta = 3,
                 .FormatoVenta = cboTipoVenta.SelectedValue
            }
        configuracionSA.EditarV00(obj)
        TmpIGV = txtIva.DecimalValue
        tmpConfigInicio.FormatoVenta = obj.FormatoVenta
        MontoMaximoCliente = txtMontoVenta.DecimalValue
        MessageBox.Show("Configuración guardada", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close()
    End Sub
End Class