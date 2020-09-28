Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports System.Collections
Imports System.Collections.Specialized
Imports Syncfusion.Windows.Forms.Tools

Public Class frmCronogramaPagos

    Inherits frmMaster

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        'configuracionModulo(Gempresas.IdEmpresaRuc, "GASTOS", Me.Text)
        'Loadcontroles()
        ' txtTipoCambio.Value = TmpTipoCambio
        ' cboMoneda.SelectedValue = "1"
        GetTableGrid()
        GetTableGrid2()
        ' LoadCombos()
        'GridCFG2(dgvMovimientos)
        'If Not lblIdDocumento.Text = "00" Then
        '    UbicarDocumento(CInt(lblIdDocumento.Text))
        'End If
        ' Add any initialization after the InitializeComponent() call.
        ' txtFecha.Value = DateTime.Now
        txtPeriodo.Value = PeriodoGeneral
    End Sub




#Region "Metodos"


    'Private Sub GenerarDocumento()

    '    Dim dt As New DataTable
    '    'Dim validar As String

    '    'Dim monto As Decimal = CDec(0.0)
    '    'Dim montome As Decimal = CDec(0.0)

    '    'Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year

    '    dt.Columns.Add("idDocumento", GetType(Integer))
    '    dt.Columns.Add("fechaOper", GetType(Date))
    '    dt.Columns.Add("idProveedor", GetType(Integer))
    '    dt.Columns.Add("nombreProv", GetType(String))
    '    dt.Columns.Add("tipodoc", GetType(String))
    '    dt.Columns.Add("nro", GetType(String))
    '    dt.Columns.Add("compraMN", GetType(Decimal))
    '    dt.Columns.Add("monedaCompra", GetType(String))
    '    dt.Columns.Add("compraME", GetType(Decimal))
    '    dt.Columns.Add("moneda", GetType(String))
    '    dt.Columns.Add("tipoCambio", GetType(Decimal))
    '    dt.Columns.Add("montoPactadoMN", GetType(Decimal))
    '    dt.Columns.Add("montoPactadoME", GetType(Decimal))
    '    dt.Columns.Add("userResponsable", GetType(String))
    '    dt.Columns.Add("tipoCC", GetType(Decimal))
    '    dt.Columns.Add("chBonif", GetType(Boolean))
    '    dt.Columns.Add("val", GetType(String))
    '    dt.Columns.Add("glosa", GetType(String))
    '    dt.Columns.Add("tipoProv", GetType(String))


    '    For Each i As Record In dgvProcesoCrono.Table.Records

    '        If i.GetValue("val") = "S" Then

    '            Dim dr As DataRow = dt.NewRow()

    '            dr(0) = i.GetValue("idDocumento")
    '            dr(1) = DateTime.Now
    '            dr(2) = i.GetValue("idProveedor")
    '            dr(3) = i.GetValue("nombreProv")
    '            dr(4) = i.GetValue("tipodoc")
    '            dr(5) = i.GetValue("nro")
    '            dr(6) = i.GetValue("compraMN")
    '            dr(7) = "1"
    '            dr(8) = i.GetValue("compraME")
    '            dr(9) = i.GetValue("moneda")
    '            dr(10) = i.GetValue("tipoCambio")
    '            dr(11) = i.GetValue("montoPactadoMN")
    '            dr(12) = i.GetValue("montoPactadoME")
    '            dr(13) = ""
    '            dr(14) = TmpIGV
    '            dr(15) = True
    '            dr(16) = "S"
    '            dr(17) = i.GetValue("glosa")
    '            dr(18) = i.GetValue("tipoProv")


    '            dt.Rows.Add(dr)
    '        End If
    '    Next

    '    'txtImporteMN.Value = monto
    '    'txtImporteME.Value = montome

    '    GridGroupingControl1.DataSource = dt



    'End Sub

    Private Sub UbicarCobrosTodo(intMoneda As String)
        Dim documentoVentaSA As New documentoVentaAbarrotesSA
        Dim documentoVenta As New List(Of documentoventaAbarrotes)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable

        Dim documentolibroSA As New documentoLibroDiarioSA
        Dim documentoLibro As New List(Of documentoLibroDiarioDetalle)
        Dim entidadSA As New entidadSA
        Dim personaSA As New PersonaSA
        Dim cuentaSA As New cuentaplanContableEmpresaSA

        ' lstConceptos.Items.Clear()
        Dim monto As Decimal = CDec(0.0)
        Dim montome As Decimal = CDec(0.0)
        Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("fechaOper", GetType(Date))
        dt.Columns.Add("idProveedor", GetType(Integer))
        dt.Columns.Add("nombreProv", GetType(String))

        dt.Columns.Add("compraMN", GetType(Decimal))

        dt.Columns.Add("compraME", GetType(Decimal))
        dt.Columns.Add("moneda", GetType(String))

        dt.Columns.Add("montoPactadoMN", GetType(Decimal))
        dt.Columns.Add("montoPactadoME", GetType(Decimal))

        dt.Columns.Add("glosa", GetType(String))
        dt.Columns.Add("tipoProv", GetType(String))
        dt.Columns.Add("tipo", GetType(String))


        documentoVenta = documentoVentaSA.UbicarCobrosPorTodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, intMoneda)
        'Dim str As String
        If Not IsNothing(documentoVenta) Then
            For Each i In documentoVenta
                Dim dr As DataRow = dt.NewRow()

                dr(0) = 1
                dr(1) = DateTime.Now
                dr(2) = i.idCliente
                dr(3) = i.NombreEntidad

                If IsNumeric(i.ImporteNacional) Then

                    dr(4) = i.ImporteNacional

                Else
                    dr(4) = CDec(0)

                End If

                If IsNumeric(i.ImporteExtranjero) Then

                    dr(5) = i.ImporteExtranjero

                Else
                    dr(5) = CDec(0)

                End If

                dr(6) = i.moneda
                dr(7) = CDec(0.0)
                dr(8) = CDec(0.0)

                dr(9) = "Por cobrar a cliente"
                dr(10) = "PR"
                dr(11) = "Cobro"
                dt.Rows.Add(dr)
            Next

        Else


        End If

        '(/////

        documentoLibro = documentolibroSA.UbicarCobroModulosTodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
        Dim str As String
        If Not IsNothing(documentoLibro) Then


            For Each i In documentoLibro
                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.fecha).ToString("dd-MMM hh:mm tt ")

                dr(0) = 1
                dr(1) = DateTime.Now


                If IsNothing(i.razonSocial) Then

                Else

                    Select Case i.tipoRazon
                        Case TIPO_ENTIDAD.PROVEEDOR
                            dr(2) = i.razonSocial
                            With entidadSA.UbicarEntidadPorID(i.razonSocial).First
                                dr(3) = .nombreCompleto
                            End With
                        Case TIPO_ENTIDAD.CLIENTE
                            dr(2) = i.razonSocial
                            With entidadSA.UbicarEntidadPorID(i.razonSocial).First
                                dr(3) = .nombreCompleto
                            End With
                        Case "TR"
                            dr(2) = i.razonSocial
                            With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.razonSocial, "TR")
                                dr(3) = .nombreCompleto
                            End With
                    End Select
                End If


                dr(4) = i.importeMN

                dr(5) = i.importeME

                dr(6) = "1"
                dr(7) = CDec(0.0)
                dr(8) = CDec(0.0)

                ' dr(9) = i.cuenta
                dr(9) = cuentaSA.ObtenerCuentaPorID(Gempresas.IdEmpresaRuc, i.cuenta).descripcion

                If IsNothing(i.razonSocial) Then

                Else
                    dr(10) = i.tipoRazon
                End If

                dr(11) = "Cobro"

                dt.Rows.Add(dr)
            Next
        End If
        '///////7



        dgvProcesoCrono.DataSource = dt
        Me.dgvProcesoCrono.TableOptions.ListBoxSelectionMode = SelectionMode.One

    End Sub


    Private Sub UbicarPagosTodo(intMoneda As String)
        Dim documentoVentaSA As New DocumentoCompraSA
        Dim documentoVenta As New List(Of documentocompra)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable

        Dim documentolibroSA As New documentoLibroDiarioSA
        Dim documentoLibro As New List(Of documentoLibroDiarioDetalle)
        Dim entidadSA As New entidadSA
        Dim personaSA As New PersonaSA
        Dim cuentaSA As New cuentaplanContableEmpresaSA



        ' lstConceptos.Items.Clear()
        Dim monto As Decimal = CDec(0.0)
        Dim montome As Decimal = CDec(0.0)
        Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("fechaOper", GetType(Date))
        dt.Columns.Add("idProveedor", GetType(Integer))
        dt.Columns.Add("nombreProv", GetType(String))
        'dt.Columns.Add("tipodoc", GetType(String))
        'dt.Columns.Add("nro", GetType(String))
        dt.Columns.Add("compraMN", GetType(Decimal))
        'dt.Columns.Add("monedaCompra", GetType(String))
        dt.Columns.Add("compraME", GetType(Decimal))
        dt.Columns.Add("moneda", GetType(String))
        ' dt.Columns.Add("tipoCambio", GetType(Decimal))
        dt.Columns.Add("montoPactadoMN", GetType(Decimal))
        dt.Columns.Add("montoPactadoME", GetType(Decimal))
        ' dt.Columns.Add("userResponsable", GetType(String))
        'dt.Columns.Add("tipoCC", GetType(Decimal))
        ' dt.Columns.Add("chBonif", GetType(Boolean))
        ' dt.Columns.Add("val", GetType(String))
        dt.Columns.Add("glosa", GetType(String))
        dt.Columns.Add("tipoProv", GetType(String))
        dt.Columns.Add("tipo", GetType(String))
        'dgvProcesoCrono.TableDescriptor.Columns(4).Width = 0
        'dgvProcesoCrono.TableDescriptor.Columns(5).Width = 0
        'dgvProcesoCrono.TableDescriptor.Columns(17).Width = 0

        documentoVenta = documentoVentaSA.UbicarPagosPorTodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, intMoneda)
        'Dim str As String
        If Not IsNothing(documentoVenta) Then
            For Each i In documentoVenta
                Dim dr As DataRow = dt.NewRow()
                'str = Nothing
                'str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
                dr(0) = 1
                dr(1) = DateTime.Now
                dr(2) = i.idProveedor
                dr(3) = i.NombreEntidad
                'dr(4) = "V"
                'dr(5) = "11"
                If IsNumeric(i.importeTotal) Then

                    dr(4) = i.importeTotal

                    ' monto += i.importeTotal
                Else
                    dr(4) = CDec(0)
                    'monto += CDec(0)
                End If
                'dr(7) = "1"
                If IsNumeric(i.importeUS) Then

                    dr(5) = i.importeUS
                    'montome += i.importeUS
                Else
                    dr(5) = CDec(0)
                    'montome += CDec(0)
                End If

                dr(6) = i.monedaDoc
                dr(7) = CDec(0.0)
                dr(8) = CDec(0.0)
                'dr(12) = CDec(0.0)
                'dr(13) = ""
                'dr(14) = TmpIGV
                'dr(15) = False
                'dr(16) = "N"
                dr(9) = "Por pago a proveedor"
                dr(10) = "PR"
                dr(11) = "Pago"
                dt.Rows.Add(dr)
            Next

            'Dim n As New ListViewItem(1)
            'n.SubItems.Add("PAGO A PROVEEDORES")
            'n.SubItems.Add(monto)
            'n.SubItems.Add(montome)
            'lstConceptos.Items.Add(n)








            'dgvProcesoCrono.DataSource = dt
            'Me.dgvProcesoCrono.TableOptions.ListBoxSelectionMode = SelectionMode.One
        Else


        End If

        '(/////

        documentoLibro = documentolibroSA.UbicarPagoModulosTodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
        Dim str As String
        If Not IsNothing(documentoLibro) Then


            For Each i In documentoLibro
                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.fecha).ToString("dd-MMM hh:mm tt ")



                dr(0) = 1
                dr(1) = DateTime.Now
                'dr(2) = i.idProveedor
                'dr(3) = i.NombreEntidad

                If IsNothing(i.razonSocial) Then

                Else

                    Select Case i.tipoRazon
                        Case TIPO_ENTIDAD.PROVEEDOR
                            dr(2) = i.razonSocial
                            With entidadSA.UbicarEntidadPorID(i.razonSocial).First
                                dr(3) = .nombreCompleto
                            End With
                        Case TIPO_ENTIDAD.CLIENTE
                            dr(2) = i.razonSocial
                            With entidadSA.UbicarEntidadPorID(i.razonSocial).First
                                dr(3) = .nombreCompleto
                            End With
                        Case "TR"
                            dr(2) = i.razonSocial
                            With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.razonSocial, "TR")
                                dr(3) = .nombreCompleto
                            End With
                    End Select
                End If



                'dr(4) = "VC"
                ''dr(5) = i.nroDoc
                'dr(5) = "1"

                dr(4) = i.importeMN
                'If i.tipoAsiento = "D" Then
                '    dr(6) = ((i.importeMN) * -1)

                'Else
                '    dr(6) = i.importeMN
                '    monto += i.importeMN
                'End If


                'dr(7) = "1"
                dr(5) = i.importeME
                'If IsNumeric(i.importeME) Then

                '    dr(8) = i.importeME
                '    montome += i.importeME
                'Else
                '    dr(8) = CDec(0)

                'End If

                ' dr(9) = i.moneda
                dr(6) = "1"
                dr(7) = CDec(0.0)
                dr(8) = CDec(0.0)
                'dr(12) = CDec(0.0)
                'dr(13) = ""
                'dr(14) = TmpIGV
                'dr(15) = False
                'dr(16) = "N"
                'dr(17) = i.informacionReferencial


                'dr(9) = i.cuenta
                dr(9) = cuentaSA.ObtenerCuentaPorID(Gempresas.IdEmpresaRuc, i.cuenta).descripcion

                If IsNothing(i.razonSocial) Then

                Else
                    dr(10) = i.tipoRazon
                End If

                dr(11) = "Pago"

                dt.Rows.Add(dr)
            Next
        End If
        '///////7



        dgvProcesoCrono.DataSource = dt
        Me.dgvProcesoCrono.TableOptions.ListBoxSelectionMode = SelectionMode.One

    End Sub






    Public Sub CargarEntidadesXtipo(strTipo As String, strBusqueda As String)
        Dim entidadSA As New entidadSA
        Try
            lsvProveedor.Items.Clear()
            For Each i As entidad In entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, strTipo, strBusqueda)
                Dim n As New ListViewItem(i.idEntidad)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(i.cuentaAsiento)
                n.SubItems.Add(i.nrodoc)
                lsvProveedor.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub





    Private Sub Cobrosmodulos(cuenta As String)
        Dim documentoVentaSA As New documentoLibroDiarioSA
        Dim documentoLibro As New List(Of documentoLibroDiarioDetalle)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        Dim entidadSA As New entidadSA
        Dim personaSA As New PersonaSA
        Dim monto As Decimal = CDec(0.0)
        Dim montome As Decimal = CDec(0.0)
        'Dim descripcion As String

        ' lstConceptos.Items.Clear()
        Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("fechaOper", GetType(Date))
        dt.Columns.Add("idProveedor", GetType(Integer))
        dt.Columns.Add("nombreProv", GetType(String))
        'dt.Columns.Add("tipodoc", GetType(String))
        'dt.Columns.Add("nro", GetType(String))
        dt.Columns.Add("compraMN", GetType(Decimal))
        'dt.Columns.Add("monedaCompra", GetType(String))
        dt.Columns.Add("compraME", GetType(Decimal))
        dt.Columns.Add("moneda", GetType(String))
        ' dt.Columns.Add("tipoCambio", GetType(Decimal))
        dt.Columns.Add("montoPactadoMN", GetType(Decimal))
        dt.Columns.Add("montoPactadoME", GetType(Decimal))
        ' dt.Columns.Add("userResponsable", GetType(String))
        'dt.Columns.Add("tipoCC", GetType(Decimal))
        ' dt.Columns.Add("chBonif", GetType(Boolean))
        ' dt.Columns.Add("val", GetType(String))
        dt.Columns.Add("glosa", GetType(String))
        dt.Columns.Add("tipoProv", GetType(String))
        dt.Columns.Add("tipo", GetType(String))
        'dgvProcesoCrono.TableDescriptor.Columns(4).Width = 70
        'dgvProcesoCrono.TableDescriptor.Columns(5).Width = 70
        'dgvProcesoCrono.TableDescriptor.Columns(17).Width = 140


        documentoLibro = documentoVentaSA.UbicarCobroModulos(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, cuenta, strPeriodo)
        Dim str As String
        If Not IsNothing(documentoLibro) Then


            For Each i In documentoLibro
                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.fecha).ToString("dd-MMM hh:mm tt ")
                'dr(0) = i.idDocumento
                'dr(1) = str
                'dr(2) = i.cuenta
                'dr(3) = i.descripcion

                'descripcion = i.descripcion

                'dr(5) = "VC"
                'dr(6) = "1"
                'dr(7) = i.nroDoc
                'Select Case i.moneda
                '    Case 1
                '        dr(8) = "NAC"
                '    Case Else
                '        dr(8) = "EXT"
                'End Select


                'If i.tipoAsiento = "D" Then
                '    dr(9) = ((i.importeMN) * -1)
                'Else
                '    dr(9) = i.importeMN
                'End If

                'dr(10) = CDec(3.33)
                'dr(11) = i.importeME
                'dr(12) = CDec(0)
                'dr(13) = CDec(0)
                'dr(14) = CDec(0)
                'dr(15) = CDec(0)

                'Select Case i.estadoPago
                '    Case TIPO_COMPRA.PAGO.PAGADO
                '        dr(16) = "Saldado"
                '    Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                '        dr(16) = "Pendiente"
                'End Select

                'dr(17) = i.informacionReferencial



                dr(0) = 1
                dr(1) = DateTime.Now
                'dr(2) = i.idProveedor
                'dr(3) = i.NombreEntidad

                If IsNothing(i.razonSocial) Then

                Else

                    Select Case i.tipoRazon
                        Case TIPO_ENTIDAD.PROVEEDOR
                            dr(2) = i.razonSocial
                            With entidadSA.UbicarEntidadPorID(i.razonSocial).First
                                dr(3) = .nombreCompleto
                            End With
                        Case TIPO_ENTIDAD.CLIENTE
                            dr(2) = i.razonSocial
                            With entidadSA.UbicarEntidadPorID(i.razonSocial).First
                                dr(3) = .nombreCompleto
                            End With
                        Case "TR"
                            dr(2) = i.razonSocial
                            With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.razonSocial, "TR")
                                dr(3) = .nombreCompleto
                            End With
                    End Select
                End If



                'dr(4) = "VC"
                'dr(5) = i.nroDoc
                'If IsNumeric(i.importeTotal) Then

                '    dr(6) = i.importeTotal
                'Else
                '    dr(6) = CDec(0)
                'End If

                If i.tipoAsiento = "H" Then
                    dr(4) = ((i.importeMN) * -1)

                Else
                    dr(4) = i.importeMN
                    'monto += i.importeMN
                End If


                'dr(7) = "1"
                If IsNumeric(i.importeME) Then

                    dr(5) = i.importeME
                    'montome += i.importeME
                Else
                    dr(5) = CDec(0)

                End If

                dr(6) = i.moneda
                dr(7) = CDec(0.0)
                dr(8) = CDec(0.0)
                'dr(12) = CDec(0.0)
                'dr(13) = ""
                'dr(14) = TmpIGV
                'dr(15) = False
                'dr(16) = "N"
                'dr(9) = i.informacionReferencial
                dr(9) = i.descripcion

                If IsNothing(i.razonSocial) Then

                Else
                    dr(10) = i.tipoRazon
                End If

                dr(11) = "Cobro"

                dt.Rows.Add(dr)
            Next

            dgvProcesoCrono.DataSource = dt
            Me.dgvProcesoCrono.TableOptions.ListBoxSelectionMode = SelectionMode.One





            'Dim n As New ListViewItem(1)
            'n.SubItems.Add(ComboBox1.Text)
            'n.SubItems.Add(monto)
            'n.SubItems.Add(montome)
            'lstConceptos.Items.Add(n)



        Else

        End If
    End Sub



    Private Sub pagosmodulos(cuenta As String)
        Dim documentoVentaSA As New documentoLibroDiarioSA
        Dim documentoLibro As New List(Of documentoLibroDiarioDetalle)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        Dim entidadSA As New entidadSA
        Dim personaSA As New PersonaSA
        Dim monto As Decimal = CDec(0.0)
        Dim montome As Decimal = CDec(0.0)
        'Dim descripcion As String

        ' lstConceptos.Items.Clear()
        Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("fechaOper", GetType(Date))
        dt.Columns.Add("idProveedor", GetType(Integer))
        dt.Columns.Add("nombreProv", GetType(String))
        'dt.Columns.Add("tipodoc", GetType(String))
        'dt.Columns.Add("nro", GetType(String))
        dt.Columns.Add("compraMN", GetType(Decimal))
        'dt.Columns.Add("monedaCompra", GetType(String))
        dt.Columns.Add("compraME", GetType(Decimal))
        dt.Columns.Add("moneda", GetType(String))
        ' dt.Columns.Add("tipoCambio", GetType(Decimal))
        dt.Columns.Add("montoPactadoMN", GetType(Decimal))
        dt.Columns.Add("montoPactadoME", GetType(Decimal))
        ' dt.Columns.Add("userResponsable", GetType(String))
        'dt.Columns.Add("tipoCC", GetType(Decimal))
        ' dt.Columns.Add("chBonif", GetType(Boolean))
        ' dt.Columns.Add("val", GetType(String))
        dt.Columns.Add("glosa", GetType(String))
        dt.Columns.Add("tipoProv", GetType(String))
        dt.Columns.Add("tipo", GetType(String))
        'dgvProcesoCrono.TableDescriptor.Columns(4).Width = 70
        'dgvProcesoCrono.TableDescriptor.Columns(5).Width = 70
        'dgvProcesoCrono.TableDescriptor.Columns(17).Width = 140


        documentoLibro = documentoVentaSA.UbicarPagoModulos(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, cuenta, strPeriodo)
        Dim str As String
        If Not IsNothing(documentoLibro) Then


            For Each i In documentoLibro
                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.fecha).ToString("dd-MMM hh:mm tt ")
                'dr(0) = i.idDocumento
                'dr(1) = str
                'dr(2) = i.cuenta
                'dr(3) = i.descripcion

                'descripcion = i.descripcion

                'dr(5) = "VC"
                'dr(6) = "1"
                'dr(7) = i.nroDoc
                'Select Case i.moneda
                '    Case 1
                '        dr(8) = "NAC"
                '    Case Else
                '        dr(8) = "EXT"
                'End Select


                'If i.tipoAsiento = "D" Then
                '    dr(9) = ((i.importeMN) * -1)
                'Else
                '    dr(9) = i.importeMN
                'End If

                'dr(10) = CDec(3.33)
                'dr(11) = i.importeME
                'dr(12) = CDec(0)
                'dr(13) = CDec(0)
                'dr(14) = CDec(0)
                'dr(15) = CDec(0)

                'Select Case i.estadoPago
                '    Case TIPO_COMPRA.PAGO.PAGADO
                '        dr(16) = "Saldado"
                '    Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                '        dr(16) = "Pendiente"
                'End Select

                'dr(17) = i.informacionReferencial



                dr(0) = 1
                dr(1) = DateTime.Now
                'dr(2) = i.idProveedor
                'dr(3) = i.NombreEntidad

                If IsNothing(i.razonSocial) Then

                Else

                    Select Case i.tipoRazon
                        Case TIPO_ENTIDAD.PROVEEDOR
                            dr(2) = i.razonSocial
                            With entidadSA.UbicarEntidadPorID(i.razonSocial).First
                                dr(3) = .nombreCompleto
                            End With
                        Case TIPO_ENTIDAD.CLIENTE
                            dr(2) = i.razonSocial
                            With entidadSA.UbicarEntidadPorID(i.razonSocial).First
                                dr(3) = .nombreCompleto
                            End With
                        Case "TR"
                            dr(2) = i.razonSocial
                            With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.razonSocial, "TR")
                                dr(3) = .nombreCompleto
                            End With
                    End Select
                End If



                'dr(4) = "VC"
                'dr(5) = i.nroDoc
                'If IsNumeric(i.importeTotal) Then

                '    dr(6) = i.importeTotal
                'Else
                '    dr(6) = CDec(0)
                'End If

                If i.tipoAsiento = "D" Then
                    dr(4) = ((i.importeMN) * -1)

                Else
                    dr(4) = i.importeMN
                    'monto += i.importeMN
                End If


                'dr(7) = "1"
                If IsNumeric(i.importeME) Then

                    dr(5) = i.importeME
                    'montome += i.importeME
                Else
                    dr(5) = CDec(0)

                End If

                dr(6) = i.moneda
                dr(7) = CDec(0.0)
                dr(8) = CDec(0.0)
                'dr(12) = CDec(0.0)
                'dr(13) = ""
                'dr(14) = TmpIGV
                'dr(15) = False
                'dr(16) = "N"

                'dr(9) = i.informacionReferencial
                dr(9) = i.descripcion
                If IsNothing(i.razonSocial) Then

                Else
                    dr(10) = i.tipoRazon
                End If
                dr(11) = "Pago"


                dt.Rows.Add(dr)
            Next

            dgvProcesoCrono.DataSource = dt
            Me.dgvProcesoCrono.TableOptions.ListBoxSelectionMode = SelectionMode.One





            'Dim n As New ListViewItem(1)
            'n.SubItems.Add(ComboBox1.Text)
            'n.SubItems.Add(monto)
            'n.SubItems.Add(montome)
            'lstConceptos.Items.Add(n)



        Else

        End If
    End Sub







    Sub GrabarCronograma()
        Dim cronoSA As New CronogramaSA
        Dim obj As New Cronograma
        Dim lista As New List(Of Cronograma)
        Try
            For Each i As Record In GridGroupingControl1.Table.Records


                obj = New Cronograma

                obj.identidad = i.GetValue("idProveedor")
                obj.tipoRazon = i.GetValue("tipoProv")
                obj.moneda = i.GetValue("moneda")
                obj.tipocambio = CDec(i.GetValue("tipocambio"))
                obj.montoAutorizadoMN = CDec(i.GetValue("montoPactadoMN"))
                obj.montoAutorizadoME = CDec(i.GetValue("montoPactadoME"))
                obj.glosa = i.GetValue("glosa")
                obj.tipoRazon = i.GetValue("tipoProv")

                If i.GetValue("tipo") = "Pago" Then
                    obj.tipo = "P"
                ElseIf i.GetValue("tipo") = "Cobro" Then
                    obj.tipo = "C"
                End If
                obj.fechaPago = txtFecha.Value
                obj.fechaoperacion = DateTime.Now


                obj.usuarioActualizacion = usuario.IDUsuario
                obj.fechaActualizacion = DateTime.Now
                obj.idDocumentoPago = 0
                lista.Add(obj)
                ' obj.usuarioResponssable = Val(i.GetValue("userResponsable"))



                'If i.GetValue("val") = "S" Then
                '    If CDec(i.GetValue("montoPactadoMN")) > 0 Then

                '        obj = New Cronograma
                '        obj.tipo = "CM"
                '        ' obj.fechaoperacion = Convert.ToDateTime(i.GetValue("fechaOper"))
                '        Dim prv = i.GetValue("idProveedor")

                '        If prv.ToString.Trim.Length > 0 Then
                '            obj.identidad = i.GetValue("idProveedor")
                '            obj.tipoRazon = i.GetValue("tipoProv")
                '        Else

                '        End If

                '        obj.idDocumentoRef = CInt(i.GetValue("idDocumento"))
                '        obj.moneda = IIf(i.GetValue("moneda") = "EXTRANJERA", "2", "1")
                '        obj.tipocambio = CDec(i.GetValue("tipocambio"))
                '        obj.montoAutorizadoMN = CDec(i.GetValue("montoPactadoMN"))
                '        obj.montoAutorizadoME = CDec(i.GetValue("montoPactadoME"))
                '        obj.usuarioResponssable = Val(i.GetValue("userResponsable"))
                '        obj.glosa = i.GetValue("glosa")
                '        obj.autorizacion = "NO"
                '        obj.montoref = CDec(i.GetValue("compraMN"))
                '        obj.montorefusd = CDec(i.GetValue("compraME"))

                '        obj.usuarioActualizacion = usuario.IDUsuario
                '        obj.fechaActualizacion = DateTime.Now
                '        lista.Add(obj)

                '    Else
                '        MessageBox.Show("Los Items Seleccionados deben ser mayor a 0")
                '        Exit Sub
                '    End If
                'End If




            Next
            cronoSA.InsetCronograma(lista)
            Dispose()
        Catch ex As Exception
            'lblEstado.Text = ex.Message
            'PanelError.Visible = True
            'Timer1.Enabled = True
            'TiempoEjecutar(10)
        End Try
    End Sub



    Sub GetTableGrid()
        Dim dt As New DataTable()


        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("fechaOper", GetType(Date))
        dt.Columns.Add("idProveedor", GetType(Integer))
        dt.Columns.Add("nombreProv", GetType(String))
        dt.Columns.Add("tipodoc", GetType(String))
        dt.Columns.Add("nro", GetType(String))
        dt.Columns.Add("compraMN", GetType(Decimal))
        dt.Columns.Add("monedaCompra", GetType(String))
        dt.Columns.Add("compraME", GetType(Decimal))
        dt.Columns.Add("moneda", GetType(String))
        dt.Columns.Add("tipoCambio", GetType(Decimal))
        dt.Columns.Add("montoPactadoMN", GetType(Decimal))
        dt.Columns.Add("montoPactadoME", GetType(Decimal))
        dt.Columns.Add("userResponsable", GetType(String))
        dt.Columns.Add("tipoCC", GetType(Decimal))
        dt.Columns.Add("chBonif", GetType(Boolean))
        dt.Columns.Add("val", GetType(String))
        dt.Columns.Add("tipo", GetType(String))

        dgvProcesoCrono.DataSource = dt
    End Sub

    Sub GetTableGrid2()
        Dim dt As New DataTable()

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("idProveedor", GetType(Integer))
        dt.Columns.Add("nombreProv", GetType(String))
        dt.Columns.Add("moneda", GetType(String))
        dt.Columns.Add("tipocambio", GetType(Decimal))
        dt.Columns.Add("montoPactadoMN", GetType(Decimal))
        dt.Columns.Add("montoPactadoME", GetType(Decimal))
        dt.Columns.Add("glosa", GetType(String))
        dt.Columns.Add("tipoProv", GetType(String))
        dt.Columns.Add("tipo", GetType(String))

        GridGroupingControl1.DataSource = dt
    End Sub




    Private Sub UbicarPagosTodos(intMoneda As String)
        Dim documentoVentaSA As New DocumentoCompraSA
        Dim documentoVenta As New List(Of documentocompra)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        'lstConceptos.Items.Clear()
        Dim monto As Decimal = CDec(0.0)
        Dim montome As Decimal = CDec(0.0)
        ' Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("fechaOper", GetType(Date))
        dt.Columns.Add("idProveedor", GetType(Integer))
        dt.Columns.Add("nombreProv", GetType(String))
        dt.Columns.Add("tipodoc", GetType(String))
        dt.Columns.Add("nro", GetType(String))
        dt.Columns.Add("compraMN", GetType(Decimal))
        dt.Columns.Add("monedaCompra", GetType(String))
        dt.Columns.Add("compraME", GetType(Decimal))
        dt.Columns.Add("moneda", GetType(String))
        dt.Columns.Add("tipoCambio", GetType(Decimal))
        dt.Columns.Add("montoPactadoMN", GetType(Decimal))
        dt.Columns.Add("montoPactadoME", GetType(Decimal))
        dt.Columns.Add("userResponsable", GetType(String))
        dt.Columns.Add("tipoCC", GetType(Decimal))
        dt.Columns.Add("chBonif", GetType(Boolean))
        dt.Columns.Add("val", GetType(String))
        dt.Columns.Add("glosa", GetType(String))
        dt.Columns.Add("tipoProv", GetType(String))

        dgvProcesoCrono.TableDescriptor.Columns(4).Width = 0
        dgvProcesoCrono.TableDescriptor.Columns(5).Width = 0
        dgvProcesoCrono.TableDescriptor.Columns(17).Width = 0

        documentoVenta = documentoVentaSA.UbicarPagosPorProveedor(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, intMoneda)
        'Dim str As String
        If Not IsNothing(documentoVenta) Then
            For Each i In documentoVenta
                Dim dr As DataRow = dt.NewRow()
                'str = Nothing
                'str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
                dr(0) = 1
                dr(1) = DateTime.Now
                dr(2) = i.idProveedor
                dr(3) = i.NombreEntidad
                dr(4) = ""
                dr(5) = ""
                If IsNumeric(i.importeTotal) Then

                    dr(6) = i.importeTotal

                    monto += i.importeTotal
                Else
                    dr(6) = CDec(0)
                    monto += CDec(0)
                End If
                dr(7) = "1"
                If IsNumeric(i.importeUS) Then

                    dr(8) = i.importeUS
                    montome += i.importeUS
                Else
                    dr(8) = CDec(0)
                    montome += CDec(0)
                End If

                dr(9) = i.monedaDoc
                dr(10) = CDec(0.0)
                dr(11) = CDec(0.0)
                dr(12) = CDec(0.0)
                dr(13) = ""
                dr(14) = TmpIGV
                dr(15) = False
                dr(16) = "N"
                dr(17) = "Por Pago a Proveedor"
                dr(16) = "PR"


                dt.Rows.Add(dr)
            Next



            'Dim n As New ListViewItem(1)
            'n.SubItems.Add("PAGO A PROVEEDORES")
            'n.SubItems.Add(monto)
            'n.SubItems.Add(montome)
            'lstConceptos.Items.Add(n)



            dgvProcesoCrono.DataSource = dt
            Me.dgvProcesoCrono.TableOptions.ListBoxSelectionMode = SelectionMode.One
        Else




        End If
    End Sub



    Private Sub UbicarCobrosTodoCliente(intMoneda As String, idprov As Integer)
        Dim documentoVentaSA As New documentoVentaAbarrotesSA
        Dim documentoVenta As New List(Of documentoventaAbarrotes)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable

        Dim documentolibroSA As New documentoLibroDiarioSA
        Dim documentoLibro As New List(Of documentoLibroDiarioDetalle)
        Dim entidadSA As New entidadSA
        Dim personaSA As New PersonaSA



        ' lstConceptos.Items.Clear()
        Dim monto As Decimal = CDec(0.0)
        Dim montome As Decimal = CDec(0.0)
        Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("fechaOper", GetType(Date))
        dt.Columns.Add("idProveedor", GetType(Integer))
        dt.Columns.Add("nombreProv", GetType(String))
        dt.Columns.Add("compraMN", GetType(Decimal))
        dt.Columns.Add("compraME", GetType(Decimal))
        dt.Columns.Add("moneda", GetType(String))
        dt.Columns.Add("montoPactadoMN", GetType(Decimal))
        dt.Columns.Add("montoPactadoME", GetType(Decimal))
        dt.Columns.Add("glosa", GetType(String))
        dt.Columns.Add("tipoProv", GetType(String))
        dt.Columns.Add("tipo", GetType(String))


        documentoVenta = documentoVentaSA.UbicarCobrosPorClienteTodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, intMoneda, idprov, strPeriodo)
        'Dim str As String
        If Not IsNothing(documentoVenta) Then
            For Each i In documentoVenta
                Dim dr As DataRow = dt.NewRow()

                dr(0) = 1
                dr(1) = DateTime.Now
                dr(2) = i.idCliente
                dr(3) = i.NombreEntidad

                If IsNumeric(i.ImporteNacional) Then

                    dr(4) = i.ImporteNacional

                    ' monto += i.importeTotal
                Else
                    dr(4) = CDec(0)
                    'monto += CDec(0)
                End If

                If IsNumeric(i.ImporteExtranjero) Then

                    dr(5) = i.ImporteExtranjero
                    'montome += i.importeUS
                Else
                    dr(5) = CDec(0)
                    'montome += CDec(0)
                End If

                dr(6) = i.moneda
                dr(7) = CDec(0.0)
                dr(8) = CDec(0.0)

                dr(9) = "Por cobrar a cliente"
                dr(10) = "PR"
                dr(11) = "Cobro"
                dt.Rows.Add(dr)
            Next

        Else


        End If

        '(/////

        documentoLibro = documentolibroSA.UbicarCobrosModulosTodoProveedor(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, idprov)
        Dim str As String
        If Not IsNothing(documentoLibro) Then


            For Each i In documentoLibro
                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.fecha).ToString("dd-MMM hh:mm tt ")

                dr(0) = 1
                dr(1) = DateTime.Now


                If IsNothing(i.razonSocial) Then

                Else

                    Select Case i.tipoRazon
                        Case TIPO_ENTIDAD.PROVEEDOR
                            dr(2) = i.razonSocial
                            With entidadSA.UbicarEntidadPorID(i.razonSocial).First
                                dr(3) = .nombreCompleto
                            End With
                        Case TIPO_ENTIDAD.CLIENTE
                            dr(2) = i.razonSocial
                            With entidadSA.UbicarEntidadPorID(i.razonSocial).First
                                dr(3) = .nombreCompleto
                            End With
                        Case "TR"
                            dr(2) = i.razonSocial
                            With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.razonSocial, "TR")
                                dr(3) = .nombreCompleto
                            End With
                    End Select
                End If



                If i.tipoAsiento = "H" Then
                    dr(4) = ((i.importeMN) * -1)

                Else
                    dr(4) = i.importeMN
                    monto += i.importeMN
                End If

                If IsNumeric(i.importeME) Then

                    dr(5) = i.importeME
                    montome += i.importeME
                Else
                    dr(5) = CDec(0)

                End If

                dr(6) = i.moneda
                dr(7) = CDec(0.0)
                dr(8) = CDec(0.0)

                dr(9) = i.informacionReferencial

                If IsNothing(i.razonSocial) Then

                Else
                    dr(10) = i.tipoRazon
                End If
                dr(11) = "Cobro"
                dt.Rows.Add(dr)
            Next
        End If
        '///////7



        dgvProcesoCrono.DataSource = dt
        Me.dgvProcesoCrono.TableOptions.ListBoxSelectionMode = SelectionMode.One

    End Sub




    Private Sub UbicarPagosTodoProveedor(intMoneda As String, idprov As Integer)
        Dim documentoVentaSA As New DocumentoCompraSA
        Dim documentoVenta As New List(Of documentocompra)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable

        Dim documentolibroSA As New documentoLibroDiarioSA
        Dim documentoLibro As New List(Of documentoLibroDiarioDetalle)
        Dim entidadSA As New entidadSA
        Dim personaSA As New PersonaSA



        ' lstConceptos.Items.Clear()
        Dim monto As Decimal = CDec(0.0)
        Dim montome As Decimal = CDec(0.0)
        Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("fechaOper", GetType(Date))
        dt.Columns.Add("idProveedor", GetType(Integer))
        dt.Columns.Add("nombreProv", GetType(String))
        'dt.Columns.Add("tipodoc", GetType(String))
        'dt.Columns.Add("nro", GetType(String))
        dt.Columns.Add("compraMN", GetType(Decimal))
        'dt.Columns.Add("monedaCompra", GetType(String))
        dt.Columns.Add("compraME", GetType(Decimal))
        dt.Columns.Add("moneda", GetType(String))
        ' dt.Columns.Add("tipoCambio", GetType(Decimal))
        dt.Columns.Add("montoPactadoMN", GetType(Decimal))
        dt.Columns.Add("montoPactadoME", GetType(Decimal))
        ' dt.Columns.Add("userResponsable", GetType(String))
        'dt.Columns.Add("tipoCC", GetType(Decimal))
        ' dt.Columns.Add("chBonif", GetType(Boolean))
        ' dt.Columns.Add("val", GetType(String))
        dt.Columns.Add("glosa", GetType(String))
        dt.Columns.Add("tipoProv", GetType(String))
        dt.Columns.Add("tipo", GetType(String))
        'dgvProcesoCrono.TableDescriptor.Columns(4).Width = 0
        'dgvProcesoCrono.TableDescriptor.Columns(5).Width = 0
        'dgvProcesoCrono.TableDescriptor.Columns(17).Width = 0

        documentoVenta = documentoVentaSA.UbicarPagosPorProveedorTodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, intMoneda, idprov, strPeriodo)
        'Dim str As String
        If Not IsNothing(documentoVenta) Then
            For Each i In documentoVenta
                Dim dr As DataRow = dt.NewRow()
                'str = Nothing
                'str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
                dr(0) = 1
                dr(1) = DateTime.Now
                dr(2) = i.idProveedor
                dr(3) = i.NombreEntidad
                'dr(4) = "V"
                'dr(5) = "11"
                If IsNumeric(i.importeTotal) Then

                    dr(4) = i.importeTotal

                    monto += i.importeTotal
                Else
                    dr(4) = CDec(0)
                    monto += CDec(0)
                End If
                'dr(7) = "1"
                If IsNumeric(i.importeUS) Then

                    dr(5) = i.importeUS
                    montome += i.importeUS
                Else
                    dr(5) = CDec(0)
                    montome += CDec(0)
                End If

                dr(6) = i.monedaDoc
                dr(7) = CDec(0.0)
                dr(8) = CDec(0.0)
                'dr(12) = CDec(0.0)
                'dr(13) = ""
                'dr(14) = TmpIGV
                'dr(15) = False
                'dr(16) = "N"
                dr(9) = "Por pago a proveedor"
                dr(10) = "PR"
                dr(11) = "Pago"
                dt.Rows.Add(dr)
            Next

            'Dim n As New ListViewItem(1)
            'n.SubItems.Add("PAGO A PROVEEDORES")
            'n.SubItems.Add(monto)
            'n.SubItems.Add(montome)
            'lstConceptos.Items.Add(n)








            'dgvProcesoCrono.DataSource = dt
            'Me.dgvProcesoCrono.TableOptions.ListBoxSelectionMode = SelectionMode.One
        Else


        End If

        '(/////

        documentoLibro = documentolibroSA.UbicarPagoModulosTodoProveedor(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, idprov)
        Dim str As String
        If Not IsNothing(documentoLibro) Then


            For Each i In documentoLibro
                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.fecha).ToString("dd-MMM hh:mm tt ")



                dr(0) = 1
                dr(1) = DateTime.Now
                'dr(2) = i.idProveedor
                'dr(3) = i.NombreEntidad

                If IsNothing(i.razonSocial) Then

                Else

                    Select Case i.tipoRazon
                        Case TIPO_ENTIDAD.PROVEEDOR
                            dr(2) = i.razonSocial
                            With entidadSA.UbicarEntidadPorID(i.razonSocial).First
                                dr(3) = .nombreCompleto
                            End With
                        Case TIPO_ENTIDAD.CLIENTE
                            dr(2) = i.razonSocial
                            With entidadSA.UbicarEntidadPorID(i.razonSocial).First
                                dr(3) = .nombreCompleto
                            End With
                        Case "TR"
                            dr(2) = i.razonSocial
                            With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.razonSocial, "TR")
                                dr(3) = .nombreCompleto
                            End With
                    End Select
                End If



                'dr(4) = "VC"
                'dr(5) = i.nroDoc


                If i.tipoAsiento = "D" Then
                    dr(4) = ((i.importeMN) * -1)

                Else
                    dr(4) = i.importeMN
                    monto += i.importeMN
                End If


                ' dr(7) = "1"
                If IsNumeric(i.importeME) Then

                    dr(5) = i.importeME
                    montome += i.importeME
                Else
                    dr(5) = CDec(0)

                End If

                dr(6) = i.moneda
                dr(7) = CDec(0.0)
                dr(8) = CDec(0.0)
                'dr(12) = CDec(0.0)
                'dr(13) = ""
                'dr(14) = TmpIGV
                'dr(15) = False
                ' dr(9) = "N"
                dr(9) = i.informacionReferencial

                If IsNothing(i.razonSocial) Then

                Else
                    dr(10) = i.tipoRazon
                End If

                dr(11) = "Pago"

                dt.Rows.Add(dr)
            Next
        End If
        '///////7



        dgvProcesoCrono.DataSource = dt
        Me.dgvProcesoCrono.TableOptions.ListBoxSelectionMode = SelectionMode.One

    End Sub


    Private Sub UbicarCobros(intMoneda As String)
        Dim documentoVentaSA As New documentoVentaAbarrotesSA
        Dim documentoVenta As New List(Of documentoventaAbarrotes)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        'lstConceptos.Items.Clear()
        Dim monto As Decimal = CDec(0.0)
        Dim montome As Decimal = CDec(0.0)
        Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("fechaOper", GetType(Date))
        dt.Columns.Add("idProveedor", GetType(Integer))
        dt.Columns.Add("nombreProv", GetType(String))

        dt.Columns.Add("compraMN", GetType(Decimal))

        dt.Columns.Add("compraME", GetType(Decimal))
        dt.Columns.Add("moneda", GetType(String))

        dt.Columns.Add("montoPactadoMN", GetType(Decimal))
        dt.Columns.Add("montoPactadoME", GetType(Decimal))

        dt.Columns.Add("glosa", GetType(String))
        dt.Columns.Add("tipoProv", GetType(String))
        dt.Columns.Add("tipo", GetType(String))


        documentoVenta = documentoVentaSA.UbicarCobrosPorProveedorXperiodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, strPeriodo, intMoneda)
        'Dim str As String
        If Not IsNothing(documentoVenta) Then
            For Each i In documentoVenta
                Dim dr As DataRow = dt.NewRow()

                dr(0) = 1
                dr(1) = DateTime.Now
                dr(2) = i.idCliente
                dr(3) = i.NombreEntidad

                If IsNumeric(i.ImporteNacional) Then

                    dr(4) = i.ImporteNacional


                Else
                    dr(4) = CDec(0)

                End If

                If IsNumeric(i.ImporteExtranjero) Then

                    dr(5) = i.ImporteExtranjero

                Else
                    dr(5) = CDec(0)

                End If

                dr(6) = i.moneda
                dr(7) = CDec(0.0)
                dr(8) = CDec(0.0)

                dr(9) = "Por cobrar a cliente"
                dr(10) = "PR"
                dr(11) = "Cobro"

                dt.Rows.Add(dr)
            Next





            dgvProcesoCrono.DataSource = dt
            Me.dgvProcesoCrono.TableOptions.ListBoxSelectionMode = SelectionMode.One
        Else




        End If
    End Sub





    Private Sub UbicarPagos(intMoneda As String)
        Dim documentoVentaSA As New DocumentoCompraSA
        Dim documentoVenta As New List(Of documentocompra)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        'lstConceptos.Items.Clear()
        Dim monto As Decimal = CDec(0.0)
        Dim montome As Decimal = CDec(0.0)
        Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("fechaOper", GetType(Date))
        dt.Columns.Add("idProveedor", GetType(Integer))
        dt.Columns.Add("nombreProv", GetType(String))
        'dt.Columns.Add("tipodoc", GetType(String))
        'dt.Columns.Add("nro", GetType(String))
        dt.Columns.Add("compraMN", GetType(Decimal))
        'dt.Columns.Add("monedaCompra", GetType(String))
        dt.Columns.Add("compraME", GetType(Decimal))
        dt.Columns.Add("moneda", GetType(String))
        ' dt.Columns.Add("tipoCambio", GetType(Decimal))
        dt.Columns.Add("montoPactadoMN", GetType(Decimal))
        dt.Columns.Add("montoPactadoME", GetType(Decimal))
        ' dt.Columns.Add("userResponsable", GetType(String))
        'dt.Columns.Add("tipoCC", GetType(Decimal))
        ' dt.Columns.Add("chBonif", GetType(Boolean))
        ' dt.Columns.Add("val", GetType(String))
        dt.Columns.Add("glosa", GetType(String))
        dt.Columns.Add("tipoProv", GetType(String))
        dt.Columns.Add("tipo", GetType(String))
        'dgvProcesoCrono.TableDescriptor.Columns(4).Width = 0
        'dgvProcesoCrono.TableDescriptor.Columns(5).Width = 0
        'dgvProcesoCrono.TableDescriptor.Columns(17).Width = 0

        documentoVenta = documentoVentaSA.UbicarPagosPorProveedorXperiodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, strPeriodo, intMoneda)
        'Dim str As String
        If Not IsNothing(documentoVenta) Then
            For Each i In documentoVenta
                Dim dr As DataRow = dt.NewRow()
                'str = Nothing
                'str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
                dr(0) = 1
                dr(1) = DateTime.Now
                dr(2) = i.idProveedor
                dr(3) = i.NombreEntidad
                'dr(4) = "V"
                'dr(5) = "11"
                If IsNumeric(i.importeTotal) Then

                    dr(4) = i.importeTotal

                    'monto += i.importeTotal
                Else
                    dr(4) = CDec(0)
                    'monto += CDec(0)
                End If
                'dr(7) = "1"
                If IsNumeric(i.importeUS) Then

                    dr(5) = i.importeUS
                    'montome += i.importeUS
                Else
                    dr(5) = CDec(0)
                    ' montome += CDec(0)
                End If

                dr(6) = i.monedaDoc
                dr(7) = CDec(0.0)
                dr(8) = CDec(0.0)
                'dr(12) = CDec(0.0)
                'dr(13) = ""
                'dr(14) = TmpIGV
                'dr(15) = False
                'dr(16) = "N"
                dr(9) = "Por pago a proveedor"
                dr(10) = "PR"
                dr(11) = "Pago"

                dt.Rows.Add(dr)
            Next

            'Dim n As New ListViewItem(1)
            'n.SubItems.Add("PAGO A PROVEEDORES")
            'n.SubItems.Add(monto)
            'n.SubItems.Add(montome)
            'lstConceptos.Items.Add(n)



            dgvProcesoCrono.DataSource = dt
            Me.dgvProcesoCrono.TableOptions.ListBoxSelectionMode = SelectionMode.One
        Else




        End If
    End Sub


    Public Function GetTableAlmacen() As DataTable
        Dim almacenSA As New PersonaSA
        Dim dt As New DataTable()
        dt.Columns.Add("idPersona", GetType(String))
        dt.Columns.Add("nombreCompleto", GetType(String))


        For Each i In almacenSA.ObtenerPersona(New Persona With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                 .tipoPersona = "T"}).ToList

            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.idPersona
            dr(1) = i.nombreCompleto
            dt.Rows.Add(dr)
        Next



        Return dt
    End Function
