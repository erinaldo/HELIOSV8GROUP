Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
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

Namespace LinkTextBoxExt


    Partial Public Class FormModeloOrg
        Inherits MetroForm

        Dim hierarchicalLayout As New HierarchicLayoutManager
        Dim listaCentrocosto As New List(Of centrocosto)
        Dim centrocostoBE As New centrocosto

        Dim LISTANUEVA As New List(Of jerarquia)
        Dim OBJ As New jerarquia

        Private node As TreeNodeAdv = Nothing
        Public nodePadre = New TreeNode

        Public Sub New()
            InitializeComponent()
            'To set the text
            ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
            diagram1.BeginUpdate()
            diagram1.Model.BoundaryConstraintsEnabled = False
            PopulateFields(SetDataSource())
            DiagramAppearance()

            hierarchicalLayout = New HierarchicLayoutManager(diagram1.Model, 0, 70, 40)
            hierarchicalLayout.LeftMargin = 50
            hierarchicalLayout.TopMargin = 50
            diagram1.LayoutManager = hierarchicalLayout
            diagram1.LayoutManager.UpdateLayout(Nothing)
            diagram1.Model.MinimumSize = New SizeF(1000, 1000)
            diagram1.Model.DocumentSize = New PageSize(1000, 1000)

            diagram1.EndUpdate()
        End Sub

#Region "Organigrama"

        Private Sub DiagramAppearance()

            diagram1.Model.RenderingStyle.SmoothingMode = SmoothingMode.HighQuality
            diagram1.View.BackgroundColor = Color.White
            diagram1.Model.BoundaryConstraintsEnabled = False
            diagram1.View.HandleRenderer.HandleColor = Color.AliceBlue
            diagram1.View.HandleRenderer.HandleOutlineColor = Color.SkyBlue
            diagram1.View.SelectionList.Clear()
        End Sub

        Private Function SetDataSource() As DataTable
            Try
                Dim conteo As Integer = 1
                Dim table = New DataTable()
                Dim establecimientoSA As New establecimientoSA

                listaCentrocosto = establecimientoSA.ObtenerListaEstablecimientos(Gempresas.IdEmpresaRuc).ToList

                table.Columns.Add("ID")
                table.Columns.Add("Name")
                table.Columns.Add("Designation")
                table.Columns.Add("ParentName")

                table.Rows.Add(Gempresas.IdEmpresaRuc, Gempresas.IdEmpresaRuc, "", String.Empty)

                For Each rubrobe In listaCentrocosto.Where(Function(o) o.nivel = 1).ToList
                    table.Rows.Add(rubrobe.idCentroCosto, rubrobe.nombre, "", Gempresas.IdEmpresaRuc)

                    For Each segmentoBE In listaCentrocosto.Where(Function(o) o.nivel = 2 And o.idpadre = rubrobe.idCentroCosto).ToList
                        table.Rows.Add(segmentoBE.idCentroCosto, segmentoBE.nombre, "", rubrobe.idCentroCosto)

                        For Each unidadBE In listaCentrocosto.Where(Function(o) o.nivel = 3 And o.idpadre = segmentoBE.idCentroCosto).ToList
                            table.Rows.Add(unidadBE.idCentroCosto, unidadBE.nombre, "", segmentoBE.idCentroCosto)

                            For Each unidad2BE In listaCentrocosto.Where(Function(o) o.nivel = 4 And o.idpadre = unidadBE.idCentroCosto).ToList
                                table.Rows.Add(unidad2BE.idCentroCosto, unidad2BE.nombre, "", unidadBE.idCentroCosto)

                                For Each unidad3BE In listaCentrocosto.Where(Function(o) o.nivel = 5 And o.idpadre = unidad2BE.idCentroCosto).ToList
                                    table.Rows.Add(unidad3BE.idCentroCosto, unidad3BE.nombre, "", unidad2BE.idCentroCosto)


                                Next

                            Next

                        Next

                    Next

                Next


                'table.Rows.Add("2", "Joe Robert", "Manager-SLS", "John Smith")
                'table.Rows.Add("3", "Jack Kent", "Manager-Mkt", "John Smith")
                'table.Rows.Add("4", "Ravi kumar", "Manager-DEV", "John Smith")
                'table.Rows.Add("5", "Sue Raymond", "CSR", "Joe Robert")
                'table.Rows.Add("6", "Lisa Simpson", "CSR", "Joe Robert")
                'table.Rows.Add("7", "Bob Woley", "PM", "Jack Kent")
                'table.Rows.Add("8", "Ron Jones", "Engineer", "Ravi kumar")
                'table.Rows.Add("9", "Dave Mason", "Engineer", "Ravi kumar")

                Return table
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Function

        Private Sub PopulateFields(dt As DataTable)
            Try



                For i As Integer = 0 To dt.Rows.Count - 1 Step +1


                    Dim RECT = New Syncfusion.Windows.Forms.Diagram.RoundRect(0, 0, 150, 80, MeasureUnits.Pixel)

                    RECT.FillStyle.Color = Color.FromArgb(255, 86, 4)
                    RECT.FillStyle.ForeColor = Color.FromArgb(255, 165, 74)
                    RECT.LineStyle.LineColor = Color.White
                    RECT.FillStyle.Type = FillStyleType.LinearGradient

                    RECT.Name = dt.Rows(i)("ID").ToString()

                    Dim Label = New Syncfusion.Windows.Forms.Diagram.Label(RECT, dt.Rows(i)("Name"))

                    Label.FontStyle.Family = "Segoe UI"
                    Label.FontStyle.Size = 9
                    Label.FontColorStyle.Color = Color.White
                    RECT.Labels.Add(Label)

                    Dim label1 = New Syncfusion.Windows.Forms.Diagram.Label(RECT, dt.Rows(i)("Designation").ToString())
                    label1.FontStyle.Family = "Segoe UI"
                    label1.FontStyle.Size = 9
                    label1.FontColorStyle.Color = Color.White
                    label1.OffsetX = RECT.BoundingRectangle.Width / 2 - label1.Size.Width / 2
                    label1.OffsetY = RECT.BoundingRectangle.Height / 2 + 5
                    RECT.Labels.Add(label1)
                    diagram1.Model.AppendChild(RECT)

                    If (Not String.IsNullOrEmpty(dt.Rows(i)("ParentName").ToString())) Then

                        Dim parentNode = diagram1.Model.Nodes.FindNodeByName(dt.Rows(i)("ParentName").ToString())
                        Dim ss = parentNode.Name
                        ConnectNodes(parentNode, RECT)
                    End If
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Sub

        Private Sub ConnectNodes(parentNode As Node, childNode As Node)

            If (Not IsNothing(parentNode) And Not IsNothing(childNode)) Then

                Dim conn = New OrgLineConnector(PointF.Empty, New PointF(0, 1))
                conn.VerticalDistance = 35
                conn.LineStyle.LineColor = Color.Gray

                Dim decor = conn.HeadDecorator
                decor.DecoratorShape = DecoratorShape.Filled45Arrow
                decor.FillStyle.Color = Color.White
                decor.LineStyle.LineColor = Color.Gray

                diagram1.Model.AppendChild(conn)

                parentNode.CentralPort.TryConnect(conn.TailEndPoint)
                childNode.CentralPort.TryConnect(conn.HeadEndPoint)

                diagram1.Model.SendToBack(conn)
            End If
        End Sub

        Private Sub diagram1_Click(sender As Object, e As EventArgs) Handles diagram1.Click

        End Sub




