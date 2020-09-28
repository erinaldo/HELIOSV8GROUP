Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports System.IO
Imports Microsoft.VisualBasic.FileIO
Imports System.Net
Imports Syncfusion.Windows.Forms.Diagram
Imports System.Drawing.Drawing2D

Public Class FormOrganigramaEmpresa
    Dim hierarchicalLayout As New HierarchicLayoutManager
    Dim listaCentrocosto As New List(Of centrocosto)
    Dim centrocostoBE As New centrocosto
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().




        CrearNodosDelPadre()
    End Sub

    Private Sub ButtonAdv15_Click(sender As Object, e As EventArgs) Handles ButtonAdv15.Click
        Dispose()
    End Sub

#Region "ARBOL DE ORGANIGRAMA"

    Private Sub CrearNodosDelPadre()
        Try

            Dim nodePadre As TreeNode
            Dim contqao As Integer = 0
            Dim contarHijos As Integer = 0
            Dim nietsosA As Integer = 0
            Dim nietoB As Integer = 0
            Dim contarEncabezado As Integer = 0
            Dim establecimientoSA As New establecimientoSA

            listaCentrocosto = establecimientoSA.ObtenerListaEstablecimientos(Gempresas.IdEmpresaRuc).ToList


            trOrganigrama.Nodes.Clear()

            Dim nodeEncabezado = New TreeNode

            'Descripción o texto del nodo
            nodeEncabezado.Text = Gempresas.NomEmpresa
            nodeEncabezado.ForeColor = Color.Red
            'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
            nodeEncabezado.Name = 0

            'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
            nodeEncabezado.Tag = 0
            trOrganigrama.Nodes.Add(nodeEncabezado)

            Dim consultaPadre = (From a In listaCentrocosto Where a.idpadre = 0 Select a).ToList

            'Dim consultaPadre = (From a In listaOr Where a.idPadre = 0 And a.idCentroCosto = cbunidadnegocioOrg.SelectedValue
            '                     Order By a.idOrganigrama Ascending Select a).ToList

            For Each PADRE In consultaPadre
                nodePadre = New TreeNode

                'Descripción o texto del nodo
                nodePadre.Text = PADRE.nombre

                'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
                nodePadre.Name = PADRE.idCentroCosto

                'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
                nodePadre.Tag = PADRE

                Dim ent = CType(nodePadre.Tag, centrocosto)

                trOrganigrama.Nodes(contarEncabezado).Nodes.Add(nodePadre)

                Dim consulta = (From a In listaCentrocosto Where a.idpadre = ent.idCentroCosto
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
                        'nodeHIJO.Tag = hijos.ID

                        nodeHIJO.Tag = hijos

                        Dim entHijo = CType(nodeHIJO.Tag, centrocosto)

                        trOrganigrama.Nodes(contarEncabezado).Nodes(contqao).Nodes.Add(nodeHIJO)

                        Dim consultANietos = (From a In listaCentrocosto Where a.idpadre = entHijo.idCentroCosto
                                              Order By a.idCentroCosto Ascending Select a).ToList

                        For Each NIETOS In consultANietos
                            Dim nodeNieto = New TreeNode

                            'Descripción o texto del nodo
                            nodeNieto.Text = NIETOS.nombre

                            'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
                            nodeNieto.Name = NIETOS.idCentroCosto

                            'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
                            'nodeNieto.Tag = NIETOS.ID
                            nodeNieto.Tag = NIETOS

                            Dim entNieto = CType(nodeNieto.Tag, centrocosto)

                            trOrganigrama.Nodes(contarEncabezado).Nodes(contqao).Nodes(contarHijos).Nodes.Add(nodeNieto)


                            Dim consultanietosA = (From m In listaCentrocosto Where m.idpadre = entNieto.idCentroCosto
                                                   Order By m.idCentroCosto Ascending Select m).ToList

                            For Each nietosA In consultanietosA

                                Dim nodeNietosA = New TreeNode

                                nodeNietosA.Text = nietosA.nombre
                                nodeNietosA.ForeColor = Color.FromArgb(7, 117, 129)
                                nodeNietosA.Name = nietosA.idCentroCosto

                                'nodeNietosA.Tag = nietosA.ID
                                nodeNietosA.Tag = nietosA

                                Dim entnodeNietosA = CType(nodeNieto.Tag, centrocosto)
                                trOrganigrama.Nodes(contarEncabezado).Nodes(contqao).Nodes(contarHijos).Nodes(nietsosA).Nodes.Add(nodeNietosA)

                                Dim consultaNietoB = (From p In listaCentrocosto Where p.idpadre = entnodeNietosA.idCentroCosto
                                                      Order By p.idCentroCosto Ascending Select p).ToList

                                For Each nietosB In consultaNietoB
                                    Dim nodoNietoB = New TreeNode

                                    nodoNietoB.Text = nietosB.nombre

                                    nodoNietoB.Name = nietosB.idCentroCosto

                                    'nodoNietoB.Tag = nietosB.ID
                                    nodeNietosA.Tag = nietosB
                                    trOrganigrama.Nodes(contarEncabezado).Nodes(contqao).Nodes(contarHijos).Nodes(nietsosA).Nodes(nietoB).Nodes.Add(nodoNietoB)
                                Next
                                nietoB += 1

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
            trOrganigrama.EndUpdate()
            trOrganigrama.ExpandAll()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
#End Region

End Class