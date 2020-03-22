using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICartola.Model
{
    [Table("grupo")]
    public class Grupo
    {
        [Key]
        public int id { get; set; }
        public string nomeGrupo { get; set; }
    }
}
