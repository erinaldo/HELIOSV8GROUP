Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Public Class frmCerrarCajaDetallado
    Inherits frmMaster

#Region "Attributes"
    Public dniPerCaja As Integer
    Public idPersona As Integer
    Dim cajausuario As New List(Of cajaUsuario)
    Dim ListDocVentaAbarrotesDet As New List(Of documentoventaAbarrotesDet)
    Dim ListacajausuarioXEntidadFinanciera As New List(Of documentoCaja)
    Dim saldoGeneral As Decimal
    Dim FIngreso As Decimal
    Dim FEgreso As Decimal
    Dim FFondo As Decimal
#End Region

#Region "Constructors"
    Public Sub New(r As Record)

        ' This call is required by the designer.
        InitializeComponent()

        FormatoGridPequeño(dgvEntidad, False)
        FormatoGridPequeño(dgvResumen, False)
        ' Add any initialization after the InitializeComponent() call.
        'Inicio(r)
    End Sub

    Public Sub New(idCaja As Integer, idPersona As Integer, fechaRegistro As DateTime)

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        'InicioCaja(idCaja, idPersona, fechaRegistro)
    End Sub
#End Region

#Region "Methods"

    Public Sub consultaMovimientoCaja(idCaja As Integer)

        Dim DocCajaSA As New DocumentoCajaSA

        ListacajausuarioXEntidadFinanciera = DocCajaSA.ResumenCiereCaja(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, idCaja, "A")

        GetAsignaciones()
        GetAsignacionesDetallado()
    End Sub


    Public Sub GetAsignaciones()
        'Dim usuario As New Usuario
        'Dim ListacajausuarioXEntidadFinanciera As New List(Of documentoCajaDetalle)
        'Dim DocCajaDetalleSA As New DocumentoCajaDetalleSA
        'dgvEntidad.Table.Records.DeleteAll()

        Dim dt As New DataTable("Entidades financieras")
        dt.Columns.Add(New DataColumn("tipoEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("nombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("moneda", GetType(String)))
        dt.Columns.Add(New DataColumn("importeApertura", GetType(Decimal)))

        'listaCajaUsuario = cajaUsuarioSA.ObtenerCajaUsuarioFull


        'ListacajausuarioXEntidadFinanciera = DocCajaDetalleSA.ConsultaMovimientosPorCajaxEstadoFinanciero(idCaja)

        For Each i In ListacajausuarioXEntidadFinanciera

            Dim dr As DataRow = dt.NewRow()

            dr(0) = i.tipo
            dr(1) = i.DetalleItem
            Select Case i.codigo
                Case 1
                    dr(2) = ("NACIONAL")
                    dr(3) = i.montoSoles
                Case 2
                    dr(2) = ("EXTRANJERA")
                    dr(3) = i.montoUsd
            End Select

            dt.Rows.Add(dr)

        Next
        dgvEntidad.DataSource = dt

    End Sub

    Public Sub GetAsignacionesDetallado()
        ''Dim usuario As New Usuario
        'Dim ListacajausuarioXEntidadFinanciera As New List(Of documentoCaja)
        'Dim DocCajaSA As New DocumentoCajaSA
        'dgvEntidad.Table.Records.DeleteAll()

        Dim dt As New DataTable("Entidades financieras")
        dt.Columns.Add(New DataColumn("tipoEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("moneda", GetType(String)))
        dt.Columns.Add(New DataColumn("importeApertura", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ingreso", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("egreso", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("total", GetType(Decimal)))

        'listaCajaUsuario = cajaUsuarioSA.ObtenerCajaUsuarioFull


        'ListacajausuarioXEntidadFinanciera = DocCajaSA.ResumenCiereCaja(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, idCaja, "A")

        For Each i In ListacajausuarioXEntidadFinanciera

            Dim dr As DataRow = dt.NewRow()

            dr(0) = i.tipo
            dr(1) = i.DetalleItem
            Select Case i.codigo
                Case 1
                    dr(2) = ("NACIONAL")
                    dr(3) = i.montoSoles
                Case 2
                    dr(2) = ("EXTRANJERA")
                    dr(3) = i.montoUsd
            End Select
            dr(4) = i.MontoIngresosMN
            dr(5) = i.MontoEgresosMN
            dr(6) = CDec((i.montoSoles + i.MontoIngresosMN) - i.MontoEgresosMN)
            dt.Rows.Add(dr)
            saldoGeneral += dr(6)
            FIngreso = i.MontoIngresosMN
            FEgreso = i.MontoEgresosMN
        Next
        dgvResumen.DataSource = dt
        DigitalGauge2.Value = saldoGeneral
    End Sub


    Public Sub CerrarCajaUsuario()
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim objcajaUsuario As New cajaUsuario
        Dim nDocumento As New documento
        Dim asiento As New asiento
        Dim ListaAsiento As New List(Of asiento)
        Try
            With objcajaUsuario
                .idcajaUsuario = CInt(txtUsuariocaja.Tag)
                .fechaCierre = DateTimePickerAdv1.Value
                .enUso = "N"
                .estadoCaja = "C"
                .otrosEgresosMN = 0 ' nudImporteEgresosmn.Value
                .otrosEgresosME = 0 ' nudImporteEgresosme.Value
                .ingresoAdicMN = 0 ' nudIngresoMN.Value
                .ingresoAdicME = 0 'nudIngresoME.Value
                .idCajaCierre = 0 ' txtCajaDestino.ValueMember
            End With

            nDocumento.CustomDocumentoCaja = Nothing

            Dim cajausuario As cajaUsuario = cajaUsuarioSA.CerrarCajaUsuario(objcajaUsuario, nDocumento)
            Tag = "cerrado"

            'If MessageBoxAdv.Show("Desea mostrar reporte de cierre?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then

            GetImpresionTickets(cajausuario)
            Dispose()
            'cajaUsuarioSA.CerrarCajaUsuario(objcajaUsuario, nDocumento)
            'Tag = "cerrado"

            'If MessageBoxAdv.Show("Desea mostrar reporte de cierre?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            '    If Not IsNothing(txtUsuariocaja.Text) Then
            '        With frmCajaUsuarioCierre
            '            '.ConsultaReporte(txtUsuariocaja.Tag, idPersona, txtUsuariocaja.Text, dniPerCaja, txtfecApertura.Text)
            '            '.ConsultaReporte(cajausuario, txtUsuariocaja.Text, dniPerCaja)
            '            .ConsultaReporte(Nothing, txtUsuariocaja.Text, dniPerCaja, FIngreso, FEgreso, DigitalGauge2.Value, FFondo)
            '            .ShowDialog()
            '            Dispose()
            '        End With
            '    End If
            'Else
            '    Dispose()
            'End If

        Catch ex As Exception
            Tag = Nothing
            'lblEstado.Text = ex.Message
            'lblEstado.Image = My.Resources.warning2
        End Try
    End Sub


    Private Sub GetImpresionTickets(cajaBE As cajaUsuario)

        'Dim impresionTicketDoc = listaDocumento.Where(Function(o) o.tipoVenta = TIPO_VENTA.VENTA_POS_DIRECTA).FirstOrDefault
        'If impresionTicketDoc IsNot Nothing Then
        If MessageBox.Show("Desea imprimir el resúmen ?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ImprimirTicket(cajaBE)
        End If

        'End If

        'Dim impresionNota = listaDocumento.Where(Function(o) o.tipoVenta = TIPO_VENTA.NOTA_DE_VENTA).FirstOrDefault
        'If impresionNota IsNot Nothing Then
        '    If MessageBox.Show("Desea imprimir la nota de venta ?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
        '        ImprimirTicket(impresionNota.idDocumento)
        '    End If
        'End If
    End Sub

    Sub ImprimirTicket(CajaBE As cajaUsuario)
        Dim gravMN As Decimal = 0
        Dim gravME As Decimal = 0
        Dim ExoMN As Decimal = 0
        Dim ExoME As Decimal = 0
        Dim InaMN As Decimal = 0
        Dim InaME As Decimal = 0
        Dim ticket As New CrearTicket()

        Dim documentoSA As New DocumentoCajaSA
        Dim documentoCajaBE As New documentoCaja
        Dim cajaUsuarioBE As New cajaUsuario
        Dim cajaUsuarioSA As New cajaUsuarioDetalleSA

        documentoCajaBE = documentoCajaBE
        documentoCajaBE.idEmpresa = Gempresas.IdEmpresaRuc
        documentoCajaBE.idEstablecimiento = GEstableciento.IdEstablecimiento
        documentoCajaBE.idCajaUsuario = CajaBE.idcajaUsuario

        Dim comprobante As documentoCaja = documentoSA.DocCajaXResumenXID(documentoCajaBE)

        'Ya podemos usar todos sus metodos
        ticket.AbreCajon()
        'Para abrir el cajon de dinero.
        'De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

        'Datos de la cabecera del Ticket.
        ticket.TextoCentro(Gempresas.NomEmpresa)
        'ticket.TextoCentro("ERM NEGOCIOS SAC.")
        'ticket.TextoCentro("JR. GN. SANTA CRUZ 481 INT-1506")
        'ticket.TextoCentro("JESUS MARIA - LIMA PERU")
        'ticket.TextoCentro("SUC: JR.SEBASTIAN LORENTE 199 TAMBO-HYO.")
        ticket.TextoCentro(Gempresas.IdEmpresaRuc)
        '   ticket.TextoIzquierda("EMAIL: cmcmarce14@gmail.com")
        'Es el mio por si me quieren contactar ...
        ticket.TextoIzquierda("")

        'ticket.TextoIzquierda("Ticket voucher")

        ticket.lineasHorizontales()
        'Sub cabecera.
        'ticket.TextoIzquierda("")

        Dim UsuarioSA As New UsuarioSA
        Dim usuariobE As New Usuario

        usuariobE = New Usuario
        usuariobE.IDUsuario = CajaBE.idPersona

        If CajaBE.idPersona <> 0 Then
            Dim usuario = UsuarioSA.UbicarUsuarioXid(usuariobE)
            Dim NBoletaElectronica As String = "Cajero: " & usuario.Nombres & " " & usuario.ApellidoPaterno & " " & usuario.ApellidoMaterno
            ticket.TextoIzquierda(NBoletaElectronica)

            ticket.TextoIzquierda("DNI.: " & usuario.NroDocumento)

        Else
            'Dim NBoletaElectronica As String = "Cliente: " & comprobante.nombrePedido
            'ticket.TextoIzquierda(NBoletaElectronica)

        End If
        ticket.TextoIzquierda("COD. MAQUINA REG.: USAFIKA12050121")
        ticket.TextoIzquierda("")
        ticket.TextoExtremos("FECHA: " + Date.Now.Date.ToShortDateString(), "HORA: " + Date.Now.ToShortTimeString())
        ticket.lineasHorizontales()

        'Articulos a vender.
        ticket.EncabezadoVentaV3()
        'NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
        'ticket.lineasAsteriscos()
        ticket.lineasHorizontales()
        ticket.TextoExtremos("APERTURA: ", CDec(CajaBE.fondoMN))
        ticket.TextoExtremos("INGRESOS: ", CDec(comprobante.otrasEntradas))
        ticket.TextoExtremos("EGRESOS: ", "(" & CDec(comprobante.otrasSalidas) & ")")

        ticket.lineasHorizontales()

        'Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.
        ''La M indica que es un decimal en C#
        'ticket.TextoIzquierda("")
        ticket.AgregarTotales("         TOTAL.......S/.", (CDec(CajaBE.fondoMN) + (CDec(comprobante.otrasEntradas)) - CDec(comprobante.otrasSalidas)))
        ticket.TextoIzquierda("")

        ticket.TextoIzquierda("")
        ticket.TextoIzquierda("")
        ticket.TextoExtremos("   ______________", "_________   ")
        ticket.TextoExtremos("    JEFE DE CAJA", "CAJERO     ")
        'ticket.TextoIzquierda("")
        'ticket.TextoCentro("¡GRACIAS TODO CONFORME!")
        ticket.CortaTicket()

        ticket.ImprimirTicket("POS-80C")
        ' ticket.ImprimirTicket("BIXOLON SRP-270")
        'Nombre de la impresora ticketera

    End Sub

#End Region

#Region "Events"

    Private Sub frmCerrarCajaUsuario_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmCerrarCajaUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePickerAdv1.Value = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        ToolStripLabel4.Text = GEstableciento.NombreEstablecimiento
        ToolStripLabel2.Text = Gempresas.NomEmpresa
    End Sub

#End Region

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        CerrarCajaUsuario()
    End Sub
End Class