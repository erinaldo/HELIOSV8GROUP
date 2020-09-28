Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping

Public Class UCMaestroRutas

#Region "Attributes"
    Public Property FormPurchase As FormTablaPrincipalTransportes
#End Region


#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GetRutas()
        FormatoGridAvanzado(GridRutas, True, False, 10.0F)

    End Sub

    Public Sub New(FormventaNueva As FormTablaPrincipalTransportes)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormPurchase = FormventaNueva

        FormatoGridAvanzado(GridRutas, True, False, 10.0F)

    End Sub


#End Region

#Region "Methods"
    'Public Sub GetProgramacionSelRuta(ruta_id As Integer)
    '    Dim rutaSA As New RutaProgramacionSalidasSA
    '    Dim dt As New DataTable
    '    dt.Columns.Add("ruta_id")
    '    dt.Columns.Add("id")
    '    dt.Columns.Add("tipo")
    '    dt.Columns.Add("fecha")
    '    dt.Columns.Add("hora")
    '    dt.Columns.Add("estado")

    '    For Each i In rutaSA.GetProgramacionSelRuta(ruta_id)
    '        dt.Rows.Add(i.ruta_id, i.programacion_id, If(i.tipo = "I", "IDA", "VUELTA"), i.fechaProgramacion.Value.ToShortDateString, i.fechaProgramacion.Value.ToShortTimeString, If(i.estado = 1, "Activo", "Baja"))
    '    Next
    '    GridGroupingControl1.DataSource = dt
    'End Sub

    Private Sub GetRutas()
        Dim rutaSA As New RutasSA

        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("codigo")
        dt.Columns.Add("origen")
        dt.Columns.Add("origenUbigeo")
        dt.Columns.Add("destino")
        dt.Columns.Add("destinoUbigeo")
        dt.Columns.Add("km")
        dt.Columns.Add("estado")

        For Each i In rutaSA.GellAllRutas(New Business.Entity.rutas With {.estado = 1}).Where(Function(O) O.codigo = "RT").ToList
            dt.Rows.Add(i.ruta_id, i.codigo, i.ciudadOrigen, i.ciudadOrigenUbigeo, i.ciudadDestino, i.ciudadDestinoUbigeo, i.km, "Activo")
        Next
        GridRutas.DataSource = dt
    End Sub
#End Region

#Region "Events"
    Private Sub BunifuFlatButton11_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton11.Click
        Try
            Me.Visible = False
            FormPurchase.UFCrearRuta.Visible = True
            FormPurchase.UFCrearRuta.CARGARDATOS()
            FormPurchase.UFCrearRuta.BringToFront()
            FormPurchase.UFCrearRuta.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Try
            Dim r As Record = GridRutas.Table.CurrentRecord
            If r IsNot Nothing Then
                Dim f As New FormCrearRuta()
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog(Me)
            Else
                Throw New Exception("DEBE SELECIONAR UN DATO")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        Try
            Dim r As Record = GridRutas.Table.CurrentRecord
            If r IsNot Nothing Then
                Dim f As New FormProgramarRutaFecha
                f.TextRuta.Tag = Integer.Parse(r.GetValue("id"))
                f.TextRuta.Text = $"{r.GetValue("origen")} - {r.GetValue("destino")}"
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog(Me)
                If f.Tag IsNot Nothing Then
                    Dim c = CType(f.Tag, rutaProgramacionSalidas)
                    'AddFilaProgramada(c)
                End If
            Else
                Throw New Exception("DEBE SELECIONAR UN DATO")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Private Sub AddFilaProgramada(c As rutaProgramacionSalidas)
    '    Try
    '        With GridGroupingControl1.Table
    '            .AddNewRecord.SetCurrent()
    '            .AddNewRecord.BeginEdit()
    '            .CurrentRecord.SetValue("ruta_id", c.ruta_id)
    '            .CurrentRecord.SetValue("id", c.programacion_id)
    '            .CurrentRecord.SetValue("tipo", If(c.tipo = "I", "IDA", "VUELTA"))
    '            .CurrentRecord.SetValue("fecha", c.fechaProgramacion.Value.ToShortDateString)
    '            .CurrentRecord.SetValue("hora", c.fechaProgramacion.Value.ToShortTimeString)
    '            .CurrentRecord.SetValue("estado", "Activo")
    '            .AddNewRecord.EndEdit()
    '            .TableDirty = True
    '        End With
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try

    'End Sub

    Private Sub GridRutas_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles GridRutas.SelectedRecordsChanged
        Cursor = Cursors.WaitCursor
        Try
            If e.SelectedRecord IsNot Nothing Then
                Dim r As Record = e.SelectedRecord.Record
                If r IsNot Nothing Then
                    If GridRutas.Table.Records.Count > 0 Then
                        'GetProgramacionSelRuta(Integer.Parse(r.GetValue("id")))
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Atención")
        End Try

        Cursor = Cursors.Default
    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        GetRutas()
    End Sub

    Private Sub BunifuFlatButton5_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton5.Click
        Try
            Me.Visible = False
            FormPurchase.LIMPIAR()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


#End Region


End Class
