using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverenceTest
{
    public static class Task1
    {
        /// <summary>
        /// Метод сжимает текст в формат, в котором каждый повторяющийся подряд символ преобразуется в строку с обозначением количества повторяющихся символов
        /// aaabbccc => "a3b2c3"
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Compression(string input)
        {
            /* Добавил пробел в конце строки, что бы учитывать и последний символ
            (в цыкле мы доходим до предпоследнего и проверяем равняется ли он следующему за ним зимволу) */
            input += " ";
            string output = string.Empty;
            int count = 1;
            // Проходим по всей строке кроме последнего символа, что бы не выйти за массив при проверке
            for (int i = 0; i < input.Length - 1; i++)
            {
                // Если следующий символ равняется текущему, прибавляем счётчик
                if (input[i] == input[i+1])
                    count++;
                // Иначе делаем проверку:
                else
                {
                    // Если символ был одиночным, просто добавляем его в выходной строке
                    if (count < 2)
                        output += input[i];
                    // Иначе добавляем сам символ и переменную count, которая считает количество повторений символа
                    //Затем сбрасываем переменную count до единицы т.к. изначально количество любого символа равняется одному!
                    else
                    {
                        output += input[i];
                        output += count;
                        count = 1;
                    }
                }
            }

            return output;
        }
        /// <summary>
        /// Преобразует формат a3b2c3 в формат aaabbccc (после каждого символа цифра, которая обозначает, сколько раз повторяется этот символ)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string DeCompression(string input)
        {
            string output = string.Empty;
            int i = 0;

            while (i < input.Length)
            {
                char currentChar = input[i];
                // Добавляем текущий символ в выходную строку
                output += currentChar; 
                i++;

                // Проверяем, есть ли за символом число
                if (i < input.Length && char.IsDigit(input[i]))
                {
                    // Считываем все цифры, которые идут после символа
                    string countStr = string.Empty;
                    while (i < input.Length && char.IsDigit(input[i]))
                    {
                        countStr += input[i];
                        i++;
                    }

                    // Преобразуем строку числа в целое значение
                    int count = int.Parse(countStr);
                    // Добавляем дополнительные повторения символа
                    output += new string(currentChar, count - 1); 
                }
            }

            return output;
        }
    }
}
