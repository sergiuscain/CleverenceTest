using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverenceTest
{
    public class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Введите команду:\n1 - Сжатие текста\n2 - Декомпрессия текста\n3 - Привод лог файлов к единому формату.\nexit - выход.");
                string cmd = Console.ReadLine();
                if (cmd == "1")
                {
                    Console.WriteLine("Введите строку для сжатия!");
                    string line = Console.ReadLine();
                    var compressionResult = Task1.Compression(line);
                    Console.WriteLine(compressionResult);
                    Console.WriteLine("Нажмите любую клавишу для возврата в меню");
                    Console.ReadKey();
                    Console.Clear();
                }
                if (cmd == "2")
                {
                    Console.WriteLine("Введите строку для декомпрессии!");
                    string line = Console.ReadLine();
                    var deCompressionResult = Task1.DeCompression(line);
                    Console.WriteLine(deCompressionResult);
                    Console.WriteLine("Нажмите любую клавишу для возврата в меню");
                    Console.ReadKey();
                    Console.Clear();
                }
                if (cmd == "exit")
                {
                    break;
                }
            }
        }
    }
}
