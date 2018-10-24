namespace MovieRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataToGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Action');");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Adventure');");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Comedy');");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Family');");
            Sql("INSERT INTO Genres (Id, Name) VALUES (6, 'Crime');");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Drama');");
            Sql("INSERT INTO Genres (Id, Name) VALUES (7, 'Epic');");
            Sql("INSERT INTO Genres (Id, Name) VALUES (8, 'Horror');");
            Sql("INSERT INTO Genres (Id, Name) VALUES (9, 'Fantasy');");
            Sql("INSERT INTO Genres (Id, Name) VALUES (10, 'Musical');");
            Sql("INSERT INTO Genres (Id, Name) VALUES (11, 'Mystery');");
            Sql("INSERT INTO Genres (Id, Name) VALUES (12, 'Romance');");
            Sql("INSERT INTO Genres (Id, Name) VALUES (13, 'Thriller');");
            Sql("INSERT INTO Genres (Id, Name) VALUES (14, 'War');");
            Sql("INSERT INTO Genres (Id, Name) VALUES (15, 'Western');");
            Sql("INSERT INTO Genres (Id, Name) VALUES (16, 'Science Fiction');");


        }
        
        public override void Down()
        {
        }
    }
}
