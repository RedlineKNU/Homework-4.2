using System;

public class Converter
{
    // Параметри для курсу долара та євро відносно гривні
    public decimal DollarRate { get; }
    public decimal EuroRate { get; }

    // Конструктор класу, який ініціалізує курси
    public Converter(decimal dollarRate, decimal euroRate)
    {
        if (dollarRate <= 0)
        {
            throw new ArgumentException("Курс долара не може бути 0 або менше.");
        }
        if (euroRate <= 0)
        {
            throw new ArgumentException("Курс євро не може бути 0 або менше.");
        }

        // Ініціалізація параметрів
        DollarRate = dollarRate;
        EuroRate = euroRate;
    }

    public decimal ConvertToDollar(decimal amountInUah)
    {
        return amountInUah / DollarRate;
    }

    public decimal ConvertToEuro(decimal amountInUah)
    {
        return amountInUah / EuroRate;
    }

    public decimal ConvertFromDollar(decimal amountInDollar)
    {
        return amountInDollar * DollarRate;
    }

    public decimal ConvertFromEuro(decimal amountInEuro)
    {
        return amountInEuro * EuroRate;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        decimal dollarRate;
        decimal euroRate;

        // Цикл для введення курсу долара
        while (true)
        {
            Console.Write("Введіть курс долара: ");
            // Спроба конвертувати введене значення в decimal
            if (decimal.TryParse(Console.ReadLine(), out dollarRate) && dollarRate > 0)
            {
                break; 
            }
            Console.WriteLine("Курс долара має бути більше 0.");
        }

        // Цикл для введення курсу євро
        while (true)
        {
            Console.Write("Введіть курс євро: ");
            // Спроба конвертувати введене значення в decimal
            if (decimal.TryParse(Console.ReadLine(), out euroRate) && euroRate > 0)
            {
                break; 
            }
            Console.WriteLine("Курс євро має бути більше 0.");
        }

        Converter converter = new Converter(dollarRate, euroRate);

        Console.WriteLine("Виберіть дію:");
        Console.WriteLine("1. Конвертувати гривні в долари");
        Console.WriteLine("2. Конвертувати гривні в євро");
        Console.WriteLine("3. Конвертувати долари в гривні");
        Console.WriteLine("4. Конвертувати євро в гривні");

        int choice = int.Parse(Console.ReadLine());
        decimal amount;

        switch (choice)
        {
            case 1:
                Console.Write("Введіть суму в гривнях: ");
                amount = decimal.Parse(Console.ReadLine());
                Console.WriteLine($"Сума в доларах: {converter.ConvertToDollar(amount):F2}"); 
                break;

            case 2:
                Console.Write("Введіть суму в гривнях: ");
                amount = decimal.Parse(Console.ReadLine());
                Console.WriteLine($"Сума в євро: {converter.ConvertToEuro(amount):F2}"); 
                break;

            case 3:
                Console.Write("Введіть суму в доларах: ");
                amount = decimal.Parse(Console.ReadLine());
                Console.WriteLine($"Сума в гривнях: {converter.ConvertFromDollar(amount):F2}"); 
                break;

            case 4:
                Console.Write("Введіть суму в євро: ");
                amount = decimal.Parse(Console.ReadLine());
                Console.WriteLine($"Сума в гривнях: {converter.ConvertFromEuro(amount):F2}"); 
                break;

            default:
                Console.WriteLine("Невірний вибір."); 
                break;
        }
    }
}
