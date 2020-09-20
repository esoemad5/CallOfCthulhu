using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Threading;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using CallOfCthulhu.CharacterManager.Framework.Navigation;
using CallOfCthulhu.CharacterManager.ViewModels;
using CallOfCthulhu.CharacterManager.Views;

namespace CallOfCthulhu.CharacterManager
{
    public interface IApplicationContext
    {
        /// <summary>
        /// Location where shared application data is stored (non-user specific)
        /// </summary>
        string SharedDataDirectory { get; }

        ResourceDictionary Resources { get; }
    }

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : IApplicationContext
    {
        private static IEnumerable<Type> ModuleTypes => new[]
        {
            typeof(ModalMessages.Module)
        };

        public string SharedDataDirectory
        {
            get
            {
                var programData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                //TODO Change below
                return Path.Combine(programData, @"esoemad5sSideProjects\CallOfCthulhu.CharacterManager");
            }
        }

        private IRegionManager RegionManager { get; set; }

        private IRegionNavigationService NavigationService
            => RegionManager?.Regions[Regions.MainContent]?.NavigationService;

        public App()
        {
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledDomainException;
            DispatcherUnhandledException += OnUnhandledDispatcherException;

            InitializeComponent();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            
            RegionManager = Container.Resolve<IRegionManager>();

            NavigationService.RequestNavigate(Pages.Main);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance(typeof(IApplicationContext), this);
            containerRegistry.RegisterSingleton<INavigationService, NavigationService>();

            RegisterViews(containerRegistry);   
        }

        private static void RegisterViews(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainPageView, MainPageViewModel>(Pages.Main);
            containerRegistry.RegisterForNavigation<SecondPageView, SecondPageViewModel>(Pages.Second);
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);

            foreach (var moduleType in ModuleTypes)
            {
                moduleCatalog.AddModule(new ModuleInfo
                {
                    ModuleName = moduleType.AssemblyQualifiedName,
                    ModuleType = moduleType.AssemblyQualifiedName
                });
            }
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        private void OnUnhandledDispatcherException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            //TODO: Show a modal
            //WpfMessageBox.Show(MainWindow,
            //    e.Exception.Message,
            //    "Error",
            //    MessageBoxButton.OK,
            //    MessageBoxImage.Error,
            //    "Copy Exception Details",
            //    e.Exception);

            //e.Handled = true;
        }

        private void OnUnhandledDomainException(object sender, UnhandledExceptionEventArgs e)
        {
            //TODO: Show a modal
            //if (e.ExceptionObject is Exception exception)
            //    WpfMessageBox.Show(MainWindow,
            //        exception.Message,
            //        "Error",
            //        MessageBoxButton.OK,
            //        MessageBoxImage.Error,
            //        "Copy Exception Details",
            //        exception);
        }
    }
}
