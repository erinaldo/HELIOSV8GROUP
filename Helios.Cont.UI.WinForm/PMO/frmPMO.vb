
Imports Helios.Cont.Business.Entity
Imports Helios.General 
Imports Helios.Planilla.Business.Entity

Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Planilla.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmPMO
    Dim IdActividadMTAnt As Integer
    Dim EstadoMTAnt As String

    'LinkLabel3.ContextMenuStrip.Show(LinkLabel3, e.Location)
#Region "Metodos"
    Public Sub GrabarPeriodo()
        Dim empresaPeriodoSA As New empresaPeriodoSA
        Dim empresaPeriodo As New empresaPeriodo

        With empresaPeriodo
            .idEmpresa = Gempresas.IdEmpresaRuc
            .periodo = cboAnios.Text
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With

        empresaPeriodoSA.InsertarPeriodo(empresaPeriodo)
        lblEstado.Text = "Año agregado correctamente!"
        LoadPeriodos()
        toolAnio.Visible = False
    End Sub

    Sub LoadPeriodos()
        Dim periodoSA As New empresaPeriodoSA
        cboPeriodo.Items.Clear()
        For Each i As empresaPeriodo In periodoSA.GetListar_empresaPeriodo(Gempresas.IdEmpresaRuc)
            cboPeriodo.Items.Add(i.periodo)
        Next
        lblPerido.Text = cboPeriodo.Items(0)
        PeriodoGeneral = lblPerido.Text
    End Sub

    Sub IdModoTRabajo()
        Select Case GProyectos.ModoTrabajo
            Case "FASE"
                GProyectos.IdModoTrabajo = TIPO_ACTIVIDAD_MODULO.FASE
            Case "ENTREGABLE"
                GProyectos.IdModoTrabajo = TIPO_ACTIVIDAD_MODULO.ENTREGABLE
            Case "ACTIVIDAD"
                GProyectos.IdModoTrabajo = TIPO_ACTIVIDAD_MODULO.ACTIVIDAD
            Case "PROYECTO"
                GProyectos.IdModoTrabajo = TIPO_ACTIVIDAD_MODULO.PROYECTO
        End Select
    End Sub

    Sub UpdateModoTrabajo(ByVal IdActividadMTAnt As Integer, ByVal EstadoMTAnt As String, ByVal EstadoMT As String)
        Dim proyectoSA As New ProyectoPlaneacionSA
        Dim proyecto As New ProyectoPlaneacion
        Dim codigoMT As String
        proyecto = New ProyectoPlaneacion With {
          .Action = Business.Entity.BaseBE.EntityAction.INSERT,
           .idProyecto = GProyectos.IdProyectoActividad,
           .anotacionEstado = EstadoMT,
           .refDocAprobacion = GModoTRabajos.IdActividad}
        codigoMT = proyectoSA.UpdateModoTrabajo(proyecto, IdActividadMTAnt, EstadoMTAnt)
    End Sub


    Sub FasesShow(intIdPadre As Integer, strModulo As String, strFlag As String)
        Dim proyectoSA As New ProyectoPlaneacionSA
        Dim proyecto As New ProyectoPlaneacion
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        With frmModalActividadPorProyecto
            Select Case strModulo
                Case TIPO_ACTIVIDAD_MODULO.FASE
                    .lblTitulo.Text = "FASE"
                Case TIPO_ACTIVIDAD_MODULO.ENTREGABLE
                    .lblTitulo.Text = "ENTREGABLE"
                Case TIPO_ACTIVIDAD_MODULO.ACTIVIDAD
                    .lblTitulo.Text = "ACTIVIDAD"
                Case TIPO_ACTIVIDAD_MODULO.PROYECTO
                    .lblTitulo.Text = "PROYECTO"
            End Select

            .ListaModal(intIdPadre, strModulo, strFlag)
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            If datos.Count > 0 Then
                GModoTRabajos = New GModoTrabajo
                proyecto = New ProyectoPlaneacion
                proyecto.idProyecto = GProyectos.IdProyectoActividad
                proyecto.anotacionEstado = strModulo
                proyecto.refDocAprobacion = datos(0).ID
                proyectoSA.EditarProyectoModoTrabajo(proyecto)
                lblEstado.Text = "Modo de trabajo actualizado!"
                lblEstado.Image = My.Resources.ok4
                GModoTRabajos.IdActividad = datos(0).ID
                GModoTRabajos.NombreActividad = datos(0).NombreEntidad
                GModoTRabajos.Modulo = strModulo
                'Select Case strModulo
                '    Case TIPO_ACTIVIDAD_MODULO.FASE
                '        LinkLabel3.Text = "FASE"
                '    Case TIPO_ACTIVIDAD_MODULO.ENTREGABLE
                '        LinkLabel3.Text = "ENTREGABLE"
                '    Case TIPO_ACTIVIDAD_MODULO.ACTIVIDAD
                '        LinkLabel3.Text = "ACTIVIDAD"
                '    Case TIPO_ACTIVIDAD_MODULO.PROYECTO
                '        LinkLabel3.Text = "PROYECTO"
                'End Select
                '    LinkLabel3.Text = datos(0).NombreEntidad
                'With proyectoSA.UbicarProyecto(GProyectos.IdProyectoActividad)
                '    Select Case .anotacionEstado
                '        Case TIPO_ACTIVIDAD_MODULO.FASE
                '            LinkLabel3.Text = "FASE"
                '            GProyectos.ModoTrabajo = "FASE"
                '            GProyectos.IdModoTrabajo = .anotacionEstado
                '            GProyectos.IdActividadTrabajo = .refDocAprobacion
                '        Case TIPO_ACTIVIDAD_MODULO.ENTREGABLE
                '            LinkLabel3.Text = "ENTREGABLE"
                '            GProyectos.ModoTrabajo = "ENTREGABLE"
                '            GProyectos.IdModoTrabajo = .anotacionEstado
                '            GProyectos.IdActividadTrabajo = .refDocAprobacion
                '        Case TIPO_ACTIVIDAD_MODULO.ACTIVIDAD
                '            LinkLabel3.Text = "ACTIVIDAD"
                '            GProyectos.ModoTrabajo = "ACTIVIDAD"
                '            GProyectos.IdModoTrabajo = .anotacionEstado
                '            GProyectos.IdActividadTrabajo = .refDocAprobacion
                '        Case TIPO_ACTIVIDAD_MODULO.PROYECTO
                '            LinkLabel3.Text = "PROYECTO"
                '            GProyectos.ModoTrabajo = "PROYECTO"
                '            GProyectos.IdModoTrabajo = .anotacionEstado
                '            GProyectos.IdActividadTrabajo = .refDocAprobacion
                '    End Select
                'End With
                UpdateModoTrabajo(IdActividadMTAnt, EstadoMTAnt, GProyectos.IdModoTrabajo)
                LoadProcesosTree("2")
                Panel4.Controls.Clear()

            End If

        End With
        Me.Cursor = Cursors.Arrow
    End Sub


    Private Function CheckForm(_form As Form) As Form
        Me.Cursor = Cursors.WaitCursor
        For Each f As Form In Application.OpenForms
            If f.Name = _form.Name Then
                '    frmMantenimientoCompras.UbicarCompra_cc(currentPage, currentSize)

                Return f
            End If
        Next

        Return Nothing
        Me.Cursor = Cursors.Arrow
    End Function

    Public Sub LoadTree()
        tvOperaciones.Nodes.Clear()
        'Dim newNodeAlmacen As TreeNode = New TreeNode("Empresas")
        'newNodeAlmacen.Nodes.Add("Nuevo/Listado de Empresas").Tag = "GE"
        'newNodeAlmacen.Nodes.Add("Cambiar sesión de empresa")

        'tvOperaciones.Nodes.Add(newNodeAlmacen)

        'Dim newNodeCompras As TreeNode = New TreeNode("Establecimientos")
        'newNodeCompras.Nodes.Add("Nuevo/Listado de establecimientos").Tag = "LET"
        'tvOperaciones.Nodes.Add(newNodeCompras)

        'Dim newNodeTablas As TreeNode = New TreeNode("Tablas Generales")
        ''newNodeTablas.Nodes.Add("1. Tipo de Medio de Pago").Tag = "1"
        ''newNodeTablas.Nodes.Add("2. Tipo de Documento de Identidad").Tag = "2"
        ''newNodeTablas.Nodes.Add("6. Unidad de Medida").Tag = "6"
        ''newNodeTablas.Nodes.Add("8. Código del Libro o Registro").Tag = "8"
        ''newNodeTablas.Nodes.Add("10. Tipo de Comprobante de Pago o Documento").Tag = "10"
        ''newNodeTablas.Nodes.Add("11. Codigo Aduanas").Tag = "11"
        ''newNodeTablas.Nodes.Add("14. Tipo Establecimiento").Tag = "14"
        ''newNodeTablas.Nodes.Add("21. Presentación de Productos").Tag = "21"
        ''newNodeTablas.Nodes.Add("98. Nacionalidades").Tag = "98"
        ''newNodeTablas.Nodes.Add("99. Elemento del Costo").Tag = "99"
        ''newNodeTablas.Nodes.Add("100. Comprobantes de prestámo").Tag = "100"
        ''newNodeTablas.Nodes.Add("102. Comprobantes Anticipos").Tag = "102"
        ''newNodeTablas.Nodes.Add("103. Comprabantes Provisiones").Tag = "103"
        ''newNodeTablas.Nodes.Add("104. Detalle Ventas").Tag = "104"
        ''newNodeTablas.Nodes.Add("106. Modalidad Ejecución").Tag = "106"
        ''newNodeTablas.Nodes.Add("107. Prioridad de Ejecución de obras").Tag = "107"
        ''newNodeTablas.Nodes.Add("200. Cargos u Ocupación").Tag = "200"
        'tvOperaciones.Nodes.Add(newNodeTablas)


        'Dim newNodeExistencia As TreeNode = New TreeNode("Gestion de Existencias")
        'newNodeExistencia.Nodes.Add("Mercaderia").Tag = "01"
        'newNodeExistencia.Nodes.Add("Producto Terminado").Tag = "02"
        'newNodeExistencia.Nodes.Add("Materias Primas").Tag = "03"
        'newNodeExistencia.Nodes.Add("Envases y Embalajes").Tag = "04"
        'newNodeExistencia.Nodes.Add("Materiales auxliares, sum...").Tag = "05"
        'newNodeExistencia.Nodes.Add("Sub Productos desechos y desperdicios").Tag = "06"
        'newNodeExistencia.Nodes.Add("Clasificacion de Productos/Items").Tag = "CLAS"
        'tvOperaciones.Nodes.Add(newNodeExistencia)


        Dim newNodeUser As TreeNode = New TreeNode("Configuración de Usuario")
        newNodeUser.Tag = "CONF_USER"
        tvOperaciones.Nodes.Add(newNodeUser)

        'Dim newNodePlaneamiento As TreeNode = tvOperaciones.Nodes.Add(0, "Dirección de Proyectos P.M.O.")

        'Dim tnInicioVS As TreeNode = newNodePlaneamiento.Nodes.Add(0, "Grupo de Proceso de Iniciación")
        'tnInicioVS.Nodes.Add(0, "Nuevo Proyecto Preliminar").Tag = "INI_nuevo"

        'With frmFichaUsuarioCaja

        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        'End With
    End Sub

    Public Sub LoadPuntoVenta()
        tvOperaciones.Nodes.Clear()

        Dim newNodePlaneamiento As TreeNode = tvOperaciones.Nodes.Add(0, "Módulo Punto de venta")

        Dim tnEjecucionVS As TreeNode = newNodePlaneamiento.Nodes.Add(0, "Grupo de Proceso de Ejecución") '.Tag = "ejecucion"

        Dim TNVentas As TreeNode = tnEjecucionVS.Nodes.Add(0, "Puntos de Venta")
        TNVentas.Nodes.Add(0, "Registro de ventas/Ticket").Tag = "PV_REG"
        TNVentas.Nodes.Add(0, "Registro de venta/Ticket directo").Tag = "PV_REG_GEN"
    End Sub

    Public Sub LoadCaja()
        tvOperaciones.Nodes.Clear()
        Dim newNodeConfiguracion As TreeNode = tvOperaciones.Nodes.Add(0, "Configuraciones")
        newNodeConfiguracion.Tag = "CONF"
        Dim newNodePlaneamiento As TreeNode = tvOperaciones.Nodes.Add(0, "Soporte Contable")

        '     Dim tnEjecucionVS As TreeNode = newNodePlaneamiento.Nodes.Add(0, "Grupo de Proceso de Ejecución") '.Tag = "ejecucion"
        Dim TNCompras As TreeNode = newNodePlaneamiento.Nodes.Add(0, "Gestión de adquisiciones")
        'TNCompras.Nodes.Add(0, "Registro de compras/Al crédito").Tag = "GEJ_COMPRAS"
        TNCompras.Nodes.Add(0, "Registro de compras").Tag = "GEJ_COMPRAS_PAG"

        TNCompras.Nodes.Add(0, "Notas de Crédito").Tag = "GEJ_NCREDITO"
        TNCompras.Nodes.Add(0, "Notas de Débito").Tag = "GEJ_NDEBITO"
        TNCompras.Nodes.Add(0, "Reportes").Tag = "GEJ_REPORTES"

        Dim TNAportes As TreeNode = newNodePlaneamiento.Nodes.Add(0, "Aportes")
        TNAportes.Nodes.Add(0, "Nuevo Aporte").Tag = "APT_EX"
        TNAportes.Nodes.Add(0, "Registro de Aportes").Tag = "GEJ_APORTES_PAG"
        TNAportes.Nodes.Add(0, "Reportes").Tag = "APORTES_REP"

        Dim TNnAlmacen As TreeNode = newNodePlaneamiento.Nodes.Add(0, "Logística")
        TNnAlmacen.Nodes.Add(0, "Productos en tránsito").Tag = "LG_TRSN"
        TNnAlmacen.Nodes.Add(0, "Kardex General").Tag = "LG_KDX"
        TNnAlmacen.Nodes.Add(0, "Productos por Almacén").Tag = "LG_ALM"
        TNnAlmacen.Nodes.Add(0, "Listado de precios").Tag = "LG_PRECIO"
        TNnAlmacen.Nodes.Add(0, "Otros movimientos de almacén").Tag = "LG_OEA"
        '    TNnAlmacen.Nodes.Add(0, "Otras Sálidas a almacén").Tag = "LG_OSA"

        Dim TNCajaBancos As TreeNode = newNodePlaneamiento.Nodes.Add(0, "Caja y Bancos")
        TNCajaBancos.Nodes.Add(0, "Caja on-line").Tag = "CB_LINE"
        TNCajaBancos.Nodes.Add(0, "Gestión de Cajas").Tag = "CB_CAJAS"
        TNCajaBancos.Nodes.Add(0, "Confirmar Pedidos/Ticket").Tag = "CB_TICKET"
        TNCajaBancos.Nodes.Add(0, "Cuentas por pagar").Tag = "CB_PAGOS"
        TNCajaBancos.Nodes.Add(0, "Cuentas por cobrar").Tag = "CB_COBRO"
        TNCajaBancos.Nodes.Add(0, "Otros conceptos por cobrar").Tag = "CB_COBRO_OTROS"
        TNCajaBancos.Nodes.Add(0, "Otros movimientos de caja").Tag = "CB_OTROS_MOV"

        Dim TNVentas As TreeNode = newNodePlaneamiento.Nodes.Add(0, "Puntos de Venta")
        TNVentas.Nodes.Add(0, "Registro de ventas/Ticket").Tag = "PV_REG"
        TNVentas.Nodes.Add(0, "Registro de venta/Ticket directo").Tag = "PV_REG_GEN"
        TNVentas.Nodes.Add(0, "Ventas Generales").Tag = "PV_GNRAL"
        TNVentas.Nodes.Add(0, "Análisis de rentabilidad").Tag = "PV_RENTA"
        TNVentas.Nodes.Add(0, "Reporte de ventas").Tag = "PV_REPORTE"

        Dim TNLibroDiario As TreeNode = newNodePlaneamiento.Nodes.Add(0, "Libro Diario")
        TNLibroDiario.Nodes.Add(0, "Ver Libro Diario").Tag = "PLD_Libro"
        TNLibroDiario.Nodes.Add(0, "Reporte Libro Diario").Tag = "PLD_RepLibro"
        TNLibroDiario.Nodes.Add(0, "Reportes Contables").Tag = "PLD_RepCont"
    End Sub

    Public Sub LoadProcesosTree(ByVal strCAso As String)
        tvOperaciones.Nodes.Clear()
        'Dim newNodeAlmacen As TreeNode = New TreeNode("Empresas")
        'newNodeAlmacen.Nodes.Add("Nuevo/Listado de Empresas").Tag = "GE"
        'newNodeAlmacen.Nodes.Add("Cambiar sesión de empresa")

        'tvOperaciones.Nodes.Add(newNodeAlmacen)

        'Dim newNodeCompras As TreeNode = New TreeNode("Establecimientos")
        'newNodeCompras.Nodes.Add("Nuevo/Listado de establecimientos").Tag = "LET"
        'tvOperaciones.Nodes.Add(newNodeCompras)

        'Dim newNodeTablas As TreeNode = New TreeNode("Tablas Generales")
        'tvOperaciones.Nodes.Add(newNodeTablas)


        'Dim newNodeExistencia As TreeNode = New TreeNode("Gestion de Existencias")
        'newNodeExistencia.Nodes.Add("Mercaderia").Tag = "01"
        'newNodeExistencia.Nodes.Add("Producto Terminado").Tag = "02"
        'newNodeExistencia.Nodes.Add("Materias Primas").Tag = "03"
        'newNodeExistencia.Nodes.Add("Envases y Embalajes").Tag = "04"
        'newNodeExistencia.Nodes.Add("Materiales auxliares, sum...").Tag = "05"
        'newNodeExistencia.Nodes.Add("Sub Productos desechos y desperdicios").Tag = "06"
        'newNodeExistencia.Nodes.Add("Clasificacion de Productos/Items").Tag = "CLAS"
        'tvOperaciones.Nodes.Add(newNodeExistencia)
        'Dim newNodeUser As TreeNode = New TreeNode("Configuración de Usuario")
        'newNodeUser.Tag = "CONF_USER"
        'tvOperaciones.Nodes.Add(newNodeUser)

        Dim newNodePlaneamiento As TreeNode = tvOperaciones.Nodes.Add(0, "Dirección de Proyectos P.M.O.")

        Dim tnInicioVS As TreeNode = newNodePlaneamiento.Nodes.Add(0, "Grupo de Proceso de Iniciación")

        '  tnInicioVS.Nodes.Add(0, "Acta de Constitución").Tag = "INI_acta"
        Dim tnActaVS As TreeNode = tnInicioVS.Nodes.Add(0, "Acta de Constitución")
        tnActaVS.Nodes.Add(0, "Nuevo Proyecto Preliminar").Tag = "INI_nuevo"
        tnActaVS.Nodes.Add(0, "Gestión de Actas").Tag = "INI_gst"
        tnActaVS.Nodes.Add(0, "Información General").Tag = "INI_acta_adic"
        tnActaVS.Nodes.Add(0, "Gastos, cotización, E.D.T.").Tag = "INI_acta"

        tnInicioVS.Nodes.Add(0, "Importar Datos desde Excel").Tag = "INI_Importar_acta"
        tnInicioVS.Nodes.Add(0, "Repositorio de documentos").Tag = "INI_repo"
        tnInicioVS.Nodes.Add(0, "Liquidación Tributaria").Tag = "INI_reportes"
        'tnInicioVS.Nodes.Add(0, "Planilla").Tag = "INI_planilla"

        Dim newNodePlanilla As TreeNode = tnInicioVS.Nodes.Add(0, "Planilla")
        newNodePlanilla.Nodes.Add(0, "Planilla").Tag = "INI_planilla"
        newNodePlanilla.Nodes.Add(0, "Mantenimiento Cargo").Tag = "INI_cargo"
        newNodePlanilla.Nodes.Add(0, "Mantenimiento ingresoSunat").Tag = "INI_ingresoSunat"

        Select Case strCAso
            Case "1"
                Dim tnPlanificacionVS As TreeNode = newNodePlaneamiento.Nodes.Add(0, "Grupo de Proceso de Planificación") '.Tag = "planificacion"
                tnPlanificacionVS.Nodes.Add(0, "Creación de Fases, entregables y actividades").Tag = "PLF_INI"
            Case "2"
                Dim tnPlanificacionVS As TreeNode = newNodePlaneamiento.Nodes.Add(0, "Grupo de Proceso de Planificación") '.Tag = "planificacion"
                tnPlanificacionVS.Nodes.Add(0, "Creación de Fases, entregables y actividades").Tag = "PLF_INI"
                tnPlanificacionVS.Nodes.Add(0, "Agrupación").Tag = "PLF_AGR"
                tnPlanificacionVS.Nodes.Add(0, "Gestión Recursos Humanos").Tag = "PLF_RRHH"
                tnPlanificacionVS.Nodes.Add(0, "Ingreso").Tag = "PLF_ING"
                tnPlanificacionVS.Nodes.Add(0, "Cadena de Suministro").Tag = "PLF_CS"
                tnPlanificacionVS.Nodes.Add(0, "O.C. Existencias/Gastos").Tag = "PLF_Compras"

                Dim tnEjecucionVS As TreeNode = newNodePlaneamiento.Nodes.Add(0, "Grupo de Proceso de Ejecución") '.Tag = "ejecucion"
                Dim TNCompras As TreeNode = tnEjecucionVS.Nodes.Add(0, "Gestión de adquisiciones")
                'TNCompras.Nodes.Add(0, "Registro de compras/Al crédito").Tag = "GEJ_COMPRAS"
                TNCompras.Nodes.Add(0, "Registro de compras").Tag = "GEJ_COMPRAS_PAG"
                TNCompras.Nodes.Add(0, "Notas de Crédito").Tag = "GEJ_NCREDITO"
                TNCompras.Nodes.Add(0, "Notas de Débito").Tag = "GEJ_NDEBITO"
                TNCompras.Nodes.Add(0, "Reportes").Tag = "GEJ_REPORTES"

                Dim TNnAlmacen As TreeNode = tnEjecucionVS.Nodes.Add(0, "Logística")
                TNnAlmacen.Nodes.Add(0, "Productos en tránsito").Tag = "LG_TRSN"
                TNnAlmacen.Nodes.Add(0, "Kardex General").Tag = "LG_KDX"
                TNnAlmacen.Nodes.Add(0, "Productos por Almacén").Tag = "LG_ALM"
                TNnAlmacen.Nodes.Add(0, "Listado de precios").Tag = "LG_PRECIO"
                TNnAlmacen.Nodes.Add(0, "Otros movimientos de almacén").Tag = "LG_OEA"
                '      TNnAlmacen.Nodes.Add(0, "Otras Sálidas a almacén").Tag = "LG_OSA"

                Dim TNCajaBancos As TreeNode = tnEjecucionVS.Nodes.Add(0, "Caja y Bancos")
                TNCajaBancos.Nodes.Add(0, "Caja on-line").Tag = "CB_LINE"
                TNCajaBancos.Nodes.Add(0, "Gestión de Cajas").Tag = "CB_CAJAS"
                TNCajaBancos.Nodes.Add(0, "Confirmar Pedidos/Ticket").Tag = "CB_TICKET"
                TNCajaBancos.Nodes.Add(0, "Cuentas por pagar").Tag = "CB_PAGOS"
                TNCajaBancos.Nodes.Add(0, "Cuentas por cobrar").Tag = "CB_COBRO"
                TNCajaBancos.Nodes.Add(0, "Otros conceptos por cobrar").Tag = "CB_COBRO_OTROS"
                TNCajaBancos.Nodes.Add(0, "Otros movimientos de caja").Tag = "CB_OTROS_MOV"


                Dim TNVentas As TreeNode = tnEjecucionVS.Nodes.Add(0, "Puntos de Venta")
                TNVentas.Nodes.Add(0, "Registro de ventas/Ticket").Tag = "PV_REG"
                TNVentas.Nodes.Add(0, "Registro de venta/Ticket directo").Tag = "PV_REG_GEN"
                TNVentas.Nodes.Add(0, "Ventas Generales").Tag = "PV_GNRAL"
                TNVentas.Nodes.Add(0, "Análisis de rentabilidad").Tag = "PV_RENTA"


            
        End Select



        Dim tnControlVS As TreeNode = newNodePlaneamiento.Nodes.Add(0, "Grupo de Proceso de Monitoreo y Control") '.Tag = "control"

        Dim tncierrelVS As TreeNode = newNodePlaneamiento.Nodes.Add(0, "Grupo de Proceso de Cierre") '.Tag = "cierre"


    End Sub
