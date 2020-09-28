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
Public Class frmMaestroPrestamosRecibidos
    Inherits frmMaster

    Dim filter As GridDynamicFilter = New GridDynamicFilter()
    Dim filter1 As GridDynamicFilter = New GridDynamicFilter()
    Private lblPeriodo As System.Windows.Forms.ToolStripLabel
    Private lblPeriodoLabel As System.Windows.Forms.ToolStripLabel

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ConfiguracionInicio()
        ' Add any initialization after the InitializeComponent() call.


    End Sub



#Region "metodos"

    Public Sub CargarTrabajadoresXnivel2(strNivel As String, strBusqueda As String)
        Dim personaSA As New PersonaSA
        Try
            lsvProveedor2.Items.Clear()
            For Each i In personaSA.ObtenerPersonaNumDocPorNivelxDescripcion(Gempresas.IdEmpresaRuc, strNivel, strBusqueda)
                Dim n As New ListViewItem(i.idPersona)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(String.Empty)
                n.SubItems.Add(i.idPersona)
                lsvProveedor2.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Sub CargarTrabajadoresXnivel(strNivel As String, strBusqueda As String)
        Dim personaSA As New PersonaSA
        Try
            lsvProveedor.Items.Clear()
            For Each i In personaSA.ObtenerPersonaNumDocPorNivelxDescripcion(Gempresas.IdEmpresaRuc, strNivel, strBusqueda)
                Dim n As New ListViewItem(i.idPersona)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(String.Empty)
                n.SubItems.Add(i.idPersona)
                lsvProveedor.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub

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


    Private Function ListaDeAprobadosDesembolsado(intIdBeneficiario As Integer) As DataTable
        Dim PrestamoSA As New prestamosSA

        Dim tabla As New tablaDetalleSA
        Dim entidad As New entidadSA
        Dim Persona As New PersonaSA
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


        For Each i As prestamos In PrestamoSA.ObtenerPrestamosAprobadosDesembolsado(intIdBeneficiario, "PRC")
            Dim dr As DataRow = dt.NewRow()


            dr(0) = i.idDocumento
            dr(1) = i.DocPrestamo
            dr(2) = tabla.GetUbicarTablaID(10, i.DocPrestamo).descripcion
            dr(3) = i.nroDoc
            dr(4) = i.fechaPrestamo
            dr(5) = i.idBeneficiario

            If i.tipoBeneficiario = "PR" Then
                dr(6) = entidad.UbicarEntidadPorIdentidad(Gempresas.IdEmpresaRuc, i.tipoBeneficiario, i.idBeneficiario).nombre
            ElseIf i.tipoBeneficiario = "TR" Then
                dr(6) = Persona.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, CStr(i.idBeneficiario), i.tipoBeneficiario).nombres
            ElseIf i.tipoBeneficiario = "CL" Then
                dr(6) = Persona.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, CStr(i.idBeneficiario), i.tipoBeneficiario).nombres
            End If

            dr(7) = i.tipoCambio
            dr(8) = i.monto
            dr(9) = i.montoUSD
            dr(10) = i.desembolso

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


    Public Sub PrestamosDesembolsoTipo(numero As Integer)
        Try

            Dim parentTable As DataTable = ListaDesembolso(numero)
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



    Private Function ListaDesembolso(intIdBeneficiario As Integer) As DataTable
        Dim PrestamoSA As New prestamosSA

        Dim tabla As New tablaDetalleSA
        Dim entidad As New entidadSA
        Dim Persona As New PersonaSA
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


        For Each i As prestamos In PrestamoSA.ObtenerPrestamosAprobadosBeneficiario(intIdBeneficiario, "PRC")
            Dim dr As DataRow = dt.NewRow()

            dr(0) = i.idDocumento
            dr(1) = i.DocPrestamo
            dr(2) = tabla.GetUbicarTablaID(10, i.DocPrestamo).descripcion
            'dr(3) = i.nroDoc
            dr(3) = i.fechaPrestamo
            dr(4) = i.idBeneficiario
            'dr(5) = entidad.UbicarEntidadPorIdentidad(Gempresas.IdEmpresaRuc, i.tipoBeneficiario, i.idBeneficiario).nombre

            If i.tipoBeneficiario = "PR" Then
                dr(5) = entidad.UbicarEntidadPorIdentidad(Gempresas.IdEmpresaRuc, i.tipoBeneficiario, i.idBeneficiario).nombre

            ElseIf i.tipoBeneficiario = "TR" Then
                dr(5) = Persona.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, CStr(i.idBeneficiario), i.tipoBeneficiario).nombres
            ElseIf i.tipoBeneficiario = "CL" Then
                dr(5) = Persona.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, CStr(i.idBeneficiario), i.tipoBeneficiario).nombres
            End If




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

    'Public Sub PrestamosEmitidosAprobar()
    '    Dim documentoCompraSA As New DocumentoCompraSA
    '    Dim grupoActual As String = String.Empty
    '    Dim g As New ListViewGroup
    '    Try

    '        Dim parentTable As DataTable = getParentTablePrestamosParaAprobar()
    '        Me.dgvPrestamos2.DataSource = parentTable
    '        dgvPrestamos2.TableDescriptor.Relations.Clear()
    '        dgvPrestamos2.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
    '        dgvPrestamos2.TableOptions.ListBoxSelectionMode = SelectionMode.One
    '        dgvPrestamos2.Appearance.AnyRecordFieldCell.Enabled = False
    '        dgvPrestamos2.GroupDropPanel.Visible = True
    '        dgvPrestamos2.TableDescriptor.GroupedColumns.Clear()
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub


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
        For Each i As prestamos In prestamoSA.ObtenerPrestamos(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, "PRC")
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




