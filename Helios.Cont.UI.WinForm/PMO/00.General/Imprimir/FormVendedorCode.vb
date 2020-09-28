Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes
Imports Helios.Seguridad.Business.Entity

Public Class FormVendedorCode
    Dim instance As New Printing.PrinterSettings
    Dim impresosaPredt As String = instance.PrinterName
    Public DocumentoID As Integer
    Public Property UsuarioSA As New cajaUsuarioSA
    Public Property UsuarioBE As New cajaUsuario

    Sub cargarCajas()
        UsuarioBE = New cajaUsuario
        UsuarioBE.idEmpresa = Gempresas.IdEmpresaRuc
        UsuarioBE.idEstablecimiento = GEstableciento.IdEstablecimiento
        UsuarioBE.estadoCaja = "A"

        ComboCaja.DataSource = UsuarioSA.ListadoCajaXEstado(UsuarioBE)
        ComboCaja.ValueMember = "idcajaUsuario" ' "IDUsuario"
        ComboCaja.DisplayMember = "NombrePersona"

    End Sub

    Sub ImprimirTicketv2(imprimir As String, intIdDocumento As Integer)
        'Dim a As pruebaTicket = New pruebaTicket
        ''a.HeaderImage = "C:\Documents and Settings\Administrador\Mis documentos\COMPU.jpg" 
        'Dim gravMN As Decimal = 0
        'Dim gravME As Decimal = 0
        'Dim ExoMN As Decimal = 0
        'Dim ExoME As Decimal = 0
        'Dim InaMN As Decimal = 0
        'Dim InaME As Decimal = 0
        'Dim precioUnit As Decimal = 0
        'Dim PrecioTotal As Decimal = 0
        'Dim entidadSA As New entidadSA
        'Dim documentoSA As New documentoVentaAbarrotesSA
        'Dim documentoDetSA As New documentoVentaAbarrotesDetSA
        'Dim comprobante = documentoSA.GetUbicar_documentoventaAbarrotesPorID(intIdDocumento)
        'Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)

        'a.TextoCentroEmpresa("MAS PERNOS SAC.")
        'a.TextoCentro("20601215935")
        ''a.TextoCentroEmpresa(Gempresas.NomEmpresa)
        ''a.TextoCentro(Gempresas.IdEmpresaRuc)
        'a.TextoCentro("Prol. Angaraes N°.399")
        'a.TextoCentro("Telf: " & "-")
        ''a.TextoCentro("Venta: Bolsas de toda dimensiòn - ")
        ''a.TextoCentro("Descartables en general")
        'a.AnadirLineaCaracteres("")

        'Select Case comprobante.tipoDocumento
        '    Case "12.1"
        '        'ticket.TextoExtremos("Caja # 1", "Ticket boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
        '        a.AnadirLineaSubcabeza("Ticket Boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
        '    Case "12.2"
        '        '  ticket.TextoExtremos("Caja # 1", "Ticket factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
        '        a.AnadirLineaSubcabeza("Ticket Factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)

        '    Case Else
        '        a.AnadirLineaSubcabeza("Ticket nota # " & comprobante.numeroVenta)
        'End Select

        'If comprobante.idCliente <> 0 Then
        '    Dim entidad = entidadSA.UbicarEntidadPorID(comprobante.idCliente).FirstOrDefault
        '    Dim NBoletaElectronica As String = "Cliente: " & entidad.nombreCompleto
        '    a.AnadirLineaSubcabeza(NBoletaElectronica)
        '    If entidad.nrodoc.Trim.Length = 11 Then
        '        a.AnadirLineaSubcabeza("RUC.: " & entidad.nrodoc)
        '    ElseIf entidad.nrodoc.Trim.Length = 8 Then
        '        a.AnadirLineaSubcabeza("DNI.: " & entidad.nrodoc)
        '    Else
        '        a.AnadirLineaSubcabeza("NRO DOC.: " & entidad.nrodoc)
        '    End If
        'Else
        '    Dim NBoletaElectronica As String = "Cliente: " & comprobante.nombrePedido
        '    a.AnadirLineaSubcabeza(NBoletaElectronica)
        'End If

        ''a.AnadirLineaSubcabeza("Cliente: " & "Maykol Charly Sanchez Coris")
        'a.AnadirLineaSubcabeza("FECHA: " + comprobante.fechaDoc.Value.ToShortDateString())
        'a.AnadirLineaSubcabeza("HORA: " + comprobante.fechaDoc.Value.ToShortTimeString())

        ''a.DottedLineGuion()
        '''El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia 
        '''de que al final de cada linea agrega una linea punteada "==========" 

        ''a.AnadirLineaSubcabeza("Le atendió: Prueba")
        ''a.AnadirLineaSubcabeza(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString())

        ''El metodo AddItem requeire 3 parametros, el primero es cantidad, el segundo es la descripcion 
        ''del producto y el tercero es el precio 
        ''a.AnadirElemento("1", "Articulohfghfghfghfghfghfhjghjghjghjg", "UND", "11.00", "111.00")
        'a.AnadirLineaCaracteres("")
        'For Each i In comprobanteDetalle

        '    Select Case i.destino
        '        Case OperacionGravada.Grabado
        '            gravMN += CDec(i.montokardex)
        '            gravME += CDec(i.montokardexUS)

        '        Case OperacionGravada.Exonerado
        '            ExoMN += CDec(i.montokardex)
        '            ExoME += CDec(i.montokardexUS)

        '        Case OperacionGravada.Inafecto
        '            InaMN += CDec(i.montokardex)
        '            InaME += CDec(i.montokardexUS)
        '    End Select

        '    precioUnit = (Math.Round(CDbl(i.importeMN / i.monto1), 2))
        '    PrecioTotal = i.importeMN
        '    a.AnadirElemento(i.monto1, i.unidad1, String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", PrecioTotal), i.nombreItem)
        '    'a.AnadirNombreElemento(i.nombreItem)
        'Next


        ''El metodo AddTotal requiere 2 parametros, la descripcion del total, y el precio 
        ''a.AnadirTotal("SUBTOTAL", "29.75")
        ''a.AnadirTotal("IVA", "5.25")
        ''a.AnadirLineaCaracteres("")
        'a.AnadirTotal("", "")
        'a.AnadirTotal("EXONERADA...S/.", ExoMN)
        'a.AnadirTotal("INAFECTA....S/.", InaMN)
        'a.AnadirTotal("GRAVADA.....S/.", gravMN)
        'a.AnadirTotal("IGV.........S/.", comprobante.igv01)
        ''La M indica que es un decimal en C#
        'a.AnadirTotal("TOTAL.......S/.", String.Format("{0:0.00}", comprobante.ImporteNacional))
        ''ticket.TextoIzquierda("")
        ''a.AnadirTotal("         EFECTIVO....S/.", comprobante.ImporteNacional)
        ''ticket.AgregarTotales("         CAMBIO........$", 0)

        ''Texto final del Ticket.
        ''ticket.TextoIzquierda("")
        'a.AnadeLineaAlPie("ARTICULOS VENDIDOS: " & comprobanteDetalle.Count)
        'a.AnadeLineaAlPie("")

        ''a.AnadirTotal("TOTAL", String.Format("{0:0.00}", Math.Round(CDbl(comprobante.ImporteNacional), 2)))

        'a.AnadeLineaAlPie("¡GRACIAS POR SU COMPRA!")

        ''//Y por ultimo llamamos al metodo PrintTicket para imprimir el ticket, este metodo necesita un 
        ''//parametro de tipo string que debe de ser el nombre de la impresora. 
        'a.ImprimeTicket(imprimir)

    End Sub

    'Sub ImprimirTicketA4(imprimir As String, intIdDocumento As Integer)
    '    Dim a As TicketA4v2 = New TicketA4v2
    '    ' Logo de la Empresa
    '    'a.HeaderImage = Image.FromFile("C:\LogosSistema\images.png")
    '    Dim lista As New List(Of String)

    '    Dim gravMN As Decimal = 0
    '    Dim gravME As Decimal = 0
    '    Dim ExoMN As Decimal = 0
    '    Dim ExoME As Decimal = 0
    '    Dim InaMN As Decimal = 0
    '    Dim InaME As Decimal = 0
    '    Dim ticket As New CrearTicket()
    '    Dim nombreComprabante As String
    '    '  Dim r As Record = dgPedidos.Table.CurrentRecord
    '    Dim entidadSA As New entidadSA
    '    Dim documentoSA As New documentoVentaAbarrotesSA
    '    Dim documentoDetSA As New documentoVentaAbarrotesDetSA
    '    Dim comprobante = documentoSA.GetUbicar_documentoventaAbarrotesPorID(intIdDocumento)
    '    Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)
    '    Dim tipoComprobante As String

    '    'Direccion de La empresa general


    '    a.AnadirLineaEmpresa(Gempresas.NomEmpresa)
    '    'Telefono de la empresa
    '    a.TextoIzquierda(Gempresas.direccionEmpresa)
    '    'direccion de la empresa
    '    a.TextoIzquierda(Gempresas.TelefonoEmpresa)
    '    a.TextoIzquierda("")

    '    Select Case comprobante.tipoDocumento
    '        Case "12.1"
    '            'ticket.TextoExtremos("Caja # 1", "Ticket boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
    '            a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, comprobante.numeroVenta, "BOLETA", comprobante.serieVenta)
    '            'ticket.TextoIzquierda("Ticket Boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
    '            nombreComprabante = "BOLETA" & comprobante.serieVenta & comprobante.numeroVenta
    '            tipoComprobante = "1"
    '        Case "12.2"
    '            '  ticket.TextoExtremos("Caja # 1", "Ticket factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
    '            'ticket.TextoIzquierda("Ticket Factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
    '            a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, comprobante.numeroVenta, "FACTURA", comprobante.serieVenta)
    '            nombreComprabante = "FACTURA" & comprobante.serieVenta & comprobante.numeroVenta
    '            tipoComprobante = "1"
    '        Case "03"
    '            '  ticket.TextoExtremos("Caja # 1", "Ticket factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
    '            'ticket.TextoIzquierda("Ticket Factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
    '            a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, comprobante.numeroVenta, "BOLETA ELECTRONICA", comprobante.serieVenta)
    '            nombreComprabante = "FACTURA" & comprobante.serieVenta & comprobante.numeroVenta
    '            tipoComprobante = "2"
    '        Case "01"
    '            '  ticket.TextoExtremos("Caja # 1", "Ticket factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
    '            'ticket.TextoIzquierda("Ticket Factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
    '            a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, comprobante.numeroVenta, "FACTURA ELECTRONICA", comprobante.serieVenta)
    '            nombreComprabante = "FACTURA" & comprobante.serieVenta & comprobante.numeroVenta
    '            tipoComprobante = "2"
    '        Case Else
    '            'ticket.TextoIzquierda("Ticket nota # " & comprobante.numeroVenta)
    '            a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, comprobante.numeroVenta, "NOTA ELECTRONICA", comprobante.serieVenta)
    '            nombreComprabante = "NOTA" & comprobante.serieVenta & comprobante.numeroVenta
    '            tipoComprobante = "1"
    '    End Select

    '    'a.TextoDerecha("RUC: " & "12345678911")
    '    'Numero de Ruc y Numeracion

    '    If comprobante.idCliente <> 0 Then
    '        Dim entidad = entidadSA.UbicarEntidadPorID(comprobante.idCliente).FirstOrDefault
    '        Dim NBoletaElectronica As String = entidad.nombreCompleto
    '        Dim nBoletaNumero As String
    '        'ticket.TextoIzquierda(NBoletaElectronica)
    '        If entidad.nrodoc.Trim.Length = 11 Then
    '            nBoletaNumero = "R.U.C. - " & entidad.nrodoc
    '        ElseIf entidad.nrodoc.Trim.Length = 8 Then
    '            nBoletaNumero = "D.N.I. - " & entidad.nrodoc
    '        Else
    '            nBoletaNumero = entidad.nrodoc
    '        End If
    '        'Fecha de Factura
    '        'Lugar de la factura
    '        'Nombre del cliente
    '        'direccion del cliente
    '        'numero del cliente
    '        'direccion de entrega
    '        'tipo moneda de la empresa
    '        'telefono de la empresa
    '        a.AnadirLineaCaracteresDatosGEnerales(comprobante.fechaDoc.Value.ToShortDateString(), "Huancayo - Perù", NBoletaElectronica, entidad.direccion, "", nBoletaNumero, "NAC", entidad.telefono)

    '    Else
    '        Dim NBoletaElectronica As String = comprobante.nombrePedido
    '        'ticket.TextoIzquierda(NBoletaElectronica)
    '        'Fecha de Factura
    '        'Lugar de la factura
    '        'Nombre del cliente
    '        'direccion del cliente
    '        'numero del cliente
    '        'direccion de entrega
    '        'tipo moneda de la empresa
    '        'telefono de la empresa
    '        a.AnadirLineaCaracteresDatosGEnerales(comprobante.fechaDoc.Value.ToShortDateString(), "Huancayo - Perù", NBoletaElectronica, "", "", "", "NAC", "")

    '    End If



    '    '*********************** TODO LOS DETALLES DE LOS ITEM *********************
    '    'CODIGO
    '    'DESCRIPCION
    '    'CANTIDAD
    '    'UM
    '    'VALOR VENTA UNITARIO
    '    'DESCUENTO
    '    'VALOR DE VENTA TOTAL
    '    'OTROS CARGOS
    '    'IMPUESTOS
    '    'PRECIO DE VENTA
    '    'VALOR TOTAL

    '    For Each i In comprobanteDetalle

    '        Select Case i.destino
    '            Case OperacionGravada.Grabado
    '                gravMN += CDec(i.montokardex)
    '                gravME += CDec(i.montokardexUS)

    '            Case OperacionGravada.Exonerado
    '                ExoMN += CDec(i.montokardex)
    '                ExoME += CDec(i.montokardexUS)

    '            Case OperacionGravada.Inafecto
    '                InaMN += CDec(i.montokardex)
    '                InaME += CDec(i.montokardexUS)
    '        End Select
    '        a.AnadirLineaElementosFactura(i.idItem, i.nombreItem, i.monto1, i.unidad1, (i.montokardex) / i.monto1, "0.00", i.montokardex, "0.00", i.montoIgv, i.importeMN / i.monto1, i.importeMN)
    '        'ticket.AgregaArticuloV2(i.nombreItem, String.Format("{0:0.00}", i.monto1), String.Format("{0:0.00}", i.importeMN / i.monto1), i.importeMN)
    '    Next

    '    '********************************** RESUMEN GENERAL DE LA FACTURA **************************
    '    'GRATUITAS
    '    a.AnadirDatosGenerales("S/", "0.00")
    '    'EXONERADAS
    '    a.AnadirDatosGenerales("S/", ExoMN)
    '    'INAFECTA
    '    a.AnadirDatosGenerales("S/", InaMN)
    '    'GRAVADA
    '    a.AnadirDatosGenerales("S/", gravMN)
    '    'TOTAL DESCUENTO
    '    a.AnadirDatosGenerales("S/", "0.00")
    '    'I.S.C.
    '    a.AnadirDatosGenerales("S/", "0.00")
    '    'I.G.V
    '    a.AnadirDatosGenerales("S/", comprobante.igv01)
    '    'IMPORTE TOTAL
    '    a.AnadirDatosGenerales("S/", comprobante.ImporteNacional)
    '    'DESCRIPCION DEL IMPORTE TOTAL EN LETRAS
    '    a.AnadirLineaTotalFactura(comprobante.ImporteNacional)
    '    'IMPRIMIR LA FACTUIRA

    '    Select Case tipoComprobante
    '        Case "1"
    '            a.tipoComprobante = "1"
    '            'enviarCorreo("maych_1@hotmail.com", "maykol_1_1_1", "maych_1@hotmail.com", "Texto Prueba", "Factura", "", NombreNumero)
    '            'a.GuardanImpresion("Microsoft Print to PDF", nombreComprabante, "maych_1@hotmail.com", "maykol_1_1_1", "maych_1@hotmail.com", "Texto Prueba", "Factura")
    '            a.ImprimeTicket(imprimir)

    '        Case "2"
    '            a.tipoComprobante = "2"
    '            'enviarCorreo("maych_1@hotmail.com", "maykol_1_1_1", "maych_1@hotmail.com", "Texto Prueba", "Factura", "", NombreNumero)
    '            'a.GuardanImpresion("Microsoft Print to PDF", nombreComprabante, "maych_1@hotmail.com", "maykol_1_1_1", "maych_1@hotmail.com", "Texto Prueba", "Factura")
    '            a.ImprimeTicket(imprimir)

    '    End Select

    'End Sub


    Private Sub FormVendedorCode_Load(sender As Object, e As EventArgs) Handles Me.Load
        cboImpresoras.Items.Clear()
        Me.CenterToParent()
        For Each item As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            cboImpresoras.Items.Add(item.ToString)
        Next
        cboImpresoras.SelectedText = impresosaPredt
        cargarCajas()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Public Function VerificarUsuario(ByVal codigo As String, ByVal lista As List(Of Usuario)) As Boolean
        Dim be = lista.Where(Function(a) a.codigo = codigo).FirstOrDefault
        VerificarUsuario = False
        If be IsNot Nothing Then
            VerificarUsuario = True
            usuario.IDUsuario = be.IDUsuario
        End If
    End Function

    Private Sub brnImprimir_Click(sender As Object, e As EventArgs) Handles brnImprimir.Click
        Dim cajaUsuaroSA As New cajaUsuarioSA
        Dim entidadSA As New EstadosFinancierosSA
        Dim codigoVendedor = TextCodigoVendedor.Text.Trim
        Dim usuarioSel = UsuariosList.Where(Function(o) o.codigo = codigoVendedor).FirstOrDefault

        If usuarioSel IsNot Nothing Then
            Dim cajaUsuario = cajaUsuaroSA.UbicarCajaUsuarioPorID(ComboCaja.SelectedValue)

            Dim ef = entidadSA.GetUbicar_estadosFinancierosPorID(cajaUsuario.idCajaOrigen)

            Dim envio As New EnvioImpresionVendedorPernos With
               {
                .CodigoVendedor = TextCodigoVendedor.Text.Trim,
                .IDCaja = cajaUsuario.idPersona,' ComboCaja.SelectedValue,
                .IDVendedor = usuarioSel.IDUsuario,
                .print = True,
                .Nombreprint = cboImpresoras.Text,
                .NombreCajero = ComboCaja.Text,
                .EntidadFinanciera = ef.idestado,
                .EntidadFinancieraName = ef.descripcion
            }
            Tag = envio
            Close()
        Else
            MessageBox.Show("Ingrese un código valido", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        'If (rbTicket.Checked = True) Then
        '    ImprimirTicketv2(cboImpresoras.Text, DocumentoID)
        '    Close()
        'ElseIf (rbA4.Checked = True) Then
        '    ImprimirTicketA4(cboImpresoras.Text, DocumentoID)
        '    Close()
        'End If
    End Sub
End Class