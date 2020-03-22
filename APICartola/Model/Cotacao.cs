using NpgsqlTypes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICartola.Model
{
    [Table("cotacao")]
    public class Cotacao
    {
        [Key]
        public int id { get; set; }
        public int idAcao { get; set; }
        public decimal cotacao { get; set; }
        public decimal variacao { get; set; }
        public DateTime dataCotacao { get; set; }
        public int semana { get; set; }
    }
}
