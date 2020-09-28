Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports System.IO
Imports OpenInvoicePeru.Comun.Dto.Intercambio
Imports OpenInvoicePeru.Comun.Dto.Modelos
Imports Syncfusion.Windows.Forms.Grid
Imports System.Runtime.Serialization
Imports Syncfusion.GroupingGridExcelConverter
Imports System.Threading
Imports Helios.General.Constantes
Imports Syncfusion.Drawing
Public Class UCPrincipalClientes

#Region "Atributos"
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    'Public Property UCClientes As UCClientes
    Public ListadoClientes As List(Of Helios.Cont.Business.Entity.entidad)
#End Region

#Region "Constructor"

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        FormatoGridAvanzado(DgvClientes, False, False, 7.0F)
        ' Add any initialization after the InitializeComponent() call.
        'UCClientes = New UCClientes With {.Dock = DockStyle.Fill}
        FormatoGridPrincipal(DgvClientes)
        'PanelBody.Controls.Add(UCClientes)

    End Sub

#End Region

#Region "Metodos"

    Private Sub EditarDomicilio(currentRecord As Record)
        Dim idAtr = Integer.Parse(currentRecord.GetValue("idAtributo"))

        Dim atributoSA As New entidadAtributosSA
        'Dim AtributosCliente = (From cli In ListadoClientes
        '                        From atri In cli.entidadAtributos
        '                        Where atri.idAtributo.Equals(idAtr)
        '                        Select atri).SingleOrDefault

        Dim Clientes = ListadoClientes.Where(Function(o) o.idEntidad = Integer.Parse(DgvClientes.Table.CurrentRecord.GetValue("idEntidad"))).SingleOrDefault
        Dim AtributosCliente = Clientes.entidadAtributos.Where(Function(a) a.idAtributo = idAtr).SingleOrDefault


        AtributosCliente.Action = Business.Entity.BaseBE.EntityAction.UPDATE
        AtributosCliente.idEntidad = Integer.Parse(DgvClientes.Table.CurrentRecord.GetValue("idEntidad"))
        AtributosCliente.tipo = "DOMICILIO"
        AtributosCliente.estado = 1
        AtributosCliente.valorAtributo = currentRecord.GetValue("detalle")
        AtributosCliente.usuarioModificacion = usuario.IDUsuario
        AtributosCliente.fechaModificacion = Date.Now
        atributoSA.AtributoEntidadSave(AtributosCliente)
        GetAtributoSelCliente(Integer.Parse(DgvClientes.Table.CurrentRecord.GetValue("idEntidad")))
    End Sub
    Private Sub GetAtributoSelCliente(idCliente As Integer)
        Dim dt As New DataTable()
        dt.Columns.Add("idAtributo")
        dt.Columns.Add("detalle")
        dt.Columns.Add("estado")

        Dim at = (From cli In ListadoClientes
                  From atri In cli.entidadAtributos
                  Where cli.idEntidad = idCliente
                  Select atri).ToList

        For Each i In at
            dt.Rows.Add(i.idAtributo, i.valorAtributo, i.estado)
        Next
        GridAtributos.DataSource = dt
    End Sub
    Private Sub GetClientes(empresa As String, filter As String)
        Dim entidadsa As New entidadSA
        Dim dt As New DataTable
        Dim MyClients As New List(Of entidad)
        With dt.Columns
            .Add("idEntidad")
            .Add("tipoDoc")
            .Add("nroDoc")
            .Add("tipo")
            .Add("razon")
            .Add("fono")
            .Add("celular")
            .Add("email")
            .Add("direc")
        End With




        ListadoClientes = (entidadsa.GetListarEntidad(New entidad With {.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})).Where(Function(o) o.tipoEntidad <> "VR").ToList

        Dim MyVarious As New entidad
        MyVarious.nombreCompleto = VarClienteGeneral.nombreCompleto
        MyVarious.idEntidad = VarClienteGeneral.idEntidad
        MyVarious.tipoDoc = "0"
        MyVarious.tipoPersona = "N"
        MyVarious.telefono = "-"
        MyVarious.celular = "-"
        MyVarious.email = "-"
        MyVarious.direccion = "-"
        MyVarious.nrodoc = "0"

        MyClients = (From i In ListadoClientes Where i.tipoEntidad = TIPO_ENTIDAD.CLIENTE And i.nombreCompleto.Contains(filter)).ToList


        MyClients.Add(MyVarious)



        For Each i In MyClients
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.idEntidad
            Select Case i.tipoDoc
                Case "6"
                    dr(1) = "RUC"
                Case "1"
                    dr(1) = "DNI"
                Case "7"
                    dr(1) = "PASSAPORTE"
                Case "4"
                    dr(1) = "CARNET DE EXTRANJERIA"
                Case "0"
                    dr(1) = "-"
            End Select

            dr(2) = i.nrodoc
            dr(3) = IIf(i.tipoPersona = "N", "NATURAL", "JURIDICO")
            dr(4) = i.nombreCompleto
            dr(5) = i.telefono
            dr(6) = i.celular
            dr(7) = i.email
            dr(8) = i.direccion
            dt.Rows.Add(dr)
        Next



        setDatasource(dt)
    End Sub

    Public Sub setDatasource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            Dim deleg As New SetDataSourceDelegate(AddressOf setDatasource)
            Invoke(deleg, New Object() {table})
        Else
            DgvClientes.DataSource = table
            'PictureLoad.Visible = False
        End If
    End Sub

