Imports Helios.Planilla.Business.Entity
Imports Helios.Planilla.WCFService.ServiceAccess
Imports Helios.Planilla.General
Imports Helios.General
Imports Syncfusion.Calculate

Public Class frmRegistroAsistencia

#Region "Atributos"
    Public Property SelControlAsistenciaPersonal() As List(Of ControlAsistencia)
    Public Property SelPersonalHorarios As New List(Of PersonalHorarios)
    Private Property ControlAsistenciaSA As New ControlAsistenciaSA
    Protected Friend SelTipoPersona As String
    Private Property SelPersona As Personal
    Private Property PersonaSA As New PersonalSA
    Private Property personalCargosSA As New PersonalCargoSA
    Private Property PersonalHorariosSA As New PersonalHorariosSA
    Public Property selListaHorarios As List(Of PersonalHorarios)
    Public calcQuick As CalcQuick

    Public tardanza As TimeSpan
    Public Property TotalHorasLaboras As TimeSpan
    Public Property UltimoAcceso As ControlAsistencia
#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        SelControlAsistenciaPersonal = New List(Of ControlAsistencia)
        SelPersonalHorarios = New List(Of PersonalHorarios)
        ListView1.CheckBoxes = False
    End Sub
#End Region

#Region "Métodos"
    Private Sub CargarHorarioPersonal()
        If SelPersona IsNot Nothing Then
            SelPersonalHorarios = New List(Of PersonalHorarios)
            SelPersonalHorarios = PersonalHorariosSA.PersonalHorariosSelxCargo(New PersonalHorarios With {.IDPersonal = SelPersona.IDPersonal, .IDCargo = txtCargo.Tag})
            'Dim sa As New ControlDeAsistenciaSA
            'Dim lista = sa.ControlDeAsistenciaSelxIDPersonal(New ControlDeAsistencia With {.IDPersonal = txtTrabajador.Tag})
            'LoadControles(lista)
        End If
    End Sub

    Private Sub CargarControlAsistenciaPersonal()
        If SelPersona IsNot Nothing Then
            Dim lstComboAcceso As New List(Of TablaDetalle)
            SelControlAsistenciaPersonal = New List(Of ControlAsistencia)
            lstComboAcceso = New List(Of TablaDetalle)
            Dim sa As New ControlAsistenciaSA

            SelControlAsistenciaPersonal = sa.ControlAsistenciaSelxIDPersonalFecha(New ControlAsistencia With {.IDPersonal = Val(txtTrabajador.Tag), .Fecha = DateTime.Now.Date})

            Dim tieneRefrigerio = SelPersonalHorarios.Where(Function(o) o.detalle = "REFRIGERIO SALIDA").FirstOrDefault


            If SelControlAsistenciaPersonal.Count > 0 Then
                'Validando combobox TipoAcceso control de asistencia
                UltimoAcceso = New ControlAsistencia
                UltimoAcceso = SelControlAsistenciaPersonal.Last()

                Select Case UltimoAcceso.TipoAcesso
                    Case "HI"
                        If tieneRefrigerio IsNot Nothing Then
                            lstComboAcceso.Add(New TablaDetalle With {.DescripcionCorta = "RE", .DescripcionLarga = "Refrigerio"})
                            PanelUltimoregistrohora.Visible = True
                            txtUltimoIngreso.Value = New DateTime(UltimoAcceso.Fecha.Value.Year, UltimoAcceso.Fecha.Value.Month, UltimoAcceso.Fecha.Value.Day,
                                                                   UltimoAcceso.Hora.Value.Hours, UltimoAcceso.Hora.Value.Minutes, UltimoAcceso.Hora.Value.Seconds)
                        Else
                            lstComboAcceso.Add(New TablaDetalle With {.DescripcionCorta = "HS", .DescripcionLarga = "Hora de Sálida"})
                            PanelUltimoregistrohora.Visible = True
                            txtUltimoIngreso.Value = New DateTime(UltimoAcceso.Fecha.Value.Year, UltimoAcceso.Fecha.Value.Month, UltimoAcceso.Fecha.Value.Day,
                                                                   UltimoAcceso.Hora.Value.Hours, UltimoAcceso.Hora.Value.Minutes, UltimoAcceso.Hora.Value.Seconds)
                        End If

                    Case "RE"
                        lstComboAcceso.Add(New TablaDetalle With {.DescripcionCorta = "RI", .DescripcionLarga = "Reingreso"})
                        PanelUltimoregistrohora.Visible = True
                        txtUltimoIngreso.Value = New DateTime(UltimoAcceso.Fecha.Value.Year, UltimoAcceso.Fecha.Value.Month, UltimoAcceso.Fecha.Value.Day,
                                                                   UltimoAcceso.Hora.Value.Hours, UltimoAcceso.Hora.Value.Minutes, UltimoAcceso.Hora.Value.Seconds)
                    Case "RI"
                        lstComboAcceso.Add(New TablaDetalle With {.DescripcionCorta = "HS", .DescripcionLarga = "Hora de Sálida"})
                        PanelUltimoregistrohora.Visible = True
                        txtUltimoIngreso.Value = New DateTime(UltimoAcceso.Fecha.Value.Year, UltimoAcceso.Fecha.Value.Month, UltimoAcceso.Fecha.Value.Day,
                                                                   UltimoAcceso.Hora.Value.Hours, UltimoAcceso.Hora.Value.Minutes, UltimoAcceso.Hora.Value.Seconds)
                    Case "HS"
                        MessageBox.Show("El usuario ya registro su asistencia para este día", "Día laborado", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                End Select

            Else
                lstComboAcceso.Add(New TablaDetalle With {.DescripcionCorta = "HI", .DescripcionLarga = "Hora de Ingreso"})

                CalculoHorario()

            End If

            If SelPersonalHorarios.Count > 0 Then
                cboAcceso.DataSource = lstComboAcceso
                cboAcceso.DisplayMember = "DescripcionLarga"
                cboAcceso.ValueMember = "DescripcionCorta"
            End If
        End If
    End Sub

    Private Sub CalculoHorario()
        Dim cargoHoraIngreso = selListaHorarios.Where(Function(o) o.IDCargo = txtCargo.Tag And o.detalle = "HORA DE INGRESO").Select(Function(o) o.HoraIngreso).FirstOrDefault
        Dim cargoHoraSalida = selListaHorarios.Where(Function(o) o.IDCargo = txtCargo.Tag And o.detalle = "HORA DE SALIDA").Select(Function(o) o.HoraIngreso).FirstOrDefault

        txthoraIngreso.Value = New DateTime(Date.Now.Year, Date.Now.Month, Date.Now.Day, cargoHoraIngreso.Value.Hours, cargoHoraIngreso.Value.Minutes, cargoHoraIngreso.Value.Seconds)
        txtHoraLlegada.Value = Date.Now
        TotalHorasLaboras = New TimeSpan
        TotalHorasLaboras = cargoHoraSalida - cargoHoraIngreso


        Dim horaIngreso = cargoHoraIngreso
        Dim horaLlegada = Date.Now.TimeOfDay
        tardanza = horaIngreso.GetValueOrDefault.Subtract(horaLlegada)
        ' Dim convertToDec As Decimal = Convert.ToDecimal(tardanza.Ticks)
        If tardanza.Hours < 0 Or tardanza.Minutes < 0 Or tardanza.Seconds < 0 Then
            tardanza = New TimeSpan(tardanza.Hours * -1, tardanza.Minutes * -1, tardanza.Seconds * -1)
        End If
        txtTotalMinTarde.Text = tardanza.ToString()
    End Sub

    Public Sub Grabar_Asistencia()
        Dim asistencia As New ControlAsistencia

        Dim tardanzasT As TimeSpan
        If cboAcceso.Text = "Hora de Ingreso" Then
            tardanzasT = TimeSpan.Parse(txtTotalMinTarde.Text)
        Else
            tardanzasT = New TimeSpan(0, 0, 0)
        End If

        asistencia = New ControlAsistencia With
            {
            .Action = BaseBE.EntityAction.INSERT,
            .IDPersonal = SelPersona.IDPersonal,
            .IDCargo = txtCargo.Tag,
            .TipoAcesso = cboAcceso.SelectedValue,
            .Fecha = Date.Now.Date,
            .Hora = Date.Now.TimeOfDay,
            .HoraPersonal = New TimeSpan(0, 0, 0),
            .HoraExtras = 0,
            .HorasFaltas = 0,
            .Tolerancia = New TimeSpan(0, 0, 0),
            .Penalidad = New TimeSpan(0, 0, 0),
            .Anotaciones = Nothing,
            .FaltaJustificada = Nothing,
            .Tardanza = tardanzasT,
            .FechaModificacion = Date.Now,
            .UsuarioModificacion = usuario.IDUsuario
        }

        Select Case cboAcceso.Text
            Case "Refrigerio", "Hora de Sálida"
                asistencia.PlanillaGeneral = CalculoPlanillaGeneral()
        End Select

        ControlAsistenciaSA.ControlAsistenciaSave(asistencia, UserManager.TransactionData)
        LimpiarTXT()
    End Sub

    Private Function CalculoConceptoValor(listaConceptos As List(Of PersonalConceptos)) As List(Of PlanillaGeneral)
        CalculoConceptoValor = New List(Of PlanillaGeneral)
        Dim personalConceptosSA As New PersonalConceptosSA
        Dim obj As PlanillaGeneral
        Dim ValorConcepto As Decimal = 0
        Dim ultimaHoraRegistrada = UltimoAcceso.Hora
        Dim horaActual = DateTime.Now.TimeOfDay

        Dim cargoHoraIngreso = selListaHorarios.Where(Function(o) o.IDCargo = txtCargo.Tag And o.detalle = "HORA DE INGRESO").Select(Function(o) o.HoraIngreso).FirstOrDefault
        Dim cargoHoraSalida = selListaHorarios.Where(Function(o) o.IDCargo = txtCargo.Tag And o.detalle = "HORA DE SALIDA").Select(Function(o) o.HoraIngreso).FirstOrDefault
        Dim HorasLaboralesGeneral = cargoHoraSalida - cargoHoraIngreso


        'valores Unicos
        Dim pagoDelDia As Decimal
        For Each i In listaConceptos.Where(Function(o) o.TipoCalculo = "02" And o.ValorCalculo > 0).ToList
            Dim formula = "=" & i.Formula
            calcQuick("result") = formula
            ValorConcepto = calcQuick("result")

            pagoDelDia = 0
            Select Case cboAcceso.Text
                Case "Refrigerio", "Hora de Sálida"
                    Dim ts As TimeSpan = horaActual.Subtract(ultimaHoraRegistrada)
                    Dim s = String.Concat(ts.Hours.ToString, ".", ts.Minutes.ToString)
                    Dim HourvalorDecimal As Decimal = s

                    Dim PagoXhora = Math.Round(ValorConcepto / HorasLaboralesGeneral.Value.Hours, 2)
                    Dim horasUsadas = horaActual.Subtract(ultimaHoraRegistrada) ' DateDiff(DateInterval.Hour, horaActual, ultimaHoraRegistrada)
                    pagoDelDia = PagoXhora * horasUsadas.TotalHours


                    obj = New PlanillaGeneral With {
                                            .IDPersonal = SelPersona.IDPersonal,
                                            .IDCargo = txtCargo.Tag,
                                            .TipoConcepto = i.IDSunat,
                                            .MesPlanilla = Date.Now.Date.Month,
                                            .AnioPlanilla = Date.Now.Date.Year,
                                            .FechaPlanilla = Date.Now,
                                            .TipoPlanilla = i.IDTipoPlanilla,
                                            .DescripcionCorta = i.DescripcionCorta,
                                            .DescripcionLarga = i.DescripcionLarga,
                                            .Importe = pagoDelDia,
                                            .Fechamodificacion = Date.Now,
                                            .UsuarioModificacion = usuario.IDUsuario
                                            }

                    CalculoConceptoValor.Add(obj)
                Case Else

            End Select
        Next
    End Function

    Private Function CalculoConceptoFormula(listaConceptos As List(Of PersonalConceptos)) As List(Of PlanillaGeneral)
        CalculoConceptoFormula = New List(Of PlanillaGeneral)
        Dim personalConceptosSA As New PersonalConceptosSA
        Dim obj As PlanillaGeneral
        Dim ValorConcepto As Decimal = 0
        Dim ultimaHoraRegistrada = UltimoAcceso.Hora
        Dim horaActual = DateTime.Now.TimeOfDay

        Dim cargoHoraIngreso = selListaHorarios.Where(Function(o) o.IDCargo = txtCargo.Tag And o.detalle = "HORA DE INGRESO").Select(Function(o) o.HoraIngreso).FirstOrDefault
        Dim cargoHoraSalida = selListaHorarios.Where(Function(o) o.IDCargo = txtCargo.Tag And o.detalle = "HORA DE SALIDA").Select(Function(o) o.HoraIngreso).FirstOrDefault
        Dim HorasLaboralesGeneral = cargoHoraSalida - cargoHoraIngreso


        'valores Unicos
        Dim pagoDelDia As Decimal
        For Each i In listaConceptos.Where(Function(o) o.TipoCalculo = "01").ToList
            Dim formula = "=" & i.Formula
            calcQuick("result") = formula
            ValorConcepto = calcQuick("result")

            If ValorConcepto <= 0 Then
                Throw New Exception("Revise los concepto configurados, los valores deben ser mayores a cero")
            End If

            pagoDelDia = 0
            Select Case cboAcceso.Text
                Case "Refrigerio", "Hora de Sálida"
                    Dim ts As TimeSpan = horaActual.Subtract(ultimaHoraRegistrada)
                    Dim s = String.Concat(ts.Hours.ToString, ".", ts.Minutes.ToString)
                    Dim HourvalorDecimal As Decimal = s

                    Dim PagoXhora = Math.Round(ValorConcepto / HorasLaboralesGeneral.Value.Hours, 2)
                    Dim horasUsadas = horaActual.Subtract(ultimaHoraRegistrada)
                    pagoDelDia = PagoXhora * horasUsadas.TotalHours


                    obj = New PlanillaGeneral With {
                                            .IDPersonal = SelPersona.IDPersonal,
                                            .IDCargo = txtCargo.Tag,
                                            .TipoConcepto = i.IDSunat,
                                            .MesPlanilla = Date.Now.Date.Month,
                                            .AnioPlanilla = Date.Now.Date.Year,
                                            .FechaPlanilla = Date.Now,
                                            .TipoPlanilla = i.IDTipoPlanilla,
                                            .DescripcionCorta = i.DescripcionCorta,
                                            .DescripcionLarga = i.DescripcionLarga,
                                            .Importe = pagoDelDia,
                                            .Fechamodificacion = Date.Now,
                                            .UsuarioModificacion = usuario.IDUsuario
                                            }

                    CalculoConceptoFormula.Add(obj)
                Case Else

            End Select
        Next
    End Function

    Private Function CalculoPlanillaGeneral() As List(Of PlanillaGeneral)
        CalculoPlanillaGeneral = New List(Of PlanillaGeneral)
        Dim personalConceptosSA As New PersonalConceptosSA
        'Dim obj As PlanillaGeneral
        Dim ValorConcepto As Decimal = 0

        'Dim cargoHoraIngreso = selListaHorarios.Where(Function(o) o.IDCargo = txtCargo.Tag And o.detalle = "HORA DE INGRESO").Select(Function(o) o.HoraIngreso).FirstOrDefault
        'Dim cargoHoraSalida = selListaHorarios.Where(Function(o) o.IDCargo = txtCargo.Tag And o.detalle = "HORA DE SALIDA").Select(Function(o) o.HoraIngreso).FirstOrDefault
        'Dim HorasLaboralesGeneral = cargoHoraSalida - cargoHoraIngreso


        Dim ultimaHoraRegistrada = UltimoAcceso.Hora
                Dim horaActual = DateTime.Now.TimeOfDay
                Dim listaConceptos = personalConceptosSA.PersonalConceptosSelxCargo(New PersonalConceptos With
                                                                                    {.IDPersonal = SelPersona.IDPersonal,
                                                                                    .IDCargo = txtCargo.Tag}).Where(Function(o) o.Activo = True).ToList
                calcQuick = New CalcQuick
                'Asignando formulas
                For Each i In listaConceptos
                    calcQuick(i.DescripcionCorta) = i.ValorCalculo.GetValueOrDefault
                Next

                'metodo calculo conceptos valor unico 
                CalculoPlanillaGeneral.AddRange(CalculoConceptoValor(listaConceptos))


                'metodo calculo concepto obtenidos x formula
                CalculoPlanillaGeneral.AddRange(CalculoConceptoFormula(listaConceptos))



        'valores Unicos
        ''''''''''Dim pagoDelDia As Decimal
        ''''''''''For Each i In listaConceptos.Where(Function(o) o.TipoCalculo = "02" And o.ValorCalculo > 0).ToList
        ''''''''''    Dim formula = "=" & i.Formula
        ''''''''''    calcQuick("result") = formula
        ''''''''''    ValorConcepto = calcQuick("result")

        ''''''''''    pagoDelDia = 0
        ''''''''''    Select Case cboAcceso.Text
        ''''''''''        Case "Refrigerio", "Hora de Sálida"
        ''''''''''            Dim ts As TimeSpan = horaActual.Subtract(ultimaHoraRegistrada)
        ''''''''''            Dim s = String.Concat(ts.Hours.ToString, ".", ts.Minutes.ToString)
        ''''''''''            Dim HourvalorDecimal As Decimal = s

        ''''''''''            Dim PagoXhora = Math.Round(ValorConcepto / HorasLaboralesGeneral.Value.Hours, 2)
        ''''''''''            Dim horasUsadas = DateDiff(DateInterval.Hour, horaActual, ultimaHoraRegistrada)
        ''''''''''            pagoDelDia = PagoXhora * horasUsadas


        ''''''''''            obj = New PlanillaGeneral With {
        ''''''''''                                    .IDPersonal = SelPersona.IDPersonal,
        ''''''''''                                    .IDCargo = txtCargo.Tag,
        ''''''''''                                    .TipoConcepto = i.IDSunat,
        ''''''''''                                    .MesPlanilla = Date.Now.Date.Month,
        ''''''''''                                    .AnioPlanilla = Date.Now.Date.Year,
        ''''''''''                                    .FechaPlanilla = Date.Now,
        ''''''''''                                    .TipoPlanilla = i.IDTipoPlanilla,
        ''''''''''                                    .DescripcionCorta = i.DescripcionCorta,
        ''''''''''                                    .DescripcionLarga = i.DescripcionLarga,
        ''''''''''                                    .Importe = pagoDelDia,
        ''''''''''                                    .Fechamodificacion = Date.Now,
        ''''''''''                                    .UsuarioModificacion = usuario.IDUsuario
        ''''''''''                                    }
        ''''''''''            CalculoPlanillaGeneral.Add(obj)
        ''''''''''        Case Else
        ''''''''''    End Select
        ''''''''''Next

        'Formulas
        '''''''''''''For Each i In listaConceptos.Where(Function(o) o.TipoCalculo = "01").ToList
        '''''''''''''    Dim formula = "=" & i.Formula
        '''''''''''''    calcQuick("result") = formula
        '''''''''''''    ValorConcepto = calcQuick("result")

        '''''''''''''    If ValorConcepto <= 0 Then
        '''''''''''''        Throw New Exception("Revise los concepto configurados, los valores deben ser mayores a cero")
        '''''''''''''    End If

        '''''''''''''    obj = New PlanillaGeneral With {
        '''''''''''''                                    .IDPersonal = SelPersona.IDPersonal,
        '''''''''''''                                    .IDCargo = txtCargo.Tag,
        '''''''''''''                                    .TipoConcepto = i.IDSunat,
        '''''''''''''                                    .MesPlanilla = Date.Now.Date.Month,
        '''''''''''''                                    .AnioPlanilla = Date.Now.Date.Year,
        '''''''''''''                                    .FechaPlanilla = Date.Now,
        '''''''''''''                                    .TipoPlanilla = i.IDTipoPlanilla,
        '''''''''''''                                    .DescripcionCorta = i.DescripcionCorta,
        '''''''''''''                                    .DescripcionLarga = i.DescripcionLarga,
        '''''''''''''                                    .Importe = ValorConcepto,
        '''''''''''''                                    .Fechamodificacion = Date.Now,
        '''''''''''''                                    .UsuarioModificacion = usuario.IDUsuario
        '''''''''''''                                    }
        '''''''''''''    CalculoPlanillaGeneral.Add(obj)
        '''''''''''''Next


    End Function

    Private Sub LimpiarTXT()
        cboAcceso.DataSource = New List(Of TablaDetalle)
        LimpiarCajas(GradientPanel3)
        ListView1.Items.Clear()
        txtCargo.Tag = Nothing
    End Sub

    'Public Sub Grabar_Asistencia()
    '    'Dim TotalHoras As TimeSpan
    '    Dim servicio As New ControlDeAsistenciaSA
    '    Dim objAsistencia As New ControlDeAsistencia

    '    objAsistencia = New ControlDeAsistencia
    '    objAsistencia.tipoPersona = SelTipoPersona
    '    'ControlAsistencia = New ControlAsistencia With {.Action = BaseBE.EntityAction.INSERT}
    '    objAsistencia.Action = BaseBE.EntityAction.INSERT
    '    objAsistencia.IDPersonal = Integer.Parse(txtTrabajador.Tag)
    '    objAsistencia.FechaAsistencia = Date.Now.Date
    '    objAsistencia.HoraIngreso = Date.Now.TimeOfDay

    '    objAsistencia.TipoAcesso = cboAcceso.SelectedValue
    '    objAsistencia.HorasTotales = New TimeSpan(0, 0, 0)

    '    Dim codAcceso = SelHorarioPersonal.Where(Function(o) o.TipoAcesso = cboAcceso.SelectedValue).FirstOrDefault

    '    If Not IsNothing(codAcceso) Then
    '        Dim tolerancia = codAcceso.Tolerancia

    '        If tolerancia < DateTime.Now.TimeOfDay Then
    '            Dim saldo = DateTime.Now.TimeOfDay.Subtract(tolerancia)
    '            objAsistencia.Tardanza = saldo
    '        Else
    '            objAsistencia.Tardanza = New TimeSpan(0, 0, 0) ' HoraCapturada
    '        End If

    '    Else

    '        objAsistencia.Tardanza = New TimeSpan(0, 0, 0) ' HoraCapturada
    '    End If

    '    'Select Case cboAcceso.SelectedValue
    '    '    Case "HI" 'Hora de Ingreso
    '    '        objAsistencia.HorasTotales = New TimeSpan(0, 0, 0)
    '    '    Case "HS" 'Hora de Salida  
    '    '        objAsistencia.HorasTotales = New TimeSpan(0, 0, 0)
    '    '    Case "RE" 'Refrigerio
    '    '        objAsistencia.HorasTotales = New TimeSpan(0, 0, 0)
    '    '    Case "RI" 'Reingreso
    '    '        objAsistencia.HorasTotales = New TimeSpan(0, 0, 0)
    '    'End Select

    '    objAsistencia.MesAsistencia = txtFecha.Value.Month
    '    objAsistencia.AñoAsistencia = txtFecha.Value.Year
    '    objAsistencia.DiaAsistencia = txtFecha.Value.Day
    '    objAsistencia.FechaModificacion = DateTime.Now
    '    objAsistencia.UsuarioModificacion = usuario.IDUsuario
    '    objAsistencia.status = 1
    '    'Dim ts As TimeSpan '= .Hora - .HoraPersonal
    '    'objAsistencia.HorasFaltas = ts.TotalHours


    '    servicio.ControlDeAsistenciaSave(objAsistencia, UserManager.TransactionData)
    '    MessageBox.Show("Asistencia registrada", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    'Dim listaAsistencia = servicio.ControlAsistenciaSelxIDPersonal(New ControlAsistencia With {.IDPersonal = txtCodigo.Text.Trim})
    '    'gridAsistencia.DataSource = listaAsistencia

    '    Close()
    'End Sub

    Private Sub LoadControles(be As List(Of ControlDeAsistencia))
        Dim coleccion As New List(Of String)
        Dim Listados As New TablaDetalleSA
        Dim lstTipoAcceso = Listados.TablaDetalleSelxTabla(New TablaDetalle With {.IDTabla = 1018})

        ' If be.Count = 0 Then
        cboAcceso.DataSource = lstTipoAcceso
        cboAcceso.ValueMember = "DescripcionCorta"
        cboAcceso.DisplayMember = "DescripcionLarga"
        'Else
        '    For Each i In be
        '        coleccion.Add(i.TipoAcesso)
        '    Next

        '    lstTipoAcceso = lstTipoAcceso.Where(Function(o) Not coleccion.Contains(o.DescripcionCorta)).ToList
        '    cboAcceso.DataSource = lstTipoAcceso
        '    cboAcceso.ValueMember = "DescripcionCorta"
        '    cboAcceso.DisplayMember = "DescripcionLarga"
        'End If
    End Sub

    Private Sub GetEntidadEncontrada(NroDocEntidad As String, tipo As String)
        Dim entidadSA As New Helios.Cont.WCFService.ServiceAccess.entidadSA

        Dim entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, tipo, NroDocEntidad)
        If entidad IsNot Nothing Then
            txtTrabajador.Text = entidad.nombreCompleto
            txtTrabajador.Tag = CInt(entidad.idEntidad)
            Select Case entidad.estado
                Case Tabla_SituacionTrabajador.BAJA
                 '   txtCargo.Text = "Activo"
                Case Tabla_SituacionTrabajador.ACTIVO_SUBSIDIADO
                  '  txtCargo.Text = "Activo"
                Case Tabla_SituacionTrabajador.SIN_VINC_LAB_POR_LIQUIDAR
                  '  txtCargo.Text = "Baja"
                Case Tabla_SituacionTrabajador.SUSPENSIÓN_PERFECTA_DE_LABORES
                    '   txtCargo.Text = "Baja"

            End Select
        End If
    End Sub

    Private Sub GetPersonaSelXDNI(Dni As Integer)
        '  Dim persona As New Personal
        'Dim servicio As New PersonalSA
        SelPersona = New Personal
        selListaHorarios = New List(Of PersonalHorarios)

        SelPersona = PersonaSA.PersonalSelxDNI(New Personal With {.Numerodocumento = Dni})

        If Not IsNothing(SelPersona) Then
            MappingPersonal()
            Dim cargos = personalCargosSA.PersonalCargoSel(New PersonalCargo With {.IDPersonal = SelPersona.IDPersonal})

            If cargos.Count = 1 Then
                Dim HoraIngreso As DateTime = DateTime.Now
                txtCargo.Text = cargos(0).DescripcionLarga
                txtCargo.Tag = cargos(0).IDCargo

                selListaHorarios = PersonalHorariosSA.PersonalHorariosSelxCargo(New PersonalHorarios With {.IDPersonal = SelPersona.IDPersonal, .IDCargo = txtCargo.Tag})

                If selListaHorarios.Count = 0 Then
                    MessageBox.Show("El cargo no tiene configurado los horarios de ingreso y sálida", "Validar horarios", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If


                Dim cargoHoraIngreso = selListaHorarios.Where(Function(o) o.IDCargo = cargos(0).IDCargo And o.detalle = "HORA DE INGRESO").Select(Function(o) o.HoraIngreso).FirstOrDefault
                Dim cargoHoraSalida = selListaHorarios.Where(Function(o) o.IDCargo = cargos(0).IDCargo And o.detalle = "HORA DE SALIDA").Select(Function(o) o.HoraIngreso).FirstOrDefault

                If IsInRange(New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, cargoHoraIngreso.Value.Hours, cargoHoraIngreso.Value.Minutes, cargoHoraIngreso.Value.Seconds),
                        New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, cargoHoraSalida.Value.Hours, cargoHoraSalida.Value.Minutes, cargoHoraSalida.Value.Seconds),
                        HoraIngreso) Then
                    LoadCargoRecuperado(cargos(0))
                Else
                    MessageBox.Show("No dispone de cargos en este horario del día", "Verificar horarios", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            ElseIf cargos.Count > 1 Then

                Dim HoraIngreso As DateTime = DateTime.Now

                For Each i In cargos
                    selListaHorarios = PersonalHorariosSA.PersonalHorariosSelxCargo(New PersonalHorarios With {.IDPersonal = SelPersona.IDPersonal, .IDCargo = i.IDCargo})

                    If selListaHorarios.Count = 0 Then
                        MessageBox.Show("El cargo no tiene configurado los horarios de ingreso y sálida", "Validar horarios", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If

                    Dim cargoHoraIngreso = selListaHorarios.Where(Function(o) o.IDCargo = i.IDCargo And o.detalle = "HORA DE INGRESO").Select(Function(o) o.HoraIngreso).FirstOrDefault
                    Dim cargoHoraSalida = selListaHorarios.Where(Function(o) o.IDCargo = i.IDCargo And o.detalle = "HORA DE SALIDA").Select(Function(o) o.HoraIngreso).FirstOrDefault

                    If IsInRange(New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, cargoHoraIngreso.Value.Hours, cargoHoraIngreso.Value.Minutes, cargoHoraIngreso.Value.Seconds),
                        New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, cargoHoraSalida.Value.Hours, cargoHoraSalida.Value.Minutes, cargoHoraSalida.Value.Seconds),
                        HoraIngreso) Then

                        'MessageBox.Show("Esta dentro del rango")
                        'Recuperar cargo dentro del rango del horario del personal

                        txtCargo.Text = i.DescripcionLarga
                        txtCargo.Tag = i.IDCargo
                        LoadCargoRecuperado(i)
                        Exit For
                    Else
                        '     MessageBox.Show("Esta fuera del rango")
                    End If
                Next
                'MessageBox.Show("No dispone de cargos en este horario del día", "Verificar horarios", MessageBoxButtons.OK, MessageBoxIcon.Error)


                'Dim f As New frmPersonalCargosAsistencia(cargos)
                'f.StartPosition = FormStartPosition.CenterParent
                'f.ShowDialog()
                'If f.Tag IsNot Nothing Then
                '    Dim c = CType(f.Tag, List(Of PersonalCargo))
                '    LoadCargos(c)
                'End If
            ElseIf cargos.Count = 0 Then
                MessageBox.Show("Debe configurar un cargo para este trabajador", "Asignar cargo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Else
            txtTrabajador.Clear()
            txtCargo.Clear()
            txtCodigoFiltrar.Select()
            MessageBox.Show("El dni ingresado no se encuentra en la base de registros", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub LoadCargos(listaCargos As List(Of PersonalCargo))
        Dim index = 0
        ListView1.Items.Clear()

        For Each i In listaCargos
            ListView1.Items.Add(i.DescripcionLarga).Tag = i.IDCargo 'Add Each Item Of Zodiac Array

            ListView1.Items(index).ImageIndex = 0 'Align ImageList Images With Array Items
            index = index + 1
        Next
    End Sub

    ''' <summary>
    ''' Llenar a listview cargo seleccionado
    ''' </summary>
    ''' <param name="i"></param>cargo recuperado
    Private Sub LoadCargoRecuperado(i As PersonalCargo)
        Dim index = 0
        ListView1.Items.Clear()
        ListView1.Items.Add(i.DescripcionLarga).Tag = i.IDCargo 'Add Each Item Of Zodiac Array
        ListView1.Items(index).ImageIndex = 0 'Align ImageList Images With Array Items
        index = index + 1
    End Sub

    Private Sub MappingPersonal()
        txtTrabajador.Text = SelPersona.FullName
        txtTrabajador.Tag = CInt(SelPersona.IDPersonal)

        Select Case SelPersona.Estado
            Case Tabla_SituacionTrabajador.BAJA
                 '   txtCargo.Text = "Activo"
            Case Tabla_SituacionTrabajador.ACTIVO_SUBSIDIADO
                  '  txtCargo.Text = "Activo"
            Case Tabla_SituacionTrabajador.SIN_VINC_LAB_POR_LIQUIDAR
                  '  txtCargo.Text = "Baja"
            Case Tabla_SituacionTrabajador.SUSPENSIÓN_PERFECTA_DE_LABORES
                '   txtCargo.Text = "Baja"

        End Select
    End Sub
#End Region

    Private Sub frmRegistroAsistencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtFecha.Value = DateTime.Now
        txtFecha.ReadOnly = False
    End Sub

    Private Sub GradientPanel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub txtCodigoFiltrar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigoFiltrar.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtCodigoFiltrar.Text.Trim.Length > 0 Then
                Try
                    txtHoraLlegada.Value = Date.Now
                    GetPersonaSelXDNI(txtCodigoFiltrar.Text.Trim)
                    CargarHorarioPersonal()
                    CargarControlAsistenciaPersonal()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                'Select Case SelTipoPersona
                '    Case TIPO_ENTIDAD.PROVEEDOR

                '    Case TIPO_ENTIDAD.CLIENTE
                '        Label3.Text = "Nombre del cliente"
                '        GetEntidadEncontrada(txtCodigoFiltrar.Text.Trim, TIPO_ENTIDAD.CLIENTE)
                '    Case "PL"
                '        Label3.Text = "Nombre del trabajador"

                'End Select

                'CargarHorarioPersonal()
                'CargarHorarios()
            End If
        End If
    End Sub

    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        Cursor = Cursors.WaitCursor
        Try
            If cboAcceso.Text.Trim.Length > 0 Then
                If txtTrabajador.Text.Trim.Length > 0 Then
                    Grabar_Asistencia()
                Else
                    MessageBox.Show("Debe identificar a un trabajador válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("No tiene acceso a este día", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub txtCodigoFiltrar_TextChanged(sender As Object, e As EventArgs) Handles txtCodigoFiltrar.TextChanged

    End Sub

    Private Sub Clock1_Click(sender As Object, e As EventArgs) Handles Clock1.Click

    End Sub
End Class