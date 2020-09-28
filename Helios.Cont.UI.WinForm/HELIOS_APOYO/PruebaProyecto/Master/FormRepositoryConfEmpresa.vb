Public Class FormRepositoryConfEmpresa
#Region "Attributes"
    Public Property UCOrganigrama As UCOrganigrama
    Public Property UCCargos As UCCargos
    Public Property UCEmpresa As UCEmpresa
    Public Property UCNumeracion As UCNumeracion

    Public Property UCModulosApoyo As UCModulosApoyo

    '  Public Property UCLogisticaAlmacen As UCLogisticaAlmacen
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.


        UCEmpresa = New UCEmpresa(Me) With {.Dock = DockStyle.Fill}
        PanelBody.Controls.Add(UCEmpresa)

        UCOrganigrama = New UCOrganigrama With {.Dock = DockStyle.Fill}
        PanelBody.Controls.Add(UCOrganigrama)

        UCCargos = New UCCargos With {.Dock = DockStyle.Fill}
        PanelBody.Controls.Add(UCCargos)

        UCNumeracion = New UCNumeracion With {.Dock = DockStyle.Fill}
        PanelBody.Controls.Add(UCNumeracion)

        UCModulosApoyo = New UCModulosApoyo With {.Dock = DockStyle.Fill}
        PanelBody.Controls.Add(UCModulosApoyo)


    End Sub

#End Region

    Private Sub bunifuImageButton2_Click(sender As Object, e As EventArgs) Handles bunifuImageButton2.Click
        Try

            If (Not IsNothing(UCEmpresa.dgPedidos.Table.CurrentRecord)) Then

                Dim Login As New FormOrgainizacionV2(UCEmpresa.dgPedidos.Table.CurrentRecord.GetValue("idEmpresa"))
                Login.StartPosition = FormStartPosition.CenterParent
                Login.ShowDialog()
                Application.DoEvents()
                Me.Dispose()
            Else
                MessageBox.Show("Debe seleccionar una empresa para comenzar")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs) Handles BunifuImageButton1.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BunifuFlatButton15_Click(sender As Object, e As EventArgs) Handles btnOrganigrama.Click, btnTipoDoc.Click, btnProducto.Click, btnCargo.Click, btnNumeracion.Click, BunifuFlatButton3.Click, btnApoyo.Click
        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width
        '  End If
        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        Select Case btn.Text
            Case "EMPRESA"
                UCOrganigrama.Visible = False
                UCCargos.Visible = False
                UCNumeracion.Visible = False
                UCModulosApoyo.Visible = False
                If UCEmpresa IsNot Nothing Then
                    UCEmpresa.Visible = True
                    UCEmpresa.BringToFront()
                    UCEmpresa.Show()

                    btnOrganigrama.Visible = False
                    btnCargo.Visible = False
                    btnNumeracion.Visible = False
                    btnTipoDoc.Visible = False
                    btnProducto.Visible = False

                End If

            Case "ORGANIGRAMA"
                UCEmpresa.Visible = False
                UCCargos.Visible = False
                UCNumeracion.Visible = False
                UCModulosApoyo.Visible = False

                If UCOrganigrama IsNot Nothing Then
                    UCOrganigrama.Visible = True
                    UCOrganigrama.BringToFront()
                    UCOrganigrama.Show()
                End If

            Case "CARGOS"
                UCEmpresa.Visible = False
                UCOrganigrama.Visible = False
                UCNumeracion.Visible = False
                UCModulosApoyo.Visible = False

                If UCCargos IsNot Nothing Then
                    UCCargos.Visible = True
                    UCCargos.BringToFront()
                    UCCargos.Show()
                End If

            Case "NUMERACION"
                UCEmpresa.Visible = False
                UCOrganigrama.Visible = False
                UCCargos.Visible = False
                UCModulosApoyo.Visible = False

                If UCNumeracion IsNot Nothing Then
                    UCNumeracion.Visible = True
                    UCNumeracion.BringToFront()
                    UCNumeracion.Show()
                End If

            Case "TABLERO"

            Case "REPORTES"

            Case "MODULOS APOYO"
                UCEmpresa.Visible = False
                UCOrganigrama.Visible = False
                UCCargos.Visible = False
                UCNumeracion.Visible = False

                If UCModulosApoyo IsNot Nothing Then
                    UCModulosApoyo.Visible = True
                    UCModulosApoyo.BringToFront()
                    UCModulosApoyo.Show()
                End If

            Case "ACCESO DE PRODUCTO"
                UCEmpresa.Visible = False
                UCOrganigrama.Visible = False
                UCCargos.Visible = False

                If UCNumeracion IsNot Nothing Then
                    UCNumeracion.Visible = True
                    UCNumeracion.BringToFront()
                    UCNumeracion.Show()
                End If

        End Select
    End Sub


End Class