Imports Helios.Seguridad.Business.Entity
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Cont.Business.Entity
Imports Syncfusion.Windows.Forms.Tools
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping

Public Class frmNuevoAreaOperativa

#Region "Atributos"
    Dim listaOr As New List(Of organizacion)
    Dim UnidadOrganicaBE As organizacion
    Dim ListaUnidadOrganica As New List(Of organizacion)
    Private node As TreeNodeAdv = Nothing
    Public nodePadre = New TreeNode
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)

#End Region

#Region "Constructor"

    Sub New(IDCargo As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GETORGANIZACION()
        CrearNodosDelPadre(1)
        VerDetalleVenta(IDCargo)
    End Sub

#End Region

#Region "Metodos"

    Public Sub GETORGANIZACION()
        Dim ORGSA As New OrganizacionSA
        listaOr = ORGSA.GetObtenerOrganizacion(Gempresas.IdEmpresaRuc)
    End Sub


    Private Sub GetListaDatosGenerales(idPerfilAnexo As Integer)
        Try

            Dim objNumeracionBoletaSA As New NumeracionBoletaSA
            Dim objNumeracionBoleta As New numeracionBoletas

            GridGroupingControl1.Table.Records.DeleteAll()

            Dim dt As New DataTable("Datos Generales")
            dt.Columns.Add(New DataColumn("ID", GetType(Integer)))
            dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
            dt.Columns.Add(New DataColumn("serie", GetType(String)))
            dt.Columns.Add(New DataColumn("agreagar"))
            dt.Columns.Add(New DataColumn("idPerfilAnexo"))


            objNumeracionBoleta.empresa = Gempresas.IdEmpresaRuc
            objNumeracionBoleta.establecimiento = GEstableciento.IdEstablecimiento


            For Each i As numeracionBoletas In objNumeracionBoletaSA.GetListar_numeracionBoletasXCargo(New numeracionBoletas With {.empresa = Gempresas.IdEmpresaRuc, .establecimiento = GEstableciento.IdEstablecimiento, .idCargo = txtDescripcion.Tag}).ToList
                Dim dr As DataRow = dt.NewRow()

                dr(0) = (i.IdEnumeracion)
                dr(1) = i.descripcionModulo
                dr(2) = i.serie

                Select Case i.estadoNumeracion
                    Case True
                        dr(3) = True
                    Case False
                        dr(3) = False
                End Select
                dr(4) = idPerfilAnexo

                dt.Rows.Add(dr)
            Next
            setDatasource(dt)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub setDatasource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            Dim deleg As New SetDataSourceDelegate(AddressOf setDatasource)
            Invoke(deleg, New Object() {table})
        Else
            GridGroupingControl1.DataSource = table
        End If
    End Sub

    Public Sub CrearNodosDelPadre(TIPO As Integer)
        Try



            'Dim infraestructuraSA As New infraestructuraSA
            'Dim infraestructuraBE As New infraestructura

            'If (TIPO = 1) Then
            '    infraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
            '    infraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento
            '    listaInfraestructura = infraestructuraSA.getListaInfraestructuraFull(infraestructuraBE)
            'End If

            Dim contqao As Integer = 0
            Dim contarHijos As Integer = 0
            Dim nietsosA As Integer = 0
            Dim nietoB As Integer = 0
            Dim nietoC As Integer = 0
            Dim nietoD As Integer = 0
            Dim nietoE As Integer = 0
            Dim nietoF As Integer = 0
            Dim nietoG As Integer = 0
            Dim nietoH As Integer = 0

            Dim contarEncabezado As Integer = 0

            TrVOrganigrama.Nodes.Clear()

            Dim nodeEncabezado = New TreeNode

            'Descripción o texto del nodo
            nodeEncabezado.Text = GEstableciento.NombreEstablecimiento
            nodeEncabezado.ForeColor = Color.Red
            'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
            nodeEncabezado.Name = 0

            'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
            nodeEncabezado.Tag = 0
            TrVOrganigrama.Nodes.Add(nodeEncabezado)

            'Dim consultaPadre = (From a In listaOr Where a.idPadre = 0
            '                     Order By a.idOrganigrama Ascending Select a).ToList

            Dim consultaPadre = (From a In listaOr Where a.idPadre = 0 And a.TipoOrganizacion = "ORG" Order By a.idOrganigrama Ascending Select a).ToList

            For Each PADRE In consultaPadre
                nodePadre = New TreeNode

                'Descripción o texto del nodo
                nodePadre.Text = PADRE.descripcion

                'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
                nodePadre.Name = PADRE.idOrganigrama

                'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
                nodePadre.Tag = PADRE.idOrganigrama
                TrVOrganigrama.Nodes(contarEncabezado).Nodes.Add(nodePadre)

                Dim consulta = (From a In listaOr Where a.idPadre = nodePadre.Tag And a.TipoOrganizacion = "ORG"
                                Order By a.idOrganigrama Ascending Select a).ToList

                If ((consulta.Count) > 0) Then
                    For Each hijos In consulta

                        Dim nodeHIJO = New TreeNode

                        'Descripción o texto del nodo
                        nodeHIJO.Text = hijos.descripcion
                        nodeHIJO.ForeColor = Color.FromArgb(32, 182, 82)
                        'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
                        nodeHIJO.Name = hijos.idOrganigrama

                        'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
                        nodeHIJO.Tag = hijos.idOrganigrama
                        TrVOrganigrama.Nodes(contarEncabezado).Nodes(contqao).Nodes.Add(nodeHIJO)

                        Dim consultANietos = (From a In listaOr Where a.idPadre = nodeHIJO.Tag And a.TipoOrganizacion = "ORG"
                                              Order By a.idOrganigrama Ascending Select a).ToList

                        For Each NIETOS In consultANietos
                            Dim nodeNieto = New TreeNode

                            'Descripción o texto del nodo
                            nodeNieto.Text = NIETOS.descripcion

                            'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
                            nodeNieto.Name = NIETOS.idOrganigrama

                            'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
                            nodeNieto.Tag = NIETOS.idOrganigrama
                            TrVOrganigrama.Nodes(contarEncabezado).Nodes(contqao).Nodes(contarHijos).Nodes.Add(nodeNieto)


                            Dim consultanietosA = (From m In listaOr Where m.idPadre = nodeNieto.Tag And m.TipoOrganizacion = "ORG"
                                                   Order By m.idOrganigrama Ascending Select m).ToList

                            For Each nietosA In consultanietosA

                                Dim nodeNietosA = New TreeNode

                                nodeNietosA.Text = nietosA.descripcion
                                nodeNietosA.ForeColor = Color.FromArgb(7, 117, 129)
                                nodeNietosA.Name = nietosA.idOrganigrama

                                nodeNietosA.Tag = nietosA.idOrganigrama
                                TrVOrganigrama.Nodes(contarEncabezado).Nodes(contqao).Nodes(contarHijos).Nodes(nietsosA).Nodes.Add(nodeNietosA)

                                Dim consultaNietoB = (From p In listaOr Where p.idPadre = nodeNietosA.Tag And p.TipoOrganizacion = "ORG"
                                                      Order By p.idOrganigrama Ascending Select p).ToList

                                For Each nietosB In consultaNietoB
                                    Dim nodoNietoB = New TreeNode

                                    nodoNietoB.Text = nietosB.descripcion

                                    nodoNietoB.Name = nietosB.idOrganigrama

                                    nodoNietoB.Tag = nietosB.idOrganigrama

                                    TrVOrganigrama.Nodes(contarEncabezado).Nodes(contqao).Nodes(contarHijos).Nodes(nietsosA).Nodes(nietoB).Nodes.Add(nodoNietoB)

                                    '******************************** NODO NRO "5" ****************************************
                                    Dim consultanietosC = (From m In listaOr Where m.idPadre = nodoNietoB.Tag And m.TipoOrganizacion = "ORG"
                                                           Order By m.idOrganigrama Ascending Select m).ToList

                                    For Each nietosC In consultanietosC
                                        Dim nodeNietosC = New TreeNode

                                        nodeNietosC.Text = nietosC.descripcion
                                        nodeNietosC.ForeColor = Color.FromArgb(7, 117, 129)
                                        nodeNietosC.Name = nietosC.idOrganigrama

                                        nodeNietosC.Tag = nietosC.idOrganigrama
                                        TrVOrganigrama.Nodes(contarEncabezado).Nodes(contqao).Nodes(contarHijos).Nodes(nietsosA).Nodes(nietoB).Nodes(nietoC).Nodes.Add(nodeNietosC)

                                        '******************************** NODO NRO "6" ****************************************
                                        Dim consultanietosD = (From m In listaOr Where m.idPadre = nodeNietosC.Tag And m.TipoOrganizacion = "ORG"
                                                               Order By m.idOrganigrama Ascending Select m).ToList

                                        For Each nietosD In consultanietosD
                                            Dim nodeNietosD = New TreeNode

                                            nodeNietosD.Text = nietosD.descripcion
                                            nodeNietosD.ForeColor = Color.FromArgb(7, 117, 129)
                                            nodeNietosD.Name = nietosD.idOrganigrama

                                            nodeNietosD.Tag = nietosD.idOrganigrama
                                            TrVOrganigrama.Nodes(contarEncabezado).Nodes(contqao).Nodes(contarHijos).Nodes(nietsosA).Nodes(nietoB).Nodes(nietoC).Nodes(nietoD).Nodes.Add(nodeNietosD)


                                            '******************************** NODO NRO "7" ****************************************
                                            Dim consultanietosE = (From m In listaOr Where m.idPadre = nodeNietosD.Tag And m.TipoOrganizacion = "ORG"
                                                                   Order By m.idOrganigrama Ascending Select m).ToList

                                            For Each nietosE In consultanietosE
                                                Dim nodeNietosE = New TreeNode

                                                nodeNietosE.Text = nietosE.descripcion
                                                nodeNietosE.ForeColor = Color.FromArgb(7, 117, 129)
                                                nodeNietosE.Name = nietosE.idOrganigrama

                                                nodeNietosE.Tag = nietosE.idOrganigrama
                                                TrVOrganigrama.Nodes(contarEncabezado).Nodes(contqao).Nodes(contarHijos).Nodes(nietsosA).Nodes(nietoB).Nodes(nietoC).Nodes(nietoD).Nodes(nietoE).Nodes.Add(nodeNietosE)


                                                '******************************** NODO NRO "8" ****************************************
                                                Dim consultanietosF = (From m In listaOr Where m.idPadre = nodeNietosE.Tag And m.TipoOrganizacion = "ORG"
                                                                       Order By m.idOrganigrama Ascending Select m).ToList

                                                For Each nietosF In consultanietosF
                                                    Dim nodeNietosF = New TreeNode

                                                    nodeNietosF.Text = nietosF.descripcion
                                                    nodeNietosF.ForeColor = Color.FromArgb(7, 117, 129)
                                                    nodeNietosF.Name = nietosF.idOrganigrama

                                                    nodeNietosF.Tag = nietosF.idOrganigrama
                                                    TrVOrganigrama.Nodes(contarEncabezado).Nodes(contqao).Nodes(contarHijos).Nodes(nietsosA).Nodes(nietoB).Nodes(nietoC).Nodes(nietoD).Nodes(nietoE).Nodes(nietoF).Nodes.Add(nodeNietosF)


                                                    '******************************** NODO NRO "9" ****************************************
                                                    Dim consultanietosG = (From m In listaOr Where m.idPadre = nodeNietosF.Tag And m.TipoOrganizacion = "ORG"
                                                                           Order By m.idOrganigrama Ascending Select m).ToList

                                                    For Each nietosG In consultanietosG
                                                        Dim nodeNietosG = New TreeNode

                                                        nodeNietosG.Text = nietosG.descripcion
                                                        nodeNietosG.ForeColor = Color.FromArgb(7, 117, 129)
                                                        nodeNietosG.Name = nietosG.idOrganigrama

                                                        nodeNietosG.Tag = nietosG.idOrganigrama
                                                        TrVOrganigrama.Nodes(contarEncabezado).Nodes(contqao).Nodes(contarHijos).Nodes(nietsosA).Nodes(nietoB).Nodes(nietoC).Nodes(nietoD).Nodes(nietoE).Nodes(nietoF).Nodes(nietoG).Nodes.Add(nodeNietosG)

                                                        '******************************** NODO NRO "10" ****************************************
                                                        Dim consultanietosH = (From m In listaOr Where m.idPadre = nodeNietosG.Tag And m.TipoOrganizacion = "ORG"
                                                                               Order By m.idOrganigrama Ascending Select m).ToList

                                                        For Each nietosH In consultanietosH
                                                            Dim nodeNietosH = New TreeNode

                                                            nodeNietosH.Text = nietosH.descripcion
                                                            nodeNietosH.ForeColor = Color.FromArgb(7, 117, 129)
                                                            nodeNietosH.Name = nietosH.idOrganigrama

                                                            nodeNietosH.Tag = nietosH.idOrganigrama
                                                            TrVOrganigrama.Nodes(contarEncabezado).Nodes(contqao).Nodes(contarHijos).Nodes(nietsosA).Nodes(nietoB).Nodes(nietoC).Nodes(nietoD).Nodes(nietoE).Nodes(nietoF).Nodes(nietoG).Nodes(nietoH).Nodes.Add(nodeNietosH)

                                                        Next
                                                        nietoH += 1

                                                    Next
                                                    nietoG += 1
                                                    nietoH = 0

                                                Next
                                                nietoF += 1
                                                nietoG = 0
                                            Next
                                            nietoE += 1
                                            nietoF = 0
                                        Next
                                        nietoD += 1
                                        nietoE = 0
                                    Next
                                    nietoC += 1
                                    nietoD = 0
                                    '****************
                                Next
                                nietoB += 1
                                nietoC = 0
                            Next
                            nietoB = 0
                            If (consulta.Count > 1) Then
                                nietsosA += 1
                            Else
                                nietsosA = 0
                            End If
                        Next
                        nietsosA = 0
                        If (consulta.Count > 1) Then
                            contarHijos += 1
                        Else
                            contarHijos = 0
                        End If
                    Next
                    contarHijos = 0
                End If
                'contarHijos += 1
                contqao += 1
            Next
            TrVOrganigrama.EndUpdate()
            TrVOrganigrama.ExpandAll()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub VerDetalleVenta(IdCArgo As Integer)
        Try
            Dim perfilAnexoSA As New OrganizacionSA

            Dim dt As New DataTable
            dt.Columns.Add("ID")
            dt.Columns.Add("DESCRIPCION")
            dt.Columns.Add("IDPerfilAnexo")

            dgvCompras.Table.Records.DeleteAll()

            For Each i In perfilAnexoSA.GetObtenerOrganigramaXPerfil(New organizacion With {.tipo = IdCArgo})
                dt.Rows.Add(i.idOrganigrama,
                      i.descripcion,
                        i.tipo)
            Next

            dgvCompras.DataSource = dt
            dgvCompras.Refresh()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grabar(Id As Integer)
        Try
            Dim perfilAnexoSA As New perfilAnexoSA
            Dim perfilAnexoBE As perfilAnexo
            Dim listPerfilAnexo As New List(Of perfilAnexo)

            perfilAnexoBE = New perfilAnexo
            perfilAnexoBE.idCargo = CInt(txtDescripcion.Tag)
            perfilAnexoBE.idCentroCosto = CInt(Id)
            perfilAnexoBE.descripcion = txtDescripcion.Text
            perfilAnexoBE.tipo = txtDescripcion.Tag
            perfilAnexoBE.estado = "A"
            perfilAnexoBE.usuarioActualizacion = "ADMIN"
            perfilAnexoBE.fechaActualizacion = Date.Now

            listPerfilAnexo.Add(perfilAnexoBE)

            perfilAnexoSA.SavePerfilAnexo(listPerfilAnexo)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TrVOrganigrama_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TrVOrganigrama.AfterSelect
        Try

            'Select Case e.Action
            '    Case TreeViewAction.ByKeyboard
            '        MessageBox.Show("You like the keyboard!")
            '    Case TreeViewAction.ByMouse
            '        MessageBox.Show("You like the mouse!")
            'End Select

            Dim TEXTOsELECCION = TrVOrganigrama.SelectedNode.Text
            Dim TempNodeText As String = TEXTOsELECCION

            If TempNodeText.Trim <> "" Then

                'Dim entNuevo = CType(TrVOrganigrama.SelectedNode.Tag, organizacion)


                If (IsNothing(ListaUnidadOrganica.Where(Function(o) o.idOrganigrama = TrVOrganigrama.SelectedNode.Tag).FirstOrDefault)) Then

                    UnidadOrganicaBE = New organizacion
                    UnidadOrganicaBE.idOrganigrama = TrVOrganigrama.SelectedNode.Tag
                    UnidadOrganicaBE.descripcion = TrVOrganigrama.SelectedNode.Text

                    grabar(TrVOrganigrama.SelectedNode.Tag)

                    'ListaUnidadOrganica.Add(UnidadOrganicaBE)
                    VerDetalleVenta(txtDescripcion.Tag)
                    pnOrganigrama.Visible = False

                Else
                    MessageBox.Show("Existe la unidad órganica")
                End If


            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TrVOrganigrama_DrawNode(sender As Object, e As DrawTreeNodeEventArgs) Handles TrVOrganigrama.DrawNode
        'e.Node.Tag = TrVOrganigrama.SelectedNode.Text
        Dim ID = TrVOrganigrama.SelectedNode.Text
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        Try
            Dim perfilAnexoSA As New perfilAnexoSA
            Dim perfilAnexoBE As perfilAnexo
            Dim listPerfilAnexo As New List(Of perfilAnexo)


            If (dgvCompras.Table.Records.Count > 0) Then
                For Each item In dgvCompras.Table.Records
                    perfilAnexoBE = New perfilAnexo
                    perfilAnexoBE.idCentroCosto = CInt(item.GetValue("ID"))
                    perfilAnexoBE.descripcion = txtDescripcion.Text
                    perfilAnexoBE.tipo = txtDescripcion.Tag
                    perfilAnexoBE.estado = "A"
                    perfilAnexoBE.usuarioActualizacion = "ADMIN"
                    perfilAnexoBE.fechaActualizacion = Date.Now

                    listPerfilAnexo.Add(perfilAnexoBE)
                Next

                perfilAnexoSA.SavePerfilAnexo(listPerfilAnexo)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Close()
    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        pnOrganigrama.Visible = False
    End Sub

    Private Sub BunifuFlatButton6_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton6.Click
        pnOrganigrama.Visible = True
    End Sub

    Private Sub GridGroupingControl1_TableControlCheckBoxClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles GridGroupingControl1.TableControlCheckBoxClick
        Try

            Me.Cursor = Cursors.WaitCursor
            Dim obj As New documentocompra
            Dim RowIndex As Integer = e.Inner.RowIndex
            Dim cc As GridCurrentCell = GridGroupingControl1.TableControl.CurrentCell
            cc.ConfirmChanges()

            If RowIndex > -1 Then
                e.TableControl.CurrentCell.EndEdit()
                e.TableControl.Table.TableDirty = True
                e.TableControl.Table.EndEdit()

                Dim style3 As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
                If style3.Enabled Then
                    If style3.TableCellIdentity.Column.Name = "agreagar" Then

                        Dim sty As GridTableCellStyleInfo = e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex)

                        If sty.TableCellIdentity.DisplayElement.Kind = DisplayElementKind.Record Then
                            Dim record = sty.TableCellIdentity.DisplayElement.GetRecord()

                            Dim valCheck = record.GetValue("agreagar") 'Me.GridCompra.TableModel(RowIndex, 15).CellValue
                            Select Case valCheck
                                Case "False" 'TRUE
                                    Dim numeracionAOSA As New distribucionNumeracionAOSA
                                    Dim idCargo = (record.GetValue("idPerfilAnexo"))
                                    Dim idNumeracion = (record.GetValue("ID"))
                                    Dim estado = "A"

                                    numeracionAOSA.InsertAreaOperativaNumeracion(New distribucionNumeracionAO With {.IdEnumeracion = idNumeracion, .idCargo = idCargo, .estado = estado, .idRol = txtDescripcion.Tag})

                                Case Else ' FALSE
                                    Dim numeracionAOSA As New distribucionNumeracionAOSA
                                    Dim idCargo = (record.GetValue("idPerfilAnexo"))
                                    Dim idNumeracion = (record.GetValue("ID"))
                                    Dim estado = "I"

                                    numeracionAOSA.InsertAreaOperativaNumeracion(New distribucionNumeracionAO With {.IdEnumeracion = idNumeracion, .idCargo = idCargo, .estado = estado})

                            End Select

                        End If

                    End If
                End If
            End If
            Me.Cursor = Cursors.Arrow

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgvCompras_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompras.TableControlCellClick
        Try
            If (Not IsNothing(dgvCompras.Table.CurrentRecord)) Then
                GetListaDatosGenerales(dgvCompras.Table.CurrentRecord.GetValue("IDPerfilAnexo"))
            Else
                Throw New Exception("Verificar")
            End If



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region


End Class