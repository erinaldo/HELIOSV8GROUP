Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class hojaPlaneamientoBL
    Inherits BaseBL

    Public Function Insert(ByVal hojaPlaneamientoBE As hojaPlaneamiento) As Integer
        Using ts As New TransactionScope
            HeliosData.hojaPlaneamiento.Add(hojaPlaneamientoBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return hojaPlaneamientoBE.Secuencia
        End Using
    End Function

    Public Sub Update(ByVal hojaPlaneamientoBE As hojaPlaneamiento)
        Using ts As New TransactionScope
            Dim hojaPlane As hojaPlaneamiento = HeliosData.hojaPlaneamiento.Where(Function(o) _
                                            o.idEmpresa = hojaPlaneamientoBE.idEmpresa _
                                            And o.idEstablecimiento = hojaPlaneamientoBE.idEstablecimiento _
                                            And o.idProyecto = hojaPlaneamientoBE.idProyecto _
                                            And o.idEvento = hojaPlaneamientoBE.idEvento _
                                            And o.secuencia = hojaPlaneamientoBE.secuencia).First()

            hojaPlane.proceso = hojaPlaneamientoBE.proceso
            hojaPlane.detalle = hojaPlaneamientoBE.detalle
            hojaPlane.unidad = hojaPlaneamientoBE.unidad
            hojaPlane.cantidad = hojaPlaneamientoBE.cantidad
            hojaPlane.ejecDiariaPersona = hojaPlaneamientoBE.ejecDiariaPersona
            hojaPlane.inicioEjec = hojaPlaneamientoBE.inicioEjec
            hojaPlane.finEjec = hojaPlaneamientoBE.finEjec
            hojaPlane.estado = hojaPlaneamientoBE.estado
            hojaPlane.orden = hojaPlaneamientoBE.orden
            hojaPlane.usuarioActualizacion = hojaPlaneamientoBE.usuarioActualizacion
            hojaPlane.fechaActualizacion = hojaPlaneamientoBE.fechaActualizacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(hojaPlane).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal hojaPlaneamientoBE As hojaPlaneamiento)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(hojaPlaneamientoBE)
    End Sub

    Public Function GetListar_hojaPlaneamiento() As List(Of hojaPlaneamiento)
        Return (From a In HeliosData.hojaPlaneamiento Select a).ToList
    End Function

    Public Function GetUbicar_hojaPlaneamientoPorID(Secuencia As Integer) As hojaPlaneamiento
        Return (From a In HeliosData.hojaPlaneamiento
                 Where a.secuencia = Secuencia Select a).First
    End Function
End Class
