Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports System.IO
Imports Microsoft.VisualBasic.FileIO
Imports System.Net
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Net.Http

Public Class frmNuevoClienteSPK

#Region "Attributes"
    Public Property TablaSA As New Helios.Cont.WCFService.ServiceAccess.tablaDetalleSA
    Private dt As DataTable
    Private Property empresaSA As New empresaSA
    Private Property ProductoSeguridadSA As New Seguridad.WCFService.ServiceAccess.ProductoSA

    Dim listacentrocosto As New List(Of centrocosto)
    Dim centroCostoBE As New centrocosto
    Dim empresaBE As New empresa
    Dim estado As Boolean = False
    Private Property SelRazon As entidad
    Private Property entidadSA As New entidadSA
#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        GetTablasGenerales()
        CARGARDEFAULT()
        CrearNodosDelPadre()
    End Sub


#End Region

#Region "Methods"

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
                txtRazonSocial.Text = students.NombreORazonSocial
                SelRazon.estado = students.EstadoDelContribuyente
                SelRazon.nrodoc = students.Ruc
                SelRazon.direccion = students.Direccion

                SelRazon.TipoVia = students.TipoDeVia
                SelRazon.Via = students.NombreDeVia
                SelRazon.Ubigeo = students.Ubigeo

                PictureLoad.Visible = False
            Else
                GetConsultaSunatAsync(nroruc)

                'TextProveedor.Clear()
                'PictureLoad.Visible = False
            End If
            txtnroDocumento.ReadOnly = False
        End Using
    End Sub


    Private Function GetConsultarDNIReniecAPIs(Dni As String) As String
        Dim strJSON As String = String.Empty
        Dim rClient As RESTClientAPI = New RESTClientAPI()
        Dim appat As String = String.Empty
        Dim apmat As String = String.Empty
        Dim nom As String = String.Empty
        Dim fullName As String = String.Empty
        Select Case ApiReniecOption
            Case ApisReniec.ApiReniecCloud
                rClient.endPoint = "https://api.reniec.cloud/dni/" & Dni
            Case ApisReniec.ApiGrupoTeComCom
                rClient.endPoint = "http://apis.grupotecom.com/api/ConsultaDni?dni=" & Dni
            Case ApisReniec.ApiConsultasDsdInformaticos
                rClient.endPoint = "http://consultas.dsdinformaticos.com/reniec.php?dni=" & Dni
        End Select

        strJSON = rClient.makeRequest()
        Dim res = JsonConvert.DeserializeObject(strJSON)

        Select Case ApiReniecOption
            Case ApisReniec.ApiReniecCloud
                appat = res("apellido_paterno").ToString() 'res.apellido_paterno
                apmat = res("apellido_materno").ToString() ' res.apellido_materno
                nom = res("nombres").ToString() 'res.nombres
                fullName = Trim($"{appat} {apmat} {nom}")
            Case ApisReniec.ApiGrupoTeComCom

                Dim result = res("success")

                If result = "false" Then
                    fullName = ""
                Else
                    fullName = res("result")("NombreCompleto")
                    fullName = Trim(fullName)
                End If


            Case ApisReniec.ApiConsultasDsdInformaticos
                appat = res("result")("ApellidoPaterno").ToString() 'res.apellido_paterno
                apmat = res("result")("ApellidoMaterno").ToString() ' res.apellido_materno
                nom = res("result")("Nombres").ToString() 'res.nombres
                fullName = Trim($"{appat} {apmat} {nom}")
        End Select

        'Dim s = res("dni").ToString()




        '  nombres = MIHTML.Replace("|", Space(1))
        Return fullName
    End Function

    Function ListacuentaplanContableEmpresa() As List(Of cuentaplanContableEmpresa)
        ' Dim dirPruebas As String = "C:\Helios"
        Dim ficPruebas As String = Path.Combine(carpeta, "cuentaplanContableEmpresa.txt")

        'Dim testFile As System.IO.FileInfo
        'testFile = My.Computer.FileSystem.GetFileInfo("C:\Helios\cuentaplanContableEmpresa.txt")
        'Dim folderPath As String = testFile.DirectoryName

        ListacuentaplanContableEmpresa = New List(Of cuentaplanContableEmpresa)
        'Using leitor As New TextFieldParser("C:\Users\Jiuni\Desktop\cuentaplanContableEmpresa.txt")
        Using leitor As New TextFieldParser(ficPruebas)

            'Informamos que será importado com Delimitação 
            leitor.TextFieldType = FileIO.FieldType.Delimited
            'Informamos o Delimitador 
            leitor.SetDelimiters(",")

            Dim linhaAtual As String()
            While Not leitor.EndOfData
                Try
                    linhaAtual = leitor.ReadFields()
                    'Dim currentField As String
                    'For Each currentField In linhaAtual
                    '    MsgBox(currentField)

                    'Next
                    ListacuentaplanContableEmpresa.Add(New cuentaplanContableEmpresa With
                                             {
                                                 .cuenta = linhaAtual(0).ToString,
                                                 .cuentaPadre = linhaAtual(1).ToString,
                                                 .descripcion = linhaAtual(2).ToString,
                                                 .Observaciones = linhaAtual(3).ToString,
                                                 .usuarioModificacion = linhaAtual(4).ToString,
                                                 .fechaModificacion = linhaAtual(5).ToString
                                             })

                Catch ex As MalformedLineException
                    'Ignoramos a linha atual caso não seja válida 
                    MsgBox("Linha: " & ex.Message & " não é válida e será ignorada.")
                End Try
            End While
            'MsgBox("Arquivo Importado com Sucesso!")
        End Using
    End Function

    Function ListamascaraGastosEmpresa() As List(Of mascaraGastosEmpresa)
        '  Dim dirPruebas As String = "C:\Helios"
        Dim ficPruebas As String = Path.Combine(carpeta, "mascaraGastosEmpresa.txt")

        'Dim testFile As System.IO.FileInfo
        'testFile = My.Computer.FileSystem.GetFileInfo("C:\Helios\mascaraGastosEmpresa.txt")
        'Dim folderPath As String = testFile.DirectoryName

        ListamascaraGastosEmpresa = New List(Of mascaraGastosEmpresa)
        Using leitor As New TextFieldParser(ficPruebas)
            'Using leitor As New TextFieldParser("C:\Users\Jiuni\Desktop\mascaraGastosEmpresa.txt")

            'Informamos que será importado com Delimitação 
            leitor.TextFieldType = FileIO.FieldType.Delimited
            'Informamos o Delimitador 
            leitor.SetDelimiters(",")

            Dim linhaAtual As String()
            While Not leitor.EndOfData
                Try
                    linhaAtual = leitor.ReadFields()
                    'Dim currentField As String
                    'For Each currentField In linhaAtual
                    '    MsgBox(currentField)

                    'Next
                    ListamascaraGastosEmpresa.Add(New mascaraGastosEmpresa With
                                             {
                                                 .cuentaCompra = linhaAtual(0).ToString,
                                                 .descripcionCompra = linhaAtual(1).ToString,
                                                 .cuentaCostoProcesoDebe = linhaAtual(2).ToString,
                                                 .descripcionCostoProcesoDebe = linhaAtual(3).ToString,
                                                 .cuentaCostoProcesoHaber = linhaAtual(4).ToString,
                                                 .descripcionCostoProcesoHaber = linhaAtual(5).ToString,
                                                 .cuentaConclusionProcesoDebe = linhaAtual(6).ToString,
                                                 .descripcionConclusionDebe = linhaAtual(7).ToString,
                                                 .cuentaConclusionProcesoHaber = linhaAtual(8).ToString,
                                                 .descripcionConclusionHaber = linhaAtual(9).ToString,
                                                 .cuentaDestinoDebe = linhaAtual(10).ToString,
                                                 .descripcionDestinoDebe = linhaAtual(11).ToString,
                                                 .cuentaDestinoHaber = linhaAtual(12).ToString,
                                                 .descripcionDestinoHaber = linhaAtual(13).ToString,
                                                 .usuarioActualizacion = linhaAtual(14).ToString,
                                                 .fechaActualizacion = linhaAtual(15).ToString
                                             })

                Catch ex As MalformedLineException
                    'Ignoramos a linha atual caso não seja válida 
                    MsgBox("Linha: " & ex.Message & " não é válida e será ignorada.")
                End Try
            End While
            'MsgBox("Arquivo Importado com Sucesso!")
        End Using
    End Function

    Function ListaCuentaMascara() As List(Of cuentaMascara)
        '    Dim dirPruebas As String = "C:\Helios"
        Dim ficPruebas As String = Path.Combine(carpeta, "cuentaMascara.txt")

        'Dim testFile As System.IO.FileInfo
        'testFile = My.Computer.FileSystem.GetFileInfo("C:\Helios\cuentaMascara.txt")
        'Dim folderPath As String = testFile.DirectoryName

        ListaCuentaMascara = New List(Of cuentaMascara)
        Using leitor As New TextFieldParser(ficPruebas)
            'Using leitor As New TextFieldParser("C:\Users\Jiuni\Desktop\cuentaMascara.txt")

            'Informamos que será importado com Delimitação 
            leitor.TextFieldType = FileIO.FieldType.Delimited
            'Informamos o Delimitador 
            leitor.SetDelimiters(",")

            Dim linhaAtual As String()
            While Not leitor.EndOfData
                Try
                    linhaAtual = leitor.ReadFields()
                    'Dim currentField As String
                    'For Each currentField In linhaAtual
                    '    MsgBox(currentField)

                    'Next
                    ListaCuentaMascara.Add(New cuentaMascara With
                                             {
                                                 .parametro = linhaAtual(0).ToString,
                                                 .cuentaBase = linhaAtual(1).ToString,
                                                 .cuentaEspecifica = linhaAtual(2).ToString,
                                                 .tipoAsiento = linhaAtual(3).ToString,
                                                 .tipo = linhaAtual(4).ToString,
                                                 .idModulo = linhaAtual(5).ToString
                                             })

                Catch ex As MalformedLineException
                    'Ignoramos a linha atual caso não seja válida 
                    MsgBox("Linha: " & ex.Message & " não é válida e será ignorada.")
                End Try
            End While
            'MsgBox("Arquivo Importado com Sucesso!")
        End Using
    End Function
    Private carpeta = ".\DBTXT\"
    Function ListaMascarContable2() As List(Of mascaraContable2)
        'Dim dirPruebas As String = "C:\Helios"


        Dim ficPruebas As String = Path.Combine(carpeta, "mascaraContable2.txt")

        'Dim testFile As System.IO.FileInfo
        'testFile = My.Computer.FileSystem.GetFileInfo("C:\Helios\mascaraContable2.txt")
        'Dim folderPath As String = testFile.DirectoryName
        ListaMascarContable2 = New List(Of mascaraContable2)
        Using leitor As New TextFieldParser(ficPruebas)
            'Using leitor As New TextFieldParser("C:\Users\Jiuni\Desktop\mascaraContable2.txt")

            'Informamos que será importado com Delimitação 
            leitor.TextFieldType = FileIO.FieldType.Delimited
            'Informamos o Delimitador 
            leitor.SetDelimiters(",")

            Dim linhaAtual As String()
            While Not leitor.EndOfData
                Try
                    linhaAtual = leitor.ReadFields()
                    'Dim currentField As String
                    'For Each currentField In linhaAtual
                    '    MsgBox(currentField)

                    'Next
                    ListaMascarContable2.Add(New mascaraContable2 With
                                             {
                                                 .tipoExistencia = linhaAtual(0).ToString.PadLeft(2, "0" & linhaAtual(0)),
                                                 .cuentaCompra = linhaAtual(1).ToString,
                                                 .descripcionCompra = linhaAtual(2).ToString,
                                                 .asientoCompra = linhaAtual(3).ToString,
                                                 .destinoCompra = linhaAtual(4).ToString,
                                                 .descripcionDestino = linhaAtual(5).ToString,
                                                 .asientoDestino = linhaAtual(6).ToString,
                                                 .destinoCompra2 = linhaAtual(7).ToString,
                                                 .descripcionDestino2 = linhaAtual(8).ToString,
                                                 .asientoDestino2 = linhaAtual(9).ToString,
                                                 .cuentaDestinoKardex = linhaAtual(10).ToString,
                                                 .nameDestinoKardex = linhaAtual(11).ToString,
                                                 .asientoDestinoKardex = linhaAtual(12).ToString,
                                                 .cuentaDestinoKardex2 = linhaAtual(13).ToString,
                                                 .nameDestinoKardex2 = linhaAtual(14).ToString,
                                                 .asientoDestinoKardex2 = linhaAtual(15).ToString,
                                                 .cuentaVenta = linhaAtual(16).ToString,
                                                 .descripcionVenta = linhaAtual(17).ToString,
                                                 .asientoVenta = linhaAtual(18).ToString,
                                                 .cuentaKardex = linhaAtual(19).ToString,
                                                 .descripcionKardex = linhaAtual(20).ToString,
                                                 .asientoKardex = linhaAtual(21).ToString,
                                                 .cuentaKardex2 = linhaAtual(22).ToString,
                                                 .descripcionKardex2 = linhaAtual(23).ToString,
                                                 .asientoKardex2 = linhaAtual(24).ToString
                                             })

                Catch ex As MalformedLineException
                    'Ignoramos a linha atual caso não seja válida 
                    MsgBox("Linha: " & ex.Message & " não é válida e será ignorada.")
                End Try
            End While
            'MsgBox("Arquivo Importado com Sucesso!")
        End Using
    End Function

    Private Sub GetTablasGenerales()
        Dim lista As New List(Of String)
        lista.Add("1")
        lista.Add("6")

        ' cboTipoDoc.DataSource = TablaSA.GetListaTablaDetalle(4, "1").Where(Function(o) lista.Contains(o.codigoDetalle)).ToList
        cboTipoDoc.DataSource = TablaSA.GetListaTablaDetalle(2, "1").Where(Function(o) lista.Contains(o.codigoDetalle)).ToList
        cboTipoDoc.DisplayMember = "codigoDetalle2"
        cboTipoDoc.ValueMember = "codigoDetalle"

        dt = New DataTable
        dt.Columns.Add("ID")
        dt.Columns.Add("NAME")
        dt.Rows.Add("1", "De 1 a 10 trabajadores")
        dt.Rows.Add("2", "De 11 a 50 trabajadores")
        dt.Rows.Add("3", "De 51 a 200 trabajadores")
        dt.Rows.Add("4", "De 201 a 500 trabajadores")
        dt.Rows.Add("5", "Más de 1000 trabajadores")
        cboNroTrab.DataSource = dt
        cboNroTrab.DisplayMember = "NAME"
        cboNroTrab.ValueMember = "ID"

        'Horario Laboral
        dt = New DataTable
        dt.Columns.Add("ID")
        dt.Columns.Add("NAME")
        dt.Rows.Add("1", "Empleador directo")
        dt.Rows.Add("2", "Agencia publicitaria")
        dt.Rows.Add("3", "Servicios temporales")
        cboHorarioLab.DataSource = dt
        cboHorarioLab.DisplayMember = "NAME"
        cboHorarioLab.ValueMember = "ID"

        'Sector empresarial
        dt = New DataTable
        dt.Columns.Add("ID")
        dt.Columns.Add("NAME")
        dt.Rows.Add("1", "Agricultura/Pesca/Ganadería")
        dt.Rows.Add("2", "Construcción / Obras")
        dt.Rows.Add("3", "Educación")
        dt.Rows.Add("4", "Energía / Minería")
        dt.Rows.Add("5", "Entretenimiento / Deporte")
        dt.Rows.Add("6", "Fabricación")
        cboSector.DataSource = dt
        cboSector.DisplayMember = "NAME"
        cboSector.ValueMember = "ID"

        'Tipo empresa
        dt = New DataTable
        dt.Columns.Add("ID")
        dt.Columns.Add("NAME")
        dt.Rows.Add("1", "Empleador Directo")
        dt.Rows.Add("2", "Agencia de reclutamiento")
        dt.Rows.Add("3", "Servicios temporarales")
        cbotipoempresa.DataSource = dt
        cbotipoempresa.DisplayMember = "NAME"
        cbotipoempresa.ValueMember = "ID"

        cboProductosSoftpack.DataSource = ProductoSeguridadSA.ListadoProductoFull()
        cboProductosSoftpack.DisplayMember = "nombre"
        cboProductosSoftpack.ValueMember = "IDProducto"
        cboProductosSoftpack.SelectedValue = 23
    End Sub

    Private Function ValidarGrabado() As Boolean
        Dim listaErrores As Integer = 0

        If txtnroDocumento.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(txtnroDocumento, "Ingrese nro. documento")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(txtnroDocumento, Nothing)
        End If

        If cboTipoDoc.SelectedValue = 1 Then
            If Not txtnroDocumento.Text.Trim.Length = 8 Then
                ErrorProvider1.SetError(txtnroDocumento, "El DNI debe ser de 8 digitos")
                listaErrores += 1
            Else
                ErrorProvider1.SetError(txtnroDocumento, Nothing)
            End If
        Else
            If Not txtnroDocumento.Text.Trim.Length = 11 Then
                ErrorProvider1.SetError(txtnroDocumento, "El RUC debe ser de 11 digitos")
                listaErrores += 1
            Else
                ErrorProvider1.SetError(txtnroDocumento, Nothing)
            End If
        End If


        If txtRazonSocial.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(txtRazonSocial, "Ingrese la razón social")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(txtRazonSocial, Nothing)
        End If

        If txtNomCorto.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(txtNomCorto, "Ingrese un nombre corto")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(txtNomCorto, Nothing)
        End If

        If txtDir.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(txtDir, "Ingrese la dirección de la empresa")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(txtDir, Nothing)
        End If

        If txtNombres.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(txtNombres, "Ingrese al contacto")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(txtNombres, Nothing)
        End If

        If txtApellidos.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(txtApellidos, "Ingrese los apellidos del contacto")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(txtApellidos, Nothing)
        End If

        If txtFono1.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(txtFono1, "Ingrese un teléfono al menos")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(txtFono1, Nothing)
        End If

        If listaErrores > 0 Then
            ValidarGrabado = False
        Else
            ValidarGrabado = True
        End If
    End Function

    Private Sub Grabar()

        Dim nuevoCliente As New clientesSoftPack With {
            .Action = BaseBE.EntityAction.INSERT,
            .IDProducto = cboProductosSoftpack.SelectedValue,
            .idclientespk = cboProductosSoftpack.SelectedValue,
            .tipodoc = cboTipoDoc.SelectedValue,
            .nroDoc = txtnroDocumento.Text.Trim,
            .razonsocial = txtRazonSocial.Text.Trim,
            .logo = Nothing,
            .nrotrabajadores = cboNroTrab.SelectedValue,
            .horariolaboral = cboHorarioLab.SelectedValue,
            .direccion = txtDir.Text.Trim,
            .departamento = 1,
            .provincia = 1,
            .distrito = 1,
            .pais = 1,
            .sectorEmpresarial = cboSector.SelectedValue,
            .tipoempresa = cbotipoempresa.SelectedValue,
            .detalle = Nothing,
            .paginaweb = txtPaginaWeb.Text.Trim,
            .nombreContacto = txtNombres.Text.Trim,
            .apellidosContacto = txtApellidos.Text.Trim,
            .telefono1 = txtFono1.Text.Trim,
            .telefono2 = txtFono2.Text.Trim,
            .status = 1
        }

        'nuevoCliente.empresa = New List(Of empresa)

        empresaBE = New empresa With {
            .regimen = If(RBGeneral.Checked, "1", "2"),
            .idEmpresa = txtnroDocumento.Text.Trim,
            .razonSocial = txtRazonSocial.Text.Trim,
            .nombreCorto = txtNomCorto.Text.Trim,
            .ruc = txtnroDocumento.Text.Trim,
            .direccion = txtDir.Text.Trim,
            .telefono = Nothing,
            .fax = Nothing,
            .celular = Nothing,
            .e_mail = Nothing,
            .actividad = cboSector.SelectedValue,
            .inicioOperacion = String.Format("{0:00}", txtPeriodoCierre.Value.Month) & "/" & txtPeriodoCierre.Value.Year,
            .periodo = txtPeriodoCierre.Value,
            .usuarioActualizacion = usuario.IDUsuario,
            .fechaActualizacion = Date.Now,
            .estado = "0"
            }

        'nuevoCliente.ListaMascaraContable2 = ListaMascarContable2()
        'nuevoCliente.ListaCuentaMascara = ListaCuentaMascara()
        'nuevoCliente.ListamascaraGastosEmpresa = ListamascaraGastosEmpresa()
        'nuevoCliente.ListacuentaplanContableEmpresa = ListacuentaplanContableEmpresa()



        'nuevoCliente.clientePagoMensual.Add(New clientePagoMensual With
        '    {
        '     anio
        'mes
        'codigoPago
        'serial
        'statuspago
        'fechacontrato
        'fechaExpiracion
        '    })

        ClientesSoftPackSA.GrabarClienteSoftPack(nuevoCliente, empresaBE, listacentrocosto)

        MessageBox.Show("Cliente registrado con Éxito", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Tag = empresaSA.UbicarEmpresaRuc(txtnroDocumento.Text.Trim)
        'Close()
    End Sub
#End Region

#Region "Events"

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        Try
            If ValidarGrabado() Then
                'For index As Integer = 0 To CInt(NroUnidadNegocio.Text)
                Grabar()
                'Next
                estado = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            estado = False
        End Try
    End Sub

    Private Sub txtPeriodo_ValueChanged(sender As Object, e As EventArgs) Handles txtPeriodo.ValueChanged
        txtPeriodoCierre.Value = CDate(txtPeriodo.Value).AddMonths(-1)
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Try
            Dim conteo As Integer = 1
            Dim centrocostosBE As New centrocosto
            Dim listaCentrocontroBE As New List(Of centrocosto)
            Dim centrocostoSA As New establecimientoSA



            If (estado = True) Then
                listaCentrocontroBE = centrocostoSA.ObtenerListaEstablecimientos(txtnroDocumento.Text).Where(Function(o) o.TipoEstab = "UN").ToList

                GetSuperAdminAdd(Nothing, listaCentrocontroBE, conteo)

                For Each item In listaCentrocontroBE
                    GetAdminAdd(Nothing, item, conteo)
                    conteo = conteo + 1
                Next

                SaveSinDeterminar()

                MessageBox.Show("Administrador agregado")

                Close()

                Tag = empresaBE
            Else
                MessageBox.Show("DEBE CREAR PRIMERO LA EMPRESA")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Public Sub SaveSinDeterminar()
        Try

            Dim centrocontroBE As New List(Of centrocosto)
            Dim centrocostoSA As New establecimientoSA

            centrocontroBE = centrocostoSA.ObtenerListaEstablecimientos(txtnroDocumento.Text).Where(Function(o) o.TipoEstab = "UN").ToList

            For Each itemUnidad In centrocontroBE

                Dim itemSA As New itemSA

                Dim objetoCat As New item
                With objetoCat
                    .tipo = "H"
                    .idEmpresa = txtnroDocumento.Text
                    .idEstablecimiento = itemUnidad.idCentroCosto
                    .descripcion = "SIN CLASIFICACION"
                    .fechaIngreso = DateTime.Now
                    .utilidad = 0
                    .utilidadmayor = 0
                    .utilidadgranmayor = 0
                    .preciocompratipo = "NN"
                    .usuarioActualizacion = usuario.IDUsuario
                    .fechaActualizacion = DateTime.Now
                End With

                Dim codCatx As Integer = itemSA.SaveCategoria(objetoCat)

                Dim objeto As New item
                With objeto
                    .idPadre = codCatx
                    .tipo = TipoGrupoArticulo.CategoriaGeneral
                    .idEmpresa = txtnroDocumento.Text
                    .idEstablecimiento = itemUnidad.idCentroCosto
                    .descripcion = "SIN CATEGORIA"
                    .fechaIngreso = DateTime.Now
                    .utilidad = 0
                    .utilidadmayor = 0
                    .utilidadgranmayor = 0
                    .preciocompratipo = "NN"
                    .usuarioActualizacion = usuario.IDUsuario
                    .fechaActualizacion = DateTime.Now
                End With

                Dim codx As Integer = itemSA.SaveCategoria(objeto)

                Dim objeto2 As New item

                With objeto2
                    .idPadre = codx
                    .tipo = TipoGrupoArticulo.SubCategoriaGeneral
                    .idEmpresa = txtnroDocumento.Text
                    .idEstablecimiento = itemUnidad.idCentroCosto
                    .descripcion = "SIN SUBCATEGORIA"
                    .fechaIngreso = DateTime.Now
                    .utilidad = 0
                    .utilidadmayor = 0
                    .utilidadgranmayor = 0
                    .preciocompratipo = "NN"
                    .usuarioActualizacion = usuario.IDUsuario
                    .fechaActualizacion = DateTime.Now
                End With


                Dim codxxx As Integer = itemSA.SaveCategoria(objeto2)


                Dim objeto3 As New item

                With objeto3
                    .idPadre = codxxx
                    .tipo = TipoGrupoArticulo.Marca
                    .idEmpresa = txtnroDocumento.Text
                    .idEstablecimiento = itemUnidad.idCentroCosto
                    .descripcion = "SIN MARCA"
                    .fechaIngreso = DateTime.Now
                    .utilidad = 0
                    .utilidadmayor = 0
                    .utilidadgranmayor = 0
                    .preciocompratipo = "NN"
                    .usuarioActualizacion = usuario.IDUsuario
                    .fechaActualizacion = DateTime.Now
                End With

                Dim codx2 As Integer = itemSA.InsertarMarcaHijo(objeto3)

                Dim objeto4 As New item

                With objeto4
                    .idPadre = codx2
                    .tipo = TipoGrupoArticulo.Presentacion
                    .idEmpresa = txtnroDocumento.Text
                    .idEstablecimiento = itemUnidad.idCentroCosto
                    .descripcion = "SIN PRESENTACION"
                    .fechaIngreso = DateTime.Now
                    .utilidad = 0
                    .utilidadmayor = 0
                    .utilidadgranmayor = 0
                    .preciocompratipo = "NN"
                    .usuarioActualizacion = usuario.IDUsuario
                    .fechaActualizacion = DateTime.Now
                End With

                Dim codx3 As Integer = itemSA.InsertarMarcaHijo(objeto4)

            Next

            Dim ListaColorTalla As New List(Of tabladetalle)
            Dim tablaDetalleSA As New tablaDetalleSA

            Dim objetoTlla As New tabladetalle
            objetoTlla.idtabla = 18
            objetoTlla.codigoDetalle = 1
            objetoTlla.codigoDetalle2 = "N"
            objetoTlla.descripcion = "SIN DETERMINAR"
            objetoTlla.estadodetalle = 1
            objetoTlla.fechaModificacion = DateTime.Now
            objetoTlla.usuarioModificacion = 1
            ListaColorTalla.Add(objetoTlla)

            Dim objetoColor As New tabladetalle
            objetoColor.idtabla = 19
            objetoColor.codigoDetalle = 1
            objetoColor.codigoDetalle2 = "N"
            objetoColor.descripcion = "SIN DETERMINAR"
            objetoColor.estadodetalle = 1
            objetoColor.fechaModificacion = DateTime.Now
            objetoColor.usuarioModificacion = 1
            ListaColorTalla.Add(objetoColor)

            If ListaColorTalla.Count > 0 Then
                tablaDetalleSA.GrabarListaTallaColor(ListaColorTalla)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GetAdminAdd(idCliente As String, listaCentroCostos As centrocosto, conteo As Integer)
        Try
            Dim usuarioSA As New Seguridad.WCFService.ServiceAccess.AutenticacionUsuarioSA

            'usuarioSA.GrabarSuperAdministradorDefault(New Seguridad.Business.Entity.AutenticacionUsuario With {.IdEmpresa = txtnroDocumento.Text.Trim, .IDCliente = idCliente})

            usuarioSA.GrabarAdministradorDefault(New Seguridad.Business.Entity.AutenticacionUsuario With {.IdEmpresa = txtnroDocumento.Text.Trim, .IDCliente = idCliente, .IDEstablecimiento = listaCentroCostos.idCentroCosto, .numeracion = conteo})

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub GetSuperAdminAdd(idCliente As String, listaCentroCostos As List(Of centrocosto), conteo As Integer)
        Try
            'Dim RolXgrupoEmpBE As Seguridad.Business.Entity.RolXGrupoEmp
            'Dim listaRolXgrupoEmpBE As New List(Of Seguridad.Business.Entity.RolXGrupoEmp)
            Dim usuarioSA As New Seguridad.WCFService.ServiceAccess.AutenticacionUsuarioSA

            'For Each item In listaCentroCostos.Where(Function(O) O.TipoEstab = "UN" And O.idEmpresa = txtnroDocumento.Text).ToList
            '    RolXgrupoEmpBE = New Seguridad.Business.Entity.RolXGrupoEmp
            '    RolXgrupoEmpBE.IDReferencia = item.idCentroCosto
            '    RolXgrupoEmpBE.descripcion = item.nombre
            '    RolXgrupoEmpBE.tipo = "GE"
            '    listaRolXgrupoEmpBE.Add(RolXgrupoEmpBE)
            'Next

            usuarioSA.GrabarSuperAdministradorDefault(New Seguridad.Business.Entity.AutenticacionUsuario With {.IdEmpresa = txtnroDocumento.Text.Trim, .IDCliente = idCliente})

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub frmNuevoClienteSPK_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPeriodo.Value = Date.Now
        trOrganigrama.ContextMenuStrip = cmAdministrar
        For Each RootNode As TreeNode In trOrganigrama.Nodes
            RootNode.ContextMenuStrip = cmAdministrar
            For Each ChildNode As TreeNode In RootNode.Nodes
                ChildNode.ContextMenuStrip = cmAdministrar
            Next
        Next
    End Sub

    Private Sub txtnroDocumento_TextChanged(sender As Object, e As EventArgs) Handles txtnroDocumento.TextChanged

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

    Private Async Sub GetConsultaSunatAsync(ruc As String)
        Dim nroDoc = ruc.Substring(0, 1).ToString
        If nroDoc = "1" Then
            Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
            If company IsNot Nothing Then
                txtRazonSocial.Text = company.RazonSocial
                txtnroDocumento.Text = company.Ruc
                txtDir.Text = company.DomicilioFiscal
                PictureLoad.Visible = False
            Else
                txtnroDocumento.Clear()
                txtRazonSocial.Clear()
                PictureLoad.Visible = False
            End If
        ElseIf nroDoc = "2" Then
            Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
            If company IsNot Nothing Then
                txtRazonSocial.Text = company.RazonSocial
                txtnroDocumento.Text = company.Ruc
                txtDir.Text = company.DomicilioFiscal
                PictureLoad.Visible = False
            Else
                txtnroDocumento.Clear()
                txtRazonSocial.Clear()
                PictureLoad.Visible = False
            End If
        End If

    End Sub

    Private Sub txtnroDocumento_KeyDown(sender As Object, e As KeyEventArgs) Handles txtnroDocumento.KeyDown
        Dim nombres = String.Empty
        Try
            'TextNumIdentrazon.Enabled = False
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True

                Select Case txtnroDocumento.Text.Trim.Length
                    Case 8 'dni

                        SelRazon = New entidad

                        If My.Computer.Network.IsAvailable = True Then
                            PictureLoad.Visible = True
                            'nombres = GetConsultarDNIReniec(TextNumIdentrazon.Text.Trim)
                            nombres = GetConsultarDNIReniecAPIs(txtnroDocumento.Text.Trim)

                            If nombres.Trim.Length > 0 Then

                                If nombres = "DNI no encontrado en Padrón Electoral" Then
                                    txtnroDocumento.Clear()
                                    txtRazonSocial.Text = String.Empty
                                    txtRazonSocial.Tag = Nothing
                                    PictureLoad.Visible = False
                                    Exit Sub
                                End If

                                SelRazon.tipoEntidad = "CL"
                                SelRazon.nombreCompleto = nombres
                                SelRazon.nrodoc = txtnroDocumento.Text.Trim
                                SelRazon.tipoDoc = "1"
                                SelRazon.tipoPersona = "N"
                                txtRazonSocial.Text = nombres

                                'Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", txtnroDocumento.Text.Trim)

                                'If existeEnDB Is Nothing Then
                                '    txtRazonSocial.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                '    'GrabarEntidadRapida()
                                '    PictureLoad.Visible = False
                                'Else
                                txtRazonSocial.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                'txtRazonSocial.Tag = existeEnDB.idEntidad
                                'If RadioButton2.Checked = True Then
                                txtDir.Focus()
                                    txtDir.Select()
                                'ElseIf RadioButton1.Checked = True Then
                                '    txtruc.Focus()
                                '    txtruc.Select()
                                'End If
                                'End If
                            Else
                                txtnroDocumento.Clear()
                                txtRazonSocial.Text = String.Empty
                                txtRazonSocial.Tag = Nothing
                            End If
                            PictureLoad.Visible = False
                        Else

                            ''CUANDO NO HAY CONEXION A INTERNET
                            'Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", txtnroDocumento.Text.Trim)
                            'If existeEnDB Is Nothing Then
                            '    SelRazon.tipoEntidad = "CL"
                            '    SelRazon.nombreCompleto = txtRazonSocial.Text.Trim
                            '    SelRazon.nrodoc = txtnroDocumento.Text.Trim
                            '    SelRazon.tipoDoc = "1"
                            '    SelRazon.tipoPersona = "N"
                            '    'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                            '    'GrabarEntidadRapida()
                            '    'GrabarEnFormBasico()
                            '    PictureLoad.Visible = False
                            'Else
                            '    txtRazonSocial.Text = existeEnDB.nombreCompleto
                            '    txtRazonSocial.Tag = existeEnDB.idEntidad
                            '    txtRazonSocial.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                            '    'If RadioButton2.Checked = True Then
                            '    txtDir.Focus()
                            '    txtDir.Select()
                            '    'ElseIf RadioButton1.Checked = True Then
                            '    '    txtruc.Focus()
                            '    '    txtruc.Select()
                            '    'End If
                            'End If
                        End If



                    Case 11 'razonSocial
                        PictureLoad.Visible = True
                        Dim objeto As Boolean = ValidationRUC(txtnroDocumento.Text.Trim)
                        If objeto = False Then
                            PictureLoad.Visible = False
                            MessageBox.Show("Debe Ingresar un número correcto de ruc", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Cursor = Cursors.Default
                            txtRazonSocial.Clear()
                            Exit Sub
                        End If

                        If My.Computer.Network.IsAvailable = True Then
                            'VALIDAR SI EXISTE EN LA bd LOCAL PRIMERO 
                            'If GetValidarLocalDB(txtnroDocumento.Text.Trim) = False Then
                            txtnroDocumento.ReadOnly = True

                            'Select Case ToggleConsultas.ToggleState
                            '    Case ToggleButton2.ToggleButtonState.OFF ' API
                            '        '  GetConsultaSunatAsync(TextNumIdentrazon.Text.Trim)
                            GetApiSunat(txtnroDocumento.Text.Trim)
                            '    Case ToggleButton2.ToggleButtonState.ON ' WEB
                            '        BgProveedor.RunWorkerAsync()
                            'End Select
                            'End If
                        Else
                            'SI NO HAY CONEXION A INTERNET
                            '    If GetValidarLocalDB(txtnroDocumento.Text.Trim) = False Then
                            '        Dim nroDoc = txtnroDocumento.Text.Trim.Substring(0, 1).ToString
                            '        If nroDoc = "1" Then
                            '            'SelRazon.tipoEntidad = "CL"
                            '            'SelRazon.nombreCompleto = TextEmpresaPasajero.Text.Trim
                            '            'SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                            '            'SelRazon.tipoDoc = "6"
                            '            'SelRazon.tipoPersona = "N"
                            '            'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                            '            'GrabarEntidadRapida()
                            '            'GrabarEnFormBasico()
                            '            PictureLoad.Visible = False
                            '            If txtRazonSocial.Text.Trim.Length > 0 Then
                            '                txtDir.Select()
                            '                txtDir.Focus()
                            '            Else
                            '                txtnroDocumento.Clear()
                            '                txtnroDocumento.Select()
                            '            End If
                            '        ElseIf nroDoc = "2" Then
                            '            'SelRazon.tipoEntidad = "CL"
                            '            'SelRazon.nombreCompleto = TextEmpresaPasajero.Text.Trim
                            '            'SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                            '            'SelRazon.tipoDoc = "6"
                            '            'SelRazon.tipoPersona = "J"
                            '            'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                            '            'GrabarEntidadRapida()
                            '            'GrabarEnFormBasico()
                            '            PictureLoad.Visible = False
                            '            If txtRazonSocial.Text.Trim.Length > 0 Then
                            '                txtDir.Select()
                            '                txtDir.Focus()
                            '            Else
                            '                txtnroDocumento.Clear()
                            '                txtnroDocumento.Select()
                            '            End If
                            '        End If
                            '    End If
                        End If

                    Case Else
                        txtRazonSocial.Text = String.Empty
                        txtnroDocumento.Text = String.Empty
                        MessageBox.Show("Ingrese un documento correcto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Select

            End If
            '    TextNumIdentrazon.Enabled = True

        Catch ew As WebException

            If ew.Status = WebExceptionStatus.ProtocolError Then
                PictureLoad.Visible = False
                Dim [error] As String = New System.IO.StreamReader(ew.Response.GetResponseStream()).ReadToEnd()
                MessageBox.Show("DNI no encontrado en el padron, verifique si es menor de edad")
                txtnroDocumento.Clear()
                txtnroDocumento.Select()
                txtnroDocumento.Focus()
                txtRazonSocial.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

#Region "ARBOL DE ORGANIGRAMA"

    Private Sub CARGARDEFAULT()
        Dim RubroConteo As Integer = 0
        Dim SegmentoConteo As Integer = 0

        centroCostoBE = New centrocosto
        centroCostoBE.idCentroCosto = listacentrocosto.Count + 1
        RubroConteo = centroCostoBE.idCentroCosto
        centroCostoBE.idpadre = Nothing
        centroCostoBE.nombre = "RUBRO 1"
        centroCostoBE.TipoEstab = "RU"
        listacentrocosto.Add(centroCostoBE)

        centroCostoBE = New centrocosto
        centroCostoBE.idCentroCosto = listacentrocosto.Count + 1
        SegmentoConteo = listacentrocosto.Count + 1
        centroCostoBE.idpadre = RubroConteo
        centroCostoBE.nombre = "SEGMENTO 1"
        centroCostoBE.TipoEstab = "SE"
        listacentrocosto.Add(centroCostoBE)

        centroCostoBE = New centrocosto
        centroCostoBE.idCentroCosto = listacentrocosto.Count + 1
        centroCostoBE.idpadre = SegmentoConteo
        centroCostoBE.nombre = "UNIDAD DE NEGOCIO 1"
        centroCostoBE.TipoEstab = "UN"
        listacentrocosto.Add(centroCostoBE)
    End Sub

    Private Sub CrearNodosDelPadre()
        Try

            Dim nodePadre As TreeNode
            Dim contqao As Integer = 0
            Dim contarHijos As Integer = 0
            Dim nietsosA As Integer = 0
            Dim nietoB As Integer = 0
            Dim contarEncabezado As Integer = 0

            ''//SEGEM,NTO

            'Dim listaSegmento As New List(Of Segmento)
            'Dim segmentoBE As New Segmento

            'segmentoBE = New Segmento
            'segmentoBE.ID = 2
            'segmentoBE.idPadre = 1
            'segmentoBE.NOMBRE = "SEGMENTO 1"
            'listaSegmento.Add(segmentoBE)

            '//rubro

            trOrganigrama.Nodes.Clear()

            Dim nodeEncabezado = New TreeNode

            'Descripción o texto del nodo
            nodeEncabezado.Text = "EMPRESA"
            nodeEncabezado.ForeColor = Color.Red
            'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
            nodeEncabezado.Name = 0

            'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
            nodeEncabezado.Tag = 0
            trOrganigrama.Nodes.Add(nodeEncabezado)

            Dim consultaPadre = (From a In listacentrocosto Where a.idpadre Is Nothing Select a).ToList

            'Dim consultaPadre = (From a In listaOr Where a.idPadre = 0 And a.idCentroCosto = cbunidadnegocioOrg.SelectedValue
            '                     Order By a.idOrganigrama Ascending Select a).ToList

            For Each PADRE In consultaPadre
                nodePadre = New TreeNode

                'Descripción o texto del nodo
                nodePadre.Text = PADRE.nombre

                'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
                nodePadre.Name = PADRE.idCentroCosto

                'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
                nodePadre.Tag = PADRE

                Dim ent = CType(nodePadre.Tag, centrocosto)

                trOrganigrama.Nodes(contarEncabezado).Nodes.Add(nodePadre)

                Dim consulta = (From a In listacentrocosto Where a.idpadre = ent.idCentroCosto
                                Order By a.idCentroCosto Ascending Select a).ToList

                If ((consulta.Count) > 0) Then
                    For Each hijos In consulta

                        Dim nodeHIJO = New TreeNode

                        'Descripción o texto del nodo
                        nodeHIJO.Text = hijos.nombre
                        nodeHIJO.ForeColor = Color.FromArgb(32, 182, 82)
                        'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
                        nodeHIJO.Name = hijos.idCentroCosto

                        'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
                        'nodeHIJO.Tag = hijos.ID

                        nodeHIJO.Tag = hijos

                        Dim entHijo = CType(nodeHIJO.Tag, centrocosto)

                        trOrganigrama.Nodes(contarEncabezado).Nodes(contqao).Nodes.Add(nodeHIJO)

                        Dim consultANietos = (From a In listacentrocosto Where a.idpadre = entHijo.idCentroCosto
                                              Order By a.idCentroCosto Ascending Select a).ToList

                        For Each NIETOS In consultANietos
                            Dim nodeNieto = New TreeNode

                            'Descripción o texto del nodo
                            nodeNieto.Text = NIETOS.nombre

                            'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
                            nodeNieto.Name = NIETOS.idCentroCosto

                            'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
                            'nodeNieto.Tag = NIETOS.ID
                            nodeNieto.Tag = NIETOS

                            Dim entNieto = CType(nodeNieto.Tag, centrocosto)

                            trOrganigrama.Nodes(contarEncabezado).Nodes(contqao).Nodes(contarHijos).Nodes.Add(nodeNieto)


                            Dim consultanietosA = (From m In listacentrocosto Where m.idpadre = entNieto.idCentroCosto
                                                   Order By m.idCentroCosto Ascending Select m).ToList

                            For Each nietosA In consultanietosA

                                Dim nodeNietosA = New TreeNode

                                nodeNietosA.Text = nietosA.nombre
                                nodeNietosA.ForeColor = Color.FromArgb(7, 117, 129)
                                nodeNietosA.Name = nietosA.idCentroCosto

                                'nodeNietosA.Tag = nietosA.ID
                                nodeNietosA.Tag = nietosA

                                Dim entnodeNietosA = CType(nodeNieto.Tag, centrocosto)
                                trOrganigrama.Nodes(contarEncabezado).Nodes(contqao).Nodes(contarHijos).Nodes(nietsosA).Nodes.Add(nodeNietosA)

                                Dim consultaNietoB = (From p In listacentrocosto Where p.idpadre = entnodeNietosA.idCentroCosto
                                                      Order By p.idCentroCosto Ascending Select p).ToList

                                For Each nietosB In consultaNietoB
                                    Dim nodoNietoB = New TreeNode

                                    nodoNietoB.Text = nietosB.nombre

                                    nodoNietoB.Name = nietosB.idCentroCosto

                                    'nodoNietoB.Tag = nietosB.ID
                                    nodeNietosA.Tag = nietosB
                                    trOrganigrama.Nodes(contarEncabezado).Nodes(contqao).Nodes(contarHijos).Nodes(nietsosA).Nodes(nietoB).Nodes.Add(nodoNietoB)
                                Next
                                nietoB += 1

                            Next
                            nietoB = 0
                            If (consulta.Count > 1) Then
                                nietsosA += 1
                            Else
                                nietsosA = 0
                            End If
                        Next
                        nietsosA = 0
                        If (consulta.Count > 1) Then
                            contarHijos += 1
                        Else
                            contarHijos = 0
                        End If
                    Next
                    contarHijos = 0
                End If
                'contarHijos += 1
                contqao += 1
            Next
            trOrganigrama.EndUpdate()
            trOrganigrama.ExpandAll()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub NuevoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoToolStripMenuItem.Click
        Try

            Dim entNuevo As New centrocosto
            Dim frm As New FormNuevoRubro
            frm.StartPosition = FormStartPosition.CenterParent
            frm.ShowDialog()
            Dim TempNodeText As String = frm.TextBox1.Text
            frm.Dispose()
            If TempNodeText.Trim <> "" Then
                Dim _Node As New TreeNode
                _Node.Text = TempNodeText
                _Node.ContextMenuStrip = cmAdministrar
                'trOrganigrama.SelectedNode.Nodes.Add(_Node)

                If (trOrganigrama.SelectedNode.Text = "EMPRESA") Then
                    centroCostoBE = New centrocosto
                    centroCostoBE.TipoEstab = "EM"
                Else
                    entNuevo = CType(trOrganigrama.SelectedNode.Tag, centrocosto)
                End If



                Select Case entNuevo.TipoEstab
                    Case Nothing

                        centroCostoBE = New centrocosto
                        centroCostoBE.idCentroCosto = listacentrocosto.Count + 1
                        centroCostoBE.idpadre = Nothing
                        centroCostoBE.nombre = TempNodeText
                        centroCostoBE.TipoEstab = "RU"
                        listacentrocosto.Add(centroCostoBE)
                        CrearNodosDelPadre()
                    Case "RU"
                        centroCostoBE = New centrocosto
                        centroCostoBE.idCentroCosto = listacentrocosto.Count + 1
                        centroCostoBE.idpadre = listacentrocosto.Where(Function(O) O.idCentroCosto = entNuevo.idCentroCosto And O.TipoEstab = "RU").FirstOrDefault.idCentroCosto
                        centroCostoBE.nombre = TempNodeText
                        centroCostoBE.TipoEstab = "SE"
                        listacentrocosto.Add(centroCostoBE)
                        CrearNodosDelPadre()
                    Case "SE"
                        centroCostoBE = New centrocosto
                        centroCostoBE.idCentroCosto = listacentrocosto.Count + 1
                        centroCostoBE.idpadre = listacentrocosto.Where(Function(O) O.idCentroCosto = entNuevo.idCentroCosto And O.TipoEstab = "SE").FirstOrDefault.idCentroCosto
                        centroCostoBE.nombre = TempNodeText
                        centroCostoBE.TipoEstab = "UN"
                        listacentrocosto.Add(centroCostoBE)
                        CrearNodosDelPadre()
                    Case "UN"
                        MessageBox.Show("NO PUEDE AGREGAR EN NIVEL")
                End Select
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub EditarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarToolStripMenuItem.Click
        Try
            Dim frm As New FormNuevoRubro
            frm.TextBox1.Text = trOrganigrama.SelectedNode.Text
            frm.ShowDialog()
            Dim TempNodeText As String = frm.TextBox1.Text
            frm.Dispose()
            'Dim SelectedNode As TreeNode = trOrganigrama.SelectedNode
            If TempNodeText.Trim <> "" Then

                Dim entNuevo = CType(trOrganigrama.SelectedNode.Tag, centrocosto)

                'SelectedNode.Text = TempNodeText
                Dim centroCostosModificar = listacentrocosto.Where(Function(O) O.idCentroCosto = entNuevo.idCentroCosto).FirstOrDefault

                centroCostosModificar.nombre = TempNodeText
                CrearNodosDelPadre()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click
        Try
            Dim entNuevo = CType(trOrganigrama.SelectedNode.Tag, centrocosto)
            trOrganigrama.Nodes.Remove(trOrganigrama.SelectedNode)
            listacentrocosto.Remove((entNuevo))
            CrearNodosDelPadre()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TrOrganigrama_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles trOrganigrama.AfterSelect

    End Sub

#End Region


End Class