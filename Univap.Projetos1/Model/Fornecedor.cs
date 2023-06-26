using System;

namespace Univap.Projetos1.Model
{
    public class Fornecedor
    {
        public Int32 Id { get; set; }
        public String RazaoSocial { get; set; }
        public String NomeFantasia { get; set; }
        public String Endereco { get; set; }
        public String Cidade { get; set; }
        public String UF { get; set; }
        public String CEP { get; set; }
        public String Telefone { get; set; }
        public String Email { get; set; }
        public String AutorizacaoANVISA { get; set; }
        public String CNPJ { get; set; }
        public String Site { get; set; }
        public Int32 IdResponsavel { get; set; }
        public Int32 IdAutenticacao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public Int32 Status { get; set; }
    }
}