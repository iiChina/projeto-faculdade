namespace Projeto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FilmeModels", "Cliente_Id", c => c.Int());
            CreateIndex("dbo.FilmeModels", "Cliente_Id");
            AddForeignKey("dbo.FilmeModels", "Cliente_Id", "dbo.ClienteModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FilmeModels", "Cliente_Id", "dbo.ClienteModels");
            DropIndex("dbo.FilmeModels", new[] { "Cliente_Id" });
            DropColumn("dbo.FilmeModels", "Cliente_Id");
        }
    }
}
