Imports Helios.Cont.Business.Entity
Imports Helios.General

Imports Helios.Planilla.Business.Entity

Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Planilla.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class FormProyectoNuevo

#Region "Métodos"
    Sub confNuevo()
        TabPage1.Parent = TabControl1
        TabPage2.Parent = Nothing
        TabPage3.Parent = Nothing
        TabPage4.Parent = Nothing
        TabPage5.Parent = Nothing
        Label3.Visible = True
        Label6.Visible = False
        Label5.Visible = False
        Label8.Visible = False
        Label10.Visible = False
    End Sub

    Sub confNuevo2()
        TabPage1.Parent = TabControl1
        TabPage2.Parent = Nothing
        TabPage3.Parent = Nothing
        TabPage4.Parent = Nothing
        TabPage5.Parent = Nothing
        Label3.Visible = True
        Label6.Visible = True
        Label5.Visible = True
        Label8.Visible = True
        Label10.Visible = True
    End Sub

    Public Sub UbicarProyectoID(intProyecto As Integer)
        Dim proyectoSA As New ProyectoPlaneacionSA()
        Dim trabajadorSA As New Trabajador_PLSA()
        Dim Lista As New ProyectoPlaneacion
        Dim Trab As New Trabajador_PL
        Try
            Lista = proyectoSA.UbicarProyecto(intProyecto)
            If Not IsNothing(Lista) Then
                TextNombreProyecto.Text = Lista.nombreProyecto
                Trab = trabajadorSA.UbicarTrabDNI(Lista.responsable, Lista.idEstablecimiento)
                If Not IsNothing(Trab) Then
                    TextIdResponsable.Text = Lista.responsable
                    TextResponsable.Text = Trab.appat & " " & Trab.apmat & ", " & Trab.nombres
                End If
                dtpFechaInicio.Value = Lista.fechaInicio
                dtpFechaFinal.Value = Lista.fechaFinal
                txtModalidadServicio.Text = Lista.modalidadServicio
                txtNroContrato.Text = Lista.nroContrato
                txtOT.Text = Lista.ot
                txtPTE.Text = Lista.pte
                txtObjetivo.Text = Lista.objetivo
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub

    'Private Function UbicarTrabajadorID(intEstable As Integer, CodTrab As String) As List(Of Trabajador_PL)
    '    Dim TrabSA As New Trabajador_PLSA()
    '    Return TrabSA.UbicarTrabDNI(CodTrab, intEstable)
    'End Function
#End Region

#Region "Personal"

    'Public Function UbicarResponsable(ByVal strTipoEntidad As String, ByVal strIdEntidad As String, ByVal strEmpresa As String) As String
    '    Dim objService = HeliosSEProxy.CrearProxyHELIOS()
    '    Dim objLista() As HeliosService.Trabajador_PLBO = Nothing

    '    Try 'GetObtenerTrabProCodigo
    '        objLista = objService.GetObtenerTrabProCodigo(strTipoEntidad, strIdEntidad, strEmpresa)
    '        If objLista.Length > 0 Then
    '            strCodPersonal = CStr(objLista(0).codTrabajdor)
    '            strNomPersonal = CStr(objLista(0).nombres + " " + objLista(0).appat + " " + objLista(0).apmat)
    '        Else
    '            strCodPersonal = "..."
    '            strNomPersonal = "..."
    '        End If
    '    Catch ex As Exception
    '        MsgBox("Error al encontrar entidad." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema!")
    '    End Try
    '    Return strNomPersonal
    'End Function

    'Sub PersonalShow()
    '    Me.Cursor = Cursors.WaitCursor
    '    Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
    '    datos.Clear()
    '    With frmModalEntidades
    '        .lblTipo.Text = TIPO_ENTIDAD.PERSONAL_PLANILLA
    '        .StartPosition = FormStartPosition.CenterParent
    '        .ShowDialog()
    '        If datos.Count > 0 Then
    '            TextIdResponsable.Text = datos(0).ID
    '            TextResponsable.Text = datos(0).NombreEntidad

    '        Else
    '            TextIdResponsable.Text = String.Empty
    '            TextResponsable.Text = String.Empty

    '        End If
    '    End With

    '    Me.Cursor = Cursors.Arrow
    'End Sub
#End Region

