using System;

class TemperatureConversion
{
    static private bool isRunning = true;
    static void Main(string[] args)
    {
        while (isRunning)
        {
            Interface();
        }
    }

    static void Interface()
    {
        Console.WriteLine("------------------------------------------");
        Console.WriteLine();
        Console.WriteLine("Welcome to the Temperature Conversion.");
        Console.WriteLine();
        var num = validNumber("Write your temperature (ONLY NUMBERS): ");
        Console.WriteLine();
        char initialTemp = validTemperature("Choose what you want to convert: (C)elsius, (F)ahrenheit, (K)elvin ");
        Console.WriteLine();
        char finalTemp = validTemperature("Choose for what do you want to convert: (C)elsius, (F)ahrenheit, (K)elvin: ");
        Console.WriteLine();
        var result = conversorVerifier(num, initialTemp, finalTemp);
        Console.Write($"The temperature from {num}{char.ToUpper(initialTemp)} to {finalTemp} is {result}{char.ToUpper(finalTemp)}");
        Console.WriteLine();
        Console.Write("Do another conversion? (Y/N) ");
        string answer = Console.ReadLine();
        answer = answer.ToUpper();
        Console.WriteLine();
        Console.WriteLine("----------------------------------");
        switch (answer)
        {
            case "Y":
                Console.Clear();
                return;
            case "N":
                isRunning = false;
                return;
        }
    }

    static int validNumber(string message)
    {
        int number;
        bool isValid;

        do
        {
            Console.Write(message);
            var input = Console.ReadLine();
            isValid = int.TryParse(input, out number);
            if (!isValid)
            {
                Console.WriteLine("Invalid input, please enter a valid number.");
            }
        } while (!isValid);
        return number;
    }

    static char validTemperature(string message)
    {
        char temp = ' ';
        bool isValid;

        do
        {
            Console.Write(message);
            var input = Console.ReadLine();


            isValid = !string.IsNullOrEmpty(input) && input.Length == 1 && char.TryParse(input.ToUpper(), out temp);

            if (isValid && (temp == 'C' || temp == 'F' || temp == 'K'))
            {
                return temp;
            }

            Console.WriteLine("Invalid input. Please enter C, F, or K.");
        } while (true);
    }


    static double conversorVerifier(int num, char initialTemp, char finalTemp)
    {
        initialTemp = char.ToUpper(initialTemp);
        finalTemp = char.ToUpper(finalTemp);

        if (initialTemp == 'C' && finalTemp == 'K')
        {
            return num + 273.15;
        }
        else if (initialTemp == 'C' && finalTemp == 'F')
        {
            return num * (9 / 5) + 32;
        }
        else if (initialTemp == 'F' && finalTemp == 'C')
        {
            return (num - 32) * (5 / 9);
        }
        else if (initialTemp == 'F' && finalTemp == 'K')
        {
            return (num - 32) * (5 / 9) + 273.15;
        }
        else if (initialTemp == 'K' && finalTemp == 'C')
        {
            return num - 273.15;
        }
        else if (initialTemp == 'K' && finalTemp == 'F')
        {
            return (num - 273.15) * (9 / 5) + 32;
        }
        return num;
    }
}