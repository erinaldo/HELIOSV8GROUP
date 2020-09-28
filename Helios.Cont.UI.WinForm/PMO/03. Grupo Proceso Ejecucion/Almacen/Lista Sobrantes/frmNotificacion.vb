Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Public Class frmNotificacion
    Inherits frmMaster
    Dim savedCursor As Windows.Forms.Cursor

    Public Sub New()
        InitializeComponent()
        Dim cfecha As Date = DateTime.Now.Date
        lblPerido.Text = PeriodoGeneral
        txtEstablecimiento.Text = GEstableciento.NombreEstablecimiento
        txtEstablecimiento.ValueMember = GEstableciento.IdEstablecimiento

        txtEmpresa.Text = Gempresas.NomEmpresa
        txtEmpresa.ValueMember = Gempresas.IdEmpresaRuc
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        popupControlContainer1.Font = New Font("Segoe UI", 8)
        popupControlContainer1.Size = New Size(264, 109)
        Me.popupControlContainer1.ParentControl = Me.txtEstablecimiento
        Me.popupControlContainer1.ShowPopup(Point.Empty)
    End Sub
End Class