#Region "Evento"

    Sub TrabajadoresShow()
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        Dim a As New ENTITY_ACTIONS
        With frmModalTrab
            .lblTipo.Text = TIPO_ENTIDAD.PERSONAL_PLANILLA
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            If datos.Count > 0 Then
                TextIdResponsable.Text = datos(0).ID
                TextResponsable.Text = datos(0).NombreEntidad

            Else
                TextIdResponsable.Text = String.Empty
                TextResponsable.Text = String.Empty

            End If
        End With

        Me.Cursor = Cursors.Arrow
    End Sub

    Sub SeleccionrarEquipoProy()
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        Dim a As New ENTITY_ACTIONS
        With frmModalTrab
            .lblTipo.Text = TIPO_ENTIDAD.PERSONAL_PLANILLA
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            If datos.Count > 0 Then
                txtidIntegrante.Text = datos(0).ID
                txtIntegrante.Text = datos(0).NombreEntidad

            Else
                txtidIntegrante.Text = String.Empty
                txtIntegrante.Text = String.Empty

            End If
        End With

        Me.Cursor = Cursors.Arrow
    End Sub

    Sub Grabar()
        Dim ProyectoSA = New ProyectoPlaneacionSA
        Dim prject As New ProyectoPlaneacion()
        Dim objACtividad As New Actividades()

        Dim nEquipo As New Actividades
        Dim ListaEquipo As New List(Of Actividades)
        With prject
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .objetivo = txtObjetivo.Text.Trim
            .nombreProyecto = TextNombreProyecto.Text
            .fechaInicio = dtpFechaInicio.Value
            .fechaFinal = dtpFechaFinal.Value
            .responsable = TextIdResponsable.Text
            .estadoCosto = "NA"
            .usuarioModificacion = "NN"
            .fechaModificacion = DateTime.Now
        End With

        With objACtividad
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .NombreActividad = TextNombreProyecto.Text
            .descripcion = TextNombreProyecto.Text
            .modulo = "PY"
            .responsable = TextIdResponsable.Text
            .FechaInicio = dtpFechaInicio.Value
            .FechaFinal = dtpFechaFinal.Value
            .usuarioActualizacion = "NN"
            .fechaActualizacion = DateTime.Now
        End With
        prject.Actividades.Add(objACtividad)

        If ProyectoSA.GrabarProyecto(prject) Then
            lblEstado.Text = "Proyecto registrado!"
            Me.lblEstado.Image = My.Resources.ok4
        Else
            lblEstado.Text = "Error al insertar proyecto!"
            Me.lblEstado.Image = My.Resources.warning2
        End If
    End Sub

    Sub EliminarEquipoPY(intIdActividad As Integer)
        Dim nEquipo As New Actividades
        Dim ActividadSA As New ActividadesSA
        With nEquipo
            .Action = Business.Entity.BaseBE.EntityAction.DELETE
            .idActividad = intIdActividad
        End With
        If ActividadSA.DeleteEDT(nEquipo) Then
            '  lsvEquipoProyecto.SelectedItems(0).Remove()
            lblEstado.Text = "registro eliminado!"
            Me.lblEstado.Image = My.Resources.ok4
        Else
            lblEstado.Text = "Error al eliminar proyecto!"
            Me.lblEstado.Image = My.Resources.warning2
        End If
    End Sub

    Sub InsertEquipo()
        Dim ProyectoSA = New ActividadesSA
        Dim prject As New ProyectoPlaneacion()
        Dim objACtividad As New List(Of Actividades)
        Dim nEquipo As New Actividades
        With prject
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .idProyecto = GProyectos.IdProyectoActividad
            .objetivo = txtObjetivo.Text.Trim
            .nombreProyecto = TextNombreProyecto.Text
            .fechaInicio = dtpFechaInicio.Value
            .fechaFinal = dtpFechaFinal.Value
            .responsable = TextIdResponsable.Text
            '   .estadoCosto = "NA"

            .modalidadServicio = txtModalidadServicio.Text.Trim
            .nroContrato = txtNroContrato.Text.Trim
            .ot = txtOT.Text.Trim
            .pte = txtPTE.Text.Trim
            .usuarioModificacion = "NN"
            .fechaModificacion = DateTime.Now
        End With
        For Each i As ListViewItem In lsvEquipoProyecto.Items
            nEquipo = New Actividades With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                            .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                            .idProyecto = GProyectos.IdProyectoActividad,
                                            .NombreActividad = TextNombreProyecto.Text,
                                            .descripcion = TextNombreProyecto.Text,
                                            .modulo = "EQ",
                                            .idPadre = GProyectos.IdProyecto,
                                            .responsable = i.SubItems(2).Text,
                                            .FechaInicio = dtpFechaInicio.Value,
                                            .FechaFinal = dtpFechaFinal.Value,
                                            .Estado = i.SubItems(3).Text,
                                            .flag = "A",
                                            .usuarioActualizacion = "NN",
                                            .fechaActualizacion = DateTime.Now}
            objACtividad.Add(nEquipo)
        Next
        If lsvEquipoCliente.Items.Count > 0 Then
            For Each i As ListViewItem In lsvEquipoCliente.Items
                nEquipo = New Actividades With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                .idProyecto = GProyectos.IdProyectoActividad,
                                                .NombreActividad = i.SubItems(2).Text,
                                                .descripcion = i.SubItems(3).Text,
                                                .modulo = "EQC",
                                                .unidad = i.SubItems(1).Text,
                                                .idPadre = GProyectos.IdProyecto,
                                                .responsable = txtIdCliente.Text.Trim,
                                                .Estado = i.SubItems(4).Text,
                                                .flag = "A",
                                                .usuarioActualizacion = "NN",
                                                .fechaActualizacion = DateTime.Now}
                objACtividad.Add(nEquipo)
            Next
        Else
            nEquipo = New Actividades With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                .idProyecto = GProyectos.IdProyectoActividad,
                                                .NombreActividad = Nothing,
                                                .descripcion = Nothing,
                                                .modulo = "EQC",
                                                .unidad = Nothing,
                                                .idPadre = GProyectos.IdProyecto,
                                                .responsable = txtIdCliente.Text.Trim,
                                                .Estado = ENTITY_ACTIONS.INSERT,
                                                .flag = "A",
                                                .usuarioActualizacion = "NN",
                                                .fechaActualizacion = DateTime.Now}

            objACtividad.Add(nEquipo)
        End If
      

        ProyectoSA.GrabarActividadEquipo(objACtividad, prject)
        lblEstado.Text = "Proyecto modificado!"
        Me.lblEstado.Image = My.Resources.ok4
    End Sub

    Sub Editar()
        Dim ProyectoSA = New ProyectoPlaneacionSA
        Dim prject As New ProyectoPlaneacion()
        prject.Action = Business.Entity.BaseBE.EntityAction.UPDATE
        prject.idProyecto = FormProyectoBuscar.lsvListaProyectos.SelectedItems(0).SubItems(0).Text
        prject.idEmpresa = Gempresas.IdEmpresaRuc
        prject.idEstablecimiento = GEstableciento.IdEstablecimiento
        prject.nombreProyecto = TextNombreProyecto.Text
        prject.objetivo = txtObjetivo.Text.Trim
        prject.fechaInicio = dtpFechaInicio.Value
        prject.fechaFinal = dtpFechaFinal.Value
        prject.responsable = TextIdResponsable.Text
        prject.estadoCosto = "P"
        If ProyectoSA.EditarProyecto(prject) Then
            lblEstado.Text = "Proyecto modificado!"
            Me.lblEstado.Image = My.Resources.ok4
            With FormProyectoBuscar
                With .lsvListaProyectos
                    With .SelectedItems(0)
                        .SubItems(1).Text = TextNombreProyecto.Text.Trim
                        .SubItems(3).Text = dtpFechaInicio.Value.Date
                        .SubItems(4).Text = dtpFechaFinal.Value.Date
                    End With
                End With
            End With
        Else
            lblEstado.Text = "Error al insertar proyecto!"
            Me.lblEstado.Image = My.Resources.warning2
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs)
        Dispose()
    End Sub

    Private Sub cboEstablecimiento_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
    End Sub

