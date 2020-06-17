using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using MapOfEnglishWords.Help;
using MapOfEnglishWords.Model;
using MapOfEnglishWords.View;

namespace MapOfEnglishWords.ViewModel
{
    class TrainerVM : ViewModelBase
    {
        private IWordService wordService = ServiceLocator.GetService<IWordService>();
        private bool translateEnglish;
        public bool TranslateEnglish
        {
            get => translateEnglish;
            set => Set(ref translateEnglish, value);
        }

        private Word oneWord;
        public Word OneWord
        {
            get => oneWord;
            set => Set(ref oneWord, value);
        }
        private Word twoWord;
        public Word TwoWord
        {
            get => twoWord;
            set => Set(ref twoWord, value);
        }
        private Word threeWord;
        public Word ThreeWord
        {
            get => threeWord;
            set => Set(ref threeWord, value);
        }
        private string text;
        public string Text
        {
            get => text;
            set => Set(ref text, value);
        }

        private Word answerWord;
        private string visibility;
        public string Visibility
        {
            get => visibility;
            set => Set(ref visibility, value);
        }

        private int CheckWord()
        {
            if (answerWord.IdWord==OneWord.IdWord) return 1;
            if (answerWord.IdWord == TwoWord.IdWord) return 2;
            if (answerWord.IdWord == ThreeWord.IdWord) return 3;
            return 0;
        }
        private ICommand сheckAnswer;
        public ICommand CheckAnswer
        {
            get
            {
                return сheckAnswer ??
                       (сheckAnswer = new Command(obj =>
                       {
                           
                           if (obj is string answer)
                           {
                               
                               if (int.Parse(answer) == CheckWord())
                               {
                                   Visibility = "Visible";
                                   Text = $"Ура! Все верно. Идем дальше?";
                                   wordService.UpdateForTrainer(answerWord.IdWord);
                               }
                               else
                               {
                                   Text = $"Упс. Ошибка попробуйте снова: переведите  «{answerWord.Translation}»";
                               }
                           }

                          
                       }));
            }
        }
        private ICommand refresh;
        public ICommand Refresh
        {
            get
            {
                return refresh ??
                       (refresh = new Command(obj =>
                       {
                           if (Text.Contains("На сегодня")) 
                               View.Close();
                           UpdateWindow();
                       }));
            }
        }

       
        public TrainerVM(IView view)
            : base(view)
        {
            UpdateWindow();
            View.ShowDialog();
        }
        private string content;
        public string Content
        {
            get => content;
            set => Set(ref content, value);
        }

        private void UpdateWindow()
        {
            try
            {
                var collection = wordService.GetForRepeat().Select(x => x.ToWord()).ToList();
                answerWord = collection[0];
                Shuffle(collection);
                //Shuffle(collection);
                OneWord = collection[0];
                collection.RemoveAt(0);
                TwoWord = collection.First();
                collection.Remove(twoWord);
                ThreeWord = collection.First();
                Visibility = "Hidden";
                Content = "Дальше";
                TranslateEnglish =  new Random().Next(0,2) != 0;
                Text = TranslateEnglish ? $"Переведите «{answerWord.Translation}»" : $"Переведите «{answerWord.Name}»";
            }
            catch (WordException ex)
            {
                Text = ex.Message;
                Content = "ОК";
                refresh  = new Command(obj =>
                {
                   View.Close();
                });
            }
        }

        public static void Shuffle(List<Word> arr)
        {
            var rand = new Random();

            for (var i = arr.Count - 1; i >= 1; i--)
            {
                var j = rand.Next(i + 1);

                var tmp = arr[j];
                arr[j] = arr[i];
                arr[i] = tmp;
            }
        }
    }
}
