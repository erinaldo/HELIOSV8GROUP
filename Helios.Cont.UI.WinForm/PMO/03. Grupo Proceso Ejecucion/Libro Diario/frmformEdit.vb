Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess

Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Public Class frmformEdit
    Inherits frmMaster

#Region "Métodos"


    Public Sub EditarLibroDiario()
        
        Dim asiento As New documentoLibroDiario
        Dim asientoSA As New documentoLibroDiarioSA
        Dim ListaAsiento As New List(Of documentoLibroDiarioDetalle)
        Dim movimiento As New documentoLibroDiarioDetalle

        asiento = New documentoLibroDiario
        asiento.idDocumento = txtFechaComprobante.Tag
        asiento.fecha = txtFechaComprobante.Value
        asiento.infoReferencial = txtGlosa.Text.Trim

        SumaTotalDebeMN = 0
        SumaTotalHaberMN = 0

        SumaTotalDebeME = 0
        SumaTotalHaberME = 0

        For Each r As Record In dgvCompra.Table.Records
            movimiento = New documentoLibroDiarioDetalle
            movimiento.secuencia = r.GetValue("id")
            movimiento.cuenta = r.GetValue("cuenta")
            movimiento.descripcion = r.GetValue("Modulo")

            Dim s As String = r.GetValue("tipoAsiento").ToString
            If s.Trim.Length > 0 Then
                Select Case r.GetValue("tipoAsiento")
                    Case "DEBE"
                        movimiento.tipoAsiento = "D"
                        If Not IsNumeric(r.GetValue("importeMN")) Then

                            lblEstado.Text = "Ingrese un formato correcto en importe"
                            PanelError.Visible = True
                            Timer1.Enabled = True
                            TiempoEjecutar(10)

                            Exit Sub
                        Else
                            If Not IsDBNull(r.GetValue("importeMN")) Then

                                If CDec(r.GetValue("importeMN")) > 0 Then
                                    movimiento.importeMN = CDec(r.GetValue("importeMN"))
                                Else

                                    lblEstado.Text = "Ingrese el importe (M.N.)."
                                    PanelError.Visible = True
                                    Timer1.Enabled = True
                                    TiempoEjecutar(10)
                                    Exit Sub
                                End If
                            End If
                        End If

                        If Not IsNumeric(r.GetValue("importeME")) Then

                            lblEstado.Text = "Ingrese un formato correcto en el importe"
                            PanelError.Visible = True
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                            Exit Sub
                        Else
                            If Not IsDBNull(r.GetValue("importeME")) Then

                                If CDec(r.GetValue("importeME")) > 0 Then
                                    movimiento.importeME = CDec(r.GetValue("importeME"))
                                Else

                                    lblEstado.Text = "Ingrese el importe (M.E.)."
                                    PanelError.Visible = True
                                    Timer1.Enabled = True
                                    TiempoEjecutar(10)
                                    Exit Sub
                                End If
                            End If
                        End If

                        'ConteoMN += CDec(r.GetValue("importeMN"))
                        'ConteoME += CDec(r.GetValue("importeME"))
                    Case Else
                        movimiento.tipoAsiento = "H"

                        If Not IsNumeric(r.GetValue("HaberMN")) Then

                            lblEstado.Text = "Ingrese un formato correcto en importe"
                            PanelError.Visible = True
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                            Exit Sub
                        Else
                            If Not IsDBNull(r.GetValue("HaberMN")) Then

                                If CDec(r.GetValue("HaberMN")) > 0 Then
                                    movimiento.importeMN = CDec(r.GetValue("HaberMN"))
                                Else

                                    lblEstado.Text = "Ingrese el importe (M.N.)."
                                    PanelError.Visible = True
                                    Timer1.Enabled = True
                                    TiempoEjecutar(10)
                                    Exit Sub
                                End If
                            End If
                        End If

                        If Not IsNumeric(r.GetValue("HaberME")) Then

                            lblEstado.Text = "Ingrese un formato correcto en importe"
                            PanelError.Visible = True
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                            Exit Sub
                        Else
                            If Not IsDBNull(r.GetValue("HaberME")) Then

                                If CDec(r.GetValue("HaberME")) > 0 Then
                                    movimiento.importeME = CDec(r.GetValue("HaberME"))
                                Else

                                    lblEstado.Text = "Ingrese el importe (M.E.)."
                                    PanelError.Visible = True
                                    Timer1.Enabled = True
                                    TiempoEjecutar(10)
                                    Exit Sub
                                End If
                            End If
                        End If

                        'ConteoMN += CDec(r.GetValue("importeMN"))
                        'ConteoME += CDec(r.GetValue("importeME"))
                End Select
            Else

                lblEstado.Text = "Debe indicar la ubicación del asiento!"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(10)
                Exit Sub
            End If

            ListaAsiento.Add(movimiento)

            SumaTotalDebeMN += CDec(r.GetValue("importeMN"))
            SumaTotalHaberMN += CDec(r.GetValue("HaberMN"))

            SumaTotalDebeME += CDec(r.GetValue("importeME"))
            SumaTotalHaberME += CDec(r.GetValue("HaberME"))
        Next

        asiento.importeMN = SumaTotalDebeMN
        asiento.importeME = SumaTotalDebeME


        asiento.documentoLibroDiarioDetalle = ListaAsiento


        'asientoSA.ActualizarDocumentoLibroDiario(asiento)
        'n.NomProceso = "Grabado"
        'n.Montomn = SumaTotalDebeMN
        'n.Montomn = SumaTotalDebeME
        'datos.Add(n)
        Dispose()
    End Sub



    Public Sub UbicarDocumentoLibro(intIdDocumento As Integer)

        Dim movimientoSA As New documentoLibroDiarioSA
        Dim dt As New DataTable
        Dim documentoSA As New documentoLibroDiarioSA

        With documentoSA.UbicarDocumentoLibroDiario(intIdDocumento)
            txtFechaComprobante.Value = .fecha
            txtFechaComprobante.Tag = .idDocumento
            txtGlosa.Text = .infoReferencial
        End With

        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("Modulo", GetType(String))
        dt.Columns.Add("cuenta", GetType(String))
        dt.Columns.Add("tipoAsiento", GetType(String))
        dt.Columns.Add("importeMN", GetType(Decimal))
        dt.Columns.Add("HaberMN", GetType(Decimal))
        dt.Columns.Add("importeME", GetType(Decimal))
        dt.Columns.Add("HaberME", GetType(Decimal))

        For Each i As documentoLibroDiarioDetalle In movimientoSA.GetUbicar_documentoLibroDiarioDetallePorIDDocumento(intIdDocumento)
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.secuencia
            dr(1) = i.descripcion
            dr(2) = i.cuenta

            Select Case i.tipoAsiento
                Case "D"
                    dr(3) = "DEBE"
                    dr(4) = i.importeMN
                    dr(5) = 0
                    dr(6) = i.importeME
                    dr(7) = 0
                Case "H"
                    dr(3) = "HABER"
                    dr(4) = 0
                    dr(5) = i.importeMN
                    dr(6) = 0
                    dr(7) = i.importeME
            End Select
            dt.Rows.Add(dr)
        Next
        dgvCompra.DataSource = dt
    End Sub



    Public Sub UbicarDocumento(intIdAsiento As Integer)
        Dim asientoSA As New AsientoSA
        Dim movimientoSA As New MovimientoSA
        Dim dt As New DataTable

        With asientoSA.UbicarAsientoPorIDAsiento(intIdAsiento)
            txtFechaComprobante.Value = .fechaProceso
            txtFechaComprobante.Tag = .idAsiento
            txtGlosa.Text = .glosa
        End With

        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("Modulo", GetType(String))
        dt.Columns.Add("cuenta", GetType(String))
        dt.Columns.Add("tipoAsiento", GetType(String))
        dt.Columns.Add("importeMN", GetType(Decimal))
        dt.Columns.Add("HaberMN", GetType(Decimal))
        dt.Columns.Add("importeME", GetType(Decimal))
        dt.Columns.Add("HaberME", GetType(Decimal))

        For Each i As movimiento In movimientoSA.UbicarMovimientosXidDocumento(CInt(txtFechaComprobante.Tag))
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.idmovimiento
            dr(1) = i.descripcion
            dr(2) = i.cuenta

            Select Case i.tipo
                Case "D"
                    dr(3) = "DEBE"
                    dr(4) = i.monto
                    dr(5) = 0
                    dr(6) = i.montoUSD
                    dr(7) = 0
                Case "H"
                    dr(3) = "HABER"
                    dr(4) = 0
                    dr(5) = i.monto
                    dr(6) = 0
                    dr(7) = i.montoUSD
            End Select
            dt.Rows.Add(dr)
        Next
        dgvCompra.DataSource = dt
    End Sub
    Dim SumaTotalDebeMN As Decimal = 0
    Dim SumaTotalHaberMN As Decimal = 0

    Dim SumaTotalDebeME As Decimal = 0
    Dim SumaTotalHaberME As Decimal = 0

    Public Sub EditarAsiento()
        'Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        'Dim n As New RecuperarCarteras
        'datos.Clear()
        Dim asiento As New asiento
        Dim asientoSA As New AsientoSA
        Dim ListaAsiento As New List(Of movimiento)
        Dim movimiento As New movimiento

        asiento = New asiento
        asiento.idAsiento = txtFechaComprobante.Tag
        asiento.fechaProceso = txtFechaComprobante.Value
        asiento.glosa = txtGlosa.Text.Trim

        SumaTotalDebeMN = 0
        SumaTotalHaberMN = 0

        SumaTotalDebeME = 0
        SumaTotalHaberME = 0

        For Each r As Record In dgvCompra.Table.Records
            movimiento = New movimiento
            movimiento.idmovimiento = r.GetValue("id")
            movimiento.idAsiento = CInt(txtFechaComprobante.Tag)
            movimiento.cuenta = r.GetValue("cuenta")
            movimiento.descripcion = r.GetValue("Modulo")

            Dim s As String = r.GetValue("tipoAsiento").ToString
            If s.Trim.Length > 0 Then
                Select Case r.GetValue("tipoAsiento")
                    Case "DEBE"
                        movimiento.tipo = "D"
                        If Not IsNumeric(r.GetValue("importeMN")) Then
                            PanelError.Visible = True
                            lblEstado.Text = "Ingrese un formato correcto en importe"
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                            Exit Sub
                        Else
                            If Not IsDBNull(r.GetValue("importeMN")) Then

                                If CDec(r.GetValue("importeMN")) > 0 Then
                                    movimiento.monto = CDec(r.GetValue("importeMN"))
                                Else
                                    PanelError.Visible = True
                                    lblEstado.Text = "Ingrese el importe (M.N.)."
                                    Timer1.Enabled = True
                                    TiempoEjecutar(10)
                                    Exit Sub
                                End If
                            End If
                        End If

                        If Not IsNumeric(r.GetValue("importeME")) Then
                            PanelError.Visible = True
                            lblEstado.Text = "Ingrese un formato correcto en el importe"
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                            Exit Sub
                        Else
                            If Not IsDBNull(r.GetValue("importeME")) Then

                                If CDec(r.GetValue("importeME")) > 0 Then
                                    movimiento.montoUSD = CDec(r.GetValue("importeME"))
                                Else
                                    PanelError.Visible = True
                                    lblEstado.Text = "Ingrese el importe (M.E.)."
                                    Timer1.Enabled = True
                                    TiempoEjecutar(10)
                                    Exit Sub
                                End If
                            End If
                        End If

                        'ConteoMN += CDec(r.GetValue("importeMN"))
                        'ConteoME += CDec(r.GetValue("importeME"))
                    Case Else
                        movimiento.tipo = "H"

                        If Not IsNumeric(r.GetValue("HaberMN")) Then
                            PanelError.Visible = True
                            lblEstado.Text = "Ingrese un formato correcto en importe"
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                            Exit Sub
                        Else
                            If Not IsDBNull(r.GetValue("HaberMN")) Then

                                If CDec(r.GetValue("HaberMN")) > 0 Then
                                    movimiento.monto = CDec(r.GetValue("HaberMN"))
                                Else
                                    PanelError.Visible = True
                                    lblEstado.Text = "Ingrese el importe (M.N.)."
                                    Timer1.Enabled = True
                                    TiempoEjecutar(10)
                                    Exit Sub
                                End If
                            End If
                        End If

                        If Not IsNumeric(r.GetValue("HaberME")) Then
                            PanelError.Visible = True
                            lblEstado.Text = "Ingrese un formato correcto en importe"
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                            Exit Sub
                        Else
                            If Not IsDBNull(r.GetValue("HaberME")) Then

                                If CDec(r.GetValue("HaberME")) > 0 Then
                                    movimiento.montoUSD = CDec(r.GetValue("HaberME"))
                                Else
                                    PanelError.Visible = True
                                    lblEstado.Text = "Ingrese el importe (M.E.)."
                                    Timer1.Enabled = True
                                    TiempoEjecutar(10)
                                    Exit Sub
                                End If
                            End If
                        End If

                        'ConteoMN += CDec(r.GetValue("importeMN"))
                        'ConteoME += CDec(r.GetValue("importeME"))
                End Select
            Else
                PanelError.Visible = True
                lblEstado.Text = "Debe indicar la ubicación del asiento!"
                Timer1.Enabled = True
                TiempoEjecutar(10)
                Exit Sub
            End If

            ListaAsiento.Add(movimiento)


            SumaTotalDebeMN += CDec(r.GetValue("importeMN"))
            SumaTotalHaberMN += CDec(r.GetValue("HaberMN"))

            SumaTotalDebeME += CDec(r.GetValue("importeME"))
            SumaTotalHaberME += CDec(r.GetValue("HaberME"))
        Next

        asiento.importeMN = SumaTotalDebeMN
        asiento.importeME = SumaTotalDebeME

        asiento.movimiento = ListaAsiento

        asientoSA.ActualizarAsientoDetalleXidAsiento(asiento)
        'n.NomProceso = "Grabado"
        'n.Montomn = SumaTotalDebeMN
        'n.Montomn = SumaTotalDebeME
        'datos.Add(n)
        Dispose()
    End Sub

