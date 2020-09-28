Imports Helios.General
Public Class frmConsultaVentaGuiaRem
#Region "Attributes"
    Public Property listaMeses As New List(Of MesesAnio)
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Meses()
        FormatoGridPequeño(dgvConfirmar, True)
        FormatoGridPequeño(dgvHistorialConforme, True)
        txtAnioCompra.Text = AnioGeneral
    End Sub
#End Region

#Region "Methods"
    Private Sub Meses()
        listaMeses = New List(Of MesesAnio)
        Dim obj As New MesesAnio

        For x = 1 To 12
            obj = New MesesAnio
            obj.Codigo = String.Format("{0:00}", CInt(x))
            obj.Mes = New DateTime(AnioGeneral, x, 1).ToString("MMMM")
            listaMeses.Add(obj)
        Next x

        cboMesPedido.DisplayMember = "Mes"
        cboMesPedido.ValueMember = "Codigo"
        cboMesPedido.DataSource = listaMeses
        cboMesPedido.SelectedValue = MesGeneral
    End Sub
#End Region

#Region "Events"

#End Region
End Class