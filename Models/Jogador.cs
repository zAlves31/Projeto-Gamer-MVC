using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Gamer_manha.Models
{
    public class Jogador
    {
       [Key] // DATA ANNOTATION - IdJogador  
        public int IdJogador { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        [ForeignKey("Equipe")]
        public int IdEquipe { get; set; } 
        public Equipe Equipe { get; set; } 
    } 
}