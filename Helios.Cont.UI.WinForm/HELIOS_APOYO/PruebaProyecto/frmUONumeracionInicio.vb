Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Public Class frmUONumeracionInicio
#Region "Attributes"
    Public Property dt As DataTable
    Public Property objNumeracion As numeracionBoletas
    Public Property numeracionSA As New NumeracionBoletaSA
    Public Property listaNumeracion As List(Of numeracionBoletas)
    Public Property strEmpresa As String
    Public Property intIdUnidOrg As Integer
#End Region

#Region "Constructors"
    Public Sub New(idEmpresa As String, IDcentroCostos As Integer, tipoUnidOrg As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        LoadModulosNumeracion(tipoUnidOrg)
        strEmpresa = idEmpresa
        intIdUnidOrg = IDcentroCostos
    End Sub
#End Region

#Region "Methods"
    Sub Grabar(IdUnidadOrganica As Integer)
        Dim numeracionBoleta As Integer = 1
        Dim estableSA As New establecimientoSA
        listaNumeracion = New List(Of numeracionBoletas)
        Dim conteoNumeracion As Integer = 1

        Dim numeracion As Long = 0

        For Each r In dgvNumeracion.Table.Records

            Select Case r.GetValue("codigo")
                Case "RSD", "BAJA"
                    numeracion = 99999
                Case Else
                    numeracion = 99999999
            End Select

            listaNumeracion.Add(New numeracionBoletas With
                                    {
                                        .codigoNumeracion = r.GetValue("codigo"),
                                        .tipo = r.GetValue("tipodoc"),
                                        .serie = CStr(r.GetValue("serie")),
                                        .valorInicial = Decimal.Parse(r.GetValue("valorInicio").ToString),
                                        .empresa = strEmpresa,
                                        .establecimiento = IdUnidadOrganica,
                                        .valorMinimo = 0,
                                        .valorMaximo = numeracion,
                                        .incremento = 1,
                                        .descripcionModulo = r.GetValue("descripcion"),
                                        .usuarioActualizacion = "ADMINISTRADOR",
                                        .fechaActualizacion = Date.Now,
                                        .tipoModulo = r.GetValue("tipo"),
                                        .estado = "A"
                                    })

        Next


        numeracionSA.InsertarNumeracionXUnidOrg(listaNumeracion)

        MessageBox.Show("Lista de modulos grabado", "Grabado", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close()
    End Sub

    Sub LoadModulosNumeracion(TIPO As String)
        dt = New DataTable
        dt.Columns.Add("codigo")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("tipodoc")
        dt.Columns.Add("serie")
        dt.Columns.Add("valorInicio")
        dt.Columns.Add("tipo")
        dt.Columns.Add("estado")


        Select Case TIPO
            Case "CM"
                'VENTA
                'PROFORMA
                dt.Rows.Add("CTZ", "Cotización", "9901", "CT0", "0", "VENTAS", True) ' FALTA VOCHER CONTABLE
                'PEDIDO
                dt.Rows.Add("PDV", "Pedido", "9901", "PD0", "0", "VENTAS", True) ' FALTA VOCHER CONTABLE
                'GUIA DE REMISION
                dt.Rows.Add("GRV", "Guía de Remisión", "09", "GR0", "0", "VENTAS", True) ' GUIA DE REMISION REMITENTE
                'VOUCHER DE SALIDA A ALMACEN
                dt.Rows.Add("VSA", "Voucher de Salida de Almacen", "9914", "VS0", "0", "VENTAS", True)
                'FACTURA ELECTRONICA
                dt.Rows.Add("VT3E", "Registro de venta factura electronica", "01", "F00", "0", "VENTAS", True)
                'BOLETA ELECTRONICA
                dt.Rows.Add("VT2E", "Registro de venta boletas electronicas", "03", "B00", "0", "VENTAS", True)
                'BOLETA FISICA
                dt.Rows.Add("VT2", "Registro de venta boletas", "03", "BF0", "0", "VENTAS", True)
                'FACTURA FISICA
                dt.Rows.Add("VT3", "Registro de venta factura", "01", "FF0", "0", "VENTAS", True)
                'NOTA DE VENTA
                dt.Rows.Add("NOTE", "Nota de venta", "9907", "NV0", "0", "VENTAS", True)
                'PRE VENTA
                dt.Rows.Add("PV", "Anticipos otorgados y recibidos", "1000", "PV0", "0", "VENTAS", True)
                'NOTA DE CREDITO
                dt.Rows.Add("NTC", "Registro de Notas de credito Electronico", "07", "FN0", "0", "VENTAS", True)
                'NOTA DE CREDITO 2
                dt.Rows.Add("NTCB", "Registro de Notas de credito Electronico", "07", "BN0", "0", "VENTAS", True)
                'RESUMEN DE BOLETA ELECTRONICA
                dt.Rows.Add("RSD", "Resumen Boletas Electronicas", "03", "RE0", "0", "VENTAS", True)
                'BAJAS
                dt.Rows.Add("BAJA", "Comunicacion Baja", "01", "CM0", "0", "VENTAS", True)
                ''ASIENTOS MANUALES
                dt.Rows.Add("GASTOS", "Asiento manuales", "9903", "AM0", "0", "VENTAS", True)
                'NOTA DE CREDITO ESPECIAL
                dt.Rows.Add("NCE", "Nota de credito especial", "87", "CE0", "0", "VENTAS", True)
                'PRESTAMOS  RECIBIDOS
                dt.Rows.Add("PTR", "Prestamos recibidos", "9903", "PR0", "0", "VENTAS", True)
                'PRESTAMOS OTORGADOS
                dt.Rows.Add("PTO", "Prestamos otorgados", "9903", "PO0", "0", "VENTAS", True)
                ''OTRAS ENTRADAS DE ALMACEN
                'dt.Rows.Add("OEA", "Otras Entradas de Almacen", "9903", "EA0", "0", "VENTAS", True)
                ''OTRAS SALIDAS DE ALMACEN
                'dt.Rows.Add("OEA", "Otras Entradas de Almacen", "9907", "SA0", "0", "VENTAS", True)

            Case "LG"
                'COMPRAS
                'REQUERIMIENTO
                dt.Rows.Add("RC", "Requerimiento", "9901", "RC0", "0", "COMPRAS", True) ' FALTA VOCHER CONTABLE
                'COTIZACION
                dt.Rows.Add("CTZC", "Cotización de compras", "9901", "OT0", "0", "COMPRAS", True) ' bien
                'ORDEN DE COMPRA
                dt.Rows.Add("OC", "Orden de Compras", "9903", "OC0", "0", "COMPRAS", True) ' BIEN
                'REGSTRO DE COMPRAS
                dt.Rows.Add("CP", "Registro de Compras", "9903", "CP0", "0", "COMPRAS", True) ' CREACION VERFIICAR
                'VOUCHER DE INGRESO A LAMCAEN
                dt.Rows.Add("VIA", "Voucher de Ingreso a Almacen", "9915", "VA0", "0", "COMPRAS", True) ' CREACION VERFIICAR
                'OAT
                dt.Rows.Add("OAT", "OAT", "9901", "OA0", "0", "COMPRAS", True) ' FALTA VOCHER CONTABLE
                'PRODUCCION
                dt.Rows.Add("PRL", "Producción", "9901", "PR0", "0", "COMPRAS", True) ' FALTA VOCHER CONTABLE
                'TRANSFERENCIA ENTRE ALMACEN
                dt.Rows.Add("TEA", "Trasnferencia entre almacenes", "9901", "TA0", "0", "COMPRAS", True) ' FALTA VOCHER CONTABLE
                'OTRAS ENTRDAS DE ALMACEN
                dt.Rows.Add("OEA", "Otras Entradas de Almacen", "9907", "EA0", "0", "COMPRAS", True)
                'OTRAS SALIDAS DE ALMACEN
                dt.Rows.Add("OSA", "Otras Salidas de Almacen", "9907", "SA0", "0", "COMPRAS", True)
                'GUIA DE REMISION
                dt.Rows.Add("GUIR", "Guía de Remisión", "09", "T00", "0", "COMPRAS", True)


            Case "FN"
                'FINANZAS
                'OTRA ENTRADAS Y SALIDA DE CAJA
                dt.Rows.Add("OED", "Otras entradas de caja", "9901", "OE0", "0", "FINANZAS", True) ' SE PUSO VOUCHER CONTABLE
                'OTRA ENTRADAS Y SALIDA DE CAJA
                dt.Rows.Add("OSD", "Otras salidas de caja", "9901", "OS0", "0", "FINANZAS", True) ' SE PUSO VOUCHER CONTABLE
                'ANTCIPOS RECIBIDOS
                dt.Rows.Add("AR", "Anticipos recibidos", "9913", "AR0", "0", "FINANZAS", True) ' SE INSERTO TABLADETALE 9913
                'ANTCIPOS OTORGADOS
                dt.Rows.Add("AO", "Anticipos otorgados", "9913", "AO0", "0", "FINANZAS", True) ' SE INSERTO TABLADETALE 9913
                'VOUCHER DE CAJA
                dt.Rows.Add("VC", "Voucher de Caja", "9903", "VC0", "0", "FINANZAS", True) ' BEIN
                'TRANSFERENCIA DE DINERO
                dt.Rows.Add("TED", "Transferencia de Dinero", "9903", "TD0", "0", "FINANZAS", True) ' SE PUSO VOUCHER CONTABLE
                'CUENTAS X COBRAR
                dt.Rows.Add("CPC", "Cuentas x Cobrar", "9902", "CC0", "0", "FINANZAS", True) ' BIEN
                'CUENTAS X PAGAR
                dt.Rows.Add("CPP", "Cuentas x Pagar", "9902", "CP0", "0", "FINANZAS", True) ' BIEN

            Case "RH"


            Case "TC"


            Case Else
                'COMPRAS
                'REQUERIMIENTO
                dt.Rows.Add("RC", "Requerimiento", "9901", "RC0", "0", "COMPRAS", True) ' FALTA VOCHER CONTABLE
                'COTIZACION
                dt.Rows.Add("CTZC", "Cotización de compras", "9901", "OT0", "0", "COMPRAS", True) ' bien
                'ORDEN DE COMPRA
                dt.Rows.Add("OC", "Orden de Compras", "9903", "OC0", "0", "COMPRAS", True) ' BIEN
                'REGSTRO DE COMPRAS
                dt.Rows.Add("CP", "Registro de Compras", "9903", "CP0", "0", "COMPRAS", True) ' CREACION VERFIICAR
                'VOUCHER DE INGRESO A LAMCAEN
                dt.Rows.Add("VIA", "Voucher de Ingreso a Almacen", "9915", "VA0", "0", "COMPRAS", True) ' CREACION VERFIICAR
                'OAT
                dt.Rows.Add("OAT", "OAT", "9901", "OA0", "0", "COMPRAS", True) ' FALTA VOCHER CONTABLE
                'PRODUCCION
                dt.Rows.Add("PRL", "Producción", "9901", "PR0", "0", "COMPRAS", True) ' FALTA VOCHER CONTABLE
                'TRANSFERENCIA ENTRE ALMACEN
                dt.Rows.Add("TEA", "Transferencia entre almacenes", "9901", "TA0", "0", "COMPRAS", True) ' FALTA VOCHER CONTABLE

                'OTRAS ENTRADAS DE ALMACEN
                dt.Rows.Add("OEA", "Otras Entradas de Almacen", "9907", "EA0", "0", "COMPRAS", True)
                'OTRAS SALIDAS DE ALMACEN
                dt.Rows.Add("OSA", "Otras Salidas de Almacen", "9907", "SA0", "0", "COMPRAS", True)
                'GUIA DE REMISION
                dt.Rows.Add("GUIR", "Guía de Remisión", "09", "T00", "0", "COMPRAS", True)


                'VENTA
                'PROFORMA
                dt.Rows.Add("CTZ", "Cotización", "9901", "CT0", "0", "VENTAS", True) ' FALTA VOCHER CONTABLE
                'PEDIDO
                dt.Rows.Add("PDV", "Pedido", "9901", "PD0", "0", "VENTAS", True) ' FALTA VOCHER CONTABLE
                'GUIA DE REMISION
                dt.Rows.Add("GRV", "Guía de Remisión", "09", "GR0", "0", "VENTAS", True) ' GUIA DE REMISION REMITENTE
                'VOUCHER DE SALIDA A ALMACEN
                dt.Rows.Add("VSA", "Voucher de Salida de Almacen", "9914", "VS0", "0", "VENTAS", True)
                'FACTURA ELECTRONICA
                dt.Rows.Add("VT3E", "Registro de venta factura electronica", "01", "F00", "0", "VENTAS", True)
                'BOLETA ELECTRONICA
                dt.Rows.Add("VT2E", "Registro de venta boletas electronicas", "03", "B00", "0", "VENTAS", True)
                'BOLETA FISICA
                dt.Rows.Add("VT2", "Registro de venta boletas", "03", "BF0", "0", "VENTAS", True)
                'FACTURA FISICA
                dt.Rows.Add("VT3", "Registro de venta factura", "01", "FF0", "0", "VENTAS", True)
                'NOTA DE VENTA
                dt.Rows.Add("NOTE", "Nota de venta", "9907", "NV0", "0", "VENTAS", True)
                'PRE VENTA
                dt.Rows.Add("PV", "Anticipos otorgados y recibidos", "1000", "PV0", "0", "VENTAS", True)
                'NOTA DE CREDITO
                dt.Rows.Add("NTC", "Registro de Notas de credito Electronico", "07", "FN0", "0", "VENTAS", True)
                'NOTA DE CREDITO 2
                dt.Rows.Add("NTCB", "Registro de Notas de credito Electronico", "07", "BN0", "0", "VENTAS", True)
                'RESUMEN DE BOLETA ELECTRONICA
                dt.Rows.Add("RSD", "Resumen Boletas Electronicas", "03", "RE0", "0", "VENTAS", True)
                'BAJAS
                dt.Rows.Add("BAJA", "Comunicacion Baja", "01", "CM0", "0", "VENTAS", True)
                ''ASIENTOS MANUALES
                dt.Rows.Add("GASTOS", "Asiento manuales", "9903", "AM0", "0", "VENTAS", True)
                'NOTA DE CREDITO ESPECIAL
                dt.Rows.Add("NCE", "Nota de credito especial", "87", "CE0", "0", "VENTAS", True)
                'PRESTAMOS  RECIBIDOS
                dt.Rows.Add("PTR", "Prestamos recibidos", "9903", "PR0", "0", "VENTAS", True)
                'PRESTAMOS OTORGADOS
                dt.Rows.Add("PTO", "Prestamos otorgados", "9903", "PO0", "0", "VENTAS", True)


                'FINANZAS
                'OTRA ENTRADAS Y SALIDA DE CAJA
                dt.Rows.Add("OED", "Otras entradas de caja", "9901", "OE0", "0", "FINANZAS", True) ' SE PUSO VOUCHER CONTABLE
                'OTRA ENTRADAS Y SALIDA DE CAJA
                dt.Rows.Add("OSD", "Otras salidas de caja", "9901", "OS0", "0", "FINANZAS", True) ' SE PUSO VOUCHER CONTABLE
                'ANTCIPOS RECIBIDOS
                dt.Rows.Add("AR", "Anticipos recibidos", "9913", "AR0", "0", "FINANZAS", True) ' SE INSERTO TABLADETALE 9913
                'ANTCIPOS OTORGADOS
                dt.Rows.Add("AO", "Anticipos otorgados", "9913", "AO0", "0", "FINANZAS", True) ' SE INSERTO TABLADETALE 9913
                'VOUCHER DE CAJA
                dt.Rows.Add("VC", "Voucher de Caja", "9903", "VC0", "0", "FINANZAS", True) ' BEIN
                'TRANSFERENCIA DE DINERO
                dt.Rows.Add("TED", "Transferencia de Dinero", "9903", "TD0", "0", "FINANZAS", True) ' SE PUSO VOUCHER CONTABLE
                'CUENTAS X COBRAR
                dt.Rows.Add("CPC", "Cuentas x Cobrar", "9902", "CC0", "0", "FINANZAS", True) ' BIEN
                'CUENTAS X PAGAR
                dt.Rows.Add("CPP", "Cuentas x Pagar", "9902", "CP0", "0", "FINANZAS", True) ' BIEN

        End Select



        'dgvNumeracion.TableDescriptor.Columns.Add("codigo")
        'dgvNumeracion.TableDescriptor.Columns.Add("descripcion")
        'dgvNumeracion.TableDescriptor.Columns.Add("tipodoc")
        'dgvNumeracion.TableDescriptor.Columns.Add("serie")
        'dgvNumeracion.TableDescriptor.Columns.Add("valorInicio")
        'dgvNumeracion.TableDescriptor.Columns.Add("tipo")

        'dgvNumeracion.TableDescriptor.Columns("codigo").HeaderText = "Codigo"
        'dgvNumeracion.TableDescriptor.Columns("codigo").MappingName = "codigo"
        'dgvNumeracion.TableDescriptor.Columns("codigo").Name = "codigo"


        'dgvNumeracion.TableDescriptor.Columns("descripcion").HeaderText = "Descripción"
        'dgvNumeracion.TableDescriptor.Columns("descripcion").MappingName = "descripcion"
        'dgvNumeracion.TableDescriptor.Columns("descripcion").Name = "descripcion"


        'dgvNumeracion.TableDescriptor.Columns("tipodoc").HeaderText = "Comprobante"
        'dgvNumeracion.TableDescriptor.Columns("tipodoc").MappingName = "tipodoc"
        'dgvNumeracion.TableDescriptor.Columns("tipodoc").Name = "tipodoc"


        'dgvNumeracion.TableDescriptor.Columns("serie").HeaderText = "Serie"
        'dgvNumeracion.TableDescriptor.Columns("serie").MappingName = "serie"
        'dgvNumeracion.TableDescriptor.Columns("serie").Name = "serie"

        'dgvNumeracion.TableDescriptor.Columns("valorInicio").HeaderText = "Valor de inicio"
        'dgvNumeracion.TableDescriptor.Columns("valorInicio").MappingName = "valorInicio"
        'dgvNumeracion.TableDescriptor.Columns("valorInicio").Name = "valorInicio"

        'dgvNumeracion.TableDescriptor.Columns("tipo").HeaderText = "tipo"
        'dgvNumeracion.TableDescriptor.Columns("tipo").MappingName = "tipo"
        'dgvNumeracion.TableDescriptor.Columns("tipo").Name = "tipo"

        dgvNumeracion.DataSource = dt

        'dgvNumeracion.TableDescriptor.Columns("codigo").Width = 50
        'dgvNumeracion.TableDescriptor.Columns("descripcion").Width = 250
        'dgvNumeracion.TableDescriptor.Columns("tipodoc").Width = 85
        'dgvNumeracion.TableDescriptor.Columns("serie").Width = 50
        'dgvNumeracion.TableDescriptor.Columns("valorInicio").Width = 75
        'dgvNumeracion.TableDescriptor.Columns("tipo").Width = 75
    End Sub
#End Region

#Region "Events"
    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        Grabar(intIdUnidOrg)
    End Sub

    Private Sub frmEmpresaNumeracionInicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
#End Region

End Class