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
Imports System.Collections
Imports System.Collections.Specialized
Imports Syncfusion.Windows.Forms.Tools

Public Class frmPagosDesembolsado
    Inherits frmMaster

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        'GridCFG(dgvCompra)

        'Loadcontroles()
        'GetTableGrid()
        'ConfiguracionInicio()


    End Sub

#Region "Metodos"

    Public Sub EliminarPagoProgramado(idDocumento As Integer, estado As String)
        Dim LibroSA As New CronogramaSA
        Try

            LibroSA.EliminarPagoProgramado(idDocumento, estado)
            Dispose()
        Catch ex As Exception

            MessageBox.Show("No se pudo Eliminar el Pago!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Public Sub UpdateGasto(idCronograma As Integer, estado As String)
        Dim LibroSA As New CronogramaSA
        Dim nDocumentoLibro As New Cronograma()


        With nDocumentoLibro

            .idCronograma = idCronograma
            .estado = estado
            .idDocumentoPago = 0
            '.montoAutorizadoMN = txtImporteMN.Value
            '.montoAutorizadoME = txtImporteME.Value
            '.fechaoperacion = txtFecha.Value
            '.usuarioActualizacion = "Jiuni"
            '.fechaActualizacion = DateTime.Now

        End With

        LibroSA.ActualizarEstado(nDocumentoLibro)



    End Sub



    Public Sub UpdateGastoDelete(idCronograma As Integer, estado As String, iddoc As Integer)
        Dim LibroSA As New CronogramaSA
        Dim nDocumentoLibro As New Cronograma()


        With nDocumentoLibro

            .idCronograma = idCronograma
            .estado = estado
            .idDocumentoPago = 0
            '.montoAutorizadoMN = txtImporteMN.Value
            '.montoAutorizadoME = txtImporteME.Value
            '.fechaoperacion = txtFecha.Value
            '.usuarioActualizacion = "Jiuni"
            '.fechaActualizacion = DateTime.Now

        End With

        LibroSA.ActualizarEstadoDelete(nDocumentoLibro, iddoc)



    End Sub

    Public Sub UbicarDocumentosPagosProgramados(intIdItem As Integer, tipoRazon As String, tipoestado As String, mes As Integer)

        Dim documentoVentaSA As New CronogramaSA
        Dim documentoLibro As New List(Of Cronograma)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        Dim entidadSA As New entidadSA
        Dim personaSA As New PersonaSA
        'Dim monto As Decimal = CDec(0.0)
        'Dim montome As Decimal = CDec(0.0)


        'Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year


        'dt.Columns.Add("nombres", GetType(String))
        'dt.Columns.Add("serie", GetType(String))
        dt.Columns.Add("nrodoc", GetType(String))
        dt.Columns.Add("monto", GetType(Decimal))
        dt.Columns.Add("montome", GetType(Decimal))
        'dt.Columns.Add("tipo", GetType(String))
        'dt.Columns.Add("importe", GetType(Decimal))
        'dt.Columns.Add("importeme", GetType(Decimal))
        dt.Columns.Add("glosa", GetType(String))
        dt.Columns.Add("fecha", GetType(Date))
        dt.Columns.Add("fechaPago", GetType(Date))
        'dt.Columns.Add("estado", GetType(String))
        'dt.Columns.Add("idcronograma", GetType(Integer))
        'dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("idDocRef", GetType(Integer))
        'dt.Columns.Add("chBonif", GetType(Boolean))
        'dt.Columns.Add("valBonif", GetType(String))

        documentoLibro = documentoVentaSA.GetPagosxProgramacion(intIdItem, tipoRazon, tipoestado, mes)

        If Not IsNothing(documentoLibro) Then


            For Each i In documentoLibro
                Dim dr As DataRow = dt.NewRow()


                dr(0) = i.nrodoc
                dr(1) = i.montoAutorizadoMN
                dr(2) = i.montoAutorizadoME
                dr(3) = "Desembolso Programado"
                dr(4) = i.fechaoperacion
                dr(5) = i.fechaPago.GetValueOrDefault
                dr(6) = i.idDocumentoPago



                dt.Rows.Add(dr)

            Next

            'txtImporteMN.Value = monto
            'txtImporteME.Value = montome

            GridGroupingControl1.DataSource = dt
            'dgvProcesoCrono.ShowGroupDropArea = False
            'dgvProcesoCrono.TableDescriptor.GroupedColumns.Clear()
            'dgvProcesoCrono.TableDescriptor.GroupedColumns.Add("nombres")

            Me.GridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One


        Else

        End If


    End Sub
#End Region

    Private Sub frmPagosDesembolsado_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmPagosDesembolsado_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnGrabar_Click(sender As Object, e As EventArgs) Handles BtnGrabar.Click
        Me.Cursor = Cursors.WaitCursor

        If Not IsNothing(GridGroupingControl1.Table.CurrentRecord) Then


            If MessageBox.Show("Desea Eliminar el Item Seleccionado Se eliminaran los pagos realizados!", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                EliminarPagoProgramado(GridGroupingControl1.Table.CurrentRecord.GetValue("idDocRef"), txttipo.Text)

            End If
        Else
            ' MessageBox.Show("Seleccione un Item a Editar")
            MessageBox.Show("Seleccione un Item a Eliminar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Me.Cursor = Cursors.Arrow


    End Sub
End Class