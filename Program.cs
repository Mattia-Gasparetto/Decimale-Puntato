using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Conversione
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dp = new int[4];
            bool[] bn = new bool[32];
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
            Convert_dp_to_binario(dp);
            

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
            int index = 0;
            foreach (int octet in dp)
            {
                // Converte ciascun ottetto in una rappresentazione binaria a 8 bit.
                string binaryOctet = Convert.ToString(octet, 2).PadLeft(8, '0');

                // Aggiunge ciascun bit dell'ottetto nell'array di booleani.
                foreach (char bitChar in binaryOctet)
                {
                    bn[index] = (bitChar == '1');
                    index++;
                }
            }

            for (int i = 0; i < bn.Length; i++)
            {
                Console.Write(bn[i] ? "1" : "0");
                if (i % 8 == 7 && i != 31)
                {
                    Console.Write(".");
                }
            }
            return null;
        }
    }
    /*
    static int[] Convert_binario_to_decimale_puntato()
    {

    }

    static int[] Convert_dp_to_intero()
    {

    }

    static int[] Convert_binario_to_intero()
    {

    }*/
}
