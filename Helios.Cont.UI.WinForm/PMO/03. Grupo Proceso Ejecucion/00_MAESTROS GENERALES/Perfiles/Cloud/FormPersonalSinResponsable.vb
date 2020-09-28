Imports System.Threading
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.Business.Entity
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid.Grouping
Public Class FormPersonalSinResponsable

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(dgPerfilesUsuario, True, False)

    End Sub


#Region "Metodos"


    Public Sub UpdateAsignarResponsable(iduser As Integer)
        Try


            Dim UsuarioSA As New UsuarioSA
            Dim objeto As New Usuario

            objeto.IDUsuario = iduser
            objeto.idUsuarioResponsable = lblidResponsable.Text

            UsuarioSA.GetUpdateUsuario(objeto)
            MessageBox.Show("Se asigno correctamete al personal")
        Catch ex As Exception
            MessageBox.Show("No se pudo asignar al personal")
        End Try
    End Sub


    Private Sub GetClientes(cargo As String)
        Dim dt As New DataTable("Usuario")
        Dim UsuarioSA As New UsuarioSA

        dt.Columns.Add(New DataColumn("IDUsuario", GetType(String)))
        dt.Columns.Add(New DataColumn("Dni", GetType(String)))
        dt.Columns.Add(New DataColumn("Nombre", GetType(String)))


        Dim obj As New Usuario
        obj.IDRol = cargo


        For Each i In UsuarioSA.ListadoUsuariosSoloCargoNoResp(obj)

            'For Each i In UsuarioSA.ListadoUsuariosXcliente(Gempresas.IDCliente)
            Dim dr As DataRow = dt.NewRow()

            dr(0) = i.IDUsuario
            dr(1) = i.NroDocumento
            dr(2) = i.Full_Name

            dt.Rows.Add(dr)
        Next

        dgPerfilesUsuario.DataSource = dt
    End Sub

#End Region


    Private Sub FormPersonalSinResponsable_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            GetClientes(lblidCargo.Text)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgPerfilesUsuario_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgPerfilesUsuario.TableControlCellClick

    End Sub

    Private Sub dgPerfilesUsuario_TableControlCellDoubleClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgPerfilesUsuario.TableControlCellDoubleClick
        Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgPerfilesUsuario.Table.CurrentRecord) Then



            Me.dgPerfilesUsuario.Table.CurrentRecord.GetValue("IDUsuario")

            UpdateAsignarResponsable(CInt(Me.dgPerfilesUsuario.Table.CurrentRecord.GetValue("IDUsuario")))
            GetClientes(lblidCargo.Text)
        End If
        Cursor = Cursors.Default
    End Sub
End Class