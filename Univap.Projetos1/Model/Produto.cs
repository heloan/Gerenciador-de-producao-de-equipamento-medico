using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Univap.Projetos1.Model
{
    public class Produto
    {
        public Int32 Id { get; set; }
        public String CodigoNomeTecnico { get; set; }
        public String RegraClassificacao { get; set; }
        public String ClasseRisco { get; set; }
        public String NomeComercial { get; set; }
        public String NomeComercialInternacional { get; set; }
        public String ModelosComerciais { get; set; }
        public String Acessorios { get; set; }
        public String ApresentacaoComercial { get; set; }
        public String ImagemProdutoCaminho { get; set; }
        public String NomeTecnico { get; set; }
        public String TipoPeticao { get; set; }
        public String ManualUsuario { get; set; }
        public Int32 IdFornecedor { get; set; }
        public Int32 IdResponsavel { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public Int32 Status { get; set; }
    }
}
