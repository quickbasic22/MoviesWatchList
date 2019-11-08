namespace MoviesWatchList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixWatchOnstringtodatetime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "WatchOn", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "WatchOn", c => c.String());
        }
    }
}
