Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmIngresoXAnticipo

#Region "Attributes"
    Public Property empresaPeriodoSA As New empresaCierreMensualSA
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGrid(dgvOtrosAportes)
        GetMovimientosPeriodoAportes(GEstableciento.IdEstablecimiento, PeriodoGeneral, "AR", 1)
    End Sub
#End Region

#Region "Methods"
    Private Sub GetMovimientosPeriodoAportes(intIdEstablecimiento As Integer, strPeriodo As String, strMovimiento As String, intMoneda As Integer)
        Dim DocumentoCompraSA As New DocumentoCompraSA

        Dim dt As New DataTable("Movimientos - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("movimiento", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("tipoDocPago", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaCobro", GetType(String)))

        dt.Columns.Add(New DataColumn("numeroOperacion", GetType(String)))

        dt.Columns.Add(New DataColumn("moneda", GetType(String)))
        dt.Columns.Add(New DataColumn("montoSoles"))
        dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUsd"))

        dt.Columns.Add(New DataColumn("NomCajaOrigen", GetType(String)))
        dt.Columns.Add(New DataColumn("NomCajaDestino", GetType(String)))

        ' Dim str As String
        'For Each i As documentoCaja In documentoCajaSA.ObtenerMovimientosPorPeriodoFinanzas(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, strPeriodo, strMovimiento)

        '    If (i.moneda = 1) Then

        '        Dim dr As DataRow = dt.NewRow()
        '        str = Nothing
        '        str = CDate(i.fechaCobro).ToString("dd-MMM hh:mm tt ")
        '        dr(0) = i.idDocumento
        '        dr(1) = i.tipoOperacion
        '        Select Case i.movimientoCaja
        '            Case "AR"
        '                dr(2) = "ANTICIPOS RECIBIDO"
        '        End Select
        '        dr(3) = str
        '        dr(4) = i.numeroOperacion
        '        Select Case i.moneda
        '            Case 1
        '                dr(5) = "NACIONAL"
        '        End Select
        '        dr(6) = CDec(i.montoSoles).ToString("N2")
        '        dr(7) = i.tipoCambio
        '        dr(8) = CDec(i.montoUsd).ToString("N2")
        '        dr(9) = "-"
        '        dr(10) = i.NomCajaOrigen
        '        dt.Rows.Add(dr)

        '    ElseIf (i.moneda = 2) Then
        '        Dim dr As DataRow = dt.NewRow()
        '        str = Nothing
        '        str = CDate(i.fechaCobro).ToString("dd-MMM hh:mm tt ")
        '        dr(0) = i.idDocumento
        '        dr(1) = i.tipoOperacion
        '        Select Case i.movimientoCaja
        '            Case "AR"
        '                dr(2) = "ANTICIPOS RECIBIDO"
        '        End Select
        '        dr(3) = str
        '        dr(4) = i.numeroOperacion
        '        Select Case i.moneda
        '            Case 2
        '                dr(5) = "EXTRANJERA"
        '        End Select
        '        dr(6) = CDec(i.montoSoles).ToString("N2")
        '        dr(7) = i.tipoCambio
        '        dr(8) = CDec(i.montoUsd).ToString("N2")
        '        dr(9) = "-"
        '        dr(10) = i.NomCajaOrigen
        '        dt.Rows.Add(dr)
        '    End If
        '    'End If

        'Next
        'dgvOtrosAportes.DataSource = dt
    End Sub




#End Region

#Region "Events"
    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Dim fechaAnt = New Date(AnioGeneral, CInt(MesGeneral), 1)
        fechaAnt = fechaAnt.AddMonths(-1)
        Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
        If periodoAnteriorEstaCerrado = False Then
            MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
            Cursor = Cursors.Default
            Exit Sub
        End If

        Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = AnioGeneral, .mes = CInt(MesGeneral)})
        If Not IsNothing(valida) Then
            If valida = True Then
                MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If
        With frmModalAnticipo
            .CaptionLabels(0).Text = "Ingreso de Antipos"
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            .txtTipoCambio.Value = TmpTipoCambio
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        Me.Cursor = Cursors.WaitCursor
        GetMovimientosPeriodoAportes(GEstableciento.IdEstablecimiento, PeriodoGeneral, "AR", 1)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        If Not IsNothing(Me.dgvOtrosAportes.Table.CurrentRecord) Then

            With frmModalAnticipo
                '.Panel6.Visible = False
                .GroupBox5.Enabled = False
                .btOperacion.Visible = False
                .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                .UbicarDocumento(Me.dgvOtrosAportes.Table.CurrentRecord.GetValue("idDocumento"))
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With

        Else
            MessageBox.Show("Debe seleccionar una item!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
#End Region

End Class