Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Tools
Public Class frminfocierreCosto
    Inherits frmMaster
    Public Property GConfiguracion As New GConfiguracionModulo

    Public Sub New(intIdCosto As Integer)

        ' This call is required by the designer.
        InitializeComponent()
        GConfiguracion = New GConfiguracionModulo
        configuracionModuloV2(Gempresas.IdEmpresaRuc, "AST", Me.Text, GEstableciento.IdEstablecimiento)
        ' Add any initialization after the InitializeComponent() call.
        UbicarByIdCosto(intIdCosto)
    End Sub

#Region "Métodos"
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
    '                        'txtSerieComp.Visible = True
    '                        'txtSerieComp.Text = .serie
    '                        'txtNumeroComp.Visible = False
    '                        'txtIdComprobante.Text = GConfiguracion.TipoComprobante
    '                        'txtComprobante.Text = GConfiguracion.NombreComprobante
    '                        'LinkTipoDoc.Enabled = False
    '                        'txtSerieComp.Enabled = False
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
    '        '    lblEstado.Text = "Este módulo no contiene una configuración disponible, intentelo más tarde.!"
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

    Public Sub UbicarByIdCosto(intidCosto As Integer)
        Dim costoSA As New recursoCostoDetalleSA
        Dim costo As New recursoCosto
        Dim recursoSA As New recursoCostoSA

        With recursoSA.GetCostoById(New recursoCosto With {.idCosto = intidCosto})
            Select Case .subtipo
                Case TipoCosto.Proyecto
                    txtTipoCosto.Text = "OBRAS DE CONTRUCCION"
                Case TipoCosto.OrdenProduccion
                    txtTipoCosto.Text = "ORDEN DE PRODUCCION"
                Case TipoCosto.ActivoFijo
                    txtTipoCosto.Text = "ACTIVOS FIJOS"

                Case TipoCosto.GastoAdministrativo
                    txtTipoCosto.Text = "GASTO ADMINISTRATIVO"
                Case TipoCosto.GastoVentas
                    txtTipoCosto.Text = "GASTO DE VENTAS"
                Case TipoCosto.GastoFinanciero
                    txtTipoCosto.Text = "GASTO FINANCIERO"
            End Select

            txtNomCosto.Text = .nombreCosto
            txtNomCosto.Tag = .idCosto
        End With

        costo = costoSA.GetSumaTotalImportesByCosto(New recursoCosto With {.idCosto = intidCosto})
        txtImporteMN.Text = costo.TotalMN
        txtImporteME.Text = costo.TotalME

    End Sub
