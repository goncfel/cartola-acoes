using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICartola.Model
{
    [Table("temporada")]
    public class Temporada
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
    }
}
