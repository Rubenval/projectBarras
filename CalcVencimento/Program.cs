using System;
using System.Collections.Generic;
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
            DateTime vencto;
            int ano, mes, dia;
            DateTime vencto2;
            DateTime emis = DateTime.Today;
            DateTime dtBase = new DateTime(1997, 7, 17);
            int nparc, nrInParc, fator;
            int digbarra, dignnum;
            double vlParc;
            string nrDuplic;
            string[] scan;
            int const1 = 1, const2 = 4;
            string cedt = "3052540", nbanco = "104", moeda = "9";


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
                switch (op)
                {
                    case 1:
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
                                fator = (vencto2 - dtBase).Days;
                                parcels[i] = new Parcelas(nrInParc, nrDuplic, emis, vlParc, vencto2, fator);
                            }
                            else
                            {
                                nrInParc += 1;
                                nrDuplic = "PP" + nrInParc.ToString("00") + "PP";
                                vencto2 = vencto.AddMonths(i);
                                fator = (vencto2 - dtBase).Days;
                                parcels[i] = new Parcelas(nrInParc, nrDuplic, emis, vlParc, vencto2, fator);
                            }
                        }

                        foreach (object obj in parcels)
                        {
                            Console.WriteLine(obj);
                        }
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("GERAR BARRAS E LINHAS\n");
                        Console.Write("Primeiro Vencimento: ");
                        scan = Console.ReadLine().Split('/');
                        ano = int.Parse(scan[2]);
                        mes = int.Parse(scan[1]);
                        dia = int.Parse(scan[0]);
                        vencto = new DateTime(ano, mes, dia);
                        string nossnum;

                        Console.Write("Informe o número de parcelas: ");
                        nparc = int.Parse(Console.ReadLine());
                        barraselinhas = new BarrasLinhas[nparc];
                        Console.Write("Número Inicial da Parcela: ");
                        nrInParc = int.Parse(Console.ReadLine());
                        Console.Write("Valor das Parcelas: R$ ");
                        vlParc = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        string strvl = b.VConv(vlParc);
                        Console.Write("Código do cliente: ");
                        int codcli = int.Parse(Console.ReadLine());


                        for (int i = 0; i < nparc; i++)
                        {
                            if (i == 0)
                            {
                                nrInParc += 0;
                                nossnum = b.NNum(const1,const2, codcli,nrInParc);
                                dignnum = b.Dig11(cedt, nossnum);
                                digbarra = b.Dig11(cedt + nossnum);
                                vencto2 = vencto.AddMonths(i);
                                fator = (vencto2 - dtBase).Days;
                                barraselinhas[i] = new BarrasLinhas(nbanco, moeda, digbarra.ToString(), fator.ToString(), strvl, cedt, nossnum, dignnum.ToString());
                            }
                            else
                            {
                                nrInParc += 1;
                                nossnum = b.NNum(const1, const2, codcli, nrInParc);
                                dignnum = b.Dig11(cedt, nossnum);
                                Console.WriteLine("->> " + cedt + nossnum);
                                digbarra = b.Dig11(cedt + nossnum);
                                vencto2 = vencto.AddMonths(i);
                                fator = (vencto2 - dtBase).Days;
                                barraselinhas[i] = new BarrasLinhas(nbanco, moeda, digbarra.ToString(), fator.ToString(), strvl, cedt, nossnum, dignnum.ToString());
                            }
                            //Console.WriteLine(barraselinhas[i].ToString());
                        }
                        foreach (object bars in barraselinhas)
                        {
                            Console.WriteLine(bars);
                        }
                        Console.ReadKey();
                        break;
                    case 3:
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
