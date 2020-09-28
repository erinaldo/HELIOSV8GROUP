
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Syncfusion.Windows.Forms
Imports System.Text.RegularExpressions

Public Class FormUbigeo

#Region "ATRIBUTOS"
    Dim listaUbigeoFull As New List(Of regiones)
    Dim Ubregion As New regiones
#End Region

#Region "CONSTTUCTOR"

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Me.KeyPreview = True
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        CargarUbigeo() '****DEBE ESTAR PRIMERO
        CargarDEfaultUbigeo() '****DEBE ESTAR SEGUNDO
    End Sub


#End Region
    Private Sub CargarUbigeo()
        Dim ActivoUbigeoSA As New ubigeoSA
        listaUbigeoFull = ActivoUbigeoSA.ListarGetUbigeos()

    End Sub

    Private Sub CargarDEfaultUbigeo()
        'Try
        '    'Dim result = Diferentes.Distinct(New ItemEqualityComparer())

        '    cbDepartamento.DisplayMember = "name"
        '    cbDepartamento.ValueMember = "id"
        '    cbDepartamento.DataSource = listaUbigeoFull
        '    cbDepartamento.SelectedValue = "120000"

        '    Ubregion = listaUbigeoFull.Where(Function(z) z.id = "120000").FirstOrDefault

        '    cbProvincia.DisplayMember = "name"
        '    cbProvincia.ValueMember = "id"
        '    cbProvincia.DataSource = Ubregion.provincia.ToList
        '    cbProvincia.SelectedValue = "120100"

        '    Dim provincia = Ubregion.provincia.Where(Function(z) z.id = "120100").FirstOrDefault

        '    cbDis.DisplayMember = "name"
        '    cbDis.ValueMember = "id"
        '    cbDis.DataSource = provincia.distrito.ToList
        '    cbDis.SelectedValue = "120107"
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
    End Sub


    Private Sub listaProvincia(cod As String)
        '' Dim codPro As String = cbDepartamento.SelectedValue.ToString

        'Try

        '    Dim provincia = Ubregion.provincia.Where(Function(z) z.id = cod).FirstOrDefault

        '    cbDis.DisplayMember = "name"
        '    cbDis.ValueMember = "id"
        '    cbDis.DataSource = provincia.distrito.ToList

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
    End Sub

    Private Sub listaDepartamento(idDep As String)
        'Try

        '    Ubregion = listaUbigeoFull.Where(Function(z) z.id = idDep).FirstOrDefault

        '    cbProvincia.DisplayMember = "name"
        '    cbProvincia.ValueMember = "id"
        '    cbProvincia.DataSource = Ubregion.provincia.ToList

        '    Dim provincia = Ubregion.provincia.Where(Function(z) z.id = cbProvincia.SelectedValue).FirstOrDefault

        '    cbDis.DisplayMember = "name"
        '    cbDis.ValueMember = "id"
        '    cbDis.DataSource = provincia.distrito.ToList

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
    End Sub

    Private Sub cbDepartamento_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbDepartamento.SelectionChangeCommitted
        listaDepartamento(cbDepartamento.SelectedValue)
    End Sub

    Private Sub cbProvincia_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbProvincia.SelectionChangeCommitted
        listaProvincia(cbProvincia.SelectedValue)
    End Sub

    Private Sub btnGuardarUbig_Click(sender As Object, e As EventArgs) Handles btnGuardarUbig.Click
        Dim Dist As New distritos With {
            .id = cbDis.SelectedValue,
            .name = cbDis.Text
            }
        Tag = Dist
        Me.Close()
    End Sub


    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData

            Case Keys.Enter
                btnGuardarUbig.PerformClick()

                'Case Keys.F2
                '    btGrabar.PerformClick()

                'Case Keys.F4
                '    'ToolStripButton1.PerformClick()
                '    UCEstructuraCabeceraVentaV2.TextFiltrar.Select()
                '    UCEstructuraCabeceraVentaV2.TextFiltrar.Focus()
                '    UCEstructuraCabeceraVentaV2.TextFiltrar.SelectAll()

                'Case Keys.F5
                '    ToolStripButton1.PerformClick()

                'Case Keys.F3
                '    UCEstructuraCabeceraVentaV2.Button1.PerformClick()

                'Case Keys.F8
                '    'If (ValidarKey = True) Then
                '    'btGrabar.PerformClick()
                '    ToolStripButton3.PerformClick()

                'Case Keys.F9
                '    ToolStripButton4.PerformClick()

                'Case Keys.Escape
                '    Close()

                'If UCEstructuraCabeceraVentaV2 IsNot Nothing Then
                '    UCEstructuraCabeceraVentaV2.ucB_OKEvent()
                'End If
            Case Else
                'Do Nothing
        End Select

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

End Class