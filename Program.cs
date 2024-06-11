using System;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Program
{
    private static void Main(string[] args)
    {
        string str_special_characters = "!#$%&()*+./:;=>?@[]^`{|}~'";
        string str_big_english = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string str_small_english = str_big_english.ToLower();
        string str_big_russian = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        string str_small_russian = str_big_russian.ToLower();
        string str_numbers = "1234567890";

        Console.WriteLine("Привет, укажи необходимые параметры для своего пароля:");
        Console.Write("Количество паролей: ");
        int n_password = Convert.ToInt32(Console.ReadLine());
        Console.Write("Специальные символы (да/нет): ");
        string special_characters = Console.ReadLine();
        if (special_characters != "да" && special_characters != "нет")
        {
            while (special_characters != "да" && special_characters != "нет")
            {
                Console.WriteLine("Нужен ответ да или нет");
                Console.Write("Специальные символы (да/нет): ");
                special_characters = Console.ReadLine();
            }
        }
        Console.Write("Использование чисел (да/нет): ");
        string use_numbers = Console.ReadLine();
        if (use_numbers != "да" && use_numbers != "нет")
        {
            while (use_numbers != "да" && use_numbers != "нет")
            {
                Console.WriteLine("Нужен ответ да или нет");
                Console.Write("Использование чисел (да/нет): ");
                use_numbers = Console.ReadLine();
            }
        }
        Console.Write("Укажите язык (русский/английский): ");
        string language = Console.ReadLine();
        if (language != "русский" && language != "английский")
        {
            while (language != "русский" && language != "английский")
            {
                Console.WriteLine("Ответ не засчитан");
                Console.Write("Укажите язык (русский/английский): ");
                language = Console.ReadLine();
            }
        }
        
        Console.WriteLine("Вот пароли:");
        for (int i = 0; i < n_password; i++)
        {
            string password = "";
            for (int j = 0; j < 12; j++)
            {
                Random random = new Random();
                int random_number = random.Next(0, 3);
                switch (random_number)
                {
                    case 0:
                        if (special_characters == "да")
                        {
                            int random_number0 = random.Next(0, str_special_characters.Length);
                            password = password + str_special_characters[random_number0];
                        }
                        else
                        {
                            j--;
                        }
                    break;

                    case 1:
                        if (language == "русский")
                        {
                            int random_number_big_or_small_letters = random.Next(0, 2);
                            int random_number1 = random.Next(0, str_small_russian.Length);

                            if (random_number_big_or_small_letters == 0)
                            {
                                password = password + str_small_russian[random_number1];
                            }
                            if (random_number_big_or_small_letters == 1)
                            {
                                password = password + str_big_russian[random_number1];
                            }
                        }
                        if (language == "английский")
                        {
                            int random_number_big_or_small_letters = random.Next(0, 2);
                            int random_number1 = random.Next(0, str_small_english.Length);

                            if (random_number_big_or_small_letters == 0)
                            {
                                password = password + str_small_english[random_number1];
                            }
                            if (random_number_big_or_small_letters == 1)
                            {
                                password = password + str_big_english[random_number1];
                            }
                        }
                    break;
                    case 2:
                        if (use_numbers == "да") 
                        {
                            int random_number2 = random.Next(0, str_numbers.Length);
                            password = password + str_numbers[random_number2];
                        }
                        else
                        {
                            j--;
                        }
                    break;
            }
        }
        Console.WriteLine(password);
        }
    }
}