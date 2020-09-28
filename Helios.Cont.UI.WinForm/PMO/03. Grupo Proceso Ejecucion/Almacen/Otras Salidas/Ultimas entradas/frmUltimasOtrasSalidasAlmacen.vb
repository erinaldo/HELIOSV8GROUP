Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Public Class frmUltimasOtrasSalidasAlmacen
    Inherits frmMaster

    Public idItem As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


#Region "Métodos"

    Public Sub ObtenerAlmacen(IdAlmacen As Integer)
        Dim almacenSA As New almacenSA
        Dim almacen As New almacen
        almacen = almacenSA.GetUbicar_almacenPorID(IdAlmacen)
        If Not IsNothing(almacen) Then
            txtAlmacen.ValueMember = almacen.idAlmacen
            txtAlmacen.Text = almacen.descripcionAlmacen
        End If
    End Sub

    Public Sub UltimasEntradas(intCuota As Integer)
        Dim CompraSA As New DocumentoCompraDetalleSA
        Dim dt As New DataTable()

        dt.Columns.Add("FechaDoc", GetType(String))
        dt.Columns.Add("tipoCompra", GetType(String))
        dt.Columns.Add("TipoDoc", GetType(String))
        dt.Columns.Add("descripcionItem", GetType(String))
        dt.Columns.Add("unidad1", GetType(String))
        dt.Columns.Add("bonificacion", GetType(String))
        dt.Columns.Add("monto1", GetType(Decimal))
        dt.Columns.Add("precioUnitario", GetType(Decimal))
        dt.Columns.Add("importe", GetType(Decimal))
        dt.Columns.Add("precioUnitarioUS", GetType(Decimal))
        dt.Columns.Add("importeUS", GetType(Decimal))
        Dim str As String
        For Each i In CompraSA.UltimasOtrasSalidasPorFecha(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, intCuota, txtAlmacen.ValueMember, idItem)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.FechaDoc).ToString("dd-MMM-yy hh:mm tt ")
            dr(0) = str
            dr(1) = i.tipoCompra
            dr(2) = i.TipoDoc
            dr(3) = i.descripcionItem
            dr(4) = i.unidad1
            Select Case i.bonificacion
                Case "S"
                    dr(5) = "SI"
                Case Else
                    dr(5) = "NO"
            End Select
            dr(6) = i.monto1
            dr(7) = i.precioUnitario
            dr(8) = i.importe
            dr(9) = i.precioUnitarioUS
            dr(10) = i.importeUS
            dt.Rows.Add(dr)
        Next

        Me.dgvEntrada.DataSource = dt
        dgvEntrada.TableDescriptor.Relations.Clear()
        dgvEntrada.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
        dgvEntrada.TableOptions.ListBoxSelectionMode = SelectionMode.One
        dgvEntrada.Appearance.AnyRecordFieldCell.Enabled = False
        dgvEntrada.GroupDropPanel.Visible = True
        dgvEntrada.TableDescriptor.GroupedColumns.Clear()

    End Sub
#End Region

    Private Sub cboMov_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMov.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Select Case cboMov.Text
            Case "5 últimas entradas"
                UltimasEntradas(5)

            Case "10 últimas entradas"
                UltimasEntradas(10)

            Case "15 últimas entradas"
                UltimasEntradas(15)

            Case Else
                dgvEntrada.Table.Records.DeleteAll()
        End Select
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub frmUltimasOtrasSalidasAlmacen_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmUltimasOtrasSalidasAlmacen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class