Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General

Public Class FormCrearServcioInfraDet
#Region "ATTRIBUTES"
    Public Property ServicioInfraestructuraSA As New ServicioInfraestructuraDetSA

    Public Property Manipulation As Entity.EntityState

    Public Property ID As Integer

#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        txtFecha.Value = Date.Now

    End Sub

    Public Sub New(IDServicio As Integer, secuencia As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        txtFecha.Value = Date.Now


        GetUbicarAgencia(IDServicio, secuencia)

    End Sub

#End Region

#Region "Methods"

    Private Sub GetUbicarAgencia(IDEstable As Integer, Secuencia As Integer)

        Dim unidad = ServicioInfraestructuraSA.GellAllServiciosInfraDetxID(IDEstable, Secuencia)

        If unidad IsNot Nothing Then
            txtDescripcion.Tag = unidad.servicio
            txtDescripcion.Text = unidad.detalleServicio
        End If

    End Sub

    Private Sub GrabarServicio(idServicio As Integer)
        Dim tipoEstab As String = String.Empty

        Dim unidad As New servicioInfraestructuraDet With
        {
         .idServicioInfraestructura = idServicio,
       .[detalleServicio] = txtDescripcion.Text,
        .[estado] = "SR",
       .[usuarioModificacion] = usuario.IDUsuario,
        .[fechaModificacion] = Date.Now
        }

        ServicioInfraestructuraSA.InsertServicioInfraestructuraSingle(unidad)

        MessageBox.Show("Item registrado con exito", "Organización", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close()
    End Sub

    Private Sub UpdateServicio(idServicio As Integer)
        Dim tipoEstab As String = String.Empty

        Dim unidad As New servicioInfraestructuraDet With
        {
         .idServicioInfraestructura = idServicio,
         .servicio = txtDescripcion.Tag,
         .[detalleServicio] = txtDescripcion.Text
        }

        ServicioInfraestructuraSA.InsertServicioInfraestructuraSingle(unidad)

        MessageBox.Show("Item registrado con exito", "Organización", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close()
    End Sub

#End Region

#Region "Events"
    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        If (Manipulation = 1) Then
            GrabarServicio(ID)
        ElseIf (Manipulation = 2) Then
            UpdateServicio(ID)
        End If
    End Sub

    Private Sub RoundButton22_Click(sender As Object, e As EventArgs) Handles RoundButton22.Click
        Dispose()
    End Sub

#End Region
End Class