#End Region

    Private Sub lblPeriodo_Click(sender As System.Object, e As System.EventArgs)
        'Me.Cursor = Cursors.WaitCursor

        'Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
        'datos.Clear()
        'With frmModalPeriodos
        '    .ObtenerAniosPorEmpresa(CEmpresa)
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    If datos.Count > 0 Then
        '        lblPeriodo.Text = datos(0).NombreCampo
        '        lblPeriodo.Text = datos(0).NombreCampo
        '        cAnioPeriodo = datos(0).NombreCampo
        '        CheckForm(frmMantenimientoCompras)
        '    Else
        '        '   MsgBox("Debe ingresar un comprobante.", MsgBoxStyle.Information, "Atención!")
        '        '   btnAgregarProv_Click(sender, e)
        '    End If
        'End With
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub frmPMO_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            Dispose()
            Application.Exit()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmPMO_Layout(sender As Object, e As System.Windows.Forms.LayoutEventArgs) Handles Me.Layout

    End Sub
    Sub LoadCMBAnios()
        For i = Year(Now) - 7 To Year(Now) + 12
            cboAnios.Items.Add(i)
        Next
    End Sub
    Private Sub frmPMO_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        ToolStrip3.RenderMode = ToolStripRenderMode.ManagerRenderMode
        PanelPlanificacion.Height = 26
        LoadPeriodos()
        LoadCMBAnios()
        toolAnio.Visible = False
        '    LoadTree()
        '  lblDescripcionEmpresa.Text = CEmpresa & ", " & CNombreEmpresa

        'Me.Panel3.HorizontalScroll.Visible = True
        ''-- Scroll Vertical
        'Me.Panel3.VerticalScroll.Visible = True
        

        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
    End Sub

    Private Sub tvOperaciones_AfterSelect(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs)

        If Not IsNothing(tvOperaciones.SelectedNode) Then
            If tvOperaciones.SelectedNode.Text = "Grupo de Proceso de Planificación" Then
                PanelPlanificacion.Visible = True
                PanelPlanificacion.Height = 26
                If Not IsNothing(GProyectos.ModoTrabajo) Then
                    GModoTRabajos = New GModoTrabajo
                    '    LinkLabel3.Text = GProyectos.ModoTrabajo
                    lblEstado.Text = "Grupo de Proceso: Planificación"
                    IdModoTRabajo()
                    GModoTRabajos.Modulo = GProyectos.ModoTrabajo
                    GModoTRabajos.IdActividad = GProyectos.IdActividadTrabajo
                Else
                    '    LinkLabel3.Text = "Modo trabajo"
                End If
            ElseIf Not IsNothing(tvOperaciones.SelectedNode.Parent) Then
                If tvOperaciones.SelectedNode.Parent.Text = "Grupo de Proceso de Planificación" Then
                    PanelPlanificacion.Visible = True
                    PanelPlanificacion.Height = 26
                    If Not IsNothing(GProyectos.ModoTrabajo) Then
                        '      LinkLabel3.Text = GProyectos.ModoTrabajo
                        IdModoTRabajo()
                        GModoTRabajos = New GModoTrabajo
                        GModoTRabajos.Modulo = GProyectos.ModoTrabajo
                        GModoTRabajos.IdActividad = GProyectos.IdActividadTrabajo
                    Else
                        '      LinkLabel3.Text = "Modo trabajo"
                    End If
                Else
                    lblTitulo.Text = "Proyecto preliminar"
                    lblEstado.Text = "Grupo de Proceso: Inicio"
                    PanelPlanificacion.Height = 26 '0
                    'lblTitulo.Visible = True
                    'LinkLabel3.Visible = True
                    'lblVerActividad.Visible = True
                End If
            Else
                lblTitulo.Text = "Proyecto preliminar"
                lblEstado.Text = "Grupo de Proceso: Inicio"
                PanelPlanificacion.Height = 26 '0
                'lblTitulo.Visible = True
                'LinkLabel3.Visible = True
                'lblVerActividad.Visible = True
            End If
        End If
    End Sub

    Private Sub tvOperaciones_DrawNode(sender As Object, e As System.Windows.Forms.DrawTreeNodeEventArgs)
        If e.State = (TreeNodeStates.Selected Or TreeNodeStates.Focused) Then
            e.Graphics.FillRectangle(Brushes.YellowGreen, e.Bounds)
            e.Graphics.DrawString(e.Node.Text, New Font("Tahoma", 8), Brushes.White, e.Bounds)
        Else
            e.DrawDefault = True
            '  e.Graphics.DrawString(e.Node.Text, New Font("Tahoma", 8), Brushes.DimGray, e.Bounds)
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        Try
            Dispose()
            Application.Exit()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub tvOperaciones_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(tvOperaciones.SelectedNode) Then
            Panel3.Width = 249
            If tvOperaciones.SelectedNode.Text = "Nuevo/Listado de Empresas" Then
                Me.lblEstado.Image = My.Resources.ok4  'Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\cross.png")
                Me.lblEstado.Text = "Selección: " & tvOperaciones.SelectedNode.Text
            Else
                Me.lblEstado.Image = My.Resources.ok4  'Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\cross.png")
                Me.lblEstado.Text = "Selección: " & tvOperaciones.SelectedNode.Text
                If Not QCompositeText2.Title = "" Then
                    Panel4.Controls.Clear()
                    If tvOperaciones.SelectedNode.Tag = "INI_nuevo" Then

                        With FormProyectoNuevo
                            Modpreliminar = Modulo_Preliminar.BASICO
                            TmpAction = ENTITY_ACTIONS.INSERT
                            .lblTitulo.Text = "Proyectos: Nuevo Ingreso"
                            .confNuevo()
                            .MdiParent = Me
                            .Parent = Panel4
                            .WindowState = FormWindowState.Maximized
                            .StartPosition = FormStartPosition.CenterScreen
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Text = "Tablas Generales" Then
                        With frmMasterTabla
                            .MdiParent = Me
                            .Parent = Panel4
                            .WindowState = FormWindowState.Maximized
                            .StartPosition = FormStartPosition.CenterScreen
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "INI_gst" Then
                        With FormProyectoBuscar
                            .ObtenerProyectos()
                            .btnEditarCuenta.Enabled = True
                            .NuevoToolStripButton.Enabled = True
                            .MdiParent = Me
                            .Parent = Panel4
                            .WindowState = FormWindowState.Maximized
                            .StartPosition = FormStartPosition.CenterScreen
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "INI_acta" Then
                        Dim proyectoSA As New ProyectoPlaneacionSA
                        Dim proyecto As New ProyectoPlaneacion
                        With frmActaConstitucionMaster
                            .MdiParent = Me
                            .UbicarProyectoID(GProyectos.IdProyectoActividad)
                            .UbicarProyectoEstado(GProyectos.IdProyectoActividad)
                            .Timer1.Enabled = True
                            .Parent = Panel4
                            .WindowState = FormWindowState.Maximized
                            .StartPosition = FormStartPosition.CenterParent
                            .Show()

                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "INI_acta_adic" Then
                        With FormProyectoNuevo
                            Modpreliminar = Modulo_Preliminar.INTERMEDIO
                            TmpAction = ENTITY_ACTIONS.INSERT
                            .lblTitulo.Text = "Proyecto preliminar: Info General."
                            .UbicarProyectoID(GProyectos.IdProyectoActividad)
                            .ObtenerListaEquipoProyecto()
                            .ObtenerListaEquipoCliente()
                            .confNuevo2()
                            .MdiParent = Me
                            .Parent = Panel4
                            .WindowState = FormWindowState.Maximized
                            .StartPosition = FormStartPosition.CenterScreen
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "INI_Importar_acta" Then
                        With frmActaConstitucion
                            .UbicarProyectoID(GProyectos.IdProyectoActividad)
                            If (GModoProyecto = "Aprobado") Then
                                .TabPage2.Parent = Nothing
                            End If
                            .StartPosition = FormStartPosition.CenterParent
                            .ShowDialog()
                        End With

                    ElseIf tvOperaciones.SelectedNode.Tag = "INI_planilla" Then
                        With FrmMasterPlanilla
                            .MdiParent = Me
                            '.UbicarProyectoID(TmpIdProyecto)
                            '.ObtenerListaCotizacion("PRS")
                            '.ObtenerListaGasto("K", "INCIDENCIA DIRECTA")
                            '.ObtenerListaEDT("EDT")
                            '.UbicarProyectoEstado(TmpIdProyecto)
                            '.Timer1.Enabled = True


                            .Parent = Panel4
                            .WindowState = FormWindowState.Maximized
                            .StartPosition = FormStartPosition.CenterParent
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "INI_cargo" Then
                        With FrmMasterOcupacion
                            .MdiParent = Me
                            '.UbicarProyectoID(TmpIdProyecto)
                            '.ObtenerListaCotizacion("PRS")
                            '.ObtenerListaGasto("K", "INCIDENCIA DIRECTA")
                            '.ObtenerListaEDT("EDT")
                            '.UbicarProyectoEstado(TmpIdProyecto)
                            '.Timer1.Enabled = True

                            .ObtenerListaOcupacion(GEstableciento.IdEstablecimiento)
                            .Parent = Panel4
                            .WindowState = FormWindowState.Maximized
                            .StartPosition = FormStartPosition.CenterParent
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "INI_ingresoSunat" Then
                        With FrmDetalleIngresoSunat
                            .MdiParent = Me
                            '.UbicarProyectoID(TmpIdProyecto)
                            '.ObtenerListaCotizacion("PRS")
                            '.ObtenerListaGasto("K", "INCIDENCIA DIRECTA")
                            '.ObtenerListaEDT("EDT")
                            '.UbicarProyectoEstado(TmpIdProyecto)
                            '.Timer1.Enabled = True
                            .Parent = Panel4
                            .WindowState = FormWindowState.Maximized
                            .StartPosition = FormStartPosition.CenterParent
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "INI_reportes" Then
                        With frmMasterLiquidacion
                            .ObtenerLiquidacion()
                            .Calculos()
                            .StartPosition = FormStartPosition.CenterParent
                            .ShowDialog()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "PLF_INI" Then
                        With frmPlanGestionProyecto
                            .MdiParent = Me
                            .Parent = Panel4
                            .ObtenerListaEDT("EDT", "AP")
                            .ObtenerFases("FS", "AP")
                            .ObtenerListaActividades("AC", "AP")
                            '.ObtenerListaCotizacion("AP")
                            .TabPage1.Parent = .TabControl1
                            .TabPage2.Parent = .TabControl1
                            .TabPage5.Parent = .TabControl1
                            .TabPage6.Parent = Nothing
                            .TabPage3.Parent = Nothing
                            .TabPage4.Parent = Nothing
                            .StartPosition = FormStartPosition.CenterParent
                            .WindowState = FormWindowState.Maximized
                            .Show()
                        End With

                    ElseIf tvOperaciones.SelectedNode.Tag = "PLF_ING" Then
                        With frmPlanGestionProyecto
                            .MdiParent = Me
                            .Parent = Panel4
                            .TabPage1.Parent = Nothing
                            .TabPage2.Parent = Nothing
                            .TabPage3.Parent = Nothing
                            .TabPage4.Parent = .TabControl1
                            .TabPage5.Parent = Nothing
                            .TabPage6.Parent = Nothing
                            .GetListaGPlaneacionIngreso(GProyectos.IdModoTrabajo, GModoTRabajos.IdActividad)
                            .StartPosition = FormStartPosition.CenterParent
                            .WindowState = FormWindowState.Maximized
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "PLF_CS" Then
                        With frmPlanGestionProyecto
                            .MdiParent = Me
                            .Parent = Panel4
                            .TabPage1.Parent = Nothing
                            .TabPage2.Parent = Nothing
                            .TabPage3.Parent = .TabControl1
                            .TabPage4.Parent = Nothing
                            .TabPage5.Parent = Nothing
                            .TabPage6.Parent = Nothing
                            .ObtenerListaGasto(GProyectos.IdModoTrabajo, GModoTRabajos.IdActividad)
                            .StartPosition = FormStartPosition.CenterParent
                            .WindowState = FormWindowState.Maximized
                            .Show()
                        End With


                    ElseIf tvOperaciones.SelectedNode.Tag = "PLF_TRAB" Then
                        With frmAgrupacionActividades
                            .MdiParent = Me
                            .Parent = Panel4
                            .StartPosition = FormStartPosition.CenterParent
                            .WindowState = FormWindowState.Maximized
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "PLF_RRHH" Then
                        With frmGestionRecursosHumanos
                            .MdiParent = Me
                            .Parent = Panel4
                            .ObtenerListaEquipo(TIPO_ACTIVIDAD_MODULO.EQUIPO_PROYECTO)
                            .StartPosition = FormStartPosition.CenterParent
                            .WindowState = FormWindowState.Maximized
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "PLF_AGR" Then
                        With frmAgrupacionActividades
                            .StartPosition = FormStartPosition.CenterParent
                            .ShowDialog()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "PLF_Compras" Then
                        With frmMantenimientoCompras
                            Panel3.Width = 0
                            .MdiParent = Me
                            .Parent = Panel4
                            .StartPosition = FormStartPosition.CenterParent
                            .WindowState = FormWindowState.Maximized
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "GEJ_COMPRAS" Then
                        With frmMasterCompras
                            Panel3.Width = 0
                            Dim cfecha As Date = DateTime.Now.Date
                            '.lblPerido.Text = cfecha.Month & "/" & cfecha.Year
                            '.ListaCompras(cfecha.Month & "/" & cfecha.Year)
                            .MdiParent = Me
                            .Parent = Panel4
                            .StartPosition = FormStartPosition.CenterParent
                            .WindowState = FormWindowState.Maximized
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "GEJ_COMPRAS_PAG" Then
                        With frmMantenimientoComprasPagadas
                            Panel3.Width = 0
                            Dim cfecha As Date = DateTime.Now.Date
                            .lblPerido.Text = cfecha.Month & "/" & cfecha.Year
                            .ListaCompras(cfecha.Month & "/" & cfecha.Year)
                            .MdiParent = Me
                            .Parent = Panel4
                            .StartPosition = FormStartPosition.CenterParent
                            .WindowState = FormWindowState.Maximized
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "LG_TRSN" Then
                        With frmInventarioTransito
                            Panel3.Width = 0
                            .MdiParent = Me
                            .Parent = Panel4
                            .StartPosition = FormStartPosition.CenterParent
                            .WindowState = FormWindowState.Maximized
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "LG_KDX" Then
                        With frmKardex
                            Panel3.Width = 0
                            .MdiParent = Me
                            .Parent = Panel4
                            .StartPosition = FormStartPosition.CenterParent
                            .WindowState = FormWindowState.Maximized
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "LG_ALM" Then
                        With frmtotalAlmacen
                            Panel3.Width = 0
                            .MdiParent = Me
                            .Parent = Panel4
                            .StartPosition = FormStartPosition.CenterParent
                            .WindowState = FormWindowState.Maximized
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "LG_PRECIO" Then
                        With frmListaPreciosExistencias
                            Panel3.Width = 0
                            .MdiParent = Me
                            .Parent = Panel4
                            .StartPosition = FormStartPosition.CenterParent
                            .WindowState = FormWindowState.Maximized
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "GEJ_REPORTES" Then
                        With frmCompraPagada
                            Panel3.Width = 0
                            .MdiParent = Me
                            .Parent = Panel4
                            .StartPosition = FormStartPosition.CenterParent
                            .WindowState = FormWindowState.Maximized
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "CB_LINE" Then
                        With frmCajaOnline
                            Panel3.Width = 0
                            .MdiParent = Me
                            .Parent = Panel4
                            .StartPosition = FormStartPosition.CenterParent
                            .WindowState = FormWindowState.Maximized
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "CB_TICKET" Then

                        With frmPagoTicket
                            Panel3.Width = 0
                            .MdiParent = Me
                            .Parent = Panel4
                            Dim cfecha As Date = DateTime.Now.Date
                            .lblPerido.Text = cfecha.Month & "/" & cfecha.Year
                            .StartPosition = FormStartPosition.CenterParent
                            .WindowState = FormWindowState.Maximized
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "CB_COBRO" Then
                        With frmCuentasPorCobrar
                            Panel3.Width = 0
                            .MdiParent = Me
                            .Parent = Panel4
                            Dim cfecha As Date = DateTime.Now.Date
                            .lblPeriodo.Text = cfecha.Month & "/" & cfecha.Year
                            .StartPosition = FormStartPosition.CenterParent
                            .WindowState = FormWindowState.Maximized
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "PV_REG" Then
                        With frmMantenimientoVentaPagada
                            Panel3.Width = 0
                            Dim cfecha As Date = DateTime.Now.Date
                            .lblPerido.Text = cfecha.Month & "/" & cfecha.Year
                            .ListaVentas(cfecha.Month & "/" & cfecha.Year)
                            .MdiParent = Me
                            .Parent = Panel4
                            .StartPosition = FormStartPosition.CenterParent
                            .WindowState = FormWindowState.Maximized
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "PV_RENTA" Then
                        With frmRentabilidad
                            Panel3.Width = 0
                            Dim cfecha As Date = DateTime.Now.Date
                            .lblPeriodo.Text = cfecha.Month & "/" & cfecha.Year
                            .GenerarRentabilidad(cfecha.Month & "/" & cfecha.Year)
                            .MdiParent = Me
                            .Parent = Panel4
                            .StartPosition = FormStartPosition.CenterParent
                            .WindowState = FormWindowState.Maximized
                            .Show()
                        End With

                    ElseIf tvOperaciones.SelectedNode.Tag = "PV_REG_GEN" Then
                        With frmMantenimientoVentaDirecta
                            Panel3.Width = 0
                            Dim cfecha As Date = DateTime.Now.Date
                            .lblPerido.Text = String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & PeriodoGeneral
                            .ListaVentas(String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & PeriodoGeneral)
                            .MdiParent = Me
                            .Parent = Panel4
                            .StartPosition = FormStartPosition.CenterParent
                            .WindowState = FormWindowState.Maximized
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "PV_GNRAL" Then
                        With frmMasterVentaGeneral
                            Panel3.Width = 0
                            Dim cfecha As Date = DateTime.Now.Date
                            .lblPerido.Text = cfecha.Month & "/" & cfecha.Year
                            .ListaVentas(cfecha.Month & "/" & cfecha.Year)
                            .MdiParent = Me
                            .Parent = Panel4
                            .StartPosition = FormStartPosition.CenterParent
                            .WindowState = FormWindowState.Maximized
                            .Show()
                        End With
                ElseIf tvOperaciones.SelectedNode.Tag = "PV_REPORTE" Then
                    Dim cfecha As Date = DateTime.Now.Date
                    With frmReporteVentas
                        'Panel3.Width = 0
                        .lblPerido.Text = String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & PeriodoGeneral
                        'martin
                            .Dock = DockStyle.Fill
                        '''''''''''''''
                        .MdiParent = Me
                        .Parent = Panel4
                        .StartPosition = FormStartPosition.CenterParent
                        '  .WindowState = FormWindowState.Maximized
                        .Show()
                    End With
                End If

                Else
                If Not tvOperaciones.SelectedNode.Text = "Gestión de Establecimientos" Then
                    '   MsgBox("Seleccione un establecimiento!.", MsgBoxStyle.Information, "Atención!")
                    Me.lblEstado.Image = My.Resources.cross 'Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\cross.png")
                    Me.lblEstado.Text = "Debe seleccionar un establecimiento!."
                End If

                End If

            End If
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    'Private Sub LinkLabel2_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
    '    Me.Cursor = Cursors.WaitCursor
    '    Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
    '    datos.Clear()
    '    ' srtidevento = Nothing
    '    With frmModalProyectos
    '        .StartPosition = FormStartPosition.CenterParent
    '        .ShowDialog()

    '        If datos.Count > 0 Then
    '            ' limpiarCajasMantenimiento()
    '            txtIdProyecto.Text = datos(0).ID
    '            txtProyecto.Text = datos(0).NombreEntidad

    '            Dim objService = HeliosSEProxy.CrearProxyHELIOS()
    '            Dim objLista() As HeliosService.ProyectoPlaneacionBO

    '            objLista = objService.GetMostrarProyectosPorCodigo(txtIdProyecto.Text)

    '            txtDescripcion.Text = objLista(0).Descripcion  ' meta
    '            If objLista(0).EstadoCosto = "APE" Then
    '                DateTimePicker3.Value = objLista(0).FechaInicioAprob.Date  'lsvListaProyectos.SelectedItems(0).SubItems(5).Text
    '                DateTimePicker4.Value = objLista(0).FechaFinalAprob.Date  'lsvListaProyectos.SelectedItems(0).SubItems(6).Text

    '                lblDias.Text = (CDate(objLista(0).FechaFinalAprob.Date) - CDate(objLista(0).FechaInicioAprob.Date)).TotalDays
    '                lbldiasRestantes.Text = CInt((CDate(objLista(0).FechaFinalAprob.Date) - CDate(Date.Now.Date)).TotalDays)

    '                txtFechaInicio.MinDate = CDate(objLista(0).FechaInicioAprob).Date
    '                txtFechaInicio.MaxDate = CDate(objLista(0).FechaFinalAprob).Date

    '                txtfechaFin.MinDate = CDate(objLista(0).FechaInicioAprob).Date
    '                txtfechaFin.MaxDate = CDate(objLista(0).FechaFinalAprob).Date

    '                txtFechaInicio.Value = CDate(objLista(0).FechaInicioAprob).Date
    '                txtfechaFin.Value = CDate(objLista(0).FechaFinalAprob).Date

    '            Else
    '                DateTimePicker3.Value = objLista(0).FechaInicio.Date  'lsvListaProyectos.SelectedItems(0).SubItems(5).Text
    '                DateTimePicker4.Value = objLista(0).FechaFinal.Date  'lsvListaProyectos.SelectedItems(0).SubItems(6).Text

    '                lblDias.Text = (CDate(objLista(0).FechaFinal.Date) - CDate(objLista(0).FechaInicio.Date)).TotalDays
    '                lbldiasRestantes.Text = CInt((CDate(objLista(0).FechaFinal.Date) - CDate(Date.Now.Date)).TotalDays)

    '                txtFechaInicio.MinDate = CDate(objLista(0).FechaInicio).Date
    '                txtFechaInicio.MaxDate = CDate(objLista(0).FechaFinal).Date

    '                txtfechaFin.MinDate = CDate(objLista(0).FechaInicio).Date
    '                txtfechaFin.MaxDate = CDate(objLista(0).FechaFinal).Date

    '                txtFechaInicio.Value = CDate(objLista(0).FechaInicio).Date
    '                txtfechaFin.Value = CDate(objLista(0).FechaFinal).Date
    '            End If



    '            srtdireccion = objLista(0).Responsable


    '            txtDirectorProyecto.Text = datos(0).Appat
    '            Call MostrarCostos()
    '        Else
    '            txtIdProyecto.Text = String.Empty
    '            txtProyecto.Text = String.Empty
    '            limpiarCajasMantenimiento()

    '        End If
    '    End With
    '    Me.Cursor = Cursors.Arrow
    'End Sub

    Private Sub LinkLabel2_LinkClicked_1(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)
        With FrmDetalleIngresoSunat
            .ShowDialog()
        End With
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs)
        With FrmMasterOcupacion
            .ShowDialog()
        End With
    End Sub

    Private Sub Panel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Static parpadear As Boolean

        If Not parpadear Then
            lblEstado.ForeColor = lblEstado.BackColor
        Else
            lblEstado.ForeColor = SystemColors.WindowText
        End If

        parpadear = Not parpadear
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub LinkLabel3_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        '     LinkLabel3.ContextMenuStrip.Show(LinkLabel3, e.Location)
    End Sub

    Private Sub FASEToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FASEToolStripMenuItem.Click
        'If (LinkLabel3.Text = "Modo trabajo") Then
        '    FasesShow(GProyectos.IdProyectoActividad, TIPO_ACTIVIDAD_MODULO.FASE, "AP")
        'Else
        '    IdActividadMTAnt = GModoTRabajos.IdActividad
        '    EstadoMTAnt = GProyectos.IdModoTrabajo
        '    FasesShow(GProyectos.IdProyectoActividad, TIPO_ACTIVIDAD_MODULO.FASE, "AP")
        'End If

    End Sub

    Private Sub ENTREGABLEToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ENTREGABLEToolStripMenuItem.Click
        'If (LinkLabel3.Text = "Modo trabajo") Then
        '    FasesShow(GProyectos.IdProyectoActividad, TIPO_ACTIVIDAD_MODULO.ENTREGABLE, "AP")
        '    'LoadProcesosTree("2")
        'Else
        '    IdActividadMTAnt = GModoTRabajos.IdActividad
        '    EstadoMTAnt = GProyectos.IdModoTrabajo
        '    FasesShow(GProyectos.IdProyectoActividad, TIPO_ACTIVIDAD_MODULO.ENTREGABLE, "AP")
        '    'UpdateModoTrabajo(IdActividadMTAnt, EstadoMTAnt, TIPO_ACTIVIDAD_MODULO.ENTREGABLE)
        '    'LoadProcesosTree("2")
        'End If

    End Sub

    Private Sub ACTIVIDADToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ACTIVIDADToolStripMenuItem.Click
        'If (LinkLabel3.Text = "Modo trabajo") Then
        '    FasesShow(GProyectos.IdProyectoActividad, TIPO_ACTIVIDAD_MODULO.ACTIVIDAD, "AP")
        '    'LoadProcesosTree("2")
        'Else
        '    IdActividadMTAnt = GModoTRabajos.IdActividad
        '    EstadoMTAnt = GProyectos.IdModoTrabajo
        '    FasesShow(GProyectos.IdProyectoActividad, TIPO_ACTIVIDAD_MODULO.ACTIVIDAD, "AP")
        '    'UpdateModoTrabajo(IdActividadMTAnt, EstadoMTAnt, TIPO_ACTIVIDAD_MODULO.ACTIVIDAD)
        '    'LoadProcesosTree("2")
        'End If

    End Sub

    Private Sub PROYECTOToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PROYECTOToolStripMenuItem.Click
        IdActividadMTAnt = GModoTRabajos.IdActividad
        EstadoMTAnt = GProyectos.IdModoTrabajo
        FasesShow(GProyectos.IdProyectoActividad, TIPO_ACTIVIDAD_MODULO.PROYECTO, "AP")
        'UpdateModoTrabajo(IdActividadMTAnt, EstadoMTAnt, TIPO_ACTIVIDAD_MODULO.PROYECTO)
        'LoadProcesosTree("2")

    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        Static parpadear As Boolean

        If Not parpadear Then
            lblTitulo.ForeColor = lblTitulo.BackColor
        Else
            lblTitulo.ForeColor = SystemColors.WindowText
        End If

        parpadear = Not parpadear
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        'If (LinkLabel3.Text <> "Modo trabajo") Then
        '    With frmDetalleModoTrabajo
        '        .lblNombreProyecto.Text = GProyectos.NombreProyecto
        '        .ubicarModoTrabajo()
        '        .StartPosition = FormStartPosition.CenterParent
        '        .ShowDialog()
        '    End With
        'End If

    End Sub


    Private Sub QRibbonPanel1_ItemActivated(sender As System.Object, e As Qios.DevSuite.Components.QCompositeEventArgs) Handles QRibbonPanel1.ItemActivated

    End Sub

    Private Sub QRibbonPage1_DoubleClick(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub QRibbonLaunchBar4_ItemActivating(sender As Object, e As Qios.DevSuite.Components.QCompositeCancelEventArgs) Handles QRibbonLaunchBar4.ItemActivating
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
        datos.Clear()
        With frmModalEstablecimientoCaja
            .StrParametroCarga = "ET"
            .ObtenerEstablecimientos()
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            If datos.Count > 0 Then
                lblProyectoBase.Title = String.Empty
                Panel4.Controls.Clear()
                Timer1.Enabled = False
                LoadTree()
                Me.lblEstado.Image = My.Resources.ok4 'Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\cross.png")
                Me.lblEstado.Text = "Done Establecimiento!."
                QCompositeText2.Title = datos(0).NombreCampo
                Dim objEstableSA As New establecimientoSA()
                GEstableciento = GEstablecimiento.InstanceSingle()
                GEstableciento.Clear()
                With objEstableSA.UbicaEstablecimientoPorID(datos(0).ID)
                    GEstableciento.IdEstablecimiento = .idCentroCosto
                    GEstableciento.NombreEstablecimiento = .nombre
                    GEstableciento.TipoEstablecimiento = .TipoEstab
                    GEstableciento.Ubigeo = .ubigeo
                End With
                'TmpIdEstable = datos(0).ID
                'TmpNomEstable = datos(0).NombreCampo
            Else

            End If
        End With

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub QRProyecto_ItemActivating(sender As System.Object, e As Qios.DevSuite.Components.QCompositeCancelEventArgs) Handles QRProyecto.ItemActivating
        If e.Item.ItemName = "qcNuevoProyecto" Then
            MsgBox("Nuevo")
        ElseIf e.Item.ItemName = "qcmProyecto" Then
            ProyectoPrdeterminado()
        End If
    End Sub

    Sub ProyectoPrdeterminado()
        Me.Cursor = Cursors.WaitCursor
        If lblEStablecimiento.Title.Trim.Length > 0 Then
            Timer1.Enabled = False
            Me.lblEstado.Image = My.Resources.ok4 'Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\cross.png")
            Me.lblEstado.Text = "Done proyecto!."
            Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
            datos.Clear()
            With frmModalProyectos
                .ObtenerProyectosModal()
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
                If datos.Count > 0 Then
                    Timer2.Enabled = True
                    '  PanelPlanificacion.Height = 0
                    ' limpiarCajasMantenimiento()
                    Dim ProyectoSA As New ProyectoPlaneacionSA()
                    GProyectos = GProyecto.InstanceSingle()
                    GProyectos.Clear()
                    With ProyectoSA.UbicarProyecto(datos(0).IdEvento)
                        GProyectos.IdProyecto = datos(0).ID
                        GProyectos.IdProyectoActividad = .idProyecto
                        GProyectos.NombreProyecto = .nombreProyecto
                        GProyectos.DirectorProyecto = .responsable
                        GProyectos.NombreDirector = .NombreTrabajador
                        GProyectos.FechaInicio = .fechaInicio
                        GProyectos.FechaFin = .fechaFinal
                        Select Case .anotacionEstado
                            Case TIPO_ACTIVIDAD_MODULO.FASE
                                GProyectos.ModoTrabajo = "FASE"
                                GProyectos.IdModoTrabajo = TIPO_ACTIVIDAD_MODULO.FASE
                            Case (TIPO_ACTIVIDAD_MODULO.ENTREGABLE)
                                GProyectos.ModoTrabajo = "ENTREGABLE"
                                GProyectos.IdModoTrabajo = TIPO_ACTIVIDAD_MODULO.ENTREGABLE
                            Case TIPO_ACTIVIDAD_MODULO.ACTIVIDAD
                                GProyectos.ModoTrabajo = "ACTIVIDAD"
                                GProyectos.IdModoTrabajo = TIPO_ACTIVIDAD_MODULO.ACTIVIDAD
                            Case TIPO_ACTIVIDAD_MODULO.PROYECTO
                                GProyectos.ModoTrabajo = "PROYECTO"
                                GProyectos.IdModoTrabajo = TIPO_ACTIVIDAD_MODULO.PROYECTO
                        End Select
                        GProyectos.IdActividadTrabajo = .refDocAprobacion
                        If (.estadoCosto = "A") Then
                            GModoProyecto = "Aprobado"
                        ElseIf (.estadoCosto = "NA") Then
                            GModoProyecto = "NAprobado"
                        ElseIf (.estadoCosto = "D") Then
                            GModoProyecto = "NAprobado"
                        End If

                    End With
                    'TmpIdProyecto = datos(0).ID
                    'TmpProyecto = datos(0).NombreEntidad
                    '   TmpIdResponsable = datos(0).IdResponsable
                    lblProyecto.Title = GProyectos.NombreProyecto
                    If Not IsNothing(GProyectos.ModoTrabajo) Then
                        LoadProcesosTree("2")
                    Else
                        LoadProcesosTree("1")
                    End If

                End If
                Panel4.Controls.Clear()
                'frmActaConstitucionMaster.Dispose()
                'FormProyectoBuscar.Dispose()
                'FormProyectoNuevo.Dispose()
            End With
        Else
            Me.lblEstado.Image = My.Resources.cross 'Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\cross.png")
            Me.lblEstado.Text = "Debe seleccionar un establecimiento!."
            Timer1.Enabled = True
            Timer1.Interval = 500
            Timer1.Start()
        End If


        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub tvOperaciones_AfterSelect_1(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs)

    End Sub

    Private Sub QCompositeMenuItem4_ItemActivated(sender As System.Object, e As Qios.DevSuite.Components.QCompositeEventArgs)

    End Sub

    Private Sub tvOperaciones_DrawNode1(sender As Object, e As System.Windows.Forms.DrawTreeNodeEventArgs)
        If e.State = (TreeNodeStates.Selected Or TreeNodeStates.Focused) Then
            e.Graphics.FillRectangle(Brushes.YellowGreen, e.Bounds)
            e.Graphics.DrawString(e.Node.Text, New Font("Tahoma", 8), Brushes.White, e.Bounds)
        Else
            e.DrawDefault = True
            '  e.Graphics.DrawString(e.Node.Text, New Font("Tahoma", 8), Brushes.DimGray, e.Bounds)
        End If
    End Sub

    Private Sub QRibbonPage1_Activated(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub QCompositeMenuItem4_ItemActivated_1(sender As System.Object, e As Qios.DevSuite.Components.QCompositeEventArgs)

    End Sub

    Private Sub tvOperaciones_MouseDoubleClick1(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(tvOperaciones.SelectedNode) Then
            Panel3.Width = 249
            If tvOperaciones.SelectedNode.Text = "Nuevo/Listado de Empresas" Then
                Me.lblEstado.Image = My.Resources.ok4  'Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\cross.png")
                Me.lblEstado.Text = "Selección: " & tvOperaciones.SelectedNode.Text
            Else
                Me.lblEstado.Image = My.Resources.ok4  'Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\cross.png")
                Me.lblEstado.Text = "Selección: " & tvOperaciones.SelectedNode.Text
                If Not QCompositeText2.Title = "" Then
                    Panel4.Controls.Clear()
                    If tvOperaciones.SelectedNode.Tag = "INI_nuevo" Then

                        With FormProyectoNuevo
                            Modpreliminar = Modulo_Preliminar.BASICO
                            TmpAction = ENTITY_ACTIONS.INSERT
                            .lblTitulo.Text = "Proyectos: Nuevo Ingreso"
                            .confNuevo()
                            .MdiParent = Me
                            .Parent = Panel4
                            .WindowState = FormWindowState.Maximized
                            .StartPosition = FormStartPosition.CenterScreen
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Text = "Tablas Generales" Then
                        With frmMasterTabla
                            .MdiParent = Me
                            .Parent = Panel4
                            .WindowState = FormWindowState.Maximized
                            .StartPosition = FormStartPosition.CenterScreen
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "INI_gst" Then
                        With FormProyectoBuscar
                            .ObtenerProyectos()
                            .btnEditarCuenta.Enabled = True
                            .NuevoToolStripButton.Enabled = True
                            .MdiParent = Me
                            .Parent = Panel4
                            .WindowState = FormWindowState.Maximized
                            .StartPosition = FormStartPosition.CenterScreen
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "INI_acta" Then
                        Dim proyectoSA As New ProyectoPlaneacionSA
                        Dim proyecto As New ProyectoPlaneacion
                        With frmActaConstitucionMaster
                            .MdiParent = Me
                            .UbicarProyectoID(GProyectos.IdProyectoActividad)
                            .UbicarProyectoEstado(GProyectos.IdProyectoActividad)
                            .Timer1.Enabled = True
                            .Parent = Panel4
                            .WindowState = FormWindowState.Maximized
                            .StartPosition = FormStartPosition.CenterParent
                            .Show()

                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "INI_acta_adic" Then
                        With FormProyectoNuevo
                            Modpreliminar = Modulo_Preliminar.INTERMEDIO
                            TmpAction = ENTITY_ACTIONS.INSERT
                            .lblTitulo.Text = "Proyecto preliminar: Info General."
                            .UbicarProyectoID(GProyectos.IdProyectoActividad)
                            .ObtenerListaEquipoProyecto()
                            .ObtenerListaEquipoCliente()
                            .confNuevo2()
                            .MdiParent = Me
                            .Parent = Panel4
                            .WindowState = FormWindowState.Maximized
                            .StartPosition = FormStartPosition.CenterScreen
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "INI_Importar_acta" Then
                        With frmActaConstitucion
                            .UbicarProyectoID(GProyectos.IdProyectoActividad)
                            If (GModoProyecto = "Aprobado") Then
                                .TabPage2.Parent = Nothing
                            End If
                            .StartPosition = FormStartPosition.CenterParent
                            .ShowDialog()
                        End With

                    ElseIf tvOperaciones.SelectedNode.Tag = "INI_planilla" Then
                        With FrmMasterPlanilla
                            .MdiParent = Me
                            '.UbicarProyectoID(TmpIdProyecto)
                            '.ObtenerListaCotizacion("PRS")
                            '.ObtenerListaGasto("K", "INCIDENCIA DIRECTA")
                            '.ObtenerListaEDT("EDT")
                            '.UbicarProyectoEstado(TmpIdProyecto)
                            '.Timer1.Enabled = True


                            .Parent = Panel4
                            .WindowState = FormWindowState.Maximized
                            .StartPosition = FormStartPosition.CenterParent
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "INI_cargo" Then
                        With FrmMasterOcupacion
                            .MdiParent = Me
                            '.UbicarProyectoID(TmpIdProyecto)
                            '.ObtenerListaCotizacion("PRS")
                            '.ObtenerListaGasto("K", "INCIDENCIA DIRECTA")
                            '.ObtenerListaEDT("EDT")
                            '.UbicarProyectoEstado(TmpIdProyecto)
                            '.Timer1.Enabled = True

                            .ObtenerListaOcupacion(GEstableciento.IdEstablecimiento)
                            .Parent = Panel4
                            .WindowState = FormWindowState.Maximized
                            .StartPosition = FormStartPosition.CenterParent
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "INI_ingresoSunat" Then
                        With FrmDetalleIngresoSunat
                            .MdiParent = Me
                            '.UbicarProyectoID(TmpIdProyecto)
                            '.ObtenerListaCotizacion("PRS")
                            '.ObtenerListaGasto("K", "INCIDENCIA DIRECTA")
                            '.ObtenerListaEDT("EDT")
                            '.UbicarProyectoEstado(TmpIdProyecto)
                            '.Timer1.Enabled = True
                            .Parent = Panel4
                            .WindowState = FormWindowState.Maximized
                            .StartPosition = FormStartPosition.CenterParent
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "INI_reportes" Then
                        With frmMasterLiquidacion
                            .ObtenerLiquidacion()
                            .Calculos()
                            .StartPosition = FormStartPosition.CenterParent
                            .ShowDialog()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "PLF_INI" Then
                        With frmPlanGestionProyecto
                            .MdiParent = Me
                            .Parent = Panel4
                            .ObtenerListaEDT("EDT", "AP")
                            .ObtenerFases("FS", "AP")
                            .ObtenerListaActividades("AC", "AP")
                            '.ObtenerListaCotizacion("AP")
                            .TabPage1.Parent = .TabControl1
                            .TabPage2.Parent = .TabControl1
                            .TabPage5.Parent = .TabControl1
                            .TabPage6.Parent = Nothing
                            .TabPage3.Parent = Nothing
                            .TabPage4.Parent = Nothing
                            .StartPosition = FormStartPosition.CenterParent
                            .WindowState = FormWindowState.Maximized
                            .Show()
                        End With

                    ElseIf tvOperaciones.SelectedNode.Tag = "PLF_ING" Then
                        With frmPlanGestionProyecto
                            .MdiParent = Me
                            .Parent = Panel4
                            .TabPage1.Parent = Nothing
                            .TabPage2.Parent = Nothing
                            .TabPage3.Parent = Nothing
                            .TabPage4.Parent = .TabControl1
                            .TabPage5.Parent = Nothing
                            .TabPage6.Parent = Nothing
                            .GetListaGPlaneacionIngreso(GProyectos.IdModoTrabajo, GModoTRabajos.IdActividad)
                            .StartPosition = FormStartPosition.CenterParent
                            .WindowState = FormWindowState.Maximized
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "PLF_CS" Then
                        With frmPlanGestionProyecto
                            .MdiParent = Me
                            .Parent = Panel4
                            .TabPage1.Parent = Nothing
                            .TabPage2.Parent = Nothing
                            .TabPage3.Parent = .TabControl1
                            .TabPage4.Parent = Nothing
                            .TabPage5.Parent = Nothing
                            .TabPage6.Parent = Nothing
                            .ObtenerListaGasto(GProyectos.IdModoTrabajo, GModoTRabajos.IdActividad)
                            .StartPosition = FormStartPosition.CenterParent
                            .WindowState = FormWindowState.Maximized
                            .Show()
                        End With


                    ElseIf tvOperaciones.SelectedNode.Tag = "PLF_TRAB" Then
                        With frmAgrupacionActividades
                            .MdiParent = Me
                            .Parent = Panel4
                            .StartPosition = FormStartPosition.CenterParent
                            .WindowState = FormWindowState.Maximized
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "PLF_RRHH" Then
                        With frmGestionRecursosHumanos
                            .MdiParent = Me
                            .Parent = Panel4
                            .ObtenerListaEquipo(TIPO_ACTIVIDAD_MODULO.EQUIPO_PROYECTO)
                            .StartPosition = FormStartPosition.CenterParent
                            .WindowState = FormWindowState.Maximized
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "PLF_AGR" Then
                        With frmAgrupacionActividades
                            .StartPosition = FormStartPosition.CenterParent
                            .ShowDialog()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "PLF_Compras" Then
                        With frmMantenimientoCompras
                            Panel3.Width = 0
                            .MdiParent = Me
                            .Parent = Panel4
                            .StartPosition = FormStartPosition.CenterParent
                            .WindowState = FormWindowState.Maximized
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "GEJ_COMPRAS" Then
                        With frmMasterCompras
                            Panel3.Width = 0
                            Dim cfecha As Date = DateTime.Now.Date
                            '.lblPerido.Text = cfecha.Month & "/" & cfecha.Year
                            '.ListaCompras(cfecha.Month & "/" & cfecha.Year)
                            .MdiParent = Me
                            .Parent = Panel4
                            .StartPosition = FormStartPosition.CenterParent
                            .WindowState = FormWindowState.Maximized
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "GEJ_COMPRAS_PAG" Then
                        With frmMantenimientoComprasPagadas
                            Panel3.Width = 0
                            Dim cfecha As Date = DateTime.Now.Date
                            .lblPerido.Text = cfecha.Month & "/" & cfecha.Year
                            .ListaCompras(cfecha.Month & "/" & cfecha.Year)
                            .MdiParent = Me
                            .Parent = Panel4
                            .StartPosition = FormStartPosition.CenterParent
                            .WindowState = FormWindowState.Maximized
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "LG_TRSN" Then
                        With frmInventarioTransito
                            Panel3.Width = 0
                            .MdiParent = Me
                            .Parent = Panel4
                            .StartPosition = FormStartPosition.CenterParent
                            .WindowState = FormWindowState.Maximized
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "LG_KDX" Then
                        With frmKardex
                            Panel3.Width = 0
                            .MdiParent = Me
                            .Parent = Panel4
                            .StartPosition = FormStartPosition.CenterParent
                            .WindowState = FormWindowState.Maximized
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "LG_ALM" Then
                        With frmtotalAlmacen
                            Panel3.Width = 0
                            .MdiParent = Me
                            .Parent = Panel4
                            .StartPosition = FormStartPosition.CenterParent
                            .WindowState = FormWindowState.Maximized
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "LG_PRECIO" Then
                        With frmListaPreciosExistencias
                            Panel3.Width = 0
                            .MdiParent = Me
                            .Parent = Panel4
                            .StartPosition = FormStartPosition.CenterParent
                            .WindowState = FormWindowState.Maximized
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "GEJ_REPORTES" Then
                        With frmCompraPagada
                            Panel3.Width = 0
                            .MdiParent = Me
                            .Parent = Panel4
                            .StartPosition = FormStartPosition.CenterParent
                            .WindowState = FormWindowState.Maximized
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "CB_LINE" Then
                        With frmCajaOnline
                            Panel3.Width = 0
                            .MdiParent = Me
                            .Parent = Panel4
                            .StartPosition = FormStartPosition.CenterParent
                            .WindowState = FormWindowState.Maximized
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "CB_TICKET" Then

                        With frmPagoTicket
                            Panel3.Width = 0
                            .MdiParent = Me
                            .Parent = Panel4
                            Dim cfecha As Date = DateTime.Now.Date
                            .lblPerido.Text = cfecha.Month & "/" & cfecha.Year
                            .StartPosition = FormStartPosition.CenterParent
                            .WindowState = FormWindowState.Maximized
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "CB_COBRO" Then
                        With frmCuentasPorCobrar
                            Panel3.Width = 0
                            .MdiParent = Me
                            .Parent = Panel4
                            Dim cfecha As Date = DateTime.Now.Date
                            .lblPeriodo.Text = cfecha.Month & "/" & cfecha.Year
                            .StartPosition = FormStartPosition.CenterParent
                            .WindowState = FormWindowState.Maximized
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "PV_REG" Then
                        With frmMantenimientoVentaPagada
                            Panel3.Width = 0
                            Dim cfecha As Date = DateTime.Now.Date
                            .lblPerido.Text = cfecha.Month & "/" & cfecha.Year
                            .ListaVentas(cfecha.Month & "/" & cfecha.Year)
                            .MdiParent = Me
                            .Parent = Panel4
                            .StartPosition = FormStartPosition.CenterParent
                            .WindowState = FormWindowState.Maximized
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "PV_RENTA" Then
                        With frmRentabilidad
                            Panel3.Width = 0
                            Dim cfecha As Date = DateTime.Now.Date
                            .lblPeriodo.Text = cfecha.Month & "/" & cfecha.Year
                            .GenerarRentabilidad(cfecha.Month & "/" & cfecha.Year)
                            .MdiParent = Me
                            .Parent = Panel4
                            .StartPosition = FormStartPosition.CenterParent
                            .WindowState = FormWindowState.Maximized
                            .Show()
                        End With

                   

                    ElseIf tvOperaciones.SelectedNode.Tag = "PV_REG_GEN" Then
                        With frmMantenimientoVentaDirecta
                            Panel3.Width = 0
                            Dim cfecha As Date = DateTime.Now.Date
                            .lblPerido.Text = cfecha.Month & "/" & cfecha.Year
                            .ListaVentas(cfecha.Month & "/" & cfecha.Year)
                            .MdiParent = Me
                            .Parent = Panel4
                            .StartPosition = FormStartPosition.CenterParent
                            .WindowState = FormWindowState.Maximized
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "PV_GNRAL" Then
                        With frmMasterVentaGeneral
                            Panel3.Width = 0
                            Dim cfecha As Date = DateTime.Now.Date
                            .lblPerido.Text = cfecha.Month & "/" & cfecha.Year
                            .ListaVentas(cfecha.Month & "/" & cfecha.Year)
                            .MdiParent = Me
                            .Parent = Panel4
                            .StartPosition = FormStartPosition.CenterParent
                            .WindowState = FormWindowState.Maximized
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "PV_REPORTE" Then
                        Dim cfecha As Date = DateTime.Now.Date
                        With frmReporteVentas
                            'Panel3.Width = 0
                            .lblPerido.Text = String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & PeriodoGeneral
                            'martin
                            .Dock = DockStyle.Fill
                            '''''''''''''''
                            .MdiParent = Me
                            .Parent = Panel4
                            .StartPosition = FormStartPosition.CenterParent
                            '  .WindowState = FormWindowState.Maximized
                            .Show()
                        End With
                    End If



                Else
                    If Not tvOperaciones.SelectedNode.Text = "Gestión de Establecimientos" Then
                        '   MsgBox("Seleccione un establecimiento!.", MsgBoxStyle.Information, "Atención!")
                        Me.lblEstado.Image = My.Resources.cross 'Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\cross.png")
                        Me.lblEstado.Text = "Debe seleccionar un establecimiento!."
                    End If
                End If

            End If
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub QMenuItem1_MenuItemActivating(sender As System.Object, e As Qios.DevSuite.Components.QMenuCancelEventArgs) Handles QMenuItem1.MenuItemActivating
  
    End Sub

    Private Sub tvOperaciones_AfterSelect_2(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles tvOperaciones.AfterSelect

    End Sub

    Private Sub tvOperaciones_DrawNode2(sender As Object, e As System.Windows.Forms.DrawTreeNodeEventArgs) Handles tvOperaciones.DrawNode
        If e.State = (TreeNodeStates.Selected Or TreeNodeStates.Focused) Then
            e.Graphics.FillRectangle(Brushes.YellowGreen, e.Bounds)
            e.Graphics.DrawString(e.Node.Text, New Font("Tahoma", 8), Brushes.White, e.Bounds)
        Else
            e.DrawDefault = True
            '  e.Graphics.DrawString(e.Node.Text, New Font("Tahoma", 8), Brushes.DimGray, e.Bounds)
        End If
    End Sub

    Private Sub tvOperaciones_MouseCaptureChanged(sender As Object, e As System.EventArgs) Handles tvOperaciones.MouseCaptureChanged

    End Sub

    Private Sub tvOperaciones_MouseDoubleClick2(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles tvOperaciones.MouseDoubleClick
        Me.Cursor = Cursors.WaitCursor
        Try

        
        If Not IsNothing(tvOperaciones.SelectedNode) Then
            Panel3.Width = 249
            If tvOperaciones.SelectedNode.Text = "Nuevo/Listado de Empresas" Then
                Me.lblEstado.Image = My.Resources.ok4  'Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\cross.png")
                Me.lblEstado.Text = "Selección: " & tvOperaciones.SelectedNode.Text
            Else
                Me.lblEstado.Image = My.Resources.ok4  'Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\cross.png")
                Me.lblEstado.Text = "Selección: " & tvOperaciones.SelectedNode.Text
                If Not QCompositeText2.Title = "" Then
                    Panel4.Controls.Clear()
                    If tvOperaciones.SelectedNode.Tag = "INI_nuevo" Then

                        With FormProyectoNuevo
                            Modpreliminar = Modulo_Preliminar.BASICO
                            TmpAction = ENTITY_ACTIONS.INSERT
                            .lblTitulo.Text = "Proyectos: Nuevo Ingreso"
                            .confNuevo()
                            .MdiParent = Me
                            .Parent = Panel4
                            .WindowState = FormWindowState.Maximized
                            .StartPosition = FormStartPosition.CenterScreen
                            .Show()
                            End With
                        ElseIf tvOperaciones.SelectedNode.Tag = "CONF_USER" Then
                            With frmFichaUsuarioCaja
                                '.MdiParent = Me
                                '.Parent = Panel4
                                .StartPosition = FormStartPosition.CenterParent
                                .ShowDialog()
                            End With
                        ElseIf tvOperaciones.SelectedNode.Text = "Tablas Generales" Then
                            With frmMasterTabla
                                .MdiParent = Me
                                .Parent = Panel4
                                .WindowState = FormWindowState.Maximized
                                .StartPosition = FormStartPosition.CenterScreen
                                .Show()
                            End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "INI_gst" Then
                        With FormProyectoBuscar
                            .ObtenerProyectos()
                            .btnEditarCuenta.Enabled = True
                            .NuevoToolStripButton.Enabled = True
                            .MdiParent = Me
                            .Parent = Panel4
                            .WindowState = FormWindowState.Maximized
                            .StartPosition = FormStartPosition.CenterScreen
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "INI_acta" Then
                        Dim proyectoSA As New ProyectoPlaneacionSA
                        Dim proyecto As New ProyectoPlaneacion
                        With frmActaConstitucionMaster
                            .MdiParent = Me
                            .UbicarProyectoID(GProyectos.IdProyectoActividad)
                            .UbicarProyectoEstado(GProyectos.IdProyectoActividad)
                            .Timer1.Enabled = True
                            .Parent = Panel4
                            .WindowState = FormWindowState.Maximized
                            .StartPosition = FormStartPosition.CenterParent
                            .Show()

                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "INI_acta_adic" Then
                        With FormProyectoNuevo
                            Modpreliminar = Modulo_Preliminar.INTERMEDIO
                            TmpAction = ENTITY_ACTIONS.INSERT
                            .lblTitulo.Text = "Proyecto preliminar: Info General."
                            .UbicarProyectoID(GProyectos.IdProyectoActividad)
                            .ObtenerListaEquipoProyecto()
                            .ObtenerListaEquipoCliente()
                            .confNuevo2()
                            .MdiParent = Me
                            .Parent = Panel4
                            .WindowState = FormWindowState.Maximized
                            .StartPosition = FormStartPosition.CenterScreen
                            .Show()
                        End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "INI_Importar_acta" Then
                            'With frmActaConstitucion
                            '    .UbicarProyectoID(GProyectos.IdProyectoActividad)
                            '    If (GModoProyecto = "Aprobado") Then
                            '        .TabPage2.Parent = Nothing
                            '    End If
                            '    .StartPosition = FormStartPosition.CenterParent
                            '    .ShowDialog()
                            'End With

                    ElseIf tvOperaciones.SelectedNode.Tag = "INI_planilla" Then
                            'With FrmMasterPlanilla
                            '    .MdiParent = Me
                            '    '.UbicarProyectoID(TmpIdProyecto)
                            '    '.ObtenerListaCotizacion("PRS")
                            '    '.ObtenerListaGasto("K", "INCIDENCIA DIRECTA")
                            '    '.ObtenerListaEDT("EDT")
                            '    '.UbicarProyectoEstado(TmpIdProyecto)
                            '    '.Timer1.Enabled = True


                            '    .Parent = Panel4
                            '    .WindowState = FormWindowState.Maximized
                            '    .StartPosition = FormStartPosition.CenterParent
                            '    .Show()
                            'End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "INI_cargo" Then
                            'With FrmMasterOcupacion
                            '    .MdiParent = Me
                            '    '.UbicarProyectoID(TmpIdProyecto)
                            '    '.ObtenerListaCotizacion("PRS")
                            '    '.ObtenerListaGasto("K", "INCIDENCIA DIRECTA")
                            '    '.ObtenerListaEDT("EDT")
                            '    '.UbicarProyectoEstado(TmpIdProyecto)
                            '    '.Timer1.Enabled = True

                            '    .ObtenerListaOcupacion(GEstableciento.IdEstablecimiento)
                            '    .Parent = Panel4
                            '    .WindowState = FormWindowState.Maximized
                            '    .StartPosition = FormStartPosition.CenterParent
                            '    .Show()
                            'End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "INI_ingresoSunat" Then
                            'With FrmDetalleIngresoSunat
                            '    .MdiParent = Me
                            '    '.UbicarProyectoID(TmpIdProyecto)
                            '    '.ObtenerListaCotizacion("PRS")
                            '    '.ObtenerListaGasto("K", "INCIDENCIA DIRECTA")
                            '    '.ObtenerListaEDT("EDT")
                            '    '.UbicarProyectoEstado(TmpIdProyecto)
                            '    '.Timer1.Enabled = True
                            '    .Parent = Panel4
                            '    .WindowState = FormWindowState.Maximized
                            '    .StartPosition = FormStartPosition.CenterParent
                            '    .Show()
                            'End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "INI_reportes" Then
                            'With frmMasterLiquidacion
                            '    .ObtenerLiquidacion()
                            '    .Calculos()
                            '    .StartPosition = FormStartPosition.CenterParent
                            '    .ShowDialog()
                            'End With
                    ElseIf tvOperaciones.SelectedNode.Tag = "PLF_INI" Then
                        With frmPlanGestionProyecto
                            .MdiParent = Me
                            .Parent = Panel4
                            .ObtenerListaEDT("EDT", "AP")
                            .ObtenerFases("FS", "AP")
                            .ObtenerListaActividades("AC", "AP")
                            '.ObtenerListaCotizacion("AP")
                            .TabPage1.Parent = .TabControl1
                            .TabPage2.Parent = .TabControl1
                            .TabPage5.Parent = .TabControl1
                            .TabPage6.Parent = Nothing
                            .TabPage3.Parent = Nothing
                            .TabPage4.Parent = Nothing
                            .StartPosition = FormStartPosition.CenterParent
                            .WindowState = FormWindowState.Maximized
                            .Show()
                        End With

                    ElseIf tvOperaciones.SelectedNode.Tag = "PLF_ING" Then
                        With frmPlanGestionProyecto
                            .MdiParent = Me
                            .Parent = Panel4
                            .TabPage1.Parent = Nothing
                            .TabPage2.Parent = Nothing
                            .TabPage3.Parent = Nothing
                            .TabPage4.Parent = .TabControl1
                            .TabPage5.Parent = Nothing
                            .TabPage6.Parent = Nothing
                            .GetListaGPlaneacionIngreso(GProyectos.IdModoTrabajo, GModoTRabajos.IdActividad)
                            .StartPosition = FormStartPosition.CenterParent
                            .WindowState = FormWindowState.Maximized
                            .Show()
                        End With
                        ElseIf tvOperaciones.SelectedNode.Tag = "PLF_CS" Then
                            With frmPlanGestionProyecto
                                .MdiParent = Me
                                .Parent = Panel4
                                .TabPage1.Parent = Nothing
                                .TabPage2.Parent = Nothing
                                .TabPage3.Parent = .TabControl1
                                .TabPage4.Parent = Nothing
                                .TabPage5.Parent = Nothing
                                .TabPage6.Parent = Nothing
                                .ObtenerListaGasto(GProyectos.IdModoTrabajo, GModoTRabajos.IdActividad)
                                .StartPosition = FormStartPosition.CenterParent
                                .WindowState = FormWindowState.Maximized
                                .Show()
                            End With


                        ElseIf tvOperaciones.SelectedNode.Tag = "PLF_TRAB" Then
                            With frmAgrupacionActividades
                                .MdiParent = Me
                                .Parent = Panel4
                                .StartPosition = FormStartPosition.CenterParent
                                .WindowState = FormWindowState.Maximized
                                .Show()
                            End With
                        ElseIf tvOperaciones.SelectedNode.Tag = "PLF_RRHH" Then
                            With frmGestionRecursosHumanos
                                .MdiParent = Me
                                .Parent = Panel4
                                .ObtenerListaEquipo(TIPO_ACTIVIDAD_MODULO.EQUIPO_PROYECTO)
                                .StartPosition = FormStartPosition.CenterParent
                                .WindowState = FormWindowState.Maximized
                                .Show()
                            End With
                        ElseIf tvOperaciones.SelectedNode.Tag = "PLF_AGR" Then
                            With frmAgrupacionActividades
                                .StartPosition = FormStartPosition.CenterParent
                                .ShowDialog()
                            End With
                        ElseIf tvOperaciones.SelectedNode.Tag = "PLF_Compras" Then
                            With frmMantenimientoCompras
                                Panel3.Width = 0
                                .MdiParent = Me
                                .Parent = Panel4
                                .StartPosition = FormStartPosition.CenterParent
                                .WindowState = FormWindowState.Maximized
                                .Show()
                            End With
                        ElseIf tvOperaciones.SelectedNode.Tag = "CONF" Then
                            With frmConfigSistema
                                .MdiParent = Me
                                .Parent = Panel4
                                .Dock = DockStyle.Fill
                                .StartPosition = FormStartPosition.CenterParent
                                .Show()
                            End With
                        ElseIf tvOperaciones.SelectedNode.Tag = "GEJ_COMPRAS" Then
                            With frmMasterCompras
                                Panel3.Width = 0
                                Dim cfecha As Date = DateTime.Now.Date
                                '.lblPerido.Text = String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & cfecha.Year
                                '.ListaCompras(cfecha.Month & "/" & cfecha.Year)
                                .MdiParent = Me
                                .Parent = Panel4
                                .StartPosition = FormStartPosition.CenterParent
                                .WindowState = FormWindowState.Maximized
                                .Show()
                            End With
                        ElseIf tvOperaciones.SelectedNode.Tag = "GEJ_NCREDITO" Then
                            With frmNotaCredito
                                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                                Panel3.Width = 0
                                Dim cfecha As Date = DateTime.Now.Date
                                .MdiParent = Me
                                .Parent = Panel4
                                .StartPosition = FormStartPosition.CenterParent
                                .configuracionModulo(Gempresas.IdEmpresaRuc, .Tag, .Text)
                                '.WindowState = FormWindowState.Maximized
                                .Show()
                            End With
                        ElseIf tvOperaciones.SelectedNode.Tag = "GEJ_NDEBITO" Then
                            With frmNotaDebito
                                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                                Panel3.Width = 0
                                Dim cfecha As Date = DateTime.Now.Date
                                .MdiParent = Me
                                .Parent = Panel4
                                .StartPosition = FormStartPosition.CenterParent
                                '.WindowState = FormWindowState.Maximized
                                .Show()
                            End With
                        ElseIf tvOperaciones.SelectedNode.Tag = "GEJ_COMPRAS_PAG" Then
                            With frmMantenimientoComprasPagadas
                                Panel3.Width = 0
                                Dim cfecha As Date = DateTime.Now.Date
                                .lblPerido.Text = String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & PeriodoGeneral
                                .ListaCompras(String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & PeriodoGeneral)
                                .MdiParent = Me
                                .Parent = Panel4
                                .Dock = DockStyle.Fill
                                ' .StartPosition = FormStartPosition.CenterParent
                                '  .WindowState = FormWindowState.Maximized
                                .Show()
                            End With
                        ElseIf tvOperaciones.SelectedNode.Tag = "GEJ_APORTES_PAG" Then
                            With frmMasterAportes
                                Panel3.Width = 0
                                Dim cfecha As Date = DateTime.Now.Date
                                .lblPerido.Text = String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & PeriodoGeneral
                                '.lblPerido.Text = cfecha.Month & "/" & cfecha.Year
                                '.ListaCompras(cfecha.Month & "/" & cfecha.Year)
                                .MdiParent = Me
                                .Parent = Panel4
                                .StartPosition = FormStartPosition.CenterParent
                                .WindowState = FormWindowState.Maximized
                                .Show()
                            End With
                        ElseIf tvOperaciones.SelectedNode.Tag = "APORTES_REP" Then
                            With frmReporteAportes
                                'Panel3.Width = 0
                                Dim cfecha As Date = DateTime.Now.Date
                                .lblPerido.Text = String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & PeriodoGeneral
                                '.lblPerido.Text = cfecha.Month & "/" & cfecha.Year
                                '.ListaCompras(cfecha.Month & "/" & cfecha.Year)
                                .Dock = DockStyle.Fill
                                .MdiParent = Me
                                .Parent = Panel4
                                .StartPosition = FormStartPosition.CenterParent
                                '.WindowState = FormWindowState.Maximized
                                .Show()

                            End With
                        ElseIf tvOperaciones.SelectedNode.Tag = "APT_EX" Then
                            GConfiguracion = New GConfiguracionModulo
                            With frmAporteExcel
                                '   Panel3.Width = 0
                                Dim cfecha As Date = DateTime.Now.Date
                                'PeriodoGeneral = cfecha.Month & "/" & cfecha.Year
                                .lblPeriodo.Text = String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & PeriodoGeneral
                                '.ListaCompras(cfecha.Month & "/" & cfecha.Year)
                                '.MdiParent = Me
                                '.Parent = Panel4
                                .StartPosition = FormStartPosition.CenterParent
                                '   .WindowState = FormWindowState.Maximized
                                .configuracionModulo(Gempresas.IdEmpresaRuc, .Tag, .Text)
                                .Show()
                            End With
                        ElseIf tvOperaciones.SelectedNode.Tag = "LG_TRSN" Then
                            With frmInventarioTransito
                                Dim cfecha As Date = DateTime.Now.Date
                                .lblPerido.Text = String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & PeriodoGeneral
                                Panel3.Width = 0
                                .MdiParent = Me
                                .Parent = Panel4
                                .StartPosition = FormStartPosition.CenterParent
                                .WindowState = FormWindowState.Maximized
                                .Show()
                            End With
                        ElseIf tvOperaciones.SelectedNode.Tag = "LG_OEA" Then
                            With frmMantenimientoOtrasEntradas
                                Dim cfecha As Date = DateTime.Now.Date
                                .lblPerido.Text = String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & PeriodoGeneral
                                Panel3.Width = 0
                                .ListaEntradas(.lblPerido.Text)
                                .MdiParent = Me
                                .Parent = Panel4
                                .StartPosition = FormStartPosition.CenterParent
                                .WindowState = FormWindowState.Maximized
                                .Show()
                            End With
                        ElseIf tvOperaciones.SelectedNode.Tag = "LG_OSA" Then
                            With frmMantenimientoOtrasSalidas
                                Dim cfecha As Date = DateTime.Now.Date
                                .lblPerido.Text = String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & PeriodoGeneral
                                Panel3.Width = 0
                                .ListaSalidas(.lblPerido.Text)
                                .MdiParent = Me
                                .Parent = Panel4
                                .StartPosition = FormStartPosition.CenterParent
                                .WindowState = FormWindowState.Maximized
                                .Show()
                            End With
                        ElseIf tvOperaciones.SelectedNode.Tag = "LG_KDX" Then
                            With frmKardex
                                Panel3.Width = 0
                                .MdiParent = Me
                                .Parent = Panel4
                                .StartPosition = FormStartPosition.CenterParent
                                .WindowState = FormWindowState.Maximized
                                .Show()
                            End With
                        ElseIf tvOperaciones.SelectedNode.Tag = "LG_ALM" Then
                            With frmtotalAlmacen
                                Panel3.Width = 0
                                .MdiParent = Me
                                .Parent = Panel4
                                .StartPosition = FormStartPosition.CenterParent
                                .WindowState = FormWindowState.Maximized
                                .Show()
                            End With
                        ElseIf tvOperaciones.SelectedNode.Tag = "LG_PRECIO" Then
                            With frmListaPreciosExistencias
                                Panel3.Width = 0
                                .MdiParent = Me
                                .Parent = Panel4
                                .StartPosition = FormStartPosition.CenterParent
                                .WindowState = FormWindowState.Maximized
                                .Show()
                            End With
                        ElseIf tvOperaciones.SelectedNode.Tag = "GEJ_REPORTES" Then
                            Dim cfecha As Date = DateTime.Now.Date
                            With frmReporteCompras
                                'Panel3.Width = 0
                                .lblPerido.Text = String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & PeriodoGeneral
                                'martin
                                .WindowState = FormWindowState.Maximized
                                '''''''''''''''
                                .MdiParent = Me
                                .Parent = Panel4
                                .StartPosition = FormStartPosition.CenterParent
                                '  .WindowState = FormWindowState.Maximized
                                .Show()
                            End With
                        ElseIf tvOperaciones.SelectedNode.Tag = "CB_LINE" Then
                            Dim cfecha As Date = DateTime.Now.Date
                            With frmCajaOnline
                                .lblPeriodo.Text = String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & cfecha.Year
                                Panel3.Width = 0
                                .MdiParent = Me
                                .Parent = Panel4
                                .StartPosition = FormStartPosition.CenterParent
                                .WindowState = FormWindowState.Maximized
                                .Show()
                            End With
                        ElseIf tvOperaciones.SelectedNode.Tag = "CB_CAJAS" Then
                            Dim cfecha As Date = DateTime.Now.Date
                            With frmMantenimientoCajas
                                Panel3.Width = 0
                                .lblPerido.Text = String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & PeriodoGeneral
                                .MdiParent = Me
                                .Parent = Panel4
                                .StartPosition = FormStartPosition.CenterParent
                                .WindowState = FormWindowState.Maximized
                                .Show()
                            End With
                        ElseIf tvOperaciones.SelectedNode.Tag = "CB_TICKET" Then

                            With frmPagoTicket
                                Panel3.Width = 0
                                .MdiParent = Me
                                .Parent = Panel4
                                Dim cfecha As Date = DateTime.Now.Date
                                .lblPerido.Text = String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & cfecha.Year
                                .StartPosition = FormStartPosition.CenterParent
                                .WindowState = FormWindowState.Maximized
                                .Show()
                            End With
                        ElseIf tvOperaciones.SelectedNode.Tag = "CB_COBRO" Then
                            With frmCuentasPorCobrar
                                Panel3.Width = 0
                                .MdiParent = Me
                                .Parent = Panel4
                                Dim cfecha As Date = DateTime.Now.Date
                                .lblPeriodo.Text = String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & cfecha.Year
                                .StartPosition = FormStartPosition.CenterParent
                                .WindowState = FormWindowState.Maximized
                                .Show()
                            End With
                        ElseIf tvOperaciones.SelectedNode.Tag = "CB_COBRO_OTROS" Then
                            With frmOtrasCuentasPorCobrar
                                Panel3.Width = 0
                                .MdiParent = Me
                                .Parent = Panel4
                                Dim cfecha As Date = DateTime.Now.Date
                                .lblPeriodo.Text = String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & PeriodoGeneral
                                .StartPosition = FormStartPosition.CenterParent
                                .WindowState = FormWindowState.Maximized
                                .Show()
                            End With

                        ElseIf tvOperaciones.SelectedNode.Tag = "CB_OTROS_MOV" Then
                            With frmMantenimientoCaja
                                Panel3.Width = 0
                                .MdiParent = Me
                                .Parent = Panel4
                                Dim cfecha As Date = DateTime.Now.Date
                                .lblPeriodo.Text = String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & PeriodoGeneral
                                .ListadoMovimientos(.lblPeriodo.Text)
                                .StartPosition = FormStartPosition.CenterParent
                                .WindowState = FormWindowState.Maximized
                                .Show()
                            End With

                        ElseIf tvOperaciones.SelectedNode.Tag = "CB_PAGOS" Then
                            Dim cfecha As Date = DateTime.Now.Date
                            With frmCuentasPorPagar
                                Panel3.Width = 0
                                .MdiParent = Me
                                .Parent = Panel4
                                .lblPeriodo.Text = String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & PeriodoGeneral
                                .StartPosition = FormStartPosition.CenterParent
                                .WindowState = FormWindowState.Maximized
                                .Show()
                            End With
                        ElseIf tvOperaciones.SelectedNode.Tag = "PV_REG" Then
                            With frmMantenimientoVentaPagada
                                Panel3.Width = 0
                                Dim cfecha As Date = DateTime.Now.Date
                                .lblPerido.Text = String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & PeriodoGeneral
                                .ListaVentas(String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & PeriodoGeneral)
                                .MdiParent = Me
                                .Parent = Panel4
                                .StartPosition = FormStartPosition.CenterParent
                                .WindowState = FormWindowState.Maximized
                                .Show()
                            End With
                        ElseIf tvOperaciones.SelectedNode.Tag = "PV_RENTA" Then
                            With frmRentabilidad
                                Panel3.Width = 0
                                Dim cfecha As Date = DateTime.Now.Date
                                .lblPeriodo.Text = String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & cfecha.Year
                                .GenerarRentabilidad(cfecha.Month & "/" & cfecha.Year)
                                .MdiParent = Me
                                .Parent = Panel4
                                .StartPosition = FormStartPosition.CenterParent
                                .WindowState = FormWindowState.Maximized
                                .Show()
                            End With

                        ElseIf tvOperaciones.SelectedNode.Tag = "PLD_Libro" Then
                            With frmLibroDiarioMaster
                                'Panel3.Width = 0
                                Dim cfecha As Date = DateTime.Now.Date
                                .BuscarLibroDiarioFull()
                                .MdiParent = Me
                                .Parent = Panel4
                                .StartPosition = FormStartPosition.CenterParent
                                .WindowState = FormWindowState.Maximized
                                .Show()
                            End With

                        ElseIf tvOperaciones.SelectedNode.Tag = "PLD_RepLibro" Then
                            With frmReportesLibroDiario
                                .StartPosition = FormStartPosition.CenterParent
                                .Show()
                            End With

                        ElseIf tvOperaciones.SelectedNode.Tag = "PLD_RepCont" Then
                            Dim cfecha As Date = DateTime.Now.Date
                            With frmReporteContableMaster
                                .MaximizeBox = False
                                .MinimizeBox = False
                                .dtpAnio.Text = New DateTime(PeriodoGeneral, cfecha.Month, cfecha.Day)
                                .dtpPeriodoAnio.Text = New DateTime(PeriodoGeneral, cfecha.Month, cfecha.Day)
                                .lblPerido.Text = String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & PeriodoGeneral
                                .BuscarMovimientosFull(PeriodoGeneral)
                                .txtDesdeA.Text = "/" & PeriodoGeneral
                                .txtHastaD.Text = "/" & PeriodoGeneral
                                '.dtpPeriodoMes.Value = Date.Now.Month
                                .MdiParent = Me
                                .Parent = Panel4
                                .StartPosition = FormStartPosition.CenterParent
                                .Dock = DockStyle.Fill
                                .Show()
                            End With

                        ElseIf tvOperaciones.SelectedNode.Tag = "PV_REG_GEN" Then
                            With frmMantenimientoVentaDirecta
                                Panel3.Width = 0
                                Dim cfecha As Date = DateTime.Now.Date
                                .lblPerido.Text = String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & PeriodoGeneral
                                .ListaVentas(String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & PeriodoGeneral)
                                .MdiParent = Me
                                .Parent = Panel4
                                .StartPosition = FormStartPosition.CenterParent
                                .WindowState = FormWindowState.Maximized
                                .Show()
                            End With
                        ElseIf tvOperaciones.SelectedNode.Tag = "PV_GNRAL" Then
                            With frmMasterVentaGeneral
                                Panel3.Width = 0
                                Dim cfecha As Date = DateTime.Now.Date
                                .lblPerido.Text = String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & PeriodoGeneral
                                .ListaVentas(String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & PeriodoGeneral)
                                .MdiParent = Me
                                .Parent = Panel4
                                .StartPosition = FormStartPosition.CenterParent
                                .WindowState = FormWindowState.Maximized
                                .Show()
                            End With
                        ElseIf tvOperaciones.SelectedNode.Tag = "PV_REPORTE" Then
                            Dim cfecha As Date = DateTime.Now.Date
                            With frmReporteVentas
                                'Panel3.Width = 0
                                .lblPerido.Text = String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & PeriodoGeneral
                                'martin
                                .Dock = DockStyle.Fill
                                '''''''''''''''
                                .MdiParent = Me
                                .Parent = Panel4
                                .StartPosition = FormStartPosition.CenterParent
                                '  .WindowState = FormWindowState.Maximized
                                .Show()
                            End With
                    End If



                    Else
                        If Not tvOperaciones.SelectedNode.Text = "Gestión de Establecimientos" Then
                            '   MsgBox("Seleccione un establecimiento!.", MsgBoxStyle.Information, "Atención!")
                            Me.lblEstado.Image = My.Resources.cross 'Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\cross.png")
                            Me.lblEstado.Text = "Debe seleccionar un establecimiento!."
                        End If
                End If

            End If
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnCambiarSesionProyecto_MenuItemActivating(sender As System.Object, e As Qios.DevSuite.Components.QMenuCancelEventArgs) Handles btnCambiarSesionProyecto.MenuItemActivating
        ProyectoPrdeterminado()
    End Sub

    Private Sub Panel4_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub LinkLabel3_LinkClicked_1(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub LinkLabel3_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub QRibbonCaption1_ItemActivated(sender As System.Object, e As Qios.DevSuite.Components.QCompositeEventArgs) Handles QRibbonCaption1.ItemActivated

    End Sub

    Private Sub QMenuItem2_MenuItemActivating(sender As Object, e As Qios.DevSuite.Components.QMenuCancelEventArgs) Handles QMenuItem2.MenuItemActivating
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
        Dim estableSA As New establecimientoSA
        Dim estable As New centrocosto
        datos.Clear()
        With frmModalEstablecimientoCaja
            .StrParametroCarga = "ET"
            .ObtenerEstablecimientos()
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            If datos.Count > 0 Then
                lblProyecto.Title = String.Empty
                Panel4.Controls.Clear()
                Timer1.Enabled = False
                estable = estableSA.ObtenerListaEstablecimientos(Gempresas.IdEmpresaRuc).First
                If Not IsNothing(estable) Then
                    lblEStablecimiento.Title = .Name
                    GEstableciento = GEstablecimiento.InstanceSingle()
                    GEstableciento.Clear()
                    With estableSA.UbicaEstablecimientoPorID(datos(0).ID)
                        GEstableciento.IdEstablecimiento = .idCentroCosto
                        GEstableciento.NombreEstablecimiento = .nombre
                        GEstableciento.TipoEstablecimiento = .TipoEstab
                        GEstableciento.Ubigeo = .ubigeo
                    End With
                Else
                    lblEStablecimiento.Title = "Seleccionar establecimiento?"
                End If
                Select Case ModuloAppx
                    Case ModuloSistema.PLANEAMIENTO

                    Case ModuloSistema.CONTABILIDAD

                    Case ModuloSistema.CAJA

                    Case ModuloSistema.PUNTO_DE_VENTA

                End Select

                LoadTree()
                Me.lblEstado.Image = My.Resources.ok4 'Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\cross.png")
                Me.lblEstado.Text = "Done Establecimiento!."
                lblEStablecimiento.Title = datos(0).NombreCampo
               
                'TmpIdEstable = datos(0).ID
                'TmpNomEstable = datos(0).NombreCampo
            Else

            End If
        End With

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub QToolBar1_Click(sender As System.Object, e As System.EventArgs) Handles QToolBar1.Click

    End Sub

    Private Sub tvOperaciones_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles tvOperaciones.MouseDown

    End Sub

    Private Sub lblPerido_Click(sender As System.Object, e As System.EventArgs) Handles lblPerido.Click

    End Sub

    Private Sub lblPerido_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lblPerido.MouseUp
        Dim p As Point = e.Location
        p.Offset(lblPerido.Bounds.Location)
        ContextMenuStrip2.Show(ToolStrip3.PointToScreen(p))
        '   cboPeriodo.SelectedIndex = 0
        '    cboPeriodo.DroppedDown = True
    End Sub

    Private Sub cboPeriodo_Click(sender As System.Object, e As System.EventArgs) Handles cboPeriodo.Click

    End Sub

    Private Sub cboPeriodo_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboPeriodo.SelectedIndexChanged
        'Select Case cboPeriodo.Text
        '    Case "ENERO"
        '        lblPerido.Text = "01" & "/2014"
        '    Case "FEBRERO"
        '        lblPerido.Text = "02" & "/2014"
        '    Case "MARZO"
        '        lblPerido.Text = "03" & "/2014"
        '    Case "ABRIL"
        '        lblPerido.Text = "04" & "/2014"
        '    Case "MAYO"
        '        lblPerido.Text = "05" & "/2014"
        '    Case "JUNIO"
        '        lblPerido.Text = "06" & "/2014"
        '    Case "JULIO"
        '        lblPerido.Text = "07" & "/2014"
        '    Case "AGOSTO"
        '        lblPerido.Text = "08" & "/2014"
        '    Case "SETIEMBRE"
        '        lblPerido.Text = "09" & "/2014"
        '    Case "OCTUBRE"
        '        lblPerido.Text = "10" & "/2014"
        '    Case "NOVIEMBRE"
        '        lblPerido.Text = "11" & "/2014"
        '    Case "DICIEMBRE"
        '        lblPerido.Text = "12" & "/2014"
        'End Select

       
        PeriodoGeneral = cboPeriodo.Text
        lblPerido.Text = cboPeriodo.Text

        ContextMenuStrip2.Hide()
    End Sub

    Private Sub AgregarPeríodoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AgregarPeríodoToolStripMenuItem.Click
        toolAnio.Visible = True
    End Sub

    Private Sub CortarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles CortarToolStripButton.Click
        toolAnio.Visible = False
    End Sub

    Private Sub cboAnios_Click(sender As System.Object, e As System.EventArgs) Handles cboAnios.Click

    End Sub

    Private Sub cboAnios_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboAnios.KeyPress
        e.Handled = True
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        GrabarPeriodo()
        Me.Cursor = Cursors.Arrow
    End Sub
End Class
