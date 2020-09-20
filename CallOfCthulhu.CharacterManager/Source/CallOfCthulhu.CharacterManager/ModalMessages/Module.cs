using System;
using System.Windows;
using DryIoc;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;

namespace CallOfCthulhu.CharacterManager.ModalMessages
{
    public class Module : IModule
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var container = containerRegistry.GetContainer();

            container.Register<IModalService, ModalService>(Reuse.Singleton);
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            var app = containerProvider.Resolve<IApplicationContext>();

            app.Resources.MergedDictionaries
                .Add(new ResourceDictionary
                {
                    Source = new Uri($"pack://application:,,,/{nameof(ModalMessages)}/Resources.xaml")
                });
        }
    }
}
