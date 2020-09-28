Imports Helios.Cont.Business.Entity
Imports Helios.General
'Imports Helios.Planilla.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Public Class frmModalTrab
#Region "Métodos"
    Sub EstablecimientoCosto()
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
        datos.Clear()

        With frmModalEstablecimientoCaja
            .StrParametroCarga = "ET"
            .ObtenerEstablecimientos()
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            If datos.Count > 0 Then
                txtIdEstable.Text = datos(0).ID
                txtEstable.Text = datos(0).NombreCampo

                txtEstable.Focus()
            Else
                txtIdEstable.Text = String.Empty
                txtEstable.Text = String.Empty
                txtEstable.Focus()
            End If
        End With

        Me.Cursor = Cursors.Arrow
    End Sub
#End Region

    Public Sub ObtenerTrabajadoresPorEstab(ByVal intIdEstablecimiento As Integer)
        Dim trabajadorSA = New Trabajador_PLSA()
        Try
            lsvTrab.Columns.Clear()
            lsvTrab.Items.Clear()

            lsvTrab.Columns.Add("COD.", 75)
            lsvTrab.Columns.Add("Nombres", 180)

            For Each i In trabajadorSA.ObtenerListaTrabEstable(intIdEstablecimiento)
                Dim n As New ListViewItem(i.codTrabajdor)
                n.SubItems.Add(String.Concat(i.nombres, ", ", i.appat, " ", i.apmat))
                lsvTrab.Items.Add(n)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub ObtenerTrabajadoresPorEstabNumDoc(ByVal intIdEstablecimiento As Integer, ByVal strNunmDoc As String)
        Dim trabajadorSA = New Trabajador_PLSA()
        Try
            lsvTrab.Columns.Clear()
            lsvTrab.Items.Clear()

            lsvTrab.Columns.Add("COD.", 75)
            lsvTrab.Columns.Add("Nombres", 180)

            With trabajadorSA.UbicarTrabDNI(strNunmDoc, intIdEstablecimiento)
                Dim n As New ListViewItem(.codTrabajdor)
                n.SubItems.Add(String.Concat(.nombres, ", ", .appat, " ", .apmat))
                lsvTrab.Items.Add(n)
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmModalTrab_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmModalTrab_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ObtenerTrabajadoresPorEstab(GEstableciento.IdEstablecimiento)
    End Sub

    Private Sub lsvTrab_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lsvTrab.MouseDoubleClick
        If lsvTrab.SelectedItems.Count > 0 Then
            Dim n As New RecuperarCarteras()
            Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
            datos.Clear()
            n.IDEstable = txtIdEstable.Text
            n.Estable = txtEstable.Text
            n.ID = lsvTrab.SelectedItems(0).SubItems(0).Text
            n.NombreEntidad = lsvTrab.SelectedItems(0).SubItems(1).Text
            datos.Add(n)
            Dispose()
        End If
    End Sub

    Private Sub lsvTrab_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lsvTrab.SelectedIndexChanged

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Call EstablecimientoCosto()
        ObtenerTrabajadoresPorEstab(GEstableciento.IdEstablecimiento)
    End Sub

    Private Sub NuevoToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles NuevoToolStripButton.Click

    End Sub

    Private Sub txtBusqueda_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtBusqueda.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtBusqueda.Text.Trim.Length > 0 Then
                ObtenerTrabajadoresPorEstabNumDoc(GEstableciento.IdEstablecimiento, txtBusqueda.Text.Trim)
            End If
        End If
    End Sub

    Private Sub txtBusqueda_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBusqueda.TextChanged

    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        With frmTrabajadorForm
            .xManipulacion = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            ObtenerTrabajadoresPorEstab(GEstableciento.IdEstablecimiento)
        End With
    End Sub
End Class