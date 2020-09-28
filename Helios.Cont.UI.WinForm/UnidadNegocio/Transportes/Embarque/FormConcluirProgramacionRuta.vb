Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Public Class FormConcluirProgramacionRuta

    Public Property formInherits As UCManifestoEnEspera
    Public Property ProgramacionSA As New RutaProgramacionSalidasSA

    Public Sub New(form As UCManifestoEnEspera)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        formInherits = form
        MappingControles()
        TextFechaEmbarque.Value = Date.Now
    End Sub

    Private Sub MappingControles()
        Dim activoSA As New ActivosFijosSA
        Dim prog = ProgramacionSA.ProgramacionSelID(New rutaProgramacionSalidas With
                                {
                                .programacion_id = Integer.Parse(formInherits.ListProgramacionEmbarque.SelectedItems(0).SubItems(0).Text)
                                })

        Dim idVehiculo As Integer = Integer.Parse(formInherits.ListPasajeros.Items(0).Tag)
        Dim vehiculo = activoSA.GetUbicar_activosFijosPorID(idVehiculo)

        TextRuta.Text = prog.CustomRutas.ciudadDestino
        TextRuta.Tag = prog.CustomRutas
        TextFechaProgramada.Tag = prog
        TextFechaProgramada.Value = prog.fechaProgramacion
        TextTipoEmbarque.Text = If(prog.tipo = "I", "IDA", "VUELTA")
        TextNumPasajeros.Text = formInherits.ListPasajeros.Items.Count
        TextSeriePlaca.Text = $"{vehiculo.descripcionItem}-{vehiculo.nroSeriePlaca}"
        TextSeriePlaca.Tag = vehiculo
        TextCodigoPlaca.Text = vehiculo.nroSeriePlaca
    End Sub

    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        If TextSeriePlaca.Text.Trim.Length > 0 Then

            GrabarConsolidacion()

        Else
            TextSeriePlaca.Select()
            MessageBox.Show("Debe indicar un vehiculo autorizado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Sub GetVehiculosPorNroSerie(placaSerie As String)
        Dim ActivoSA As New ActivosFijosSA
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


            TextCodigoPlaca.Text = listaVehiculos.FirstOrDefault.nroSeriePlaca
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
            MessageBox.Show("No se encontraron datos con el número serie/placa ingresado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextSeriePlaca.Focus()
            TextSeriePlaca.ForeColor = Color.Black
        End If
    End Sub

    Private Sub GrabarConsolidacion()
        Dim consolidacionSA As New RutaProgramacionSalidasSA
        Dim obj As New rutaTareoAutos
        Dim objDet As rutaTareoDetalle
        Dim Lista As New List(Of rutaTareoDetalle)

        Dim ruta = CType(TextRuta.Tag, rutas)
        Dim prog = CType(TextFechaProgramada.Tag, rutaProgramacionSalidas)
        Dim vehiculo = CType(TextSeriePlaca.Tag, activosFijos)

        obj.idVehiculo = vehiculo.idActivo ' Integer.Parse(TextSeriePlaca.Tag)
        obj.ruta_id = ruta.ruta_id
        obj.horario_id = ruta.ruta_horarios.First.horario_id
        obj.programacion_id = prog.programacion_id
        obj.fecha = TextFechaEmbarque.Value
        obj.nroPlaca = TextCodigoPlaca.Text.Trim
        obj.tipoTareo = TipotareoGeneral.LlegadaAdestino
        obj.fechaOperacion = Date.Now
        obj.nroPasajeros = Integer.Parse(TextNumPasajeros.Text)
        obj.nroTripulantes = Integer.Parse(TextNroTripulantes.IntegerValue)
        obj.estado = 1
        obj.usuarioActualizacion = usuario.IDUsuario
        obj.fechaActualizacion = Date.Now

        'detalle del tareo o manifiesto
        For Each i As ListViewItem In formInherits.ListPasajeros.Items
            If i.Checked = True Then
                objDet = New rutaTareoDetalle
                objDet.idVehiculo = obj.idVehiculo
                objDet.ruta_id = obj.ruta_id
                objDet.horario_id = obj.horario_id
                objDet.programacion_id = obj.programacion_id ' Integer.Parse(TextFechaProgramada.Tag)
                objDet.nroasiento = Integer.Parse(i.SubItems(0).Text)
                objDet.entidad_id = Integer.Parse(i.SubItems(1).Text)
                objDet.servicio_id = Integer.Parse(i.SubItems(7).Text)
                objDet.documentoVenta_id = Integer.Parse(i.SubItems(9).Text)
                objDet.servicio = i.SubItems(8).Text
                objDet.tipo = EntidadConsolidacion.Pasajeros
                objDet.idPadre = 0
                objDet.status = EntidadConsolidacionStatus.Pendiente
                objDet.usuarioActualizacion = usuario.IDUsuario
                objDet.fechaActualizacion = Date.Now
                Lista.Add(objDet)
            End If
        Next
        obj.rutaTareoDetalle = Lista
        consolidacionSA.GrabarConsolidacion(obj, Transporte.ProgramacionEstado.VehiculoAsignadoRutaCulminada)
        formInherits.ConfirmarProgramacionRuta()
        MessageBox.Show("Ruta culminada con exito!", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close()
    End Sub

    Private Sub TextSeriePlaca_TextChanged(sender As Object, e As EventArgs) Handles TextSeriePlaca.TextChanged

    End Sub

    Private Sub TextSeriePlaca_KeyDown(sender As Object, e As KeyEventArgs) Handles TextSeriePlaca.KeyDown

    End Sub

End Class