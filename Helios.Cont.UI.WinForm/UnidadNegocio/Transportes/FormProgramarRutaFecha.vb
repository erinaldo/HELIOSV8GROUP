Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General

Public Class FormProgramarRutaFecha
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        getCargarCombos()
        TextFechaProgramada.Value = Date.Now
        TextHora.Value = Date.Now
        cboActivosFijos.Visible = True
    End Sub

    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        GrabarRuta()
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
            cboActivosFijos.DisplayMember = "nroSeriePlaca"
            cboActivosFijos.ReadOnly = False
        End If
    End Sub

    Private Sub GrabarRuta()
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
            .tipo = If(RBIda.Checked = True, "I", "V"),
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

            listaDistribucion = distribucionSA.getInfraestructuraTransporte(distribucionInfraestructuraBE)

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
            Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CboActivosFijos_Click(sender As Object, e As EventArgs) Handles cboActivosFijos.Click

    End Sub

    Private Sub FormProgramarRutaFecha_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextFechaProgramada.MinValue = DateTime.Today
    End Sub

    Private Sub TxtFondoMN_ValueChanged(sender As Object, e As EventArgs) Handles txtFondoMN.ValueChanged

    End Sub

    Private Sub TxtFondoMN_Click(sender As Object, e As EventArgs) Handles txtFondoMN.Click
        txtFondoMN.Select(0, txtFondoMN.Text.Length)
    End Sub

    Private Sub TxtManifiesto_Click(sender As Object, e As EventArgs) Handles txtManifiesto.Click
        txtManifiesto.Select(0, txtManifiesto.Text.Length)
    End Sub

    Private Sub CboActivosFijos_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboActivosFijos.SelectionChangeCommitted
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
End Class