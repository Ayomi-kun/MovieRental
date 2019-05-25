namespace MovieRentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixgenremodeldatatype : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genre_Id" });
            DropColumn("dbo.Movies", "GenreID");
            RenameColumn(table: "dbo.Movies", name: "Genre_Id", newName: "GenreID");
            DropPrimaryKey("dbo.Genres");
            AlterColumn("dbo.Movies", "GenreID", c => c.Byte(nullable: false));
            AlterColumn("dbo.Genres", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Genres", "Id");
            CreateIndex("dbo.Movies", "GenreID");
            AddForeignKey("dbo.Movies", "GenreID", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreID", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreID" });
            DropPrimaryKey("dbo.Genres");
            AlterColumn("dbo.Genres", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Movies", "GenreID", c => c.Int());
            AddPrimaryKey("dbo.Genres", "Id");
            RenameColumn(table: "dbo.Movies", name: "GenreID", newName: "Genre_Id");
            AddColumn("dbo.Movies", "GenreID", c => c.Byte(nullable: false));
            CreateIndex("dbo.Movies", "Genre_Id");
            AddForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres", "Id");
        }
    }
}
