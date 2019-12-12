using MapOfEnglishWords.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Excel = Microsoft.Office.Interop.Excel;
using Word1 = Microsoft.Office.Interop.Word;

namespace MapOfEnglichWords.Controllers
{
    public static class ReportController
    {
        public static void ExportToExel(ObservableCollection<Word> words)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Dictionary.xlsx");
            if (!File.Exists(path))
            {
                MessageBox.Show("sss");
                //Require(false, "Шаблон отчета отсутсвует");
                return;
            }
            var ExcelApp = new Excel.Application();
            ExcelApp.Visible = true;

            var book = ExcelApp.Workbooks.Open(path);
            var sheet = (Excel.Worksheet)book.Worksheets[1];

            sheet.UsedRange.Replace("#count", words.Count);
            if (words[0].Parent!=null)
            {
                sheet.UsedRange.Replace("#parant", words[0].Parent.Name);
            }
            else sheet.UsedRange.Replace("#parant", "все категории");
            var range = sheet.UsedRange.Find("#name");
            var row = range.Row;

            foreach (var item in words)
            {
                sheet.Cells[row, 1] = item.Name;
                sheet.Cells[row, 2] = item.Translation;
                sheet.Cells[row, 3] = item.Example;
                row++;
            }
        }
        public static void ExportToWord(Word word)
        {
            Word1.Application app = new Word1.Application();
            Word1.Document doc = app.Documents.Add();
            doc.Paragraphs[1].Range.Text = "Я отчет";
            app.Visible = true;
        }
    }
}
