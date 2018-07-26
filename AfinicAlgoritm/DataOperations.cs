using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfinicAlgoritm
{
    class DataOperations
    {
        internal static Data DataInit()
        {
            Data data = new Data();
            Console.WriteLine("Podaj pierwszy czynnik:");
            data.FirstFactor = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj drugi czynnik:");
            data.SecondFactor = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj słowo do zaszyfrowania:");
            data.KeyWord = Console.ReadLine();
            Console.WriteLine("Podaj mode:");
            data.Mod = int.Parse(Console.ReadLine());
            return (data);
        }

        internal static Data DataInitDecription()
        {
            Data data = new Data();
            Console.WriteLine("Podaj pierwszy czynnik:");
            data.FirstFactor = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj drugi czynnik:");
            data.SecondFactor = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj słowo do odszyfrowania:");
            data.KeyWord = Console.ReadLine();
            Console.WriteLine("Podaj mode:");
            data.Mod = int.Parse(Console.ReadLine());
            return (data);
        }

        private static Data KeyWordToCharTab(Data data)
        {
            data.KeyWord = data.KeyWord.ToUpper();
            data.CharTab = new char[data.KeyWord.Length];
            data.CharTab = data.KeyWord.ToCharArray();

            return data;
        }

        private static Data CharTabToNumericRepresentation(Data data)
        {
            data.IntAlphabet = new int[data.CharTab.Length];

            for (int i = 0; i < data.CharTab.Length; i++)
            {
                data.IntAlphabet[i] = ((int)data.CharTab[i]) - 65;
            }

            return data;
        }

        private static Data Transcription(Data data)
        {
            data.TransIntAlphabet = new int[data.IntAlphabet.Length];

            for (int i = 0; i < data.IntAlphabet.Length; i++)
            {
                data.TransIntAlphabet[i] = (data.FirstFactor * data.IntAlphabet[i]+ data.SecondFactor) % data.Mod;
            }
            return data;
        }

        private static Data TransIntToChar(Data data)
        {
            data.TransChar = new char[data.TransIntAlphabet.Length];

            for (int i = 0; i < data.TransIntAlphabet.Length; i++)
            {
                data.TransChar[i] = (char)(data.TransIntAlphabet[i] + 65);
            }

            return data;
        }

        private static void TransEnding(Data data)
        {
            Console.WriteLine("\n Po zaszyfrowaniu");
            Console.WriteLine(data.TransChar);
        }

        internal static void ShowEncriptedData(Data data)
        {
            data = KeyWordToCharTab(data);
            data = CharTabToNumericRepresentation(data);
            data = Transcription(data);
            data = TransIntToChar(data);
            TransEnding(data);
        }

        internal static Data Encription(Data data)
        {
            data = KeyWordToCharTab(data);
            data = CharTabToNumericRepresentation(data);
            data = Transcription(data);
            data = TransIntToChar(data);
            return data;
        }

        private static Data FindInvertMod(Data data)
        {
            data.InvertMod = -1;
            for (int i = 1; i < data.Mod + 1; i++)
            {
                if ((i * data.FirstFactor) % data.Mod == 1)
                {
                    data.InvertMod = i;
                }
            }
            return data;
        }

        internal static Data CheckIsInvertAble(Data data)
        {
            data.IsInvertAble = (data.InvertMod == -1);
            return data;
        }

        private static Data ReverseTranscription(Data data)
        {
            data.TransIntAlphabet = new int[data.IntAlphabet.Length];

            for (int i = 0; i < data.IntAlphabet.Length; i++)
            {
                int temp = data.InvertMod * (data.IntAlphabet[i] - data.SecondFactor);
                data.TransIntAlphabet[i] = temp % data.Mod<0? (temp % data.Mod)+data.Mod: temp % data.Mod;
            }

            return data;
        }

        internal static Data Decription(Data data)
        {
            data = FindInvertMod(data);
            data = KeyWordToCharTab(data);
            data = CharTabToNumericRepresentation(data);
            data = ReverseTranscription(data);
            data = TransIntToChar(data);
            return data;
        }

        internal static void ShowDecriptedData(Data data)
        {
            data = FindInvertMod(data);
            data = KeyWordToCharTab(data);
            data = CharTabToNumericRepresentation(data);
            data = ReverseTranscription(data);
            data = TransIntToChar(data);
            EndDecription(data);
        }

        private static void EndDecription(Data data)
        {
            Console.WriteLine("Wiadomość po odszyfrowaniu");
            Console.WriteLine(data.CharTab);
        }
    }
}
