Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Syncfusion.Windows.Forms
Imports System.Text.RegularExpressions
Imports Helios.Cont.Presentation.WinForm

Public Class FormAgregarBienes



#Region "ATRIBUTOS"
    Public Property FormEmitirGuiaRemision As FormEmitirGuiaRemision
#End Region

#Region "CONSTRUCTOR"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        LoadControles()

        FormEmitirGuiaRemision = New FormEmitirGuiaRemision()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
#End Region
    Private Sub LoadControles()

        Dim tablaSA As New tablaDetalleSA

        Try

            Me.cbUniMediAgre.DataSource = tablaSA.GetListaTablaDetalle(6, "1")
            Me.cbUniMediAgre.DisplayMember = "descripcion"
            Me.cbUniMediAgre.ValueMember = "codigoDetalle"

        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Public Sub ValidaCajaDuplicada()

        For Each i In FormEmitirGuiaRemision.dgAgregarBien.Table.Records
            If (i.GetValue("descripcion")) = txtdescAgreBien.Text Then
                Throw New Exception("No puede agregar la caja seleccionada, ya está agregada.")
            End If
        Next
    End Sub
    Public Sub AgregarCaja()

        Try
            FormEmitirGuiaRemision.dgAgregarBien.Table.AddNewRecord.SetCurrent()
            FormEmitirGuiaRemision.dgAgregarBien.Table.AddNewRecord.BeginEdit()
            'f.dgAgregarBien.Table.CurrentRecord.SetValue("Nro", 1)
            FormEmitirGuiaRemision.dgAgregarBien.Table.CurrentRecord.SetValue("CodigoBien", txtCodAgreBien.Text)
            FormEmitirGuiaRemision.dgAgregarBien.Table.CurrentRecord.SetValue("descripcion", txtdescAgreBien.Text)
            FormEmitirGuiaRemision.dgAgregarBien.Table.CurrentRecord.SetValue("Unidad", cbUniMediAgre.Text)
            FormEmitirGuiaRemision.dgAgregarBien.Table.CurrentRecord.SetValue("Cantidad", txtCantAgregBien.Text)


            FormEmitirGuiaRemision.dgAgregarBien.Table.AddNewRecord.EndEdit()
            FormEmitirGuiaRemision.dgAgregarBien.Table.TableDirty = True
        Catch ex As Exception
            Throw ex
        End Try

    End Sub



    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            ValidaCajaDuplicada()
            AgregarCaja()
            'txtnomAcRe.Text = ""
            'txtcantRefen.Text = ""
            'txtcantRe.Text = ""
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validar cajas")
        End Try
    End Sub

End Class