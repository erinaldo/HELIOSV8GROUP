Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports PopupControl
Imports ProcesosGeneralesCajamiSoft
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Syncfusion.Windows.Forms
Imports System.Text.RegularExpressions
Imports Syncfusion.Windows.Forms.Tools

Public Class UCARBOL

#Region "ATRIBUTOS"

    Dim listaOr As New List(Of organizacion)

    Private node As TreeNodeAdv = Nothing
    Public nodePadre = New TreeNode

#End Region

#Region "CONTRUCTOR"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        GETORGANIZACION()
        CrearNodosDelPadre(0)

    End Sub
#End Region

    Public Sub GETORGANIZACION()
        Dim ORGSA As New OrganizacionSA
        listaOr = ORGSA.GetObtenerOrganizacion(Gempresas.IdEmpresaRuc)
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

            Dim consultaPadre = (From a In listaOr Where a.idPadre = 0 And a.idCentroCosto = GEstableciento.IdEstablecimiento _
                                                       And a.TipoOrganizacion = "ORG" Order By a.idOrganigrama Ascending Select a).ToList

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


    Public Sub CrearNodosDelPadreTexto(TEXTO As String)
        Try

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

            Dim consultaPadre = (From a In listaOr Where a.idCentroCosto = GEstableciento.IdEstablecimiento _
                                                      And a.descripcion = TEXTO Order By a.idOrganigrama Ascending Select a).ToList

            For Each PADRE In consultaPadre
                nodePadre = New TreeNode

                'Descripción o texto del nodo
                nodePadre.Text = PADRE.descripcion

                'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
                nodePadre.Name = PADRE.idOrganigrama

                'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
                nodePadre.Tag = PADRE.idOrganigrama
                TrVOrganigrama.Nodes(contarEncabezado).Nodes.Add(nodePadre)

                Dim consulta = (From a In listaOr Where a.idPadre = nodePadre.Tag
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

                        Dim consultANietos = (From a In listaOr Where a.idPadre = nodeHIJO.Tag
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


                            Dim consultanietosA = (From m In listaOr Where m.idPadre = nodeNieto.Tag
                                                   Order By m.idOrganigrama Ascending Select m).ToList

                            For Each nietosA In consultanietosA

                                Dim nodeNietosA = New TreeNode

                                nodeNietosA.Text = nietosA.descripcion
                                nodeNietosA.ForeColor = Color.FromArgb(7, 117, 129)
                                nodeNietosA.Name = nietosA.idOrganigrama

                                nodeNietosA.Tag = nietosA.idOrganigrama
                                TrVOrganigrama.Nodes(contarEncabezado).Nodes(contqao).Nodes(contarHijos).Nodes(nietsosA).Nodes.Add(nodeNietosA)

                                Dim consultaNietoB = (From p In listaOr Where p.idPadre = nodeNietosA.Tag
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
            TrVOrganigrama.EndUpdate()
            TrVOrganigrama.ExpandAll()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub




    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click

        'If cboBusqArb.Text = "TODO" Then
        '    CrearNodosDelPadre(0)

        'Else
        '    CrearNodosDelPadreTexto(txtBusqueARBOL.Text)
        'End If
        GETORGANIZACION()
        CrearNodosDelPadre(0)
    End Sub

    Private Sub cbsegmentoOrg_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboBusqArb.SelectionChangeCommitted
        Select Case cboBusqArb.Text
            Case "TODO"
                txtBusqueARBOL.Visible = False
                Label1.Visible = False
                btnGuarTodo.Text = "BUSCAR"
            Case "POR DESCRIPCION"
                txtBusqueARBOL.Visible = True
                Label1.Visible = True
                btnGuarTodo.Text = "CONSULTAR"
        End Select
    End Sub


    '************BUSQUERDA DE ORGANIZACION****************************************************

    Private Sub txtBusqueARBOL_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBusqueARBOL.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        ElseIf e.KeyCode = Keys.Enter Then

            CrearNodosDelPadreTexto(txtBusqueARBOL.Text)

        Else
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.PopupControlContainer1.Size = New Size(350, 180)
            Me.PopupControlContainer1.ParentControl = Me.txtBusqueARBOL
            Me.PopupControlContainer1.ShowPopup(Point.Empty)

            Dim consulta3 = (From n In listaOr
                             Where n.descripcion.StartsWith(txtBusqueARBOL.Text.ToUpper) And n.nivel <= 4).ToList


            'consulta2.AddRange(consulta2)
            FillLSValXLoteDes(consulta3)
            e.Handled = True
        End If



        If e.KeyCode = Keys.Down Then
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.PopupControlContainer1.Size = New Size(350, 180)
            Me.PopupControlContainer1.ParentControl = Me.txtBusqueARBOL
            Me.PopupControlContainer1.ShowPopup(Point.Empty)
            ListView1.Focus()
        End If




        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.PopupControlContainer1.IsShowing() Then
                Me.PopupControlContainer1.HidePopup(PopupCloseType.Canceled)
            End If
        End If

    End Sub

    Private Sub ListView1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseDoubleClick
        Me.PopupControlContainer1.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub PopupControlContainer1_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer1.CloseUp
        Me.Cursor = Cursors.WaitCursor

        Dim OrganizaSA As New OrganizacionSA


        If e.PopupCloseType = PopupCloseType.Done Then
            If ListView1.SelectedItems.Count > 0 Then
                txtBusqueARBOL.Text = ListView1.SelectedItems(0).SubItems(1).Text
                txtBusqueARBOL.Tag = ListView1.SelectedItems(0).SubItems(0).Text
                txtBusqueARBOL.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)

                'listadoxLotesDes = OrganizaSA.GetObtenerOrganizacion(Gempresas.IdEmpresaRuc)
                'listaOr

            End If
        End If
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtBusqueARBOL.Focus()
        End If
        Me.Cursor = Cursors.Arrow


    End Sub

    Private Sub txtBusqueARBOL_TextAlignChanged(sender As Object, e As EventArgs) Handles txtBusqueARBOL.TextAlignChanged
        txtBusqueARBOL.ForeColor = Color.Black
        txtBusqueARBOL.Tag = Nothing
    End Sub


    Private Sub FillLSValXLoteDes(consulta As List(Of organizacion))
        ListView1.Items.Clear()
        '     Dim image = ImageList1.Images(0)
        For Each i In consulta
            Dim n As New ListViewItem(i.idOrganigrama)
            n.SubItems.Add(i.descripcion)
            ListView1.Items.Add(n)
        Next
    End Sub


    '***************************************************************************************************

    Private Sub cboBusqArb_KeyDown(sender As Object, e As KeyEventArgs) Handles cboBusqArb.KeyDown
        If cboBusqArb.Text = "TODO" Then
            txtBusqueARBOL.Clear()
            txtBusqueARBOL.Select()
            CrearNodosDelPadre(0)

        End If
        GETORGANIZACION()
    End Sub

    Private Sub btnGuarTodo_Click(sender As Object, e As EventArgs) Handles btnGuarTodo.Click
        Select Case btnGuarTodo.Text
            Case "CONSULTAR"
                CrearNodosDelPadreTexto(txtBusqueARBOL.Text)
            Case "BUSCAR"
                CrearNodosDelPadre(0)
        End Select
    End Sub
End Class
