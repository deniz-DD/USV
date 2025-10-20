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
            }catch(FormatException m)
            {
                Console.WriteLine("Du hast keine Zahl angegben: " + m.Message);
            }
            double[] powerList = new double[number_devices];
            double[] capList= new double[number_devices];


            do
            {
                Console.Write("Bitte geben Sie die Spannung (V = Volt) an: " );
                //power = Convert.ToDouble(Console.ReadLine());   
                S_power = Console.ReadLine();
                if(S_power == ""){ //Standard Wert von 12A
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
            Console.WriteLine(all_power + "V");
            Wirkleistung = all_power * 0.65;
            Gesamtleistung = Wirkleistung * 1.30;
            Console.WriteLine("______________");
            Console.WriteLine("Wirkleistung: " + Wirkleistung);
            Console.WriteLine("______________");
            Console.WriteLine("Gesamtlast: " + Gesamtleistung);
            number_loop = 0;
            do
            {
                Console.Write("Bitte geben Sie die Kapazitaet ihrer Akkus an (Ah): ");
                //power = Convert.ToDouble(Console.ReadLine());   
                S_cap = Console.ReadLine();
                if (S_cap == "")
                { //Standard Wert von 0A
                    number_loop++;
                }
                else if (!double.TryParse(S_cap, out cap))
                {
                    Console.WriteLine("Das ist keine Zahl");

                }
                else
                {
                    capList[number_loop] = cap;
                    all_cap += capList[number_loop];
                    number_loop++;
                }


            } while (number_loop < number_devices);
            Console.WriteLine("______________");
            Console.WriteLine("Gesamtkapazittaet: "+all_cap);

            double time = (number_devices * all_power * all_cap)/ Gesamtleistung;   
            Console.WriteLine(time);

            Console.ReadKey();
        }
    }
}
