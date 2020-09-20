using System.Windows;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using CallOfCthulhu.CharacterManager.Framework.Navigation;
using CallOfCthulhu.CharacterManager.ModalMessages;

namespace CallOfCthulhu.CharacterManager.ViewModels
{
    public class SecondPageViewModel : INavigationAware 
    {
        #region Fields
        private readonly INavigationService _navigationService;
        private readonly IModalService _modalService;
        public DelegateCommand NavigateBackCommand { get; }
        public DelegateCommand ShowConfirmationDialogCommand { get; }
        #endregion Fields

        #region Constructor

        public SecondPageViewModel(INavigationService navigationService, IModalService modalService)
        {
            _navigationService = navigationService;
            _modalService = modalService;

            NavigateBackCommand = new DelegateCommand(NavigateBackTo);
            ShowConfirmationDialogCommand = new DelegateCommand(ShowConfirmationDialog);
        }

        #endregion Constructor

        #region Properties

        #endregion Properties

        #region Command Handlers

        private void NavigateBackTo()
        {
            _navigationService.PopPage();
        }

        private async void ShowConfirmationDialog()
        {
            var confirmationDialog = new ConfirmationDialogViewModel
            {
                Title = "Modal Message Example",
                Message = "This is an example of a modal message",
                Buttons = MessageBoxButton.YesNo,
                Icon = MessageBoxImage.Information
            };

            var result = await _modalService.ShowOverlayAsync(confirmationDialog);

            //If no was selected
            if (!result.HasValue || !result.Value)
                return;
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
