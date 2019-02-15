namespace BingoMoviesPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Final2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovieMains", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MovieMains", "Description");
        }
    }
}
