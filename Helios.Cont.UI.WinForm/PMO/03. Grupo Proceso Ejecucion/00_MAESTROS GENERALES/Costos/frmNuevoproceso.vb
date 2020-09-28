Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports System.Drawing
Imports System.Drawing.Drawing2D
Public Class frmNuevoproceso
    Inherits frmMaster

    Public Property ManipulacionEstado() As String
    Public Property IdCostoPadre() As Integer
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(intIdCosto As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UbicarCosto(intIdCosto)
    End Sub

#Region "Métodos"

    Public Sub UbicarCosto(intIdCosto As Integer)
        Dim costoSA As New recursoCostoSA

        With costoSA.GetCostoById(New recursoCosto With {.idCosto = intIdCosto})
            IdCostoPadre = .idpadre
            txtNuevoCosto.Tag = .idCosto
            txtNuevoCosto.Text = .nombreCosto
            txtSubdetalle.Text = .detalle
        End With

    End Sub

    Public Sub Grabar()
        Dim costo As New recursoCosto
        Dim proceso As New recursoCosto
        Dim recursoSA As New recursoCostoSA

        costo = New recursoCosto
        costo.idpadre = IdCostoPadre
        costo.tipo = "PRC"
        costo.subtipo = "PRC"
        costo.nombreCosto = txtNuevoCosto.Text.Trim
        costo.codigo = String.Empty
        costo.detalle = txtSubdetalle.Text.Trim
        costo.subdetalle = String.Empty
        costo.inicio = Nothing
        costo.finaliza = Nothing
        costo.procesado = "N"
        costo.usuarioActualizacion = usuario.IDUsuario
        costo.fechaActualizacion = DateTime.Now

        recursoSA.GrabarCostoOne(costo)
        MessageBox.Show("EDT grabado!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Dispose()
    End Sub

    Public Sub Editar()
        Dim costo As New recursoCosto
        Dim proceso As New recursoCosto
        Dim recursoSA As New recursoCostoSA

        costo = New recursoCosto
        costo.idpadre = IdCostoPadre
        costo.tipo = "PRC"
        costo.subtipo = "PRC"
        costo.idCosto = Val(txtNuevoCosto.Tag)
        costo.nombreCosto = txtNuevoCosto.Text.Trim
        costo.codigo = String.Empty
        costo.detalle = txtSubdetalle.Text.Trim
        costo.subdetalle = String.Empty
        costo.inicio = Nothing
        costo.finaliza = Nothing
        costo.procesado = "N"
        costo.usuarioActualizacion = usuario.IDUsuario
        costo.fechaActualizacion = DateTime.Now

        recursoSA.EditarCosto(costo)
        MessageBox.Show("EDT editado!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Dispose()
    End Sub
#End Region

    Private Sub frmNuevoproceso_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmNuevoproceso_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Dispose()
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        Me.Cursor = Cursors.WaitCursor
        If Not txtNuevoCosto.Text.Trim.Length > 0 Then
            MessageBox.Show("Debe indicar el nombre del EDT!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNuevoCosto.Select()
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If
        If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
            Grabar()
        Else
            Editar()
        End If

        Me.Cursor = Cursors.Arrow
    End Sub
End Class