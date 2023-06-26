using System;

namespace Univap.Projetos1.Model
{
    public class Processo
    {
        public Int32 Id { get; set; }
        public Int32 IdProduto { get; set; }
        public String NumeroProcesso { get; set; }
        public String NumeroNotificacao { get; set; }
        public String CodigoPeticao { get; set; }
        public String Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public Int32 Status { get; set; }
    }
}