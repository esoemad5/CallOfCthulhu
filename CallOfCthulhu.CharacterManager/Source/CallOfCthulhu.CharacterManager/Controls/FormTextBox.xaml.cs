using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CallOfCthulhu.CharacterManager.Controls
{
    /// <summary>
    /// Interaction logic for FormTextBox.xaml
    /// </summary>
    public partial class FormTextBox : UserControl
    {
        public FormTextBox()
        {
            InitializeComponent();
        }

        public string LabelText
        {
            get => (string)GetValue(LabelTextProperty);
            set => SetValue(LabelTextProperty, value);
        }
        public static readonly DependencyProperty LabelTextProperty = DependencyProperty.Register(
            nameof(LabelText),
            typeof(string),
            typeof(FormTextBox),
            null
        );

        public string TextBoxText
        {
            get => (string)GetValue(TextBoxTextProperty);
            set => SetValue(TextBoxTextProperty, value);
        }
        public static readonly DependencyProperty TextBoxTextProperty = DependencyProperty.Register(
            nameof(TextBoxText),
            typeof(string),
            typeof(FormTextBox),
            null
        );
    }
}
