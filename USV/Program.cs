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
            int number_loop = 0;
            double power;
           
            Console.Write("Bitte geben sie an wie viele Akkus wollen Sie an der USV anschliessen wollen: ");
            try
            {
                 number_devices = Convert.ToInt32(Console.ReadLine());
            }catch(FormatException m)
            {
                Console.WriteLine("Du hast keine Zahl angegben: " + m.Message);
            }
            double[] powerList = new double[number_devices];


            do
            {
                Console.Write("Bitte geben Sie die Spannung (V = Volt) an:" );
                power = Convert.ToDouble(Console.ReadLine());   
                powerList[number_loop] = power; 

                number_loop++;  

            } while (number_loop < number_devices);
            Console.WriteLine();
            for (int i = 0; i < number_devices; i++)
            {
                Console.WriteLine(powerList[i]);
            }
            Console.ReadKey();
        }
    }
}
