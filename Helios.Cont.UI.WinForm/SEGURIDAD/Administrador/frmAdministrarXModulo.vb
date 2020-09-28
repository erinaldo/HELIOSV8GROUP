Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Helios.Seguridad.Business.Entity
Imports Syncfusion.Windows.Forms.Grid

Public Class frmAdministrarXModulo

#Region "Attributes"
    Public Property ProductoSA As New ProductoSA
    Public Property autorizaSA As New AutorizacionRolSA
    Public Property autorizaDetalleSA As New ProductoDetalleSA
    Public Property frmModulos As frmModalSistemas
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridPequeño(dgPerfilAutoriza, False)
        'GetPefiles()
        Dim dt As New DataTable()
        dt.Columns.Add("IDAsegurable")
        dt.Columns.Add("Nombre")
        dt.Columns.Add("modulo")
        dt.Columns.Add("autorizado", GetType(Boolean))
        dgPerfilAutoriza.DataSource = dt
        GetPefiles()
    End Sub
#End Region

#Region "Methods"
    Sub GetPefiles()
        cboPErfil.ValueMember = "idProducto"
        cboPErfil.DisplayMember = "nombre"
        cboPErfil.DataSource = ProductoSA.ListadoProductoFull
        cboPErfil.SelectedIndex = -1
    End Sub

    'Private Sub listaModulos(tipoModulo As String)
    '    Dim listaModulos As New List(Of Integer)
    '    Select Case tipoModulo
    '        Case "PV.00"
    '            'COMPRAS
    '            listaModulos.Add(AsegurablesSistema.MAESTRO_COMPRAS)
    '            listaModulos.Add(AsegurablesSistema.COMPRA_AL_CONTADO_Existencias_servicios_y_otros_)
    '            'INVENTARIO
    '            listaModulos.Add(AsegurablesSistema.PROVEEDOR_MAESTRO)
    '            listaModulos.Add(AsegurablesSistema.OTROS_INGRESOS_DE_INVENTARIOS)
    '            listaModulos.Add(AsegurablesSistema.OTRAS_SALIDAS_DE_INVENTARIOS)
    '            listaModulos.Add(AsegurablesSistema.INFORMACIÓN_Kardex)
    '            'listaModulos.Add(AsegurablesSistema.INFORMACIÓN_Invent_Valoriz)
    '            listaModulos.Add(AsegurablesSistema.TRANSFERENCIA_ENTRE_ALMACENES_)
    '            'VENTA - FACTURACION
    '            listaModulos.Add(AsegurablesSistema.VENTA_POS_CONTADO_Entrega_total__)
    '            listaModulos.Add(AsegurablesSistema.LISTA_DE_PRECIOS_DE_SERVICIOS_)
    '            listaModulos.Add(AsegurablesSistema.LISTA_DE_PRECIOS_DE_INVENTARIOS_)
    '            listaModulos.Add(AsegurablesSistema.ADMINISTRACION_DE_CLIENTES)
    '            'FINANZAS
    '            listaModulos.Add(AsegurablesSistema.CUENTAS_FINANCIERAS_)
    '            listaModulos.Add(AsegurablesSistema.CUENTAS_FINANCIERAS_CAJA_EFECTIVO)
    '            listaModulos.Add(AsegurablesSistema.ADMINISTRACIÓN_DE_USUARIOS_)
    '            listaModulos.Add(AsegurablesSistema.CAJA_Abrir_Cerrar)
    '            listaModulos.Add(AsegurablesSistema.OTROS_INGRESOS_A_CAJA_)
    '            listaModulos.Add(AsegurablesSistema.OTRAS_SALIDAS_DE_CAJA_)
    '            'INFORMACION 
    '            listaModulos.Add(AsegurablesSistema.INFORMACION_GERENCIAL_Dashword)

    '        Case "PV.01"

    '            'COMPRAS
    '            listaModulos.Add(AsegurablesSistema.MAESTRO_COMPRAS)
    '            listaModulos.Add(AsegurablesSistema.COMPRA_AL_CONTADO_Existencias_servicios_y_otros_)
    '            'INVENTARIO
    '            listaModulos.Add(AsegurablesSistema.PROVEEDOR_MAESTRO)
    '            listaModulos.Add(AsegurablesSistema.OTROS_INGRESOS_DE_INVENTARIOS)
    '            listaModulos.Add(AsegurablesSistema.OTRAS_SALIDAS_DE_INVENTARIOS)
    '            listaModulos.Add(AsegurablesSistema.INFORMACIÓN_Kardex)
    '            'listaModulos.Add(AsegurablesSistema.INFORMACIÓN_Invent_Valoriz)
    '            listaModulos.Add(AsegurablesSistema.TRANSFERENCIA_ENTRE_ALMACENES_)
    '            'VENTA - FACTURACION
    '            listaModulos.Add(AsegurablesSistema.VENTA_POS_CONTADO_Entrega_total__)
    '            listaModulos.Add(AsegurablesSistema.LISTA_DE_PRECIOS_DE_SERVICIOS_)
    '            listaModulos.Add(AsegurablesSistema.LISTA_DE_PRECIOS_DE_INVENTARIOS_)
    '            listaModulos.Add(AsegurablesSistema.ADMINISTRACION_DE_CLIENTES)
    '            listaModulos.Add(AsegurablesSistema.AD_PRE_VENTA)
    '            'FINANZAS
    '            listaModulos.Add(AsegurablesSistema.CUENTAS_FINANCIERAS_)
    '            listaModulos.Add(AsegurablesSistema.CUENTAS_FINANCIERAS_CAJA_EFECTIVO)
    '            listaModulos.Add(AsegurablesSistema.ADMINISTRACIÓN_DE_USUARIOS_)
    '            listaModulos.Add(AsegurablesSistema.CAJA_Abrir_Cerrar)
    '            listaModulos.Add(AsegurablesSistema.OTROS_INGRESOS_A_CAJA_)
    '            listaModulos.Add(AsegurablesSistema.OTRAS_SALIDAS_DE_CAJA_)
    '            'INFORMACION 
    '            listaModulos.Add(AsegurablesSistema.INFORMACION_GERENCIAL_Dashword)
    '            listaModulos.Add(AsegurablesSistema.CENTRO_DE_COSTOS)
    '        Case "PV.02"

    '            'COMPRAS
    '            listaModulos.Add(AsegurablesSistema.MAESTRO_COMPRAS)
    '            listaModulos.Add(AsegurablesSistema.COMPRA_AL_CONTADO_Existencias_servicios_y_otros_)
    '            listaModulos.Add(AsegurablesSistema.NOTAS_DE_CREDITO_COMPRA)
    '            listaModulos.Add(AsegurablesSistema.NOTAS_DE_DEBITO_COMPRA)
    '            'INVENTARIO
    '            listaModulos.Add(AsegurablesSistema.PROVEEDOR_MAESTRO)
    '            listaModulos.Add(AsegurablesSistema.OTROS_INGRESOS_DE_INVENTARIOS)
    '            listaModulos.Add(AsegurablesSistema.OTRAS_SALIDAS_DE_INVENTARIOS)
    '            listaModulos.Add(AsegurablesSistema.INFORMACIÓN_Kardex)
    '            listaModulos.Add(AsegurablesSistema.INFORMACIÓN_Invent_Valoriz)
    '            listaModulos.Add(AsegurablesSistema.TRANSFERENCIA_ENTRE_ALMACENES_)
    '            'VENTA - FACTURACION
    '            listaModulos.Add(AsegurablesSistema.VENTA_POS_CONTADO_Entrega_total__)
    '            listaModulos.Add(AsegurablesSistema.LISTA_DE_PRECIOS_DE_SERVICIOS_)
    '            listaModulos.Add(AsegurablesSistema.LISTA_DE_PRECIOS_DE_INVENTARIOS_)
    '            listaModulos.Add(AsegurablesSistema.ADMINISTRACION_DE_CLIENTES)
    '            listaModulos.Add(AsegurablesSistema.AD_PRE_VENTA)
    '            listaModulos.Add(AsegurablesSistema.COTIZACIONES)
    '            listaModulos.Add(AsegurablesSistema.NOTAS_DE_CREDITO_VENTA)
    '            listaModulos.Add(AsegurablesSistema.NOTAS_DE_DEBITO_VENTA)
    '            'FINANZAS
    '            listaModulos.Add(AsegurablesSistema.CUENTAS_FINANCIERAS_)
    '            listaModulos.Add(AsegurablesSistema.CUENTAS_FINANCIERAS_CAJA_EFECTIVO)
    '            listaModulos.Add(AsegurablesSistema.CUENTAS_FINANCIERAS_BANCOS)
    '            listaModulos.Add(AsegurablesSistema.ADMINISTRACIÓN_DE_USUARIOS_)
    '            listaModulos.Add(AsegurablesSistema.CAJA_Abrir_Cerrar)
    '            listaModulos.Add(AsegurablesSistema.OTROS_INGRESOS_A_CAJA_)
    '            listaModulos.Add(AsegurablesSistema.OTRAS_SALIDAS_DE_CAJA_)
    '            listaModulos.Add(AsegurablesSistema.CUENTAS_POR_COBRAR_)
    '            listaModulos.Add(AsegurablesSistema.CUENTAS_POR_PAGAR_)
    '            'INFORMACION 
    '            listaModulos.Add(AsegurablesSistema.INFORMACION_GERENCIAL_Dashword)
    '            listaModulos.Add(AsegurablesSistema.CENTRO_DE_COSTOS)
    '            'LIBRO ELECTRONICOS
    '            listaModulos.Add(AsegurablesSistema.REGISTRO_DE_VENTAS_LE)
    '            listaModulos.Add(AsegurablesSistema.REGISTRO_DE_COMPRAS_LE)
    '        Case "PV.03"

    '            'COMPRAS
    '            listaModulos.Add(AsegurablesSistema.MAESTRO_COMPRAS)
    '            listaModulos.Add(AsegurablesSistema.COMPRA_AL_CONTADO_Existencias_servicios_y_otros_)
    '            listaModulos.Add(AsegurablesSistema.NOTAS_DE_CREDITO_COMPRA)
    '            listaModulos.Add(AsegurablesSistema.NOTAS_DE_DEBITO_COMPRA)
    '            'INVENTARIO
    '            listaModulos.Add(AsegurablesSistema.PROVEEDOR_MAESTRO)
    '            listaModulos.Add(AsegurablesSistema.OTROS_INGRESOS_DE_INVENTARIOS)
    '            listaModulos.Add(AsegurablesSistema.OTRAS_SALIDAS_DE_INVENTARIOS)
    '            listaModulos.Add(AsegurablesSistema.INFORMACIÓN_Kardex)
    '            listaModulos.Add(AsegurablesSistema.INFORMACIÓN_Invent_Valoriz)
    '            listaModulos.Add(AsegurablesSistema.TRANSFERENCIA_ENTRE_ALMACENES_)
    '            'VENTA - FACTURACION
    '            listaModulos.Add(AsegurablesSistema.VENTA_POS_CONTADO_Entrega_total__)
    '            listaModulos.Add(AsegurablesSistema.LISTA_DE_PRECIOS_DE_SERVICIOS_)
    '            listaModulos.Add(AsegurablesSistema.LISTA_DE_PRECIOS_DE_INVENTARIOS_)
    '            listaModulos.Add(AsegurablesSistema.ADMINISTRACION_DE_CLIENTES)
    '            listaModulos.Add(AsegurablesSistema.AD_PRE_VENTA)
    '            listaModulos.Add(AsegurablesSistema.COTIZACIONES)
    '            listaModulos.Add(AsegurablesSistema.NOTAS_DE_CREDITO_VENTA)
    '            listaModulos.Add(AsegurablesSistema.NOTAS_DE_DEBITO_VENTA)
    '            listaModulos.Add(AsegurablesSistema.VENTA_ANTICIPADA)
    '            listaModulos.Add(AsegurablesSistema.RECLAMACION_DE_CLIENTES)
    '            listaModulos.Add(AsegurablesSistema.COMPENSACION_ENTRE_OBLIGACIONES)
    '            listaModulos.Add(AsegurablesSistema.FACTURA_BOLETA_DE_VENTA_ELECTRONICA)
    '            listaModulos.Add(AsegurablesSistema.NOTA_DE_CREDITO_DEBITO_ELECTRONICO)
    '            'FINANZAS
    '            listaModulos.Add(AsegurablesSistema.CUENTAS_FINANCIERAS_)
    '            listaModulos.Add(AsegurablesSistema.CUENTAS_FINANCIERAS_CAJA_EFECTIVO)
    '            listaModulos.Add(AsegurablesSistema.CUENTAS_FINANCIERAS_BANCOS)
    '            listaModulos.Add(AsegurablesSistema.ADMINISTRACIÓN_DE_USUARIOS_)
    '            listaModulos.Add(AsegurablesSistema.CAJA_Abrir_Cerrar)
    '            listaModulos.Add(AsegurablesSistema.OTROS_INGRESOS_A_CAJA_)
    '            listaModulos.Add(AsegurablesSistema.OTRAS_SALIDAS_DE_CAJA_)
    '            listaModulos.Add(AsegurablesSistema.CUENTAS_POR_COBRAR_)
    '            listaModulos.Add(AsegurablesSistema.CUENTAS_POR_PAGAR_)
    '            'INFORMACION 
    '            listaModulos.Add(AsegurablesSistema.INFORMACION_GERENCIAL_Dashword)
    '            listaModulos.Add(AsegurablesSistema.CENTRO_DE_COSTOS)
    '    End Select
    '    GetAutorizacionesByRol(listaModulos)
    'End Sub

    Public Sub GetAutorizacionesByRol(ID As Integer)
        Dim dt As New DataTable()
        dt.Columns.Add("IDAsegurable")
        dt.Columns.Add("Nombre")
        dt.Columns.Add("modulo")
        dt.Columns.Add("producto")
        dt.Columns.Add("idProducto")
        dt.Columns.Add("autoriza")

        For Each i In autorizaDetalleSA.ListadoAsegurableProducto(ID)
            dt.Rows.Add(i.IDAsegurable, i.nombre, i.descripcion, i.nombreProducto, i.idProducto)
        Next
        dgPerfilAutoriza.DataSource = dt
        'dgPerfilAutoriza.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        'dgPerfilAutoriza.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left

        dgPerfilAutoriza.TableDescriptor.Columns("Nombre").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        dgPerfilAutoriza.TableDescriptor.Columns("Nombre").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
        'dgPerfilAutoriza.TableDescriptor.GroupedColumns.Clear()
        'dgPerfilAutoriza.TableDescriptor.GroupedColumns.Add("modulo")
        'dgPerfilAutoriza.TableDescriptor.Columns("modulo").Width = 0
    End Sub
