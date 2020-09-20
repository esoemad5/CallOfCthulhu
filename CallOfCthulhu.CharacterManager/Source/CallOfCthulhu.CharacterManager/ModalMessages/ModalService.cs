using System;
using System.Threading.Tasks;
using Prism.Ioc;
using Prism.Regions;

namespace CallOfCthulhu.CharacterManager.ModalMessages
{
    public delegate void ModalClosedEventHandler(bool? result);

    public interface IModalService
    {
        Task<bool?> ShowOverlayAsync(IModalContent content);
    }

    public class ModalService : IModalService
    {
        private readonly Lazy<ModalOverlayView> _lazyView;

        private IRegionManager RegionManager { get; }

        private IRegion Region => RegionManager.Regions[Regions.OverlayDialog];

        private ModalOverlayView View => _lazyView.Value;

        public ModalService(IContainerExtension container, IRegionManager regionManager)
        {
            RegionManager = regionManager;

            _lazyView = new Lazy<ModalOverlayView>(
                container.Resolve<ModalOverlayView>
            );
        }

        public async Task<bool?> ShowOverlayAsync(IModalContent content)
        {
            var vm = new ModalDialogViewModel(content);

            View.DataContext = vm;

            Region.Add(View);

            var result = await vm.GetResultAsync();

            Region.Remove(View);

            return result;
        }
    }
}
