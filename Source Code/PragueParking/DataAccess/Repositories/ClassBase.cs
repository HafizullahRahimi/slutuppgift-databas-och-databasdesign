using System.Data.SqlClient;

namespace DataAccess.Repositories
{
    public class ClassBase
    {
        #region Fields (variables)
        private string _connectionString;
        private SqlConnection _connection;
        #endregion


        #region Properties

        #endregion


        #region Constructor
        public ClassBase(string connectionString) //constructor injection c#
        {
            _connectionString = connectionString;
        }
        #endregion


        #region CRUD

        public bool Insert() { return true; }
        public bool Delete() { return true; }
        public bool Update() { return true; }
        public bool Read() { return true; }

        #endregion


        #region Methods

        #endregion

    }
}
