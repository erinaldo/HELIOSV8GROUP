Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Tools
'Imports Helios.Planilla.Business.Entity
'Imports Helios.Planilla.WCFService.ServiceAccess
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Public Class frmOrdenServiciosGeneral

    Public Sub New()
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        QGlobalColorSchemeManager1.Global.CurrentTheme = Qios.DevSuite.Components.QColorScheme.LunaBlueThemeName
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.dockingManager1.DockControl(Me.Panel4, Me, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 350)
        'Me.dockingManager1.DockControl(Me.PanelServicios, Me, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 382)
        dockingManager1.DockControlInAutoHideMode(Panel4, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 350)
        'dockingManager1.DockControlInAutoHideMode(PanelServicios, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 382)
        dockingManager1.MDIActivatedVisibility = True
        'dockingClientPanel1.BringToFront()
        'Me.dockingClientPanel1.AutoScroll = True
        'Me.dockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        dockingManager1.SetDockLabel(Panel4, "Datos Generales")
        'dockingManager1.SetDockLabel(PanelServicios, "Servicios")


    End Sub

    Public Sub UbicarDocumentoServicio(intIdDocumento As Integer)
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim documentoDetalleSA As New DocumentoCompraDetalleSA
        Dim dt As DataTable
        dt = New DataTable()
        Dim entidadSA As New entidadSA
        Dim tablaDetalleSA As New tablaDetalleSA
        Dim docOtros As New DocumentoOtrosDatosSA
        Dim cFinancieraSA As New EstadosFinancierosSA

        With documentoCompraSA.UbicarDocumentoCompra(intIdDocumento)

            With docOtros.UbicarDocumentoOtros(intIdDocumento)


                If (Not IsNothing(.condicionPago)) Then
                    cboCondPago.Text = tablaDetalleSA.GetUbicarTablaID(501, CInt(.condicionPago)).descripcion
                End If

                If (Not IsNothing(.Vcto)) Then
                    dtpFechaVencimiento.Value = CDate(.Vcto).Date
                End If

                If (Not IsNothing(.Modalidad)) Then
                    cboModalidad2.Text = tablaDetalleSA.GetUbicarTablaID(1, .Modalidad).descripcion
                End If

                If (Not IsNothing(.ctaDeposito)) Then
                    txtcto.Text = .ctaDeposito
                End If

                If (Not IsNothing(.institucionFinanciera)) Then
                    With cFinancieraSA.ObtenerEstadosFinancierosPorCodigo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, .institucionFinanciera)
                        txtCajaOrigen.ValueMember = .idestado
                        txtCajaOrigen.Text = .descripcion
                    End With
                End If
            End With

            If (Not IsNothing(.idProveedor)) Then
                With entidadSA.UbicarEntidadPorID(.idProveedor).First
                    txtProveedor.Text = .nombreCompleto
                    txtProveedor.ValueMember = .idEntidad
                    txtRuc.Text = .nrodoc
                    txtCuenta.Text = .cuentaAsiento
                End With
            End If
            txtFechaComprobante.Value = .fechaDoc
        End With

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("secuencia", GetType(Integer))
        dt.Columns.Add("nroEntregable", GetType(Integer))
        dt.Columns.Add("descripcionItem", GetType(String))

        For Each row In documentoDetalleSA.UbicarDocumentoCompraDetalle(intIdDocumento)
            Dim dr As DataRow = dt.NewRow()
            dr(0) = row.idDocumento
            dr(1) = row.secuencia
            dr(2) = row.entregable
            dr(3) = row.descripcionItem

            dt.Rows.Add(dr)
        Next
        Me.dgvServicio.DataSource = dt
        Me.dgvServicio.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
    End Sub

    Public Sub UbicarDocumentos(intIdDocumento As Integer)
        Dim documentoCompraSA As New DocumentoOtrosDatosSA
        Dim docOtros As New DocumentoOtrosDatosSA

        With docOtros.UbicarDocumentoOtrosReferencia(intIdDocumento)
            fechainicio.Value = .fechaInicio
            fechafin.Value = .fechaFin

            txtContra.Text = .objetoContratacion
            cboObjetoContratacion.SelectedItem = .periodoValorizacion
            txtPenalidades.Text = .penalidades

            txtImporteContratacion.Value = .importeContratacionMN
            txtImporteContratacionME.Value = .importeContratacionME
            If (.detraccionesMN <> 0) Then
                nudDetraccion.Visible = True
                nudDetraccionME.Visible = True
                nudDetraccion.Value = .detraccionesMN
                nudDetraccionME.Value = .detraccionesME
                tbDetraccion.ToggleState = ToggleButtonState.Active
            Else
                nudDetraccion.Visible = False
                nudDetraccionME.Visible = False
                nudDetraccion.Value = 0
                nudDetraccionME.Value = 0
                tbDetraccion.ToggleState = ToggleButtonState.Inactive
            End If

            txtAdelanto.Value = .adelantoMN
            txtAdelantoME.Value = .adelantoME
            txtFondoGarantia.Value = .fondoGarantiaMN
            txtFondoGarantiaME.Value = .fondoGarantiaME
        End With
    End Sub

    Private Sub dgvServicio_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvServicio.TableControlCellClick
        If Not IsNothing(Me.dgvServicio.Table.CurrentRecord) Then
            limpiarCaja()
            txtNombreEntregable.Text = Me.dgvServicio.Table.CurrentRecord.GetValue("descripcionItem")
            UbicarDocumentos(Me.dgvServicio.Table.CurrentRecord.GetValue("secuencia"))
        End If
    End Sub

    Public Sub limpiarCaja()
        txtContra.Text = String.Empty
        cboObjetoContratacion.SelectedIndex = -1
        txtImporteContratacion.Value = 0.0
        txtAdelanto.Value = 0.0
        txtFondoGarantia.Text = 0.0
        nudDetraccion.Value = 0.0
        txtImporteContratacionME.Value = 0.0
        txtAdelantoME.Value = 0.0
        txtFondoGarantiaME.Text = 0.0
        nudDetraccionME.Value = 0.0
        txtPenalidades.Text = String.Empty
        fechainicio.Value = Date.Now
        fechafin.Value = Date.Now
        tbDetraccion.ToggleState = ToggleButtonState.Inactive
    End Sub

    Private Sub frmOrdenServiciosGeneral_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class