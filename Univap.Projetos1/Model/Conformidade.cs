using System;

namespace Univap.Projetos1.Model
{
    public class Conformidade
    {
        public Int32 Id { get; set; }
        public UInt32 AutorizacaoFuncionamento { get; set; }
        public UInt32 LicencaFuncionamento { get; set; }
        public UInt32 BoasPraticas { get; set; }
        public UInt32 IdentificacaoSanitaria { get; set; }
        public UInt32 ClassificacaoEquipamento { get; set; }
        public UInt32 CertificadoInmetro { get; set; }
        public UInt32 InformacoesEconomica { get; set; }
        public UInt32 TipoPeticao { get; set; }
        public UInt32 EnvioPeticao { get; set; }
        public UInt32 NumeroPeticao { get; set; }
        public UInt32 ResutadoAnalise { get; set; }
        public Int32 IdProduto { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public Int32 Status { get; set; }
    }
}
