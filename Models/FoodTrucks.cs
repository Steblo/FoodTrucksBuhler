using static FoodTrucks.Pages.IndexModel;

namespace FoodTrucks.Models
{
    public class FoodTruck
    {
        public int locationid { get; set; }
        public string Applicant { get; set; }
        public string FacilityType { get; set; }
        public int cnn { get; set; }
        public string LocationDescription { get; set; }
        public string Address { get; set; }
        public string blocklot { get; set; }
        public string block { get; set; }
        public string lot { get; set; }
        public string permit { get; set; }
        public string Status { get; set; }
        public string FoodItems { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Schedule { get; set; }
        public string dayshours { get; set; }
        public string NOISent { get; set; }
        public string Approved { get; set; }
        public int Received { get; set; }
        public int PriorPermit { get; set; }
        public string ExpirationDate { get; set; }
        public string Location { get; set; }

        public double CalculateDistance(Location point1, Location point2)
        {
            var d1 = point1.Latitude * (Math.PI / 180.0);
            var num1 = point1.Longitude * (Math.PI / 180.0);
            var d2 = point2.Latitude * (Math.PI / 180.0);
            var num2 = point2.Longitude * (Math.PI / 180.0) - num1;
            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) +
                     Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);
            return 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));
        }
    }
}
