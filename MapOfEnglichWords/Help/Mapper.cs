using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapOfEnglishWords;
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
                Example = dto.Example
            };
        }

        private  static ObservableCollection<Word> ToWords(this ICollection<WordDto> dtos)
        {
            return new ObservableCollection<Word>(dtos.Select(x=>x.ToBaseWord()));
        }

        public static Word ToWord(this WordDto dto)
        {
            var word = dto.ToBaseWord();
            //word.Parent = dto.Parents.ToWords();
            word.Childs = dto.Childrens.ToWords();

            return word;
        }
    }
}
