Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Text.RegularExpressions
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports HtmlAgilityPack
Imports PopupControl
Imports ProcesosGeneralesCajamiSoft
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Imports System.Xml
Imports Syncfusion.Drawing
Public Class FormFiltroPeriodoCliente

#Region "Atributos"

    Private Property SelRazon As entidad
    Private Property entidadSA As New entidadSA

#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GetMeses()
    End Sub
#End Region

#Region "methods"
    Sub GetMeses()
        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.DataSource = General.ListaDeMeses
        cboMesCompra.SelectedValue = String.Format("{0:00}", DateTime.Now.Month)

        TExtAnio.DecimalValue = DateTime.Now.Year
    End Sub

    Private Sub FillLSVClientes(consulta As List(Of entidad))
        LsvProveedor.Items.Clear()
        '     Dim image = ImageList1.Images(0)
        For Each i In consulta
            Dim n As New ListViewItem(i.idEntidad)

            n.SubItems.Add(i.nombreCompleto)
            n.SubItems.Add(i.nrodoc)
            n.SubItems.Add(i.tipoDoc)
            LsvProveedor.Items.Add(n)
        Next
    End Sub

    Private Function GetValidarLocalDB(idEntidad As String) As Boolean
        GetValidarLocalDB = False
        Dim entidadSA As New entidadSA

        Dim entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", idEntidad)
        If entidad IsNot Nothing Then
            SelRazon = New entidad
            SelRazon = entidad
            TextProveedor.Text = entidad.nombreCompleto
            TextProveedor.Tag = entidad.idEntidad
            GetValidarLocalDB = True
            PictureLoad.Visible = False

            If TextProveedor.Text.Trim.Length > 0 Then

            Else
                TextNumIdentrazon.Clear()
                TextNumIdentrazon.Select()
            End If
        End If
    End Function

#End Region

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click

        Dim datos As List(Of item) = item.Instance()
        datos.Clear()
        Dim c As New item

        Dim periodo As New Date(TExtAnio.DecimalValue, CInt(cboMesCompra.SelectedValue), 1)
        Tag = periodo

        c.descripcion = cboComprobantes.Text
        c.idEntidad = TextProveedor.Tag
        c.fechaActualizacion = periodo
        datos.Add(c)

        Close()
    End Sub

    Private Sub TextNumIdentrazon_TextChanged(sender As Object, e As EventArgs) Handles TextNumIdentrazon.TextChanged

    End Sub

    Private Sub TextNumIdentrazon_KeyDown(sender As Object, e As KeyEventArgs) Handles TextNumIdentrazon.KeyDown

        TextProveedor.Text = ""
        TextProveedor.Tag = Nothing


        If RadioButton1.Checked = True Then
            Dim nombres = String.Empty
            Try
                'TextNumIdentrazon.Enabled = False
                If e.KeyCode = Keys.Enter Then
                    e.SuppressKeyPress = True

                    Select Case TextNumIdentrazon.Text.Trim.Length
                        Case 8 'dni

                            SelRazon = New entidad

                            Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", TextNumIdentrazon.Text.Trim)
                            If existeEnDB Is Nothing Then

                            Else
                                TextProveedor.Text = existeEnDB.nombreCompleto
                                TextProveedor.Tag = existeEnDB.idEntidad
                                TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)

                            End If




                        Case 11 'razonSocial
                            PictureLoad.Visible = True
                            Dim objeto As Boolean = ValidationRUC(TextNumIdentrazon.Text.Trim)
                            If objeto = False Then
                                PictureLoad.Visible = False
                                MessageBox.Show("Debe Ingresar un número correcto de ruc", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Cursor = Cursors.Default
                                TextProveedor.Clear()
                                Exit Sub
                            End If


                            If GetValidarLocalDB(TextNumIdentrazon.Text.Trim) = False Then

                            End If


                        Case Else
                            TextProveedor.Text = String.Empty
                            TextNumIdentrazon.Text = String.Empty
                            MessageBox.Show("Ingrese un documento correcto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End Select

                End If




            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub TextProveedor_TextChanged(sender As Object, e As EventArgs) Handles TextProveedor.TextChanged

    End Sub

    Private Sub TextProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles TextProveedor.KeyDown

        TextNumIdentrazon.Text = ""

        If RBFullName.Checked = True Then
            If RBFullName.Checked = True Then
                Dim entidadSA As New entidadSA
                If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

                Else
                    If e.KeyCode = Keys.Enter Then
                        e.SuppressKeyPress = True
                        Dim consulta = entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, "CL", TextProveedor.Text.Trim)

                        If consulta.Count > 0 Then
                            FillLSVClientes(consulta)
                            Me.pcLikeCategoria.Size = New Size(282, 128)
                            Me.pcLikeCategoria.ParentControl = Me.TextProveedor
                            Me.pcLikeCategoria.ShowPopup(Point.Empty)
                        End If
                        e.Handled = True
                    End If
                End If

                If e.KeyCode = Keys.Down Then
                    '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
                    If LsvProveedor.Items.Count > 0 Then
                        Me.pcLikeCategoria.Size = New Size(282, 128)
                        Me.pcLikeCategoria.ParentControl = Me.TextProveedor
                        Me.pcLikeCategoria.ShowPopup(Point.Empty)
                        LsvProveedor.Focus()
                    End If
                End If
                '   End If

                ' e.SuppressKeyPress = True
                If e.KeyCode = Keys.Escape Then
                    If Me.pcLikeCategoria.IsShowing() Then
                        Me.pcLikeCategoria.HidePopup(PopupCloseType.Canceled)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub pcLikeCategoria_CloseUp(sender As Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs) Handles pcLikeCategoria.CloseUp
        Dim beneficioSA As New beneficioSA
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.PopupCloseType = PopupCloseType.Done Then
                If LsvProveedor.SelectedItems.Count > 0 Then

                    TextProveedor.Text = LsvProveedor.SelectedItems(0).SubItems(1).Text
                    TextProveedor.Tag = LsvProveedor.SelectedItems(0).SubItems(0).Text
                    TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    TextNumIdentrazon.Text = LsvProveedor.SelectedItems(0).SubItems(2).Text
                End If
            End If

            'Set focus back to textbox.
            If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
                Me.TextProveedor.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LsvProveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LsvProveedor.SelectedIndexChanged
        Me.pcLikeCategoria.HidePopup(PopupCloseType.Done)
    End Sub
End Class