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

Public Class frmDetalleNegociación
    Inherits frmMaster


#Region "Metodos"

    Public Sub eliminarCuotas()
        Dim cronogramaSA As New CronogramaSA
        Dim lista As New List(Of Cronograma)
        Dim docCrono As New Cronograma

        For Each i As Record In dgvObligaciones.Table.Records

            docCrono = New Cronograma
            docCrono.idCronograma = i.GetValue("idCronograma")
            lista.Add(docCrono)

        Next

        If lista.Count > 0 Then
            cronogramaSA.DeleteCronoDocumento(lista)
            Dispose()
        End If

    End Sub

    Public Sub UbicarDocumentoDetalleCobros(idDocumento As Integer)

        Dim documentoVentaSA As New CronogramaSA
        Dim documentoLibro As New List(Of Cronograma)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        Dim entidadSA As New entidadSA
        Dim personaSA As New PersonaSA
        Dim monto As Decimal = CDec(0.0)
        Dim montome As Decimal = CDec(0.0)


        'Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year


        dt.Columns.Add("fecha", GetType(Date))
        dt.Columns.Add("fechaPago", GetType(Date))
        dt.Columns.Add("importe", GetType(Decimal))
        dt.Columns.Add("importeme", GetType(Decimal))
        dt.Columns.Add("idCronograma", GetType(Integer))




        documentoLibro = documentoVentaSA.GetListarCronogramaDpcumento(idDocumento)

        If Not IsNothing(documentoLibro) Then


            For Each i In documentoLibro
                Dim dr As DataRow = dt.NewRow()




                dr(0) = i.fechaoperacion
                dr(1) = i.fechaPago

                dr(2) = i.montoAutorizadoMN
                dr(3) = i.montoAutorizadoME
                dr(4) = i.idCronograma




                dt.Rows.Add(dr)

            Next

            'txtImporteMN.Value = monto
            'txtImporteME.Value = montome

            dgvObligaciones.DataSource = dt
            'dgvProcesoCrono.ShowGroupDropArea = False
            'dgvProcesoCrono.TableDescriptor.GroupedColumns.Clear()
            'dgvProcesoCrono.TableDescriptor.GroupedColumns.Add("nombres")

            Me.dgvObligaciones.TableOptions.ListBoxSelectionMode = SelectionMode.One


        Else

        End If


    End Sub
#End Region

    Private Sub frmDetalleNegociación_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnGrabar_Click(sender As Object, e As EventArgs) Handles BtnGrabar.Click
        eliminarCuotas()
    End Sub
End Class