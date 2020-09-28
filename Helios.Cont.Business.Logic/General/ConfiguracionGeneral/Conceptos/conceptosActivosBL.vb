Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class conceptosActivosBL
    Inherits BaseBL

    Public Function Insert(ByVal conceptosActivosBE As conceptosActivos) As Integer
        Using ts As New TransactionScope
            HeliosData.conceptosActivos.Add(conceptosActivosBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return conceptosActivosBE.idConcepto
        End Using
    End Function

    Public Sub Update(ByVal conceptosActivosBE As conceptosActivos)
        Using ts As New TransactionScope
            Dim conceptosActivos As conceptosActivos = HeliosData.conceptosActivos.Where(Function(o) _
                                            o.idConcepto = conceptosActivosBE.idConcepto).First()

            conceptosActivos.idEmpresa = conceptosActivosBE.idEmpresa
            conceptosActivos.descripcion = conceptosActivosBE.descripcion
            conceptosActivos.estado = conceptosActivosBE.estado
            conceptosActivos.usuarioActualizacion = conceptosActivosBE.usuarioActualizacion
            conceptosActivos.fechaActualizacion = conceptosActivosBE.fechaActualizacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(conceptosActivos).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub Delete(ByVal conceptosActivosBE As conceptosActivos)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(conceptosActivosBE)
    End Sub

    Public Function GetListar_conceptosActivos() As List(Of conceptosActivos)
        Return (From a In HeliosData.conceptosActivos Select a).ToList
    End Function

    Public Function GetUbicar_conceptosActivosPorID(idConcepto As String) As conceptosActivos
        Return (From a In HeliosData.conceptosActivos
                Where a.idConcepto = idConcepto Select a).First
    End Function
End Class
