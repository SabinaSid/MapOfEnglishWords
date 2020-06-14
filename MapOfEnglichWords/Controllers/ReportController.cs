using MapOfEnglishWords.Model;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using WordM = Microsoft.Office.Interop.Word;
using MapOfEnglishWords.View;
using MapOfEnglishWords.ViewModel;

namespace MapOfEnglishWords.Controllers
{
    public static class ReportController
    {
        public static void ExportToExel(ObservableCollection<Word> words)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Dictionary.xlsx");
            try
            {
                if (!File.Exists(path))
                {
                    throw new Exception("Шаблон отчета отсутствует");
                }
                var ExcelApp = new Excel.Application();
                ExcelApp.Visible = true;

                var book = ExcelApp.Workbooks.Open(path);
                var sheet = (Excel.Worksheet)book.Worksheets[1];

                sheet.UsedRange.Replace("#count", words.Count);
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
            catch (Exception ex)
            {
                new MessageWinVM(new MessageWin(), ex.Message);
            }



        }
        public static void ExportToWord(Word word)
        {
            
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DicWord.docx");
            try
            {
                if (!File.Exists(path))
                {
                    throw new Exception("Шаблон отчета отсутствует");
                }
                if (word==null) throw new Exception("Сначала выберите слово");
                WordM.Application app = new WordM.Application();
                WordM.Document doc = app.Documents.Open(path);
                string rez = "\t\t\t\t\t" + word.Name + "  (" + word.Translation + ")" + "\n";
                Rec(word, ref rez, 0);
                doc.Paragraphs[1].Range.Text = rez;
                app.Visible = true;
            }
            catch(Exception ex)
            {
                new MessageWinVM(new MessageWin(), ex.Message);
            }
           
        }

        static private void Rec(Word word, ref string result, int otstup)
        {
            string otstupStr = "";
            for (int i = 0; i < otstup; i++)
            {
                otstupStr += "\t";
            }
            bool q = false;
            while (word.Children.Any() && q == false)
            {
                foreach (var item in word.Children)
                {
                    result += $"{otstupStr}{item.Name} ({item.Translation}) - {item.Example}\n";
                    Rec(item, ref result, otstup + 1);
                }
                q = true;
            }

        }
    }
}
