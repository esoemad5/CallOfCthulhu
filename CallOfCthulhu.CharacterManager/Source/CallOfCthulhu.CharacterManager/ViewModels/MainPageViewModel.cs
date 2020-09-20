using Prism.Commands;
using Prism.Regions;
using CallOfCthulhu.CharacterManager.Framework.Navigation;

namespace CallOfCthulhu.CharacterManager.ViewModels
{
    public class MainPageViewModel : INavigationAware
    {
        #region Fields
        private readonly INavigationService _navigationService;
        public DelegateCommand<string> NavigateCommand { get; }
        #endregion Fields

        #region Constructor
        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommand = new DelegateCommand<string>(Navigate);
        }
        #endregion Constructor

        #region Properties

        #endregion Properties

        #region Command Handlers
        private void Navigate(string target)
        {
            _navigationService.PushPage(target);
        }
        #endregion Command Handlers

        #region Navigation
        public void OnNavigatedTo(NavigationContext navigationContext)
        {

        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }
        #endregion Navigation
    }
}
