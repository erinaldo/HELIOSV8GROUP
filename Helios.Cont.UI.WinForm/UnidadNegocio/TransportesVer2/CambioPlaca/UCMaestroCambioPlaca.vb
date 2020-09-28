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

Public Class UCMaestroCambioPlaca

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


#End Region


    Private Sub RoundButton28_Click(sender As Object, e As EventArgs) Handles RoundButton28.Click
        Cursor = Cursors.WaitCursor
        GetDocumentoVentaID()
        Cursor = Cursors.Default
    End Sub

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

        Try
            If (Not IsNothing(GridCompra.Table.CurrentRecord)) Then
                Me.Visible = False
                If FormPurchase.UFCambiarPLaca IsNot Nothing Then
                    FormPurchase.UFCambiarPLaca.Visible = True
                    FormPurchase.UFCambiarPLaca.cargarAgencias(GridCompra.Table.CurrentRecord.GetValue("ID"), GridCompra.Table.CurrentRecord.GetValue("idBus"))
                    FormPurchase.UFCambiarPLaca.BringToFront()
                    FormPurchase.UFCambiarPLaca.Show()
                End If
            End If
        Catch ex As Exception

        End Try

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
