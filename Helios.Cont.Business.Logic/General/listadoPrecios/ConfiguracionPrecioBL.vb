Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class ConfiguracionPrecioBL
    Inherits BaseBL

    Public Sub GrabarPrecioGeneral(objPrecio As configuracionPrecio)

        Using ts As New TransactionScope
            Dim precioBE As New configuracionPrecio With
                {
                    .precio = objPrecio.precio,
                    .tasaPorcentaje = objPrecio.tasaPorcentaje,
                    .tipo = objPrecio.tipo
                }

            HeliosData.configuracionPrecio.Add(precioBE)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub DeletePrecioGeneral(ByVal configuracionPrecioBE As configuracionPrecio)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(configuracionPrecioBE)
    End Sub

    Public Sub UpdatePrecioGeneral(objPrecio As configuracionPrecio)
        Using ts As New TransactionScope
            Dim totCaja As configuracionPrecio = HeliosData.configuracionPrecio.Where(Function(o) _
                                            o.idPrecio = objPrecio.idPrecio).First()
            totCaja.precio = objPrecio.precio
            totCaja.tasaPorcentaje = objPrecio.tasaPorcentaje
            totCaja.tipo = objPrecio.tipo
            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub

    Public Sub Grabar(objPrecio As configuracionPrecio)
        Using ts As New TransactionScope
            Dim precioBE As New configuracionPrecio With
                {
                    .precio = objPrecio.precio,
                    .tasaPorcentaje = objPrecio.tasaPorcentaje,
                    .tipo = objPrecio.tipo
                }

            HeliosData.configuracionPrecio.Add(precioBE)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function ListadoPrecios() As List(Of configuracionPrecio)
        Return HeliosData.configuracionPrecio.ToList
    End Function

    Public Function EncontrarPrecioXitem(configBE As configuracionPrecio) As configuracionPrecio
        Return HeliosData.configuracionPrecio.Where(Function(o) o.idPrecio = configBE.idPrecio).FirstOrDefault
    End Function

End Class
