Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class FormCrearDevoluciónRecl
#Region "Attributes"
    Public Property cajaUsuaroSA As New cajaUsuarioSA
    Public Property envio As EnvioImpresionVendedorPernos
    Public Property DocumentoSel As documentoAnticipo
    'Public Property FormMDI As FormMaestroReclamacionPagos
#End Region

#Region "Constructors"
    Public Sub New(be As entidad, idDocumento As Integer) ', form As FormMaestroReclamacionPagos)

        ' This call is required by the designer.
        InitializeComponent()
        'FormMDI = Form
        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(dgvCuentas, False, False, 10)
        textFecha.Value = Date.Now
        GetMappingEntidad(be)
        'Me.Size = New Size(790, 132)
        cargarCajas()
        GetDocumentoBase(idDocumento)
    End Sub
#End Region

#Region "Methods"

    Sub GetDocumentoBase(idDocumento As Integer)
        Dim anticipoSA As New documentoAnticipoSA
        Dim ant = anticipoSA.GetDevolucionesByDocumentoNota(New documentoventaAbarrotes With {.idDocumento = idDocumento}).SingleOrDefault

        DocumentoSel = ant

        txtTotalPagar.DecimalValue = ant.SaldoReclamacion.GetValueOrDefault
        textMontoBase.DecimalValue = ant.SaldoReclamacion.GetValueOrDefault


    End Sub

    Sub GetMappingEntidad(be As entidad)
        TextPersona.Tag = be.idEntidad
        TextPersona.Text = be.nombreCompleto
        TextRuc.Text = be.nrodoc
    End Sub
    'Private Sub GeTgColumnsGrid()
    '    Dim dt As New DataTable

    '    With dt
    '        .Columns.Add("tipo")
    '        .Columns.Add("identidad")
    '        .Columns.Add("entidad")
    '        .Columns.Add("abonado")
    '        .Columns.Add("tipocambio")
    '        .Columns.Add("idforma")
    '        .Columns.Add("formaPago")
    '    End With
    '    dgvCuentas.DataSource = dt
    'End Sub

    Private Sub GetMappingColumnsGrid(idCaja As Integer)
        Dim dt As New DataTable
        Dim SA As New EstadosFinancierosConfiguracionPagosSA
        With dt
            .Columns.Add("tipo")
            .Columns.Add("identidad")
            .Columns.Add("entidad")
            .Columns.Add("abonado")
            .Columns.Add("Saldo")
            .Columns.Add("tipocambio")
            .Columns.Add("idforma")
            .Columns.Add("formaPago")
        End With
        'Dim listaCuentas = SA.GetConfigurationPay(New estadosFinancierosConfiguracionPagos With
        '                                     {
        '                                     .idEmpresa = Gempresas.IdEmpresaRuc,
        '                                     .idEstablecimiento = GEstableciento.IdEstablecimiento
        '                                     })
        'Dim listaCuentas = SA.GetConfigurationPayCaja(New estadosFinancierosConfiguracionPagos With
        '                                         {
        '                                         .idEmpresa = Gempresas.IdEmpresaRuc,
        '                                         .idEstablecimiento = GEstableciento.IdEstablecimiento,
        '                                         .IDCaja = idCaja
        '                                         })

        ListaCuentasFinancierasConfiguradas = SA.GetConfigurationPaySaldo(New estadosFinancierosConfiguracionPagos With
                {
                .idEmpresa = Gempresas.IdEmpresaRuc,
                .idEstablecimiento = GEstableciento.IdEstablecimiento,
                .fecha = DateTime.Now
                                                           })


        For Each i In ListaCuentasFinancierasConfiguradas.Where(Function(o) o.IDFormaPago <> "9991").ToList
            dt.Rows.Add(String.Empty, i.identidad, i.entidad, 0.0, i.MontoCaja, TmpTipoCambio, i.IDFormaPago, i.FormaPago)
        Next
        dgvCuentas.DataSource = dt
    End Sub

    Sub cargarCajas()
        ' Dim UsuarioBE = New cajaUsuario
        '    Dim cajaUsuarioSA As New cajaUsuarioSA
        'UsuarioBE.idEmpresa = Gempresas.IdEmpresaRuc
        'UsuarioBE.idEstablecimiento = GEstableciento.IdEstablecimiento
        'UsuarioBE.estadoCaja = "A"

        ComboCaja.DataSource = ListaCajasActivas ' cajaUsuarioSA.ListadoCajaXEstado(UsuarioBE)
        ComboCaja.ValueMember = "idcajaUsuario" ' "IDUsuario"
        ComboCaja.DisplayMember = "NombrePersona"

    End Sub

    Private Function SumaPagos() As Decimal
        SumaPagos = 0
        For Each i In dgvCuentas.Table.Records
            'If i.GetValue("abonado") <= 0 Then
            '    Throw New Exception("El monto abonado debe sre mayor a cero")
            'End If
            If CDec(i.GetValue("abonado")) <= CDec(i.GetValue("Saldo")) Then
                SumaPagos += CDec(i.GetValue("abonado"))
            Else
                dgvCuentas.Table.CurrentRecord.SetValue("abonado", 0)
            End If
        Next

        SumaPagos = SumaPagos
        Return SumaPagos
    End Function

