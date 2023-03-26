using DataAccess;
using ViewModels;

namespace Business
{
    public class Parking
    {
        #region Fiels

        private Database db = new Database();

        #endregion

        #region Properies
        public int CuontEmptyPlaceForCar
        {
            get { return CuontEmptyPlace("Car"); }
        }
        public int CuontEmptyPlaceForMC
        {
            get { return CuontEmptyPlace("MC"); }
        }

        #endregion

        #region Private Methods

        private int CuontEmptyPlace(string vType)
        {
            var list = db.ParkingPlacePartRepository.GetListFreePlaces(vType);
            int count = list.Count;
            return count;
        }

        #endregion


        #region Methods

        public void ParkNewVehicle()
        {
            bool nPlateInportSuccessful = true;
            bool vTypeInportSuccessful = true;

            while (nPlateInportSuccessful)
            {
                Console.Write("Enter NumberPlate: ");
                string numberPlate = Console.ReadLine();
                db.VehicleRepository.NumberPlate = numberPlate.ToUpper();
                bool haveVehicleID = db.VehicleRepository.HaveVehicleID();

                //Console.WriteLine(haveVehicleID);
                if (haveVehicleID)
                {
                    Console.WriteLine("We have NumberPlate: {0}", db.VehicleRepository.NumberPlate);
                }
                else
                {
                    nPlateInportSuccessful = false;
                }
            }

            while (vTypeInportSuccessful)
            {
                Console.Write("Enter VehicleType (1: Car, 2: MC): ");
                string vehicleType = Console.ReadLine();


                if (vehicleType == "2" || vehicleType == "1")
                {
                    db.VehicleRepository.VehicleTypeID = vehicleType;
                    vTypeInportSuccessful = false;
                }

            }

            Console.Write("Enter FullName: ");
            string fullName = Console.ReadLine();
            db.VehicleRepository.DriverFullName = fullName;

            bool insertedVehicle = db.VehicleRepository.Insert();

            if (insertedVehicle)
            {
                db.VehicleRepository.SetVehicleID();
                int newVehicleID = db.VehicleRepository.VehicleID;

                db.ParkingBillRepository.VehicleID = newVehicleID;
                db.ParkingBillRepository.ArrivalDate = DateTime.Now;
                bool insertedParkingBill = db.ParkingBillRepository.Insert();

                if (insertedParkingBill)
                {

                    db.ParkingBillRepository.GetLastRegNumber();

                    db.ParkingPlacePartRepository.RegNumber = db.ParkingBillRepository.RegNumber;
                    db.ParkingPlacePartRepository.AddRegNumber();
                    Console.WriteLine("---------------------------");
                    Console.WriteLine((db.VehicleRepository.VehicleTypeID == "1") ? "Car:" : "MotorC:");
                    Console.WriteLine("  NumberPlate: {0}", db.VehicleRepository.NumberPlate);
                    Console.WriteLine("  Driver fullname: {0}", db.VehicleRepository.DriverFullName);
                    Console.WriteLine("  RegNumber: {0}", db.ParkingPlacePartRepository.RegNumber);
                    Console.WriteLine("Parked!!");
                    Console.WriteLine("---------------------------");
                }
                else Console.WriteLine("Insert to ParkingBil Erorr");
            }
            else
            {
                Console.WriteLine("Insert to Vehicle Error");
            }

        }
        public void DeliveryOfVehicle()
        {
            int regNumber = 0;
            bool regNumberInportSuccessful = false;

            while (!regNumberInportSuccessful)
            {
                //Inport RegNumber
                Console.Write("Enter your regNumber: ");
                regNumber = int.Parse(Console.ReadLine());

                //Check to have RegNumber
                db.ParkingPlacePartRepository.RegNumber = regNumber;
                bool haveRegNumber = db.ParkingPlacePartRepository.HaveRegNumber();

                //If have Regnumber
                if (haveRegNumber) regNumberInportSuccessful = true;
                else Console.WriteLine("Have not RegNumber {0}", regNumber);

            }

            if (regNumberInportSuccessful)
            {
                bool Deleted = db.ParkingPlacePartRepository.DeleteRegNumber();

                if (Deleted)
                {
                    GetBill(regNumber, db);
                }
                else Console.WriteLine(" SERVER: Erorrr delete!!!!!!");
            }
        }
        public void MoveVehicle()
        {
            bool regNumberInportSuccessful = false;

            //Inport RegNumber
            while (!regNumberInportSuccessful)
            {
                //Inport RegNumber
                Console.Write("Enter your regNumber: ");
                int regNumber = int.Parse(Console.ReadLine());

                //Check to have RegNumber
                db.ParkingPlacePartRepository.RegNumber = regNumber;
                bool haveRegNumber = db.ParkingPlacePartRepository.HaveRegNumber();


                if (haveRegNumber) //If have Regnumber
                {
                    regNumberInportSuccessful = true;
                    db.ParkingPlacePartRepository.RegNumber = regNumber; //SET RegNumber

                }
                else
                {
                    Console.WriteLine("Have not RegNumber {0}", regNumber);
                    regNumberInportSuccessful = false;
                }
            }

            //SET VehicleType
            db.ParkingPlacePartRepository.SetVehicleType();
            string vehicleType = db.ParkingPlacePartRepository.VehicleType; //GET vehicleType

            Console.WriteLine("vehicleType: {0}", vehicleType);

            //vehicleType: Car
            if (vehicleType == "Car")
            {
                int placeID = 0;
                bool placeIDInportSuccessful = false;


                var freePlaces = db.ParkingPlacePartRepository.GetListFreePlaces(vehicleType);
                int countFreePlaces = freePlaces.Count;

                if (countFreePlaces < 1) Console.WriteLine("Have not Free Place for Moving Car!!");
                else
                {
                    while (!placeIDInportSuccessful)
                    {
                        //Show free places
                        Console.Write("Free place numbers for car: ");
                        foreach (var item in freePlaces)
                        {
                            Console.Write("{0} ", item);
                        }
                        Console.WriteLine();

                        //Inport placeID
                        Console.Write("Enter place number: ");
                        placeID = int.Parse(Console.ReadLine());

                        //Check to place is true
                        bool isPlaceTrue = false;
                        foreach (var item in freePlaces)
                        {
                            if (item == placeID)
                            {
                                isPlaceTrue = true;
                            }
                        }

                        if (isPlaceTrue) placeIDInportSuccessful = true;
                        else Console.WriteLine("Palce number is FALSE: {0}", placeID);

                    }

                    //Console.WriteLine("Part: isPlaceTrue, RegNumber:{0}", db.ParkingPlacePartRepository.RegNumber);

                    db.ParkingPlacePartRepository.ParkingPlaceID = placeID; //SET placeID
                    db.ParkingPlacePartRepository.DeleteRegNumber();
                    bool moved = db.ParkingPlacePartRepository.MoveRegNumber();

                    if (moved)
                    {
                        Console.WriteLine("----------------------------");
                        Console.WriteLine("Car moved to:");
                        Console.WriteLine("    Palce: {0}", placeID);
                        Console.WriteLine("----------------------------");

                    }
                    else Console.WriteLine("Error MoveRegNumber() ");

                }

            }
            else //vehicleType: MotorC
            {
                int placeID = 0;
                int partID = 0;
                bool placeIDInportSuccessful = false;
                bool partIDInportSuccessful = false;

                var freePlaces = db.ParkingPlacePartRepository.GetListFreePlaceParts();
                int countFreePlaces = freePlaces.Count;


                Console.WriteLine("countFreePlaces: {0}", countFreePlaces);

                if (countFreePlaces < 1) Console.WriteLine("Have not Free Place for Moving MotorC!!");
                else
                {
                    //Show List free places
                    Console.Write("\nFree places for motorC: ");
                    int place = 0;
                    foreach (var item in freePlaces)
                    {
                        if (item.PlaceID != place)
                        {
                            Console.WriteLine("\nPlace {0} ", item.PlaceID);
                            place = item.PlaceID;
                        }
                        Console.WriteLine("  Part: {0}", item.PartID);
                    }
                    Console.WriteLine();

                    //Inport PlaceID
                    while (!placeIDInportSuccessful)
                    {
                        //Inport PlaceID
                        Console.Write("Enter place number: ");
                        placeID = int.Parse(Console.ReadLine());

                        //Check to PlaceID is true
                        bool isPlaceTrue = false;
                        int cuontPart = 0;
                        foreach (var item in freePlaces)
                        {
                            if (item.PlaceID == placeID)
                            {
                                cuontPart++;
                                isPlaceTrue = true;
                                if (cuontPart < 2)
                                {
                                    partID = item.PartID;
                                }

                            }
                        }

                        if (isPlaceTrue)
                        {


                            db.ParkingPlacePartRepository.ParkingPlaceID = placeID; //SET placeID
                            placeIDInportSuccessful = true;

                            if (cuontPart < 2)
                            {
                                db.ParkingPlacePartRepository.PartID = partID;
                                partIDInportSuccessful = true;
                            }
                        }
                        else Console.WriteLine("Palce number is FALSE: {0}", placeID);

                    }


                    //Inport partID
                    while (!partIDInportSuccessful)
                    {
                        //Inport PlaceID
                        Console.Write("Enter Part number (1 or 2): ");
                        partID = int.Parse(Console.ReadLine());

                        //Check to PlaceID is true
                        if (partID == 1 || partID == 2)
                        {

                            //Console.WriteLine("Part: isPlaceTrue, RegNumber:{0}", db.ParkingPlacePartRepository.RegNumber);

                            db.ParkingPlacePartRepository.PartID = partID; //SET partID
                            Console.WriteLine("Part number: {0}", partID);
                            partIDInportSuccessful = true;
                        }
                        else
                        {
                            partIDInportSuccessful = false;
                            Console.WriteLine("Part number {0} is FALSE:", partID);
                        }


                    }

                    //RUN DeleteRegNumber and MoveRegNumber


                    db.ParkingPlacePartRepository.DeleteRegNumber();
                    bool moved = db.ParkingPlacePartRepository.MoveRegNumber();

                    if (moved)
                    {
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine("{0} moved to:", vehicleType);
                        Console.WriteLine("     Place: {0}", placeID);
                        Console.WriteLine("     Part: {0}", partID);
                        Console.WriteLine("-------------------------------");
                    }
                    else
                    {
                        Console.WriteLine("SEVER: Error MoveRegNumber ");
                    }
                }

            }
        }

