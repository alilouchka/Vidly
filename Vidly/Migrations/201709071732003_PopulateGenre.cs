namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (name) VALUES ('Comedy')");
            Sql("INSERT INTO Genres (name) VALUES ('Action')");
            Sql("INSERT INTO Genres (name) VALUES ('Science fiction')");
            Sql("INSERT INTO Genres (name) VALUES ('Animation')");



        }

        public override void Down()
        {
        }
    }
}
