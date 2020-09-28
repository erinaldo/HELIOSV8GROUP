Imports System.ComponentModel
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.Presentation.WinForm
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports System.IO
Imports OpenInvoicePeru.Comun.Dto.Intercambio
Imports OpenInvoicePeru.Comun.Dto.Modelos

Public Class frmFacturasAlertas

#Region "Constructor"
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        GetTableGrid()
        FormatoGridAvanzado(dgvFacturas, False, False)
        ' Add any initialization after the InitializeComponent() call.
        txtPeriodo.Value = DateTime.Now
    End Sub
#End Region
#Region "METODOS"

    Public Sub BuscarDocsFechaPeriodo(fecha As DateTime, tipoDoc As String)
        Dim docSA As New documentoVentaAbarrotesSA
        dgvFacturas.Table.Records.DeleteAll()
        Dim consulta = docSA.BuscarFacturanoEnviadasPeriodo(fecha, tipoDoc, Gempresas.IdEmpresaRuc)


        For Each i In consulta
            Me.dgvFacturas.Table.AddNewRecord.SetCurrent()
            Me.dgvFacturas.Table.AddNewRecord.BeginEdit()
            Me.dgvFacturas.Table.CurrentRecord.SetValue("IdDocumento", i.idDocumento)
            Me.dgvFacturas.Table.CurrentRecord.SetValue("Serie", i.serieVenta)
            Me.dgvFacturas.Table.CurrentRecord.SetValue("Numero", i.numeroVenta)
            Me.dgvFacturas.Table.CurrentRecord.SetValue("TipoDocumento", i.tipoDocumento)
            Me.dgvFacturas.Table.CurrentRecord.SetValue("Importe", i.ImporteNacional)
            Me.dgvFacturas.Table.CurrentRecord.SetValue("Fecha", i.fechaDoc)
            Me.dgvFacturas.Table.AddNewRecord.EndEdit()


        Next


    End Sub


    Sub GetTableGrid()
        Dim dt As New DataTable()

        dt.Columns.Add("IdDocumento")
        dt.Columns.Add("Serie")
        dt.Columns.Add("Numero")
        dt.Columns.Add("TipoDocumento")
        dt.Columns.Add("Importe")
        dt.Columns.Add("Fecha")




        dgvFacturas.DataSource = dt
    End Sub
#End Region
    Private Sub frmFacturasAlertas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If txtTipoDoc.Text.Trim.Length > 0 Then
            Select Case txtTipoDoc.Text
                Case "01"
                    BuscarDocsFechaPeriodo(txtPeriodo.Value, "01")
                Case "07"
                    BuscarDocsFechaPeriodo(txtPeriodo.Value, "07")
                Case "08"
                    ' BuscarDocsFecha(dtpFechaDocs.Value, "08")


            End Select
        End If


    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Select Case txtTipoDoc.Text
            Case "01"
                BuscarDocsFechaPeriodo(txtPeriodo.Value, "01")
            Case "07"
                BuscarDocsFechaPeriodo(txtPeriodo.Value, "07")
            Case "08"
                ' BuscarDocsFecha(dtpFechaDocs.Value, "08")
            Case "ANU"

        End Select
    End Sub
End Class