Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Tools
Public Class frmHistorialCajasDetallado
#Region "Attributes"
    Dim listaMeses As New List(Of MesesAnio)
#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGrid(dgvCajasAssig)
        'GetCajaActivas()

    End Sub

#End Region

#Region "Methods"

    Public Sub ObtenerListaCajaAsignacionDetalle(idCajausuario As Integer, idpersona As Integer, fechaRegistro As DateTime)
        Dim cajausuariosa As New cajaUsuarioSA
        Dim finanza As New estadosFinancieros
        Dim finanzaSA As New EstadosFinancierosSA
        Dim cajausuario As New List(Of cajaUsuario)

        cajausuario = cajausuariosa.ResumenTransaccionesXusuarioCajaPago(New cajaUsuario With {.idcajaUsuario = idCajausuario, .idPersona = idpersona, .fechaRegistro = fechaRegistro})

        Dim dt As New DataTable("Entidades financieras")
        dt.Columns.Add(New DataColumn("idCajaUsuario", GetType(Integer)))
        dt.Columns.Add(New DataColumn("idPersona", GetType(Integer)))
        dt.Columns.Add(New DataColumn("nombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("tipo", GetType(String)))
        dt.Columns.Add(New DataColumn("moneda", GetType(String)))
        dt.Columns.Add(New DataColumn("fondoMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("fondoME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ingresoAdicMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ingresoAdicME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("saldoMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("saldoME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("empresa"))
        dt.Columns.Add(New DataColumn("estable"))
        dt.Columns.Add(New DataColumn("pagoMN"))
        dt.Columns.Add(New DataColumn("pagoME"))

        For Each i In cajausuario
            finanza = finanzaSA.GetUbicar_estadosFinancierosPorID(i.idEntidad)


            Dim dr As DataRow = dt.NewRow()

            Select Case i.moneda
                Case 1
                    dr(0) = i.idcajaUsuario
                    dr(1) = i.idPersona
                    dr(2) = i.NombreEntidad
                    dr(3) = i.Tipo
                    dr(4) = "NACIONAL"
                    dr(5) = i.fondoMN
                    dr(6) = 0
                    dr(7) = i.ingresoAdicMN
                    dr(8) = 0
                    dr(9) = i.Saldo
                    dr(10) = 0
                    dr(11) = finanza.idEmpresa
                    dr(12) = finanza.idEstablecimiento
                    dr(13) = i.otrosEgresosMN
                    dr(14) = 0.0
                    dt.Rows.Add(dr)
                Case 2
                    dr(0) = i.idcajaUsuario
                    dr(1) = i.idPersona
                    dr(2) = i.NombreEntidad
                    dr(3) = i.Tipo
                    dr(4) = "EXTRANJERA"
                    dr(5) = i.fondoMN
                    dr(6) = i.fondoME
                    dr(7) = i.ingresoAdicMN
                    dr(8) = i.ingresoAdicME
                    dr(9) = i.Saldo
                    dr(10) = i.SaldoME
                    dr(11) = finanza.idEmpresa
                    dr(12) = finanza.idEstablecimiento
                    dr(13) = i.otrosEgresosMN
                    dr(14) = 0.0
                    dt.Rows.Add(dr)
            End Select



        Next
        dgvCajasAssig.DataSource = dt

    End Sub


#Region "TIMER"

#End Region
#End Region

#Region "Events"

#End Region


   
End Class