#End Region
    Dim comboTableP As New DataTable

    Private Sub frmCronogramaPagos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub
    Private Sub frmCronogramaPagos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtPeriodo.Value = PeriodoGeneral

        comboTableP = Me.GetTableAlmacen
        Dim ggcStyle As GridTableCellStyleInfo = dgvProcesoCrono.TableDescriptor.Columns(13).Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = Me.comboTableP
        ggcStyle.ValueMember = "idPersona"
        ggcStyle.DisplayMember = "nombreCompleto"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive
        dgvProcesoCrono.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        dgvProcesoCrono.ShowRowHeaders = False
    End Sub

    Private Sub ButtonAdv15_Click(sender As Object, e As EventArgs) Handles ButtonAdv15.Click
        Me.Cursor = Cursors.WaitCursor


        Select Case cboMonedaProveedor.Text
            Case "NACIONAL"


                If cbotipo.Text = "PAGOS" Then

                    If cboConsulta.Text = "CONSULTA PERSONALIZADA" Then
                        UbicarPagosTodoProveedor("1", txtProveedor.Tag)
                    ElseIf cboConsulta.Text = "CONSULTA POR MODULO" Then

                        If cboModulos.Text = "PAGO A PROVEEDORES" Then
                            UbicarPagos("1")
                        ElseIf cboModulos.Text = "ANTICIPOS DE CLIENTES" Then
                            pagosmodulos("122")
                        ElseIf cboModulos.Text = "ANTICIPOS RECIBIDOS" Then
                            pagosmodulos("132")
                        ElseIf cboModulos.Text = "REMUNERACIONES Y PARTICIPACIONES POR PAGAR" Then
                            pagosmodulos("41")
                        ElseIf cboModulos.Text = "CUENTAS POR PAGAR COMERCIALES – TERCEROS" Then
                            pagosmodulos("42")
                        ElseIf cboModulos.Text = "CUENTAS POR PAGAR COMERCIALES – RELACIONADAS" Then
                            pagosmodulos("43")
                        ElseIf cboModulos.Text = "LETRAS POR PAGAR 423" Then
                            pagosmodulos("423")
                        ElseIf cboModulos.Text = "LETRAS POR PAGAR 433" Then
                            pagosmodulos("433")
                        ElseIf cboModulos.Text = "CUENTAS POR PAGAR A LOS ACCIONISTAS, DIRECTORES Y GERENTES" Then
                            pagosmodulos("44")
                        ElseIf cboModulos.Text = "OBLIGACIONES FINANCIERAS" Then
                            pagosmodulos("45")
                        ElseIf cboModulos.Text = "CUENTAS POR PAGAR DIVERSAS – TERCEROS" Then
                            pagosmodulos("46")
                        ElseIf cboModulos.Text = "CUENTAS POR PAGAR DIVERSAS – RELACIONADAS" Then
                            pagosmodulos("47")
                        ElseIf cboModulos.Text = "TRIBUTOS Y APORTES AL SISTEMA DE PENSIONES Y DE SALUD POR PAGAR" Then
                            pagosmodulos("40")
                        End If

                    ElseIf cboConsulta.Text = "CONSULTA INTEGRAL" Then
                        UbicarPagosTodo("1")
                    End If

                ElseIf cbotipo.Text = "COBROS" Then


                    If cboConsulta.Text = "CONSULTA PERSONALIZADA" Then

                        UbicarCobrosTodoCliente("1", txtProveedor.Tag)

                    ElseIf cboConsulta.Text = "CONSULTA POR MODULO" Then

                        If cboModulosCobros.Text = "COBRO A CLIENTES" Then
                            UbicarCobros("1")
                        ElseIf cboModulosCobros.Text = "CUENTAS POR COBRAR COMERCIALES – RELACIONADAS" Then
                            Cobrosmodulos("13")
                        ElseIf cboModulosCobros.Text = "CUENTAS POR COBRAR AL PERSONAL, A LOS ACCIONISTAS (SOCIOS), DIRECTORES Y GERENTES" Then
                            Cobrosmodulos("14")
                        ElseIf cboModulos.Text = "CUENTAS POR COBRAR DIVERSAS - TERCEROS" Then
                            Cobrosmodulos("16")
                        ElseIf cboModulos.Text = "CUENTAS POR COBRAR DIVERSAS - RELACIONADAS" Then
                            Cobrosmodulos("17")
                        ElseIf cboModulos.Text = "ANTICIPOS A PROVEEDORES" Then
                            Cobrosmodulos("422")
                        ElseIf cboModulos.Text = "ANTICIPOS OTORGADOS" Then
                            Cobrosmodulos("432")
                        End If

                    ElseIf cboConsulta.Text = "CONSULTA INTEGRAL" Then
                        UbicarCobrosTodo("1")
                    End If



                    End If
            Case "EXTRANJERA"

                    ' UbicarPagos("2")



        End Select
        Me.Cursor = Cursors.Arrow
    End Sub

  

    Private Sub dgvProcesoCrono_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvProcesoCrono.QueryCellStyleInfo
        If e.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.TableCellIdentity.Column.Name = "chBonif" Then
            e.Style.CellType = "CheckBox"
            e.Style.CellValueType = GetType(Boolean)
            '   e.Style.CellValue = CheckBoxValue
            e.Style.[ReadOnly] = False
            e.Style.CellAppearance = GridCellAppearance.Raised
            e.Style.Enabled = True
            e.Style.Description = e.Style.CellValue.ToString()
        End If
    End Sub

    Private Sub dgvProcesoCrono_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvProcesoCrono.TableControlCellClick
        Dim style2 As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
        If style2.Enabled Then
            If style2.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso style2.TableCellIdentity.Column.Name = "chBonif" Then
                e.Inner.Cancel = True
            End If
            Console.WriteLine(e.Inner.RowIndex.ToString() & "TableControlCellClick")
        End If
    End Sub



    Private chk As Boolean, check As Boolean = False
    Private ht As New ArrayList()
    Private Sub dgvProcesoCrono_TableControlCheckBoxClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvProcesoCrono.TableControlCheckBoxClick
        'Dim style As GridTableCellStyleInfo = DirectCast(e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex), GridTableCellStyleInfo)
        'Dim el As Element = Me.dgvProcesoCrono.Table.GetInnerMostCurrentElement()

        'Dim colindexVal As Integer = style.CellIdentity.ColIndex

        'Dim RowIndex2 As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.RowIndex
        'If RowIndex2 > -1 Then
        '    Select Case colindexVal
        '        Case 18



        '        Case 16

        '            '      Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex), GridTableCellStyleInfo)
        '            If style.Enabled Then
        '                Dim column As Integer = Me.dgvProcesoCrono.TableModel.NameToColIndex("chBonif")
        '                ' Console.WriteLine("CheckBoxClicked")
        '                '   Dim s = e.TableControl.Table.CurrentRecord.GetValue("colModVenta")
        '                If style.Enabled AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell Then
        '                    chk = CBool(Me.dgvProcesoCrono.TableModel(style.TableCellIdentity.RowIndex, column).CellValue)

        '                    e.TableControl.BeginUpdate()

        '                    e.TableControl.EndUpdate(True)
        '                End If





        '                If style.Enabled AndAlso (style.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell OrElse style.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) AndAlso style.TableCellIdentity.Column.Name = "chBonif" Then
        '                    Dim currentRecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
        '                    Dim curStatus As Boolean = Boolean.Parse(style.Text)
        '                    e.TableControl.BeginUpdate()

        '                    If curStatus Then
        '                        '   CheckBoxValue = False
        '                    End If
        '                    If curStatus = True Then
        '                        Dim RowIndex As Integer = e.Inner.RowIndex
        '                        Dim ColIndex As Integer = e.Inner.ColIndex
        '                        '      MsgBox(False)
        '                        Me.dgvProcesoCrono.TableModel(RowIndex, 17).CellValue = "N" ' curStatus



        '                    Else
        '                        Dim RowIndex As Integer = e.Inner.RowIndex
        '                        Dim ColIndex As Integer = e.Inner.ColIndex
        '                        '     MsgBox(True)
        '                        Me.dgvProcesoCrono.TableModel(RowIndex, 17).CellValue = "S"




        '                    End If






        '                    e.TableControl.EndUpdate()
        '                    If ht.Contains(curStatus) AndAlso (Not ht.Contains((Not curStatus))) Then
        '                    ElseIf Not ht.Contains(curStatus) Then
        '                    End If
        '                    ht.Clear()
        '                End If








        '            End If
        '    End Select

        '    Me.dgvProcesoCrono.TableControl.Refresh()

        'End If
    End Sub

    Private Sub dgvProcesoCrono_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles dgvProcesoCrono.TableControlCurrentCellCloseDropDown
        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()
    End Sub

    Private Sub dgvProcesoCrono_TableControlCurrentCellDeactivateFailed(sender As Object, e As GridTableControlEventArgs) Handles dgvProcesoCrono.TableControlCurrentCellDeactivateFailed

    End Sub

    Private Sub dgvProcesoCrono_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvProcesoCrono.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        If Not IsNothing(Me.dgvProcesoCrono.Table.CurrentRecord) Then
            Select Case ColIndex

                Case 12


                    If Me.dgvProcesoCrono.Table.CurrentRecord.GetValue("montoPactadoMN") >= 0 Then

                        If Me.dgvProcesoCrono.Table.CurrentRecord.GetValue("montoPactadoMN") <= Me.dgvProcesoCrono.Table.CurrentRecord.GetValue("compraMN") Then

                            Dim colPercepcionME As Decimal = 0
                            colPercepcionME = Math.Round(CDec(Me.dgvProcesoCrono.Table.CurrentRecord.GetValue("montoPactadoMN")) / TmpTipoCambio, 2)
                            Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("montoPactadoME", colPercepcionME)

                            'If Me.dgvProcesoCrono.Table.CurrentRecord.GetValue("montoPactadoMN") > 0 Then

                            '    ' Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("chBonif", True)
                            '    ' Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("val", "S")
                            'Else

                            '    'Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("chBonif", False)
                            '    ' Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("val", "N")

                            'End If

                        Else

                            Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("montoPactadoMN", CDec(0.0))
                            Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("montoPactadoME", CDec(0.0))
                            ' MessageBox.Show("Ingrese un Monto Menor o Igual ala deuda")
                            MessageBox.Show("Ingrese un Monto Menor o Igual ala deuda!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)


                            'Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("chBonif", False)
                            'Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("val", "N")
                        End If

                    Else
                        Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("montoPactadoMN", CDec(0.0))
                        Me.dgvProcesoCrono.Table.CurrentRecord.SetValue("montoPactadoME", CDec(0.0))
                    End If

            End Select
        End If
    End Sub

    'Private Sub ButtonAdv18_Click(sender As Object, e As EventArgs) Handles ButtonAdv18.Click
    '    If cboCuentaPadre.Text.Trim.Length > 0 Then

    '        'pagosmodulos(cboCuentaPadre.Text)

    '        If cboCuentaPadre.Text = "ANTICIPOS DE CLIENTES" Then
    '            pagosmodulos("122")
    '        ElseIf cboCuentaPadre.Text = "ANTICIPOS RECIBIDOS" Then
    '            pagosmodulos("132")
    '        ElseIf cboCuentaPadre.Text = "REMUNERACIONES Y PARTICIPACIONES POR PAGAR" Then
    '            pagosmodulos("41")
    '        ElseIf cboCuentaPadre.Text = "CUENTAS POR PAGAR COMERCIALES – TERCEROS" Then
    '            pagosmodulos("42")
    '        ElseIf cboCuentaPadre.Text = "CUENTAS POR PAGAR COMERCIALES – RELACIONADAS" Then
    '            pagosmodulos("43")
    '        ElseIf cboCuentaPadre.Text = "LETRAS POR PAGAR 423" Then
    '            pagosmodulos("423")
    '        ElseIf cboCuentaPadre.Text = "LETRAS POR PAGAR 433" Then
    '            pagosmodulos("433")
    '        ElseIf cboCuentaPadre.Text = "CUENTAS POR PAGAR A LOS ACCIONISTAS, DIRECTORES Y GERENTES" Then
    '            pagosmodulos("44")
    '        ElseIf cboCuentaPadre.Text = "OBLIGACIONES FINANCIERAS" Then
    '            pagosmodulos("45")
    '        ElseIf cboCuentaPadre.Text = "CUENTAS POR PAGAR DIVERSAS – TERCEROS" Then
    '            pagosmodulos("46")
    '        ElseIf cboCuentaPadre.Text = "CUENTAS POR PAGAR DIVERSAS – RELACIONADAS" Then
    '            pagosmodulos("47")
    '        ElseIf cboCuentaPadre.Text = "TRIBUTOS Y APORTES AL SISTEMA DE PENSIONES Y DE SALUD POR PAGAR" Then
    '            pagosmodulos("40")

    '        End If


    '    Else

    '    End If
    'End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
        'If ComboBox1.Text = "PAGO A PROVEEDORES" Then


        '    Label15.Visible = True
        '    cboMonedaProveedor.Visible = True
        '    Label34.Visible = True
        '    txtPeriodo.Visible = True
        '    ButtonAdv15.Visible = True
        '    ButtonAdv1.Visible = True
        '    'Label41.Visible = False


        'Else
        '    'Label41.Visible = False
        '    cboMonedaProveedor.Visible = False
        '    Label34.Visible = False
        '    txtPeriodo.Visible = False
        '    Label15.Visible = False


        'End If
    End Sub

    Private Sub cboCuentaPadre_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    'Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
    '    Select Case cboMonedaProveedor.Text
    '        Case "NACIONAL"
    '            'UbicarPagosTodos("1")

    '            UbicarPagosTodo("1")

    '        Case "EXTRANJERA"
    '            'UbicarPagosTodos("2")
    '            UbicarPagosTodo("2")
    '    End Select
    'End Sub

    Private Sub txtProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Me.popupControlContainer1.ParentControl = Me.txtProveedor
            Me.popupControlContainer1.ShowPopup(Point.Empty)


            If cbotipo.Text = "PAGOS" Then
                CargarEntidadesXtipo(TIPO_ENTIDAD.PROVEEDOR, txtProveedor.Text.Trim)

            ElseIf cbotipo.Text = "COBROS" Then
                CargarEntidadesXtipo(TIPO_ENTIDAD.CLIENTE, txtProveedor.Text.Trim)

            End If

        End If
    End Sub

  
    Private Sub txtProveedor_TextChanged(sender As Object, e As EventArgs) Handles txtProveedor.TextChanged

    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        If lsvProveedor.SelectedItems.Count > 0 Then
            Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub lsvProveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvProveedor.SelectedIndexChanged

    End Sub

    Private Sub popupControlContainer1_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles popupControlContainer1.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                Me.txtProveedor.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                txtProveedor.Tag = lsvProveedor.SelectedItems(0).SubItems(0).Text
                txtRuc.Text = lsvProveedor.SelectedItems(0).SubItems(3).Text
                'txtCuenta = lsvProveedor.SelectedItems(0).SubItems(2).Text
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
    End Sub

    'Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
    '    If CheckBox2.Checked = True Then
    '        CheckBox1.Checked = False
    '        CheckBox3.Checked = False
    '        GroupBox5.Visible = True
    '        ButtonAdv1.Visible = False
    '        GroupBox1.Visible = False

    '    ElseIf CheckBox2.Checked = False Then
    '        CheckBox2.Checked = False
    '        GroupBox5.Visible = False
    '        GroupBox1.Visible = False
    '    End If
    'End Sub

   

    'Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
    '    If CheckBox1.Checked = True Then
    '        CheckBox2.Checked = False
    '        CheckBox3.Checked = False
    '        ButtonAdv1.Visible = False
    '        ButtonAdv15.Visible = True
    '        GroupBox1.Visible = True
    '        GroupBox5.Visible = True
    '    ElseIf CheckBox1.Checked = False Then
    '        CheckBox1.Checked = False
    '        GroupBox5.Visible = False
    '        GroupBox1.Visible = False

    '    End If
    'End Sub

    'Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
    '    If CheckBox3.Checked = True Then
    '        CheckBox1.Checked = False
    '        CheckBox2.Checked = False
    '        ButtonAdv1.Visible = True
    '        ButtonAdv15.Visible = False
    '        GroupBox1.Visible = False
    '        ' GroupBox5.Visible = True
    '    ElseIf CheckBox3.Checked = False Then
    '        CheckBox3.Checked = False
    '        GroupBox5.Visible = False

    '        ButtonAdv1.Visible = False
    '        GroupBox1.Visible = False
    '    End If
    'End Sub

    'Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
    '    If ComboBox2.Text = "CONSULTA POR MODULO" Then
    '        ComboBox1.Visible = True
    '        GroupBox5.Visible = False
    '    ElseIf ComboBox2.Text = "CONSULTA PERSONALIZADA" Then
    '        ComboBox1.Visible = False
    '        GroupBox5.Visible = True
    '    ElseIf ComboBox2.Text = "CONSULTA INTEGRAL" Then
    '        ComboBox1.Visible = False
    '        GroupBox5.Visible = False
    '    End If
    'End Sub





    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    'If Not IsNothing(dgvProcesoCrono.Table.CurrentRecord) Then

    '    With frmNuevoDetCronograma

    '        .txtProveedor.Tag = dgvProcesoCrono.Table.CurrentRecord.GetValue("idProveedor")
    '        .txtProveedor.Text = dgvProcesoCrono.Table.CurrentRecord.GetValue("nombreProv")
    '        .txtGlosa.Text = dgvProcesoCrono.Table.CurrentRecord.GetValue("glosa")
    '        .txtImporteMN.Value = dgvProcesoCrono.Table.CurrentRecord.GetValue("montoPactadoMN")
    '        .txtImporteME.Value = dgvProcesoCrono.Table.CurrentRecord.GetValue("montoPactadoME")
    '        .txtTipoProv.Text = dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv")
    '        .ShowDialog()
    '    End With




    'End If
    'End Sub

    

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        If Not IsNothing(Me.GridGroupingControl1.Table.CurrentRecord) Then
            Me.GridGroupingControl1.Table.CurrentRecord.Delete()
            'TotalTalesXcolumna()
        Else
            MessageBox.Show("Seleccione un Item para eliminar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        If GridGroupingControl1.Table.Records.Count > 0 Then
            GrabarCronograma()
        Else
            ' MessageBox.Show("Debe Ingresar Items ala Canasta")
            MessageBox.Show("Debe Ingresar Items ala Canasta!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        Dispose()
    End Sub

    Private Sub ComboBoxAdv1_Click(sender As Object, e As EventArgs) Handles cboConsulta.Click

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBoxAdv1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboConsulta.SelectedIndexChanged
        If cboConsulta.Text = "CONSULTA POR MODULO" Then
            cboModulos.Visible = True
            GroupBox5.Visible = False
            Label15.Visible = True
            cboMonedaProveedor.Visible = True
            Label34.Visible = True
            txtPeriodo.Visible = True


        ElseIf cboConsulta.Text = "CONSULTA PERSONALIZADA" Then
            cboModulos.Visible = False
            GroupBox5.Visible = True

            Label15.Visible = True
            cboMonedaProveedor.Visible = True
            Label34.Visible = True
            txtPeriodo.Visible = True
            cboModulosCobros.Visible = False

        ElseIf cboConsulta.Text = "CONSULTA INTEGRAL" Then
            cboModulos.Visible = False
            GroupBox5.Visible = False

            Label15.Visible = False
            cboMonedaProveedor.Visible = False
            Label34.Visible = False
            txtPeriodo.Visible = False

        End If
    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click

        If Not IsNothing(dgvProcesoCrono.Table.CurrentRecord) Then

            For Each i As Record In GridGroupingControl1.Table.Records

                If i.GetValue("idProveedor") = dgvProcesoCrono.Table.CurrentRecord.GetValue("idProveedor") Then
                    If i.GetValue("glosa") = dgvProcesoCrono.Table.CurrentRecord.GetValue("glosa") Then

                        MessageBox.Show("Este Item ya ha sido agregado elimine si desea agregar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub

                    End If
                End If
            Next

            If dgvProcesoCrono.Table.CurrentRecord.GetValue("montoPactadoMN") > 0 Then

                Me.GridGroupingControl1.Table.AddNewRecord.SetCurrent()
                Me.GridGroupingControl1.Table.AddNewRecord.BeginEdit()
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("idProveedor", dgvProcesoCrono.Table.CurrentRecord.GetValue("idProveedor"))
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("nombreProv", dgvProcesoCrono.Table.CurrentRecord.GetValue("nombreProv"))
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("moneda", "1")
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("tipocambio", TmpTipoCambio)
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("montoPactadoMN", dgvProcesoCrono.Table.CurrentRecord.GetValue("montoPactadoMN"))
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("montoPactadoME", dgvProcesoCrono.Table.CurrentRecord.GetValue("montoPactadoME"))
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("glosa", dgvProcesoCrono.Table.CurrentRecord.GetValue("glosa"))
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("tipoProv", dgvProcesoCrono.Table.CurrentRecord.GetValue("tipoProv"))
                Me.GridGroupingControl1.Table.CurrentRecord.SetValue("tipo", dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo"))
                Me.GridGroupingControl1.Table.AddNewRecord.EndEdit()

            Else

                MessageBox.Show("El monto debe ser Mayor a 0")

            End If

        Else
            MessageBox.Show("Seleccione un Item para agregar a canasta!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub cbotipo_Click(sender As Object, e As EventArgs) Handles cbotipo.Click
        
    End Sub

    Private Sub cbotipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbotipo.SelectedIndexChanged
        If cboConsulta.Text = "CONSULTA POR MODULO" Then

            If cbotipo.Text = "PAGOS" Then
                cboModulos.Visible = True
                cboModulosCobros.Visible = False
                GroupBox5.Visible = False

                dgvProcesoCrono.Table.Records.DeleteAll()
                GridGroupingControl1.Table.Records.DeleteAll()

            ElseIf cbotipo.Text = "COBROS" Then
                cboModulos.Visible = False
                cboModulosCobros.Visible = True
                GroupBox5.Visible = False

                dgvProcesoCrono.Table.Records.DeleteAll()
                GridGroupingControl1.Table.Records.DeleteAll()
            End If

        ElseIf cboConsulta.Text = "CONSULTA PERSONALIZADA" Then
            cboModulos.Visible = False
            cboModulosCobros.Visible = False
            GroupBox5.Visible = True

        ElseIf cboConsulta.Text = "CONSULTA INTEGRAL" Then
            cboModulos.Visible = False
            cboModulosCobros.Visible = False
            GroupBox5.Visible = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With frmFlujoPagos
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub
End Class