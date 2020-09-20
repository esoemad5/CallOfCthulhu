using System.Collections.Generic;

namespace CallOfCthulhu.CharacterManager.Framework.Navigation
{
    public interface INavigationService
    {
        void PushPage(string target, IDictionary<string, object> parameters = null);

        void PopPage(string target = null);

        void Swap(string target, IDictionary<string, object> parameters = null);
    }
}