#End Region

#Region "Validacion"

    Private Sub TextNombreProyecto_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            TextResponsable.Focus()
            TextResponsable.Select(0, TextResponsable.Text.Length)

        End If
    End Sub

    Private Sub TextResponsable_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs)
        'If e.KeyCode = Keys.Enter Then
        '    e.SuppressKeyPress = True
        '    txtDescripcion.Focus()
        '    txtDescripcion.Select(0, txtDescripcion.Text.Length)

        'End If
    End Sub

    Private Sub txtDescripcion_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            dtpFechaInicio.Focus()
        End If
    End Sub

    Private Sub dtpFechaInicio_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            '  pcbGrabar.Focus()
        End If
    End Sub


    'Function validarcajas() As Boolean
    '    If Me.TextNombreProyecto.Text.Length = 0 Then
    '        ErrorCajas.SetError(Me.TextNombreProyecto, "Designe un nombre al Proyecto!")
    '        TextNombreProyecto.Focus()
    '        Me.Cursor = Cursors.Arrow
    '        Exit Function
    '    Else
    '        ErrorCajas.SetError(Me.TextNombreProyecto, "")
    '    End If

    '    If Me.TextIdResponsable.Text.Length = 0 Then
    '        ErrorCajas.SetError(Me.TextResponsable, "Designe un nombre de responsable!")
    '        TextResponsable.Focus()
    '        Me.Cursor = Cursors.Arrow
    '        Exit Function

    '    Else
    '        ErrorCajas.SetError(Me.TextResponsable, "")
    '    End If

    '    '
    '    Return True

    'End Function

    Private Sub TextNombreProyecto_Validating(sender As System.Object, e As System.ComponentModel.CancelEventArgs)
        If Me.TextNombreProyecto.Text.Length = 0 Then
            ErrorCajas.SetError(Me.TextNombreProyecto, "Designe un nombre al Proyecto!")
            '  e.Cancel = True
        Else
            ErrorCajas.SetError(Me.TextNombreProyecto, "")
        End If
    End Sub

    Private Sub TextResponsable_Validating(sender As System.Object, e As System.ComponentModel.CancelEventArgs)
        If Me.TextResponsable.Text.Length = 0 Then
            ErrorCajas.SetError(Me.TextResponsable, "Designe un nombre de responsable!")
            '      e.Cancel = True
        Else
            ErrorCajas.SetError(Me.TextResponsable, "")
        End If
    End Sub