#End Region

#Region "Events"
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

        Dim codigoVendedor = TextCodigoVendedor.Text.Trim
        Dim usuarioSel = UsuariosList.Where(Function(o) o.codigo = codigoVendedor).FirstOrDefault

        If usuarioSel IsNot Nothing Then
            Dim cajaUsuario = cajaUsuaroSA.UbicarCajaUsuarioPorID(ComboCaja.SelectedValue)

            envio = New EnvioImpresionVendedorPernos With
                {
                .CodigoVendedor = TextCodigoVendedor.Text.Trim,
                .IDCaja = cajaUsuario.idcajaUsuario,' ComboCaja.SelectedValue,
                .IDVendedor = usuarioSel.IDUsuario,
                .print = True,
                .Nombreprint = String.Empty,
                .NombreCajero = ComboCaja.Text,
                .EntidadFinanciera = cajaUsuario.idcajaUsuario,
                .EntidadFinancieraName = String.Empty
            }
            'Me.Size = New Size(790, 691)
            GroupBox1.Visible = True
            Centrar(Me)
            '      GetMappingColumnsGrid()

        Else
            MessageBox.Show("Ingrese un código valido", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextCodigoVendedor.Select()
        End If
    End Sub

    Private Sub ButtonGrabar_Click(sender As Object, e As EventArgs) Handles ButtonGrabar.Click
        GrabarDocumento()
    End Sub

    Private Sub GrabarDocumento()
        Try
            Dim ventaSA As New documentoVentaAbarrotesSA
            Dim documento As New documento
            Dim lista = ListaPagosCajas()
            documento = New documento With {
                .idDocumento = DocumentoSel.idDocumento,
                .ListaCustomDocumento = lista
                }
            ventaSA.GrabarDocumentoCajaDevolucionAnt(documento)

            'FormMDI.GetStatus()

            MessageBox.Show("Devolución registrada", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Close()
        Catch ex As Exception

        End Try


    End Sub

    Public Function ListaPagosCajas() As List(Of documento)
        Dim nDocumentoCaja As New documento
        Dim objCaja As New documentoCaja
        Dim ListaDoc As New List(Of documento)
        For Each i In dgvCuentas.Table.Records
            If Decimal.Parse(i.GetValue("abonado")) > 0 Then
                nDocumentoCaja = New documento
                nDocumentoCaja.idDocumento = CInt(Me.Tag)
                nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
                nDocumentoCaja.idCentroCosto = GEstableciento.IdEstablecimiento
                nDocumentoCaja.tipoDoc = "9901" ' cbotipoDocPago.SelectedValue
                nDocumentoCaja.fechaProceso = textFecha.Value
                nDocumentoCaja.nroDoc = "1"
                nDocumentoCaja.idOrden = Nothing
                nDocumentoCaja.moneda = "1"
                nDocumentoCaja.idEntidad = Val(TextPersona.Tag)
                nDocumentoCaja.entidad = TextPersona.Text
                nDocumentoCaja.nrodocEntidad = TextRuc.Text
                nDocumentoCaja.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
                nDocumentoCaja.tipoOperacion = StatusTipoOperacion.PAGO_A_CLIENTES_RECLAMACION
                nDocumentoCaja.usuarioActualizacion = envio.IDCaja ' usuario.IDUsuario
                nDocumentoCaja.fechaActualizacion = DateTime.Now

                'DOCUMENTO CAJA
                objCaja = New documentoCaja
                objCaja.tipoOperacion = StatusTipoOperacion.PAGO_A_CLIENTES_RECLAMACION
                objCaja.idDocumento = 0
                objCaja.periodo = GetPeriodo(textFecha.Value, True)
                objCaja.idEmpresa = Gempresas.IdEmpresaRuc
                objCaja.idEstablecimiento = GEstableciento.IdEstablecimiento
                objCaja.fechaProceso = textFecha.Value
                objCaja.fechaCobro = textFecha.Value
                objCaja.tipoMovimiento = TIPO_COMPRA.PAGO.PAGADO
                objCaja.codigoProveedor = Integer.Parse(TextPersona.Tag)
                objCaja.IdProveedor = Integer.Parse(TextPersona.Tag)
                objCaja.idPersonal = Integer.Parse(TextPersona.Tag)
                objCaja.TipoDocumentoPago = "9901" 'cbotipoDocPago.SelectedValue
                objCaja.codigoLibro = "1"
                objCaja.tipoDocPago = "9901"
                objCaja.formapago = i.GetValue("idforma")
                objCaja.NumeroDocumento = "-"
                objCaja.numeroOperacion = "-"
                objCaja.movimientoCaja = StatusTipoOperacion.DEVOLUCION_DE_ANTICIPO_A_CLIENTE
                objCaja.montoSoles = Decimal.Parse(i.GetValue("abonado"))

                objCaja.moneda = "1"
                objCaja.tipoCambio = TmpTipoCambio
                objCaja.montoUsd = Decimal.Parse(objCaja.montoSoles / TmpTipoCambio)

                objCaja.estado = "1"
                objCaja.glosa = "RECLAMACION A PROVEEDOR"
                objCaja.entregado = "SI"

                objCaja.entidadFinanciera = i.GetValue("identidad")
                objCaja.NombreEntidad = i.GetValue("entidad")
                objCaja.idCajaUsuario = envio.IDCaja 'GFichaUsuarios.IdCajaUsuario
                objCaja.usuarioModificacion = envio.IDCaja 'usuario.IDUsuario


                objCaja.fechaModificacion = DateTime.Now
                nDocumentoCaja.documentoCaja = objCaja
                nDocumentoCaja.documentoCaja.documentoCajaDetalle = GetDetallePago(objCaja, i)
                '  asientoDocumento(nDocumentoCaja.documentoCaja)
                ListaDoc.Add(nDocumentoCaja)
            End If
        Next

        Return ListaDoc
    End Function

    Private Function GetDetallePago(objCaja As documentoCaja, r As Record) As List(Of documentoCajaDetalle)
        Dim montoPago = objCaja.montoSoles
        GetDetallePago = New List(Of documentoCajaDetalle)
        GetDetallePago.Add(New documentoCajaDetalle With
                  {
                  .fecha = Date.Now,
                  .codigoLote = 0,
                  .otroMN = 0,
                  .idItem = r.GetValue("identidad"),
                  .DetalleItem = r.GetValue("entidad"),
                  .montoSoles = Decimal.Parse(r.GetValue("abonado")),
                  .montoUsd = 0,
                  .diferTipoCambio = TmpTipoCambio,
                  .tipoCambioTransacc = TmpTipoCambio,
                  .entregado = "SI",
                  .idCajaUsuario = envio.IDCaja,
                  .usuarioModificacion = envio.IDCaja,' usuario.IDUsuario,
                  .documentoAfectado = DocumentoSel.idDocumento,
                  .documentoAfectadodetalle = 0,
                  .fechaModificacion = DateTime.Now
                  })
    End Function

    Private Sub dgvCuentas_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvCuentas.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Try
            Select Case ColIndex
                Case 2
                    Dim pagos As Decimal = SumaPagos()
                    If pagos > CDec(txtTotalPagar.Text) Then
                        MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        dgvCuentas.Table.CurrentRecord.SetValue("abonado", 0)
                        Exit Sub
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Verificar montos del pago")
        End Try
    End Sub

    Private Sub ButtonSalir_Click(sender As Object, e As EventArgs) Handles ButtonSalir.Click
        Close()
    End Sub



    Private Sub ComboCaja_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboCaja.SelectedValueChanged
        If IsNumeric(ComboCaja.SelectedValue) Then
            GetMappingColumnsGrid(Integer.Parse(ComboCaja.SelectedValue))
        End If
    End Sub

    Private Sub FormCrearDevoluciónRecl_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ComboCaja_Click(sender As Object, e As EventArgs) Handles ComboCaja.Click

    End Sub


#End Region
End Class