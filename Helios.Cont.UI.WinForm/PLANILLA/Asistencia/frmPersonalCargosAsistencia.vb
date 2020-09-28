Imports Helios.Planilla.Business.Entity

Public Class frmPersonalCargosAsistencia

    Private Property ListaCargosSelec As List(Of PersonalCargo)

    Public Sub New(listaCargos As List(Of PersonalCargo))

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        LoadCargos(listaCargos)
    End Sub

    Private Sub LoadCargos(listaCargos As List(Of PersonalCargo))
        Dim index = 0
        For Each i In listaCargos
            ListView1.Items.Add(i.DescripcionLarga).Tag = i.IDCargo 'Add Each Item Of Zodiac Array

            ListView1.Items(index).ImageIndex = 0 'Align ImageList Images With Array Items
            index = index + 1
        Next
    End Sub


    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click

        ListaCargosSelec = New List(Of PersonalCargo)
        For Each i As ListViewItem In ListView1.CheckedItems
            ListaCargosSelec.Add(New PersonalCargo With {.IDCargo = Integer.Parse(i.Tag), .DescripcionLarga = i.SubItems(0).Text})
        Next
        Tag = ListaCargosSelec
        If ListaCargosSelec.Count > 0 Then
            Close()
        Else
            MessageBox.Show("Debe seleccionar al menos un cargo", "Seleccionar cargo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub
End Class