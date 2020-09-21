using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallOfCthulhu.CharacterManager.Models
{
    public abstract class AbstractPropertyBase : BindableBase
    {
        private string _displayName;
        public string DisplayName
        {
            get => _displayName;
            set => SetProperty(ref _displayName, value);
        }

        private string _value;
        public string Value
        {
            get => _value;
            set
            {
                SetProperty(ref _value, value);
                ValueChanged?.Invoke(this, null);
            }
        }

        public event EventHandler<EventArgs> ValueChanged;
    }

    public class TextProperty : AbstractPropertyBase
    {

    }
}
