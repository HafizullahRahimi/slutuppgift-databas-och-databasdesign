using System.Data.SqlClient;
using ViewModels;

namespace DataAccess.Repositories
{
    public class ParkingPlacePartRepository
    {
        #region Fields (variables)
        private string _connectionString;
        private SqlConnection _connection;
        #endregion


        #region Properties

        public int ParkingPlacePartID { get; set; }
        public int ParkingPlaceID { get; set; }
        public int PartID { get; set; }
        public int RegNumber { get; set; }
        public string VehicleType { get; set; }

        #endregion


        #region Constructor
        public ParkingPlacePartRepository(string connectionString) //constructor injection c#
        {
            _connectionString = connectionString;
        }

        #endregion


        #region CRUD

        //public bool Insert() { return true; }
        //public bool Delete() { return true; }
        //public bool Update() { return true; }

        /// <summary>
        /// Read All rows from View_ParkingPlaceParts_ParkingBills_Vehicles_VehicleTypes, Need RegNumber
        /// </summary>
        /// <returns>Return a list of object BillViewModel</returns>
        public List<BillViewModel> Read()
        {
            string query = "select * from View_ParkingPlaceParts_ParkingBills_Vehicles_VehicleTypes";

            try
            {
                using (_connection = new SqlConnection(_connectionString))
                {
                    _connection.Open();
                    SqlCommand command = new SqlCommand(query, _connection);

                    SqlDataReader reader = command.ExecuteReader();

                    List<BillViewModel> billList = new List<BillViewModel>();
                    List<BillViewModel> uniqueList = new List<BillViewModel>();

                    while (reader.Read())
                    {

                        BillViewModel bill = new BillViewModel();

                        bill.Place = reader["ParkingPlaceID"].ToString();
                        bill.Part = reader["PartID"].ToString();
                        bill.RegNumber = reader["RegNumber"].ToString();
                        bill.VehicleType = reader["VehicleType"].ToString();
                        bill.NumberPlate = reader["NumberPlate"].ToString();
                        bill.DriverFullName = reader["DriverFullName"].ToString();
                        bill.ArrivalDate = reader["ArrivalDate"].ToString();
                        bill.DepartureDate = reader["DepartureDate"].ToString();
                        bill.StoppagePeriod = reader["StoppagePeriod"].ToString();
                        bill.Bill = reader["Bill"].ToString();

                        billList.Add(bill);


                    }

                    string regNumber = null;

                    foreach (var item in billList)
                    {

                        if (item.RegNumber != regNumber)
                        {
                            uniqueList.Add(item);
                        }

                        regNumber = item.RegNumber;
                    }

                    return uniqueList;
                }

            }
            catch (Exception)
            {
                return new List<BillViewModel>();
                throw;
            }
        }

        /// <summary>
        /// Read a Row from View_ParkingPlaceParts_ParkingBills_Vehicles_VehicleTypes, Need RegNumber
        /// </summary>
        /// <returns> return Object BillViewModel</returns>
        public BillViewModel ReadARow()
        {
            string query = @"select * from View_ParkingPlaceParts_ParkingBills_Vehicles_VehicleTypes
                            where Regnumber = @regNumber
                             ";

            try
            {
                using (_connection = new SqlConnection(_connectionString))
                {
                    _connection.Open();
                    SqlCommand command = new SqlCommand(query, _connection);

                    command.Parameters.AddWithValue("@regNumber", RegNumber);

                    SqlDataReader reader = command.ExecuteReader();

                    BillViewModel bill = new BillViewModel();

                    while (reader.Read())
                    {

                        bill.Place = reader["ParkingPlaceID"].ToString();
                        bill.Part = reader["PartID"].ToString();
                        bill.RegNumber = reader["RegNumber"].ToString();
                        bill.VehicleType = reader["VehicleType"].ToString();
                        bill.NumberPlate = reader["NumberPlate"].ToString();
                        bill.DriverFullName = reader["DriverFullName"].ToString();
                        bill.ArrivalDate = reader["ArrivalDate"].ToString();
                        bill.DepartureDate = reader["DepartureDate"].ToString();
                        bill.StoppagePeriod = reader["StoppagePeriod"].ToString();
                        bill.Bill = reader["Bill"].ToString();

                    }



                    return bill;
                }

            }
            catch (Exception)
            {
                return new BillViewModel();
                throw;
            }
        }

