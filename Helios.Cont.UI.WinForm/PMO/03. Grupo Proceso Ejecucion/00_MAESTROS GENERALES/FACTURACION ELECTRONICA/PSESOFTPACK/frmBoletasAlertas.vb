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

Public Class frmBoletasAlertas
#Region "Constructor"
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        GetTableGrid()
        FormatoGridAvanzado(dgvBoletas, False, False)
        ' Add any initialization after the InitializeComponent() call.
        txtPeriodo.Value = DateTime.Now
    End Sub
#End Region

#Region "Metodos"
    Sub GetTableGrid()
        Dim dt As New DataTable()

        dt.Columns.Add("Fecha")
        dt.Columns.Add("TipoDoc")
        dt.Columns.Add("Cantidad")
        dgvBoletas.DataSource = dt
    End Sub



    Public Sub NotasBoletasPeriodo()
        Dim documentosa As New documentoVentaAbarrotesSA

        Dim consulta = documentosa.NotasBoletasPeriodo(txtPeriodo.Value, "07", Gempresas.IdEmpresaRuc)

        dgvBoletas.Table.Records.DeleteAll()




        For Each i In consulta
            Me.dgvBoletas.Table.AddNewRecord.SetCurrent()
            Me.dgvBoletas.Table.AddNewRecord.BeginEdit()
            Me.dgvBoletas.Table.CurrentRecord.SetValue("Fecha", i.fechaDoc)
            Me.dgvBoletas.Table.CurrentRecord.SetValue("TipoDoc", i.tipoDocumento)
            Me.dgvBoletas.Table.CurrentRecord.SetValue("Cantidad", i.CantNotaBol)
            Me.dgvBoletas.Table.AddNewRecord.EndEdit()
        Next

    End Sub


    Public Sub BoletasPeriodo()
        Dim documentosa As New documentoVentaAbarrotesSA

        Dim consulta = documentosa.BoletasPeriodo(txtPeriodo.Value, "03", Gempresas.IdEmpresaRuc)

        dgvBoletas.Table.Records.DeleteAll()




        For Each i In consulta
            Me.dgvBoletas.Table.AddNewRecord.SetCurrent()
            Me.dgvBoletas.Table.AddNewRecord.BeginEdit()
            Me.dgvBoletas.Table.CurrentRecord.SetValue("Fecha", i.fechaDoc)
            Me.dgvBoletas.Table.CurrentRecord.SetValue("TipoDoc", i.tipoDocumento)
            Me.dgvBoletas.Table.CurrentRecord.SetValue("Cantidad", i.CantBol)
            Me.dgvBoletas.Table.AddNewRecord.EndEdit()
        Next

    End Sub

    Public Sub BoletasAnuladas()
        Dim documentosa As New documentoVentaAbarrotesSA

        Dim consulta = documentosa.BoletasAnuladasPeriodo(txtPeriodo.Value, "03", Gempresas.IdEmpresaRuc)

        dgvBoletas.Table.Records.DeleteAll()




        For Each i In consulta
            Me.dgvBoletas.Table.AddNewRecord.SetCurrent()
            Me.dgvBoletas.Table.AddNewRecord.BeginEdit()
            Me.dgvBoletas.Table.CurrentRecord.SetValue("Fecha", i.fechaDoc)
            Me.dgvBoletas.Table.CurrentRecord.SetValue("TipoDoc", i.tipoDocumento)
            Me.dgvBoletas.Table.CurrentRecord.SetValue("Cantidad", i.CantBolAnu)
            Me.dgvBoletas.Table.AddNewRecord.EndEdit()
        Next

    End Sub

    Public Sub FacturasAnuladas()
        Dim documentosa As New documentoVentaAbarrotesSA

        Dim consulta = documentosa.FacturasAnuladasPeriodo(txtPeriodo.Value, "01", Gempresas.IdEmpresaRuc)

        dgvBoletas.Table.Records.DeleteAll()

        For Each i In consulta
            Me.dgvBoletas.Table.AddNewRecord.SetCurrent()
            Me.dgvBoletas.Table.AddNewRecord.BeginEdit()
            Me.dgvBoletas.Table.CurrentRecord.SetValue("Fecha", i.fechaDoc)
            Me.dgvBoletas.Table.CurrentRecord.SetValue("TipoDoc", i.tipoDocumento)
            Me.dgvBoletas.Table.CurrentRecord.SetValue("Cantidad", i.CantFactAnu)
            Me.dgvBoletas.Table.AddNewRecord.EndEdit()
        Next

    End Sub

#End Region
    Private Sub frmBoletasAlertas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If txtTipoDoc.Text.Trim.Length > 0 Then
            Select Case txtTipoDoc.Text
                Case "03"
                    BoletasPeriodo()
                Case "07"
                    NotasBoletasPeriodo()
                Case "ANUBOL"
                    BoletasAnuladas()
                Case "ANU"
                    FacturasAnuladas()
            End Select
        End If



    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        If txtTipoDoc.Text.Trim.Length > 0 Then
            Select Case txtTipoDoc.Text
                Case "03"
                    BoletasPeriodo()
                Case "07"
                    NotasBoletasPeriodo()
                Case "ANUBOL"
                    BoletasAnuladas()
                Case "ANU"
                    FacturasAnuladas()
            End Select
        End If
    End Sub
End Class