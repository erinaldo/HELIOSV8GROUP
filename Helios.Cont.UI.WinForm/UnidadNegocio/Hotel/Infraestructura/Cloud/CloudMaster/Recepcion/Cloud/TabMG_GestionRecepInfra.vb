Imports System.IO
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class TabMG_GestionRecepInfra

#Region "Attributes"
    Public Property FormPurchase As Tab_RecepcionCliente
    Dim listaDistribucion As New List(Of distribucionInfraestructura)
    Dim listaCuartos As New List(Of documentoventaAbarrotesDet)

#End Region

#Region "Constructors"
    Public Sub New(RecepcionCliente As Tab_RecepcionCliente)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormPurchase = RecepcionCliente
        CargarCombos()
        GetTableDetalle()
    End Sub

    Private Sub BunifuFlatButton5_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton5.Click
        GetTableDetalle()
    End Sub

#End Region

#Region "Methods"

    Public Sub CargarCombos()
        Dim tipoServicioInfraestructuraSA As New tipoServicioInfraestructuraSA
        Dim infraestrucutraSA As New infraestructuraSA
        Dim objInfraBE As New infraestructura
        Dim objServicioInfraBE As New tipoServicioInfraestructura
        Dim listaInfra As New List(Of infraestructura)
        Dim listaServicioInfra As New List(Of tipoServicioInfraestructura)
        Dim objInfraDefault As New infraestructura
        Dim objServicioInfraDefault As New tipoServicioInfraestructura

        objInfraBE.idEmpresa = Gempresas.IdEmpresaRuc
        objInfraBE.idEstablecimiento = GEstableciento.IdEstablecimiento
        objInfraBE.tipo = "P"

        objInfraDefault.idInfraestructura = 0
        objInfraDefault.nombre = "TODO"

        listaInfra.Add(objInfraDefault)
        listaInfra.AddRange(infraestrucutraSA.getListaInfraestructura(objInfraBE))

        cboFormato.ValueMember = "idInfraestructura"
        cboFormato.DisplayMember = "nombre"
        cboFormato.DataSource = listaInfra
        cboFormato.SelectedValue = 0


        objServicioInfraBE.idEmpresa = Gempresas.IdEmpresaRuc
        objServicioInfraBE.idEstablecimiento = GEstableciento.IdEstablecimiento

        objServicioInfraDefault.idTipoServicio = 0
        objServicioInfraDefault.descripcionTipoServicio = "TODO"

        listaServicioInfra.Add(objServicioInfraDefault)
        listaServicioInfra.AddRange(tipoServicioInfraestructuraSA.GetUbicartipoServicioInfra(objServicioInfraBE))

        cboCategoria.ValueMember = "idTipoServicio"
        cboCategoria.DisplayMember = "descripcionTipoServicio"
        cboCategoria.DataSource = listaServicioInfra
        cboCategoria.SelectedValue = 0

    End Sub

    Private Sub GetTableDetalle()

        Dim distribucionInfraestructuraSA As New distribucionInfraestructuraSA
        Dim distribucionInfraestructuraBE As New distribucionInfraestructura
        Dim conteo As Integer = 0
        Dim sumatoriaBoton As Integer = 1


        distribucionInfraestructuraBE.tipo = "1"
        distribucionInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
        distribucionInfraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento
        distribucionInfraestructuraBE.tipo = "VNP"
        distribucionInfraestructuraBE.estado = "A"
        distribucionInfraestructuraBE.usuarioActualizacion = "A"
        distribucionInfraestructuraBE.idTipoServicio = cboCategoria.SelectedValue

        'Dim distribucionInfraestructuraSA As New distribucionInfraestructuraSA
        'Dim distribucionInfraestructuraBE As New distribucionInfraestructura
        Dim dt As New DataTable

        With dt.Columns
            .Add("idtabla")
            .Add("bloque")
            .Add("segmento")
            .Add("piso")
            .Add("tipo")
            .Add("descripcion")
            .Add("numero")
            .Add("precio")
            .Add("estado")
            .Add("agregar")
        End With

        For Each i In distribucionInfraestructuraSA.getDistribucionInfraestructuraXtipo(distribucionInfraestructuraBE) '.Where(Function(o) tables.Contains(o.idtabla)).ToList
            dt.Rows.Add(i.idDistribucion, Nothing, Nothing, Nothing, i.usuarioActualizacion, i.descripcionDistribucion, i.numeracion, i.menor, i.estado, False)
        Next
        dgvCompras.DataSource = dt
        dgvCompras.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        dgvCompras.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
    End Sub

    Private Sub BunifuFlatButton7_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton7.Click
        Dim productoBE As New documentoventaAbarrotes
        Dim distribucionInfraestructuraSA As New distribucionInfraestructuraSA
        Dim distribucionInfraestructuraBE As New distribucionInfraestructura
        Dim listaDistribucionInfra As New List(Of String)
        Dim obj As documentoventaAbarrotesDet

        Try
            listaCuartos = New List(Of documentoventaAbarrotesDet)
            For Each item In dgvCompras.Table.Records
                If (item.GetValue("agregar") = True) Then
                    Dim canti As Decimal = 1
                    Dim baseImponible As Decimal = 0
                    Dim Iva As Decimal = 0
                    'Dim sub_total As Decimal = canti * eq.fraccionUnidad.GetValueOrDefault
                    Dim total As Decimal = canti * CDec(item.GetValue("precio"))   'Decimal.Parse(r.GetValue("totalmn"))
                    baseImponible = Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
                    Iva = Math.Round(total - baseImponible, 2)

                    obj = New documentoventaAbarrotesDet
                    Dim cod = System.Guid.NewGuid.ToString()
                    obj.CodigoCosto = 1
                    obj.CustomProducto = New detalleitems
                    obj.CustomProducto.origenProducto = 1
                    obj.CustomProducto.descripcionItem = item.GetValue("descripcion") & " " & item.GetValue("numero")
                    obj.CustomProducto.unidad1 = "NIU"
                    obj.CustomProducto.codigodetalle = item.GetValue("idtabla")
                    obj.CustomProducto.tipoExistencia = "IF"
                    obj.CustomEquivalencia = New detalleitem_equivalencias
                    obj.CustomEquivalencia.fraccionUnidad = 0
                    obj.idItem = item.GetValue("idtabla")
                    obj.DetalleItem = item.GetValue("descripcion") & " " & item.GetValue("numero")
                    obj.catalogo_id = 0
                    obj.monto1 = 1
                    obj.unidad1 = "NIU"
                    obj.tipoExistencia = "IF"
                    obj.montokardex = baseImponible
                    obj.montoIgv = Iva
                    obj.importeMN = CDec(total)
                    obj.PrecioUnitarioVentaMN = CDec(item.GetValue("precio"))
                    obj.precioUnitario = CDec(item.GetValue("precio"))
                    obj.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                    obj.CustomEquivalencia.equivalencia_id = 0
                    obj.CustomCatalogo = New detalleitemequivalencia_catalogos
                    obj.CustomCatalogo.idCatalogo = 0
                    obj.FlagBonif = False
                    obj.CustomListaInventarioMovimiento = New List(Of InventarioMovimiento)
                    obj.idDistribucion = CInt(item.GetValue("idtabla"))
                    obj.fechaIngreso = FormPurchase.fechaIngreso
                    obj.fechaFin = FormPurchase.fechaFin
                    listaDistribucionInfra.Add(item.GetValue("idtabla"))
                    listaCuartos.Add(obj)
                End If
            Next

            distribucionInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
            distribucionInfraestructuraBE.estado = "U"
            distribucionInfraestructuraBE.listaEstado = listaDistribucionInfra
            distribucionInfraestructuraSA.updateDistribucionMasivo(distribucionInfraestructuraBE)
            FormPurchase.Tag = listaCuartos
            FormPurchase.Hide()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub DgvCompras_TableControlCheckBoxClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompras.TableControlCheckBoxClick
        'Me.Cursor = Cursors.WaitCursor
        'Dim obj As New documentocompra
        'Dim RowIndex As Integer = e.Inner.RowIndex
        'Dim cc As GridCurrentCell = GridCompra.TableControl.CurrentCell
        'cc.ConfirmChanges()

        'If RowIndex > -1 Then
        '    e.TableControl.CurrentCell.EndEdit()
        '    e.TableControl.Table.TableDirty = True
        '    e.TableControl.Table.EndEdit()

        '    Dim style3 As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
        '    If style3.Enabled Then
        '        'If style3.TableCellIdentity.Column.Name = "agregar" Then
        '        '    Dim valCheck = Me.GridCompra.TableModel(RowIndex, 9).CellValue
        '        '    Select Case valCheck
        '        '        Case "False" 'TRUE
        '        '            GetCalculoItem(RowIndex)
        '        '            EditarItemVenta(RowIndex)
        '        '            'MessageBox.Show(True)
        '        '        Case Else ' FALSE
        '        '            GetCalculoItem(RowIndex)
        '        '            EditarItemVenta(RowIndex)
        '        '            'MessageBox.Show(False)
        '        '    End Select
        '        'Else
        '        If style3.TableCellIdentity.Column.Name = "agregar" Then
        '            Dim afectaStock = Me.GridCompra.TableModel(RowIndex, 9).CellValue
        '            Select Case afectaStock
        '                Case "False" 'TRUE
        '                    If RowIndex <> -1 Then
        '                        Dim item = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = Me.GridCompra.TableModel(RowIndex, 1).CellValue).SingleOrDefault
        '                        If item IsNot Nothing Then
        '                            With item
        '                                .AfectoInventario = True
        '                            End With
        '                        End If
        '                    End If
        '                Case Else ' FALSE
        '                    If RowIndex <> -1 Then
        '                        Dim item = ListaproductosVendidos.Where(Function(o) o.CodigoCosto = Me.GridCompra.TableModel(RowIndex, 1).CellValue).SingleOrDefault
        '                        If item IsNot Nothing Then
        '                            With item
        '                                .AfectoInventario = False
        '                            End With
        '                        End If
        '                    End If
        '            End Select
        '        End If
        '    End If
        'End If
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub DgvCompras_TableControlCurrentCellKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvCompras.TableControlCurrentCellKeyDown
        'Try

        '    Dim cc As GridCurrentCell = dgvCompras.TableControl.CurrentCell
        '    If cc.RowIndex > -1 Then
        '        If e.Inner.KeyCode = Keys.Enter Then
        '            If cc IsNot Nothing Then

        '                Dim productoBE As New documentoventaAbarrotes
        '                Dim distribucionInfraestructuraSA As New distribucionInfraestructuraSA
        '                Dim distribucionInfraestructuraBE As New distribucionInfraestructura
        '                Dim listaDistribucionInfra As New List(Of String)
        '                Dim obj As documentoventaAbarrotesDet

        '                cc.ConfirmChanges()
        '                Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex - 1, cc.ColIndex), GridTableCellStyleInfo)

        '                Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()

        '                listaCuartos = New List(Of documentoventaAbarrotesDet)

        '                Dim canti As Decimal = 1
        '                Dim baseImponible As Decimal = 0
        '                Dim Iva As Decimal = 0
        '                'Dim sub_total As Decimal = canti * eq.fraccionUnidad.GetValueOrDefault
        '                Dim total As Decimal = canti * CDec(currenrecord.GetValue("precio"))   'Decimal.Parse(r.GetValue("totalmn"))
        '                baseImponible = Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
        '                Iva = Math.Round(total - baseImponible, 2)

        '                obj = New documentoventaAbarrotesDet
        '                Dim cod = System.Guid.NewGuid.ToString()
        '                obj.CodigoCosto = 1
        '                obj.CustomProducto = New detalleitems
        '                obj.CustomProducto.origenProducto = 1
        '                obj.CustomProducto.descripcionItem = currenrecord.GetValue("descripcion") & " " & currenrecord.GetValue("numero")
        '                obj.CustomProducto.unidad1 = "NIU"
        '                obj.CustomProducto.codigodetalle = currenrecord.GetValue("idtabla")
        '                obj.CustomProducto.tipoExistencia = "IF"
        '                obj.CustomEquivalencia = New detalleitem_equivalencias
        '                obj.CustomEquivalencia.fraccionUnidad = 0
        '                obj.idItem = currenrecord.GetValue("idtabla")
        '                obj.DetalleItem = currenrecord.GetValue("descripcion") & " " & currenrecord.GetValue("numero")
        '                obj.catalogo_id = 0
        '                obj.monto1 = 1
        '                obj.unidad1 = "NIU"
        '                obj.tipoExistencia = "IF"
        '                obj.montokardex = baseImponible
        '                obj.montoIgv = Iva
        '                obj.importeMN = CDec(total)
        '                obj.PrecioUnitarioVentaMN = CDec(currenrecord.GetValue("precio"))
        '                obj.precioUnitario = CDec(currenrecord.GetValue("precio"))
        '                obj.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
        '                obj.CustomEquivalencia.equivalencia_id = 0
        '                obj.CustomCatalogo = New detalleitemequivalencia_catalogos
        '                obj.CustomCatalogo.idCatalogo = 0
        '                obj.FlagBonif = False
        '                obj.CustomListaInventarioMovimiento = New List(Of InventarioMovimiento)
        '                obj.idDistribucion = CInt(currenrecord.GetValue("idtabla"))
        '                obj.fechaIngreso = FormPurchase.fechaIngreso
        '                obj.fechaFin = FormPurchase.fechaFin

        '                listaDistribucionInfra.Add(currenrecord.GetValue("idtabla"))
        '                listaCuartos.Add(obj)

        '                distribucionInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
        '                distribucionInfraestructuraBE.estado = "U"
        '                distribucionInfraestructuraBE.listaEstado = listaDistribucionInfra
        '                distribucionInfraestructuraSA.updateDistribucionMasivo(distribucionInfraestructuraBE)
        '                FormPurchase.Tag = listaCuartos

        '            End If

        '        End If

        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub


#End Region

#Region "Events"


#End Region

End Class