        public void FindVehicle()
        {
            bool regNumberInportSuccessful = false;

            while (!regNumberInportSuccessful)
            {
                //Inport RegNumber
                Console.Write("Enter your regNumber: ");
                int regNumber = int.Parse(Console.ReadLine());

                //Check to have RegNumber
                db.ParkingPlacePartRepository.RegNumber = regNumber;
                bool haveRegNumber = db.ParkingPlacePartRepository.HaveRegNumber();


                if (haveRegNumber) //If have Regnumber
                {
                    regNumberInportSuccessful = true;
                    BillViewModel bill = db.ParkingPlacePartRepository.ReadARow();

                    Console.WriteLine("\n-----------------------------------");
                    Console.WriteLine("VehicleType: {0}", (bill.VehicleType == "MC") ? "MotorC" : "Car");
                    Console.WriteLine($" Place: {bill.Place}");
                    if (bill.VehicleType == "MC") Console.WriteLine($" Part: {bill.Part}");
                    Console.WriteLine($" RegNumber: {bill.RegNumber}");
                    Console.WriteLine($" NumberPlate: {bill.NumberPlate}\n Arrival Date: {bill.ArrivalDate}\n Driver fullname: {bill.DriverFullName}");
                    Console.WriteLine("-----------------------------------\n");
                }
                else
                {
                    Console.WriteLine("Have not RegNumber {0}", regNumber);
                    regNumberInportSuccessful = false;
                }
            }

        }

