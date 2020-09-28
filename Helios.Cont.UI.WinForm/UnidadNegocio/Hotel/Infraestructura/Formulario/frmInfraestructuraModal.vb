Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmInfraestructuraModal

    Dim IMAGEN As String

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        CargarCombos()
    End Sub

    Private Sub CargarCombos()
        Dim componenteBE As New componente
        Dim componenteSA As New componenteSA
        Dim listaComponente As New List(Of componente)
        Try
            componenteBE.idEmpresa = Gempresas.IdEmpresaRuc
            componenteBE.idEstablecimiento = GEstableciento.IdEstablecimiento
            componenteBE.tipo = "T"
            componenteBE.estado = "A"

            listaComponente = componenteSA.getListaComponenteXTipo(componenteBE)

            cboTipo.DataSource = Nothing

            cboTipo.ValueMember = "idComponente"
            cboTipo.DisplayMember = "descripcionItem"
            cboTipo.DataSource = listaComponente

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub cargarImagen()
        Try
            Me.OpenFileDialog1.ShowDialog()
            If Me.OpenFileDialog1.FileName <> "" Then
                txtRuta.Text = Me.OpenFileDialog1.FileName
                IMAGEN = OpenFileDialog1.FileName
                Dim largo As Integer = IMAGEN.Length
                Dim imagen2 As String
                imagen2 = CStr(Microsoft.VisualBasic.Mid(RTrim(IMAGEN), largo - 2, largo))
                If imagen2 <> "gif" And imagen2 <> "bmp" And imagen2 <> "jpg" And imagen2 <> "jpeg" And imagen2 <> "GIF" And imagen2 <> "BMP" And imagen2 <> "JPG" And imagen2 <> "JPEG" Then
                    imagen2 = CStr(Microsoft.VisualBasic.Mid(RTrim(IMAGEN), largo - 3, largo))
                    If imagen2 <> "jpeg" And imagen2 <> "JPEG" And imagen2 <> "log1" Then
                        txtRuta.Clear()
                        MsgBox("Formato no valido") : Exit Sub
                        If imagen2 <> "log1" Then Exit Sub
                    End If
                    pcImagen.Load(IMAGEN)

                Else
                    pcImagen.Load(IMAGEN)
                End If
            End If
        Catch ex As Exception

        End Try
        'PictureBox1.Load(IMAGEN)
    End Sub

    Private Sub Grabar()
        Try

            If (txtCantidad.Value > 0) Then

                If (txtDescripcion.Text.Length > 0) Then

                    Dim componenteBE As New componente
                    Dim componenteSA As New componenteSA
                    Dim listaComponente As New List(Of componente)
                    For index As Integer = 1 To txtCantidad.Value

                        componenteBE.[idEmpresa] = Gempresas.IdEmpresaRuc
                        componenteBE.[idEstablecimiento] = GEstableciento.IdEstablecimiento
                        componenteBE.[idPadre] = cboTipo.SelectedValue
                        componenteBE.idItem = 0
                        If (txtDescripcion.Text.Length > 0) Then
                            componenteBE.descripcionItem = txtDescripcion.Text
                        Else
                            componenteBE.descripcionItem = cboTipo.Text
                        End If
                        componenteBE.[estado] = "A"
                        componenteBE.[tipo] = "TD"
                        componenteBE.[usuarioActualizacion] = "MAYKOL"
                        componenteBE.[fechaActualizacion] = Date.Now
                        componenteBE.imagen = "S"
                        componenteBE.direccionImagen = txtRuta.Text
                        listaComponente.Add(componenteBE)
                    Next

                    Dim codx = componenteSA.SaveComponenteFull(listaComponente)
                    txtCantidad.Value = 0
                    txtDescripcion.Text = String.Empty

                Else
                    MessageBox.Show("Debe ingresar una descripción!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Debe ingresar una cantidad!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim componenteBE As New componente
        Dim componenteSA As New componenteSA
        Dim listaComponente As New List(Of componente)
        Try
            Dim f As New frmInfraestructuraTipo
            f.txtServicioNew.Select()
            f.CaptionLabels(0).Text = "Nuevo Tipo"
            f.tipo = "Tipo"

            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            If Not IsNothing(f.Tag) Then
                Dim c = CType(f.Tag, componente)

                componenteBE.idEmpresa = Gempresas.IdEmpresaRuc
                componenteBE.idEstablecimiento = GEstableciento.IdEstablecimiento
                componenteBE.tipo = "T"
                componenteBE.estado = "A"

                listaComponente = componenteSA.getListaComponenteXTipo(componenteBE)

                cboTipo.DataSource = Nothing

                cboTipo.ValueMember = "idComponente"
                cboTipo.DisplayMember = "descripcionItem"
                cboTipo.DataSource = listaComponente
                cboTipo.SelectedValue = c.idComponente

                txtDescripcion.Text = cboTipo.Text
                txtCantidad.Value = 0
                txtCantidad.Select(0, txtCantidad.Text.Length)

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtCantidad_Click(sender As Object, e As EventArgs) Handles txtCantidad.Click
        txtCantidad.Select(0, txtCantidad.Text.Length)
    End Sub

    Private Sub Panel7_Click(sender As Object, e As EventArgs) Handles Panel7.Click
        cargarImagen()
        If (txtRuta.Text = "OpenFileDialog1") Then
            txtRuta.Clear()
        End If
    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        Grabar()
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs)
        Close()
    End Sub

End Class