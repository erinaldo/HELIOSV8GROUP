Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Cont.Business.Entity
Imports Microsoft.VisualBasic.FileIO
Imports System
Imports System.IO
Imports System.Collections
Public Class frmDetalleEmpresa

#Region "Attributes"
    Public Property EmpresaSA As New empresaSA
    Public Property empresa As empresa
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtPeriodo.Value = Date.Now
        txtPeriodo.Visible = True
    End Sub
#End Region

#Region "Methods"

    Function ListacuentaplanContableEmpresa() As List(Of cuentaplanContableEmpresa)
        Dim dirPruebas As String = "C:\Helios"
        Dim ficPruebas As String = Path.Combine(dirPruebas, "cuentaplanContableEmpresa.txt")

        'Dim testFile As System.IO.FileInfo
        'testFile = My.Computer.FileSystem.GetFileInfo("C:\Helios\cuentaplanContableEmpresa.txt")
        'Dim folderPath As String = testFile.DirectoryName

        ListacuentaplanContableEmpresa = New List(Of cuentaplanContableEmpresa)
        'Using leitor As New TextFieldParser("C:\Users\Jiuni\Desktop\cuentaplanContableEmpresa.txt")
        Using leitor As New TextFieldParser(ficPruebas)

            'Informamos que será importado com Delimitação 
            leitor.TextFieldType = FileIO.FieldType.Delimited
            'Informamos o Delimitador 
            leitor.SetDelimiters(",")

            Dim linhaAtual As String()
            While Not leitor.EndOfData
                Try
                    linhaAtual = leitor.ReadFields()
                    'Dim currentField As String
                    'For Each currentField In linhaAtual
                    '    MsgBox(currentField)

                    'Next
                    ListacuentaplanContableEmpresa.Add(New cuentaplanContableEmpresa With
                                             {
                                                 .cuenta = linhaAtual(0).ToString,
                                                 .cuentaPadre = linhaAtual(1).ToString,
                                                 .descripcion = linhaAtual(2).ToString,
                                                 .Observaciones = linhaAtual(3).ToString,
                                                 .usuarioModificacion = linhaAtual(4).ToString,
                                                 .fechaModificacion = linhaAtual(5).ToString
                                             })

                Catch ex As MalformedLineException
                    'Ignoramos a linha atual caso não seja válida 
                    MsgBox("Linha: " & ex.Message & " não é válida e será ignorada.")
                End Try
            End While
            'MsgBox("Arquivo Importado com Sucesso!")
        End Using
    End Function

    Function ListamascaraGastosEmpresa() As List(Of mascaraGastosEmpresa)
        Dim dirPruebas As String = "C:\Helios"
        Dim ficPruebas As String = Path.Combine(dirPruebas, "mascaraGastosEmpresa.txt")

        'Dim testFile As System.IO.FileInfo
        'testFile = My.Computer.FileSystem.GetFileInfo("C:\Helios\mascaraGastosEmpresa.txt")
        'Dim folderPath As String = testFile.DirectoryName

        ListamascaraGastosEmpresa = New List(Of mascaraGastosEmpresa)
        Using leitor As New TextFieldParser(ficPruebas)
            'Using leitor As New TextFieldParser("C:\Users\Jiuni\Desktop\mascaraGastosEmpresa.txt")

            'Informamos que será importado com Delimitação 
            leitor.TextFieldType = FileIO.FieldType.Delimited
            'Informamos o Delimitador 
            leitor.SetDelimiters(",")

            Dim linhaAtual As String()
            While Not leitor.EndOfData
                Try
                    linhaAtual = leitor.ReadFields()
                    'Dim currentField As String
                    'For Each currentField In linhaAtual
                    '    MsgBox(currentField)

                    'Next
                    ListamascaraGastosEmpresa.Add(New mascaraGastosEmpresa With
                                             {
                                                 .cuentaCompra = linhaAtual(0).ToString,
                                                 .descripcionCompra = linhaAtual(1).ToString,
                                                 .cuentaCostoProcesoDebe = linhaAtual(2).ToString,
                                                 .descripcionCostoProcesoDebe = linhaAtual(3).ToString,
                                                 .cuentaCostoProcesoHaber = linhaAtual(4).ToString,
                                                 .descripcionCostoProcesoHaber = linhaAtual(5).ToString,
                                                 .cuentaConclusionProcesoDebe = linhaAtual(6).ToString,
                                                 .descripcionConclusionDebe = linhaAtual(7).ToString,
                                                 .cuentaConclusionProcesoHaber = linhaAtual(8).ToString,
                                                 .descripcionConclusionHaber = linhaAtual(9).ToString,
                                                 .cuentaDestinoDebe = linhaAtual(10).ToString,
                                                 .descripcionDestinoDebe = linhaAtual(11).ToString,
                                                 .cuentaDestinoHaber = linhaAtual(12).ToString,
                                                 .descripcionDestinoHaber = linhaAtual(13).ToString,
                                                 .usuarioActualizacion = linhaAtual(14).ToString,
                                                 .fechaActualizacion = linhaAtual(15).ToString
                                             })

                Catch ex As MalformedLineException
                    'Ignoramos a linha atual caso não seja válida 
                    MsgBox("Linha: " & ex.Message & " não é válida e será ignorada.")
                End Try
            End While
            'MsgBox("Arquivo Importado com Sucesso!")
        End Using
    End Function

    Function ListaCuentaMascara() As List(Of cuentaMascara)
        Dim dirPruebas As String = "C:\Helios"
        Dim ficPruebas As String = Path.Combine(dirPruebas, "cuentaMascara.txt")

        'Dim testFile As System.IO.FileInfo
        'testFile = My.Computer.FileSystem.GetFileInfo("C:\Helios\cuentaMascara.txt")
        'Dim folderPath As String = testFile.DirectoryName

        ListaCuentaMascara = New List(Of cuentaMascara)
        Using leitor As New TextFieldParser(ficPruebas)
            'Using leitor As New TextFieldParser("C:\Users\Jiuni\Desktop\cuentaMascara.txt")

            'Informamos que será importado com Delimitação 
            leitor.TextFieldType = FileIO.FieldType.Delimited
            'Informamos o Delimitador 
            leitor.SetDelimiters(",")

            Dim linhaAtual As String()
            While Not leitor.EndOfData
                Try
                    linhaAtual = leitor.ReadFields()
                    'Dim currentField As String
                    'For Each currentField In linhaAtual
                    '    MsgBox(currentField)

                    'Next
                    ListaCuentaMascara.Add(New cuentaMascara With
                                             {
                                                 .parametro = linhaAtual(0).ToString,
                                                 .cuentaBase = linhaAtual(1).ToString,
                                                 .cuentaEspecifica = linhaAtual(2).ToString,
                                                 .tipoAsiento = linhaAtual(3).ToString,
                                                 .tipo = linhaAtual(4).ToString,
                                                 .idModulo = linhaAtual(5).ToString
                                             })

                Catch ex As MalformedLineException
                    'Ignoramos a linha atual caso não seja válida 
                    MsgBox("Linha: " & ex.Message & " não é válida e será ignorada.")
                End Try
            End While
            'MsgBox("Arquivo Importado com Sucesso!")
        End Using
    End Function

    Function ListaMascarContable2() As List(Of mascaraContable2)
        Dim dirPruebas As String = "C:\Helios"
        Dim ficPruebas As String = Path.Combine(dirPruebas, "mascaraContable2.txt")

        'Dim testFile As System.IO.FileInfo
        'testFile = My.Computer.FileSystem.GetFileInfo("C:\Helios\mascaraContable2.txt")
        'Dim folderPath As String = testFile.DirectoryName
        ListaMascarContable2 = New List(Of mascaraContable2)
        Using leitor As New TextFieldParser(ficPruebas)
            'Using leitor As New TextFieldParser("C:\Users\Jiuni\Desktop\mascaraContable2.txt")

            'Informamos que será importado com Delimitação 
            leitor.TextFieldType = FileIO.FieldType.Delimited
            'Informamos o Delimitador 
            leitor.SetDelimiters(",")

            Dim linhaAtual As String()
            While Not leitor.EndOfData
                Try
                    linhaAtual = leitor.ReadFields()
                    'Dim currentField As String
                    'For Each currentField In linhaAtual
                    '    MsgBox(currentField)

                    'Next
                    ListaMascarContable2.Add(New mascaraContable2 With
                                             {
                                                 .tipoExistencia = linhaAtual(0).ToString.PadLeft(2, "0" & linhaAtual(0)),
                                                 .cuentaCompra = linhaAtual(1).ToString,
                                                 .descripcionCompra = linhaAtual(2).ToString,
                                                 .asientoCompra = linhaAtual(3).ToString,
                                                 .destinoCompra = linhaAtual(4).ToString,
                                                 .descripcionDestino = linhaAtual(5).ToString,
                                                 .asientoDestino = linhaAtual(6).ToString,
                                                 .destinoCompra2 = linhaAtual(7).ToString,
                                                 .descripcionDestino2 = linhaAtual(8).ToString,
                                                 .asientoDestino2 = linhaAtual(9).ToString,
                                                 .cuentaDestinoKardex = linhaAtual(10).ToString,
                                                 .nameDestinoKardex = linhaAtual(11).ToString,
                                                 .asientoDestinoKardex = linhaAtual(12).ToString,
                                                 .cuentaDestinoKardex2 = linhaAtual(13).ToString,
                                                 .nameDestinoKardex2 = linhaAtual(14).ToString,
                                                 .asientoDestinoKardex2 = linhaAtual(15).ToString,
                                                 .cuentaVenta = linhaAtual(16).ToString,
                                                 .descripcionVenta = linhaAtual(17).ToString,
                                                 .asientoVenta = linhaAtual(18).ToString,
                                                 .cuentaKardex = linhaAtual(19).ToString,
                                                 .descripcionKardex = linhaAtual(20).ToString,
                                                 .asientoKardex = linhaAtual(21).ToString,
                                                 .cuentaKardex2 = linhaAtual(22).ToString,
                                                 .descripcionKardex2 = linhaAtual(23).ToString,
                                                 .asientoKardex2 = linhaAtual(24).ToString
                                             })

                Catch ex As MalformedLineException
                    'Ignoramos a linha atual caso não seja válida 
                    MsgBox("Linha: " & ex.Message & " não é válida e será ignorada.")
                End Try
            End While
            'MsgBox("Arquivo Importado com Sucesso!")
        End Using
    End Function

    Sub GrabarEmpresa()
        Try
            empresa = New empresa
            empresa.idEmpresa = txtRuc.Text
            empresa.razonSocial = txtRazon.Text
            empresa.nombreCorto = txtNombreCorto.Text
            empresa.ruc = txtRuc.Text
            empresa.direccion = txtDir.Text
            empresa.telefono = txtFono.Text
            empresa.fax = txtFax.Text
            empresa.celular = txtCel.Text
            empresa.e_mail = txtMail.Text
            empresa.regimen = txtRegimen.Text
            empresa.actividad = txtActividad.Text
            empresa.inicioOperacion = String.Format("{0:00}", txtPeriodoCierre.Value.Month) & "/" & txtPeriodoCierre.Value.Year
            empresa.periodo = txtPeriodoCierre.Value
            empresa.usuarioActualizacion = usuario.IDUsuario
            empresa.fechaActualizacion = Date.Now
            empresa.estado = "0"

            Dim lista11 = ListaMascarContable2()

            EmpresaSA.InsertarEmpresa(empresa, lista11, ListaCuentaMascara, ListamascaraGastosEmpresa, ListacuentaplanContableEmpresa)
            MessageBox.Show("Empresa registrada!", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)
            empresa.idEmpresa = empresa.ruc
            Tag = empresa
            Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


