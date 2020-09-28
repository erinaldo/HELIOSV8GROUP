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
Imports HtmlAgilityPack
Imports System.Net.Http
Imports Helios.Cont.Business.Logic

Public Class FormNuevoReserva

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        cargarAgencias()

    End Sub

    Public Sub cargarAgencias()
        Try
            Dim lista = ListaAgencias.Where(Function(o) o.TipoEstab = "UN").ToList
            Dim IDPADRE As New centrocosto
            cboRutas.DataSource = lista
            cboRutas.DisplayMember = "nombre"
            cboRutas.ValueMember = "idCentroCosto"

            cargarDAtos()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub TxtEdad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEdad.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                ListView1.Select()
                ListView1.Focus()
                'ListView1.DroppedDown = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub cargarDAtos()
        Try
            Dim img As ImageList = New ImageList
            img.ImageSize = New Size(50, 50)

            'ListView1. = img
            ''For Each item In ImageList1.ListImages.Count - 1
            ListView1.LargeImageList = ImageList1
            '''Next
            '''

            'ListView1.Alignment = ListViewAlignment.Left
            'ImageList1.ImageSize = New Size(50, 50)

            'For Each ITEMSSS In ImageList1.Images


            '    'Dim item As New ListViewItem()
            '    'item.ImageIndex = j

            '    ListView1.Items.Add(ITEMSSS)

            'Next

            'ListView1.LargeImageList = ImageList1
            'ListView1.SmallImageList = ImageList1
            'ListView1.Items(0).ImageIndex = 0


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BtnReserva_Click(sender As Object, e As EventArgs) Handles btnReserva.Click
        Try
            Dim configuracionBE As configuracionReserva
            Dim configuracionSA As New configuracionReservaSA

            configuracionBE = New configuracionReserva
            configuracionBE.[idEmpresa] = Gempresas.IdEmpresaRuc
            configuracionBE.[idEstablecimiento] = cboRutas.SelectedValue
            configuracionBE.[descripcion] = cboRutas.Text
            configuracionBE.[color] = ListView1.SelectedItems(0).SubItems(0).Text
            configuracionBE.[abreviatura] = txtEdad.Text
            configuracionBE.[estado] = "A"
            configuracionBE.[usuarioActualizacion] = usuario.IDUsuario
            configuracionBE.[fechaModificacion] = DateTime.Now

            configuracionSA.GetConfiguracionInsert(configuracionBE)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub



End Class
