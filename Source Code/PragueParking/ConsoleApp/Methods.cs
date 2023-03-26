using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace ConsoleApp
{
    public static class Methods
    {
        static public BillTransactionViewModel BillTransaction(DateTime arrivalDate, DateTime departureDate, string vehicleType)
        {
            int hours = 0;
            int minutes = 0;
            string stoppagePeriod;
            int parkingTime;
            decimal bill = 0;
            var result = new BillTransactionViewModel();

            TimeSpan timeDiff = departureDate - arrivalDate;

            hours = (timeDiff.Days * 24) + timeDiff.Hours;
            minutes = timeDiff.Minutes;

            parkingTime = (hours * 60) + minutes;

            if (vehicleType=="Car") bill = parkingTime * (80m / 60);  //80kr for a hour(60 mins) Car
            else bill = parkingTime * (40m / 60);  //40 kr for a hour(60 mins) MotoC

            result.StoppagePeriod = $"{hours}:{minutes}";
            result.Bill = bill;

            return result;


        }
    }
}
