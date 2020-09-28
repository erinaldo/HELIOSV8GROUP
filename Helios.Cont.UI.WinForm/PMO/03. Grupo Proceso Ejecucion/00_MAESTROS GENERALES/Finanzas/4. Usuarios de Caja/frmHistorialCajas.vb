Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Tools
Public Class frmHistorialCajas
#Region "Attributes"
    Dim listaMeses As New List(Of MesesAnio)
#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGrid(dgvUsuarioActivo)
        'GetCajaActivas()

        Meses()
        txtAnioCompra.Text = AnioGeneral
    End Sub

#End Region

#Region "Methods"
    Private Sub Meses()
        listaMeses = New List(Of MesesAnio)
        Dim obj As New MesesAnio
        For x = 1 To 12
            obj = New MesesAnio
            obj.Codigo = String.Format("{0:00}", CInt(x))
            obj.Mes = New DateTime(AnioGeneral, x, 1).ToString("MMMM")
            listaMeses.Add(obj)
        Next x

        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.DataSource = listaMeses
        cboMesCompra.SelectedValue = MesGeneral
    End Sub

    Public Sub GetCajaActivas()
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim usuriaoSA As New UsuarioSA
        Dim usuario As New Usuario
        Dim listaCajaUsuario As New List(Of cajaUsuario)
        Dim listaUsuario As New List(Of Usuario)

        Dim dt As New DataTable("Entidades financieras")
        dt.Columns.Add(New DataColumn("idPersona", GetType(Integer)))
        dt.Columns.Add(New DataColumn("idCaja", GetType(Integer)))
        dt.Columns.Add(New DataColumn("nombre", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("aperturaMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ingresoMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("egresoMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("total", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("fecha", GetType(String)))

        'listaCajaUsuario = cajaUsuarioSA.ObtenerCajaUsuarioFull

        For Each i In cajaUsuarioSA.ObtenerCajaUsuarioFullXpersona(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, cboMesCompra.SelectedValue + "/" + txtAnioCompra.Text, txtCliente2.Tag)
            'usuario = New Usuario
            'usuario.IDUsuario = i.idPersona

            'usuario = usuriaoSA.UbicarUsuarioXid(usuario)
            'If (Not IsNothing(usuario)) Then
            Dim dr As DataRow = dt.NewRow()

            dr(0) = i.idPersona
            dr(1) = i.idcajaUsuario
            dr(2) = txtCliente2.Text
            Select Case i.estadoCaja
                Case "A"
                    dr(3) = "ABIERTO"
                Case "C"
                    dr(3) = "CERRADO"
            End Select
            dr(4) = i.fondoMN.GetValueOrDefault
            dr(5) = i.ingresoAdicMN.GetValueOrDefault
            dr(6) = i.otrosEgresosMN.GetValueOrDefault
            dr(7) = CDec((i.fondoMN.GetValueOrDefault + i.ingresoAdicMN.GetValueOrDefault) - i.otrosEgresosMN.GetValueOrDefault)
            dr(8) = i.fechaRegistro
            dt.Rows.Add(dr)

            'End If
        Next
        dgvUsuarioActivo.DataSource = dt

    End Sub


#Region "TIMER"

#End Region
#End Region

#Region "Events"

#End Region

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        If (Not IsNothing(txtCliente2.Tag)) Then
            GetCajaActivas()
        Else
            MessageBoxAdv.Show("Debe seleccionar una persona", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        Cursor = Cursors.WaitCursor
        Dim f As New frmGeneral_BusquedaEntidad(TIPO_ENTIDAD.USUARIO)
        f.CaptionLabels(0).Text = "Usuarios"
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        If Not IsNothing(f.Tag) Then
            Dim c = DirectCast(f.Tag, Usuario)
            'Dim c = CType(f.Tag, entidad)
            txtCliente2.Text = c.Nombres + " " + c.ApellidoPaterno + " " + c.ApellidoMaterno
            txtCliente2.Tag = c.IDUsuario
            txtRuc2.Text = c.NroDocumento
            txtRuc2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            txtCliente2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Label80_Click(sender As Object, e As EventArgs) Handles Label80.Click

    End Sub

    Private Sub dgvUsuarioActivo_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvUsuarioActivo.TableControlCellClick
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgvUsuarioActivo.Table.CurrentRecord) Then
            With frmHistorialCajasDetallado
                .ObtenerListaCajaAsignacionDetalle(Me.dgvUsuarioActivo.Table.CurrentRecord.GetValue("idCaja"), Me.dgvUsuarioActivo.Table.CurrentRecord.GetValue("idPersona"), Me.dgvUsuarioActivo.Table.CurrentRecord.GetValue("fecha"))
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With

        End If
        Me.Cursor = Cursors.Arrow
    End Sub
End Class