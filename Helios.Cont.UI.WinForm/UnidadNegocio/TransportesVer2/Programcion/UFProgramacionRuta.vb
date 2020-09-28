Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class UFProgramacionRuta

#Region "Attributes"
    Public Property FormPurchase As FormTablaPrincipalTransportes

#End Region


#Region "Constructors"
    Public Sub New(FormventaNueva As FormTablaPrincipalTransportes)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormPurchase = FormventaNueva
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Me.Visible = False
        If FormPurchase.UCMaestroProgramacion IsNot Nothing Then
            FormPurchase.UCMaestroProgramacion.Visible = True
            FormPurchase.UCMaestroProgramacion.BringToFront()
            FormPurchase.UCMaestroProgramacion.Show()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim f As New FormProgramacionSimple
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim ent = CType(f.Tag, rutas)
            TextRuta.Text = ent.ciudadOrigen
            TextRuta.Tag = ent.ruta_id
        Else
            TextRuta.Text = String.Empty
            TextRuta.Tag = Nothing
        End If
    End Sub

#End Region

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
            cboActivosFijos.DisplayMember = "nroSeriePlaca"
            cboActivosFijos.ReadOnly = False
        End If
    End Sub

    Private Sub cboActivosFijos_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboActivosFijos.SelectionChangeCommitted
        Try

            Dim listaDistribucion As New List(Of distribucionInfraestructura)
            Dim conteoAsientos As Integer = 0

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
            distribucionInfraestructuraBE.SubCategoria = cboActivosFijos.SelectedValue

            listaDistribucion = distribucionInfraestructuraSA.getInfraestructuraTransporte(distribucionInfraestructuraBE)

            If (listaDistribucion.Count > 0) Then
                conteoAsientos = listaDistribucion.Where(Function(o) o.estado = "A").Count
                txtNumeroAsientos.Text = conteoAsientos
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub UFProgramacionRuta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextFechaProgramada.MinValue = DateTime.Today
    End Sub

    Private Sub BunifuFlatButton11_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton11.Click
        Try

            If (cboActivosFijos.Text.Length = 0) Then
                    MessageBox.Show("DEBE INGRESAR UN PLACA")
                    Exit Sub
                End If

                If (txtManifiesto.Text.Length = 0) Then
                    MessageBox.Show("DEBE INGRESAR UN MANIFIESTO")
                    txtManifiesto.Select()
                    txtManifiesto.Focus()
                    Exit Sub
                End If


                Dim detalleitemSA As New detalleitemsSA
                Dim detalleItemBE As New detalleitems

                Dim rutaSA As New RutaProgramacionSalidasSA
            Dim ruta As New rutaProgramacionSalidas With
                {
                .ruta_id = Integer.Parse(TextRuta.Tag),
                .tipo = "I",' If(RBIda.Checked = True, "I", "V"),
                .fechaProgramacion = New DateTime(TextFechaProgramada.Value.Year,
                TextFechaProgramada.Value.Month,
                TextFechaProgramada.Value.Day, TextHora.Value.TimeOfDay.Hours, TextHora.Value.TimeOfDay.Minutes, 0),
                .estado = 1,
                .idActivo = cboActivosFijos.SelectedValue,
                .manifiesto = txtManifiesto.Text,
                .usuarioActualizacion = usuario.IDUsuario,
                .fechaActualizacion = Date.Now
                }


            '//
            Dim distribucionSA As New distribucionInfraestructuraSA
                Dim listaDistribucion As New List(Of distribucionInfraestructura)
                Dim distribucionInfraestructuraBE As New distribucionInfraestructura


            distribucionInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
            distribucionInfraestructuraBE.tipo = "C"
            distribucionInfraestructuraBE.idActivo = cboActivosFijos.SelectedValue

            listaDistribucion = distribucionSA.getDistribucionInfraestructura(distribucionInfraestructuraBE)

            Dim vehiculoASiento As vehiculoAsiento_Precios
                Dim listaVehiculoASiento As New List(Of vehiculoAsiento_Precios)

            If (listaDistribucion.Count > 0) Then
                detalleItemBE = detalleitemSA.GetUbicaProductoID(listaDistribucion(0).idDetalleItem)
            End If


            For Each item In listaDistribucion
                    vehiculoASiento = New vehiculoAsiento_Precios With
                {
                .[ruta_id] = Integer.Parse(TextRuta.Tag),
                .[horario_id] = Integer.Parse(TextRuta.Tag),
                .[codigoServicio] = 1,
                 .[idDistribucion] = item.idDistribucion,
                .[idComponente] = item.idComponente,
                .[idEmpresa] = Gempresas.IdEmpresaRuc,
                .[idEstablecimiento] = GEstableciento.IdEstablecimiento,
                .[programacion_id] = Nothing,
                .[tareo_id] = Nothing,
                 .[idDocumentoVenta] = Nothing,
                .[idActivo] = cboActivosFijos.SelectedValue,
                .[vence] = Nothing,
                .[numeracion] = item.numeracion,
                .precioAsientoMN = txtFondoMN.Value,
               .precioAsientoME = 0.0,
                .moneda = "NAC",
                .origen = detalleItemBE.origenProducto,
                  .idItem = detalleItemBE.idItem,
                    .descripcionItem = detalleItemBE.descripcionItem,
                      .destino = detalleItemBE.origenProducto,
                .[estado] = item.estado,
                 .[usuarioActualizacion] = usuario.IDUsuario,
                .[fechaActualizacion] = Date.Now
                }
                    listaVehiculoASiento.Add(vehiculoASiento)
                Next

                Dim obj = rutaSA.programacionXBusXHorarioSave(ruta, listaVehiculoASiento)
                Tag = obj

                MessageBox.Show("Programación registrada!", "hecho!", MessageBoxButtons.OK, MessageBoxIcon.Information)


            Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
