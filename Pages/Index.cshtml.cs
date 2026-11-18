using CsvHelper;
using CsvHelper.Configuration;
using FoodTrucks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace FoodTrucks.Pages
{
    public class IndexModel : PageModel
    {
        private const int MaximumResults = 50;
        private readonly IWebHostEnvironment _environment;

        public IndexModel(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public List<FoodTruck> FoodTrucks { get; private set; } = [];

        [Range(-90, 90)]
        [BindProperty(SupportsGet = true)]
        public double SearchLatitude { get; set; } = 37.7749;

        [Range(-180, 180)]
        [BindProperty(SupportsGet = true)]
        public double SearchLongitude { get; set; } = -122.4194;

        [Range(1, MaximumResults, ErrorMessage = "Zadej počet výsledků od 1 do 50.")]
        [BindProperty(SupportsGet = true)]
        public int SearchAmount { get; set; } = 10;

        [StringLength(100)]
        [BindProperty(SupportsGet = true)]
        public string? SearchFood { get; set; }

        public void OnGet()
        {
            if (!ModelState.IsValid)
            {
                return;
            }

            var csvPath = Path.Combine(_environment.ContentRootPath, "Data", "Mobile_Food_Facility_Permit.csv");
            if (!System.IO.File.Exists(csvPath))
            {
                ModelState.AddModelError(string.Empty, "Datový soubor food trucků nebyl nalezen.");
                return;
            }

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => args.Header.ToLowerInvariant(),
            };

            using var reader = new StreamReader(csvPath);
            using var csv = new CsvReader(reader, config);

            var foodFilter = SearchFood?.Trim();
            FoodTrucks = csv.GetRecords<FoodTruck>()
                .Where(truck => string.IsNullOrWhiteSpace(foodFilter)
                    || (!string.IsNullOrWhiteSpace(truck.FoodItems)
                        && truck.FoodItems.Contains(foodFilter, StringComparison.OrdinalIgnoreCase)))
                .OrderBy(truck => truck.CalculateDistance(SearchLatitude, SearchLongitude))
                .Take(SearchAmount)
                .ToList();
        }
    }
}
