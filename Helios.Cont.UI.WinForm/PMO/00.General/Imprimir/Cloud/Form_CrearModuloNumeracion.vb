Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes

Public Class Form_CrearModuloNumeracion
    Dim listaNumeracionBoleta As New List(Of numeracionBoletas)
    Dim listaAreaOperativa As New List(Of organizacion)
    Dim listaConfModuloBE As New List(Of moduloConfiguracion)
    Dim listaUnidadNegocio As New List(Of centrocosto)
    Dim listaPerfilAnexo As New List(Of perfilAnexo)
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        cargarComboAreaOperactiva()
        cargarCombo()
    End Sub

    Public Sub cargarComboUnidadNEgocio()
        Try

            Dim unidadNeogcioSA As New establecimientoSA


            listaUnidadNegocio = unidadNeogcioSA.ObtenerListaEstablecimientos(Gempresas.IdEmpresaRuc)


            cboUnidadNegocio.ValueMember = "idCentroCosto"
            cboUnidadNegocio.DisplayMember = "nombre"
            cboUnidadNegocio.DataSource = listaUnidadNegocio

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub cargarComboCargos(areaOperativa As Integer)
        Try

            Dim perfilSA As New perfilAnexoSA


            listaPerfilAnexo = perfilSA.GetObtenerPerfilAnexo(New perfilAnexo With {.idCentroCosto = areaOperativa})


            cboCargos.ValueMember = "tipo"
            cboCargos.DisplayMember = "descripcion"
            cboCargos.DataSource = listaPerfilAnexo

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub cargarComboAreaOperactiva()
        Try

            Dim areaOperativaSA As New OrganizacionSA

            listaAreaOperativa = areaOperativaSA.GetOrganizacion(New organizacion With {.idEmpresa = Gempresas.IdEmpresaRuc})

            cboAreaOperativa.ValueMember = "idOrganigrama"
            cboAreaOperativa.DisplayMember = "descripcion"
            cboAreaOperativa.DataSource = listaAreaOperativa
            cboAreaOperativa.SelectedValue = -1
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub cargarCombo()
        Try

            Dim numeracionBoletaSA As New NumeracionBoletaSA

            listaNumeracionBoleta = numeracionBoletaSA.GetListar_numeracionBoletasAll(New numeracionBoletas With {.empresa = Gempresas.IdEmpresaRuc, .establecimiento = GEstableciento.IdEstablecimiento})


            Dim configModuloSA As New ModuloConfiguracionSA

            Dim ConfModuloBE = New moduloConfiguracion

            Dim estado As String = String.Empty
            estado = "A"

            ConfModuloBE.idEstablecimiento = GEstableciento.IdEstablecimiento
            ConfModuloBE.idEmpresa = Gempresas.IdEmpresaRuc

            listaConfModuloBE = (configModuloSA.ListaModulosConfigurados(ConfModuloBE))

            cboTipo.ValueMember = "idConfiguracion"
            cboTipo.DisplayMember = "descripcionModulo"
            cboTipo.DataSource = listaConfModuloBE
            cboTipo.SelectedValue = -1

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub VerDetalleVenta(ID As String)
        Try
            Dim dt As New DataTable
            dt.Columns.Add("ID")
            dt.Columns.Add("DESCRIPCION")

            dgvCompras.Table.Records.DeleteAll()

            For Each i In listaNumeracionBoleta.Where(Function(O) O.codigoNumeracion = ID And O.empresa = Gempresas.IdEmpresaRuc).ToList
                dt.Rows.Add(i.codigoNumeracion,
                      i.serie)
            Next

            dgvCompras.DataSource = dt
            dgvCompras.Refresh()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Close()
    End Sub

    Private Sub cboTipo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboTipo.SelectionChangeCommitted
        Try

            Dim ModuloSeleccionado = listaConfModuloBE.Where(Function(O) O.idConfiguracion = cboTipo.SelectedValue).FirstOrDefault
            VerDetalleVenta(ModuloSeleccionado.idModulo)
            txtFormato.Text = ModuloSeleccionado.tipoDoc
            txtCodigoNum.Text = ModuloSeleccionado.idModulo

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton6_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton6.Click
        Try
            'Dim nueracionBolSA As New NumeracionBoletaSA
            Dim nueracionBolBE As New numeracionBoletas
            Dim distribucionNumeracionBE As New distribucionNumeracionAO
            Dim distribucionNumeracionSA As New distribucionNumeracionAOSA

            If (txtSerie.Text.Length <= 0) Then
                MessageBox.Show("DEBE INGRESAR UNA SERIE")
                Exit Sub
            End If

            Dim CONTEO As Integer = 0

            For Each ITEM In dgvCompras.Table.Records
                If (CStr(ITEM.GetValue("DESCRIPCION")) = cboTipo.SelectedValue) Then
                    CONTEO = CONTEO + 1
                End If
            Next

            If (CONTEO > 0) Then
                MessageBox.Show("YA EXISTE UNA SERIE IGUAL")
                Exit Sub
            End If

            Dim tipoDoc = listaConfModuloBE.Where(Function(o) o.idConfiguracion = cboTipo.SelectedValue).FirstOrDefault

            Dim unidad As Integer = 0
            Dim afectoUN As Boolean
            If (chAfectaUN.Checked = True) Then
                unidad = cboUnidadNegocio.SelectedValue
                afectoUN = True
            ElseIf (chAfectaUN.Checked = False) Then
                unidad = 0
                afectoUN = False
            End If

            nueracionBolBE = New numeracionBoletas With {
            .codigoNumeracion = tipoDoc.idModulo,
            .tipo = txtFormato.Text,
            .serie = txtSerie.Text,
            .valorInicial = 0,
            .empresa = Gempresas.IdEmpresaRuc,
            .establecimiento = unidad,
            .valorMinimo = 0,
            .valorMaximo = txtValormaximo.Text,
            .incremento = 1,
            .usuarioActualizacion = usuario.IDUsuario,
            .fechaActualizacion = DateTime.Now,
            .afectoUN = afectoUN
            }

            distribucionNumeracionBE = New distribucionNumeracionAO With {
                               .IdEnumeracion = tipoDoc.idConfiguracion,
               .idRol = tipoDoc.idModulo,
               .[estado] = "A",
               .idCargo = CInt(cboCargos.SelectedValue),
               .[usuarioActualizacion] = "ADMINISTRADOR",
               .[fechaActualizacion] = Date.Now,
               .numeracionBoletas = nueracionBolBE
            }

            distribucionNumeracionSA.InsertNumeracionXAreaOperativa(distribucionNumeracionBE)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub chAfectaUN_CheckedChanged(sender As Object, e As EventArgs) Handles chAfectaUN.CheckedChanged
        Try
            If (chAfectaUN.Checked = True) Then
                chAfectaUN.Checked = True
                cboUnidadNegocio.Visible = True
                cargarComboUnidadNEgocio()
            ElseIf (chAfectaUN.Checked = False) Then
                chAfectaUN.Checked = False
                cboUnidadNegocio.Visible = False
                cboUnidadNegocio.DataSource = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cboAreaOperativa_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboAreaOperativa.SelectionChangeCommitted
        Try
            cargarComboCargos(cboAreaOperativa.SelectedValue)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
