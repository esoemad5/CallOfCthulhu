using System;
using System.Collections.Generic;
using System.Text;

namespace CallOfCthulhu.SoloAdventures
{
    public interface ISoloAdventure
    {
        List<string> Scenes { get; }
    }
}