#End Region

#Region "Events"
    Private Sub txtPeriodo_ValueChanged(sender As Object, e As EventArgs) Handles txtPeriodo.ValueChanged
        txtPeriodoCierre.Value = CDate(txtPeriodo.Value).AddMonths(-1)
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Cursor = Cursors.WaitCursor
        If Not txtRazon.Text.Trim.Length > 0 Then
            MessageBox.Show("Debe ingresar la razón social de la empresa!", "Validar razón social", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Cursor = Cursors.Default
            Exit Sub
        End If

        If Not txtNombreCorto.Text.Trim.Length > 0 Then
            MessageBox.Show("Debe ingresar el nombre corto de la empresa!", "Validar nombre corto", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Cursor = Cursors.Default
            Exit Sub
        End If

        If Not txtRuc.Text.Trim.Length > 0 Then
            MessageBox.Show("Debe ingresar el ruc de la empresa!", "Validar RUC.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Cursor = Cursors.Default
            Exit Sub
        End If

        'If Not txtRazon.Text.Trim.Length > 0 Then
        '    MessageBox.Show("Debe ingresar la razón social de la empresa!", "Validar razón social", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Cursor = Cursors.Default
        '    Exit Sub
        'End If

        GrabarEmpresa()
        Cursor = Cursors.Default
    End Sub
#End Region

    
End Class
