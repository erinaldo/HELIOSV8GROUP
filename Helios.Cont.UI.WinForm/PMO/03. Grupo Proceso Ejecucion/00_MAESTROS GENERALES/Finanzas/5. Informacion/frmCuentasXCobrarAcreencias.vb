Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Tools
Public Class frmCuentasXCobrarAcreencias

#Region "Attributes"

#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'GridCFG(dgvUsuarioActivo)
        FormatoGridPequeño(dgvGeneralCobros, True)
    End Sub
#End Region

#Region "Methods"

    Private Sub OtrasAcreencias()
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


        documentoLibro = documentoVentaSA.CobrosGeneralesAsiento()

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
                dr(7) = CDec(0)
                dr(8) = i.montocrono


                dr(9) = i.importeME
                dr(10) = i.ImportePagoME
                dr(11) = i.importeME - i.ImportePagoME
                dr(12) = CDec(0)
                dr(13) = i.montocronome

                'doccompra.ImportePagoVencidoMN = i.PagoDeudaVencida.GetValueOrDefault
                'doccompra.ImportePagoVencidoME = i.PagoDeudaVencidaME.GetValueOrDefault

                dt.Rows.Add(dr)

            Next


            dgvGeneralCobros.DataSource = dt
            Me.dgvGeneralCobros.TableOptions.ListBoxSelectionMode = SelectionMode.One

            dgvGeneralCobros.TableDescriptor.Columns("razonSocial").Width = 0
            dgvGeneralCobros.TableDescriptor.Columns("cuenta").Width = 70
            dgvGeneralCobros.TableDescriptor.Columns("descripcion").Width = 180
        Else

        End If
    End Sub

    Private Sub AcreenciasGenerales()
        Dim documentoVentaSA As New documentoVentaAbarrotesSA
        Dim documentoLibro As New List(Of documentoventaAbarrotes)
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



        documentoLibro = documentoVentaSA.CobrosGenerales()

        If Not IsNothing(documentoLibro) Then


            For Each i In documentoLibro
                Dim dr As DataRow = dt.NewRow()

                dr(0) = i.idCliente
                dr(1) = ""
                dr(2) = ""
                dr(3) = i.NombreEntidad

                dr(4) = i.ImporteNacional
                dr(5) = i.importeCostoMN
                dr(6) = i.ImporteNacional - i.importeCostoMN
                dr(7) = CDec(0)
                dr(8) = i.montocrono


                dr(9) = i.ImporteExtranjero
                dr(10) = i.importeCostoME
                dr(11) = i.ImporteExtranjero - i.importeCostoME
                dr(12) = CDec(0)
                dr(13) = i.montocronome

                'doccompra.ImportePagoVencidoMN = i.PagoDeudaVencida.GetValueOrDefault
                'doccompra.ImportePagoVencidoME = i.PagoDeudaVencidaME.GetValueOrDefault

                dt.Rows.Add(dr)

            Next
            dgvGeneralCobros.DataSource = dt
            Me.dgvGeneralCobros.TableOptions.ListBoxSelectionMode = SelectionMode.One

            dgvGeneralCobros.TableDescriptor.Columns("cuenta").Width = 0
            dgvGeneralCobros.TableDescriptor.Columns("descripcion").Width = 0
            dgvGeneralCobros.TableDescriptor.Columns("razonSocial").Width = 180
        Else

        End If
    End Sub


#Region "TIMER"

#End Region
#End Region

#Region "Events"
    Private Sub ButtonAdv49_Click(sender As Object, e As EventArgs) Handles ButtonAdv49.Click
        AcreenciasGenerales()
    End Sub

    Private Sub ButtonAdv47_Click(sender As Object, e As EventArgs) Handles ButtonAdv47.Click
        OtrasAcreencias()
    End Sub
#End Region
End Class