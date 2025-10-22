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
            string S_type = "VA";
            string S_number_devices;
            string S_power;
            string S_cap;
            double power;
            double cap;
            double all_power = 0; //Scheinleistung 
            double all_cap = 0;
            //Abfrage der Akkus 
            Console.Write("Bitte geben sie an wie viele Akkus wollen Sie an der USV anschliessen wollen: ");
            S_number_devices = Console.ReadLine();

            if (!int.TryParse(S_number_devices, out number_devices))
            {
                do
                {
                    Console.Clear();
                    Console.Write("Bitte geben sie an wie viele Akkus wollen Sie an der USV anschliessen wollen: ");
                    S_number_devices = Console.ReadLine();

                } while (!int.TryParse(S_number_devices, out number_devices));
            }
            double[] powerList = new double[number_devices];

            do
            {

                Console.WriteLine("-----" + "Akku " + number_loop + "-----");
                Console.Write("Bitte geben Sie an welche Leistungsaufnahmne an ihrem Geraete steht (W, VA(Standard), A, )");
                S_type = Console.ReadLine();
                do
                {
                    if(S_type == "VA")
                    {
                        Console.WriteLine("VA");
                    }else if (S_type == "W")
                    {
                        Console.WriteLine("W");

                    }else if (S_type == "A")
                    {
                        Console.WriteLine("A");
                    }
         
                } while (double.TryParse(S_type, out double type));

            } while (number_loop <= number_devices);




            //Leistungsabfrage



            Console.ReadKey();
        }
        static void USV_Task1()
        {
            int number_devices = 1;
            int number_loop = 1;
            string S_number_devices;
            string S_power;
            string S_cap;
            double power;
            double cap;
            double all_power = 0; //Scheinleistung 
            double all_cap = 0;
            double Wirkleistung = 0;
            double Gesamtleistung = 0;

            Console.Write("Bitte geben sie an wie viele Akkus wollen Sie an der USV anschliessen wollen: ");
            S_number_devices = Console.ReadLine();

            if (!int.TryParse(S_number_devices, out number_devices))
            {
                do
                {
                    Console.Clear();
                    Console.Write("Bitte geben sie an wie viele Akkus wollen Sie an der USV anschliessen wollen: ");
                    S_number_devices = Console.ReadLine();

                } while (!int.TryParse(S_number_devices, out number_devices));
            }

            double[] powerList = new double[number_devices];
            double[] capList = new double[number_devices];
            do
            {

                Console.WriteLine("-----" + "Akku " + number_loop + "-----");
                Console.Write("Bitte geben Sie die Spannung (VA = Volt * Ampere) an: ");
                S_power = Console.ReadLine();

                if (S_power == "")
                { //Standard Wert von 12VA
                    power = 12;
                    powerList[number_loop] = power;
                    all_power += powerList[number_loop];

                }
                else if (!double.TryParse(S_power, out power))
                {
                    do
                    {
                        Console.Write("Bitte geben Sie die Spannung (VA = Volt * Ampere) an: ");
                        S_power = Console.ReadLine();
                        if (S_power == "")
                        { //Standard Wert von 12VA
                            power = 12;
                            powerList[number_loop - 1] = power;
                            all_power += powerList[number_loop];

                        }
                        else
                        {
                            powerList[number_loop - 1] = power;
                            all_power += powerList[number_loop - 1];
                        }
                    } while (!double.TryParse(S_power, out power));
                    Console.WriteLine("Weiter");
                }
                else
                {
                    powerList[number_loop - 1] = power;
                    all_power += powerList[number_loop - 1];
                }
                //Kapazitaet abfragen
                Console.Write("Bitte geben Sie die Kapazitaet (Ah) an: ");
                S_cap = Console.ReadLine();
                if (S_cap == "")
                { //Standard Wert von 1Ah

                    number_loop++;
                }
                else if (!double.TryParse(S_cap, out cap))
                {
                    do
                    {
                        Console.Write("Bitte geben Sie die Kapazitaet (Ah) an: ");
                        S_cap = Console.ReadLine();
                        if (S_cap == "")
                        {
                            cap = 1;
                            capList[number_loop - 1] = cap;
                            number_loop++;

                        }
                        else
                        {
                            capList[number_loop - 1] = cap;
                            all_cap += capList[number_loop - 1];
                            number_loop++;
                        }

                    } while (!double.TryParse(S_cap, out cap));
                    Console.WriteLine("Weiter");
                }
                else
                {
                    capList[number_loop - 1] = cap;
                    all_cap += capList[number_loop - 1];
                    number_loop++;
                }


            } while (number_loop <= number_devices);

            //Aus der Scheinleistung muss erst die Wirkleistung 
            Wirkleistung = all_power * 0.65;
            Gesamtleistung = Wirkleistung * 1.30;
            Gesamtleistung = Gesamtleistung * 1.55;
            Console.WriteLine("______________");
            Console.WriteLine("Wirkleistung: " + Wirkleistung);
            Console.WriteLine("______________");
            Console.WriteLine("Gesamtlast: " + Gesamtleistung + " VA");

            //Bestimmung von Volt der Akkus 
            double all_volt = Wirkleistung / all_cap;
            Console.WriteLine("______________");
            Console.WriteLine("Volt: " + all_volt);

            // Bestimmug der Zeit

            double time = (number_devices * all_volt * all_cap) / Gesamtleistung;
            Console.WriteLine("______________");
            Console.WriteLine("Zeit: " + time);

        }

        
    }
}
