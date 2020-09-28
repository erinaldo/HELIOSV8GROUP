Imports Helios.Seguridad.Business.Entity
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Cont.Business.Entity
Imports Syncfusion.Windows.Forms.Tools
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping

Public Class frmVerCargos

#Region "Atributos"
    Dim listaOr As New List(Of Rol)
    Dim UnidadOrganicaBE As organizacion
    Dim ListaUnidadOrganica As New List(Of organizacion)
    Private node As TreeNodeAdv = Nothing
    Public nodePadre = New TreeNode
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Dim UnidadOrgID As Integer

#End Region

#Region "Constructor"

    Sub New(IdUnidadOrg As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UnidadOrgID = IdUnidadOrg
        GETORGANIZACION()

    End Sub

#End Region

#Region "Metodos"

    Public Sub GETORGANIZACION()
        Dim ORGSA As New RolSA
        'listaOr = ORGSA.GetRolesXEstablecimiento(New Rol With {.idEstablecimiento = UnidadOrgID, .tipo = 2})
        'GetListaDatosGenerales(listaOr, UnidadOrgID)
    End Sub

    Private Sub GetListaDatosGenerales(listaOrg As List(Of Rol), UnidadOrgID As Integer)
        Try

            Dim perfilAnexoSA As New perfilAnexoSA
            Dim listaPErfil As New List(Of perfilAnexo)


            dgCargos.Table.Records.DeleteAll()

            Dim dt As New DataTable("Datos Generales")
            dt.Columns.Add(New DataColumn("ID", GetType(Integer)))
            dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
            dt.Columns.Add(New DataColumn("agreagar"))


            listaPErfil = perfilAnexoSA.GetObtenerPerfilIDestablecimiento(New perfilAnexo With {.idCentroCosto = UnidadOrgID}).ToList

            For Each i In listaOrg.Where(Function(o) o.control = "GR").ToList
                Dim dr As DataRow = dt.NewRow()

                dr(0) = (i.IDRol)
                dr(1) = i.Nombre

                If (listaPErfil.Where(Function(o) o.idCentroCosto = UnidadOrgID And o.idRol = i.IDRol).Count > 0) Then
                    dr(2) = True
                Else
                    dr(2) = False
                End If

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
            dgCargos.DataSource = table
        End If
    End Sub


    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Close()
    End Sub

    Private Sub GridGroupingControl1_TableControlCheckBoxClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles dgCargos.TableControlCheckBoxClick
        Try

            Me.Cursor = Cursors.WaitCursor
            Dim obj As New documentocompra
            Dim RowIndex As Integer = e.Inner.RowIndex
            Dim cc As GridCurrentCell = dgCargos.TableControl.CurrentCell
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
                                    Dim perfilAnexosa As New perfilAnexoSA
                                    Dim ID = UnidadOrgID
                                    Dim IDRol = (record.GetValue("ID"))
                                    Dim nombre = (record.GetValue("descripcion"))
                                    perfilAnexosa.SavePerfilAnexoSingle(New perfilAnexo With {.idCentroCosto = ID, .idRol = IDRol, .estado = "A", .descripcion = nombre, .usuarioActualizacion = "Administrador", .fechaActualizacion = Date.Now})

                                Case Else ' FALSE
                                    Dim perfilAnexosa As New perfilAnexoSA
                                    Dim ID = UnidadOrgID
                                    Dim IDRol = (record.GetValue("ID"))
                                    Dim nombre = (record.GetValue("descripcion"))


                                    perfilAnexosa.UpdatePerfilAnexoSingle(New perfilAnexo With {.idCentroCosto = ID, .idRol = IDRol})
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

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs)
        Try
            For Each Record In dgCargos.Table.Records
                Dim perfilAnexosa As New perfilAnexoSA
                Dim ID = UnidadOrgID
                Dim IDRol = (Record.GetValue("ID"))
                Dim nombre = (Record.GetValue("descripcion"))
                perfilAnexosa.SavePerfilAnexoSingle(New perfilAnexo With {.idCentroCosto = ID, .idRol = IDRol, .estado = "A", .descripcion = nombre, .usuarioActualizacion = "Administrador", .fechaActualizacion = Date.Now})
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        GETORGANIZACION()
    End Sub

#End Region


End Class