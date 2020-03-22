using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICartola.ViewModel
{
    public class responseCotacao
    {
        public int id { get; set; }
        public string codAcao { get; set; }
        public decimal cotacao { get; set; }
        public decimal variacao { get; set; }
        public DateTime dataCotacao { get; set; }
    }
}
