Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class correoEntidadesBL
    Inherits BaseBL

    Public Function Insert(ByVal correoEntidadesBE As correoEntidades) As Integer
        Using ts As New TransactionScope
            HeliosData.correoEntidades.Add(correoEntidadesBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return correoEntidadesBE.codigo
        End Using
    End Function

    Public Sub Update(ByVal correoEntidadesBE As correoEntidades)
        Using ts As New TransactionScope
            Dim correoEntidades As correoEntidades = HeliosData.correoEntidades.Where(Function(o) _
                                            o.codigo = correoEntidadesBE.codigo).First()

            correoEntidades.idEmpresa = correoEntidadesBE.idEmpresa
            correoEntidades.idEstablecimiento = correoEntidadesBE.idEstablecimiento
            correoEntidades.idEntidad = correoEntidadesBE.idEntidad
            correoEntidades.tipoEntidad = correoEntidadesBE.tipoEntidad
            correoEntidades.Gop = correoEntidadesBE.Gop
            correoEntidades.tipoCorreo = correoEntidadesBE.tipoCorreo
            correoEntidades.email = correoEntidadesBE.email
            correoEntidades.usuarioActualizacion = correoEntidadesBE.usuarioActualizacion
            correoEntidades.fechaActualizacion = correoEntidadesBE.fechaActualizacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(correoEntidades).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub Delete(ByVal correoEntidadesBE As correoEntidades)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(correoEntidadesBE)
    End Sub

    Public Function GetListar_correoEntidades() As List(Of correoEntidades)
        Return (From a In HeliosData.correoEntidades Select a).ToList
    End Function

    Public Function GetUbicar_correoEntidadesPorID(codigo As Integer) As correoEntidades
        Return (From a In HeliosData.correoEntidades
                 Where a.codigo = codigo Select a).First
    End Function
End Class