#End Region

#Region "Metodos"

    Function ValidarCajas(ByVal controls As Control) As Boolean
        For Each control As Control In controls.Controls
            If TypeOf control Is TextBox Then
                If control.Text.Trim.Length > 0 Then

                Else
                    control.Focus()
                    control.Select()
                    Return False
                    Exit Function
                End If
            End If
        Next
        Return True
    End Function

    Public Sub deshabilitar()
        grbDetalleProyecto.Enabled = False
        grbTiempoProy.Enabled = False
    End Sub

    Public Sub Habilitar()
        grbDetalleProyecto.Enabled = False
        grbTiempoProy.Enabled = False
    End Sub

    Public Sub LimpiarCajas()
        TextNombreProyecto.Text = ""
        TextResponsable.Text = ""
        dtpFechaInicio.Value = Date.Now
        dtpFechaFinal.Value = Date.Now
    End Sub

    'Public Sub GrabarProyecto()

    '    Dim objService = HeliosSEProxy.CrearProxyHELIOS
    '    Dim objEVENTO As New HeliosService.ProyectoPlaneacionEO()
    '    Dim objDet As New HeliosService.ProyectoDetalleInfoBO()
    '    Dim objDetalle() As HeliosService.ProyectoDetalleInfoBO
    '    Dim conteo As Integer = dgvDetalle.Rows.Count
    '    conteo = conteo - 1
    '    ReDim objDetalle(conteo)
    '    Try
    '        objEVENTO.IdEvento = 0
    '        objEVENTO.IdEmpresa = CEmpresa
    '        objEVENTO.IdEstablecimiento = cboEstablecimiento.SelectedValue
    '        ' objEVENTO.descripcion = IIf(IsNothing(txtDescripcion.Text) Or String.IsNullOrEmpty(txtDescripcion.Text) Or String.IsNullOrWhiteSpace(txtDescripcion.Text), Nothing, Trim(txtDescripcion.Text).Trim)
    '        objEVENTO.UsuarioModificacion = cNombreusuario
    '        objEVENTO.fechaModificacion = Date.Now
    '        objEVENTO.FechaInicio = dtpFechaInicio.Value
    '        objEVENTO.FechaFinal = dtpFechaFinal.Value
    '        objEVENTO.NombreProyecto = TextNombreProyecto.Text
    '        objEVENTO.Responsable = TextIdResponsable.Text
    '        objEVENTO.fechaEstadoCobro = dtpFechaInicio.Value
    '        objEVENTO.EstadoCosto = "ED"
    '        objEVENTO.anotacionEstado = Nothing
    '        objEVENTO.refDocAprobacion = Nothing

    '        'mapeando del detalle del proyecto
    '        Dim S As Integer = 0
    '        For S = 0 To conteo
    '            objDet = New HeliosService.ProyectoDetalleInfoBO()
    '            objDet.IdItem = S + 1
    '            objDet.DetalleItem = dgvDetalle.Rows(S).Cells(1).Value()
    '            objDet.UnidadMedida = dgvDetalle.Rows(S).Cells(2).Value()
    '            objDet.Cantidad = dgvDetalle.Rows(S).Cells(4).Value()
    '            objDet.PrecioUnitario = dgvDetalle.Rows(S).Cells(5).Value()
    '            objDet.Importe = dgvDetalle.Rows(S).Cells(6).Value()
    '            objDet.FechaEntrega = dgvDetalle.Rows(S).Cells(7).Value()
    '            objDet.ObservacionesOtros = dgvDetalle.Rows(S).Cells(8).Value()
    '            objDet.UsuarioActualizacion = cIDUsuario
    '            objDet.FechaActualizacion = Date.Now
    '            objDetalle(S) = objDet
    '        Next S
    '        objEVENTO.ProyectoDetalleLista = objDetalle

    '        If objService.GrabarProyecto(objEVENTO) Then
    '            MsgBox("El proyecto se guardo correctamente", MsgBoxStyle.Information, "Congratulations.!")
    '            Dispose()

    '        End If
    '    Catch ex As Exception
    '        MsgBox("No se pudo grabar la empresa." & vbCrLf & ex.Message)
    '    End Try
    'End Sub

    'Public Sub ActualizarProyectoEstado()

    '    Dim objService = HeliosSEProxy.CrearProxyHELIOS
    '    Dim objEVENTO As New HeliosService.ProyectoPlaneacionEO()
    '    Dim objDet As New HeliosService.ProyectoDetalleInfoBO()
    '    Dim objDetalle() As HeliosService.ProyectoDetalleInfoBO
    '    Dim conteo As Integer = dgvDetalle.Rows.Count
    '    conteo = conteo - 1
    '    ReDim objDetalle(conteo)

    '    Try
    '        With FormProyectoBuscar
    '            objEVENTO.IdEvento = .lsvListaProyectos.SelectedItems(0).SubItems(0).Text

    '            '   objEVENTO.Descripcion = IIf(IsNothing(txtDescripcion.Text) Or String.IsNullOrEmpty(txtDescripcion.Text) Or String.IsNullOrWhiteSpace(txtDescripcion.Text), Nothing, Trim(txtDescripcion.Text).Trim)
    '            If (cboSituacion.Text = "APROBADO/EJECUCION") Then
    '                objEVENTO.FechaInicioAprob = DateTimePicker2.Value
    '                objEVENTO.FechaFinalAprob = DateTimePicker1.Value
    '                'objEVENTO.FechaInicio = dtpFechaInicio.Value
    '                'objEVENTO.FechaFinal = dtpFechaFinal.Value

    '            End If

    '            objEVENTO.Responsable = IIf(IsNothing(TextIdResponsable.Text) Or String.IsNullOrEmpty(TextIdResponsable.Text) Or String.IsNullOrWhiteSpace(TextIdResponsable.Text), Nothing, Trim(TextIdResponsable.Text).Trim)
    '            objEVENTO.UsuarioModificacion = cIDUsuario ' cNombreusuario
    '            objEVENTO.fechaModificacion = Date.Now

    '            'mapeando del detalle del proyecto
    '            If (Tag = 1) Then
    '                objEVENTO.NombreProyecto = TextNombreProyecto.Text
    '                objEVENTO.FechaInicio = dtpFechaInicio.Value
    '                objEVENTO.FechaFinal = dtpFechaFinal.Value
    '                With FormProyectoBuscar
    '                    Select Case .lsvListaProyectos.SelectedItems(0).SubItems(8).Text
    '                        Case "APROBADO"
    '                            objEVENTO.EstadoCosto = "AP"
    '                        Case "EN DEBATE"
    '                            objEVENTO.EstadoCosto = "ED"
    '                        Case "ANULADO"
    '                            objEVENTO.EstadoCosto = "AN"
    '                        Case "APROBADO/EJECUCION"
    '                            objEVENTO.EstadoCosto = "APE"
    '                    End Select
    '                    objEVENTO.fechaEstadoCobro = .lsvListaProyectos.SelectedItems(0).SubItems(9).Text
    '                    objEVENTO.anotacionEstado = .lsvListaProyectos.SelectedItems(0).SubItems(10).Text
    '                    objEVENTO.refDocAprobacion = .lsvListaProyectos.SelectedItems(0).SubItems(11).Text
    '                End With

    '                Dim S As Integer = 0
    '                For S = 0 To conteo
    '                    objDet = New HeliosService.ProyectoDetalleInfoBO()
    '                    objDet.IdItem = S + 1
    '                    objDet.DetalleItem = dgvDetalle.Rows(S).Cells(1).Value()
    '                    objDet.UnidadMedida = dgvDetalle.Rows(S).Cells(2).Value()
    '                    objDet.Cantidad = dgvDetalle.Rows(S).Cells(4).Value()
    '                    objDet.PrecioUnitario = dgvDetalle.Rows(S).Cells(5).Value()
    '                    objDet.Importe = dgvDetalle.Rows(S).Cells(6).Value()
    '                    objDet.FechaEntrega = dgvDetalle.Rows(S).Cells(7).Value()
    '                    objDet.ObservacionesOtros = dgvDetalle.Rows(S).Cells(8).Value()
    '                    objDet.UsuarioActualizacion = cIDUsuario
    '                    objDet.FechaActualizacion = Date.Now
    '                    objDetalle(S) = objDet
    '                Next S
    '                objEVENTO.ProyectoDetalleLista = objDetalle

    '            ElseIf (Tag = 2) Then
    '                objEVENTO.NombreProyecto = txtProyecto.Text

    '                Select Case cboSituacion.Text
    '                   Case "APROBADO"
    '                        objEVENTO.EstadoCosto = "AP"
    '                    Case "EN DEBATE"
    '                        objEVENTO.EstadoCosto = "ED"
    '                    Case "ANULADO"
    '                        objEVENTO.EstadoCosto = "AN"
    '                    Case "APROBADO/EJECUCION"
    '                        objEVENTO.EstadoCosto = "APE"
    '                End Select
    '                objEVENTO.fechaEstadoCobro = txtFechaSituacion.Value
    '                objEVENTO.anotacionEstado = txtAnotacion.Text
    '                objEVENTO.refDocAprobacion = txtdocAprobacion.Text
    '                objEVENTO.FechaInicio = DateTimePicker3.Value
    '                objEVENTO.FechaFinal = DateTimePicker4.Value
    '            End If

    '            If objService.UpdateProyectoSituacion(objEVENTO) Then
    '                MsgBox("El proyecto se actualizó correctamente", MsgBoxStyle.Information, "Congratulations.!")

    '                If (cboSituacion.Text = "APROBADO/EJECUCION") Then
    '                    If (DateTimePicker3.Value <= txtFechaSituacion.Value) Then
    '                        With frmMantFechaPlaneamiento
    '                            .lblEstablecimiento.Text = CNombreEstablecimiento ' cboEstablecimiento.Text
    '                            .lblEmpresa.Text = CNombreEmpresa
    '                            '  .CargarProyectos()
    '                            '.srtidevento = srtidevento
    '                            .txtProyecto.Text = txtProyecto.Text
    '                            .DateTimePicker3.Value = DateTimePicker2.Value
    '                            .DateTimePicker4.Value = DateTimePicker1.Value
    '                            .srtidevento = srtidevento
    '                            .srttag = 1
    '                            .obtenerPlaneacionproCodigo2(srtidevento, "EJ")
    '                            .StartPosition = FormStartPosition.CenterScreen
    '                            .ShowDialog()

    '                        End With
    '                    Else


    '                    End If


    '                    'With frmMantenimientoPlaneamiento
    '                    '    .lblEstablecimiento.Text = CNombreEstablecimiento ' cboEstablecimiento.Text
    '                    '    .lblEmpresa.Text = CNombreEmpresa
    '                    '    '  .CargarProyectos()
    '                    '    .srtidevento = srtidevento
    '                    '    .buscarPlaneamiento()
    '                    '    .StartPosition = FormStartPosition.CenterScreen
    '                    '    .ShowDialog()
    '                    '    Dispose()
    '                    'End With
    '                Else
    '                    .rbdTodo.Checked = True
    '                    .CargarProyectos()
    '                    Dispose()
    '                End If

    '            End If

    '        End With
    '    Catch ex As Exception
    '        MsgBox("No se pudo Actualizar el documento." & vbCrLf & ex.Message)
    '    End Try
    'End Sub

