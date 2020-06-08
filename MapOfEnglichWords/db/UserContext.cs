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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WordDto>()
                .HasMany(c => c.Parents)
                .WithMany(p => p.Childrens)
                .Map(m =>
                {
                    // Ссылка на промежуточную таблицу
                    m.ToTable("ParentChild");

                    // Настройка внешних ключей промежуточной таблицы
                    m.MapLeftKey("ChildId");
                    m.MapRightKey("ParentId");
                });
        }

        public DbSet<WordDto> Words { get; set; }
    }
}
