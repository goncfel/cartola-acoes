using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICartola.ViewModel
{
    public class responseMinhaCarteira
    {
        public int idCarteira { get; set; }
        public int semana { get; set; }

        public List<DetalheCarteira> listaAcoes { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal PercTotal { get; set; }

        public responseMinhaCarteira()
        {
            listaAcoes = new List<DetalheCarteira>();
        }
    }
}
