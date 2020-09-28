Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class UFCrearRuta

#Region "Attributes"
    Public Property FormPurchase As FormTablaPrincipalTransportes
    Dim listaRegiones As New List(Of regiones)
    Dim ListaProvinvias As List(Of provincias)
    Dim ListaDistritos As List(Of distritos)
    Dim ListaCentroCostos As List(Of centrocosto)
    Dim ListaCentroCostosOrigen As List(Of centrocosto)
    Dim ListaCentroCostosDestino As List(Of centrocosto)
    Dim listaAgenciasSubRutasDestino As New List(Of centrocosto)
    Dim listaAgenciasSubRutasOrigen As New List(Of centrocosto)

    Dim listaSubRutasNuevas As New List(Of centrocosto)


    Dim listaCentroCostosID As New List(Of Integer)
#End Region


#Region "Constructors"
    Public Sub New(FormventaNueva As FormTablaPrincipalTransportes)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormPurchase = FormventaNueva
    End Sub


    Public Sub CARGARDATOS()
        CargarUbigeo()
        CargarCentroCosto()
        GetTableGrid()
    End Sub

#End Region

#Region "Methods"
    Sub GetTableGrid()
        Dim dt As New DataTable()

        dt.Columns.Add("ID", GetType(Integer))
        dt.Columns.Add("ORIGEN", GetType(String))
        dt.Columns.Add("DESTINO", GetType(String))
        dt.Columns.Add("RECORRIDO", GetType(Decimal))
        dt.Columns.Add("MANUAL", GetType(Boolean))

        GridTotales.DataSource = dt
    End Sub


    Public Sub AgregarSubRuta()
        Try
            Dim obj As New centrocosto

            If (GridTotales.Table.Records.Count > 0) Then
                For Each ITEM In GridTotales.Table.Records
                    listaCentroCostosID.Add(ITEM.GetValue("DESTINO"))
                Next
            End If

            listaAgenciasSubRutasDestino = ListaCentroCostos.Where(Function(o) Not listaCentroCostosID.Contains(o.idCentroCosto)).ToList


            listaAgenciasSubRutasOrigen = ListaCentroCostos.Where(Function(o) o.idCentroCosto <> ComboAgenciaDestino.SelectedValue).ToList

            GridTotales.Table.AddNewRecord.SetCurrent()
            GridTotales.Table.AddNewRecord.BeginEdit()
            GridTotales.Table.CurrentRecord.SetValue("ID", 1)
            GridTotales.Table.CurrentRecord.SetValue("ORIGEN", listaAgenciasSubRutasOrigen)
            GridTotales.Table.CurrentRecord.SetValue("DESTINO", listaAgenciasSubRutasDestino)
            GridTotales.Table.CurrentRecord.SetValue("ORIGEN", listaAgenciasSubRutasOrigen)
            GridTotales.Table.CurrentRecord.SetValue("RECORRIDO", 0.0)
            GridTotales.Table.CurrentRecord.SetValue("MANUAL", True)
            GridTotales.Table.AddNewRecord.EndEdit()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub




    Private Sub CargarCentroCosto()
        Try
            Dim CentrocostosSA As New CentrocostosSA
            ListaCentroCostos = New List(Of centrocosto)
            ListaCentroCostosOrigen = New List(Of centrocosto)
            ListaCentroCostosDestino = New List(Of centrocosto)

            ListaCentroCostos = CentrocostosSA.GetObtenerEstablecimiento(Gempresas.IdEmpresaRuc).ToList

            ListaCentroCostosOrigen = ListaCentroCostos
            ListaCentroCostosDestino = ListaCentroCostos

            ComboAgenciaOrigen.DataSource = ListaCentroCostosOrigen.ToList
            ComboAgenciaOrigen.ValueMember = "idCentroCosto"
            ComboAgenciaOrigen.DisplayMember = "nombre"

            ComboAgenciaDestino.DataSource = ListaCentroCostosDestino.Where(Function(o) o.idCentroCosto <> ComboAgenciaOrigen.SelectedValue).ToList
            ComboAgenciaDestino.ValueMember = "idCentroCosto"
            ComboAgenciaDestino.DisplayMember = "nombre"

            GetRegion(ListaCentroCostosOrigen.Where(Function(x) x.idCentroCosto = ComboAgenciaOrigen.SelectedValue).FirstOrDefault.ubigeo)

            Dim IDCARGO = ComboAgenciaDestino.SelectedValue

            If (IDCARGO > 0) Then
                GetRegionDestino(ListaCentroCostosDestino.Where(Function(x) x.idCentroCosto = ComboAgenciaDestino.SelectedValue).FirstOrDefault.ubigeo)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CargarUbigeo()
        Try
            Dim regioneSA As New regionesSA
            listaRegiones = regioneSA.ListarUbigeosActivos()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub GetRegion(idUbigeo As String)
        Try
            Dim regionesBE As New regiones
            Dim UBIGEO As String

            UBIGEO = (idUbigeo.Substring(0, 2)) & "0000"

            regionesBE = listaRegiones.Where(Function(i) i.id = UBIGEO).FirstOrDefault

            txtRegionOrigen.Text = regionesBE.name
            txtRegionOrigen.Tag = regionesBE.id

            GetProvincias(idUbigeo)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub GetProvincias(idUbigeo As String)
        Try
            Dim provinciasBE As New provincias
            Dim UBIGEO As String

            UBIGEO = (idUbigeo.Substring(0, 2)) & "0000"

            For Each i In listaRegiones
                ListaProvinvias = i.provincias.Where(Function(o) o.region_id = UBIGEO).ToList
                If (ListaProvinvias.Count > 0) Then
                    Exit For
                End If
            Next

            Dim UBIGEOPRO As String
            UBIGEOPRO = (idUbigeo.Substring(0, 4)) & "00"
            'UBIGEOPRO = String.Format("{0:00}", idUbigeo.Substring(0, 4))
            provinciasBE = ListaProvinvias.Where(Function(i) i.id = UBIGEOPRO).FirstOrDefault

            txtProvinciaOrigen.Text = provinciasBE.name
            txtProvinciaOrigen.Tag = provinciasBE.id

            GetDistrito(idUbigeo)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub GetDistrito(idUbigeo As String)
        Try
            Dim distritoBE As New distritos
            Dim UBIGEO As String

            UBIGEO = (idUbigeo.Substring(0, 4)) & "00"


            For Each i In listaRegiones
                For Each x In i.provincias.ToList
                    ListaDistritos = x.distritos.Where(Function(o) o.province_id = UBIGEO).ToList
                    If (ListaDistritos.Count > 0) Then
                        Exit For
                    End If
                Next
                If (ListaDistritos.Count > 0) Then
                    Exit For
                End If
            Next

            Dim UBIGEODIS As String

            UBIGEODIS = idUbigeo

            distritoBE = ListaDistritos.Where(Function(i) i.id = UBIGEODIS).FirstOrDefault

            txtDistritoOrigen.Text = distritoBE.name
            txtDistritoOrigen.Tag = distritoBE.id

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub GetRegionDestino(idUbigeo As String)
        Try
            Dim regionesBE As New regiones
            Dim UBIGEO As String

            UBIGEO = (idUbigeo.Substring(0, 2)) & "0000"

            regionesBE = listaRegiones.Where(Function(i) i.id = UBIGEO).FirstOrDefault

            txtRegionDestino.Text = regionesBE.name
            txtRegionDestino.Tag = regionesBE.id

            GetProvinciasDestino(idUbigeo)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub GetProvinciasDestino(idUbigeo As String)
        Try
            Dim provinciasBE As New provincias
            Dim UBIGEO As String

            UBIGEO = (idUbigeo.Substring(0, 2)) & "0000"

            For Each i In listaRegiones
                ListaProvinvias = i.provincias.Where(Function(o) o.region_id = UBIGEO).ToList
                If (ListaProvinvias.Count > 0) Then
                    Exit For
                End If
            Next

            Dim UBIGEOPRO As String
            UBIGEOPRO = (idUbigeo.Substring(0, 4)) & "00"
            'UBIGEOPRO = String.Format("{0:00}", idUbigeo.Substring(0, 4))
            provinciasBE = ListaProvinvias.Where(Function(i) i.id = UBIGEOPRO).FirstOrDefault

            txtProvinciaDestino.Text = provinciasBE.name
            txtProvinciaDestino.Tag = provinciasBE.id

            GetDistritoDestino(idUbigeo)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub GetDistritoDestino(idUbigeo As String)
        Try

            Dim distritoBE As New distritos
            Dim UBIGEO As String

            UBIGEO = (idUbigeo.Substring(0, 4)) & "00"


            For Each i In listaRegiones
                For Each x In i.provincias.ToList
                    ListaDistritos = x.distritos.Where(Function(o) o.province_id = UBIGEO).ToList
                    If (ListaDistritos.Count > 0) Then
                        Exit For
                    End If
                Next
                If (ListaDistritos.Count > 0) Then
                    Exit For
                End If
            Next

            Dim UBIGEODIS As String

            UBIGEODIS = idUbigeo

            distritoBE = ListaDistritos.Where(Function(i) i.id = UBIGEODIS).FirstOrDefault

            txtCiudadDestino.Text = distritoBE.name
            txtCiudadDestino.Tag = distritoBE.id

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cargarCombosDATA(listaCentroCostosID As List(Of Integer))
        Try

            listaAgenciasSubRutasDestino = ListaCentroCostos.Where(Function(o) Not listaCentroCostosID.Contains(o.idCentroCosto)).ToList

            Dim ggcStyle2 As GridTableCellStyleInfo = GridTotales.TableDescriptor.Columns(2).Appearance.AnyRecordFieldCell
            ggcStyle2.CellType = "ComboBox"
            ggcStyle2.DataSource = listaAgenciasSubRutasDestino
            ggcStyle2.ValueMember = "idCentroCosto"
            ggcStyle2.DisplayMember = "nombre"
            ggcStyle2.DropDownStyle = GridDropDownStyle.Exclusive
            GridTotales.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
            GridTotales.ShowRowHeaders = False


            listaAgenciasSubRutasOrigen = ListaCentroCostos.Where(Function(o) o.idCentroCosto <> ComboAgenciaDestino.SelectedValue).ToList

            Dim ggcStyle3 As GridTableCellStyleInfo = GridTotales.TableDescriptor.Columns(1).Appearance.AnyRecordFieldCell
            ggcStyle3.CellType = "ComboBox"
            ggcStyle3.DataSource = listaAgenciasSubRutasOrigen
            ggcStyle3.ValueMember = "idCentroCosto"
            ggcStyle3.DisplayMember = "nombre"
            ggcStyle3.DropDownStyle = GridDropDownStyle.Exclusive

            GridTotales.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
            GridTotales.ShowRowHeaders = False

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub chHabilitarRutas_CheckedChanged(sender As Object, e As EventArgs) Handles chHabilitarRutas.CheckedChanged
        Try


            If (chHabilitarRutas.Checked = True) Then
                tabSubRutas.TabVisible = True

                listaCentroCostosID.Add(ComboAgenciaOrigen.SelectedValue)
                listaCentroCostosID.Add(ComboAgenciaDestino.SelectedValue)

                GBRuta.Enabled = True
                GBOrigen.Enabled = False
                GBDestino.Enabled = False


                txtRutaOrigen.Text = ComboAgenciaOrigen.Text
                txtRutaDestino.Text = ComboAgenciaDestino.Text

                cargarCombosDATA(listaCentroCostosID)

            ElseIf (chHabilitarRutas.Checked = False) Then

                txtRutaOrigen.Clear()
                txtRutaDestino.Clear()
                GridTotales.Table.Records.DeleteAll()

                tabSubRutas.TabVisible = False
                GBRuta.Enabled = False
                GBOrigen.Enabled = True
                GBDestino.Enabled = True
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ComboAgenciaDestino_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboAgenciaDestino.SelectionChangeCommitted
        GetRegionDestino(ListaCentroCostosDestino.Where(Function(x) x.idCentroCosto = ComboAgenciaDestino.SelectedValue).FirstOrDefault.ubigeo)
    End Sub

    Private Sub ComboAgenciaOrigen_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboAgenciaOrigen.SelectionChangeCommitted
        GetRegion(ListaCentroCostosOrigen.Where(Function(x) x.idCentroCosto = ComboAgenciaOrigen.SelectedValue).FirstOrDefault.ubigeo)
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            If (ComboAgenciaOrigen.Text.Length = 0) Then
                MessageBox.Show("DEBE INGRESAR AGENCIA ORIGEN")
                Exit Sub
            End If

            If (ComboAgenciaDestino.Text.Length = 0) Then
                MessageBox.Show("DEBE INGRESAR AGENCIA DESTINO")
                Exit Sub
            End If

            AgregarSubRuta()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
        Try
            If (Not IsNothing(GridTotales.Table.CurrentRecord)) Then
                GridTotales.Table.CurrentRecord.Delete()
            Else
                MessageBox.Show("DEBE SELECCIONAR UN CAMPO")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton11_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton11.Click
        Try
            Dim RutaSA As New RutasSA
            Dim rutaBE As New rutas
            Dim listaSubRutas As New List(Of rutas)
            Dim CONTEO As Integer = 1

            If (chHabilitarRutas.Checked = True) Then
                For Each item In GridTotales.Table.Records

                    If (CONTEO = 1) Then
                        Dim subrutaDestino = ListaCentroCostos.Where(Function(o) o.idCentroCosto = item.GetValue("DESTINO")).FirstOrDefault
                        Dim subrutaOrigen = ListaCentroCostos.Where(Function(o) o.idCentroCosto = item.GetValue("ORIGEN")).FirstOrDefault

                        rutaBE = New rutas With {
                .[codigo] = "SR",
                .[km] = item.GetValue("RECORRIDO"),
                .[ciudadOrigen] = ComboAgenciaOrigen.SelectedValue,
            .[ciudadOrigenUbigeo] = txtDistritoOrigen.Tag,
            .[ciudadOrigenDomicilio] = TexDomicilioOrigen.Text,
                .[ciudadDestino] = subrutaDestino.idCentroCosto,
                .[ciudadDestinoUbigeo] = subrutaDestino.ubigeo,
                .[ciudadDestinoDomicilio] = subrutaDestino.direccion,
                .[idpadre] = Nothing,
                .[estado] = 1,
                .[usuarioActualizacion] = usuario.IDUsuario,
                .[fechaActualizacion] = Date.Now
                        }

                        listaSubRutas.Add(rutaBE)

                    ElseIf (CONTEO = GridTotales.Table.Records.Count) Then

                        Dim subrutaDestino = ListaCentroCostos.Where(Function(o) o.idCentroCosto = item.GetValue("DESTINO")).FirstOrDefault
                        Dim subrutaOrigen = ListaCentroCostos.Where(Function(o) o.idCentroCosto = item.GetValue("ORIGEN")).FirstOrDefault

                        rutaBE = New rutas With {
                .[codigo] = "SR",
                .[km] = item.GetValue("RECORRIDO"),
                .[ciudadOrigen] = subrutaOrigen.idCentroCosto,
                .[ciudadOrigenUbigeo] = subrutaOrigen.ubigeo,
                .[ciudadOrigenDomicilio] = subrutaOrigen.direccion,
               .[ciudadDestino] = ComboAgenciaDestino.SelectedValue,
            .[ciudadDestinoUbigeo] = txtCiudadDestino.Tag,
            .[ciudadDestinoDomicilio] = TexDomicilioDestino.Text,
                .[idpadre] = Nothing,
                .[estado] = 1,
                .[usuarioActualizacion] = usuario.IDUsuario,
                .[fechaActualizacion] = Date.Now
                        }

                        listaSubRutas.Add(rutaBE)
                    Else
                        Dim subrutaDestino = ListaCentroCostos.Where(Function(o) o.idCentroCosto = item.GetValue("DESTINO")).FirstOrDefault
                        Dim subrutaOrigen = ListaCentroCostos.Where(Function(o) o.idCentroCosto = item.GetValue("ORIGEN")).FirstOrDefault

                        rutaBE = New rutas With {
                .[codigo] = "SR",
                .[km] = item.GetValue("RECORRIDO"),
                .[ciudadOrigen] = subrutaOrigen.idCentroCosto,
                .[ciudadOrigenUbigeo] = subrutaOrigen.ubigeo,
                .[ciudadOrigenDomicilio] = subrutaOrigen.direccion,
                .[ciudadDestino] = subrutaDestino.idCentroCosto,
                .[ciudadDestinoUbigeo] = subrutaDestino.ubigeo,
                .[ciudadDestinoDomicilio] = subrutaDestino.direccion,
                .[idpadre] = Nothing,
                .[estado] = 1,
                .[usuarioActualizacion] = usuario.IDUsuario,
                .[fechaActualizacion] = Date.Now
                        }

                        listaSubRutas.Add(rutaBE)
                    End If

                    CONTEO = CONTEO + 1
                Next
            End If

            rutaBE = New rutas With {
            .[codigo] = "RT",
            .[km] = TextBoxExt1.Text,
            .[ciudadOrigen] = ComboAgenciaOrigen.SelectedValue,
            .[ciudadOrigenUbigeo] = txtDistritoOrigen.Tag,
            .[ciudadOrigenDomicilio] = TexDomicilioOrigen.Text,
            .[ciudadDestino] = ComboAgenciaDestino.SelectedValue,
            .[ciudadDestinoUbigeo] = txtCiudadDestino.Tag,
            .[ciudadDestinoDomicilio] = TexDomicilioDestino.Text,
            .[idpadre] = Nothing,
            .[estado] = 1,
            .[usuarioActualizacion] = usuario.IDUsuario,
            .[fechaActualizacion] = Date.Now,
            .ListaSubRutas = listaSubRutas
                }

            RutaSA.InsertarRuta(rutaBE)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Try
            FormPurchase.UCMaestroRutas.Visible = True

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region

#Region "Events"

#End Region


End Class
