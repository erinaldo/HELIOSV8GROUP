Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Public Class frmEmpresaNumeracionInicio
#Region "Attributes"
    Public Property dt As DataTable
    Public Property objNumeracion As numeracionBoletas
    Public Property numeracionSA As New NumeracionBoletaSA
    Public Property listaNumeracion As List(Of numeracionBoletas)
    Public Property strEmpresa As String
#End Region

#Region "Constructors"
    Public Sub New(idEmpresa As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        LoadModulosNumeracion()
        strEmpresa = idEmpresa
    End Sub
#End Region

#Region "Methods"
    Sub Grabar()
        Dim numeracionBoleta As Integer = 1
        Dim estableSA As New establecimientoSA
        listaNumeracion = New List(Of numeracionBoletas)
        Dim conteoNumeracion As Integer = 1
        Dim lista = estableSA.ObtenerListaEstablecimientos(strEmpresa).Where(Function(O) O.TipoEstab = "UN").ToList

        'Dim unidad = lista.Where(Function(o) o.TipoEstab = "UN").FirstOrDefault

        For Each itemUnidad In lista

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
                                        .serie = CStr(r.GetValue("serie") & numeracionBoleta).PadRight(5, "0"c),
                                        .valorInicial = Decimal.Parse(r.GetValue("valorInicio").ToString),
                                        .empresa = strEmpresa,
                                        .establecimiento = itemUnidad.idCentroCosto,
                                        .valorMinimo = 0,
                                        .valorMaximo = numeracion,
                                        .incremento = 1,
                                        .descripcionModulo = r.GetValue("descripcion"),
                                        .usuarioActualizacion = "Jiu",
                                        .fechaActualizacion = Date.Now,
                                        .tipoModulo = r.GetValue("tipo"),
                                        .estado = "A"
                                    })

            Next


            numeracionBoleta += 1
        Next

        numeracionSA.InsertarNumeracionInicio(listaNumeracion, lista)
        listaNumeracion = New List(Of numeracionBoletas)

        MessageBox.Show("Lista de modulos grabado", "Grabado", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close()
    End Sub

    Sub LoadModulosNumeracion()
        dt = New DataTable
        dt.Columns.Add("codigo")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("tipodoc")
        dt.Columns.Add("serie")
        dt.Columns.Add("valorInicio")
        dt.Columns.Add("tipo")

        'COMPRAS
        'REQUERIMIENTO
        dt.Rows.Add("RC", "Requerimiento", "9901", "RC00", "0", "COMPRAS") ' FALTA VOCHER CONTABLE
        'COTIZACION
        dt.Rows.Add("CTZC", "Cotización de compras", "9901", "CTC0", "0", "COMPRAS") ' bien
        'ORDEN DE COMPRA
        dt.Rows.Add("OC", "Orden de Compras", "9903", "OC00", "0", "COMPRAS") ' BIEN
        'REGSTRO DE COMPRAS
        dt.Rows.Add("CP", "Registro de Compras", "9903", "CP00", "0", "COMPRAS") ' CREACION VERFIICAR
        'VOUCHER DE INGRESO A LAMCAEN
        dt.Rows.Add("VIA", "Voucher de Ingreso a Almacen", "9915", "VIA0", "0", "COMPRAS") ' CREACION VERFIICAR
        'OAT
        dt.Rows.Add("OAT", "OAT", "9901", "OAT0", "0", "COMPRAS") ' FALTA VOCHER CONTABLE
        'PRODUCCION
        dt.Rows.Add("PRL", "Producción", "9901", "PRL0", "0", "COMPRAS") ' FALTA VOCHER CONTABLE
        'TRANSFERENCIA ENTRE ALMACEN
        dt.Rows.Add("TEA", "Trasnferencia entre almacenes", "9901", "TEA0", "0", "COMPRAS") ' FALTA VOCHER CONTABLE

        'VENTA
        'PROFORMA
        dt.Rows.Add("PRF", "Proforma", "9901", "PF00", "0", "VENTAS") ' FALTA VOCHER CONTABLE
        'PEDIDO
        dt.Rows.Add("PDV", "Pedido", "9901", "PD00", "0", "VENTAS") ' FALTA VOCHER CONTABLE
        'GUIA DE REMISION
        dt.Rows.Add("GRV", "Guía de Remisión", "09", "GR00", "0", "VENTAS") ' GUIA DE REMISION REMITENTE
        'VOUCHER DE SALIDA A ALMACEN
        dt.Rows.Add("VSA", "Voucher de Salida de Almacen", "9914", "VSA0", "0", "VENTAS")
        'FACTURA ELECTRONICA
        dt.Rows.Add("VT3E", "Registro de venta factura electronica", "01", "FE00", "0", "VENTAS")
        'BOLETA ELECTRONICA
        dt.Rows.Add("VT2E", "Registro de venta boletas electronicas", "03", "BE00", "0", "VENTAS")
        'BOLETA FISICA
        dt.Rows.Add("VT2", "Registro de venta boletas", "03", "BF00", "0", "VENTAS")
        'FACTURA FISICA
        dt.Rows.Add("VT3", "Registro de venta factura", "01", "FF00", "0", "VENTAS")
        'NOTA DE VENTA
        dt.Rows.Add("NOTE", "Nota de venta", "9907", "NV00", "0", "VENTAS")
        'PRE VENTA
        dt.Rows.Add("PV", "Anticipos otorgados y recibidos", "1000", "PV00", "0", "VENTAS")
        'NOTA DE CREDITO
        dt.Rows.Add("NTC", "Registro de Notas de credito Electronico", "07", "FN00", "0", "VENTAS")
        'NOTA DE CREDITO 2
        dt.Rows.Add("NTCB", "Registro de Notas de credito Electronico", "07", "BN00", "0", "VENTAS")
        'RESUMEN DE BOLETA ELECTRONICA
        dt.Rows.Add("RSD", "Resumen Boletas Electronicas", "03", "RE00", "0", "VENTAS")
        'BAJAS
        dt.Rows.Add("BAJA", "Comunicacion Baja", "01", "CM00", "0", "VENTAS")
        ''ASIENTOS MANUALES
        dt.Rows.Add("GASTOS", "Asiento manuales", "9903", "AM", "0")
        'NOTA DE CREDITO ESPECIAL
        dt.Rows.Add("NCE", "Nota de credito especial", "87", "CE00", "0", "VENTAS")
        'PRESTAMOS  RECIBIDOS
        dt.Rows.Add("PTR", "Prestamos recibidos", "9903", "PR00", "0", "VENTAS")
        'PRESTAMOS OTORGADOS
        dt.Rows.Add("PTO", "Prestamos otorgados", "9903", "PO00", "0", "VENTAS")
        'OTRAS ENTRADAS DE ALMACEN
        dt.Rows.Add("OEA", "Otras Entradas de Almacen", "9903", "OEA0", "0", "VENTAS")


        'FINANZAS
        'OTRA ENTRADAS Y SALIDA DE CAJA
        dt.Rows.Add("OED", "Otras entradas de caja", "9901", "OE00", "0", "FINANZAS") ' SE PUSO VOUCHER CONTABLE
        'OTRA ENTRADAS Y SALIDA DE CAJA
        dt.Rows.Add("OSD", "Otras salidas de caja", "9901", "OS00", "0", "FINANZAS") ' SE PUSO VOUCHER CONTABLE
        'ANTCIPOS RECIBIDOS
        dt.Rows.Add("AR", "Anticipos recibidos", "9913", "AR00", "0", "FINANZAS") ' SE INSERTO TABLADETALE 9913
        'ANTCIPOS OTORGADOS
        dt.Rows.Add("AO", "Anticipos otorgados", "9913", "AO00", "0", "FINANZAS") ' SE INSERTO TABLADETALE 9913
        'VOUCHER DE CAJA
        dt.Rows.Add("VC", "Voucher de Caja", "9903", "VC00", "0", "FINANZAS") ' BEIN
        'TRANSFERENCIA DE DINERO
        dt.Rows.Add("TED", "Transferencia de Dinero", "9903", "TD00", "0", "FINANZAS") ' SE PUSO VOUCHER CONTABLE
        'CUENTAS X COBRAR
        dt.Rows.Add("CPC", "Cuentas x Cobrar", "9902", "CC00", "0", "FINANZAS") ' BIEN
        'CUENTAS X PAGAR
        dt.Rows.Add("CPP", "Cuentas x Pagar", "9902", "CP00", "0", "FINANZAS") ' BIEN

        dgvNumeracion.TableDescriptor.Columns.Add("codigo")
        dgvNumeracion.TableDescriptor.Columns.Add("descripcion")
        dgvNumeracion.TableDescriptor.Columns.Add("tipodoc")
        dgvNumeracion.TableDescriptor.Columns.Add("serie")
        dgvNumeracion.TableDescriptor.Columns.Add("valorInicio")
        dgvNumeracion.TableDescriptor.Columns.Add("tipo")

        dgvNumeracion.TableDescriptor.Columns("codigo").HeaderText = "Codigo"
        dgvNumeracion.TableDescriptor.Columns("codigo").MappingName = "codigo"
        dgvNumeracion.TableDescriptor.Columns("codigo").Name = "codigo"


        dgvNumeracion.TableDescriptor.Columns("descripcion").HeaderText = "Descripción"
        dgvNumeracion.TableDescriptor.Columns("descripcion").MappingName = "descripcion"
        dgvNumeracion.TableDescriptor.Columns("descripcion").Name = "descripcion"


        dgvNumeracion.TableDescriptor.Columns("tipodoc").HeaderText = "Comprobante"
        dgvNumeracion.TableDescriptor.Columns("tipodoc").MappingName = "tipodoc"
        dgvNumeracion.TableDescriptor.Columns("tipodoc").Name = "tipodoc"


        dgvNumeracion.TableDescriptor.Columns("serie").HeaderText = "Serie"
        dgvNumeracion.TableDescriptor.Columns("serie").MappingName = "serie"
        dgvNumeracion.TableDescriptor.Columns("serie").Name = "serie"

        dgvNumeracion.TableDescriptor.Columns("valorInicio").HeaderText = "Valor de inicio"
        dgvNumeracion.TableDescriptor.Columns("valorInicio").MappingName = "valorInicio"
        dgvNumeracion.TableDescriptor.Columns("valorInicio").Name = "valorInicio"

        dgvNumeracion.TableDescriptor.Columns("tipo").HeaderText = "tipo"
        dgvNumeracion.TableDescriptor.Columns("tipo").MappingName = "tipo"
        dgvNumeracion.TableDescriptor.Columns("tipo").Name = "tipo"

        dgvNumeracion.DataSource = dt

        dgvNumeracion.TableDescriptor.Columns("codigo").Width = 50
        dgvNumeracion.TableDescriptor.Columns("descripcion").Width = 250
        dgvNumeracion.TableDescriptor.Columns("tipodoc").Width = 85
        dgvNumeracion.TableDescriptor.Columns("serie").Width = 50
        dgvNumeracion.TableDescriptor.Columns("valorInicio").Width = 75
        dgvNumeracion.TableDescriptor.Columns("tipo").Width = 75
    End Sub
#End Region

#Region "Events"
    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        Grabar()
    End Sub

    Private Sub frmEmpresaNumeracionInicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
#End Region

End Class