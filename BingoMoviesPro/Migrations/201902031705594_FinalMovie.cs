namespace BingoMoviesPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinalMovie : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MovieMains", "DirectorsId", "dbo.Directors");
            DropIndex("dbo.MovieMains", new[] { "DirectorsId" });
            DropColumn("dbo.MovieMains", "DirectorsId");
            DropTable("dbo.Directors");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Directors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        ImgDirector = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.MovieMains", "DirectorsId", c => c.Int(nullable: false));
            CreateIndex("dbo.MovieMains", "DirectorsId");
            AddForeignKey("dbo.MovieMains", "DirectorsId", "dbo.Directors", "Id", cascadeDelete: true);
        }
    }
}
