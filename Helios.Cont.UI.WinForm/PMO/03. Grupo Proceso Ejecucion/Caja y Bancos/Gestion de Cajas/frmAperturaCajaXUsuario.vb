Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Drawing
Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Imports System.ComponentModel
Public Class frmAperturaCajaXUsuario
   
#Region "Attributes"
    Inherits frmMaster
    Dim colorx As New GridMetroColors()
    Dim objCajausuario As New cajaUsuario
    Dim sumMontoMN As Decimal
    Dim sumMontoME As Decimal
    Public Property ListaAsientonTransito As New List(Of asiento)
    Public Property strEstadoManipulacion() As String
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGrid(dgvAperturaCajaXUsuario)
        dgvAperturaCajaXUsuario.DataSource = UbicarCajasHijas()

        txtFecHaApertura.Value = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
    End Sub
#End Region

#Region "Methods"
#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean

        'If Not parpadear Then
        '    lblEstado.ForeColor = lblEstado.BackColor
        '    lblEstado.BackColor = Color.Yellow
        'Else
        '    lblEstado.ForeColor = SystemColors.WindowText
        'End If

        parpadear = Not parpadear
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If TiempoRestante > 0 Then
            parpadeo()

            'lblAgregar.Visible = True
            'lblMensaje.Visible = True
            'tsSave.Enabled = False
            'lblMensaje.Text = "Agregar otro en: " & TiempoRestante
            TiempoRestante = TiempoRestante - 1
        ElseIf TiempoRestante = 0 Then
            Timer1.Enabled = False
            'lblEstado.ForeColor = Color.Navy
            'lblEstado.BackColor = Color.Transparent
            PanelError.Visible = False
            '      Dispose()
        Else
            Timer1.Enabled = False
            'Ejecuta tu función cuando termina el tiempo
            TiempoEjecutar(10)

        End If
    End Sub
    Private TiempoRestante As Integer
    Public Sub TimerOn(ByRef Interval As Short)
        If Interval > 0 Then
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
        End If

    End Sub
    Public Function TiempoEjecutar(ByVal Tiempo As Integer)
        TiempoEjecutar = ""
        TiempoRestante = Tiempo  ' 1 minutos=60 segundos 
        Timer1.Interval = 400

        Call TimerOn(1000) ' Hechanos a andar el timer
    End Function
