namespace EntityFrameworkEscola.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Versao01 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CursoProfessor", "CursoId", "dbo.Curso");
            DropForeignKey("dbo.CursoProfessor", "ProfessorId", "dbo.Professor");
            DropForeignKey("dbo.Turma", "CursoId", "dbo.Curso");
            DropForeignKey("dbo.Turma", "ProfessorId", "dbo.Professor");
            DropForeignKey("dbo.Aluno", "TurmaId", "dbo.Turma");
            DropIndex("dbo.Aluno", new[] { "TurmaId" });
            DropIndex("dbo.Turma", new[] { "CursoId" });
            DropIndex("dbo.Turma", new[] { "ProfessorId" });
            DropIndex("dbo.CursoProfessor", new[] { "CursoId" });
            DropIndex("dbo.CursoProfessor", new[] { "ProfessorId" });
            DropColumn("dbo.Aluno", "TurmaId");
            DropColumn("dbo.Turma", "CursoId");
            DropColumn("dbo.Turma", "ProfessorId");
            DropTable("dbo.CursoProfessor");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CursoProfessor",
                c => new
                    {
                        CursoId = c.Int(nullable: false),
                        ProfessorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CursoId, t.ProfessorId });
            
            AddColumn("dbo.Turma", "ProfessorId", c => c.Int(nullable: false));
            AddColumn("dbo.Turma", "CursoId", c => c.Int(nullable: false));
            AddColumn("dbo.Aluno", "TurmaId", c => c.Int(nullable: false));
            CreateIndex("dbo.CursoProfessor", "ProfessorId");
            CreateIndex("dbo.CursoProfessor", "CursoId");
            CreateIndex("dbo.Turma", "ProfessorId");
            CreateIndex("dbo.Turma", "CursoId");
            CreateIndex("dbo.Aluno", "TurmaId");
            AddForeignKey("dbo.Aluno", "TurmaId", "dbo.Turma", "TurmaId");
            AddForeignKey("dbo.Turma", "ProfessorId", "dbo.Professor", "ProfessorId");
            AddForeignKey("dbo.Turma", "CursoId", "dbo.Curso", "CursoId");
            AddForeignKey("dbo.CursoProfessor", "ProfessorId", "dbo.Professor", "ProfessorId");
            AddForeignKey("dbo.CursoProfessor", "CursoId", "dbo.Curso", "CursoId");
        }
    }
}
