Imports Helios.Cont.WCFService.ServiceImplementation
Imports Helios.Seguridad.WCFService.ServiceImplementation
Public NotInheritable Class Principal
    <STAThread()>
    Public Shared Sub Main()
        '   Dim objService As ContService = Nothing
        Try
            Using SeguridadServiceHost As ServiceModel.ServiceHost = New ServiceModel.ServiceHost(GetType(SeguridadService))
                SeguridadServiceHost.Open()
                Using serviceHost As ServiceModel.ServiceHost = New ServiceModel.ServiceHost(GetType(ContService))
                    Application.EnableVisualStyles()
                    Application.SetCompatibleTextRenderingDefault(False)
                    serviceHost.Open()
                    '  Dim FormPrincipal = frmMaestroModuloPOSV2
                    Dim FormPrincipal = FormOrgainizacionV2 'frmPantallaVendedorPOS
                    FormPrincipal.StartPosition = FormStartPosition.CenterParent
                    Application.Run(FormPrincipal)
                    FormPrincipal.Activate()
                    serviceHost.Close()
                End Using
                SeguridadServiceHost.Close()
            End Using

            'Catch LicEx As MyLicenseException
            'Se cierra la aplicación solamente
        Catch ex As Exception
            MessageBox.Show("Error" + ex.Message)
        End Try
    End Sub
    'Public Shared Sub Encriptar()

    '    Dim config As Configuration = _
    '               ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
    '    config.ConnectionStrings.SectionInformation.ProtectSection(Nothing)
    '    ' We must save the changes to the configuration file.
    '    config.Save(ConfigurationSaveMode.Full, True)

    '    Dim vaultProtector As ConfigSectionProtector

    '    vaultProtector = New ConfigSectionProtector("appSettings")
    '    vaultProtector.ProtectSection()

    '    vaultProtector = New ConfigSectionProtector("mailSettings")
    '    vaultProtector.ProtectSection()
    'End Sub
End Class





