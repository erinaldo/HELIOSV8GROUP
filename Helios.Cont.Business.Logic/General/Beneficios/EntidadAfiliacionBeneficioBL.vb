Imports System.Transactions
Imports Helios.Cont.Business.Entity

Public Class EntidadAfiliacionBeneficioBL
    Inherits BaseBL

    Public Function GetEntidadAfiliacionConteo(be As EntidadAfiliacionBeneficio) As List(Of EntidadAfiliacionBeneficio)
        Dim query = HeliosData.EntidadAfiliacionBeneficio.GroupBy(Function(g) New With
                 {
                                                                                                                                          Key g.status
                                                                                                                                          }).
           Select(Function(group) New With
           {
           .status = group.Key.status,
           .TotalCount = group.Count()
                      }).ToList()

        GetEntidadAfiliacionConteo = New List(Of EntidadAfiliacionBeneficio)
        For Each i In query
            GetEntidadAfiliacionConteo.Add(New EntidadAfiliacionBeneficio With
                                    {
                                    .status = i.status,
                                    .Conteo = i.TotalCount
                                    })
        Next
    End Function

    Public Sub ChangeStatusAfiliado(be As EntidadAfiliacionBeneficio)
        Using ts As New TransactionScope()

            Dim con = HeliosData.EntidadAfiliacionBeneficio.Where(Function(o) o.idEntidad = be.idEntidad).SingleOrDefault

            Dim cli = HeliosData.entidad.Where(Function(o) o.idEntidad = be.idEntidad).FirstOrDefault
            cli.tieneBeneficio = True

            con.status = General.StatusAfiliacionBeneficiosCliente.Aprobado
            con.fechaAprobacion = DateTime.Now
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub EntidadAfiliacionBeneficioSave(be As EntidadAfiliacionBeneficio)
        Using ts As New TransactionScope()
            HeliosData.EntidadAfiliacionBeneficio.Add(be)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function EntidadAfiliacionBeneficioSelXEntidad(be As EntidadAfiliacionBeneficio) As EntidadAfiliacionBeneficio
        Dim consulta = (From n In HeliosData.EntidadAfiliacionBeneficio
                        Where n.idEntidad = be.idEntidad
                        Select
                           n.idEntidad,
                           n.fechaPedido,
                            n.fechaAprobacion,
                            n.notas,
                            n.status).SingleOrDefault

        If consulta IsNot Nothing Then
            EntidadAfiliacionBeneficioSelXEntidad = New EntidadAfiliacionBeneficio With
        {
        .idEntidad = consulta.idEntidad,
        .fechaPedido = consulta.fechaPedido,
        .fechaAprobacion = consulta.fechaAprobacion,
        .notas = consulta.notas,
        .status = consulta.status
        }
        Else
            Return Nothing
        End If

    End Function


    Public Function EntidadAfiliacionBeneficioStatus(be As EntidadAfiliacionBeneficio) As List(Of EntidadAfiliacionBeneficio)
        Dim consulta = (From n In HeliosData.EntidadAfiliacionBeneficio
                        Join ent In HeliosData.entidad
                                On ent.idEntidad Equals n.idEntidad
                        Where n.status = be.status
                        Select
                            n.idEntidad,
                            ent.nombreCompleto,
                            ent.nrodoc,
                            n.fechaPedido,
                            n.fechaAprobacion,
                            n.notas,
                            n.status).ToList

        EntidadAfiliacionBeneficioStatus = New List(Of EntidadAfiliacionBeneficio)
        For Each i In consulta
            EntidadAfiliacionBeneficioStatus.Add(New EntidadAfiliacionBeneficio With
                                                     {
                                                     .idEntidad = i.idEntidad,
                                                     .fechaPedido = i.fechaPedido,
                                                     .fechaAprobacion = i.fechaAprobacion,
                                                     .notas = i.notas,
                                                     .status = i.status,
                                                     .entidad = New entidad With
                                                     {
                                                     .idEntidad = i.idEntidad,
                                                     .nombreCompleto = i.nombreCompleto,
                                                     .nrodoc = i.nrodoc
                                                     }
                                                 })
        Next

    End Function

End Class
