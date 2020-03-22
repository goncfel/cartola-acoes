using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICartola.Model
{
    [Table("usuario")]
    public class Usuario
    {
        [Key]
        public int id { get; set; }
        public string login { get; set; }
        public string nome { get; set; }
        public string senha { get; set; }
    }
}
