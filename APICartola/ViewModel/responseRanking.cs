using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICartola.ViewModel
{
    public class ResponseRanking
    {
        public int idGrupo { get; set; }
        public string nomeGrupo { get; set; }
        public List<ClassificacaoUsuario> listaClassificacao { get; set; }
        
        public ResponseRanking()
        {
            listaClassificacao = new List<ClassificacaoUsuario>();
        }
    }

    public class ClassificacaoUsuario
    {
        public int classificacao { get; set; }
        public int idUsuario { get; set; }
        public string nomeUsuario { get; set; }
        public decimal patrimonioInicial { get; set; }
        public decimal patrimonioAtual { get; set; }
        public decimal valorizacaoPerc { get; set; }
    }
}
