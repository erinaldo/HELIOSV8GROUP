Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess

Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping

Imports Syncfusion.DocIO
Imports Syncfusion.DocIO.DLS
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports System.Data.OleDb
Imports System.Data.SqlServerCe
Imports System.ComponentModel

Public Class frmPrestamosMaster
    Inherits frmMaster

    Dim filter As GridDynamicFilter = New GridDynamicFilter()
    Dim filter1 As GridDynamicFilter = New GridDynamicFilter()
    Private lblPeriodo As System.Windows.Forms.ToolStripLabel
    Private lblPeriodoLabel As System.Windows.Forms.ToolStripLabel

    Private Sub ConfiguracionInicio()
        'Me.RibbonControlAdv1.QuickPanelVisible = True
        Me.lblPeriodo = New System.Windows.Forms.ToolStripLabel()
        Me.lblPeriodoLabel = New System.Windows.Forms.ToolStripLabel()
        Me.lblPeriodoLabel.Text = "Período:"
        Me.lblPeriodoLabel.Font = New Font("Segoe UI", 8.25, FontStyle.Bold)
        lblPeriodoLabel.Enabled = False

        Me.lblPeriodo.Font = New Font("Segoe UI", 8.25)
        ' Set the text and DisplayStyle property.
        Me.lblPeriodo.Text = PeriodoGeneral
        lblPeriodo.Enabled = False
        Me.lblPeriodo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text

        ' Add the toolstripbutton in the header of the RibbonControlAdv.
        'Me.RibbonControlAdv1.Header.AddQuickItem(Me.lblPeriodoLabel)
        'Me.RibbonControlAdv1.Header.AddQuickItem(Me.lblPeriodo) 'ToolStripSeparator1
        '   Me.RibbonControlAdv1.Header.AddQuickItem(Me.ToolStripSeparator1)
        'RibbonControlAdv1.RibbonHeaderImage = Syncfusion.Windows.Forms.Tools.RibbonHeaderImage.Birds
        'Me.rbnPrincipal.Header.AddQuickItem(btnAnio)
        'Me.rbnPrincipal.Header.AddQuickItem(cboAnio)
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ConfiguracionInicio()
        ' Add any initialization after the InitializeComponent() call.
        'TabPageAdv1.Parent = TabControlAdv1
        'TabPageAdv2.Parent = Nothing
    End Sub

#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean

        'If Not parpadear Then
        '    lblEstado.ForeColor = lblEstado.BackColor
        '    lblEstado.BackColor = Color.Yellow
        'Else
        '    lblEstado.ForeColor = SystemColors.WindowText
        'End If

        parpadear = Not parpadear
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If TiempoRestante > 0 Then
            parpadeo()

            'lblAgregar.Visible = True
            'lblMensaje.Visible = True
            'tsSave.Enabled = False
            'lblMensaje.Text = "Agregar otro en: " & TiempoRestante
            TiempoRestante = TiempoRestante - 1
        ElseIf TiempoRestante = 0 Then
            Timer1.Enabled = False
            'lblEstado.ForeColor = Color.Navy
            'lblEstado.BackColor = Color.Transparent
            PanelError.Visible = False
            '      Dispose()
        Else
            Timer1.Enabled = False
            'Ejecuta tu función cuando termina el tiempo
            TiempoEjecutar(10)

        End If
    End Sub
    Private TiempoRestante As Integer
    Public Sub TimerOn(ByRef Interval As Short)
        If Interval > 0 Then
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
        End If

    End Sub
    Public Function TiempoEjecutar(ByVal Tiempo As Integer)
        TiempoEjecutar = ""
        TiempoRestante = Tiempo  ' 1 minutos=60 segundos 
        Timer1.Interval = 400

        Call TimerOn(1000) ' Hechanos a andar el timer
    End Function
#End Region

