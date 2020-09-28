Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Public Class frmCierreContabilidad
    Inherits frmMaster

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        GridCFG(dgvCierre)
        ' Add any initialization after the InitializeComponent() call.
        Me.WindowState = FormWindowState.Maximized
        ObtenerCierreMovimientos()
    End Sub

#Region "Métodos"
    Dim colorx As New GridMetroColors()
    Sub GridCFG(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = True
        GGC.ShowColumnHeaders = True

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = System.Windows.Forms.BorderStyle.None

        '  GGC.BrowseOnly = True
        GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GGC.TableOptions.SelectionBackColor = Color.Gray
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        GGC.Table.DefaultColumnHeaderRowHeight = 23
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Public Sub GrabarCierre()
        Dim cierre As New cierrecontable
        Dim listaCierre As New List(Of cierrecontable)
        Dim cierreSA As New CierreContableSA
        Try
            For Each r As Record In dgvCierre.Table.Records
                cierre = New cierrecontable
                cierre.idEmpresa = Gempresas.IdEmpresaRuc
                cierre.idCentroCosto = GEstableciento.IdEstablecimiento
                cierre.periodo = PeriodoGeneral.Replace("/", "")
                cierre.cuenta = r.GetValue("cuenta")
                cierre.tipoasiento = r.GetValue("tipoasiento").ToString.Trim
                cierre.anio = CInt(AnioGeneral)
                cierre.mes = CInt(MesGeneral)
                Select Case r.GetValue("tipoasiento")
                    Case "D"
                        cierre.monto = r.GetValue("debe")
                        cierre.montoUSD = r.GetValue("debeus")
                    Case "H"
                        cierre.monto = r.GetValue("haber")
                        cierre.montoUSD = r.GetValue("haberus")
                End Select

                cierre.usuarioActualizacion = usuario.IDUsuario
                cierre.fechaActualizacion = DateTime.Now
                listaCierre.Add(cierre)
            Next r
            cierreSA.GrabarListaAsientosCierre(listaCierre)
            Dispose()
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub

    Public Sub ObtenerCierreMovimientos()
        Dim movimientosSA As New MovimientoSA
        Dim planContableSA As New cuentaplanContableEmpresaSA

        Dim dt As New DataTable("Balance de comprobación: " & PeriodoGeneral & " ")

        dt.Columns.Add(New DataColumn("cuenta", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("debe", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("haber", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("debeus", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("haberus", GetType(Decimal))) '
        dt.Columns.Add(New DataColumn("tipoasiento", GetType(String)))

        For Each i As movimiento In movimientosSA.GetObetnerCierrePorPeriodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, AnioGeneral, MesGeneral)
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.cuenta
            Dim str As String = i.cuenta.Substring(0, 2)
            dr(1) = planContableSA.ObtenerCuentaPorID(Gempresas.IdEmpresaRuc, str).descripcion
            Select Case i.tipo
                Case "D"
                    dr(2) = i.monto
                    dr(3) = 0
                Case "H"
                    dr(2) = 0
                    dr(3) = i.monto
            End Select

            Select Case i.tipo
                Case "D"
                    dr(4) = i.montoUSD
                    dr(5) = 0
                Case "H"
                    dr(4) = 0
                    dr(5) = i.montoUSD
            End Select
            dr(6) = i.tipo
            dt.Rows.Add(dr)
        Next
        dgvCierre.DataSource = dt
    End Sub
#End Region

    Private Sub frmCierreContabilidad_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmCierreContabilidad_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnCard_Click(sender As Object, e As EventArgs) Handles btnCard.Click
        Me.Cursor = Cursors.WaitCursor
        GrabarCierre()
        Me.Cursor = Cursors.Arrow
    End Sub
End Class