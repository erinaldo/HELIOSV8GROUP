Imports System.IO
Imports System.Net
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports ProcesosGeneralesCajamiSoft
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class TabP_RestBartMaster

    Private Property SelRazon As entidad
    Private Property entidadSA As New entidadSA

    Private Property personaBeneficioSA As New personaBeneficioSA

    Public Property FormPurchase As FormControlRestaurant



    Public Sub New(formRepPiscina As FormControlRestaurant)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormPurchase = formRepPiscina
    End Sub

    Public Sub New(formRepPiscina As FormControlRestaurant, tipo As Integer)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormPurchase = formRepPiscina
        RoundButton25.Visible = False
        RoundButton26.Visible = False
        RoundButton24.Visible = False
    End Sub


#Region "Metodos"

#End Region


    Private Sub RoundButton25_Click(sender As Object, e As EventArgs) Handles RoundButton25.Click
        Try
            Dim cajaUsuarioSA As New cajaUsuarioSA

            If ListaCajasActivas.Count = 0 Or ListaCajasActivas Is Nothing Then
                MessageBox.Show("Debe registrar una caja para realizar la venta")
                ListaCajasActivas = cajaUsuarioSA.ListadoCajaXEstado(New cajaUsuario With {
                                                                 .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                 .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                 .estadoCaja = "A"
                                                                 })
                Exit Sub
            End If

            Dim f As New FormVentaTouch
            f.GetComboSecundario()
            f.VENTADIRECTA = True
            f.UCEstructuraCabeceraVentaV2.PanelCenter.Size = New Size(521, 114)
            f.UCEstructuraCabeceraVentaV2.pnVEntaDirecta.Visible = True
            f.UCEstructuraCabeceraVentaV2.txtInfraestructura.Visible = False
            f.UCEstructuraCabeceraVentaV2.CargarCategorias()
            f.ComboComprobante.Text = "NOTA DE VENTA"
            f.StartPosition = FormStartPosition.CenterParent
            f.Show(Me)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub RoundButton23_Click(sender As Object, e As EventArgs) Handles RoundButton23.Click
        Try
            FormPurchase.TabR_GestionCajaCentralizada.Visible = False
            FormPurchase.TabP_RestaurantMaster.Visible = False
            If FormPurchase.TabR_GestionInfraRestaurant IsNot Nothing Then
                FormPurchase.TabR_GestionInfraRestaurant.pnCargaDatos.Visible = True
                FormPurchase.TabR_GestionInfraRestaurant.Visible = True
                FormPurchase.TabR_GestionInfraRestaurant.CargarDefault()
                FormPurchase.TabR_GestionInfraRestaurant.BringToFront()
                FormPurchase.TabR_GestionInfraRestaurant.Show()
                FormPurchase.TabR_GestionInfraRestaurant.pnCargaDatos.Visible = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub RoundButton26_Click(sender As Object, e As EventArgs) Handles RoundButton26.Click
        Try
            FormPurchase.TabP_RestaurantMaster.Visible = False
            FormPurchase.TabR_GestionInfraRestaurant.Visible = False
            If FormPurchase.TabR_GestionCajaCentralizada IsNot Nothing Then
                FormPurchase.TabR_GestionCajaCentralizada.Visible = True
                FormPurchase.TabR_GestionCajaCentralizada.CargarDefault()
                FormPurchase.TabR_GestionCajaCentralizada.BringToFront()
                FormPurchase.TabR_GestionCajaCentralizada.Show()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        Dim f As New FormGestionProductos
        f.StartPosition = FormStartPosition.CenterParent
        f.Show(Me)
    End Sub

    Private Sub RoundButton22_Click(sender As Object, e As EventArgs)
        Try
            Dim cajaUsuarioSA As New cajaUsuarioSA

            If ListaCajasActivas.Count = 0 Or ListaCajasActivas Is Nothing Then
                MessageBox.Show("Debe registrar una caja para realizar la venta")
                ListaCajasActivas = cajaUsuarioSA.ListadoCajaXEstado(New cajaUsuario With {
                                                                 .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                 .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                 .estadoCaja = "A"
                                                                 })
                Exit Sub
            End If

            Dim f As New FormVentaTouch

            f.GetComboPrincipal()
            f.UCEstructuraCabeceraVentaV2.PanelCenter.Size = New Size(521, 114)
            f.UCEstructuraCabeceraVentaV2.pnVEntaDirecta.Visible = True
            f.UCEstructuraCabeceraVentaV2.txtInfraestructura.Visible = False
            f.UCEstructuraCabeceraVentaV2.CargarCategorias()
            f.ComboComprobante.Text = "PRE VENTA"
            f.ComboComprobante.ReadOnly = True
            f.StartPosition = FormStartPosition.CenterParent
            f.Show(Me)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