#End Region


    Private Sub txtBuscarCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscarCliente.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True

                Dim empresa As String = Gempresas.IdEmpresaRuc
                GetClientes(empresa, txtBuscarCliente.Text)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub DgvClientes_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles DgvClientes.TableControlCellClick
        If DgvClientes.Table.Records.Count > 0 Then
            Dim r As Record = DgvClientes.Table.CurrentRecord
            GetAtributoSelCliente(Integer.Parse(r.GetValue("idEntidad")))
        End If
    End Sub

    Private Sub btnNuevoDomicilio_Click(sender As Object, e As EventArgs) Handles btnNuevoDomicilio.Click
        Try




            Dim atributoSA As New entidadAtributosSA
            Dim r As Record = DgvClientes.Table.CurrentRecord
            Dim nuevoPrice As New Helios.Cont.Business.Entity.entidadAtributos With
                                  {
                                  .idEntidad = Integer.Parse(r.GetValue("idEntidad")),
                                  .tipo = "DOMICILIO",
                                  .valorAtributo = "NUEVO DOMICILIO...",
                                  .estado = 1,
                                  .usuarioModificacion = usuario.IDUsuario,
                                  .fechaModificacion = Date.Now
                                  }



            Dim Clientes = ListadoClientes.Where(Function(o) o.idEntidad = Integer.Parse(r.GetValue("idEntidad"))).SingleOrDefault
            Dim atributos = Clientes.entidadAtributos.ToList()


            Dim be = atributoSA.AtributoEntidadSave(nuevoPrice)

            Clientes.entidadAtributos.Add(be)

            GetAtributoSelCliente(Integer.Parse(r.GetValue("idEntidad")))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAnularVenta_Click(sender As Object, e As EventArgs) Handles btnAnularVenta.Click
        Try


            If GridAtributos.Table.CurrentRecord IsNot Nothing Then
                GridAtributos.TableControl.CurrentCell.EndEdit()
                GridAtributos.TableControl.Table.TableDirty = True
                GridAtributos.TableControl.Table.EndEdit()

                If MessageBox.Show("Eliminar el domicilio seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Dim atributoSA As New entidadAtributosSA
                    Dim id = GridAtributos.Table.CurrentRecord.GetValue("idAtributo")
                    atributoSA.AtributoEntidadSave(New entidadAtributos With {.Action = BaseBE.EntityAction.DELETE, .idAtributo = id})

                    Dim Clientes = ListadoClientes.Where(Function(o) o.idEntidad = Integer.Parse(DgvClientes.Table.CurrentRecord.GetValue("idEntidad"))).SingleOrDefault
                    Dim AtributosCliente = Clientes.entidadAtributos.Where(Function(a) a.idAtributo = id).SingleOrDefault
                    Clientes.entidadAtributos.Remove(AtributosCliente)
                    GetAtributoSelCliente(Integer.Parse(DgvClientes.Table.CurrentRecord.GetValue("idEntidad")))
                End If
            Else
                MessageBox.Show("Seleccionar un domicilio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GridAtributos_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridAtributos.TableControlCellClick

    End Sub

    Private Sub GridAtributos_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles GridAtributos.TableControlCurrentCellEditingComplete
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex

        'Dim cc As GridCurrentCell = GridAtributos.TableControl.CurrentCell
        'cc.ConfirmChanges()
        'Try
        '    ' If cc.Renderer IsNot Nothing Then

        '    If cc.ColIndex > -1 Then
        '        Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

        '        If style.TableCellIdentity.Column.Name = "detalle" Then

        '            If cc.Renderer IsNot Nothing Then
        '                '  If e.TableControl.Model.Modified = True Then
        '                Dim text As String = cc.Renderer.ControlText
        '                If GridAtributos.Table.CurrentRecord IsNot Nothing Then
        '                    GridAtributos.Table.CurrentRecord.SetValue("detalle", text)
        '                    EditarDomicilio(GridAtributos.Table.CurrentRecord)
        '                End If
        '            End If

        '        End If
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, "validar ingreso")
        'End Try
    End Sub

    Private Sub btnDocumentos_Click(sender As Object, e As EventArgs) Handles btnDocumentos.Click
        Dim r As Record = DgvClientes.Table.CurrentRecord
        If Not IsNothing(r) Then




            Dim clas = (Me.DgvClientes.Table.CurrentRecord.GetValue("idEntidad"))

            If clas.ToString.Trim.Length > 0 Then

                Dim f As New frmClientDetailsDocuments
                f.lblIdCliente.Text = clas
                f.lblNameClient.Text = Me.DgvClientes.Table.CurrentRecord.GetValue("razon")
                f.StartPosition = FormStartPosition.CenterParent
                f.Show(Me)

            End If

        Else
            MessageBox.Show("Seleccione un Cliente!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub



    Private Sub GridAtributos_TableControlCurrentCellValidated(sender As Object, e As GridTableControlEventArgs) Handles GridAtributos.TableControlCurrentCellValidated
        Dim equivalenciaSA As New detalleitem_equivalenciasSA
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim cc As GridCurrentCell = GridAtributos.TableControl.CurrentCell
        'cc.ConfirmChanges()
        If cc.Renderer IsNot Nothing Then
            Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

            If style.TableCellIdentity.Column.Name = "detalle" Then
                If cc.Renderer IsNot Nothing Then
                    Dim text As String = cc.Renderer.ControlText
                    Dim oldValue = Me.GridAtributos.TableModel(cc.RowIndex, 0).CellValue
                    Dim newValue = text
                    Dim r = style.TableCellIdentity.DisplayElement.GetRecord()
                    If oldValue <> newValue Then
                        Dim mensaje = $"Nombre Dirección: {newValue} Desea guardar cambios ?"
                        If MessageBox.Show(mensaje, "Unidad comercial", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            Me.GridAtributos.EndUpdate(True)
                            r.SetValue("detalle", newValue)
                            If text.Trim.Length > 0 Then
                                If GridAtributos.Table.CurrentRecord IsNot Nothing Then

                                    'Dim codigoExiste = equivalenciaSA.GetExisteCodeUnidadComercial(New detalleitem_equivalencias() With
                                    '                                                               {
                                    '                                                               .codigo = newValue
                                    '                                                               })

                                    'If (codigoExiste) Then
                                    '    cc.RejectChanges()
                                    '    Me.GridAtributos.TableModel(cc.RowIndex, 1).CellValue = oldValue
                                    '    Me.GridAtributos.EndUpdate(True)
                                    '    MessageBox.Show("El codigo ingresado no está disponible, ingrese otro!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    '    Exit Sub
                                    'Else

                                    EditarDomicilio(r)
                                    'End If
                                End If
                                'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
                            End If
                        Else
                            cc.RejectChanges()
                            Me.GridAtributos.TableModel(cc.RowIndex, 1).CellValue = oldValue
                            Me.GridAtributos.EndUpdate(True)
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub txtBuscarCliente_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarCliente.TextChanged

    End Sub

    Private Sub btnRegistroCotizaciones_Click(sender As Object, e As EventArgs) Handles btnRegistroCotizaciones.Click
        Dim f As New FormQuotesClients
        f.StartPosition = FormStartPosition.CenterParent
        f.Show(Me)
    End Sub

    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click


        Dim f As New frmCrearENtidades With
        {
        .strTipo = TIPO_ENTIDAD.CLIENTE,
        .ManipulacionEstado = ENTITY_ACTIONS.INSERT,
        .StartPosition = FormStartPosition.CenterParent
        }
        f.CaptionLabels(0).Text = "Nuevo cliente"
        f.ShowDialog(Me)

        'Dim f As New FrmSuccess("Cliente Registrado")
        'f.ShowDialog()


        'FrmSuccess.ConfirmationForm("Cliente Registrado")
    End Sub

    Private Sub btnEditarCliente_Click(sender As Object, e As EventArgs) Handles btnEditarCliente.Click
        Cursor = Cursors.WaitCursor
        If Not IsNothing(DgvClientes.Table.CurrentRecord) Then
            If DgvClientes.Table.CurrentRecord.GetValue("razon") <> "CLIENTES VARIOS" Then
                Dim f As New frmCrearENtidades(CInt(DgvClientes.Table.CurrentRecord.GetValue("idEntidad")))
                f.CaptionLabels(0).Text = "Editar Cliente"
                f.strTipo = TIPO_ENTIDAD.CLIENTE
                '   f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE 
                f.intIdEntidad = DgvClientes.Table.CurrentRecord.GetValue("idEntidad")
                'f.UbicarEntidad(dgvProveedor.Table.CurrentRecord.GetValue("idEntidad"))
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()



                GetClientes(Gempresas.IdEmpresaRuc, "")
            End If
        Else
            MessageBox.Show("Debe seleccionar un cliente!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub btnVerDetalle_Click(sender As Object, e As EventArgs) Handles btnVerDetalle.Click

    End Sub
End Class
