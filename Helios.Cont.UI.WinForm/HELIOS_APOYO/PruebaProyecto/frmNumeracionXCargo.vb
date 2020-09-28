Imports Helios.Seguridad.Business.Entity
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Cont.Business.Entity
Imports Syncfusion.Windows.Forms.Tools
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping

Public Class frmNumeracionXCargo

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




    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs)
        'Try
        '    Dim perfilAnexoSA As New perfilAnexoSA
        '    Dim perfilAnexoBE As perfilAnexo
        '    Dim listPerfilAnexo As New List(Of perfilAnexo)


        '    If (dgvCompras.Table.Records.Count > 0) Then
        '        For Each item In dgvCompras.Table.Records
        '            perfilAnexoBE = New perfilAnexo
        '            perfilAnexoBE.idCentroCosto = CInt(item.GetValue("ID"))
        '            perfilAnexoBE.descripcion = txtDescripcion.Text
        '            perfilAnexoBE.tipo = txtDescripcion.Tag
        '            perfilAnexoBE.estado = "A"
        '            perfilAnexoBE.usuarioActualizacion = "ADMIN"
        '            perfilAnexoBE.fechaActualizacion = Date.Now

        '            listPerfilAnexo.Add(perfilAnexoBE)
        '        Next

        '        perfilAnexoSA.SavePerfilAnexo(listPerfilAnexo)
        '    End If

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Close()
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

    'Private Sub dgvCompras_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs)
    '    Try
    '        If (Not IsNothing(dgvCompras.Table.CurrentRecord)) Then
    '            GetListaDatosGenerales(dgvCompras.Table.CurrentRecord.GetValue("IDPerfilAnexo"))
    '        Else
    '            Throw New Exception("Verificar")
    '        End If



    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

#End Region


End Class