Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms.Grid

Public Class FormProgramacionSimple

#Region "Attributes"
    Dim ListaCentroCostos As List(Of centrocosto)
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub cargarDAtos()
        Try

            Dim rutaSA As New RutasSA
            Dim dt As New DataTable

            GridTotales.Table.Records.DeleteAll()

            Dim lista = rutaSA.GellAllRutas(New rutas With
                                                              {
                                                              .estado = "A"
                                                              }).Where(Function(O) O.codigo = "RT").ToList


            With dt.Columns
                .Add("ID")
                .Add("ORIGEN")
                .Add("DESTINO")
            End With

            For Each i In lista

                dt.Rows.Add(i.ruta_id,
                          ListaAgencias.Where(Function(X) X.idCentroCosto = i.ciudadOrigen).FirstOrDefault.nombre,
                         ListaAgencias.Where(Function(X) X.idCentroCosto = i.ciudadDestino).FirstOrDefault.nombre
                         )
                GridTotales.DataSource = dt

            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub GridTotales_TableControlCellDoubleClick(sender As Object, e As Grouping.GridTableControlCellClickEventArgs) Handles GridTotales.TableControlCellDoubleClick

        If (Not IsNothing(GridTotales.Table.CurrentRecord)) Then
            Dim entidad As New rutas
            entidad.ruta_id = GridTotales.Table.CurrentRecord.GetValue("ID")
            entidad.ciudadOrigen = GridTotales.Table.CurrentRecord.GetValue("ORIGEN") & "-" & GridTotales.Table.CurrentRecord.GetValue("DESTINO")

            Me.Tag = entidad

            Dispose()
        Else
            MessageBox.Show("DEBE SELECCIONAR UN CAMPO")
        End If

    End Sub

#End Region

#Region "METODOS"



#End Region






End Class