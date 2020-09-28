Imports Helios.General
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Cont.Business.Entity
Public Class frmDetallePagoDirecto

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ListaDocPago()
    End Sub

#Region "Attributes"
    Dim CajaSeleccionada As New CajaSeleccionada
#End Region

#Region "Methods"
    Public Sub ListaDocPago()
        Dim tablaSA As New tablaDetalleSA
        Dim tabla As New List(Of tabladetalle)

        tabla = tablaSA.GetListaTablaDetalle(1, "1")
        'tabla = (From n In tabla _
        '             Where listaCuenta.Contains(n.codigoDetalle) _
        '            Select n).ToList
        cboTipoDocumento.DataSource = tabla
        cboTipoDocumento.ValueMember = "codigoDetalle"
        cboTipoDocumento.DisplayMember = "descripcion"
        cboTipoDocumento.SelectedValue = "001"

        cboEntidad.ValueMember = "codigoDetalle"
        cboEntidad.DisplayMember = "descripcion"
        cboEntidad.DataSource = tablaSA.GetListaTablaDetalle(3, "1")
        cboEntidad.SelectedValue = -1

    End Sub
#End Region

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Close()
    End Sub

    Private Sub cboTipoDocumento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoDocumento.SelectedIndexChanged
        Dim cod = cboTipoDocumento.SelectedValue
        If (Not IsNothing(cod)) Then
            cod = cod.ToString
            If (cod = "109") Then
                pnEntidad.Enabled = False
            Else
                pnEntidad.Enabled = True
            End If
            'pnEntidad.Enabled = True
        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If cboTipoDocumento.Text.Trim.Length > 0 Then
            CajaSeleccionada = New CajaSeleccionada
            CajaSeleccionada.FormaPago = cboTipoDocumento.SelectedValue
            CajaSeleccionada.FormaPagoDetalle = cboTipoDocumento.Text
            CajaSeleccionada.entidad = cboEntidad.SelectedValue
            CajaSeleccionada.entidadDetalle = cboEntidad.Text
            CajaSeleccionada.CuentaCorriente = txtCuentaCorriente.Text.Trim
            Tag = CajaSeleccionada
            Close()
        End If

    End Sub
End Class