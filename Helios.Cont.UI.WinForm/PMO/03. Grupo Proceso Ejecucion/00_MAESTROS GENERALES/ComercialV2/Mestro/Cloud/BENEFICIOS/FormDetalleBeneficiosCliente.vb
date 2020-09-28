Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess

Public Class FormDetalleBeneficiosCliente

#Region "Attributes"
    Public Property beneficioSA As New beneficioSA
#End Region

#Region "Constructors"
    Public Sub New(be As entidad)

        ' This call is required by the designer.
        InitializeComponent()
        General.FormatoGridAvanzado(Gridbeneficios, True, False, 10.0F)
        General.FormatoGridAvanzado(GridCupones, True, False, 10.0F)
        ' Add any initialization after the InitializeComponent() call.
        TextEntidad.Text = be.nombreCompleto
        TextEntidad.Tag = be.idEntidad

        GetBeneficios(be)
        GetBeneficiosCupones(be)
    End Sub


#End Region

#Region "Methods"
    Private Sub GetBeneficiosCupones(be As entidad)
        Dim dt As New DataTable()
        dt.Columns.Add("id")
        dt.Columns.Add("tipobeneficio")
        dt.Columns.Add("producto")
        dt.Columns.Add("montobase")
        dt.Columns.Add("valorganado")
        dt.Columns.Add("vigencia")

        For Each i In beneficioSA.BeneficioListaClienteProductionCupones(New Business.Entity.beneficio With
                                                                   {
                                                                   .idCliente = be.idEntidad
                                                                   })

            Dim tipoBeneficio = String.Empty
            Dim valorbeneficio = Nothing


            tipoBeneficio = "CUPON DESCUENTO"
            valorbeneficio = i.CustomBeneficioProduccion.valor
            dt.Rows.Add(i.beneficio_id, tipoBeneficio, i.CustomBeneficioProduccion.descripcion,
                        i.importeBase, valorbeneficio, i.CustomBeneficioProduccion.Vigencia)
        Next
        GridCupones.DataSource = dt
    End Sub

    Private Sub GetBeneficios(be As entidad)
        Dim dt As New DataTable()
        dt.Columns.Add("id")
        dt.Columns.Add("tipobeneficio")
        dt.Columns.Add("producto")
        dt.Columns.Add("montobase")
        dt.Columns.Add("valorganado")
        dt.Columns.Add("vigencia")

        For Each i In beneficioSA.BeneficioListaClienteProductions(New Business.Entity.beneficio With
                                                                   {
                                                                   .idCliente = be.idEntidad
                                                                   })

            Dim tipoBeneficio = String.Empty
            Dim valorbeneficio = Nothing
            Select Case i.tipoTabla
                Case General.TipoTabla.Promocion
                    tipoBeneficio = "PROMOCION, OFERTA"
                    valorbeneficio = i.beneficioReferenciaCantidad
                Case General.TipoTabla.Bonificacion, General.TipoTabla.regalo
                    tipoBeneficio = "REGALO, BONIFICACION"
                    valorbeneficio = i.beneficioReferenciaCantidad
                Case General.TipoTabla.DescuentoRebaja
                    tipoBeneficio = "DESCUENTO REBAJA"
                    valorbeneficio = i.valorConvertido
            End Select


            dt.Rows.Add(i.beneficio_id, tipoBeneficio, i.CustomProducto.descripcionItem,
                        i.importeBase, valorbeneficio, i.vigencia.GetValueOrDefault)
        Next
        Gridbeneficios.DataSource = dt
    End Sub


#End Region

#Region "Events"

#End Region
End Class