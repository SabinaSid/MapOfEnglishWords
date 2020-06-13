namespace MapOfEnglishWords.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Word", "CountRepeat", c => c.Int(nullable: false, defaultValue: 1));
            AddColumn("dbo.Word", "LastRepeatDate", c => c.DateTime(nullable: false, defaultValueSql: "GetDate()"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Word", "LastRepeatDate");
            DropColumn("dbo.Word", "CountRepeat");
        }
    }
}
