Public Class frmMaster
    'ReadOnly Property BotonGrabar As ToolStripButton
    '    Get
    '        '      Return Me.SaveToolStripButton
    '    End Get
    'End Property
    'ReadOnly Property BotonNuevo As ToolStripButton
    '    Get
    '        '      Return Me.NewToolStripButton
    '    End Get
    'End Property
    'ReadOnly Property BotonImprimir As ToolStripButton
    '    Get
    '        '        Return PrintToolStripButton
    '    End Get
    'End Property
    'ReadOnly Property BotonAbrir As ToolStripButton
    '    Get
    '        '        Return OpenToolStripButton
    '    End Get
    'End Property
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'BotonGrabar.Visible = False
        'BotonNuevo.Visible = False
        'BotonAbrir.Visible = False
        'BotonImprimir.Visible = False
    End Sub

    'Private Sub tsOpciones_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)
    '    Try
    '        Select Case e.ClickedItem.Name
    '            Case BotonGrabar.Name
    '                Grabar()
    '            Case BotonNuevo.Name
    '        End Select
    '    Catch ex As Exception

    '    End Try
    'End Sub
    ''' <summary>
    ''' Realizar las validaciones necesarias antes de grabar.
    ''' </summary>
    ''' <returns>Retorn verdadero sólo si pasó las validaciones</returns>
    ''' <remarks>Si no se tiene que validar nada, retornar siempre VERDADERO.
    ''' </remarks>
    Public Overridable Function ValidarGrabar() As Boolean
        Return False
    End Function
    ' ''' <summary>
    ' ''' Graba toda la información del formulario
    ' ''' </summary>
    ' ''' <remarks></remarks>
    ''Public Overridable Sub Grabar()

    'End Sub

    Private Sub frmMaster_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class