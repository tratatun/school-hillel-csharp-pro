using System;
using System.Net;
using System.Reflection;
using System.Text;

namespace Lesson02
{
    internal class Program
    {
        /*
        1) Реверс строки/масиву. Без додаткового масиву. Складність О(n).
        2) Фільтрування неприпустимих слів у строці. Має бути саме слова, а не частини слів.
        3) Генератор випадкових символів. На вхід кількість символів, на виході рядок з випадковими символами.
        4) "Дірка" (пропущене число) у масиві. Масив довжини N у випадковому порядку заповнений цілими числами з діапазону від 0 до N. 
            Кожне число зустрічається в масиві не більше одного разу. Знайти відсутнє число (дірку). 
            Є дуже простий та оригінальний спосіб вирішення. Складність алгоритму O(N). 
            Використання додаткової пам'яті, пропорційної довжині масиву не допускається.
        5) Найпростіше стиснення ланцюжка ДНК. Ланцюг ДНК у вигляді строки на вхід (кожен нуклеотид представлений символом "A", "C", "G", "T"). 
            Два методи, один для компресії, інший для декомпресії.
        6) Симетричне шифрування. Є строка на вхід, який має бути зашифрований. Ключ можна задати в коді або згенерувати та зберегти. 
            Два методи, шифрування та дешифрування.
        */

        static void Main(string[] args)
        {
            //Task1();
            //Task2();
            Task3();
            //Task4();
            //Task5();
            //Task6();
        }

        public static string Encrypt(string str)
        {
            var key = "123Asd";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                sb.Append((char)(str[i] ^ key[i % key.Length]));
            }
            return sb.ToString();
        }

