using EntityFrameworkEscola.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace EntityFrameworkEscola.DataAccess.Map
{
    public class AlunoMap : EntityTypeConfiguration<Aluno>
    {
        public AlunoMap()
        {
            ToTable("Aluno");
            HasKey(x => x.AlunoId);


            //*1:1 - 1 aluno deve ter apenas 1 usuário
            HasRequired(x => x.Usuario)
            .WithRequiredPrincipal();
        }
    }
}
