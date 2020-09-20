using System.Windows;

namespace CallOfCthulhu.CharacterManager.ModalMessages
{
    public interface IModalContent
    {
        string Title { get; }

        event ModalClosedEventHandler Closed;

        HorizontalAlignment DialogHorizontalAlignment { get; }

        VerticalAlignment DialogVerticalAlignment { get; }
    }
}