#End Region

    Public Function UbicarCajasHijas() As DataTable

        Dim DT As New DataTable()
        DT.Columns.Add("codigo", GetType(String))
        DT.Columns.Add("IdEntidad", GetType(Integer))
        DT.Columns.Add("entidad", GetType(String))
        DT.Columns.Add("moneda", GetType(String))
        DT.Columns.Add("tc", GetType(Decimal))
        DT.Columns.Add("importeMN", GetType(Decimal))
        DT.Columns.Add("importeME", GetType(Decimal))
        DT.Columns.Add("montoMax", GetType(Decimal))
        Return DT
    End Function


    Public Sub UbicarCajaUsuario(inrIdPersona As Integer)
        Dim cajausuarioSA As New cajaUsuarioSA
        Dim cajausuarioDetalleSA As New cajaUsuarioDetalleSA
        Dim cajausuario As New cajaUsuario
        Dim usuarioSA As New UsuarioSA
        Dim efSA As New EstadosFinancierosSA
        Dim ef As New estadosFinancieros
        Dim usuarioBL As New Usuario
        Dim usuarioDetalleBL As New Usuario
        Dim listacajausuario As New List(Of cajaUsuario)

        Try

            If (IsNothing(cajausuarioSA.UbicarUsuarioAbierto(inrIdPersona))) Then
                With usuarioBL
                    .IDUsuario = inrIdPersona
                End With

                usuarioDetalleBL = usuarioSA.UbicarUsuarioXid(usuarioBL)

                txtNombreCaja.Text = usuarioDetalleBL.Nombres & " " & usuarioDetalleBL.ApellidoPaterno & " " & usuarioDetalleBL.ApellidoMaterno
                txtNombreCaja.Tag = usuarioBL.IDUsuario

                txtDni.Text = usuarioDetalleBL.NroDocumento

                txtFecHaApertura.Value = Date.Now

                Me.dgvAperturaCajaXUsuario.Table.Records.DeleteAll()

                objCajausuario = cajausuarioSA.ValidarCajaXUsuario(inrIdPersona)

                If (Not IsNothing(objCajausuario)) Then

                    For Each i In cajausuarioDetalleSA.ListaDetallePorCaja(objCajausuario.idcajaUsuario)
                        ef = efSA.GetUbicar_estadosFinancierosPorID(i.idEntidad)

                        Me.dgvAperturaCajaXUsuario.Table.AddNewRecord.SetCurrent()
                        Me.dgvAperturaCajaXUsuario.Table.AddNewRecord.BeginEdit()
                        Me.dgvAperturaCajaXUsuario.Table.CurrentRecord.SetValue("codigo", i.secuencia)
                        Me.dgvAperturaCajaXUsuario.Table.CurrentRecord.SetValue("IdEntidad", i.idEntidad)
                        Me.dgvAperturaCajaXUsuario.Table.CurrentRecord.SetValue("entidad", ef.descripcion)
                        Me.dgvAperturaCajaXUsuario.Table.CurrentRecord.SetValue("moneda", IIf(ef.codigo = "1", "NACIONAL", "EXTRANJERA"))
                        Me.dgvAperturaCajaXUsuario.Table.CurrentRecord.SetValue("tc", TmpTipoCambio)
                        Me.dgvAperturaCajaXUsuario.Table.CurrentRecord.SetValue("importeMN", i.importeMN)
                        Me.dgvAperturaCajaXUsuario.Table.CurrentRecord.SetValue("importeME", i.importeME)
                        Me.dgvAperturaCajaXUsuario.Table.CurrentRecord.SetValue("montoMax", 0)
                        Me.dgvAperturaCajaXUsuario.Table.AddNewRecord.EndEdit()
                        sumMontoMN += i.importeMN
                        sumMontoME += i.importeME
                    Next

                End If
                Panel2.Visible = True
            Else
                'Throw New Exception("Ya existe una caja abierta con su cuenta")
                With usuarioBL
                    .IDUsuario = inrIdPersona
                End With

                usuarioDetalleBL = usuarioSA.UbicarUsuarioXid(usuarioBL)

                txtNombreCaja.Text = usuarioDetalleBL.Nombres & " " & usuarioDetalleBL.ApellidoPaterno & " " & usuarioDetalleBL.ApellidoMaterno
                txtNombreCaja.Tag = usuarioBL.IDUsuario

                txtDni.Text = usuarioDetalleBL.NroDocumento

                txtFecHaApertura.Value = Date.Now

                Me.dgvAperturaCajaXUsuario.Table.Records.DeleteAll()

                objCajausuario = cajausuarioSA.ValidarCajaXUsuario(inrIdPersona)

                If (Not IsNothing(objCajausuario)) Then

                    For Each i In cajausuarioDetalleSA.ListaDetallePorCaja(objCajausuario.idcajaUsuario)
                        ef = efSA.GetUbicar_estadosFinancierosPorID(i.idEntidad)

                        Me.dgvAperturaCajaXUsuario.Table.AddNewRecord.SetCurrent()
                        Me.dgvAperturaCajaXUsuario.Table.AddNewRecord.BeginEdit()
                        Me.dgvAperturaCajaXUsuario.Table.CurrentRecord.SetValue("codigo", i.secuencia)
                        Me.dgvAperturaCajaXUsuario.Table.CurrentRecord.SetValue("IdEntidad", i.idEntidad)
                        Me.dgvAperturaCajaXUsuario.Table.CurrentRecord.SetValue("entidad", ef.descripcion)
                        Me.dgvAperturaCajaXUsuario.Table.CurrentRecord.SetValue("moneda", IIf(ef.codigo = "1", "NACIONAL", "EXTRANJERA"))
                        Me.dgvAperturaCajaXUsuario.Table.CurrentRecord.SetValue("tc", TmpTipoCambio)
                        Me.dgvAperturaCajaXUsuario.Table.CurrentRecord.SetValue("importeMN", i.importeMN)
                        Me.dgvAperturaCajaXUsuario.Table.CurrentRecord.SetValue("importeME", i.importeME)
                        Me.dgvAperturaCajaXUsuario.Table.CurrentRecord.SetValue("montoMax", 0)
                        Me.dgvAperturaCajaXUsuario.Table.AddNewRecord.EndEdit()
                        sumMontoMN += i.importeMN
                        sumMontoME += i.importeME
                    Next

                End If
                Panel2.Visible = False
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try

    End Sub

    Public Sub HabilitarUsoCaja(intIdUsuario As Integer)
        'Dim cajaUsuarioSA As New cajaUsuarioSA
        'Dim cajaUsuario As New cajaUsuario
        'Dim efSA As New EstadosFinancierosSA
        'Dim NEstadosSA As New estadosFinancieros


        'GFichaUsuarios = GFichaUsuario.InstanceSingle()
        'GFichaUsuarios.Clear()
        'Dim UsuarioEstadoCaja As New UsuarioEstadoCaja

        'cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(intIdUsuario, "A", "S", Nothing)

        'If Not IsNothing(cajaUsuario) Then
        '    With cajaUsuario
        '        NEstadosSA = efSA.GetUbicar_estadosFinancierosPorID(.idCajaOrigen)
        '        GFichaUsuarios.IdCajaUsuario = .idcajaUsuario
        '        GFichaUsuarios.IdPersona = .idPersona
        '        GFichaUsuarios.NombrePersona = usuario.Alias
        '        GFichaUsuarios.ClaveUsuario = .claveIngreso
        '        GFichaUsuarios.IdCajaOrigen = .idCajaOrigen
        '        GFichaUsuarios.IdCajaDestino = .idCajaOrigen
        '        GFichaUsuarios.cuentaDestino = NEstadosSA.cuenta
        '        GFichaUsuarios.NomCajaDestinb = NEstadosSA.descripcion
        '        GFichaUsuarios.FechaApertura = .fechaRegistro
        '        GFichaUsuarios.Moneda = .moneda
        '        GFichaUsuarios.TipoCambio = .tipoCambio
        '        GFichaUsuarios.FondoMN = .fondoMN
        '        GFichaUsuarios.FondoME = .fondoME
        '        GFichaUsuarios.EstadoCaja = .idcajaUsuario
        '        GFichaUsuarios.EnUso = .idcajaUsuario
        '        UsuarioEstadoCaja.GetSaldoActual(GFichaUsuarios)
        '    End With
        'Else
        '    'MessageBoxAdv.Show("No tiene asiganda una caja!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    'Throw New Exception("No tiene asiganda una caja!")
        'End If


        ''With cajaUsuarioSA.UbicarCajaAsignadaUser(txtDni.Text.Trim, "A", "S", txtClave.Text.Trim)
        ''    NEstadosSA = efSA.GetUbicar_estadosFinancierosPorID(.idCajaDestino)
        ''    GFichaUsuarios.IdCajaUsuario = .idcajaUsuario
        ''    GFichaUsuarios.IdPersona = .idPersona
        ''    GFichaUsuarios.NombrePersona = txtPersona.Text.Trim
        ''    GFichaUsuarios.ClaveUsuario = .claveIngreso
        ''    GFichaUsuarios.IdCajaOrigen = .idCajaOrigen
        ''    GFichaUsuarios.IdCajaDestino = .idCajaDestino
        ''    GFichaUsuarios.cuentaDestino = NEstadosSA.cuenta
        ''    GFichaUsuarios.NomCajaDestinb = NEstadosSA.descripcion
        ''    GFichaUsuarios.FechaApertura = .fechaRegistro
        ''    GFichaUsuarios.Moneda = .moneda
        ''    GFichaUsuarios.TipoCambio = .tipoCambio
        ''    GFichaUsuarios.FondoMN = CDec(.fondoMN + (montoMNF))
        ''    GFichaUsuarios.FondoME = CDec(.fondoME + (montoMEF))
        ''    GFichaUsuarios.EstadoCaja = .idcajaUsuario
        ''    GFichaUsuarios.EnUso = .idcajaUsuario
        ''End With
        'Dispose()

        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim cajaUsuario As New cajaUsuario
        Dim efSA As New EstadosFinancierosSA
        Dim NEstadosSA As New estadosFinancieros


        GFichaUsuarios = GFichaUsuario.InstanceSingle()
        GFichaUsuarios.Clear()
        Dim UsuarioEstadoCaja As New UsuarioEstadoCaja

        cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(intIdUsuario, "A", "S", Nothing)

        '
        If Not IsNothing(cajaUsuario) Then
            With cajaUsuario
                'NEstadosSA = efSA.GetUbicar_estadosFinancierosPorID(.idCajaOrigen)
                GFichaUsuarios.IdCajaUsuario = .idcajaUsuario
                GFichaUsuarios.IdPersona = .idPersona
                GFichaUsuarios.NombrePersona = usuario.Alias
                GFichaUsuarios.ClaveUsuario = .claveIngreso
                GFichaUsuarios.IdCajaOrigen = .idCajaOrigen.GetValueOrDefault
                GFichaUsuarios.IdCajaDestino = .idCajaOrigen.GetValueOrDefault
                GFichaUsuarios.cuentaDestino = NEstadosSA.cuenta
                GFichaUsuarios.NomCajaDestinb = NEstadosSA.descripcion
                GFichaUsuarios.FechaApertura = .fechaRegistro
                GFichaUsuarios.Moneda = .moneda
                GFichaUsuarios.TipoCambio = .tipoCambio
                GFichaUsuarios.FondoMN = .fondoMN
                GFichaUsuarios.FondoME = .fondoME
                GFichaUsuarios.EstadoCaja = .estadoCaja
                GFichaUsuarios.EnUso = .idcajaUsuario
                UsuarioEstadoCaja.GetSaldoActual(GFichaUsuarios)
            End With
        Else
            'MessageBoxAdv.Show("No tiene asiganda una caja!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'Throw New Exception("No tiene asiganda una caja!")
        End If

        Dispose()
    End Sub

    Private Sub grabarApertura()
        Dim cajaSA As New cajaUsuarioSA
        Dim objCaja As New cajaUsuario
        Dim documentoSA As New DocumentoSA
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim ndocumento As New documento
        Dim ndocumentoCaja As New documentoCaja
        Dim ndocumentoCajaDetalle As New documentoCajaDetalle
        Dim ListadocumentoCajaDetalle As New List(Of documentoCajaDetalle)
        Dim asiento As New asiento
        Dim ListaAsiento As New List(Of asiento)
        Dim ListaSubUsers As New List(Of cajaUsuario)
        Dim SubUsers As New cajaUsuario
        Dim UserDetalle As New cajaUsuariodetalle
        Dim ListaUserDetalle As New List(Of cajaUsuariodetalle)
        ListaAsientonTransito = New List(Of asiento)

        Try

            If (dgvAperturaCajaXUsuario.Table.Records.Count > 0) Then
                With objCaja
                    .idEmpresa = Gempresas.IdEmpresaRuc
                    .idEstablecimiento = GEstableciento.IdEstablecimiento
                    .periodo = PeriodoGeneral
                    .idPersona = txtNombreCaja.Tag
                    .idCajaOrigen = "0"
                    .idCajaDestino = Nothing ' txtDestino.Tag
                    .moneda = "1"
                    .tipoCambio = TmpTipoCambio
                    .fechaRegistro = txtFecHaApertura.Value
                    .fondoMN = sumMontoMN  ' txtFondoMN.DecimalValue
                    .fondoME = sumMontoME ' txtFondoME.DecimalValue
                    '.claveIngreso = txtClave.Text.Trim
                    .ingresoAdicMN = 0
                    .ingresoAdicME = 0
                    .otrosIngresosMN = 0
                    .otrosIngresosME = 0
                    .otrosEgresosMN = 0
                    .otrosEgresosME = 0
                    .estadoCaja = "A"
                    .enUso = "N"
                    .usuarioActualizacion = "Jiuni"
                    .fechaActualizacion = DateTime.Now
                End With

                For Each i As Record In dgvAperturaCajaXUsuario.Table.Records
                    UserDetalle = New cajaUsuariodetalle
                    UserDetalle.idEntidad = i.GetValue("IdEntidad")
                    Select Case i.GetValue("moneda")
                        Case "NACIONAL"
                            UserDetalle.moneda = 1
                        Case Else
                            UserDetalle.moneda = 2
                    End Select
                    UserDetalle.importeMN = CDec(i.GetValue("importeMN"))
                    UserDetalle.importeME = CDec(i.GetValue("importeME"))
                    UserDetalle.usuarioActualizacion = usuario.IDUsuario
                    UserDetalle.fechaActualizacion = DateTime.Now
                    ListaUserDetalle.Add(UserDetalle)
                Next
                objCaja.cajaUsuariodetalle = ListaUserDetalle
                Dim codigoUsuarioClave = documentoCajaSA.SaveGroupCajaApertura(Nothing, objCaja, ListaSubUsers)
                Tag = codigoUsuarioClave
                Dispose()
            Else
                lblEstado.Text = "No tiene ninguna cuenta financiera aperturada!"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(10)
            End If

        Catch ex As Exception
            Tag = Nothing
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try

    End Sub

#End Region

#Region "Events"
   
    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dispose()
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        grabarApertura()
        'HabilitarUsoCaja()
    End Sub

    Private Sub gridGroupingControl1_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvAperturaCajaXUsuario.TableControlCurrentCellEditingComplete
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'Dim montoME As Decimal = 0
        'Dim montoMN As Decimal = 0
        'Dim moneda As String

        'If Not IsNothing(Me.dgvAperturaCajaXUsuario.Table.CurrentRecord) Then
        '    Select Case ColIndex
        '        Case 6
        '            moneda = Me.dgvAperturaCajaXUsuario.Table.CurrentRecord.GetValue("moneda")
        '            If (moneda = "NACIONAL") Then
        '                If (Me.dgvAperturaCajaXUsuario.Table.CurrentRecord.GetValue("moneda") = "NACIONAL") Then
        '                    If (Me.dgvAperturaCajaXUsuario.Table.CurrentRecord.GetValue("importeME") > 0) Then
        '                        Me.dgvAperturaCajaXUsuario.Table.CurrentRecord.SetValue("importeME", 0.0)
        '                    End If
        '                End If

        '            Else
        '                Me.dgvAperturaCajaXUsuario.Table.CurrentRecord.SetValue("importeMN", 0.0)
        '                lblEstado.Text = "la cuenta seleccionada es Extranjera!"
        '                PanelError.Visible = True
        '                Timer1.Enabled = True
        '                TiempoEjecutar(10)
        '            End If

        '        Case 7
        '            moneda = Me.dgvAperturaCajaXUsuario.Table.CurrentRecord.GetValue("moneda")
        '            If (moneda = "EXTRANJERA") Then
        '                If (Me.dgvAperturaCajaXUsuario.Table.CurrentRecord.GetValue("moneda") = "EXTRANJERA") Then

        '                    If (Me.dgvAperturaCajaXUsuario.Table.CurrentRecord.GetValue("importeMN") > 0) Then
        '                        Me.dgvAperturaCajaXUsuario.Table.CurrentRecord.SetValue("importeMN", 0.0)
        '                    End If
        '                Else
        '                    Me.dgvAperturaCajaXUsuario.Table.CurrentRecord.SetValue("importeME", 0.0)
        '                    lblEstado.Text = "la cuenta seleccionada es Nacional!"
        '                    PanelError.Visible = True
        '                    Timer1.Enabled = True
        '                    TiempoEjecutar(10)
        '                End If
        '            End If

        '    End Select
        'End If
    End Sub

    Private Sub chSinReferencia_CheckedChanged(sender As Object, e As EventArgs)

        'Dim cajausuarioSA As New cajaUsuarioSA
        'Dim cajausuarioDetalleSA As New cajaUsuarioDetalleSA
        'Dim cajausuario As New cajaUsuario
        'Dim usuarioSA As New UsuarioSA
        'Dim efSA As New EstadosFinancierosSA
        'Dim ef As New estadosFinancieros
        'Dim usuarioBL As New Usuario
        'Dim usuarioDetalleBL As New Usuario
        'Dim listacajausuario As New List(Of cajaUsuario)
        'Dim montoMN As Decimal
        'Dim montoME As Decimal

        'If chSinReferencia.Checked = True Then
        '    For Each i As Record In gridGroupingControl1.Table.Records
        '        i.SetValue("importeMN", 0.0)
        '        i.SetValue("importeME", 0.0)
        '        txtSaldoResponsableMN.DecimalValue = 0.0
        '        txtSaldoResponsableMe.DecimalValue = 0.0
        '    Next
        'Else
        '    listacajausuario = cajausuarioSA.ResumenTransaccionesXusuarioCaja(New cajaUsuario With {.idcajaUsuario = objCajausuario.idcajaUsuario, .idPersona = txtNombreCaja.Tag})
        '    'If (Not IsNothing(listacajausuario)) Then
        '    '    montoMN = listacajausuario.Sum(Function(o) o.fondoMN) + listacajausuario.Sum(Function(o) o.ingresoAdicMN)
        '    '    montoME = listacajausuario.Sum(Function(o) o.fondoME) + listacajausuario.Sum(Function(o) o.ingresoAdicME)
        '    'End If
        '    Me.gridGroupingControl1.Table.Records.DeleteAll()
        '    For Each i In cajausuarioDetalleSA.ListaDetallePorCaja(objCajausuario.idcajaUsuario)
        '        ef = efSA.GetUbicar_estadosFinancierosPorID(i.idEntidad)

        '        Me.gridGroupingControl1.Table.AddNewRecord.SetCurrent()
        '        Me.gridGroupingControl1.Table.AddNewRecord.BeginEdit()
        '        Me.gridGroupingControl1.Table.CurrentRecord.SetValue("codigo", i.secuencia)
        '        Me.gridGroupingControl1.Table.CurrentRecord.SetValue("IdEntidad", i.idEntidad)
        '        Me.gridGroupingControl1.Table.CurrentRecord.SetValue("entidad", ef.descripcion)
        '        Me.gridGroupingControl1.Table.CurrentRecord.SetValue("moneda", IIf(ef.codigo = "1", "NACIONAL", "EXTRANJERA"))
        '        Me.gridGroupingControl1.Table.CurrentRecord.SetValue("tc", TmpTipoCambio)
        '        Me.gridGroupingControl1.Table.CurrentRecord.SetValue("importeMN", i.importeMN)
        '        Me.gridGroupingControl1.Table.CurrentRecord.SetValue("importeME", i.importeME)
        '        Me.gridGroupingControl1.Table.CurrentRecord.SetValue("montoMax", 0)
        '        Me.gridGroupingControl1.Table.AddNewRecord.EndEdit()
        '        txtSaldoResponsableMN.DecimalValue += i.importeMN
        '        txtSaldoResponsableMe.DecimalValue += i.importeME
        '    Next



        'End If
    End Sub
#End Region


End Class