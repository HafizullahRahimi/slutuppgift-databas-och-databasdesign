using System.Data.SqlClient;

namespace DataAccess.Services
{
    /// <summary>
    /// Repository for work with Table Vehicles Data in Database
    /// </summary>
    public class VehicleRepository
    {
        #region Fields (variables)
        private string _connectionString;
        private SqlConnection _connection;
        #endregion

        #region Properties
        public int Rasult;
        public int VehicleID { get; set; }
        public string NumberPlate { get; set; }
        public string VehicleTypeID { get; set; }
        public string DriverFullName { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }

        #endregion

        #region Constructor
        public VehicleRepository(string connectionString)  //constructor injection c#
        {
            _connectionString = connectionString;
        }
        #endregion

        #region CRUD
        public bool Insert()
        {
            string query = @"INSERT INTO [Vehicles] (NumberPlate, VehicleTypeID, DriverFullName, Active)
	                           VALUES (@numberPlate, @vehicleTypeID, @driverFullName, '1');
                           ";

            try
            {
                using (_connection = new SqlConnection(_connectionString))
                {
                    _connection.Open();
                    SqlCommand command = new SqlCommand(query, _connection);

                    command.Parameters.AddWithValue("@numberPlate", NumberPlate);
                    command.Parameters.AddWithValue("@vehicleTypeID", VehicleTypeID);
                    command.Parameters.AddWithValue("@driverFullName", DriverFullName);
                    //command.Parameters.AddWithValue("@mobileNumber", MobileNumber);
                    //command.Parameters.AddWithValue("@email", Email);


                    int result = command.ExecuteNonQuery(); //Return -1: false, > 0:true

                    Rasult = result;

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
        public bool Delete()
        {
            string query = @"DELETE FROM Vehicles
                            WHERE VehicleID = @vehicleID;
                           ";
            try
            {
                using (_connection = new SqlConnection(_connectionString))
                {
                    _connection.Open();
                    SqlCommand command = new SqlCommand(query, _connection);

                    command.Parameters.AddWithValue("@vehicleID", VehicleID);

                    int result = command.ExecuteNonQuery(); //Return -1: false, > 0:true

                    Rasult = result;

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
        public bool Update()
        {
            string query = @"UPDATE Vehicles
                            SET Active = @active
                            WHERE VehicleID = @vehicleID;
                           ";
            try
            {
                using (_connection = new SqlConnection(_connectionString))
                {
                    _connection.Open();
                    SqlCommand command = new SqlCommand(query, _connection);

                    command.Parameters.AddWithValue("@active", Active);
                    command.Parameters.AddWithValue("@vehicleID", VehicleID);

                    int result = command.ExecuteNonQuery(); //Return -1: false, > 0:true

                    Rasult = result;

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
            string query = "select * from Vehicles";

            try
            {
                using (_connection = new SqlConnection(_connectionString))
                {
                    _connection.Open();
                    SqlCommand command = new SqlCommand(query, _connection);

                    SqlDataReader reader = command.ExecuteReader();

                    Console.WriteLine("\nVehicles Table:");
                    Console.WriteLine("VehicleID   NumberPlate  VehicleType    DriverFullName");
                    Console.WriteLine("----------  -----------  -----------    --------------");
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}           {1}            {2}         {3}", reader[0], reader[1], reader[2], reader[3]);
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
        /// SET numberPlate,  Need NumberPlate property
        /// </summary>
        /// <returns>True or false</returns>
        public bool SetVehicleID()
        {

            string query = @"SELECT * FROM Vehicles
	                        WHERE NumberPlate = @numberPlate;
                           ";

            try
            {
                using (_connection = new SqlConnection(_connectionString))
                {
                    _connection.Open();
                    SqlCommand command = new SqlCommand(query, _connection);

                    command.Parameters.AddWithValue("@numberPlate", NumberPlate);


                    int result = Convert.ToInt32(command.ExecuteScalar());
                    // ExecuteScalar is Objset But I need int (VehicleID)
                    // Return VehicleID 
                    // Return 0 : Have not VehicleID

                    Rasult = result;

                    if (result > 0)
                    {
                        VehicleID = result;
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
        /// Check To have numberPlate,  Need NumberPlate property
        /// </summary>
        /// <returns>True and false</returns>
        public bool HaveVehicleID()
        {

            string query = @"SELECT * FROM Vehicles
	                        WHERE NumberPlate = @numberPlate and Active='1';
                           ";

            try
            {
                using (_connection = new SqlConnection(_connectionString))
                {
                    _connection.Open();
                    SqlCommand command = new SqlCommand(query, _connection);

                    command.Parameters.AddWithValue("@numberPlate", NumberPlate);


                    int result = Convert.ToInt32(command.ExecuteScalar());
                    // ExecuteScalar is Objset But I need int (VehicleID)
                    // Return VehicleID 
                    // Return 0 : Have not VehicleID

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

        #endregion
    }
}
