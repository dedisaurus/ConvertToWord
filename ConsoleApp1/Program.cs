using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string numInput = "";
        string result = "";


        // Ask the user to type the number.
        Console.Write("Type a number, and then press Enter: ");
        numInput = Console.ReadLine();
        var isNumeric = int.TryParse(numInput, out int n);
        if (isNumeric == true)
        {
            result = MoneyToWords(double.Parse(numInput));

        }
        else
            result = "Input is not a number.";

        Console.WriteLine(result);
    }

    public static string MoneyToWords(double value)
    {
        decimal money = Math.Round((decimal)value, 2);
        Int64 number = (Int64)money;
        int decimalValue = 0;
        string dollar = string.Empty;
        string cents = string.Empty;
        dollar = NumberToWords(number);
        if (money.ToString().Contains("."))
        {
            decimalValue = int.Parse(money.ToString().Split('.')[1]);
            cents = NumberToWords(decimalValue);
        }
        string result = !string.IsNullOrEmpty(cents) ? (decimalValue == 1 ? string.Format("{0} Dollar and {1} Cent.", dollar, cents) : string.Format("{0} Dollar and {1} Cents .", dollar, cents)) : string.Format("{0} Dollar.", dollar);
        return result;
    }

    public static string NumberToWords(long number)
    {
        if (number == 0)
            return "zero";

        if (number < 0)
            return "minus " + NumberToWords(Math.Abs(number));

        string words = "";

        if ((number / 1000000000000000000) > 0)
        {
            words += NumberToWords(number / 100000000000000000) + " Quintillion ";
            number %= 1000000000000000000;
        }

        if ((number / 100000000000000000) > 0)
        {
            words += NumberToWords(number / 10000000000000000) + " Hundred Quadrillion ";
            number %= 100000000000000000;
        }

        if ((number / 10000000000000000) > 0)
        {
            words += NumberToWords(number / 1000000000000000) + " Ten Quadrillion ";
            number %= 10000000000000000;
        }

        if ((number / 1000000000000000) > 0)
        {
            words += NumberToWords(number / 100000000000000) + " Quadrillion ";
            number %= 1000000000000000;
        }

        if ((number / 100000000000000) > 0)
        {
            words += NumberToWords(number / 10000000000000) + " Hundred Trillion ";
            number %= 100000000000000;
        }

        if ((number / 10000000000000) > 0)
        {
            words += NumberToWords(number / 1000000000000) + " Ten Trillion ";
            number %= 10000000000000;
        }

        if ((number / 1000000000000) > 0)
        {
            words += NumberToWords(number / 100000000000) + " Trillion ";
            number %= 1000000000000;
        }

        if ((number / 100000000000) > 0)
        {
            words += NumberToWords(number / 10000000000) + " Hundred Billion ";
            number %= 100000000000;
        }

        if ((number / 10000000000) > 0)
        {
            words += NumberToWords(number / 1000000000) + " Ten Billion ";
            number %= 10000000000;
        }

        if ((number / 1000000000) > 0)
        {
            words += NumberToWords(number / 1000000000) + " Billion ";
            number %= 1000000000;
        }

        if ((number / 100000000) > 0)
        {
            words += NumberToWords(number / 100000000) + " Hundred Million ";
            number %= 100000000;
        }

        if ((number / 10000000) > 0)
        {
            words += NumberToWords(number / 10000000) + " Ten Million ";
            number %= 10000000;
        }

        if ((number / 1000000) > 0)
        {
            words += NumberToWords(number / 1000000) + " Million ";
            number %= 1000000;
        }

        if ((number / 100000) > 0)
        {
            words += NumberToWords(number / 100000) + " Hundred Thousand ";
            number %= 100000;
        }

        if ((number / 10000) > 0)
        {
            words += NumberToWords(number / 10000) + " Ten Thousand ";
            number %= 10000;
        }

        if ((number / 1000) > 0)
        {
            words += NumberToWords(number / 1000) + " Thousand ";
            number %= 1000;
        }

        if ((number / 100) > 0)
        {
            words += NumberToWords(number / 100) + " Hundred ";
            number %= 100;
        }

        if (number > 0)
        {
            var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

            if (number < 20)
                words += unitsMap[number];
            else
            {
                words += tensMap[(number) / 10];
                if ((number % 10) > 0)
                    words += " " + unitsMap[(number) % 10];
            }
        }
        return words;
    }



}

