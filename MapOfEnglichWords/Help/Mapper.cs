using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapOfEnglishWords;
using MapOfEnglishWords.db;
using MapOfEnglishWords.Model;

namespace MapOfEnglishWords.Help
{
    public static  class Mapper
    {
        private static Word ToBaseWord(this WordDto dto)
        {
            return new Word()
            {
                IdWord = dto.Id,
                Translation = dto.Translation,
                Name = dto.Name,
                Example = dto.Example,
                CountRepeat = dto.CountRepeat,
                LastRepeatDate = dto.LastRepeatDate
            };
        }

        private  static ObservableCollection<Word> ToWords(this ICollection<WordDto> dtos)
        {
            return new ObservableCollection<Word>(dtos.Select(x=>x.ToBaseWord()));
        }

        public static ObservableCollection<Word> ToObservableCollectionWords(this IEnumerable<Word> dtos)
        {
            return new ObservableCollection<Word>(dtos);
        }

        public static Word ToWord(this WordDto dto)
        {
            var word = dto.ToBaseWord();
            word.Parents = dto.Parents.ToWords();
            word.Children = dto.Childrens.ToWords();

            return word;
        }


        public static Word ToBasseWord(this WordDto dto)
        {
            var word = dto.ToBaseWord();
   

            return word;
        }

        public static WordDto ToWordDto(this Word word)
        {
            return new WordDto()
            {
                Id = word.IdWord,
                Name = word.Name,
                Translation = word.Translation,
                Example = word.Example,
                CountRepeat = word.CountRepeat == default ? 1 : word.CountRepeat,
                LastRepeatDate = word.LastRepeatDate == default ? DateTime.Now : word.LastRepeatDate,
                Parents = word.Parents.Select(x => new WordDto {Id = x.IdWord}).ToList(),
                Childrens = word.Children.Select(x => new WordDto {Id = x.IdWord}).ToList()
            };
        }
    }
}
