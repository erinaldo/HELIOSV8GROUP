Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class ucHistorialGuiaDoc
    Private listaGuias As List(Of documentoGuia)

#Region "Constructors"
    Public Sub New(venta As documentoventaAbarrotes)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatGrid_DarkCell(GridTraslado, Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center, BorderStyle.None)
        FormatGrid_DarkCell(GridBienesTraslados, Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center, BorderStyle.None)

        _venta = venta
        GetHistorialEntregas()
    End Sub

    Public ReadOnly Property _venta As documentoventaAbarrotes


#End Region

#Region "Methods"
    Private Sub GetHistorialEntregas()
        Dim guiaSA As New DocumentoGuiaSA
        listaGuias = guiaSA.ListaGuiasPorCompra(_venta.idDocumento)

        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("fechaoper")
        dt.Columns.Add("tipodoc")
        dt.Columns.Add("serie")
        dt.Columns.Add("numero")
        dt.Columns.Add("cliente")
        dt.Columns.Add("nroitems")
        dt.Columns.Add("btEliminar")
        dt.Columns.Add("enviosunat")

        For Each i In listaGuias
            If i.EnvioSunat IsNot Nothing Then
                dt.Rows.Add(i.idDocumento, i.fechaDoc, i.tipoDoc, i.serie, i.numeroDoc, _venta.CustomEntidad.nombreCompleto, $"{i.documentoguiaDetalle.Count} Item(s).", "", i.EnvioSunat)
            Else
                dt.Rows.Add(i.idDocumento, i.fechaDoc, i.tipoDoc, i.serie, i.numeroDoc, _venta.CustomEntidad.nombreCompleto, $"{i.documentoguiaDetalle.Count} Item(s).", "", "NO")
            End If
        Next
        GridTraslado.DataSource = dt

    End Sub

    Private Sub GetDetalleGuia(id As Integer)
        Dim guiaSel = listaGuias.Where(Function(o) o.idDocumento = id).SingleOrDefault()

        Dim dt As New DataTable("Detalle de bienes trasladados")
        dt.Columns.Add("id")
        dt.Columns.Add("codigo")
        dt.Columns.Add("detalle")
        dt.Columns.Add("unidad")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("btdelete")

        For Each i In guiaSel.documentoguiaDetalle
            dt.Rows.Add(i.secuencia, $"P-{i.idItem}", i.descripcionItem, i.unidadMedida, i.cantidad)
        Next
        GridBienesTraslados.DataSource = dt

    End Sub
