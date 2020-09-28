Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping

Public Class FormValesDeConsumo

    Public Property beneficioSA As New beneficioSA
    Dim entidadSA As New entidadSA

    Public Sub New(idCLiente As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GetCliente(idCLiente)
    End Sub

    Private Sub GetCliente(cliente As Integer)
        Dim Entidadcliente = entidadSA.UbicarEntidadPorID(cliente).FirstOrDefault

        If Entidadcliente IsNot Nothing Then
            TextEntidad.Text = Entidadcliente.nombreCompleto
            TextEntidad.Tag = Entidadcliente.idEntidad
            TextNroDocEntidad.Text = Entidadcliente.nrodoc
        End If

    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim f As New FormBeneficioValesDisponibles
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim c = CType(f.Tag, beneficioProduccionConsumo)
            TextDetalleBeneficio.Text = c.descripcion
            TextDetalleBeneficio.Tag = c.produccion_id
            TextProduccion.Text = $"{c.tipo}-{c.produccion_id}"
            If c.tieneVigencia Then
                txtVigencia.Value = c.Vigencia
            End If
            TextValorConvertido.DecimalValue = c.valor

        End If
    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click

        Dim codigoTipoTabla = General.TipoTabla.valesDeDescuento
        Dim codigoTipoBeneficio = General.TipoBeneficio.Documento

        Dim beneficio As New Business.Entity.beneficio With
          {
          .Action = BaseBE.EntityAction.INSERT,
           .idEmpresa = Gempresas.IdEmpresaRuc,
            .idOrganizacion = GEstableciento.IdEstablecimiento,
          .tipoTabla = codigoTipoTabla,
          .detalleBeneficio = TextDetalleBeneficio.Text,
          .tipoBeneficio = codigoTipoBeneficio,
          .beneficioReferencia = 0,
          .beneficioReferenciaCantidad = 0,
          .afectoComprobante = chAfectoComprobante.Checked,
          .tipoAfectacion = If(CbotipoAfectacion.Text = "IMPORTE", "I", "C"),
          .importeBase = TextImporteBase.DecimalValue,
          .valorConvertido = TextValorConvertido.DecimalValue,
          .vigencia = txtVigencia.Value,
          .esPremioRegaloBonif = False,
          .idCliente = TextEntidad.Tag,
          .produccion_id = If(TextDetalleBeneficio.Text.Trim.Length > 0, TextDetalleBeneficio.Tag, 0),
          .estado = General.Beneficio.StatusBeneficio.Activo
          }

        beneficioSA.RegisterClientBenefice(beneficio)
        MessageBox.Show("Cupon asignado correctamente!", "Registro con exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close()
    End Sub
End Class