#End Region

    Private Sub frminfocierreCosto_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frminfocierreCosto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim documento As New documento
        Dim documentoLibroDiario As New documentoLibroDiario
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento
        Dim costoSA As New recursoCostoSA
        Dim listAsiento As New List(Of asiento)

        Dim recursocosto As New recursoCosto
        recursocosto.idCosto = txtNomCosto.Tag
        recursocosto.status = StatusCosto.Culminado

        listAsiento = New List(Of asiento)

        documento = New documento
        documento.Action = Business.Entity.BaseBE.EntityAction.INSERT
        documento.idEmpresa = Gempresas.IdEmpresaRuc
        documento.idCentroCosto = GEstableciento.IdEstablecimiento
        documento.tipoDoc = "9901" 'VOUCHER CONTABLE
        documento.fechaProceso = DateTime.Now
        documento.nroDoc = "1"
        documento.tipoOperacion = "9906"
        documento.idOrden = Nothing
        documento.usuarioActualizacion = usuario.IDUsuario
        documento.fechaActualizacion = DateTime.Now

        documentoLibroDiario = New documentoLibroDiario
        documentoLibroDiario.TipoConfiguracion = GConfiguracion.TipoConfiguracion
        documentoLibroDiario.IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
        documentoLibroDiario.idEmpresa = Gempresas.IdEmpresaRuc
        documentoLibroDiario.idEstablecimiento = GEstableciento.IdEstablecimiento
        documentoLibroDiario.tipoRegistro = "CCS"
        documentoLibroDiario.fecha = DateTime.Now
        documentoLibroDiario.fechaPeriodo = PeriodoGeneral

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        documentoLibroDiario.tipoRazonSocial = "PR"
        documentoLibroDiario.razonSocial = Nothing
        documentoLibroDiario.infoReferencial = "Asientos Manuales"
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        documentoLibroDiario.tipoDoc = "9901"
        documentoLibroDiario.nroDoc = "1"
        documentoLibroDiario.tipoOperacion = "9906"
        documentoLibroDiario.moneda = "1"
        documentoLibroDiario.tipoCambio = 1
        documentoLibroDiario.importeMN = CDec(txtImporteMN.Text)
        documentoLibroDiario.importeME = CDec(txtImporteME.Text)
        documentoLibroDiario.usuarioActualizacion = usuario.IDUsuario
        documentoLibroDiario.fechaActualizacion = DateTime.Now

        documentoLibroDiario.tieneCosto = "S"
        documentoLibroDiario.idCosto = txtNomCosto.Tag
        documento.documentoLibroDiario = documentoLibroDiario

        'ASIENTOS CONTABLES
        nAsiento = New asiento With {
        .idEmpresa = Gempresas.IdEmpresaRuc,
        .idCentroCostos = GEstableciento.IdEstablecimiento,
        .idDocumentoRef = Nothing,
        .idAlmacen = 0,
        .nombreAlmacen = String.Empty,
        .idEntidad = String.Empty,
        .nombreEntidad = String.Empty,
        .tipoEntidad = String.Empty,
        .fechaProceso = DateTime.Now,
        .codigoLibro = "5",
        .tipo = "D",
        .tipoAsiento = "CCS",
        .importeMN = CDec(txtImporteMN.Text),
        .importeME = CDec(txtImporteME.Text),
        .glosa = "CIERRE DE COSTO",
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = DateTime.Now}

        nMovimiento = New movimiento
        nMovimiento.cuenta = "211"
        nMovimiento.descripcion = "PRODUCTOS MANUFACTURADOS"
        nMovimiento.tipo = "D"
        nMovimiento.monto = CDec(txtImporteMN.Text)
        nMovimiento.montoUSD = CDec(txtImporteME.Text)
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = DateTime.Now
        nAsiento.movimiento.Add(nMovimiento)

        nMovimiento = New movimiento
        nMovimiento.cuenta = "7111"
        nMovimiento.descripcion = "PRODUCTOS MANUFACTURADOS"
        nMovimiento.tipo = "H"
        nMovimiento.monto = CDec(txtImporteMN.Text)
        nMovimiento.montoUSD = CDec(txtImporteME.Text)
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = DateTime.Now
        nAsiento.movimiento.Add(nMovimiento)
        '-------------------------------------------------------------------------------


        nMovimiento = New movimiento
        nMovimiento.cuenta = "69211"
        nMovimiento.descripcion = "TERCEROS"
        nMovimiento.tipo = "D"
        nMovimiento.monto = CDec(txtImporteMN.Text)
        nMovimiento.montoUSD = CDec(txtImporteME.Text)
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = DateTime.Now
        nAsiento.movimiento.Add(nMovimiento)

        nMovimiento = New movimiento
        nMovimiento.cuenta = "211"
        nMovimiento.descripcion = "PRODUCTOS MANUFACTURADOS"
        nMovimiento.tipo = "H"
        nMovimiento.monto = CDec(txtImporteMN.Text)
        nMovimiento.montoUSD = CDec(txtImporteME.Text)
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = DateTime.Now
        nAsiento.movimiento.Add(nMovimiento)

        listAsiento.Add(nAsiento)
        documento.asiento = listAsiento

        costoSA.GetCulminarCosto(recursocosto, documento)
        MessageBox.Show("Costo cerrado correctamente!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Dispose()
    End Sub
End Class