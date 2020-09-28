Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Public Class FormResumenClienteXDoc


    Public Sub New(id As Integer)
        ' This call is required by the designer.
        InitializeComponent()
        cargarDatos(id)
    End Sub

    Private Sub cargarDatos(ID As Integer)
        Try
            Dim documentoventaTransporteBE As New documentoventaTransporte
            Dim documentoventaTransporteSA As New DocumentoventaTransporteSA
            Dim documentoventaTrans As New documentoventaTransporte

            documentoventaTransporteBE.idDocumento = ID
            documentoventaTrans = documentoventaTransporteSA.DocumentoTransporteSelID(documentoventaTransporteBE)

            If (Not IsNothing(documentoventaTrans)) Then

                If (Not IsNothing(documentoventaTrans.CustomPerson.nombreCompleto)) Then
                    txtConsignado.Text = documentoventaTrans.CustomPerson.nombreCompleto
                Else
                    txtConsignado.Text = documentoventaTrans.comprador
                End If
                txtRemitente.Text = documentoventaTrans.Remitente

                txtNroRemitemte.Text = documentoventaTrans.telefonoRemitente
                    txtNumeroREmitente.Text = documentoventaTrans.telefonoConsignado
                    TextFechaDia.Value = documentoventaTrans.fechadoc
                End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

End Class