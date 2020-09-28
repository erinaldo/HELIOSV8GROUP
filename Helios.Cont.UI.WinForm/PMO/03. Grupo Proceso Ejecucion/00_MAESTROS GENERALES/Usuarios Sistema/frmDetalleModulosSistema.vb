Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Helios.Seguridad.Business.Entity
Imports Helios.General
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid

Public Class frmDetalleModulosSistema

#Region "Attributes"
    Public Property AsegurableSA As New AsegurableSA
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridPequeño(dgAsegurables, True)
        GetAsegurables()
    End Sub
#End Region

#Region "Methods"
    Sub GetAsegurables()
        dgAsegurables.DataSource = AsegurableSA.ListadoAsegurables
        dgAsegurables.TableOptions.ListBoxSelectionMode = SelectionMode.One
        dgAsegurables.TableDescriptor.Columns("Nombre").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        dgAsegurables.TableDescriptor.Columns("Nombre").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
    End Sub
#End Region

#Region "Events"
    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        Cursor = Cursors.WaitCursor
        GetAsegurables()
        Cursor = Cursors.Default
    End Sub
#End Region
End Class