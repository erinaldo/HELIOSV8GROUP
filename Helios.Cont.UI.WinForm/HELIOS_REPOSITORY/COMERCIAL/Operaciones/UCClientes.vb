Imports System.Threading
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes
Imports Syncfusion.Drawing
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class UCClientes
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Private Thread As Thread
    Dim filter As New GridExcelFilter()
    Public ListadoClientes As List(Of Helios.Cont.Business.Entity.entidad)
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(dgvCliente, True, False, 9.0F)
        FormatoGridAvanzado(GridAtributos, False, False, 9.0F)
        GridAtributos.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        OrdenamientoGrid(dgvCliente, True)
        OrdenamientoGrid(GridAtributos, True)
        'Dim empresa As String = Gempresas.IdEmpresaRuc
        'PictureLoad.Visible = True
        'Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetClientes(empresa)))
        'Thread.Start()

        AddHandler dgvCliente.TableModel.QueryRowHeight, AddressOf TableModel_QueryRowHeight

    End Sub


    Private Sub TableModel_QueryRowHeight(ByVal sender As Object, ByVal e As GridRowColSizeEventArgs)
        If e.Index > 0 Then
            Dim graphicsProvider As IGraphicsProvider = Me.dgvCliente.TableModel.GetGraphicsProvider()
            Dim g As Graphics = graphicsProvider.Graphics
            Dim style As GridStyleInfo = Me.dgvCliente.TableModel(e.Index, 4)
            Dim model As GridCellModelBase = style.CellModel
            e.Size = model.CalculatePreferredCellSize(g, e.Index, 4, style, GridQueryBounds.Height).Height
            e.Handled = True
        End If
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

    Private Sub GetClientes(empresa As String)
        Dim entidadsa As New entidadSA
        Dim dt As New DataTable
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

        For Each i In ListadoClientes
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
            dgvCliente.DataSource = table
            PictureLoad.Visible = False
        End If
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        Dim f As New frmCrearENtidades With
        {
        .strTipo = TIPO_ENTIDAD.CLIENTE,
        .ManipulacionEstado = ENTITY_ACTIONS.INSERT,
        .StartPosition = FormStartPosition.CenterParent
        }
        f.CaptionLabels(0).Text = "Nuevo cliente"
        f.ShowDialog(Me)
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        Cursor = Cursors.WaitCursor
        If Not IsNothing(dgvCliente.Table.CurrentRecord) Then
            If dgvCliente.Table.CurrentRecord.GetValue("razon") <> "CLIENTES VARIOS" Then
                Dim f As New frmCrearENtidades(CInt(dgvCliente.Table.CurrentRecord.GetValue("idEntidad")))
                f.CaptionLabels(0).Text = "Editar Cliente"
                f.strTipo = TIPO_ENTIDAD.CLIENTE
                '   f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE 
                f.intIdEntidad = dgvCliente.Table.CurrentRecord.GetValue("idEntidad")
                'f.UbicarEntidad(dgvProveedor.Table.CurrentRecord.GetValue("idEntidad"))
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()


                GetClientes(Gempresas.IdEmpresaRuc)
            End If
        Else
            MessageBox.Show("Debe seleccionar un cliente!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        Dim empresa As String = Gempresas.IdEmpresaRuc
        PictureLoad.Visible = True
        Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetClientes(empresa)))
        Thread.Start()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        dgvCliente.TopLevelGroupOptions.ShowFilterBar = True
        dgvCliente.NestedTableGroupOptions.ShowFilterBar = True
        dgvCliente.ChildGroupOptions.ShowFilterBar = True
        For Each col As GridColumnDescriptor In dgvCliente.TableDescriptor.Columns
            col.AllowFilter = True
        Next
        filter.AllowResize = True
        filter.AllowFilterByColor = True
        filter.EnableDateFilter = True
        filter.EnableNumberFilter = True

        dgvCliente.OptimizeFilterPerformance = True
        dgvCliente.ShowNavigationBar = True
        filter.WireGrid(dgvCliente)
    End Sub

    Private Sub DgvCliente_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCliente.TableControlCellClick
        If dgvCliente.Table.Records.Count > 0 Then
            Dim r As Record = dgvCliente.Table.CurrentRecord
            GetAtributoSelCliente(Integer.Parse(r.GetValue("idEntidad")))
        End If
    End Sub

    Private Sub BunifuFlatButton5_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton5.Click
        Dim atributoSA As New entidadAtributosSA
        Dim r As Record = dgvCliente.Table.CurrentRecord
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


        'Dim AtributosCliente = (From cli In ListadoClientes
        '                        From atri In cli.entidadAtributos
        '                        Where atri.idEntidad = Integer.Parse(r.GetValue("idEntidad"))
        '                        Select atri).ToList

        Dim be = atributoSA.AtributoEntidadSave(nuevoPrice)

        Clientes.entidadAtributos.Add(be)
        'atributos.Add(be)
        GetAtributoSelCliente(Integer.Parse(r.GetValue("idEntidad")))
    End Sub

    Private Sub GridAtributos_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridAtributos.TableControlCellClick

    End Sub

    Private Sub GridAtributos_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs) Handles GridAtributos.TableControlCurrentCellChanged

    End Sub

    Private Sub EditarDomicilio(currentRecord As Record)
        Dim idAtr = Integer.Parse(currentRecord.GetValue("idAtributo"))

        Dim atributoSA As New entidadAtributosSA
        'Dim AtributosCliente = (From cli In ListadoClientes
        '                        From atri In cli.entidadAtributos
        '                        Where atri.idAtributo.Equals(idAtr)
        '                        Select atri).SingleOrDefault

        Dim Clientes = ListadoClientes.Where(Function(o) o.idEntidad = Integer.Parse(dgvCliente.Table.CurrentRecord.GetValue("idEntidad"))).SingleOrDefault
        Dim AtributosCliente = Clientes.entidadAtributos.Where(Function(a) a.idAtributo = idAtr).SingleOrDefault


        AtributosCliente.Action = Business.Entity.BaseBE.EntityAction.UPDATE
        AtributosCliente.idEntidad = Integer.Parse(dgvCliente.Table.CurrentRecord.GetValue("idEntidad"))
        AtributosCliente.tipo = "DOMICILIO"
        AtributosCliente.estado = 1
        AtributosCliente.valorAtributo = currentRecord.GetValue("detalle")
        AtributosCliente.usuarioModificacion = usuario.IDUsuario
        AtributosCliente.fechaModificacion = Date.Now
        atributoSA.AtributoEntidadSave(AtributosCliente)
        GetAtributoSelCliente(Integer.Parse(dgvCliente.Table.CurrentRecord.GetValue("idEntidad")))
    End Sub

    Private Sub GridAtributos_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles GridAtributos.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex

        Dim cc As GridCurrentCell = GridAtributos.TableControl.CurrentCell
        cc.ConfirmChanges()
        Try
            ' If cc.Renderer IsNot Nothing Then

            If cc.ColIndex > -1 Then
                Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

                If style.TableCellIdentity.Column.Name = "detalle" Then

                    If cc.Renderer IsNot Nothing Then
                        '  If e.TableControl.Model.Modified = True Then
                        Dim text As String = cc.Renderer.ControlText
                        If GridAtributos.Table.CurrentRecord IsNot Nothing Then
                            GridAtributos.Table.CurrentRecord.SetValue("detalle", text)
                            EditarDomicilio(GridAtributos.Table.CurrentRecord)
                        End If
                    End If

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "validar ingreso")
        End Try
    End Sub

    Private Sub BunifuFlatButton6_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton6.Click
        If GridAtributos.Table.CurrentRecord IsNot Nothing Then
            GridAtributos.TableControl.CurrentCell.EndEdit()
            GridAtributos.TableControl.Table.TableDirty = True
            GridAtributos.TableControl.Table.EndEdit()

            If MessageBox.Show("Eliminar el domicilio seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim atributoSA As New entidadAtributosSA
                Dim id = GridAtributos.Table.CurrentRecord.GetValue("idAtributo")
                atributoSA.AtributoEntidadSave(New entidadAtributos With {.Action = BaseBE.EntityAction.DELETE, .idAtributo = id})

                Dim Clientes = ListadoClientes.Where(Function(o) o.idEntidad = Integer.Parse(dgvCliente.Table.CurrentRecord.GetValue("idEntidad"))).SingleOrDefault
                Dim AtributosCliente = Clientes.entidadAtributos.Where(Function(a) a.idAtributo = id).SingleOrDefault
                Clientes.entidadAtributos.Remove(AtributosCliente)
                GetAtributoSelCliente(Integer.Parse(dgvCliente.Table.CurrentRecord.GetValue("idEntidad")))
            End If
        Else
            MessageBox.Show("Seleccionar un domicilio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
End Class
