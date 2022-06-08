using System;

namespace Lab_1_Sensors
{
    class Program
    {
        static void Main(string[] args)
        {
            int userChoice = -1;
            do
            {
                Console.WriteLine("Select option:");
                Console.WriteLine("1 - Passport method");
                Console.WriteLine("2 - Address method");
                Console.WriteLine("0 - Quit");
                string input = Console.ReadLine();
                if (int.TryParse(input, out userChoice))
                {
                    if (userChoice == 1)
                    {
                        PassportHandler passportHandler = new PassportHandler();
                        passportHandler.CyclicalMethod();
                    }
                    else if (userChoice == 2)
                    {
                        int userSubChoice = -1;
                        do
                        {
                            Console.WriteLine("Select option for address method:");
                            Console.WriteLine("1 - All sensors");
                            Console.WriteLine("2 - Single sensor");
                            Console.WriteLine("9 - To main menu");
                            Console.WriteLine("0 - Quit");
                            string subInput = Console.ReadLine();
                            if (int.TryParse(subInput, out userSubChoice))
                            {
                                if (userSubChoice == 1)
                                {
                                    int userTime = -1;
                                    do
                                    {
                                        Console.WriteLine("Input time in seconds:");
                                        string userTimeInput = Console.ReadLine();
                                        if (int.TryParse(userTimeInput, out userTime))
                                        {
                                            if(userTime > 0)
                                            {
                                                CharacteristicHandler characteristicHandler = new CharacteristicHandler();
                                                characteristicHandler.AddressMethod(userTime);
                                            }
                                        }
                                        else
                                        {
                                            userTime = -1;
                                        }
                                    }
                                    while (userTime != 0);
                                }
                                else if (userSubChoice == 2)
                                {
                                    int userSensor = -1;
                                    do
                                    {
                                        Console.WriteLine("Input sensor index (from 0 to 4):");
                                        string userSensorInput = Console.ReadLine();
                                        if (int.TryParse(userSensorInput, out userSensor))
                                        {
                                            if (userSensor >= 0 && userSensor <= 4)
                                            {
                                                CharacteristicHandler characteristicHandler = new CharacteristicHandler();
                                                characteristicHandler.RequestSingleSensor(userSensor);
                                            }
                                        }
                                        else
                                        {
                                            userSensor = -1;
                                        }
                                    }
                                    while (userSensor != -1);
                                }
                                else if (userSubChoice == 9)
                                {
                                    break;
                                }
                                else if (userSubChoice == 0)
                                {
                                    return;
                                }
                            }
                            else
                            {
                                userSubChoice = -1;
                            }
                        }
                        while (userSubChoice != 0);
                    }
                }
                else
                {
                    userChoice = -1;
                }
            }
            while (userChoice != 0);
        }
    }
}
