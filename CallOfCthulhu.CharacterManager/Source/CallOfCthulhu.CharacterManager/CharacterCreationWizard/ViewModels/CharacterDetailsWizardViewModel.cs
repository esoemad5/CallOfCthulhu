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
        private CharacterModel _characterModel;

        public DelegateCommand GoToNextPageCommand { get; }

        public CharacterDetailsWizardViewModel()
        {
            _characterModel = new CharacterModel();
            GoToNextPageCommand = new DelegateCommand(GoToNextPage);
        }

        //private List<PropertyWrapper> _properties;
        //public List<PropertyWrapper> Properties
        //{
        //    get => _properties;
        //    set => SetProperty(ref _properties, value);
        //}
        

        private void GoToNextPage()
        {

        }
    }
}
