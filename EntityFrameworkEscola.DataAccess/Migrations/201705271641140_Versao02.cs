namespace EntityFrameworkEscola.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Versao02 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Usuario", "Idx_Usuario_Email");
            CreateIndex("dbo.Usuario", "Email", name: "Idx_Usuario_Email");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Usuario", "Idx_Usuario_Email");
            CreateIndex("dbo.Usuario", "Email", unique: true, name: "Idx_Usuario_Email");
        }
    }
}
