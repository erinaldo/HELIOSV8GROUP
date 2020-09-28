Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Text.RegularExpressions
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports PopupControl
Imports ProcesosGeneralesCajamiSoft
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Bunifu.Framework.UI
Imports HtmlAgilityPack


Public Class FormVentaPasajes
    'Implements ICommitOperacionMKT

#Region "Attributes"
    Public Property ListaRutasActivas As List(Of rutas)
    Dim thread As System.Threading.Thread
    Public Property personaSA As New PersonaSA
    Friend Delegate Sub SetDataSourceDelegate(ByVal lista As List(Of Persona))
    Friend Delegate Sub SetDataSourceDelegateEntidad(ByVal lista As List(Of entidad))

    Public Property listaPersonas As List(Of Persona)
    Public Property listaServicios As List(Of ruta_HorarioServicios)
    Public Property entidadSA As New entidadSA
    Public Property listaClientes As List(Of entidad)

    Dim listaDistribucion As New List(Of distribucionInfraestructura)
    Dim tipoLista As String = "T"
    Private Property SelRazon As entidad

    Private Property tipoSeleccion As Boolean

    Public Property FormPurchase As FormControlTransportes

#End Region

#Region "Constructors"
    Public Sub New(formRepTransporte As FormControlTransportes)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormPurchase = formRepTransporte
    End Sub
#End Region

#Region "Methods"

    Public Sub LimpiarCajasTransporte()
        LabelAsientoSel.Tag = Nothing
        LabelAsientoSel.Text = "0"
        lblPrecioTotal.Tag = Nothing
        lblPrecioTotal.Text = "0.00"
        TextNumIdentrazon.Tag = Nothing
        TextNumIdentrazon.Clear()
        TextEmpresaPasajero.Tag = Nothing
        TextEmpresaPasajero.Clear()
        txtruc.Tag = Nothing
        txtruc.Clear()
        textPersona.Tag = Nothing
        textPersona.Clear()
        RBNatural.Checked = True
    End Sub


    Public Sub cargarBus(id As Integer, bus As String)
        txtNombreBus.Text = bus
        txtNombreBus.Tag = id
        lblPrecioTotal.Text = "0.00"
        LabelAsientoSel.Text = "0"
        LLAMARiNFRAESTRUCTURA(txtNombreBus.Tag)
    End Sub

    Public Sub LLAMARiNFRAESTRUCTURA(idActivo As Integer)
        Try



            Dim atributos As New FileAttributes
            Dim distribucionInfraestructuraSA As New distribucionInfraestructuraSA
            Dim distribucionInfraestructuraBE As New distribucionInfraestructura
            Dim conteo As Integer = 0
            Dim sumatoriaBoton As Integer = 1

            Dim estado As String = String.Empty
            estado = "U, A, L"



            distribucionInfraestructuraBE.tipo = "1"
            distribucionInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
            distribucionInfraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento
            distribucionInfraestructuraBE.tipo = "VPN"
            distribucionInfraestructuraBE.estado = "A"
            distribucionInfraestructuraBE.usuarioActualizacion = estado
            distribucionInfraestructuraBE.Categoria = 1
            distribucionInfraestructuraBE.SubCategoria = idActivo

            listaDistribucion = distribucionInfraestructuraSA.getInfraestructuraTransporte(distribucionInfraestructuraBE)


            DibujarControl(listaDistribucion)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub DibujarControl(listDistr As List(Of distribucionInfraestructura))
        '//IMAGNE 
        FlowNumero1.Controls.Clear()
        FlowNumero2.Controls.Clear()
        FlowNumero3.Controls.Clear()
        FlowNumero4.Controls.Clear()
        FlowPrimerPisoSector1.Controls.Clear()
        FlowPrimerPisoSector2.Controls.Clear()
        FlowPrimerPisoSector3.Controls.Clear()
        FlowPrimerPisoSector4.Controls.Clear()

        For Each items In listDistr

            Dim b As New RoundButton2

            b.Text = items.numeracion
            b.TextAlign = ContentAlignment.MiddleLeft
            b.TabIndex = 0
            b.FlatStyle = FlatStyle.Standard
            b.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            b.ForeColor = System.Drawing.Color.White
            b.Size = New System.Drawing.Size(45, 45)
            b.Font = New Font(" Arial Narrow", 10, FontStyle.Bold)
            b.Tag = items
            Select Case items.estado
                Case "A"
                    b.BackgroundImage = My.Resources.libreTrans
                Case "U"
                    b.BackgroundImage = My.Resources.usadoTrans
                    b.Enabled = False
                Case "L"
                    b.BackgroundImage = My.Resources.seleccioandoTrans
            End Select
            b.BackgroundImage.Tag = 1
            b.BackgroundImageLayout = ImageLayout.Zoom
            'b.Image = ImageList1.Images(0)
            'b.ImageAlign = ContentAlignment.MiddleCenter
            'b.TextImageRelation = TextImageRelation.ImageAboveText
            'b.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            b.UseVisualStyleBackColor = False

            Select Case items.NombreSector
                Case "SECTOR 1"
                    Select Case items.NombrePiso
                        Case "PISO 1"
                            FlowPrimerPisoSector1.Controls.Add(b)
                        Case "PISO 2"
                            FlowNumero1.Controls.Add(b)
                    End Select
                Case "SECTOR 2"
                    Select Case items.NombrePiso
                        Case "PISO 1"
                            FlowPrimerPisoSector2.Controls.Add(b)
                        Case "PISO 2"
                            FlowNumero2.Controls.Add(b)
                    End Select
                Case "SECTOR 3"
                    Select Case items.NombrePiso
                        Case "PISO 1"
                            FlowPrimerPisoSector3.Controls.Add(b)
                        Case "PISO 2"
                            FlowNumero3.Controls.Add(b)
                    End Select
                Case "SECTOR 4"
                    Select Case items.NombrePiso
                        Case "PISO 1"
                            FlowPrimerPisoSector4.Controls.Add(b)
                        Case "PISO 2"
                            FlowNumero4.Controls.Add(b)
                    End Select

            End Select

            AddHandler b.Click, AddressOf Butto1

        Next
    End Sub

    Private Sub Butto1(sender As Object, e As EventArgs)
        Dim productoBE As New documentoventaAbarrotes
        Dim distribucionInfraestructuraSA As New distribucionInfraestructuraSA
        Dim distribucionInfraestructuraBE As New distribucionInfraestructura

        Try

            Dim c = CType(sender.Tag, distribucionInfraestructura)
            Select Case tipoLista
                Case "T"

                    Dim documentoventaSA As New distribucionInfraestructuraSA
                    Dim documentoventaBE As New distribucionInfraestructura

                    distribucionInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
                    distribucionInfraestructuraBE.idDistribucion = c.idDistribucion
                    distribucionInfraestructuraBE.estado = "L"
                    'distribucionInfraestructuraBE.estadoAnterior = "L"

                    documentoventaSA.updateDistribucionTransportexID(distribucionInfraestructuraBE)

                    LLAMARiNFRAESTRUCTURA(txtNombreBus.Tag)

                    ''If sender.BackgroundImage Is My.Resources.libreTrans Then
                    'sender.BackgroundImage = My.Resources.seleccioandoTrans
                    tipoSeleccion = True
                    LabelAsientoSel.Text = c.numeracion
                    LabelAsientoSel.Tag = c.idDistribucion
                    lblPrecioTotal.Text = c.menor

                    ''ElseIf sender.BackgroundImage Is My.Resources.seleccioandoTrans Then
                    ''    sender.BackgroundImage = My.Resources.libreTrans
                    ''    sender.BackgroundImage.tag = False
                    ''    LabelAsientoSel.Text = "0"
                    ''    lblPrecioTotal.Text = "0.00"
                    ''End If


            End Select

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Public Sub getCargarCombos()
        Dim ActivosFijosSA As New ActivosFijosSA
        Dim activosFijosBE As New List(Of activosFijos)
        Dim NuevoActivo As New activosFijos

        NuevoActivo.idActivo = 0
        NuevoActivo.descripcionItem = "Elija una opción"

        activosFijosBE.Add(NuevoActivo)
        activosFijosBE.AddRange(ActivosFijosSA.GetListar_activosFijos())

        If NuevoActivo IsNot Nothing Then
            cboActivosFijos.DataSource = activosFijosBE
            cboActivosFijos.ValueMember = "idActivo"
            cboActivosFijos.DisplayMember = "descripcionItem"
            cboActivosFijos.ReadOnly = False
        End If
    End Sub

