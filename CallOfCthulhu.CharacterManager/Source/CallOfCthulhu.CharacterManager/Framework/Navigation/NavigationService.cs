using System;
using System.Collections.Generic;
using Prism.Regions;

namespace CallOfCthulhu.CharacterManager.Framework.Navigation
{
    public class NavigationService : INavigationService
    {
        private IRegionNavigationService PrismNavigationService { get; }

        public NavigationService(IRegionManager regionManager)
        {
            PrismNavigationService = regionManager?.Regions[Regions.MainContent]?.NavigationService;
        }

        public void PushPage(string target, IDictionary<string, object> parameters = null)
        {
            var targetUri = new Uri(target, UriKind.RelativeOrAbsolute);

            NavigationParameters navParams = null;

            if (parameters?.Count > 0)
            {
                navParams = new NavigationParameters();
                foreach (var arg in parameters)
                    navParams.Add(arg.Key, arg.Value);
            }

            PrismNavigationService.RequestNavigate(targetUri, navParams);
        }

        public void PopPage(string target = null)
        {
            var journal = PrismNavigationService.Journal;

            if (string.IsNullOrEmpty(target))
            {
                if (journal.CanGoBack)
                    journal.GoBack();
                return;
            }

            var targetUri = new Uri(target, UriKind.Absolute);
            do
            {
                if (!journal.CanGoBack)
                    return;

                journal.GoBack();
            } while (journal.CurrentEntry.Uri != targetUri);
        }

        public void Swap(string target, IDictionary<string, object> parameters = null)
        {
            PopPage();
            PushPage(target, parameters);
        }
    }
}
