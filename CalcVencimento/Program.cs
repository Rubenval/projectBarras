using System;
//using System.Collections.Generic;
using CalcVencimento.Classes;
using System.Globalization;

namespace CalcVencimento
{
    class Program
    {
        static void Main()
        {
            Parcelas[] parcels;
            BarrasLinhas[] barraselinhas;
            BarrasLinhas b = new BarrasLinhas();
            DateTime vencto, vencto2;
            int ano, mes, dia;
            DateTime emis = DateTime.Today;
            DateTime dtBase = new DateTime(1997, 10, 7);
            int nparc, nrInParc, codcli, fator;
            int digbarra, dignnum;
            double vlParc;
            string nrDuplic;
            string[] scan;
            int const1 = 1, const2 = 4;
            string cedt = "3052540", nbanco = "104", moeda = "9";
            string nossnum, strvl, strbarra; string res;


            string menu = "SELECIONE SUA OPÇÃO:\n" +
                "1 - Gerar Parcelas\n" +
                "2 - Gerar Código de Barras\n" +
                "3 - Ver Código de Barras e Linha Digitável\n" +
                "4 - Imprimir Parcelas\n" +
                "5 - Imprimir Barras e Linhas Dig\n" +
                "6 - Sair\n" +
                ":=> ";
            Console.Write(menu);
            int op = int.Parse(Console.ReadLine());

            while (op != 6)
            {
                if (op != 6) { res = "S"; } else { res = "N"; }
                switch (op)
                {
                    case 1:
                        while (res == "S")
                        {
                            Console.WriteLine("GERAR PARCELAS\n");
                            Console.Write("Primeiro Vencimento: ");
                            scan = Console.ReadLine().Split('/');
                            ano = int.Parse(scan[2]);
                            mes = int.Parse(scan[1]);
                            dia = int.Parse(scan[0]);
                            vencto = new DateTime(ano, mes, dia);

                            Console.Write("Informe o número de parcelas: ");
                            nparc = int.Parse(Console.ReadLine());
                            parcels = new Parcelas[nparc];
                            Console.Write("Número Inicial da Parcela: ");
                            nrInParc = int.Parse(Console.ReadLine());
                            Console.Write("Valor das Parcelas: R$ ");
                            vlParc = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                            for (int i = 0; i < nparc; i++)
                            {
                                if (i == 0)
                                {
                                    nrInParc += 0;
                                    nrDuplic = "PP" + nrInParc.ToString("00") + "PP";
                                    vencto2 = vencto.AddMonths(i);
                                    parcels[i] = new Parcelas(nrInParc, nrDuplic, emis, vlParc, vencto2);
                                }
                                else
                                {
                                    nrInParc += 1;
                                    nrDuplic = "PP" + nrInParc.ToString("00") + "PP";
                                    vencto2 = vencto.AddMonths(i);
                                    parcels[i] = new Parcelas(nrInParc, nrDuplic, emis, vlParc, vencto2);
                                }
                            }

                            foreach (object obj in parcels)
                            {
                                Console.WriteLine(obj);
                            }
                            Console.ReadKey();

                            Console.Write("Gerar novas parcelas? ");
                            res = Console.ReadLine().ToUpper();
                            Console.Clear();
                        }
                        break;
                    case 2:
                        while (res == "S")
                        {
                            Console.WriteLine("GERAR BARRAS E LINHAS\n");
                            Console.Write("Primeiro Vencimento: ");
                            scan = Console.ReadLine().Split('/');
                            ano = int.Parse(scan[2]);
                            mes = int.Parse(scan[1]);
                            dia = int.Parse(scan[0]);
                            vencto = new DateTime(ano, mes, dia);


                            Console.Write("Informe o número de parcelas: ");
                            nparc = int.Parse(Console.ReadLine());
                            barraselinhas = new BarrasLinhas[nparc];
                            Console.Write("Número Inicial da Parcela: ");
                            nrInParc = int.Parse(Console.ReadLine());
                            Console.Write("Valor das Parcelas: R$ ");
                            vlParc = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                            strvl = b.VConv(vlParc);
                            Console.Write("Código do cliente: ");
                            codcli = int.Parse(Console.ReadLine());


                            for (int i = 0; i < nparc; i++)
                            {
                                if (i == 0)
                                {
                                    nrInParc += 0;
                                    nossnum = b.NNum(const1, const2, codcli, nrInParc);
                                    dignnum = b.Dig11(cedt, nossnum);
                                    vencto2 = vencto.AddMonths(i);
                                    fator = (vencto2 - dtBase).Days;
                                    strbarra = nbanco + moeda + fator.ToString() + strvl + cedt + nossnum + dignnum;
                                    digbarra = b.Dig11(strbarra);
                                    strbarra = strbarra.Substring(0, 4) + digbarra + strbarra.Substring(4) + dignnum;
                                    barraselinhas[i] = new BarrasLinhas(nbanco, moeda, digbarra.ToString(), fator.ToString(), strvl, cedt, nossnum, dignnum.ToString(), strbarra);
                                }
                                else
                                {
                                    nrInParc += 1;
                                    nossnum = b.NNum(const1, const2, codcli, nrInParc);
                                    dignnum = b.Dig11(cedt, nossnum);
                                    vencto2 = vencto.AddMonths(i);
                                    fator = (vencto2 - dtBase).Days;
                                    strbarra = nbanco + moeda + fator.ToString() + strvl + cedt + nossnum + dignnum;
                                    digbarra = b.Dig11(strbarra);
                                    strbarra = strbarra.Substring(0, 4) + digbarra + strbarra.Substring(4) + dignnum;
                                    barraselinhas[i] = new BarrasLinhas(nbanco, moeda, digbarra.ToString(), fator.ToString(), strvl, cedt, nossnum, dignnum.ToString(), strbarra);
                                }
                            }
                            foreach (object bars in barraselinhas)
                            {
                                Console.WriteLine(bars);
                            }
                            Console.ReadKey();
                            Console.Write("Gerar novos boletos? ");
                            res = Console.ReadLine().ToUpper();
                            Console.Clear();
                        }
                        break;
                    case 3:
                        while (res == "S")
                        {
                            Console.WriteLine("CONFERE DIGITO\n");
                            Console.Write("Informe o número de parcelas: ");
                            nparc = int.Parse(Console.ReadLine());
                            barraselinhas = new BarrasLinhas[nparc];
                            Console.Write("Número Inicial da Parcela: ");
                            nrInParc = int.Parse(Console.ReadLine());
                            Console.Write("Valor das Parcelas: R$ ");
                            vlParc = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                            strvl = b.VConv(vlParc);
                            Console.Write("Código do cliente: ");
                            codcli = int.Parse(Console.ReadLine());
                            for (int i = 0; i < nparc; i++)
                            {
                                nrInParc += 1;
                                nossnum = b.NNum(const1, const2, codcli, nrInParc);
                                dignnum = b.Dig11("104985750000007000305254000010004001899749");//const1, const2, codcli, nrInParc); // cedt, nossnum);
                                //barraselinhas[i] = new BarrasLinhas(nossnum, dignnum.ToString());
                                Console.WriteLine(dignnum);

                            }
                            Console.ReadKey();
                            Console.Write("Novo Teste? ");
                            res = Console.ReadLine().ToUpper();
                            Console.Clear();
                        }
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                }
                Console.Clear();
                Console.Write(menu);
                op = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Finalizando!");
            Console.ReadKey();
        }
    }
}