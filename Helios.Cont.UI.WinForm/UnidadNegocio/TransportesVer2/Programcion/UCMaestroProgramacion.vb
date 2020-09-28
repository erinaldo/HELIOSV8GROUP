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
Imports HtmlAgilityPack

Public Class UCMaestroProgramacion

    Public Property FormPurchase As FormTablaPrincipalTransportes
    Private Const FormatoFecha As String = "yyyy-MM-dd"
    Dim listaCentroCosnto As New List(Of centrocosto)

    Public Sub New(formventaNueva As FormTablaPrincipalTransportes)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormPurchase = formventaNueva
    End Sub

#Region "METODO"

    Public Sub CargarDatos()
        FormatoGridTouch(GridCompra, False, False, 14.0F)
        TextFechaProgramada.Value = Date.Now
        cargarEstablecimiento()
        GetDocumentoVentaID()
    End Sub

    Public Sub cargarEstablecimiento()
        Dim centrosa As New establecimientoSA
        listaCentroCosnto = centrosa.ObtenerListaEstablecimientos(Gempresas.IdEmpresaRuc)
    End Sub

    Public Sub GetDocumentoVentaID()
        Try
            Dim status As String = String.Empty
            Dim rutaSA As New RutaProgramacionSalidasSA
            Dim dt As New DataTable

            GridCompra.Table.Records.DeleteAll()

            Dim lista = rutaSA.GetProgramacionPorFechaLaboral(New rutaProgramacionSalidas With
                                                              {
                                                              .fechaProgramacion = TextFechaProgramada.Value
                                                              }).OrderByDescending(Function(O) O.fechaProgramacion).ToList


            With dt.Columns
                .Add("ID")
                .Add("tipo")
                .Add("Fecha")
                .Add("ColHora")
                .Add("HoraID")
                .Add("idBus")
                .Add("nombreBus")
                .Add("RutaID")
                .Add("origen")
                .Add("Destino")
                .Add("Estado")
                .Add("manifiesto")
                .Add("programacionID")
                .Add("ubigeoOrigen")
                .Add("ubigeoDestino")
                .Add("agenciaOrigen")
                .Add("agenciaDestino")
            End With


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

                        dt.Rows.Add(i.programacion_id,
                          If(i.tipo = "I", "SALIDA", "VUELTA"),
                          i.fechaProgramacion,
                          i.fechaProgramacion.Value.ToShortTimeString,
                          i.CustomRutas.CustomRuta_horarios.horario_id,
                          i.idActivo,
                          i.nombreBus,
                          i.ruta_id,
                          i.CustomRutas.ciudadOrigen,
                          i.CustomRutas.ciudadDestino, status,
              i.manifiesto,
              i.programacion_id,
i.CustomRutas.ciudadOrigenUbigeo,
i.CustomRutas.ciudadDestinoUbigeo)
                        GridCompra.DataSource = dt

                    Case ProgramacionEstado.ZonaEmbarque
                        status = "Embarque"
                End Select

            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Private Sub CargarProgramacion()

    '    If Not IsNothing(GridCompra.Table.CurrentRecord) Then

    '        Dim rec As Record
    '        rec = GridCompra.Table.CurrentRecord

    '        Dim fecha = rec.GetValue("fechaProgramacion")
    '        LabelfechaProg.Text = fecha.ToString
    '        LabelfechaProg.Tag = Integer.Parse(rec.GetValue("ID"))
    '        LabelTipoProg.Text = rec.GetValue("tipo")



    '        '-----------------------------------------------------------------------------------------------------------------------
    '        Dim id_ruta = Integer.Parse(rec.GetValue("RutaID"))
    '        Dim horario_id = Integer.Parse(rec.GetValue("HoraID"))

    '        ''     Dim ruta = ListaRutasActivas.Where(Function(o) o.ruta_id = id_ruta).SingleOrDefault

    '        ''LabelRuta.Text = $"DESDE {ruta.ciudadOrigen} HASTA {ruta.ciudadDestino}"
    '        ''GetProgramacion(id_ruta)
    '        'GetServiciosPasajes(id_ruta, horario_id)

    '    Else
    '        LabelfechaProg.Text = String.Empty
    '    End If
    'End Sub


