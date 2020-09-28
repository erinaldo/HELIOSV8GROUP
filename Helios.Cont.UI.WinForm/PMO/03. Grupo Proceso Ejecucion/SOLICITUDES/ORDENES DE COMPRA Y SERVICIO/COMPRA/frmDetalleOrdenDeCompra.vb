Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Tools
Imports System.Collections
Imports Syncfusion.Windows.Forms.Grid
Imports System.Collections.Specialized
Imports Syncfusion.Grouping
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid.Grouping
Public Class frmDetalleOrdenDeCompra
    Public ManipulacionEstado As String
    Public dtCompra As New DataTable
    Public idDocumento As Integer
    Public objListaOtros As New List(Of documentoOtrosDatos)

    Public Sub New()

        InitializeComponent()
        GridCFG(dgvOrdenCompra)
        GridCFG(dgvHistorialDetalle)

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

#Region "Metodos"

    Sub GetTableGrid()
        Dim dt As New DataTable()

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("cantidad", GetType(String))
        dt.Columns.Add("descripcionItem", GetType(String))

        dgvOrdenCompra.DataSource = dt

        Dim dtLista As New DataTable()

        dtLista.Columns.Add("idDocumento", GetType(Integer))
        dtLista.Columns.Add("secuencia", GetType(Integer))
        dtLista.Columns.Add("cantidad", GetType(Integer))
        dtLista.Columns.Add("idAlmacen", GetType(String))
        dtLista.Columns.Add("nombreAlmacen", GetType(String))
        dtLista.Columns.Add("direccionAlmacen", GetType(String))
        dtLista.Columns.Add("fechainicio", GetType(String))
        dtLista.Columns.Add("fechaFin", GetType(String))
        dtLista.Columns.Add("indicaciones", GetType(String))

        dgvHistorialDetalle.DataSource = dtLista

    End Sub

    Sub GridCFG(grid As GridGroupingControl)
        grid.TableOptions.ShowRowHeader = False
        grid.TopLevelGroupOptions.ShowCaption = False

        Dim colorx As New GridMetroColors()
        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        grid.SetMetroStyle(colorx)
        grid.BorderStyle = System.Windows.Forms.BorderStyle.None
        grid.TableOptions.SelectionBackColor = Color.Gray
        grid.AllowProportionalColumnSizing = False
        grid.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        grid.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        grid.Table.DefaultColumnHeaderRowHeight = 25
        grid.Table.DefaultRecordRowHeight = 20
        grid.TableDescriptor.Appearance.AnyCell.Font.Size = 7.5F

    End Sub

    Public Sub UbicarDocumentoOrdenCompra(ByVal intIdDocumento As Integer)
        Dim objDocCompra As New DocumentoCompraSA
        Dim objDocCompraDet As New DocumentoCompraDetalleSA
        Dim objEntidad As New entidadSA
        Dim nEntidad As New entidad
        'Dim objListaOtros As New List(Of documentoOtrosDatos)
        Dim objOtrosSA As New DocumentoOtrosDatosSA

        Try

            GetTableGrid()

            With objDocCompra.UbicarDocumentoCompra(intIdDocumento)
                If Not IsNothing(.fechaConstancia) Then
                    txtFecha.Value = .fechaConstancia
                End If

                nEntidad = objEntidad.UbicarEntidadPorID(.idProveedor).First()
                txtRuc.Text = nEntidad.nrodoc
                txtProveedor.Tag = nEntidad.idEntidad
                txtProveedor.Text = nEntidad.nombreCompleto

            End With

            'DETALLE DE LA COMPRA
            dgvOrdenCompra.Table.Records.DeleteAll()

            For Each i In objDocCompraDet.UbicarDocumentoCompraDetalleSituacion(intIdDocumento, TIPO_COMPRA.ORDEN_COMPRA)

                Me.dgvOrdenCompra.Table.AddNewRecord.SetCurrent()
                Me.dgvOrdenCompra.Table.AddNewRecord.BeginEdit()
                Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("idDocumento", i.secuencia)
                Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("cantidad", i.monto1)
                Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("descripcionItem", i.descripcionItem)
                Me.dgvOrdenCompra.Table.AddNewRecord.EndEdit()
            Next



        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try

    End Sub

#End Region

    Private Sub dgvOrdenCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvOrdenCompra.TableControlCellClick
        'Me.Cursor = Cursors.WaitCursor
        Dim objOtrosSA As New DocumentoOtrosDatosSA
      
        If Not IsNothing(Me.dgvOrdenCompra.Table.CurrentRecord) Then

            objListaOtros = objOtrosSA.UbicarDocumentoOtrosHistorialEntrega(Me.dgvOrdenCompra.Table.CurrentRecord.GetValue("idDocumento"))
            'Dim consulta = (From a In objListaOtros Where a.idReferencia = Me.dgvOrdenCompra.Table.CurrentRecord.GetValue("idDocumento")).ToList
            Dim dt As New DataTable("Movimientos - período " & PeriodoGeneral & " ")
            Dim DocumentoOtrosDatosSA As New DocumentoOtrosDatosSA
            dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
            dt.Columns.Add(New DataColumn("secuencia", GetType(Integer)))
            dt.Columns.Add(New DataColumn("cantidad", GetType(Integer)))
            dt.Columns.Add(New DataColumn("idAlmacen", GetType(Integer)))
            dt.Columns.Add(New DataColumn("nombreAlmacen", GetType(String)))
            dt.Columns.Add(New DataColumn("direccionAlmacen", GetType(String)))
            dt.Columns.Add(New DataColumn("fechainicio", GetType(String)))
            dt.Columns.Add(New DataColumn("fechaFin", GetType(String)))
            dt.Columns.Add(New DataColumn("indicaciones", GetType(String)))


            For Each i As documentoOtrosDatos In objListaOtros
                Dim dr As DataRow = dt.NewRow()
                dr(0) = i.idDocumento
                dr(1) = i.secuencia
                dr(2) = i.cantidad
                dr(3) = i.idAlmacen
                dr(4) = i.nombreAlmacen
                dr(5) = i.direccionAlmacen
                dr(6) = CStr(i.fechaInicio)
                dr(7) = CStr(i.fechaFin)
                dr(8) = i.indicaciones

                dt.Rows.Add(dr)
            Next

            dgvHistorialDetalle.DataSource = dt

        End If



    End Sub
End Class