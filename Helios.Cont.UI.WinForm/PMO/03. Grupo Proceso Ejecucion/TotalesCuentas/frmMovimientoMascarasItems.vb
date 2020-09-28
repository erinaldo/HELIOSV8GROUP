Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Public Class frmMovimientoMascarasItems
    Inherits frmMaster

    Private Sub frmMovimientoMascaras_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim contadoSA As New mascaraContable2SA
        GridGroupingControl1.DataSource = contadoSA.ObtenerMascaraContable2PorItems(Gempresas.IdEmpresaRuc)
        Me.GridGroupingControl1.TableOptions.AllowSelection = GridSelectionFlags.Any
        GridGroupingControl1.TableOptions.ShowRecordPlusMinus = False
        GridGroupingControl1.TableOptions.ShowRecordPreviewRow = False
        GridGroupingControl1.TableOptions.ShowTableIndent = False
        GridGroupingControl1.TableDescriptor.Relations.Clear()
        GridGroupingControl1.TableDescriptor.GroupedColumns.Clear()
        GridGroupingControl1.TableDescriptor.GroupedColumns.Add("idEmpresa")
        GridGroupingControl1.TableDescriptor.GroupedColumns.Add("tipoExistencia")
        GridGroupingControl1.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
        GridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GridGroupingControl1.Appearance.AnyRecordFieldCell.Enabled = False
    End Sub
End Class