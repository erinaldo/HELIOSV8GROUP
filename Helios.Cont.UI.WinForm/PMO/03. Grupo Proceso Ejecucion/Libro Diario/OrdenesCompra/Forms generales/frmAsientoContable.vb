Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Public Class frmAsientoContable
    Inherits frmMaster

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

#Region "Métodos"
    Public Sub UbicarAsientoContableXidDocumento(intIdDocumento As Integer)
        Dim asientoSA As New MovimientoSA
        Dim dt As New DataTable()

        dt.Columns.Add("cuenta")
        dt.Columns.Add("NomCuenta")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("debeMN", GetType(Decimal))
        dt.Columns.Add("haberMN", GetType(Decimal))

        dt.Columns.Add("debeME", GetType(Decimal))
        dt.Columns.Add("haberME", GetType(Decimal))

        For Each i As movimiento In asientoSA.UbicarAsientoXidDocumento(intIdDocumento)
            txtFecha.Text = i.fechaActualizacion
            txtGlosa.Text = i.glosa
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.cuenta
            dr(1) = "NN"
            dr(2) = i.descripcion
            Select Case i.tipo
                Case "D"
                    dr(3) = FormatNumber(i.monto, 2)
                    dr(4) = 0
                    dr(5) = FormatNumber(i.montoUSD, 2)
                    dr(6) = 0
                Case Else
                    dr(3) = 0
                    dr(4) = FormatNumber(i.monto, 2)
                    dr(5) = 0
                    dr(6) = FormatNumber(i.montoUSD, 2)
            End Select
            dt.Rows.Add(dr)
        Next
        dgvAsiento.DataSource = dt
        dgvAsiento.TableDescriptor.Relations.Clear()
        dgvAsiento.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
        dgvAsiento.TableOptions.ListBoxSelectionMode = SelectionMode.One
        dgvAsiento.Appearance.AnyRecordFieldCell.Enabled = False
        dgvAsiento.TableDescriptor.GroupedColumns.Clear()
    End Sub
#End Region

    Private Sub frmAsientoContable_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class