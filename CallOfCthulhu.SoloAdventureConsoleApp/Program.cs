using System;
using CallOfCthulhu.SoloAdventures.Interfaces;
using CallOfCthulhu.SoloAdventures.Adventures;
using CallOfCthulhu.SoloAdventures;

namespace CallOfCthulhu.SoloAdventureConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var adventureRunner = new AdventureRunner(new InputGetter(), new OutputDisplayer());
            adventureRunner.RunAdventure(new AloneAgainstTheFlames());
        }
    }

    class InputGetter : IGetStringInput
    {
        public string GetInput()
        {
            return Console.ReadLine();
        }
    }

    class OutputDisplayer : IDisplayStringOutput
    {
        public void DisplayOutput(string output)
        {
            Console.WriteLine(output);
        }
    }
}