#Region "BUSQUEDA RUC"

    Private Function GetConsultarDNIReniec(Dni As String) As String
        Dim CLIENTE As New WebClient
        'Dim PAGINA As Stream = CLIENTE.OpenRead("http://aplicaciones007.jne.gob.pe/srop_publico/Consulta/Afiliado/GetNombresCiudadano?DNI=" & Dni)
        Dim PAGINA As Stream = CLIENTE.OpenRead("http://clientes.reniec.gob.pe/padronElectoral2012/consulta.htm?hTipo=2&hDni=" & Dni)
        Dim LECTOR As New StreamReader(PAGINA)
        Dim MIHTML As String = LECTOR.ReadToEnd
        Dim nombres = String.Empty
        ' Dim array = MIHTML.Split("|")
        Dim posicion = 0
        Dim doc As HtmlAgilityPack.HtmlDocument = New HtmlAgilityPack.HtmlDocument
        doc.LoadHtml(MIHTML)

        For Each node As HtmlTextNode In doc.DocumentNode.SelectNodes("//text()")
            Select Case posicion
                Case 36
                    nombres = node.Text
                    Exit For
                Case 42
                   ' TextDNI.Text = node.Text
                Case 60
                  '  TextProvincia.Text = node.Text
                Case 66
                 '   TextDepartamento.Text = node.Text
                Case 54
                    '   TextDistrito.Text = node.Text
            End Select
            posicion = posicion + 1
        Next


        '  nombres = MIHTML.Replace("|", Space(1))
        Return Trim(nombres)
    End Function

    Private Function GetValidarLocalDB(idEntidad As String) As Boolean
        GetValidarLocalDB = False
        Dim entidadSA As New entidadSA

        Dim entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", idEntidad)
        If entidad IsNot Nothing Then
            SelRazon = New entidad
            SelRazon = entidad
            TextEmpresaPasajero.Text = entidad.nombreCompleto

            TextEmpresaPasajero.Tag = entidad.idEntidad
            GetValidarLocalDB = True
            PictureLoad.Visible = False

            If TextEmpresaPasajero.Text.Trim.Length > 0 Then

            Else
                TextNumIdentrazon.Clear()
                TextNumIdentrazon.Select()
            End If
        End If
    End Function

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
            obEntidad.nombreCompleto = TextEmpresaPasajero.Text.Trim
            obEntidad.cuentaAsiento = "1213"
            obEntidad.direccion = SelRazon.direccion
            If SelRazon.direccion IsNot Nothing Then
                If SelRazon.direccion.Trim.Length > 0 Then
                    obEntidad.entidadAtributos = New List(Of entidadAtributos)
                    obEntidad.entidadAtributos.Add(New entidadAtributos With {
                                                   .Action = BaseBE.EntityAction.INSERT,
                                                   .tipo = "DOMICILIO",
                                                   .tipoVia = SelRazon.TipoVia,
                                                   .Via = SelRazon.Via,
                                                   .ubigeo = SelRazon.Ubigeo,
                                                   .estado = 1,
                                                   .valorAtributo = SelRazon.direccion,
                                                   .usuarioModificacion = usuario.IDUsuario,
                                                   .fechaModificacion = Date.Now
                                                   })
                End If
            End If
            obEntidad.estado = StatusEntidad.Activo
            Dim codx As Integer = entidadSA.GrabarEntidad(obEntidad)

            TextEmpresaPasajero.Tag = codx
            Dim entidad As New entidad
            entidad.idEntidad = codx
            entidad.nrodoc = TextNumIdentrazon.Text.Trim
            entidad.nombreCompleto = obEntidad.nombreCompleto
            entidad.tipoDoc = obEntidad.tipoDoc
            Me.Tag = entidad
            'If RadioButton2.Checked = True Then
            '    textPersona.Focus()
            '    textPersona.Select()
            'ElseIf RadioButton1.Checked = True Then
            '    txtruc.Focus()
            '    txtruc.Select()
            'End If
            'Transporte.ListaEmpresas.Add(entidad)

            '    Dispose()
        Catch ex As Exception
            'Manejo de errores
            MsgBox("No se pudo grabar el cliente." & vbCrLf & ex.Message, MsgBoxStyle.Critical)
            Me.Tag = Nothing
        End Try
    End Sub

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
                TextEmpresaPasajero.Text = company.RazonSocial
                SelRazon.nombreContacto = company.RazonSocial
                SelRazon.estado = company.ContribuyenteEstado
                SelRazon.nrodoc = company.Ruc
                SelRazon.direccion = company.DomicilioFiscal
                GrabarEntidadRapida()
                PictureLoad.Visible = False
            Else
                TextEmpresaPasajero.Clear()
                PictureLoad.Visible = False
            End If
        ElseIf nroDoc = "2" Then
            Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
            If company IsNot Nothing Then
                'If company.ContribuyenteTipo = "SOCIEDAD ANONIMA CERRADA" Then
                SelRazon.tipoPersona = "J"
                SelRazon.tipoDoc = "6"
                SelRazon.tipoEntidad = "CL"
                '  End If
                SelRazon.nombreCompleto = company.RazonSocial
                SelRazon.nombreContacto = company.RazonSocial
                TextEmpresaPasajero.Text = company.RazonSocial
                SelRazon.estado = company.ContribuyenteEstado
                SelRazon.direccion = company.DomicilioFiscal
                SelRazon.nrodoc = company.Ruc
                'If company.RepresentanteLegal IsNot Nothing Then
                '    If company.RepresentanteLegal.Dni41094462 IsNot Nothing Then
                '        With company.RepresentanteLegal.Dni41094462
                '            txtContacto.Text = String.Format("{0}/{1}/{2}", .Cargo, .Nombre, .Desde)
                '        End With
                '    End If
                'End If
                GrabarEntidadRapida()
                PictureLoad.Visible = False
            Else
                TextEmpresaPasajero.Clear()
                PictureLoad.Visible = False
            End If
        End If
        TextNumIdentrazon.ReadOnly = False
    End Sub

    Private Async Sub GetApiSunat(ByVal nroruc As String)
        SelRazon = New entidad()

        Using client = New HttpClient()

            If nroruc.ToString().Trim().Substring(0, 1) = "1" Then
                SelRazon.tipoPersona = "N"
            ElseIf nroruc.ToString().Trim().Substring(0, 1) = "2" Then
                SelRazon.tipoPersona = "J"
            End If

            'client.BaseAddress = New Uri("https://api.peruonline.cloud/v1/?ruc=10449245691")
            Dim responseTask = Await client.GetAsync("https://api.peruonline.cloud/v1/?ruc=" & nroruc)
            ' responseTask.Wait()
            'Dim result = responseTask.Result

            If responseTask.IsSuccessStatusCode Then
                Dim readTask = responseTask.Content.ReadAsAsync(Of SunatContribuyente)()
                readTask.Wait()
                Dim students = readTask.Result
                SelRazon.tipoDoc = "6"
                SelRazon.tipoEntidad = "CL"
                SelRazon.nombreCompleto = students.NombreORazonSocial
                SelRazon.nombreContacto = students.NombreORazonSocial
                TextEmpresaPasajero.Text = students.NombreORazonSocial
                'TextNumIdentrazon.Text = txtBuscador.Text
                SelRazon.estado = students.EstadoDelContribuyente
                SelRazon.nrodoc = students.Ruc
                SelRazon.direccion = students.Direccion

                SelRazon.TipoVia = students.TipoDeVia
                SelRazon.Via = students.NombreDeVia
                SelRazon.Ubigeo = students.Ubigeo

                GrabarEntidadRapida()
                PictureLoad.Visible = False
            Else
                GetConsultaSunatAsync(nroruc)

                'TextProveedor.Clear()
                'PictureLoad.Visible = False
            End If
            TextNumIdentrazon.ReadOnly = False
        End Using
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
            TextEmpresaPasajero.Text = ent.nombreCompleto
            TextEmpresaPasajero.Tag = ent.idEntidad
        Else
            TextNumIdentrazon.Text = String.Empty
            TextEmpresaPasajero.Text = String.Empty
            TextEmpresaPasajero.Tag = Nothing
        End If
    End Sub


    '/////////////// BUSQUEDA RUC PERSONA



    Private Function GetValidarLocalDB2(idEntidad As String) As Boolean
        GetValidarLocalDB2 = False
        Dim entidadSA As New entidadSA

        Dim entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", idEntidad)
        If entidad IsNot Nothing Then
            SelRazon = New entidad
            SelRazon = entidad
            textPersona.Text = entidad.nombreCompleto

            textPersona.Tag = entidad.idEntidad
            GetValidarLocalDB2 = True
            PictureLoad.Visible = False

            If textPersona.Text.Trim.Length > 0 Then

            Else
                txtruc.Clear()
                txtruc.Select()
            End If
        End If
    End Function

    Private Sub GrabarEntidadRapida2()
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
            obEntidad.nombreCompleto = textPersona.Text.Trim
            obEntidad.cuentaAsiento = "1213"
            obEntidad.direccion = SelRazon.direccion
            If SelRazon.direccion IsNot Nothing Then
                If SelRazon.direccion.Trim.Length > 0 Then
                    obEntidad.entidadAtributos = New List(Of entidadAtributos)
                    obEntidad.entidadAtributos.Add(New entidadAtributos With {
                                                   .Action = BaseBE.EntityAction.INSERT,
                                                   .tipo = "DOMICILIO",
                                                   .tipoVia = SelRazon.TipoVia,
                                                   .Via = SelRazon.Via,
                                                   .ubigeo = SelRazon.Ubigeo,
                                                   .estado = 1,
                                                   .valorAtributo = SelRazon.direccion,
                                                   .usuarioModificacion = usuario.IDUsuario,
                                                   .fechaModificacion = Date.Now
                                                   })
                End If
            End If
            obEntidad.estado = StatusEntidad.Activo
            Dim codx As Integer = entidadSA.GrabarEntidad(obEntidad)

            textPersona.Tag = codx
            Dim entidad As New entidad
            entidad.idEntidad = codx
            entidad.nrodoc = txtruc.Text.Trim
            entidad.nombreCompleto = obEntidad.nombreCompleto
            entidad.tipoDoc = obEntidad.tipoDoc
            Me.Tag = entidad
            'If RadioButton2.Checked = True Then
            '    textPersona.Focus()
            '    textPersona.Select()
            'ElseIf RadioButton1.Checked = True Then
            '    txtruc.Focus()
            '    txtruc.Select()
            'End If
            'Transporte.ListaEmpresas.Add(entidad)

            '    Dispose()
        Catch ex As Exception
            'Manejo de errores
            MsgBox("No se pudo grabar el cliente." & vbCrLf & ex.Message, MsgBoxStyle.Critical)
            Me.Tag = Nothing
        End Try
    End Sub

    Private Async Sub GetConsultaSunatAsync2(ruc As String)
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
                textPersona.Text = company.RazonSocial
                SelRazon.nombreContacto = company.RazonSocial
                SelRazon.estado = company.ContribuyenteEstado
                SelRazon.nrodoc = company.Ruc
                SelRazon.direccion = company.DomicilioFiscal
                GrabarEntidadRapida()
                PictureLoad.Visible = False
            Else
                textPersona.Clear()
                PictureLoad.Visible = False
            End If
        ElseIf nroDoc = "2" Then
            Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
            If company IsNot Nothing Then
                'If company.ContribuyenteTipo = "SOCIEDAD ANONIMA CERRADA" Then
                SelRazon.tipoPersona = "J"
                SelRazon.tipoDoc = "6"
                SelRazon.tipoEntidad = "CL"
                '  End If
                SelRazon.nombreCompleto = company.RazonSocial
                SelRazon.nombreContacto = company.RazonSocial
                textPersona.Text = company.RazonSocial
                SelRazon.estado = company.ContribuyenteEstado
                SelRazon.direccion = company.DomicilioFiscal
                SelRazon.nrodoc = company.Ruc
                'If company.RepresentanteLegal IsNot Nothing Then
                '    If company.RepresentanteLegal.Dni41094462 IsNot Nothing Then
                '        With company.RepresentanteLegal.Dni41094462
                '            txtContacto.Text = String.Format("{0}/{1}/{2}", .Cargo, .Nombre, .Desde)
                '        End With
                '    End If
                'End If
                GrabarEntidadRapida()
                PictureLoad.Visible = False
            Else
                textPersona.Clear()
                PictureLoad.Visible = False
            End If
        End If
        txtruc.ReadOnly = False
    End Sub

    Private Async Sub GetApiSunat2(ByVal nroruc As String)
        SelRazon = New entidad()

        Using client = New HttpClient()

            If nroruc.ToString().Trim().Substring(0, 1) = "1" Then
                SelRazon.tipoPersona = "N"
            ElseIf nroruc.ToString().Trim().Substring(0, 1) = "2" Then
                SelRazon.tipoPersona = "J"
            End If

            'client.BaseAddress = New Uri("https://api.peruonline.cloud/v1/?ruc=10449245691")
            Dim responseTask = Await client.GetAsync("https://api.peruonline.cloud/v1/?ruc=" & nroruc)
            ' responseTask.Wait()
            'Dim result = responseTask.Result

            If responseTask.IsSuccessStatusCode Then
                Dim readTask = responseTask.Content.ReadAsAsync(Of SunatContribuyente)()
                readTask.Wait()
                Dim students = readTask.Result
                SelRazon.tipoDoc = "6"
                SelRazon.tipoEntidad = "CL"
                SelRazon.nombreCompleto = students.NombreORazonSocial
                SelRazon.nombreContacto = students.NombreORazonSocial
                textPersona.Text = students.NombreORazonSocial
                'TextNumIdentrazon.Text = txtBuscador.Text
                SelRazon.estado = students.EstadoDelContribuyente
                SelRazon.nrodoc = students.Ruc
                SelRazon.direccion = students.Direccion

                SelRazon.TipoVia = students.TipoDeVia
                SelRazon.Via = students.NombreDeVia
                SelRazon.Ubigeo = students.Ubigeo

                GrabarEntidadRapida()
                PictureLoad.Visible = False
            Else
                GetConsultaSunatAsync(nroruc)

                'TextProveedor.Clear()
                'PictureLoad.Visible = False
            End If
            txtruc.ReadOnly = False
        End Using
    End Sub

    Private Sub GrabarEnFormBasico2()
        Dim f As New frmCrearENtidades
        f.strTipo = TIPO_ENTIDAD.CLIENTE
        f.CaptionLabels(0).Text = "Nuevo cliente"
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim ent = CType(f.Tag, entidad)
            txtruc.Text = ent.nrodoc
            textPersona.Text = ent.nombreCompleto
            textPersona.Tag = ent.idEntidad
        Else
            txtruc.Text = String.Empty
            textPersona.Text = String.Empty
            textPersona.Tag = Nothing
        End If
    End Sub

