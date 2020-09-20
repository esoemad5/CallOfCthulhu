using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism;
using Prism.Commands;

namespace CallOfCthulhu.CharacterManager.ModalMessages
{
    public class ModalDialogViewModel : IActiveAware
    {
        private readonly TaskCompletionSource<bool?> _resultSource;
        private bool _isActive;

        public ModalDialogViewModel(IModalContent content)
        {
            Content = content ?? throw new ArgumentNullException(nameof(content));
            Content.Closed += OnContentClosed;

            _resultSource = new TaskCompletionSource<bool?>();
            CloseCommand = new DelegateCommand(OnCloseExecuted);
        }

        private void OnContentClosed(bool? result)
        {
            _resultSource.SetResult(result);
            Content.Closed -= OnContentClosed;
        }

        public ICommand CloseCommand { get; }

        public IModalContent Content { get; }

        private void OnCloseExecuted()
        {
            _resultSource.SetResult(null);
        }

        public Task<bool?> GetResultAsync()
        {
            return _resultSource.Task;
        }

        public bool IsActive
        {
            get => _isActive;
            set
            {
                if (_isActive == value) return;

                _isActive = value;
                IsActiveChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler IsActiveChanged;
    }
}
