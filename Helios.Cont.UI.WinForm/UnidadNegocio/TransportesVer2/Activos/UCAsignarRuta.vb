Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Public Class UCAsignarRuta

#Region "Attributes"
    Public Property ActivoSA As New ActivosFijosSA
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
#End Region

#Region "Methods"
    Sub GetVehiculosPorNroSerie(placaSerie As String)
        Dim listaVehiculos = ActivoSA.GetListar_activosFijosSeriePlaca(New Business.Entity.activosFijos With
                                                                       {
                                                                       .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                       .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                       .nroSeriePlaca = placaSerie
                                                                       })


        If listaVehiculos.Count > 0 Then
            TextSeriePlaca.Text = $"{listaVehiculos.FirstOrDefault.nroSeriePlaca}-{listaVehiculos.FirstOrDefault.descripcionItem}"
            TextSeriePlaca.Tag = listaVehiculos.FirstOrDefault
            TextSeriePlaca.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)


            'If MessageBox.Show("Se encontró vehiculo(s), desea agregarlo(s) ahora?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            '    For Each i In listaVehiculos
            '        Dim n As New ListViewItem(i.idActivo)
            '        n.SubItems.Add(i.descripcionItem)
            '        n.SubItems.Add(i.anio)
            '        n.SubItems.Add(i.modelo)
            '        n.SubItems.Add(i.marca)
            '        n.SubItems.Add(i.color)
            '        n.SubItems.Add(i.motor)
            '        n.SubItems.Add(i.nroSeriePlaca)
            '        ListView1.Items.Add(n)
            '    Next
            'End If
        Else
            TextSeriePlaca.ForeColor = Color.Black
        End If
    End Sub

    Private Sub GetRuta(codigo As String)
        Dim rutaSA As New RutasSA
        Dim ruta = rutaSA.GetRutaSelCodigo(New Business.Entity.rutas With
                                          {
                                          .codigo = codigo
                                          })

        If ruta IsNot Nothing Then
            TextCodigoRuta.Text = $"{ruta.ciudadOrigen}-{ruta.ciudadDestino}"
            TextCodigoRuta.Tag = ruta
            TextCodigoRuta.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        End If
    End Sub

    Private Sub ConfirmarRutas()
        Dim tareoSA As New RutaTareoAutoSA
        Dim obj As New rutaTareoAutos
        Dim lista As New List(Of rutaTareoAutos)

        For Each i As ListViewItem In ListView1.Items

            obj = New rutaTareoAutos With
                {
                .idVehiculo = Integer.Parse(i.SubItems(0).Text),
                .ruta_id = Integer.Parse(i.SubItems(4).Text),
                .horario_id = Integer.Parse(i.SubItems(7).Text),
                .nroPlaca = i.SubItems(3).Text,
                .tipoTareo = 1,
                .fechaOperacion = DateTime.Now,
                .nroPasajeros = 0,
                .nroTripulantes = 0,
                .estado = 1,
                .usuarioActualizacion = usuario.IDUsuario,
                .fechaActualizacion = Date.Now
            }
            lista.Add(obj)
        Next

        tareoSA.GetListaSaveTareo(lista)
        MessageBox.Show("Registro relizado con exito!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ListView1.Items.Clear()
        TextCodigoRuta.Clear()
        TextCodigoRuta.Tag = Nothing
        TextSeriePlaca.Clear()
        TextSeriePlaca.Tag = Nothing
    End Sub
#End Region

#Region "Events"
    Private Sub TextCiudadOrigen_KeyDown(sender As Object, e As KeyEventArgs) Handles TextSeriePlaca.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If TextSeriePlaca.Text.Trim.Length > 0 Then
                GetVehiculosPorNroSerie(TextSeriePlaca.Text.Trim)
            End If
        End If
    End Sub

    Private Sub RoundButton22_Click(sender As Object, e As EventArgs) Handles RoundButton22.Click
        If ListView1.SelectedItems.Count > 0 Then
            ListView1.SelectedItems(0).Remove()
        Else
            MessageBox.Show("Debe seleccionar un item válido!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub TextCodigoRuta_KeyDown(sender As Object, e As KeyEventArgs) Handles TextCodigoRuta.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If TextCodigoRuta.Text.Trim.Length > 0 Then
                GetRuta(TextCodigoRuta.Text.Trim)
            End If
        End If
    End Sub

    Private Sub TextSeriePlaca_TextChanged(sender As Object, e As EventArgs) Handles TextSeriePlaca.TextChanged
        TextSeriePlaca.ForeColor = Color.Black
        TextSeriePlaca.Tag = Nothing
    End Sub

    Private Sub TextCodigoRuta_TextChanged(sender As Object, e As EventArgs) Handles TextCodigoRuta.TextChanged
        TextCodigoRuta.ForeColor = Color.Black
        TextCodigoRuta.Tag = Nothing
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        If TextSeriePlaca.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            If TextCodigoRuta.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
                Dim auto = CType(TextSeriePlaca.Tag, activosFijos)
                Dim ruta = CType(TextCodigoRuta.Tag, rutas)

                Dim n As New ListViewItem(auto.idActivo)
                n.SubItems.Add(auto.descripcionItem)
                n.SubItems.Add(auto.color)
                n.SubItems.Add(auto.anio)

                n.SubItems.Add(ruta.ruta_id)
                n.SubItems.Add($"{ruta.ciudadOrigen}-{ruta.ciudadDestino}")
                n.SubItems.Add(ruta.km)
                n.SubItems.Add(ruta.ruta_horarios.FirstOrDefault.horario_id)
                ListView1.Items.Add(n)
            End If
        End If
    End Sub

    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        If ListView1.Items.Count > 0 Then
            ConfirmarRutas()
        End If
    End Sub

#End Region

End Class
