using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirMimeTypeParser.HTMLGenerator
{
    
    public interface IHtmlGenerator
    {
        public async Task Generate();
    }


    public class HtmlReportGenerator : IHtmlGenerator
    {
        public string ReportPath { get; set; }

        public HtmlReportGenerator(string reportPath)
        {

        }

        public async Task Generate()
        {
            throw new NotImplementedException();
        }

        private async Task Generate(string reportDocPath)
        {

        }
    }
}
