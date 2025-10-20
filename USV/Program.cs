using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USV
{
    internal class Program
    {
        static void Main(string[] args)

        {
            int number_devices = 1;
            int number_loop = 1;
            Console.Write("Bitte geben sie an wie viele Geraete Sie an der USV anschliessen wollen: ");
            try
            {
                 number_devices = Convert.ToInt32(Console.ReadLine());
            }catch(FormatException m)
            {
                Console.WriteLine("Du hast keine Zahl angegben: " + m.Message);
            }



            do
            {
                Console.WriteLine(number_loop);

                number_loop++;  

            } while (number_loop <= number_devices);
            Console.ReadKey();
        }
    }
}
