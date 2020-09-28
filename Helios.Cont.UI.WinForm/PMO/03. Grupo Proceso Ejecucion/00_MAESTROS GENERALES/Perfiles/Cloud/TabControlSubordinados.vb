Imports Helios.Cont.Business.Entity
Imports Helios.Cont.Presentation.WinForm
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Drawing
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Chart
Imports Syncfusion.Windows.Forms.Grid
Imports Helios.Seguridad.Business.Entity

Imports Helios.Seguridad.WCFService.ServiceAccess
Imports System.ComponentModel




Public Class TabControlSubordinados

#Region "Variables"

    Public Property ListaCargos As List(Of Rol)

#End Region

#Region "Constructor"

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        'txtFechaLaboral.Value = Date.Now
        'txtFechaLaboral.BorderStyle = BorderStyle.None
        'FormatoGrid()
        FormatoGridBlack(dgvSubordinados, True)
        'FormatoGridBlack(GridComprobantes, True)
        'FormatoGridBlack(GridFjloCajaDetalle, True)
        'FormatoGridBlack(GridFormaPagoDetalle, True)
        'txtFechaLaboral.BorderColor = Color.FromArgb(209, 211, 212)

    End Sub

#End Region


#Region "Metodos"

    Public Sub ListarSubordinados()
        Try


            Dim sa As New UsuarioSA
            Dim obj As New Usuario
            obj.idUsuarioResponsable = txtIdentificacion.Tag
            obj.IDRol = cboCargosAResponsabilidad.SelectedValue

            Dim consulta = sa.ListadoUsuariosConResponsable(obj)


            Dim dt As New DataTable("Usuario")
            Dim UsuarioSA As New UsuarioSA

            dt.Columns.Add(New DataColumn("idUsuario", GetType(Integer)))
            dt.Columns.Add(New DataColumn("idCargo", GetType(String)))
            dt.Columns.Add(New DataColumn("nombreCargo", GetType(String)))
            dt.Columns.Add(New DataColumn("Dni", GetType(String)))
            dt.Columns.Add(New DataColumn("nombrePersona", GetType(String)))


            For Each i In consulta
                Dim dr As DataRow = dt.NewRow()

                dr(0) = i.IDUsuario
                dr(1) = i.IDRol
                dr(2) = i.nombrecargo
                dr(3) = i.NroDocumento
                dr(4) = i.Nombres & " " & i.ApellidoPaterno & "" & i.ApellidoMaterno
                dt.Rows.Add(dr)
            Next

            dgvSubordinados.DataSource = dt
        Catch ex As Exception

        End Try
    End Sub

    Public Sub CargarCargos()
        Try

            Dim jerarquiBE As New Rol
            ListaCargos = New List(Of Rol)
            Dim sa As New RolSA

            jerarquiBE.IDEmpresa = Gempresas.IdEmpresaRuc
            'jerarquiBE.IDEstablecimiento = GEstableciento.IdEstablecimiento

            Dim consulta = sa.RoleList(jerarquiBE)
            ListaCargos = consulta





            Dim user = (From i In UsuariosList
                        Where i.IDUsuario = usuario.IDUsuario).FirstOrDefault

            Dim cargoSelect = (From z In user.UsuarioRol Where z.IDRol = usuario.IDRol).FirstOrDefault

            If user IsNot Nothing Then

                If cargoSelect IsNot Nothing Then


                    txtIdentificacion.Text = user.ApellidoPaterno & " " & user.ApellidoMaterno & " " & user.Nombres
                    txtIdentificacion.Tag = user.IDUsuario

                    'im nomcargo = (From i In ListaCargos
                    '               Where i.IDRol = cargoSelect.IDRol).FirstOrDefaultD

                    'If nomcargo IsNot Nothing Then

                    txtCargo.Text = cargoSelect.nombrePerfil
                    txtCargo.Tag = cargoSelect.IDRol


                    Dim listahijos = (From i In ListaCargos
                                      Where i.idPadre = cargoSelect.IDRol).ToList


                    cboCargosAResponsabilidad.DisplayMember = "Descripcion"
                    cboCargosAResponsabilidad.ValueMember = "IDRol"
                    cboCargosAResponsabilidad.DataSource = listahijos

                    'End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuThinButton23_Click(sender As Object, e As EventArgs) Handles BunifuThinButton23.Click
        ListarSubordinados()
    End Sub

    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click

        Dim usuarioListSA As New Helios.Seguridad.WCFService.ServiceAccess.UsuarioSA

        Dim f As New FormPersonalSinResponsable
        f.lblidResponsable.Text = txtIdentificacion.Tag
        f.lblResponsable.Text = txtIdentificacion.Text
        f.lblCargo.Text = cboCargosAResponsabilidad.Text
        f.lblidCargo.Text = cboCargosAResponsabilidad.SelectedValue

        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)


        UsuariosList = usuarioListSA.ListadoUsuariosv2()
    End Sub



#End Region

End Class
