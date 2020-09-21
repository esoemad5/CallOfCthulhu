using CallOfCthulhu.Common;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallOfCthulhu.CharacterManager.CharacterCreationWizard.ViewModels
{
    public class CharacterDetailsWizardViewModel : BindableBase
    {
        public DelegateCommand GoToNextPageCommand { get; }

        public CharacterDetailsWizardViewModel()
        {
            CharacterModel = new CharacterModel();
            GoToNextPageCommand = new DelegateCommand(GoToNextPage);
        }

        private CharacterModel _characterModel;
        public CharacterModel CharacterModel
        {
            get => _characterModel;
            set => SetProperty(ref _characterModel, value);
        }

        private void GoToNextPage()
        {

        }
    }
}
