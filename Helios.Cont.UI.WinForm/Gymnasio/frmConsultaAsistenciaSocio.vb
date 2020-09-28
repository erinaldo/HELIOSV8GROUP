Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Planilla.WCFService.ServiceAccess
Imports Helios.General
Public Class frmConsultaAsistenciaSocio
#Region "Attributes"
    Protected dt As DataTable
    Protected Friend ControlDeAsistenciaSA As New ControlDeAsistenciaSA
#End Region

#Region "Constructors"
    Public Sub New(idDocumento As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(dgvAsistencia, True, False)
        UbicarDocumentoMembresia(idDocumento)
        Tag = idDocumento
    End Sub
#End Region

#Region "Methods"
    Private Sub UbicarDocumentoMembresia(iddocumento As Integer)
        Dim objDocumento = Entidadmembresia_GymSA.GetUbicarDocumentoMembresia(iddocumento)
        If objDocumento IsNot Nothing Then
            Tag = objDocumento.idDocumento
            txtdni.Text = objDocumento.CustomEntidad.nrodoc
            TXTcLIENTE.Text = objDocumento.CustomEntidad.nombreCompleto
            TXTcLIENTE.Tag = objDocumento.CustomEntidad.idEntidad
            txtMembresia.Text = objDocumento.CustomMembresia.descripcion

            'Servicio Contractutal
            txtFechaInicio.Value = objDocumento.fechaInicio.Value
            txtFechaVcto.Value = objDocumento.fechaVcto

            Dim asistencia = ControlDeAsistenciaSA.ControlDeAsistenciaSelxSocio(New Planilla.Business.Entity.ControlDeAsistencia With {.iddocumentoref = objDocumento.idDocumento, .IDPersonal = objDocumento.CustomEntidad.idEntidad})
            dt = New DataTable
            dt.Columns.Add("anio")
            dt.Columns.Add("mes")
            dt.Columns.Add("dia")
            dt.Columns.Add("hora")
            dt.Columns.Add("status")

            For Each i In asistencia
                '    DateTime.Today.ToString("ddd", CultureInfo.InvariantCulture).ToUpper()
                dt.Rows.Add(i.AñoAsistencia, MonthName(i.MesAsistencia, True).ToUpper, i.DiaAsistencia.Value, i.HoraIngreso, "Asistio")
            Next

            Dim congelamientos = membresia_congelamientoSA.GetCongelamientoByDocumento(objDocumento.idDocumento)
            For Each i In congelamientos
                Dim diasAdd = DateDiff(DateInterval.Day, i.fechainicio.GetValueOrDefault, i.fechafin.GetValueOrDefault)
                diasAdd += 1
                Do While True
                    If diasAdd <= 0 Then
                        Exit Do
                    End If
                    dt.Rows.Add(i.fechainicio.Value.Year, MonthName(i.fechainicio.Value.Month, True).ToUpper, i.fechainicio.Value.Day, 0, "Congelado")
                    i.fechainicio = CDate(i.fechainicio).AddDays(1)
                    diasAdd -= 1
                    'If diasAdd <= 0 Then
                    '    Exit Do
                    'End If
                Loop
                dt.Rows.Add()
            Next
            dgvAsistencia.DataSource = dt
        End If
    End Sub


#End Region

#Region "Events"
    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        Cursor = Cursors.WaitCursor
        UbicarDocumentoMembresia(Tag)
        Cursor = Cursors.Default
    End Sub
#End Region

End Class