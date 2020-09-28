Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Public Class UCLiquidacionEncomiendas
#Region "Attributes"
    'Dim cajaSA As New DocumentoventaTransporteSA
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(GridEncomiendas, True, False, 9.0F)
        LabelStatus.Tag = "baja"
        GetUsuariosCaja()
    End Sub
#End Region

#Region "Methods"
    Private Sub GetUsuariosCaja()
        If ListaCajasActivas IsNot Nothing Then
            ComboUsuario.DataSource = ListaCajasActivas
            ComboUsuario.DisplayMember = "NombrePersona"
            ComboUsuario.ValueMember = "idcajaUsuario"
        End If
    End Sub

    Private Sub GetMovimientosUsuario(v As Integer)



        'Dim Enco = cajaSA.GetResumenVentasSelCajero(
        '    New documentoCaja With
        '    {
        '    .idCajaUsuario = v, .movimientoCaja = TIPO_VENTA.VENTA_ENCOMIENDAS
        '    })

        'If Enco IsNot Nothing Then
        '    LabelTotalEncomienda.Text = CDec(Enco.montoSoles.GetValueOrDefault).ToString("N2")
        'Else
        '    LabelTotalEncomienda.Text = "0.00"
        'End If


    End Sub

    Private Sub CerrarCaja()
        Dim cajaSA As New cajaUsuarioSA
        Dim obj As New cajaUsuario
        obj.idcajaUsuario = ComboUsuario.SelectedValue
        obj.estadoCaja = "C"
        obj.fechaCierre = Date.Now
        obj.enUso = "N"
        obj.ingresoAdicMN = CDec(LabelTotalEncomienda.Text)
        obj.otrosEgresosMN = 0

        '    cajaSA.CerrarCajaUsuarioTrasnporte(obj)
        MessageBox.Show("Caja cerrada con éxito!", "Caja cerrada", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ListaCajasActivas = cajaSA.ListadoCajaXEstado(New cajaUsuario With {
                                                             .idEmpresa = Gempresas.IdEmpresaRuc,
                                                             .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                             .estadoCaja = "A"
                                                             })
        LabelStatus.ForeColor = Color.Gray
        LabelStatus.Text = "Status: Caja inactiva"
        LabelStatus.Tag = "baja"
        LabelTotalEncomienda.Text = "0.00"
        GridEncomiendas.Table.Records.DeleteAll()
        GetUsuariosCaja()
    End Sub
#End Region

#Region "Events"
    Private Sub BunifuThinButton22_Click(sender As Object, e As EventArgs) Handles BunifuThinButton22.Click
        Cursor = Cursors.WaitCursor
        Try
            If ListaCajasActivas IsNot Nothing Then
                GridEncomiendas.Table.Records.DeleteAll()
                GetMovimientosUsuario(Integer.Parse(ComboUsuario.SelectedValue))
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click
        If LabelStatus.Tag = "activa" Then
            If MessageBox.Show("Esta seguro de cerrar la caja?", "Cerrar caja", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                CerrarCaja()
            End If
        End If
    End Sub

    Private Sub ComboUsuario_Click(sender As Object, e As EventArgs) Handles ComboUsuario.Click

    End Sub

    Private Sub ComboUsuario_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboUsuario.SelectedValueChanged
        If IsNumeric(ComboUsuario.SelectedValue) Then
            Dim tieneCaja = ListaCajasActivas.Any(Function(o) o.idcajaUsuario = ComboUsuario.SelectedValue)
            If tieneCaja Then
                LabelStatus.ForeColor = Color.ForestGreen
                LabelStatus.Text = "Status: Caja activa"
                LabelStatus.Tag = "activa"
            Else
                LabelStatus.ForeColor = Color.Gray
                LabelStatus.Text = "Status: Caja inactiva"
                LabelStatus.Tag = "baja"
            End If

        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Cursor = Cursors.WaitCursor
        If ListaCajasActivas IsNot Nothing Then
            GetDetalleVenta(Integer.Parse(ComboUsuario.SelectedValue))
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GetDetalleVenta(idCajaUsuario As Integer)
        Dim Estado As String = String.Empty
        'Dim lista = cajaSA.GetEncomiendasSelCajero(New documentoventaTransporte With
        '                                             {
        '                                             .idcajaUsuario = idCajaUsuario
        '                                             })

        Dim dt As New DataTable

        dt.Columns.Add("id")
        dt.Columns.Add("fecha")
        dt.Columns.Add("tipodoc")
        dt.Columns.Add("serie")
        dt.Columns.Add("numero")
        dt.Columns.Add("remitente")
        dt.Columns.Add("importe")
        dt.Columns.Add("estadopago")

        'dt.Columns.Add("id")
        'dt.Columns.Add("fecharecepcion")
        'dt.Columns.Add("origen")
        'dt.Columns.Add("Emisor")
        'dt.Columns.Add("destino")
        'dt.Columns.Add("receptor")
        'dt.Columns.Add("items")
        'dt.Columns.Add("total")
        'dt.Columns.Add("estadopago")
        'dt.Columns.Add("estado", GetType(Boolean))
        'dt.Columns.Add("contenido")
        'dt.Columns.Add("costo")
        'dt.Columns.Add("secuencia")
        'dt.Columns.Add("cantidad")

        'For Each i In lista

        '    dt.Rows.Add(
        '        i.idDocumento,
        '        i.fechadoc,
        '        i.tipoDocumento,
        '        i.serie,
        '        i.numero,
        '        i.Remitente,
        '        i.total,
        '       If(i.estadoCobro = "DC", "Cobrado", "Pendiente"))
        'Next
        GridEncomiendas.DataSource = dt
    End Sub
#End Region
End Class
