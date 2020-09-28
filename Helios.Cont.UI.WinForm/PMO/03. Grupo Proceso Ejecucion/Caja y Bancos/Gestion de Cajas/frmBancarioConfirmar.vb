Imports System.ComponentModel
Imports System.Drawing.Printing
Imports System.Runtime.Serialization
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.Presentation.WinForm
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Drawing
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Tools

Public Class frmBancarioConfirmar

#Region "Constructor"

    Sub New()


        ' This call is required by the designer.
        InitializeComponent()
        FormatoGridAvanzado(dgvbancario, False, False, 7.0F)
        GetTableGrid()
        txtPeriodo.Value = DateTime.Now
        ' Add any initialization after the InitializeComponent() call.

    End Sub


#End Region

#Region "Metodos"

    Sub GetTableGrid()
        Dim dt As New DataTable()
        'dt.Columns.Add("codigo", GetType(String))

        dt.Columns.Add("idDocumento")
        dt.Columns.Add("IdProveedor")
        dt.Columns.Add("nombreCompleto")
        dt.Columns.Add("tipoEntidad")
        dt.Columns.Add("nrodoc")
        dt.Columns.Add("formapago")
        dt.Columns.Add("tipoDocPago")
        dt.Columns.Add("numeroDoc")
        dt.Columns.Add("fechaProceso")
        dt.Columns.Add("fechaCobro")
        dt.Columns.Add("moneda")
        dt.Columns.Add("tipoOperacion")
        dt.Columns.Add("montoSoles")
        dt.Columns.Add("MovimientoCaja")
        dt.Columns.Add("numeroOperacion")
        dgvbancario.DataSource = dt
    End Sub

#End Region

#Region "Metodos"

    Public Sub ConfirmarPagoTarjeta(iddoc As Integer, fechacobro As DateTime)
        Try

            Dim documentocajasa As New DocumentoCajaSA

            documentocajasa.ConfirmarPagoTarjeta(iddoc, fechacobro)

            ListarPagosXConfirmar()
            MessageBox.Show("Se confirmo correctamente el pago")

        Catch ex As Exception
            MessageBox.Show("No se pudo confirmar el pago")
        End Try



    End Sub

    Public Sub ListarPagosXConfirmar()
        Dim documentocajasa As New DocumentoCajaSA

        dgvbancario.Table.Records.DeleteAll()

        Dim detalle = documentocajasa.GetPagosTarjetaxConfirmar(New documentoCaja With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                .fechaProceso = txtPeriodo.Value})

        For Each i In detalle


            Me.dgvbancario.Table.AddNewRecord.SetCurrent()
            Me.dgvbancario.Table.AddNewRecord.BeginEdit()

            Me.dgvbancario.Table.CurrentRecord.SetValue("idDocumento", i.idDocumento)
            Me.dgvbancario.Table.CurrentRecord.SetValue("IdProveedor", i.IdProveedor)
            Me.dgvbancario.Table.CurrentRecord.SetValue("nombreCompleto", i.NombreEntidad)
            Me.dgvbancario.Table.CurrentRecord.SetValue("tipoEntidad", i.tipo)
            Me.dgvbancario.Table.CurrentRecord.SetValue("nrodoc", i.NumeroDocumento)


            If i.formapago = "006" Then
                Me.dgvbancario.Table.CurrentRecord.SetValue("formapago", "TARJETA DE CREDITO")
            ElseIf i.formapago = "001" Then

                Me.dgvbancario.Table.CurrentRecord.SetValue("formapago", "DEPOSITO EN CUENTA")
            ElseIf i.formapago = "003" Then
                Me.dgvbancario.Table.CurrentRecord.SetValue("formapago", "TRANSFERENCIA DE FONDOS")
                ElseIf i.formapago = "005" Then
                Me.dgvbancario.Table.CurrentRecord.SetValue("formapago", "TARJETA DE DEBITO")
            ElseIf i.formapago = "007" Then
                Me.dgvbancario.Table.CurrentRecord.SetValue("formapago", "CHEQUES")
            ElseIf i.formapago = "011" Then
                Me.dgvbancario.Table.CurrentRecord.SetValue("formapago", "LETRAS DE CAMBIO")

            End If

            Me.dgvbancario.Table.CurrentRecord.SetValue("tipoDocPago", i.tipoDocPago)
            Me.dgvbancario.Table.CurrentRecord.SetValue("numeroDoc", i.numeroDoc)
            Me.dgvbancario.Table.CurrentRecord.SetValue("fechaProceso", i.fechaProceso)
            Me.dgvbancario.Table.CurrentRecord.SetValue("fechaCobro", i.fechaCobro)

            If i.moneda = "1" Then
                Me.dgvbancario.Table.CurrentRecord.SetValue("moneda", "NACIONAL")
            Else
                Me.dgvbancario.Table.CurrentRecord.SetValue("moneda", "EXTRANJERO")
            End If

            Me.dgvbancario.Table.CurrentRecord.SetValue("tipoOperacion", i.tipoOperacion)
            Me.dgvbancario.Table.CurrentRecord.SetValue("montoSoles", i.montoSoles)
            Me.dgvbancario.Table.CurrentRecord.SetValue("MovimientoCaja", i.movimientoCaja)
            Me.dgvbancario.Table.CurrentRecord.SetValue("numeroOperacion", i.numeroOperacion)


            Me.dgvbancario.Table.AddNewRecord.EndEdit()





        Next



    End Sub

#End Region


    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        ListarPagosXConfirmar()
    End Sub

    Private Sub frmBancarioConfirmar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        Dim r As Record
        Try
            r = dgvbancario.Table.CurrentRecord



            If r.GetValue("idDocumento") > 0 Then





                ConfirmarPagoTarjeta(CInt(r.GetValue("idDocumento")), CDate(r.GetValue("fechaCobro")))

            Else
                MessageBox.Show("Seleccione un Documento para Confirmar")

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
End Class