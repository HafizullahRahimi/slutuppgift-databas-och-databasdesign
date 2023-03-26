using Business;

namespace ConsoleApp
{

    internal static class Menu
    {
        public static bool Show()
        {
            //Console.Clear();
            //Console.WriteLine("Welcome to Prague parking!\n");

            Titel("Welcome to Prague parking!");

            Console.WriteLine("Choose an option:");

            Console.WriteLine("1) Park new vehicle");
            Console.WriteLine("2) Delivery of vehicle");
            Console.WriteLine("3) Move a vehicle");
            Console.WriteLine("4) Find a vehicle");
            Console.WriteLine("5) Parkring places info");

            Console.WriteLine("6) Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    PartPark();
                    return true;
                case "2":
                    PartDelivery();
                    return true;
                case "3":
                    PartMove();
                    return true;
                case "4":
                    PartFind();
                    return true;

                case "5":
                    PartInfo();
                    return true;

                case "6":
                    return false;
                default:
                    return true;
            }
        }

        private static void PartPark()
        {
            //Console.Clear();
            //Console.WriteLine("Park New Vehicle \n");
            Titel("Park New Vehicle");

            Parking parking = new Parking();

            parking.ParkNewVehicle();


            BackToMenu();
        }

        private static void PartDelivery()
        {
            Console.Clear();
            Console.WriteLine("Parking Delivery \n");

            Parking p = new Parking();

            p.DeliveryOfVehicle();

            BackToMenu();
        }

        private static void PartMove()
        {

            Titel("Move a vehicle");

            Parking p = new Parking();

            p.MoveVehicle();

            BackToMenu();
        }

        private static void PartFind()
        {
            Console.Clear();
            Console.WriteLine("Find a vehicle \n");

            Parking p = new Parking();

            p.FindVehicle();


            BackToMenu();
        }
        private static void PartInfo()
        {
            Console.Clear();
            Console.WriteLine("Parking Places \n");

            Parking parking = new Parking();

            parking.ShowContentOfParkingPlaces();

            BackToMenu();
        }

        private static void BackToMenu()
        {
            Console.Write("\r\nPress Enter to go to menu ");
            Console.ReadLine();
        }

        private static void Titel(string titel)
        {
            Console.Clear();
            Console.WriteLine(titel);
            Parking p = new Parking();
            Console.WriteLine("Empty places:\n Car: {0}, MotorC: {1}\n", p.CuontEmptyPlaceForCar, p.CuontEmptyPlaceForMC);
        }
    }
}