#End Region
    Private Sub ConfiguracionInicio()

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

        'Me.rbnPrincipal.Header.AddQuickItem(btnAnio)
        'Me.rbnPrincipal.Header.AddQuickItem(cboAnio)
    End Sub

#Region "Emisión préstamos"
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
    'Public Sub PrestamosXPeriodo()
    '    Dim documentoCompraSA As New DocumentoCompraSA
    '    Dim grupoActual As String = String.Empty
    '    Dim g As New ListViewGroup
    '    Try

    '        parentTable = getParentTablePrestamosXperiodo()
    '        Me.dgvPrestamos2.DataSource = parentTable
    '        dgvPrestamos2.TableDescriptor.Relations.Clear()
    '        dgvPrestamos2.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
    '        dgvPrestamos2.TableOptions.ListBoxSelectionMode = SelectionMode.One
    '        dgvPrestamos2.Appearance.AnyRecordFieldCell.Enabled = False
    '        dgvPrestamos2.GroupDropPanel.Visible = True
    '        dgvPrestamos2.TableDescriptor.GroupedColumns.Clear()
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

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

        Dim str As String
        For Each i As prestamos In prestamoSA.ObtenerPrestamos(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, "PRC")
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
            Select Case i.estado
                Case "PN"
                    dr(13) = "Pendiente"
                Case Else
                    dr(13) = "Aprobado"
            End Select

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
        For Each i As prestamos In prestamoSA.ObtenerPrestamosXperiodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, PeriodoGeneral, "PRC")
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

#Region "Manipulación Data"
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
    '            .lblTipoPres.Tag = "PR"
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
    '            ' If .TieneCuentaFinanciera = True Then
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
    '            'lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
    '            'PanelError.Visible = True
    '            'Timer1.Enabled = True
    '            'TiempoEjecutar(10)
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

