using System;
using System.Collections.Generic;
using System.Text;

namespace CalcVencimento.Classes
{
    class BarrasLinhas
    {
        public string NumBanco { get; set; }
        public string CodMoeda { get; set; }
        public string Dig { get; set; }
        public string DigBarra { get; set; }
        public string IdClient { get; set; }
        public string Cedente { get; set; }
        public string NumParc { get; set; }
        public string FatorVen { get; set; }
        public string StrValor { get; set; }
        public string NossoNum { get; set; }

        public BarrasLinhas(string numBanco, string codMoeda, string digbarra, string fatorVen, string strValor, string cedente, string nossoNum, string dignum)
        {
            NumBanco = numBanco;
            CodMoeda = codMoeda;
            DigBarra = digbarra;
            FatorVen = fatorVen;
            StrValor = strValor;
            Cedente = cedente;
            NossoNum = nossoNum;
            Dig = dignum;
        }

        public BarrasLinhas()
        {
        }

        public int Dig11(string vlconv)
        {
            int mult = 2, sumaux = 0, resto;
            for (int i = vlconv.Length - 1; i > -1; i--)
            {
                int aux = int.Parse(vlconv.Substring(i, 1)) * mult;
                sumaux += aux;
                if (mult < 9)
                {
                    mult += 1;
                }
                else
                {
                    mult = 2;
                }
            }
            resto = sumaux % 11;
            if (resto == 0 || resto == 1 || resto == 10)
            {
                return 1;
            }
            else
            {
                return 11 - resto;
            }
        }
        public int Dig11(string cedente, string nnum)
        {
            string vlconv = cedente + nnum;
            int mult = 2, sumaux = 0, resto;
            for (int i = vlconv.Length - 1; i > -1; i--)
            {
                int aux = int.Parse(vlconv.Substring(i, 1)) * mult;
                sumaux += aux;
                if (mult < 9)
                {
                    mult += 1;
                }
                else
                {
                    mult = 2;
                }
            }
            resto = sumaux % 11;
            if (resto == 0 || resto == 1 || resto == 10)
            {
                return 1;
            }
            else
            {
                return 11 - resto;
            }
        }

        public int Dig11(int c1, int c2, int cclie, int numparc) //Está certinho
        {
            string vlconv = c1.ToString() + c2.ToString() + cclie.ToString("0000000000000") + numparc.ToString("00");
            int mult = 2, sumaux = 0, resto;
            for (int i = vlconv.Length - 1; i > -1; i--)
            {
                int aux = int.Parse(vlconv.Substring(i, 1)) * mult;
                sumaux += aux;
                if (mult < 9)
                {
                    mult += 1;
                }
                else
                {
                    mult = 2;
                }
            }
            resto = sumaux % 11;

            if (resto == 0 || resto == 1)
            {
                return 0;
            }
            else if (11 - resto > 9)
            {
                return 0;
            }
            else
            {
                return 11 - resto;
            }
        }

        public string VConv(double num)
        {
            return (num * 100).ToString("0000000000");
        }

        public string NNum(int c1, int c4, int cdcli, int parc)
        {
            string c_1 = c1.ToString("0000"); string c_4 = c4.ToString("0000"); string codcli = cdcli.ToString("0000000"); string parcc = parc.ToString("00");
            return c_1 + c_4 + codcli + parcc;
        }
        public string MontaBarra() //string banco, string moeda, string dig, string fatorV, string strValor, string cdte, string nossonum
        {
            return NumBanco + CodMoeda + DigBarra + FatorVen + StrValor + Cedente + NossoNum + Dig;
        }

        public override string ToString()
        {
            return "Component." + NumBanco + "." + CodMoeda + "." + DigBarra + "." + FatorVen + "." + StrValor + "." + Cedente + "." + NossoNum + "." + Dig +".\n" +
                   "CodBarras." +  MontaBarra();
        }
    }
}
