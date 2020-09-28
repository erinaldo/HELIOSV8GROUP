Imports Helios.Cont.Business.Entity
Imports Helios.General
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmCerrarCaja
    Inherits frmMaster
    Public Property IdPadre() As Integer
    Public Property TipoMov() As String
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

#Region "Métodos"
    Public Sub TraNsaccioNes()
        Dim docCajaSA As New DocumentoCajaSA
        Dim dt As New DataTable()

        dt.Columns.Add("Usuario", GetType(String))
        dt.Columns.Add("IngresosMN", GetType(Decimal))
        dt.Columns.Add("IngresosME", GetType(Decimal))

        For Each i In docCajaSA.ResumenTransaccionesFullUsers(IdPadre, TipoMov)
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.NombreEntidad
            dr(1) = i.montoSoles
            dr(2) = i.montoUsd
            dt.Rows.Add(dr)
        Next
        GridGroupingControl1.DataSource = dt
    End Sub
#End Region

    Private Sub frmCerrarCaja_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmCerrarCaja_Load(sender As Object, e As EventArgs) Handles Me.Load
        TraNsaccioNes()
    End Sub
End Class