#End Region

#Region "Metodos"

        Private Sub guargarUnidadOrganica(UnidadOrganicaBE As centrocosto)
            Try

                Dim CentrocostosSA As New CentrocostosSA
                listaCentrocosto = CentrocostosSA.InsertListaEstablecimiento(UnidadOrganicaBE)

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Sub



        Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
            diagram1.Model.RemoveAllChildren()
            diagram1.BeginUpdate()
            diagram1.Model.BoundaryConstraintsEnabled = False
            PopulateFields(SetDataSource())
            DiagramAppearance()

            hierarchicalLayout = New HierarchicLayoutManager(diagram1.Model, 0, 70, 40)
            hierarchicalLayout.LeftMargin = 50
            hierarchicalLayout.TopMargin = 50
            diagram1.LayoutManager = hierarchicalLayout
            diagram1.LayoutManager.UpdateLayout(Nothing)
            diagram1.Model.MinimumSize = New SizeF(1000, 1000)
            diagram1.Model.DocumentSize = New PageSize(1000, 1000)

            diagram1.EndUpdate()

        End Sub

        Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs)
            Try
                Dim unidadOrganicaBE As centrocosto
                Dim listaUnidadOrg As New List(Of centrocosto)

                For Each ITEM In listaCentrocosto.Where(Function(O) O.estado = "N").ToList

                    unidadOrganicaBE = New centrocosto With {
                        .idEmpresa = Gempresas.IdEmpresaRuc,
                        .[idCentroCosto] = ITEM.idCentroCosto,
                        .[nombre] = ITEM.nombre,
                        .[TipoEstab] = ITEM.TipoEstab,
                        .[ubigeo] = ITEM.ubigeo,
                        .[idpadre] = ITEM.idpadre,
                        .[detalleAdicional] = Nothing,
                        .[NroOrganizacion] = Nothing,
                        .[tipo] = ITEM.tipoOrganizacion,
                        .[tipoOrganizacion] = ITEM.tipoOrganizacion,
                        .[estado] = "A",
                        .[tipoSegmento] = "",
                        .[nivel] = ITEM.nivel,
                        .[usuarioActualizacion] = "Administrador",
                        .[fechaActualizacion] = Date.Now,
                        .formaControl = "1"
                    }

                    listaUnidadOrg.Add(unidadOrganicaBE)

                Next

                'guargarUnidadOrganica(listaUnidadOrg)

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try


        End Sub

        Private Sub NuevoToolStripMenuItem_Click(sender As Object, e As EventArgs) 

        End Sub

#End Region
    End Class




End Namespace
