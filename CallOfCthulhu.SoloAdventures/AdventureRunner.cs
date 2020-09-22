using CallOfCthulhu.SoloAdventures.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CallOfCthulhu.SoloAdventures
{
    public class AdventureRunner
    {
        private readonly IGetStringInput _inputGetter;
        private readonly IDisplayStringOutput _outputDisplayer;

        public AdventureRunner(IGetStringInput inputGetter, IDisplayStringOutput outputDisplayer)
        {
            _inputGetter = inputGetter;
            _outputDisplayer = outputDisplayer;
        }

        public void RunAdventure(ISoloAdventure soloAdventure)
        {
            _outputDisplayer.DisplayOutput(soloAdventure.Scenes.First());

            while (true)
            {
                int parsedInput;
                var input = _inputGetter.GetInput();

                while (!int.TryParse(input, out parsedInput))
                    _outputDisplayer.DisplayOutput("Invalid input. Must be an integer.");

                _outputDisplayer.DisplayOutput(soloAdventure.Scenes[parsedInput]);
            }
        }
    }
}
