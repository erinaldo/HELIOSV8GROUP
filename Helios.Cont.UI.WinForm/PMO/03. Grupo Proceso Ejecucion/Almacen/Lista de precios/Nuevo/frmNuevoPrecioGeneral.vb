Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Tools
Public Class frmNuevoPrecioGeneral
    Inherits frmMaster

    Public Property EstadoManipulacion() As String

    Public Property idPrecio() As Integer

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

#Region "Métodos"
    Sub Ubicar(intPrecio As Integer)
        Dim precioSA As New ConfiguracionPrecioSA

        With precioSA.EncontrarPrecioXitem(New configuracionPrecio With {.idPrecio = intPrecio})
            txtPrecio.Text = .tipo
            txtPorcemtaje.Text = .tasaPorcentaje
            'Select Case .tipo
            '    Case "P"
            '        cboTipo.SelectedItem = "PAGADO"
            'End Select

        End With
    End Sub

    'Sub CargarCombos()
    '    Dim precioSA As New ConfiguracionPrecioSA

    '    cboTipo.DisplayMember = "precio"
    '    cboTipo.ValueMember = "idPrecio"
    '    cboTipo.DataSource = precioSA.ListadoPrecios()

    'End Sub

    Sub Grabar()
        Dim precioSA As New ConfiguracionPrecioSA
        Dim precio As New configuracionPrecio
        Try
            precio.precio = txtPrecio.Text
            precio.tasaPorcentaje = txtPorcemtaje.Text
            precio.tipo = "P"
          
            precioSA.GrabarPrecioGeneral(precio)
            Dispose()
        Catch ex As Exception
            MessageBoxAdv.Show(ex.Message)
        End Try
    End Sub

    Sub updatePrecio()
        Dim precioSA As New ConfiguracionPrecioSA
        Dim precio As New configuracionPrecio
        Try
            precio.precio = txtPrecio.Text
            precio.tasaPorcentaje = txtPorcemtaje.Text
            precio.tipo = "P"

            precioSA.UpdatePrecioGeneral(precio)
            Dispose()
        Catch ex As Exception
            MessageBoxAdv.Show(ex.Message)
        End Try
    End Sub

#End Region

    Private Sub ButtonAdv15_Click(sender As Object, e As EventArgs) Handles ButtonAdv15.Click
        Me.Cursor = Cursors.WaitCursor

        If Not txtPrecio.Text.Trim.Length > 0 Then
            MessageBox.Show("Debe ingresar la descripción del precio!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPrecio.Select()
            Exit Sub
        End If

        If Not txtPorcemtaje.DecimalValue > 0 Then
            MessageBox.Show("Debe ingresar una tasa mayor a cero!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPorcemtaje.Select()
            Exit Sub
        End If

        If EstadoManipulacion = ENTITY_ACTIONS.INSERT Then
            Grabar()
        Else
            updatePrecio()
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub frmNuevoPrecioGeneral_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmNuevoPrecioGeneral_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class