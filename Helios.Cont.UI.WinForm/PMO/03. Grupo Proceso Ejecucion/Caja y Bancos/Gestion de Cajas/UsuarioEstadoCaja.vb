Imports Helios.Cont.Business.Entity
Imports Helios.General
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class UsuarioEstadoCaja

    Friend Sub GetSaldoActual(Usuarios As GFichaUsuario)
        Dim cajaSA As New DocumentoCajaSA
        Dim caja As New documentoCaja
        Dim ingresosMN As Decimal = 0
        Dim EgresosMN As Decimal = 0
        Dim saldo As Decimal = 0

        Dim ingresosME As Decimal = 0
        Dim EgresosME As Decimal = 0
        Dim saldoME As Decimal = 0

        caja = cajaSA.GetSaldoCuentaFinancieraXusuario(New documentoCaja With {.entidadFinanciera = TmpIdEntidadFinanciera,
                                                                               .usuarioModificacion = usuario.IDUsuario})

        ingresosMN = caja.MontoIngresosMN
        EgresosMN = caja.MontoEgresosMN
        saldo = Usuarios.FondoMN + ingresosMN - EgresosMN

        ingresosME = caja.MontoIngresosME
        EgresosME = caja.MontoEgresosME
        saldoME = Usuarios.FondoME + ingresosME - EgresosME

        '----------------------------------------------------
        'actualizando saldos del usuario de caja actual

        GFichaUsuarios.SaldoMN = saldo
        GFichaUsuarios.SaldoME = saldoME

    End Sub

    Friend Function GetIngresos(Usuario As GFichaUsuario) As List(Of Decimal)
        Dim cajaSA As New DocumentoCajaSA
        Dim caja As New documentoCaja
        Dim ingresosMN As Decimal = 0
        Dim ingresosME As Decimal = 0
        Dim listaVal As New List(Of Decimal)

        caja = cajaSA.ResumenTransaccionesxUsuarioDEP(Usuario.IdCajaUsuario)

        ingresosMN = caja.MontoIngresosMN

        ingresosME = caja.MontoIngresosME
     
        '----------------------------------------------------
        'actualizando saldos del usuario de caja actual

        listaVal.Add(ingresosMN)
        listaVal.Add(ingresosME)

        Return listaVal
    End Function

    Friend Function GetSalidas(Usuario As GFichaUsuario) As List(Of Decimal)
        Dim cajaSA As New DocumentoCajaSA
        Dim caja As New documentoCaja

        Dim EgresosMN As Decimal = 0
        Dim EgresosME As Decimal = 0
        Dim listaVal As New List(Of Decimal)

        caja = cajaSA.ResumenTransaccionesxUsuarioDEP(Usuario.IdCajaUsuario)

        EgresosMN = caja.MontoEgresosMN

        EgresosME = caja.MontoEgresosME

        '----------------------------------------------------
        'actualizando saldos del usuario de caja actual

        listaVal.Add(EgresosMN)
        listaVal.Add(EgresosME)

        Return listaVal
    End Function

End Class