#End Region

#Region "Equipo de Proyecto"
    Public Sub ObtenerListaEquipoProyecto()
        Dim actividadSA As New ActividadesSA
        lsvEquipoProyecto.Items.Clear()
        For Each i As Actividades In actividadSA.GetUbicarActividadPorModulo(GProyectos.IdProyecto, "EQ")
            Dim n As New ListViewItem(i.idActividad)
            n.SubItems.Add(i.NombreResponsableEquipo)
            n.SubItems.Add(i.responsable)
            n.SubItems.Add(ENTITY_ACTIONS.UPDATE)
            lsvEquipoProyecto.Items.Add(n)
        Next
    End Sub

    Public Sub ObtenerListaEquipoCliente()
        Dim actividadSA As New ActividadesSA
        lsvEquipoCliente.Items.Clear()
        txtIdCliente.Clear()
        txtCliente.Clear()
        For Each i As Actividades In actividadSA.GetUbicarActividadPorModuloOcupacion(GProyectos.IdProyecto, "EQC")
            If Not IsNothing(i.NombreActividad) Then
                Dim n As New ListViewItem(i.idActividad)
                n.SubItems.Add(i.unidad)
                n.SubItems.Add(i.NombreActividad)
                n.SubItems.Add(i.descripcion)
                n.SubItems.Add(ENTITY_ACTIONS.UPDATE)
                lsvEquipoCliente.Items.Add(n)
            End If
            txtIdCliente.Text = i.responsable
            txtCliente.Text = i.nombreTrab
        Next
    End Sub
