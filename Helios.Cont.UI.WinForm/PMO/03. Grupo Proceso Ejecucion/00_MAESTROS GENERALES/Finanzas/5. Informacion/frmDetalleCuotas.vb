Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Tools

Public Class frmDetalleCuotas
    Inherits frmMaster

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        txtCliente.BorderStyle = BorderStyle.None
        txtRuc.BorderStyle = BorderStyle.None
        txtTipoProv.BorderStyle = BorderStyle.None
        txtSerie.BorderStyle = BorderStyle.None
        txtNumero.BorderStyle = BorderStyle.None
        txtDescripcion.BorderStyle = BorderStyle.None
        txtCuenta.BorderStyle = BorderStyle.None
        ' txtfechaprogramacion.BorderStyle = BorderStyle.None
        txtMoneda.BorderStyle = BorderStyle.None
        txtImporteCompramn.BorderStyle = BorderStyle.None
        txtImporteComprame.BorderStyle = BorderStyle.None

        ' Add any initialization after the InitializeComponent() call.
        'GridCFG(dgvPagosV)
        GridCFG(dgvPagosProgramados)
        GetTableGrid2()

      
        'txtPeriodo.Value = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Day)

        'getConfigGrid()
    End Sub

#Region "Metodos"

    Dim colorx As New GridMetroColors()
    Sub GridCFG(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = System.Windows.Forms.BorderStyle.None

        '  GGC.BrowseOnly = True
        'GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        'GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        'GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GGC.TableOptions.SelectionBackColor = Color.Gray
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        GGC.Table.DefaultColumnHeaderRowHeight = 23
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 7.5F

    End Sub

    Sub GetTableGrid2()
        Dim dt As New DataTable()

        dt.Columns.Add("cuota", GetType(String))
        dt.Columns.Add("fechaPago", GetType(Date))
        dt.Columns.Add("pago", GetType(Decimal))
        dt.Columns.Add("pagome", GetType(Decimal))
        dt.Columns.Add("estado", GetType(String))
        dgvPagosProgramados.DataSource = dt
    End Sub

    Public Sub UbicarCuotasPorDocumento(intIdItem As Integer)

        Dim documentoVentaSA As New CronogramaSA
        Dim documentoLibro As New List(Of Cronograma)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        Dim entidadSA As New entidadSA
        Dim personaSA As New PersonaSA
        Dim monto As Decimal = CDec(0.0)
        Dim montome As Decimal = CDec(0.0)
        Dim cuota As Integer = 0

        'Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year


        dt.Columns.Add("cuota", GetType(String))
        dt.Columns.Add("fechaPago", GetType(Date))
        dt.Columns.Add("pago", GetType(Decimal))
        dt.Columns.Add("pagome", GetType(Decimal))
        dt.Columns.Add("estado", GetType(String))


        documentoLibro = documentoVentaSA.GetListarCuotasDocumento(intIdItem)

        If Not IsNothing(documentoLibro) Then


            For Each i In documentoLibro
                Dim dr As DataRow = dt.NewRow()
                cuota = cuota + 1




                dr(0) = i.nrocuota
                dr(1) = i.fechaPago
                dr(2) = i.montoAutorizadoMN
                dr(3) = i.montoAutorizadoME
                dr(4) = i.estado



                dt.Rows.Add(dr)

            Next


            dgvPagosProgramados.DataSource = dt






            Me.dgvPagosProgramados.TableOptions.ListBoxSelectionMode = SelectionMode.One


        Else

        End If


    End Sub
#End Region
    Private Sub frmDetalleCuotas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class