        public static string Decrypt(string str, string key)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                sb.Append((char)(str[i] ^ key[i % key.Length]));
            }
            return sb.ToString();
        }

        public static void Task6()
        {
            Console.WriteLine("Begin Task 6");
            Console.WriteLine("Enter string");
            string str = Console.ReadLine();

            if (str == null)
            {
                Console.WriteLine("String is null");
                return;
            }

            Console.WriteLine("Enter key");
            string key = Console.ReadLine();

            if (key == null)
            {
                Console.WriteLine("Key is null");
                return;
            }

            string encrypted = Encrypt(str);
            string decrypted = Decrypt(encrypted, key);

            Console.WriteLine("Encrypted:");
            Console.WriteLine(encrypted);

            Console.WriteLine("Decrypted:");
            Console.WriteLine(decrypted);
        }

        public static byte[] Compress(string str)
        {
            int byteLength = str.Length / 4, byteNumber = 2;
            if (str.Length % 4 != 0)
            {
                byteLength++;
            }

            // резервуємо 2 біта для збереження довжини оригінального рядка
            byteLength += 2;
            byte[] bytes = new byte[byteLength];

            // записуємо довжину оригінального рядка
            bytes[0] = (byte)(str.Length >> 8);
            bytes[1] = (byte)(str.Length & 255);
            int i = 0;
            while (i < str.Length)
            {
                int j = 0;
                while (j < 4 && i < str.Length)
                {
                    switch (str[i])
                    {
                        case 'A':
                            bytes[byteNumber] |= 0b00;
                            break;
                        case 'C':
                            bytes[byteNumber] |= 0b01;
                            break;
                        case 'G':
                            bytes[byteNumber] |= 0b10;
                            break;
                        case 'T':
                            bytes[byteNumber] |= 0b11;
                            break;
                    }
                    // останній байт не повинен зсуватися
                    bytes[byteNumber] <<= j == 3 ? 0 : 2;
                    j++;
                    i++;
                }
                byteNumber++;
            }
            return bytes;
        }

        public static string Decompress(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();
            // читаємо довжину оригінального рядка
            int length = (bytes[0] << 8) + bytes[1];
            for (int i = 2; i < bytes.Length; i++)
            {
                for (int j = 0; j < 4 && length > 0; j++)
                {
                    switch (bytes[i] >> 6)
                    {
                        case 0b00:
                            sb.Append('A');
                            break;
                        case 0b01:
                            sb.Append('C');
                            break;
                        case 0b10:
                            sb.Append('G');
                            break;
                        case 0b11:
                            sb.Append('T');
                            break;
                    }
                    bytes[i] <<= 2;
                    length--;
                }
            }
            return sb.ToString();
        }

        public static void Task5()
        {
            Console.WriteLine("Begin Task 5");
            Console.WriteLine("Enter string");
            string str = Console.ReadLine();
            if (str == null)
            {
                Console.WriteLine("String is null");
                return;
            }

            byte[] bytes = Compress(str);
            string str2 = Decompress(bytes);


            Console.WriteLine(str2.ToString());
        }   

        public static void Task4()
        {
            Console.WriteLine("Begin Task 4");
            Console.WriteLine("Enter numbers");
            string str = Console.ReadLine();
            
            //example: "3 5 4 7 1  0 6" so need to find "2"
            
            if (str == null)
            {
                Console.WriteLine("String is null");
                return;
            }
            int num;
            string[] strNumbers = str.Split(' ');
           
            int sum = 0, sumCorrect = 0;
            for (int i = 0; i < strNumbers.Length; i++)
            {
                sumCorrect += i;
                if (int.TryParse(strNumbers[i], out num))
                {
                    sum += num;
                }
            }

            Console.WriteLine(sumCorrect-sum);
        }

        public static void Task3()
        {
            Console.WriteLine("Begin Task 3");
            Console.WriteLine("Enter number");
            string str = Console.ReadLine();

            if (str == null)
            {
                Console.WriteLine("String is null");
                return;
            }
            int number = int.Parse(str);

            var sb = new StringBuilder();

            for (int i = 0; i < number; i++)
            {
                // Печатні символи від 32 до 126
                var seed = Math.Abs(Environment.TickCount << i);
                var letterNumber = (32 + (seed) % (126 - 32));
                sb.Append((char)letterNumber);
            }

            // sorting string
            char[] arr = sb.ToString().ToCharArray();
            Array.Sort(arr);
            sb.Clear();
            sb.Append(arr);

            Console.WriteLine(sb.ToString());
        }

        public static void Task2()
        {
            Console.WriteLine("Begin Task 2");
            Console.WriteLine("Enter string");
            string str = Console.ReadLine();

            if (str == null)
            {
                Console.WriteLine("String is null");
                return;
            }
            Console.WriteLine("Enter exceptions devided by SPACE");

            string exceptionsStr = Console.ReadLine();

            if (exceptionsStr == null)
            {
                Console.WriteLine("Exceptions is null");
                return;
            }
            string[] exceptions = exceptionsStr.Split(' ');
            
            Array.Sort(exceptions);

            StringBuilder sb = new StringBuilder();
            bool isFirstLetter = char.IsLetter(str[0]);
            int wordLength = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsLetter(str[i]) && isFirstLetter)
                {
                    isFirstLetter = false;
                    wordLength = 1;
                }
                else if (char.IsLetter(str[i]) && !isFirstLetter)
                {
                    wordLength++;
                }
                if (!char.IsLetter(str[i]) && !isFirstLetter)
                {
                    isFirstLetter = true;
                    string word = str.Substring(i - wordLength, wordLength);
                    if (Array.BinarySearch(exceptions, word) < 0)
                    {
                        sb.Append(word);
                        sb.Append(' ');
                    }
                    else
                    {
                        sb.Append("***");
                        sb.Append(' ');
                    }
                }

                if (i == str.Length - 1)
                {
                    isFirstLetter = true;
                    string word = str.Substring(str.Length - wordLength, wordLength);
                    if (Array.BinarySearch(exceptions, word) < 0)
                    {
                        sb.Append(word);
                        sb.Append(' ');
                    }
                    else
                    {
                        sb.Append("***");
                        sb.Append(' ');
                    }
                }
            }

            Console.WriteLine(sb);

        }

        public static void Task1()
        {
            Console.WriteLine("Begin Task 1");
            string str = Console.ReadLine();

            if (str == null)
            {
                Console.WriteLine("String is null");
                return;
            }

            char[] arr = new char[str.Length];
            for (int i = 0; i < arr.Length/2; i++)
            {
                char temp = arr[i];
                arr[i] = arr[arr.Length - 1 - i];
                arr[arr.Length -1 - i] = temp;
            }

            Console.WriteLine(arr);
            Console.WriteLine("End Task 1");
        }
    }
}