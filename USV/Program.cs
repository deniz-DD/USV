using System;

namespace USV
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Task2();



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
        static void Task2()
        {
            int number_devices = 1;
            int number_loop = 1;
            string S_type = "W";
            string S_number_devices;
            string S_power;
            string S_cap;
            double power;
            double all_powerW = 0;
            double all_powerVA = 0;
            double all_powerA = 0;
            double cap;
            double all_cap = 0;
            double Wirkleistung = 0;
            double Scheinleistung = 0;

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
                Console.Write("Bitte geben Sie an welche Leistungsaufnahmne an ihrem Geraete steht (W (Standard), VA, A, ): ");
                
                S_type = Console.ReadLine();
                if(S_type  == "VA" || S_type == "va"  || S_type == "vA" || S_type == "Va"
                    S_type == "" || S_type == "va" || S_type == "vA" || S_type == "Va")

                Console.Write("Bitte geben Sie die Leistungsaufnahmen {0} an: ", S_type);
                
                S_power = Console.ReadLine();

                if (!double.TryParse(S_power, out power))
                {
                    do
                    {
                        Console.Write("Bitte geben Sie die Leistungsaufnahmen {0} an: ", S_type);
                        S_power = Console.ReadLine();

                        if (S_power == null)
                        {
                            power = 12;  //Standard
                            if (S_type == "VA") { all_powerVA += power; }
                            else if (S_type == "W") { all_powerW += power; }
                            else if (S_type == "A") { all_powerA += power; }
                        }
                        else
                        {
                            power = Convert.ToDouble(S_power);
                            if (S_type == "VA") { all_powerVA += power; }
                            else if (S_type == "W") { all_powerW += power; }
                            else if (S_type == "A") { all_powerA += power; }
                        }
                    } while (!double.TryParse(S_power, out power));
                }
                else
                {
                    if (S_power == "")
                    {
                        power = 12;  //Standard
                        if (S_type == "VA") { all_powerVA += power; }
                        else if (S_type == "W") { all_powerW += power; }
                        else if (S_type == "A") { all_powerA += power; }
                    }
                    else
                    {
                        power = Convert.ToDouble(S_power);
                        if (S_type == "VA") { all_powerVA += power; }
                        else if (S_type == "W") { all_powerW += power; }
                        else if (S_type == "A") { all_powerA += power; }
                    }
                }
                number_loop++;
            } while (number_loop <= number_devices);


            //Umrechnung von A nach Va
            all_powerVA += all_powerA * 230;
            //Umrechnung von W in VA 
            Scheinleistung = all_powerVA + all_powerW * 1.55;
            //Umrechnung von VA in Watt
            Wirkleistung = all_powerW + all_powerVA * 0.65 * 1.30;

            Console.WriteLine("__________________");
            Console.WriteLine("Scheinleistung: {0} VA", Scheinleistung);
            Console.WriteLine("__________________");
            Console.WriteLine("Wirkleistung: {0} W", Wirkleistung);
        }
    }
}
