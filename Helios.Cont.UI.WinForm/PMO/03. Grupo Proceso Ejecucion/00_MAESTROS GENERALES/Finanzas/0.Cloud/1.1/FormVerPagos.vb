Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes

Public Class FormVerPagos

    Public Sub New(intIdDocumento As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        UbicarDocumento(intIdDocumento)
    End Sub

#Region "Methods"
    Public Sub UbicarDocumento(intIdDocumento As Integer)
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim documentoCajaDetalleSA As New DocumentoCajaDetalleSA
        Dim alEFSA As New EstadosFinancierosSA
        Dim tablaSA As New tablaDetalleSA
        Dim establecimientoSA As New establecimientoSA
        Dim entidadSA As New entidadSA
        Dim personaSA As New PersonaSA
        Try
            Dim docCaja = documentoCajaSA.GetUbicar_documentoCajaPorID(intIdDocumento)
            TextNumero.Text = docCaja.numeroDoc
            If docCaja IsNot Nothing Then
                Select Case docCaja.tipoMovimiento
                    Case MovimientoCaja.SalidaDinero
                        CaptionLabels(0).Text = "Otros egresos"
                        CaptionBarColor = Color.FromArgb(255, 134, 51)
                        BorderColor = Color.FromArgb(255, 134, 51)
                    Case MovimientoCaja.EntradaDinero
                        CaptionLabels(0).Text = "Otros ingresos"
                End Select
                TextTipoComprobante.Text = "VOUCHER CONTABLE: " & docCaja.numeroDoc
                TextFechaPago.Text = docCaja.fechaProceso
                TextFechaTrans.Text = docCaja.fechaModificacion

                Dim codigoDoc = docCaja.formapago
                Dim formaPago = tablaSA.GetUbicarTablaID(1, codigoDoc)
                TextFormaPago.Text = formaPago.descripcion

                With alEFSA.GetUbicar_estadosFinancierosPorID(docCaja.entidadFinanciera)
                    Select Case .tipo
                        Case CuentaFinanciera.Banco
                            TextTipoCuentaFinanciera.Text = "CUENTAS EN BANCO"
                        Case CuentaFinanciera.Efectivo
                            TextTipoCuentaFinanciera.Text = "CUENTAS EN EFECTIVO"
                        Case CuentaFinanciera.Tarjeta_Credito
                            TextTipoCuentaFinanciera.Text = "TARJETA DE CREDITO"
                    End Select
                    TextMoneda.Text = .codigo
                    TextCuentaFinanciera.Tag = .idestado
                    TextCuentaFinanciera.Text = .descripcion
                End With

                '   txtTipoCambio.Value = docCaja.tipoCambio
                TextImporte.Text = docCaja.montoSoles
                '       txtFondoME.Value = docCaja.montoUsd
                TextGlosa.Text = docCaja.glosa

                Select Case docCaja.tipoPersona
                    Case TIPO_ENTIDAD.PERSONAL_PLANILLA

                    Case TIPO_ENTIDAD.PERSONA_GENERAL
                        Dim personal = personaSA.ObtenerPersonaNumDoc(Gempresas.IdEmpresaRuc, docCaja.idPersonal)
                        TextPersona.Text = personal.nombreCompleto
                        TextDNI.Text = personal.idPersona
                        TextTipoPersona.Text = "Otros"
                    Case "CL"
                        Dim personal = entidadSA.UbicarEntidadPorID(docCaja.idPersonal)
                        TextPersona.Text = personal.First.nombreCompleto
                        TextDNI.Text = personal.First.nrodoc
                        TextTipoPersona.Text = "Cliente"
                    Case "PR"
                        Dim personal = entidadSA.UbicarEntidadPorID(docCaja.idPersonal)
                        TextPersona.Text = personal.First.nombreCompleto
                        TextDNI.Text = personal.First.nrodoc
                        TextTipoPersona.Text = "Proveedor"
                    Case "VR"
                        TextPersona.Text = VarClienteGeneral.nombreCompleto
                        TextDNI.Text = VarClienteGeneral.nrodoc
                        TextTipoPersona.Text = "Varios"
                End Select
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        Close()
    End Sub
End Class