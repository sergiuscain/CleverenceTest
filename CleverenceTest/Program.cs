using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Text.RegularExpressions;

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
                if (cmd == "3")
                {
                    ProcessLogFiles();
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

        static void ProcessLogFiles()
        {
            string inputFilePath = "input.log"; // Путь к входному файлу
            string outputFilePath = "output.log"; // Путь к выходному файлу
            string problemFilePath = "problems.txt"; // Путь к файлу с проблемами

            using (StreamReader reader = new StreamReader(inputFilePath))
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            using (StreamWriter problemWriter = new StreamWriter(problemFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    try
                    {
                        var standardizedLog = ProcessLogLine(line);
                        if (standardizedLog != null)
                        {
                            writer.WriteLine(standardizedLog);
                        }
                        else
                        {
                            problemWriter.WriteLine(line); // Записываем невалидную запись
                        }
                    }
                    catch (Exception)
                    {
                        problemWriter.WriteLine(line); // Записываем невалидную запись
                    }
                }
            }

            Console.WriteLine("Обработка лог-файлов завершена.");
        }

        static string ProcessLogLine(string logLine)
        {
            var format1Regex = new Regex(@"^(\d{2}\.\d{2}\.\d{4}) (\d{2}:\d{2}:\d{2}\.\d{3}) (INFORMATION|WARNING|ERROR|DEBUG) (.+)$");
            var format2Regex = new Regex(@"^(\d{4}-\d{2}-\d{2}) (\d{2}:\d{2}:\d{2}\.\d{4})\| (INFO|WARN|ERROR|DEBUG)\|(\d+)\|(.+)\| (.+)$");

            if (format1Regex.IsMatch(logLine))
            {
                var match = format1Regex.Match(logLine);
                string date = match.Groups[1].Value;
                string time = match.Groups[2].Value;
                string level = "INFO"; // преобразуем уровень
                string message = match.Groups[4].Value;
                string method = "DEFAULT"; // по умолчанию

                return $"{ConvertDateFormat(date)}\n{time}\n{level}\n{method}\n{message}";
            }
            else if (format2Regex.IsMatch(logLine))
            {
                var match = format2Regex.Match(logLine);
                string date = match.Groups[1].Value;
                string time = match.Groups[2].Value;
                string level = match.Groups[3].Value;
                string method = match.Groups[5].Value;
                string message = match.Groups[6].Value;

                return $"{ConvertDateFormat(date)}\n{time}\n{level}\n{method}\n{message}";
            }

            return null; // Если невалидная запись
        }

        static string ConvertDateFormat(string date)
        {
            var parts = date.Split('.');
            return $"{parts[0]}-{parts[1]}-{parts[2]}";
        }
    }
}

