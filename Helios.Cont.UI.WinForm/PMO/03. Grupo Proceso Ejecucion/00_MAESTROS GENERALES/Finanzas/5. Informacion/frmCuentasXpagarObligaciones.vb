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
Public Class frmCuentasXpagarObligaciones
#Region "Attributes"

#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'GridCFG(dgvUsuarioActivo)
        FormatoGridPequeño(GridGroupingControl2, True)
    End Sub
#End Region

#Region "Methods"

    Private Sub ObligacionesGenerales()
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
                dr(7) = CDec(0)
                dr(8) = i.montocrono


                dr(9) = i.importeUS
                dr(10) = i.ImportePagoME
                dr(11) = i.importeUS - i.ImportePagoME
                dr(12) = CDec(0)
                dr(13) = i.montocronome

                'doccompra.ImportePagoVencidoMN = i.PagoDeudaVencida.GetValueOrDefault
                'doccompra.ImportePagoVencidoME = i.PagoDeudaVencidaME.GetValueOrDefault

                dt.Rows.Add(dr)

            Next


            GridGroupingControl2.DataSource = dt
            Me.GridGroupingControl2.TableOptions.ListBoxSelectionMode = SelectionMode.One

            GridGroupingControl2.TableDescriptor.Columns("cuenta").Width = 0
            GridGroupingControl2.TableDescriptor.Columns("descripcion").Width = 0
            GridGroupingControl2.TableDescriptor.Columns("razonSocial").Width = 180

        Else

        End If
    End Sub

    Private Sub OtrasObligaciones()
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


            GridGroupingControl2.DataSource = dt
            Me.GridGroupingControl2.TableOptions.ListBoxSelectionMode = SelectionMode.One

            GridGroupingControl2.TableDescriptor.Columns("razonSocial").Width = 0
            GridGroupingControl2.TableDescriptor.Columns("cuenta").Width = 70
            GridGroupingControl2.TableDescriptor.Columns("descripcion").Width = 180
        Else

        End If
    End Sub

#Region "TIMER"

#End Region
#End Region

#Region "Events"

    Private Sub ButtonAdv32_Click(sender As Object, e As EventArgs) Handles ButtonAdv32.Click
        LoadingAnimator.Wire(Me.GridGroupingControl2.TableControl)
        ObligacionesGenerales()
        LoadingAnimator.UnWire(Me.GridGroupingControl2.TableControl)
    End Sub

    Private Sub ButtonAdv30_Click(sender As Object, e As EventArgs) Handles ButtonAdv30.Click
        LoadingAnimator.Wire(Me.GridGroupingControl2.TableControl)
        OtrasObligaciones()
        LoadingAnimator.UnWire(Me.GridGroupingControl2.TableControl)
    End Sub
#End Region
End Class