#End Region

#Region "Events"
    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Cursor = Cursors.WaitCursor
        GetAutorizacionesByRol(cboPErfil.SelectedValue)
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        frmModulos = New frmModalSistemas(cboPErfil.SelectedValue)
        frmModulos.tipo = "CLI"
        frmModulos.StartPosition = FormStartPosition.CenterParent
        frmModulos.ShowDialog()
        Dim c = CType(frmModulos.Tag, AutorizacionRol)
        'agregar fila al GGC
        dgPerfilAutoriza.Table.AddNewRecord.SetCurrent()
        dgPerfilAutoriza.Table.AddNewRecord.BeginEdit()
        dgPerfilAutoriza.Table.CurrentRecord.SetValue("IDAsegurable", c.IDAsegurable)
        dgPerfilAutoriza.Table.CurrentRecord.SetValue("Nombre", c.Nomasegurable)
        dgPerfilAutoriza.Table.CurrentRecord.SetValue("descripcion", c.EstaAutorizado)
        dgPerfilAutoriza.Table.CurrentRecord.SetValue("producto", cboPErfil.Text)
        dgPerfilAutoriza.Table.CurrentRecord.SetValue("idProducto", cboPErfil.SelectedValue)
        dgPerfilAutoriza.Table.CurrentRecord.SetValue("autoriza", True)
        dgPerfilAutoriza.Table.AddNewRecord.EndEdit()
        c.Action = BaseBE.EntityAction.INSERT
        c.IDRol = cboPErfil.SelectedValue
        c.UsuarioActualizacion = usuario.IDUsuario
        c.FechaActualizacion = Date.Now
        autorizaSA.InsertItem(c)
        GetAutorizacionesByRol(cboPErfil.SelectedValue)
    End Sub

    Private Sub dgPerfilAutoriza_TableControlCheckBoxClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs)
        Cursor = Cursors.WaitCursor
        Dim RowIndex As Integer = e.Inner.RowIndex
        Dim be As New AutorizacionRol

        If RowIndex > -1 Then
            e.TableControl.CurrentCell.EndEdit()
            e.TableControl.Table.TableDirty = True
            e.TableControl.Table.EndEdit()

            Dim valCheck = Me.dgPerfilAutoriza.TableModel(RowIndex, 4).CellValue
            Select Case valCheck
                Case "False" 'TRUE
                    '     MessageBox.Show(True)

                    'be.IDAsegurable = Me.dgPerfilAutoriza.TableModel(RowIndex, 1).CellValue
                    'be.IDRol = cboPErfil.SelectedValue
                    'be.EstaAutorizado = True
                    ''autorizaSA.GetUpdateAutorizacion(be)
                Case Else ' FALSE

                    '       MessageBox.Show(False)

                    'be.IDAsegurable = Me.dgPerfilAutoriza.TableModel(RowIndex, 1).CellValue
                    'be.IDRol = cboPErfil.SelectedValue
                    'be.EstaAutorizado = False
                    ''autorizaSA.GetUpdateAutorizacion(be)
            End Select
        End If
        Cursor = Cursors.Default
    End Sub

#End Region

    Private Sub cboPErfil_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPErfil.SelectedIndexChanged
        dgPerfilAutoriza.Table.Records.DeleteAll()
    End Sub
End Class