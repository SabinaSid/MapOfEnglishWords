using MapOfEnglichWords.DAL;
using MapOfEnglichWords.DAL.Rep;
using MapOfEnglichWords.Model;
using MapOfEnglichWords.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapOfEnglichWords.ViewModel
{
    public class EditVM:ViewModelBase
    {
        Word word;
        UnitOfWork manager;
        Word newWord;
        private Command editWord;
        public Command EditWord
        {
            get
            {
                return editWord ??
                    (editWord = new Command(obj =>
                    {
                        manager.Words.Update(word,newWord);
                        View.Close();
                    }));
            }
        }

        public EditVM(IView view)
            :base(view)
        {
            manager = new UnitOfWork(LocalStorageCode.Instance);
            View.Show();
        }
    }
}
