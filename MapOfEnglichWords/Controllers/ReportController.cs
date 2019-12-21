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
using WordM = Microsoft.Office.Interop.Word;
using Xceed.Words.NET;

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
            if (words[0].Parent != null)
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
        public static void ExportToWord(ObservableCollection<Word> words)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DicWord.docx");
            if (!File.Exists(path))
            {
                MessageBox.Show("sss");
                //Require(false, "Шаблон отчета отсутсвует");
                return;
            }
            WordM.Application app = new WordM.Application();
            WordM.Document doc = app.Documents.Open(path);
            string rez= "\t\t\t\t\t" + words[0].Name + "  (" + words[0].Translation + ")" + "\n";
            Rec(words[0], ref rez, 0);
            doc.Paragraphs[1].Range.Text = rez;
            app.Visible = true;

            //doc.Paragraphs[1].Range.Text = "Я отчет";
            //app.Visible = true;
            //WordM.Document doc = null;
            //try
            //{
            //    WordM.Application app = new WordM.Application();
            //    doc = app.Documents.Open(path,Visible:true);
            //    doc.Activate();
            //    WordM.Bookmarks wBookmarks = doc.Bookmarks;
            //    WordM.Range wRange;
            //    doc.Paragraphs[1].Range.Text = "жопа \n жопа";


            //int i = 0;
            //foreach (WordM.Bookmark mark in wBookmarks)
            //{

            //    wRange = mark.Range;
            //    wRange.Text = words[i].Name;
            //    i++;
            //}
            //  app.Visible = true;
            // Закрываем документ
            // doc.Close();
            //    doc = null;
            //}
            //catch (Exception ex)
            //{
            //    doc.Close();
            //    doc = null;
            //    Console.WriteLine(ex.Message);
            //} 


            //////

            //string pathDocument = @"..\example.docx";

            //// создаём документ
            //DocX document = DocX.Create(pathDocument);

            //if (words[0].Parent!=null)
            //{
            //    document.InsertParagraph("Словарь для категории: " + words[0].Parent.Name);
            //}
            //else
            //{
            //    document.InsertParagraph("Словарь для категории: все категории");
            //}
            //document.Save();





            //string rez = "\t\t\t\t\t\t"+words[0].Name+ " - "+ words[0].Translation + "\n";

            //Rec(words[0], ref rez, 0);
            //string pathDocument = @"..\example.docx";

            //// создаём документ
            //DocX document = DocX.Create(pathDocument);
            //document.InsertParagraph(rez).FontSize(16);
           
            //document.Save();
        }

        static private void Rec(Word word, ref string result, int otstup)
        {
            string otstupStr = "";
            for (int i = 0; i < otstup; i++)
            {
                otstupStr += "\t";
            }
            bool q = false;
            while (word.Childs.Any() && q == false)
            {
                foreach (var item in word.Childs)
                {
                    result += $"{otstupStr}{item.Name} ({item.Translation}) - {item.Example}\n";
                    //if (item == word.Childs.Last())
                    //{
                    //    result += $"{otstupStr}{item.Name} ({item.Translation}) - {word.Example}\n";
                    //}
                    //else
                    //{
                    //    result += $"{otstupStr}{item.Name} ({item.Translation}) - {word.Example}\n";
                    //}
                    Rec(item, ref result, otstup + 1);
                }
                q = true;
            }

        }
    }
}
