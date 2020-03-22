using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICartola.ViewModel
{
    public class DetalheCarteira
    {
        public int idAcao { get; set; }
        public string codAcao { get; set; }
        public int qtdAcao { get; set; }
        public decimal custo { get; set; }
        public decimal cotacaoInicial { get; set; }
        public decimal cotacaoAtual { get; set; }
        public decimal percentual { get; set; }
        public decimal valorTotal { get; set; }
    }
}
