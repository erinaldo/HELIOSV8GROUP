Imports System.ComponentModel
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity

Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Public Class UCCajaEnArqueo

#Region "Constructor"

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        FormatoGridBlack(DgvOpenBox, False)
        'ListBoxClosedPending()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

#End Region

#Region "Metodos"

    Public Sub ListBoxClosedPending()


        Dim dt As New DataTable("Usuario")
        Dim boxUserSA As New cajaUsuarioSA

        dt.Columns.Add(New DataColumn("idUser", GetType(Integer)))
        dt.Columns.Add(New DataColumn("User", GetType(String)))
        dt.Columns.Add(New DataColumn("idBox", GetType(String)))
        dt.Columns.Add(New DataColumn("namePc", GetType(String)))
        dt.Columns.Add(New DataColumn("date", GetType(String)))
        dt.Columns.Add(New DataColumn("importe", GetType(String)))
        dt.Columns.Add(New DataColumn("importeme", GetType(String)))

        Dim be As New cajaUsuario
        be.idEmpresa = Gempresas.IdEmpresaRuc
        be.idEstablecimiento = GEstableciento.IdEstablecimiento

        Dim ListOpenBox = boxUserSA.ListBoxClosedPending(be)

        For Each i In ListOpenBox
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.idPersona
            dr(1) = (From j In UsuariosList Where j.IDUsuario = i.idPersona Select j.Nombres).FirstOrDefault
            dr(2) = i.idcajaUsuario
            dr(3) = i.namepc
            dr(4) = i.fechaRegistro
            dr(5) = i.montoMN
            dr(6) = i.montoME
            dt.Rows.Add(dr)
        Next

        DgvOpenBox.DataSource = dt

    End Sub

    Private Sub ButtonAdv8_Click(sender As Object, e As EventArgs) Handles ButtonAdv8.Click
        ListBoxClosedPending()
    End Sub

#End Region

End Class
