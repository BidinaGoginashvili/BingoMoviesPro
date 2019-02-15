namespace BingoMoviesPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieModel2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actors", "ActorImg", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Actors", "ActorImg");
        }
    }
}
