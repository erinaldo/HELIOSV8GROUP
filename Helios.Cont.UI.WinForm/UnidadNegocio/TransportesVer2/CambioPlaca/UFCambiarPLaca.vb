Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class UFCambiarPLaca
#Region "Attributes"
    Public Property FormPurchase As FormTablaPrincipalTransportes

    Dim activosFijosBE As New List(Of activosFijos)
    Dim ObjvehiculoBE As New List(Of vehiculoAsiento_Precios)
    Public Property programacionAnterior As Integer
#End Region

#Region "Constructors"
    Public Sub New(formventaNueva As FormTablaPrincipalTransportes)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        FormPurchase = formventaNueva

    End Sub

    Private Sub BunifuFlatButton11_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton11.Click
        GrabarRuta()
    End Sub
#End Region

#Region "Methods"
    Private Sub GrabarRuta()
        Try
            Dim IDITEM As Integer = 0
            Dim DESCRICCIONITEM As String = String.Empty
            Dim DESTINO As String = 0

            If (cboActivosFijos.Text.Length = 0) Then
                MessageBox.Show("DEBE SELECCIONAR UN BUS")
                Exit Sub
            End If

            If (CInt(lblVendedios.Text) <= CInt(lblTotalAsientos.Text)) Then

                'If (CInt(lblLibres.Text) <= CInt(lblTotalAsientos.Text)) Then

                Dim rutaSA As New RutaProgramacionSalidasSA
                Dim ruta As New rutaProgramacionSalidas With
            {
            .ruta_id = Integer.Parse(TextRuta.Tag),
            .tipo = "I",
            .fechaProgramacion = New DateTime(txtNuevaFecha.Value.Year,
            txtNuevaFecha.Value.Month,
            txtNuevaFecha.Value.Day, txtNuevaHora.Value.TimeOfDay.Hours, txtNuevaHora.Value.TimeOfDay.Minutes, 0),
            .estado = 1,
            .nroProgramcionAnterior = programacionAnterior,
            .idActivo = cboActivosFijos.SelectedValue,
            .manifiesto = 1,
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

                For Each item In listaDistribucion

                    Dim estadoNuevo As String
                    Dim COSNULTA = ObjvehiculoBE.Where(Function(O) O.numeracion = item.numeracion).SingleOrDefault

                    If (Not IsNothing(COSNULTA)) Then


                        IDITEM = COSNULTA.idItem.GetValueOrDefault
                        DESCRICCIONITEM = COSNULTA.descripcionItem
                        DESTINO = COSNULTA.destino
                        estadoNuevo = COSNULTA.estado

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
                .precioAsientoMN = 0,
                .precioAsientoME = 0.0,
                .moneda = "NAC",
                .origen = 2,
                .destino = COSNULTA.destino,
                .descripcionItem = COSNULTA.descripcionItem,
                .idItem = COSNULTA.idItem,
                            .[estado] = estadoNuevo,
                 .[usuarioActualizacion] = usuario.IDUsuario,
                .[fechaActualizacion] = Date.Now
                }
                        listaVehiculoASiento.Add(vehiculoASiento)
                    Else
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
                .precioAsientoMN = 0,
                .precioAsientoME = 0.0,
                .moneda = "NAC",
                .origen = 2,
                   .destino = DESTINO,
                .descripcionItem = DESCRICCIONITEM,
                .idItem = IDITEM,
                            .[estado] = "A",
                 .[usuarioActualizacion] = usuario.IDUsuario,
                .[fechaActualizacion] = Date.Now
                }
                        listaVehiculoASiento.Add(vehiculoASiento)
                    End If
                Next

                Dim obj = rutaSA.programacionXBusXCambioPlacaSave(ruta, listaVehiculoASiento)
                Tag = obj

                MessageBox.Show("Programación registrada!", "hecho!", MessageBoxButtons.OK, MessageBoxIcon.Information)

                'Else
                '    MessageBox.Show("El numero asientos supera el cambio permitido")
                'End If
            Else
                MessageBox.Show("El numero asientos supera el cambio permitido")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Sub cargarAgencias(idprogramacion As Integer, idActivo As Integer)
        Try

            Dim vehiculoBE As New vehiculoAsiento_Precios
            Dim vehiculoSA As New VehiculoAsiento_PreciosSA


            vehiculoBE.programacion_id = idprogramacion
            vehiculoBE.idActivo = idActivo

            ObjvehiculoBE = vehiculoSA.GetConsultarProgramacionXbusAsientos(vehiculoBE)

            lblLibres.Text = ObjvehiculoBE.Count
            lblReserva.Text = ObjvehiculoBE.Where(Function(o) o.estado = "R").Count
            lblVendedios.Text = ObjvehiculoBE.Where(Function(o) o.estado = "U").Count

            Dim ActivosFijosSA As New ActivosFijosSA

            Dim NuevoActivo As New activosFijos

            NuevoActivo.idActivo = 0
            NuevoActivo.descripcionItem = "Elija una opción"

            activosFijosBE.Add(NuevoActivo)
            activosFijosBE.AddRange(ActivosFijosSA.GetListar_activosFijosConteoAsientos())

            If NuevoActivo IsNot Nothing Then
                'cboActivosFijos.DataSource = activosFijosBE.Where(Function(o) o.idActivo <> idActivo).ToList
                cboActivosFijos.DataSource = activosFijosBE.ToList
                cboActivosFijos.ValueMember = "idActivo"
                cboActivosFijos.DisplayMember = "nroSeriePlaca"
                cboActivosFijos.ReadOnly = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub chBoxProgramacion_CheckedChanged(sender As Object, e As EventArgs) Handles chBoxProgramacion.CheckedChanged
        If (chBoxProgramacion.Checked = True) Then
            pnHora.Enabled = True
        ElseIf (chBoxProgramacion.Checked = False) Then
            pnHora.Enabled = False
        End If
    End Sub

    Private Sub cboActivosFijos_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboActivosFijos.SelectionChangeCommitted
        Try
            lblTotalAsientos.Text = activosFijosBE.Where(Function(o) o.idActivo = cboActivosFijos.SelectedValue).FirstOrDefault.usuarioActualizacion
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BunifuFlatButton1_Click_1(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Me.Visible = False
        FormPurchase.UCMaestroCambioPlaca.Visible = True
    End Sub

#End Region

#Region "Events"

#End Region

End Class
