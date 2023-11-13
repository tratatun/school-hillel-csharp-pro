using System.Text;

namespace Lesson01
{
    internal class Program
    {
        /*
        1) Знайти позицію літери в алфавіті та перевести її в інший регістр
        2) Розділювач рядка. Дана строка та символ, потрібно розділити строку на кілька строк (масив строк) виходячи із заданого символу. 
            Наприклад: строка = "Лондон, Париж, Рим", а символ = ','. Результат = string[] { "Лондон", "Париж", "Рим" }.
        3) Пошук підстроки у строці.
        4) Написати програму, яка виводить число літерами. Приклад: 117 - сто сімнадцять
        5) Поміняти місцями значення двох змінних (типу int) (без використання 3й)
    Не потрібно використовувати стандартні рішення (наприклад string.Split у 2му завданні).
         */
        static void Main(string[] args)
        {

            Task1();
            Console.WriteLine();
            Task2();
            Console.WriteLine();
            Task3();
            Console.WriteLine();
            //Task4();
            Task5();

            Console.ReadKey();
        }
        private static void Task5()
        {
            Console.WriteLine("Task 5:");
            Console.WriteLine("Enter a number 1:");
            var str1 = Console.ReadLine();
            var num1 = 0;
            if (string.IsNullOrEmpty(str1) || !int.TryParse(str1, out num1))
            {
                Console.WriteLine("String should a number and not be empty!");
                return;
            }

            Console.WriteLine("Enter a number 2:");

            var str2 = Console.ReadLine();
            var num2 = 0;
            if (string.IsNullOrEmpty(str2) || !int.TryParse(str2, out num2))
            {
                Console.WriteLine("String should a number and not be empty!");
                return;
            }

            Console.WriteLine("Numbers before swap: {0} and {1}", num1, num2);
            num1 = num1 + num2;
            num2 = num1 - num2;
            num1 = num1 - num2;
            Console.WriteLine("Numbers after swap: {0} and {1}", num1, num2);

        }

        private static void Task4()
        {
            Console.WriteLine("Task 4:");
            var numbers = new string[] { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var tens = new string[] { "", "ten", "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eighty","ninety" };
            var teens = new string[] { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen","seventeen","eighteen","nineteen" };
            var ranks = new string[] { "hundred", "thousand", "million", "billion", "trillion" };

            Console.WriteLine("Enter a number:");
            var str = Console.ReadLine();
            if (string.IsNullOrEmpty(str))
            {
                Console.WriteLine("String should not be empty!");
                return;
            }
            
            var rank = 0;
            var result = new StringBuilder();
            rank = str.Length / 3;

            //for(int i = 0; i < )
        }

        private static void Task3()
        {
            Console.WriteLine("Task 3:");
            Console.WriteLine("Enter a string:");
            var str = Console.ReadLine();
            if (string.IsNullOrEmpty(str))
            {
                Console.WriteLine("String should not be empty!");
                return;
            }

            Console.WriteLine("Enter a substring:");
            var substr = Console.ReadLine();
            if (string.IsNullOrEmpty(substr))
            {
                Console.WriteLine("Substring should not be empty!");
                return;
            }

            if(substr.Length >= str.Length)
            {
                Console.WriteLine("Substring should not be longer than string!");
                return;
            }

            int iSub = 0;

            for (int i = 0; i<str.Length; i++)
            {
                if (str[i] == substr[iSub])
                {
                    if(iSub == substr.Length - 1)
                    {
                        Console.WriteLine("Substring found at position {0}", i - substr.Length + 1);
                        iSub = 0;
                    }
                    iSub++;
                }
                else
                {
                    iSub = 0;
                }
            }
            Console.WriteLine("Substring is not found!");
        }

        private static void Task2()
        {
            Console.WriteLine("Task 2:");
            Console.WriteLine("Enter a string:");
            var str = Console.ReadLine();
            if (string.IsNullOrEmpty(str))
            {
                Console.WriteLine("String should not be empty!");
                return;
            }
            Console.WriteLine("Enter a divider:");
            var div = Console.ReadLine();
            if (string.IsNullOrEmpty(div) || div.Length != 1)
            {
                Console.WriteLine("Divider should 1 character long!");
                return;
            }

            Console.WriteLine($"Result: { StringDivider(str, div[0]).Aggregate("", (acc, curr) => $"{acc}, \"{curr}\"") }");
        }

        // Оскільки у другому завданні написано що є вхідні данні (строка та символ), то я зробив окрему фіункцію з ціми вхідними даними
        private static string[] StringDivider(string input, char div)
        {
            var result = new List<string>();
            var current = new StringBuilder();

            for (int i = 0; i< input.Length;i++) {
                // як я зрозумів, у результаті не повинно бути пробілів
                if (input[i] != div)
                {
                    current.Append(input[i]);
                } 
                else
                {
                    result.Add(current.ToString());
                    current.Clear();
                }
            }

            return result.ToArray();
        }

        private static void Task1()
        {
            Console.WriteLine("Task 1:");
            Console.WriteLine("Enter a letter:");

            var str = Console.ReadLine();
            if (str == null || str.Length != 1)
            {
                Console.WriteLine("Enter only one letter");
                return;
            }
            char letter = str[0];
            if (letter >= 65 && letter <= 90)
            {
                Console.WriteLine("The letter \"{0}\" number in alphabet - {1}", letter, (letter - 'A' + 1));
                Console.WriteLine("The letter in lower register - " + (char)(letter + 32));
                return;
            }
            else if (letter >= 97 && letter <= 122)
            {
                Console.WriteLine("The letter \"{0}\" number in alphabet - {1}", letter, (letter - 'a' + 1));
                Console.WriteLine("The letter in upper register - " + (char)(letter - 32));
                return;
            }
            else 
            {
                Console.WriteLine("Input is not a letter!");
            }
        }
    }
}