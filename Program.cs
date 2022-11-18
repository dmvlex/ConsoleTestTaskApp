using System;
using System.IO;
using DirMimeTypeParser.HTMLGenerator;
using DirMimeTypeParser.DirectoryDataParser;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using DirMimeTypeParser.HTMLGenerator.RazorPagesCompiler.model;
using System.Collections.Generic;

namespace DirMimeTypeParser
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string directorypath = "E:\\OTHER\\GUITAR\\SAMPLE";
            string reportpath = "C:\\Users\\Alexandro\\Desktop\\fuck2";
            List<string> logs = new List<string>();

            Console.WriteLine("Dir note");
            DirectoryDataTreeParser dataParser = new DirectoryDataTreeParser(directorypath);

            Console.WriteLine("Rep Model");
            ReportModel reportModel = new ReportModel(dataParser.GetParsedData(out logs));

            Console.WriteLine("Generating report...");
            HtmlReportGenerator<ReportModel> reportGenerator = new HtmlReportGenerator<ReportModel>(reportpath, reportModel);

            await reportGenerator.Generate();

            Console.WriteLine("Generated");
            Console.ReadKey();

        }
    }
}