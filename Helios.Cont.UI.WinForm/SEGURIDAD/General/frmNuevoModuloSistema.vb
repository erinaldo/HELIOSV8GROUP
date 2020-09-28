Imports Helios.Seguridad.Business.Entity
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmNuevoModuloSistema

#Region "Attributes"
    Public Property strEstadoManipulacion() As String
    Public Property AsegurableSA As New AsegurableSA
    Dim idAsegurableAct As Integer
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtFecha.Text = DateTime.Now
        txtFecha.ReadOnly = True
    End Sub

    Public Sub New(idAsegurable As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtFecha.Text = DateTime.Now
        txtFecha.ReadOnly = True
        UbicarAsegurable(idAsegurable)
    End Sub

#End Region

#Region "Methods"


    Public Sub Grabar()
        Dim objAsegurable As New Asegurable
        Try
            objAsegurable = New Asegurable
            With objAsegurable
                .Action = BaseBE.EntityAction.INSERT
                .IDEmpresa = ("GENERICO")
                .Nombre = txtNombres.Text
                .Descripcion = txtDescripcion.Text
                .IDAsegurablePadre = 0
                .UsuarioActualizacion = usuario.IDUsuario
                .FechaActualizacion = Date.Now
            End With

            AsegurableSA.insertAsegurable(objAsegurable)
            MessageBox.Show("Modulo grabado correctamente!", "!Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Close()

        Catch ex As Exception
            MsgBox("Error al grabar modulo. " & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema!")

        End Try

    End Sub

    Public Sub UbicarAsegurable(idAsegurable As Integer)
        Dim AsegurableBE As New Asegurable
        Try
            AsegurableBE = AsegurableSA.ListadoAsegurableXID(idAsegurable)

            With AsegurableBE
                idAsegurableAct = .IDAsegurable
                cboDescripcion.Text = .Descripcion
                txtNombres.Text = .Nombre
                txtFecha.Text = .UsuarioActualizacion
            End With

            MessageBox.Show("se ubico correctamente!", "!Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Close()

        Catch ex As Exception
            MsgBox("Error al uicar modulo. " & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema!")

        End Try

    End Sub

#End Region

#Region "Events"
    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Close()
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        If txtNombres.Text.Trim.Length > 0 Then
            If cboDescripcion.Text.Trim.Length > 0 Then
                If txtFecha.Text.Trim.Length > 0 Then
                    Select Case strEstadoManipulacion
                        Case ENTITY_ACTIONS.INSERT
                            Grabar()
                        Case ENTITY_ACTIONS.UPDATE
                            'Update()
                            Close()
                    End Select
                Else
                    MsgBox("Ingrese una fecha actual", MsgBoxStyle.Information, "!Atención")
                    txtFecha.Focus()

                End If
            Else
                MsgBox("Ingrese una descripcion.", MsgBoxStyle.Information, "!Atención")
                cboDescripcion.Focus()
            End If
        Else
            MsgBox("Ingrese el nombre de modulo.", MsgBoxStyle.Information, "!Atención")
            txtNombres.Focus()
        End If
    End Sub
#End Region

End Class