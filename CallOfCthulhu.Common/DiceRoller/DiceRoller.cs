using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallOfCthulhu.Common.DiceRoller
{
    public class DiceRoller
    {
        public static int RollDice(IEnumerable<Die> dice, int modifier = 0)
        {
            var output = 0;
            foreach (var die in dice)
                output += die.Roll();
            output += modifier;
            return output;
        }

        public static int RollDice(string input)
        {
            var splitInput = input.Split(new[] { '+', '-' });
            if (splitInput.Length > 2)
                throw new ArgumentException($"Invalid input in DiceRoller.RollDice({input}).");

            try
            {
                var output = splitInput.Length == 2 ? int.Parse(splitInput[1]) : 0;

                var splitDiceString = splitInput[0].ToLower().Split(new[] { 'd' });
                if (splitDiceString.Length != 2)
                    throw new ArgumentException();

                var die = new Die(int.Parse(splitDiceString[1]));
                var numberOfDice = int.Parse(splitDiceString[0]);
                for (var i = 0; i < numberOfDice; i++)
                    output += die.Roll();

                return output;
            }
            catch(Exception)
            {
                throw new ArgumentException($"Invalid input in DiceRoller.RollDice({input}).");
            }
        }
    }
}
