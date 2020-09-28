Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess

Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Public Class frmCierreContable
    Inherits frmMaster

    Dim filter As GridDynamicFilter = New GridDynamicFilter()
    Private lblPeriodo As System.Windows.Forms.ToolStripLabel
    Private lblPeriodoLabel As System.Windows.Forms.ToolStripLabel

    Private Sub ConfiguracionInicio()
        Me.RibbonControlAdv1.QuickPanelVisible = True
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
        Me.RibbonControlAdv1.Header.AddQuickItem(Me.lblPeriodoLabel)
        Me.RibbonControlAdv1.Header.AddQuickItem(Me.lblPeriodo) 'ToolStripSeparator1
        ' Me.RibbonControlAdv1.Header.AddQuickItem(Me.ToolStripSeparator1)
        RibbonControlAdv1.RibbonHeaderImage = Syncfusion.Windows.Forms.Tools.RibbonHeaderImage.Birds
        'Me.rbnPrincipal.Header.AddQuickItem(btnAnio)
        'Me.rbnPrincipal.Header.AddQuickItem(cboAnio)
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

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        ConfiguracionInicio()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        GetCerradoEstadoPeriodo()
    End Sub

#Region "Métodos"
    Public Sub GetCerradoEstadoPeriodo()
        Dim cierreSA As New CierreContableSA
        Dim cierre As New cierrecontable
        cierre = cierreSA.RecuperarEstadoCierrePeriodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, PeriodoGeneral)

        If Not IsNothing(cierre) Then
            'Select cierre.estado
            '    Case "C"
            '        ToolStripButton1.Enabled = False
            '    Case "A"
            '        ToolStripButton1.Enabled = True
            'End Select
        Else
            ToolStripButton1.Enabled = True
        End If
    End Sub

    Public Function ObtenerCierreMovimientos() As DataTable
        Dim movimientosSA As New MovimientoSA
        Dim planContableSA As New cuentaplanContableEmpresaSA

        Dim dt As New DataTable("Balance de comprobación: " & PeriodoGeneral & " ")

        dt.Columns.Add(New DataColumn("cuenta", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("debe", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("haber", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("debeus", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("haberus", GetType(Decimal))) '
        dt.Columns.Add(New DataColumn("tipoasiento", GetType(String)))

        For Each i As movimiento In movimientosSA.GetObetnerCierrePorPeriodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, AnioGeneral, MesGeneral)
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.cuenta
            Dim str As String = i.cuenta.Substring(0, 2)
            dr(1) = planContableSA.ObtenerCuentaPorID(Gempresas.IdEmpresaRuc, str).descripcion
            Select Case i.tipo
                Case "D"
                    dr(2) = i.monto
                    dr(3) = 0
                Case "H"
                    dr(2) = 0
                    dr(3) = i.monto
            End Select

            Select Case i.tipo
                Case "D"
                    dr(4) = i.montoUSD
                    dr(5) = 0
                Case "H"
                    dr(4) = 0
                    dr(5) = i.montoUSD
            End Select
            dr(6) = i.tipo
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Public Function ObtenerCierreMovimientosCierre() As DataTable
        Dim movimientosSA As New CierreContableSA
        Dim planContableSA As New cuentaplanContableEmpresaSA

        Dim dt As New DataTable("Balance de comprobación: " & PeriodoGeneral & " ")

        dt.Columns.Add(New DataColumn("cuenta", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("debe", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("haber", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("debeus", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("haberus", GetType(Decimal))) '
        dt.Columns.Add(New DataColumn("tipoasiento", GetType(String)))

        For Each i As cierrecontable In movimientosSA.GetCargarCierrePorPeriodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, PeriodoGeneral)
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.cuenta
            Dim str As String = i.cuenta.Substring(0, 2)
            dr(1) = planContableSA.ObtenerCuentaPorID(Gempresas.IdEmpresaRuc, str).descripcion
            Select Case i.tipoasiento.Trim
                Case "D"
                    dr(2) = i.monto
                    dr(3) = 0
                Case "H"
                    dr(2) = 0
                    dr(3) = i.monto
            End Select

            Select Case i.tipoasiento.Trim
                Case "D"
                    dr(4) = i.montoUSD
                    dr(5) = 0
                Case "H"
                    dr(4) = 0
                    dr(5) = i.montoUSD
            End Select
            dr(6) = i.tipoasiento
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Public Sub GrabarCierre()
        Dim cierre As New cierrecontable
        Dim listaCierre As New List(Of cierrecontable)
        Dim cierreSA As New CierreContableSA
        Try
            For Each r As Record In dgvCierre.Table.Records
                cierre = New cierrecontable
                cierre.idEmpresa = Gempresas.IdEmpresaRuc
                cierre.idCentroCosto = GEstableciento.IdEstablecimiento
                cierre.periodo = PeriodoGeneral
                cierre.cuenta = r.GetValue("cuenta")
                cierre.tipoasiento = r.GetValue("tipoasiento").ToString.Trim
                cierre.anio = AnioGeneral
                cierre.mes = MesGeneral
                Select Case r.GetValue("tipoasiento")
                    Case "D"
                        cierre.monto = r.GetValue("debe")
                        cierre.montoUSD = r.GetValue("debeus")
                    Case "H"
                        cierre.monto = r.GetValue("haber")
                        cierre.montoUSD = r.GetValue("haberus")
                End Select

                cierre.usuarioActualizacion = "Jiuni"
                cierre.fechaActualizacion = DateTime.Now
                listaCierre.Add(cierre)
            Next r
            'cierreSA.GrabarListaAsientos(listaCierre)
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub

    Public Sub EditarCierre()
        Dim movimientosSA As New MovimientoSA
        Dim listaAsientos As New List(Of movimiento)
        Dim cierre As New cierrecontable
        Dim listaCierre As New List(Of cierrecontable)
        Dim cierreSA As New CierreContableSA
        Try
            listaAsientos = movimientosSA.GetObetnerCierrePorPeriodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, AnioGeneral, MesGeneral)
            For Each r In listaAsientos
                cierre = New cierrecontable
                cierre.idEmpresa = Gempresas.IdEmpresaRuc
                cierre.idCentroCosto = GEstableciento.IdEstablecimiento
                cierre.periodo = PeriodoGeneral
                cierre.cuenta = r.cuenta
                cierre.tipoasiento = r.tipo
                cierre.anio = AnioGeneral
                cierre.mes = MesGeneral
                Select Case r.tipo
                    Case "D"
                        cierre.monto = r.monto
                        cierre.montoUSD = r.montoUSD
                    Case "H"
                        cierre.monto = r.monto
                        cierre.montoUSD = r.montoUSD
                End Select

                cierre.usuarioActualizacion = "Jiuni"
                cierre.fechaActualizacion = DateTime.Now
                'cierre.estado = "C"
                '  Console.WriteLine(r.Info)
                '    MsgBox(r.Info)
                '     MsgBox(r.GetValue("Column2"))
                listaCierre.Add(cierre)
            Next r
            cierreSA.UpdateListaAsientos(listaCierre)
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub


    Public Sub GetCierre()
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim grupoActual As String = String.Empty
        Dim g As New ListViewGroup
        Dim cierreSA As New CierreContableSA
        Dim parentTable As New DataTable
        Try
            If cierreSA.CierreCerrado(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, PeriodoGeneral) = True Then
                parentTable = ObtenerCierreMovimientosCierre()
            Else
                parentTable = ObtenerCierreMovimientos()
            End If
            Me.dgvCierre.DataSource = parentTable
            dgvCierre.TableDescriptor.Relations.Clear()
            dgvCierre.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            dgvCierre.TableOptions.ListBoxSelectionMode = SelectionMode.One
            dgvCierre.Appearance.AnyRecordFieldCell.Enabled = False
            dgvCierre.GroupDropPanel.Visible = True
            dgvCierre.TableDescriptor.GroupedColumns.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub GetCierreMovimientosAsiento()
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim grupoActual As String = String.Empty
        Dim g As New ListViewGroup
        Dim cierreSA As New CierreContableSA
        Dim parentTable As New DataTable
        Try
            parentTable = ObtenerCierreMovimientos()
            Me.dgvCierre.DataSource = parentTable
            dgvCierre.TableDescriptor.Relations.Clear()
            dgvCierre.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            dgvCierre.TableOptions.ListBoxSelectionMode = SelectionMode.One
            dgvCierre.Appearance.AnyRecordFieldCell.Enabled = False
            dgvCierre.GroupDropPanel.Visible = True
            dgvCierre.TableDescriptor.GroupedColumns.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub GetCierreExistente()
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim grupoActual As String = String.Empty
        Dim g As New ListViewGroup
        Dim cierreSA As New CierreContableSA
        Dim parentTable As New DataTable
        Try
            If cierreSA.CierreCerrado(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, PeriodoGeneral) = True Then
                parentTable = ObtenerCierreMovimientosCierre()
            Else
                parentTable = ObtenerCierreMovimientos()
            End If
            Me.dgvCierre.DataSource = parentTable
            dgvCierre.TableDescriptor.Relations.Clear()
            dgvCierre.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            dgvCierre.TableOptions.ListBoxSelectionMode = SelectionMode.One
            dgvCierre.Appearance.AnyRecordFieldCell.Enabled = False
            dgvCierre.GroupDropPanel.Visible = True
            dgvCierre.TableDescriptor.GroupedColumns.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        PanelError.Visible = False
        Timer1.Enabled = False
    End Sub

    Private Sub frmCierreContable_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmCierreContable_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        Me.Cursor = Cursors.WaitCursor
        GetCierre()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        Me.Cursor = Cursors.WaitCursor
        GrabarCierre()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton4_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton4.Click
    
    End Sub

    Private Sub VerDataToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles VerDataToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        GetCierreMovimientosAsiento()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub UpdateCambiosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UpdateCambiosToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        EditarCierre()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnAperturar_Click(sender As System.Object, e As System.EventArgs) Handles btnAperturar.Click
        Me.Cursor = Cursors.WaitCursor
        Dim cierreContableSA As New CierreContableSA
        Dim cierre As New cierrecontable

        cierre = cierreContableSA.RecuperarEstadoCierrePeriodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, PeriodoGeneral)
        If Not IsNothing(cierre) Then
            'Select Case cierre.estado
            '    Case "C"
            '        cierreContableSA.AperturarPeriodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, PeriodoGeneral)
            '    Case "A"

            'End Select
        Else
            ' MsgBox("")
        End If


        Me.Cursor = Cursors.Arrow
    End Sub
End Class