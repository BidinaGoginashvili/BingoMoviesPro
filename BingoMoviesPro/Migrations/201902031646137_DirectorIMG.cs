namespace BingoMoviesPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DirectorIMG : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Directors", "ImgDirector", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Directors", "ImgDirector");
        }
    }
}
