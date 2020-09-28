Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General

Public Class FormCrearServcioInfra
#Region "ATTRIBUTES"
    Public Property ServicioInfraestructuraSA As New ServicioInfraestructuraSA

    Public Property Manipulation As Entity.EntityState

#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        txtFecha.Value = Date.Now

    End Sub

#End Region

#Region "Methods"

    Private Sub GetUbicarAgencia(IDEstable As Integer)
        'Dim unidad = ServicioInfraestructuraSA.(IDEstable)
        'If unidad IsNot Nothing Then
        '    txtFecha.Tag = unidad.idCentroCosto
        '    txtFecha.Value = unidad.fechaActualizacion
        '    TextColor.Text = unidad.nombre
        '    TextBoxExt1.Text = unidad.otrasReferencias
        'End If
    End Sub

    Private Sub GrabarServicio()
        Dim tipoEstab As String = String.Empty

        Dim unidad As New ServicioInfraestructura With
        {
        .[idEmpresa] = Gempresas.IdEmpresaRuc,
        .[descripcionServicio] = txtDescripcion.Text,
        .[tipoServicio] = "SR",
        .[usuarioModificacion] = usuario.IDUsuario,
        .[fechaModificacion] = Date.Now
        }

        ServicioInfraestructuraSA.InsertServicioInfraestructura(unidad)

        MessageBox.Show("Item registrado con exito", "Organización", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close()
    End Sub

#End Region

#Region "Events"
    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        GrabarServicio()
    End Sub

    Private Sub RoundButton22_Click(sender As Object, e As EventArgs) Handles RoundButton22.Click
        Dispose()
    End Sub

#End Region
End Class