#End Region

    Private Sub GetRutasPorDia()
        Dim status As String = String.Empty
        Dim rutaSA As New RutaProgramacionSalidasSA
        'ListProgamacion.Items.Clear()

        Dim lista = rutaSA.GetProgramacionPorFechaLaboral(New rutaProgramacionSalidas With
                                                          {
                                                          .fechaProgramacion = Date.Now ' TextFechaProgramada.Value
                                                          })


        For Each i In lista
            Select Case i.estado
                Case ProgramacionEstado.VehiculoAsignadoEnCurso
                    status = "En Curso"
                Case ProgramacionEstado.VehiculoAsignadoRutaCulminada
                    status = "Culminada"
                Case ProgramacionEstado.VentaCerrada
                    status = "Venta cerrada"
                Case ProgramacionEstado.VentaEnMostrador
                    status = "En mostrador"
                Case ProgramacionEstado.ZonaEmbarque
                    status = "Embarque"
            End Select

            Dim n As New ListViewItem(i.programacion_id)
            n.SubItems.Add(If(i.tipo = "I", "SALIDA", "VUELTA"))
            n.SubItems.Add(i.fechaProgramacion)
            n.SubItems.Add(i.fechaProgramacion.Value.ToShortTimeString)
            n.SubItems.Add(i.CustomRutas.CustomRuta_horarios.horario_id)
            n.SubItems.Add(i.ruta_id)
            n.SubItems.Add(i.CustomRutas.ciudadDestino)
            n.SubItems.Add(status)
            'ListProgamacion.Items.Add(n)
        Next
        'ListProgamacion.Refresh()

    End Sub

    Public Sub GetDocsVenta()
        cboTipoDoc.Items.Clear()
        cboTipoDoc.Items.Add("NOTA DE VENTA")
        'cboTipoDoc.Items.Add("BOLETA")
        'cboTipoDoc.Items.Add("FACTURA")
        cboTipoDoc.Items.Add("BOLETA ELECTRONICA")
        cboTipoDoc.Items.Add("FACTURA ELECTRONICA")

        cboTipoDoc.Text = "BOLETA ELECTRONICA"
    End Sub


    Public Sub GetRutasActivas()
        'Dim rutaSA As New RutaTareoAutoSA
        'Dim rutaSA As New RutasSA
        Dim rutaSA As New RutaProgramacionSalidasSA

        'ListaRutasActivas = rutaSA.GellAllRutas(New rutas With {.estado = 1})
        ListaRutasActivas = rutaSA.ProgramacionSelRutasActivas(New rutaProgramacionSalidas With {.estado = 1})
        'ComboRutasActivas.DataSource = ListaRutasActivas
        'ComboRutasActivas.DisplayMember = "GetNameLarge"
        'ComboRutasActivas.ValueMember = "ruta_id"
    End Sub


