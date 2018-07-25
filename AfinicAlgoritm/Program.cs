using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfinicAlgoritm
{
    class Program
    {
        static void Main(string[] args)
        {
            int control = -1;
            do
            {
                Console.WriteLine("Co chcesz zrobić: \n 1) Szyfrowanie \n 2) Deszyfrowanie \n 0) Wyjście");
                control = Int32.Parse(Console.ReadLine());
                if (control==1)
                {
                    Data data = DataOperations.DataInit();
                    DataOperations.ShowEncriptedData(data);
                }
                if (control == 2)
                {
                    Data data = DataOperations.DataInitDecription();
                    if (DataOperations.CheckIsInvertAble(data).IsInvertAble)
                    {
                        DataOperations.Decription(data);
                        DataOperations.ShowDecription(data);
                    }
                    else
                    {
                        Console.WriteLine("\nNie istnieje odwrotna moda, zmień dane\n");
                    }
                }
                if (control!=1&& control != 2 && control != 0)
                {
                    Console.WriteLine("Podane dane są nieprawidłowe");
                }
            } while (control!=0);
        }

        
    }
}
