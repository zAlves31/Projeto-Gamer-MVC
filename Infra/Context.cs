
using Microsoft.EntityFrameworkCore;
using Projeto_Gamer_manha.Models;

namespace Projeto_Gamer_manha.Infra
{
    public class Context : DbContext
    {
       public Context()
       {

       }

       public Context(DbContextOptions<Context> options) : base(options)
       {

       }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // string de conexao com o banco
                // Data Source: o nome do servidor do gerenciador do banco
                // Initial catalog: nome do banco de dados

                // autenticacao pelo windows
                // Integrated Security: autenticacao pelo windows
                // TrustServerCertificate: autenticacao pelo windows

                // autenticacao pelo SqlServer
                // Id User = "nome do seu usuario de login"
                // password = "senha do usuario"
                optionsBuilder.UseSqlServer("Data Source = NOTE10-S14; Initial catalog = gamerManha; User Id = sa; pwd = Senai@134; TrustServerCertificate = true ");
            }
        }

        public DbSet<Jogador> Jogador { get; set; }
        public DbSet<Equipe> Equipe { get; set; }
    }
}