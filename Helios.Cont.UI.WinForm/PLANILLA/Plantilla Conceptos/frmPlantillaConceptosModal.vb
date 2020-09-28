Imports Helios.Planilla.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping

Public Class frmPlantillaConceptosModal

#Region "Attributes"
    Private Property plantillaSA As New PlantillaSA
#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        ConfiguracionesInicio()
        FormatoGridPequeño(dgPlantilla, True)
        GetPlantillas()
        GradientPanel8.Visible = True
    End Sub

#End Region

#Region "Methods"
    Private Sub ConfiguracionesInicio()
        dgPlantilla.TableDescriptor.Columns("IDPlantilla").HeaderText = "ID"
        dgPlantilla.TableDescriptor.Columns("DescripcionCorta").HeaderText = "Abrev."
        dgPlantilla.TableDescriptor.Columns("DescripcionLarga").HeaderText = "Descripción"
    End Sub

    Private Sub GetPlantillas()
        Dim dt As New DataTable
        dt.Columns.Add("IDPlantilla").Caption = "ID"
        dt.Columns.Add("DescripcionCorta")
        dt.Columns.Add("DescripcionLarga")

        For Each i In plantillaSA.PlantillaSelAll
            dt.Rows.Add(i.IDPlantilla,
                        i.DescripcionCorta,
                        i.DescripcionLarga)
        Next
        dgPlantilla.DataSource = dt
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Dim plantillaSeleccionada As Integer = 0
        Dim r As Record = dgPlantilla.Table.CurrentRecord
        If r IsNot Nothing Then
            plantillaSeleccionada = Integer.Parse(r.GetValue("IDPlantilla"))
            Tag = plantillaSeleccionada
            Close()
        Else
            MessageBox.Show("Debe seleccionar una plantilla", "Seleccionar fila", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
    End Sub
#End Region

#Region "Events"

#End Region


End Class