using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Cronometro
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Menu();
        }

        // método com menu e entrada do usuário
        static void Menu()
        {
            while (true)
            {
                Console.WriteLine("\t\t\tCRONOMETRO");
                Console.WriteLine("\tUse \"s\" no final do digito para contar segundos.");
                Console.WriteLine("\tUse \"m\" no final do digito para contar minutos.");
                Console.WriteLine("\tex: 45s, 5m");
                Console.WriteLine("\tDigite apenas 0s ou 0m para sair.");

                try
                {
                    string sdigit = Console.ReadLine().ToLower();
                    char type = char.Parse(sdigit.Substring(sdigit.Length - 1, 1));
                    int idigit = int.Parse(sdigit.Substring(0, sdigit.Length - 1));
                    if(idigit == 0)
                    {
                        Console.WriteLine("Volte sempre!");
                        Thread.Sleep(2500);
                        Environment.Exit(0);
                    }

                    Select(idigit, type);

                }
                catch (FormatException)
                {
                    Console.WriteLine("Digito invalido, verifique se o formato esta correto...");
                    Menu();
                }
            }
        }
        // Método que faz a chamada para a contagem convertendo os minutos para segundos caso necessário
        static void Select(int idigit, char type)
        {
            if (type == 's')
            {
                Conte(idigit);
            }
            else if (type == 'm')
            {
                Conte(idigit * 60);
            }
            else
            {
                throw new FormatException();
            }

        }
        // método de contagem
        static void Conte(int idigit)
        {
            for (int ctime = 0; ctime < idigit; ctime++)
            {
                Console.Clear();
                Console.WriteLine($"Contagem em segundos:\t{ctime}");
                Thread.Sleep(1000);
            }
            Console.WriteLine("\t\tContagem finalizada, retornando ao menu...");
            }
    }
}