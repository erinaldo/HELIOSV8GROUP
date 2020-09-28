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

Public Class frmEstadoPagosGeneral

    Inherits frmMaster

#Region "Metodos"

    Private Sub ProgramacionAsiento()
        Dim documentoVentaSA As New DocumentoCompraSA
        Dim documentoLibro As New List(Of documentoLibroDiarioDetalle)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        Dim entidadSA As New entidadSA
        Dim personaSA As New PersonaSA

        dt.Columns.Add("idProveedor", GetType(Integer))
        dt.Columns.Add("cuenta", GetType(String))
        dt.Columns.Add("descripcion", GetType(String))
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


        documentoLibro = documentoVentaSA.DeudasGeneralesAsiento()

        If Not IsNothing(documentoLibro) Then


            For Each i In documentoLibro
                Dim dr As DataRow = dt.NewRow()

                dr(0) = 1
                dr(1) = i.cuenta
                dr(2) = i.descripcion
                dr(3) = ""

                dr(4) = i.importeMN
                dr(5) = i.ImportePagoMN
                dr(6) = i.importeMN - i.ImportePagoMN
                dr(7) = i.montovencido - i.ImportePagoVencidoMN
                dr(8) = i.montocrono


                dr(9) = i.importeME
                dr(10) = i.ImportePagoME
                dr(11) = i.importeME - i.ImportePagoME
                dr(12) = i.montovencidome - i.ImportePagoVencidoME
                dr(13) = i.montocronome

                'doccompra.ImportePagoVencidoMN = i.PagoDeudaVencida.GetValueOrDefault
                'doccompra.ImportePagoVencidoME = i.PagoDeudaVencidaME.GetValueOrDefault

                dt.Rows.Add(dr)

            Next


            dgvProcesoCrono.DataSource = dt
            Me.dgvProcesoCrono.TableOptions.ListBoxSelectionMode = SelectionMode.One

            dgvProcesoCrono.TableDescriptor.Columns("razonSocial").Width = 0
            dgvProcesoCrono.TableDescriptor.Columns("cuenta").Width = 70
            dgvProcesoCrono.TableDescriptor.Columns("descripcion").Width = 180
        Else

        End If
    End Sub


    Private Sub Programacion()
        Dim documentoVentaSA As New DocumentoCompraSA
        Dim documentoLibro As New List(Of documentocompra)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        Dim entidadSA As New entidadSA
        Dim personaSA As New PersonaSA


        dt.Columns.Add("idProveedor", GetType(Integer))
        dt.Columns.Add("cuenta", GetType(String))
        dt.Columns.Add("descripcion", GetType(String))
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





        documentoLibro = documentoVentaSA.DeudasGenerales()

        If Not IsNothing(documentoLibro) Then


            For Each i In documentoLibro
                Dim dr As DataRow = dt.NewRow()

                dr(0) = i.idProveedor
                dr(1) = ""
                dr(2) = ""
                dr(3) = i.NombreEntidad

                dr(4) = i.importeTotal
                dr(5) = i.ImportePagoMN
                dr(6) = i.importeTotal - i.ImportePagoMN
                dr(7) = i.montovencido - i.ImportePagoVencidoMN
                dr(8) = i.montocrono


                dr(9) = i.importeUS
                dr(10) = i.ImportePagoME
                dr(11) = i.importeUS - i.ImportePagoME
                dr(12) = i.montovencidome - i.ImportePagoVencidoME
                dr(13) = i.montocronome

                'doccompra.ImportePagoVencidoMN = i.PagoDeudaVencida.GetValueOrDefault
                'doccompra.ImportePagoVencidoME = i.PagoDeudaVencidaME.GetValueOrDefault

                dt.Rows.Add(dr)

            Next


            dgvProcesoCrono.DataSource = dt
            Me.dgvProcesoCrono.TableOptions.ListBoxSelectionMode = SelectionMode.One

            dgvProcesoCrono.TableDescriptor.Columns("cuenta").Width = 0
            dgvProcesoCrono.TableDescriptor.Columns("descripcion").Width = 0
        Else

        End If
    End Sub
#End Region

    Private Sub frmEstadoPagosGeneral_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdv7_Click(sender As Object, e As EventArgs) Handles ButtonAdv7.Click
        Programacion()
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        With frmFlujoPagos
            .StartPosition = FormStartPosition.CenterParent
            '.Label4.Text = "Obligaciones"
            '.cbotipo.Text = "PAGOS"
            .Size = New Size(1340, 708)
            .ShowDialog()
        End With
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        ProgramacionAsiento()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class