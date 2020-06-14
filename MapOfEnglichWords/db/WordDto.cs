using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapOfEnglishWords.db
{
    [Table("Word")]
    public class WordDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Translation { get; set; }

        public string Example { get; set; }

        public int CountRepeat { get; set; }

        public DateTime LastRepeatDate { get; set; }

        [Column("Parent")]
        public virtual ICollection<WordDto> Parents { get; set; }
        [Column("Child")]
        public virtual ICollection<WordDto> Childrens { get; set; }

        public WordDto()
        {
            Parents = new List<WordDto>();
            Childrens = new List<WordDto>();
        }
    }
}