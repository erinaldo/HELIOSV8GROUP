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

Public Class FormManifiestoLiquidacion

    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        FormatoGridTouch(GridCompra, False, False, 14.0F)

        TextFechaProgramada.Value = Date.Now
    End Sub

#Region "METODO"

    Public Sub GetDocumentoVentaID()
        Try
            Dim status As String = String.Empty
            Dim rutaSA As New RutaProgramacionSalidasSA
            Dim dt As New DataTable

            GridCompra.Table.Records.DeleteAll()

            Dim lista = rutaSA.GetProgramacionPorFechaLaboral(New rutaProgramacionSalidas With
                                                              {
                                                              .fechaProgramacion = TextFechaProgramada.Value
                                                              })


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
                .Add("placaBus")
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
                    Case ProgramacionEstado.ZonaEmbarque
                        status = "Embarque"
                End Select

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
                                           i.manifiesto, i.nroPlcaBus)
            Next
            GridCompra.DataSource = dt
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

    Private Sub GridCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridCompra.TableControlCellClick
        Try

            If Not IsNothing(GridCompra.Table.CurrentRecord) Then
                Dim rec As Record
                rec = GridCompra.Table.CurrentRecord

                'FormPurchase.TabTR_IdentificacionRuta.Visible = False
                'FormPurchase.UCPantallaEmbarque.Visible = False

                'If FormPurchase.TabTR_PasajeVenta IsNot Nothing Then

                '    FormPurchase.TabTR_PasajeVenta.Visible = True
                '    Dim fecha = rec.GetValue("Fecha")
                '    FormPurchase.TabTR_PasajeVenta.LabelfechaProg.Text = fecha.ToString
                '    FormPurchase.TabTR_PasajeVenta.LabelfechaProg.Tag = Integer.Parse(rec.GetValue("ID"))
                '    FormPurchase.TabTR_PasajeVenta.LabelTipoProg.Text = rec.GetValue("tipo")
                '    FormPurchase.TabTR_PasajeVenta.LabelRuta.Text = "DESDE: " & rec.GetValue("origen") & " - " & rec.GetValue("Destino")
                '    FormPurchase.TabTR_PasajeVenta.LabelRuta.Tag = Integer.Parse(rec.GetValue("RutaID"))
                '    FormPurchase.TabTR_PasajeVenta.manifiesto = (rec.GetValue("manifiesto"))
                '    FormPurchase.TabTR_PasajeVenta.GetDocsVenta()
                '    FormPurchase.TabTR_PasajeVenta.cargarBus(rec.GetValue("idBus"), rec.GetValue("nombreBus"))
                '    '-----------------------------------------------------------------------------------------------------------------------
                '    Dim id_ruta = Integer.Parse(rec.GetValue("RutaID"))
                '    Dim horario_id = Integer.Parse(rec.GetValue("HoraID"))
                '    FormPurchase.TabTR_PasajeVenta.BringToFront()
                '    FormPurchase.TabTR_PasajeVenta.Show()
                'End If
            Else
                MessageBox.Show("Verificar el cliente")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub



    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs)
        Dim f As New FormCrearTripulante
        f.StartPosition = FormStartPosition.CenterParent
        f.Show()
    End Sub

    Private Sub FormManifiestoLiquidacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        General.Centrar(Me)
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Try
            If Not IsNothing(GridCompra.Table.CurrentRecord) Then
                Dim rec As Record
                rec = GridCompra.Table.CurrentRecord

                Dim f As New FormCambioPlaca(rec.GetValue("ID"), rec.GetValue("idBus"))
                f.pnBuscardor.Visible = True
                f.cboActivosFijos.Visible = True
                f.TextRuta.Tag = rec.GetValue("RutaID")
                f.TextRuta.Text = rec.GetValue("origen") & " - " & rec.GetValue("Destino")
                f.programacionAnterior = rec.GetValue("ID")
                f.TextFechaProgramada.Value = rec.GetValue("Fecha")
                f.TextHora.Value = rec.GetValue("ColHora")
                f.txtEdad.Tag = rec.GetValue("idBus")
                f.txtEdad.Text = rec.GetValue("nombreBus")
                f.txtNuevaFecha.Value = rec.GetValue("Fecha")
                f.txtNuevaHora.Value = rec.GetValue("Fecha")
                f.StartPosition = FormStartPosition.CenterParent
                f.Show()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
