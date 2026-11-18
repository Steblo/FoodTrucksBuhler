namespace FoodTrucks.Models
{
    public class FoodTruck
    {
        public int locationid { get; set; }
        public string Applicant { get; set; } = string.Empty;
        public string FacilityType { get; set; } = string.Empty;
        public int cnn { get; set; }
        public string LocationDescription { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string blocklot { get; set; } = string.Empty;
        public string block { get; set; } = string.Empty;
        public string lot { get; set; } = string.Empty;
        public string permit { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string FoodItems { get; set; } = string.Empty;
        public string X { get; set; } = string.Empty;
        public string Y { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Schedule { get; set; } = string.Empty;
        public string dayshours { get; set; } = string.Empty;
        public string NOISent { get; set; } = string.Empty;
        public string Approved { get; set; } = string.Empty;
        public int Received { get; set; }
        public int PriorPermit { get; set; }
        public string ExpirationDate { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;

        public double CalculateDistance(double latitude, double longitude)
        {
            var d1 = latitude * (Math.PI / 180.0);
            var num1 = longitude * (Math.PI / 180.0);
            var d2 = Latitude * (Math.PI / 180.0);
            var num2 = Longitude * (Math.PI / 180.0) - num1;
            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) +
                     Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);
            return 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));
        }
    }
}
