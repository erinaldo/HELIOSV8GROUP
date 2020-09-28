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

Public Class frmEstadoCobrosGeneral
    Inherits frmMaster

#Region "Metodos"
    Private Sub Programacion()
        Dim documentoVentaSA As New documentoVentaAbarrotesSA
        Dim documentoLibro As New List(Of documentoventaAbarrotes)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        Dim entidadSA As New entidadSA
        Dim personaSA As New PersonaSA


        dt.Columns.Add("idProveedor", GetType(Integer))
        dt.Columns.Add("razonSocial", GetType(String))
        dt.Columns.Add("deuda", GetType(Decimal))
        dt.Columns.Add("montoPago", GetType(Decimal))
        dt.Columns.Add("saldo", GetType(Decimal))
        dt.Columns.Add("montoVencido", GetType(Decimal))
        dt.Columns.Add("montoProg", GetType(Decimal))
        dt.Columns.Add("deudaME", GetType(Decimal))
        dt.Columns.Add("montoPagoME", GetType(Decimal))
        dt.Columns.Add("saldome", GetType(Decimal))
        dt.Columns.Add("montoVencidoME", GetType(Decimal))
        dt.Columns.Add("montoProgME", GetType(Decimal))


        documentoLibro = documentoVentaSA.CobrosGenerales()

        If Not IsNothing(documentoLibro) Then


            For Each i In documentoLibro
                Dim dr As DataRow = dt.NewRow()

                dr(0) = i.idCliente 
                dr(1) = i.NombreEntidad

                dr(2) = i.ImporteNacional
                dr(3) = i.importeCostoMN
                dr(4) = i.ImporteNacional - i.importeCostoMN
                dr(5) = i.montovencido - i.ImportePagoVencidoMN
                dr(6) = i.montocrono


                dr(7) = i.ImporteExtranjero
                dr(8) = i.importeCostoME
                dr(9) = i.ImporteExtranjero - i.importeCostoME
                dr(10) = i.montovencidome - i.ImportePagoVencidoME
                dr(11) = i.montocronome

                'doccompra.ImportePagoVencidoMN = i.PagoDeudaVencida.GetValueOrDefault
                'doccompra.ImportePagoVencidoME = i.PagoDeudaVencidaME.GetValueOrDefault

                dt.Rows.Add(dr)

            Next


            dgvProcesoCrono.DataSource = dt
            Me.dgvProcesoCrono.TableOptions.ListBoxSelectionMode = SelectionMode.One


        Else

        End If
    End Sub
#End Region

    Private Sub frmEstadoCobrosGeneral_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmEstadoCobrosGeneral_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdv7_Click(sender As Object, e As EventArgs) Handles ButtonAdv7.Click
        Programacion()
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click

    End Sub
End Class