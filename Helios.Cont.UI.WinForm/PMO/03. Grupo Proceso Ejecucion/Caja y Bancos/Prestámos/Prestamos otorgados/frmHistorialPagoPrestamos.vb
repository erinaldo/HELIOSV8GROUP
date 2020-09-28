Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.GridHelperClasses
Imports PopupControl
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Public Class frmHistorialPagoPrestamos
    Inherits frmMaster


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

#Region "Métodos"
    Public Sub EliminarDocumento(intIdDocumento As Integer)
        Dim documentoSA As New DocumentoSA
        Dim docCajaSA As New DocumentoCajaSA
        Dim nDocumento As New documento()

        'Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
        'Dim n As New RecuperarTablas
        '   datos.Clear()

        With nDocumento
            .IdDocumentoAfectado = Me.dgvHistorial.Table.CurrentRecord.GetValue("docPrestamo") ' documentoPrestamo origen
            .idDocumento = intIdDocumento
            .usuarioActualizacion = Me.dgvHistorial.Table.CurrentRecord.GetValue("user") ' docCajaSA.GetUbicar_documentoCajaPorID(intIdDocumento).usuarioModificacion
        End With
        documentoSA.EliminarPagoPrestamo(nDocumento)
        'n.NombreCampo = "ELIMINADO"
        'n.Codigo = "ELIMINADO"
        'datos.Add(n)
        Me.dgvHistorial.Table.CurrentRecord.Delete()
        lblEstado.Text = "Pago eliminado correctamente"
        PanelError.Visible = True
        Timer1.Enabled = True
        TiempoEjecutar(10)
        '  HistorialCompra(txtFechaCompra.ValueMember)
    End Sub

    Private Function getParentTableHistorial(intIdCuota As Integer) As DataTable
        Dim objLista As New DocumentoCajaDetalleSA()

        Dim dt As New DataTable("Historial de pagos")

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("fecha", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("DetalleItem", GetType(String)))
        dt.Columns.Add(New DataColumn("nomEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("nomDocumento", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String))) '
        dt.Columns.Add(New DataColumn("entregado", GetType(String)))
        dt.Columns.Add(New DataColumn("montoSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUsd", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("user", GetType(String)))
        dt.Columns.Add(New DataColumn("docPrestamo", GetType(String)))

        Dim str As String
        For Each i As documentoCajaDetalle In objLista.ObtenerHistorialPagoPrestamoXCuota(intIdCuota)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = str
            dr(2) = i.DetalleItem
            dr(3) = i.nomEntidad
            dr(4) = i.nomDocumento
            dr(5) = i.numeroDoc
            Select Case i.entregado
                Case "C"
                    dr(6) = "Capital"
                Case "I"
                    dr(6) = "Interés"
            End Select
            dr(7) = i.montoSoles
            dr(8) = i.montoUsd
            dr(9) = i.usuarioModificacion
            dr(10) = i.documentoAfectado
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Public Sub HistorialPretamos(intIdCuota As Integer)
        Dim objLista As New DocumentoCajaDetalleSA()
        dgvHistorial.TableDescriptor.Name = ("Historial prestámos-cuota")
        dgvHistorial.DataSource = getParentTableHistorial(intIdCuota) ' objLista.ObtenerHistorialPagos(intIdCompra)
        dgvHistorial.TableDescriptor.Relations.Clear()
        dgvHistorial.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
        dgvHistorial.TableOptions.ListBoxSelectionMode = SelectionMode.One
        dgvHistorial.ShowColumnHeaders = True
        dgvHistorial.GroupDropPanel.Visible = True
        Me.dgvHistorial.TopLevelGroupOptions.ShowCaption = False
        '  dgvPagos.TableOptions.ShowRowHeader = False
        dgvHistorial.Appearance.AnyRecordFieldCell.Enabled = False
        dgvHistorial.TableDescriptor.GroupedColumns.Clear()
        dgvHistorial.TableDescriptor.GroupedColumns.Add("nomDocumento")
    End Sub
#End Region

    Private Sub frmHistorialPagoPrestamos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmHistorialPagoPrestamos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PegarToolStripButton_Click(sender As Object, e As EventArgs) Handles PegarToolStripButton.Click
        Dispose()
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As Object, e As EventArgs) Handles GuardarToolStripButton.Click
     
        Try
            If Not IsNothing(Me.dgvHistorial.Table.CurrentRecord) Then
                EliminarDocumento(CInt(Me.dgvHistorial.Table.CurrentRecord.GetValue("idDocumento")))
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        PanelError.Visible = False
        Timer1.Enabled = False
    End Sub
End Class