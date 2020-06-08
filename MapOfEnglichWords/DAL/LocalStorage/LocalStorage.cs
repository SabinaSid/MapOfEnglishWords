﻿using MapOfEnglishWords.DAL;
using MapOfEnglishWords.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapOfEnglishWords.DAL.LocalStorage
{
    public class LocalStorage : IStorage
    {
        private LocalStorage()
        {
            Words = GetMainWordsPrev();
        }
        static LocalStorage instance;
        public static LocalStorage Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LocalStorage();
                }
                return instance;
            }

        }
        public ObservableCollection<Word> Words { get; set; }
        public ObservableCollection<Word> GetMainWords()
        {
            return Words;
        }
        public ObservableCollection<Word> GetMainWordsPrev()
        {
            //путь к файлу
            var path = "ads.xml";
            return Xml.LoadObjectFromFile<ObservableCollection<Word>>(path);
        }
        public void SaveMainWords()
        {
            var x = Xml.Serelialize(Words);
            x.Save("ads.xml");

        }
    }
}
