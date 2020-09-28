Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Public Class frmNuevaCuentaContable
    Inherits frmMaster

    Public Property ManipulacionEstado() As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ObtenerCuentas()
    End Sub

    Public Sub New(strCuenta As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ObtenerCuentas()
        Editar(strCuenta)
    End Sub

#Region "Métodos"
    Sub Editar(strCuenta As String)
        Dim cuentaSA As New cuentaplanContableEmpresaSA

        With cuentaSA.ObtenerCuentaPorID(Gempresas.IdEmpresaRuc, strCuenta)
            txtCodigoCuenta.Text = .cuenta
            txtnomCuenta.Text = .descripcion
            txtDescripcion.Text = .Observaciones
        End With

    End Sub

    Sub ObtenerCuentas()
        Dim cuentaSA As New cuentaplanContableEmpresaSA

        cboCuentaPadre.DisplayMember = "descripcion"
        cboCuentaPadre.ValueMember = "cuenta"
        cboCuentaPadre.DataSource = cuentaSA.ObtenerCuentasPorEmpresaEscalable(Gempresas.IdEmpresaRuc)

    End Sub

    Sub GrabarCuenta()
        Dim cuenta As New cuentaplanContableEmpresa
        Dim cuentaSA As New cuentaplanContableEmpresaSA

        cuenta = New cuentaplanContableEmpresa With
                 {.cuenta = txtCodigoCuenta.Text,
                  .cuentaPadre = Mid(txtCodigoCuenta.Text, 1, 2),
                  .descripcion = txtnomCuenta.Text.Trim,
                  .Observaciones = txtDescripcion.Text,
                  .idEmpresa = Gempresas.IdEmpresaRuc,
                  .usuarioModificacion = usuario.IDUsuario,
                  .fechaModificacion = DateTime.Now}

        cuentaSA.GrabarCuenta(cuenta)
        Dispose()
    End Sub

    Sub EditarCuenta()
        Dim cuenta As New cuentaplanContableEmpresa
        Dim cuentaSA As New cuentaplanContableEmpresaSA

        cuenta = New cuentaplanContableEmpresa With
                 {.cuenta = txtCodigoCuenta.Text,
                  .cuentaPadre = Mid(txtCodigoCuenta.Text, 1, 2),
                  .descripcion = txtnomCuenta.Text.Trim,
                  .Observaciones = txtDescripcion.Text,
                  .idEmpresa = Gempresas.IdEmpresaRuc,
                  .usuarioModificacion = usuario.IDUsuario,
                  .fechaModificacion = DateTime.Now}

        cuentaSA.EditarCuenta(cuenta)
        Dispose()
    End Sub
#End Region

    Private Sub frmNuevaCuentaContable_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmNuevaCuentaContable_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dispose()
    End Sub

    Private Sub cboCuentaPadre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCuentaPadre.SelectedIndexChanged
        If cboCuentaPadre.SelectedIndex > -1 Then
            txtCodigoCuenta.Text = cboCuentaPadre.SelectedValue & "1"
        End If
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                GrabarCuenta()
            Else
                EditarCuenta()
            End If

        Catch ex As Exception
            MessageBoxAdv.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub
End Class