#End Region

    Private Sub FormProyectoNuevo_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub


    Private Sub FormProyectoNuevo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ' TextNombreProyecto.Select()

        ObtenerCargosPorEstablecimiento()
    End Sub


    'Sub UnidadShows()
    '    Me.Cursor = Cursors.WaitCursor
    '    Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
    '    datos.Clear()
    '    With frmModalComprobantesTabla
    '        .lblTipo.Text = "6"
    '        .StartPosition = FormStartPosition.CenterParent
    '        .ShowDialog()
    '        If datos.Count > 0 Then
    '            dgvDetalle.Item(2, dgvDetalle.CurrentRow.Index).Value = datos(0).ID
    '            dgvDetalle.Item(3, dgvDetalle.CurrentRow.Index).Value = datos(0).NombreCampo
    '        Else
    '            dgvDetalle.Item(2, dgvDetalle.CurrentRow.Index).Value = String.Empty
    '            dgvDetalle.Item(3, dgvDetalle.CurrentRow.Index).Value = String.Empty
    '        End If
    '    End With
    '    Me.Cursor = Cursors.Arrow
    'End Sub


    Private Sub btnSAlir_Click(sender As System.Object, e As System.EventArgs) Handles btnSAlir.Click
        Dispose()
    End Sub
    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        Me.Cursor = Cursors.WaitCursor
        If CDate(dtpFechaFinal.Value.Date) < CDate(dtpFechaInicio.Value.Date) Then
            MsgBox("La fecha de termino no debe ser menor a la fecha de inicio.!", MsgBoxStyle.Information, "Atención")
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If
        Grabar()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs)
        Dispose()
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        If Not TextNombreProyecto.Text.Trim.Length > 0 Then
            lblEstado.Text = "debe indicar el nombre del proyecto.!"
            lblEstado.Image = My.Resources.warning2
            TextNombreProyecto.Select()
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If
        If Not TextIdResponsable.Text.Trim.Length > 0 Then
            lblEstado.Text = "debe indicar el director del proyecto.!"
            lblEstado.Image = My.Resources.warning2
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If
        If CDate(dtpFechaFinal.Value.Date) < CDate(dtpFechaInicio.Value.Date) Then
            'MsgBox("La fecha de termino no debe ser menor a la fecha de inicio.!", MsgBoxStyle.Information, "Atención")
            lblEstado.Text = "La fecha de termino no debe ser menor a la fecha de inicio.!"
            lblEstado.Image = My.Resources.warning2
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If
        If Modpreliminar = Modulo_Preliminar.BASICO Then
            Select Case TmpAction
                Case ENTITY_ACTIONS.INSERT
                    Grabar()
                Case ENTITY_ACTIONS.UPDATE
                    Editar()
            End Select
        ElseIf Modpreliminar = Modulo_Preliminar.INTERMEDIO Then
            InsertEquipo()
        End If
        Dispose()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        Dispose()
    End Sub

    Private Sub linkResp_Click_1(sender As System.Object, e As System.EventArgs) Handles linkResp.Click
        Me.Cursor = Cursors.WaitCursor
        TrabajadoresShow()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub TabPage3_Click(sender As System.Object, e As System.EventArgs) Handles TabPage3.Click

    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lsvEquipoCliente.SelectedIndexChanged

    End Sub

    Private Sub Label3_Click(sender As System.Object, e As System.EventArgs) Handles Label3.Click
        TabPage1.Parent = TabControl1
        TabPage2.Parent = Nothing
        TabPage3.Parent = Nothing
        TabPage4.Parent = Nothing
        TabPage5.Parent = Nothing
    End Sub

    Private Sub Label6_Click(sender As System.Object, e As System.EventArgs) Handles Label6.Click
        TabPage1.Parent = Nothing
        TabPage2.Parent = TabControl1
        TabPage3.Parent = Nothing
        TabPage4.Parent = Nothing
        TabPage5.Parent = Nothing
    End Sub

    Private Sub Label5_Click(sender As System.Object, e As System.EventArgs) Handles Label5.Click
        TabPage1.Parent = Nothing
        TabPage2.Parent = Nothing
        TabPage3.Parent = TabControl1
        TabPage4.Parent = Nothing
        TabPage5.Parent = Nothing
    End Sub

    Private Sub Label8_Click(sender As System.Object, e As System.EventArgs) Handles Label8.Click
        TabPage1.Parent = Nothing
        TabPage2.Parent = Nothing
        TabPage3.Parent = Nothing
        TabPage4.Parent = TabControl1
        TabPage5.Parent = Nothing
    End Sub

    Private Sub Label10_Click(sender As System.Object, e As System.EventArgs) Handles Label10.Click
        TabPage1.Parent = Nothing
        TabPage2.Parent = Nothing
        TabPage3.Parent = Nothing
        TabPage4.Parent = Nothing
        TabPage5.Parent = TabControl1
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        SeleccionrarEquipoProy()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LinkLabel7_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel7.LinkClicked
        If txtIntegrante.Text.Trim.Length > 0 Then
            Dim n As New ListViewItem("0")
            n.SubItems.Add(txtIntegrante.Text.Trim)
            n.SubItems.Add(txtidIntegrante.Text.Trim)
            n.SubItems.Add(ENTITY_ACTIONS.INSERT)
            lsvEquipoProyecto.Items.Add(n)
            lblEstado.Text = "Done! Integrante"
            lblEstado.Image = My.Resources.ok4
            txtidIntegrante.Clear()
            txtIntegrante.Clear()
        Else
            lblEstado.Text = "Ingrese un integrante válido"
            lblEstado.Image = My.Resources.warning2
        End If

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        ProveedoresShow()
    End Sub

    Sub ProveedoresShow()
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        With frmModalEntidades
            .lblTipo.Text = TIPO_ENTIDAD.CLIENTE
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            If datos.Count > 0 Then
                txtIdCliente.Text = datos(0).ID
                txtCliente.Text = datos(0).NombreEntidad

            Else
                'txtIdCliente.Text = String.Empty
                'txtCliente.Text = String.Empty

            End If
        End With

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ObtenerCargosPorEstablecimiento()
        Dim ocupacionSA As New ocupacionSA
        Dim objEstados As New List(Of ocupacion)
        Dim ACTDBSuggestions _
            As New AutoCompleteStringCollection()
        Try
            objEstados = ocupacionSA.ObtenerOcupacion(GEstableciento.IdEstablecimiento)
            For Each i As ocupacion In objEstados
                ACTDBSuggestions.Add(i.nombreOcupacion)
            Next
            txtCargoCliente.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtCargoCliente.AutoCompleteCustomSource = ACTDBSuggestions
            txtCargoCliente.AutoCompleteMode = AutoCompleteMode.Suggest

        Catch ex As Exception
            MsgBox("No se pudo cargar la información para la lista de EF." & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub txtCargoCliente_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCargoCliente.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Dim ocupacionSA As New ocupacionSA
            If txtCargoCliente.AutoCompleteCustomSource.Contains(txtCargoCliente.Text.Trim) Then
                '      lblEstado.ForeColor = Color.OliveDrab
                ' & vbCrLf & "este número no esta disponible."
                With ocupacionSA.GetUbicarOcupacionPorNombre(txtCargoCliente.Text, GEstableciento.IdEstablecimiento)
                    txtCodOcupa.Text = .codOcupacion
                End With
                lblEstado.Text = "Done ocupación.!"
                lblEstado.Tag = "IH"
                lblEstado.Image = My.Resources.ok4
                txtNomCliente.Focus()
                txtNomCliente.Select(0, txtNomCliente.Text.Length)
            Else

                '   lblEstado.ForeColor = Color.Red
                lblEstado.Text = "La ocupación no existe en la BD., "
                lblEstado.Tag = "H"
                lblEstado.Image = My.Resources.warning2
                txtCodOcupa.Clear()
                txtCargoCliente.Focus()
                txtCargoCliente.Select(0, txtCargoCliente.Text.Length)

            End If
        End If

    End Sub

    Private Sub txtCargoCliente_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCargoCliente.TextChanged

    End Sub

    Private Sub Panel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub LinkLabel6_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        If lsvEquipoProyecto.SelectedItems.Count > 0 Then
            If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If lsvEquipoProyecto.SelectedItems(0).SubItems(3).Text = ENTITY_ACTIONS.INSERT Then
                    lsvEquipoProyecto.SelectedItems(0).Remove()
                ElseIf lsvEquipoProyecto.SelectedItems(0).SubItems(3).Text = ENTITY_ACTIONS.UPDATE Then
                    EliminarEquipoPY(lsvEquipoProyecto.SelectedItems(0).SubItems(0).Text)
                    ObtenerListaEquipoProyecto()
                End If
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        If txtCargoCliente.Text.Trim.Length > 0 And txtNomCliente.Text.Trim.Length > 0 And txtMailCliente.Text.Trim.Length > 0 Then
            Dim n As New ListViewItem(0)
            n.SubItems.Add(txtCodOcupa.Text.Trim)
            n.SubItems.Add(txtNomCliente.Text.Trim)
            n.SubItems.Add(txtMailCliente.Text.Trim)
            n.SubItems.Add(ENTITY_ACTIONS.INSERT)
            lsvEquipoCliente.Items.Add(n)
            lblEstado.Text = "Done Datos!"
            lblEstado.Image = My.Resources.ok4
        Else
            lblEstado.Text = "Complete todos los campos del cliente"
            lblEstado.Image = My.Resources.warning2
        End If
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        If lsvEquipoCliente.SelectedItems.Count > 0 Then
            If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If lsvEquipoCliente.SelectedItems(0).SubItems(4).Text = ENTITY_ACTIONS.INSERT Then
                    lsvEquipoCliente.SelectedItems(0).Remove()
                ElseIf lsvEquipoCliente.SelectedItems(0).SubItems(4).Text = ENTITY_ACTIONS.UPDATE Then
                    EliminarEquipoPY(lsvEquipoCliente.SelectedItems(0).SubItems(0).Text)
                    ObtenerListaEquipoProyecto()
                    ObtenerListaEquipoCliente()
                End If
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub
End Class