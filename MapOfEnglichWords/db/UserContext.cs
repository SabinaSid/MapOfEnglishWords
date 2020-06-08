using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapOfEnglishWords;
using MapOfEnglishWords.Model;

namespace MapOfEnglishWords.db
{
    public class UserContext : DbContext
    {
        public UserContext()
            : base("DbConnection")
        {
        }

        public DbSet<WordDb> Words { get; set; }
    }
}