#End Region


    Private Sub RoundButton28_Click(sender As Object, e As EventArgs) Handles RoundButton28.Click
        Cursor = Cursors.WaitCursor
        GetDocumentoVentaID()
        Cursor = Cursors.Default
    End Sub

    'Private Sub GridCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridCompra.TableControlCellClick
    '    Try
    '        If (CDate(TextFechaProgramada.Value) >= Date.Now.Date) Then

    '            If Not IsNothing(GridCompra.Table.CurrentRecord) Then
    '                Dim rec As Record
    '                rec = GridCompra.Table.CurrentRecord

    '                FormPurchase.TabTR_IdentificacionRuta.Visible = False
    '                FormPurchase.UCPantallaEmbarque.Visible = False

    '                If FormPurchase.TabTR_PasajeVenta IsNot Nothing Then

    '                    'If (rec.GetValue("estado") = "En mostrador") Then
    '                    FormPurchase.TabTR_PasajeVenta.Visible = True
    '                    'Dim fecha = rec.GetValue("Fecha")
    '                    FormPurchase.TabTR_PasajeVenta.LabelfechaProg.Text = CDate(rec.GetValue("Fecha")).ToString(FormatoFecha)   'CDate(fecha).Date
    '                    FormPurchase.TabTR_PasajeVenta.dtpHoraProgramada.Value = CDate(rec.GetValue("Fecha")) 'CDate(fecha).Date 'CDate(fecha).ToShortTimeString
    '                    FormPurchase.TabTR_PasajeVenta.LabelfechaProg.Tag = Integer.Parse(rec.GetValue("ID"))
    '                    'FormPurchase.TabTR_PasajeVenta.LabelTipoProg.Text = rec.GetValue("tipo")
    '                    FormPurchase.TabTR_PasajeVenta.LabelRuta.Text = "DESDE: " & rec.GetValue("origen") & " - " & rec.GetValue("Destino")
    '                    FormPurchase.TabTR_PasajeVenta.LabelRuta.Tag = Integer.Parse(rec.GetValue("RutaID"))
    '                    FormPurchase.TabTR_PasajeVenta.manifiesto = (rec.GetValue("manifiesto"))
    '                    FormPurchase.TabTR_PasajeVenta.ubigeoOrigen = (rec.GetValue("ubigeoOrigen"))
    '                    FormPurchase.TabTR_PasajeVenta.ubigeoDestino = (rec.GetValue("ubigeoDestino"))
    '                    FormPurchase.TabTR_PasajeVenta.LISTAESTABLECIMIENTO = listaCentroCosnto
    '                    FormPurchase.TabTR_PasajeVenta.GetDocsVenta()
    '                    FormPurchase.TabTR_PasajeVenta.cargarBus(rec.GetValue("idBus"), rec.GetValue("nombreBus"), rec.GetValue("programacionID"))
    '                    FormPurchase.TabTR_PasajeVenta.fechaEnvio = CDate(rec.GetValue("Fecha")) 'CDate(fecha)
    '                    '-----------------------------------------------------------------------------------------------------------------------
    '                    FormPurchase.TabTR_PasajeVenta.ToolStripButton7.Visible = True
    '                    FormPurchase.TabTR_PasajeVenta.BtConfirmarVenta.Visible = True
    '                    FormPurchase.TabTR_PasajeVenta.btnEliminarReserva.Visible = False
    '                    FormPurchase.TabTR_PasajeVenta.btnReserva.Visible = False
    '                    FormPurchase.TabTR_PasajeVenta.ToolStripButton4.Visible = True

    '                    Dim id_ruta = Integer.Parse(rec.GetValue("RutaID"))
    '                    Dim horario_id = Integer.Parse(rec.GetValue("HoraID"))
    '                    FormPurchase.TabTR_PasajeVenta.BringToFront()
    '                    FormPurchase.TabTR_PasajeVenta.Show()
    '                    'Else
    '                    '    MessageBox.Show("NO PUEDE REALIZAR VENTAS")
    '                    'End If


    '                End If
    '            Else
    '                MessageBox.Show("Verificar el cliente")
    '            End If
    '        Else
    '            Dim rec As Record
    '            rec = GridCompra.Table.CurrentRecord

    '            FormPurchase.TabTR_IdentificacionRuta.Visible = False
    '            FormPurchase.UCPantallaEmbarque.Visible = False

    '            If FormPurchase.TabTR_PasajeVenta IsNot Nothing Then

    '                'If (rec.GetValue("estado") = "En mostrador") Then
    '                FormPurchase.TabTR_PasajeVenta.Visible = True
    '                ' Dim fecha = rec.GetValue("Fecha")
    '                FormPurchase.TabTR_PasajeVenta.LabelfechaProg.Text = CDate(rec.GetValue("Fecha"))
    '                FormPurchase.TabTR_PasajeVenta.dtpHoraProgramada.Value = CDate(rec.GetValue("Fecha"))
    '                FormPurchase.TabTR_PasajeVenta.LabelfechaProg.Tag = Integer.Parse(rec.GetValue("ID"))
    '                'FormPurchase.TabTR_PasajeVenta.LabelTipoProg.Text = rec.GetValue("tipo")
    '                FormPurchase.TabTR_PasajeVenta.LabelRuta.Text = "DESDE: " & rec.GetValue("origen") & " - " & rec.GetValue("Destino")
    '                FormPurchase.TabTR_PasajeVenta.LabelRuta.Tag = Integer.Parse(rec.GetValue("RutaID"))
    '                FormPurchase.TabTR_PasajeVenta.manifiesto = (rec.GetValue("manifiesto"))
    '                FormPurchase.TabTR_PasajeVenta.ubigeoOrigen = (rec.GetValue("ubigeoOrigen"))
    '                FormPurchase.TabTR_PasajeVenta.ubigeoDestino = (rec.GetValue("ubigeoDestino"))
    '                FormPurchase.TabTR_PasajeVenta.LISTAESTABLECIMIENTO = listaCentroCosnto
    '                FormPurchase.TabTR_PasajeVenta.GetDocsVenta()
    '                FormPurchase.TabTR_PasajeVenta.cargarBus(rec.GetValue("idBus"), rec.GetValue("nombreBus"), rec.GetValue("programacionID"))
    '                FormPurchase.TabTR_PasajeVenta.fechaEnvio = CDate(rec.GetValue("Fecha"))
    '                FormPurchase.TabTR_PasajeVenta.ToolStripButton7.Visible = False
    '                FormPurchase.TabTR_PasajeVenta.BtConfirmarVenta.Visible = False
    '                FormPurchase.TabTR_PasajeVenta.btnEliminarReserva.Visible = False
    '                FormPurchase.TabTR_PasajeVenta.btnReserva.Visible = False
    '                FormPurchase.TabTR_PasajeVenta.ToolStripButton4.Visible = False

    '                '-----------------------------------------------------------------------------------------------------------------------
    '                Dim id_ruta = Integer.Parse(rec.GetValue("RutaID"))
    '                Dim horario_id = Integer.Parse(rec.GetValue("HoraID"))
    '                FormPurchase.TabTR_PasajeVenta.BringToFront()
    '                FormPurchase.TabTR_PasajeVenta.Show()
    '                'Else
    '                '    MessageBox.Show("NO PUEDE REALIZAR VENTAS")
    '                'End If


    '            End If
    '        End If

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub


    Private Sub TextFechaProgramada_ValueChanged(sender As Object, e As EventArgs) Handles TextFechaProgramada.ValueChanged
        Try
            Cursor = Cursors.WaitCursor
            GridCompra.Table.Records.DeleteAll()
            GetDocumentoVentaID()
            Cursor = Cursors.Default
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs)
        Try
            If MessageBox.Show("¿Liberar Bus?", "Salir de la venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then

                If Not IsNothing(GridCompra.Table.CurrentRecord) Then
                    Dim rec As Record
                    rec = GridCompra.Table.CurrentRecord

                    Dim RUTAsa As New RutaProgramacionSalidasSA
                    Dim RUTABE As rutaProgramacionSalidas

                    Dim documentoventaSA As New distribucionInfraestructuraSA
                    Dim documentoventaBE As New distribucionInfraestructura
                    Dim distribucionInfraturaBE = New distribucionInfraestructura

                    distribucionInfraturaBE.idEmpresa = Gempresas.IdEmpresaRuc
                    distribucionInfraturaBE.idActivo = CInt(rec.GetValue("idBus"))
                    distribucionInfraturaBE.estado = "A"

                    documentoventaSA.updateDistribucioTrasnportemMasivo(distribucionInfraturaBE)

                    RUTABE = New rutaProgramacionSalidas
                    RUTABE.estado = 0
                    RUTABE.programacion_id = CInt(rec.GetValue("ID"))

                    RUTAsa.UpdateEstadoProgramacion(RUTABE)

                    MessageBox.Show("SE HABILITO EL BUS")

                Else
                    MessageBox.Show("Debe Seleccionar un bus")

                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton11_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton11.Click

        Me.Visible = False
        If FormPurchase.UFProgramacionRuta IsNot Nothing Then
            FormPurchase.UFProgramacionRuta.Visible = True
            FormPurchase.UFProgramacionRuta.BringToFront()
            FormPurchase.UFProgramacionRuta.Show()
        End If
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Me.Visible = False
        If FormPurchase.PanelBody IsNot Nothing Then
            FormPurchase.PanelBody.Visible = True
            FormPurchase.PanelBody.BringToFront()
            FormPurchase.PanelBody.Show()
        End If
    End Sub
End Class
