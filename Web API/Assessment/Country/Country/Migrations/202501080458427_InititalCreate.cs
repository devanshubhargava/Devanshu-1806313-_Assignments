namespace Country.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InititalCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                        Capital = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Contries");
        }
    }
}
