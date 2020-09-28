Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.GridHelperClasses
Imports PopupControl
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Public Class frmConsultaCajas
    Inherits frmMaster

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

#Region "Métodos"

    Public Sub ObtenerPagosDelDia()
        Dim objLista As New DocumentoCajaDetalleSA()
        dgvPagos.TableDescriptor.Name = ("Pagos del día")
        dgvPagos.DataSource = objLista.ObtenerPagosDelDiaPorEstablecimiento(GEstableciento.IdEstablecimiento)
        '   dgvPagos.TableDescriptor.Relations.Clear()
        dgvPagos.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
        dgvPagos.TableOptions.ListBoxSelectionMode = SelectionMode.One
        '  dgvPagos.TableOptions.ShowRowHeader = False
        dgvPagos.Appearance.AnyRecordFieldCell.Enabled = False
        dgvPagos.TableDescriptor.GroupedColumns.Clear()
        dgvPagos.TableDescriptor.GroupedColumns.Add("nomEntidad")
        '    DockingClientPanel1.Visible = True

    End Sub

    Public Sub ObtenerPagosPorPeriodo()
        Dim objLista As New DocumentoCajaDetalleSA()
        dgvPagos.TableDescriptor.Name = ("Pagos por período")
        dgvPagos.DataSource = objLista.ObtenerPagosPorPeriodoporEstablecimiento(GEstableciento.IdEstablecimiento, PeriodoGeneral)
        '   dgvPagos.TableDescriptor.Relations.Clear()
        dgvPagos.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
        dgvPagos.TableOptions.ListBoxSelectionMode = SelectionMode.One
        '  dgvPagos.TableOptions.ShowRowHeader = False
        dgvPagos.Appearance.AnyRecordFieldCell.Enabled = False
        dgvPagos.TableDescriptor.GroupedColumns.Clear()
        dgvPagos.TableDescriptor.GroupedColumns.Add("nomEntidad")
        '    DockingClientPanel1.Visible = True

    End Sub
#End Region

    Private Sub frmConsultaCajas_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmConsultaCajas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SaveToolStripButton_Click(sender As Object, e As EventArgs) Handles SaveToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        ObtenerPagosPorPeriodo()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        ObtenerPagosDelDia()
        Me.Cursor = Cursors.Arrow
    End Sub
End Class