Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Helios.General
Imports Syncfusion.Grouping
Imports Helios.Cont.Business.Entity
Imports Syncfusion.Windows.Forms.Tools
Public Class UCComisionDesembolso

    Public listaComision As List(Of registrocomision_autorizacion)
    Public usuario As Helios.Seguridad.Business.Entity.Usuario
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGrid(GridProducts)
    End Sub

    Private Sub FormatoGrid(grid As GridGroupingControl)
        grid.Appearance.AnyCell.TextColor = Color.WhiteSmoke
        grid.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        grid.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        grid.TableOptions.ListBoxSelectionMode = SelectionMode.One
        grid.TableOptions.SelectionBackColor = Color.FromArgb(85, 170, 255)
        grid.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        grid.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
    End Sub

    Private Sub TextBoxExt1_TextChanged(sender As Object, e As EventArgs) Handles TextUsuario.TextChanged

    End Sub

    Private Sub TextDescripcion_TextChanged(sender As Object, e As EventArgs) Handles TextCodigo.TextChanged

    End Sub

    Private Sub TextDescripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles TextCodigo.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            usuario = UsuariosList.Where(Function(o) o.codigo = TextCodigo.Text.Trim).SingleOrDefault
            If usuario IsNot Nothing Then
                TextUsuario.Text = usuario.Full_Name
                TextUsuario.Tag = usuario
            End If
        End If
    End Sub

    Private Sub BunifuFlatButton6_Click(sender As Object, e As EventArgs) Handles bunifuFlatButton6.Click
        Cursor = Cursors.WaitCursor
        If TextUsuario.Tag IsNot Nothing Then
            Dim usuario = CType(TextUsuario.Tag, Helios.Seguridad.Business.Entity.Usuario)
            GetComisiones(usuario)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GetComisiones(usuario As Helios.Seguridad.Business.Entity.Usuario)
        Dim comisionSA As New registrocomision_autorizacionSA

        Dim dt As New DataTable
        dt.Columns.Add("usuario")
        dt.Columns.Add("usuariocode")
        dt.Columns.Add("fechaventa")
        dt.Columns.Add("tipodoc")
        dt.Columns.Add("nroventa")
        dt.Columns.Add("moneda")
        dt.Columns.Add("producto")
        dt.Columns.Add("unidadcomercial")
        dt.Columns.Add("catalogo")
        dt.Columns.Add("importeventa")
        dt.Columns.Add("importecomision")
        dt.Columns.Add("estadoventa")
        dt.Columns.Add("estadocomision")
        dt.Columns.Add("comision", GetType(registrocomision_autorizacion))


        listaComision = comisionSA.registrocomision_autorizacionSelUsuario(New registrocomision_usuarios_detalle With
                                                                         {
                                                                         .IdUsuario = usuario.IDUsuario
                                                                         })

        For Each i In listaComision
            dt.Rows.Add(
                usuario.Full_Name,
                usuario.IDUsuario,
                i.customDocumentoVenta.fechaDoc,
                i.customDocumentoVenta.tipoDocumento,
                $"{i.customDocumentoVenta.serieVenta}-{i.customDocumentoVenta.numeroVenta}",
                i.customDocumentoVenta.moneda,
                i.customProducto.descripcionItem,
                i.customUnidadComercial.unidadComercial,
                i.customCatalogoPrecio.nombre_corto,
                i.customRegistrocomision_usuarios_detalle.valorComision,
                i.importeAutorizado,
                i.customDocumentoVenta.estadoCobro,
                i.customRegistrocomision_usuarios_detalle.estadoComision,
                i)

        Next
        GridProducts.DataSource = dt
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        Dim usuarioBeneficiario = CType(TextUsuario.Tag, Seguridad.Business.Entity.Usuario)

        Dim f As New FormConfirmaDesembolsoComision(usuarioBeneficiario, listaComision)
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
    End Sub
End Class
