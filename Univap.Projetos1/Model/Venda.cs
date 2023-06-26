using System;

namespace Univap.Projetos1.Model
{
    public class Venda
    {
        public Int32 Id { get; set; }
        public Int32 IdProduto { get; set; }
        public String NomeRepresentante { get; set; }
        public String NomeEmpresa { get; set; }
        public String CPF { get; set; }
        public String CNPJ { get; set; }
        public String Email { get; set; }
        public String Telefone { get; set; }
        public String Endereco { get; set; }
        public DateTime DataVenda { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public Int32 Status { get; set; }
    }
}