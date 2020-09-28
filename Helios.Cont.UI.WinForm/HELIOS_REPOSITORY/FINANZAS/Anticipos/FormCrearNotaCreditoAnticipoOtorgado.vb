Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General

Public Class FormCrearNotaCreditoAnticipoOtorgado

#Region "Attributes"
    Public Property anticipoSA As New documentoAnticipoSA
    Public Alert As Alert
    Public Property AnticipoPadre As Integer
    ' Public Property FormMDI As FormMaestroModuloAnticipos
#End Region

#Region "Constructor"

    Sub New(idAnticipo As Integer, ent As entidad)

        ' This call is required by the designer.
        InitializeComponent()
        textFecha.Value = Date.Now
        AnticipoPadre = idAnticipo
        GetAnticipo(idAnticipo, ent)
        ' Add any initialization after the InitializeComponent() call.

    End Sub

#End Region

#Region "Methods"

    Private Sub GetAnticipo(idAnticipo As Integer, ent As entidad)
        TextPersona.Text = ent.nombreCompleto
        TextPersona.Tag = ent.idEntidad
        TextRuc.Text = ent.nrodoc

        Dim anticipo = anticipoSA.ObtenerSaldoAnticipoV2Compra(idAnticipo)
        If anticipo IsNot Nothing Then
            Dim saldoDisponible = anticipo.Saldo.GetValueOrDefault
            textMontoBase.DecimalValue = saldoDisponible
            TextValorReclamacion.MaxValue = saldoDisponible
            TextValorReclamacion.MinValue = 0
        Else
            textMontoBase.DecimalValue = 0
            TextValorReclamacion.MaxValue = 0
            TextValorReclamacion.MinValue = 0
        End If
    End Sub

    Private Sub GetCalculo()
        Dim importe = TextValorReclamacion.DecimalValue
        Dim baseImponible = Math.Round(CDec(CalculoBaseImponible(importe, 1.18)), 2)
        Dim iva = Math.Round(importe - baseImponible, 2)
        TextBaseImponible.DecimalValue = baseImponible
        TextValorIva.DecimalValue = iva
    End Sub

    Sub Grabar(EstadoPago As String)
        Dim VentaSA As New documentoVentaAbarrotesSA
        Dim CompraSA As New DocumentoCompraSA
        Dim ndocumento As New documento()
        Dim DocCaja As New documento

        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim docVentaSA As New documentoVentaAbarrotesSA

        Dim nDocumentoVenta As New documentocompra()
        Dim objDocumentoVentaDet As New documentocompradetalle
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim asientoSA As New AsientoSA
        ' Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim ListaDetalle As New List(Of documentocompradetalle)
        Dim proveedor As String
        Dim idProveedor As Integer

        proveedor = TextPersona.Text
        idProveedor = CInt(TextPersona.Tag)

        textFecha.Value = DateTime.Now
        '-------------------------------------------------------------------------------------
        ndocumento = New documento
        ndocumento.Action = Business.Entity.BaseBE.EntityAction.INSERT
        ndocumento.idEmpresa = Gempresas.IdEmpresaRuc
        ndocumento.idCentroCosto = GEstableciento.IdEstablecimiento
        ndocumento.tipoDoc = "07"
        ndocumento.fechaProceso = textFecha.Value
        ndocumento.nroDoc = $"{TextSerie.Text.Trim}-{TextNumero.Text.Trim}"
        ndocumento.moneda = "1"
        ndocumento.idEntidad = Val(idProveedor)
        ndocumento.entidad = proveedor
        ndocumento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        ndocumento.nrodocEntidad = TextRuc.Text
        ndocumento.tipoOperacion = StatusTipoOperacion.COMPRA
        ndocumento.usuarioActualizacion = usuario.IDUsuario
        ndocumento.fechaActualizacion = DateTime.Now

        nDocumentoVenta = New documentocompra With {
            .idPadre = AnticipoPadre,
                  .tipoOperacion = "01",
                  .codigoLibro = "14",
                  .tipoDoc = "07",
                  .idEmpresa = Gempresas.IdEmpresaRuc,
                  .idCentroCosto = GEstableciento.IdEstablecimiento,
                  .fechaDoc = textFecha.Value,
                  .fechaContable = GetPeriodo(textFecha.Value, True),
                  .serie = TextSerie.Text.Trim,
                  .numeroDoc = TextNumero.Text.Trim,
                  .idProveedor = idProveedor,
                  .nombreProveedor = proveedor,
                  .monedaDoc = "1",
                  .tasaIgv = TmpIGV,
                  .tipocambio = TmpTipoCambio,
                  .bi01 = TextBaseImponible.DecimalValue,
                  .bi02 = 0,
                  .igv01 = TextValorIva.DecimalValue,
                  .igv02 = 0,
                  .bi01us = 0,
                  .bi02us = 0,
                  .igv01us = 0,
                  .igv02us = 0,
                  .importeTotal = TextValorReclamacion.DecimalValue,
                  .importeUS = 0,
                  .tipoCompra = TIPO_VENTA.VENTA_NOTA_CREDITO_ANTICIPO,
                  .estadoPago = EstadoPago, 'TIPO_COMPRA.PAGO.PENDIENTE_PAGO,
                  .glosa = "Nota de credito por anticipo recibido, reclamación emitida",
                  .usuarioActualizacion = usuario.IDUsuario,
                  .fechaActualizacion = DateTime.Now}
        ndocumento.documentocompra = nDocumentoVenta


        'REGISTRANDO LA GUIA DE REMISION
        'GuiaRemision(ndocumento)
        objDocumentoVentaDet = New documentocompradetalle
        objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
        objDocumentoVentaDet.IdEmpresa = Gempresas.IdEmpresaRuc
        objDocumentoVentaDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
        objDocumentoVentaDet.FechaDoc = textFecha.Value
        objDocumentoVentaDet.Serie = TextSerie.Text.Trim
        objDocumentoVentaDet.NumDoc = TextNumero.Text.Trim
        objDocumentoVentaDet.TipoDoc = "07"
        objDocumentoVentaDet.almacenRef = Nothing
        objDocumentoVentaDet.tipoCompra = Nothing
        objDocumentoVentaDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
        'objDocumentoVentaDet.cuentaOrigen = Nothing
        objDocumentoVentaDet.idItem = 0
        objDocumentoVentaDet.DetalleItem = "RECLAMACION POR ANTICIPO"
        objDocumentoVentaDet.descripcionItem = "RECLAMACION POR ANTICIPO"
        objDocumentoVentaDet.tipoExistencia = "01"
        objDocumentoVentaDet.destino = "1"
        objDocumentoVentaDet.unidad1 = "UND"
        objDocumentoVentaDet.monto1 = 1
        objDocumentoVentaDet.unidad2 = Nothing
        objDocumentoVentaDet.monto2 = Nothing 'i.Cells(31).Value()
        objDocumentoVentaDet.precioUnitario = 0
        objDocumentoVentaDet.precioUnitarioUS = 0
        objDocumentoVentaDet.importe = TextValorReclamacion.DecimalValue
        objDocumentoVentaDet.importeUS = 0
        'objDocumentoVentaDet.descuentoMN = 0
        'objDocumentoVentaDet.descuentoME = 0

        objDocumentoVentaDet.montokardex = TextBaseImponible.DecimalValue
        objDocumentoVentaDet.montoIsc = 0
        objDocumentoVentaDet.montoIgv = TextValorIva.DecimalValue
        objDocumentoVentaDet.otrosTributos = 0

        objDocumentoVentaDet.montokardexUS = 0
        objDocumentoVentaDet.montoIscUS = 0
        objDocumentoVentaDet.montoIgvUS = 0
        objDocumentoVentaDet.otrosTributosUS = 0
        'objDocumentoVentaDet.estadoMovimiento = "NO" 'ENTREGADO/COBRADO
        'objDocumentoVentaDet.importeMNK = 0
        'objDocumentoVentaDet.importeMEK = 0
        objDocumentoVentaDet.FechaVcto = Nothing
        objDocumentoVentaDet.salidaCostoMN = 0
        objDocumentoVentaDet.salidaCostoME = 0
        objDocumentoVentaDet.categoria = Nothing
        objDocumentoVentaDet.preEvento = Nothing
        'objDocumentoVentaDet.tipobeneficio = "-"
        'objDocumentoVentaDet.beneficiobase = 0
        objDocumentoVentaDet.usuarioModificacion = usuario.IDUsuario
        objDocumentoVentaDet.fechaModificacion = Date.Now
        objDocumentoVentaDet.Glosa = nDocumentoVenta.glosa
        ListaDetalle.Add(objDocumentoVentaDet)
        ndocumento.documentocompra.documentocompradetalle = ListaDetalle
        'Dim cod = VentaSA.GrabarVentaDocumentoGeneral(ndocumento)

        Dim cod2 = CompraSA.GrabarCompraDocumentoGeneral(ndocumento)

        Alert = New Alert("Reclamación registrada", alertType.success)
        Alert.TopMost = True
        Alert.Show()
        'FormMDI.GetStatus()
        'FormMDI.GetStatusNotasCreditoREM()
        Close()
    End Sub
#End Region

    Private Sub FormCrearNotaCreditoAnticipoOtorgado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboTipoOperacion.Text = "COMPENSACION"
    End Sub

    Private Sub TextValorReclamacion_TextChanged(sender As Object, e As EventArgs) Handles TextValorReclamacion.TextChanged
        GetCalculo()
    End Sub

    Private Sub ButtonGrabar_Click(sender As Object, e As EventArgs) Handles ButtonGrabar.Click

        If MessageBox.Show("Está seguro de realizar la reclamación?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then


            If cboTipoOperacion.Text = "COMPENSACION" Then
                Grabar(TIPO_VENTA.PAGO.PENDIENTE_PAGO)
            ElseIf cboTipoOperacion.Text = "DEVOLUCION" Then
                Grabar(Anticipo.EstadoCobroNotaCredito.SolicitudDevolucion)
            End If
        End If

    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Close()
    End Sub
End Class