        public void ShowContentOfParkingPlaces()
        {

            List<BillViewModel> listBills = db.ParkingPlacePartRepository.Read();

            foreach (var item in listBills)
            {
                Console.WriteLine($"Place: {item.Place}");
                Console.WriteLine(" VehicleType: {0}", (item.VehicleType == "MC") ? "MotorC" : "Car");
                if (item.VehicleType == "MC") Console.WriteLine($" Part: {item.Part}");
                Console.WriteLine($" RegNumber: {item.RegNumber}");
                Console.WriteLine($" NumberPlate: {item.NumberPlate}\n Arrival Date: {item.ArrivalDate}\n Driver fullname: {item.DriverFullName}");
                Console.WriteLine("-----------------------------------");
            }

        }

        #endregion


        #region Private Methods

        private bool GetBill(int regNumber, Database database)
        {
            Database db = database;
            db.ParkingBillRepository.RegNumber = regNumber;

            DateTime arrivalDate = db.ParkingBillRepository.GetArrivalDate();

            DateTime departureDate = db.ParkingBillRepository.DepartureDate = DateTime.Now;//02

            string vehicleType = db.ParkingBillRepository.GetVehicleType();

            var billPayment = Methods.BillTransaction(arrivalDate, departureDate, vehicleType);

            db.ParkingBillRepository.StoppagePeriod = billPayment.StoppagePeriod;//03
            db.ParkingBillRepository.Bill = billPayment.Bill; //04

            bool updated = db.ParkingBillRepository.Update();

            if (updated)
            {
                Console.WriteLine("\n--------------------------------------");
                Console.WriteLine("RegNumber: {0}", regNumber);
                Console.WriteLine("ArrivalDate: {0}", arrivalDate);
                Console.WriteLine("DepartureDate: {0}", departureDate);
                Console.WriteLine("vehicleType: {0}", vehicleType);
                Console.WriteLine("StoppagePeriod: {0}", db.ParkingBillRepository.StoppagePeriod);
                Console.WriteLine("Bill: {0:c}", db.ParkingBillRepository.Bill);
                Console.WriteLine("--------------------------------------");

                return true;
            }
            else
            {
                Console.WriteLine("SERVER: Error update");
                return false;
            };
        }

        #endregion
    }

}