#Region "Listas"
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
    Private Function ListaPrestamosPorBeneficiario(intIdBeneficiario As Integer) As DataTable
        Dim documentoPrestamoSA As New documentoPrestamoSA
        '    Dim DatoRepetido As Boolean

        Dim dt As New DataTable("Prestámos usuario: ")

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

        dt.Columns.Add(New DataColumn("ImportePagoCapitalMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ImportePagoCapitalME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ImportePagoInteresMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ImportePagoInteresME", GetType(Decimal)))


        Dim str As String
        For Each i As documentoPrestamos In documentoPrestamoSA.ListadoPrestamosPendientes(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, intIdBeneficiario, PeriodoGeneral, "PR")
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
            dr(9) = i.fechaVcto
            dr(10) = i.numeroDocumento
            dr(11) = i.idCuota
            dr(12) = i.referencia
            dr(13) = i.entidadFinanciera
            dr(14) = i.montoSoles
            dr(15) = i.montoDolares

            dr(16) = i.montoInteresSoles
            dr(17) = i.montoInteresUSD

            dr(18) = i.ImportePagoCapitalMN
            dr(19) = i.ImportePagoCapitalME
            dr(20) = i.ImportePagoInteresMN
            dr(21) = i.ImportePagoInteresME

            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    'Public Sub PrestamosPorUsuario()
    '    Try

    '        Dim parentTable As DataTable = ListaPrestamosPorBeneficiario(txtNroBusqueda.Tag)
    '        Me.dgvPrestamosUser.DataSource = parentTable
    '        Me.dgvPrestamosUser.Refresh()
    '        dgvPrestamosUser.TableDescriptor.Relations.Clear()
    '        dgvPrestamosUser.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
    '        dgvPrestamosUser.TableOptions.ListBoxSelectionMode = SelectionMode.One
    '        dgvPrestamosUser.Appearance.AnyRecordFieldCell.Enabled = False
    '        dgvPrestamosUser.GroupDropPanel.Visible = True
    '        dgvPrestamosUser.TableDescriptor.GroupedColumns.Clear()
    '        dgvPrestamosUser.TableDescriptor.GroupedColumns.Add("TipoDocPrestamo")

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

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

    'Public Sub UbicarTrabPorDNI(strNumero As String, strNivel As String)
    '    Dim personaSA As New PersonaSA
    '    Dim persona As New Persona

    '    persona = personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, strNumero, strNivel)
    '    If Not IsNothing(persona) Then
    '        With persona
    '            txtNroBusqueda.Text = .idPersona
    '            txtNroBusqueda.Tag = .idPersona
    '            '   txtCuenta.Text = "TR"
    '            '  txtRuc.Text = .idPersona
    '            lblNombre.Text = .nombreCompleto
    '            lblNro.Text = .idPersona
    '            PrestamosPorUsuario()
    '        End With
    '    Else
    '        lblNombre.Text = String.Empty
    '        lblNro.Text = String.Empty
    '        Me.dgvPrestamosUser.Table.Records.SelectAll()
    '        Me.dgvPrestamosUser.Table.Records.DeleteAll()

    '    End If
    'End Sub

    'Public Sub UbicarEntidadPorTipo(strTipoEntidad As String, strNumDoc As String)

    '    If cboTipoEntidad.Text = "PR" Then
    '        UbicarEntidadPorRuc(TIPO_ENTIDAD.PROVEEDOR, strNumDoc)
    '    ElseIf cboTipoEntidad.Text = "CL" Then
    '        UbicarEntidadPorRuc(TIPO_ENTIDAD.CLIENTE, strNumDoc)
    '    ElseIf cboTipoEntidad.Text = "TR" Then
    '        UbicarTrabPorDNI(strNumDoc, "TR")
    '    ElseIf cboTipoEntidad.Text = "OT" Then
    '        UbicarTrabPorDNI(strNumDoc, "OT")
    '    End If

    'End Sub
