using System;
using System.Collections.Generic;
using System.Windows;
using Prism.Commands;
using Prism.Mvvm;

namespace CallOfCthulhu.CharacterManager.ModalMessages
{
    public class ConfirmationDialogViewModel : BindableBase, IModalContent
    {
        private MessageBoxButton _buttons;
        private readonly Lazy<CommandWrapper> _cancelCommandWrapper;
        private string _message;
        private readonly Lazy<CommandWrapper> _noCommandWrapper;
        private readonly Lazy<CommandWrapper> _okCommandWrapper;
        private string _title;
        private readonly Lazy<CommandWrapper> _yesCommandWrapper;
        private MessageBoxImage _icon;
        private HorizontalAlignment _dialogHorizontalAlignment;
        private VerticalAlignment _dialogVerticalAlignment;

        public ConfirmationDialogViewModel()
        {
            _icon = MessageBoxImage.Information;

            ConfirmCommand = new DelegateCommand(
                () => Closed?.Invoke(true)
            );
            DeclineCommand = new DelegateCommand(
                () => Closed?.Invoke(false)
            );
            CancelCommand = new DelegateCommand(
                () => Closed?.Invoke(null)
            );

            _yesCommandWrapper = new Lazy<CommandWrapper>(() => new CommandWrapper
            {
                DisplayName = "Yes",
                Command = ConfirmCommand,
                IsDefault = true
            });

            _noCommandWrapper = new Lazy<CommandWrapper>(() => new CommandWrapper
            {
                DisplayName = "No",
                Command = DeclineCommand
            });

            _okCommandWrapper = new Lazy<CommandWrapper>(() => new CommandWrapper
            {
                DisplayName = "OK",
                Command = ConfirmCommand,
                IsDefault = true
            });

            _cancelCommandWrapper = new Lazy<CommandWrapper>(() => new CommandWrapper
            {
                DisplayName = "Cancel",
                Command = ConfirmCommand,
                IsCancel = true
            });
        }

        public DelegateCommand ConfirmCommand { get; }

        public DelegateCommand DeclineCommand { get; }

        public DelegateCommand CancelCommand { get; }

        public IEnumerable<CommandWrapper> Commands
        {
            get
            {
                switch (Buttons)
                {
                    case MessageBoxButton.OK:
                        yield return _okCommandWrapper.Value;
                        break;
                    case MessageBoxButton.OKCancel:
                        yield return _okCommandWrapper.Value;
                        yield return _cancelCommandWrapper.Value;
                        break;
                    case MessageBoxButton.YesNoCancel:
                        yield return _yesCommandWrapper.Value;
                        _noCommandWrapper.Value.IsCancel = false;
                        yield return _noCommandWrapper.Value;
                        yield return _cancelCommandWrapper.Value;
                        break;
                    case MessageBoxButton.YesNo:
                        yield return _yesCommandWrapper.Value;
                        _noCommandWrapper.Value.IsCancel = true;
                        yield return _noCommandWrapper.Value;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public MessageBoxImage Icon
        {
            get => _icon;
            set => SetProperty(ref _icon, value);
        }

        public MessageBoxButton Buttons
        {
            get => _buttons;
            set
            {
                if (!SetProperty(ref _buttons, value))
                    return;
                OnPropertyChanged(nameof(Commands));
            }
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public event ModalClosedEventHandler Closed;

        public HorizontalAlignment DialogHorizontalAlignment =>
            HorizontalAlignment.Center;

        public VerticalAlignment DialogVerticalAlignment =>
            VerticalAlignment.Center;

        public class CommandWrapper
        {
            public string DisplayName { get; set; }

            public DelegateCommand Command { get; set; }

            public bool IsDefault { get; set; }

            public bool IsCancel { get; set; }
        }
    }
}