#End Region

    Private Sub frmformEdit_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dispose()
    End Sub

#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean



        parpadear = Not parpadear
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick

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

    Private Sub frmformEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub VerGuíaToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnConfiguracion_Click(sender As Object, e As EventArgs) Handles btnConfiguracion.Click

        If Tag = "asiento" Then
            EditarAsiento()

        ElseIf Tag = "compra" Then
            EditarLibroDiario()

        End If
    End Sub

    Private Sub dgvCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompra.TableControlCellClick

    End Sub

    Private Sub dgvCompra_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvCompra.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            'Select Case ColIndex
            '    Case 4
            '        e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 6, GridSetCurrentCellOptions.SetFocus)

            '        'Case 7
            '        '    e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 10, GridSetCurrentCellOptions.SetFocus)
            'End Select

            If ColIndex = 3 Then
                Dim importeDebeME As Decimal = 0

                If CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("importeMN")) > 0 Then
                    Me.dgvCompra.Table.CurrentRecord.SetValue("HaberMN", 0)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("HaberME", 0)
                    importeDebeME = Math.Round(CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("importeMN")) / txtTipoCambio.Value, 2)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("importeME", importeDebeME)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("tipoAsiento", "DEBE")
                End If

            End If
            If ColIndex = 4 Then
                Dim importeHaberME As Decimal = 0

                Me.dgvCompra.Table.CurrentRecord.SetValue("importeME", 0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("importeMN", 0)
                importeHaberME = Math.Round(CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("HaberMN")) / txtTipoCambio.Value, 2)
                Me.dgvCompra.Table.CurrentRecord.SetValue("HaberME", importeHaberME)
                Me.dgvCompra.Table.CurrentRecord.SetValue("tipoAsiento", "HABER")

            End If
        End If
    End Sub
End Class