using DataAccess;
using DataAccess.Repositories;
using DataAccess.Services;
using System.Collections.Generic;
using ViewModels;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main()
        {
            //Console.WriteLine("Prague Parking!");
            //Database db = new Database();







            //-----Read() -------------------------------------------
            //VehicleRepository
            //db.VehicleRepository.Read();

            //-----Insert() --------------------------------------------

            //bool numberPlateInport = true;
            //bool vehicleTypeIDInport = true;

            //while (numberPlateInport)
            //{
            //    Console.Write("Enter NumberPlate: ");
            //    string numberPlate = Console.ReadLine();
            //    db.VehicleRepository.NumberPlate = numberPlate;
            //    int haveVehicleID = db.VehicleRepository.GetVehicleID();

            //    Console.WriteLine(haveVehicleID);
            //    if (haveVehicleID > 0)
            //    {
            //        Console.WriteLine("We have NumberPlate: {0}", db.VehicleRepository.NumberPlate);
            //    }
            //    else
            //    {
            //        numberPlateInport = false;
            //    }
            //}

            //while (vehicleTypeIDInport)
            //{
            //    Console.Write("Enter VehicleType (1: Car, 2: MC): ");
            //    string vehicleType = Console.ReadLine();


            //    if (vehicleType == "2" || vehicleType == "1")
            //    {
            //        db.VehicleRepository.VehicleTypeID = vehicleType;
            //        vehicleTypeIDInport = false;
            //    }

            //}

            //Console.Write("Enter FullName: ");
            //string fullName = Console.ReadLine();
            //db.VehicleRepository.DriverFullName = fullName;

            //bool added = db.VehicleRepository.Insert();

            //if (added)
            //{

            //    db.VehicleRepository.Read();
            //    db.VehicleRepository.GetVehicleID();
            //    Console.WriteLine("VehicleTypeID:{0} added!", db.VehicleRepository.VehicleTypeID);
            //}
            //else
            //{
            //    Console.WriteLine("Insert: {0}", added);
            //    Console.WriteLine("DriverFullName: {0}", db.VehicleRepository.DriverFullName);
            //    Console.WriteLine("Errorrrrr");
            //}



            //----Update() ---------------------------------------------

            //db.VehicleRepository.VehicleID= 6;
            //db.VehicleRepository.Active = false;

            //bool udated = db.VehicleRepository.Update();

            //if (udated)
            //{
            //    Console.WriteLine("Updated!!");

            //    db.VehicleRepository.Read();
            //}


            //----Delete() ------------------------------------------------

            //db.VehicleRepository.VehicleID = 3;

            //bool delete = db.VehicleRepository.Delete();

            //if (delete)
            //{
            //    Console.WriteLine("Deleted!!");

            //    db.VehicleRepository.Read();
            //}



            //***************************************************************************************
            //ParkingBill Repository

            //----------Insert() ParkingBillRepository
            //db.ParkingBillRepository.VehicleID = 1;

            //int haveVehicleID = db.ParkingBillRepository.HaveVehicleID();

            //if (haveVehicleID == 0) // Have not haveVehicleID
            //{
            //    db.ParkingBillRepository.ArrivalDate = DateTime.Now;
            //    bool inserted = db.ParkingBillRepository.Insert();

            //    if (inserted)
            //    {
            //        Console.WriteLine("Inserted !!!");

            //        db.ParkingBillRepository.GetLastRegNumber();

            //        Console.WriteLine("RegNumber New Bill: {0}", db.ParkingBillRepository.RegNumber);
            //    }
            //    else Console.WriteLine("Erorr Insert()");

            //}
            //else Console.WriteLine("Have VehicleID: {0}", haveVehicleID);



            ////----------HaveVehicleID() ParkingBillRepository
            //db.ParkingBillRepository.VehicleID = 14;
            //int haveVehicleID = db.ParkingBillRepository.HaveVehicleID();

            //Console.WriteLine("Have VehicleID: {0}", haveVehicleID);



            ////----------Delete() ParkingBillRepository
            //db.ParkingBillRepository.RegNumber= 106;
            //bool deleted = db.ParkingBillRepository.Delete();

            //if (deleted) Console.WriteLine("Deleted !!!");
            //else Console.WriteLine("Erorr Delete()");



            ////----------Read() ParkingBillRepository
            //db.ParkingBillRepository.Read();



            ////----------GetRegNumber() ParkingBillRepository
            //db.ParkingBillRepository.RegNumber = 102;
            //int haveRegNumber = db.ParkingBillRepository.HaveRegNumber();

            //if (haveRegNumber > 0) Console.WriteLine("Have {0}", haveRegNumber);
            //else Console.WriteLine("Have NOT");




            ////----------GetArrivalDate() ParkingBillRepository
            //db.ParkingBillRepository.RegNumber = 102;
            //DateTime arrivalDate = db.ParkingBillRepository.GetArrivalDate();
            //Console.WriteLine(arrivalDate);




            //----------GetVehicleType()  ParkingBillRepository
            //db.ParkingBillRepository.RegNumber = 101;
            //String vehicleType = db.ParkingBillRepository.GetVehicleType();
            //Console.WriteLine(vehicleType);




            //----------Update() ParkingBillRepository

            //db.ParkingBillRepository.RegNumber = 102; //01
            //int haveRegNumber = db.ParkingBillRepository.HaveRegNumber();

            //if (haveRegNumber > 0)
            //{
            //    Console.WriteLine("Have {0}", haveRegNumber);

            //    DateTime arrivalDate = db.ParkingBillRepository.GetArrivalDate();
            //    Console.WriteLine("ArrivalDate: {0}", arrivalDate);

            //    DateTime departureDate = db.ParkingBillRepository.DepartureDate = DateTime.Now;//02
            //    Console.WriteLine("DepartureDate: {0}", departureDate);

            //    string vehicleType = db.ParkingBillRepository.GetVehicleType();
            //    Console.WriteLine("vehicleType: {0}", vehicleType);

            //    var billPayment = Methods.BillTransaction(arrivalDate, departureDate, vehicleType);

            //    db.ParkingBillRepository.StoppagePeriod = billPayment.StoppagePeriod;//03
            //    db.ParkingBillRepository.Bill = billPayment.Bill; //04

            //    Console.WriteLine("StoppagePeriod: {0}", db.ParkingBillRepository.StoppagePeriod);
            //    Console.WriteLine("Bill: {0}", db.ParkingBillRepository.Bill);

            //    bool updated = db.ParkingBillRepository.Update();

            //    if (updated)
            //    {
            //        Console.WriteLine("Updated");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Error update");
            //    }

            //}
            //else Console.WriteLine("Have NOT");



            //***************************************************************************************
            //ParkingPlacePartRepository

            ////----------GetFreePlaces ParkingPlacePartRepository
            ////var listFreePlaces = db.ParkingPlacePartRepository.GetListFreePlaces("Car");

            //db.ParkingPlacePartRepository.RegNumber = 102;
            //var listFreePlaces = db.ParkingPlacePartRepository.GetListFreePlaces();

            //foreach (var item in listFreePlaces)
            //{
            //    Console.WriteLine(item);
            //}



            ////----------AddRegNumber() ParkingPlacePartRepository
            //db.ParkingPlacePartRepository.RegNumber = 101;

            //bool haveRegNumber = db.ParkingPlacePartRepository.HaveRegNumber();

            //if (haveRegNumber)
            //{
            //    Console.WriteLine("Have RegNumber: {0}", db.ParkingPlacePartRepository.RegNumber);

            //}
            //else
            //{
            //    db.ParkingPlacePartRepository.AddRegNumber();
            //    Console.WriteLine("RegNumber Added");
            //}




            //----------DeleteRegNumber() ParkingPlacePartRepository
            //db.ParkingPlacePartRepository.RegNumber = 100;

            //bool haveRegNumber = db.ParkingPlacePartRepository.HaveRegNumber();

            //if (haveRegNumber)
            //{
            //    bool Deleted = db.ParkingPlacePartRepository.DeleteRegNumber();

            //    if (Deleted) Console.WriteLine("RegNumber deleted!");
            //    else Console.WriteLine("Erorrr delete!!!!!!");
            //}
            //else
            //{
            //    Console.WriteLine("Have NOT this RegNumber");
            //}




            //----------MoveRegNumber() ParkingPlacePartRepository
            //db.ParkingPlacePartRepository.RegNumber = 102;

            //db.ParkingPlacePartRepository.DeleteRegNumber();

            //db.ParkingPlacePartRepository.ParkingPlaceID = 12;
            ////db.ParkingPlacePartRepository.PartID = 2;
            //bool moved = db.ParkingPlacePartRepository.MoveRegNumber();

            //if (moved)
            //{
            //    Console.WriteLine("Moved");
            //}
            //else
            //{
            //    Console.WriteLine("Erorrrr Move");
            //}


            //----------------------------------------------------------
            ////----------MoveRegNumber() ParkingPlacePartRepository
            //db.ParkingPlacePartRepository.RegNumber = 102;

            //db.ParkingPlacePartRepository.ParkingPlaceID = 5;
            //db.ParkingPlacePartRepository.PartID = 2;

            ////Check to ParkingPlaceID is free
            //var FreePlace = db.ParkingPlacePartRepository.GetListFreePlaces();
            //bool isPlaceFree = false;
            //foreach (var item in FreePlace)
            //{
            //    if (item == db.ParkingPlacePartRepository.ParkingPlaceID)
            //    {
            //        isPlaceFree = true;
            //    }
            //}


            ////Check to HaveRegNumber
            //bool haveRegNumber = db.ParkingPlacePartRepository.HaveRegNumber();

            //if (haveRegNumber)
            //{
            //    Console.WriteLine("RegNumber Have");


            //    if (isPlaceFree)//Check to ParkingPlaceID is free
            //    {
            //        Console.WriteLine("Place is Free");

            //        db.ParkingPlacePartRepository.DeleteRegNumber();


            //        bool moved = db.ParkingPlacePartRepository.MoveRegNumber();

            //        if (moved)
            //        {
            //            Console.WriteLine("Moved");
            //        }
            //        else
            //        {
            //            Console.WriteLine("Erorrrr Move");
            //        }

            //    }
            //    else
            //    {
            //        Console.WriteLine("Place is NOT Free!!!!!!!!!!!");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Have NOT this RegNumber");
            //}







            ////----------SetParkingPlaceID() ParkingPlacePartRepository
            //db.ParkingPlacePartRepository.RegNumber = 102;
            //db.ParkingPlacePartRepository.SetParkingPlaceID();
            //Console.WriteLine(db.ParkingPlacePartRepository.ParkingPlaceID);


            ////----------SetParkingPlacePartID() ParkingPlacePartRepository
            //db.ParkingPlacePartRepository.RegNumber = 100;
            //db.ParkingPlacePartRepository.SetParkingPlacePartID();
            //Console.WriteLine(db.ParkingPlacePartRepository.ParkingPlacePartID);


            ////----------SetVehicleType ParkingPlacePartRepository
            //db.ParkingPlacePartRepository.RegNumber = 102;
            //db.ParkingPlacePartRepository.SetVehicleType();
            //Console.WriteLine(db.ParkingPlacePartRepository.VehicleType);

            //db.ParkingPlacePartRepository.Read();


            ////----------Read() ParkingPlacePartRepository
            //List<BillViewModel> listBills = db.ParkingPlacePartRepository.Read();

            //foreach (var item in listBills)
            //{
            //    Console.WriteLine($"Place: {item.Place}");
            //    if (item.VehicleType== "MC") Console.WriteLine($"Part: {item.Part}");
            //    Console.WriteLine($"RegNumber: {item.RegNumber}\nVehicleType: {item.VehicleType}\nNumberPlate: {item.NumberPlate}\nArrival Date: {item.ArrivalDate}\nDriver full name: {item.DriverFullName}");
            //    Console.WriteLine("-----------------------------------");
            //}




            bool showMenu = true;
            while (showMenu)
            {
                showMenu = Menu.Show();
            }

            //Console.ReadKey();
        }
    }
}