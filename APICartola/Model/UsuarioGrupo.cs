using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICartola.Model
{
    [Table("usuarioGrupo")]
    public class UsuarioGrupo
    {
        [Key]
        public int id { get; set; }
        public int idUsuario { get; set; }
        public int idGrupo { get; set; }
        public decimal patrimonioInicial { get; set; }
        public decimal patrimonioAtual { get; set; }
        public decimal valorizacaoPerc { get; set; }
    }
}
