using System;

class TemperatureConversion
{
    static private bool isRunning = true;

    static readonly Dictionary<(char, char), Func<double, double>> conversionMap = new(){
        { ('C', 'K'), temp => temp + 273.15 },
        { ('C', 'F'), temp => temp * 9 / 5 + 32 },
        { ('F', 'C'), temp => (temp - 32) * 5 / 9 },
        { ('F', 'K'), temp => (temp - 32) * 5 / 9 + 273.15 },
        { ('K', 'C'), temp => temp - 273.15 },
        { ('K', 'F'), temp => (temp - 273.15) * 9 / 5 + 32 }
    };
    static void Main(string[] args)
    {
        while (isRunning)
        {
            Interface();
        }
    }

    static void Interface()
    {
        Console.Clear();
        Console.WriteLine("------------------------------------------");
        Console.WriteLine("\nWelcome to the Temperature Conversion. \n");

        double temperature = GetValidInput<double>("Write your temperature (ONLY NUMBERS): ", double.TryParse);
        char initialUnit = GetValidUnit("Choose what you want to convert: (C)elsius, (F)ahrenheit, (K)elvin ");
        char targetUnit = GetValidUnit("Choose for what do you want to convert: (C)elsius, (F)ahrenheit, (K)elvin: ");

        double result = convertTemperature(temperature, initialUnit, targetUnit);

        Console.Write($"The temperature from {temperature}{initialUnit} to {targetUnit} is {result:F2}{targetUnit}");

        Console.Write("\nDo another conversion? (Y/N) ");
        isRunning = Console.ReadLine()?.Trim().ToUpper() == "Y";
    }

    static T GetValidInput<T>(string message, TryParseHandler<T> tryParse)
    {
        T result;
        bool isValid;

        do
        {
            Console.Write(message);
            string input = Console.ReadLine();
            isValid = tryParse(input, out result);
            if (!isValid)
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        } while (!isValid);
        return result;
    }

    static char GetValidUnit(string message)
    {
        char unit;

        do
        {
            Console.Write(message);
            var input = Console.ReadLine()?.Trim().ToUpper();

            if (!string.IsNullOrEmpty(input) && input.Length == 1)
            {
                unit = input[0];
                if (unit == 'C' || unit == 'F' || unit == 'K') return unit;
            }

            Console.WriteLine("Invalid input. Please enter C, F, or K.");
        } while (true);
    }


    static double convertTemperature(double temp, char fromUnit, char toUnit)
    {
        if (fromUnit == toUnit)
            return temp;

        if (conversionMap.TryGetValue((fromUnit, toUnit), out var conversion))
            return conversion(temp);

        throw new InvalidOperationException("Unsupported conversion.");
    }

    delegate bool TryParseHandler<T>(string input, out T result);
}