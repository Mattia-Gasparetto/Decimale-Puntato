using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Conversione
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dp = new int[4];
            LeggiIp(out dp);
            Console.WriteLine("L'indirizzo IP in decimale puntato inserito è: ");
            for (int i = 0; i < dp.Length; i++)
            {
                if (i < 3)
                {
                    Console.Write(dp[i] + ".");
                }
                else
                {
                    Console.Write(dp[i]);
                }
            }

            Console.WriteLine("\nL'indirizzo IP in decimale puntato convertito in binario è: ");
            bool[] bn = Convert_dp_to_binario(dp);
            for (int i = 0; i < bn.Length; i++)
            {
                Convert.ToInt32(bn[i]);
                if (i == 7 || i == 15 || i == 23)
                {
                    Console.Write(Convert.ToInt32(bn[i]) + ".");
                }
                else
                {
                    Console.Write(Convert.ToInt32(bn[i]));
                }
            }
            int[] decimalePuntato = Convert_binario_to_decimale_puntato(bn);
            Console.WriteLine("\nL'indirizzo IP in binario convertito in decimale puntato è: ");
            for (int i = 0; i < decimalePuntato.Length; i++)
            {
                if (i < 3)
                {
                    Console.Write(decimalePuntato[i] + ".");
                }
                else
                {
                    Console.Write(decimalePuntato[i]);
                }
            }
            Console.WriteLine("\nL'indirizzo IP in decimale puntato convertito in decimale è: ");
            Console.Write(Convert_dp_to_intero(dp));
            Console.WriteLine("\nL'indirizzo IP in binario convertito in decimale è: ");
            Console.Write(Convert_binario_to_intero(bn));
            Console.ReadLine();
        }
        static void LeggiIp(out int[] dp)
        {
            int otteto;
            bool valido;
            dp = new int[4];
            for (int i = 0; i < dp.Length; i++)
            {
                do
                {
                    Console.WriteLine($"Inserisci il {i + 1}° otteto: ");
                    valido = int.TryParse(Console.ReadLine(), out otteto);
                    if (!valido || (otteto < 0 || otteto > 255))
                    {
                        Console.WriteLine("Errore, hai inserito un otteto sbagliato");
                    }
                } while (!valido || (otteto < 0 || otteto > 255));

                dp[i] += otteto;
            }
        }

        static bool[] Convert_dp_to_binario(int[] dp)
        {
            bool[] bn = new bool[32];
            int cont = bn.Length - 1;
            int numeroBinario;
            int bit = 8;
            for (int i = 0; i < dp.Length; i++)
            {
                numeroBinario = dp[i];
                for (int j = 0; j < bit; j++)
                {
                    bn[cont] = numeroBinario % 2 == 1; //verifica se il bit è uguale 1 o 0 in base a questo assegnerà all'array di bool true o false
                    numeroBinario = numeroBinario / 2;
                    cont--;
                }
            }
            return bn;
        }
        static int[] Convert_binario_to_decimale_puntato(bool[] bn)
        {
            int[] decimalePuntato = new int[4];
            for (int i = 0; i < decimalePuntato.Length; i++) //il contatore i rappresenta l'otteto in cui siamo
            {
                int decimale = 0;
                for (int j = 0; j < 8; j++) //il contatore j serve per vedere in che posizione si trova all'interno dell'otteto
                {
                    int posizione = i * 8 + j; //i rappresenta quale otteto stiamo analizzando poi gli si moltiplica il numero di bit e gli si aggiunge la posizione in cui si trova il bit all'interno dell'otteto
                    if (bn[posizione]) //condizione per verificare se il bit è 0 oppure 1, se il bit è 1 si converte sennò viene ignorato
                    {
                        decimale += (int)Math.Pow(2, 7 - j);
                    }
                }
                decimalePuntato[i] = decimale;
            }
            return decimalePuntato;
            
        }
        static int Convert_dp_to_intero(int[] dp)
        {
            int intero = 0;
            for (int i = 0; i < dp.Length; i++)
            {
                intero += dp[i] * (int)Math.Pow(256, 3 -i);
            }
            return intero;
        }
        static int Convert_binario_to_intero(bool[] bn)
        {
            int intero = 0;
            for (int i = bn.Length - 1; i >= 0; i--)
            {
                if (bn[i] == true)
                {
                    intero += Convert.ToInt32(bn[i]) * (int)Math.Pow(2, bn.Length - 1 - i);
                }
            }
            return intero;
        }
    }
}
