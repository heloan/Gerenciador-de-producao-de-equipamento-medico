using System;

namespace Univap.Projetos1.Model
{
    public class Responsavel
    {
        public Int32 Id { get; set; }
        public String ResponsavelLegal { get; set; }
        public String ResponsavelTecnico { get; set; }
        public String Cargo { get; set; }
        public String ConselhoClasse { get; set; }
        public String UF { get; set; }
        public String NumeroInscricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public Int32 Status { get; set; }
    }
}