#End Region

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

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        PanelError.Visible = False
        Timer1.Enabled = False
    End Sub

    Private Sub frmMaestroPrestamosRecibidos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmMaestroPrestamosRecibidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub










    Private Sub txtNroBusqueda_Click(sender As Object, e As EventArgs)

    End Sub


    Private Sub ToolStripButton13_Click(sender As Object, e As EventArgs) Handles ToolStripButton13.Click
        Me.Cursor = Cursors.WaitCursor
        With frmPrestamoRecibido
           
            .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
            .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            .lblPerido.Text = PeriodoGeneral
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton14_Click(sender As Object, e As EventArgs) Handles ToolStripButton14.Click
        Dim prestamoSA As New prestamosSA
        Me.Cursor = Cursors.WaitCursor
        If prestamoSA.PrestamoEstadoAprobado(Me.dgvPrestamos.Table.CurrentRecord.GetValue("codigo")) = False Then
            With frmPrestamo
                '.Label19.Tag = "R"
                '.Label19.Text = "P. Recibido"
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
            lblEstado.Text = "El préstamo ya fue aprobado!!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If

        Me.Cursor = Cursors.Arrow
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
        'PrestamosXPeriodo()
        lblEstado.Text = "Prestamos del período: " & PeriodoGeneral
        Timer1.Enabled = True
        PanelError.Visible = True
        TiempoEjecutar(10)
        Me.Cursor = Cursors.Arrow
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
                ' CargarEntidadesXtipo(cboTipoEntidad2.Text, txtProveedor.Text.Trim)

                If cboTipoEntidad2.Text = "PR" Then
                    CargarEntidadesXtipo(TIPO_ENTIDAD.PROVEEDOR, txtProveedor.Text.Trim)
                ElseIf cboTipoEntidad2.Text = "TR" Then
                    CargarTrabajadoresXnivel("TR", txtProveedor.Text.Trim)

                ElseIf cboTipoEntidad2.Text = "CL" Then
                    CargarTrabajadoresXnivel("CL", txtProveedor.Text.Trim)
                End If

            End If
        End If
    End Sub

    'Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
    '    Me.Cursor = Cursors.WaitCursor
    '    Dim prestamoSA As New prestamosSA
    '    If Not IsNothing(Me.dgvPrestamos2.Table.CurrentRecord) Then
    '        If prestamoSA.PrestamoEstadoAprobado(Me.dgvPrestamos2.Table.CurrentRecord.GetValue("codigo")) = False Then
    '            With frmConfirmarPrestamoOtor
    '                .TipoPrestamoAprobado = "PR"
    '                .UbicarPrestamo(Me.dgvPrestamos2.Table.CurrentRecord.GetValue("codigo"))
    '                .StartPosition = FormStartPosition.CenterParent
    '                .ShowDialog()
    '            End With
    '        Else
    '            lblEstado.Text = "El prestámo ya fue aprobado!!"
    '            PanelError.Visible = True
    '            Timer1.Enabled = True
    '            TiempoEjecutar(10)
    '        End If
    '    End If
    '    Me.Cursor = Cursors.Arrow
    'End Sub




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

    Private Sub ToolStripButton17_Click(sender As Object, e As EventArgs) Handles ToolStripButton17.Click
        If Not IsNothing(Me.dgvPrestamosUser2.Table.CurrentRecord) Then




            Dim f As New frmIngresoPrestamo
            'f.UbicarFechas(Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("idDocumento"))

            f.txtProveedor.Text = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("Beneficiario")
            f.txtProveedor.Tag = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("idBeneficiario")
            f.txtComprobante.Text = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("DocPrestamo")
            f.txtComprobante.Tag = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("tipoDoc")

            'f.txtFechaComprobante.Value = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("fechaPrestamo")
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

            'f.txtCuotas.Value = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("NumCuotas")
            'f.cboModo.Text = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("ModoPago")

            'f.DateTimePickerAdv2.Value = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("fechaInicio")
            'f.cboDiaPago.Text = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("diaPago")
            'f.cbodiaplazo.Text = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("gracia")
            f.txtTipo.Text = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("tipo")


            f.lblMovimiento.Tag = "OEC"
            f.lblMovimiento.Text = "OTRAS ENTRADAS DE CAJA"
            'f.CaptionLabels(0).Text = "OTRAS SALIDAS DE CAJA"
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT


            f.StartPosition = FormStartPosition.CenterParent
            f.WindowState = FormWindowState.Maximized
            f.ShowDialog()


            Me.Cursor = Cursors.Arrow


        Else
            lblEstado.Text = "Seleccione un Item"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
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
                'CargarEntidadesXtipo2(cboTipoEntidad3.Text, txtProveedor2.Text.Trim)
                If cboTipoEntidad3.Text = "PR" Then
                    CargarEntidadesXtipo2(TIPO_ENTIDAD.PROVEEDOR, txtProveedor2.Text.Trim)
                ElseIf cboTipoEntidad3.Text = "TR" Then
                    CargarTrabajadoresXnivel2("TR", txtProveedor2.Text.Trim)

                ElseIf cboTipoEntidad3.Text = "CL" Then
                    CargarTrabajadoresXnivel2("CL", txtProveedor2.Text.Trim)
                End If
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

    Private Sub ToolStripButton23_Click(sender As Object, e As EventArgs) Handles ToolStripButton23.Click
        If Not IsNothing(Me.GridGroupingControl1.Table.CurrentRecord) Then

            With frmPrestamosPago
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
End Class