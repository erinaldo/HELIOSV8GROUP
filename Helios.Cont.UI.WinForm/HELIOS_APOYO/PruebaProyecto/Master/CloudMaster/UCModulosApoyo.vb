Imports System.Threading
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.Business.Entity
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class UCModulosApoyo


#Region "Fields"

    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)

    Dim Repository2 As FormRepositoryConfEmpresa

#End Region

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.


        'Repository2 = Repository

    End Sub

    Private Sub GetListaDatosGenerales()
        Try
            Dim ListaUnidApoyo As New List(Of negocioComercial)
            Dim objEmpresaSA As New negocioComercialSA
            Dim objEmpresa As New negocioComercial

            Dim dt As New DataTable("Datos Generales")
            dt.Columns.Add(New DataColumn("ID", GetType(String)))
            dt.Columns.Add(New DataColumn("modulo", GetType(String)))
            dt.Columns.Add(New DataColumn("descripcion", GetType(String)))

            'ListaUnidApoyo.Add(New empresa With {.departamento = "COMERCIAL", .direccion = "NINGUNO"})
            'ListaUnidApoyo.Add(New empresa With {.departamento = "FINANZAS", .direccion = "NINGUNO"})
            'ListaUnidApoyo.Add(New empresa With {.departamento = "LOGISTICA", .direccion = "NINGUNO"})
            'ListaUnidApoyo.Add(New empresa With {.departamento = "RR.HH.", .direccion = "NINGUNO"})
            'ListaUnidApoyo.Add(New empresa With {.departamento = "TIC", .direccion = "NINGUNO"})


            For Each i As negocioComercial In objEmpresaSA.GetListaNegocioComercial.Where(Function(O) O.tipo = "UA").ToList
                Dim dr As DataRow = dt.NewRow()

                dr(0) = (i.IdNegocioComercial)
                dr(1) = (i.nombreRubro)
                dr(2) = i.tipo

                dt.Rows.Add(dr)
            Next

            setDatasource(dt)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub setDatasource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            Dim deleg As New SetDataSourceDelegate(AddressOf setDatasource)
            Invoke(deleg, New Object() {table})
        Else
            dgPedidos.DataSource = table
        End If
    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        GetListaDatosGenerales()
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        Try

            If (Not IsNothing(dgPedidos.Table.CurrentRecord)) Then
                Select Case dgPedidos.Table.CurrentRecord.GetValue("modulo")
                    Case "LOGISTICA"
                        Dim Login As New FormRepositoryLogisticaApoyo()
                        Login.StartPosition = FormStartPosition.CenterParent
                        Login.ShowDialog()
                        Application.DoEvents()
                    Case "COMERCIAL"

                    Case "FINANZAS"
                        Dim Login As New FormRepositoryFinanzasApoyo()
                        Login.StartPosition = FormStartPosition.CenterParent
                        Login.ShowDialog()
                        Application.DoEvents()
                    Case "RR.HH"
                        Dim Login As New FormRepositoryRRHHApoyo()
                        Login.StartPosition = FormStartPosition.CenterParent
                        Login.ShowDialog()
                        Application.DoEvents()
                    Case "TIC´S"

                    Case "SIN CONTROL"

                End Select
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

End Class
