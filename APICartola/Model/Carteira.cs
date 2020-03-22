using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICartola.Model
{
    [Table("carteira")]
    public class Carteira
    {
        [Key]
        public int id { get; set; }
        public int idUsuario { get; set; }
        public int idAcao1 { get; set; }
        public int qtdAcao1 { get; set; }
        public int idAcao2 { get; set; }
        public int qtdAcao2 { get; set; }
        public int idAcao3 { get; set; }
        public int qtdAcao3 { get; set; }
        public int idAcao4 { get; set; }
        public int qtdAcao4 { get; set; }
        public int idAcao5 { get; set; }
        public int qtdAcao5 { get; set; }
        public int semana { get; set; }
        public decimal rentabilidade { get; set; }
        public decimal rentValor { get; set; }
    }
}
