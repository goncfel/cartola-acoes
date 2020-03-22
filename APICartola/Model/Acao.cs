using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICartola.Model
{
    [Table("acao")]
    public class Acao
    {
        [Key]
        public int id { get; set; }
        public string codAcao { get; set; }
    }
}
