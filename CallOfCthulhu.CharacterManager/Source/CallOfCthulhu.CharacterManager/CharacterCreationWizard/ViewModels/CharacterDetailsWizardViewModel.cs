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
            //All these properties have an event handler set up for notification stuff. Idk if its needed.
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
            var propertiesDictionary = Properties.ToDictionary(p => p.DisplayName, q => q.Value);
            if (!int.TryParse(propertiesDictionary["Age"], out var parsedAge))
                throw new Exception(); //TODO: Handle validation errors better.
            _characterModel.CharacterDetails.Age = parsedAge;
            _characterModel.CharacterDetails.Birthplace = propertiesDictionary["Birthplace"];
            _characterModel.CharacterDetails.CampaignSetting = propertiesDictionary["Campaign Setting"];
            _characterModel.CharacterDetails.Name = propertiesDictionary["Name"];
            _characterModel.CharacterDetails.Occupation = propertiesDictionary["Occupation"];
            _characterModel.CharacterDetails.Player = propertiesDictionary["Player"];
            _characterModel.CharacterDetails.Residence = propertiesDictionary["Residence"];
            _characterModel.CharacterDetails.Sex = propertiesDictionary["Sex"];

            //Navigate to next step and pass model as a parameter
        }
    }
}
