using System;
using System.IO;
using DirMimeTypeParser.HTMLGenerator;
using DirMimeTypeParser.DirectoryDataParser;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using DirMimeTypeParser.HTMLGenerator.RazorPagesCompiler.model;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Diagnostics;

namespace DirMimeTypeParser
{
    internal class Program
    {
        static async Task<List<string>> Start(string directoryPath,string reportPath)
        {
            List<string> logs = new List<string>();//Все сообщения ошибок возникших в ходе анализа директории

            try
            {
                ColoredOutput.WriteLine($"Анализируемная директория:{directoryPath}", ConsoleColor.Yellow);
                ColoredOutput.WriteLine($"Путь к сгенерируемому отчету:{reportPath}", ConsoleColor.Yellow);

                Console.WriteLine("Анализ директории...");
                Console.WriteLine("Создание модели...");
                ReportModel reportModel = new ReportModel(directoryPath,out logs);

                Console.WriteLine("Генерация HTML файла...");
                HtmlReportGenerator<ReportModel> reportGenerator = new HtmlReportGenerator<ReportModel>(reportPath, reportModel);

                await reportGenerator.Generate();

                ColoredOutput.WriteLine("Файл успешно сгенерирован", ConsoleColor.Green);
                Console.WriteLine();
                ColoredOutput.WriteLine("Открытие папки с отчетом...", ConsoleColor.Green);
                Process.Start("explorer.exe",reportPath);
            }
            catch (Exception e)
            {
                ColoredOutput.WriteLine($"Ошибка!\n{e.Message}", ConsoleColor.DarkRed);
            }
            return logs;
        }

        static void CheckArgument(string arg1, string arg2, ref string dirPath, ref string repPath)
        {
            if (!(string.IsNullOrEmpty(arg1)) && Directory.Exists(arg1))
            {
                dirPath = arg1;
            }
            else
            {
                ColoredOutput.WriteLine("\nОшибка!\nПути к директории не существует!", ConsoleColor.DarkRed);
            }

            if (!(string.IsNullOrEmpty(arg2)) && Directory.Exists(arg2))
            {
                repPath = arg2;
            }
            else
            {
                ColoredOutput.WriteLine("\nОшибка!\nПути к директории отчета не существует!", ConsoleColor.DarkRed);
            }
        }

        static void PrintLogs(List<string> logs)
        {
            if (logs.Count > 0)
            {
                Console.WriteLine();
                Console.WriteLine("Логи сканирования:");
                foreach (var log in logs)
                {
                    ColoredOutput.WriteLine(log, ConsoleColor.DarkRed);
                }
            }

        }

        static async Task Main(string[] args)
        {
            string directoryPath = Environment.CurrentDirectory;
            string reportPath = Environment.CurrentDirectory;
            List<string> logs = new List<string>();

            if (args.Length == 2)
            {
                CheckArgument(args[0], args[1], ref directoryPath, ref reportPath);
            }

            logs = await Start(directoryPath, reportPath);

            PrintLogs(logs);

            Console.ReadKey();
        }
    }
}