using System;
using System.Collections.Generic;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            //Вводим строку данных
            Console.WriteLine("Введите строку данных");
            string stringData = Console.ReadLine();

            //Получаем значение булевой переменной. true - корректная строка, false - строка некорректна. 
            bool chekData = Chek(stringData);

            //выводим результаты проверки на экран
            if (chekData) Console.WriteLine("Скобки введены корректно");
            else Console.WriteLine("Скобки введены некорректно");
            Console.ReadLine();

        }

        //Создаем метод перебора символов строки. Возвращает 1 если скобки расставлены верно, возвращает 0 если присутствуют ошибки
        static bool Chek(string stringData)
        {
            //Создаем словарь с необходимыми парными скобками
            Dictionary<char, char> brackets = new Dictionary<char, char>()
            {
                { '[',']' },
                { '(',')' },
                { '{','}' },
            };

            //Алгоритм перебора символов строки. 
            Stack<char> stackCharOfStringData = new Stack<char>();

            foreach (char c in stringData)
            {
                if (c == '[' || c == '{' || c == '(')
                    stackCharOfStringData.Push(brackets[c]);
                if (c == ']' || c == '}' || c == ')')
                {
                    if (stackCharOfStringData.Count == 0 || stackCharOfStringData.Pop() != c)
                        return false;
                }
            }
            //Получиение итоговых значений.
            if (stackCharOfStringData.Count == 0)
                return true;
            else return false;
        }
    }
}
