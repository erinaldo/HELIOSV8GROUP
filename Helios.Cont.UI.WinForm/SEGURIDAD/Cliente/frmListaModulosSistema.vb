Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Helios.Seguridad.Business.Entity
Imports Helios.General
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid

Public Class frmListaModulosSistema

#Region "Attributes"
    Public Property AsegurableSA As New AsegurableSA
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridPequeño(dgAsegurables, True)
        'listaModulos("POS1")
        'GetAsegurables()
    End Sub
#End Region

#Region "Methods"

    'Private Sub listaModulos(tipoModulo As String)
    '    Dim listaModulos As New List(Of Integer)
    '    Select Case tipoModulo
    '        Case "POS1"

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

    '        Case "POS2"

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
    '        Case "POS3"

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
    '        Case "POS4"

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
    '    GetAsegurables(listaModulos)
    'End Sub

    Private Sub GetAsegurables()
        Dim dt As New DataTable("Asegurables")

        dt.Columns.Add(New DataColumn("IDAsegurable", GetType(Integer))) '0
        dt.Columns.Add(New DataColumn("IDCliente", GetType(String)))
        dt.Columns.Add(New DataColumn("CodAsegurable", GetType(String)))
        dt.Columns.Add(New DataColumn("Nombre", GetType(String))) '3
        dt.Columns.Add(New DataColumn("Descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("IDAsegurablePadre", GetType(Integer)))
        dt.Columns.Add(New DataColumn("CodRef", GetType(String))) '6
        dt.Columns.Add(New DataColumn("UsuarioActualizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("FechaActualizacion", GetType(String))) '8

        Dim str As String
        For Each i As Asegurable In AsegurableSA.GetAsegurableXidCliente(New Asegurable With {.IDEmpresa = Gempresas.IdEmpresaRuc})

            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.FechaActualizacion).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.IDAsegurable
            dr(1) = i.IDEmpresa
            dr(2) = i.CodAsegurable
            dr(3) = i.Nombre
            dr(4) = i.Descripcion
            dr(5) = i.IDAsegurablePadre.GetValueOrDefault
            dr(6) = i.CodRef
            dr(7) = i.UsuarioActualizacion
            dr(8) = str
            dt.Rows.Add(dr)
        Next
        dgAsegurables.DataSource = dt
    End Sub

    'Sub GetAsegurables()
    '    dgAsegurables.DataSource = AsegurableSA.ListadoAsegurables
    '    dgAsegurables.TableOptions.ListBoxSelectionMode = SelectionMode.One
    '    dgAsegurables.TableDescriptor.Columns("Nombre").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
    '    dgAsegurables.TableDescriptor.Columns("Nombre").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
    'End Sub
#End Region

#Region "Events"
    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        Cursor = Cursors.WaitCursor
        GetAsegurables()
        Cursor = Cursors.Default
    End Sub
#End Region


End Class