Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping

Public Class UCMaestroAgenciaEmp

#Region "Attributes"

    Public Property FormPurchase As FormTablaPrincipalTransportes
#End Region


#Region "Constructors"
    Public Sub New(FormventaNueva As FormTablaPrincipalTransportes)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        FormatoGridAvanzado(GridRutas, True, False, 10.0F)
        FormPurchase = FormventaNueva
    End Sub


#End Region

#Region "Methods"

    Private Sub GetceNTROcoSTOS()
        Try

            Dim CentrocostosSA As New CentrocostosSA
            Dim REGIONSA As New regionesSA
            Dim LISTAREGIONES As New List(Of regiones)

            Dim dt As New DataTable
            dt.Columns.Add("ID")
            dt.Columns.Add("AGENCIA")
            dt.Columns.Add("DEPARTAMENTO")
            dt.Columns.Add("PROVINCIA")
            dt.Columns.Add("DISTRITO")
            dt.Columns.Add("DIRECCION")

            LISTAREGIONES = REGIONSA.ListarUbigeosActivos()

            For Each i In CentrocostosSA.GetObtenerEstablecimiento(Gempresas.IdEmpresaRuc).ToList

                Dim REGION As New regiones
                Dim PROVINCIA As New provincias
                Dim DISTRITO As New distritos

                REGION = LISTAREGIONES.Where(Function(O) O.id = (i.ubigeo.Substring(0, 2) & "0000")).FirstOrDefault
                PROVINCIA = REGION.provincias.Where(Function(Z) Z.id = (i.ubigeo.Substring(0, 4) & "00")).FirstOrDefault
                DISTRITO = PROVINCIA.distritos.Where(Function(X) X.id = (i.ubigeo.Substring(0, 6))).FirstOrDefault

                dt.Rows.Add(i.idCentroCosto,
                        i.nombre,
                       REGION.name,
                      PROVINCIA.name,
                        DISTRITO.name,
                        i.direccion)
            Next
            GridRutas.DataSource = dt

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        GetceNTROcoSTOS()
    End Sub

    Private Sub BunifuFlatButton5_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton5.Click
        Try
            Me.Visible = False
            FormPurchase.LIMPIAR()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton11_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton11.Click
        Try
            If (Not IsNothing(GridRutas.Table.CurrentRecord)) Then
                Dim Login As New formCrearAgencias
                Login.txtNombreAgencia.Text = GridRutas.Table.CurrentRecord.GetValue("AGENCIA")
                Login.txtDireccion.Text = GridRutas.Table.CurrentRecord.GetValue("DIRECCION")
                Login.txtUbigeo.Text = GridRutas.Table.CurrentRecord.GetValue("DEPARTAMENTO") & "/" & GridRutas.Table.CurrentRecord.GetValue("PROVINCIA") & "/" & GridRutas.Table.CurrentRecord.GetValue("DIRECCION")
                Login.txtTelefono1.Text = ""
                Login.txtTelefono2.Text = ""
                Login.StartPosition = FormStartPosition.CenterParent
                Login.ShowDialog()
            Else
                Throw New Exception("DEBE SELECCIONAR UN DATO")
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


#End Region





End Class
