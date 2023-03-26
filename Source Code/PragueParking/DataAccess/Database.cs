using DataAccess.Repositories;
using DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    /// <summary>
    /// Database with All Repositories
    /// </summary>
    public class Database
    {
        #region Fields (variables)
        private string _connectionString = @"Data Source=.\SQL2019; Initial Catalog=PragueParkingDB;Integrated Security=True;";

        private VehicleRepository _vehicleRepository;
        private ParkingBillRepository _parkingBillRepository;
        private ParkingPlacePartRepository _parkingPlacePartRepository;
        #endregion

        #region Properties
        public VehicleRepository VehicleRepository
        {
            get
            {
                if (_vehicleRepository == null)
                {
                    _vehicleRepository = new VehicleRepository(_connectionString);
                }

                return _vehicleRepository;
            }
        }
        public ParkingBillRepository ParkingBillRepository
        {
            get
            {
                if (_parkingBillRepository == null)
                {
                    _parkingBillRepository = new ParkingBillRepository(_connectionString);
                }

                return _parkingBillRepository;
            }
        }
        public ParkingPlacePartRepository ParkingPlacePartRepository
        {
            get
            {
                if (_parkingPlacePartRepository == null)
                {
                    _parkingPlacePartRepository = new ParkingPlacePartRepository(_connectionString);
                }

                return _parkingPlacePartRepository;
            }
        }

        #endregion
    }
}
