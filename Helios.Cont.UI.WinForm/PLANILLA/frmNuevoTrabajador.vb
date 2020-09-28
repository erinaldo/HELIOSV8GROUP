Imports Helios.Planilla.WCFService.ServiceAccess
Imports Helios.Planilla.Business.Entity
Imports System.IO
Imports Helios.Cont.WCFService.ServiceAccess

Imports Helios.General
Imports Syncfusion.Windows.Forms.Tools

Public Class frmNuevoTrabajador

#Region "Attributes"
    Protected Friend TipoPersonaPlanilla As String
    Private hitinfo As ListViewHitTestInfo
    Private editbox As New DateTimePickerAdv
    Public Property EstablecimientoSA As New Helios.Cont.WCFService.ServiceAccess.establecimientoSA
    Public Property Action As Entity.EntityState
#End Region

#Region "Constructors"
    Public Sub New(tipoPersona As String, empresa As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        TipoPersonaPlanilla = tipoPersona
        LoadCombos()
        If tmpConfigInicio.proyecto = "S" Then
            GetProyectosGeneralesCMB()
        End If
        GetDGV()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        LoadCombos()
        If tmpConfigInicio IsNot Nothing Then
            If tmpConfigInicio.proyecto = "S" Then
                GetProyectosGeneralesCMB()
            End If
        End If
        GetDGV()
    End Sub

    Public Sub New(idPersonal As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        LoadCombos()
        UbicarPersonal(idPersonal)

    End Sub
#End Region

#Region "Proyectos"

    Public Sub GetDGV()
        Dim dt As New DataTable
        dt.Columns.Add("IDCosto")
        dt.Columns.Add("IDPersonal")
        dt.Columns.Add("IDCargo")

        dgvProyectos.DataSource = dt

    End Sub

    Sub ComboProcesos1(intIdCostoPadre As Integer)
        Dim costoSA As New recursoCostoSA
        ' ()
        cboEdt.DataSource = costoSA.GetProcesosByCosto(New Helios.Cont.Business.Entity.recursoCosto With {.idCosto = intIdCostoPadre})
        'cboProceso.DataSource = costoSA.GetActividadProcesoByProyecto(New recursoCosto With {.idCosto = intIdCostoPadre})
        cboEdt.ValueMember = "idCosto"
        cboEdt.DisplayMember = "nombreCosto"
    End Sub

    Sub GetEntregables(idSubproyecto As Integer)
        Dim costoSA As New recursoCostoSA
        Dim costo As New List(Of Helios.Cont.Business.Entity.recursoCosto)

        '     If Not IsNothing(cboSubProyecto.SelectedValue) Then

        costo = costoSA.GetOrdenesDeProduccionInfo(New Helios.Cont.Business.Entity.recursoCosto With {.idCosto = idSubproyecto, .status = StatusProductosTerminados.Pendiente})
        cboEntregable.DisplayMember = "nombreCosto"
        cboEntregable.ValueMember = "idCosto"
        cboEntregable.DataSource = costo
        '   End If
    End Sub

    Public Sub GetSubProyectos(idProyectoGeneral As Integer)
        Dim recursoSA As New recursoCostoSA
        Dim lista As New List(Of Helios.Cont.Business.Entity.recursoCosto)
        lista = recursoSA.GetListaProyectosBySubTipo(New Helios.Cont.Business.Entity.recursoCosto With {.tipo = "HC", .idpadre = idProyectoGeneral, .subtipo = "OP1", .status = StatusProductosTerminados.Pendiente})
        'lista = recursoSA.GetListaProtectosByProyGeneral(New recursoCosto With {.tipo = "HC", .idpadre = idProyectoGeneral})
        Dim query = lista.Where(Function(o) o.subtipo <> TipoCosto.HC_Mercaderia).ToList
        cboSubProyecto.DataSource = query
        cboSubProyecto.DisplayMember = "nombreCosto"
        cboSubProyecto.ValueMember = "idCosto"
    End Sub

    Private Sub GetProyectosGeneralesCMB()
        Dim costoSA As New recursoCostoSA
        cboProyectoGeneral.DisplayMember = "nombreCosto"
        cboProyectoGeneral.ValueMember = "idCosto"
        cboProyectoGeneral.DataSource = costoSA.GetListaRecursosXtipo(New Helios.Cont.Business.Entity.recursoCosto With {.tipo = "HC", .subtipo = "PY"})
    End Sub

#End Region

#Region "Métodos"
    Public Sub UbicarPersonal(idPersonal As Integer)
        Dim servicio As New PersonalSA
        Dim objPersonal As New Personal

        objPersonal = servicio.PersonalSelxID(New Personal With {.IDPersonal = idPersonal})

        If Not IsNothing(objPersonal) Then
            Tag = objPersonal.IDPersonal
            CBOTipoTRabajador.SelectedValue = Integer.Parse(objPersonal.TipoTrabajador)
            cboDocumento.SelectedValue = Integer.Parse(objPersonal.Tipodocumento)
            txtNumDoc.Text = objPersonal.Numerodocumento
            CBOSituacionTrabajador.SelectedValue = Integer.Parse(objPersonal.Situacion)
            txtAppat.Text = objPersonal.ApellidoPaterno
            txtApmat.Text = objPersonal.ApellidoMaterno
            txtNombres.Text = objPersonal.Nombre
            txtFechaNac.Value = objPersonal.FechaNacimiento
            cboPasiEmisorDoc.SelectedValue = Integer.Parse(objPersonal.paisEmisorComprobante)
            cboSexo.SelectedValue = Integer.Parse(objPersonal.Sexo)
            cboEstadoCivil.SelectedValue = Integer.Parse(objPersonal.Estadocivil)
            cboNacionalidad.SelectedValue = Integer.Parse(objPersonal.Nacionalidad)
            CheckBox1.Checked = objPersonal.AsignacionFamiliar

            cboCodigoLargaDistancia.SelectedValue = Integer.Parse(objPersonal.codigoLargaDistancia)
            txtNumTelefono.Text = objPersonal.Telefono
            txtCelular.Text = objPersonal.Celular
            txtCorreo.Text = objPersonal.Email
            txtPrimeraDir.Text = objPersonal.PrimeraDireccion
            cboRegimenLaboral.SelectedValue = Integer.Parse(objPersonal.regimenLaboral)
            cboCatOcupacional.SelectedValue = Integer.Parse(objPersonal.CategoriaOcupacional)
            cboTipoContrato.SelectedValue = Integer.Parse(objPersonal.tipoContrato)
            cboFormaPago.SelectedValue = Integer.Parse(objPersonal.FormadePago)
            cboPeriodicidadPago.SelectedValue = Integer.Parse(objPersonal.periodicidadpago)
            cboEstablecimiento.SelectedValue = Integer.Parse(objPersonal.idEstablecimiento)
            chJL_trabajomaximo.Checked = objPersonal.JornadaTrabajoMaximo
            chJL_atipica.Checked = objPersonal.JornadaTrabajoAtipica
            chJL_nocturno.Checked = objPersonal.JornadaTrabajoNocturno
            cboSituacionEspecial.SelectedValue = Integer.Parse(objPersonal.SituacionEspecial)
            If (objPersonal.Discapacidad = True) Then
                rbConDiscapacidad.Checked = True
            Else
                rbSinDiscapacidad.Checked = True
            End If

            If (objPersonal.Sindicalizado = True) Then
                rbSindicaSi.Checked = True
            Else
                rbSindicaNO.Checked = True
            End If

            'Seguridad Social ----------------------------------------------
            cboRegimenSalud.SelectedValue = Integer.Parse(objPersonal.RegimenSalud)
            txtinicioSalud.Value = objPersonal.RegimenSalud_Inicio
            txtfinSalud.Value = objPersonal.RegimenSalud_Fin
            cboRegimenPensionario.SelectedValue = Integer.Parse(objPersonal.RegimenPension)

            txtInicioRegPensionario.Value = objPersonal.InicioPension
            txtFinRegPensionario.Value = objPersonal.FinalizaPension

            If (objPersonal.SCRT = "S") Then
                CSTRSi.Checked = True
            Else
                CSTRNo.Checked = True
            End If

            If (objPersonal.CoberturaPension = "ONP") Then
                rbOnp.Checked = True
            Else
                rbPrivado.Checked = True
            End If

            If objPersonal.CoberturaSalud = "EsSalud" Then
                rbEsSalud.Checked = True
            Else
                rbEPS.Checked = True
            End If

            txtInicioCoberturaSalud.Value = objPersonal.CoberturaSaludInicio
            txtFinCoberturaSalud.Value = objPersonal.CoberturaSaludFinaliza

            'Datos de la situacion educativa
            '----------------------------------------------------------------
            cboNivelEduca.SelectedValue = Integer.Parse(objPersonal.NivelEducacion)

            'Datos tributarios
            '----------------------------------------------------------------
            If objPersonal.LIR = True Then
                rbLIR_si.Checked = True
            Else
                rbLIR_no.Checked = True
            End If

            If objPersonal.EvitaDobleImposicion = True Then
                rb_evitaDobleImp_SI.Checked = True
            Else
                rb_evitaDobleImp_NO.Checked = True
            End If
            'txtAppat.Text = objPersonal.ApellidoPaterno
            'txtApmat.Text = objPersonal.ApellidoMaterno
            'txtNombres.Text = objPersonal.Nombre
            'dfgdfg

            'cboDocumento.SelectedValue = CInt(objPersonal.Tipodocumento)
            'txtNumDoc.Text = objPersonal.Numerodocumento
            'cboEstadoCivil.SelectedValue = CInt(objPersonal.Estadocivil)
            'txtFechaNac.Value = objPersonal.FechaNacimiento
            'cboSexo.SelectedValue = CInt(objPersonal.Sexo)

            'cboTipoVia.SelectedValue = CInt(objPersonal.ViaTipo)
            'txtViaNro.Text = objPersonal.ViaNumero
            'txtViaDto.Text = objPersonal.ViaDpto
            'txtViaInt.Text = objPersonal.ViaInterior
            'txtViaMz.Text = objPersonal.ViaManzana
            'txtViaLt.Text = objPersonal.ViaLote
            'txtViaNombre.Text = objPersonal.ViaNombre

            'cboUrbanizacion.SelectedValue = CInt(objPersonal.Zonatipo)
            'txtNomZona.Text = objPersonal.Zonanombre
            'cboDepartamento.SelectedValue = CInt(objPersonal.Departamneto)
            'cboProvincia.SelectedValue = CInt(objPersonal.Provincia)
            'cboDistrito.SelectedValue = CInt(objPersonal.Distrito)
            'cboNacionalidad.SelectedValue = CInt(objPersonal.Nacionalidad)
            'txtReferencia.Text = objPersonal.Referencia

            'cboCondicion.SelectedValue = CInt(objPersonal.CondicionDomiciliado)
            'txtNumTelefono.Text = objPersonal.Telefono
            'txtCelular.Text = objPersonal.Celular
            'txtCorreo.Text = objPersonal.Email
        Else
                MessageBox.Show("El personal solicitado no existe")
        End If
    End Sub

    Public Sub Grabar()
        Dim servicio As New PersonalSA
        Dim objPersonal As New Personal
        Dim personalProyecto As PersonalProyecto
        Dim listadoProyecto As List(Of PersonalProyecto)
        Dim fechaNull As Nullable(Of DateTime) = Nothing

        objPersonal = New Personal
        With objPersonal
            .Action = BaseBE.EntityAction.INSERT
            .Estado = "1"
            .IDPersonal = 0 ' txtCodigo.Text.Trim
            '**********************************************
            'PAGINA 1
            .TipoTrabajador = CBOTipoTRabajador.SelectedValue
            .Tipodocumento = cboDocumento.SelectedValue
            .Numerodocumento = txtNumDoc.Text.Trim
            .Situacion = CBOSituacionTrabajador.SelectedValue
            .ApellidoPaterno = txtAppat.Text.Trim
            .ApellidoMaterno = txtApmat.Text
            .Nombre = txtNombres.Text
            .FechaNacimiento = txtFechaNac.Value
            .paisEmisorComprobante = cboPasiEmisorDoc.SelectedValue
            .Sexo = cboSexo.SelectedValue
            .Estadocivil = cboEstadoCivil.SelectedValue
            .Nacionalidad = cboNacionalidad.SelectedValue
            .AsignacionFamiliar = CheckBox1.Checked
            .codigoLargaDistancia = cboCodigoLargaDistancia.SelectedValue
            .Telefono = txtNumTelefono.Text.Trim
            .Celular = txtCelular.Text.Trim
            .Email = txtCorreo.Text.Trim
            .PrimeraDireccion = txtPrimeraDir.Text.Trim
            .regimenLaboral = cboRegimenLaboral.SelectedValue
            .CategoriaOcupacional = cboCatOcupacional.SelectedValue
            .tipoContrato = cboTipoContrato.SelectedValue
            .FormadePago = cboFormaPago.SelectedValue
            .periodicidadpago = cboPeriodicidadPago.SelectedValue
            .idEstablecimiento = cboEstablecimiento.SelectedValue
            .JornadaTrabajoMaximo = chJL_trabajomaximo.Checked
            .JornadaTrabajoAtipica = chJL_atipica.Checked
            .JornadaTrabajoNocturno = chJL_nocturno.Checked
            .SituacionEspecial = cboSituacionEspecial.SelectedValue
            .Discapacidad = If(rbConDiscapacidad.Checked = True, True, False)
            .Sindicalizado = If(rbSindicaSi.Checked = True, True, False)

            'Seguridad Social ----------------------------------------------
            .RegimenSalud = cboRegimenSalud.SelectedValue
            .RegimenSalud_Inicio = txtinicioSalud.Value
            .RegimenSalud_Fin = txtfinSalud.Value
            .RegimenPension = cboRegimenPensionario.SelectedValue.ToString()
            .InicioPension = txtInicioRegPensionario.Value
            .FinalizaPension = txtFinRegPensionario.Value
            .SCRT = If(CSTRSi.Checked = True, "S", "N")
            .CoberturaPension = If(rbOnp.Checked = True, "ONP", "PRIVADO")
            .CoberturaSalud = If(rbEsSalud.Checked = True, "EsSalud", "EPS")
            .CoberturaSaludInicio = txtInicioCoberturaSalud.Value
            .CoberturaSaludFinaliza = txtFinCoberturaSalud.Value

            'Datos de la situacion educativa
            '----------------------------------------------------------------
            .NivelEducacion = cboNivelEduca.SelectedValue

            'Datos tributarios
            '----------------------------------------------------------------
            .LIR = If(rbLIR_si.Checked = True, True, False)
            .EvitaDobleImposicion = If(rb_evitaDobleImp_SI.Checked = True, True, False)



            'Zonificacion
            .ViaTipo = cboTipoVia.SelectedValue
            .ViaNumero = txtViaNro.Text.Trim
            .ViaDpto = txtViaDto.Text.Trim
            .ViaInterior = txtViaInt.Text.Trim
            .ViaManzana = txtViaMz.Text.Trim
            .ViaLote = txtViaLt.Text.Trim
            .ViaNombre = txtViaNombre.Text.Trim
            .Zonatipo = cboUrbanizacion.SelectedValue
            .Zonanombre = txtNomZona.Text.Trim
            .Departamneto = cboDepartamento.SelectedValue
            .Provincia = cboProvincia.SelectedValue
            .Distrito = cboDistrito.SelectedValue

            .Referencia = txtReferencia.Text.Trim
            .CondicionDomiciliado = cboCondicion.SelectedValue

            '.Fotografia = txtRutafoto.Text.Trim

            'PAGINA 2
            '.Area = cboArea.SelectedValue
            'If TipoPersonaPlanilla.ToString.Trim.Length > 0 Then
            '    .TipoTrabajador = TipoPersonaPlanilla
            'Else

            'End If



            'If IsDate(txtFechaIngreso.Text.Trim) = True Then
            '    .FechaIngreso = txtFechaIngreso.Text.Trim
            'End If
            'If IsDate(txtFechaCese.Text.Trim) = True Then
            '    .FechaCese = txtFechaCese.Text.Trim
            'End If



            '  .Estado = cboCatOcupacional.Text

            'If IsDate(txtInicioRegimen.Text.Trim) = True Then
            '    .InicioPension = txtInicioRegimen.Text.Trim
            'End If

            '.AsignacionFamiliar = chkAsignacionFamiliar.Text
            '.Banco = cboBancoRemuneracion.SelectedValue
            ' .BancoCuenta = txtBancoCuenta.Text.Trim
            '.CTS = cboBancoCTS.SelectedValue
            '.CTSCuenta = txtCTSCuenta.Text.Trim
            '********************************************
            '.Action = Personal.Action
        End With

        If tmpConfigInicio IsNot Nothing Then
            If tmpConfigInicio.proyecto = "S" Then
                listadoProyecto = New List(Of PersonalProyecto)
                For Each i In dgvProyectos.Table.Records
                    personalProyecto = New PersonalProyecto
                    personalProyecto.IDCosto = i.GetValue("IDCosto")
                    personalProyecto.IDCargo = i.GetValue("IDCargo")
                    personalProyecto.IDPersonal = 0
                    listadoProyecto.Add(personalProyecto)
                Next

                objPersonal.PersonalProyecto = listadoProyecto
            End If
        End If


        'For Each l As ListViewItem In lsvHorarios.Items
        '    'LUNES
        '    objPersonal.PersonalHorarios.Add(New PersonalHorarios With
        '                                     {
        '                                     .detalle = l.SubItems(0).Text,
        '                                     .DiaNumero = 1,
        '                                     .DiaSemana = "LUNES",
        '                                     .HoraIngreso = TimeSpan.Parse(l.SubItems(1).Text)
        '                                     })
        '    'MARTES
        '    objPersonal.PersonalHorarios.Add(New PersonalHorarios With
        '                                    {
        '                                    .detalle = l.SubItems(0).Text,
        '                                    .DiaNumero = 2,
        '                                    .DiaSemana = "MARTES",
        '                                    .HoraIngreso = TimeSpan.Parse(l.SubItems(2).Text)
        '                                    })
        '    'MIERCOLES
        '    objPersonal.PersonalHorarios.Add(New PersonalHorarios With
        '                                    {
        '                                    .detalle = l.SubItems(0).Text,
        '                                    .DiaNumero = 3,
        '                                    .DiaSemana = "MIERCOLES",
        '                                    .HoraIngreso = TimeSpan.Parse(l.SubItems(3).Text)
        '                                    })
        '    'JUEVES
        '    objPersonal.PersonalHorarios.Add(New PersonalHorarios With
        '                                    {
        '                                    .detalle = l.SubItems(0).Text,
        '                                    .DiaNumero = 4,
        '                                    .DiaSemana = "JUEVES",
        '                                    .HoraIngreso = TimeSpan.Parse(l.SubItems(4).Text)
        '                                    })
        '    'VIERNES
        '    objPersonal.PersonalHorarios.Add(New PersonalHorarios With
        '                                    {
        '                                    .detalle = l.SubItems(0).Text,
        '                                    .DiaNumero = 5,
        '                                    .DiaSemana = "VIERNES",
        '                                    .HoraIngreso = TimeSpan.Parse(l.SubItems(5).Text)
        '                                    })
        '    'SABADO
        '    objPersonal.PersonalHorarios.Add(New PersonalHorarios With
        '                                    {
        '                                    .detalle = l.SubItems(0).Text,
        '                                    .DiaNumero = 6,
        '                                    .DiaSemana = "SABADO",
        '                                    .HoraIngreso = TimeSpan.Parse(l.SubItems(6).Text)
        '                                    })
        '    'DOMINGO
        '    objPersonal.PersonalHorarios.Add(New PersonalHorarios With
        '                                    {
        '                                    .detalle = l.SubItems(0).Text,
        '                                    .DiaNumero = 7,
        '                                    .DiaSemana = "DOMINGO",
        '                                    .HoraIngreso = TimeSpan.Parse(l.SubItems(7).Text)
        '                                    })
        'Next
        servicio.PersonalSave(objPersonal, UserManager.TransactionData)
        'Dim TransactionLog As New TransactionDataBE With {.ComputerName = My.Computer.Name,.LocalDate = Date.Now,.LoggedUser = "Jack"}
        'servicio.PersonalSave(objPersonal, TransactionLog)
        MessageBox.Show("Persona registrada!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub

    Public Sub Editar()
        Dim servicio As New PersonalSA
        Dim objPersonal As New Personal
        Dim personalProyecto As PersonalProyecto
        Dim listadoProyecto As List(Of PersonalProyecto)
        Dim fechaNull As Nullable(Of DateTime) = Nothing

        objPersonal = New Personal
        With objPersonal
            .Action = BaseBE.EntityAction.UPDATE
            .Estado = "1"
            .IDPersonal = Tag ' txtCodigo.Text.Trim
            '**********************************************
            'PAGINA 1
            .TipoTrabajador = CBOTipoTRabajador.SelectedValue
            .Tipodocumento = cboDocumento.SelectedValue
            .Numerodocumento = txtNumDoc.Text.Trim
            .Situacion = CBOSituacionTrabajador.SelectedValue
            .ApellidoPaterno = txtAppat.Text.Trim
            .ApellidoMaterno = txtApmat.Text
            .Nombre = txtNombres.Text
            .FechaNacimiento = txtFechaNac.Value
            .paisEmisorComprobante = cboPasiEmisorDoc.SelectedValue
            .Sexo = cboSexo.SelectedValue
            .Estadocivil = cboEstadoCivil.SelectedValue
            .Nacionalidad = cboNacionalidad.SelectedValue
            .AsignacionFamiliar = CheckBox1.Checked
            .codigoLargaDistancia = cboCodigoLargaDistancia.SelectedValue
            .Telefono = txtNumTelefono.Text.Trim
            .Celular = txtCelular.Text.Trim
            .Email = txtCorreo.Text.Trim
            .PrimeraDireccion = txtPrimeraDir.Text.Trim
            .regimenLaboral = cboRegimenLaboral.SelectedValue
            .CategoriaOcupacional = cboCatOcupacional.SelectedValue
            .tipoContrato = cboTipoContrato.SelectedValue
            .FormadePago = cboFormaPago.SelectedValue
            .periodicidadpago = cboPeriodicidadPago.SelectedValue
            .idEstablecimiento = cboEstablecimiento.SelectedValue
            .JornadaTrabajoMaximo = chJL_trabajomaximo.Checked
            .JornadaTrabajoAtipica = chJL_atipica.Checked
            .JornadaTrabajoNocturno = chJL_nocturno.Checked
            .SituacionEspecial = cboSituacionEspecial.SelectedValue
            .Discapacidad = If(rbConDiscapacidad.Checked = True, True, False)
            .Sindicalizado = If(rbSindicaSi.Checked = True, True, False)

            'Seguridad Social ----------------------------------------------
            .RegimenSalud = cboRegimenSalud.SelectedValue
            .RegimenSalud_Inicio = txtinicioSalud.Value
            .RegimenSalud_Fin = txtfinSalud.Value
            .RegimenPension = cboRegimenPensionario.SelectedValue.ToString()
            .InicioPension = txtInicioRegPensionario.Value
            .FinalizaPension = txtFinRegPensionario.Value
            .SCRT = If(CSTRSi.Checked = True, "S", "N")
            .CoberturaPension = If(rbOnp.Checked = True, "ONP", "PRIVADO")
            .CoberturaSalud = If(rbEsSalud.Checked = True, "EsSalud", "EPS")
            .CoberturaSaludInicio = txtInicioCoberturaSalud.Value
            .CoberturaSaludFinaliza = txtFinCoberturaSalud.Value

            'Datos de la situacion educativa
            '----------------------------------------------------------------
            .NivelEducacion = cboNivelEduca.SelectedValue

            'Datos tributarios
            '----------------------------------------------------------------
            .LIR = If(rbLIR_si.Checked = True, True, False)
            .EvitaDobleImposicion = If(rb_evitaDobleImp_SI.Checked = True, True, False)



            'Zonificacion
            .ViaTipo = cboTipoVia.SelectedValue
            .ViaNumero = txtViaNro.Text.Trim
            .ViaDpto = txtViaDto.Text.Trim
            .ViaInterior = txtViaInt.Text.Trim
            .ViaManzana = txtViaMz.Text.Trim
            .ViaLote = txtViaLt.Text.Trim
            .ViaNombre = txtViaNombre.Text.Trim
            .Zonatipo = cboUrbanizacion.SelectedValue
            .Zonanombre = txtNomZona.Text.Trim
            .Departamneto = cboDepartamento.SelectedValue
            .Provincia = cboProvincia.SelectedValue
            .Distrito = cboDistrito.SelectedValue

            .Referencia = txtReferencia.Text.Trim
            .CondicionDomiciliado = cboCondicion.SelectedValue

            '.Fotografia = txtRutafoto.Text.Trim

            'PAGINA 2
            '.Area = cboArea.SelectedValue
            'If TipoPersonaPlanilla.ToString.Trim.Length > 0 Then
            '    .TipoTrabajador = TipoPersonaPlanilla
            'Else

            'End If



            'If IsDate(txtFechaIngreso.Text.Trim) = True Then
            '    .FechaIngreso = txtFechaIngreso.Text.Trim
            'End If
            'If IsDate(txtFechaCese.Text.Trim) = True Then
            '    .FechaCese = txtFechaCese.Text.Trim
            'End If



            '  .Estado = cboCatOcupacional.Text

            'If IsDate(txtInicioRegimen.Text.Trim) = True Then
            '    .InicioPension = txtInicioRegimen.Text.Trim
            'End If

            '.AsignacionFamiliar = chkAsignacionFamiliar.Text
            '.Banco = cboBancoRemuneracion.SelectedValue
            ' .BancoCuenta = txtBancoCuenta.Text.Trim
            '.CTS = cboBancoCTS.SelectedValue
            '.CTSCuenta = txtCTSCuenta.Text.Trim
            '********************************************
            '.Action = Personal.Action
        End With

        If tmpConfigInicio.proyecto = "S" Then
            listadoProyecto = New List(Of PersonalProyecto)
            For Each i In dgvProyectos.Table.Records
                personalProyecto = New PersonalProyecto
                personalProyecto.IDCosto = i.GetValue("IDCosto")
                personalProyecto.IDCargo = i.GetValue("IDCargo")
                personalProyecto.IDPersonal = 0
                listadoProyecto.Add(personalProyecto)
            Next

            objPersonal.PersonalProyecto = listadoProyecto
        End If

        'For Each l As ListViewItem In lsvHorarios.Items
        '    'LUNES
        '    objPersonal.PersonalHorarios.Add(New PersonalHorarios With
        '                                     {
        '                                     .detalle = l.SubItems(0).Text,
        '                                     .DiaNumero = 1,
        '                                     .DiaSemana = "LUNES",
        '                                     .HoraIngreso = TimeSpan.Parse(l.SubItems(1).Text)
        '                                     })
        '    'MARTES
        '    objPersonal.PersonalHorarios.Add(New PersonalHorarios With
        '                                    {
        '                                    .detalle = l.SubItems(0).Text,
        '                                    .DiaNumero = 2,
        '                                    .DiaSemana = "MARTES",
        '                                    .HoraIngreso = TimeSpan.Parse(l.SubItems(2).Text)
        '                                    })
        '    'MIERCOLES
        '    objPersonal.PersonalHorarios.Add(New PersonalHorarios With
        '                                    {
        '                                    .detalle = l.SubItems(0).Text,
        '                                    .DiaNumero = 3,
        '                                    .DiaSemana = "MIERCOLES",
        '                                    .HoraIngreso = TimeSpan.Parse(l.SubItems(3).Text)
        '                                    })
        '    'JUEVES
        '    objPersonal.PersonalHorarios.Add(New PersonalHorarios With
        '                                    {
        '                                    .detalle = l.SubItems(0).Text,
        '                                    .DiaNumero = 4,
        '                                    .DiaSemana = "JUEVES",
        '                                    .HoraIngreso = TimeSpan.Parse(l.SubItems(4).Text)
        '                                    })
        '    'VIERNES
        '    objPersonal.PersonalHorarios.Add(New PersonalHorarios With
        '                                    {
        '                                    .detalle = l.SubItems(0).Text,
        '                                    .DiaNumero = 5,
        '                                    .DiaSemana = "VIERNES",
        '                                    .HoraIngreso = TimeSpan.Parse(l.SubItems(5).Text)
        '                                    })
        '    'SABADO
        '    objPersonal.PersonalHorarios.Add(New PersonalHorarios With
        '                                    {
        '                                    .detalle = l.SubItems(0).Text,
        '                                    .DiaNumero = 6,
        '                                    .DiaSemana = "SABADO",
        '                                    .HoraIngreso = TimeSpan.Parse(l.SubItems(6).Text)
        '                                    })
        '    'DOMINGO
        '    objPersonal.PersonalHorarios.Add(New PersonalHorarios With
        '                                    {
        '                                    .detalle = l.SubItems(0).Text,
        '                                    .DiaNumero = 7,
        '                                    .DiaSemana = "DOMINGO",
        '                                    .HoraIngreso = TimeSpan.Parse(l.SubItems(7).Text)
        '                                    })
        'Next
        servicio.PersonalSave(objPersonal, UserManager.TransactionData)
        'Dim TransactionLog As New TransactionDataBE With {.ComputerName = My.Computer.Name,.LocalDate = Date.Now,.LoggedUser = "Jack"}
        'servicio.PersonalSave(objPersonal, TransactionLog)
        MessageBox.Show("Persona registrada!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub

    Public Sub LoadCombos()
        Dim tbl As New Helios.Planilla.Business.Entity.TablaDetalle
        Dim servicio As New PersonalSA
        Dim Listados As New Helios.Planilla.WCFService.ServiceAccess.TablaDetalleSA
        Dim AfpListados As New AFPSA


        Dim lstSexo = Listados.TablaDetalleSelxTabla(New Helios.Planilla.Business.Entity.TablaDetalle With {.IDTabla = 16})
        Dim lstEstadoCIvil = Listados.TablaDetalleSelxTabla(New Helios.Planilla.Business.Entity.TablaDetalle With {.IDTabla = 17})
        Dim lstNacionalidad = Listados.TablaDetalleSelxTabla(New Helios.Planilla.Business.Entity.TablaDetalle With {.IDTabla = 18})
        Dim lstCondicionDomiciliado = Listados.TablaDetalleSelxTabla(New Helios.Planilla.Business.Entity.TablaDetalle With {.IDTabla = 19})
        Dim lstDocumentos = Listados.TablaDetalleSelxTabla(New Helios.Planilla.Business.Entity.TablaDetalle With {.IDTabla = 4})
        Dim lstTipoVia = Listados.TablaDetalleSelxTabla(New Helios.Planilla.Business.Entity.TablaDetalle With {.IDTabla = 5})
        Dim lstRegimenPension = Listados.TablaDetalleSelxTabla(New Helios.Planilla.Business.Entity.TablaDetalle With {.IDTabla = 22})
        Dim lstNivelEduca = Listados.TablaDetalleSelxTabla(New Helios.Planilla.Business.Entity.TablaDetalle With {.IDTabla = 20})
        Dim lsvTipoTrabajador = Listados.TablaDetalleSelxTabla(New Helios.Planilla.Business.Entity.TablaDetalle With {.IDTabla = 21})
        Dim lstSituacionTrabajador = Listados.TablaDetalleSelxTabla(New Helios.Planilla.Business.Entity.TablaDetalle With {.IDTabla = 23})
        Dim lstFormaPago = Listados.TablaDetalleSelxTabla(New Helios.Planilla.Business.Entity.TablaDetalle With {.IDTabla = 24})

        'AGREGADOS
        Dim lstRegimenLaboral = Listados.TablaDetalleSelxTabla(New Helios.Planilla.Business.Entity.TablaDetalle With {.IDTabla = 1023})
        Dim lstTipoContrato = Listados.TablaDetalleSelxTabla(New Helios.Planilla.Business.Entity.TablaDetalle With {.IDTabla = 1024})
        Dim lstPeriodicidadPago = Listados.TablaDetalleSelxTabla(New Helios.Planilla.Business.Entity.TablaDetalle With {.IDTabla = 1025})
        Dim lstEstablecimientos = EstablecimientoSA.ObtenerListaEstablecimientos(Gempresas.IdEmpresaRuc)
        Dim lstSituacionEspecial = Listados.TablaDetalleSelxTabla(New Helios.Planilla.Business.Entity.TablaDetalle With {.IDTabla = 1026})
        Dim lstRegimenSalud = Listados.TablaDetalleSelxTabla(New Helios.Planilla.Business.Entity.TablaDetalle With {.IDTabla = 1027})
        Dim lstPaisEmisorDocumento = Listados.TablaDetalleSelxTabla(New Helios.Planilla.Business.Entity.TablaDetalle With {.IDTabla = 9})
        Dim lstCodigoLargaDistancia = Listados.TablaDetalleSelxTabla(New Helios.Planilla.Business.Entity.TablaDetalle With {.IDTabla = 15})
        Dim lstMotivoBaja = Listados.TablaDetalleSelxTabla(New Helios.Planilla.Business.Entity.TablaDetalle With {.IDTabla = 1028})
        '---------------------------------------------------------------------------------------------------------

        Dim lstCatOcupacional = Listados.TablaDetalleSelxTabla(New Helios.Planilla.Business.Entity.TablaDetalle With {.IDTabla = 25})
        Dim lstAFP = AfpListados.AFPSelAll(New Afp)
        Dim lstZona = Listados.TablaDetalleSelxTabla(New Helios.Planilla.Business.Entity.TablaDetalle With {.IDTabla = 6})

        Dim lstDepartamentos = Listados.TablaDetalleDepartamentos()

        cboMotivoBaja.DataSource = lstMotivoBaja
        cboMotivoBaja.ValueMember = "IDTablaDetalle"
        cboMotivoBaja.DisplayMember = "DescripcionCorta"

        cboCodigoLargaDistancia.DataSource = lstCodigoLargaDistancia
        cboCodigoLargaDistancia.ValueMember = "IDTablaDetalle"
        cboCodigoLargaDistancia.DisplayMember = "DescripcionLarga"


        cboPasiEmisorDoc.DataSource = lstPaisEmisorDocumento
        cboPasiEmisorDoc.ValueMember = "IDTablaDetalle"
        cboPasiEmisorDoc.DisplayMember = "DescripcionLarga"

        cboRegimenLaboral.DataSource = lstRegimenLaboral
        cboRegimenLaboral.ValueMember = "IDTablaDetalle"
        cboRegimenLaboral.DisplayMember = "DescripcionCorta"

        cboTipoContrato.DataSource = lstTipoContrato
        cboTipoContrato.ValueMember = "IDTablaDetalle"
        cboTipoContrato.DisplayMember = "DescripcionCorta"

        cboPeriodicidadPago.DataSource = lstPeriodicidadPago
        cboPeriodicidadPago.ValueMember = "IDTablaDetalle"
        cboPeriodicidadPago.DisplayMember = "DescripcionCorta"

        cboSituacionEspecial.DataSource = lstSituacionEspecial
        cboSituacionEspecial.ValueMember = "IDTablaDetalle"
        cboSituacionEspecial.DisplayMember = "DescripcionCorta"

        cboRegimenSalud.DataSource = lstRegimenSalud
        cboRegimenSalud.ValueMember = "IDTablaDetalle"
        cboRegimenSalud.DisplayMember = "DescripcionCorta"

        cboEstablecimiento.DataSource = lstEstablecimientos
        cboEstablecimiento.ValueMember = "idCentroCosto"
        cboEstablecimiento.DisplayMember = "nombre"
        cboEstablecimiento.SelectedValue = GEstableciento.IdEstablecimiento

        cboDepartamento.DataSource = lstDepartamentos
        cboDepartamento.ValueMember = "IDTablaDetalle"
        cboDepartamento.DisplayMember = "DescripcionLarga"

        cboCatOcupacional.DataSource = lstCatOcupacional
        cboCatOcupacional.ValueMember = "IDTablaDetalle"
        cboCatOcupacional.DisplayMember = "DescripcionLarga"

        cboFormaPago.DataSource = lstFormaPago
        cboFormaPago.ValueMember = "IDTablaDetalle"
        cboFormaPago.DisplayMember = "DescripcionLarga"

        CBOSituacionTrabajador.DataSource = lstSituacionTrabajador
        CBOSituacionTrabajador.ValueMember = "IDTablaDetalle"
        CBOSituacionTrabajador.DisplayMember = "DescripcionLarga"

        cboNivelEduca.DataSource = lstNivelEduca
        cboNivelEduca.ValueMember = "IDTablaDetalle"
        cboNivelEduca.DisplayMember = "DescripcionLarga"

        CBOTipoTRabajador.DataSource = lsvTipoTrabajador
        CBOTipoTRabajador.ValueMember = "IDTablaDetalle"
        CBOTipoTRabajador.DisplayMember = "DescripcionCorta"

        cboUrbanizacion.DataSource = lstZona
        cboUrbanizacion.ValueMember = "IDTablaDetalle"
        cboUrbanizacion.DisplayMember = "DescripcionLarga"

        cboCondicion.DataSource = lstCondicionDomiciliado
        cboCondicion.ValueMember = "IDTablaDetalle"
        cboCondicion.DisplayMember = "DescripcionLarga"

        cboSexo.DataSource = lstSexo
        cboSexo.ValueMember = "IDTablaDetalle"
        cboSexo.DisplayMember = "DescripcionLarga"

        cboEstadoCivil.DataSource = lstEstadoCIvil
        cboEstadoCivil.ValueMember = "IDTablaDetalle"
        cboEstadoCivil.DisplayMember = "DescripcionLarga"

        cboDocumento.DataSource = lstDocumentos
        cboDocumento.ValueMember = "IDTablaDetalle"
        cboDocumento.DisplayMember = "DescripcionCorta"
        cboDocumento.SelectedValue = 1

        cboTipoVia.DataSource = lstTipoVia
        cboTipoVia.ValueMember = "IDTablaDetalle"
        cboTipoVia.DisplayMember = "DescripcionLarga"

        cboNacionalidad.DataSource = lstNacionalidad
        cboNacionalidad.ValueMember = "IDTablaDetalle"
        cboNacionalidad.DisplayMember = "DescripcionLarga"

        cboRegimenPensionario.DataSource = lstRegimenPension
        cboRegimenPensionario.ValueMember = "IDTablaDetalle"
        cboRegimenPensionario.DisplayMember = "DescripcionLarga"

        'cboNombreAFP.DataSource = lstAFP
        'cboNombreAFP.ValueMember = "IDAFP"
        'cboNombreAFP.DisplayMember = "DescripcionLarga"

        'If tmpConfigInicio.proyecto = "S" Then
        '    '    CMBCargos()
        'End If
        ' CMBCargos()
    End Sub
#End Region

#Region "Events"

    Private Sub cboSubProyecto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSubProyecto.SelectedIndexChanged
        Dim costoSA As New recursoCostoSA
        cboEdt.DataSource = Nothing
        If cboSubProyecto.SelectedIndex > -1 Then
            '   If rbHojaCosto.Checked = True Then
            Dim recursoSA As New recursoCostoSA

            Dim codValue = cboSubProyecto.SelectedValue


            If IsNumeric(codValue) Then
                codValue = Val(codValue)

                GetEntregables(codValue)

                'ComboProcesos1(codValue)

                'End If
            End If
        End If
        cboEdt.SelectedIndex = -1
    End Sub

    Private Sub cboDepartamento_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboDepartamento.SelectedValueChanged
        Dim codDepa = cboDepartamento.SelectedValue
        If Not IsNothing(codDepa) Then
            If IsNumeric(codDepa) Then
                Dim Listados As New Helios.Planilla.WCFService.ServiceAccess.TablaDetalleSA
                Dim lstProvincia = Listados.TablaDetalleProvincia(New Helios.Planilla.Business.Entity.TablaDetalle With {.IDTablaDetalle = cboDepartamento.SelectedValue})
                cboProvincia.DataSource = lstProvincia
                cboProvincia.ValueMember = "IDTablaDetalle"
                cboProvincia.DisplayMember = "DescripcionLarga"
            End If
        End If
    End Sub

    Private Sub cboProvincia_Click(sender As Object, e As EventArgs) Handles cboProvincia.Click

    End Sub

    Private Sub cboProvincia_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboProvincia.SelectedValueChanged
        Dim codProv = cboProvincia.SelectedValue
        If Not IsNothing(codProv) Then
            If IsNumeric(codProv) Then
                Dim Listados As New Helios.Planilla.WCFService.ServiceAccess.TablaDetalleSA
                Dim lstDistrito = Listados.TablaDetalleDistrito(New Helios.Planilla.Business.Entity.TablaDetalle With {.IDTablaDetalle = cboProvincia.SelectedValue})
                cboDistrito.DataSource = lstDistrito
                cboDistrito.ValueMember = "IDTablaDetalle"
                cboDistrito.DisplayMember = "DescripcionLarga"
            End If
        End If
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        Try

            If Not txtAppat.Text.Trim.Length > 0 Then
                MessageBox.Show("Debe indicar el apellido paterno", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtAppat.Select()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            If Not txtApmat.Text.Trim.Length > 0 Then
                MessageBox.Show("Debe indicar el apellido materno", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtApmat.Select()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            If Not txtNombres.Text.Trim.Length > 0 Then
                MessageBox.Show("Debe indicar el nombre del trabajador", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtNombres.Select()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            If Not txtNumDoc.Text.Trim.Length > 0 Then
                MessageBox.Show("Debe indicar el número de documento de identificación.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtNumDoc.Select()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            'If Not lsvHorarios.Items.Count >= 2 Then
            '    MessageBox.Show("Debe ingresar el horario del trabajador", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    txtNumDoc.Select()
            '    Me.Cursor = Cursors.Default
            '    Exit Sub
            'End If
            If Action = Entity.EntityState.Modified Then
                Editar()
            Else
                Grabar()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub frmNuevoTrabajador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabPageAdv3.Parent = Nothing
        TabPageAdv4.Parent = Nothing
        'If tmpConfigInicio.proyecto = "S" Then
        '    TabPageAdv3.Parent = TabControlAdv1
        'Else
        '    TabPageAdv3.Parent = Nothing

        'End If
        'editbox.ShowDropButton = False
        'editbox.ShowUpDown = True
        'editbox.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        'editbox.ShowCheckBox = False
        'editbox.Format = DateTimePickerFormat.Custom
        'editbox.CustomFormat = "HH:mm:ss tt"
        'editbox.Parent = lsvHorarios
        'editbox.Hide()
        'AddHandler editbox.LostFocus, AddressOf txtFechaHorario_LostFocus
        'AddHandler editbox.KeyPress, AddressOf txtFechaHorario_KeyPress
        'lsvHorarios.FullRowSelect = True
    End Sub

    Private Sub TabPageAdv3_Click(sender As Object, e As EventArgs) Handles TabPageAdv3.Click

    End Sub

    Private Sub Label31_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GridGroupingControl2_TableControlCellClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles dgvProyectos.TableControlCellClick

    End Sub

    Private Sub Label33_Click(sender As Object, e As EventArgs) Handles Label33.Click

    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        Me.Cursor = Cursors.WaitCursor
        GetSubProyectos(cboProyectoGeneral.SelectedValue)
        cboSubProyecto.SelectedIndex = -1
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboEdt_Click(sender As Object, e As EventArgs) Handles cboEdt.Click

    End Sub

    Private Sub cboEntregable_Click(sender As Object, e As EventArgs) Handles cboEntregable.Click

    End Sub

    Private Sub cboEntregable_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEntregable.SelectedIndexChanged
        Cursor = Cursors.WaitCursor
        Dim codEntregable = cboEntregable.SelectedValue
        If Not IsNothing(codEntregable) Then
            If IsNumeric(codEntregable) Then
                ComboProcesos1(codEntregable)
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        dgvProyectos.Table.AddNewRecord.SetCurrent()
        dgvProyectos.Table.AddNewRecord.BeginEdit()
        dgvProyectos.Table.CurrentRecord.SetValue("IDCosto", cboEdt.SelectedValue)
        dgvProyectos.Table.CurrentRecord.SetValue("IDPersonal", 0)
        '    dgvProyectos.Table.CurrentRecord.SetValue("IDCargo", cboCargo.SelectedValue)
        dgvProyectos.Table.AddNewRecord.EndEdit()
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        Try
            If CheckBox2.Checked = True Then
                PanelDatos.Visible = True
                Me.Size = New Size(660, 644)
            Else
                PanelDatos.Visible = False
                Me.Size = New Size(660, 298)
            End If
            Dim boundWidth As Integer = Screen.PrimaryScreen.Bounds.Width
            Dim boundHeight As Integer = Screen.PrimaryScreen.Bounds.Height
            Dim x As Integer = boundWidth - Width
            Dim y As Integer = boundHeight - Height
            Location = New Point(x \ 2, y \ 2)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtFinCoberturaSalud_ValueChanged(sender As Object, e As EventArgs) Handles txtFinCoberturaSalud.ValueChanged

    End Sub
#End Region

End Class