#End Region

#Region "Events"

#End Region



    Private Sub VDERToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'Select Case Tool4.Tag
        '    Case "D"
        GetventaPasaje("4")
        '    Case "V", "R"

        'End Select
    End Sub

    Private Sub GetventaPasaje(silla As String)
        LabelAsientoSel.Text = silla
    End Sub

    Private Sub textPersona_TextChanged(sender As Object, e As EventArgs) Handles textPersona.TextChanged
        'textPersona.ForeColor = Color.Black
        'textPersona.Tag = Nothing
        'If textPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
        '    txtruc.Visible = True
        'Else
        '    txtruc.Visible = False
        'End If
    End Sub


    Private Sub GetLimpiarControles()
        LabelfechaProg.Text = String.Empty
        LabelAsientoSel.Text = "0"
        'ComboServicio.SelectedIndex = -1
        'txtTotalPagar.DecimalValue = 0

    End Sub

    'Private Sub GetServiciosPasajes(ruta_id As Integer, horario_id As Integer)
    '    Dim rutaSA As New Ruta_HorarioServiciosSA
    '    ComboServicio.Enabled = True
    '    listaServicios = rutaSA.GetServiciosVentaTransporte(New ruta_HorarioServicios With {.ruta_id = ruta_id, .horario_id = horario_id})
    '    ComboServicio.DataSource = listaServicios
    '    ComboServicio.DisplayMember = "descripcionLarga"
    '    ComboServicio.ValueMember = "codigoServicio"
    'End Sub

    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles BtConfirmarVenta.Click
        Try
            If IsDate(LabelfechaProg.Text) Then
                If CInt(LabelAsientoSel.Text) > 0 Then
                    If textPersona.Text.Trim.Length > 0 Then

                        If RBJuridico.Checked = True Then
                            If TextEmpresaPasajero.ForeColor <> Color.FromKnownColor(KnownColor.HotTrack) Then
                                MessageBox.Show("Ingrese una empresa valida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                TextEmpresaPasajero.Select()
                                TextEmpresaPasajero.Focus()
                                Exit Sub
                            End If
                        End If


                        'If TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
                        If textPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then

                            Dim id_ruta = LabelRuta.Tag  ' Integer.Parse(ListProgamacion.SelectedItems(0).SubItems(5).Text)

                            Dim envio = GetMappingEnvio(id_ruta)
                            Dim f As New FormCrearVentaTransporte(envio, envio.tipoPersona, Nothing)
                            f.TextFechaProgramada.Value = CDate(LabelfechaProg.Text)
                            f.TextFechaProgramada.Tag = (LabelfechaProg.Tag)
                            f.TextFechaProgramada.Enabled = False
                            f.distribucionID = LabelAsientoSel.Tag
                            f.LabelAsientoSel.Tag = LabelAsientoSel.Tag
                            f.StartPosition = FormStartPosition.CenterParent
                            f.ShowDialog(Me)
                            LimpiarCajasTransporte()
                            LLAMARiNFRAESTRUCTURA(txtNombreBus.Tag)
                        Else
                            MessageBox.Show("Ingrese un pasajero valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            textPersona.Select()
                            textPersona.Focus()
                        End If
                        'Else
                        '    MessageBox.Show("Ingreser una empresa valida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        '    TextEmpresaPasajero.Select()
                        '    TextEmpresaPasajero.Focus()
                        'End If
                    Else
                        MessageBox.Show("Ingrese un pasajero valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("Debe indicar el asiento para seguir la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Indique una fecha programada", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Function GetMappingEnvio(id_ruta As Integer) As rutaTareoAutos
        Dim rutaSA As New RutasSA
        Dim persona As Persona = Nothing
        Dim razonSocialEmpresa As entidad = Nothing
        Dim rutaSel As rutas = Nothing
        Dim servicio As ruta_HorarioServicios = Nothing

        GetMappingEnvio = New rutaTareoAutos

        If RBJuridico.Checked = True Then
            GetMappingEnvio.tipoPersona = "J"
            persona = listaPersonas.Where(Function(o) o.codigo = CInt(textPersona.Tag)).SingleOrDefault
            razonSocialEmpresa = listaClientes.Where(Function(o) o.idEntidad = CInt(TextEmpresaPasajero.Tag)).SingleOrDefault
            rutaSel = rutaSA.RutaSelID(New rutas With {.ruta_id = id_ruta}) ' ListaRutasActivas.Where(Function(o) o.ruta_id = id_ruta).SingleOrDefault
            'servicio = listaServicios.Where(Function(o) o.codigoServicio = CodigoServicio).SingleOrDefault
        ElseIf RBNatural.Checked = True Then
            GetMappingEnvio.tipoPersona = "N"
            'persona = listaPersonas.Where(Function(o) o.codigo = CInt(textPersona.Tag)).SingleOrDefault

            persona = New Persona
            persona.idEmpresa = Gempresas.IdEmpresaRuc
            persona.idOrganizacion = GEstableciento.IdEstablecimiento
            persona.codigo = textPersona.Tag
            persona.idPersona = textPersona.Tag
            persona.tipoPersona = "N"
            persona.tipodoc = "1"
            persona.nombreCompleto = textPersona.Text

            'razonSocialEmpresa = listaClientes.Where(Function(o) o.idEntidad = CInt(TextEmpresaPasajero.Tag)).SingleOrDefault
            rutaSel = rutaSA.RutaSelID(New rutas With {.ruta_id = id_ruta}) 'ListaRutasActivas.Where(Function(o) o.ruta_id = id_ruta).SingleOrDefault
            'servicio = listaServicios.Where(Function(o) o.codigoServicio = CodigoServicio).SingleOrDefault
        End If


        Select Case cboTipoDoc.Text
            Case "BOLETA ELECTRONICA"
                GetMappingEnvio.TipoDocVenta = "03"
            Case "FACTURA ELECTRONICA"
                GetMappingEnvio.TipoDocVenta = "01"
            Case Else
                GetMappingEnvio.TipoDocVenta = "9901"
        End Select
        GetMappingEnvio.ImporteVenta = CDec(lblPrecioTotal.Text)
        GetMappingEnvio.Asiento = CInt(LabelAsientoSel.Text)
        GetMappingEnvio.customRuta = rutaSel ' Tareo.customRuta
        GetMappingEnvio.customruta_horarios = rutaSel.ruta_horarios.FirstOrDefault ' Tareo.customruta_horarios
        GetMappingEnvio.customRuta_HorarioServicios = servicio
        GetMappingEnvio.customPersona = persona
        GetMappingEnvio.customEntidad = razonSocialEmpresa
    End Function

    Private Sub RoundButton23_Click(sender As Object, e As EventArgs) Handles RoundButton26.Click
        GetLimpiarControles()
    End Sub

    Private Sub ComboServicio_SelectedValueChanged(sender As Object, e As EventArgs)
        'If IsNumeric(ComboServicio.SelectedValue) Then
        '    Dim serv = listaServicios.Where(Function(o) o.codigoServicio = ComboServicio.SelectedValue).SingleOrDefault
        '    txtTotalPagar.DecimalValue = serv.costoEstimado.GetValueOrDefault
        'End If
    End Sub


    Private Sub GetCerrarVentas(prog_id As Integer, estado As General.Transporte.ProgramacionEstado)
        Dim programacionSA As New RutaProgramacionSalidasSA
        Dim obj As New rutaProgramacionSalidas With
        {
        .programacion_id = prog_id,
        .estado = estado
        }
        programacionSA.UpdateEstadoProgramacion(obj)
        'If estado = ProgramacionEstado.VentaCerrada Then
        '    ListProgamacion.SelectedItems(0).Remove()
        'End If
        MessageBox.Show("Ruta enviada a zona de embarque!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'CerrarVenta()
    End Sub


    Private Sub TextEmpresaPasajero_TextChanged(sender As Object, e As EventArgs) Handles TextEmpresaPasajero.TextChanged
        TextEmpresaPasajero.ForeColor = Color.Black
        TextEmpresaPasajero.Tag = Nothing
        If TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            TextNumIdentrazon.Visible = True
        Else
            TextNumIdentrazon.Visible = False
        End If
    End Sub

    Private Sub RBNatural_CheckedChanged(sender As Object, e As EventArgs) Handles RBNatural.CheckedChanged
        If RBNatural.Checked = True Then
            GroupBoxPasajero.Enabled = True
            GroupBoxEmpresa.Enabled = False
        End If
    End Sub

    Private Sub RBJuridico_CheckedChanged(sender As Object, e As EventArgs) Handles RBJuridico.CheckedChanged
        If RBJuridico.Checked = True Then
            GroupBoxPasajero.Enabled = True
            GroupBoxEmpresa.Enabled = True

        End If
    End Sub

    Private Sub RoundButton28_Click(sender As Object, e As EventArgs)
        Cursor = Cursors.WaitCursor
        GetLimpiarControles()
        GetRutasPorDia()
        Cursor = Cursors.Default
    End Sub

    Private Sub CboActivosFijos_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboActivosFijos.SelectionChangeCommitted
        Try
            If (cboActivosFijos.Text <> "Elija una Opción") Then
                lblPrecioTotal.Text = "0.00"
                LabelAsientoSel.Text = "0"
                LLAMARiNFRAESTRUCTURA(cboActivosFijos.SelectedValue)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

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
                            PictureLoad.Visible = True
                            nombres = GetConsultarDNIReniec(TextNumIdentrazon.Text.Trim)

                            If nombres.Trim.Length > 0 Then

                                If nombres = "DNI no encontrado en Padrón Electoral" Then
                                    TextNumIdentrazon.Clear()
                                    TextEmpresaPasajero.Text = String.Empty
                                    TextEmpresaPasajero.Tag = Nothing
                                    PictureLoad.Visible = False
                                    Exit Sub
                                End If

                                SelRazon.tipoEntidad = "CL"
                                SelRazon.nombreCompleto = nombres
                                SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                                SelRazon.tipoDoc = "1"
                                SelRazon.tipoPersona = "N"
                                TextEmpresaPasajero.Text = nombres

                                Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", TextNumIdentrazon.Text.Trim)

                                If existeEnDB Is Nothing Then
                                    TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    GrabarEntidadRapida()
                                    PictureLoad.Visible = False
                                Else
                                    TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    TextEmpresaPasajero.Tag = existeEnDB.idEntidad
                                    'If RadioButton2.Checked = True Then
                                    'TextFiltrar.Focus()
                                    'TextFiltrar.Select()
                                    'ElseIf RadioButton1.Checked = True Then
                                    '    txtruc.Focus()
                                    '    txtruc.Select()
                                    'End If
                                End If
                            Else
                                TextNumIdentrazon.Clear()
                                TextEmpresaPasajero.Text = String.Empty
                                TextEmpresaPasajero.Tag = Nothing
                            End If
                            PictureLoad.Visible = False
                        Else

                            'CUANDO NO HAY CONEXION A INTERNET
                            Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", TextNumIdentrazon.Text.Trim)
                            If existeEnDB Is Nothing Then
                                SelRazon.tipoEntidad = "CL"
                                SelRazon.nombreCompleto = TextEmpresaPasajero.Text.Trim
                                SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                                SelRazon.tipoDoc = "1"
                                SelRazon.tipoPersona = "N"
                                'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                'GrabarEntidadRapida()
                                GrabarEnFormBasico()
                                PictureLoad.Visible = False
                            Else
                                TextEmpresaPasajero.Text = existeEnDB.nombreCompleto
                                TextEmpresaPasajero.Tag = existeEnDB.idEntidad
                                TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                'If RadioButton2.Checked = True Then
                                'TextFiltrar.Focus()
                                'TextFiltrar.Select()
                                'ElseIf RadioButton1.Checked = True Then
                                '    txtruc.Focus()
                                '    txtruc.Select()
                                'End If
                            End If
                        End If



                    Case 11 'razonSocial
                        PictureLoad.Visible = True
                        Dim objeto As Boolean = ValidationRUC(TextNumIdentrazon.Text.Trim)
                        If objeto = False Then
                            PictureLoad.Visible = False
                            MessageBox.Show("Debe Ingresar un número correcto de ruc", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Cursor = Cursors.Default
                            TextEmpresaPasajero.Clear()
                            Exit Sub
                        End If

                        If My.Computer.Network.IsAvailable = True Then
                            'VALIDAR SI EXISTE EN LA bd LOCAL PRIMERO 
                            If GetValidarLocalDB(TextNumIdentrazon.Text.Trim) = False Then
                                TextNumIdentrazon.ReadOnly = True

                                GetApiSunat(TextNumIdentrazon.Text.Trim)

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
                                    PictureLoad.Visible = False
                                    If TextEmpresaPasajero.Text.Trim.Length > 0 Then
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
                                    PictureLoad.Visible = False
                                    If TextEmpresaPasajero.Text.Trim.Length > 0 Then
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
                        TextEmpresaPasajero.Text = String.Empty
                        TextNumIdentrazon.Text = String.Empty
                        MessageBox.Show("Ingrese un documento correcto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Select

            End If
            '    TextNumIdentrazon.Enabled = True

        Catch ew As WebException

            If ew.Status = WebExceptionStatus.ProtocolError Then
                PictureLoad.Visible = False
                Dim [error] As String = New System.IO.StreamReader(ew.Response.GetResponseStream()).ReadToEnd()
                MessageBox.Show("DNI no encontrado en el padron, verifique si es menor de edad")
                TextNumIdentrazon.Clear()
                TextNumIdentrazon.Select()
                TextNumIdentrazon.Focus()
                TextEmpresaPasajero.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Txtruc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtruc.KeyDown
        Dim nombres = String.Empty
        Try
            'TextNumIdentrazon.Enabled = False
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True

                Select Case txtruc.Text.Trim.Length
                    Case 8 'dni

                        SelRazon = New entidad

                        If My.Computer.Network.IsAvailable = True Then
                            PictureLoad.Visible = True
                            nombres = GetConsultarDNIReniec(txtruc.Text.Trim)

                            If nombres.Trim.Length > 0 Then

                                If nombres = "DNI no encontrado en Padrón Electoral" Then
                                    txtruc.Clear()
                                    textPersona.Text = String.Empty
                                    textPersona.Tag = Nothing
                                    PictureLoad.Visible = False
                                    Exit Sub
                                End If

                                SelRazon.tipoEntidad = "CL"
                                SelRazon.nombreCompleto = nombres
                                SelRazon.nrodoc = txtruc.Text.Trim
                                SelRazon.tipoDoc = "1"
                                SelRazon.tipoPersona = "N"
                                textPersona.Text = nombres

                                Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", txtruc.Text.Trim)

                                If existeEnDB Is Nothing Then
                                    textPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    GrabarEntidadRapida2()
                                    PictureLoad.Visible = False
                                Else
                                    textPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    textPersona.Tag = existeEnDB.idEntidad
                                    'If RadioButton2.Checked = True Then
                                    'TextFiltrar.Focus()
                                    'TextFiltrar.Select()
                                    'ElseIf RadioButton1.Checked = True Then
                                    '    txtruc.Focus()
                                    '    txtruc.Select()
                                    'End If
                                End If
                            Else
                                txtruc.Clear()
                                textPersona.Text = String.Empty
                                textPersona.Tag = Nothing
                            End If
                            PictureLoad.Visible = False
                        Else

                            'CUANDO NO HAY CONEXION A INTERNET
                            Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", txtruc.Text.Trim)
                            If existeEnDB Is Nothing Then
                                SelRazon.tipoEntidad = "CL"
                                SelRazon.nombreCompleto = textPersona.Text.Trim
                                SelRazon.nrodoc = txtruc.Text.Trim
                                SelRazon.tipoDoc = "1"
                                SelRazon.tipoPersona = "N"
                                'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                'GrabarEntidadRapida()
                                GrabarEnFormBasico2()
                                PictureLoad.Visible = False
                            Else
                                textPersona.Text = existeEnDB.nombreCompleto
                                textPersona.Tag = existeEnDB.idEntidad
                                textPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                'If RadioButton2.Checked = True Then
                                'TextFiltrar.Focus()
                                'TextFiltrar.Select()
                                'ElseIf RadioButton1.Checked = True Then
                                '    txtruc.Focus()
                                '    txtruc.Select()
                                'End If
                            End If
                        End If



                    Case 11 'razonSocial
                        PictureLoad.Visible = True
                        Dim objeto As Boolean = ValidationRUC(txtruc.Text.Trim)
                        If objeto = False Then
                            PictureLoad.Visible = False
                            MessageBox.Show("Debe Ingresar un número correcto de ruc", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Cursor = Cursors.Default
                            textPersona.Clear()
                            Exit Sub
                        End If

                        If My.Computer.Network.IsAvailable = True Then
                            'VALIDAR SI EXISTE EN LA bd LOCAL PRIMERO 
                            If GetValidarLocalDB2(txtruc.Text.Trim) = False Then
                                txtruc.ReadOnly = True

                                GetApiSunat2(txtruc.Text.Trim)

                            End If
                        Else
                            'SI NO HAY CONEXION A INTERNET
                            If GetValidarLocalDB2(txtruc.Text.Trim) = False Then
                                Dim nroDoc = txtruc.Text.Trim.Substring(0, 1).ToString
                                If nroDoc = "1" Then
                                    'SelRazon.tipoEntidad = "CL"
                                    'SelRazon.nombreCompleto = TextEmpresaPasajero.Text.Trim
                                    'SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                                    'SelRazon.tipoDoc = "6"
                                    'SelRazon.tipoPersona = "N"
                                    'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    'GrabarEntidadRapida()
                                    GrabarEnFormBasico2()
                                    PictureLoad.Visible = False
                                    If textPersona.Text.Trim.Length > 0 Then
                                        'TextFiltrar.Select()
                                        'TextFiltrar.Focus()
                                    Else
                                        txtruc.Clear()
                                        txtruc.Select()
                                    End If
                                ElseIf nroDoc = "2" Then
                                    'SelRazon.tipoEntidad = "CL"
                                    'SelRazon.nombreCompleto = TextEmpresaPasajero.Text.Trim
                                    'SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                                    'SelRazon.tipoDoc = "6"
                                    'SelRazon.tipoPersona = "J"
                                    'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    'GrabarEntidadRapida()
                                    GrabarEnFormBasico2()
                                    PictureLoad.Visible = False
                                    If textPersona.Text.Trim.Length > 0 Then
                                        'TextFiltrar.Select()
                                        'TextFiltrar.Focus()
                                    Else
                                        txtruc.Clear()
                                        txtruc.Select()
                                    End If
                                End If
                            End If
                        End If

                    Case Else
                        textPersona.Text = String.Empty
                        txtruc.Text = String.Empty
                        MessageBox.Show("Ingrese un documento correcto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Select

            End If
            '    TextNumIdentrazon.Enabled = True

        Catch ew As WebException

            If ew.Status = WebExceptionStatus.ProtocolError Then
                PictureLoad.Visible = False
                Dim [error] As String = New System.IO.StreamReader(ew.Response.GetResponseStream()).ReadToEnd()
                MessageBox.Show("DNI no encontrado en el padron, verifique si es menor de edad")
                TextNumIdentrazon.Clear()
                TextNumIdentrazon.Select()
                TextNumIdentrazon.Focus()
                textPersona.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Try

            If MessageBox.Show("¿Desea salir de la venta?", "Salir de la venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then

                LimpiarCajasTransporte()
                FormPurchase.TabTR_PasajeVenta.Visible = False

                If FormPurchase.TabTR_IdentificacionRuta IsNot Nothing Then
                    FormPurchase.TabTR_IdentificacionRuta.GetDocumentoVentaID()
                    FormPurchase.TabTR_IdentificacionRuta.Visible = True
                    FormPurchase.TabTR_IdentificacionRuta.BringToFront()
                    FormPurchase.TabTR_IdentificacionRuta.Show()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub RoundButton27_Click(sender As Object, e As EventArgs) Handles RoundButton27.Click
        Try
            'If ListProgamacion.SelectedItems.Count > 0 Then
            If MessageBox.Show("Desea enviar programación a zona de embarque?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                GetCerrarVentas(Integer.Parse(LabelfechaProg.Tag), ProgramacionEstado.ZonaEmbarque)
            End If
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
