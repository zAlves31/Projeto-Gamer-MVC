using System.ComponentModel.DataAnnotations;

namespace Projeto_Gamer_manha.Models
{
    public class Equipe
    {
        [Key] // DATA ANNOTATION - IdEquipe  
        public int IdEquipe { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }

        public ICollection<Jogador> Jogador { get; set; }
    }
}