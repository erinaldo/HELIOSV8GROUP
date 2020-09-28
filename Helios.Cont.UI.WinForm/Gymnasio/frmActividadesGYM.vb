Imports System.Windows.Forms.Calendar
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmActividadesGYM

#Region "Attributes"
    Public Property dt As DataTable
    Public Property beActividad As actividadPersonal
    Public Property statusAction As Entity.EntityState
#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(dgAgenda, False, False)
        '  GetDias()
    End Sub

    Public Sub New(idActividad As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(dgAgenda, False, False)
        UbicarActividad(idActividad)
    End Sub

#End Region

#Region "methods"

    Public Sub GetDias()

        Dim dt As New DataTable
        dt.Columns.Add("Dia")
        dt.Columns.Add("horainicio")
        dt.Columns.Add("horafin")

        'dt.Rows.Add("Lunes")
        'dt.Rows.Add("Martes")
        'dt.Rows.Add("Miercoles")
        'dt.Rows.Add("Jueves")
        'dt.Rows.Add("Viernes")
        'dt.Rows.Add("Sabado")
        'dt.Rows.Add("Domingo")
        For Each i In lstDias.CheckedItems
            dt.Rows.Add(i.ToString)
        Next

        dgAgenda.DataSource = dt
    End Sub


    Private Sub UbicarActividad(idActividad As Integer)
        Dim dt As New DataTable
        dt.Columns.Add("Dia")
        dt.Columns.Add("horainicio")
        dt.Columns.Add("horafin")
        beActividad = actividadPersonalSA.GetUbicarActividadGYM(idActividad)
        If beActividad IsNot Nothing Then
            txtActividad.Text = beActividad.nombre
            txtActividad.Tag = beActividad.idActividad

            For Each i In clasehorariosSA.GetUbicarActividadGYMDetalle(idActividad)
                dt.Rows.Add(i.dia, i.horainicio, i.horafin)
                'For Each t In lstDias.Items
                '    If i.dia = t.ToString Then
                '        lstDias.CheckedItems()
                '    End If
                'Next
            Next
            dgAgenda.DataSource = dt
        End If
    End Sub

    Private Function ValidarGrabado() As Boolean
        Dim listaErrores As Integer = 0

        If txtActividad.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(txtActividad, "Ingrese el nombre de la actividad")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(txtActividad, Nothing)
        End If


        If listaErrores > 0 Then
            ValidarGrabado = False
        Else
            ValidarGrabado = True
        End If
    End Function

    Private Sub Grabar()
        Dim beDetalleActividad As New clasehorarios
        beActividad = New actividadPersonal
        beActividad.nombre = txtActividad.Text.Trim
        beActividad.tipo = Gimnasio_StatusActividades.TodosLosDias
        beActividad.costo = 0
        beActividad.usuarioModificacion = usuario.IDUsuario
        beActividad.fechaModificacion = Date.Now

        beActividad.clasehorarios = New List(Of clasehorarios)
        For Each r In dgAgenda.Table.Records
            'Dim horaInicio = Mid(r.GetValue("horainicio"), 1, 2)
            'horaInicio = horaInicio & ":" & Mid(r.GetValue("horainicio"), 3, 4)
            'Dim horaFinaliza = Mid(r.GetValue("horafin"), 1, 2)
            'horaFinaliza = horaFinaliza & ":" & Mid(r.GetValue("horafin"), 3, 4)

            beDetalleActividad = New clasehorarios
            beDetalleActividad.dia = r.GetValue("Dia")
            beDetalleActividad.horainicio = New TimeSpan(Mid(r.GetValue("horainicio"), 1, 2), Mid(r.GetValue("horainicio"), 3, 4), 0)
            beDetalleActividad.horafin = New TimeSpan(Mid(r.GetValue("horafin"), 1, 2), Mid(r.GetValue("horafin"), 3, 4), 0)
            beDetalleActividad.aforo = 0
            'beDetalleActividad.costo
            'beDetalleActividad.status
            beDetalleActividad.usuarioModificacion = usuario.IDUsuario
            beDetalleActividad.fechaModificacion = Date.Now


            beActividad.clasehorarios.Add(beDetalleActividad)
        Next

        actividadPersonalSA.GrabarActividadPersonalGym(beActividad)
        MessageBox.Show("Actividad registrada", "Grabado", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close()
    End Sub

    Private Sub Editar()
        Dim beDetalleActividad As New clasehorarios
        beActividad.nombre = txtActividad.Text.Trim
        beActividad.usuarioModificacion = usuario.IDUsuario
        beActividad.fechaModificacion = Date.Now

        beActividad.clasehorarios = New List(Of clasehorarios)
        For Each r In dgAgenda.Table.Records
            'Dim horaInicio = Mid(r.GetValue("horainicio"), 1, 2)
            'horaInicio = horaInicio & ":" & Mid(r.GetValue("horainicio"), 3, 4)
            'Dim horaFinaliza = Mid(r.GetValue("horafin"), 1, 2)
            'horaFinaliza = horaFinaliza & ":" & Mid(r.GetValue("horafin"), 3, 4)

            beDetalleActividad = New clasehorarios
            beDetalleActividad.idActividad = beActividad.idActividad
            beDetalleActividad.dia = r.GetValue("Dia")
            beDetalleActividad.horainicio = New TimeSpan(Mid(r.GetValue("horainicio"), 1, 2), Mid(r.GetValue("horainicio"), 3, 4), 0)
            beDetalleActividad.horafin = New TimeSpan(Mid(r.GetValue("horafin"), 1, 2), Mid(r.GetValue("horafin"), 3, 4), 0)
            beDetalleActividad.aforo = 0
            'beDetalleActividad.costo
            'beDetalleActividad.status
            beDetalleActividad.usuarioModificacion = usuario.IDUsuario
            beDetalleActividad.fechaModificacion = Date.Now


            beActividad.clasehorarios.Add(beDetalleActividad)
        Next

        actividadPersonalSA.EditarActividadGym(beActividad)
        MessageBox.Show("Actividad registrada", "Grabado", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close()
    End Sub


#End Region

#Region "Events"
    Private Sub frmActividadesGYM_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        If ValidarGrabado() = True Then
            If statusAction = Entity.EntityState.Added Then
                Grabar()
            ElseIf statusAction = Entity.EntityState.Modified Then
                Editar()
            End If
        End If
    End Sub




    Private Sub dgAgenda_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgAgenda.TableControlCellClick

    End Sub

    Private Sub lstDias_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstDias.SelectedIndexChanged

    End Sub

    Private Sub RoundButton22_Click(sender As Object, e As EventArgs) Handles RoundButton22.Click
        GetDias()
    End Sub

    'Private Sub RoundButton22_Click(sender As Object, e As EventArgs) Handles RoundButton22.Click
    '    Dim cal = New CalendarItem(calendar1, New DateTime(2017, 12, 11, 7, 0, 0), New DateTime(2017, 12, 11, 7, 0, 0), "Prubea")
    '    calendar1.Items.Add(cal)
    '    calendar1.Refresh()
    'End Sub

#End Region

End Class