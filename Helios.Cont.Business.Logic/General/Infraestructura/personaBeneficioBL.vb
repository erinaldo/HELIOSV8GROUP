Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Imports System.Data.Entity
Public Class personaBeneficioBL
    Inherits BaseBL

    Public Sub SavePersonaBeneficio(ListaobjPersona As List(Of personaBeneficio), idDocumento As Integer)
        Dim obj As New personaBeneficio()
        Dim iddistri As Integer = CInt(ListaobjPersona(0).distribucionID)
        Try

            Using ts As New TransactionScope
                If (ListaobjPersona.Count > 0) Then

                    Dim consulta = (HeliosData.documentoventaAbarrotesDet.Where(Function(doc) doc.idDistribucion = iddistri And
                                                                                           doc.idDocumento = CInt(idDocumento))).FirstOrDefault

                    'Dim consulta = HeliosData.personaBeneficio.Where(Function(o) o.idPersonaBeneficio = personas.idPersonaBeneficio And
                    '                                                 o.idEmpresa = personas.idEmpresa And personas.listaEstado.Contains(o.estado)).ToList
                    For Each objCategoria In ListaobjPersona
                        obj = New personaBeneficio()

                        obj.[idEmpresa] = objCategoria.[idEmpresa]
                        obj.[idEstablecimiento] = objCategoria.[idEstablecimiento]
                        obj.[idDocumento] = consulta.idDocumento
                        obj.secuencia = consulta.secuencia
                        obj.[idEntidad] = objCategoria.[idEntidad]
                        obj.[tipoDoc] = objCategoria.[tipoDoc]
                        obj.[nombrePersona] = objCategoria.[nombrePersona]
                        obj.[nroDocumento] = objCategoria.[nroDocumento]
                        obj.[nacionalidad] = objCategoria.[nacionalidad]
                        obj.[sexo] = objCategoria.[sexo]
                        obj.idDistribucion = objCategoria.distribucionID
                        obj.[glosario] = objCategoria.[glosario]
                        obj.[estado] = objCategoria.[estado]
                        obj.[usuarioActualizacion] = objCategoria.[usuarioActualizacion]
                        obj.[fechaActualizacion] = objCategoria.[fechaActualizacion]

                        HeliosData.personaBeneficio.Add(obj)
                        HeliosData.SaveChanges()
                    Next

                End If
                ts.Complete()
            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ListarPersonaBeneficio(personas As personaBeneficio) As List(Of personaBeneficio)
        Dim conteo As Integer = 0
        Dim obj As New personaBeneficio

        Dim listaInfraestructura As New List(Of personaBeneficio)

        'Dim consulta = HeliosData.personaBeneficio.Where(Function(o) o.idPersonaBeneficio = personas.idPersonaBeneficio And
        '                                                 o.idEmpresa = personas.idEmpresa And personas.listaEstado.Contains(o.estado)).ToList


        Dim consulta = HeliosData.personaBeneficio.Join _
            (HeliosData.documentoventaAbarrotesDet, Function(v) v.idDocumento,
             Function(o) o.idDocumento, Function(v, o) New With {.persona = v,
                                                                     .ocupacion = o}) _
                                                  .Join _
             (HeliosData.distribucionInfraestructura, Function(vv) vv.ocupacion.idDistribucion,
             Function(oo) oo.idDistribucion, Function(vv, oo) New With {.persona = vv.persona,
                                                                     .ocupacion = vv.ocupacion,
                                                                     .distribucion = oo}) _
                                                 .Where(Function(ooo) ooo.persona.idEmpresa = personas.idEmpresa And
                                                 ooo.persona.idPersonaBeneficio = personas.idPersonaBeneficio And
                                                 personas.listaEstado.Contains(ooo.persona.estado)).ToList

        'Dim consulta = (From dis In HeliosData.personaBeneficio
        '                Where dis.idPersonaBeneficio = personas.idPersonaBeneficio And dis.idEmpresa = personas.idEmpresa).ToList

        For Each i In consulta
            obj = New personaBeneficio
            obj.[idPersonaBeneficio] = i.persona.[idPersonaBeneficio]
            obj.[idEmpresa] = i.persona.[idEmpresa]
            obj.[idEstablecimiento] = i.persona.[idEstablecimiento]
            obj.[idDocumento] = i.persona.idDocumento
            obj.[idEntidad] = i.persona.[idEntidad]
            obj.[tipoDoc] = i.persona.[tipoDoc]
            obj.[nombrePersona] = i.persona.[nombrePersona]
            obj.[nroDocumento] = i.persona.[nroDocumento]
            obj.[nacionalidad] = i.persona.[nacionalidad]
            obj.[sexo] = i.persona.[sexo]
            obj.[glosario] = i.persona.[glosario]
            obj.[estado] = i.persona.[estado]
            obj.usuarioActualizacion = i.persona.[usuarioActualizacion]
            obj.[fechaActualizacion] = i.persona.[fechaActualizacion]
            obj.nombreHabitacion = i.distribucion.descripcionDistribucion & " " & i.distribucion.numeracion
            listaInfraestructura.Add(obj)
        Next

        Return listaInfraestructura
    End Function

    Public Function ListarPersonaFull(personas As personaBeneficio) As List(Of personaBeneficio)
        Try

            Dim conteo As Integer = 0
            Dim obj As New personaBeneficio

            Dim listaInfraestructura As New List(Of personaBeneficio)

            Dim consulta = (HeliosData.personaBeneficio.Where(Function(o) o.idEmpresa = personas.idEmpresa)).GroupBy(Function(x) x.nroDocumento).ToList

            For Each activity In consulta
                For Each i In activity

                    obj = New personaBeneficio
                    obj.[idPersonaBeneficio] = i.[idPersonaBeneficio]
                    obj.[idEmpresa] = i.[idEmpresa]
                    obj.[idEstablecimiento] = i.[idEstablecimiento]
                    obj.[idDocumento] = i.idDocumento
                    obj.[idEntidad] = i.[idEntidad]
                    obj.[tipoDoc] = i.[tipoDoc]
                    obj.[nombrePersona] = i.[nombrePersona]
                    obj.[nroDocumento] = i.[nroDocumento]
                    obj.[nacionalidad] = i.[nacionalidad]
                    obj.[sexo] = i.[sexo]
                    obj.[glosario] = i.[glosario]
                    obj.[estado] = i.[estado]
                    obj.usuarioActualizacion = i.[usuarioActualizacion]
                    obj.[fechaActualizacion] = i.[fechaActualizacion]

                    listaInfraestructura.Add(obj)

                Next

            Next

            Return listaInfraestructura
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ListarPersonaBeneficioXHabitacion(personas As personaBeneficio) As List(Of personaBeneficio)
        Try
            Dim conteo As Integer = 0
            Dim obj As New personaBeneficio

            Dim listaInfraestructura As New List(Of personaBeneficio)


            Dim consulta = HeliosData.personaBeneficio.Join _
            (HeliosData.documentoventaAbarrotesDet, Function(v) v.idDocumento,
             Function(o) o.idDocumento, Function(v, o) New With {.persona = v,
                                                                     .ocupacion = o}) _
                                                  .Join _
             (HeliosData.distribucionInfraestructura, Function(vv) vv.ocupacion.idDistribucion,
             Function(oo) oo.idDistribucion, Function(vv, oo) New With {.persona = vv.persona,
                                                                     .ocupacion = vv.ocupacion,
                                                                     .distribucion = oo}) _
                                                 .Where(Function(ooo) ooo.persona.idEmpresa = personas.idEmpresa).ToList



            'Dim consulta = (From per In HeliosData.personaBeneficio
            '                Join dis In HeliosData.distribucionInfraestructura
            '                    On CType(CInt(per.documentoventaAbarrotes.idDistribucion), Int32?) Equals dis.idDistribucion
            '                Where
            '                        per.idEmpresa = personas.idEmpresa And
            '                        per.idEstablecimiento = personas.idEstablecimiento
            '                Select
            '                    per.idPersonaBeneficio,
            '                    per.idEmpresa,
            '                    per.idEstablecimiento,
            '                    per.idDocumento,
            '                    per.idEntidad,
            '                    per.tipoDoc,
            '                    per.nombrePersona,
            '                    per.nroDocumento,
            '                    per.nacionalidad,
            '                    per.sexo,
            '                    per.glosario,
            '                    per.estado,
            '                    per.usuarioActualizacion,
            '                    per.fechaActualizacion,
            '                    dis.descripcionDistribucion,
            '                    dis.numeracion).ToList

            For Each i In consulta
                obj = New personaBeneficio
                obj.[idPersonaBeneficio] = i.persona.[idPersonaBeneficio]
                obj.[idEmpresa] = i.persona.[idEmpresa]
                obj.[idEstablecimiento] = i.persona.[idEstablecimiento]
                obj.[idDocumento] = i.persona.idDocumento
                obj.[idEntidad] = i.persona.[idEntidad]
                obj.[tipoDoc] = i.persona.[tipoDoc]
                obj.[nombrePersona] = i.persona.[nombrePersona]
                obj.[nroDocumento] = i.persona.[nroDocumento]
                obj.[nacionalidad] = i.persona.[nacionalidad]
                obj.[sexo] = i.persona.[sexo]
                obj.[glosario] = i.persona.[glosario]
                obj.[estado] = i.persona.[estado]
                obj.usuarioActualizacion = i.persona.[usuarioActualizacion]
                obj.[fechaActualizacion] = i.persona.[fechaActualizacion]
                obj.nombreHabitacion = i.distribucion.descripcionDistribucion & " " & i.distribucion.numeracion
                listaInfraestructura.Add(obj)
            Next

            Return listaInfraestructura
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ListarPersonaBeneficioXHabitacionActivo(personas As personaBeneficio) As List(Of personaBeneficio)
        Try
            Dim conteo As Integer = 0
            Dim obj As New personaBeneficio

            Dim listaInfraestructura As New List(Of personaBeneficio)


            Dim consulta = HeliosData.personaBeneficio.Join _
                (HeliosData.documentoventaAbarrotesDet, Function(v) v.idDocumento,
                 Function(o) o.idDocumento, Function(v, o) New With {.persona = v,
                                                                         .ocupacion = o}) _
                                                      .Join _
                 (HeliosData.distribucionInfraestructura, Function(vv) vv.ocupacion.idDistribucion,
                 Function(oo) oo.idDistribucion, Function(vv, oo) New With {.persona = vv.persona,
                                                                         .ocupacion = vv.ocupacion,
                                                                         .distribucion = oo}) _
                                                     .Where(Function(ooo) ooo.persona.idEmpresa = personas.idEmpresa And
                                                     ooo.persona.estado = "A").ToList

            For Each i In consulta
                obj = New personaBeneficio
                obj.[idPersonaBeneficio] = i.persona.[idPersonaBeneficio]
                obj.[idEmpresa] = i.persona.[idEmpresa]
                obj.[idEstablecimiento] = i.persona.[idEstablecimiento]
                obj.[idDocumento] = i.persona.idDocumento
                obj.[idEntidad] = i.persona.[idEntidad]
                obj.[tipoDoc] = i.persona.[tipoDoc]
                obj.[nombrePersona] = i.persona.[nombrePersona]
                obj.[nroDocumento] = i.persona.[nroDocumento]
                obj.[nacionalidad] = i.persona.[nacionalidad]
                obj.[sexo] = i.persona.[sexo]
                obj.[glosario] = i.persona.[glosario]
                obj.[estado] = i.persona.[estado]
                obj.usuarioActualizacion = i.persona.[usuarioActualizacion]
                obj.[fechaActualizacion] = i.persona.[fechaActualizacion]
                obj.nombreHabitacion = i.distribucion.descripcionDistribucion & " " & i.distribucion.numeracion
                listaInfraestructura.Add(obj)
            Next

            Return listaInfraestructura
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub EditarPersonaBeneficio(i As ocupacionInfraestructura)
        Try
            Using ts As New TransactionScope
                Dim consulta = (From a In HeliosData.documentoventaAbarrotesDet Join b In HeliosData.personaBeneficio
                                On a.idDocumento Equals b.idDocumento Where i.listaId.Contains(a.idDistribucion) And b.estado = "A").ToList
                For Each ite In consulta
                    Dim obj = (From n In HeliosData.personaBeneficio Where ite.a.idDocumento = n.idDocumento).ToList

                    For Each ITEM In obj
                        ITEM.estado = "C"
                        HeliosData.SaveChanges()
                    Next
                Next
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Function ListarPersonaXHabXCliente(personas As personaBeneficio) As List(Of personaBeneficio)
        Try

            Dim conteo As Integer = 0
            Dim obj As New personaBeneficio

            Dim listaInfraestructura As New List(Of personaBeneficio)

            Dim consulta = (HeliosData.personaBeneficio.Where(Function(o) o.idEmpresa = personas.idEmpresa And o.secuencia = personas.secuencia _
                                                                  And o.estado = personas.estado)).ToList

            For Each i In consulta
                obj = New personaBeneficio
                obj.[idPersonaBeneficio] = i.[idPersonaBeneficio]
                obj.[idEmpresa] = i.[idEmpresa]
                obj.[idEstablecimiento] = i.[idEstablecimiento]
                obj.[idDocumento] = i.idDocumento
                obj.[idEntidad] = i.[idEntidad]
                obj.[tipoDoc] = i.[tipoDoc]
                obj.[nombrePersona] = i.[nombrePersona]
                obj.[nroDocumento] = i.[nroDocumento]
                obj.[nacionalidad] = i.[nacionalidad]
                obj.[sexo] = i.[sexo]
                obj.[glosario] = i.[glosario]
                obj.[estado] = i.[estado]
                obj.usuarioActualizacion = i.[usuarioActualizacion]
                obj.[fechaActualizacion] = i.[fechaActualizacion]

                listaInfraestructura.Add(obj)
            Next

            Return listaInfraestructura
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function UbicarHospedadoPorRucNro(strEmpresa As String, strNroDoc As String) As personaBeneficio
        Return (From n In HeliosData.personaBeneficio Where n.nroDocumento = strNroDoc And n.estado = "A").FirstOrDefault
    End Function

    Public Function UbicarHospedadoPorID(PersonaBE As personaBeneficio) As personaBeneficio
        Dim obj As personaBeneficio

        Dim c = HeliosData.personaBeneficio.Join(HeliosData.distribucionInfraestructura, Function(post) post.idDistribucion, Function(prod) prod.idDistribucion, Function(post, prod) _
                                               New With
                                               {
                                               .post = post,
                                               .prod = prod
                                               }) _
                                                .Where(Function(O) O.post.idEntidad = PersonaBE.idEntidad And
                                                     O.post.estado = PersonaBE.estado).FirstOrDefault


        obj = New personaBeneficio
        obj.idPersonaBeneficio = c.post.idPersonaBeneficio
        obj.idEntidad = c.post.idEntidad
        obj.nombrePersona = c.post.nombrePersona
        obj.nombrePersona = c.prod.descripcionDistribucion & " " & c.prod.numeracion
        obj.idDistribucion = c.prod.idDistribucion

        Return obj

    End Function

    Public Function ListarHospedadosXCliente(personasBE As personaBeneficio) As List(Of personaBeneficio)
        Try

            Dim conteo As Integer = 0
            Dim obj As New personaBeneficio
            Dim listaInfraestructura As New List(Of personaBeneficio)

            Dim consulta = (From per In HeliosData.personaBeneficio
                            Where
                                CLng(per.documentoventaAbarrotesDet.documentoventaAbarrotes.idCliente) = personasBE.idEntidad And
                                per.documentoventaAbarrotesDet.estadoDistribucion = personasBE.estado
                            Select
                                per.nombrePersona,
                                per.nroDocumento,
                                per.nacionalidad,
                                per.sexo,
                                per.documentoventaAbarrotesDet.nombreItem).ToList

            For Each i In consulta
                obj = New personaBeneficio
                obj.[nombrePersona] = i.[nombrePersona]
                obj.[nroDocumento] = i.[nroDocumento]
                obj.[nacionalidad] = i.[nacionalidad]
                obj.[sexo] = i.[sexo]
                obj.usuarioActualizacion = i.nombreItem

                listaInfraestructura.Add(obj)
            Next

            Return listaInfraestructura
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
