Imports Helios.Planilla.Business.Entity
Imports Helios.Planilla.General.Constantes
Imports Helios.Planilla.WCFService.ServiceAccess
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Tools
Imports Helios.General

Public Class frmHorariosPersonal

#Region "Atributos"
    Public Property SelPersona As New Personal
    Private Property PersonalHorariosSA As New PersonalHorariosSA
    Public Property statusAction As Entity.EntityState

    Private hitinfo As ListViewHitTestInfo
    Private editbox As New DateTimePickerAdv
#End Region

#Region "Constructors"
    Public Sub New(idPersona As Integer, cargo As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        SelPersona = UbicarPersonal(idPersona)
        'If Not IsNothing(SelPersona) Then
        '    txtCodigoFiltrar.Text = SelPersona.Numerodocumento
        '    txtTrabajador.Text = SelPersona.FullName
        '    Select Case SelPersona.Situacion
        '        Case Tabla_SituacionTrabajador.activo_o_subsidiado
        '            TextBoxExt1.Text = "Activo"
        '        Case Tabla_SituacionTrabajador.activo_o_subsidiado_eps_serv_propios
        '            TextBoxExt1.Text = "Activo"
        '        Case Tabla_SituacionTrabajador.baja
        '            TextBoxExt1.Text = "Baja"
        '        Case Tabla_SituacionTrabajador.baja_eps_serv_propios
        '            TextBoxExt1.Text = "Baja"
        '        Case Tabla_SituacionTrabajador.sin_vinculo_laboral_con_conceptos_pendientes_de_liquidar_eps_serv_propios
        '            TextBoxExt1.Text = "Sin vinculo laboral"
        '        Case Tabla_SituacionTrabajador.sin_vinculo_laboral_con_conceptos_pendientes_por_liquidar
        '            TextBoxExt1.Text = "Sin vinculo laboral"
        '        Case Tabla_SituacionTrabajador.suspension_perfecta
        '            TextBoxExt1.Text = "Suspendión perfecta"
        '    End Select
        'End If
        LoadData(cargo)
    End Sub
#End Region

#Region "Métodos"
    Private Sub AgregarItemListview()
        Dim n As New ListViewItem(cboDetalleHorario.Text)
        n.SubItems.Add(txtHorario.Value.TimeOfDay.ToString).Tag = "L"
        n.SubItems.Add(txtHorario.Value.TimeOfDay.ToString).Tag = "M"
        n.SubItems.Add(txtHorario.Value.TimeOfDay.ToString).Tag = "MI"
        n.SubItems.Add(txtHorario.Value.TimeOfDay.ToString).Tag = "J"
        n.SubItems.Add(txtHorario.Value.TimeOfDay.ToString).Tag = "V"
        n.SubItems.Add(txtHorario.Value.TimeOfDay.ToString).Tag = "S"
        n.SubItems.Add(txtHorario.Value.TimeOfDay.ToString).Tag = "D"
        lsvHorarios.Items.Add(n)
    End Sub
    Private Sub LoadData(cargo As Integer)
        Dim cargoSA As New Helios.Planilla.WCFService.ServiceAccess.PersonalCargoSA
        Dim PersonalHorarioSA As New Helios.Planilla.WCFService.ServiceAccess.PersonalHorariosSA
        ' Dim personal

        cboCargo.DataSource = cargoSA.PersonalCargoSel(New PersonalCargo With {.IDPersonal = SelPersona.IDPersonal, .IDCargo = cargo})
        cboCargo.ValueMember = "IDCargo"
        cboCargo.DisplayMember = "DescripcionLarga"
        cboCargo.SelectedValue = cargo
        'dgAsistencia.DataSource = sa.ControlAsistenciaSelxIDPersonal(New ControlAsistencia With {.IDPersonal = SelPersona.IDPersonal})
        'dgAsistencia.TableOptions.ListBoxSelectionMode = SelectionMode.One
        Dim lstHorario = PersonalHorarioSA.PersonalHorariosSelxCargo(New PersonalHorarios With {.IDPersonal = SelPersona.IDPersonal, .IDCargo = cargo})
        lsvHorarios.Items.Clear()
        Dim lstDetalles = (From n In lstHorario
                           Select n.detalle).Distinct.ToList

        For Each l In lstDetalles
            Dim n As New ListViewItem(l.ToString)

            Dim listaDiasXdetalle = lstHorario.Where(Function(o) o.detalle = l.ToString).ToList
            For Each i In listaDiasXdetalle
                Select Case i.DiaNumero
                    Case 1
                        n.SubItems.Add(i.HoraIngreso.ToString).Tag = "L"
                    Case 2
                        n.SubItems.Add(i.HoraIngreso.ToString).Tag = "M"
                    Case 3
                        n.SubItems.Add(i.HoraIngreso.ToString).Tag = "MI"
                    Case 4
                        n.SubItems.Add(i.HoraIngreso.ToString).Tag = "J"
                    Case 5
                        n.SubItems.Add(i.HoraIngreso.ToString).Tag = "V"
                    Case 6
                        n.SubItems.Add(i.HoraIngreso.ToString).Tag = "S"
                    Case 7
                        n.SubItems.Add(i.HoraIngreso.ToString).Tag = "D"
                End Select

            Next
            lsvHorarios.Items.Add(n)
        Next

    End Sub

    Private Function UbicarPersonal(idPersonal As Integer) As Personal
        Dim personaSA As New PersonalSA
        Return personaSA.PersonalSelxID(New Personal With {.IDPersonal = idPersonal})
    End Function

    Private Function ValidarGrabado() As Boolean
        If txtTrabajador.Text.Trim.Length <= 0 Then
            MessageBox.Show("Debe ingresar un trabajador válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function

    Private Function ValidarDuplicados() As Boolean
        ValidarDuplicados = True
        If lsvHorarios.Items.Count > 0 Then
            Dim tieneIngreso As Boolean = False
            Dim tieneSalida As Boolean = False
            For Each i As ListViewItem In lsvHorarios.Items
                If cboDetalleHorario.Text = i.SubItems(0).Text Then
                    ValidarDuplicados = False
                    Exit For
                End If
                'If i.SubItems(0).Text = "HORA DE INGRESO" Then
                '    ValidarDuplicados = False
                'ElseIf i.SubItems(0).Text = "HORA DE SALIDA" Then
                '    ValidarDuplicados = False
                'End If
            Next
        End If
    End Function

    Private Function IsInRange(ByVal vFechaIni As DateTime, ByVal vFechaFin As DateTime, ByVal vFechaSeleccionada As DateTime) As Boolean
        If vFechaSeleccionada.ToUniversalTime() >= vFechaIni.ToUniversalTime() AndAlso vFechaSeleccionada.ToUniversalTime() <= vFechaFin.ToUniversalTime() Then Return True
        Return False
    End Function

    Function ValidarHorario() As Boolean
        ValidarHorario = True

        Dim HoraIngreso As New DateTime
        Dim HoraSalida As New DateTime
        Dim listaHorarios = PersonalHorariosSA.PersonalHorariosSelxIDPersonal(New PersonalHorarios With {.IDPersonal = SelPersona.IDPersonal})

        For Each i As ListViewItem In lsvHorarios.Items
            Select Case i.SubItems(0).Text
                Case "HORA DE INGRESO"
                    Dim Hora = TimeSpan.Parse(i.SubItems(1).Text)
                    HoraIngreso = New DateTime(AnioGeneral, MesGeneral, 1, Hora.Hours, Hora.Minutes, Hora.Seconds)
                Case "HORA DE SALIDA"
                    Dim Hora = TimeSpan.Parse(i.SubItems(1).Text)
                    HoraSalida = New DateTime(AnioGeneral, MesGeneral, 1, Hora.Hours, Hora.Minutes, Hora.Seconds)
            End Select
        Next

        'Validando ingreso de los horaios por cargo
        Dim listaHorariosRef = listaHorarios.Where(Function(o) o.IDCargo <> cboCargo.SelectedValue)

        Dim cargosDistinc = (From c In listaHorariosRef
                             Select c.IDCargo).Distinct().ToList

        For Each c In cargosDistinc

            Dim cargoHoraIngreso = listaHorariosRef.Where(Function(o) o.IDCargo = c And o.detalle = "HORA DE INGRESO").Select(Function(o) o.HoraIngreso).FirstOrDefault
            Dim cargoHoraSalida = listaHorariosRef.Where(Function(o) o.IDCargo = c And o.detalle = "HORA DE SALIDA").Select(Function(o) o.HoraIngreso).FirstOrDefault

            If IsInRange(New DateTime(AnioGeneral, MesGeneral, 1, cargoHoraIngreso.Value.Hours, cargoHoraIngreso.Value.Minutes, cargoHoraIngreso.Value.Seconds),
                         New DateTime(AnioGeneral, MesGeneral, 1, cargoHoraSalida.Value.Hours, cargoHoraSalida.Value.Minutes, cargoHoraSalida.Value.Seconds),
                         HoraIngreso) Then
                'MessageBox.Show("Esta dentro del rango")
                MessageBox.Show("No puede registrar en este horario", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ValidarHorario = False
                Exit For
            Else
                '     MessageBox.Show("Esta fuera del rango")
            End If


            'If HoraIngreso.TimeOfDay.CompareTo(c.HoraIngreso.Value) >= 0 AndAlso HoraIngreso.TimeOfDay.CompareTo(c.HoraSalida.Value) <= 0 Then

            'End If


            'If c.HoraIngreso.Value.CompareTo(HoraIngreso.TimeOfDay) >= 0 AndAlso c.HoraIngreso.Value.CompareTo(HoraSalida.TimeOfDay) <= 0 Then
            '    MessageBox.Show("No puede registrar en este horario", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    ValidarHorario = False
            '    Exit For
            'Else

            'End If
            'If c.HoraIngreso.Date.CompareTo(HoraIngreso.Date) >= 0 AndAlso HoraIngreso.Date.CompareTo(HoraSalida) <= 0 Then
            '    GetCalculoDiasFreezingNow += 1
            'Else
            '    ' MessageBox.Show("Fuera del rango de congelamiento")
            'End If
        Next

    End Function

    Sub GrabarHorarios()
        Dim objPersonalSA As New PersonalHorariosSA
        Dim objPersonal As New List(Of PersonalHorarios)
        Dim SumaHoras As New TimeSpan
        SumaHoras = New TimeSpan(0, 0, 0)
        For Each l As ListViewItem In lsvHorarios.Items
            'LUNES
            objPersonal.Add(New PersonalHorarios With
                                             {
                                             .IDPersonal = SelPersona.IDPersonal,
                                             .IDCargo = cboCargo.SelectedValue,
                                             .detalle = l.SubItems(0).Text,
                                             .DiaNumero = 1,
                                             .DiaSemana = "LUNES",
                                             .HoraIngreso = TimeSpan.Parse(l.SubItems(1).Text)
                                             })

            SumaHoras = SumaHoras.Add(TimeSpan.Parse(l.SubItems(1).Text))
            'MARTES
            objPersonal.Add(New PersonalHorarios With
                                            {
                                            .IDPersonal = SelPersona.IDPersonal,
                                            .IDCargo = cboCargo.SelectedValue,
                                            .detalle = l.SubItems(0).Text,
                                            .DiaNumero = 2,
                                            .DiaSemana = "MARTES",
                                            .HoraIngreso = TimeSpan.Parse(l.SubItems(2).Text)
                                            })
            'MIERCOLES
            objPersonal.Add(New PersonalHorarios With
                                            {
                                            .IDPersonal = SelPersona.IDPersonal,
                                            .IDCargo = cboCargo.SelectedValue,
                                            .detalle = l.SubItems(0).Text,
                                            .DiaNumero = 3,
                                            .DiaSemana = "MIERCOLES",
                                            .HoraIngreso = TimeSpan.Parse(l.SubItems(3).Text)
                                            })
            'JUEVES
            objPersonal.Add(New PersonalHorarios With
                                            {
                                            .IDPersonal = SelPersona.IDPersonal,
                                            .IDCargo = cboCargo.SelectedValue,
                                            .detalle = l.SubItems(0).Text,
                                            .DiaNumero = 4,
                                            .DiaSemana = "JUEVES",
                                            .HoraIngreso = TimeSpan.Parse(l.SubItems(4).Text)
                                            })
            'VIERNES
            objPersonal.Add(New PersonalHorarios With
                                            {
                                            .IDPersonal = SelPersona.IDPersonal,
                                            .IDCargo = cboCargo.SelectedValue,
                                            .detalle = l.SubItems(0).Text,
                                            .DiaNumero = 5,
                                            .DiaSemana = "VIERNES",
                                            .HoraIngreso = TimeSpan.Parse(l.SubItems(5).Text)
                                            })
            'SABADO
            objPersonal.Add(New PersonalHorarios With
                                            {
                                            .IDPersonal = SelPersona.IDPersonal,
                                            .IDCargo = cboCargo.SelectedValue,
                                            .detalle = l.SubItems(0).Text,
                                            .DiaNumero = 6,
                                            .DiaSemana = "SABADO",
                                            .HoraIngreso = TimeSpan.Parse(l.SubItems(6).Text)
                                            })
            'DOMINGO
            objPersonal.Add(New PersonalHorarios With
                                            {
                                            .IDPersonal = SelPersona.IDPersonal,
                                            .IDCargo = cboCargo.SelectedValue,
                                            .detalle = l.SubItems(0).Text,
                                            .DiaNumero = 7,
                                            .DiaSemana = "DOMINGO",
                                            .HoraIngreso = TimeSpan.Parse(l.SubItems(7).Text)
                                            })
        Next

        Dim horaIngreso = objPersonal.Where(Function(o) o.detalle = "HORA DE INGRESO").FirstOrDefault

        Dim horaRefrigerio = objPersonal.Where(Function(o) o.detalle = "REFRIGERIO SALIDA").FirstOrDefault

        Dim horaReingresoRefrigerio = objPersonal.Where(Function(o) o.detalle = "REFRIGERIO REINGRESO").FirstOrDefault

        Dim horaSalida = objPersonal.Where(Function(o) o.detalle = "HORA DE SALIDA").FirstOrDefault

        Dim h1 = horaRefrigerio.HoraIngreso.Value.Subtract(horaIngreso.HoraIngreso) ' numero de horas laboradas hasta el refrigerio

        Dim h2 = horaSalida.HoraIngreso.Value.Subtract(horaReingresoRefrigerio.HoraIngreso) ' numero de horas laboradas desde el reingreso refrigerio hasta la salida

        Dim countDias = objPersonal.Where(Function(o) o.detalle = "HORA DE INGRESO").Count

        '    SumaHoras = h1.TotalHours + h2.TotalHours
        Dim totalHoras = h1.TotalHours + h2.TotalHours

        objPersonal(0).CustomPersonalCargo =
            New PersonalCargo With {
                                    .IDCargo = cboCargo.SelectedValue,
                                    .IDPersonal = SelPersona.IDPersonal,
                                    .DiasLaborales = countDias,
                                    .Totalhoras = totalHoras
                                   }
        objPersonalSA.PersonalHorariosSaveLista(objPersonal, UserManager.TransactionData)
        MessageBox.Show("Horario registrado", "Hecho!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close()
    End Sub

    Private Sub Grabar()
        Dim be As New ControlAsistencia()
        Dim sa As New ControlAsistenciaSA
        Try
            be = New ControlAsistencia()
            be.Action = BaseBE.EntityAction.INSERT
            be.IDPersonal = SelPersona.IDPersonal
            be.TipoAcesso = cboAcceso.SelectedValue
            be.Fecha = txtFecha.Value.Date
            be.Hora = txtHoraIngreso.Value.TimeOfDay
            be.HoraPersonal = txtHoraIngreso.Value.TimeOfDay
            be.HoraExtras = 0
            be.HorasFaltas = 0
            be.Tolerancia = txtTolerancia.Value.TimeOfDay
            be.FechaModificacion = DateTime.Now
            be.UsuarioModificacion = usuario.IDUsuario
            sa.ControlAsistenciaSave(be, UserManager.TransactionData)
            MessageBox.Show("Horario registrado", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'LoadData()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Editar()
        Dim be As New ControlAsistencia()
        Dim sa As New ControlAsistenciaSA

        be = New ControlAsistencia()
        be.Action = BaseBE.EntityAction.UPDATE
        be.IDAsistencia = Val(txtCodigoFiltrar.Tag)
        be.IDPersonal = SelPersona.IDPersonal
        be.TipoAcesso = cboAcceso.SelectedValue
        be.Fecha = txtFecha.Value.Date
        be.Hora = txtHoraIngreso.Value.TimeOfDay
        be.HoraPersonal = txtHoraIngreso.Value.TimeOfDay
        be.HoraExtras = 0
        be.HorasFaltas = 0
        be.Tolerancia = txtTolerancia.Value.TimeOfDay
        be.FechaModificacion = DateTime.Now
        be.UsuarioModificacion = usuario.IDUsuario
        sa.ControlAsistenciaSave(be, UserManager.TransactionData)
        MessageBox.Show("Horario editado", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'LoadData()
        GradientPanel3.Enabled = False
    End Sub

    Private Function ValidarIngresoHorarios() As Boolean
        ValidarIngresoHorarios = True
        Dim tieneIngreso As Boolean = False
        Dim tieneSalida As Boolean = False
        For Each i As ListViewItem In lsvHorarios.Items
            If i.SubItems(0).Text = "HORA DE INGRESO" Then
                tieneIngreso = True
            ElseIf i.SubItems(0).Text = "HORA DE SALIDA" Then
                tieneSalida = True
            End If
        Next

        If tieneIngreso = False Then
            ValidarIngresoHorarios = False
        End If

        If tieneSalida = False Then
            ValidarIngresoHorarios = False
        End If

    End Function

#End Region

#Region "Eventos"

    Private Sub lsvHorarios_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvHorarios.MouseDoubleClick
        hitinfo = lsvHorarios.HitTest(e.X, e.Y)

        Dim t = hitinfo.SubItem.Tag
        Select Case t
            Case "L", "M", "MI", "J", "V", "S", "D"
                editbox.Bounds = hitinfo.SubItem.Bounds
                Dim time = TimeSpan.Parse(hitinfo.SubItem.Text)
                Dim fechaTime = New DateTime(AnioGeneral, MesGeneral, 1, time.Hours, time.Minutes, time.Seconds)
                editbox.Value = fechaTime
                editbox.Focus()
                editbox.Show()
            Case Else

        End Select
    End Sub

    Private Sub txtFechaHorario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        'call LostFocus Sub in the event user pressed RETURN
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            txtFechaHorario_LostFocus(sender, Nothing)
        End If
    End Sub

    Private Sub txtFechaHorario_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not IsNothing(hitinfo) Then
            Select Case hitinfo.SubItem.Tag
                Case "L", "M", "MI", "J", "V", "S", "D"
                    If hitinfo.SubItem.Text.Trim.Length > 0 Then
                        Dim time = editbox.Value.TimeOfDay.ToString
                        '     Dim fechaTime = New DateTime(AnioGeneral, MesGeneral, 1, time.Hours, time.Minutes, time.Seconds)
                        hitinfo.SubItem.Text = time.ToString
                        editbox.Hide()

                        'Dim lsv As New ListViewItem
                        'lsv = ListView1.SelectedItems(0)
                        'Dim movimiento As New movimiento
                        'movimiento.idmovimiento = Integer.Parse(lsv.SubItems(0).Text)
                        'movimiento.idAsiento = Integer.Parse(lsv.SubItems(5).Text)
                        'movimiento.cuenta = lsv.SubItems(1).Text
                        'movimiento.descripcion = lsv.SubItems(2).Text
                        'Select Case lsv.SubItems(6).Text
                        '    Case "D"
                        '        movimiento.monto = Decimal.Parse(lsv.SubItems(3).Text)
                        '        movimiento.montoUSD = 0
                        '    Case "H"
                        '        movimiento.monto = Decimal.Parse(lsv.SubItems(4).Text)
                        '        movimiento.montoUSD = 0
                        'End Select
                        'movimiento.usuarioActualizacion = usuario.IDUsuario
                        'movimiento.fechaActualizacion = Date.Now


                        'asientoSA.EditarMovimientosContablesByAsiento(movimiento)
                    End If
            End Select

        End If

    End Sub

    Private Sub lsvHorarios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvHorarios.SelectedIndexChanged
        Try
            If lsvHorarios.SelectedItems.Count > 0 Then
                txtFechaHorario_LostFocus(sender, Nothing)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub EditGrid(r As Record)
        Dim time = r.GetValue("Hora")
        Dim tolerancia = DirectCast(r.GetValue("Tolerancia"), TimeSpan)
        Dim Acceso = r.GetValue("TipoAcesso")
        Dim time2 = DirectCast(time, TimeSpan)
        txtCodigoFiltrar.Tag = Val(r.GetValue("IDAsistencia"))
        txtHoraIngreso.Value = New Date(Date.Now.Year, Date.Now.Month, Date.Now.Day, time2.Hours, time2.Minutes, time2.Seconds)
        txtTolerancia.Value = New Date(Date.Now.Year, Date.Now.Month, Date.Now.Day, tolerancia.Hours, tolerancia.Minutes, tolerancia.Seconds)
        cboAcceso.SelectedValue = Acceso
    End Sub


    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim r As Record = dgAsistencia.Table.CurrentRecord
        Dim sa As New ControlAsistenciaSA
        Dim obj As New ControlAsistencia

        obj = sa.ControlAsistenciaSelxID(New ControlAsistencia With {.IDAsistencia = Val(r.GetValue("IDAsistencia"))}).FirstOrDefault

        If Not IsNothing(r) Then
            sa.ControlAsistenciaDelete(obj, UserManager.TransactionData)
            '    LoadData()
            GradientPanel3.Enabled = False
        Else
            MessageBox.Show("Debe seleccionar un registro", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Cursor = Cursors.WaitCursor
        txtCodigoFiltrar.Tag = Nothing
        '    LoadData()
        dgAsistencia.Enabled = True
        GradientPanel3.Enabled = False
        Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Select Case statusAction
            Case Entity.EntityState.Added
                If ValidarGrabado() = True Then
                    Grabar()
                End If
            Case Entity.EntityState.Modified
                If ValidarGrabado() = True Then
                    Editar()
                End If
        End Select
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        statusAction = Entity.EntityState.Added
        dgAsistencia.Enabled = False
        txtCodigoFiltrar.Tag = Nothing
        GradientPanel3.Enabled = True
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        statusAction = Nothing
        GradientPanel3.Enabled = False
        dgAsistencia.Enabled = True
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        statusAction = Entity.EntityState.Modified
        GradientPanel3.Enabled = True
        dgAsistencia.Enabled = False
        EditGrid(dgAsistencia.Table.CurrentRecord)
    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        If ValidarIngresoHorarios Then
            If ValidarHorario() Then
                GrabarHorarios()
            End If
        Else
            MessageBox.Show("De ingresar el horario completo", "Completar horario", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ButtonAdv7_Click(sender As Object, e As EventArgs) Handles ButtonAdv7.Click
        If ValidarDuplicados() Then
            AgregarItemListview()
        Else
            MessageBox.Show("El item ingresado ya está registrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub



    Private Sub ButtonAdv8_Click(sender As Object, e As EventArgs) Handles ButtonAdv8.Click
        If lsvHorarios.SelectedItems.Count > 0 Then
            lsvHorarios.SelectedItems(0).Remove()
        End If
    End Sub

    Private Sub frmHorariosPersonal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        editbox.ShowDropButton = False
        editbox.ShowUpDown = True
        editbox.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        editbox.ShowCheckBox = False
        editbox.Format = DateTimePickerFormat.Custom
        editbox.CustomFormat = "HH:mm:ss tt"
        editbox.Parent = lsvHorarios
        editbox.Hide()
        AddHandler editbox.LostFocus, AddressOf txtFechaHorario_LostFocus
        AddHandler editbox.KeyPress, AddressOf txtFechaHorario_KeyPress
        lsvHorarios.FullRowSelect = True
    End Sub
#End Region



End Class