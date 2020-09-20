using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallOfCthulhu.Common.DiceRoller
{
    public class Die
    {
        public readonly int NumberOfSides;

        private readonly Random _random;

        public Die(int numberOfSides)
        {
            NumberOfSides = numberOfSides;
            _random = new Random();
        }

        public int Roll()
        {
            return _random.Next(1, NumberOfSides + 1);
        }
    }
}
