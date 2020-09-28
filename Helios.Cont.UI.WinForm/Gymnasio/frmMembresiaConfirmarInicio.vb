Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Grouping

Public Class frmMembresiaConfirmarInicio
#Region "Attributes"
    Public Property EntidadSA As entidadSA
#End Region

#Region "Constructors"
    Public Sub New(idDocumento As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        UbicarDocumentoMembresia(idDocumento)
        'txtFechaInicio.Value = Date.Now
    End Sub
#End Region

#Region "Methods"
    Private Sub CalculoDias()
        Dim result = Nothing
        Dim fActual = txtFechaInicio.Value
        Select Case txtDuracion.Text.ToLower
            Case "años"
                result = fActual.AddYears(Decimal.Parse(txtValDuracion.Text))
            Case "mes"
                result = fActual.AddMonths(Decimal.Parse(txtValDuracion.Text)).AddDays(-1)
            Case "días"
                result = fActual.AddDays(Decimal.Parse(txtValDuracion.Text))
        End Select
        txtFechaVcto.Value = result

    End Sub

    Private Sub UbicarDocumentoMembresia(iddocumento As Integer)
        Dim objDocumento = Entidadmembresia_GymSA.GetUbicarDocumentoMembresia(iddocumento)
        If objDocumento IsNot Nothing Then
            'Dim fechasDB = membresia_congelamientoSA.GetMaximoMinimoFechaCongelamiento(New membresia_congelamiento With {.idDocumento = objDocumento.idDocumento})


            Tag = objDocumento.idDocumento
            txtdni.Text = objDocumento.CustomEntidad.nrodoc
            TXTcLIENTE.Text = objDocumento.CustomEntidad.nombreCompleto
            TXTcLIENTE.Tag = objDocumento.CustomEntidad.idEntidad
            txtMembresia.Text = objDocumento.CustomMembresia.descripcion
            cboPeriodicida.SelectedValue = objDocumento.CustomMembresia.tipo.ToString
            txtValDuracion.Text = objDocumento.CustomMembresia.valorDuracion
            txtDuracion.Text = objDocumento.CustomMembresia.tipoDuracion
            txtValido.Value = objDocumento.CustomMembresia.fechafin
            txtInfoExtra.Text = objDocumento.CustomMembresia.detalle

            'Servicio Contractutal
            txtFechaInicio.Value = objDocumento.fechaInicio.Value
            txtFechaVcto.Value = objDocumento.fechaVcto
            txtFechaVcto.Enabled = True
            txtCongela_dia.Value = objDocumento.congela_dia
            CalculoDias()
        End If
    End Sub

    Private Sub ConfirmarInicioSocio()
        Try
            Entidadmembresia_GymSA.GetConfirmarInicio(New Entidadmembresia_Gym With {.idDocumento = Tag, .fechaInicio = txtFechaInicio.Value, .fechaVcto = txtFechaVcto.Value, .idEntidad = TXTcLIENTE.Tag}, True)
            Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Validar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "Events"
    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        Cursor = Cursors.WaitCursor
        ConfirmarInicioSocio()
        Cursor = Cursors.Arrow
    End Sub

    Private Sub txtFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaInicio.ValueChanged
        If IsDate(txtFechaInicio.Value) Then
            CalculoDias()
        End If
    End Sub
#End Region

End Class