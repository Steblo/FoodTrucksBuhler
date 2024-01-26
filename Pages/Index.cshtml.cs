using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FoodTrucks.Models;
using CsvHelper;
using System.Globalization;
using CsvHelper.Configuration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTrucks.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => args.Header.ToLower(),
            };
            string startupPath = Environment.CurrentDirectory;
            using var reader = new StreamReader(startupPath + @"\Data\Mobile_Food_Facility_Permit.csv");
            using var csv = new CsvReader(reader, config);

            FoodTrucks = csv.GetRecords<FoodTruck>().Where(x => x.FoodItems.Contains(SearchFood ?? string.Empty)).OrderBy(x => x.CalculateDistance(new Location() { Latitude = SearchLatitude, Longitude = SearchLongitude }, new Location() { Latitude = x.Latitude, Longitude = x.Longitude })).ToList();

            if (SearchAmount != null)
            {
                FoodTrucks = FoodTrucks.Take(SearchAmount).ToList();
            }
        }

        [DataType(DataType.Currency)]
        [Column(TypeName = "double")]
        [BindProperty(SupportsGet = true)]
        public double SearchLatitude { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "double")]
        [BindProperty(SupportsGet = true)]
        public double SearchLongitude { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "int32")]
        [BindProperty(SupportsGet = true)]
        public int SearchAmount { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SearchFood { get; set; }

        public required List<FoodTruck> FoodTrucks { get; set; }

        public class Location
        {
            public double Latitude { get; set; }
            public double Longitude { get; set; }
        }
    }
}
