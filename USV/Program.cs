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
            string S_power;
            string S_cap;
            double power;
            double cap;
            double all_power = 0;
            double all_cap = 0;
            double Wirkleistung = 0;
            double Gesamtleistung = 0;

            Console.Write("Bitte geben sie an wie viele Akkus wollen Sie an der USV anschliessen wollen: ");
            try
            {
                number_devices = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException m)
            {
                Console.WriteLine("Du hast keine Zahl angegben: " + m.Message);

            }
            double[] powerList = new double[number_devices];
            double[] capList = new double[number_devices];
            do
            {

                Console.WriteLine("-----" + "Akku " + number_loop + "-----");
                Console.Write("Bitte geben Sie die Spannung (VA = Volt * Ampere) an: ");
                S_power = Console.ReadLine();
                if (S_power == "")
                { //Standard Wert von 12V
                    power = 12;
                    powerList[number_loop] = power;
                    all_power += powerList[number_loop];
                   
                }
                else if (!double.TryParse(S_power, out power))
                {
                    Console.WriteLine("Das ist keine Zahl");

                }
                else
                {
                    powerList[number_loop-1] = power;
                    all_power += powerList[number_loop-1];
                }
                //Kapazitaet abfragen
                Console.Write("Bitte geben Sie die Kapazitaet (Ah) an: ");
                S_cap = Console.ReadLine();
                if (S_cap == "")
                { //Standard Wert von 1A
                    number_loop++;
                }
                else if (!double.TryParse(S_cap, out cap))
                {
                    Console.WriteLine("Das ist keine Zahl");

                }
                else
                {
                    capList[number_loop - 1] = cap;
                    all_cap += capList[number_loop - 1];
                    number_loop++;
                }


            } while (number_loop <= number_devices);

            for(int i = 0; i < number_loop-1; i++)
            {
                Console.Write(powerList[i] + " ");

            }
            for (int i = 0; i < number_loop-1; i++)
            {
                Console.Write(capList[i] + " ");

            }




            Console.ReadKey();
        }

        
    }
}
