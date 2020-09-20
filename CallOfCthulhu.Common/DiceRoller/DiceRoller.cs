using System;
using System.Collections.Generic;

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

        /// <summary>
        /// Input must be in form of [number of dice to roll]d[number of sides] + [bonus/penalty] or simply an int.
        /// Valid inputs: 3d6 + 2, d20 - 6, 2d10, 5, -2
        /// </summary>
        public static int RollDice(string input)
        {
            var splitInput = input.Split(new[] { '+', '-' });
            if (splitInput.Length > 2)
                throw new ArgumentException($"Invalid input in DiceRoller.RollDice({input}).");

            if (int.TryParse(input, out var parsedInput))
                return parsedInput;

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