#End Region

    Private Sub ucHistorialGuiaDoc_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub GridTraslado_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles GridTraslado.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 8 Then
                e.Inner.Style.Description = "Eliminar"
                e.Inner.Style.TextColor = Color.LightGreen
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
                                           New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
                    )
                '    e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
            End If

            If e.Inner.ColIndex = 9 Then
                e.Inner.Style.Description = "Vista de Impresión"
                e.Inner.Style.TextColor = Color.LightGreen
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
                                           New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
                    )
                '    e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
            End If
        End If
    End Sub


    Public Sub EnviarAnulacionDocumento(objeto As documentoventaAbarrotes)
        Try
            Dim documentoventasa As New DocumentoGuiaSA

            Dim objetoBaja As New Helios.Fact.Sunat.Business.Entity.RecepcionComunicacionBaja

            objetoBaja.IdDocumento = objeto.serieVenta & "-" & String.Format("{0:00000000}", CInt(objeto.numeroVenta))
            objetoBaja.TipoDocumento = objeto.tipoDocumento
            objetoBaja.idEmpresa = Gempresas.ubigeo
            objetoBaja.FechaEmision = objeto.fechaDoc
            objetoBaja.EnvioSunat = "NO"
            objetoBaja.estadoEnvio = "PE"
            objetoBaja.Contribuyente_id = Gempresas.IdEmpresaRuc

            Dim codigo = Helios.Fact.Sunat.WCFService.ServiceAccess.Admin.RecepcionComunicacionBajaSA.RecepcionComunicacionBajaSave(objetoBaja, Nothing)

            If codigo.idAnulacion > 0 Then
                'ActualizarEnvioSunat("0", objeto)
                documentoventasa.UpdateGuiaXEstado(objeto.idDocumento, "SI") ', codigo.idAnulacion, 0)

                MessageBox.Show("La comunicacion se Envio Correctamente al PSE")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GridTraslado_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles GridTraslado.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        'Dim guiaSA As New DocumentoSA
        Dim guiaSA As New DocumentoGuiaSA
        Try
            If e.Inner.ColIndex = 8 Then
                If GridTraslado.Table.CurrentRecord IsNot Nothing Then
                    If GridTraslado.Table.CurrentRecord IsNot Nothing Then
                        If MessageBox.Show("Elminar guia seleccionada?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            Dim style As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
                            Dim codigoGuia = style.TableCellIdentity.Table.CurrentRecord.GetValue("id")
                            ' guiaSA.DeleteSingleVariable(codigoGuia)
                            'guiaSA.EliminatGuia(New documento() With {.idDocumento = codigoGuia})
                            Dim rptasunat = style.TableCellIdentity.Table.CurrentRecord.GetValue("enviosunat")
                            If rptasunat = "NO" Then
                                MessageBox.Show("La Guia Debe ser enviada primero!", "Validar Envio de Cpe", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End If

                            If My.Computer.Network.IsAvailable = True Then
                                Dim f As New FormAnularVenta(CDate(style.TableCellIdentity.Table.CurrentRecord.GetValue("fechaoper")))
                                f.StartPosition = FormStartPosition.CenterParent
                                f.ShowDialog(Me)
                                If f.Tag IsNot Nothing Then
                                    Dim c = CType(f.Tag, Boolean)
                                    If c = True Then 'fecha dentro del rango permitido

                                        Dim objeto As New documentoventaAbarrotes
                                        objeto.idDocumento = CInt(style.TableCellIdentity.Table.CurrentRecord.GetValue("id"))
                                        objeto.tipoDocumento = style.TableCellIdentity.Table.CurrentRecord.GetValue("tipodoc")
                                        objeto.serieVenta = style.TableCellIdentity.Table.CurrentRecord.GetValue("serie")
                                        objeto.numeroVenta = CInt(style.TableCellIdentity.Table.CurrentRecord.GetValue("numero"))
                                        objeto.fechaDoc = CDate(style.TableCellIdentity.Table.CurrentRecord.GetValue("fechaoper"))

                                        Try
                                            If Gempresas.ubigeo > 0 Then

                                                If My.Computer.Network.Ping("138.128.171.106") Then

                                                    Try
                                                        'EliminarPV(Val(Me.DgvComprobantes.Table.CurrentRecord.GetValue("idDocumento")))
                                                        guiaSA.EliminatGuia(New documento() With {.idDocumento = codigoGuia})
                                                        If GridTraslado.Table.CurrentRecord IsNot Nothing Then
                                                            Dim envio = Me.GridTraslado.Table.CurrentRecord.GetValue("enviosunat")
                                                            If envio.ToString.Trim.Length > 0 Then
                                                                EnviarAnulacionDocumento(objeto)
                                                                GridTraslado.Table.CurrentRecord.Delete()
                                                            End If
                                                        End If

                                                    Catch ex As Exception
                                                        MsgBox(ex.Message)

                                                    End Try


                                                Else
                                                    MessageBox.Show("No tiene conexión con el servidor SPK!", "Verificar conexión a internet", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                End If

                                            Else
                                                guiaSA.EliminatGuia(New documento() With {.idDocumento = codigoGuia})
                                            End If
                                            'btnAnularVenta.Enabled = True
                                        Catch ex As Exception
                                            'btnAnularVenta.Enabled = True
                                        End Try


                                    Else
                                        MessageBox.Show("No puede anular la venta, debe estar dentro del rango de 5 días hábiles!", "Validar fechas", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    End If
                                End If
                            Else
                                MessageBox.Show("No tiene conexión a internet!", "Verificar conexión a internet", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If











                            MessageBox.Show("Documento eliminado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            'style.TableCellIdentity.Table.CurrentRecord.Delete()
                        End If
                    End If
                End If
            End If

            If e.Inner.ColIndex = 9 Then
                If GridTraslado.Table.CurrentRecord IsNot Nothing Then
                    If GridTraslado.Table.CurrentRecord IsNot Nothing Then
                        '  If MessageBox.Show("Elminar guia seleccionada?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        Dim style As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
                        Dim codigoGuia = style.TableCellIdentity.Table.CurrentRecord.GetValue("id")
                        Dim guia = listaGuias.Where(Function(o) o.idDocumento = codigoGuia).SingleOrDefault()
                        ' guiaSA.DeleteSingleVariable(codigoGuia)

                        Dim f As New FormReimpresionGuias(guia)
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog(Me)
                        '    End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub GridTraslado_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridTraslado.TableControlCellClick
        If e.TableControl.Table.CurrentRecord IsNot Nothing Then
            GetDetalleGuia(Integer.Parse(e.TableControl.Table.CurrentRecord.GetValue("id")))
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Try


            Cursor = Cursors.WaitCursor
            Dim r As Record = GridTraslado.Table.CurrentRecord
            If r IsNot Nothing Then

                Dim guiaSA As New DocumentoGuiaSA
                Dim COMPROBANTE As New documentoGuia
                COMPROBANTE = guiaSA.GetVentaIDGuia(New documento With {.idDocumento = r.GetValue("id")})
                Dim f As New FormImpresionNuevo(COMPROBANTE, 1) 'FormImpresionNuevo(Integer.Parse(r.GetValue("idDocumento")))
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog(Me)
            Else
                MessageBox.Show("Debe seleccionar un documento válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
