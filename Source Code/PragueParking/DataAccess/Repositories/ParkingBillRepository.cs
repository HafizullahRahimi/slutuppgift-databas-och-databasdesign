using System.Data.SqlClient;

namespace DataAccess.Repositories
{
    /// <summary>
    /// Repository for work with Table ParkingBills Data in Database
    /// </summary>
    public class ParkingBillRepository
    {
        #region Fields (variables)
        private string _connectionString;
        private SqlConnection _connection;
        #endregion

        #region Properties
        public int RegNumber { get; set; }
        public int VehicleID { get; set; }
        public bool Active { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public string StoppagePeriod { get; set; }
        public decimal Bill { get; set; }

        #endregion

        #region Constructor
        public ParkingBillRepository(string connectionString) //constructor injection c#
        {
            _connectionString = connectionString;
        }
        #endregion

        #region CRUD

        /// <summary>
        /// Insert to ParkingBills Table, Need to VehicleID and ArrivalDate Properties
        /// </summary>
        /// <returns> true if inserted</returns>
        public bool Insert()
        {
            String query = @"INSERT INTO ParkingBills (VehicleID, Active, ArrivalDate)
	                           VALUES (@vehicleID, 1, @arrivalDate );
                           ";


            try
            {
                using (_connection = new SqlConnection(_connectionString))
                {
                    _connection.Open();
                    SqlCommand command = new SqlCommand(query, _connection);

                    command.Parameters.AddWithValue("@vehicleID", VehicleID);
                    command.Parameters.AddWithValue("@arrivalDate", ArrivalDate);

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
        /// Delete a Colum From ParkingBills Table, Need to RegNumber Property
        /// </summary>
        /// <returns> true: deleted</returns>
        public bool Delete()
        {

            string query = @"DELETE FROM ParkingBills
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
        /// Update a Colum From ParkingBills Table, Need to RegNumber, DepartureDate, StoppagePeriod and Bill  Properties
        /// </summary>
        /// <returns>True or False</returns>
        public bool Update()
        {
            string query = @"UPDATE ParkingBills
                            SET Active = 0,
                            DepartureDate = @departureDate,
                            StoppagePeriod= @stoppagePeriod,
                            Bill = @bill
                            WHERE RegNumber = @regNumber;
                           ";
            try
            {
                using (_connection = new SqlConnection(_connectionString))
                {
                    _connection.Open();
                    SqlCommand command = new SqlCommand(query, _connection);

                    command.Parameters.AddWithValue("@departureDate", DepartureDate);
                    command.Parameters.AddWithValue("@stoppagePeriod", StoppagePeriod);
                    command.Parameters.AddWithValue("@bill", Bill);
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
        public bool Read()
        {
            string query = "select * from ParkingBills";

            try
            {
                using (_connection = new SqlConnection(_connectionString))
                {
                    _connection.Open();
                    SqlCommand command = new SqlCommand(query, _connection);

                    SqlDataReader reader = command.ExecuteReader();

                    Console.WriteLine("\nParkingBills Table:");
                    Console.WriteLine("RegNumber   VehicleID  Active    ArrivalDate             DepartureDate          StoppagePeriod       Charge");
                    Console.WriteLine("----------  ---------  ------    -----------             -------------          --------------       ------");
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}           {1}        {2}     {3}     {4}    {5}    {6}", reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6]);
                    }

                    return true;
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
        /// Check To have RegNumber, Need to RegNumber property
        /// </summary>
        /// <returns>Reg number or 0(have not)</returns>
        public int HaveRegNumber()
        {

            string query = @"SELECT * FROM ParkingBills
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
                        VehicleID = result;
                        return result;
                    }
                    else return 0;
                }
            }
            catch (Exception)
            {
                return 0; //Have Not 
                throw;
            }
        }

        /// <summary>
        /// For Get ArrivalDate, Need RegNumber property
        /// </summary>
        /// <returns>ArrivalDate OR default DateTime(Have Not)</returns>
        public DateTime GetArrivalDate()
        {

            string query = @"SELECT ArrivalDate FROM ParkingBills
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

                    DateTime result = default;

                    while (reader.Read())
                    {
                        string resultString = reader[0].ToString();
                        result = DateTime.Parse(resultString);
                    }

                    if (result != default) return result;
                    else return default;

                }
            }
            catch (Exception)
            {
                return default;
                throw;
            }
        }

        /// <summary>
        /// Get Last RegNumber, 
        /// </summary>
        /// <returns>RegNumber or 0 (Have Not) </returns>
        public int GetLastRegNumber()
        {

            string query = @"SELECT top(1) * FROM ParkingBills
	                        order by RegNumber desc;
                           ";

            try
            {
                using (_connection = new SqlConnection(_connectionString))
                {
                    _connection.Open();
                    SqlCommand command = new SqlCommand(query, _connection);

                    int result = Convert.ToInt32(command.ExecuteScalar());
                    // ExecuteScalar is Objset But I need int 

                    if (result > 0)
                    {
                        RegNumber = result;
                        return result;
                    }
                    else return 0;
                }
            }
            catch (Exception)
            {
                return 0; //Have Not 
                throw;
            }
        }

        /// <summary>
        /// Check to have VehicleID than Active = 1, Need VehicleID property
        /// </summary>
        /// <returns>RegNumber or 0</returns>
        public int HaveVehicleID()
        {

            string query = @"SELECT * FROM ParkingBills
	                        WHERE VehicleID = @vehicleID and Active = '1';
                           ";

            try
            {
                using (_connection = new SqlConnection(_connectionString))
                {
                    _connection.Open();
                    SqlCommand command = new SqlCommand(query, _connection);

                    command.Parameters.AddWithValue("@vehicleID", VehicleID);

                    int result = Convert.ToInt32(command.ExecuteScalar());

                    if (result > 0)
                    {
                        RegNumber = result;
                        return result;
                    }
                    else return 0;
                }
            }
            catch (Exception)
            {
                return 0; //Have Not 
                throw;
            }
        }

        /// <summary>
        /// For Get VehicleType, Need RegNumber property
        /// </summary>
        /// <returns>VehicleType OR ""(Have Not)</returns>
        public string GetVehicleType()
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
                        result = reader[0].ToString();
                    }

                    if (result != "") return result;
                    else return "";

                }
            }
            catch (Exception)
            {
                return "";
                throw;
            }
        }

        #endregion
    }
}
