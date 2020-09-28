Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports Microsoft.VisualBasic.FileIO
Imports System.Net
Imports Syncfusion.Windows.Forms.Diagram
Imports System.Drawing.Drawing2D
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess

Public Class UCOrganigrama
    Dim hierarchicalLayout As New HierarchicLayoutManager
    Dim listaCentrocosto As New List(Of centrocosto)
    Dim centrocostoBE As New centrocosto

    Dim LISTANUEVA As New List(Of jerarquia)
    Dim OBJ As New jerarquia

    Private node As TreeNodeAdv = Nothing
    Public nodePadre = New TreeNode

    Dim PERFILESxUnigOrg As New List(Of perfilAnexo)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

    End Sub


    Private Sub BunifuFlatButton5_Click_1(sender As Object, e As EventArgs)
        Dim M As New FormJerarquia
        M.StartPosition = FormStartPosition.CenterParent
        M.ShowDialog()

        'RELOADORGANIGRAMA()
        'cbNivelesOrg.SelectedValue = -1
    End Sub

    Private Sub NuevoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoToolStripMenuItem.Click
        Try

            Dim entNuevo As New centrocosto
            Dim frm As New FormNuevoRubro
            frm.ListarCargosPadre()
            frm.StartPosition = FormStartPosition.CenterParent
            frm.ShowDialog(Me)
            Dim TempNodeText As String = frm.TextBox1.Text

            If frm.Tag IsNot Nothing Then
                Dim ent = CType(frm.Tag, centrocosto)

                If TempNodeText.Trim <> "" Then
                    Dim _Node As New TreeNode
                    _Node.Text = TempNodeText
                    _Node.ContextMenuStrip = cmAdministrar
                    'trOrganigrama.SelectedNode.Nodes.Add(_Node)

                    If (TrVOrganigrama.SelectedNode.Text = Gempresas.IdEmpresaRuc) Then
                        centrocostoBE = New centrocosto
                        centrocostoBE.nivel = 0
                        entNuevo.nivel = 0
                    Else
                        entNuevo = CType(TrVOrganigrama.SelectedNode.Tag, centrocosto)
                    End If

                    Select Case entNuevo.nivel
                        Case 0
                            centrocostoBE = New centrocosto
                            centrocostoBE.idEmpresa = Gempresas.IdEmpresaRuc
                            centrocostoBE.idCentroCosto = listaCentrocosto.Count + 1
                            centrocostoBE.idpadre = 0
                            centrocostoBE.nombre = TempNodeText
                            centrocostoBE.TipoEstab = ent.TipoEstab
                            centrocostoBE.nivel = 1
                            centrocostoBE.estado = "A"
                            centrocostoBE.tipoOrganizacion = "ORG"
                            centrocostoBE.[usuarioActualizacion] = "Administrador"
                            centrocostoBE.[fechaActualizacion] = Date.Now
                            centrocostoBE.IDNegocioComercial = ent.IDNegocioComercial
                            centrocostoBE.tipo = ent.tipo
                            centrocostoBE.ubigeo = ent.ubigeo
                            centrocostoBE.inicioOperaciones = ent.inicioOperaciones
                            listaCentrocosto.Add(centrocostoBE)

                            guargarUnidadOrganica(centrocostoBE)
                            CrearNodosDelPadre(0)
                        Case 1
                            centrocostoBE = New centrocosto
                            centrocostoBE.idEmpresa = Gempresas.IdEmpresaRuc
                            centrocostoBE.idCentroCosto = listaCentrocosto.Count + 1
                            centrocostoBE.idpadre = entNuevo.idCentroCosto
                            centrocostoBE.nombre = TempNodeText
                            centrocostoBE.TipoEstab = ent.TipoEstab
                            centrocostoBE.nivel = 2
                            centrocostoBE.estado = "A"
                            centrocostoBE.tipoOrganizacion = "ORG"
                            centrocostoBE.[usuarioActualizacion] = "Administrador"
                            centrocostoBE.IDNegocioComercial = ent.IDNegocioComercial
                            centrocostoBE.tipo = ent.tipo
                            centrocostoBE.ubigeo = ent.ubigeo
                            centrocostoBE.inicioOperaciones = ent.inicioOperaciones
                            centrocostoBE.[fechaActualizacion] = Date.Now

                            listaCentrocosto.Add(centrocostoBE)
                            guargarUnidadOrganica(centrocostoBE)
                            CrearNodosDelPadre(0)
                        Case 2
                            centrocostoBE = New centrocosto
                            centrocostoBE.idEmpresa = Gempresas.IdEmpresaRuc
                            centrocostoBE.idCentroCosto = listaCentrocosto.Count + 1
                            centrocostoBE.idpadre = entNuevo.idCentroCosto
                            centrocostoBE.nombre = TempNodeText
                            centrocostoBE.TipoEstab = ent.TipoEstab
                            centrocostoBE.nivel = 3
                            centrocostoBE.estado = "A"
                            centrocostoBE.tipoOrganizacion = "ORG"
                            centrocostoBE.[usuarioActualizacion] = "Administrador"
                            centrocostoBE.[fechaActualizacion] = Date.Now
                            centrocostoBE.IDNegocioComercial = ent.IDNegocioComercial
                            centrocostoBE.tipo = ent.tipo
                            centrocostoBE.ubigeo = ent.ubigeo
                            centrocostoBE.inicioOperaciones = ent.inicioOperaciones
                            listaCentrocosto.Add(centrocostoBE)
                            guargarUnidadOrganica(centrocostoBE)
                            CrearNodosDelPadre(0)
                        Case 3
                            centrocostoBE = New centrocosto
                            centrocostoBE.idEmpresa = Gempresas.IdEmpresaRuc
                            centrocostoBE.idCentroCosto = listaCentrocosto.Count + 1
                            centrocostoBE.idpadre = entNuevo.idCentroCosto
                            centrocostoBE.nombre = TempNodeText
                            centrocostoBE.TipoEstab = ent.TipoEstab
                            centrocostoBE.nivel = 4
                            centrocostoBE.estado = "A"
                            centrocostoBE.tipoOrganizacion = "ORG"
                            centrocostoBE.[usuarioActualizacion] = "Administrador"
                            centrocostoBE.[fechaActualizacion] = Date.Now
                            centrocostoBE.IDNegocioComercial = ent.IDNegocioComercial
                            centrocostoBE.tipo = ent.tipo
                            centrocostoBE.ubigeo = ent.ubigeo
                            centrocostoBE.inicioOperaciones = ent.inicioOperaciones
                            listaCentrocosto.Add(centrocostoBE)
                            guargarUnidadOrganica(centrocostoBE)
                            CrearNodosDelPadre(0)
                        Case 4
                            centrocostoBE = New centrocosto
                            centrocostoBE.idEmpresa = Gempresas.IdEmpresaRuc
                            centrocostoBE.idCentroCosto = listaCentrocosto.Count + 1
                            centrocostoBE.idpadre = entNuevo.idCentroCosto
                            centrocostoBE.nombre = TempNodeText
                            centrocostoBE.TipoEstab = ent.TipoEstab
                            centrocostoBE.nivel = 5
                            centrocostoBE.estado = "A"
                            centrocostoBE.tipoOrganizacion = "ORG"
                            centrocostoBE.[usuarioActualizacion] = "Administrador"
                            centrocostoBE.[fechaActualizacion] = Date.Now
                            centrocostoBE.IDNegocioComercial = ent.IDNegocioComercial
                            centrocostoBE.tipo = ent.tipo
                            centrocostoBE.ubigeo = ent.ubigeo
                            centrocostoBE.inicioOperaciones = ent.inicioOperaciones
                            listaCentrocosto.Add(centrocostoBE)
                            guargarUnidadOrganica(centrocostoBE)
                            CrearNodosDelPadre(0)
                        Case 5
                            centrocostoBE = New centrocosto
                            centrocostoBE.idEmpresa = Gempresas.IdEmpresaRuc
                            centrocostoBE.idCentroCosto = listaCentrocosto.Count + 1
                            centrocostoBE.idpadre = entNuevo.idCentroCosto
                            centrocostoBE.nombre = TempNodeText
                            centrocostoBE.TipoEstab = ent.TipoEstab
                            centrocostoBE.nivel = 6
                            centrocostoBE.estado = "A"
                            centrocostoBE.tipoOrganizacion = "ORG"
                            centrocostoBE.[usuarioActualizacion] = "Administrador"
                            centrocostoBE.[fechaActualizacion] = Date.Now
                            centrocostoBE.IDNegocioComercial = ent.IDNegocioComercial
                            centrocostoBE.tipo = ent.tipo
                            centrocostoBE.ubigeo = ent.ubigeo
                            centrocostoBE.inicioOperaciones = ent.inicioOperaciones
                            listaCentrocosto.Add(centrocostoBE)
                            guargarUnidadOrganica(centrocostoBE)
                            CrearNodosDelPadre(0)
                        Case 6
                            centrocostoBE = New centrocosto
                            centrocostoBE.idEmpresa = Gempresas.IdEmpresaRuc
                            centrocostoBE.idCentroCosto = listaCentrocosto.Count + 1
                            centrocostoBE.idpadre = entNuevo.idCentroCosto
                            centrocostoBE.nombre = TempNodeText
                            centrocostoBE.TipoEstab = ent.TipoEstab
                            centrocostoBE.nivel = 7
                            centrocostoBE.estado = "A"
                            centrocostoBE.tipoOrganizacion = "ORG"
                            centrocostoBE.[usuarioActualizacion] = "Administrador"
                            centrocostoBE.[fechaActualizacion] = Date.Now
                            centrocostoBE.IDNegocioComercial = ent.IDNegocioComercial
                            centrocostoBE.tipo = ent.tipo
                            centrocostoBE.ubigeo = ent.ubigeo
                            centrocostoBE.inicioOperaciones = ent.inicioOperaciones
                            listaCentrocosto.Add(centrocostoBE)
                            guargarUnidadOrganica(centrocostoBE)
                            CrearNodosDelPadre(0)
                        Case 7
                            centrocostoBE = New centrocosto
                            centrocostoBE.idEmpresa = Gempresas.IdEmpresaRuc
                            centrocostoBE.idCentroCosto = listaCentrocosto.Count + 1
                            centrocostoBE.idpadre = entNuevo.idCentroCosto
                            centrocostoBE.nombre = TempNodeText
                            centrocostoBE.TipoEstab = ent.TipoEstab
                            centrocostoBE.nivel = 8
                            centrocostoBE.estado = "A"
                            centrocostoBE.tipoOrganizacion = "ORG"
                            centrocostoBE.[usuarioActualizacion] = "Administrador"
                            centrocostoBE.[fechaActualizacion] = Date.Now
                            centrocostoBE.IDNegocioComercial = ent.IDNegocioComercial
                            centrocostoBE.tipo = ent.tipo
                            centrocostoBE.ubigeo = ent.ubigeo
                            centrocostoBE.inicioOperaciones = ent.inicioOperaciones
                            listaCentrocosto.Add(centrocostoBE)
                            guargarUnidadOrganica(centrocostoBE)
                            CrearNodosDelPadre(0)
                        Case 8
                            centrocostoBE = New centrocosto
                            centrocostoBE.idEmpresa = Gempresas.IdEmpresaRuc
                            centrocostoBE.idCentroCosto = listaCentrocosto.Count + 1
                            centrocostoBE.idpadre = entNuevo.idCentroCosto
                            centrocostoBE.nombre = TempNodeText
                            centrocostoBE.TipoEstab = ent.TipoEstab
                            centrocostoBE.nivel = 9
                            centrocostoBE.estado = "A"
                            centrocostoBE.tipoOrganizacion = "ORG"
                            centrocostoBE.[usuarioActualizacion] = "Administrador"
                            centrocostoBE.[fechaActualizacion] = Date.Now
                            centrocostoBE.IDNegocioComercial = ent.IDNegocioComercial
                            centrocostoBE.tipo = ent.tipo
                            centrocostoBE.ubigeo = ent.ubigeo
                            centrocostoBE.inicioOperaciones = ent.inicioOperaciones
                            listaCentrocosto.Add(centrocostoBE)
                            guargarUnidadOrganica(centrocostoBE)
                            CrearNodosDelPadre(0)

                        Case 9
                            centrocostoBE = New centrocosto
                            centrocostoBE.idEmpresa = Gempresas.IdEmpresaRuc
                            centrocostoBE.idCentroCosto = listaCentrocosto.Count + 1
                            centrocostoBE.idpadre = entNuevo.idCentroCosto
                            centrocostoBE.nombre = TempNodeText
                            centrocostoBE.TipoEstab = ent.TipoEstab
                            centrocostoBE.nivel = 10
                            centrocostoBE.estado = "A"
                            centrocostoBE.tipoOrganizacion = "ORG"
                            centrocostoBE.[usuarioActualizacion] = "Administrador"
                            centrocostoBE.[fechaActualizacion] = Date.Now
                            centrocostoBE.IDNegocioComercial = ent.IDNegocioComercial
                            centrocostoBE.tipo = ent.tipo
                            centrocostoBE.ubigeo = ent.ubigeo
                            centrocostoBE.inicioOperaciones = ent.inicioOperaciones
                            listaCentrocosto.Add(centrocostoBE)
                            guargarUnidadOrganica(centrocostoBE)
                            CrearNodosDelPadre(0)
                        Case 10
                            centrocostoBE = New centrocosto
                            centrocostoBE.idEmpresa = Gempresas.IdEmpresaRuc
                            centrocostoBE.idCentroCosto = listaCentrocosto.Count + 1
                            centrocostoBE.idpadre = entNuevo.idCentroCosto
                            centrocostoBE.nombre = TempNodeText
                            centrocostoBE.TipoEstab = ent.TipoEstab
                            centrocostoBE.nivel = 11
                            centrocostoBE.estado = "A"
                            centrocostoBE.tipoOrganizacion = "ORG"
                            centrocostoBE.[usuarioActualizacion] = "Administrador"
                            centrocostoBE.[fechaActualizacion] = Date.Now
                            centrocostoBE.IDNegocioComercial = ent.IDNegocioComercial
                            centrocostoBE.tipo = ent.tipo
                            centrocostoBE.ubigeo = ent.ubigeo
                            centrocostoBE.inicioOperaciones = ent.inicioOperaciones
                            listaCentrocosto.Add(centrocostoBE)
                            guargarUnidadOrganica(centrocostoBE)
                            CrearNodosDelPadre(0)

                        Case > 11
                            MessageBox.Show("NO PUEDE AGREGAR EN NIVEL")
                    End Select
                End If

            Else
                Throw New Exception("Verificar dato")
            End If



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub EditarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarToolStripMenuItem.Click
        Try
            Dim frm As New FormNuevoRubro
            frm.TextBox1.Text = TrVOrganigrama.SelectedNode.Text
            frm.ShowDialog()
            Dim TempNodeText As String = frm.TextBox1.Text
            frm.Dispose()
            'Dim SelectedNode As TreeNode = trOrganigrama.SelectedNode
            If TempNodeText.Trim <> "" Then

                Dim entNuevo = CType(TrVOrganigrama.SelectedNode.Tag, centrocosto)

                'SelectedNode.Text = TempNodeText
                Dim centroCostosModificar = listaCentrocosto.Where(Function(O) O.idCentroCosto = entNuevo.idCentroCosto).FirstOrDefault

                centroCostosModificar.nombre = TempNodeText
                'CrearNodosDelPadre()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click
        Try
            Dim entNuevo = CType(TrVOrganigrama.SelectedNode.Tag, centrocosto)
            TrVOrganigrama.Nodes.Remove(TrVOrganigrama.SelectedNode)
            listaCentrocosto.Remove((entNuevo))
            'CrearNodosDelPadre()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


