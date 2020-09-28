Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Public Class FormResumenVentas
    Private listaVentas As List(Of documentoventaTransporte)
    Private Property UCMaster As UCRecepcionEncomiendas

    Public Sub New(formPrincipal As UCRecepcionEncomiendas)

        ' This call is required by the designer.
        InitializeComponent()
        UCMaster = formPrincipal
        ' Add any initialization after the InitializeComponent() call.
        TextFechaDia.Value = Date.Now
        TextFechaMes.Value = Date.Now
    End Sub

    Private Sub RBAcumulado_CheckedChanged(sender As Object, e As EventArgs) Handles RBAcumuladoDia.CheckedChanged
        If RBAcumuladoDia.Checked = True Then
            TextFechaDia.Visible = True
            TextFechaMes.Visible = False
        End If
    End Sub

    Private Sub RBPendiente_CheckedChanged(sender As Object, e As EventArgs) Handles RBPendiente.CheckedChanged
        If RBPendiente.Checked = True Then
            TextFechaDia.Visible = False
            TextFechaMes.Visible = True
        End If
    End Sub

    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        imprimir()
    End Sub

    Private Sub imprimir()
        Dim ventaSA As New DocumentoventaTransporteSA

        If RBAcumuladoDia.Checked = True Then
            listaVentas = ventaSA.GetConsultaEncomiendasFecha(New Business.Entity.documentoventaTransporte With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .idOrganizacion = UCMaster.ComboAgenciaOrigen.SelectedValue,
                                                          .fechadoc = TextFechaDia.Value
                                                          }).Where(Function(o) o.estado <> 5).OrderByDescending(Function(o) o.fechadoc).ToList
        End If


        If RBPendiente.Checked = True Then
            listaVentas = ventaSA.GetConsultaEncomiendasSelMes(New Business.Entity.documentoventaTransporte With
                                                              {
                                                              .idEmpresa = Gempresas.IdEmpresaRuc,
                                                              .idOrganizacion = UCMaster.ComboAgenciaOrigen.SelectedValue,
                                                              .fechadoc = TextFechaMes.Value
                                                              }).Where(Function(o) o.estado <> 5).OrderByDescending(Function(o) o.fechadoc).ToList
        End If

        If RBA4.Checked = True Then
            ImpresionA4(listaVentas)
        End If

        If RBTicket.Checked = True Then
            ImpresionTK(listaVentas)
        End If
    End Sub

    Private Sub ImpresionTK(listaVentas As List(Of documentoventaTransporte))
        Try
            Dim a As TickeTransporteResumen = New TickeTransporteResumen
            'a.HeaderImage = "C:\Users\MAYKOL\Documents\LogoEmpresa\LOGO ROYAL BRANDING.jpg"
            Dim gravMN As Decimal = 0
            Dim gravME As Decimal = 0
            Dim ExoMN As Decimal = 0
            Dim ExoME As Decimal = 0
            Dim InaMN As Decimal = 0
            Dim InaME As Decimal = 0
            Dim precioUnit As Decimal = 0
            Dim PrecioTotal As Decimal = 0


            Dim rucCliente As String = String.Empty
            a.tipoImagen = False


            a.tipoEncabezado = False
            a.AnadirLineaEmpresa(Gempresas.NomEmpresa)
            a.TextoIzquierda("R.U.C.: " & Gempresas.IdEmpresaRuc)
            'direccion de la empresa
            a.TextoIzquierda("Direccion Principal: " & "")
            'Telefono de la empresa
            a.TextoIzquierda("TELF: " & "")

            '// FECHA
            '//NOMBRE CAJERO
            '//AGENCIA DESTINO
            '//DNI DEL CAJERO
            a.AnadirLineaCaracteresDatosGEnerales(TextFechaDia.Value,
                                              "",
                                              "",
                                              "-",
                                              UCMaster.ComboAgenciaOrigen.Text,
                                              "-",
                                              "",
                                              "")

            '//DETALLE DE LA VENTA FOR
            Dim NUMERACION As Integer = 1
            Dim TOTALVENTA As Decimal = 0.00
            For Each ITEM In listaVentas
                a.AnadirLineaElementosFactura(NUMERACION,
                                              ITEM.tipoDocumento & "-" & ITEM.serie & "-" & ITEM.numero,
                                              "",
                                              "",
                                              String.Format("{0:0.00}", ITEM.total))
                NUMERACION = NUMERACION + 1
                TOTALVENTA = TOTALVENTA + ITEM.total
            Next

            '//TOTAL DE LOS ITEM
            a.AnadirDatosGenerales("S/", String.Format("{0:0.00}", TOTALVENTA))

            a.ImprimeTicket("TICKET")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ImpresionA4(listaVentas As List(Of documentoventaTransporte))
        Try
            Dim a As TicketA4_ResumenVenta = New TicketA4_ResumenVenta
            Dim lista As New List(Of String)
            Dim gravMN As Decimal = 0
            Dim gravME As Decimal = 0
            Dim ExoMN As Decimal = 0
            Dim ExoME As Decimal = 0
            Dim InaMN As Decimal = 0
            Dim InaME As Decimal = 0
            Dim tipoComprobante As String = String.Empty

            ''//Logo de la Empresa
            ''a.HeaderImage = Image.FromFile("C:\Users\MAYKOL\Documents\LogoEmpresa\logoTomas.jpg")
            ''//POSISCION DE LA IMAGEN
            'a.PosicionLogo = "IT"

            ''//DATOS GENERALES DE LA EMPRESA
            a.AnadirLineaEmpresa(Gempresas.NomEmpresa,
                            "",
                             "Domicilio Fiscal: " & "",
                            "Establ. Anexo: " & "",
                            "Telf: " & "")



            ''//DATOS DEL CLIENTE
            ''Fecha de Factura
            ''Lugar de la factura
            ''Nombre del cliente
            ''direccion del cliente
            ''numero del cliente
            ''direccion de entrega
            ''tipo moneda de la empresa
            ''telefono de la empresa


            a.AnadirLineaCaracteresDatosGEnerales(TextFechaDia.Value,
                                              "",
                                              "-",
                                              "-",
                                              "",
                                              UCMaster.ComboAgenciaOrigen.Text,
                                              "",
                                              "")


            ''//DATOS DE LOS DETALLES DE LOS ITEMS
            ''*********************** TODO LOS DETALLES DE LOS ITEM *********************
            ''numeracion
            ''cliente
            ''serie.numero
            ''tipo_documento
            ''ruc cliente
            ''0
            ''0
            ''0
            ''0
            ''0
            'importe total

            '//DETALLE DE LA VENTA FOR
            Dim NUMERACION As Integer = 1
            Dim TOTALVENTA As Decimal = 0.00
            For Each ITEM In listaVentas

                If ITEM.Consignado IsNot Nothing Then
                    a.AnadirLineaElementosFactura(NUMERACION,
                                      ITEM.Consignado,
                                      ITEM.serie & "-" & ITEM.numero,
                                      ITEM.tipoDocumento,
                                      ITEM.fechadoc,
                                      "0.04",
                                      0,
                                      "0.03",
                                      "0.02",
                                      ITEM.fechadoc.Value.ToShortDateString,
                                      String.Format("{0:0.00}", ITEM.total))
                Else
                    a.AnadirLineaElementosFactura(NUMERACION,
                                     ITEM.comprador,
                                     ITEM.serie & "-" & ITEM.numero,
                                     ITEM.tipoDocumento,
                                     ITEM.fechadoc.Value.ToShortDateString,
                                     "0.00",
                                     0,
                                     "0.00",
                                     "0.00",
                                   ITEM.fechadoc.Value.ToShortDateString,
                                     String.Format("{0:0.00}", ITEM.total))
                End If

                NUMERACION = NUMERACION + 1
                TOTALVENTA = TOTALVENTA + ITEM.total
            Next



            'IMPORTE TOTAL
            a.AnadirDatosGenerales("S/", TOTALVENTA)

            a.ImprimeTicket("TICKET/RUTA", 1)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class