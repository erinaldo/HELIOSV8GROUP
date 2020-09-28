Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Public Class TabMG_Categorias

#Region "Variables"

#End Region

#Region "Constructor"

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.


        FormatoGridAvanzado(dgvCompras, True, False, 9.0F)
        OrdenamientoGrid(dgvCompras, True)
        GradientPanel11.Visible = True


    End Sub

#End Region

#Region "Metodos"


    Private Sub GetTableCategorias(tipo As String)
        Dim itemSA As New itemSA
        Dim dt As New DataTable
        ' Dim tables() As String = {"1", "2", "6", "10", "14", ""}

        With dt.Columns
            .Add("idItem")
            .Add("nomPadre")
            .Add("idPadre")
            .Add("descripcion")
            .Add("tipo")
            .Add("codigo")
        End With


        Dim objeto As New item

        objeto.idEmpresa = Gempresas.IdEmpresaRuc
        objeto.tipo = tipo

        For Each i In itemSA.GetListaItemsPorTipoPadre(objeto) '.Where(Function(o) tables.Contains(o.idtabla)).ToList
            dt.Rows.Add(i.idItem, i.nombrePadre, i.idPadre, i.descripcion, i.tipo, i.codigo)
        Next
        dgvCompras.DataSource = dt
        dgvCompras.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        dgvCompras.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click




        Select Case cboCategorias.Text
            Case "PRINCIPAL"
                GetTableCategorias(TipoGrupoArticulo.Principal)
            Case "CLASIFICACION"
                GetTableCategorias(TipoGrupoArticulo.CategoriaGeneral)
            Case "SUBCLASIFICACION"
                GetTableCategorias(TipoGrupoArticulo.SubCategoriaGeneral)
            Case "MARCA"
                GetTableCategorias(TipoGrupoArticulo.Marca)
            Case "MODELO/PRESENTACION"
                GetTableCategorias(TipoGrupoArticulo.Presentacion)
        End Select




    End Sub

    Private Sub ToolStripLabel1_Click(sender As Object, e As EventArgs) Handles ToolStripLabel1.Click
        Select Case cboCategorias.Text
            Case "PRINCIPAL"
                GetTableCategorias(TipoGrupoArticulo.Principal)
            Case "CLASIFICACION"
                GetTableCategorias(TipoGrupoArticulo.CategoriaGeneral)
            Case "SUBCLASIFICACION"
                GetTableCategorias(TipoGrupoArticulo.SubCategoriaGeneral)
            Case "MARCA"
                GetTableCategorias(TipoGrupoArticulo.Marca)
            Case "MODELO/PRESENTACION"
                GetTableCategorias(TipoGrupoArticulo.Presentacion)
        End Select
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Dim r As Record = dgvCompras.Table.CurrentRecord
        Try
            If r IsNot Nothing Then


                Select Case r.GetValue("tipo")
                    Case TipoGrupoArticulo.Principal

                        Dim h As New frmNuevoGrupoPrin
                        h.lblCodigo.Text = r.GetValue("idItem")
                        h.txtDescripcion.Text = r.GetValue("descripcion")

                        If r.GetValue("codigo").ToString.Trim.Length > 0 Then
                            h.chkCodigo.Checked = True
                            h.txtCodigo.Visible = True
                            h.txtCodigo.Text = r.GetValue("codigo")
                        End If


                        h.StartPosition = FormStartPosition.CenterParent
                        h.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                        h.ShowDialog()

                    Case TipoGrupoArticulo.CategoriaGeneral

                        Dim i As New frmNuevoGrupoClas
                        i.lblidgrupo.Text = r.GetValue("idpadre")
                        i.txtGrupo.Text = r.GetValue("nomPadre")
                        'i.txtGrupo.Text = txtPrincipal.Text
                        i.lblCodigo.Text = r.GetValue("idItem")
                        i.txtDescripcion.Text = r.GetValue("descripcion")
                        i.StartPosition = FormStartPosition.CenterParent
                        i.ManipulacionEstado = ENTITY_ACTIONS.UPDATE

                        If r.GetValue("codigo").ToString.Trim.Length > 0 Then
                            i.chkCodigo.Checked = True
                            i.txtCodigo.Visible = True
                            i.txtCodigo.Text = r.GetValue("codigo")
                        End If

                        i.ShowDialog()

                    Case TipoGrupoArticulo.SubCategoriaGeneral

                        Dim j As New frmNuevaClasificacion
                        j.txtClasificacion.Text = r.GetValue("idpadre")
                        j.txtClasificacion.Text = r.GetValue("nomPadre")
                        'j.lblidClasificacion.Text = txtClasificacion.Tag
                        j.lblCodigo.Text = r.GetValue("idItem")
                        j.txtDescripcion.Text = r.GetValue("descripcion")
                        j.StartPosition = FormStartPosition.CenterParent
                        j.ManipulacionEstado = ENTITY_ACTIONS.UPDATE

                        If r.GetValue("codigo").ToString.Trim.Length > 0 Then
                            j.chkCodigo.Checked = True
                            j.txtCodigo.Visible = True
                            j.txtCodigo.Text = r.GetValue("codigo")
                        End If

                        j.ShowDialog()

                    Case TipoGrupoArticulo.Marca

                        Dim k As New frmNuevaMarca
                        k.StartPosition = FormStartPosition.CenterParent
                        'f.lblidSubClasificacion.Text = txtSubClasificacion.Tag
                        'f.txtSubClasificacion.Text = txtSubClasificacion.Text
                        'k.llblCodigo.Text = r.GetValue("idItem")
                        k.lblCodigo.Text = r.GetValue("idItem")
                        k.txtDescripcion.Text = r.GetValue("descripcion")
                        k.ManipulacionEstado = ENTITY_ACTIONS.UPDATE

                        If r.GetValue("codigo").ToString.Trim.Length > 0 Then
                            k.chkCodigo.Checked = True
                            k.txtCodigoInterno.Visible = True
                            k.txtCodigoInterno.Text = r.GetValue("codigo")
                        End If

                        k.ShowDialog()

                    Case TipoGrupoArticulo.Presentacion


                        Dim l As New frmNuevoPresentacion
                        l.StartPosition = FormStartPosition.CenterParent
                        l.lblCodigo.Text = r.GetValue("idItem")
                        l.txtDescripcion.Text = r.GetValue("descripcion")
                        l.ManipulacionEstado = ENTITY_ACTIONS.UPDATE


                        If r.GetValue("codigo").ToString.Trim.Length > 0 Then
                            l.chkCodigo.Checked = True
                            l.txtCodigoInterno.Visible = True
                            l.txtCodigoInterno.Text = r.GetValue("codigo")
                        End If
                        l.ShowDialog()





                End Select






            Else
                MsgBox("Debe seleccionar un item", MsgBoxStyle.Exclamation, "Seleccionar fila")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


#End Region

End Class
