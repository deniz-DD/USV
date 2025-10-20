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
            string S_power;
            double power;
            double all_power = 0;
           
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
                Console.Write("Bitte geben Sie die Spannung (V = Volt) an: " );
                //power = Convert.ToDouble(Console.ReadLine());   
                S_power = Console.ReadLine();
                if(S_power == ""){
                    power = 12;
                    powerList[number_loop] = power;
                    all_power += powerList[number_loop];
                    number_loop++;
                }
                else if (!double.TryParse(S_power, out power))
                {
                    Console.WriteLine("Das ist keine Zahl");
                   
                }
                else
                {
                    powerList[number_loop] = power;
                    all_power += powerList[number_loop];
                    number_loop++;
                }

                

                

            } while (number_loop < number_devices);
            Console.WriteLine(all_power);    
          
            Console.ReadKey();
        }
    }
}
