Imports Helios.Seguridad.Business.Entity
Imports System.Transactions

Public Class AsegurableBL
    Inherits BaseBL
    ''' <summary>
    ''' Retorna la lista de objetos ASEGURABLE que son hijos de forma recursiva 
    ''' </summary>
    ''' <param name="item"></param>
    ''' <returns></returns>
    ''' <remarks>Falta implementar la parte recursiva</remarks>

    Public Function GetAllByIDPadreClienteAsegurable(ByVal item As Asegurable) As List(Of Asegurable)
        Return (From padre In SeguridadData.Asegurable
                Join hijo In SeguridadData.Asegurable On hijo.IDAsegurablePadre Equals padre.IDAsegurable
                Where padre.IDEmpresa = item.IDEmpresa And padre.IDEstablecimiento = item.IDEstablecimiento AndAlso padre.CodAsegurable = item.CodAsegurable
                Select hijo
                ).ToList
    End Function

    Public Function GetAsegurableXidCliente(ByVal item As Asegurable) As List(Of Asegurable)
        Try
            GetAsegurableXidCliente = New List(Of Asegurable)
            Dim asegurableBE As New Asegurable


            Dim CONSULTA = (From padre In SeguridadData.Asegurable
                            Where padre.IDEmpresa = item.IDEmpresa And padre.IDEstablecimiento = item.IDEstablecimiento).ToList


            For Each item In CONSULTA
                asegurableBE = New Asegurable

                asegurableBE.[IDModulo] = item.[IDModulo]
                asegurableBE.[IDAsegurable] = item.[IDAsegurable]
                asegurableBE.[IDAsegurablePadre] = item.[IDAsegurablePadre]
                asegurableBE.[IDEmpresa] = item.[IDEmpresa]
                asegurableBE.[IDEstablecimiento] = item.[IDEstablecimiento]
                asegurableBE.[CodAsegurable] = item.[CodAsegurable]
                asegurableBE.[Nombre] = item.[Nombre]
                asegurableBE.[Descripcion] = item.[Descripcion]
                asegurableBE.[CodRef] = item.[CodRef]
                asegurableBE.[orden] = item.[orden]
                asegurableBE.[UsuarioActualizacion] = item.[UsuarioActualizacion]
                asegurableBE.[FechaActualizacion] = item.[FechaActualizacion]

                GetAsegurableXidCliente.Add(asegurableBE)

            Next


            Return GetAsegurableXidCliente

        Catch ex As Exception
            Throw ex
        End Try


    End Function

    Public Function GetAsegurables() As List(Of Asegurable)
        Return SeguridadData.Asegurable.ToList()
    End Function


    Public Function GetListaAsegurables(listaAsegurable As List(Of Integer)) As List(Of Asegurable)
        Return (From Aseg In SeguridadData.Asegurable
                Where listaAsegurable.Contains(Aseg.IDAsegurable) Order By Aseg.Descripcion).ToList
    End Function


    Public Function GetInsertAsegurable(objAsegurables As Asegurable) As Asegurable
        Try
            Using ts As New TransactionScope

                Dim consulta = (From s In SeguridadData.Asegurable
                                Group s By s.IDEstablecimiento Into g = Group
                                Select New With {
                                .Id = CType(g.Max(Function(p) p.IDAsegurable), Int32?)}).FirstOrDefault

                If (Not IsNothing(consulta)) Then
                    objAsegurables.IDAsegurable = CInt(consulta.Id.GetValueOrDefault) + 1
                Else
                    objAsegurables.IDAsegurable = 0
                End If

                SeguridadData.Asegurable.Add(objAsegurables)
                SeguridadData.SaveChanges()
                ts.Complete()
                Return objAsegurables
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function Insert(objAsegurables As Asegurable) As Asegurable
        Dim asegurable As New Asegurable
        Try
            Using ts As New TransactionScope

                asegurable = New Asegurable With
                {
                 .IDAsegurable = objAsegurables.IDAsegurable,
                .IDAsegurablePadre = objAsegurables.IDAsegurablePadre,
                .IDEmpresa = objAsegurables.IDEmpresa,
                .IDEstablecimiento = objAsegurables.IDEstablecimiento,
                .CodAsegurable = objAsegurables.CodAsegurable,
                .Nombre = objAsegurables.Nombre,
                .Descripcion = objAsegurables.Descripcion,
                .CodRef = objAsegurables.CodRef,
                .orden = objAsegurables.orden,
                .UsuarioActualizacion = objAsegurables.UsuarioActualizacion,
                .FechaActualizacion = objAsegurables.FechaActualizacion
                }
                SeguridadData.Asegurable.Add(asegurable)
                SeguridadData.SaveChanges()
                objAsegurables.IDModulo = asegurable.IDModulo
                ts.Complete()
                Return objAsegurables
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ListadoAsegurableXID(idAsegurable As Integer) As Asegurable
        Dim AsegurableBE As Asegurable
        Try
            AsegurableBE = (From be In SeguridadData.Asegurable Where be.IDAsegurable = idAsegurable).FirstOrDefault
            Return AsegurableBE
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function updateAsegurable(ByVal ObjAsegurable As Asegurable) As Asegurable
        Try

            Using ts As New TransactionScope

                Dim asegurableBE As Asegurable = (From be In SeguridadData.Asegurable Where be.IDAsegurable = ObjAsegurable.IDAsegurable).FirstOrDefault

                If (Not IsNothing(asegurableBE)) Then
                    asegurableBE.Nombre = ObjAsegurable.Nombre
                    asegurableBE.Descripcion = ObjAsegurable.Descripcion
                    SeguridadData.SaveChanges()
                    ts.Complete()
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function GetListaAsegurablesPadre(objAsegurable As Asegurable) As List(Of Asegurable)
        Dim AsegurableBE As New Asegurable
        Dim listaASegurable As New List(Of Asegurable)

        Dim consulta = (From a In SeguridadData.Asegurable
                        Order By
                    a.IDAsegurable
                        Select a).ToList

        For Each item In consulta
            AsegurableBE = New Asegurable
            AsegurableBE.IDAsegurable = item.IDAsegurable
            AsegurableBE.IDAsegurablePadre = item.IDAsegurablePadre
            AsegurableBE.Nombre = item.Nombre
            AsegurableBE.Descripcion = item.Descripcion
            AsegurableBE.IDEmpresa = item.IDEmpresa
            AsegurableBE.IDEstablecimiento = item.IDEstablecimiento
            AsegurableBE.FechaActualizacion = item.FechaActualizacion
            AsegurableBE.Autoriza = False
            listaASegurable.Add(AsegurableBE)
        Next
        Return listaASegurable
    End Function

    Public Function GetListaAsegurablesXCliente(objAsegurable As Asegurable) As List(Of Asegurable)
        Dim AsegurableBE As New Asegurable
        Dim listaASegurable As New List(Of Asegurable)

        Dim consulta = (From a In SeguridadData.Asegurable
                        Where a.IDEmpresa = objAsegurable.IDEmpresa And a.IDEstablecimiento = objAsegurable.IDEstablecimiento
                        Order By
                    a.IDAsegurable
                        Select a).ToList

        For Each item In consulta
            AsegurableBE = New Asegurable
            AsegurableBE.IDAsegurable = item.IDAsegurable
            AsegurableBE.IDAsegurablePadre = item.IDAsegurablePadre
            AsegurableBE.Nombre = item.Nombre
            AsegurableBE.Descripcion = item.Descripcion
            AsegurableBE.IDEmpresa = item.IDEmpresa
            AsegurableBE.IDEstablecimiento = item.IDEstablecimiento
            AsegurableBE.FechaActualizacion = item.FechaActualizacion
            AsegurableBE.Autoriza = True
            listaASegurable.Add(AsegurableBE)
        Next
        Return listaASegurable
    End Function

    Public Function GetAsegurablesByPadreXcliente(objAsegurable As Asegurable) As List(Of Asegurable)
        Dim AsegurableBE As New Asegurable
        Dim listaASegurable As New List(Of Asegurable)

        Dim ubicarModuloPadre = SeguridadData.Asegurable.Where(Function(o) o.Nombre = objAsegurable.Nombre And o.IDEmpresa = objAsegurable.IDEmpresa And o.IDEstablecimiento = objAsegurable.IDEstablecimiento).FirstOrDefault

        Dim consulta = (From a In SeguridadData.Asegurable
                        Where a.IDEmpresa = objAsegurable.IDEmpresa And a.IDEstablecimiento = objAsegurable.IDEstablecimiento _
                            And a.IDAsegurablePadre = ubicarModuloPadre.IDAsegurable
                        Order By
                    a.orden
                        Select a).ToList

        For Each item In consulta
            AsegurableBE = New Asegurable
            AsegurableBE.IDAsegurable = item.IDAsegurable
            AsegurableBE.IDAsegurablePadre = item.IDAsegurablePadre
            AsegurableBE.Nombre = item.Nombre
            AsegurableBE.Descripcion = item.Descripcion
            AsegurableBE.IDEmpresa = item.IDEmpresa
            AsegurableBE.IDEstablecimiento = item.IDEstablecimiento
            AsegurableBE.FechaActualizacion = item.FechaActualizacion
            AsegurableBE.Autoriza = False
            listaASegurable.Add(AsegurableBE)
        Next
        Return listaASegurable
    End Function

    Public Function GetListaAsegurablesXClientePOS(objAsegurable As Asegurable) As List(Of Asegurable)
        Dim AsegurableBE As New Asegurable
        Dim listaASegurable As New List(Of Asegurable)

        Dim consulta = (From a In SeguridadData.Asegurable
                        Where a.IDEmpresa = objAsegurable.IDEmpresa And a.IDEstablecimiento = objAsegurable.IDEstablecimiento And
                            a.CodAsegurable = objAsegurable.CodAsegurable
                        Order By
                    a.IDAsegurable
                        Select a).ToList

        For Each item In consulta
            AsegurableBE = New Asegurable
            AsegurableBE.IDAsegurable = item.IDAsegurable
            AsegurableBE.IDAsegurablePadre = item.IDAsegurablePadre
            AsegurableBE.Nombre = item.Nombre
            AsegurableBE.Descripcion = item.Descripcion
            AsegurableBE.IDEmpresa = item.IDEmpresa
            AsegurableBE.IDEstablecimiento = item.IDEstablecimiento
            AsegurableBE.FechaActualizacion = item.FechaActualizacion
            AsegurableBE.Autoriza = True
            listaASegurable.Add(AsegurableBE)
        Next
        Return listaASegurable
    End Function

End Class
