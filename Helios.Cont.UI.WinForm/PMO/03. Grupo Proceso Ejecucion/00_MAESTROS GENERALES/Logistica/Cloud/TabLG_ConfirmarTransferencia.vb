Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping

Public Class TabLG_ConfirmarTransferencia
    Dim compraSA As New DocumentoCompraSA
    Public Property VentanaSel As FormMaestroLogistica
    Public Sub New(ventana As FormMaestroLogistica)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(GridEntidades, True, False)
        FormatoGridAvanzado(GridDocumentos, True, False)
        FormatoGridAvanzado(GridGroupingControl2, True, False)
        VentanaSel = ventana
        GetTransferenciasXconfirmar()
    End Sub

    Private Sub GetTransferenciasXconfirmar()
        Dim dt As New DataTable

        dt.Columns.Add("id")
        dt.Columns.Add("Prov")
        dt.Columns.Add("Ruc")
        dt.Columns.Add("tipo")

        For Each i In compraSA.GetListaPersonasTrasnferenciasXconfirmar(New Business.Entity.documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
            dt.Rows.Add(i.idEntidad, i.nombreCompleto, i.nrodoc, i.tipoEntidad)
        Next
        GridEntidades.DataSource = dt
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub GridEntidades_TableControlCellClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles GridEntidades.TableControlCellClick
        GridGroupingControl2.Table.Records.DeleteAll()
    End Sub

    Private Sub GridEntidades_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles GridEntidades.SelectedRecordsChanged
        If e.SelectedRecord IsNot Nothing Then
            GetListaTransferenciasXEntidad(e.SelectedRecord.Record)
        End If
    End Sub

    Private Sub GetListaTransferenciasXEntidad(record As Record)
        Dim guiaSA As New DocumentoGuiaSA
        Dim dt As New DataTable
        dt.Columns.Add("iddocumento")
        dt.Columns.Add("fecha")
        dt.Columns.Add("nrotransaccion")
        dt.Columns.Add("importe")
        dt.Columns.Add("recepcion")
        dt.Columns.Add("glosa")

        'For Each i In guiaSA.ListaGuiasTransferenciasXEntidad(
        '    New Business.Entity.documentocompra With
        '    {.idEmpresa = Gempresas.IdEmpresaRuc,
        '    .entidad = New Business.Entity.entidad With
        '                                        {.idEntidad = record.GetValue("id"),
        '                                         .tipoEntidad = If(record.GetValue("tipo") = "Otros", "TR", "PR")
        '                                        }
        '    }).Where(Function(o) o.estado = TipoGuia.Pendiente).ToList

        '    dt.Rows.Add(i.idDocumento, i.fechaDoc, String.Format("{0}-{1}", i.serie, i.numeroDoc), i.importeMN, "-", i.glosa)
        'Next

        For Each i In guiaSA.ListaGuiasTransferenciasXEntidadV2(
            New Business.Entity.documentocompra With
            {
            .idEmpresa = Gempresas.IdEmpresaRuc,
            .entidad = New Business.Entity.entidad With
                                                {.idEntidad = record.GetValue("id"),
                                                 .tipoEntidad = If(record.GetValue("tipo") = "Otros", "TR", "PR")
                                                }
            }, If(record.GetValue("tipo") = "Otros", "TR", "PR")).ToList

            dt.Rows.Add(i.idDocumento, i.fechaDoc, String.Format("{0}-{1}", i.serie, i.numeroDoc), i.importeMN, "-", i.glosa)
        Next


        GridDocumentos.DataSource = dt
    End Sub

    Private Sub GridDocumentos_TableControlCellClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles GridDocumentos.TableControlCellClick

    End Sub

    Private Sub GridDocumentos_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles GridDocumentos.SelectedRecordsChanged
        If e.SelectedRecord IsNot Nothing Then
            GetDetalleTransferencia(e.SelectedRecord.Record)
        End If
    End Sub

    Private Sub GetDetalleTransferencia(record As Record)
        Dim compraDetalleSA As New DocumentoCompraDetalleSA
        '        Dim compraDetalleSA As New DocumentoGuiaDetalleSA
        Dim dt As New DataTable
        With dt.Columns
            .Add("lote")
            .Add("iditem")
            .Add("item")
            .Add("unidad")
            .Add("cantidad")
            .Add("importe")
            .Add("almacen")
        End With

        'For Each i In compraDetalleSA.UbicarDocumentoGuiaDetalle(record.GetValue("iddocumento"))
        '    dt.Rows.Add(i.secuencia, i.idItem, i.descripcionItem, i.unidadMedida, i.cantidad, i.importeMN, i.NombreAlmacen)
        'Next

        For Each i In compraDetalleSA.UbicarDocumentoCompraDetalle(record.GetValue("iddocumento"))
            dt.Rows.Add(i.secuencia, i.idItem, i.descripcionItem, i.unidad1, i.monto1, 0, String.Empty)
        Next
        GridGroupingControl2.DataSource = dt
    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        If GridDocumentos.Table.CurrentRecord IsNot Nothing Then

            Dim obj As New documentocompra With {
                .idDocumento = GridDocumentos.Table.CurrentRecord.GetValue("iddocumento"),
                .entidad = New entidad With {.idEntidad = GridEntidades.Table.CurrentRecord.GetValue("id"),
                                             .nombreCompleto = GridEntidades.Table.CurrentRecord.GetValue("Prov"),
                                             .nrodoc = GridEntidades.Table.CurrentRecord.GetValue("Ruc")}}

            Dim f As New frmControlEntregableTransferencia(obj)
            f.lblPerido.Text = String.Format("{0:00}", DateTime.Now.Month) & "/" & DateTime.Now.Year
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
            If GridEntidades IsNot Nothing Then
                GetListaTransferenciasXEntidad(GridEntidades.Table.CurrentRecord)
            End If
            GridGroupingControl2.Table.Records.DeleteAll()
            VentanaSel.ThreadTransitoTransferencia()
        End If
    End Sub
End Class
