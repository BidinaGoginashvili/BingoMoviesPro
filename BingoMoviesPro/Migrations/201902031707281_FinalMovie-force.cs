namespace BingoMoviesPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinalMovieforce : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovieMains", "DirectorFullName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MovieMains", "DirectorFullName");
        }
    }
}
