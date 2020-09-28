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
Public Class frmDevolucionExistencia
    Inherits frmMaster

#Region "Métodos"
    Private Function GetTableGrid() As DataTable
        Dim tablaSA As New tablaDetalleSA

        Dim dt As New DataTable
        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("grav", GetType(String))
        dt.Columns.Add("idItem", GetType(Integer))
        dt.Columns.Add("item", GetType(String))
        dt.Columns.Add("cantidad", GetType(Decimal))
        dt.Columns.Add("precMN", GetType(Decimal))
        dt.Columns.Add("importeMN", GetType(Decimal))
        dt.Columns.Add("precME", GetType(Decimal))
        dt.Columns.Add("importeME", GetType(Decimal))
        dt.Columns.Add("tipoEx", GetType(String))
        dt.Columns.Add("estado", GetType(String))
        dt.Columns.Add("almacenBack", GetType(Integer))
        dt.Columns.Add("cuentaHaber", GetType(String))
        Return dt
    End Function
#End Region

    Private Sub frmDevolucionExistencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class