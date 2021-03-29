using System;
//using System.Collections.Generic;
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
        public string StrBarra { get; set; }

        public BarrasLinhas(string numBanco, string codMoeda, string digbarra, string fatorVen, string strValor, string cedente, string nossoNum, string dignum, string strbarra)
        {
            NumBanco = numBanco;
            CodMoeda = codMoeda;
            DigBarra = digbarra;
            FatorVen = fatorVen;
            StrValor = strValor;
            Cedente = cedente;
            NossoNum = nossoNum;
            Dig = dignum;
            StrBarra = strbarra;
        }

        public BarrasLinhas(string nossoNum, string dignum)
        {
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

        public int Dig10(string barras)
        {
            int mult = 2, sumaux = 0, resto;
            for (int i = barras.Length - 1; i > -1; i--)
            {
                int aux = int.Parse(barras.Substring(i, 1)) * mult;
                if (aux > 9)
                {
                    sumaux += int.Parse(aux.ToString().Substring(0, 1)) + int.Parse(aux.ToString().Substring(1, 1));
                }
                sumaux += aux;
                if (mult == 2) { mult = 1; } else { mult = 2; }
            }
            resto = sumaux % 10;
            if (resto == 0)
            {
                return 0;
            }
            else
            {
                return (10 - resto);
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

        public string MontarLinha(string strbarra)
        {
            string str1 = strbarra.Substring(0, 4) + strbarra.Substring(19, 5);
            string str2 = strbarra.Substring(24, 10);
            string str3 = strbarra.Substring(34, 10);
            string str4 = strbarra.Substring(4, 1);
            string str5 = strbarra.Substring(5, 14);

            str1 = str1 + Dig10(str1);
            str2 = str2 + Dig10(str2);
            str3 = str3 + Dig10(str3);
            //str4 = str4 + Dig10(str4);

            return str1.Substring(0, 5) + "." + str1.Substring(5) + " " + str2.Substring(0, 5) + "." + str2.Substring(5) + " "
                + str3.Substring(0, 5) + "." + str3.Substring(5) + " " + str4 + " " + str5;
        }

        public override string ToString()
        {
            return "Component." + NumBanco + CodMoeda + DigBarra + FatorVen + StrValor + Cedente + NossoNum + "." + Dig + ".\n\n" +
                   "CodBarras." + MontaBarra() + "\n" +
                   "Linha Dig\n " + MontarLinha(StrBarra) +
                   "\n";
        }
    }
}