#Region "Metodos"

    'Private Sub GetListaCArgos(Id As Integer)
    '    Try

    '        Dim objRolSA As New perfilAnexoSA


    '        Dim dt As New DataTable("Datos Generales")
    '        dt.Columns.Add(New DataColumn("ID", GetType(Integer)))
    '        dt.Columns.Add(New DataColumn("CARGO", GetType(String)))

    '        PERFILESxUnigOrg = objRolSA.GetObtenerPerfilIDestablecimiento(New perfilAnexo With {.idCentroCosto = Id}).ToList


    '        For Each i In PERFILESxUnigOrg
    '            Dim dr As DataRow = dt.NewRow()

    '            dr(0) = (i.idRol)
    '            dr(1) = i.descripcion


    '            dt.Rows.Add(dr)
    '        Next

    '        dgca.DataSource = dt

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

    Private Sub guargarUnidadOrganica(UnidadOrganicaBE As centrocosto)
        Try
            Dim NOMBRE As String
            Dim CentrocostosSA As New CentrocostosSA

            Select Case UnidadOrganicaBE.TipoEstab
                Case "UN"
                    listaCentrocosto = CentrocostosSA.InsertListaEstablecimiento(UnidadOrganicaBE)

                    NOMBRE = listaCentrocosto.Where(Function(o) o.nombre = UnidadOrganicaBE.nombre).FirstOrDefault.idEmpresa

                    Dim M As New frmUONumeracionInicio(NOMBRE, UnidadOrganicaBE.idCentroCosto, UnidadOrganicaBE.tipo)
                    M.StartPosition = FormStartPosition.CenterParent
                    M.ShowDialog()

                Case "SC"
                    listaCentrocosto = CentrocostosSA.InsertListaEstablecimientoApoyo(UnidadOrganicaBE)


                    Select Case UnidadOrganicaBE.tipo
                        Case "CM"
                            NOMBRE = listaCentrocosto.Where(Function(o) o.nombre = UnidadOrganicaBE.nombre).FirstOrDefault.idEmpresa

                            Dim M As New frmUONumeracionInicio(NOMBRE, UnidadOrganicaBE.idCentroCosto, UnidadOrganicaBE.tipo)
                            M.StartPosition = FormStartPosition.CenterParent
                            M.ShowDialog()
                        Case "LG"
                            NOMBRE = listaCentrocosto.Where(Function(o) o.nombre = UnidadOrganicaBE.nombre).FirstOrDefault.idEmpresa

                            Dim M As New frmUONumeracionInicio(NOMBRE, UnidadOrganicaBE.idCentroCosto, UnidadOrganicaBE.tipo)
                            M.StartPosition = FormStartPosition.CenterParent
                            M.ShowDialog()

                        Case "FN"
                            NOMBRE = listaCentrocosto.Where(Function(o) o.nombre = UnidadOrganicaBE.nombre).FirstOrDefault.idEmpresa

                            Dim M As New frmUONumeracionInicio(NOMBRE, UnidadOrganicaBE.idCentroCosto, UnidadOrganicaBE.tipo)
                            M.StartPosition = FormStartPosition.CenterParent
                            M.ShowDialog()
                        Case "RH"

                        Case "TC"

                        Case Else

                    End Select

            End Select

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub CrearNodosDelPadre(TIPO As Integer)
        Try

            Dim establecimientoSA As New establecimientoSA
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

            listaCentrocosto = establecimientoSA.ObtenerListaEstablecimientos(Gempresas.IdEmpresaRuc).ToList

            Dim nodeEncabezado = New TreeNode

            'Descripción o texto del nodo
            nodeEncabezado.Text = Gempresas.IdEmpresaRuc
            nodeEncabezado.ForeColor = Color.Red
            'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
            nodeEncabezado.Name = 0

            'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
            nodeEncabezado.Tag = 0
            TrVOrganigrama.Nodes.Add(nodeEncabezado)

            'Dim consultaPadre = (From a In listaOr Where a.idPadre = 0
            '                     Order By a.idOrganigrama Ascending Select a).ToList

            Dim consultaPadre = (From a In listaCentrocosto Where a.idpadre = 0 _
                                                       And a.tipoOrganizacion = "ORG" Order By a.idCentroCosto Ascending Select a).ToList

            For Each PADRE In consultaPadre
                nodePadre = New TreeNode

                'Descripción o texto del nodo
                nodePadre.Text = PADRE.nombre

                'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
                nodePadre.Name = PADRE.idCentroCosto

                'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
                nodePadre.Tag = PADRE
                TrVOrganigrama.Nodes(contarEncabezado).Nodes.Add(nodePadre)

                Dim consulta = (From a In listaCentrocosto Where a.idpadre = nodePadre.NAME And a.tipoOrganizacion = "ORG"
                                Order By a.idCentroCosto Ascending Select a).ToList

                If ((consulta.Count) > 0) Then
                    For Each hijos In consulta

                        Dim nodeHIJO = New TreeNode

                        'Descripción o texto del nodo
                        nodeHIJO.Text = hijos.nombre
                        nodeHIJO.ForeColor = Color.FromArgb(32, 182, 82)
                        'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
                        nodeHIJO.Name = hijos.idCentroCosto

                        'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
                        nodeHIJO.Tag = hijos
                        TrVOrganigrama.Nodes(contarEncabezado).Nodes(contqao).Nodes.Add(nodeHIJO)

                        Dim consultANietos = (From a In listaCentrocosto Where a.idpadre = nodeHIJO.Name And a.tipoOrganizacion = "ORG"
                                              Order By a.idCentroCosto Ascending Select a).ToList

                        For Each NIETOS In consultANietos
                            Dim nodeNieto = New TreeNode

                            'Descripción o texto del nodo
                            nodeNieto.Text = NIETOS.nombre

                            'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
                            nodeNieto.Name = NIETOS.idCentroCosto

                            'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
                            nodeNieto.Tag = NIETOS
                            TrVOrganigrama.Nodes(contarEncabezado).Nodes(contqao).Nodes(contarHijos).Nodes.Add(nodeNieto)


                            Dim consultanietosA = (From m In listaCentrocosto Where m.idpadre = nodeNieto.Name And m.tipoOrganizacion = "ORG"
                                                   Order By m.idCentroCosto Ascending Select m).ToList

                            For Each nietosA In consultanietosA

                                Dim nodeNietosA = New TreeNode

                                nodeNietosA.Text = nietosA.nombre
                                nodeNietosA.ForeColor = Color.FromArgb(7, 117, 129)
                                nodeNietosA.Name = nietosA.idCentroCosto

                                nodeNietosA.Tag = nietosA
                                TrVOrganigrama.Nodes(contarEncabezado).Nodes(contqao).Nodes(contarHijos).Nodes(nietsosA).Nodes.Add(nodeNietosA)

                                Dim consultaNietoB = (From p In listaCentrocosto Where p.idpadre = nodeNietosA.Name And p.tipoOrganizacion = "ORG"
                                                      Order By p.idCentroCosto Ascending Select p).ToList

                                For Each nietosB In consultaNietoB
                                    Dim nodoNietoB = New TreeNode

                                    nodoNietoB.Text = nietosB.nombre

                                    nodoNietoB.Name = nietosB.idCentroCosto

                                    nodoNietoB.Tag = nietosB

                                    TrVOrganigrama.Nodes(contarEncabezado).Nodes(contqao).Nodes(contarHijos).Nodes(nietsosA).Nodes(nietoB).Nodes.Add(nodoNietoB)

                                    '******************************** NODO NRO "5" ****************************************
                                    Dim consultanietosC = (From m In listaCentrocosto Where m.idpadre = nodoNietoB.Name And m.tipoOrganizacion = "ORG"
                                                           Order By m.idCentroCosto Ascending Select m).ToList

                                    For Each nietosC In consultanietosC
                                        Dim nodeNietosC = New TreeNode

                                        nodeNietosC.Text = nietosC.nombre
                                        nodeNietosC.ForeColor = Color.FromArgb(7, 117, 129)
                                        nodeNietosC.Name = nietosC.idCentroCosto

                                        nodeNietosC.Tag = nietosC
                                        TrVOrganigrama.Nodes(contarEncabezado).Nodes(contqao).Nodes(contarHijos).Nodes(nietsosA).Nodes(nietoB).Nodes(nietoC).Nodes.Add(nodeNietosC)

                                        '******************************** NODO NRO "6" ****************************************
                                        Dim consultanietosD = (From m In listaCentrocosto Where m.idpadre = nodeNietosC.Name And m.tipoOrganizacion = "ORG"
                                                               Order By m.idCentroCosto Ascending Select m).ToList

                                        For Each nietosD In consultanietosD
                                            Dim nodeNietosD = New TreeNode

                                            nodeNietosD.Text = nietosD.nombre
                                            nodeNietosD.ForeColor = Color.FromArgb(7, 117, 129)
                                            nodeNietosD.Name = nietosD.idCentroCosto

                                            nodeNietosD.Tag = nietosD
                                            TrVOrganigrama.Nodes(contarEncabezado).Nodes(contqao).Nodes(contarHijos).Nodes(nietsosA).Nodes(nietoB).Nodes(nietoC).Nodes(nietoD).Nodes.Add(nodeNietosD)


                                            '******************************** NODO NRO "7" ****************************************
                                            Dim consultanietosE = (From m In listaCentrocosto Where m.idpadre = nodeNietosD.Name And m.tipoOrganizacion = "ORG"
                                                                   Order By m.idCentroCosto Ascending Select m).ToList

                                            For Each nietosE In consultanietosE
                                                Dim nodeNietosE = New TreeNode

                                                nodeNietosE.Text = nietosE.nombre
                                                nodeNietosE.ForeColor = Color.FromArgb(7, 117, 129)
                                                nodeNietosE.Name = nietosE.idCentroCosto

                                                nodeNietosE.Tag = nietosE
                                                TrVOrganigrama.Nodes(contarEncabezado).Nodes(contqao).Nodes(contarHijos).Nodes(nietsosA).Nodes(nietoB).Nodes(nietoC).Nodes(nietoD).Nodes(nietoE).Nodes.Add(nodeNietosE)


                                                '******************************** NODO NRO "8" ****************************************
                                                Dim consultanietosF = (From m In listaCentrocosto Where m.idpadre = nodeNietosE.Name And m.tipoOrganizacion = "ORG"
                                                                       Order By m.idCentroCosto Ascending Select m).ToList

                                                For Each nietosF In consultanietosF
                                                    Dim nodeNietosF = New TreeNode

                                                    nodeNietosF.Text = nietosF.nombre
                                                    nodeNietosF.ForeColor = Color.FromArgb(7, 117, 129)
                                                    nodeNietosF.Name = nietosF.idCentroCosto

                                                    nodeNietosF.Tag = nietosF
                                                    TrVOrganigrama.Nodes(contarEncabezado).Nodes(contqao).Nodes(contarHijos).Nodes(nietsosA).Nodes(nietoB).Nodes(nietoC).Nodes(nietoD).Nodes(nietoE).Nodes(nietoF).Nodes.Add(nodeNietosF)


                                                    '******************************** NODO NRO "9" ****************************************
                                                    Dim consultanietosG = (From m In listaCentrocosto Where m.idpadre = nodeNietosF.Name And m.tipoOrganizacion = "ORG"
                                                                           Order By m.idCentroCosto Ascending Select m).ToList

                                                    For Each nietosG In consultanietosG
                                                        Dim nodeNietosG = New TreeNode

                                                        nodeNietosG.Text = nietosG.nombre
                                                        nodeNietosG.ForeColor = Color.FromArgb(7, 117, 129)
                                                        nodeNietosG.Name = nietosG.idCentroCosto

                                                        nodeNietosG.Tag = nietosG
                                                        TrVOrganigrama.Nodes(contarEncabezado).Nodes(contqao).Nodes(contarHijos).Nodes(nietsosA).Nodes(nietoB).Nodes(nietoC).Nodes(nietoD).Nodes(nietoE).Nodes(nietoF).Nodes(nietoG).Nodes.Add(nodeNietosG)

                                                        '******************************** NODO NRO "10" ****************************************
                                                        Dim consultanietosH = (From m In listaCentrocosto Where m.idpadre = nodeNietosG.Name And m.tipoOrganizacion = "ORG"
                                                                               Order By m.idCentroCosto Ascending Select m).ToList

                                                        For Each nietosH In consultanietosH
                                                            Dim nodeNietosH = New TreeNode

                                                            nodeNietosH.Text = nietosH.nombre
                                                            nodeNietosH.ForeColor = Color.FromArgb(7, 117, 129)
                                                            nodeNietosH.Name = nietosH.idCentroCosto

                                                            nodeNietosH.Tag = nietosH
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

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        CrearNodosDelPadre(0)
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        Try

            Dim M As New LinkTextBoxExt.FormModeloOrg
            M.StartPosition = FormStartPosition.CenterParent
            M.ShowDialog()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Try
            Dim TEXTOsELECCION = TrVOrganigrama.SelectedNode.Tag
            Dim M As New frmListaCargosAll(TEXTOsELECCION.idcentroCosto)
            M.StartPosition = FormStartPosition.CenterParent
            M.ShowDialog()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TrVOrganigrama_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TrVOrganigrama.AfterSelect
        'Try
        '    If (TrVOrganigrama.SelectedNode.Text <> Gempresas.IdEmpresaRuc) Then

        '        Dim TEXTOsELECCION = TrVOrganigrama.SelectedNode.Tag

        '        If (Not IsNothing(TEXTOsELECCION)) Then

        '            GetListaCArgos(TEXTOsELECCION.idCentroCosto)

        '        End If
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try

    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        Try
            Dim TEXTOsELECCION = TrVOrganigrama.SelectedNode.Tag
            Dim M As New frmNumeracionXCargoUnigOrg(TEXTOsELECCION, PERFILESxUnigOrg)
            M.StartPosition = FormStartPosition.CenterParent
            M.ShowDialog()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton6_Click(sender As Object, e As EventArgs)
        Dim TEXTOsELECCION = TrVOrganigrama.SelectedNode.Tag
        Dim M As New frmModulosUnidOrganicas(TEXTOsELECCION)
        M.StartPosition = FormStartPosition.CenterParent
        M.ShowDialog()
    End Sub

#End Region

End Class
