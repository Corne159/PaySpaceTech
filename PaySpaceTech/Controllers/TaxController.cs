using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PaySpaceTech.Models;
using PaySpaceTech.Models.Entities;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;

namespace PaySpaceTech.Controllers
{
    public class TaxController : Controller
    {
        public IActionResult Calculate()
        {
            return View();
        }

        [HttpPost]
        public async Task<dynamic> CalculateTax([FromBody] TaxDto inputValues)
        {
            if (inputValues == null)
            {
                throw new ArgumentNullException("Invalid values received");
            }

            if (string.IsNullOrEmpty(inputValues.MonthlyIncome))
            {
                throw new ArgumentNullException("Invalid monthly income received");
            }

            if (string.IsNullOrEmpty(inputValues.PostalCode))
            {
                throw new ArgumentNullException("Invalid postal code received");
            }

            dynamic status;
            var URI = "https://localhost:7092/";

            using HttpClient client = new();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));            
            client.BaseAddress = new Uri(URI);

            var json = JsonConvert.SerializeObject(inputValues);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"api/calculations/SaveCalculation", data);
            var result = await response.Content.ReadAsStringAsync();

            try
            {
                status = JsonConvert.DeserializeObject<decimal>(result);
            }
            catch
            {
                status = "Failed";
            }
           
            return status;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}