Imports System.IO
Imports System.Net
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports ProcesosGeneralesCajamiSoft
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class TabMG_Dashboard

    Private Property SelRazon As entidad
    Private Property entidadSA As New entidadSA

    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        FormatoGridBlack(gridServicios, True)
        FormatoGridBlack(gridHabitaciones, True)
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        CARGAR()
    End Sub

#Region "Metodos"

    Sub CARGAR()
        gridServicios.Table.Records.DeleteAll()

        Dim dt As New DataTable
        dt.Columns.Add("nro", GetType(Integer))
        dt.Columns.Add("descripcion", GetType(String))
        dt.Columns.Add("cantidad", GetType(Integer))
        dt.Columns.Add("ver", GetType(String))

        Dim dr As DataRow = dt.NewRow()
        dr(0) = 1
        dr(1) = "Pedidos pendientes x atender"
        dr(2) = 0
        dr(3) = ""
        dt.Rows.Add(dr)

        Dim dr1 As DataRow = dt.NewRow()
        dr1(0) = 2
        dr1(1) = "Control de servicios ofrecidos"
        dr1(2) = 0
        dr1(3) = ""
        dt.Rows.Add(dr1)

        Dim dr2 As DataRow = dt.NewRow()
        dr2(0) = 3
        dr2(1) = "Control de bienes en uso - (Entrega)"
        dr2(2) = 0
        dr2(3) = ""
        dt.Rows.Add(dr2)

        Dim DR3 As DataRow = dt.NewRow()
        DR3(0) = 4
        DR3(1) = "Control de bienes recepción - (Custodia"
        DR3(2) = 0
        DR3(3) = ""
        dt.Rows.Add(DR3)

        Dim DR4 As DataRow = dt.NewRow()
        DR4(0) = 5
        DR4(1) = "Proximo cumplimiento de atender"
        DR4(2) = 0
        DR4(3) = ""
        dt.Rows.Add(DR4)

        gridServicios.DataSource = dt
        gridServicios.TableOptions.ListBoxSelectionMode = SelectionMode.One


        '//HABITACIONES

        gridHabitaciones.Table.Records.DeleteAll()

        Dim dt2 As New DataTable
        dt2.Columns.Add("nro", GetType(Integer))
        dt2.Columns.Add("descripcion", GetType(String))
        dt2.Columns.Add("cantidad", GetType(Integer))
        dt2.Columns.Add("ver", GetType(String))

        Dim dr5 As DataRow = dt2.NewRow()
        dr5(0) = 1
        dr5(1) = "Habitaciones en uso"
        dr5(2) = 0
        dr5(3) = ""
        dt2.Rows.Add(dr5)

        Dim dr6 As DataRow = dt2.NewRow()
        dr6(0) = 2
        dr6(1) = "Habitaciones pendientes"
        dr6(2) = 0
        dr6(3) = ""
        dt2.Rows.Add(dr6)

        gridHabitaciones.DataSource = dt2
        gridHabitaciones.TableOptions.ListBoxSelectionMode = SelectionMode.One

    End Sub

    Private Function GetConsultarDNIReniec(Dni As String) As String
        Dim CLIENTE As New WebClient
        Dim PAGINA As Stream = CLIENTE.OpenRead("http://aplicaciones007.jne.gob.pe/srop_publico/Consulta/Afiliado/GetNombresCiudadano?DNI=" & Dni)
        Dim LECTOR As New StreamReader(PAGINA)
        Dim MIHTML As String = LECTOR.ReadToEnd
        ' Dim array = MIHTML.Split("|")

        Dim nombres = MIHTML.Replace("|", Space(1))
        Return Trim(nombres)
    End Function

    Private Sub GetConsultaSunatThread(ruc As String)
        SelRazon = New entidad
        Dim nroDoc = ruc.Substring(0, 1).ToString
        If nroDoc = "1" Then

            'getRuc donde ase llama como el company
            Dim sunat As New Helios.Consultas.Sunat.Sunat()
            sunat.GenerateCapchaTemporal()
            Dim valorCapcha = sunat.Decode_CapchaTemporal()
            Dim company As ProcesosJH.DatosRuc = ProcesosJH.ConsultarRUC(ruc, valorCapcha)

            'Dim datosSunat = New Helios.Sunat.Consulta.GetConsultaSunat()
            'Dim company = datosSunat.GetConsultaRuc(ruc)

            '  Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
            If company.Ruc IsNot Nothing Then
                If company.RazonSocial = "ERROR" Then

                Else
                    SelRazon.tipoPersona = "N"
                    SelRazon.tipoDoc = "6"
                    SelRazon.tipoEntidad = "PR"
                    SelRazon.nombreCompleto = company.RazonSocial
                    SelRazon.nombreContacto = company.RazonSocial
                    SelRazon.estado = company.Estado_Contribuyente
                    SelRazon.nrodoc = company.Ruc
                    SelRazon.direccion = company.DireccionDomicilioFiscal
                End If

            Else

            End If
        ElseIf nroDoc = "2" Then
            Dim sunat As New Helios.Consultas.Sunat.Sunat()
            sunat.GenerateCapchaTemporal()
            Dim valorCapcha = sunat.Decode_CapchaTemporal()
            Dim company As ProcesosJH.DatosRuc = ProcesosJH.ConsultarRUC(ruc, valorCapcha)

            'Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
            If company.Ruc IsNot Nothing Then
                'If company.ContribuyenteTipo = "SOCIEDAD ANONIMA CERRADA" Then
                If company.RazonSocial = "ERROR" Then

                Else
                    SelRazon.tipoPersona = "J"
                    SelRazon.tipoDoc = "6"
                    SelRazon.tipoEntidad = "PR"
                    SelRazon.nombreCompleto = company.RazonSocial
                    SelRazon.nombreContacto = company.RazonSocial
                    SelRazon.estado = company.Estado_Contribuyente
                    SelRazon.direccion = company.DireccionDomicilioFiscal
                    SelRazon.nrodoc = company.Ruc

                End If
            Else

            End If
        End If
    End Sub

    Private Sub GrabarEntidadRapidaThread()
        Dim obEntidad As New entidad
        Dim entidadSA As New entidadSA
        Try
            'Se asigna cada uno de los datos registrados
            obEntidad.idEmpresa = Gempresas.IdEmpresaRuc
            obEntidad.idOrganizacion = GEstableciento.IdEstablecimiento
            obEntidad.tipoEntidad = "CL"
            obEntidad.tipoDoc = SelRazon.tipoDoc
            obEntidad.tipoPersona = SelRazon.tipoPersona
            obEntidad.nrodoc = SelRazon.nrodoc
            obEntidad.nombreCompleto = SelRazon.nombreCompleto
            obEntidad.cuentaAsiento = "1213"
            obEntidad.direccion = SelRazon.direccion
            obEntidad.estado = StatusEntidad.Activo
            Dim codx As Integer = entidadSA.GrabarEntidad(obEntidad)

            TextProveedor.Tag = codx
            Dim entidad As New entidad
            entidad.idEntidad = codx
            entidad.nrodoc = TextNumIdentrazon.Text.Trim
            entidad.nombreCompleto = obEntidad.nombreCompleto
            entidad.tipoDoc = obEntidad.tipoDoc
            Me.Tag = entidad

        Catch ex As Exception
            MsgBox("No se pudo grabar el cliente." & vbCrLf & ex.Message, MsgBoxStyle.Critical)
            Me.Tag = Nothing
        End Try
    End Sub

    Private Sub GrabarEntidadRapida()
        Dim obEntidad As New entidad
        Dim entidadSA As New entidadSA
        Try
            'Se asigna cada uno de los datos registrados
            obEntidad.idEmpresa = Gempresas.IdEmpresaRuc
            obEntidad.idOrganizacion = GEstableciento.IdEstablecimiento
            obEntidad.tipoEntidad = "CL"
            obEntidad.tipoDoc = SelRazon.tipoDoc
            obEntidad.tipoPersona = SelRazon.tipoPersona
            obEntidad.nrodoc = SelRazon.nrodoc
            obEntidad.nombreCompleto = TextProveedor.Text.Trim
            obEntidad.cuentaAsiento = "1213"
            obEntidad.direccion = SelRazon.direccion
            obEntidad.estado = StatusEntidad.Activo
            Dim codx As Integer = entidadSA.GrabarEntidad(obEntidad)

            TextProveedor.Tag = codx
            Dim entidad As New entidad
            entidad.idEntidad = codx
            entidad.nrodoc = TextNumIdentrazon.Text.Trim
            entidad.nombreCompleto = obEntidad.nombreCompleto
            entidad.tipoDoc = obEntidad.tipoDoc
            Me.Tag = entidad

        Catch ex As Exception
            'Manejo de errores
            MsgBox("No se pudo grabar el cliente." & vbCrLf & ex.Message, MsgBoxStyle.Critical)
            Me.Tag = Nothing
        End Try
    End Sub

    Private Sub GrabarEnFormBasico()
        Dim f As New frmCrearENtidades
        f.strTipo = TIPO_ENTIDAD.CLIENTE
        f.CaptionLabels(0).Text = "Nuevo cliente"
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim ent = CType(f.Tag, entidad)
            TextNumIdentrazon.Text = ent.nrodoc
            TextProveedor.Text = ent.nombreCompleto
            TextProveedor.Tag = ent.idEntidad
        Else
            TextNumIdentrazon.Text = String.Empty
            TextProveedor.Text = String.Empty
            TextProveedor.Tag = Nothing
        End If
    End Sub

    Private Function GetValidarLocalDB(idEntidad As String) As Boolean
        GetValidarLocalDB = False
        Dim entidadSA As New entidadSA

        Dim entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", idEntidad)
        If entidad IsNot Nothing Then
            SelRazon = New entidad
            SelRazon = entidad
            TextProveedor.Text = entidad.nombreCompleto
            TextProveedor.Tag = entidad.idEntidad
            GetValidarLocalDB = True

            If TextProveedor.Text.Trim.Length > 0 Then
                'TextFiltrar.Select()
                'TextFiltrar.Focus()
            Else
                TextNumIdentrazon.Clear()
                TextNumIdentrazon.Select()
            End If
        End If
    End Function

    Private Async Sub GetConsultaSunatAsync(ruc As String)
        SelRazon = New entidad
        Dim nroDoc = ruc.Substring(0, 1).ToString
        If nroDoc = "1" Then
            Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
            If company IsNot Nothing Then
                ' If company.ContribuyenteTipo = "PERSONA NATURAL SIN NEGOCIO" Then
                SelRazon.tipoPersona = "N"
                SelRazon.tipoDoc = "6"
                ' End If
                SelRazon.tipoEntidad = "CL"
                SelRazon.nombreCompleto = company.RazonSocial
                TextProveedor.Text = company.RazonSocial
                SelRazon.nombreContacto = company.RazonSocial
                SelRazon.estado = company.ContribuyenteEstado
                SelRazon.nrodoc = company.Ruc
                SelRazon.direccion = company.DomicilioFiscal
                GrabarEntidadRapida()

            Else
                TextProveedor.Clear()

            End If
        ElseIf nroDoc = "2" Then
            Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
            If company IsNot Nothing Then
                'If company.ContribuyenteTipo = "SOCIEDAD ANONIMA CERRADA" Then
                SelRazon.tipoPersona = "J"
                SelRazon.tipoDoc = "6"
                '  End If
                SelRazon.nombreCompleto = company.RazonSocial
                SelRazon.nombreContacto = company.RazonSocial
                TextProveedor.Text = company.RazonSocial
                SelRazon.estado = company.ContribuyenteEstado
                SelRazon.direccion = company.DomicilioFiscal
                SelRazon.nrodoc = company.Ruc

                GrabarEntidadRapida()

            Else
                TextProveedor.Clear()

            End If
        End If
        TextNumIdentrazon.ReadOnly = False
    End Sub

    Private Function GetCodigoVendedor() As Helios.Seguridad.Business.Entity.Usuario
        GetCodigoVendedor = Nothing
        Dim f As New FormCodigoVendedor
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim c = CType(f.Tag, Helios.Seguridad.Business.Entity.Usuario)
            GetCodigoVendedor = c
        End If
    End Function

    Public Sub limpiarCajas()
        TextNumIdentrazon.Clear()
        TextProveedor.Clear()
    End Sub

    Private Sub TextNumIdentrazon_KeyDown(sender As Object, e As KeyEventArgs) Handles TextNumIdentrazon.KeyDown
        Dim nombres = String.Empty
        Try
            'TextNumIdentrazon.Enabled = False
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True

                Select Case TextNumIdentrazon.Text.Trim.Length
                    Case 8 'dni

                        SelRazon = New entidad

                        If My.Computer.Network.IsAvailable = True Then

                            nombres = GetConsultarDNIReniec(TextNumIdentrazon.Text.Trim)

                            If nombres.Trim.Length > 0 Then

                                If nombres = "DNI no encontrado en Padrón Electoral" Then
                                    TextNumIdentrazon.Clear()
                                    TextProveedor.Text = String.Empty
                                    TextProveedor.Tag = Nothing
                                    Exit Sub
                                End If

                                SelRazon.tipoEntidad = "CL"
                                SelRazon.nombreCompleto = nombres
                                SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                                SelRazon.tipoDoc = "1"
                                SelRazon.tipoPersona = "N"
                                TextProveedor.Text = nombres

                                Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", TextNumIdentrazon.Text.Trim)

                                If existeEnDB Is Nothing Then
                                    TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    GrabarEntidadRapida()

                                Else
                                    TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    TextProveedor.Tag = existeEnDB.idEntidad

                                End If
                            Else
                                TextNumIdentrazon.Clear()
                                TextProveedor.Text = String.Empty
                                TextProveedor.Tag = Nothing
                            End If

                        Else

                            'CUANDO NO HAY CONEXION A INTERNET
                            Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", TextNumIdentrazon.Text.Trim)
                            If existeEnDB Is Nothing Then
                                SelRazon.tipoEntidad = "CL"
                                SelRazon.nombreCompleto = TextProveedor.Text.Trim
                                SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                                SelRazon.tipoDoc = "1"
                                SelRazon.tipoPersona = "N"
                                'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                'GrabarEntidadRapida()
                                GrabarEnFormBasico()

                            Else
                                TextProveedor.Text = existeEnDB.nombreCompleto
                                TextProveedor.Tag = existeEnDB.idEntidad
                                TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                            End If
                        End If



                    Case 11 'razonSocial

                        Dim objeto As Boolean = ValidationRUC(TextNumIdentrazon.Text.Trim)
                        If objeto = False Then

                            MessageBox.Show("Debe Ingresar un número correcto de ruc", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Cursor = Cursors.Default
                            TextProveedor.Clear()
                            Exit Sub
                        End If

                        If My.Computer.Network.IsAvailable = True Then
                            'VALIDAR SI EXISTE EN LA bd LOCAL PRIMERO 
                            If GetValidarLocalDB(TextNumIdentrazon.Text.Trim) = False Then
                                TextNumIdentrazon.ReadOnly = True


                            End If
                        Else
                            'SI NO HAY CONEXION A INTERNET
                            If GetValidarLocalDB(TextNumIdentrazon.Text.Trim) = False Then
                                Dim nroDoc = TextNumIdentrazon.Text.Trim.Substring(0, 1).ToString
                                If nroDoc = "1" Then
                                    'SelRazon.tipoEntidad = "CL"
                                    'SelRazon.nombreCompleto = TextEmpresaPasajero.Text.Trim
                                    'SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                                    'SelRazon.tipoDoc = "6"
                                    'SelRazon.tipoPersona = "N"
                                    'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    'GrabarEntidadRapida()
                                    GrabarEnFormBasico()

                                    If TextProveedor.Text.Trim.Length > 0 Then
                                        'TextFiltrar.Select()
                                        'TextFiltrar.Focus()
                                    Else
                                        TextNumIdentrazon.Clear()
                                        TextNumIdentrazon.Select()
                                    End If
                                ElseIf nroDoc = "2" Then
                                    'SelRazon.tipoEntidad = "CL"
                                    'SelRazon.nombreCompleto = TextEmpresaPasajero.Text.Trim
                                    'SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                                    'SelRazon.tipoDoc = "6"
                                    'SelRazon.tipoPersona = "J"
                                    'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    'GrabarEntidadRapida()
                                    GrabarEnFormBasico()

                                    If TextProveedor.Text.Trim.Length > 0 Then
                                        'TextFiltrar.Select()
                                        'TextFiltrar.Focus()
                                    Else
                                        TextNumIdentrazon.Clear()
                                        TextNumIdentrazon.Select()
                                    End If
                                End If
                            End If
                        End If

                    Case Else
                        TextProveedor.Text = String.Empty
                        TextNumIdentrazon.Text = String.Empty
                        MessageBox.Show("Ingrese un documento correcto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Select

            End If
            '    TextNumIdentrazon.Enabled = True

        Catch ew As WebException

            If ew.Status = WebExceptionStatus.ProtocolError Then

                Dim [error] As String = New System.IO.StreamReader(ew.Response.GetResponseStream()).ReadToEnd()
                MessageBox.Show("DNI no encontrado en el padron, verifique si es menor de edad")
                TextNumIdentrazon.Clear()
                TextNumIdentrazon.Select()
                TextNumIdentrazon.Focus()
                TextProveedor.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BgProveedor_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BgProveedor.DoWork
        GetConsultaSunatThread(TextNumIdentrazon.Text)
    End Sub

    Private Sub BgProveedor_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BgProveedor.RunWorkerCompleted
        If SelRazon.nrodoc IsNot Nothing Then
            SelRazon.tipoEntidad = "CL"
            SelRazon.nombreCompleto = SelRazon.nombreCompleto.ToString.Replace(Chr(34), "")
            GrabarEntidadRapidaThread()
            TextNumIdentrazon.Text = SelRazon.nrodoc
            TextProveedor.Text = SelRazon.nombreCompleto
            TextNumIdentrazon.ReadOnly = False
            SelRazon = New entidad

        Else
            TextProveedor.Clear()
            TextProveedor.Tag = Nothing
            TextNumIdentrazon.ReadOnly = False
            SelRazon = New entidad
            TextNumIdentrazon.Select()
        End If

    End Sub

    Private Sub ComboEstable_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboEstable.SelectionChangeCommitted
        Try
            Select Case ComboEstable.Text
                Case "GENERAL"
                    pnBusqueda.Visible = False
                    btnConfirmar.Visible = True
                Case "CLIENTE"
                    pnBusqueda.Visible = True
                    btnConfirmar.Visible = False
                Case "HUESPED"
                    pnBusqueda.Visible = True
                    btnConfirmar.Visible = False
                Case "TERCEROS"
                    pnBusqueda.Visible = True
                    btnConfirmar.Visible = False
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BtnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        Try
            Dim Resumen As New distribucionInfraestructuraSA
            Dim pendiente As Integer
            Dim habPendiente As Integer
            Dim HabUso As Integer

            'Dim CONSULTA = Resumen.GetDashboardDistribucion()

            'If (Not IsNothing(CONSULTA)) Then

            '    For Each ite In CONSULTA
            '        labelCtaXCobrar.Text = CDec(ite.ctaXCobrar)
            '        'HabUso = (ite.conteoHabDisponibles)
            '        'habPendiente = (ite.conteoHabPendientes)
            '        labelventaTotal.Text = (ite.importeVentaTotal)
            '        pendiente = (ite.conteoPedidoPendiente)
            '    Next

            'For Each xxx In gridServicios.Table.Records

            '        Select Case xxx.GetValue("nro")
            '            Case 1
            '                xxx.SetValue("cantidad", pendiente)
            '            Case 2
            '                xxx.SetValue("cantidad", 0)
            '            Case 3
            '                xxx.SetValue("cantidad", 0)
            '            Case 4
            '                xxx.SetValue("cantidad", 0)
            '            Case 5
            '                xxx.SetValue("cantidad", 0)
            '        End Select


            'Next

            '    For Each yy In gridHabitaciones.Table.Records
            '        Select Case yy.GetValue("nro")
            '            Case 1
            '                yy.SetValue("cantidad", HabUso)
            '            Case 2
            '                yy.SetValue("cantidad", habPendiente)
            '        End Select
            '    Next

            'End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            Select Case ComboEstable.Text
                Case "GENERAL"

                Case "CLIENTE"
                    Dim entidadsa As New entidadSA
                    Dim consulta = entidadsa.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", TextNumIdentrazon.Text)

                    If (Not IsNothing(consulta)) Then
                        TextProveedor.Tag = consulta.idEntidad
                        TextProveedor.Text = consulta.nombreCompleto

                        If (consulta.estado = "A") Then
                            labelEstado.Text = "ACTIVO"
                        Else
                            labelEstado.Text = "INACTIVO"
                        End If
                    End If

                        Case "HUESPED"
                    Dim personaBeneficioSA As New personaBeneficioSA
                    Dim consulta = personaBeneficioSA.UbicarHospedadoPorRucNro(Gempresas.IdEmpresaRuc, TextNumIdentrazon.Text)

                    If (Not IsNothing(consulta)) Then
                        TextProveedor.Tag = consulta.idPersonaBeneficio
                        TextProveedor.Text = consulta.nombrePersona
                        If (consulta.estado = "A") Then
                            labelEstado.Text = "ACTIVO"
                        Else
                            labelEstado.Text = "INACTIVO"
                        End If
                    End If

                Case "TERCEROS"
                    Dim entidadsa As New entidadSA
                    Dim consulta = entidadsa.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", TextNumIdentrazon.Text)

                    If (Not IsNothing(consulta)) Then
                        TextProveedor.Tag = consulta.idEntidad
                        TextProveedor.Text = consulta.nombreCompleto
                        If (consulta.estado = "A") Then
                            labelEstado.Text = "ACTIVO"
                        Else
                            labelEstado.Text = "INACTIVO"
                        End If
                    End If
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GridServicios_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles gridServicios.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 4 Then
                e.Inner.Style.Description = "Documentos"
                e.Inner.Style.TextColor = Color.Black
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
                                           New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
                    )
                '    e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
            End If
        End If
    End Sub

    Private Sub GridGroupingControl2_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles gridHabitaciones.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 4 Then
                e.Inner.Style.Description = "VER"
                e.Inner.Style.TextColor = Color.Black
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
                                           New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
                    )
                '    e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
            End If
        End If
    End Sub

    Private Sub GridHabitaciones_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles gridHabitaciones.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        Dim precioSA As New detalleitemequivalencia_preciosSA
        Dim moneda As String = ""
        Try
            If e.Inner.ColIndex = 4 Then
                If gridHabitaciones.Table.CurrentRecord IsNot Nothing Then

                    Dim idCliente = gridHabitaciones.TableModel(e.Inner.RowIndex, 1).CellValue
                    Dim terminos = gridHabitaciones.TableModel(e.Inner.RowIndex, 2).CellValue
                    'CuentasPorPagarSelCliente(moneda, idCliente, terminos)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub GridServicios_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles gridServicios.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        Dim precioSA As New detalleitemequivalencia_preciosSA
        Dim moneda As String = ""
        Try
            If e.Inner.ColIndex = 4 Then
                If gridServicios.Table.CurrentRecord IsNot Nothing Then

                    Dim idCliente = gridServicios.TableModel(e.Inner.RowIndex, 1).CellValue
                    Dim terminos = gridServicios.TableModel(e.Inner.RowIndex, 2).CellValue

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Try
            Dim f As New frmDashBoardDetalle("CC")
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LabelCtaXCobrar_Click(sender As Object, e As EventArgs) Handles labelCtaXCobrar.Click
        Try
            Dim f As New frmDashBoardDetalle("CC")
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LabelventaTotal_Click(sender As Object, e As EventArgs) Handles labelventaTotal.Click
        Try
            Dim f As New frmDashBoardDetalle("VT")
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Try
            Dim f As New frmDashBoardDetalle("VT")
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region


End Class