        #endregion

        #region RegNumber Methods

        /// <summary>
        /// Add RegNumber of Car or MotorC, Need RegNumber
        /// </summary>
        /// <returns>true or false</returns>
        public bool AddRegNumber()
        {
            SetVehicleType();
            string query;

            if (VehicleType == "Car")
            {
                query = @"UPDATE ParkingPlaceParts
                             SET RegNumber = @regNumber
	                         WHERE ParkingPlaceID = @parkingPlaceID;
                           ";
            }
            else
            {
                query = @"UPDATE ParkingPlaceParts
                             SET RegNumber = @regNumber
	                         WHERE ParkingPlacePartID = @parkingPlacePartID;
                           ";
            }

            try
            {
                using (_connection = new SqlConnection(_connectionString))
                {
                    _connection.Open();
                    SqlCommand command = new SqlCommand(query, _connection);


                    // Random Place
                    var listFreePlaces = GetListFreePlaces();
                    var random = new Random();
                    int index = random.Next(listFreePlaces.Count);
                    int randomPlace = listFreePlaces[index];
                    //Console.WriteLine("Random Place: {0}", randomPlace);

                    command.Parameters.AddWithValue("@regNumber", RegNumber);
                    if (VehicleType == "Car") command.Parameters.AddWithValue("@parkingPlaceID", randomPlace); //Car
                    else command.Parameters.AddWithValue("@parkingPlacePartID", randomPlace); //MotorC

                    int result = command.ExecuteNonQuery(); //Return -1: false, > 0:true


                    if (result > 0) return true;
                    else return false;
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        /// <summary>
        /// Have the RegNumber or Not, Need RegNumber property
        /// </summary>
        /// <returns>True or False(Have Not)</returns>
        public bool HaveRegNumber()
        {

            string query = @"SELECT * FROM ParkingPlaceParts
	                        WHERE RegNumber = @regNumber;
                           ";

            try
            {
                using (_connection = new SqlConnection(_connectionString))
                {
                    _connection.Open();
                    SqlCommand command = new SqlCommand(query, _connection);

                    command.Parameters.AddWithValue("@regNumber", RegNumber);


                    int result = Convert.ToInt32(command.ExecuteScalar());
                    // ExecuteScalar is Objset But I need int 

                    if (result > 0)
                    {
                        return true;
                    }
                    else return false;
                }
            }
            catch (Exception)
            {
                return false; //Have Not 
                throw;
            }
        }

        /// <summary>
        /// Delete RegNumber of Car or MotorC, Need RegNumber
        /// </summary>
        /// <returns>true or false</returns>
        public bool DeleteRegNumber()
        {
            string query = @"UPDATE ParkingPlaceParts
                             SET RegNumber = Null
                            WHERE RegNumber = @regNumber;
                           ";

            try
            {
                using (_connection = new SqlConnection(_connectionString))
                {
                    _connection.Open();
                    SqlCommand command = new SqlCommand(query, _connection);

                    command.Parameters.AddWithValue("@regNumber", RegNumber);

                    int result = command.ExecuteNonQuery(); //Return -1: false, > 0:true

                    if (result > 0) return true;
                    else return false;
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        /// <summary>
        /// Move RegNumber of Car or MotorC, Need RegNumber and ParkingPlaceID(Car) , ParkingPlacePartID(MotoC)
        /// </summary>
        /// <returns>true or false</returns>
        public bool MoveRegNumber()
        {
            SetVehicleType();
            string query;

            if (VehicleType == "Car")
            {
                query = @"UPDATE ParkingPlaceParts
                             SET RegNumber = @regNumber
	                         WHERE ParkingPlaceID = @parkingPlaceID;
                           ";
            }
            else
            {
                query = @"UPDATE ParkingPlaceParts
                             SET RegNumber = @regNumber
	                         WHERE ParkingPlaceID = @parkingPlaceID AND PartID = @partID;
                           ";
            }

            try
            {
                using (_connection = new SqlConnection(_connectionString))
                {
                    _connection.Open();
                    SqlCommand command = new SqlCommand(query, _connection);

                    command.Parameters.AddWithValue("@regNumber", RegNumber);
                    if (VehicleType == "Car") command.Parameters.AddWithValue("@parkingPlaceID", ParkingPlaceID); //Car
                    else
                    {
                        command.Parameters.AddWithValue("@parkingPlaceID", ParkingPlaceID); //MotorC
                        command.Parameters.AddWithValue("@partID", PartID);
                    }

                    int result = command.ExecuteNonQuery(); //Return -1: false, > 0:true


                    if (result > 0)
                    {
                        return true;
                    }
                    else return false;
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }



        }

        #endregion

        #region Methods

        /// <summary>
        /// Set VehicleType property, Need RegNumber property
        /// </summary>
        /// <returns>True or False(Have Not)</returns>
        public bool SetVehicleType()
        {
            string query = @"SELECT VehicleType FROM View_ParkingBills_Vehicles_VehicleTypes
	                        WHERE RegNumber = @regNumber;
                           ";

            try
            {
                using (_connection = new SqlConnection(_connectionString))
                {
                    _connection.Open();
                    SqlCommand command = new SqlCommand(query, _connection);

                    command.Parameters.AddWithValue("@regNumber", RegNumber);

                    SqlDataReader reader = command.ExecuteReader();

                    string result = "";

                    while (reader.Read())
                    {
                        result = reader["VehicleType"].ToString();
                    }

                    if (result != "")
                    {
                        VehicleType = result;
                        return true;
                    }
                    else return false;

                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        /// <summary>
        /// Set ParkingPlacePartID property, Need RegNumber property
        /// </summary>
        /// <returns>True or False(Have Not)</returns>
        private bool SetParkingPlacePartID()
        {
            string query = @"SELECT ParkingPlacePartID FROM View_ParkingPlaceParts_ParkingBills_Vehicles_VehicleTypes
	                        WHERE RegNumber = @regNumber;
                           ";

            try
            {
                using (_connection = new SqlConnection(_connectionString))
                {
                    _connection.Open();
                    SqlCommand command = new SqlCommand(query, _connection);

                    command.Parameters.AddWithValue("@regNumber", RegNumber);

                    SqlDataReader reader = command.ExecuteReader();

                    string result = "";

                    while (reader.Read())
                    {
                        result = reader["ParkingPlacePartID"].ToString();
                    }

                    if (result != "")
                    {
                        ParkingPlacePartID = int.Parse(result);
                        return true;
                    }
                    else return false;

                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        /// <summary>
        /// Set ParkingPlaceID  property, Need RegNumber property
        /// </summary>
        /// <returns>True or False(Have Not)</returns>
        private bool SetParkingPlaceID()
        {
            string query = @"SELECT ParkingPlaceID FROM View_ParkingPlaceParts_ParkingBills_Vehicles_VehicleTypes
	                        WHERE RegNumber = @regNumber;
                           ";

            try
            {
                using (_connection = new SqlConnection(_connectionString))
                {
                    _connection.Open();
                    SqlCommand command = new SqlCommand(query, _connection);

                    command.Parameters.AddWithValue("@regNumber", RegNumber);

                    SqlDataReader reader = command.ExecuteReader();

                    string result = "";

                    while (reader.Read())
                    {
                        result = reader["ParkingPlaceID"].ToString();
                    }

                    if (result != "")
                    {
                        ParkingPlaceID = int.Parse(result);
                        return true;
                    }
                    else return false;

                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        /// <summary>
        /// Get a list of Free Places For Car or MotoerC, Need RegNumber property
        /// </summary>
        /// <returns>List or empty list</returns>
        public List<int> GetListFreePlaces()
        {
            SetVehicleType();
            List<int> list = new List<int>();
            string query;

            if (VehicleType == "Car")
            {

                query = @"SELECT ParkingPlaceID, COUNT(ParkingPlaceID) AS CountPlaces
                            FROM ParkingPlaceParts
                            Where  RegNumber IS NULL 
                            GROUP BY ParkingPlaceID
                            HAVING COUNT(ParkingPlaceID) > 1;";
            }
            else
            {
                query = @"SELECT ParkingPlacePartID FROM ParkingPlaceParts
                            WHERE (PartID='1' or PartID='2') and RegNumber IS NULL;";

            }


            try
            {
                using (_connection = new SqlConnection(_connectionString))
                {
                    _connection.Open();
                    SqlCommand command = new SqlCommand(query, _connection);

                    SqlDataReader reader = command.ExecuteReader();

                    string item;

                    while (reader.Read())
                    {

                        if (VehicleType == "Car") item = reader["ParkingPlaceID"].ToString();
                        else item = reader["ParkingPlacePartID"].ToString();

                        list.Add(int.Parse(item));
                    }

                    return list;
                }

            }
            catch (Exception)
            {
                return list;
                throw;
            }

        }

        /// <summary>
        /// Get a list of Free Places For Car or MotoerC
        /// </summary>
        /// <returns>List or empty list</returns>
        public List<int> GetListFreePlaces(string vehicleType)
        {
            //SetVehicleType();
            List<int> list = new List<int>();
            string query;

            if (vehicleType == "Car")
            {

                query = @"SELECT ParkingPlaceID, COUNT(ParkingPlaceID) AS CountPlaces
                            FROM ParkingPlaceParts
                            Where  RegNumber IS NULL 
                            GROUP BY ParkingPlaceID
                            HAVING COUNT(ParkingPlaceID) > 1;";
            }
            else
            {
                query = @"SELECT ParkingPlacePartID FROM ParkingPlaceParts
                            WHERE (PartID='1' or PartID='2') and RegNumber IS NULL;";

            }


            try
            {
                using (_connection = new SqlConnection(_connectionString))
                {
                    _connection.Open();
                    SqlCommand command = new SqlCommand(query, _connection);

                    SqlDataReader reader = command.ExecuteReader();

                    string item;

                    while (reader.Read())
                    {

                        if (vehicleType == "Car") item = reader["ParkingPlaceID"].ToString();
                        else item = reader["ParkingPlacePartID"].ToString();

                        list.Add(int.Parse(item));
                    }

                    return list;
                }

            }
            catch (Exception)
            {
                return list;
                throw;
            }

        }

        /// <summary>
        /// Get a list of Free Places For Car or MotoerC
        /// </summary>
        /// <returns>List or empty list</returns>
        public List<FPMotorCViewModel> GetListFreePlaceParts()
        {
            List<FPMotorCViewModel> list = new List<FPMotorCViewModel>();
            string query;

            query = @"SELECT ParkingPlaceID,PartID FROM ParkingPlaceParts
                      WHERE (PartID='1' or PartID='2') and RegNumber IS NULL;";

            try
            {
                using (_connection = new SqlConnection(_connectionString))
                {
                    _connection.Open();
                    SqlCommand command = new SqlCommand(query, _connection);

                    SqlDataReader reader = command.ExecuteReader();


                    while (reader.Read())
                    {
                        FPMotorCViewModel item = new FPMotorCViewModel();

                        item.PlaceID = int.Parse(reader["ParkingPlaceID"].ToString());
                        item.PartID = int.Parse(reader["PartID"].ToString());

                        list.Add(item);
                    }

                    return list;
                }

            }
            catch (Exception)
            {
                return list;
                throw;
            }

        }
        #endregion
    }
}
