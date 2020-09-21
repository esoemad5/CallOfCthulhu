using CallOfCthulhu.Common;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using CallOfCthulhu.CharacterManager.Models;

namespace CallOfCthulhu.CharacterManager.CharacterCreationWizard.ViewModels
{
    public class CharacterDetailsWizardViewModel : BindableBase
    {
        private readonly CharacterModel _characterModel;

        public DelegateCommand GoToNextPageCommand { get; }

        public CharacterDetailsWizardViewModel()
        {
            _characterModel = new CharacterModel();
            Properties = new ObservableCollection<TextProperty>();
            foreach (var property in _characterModel.CharacterDetails.GetFriendlyPropertyNames())
                Properties.Add(new TextProperty 
                {
                    DisplayName = property,
                    Value = string.Empty
                });
            GoToNextPageCommand = new DelegateCommand(GoToNextPage);
        }

        private ObservableCollection<TextProperty> _properties;
        public ObservableCollection<TextProperty> Properties
        {
            get => _properties;
            set => SetProperty(ref _properties, value);
        }

        private void GoToNextPage()
        {

        }
    }
}
