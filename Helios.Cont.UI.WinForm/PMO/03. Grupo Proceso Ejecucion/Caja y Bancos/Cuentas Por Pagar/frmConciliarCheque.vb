Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Public Class frmConciliarCheque
    Inherits frmMaster

    Public Property lblIdProveedor() As String
    Public Property lblNomProveedor() As String
    Public Property lblCuentaProveedor() As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        QGlobalColorSchemeManager1 = New Qios.DevSuite.Components.QGlobalColorSchemeManager
        QGlobalColorSchemeManager1.Global.CurrentTheme = Qios.DevSuite.Components.QColorScheme.LunaBlueThemeName
        ' Add any initialization after the InitializeComponent() call.

    End Sub

#Region "VALIDA USUARIO CAJA"
    Public Function TieneCuentaFinanciera(Optional intIdDocumento As Integer = Nothing) As Boolean
        Dim efSA As New EstadosFinancierosSA
        Dim ef As New estadosFinancieros
        Dim estableSA As New establecimientoSA

        GFichaUsuarios = New GFichaUsuario
        With frmFichaUsuarioCaja
            ModuloAppx = ModuloSistema.CAJA
            .lblNivel.Text = "Caja"
            .lblEstadoCaja.Visible = True
            '    .GroupBox1.Visible = True
            '.GroupBox2.Visible = True
            '  .GroupBox4.Visible = True
            '  .cboMoneda.Visible = True
            .Timer1.Enabled = False
            .StartPosition = FormStartPosition.CenterParent
            '   .UbicarUsuarioCaja(intIdDocumento, "CUENTAS_POR_PAGAR")
            .ShowDialog()
            If IsNothing(GFichaUsuarios.NombrePersona) Then
                Return False
            Else
                Return True
            End If
        End With
    End Function
#End Region

#Region "Métodos"

    Public Function AS_DebeCaja(Cuenta As String, cDescripcion As String, cMonto As Decimal, cMontoUS As Decimal) As movimiento
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
      .usuarioActualizacion = GFichaUsuarios.IdCajaUsuario}

        Return nMovimiento


    End Function
    Function Glosa() As String
        Dim strGlosa As String = Nothing

        'With frmCuentasPorPagar
        strGlosa = "Por conciliación de cheque nro. " & txtNumOperacion.Text.Trim & " con fecha: " & txtFechaComprobante.Value

        'End With
        Return strGlosa
    End Function
    Function asientoCaja() As asiento
        Dim cuentaFinacieraSA As New EstadosFinancierosSA
        Dim documentocajaDetSA As New DocumentoCajaDetalleSA
        Dim nAsiento As New asiento
        Dim nDebe As New movimiento
        Dim nHaber As New movimiento

        nAsiento = New asiento
        nAsiento.idDocumento = lblIdDocumento.Text
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = lblIdProveedor
        nAsiento.nombreEntidad = lblNomProveedor
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = txtFechaComprobante.Value
        nAsiento.codigoLibro = "1"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.PAGO_COMPRA
        nAsiento.importeMN = txtImporteCompramn.Value ' dgvDetalleItems.Rows(i.Index).Cells(6).Value()
        nAsiento.importeME = txtImporteComprame.Value ' dgvDetalleItems.Rows(i.Index).Cells(7).Value()
        nAsiento.glosa = Glosa()
        nAsiento.usuarioActualizacion = GFichaUsuarios.IdCajaUsuario
        nAsiento.fechaActualizacion = DateTime.Now

        For Each i In documentocajaDetSA.GetUbicar_DetallePorIdDocumento(CInt(lblIdDocumento.Text))
            '  If CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value()) > 0 Then
            nAsiento.movimiento.Add(AS_HaberCliente(i.montoSoles, i.montoUsd))
            nAsiento.movimiento.Add(AS_DebeCaja(cuentaFinacieraSA.GetUbicar_estadosFinancierosPorID(GFichaUsuarios.IdCajaDestino).cuenta, i.DetalleItem, i.montoSoles, i.montoUsd))
            '  End If
        Next

        Return nAsiento
    End Function
#End Region

    Private Sub Conciliar()
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim documentoCajaDetalleSA As New DocumentoCajaDetalleSA
        Dim documentoCaja As New documentoCaja
        Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
        Dim obj As New RecuperarTablas
        Dim asiento As New asiento
        Dim ListaAsiento As New List(Of asiento)
        Dim documentoAsiento As New documento

        Dim cajaUsarioBE As New cajaUsuario
        Dim cajaUsariodetalleBE As New cajaUsuariodetalle
        Dim cajaUsariodetalleListaBE As New List(Of cajaUsuariodetalle)
        Dim DocumentoCompraSA As New DocumentoCompraSA
        Try

            With cajaUsarioBE
                .idcajaUsuario = GFichaUsuarios.IdCajaUsuario
                .otrosEgresosMN = CDec(txtImporteCompramn.Value)
                .otrosEgresosME = CDec(txtImporteComprame.Value)
            End With
            Dim codCompra As String = documentoCajaDetalleSA.GetUbicar_DetallePorIdDocumento(lblIdDocumento.Text).First.documentoAfectado
            cajaUsariodetalleBE = New cajaUsuariodetalle
            cajaUsariodetalleBE.idcajaUsuario = GFichaUsuarios.IdCajaUsuario
            cajaUsariodetalleBE.importeMN = CDec(txtImporteCompramn.Value)
            cajaUsariodetalleBE.importeME = CDec(txtImporteComprame.Value)
            cajaUsariodetalleListaBE.Add(cajaUsariodetalleBE)
            cajaUsarioBE.cajaUsuariodetalle = cajaUsariodetalleListaBE

            With documentoCaja
                .idDocumento = lblIdDocumento.Text
                .fechaCobro = txtFechaComprobante.Value
                .numeroOperacion = txtNumOperacion.Text.Trim
                .entregado = "SI"
            End With
            asiento = asientoCaja()
            ListaAsiento.Add(asiento)
            documentoAsiento.idDocumento = lblIdDocumento.Text
            documentoAsiento.asiento = ListaAsiento

            documentoCajaSA.ConciliarCheque(documentoCaja, documentoAsiento, cajaUsarioBE)
            obj.Codigo = txtNumOperacion.Text.Trim
            obj.NombreCampo = txtFechaComprobante.Value
            datos.Add(obj)
            Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmConciliarCheque_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmConciliarCheque_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PegarToolStripButton_Click(sender As Object, e As EventArgs) Handles PegarToolStripButton.Click
        Dispose()
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As Object, e As EventArgs) Handles GuardarToolStripButton.Click
 
    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        Me.Cursor = Cursors.WaitCursor
        Conciliar()
        Me.Cursor = Cursors.Arrow
    End Sub
End Class