#Region "Método Listas"


    'cobros prestamos




    Public Sub CargarEntidadesXtipo2(strTipo As String, strBusqueda As String)
        Dim entidadSA As New entidadSA
        Try
            lsvProveedor2.Items.Clear()
            For Each i As entidad In entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.PROVEEDOR, strBusqueda)
                Dim n As New ListViewItem(i.idEntidad)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(i.cuentaAsiento)
                n.SubItems.Add(i.nrodoc)
                lsvProveedor2.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Sub CargarEntidadesXtipo(strTipo As String, strBusqueda As String)
        Dim entidadSA As New entidadSA
        Try
            lsvProveedor.Items.Clear()
            For Each i As entidad In entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.PROVEEDOR, strBusqueda)
                Dim n As New ListViewItem(i.idEntidad)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(i.cuentaAsiento)
                n.SubItems.Add(i.nrodoc)
                lsvProveedor.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub


    Private Function ListaDeAprobadosDesembolsado(intIdBeneficiario As Integer) As DataTable
        Dim PrestamoSA As New prestamosSA

        Dim tabla As New tablaDetalleSA
        Dim entidad As New entidadSA
        '    Dim DatoRepetido As Boolean

        Dim dt As New DataTable("Prestámos para Desembolsar")

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("DocPrestamo", GetType(String)))
        dt.Columns.Add(New DataColumn("nroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaPrestamo", GetType(Date)))
        dt.Columns.Add(New DataColumn("idBeneficiario", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Beneficiario", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUSD", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("desembolso", GetType(String)))


        For Each i As prestamos In PrestamoSA.ObtenerPrestamosAprobadosDesembolsado(intIdBeneficiario, "POT")
            Dim dr As DataRow = dt.NewRow()


            dr(0) = i.idDocumento
            dr(1) = i.DocPrestamo
            dr(2) = tabla.GetUbicarTablaID(10, i.DocPrestamo).descripcion
            dr(3) = i.nroDoc
            dr(4) = i.fechaPrestamo
            dr(5) = i.idBeneficiario
            dr(6) = entidad.UbicarEntidadPorIdentidad(Gempresas.IdEmpresaRuc, i.tipoBeneficiario, i.idBeneficiario).nombre
            dr(7) = i.tipoCambio
            dr(8) = i.monto
            dr(9) = i.montoUSD
            dr(10) = i.desembolso

            dt.Rows.Add(dr)
        Next
        Return dt
    End Function



    Private Function ListaDesembolsoApto(tipo As String) As DataTable
        Dim PrestamoSA As New prestamosSA

        Dim tabla As New tablaDetalleSA
        Dim entidad As New entidadSA
        '    Dim DatoRepetido As Boolean

        Dim dt As New DataTable("Prestámos para Desembolsar")

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("DocPrestamo", GetType(String)))
        'dt.Columns.Add(New DataColumn("nroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaPrestamo", GetType(Date)))
        dt.Columns.Add(New DataColumn("idBeneficiario", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Beneficiario", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUSD", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("desembolso", GetType(String)))

        dt.Columns.Add(New DataColumn("colInteresSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("colInteresUSD", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("Seguro", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("SeguroME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("Otro", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("otroME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("Portes", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("PortesME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("EnvioCuenta", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("EnvCuentaME", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("NumCuotas", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ModoPago", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaInicio", GetType(Date)))
        dt.Columns.Add(New DataColumn("diaPago", GetType(Integer)))
        dt.Columns.Add(New DataColumn("gracia", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipo", GetType(String)))


        For Each i As prestamos In PrestamoSA.ObtenerDesembolsoApto(Gempresas.IdEmpresaRuc, tipo)
            Dim dr As DataRow = dt.NewRow()

            dr(0) = i.idDocumento
            dr(1) = i.DocPrestamo
            dr(2) = tabla.GetUbicarTablaID(10, i.DocPrestamo).descripcion
            'dr(3) = i.nroDoc
            dr(3) = i.fechaPrestamo
            dr(4) = i.idBeneficiario
            dr(5) = entidad.UbicarEntidadPorIdentidad(Gempresas.IdEmpresaRuc, i.tipoBeneficiario, i.idBeneficiario).nombre
            dr(6) = i.tipoCambio
            dr(7) = i.monto
            dr(8) = i.montoUSD
            dr(9) = i.desembolso

       

            Dim cuota As Decimal = i.numCuotas
            dr(20) = CDec(cuota)
            dr(21) = i.modoPago
            dr(22) = i.fechaInicio
            dr(23) = i.diaPago
            dr(24) = i.plazoDias
            dr(25) = i.tipo

            dt.Rows.Add(dr)
        Next
        Return dt
    End Function



    Private Function ListaDesembolso(intIdBeneficiario As Integer) As DataTable
        Dim PrestamoSA As New prestamosSA

        Dim tabla As New tablaDetalleSA
        Dim entidad As New entidadSA
        Dim entidadSA As New entidadSA
        Dim personaSA As New PersonaSA

        '    Dim DatoRepetido As Boolean

        Dim dt As New DataTable("Prestámos para Desembolsar")

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("DocPrestamo", GetType(String)))
        'dt.Columns.Add(New DataColumn("nroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaPrestamo", GetType(Date)))
        dt.Columns.Add(New DataColumn("idBeneficiario", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Beneficiario", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUSD", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("desembolso", GetType(String)))

        dt.Columns.Add(New DataColumn("colInteresSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("colInteresUSD", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("Seguro", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("SeguroME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("Otro", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("otroME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("Portes", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("PortesME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("EnvioCuenta", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("EnvCuentaME", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("NumCuotas", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ModoPago", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaInicio", GetType(Date)))
        dt.Columns.Add(New DataColumn("diaPago", GetType(Integer)))
        dt.Columns.Add(New DataColumn("gracia", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipo", GetType(String)))


        For Each i As prestamos In PrestamoSA.ObtenerPrestamosAprobadosBeneficiario(intIdBeneficiario, "POT")
            Dim dr As DataRow = dt.NewRow()

            dr(0) = i.idDocumento
            dr(1) = i.DocPrestamo
            dr(2) = tabla.GetUbicarTablaID(10, i.DocPrestamo).descripcion
            'dr(3) = i.nroDoc
            dr(3) = i.fechaPrestamo
            dr(4) = i.idBeneficiario
            ' dr(5) = entidad.UbicarEntidadPorIdentidad(Gempresas.IdEmpresaRuc, i.tipoBeneficiario, i.idBeneficiario).nombre
            Select Case i.tipoBeneficiario
                Case TIPO_ENTIDAD.PROVEEDOR

                    With entidadSA.UbicarEntidadPorID(i.idBeneficiario).First
                        dr(5) = .nombreCompleto
                    End With
                Case TIPO_ENTIDAD.CLIENTE

                    With entidadSA.UbicarEntidadPorID(i.idBeneficiario).First
                        dr(5) = .nombreCompleto
                    End With
                Case "TR"
                    dr(3) = "Trabajador"
                    With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.idBeneficiario, "TR")
                        dr(5) = .nombreCompleto
                    End With
                Case "OT"

                    With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.idBeneficiario, "OT")
                        dr(5) = .nombreCompleto
                    End With
            End Select


            dr(6) = i.tipoCambio
            dr(7) = i.monto
            dr(8) = i.montoUSD
            dr(9) = i.desembolso

            dr(10) = i.montoInteresSoles
            dr(11) = i.montoInteresUSD
            dr(12) = i.montoSeguroMN
            dr(13) = i.montoSeguroME
            dr(14) = i.montoOtroMN
            dr(15) = i.montoOtroME
            dr(16) = i.montoPorteMN
            dr(17) = i.montoPorteME
            dr(18) = i.montoEnvCuentaMN
            dr(19) = i.montoEnvCuentaME

            Dim cuota As Decimal = i.numCuotas
            dr(20) = CDec(cuota)
            dr(21) = i.modoPago
            dr(22) = i.fechaInicio
            dr(23) = i.diaPago
            dr(24) = i.plazoDias
            dr(25) = i.tipo

            dt.Rows.Add(dr)
        Next
        Return dt
    End Function





    Private Function ListaPrestamosPorBeneficiario(intIdBeneficiario As Integer) As DataTable
        Dim documentoPrestamoSA As New documentoPrestamoSA
        '    Dim DatoRepetido As Boolean

        Dim dt As New DataTable("Prestámos usuario: " & txtNroBusqueda.Text.Trim)

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("TipoDocPrestamo", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("NroPrestamo", GetType(String)))
        dt.Columns.Add(New DataColumn("moneda", GetType(String)))

        dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("CapitalMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("CapitalME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("CapitalIMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("CapitalIME", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("fechaVcto", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDocumento", GetType(String)))
        dt.Columns.Add(New DataColumn("idCuota", GetType(Integer)))
        dt.Columns.Add(New DataColumn("referencia", GetType(String)))
        dt.Columns.Add(New DataColumn("entidadFinanciera", GetType(String)))
        dt.Columns.Add(New DataColumn("montoSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoDolares", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoInteresSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoInteresUSD", GetType(Decimal)))

        '''''''''''''''''''''''''''''
        dt.Columns.Add(New DataColumn("montoSeguro", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoSeguroME", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("montoOtro", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoOtroME", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("montoPortes", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoPortesME", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("montoEnvCuenta", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoEnvCuentaME", GetType(Decimal)))


        dt.Columns.Add(New DataColumn("IntMoratorio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("IntCompensatorio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("Otro1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("Otro2", GetType(Decimal)))
        '''''''''''''''''''''''''''''''

        dt.Columns.Add(New DataColumn("ImportePagoCapitalMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ImportePagoCapitalME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ImportePagoInteresMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ImportePagoInteresME", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("ImportePagoSeguroMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ImportePagoSeguroME", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("ImportePagoOtroMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ImportePagoOtroME", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("ImportePagoPorteMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ImportePagoPorteME", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("ImportePagoCuentaMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ImportePagoCuentaME", GetType(Decimal)))


        Dim str As String
        For Each i As documentoPrestamos In documentoPrestamoSA.ListadoPrestamosPendientes(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, intIdBeneficiario, PeriodoGeneral, "PO")
            Dim dr As DataRow = dt.NewRow()

            str = Nothing
            str = CDate(i.fecha).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.TipoDocPrestamo
            dr(2) = i.NroPrestamo
            dr(3) = i.moneda
            dr(4) = i.tipoCambio
            dr(5) = i.CapitalMN
            dr(6) = i.CapitalME
            dr(7) = i.CapitalIMN
            dr(8) = i.CapitalIME
            str = CDate(i.fechaVcto).ToString("dd-MMM")
            dr(9) = str
            dr(10) = i.numeroDocumento
            dr(11) = i.idCuota
            dr(12) = i.referencia

            dr(14) = i.montoSoles
            dr(15) = i.montoDolares

            


            If DateTime.Now.Date > i.fechaPlazo Then


                
            Else


                dr(26) = CDec(0)
                dr(27) = CDec(0)
                dr(28) = CDec(0)
                dr(29) = CDec(0)
            End If


            If i.ImportePagoTodoMN > 0 Then

                dr(30) = i.montoSoles
                dr(31) = i.montoDolares
               


            Else

                dr(30) = i.ImportePagoCapitalMN
                dr(31) = i.ImportePagoCapitalME
                dr(32) = i.ImportePagoInteresMN
                dr(33) = i.ImportePagoInteresME
                dr(34) = i.ImportePagoSeguroMN
                dr(35) = i.ImportePagoSeguroME
                dr(36) = i.ImportePagoOtroMN
                dr(37) = i.ImportePagoOtroME
                dr(38) = i.ImportePagoPorteMN
                dr(39) = i.ImportePagoPorteME
                dr(40) = i.ImportePagoEnvCueMN
                dr(41) = i.ImportePagoEnvCueME

            End If





            dt.Rows.Add(dr)
        Next
        Return dt
    End Function


    Public Sub PrestamosDesembolsoAprobado2(idbene As Integer)
        Try

            Dim parentTable As DataTable = ListaDeAprobadosDesembolsado(idbene)
            Me.GridGroupingControl1.DataSource = parentTable
            Me.dgvCobroPrestamo.Refresh()
            GridGroupingControl1.TableDescriptor.Relations.Clear()
            GridGroupingControl1.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            GridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
            GridGroupingControl1.Appearance.AnyRecordFieldCell.Enabled = False
            'dgvPrestamosUser2.GroupDropPanel.Visible = True
            'dgvPrestamosUser2.TableDescriptor.GroupedColumns.Clear()
            'dgvPrestamosUser2.TableDescriptor.GroupedColumns.Add("TipoDocPrestamo")

        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub


    Public Sub PrestamosDesembolsoAprobado()
        Try

            Dim parentTable As DataTable = ListaDeAprobadosDesembolsado(txtNroBusqueda.Tag)
            Me.GridGroupingControl1.DataSource = parentTable
            Me.dgvCobroPrestamo.Refresh()
            GridGroupingControl1.TableDescriptor.Relations.Clear()
            GridGroupingControl1.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            GridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
            GridGroupingControl1.Appearance.AnyRecordFieldCell.Enabled = False
            'dgvPrestamosUser2.GroupDropPanel.Visible = True
            'dgvPrestamosUser2.TableDescriptor.GroupedColumns.Clear()
            'dgvPrestamosUser2.TableDescriptor.GroupedColumns.Add("TipoDocPrestamo")

        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub



    Public Sub PrestamosDesembolsoAptos(tipo As String)
        Try

            Dim parentTable As DataTable = ListaDesembolsoApto(tipo)
            Me.dgvPrestamosUser2.DataSource = parentTable
            Me.dgvPrestamosUser2.Refresh()
            dgvPrestamosUser2.TableDescriptor.Relations.Clear()
            dgvPrestamosUser2.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            dgvPrestamosUser2.TableOptions.ListBoxSelectionMode = SelectionMode.One
            dgvPrestamosUser2.Appearance.AnyRecordFieldCell.Enabled = False
            'dgvPrestamosUser2.GroupDropPanel.Visible = True
            'dgvPrestamosUser2.TableDescriptor.GroupedColumns.Clear()
            'dgvPrestamosUser2.TableDescriptor.GroupedColumns.Add("TipoDocPrestamo")


        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub


    Public Sub PrestamosDesembolsoTipo(numero As Integer)
        Try

            Dim parentTable As DataTable = ListaDesembolso(numero)
            Me.dgvPrestamosUser2.DataSource = parentTable
            Me.dgvPrestamosUser2.Refresh()
            dgvPrestamosUser2.TableDescriptor.Relations.Clear()
            dgvPrestamosUser2.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            dgvPrestamosUser2.TableOptions.ListBoxSelectionMode = SelectionMode.One
            dgvPrestamosUser2.Appearance.AnyRecordFieldCell.Enabled = False

        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub



    Public Sub PrestamosDesembolso()
        Try

            Dim parentTable As DataTable = ListaDesembolso(txtNroBusqueda.Tag)
            Me.dgvPrestamosUser2.DataSource = parentTable
            Me.dgvPrestamosUser2.Refresh()
            dgvPrestamosUser2.TableDescriptor.Relations.Clear()
            dgvPrestamosUser2.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            dgvPrestamosUser2.TableOptions.ListBoxSelectionMode = SelectionMode.One
            dgvPrestamosUser2.Appearance.AnyRecordFieldCell.Enabled = False
            'dgvPrestamosUser2.GroupDropPanel.Visible = True
            'dgvPrestamosUser2.TableDescriptor.GroupedColumns.Clear()
            'dgvPrestamosUser2.TableDescriptor.GroupedColumns.Add("TipoDocPrestamo")





        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub


    Public Sub PrestamosPorUsuario()
        'Try

        '    Dim parentTable As DataTable = ListaPrestamosPorBeneficiario(txtNroBusqueda.Tag)
        '    Me.dgvPrestamosUser.DataSource = parentTable
        '    Me.dgvPrestamosUser.Refresh()
        '    dgvPrestamosUser.TableDescriptor.Relations.Clear()
        '    dgvPrestamosUser.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
        '    dgvPrestamosUser.TableOptions.ListBoxSelectionMode = SelectionMode.One
        '    dgvPrestamosUser.Appearance.AnyRecordFieldCell.Enabled = False
        '    dgvPrestamosUser.GroupDropPanel.Visible = True
        '    dgvPrestamosUser.TableDescriptor.GroupedColumns.Clear()
        '    dgvPrestamosUser.TableDescriptor.GroupedColumns.Add("TipoDocPrestamo")

        'Catch ex As Exception
        '    MsgBox(ex)
        'End Try
    End Sub


    Public Sub PrestamosEmitidosAprobar()
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim grupoActual As String = String.Empty
        Dim g As New ListViewGroup
        Try

            Dim parentTable As DataTable = getParentTablePrestamosParaAprobar()
            Me.dgvPrestamos2.DataSource = parentTable
            dgvPrestamos2.TableDescriptor.Relations.Clear()
            dgvPrestamos2.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            dgvPrestamos2.TableOptions.ListBoxSelectionMode = SelectionMode.One
            dgvPrestamos2.Appearance.AnyRecordFieldCell.Enabled = False
            dgvPrestamos2.GroupDropPanel.Visible = True
            dgvPrestamos2.TableDescriptor.GroupedColumns.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Sub PrestamosEmitidos()
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim grupoActual As String = String.Empty
        Dim g As New ListViewGroup
        Try

            Dim parentTable As DataTable = getParentTablePrestamosEmitidos()
            Me.dgvPrestamos.DataSource = parentTable
            dgvPrestamos.TableDescriptor.Relations.Clear()
            dgvPrestamos.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            dgvPrestamos.TableOptions.ListBoxSelectionMode = SelectionMode.One
            dgvPrestamos.Appearance.AnyRecordFieldCell.Enabled = False
            dgvPrestamos.GroupDropPanel.Visible = True
            dgvPrestamos.TableDescriptor.GroupedColumns.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Dim parentTable As New DataTable

    Public Sub PrestamosEmitidosXPeriodo()
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim grupoActual As String = String.Empty
        Dim g As New ListViewGroup
        Try

            parentTable = getParentTablePrestamosEmitidosXperiodo()
            Me.dgvPrestamos.DataSource = parentTable
            dgvPrestamos.TableDescriptor.Relations.Clear()
            dgvPrestamos.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            dgvPrestamos.TableOptions.ListBoxSelectionMode = SelectionMode.One
            dgvPrestamos.Appearance.AnyRecordFieldCell.Enabled = False
            dgvPrestamos.GroupDropPanel.Visible = True
            dgvPrestamos.TableDescriptor.GroupedColumns.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Sub PrestamosXPeriodo()
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim grupoActual As String = String.Empty
        Dim g As New ListViewGroup
        Try

            parentTable = getParentTablePrestamosXperiodo()
            Me.dgvPrestamos2.DataSource = parentTable
            dgvPrestamos2.TableDescriptor.Relations.Clear()
            dgvPrestamos2.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            dgvPrestamos2.TableOptions.ListBoxSelectionMode = SelectionMode.One
            dgvPrestamos2.Appearance.AnyRecordFieldCell.Enabled = False
            dgvPrestamos2.GroupDropPanel.Visible = True
            dgvPrestamos2.TableDescriptor.GroupedColumns.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Function getParentTablePrestamosParaAprobar() As DataTable
        Dim prestamoSA As New prestamosSA
        Dim entidadSA As New entidadSA
        Dim personaSA As New PersonaSA

        Dim dt As New DataTable("Prestámos emitidos")

        dt.Columns.Add(New DataColumn("codigo", GetType(Integer)))
        dt.Columns.Add(New DataColumn("fechaPrestamo", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("DocPrestamo", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoBeneficiario", GetType(String)))
        dt.Columns.Add(New DataColumn("Beneficiario", GetType(String)))
        dt.Columns.Add(New DataColumn("moneda", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("interes", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tipoActivo", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUSD", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoInteresSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoInteresUSD", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))

        Dim str As String
        For Each i As prestamos In prestamoSA.ObtenerPrestamos(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, "POT")
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaPrestamo).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.codigo
            dr(1) = str
            dr(2) = i.DocPrestamo

            Select Case i.tipoBeneficiario
                Case TIPO_ENTIDAD.PROVEEDOR
                    dr(3) = "Proveedor"
                    With entidadSA.UbicarEntidadPorID(i.idBeneficiario).First
                        dr(4) = .nombreCompleto
                    End With
                Case TIPO_ENTIDAD.CLIENTE
                    dr(3) = "Cliente"
                    With entidadSA.UbicarEntidadPorID(i.idBeneficiario).First
                        dr(4) = .nombreCompleto
                    End With
                Case "TR"
                    dr(3) = "Trabajador"
                    With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.idBeneficiario, "TR")
                        dr(4) = .nombreCompleto
                    End With
                Case "OT"
                    dr(3) = "Otros"
                    With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.idBeneficiario, "OT")
                        dr(4) = .nombreCompleto
                    End With
            End Select
            dr(5) = i.moneda
            dr(6) = i.tipoCambio
            dr(7) = i.interes
            dr(8) = i.tipoActivo
            dr(9) = i.monto
            dr(10) = i.montoUSD
            dr(11) = i.montoInteresSoles
            dr(12) = i.montoInteresUSD
            Select Case i.entregaPendiente
                Case "SI"
                    dr(13) = "Aprobado"
                Case Else
                    dr(13) = "Pendiente"
            End Select

            If i.idDocumento > 0 Then
                dr(14) = i.idDocumento
            End If
            'dr(13) = i.idDocumento

            dt.Rows.Add(dr)
        Next
        Return dt

    End Function


    Private Function getParentTablePrestamosEmitidos() As DataTable
        Dim prestamoSA As New prestamosSA
        Dim entidadSA As New entidadSA
        Dim personaSA As New PersonaSA

        Dim dt As New DataTable("Prestámos emitidos")

        dt.Columns.Add(New DataColumn("codigo", GetType(Integer)))
        dt.Columns.Add(New DataColumn("fechaPrestamo", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("DocPrestamo", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoBeneficiario", GetType(String)))
        dt.Columns.Add(New DataColumn("Beneficiario", GetType(String)))
        dt.Columns.Add(New DataColumn("moneda", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("interes", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tipoActivo", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUSD", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoInteresSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoInteresUSD", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))

        Dim str As String
        For Each i As prestamos In prestamoSA.ObtenerPrestamosEmitidos(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, "POT")
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaPrestamo).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.codigo
            dr(1) = str
            dr(2) = i.DocPrestamo

            Select Case i.tipoBeneficiario
                Case TIPO_ENTIDAD.PROVEEDOR
                    dr(3) = "Proveedor"
                    With entidadSA.UbicarEntidadPorID(i.idBeneficiario).First
                        dr(4) = .nombreCompleto
                    End With
                Case TIPO_ENTIDAD.CLIENTE
                    dr(3) = "Cliente"
                    With entidadSA.UbicarEntidadPorID(i.idBeneficiario).First
                        dr(4) = .nombreCompleto
                    End With
                Case "TR"
                    dr(3) = "Trabajador"
                    With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.idBeneficiario, "TR")
                        dr(4) = .nombreCompleto
                    End With
                Case "OT"
                    dr(3) = "Otros"
                    With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.idBeneficiario, "OT")
                        dr(4) = .nombreCompleto
                    End With
            End Select
            dr(5) = i.moneda
            dr(6) = i.tipoCambio
            dr(7) = i.interes
            dr(8) = i.tipoActivo
            dr(9) = i.monto
            dr(10) = i.montoUSD
            dr(11) = i.montoInteresSoles
            dr(12) = i.montoInteresUSD
            Select Case i.entregaPendiente
                Case "SI"
                    dr(13) = "Aprobado"
                Case Else
                    dr(13) = "Pendiente"
            End Select

            If i.idDocumento > 0 Then
                dr(14) = i.idDocumento
            End If
            'dr(13) = i.idDocumento

            dt.Rows.Add(dr)
        Next
        Return dt

    End Function


    Private Function getParentTablePrestamosEmitidosXperiodo() As DataTable
        Dim prestamoSA As New prestamosSA
        Dim entidadSA As New entidadSA
        Dim personaSA As New PersonaSA

        Dim dt As New DataTable("Prestámos período -" & PeriodoGeneral)

        dt.Columns.Add(New DataColumn("codigo", GetType(Integer)))
        dt.Columns.Add(New DataColumn("fechaPrestamo", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("DocPrestamo", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoBeneficiario", GetType(String)))
        dt.Columns.Add(New DataColumn("Beneficiario", GetType(String)))
        dt.Columns.Add(New DataColumn("moneda", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("interes", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tipoActivo", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUSD", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoInteresSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoInteresUSD", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))

        Dim str As String
        For Each i As prestamos In prestamoSA.ObtenerPrestamosEmitidosXperiodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, PeriodoGeneral, "POT")
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaPrestamo).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.codigo
            dr(1) = str
            dr(2) = i.DocPrestamo

            Select Case i.tipoBeneficiario
                Case TIPO_ENTIDAD.PROVEEDOR
                    dr(3) = "Proveedor"
                    With entidadSA.UbicarEntidadPorID(i.idBeneficiario).First
                        dr(4) = .nombreCompleto
                    End With
                Case TIPO_ENTIDAD.CLIENTE
                    dr(3) = "Cliente"
                    With entidadSA.UbicarEntidadPorID(i.idBeneficiario).First
                        dr(4) = .nombreCompleto
                    End With
                Case "TR"
                    dr(3) = "Trabajador"
                    With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.idBeneficiario, "TR")
                        dr(4) = .nombreCompleto
                    End With
                Case "OT"
                    dr(3) = "Otros"
                    With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.idBeneficiario, "OT")
                        dr(4) = .nombreCompleto
                    End With
            End Select
            dr(5) = i.moneda
            dr(6) = i.tipoCambio
            dr(7) = i.interes
            dr(8) = i.tipoActivo
            dr(9) = i.monto
            dr(10) = i.montoUSD
            dr(11) = i.montoInteresSoles
            dr(12) = i.montoInteresUSD
            Select Case i.entregaPendiente
                Case "SI"
                    dr(13) = "Aprobado"
                Case Else
                    dr(13) = "Pendiente"
            End Select


            If i.idDocumento > 0 Then
                dr(14) = i.idDocumento
            End If


            dt.Rows.Add(dr)
        Next
        Return dt

    End Function


    Private Function getParentTablePrestamosXperiodo() As DataTable
        Dim prestamoSA As New prestamosSA
        Dim entidadSA As New entidadSA
        Dim personaSA As New PersonaSA

        Dim dt As New DataTable("Prestámos período -" & PeriodoGeneral)

        dt.Columns.Add(New DataColumn("codigo", GetType(Integer)))
        dt.Columns.Add(New DataColumn("fechaPrestamo", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("DocPrestamo", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoBeneficiario", GetType(String)))
        dt.Columns.Add(New DataColumn("Beneficiario", GetType(String)))
        dt.Columns.Add(New DataColumn("moneda", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("interes", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tipoActivo", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUSD", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoInteresSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoInteresUSD", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))

        Dim str As String
        For Each i As prestamos In prestamoSA.ObtenerPrestamosXperiodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, PeriodoGeneral, "POT")
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaPrestamo).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.codigo
            dr(1) = str
            dr(2) = i.DocPrestamo

            Select Case i.tipoBeneficiario
                Case TIPO_ENTIDAD.PROVEEDOR
                    dr(3) = "Proveedor"
                    With entidadSA.UbicarEntidadPorID(i.idBeneficiario).First
                        dr(4) = .nombreCompleto
                    End With
                Case TIPO_ENTIDAD.CLIENTE
                    dr(3) = "Cliente"
                    With entidadSA.UbicarEntidadPorID(i.idBeneficiario).First
                        dr(4) = .nombreCompleto
                    End With
                Case "TR"
                    dr(3) = "Trabajador"
                    With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.idBeneficiario, "TR")
                        dr(4) = .nombreCompleto
                    End With
                Case "OT"
                    dr(3) = "Otros"
                    With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.idBeneficiario, "OT")
                        dr(4) = .nombreCompleto
                    End With
            End Select
            dr(5) = i.moneda
            dr(6) = i.tipoCambio
            dr(7) = i.interes
            dr(8) = i.tipoActivo
            dr(9) = i.monto
            dr(10) = i.montoUSD
            dr(11) = i.montoInteresSoles
            dr(12) = i.montoInteresUSD
            Select Case i.entregaPendiente
                Case "SI"
                    dr(13) = "Aprobado"
                Case Else
                    dr(13) = "Pendiente"
            End Select


            If i.idDocumento > 0 Then
                dr(14) = i.idDocumento
            End If


            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
#End Region

#Region "Métodos"

    Private Sub EliminarPrestamo(intCodigo As Integer)
        Dim prestamoSA As New prestamosSA
        Dim prestamo As New prestamos

        With prestamo
            .codigo = intCodigo
        End With
        prestamoSA.EliminarPrePrestamo(prestamo)
        Me.dgvPrestamos.Table.CurrentRecord.Delete()
        PanelError.Visible = True
        Timer1.Enabled = True
        TiempoEjecutar(10)
        lblEstado.Text = "pre préstamo eliminado!"
    End Sub

    Private Sub EliminarPrestamoAprobado(intCodigo As Integer)
        Dim prestamoSA As New prestamosSA
        Dim prestamo As New prestamos

        With prestamo
            .codigo = intCodigo
            .idDocumento = Me.dgvPrestamos.Table.CurrentRecord.GetValue("idDocumento")
        End With
        prestamoSA.EliminarPrestamoAprobado(prestamo)
        Me.dgvPrestamos.Table.CurrentRecord.Delete()
        PanelError.Visible = True
        Timer1.Enabled = True
        TiempoEjecutar(10)
        lblEstado.Text = "préstamo eliminado!"
    End Sub

    'Public Sub UbicarEntidadPorRuc(strTipoEntidad As String, strNro As String)
    '    Dim entidadSA As New entidadSA
    '    Dim entidad As New entidad

    '    entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, strTipoEntidad, strNro)
    '    If Not IsNothing(entidad) Then
    '        With entidad
    '            txtNroBusqueda.Text = .nrodoc
    '            txtNroBusqueda.Tag = .idEntidad
    '            '   txtCuenta.Text = .cuentaAsiento
    '            lblNombre.Text = .nombreCompleto
    '            lblNro.Text = .nrodoc
    '            '    txtRuc.Text = .nrodoc

    '            PrestamosPorUsuario()
    '            'PrestamosDesembolso()
    '        End With
    '    Else
    '        Me.dgvPrestamosUser.Table.Records.SelectAll()
    '        Me.dgvPrestamosUser.Table.Records.DeleteAll()
    '        'txtProveedor.Clear()
    '        'txtProveedor.Clear()
    '        ''    txtCuenta.Clear()
    '        'txtRuc.Clear()
    '        lblNombre.Text = String.Empty
    '        lblNro.Text = String.Empty

    '    End If
    'End Sub


    Public Sub UbicarEntidadPorRucDesem(strTipoEntidad As String, strNro As String)
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, strTipoEntidad, strNro)
        If Not IsNothing(entidad) Then
            With entidad
                txtNroBusqueda.Text = .nrodoc
                txtNroBusqueda.Tag = .idEntidad
                '   txtCuenta.Text = .cuentaAsiento
                lblNombre.Text = .nombreCompleto
                lblNro.Text = .nrodoc
                '    txtRuc.Text = .nrodoc

                'PrestamosPorUsuario()
                PrestamosDesembolso()
            End With
        Else
            Me.dgvPrestamosUser2.Table.Records.SelectAll()
            Me.dgvPrestamosUser2.Table.Records.DeleteAll()
            'txtProveedor.Clear()
            'txtProveedor.Clear()
            ''    txtCuenta.Clear()
            'txtRuc.Clear()
            lblNombre.Text = String.Empty
            lblNro.Text = String.Empty

        End If
    End Sub


    Public Sub UbicarEntidadPorRucDesemAprobado(strTipoEntidad As String, strNro As String)
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, strTipoEntidad, strNro)
        If Not IsNothing(entidad) Then
            With entidad
                txtNroBusqueda.Text = .nrodoc
                txtNroBusqueda.Tag = .idEntidad
                '   txtCuenta.Text = .cuentaAsiento
                lblNombre.Text = .nombreCompleto
                lblNro.Text = .nrodoc
                '    txtRuc.Text = .nrodoc

                'PrestamosPorUsuario()
                PrestamosDesembolsoAprobado()
            End With
        Else
            Me.GridGroupingControl1.Table.Records.SelectAll()
            Me.GridGroupingControl1.Table.Records.DeleteAll()
            'txtProveedor.Clear()
            'txtProveedor.Clear()
            ''    txtCuenta.Clear()
            'txtRuc.Clear()
            lblNombre.Text = String.Empty
            lblNro.Text = String.Empty

        End If
    End Sub


    Public Sub UbicarTrabPorDNI(strNumero As String, strNivel As String)
        Dim personaSA As New PersonaSA
        Dim persona As New Persona

        persona = personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, strNumero, strNivel)
        If Not IsNothing(persona) Then
            With persona
                txtNroBusqueda.Text = .idPersona
                txtNroBusqueda.Tag = .idPersona
                '   txtCuenta.Text = "TR"
                '  txtRuc.Text = .idPersona
                lblNombre.Text = .nombreCompleto
                lblNro.Text = .idPersona
                PrestamosPorUsuario()
            End With
        Else
            lblNombre.Text = String.Empty
            lblNro.Text = String.Empty
            'Me.dgvPrestamosUser.Table.Records.SelectAll()
            'Me.dgvPrestamosUser.Table.Records.DeleteAll()

        End If
    End Sub

    'Private Sub btnNuevoPago(StrCObro As String)
    '    Me.Cursor = Cursors.WaitCursor
    '    Dim objLista As New DocumentoCajaDetalleSA
    '    Dim saldomn As Decimal = 0
    '    Dim saldome As Decimal = 0

    '    Dim cTotalmn As Decimal = 0
    '    Dim cTotalme As Decimal = 0
    '    Dim cCreditomn As Decimal = 0
    '    Dim cCreditome As Decimal = 0
    '    Dim cDebitomn As Decimal = 0
    '    Dim cDebitome As Decimal = 0

    '    Try
    '        With frmCobroPrestamo
    '            .lblTipoPres.Text = "Préstamo otorgado"
    '            .lblTipoPres.Font = New Font("Segoe UI", 8, FontStyle.Bold)
    '            .lblTipoPres.Tag = "PO"
    '            '   .tbFormaPago.ToggleState = Tools.ToggleButtonState.Inactive
    '            .dgvDetalleItems.Rows.Clear()
    '            .manipulacionEstado = ENTITY_ACTIONS.INSERT

    '            .lblIdProveedor = txtNroBusqueda.Tag
    '            .lblNomProveedor = lblNombre.Text
    '            .lblTipoEntidad = cboTipoEntidad.Text
    '            .lblIdDocumento.Text = Me.dgvPrestamosUser.Table.CurrentRecord.GetValue("idDocumento")
    '            Select Case StrCObro
    '                Case "CAPITAL"
    '                    .Label23.Text = "CAPITAL"
    '                    For Each i As documentoCajaDetalle In objLista.ObtenerPagosAcumPrestamos(Me.dgvPrestamosUser.Table.CurrentRecord.GetValue("idDocumento"), "C")
    '                        cTotalmn = Math.Round(CDec(i.MontoDeudaSoles) - CDec(i.MontoPagadoSoles), 2)
    '                        cTotalme = Math.Round(CDec(i.MontoDeudaUSD) - CDec(i.MontoPagadoUSD), 2)
    '                        saldomn += cTotalmn
    '                        saldome += cTotalme
    '                        If cTotalmn > 0 Or cTotalme > 0 Then
    '                            .dgvDetalleItems.Rows.Add(i.idItem, i.DetalleItem, Nothing,
    '                                                       Nothing, cTotalmn, cTotalme,
    '                                                       "0.00", "0.00", "0.00", "0.00", Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT)
    '                        End If

    '                    Next
    '                Case "INTERES"
    '                    .Label23.Text = "INTERES"
    '                    For Each i As documentoCajaDetalle In objLista.ObtenerPagosAcumPrestamos(Me.dgvPrestamosUser.Table.CurrentRecord.GetValue("idDocumento"), "I")
    '                        cTotalmn = Math.Round(CDec(i.notaCreditoMN) - CDec(i.MontoPagadoSoles), 2)
    '                        cTotalme = Math.Round(CDec(i.notaCreditoME) - CDec(i.MontoPagadoUSD), 2)
    '                        saldomn += cTotalmn
    '                        saldome += cTotalme
    '                        If cTotalmn > 0 Or cTotalme > 0 Then
    '                            .dgvDetalleItems.Rows.Add(i.idItem, i.DetalleItem, Nothing,
    '                                                       Nothing, cTotalmn, cTotalme,
    '                                                       "0.00", "0.00", "0.00", "0.00", Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT)
    '                        End If

    '                    Next

    '                Case "SEGURO"
    '                    .Label23.Text = "SEGURO"
    '                    For Each i As documentoCajaDetalle In objLista.ObtenerPagosAcumPrestamos(Me.dgvPrestamosUser.Table.CurrentRecord.GetValue("idDocumento"), "S")
    '                        cTotalmn = Math.Round(CDec(i.seguroMN) - CDec(i.MontoPagadoSoles), 2)
    '                        cTotalme = Math.Round(CDec(i.seguroME) - CDec(i.MontoPagadoUSD), 2)
    '                        saldomn += cTotalmn
    '                        saldome += cTotalme
    '                        If cTotalmn > 0 Or cTotalme > 0 Then
    '                            .dgvDetalleItems.Rows.Add(i.idItem, i.DetalleItem, Nothing,
    '                                                       Nothing, cTotalmn, cTotalme,
    '                                                       "0.00", "0.00", "0.00", "0.00", Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT)
    '                        End If

    '                    Next


    '                Case "TODO"
    '                    .Label23.Text = "TODO"
    '                    For Each i As documentoCajaDetalle In objLista.ObtenerPagosAcumPrestamos(Me.dgvPrestamosUser.Table.CurrentRecord.GetValue("idDocumento"), "T")
    '                        cTotalmn = Math.Round(CDec(i.TodoMN) - CDec(i.MontoPagadoSoles), 2)
    '                        cTotalme = Math.Round(CDec(i.TodoME) - CDec(i.MontoPagadoUSD), 2)
    '                        saldomn += cTotalmn
    '                        saldome += cTotalme
    '                        If cTotalmn > 0 Or cTotalme > 0 Then
    '                            .dgvDetalleItems.Rows.Add(i.idItem, i.DetalleItem, Nothing,
    '                                                       Nothing, cTotalmn, cTotalme,
    '                                                       "0.00", "0.00", "0.00", "0.00", Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT)
    '                        End If

    '                    Next


    '            End Select

    '            'lblPagoMN.Text = saldomn.ToString("N2")
    '            'lblPagoME.Text = saldome.ToString("N2")

    '            ''.nudImporteNac.Maximum = CDec(lblPagoMN.Text)
    '            .lblDeudaPendiente.Text = saldomn.ToString("N2")
    '            .lblDeudaPendienteme.Text = saldome.ToString("N2")

    '            'If CDec(lblPagoMN.Text) <= 0 Then
    '            '    '    MsgBox("El documento ya se encuentra pagado.", MsgBoxStyle.Information, "Aviso del Sistema")
    '            '    lblEstado.Text = "El documento ya se encuentra pagado."
    '            '    PanelError.Visible = True
    '            '    Timer1.Enabled = True
    '            '    TiempoEjecutar(10)
    '            '    Me.Cursor = Cursors.Arrow
    '            '    Exit Sub
    '            'Else
    '            'If .TieneCuentaFinanciera = True Then
    '            .txtFechaComprobante.Value = New Date(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
    '            .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
    '            .txtFechaComprobante.Enabled = False
    '            .lblPerido.Text = lblPeriodo.Text
    '            'If strFormPago = "EFECTIVO" Then
    '            '    .rbEfectivo.Checked = True
    '            '    .LoadEfectivo()
    '            '    .txtNumero.Visible = False
    '            '    .txtNumero.Clear()
    '            'ElseIf strFormPago = "OTROS" Then
    '            '    .rbOtros.Checked = True
    '            '    .LoadOtros()
    '            '    .txtNumero.Visible = True
    '            '    .txtNumero.Clear()
    '            'End If
    '            .cboTipoDoc.Enabled = True
    '            .cboTipoDoc.ReadOnly = False
    '            .StartPosition = FormStartPosition.CenterParent
    '            .ShowDialog()
    '            'Else
    '            '    lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
    '            '    PanelError.Visible = True
    '            '    Timer1.Enabled = True
    '            '    TiempoEjecutar(10)
    '            'End If
    '            '    End If
    '        End With
    '    Catch ex As Exception
    '        lblEstado.Text = ex.Message
    '        PanelError.Visible = True
    '        Timer1.Enabled = True
    '        TiempoEjecutar(10)
    '    End Try



    '    Me.Cursor = Cursors.Arrow
    'End Sub
#End Region

    Public Sub UbicarEntidadPorTipo(strTipoEntidad As String, strNumDoc As String)
        ' SDFS()
        If cboTipoEntidad.Text = "PR" Then
            'UbicarEntidadPorRuc(TIPO_ENTIDAD.PROVEEDOR, strNumDoc)
        ElseIf cboTipoEntidad.Text = "CL" Then
            'UbicarEntidadPorRuc(TIPO_ENTIDAD.CLIENTE, strNumDoc)
        ElseIf cboTipoEntidad.Text = "TR" Then
            'UbicarTrabPorDNI(strNumDoc, "TR")
        ElseIf cboTipoEntidad.Text = "OT" Then
            'UbicarTrabPorDNI(strNumDoc, "OT")
        End If

    End Sub

    Public Sub UbicarDesem(strTipoEntidad As String, strNumDoc As String)

        If cboTipoEntidad.Text = "PR" Then
            UbicarEntidadPorRucDesem(TIPO_ENTIDAD.PROVEEDOR, strNumDoc)
        ElseIf cboTipoEntidad.Text = "CL" Then
            UbicarEntidadPorRucDesem(TIPO_ENTIDAD.CLIENTE, strNumDoc)
        ElseIf cboTipoEntidad.Text = "TR" Then
            UbicarTrabPorDNI(strNumDoc, "TR")
        ElseIf cboTipoEntidad.Text = "OT" Then
            UbicarTrabPorDNI(strNumDoc, "OT")
        End If

    End Sub

    Public Sub UbicarAprobadoDesem(strTipoEntidad As String, strNumDoc As String)

        If cboTipoEntidad.Text = "PR" Then
            UbicarEntidadPorRucDesemAprobado(TIPO_ENTIDAD.PROVEEDOR, strNumDoc)
        ElseIf cboTipoEntidad.Text = "CL" Then
            UbicarEntidadPorRucDesemAprobado(TIPO_ENTIDAD.CLIENTE, strNumDoc)
        ElseIf cboTipoEntidad.Text = "TR" Then
            UbicarTrabPorDNI(strNumDoc, "TR")
        ElseIf cboTipoEntidad.Text = "OT" Then
            UbicarTrabPorDNI(strNumDoc, "OT")
        End If

    End Sub



    Private Sub frmPrestamosMaster_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        Dispose()
    End Sub

    Private Sub frmPrestamosMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Maximized


        If filter IsNot Nothing Then
            filter.LoadCompareOperator()
        End If

        If filter1 IsNot Nothing Then
            filter1.LoadCompareOperator()
        End If
    End Sub



    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        PanelError.Visible = False
        Timer1.Enabled = False
    End Sub



    Private Sub btnHistorialPago_Click(sender As Object, e As EventArgs) Handles btnHistorialPago.Click
        'Me.Cursor = Cursors.WaitCursor
        'With frmHistorialPagoPrestamos
        '    If Not IsNothing(Me.dgvPrestamosUser.Table.CurrentRecord) Then
        '        .HistorialPretamos(Me.dgvPrestamosUser.Table.CurrentRecord.GetValue("idCuota"))
        '        .MaximizeBox = False
        '        .StartPosition = FormStartPosition.CenterParent
        '        .ShowDialog()
        '    End If
        'End With
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnEliminarCompra_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click

    End Sub

    Private Sub btnEditCompra_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click

    End Sub




    Private Sub chFilter2_Click_1(sender As Object, e As EventArgs) Handles chFilter2.Click
        'If chFilter2.Checked Then
        '    filter.WireGrid(dgvPrestamosUser)
        'Else
        '    filter.UnWireGrid(dgvPrestamosUser)
        'End If
    End Sub

    Private Sub chFilter1_Click(sender As Object, e As EventArgs) Handles chFilter1.Click
        'If chFilter1.Checked = True Then
        '    Me.dgvPrestamosUser.TopLevelGroupOptions.ShowFilterBar = True
        '    'Enable the filter for each columns 
        '    For i As Integer = 0 To dgvPrestamosUser.TableDescriptor.Columns.Count - 1
        '        dgvPrestamosUser.TableDescriptor.Columns(i).AllowFilter = True
        '    Next
        'Else
        '    Me.dgvPrestamosUser.TopLevelGroupOptions.ShowFilterBar = False
        'End If
    End Sub



    Private Sub CToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ' btnNuevoPago("CAPITAL")
    End Sub

    Private Sub CInteresToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ' btnNuevoPago("INTERES")
    End Sub

    Private Sub chAgrupa_Click(sender As Object, e As EventArgs) Handles chAgrupa.Click
        'If chAgrupa.Checked Then
        '    dgvPrestamosUser.TableDescriptor.GroupedColumns.Clear()
        '    dgvPrestamosUser.ShowGroupDropArea = True
        'Else
        '    dgvPrestamosUser.TableDescriptor.GroupedColumns.Clear()
        '    dgvPrestamosUser.ShowGroupDropArea = False
        'End If
    End Sub

    Private Sub txtNroBusqueda_Click(sender As Object, e As EventArgs)

    End Sub





    Private Sub CheckBox1_Click(sender As Object, e As EventArgs) Handles CheckBox1.Click, ToolStripCheckBox1.Click
        If CheckBox1.Checked = True Then
            Me.dgvPrestamos.TopLevelGroupOptions.ShowFilterBar = True
            'Enable the filter for each columns 
            For i As Integer = 0 To dgvPrestamos.TableDescriptor.Columns.Count - 1
                dgvPrestamos.TableDescriptor.Columns(i).AllowFilter = True
            Next
        Else
            Me.dgvPrestamos.TopLevelGroupOptions.ShowFilterBar = False
        End If
    End Sub

    Private Sub CheckBox2_Click(sender As Object, e As EventArgs) Handles CheckBox2.Click, cboFormato.Click
        If CheckBox2.Checked Then
            filter1.WireGrid(dgvPrestamos)
        Else
            filter1.UnWireGrid(dgvPrestamos)
        End If
    End Sub

    Private Sub CheckBox3_Click(sender As Object, e As EventArgs) Handles CheckBox3.Click
        If CheckBox3.Checked Then
            dgvPrestamos.TableDescriptor.GroupedColumns.Clear()
            dgvPrestamos.ShowGroupDropArea = True
        Else
            dgvPrestamos.TableDescriptor.GroupedColumns.Clear()
            dgvPrestamos.ShowGroupDropArea = False
        End If
    End Sub

    Private Sub ViewTemplateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewTemplateToolStripMenuItem.Click
        Process.Start("D:\tfs.jiuni\HELIOS\SOFT-CONTABLE\HELIOS.CONT\Helios.Cont.UI.WinForm\PMO\03. Grupo Proceso Ejecucion\Caja y Bancos\Prestámos\Template\Letter Formatting.doc")
    End Sub
    Dim dr As DataRow
    Dim table As DataTable

    Private Sub GenerateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerateToolStripMenuItem.Click
        Dim dataPath As String = "D:\tfs.jiuni\HELIOS\SOFT-CONTABLE\HELIOS.CONT\Helios.Cont.UI.WinForm\PMO\03. Grupo Proceso Ejecucion\Caja y Bancos\Prestámos\Template\" ' Application.StartupPath + "\..\..\..\..\..\..\..\..\Common\Data\DocIO\"

        Try
            ' Create a new document.
            Dim document As New WordDocument()

            ' Loading Template.
            document.Open(System.IO.Path.Combine(dataPath, "Letter Formatting.doc"), FormatType.Doc)

            document.MailMerge.RemoveEmptyParagraphs = True

            'To clear the fields with empty value
            document.MailMerge.ClearFields = True

            'Clear the map fields
            document.MailMerge.MappedFields.Clear()

            'Update the mapping fields

            document.MailMerge.MappedFields.Add("Doc Prestamo", "DocPrestamo")
            Dim fieldname As String() = {"DocPrestamo", "DocPrestamo"}

            Dim fieldvalues As String() = {Me.dgvPrestamos.Table.CurrentRecord.GetValue("Beneficiario"), "David"}

            '    dr = parentTable.Rows(dgvPrestamos.Table.GetRowIndex)
            'Dim fieldname As String() = {"FirstName", "LastName"}
            document.MailMerge.Execute(fieldname, fieldvalues)
            'Dim fieldvalues As String() = {"John", "David"}

            'document.MailMerge.ClearFields = False

            'document.MailMerge.Execute(fieldname, fieldvalues)


            'Add Text Watermark
            document.Watermark = New TextWatermark()
            TryCast(document.Watermark, TextWatermark).Text = "Pre Préstamo"
            TryCast(document.Watermark, TextWatermark).Size = 144

            'Save as word 2003 format
            If cboFormato.Text = "Word 97-2003" Then
                'Saving the document to disk.
                document.Save("Sample.doc")

                'Message box confirmation to view the created document.
                If MessageBoxAdv.Show("Do you want to view the MS Word document?", "Document has been created", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                    'Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                    System.Diagnostics.Process.Start("Sample.doc")
                    'Exit
                    Me.Close()
                End If
                'Save as word 2007 format
            ElseIf cboFormato.Text = "Word 2007" Then
                'Saving the document as .docx
                document.Save("Sample.docx", FormatType.Word2007)
                'Message box confirmation to view the created document.
                If MessageBoxAdv.Show("Do you want to view the MS Word document?", "Document has been created", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                    Try
                        'Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                        System.Diagnostics.Process.Start("Sample.docx")
                        'Exit
                        Me.Close()
                    Catch ex As Win32Exception
                        MessageBoxAdv.Show("Word 2007 is not installed in this system")
                        '        Console.WriteLine(ex__1.ToString())
                    End Try
                End If
                'Save as word 2010  format
            ElseIf cboFormato.Text = "Word 2010" Then
                'Saving the document as .docx
                document.Save("Sample.docx", FormatType.Word2010)
                'Message box confirmation to view the created document.
                If MessageBoxAdv.Show("Do you want to view the MS Word document?", "Document has been created", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                    Try
                        'Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                        System.Diagnostics.Process.Start("Sample.docx")
                        'Exit
                        Me.Close()
                    Catch ex As Win32Exception
                        MessageBoxAdv.Show("Word 2010 is not installed in this system")
                        '  Console.WriteLine(ex__1.ToString())
                    End Try
                End If
                'Save as word 2013  format
            ElseIf cboFormato.Text = "Word 2013" Then
                'Saving the document as .docx
                document.Save("Samplexx.docx", FormatType.Word2013)
                'Message box confirmation to view the created document.
                If MessageBoxAdv.Show("Do you want to view the MS Word document?", "Document has been created", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                    Try
                        'Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                        System.Diagnostics.Process.Start("Samplexx.docx")
                        'Exit
                        '     Me.Close()
                    Catch ex As Win32Exception
                        MessageBoxAdv.Show("Word 2013 is not installed in this system")
                        '    Console.WriteLine(ex__1.ToString())
                    End Try
                End If
            Else
                ' Exit
                ' Me.Close()
            End If
        Catch Ex As Exception
            MessageBoxAdv.Show(Ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End Try
    End Sub

    Private Sub btnEditCompra_Click_1(sender As Object, e As EventArgs) Handles btnEditCompra.Click
        Dim prestamoSA As New prestamosSA
        Me.Cursor = Cursors.WaitCursor
        If prestamoSA.PrestamoEstadoAprobado(Me.dgvPrestamos.Table.CurrentRecord.GetValue("codigo")) = False Then
            With frmPrestamo
                '.Label19.Tag = "O"
                '.Label19.Text = "P. Otorgado"
                .UbicarPrestamoXcodigo(Me.dgvPrestamos.Table.CurrentRecord.GetValue("codigo"))
                .txtFechaComprobante.ShowUpDown = True
                .txtFechaComprobante.ShowDropButton = False
                .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        Else
            lblEstado.Text = "El préstamo ya fue aprobado!!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnEliminarCompra_Click_1(sender As Object, e As EventArgs) Handles btnEliminarCompra.Click
        Dim prestamoSA As New prestamosSA
        Me.Cursor = Cursors.WaitCursor
        If prestamoSA.PrestamoEstadoAprobado(Me.dgvPrestamos.Table.CurrentRecord.GetValue("codigo")) = False Then
            'eliminar prestamo
            If MessageBoxAdv.Show("Desea eliminar el préstamo seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                EliminarPrestamo(Me.dgvPrestamos.Table.CurrentRecord.GetValue("codigo"))
            End If
        Else
            '   lblEstado.Text = "El préstamo ya fue aprobado!!"
            If MessageBoxAdv.Show("Desea eliminar el préstamo seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                EliminarPrestamoAprobado(Me.dgvPrestamos.Table.CurrentRecord.GetValue("codigo"))
            End If

            'PanelError.Visible = True
            'Timer1.Enabled = True
            'TiempoEjecutar(10)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub HistorialPagosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HistorialPagosToolStripMenuItem.Click
        Dim dataPath As String = "D:\tfs.jiuni\HELIOS\SOFT-CONTABLE\HELIOS.CONT\Helios.Cont.UI.WinForm\PMO\03. Grupo Proceso Ejecucion\Caja y Bancos\Prestámos\Template\" ' Application.StartupPath + "\..\..\..\..\..\..\..\..\Common\Data\DocIO\"
        Dim prestamoSA As New prestamosSA
        Dim prestamo As New prestamos
        Dim documentoPrestamoSA As New documentoPrestamoSA
        Try
            ' Create a new document.
            Dim document As New WordDocument()

            ' Loading Template.
            document.Open(System.IO.Path.Combine(dataPath, "Template_historialPrestamo.doc"), FormatType.Doc)

            document.MailMerge.RemoveEmptyParagraphs = True

            'To clear the fields with empty value
            document.MailMerge.ClearFields = True

            'Clear the map fields
            document.MailMerge.MappedFields.Clear()

            'Update the mapping fields
            Dim data As New DataTable()
            data.TableName = "cabecera"
            data.Columns.Add("Beneficiario")
            data.Columns.Add("Nro")
            data.Columns.Add("moneda")
            data.Columns.Add("importe")
            data.Columns.Add("interes")
            data.Columns.Add("montoInteres")

            Dim dr As DataRow = data.NewRow
            dr(0) = Me.dgvPrestamos.Table.CurrentRecord.GetValue("Beneficiario")
            dr(1) = "54" ' Me.dgvPrestamos.Table.CurrentRecord.GetValue("NroPrestamo")
            dr(2) = Me.dgvPrestamos.Table.CurrentRecord.GetValue("moneda")
            dr(3) = Me.dgvPrestamos.Table.CurrentRecord.GetValue("monto")
            dr(4) = Me.dgvPrestamos.Table.CurrentRecord.GetValue("interes")
            dr(5) = Me.dgvPrestamos.Table.CurrentRecord.GetValue("montoInteresSoles")
            data.Rows.Add(dr)

            prestamo = prestamoSA.UbicarPrestamoXcodigoDefault(Me.dgvPrestamos.Table.CurrentRecord.GetValue("codigo"))
            Dim DTDetails As New DataTable
            'DTDetails.TableName = "Detail"
            'DTDetails.Columns.Add("referencia")
            'DTDetails.Columns.Add("fechaVcto")
            'DTDetails.Columns.Add("montoSoles")
            'DTDetails.Columns.Add("montoInteresSoles")
            'DTDetails.Columns.Add("ImportePagoCapitalMN")

            'Dim str As String
            'For Each i As documentoPrestamos In documentoPrestamoSA.ListadoPrestamosPendientes(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, prestamo.idBeneficiario, PeriodoGeneral, "PO")
            '    Dim drx As DataRow = DTDetails.NewRow()
            '    str = Nothing
            '    str = CDate(i.fecha).ToString("dd-MMM hh:mm tt ")
            '    drx(0) = i.referencia
            '    drx(1) = i.fechaVcto
            '    drx(2) = i.montoSoles
            '    drx(3) = i.montoInteresSoles
            '    drx(4) = i.ImportePagoCapitalMN
            '    DTDetails.Rows.Add(drx)
            'Next

            DTDetails = ListaPrestamosPorBeneficiario(prestamo.idBeneficiario)
            DTDetails.TableName = "Detail"
            Dim orderDetails As New DataView(DTDetails)
            '      orderDetails.Sort = "ExtendedPrice DESC"
            document.MailMerge.ExecuteGroup(orderDetails)


            '    dr = parentTable.Rows(dgvPrestamos.Table.GetRowIndex)
            'Dim fieldname As String() = {"FirstName", "LastName"}
            document.MailMerge.Execute(data)
            '  document.MailMerge.ExecuteGroup(DTDetails)
            'Dim fieldvalues As String() = {"John", "David"}

            'document.MailMerge.ClearFields = False

            'document.MailMerge.Execute(fieldname, fieldvalues)


            'Add Text Watermark
            'document.Watermark = New TextWatermark()
            'TryCast(document.Watermark, TextWatermark).Text = "Pre Préstamo"
            'TryCast(document.Watermark, TextWatermark).Size = 144

            'Save as word 2003 format
            If cboFormato.Text = "Word 97-2003" Then
                'Saving the document to disk.
                document.Save("Sample.doc")

                'Message box confirmation to view the created document.
                If MessageBoxAdv.Show("Do you want to view the MS Word document?", "Document has been created", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                    'Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                    System.Diagnostics.Process.Start("Sample.doc")
                    'Exit
                    Me.Close()
                End If
                'Save as word 2007 format
            ElseIf cboFormato.Text = "Word 2007" Then
                'Saving the document as .docx
                document.Save("Sample.docx", FormatType.Word2007)
                'Message box confirmation to view the created document.
                If MessageBoxAdv.Show("Do you want to view the MS Word document?", "Document has been created", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                    Try
                        'Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                        System.Diagnostics.Process.Start("Sample.docx")
                        'Exit
                        Me.Close()
                    Catch ex As Win32Exception
                        MessageBoxAdv.Show("Word 2007 is not installed in this system")
                        '        Console.WriteLine(ex__1.ToString())
                    End Try
                End If
                'Save as word 2010  format
            ElseIf cboFormato.Text = "Word 2010" Then
                'Saving the document as .docx
                document.Save("Sample.docx", FormatType.Word2010)
                'Message box confirmation to view the created document.
                If MessageBoxAdv.Show("Do you want to view the MS Word document?", "Document has been created", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                    Try
                        'Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                        System.Diagnostics.Process.Start("Sample.docx")
                        'Exit
                        Me.Close()
                    Catch ex As Win32Exception
                        MessageBoxAdv.Show("Word 2010 is not installed in this system")
                        '  Console.WriteLine(ex__1.ToString())
                    End Try
                End If
                'Save as word 2013  format
            ElseIf cboFormato.Text = "Word 2013" Then
                'Saving the document as .docx
                document.Save("Samplexx.docx", FormatType.Word2013)
                'Message box confirmation to view the created document.
                If MessageBoxAdv.Show("Do you want to view the MS Word document?", "Document has been created", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                    Try
                        'Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                        System.Diagnostics.Process.Start("Samplexx.docx")
                        'Exit
                        '     Me.Close()
                    Catch ex As Win32Exception
                        MessageBoxAdv.Show("Word 2013 is not installed in this system")
                        '    Console.WriteLine(ex__1.ToString())
                    End Try
                End If
            Else
                ' Exit
                ' Me.Close()
            End If
        Catch Ex As Exception
            MessageBoxAdv.Show(Ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End Try
    End Sub

    Private Sub CSeguroToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ' btnNuevoPago("SEGURO")
    End Sub

    Private Sub CtodoToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ' btnNuevoPago("TODO")
    End Sub

    Private Sub k(sender As Object, e As EventArgs)

    End Sub



    Private Sub ButtonAdv15_Click(sender As Object, e As EventArgs) Handles ButtonAdv15.Click
        Me.Cursor = Cursors.WaitCursor
        PrestamosEmitidos()
        lblEstado.Text = "Prestamos del día: " & DateTime.Now.Date
        Timer1.Enabled = True
        PanelError.Visible = True
        TiempoEjecutar(10)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        Me.Cursor = Cursors.WaitCursor
        PrestamosEmitidosXPeriodo()
        lblEstado.Text = "Prestamos del período: " & PeriodoGeneral
        Timer1.Enabled = True
        PanelError.Visible = True
        TiempoEjecutar(10)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton13_Click(sender As Object, e As EventArgs) Handles ToolStripButton13.Click
        Me.Cursor = Cursors.WaitCursor
        With frmPrestamo
            '.Label19.Tag = "O"
            '.Label19.Text = "P. Otorgado"
            .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
            .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            .lblPerido.Text = PeriodoGeneral
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .WindowState = FormWindowState.Maximized
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton14_Click(sender As Object, e As EventArgs) Handles ToolStripButton14.Click
        Dim prestamoSA As New prestamosSA
        Me.Cursor = Cursors.WaitCursor
        If prestamoSA.PrestamoEstadoAprobado(Me.dgvPrestamos.Table.CurrentRecord.GetValue("codigo")) = False Then
            With frmPrestamo
                '.Label19.Tag = "O"
                '.Label19.Text = "P. Otorgado"
                .UbicarPrestamoXcodigo(Me.dgvPrestamos.Table.CurrentRecord.GetValue("codigo"))
                .txtFechaComprobante.ShowUpDown = True
                .txtFechaComprobante.ShowDropButton = False
                .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        Else
            lblEstado.Text = "El préstamo ya fue aprobado!!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton16_Click(sender As Object, e As EventArgs) Handles ToolStripButton16.Click
        Dim prestamoSA As New prestamosSA
        Me.Cursor = Cursors.WaitCursor
        If prestamoSA.PrestamoEstadoAprobado(Me.dgvPrestamos.Table.CurrentRecord.GetValue("codigo")) = False Then
            'eliminar prestamo
            If MessageBoxAdv.Show("Desea eliminar el préstamo seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                EliminarPrestamo(Me.dgvPrestamos.Table.CurrentRecord.GetValue("codigo"))
            End If
        Else
            '   lblEstado.Text = "El préstamo ya fue aprobado!!"
            If MessageBoxAdv.Show("Desea eliminar el préstamo seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                EliminarPrestamoAprobado(Me.dgvPrestamos.Table.CurrentRecord.GetValue("codigo"))
            End If

            'PanelError.Visible = True
            'Timer1.Enabled = True
            'TiempoEjecutar(10)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub



    Private Sub ToolStripButton17_Click(sender As Object, e As EventArgs) Handles ToolStripButton17.Click


        If Not IsNothing(Me.dgvPrestamosUser2.Table.CurrentRecord) Then

            Dim f As New frmNuevoDesembolso
            f.UbicarFechas(Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("idDocumento"))
            f.txtProveedor.Text = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("Beneficiario")
            f.txtProveedor.Tag = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("idBeneficiario")
            f.txtComprobante.Text = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("DocPrestamo")
            f.txtComprobante.Tag = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("tipoDoc")
            f.txtFechaComprobante.Value = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("fechaPrestamo")
            f.txtTipoCambio.Value = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("tipoCambio")
            f.txtFondoMN.Value = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("monto")
            f.txtFondoME.Value = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("montoUSD")
            f.lblIdPrestamo.Text = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("idDocumento")
            f.txtInteresMN.Value = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("colInteresSoles")
            f.txtInteresME.Value = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("colInteresUSD")
            f.txtSeguroMN.Value = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("Seguro")
            f.txtSeguroME.Value = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("SeguroME")
            f.txtOtroMN.Value = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("Otro")
            f.txtOtroME.Value = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("otroME")
            f.txtPortesMN.Value = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("Portes")
            f.txtPortesME.Value = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("PortesME")
            f.txtEnvMN.Value = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("EnvioCuenta")
            f.txtEnvME.Value = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("EnvCuentaME")
            f.txtCuotas.Value = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("NumCuotas")
            f.cboModo.Text = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("ModoPago")
            f.DateTimePickerAdv2.Value = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("fechaInicio")
            f.cboDiaPago.Text = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("diaPago")
            f.cbodiaplazo.Text = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("gracia")
            f.txtTipo.Text = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("tipo")
            f.lblMovimiento.Tag = "OSC"
            f.lblMovimiento.Text = "OTRAS SALIDAS DE CAJA"
            f.CaptionLabels(0).Text = "OTRAS SALIDAS DE CAJA"
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            f.StartPosition = FormStartPosition.CenterParent
            f.WindowState = FormWindowState.Maximized
            f.ShowDialog()
            PrestamosDesembolsoAptos("POT")
            Me.Cursor = Cursors.Arrow

        Else
            lblEstado.Text = "Seleccione un Item"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If


    End Sub

    Private Sub txtNroBusqueda_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtNroBusqueda_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNroBusqueda.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtNroBusqueda.Text.Trim.Length > 0 Then
                UbicarEntidadPorTipo(cboTipoEntidad.Text, txtNroBusqueda.Text.Trim)
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub





    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtNroBusqueda.TextChanged

    End Sub

    Private Sub txtNroBusqueda2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNroBusqueda2.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtNroBusqueda2.Text.Trim.Length > 0 Then
                UbicarDesem(cboTipoEntidad2.Text, txtNroBusqueda2.Text.Trim)
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub



    Private Sub TextBox1_TextChanged_1(sender As Object, e As EventArgs) Handles txtNroBusqueda2.TextChanged

    End Sub

    Private Sub ToolStripButton23_Click(sender As Object, e As EventArgs) Handles ToolStripButton23.Click

        If Not IsNothing(Me.GridGroupingControl1.Table.CurrentRecord) Then

            With frmPrestamosCobro
                .UbicarDocumento(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("idDocumento"))
                .StartPosition = FormStartPosition.CenterParent
                .WindowState = FormWindowState.Maximized
                .ShowDialog()
            End With

        Else
            lblEstado.Text = "Seleccione un Item"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If
    End Sub

    Private Sub ButtonAdv7_Click(sender As Object, e As EventArgs) Handles ButtonAdv7.Click

    End Sub

    Private Sub ToolStripPanelItem1_Click(sender As Object, e As EventArgs) Handles ToolStripPanelItem1.Click

    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtNroBusqueda3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNroBusqueda3.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtNroBusqueda3.Text.Trim.Length > 0 Then
                UbicarAprobadoDesem(cboTipoEntidad3.Text, txtNroBusqueda3.Text.Trim)
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtNroBusqueda3_TextChanged(sender As Object, e As EventArgs) Handles txtNroBusqueda3.TextChanged

    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        Me.Cursor = Cursors.WaitCursor
        PrestamosEmitidosAprobar()
        lblEstado.Text = "Prestamos del día: " & DateTime.Now.Date
        Timer1.Enabled = True
        PanelError.Visible = True
        TiempoEjecutar(10)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Me.Cursor = Cursors.WaitCursor
        PrestamosXPeriodo()
        lblEstado.Text = "Prestamos del período: " & PeriodoGeneral
        Timer1.Enabled = True
        PanelError.Visible = True
        TiempoEjecutar(10)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        Me.Cursor = Cursors.WaitCursor
        Dim prestamoSA As New prestamosSA
        If Not IsNothing(Me.dgvPrestamos2.Table.CurrentRecord) Then

            If prestamoSA.PrestamoEstadoAprobado(Me.dgvPrestamos2.Table.CurrentRecord.GetValue("codigo")) = False Then



                Dim f As New frmConfirmarPrestamo
                'f.TipoPrestamoAprobado = "PO"
                f.UbicarPrestamo(Me.dgvPrestamos2.Table.CurrentRecord.GetValue("codigo"))
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                PrestamosEmitidosAprobar()
                Me.Cursor = Cursors.Arrow



                'With frmConfirmarPrestamo
                '    .TipoPrestamoAprobado = "PO"
                '    .UbicarPrestamo(Me.dgvPrestamos2.Table.CurrentRecord.GetValue("codigo"))
                '    .StartPosition = FormStartPosition.CenterParent
                '    .ShowDialog()
                'End With




            Else
                lblEstado.Text = "El prestámo ya fue aprobado!!"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(10)
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub


    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        'With frmRptPrestamosOtor
        '    .StartPosition = FormStartPosition.CenterParent
        '    .WindowState = FormWindowState.Maximized
        '    .ShowDialog()
        'End With
    End Sub

    Private Sub ButtonAdv8_Click(sender As Object, e As EventArgs) Handles ButtonAdv8.Click
        'With frmRptMayorMenorPrestamo
        '    .StartPosition = FormStartPosition.CenterParent
        '    .WindowState = FormWindowState.Maximized
        '    .ShowDialog()
        'End With
    End Sub

    Private Sub ButtonAdv9_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ButtonAdv9_Click_1(sender As Object, e As EventArgs) Handles ButtonAdv9.Click
        'With frmRptPrestamosPagos
        '    .StartPosition = FormStartPosition.CenterParent
        '    .WindowState = FormWindowState.Maximized
        '    .ShowDialog()
        'End With
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        PrestamosDesembolsoAptos("POT")
    End Sub

    Private Sub txtProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedor.KeyDown
        If e.Alt Then
            If e.KeyCode = Keys.Down Then
                If Not Me.popupControlContainer1.IsShowing() Then
                    ' Let the popup align around the source textBox.
                    Me.popupControlContainer1.ParentControl = Me.txtProveedor
                    ' Passing Point.Empty will align it automatically around the above ParentControl.
                    Me.popupControlContainer1.ShowPopup(Point.Empty)

                    e.Handled = True
                End If
            End If
        End If
        '' Escape should close the popup.
        If e.KeyCode = Keys.Escape Then
            If Me.popupControlContainer1.IsShowing() Then
                Me.popupControlContainer1.HidePopup(PopupCloseType.Canceled)
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtProveedor.Text.Trim.Length > 0 Then
                Me.popupControlContainer1.ParentControl = Me.txtProveedor
                Me.popupControlContainer1.ShowPopup(Point.Empty)
                CargarEntidadesXtipo(cboTipoEntidad2.Text, txtProveedor.Text.Trim)
            End If
        End If
    End Sub

    Private Sub txtProveedor_TextChanged(sender As Object, e As EventArgs) Handles txtProveedor.TextChanged

    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        If lsvProveedor.SelectedItems.Count > 0 Then
            Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub lsvProveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvProveedor.SelectedIndexChanged

    End Sub

    Private Sub popupControlContainer1_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles popupControlContainer1.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then


                ' Dim idprov As Integer = CInt(lsvProveedor.SelectedItems(0).SubItems(0).Text)

                PrestamosDesembolsoTipo(CInt(lsvProveedor.SelectedItems(0).SubItems(0).Text))

                Me.txtProveedor.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                'txtProveedor.Tag = lsvProveedor.SelectedItems(0).SubItems(0).Text
                txtNroBusqueda2.Text = lsvProveedor.SelectedItems(0).SubItems(3).Text
                '' txtCuenta.Text = lsvProveedor.SelectedItems(0).SubItems(2).Text

                'If txtSerie.Text.Trim.Length > 0 AndAlso txtNumero.Text.Trim.Length > 0 AndAlso txtProveedor.Text.Trim.Length > 0 Then
                '    txtGlosa.Text = "Por la compra según " & cboTipoDoc.Text & Space(1) & "Nro. " & txtSerie.Text.Trim & "-" & txtNumero.Text.Trim & Space(1) & "del proveedor " & txtProveedor.Text.Trim
                'End If

                'txtSerieGuia.Select()
                'txtSerieGuia.SelectAll()
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
    End Sub

    Private Sub txtProveedor2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedor2.KeyDown
        If e.Alt Then
            If e.KeyCode = Keys.Down Then
                If Not Me.PopupControlContainer2.IsShowing() Then
                    ' Let the popup align around the source textBox.
                    Me.PopupControlContainer2.ParentControl = Me.txtProveedor2
                    ' Passing Point.Empty will align it automatically around the above ParentControl.
                    Me.PopupControlContainer2.ShowPopup(Point.Empty)

                    e.Handled = True
                End If
            End If
        End If
        '' Escape should close the popup.
        If e.KeyCode = Keys.Escape Then
            If Me.PopupControlContainer2.IsShowing() Then
                Me.PopupControlContainer2.HidePopup(PopupCloseType.Canceled)
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtProveedor2.Text.Trim.Length > 0 Then
                Me.PopupControlContainer2.ParentControl = Me.txtProveedor2
                Me.PopupControlContainer2.ShowPopup(Point.Empty)
                CargarEntidadesXtipo2(cboTipoEntidad3.Text, txtProveedor2.Text.Trim)
            End If
        End If
    End Sub

    Private Sub txtProveedor2_TextChanged(sender As Object, e As EventArgs) Handles txtProveedor2.TextChanged

    End Sub

    Private Sub lsvProveedor2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvProveedor2.MouseDoubleClick
        If lsvProveedor2.SelectedItems.Count > 0 Then
            Me.popupControlContainer2.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub lsvProveedor2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvProveedor2.SelectedIndexChanged

    End Sub

    Private Sub PopupControlContainer2_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer2.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor2.SelectedItems.Count > 0 Then


                ' Dim idprov As Integer = CInt(lsvProveedor.SelectedItems(0).SubItems(0).Text)

                PrestamosDesembolsoAprobado2(CInt(lsvProveedor2.SelectedItems(0).SubItems(0).Text))

                Me.txtProveedor2.Text = lsvProveedor2.SelectedItems(0).SubItems(1).Text
                'txtProveedor.Tag = lsvProveedor.SelectedItems(0).SubItems(0).Text
                txtNroBusqueda3.Text = lsvProveedor2.SelectedItems(0).SubItems(3).Text
                '' txtCuenta.Text = lsvProveedor.SelectedItems(0).SubItems(2).Text

                'If txtSerie.Text.Trim.Length > 0 AndAlso txtNumero.Text.Trim.Length > 0 AndAlso txtProveedor.Text.Trim.Length > 0 Then
                '    txtGlosa.Text = "Por la compra según " & cboTipoDoc.Text & Space(1) & "Nro. " & txtSerie.Text.Trim & "-" & txtNumero.Text.Trim & Space(1) & "del proveedor " & txtProveedor.Text.Trim
                'End If

                'txtSerieGuia.Select()
                'txtSerieGuia.SelectAll()
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
    End Sub

    Private Sub TabControlAdv2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControlAdv2.SelectedIndexChanged
       


    End Sub

    Private Sub TabControlAdv2_SelectedIndexChanging(sender As Object, args As SelectedIndexChangingEventArgs) Handles TabControlAdv2.SelectedIndexChanging
        txtProveedor2.Text = ""
        txtProveedor.Text = ""
        txtNroBusqueda2.Text = ""
        txtNroBusqueda3.Text = ""
    End Sub

    Private Sub TabControlAdv2_TabIndexChanged(sender As Object, e As EventArgs) Handles TabControlAdv2.TabIndexChanged
        
    End Sub

    Private Sub TabControlAdv2_TabMoving(sender As Object, e As TabMovingEventArgs) Handles TabControlAdv2.TabMoving
        
    End Sub
End Class