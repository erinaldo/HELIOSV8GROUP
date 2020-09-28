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

Public Class FrmPrestamosGeneral

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

#Region "Metodos"

    'Listar todas las cuentas
    Public Sub TodasCuotasVencidas(tipo As String)
        Try

            Dim parentTable As DataTable = ListaTodasCuotasVencidas(tipo)
            Me.GridGroupingControl6.DataSource = parentTable
            Me.GridGroupingControl6.Refresh()
            GridGroupingControl6.TableDescriptor.Relations.Clear()
            GridGroupingControl6.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            GridGroupingControl6.TableOptions.ListBoxSelectionMode = SelectionMode.One
            GridGroupingControl6.Appearance.AnyRecordFieldCell.Enabled = False
            'dgvPrestamosUser2.GroupDropPanel.Visible = True
            'dgvPrestamosUser2.TableDescriptor.GroupedColumns.Clear()
            'dgvPrestamosUser2.TableDescriptor.GroupedColumns.Add("TipoDocPrestamo")

        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub


    Private Function ListaTodasCuotasVencidas(tipo As String) As DataTable
        Dim PrestamoSA As New prestamosSA

        Dim tabla As New tablaDetalleSA
        Dim entidad As New entidadSA
        '    Dim DatoRepetido As Boolean

        Dim dt As New DataTable("Prestámos para Desembolsar")

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("idCuota", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Glosa", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("DocPrestamo", GetType(String)))
        dt.Columns.Add(New DataColumn("nroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaPrestamo", GetType(Date)))
        dt.Columns.Add(New DataColumn("idBeneficiario", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Beneficiario", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUSD", GetType(Decimal)))
        'dt.Columns.Add(New DataColumn("desembolso", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaVen", GetType(Date)))


        For Each i As prestamos In PrestamoSA.ObtenerTodoCuotasVencidas(tipo)
            Dim dr As DataRow = dt.NewRow()


            dr(0) = i.idDocumento
            dr(1) = i.idCuota
            dr(2) = i.nomCuota
            dr(3) = i.DocPrestamo
            dr(4) = tabla.GetUbicarTablaID(10, i.DocPrestamo).descripcion
            dr(5) = i.nroDoc
            dr(6) = i.fechaPrestamo
            dr(7) = i.idBeneficiario
            dr(8) = entidad.UbicarEntidadPorIdentidad(Gempresas.IdEmpresaRuc, i.tipoBeneficiario, i.idBeneficiario).nombreCompleto
            dr(9) = i.tipoCambio
            dr(10) = i.monto
            dr(11) = i.montoUSD
            dr(12) = i.fechaVen

            dt.Rows.Add(dr)
        Next
        Return dt
    End Function



    'listacuotasvencidasproveedor
    Public Sub CuotasVencidasProv(idbene As Integer, tipo As String)
        Try

            Dim parentTable As DataTable = ListaCuotasVencidasProveedor(idbene, tipo)
            Me.GridGroupingControl6.DataSource = parentTable
            Me.GridGroupingControl6.Refresh()
            GridGroupingControl6.TableDescriptor.Relations.Clear()
            GridGroupingControl6.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            GridGroupingControl6.TableOptions.ListBoxSelectionMode = SelectionMode.One
            GridGroupingControl6.Appearance.AnyRecordFieldCell.Enabled = False
            'dgvPrestamosUser2.GroupDropPanel.Visible = True
            'dgvPrestamosUser2.TableDescriptor.GroupedColumns.Clear()
            'dgvPrestamosUser2.TableDescriptor.GroupedColumns.Add("TipoDocPrestamo")

        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub


    Private Function ListaCuotasVencidasProveedor(intIdBeneficiario As Integer, tipo As String) As DataTable
        Dim PrestamoSA As New prestamosSA

        Dim tabla As New tablaDetalleSA
        Dim entidad As New entidadSA
        '    Dim DatoRepetido As Boolean

        Dim dt As New DataTable("Prestámos para Desembolsar")

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("idCuota", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Glosa", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("DocPrestamo", GetType(String)))
        dt.Columns.Add(New DataColumn("nroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaPrestamo", GetType(Date)))
        dt.Columns.Add(New DataColumn("idBeneficiario", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Beneficiario", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUSD", GetType(Decimal)))
        'dt.Columns.Add(New DataColumn("desembolso", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaVen", GetType(Date)))


        For Each i As prestamos In PrestamoSA.ObtenerCuotasVencidas(intIdBeneficiario, tipo)
            Dim dr As DataRow = dt.NewRow()


            dr(0) = i.idDocumento
            dr(1) = i.idCuota
            dr(2) = i.nomCuota
            dr(3) = i.DocPrestamo
            dr(4) = tabla.GetUbicarTablaID(10, i.DocPrestamo).descripcion
            dr(5) = i.nroDoc
            dr(6) = i.fechaPrestamo
            dr(7) = i.idBeneficiario
            dr(8) = entidad.UbicarEntidadPorIdentidad(Gempresas.IdEmpresaRuc, i.tipoBeneficiario, i.idBeneficiario).nombreCompleto
            dr(9) = i.tipoCambio
            dr(10) = i.monto
            dr(11) = i.montoUSD
            dr(12) = i.fechaVen

            dt.Rows.Add(dr)
        Next
        Return dt
    End Function





    'pagos prestamos
    Public Sub PrestamosDesembolsoAprobadoP(idbene As Integer, tipoPR As String)
        Try

            Dim parentTable As DataTable = ListaDeAprobadosDesembolsadoP(idbene, tipoPR)
            Me.GridGroupingControl5.DataSource = parentTable
            Me.GridGroupingControl5.Refresh()
            GridGroupingControl5.TableDescriptor.Relations.Clear()
            GridGroupingControl5.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            GridGroupingControl5.TableOptions.ListBoxSelectionMode = SelectionMode.One
            GridGroupingControl5.Appearance.AnyRecordFieldCell.Enabled = False

        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub



    Private Function ListaDeAprobadosDesembolsadoP(intIdBeneficiario As Integer, tipo As String) As DataTable
        Dim PrestamoSA As New prestamosSA

        Dim tabla As New tablaDetalleSA
        Dim entidadSA As New entidadSA
        Dim personaSA As New PersonaSA
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
        dt.Columns.Add(New DataColumn("desembolso", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("cuenta", GetType(String)))
        dt.Columns.Add(New DataColumn("monto", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUSD", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("interes", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("deuda", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("abono", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("saldo", GetType(Decimal)))

        'dt.Columns.Add(New DataColumn("devengado", GetType(String)))
        'dt.Columns.Add(New DataColumn("tipo1", GetType(String)))
        'dt.Columns.Add(New DataColumn("tipo2", GetType(String)))

        For Each i As prestamos In PrestamoSA.ObtenerPrestamosAprobadosDesembolsado(intIdBeneficiario, "PRC", tipo)
            Dim dr As DataRow = dt.NewRow()


            dr(0) = i.idDocumento
            dr(1) = i.DocPrestamo
            dr(2) = tabla.GetUbicarTablaID(10, i.DocPrestamo).descripcion
            dr(3) = i.nroDoc
            dr(4) = i.fechaPrestamo
            dr(5) = i.idBeneficiario

            Select Case i.tipoBeneficiario
                Case TIPO_ENTIDAD.PROVEEDOR
                    With entidadSA.UbicarEntidadPorID(i.idBeneficiario).First
                        dr(6) = .nombreCompleto
                    End With
                Case TIPO_ENTIDAD.CLIENTE
                    With entidadSA.UbicarEntidadPorID(i.idBeneficiario).First
                        dr(6) = .nombreCompleto
                    End With
                Case "TR"

                    With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.idBeneficiario, "TR")
                        dr(6) = .nombreCompleto
                    End With
                Case "OT"
                    With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.idBeneficiario, "OT")
                        dr(6) = .nombreCompleto
                    End With
            End Select

            'dr(7) = i.tipoCambio
            'dr(8) = i.monto
            'dr(9) = i.montoUSD
            'dr(10) = i.desembolso
            'dr(11) = i.estado
            'dr(12) = i.cuentaTipo
            ''dr(13) = i.cuentaDevengado
            ''dr(14) = i.tipoCuenta
            ''dr(15) = i.tipoDevengado

            dr(7) = i.tipoCambio
            dr(8) = i.desembolso
            dr(9) = i.estado
            dr(10) = i.cuentaTipo
            dr(11) = i.monto
            dr(12) = i.montoUSD
            dr(13) = i.interes
            dr(14) = (i.monto + i.interes)
            dr(15) = i.abono
            dr(16) = ((i.monto + i.interes) - i.abono)

            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Public Sub CargarTrabajadoresXnivelVen(strNivel As String, strBusqueda As String)
        Dim personaSA As New PersonaSA
        Try
            ListView4.Items.Clear()
            For Each i In personaSA.ObtenerPersonaNumDocPorNivelxDescripcion(Gempresas.IdEmpresaRuc, strNivel, strBusqueda)
                Dim n As New ListViewItem(i.idPersona)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(String.Empty)
                n.SubItems.Add(i.idPersona)
                ListView4.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Sub CargarTrabajadoresXnivelCobro(strNivel As String, strBusqueda As String)
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

    '/////////////////////////////periodopagos

    Public Sub PrestamosOtorgadosPeriodoR(periodo As String)
        Try
            Dim parentTable As DataTable = ListaPrestamosOtorgadosPeriodoR(periodo)
            Me.GridGroupingControl5.DataSource = parentTable
            Me.GridGroupingControl5.Refresh()
            GridGroupingControl5.TableDescriptor.Relations.Clear()
            GridGroupingControl5.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            GridGroupingControl5.TableOptions.ListBoxSelectionMode = SelectionMode.One
            GridGroupingControl5.Appearance.AnyRecordFieldCell.Enabled = False


        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub


    Private Function ListaPrestamosOtorgadosPeriodoR(periodo As String) As DataTable
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
        dt.Columns.Add(New DataColumn("estado", GetType(String)))

        For Each i As prestamos In PrestamoSA.ObtenerPrestamosPagoCobro(periodo, "PRC")
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
            dr(11) = i.estado

            dt.Rows.Add(dr)
        Next
        Return dt
    End Function



    '///////////////


    Public Sub PrestamosOtorgadosPeriodo(periodo As String)
        Try

            Dim parentTable As DataTable = ListaPrestamosOtorgadosPeriodo(periodo)
            Me.GridGroupingControl4.DataSource = parentTable
            Me.GridGroupingControl4.Refresh()
            GridGroupingControl4.TableDescriptor.Relations.Clear()
            GridGroupingControl4.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            GridGroupingControl4.TableOptions.ListBoxSelectionMode = SelectionMode.One
            GridGroupingControl4.Appearance.AnyRecordFieldCell.Enabled = False
     

        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub


    Private Function ListaPrestamosOtorgadosPeriodo(periodo As String) As DataTable
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
        dt.Columns.Add(New DataColumn("estado", GetType(String)))

        For Each i As prestamos In PrestamoSA.ObtenerPrestamosPagoCobro(periodo, "POT")
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
            dr(11) = i.estado

            dt.Rows.Add(dr)
        Next
        Return dt
    End Function


    'cobros prestamos
    Public Sub PrestamosDesembolsoAprobado2(idbene As Integer, tipo As String)
        Try

            Dim parentTable As DataTable = ListaDeAprobadosDesembolsado(idbene, tipo)
            Me.GridGroupingControl4.DataSource = parentTable
            Me.GridGroupingControl4.Refresh()
            GridGroupingControl4.TableDescriptor.Relations.Clear()
            GridGroupingControl4.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            GridGroupingControl4.TableOptions.ListBoxSelectionMode = SelectionMode.One
            GridGroupingControl4.Appearance.AnyRecordFieldCell.Enabled = False
            'dgvPrestamosUser2.GroupDropPanel.Visible = True
            'dgvPrestamosUser2.TableDescriptor.GroupedColumns.Clear()
            'dgvPrestamosUser2.TableDescriptor.GroupedColumns.Add("TipoDocPrestamo")

        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub


    Private Function ListaDeAprobadosDesembolsado(intIdBeneficiario As Integer, tipo As String) As DataTable
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
        dt.Columns.Add(New DataColumn("nroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaPrestamo", GetType(Date)))
        dt.Columns.Add(New DataColumn("idBeneficiario", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Beneficiario", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("desembolso", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("cuenta", GetType(String)))
        dt.Columns.Add(New DataColumn("monto", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUSD", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("interes", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("deuda", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("abono", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("saldo", GetType(Decimal)))

        

        For Each i As prestamos In PrestamoSA.ObtenerPrestamosAprobadosDesembolsado(intIdBeneficiario, "POT", tipo)
            Dim dr As DataRow = dt.NewRow()


            dr(0) = i.idDocumento
            dr(1) = i.DocPrestamo
            dr(2) = tabla.GetUbicarTablaID(10, i.DocPrestamo).descripcion
            dr(3) = i.nroDoc
            dr(4) = i.fechaPrestamo
            dr(5) = i.idBeneficiario

            'dr(6) = entidad.UbicarEntidadPorIdentidad(Gempresas.IdEmpresaRuc, i.tipoBeneficiario, i.idBeneficiario).nombre

            Select Case i.tipoBeneficiario
                Case TIPO_ENTIDAD.PROVEEDOR
                    With entidadSA.UbicarEntidadPorID(i.idBeneficiario).First
                        dr(6) = .nombreCompleto
                    End With
                Case TIPO_ENTIDAD.CLIENTE
                    With entidadSA.UbicarEntidadPorID(i.idBeneficiario).First
                        dr(6) = .nombreCompleto
                    End With
                Case "TR"

                    With PersonaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.idBeneficiario, "TR")
                        dr(6) = .nombreCompleto
                    End With
                Case "OT"
                    With PersonaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.idBeneficiario, "OT")
                        dr(6) = .nombreCompleto
                    End With
            End Select



            dr(7) = i.tipoCambio
            
            dr(8) = i.desembolso
            dr(9) = i.estado
            dr(10) = i.cuentaTipo
            dr(11) = i.monto
            dr(12) = i.montoUSD
            dr(13) = i.interes
            dr(14) = (i.monto + i.interes)
            dr(15) = i.abono
            dr(16) = ((i.monto + i.interes) - i.abono)

            

            dt.Rows.Add(dr)
        Next
        Return dt
    End Function


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


    Public Sub CargarEntidadesXtipoVen(strTipo As String, strBusqueda As String)
        Dim entidadSA As New entidadSA
        Try
            ListView4.Items.Clear()
            For Each i As entidad In entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.PROVEEDOR, strBusqueda)
                Dim n As New ListViewItem(i.idEntidad)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(i.cuentaAsiento)
                n.SubItems.Add(i.nrodoc)
                ListView4.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub



    Public Sub CargarEntidadesXtipoP(strTipo As String, strBusqueda As String)
        Dim entidadSA As New entidadSA
        Try
            ListView2.Items.Clear()
            For Each i As entidad In entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.PROVEEDOR, strBusqueda)
                Dim n As New ListViewItem(i.idEntidad)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(i.cuentaAsiento)
                n.SubItems.Add(i.nrodoc)
                ListView2.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub

    'lista desembolso aptos
    Public Sub PrestamosDesembolsoAptos(tipo As String)
        Try

            Dim parentTable As DataTable = ListaDesembolsoApto(tipo)
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

        'dt.Columns.Add(New DataColumn("colInteresSoles", GetType(Decimal)))
        'dt.Columns.Add(New DataColumn("colInteresUSD", GetType(Decimal)))
        'dt.Columns.Add(New DataColumn("Seguro", GetType(Decimal)))
        'dt.Columns.Add(New DataColumn("SeguroME", GetType(Decimal)))
        'dt.Columns.Add(New DataColumn("Otro", GetType(Decimal)))
        'dt.Columns.Add(New DataColumn("otroME", GetType(Decimal)))
        'dt.Columns.Add(New DataColumn("Portes", GetType(Decimal)))
        'dt.Columns.Add(New DataColumn("PortesME", GetType(Decimal)))
        'dt.Columns.Add(New DataColumn("EnvioCuenta", GetType(Decimal)))
        'dt.Columns.Add(New DataColumn("EnvCuentaME", GetType(Decimal)))

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

            'dr(10) = i.montoInteresSoles
            'dr(11) = i.montoInteresUSD
            'dr(12) = i.montoSeguroMN
            'dr(13) = i.montoSeguroME
            'dr(14) = i.montoOtroMN
            'dr(15) = i.montoOtroME
            'dr(16) = i.montoPorteMN
            'dr(17) = i.montoPorteME
            'dr(18) = i.montoEnvCuentaMN
            'dr(19) = i.montoEnvCuentaME

            Dim cuota As Decimal = i.numCuotas
            dr(10) = CDec(cuota)
            dr(11) = i.modoPago
            dr(12) = i.fechaInicio
            dr(13) = i.diaPago
            dr(14) = i.plazoDias
            dr(15) = i.tipo

            dt.Rows.Add(dr)
        Next
        Return dt
    End Function





    'prestamos otorgados para desembolsar

    Public Sub PrestamosDesembolsoTipo(numero As Integer, tipo As String, tipoProv As String)
        Try

            Dim parentTable As DataTable = ListaDesembolsoF(numero, tipo, tipoProv)
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


    Private Function ListaDesembolsoF(intIdBeneficiario As Integer, tipo As String, tipoP As String) As DataTable
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
        dt.Columns.Add(New DataColumn("fechaPrestamo", GetType(Date)))
        dt.Columns.Add(New DataColumn("idBeneficiario", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Beneficiario", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUSD", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("desembolso", GetType(String)))
        dt.Columns.Add(New DataColumn("NumCuotas", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ModoPago", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaInicio", GetType(Date)))
        dt.Columns.Add(New DataColumn("diaPago", GetType(Integer)))
        dt.Columns.Add(New DataColumn("gracia", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipo", GetType(String)))
        dt.Columns.Add(New DataColumn("cuenta", GetType(String)))
        dt.Columns.Add(New DataColumn("moneda", GetType(String)))

        For Each i As prestamos In PrestamoSA.ObtenerPrestamosAprobadosBeneficiario(intIdBeneficiario, tipo, tipoP)
            Dim dr As DataRow = dt.NewRow()

            dr(0) = i.idDocumento
            dr(1) = i.DocPrestamo
            dr(2) = tabla.GetUbicarTablaID(10, i.DocPrestamo).descripcion
            dr(3) = i.fechaPrestamo
            dr(4) = i.idBeneficiario

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

            'dr(10) = i.montoInteresSoles
            'dr(11) = i.montoInteresUSD
            'dr(12) = i.montoSeguroMN
            'dr(13) = i.montoSeguroME
            'dr(14) = i.montoOtroMN
            'dr(15) = i.montoOtroME
            'dr(16) = i.montoPorteMN
            'dr(17) = i.montoPorteME
            'dr(18) = i.montoEnvCuentaMN
            'dr(19) = i.montoEnvCuentaME

            Dim cuota As Decimal = i.numCuotas
            dr(10) = CDec(cuota)
            dr(11) = i.modoPago
            dr(12) = i.fechaInicio
            dr(13) = i.diaPago
            dr(14) = i.plazoDias
            dr(15) = i.tipo
            dr(16) = i.cuentaTipo
            dr(17) = i.moneda


            dt.Rows.Add(dr)
        Next
        Return dt
    End Function




    '/////

    Public Sub CargarEntidadesXtipo(strTipo As String, strBusqueda As String)
        Dim entidadSA As New entidadSA
        Try
            ListView3.Items.Clear()
            For Each i As entidad In entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.PROVEEDOR, strBusqueda)
                Dim n As New ListViewItem(i.idEntidad)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(i.cuentaAsiento)
                n.SubItems.Add(i.nrodoc)
                ListView3.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Sub CargarTrabajadoresXnivel(strNivel As String, strBusqueda As String)
        Dim personaSA As New PersonaSA
        Try
            ListView3.Items.Clear()
            For Each i In personaSA.ObtenerPersonaNumDocPorNivelxDescripcion(Gempresas.IdEmpresaRuc, strNivel, strBusqueda)
                Dim n As New ListViewItem(i.idPersona)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(String.Empty)
                n.SubItems.Add(i.idPersona)
                ListView3.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub


    Public Sub CargarTrabajadoresXnivel2(strNivel As String, strBusqueda As String)
        Dim personaSA As New PersonaSA
        Try
            ListView2.Items.Clear()
            For Each i In personaSA.ObtenerPersonaNumDocPorNivelxDescripcion(Gempresas.IdEmpresaRuc, strNivel, strBusqueda)
                Dim n As New ListViewItem(i.idPersona)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(String.Empty)
                n.SubItems.Add(i.idPersona)
                ListView2.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub

    'otorgados por dia
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

        dt.Columns.Add(New DataColumn("tipoActivo", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUSD", GetType(Decimal)))
        'dt.Columns.Add(New DataColumn("montoInteresSoles", GetType(Decimal)))
        'dt.Columns.Add(New DataColumn("montoInteresUSD", GetType(Decimal)))
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

            dr(7) = i.tipoActivo
            dr(8) = i.monto
            dr(9) = i.montoUSD
            'dr(11) = i.montoInteresSoles
            'dr(12) = i.montoInteresUSD
            Select Case i.entregaPendiente
                Case "SI"
                    dr(10) = "Aprobado"
                Case Else
                    dr(10) = "Pendiente"
            End Select

            If i.idDocumento > 0 Then
                dr(11) = i.idDocumento
            End If
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    'recibidos por dia 
    Public Sub PrestamosEmitidosRecibidos()
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim grupoActual As String = String.Empty
        Dim g As New ListViewGroup
        Try

            Dim parentTable As DataTable = getParentTablePrestamosEmitidosRec()
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

    Private Function getParentTablePrestamosEmitidosRec() As DataTable
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

        dt.Columns.Add(New DataColumn("tipoActivo", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUSD", GetType(Decimal)))
        'dt.Columns.Add(New DataColumn("montoInteresSoles", GetType(Decimal)))
        'dt.Columns.Add(New DataColumn("montoInteresUSD", GetType(Decimal)))
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

            dr(7) = i.tipoActivo
            dr(8) = i.monto
            dr(9) = i.montoUSD
            'dr(11) = i.montoInteresSoles
            'dr(12) = i.montoInteresUSD
            Select Case i.estado
                Case "PN"
                    dr(10) = "Pendiente"
                Case Else
                    dr(10) = "Aprobado"
            End Select
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function
    'end

    'PRESTAMOS DEL PERIODO
    Public Sub PrestamosEmitidosXPeriodo()
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim grupoActual As String = String.Empty
        Dim g As New ListViewGroup
        Dim parentTable As New DataTable
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

        dt.Columns.Add(New DataColumn("tipoActivo", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUSD", GetType(Decimal)))
        'dt.Columns.Add(New DataColumn("montoInteresSoles", GetType(Decimal)))
        'dt.Columns.Add(New DataColumn("montoInteresUSD", GetType(Decimal)))
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

            dr(7) = i.tipoActivo
            dr(8) = i.monto
            dr(9) = i.montoUSD
            'dr(11) = i.montoInteresSoles
            'dr(12) = i.montoInteresUSD
            Select Case i.entregaPendiente
                Case "SI"
                    dr(10) = "Aprobado"
                Case Else
                    dr(10) = "Pendiente"
            End Select


            If i.idDocumento > 0 Then
                dr(11) = i.idDocumento
            End If


            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    'DEL PERIODO RECIBIDO

    Public Sub PrestamosEmitidosXPeriodoRec()
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim grupoActual As String = String.Empty
        Dim g As New ListViewGroup
        Dim parentTable As New DataTable
        Try

            parentTable = getParentTablePrestamosEmitidosXperiodoRec()
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

    Private Function getParentTablePrestamosEmitidosXperiodoRec() As DataTable
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

        dt.Columns.Add(New DataColumn("tipoActivo", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUSD", GetType(Decimal)))
        'dt.Columns.Add(New DataColumn("montoInteresSoles", GetType(Decimal)))
        'dt.Columns.Add(New DataColumn("montoInteresUSD", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))

        Dim str As String

        For Each i As prestamos In prestamoSA.ObtenerPrestamosRecibidoXperiodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, PeriodoGeneral, "PRC")
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

            dr(7) = i.tipoActivo
            dr(8) = i.monto
            dr(9) = i.montoUSD
            'dr(11) = i.montoInteresSoles
            'dr(12) = i.montoInteresUSD
            Select Case i.entregaPendiente
                Case "SI"
                    dr(10) = "Aprobado"
                Case Else
                    dr(10) = "Pendiente"
            End Select


            If i.idDocumento > 0 Then
                dr(11) = i.idDocumento
            End If


            dt.Rows.Add(dr)
        Next
        Return dt

    End Function


    'prestamos por aprobar xdia
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

        dt.Columns.Add(New DataColumn("tipoActivo", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUSD", GetType(Decimal)))
        'dt.Columns.Add(New DataColumn("montoInteresSoles", GetType(Decimal)))
        'dt.Columns.Add(New DataColumn("montoInteresUSD", GetType(Decimal)))
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
            ' dr(7) = i.interes
            dr(7) = i.tipoActivo
            dr(8) = i.monto
            dr(9) = i.montoUSD
            'dr(11) = i.montoInteresSoles
            'dr(12) = i.montoInteresUSD
            Select Case i.entregaPendiente
                Case "SI"
                    dr(10) = "Aprobado"
                Case Else
                    dr(10) = "Pendiente"
            End Select

            If i.idDocumento > 0 Then
                dr(11) = i.idDocumento
            End If
            'dr(13) = i.idDocumento

            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    'prestamos por aprobar periodo

    Public Sub PrestamosXPeriodo()
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim grupoActual As String = String.Empty
        Dim g As New ListViewGroup
        Try

            Dim parentTable As DataTable = getParentTablePrestamosXperiodo()
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
        'dt.Columns.Add(New DataColumn("interes", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tipoActivo", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monto", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUSD", GetType(Decimal)))
        'dt.Columns.Add(New DataColumn("montoInteresSoles", GetType(Decimal)))
        'dt.Columns.Add(New DataColumn("montoInteresUSD", GetType(Decimal)))
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
            'dr(7) = i.interes
            dr(7) = i.tipoActivo
            dr(8) = i.monto
            dr(9) = i.montoUSD
            'dr(11) = i.montoInteresSoles
            'dr(12) = i.montoInteresUSD
            Select Case i.entregaPendiente
                Case "SI"
                    dr(10) = "Aprobado"
                Case Else
                    dr(10) = "Pendiente"
            End Select


            If i.idDocumento > 0 Then
                dr(11) = i.idDocumento
            End If


            dt.Rows.Add(dr)
        Next
        Return dt

    End Function



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

    Private Sub treeViewAdv2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles treeViewAdv2.MouseDoubleClick
        Select Case treeViewAdv2.SelectedNode.Text
            Case "Prestamos del Dia"
                TabPrestamoDia.Parent = TabPrestamos
                TabAprobacion.Parent = Nothing
                TabDesembolso.Parent = Nothing
                TabCobros.Parent = Nothing
                TabPagos.Parent = Nothing
                TabVencidas.Parent = Nothing

                Label15.Text = "PRESTAMOS DEL DIA"

                'Case "Prestamos del Periodo"

                '    TabPrestamoDia.Parent = TabPrestamos
                '    TabAprobacion.Parent = Nothing
                '    TabDesembolso.Parent = Nothing
                '    TabCobros.Parent = Nothing
                '    TabPagos.Parent = Nothing
                '    TabVencidas.Parent = Nothing
                '    Label15.Text = "PRESTAMOS DEL PERIODO"

            Case "Prestamos Por Aprobar"
                TabAprobacion.Parent = TabPrestamos
                TabPrestamoDia.Parent = Nothing
                TabDesembolso.Parent = Nothing
                TabCobros.Parent = Nothing
                TabPagos.Parent = Nothing
                TabVencidas.Parent = Nothing
            Case "Prestamos Para Desembolsar"
                TabAprobacion.Parent = Nothing
                TabPrestamoDia.Parent = Nothing
                TabCobros.Parent = Nothing
                TabPagos.Parent = Nothing
                TabVencidas.Parent = Nothing
                TabDesembolso.Parent = TabPrestamos
            Case "Prestamos Recibidos"
                TabAprobacion.Parent = Nothing
                TabPrestamoDia.Parent = Nothing
                TabCobros.Parent = Nothing
                TabPagos.Parent = TabPrestamos
                TabDesembolso.Parent = Nothing
                TabVencidas.Parent = Nothing
            Case "Prestamos Otorgados"
                TabAprobacion.Parent = Nothing
                TabPrestamoDia.Parent = Nothing
                TabCobros.Parent = TabPrestamos
                TabPagos.Parent = Nothing
                TabDesembolso.Parent = Nothing
                TabVencidas.Parent = Nothing

            Case "Cuotas Vencidas"
                TabAprobacion.Parent = Nothing
                TabPrestamoDia.Parent = Nothing
                TabCobros.Parent = Nothing
                TabPagos.Parent = Nothing
                TabDesembolso.Parent = Nothing
                TabVencidas.Parent = TabPrestamos

        End Select
    End Sub

    Private Sub ToolStripButton22_Click(sender As Object, e As EventArgs) Handles ToolStripButton22.Click
        If tb19.ToggleState = ToggleButton2.ToggleButtonState.ON Then

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



        ElseIf tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF Then

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



        End If
    End Sub

    Private Sub treeViewAdv2_Click(sender As Object, e As EventArgs) Handles treeViewAdv2.Click

    End Sub

    Private Sub ButtonAdv10_Click(sender As Object, e As EventArgs) Handles ButtonAdv10.Click
        If Label15.Text = "PRESTAMOS DEL DIA" Then

            If tb19.ToggleState = ToggleButton2.ToggleButtonState.ON Then
                PrestamosEmitidos()
                lblEstado.Text = "Prestamos del día: " & DateTime.Now.Date
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
            ElseIf tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF Then
                PrestamosEmitidosRecibidos()
                lblEstado.Text = "Prestamos del día: " & DateTime.Now.Date
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
            End If
        End If
       
    End Sub

    Private Sub ButtonAdv7_Click(sender As Object, e As EventArgs) Handles ButtonAdv7.Click
        PrestamosEmitidosAprobar()
        lblEstado.Text = "Prestamos del día: " & DateTime.Now.Date
        Timer1.Enabled = True
        PanelError.Visible = True
        TiempoEjecutar(10)
    End Sub

    Private Sub ButtonAdv11_Click(sender As Object, e As EventArgs) Handles ButtonAdv11.Click
        PrestamosXPeriodo()
        lblEstado.Text = "Prestamos del período: " & PeriodoGeneral
        Timer1.Enabled = True
        PanelError.Visible = True
        TiempoEjecutar(10)
    End Sub

    Private Sub ToolStripButton20_Click(sender As Object, e As EventArgs) Handles ToolStripButton20.Click
        Me.Cursor = Cursors.WaitCursor
        Dim prestamoSA As New prestamosSA
        If Not IsNothing(Me.dgvPrestamos2.Table.CurrentRecord) Then

            If prestamoSA.PrestamoEstadoAprobado(Me.dgvPrestamos2.Table.CurrentRecord.GetValue("codigo")) = False Then
                Dim f As New frmConfirmarPrestamo
                'f.TipoPrestamoAprobado = "PO"
                f.UbicarPrestamo(Me.dgvPrestamos2.Table.CurrentRecord.GetValue("idDocumento"))
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                PrestamosEmitidosAprobar()
                Me.Cursor = Cursors.Arrow
            Else
                lblEstado.Text = "El prestámo ya fue aprobado!!"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(10)
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedor.KeyDown
        If e.Alt Then
            If e.KeyCode = Keys.Down Then
                If Not Me.PopupControlContainer5.IsShowing() Then
                    ' Let the popup align around the source textBox.
                    Me.PopupControlContainer5.ParentControl = Me.txtProveedor
                    ' Passing Point.Empty will align it automatically around the above ParentControl.
                    Me.PopupControlContainer5.ShowPopup(Point.Empty)

                    e.Handled = True
                End If
            End If
        End If
        '' Escape should close the popup.
        If e.KeyCode = Keys.Escape Then
            If Me.PopupControlContainer5.IsShowing() Then
                Me.PopupControlContainer5.HidePopup(PopupCloseType.Canceled)
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtProveedor.Text.Trim.Length > 0 Then
                Me.PopupControlContainer5.ParentControl = Me.txtProveedor
                Me.PopupControlContainer5.ShowPopup(Point.Empty)




                If cboTipoEntidad2.Text = "PR" Then
                    'CargarEntidadesXtipo(TIPO_ENTIDAD.PROVEEDOR, txtProveedor.Text.Trim)
                    CargarEntidadesXtipo(cboTipoEntidad2.Text, txtProveedor.Text.Trim)
                ElseIf cboTipoEntidad2.Text = "TR" Then
                    CargarTrabajadoresXnivel("TR", txtProveedor.Text.Trim)

                ElseIf cboTipoEntidad2.Text = "CL" Then
                    CargarEntidadesXtipo(cboTipoEntidad2.Text, txtProveedor.Text.Trim)
                End If

            End If
        End If
    End Sub

    Private Sub txtProveedor_TextChanged(sender As Object, e As EventArgs) Handles txtProveedor.TextChanged

    End Sub

    Private Sub ListView3_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListView3.MouseDoubleClick
        If ListView3.SelectedItems.Count > 0 Then
            Me.PopupControlContainer5.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub ListView3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView3.SelectedIndexChanged

    End Sub

    Private Sub PopupControlContainer5_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer5.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then


            If ListView3.SelectedItems.Count > 0 Then

                If cboTipoEntidad2.Text = "PR" Then

                    If tb20.ToggleState = ToggleButton2.ToggleButtonState.ON Then
                        PrestamosDesembolsoTipo(CInt(ListView3.SelectedItems(0).SubItems(0).Text), "POT", "PR")
                        Me.txtProveedor.Text = ListView3.SelectedItems(0).SubItems(1).Text
                        txtNroBusqueda2.Text = ListView3.SelectedItems(0).SubItems(3).Text

                    ElseIf tb20.ToggleState = ToggleButton2.ToggleButtonState.OFF Then
                        PrestamosDesembolsoTipo(CInt(ListView3.SelectedItems(0).SubItems(0).Text), "PRC", "PR")
                        Me.txtProveedor.Text = ListView3.SelectedItems(0).SubItems(1).Text
                        txtNroBusqueda2.Text = ListView3.SelectedItems(0).SubItems(3).Text
                    End If

                ElseIf cboTipoEntidad2.Text = "TR" Then

                    If tb20.ToggleState = ToggleButton2.ToggleButtonState.ON Then
                        PrestamosDesembolsoTipo(CInt(ListView3.SelectedItems(0).SubItems(0).Text), "POT", "TR")
                        Me.txtProveedor.Text = ListView3.SelectedItems(0).SubItems(1).Text
                        txtNroBusqueda2.Text = ListView3.SelectedItems(0).SubItems(3).Text

                    ElseIf tb20.ToggleState = ToggleButton2.ToggleButtonState.OFF Then
                        PrestamosDesembolsoTipo(CInt(ListView3.SelectedItems(0).SubItems(0).Text), "PRC", "TR")
                        Me.txtProveedor.Text = ListView3.SelectedItems(0).SubItems(1).Text
                        txtNroBusqueda2.Text = ListView3.SelectedItems(0).SubItems(3).Text
                    End If


                ElseIf cboTipoEntidad2.Text = "CL" Then

                    If tb20.ToggleState = ToggleButton2.ToggleButtonState.ON Then
                        PrestamosDesembolsoTipo(CInt(ListView3.SelectedItems(0).SubItems(0).Text), "POT", "CL")
                        Me.txtProveedor.Text = ListView3.SelectedItems(0).SubItems(1).Text
                        txtNroBusqueda2.Text = ListView3.SelectedItems(0).SubItems(3).Text

                    ElseIf tb20.ToggleState = ToggleButton2.ToggleButtonState.OFF Then
                        PrestamosDesembolsoTipo(CInt(ListView3.SelectedItems(0).SubItems(0).Text), "PRC", "CL")
                        Me.txtProveedor.Text = ListView3.SelectedItems(0).SubItems(1).Text
                        txtNroBusqueda2.Text = ListView3.SelectedItems(0).SubItems(3).Text
                    End If

                ElseIf cboTipoEntidad2.Text = "OT" Then

                    If tb20.ToggleState = ToggleButton2.ToggleButtonState.ON Then
                        PrestamosDesembolsoTipo(CInt(ListView3.SelectedItems(0).SubItems(0).Text), "POT", "OT")
                        Me.txtProveedor.Text = ListView3.SelectedItems(0).SubItems(1).Text
                        txtNroBusqueda2.Text = ListView3.SelectedItems(0).SubItems(3).Text

                    ElseIf tb20.ToggleState = ToggleButton2.ToggleButtonState.OFF Then
                        PrestamosDesembolsoTipo(CInt(ListView3.SelectedItems(0).SubItems(0).Text), "PRC", "OT")
                        Me.txtProveedor.Text = ListView3.SelectedItems(0).SubItems(1).Text
                        txtNroBusqueda2.Text = ListView3.SelectedItems(0).SubItems(3).Text
                    End If


                End If
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
    End Sub

    Private Sub ToolStripButton12_Click(sender As Object, e As EventArgs) Handles ToolStripButton12.Click
        If tb20.ToggleState = ToggleButton2.ToggleButtonState.ON Then
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
                f.txtCuotas.Value = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("NumCuotas")
                f.cboModo.Text = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("ModoPago")
                f.DateTimePickerAdv2.Value = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("fechaInicio")
                f.cboDiaPago.Text = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("diaPago")
                f.cbodiaplazo.Text = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("gracia")
                f.txtTipo.Text = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("tipo")
                f.txtcuentatipo.Text = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("cuenta")

                If Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("moneda") = "1" Then
                    f.txtMoneda.Text = "NACIONAL"
                    f.txtMoneda.Tag = "1"

                ElseIf Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("moneda") = "2" Then
                    f.txtMoneda.Text = "EXTRANJERO"
                    f.txtMoneda.Tag = "2"
                End If

                ' f.txttipocuenta.Text = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("cuentatipo")

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

        ElseIf tb20.ToggleState = ToggleButton2.ToggleButtonState.OFF Then

            If Not IsNothing(Me.dgvPrestamosUser2.Table.CurrentRecord) Then


                Dim f As New frmIngresoPrestamo

                f.listamontos(Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("idDocumento"))
                f.txtProveedor.Text = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("Beneficiario")
                f.txtProveedor.Tag = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("idBeneficiario")
                f.txtComprobante.Text = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("DocPrestamo")
                f.txtComprobante.Tag = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("tipoDoc")
                f.txtTipoCambio.Value = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("tipoCambio")
                f.txtFondoMN.Value = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("monto")
                f.txtFondoME.Value = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("montoUSD")
                f.lblIdPrestamo.Text = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("idDocumento")
                f.txtTipo.Text = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("tipo")

                f.txtcuentatipo.Text = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("cuenta")
                ' f.txttipocuenta.Text = Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("cuentatipo")

                If Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("moneda") = "1" Then
                    f.txtMoneda.Text = "NACIONAL"
                    f.txtMoneda.Tag = "1"

                ElseIf Me.dgvPrestamosUser2.Table.CurrentRecord.GetValue("moneda") = "2" Then
                    f.txtMoneda.Text = "EXTRANJERO"
                    f.txtMoneda.Tag = "2"
                End If


                f.lblMovimiento.Tag = "OEC"
                f.lblMovimiento.Text = "OTRAS ENTRADAS DE CAJA"
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT

                f.StartPosition = FormStartPosition.CenterParent
                f.WindowState = FormWindowState.Maximized
                f.ShowDialog()
                PrestamosDesembolsoAptos("PRC")

                Me.Cursor = Cursors.Arrow

            Else
                lblEstado.Text = "Seleccione un Item"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(10)
            End If




        End If
    End Sub

    Private Sub txtProveedor2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedor2.KeyDown
        If e.Alt Then
            If e.KeyCode = Keys.Down Then
                If Not Me.PopupControlContainer4.IsShowing() Then
                    ' Let the popup align around the source textBox.
                    Me.PopupControlContainer4.ParentControl = Me.txtProveedor2
                    ' Passing Point.Empty will align it automatically around the above ParentControl.
                    Me.PopupControlContainer4.ShowPopup(Point.Empty)

                    e.Handled = True
                End If
            End If
        End If
        '' Escape should close the popup.
        If e.KeyCode = Keys.Escape Then
            If Me.PopupControlContainer4.IsShowing() Then
                Me.PopupControlContainer4.HidePopup(PopupCloseType.Canceled)
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtProveedor2.Text.Trim.Length > 0 Then
                Me.PopupControlContainer4.ParentControl = Me.txtProveedor2
                Me.PopupControlContainer4.ShowPopup(Point.Empty)
                ' CargarEntidadesXtipo2(cboTipoEntidad3.Text, txtProveedor2.Text.Trim)

                If cboTipoEntidad3.Text = "PR" Then
                    ' CargarEntidadesXtipo(cboTipoEntidad2.Text, txtProveedor.Text.Trim)
                    CargarEntidadesXtipo2(cboTipoEntidad3.Text, txtProveedor2.Text.Trim)
                ElseIf cboTipoEntidad3.Text = "TR" Then
                    CargarTrabajadoresXnivelCobro("TR", txtProveedor2.Text.Trim)

                ElseIf cboTipoEntidad3.Text = "CL" Then
                    CargarEntidadesXtipo2(cboTipoEntidad3.Text, txtProveedor2.Text.Trim)
                End If


            End If
        End If
    End Sub

    Private Sub txtProveedor2_TextChanged(sender As Object, e As EventArgs) Handles txtProveedor2.TextChanged

    End Sub

    Private Sub PopupControlContainer4_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer4.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor2.SelectedItems.Count > 0 Then

                

                If cboTipoEntidad3.Text = "PR" Then

                    PrestamosDesembolsoAprobado2(CInt(lsvProveedor2.SelectedItems(0).SubItems(0).Text), "PR")
                    Me.txtProveedor2.Tag = lsvProveedor2.SelectedItems(0).SubItems(0).Text
                    Me.txtProveedor2.Text = lsvProveedor2.SelectedItems(0).SubItems(1).Text
                    txtNroBusqueda3.Text = lsvProveedor2.SelectedItems(0).SubItems(3).Text

                ElseIf cboTipoEntidad3.Text = "TR" Then

                    PrestamosDesembolsoAprobado2(CInt(lsvProveedor2.SelectedItems(0).SubItems(0).Text), "TR")
                    Me.txtProveedor2.Tag = lsvProveedor2.SelectedItems(0).SubItems(0).Text
                    Me.txtProveedor2.Text = lsvProveedor2.SelectedItems(0).SubItems(1).Text
                    txtNroBusqueda3.Text = lsvProveedor2.SelectedItems(0).SubItems(3).Text

                ElseIf cboTipoEntidad3.Text = "CL" Then

                    PrestamosDesembolsoAprobado2(CInt(lsvProveedor2.SelectedItems(0).SubItems(0).Text), "CL")
                    Me.txtProveedor2.Tag = lsvProveedor2.SelectedItems(0).SubItems(0).Text
                    Me.txtProveedor2.Text = lsvProveedor2.SelectedItems(0).SubItems(1).Text
                    txtNroBusqueda3.Text = lsvProveedor2.SelectedItems(0).SubItems(3).Text

             

                End If

            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
    End Sub

    Private Sub TextBoxExt3_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxExt3.KeyDown
        If e.Alt Then
            If e.KeyCode = Keys.Down Then
                If Not Me.PopupControlContainer6.IsShowing() Then
                    ' Let the popup align around the source textBox.
                    Me.PopupControlContainer6.ParentControl = Me.TextBoxExt3
                    ' Passing Point.Empty will align it automatically around the above ParentControl.
                    Me.PopupControlContainer6.ShowPopup(Point.Empty)

                    e.Handled = True
                End If
            End If
        End If
        '' Escape should close the popup.
        If e.KeyCode = Keys.Escape Then
            If Me.PopupControlContainer6.IsShowing() Then
                Me.PopupControlContainer6.HidePopup(PopupCloseType.Canceled)
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If TextBoxExt3.Text.Trim.Length > 0 Then
                Me.PopupControlContainer6.ParentControl = Me.TextBoxExt3
                Me.PopupControlContainer6.ShowPopup(Point.Empty)
                'CargarEntidadesXtipo2(cboTipoEntidad3.Text, txtProveedor2.Text.Trim)
                If ComboBox1.Text = "PR" Then
                    CargarEntidadesXtipoP(TIPO_ENTIDAD.PROVEEDOR, TextBoxExt3.Text.Trim)
                ElseIf ComboBox1.Text = "TR" Then
                    CargarTrabajadoresXnivel2("TR", TextBoxExt3.Text.Trim)

                ElseIf ComboBox1.Text = "CL" Then
                    CargarEntidadesXtipoP("CL", TextBoxExt3.Text.Trim)
                End If

               

               


            End If
        End If
    End Sub

    Private Sub TextBoxExt3_TextChanged(sender As Object, e As EventArgs) Handles TextBoxExt3.TextChanged

    End Sub

    Private Sub ListView2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListView2.MouseDoubleClick
        If ListView2.SelectedItems.Count > 0 Then
            Me.PopupControlContainer6.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub ListView2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView2.SelectedIndexChanged

    End Sub

    Private Sub PopupControlContainer6_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer6.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If ListView2.SelectedItems.Count > 0 Then

                If ComboBox1.Text = "PR" Then
                    PrestamosDesembolsoAprobadoP(CInt(ListView2.SelectedItems(0).SubItems(0).Text), "PR")
                    Me.TextBoxExt3.Tag = ListView2.SelectedItems(0).SubItems(0).Text
                    Me.TextBoxExt3.Text = ListView2.SelectedItems(0).SubItems(1).Text
                    TextBox1.Text = ListView2.SelectedItems(0).SubItems(3).Text
                ElseIf ComboBox1.Text = "TR" Then
                    PrestamosDesembolsoAprobadoP(CInt(ListView2.SelectedItems(0).SubItems(0).Text), "TR")
                    Me.TextBoxExt3.Tag = ListView2.SelectedItems(0).SubItems(0).Text
                    Me.TextBoxExt3.Text = ListView2.SelectedItems(0).SubItems(1).Text
                    TextBox1.Text = ListView2.SelectedItems(0).SubItems(3).Text
                ElseIf ComboBox1.Text = "CL" Then
                    PrestamosDesembolsoAprobadoP(CInt(ListView2.SelectedItems(0).SubItems(0).Text), "CL")
                    Me.TextBoxExt3.Tag = ListView2.SelectedItems(0).SubItems(0).Text
                    Me.TextBoxExt3.Text = ListView2.SelectedItems(0).SubItems(1).Text
                    TextBox1.Text = ListView2.SelectedItems(0).SubItems(3).Text
                End If

            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
    End Sub

    Private Sub lsvProveedor2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvProveedor2.MouseDoubleClick
        If lsvProveedor2.SelectedItems.Count > 0 Then
            Me.PopupControlContainer4.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub lsvProveedor2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvProveedor2.SelectedIndexChanged

    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        If Not IsNothing(Me.GridGroupingControl4.Table.CurrentRecord) Then



            If Me.GridGroupingControl4.Table.CurrentRecord.GetValue("estado") = "PG" Then

                lblEstado.Text = "El prestamo ya fue Saldado"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(10)

            Else

                Dim f As New frmPrestamosCobro
                f.UbicarDocumento(Me.GridGroupingControl4.Table.CurrentRecord.GetValue("idDocumento"))
                f.txtcuentatipo.Text = Me.GridGroupingControl4.Table.CurrentRecord.GetValue("cuenta")
                f.StartPosition = FormStartPosition.CenterParent
                f.WindowState = FormWindowState.Maximized
                f.ShowDialog()

                If cboTipoEntidad3.Text = "PR" Then
                    If txtProveedor2.Tag > 0 Then
                        PrestamosDesembolsoAprobado2(CInt(txtProveedor2.Tag), "PR")
                    End If
                ElseIf cboTipoEntidad3.Text = "TR" Then
                    If txtProveedor2.Tag > 0 Then
                        PrestamosDesembolsoAprobado2(CInt(txtProveedor2.Tag), "TR")
                       
                    End If
                ElseIf cboTipoEntidad3.Text = "CL" Then
                    If txtProveedor2.Tag > 0 Then
                        PrestamosDesembolsoAprobado2(CInt(txtProveedor2.Tag), "CL")

                    End If

                End If


                End If
        Else
                lblEstado.Text = "Seleccione un Item"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(10)
        End If


    End Sub

    Private Sub ToolStripButton15_Click(sender As Object, e As EventArgs) Handles ToolStripButton15.Click
        If Not IsNothing(Me.GridGroupingControl5.Table.CurrentRecord) Then

           


            '3456
            If Me.GridGroupingControl5.Table.CurrentRecord.GetValue("estado") = "PG" Then

                lblEstado.Text = "El prestamo ya fue Saldado"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(10)

            Else

                Dim f As New frmPrestamosPago

                f.UbicarDocumento(Me.GridGroupingControl5.Table.CurrentRecord.GetValue("idDocumento"))
                f.txtcuentatipo.Text = Me.GridGroupingControl5.Table.CurrentRecord.GetValue("cuenta")
                f.StartPosition = FormStartPosition.CenterParent
                f.WindowState = FormWindowState.Maximized
                f.ShowDialog()

                If ComboBox1.Text = "PR" Then
                    If TextBoxExt3.Tag > 0 Then
                        PrestamosDesembolsoAprobadoP(CInt(TextBoxExt3.Tag), "PR")
                    End If
                ElseIf ComboBox1.Text = "TR" Then
                    If TextBoxExt3.Tag > 0 Then
                        PrestamosDesembolsoAprobadoP(CInt(TextBoxExt3.Tag), "TR")
                    End If
                ElseIf ComboBox1.Text = "CL" Then
                    If TextBoxExt3.Tag > 0 Then
                        PrestamosDesembolsoAprobadoP(CInt(TextBoxExt3.Tag), "CL")
                    End If
                End If


                End If

        Else
                lblEstado.Text = "Seleccione un Item"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(10)
        End If





    End Sub

    Private Sub FrmPrestamosGeneral_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabPrestamoDia.Parent = TabPrestamos
        TabAprobacion.Parent = Nothing
        TabDesembolso.Parent = Nothing
        TabCobros.Parent = Nothing
        TabPagos.Parent = Nothing
        TabVencidas.Parent = Nothing
        Label15.Text = "PRESTAMOS DEL DIA"
    End Sub

    Private Sub TextBoxExt4_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxExt4.KeyDown
        If e.Alt Then
            If e.KeyCode = Keys.Down Then
                If Not Me.PopupControlContainer7.IsShowing() Then
                    ' Let the popup align around the source textBox.
                    Me.PopupControlContainer7.ParentControl = Me.TextBoxExt4
                    ' Passing Point.Empty will align it automatically around the above ParentControl.
                    Me.PopupControlContainer7.ShowPopup(Point.Empty)

                    e.Handled = True
                End If
            End If
        End If
        '' Escape should close the popup.
        If e.KeyCode = Keys.Escape Then
            If Me.PopupControlContainer7.IsShowing() Then
                Me.PopupControlContainer7.HidePopup(PopupCloseType.Canceled)
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If TextBoxExt4.Text.Trim.Length > 0 Then
                Me.PopupControlContainer7.ParentControl = Me.TextBoxExt4
                Me.PopupControlContainer7.ShowPopup(Point.Empty)
                'CargarEntidadesXtipo2(cboTipoEntidad3.Text, txtProveedor2.Text.Trim)
                If ComboBox2.Text = "PR" Then
                    CargarEntidadesXtipoVen(TIPO_ENTIDAD.PROVEEDOR, TextBoxExt4.Text.Trim)
                ElseIf ComboBox2.Text = "TR" Then
                    CargarTrabajadoresXnivelVen("TR", TextBoxExt4.Text.Trim)

                ElseIf ComboBox2.Text = "CL" Then
                    CargarEntidadesXtipoVen("CL", TextBoxExt4.Text.Trim)
                End If


                'If ComboBox1.Text = "PR" Then
                '    CargarEntidadesXtipoP(TIPO_ENTIDAD.PROVEEDOR, TextBoxExt3.Text.Trim)
                'ElseIf ComboBox1.Text = "TR" Then
                '    CargarTrabajadoresXnivel2("TR", TextBoxExt3.Text.Trim)

                'ElseIf ComboBox1.Text = "CL" Then
                '    CargarEntidadesXtipoP("CL", TextBoxExt3.Text.Trim)
                'End If


            End If
        End If
    End Sub

    Private Sub TextBoxExt4_TextChanged(sender As Object, e As EventArgs) Handles TextBoxExt4.TextChanged

    End Sub

    Private Sub ListView4_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListView4.MouseDoubleClick
        If ListView4.SelectedItems.Count > 0 Then
            Me.PopupControlContainer7.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub ListView4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView4.SelectedIndexChanged

    End Sub

    Private Sub PopupControlContainer7_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer7.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If ListView4.SelectedItems.Count > 0 Then

                If tb25.ToggleState = ToggleButton2.ToggleButtonState.ON Then
                    'otorgados
                    CuotasVencidasProv(CInt(ListView4.SelectedItems(0).SubItems(0).Text), "POT")


                ElseIf tb25.ToggleState = ToggleButton2.ToggleButtonState.OFF Then
                    CuotasVencidasProv(CInt(ListView4.SelectedItems(0).SubItems(0).Text), "PRC")
                End If

                Me.TextBoxExt4.Text = ListView4.SelectedItems(0).SubItems(1).Text
                TextBox2.Text = ListView4.SelectedItems(0).SubItems(3).Text

            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
    End Sub

    Private Sub ButtonAdv16_Click(sender As Object, e As EventArgs) Handles ButtonAdv16.Click
        If tb25.ToggleState = ToggleButton2.ToggleButtonState.ON Then
            'otorgados
            TodasCuotasVencidas("POT")


        ElseIf tb25.ToggleState = ToggleButton2.ToggleButtonState.OFF Then
            TodasCuotasVencidas("PRC")
        End If
    End Sub

    Private Sub ButtonAdv17_Click(sender As Object, e As EventArgs) Handles ButtonAdv17.Click
        PrestamosOtorgadosPeriodo(PeriodoGeneral)
    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click



        If Not IsNothing(Me.GridGroupingControl4.Table.CurrentRecord) Then

            With frmHistorialPagoPrest
                .IdDocumentoCompra = Me.GridGroupingControl4.Table.CurrentRecord.GetValue("idDocumento")
                .LoadHistorialCajasXcompra()
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

    Private Sub ToolStripButton16_Click(sender As Object, e As EventArgs) Handles ToolStripButton16.Click
        If Not IsNothing(Me.GridGroupingControl5.Table.CurrentRecord) Then

            With frmHistorialPagoPrest
                .IdDocumentoCompra = Me.GridGroupingControl5.Table.CurrentRecord.GetValue("idDocumento")
                .LoadHistorialCajasXcompra()
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

    Private Sub ButtonAdv18_Click(sender As Object, e As EventArgs) Handles ButtonAdv18.Click
        PrestamosOtorgadosPeriodoR(PeriodoGeneral)
    End Sub

    Private Sub ToolStripButton25_Click(sender As Object, e As EventArgs) Handles ToolStripButton25.Click
        Dim f As New frmPrestamo
        'f.TipoPrestamoAprobado = "PO"
        f.UbicarPrestamo(Me.dgvPrestamos.Table.CurrentRecord.GetValue("idDocumento"))

        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        ' PrestamosEmitidosAprobar()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub tb20_ButtonStateChanged(sender As Object, e As ToggleButton2.ToggleButtonStateEventArgs) Handles tb20.ButtonStateChanged
        If tb20.ToggleState = ToggleButton2.ToggleButtonState.ON Then


            ToolStripButton12.Text = "Cobrar Desembolso"

        ElseIf tb20.ToggleState = ToggleButton2.ToggleButtonState.OFF Then

            ToolStripButton12.Text = "Desembolsar"

        End If
    End Sub

    Private Sub tb20_Click(sender As Object, e As EventArgs) Handles tb20.Click

    End Sub
End Class