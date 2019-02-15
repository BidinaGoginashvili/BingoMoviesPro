namespace BingoMoviesPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidationsAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Actors", "FullName", c => c.String(nullable: false, maxLength: 70));
            AlterColumn("dbo.Actors", "ActorImg", c => c.String(nullable: false));
            AlterColumn("dbo.MovieMains", "MovieTitleEng", c => c.String(nullable: false));
            AlterColumn("dbo.MovieMains", "MovieTitleKa", c => c.String(nullable: false));
            AlterColumn("dbo.MovieMains", "ReleaseDate", c => c.String(nullable: false));
            AlterColumn("dbo.MovieMains", "MovieImgpath", c => c.String(nullable: false));
            AlterColumn("dbo.MovieMains", "MovieVdpath", c => c.String(nullable: false));
            AlterColumn("dbo.MovieMains", "DirectorFullName", c => c.String(nullable: false));
            AlterColumn("dbo.MovieMains", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.MovieComments", "Comment", c => c.String(nullable: false));
            AlterColumn("dbo.Sliders", "imgSlider", c => c.String(nullable: false));
            AlterColumn("dbo.Sliders", "linkSlider", c => c.String(nullable: false));
            AlterColumn("dbo.Sliders", "textSlider", c => c.String(nullable: false));
            AlterColumn("dbo.UserSignUps", "ProfileImage", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserSignUps", "ProfileImage", c => c.String());
            AlterColumn("dbo.Sliders", "textSlider", c => c.String());
            AlterColumn("dbo.Sliders", "linkSlider", c => c.String());
            AlterColumn("dbo.Sliders", "imgSlider", c => c.String());
            AlterColumn("dbo.MovieComments", "Comment", c => c.String());
            AlterColumn("dbo.MovieMains", "Description", c => c.String());
            AlterColumn("dbo.MovieMains", "DirectorFullName", c => c.String());
            AlterColumn("dbo.MovieMains", "MovieVdpath", c => c.String());
            AlterColumn("dbo.MovieMains", "MovieImgpath", c => c.String());
            AlterColumn("dbo.MovieMains", "ReleaseDate", c => c.String());
            AlterColumn("dbo.MovieMains", "MovieTitleKa", c => c.String());
            AlterColumn("dbo.MovieMains", "MovieTitleEng", c => c.String());
            AlterColumn("dbo.Actors", "ActorImg", c => c.String());
            AlterColumn("dbo.Actors", "FullName", c => c.String());
        }
    }
}
