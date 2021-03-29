using System;
using System.Globalization;

namespace CalcVencimento.Classes
{
    class Parcelas
    {
        public int NumParc { get; set; }
        public string NrDuplic { get; set; }
        public DateTime Emissao { get; set; }
        public double ValorParc { get; set; }
        public DateTime Vencto { get; set; }
        public int Fator { get; set; }
        

        public Parcelas(int numParc, string nrDuplic, DateTime emissao, double valorParc, DateTime vencto, int fator)
        {
            NumParc = numParc;
            NrDuplic = nrDuplic;
            Emissao = emissao;
            ValorParc = valorParc;
            Vencto = vencto;
            Fator = fator;
        }

        public Parcelas()
        {
        }

        public override string ToString()
        {
            return NumParc
                + "-"
                + NrDuplic
                + "-"
                + Emissao.ToShortDateString()
                + "-"
                + " R$ "
                + ValorParc.ToString("f2", CultureInfo.InvariantCulture)
                + " - "
                + Vencto.ToShortDateString()
                + " - Fator Vencimento: "
                + Fator;
        }
    }
}
