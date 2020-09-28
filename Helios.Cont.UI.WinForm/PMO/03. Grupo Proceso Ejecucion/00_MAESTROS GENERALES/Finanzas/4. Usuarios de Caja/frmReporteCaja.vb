Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Helios.General
Public Class frmReporteCaja

#Region "Attributes"

#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridPequeño(dgvReporteCaja, True)
    End Sub

#End Region

#Region "Methods"


    Public Sub ObtenerListaCajaAsignacionReporte()
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim usuriaoSA As New UsuarioSA
        Dim usuario As New Usuario
        Dim listaCajaUsuario As New List(Of cajaUsuario)
        Dim listaUsuario As New List(Of Usuario)

        Dim dt As New DataTable("Entidades financieras")
        dt.Columns.Add(New DataColumn("idPersona", GetType(Integer)))
        dt.Columns.Add(New DataColumn("idCaja", GetType(Integer)))
        dt.Columns.Add(New DataColumn("fechaRegistro", GetType(String)))
        dt.Columns.Add(New DataColumn("nombre", GetType(String)))
        dt.Columns.Add(New DataColumn("DNI", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))

        'listaCajaUsuario = cajaUsuarioSA.ObtenerCajaUsuarioFull

        For Each i In cajaUsuarioSA.ObtenerCajaUsuarioFull(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
            usuario = New Usuario
            usuario.IDUsuario = i.idPersona

            usuario = usuriaoSA.UbicarUsuarioXid(usuario)
            If (Not IsNothing(usuario)) Then
                Dim dr As DataRow = dt.NewRow()

                dr(0) = i.idPersona
                dr(1) = i.idcajaUsuario
                dr(2) = i.fechaRegistro
                dr(3) = usuario.Nombres & " " & usuario.ApellidoPaterno & " " & usuario.ApellidoMaterno
                dr(4) = usuario.NroDocumento
                Select Case i.estadoCaja
                    Case "A"
                        dr(5) = "ABIERTO"
                    Case "C"
                        dr(5) = "CERRADO"
                End Select

                dt.Rows.Add(dr)


            End If
        Next
        dgvReporteCaja.DataSource = dt


    End Sub

#Region "TIMER"

#End Region
#End Region

#Region "Events"
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If Not IsNothing(Me.dgvReporteCaja.Table.CurrentRecord) Then
            With frmCajausuario
                .ConsultaReporte(Me.dgvReporteCaja.Table.CurrentRecord.GetValue("idCaja"), Me.dgvReporteCaja.Table.CurrentRecord.GetValue("idPersona"), Me.dgvReporteCaja.Table.CurrentRecord.GetValue("nombre"), Me.dgvReporteCaja.Table.CurrentRecord.GetValue("DNI"))
                .ShowDialog()
            End With
        Else
            MessageBox.Show("Debe Seleccionar un item!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        If Not IsNothing(Me.dgvReporteCaja.Table.CurrentRecord) Then
            With frmCajaUsuarioCierre
                .ConsultaReportePost(Me.dgvReporteCaja.Table.CurrentRecord.GetValue("idCaja"), Me.dgvReporteCaja.Table.CurrentRecord.GetValue("idPersona"), Me.dgvReporteCaja.Table.CurrentRecord.GetValue("nombre"), Me.dgvReporteCaja.Table.CurrentRecord.GetValue("DNI"), Me.dgvReporteCaja.Table.CurrentRecord.GetValue("fechaRegistro"))
                .ShowDialog()
            End With
        Else
            MessageBox.Show("Debe Seleccionar un item!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ObtenerListaCajaAsignacionReporte()
    End Sub

#End Region
End Class