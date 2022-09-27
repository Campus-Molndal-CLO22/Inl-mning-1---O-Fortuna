
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ohfortuna
{
    //Hjälp klass för att kolla om man har matat in giltligt värde
    static class InputUtils
    {
        public static int SafeReadInt(string message, int minValue, int maxValue)
        {
            int inputValue = 0;
            bool validSelectionMade = false;
            while (!validSelectionMade)
            {
                Console.WriteLine(message + ", between " + minValue + " and " + maxValue + ".");
                Console.Write("\r\nEnter a value: ");
                string rawInputValue = Console.ReadLine();
                if (int.TryParse(rawInputValue, out _))
                {
                    inputValue = Convert.ToInt32(rawInputValue);
                    validSelectionMade = inputValue <= maxValue && inputValue >= minValue;
                }
            }
            return inputValue;
        }
    }
}