
'------------------------------------------------------------------------------
' <auto-generated>
'    Este código se generó a partir de una plantilla.
'
'    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
'    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Data.Objects
Imports System.Data.Objects.DataClasses
Imports System.Data.EntityClient
Imports System.ComponentModel
Imports System.Xml.Serialization
Imports System.Runtime.Serialization

<Assembly: EdmSchemaAttribute("11566604-07e6-4409-a0e7-a1541f99c007")>

#Region "Contextos"

''' <summary>
''' No hay documentación de metadatos disponible.
''' </summary>
Public Partial Class HELIOSEntities
    Inherits ObjectContext

    #Region "Constructors"

    ''' <summary>
    ''' Inicializa un nuevo objeto HELIOSEntities usando la cadena de conexión encontrada en la sección 'HELIOSEntities' del archivo de configuración de la aplicación.
    ''' </summary>
    Public Sub New()
        MyBase.New("name=HELIOSEntities", "HELIOSEntities")
    MyBase.ContextOptions.LazyLoadingEnabled = true
        OnContextCreated()
    End Sub

    ''' <summary>
    ''' Inicializar un nuevo objeto HELIOSEntities.
    ''' </summary>
    Public Sub New(ByVal connectionString As String)
        MyBase.New(connectionString, "HELIOSEntities")
    MyBase.ContextOptions.LazyLoadingEnabled = true
        OnContextCreated()
    End Sub

    ''' <summary>
    ''' Inicializar un nuevo objeto HELIOSEntities.
    ''' </summary>
    Public Sub New(ByVal connection As EntityConnection)
        MyBase.New(connection, "HELIOSEntities")
    MyBase.ContextOptions.LazyLoadingEnabled = true
        OnContextCreated()
    End Sub

    #End Region

    #Region "Partial Methods"

    Partial Private Sub OnContextCreated()
    End Sub

    #End Region

    #Region "Propiedades de ObjectSet"

    ''' <summary>
    ''' No hay documentación de metadatos disponible.
    ''' </summary>
    Public ReadOnly Property empresa() As ObjectSet(Of empresa)
        Get
            If (_empresa Is Nothing) Then
                _empresa = MyBase.CreateObjectSet(Of empresa)("empresa")
            End If
            Return _empresa
        End Get
    End Property

    Private _empresa As ObjectSet(Of empresa)

    #End Region
    #Region "Métodos AddTo"

    ''' <summary>
    ''' Método desusado para agregar un nuevo objeto al EntitySet empresa. Considere la posibilidad de usar el método .Add de la propiedad ObjectSet(Of T) asociada.
    ''' </summary>
    Public Sub AddToempresa(ByVal empresa As empresa)
        MyBase.AddObject("empresa", empresa)
    End Sub

    #End Region
    #Region "Importaciones de funciones"

    ''' <summary>
    ''' No hay documentación de metadatos disponible.
    ''' </summary>
    Public Function load_empresas() As ObjectResult(Of empresa)
        Return MyBase.ExecuteFunction(Of empresa)("load_empresas")

    End Function
    ''' <summary>
    ''' No hay documentación de metadatos disponible.
    ''' </summary>
    ''' <param name="mergeOption"></param>
    Public Function load_empresas(mergeOption As MergeOption) As ObjectResult(Of empresa)
        Return MyBase.ExecuteFunction(Of empresa)("load_empresas", mergeOption)

    End Function

    #End Region
End Class

#End Region
#Region "Entidades"

''' <summary>
''' No hay documentación de metadatos disponible.
''' </summary>
<EdmEntityTypeAttribute(NamespaceName:="HELIOSModel", Name:="empresa")>
<Serializable()>
<DataContractAttribute(IsReference:=True)>
Public Partial Class empresa
    Inherits EntityObject
    #Region "Método de generador"

    ''' <summary>
    ''' Crear un nuevo objeto empresa.
    ''' </summary>
    ''' <param name="idEmpresa">Valor inicial de la propiedad idEmpresa.</param>
    Public Shared Function Createempresa(idEmpresa As Global.System.String) As empresa
        Dim empresa as empresa = New empresa
        empresa.idEmpresa = idEmpresa
        Return empresa
    End Function

    #End Region
    #Region "Propiedades primitivas"

    ''' <summary>
    ''' No hay documentación de metadatos disponible.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=true, IsNullable:=false)>
    <DataMemberAttribute()>
    Public Property idEmpresa() As Global.System.String
        Get
            Return _idEmpresa
        End Get
        Set
            If (_idEmpresa <> Value) Then
                OnidEmpresaChanging(value)
                ReportPropertyChanging("idEmpresa")
                _idEmpresa = StructuralObject.SetValidValue(value, false)
                ReportPropertyChanged("idEmpresa")
                OnidEmpresaChanged()
            End If
        End Set
    End Property

    Private _idEmpresa As Global.System.String
    Private Partial Sub OnidEmpresaChanging(value As Global.System.String)
    End Sub

    Private Partial Sub OnidEmpresaChanged()
    End Sub

    ''' <summary>
    ''' No hay documentación de metadatos disponible.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true)>
    <DataMemberAttribute()>
    Public Property razonSocial() As Global.System.String
        Get
            Return _razonSocial
        End Get
        Set
            OnrazonSocialChanging(value)
            ReportPropertyChanging("razonSocial")
            _razonSocial = StructuralObject.SetValidValue(value, true)
            ReportPropertyChanged("razonSocial")
            OnrazonSocialChanged()
        End Set
    End Property

    Private _razonSocial As Global.System.String
    Private Partial Sub OnrazonSocialChanging(value As Global.System.String)
    End Sub

    Private Partial Sub OnrazonSocialChanged()
    End Sub

    ''' <summary>
    ''' No hay documentación de metadatos disponible.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true)>
    <DataMemberAttribute()>
    Public Property nombreCorto() As Global.System.String
        Get
            Return _nombreCorto
        End Get
        Set
            OnnombreCortoChanging(value)
            ReportPropertyChanging("nombreCorto")
            _nombreCorto = StructuralObject.SetValidValue(value, true)
            ReportPropertyChanged("nombreCorto")
            OnnombreCortoChanged()
        End Set
    End Property

    Private _nombreCorto As Global.System.String
    Private Partial Sub OnnombreCortoChanging(value As Global.System.String)
    End Sub

    Private Partial Sub OnnombreCortoChanged()
    End Sub

    ''' <summary>
    ''' No hay documentación de metadatos disponible.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true)>
    <DataMemberAttribute()>
    Public Property ruc() As Global.System.String
        Get
            Return _ruc
        End Get
        Set
            OnrucChanging(value)
            ReportPropertyChanging("ruc")
            _ruc = StructuralObject.SetValidValue(value, true)
            ReportPropertyChanged("ruc")
            OnrucChanged()
        End Set
    End Property

    Private _ruc As Global.System.String
    Private Partial Sub OnrucChanging(value As Global.System.String)
    End Sub

    Private Partial Sub OnrucChanged()
    End Sub

    ''' <summary>
    ''' No hay documentación de metadatos disponible.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true)>
    <DataMemberAttribute()>
    Public Property direccion() As Global.System.String
        Get
            Return _direccion
        End Get
        Set
            OndireccionChanging(value)
            ReportPropertyChanging("direccion")
            _direccion = StructuralObject.SetValidValue(value, true)
            ReportPropertyChanged("direccion")
            OndireccionChanged()
        End Set
    End Property

    Private _direccion As Global.System.String
    Private Partial Sub OndireccionChanging(value As Global.System.String)
    End Sub

    Private Partial Sub OndireccionChanged()
    End Sub

    ''' <summary>
    ''' No hay documentación de metadatos disponible.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true)>
    <DataMemberAttribute()>
    Public Property telefono() As Global.System.String
        Get
            Return _telefono
        End Get
        Set
            OntelefonoChanging(value)
            ReportPropertyChanging("telefono")
            _telefono = StructuralObject.SetValidValue(value, true)
            ReportPropertyChanged("telefono")
            OntelefonoChanged()
        End Set
    End Property

    Private _telefono As Global.System.String
    Private Partial Sub OntelefonoChanging(value As Global.System.String)
    End Sub

    Private Partial Sub OntelefonoChanged()
    End Sub

    ''' <summary>
    ''' No hay documentación de metadatos disponible.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true)>
    <DataMemberAttribute()>
    Public Property fax() As Global.System.String
        Get
            Return _fax
        End Get
        Set
            OnfaxChanging(value)
            ReportPropertyChanging("fax")
            _fax = StructuralObject.SetValidValue(value, true)
            ReportPropertyChanged("fax")
            OnfaxChanged()
        End Set
    End Property

    Private _fax As Global.System.String
    Private Partial Sub OnfaxChanging(value As Global.System.String)
    End Sub

    Private Partial Sub OnfaxChanged()
    End Sub

    ''' <summary>
    ''' No hay documentación de metadatos disponible.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true)>
    <DataMemberAttribute()>
    Public Property celular() As Global.System.String
        Get
            Return _celular
        End Get
        Set
            OncelularChanging(value)
            ReportPropertyChanging("celular")
            _celular = StructuralObject.SetValidValue(value, true)
            ReportPropertyChanged("celular")
            OncelularChanged()
        End Set
    End Property

    Private _celular As Global.System.String
    Private Partial Sub OncelularChanging(value As Global.System.String)
    End Sub

    Private Partial Sub OncelularChanged()
    End Sub

    ''' <summary>
    ''' No hay documentación de metadatos disponible.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true)>
    <DataMemberAttribute()>
    Public Property e_mail() As Global.System.String
        Get
            Return _e_mail
        End Get
        Set
            One_mailChanging(value)
            ReportPropertyChanging("e_mail")
            _e_mail = StructuralObject.SetValidValue(value, true)
            ReportPropertyChanged("e_mail")
            One_mailChanged()
        End Set
    End Property

    Private _e_mail As Global.System.String
    Private Partial Sub One_mailChanging(value As Global.System.String)
    End Sub

    Private Partial Sub One_mailChanged()
    End Sub

    ''' <summary>
    ''' No hay documentación de metadatos disponible.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true)>
    <DataMemberAttribute()>
    Public Property regimen() As Global.System.String
        Get
            Return _regimen
        End Get
        Set
            OnregimenChanging(value)
            ReportPropertyChanging("regimen")
            _regimen = StructuralObject.SetValidValue(value, true)
            ReportPropertyChanged("regimen")
            OnregimenChanged()
        End Set
    End Property

    Private _regimen As Global.System.String
    Private Partial Sub OnregimenChanging(value As Global.System.String)
    End Sub

    Private Partial Sub OnregimenChanged()
    End Sub

    ''' <summary>
    ''' No hay documentación de metadatos disponible.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true)>
    <DataMemberAttribute()>
    Public Property actividad() As Global.System.String
        Get
            Return _actividad
        End Get
        Set
            OnactividadChanging(value)
            ReportPropertyChanging("actividad")
            _actividad = StructuralObject.SetValidValue(value, true)
            ReportPropertyChanged("actividad")
            OnactividadChanged()
        End Set
    End Property

    Private _actividad As Global.System.String
    Private Partial Sub OnactividadChanging(value As Global.System.String)
    End Sub

    Private Partial Sub OnactividadChanged()
    End Sub

    ''' <summary>
    ''' No hay documentación de metadatos disponible.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true)>
    <DataMemberAttribute()>
    Public Property usuarioActualizacion() As Global.System.String
        Get
            Return _usuarioActualizacion
        End Get
        Set
            OnusuarioActualizacionChanging(value)
            ReportPropertyChanging("usuarioActualizacion")
            _usuarioActualizacion = StructuralObject.SetValidValue(value, true)
            ReportPropertyChanged("usuarioActualizacion")
            OnusuarioActualizacionChanged()
        End Set
    End Property

    Private _usuarioActualizacion As Global.System.String
    Private Partial Sub OnusuarioActualizacionChanging(value As Global.System.String)
    End Sub

    Private Partial Sub OnusuarioActualizacionChanged()
    End Sub

    ''' <summary>
    ''' No hay documentación de metadatos disponible.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true)>
    <DataMemberAttribute()>
    Public Property fechaActualizacion() As Nullable(Of Global.System.DateTime)
        Get
            Return _fechaActualizacion
        End Get
        Set
            OnfechaActualizacionChanging(value)
            ReportPropertyChanging("fechaActualizacion")
            _fechaActualizacion = StructuralObject.SetValidValue(value)
            ReportPropertyChanged("fechaActualizacion")
            OnfechaActualizacionChanged()
        End Set
    End Property

    Private _fechaActualizacion As Nullable(Of Global.System.DateTime)
    Private Partial Sub OnfechaActualizacionChanging(value As Nullable(Of Global.System.DateTime))
    End Sub

    Private Partial Sub OnfechaActualizacionChanged()
    End Sub

    #End Region
End Class

#End Region

