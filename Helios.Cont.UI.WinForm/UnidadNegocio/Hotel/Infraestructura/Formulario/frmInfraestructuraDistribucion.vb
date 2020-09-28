Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Microsoft
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Tools
Imports Syncfusion.Drawing
Imports Helios.Cont.Business.Entity.Helios.Cont.Business.Entity

Public Class frmInfraestructuraDistribucion
    Inherits frmMaster

    Public Property EstadoManipulacion() As String
    Public Property listaInfraestructura As New List(Of infraestructura)
    Public Property UnidadNegocioID As Integer
    Dim codigo As Integer = 0
    Public Alert As Alert
    Dim numeracion As Integer
    Private node As TreeNodeAdv = Nothing
    Public nodePadre = New TreeNode

    Dim listaDistribucion As New List(Of distribucionInfraestructura)


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'FormatoGridPequeño(dgvDetalleArea, False, 11.0F)
        'FormatoGridPequeño(dgAtendido, False, 11.0F)
        'CargarCombos()
        FormatoGridAvanzado(dgvInfraestructura, True, False)
        FormatoGridAvanzado(dgvComponente, False, False)

        GetTableGrid()
        CargarCombos()
        GetListaInfraestructura()

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

            cboTipoComposicion.DataSource = Nothing

            If (Not IsNothing(listaComponente)) Then
                cboTipoComposicion.ValueMember = "idComponente"
                cboTipoComposicion.DisplayMember = "descripcionItem"
                cboTipoComposicion.DataSource = listaComponente
                cboTipoComposicion.SelectedValue = listaComponente(0).idComponente

                GetListaComponenteXID(cboTipoComposicion.SelectedValue)

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub GetTableGrid()
        Dim dt As New DataTable()

        dt.Columns.Add("bloque", GetType(String))
        dt.Columns.Add("sector", GetType(String))
        dt.Columns.Add("idPiso", GetType(Integer))
        dt.Columns.Add("piso", GetType(String))

        dgvInfraestructura.DataSource = dt

        Dim dtComponente As New DataTable()

        dtComponente.Columns.Add("numero", GetType(Integer))
        dtComponente.Columns.Add("idItem", GetType(Integer))
        dtComponente.Columns.Add("tipo", GetType(String))
        dtComponente.Columns.Add("descripcion", GetType(String))
        dtComponente.Columns.Add("estado", GetType(String))
        dtComponente.Columns.Add("seleccion")
        dtComponente.Columns.Add("idPadre", GetType(String))

        dgvComponente.DataSource = dtComponente

    End Sub

    Private Sub GetListaInfraestructura()
        Dim infraestructuraSA As New infraestructuraSA
        Dim infraestructuraBE As New infraestructura
        Dim listaInfraestructura As New List(Of infraestructura)

        'infraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
        'infraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento
        'infraestructuraBE.tipo = "TD"

        listaInfraestructura = infraestructuraSA.getInfraestructuraEstructura(New infraestructura With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento}).ToList

        Dim dt As New DataTable()
        Try
            dt.Columns.Add("bloque", GetType(String))
            dt.Columns.Add("sector", GetType(String))
            dt.Columns.Add("idPiso", GetType(Integer))
            dt.Columns.Add("piso", GetType(String))

            For Each i As infraestructura In listaInfraestructura
                Dim dr As DataRow = dt.NewRow()
                dr(0) = i.Bloque
                dr(1) = i.Sector
                dr(2) = i.idInfraestructura
                dr(3) = i.Piso

                dt.Rows.Add(dr)
            Next

            dgvInfraestructura.DataSource = dt
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub GetListaComponenteXID(ID As Integer)
        Try
            Dim componenteBE As New componente
            Dim componenteSA As New componenteSA
            Dim listaComponente As New List(Of componente)


            componenteBE.idEmpresa = Gempresas.IdEmpresaRuc
            componenteBE.idEstablecimiento = GEstableciento.IdEstablecimiento
            componenteBE.tipo = "TD"
            componenteBE.idPadre = ID
            componenteBE.estado = "A"

            listaComponente = componenteSA.getListaComponenteXIdPadre(componenteBE)

            Dim dt As New DataTable()

            dt.Columns.Add("numero", GetType(Integer))
            dt.Columns.Add("idItem", GetType(Integer))
            dt.Columns.Add("tipo", GetType(String))
            dt.Columns.Add("descripcion", GetType(String))
            dt.Columns.Add("estado", GetType(String))
            dt.Columns.Add("seleccion")
            dt.Columns.Add("idPadre", GetType(String))

            For Each i As componente In listaComponente
                Dim dr As DataRow = dt.NewRow()
                dr(0) = i.idComponente
                dr(1) = i.idItem
                dr(2) = i.tipo
                dr(3) = i.descripcionItem
                dr(4) = i.estado
                dr(5) = False
                dr(6) = i.idPadre
                dt.Rows.Add(dr)
            Next

            dgvComponente.DataSource = dt
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try
    End Sub

    Sub FormatoGridAvanzado(GGC As GridGroupingControl, FullRowSelect As Boolean, AllowProportionalColumnSizing As Boolean)
        Dim colorx As New GridMetroColors()
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = BorderStyle.None
        '  GGC.BrowseOnly = True
        If FullRowSelect = True Then
            GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
            GGC.TableOptions.ListBoxSelectionCurrentCellOptions = GridListBoxSelectionCurrentCellOptions.HideCurrentCell
            GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
            GGC.TableOptions.SelectionBackColor = Color.Gray
        End If
        GGC.AllowProportionalColumnSizing = AllowProportionalColumnSizing
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        GGC.Table.DefaultColumnHeaderRowHeight = 27
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Private Sub GrabarDistribucion(r As Record, listaComponente As List(Of componente))
        Dim distribucionInfraestructuraBE As New distribucionInfraestructura
        Dim distribucionInfraestructuraSA As New distribucionInfraestructuraSA
        Dim listaDistribucion As New List(Of distribucionInfraestructura)
        Dim distribucionBE As New distribucionInfraestructura

        distribucionBE.idComponente = listaComponente(0).tipo

        For Each item In listaComponente
            distribucionInfraestructuraBE = New distribucionInfraestructura

            distribucionInfraestructuraBE.[idEmpresa] = Gempresas.IdEmpresaRuc
            distribucionInfraestructuraBE.[idEstablecimiento] = GEstableciento.IdEstablecimiento
            distribucionInfraestructuraBE.[idComponente] = item.idComponente
            distribucionInfraestructuraBE.[idInfraestructura] = r.GetValue("idPiso")
            distribucionInfraestructuraBE.[descripcionDistribucion] = item.descripcionItem
            distribucionInfraestructuraBE.[glosario] = r.GetValue("bloque") & "/" & r.GetValue("sector") & "/" & r.GetValue("piso") & "/" & item.descripcionItem
            distribucionInfraestructuraBE.[estado] = "A"
            distribucionInfraestructuraBE.[tipo] = CStr(item.tipo)
            distribucionInfraestructuraBE.[usuarioActualizacion] = "MAYKOL"
            distribucionInfraestructuraBE.[fechaActualizacion] = DateTime.Now
            listaDistribucion.Add(distribucionInfraestructuraBE)

        Next

        distribucionInfraestructuraSA.SaveDistribucionInfraestructuraFull(distribucionBE, listaDistribucion)

    End Sub

    Private Sub EliminarDistribucion()
        Dim distribucionBE As New distribucionInfraestructura
        Dim distribucionSA As New distribucionInfraestructuraSA

        distribucionBE.idEmpresa = Gempresas.IdEmpresaRuc
        distribucionBE.idEstablecimiento = GEstableciento.IdEstablecimiento

        distribucionSA.EliminarDistribucionFull(distribucionBE)
        CargarCombos()
        GetListaInfraestructura()
        tvListaModulos.Nodes.Clear()
        MessageBoxAdv.Show("Se elimino exitosamente la distribución!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub CrearNodosDelPadre()
        Try

            Dim distribucionInfraestructuraSA As New distribucionInfraestructuraSA
            Dim distribucionInfraestructuraBE As New distribucionInfraestructura
            Dim infraestructuraSA As New infraestructuraSA
            Dim infraestructuraBE As New infraestructura
            Dim contqao As Integer = 0
            Dim contarHijos As Integer = 0
            Dim contarEncabezado As Integer = 0
            Dim contarComponente As Integer = 0

            distribucionInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
            distribucionInfraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento
            distribucionInfraestructuraBE.estado = "A"

            infraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
            infraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento

            listaInfraestructura = infraestructuraSA.getListaInfraestructuraFull(infraestructuraBE)
            listaDistribucion = distribucionInfraestructuraSA.getDistribucionInfraestructura(distribucionInfraestructuraBE)
            tvListaModulos.Nodes.Clear()

            Dim nodeEncabezado = New TreeNode

            'Descripción o texto del nodo
            nodeEncabezado.Text = "EMPRESA PRUEBAS SAC" & "/" & "UNIDAD DE NEGOCIO"

            'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
            nodeEncabezado.Name = 0

            'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
            nodeEncabezado.Tag = 0
            tvListaModulos.Nodes.Add(nodeEncabezado)

            Dim consultaPadre = (From a In listaInfraestructura Where a.idPadre = 0
                                 Order By a.idInfraestructura Ascending Select a).ToList

            For Each PADRE In consultaPadre
                nodePadre = New TreeNode

                'Descripción o texto del nodo
                nodePadre.Text = PADRE.nombre

                'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
                nodePadre.Name = PADRE.idInfraestructura

                'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
                nodePadre.Tag = PADRE.idInfraestructura
                tvListaModulos.Nodes(contarEncabezado).Nodes.Add(nodePadre)

                Dim consulta = (From a In listaInfraestructura Where a.idPadre = nodePadre.Tag
                                Order By a.idInfraestructura Ascending Select a).ToList

                If ((consulta.Count) > 0) Then
                    For Each hijos In consulta

                        Dim nodeHIJO = New TreeNode

                        'Descripción o texto del nodo
                        nodeHIJO.Text = hijos.nombre

                        'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
                        nodeHIJO.Name = hijos.idInfraestructura

                        'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
                        nodeHIJO.Tag = hijos.idInfraestructura
                        tvListaModulos.Nodes(contarEncabezado).Nodes(contqao).Nodes.Add(nodeHIJO)

                        Dim consultANietos = (From a In listaInfraestructura Where a.idPadre = nodeHIJO.Tag
                                              Order By a.idInfraestructura Ascending Select a).ToList

                        For Each NIETOS In consultANietos
                            Dim nodeNieto = New TreeNode

                            'Descripción o texto del nodo
                            nodeNieto.Text = NIETOS.nombre

                            'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
                            nodeNieto.Name = NIETOS.idInfraestructura

                            'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
                            nodeNieto.Tag = NIETOS.idInfraestructura
                            tvListaModulos.Nodes(contarEncabezado).Nodes(contqao).Nodes(contarHijos).Nodes.Add(nodeNieto)

                            Dim consultaComponente = (From a In listaDistribucion Where a.idInfraestructura = nodeNieto.Tag
                                                      Order By a.idDistribucion Ascending Select a).ToList

                            For Each componente In consultaComponente
                                Dim nodeComponente = New TreeNode

                                'Descripción o texto del nodo
                                nodeComponente.Text = componente.descripcionDistribucion & "  N° " & componente.numeracion

                                'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
                                nodeComponente.Name = componente.idDistribucion

                                'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
                                nodeComponente.Tag = componente.idDistribucion
                                tvListaModulos.Nodes(contarEncabezado).Nodes(contqao).Nodes(contarHijos).Nodes(contarComponente).Nodes.Add(nodeComponente)

                            Next
                            If (consultANietos.Count > 1) Then
                                contarComponente += 1
                            Else
                                contarComponente = 0
                            End If

                        Next
                        If (consulta.Count > 1) Then
                            contarHijos += 1
                        Else
                            contarHijos = 0
                        End If
                        contarComponente = 0
                    Next

                    contarHijos = 0
                End If
                'contarHijos += 1
                contqao += 1
            Next
            tvListaModulos.EndUpdate()
            tvListaModulos.ExpandAll()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub cboTipoComposicion_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboTipoComposicion.SelectionChangeCommitted
        GetListaComponenteXID(cboTipoComposicion.SelectedValue)
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles chSeleccion.CheckedChanged
        If (chSeleccion.Checked = True) Then
            chSeleccion.Checked = True

            For Each item In dgvComponente.Table.Records
                item.SetValue("seleccion", True)
            Next

        Else
            chSeleccion.Checked = False
            For Each item In dgvComponente.Table.Records
                item.SetValue("seleccion", False)
            Next
        End If
    End Sub

    Private Sub dgvInfraestructura_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvInfraestructura.TableControlCellClick
        CrearNodosDelPadre()
    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        Dim componenteBE As New componente
        Dim listaComponente As New List(Of componente)
        Dim ConteoCheck As Integer = 0
        Try

            For Each ITEM In dgvComponente.Table.Records
                ConteoCheck += 1
            Next

            If (ConteoCheck > 0) Then
                If (Not IsNothing(dgvInfraestructura.Table.CurrentRecord)) Then
                    If MessageBox.Show("Desea realizar la distribución?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                        For Each ITEM In dgvComponente.Table.Records
                            If (ITEM.GetValue("seleccion") = True) Then
                                componenteBE = New componente
                                componenteBE.descripcionItem = ITEM.GetValue("descripcion")
                                componenteBE.idComponente = ITEM.GetValue("numero")
                                componenteBE.estado = ITEM.GetValue("estado")
                                componenteBE.tipo = ITEM.GetValue("idPadre")

                                listaComponente.Add(componenteBE)

                                ITEM.Delete()
                            End If
                        Next

                        GrabarDistribucion(dgvInfraestructura.Table.CurrentRecord, listaComponente)
                        CrearNodosDelPadre()
                    End If
                Else

                    MessageBox.Show("Debe seleccionar una infraestructura")
                End If
            Else
                MessageBox.Show("Debe seleccionar un componente")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs)
        Dispose()
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        If MessageBox.Show("Desea Eliminar toda la distribución?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            EliminarDistribucion()
        End If
    End Sub
End Class